namespace DiscountСardApp.Domain.Entities
{
    public class CommertialNetwork
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Store> Stores { get; set; }
    }
}
