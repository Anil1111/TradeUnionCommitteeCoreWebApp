using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class SocialActivity
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public string Name { get; set; }

        public virtual ICollection<SocialActivityEmployees> SocialActivityEmployees { get; set; }
    }
}
