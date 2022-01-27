namespace DiscountСardApp.Domain.Entities
{
    public class MCCCode
    {
        public int Code { get; set; }
        public string Description { get; set; }

        public ICollection<MCCCodeDiscountCard> MCCCodeDiscountCards { get; set; }
        public ICollection<Store> Stores { get; set; }
    }
}
