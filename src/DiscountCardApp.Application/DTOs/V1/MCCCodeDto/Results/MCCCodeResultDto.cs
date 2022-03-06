using DiscountCardApp.Domain.EntityModels;

namespace DiscountCardApp.Application.DTOs.V1.MCCCodeDto.Results
{
    public class MCCCodeResultDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = String.Empty;

        public List<Category> Caterogies { get; set; } = new List<Category>();
        public List<Store> Stores { get; set; } = new List<Store>();
    }
}
