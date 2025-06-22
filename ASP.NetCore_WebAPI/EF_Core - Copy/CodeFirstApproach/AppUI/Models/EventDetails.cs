using System.ComponentModel.DataAnnotations;

namespace AppUI.Models
{
    public class EventDetails
    {
        public int EventId { get; set; }

        public string EventName { get; set; }

        public string EventCategory { get; set; }

        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
