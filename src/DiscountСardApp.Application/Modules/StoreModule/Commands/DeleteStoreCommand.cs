using AutoMapper;
using DiscountСardApp.Application.Models.V1.Store.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.StoreModule.Commands
{
    public sealed class DeleteStoreCommand : IRequest<StoreResult>
    {
        public Guid Id { get; set; }
    }

    public sealed class DeleteStoreCommandValidator : AbstractValidator<DeleteStoreCommand>
    {
        public DeleteStoreCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the Store id!");
        }
    }

    public sealed class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand, StoreResult>
    {
        private readonly IMapper _mapper;

        public DeleteStoreCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<StoreResult> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _StoreService.DeleteStoreAsync(deleteStoreModel);
        }
    }
}
