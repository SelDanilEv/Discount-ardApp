namespace DiscountCardApp.Domain.Entities
{
    public class Store
    {
        public Guid Id { get; set; }

        public Guid MCCCodeId { get; set; }
        public MCCCode? MCCCode { get; set; } = null;

        public Guid CommercialNetworkId { get; set; }
        public CommercialNetwork? CommercialNetwork { get; set; } = null;

        public string Address { get; set; } = String.Empty;
    }
}
