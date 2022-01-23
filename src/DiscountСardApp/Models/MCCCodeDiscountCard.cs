namespace DiscountСardApp.Models
{
    public class MCCCodeDiscountCard
    {
        public Guid Id { get; set; }

        public int Code { get; set; }
        public MCCCode MCCCode { get; set; }

        public Guid DiscountCardId { get; set; }
        public DiscountCard DiscountCard { get; set; }
    }
}
