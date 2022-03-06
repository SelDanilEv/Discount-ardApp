using AutoMapper;
using DiscountCardApp.Application.Models.V1.CommercialNetwork.Results;
using DiscountCardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiscountCardApp.Application.Modules.CommercialNetworkModule.Queries
{
    public sealed class GetAllCommercialNetworksQuery : IRequest<List<CommercialNetworkResult>>
    {
    }

    public sealed class GetAllCommercialNetworksQueryValidator : AbstractValidator<GetAllCommercialNetworksQuery>
    {
        public GetAllCommercialNetworksQueryValidator()
        {
        }
    }

    public sealed class GetAllCommercialNetworksQueryHandler : BaseModuleHandler<GetAllCommercialNetworksQuery, List<CommercialNetworkResult>>
    {
        public GetAllCommercialNetworksQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<List<CommercialNetworkResult>> Handle(GetAllCommercialNetworksQuery request, CancellationToken cancellationToken)
        {
            var comercialNetworksList = await _dbContext.CommercialNetworks
                        .Include(c => c.Stores)
                        .ThenInclude(c => c.MCCCode)
                        .ToListAsync();

            var commercialNetworkResult = _mapper.Map<List<CommercialNetworkResult>>(comercialNetworksList);

            return commercialNetworkResult;
        }
    }
}
