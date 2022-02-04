using AutoMapper;
using DiscountСardApp.Application.Models.V1.DiscountCard.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.DiscountCard.Commands
{
    public sealed class UpdateDiscountCardCommand : IRequest<DiscountCardResult>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Conditions { get; set; }
    }

    public sealed class UpdateDiscountCardCommandValidator : AbstractValidator<UpdateDiscountCardCommand>
    {
        public UpdateDiscountCardCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the DiscountCard id!");

            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Please provide the card name!");

            RuleFor(x => x.Conditions).NotNull().NotEmpty()
                .WithMessage("Please provide the card conditions!");
        }
    }

    public sealed class UpdateDiscountCardCommandHandler : IRequestHandler<UpdateDiscountCardCommand, DiscountCardResult>
    {
        private readonly IMapper _mapper;

        public UpdateDiscountCardCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<DiscountCardResult> Handle(UpdateDiscountCardCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _DiscountCardService.UpdateDiscountCardAsync(updateDiscountCardModel);
        }
    }
}
