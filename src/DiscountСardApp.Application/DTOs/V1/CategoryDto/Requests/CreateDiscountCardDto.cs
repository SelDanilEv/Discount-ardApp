namespace DiscountСardApp.Application.DTOs.V1.CategoryDto.Requests
{
    public class CreateCategoryDto
    {
        public string? Name { get; set; }
        public Guid DiscountCardId { get; set; }
    }
}
