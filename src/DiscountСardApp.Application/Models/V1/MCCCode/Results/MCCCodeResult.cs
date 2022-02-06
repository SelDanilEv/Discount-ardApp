namespace DiscountСardApp.Application.Models.V1.MCCCode.Results
{
    public class MCCCodeResult : BaseMCCCodeModel
    {
        public int Code { get; set; }
        public string? Description { get; set; } = String.Empty;

        public List<Domain.EntityModels.Category> Caterogies { get; set; } = new List<Domain.EntityModels.Category>();
        public List<Domain.EntityModels.Store> Stores { get; set; } = new List<Domain.EntityModels.Store>();
    }
}
