﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class Event
    {
        public Event()
        {
            EventChildrens = new HashSet<EventChildrens>();
            EventEmployees = new HashSet<EventEmployees>();
            EventFamily = new HashSet<EventFamily>();
            EventGrandChildrens = new HashSet<EventGrandChildrens>();
        }

        public long Id { get; set; }
        [ConcurrencyCheck]
        public string Name { get; set; }
        [ConcurrencyCheck]
        public long TypeId { get; set; }

        public TypeEvent Type { get; set; }
        public ICollection<EventChildrens> EventChildrens { get; set; }
        public ICollection<EventEmployees> EventEmployees { get; set; }
        public ICollection<EventFamily> EventFamily { get; set; }
        public ICollection<EventGrandChildrens> EventGrandChildrens { get; set; }
    }
}
