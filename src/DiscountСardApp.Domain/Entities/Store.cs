namespace DiscountСardApp.Domain.Entities
{
    public class Store
    {
        public Guid Id { get; set; }

        public int Code { get; set; }
        public MCCCode MCCCode { get; set; }

        public Guid CommertialNetworkId { get; set; }
        public CommertialNetwork CommertialNetwork { get; set; }

        public string Address { get; set; }
    }
}
