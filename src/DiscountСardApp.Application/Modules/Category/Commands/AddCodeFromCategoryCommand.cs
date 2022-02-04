using AutoMapper;
using DiscountСardApp.Application.Models.V1.DiscountCard.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.DiscountCard.Commands
{
    public sealed class AddCodeFromCategoryCommand : IRequest<DiscountCardResult>
    {
        public Guid MCCCodeId { get; set; }
        public Guid CategoryId { get; set; }
    }

    public sealed class AddCodeFromCategoryValidator : AbstractValidator<AddCodeFromCategoryCommand>
    {
        public AddCodeFromCategoryValidator()
        {
            RuleFor(x => x.MCCCodeId).NotNull().NotEmpty()
                .WithMessage("Please provide the code id!");

            RuleFor(x => x.CategoryId).NotNull().NotEmpty()
                .WithMessage("Please provide the category id!");
        }
    }

    public sealed class AddCodeFromCategoryHandler : IRequestHandler<AddCodeFromCategoryCommand, DiscountCardResult>
    {
        private readonly IMapper _mapper;

        public AddCodeFromCategoryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<DiscountCardResult> Handle(AddCodeFromCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _DiscountCardService.AddCategoryAsync(AddCategoryModel);
        }
    }
}
