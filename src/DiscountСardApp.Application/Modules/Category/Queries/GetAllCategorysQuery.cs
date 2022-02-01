using AutoMapper;
using Discount—ardApp.Application.Models.V1.Category.Results;
using FluentValidation;
using MediatR;

namespace Discount—ardApp.Application.Modules.Category.Queries
{
    public sealed class GetAllCategorysQuery : IRequest<List<CategoryResult>>
    {
    }

    public sealed class GetAllCategorysQueryValidator : AbstractValidator<GetAllCategorysQuery>
    {
        public GetAllCategorysQueryValidator()
        {
        }
    }

    public sealed class GetAllCategorysQueryHandler : IRequestHandler<GetAllCategorysQuery, List<CategoryResult>>
    {
        private readonly IMapper _mapper;

        public GetAllCategorysQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<CategoryResult>> Handle(GetAllCategorysQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _CategoryService.GetAll();
        }
    }
}
