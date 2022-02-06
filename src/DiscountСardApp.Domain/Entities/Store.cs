namespace DiscountСardApp.Domain.Entities
{
    public class Store
    {
        public Guid Id { get; set; }

        public Guid MCCCodeId { get; set; }
        public MCCCode? MCCCode { get; set; } = null;

        public Guid CommertialNetworkId { get; set; }
        public CommertialNetwork? CommertialNetwork { get; set; } = null;

        public string Address { get; set; } = String.Empty;
    }
}
