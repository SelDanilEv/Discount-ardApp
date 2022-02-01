namespace DiscountСardApp.Domain.Entities
{
    public class Store
    {
        public Guid Id { get; set; }

        public int Code { get; set; }
        public MCCCode MCCCode { get; set; } = new MCCCode();

        public Guid CommertialNetworkId { get; set; }
        public CommertialNetwork CommertialNetwork { get; set; } = new CommertialNetwork();

        public string Address { get; set; } = String.Empty;
    }
}
