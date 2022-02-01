using DiscountСardApp.Domain.Entities;

namespace DiscountСardApp.Application.Models.V1.Category.Results
{
    public class CategoryResult : BaseCategoryModel
    {
        public string CategoryName { get; set; } = String.Empty;

        public Guid DiscountCardId { get; set; }

        public List<MCCCode> MCCCodes { get; set; } = new List<MCCCode>();
    }
}
