﻿using TradeUnionCommittee.DAL.EF;
using TradeUnionCommittee.DAL.Entities;

namespace TradeUnionCommittee.DAL.Repositories.Directories
{
    public class ActivitiesRepository : Repository<Activities>
    {
        public ActivitiesRepository(TradeUnionCommitteeEmployeesCoreContext db) : base(db)
        {
        }
    }
}