using AutoMapper;
using DiscountСardApp.Application.Models.V1.DiscountCard.Results;
using DiscountСardApp.Domain.Entities;
using DiscountСardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.DiscountCardModule.Commands
{
    public sealed class CreateDiscountCardCommand : IRequest<DiscountCardResult>
    {
        public string? Name { get; set; }
        public string? Conditions { get; set; }
        public Guid BankId { get; set; }
    }

    public sealed class CreateDiscountCardCommandValidator : AbstractValidator<CreateDiscountCardCommand>
    {
        public CreateDiscountCardCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Please provide the card name!");

            RuleFor(x => x.BankId).NotNull().NotEmpty()
                .WithMessage("Please provide the bank id!");
        }
    }

    public sealed class CreateDiscountCardCommandHandler : IRequestHandler<CreateDiscountCardCommand, DiscountCardResult>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public CreateDiscountCardCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<DiscountCardResult> Handle(CreateDiscountCardCommand request, CancellationToken cancellationToken)
        {
            var newDiscountCard = _mapper.Map<DiscountCard>(request);

            await _dbContext.DiscountCards.AddAsync(newDiscountCard);
            await _dbContext.SaveChangesAsync();

            var bankResult = _mapper.Map<DiscountCardResult>(newDiscountCard);

            return bankResult;
        }
    }
}
