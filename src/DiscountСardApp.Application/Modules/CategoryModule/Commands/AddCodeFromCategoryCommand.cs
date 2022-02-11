using AutoMapper;
using DiscountСardApp.Application.Models.V1.DiscountCard.Results;
using DiscountСardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.CategoryModule.Commands
{
    public sealed class AddCodeToCategoryCommand : IRequest<DiscountCardResult>
    {
        public Guid MCCCodeId { get; set; }
        public Guid CategoryId { get; set; }
    }

    public sealed class AddCodeToCategoryValidator : AbstractValidator<AddCodeToCategoryCommand>
    {
        public AddCodeToCategoryValidator()
        {
            RuleFor(x => x.MCCCodeId).NotNull().NotEmpty()
                .WithMessage("Please provide the code id!");

            RuleFor(x => x.CategoryId).NotNull().NotEmpty()
                .WithMessage("Please provide the category id!");
        }
    }

    public sealed class AddCodeToCategoryHandler : BaseModuleHandler<AddCodeToCategoryCommand, DiscountCardResult>
    {
        public AddCodeToCategoryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<DiscountCardResult> Handle(AddCodeToCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _DiscountCardService.AddCategoryAsync(AddCategoryModel);
        }
    }
}
