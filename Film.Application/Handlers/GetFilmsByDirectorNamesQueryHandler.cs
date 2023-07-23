using Film.Application.Mappers;
using Film.Application.Queries;
using Film.Application.Responses;
using Film.Core.Repositories;
using MediatR;

namespace Film.Application.Handlers
{
    public class GetFilmsByDirectorNamesQueryHandler : IRequestHandler<GetFilmsByDirectorNamesQuery, IEnumerable<FilmResponse>>
    {
        private readonly IFilmRepository _repository;

        public GetFilmsByDirectorNamesQueryHandler(IFilmRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FilmResponse>> Handle(GetFilmsByDirectorNamesQuery request, CancellationToken cancellationToken)
        {
            var films = await _repository.GetAllFilmsByDirectorNameAsync(request.DirectorName);

            var response = FilmMapper.Mapper.Map<IEnumerable<FilmResponse>>(films);

            return response;
        }
    }
}
