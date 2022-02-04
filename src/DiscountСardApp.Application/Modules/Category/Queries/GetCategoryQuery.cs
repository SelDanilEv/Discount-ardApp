using AutoMapper;
using DiscountСardApp.Application.Models.V1.Category.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.Category.Queries
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

    public sealed class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryResult>
    {
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<CategoryResult> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _CategoryService.GetAll(getCategoryModel);
        }
    }
}
