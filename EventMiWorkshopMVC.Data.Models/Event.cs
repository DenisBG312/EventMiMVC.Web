using System.ComponentModel.DataAnnotations;

using static EventMiWorkshopMVC.Common.EntityConstraints;

namespace EventMiWorkshopMVC.Data.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EventNameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(EventPlaceMaxLength)]
        public string Place { get; set; } = null!;
    }
}
