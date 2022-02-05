using DiscountСardApp.Domain.Entities;

namespace DiscountСardApp.Application.DTOs.V1.StoreDto.Results
{
    public class StoreResultDto
    {
        public Guid Id { get; set; }
        public Guid MCCCodeId { get; set; }
        public MCCCode MCCCode { get; set; } = new MCCCode();

        public Guid CommertialNetworkId { get; set; }
        public CommertialNetwork CommertialNetwork { get; set; } = new CommertialNetwork();

        public string Address { get; set; } = String.Empty;
    }
}
