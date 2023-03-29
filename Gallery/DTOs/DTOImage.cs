namespace Gallery.DTOs
{
    public class DTOImage
    {
        public int EventId { get; set; }

        public string? Description { get; set; }

        public IFormFile? Image { get; set; }
    }
}
