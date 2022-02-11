using AutoMapper;
using DiscountСardApp.Application.Models.V1.DiscountCard.Results;
using DiscountСardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.CategoryModule.Commands
{
    public sealed class RemoveCodeFromCategoryCommand : IRequest<DiscountCardResult>
    {
        public Guid MCCCodeId { get; set; }
        public Guid CategoryId { get; set; }
    }

    public sealed class AddCategoryCommandValidator : AbstractValidator<RemoveCodeFromCategoryCommand>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(x => x.MCCCodeId).NotNull().NotEmpty()
                .WithMessage("Please provide the code id!");

            RuleFor(x => x.CategoryId).NotNull().NotEmpty()
                .WithMessage("Please provide the category id!");
        }
    }

    public sealed class AddCategoryCommandHandler : BaseModuleHandler<RemoveCodeFromCategoryCommand, DiscountCardResult>
    {
        public AddCategoryCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<DiscountCardResult> Handle(RemoveCodeFromCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _DiscountCardService.AddCategoryAsync(AddCategoryModel);
        }
    }
}
