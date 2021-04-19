using System;

namespace StefaniniPracticalTest.Domain.Filters
{
    public class CustomerFilter
    {
        public string? Name { get; set; }
        public int? GenderId { get; set; }
        public int? CityId { get; set; }
        public int? RegionId { get; set; }
        public int? ClassificationId { get; set; }
        public DateTime? LastPurchaseFrom { get; set; }
        public DateTime? LastPurchaseTo { get; set; }
        public int? SellerId { get; set; }
    }
}
