using AutoMapper;
using DiscountСardApp.Application.Models.V1.Bank.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.BankModule.Commands
{
    public sealed class CreateBankCommand : IRequest<BankResult>
    {
        public string? Name { get; set; }
    }

    public sealed class CreateBankCommandValidator : AbstractValidator<CreateBankCommand>
    {
        public CreateBankCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Please provide the bank name!");
        }
    }

    public sealed class CreateBankCommandHandler : IRequestHandler<CreateBankCommand, BankResult>
    {
        private readonly IMapper _mapper;

        public CreateBankCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<BankResult> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _bankService.CreateBankAsync(createBankModel);
        }
    }
}
