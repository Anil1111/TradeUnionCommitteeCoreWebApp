﻿using TradeUnionCommittee.DAL.EF;
using TradeUnionCommittee.DAL.Entities;

namespace TradeUnionCommittee.DAL.Repositories.Directories
{
    public class PrivilegesRepository : Repository<Privileges>
    {
        public PrivilegesRepository(TradeUnionCommitteeEmployeesCoreContext db) : base(db)
        {
        }
    }
}