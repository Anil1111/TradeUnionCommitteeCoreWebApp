﻿namespace TradeUnionCommittee.BLL.DTO
{
    public class EducationDTO
    {
        public long Id { get; set; }
        public long IdEmployee { get; set; }
        public string LevelEducation { get; set; }
        public string NameInstitution { get; set; }
        public int? YearReceiving { get; set; }
    }
}