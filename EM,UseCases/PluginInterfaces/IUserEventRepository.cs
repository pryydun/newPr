using EM.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases.PluginInterfaces
{
    public interface IUserEventRepository
    {
        Task<bool> IsUserRegisteredAsync(string userId, int eventId);
        Task AddUserEventAsync(string userId, int eventId, string name);
        Task RemoveUserEventAsync(string userId, int eventId, string name);
        Task<List<string>> GetRegisteredUserNamesAsync(int eventId);
    }


}
