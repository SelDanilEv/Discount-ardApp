namespace DiscountСardApp.Domain.EntityModels
{
    public class Store
    {
        public Guid Id { get; set; }

        public Guid MCCCodeId { get; set; }

        public MCCCode? MCCCode { get; set; } = null;

        public Guid CommercialNetworkId { get; set; }

        public string Address { get; set; } = String.Empty;
    }
}
