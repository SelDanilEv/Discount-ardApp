using AutoMapper;
using DiscountСardApp.Application.Models.V1.DiscountCard.Results;
using DiscountСardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.DiscountCardModule.Queries
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

    public sealed class GetDiscountCardQueryHandler : BaseModuleHandler<GetDiscountCardQuery, DiscountCardResult>
    {
        public GetDiscountCardQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<DiscountCardResult> Handle(GetDiscountCardQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _DiscountCardService.GetAll(getDiscountCardModel);
        }
    }
}
