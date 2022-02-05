using AutoMapper;
using DiscountСardApp.Application.Models.V1.MCCCode.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.MCCCodeModule.Commands
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

    public sealed class DeleteMCCCodeCommandHandler : IRequestHandler<DeleteMCCCodeCommand, MCCCodeResult>
    {
        private readonly IMapper _mapper;

        public DeleteMCCCodeCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<MCCCodeResult> Handle(DeleteMCCCodeCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _MCCCodeService.DeleteMCCCodeAsync(deleteMCCCodeModel);
        }
    }
}
