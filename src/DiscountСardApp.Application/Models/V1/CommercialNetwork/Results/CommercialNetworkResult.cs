namespace DiscountСardApp.Application.Models.V1.CommercialNetwork.Results
{
    public class CommercialNetworkResult : BaseCommercialNetworkModel
    {
        public string? Name { get; set; } = String.Empty;

        public List<Domain.EntityModels.Store> Stores { get; set; } = new List<Domain.EntityModels.Store>();
    }
}
