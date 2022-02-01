using AutoMapper;
using Discount—ardApp.Application.Models.V1.DiscountCard.Results;
using FluentValidation;
using MediatR;

namespace Discount—ardApp.Application.Modules.DiscountCard.Commands
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

    public sealed class DeleteDiscountCardCommandHandler : IRequestHandler<DeleteDiscountCardCommand, DiscountCardResult>
    {
        private readonly IMapper _mapper;

        public DeleteDiscountCardCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<DiscountCardResult> Handle(DeleteDiscountCardCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _DiscountCardService.DeleteDiscountCardAsync(deleteDiscountCardModel);
        }
    }
}
