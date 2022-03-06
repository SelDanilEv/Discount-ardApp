using AutoMapper;
using DiscountCardApp.Application.Models.V1.Category.Results;
using DiscountCardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountCardApp.Application.Modules.CategoryModule.Queries
{
    public sealed class GetAllCategorysQuery : IRequest<List<CategoryResult>>
    {
    }

    public sealed class GetAllCategorysQueryValidator : AbstractValidator<GetAllCategorysQuery>
    {
        public GetAllCategorysQueryValidator()
        {
        }
    }

    public sealed class GetAllCategorysQueryHandler : BaseModuleHandler<GetAllCategorysQuery, List<CategoryResult>>
    {
        public GetAllCategorysQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<List<CategoryResult>> Handle(GetAllCategorysQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _CategoryService.GetAll();
        }
    }
}
