using AutoMapper;
using DiscountСardApp.Application.Models.V1.CommercialNetwork.Results;
using DiscountСardApp.Domain.Entities;
using DiscountСardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.CommercialNetworkModule.Commands
{
    public sealed class CreateCommercialNetworkCommand : IRequest<CommercialNetworkResult>
    {
        public string Name { get; set; } = String.Empty;
    }

    public sealed class CreateCommercialNetworkCommandValidator : AbstractValidator<CreateCommercialNetworkCommand>
    {
        public CreateCommercialNetworkCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Please provide the commercial network name!");
        }
    }

    public sealed class CreateCommercialNetworkCommandHandler : BaseModuleHandler<CreateCommercialNetworkCommand, CommercialNetworkResult>
    {
        public CreateCommercialNetworkCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<CommercialNetworkResult> Handle(CreateCommercialNetworkCommand request, CancellationToken cancellationToken)
        {
            var newCommercialNetwork = _mapper.Map<CommercialNetwork>(request);

            await _dbContext.CommercialNetworks.AddAsync(newCommercialNetwork);
            await _dbContext.SaveChangesAsync();

            var commercialNetworkResult = _mapper.Map<CommercialNetworkResult>(newCommercialNetwork);

            return commercialNetworkResult;
        }
    }
}
