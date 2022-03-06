using DiscountCardApp.Domain.EntityModels;

namespace DiscountCardApp.Application.DTOs.V1.CommercialNetworkDto.Results
{
    public class CommercialNetworkResultDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = String.Empty;

        public List<Store> Stores { get; set; } = new List<Store>();
    }
}
