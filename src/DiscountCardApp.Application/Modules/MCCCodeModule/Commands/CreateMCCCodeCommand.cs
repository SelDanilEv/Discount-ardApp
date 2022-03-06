using AutoMapper;
using DiscountCardApp.Application.Models.V1.MCCCode.Results;
using DiscountCardApp.Domain.Entities;
using DiscountCardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountCardApp.Application.Modules.MCCCodeModule.Commands
{
    public sealed class CreateMCCCodeCommand : IRequest<MCCCodeResult>
    {
        public string Code { get; set; }
        public string Description { get; set; } = String.Empty;
    }

    public sealed class CreateMCCCodeCommandValidator : AbstractValidator<CreateMCCCodeCommand>
    {
        public CreateMCCCodeCommandValidator()
        {
            RuleFor(x => x.Code).NotNull().NotEmpty().WithMessage("Please provide the code number!");
            RuleFor(x => x.Code.ToString()).Length(4, 4).WithMessage("Code number is not valid!");
        }
    }

    public sealed class CreateMCCCodeCommandHandler : BaseModuleHandler<CreateMCCCodeCommand, MCCCodeResult>
    {
        public CreateMCCCodeCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<MCCCodeResult> Handle(CreateMCCCodeCommand request, CancellationToken cancellationToken)
        {
            var newMCCCode = _mapper.Map<MCCCode>(request);

            await _dbContext.MCCCodes.AddAsync(newMCCCode);
            await _dbContext.SaveChangesAsync();

            var mCCCodeResult = _mapper.Map<MCCCodeResult>(newMCCCode);

            return mCCCodeResult;
        }
    }
}
