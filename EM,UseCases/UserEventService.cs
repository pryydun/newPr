using EM.CoreBusiness;
using EM_UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases
{
    public class UserEventService : IUserEventService
    {
        private readonly IUserEventRepository _userEventRepository;

        public UserEventService(IUserEventRepository userEventRepository)
        {
            _userEventRepository = userEventRepository;
        }

        public async Task<bool> IsUserRegisteredAsync(string userId, int eventId)
        {
            return await _userEventRepository.IsUserRegisteredAsync(userId, eventId);
        }

        public async Task RegisterUserForEventAsync(string userId, int eventId, string name)
        {
            await _userEventRepository.AddUserEventAsync( userId, eventId, name);
        }

        public async Task UnregisterUserFromEventAsync(string userId, int eventId,string name)
        {
            await _userEventRepository.RemoveUserEventAsync(userId, eventId, name);
        }

        public async Task<List<string>> GetRegisteredUsersAsync(int eventId)
        {
            return await _userEventRepository.GetRegisteredUserNamesAsync(eventId);
        }
    }


}
