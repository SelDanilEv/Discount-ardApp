using AutoMapper;
using DiscountСardApp.Application.Models.V1.Category.Results;
using DiscountСardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.CategoryModule.Queries
{
    public sealed class GetCategoryQuery : IRequest<CategoryResult>
    {
        public Guid Id { get; set; }
    }

    public sealed class GetCategoryQueryValidator : AbstractValidator<GetCategoryQuery>
    {
        public GetCategoryQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the category id!");
        }
    }

    public sealed class GetCategoryQueryHandler : BaseModuleHandler<GetCategoryQuery, CategoryResult>
    {
        public GetCategoryQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<CategoryResult> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _CategoryService.GetAll(getCategoryModel);
        }
    }
}
