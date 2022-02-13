namespace DiscountСardApp.Application.DTOs.V1.CategoryDto.Requests
{
    public class ReplaceCategoryCodesDto
    {
        public string Codes { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
    }
}
