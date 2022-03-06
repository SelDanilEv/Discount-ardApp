using AutoMapper;
using DiscountCardApp.Application.Models.V1.MCCCode.Results;
using DiscountCardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountCardApp.Application.Modules.MCCCodeModule.Commands
{
    public sealed class DeleteMCCCodeCommand : IRequest<MCCCodeResult>
    {
        public Guid Id { get; set; }
    }

    public sealed class DeleteMCCCodeCommandValidator : AbstractValidator<DeleteMCCCodeCommand>
    {
        public DeleteMCCCodeCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the сode id!");
        }
    }

    public sealed class DeleteMCCCodeCommandHandler : BaseModuleHandler<DeleteMCCCodeCommand, MCCCodeResult>
    {
        public DeleteMCCCodeCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<MCCCodeResult> Handle(DeleteMCCCodeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _MCCCodeService.DeleteMCCCodeAsync(deleteMCCCodeModel);
        }
    }
}
