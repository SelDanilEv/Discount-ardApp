using AutoMapper;
using Discount—ardApp.Application.Models.V1.Bank.Results;
using FluentValidation;
using MediatR;

namespace Discount—ardApp.Application.Modules.Bank.Queries
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

        public GetAllBanksQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<BankResult>> Handle(GetAllBanksQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _bankService.GetAll();
        }
    }
}
