using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("SessionInfo")]
    public class SessionInfo
    {
        [Key]
        public int SessionId { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string SessionTitle { get; set; }

        public int? SpeakerId { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime SessionStart { get; set; }

        [Required]
        public DateTime SessionEnd { get; set; }

        public string SessionUrl { get; set; }
    }
}
