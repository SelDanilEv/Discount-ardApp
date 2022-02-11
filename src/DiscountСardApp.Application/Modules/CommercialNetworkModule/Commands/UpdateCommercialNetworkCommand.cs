using AutoMapper;
using DiscountСardApp.Application.Models.V1.CommercialNetwork.Results;
using DiscountСardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.CommercialNetworkModule.Commands
{
    public sealed class UpdateCommercialNetworkCommand : IRequest<CommercialNetworkResult>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }

    public sealed class UpdateCommercialNetworkCommandValidator : AbstractValidator<UpdateCommercialNetworkCommand>
    {
        public UpdateCommercialNetworkCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the commercial network id!");
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Please provide the commercial network name!");
        }
    }

    public sealed class UpdateCommercialNetworkCommandHandler : BaseModuleHandler<UpdateCommercialNetworkCommand, CommercialNetworkResult>
    {
        public UpdateCommercialNetworkCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<CommercialNetworkResult> Handle(UpdateCommercialNetworkCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _CommercialNetworkService.UpdateCommercialNetworkAsync(updateCommercialNetworkModel);
        }
    }
}
