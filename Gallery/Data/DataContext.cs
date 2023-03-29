using Gallery.Models;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }

        public DbSet<Image> Images { get; set; }
    }
}
