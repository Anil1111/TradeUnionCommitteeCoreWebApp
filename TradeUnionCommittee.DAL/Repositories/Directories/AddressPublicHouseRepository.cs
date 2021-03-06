﻿using TradeUnionCommittee.DAL.EF;
using TradeUnionCommittee.DAL.Entities;

namespace TradeUnionCommittee.DAL.Repositories.Directories
{
    public class AddressPublicHouseRepository : Repository<AddressPublicHouse>
    {
        public AddressPublicHouseRepository(TradeUnionCommitteeEmployeesCoreContext db) : base(db)
        {
        }
    }
}