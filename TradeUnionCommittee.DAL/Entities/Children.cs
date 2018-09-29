using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class Children
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
        public virtual ICollection<ActivityChildrens> ActivityChildrens { get; set; }
        public virtual ICollection<CulturalChildrens> CulturalChildrens { get; set; }
        public virtual ICollection<EventChildrens> EventChildrens { get; set; }
        public virtual ICollection<GiftChildrens> GiftChildrens { get; set; }
        public virtual ICollection<HobbyChildrens> HobbyChildrens { get; set; }
    }
}
