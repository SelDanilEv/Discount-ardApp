namespace DiscountСardApp.Application.Models.V1.Bank.Results
{
    public class BankResult : BaseBankModel
    {
        public string? Name { get; set; }

        public List<Domain.Entities.DiscountCard> DiscountCards { get; set; } 
            = new List<Domain.Entities.DiscountCard>();
    }
}
