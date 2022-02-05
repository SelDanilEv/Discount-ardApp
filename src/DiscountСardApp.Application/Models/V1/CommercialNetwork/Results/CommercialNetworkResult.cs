namespace DiscountСardApp.Application.Models.V1.CommercialNetwork.Results
{
    public class CommercialNetworkResult : BaseCommercialNetworkModel
    {
        public string? Name { get; set; } = String.Empty;

        public List<Domain.Entities.Store> Stores { get; set; } = new List<Domain.Entities.Store>();
    }
}
