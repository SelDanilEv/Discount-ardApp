using AutoMapper;
using DiscountCardApp.Infrastructure.Contexts;
using MediatR;

namespace DiscountCardApp.Application.Modules
{
    public abstract class BaseModuleHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly IMapper _mapper;
        protected readonly ApplicationDbContext _dbContext;

        public BaseModuleHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
