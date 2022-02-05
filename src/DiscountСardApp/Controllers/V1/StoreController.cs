using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DiscountСardApp.Application.DTOs.V1.StoreDto.Results;
using DiscountСardApp.Application.DTOs.V1.StoreDto.Requests;
using DiscountСardApp.Application.Modules.StoreModule.Commands;
using DiscountСardApp.Application.Modules.StoreModule.Queries;

namespace DiscountСardApp.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [SwaggerTag("")]
    public sealed class StoreController : BaseApiController
    {
        public StoreController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        { }

        [HttpGet("GetAllStores")]
        [ProducesResponseType(typeof(List<StoreResultDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<StoreResultDto>>> GetStores()
        {
            var query = new GetAllStoresQuery();

            return await ProcessApiCallAsync<GetAllStoresQuery, List<StoreResultDto>>(query);
        }

        [HttpGet("GetStore")]
        [ProducesResponseType(typeof(StoreResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StoreResultDto>> GetStore(GetStoreDto getStoreDto)
        {
            var query = new GetStoreQuery
            {
                Id = getStoreDto.Id
            };

            return await ProcessApiCallAsync<GetStoreQuery, StoreResultDto>(query);
        }

        [HttpPost("CreateStore")]
        [ProducesResponseType(typeof(StoreResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StoreResultDto>> CreateStore(CreateStoreDto createStoreDto)
        {
            var command = new CreateStoreCommand
            {
                CommertialNetworkId = createStoreDto.CommertialNetworkId,
                MCCCodeId = createStoreDto.MCCCodeId,
                Address = createStoreDto.Address,
            };

            return await ProcessApiCallAsync<CreateStoreCommand, StoreResultDto>(command);
        }

        [HttpPut("UpdateStore")]
        [ProducesResponseType(typeof(StoreResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StoreResultDto>> UpdateStore(UpdateStoreDto updateStoreDto)
        {
            var command = new UpdateStoreCommand
            {
                Id = updateStoreDto.Id,
                CommertialNetworkId = updateStoreDto.CommertialNetworkId,
                MCCCodeId = updateStoreDto.MCCCodeId,
                Address = updateStoreDto.Address,
            };

            return await ProcessApiCallAsync<UpdateStoreCommand, StoreResultDto>(command);
        }

        [HttpDelete("DeleteStore")]
        [ProducesResponseType(typeof(StoreResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StoreResultDto>> DeleteStore(DeleteStoreDto deleteStoreDto)
        {
            var command = new DeleteStoreCommand
            {
                Id = deleteStoreDto.Id,
            };

            return await ProcessApiCallAsync<DeleteStoreCommand, StoreResultDto>(command);
        }
    }
}