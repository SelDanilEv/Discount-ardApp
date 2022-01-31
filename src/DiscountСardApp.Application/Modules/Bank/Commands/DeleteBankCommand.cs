using AutoMapper;
using Discount—ardApp.Application.Models.V1.Bank.Results;
using FluentValidation;
using MediatR;

namespace Discount—ardApp.Application.Modules.Bank.Commands
{
    public sealed class DeleteBankCommand : IRequest<BankResult>
    {
        public Guid Id { get; set; }
    }

    public sealed class DeleteBankCommandValidator : AbstractValidator<DeleteBankCommand>
    {
        public DeleteBankCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the bank id!");
        }
    }

    public sealed class DeleteBankCommandHandler : IRequestHandler<DeleteBankCommand, BankResult>
    {
        private readonly IMapper _mapper;

        public DeleteBankCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<BankResult> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _bankService.DeleteBankAsync(deleteBankModel);
        }
    }
}
