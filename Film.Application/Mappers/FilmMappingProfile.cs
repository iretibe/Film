using AutoMapper;
using Film.Application.Commands;
using Film.Application.Responses;

namespace Film.Application.Mappers
{
    internal class FilmMappingProfile : Profile
    {
        public FilmMappingProfile()
        {
            CreateMap<Core.Entities.Film, FilmResponse>().ReverseMap();
            CreateMap<Core.Entities.Film, CreateFilmCommand>().ReverseMap();
        }
    }
}
