namespace DiscountCardApp.Application.Models.V1.Store.Results
{
    public class StoreResult : BaseStoreModel
    {
        public Guid MCCCodeId { get; set; }
        public Domain.EntityModels.MCCCode MCCCode { get; set; } = new Domain.EntityModels.MCCCode();

        public Guid CommercialNetworkId { get; set; }
        public Domain.EntityModels.CommercialNetwork CommercialNetwork { get; set; } = new Domain.EntityModels.CommercialNetwork();

        public string Address { get; set; } = String.Empty;
    }
}
