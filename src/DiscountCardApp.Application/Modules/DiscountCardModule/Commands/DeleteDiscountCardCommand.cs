using AutoMapper;
using DiscountCardApp.Application.Models.V1.DiscountCard.Results;
using DiscountCardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountCardApp.Application.Modules.DiscountCardModule.Commands
{
    public sealed class DeleteDiscountCardCommand : IRequest<DiscountCardResult>
    {
        public Guid Id { get; set; }
    }

    public sealed class DeleteDiscountCardCommandValidator : AbstractValidator<DeleteDiscountCardCommand>
    {
        public DeleteDiscountCardCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the card id!");
        }
    }

    public sealed class DeleteDiscountCardCommandHandler : BaseModuleHandler<DeleteDiscountCardCommand, DiscountCardResult>
    {
        public DeleteDiscountCardCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<DiscountCardResult> Handle(DeleteDiscountCardCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _DiscountCardService.DeleteDiscountCardAsync(deleteDiscountCardModel);
        }
    }
}
