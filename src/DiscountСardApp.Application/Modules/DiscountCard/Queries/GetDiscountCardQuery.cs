using AutoMapper;
using DiscountСardApp.Application.Models.V1.DiscountCard.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.DiscountCard.Queries
{
    public sealed class GetDiscountCardQuery : IRequest<DiscountCardResult>
    {
        public Guid Id { get; set; }
    }

    public sealed class GetDiscountCardQueryValidator : AbstractValidator<GetDiscountCardQuery>
    {
        public GetDiscountCardQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the card id!");
        }
    }

    public sealed class GetDiscountCardQueryHandler : IRequestHandler<GetDiscountCardQuery, DiscountCardResult>
    {
        private readonly IMapper _mapper;

        public GetDiscountCardQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<DiscountCardResult> Handle(GetDiscountCardQuery request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _DiscountCardService.GetAll(getDiscountCardModel);
        }
    }
}
