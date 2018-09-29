using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class Cultural
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public string Name { get; set; }

        public virtual ICollection<CulturalChildrens> CulturalChildrens { get; set; }
        public virtual ICollection<CulturalEmployees> CulturalEmployees { get; set; }
        public virtual ICollection<CulturalFamily> CulturalFamily { get; set; }
        public virtual ICollection<CulturalGrandChildrens> CulturalGrandChildrens { get; set; }
    }
}
