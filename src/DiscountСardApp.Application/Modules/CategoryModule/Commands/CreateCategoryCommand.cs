using AutoMapper;
using DiscountСardApp.Application.Models.V1.Category.Results;
using DiscountСardApp.Domain.Entities;
using DiscountСardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.CategoryModule.Commands
{
    public sealed class CreateCategoryCommand : IRequest<CategoryResult>
    {
        public string? Name { get; set; }

        public Guid DiscountCardId { get; set; }
    }

    public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty()
                .WithMessage("Please provide the category name!");

            RuleFor(x => x.DiscountCardId).NotNull().NotEmpty()
                .WithMessage("Please provide the card id!");
        }
    }

    public sealed class CreateCategoryCommandHandler : BaseModuleHandler<CreateCategoryCommand, CategoryResult>
    {
        public CreateCategoryCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<CategoryResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var newCategory = _mapper.Map<Category>(request);

            await _dbContext.Categories.AddAsync(newCategory);
            await _dbContext.SaveChangesAsync();

            var categoryResult = _mapper.Map<CategoryResult>(newCategory);

            return categoryResult;
        }
    }
}
