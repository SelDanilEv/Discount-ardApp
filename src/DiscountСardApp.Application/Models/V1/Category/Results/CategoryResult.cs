using DiscountСardApp.Domain.Entities;

namespace DiscountСardApp.Application.Models.V1.Category.Results
{
    public class CategoryResult : BaseCategoryModel
    {
        public string? Name { get; set; } = String.Empty;

        public Guid DiscountCardId { get; set; }

        public List<Domain.Entities.MCCCode> MCCCodes { get; set; } = new List<Domain.Entities.MCCCode>();
    }
}
