﻿using System;

namespace StefaniniPracticalTest.Domain.Entities
{ 
    public class Customer: BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int GenderId { get; set; }
        public int CityId { get; set; }
        public int RegionId { get; set; }
        public DateTime LastPurchase { get; set; }
        public int ClassificationId { get; set; }
        public int UserId { get; set; }

        public Gender Gender { get; set; }
        public City City { get; set; }
        public Region Region { get; set; }
        public Classification Classification { get; set; }
        public UserSys User { get; set; }
    }
}
