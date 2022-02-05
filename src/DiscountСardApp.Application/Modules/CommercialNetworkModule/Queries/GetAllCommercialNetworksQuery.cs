using AutoMapper;
using DiscountСardApp.Application.Models.V1.CommercialNetwork.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.CommercialNetworkModule.Queries
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

    public sealed class GetAllCommercialNetworksQueryHandler : IRequestHandler<GetAllCommercialNetworksQuery, List<CommercialNetworkResult>>
    {
        private readonly IMapper _mapper;

        public GetAllCommercialNetworksQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<CommercialNetworkResult>> Handle(GetAllCommercialNetworksQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _CommercialNetworkService.GetAll();
        }
    }
}
