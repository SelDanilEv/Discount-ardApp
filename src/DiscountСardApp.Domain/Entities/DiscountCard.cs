﻿namespace DiscountСardApp.Domain.Entities
{
    public class DiscountCard
    {
        public Guid Id { get; set; }
        public string CardName { get; set; } = String.Empty;

        public Guid BankId { get; set; }
        public Bank Bank { get; set; } = new Bank();

        public List<Caterogy> Caterogies { get; set; } = new List<Caterogy>();
    }
}
