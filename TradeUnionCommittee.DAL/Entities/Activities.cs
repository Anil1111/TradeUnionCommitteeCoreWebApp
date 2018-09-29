using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class Activities
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public string Name { get; set; }

        public virtual ICollection<ActivityChildrens> ActivityChildrens { get; set; }
        public virtual ICollection<ActivityEmployees> ActivityEmployees { get; set; }
        public virtual ICollection<ActivityFamily> ActivityFamily { get; set; }
        public virtual ICollection<ActivityGrandChildrens> ActivityGrandChildrens { get; set; }
    }
}
