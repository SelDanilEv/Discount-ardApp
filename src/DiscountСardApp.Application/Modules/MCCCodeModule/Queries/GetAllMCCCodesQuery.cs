using AutoMapper;
using DiscountСardApp.Application.Models.V1.MCCCode.Results;
using FluentValidation;
using MediatR;

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

    public sealed class GetAllMCCCodesQueryHandler : IRequestHandler<GetAllMCCCodesQuery, List<MCCCodeResult>>
    {
        private readonly IMapper _mapper;

        public GetAllMCCCodesQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<MCCCodeResult>> Handle(GetAllMCCCodesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _MCCCodeService.GetAll();
        }
    }
}
