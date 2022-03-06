using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DiscountCardApp.Application.DTOs.V1.DashboardDto.Results;
using DiscountCardApp.Application.Modules.DashboardModule.Queries;

namespace DiscountCardApp.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [SwaggerTag("")]
    public sealed class DashboardController : BaseApiController
    {
        public DashboardController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        { }

        [HttpGet("GetDashboardByCategoryId")]
        [ProducesResponseType(typeof(DashboardResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DashboardResultDto>> GetDashboardByCategoryId(Guid categoryId)
        {
            var query = new GetDashboardByCategoryIdQuery
            {
                CategoryId = categoryId
            };

            var result = await ProcessApiCallAsync<GetDashboardByCategoryIdQuery, DashboardResultDto>(query);

            return result;
        }
    }
}