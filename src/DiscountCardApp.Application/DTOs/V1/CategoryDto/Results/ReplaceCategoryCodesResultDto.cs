using DiscountCardApp.Application.DTOs.V1.EmptyResult;

namespace DiscountCardApp.Application.DTOs.V1.CategoryDto.Results
{
    public class ReplaceCategoryCodesResultDto : EmptyResultDto
    {
        public string Codes { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
    }
}
