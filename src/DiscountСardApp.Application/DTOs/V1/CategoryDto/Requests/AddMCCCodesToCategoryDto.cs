namespace DiscountСardApp.Application.DTOs.V1.CategoryDto.Requests
{
    public class AddMCCCodesToCategoryDto
    {
        public string Codes { get; set; } = string.Empty;
        public Guid DiscountCardId { get; set; }
    }
}
