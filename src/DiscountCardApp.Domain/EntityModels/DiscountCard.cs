namespace DiscountCardApp.Domain.EntityModels
{
    public class DiscountCard
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Conditions { get; set; } = String.Empty;

        public Guid BankId { get; set; }

        public List<Category>? Categories { get; set; } = null;
    }
}
