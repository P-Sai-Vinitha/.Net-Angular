using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("ParticipantEventDetails")]
    public class ParticipantEventDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ParticipantEmailId { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        [RegularExpression("Yes|No", ErrorMessage = "IsAttended must be 'Yes' or 'No'.")]
        public string IsAttended { get; set; }
    }
}
