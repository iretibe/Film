using Film.Application.Responses;
using MediatR;

namespace Film.Application.Commands
{
    public class CreateFilmCommand : IRequest<FilmResponse>
    {
        public string FilmName { get; set; }
        public string DirectorName { get; set; }
        public DateTime ReleasedYear { get; set; }
    }
}
