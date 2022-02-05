using AutoMapper;
using DiscountСardApp.Application.Models.V1.MCCCode.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.MCCCodeModule.Commands
{
    public sealed class UpdateMCCCodeCommand : IRequest<MCCCodeResult>
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; } = String.Empty;
    }

    public sealed class UpdateMCCCodeCommandValidator : AbstractValidator<UpdateMCCCodeCommand>
    {
        public UpdateMCCCodeCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the MCCCode id!"); 
            RuleFor(x => x.Code).NotNull().NotEmpty().WithMessage("Please provide the code number!");
            RuleFor(x => x.Code.ToString()).Length(4, 4).WithMessage("Code number is not valid!");
        }
    }

    public sealed class UpdateMCCCodeCommandHandler : IRequestHandler<UpdateMCCCodeCommand, MCCCodeResult>
    {
        private readonly IMapper _mapper;

        public UpdateMCCCodeCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<MCCCodeResult> Handle(UpdateMCCCodeCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _MCCCodeService.UpdateMCCCodeAsync(updateMCCCodeModel);
        }
    }
}
