using EM.CoreBusiness;
using EM.Plugins.EFCoreSQL;
using EM_UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class UserEventRepository : IUserEventRepository
{
    private readonly EventContext _context;

    public UserEventRepository(EventContext context)
    {
        _context = context;
    }

    public async Task<bool> IsUserRegisteredAsync(string userId, int eventId)
    {
        return await _context.UserEvents.AnyAsync(ue => ue.UserId == userId && ue.EventId == eventId);
    }
    public async Task AddUserEventAsync(string userId, int eventId, string name)
    {
        // Створюємо новий об'єкт UserEvent
        var userEvent = new UserEvents
        {
            UserId = userId,
            EventId = eventId,
            Name = name
        };

        // Додаємо до контексту
        _context.UserEvents.Add(userEvent);

        // Зберігаємо зміни в базі даних
        await _context.SaveChangesAsync();
    }

    public async Task RemoveUserEventAsync(string userId, int eventId, string name)
    {
        var userEvent = await _context.UserEvents
            .FirstOrDefaultAsync(ue => ue.UserId == userId && ue.EventId == eventId && ue.Name == name);

        if (userEvent != null)
        {
            _context.UserEvents.Remove(userEvent);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<string>> GetRegisteredUserNamesAsync(int eventId)
    {
        return await _context.UserEvents
            .Where(ue => ue.EventId == eventId)
            .Select(ue => ue.Name) // Повертаємо ім'я користувача
            .ToListAsync();
    }
}
