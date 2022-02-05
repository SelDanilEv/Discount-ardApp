namespace DiscountСardApp.Domain.Entities
{
    public class DiscountCard
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public Guid BankId { get; set; }
        public Bank Bank { get; set; } = new Bank();

        public List<Category> Caterogies { get; set; } = new List<Category>();
    }
}
