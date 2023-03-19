using Les_Birds.Models;
using Microsoft.EntityFrameworkCore;

namespace Les_Birds.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Bird> Bird { get; set; }
        public DbSet<Image> Image { get; set; }
    }
}
