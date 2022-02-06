namespace DiscountСardApp.Domain.EntityModels
{
    public class MCCCode
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; } = String.Empty;

        public List<Category>? Caterogies { get; set; } = null;
        public List<Store>? Stores { get; set; } = null;
    }
}
