using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradeUnionCommittee.DAL.Entities
{
    public class Employee
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public string FirstName { get; set; }
        [ConcurrencyCheck]
        public string SecondName { get; set; }
        [ConcurrencyCheck]
        public string Patronymic { get; set; }
        [ConcurrencyCheck]
        public string Sex { get; set; }
        [ConcurrencyCheck]
        public DateTime BirthDate { get; set; }
        [ConcurrencyCheck]
        public string IdentificationСode { get; set; }
        [ConcurrencyCheck]
        public string MechnikovCard { get; set; }
        [ConcurrencyCheck]
        public string MobilePhone { get; set; }
        [ConcurrencyCheck]
        public string CityPhone { get; set; }
        [ConcurrencyCheck]
        public string BasicProfession { get; set; }
        [ConcurrencyCheck]
        public int StartYearWork { get; set; }
        [ConcurrencyCheck]
        public int? EndYearWork { get; set; }
        [ConcurrencyCheck]
        public DateTime StartDateTradeUnion { get; set; }
        [ConcurrencyCheck]
        public DateTime? EndDateTradeUnion { get; set; }
        [ConcurrencyCheck]
        public string Note { get; set; }
        [ConcurrencyCheck]
        public DateTime DateAdded { get; set; }

        public virtual Education Education { get; set; }
        public virtual PositionEmployees PositionEmployees { get; set; }
        public virtual PrivilegeEmployees PrivilegeEmployees { get; set; }
        public virtual Scientific Scientific { get; set; }
        public virtual SocialActivityEmployees SocialActivityEmployees { get; set; }
        public virtual ICollection<ActivityEmployees> ActivityEmployees { get; set; }
        public virtual ICollection<ApartmentAccountingEmployees> ApartmentAccountingEmployees { get; set; }
        public virtual ICollection<AwardEmployees> AwardEmployees { get; set; }
        public virtual ICollection<Children> Children { get; set; }
        public virtual ICollection<CulturalEmployees> CulturalEmployees { get; set; }
        public virtual ICollection<EventEmployees> EventEmployees { get; set; }
        public virtual ICollection<Family> Family { get; set; }
        public virtual ICollection<FluorographyEmployees> FluorographyEmployees { get; set; }
        public virtual ICollection<GiftEmployees> GiftEmployees { get; set; }
        public virtual ICollection<GrandChildren> GrandChildren { get; set; }
        public virtual ICollection<HobbyEmployees> HobbyEmployees { get; set; }
        public virtual ICollection<MaterialAidEmployees> MaterialAidEmployees { get; set; }
        public virtual ICollection<PrivateHouseEmployees> PrivateHouseEmployees { get; set; }
        public virtual ICollection<PublicHouseEmployees> PublicHouseEmployees { get; set; }
    }
}
