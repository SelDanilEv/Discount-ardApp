using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DiscountCardApp.Application.DTOs.V1.CommercialNetworkDto.Results;
using DiscountCardApp.Application.DTOs.V1.CommercialNetworkDto.Requests;
using DiscountCardApp.Application.Modules.CommercialNetworkModule.Commands;
using DiscountCardApp.Application.Modules.CommercialNetworkModule.Queries;

namespace DiscountCardApp.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [SwaggerTag("")]
    public sealed class CommercialNetworkController : BaseApiController
    {
        public CommercialNetworkController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        { }

        [HttpGet("GetAllCommercialNetworks")]
        [ProducesResponseType(typeof(List<CommercialNetworkResultDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<CommercialNetworkResultDto>>> GetCommercialNetworks()
        {
            var query = new GetAllCommercialNetworksQuery();

            return await ProcessApiCallAsync<GetAllCommercialNetworksQuery, List<CommercialNetworkResultDto>>(query);
        }

        [HttpGet("GetCommercialNetwork")]
        [ProducesResponseType(typeof(CommercialNetworkResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CommercialNetworkResultDto>> GetCommercialNetwork(GetCommercialNetworkDto getCommercialNetworkDto)
        {
            var query = new GetCommercialNetworkQuery
            {
                Id = getCommercialNetworkDto.Id
            };

            return await ProcessApiCallAsync<GetCommercialNetworkQuery, CommercialNetworkResultDto>(query);
        }

        [HttpPost("CreateCommercialNetwork")]
        [ProducesResponseType(typeof(CommercialNetworkResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CommercialNetworkResultDto>> CreateCommercialNetwork(CreateCommercialNetworkDto createCommercialNetworkDto)
        {
            var command = new CreateCommercialNetworkCommand
            {
                Name = createCommercialNetworkDto.Name
            };

            return await ProcessApiCallAsync<CreateCommercialNetworkCommand, CommercialNetworkResultDto>(command);
        }

        [HttpPut("UpdateCommercialNetwork")]
        [ProducesResponseType(typeof(CommercialNetworkResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CommercialNetworkResultDto>> UpdateCommercialNetwork(UpdateCommercialNetworkDto updateCommercialNetworkDto)
        {
            var command = new UpdateCommercialNetworkCommand
            {
                Id = updateCommercialNetworkDto.Id,
                Name = updateCommercialNetworkDto.Name
            };

            return await ProcessApiCallAsync<UpdateCommercialNetworkCommand, CommercialNetworkResultDto>(command);
        }

        [HttpDelete("DeleteCommercialNetwork")]
        [ProducesResponseType(typeof(CommercialNetworkResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CommercialNetworkResultDto>> DeleteCommercialNetwork(DeleteCommercialNetworkDto deleteCommercialNetworkDto)
        {
            var command = new DeleteCommercialNetworkCommand
            {
                Id = deleteCommercialNetworkDto.Id,
            };

            return await ProcessApiCallAsync<DeleteCommercialNetworkCommand, CommercialNetworkResultDto>(command);
        }
    }
}