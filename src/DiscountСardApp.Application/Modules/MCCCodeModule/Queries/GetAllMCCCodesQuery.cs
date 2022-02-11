using AutoMapper;
using DiscountСardApp.Application.Models.V1.MCCCode.Results;
using DiscountСardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiscountСardApp.Application.Modules.MCCCodeModule.Queries
{
    public sealed class GetAllMCCCodesQuery : IRequest<List<MCCCodeResult>>
    {
    }

    public sealed class GetAllMCCCodesQueryValidator : AbstractValidator<GetAllMCCCodesQuery>
    {
        public GetAllMCCCodesQueryValidator()
        {
        }
    }

    public sealed class GetAllMCCCodesQueryHandler : BaseModuleHandler<GetAllMCCCodesQuery, List<MCCCodeResult>>
    {
        public GetAllMCCCodesQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<List<MCCCodeResult>> Handle(GetAllMCCCodesQuery request, CancellationToken cancellationToken)
        {
            var mCCCodeList = await _dbContext.MCCCodes.ToListAsync();

            var mCCCodesResult = _mapper.Map<List<MCCCodeResult>>(mCCCodeList);

            return mCCCodesResult;
        }
    }
}
