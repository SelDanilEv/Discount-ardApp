using AutoMapper;
using DiscountCardApp.Application.Models.V1.Bank.Results;
using DiscountCardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountCardApp.Application.Modules.BankModule.Queries
{
    public sealed class GetBankQuery : IRequest<BankResult>
    {
        public Guid Id { get; set; }
    }

    public sealed class GetBankQueryValidator : AbstractValidator<GetBankQuery>
    {
        public GetBankQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the bank id!");
        }
    }

    public sealed class GetBankQueryHandler : BaseModuleHandler<GetBankQuery, BankResult>
    {
        public GetBankQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext,mapper){}

        public override async Task<BankResult> Handle(GetBankQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _bankService.GetAll(getBankModel);
        }
    }
}
