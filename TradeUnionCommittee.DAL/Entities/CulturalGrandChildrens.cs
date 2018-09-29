﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class CulturalGrandChildrens
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public long IdGrandChildren { get; set; }
        [ConcurrencyCheck]
        public long IdCultural { get; set; }
        [ConcurrencyCheck]
        public decimal Amount { get; set; }
        [ConcurrencyCheck]
        public decimal Discount { get; set; }
        [ConcurrencyCheck]
        public DateTime DateVisit { get; set; }

        public virtual Cultural IdCulturalNavigation { get; set; }
        public virtual GrandChildren IdGrandChildrenNavigation { get; set; }
    }
}
