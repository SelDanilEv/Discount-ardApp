using AutoMapper;
using DiscountСardApp.Application.Models.V1.Bank.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.Bank.Queries
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

    public sealed class GetBankQueryHandler : IRequestHandler<GetBankQuery, BankResult>
    {
        private readonly IMapper _mapper;

        public GetBankQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<BankResult> Handle(GetBankQuery request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _bankService.GetAll(getBankModel);
        }
    }
}
