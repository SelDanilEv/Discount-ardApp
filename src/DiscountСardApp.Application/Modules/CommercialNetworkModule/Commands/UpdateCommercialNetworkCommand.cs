using AutoMapper;
using DiscountСardApp.Application.Models.V1.CommercialNetwork.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.CommercialNetworkModule.Commands
{
    public sealed class UpdateCommercialNetworkCommand : IRequest<CommercialNetworkResult>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }

    public sealed class UpdateCommercialNetworkCommandValidator : AbstractValidator<UpdateCommercialNetworkCommand>
    {
        public UpdateCommercialNetworkCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the commercial network id!");
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Please provide the commercial network name!");
        }
    }

    public sealed class UpdateCommercialNetworkCommandHandler : IRequestHandler<UpdateCommercialNetworkCommand, CommercialNetworkResult>
    {
        private readonly IMapper _mapper;

        public UpdateCommercialNetworkCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<CommercialNetworkResult> Handle(UpdateCommercialNetworkCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _CommercialNetworkService.UpdateCommercialNetworkAsync(updateCommercialNetworkModel);
        }
    }
}
