namespace DiscountCardApp.Domain.EntityModels
{
    public class Bank
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public List<DiscountCard>? DiscountCards { get; set; } = null;
    }
}
