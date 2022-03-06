using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DiscountCardApp.Application.DTOs.V1.DiscountCardDto.Results;
using DiscountCardApp.Application.DTOs.V1.DiscountCardDto.Requests;
using DiscountCardApp.Application.Modules.DiscountCardModule.Commands;
using DiscountCardApp.Application.Modules.DiscountCardModule.Queries;

namespace DiscountCardApp.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [SwaggerTag("")]
    public sealed class DiscountCardController : BaseApiController
    {
        public DiscountCardController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        { }

        [HttpGet("GetAllDiscountCards")]
        [ProducesResponseType(typeof(List<DiscountCardResultDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<DiscountCardResultDto>>> GetDiscountCards()
        {
            var query = new GetAllDiscountCardsQuery();

            return await ProcessApiCallAsync<GetAllDiscountCardsQuery, List<DiscountCardResultDto>>(query);
        }

        [HttpGet("GetDiscountCard")]
        [ProducesResponseType(typeof(DiscountCardResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DiscountCardResultDto>> GetDiscountCard(GetDiscountCardDto getDiscountCardDto)
        {
            var query = new GetDiscountCardQuery
            {
                Id = getDiscountCardDto.Id
            };

            return await ProcessApiCallAsync<GetDiscountCardQuery, DiscountCardResultDto>(query);
        }

        [HttpPost("CreateDiscountCard")]
        [ProducesResponseType(typeof(DiscountCardResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DiscountCardResultDto>> CreateDiscountCard(CreateDiscountCardDto createDiscountCardDto)
        {
            var command = new CreateDiscountCardCommand
            {
                BankId = createDiscountCardDto.BankId,
                Name = createDiscountCardDto.Name,
                Conditions = createDiscountCardDto.Conditions,
            };

            return await ProcessApiCallAsync<CreateDiscountCardCommand, DiscountCardResultDto>(command);
        }

        [HttpPut("UpdateDiscountCard")]
        [ProducesResponseType(typeof(DiscountCardResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DiscountCardResultDto>> UpdateDiscountCard(UpdateDiscountCardDto updateDiscountCardDto)
        {
            var command = new UpdateDiscountCardCommand
            {
                Id = updateDiscountCardDto.Id,
                BankId = updateDiscountCardDto.BankId,
                Name = updateDiscountCardDto.Name,
                Conditions = updateDiscountCardDto.Conditions,
            };

            return await ProcessApiCallAsync<UpdateDiscountCardCommand, DiscountCardResultDto>(command);
        }

        [HttpDelete("DeleteDiscountCard")]
        [ProducesResponseType(typeof(DiscountCardResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DiscountCardResultDto>> DeleteDiscountCard(DeleteDiscountCardDto deleteDiscountCardDto)
        {
            var command = new DeleteDiscountCardCommand
            {
                Id = deleteDiscountCardDto.Id,
            };

            return await ProcessApiCallAsync<DeleteDiscountCardCommand, DiscountCardResultDto>(command);
        }
    }
}