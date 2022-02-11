using AutoMapper;
using DiscountСardApp.Application.Models.V1.Bank.Results;
using DiscountСardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiscountСardApp.Application.Modules.BankModule.Queries
{
    public sealed class GetAllBanksQuery : IRequest<List<BankResult>>
    {
    }

    public sealed class GetAllBanksQueryValidator : AbstractValidator<GetAllBanksQuery>
    {
        public GetAllBanksQueryValidator()
        {
        }
    }

    public sealed class GetAllBanksQueryHandler : BaseModuleHandler<GetAllBanksQuery, List<BankResult>>
    {
        public GetAllBanksQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<List<BankResult>> Handle(GetAllBanksQuery request, CancellationToken cancellationToken)
        {
            var bankList = await _dbContext.Banks
                .Include(b => b.DiscountCards)
                .ThenInclude(x => x.Categories)
                .ThenInclude(x => x.MCCCodes).ToListAsync();

            var banksResult = _mapper.Map<List<BankResult>>(bankList);

            return banksResult;
        }
    }
}
