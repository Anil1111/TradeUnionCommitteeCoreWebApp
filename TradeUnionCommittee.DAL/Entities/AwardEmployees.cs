using System;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class AwardEmployees
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public long IdEmployee { get; set; }
        [ConcurrencyCheck]
        public long IdAward { get; set; }
        [ConcurrencyCheck]
        public decimal Amount { get; set; }
        [ConcurrencyCheck]
        public DateTime DateIssue { get; set; }

        public virtual Award IdAwardNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
