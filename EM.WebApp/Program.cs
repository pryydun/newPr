 
using Elfie.Serialization;
using EM.Plugins.EFCoreSQL;
using EM.Plugins.EFCoreSQLServer;
 
using EM.WebApp.Components;
using EM_UseCases.Events;
using EM.WebApp.Components.Account;
using EM.WebApp.Data;

using EM_UseCases.Events.interfaces;
using EM_UseCases.PluginInterfaces;
 
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EM_UseCases;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContextFactory<EventContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Event")));



builder.Services.AddRazorComponents();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("accounts") ?? throw new InvalidOperationException("Connection string 'EMaccounts' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();














 
    // Реєструємо репозиторії для SQL Server
    builder.Services.AddTransient<IEventRepository, EventRepository>();
    
     
    

 

builder.Services.AddRazorComponents();
 
builder.Services.AddTransient<IViewEventsByNameUseCase, ViewEventsByNameUseCase>();
builder.Services.AddTransient<IEditEventUseCase, EditEventUseCase>();
builder.Services.AddTransient<IAddEventsUseCase, AddEventsUseCase>();
builder.Services.AddTransient<IViewEventByIdUseCase, ViewEventByIdUseCase>();
builder.Services.AddTransient<IDeleteEventUseCase, DeleteEventUseCase>();
builder.Services.AddScoped<IUserEventService, UserEventService>();




builder.Services.AddScoped<IUserEventRepository, UserEventRepository>();
builder.Services.AddScoped<IEventUseCase, EventUseCase>();
 
 



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

 

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
 
app.MapAdditionalIdentityEndpoints();

app.Run();
