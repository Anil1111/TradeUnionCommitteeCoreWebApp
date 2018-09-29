using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class Privileges
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public string Name { get; set; }

        public virtual ICollection<PrivilegeEmployees> PrivilegeEmployees { get; set; }
    }
}
