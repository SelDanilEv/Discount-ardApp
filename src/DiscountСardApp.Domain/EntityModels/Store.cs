namespace DiscountСardApp.Domain.EntityModels
{
    public class Store
    {
        public Guid Id { get; set; }

        public Guid MCCCodeId { get; set; }

        public Guid CommertialNetworkId { get; set; }

        public string Address { get; set; } = String.Empty;
    }
}
