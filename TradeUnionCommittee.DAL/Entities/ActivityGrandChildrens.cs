using System;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class ActivityGrandChildrens
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public long IdGrandChildren { get; set; }
        [ConcurrencyCheck]
        public long IdActivities { get; set; }
        [ConcurrencyCheck]
        public DateTime DateEvent { get; set; }

        public virtual Activities IdActivitiesNavigation { get; set; }
        public virtual GrandChildren IdGrandChildrenNavigation { get; set; }
    }
}
