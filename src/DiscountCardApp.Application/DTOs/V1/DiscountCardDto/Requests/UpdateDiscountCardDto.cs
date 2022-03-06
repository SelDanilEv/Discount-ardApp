namespace DiscountCardApp.Application.DTOs.V1.DiscountCardDto.Requests
{
    public class UpdateDiscountCardDto
    {
        public Guid Id { get; set; }
        public Guid BankId { get; set; }
        public string? Name { get; set; }
        public string? Conditions { get; set; }
    }
}