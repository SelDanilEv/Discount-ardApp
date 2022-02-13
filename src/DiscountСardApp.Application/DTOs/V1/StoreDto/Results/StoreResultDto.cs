using DiscountСardApp.Domain.EntityModels;

namespace DiscountСardApp.Application.DTOs.V1.StoreDto.Results
{
    public class StoreResultDto
    {
        public Guid Id { get; set; }
        public Guid MCCCodeId { get; set; }
        public MCCCode MCCCode { get; set; } = new MCCCode();

        public Guid CommercialNetworkId { get; set; }
        public CommercialNetwork CommercialNetwork { get; set; } = new CommercialNetwork();

        public string Address { get; set; } = String.Empty;
    }
}
