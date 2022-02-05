using DiscountСardApp.Domain.Entities;

namespace DiscountСardApp.Application.DTOs.V1.DiscountCardDto.Results
{
    public class DiscountCardResultDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Conditions { get; set; }

        public Guid BankId { get; set; }
        public List<Category> Categories = new List<Category>();
    }
}
