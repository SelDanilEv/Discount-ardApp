using AutoMapper;
using DiscountCardApp.Application.Models.V1.CommercialNetwork.Results;
using DiscountCardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountCardApp.Application.Modules.CommercialNetworkModule.Commands
{
    public sealed class DeleteCommercialNetworkCommand : IRequest<CommercialNetworkResult>
    {
        public Guid Id { get; set; }
    }

    public sealed class DeleteCommercialNetworkCommandValidator : AbstractValidator<DeleteCommercialNetworkCommand>
    {
        public DeleteCommercialNetworkCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the commercial network id!");
        }
    }

    public sealed class DeleteCommercialNetworkCommandHandler : BaseModuleHandler<DeleteCommercialNetworkCommand, CommercialNetworkResult>
    {
        public DeleteCommercialNetworkCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<CommercialNetworkResult> Handle(DeleteCommercialNetworkCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _CommercialNetworkService.DeleteCommercialNetworkAsync(deleteCommercialNetworkModel);
        }
    }
}
