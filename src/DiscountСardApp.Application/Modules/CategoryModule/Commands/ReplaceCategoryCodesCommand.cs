using AutoMapper;
using DiscountСardApp.Application.Models.V1.Category.Results;
using DiscountСardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DiscountСardApp.Application.Modules.CategoryModule.Commands
{
    public sealed class ReplaceCategoryCodesCommand : IRequest<ReplaceCodesResult>
    {
        public string Codes { get; set; } = String.Empty;
        public Guid CategoryId { get; set; }
    }

    public sealed class ReplaceCategoryCodesValidator : AbstractValidator<ReplaceCategoryCodesCommand>
    {
        public ReplaceCategoryCodesValidator()
        {
            RuleFor(x => x.Codes).NotNull().NotEmpty()
                .WithMessage("Please provide codes!");

            RuleFor(x => x.CategoryId).NotNull().NotEmpty()
                .WithMessage("Please provide the category id!");
        }
    }

    public sealed class ReplaceCategoryCodesHandler : BaseModuleHandler<ReplaceCategoryCodesCommand, ReplaceCodesResult>
    {
        public ReplaceCategoryCodesHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<ReplaceCodesResult> Handle(ReplaceCategoryCodesCommand request, CancellationToken cancellationToken)
        {
            var codes = request.Codes.Split(",").Select(x => x.Trim()).ToArray();

            var category = _dbContext.Categories.Include(c => c.MCCCodes).Single(x => x.Id == request.CategoryId);

            if (category == null)
            {
                throw new ArgumentOutOfRangeException("Category with that ID is not exist");
            }

            category.MCCCodes?.Clear();

            category.MCCCodes = await _dbContext.MCCCodes.Where(x => codes.Contains(x.Code)).ToListAsync();

            await _dbContext.SaveChangesAsync();

            var result = new ReplaceCodesResult { CategoryId = request.CategoryId};

            result.Codes = String.Join(", ",category.MCCCodes.Select(x => x.Code).ToArray());

            return result;
        }
    }
}
