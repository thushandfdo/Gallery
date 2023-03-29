using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gallery.Models
{
    public class Image
    {
        [Required, Key]
        public int Id { get; set; }

        [Required, ForeignKey("Event")]
        public int EventId { get; set; }

        public Event? Event { get; set; }

        [Required]
        public string? Path { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
