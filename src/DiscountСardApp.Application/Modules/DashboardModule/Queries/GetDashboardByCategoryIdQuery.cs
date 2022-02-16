using AutoMapper;
using DiscountСardApp.Application.Models.V1.Dashboard.Results;
using DiscountСardApp.Domain.EntityModels;
using DiscountСardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DiscountСardApp.Application.Modules.DashboardModule.Queries
{
    public sealed class GetDashboardByCategoryIdQuery : IRequest<DashboardResult>
    {
        public Guid CategoryId { get; set; }
    }

    public sealed class GetDashboardByCategoryIdQueryValidator : AbstractValidator<GetDashboardByCategoryIdQuery>
    {
        public GetDashboardByCategoryIdQueryValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Please provide the category id!");
        }
    }

    public sealed class GetDashboardByCategoryIdQueryHandler : BaseModuleHandler<GetDashboardByCategoryIdQuery, DashboardResult>
    {
        public GetDashboardByCategoryIdQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<DashboardResult> Handle(GetDashboardByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var dashboardResult = new DashboardResult();

            var codes = _dbContext.Categories.Include(c => c.MCCCodes)
                                        .Single(x => x.Id == request.CategoryId)
                                        .MCCCodes.Select(c => c.Code);

            var stores = await _dbContext.CommercialNetworks
                .Include(cn => cn.Stores.Where(s => codes.Contains(s.MCCCode.Code)))
                .Where(cn => cn.Stores.Where(s => codes.Contains(s.MCCCode.Code)).Count() > 0)
                .ToListAsync();

            if (stores == null)
            {
                throw new ArgumentOutOfRangeException("Category with that id is not exist");
            }

            dashboardResult.Stores = _mapper.Map<List<CommercialNetwork>>(stores);


            return dashboardResult;
        }
    }
}
