using AutoMapper;
using DiscountСardApp.Application.Models.V1.Store.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.StoreModule.Queries
{
    public sealed class GetAllStoresQuery : IRequest<List<StoreResult>>
    {
    }

    public sealed class GetAllStoresQueryValidator : AbstractValidator<GetAllStoresQuery>
    {
        public GetAllStoresQueryValidator()
        {
        }
    }

    public sealed class GetAllStoresQueryHandler : IRequestHandler<GetAllStoresQuery, List<StoreResult>>
    {
        private readonly IMapper _mapper;

        public GetAllStoresQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<StoreResult>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _StoreService.GetAll();
        }
    }
}
