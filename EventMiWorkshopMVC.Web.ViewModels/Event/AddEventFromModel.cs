using System.ComponentModel.DataAnnotations;
using EventMiWorkshopMVC.Common;

namespace EventMiWorkshopMVC.Web.ViewModels.Event
{
    using static EntityConstraints;
    public class AddEventFromModel
    {
        [Required]
        [StringLength(EventNameMaxLength, MinimumLength = EventNameMinLength)]
        public string Name { get; set; } = null!;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(EventPlaceMaxLength, MinimumLength = EventPlaceMinLength)]
        public string Place { get; set; } = null!;
    }
}
