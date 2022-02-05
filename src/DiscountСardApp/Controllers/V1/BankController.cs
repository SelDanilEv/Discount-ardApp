using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DiscountСardApp.Application.DTOs.V1.Bank.Results;
using DiscountСardApp.Application.DTOs.V1.Bank.Requests;
using DiscountСardApp.Application.Modules.BankModule.Commands;
using DiscountСardApp.Application.Modules.BankModule.Queries;

namespace DiscountСardApp.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [SwaggerTag("")]
    public sealed class BankController : BaseApiController
    {
        public BankController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        { }

        [HttpGet("GetAllBanks")]
        [ProducesResponseType(typeof(List<BankResultDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<BankResultDto>>> GetBanks()
        {
            var query = new GetAllBanksQuery();

            return await ProcessApiCallAsync<GetAllBanksQuery, List<BankResultDto>>(query);
        }

        [HttpGet("GetBank")]
        [ProducesResponseType(typeof(BankResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankResultDto>> GetBank(GetBankDto getBankDto)
        {
            var query = new GetBankQuery
            {
                Id = getBankDto.Id
            };

            return await ProcessApiCallAsync<GetBankQuery, BankResultDto>(query);
        }

        [HttpPost("CreateBank")]
        [ProducesResponseType(typeof(BankResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankResultDto>> CreateBank(CreateBankDto createBankDto)
        {
            var command = new CreateBankCommand
            {
                Name = createBankDto.Name,
            };

            return await ProcessApiCallAsync<CreateBankCommand, BankResultDto>(command);
        }

        [HttpPut("UpdateBank")]
        [ProducesResponseType(typeof(BankResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankResultDto>> UpdateBank(UpdateBankDto updateBankDto)
        {
            var command = new UpdateBankCommand
            {
                Id = updateBankDto.Id,
                Name = updateBankDto.Name,
            };

            return await ProcessApiCallAsync<UpdateBankCommand, BankResultDto>(command);
        }

        [HttpDelete("DeleteBank")]
        [ProducesResponseType(typeof(BankResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankResultDto>> DeleteBank(DeleteBankDto deleteBankDto)
        {
            var command = new DeleteBankCommand
            {
                Id = deleteBankDto.Id,
            };

            return await ProcessApiCallAsync<DeleteBankCommand, BankResultDto>(command);
        }
    }
}