namespace DiscountCardApp.Application.DTOs.V1.StoreDto.Requests
{
    public class CreateStoreDto
    {
        public Guid CommercialNetworkId { get; set; }
        public string MCCCode { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
    }
}
