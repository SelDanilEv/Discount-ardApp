using AutoMapper;
using DiscountСardApp.Application.Models.V1.MCCCode.Results;
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

    public sealed class GetMCCCodeQueryHandler : IRequestHandler<GetMCCCodeQuery, MCCCodeResult>
    {
        private readonly IMapper _mapper;

        public GetMCCCodeQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<MCCCodeResult> Handle(GetMCCCodeQuery request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _MCCCodeService.GetAll(getMCCCodeModel);
        }
    }
}
