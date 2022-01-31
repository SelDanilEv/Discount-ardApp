using AutoMapper;
using Discount—ardApp.Application.Models.V1.Bank.Results;
using FluentValidation;
using MediatR;

namespace Discount—ardApp.Application.Modules.Bank.Commands
{
    public sealed class UpdateBankCommand : IRequest<BankResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public sealed class UpdateBankCommandValidator : AbstractValidator<UpdateBankCommand>
    {
        public UpdateBankCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the bank id!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please provide the bank name!");
        }
    }

    public sealed class UpdateBankCommandHandler : IRequestHandler<UpdateBankCommand, BankResult>
    {
        private readonly IMapper _mapper;

        public UpdateBankCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<BankResult> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _bankService.UpdateBankAsync(updateBankModel);
        }
    }
}
