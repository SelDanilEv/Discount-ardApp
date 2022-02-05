using AutoMapper;
using DiscountСardApp.Application.Models.V1.CommercialNetwork.Results;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.CommercialNetworkModule.Commands
{
    public sealed class DeleteCommercialNetworkCommand : IRequest<CommercialNetworkResult>
    {
        public Guid Id { get; set; }
    }

    public sealed class DeleteCommercialNetworkCommandValidator : AbstractValidator<DeleteCommercialNetworkCommand>
    {
        public DeleteCommercialNetworkCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please provide the commercial network id!");
        }
    }

    public sealed class DeleteCommercialNetworkCommandHandler : IRequestHandler<DeleteCommercialNetworkCommand, CommercialNetworkResult>
    {
        private readonly IMapper _mapper;

        public DeleteCommercialNetworkCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<CommercialNetworkResult> Handle(DeleteCommercialNetworkCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
            //return await _CommercialNetworkService.DeleteCommercialNetworkAsync(deleteCommercialNetworkModel);
        }
    }
}
