using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.CoreBusiness
{

    public class UserEvents
    {
        public int Id { get; set; } // Унікальний ідентифікатор
        public string UserId { get; set; } // ID користувача з AspNetUsers
        public int EventId { get; set; }
        public Event? Event { get; set; }
        public string? Name { get; set; } // Ім'я користувача
    }
}
