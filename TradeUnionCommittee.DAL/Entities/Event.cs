using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class Event
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public string Name { get; set; }
        [ConcurrencyCheck]
        public long TypeId { get; set; }

        public virtual TypeEvent Type { get; set; }
        public virtual ICollection<EventChildrens> EventChildrens { get; set; }
        public virtual ICollection<EventEmployees> EventEmployees { get; set; }
        public virtual ICollection<EventFamily> EventFamily { get; set; }
        public virtual ICollection<EventGrandChildrens> EventGrandChildrens { get; set; }
    }
}
