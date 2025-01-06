namespace EM_UseCases
{
    public interface IUserEventService
    {
        Task<bool> IsUserRegisteredAsync(string userId, int eventId);
        Task RegisterUserForEventAsync(string userId, int eventId, string name);
        Task UnregisterUserFromEventAsync(string userId, int eventId, string name);
        Task<List<string>> GetRegisteredUsersAsync(int eventId);
    }


}