namespace DiscountСardApp.Application.DTOs.V1.MCCCodeDto.Requests
{
    public class UpdateMCCCodeDto
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; } = String.Empty;
    }
}