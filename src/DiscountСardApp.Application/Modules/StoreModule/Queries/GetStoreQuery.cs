using AutoMapper;
using DiscountСardApp.Application.Models.V1.Store.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.StoreModule.Queries
{
    public sealed class GetStoreQuery : IRequest<StoreResult>
    {
        public Guid Id { get; set; }
    }

    public sealed class GetStoreQueryValidator : AbstractValidator<GetStoreQuery>
    {
        public GetStoreQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the Store id!");
        }
    }

    public sealed class GetStoreQueryHandler : IRequestHandler<GetStoreQuery, StoreResult>
    {
        private readonly IMapper _mapper;

        public GetStoreQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<StoreResult> Handle(GetStoreQuery request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _StoreService.GetAll(getStoreModel);
        }
    }
}
