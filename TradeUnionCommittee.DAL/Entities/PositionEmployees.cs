using System;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class PositionEmployees
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public long IdEmployee { get; set; }
        [ConcurrencyCheck]
        public long IdSubdivision { get; set; }
        [ConcurrencyCheck]
        public long IdPosition { get; set; }
        [ConcurrencyCheck]
        public bool CheckPosition { get; set; }
        [ConcurrencyCheck]
        public DateTime? StartDate { get; set; }
        [ConcurrencyCheck]
        public DateTime? EndDate { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Position IdPositionNavigation { get; set; }
        public virtual Subdivisions IdSubdivisionNavigation { get; set; }
    }
}
