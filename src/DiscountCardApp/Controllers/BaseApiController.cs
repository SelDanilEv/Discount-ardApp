using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DiscountCardApp.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected readonly IMediator Mediator;
        protected readonly IMapper Mapper;

        public BaseApiController(IMediator mediator, IMapper mapper)
        {
            Mediator = mediator;
            Mapper = mapper;
        }

        protected async Task<TResult> ProcessApiCallAsync<TRequest, TResult>(TRequest request)
        {
            var response = await Mediator.Send(request);

            var result = Mapper.Map<TResult>(response);

            return result;
        }

        private async Task<TResult> ProcessApiCallAsync<TModel, TRequest, TResult>(TModel model)
        {
            var request = Mapper.Map<TRequest>(model);

            var response = await Mediator.Send(request);

            var result = Mapper.Map<TResult>(response);

            return result;
        }

        protected async Task<ActionResult<TResult>> ExecuteAction<TModel, TRequest, TResult>(TModel model)
        {
            if (model != null)
            {
                return await ProcessApiCallAsync<TModel, TRequest, TResult>(model);
            }

            return BadRequest();
        }

        protected async Task<TResult> ProcessApiCallWithoutMappingAsync<TRequest, TResult>(TRequest request)
        {
            var response = await Mediator.Send(request);

            return (TResult) response;
        }

        protected async Task ProcessApiCallAsync<TRequest>(TRequest request)
        {
            await Mediator.Send(request);
        }
    }
}