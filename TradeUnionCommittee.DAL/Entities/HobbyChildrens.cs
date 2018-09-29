using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class HobbyChildrens
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public long IdChildren { get; set; }
        [ConcurrencyCheck]
        public long IdHobby { get; set; }

        public virtual Children IdChildrenNavigation { get; set; }
        public virtual Hobby IdHobbyNavigation { get; set; }
    }
}
