namespace DiscountСardApp.Application.Models.V1.MCCCode.Results
{
    public class MCCCodeResult : BaseMCCCodeModel
    {
        public int Code { get; set; }
        public string? Description { get; set; } = String.Empty;

        public List<Domain.Entities.Caterogy> Caterogies { get; set; } = new List<Domain.Entities.Caterogy>();
        public List<Domain.Entities.Store> Stores { get; set; } = new List<Domain.Entities.Store>();
    }
}
