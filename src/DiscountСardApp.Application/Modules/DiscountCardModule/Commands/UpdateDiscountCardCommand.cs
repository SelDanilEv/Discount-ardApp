using AutoMapper;
using DiscountСardApp.Application.Models.V1.DiscountCard.Results;
using DiscountСardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.DiscountCardModule.Commands
{
    public sealed class UpdateDiscountCardCommand : IRequest<DiscountCardResult>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Conditions { get; set; }
        public Guid BankId { get; set; }
    }

    public sealed class UpdateDiscountCardCommandValidator : AbstractValidator<UpdateDiscountCardCommand>
    {
        public UpdateDiscountCardCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the discount card id!");

            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Please provide the card name!");

            RuleFor(x => x.BankId).NotNull().NotEmpty()
                .WithMessage("Please provide the bank id!");
        }
    }

    public sealed class UpdateDiscountCardCommandHandler : BaseModuleHandler<UpdateDiscountCardCommand, DiscountCardResult>
    {
        public UpdateDiscountCardCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<DiscountCardResult> Handle(UpdateDiscountCardCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _DiscountCardService.UpdateDiscountCardAsync(updateDiscountCardModel);
        }
    }
}
