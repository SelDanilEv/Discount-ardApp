using AutoMapper;
using Discount—ardApp.Application.Models.V1.Category.Results;
using Discount—ardApp.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Discount—ardApp.Application.Modules.Category.Commands
{
    public sealed class UpdateCategoryCommand : IRequest<CategoryResult>
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; } = String.Empty;

        public Guid DiscountCardId { get; set; }

        public List<MCCCode> MCCCodes { get; set; } = new List<MCCCode>();
    }

    public sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the category id!");

            RuleFor(x => x.CategoryName).NotNull().NotEmpty()
                .WithMessage("Please provide the category name!");

            RuleFor(x => x.DiscountCardId).NotNull().NotEmpty()
                .WithMessage("Please provide the card id!");
        }
    }

    public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryResult>
    {
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<CategoryResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _CategoryService.UpdateCategoryAsync(updateCategoryModel);
        }
    }
}
