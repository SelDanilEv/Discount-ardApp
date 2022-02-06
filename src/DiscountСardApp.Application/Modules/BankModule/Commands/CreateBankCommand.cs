using AutoMapper;
using DiscountСardApp.Application.Models.V1.Bank.Results;
using DiscountСardApp.Domain.Entities;
using DiscountСardApp.Infrastructure.Contexts;
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
        private readonly ApplicationDbContext _dbContext;

        public CreateBankCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<BankResult> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            var newBank = _mapper.Map<Bank>(request);

            await _dbContext.Banks.AddAsync(newBank);
            await _dbContext.SaveChangesAsync();

            var bankResult = _mapper.Map<BankResult>(newBank);

            return bankResult;
        }
    }
}
