using Microsoft.EntityFrameworkCore;

namespace Polygamy.Models
{
    public class PolygamyContext : DbContext
    {
        public PolygamyContext (DbContextOptions<PolygamyContext> options)
            : base(options)
        {
        }

        public DbSet<Polygamy.Models.Student> Student { get; set; }
    }
}
