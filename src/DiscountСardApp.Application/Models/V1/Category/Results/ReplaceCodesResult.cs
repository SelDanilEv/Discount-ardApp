namespace DiscountСardApp.Application.Models.V1.Category.Results
{
    public class ReplaceCodesResult : BaseCategoryModel
    {
        public string Codes { get; set; } = String.Empty;

        public Guid CategoryId { get; set; }
    }
}
