namespace DiscountСardApp.Application.Models.V1.DiscountCard.Results
{
    public class DiscountCardResult : BaseDiscountCardModel
    {
        public string CardName { get; set; } = String.Empty;
        public string Conditions { get; set; } = String.Empty;

        public Guid BankId { get; set; }

        public List<Domain.Entities.Caterogy> Caterogies { get; set; } = 
            new List<Domain.Entities.Caterogy>();
    }
}
