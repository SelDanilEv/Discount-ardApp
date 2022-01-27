using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DiscountСardApp.Application.DTOs.V1.Bank.Results;
using DiscountСardApp.Application.DTOs.V1.Bank.Requests;

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
            throw new NotImplementedException();

            //var command = new GetNotificationReportByRequestIdCommand
            //{
            //    NotificationRequestId = requestId,
            //    WithDetails = withDetails
            //};
            //return await ProcessApiCallAsync<GetNotificationReportByRequestIdCommand, ReportResultDto>(command);
        }

        [HttpGet("GetBank")]
        [ProducesResponseType(typeof(BankResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankResultDto>> GetBank(GetBankDto getBankDto)
        {
            throw new NotImplementedException();

            //var command = new GetNotificationReportByRequestIdCommand
            //{
            //    NotificationRequestId = requestId,
            //    WithDetails = withDetails
            //};
            //return await ProcessApiCallAsync<GetNotificationReportByRequestIdCommand, ReportResultDto>(command);
        }

        [HttpPost("CreateBank")]
        [ProducesResponseType(typeof(BankResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankResultDto>> CreateBank(CreateBankDto createBankDto)
        {
            throw new NotImplementedException();

            //var command = new GetNotificationReportByRequestIdCommand
            //{
            //    NotificationRequestId = requestId,
            //    WithDetails = withDetails
            //};
            //return await ProcessApiCallAsync<GetNotificationReportByRequestIdCommand, ReportResultDto>(command);
        }

        [HttpPut("UpdateBank")]
        [ProducesResponseType(typeof(BankResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankResultDto>> UpdateBank(UpdateBankDto updateBankDto)
        {
            throw new NotImplementedException();

            //var command = new GetNotificationReportByRequestIdCommand
            //{
            //    NotificationRequestId = requestId,
            //    WithDetails = withDetails
            //};
            //return await ProcessApiCallAsync<GetNotificationReportByRequestIdCommand, ReportResultDto>(command);
        }

        [HttpDelete("DeleteBank")]
        [ProducesResponseType(typeof(BankResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankResultDto>> DeleteBank(DeleteBankDto deleteBankDto)
        {
            throw new NotImplementedException();

            //var command = new GetNotificationReportByRequestIdCommand
            //{
            //    NotificationRequestId = requestId,
            //    WithDetails = withDetails
            //};
            //return await ProcessApiCallAsync<GetNotificationReportByRequestIdCommand, ReportResultDto>(command);
        }
    }
}