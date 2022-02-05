namespace DiscountСardApp.Application.Models.V1.Store.Results
{
    public class StoreResult : BaseStoreModel
    {
        public Guid MCCCodeId { get; set; }
        public Domain.Entities.MCCCode MCCCode { get; set; } = new Domain.Entities.MCCCode();

        public Guid CommertialNetworkId { get; set; }
        public Domain.Entities.CommertialNetwork CommertialNetwork { get; set; } = new Domain.Entities.CommertialNetwork();

        public string Address { get; set; } = String.Empty;
    }
}
