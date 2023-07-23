using Film.Application.Commands;
using Film.Application.Queries;
using Film.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Film.Api.Controllers
{
    public class FilmController : BaseController
    {
        private readonly IMediator _mediator;

        public FilmController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetFilmsByDirectorName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<FilmResponse>>> GetFilmsByDirectorName(string directorName)
        {
            var query = new GetFilmsByDirectorNamesQuery(directorName);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("CreateFilm")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FilmResponse>> CreateFilm(CreateFilmCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
