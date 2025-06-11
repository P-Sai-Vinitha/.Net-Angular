using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("EventDetails")]
    public class EventDetails
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string EventName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string EventCategory { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        [Required]
        [RegularExpression("Active|In-Active", ErrorMessage = "Status must be 'Active' or 'In-Active'.")]
        public string Status { get; set; }
    }
}
