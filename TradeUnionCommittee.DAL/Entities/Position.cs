using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class Position
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public string Name { get; set; }

        public virtual ICollection<PositionEmployees> PositionEmployees { get; set; }
    }
}
