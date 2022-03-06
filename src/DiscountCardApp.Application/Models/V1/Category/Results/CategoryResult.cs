namespace DiscountCardApp.Application.Models.V1.Category.Results
{
    public class CategoryResult : BaseCategoryModel
    {
        public string Name { get; set; } = String.Empty;

        public Guid DiscountCardId { get; set; }

        public List<Domain.EntityModels.MCCCode> MCCCodes { get; set; } = new List<Domain.EntityModels.MCCCode>();
    }
}
