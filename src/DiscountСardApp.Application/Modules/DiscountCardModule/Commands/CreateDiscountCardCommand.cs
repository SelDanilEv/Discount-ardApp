using AutoMapper;
using DiscountСardApp.Application.Models.V1.DiscountCard.Results;
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

        public CreateDiscountCardCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<DiscountCardResult> Handle(CreateDiscountCardCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _DiscountCardService.CreateDiscountCardAsync(createDiscountCardModel);
        }
    }
}
