﻿using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class HobbyEmployees
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public long IdEmployee { get; set; }
        [ConcurrencyCheck]
        public long IdHobby { get; set; }

        public Employee IdEmployeeNavigation { get; set; }
        public Hobby IdHobbyNavigation { get; set; }
    }
}
