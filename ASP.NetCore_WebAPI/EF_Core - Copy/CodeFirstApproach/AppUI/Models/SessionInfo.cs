using System.ComponentModel.DataAnnotations;

namespace AppUI.Models
{
    public class SessionInfo
    {
        public int SessionId { get; set; }
        public int EventId { get; set; }
        public string SessionTitle { get; set; }

        public int? SpeakerId { get; set; }

        public string Description { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime SessionEnd { get; set; }

        public string SessionUrl { get; set; }
    }
}
