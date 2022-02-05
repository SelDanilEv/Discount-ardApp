using AutoMapper;
using DiscountСardApp.Application.Models.V1.Category.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.CategoryModule.Commands
{
    public sealed class DeleteCategoryCommand : IRequest<CategoryResult>
    {
        public Guid Id { get; set; }
    }

    public sealed class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the category id!");
        }
    }

    public sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CategoryResult>
    {
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<CategoryResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _CategoryService.DeleteCategoryAsync(deleteCategoryModel);
        }
    }
}
