namespace DiscountСardApp.Application.DTOs.V1.CategoryDto.Requests
{
    public class UpdateCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid DiscountCardId { get; set; }
    }
}