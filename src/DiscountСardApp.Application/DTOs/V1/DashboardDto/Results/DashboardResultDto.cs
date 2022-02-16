using DiscountСardApp.Domain.EntityModels;

namespace DiscountСardApp.Application.DTOs.V1.DashboardDto.Results
{
    public class DashboardResultDto
    {
        public List<CommercialNetwork> Stores { get; set; } = new List<CommercialNetwork>();
    }
}
