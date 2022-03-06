using DiscountCardApp.Domain.EntityModels;

namespace DiscountCardApp.Application.DTOs.V1.BankDto.Results
{
    public class BankResultDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public List<DiscountCard> DiscountCards { get; set; } = new List<DiscountCard>();
    }
}
