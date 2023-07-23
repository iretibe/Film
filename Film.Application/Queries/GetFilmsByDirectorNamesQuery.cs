using Film.Application.Responses;
using MediatR;

namespace Film.Application.Queries
{
    public class GetFilmsByDirectorNamesQuery : IRequest<IEnumerable<FilmResponse>>
    {
        public string DirectorName { get; set; }

        public GetFilmsByDirectorNamesQuery(string directorName)
        {
            DirectorName = directorName;
        }
    }
}
