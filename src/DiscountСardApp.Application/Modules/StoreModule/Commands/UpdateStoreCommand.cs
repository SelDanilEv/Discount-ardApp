using AutoMapper;
using DiscountСardApp.Application.Models.V1.Store.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.StoreModule.Commands
{
    public sealed class UpdateStoreCommand : IRequest<StoreResult>
    {
        public Guid Id { get; set; }

        public Guid MCCCodeId { get; set; }

        public Guid CommertialNetworkId { get; set; }

        public string Address { get; set; } = String.Empty;
    }

    public sealed class UpdateStoreCommandValidator : AbstractValidator<UpdateStoreCommand>
    {
        public UpdateStoreCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the Store id!");

            RuleFor(x => x.MCCCodeId).NotNull().NotEmpty().WithMessage("Please provide the code!");
            RuleFor(x => x.CommertialNetworkId).NotNull().NotEmpty().WithMessage("Please provide the commertial network!");
        }
    }

    public sealed class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, StoreResult>
    {
        private readonly IMapper _mapper;

        public UpdateStoreCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<StoreResult> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _StoreService.UpdateStoreAsync(updateStoreModel);
        }
    }
}
