using AutoMapper;
using DiscountСardApp.Application.Models.V1.MCCCode.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.MCCCodeModule.Commands
{
    public sealed class CreateMCCCodeCommand : IRequest<MCCCodeResult>
    {
        public int Code { get; set; }
        public string Description { get; set; } = String.Empty;
    }

    public sealed class CreateMCCCodeCommandValidator : AbstractValidator<CreateMCCCodeCommand>
    {
        public CreateMCCCodeCommandValidator()
        {
            RuleFor(x => x.Code).NotNull().NotEmpty().WithMessage("Please provide the code number!");
            RuleFor(x => x.Code.ToString()).Length(4,4).WithMessage("Code number is not valid!");
        }
    }

    public sealed class CreateMCCCodeCommandHandler : IRequestHandler<CreateMCCCodeCommand, MCCCodeResult>
    {
        private readonly IMapper _mapper;

        public CreateMCCCodeCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<MCCCodeResult> Handle(CreateMCCCodeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _MCCCodeService.CreateMCCCodeAsync(createMCCCodeModel);
        }
    }
}
