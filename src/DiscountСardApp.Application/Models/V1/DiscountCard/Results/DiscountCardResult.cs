namespace DiscountСardApp.Application.Models.V1.DiscountCard.Results
{
    public class DiscountCardResult : BaseDiscountCardModel
    {
        public string? Name { get; set; } = String.Empty;
        public string? Conditions { get; set; } = String.Empty;

        public Guid BankId { get; set; }

        public List<Domain.Entities.Category> Caterogies { get; set; } = 
            new List<Domain.Entities.Category>();
    }
}
