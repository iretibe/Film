using Film.Core.Repositories;
using Film.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Film.Infrastructure.Repositories
{
    public class FilmRepository : Repository<Core.Entities.Film>, IFilmRepository
    {
        public FilmRepository(FilmDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Core.Entities.Film>> GetAllFilmsByDirectorNameAsync(string directorName)
        {
            return await _context.Films
                .Where(f  => f.DirectorName == directorName)
                .ToListAsync();
        }
    }
}
