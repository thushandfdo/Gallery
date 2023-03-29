using Gallery.Data;
using Gallery.DTOs;
using Gallery.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Gallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly DataContext _context;

        public GalleryController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostImage([FromForm] DTOImage image)
        {
            if (image == null || image.Image == null)
            {
                return BadRequest("No file selected");
            }

            byte[] fileBytes;

            using (var ms = new MemoryStream())
            {
                image.Image.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            var filePath = $"./Gallery/{image.EventId}.png";

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await stream.WriteAsync(fileBytes);
            }

            var newImage = new Image
            {
                EventId = image.EventId,
                Path = $"{image.EventId}.png",
                Description = image.Description
            };

            await _context.Images.AddAsync(newImage);
            _context.SaveChanges();

            return Ok("Image Saved");
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<IFormFile>> GetImage(int eventId)
        {
            var filePath = $"./Gallery/{eventId}.png";

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Not found");
            }

            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            return new FileStreamResult(fileStream, $"image/png");
        }
    }
}
