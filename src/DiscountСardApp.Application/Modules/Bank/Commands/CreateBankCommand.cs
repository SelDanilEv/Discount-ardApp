using AutoMapper;
using Discount—ardApp.Application.Models.V1.Bank.Requests;
using Discount—ardApp.Application.Models.V1.Bank.Results;
using FluentValidation;
using MediatR;

namespace Discount—ardApp.Application.Modules.Bank.Commands
{
    public sealed class CreateBankCommand : IRequest<BankResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public sealed class CreateBankCommandValidator : AbstractValidator<CreateBankCommand>
    {
        public CreateBankCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please provide the bank name!");
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
            var createBankModel = _mapper.Map<CreateBank>(request);

            throw new NotImplementedException();
            //return await _bankService.CreateBankAsync(createBankModel);
        }
    }
}
