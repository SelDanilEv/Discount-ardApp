namespace DiscountСardApp.Application.Models.V1.Store.Results
{
    public class StoreResult : BaseStoreModel
    {
        public Guid MCCCodeId { get; set; }
        public Domain.EntityModels.MCCCode MCCCode { get; set; } = new Domain.EntityModels.MCCCode();

        public Guid CommertialNetworkId { get; set; }
        public Domain.EntityModels.CommertialNetwork CommertialNetwork { get; set; } = new Domain.EntityModels.CommertialNetwork();

        public string Address { get; set; } = String.Empty;
    }
}
