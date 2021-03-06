﻿using TradeUnionCommittee.DAL.EF;
using TradeUnionCommittee.DAL.Entities;

namespace TradeUnionCommittee.DAL.Repositories.Directories
{
    public class SocialActivityRepository : Repository<SocialActivity>
    {
        public SocialActivityRepository(TradeUnionCommitteeEmployeesCoreContext db) : base(db)
        {
        }
    }
}