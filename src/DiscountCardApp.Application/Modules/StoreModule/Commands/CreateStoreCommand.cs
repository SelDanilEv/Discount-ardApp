using AutoMapper;
using DiscountCardApp.Application.Models.V1.Store.Results;
using DiscountCardApp.Domain.Entities;
using DiscountCardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountCardApp.Application.Modules.StoreModule.Commands
{
    public sealed class CreateStoreCommand : IRequest<StoreResult>
    {
        public Guid CommercialNetworkId { get; set; }

        public string MCCCode { get; set; } = String.Empty;

        public string Address { get; set; } = String.Empty;
    }

    public sealed class CreateStoreCommandValidator : AbstractValidator<CreateStoreCommand>
    {
        public CreateStoreCommandValidator()
        {
            RuleFor(x => x.MCCCode).NotNull().NotEmpty().WithMessage("Please provide the code!");
            RuleFor(x => x.CommercialNetworkId).NotNull().NotEmpty().WithMessage("Please provide the commercial network!");
        }
    }

    public sealed class CreateStoreCommandHandler : BaseModuleHandler<CreateStoreCommand, StoreResult>
    {
        public CreateStoreCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<StoreResult> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var newStore = _mapper.Map<Store>(request);

            newStore.MCCCode = _dbContext.MCCCodes.Single(c => c.Code == request.MCCCode);

            await _dbContext.Stores.AddAsync(newStore);
            await _dbContext.SaveChangesAsync();

            var storeResult = _mapper.Map<StoreResult>(newStore);

            return storeResult;
        }
    }
}
