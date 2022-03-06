using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DiscountCardApp.Application.DTOs.V1.MCCCodeDto.Results;
using DiscountCardApp.Application.DTOs.V1.MCCCodeDto.Requests;
using DiscountCardApp.Application.Modules.MCCCodeModule.Commands;
using DiscountCardApp.Application.Modules.MCCCodeModule.Queries;

namespace DiscountCardApp.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [SwaggerTag("")]
    public sealed class MCCCodeController : BaseApiController
    {
        public MCCCodeController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        { }

        [HttpGet("GetAllMCCCodes")]
        [ProducesResponseType(typeof(List<MCCCodeResultDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<MCCCodeResultDto>>> GetMCCCodes()
        {
            var query = new GetAllMCCCodesQuery();

            return await ProcessApiCallAsync<GetAllMCCCodesQuery, List<MCCCodeResultDto>>(query);
        }

        [HttpGet("GetMCCCode")]
        [ProducesResponseType(typeof(MCCCodeResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MCCCodeResultDto>> GetMCCCode(GetMCCCodeDto getMCCCodeDto)
        {
            var query = new GetMCCCodeQuery
            {
                Id = getMCCCodeDto.Id
            };

            return await ProcessApiCallAsync<GetMCCCodeQuery, MCCCodeResultDto>(query);
        }

        [HttpPost("CreateMCCCode")]
        [ProducesResponseType(typeof(MCCCodeResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MCCCodeResultDto>> CreateMCCCode(CreateMCCCodeDto createMCCCodeDto)
        {
            var command = new CreateMCCCodeCommand
            {
                Code = createMCCCodeDto.Code,
                Description = createMCCCodeDto.Description,
            };

            return await ProcessApiCallAsync<CreateMCCCodeCommand, MCCCodeResultDto>(command);
        }

        [HttpPut("UpdateMCCCode")]
        [ProducesResponseType(typeof(MCCCodeResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MCCCodeResultDto>> UpdateMCCCode(UpdateMCCCodeDto updateMCCCodeDto)
        {
            var command = new UpdateMCCCodeCommand
            {
                Id = updateMCCCodeDto.Id,
                Code = updateMCCCodeDto.Code,
                Description = updateMCCCodeDto.Description,
            };

            return await ProcessApiCallAsync<UpdateMCCCodeCommand, MCCCodeResultDto>(command);
        }

        [HttpDelete("DeleteMCCCode")]
        [ProducesResponseType(typeof(MCCCodeResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MCCCodeResultDto>> DeleteMCCCode(DeleteMCCCodeDto deleteMCCCodeDto)
        {
            var command = new DeleteMCCCodeCommand
            {
                Id = deleteMCCCodeDto.Id,
            };

            return await ProcessApiCallAsync<DeleteMCCCodeCommand, MCCCodeResultDto>(command);
        }
    }
}