using AutoMapper;
using DiscountСardApp.Application.Models.V1.CommercialNetwork.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.CommercialNetworkModule.Queries
{
    public sealed class GetCommercialNetworkQuery : IRequest<CommercialNetworkResult>
    {
        public Guid Id { get; set; }
    }

    public sealed class GetCommercialNetworkQueryValidator : AbstractValidator<GetCommercialNetworkQuery>
    {
        public GetCommercialNetworkQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the commercial network id!");
        }
    }

    public sealed class GetCommercialNetworkQueryHandler : IRequestHandler<GetCommercialNetworkQuery, CommercialNetworkResult>
    {
        private readonly IMapper _mapper;

        public GetCommercialNetworkQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<CommercialNetworkResult> Handle(GetCommercialNetworkQuery request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _CommercialNetworkService.GetAll(getCommercialNetworkModel);
        }
    }
}
