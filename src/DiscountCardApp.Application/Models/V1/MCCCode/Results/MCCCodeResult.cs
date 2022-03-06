namespace DiscountCardApp.Application.Models.V1.MCCCode.Results
{
    public class MCCCodeResult : BaseMCCCodeModel
    {
        public string Code { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

        public List<Domain.EntityModels.Category> Caterogies { get; set; } = new List<Domain.EntityModels.Category>();
        public List<Domain.EntityModels.Store> Stores { get; set; } = new List<Domain.EntityModels.Store>();
    }
}
