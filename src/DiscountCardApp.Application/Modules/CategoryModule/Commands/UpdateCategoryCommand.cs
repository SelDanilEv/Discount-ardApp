using AutoMapper;
using DiscountCardApp.Application.Models.V1.Category.Results;
using DiscountCardApp.Domain.Entities;
using DiscountCardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountCardApp.Application.Modules.CategoryModule.Commands
{
    public sealed class UpdateCategoryCommand : IRequest<CategoryResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public Guid DiscountCardId { get; set; }

        public List<MCCCode> MCCCodes { get; set; } = new List<MCCCode>();
    }

    public sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the category id!");

            RuleFor(x => x.Name).NotNull().NotEmpty()
                .WithMessage("Please provide the category name!");

            RuleFor(x => x.DiscountCardId).NotNull().NotEmpty()
                .WithMessage("Please provide the card id!");
        }
    }

    public sealed class UpdateCategoryCommandHandler : BaseModuleHandler<UpdateCategoryCommand, CategoryResult>
    {
        public UpdateCategoryCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<CategoryResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _CategoryService.UpdateCategoryAsync(updateCategoryModel);
        }
    }
}
