using Microsoft.Extensions.Logging;

namespace Film.Infrastructure.Data
{
    public class FilmContextSeed
    {
        public static async Task SeedAsync(FilmDbContext context, ILoggerFactory factory, int? retry = 0)
        {
            int retryCount = retry.Value;

            try
            {
                await context.Database.EnsureCreatedAsync();

                if (!context.Films.Any()) 
                {
                    context.Films.AddRange(GetFilms());

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryCount < 3)
                {
                    retryCount++;
                    var log = factory.CreateLogger<FilmContextSeed>();
                    log.LogError($"Execution occurred while connecting: {ex.Message}");
                    await SeedAsync(context, factory, retry);
                }
            }
        }

        private static Core.Entities.Film[] GetFilms()
        {
            return new Core.Entities.Film[] 
            {
                new Core.Entities.Film
                {
                    FilmName = "Avatar", DirectorName = "James Cameron", ReleasedYear = Convert.ToDateTime("December 17, 2009")
                },
                new Core.Entities.Film
                {
                    FilmName = "Titanic", DirectorName = "James Cameron", ReleasedYear = Convert.ToDateTime("December 19, 1997")
                },
                new Core.Entities.Film
                {
                    FilmName = "Merlin", DirectorName = "Steve Barron", ReleasedYear = Convert.ToDateTime("April 26, 1998")
                },
                new Core.Entities.Film
                {
                    FilmName = "Harry Potter", DirectorName = "J. K. Rowling", ReleasedYear = Convert.ToDateTime("November 14, 2001")
                }
            };
        }
    }
}
