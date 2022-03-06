using DiscountCardApp.Domain.EntityModels;

namespace DiscountCardApp.Application.DTOs.V1.CategoryDto.Results
{
    public class CategoryResultDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public Guid DiscountCardId { get; set; }
        public List<MCCCode> MCCCodes = new List<MCCCode>();
    }
}
