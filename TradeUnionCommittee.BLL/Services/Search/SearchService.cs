﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeUnionCommittee.BLL.DTO;
using TradeUnionCommittee.BLL.Interfaces.Search;
using TradeUnionCommittee.BLL.Utilities;
using TradeUnionCommittee.Common.ActualResults;
using TradeUnionCommittee.DAL.Enums;
using TradeUnionCommittee.DAL.Interfaces;

namespace TradeUnionCommittee.BLL.Services.Search
{
    public class SearchService : ISearchService
    {
        private readonly IUnitOfWork _database;
        private readonly IHashIdUtilities _hashIdUtilities;

        public SearchService(IUnitOfWork database, IHashIdUtilities hashIdUtilities)
        {
            _database = database;
            _hashIdUtilities = hashIdUtilities;
        }

        //------------------------------------------------------------------------------------------------------------------------------------------

        public async Task<ActualResult<IEnumerable<ResultSearchDTO>>> SearchFullName(string fullName)
        {
            var ids = await _database.SearchRepository.SearchByFullName(fullName, TrigramSearch.Gist);
            if (!ids.Any()) return new ActualResult<IEnumerable<ResultSearchDTO>>();

            var listEmployee = new List<DAL.Entities.Employee>();

            foreach (var id in ids)
            {
                var employees = await _database
                    .EmployeeRepository
                    .Find(x => x.Id == id);
                listEmployee.Add(employees.Result.FirstOrDefault());
            }

            return new ActualResult<IEnumerable<ResultSearchDTO>> { Result = ResultFormation(listEmployee) };
        }

        //------------------------------------------------------------------------------------------------------------------------------------------

        public async Task<ActualResult<IEnumerable<ResultSearchDTO>>> SearchGender(string gender, string subdivision)
        {
            if (subdivision != null)
            {
                var idSubdivision = _hashIdUtilities.DecryptLong(subdivision, Enums.Services.Subdivision);

                var searchByGenderAndSubdivision = await _database
                    .EmployeeRepository
                    .GetWithInclude(x => x.Sex == gender &&
                                    x.PositionEmployees.IdSubdivisionNavigation.Id == idSubdivision ||
                                    x.PositionEmployees.IdSubdivisionNavigation.IdSubordinate == idSubdivision, 
                                    p => p.PositionEmployees.IdSubdivisionNavigation.InverseIdSubordinateNavigation);

                return new ActualResult<IEnumerable<ResultSearchDTO>> { Result = ResultFormation(searchByGenderAndSubdivision.Result) };
            }

            var searchByGender = await _database
                .EmployeeRepository
                .GetWithInclude(x => x.Sex == gender, p => p.PositionEmployees.IdSubdivisionNavigation.InverseIdSubordinateNavigation);

            return new ActualResult<IEnumerable<ResultSearchDTO>> {Result = ResultFormation(searchByGender.Result)};
        }

        //------------------------------------------------------------------------------------------------------------------------------------------

        public async Task<ActualResult<IEnumerable<ResultSearchDTO>>> SearchPosition(string position, string subdivision)
        {
            var idPosition =_hashIdUtilities.DecryptLong(position, Enums.Services.Position);

            if (subdivision != null)
            {
                var idSubdivision = _hashIdUtilities.DecryptLong(subdivision, Enums.Services.Subdivision);

                var searchByGenderAndSubdivision = await _database
                    .EmployeeRepository
                    .GetWithInclude(x => x.PositionEmployees.IdPosition == idPosition &&
                                         x.PositionEmployees.IdSubdivisionNavigation.Id == idSubdivision ||
                                         x.PositionEmployees.IdSubdivisionNavigation.IdSubordinate == idSubdivision,
                                    p => p.PositionEmployees.IdSubdivisionNavigation.InverseIdSubordinateNavigation);

                return new ActualResult<IEnumerable<ResultSearchDTO>> { Result = ResultFormation(searchByGenderAndSubdivision.Result) };
            }

            var searchByGender = await _database
                .EmployeeRepository
                .GetWithInclude(x => x.PositionEmployees.IdPosition == idPosition, 
                                p => p.PositionEmployees.IdSubdivisionNavigation.InverseIdSubordinateNavigation);

            return new ActualResult<IEnumerable<ResultSearchDTO>> { Result = ResultFormation(searchByGender.Result) };
        }

        //------------------------------------------------------------------------------------------------------------------------------------------

