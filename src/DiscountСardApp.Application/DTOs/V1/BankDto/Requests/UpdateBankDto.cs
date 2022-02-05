namespace DiscountСardApp.Application.DTOs.V1.BankDto.Requests
{
    public class UpdateBankDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
    }
}