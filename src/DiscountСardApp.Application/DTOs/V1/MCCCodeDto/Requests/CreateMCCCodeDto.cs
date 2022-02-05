namespace DiscountСardApp.Application.DTOs.V1.MCCCodeDto.Requests
{
    public class CreateMCCCodeDto
    {
        public int Code { get; set; }
        public string Description { get; set; } = String.Empty;
    }
}
