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

    public sealed class GetAllBanksQueryHandler : IRequestHandler<GetAllBanksQuery, List<BankResult>>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public GetAllBanksQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<List<BankResult>> Handle(GetAllBanksQuery request, CancellationToken cancellationToken)
        {
            var bankList = await _dbContext.Banks.Include(b => b.DiscountCards).AsNoTracking().ToListAsync();

            var banksResult = _mapper.Map<List<BankResult>>(bankList);

            return banksResult;
        }
    }
}
