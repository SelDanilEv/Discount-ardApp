﻿namespace DiscountCardApp.Application.DTOs.V1.StoreDto.Requests
{
    public class UpdateStoreDto
    {
        public Guid Id { get; set; }
        public Guid MCCCodeId { get; set; }
        public Guid CommercialNetworkId { get; set; }
        public string Address { get; set; } = String.Empty;
    }
}