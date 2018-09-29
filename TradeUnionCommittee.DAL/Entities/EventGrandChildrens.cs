using System;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class EventGrandChildrens
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public long IdGrandChildren { get; set; }
        [ConcurrencyCheck]
        public long IdEvent { get; set; }
        [ConcurrencyCheck]
        public decimal Amount { get; set; }
        [ConcurrencyCheck]
        public decimal Discount { get; set; }
        [ConcurrencyCheck]
        public DateTime StartDate { get; set; }
        [ConcurrencyCheck]
        public DateTime EndDate { get; set; }

        public virtual Event IdEventNavigation { get; set; }
        public virtual GrandChildren IdGrandChildrenNavigation { get; set; }
    }
}
