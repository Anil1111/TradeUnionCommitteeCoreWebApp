﻿using TradeUnionCommittee.DAL.EF;
using TradeUnionCommittee.DAL.Entities;

namespace TradeUnionCommittee.DAL.Repositories.Lists
{
    public class HobbyChildrensRepository : Repository<HobbyChildrens>
    {
        public HobbyChildrensRepository(TradeUnionCommitteeEmployeesCoreContext db) : base(db)
        {
        }
    }
}