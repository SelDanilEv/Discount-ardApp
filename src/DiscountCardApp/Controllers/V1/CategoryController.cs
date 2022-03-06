using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DiscountCardApp.Application.DTOs.V1.CategoryDto.Results;
using DiscountCardApp.Application.DTOs.V1.CategoryDto.Requests;
using DiscountCardApp.Application.Modules.CategoryModule.Commands;
using DiscountCardApp.Application.Modules.CategoryModule.Queries;

namespace DiscountCardApp.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [SwaggerTag("")]
    public sealed class CategoryController : BaseApiController
    {
        public CategoryController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        { }

        [HttpGet("GetAllCategories")]
        [ProducesResponseType(typeof(List<CategoryResultDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<CategoryResultDto>>> GetCategorys()
        {
            var query = new GetAllCategorysQuery();

            return await ProcessApiCallAsync<GetAllCategorysQuery, List<CategoryResultDto>>(query);
        }

        [HttpGet("GetCategory")]
        [ProducesResponseType(typeof(CategoryResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CategoryResultDto>> GetCategory(GetCategoryDto getCategoryDto)
        {
            var query = new GetCategoryQuery
            {
                Id = getCategoryDto.Id
            };

            return await ProcessApiCallAsync<GetCategoryQuery, CategoryResultDto>(query);
        }

        [HttpPost("CreateCategory")]
        [ProducesResponseType(typeof(CategoryResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CategoryResultDto>> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var command = new CreateCategoryCommand
            {
                DiscountCardId = createCategoryDto.DiscountCardId,
                Name = createCategoryDto.Name,
            };

            return await ProcessApiCallAsync<CreateCategoryCommand, CategoryResultDto>(command);
        }

        [HttpPut("UpdateCategory")]
        [ProducesResponseType(typeof(CategoryResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CategoryResultDto>> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var command = new UpdateCategoryCommand
            {
                Id = updateCategoryDto.Id,
                DiscountCardId = updateCategoryDto.DiscountCardId,
                Name = updateCategoryDto.Name,
            };

            return await ProcessApiCallAsync<UpdateCategoryCommand, CategoryResultDto>(command);
        }

        [HttpDelete("DeleteCategory")]
        [ProducesResponseType(typeof(CategoryResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CategoryResultDto>> DeleteCategory(DeleteCategoryDto deleteCategoryDto)
        {
            var command = new DeleteCategoryCommand
            {
                Id = deleteCategoryDto.Id,
            };

            return await ProcessApiCallAsync<DeleteCategoryCommand, CategoryResultDto>(command);
        }

        [HttpPost("ReplaceCodes")]
        [ProducesResponseType(typeof(ReplaceCategoryCodesResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ReplaceCategoryCodesResultDto>> ReplaceCategoryCodes(ReplaceCategoryCodesDto replaceCategoryCodes)
        {
            var command = new ReplaceCategoryCodesCommand
            {
                Codes = replaceCategoryCodes.Codes,
                CategoryId = replaceCategoryCodes.CategoryId
            };

            return await ProcessApiCallAsync<ReplaceCategoryCodesCommand, ReplaceCategoryCodesResultDto>(command);
        }
    }
}