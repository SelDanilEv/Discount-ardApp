namespace DiscountCardApp.Application.DTOs.V1.DiscountCardDto.Requests
{
    public class CreateDiscountCardDto
    {
        public Guid BankId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Conditions { get; set; } = String.Empty;
    }
}
