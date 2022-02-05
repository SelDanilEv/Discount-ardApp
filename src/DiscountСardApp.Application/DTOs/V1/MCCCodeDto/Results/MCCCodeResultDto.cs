using DiscountСardApp.Domain.Entities;

namespace DiscountСardApp.Application.DTOs.V1.MCCCodeDto.Results
{
    public class MCCCodeResultDto
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; } = String.Empty;

        public List<Category> Caterogies { get; set; } = new List<Category>();
        public List<Store> Stores { get; set; } = new List<Store>();
    }
}
