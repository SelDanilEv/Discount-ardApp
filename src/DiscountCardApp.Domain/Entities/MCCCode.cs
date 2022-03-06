namespace DiscountCardApp.Domain.Entities
{
    public class MCCCode
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

        public List<Category>? Caterogies { get; set; } = null;
        public List<Store>? Stores { get; set; } = null;
    }
}
