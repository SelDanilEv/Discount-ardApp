using AutoMapper;
using DiscountСardApp.Application.Models.V1.DiscountCard.Results;
using DiscountСardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.DiscountCardModule.Queries
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

    public sealed class GetAllDiscountCardsQueryHandler : BaseModuleHandler<GetAllDiscountCardsQuery, List<DiscountCardResult>>
    {
        public GetAllDiscountCardsQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<List<DiscountCardResult>> Handle(GetAllDiscountCardsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _DiscountCardService.GetAll();
        }
    }
}
