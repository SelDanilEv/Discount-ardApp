using AutoMapper;
using DiscountCardApp.Application.Models.V1.DiscountCard.Results;
using DiscountCardApp.Domain.Entities;
using DiscountCardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountCardApp.Application.Modules.DiscountCardModule.Commands
{
    public sealed class CreateDiscountCardCommand : IRequest<DiscountCardResult>
    {
        public string Name { get; set; } = String.Empty;
        public string Conditions { get; set; } = String.Empty;
        public Guid BankId { get; set; }
    }

    public sealed class CreateDiscountCardCommandValidator : AbstractValidator<CreateDiscountCardCommand>
    {
        public CreateDiscountCardCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Please provide the card name!");

            RuleFor(x => x.BankId).NotNull().NotEmpty().WithMessage("Please provide the bank id!");
        }
    }

    public sealed class CreateDiscountCardCommandHandler : BaseModuleHandler<CreateDiscountCardCommand, DiscountCardResult>
    {
        public CreateDiscountCardCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<DiscountCardResult> Handle(CreateDiscountCardCommand request, CancellationToken cancellationToken)
        {
            var newDiscountCard = _mapper.Map<DiscountCard>(request);

            await _dbContext.DiscountCards.AddAsync(newDiscountCard);
            await _dbContext.SaveChangesAsync();

            var bankResult = _mapper.Map<DiscountCardResult>(newDiscountCard);

            return bankResult;
        }
    }
}
