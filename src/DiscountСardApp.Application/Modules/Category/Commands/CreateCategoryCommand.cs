using AutoMapper;
using DiscountСardApp.Application.Models.V1.Category.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.Category.Commands
{
    public sealed class CreateCategoryCommand : IRequest<CategoryResult>
    {
        public string CategoryName { get; set; } = String.Empty;

        public Guid DiscountCardId { get; set; }
    }

    public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.CategoryName).NotNull().NotEmpty()
                .WithMessage("Please provide the category name!");

            RuleFor(x => x.DiscountCardId).NotNull().NotEmpty()
                .WithMessage("Please provide the card id!");
        }
    }

    public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResult>
    {
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<CategoryResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _CategoryService.CreateCategoryAsync(createCategoryModel);
        }
    }
}
