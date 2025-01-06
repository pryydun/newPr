using System.ComponentModel.DataAnnotations;

namespace EM.CoreBusiness
{
    public class Event
    {
            public int Id { get; set; } // Унікальний ідентифікатор події

        [Required]
       
        public string Title { get; set; } = string.Empty; // Назва події
        [Required]
        public string Description { get; set; } = string.Empty; // Опис події

        [Required]
        public DateTime StartDate { get; set; } // Дата початку
        [Required]
        public DateTime EndDate { get; set; } // Дата завершення
       
        [Required]
        public string Location { get; set; } = string.Empty; // Локація

        public ICollection<UserEvents> UserEvents { get; set; } = new List<UserEvents>();
    }
}
