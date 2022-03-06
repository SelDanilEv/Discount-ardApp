namespace DiscountCardApp.Application.Models.V1.Bank.Results
{
    public class BankResult : BaseBankModel
    {
        public string? Name { get; set; } = string.Empty;

        public List<Domain.EntityModels.DiscountCard>? DiscountCards { get; set; }
            = null;
    }
}
