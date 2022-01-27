namespace DiscountСardApp.Domain.Entities
{
    public class DiscountCard
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid BankId { get; set; }
        public Bank Bank { get; set; }

        public ICollection<MCCCodeDiscountCard> MCCCodeDiscountCards { get; set; }
    }
}
