using AutoMapper;
using DiscountCardApp.Application.Models.V1.Bank.Results;
using DiscountCardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountCardApp.Application.Modules.BankModule.Commands
{
    public sealed class UpdateBankCommand : IRequest<BankResult>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }

    public sealed class UpdateBankCommandValidator : AbstractValidator<UpdateBankCommand>
    {
        public UpdateBankCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the bank id!");
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Please provide the bank name!");
        }
    }

    public sealed class UpdateBankCommandHandler : BaseModuleHandler<UpdateBankCommand, BankResult>
    {
        public UpdateBankCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<BankResult> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _bankService.UpdateBankAsync(updateBankModel);
        }
    }
}
