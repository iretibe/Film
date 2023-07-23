using Microsoft.EntityFrameworkCore;

namespace Film.Infrastructure.Data
{
    public class FilmDbContext : DbContext
    {
        public FilmDbContext(DbContextOptions<FilmDbContext> options) : base(options) { }

        public DbSet<Core.Entities.Film> Films { get; set; }
    }
}
