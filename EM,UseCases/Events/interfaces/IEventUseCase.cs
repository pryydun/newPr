using EM.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases.Events.interfaces
{
    public interface IEventUseCase
    {
        Task RegisterUserToEventAsync(string userId, int eventId,string name);
        
    }
}