        public async Task<ActualResult<IEnumerable<ResultSearchDTO>>> SearchPrivilege(string privilege, string subdivision)
        {
            var idPrivilege = _hashIdUtilities.DecryptLong(privilege, Enums.Services.Privileges);

            if (subdivision != null)
            {
                var idSubdivision = _hashIdUtilities.DecryptLong(subdivision, Enums.Services.Subdivision);

                var searchByGenderAndSubdivision = await _database
                    .EmployeeRepository
                    .GetWithInclude(x => x.PrivilegeEmployees.IdPrivileges == idPrivilege &&
                                         x.PositionEmployees.IdSubdivisionNavigation.Id == idSubdivision ||
                                         x.PositionEmployees.IdSubdivisionNavigation.IdSubordinate == idSubdivision,
                                    p => p.PositionEmployees.IdSubdivisionNavigation.InverseIdSubordinateNavigation,
                                    p => p.PrivilegeEmployees);

                return new ActualResult<IEnumerable<ResultSearchDTO>> { Result = ResultFormation(searchByGenderAndSubdivision.Result) };
            }

            var searchByGender = await _database
                .EmployeeRepository
                .GetWithInclude(x => x.PrivilegeEmployees.IdPrivileges == idPrivilege,
                                p => p.PositionEmployees.IdSubdivisionNavigation.InverseIdSubordinateNavigation,
                                p => p.PrivilegeEmployees);

            return new ActualResult<IEnumerable<ResultSearchDTO>> { Result = ResultFormation(searchByGender.Result) };
        }

