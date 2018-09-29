using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class Subdivisions
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public long? IdSubordinate { get; set; }
        [ConcurrencyCheck]
        public string Name { get; set; }
        [ConcurrencyCheck]
        public string Abbreviation { get; set; }

        public virtual Subdivisions IdSubordinateNavigation { get; set; }
        public virtual ICollection<Subdivisions> InverseIdSubordinateNavigation { get; set; }
        public virtual ICollection<PositionEmployees> PositionEmployees { get; set; }
    }
}
