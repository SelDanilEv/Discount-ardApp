namespace DiscountСardApp.Application.DTOs.V1.DiscountCardDto.Requests
{
    public class CreateDiscountCardDto
    {
        public Guid BankId { get; set; }
        public string? Name { get; set; }
        public string? Conditions { get; set; }
    }
}
