using Film.Application.Commands;
using Film.Application.Mappers;
using Film.Application.Responses;
using Film.Core.Repositories;
using MediatR;

namespace Film.Application.Handlers
{
    public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommand, FilmResponse>
    {
        private readonly IFilmRepository _repository;

        public CreateFilmCommandHandler(IFilmRepository repository)
        {
            _repository = repository;
        }

        public async Task<FilmResponse> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
        {
            var films = FilmMapper.Mapper.Map<Core.Entities.Film>(request);

            if (films is null)
            {
                throw new ApplicationException("There is an issue with mapping...");
            }

            var newFilm = await _repository.AddAsync(films);

            var response = FilmMapper.Mapper.Map<FilmResponse>(newFilm);

            return response;
        }
    }
}
