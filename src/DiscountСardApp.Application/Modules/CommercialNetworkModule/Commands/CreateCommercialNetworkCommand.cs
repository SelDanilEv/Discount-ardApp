using AutoMapper;
using DiscountСardApp.Application.Models.V1.CommercialNetwork.Results;
using DiscountСardApp.Domain.Entities;
using FluentValidation;
using MediatR;

namespace DiscountСardApp.Application.Modules.CommercialNetworkModule.Commands
{
    public sealed class CreateCommercialNetworkCommand : IRequest<CommercialNetworkResult>
    {
        public string? Name { get; set; }
    }

    public sealed class CreateCommercialNetworkCommandValidator : AbstractValidator<CreateCommercialNetworkCommand>
    {
        public CreateCommercialNetworkCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Please provide the commercial network name!");
        }
    }

    public sealed class CreateCommercialNetworkCommandHandler : IRequestHandler<CreateCommercialNetworkCommand, CommercialNetworkResult>
    {
        private readonly IMapper _mapper;

        public CreateCommercialNetworkCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<CommercialNetworkResult> Handle(CreateCommercialNetworkCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _CommercialNetworkService.CreateCommercialNetworkAsync(createCommercialNetworkModel);
        }
    }
}
