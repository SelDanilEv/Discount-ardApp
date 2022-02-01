using AutoMapper;
using Discount—ardApp.Application.Models.V1.DiscountCard.Results;
using FluentValidation;
using MediatR;

namespace Discount—ardApp.Application.Modules.DiscountCard.Queries
{
    public sealed class GetAllDiscountCardsQuery : IRequest<List<DiscountCardResult>>
    {
    }

    public sealed class GetAllDiscountCardsQueryValidator : AbstractValidator<GetAllDiscountCardsQuery>
    {
        public GetAllDiscountCardsQueryValidator()
        {
        }
    }

    public sealed class GetAllDiscountCardsQueryHandler : IRequestHandler<GetAllDiscountCardsQuery, List<DiscountCardResult>>
    {
        private readonly IMapper _mapper;

        public GetAllDiscountCardsQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<DiscountCardResult>> Handle(GetAllDiscountCardsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _DiscountCardService.GetAll();
        }
    }
}
