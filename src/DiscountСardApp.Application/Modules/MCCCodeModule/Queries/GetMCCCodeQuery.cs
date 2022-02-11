using AutoMapper;
using DiscountСardApp.Application.Models.V1.MCCCode.Results;
using DiscountСardApp.Infrastructure.Contexts;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.MCCCodeModule.Queries
{
    public sealed class GetMCCCodeQuery : IRequest<MCCCodeResult>
    {
        public Guid Id { get; set; }
    }

    public sealed class GetMCCCodeQueryValidator : AbstractValidator<GetMCCCodeQuery>
    {
        public GetMCCCodeQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the сode id!");
        }
    }

    public sealed class GetMCCCodeQueryHandler : BaseModuleHandler<GetMCCCodeQuery, MCCCodeResult>
    {
        public GetMCCCodeQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<MCCCodeResult> Handle(GetMCCCodeQuery request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _MCCCodeService.GetAll(getMCCCodeModel);
        }
    }
}
