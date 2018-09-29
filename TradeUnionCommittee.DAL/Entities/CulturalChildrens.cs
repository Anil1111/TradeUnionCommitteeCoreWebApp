using System;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class CulturalChildrens
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public long IdChildren { get; set; }
        [ConcurrencyCheck]
        public long IdCultural { get; set; }
        [ConcurrencyCheck]
        public decimal Amount { get; set; }
        [ConcurrencyCheck]
        public decimal Discount { get; set; }
        [ConcurrencyCheck]
        public DateTime DateVisit { get; set; }

        public virtual Children IdChildrenNavigation { get; set; }
        public virtual Cultural IdCulturalNavigation { get; set; }
    }
}
