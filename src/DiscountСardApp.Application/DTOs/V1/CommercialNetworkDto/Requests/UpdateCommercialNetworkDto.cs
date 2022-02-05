namespace DiscountСardApp.Application.DTOs.V1.CommercialNetworkDto.Requests
{
    public class UpdateCommercialNetworkDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = String.Empty;
    }
}