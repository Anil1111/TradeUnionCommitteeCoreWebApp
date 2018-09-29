using System;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class ActivityFamily
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public long IdFamily { get; set; }
        [ConcurrencyCheck]
        public long IdActivities { get; set; }
        [ConcurrencyCheck]
        public DateTime DateEvent { get; set; }

        public virtual Activities IdActivitiesNavigation { get; set; }
        public virtual Family IdFamilyNavigation { get; set; }
    }
}
