﻿namespace DiscountCardApp.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public Guid DiscountCardId { get; set; }
        public DiscountCard? DiscountCard { get; set; } = null;

        public List<MCCCode>? MCCCodes { get; set; } = null;
    }
}
