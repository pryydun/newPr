using EM.CoreBusiness;
using EM_UseCases.Events.interfaces;
using EM_UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EM_UseCases.Events
{
    public class EventUseCase : IEventUseCase
    {
        private readonly IUserEventRepository _userEventRepository;

        public EventUseCase(IUserEventRepository userEventRepository)
        {
            _userEventRepository = userEventRepository;
        }

        public async Task RegisterUserToEventAsync(string userId, int eventId, string name)
        {
            var userEvent = new UserEvents
            {
                UserId = userId,
                EventId = eventId
            };

            await _userEventRepository.AddUserEventAsync(  userId,  eventId,  name);
        }

         
    }
}
 