using AutoMapper;
using DiscountСardApp.Application.Models.V1.Store.Results;
using DiscountСardApp.Infrastructure.Contexts;
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

    public sealed class GetAllStoresQueryHandler : BaseModuleHandler<GetAllStoresQuery, List<StoreResult>>
    {
        public GetAllStoresQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<List<StoreResult>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _StoreService.GetAll();
        }
    }
}
