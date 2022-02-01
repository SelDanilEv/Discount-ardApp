namespace DiscountСardApp.Domain.Entities
{
    public class MCCCode
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; } = String.Empty;

        public List<Caterogy> Caterogies { get; set; } = new List<Caterogy>();
        public List<Store> Stores { get; set; } = new List<Store>();
    }
}
