namespace DiscountСardApp.Application.DTOs.V1.StoreDto.Requests
{
    public class CreateStoreDto
    {
        public Guid MCCCodeId { get; set; }
        public Guid CommertialNetworkId { get; set; }
        public string Address { get; set; } = String.Empty;
    }
}
