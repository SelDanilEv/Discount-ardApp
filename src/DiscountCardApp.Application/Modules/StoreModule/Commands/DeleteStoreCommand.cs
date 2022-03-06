using AutoMapper;
using DiscountCardApp.Application.Models.V1.Store.Results;
using DiscountCardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountCardApp.Application.Modules.StoreModule.Commands
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

    public sealed class DeleteStoreCommandHandler : BaseModuleHandler<DeleteStoreCommand, StoreResult>
    {
        public DeleteStoreCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<StoreResult> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _StoreService.DeleteStoreAsync(deleteStoreModel);
        }
    }
}
