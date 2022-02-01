namespace DiscountСardApp.Domain.Entities
{
    public class Caterogy
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; } = String.Empty;

        public Guid DiscountCardId { get; set; }
        public DiscountCard DiscountCard { get; set; } = new DiscountCard();

        public List<MCCCode> MCCCodes { get; set; } = new List<MCCCode>();
    }
}
