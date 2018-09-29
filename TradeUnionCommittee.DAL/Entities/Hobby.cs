using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class Hobby
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public string Name { get; set; }

        public virtual ICollection<HobbyChildrens> HobbyChildrens { get; set; }
        public virtual ICollection<HobbyEmployees> HobbyEmployees { get; set; }
        public virtual ICollection<HobbyGrandChildrens> HobbyGrandChildrens { get; set; }
    }
}
