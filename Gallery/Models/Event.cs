using System.ComponentModel.DataAnnotations;

namespace Gallery.Models
{
    public class Event
    {
        [Required, Key]
        public int EventId { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
