using AutoMapper;
using DiscountСardApp.Application.Models.V1.Store.Results;
using DiscountСardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.StoreModule.Commands
{
    public sealed class UpdateStoreCommand : IRequest<StoreResult>
    {
        public Guid Id { get; set; }

        public Guid MCCCodeId { get; set; }

        public Guid CommercialNetworkId { get; set; }

        public string Address { get; set; } = String.Empty;
    }

    public sealed class UpdateStoreCommandValidator : AbstractValidator<UpdateStoreCommand>
    {
        public UpdateStoreCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the store id!");

            RuleFor(x => x.MCCCodeId).NotNull().NotEmpty().WithMessage("Please provide the code!");
            RuleFor(x => x.CommercialNetworkId).NotNull().NotEmpty().WithMessage("Please provide the commercial network!");
        }
    }

    public sealed class UpdateStoreCommandHandler : BaseModuleHandler<UpdateStoreCommand, StoreResult>
    {
        public UpdateStoreCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<StoreResult> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _StoreService.UpdateStoreAsync(updateStoreModel);
        }
    }
}
