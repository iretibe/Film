namespace Film.Core.Repositories
{
    public interface IFilmRepository : IRepository<Entities.Film>
    {
        Task<IEnumerable<Entities.Film>> GetAllFilmsByDirectorNameAsync(string directorName);
    }
}
