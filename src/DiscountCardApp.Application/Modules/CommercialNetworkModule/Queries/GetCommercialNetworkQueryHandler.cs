using AutoMapper;
using DiscountCardApp.Application.Models.V1.CommercialNetwork.Results;
using DiscountCardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountCardApp.Application.Modules.CommercialNetworkModule.Queries
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

    public sealed class GetCommercialNetworkQueryHandler : BaseModuleHandler<GetCommercialNetworkQuery, CommercialNetworkResult>
    {
        public GetCommercialNetworkQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<CommercialNetworkResult> Handle(GetCommercialNetworkQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _CommercialNetworkService.GetAll(getCommercialNetworkModel);
        }
    }
}
