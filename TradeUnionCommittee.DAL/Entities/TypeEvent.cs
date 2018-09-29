﻿using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class TypeEvent
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public string Name { get; set; }

        public virtual Event Event { get; set; }
    }
}