        //------------------------------------------------------------------------------------------------------------------------------------------

        
        public async Task<ActualResult<IEnumerable<ResultSearchDTO>>> SearchAccommodation(string typeAccommodation, string dormitory, string departmental)
        {
            switch (typeAccommodation)
            {
                case "dormitory":
                    var idDormitory = _hashIdUtilities.DecryptLong(dormitory, Enums.Services.Dormitory);
                    var searchByDormitory = await _database
                        .EmployeeRepository
                        .GetWithInclude(x => x.PublicHouseEmployees.Any(t => t.IdAddressPublicHouse == idDormitory),
                                        p => p.PositionEmployees.IdSubdivisionNavigation.InverseIdSubordinateNavigation,
                                        p => p.PublicHouseEmployees);
                    return new ActualResult<IEnumerable<ResultSearchDTO>> { Result = ResultFormation(searchByDormitory.Result) };
                case "departmental":
                    var idDepartmental = _hashIdUtilities.DecryptLong(departmental, Enums.Services.Departmental);
                    var searchByDepartmental = await _database
                        .EmployeeRepository
                        .GetWithInclude(x => x.PublicHouseEmployees.Any(t => t.IdAddressPublicHouse == idDepartmental),
                                        p => p.PositionEmployees.IdSubdivisionNavigation.InverseIdSubordinateNavigation,
                                        p => p.PublicHouseEmployees);
                    return new ActualResult<IEnumerable<ResultSearchDTO>> { Result = ResultFormation(searchByDepartmental.Result) };
                case "from-university":
                    var searchByFromUniversity = await _database
                        .EmployeeRepository
                        .GetWithInclude(x => x.PrivateHouseEmployees.Any(t => t.DateReceiving != null),
                                        p => p.PositionEmployees.IdSubdivisionNavigation.InverseIdSubordinateNavigation,
                                        p => p.PrivateHouseEmployees);
                    return new ActualResult<IEnumerable<ResultSearchDTO>> { Result = ResultFormation(searchByFromUniversity.Result) };
                default:
                    return new ActualResult<IEnumerable<ResultSearchDTO>>();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------
        
        public async Task<ActualResult<IEnumerable<ResultSearchDTO>>> SearchBirthDate(string typeBirthDate, DateTime startDate, DateTime endDate)
        {
            switch (typeBirthDate)
            {
                case "employeeBirthDate":
                    var searchByEmployeeBirthDate = await _database
                        .EmployeeRepository
                        .GetWithInclude(x => x.BirthDate >= startDate && x.BirthDate <= endDate,
                                        p => p.PositionEmployees.IdSubdivisionNavigation.InverseIdSubordinateNavigation);
                    return new ActualResult<IEnumerable<ResultSearchDTO>> { Result = ResultFormation(searchByEmployeeBirthDate.Result) };
                case "childrenBirthDate":
                    var searchByChildrenBirthDate = await _database
                        .EmployeeRepository
                        .GetWithInclude(x => x.Children.Any(t => t.BirthDate >= startDate && t.BirthDate <= endDate),
                                        p => p.PositionEmployees.IdSubdivisionNavigation.InverseIdSubordinateNavigation,
                                        p => p.Children);
                    return new ActualResult<IEnumerable<ResultSearchDTO>> { Result = ResultFormation(searchByChildrenBirthDate.Result) };
                case "grandChildrenBirthDate":
                    var searchByGrandChildrenBirthDate = await _database
                        .EmployeeRepository
                        .GetWithInclude(x => x.GrandChildren.Any(t => t.BirthDate >= startDate && t.BirthDate <= endDate),
                                        p => p.PositionEmployees.IdSubdivisionNavigation.InverseIdSubordinateNavigation,
                                        p => p.GrandChildren);
                    return new ActualResult<IEnumerable<ResultSearchDTO>> { Result = ResultFormation(searchByGrandChildrenBirthDate.Result) };
                default:
                    return new ActualResult<IEnumerable<ResultSearchDTO>>();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------
        
        public async Task<ActualResult<IEnumerable<ResultSearchDTO>>> SearchHobby(string typeHobby, string hobby)
        {
            var idHobby = _hashIdUtilities.DecryptLong(hobby, Enums.Services.Hobby);

            switch (typeHobby)
            {
                case "employeeHobby":
                    var searchByEmployeeHobby = await _database
                        .EmployeeRepository
                        .GetWithInclude(x => x.HobbyEmployees.Any(t => t.Id == idHobby),
                                        p => p.PositionEmployees.IdSubdivisionNavigation.InverseIdSubordinateNavigation,
                                        p => p.HobbyEmployees);
                    return new ActualResult<IEnumerable<ResultSearchDTO>> { Result = ResultFormation(searchByEmployeeHobby.Result) };
                case "childrenHobby":
                    var searchByChildrenHobby = await _database
                        .EmployeeRepository
                        .GetWithInclude(x => x.Children.Any(t => t.HobbyChildrens.Any(g => g.Id == idHobby)),
                                        p => p.PositionEmployees.IdSubdivisionNavigation.InverseIdSubordinateNavigation,
                                        p => p.Children);
                    return new ActualResult<IEnumerable<ResultSearchDTO>> { Result = ResultFormation(searchByChildrenHobby.Result) };
                case "grandChildrenHobby":
                    var searchByGrandChildrenHobby = await _database
                        .EmployeeRepository
                        .GetWithInclude(x => x.GrandChildren.Any(t => t.HobbyGrandChildrens.Any(g => g.Id == idHobby)),
                                        p => p.PositionEmployees.IdSubdivisionNavigation.InverseIdSubordinateNavigation,
                                        p => p.GrandChildren);
                    return new ActualResult<IEnumerable<ResultSearchDTO>> { Result = ResultFormation(searchByGrandChildrenHobby.Result) };
                default:
                    return new ActualResult<IEnumerable<ResultSearchDTO>>();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------

        private IEnumerable<ResultSearchDTO> ResultFormation(IEnumerable<DAL.Entities.Employee> employees)
        {
            var result = new List<ResultSearchDTO>();

            foreach (var employee in employees)
            {
                string mainSubdivision;
                string mainSubdivisionAbbreviation;

                string subordinateSubdivision = null;
                string subordinateSubdivisionAbbreviation = null;

                if (employee.PositionEmployees.IdSubdivisionNavigation.IdSubordinateNavigation != null)
                {
                    mainSubdivision = employee.PositionEmployees.IdSubdivisionNavigation.IdSubordinateNavigation.Name;
                    mainSubdivisionAbbreviation = employee.PositionEmployees.IdSubdivisionNavigation.IdSubordinateNavigation.Abbreviation;
                    subordinateSubdivision = employee.PositionEmployees.IdSubdivisionNavigation.Name;
                    subordinateSubdivisionAbbreviation = employee.PositionEmployees.IdSubdivisionNavigation.Abbreviation;
                }
                else
                {
                    if (employee.PositionEmployees.IdSubdivisionNavigation.IdSubordinate != null)
                    {
                        var subdivision = Task.Run(async() => await _database.SubdivisionsRepository.Get(employee.PositionEmployees.IdSubdivisionNavigation.IdSubordinate.Value));
                        mainSubdivision = subdivision.Result.Result.Name;
                        mainSubdivisionAbbreviation = subdivision.Result.Result.Abbreviation;
                        subordinateSubdivision = employee.PositionEmployees.IdSubdivisionNavigation.Name;
                        subordinateSubdivisionAbbreviation = employee.PositionEmployees.IdSubdivisionNavigation.Abbreviation;
                    }
                    else
                    {
                        mainSubdivision = employee.PositionEmployees.IdSubdivisionNavigation.Name;
                        mainSubdivisionAbbreviation = employee.PositionEmployees.IdSubdivisionNavigation.Abbreviation;
                    }
                }

                var patronymic = string.Empty;
                if (!string.IsNullOrEmpty(employee.Patronymic))
                {
                    patronymic = $"{employee.Patronymic[0]}.";
                }

                result.Add(new ResultSearchDTO
                {
                    IdUser = employee.Id,
                    FullName = $"{employee.FirstName} {employee.SecondName} {employee.Patronymic}",
                    SurnameAndInitials = $"{employee.FirstName} {employee.SecondName[0]}. {patronymic}",
                    BirthDate = employee.BirthDate,
                    MobilePhone = employee.MobilePhone,
                    CityPhone = employee.CityPhone,
                    MainSubdivision = mainSubdivision,
                    MainSubdivisionAbbreviation = mainSubdivisionAbbreviation,
                    SubordinateSubdivision = subordinateSubdivision,
                    SubordinateSubdivisionAbbreviation = subordinateSubdivisionAbbreviation
                });
            }
            return result;
        }

        //------------------------------------------------------------------------------------------------------------------------------------------

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}