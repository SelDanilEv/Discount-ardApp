using AutoMapper;
using Discount—ardApp.Application.Models.V1.DiscountCard.Results;
using FluentValidation;
using MediatR;

namespace Discount—ardApp.Application.Modules.DiscountCard.Commands
{
    public sealed class CreateDiscountCardCommand : IRequest<DiscountCardResult>
    {
        public string? Name { get; set; }
        public string? Conditions { get; set; }
    }

    public sealed class CreateDiscountCardCommandValidator : AbstractValidator<CreateDiscountCardCommand>
    {
        public CreateDiscountCardCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Please provide the card name!");

            RuleFor(x => x.Conditions).NotNull().NotEmpty()
                .WithMessage("Please provide the card conditions!");
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
