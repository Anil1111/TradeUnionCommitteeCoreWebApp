using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class PrivilegeEmployees
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public long IdEmployee { get; set; }
        [ConcurrencyCheck]
        public long IdPrivileges { get; set; }
        [ConcurrencyCheck]
        public string Note { get; set; }
        [ConcurrencyCheck]
        public bool CheckPrivileges { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Privileges IdPrivilegesNavigation { get; set; }
    }
}
