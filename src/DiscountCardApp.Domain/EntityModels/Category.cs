namespace DiscountCardApp.Domain.EntityModels
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public Guid DiscountCardId { get; set; }

        public List<MCCCode>? MCCCodes { get; set; } = null;
    }
}
