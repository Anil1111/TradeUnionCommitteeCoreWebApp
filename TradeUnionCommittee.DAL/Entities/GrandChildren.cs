using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class GrandChildren
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public long IdEmployee { get; set; }
        [ConcurrencyCheck]
        public string FirstName { get; set; }
        [ConcurrencyCheck]
        public string SecondName { get; set; }
        [ConcurrencyCheck]
        public string Patronymic { get; set; }
        [ConcurrencyCheck]
        public DateTime BirthDate { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual ICollection<ActivityGrandChildrens> ActivityGrandChildrens { get; set; }
        public virtual ICollection<CulturalGrandChildrens> CulturalGrandChildrens { get; set; }
        public virtual ICollection<EventGrandChildrens> EventGrandChildrens { get; set; }
        public virtual ICollection<GiftGrandChildrens> GiftGrandChildrens { get; set; }
        public virtual ICollection<HobbyGrandChildrens> HobbyGrandChildrens { get; set; }
    }
}
