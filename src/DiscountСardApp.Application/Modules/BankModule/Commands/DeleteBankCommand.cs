using AutoMapper;
using DiscountСardApp.Application.Models.V1.Bank.Results;
using DiscountСardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.BankModule.Commands
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

    public sealed class DeleteBankCommandHandler : BaseModuleHandler<DeleteBankCommand, BankResult>
    {
        public DeleteBankCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<BankResult> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _bankService.DeleteBankAsync(deleteBankModel);
        }
    }
}
