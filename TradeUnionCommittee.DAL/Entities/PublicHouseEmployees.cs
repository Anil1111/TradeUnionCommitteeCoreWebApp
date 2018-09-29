using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class PublicHouseEmployees
    {
        public long IdAddressPublicHouse { get; set; }
        [ConcurrencyCheck]
        public long IdEmployee { get; set; }
        [ConcurrencyCheck]
        public string NumberRoom { get; set; }

        public virtual AddressPublicHouse IdAddressPublicHouseNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
