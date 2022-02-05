using AutoMapper;
using DiscountСardApp.Application.Models.V1.Store.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.StoreModule.Commands
{
    public sealed class CreateStoreCommand : IRequest<StoreResult>
    {
        public Guid MCCCodeId { get; set; }

        public Guid CommertialNetworkId { get; set; }

        public string Address { get; set; } = String.Empty;
    }

    public sealed class CreateStoreCommandValidator : AbstractValidator<CreateStoreCommand>
    {
        public CreateStoreCommandValidator()
        {
            RuleFor(x => x.MCCCodeId).NotNull().NotEmpty().WithMessage("Please provide the code!");
            RuleFor(x => x.CommertialNetworkId).NotNull().NotEmpty().WithMessage("Please provide the commertial network!");
        }
    }

    public sealed class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, StoreResult>
    {
        private readonly IMapper _mapper;

        public CreateStoreCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<StoreResult> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _StoreService.CreateStoreAsync(createStoreModel);
        }
    }
}
