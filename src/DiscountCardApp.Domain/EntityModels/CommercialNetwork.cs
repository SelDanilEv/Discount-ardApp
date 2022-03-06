namespace DiscountCardApp.Domain.EntityModels
{
    public class CommercialNetwork
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public List<Store>? Stores { get; set; } = null;
    }
}
