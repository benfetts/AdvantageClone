using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;

namespace AdvantageFramework.Core.Database.Procedures
{
    public static class EmployeeView
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        //public static IEnumerable<AdvantageFramework.Core.Database.Core.Employee> LoadCore(Global.System.Data.Entity.Infrastructure.DbQuery Employees)
        //{
        //    IEnumerable<AdvantageFramework.Core.Database.Core.Employee> LoadCoreRet = default;
        //    try
        //    {
        //        LoadCoreRet = Employees.Select(Entity => new
        //        {
        //            Entity.Code,
        //            Entity.FirstName,
        //            Entity.LastName,
        //            Entity.MiddleInitial,
        //            Entity.TerminationDate
        //        }).Select(Entity => new AdvantageFramework.Core.Database.Core.Employee()
        //        {
        //            Code = Entity.Code,
        //            FirstName = Entity.FirstName,
        //            LastName = Entity.LastName,
        //            MiddleInitial = Entity.MiddleInitial,
        //            TerminationDate = Entity.TerminationDate
        //        }).ToList;
        //    }
        //    catch (Exception ex)
        //    {
        //        LoadCoreRet = null;
        //    }

        //    return LoadCoreRet;
        //}

        //public static IEnumerable<AdvantageFramework.Core.Database.Core.Employee> LoadCore(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    IEnumerable<AdvantageFramework.Core.Database.Core.Employee> LoadCoreRet = default;
        //    try
        //    {
        //        LoadCoreRet = LoadCore(Load(DbContext));
        //    }
        //    catch (Exception ex)
        //    {
        //        LoadCoreRet = null;
        //    }

        //    return LoadCoreRet;
        //}

        ///* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadActiveConceptShareEmployees(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Security.Session Session)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadActiveConceptShareEmployeesRet = default;
        //    LoadActiveConceptShareEmployeesRet = from Employee in LoadAllActiveWithOfficeLimits(Session, DbContext)
        //                                         where Employee.ConceptShareUserID is object && Employee.ConceptShareUserID > 0
        //                                         select Employee;
        //    return LoadActiveConceptShareEmployeesRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadByAlertAssignmentTemplateIDAndAlertStateID(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Security.Database.DbContext SecurityDbContext, string UserCode, int AlertAssignmentTemplateID, int AlertStateID)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadByAlertAssignmentTemplateIDAndAlertStateIDRet = default;
        //    string[] TemplateStateEmployeeCodes = null;
        //    try
        //    {
        //        TemplateStateEmployeeCodes = (from AlertAssignmentTemplateEmployee in AdvantageFramework.Core.Database.Procedures.AlertAssignmentTemplateEmployee.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext, AlertAssignmentTemplateID, AlertStateID)
        //                                      select AlertAssignmentTemplateEmployee.EmployeeCode).ToArray;
        //    }
        //    catch (Exception ex)
        //    {
        //        TemplateStateEmployeeCodes = null;
        //    }

        //    try
        //    {
        //        LoadByAlertAssignmentTemplateIDAndAlertStateIDRet = from Employee in LoadAllActiveEmployeesByUser(DbContext, SecurityDbContext, UserCode)
        //                                                            where TemplateStateEmployeeCodes.Any(TemplateStateEmployeeCode => TemplateStateEmployeeCode == Employee.Code)
        //                                                            select Employee;
        //    }
        //    catch (Exception ex)
        //    {
        //        LoadByAlertAssignmentTemplateIDAndAlertStateIDRet = default;
        //    }

        //    return LoadByAlertAssignmentTemplateIDAndAlertStateIDRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadWithOfficeLimits(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Security.Session Session)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadWithOfficeLimitsRet = default;
        //    LoadWithOfficeLimitsRet = LoadWithOfficeLimits(DbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes);
        //    return LoadWithOfficeLimitsRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadWithOfficeLimits(AdvantageFramework.Core.Database.DbContext DbContext, List<string> OfficeCodes, bool HasLimitedOfficeCodes)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadWithOfficeLimitsRet = default;
        //    LoadWithOfficeLimitsRet = LoadWithOfficeLimits(DbContext.Employees, OfficeCodes, HasLimitedOfficeCodes);
        //    return LoadWithOfficeLimitsRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadWithOfficeLimits(Global.System.Data.Entity.Infrastructure.DbQuery Employees, List<string> OfficeCodes, bool HasLimitedOfficeCodes)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadWithOfficeLimitsRet = default;
        //    LoadWithOfficeLimitsRet = LoadWithOfficeLimits(Employees, OfficeCodes, HasLimitedOfficeCodes, default);
        //    return LoadWithOfficeLimitsRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadWithOfficeLimits(Global.System.Data.Entity.Infrastructure.DbQuery Employees, List<string> OfficeCodes, bool HasLimitedOfficeCodes, string[] OfficeBypassedEmployeeCodes)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadWithOfficeLimitsRet = default;
        //    if (OfficeBypassedEmployeeCodes is null)
        //    {
        //        OfficeBypassedEmployeeCodes = new[] { "" };
        //    }

        //    LoadWithOfficeLimitsRet = from Employee in Employees
        //                              where HasLimitedOfficeCodes == false || OfficeCodes.Contains(Employee.OfficeCode) || OfficeBypassedEmployeeCodes.Contains(Employee.Code)
        //                              select Employee;
        //    return LoadWithOfficeLimitsRet;
        //}

        //public static IEnumerable<Database.Views.Employee> LoadWithOfficeLimits(IEnumerable<AdvantageFramework.Core.Database.Views.Employee> Employees, List<string> OfficeCodes, bool HasLimitedOfficeCodes, string[] OfficeBypassedEmployeeCodes)
        //{
        //    IEnumerable<Database.Views.Employee> LoadWithOfficeLimitsRet = default;
        //    if (OfficeBypassedEmployeeCodes is null)
        //    {
        //        OfficeBypassedEmployeeCodes = new[] { "" };
        //    }

        //    LoadWithOfficeLimitsRet = (IEnumerable<Database.Views.Employee>)(from Employee in Employees
        //                                                                     where HasLimitedOfficeCodes == false || OfficeCodes.Contains(Conversions.ToString(Employee.OfficeCode)) || OfficeBypassedEmployeeCodes.Contains(Conversions.ToString(Employee.Code))
        //                                                                     select Employee);
        //    return LoadWithOfficeLimitsRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadByUserCodeWithOfficeLimits(AdvantageFramework.Security.Session Session, AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Security.Database.DbContext SecurityDbContext, bool ForceCurrentEmployee = false)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadByUserCodeWithOfficeLimitsRet = default;
        //    LoadByUserCodeWithOfficeLimitsRet = LoadWithOfficeLimits(LoadAllEmployeesByUser(DbContext, SecurityDbContext, Session.UserCode), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes, new[] { ForceCurrentEmployee ? Session.User.EmployeeCode : "" });
        //    return LoadByUserCodeWithOfficeLimitsRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadAllEmployeesByUserWithOfficeLimits(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Security.Database.DbContext SecurityDbContext, AdvantageFramework.Security.Session Session)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadAllEmployeesByUserWithOfficeLimitsRet = default;
        //    LoadAllEmployeesByUserWithOfficeLimitsRet = LoadAllEmployeesByUserWithOfficeLimits(DbContext, SecurityDbContext, Session.UserCode, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes);
        //    return LoadAllEmployeesByUserWithOfficeLimitsRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadAllEmployeesByUserWithOfficeLimits(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Security.Database.DbContext SecurityDbContext, string UserCode, List<string> AccessibleOfficeCodes, bool HasLimitedOfficeCodes)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadAllEmployeesByUserWithOfficeLimitsRet = default;
        //    LoadAllEmployeesByUserWithOfficeLimitsRet = LoadWithOfficeLimits(LoadAllEmployeesByUser(DbContext, SecurityDbContext, UserCode), AccessibleOfficeCodes, HasLimitedOfficeCodes);
        //    return LoadAllEmployeesByUserWithOfficeLimitsRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveWithOfficeLimits(AdvantageFramework.Security.Session Session, AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveWithOfficeLimitsRet = default;
        //    LoadAllActiveWithOfficeLimitsRet = LoadWithOfficeLimits(LoadAllActive(DbContext), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes);
        //    return LoadAllActiveWithOfficeLimitsRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveByUserCodeWithOfficeLimitsAndIncludeCurrentUser(AdvantageFramework.Security.Session Session, AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Security.Database.DbContext SecurityDbContext)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveByUserCodeWithOfficeLimitsAndIncludeCurrentUserRet = default;
        //    LoadAllActiveByUserCodeWithOfficeLimitsAndIncludeCurrentUserRet = LoadWithOfficeLimits(LoadAllActiveEmployeesByUser(DbContext, SecurityDbContext, Session.UserCode), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes, new[] { Session.User.EmployeeCode });
        //    return LoadAllActiveByUserCodeWithOfficeLimitsAndIncludeCurrentUserRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadEmployeeVendorsByUser(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Security.Database.DbContext SecurityDbContext, string UserCode)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadEmployeeVendorsByUserRet = default;

        //    // objects
        //    string[] VendorEmployeeCodes = null;
        //    try
        //    {
        //        VendorEmployeeCodes = (from VendorEmployee in AdvantageFramework.Core.Database.Procedures.Vendor.LoadEmployeeVendors(DbContext)
        //                               select VendorEmployee.Code).ToArray;
        //    }
        //    catch (Exception ex)
        //    {
        //        VendorEmployeeCodes = null;
        //    }

        //    try
        //    {
        //        LoadEmployeeVendorsByUserRet = from Employee in LoadAllActiveEmployeesByUser(DbContext, SecurityDbContext, UserCode)
        //                                       where VendorEmployeeCodes.Any(VendorEmployeeCode => VendorEmployeeCode == Employee.EmployeeVendorCode)
        //                                       select Employee;
        //    }
        //    catch (Exception ex)
        //    {
        //        LoadEmployeeVendorsByUserRet = default;
        //    }

        //    return LoadEmployeeVendorsByUserRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveEmployeesByUser(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Security.Database.DbContext SecurityDbContext, string UserCode)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveEmployeesByUserRet = default;

        //    // objects
        //    List<string> UserEmployeeAccessList = null;
        //    try
        //    {
        //        UserEmployeeAccessList = AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(SecurityDbContext, UserCode).Select(Entity => Entity.EmployeeCode).ToList;
        //    }
        //    catch (Exception ex)
        //    {
        //        UserEmployeeAccessList = null;
        //    }

        //    if (UserEmployeeAccessList is object && UserEmployeeAccessList.Count > 0)
        //    {
        //        string ThisEmployeeCode = Conversions.ToString(DbContext.Database.SqlQuery<string>(string.Format("SELECT TOP 1 EMP_CODE FROM SEC_USER WITH(NOLOCK) WHERE UPPER(USER_CODE) = '{0}';", UserCode.ToUpper())).FirstOrDefault);
        //        if (string.IsNullOrWhiteSpace(ThisEmployeeCode) == false && UserEmployeeAccessList.Contains(ThisEmployeeCode) == false)
        //        {
        //            UserEmployeeAccessList.Add(ThisEmployeeCode);
        //        }

        //        LoadAllActiveEmployeesByUserRet = from Employee in LoadAllActive(DbContext)
        //                                          where UserEmployeeAccessList.Contains(Employee.Code) == true
        //                                          select Employee;
        //    }
        //    else
        //    {
        //        LoadAllActiveEmployeesByUserRet = from Employee in LoadAllActive(DbContext)
        //                                          select Employee;
        //    }

        //    return LoadAllActiveEmployeesByUserRet;
        //}

        //public static List<string> LoadAllActiveEmployeeCodesByUserOffice(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode)
        //{
        //    List<string> LoadAllActiveEmployeeCodesByUserOfficeRet = default;

        //    // objects
        //    List<string> UserOfficeAccessList = null;
        //    try
        //    {
        //        UserOfficeAccessList = AdvantageFramework.Core.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, EmployeeCode).Select(Entity => Entity.OfficeCode).ToList;
        //    }
        //    catch (Exception ex)
        //    {
        //        UserOfficeAccessList = null;
        //    }

        //    if (UserOfficeAccessList is object && UserOfficeAccessList.Count > 0)
        //    {
        //        LoadAllActiveEmployeeCodesByUserOfficeRet = (from Employee in LoadAllActive(DbContext)
        //                                                     where UserOfficeAccessList.Contains(Employee.OfficeCode) == true && Employee.TerminationDate is null
        //                                                     select Employee.Code).ToList;
        //    }
        //    else
        //    {
        //        LoadAllActiveEmployeeCodesByUserOfficeRet = (from Employee in LoadAllActive(DbContext)
        //                                                     where Employee.TerminationDate is null
        //                                                     select Employee.Code).ToList;
        //    }

        //    return LoadAllActiveEmployeeCodesByUserOfficeRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveEmployeesByUserOffice(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveEmployeesByUserOfficeRet = default;

        //    // objects
        //    List<string> UserOfficeAccessList = null;
        //    try
        //    {
        //        UserOfficeAccessList = AdvantageFramework.Core.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, EmployeeCode).Select(Entity => Entity.OfficeCode).ToList;
        //    }
        //    catch (Exception ex)
        //    {
        //        UserOfficeAccessList = null;
        //    }

        //    if (UserOfficeAccessList is object && UserOfficeAccessList.Count > 0)
        //    {
        //        LoadAllActiveEmployeesByUserOfficeRet = from Employee in LoadAllActive(DbContext)
        //                                                where UserOfficeAccessList.Contains(Employee.OfficeCode) == true && Employee.TerminationDate is null
        //                                                select Employee;
        //    }
        //    else
        //    {
        //        LoadAllActiveEmployeesByUserOfficeRet = from Employee in LoadAllActive(DbContext)
        //                                                where Employee.TerminationDate is null
        //                                                select Employee;
        //    }

        //    return LoadAllActiveEmployeesByUserOfficeRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveEmployeesByUserandOffice(AdvantageFramework.Security.Session Session, AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Security.Database.DbContext SecurityDbContext)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveEmployeesByUserandOfficeRet = default;
        //    LoadAllActiveEmployeesByUserandOfficeRet = LoadAllActiveEmployeesByUserandOffice(DbContext, SecurityDbContext, Session.UserCode, Session.User.EmployeeCode);
        //    return LoadAllActiveEmployeesByUserandOfficeRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveEmployeesByUserandOffice(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Security.Database.DbContext SecurityDbContext, string UserCode, string EmployeeCode)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveEmployeesByUserandOfficeRet = default;

        //    // objects
        //    List<string> UserEmployeeAccessList = null;
        //    List<string> UserOfficeAccessList = null;
        //    Global.System.Data.Entity.Infrastructure.DbQuery ResultQuery = default;
        //    try
        //    {
        //        UserEmployeeAccessList = AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(SecurityDbContext, UserCode).Select(Entity => Entity.EmployeeCode).ToList;
        //        UserOfficeAccessList = AdvantageFramework.Core.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, EmployeeCode).Select(Entity => Entity.OfficeCode).ToList;
        //    }
        //    catch (Exception ex)
        //    {
        //        UserEmployeeAccessList = null;
        //    }

        //    if (UserOfficeAccessList is object && UserOfficeAccessList.Count > 0)
        //    {
        //        ResultQuery = from Employee in LoadAllActive(DbContext)
        //                      where UserOfficeAccessList.Contains(Employee.OfficeCode) == true && Employee.TerminationDate is null
        //                      select Employee;
        //    }
        //    else
        //    {
        //        ResultQuery = from Employee in LoadAllActive(DbContext)
        //                      where Employee.TerminationDate is null
        //                      select Employee;
        //    }

        //    if (UserEmployeeAccessList is object && UserEmployeeAccessList.Count > 0)
        //    {
        //        ResultQuery = ResultQuery.Where(Emp => UserEmployeeAccessList.Contains(Conversions.ToString(Emp.Code)));
        //    }

        //    LoadAllActiveEmployeesByUserandOfficeRet = ResultQuery;
        //    return LoadAllActiveEmployeesByUserandOfficeRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadAllExpenseEmployees(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadAllExpenseEmployeesRet = default;
        //    LoadAllExpenseEmployeesRet = from Entity in Load(DbContext)
        //                                 join Vendor in Vendor.Load(DbContext) on Vendor.Code equals Entity.EmployeeVendorCode
        //                                 where Entity.EmployeeVendorCode is object && Entity.EmployeeVendorCode != ""
        //                                 select Entity;
        //    return LoadAllExpenseEmployeesRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveExpenseEmployees(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveExpenseEmployeesRet = default;
        //    LoadAllActiveExpenseEmployeesRet = from Entity in LoadAllActive(DbContext)
        //                                       join Vendor in Vendor.LoadAllActive(DbContext) on Vendor.Code equals Entity.EmployeeVendorCode
        //                                       where Entity.EmployeeVendorCode is object && Entity.EmployeeVendorCode != ""
        //                                       select Entity;
        //    return LoadAllActiveExpenseEmployeesRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadAllEmployeesByUser(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Security.Database.DbContext SecurityDbContext, string UserCode)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadAllEmployeesByUserRet = default;

        //    // objects
        //    List<string> UserEmployeeAccessList = null;
        //    try
        //    {
        //        UserEmployeeAccessList = AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(SecurityDbContext, UserCode).Select(Entity => Entity.EmployeeCode).ToList;
        //    }
        //    catch (Exception ex)
        //    {
        //        UserEmployeeAccessList = null;
        //    }

        //    if (UserEmployeeAccessList is object && UserEmployeeAccessList.Count > 0)
        //    {
        //        string ThisEmployeeCode = Conversions.ToString(DbContext.Database.SqlQuery<string>(string.Format("SELECT TOP 1 EMP_CODE FROM SEC_USER WITH(NOLOCK) WHERE UPPER(USER_CODE) = '{0}';", UserCode.ToUpper())).FirstOrDefault);
        //        if (string.IsNullOrWhiteSpace(ThisEmployeeCode) == false && UserEmployeeAccessList.Contains(ThisEmployeeCode) == false)
        //        {
        //            UserEmployeeAccessList.Add(ThisEmployeeCode);
        //        }

        //        LoadAllEmployeesByUserRet = from Employee in Load(DbContext)
        //                                    where UserEmployeeAccessList.Contains(Employee.Code) == true
        //                                    select Employee;
        //    }
        //    else
        //    {
        //        LoadAllEmployeesByUserRet = from Employee in Load(DbContext)
        //                                    select Employee;
        //    }

        //    return LoadAllEmployeesByUserRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveByOfficeCode(AdvantageFramework.Core.Database.DbContext DbContext, string OfficeCode)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveByOfficeCodeRet = default;
        //    LoadAllActiveByOfficeCodeRet = from Employee in LoadAllActive(DbContext)
        //                                   where Employee.OfficeCode == OfficeCode
        //                                   select Employee;
        //    return LoadAllActiveByOfficeCodeRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveByDepartmentTeamCode(AdvantageFramework.Core.Database.DbContext DbContext, string DepartmentTeamCode)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveByDepartmentTeamCodeRet = default;
        //    LoadAllActiveByDepartmentTeamCodeRet = from Employee in LoadAllActive(DbContext)
        //                                           join EmployeeDepartment in EmployeeDepartment.LoadByDepartmentTeamCode(DbContext, DepartmentTeamCode) on EmployeeDepartment.EmployeeCode equals Employee.Code
        //                                           select Employee;
        //    return LoadAllActiveByDepartmentTeamCodeRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveByRoleCode(AdvantageFramework.Core.Database.DbContext DbContext, string RoleCode)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveByRoleCodeRet = default;
        //    LoadAllActiveByRoleCodeRet = from Employee in LoadAllActive(DbContext)
        //                                 join EmployeeRole in EmployeeRole.LoadByRoleCode(DbContext, RoleCode) on EmployeeRole.EmployeeCode equals Employee.Code
        //                                 select Employee;
        //    return LoadAllActiveByRoleCodeRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveByAlertGroupCode(AdvantageFramework.Core.Database.DbContext DbContext, string AlertGroupCode)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveByAlertGroupCodeRet = default;
        //    LoadAllActiveByAlertGroupCodeRet = from Employee in LoadAllActive(DbContext)
        //                                       join AlertGroup in AlertGroup.LoadByAlertGroupCode(DbContext, AlertGroupCode) on AlertGroup.EmployeeCode equals Employee.Code
        //                                       select Employee;
        //    return LoadAllActiveByAlertGroupCodeRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActive(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadAllActiveRet = default;
        //    LoadAllActiveRet = from Employee in DbContext.GetQuery < Database.Views.Employee >
        //                       where Employee.TerminationDate is null
        //                       select Employee;
        //    return LoadAllActiveRet;
        //}

        //public static AdvantageFramework.Core.Database.Views.Employee LoadByEmployeeEmail(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeEmail)
        //{
        //    AdvantageFramework.Core.Database.Views.Employee LoadByEmployeeEmailRet = default;
        //    try
        //    {
        //        LoadByEmployeeEmailRet = (from Employee in DbContext.GetQuery < Database.Views.Employee >
        //                                  where Employee.Email == EmployeeEmail
        //                                  select Employee).FirstOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        LoadByEmployeeEmailRet = default;
        //    }

        //    return LoadByEmployeeEmailRet;
        //}

        //public static AdvantageFramework.Core.Database.Views.Employee LoadByConceptShareUserID(AdvantageFramework.Core.Database.DbContext DbContext, int ConceptShareUserID)
        //{
        //    AdvantageFramework.Core.Database.Views.Employee LoadByConceptShareUserIDRet = default;
        //    try
        //    {
        //        LoadByConceptShareUserIDRet = (from Employee in DbContext.GetQuery < Database.Views.Employee >
        //                                       where Employee.ConceptShareUserID == ConceptShareUserID
        //                                       select Employee).FirstOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        LoadByConceptShareUserIDRet = default;
        //    }

        //    return LoadByConceptShareUserIDRet;
        //}

        //public static AdvantageFramework.Core.Database.Views.Employee LoadByConceptShareEmployeeEmail(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeEmail)
        //{
        //    AdvantageFramework.Core.Database.Views.Employee LoadByConceptShareEmployeeEmailRet = default;
        //    try
        //    {
        //        LoadByConceptShareEmployeeEmailRet = (from Employee in DbContext.GetQuery < Database.Views.Employee >
        //                                              where Employee.Email == EmployeeEmail & Employee.ConceptShareUserID is object
        //                                              select Employee).FirstOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        LoadByConceptShareEmployeeEmailRet = default;
        //    }

        //    return LoadByConceptShareEmployeeEmailRet;
        //}

        public static AdvantageFramework.Core.Database.Views.Employee LoadByEmployeeCode(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode)
        {
            AdvantageFramework.Core.Database.Views.Employee LoadByEmployeeCodeRet = default;
            try
            {
                LoadByEmployeeCodeRet = (from Employee in DbContext.Employees.AsQueryable()
                                         where Employee.EmpCode == EmployeeCode
                                         select Employee).SingleOrDefault();
            }
            catch (Exception ex)
            {
                LoadByEmployeeCodeRet = default;
            }

            return LoadByEmployeeCodeRet;
        }

        //public static AdvantageFramework.Core.Database.Views.Employee LoadByUserCode(AdvantageFramework.Core.Database.DbContext DbContext, string UserCode)
        //{
        //    AdvantageFramework.Core.Database.Views.Employee LoadByUserCodeRet = default;
        //    try
        //    {
        //        string EmployeeCode = "";
        //        EmployeeCode = DbContext.Database.SqlQuery<string>(string.Format("SELECT TOP 1 EMP_CODE FROM SEC_USER WITH(NOLOCK) WHERE UPPER(USER_CODE) = '{0}' ORDER BY SEC_USER_ID DESC;", UserCode.ToUpper())).FirstOrDefault;
        //        LoadByUserCodeRet = (from Employee in DbContext.GetQuery < Database.Views.Employee >
        //                             where Employee.Code == EmployeeCode
        //                             select Employee).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        LoadByUserCodeRet = default;
        //    }

        //    return LoadByUserCodeRet;
        //}

        //public static string LoadUserCodeByEmployeeCode(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode)
        //{
        //    try
        //    {
        //        return DbContext.Database.SqlQuery<string>(string.Format("SELECT TOP 1 USER_CODE FROM SEC_USER WITH(NOLOCK) WHERE EMP_CODE = '{0}' ORDER BY SEC_USER_ID DESC;", EmployeeCode)).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        return string.Empty;
        //    }
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadBySupervisorEmployeeCode(AdvantageFramework.Core.Database.DbContext DbContext, string SupervisorEmployeeCode)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadBySupervisorEmployeeCodeRet = default;
        //    LoadBySupervisorEmployeeCodeRet = from Employee in DbContext.GetQuery < Database.Views.Employee >
        //                                      where Employee.SupervisorEmployeeCode == SupervisorEmployeeCode
        //                                      select Employee;
        //    return LoadBySupervisorEmployeeCodeRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadBySupervisorEmployeeCodewithOfficeLimits(AdvantageFramework.Core.Database.DbContext DbContext, string SupervisorEmployeeCode, AdvantageFramework.Security.Session Session)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadBySupervisorEmployeeCodewithOfficeLimitsRet = default;
        //    LoadBySupervisorEmployeeCodewithOfficeLimitsRet = from Employee in LoadAllActiveWithOfficeLimits(Session, DbContext)
        //                                                      where Employee.SupervisorEmployeeCode == SupervisorEmployeeCode
        //                                                      select Employee;
        //    return LoadBySupervisorEmployeeCodewithOfficeLimitsRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery Load(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadRet = default;
        //    LoadRet = from Employee in DbContext.GetQuery < Database.Views.Employee >
        //              select Employee;
        //    return LoadRet;
        //}

        //public static void ProcessPaidTimeOffAccruals(AdvantageFramework.Core.Database.DbContext DbContext, int Year, int Month, ref int ReturnValue)
        //{

        //    // objects
        //    System.Data.SqlClient.SqlParameter SqlParameterYear = null;
        //    System.Data.SqlClient.SqlParameter SqlParameterMonth = null;
        //    System.Data.SqlClient.SqlParameter SqlParameterReturnValue = null;
        //    System.Data.SqlClient.SqlParameter SqlParameterUserCode = null;
        //    SqlParameterUserCode = new System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar);
        //    SqlParameterUserCode.Value = DbContext.UserCode;
        //    SqlParameterYear = new System.Data.SqlClient.SqlParameter("@process_yr", SqlDbType.SmallInt);
        //    SqlParameterMonth = new System.Data.SqlClient.SqlParameter("@process_mo", SqlDbType.SmallInt);
        //    SqlParameterReturnValue = new System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.SmallInt);
        //    SqlParameterReturnValue.Direction = ParameterDirection.Output;
        //    SqlParameterYear.Value = Year;
        //    SqlParameterMonth.Value = Month;
        //    SqlParameterReturnValue.Value = 0;
        //    try
        //    {
        //        DbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_emp_time_rule_process @process_yr, @process_mo, @ret_val OUTPUT, @user_id", SqlParameterYear, SqlParameterMonth, SqlParameterReturnValue, SqlParameterUserCode);
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    ReturnValue = Conversions.ToInteger(SqlParameterReturnValue.Value);
        //}

        //public static bool Insert(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.DataContext DataContext, AdvantageFramework.Core.Database.Views.Employee Employee)
        //{
        //    bool InsertRet = default;

        //    // objects
        //    bool Inserted = false;
        //    bool Initialized = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    AdvantageFramework.Core.Database.Entities.SettingValue SettingValue = default;
        //    try
        //    {
        //        if (Initialize(DbContext, Employee))
        //        {
        //            Initialized = true;
        //            if (SaveEmployee(DbContext, Employee))
        //            {
        //                Inserted = true;
        //                try
        //                {
        //                    if (Employee.TerminationDate is null)
        //                    {
        //                        SettingValue = new AdvantageFramework.Core.Database.Entities.SettingValue();
        //                        SettingValue.DataContext = DataContext;
        //                        SettingValue.SettingCode = AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT.ToString;
        //                        SettingValue.DisplayText = Employee.FirstName + " " + (Employee.MiddleInitial != "" ? Employee.MiddleInitial + ". " : "") + Employee.LastName;
        //                        SettingValue.Value = Employee.Code;
        //                        AdvantageFramework.Core.Database.Procedures.SettingValue.Insert(DataContext, SettingValue);
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Inserted = false;
        //        ErrorText = "Failed trying to insert into the database. Please contact software support.";
        //    }
        //    finally
        //    {
        //        if (Initialized && Inserted == false)
        //        {
        //            Delete(DbContext, DataContext, Employee.Code);
        //        }

        //        if (!string.IsNullOrEmpty(ErrorText))
        //        {
        //            throw new Exception(ErrorText);
        //        }

        //        InsertRet = Inserted;
        //    }

        //    return InsertRet;
        //}

        //public static bool Initialize(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Views.Employee Employee)
        //{
        //    bool InitializeRet = default;
        //    bool Initialized = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    string InsertStatement = null;
        //    try
        //    {
        //        InsertStatement = string.Format("INSERT INTO dbo.EMPLOYEE (EMP_CODE, DP_TM_CODE, EMP_LNAME, EMP_FNAME, EMP_MI, IS_ACTIVE_FREELANCE, IGNORE_CALENDAR_SYNC) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6})", Employee.Code is object ? "'" + Employee.Code.Replace("'", "''") + "'" : "NULL", Employee.DepartmentTeamCode is object && Employee.DepartmentTeamCode != "" ? "'" + Employee.DepartmentTeamCode.Replace("'", "''") + "'" : "NULL", Employee.LastName is object ? "'" + Employee.LastName.Replace("'", "''") + "'" : "NULL", Employee.FirstName is object ? "'" + Employee.FirstName.Replace("'", "''") + "'" : "NULL", Employee.MiddleInitial is object ? "'" + Employee.MiddleInitial.Replace("'", "''") + "'" : "NULL", Employee.IsActiveFreelance ? 1 : 0, Employee.IgnoreCalendarSync ? 1 : 0);
        //        DbContext.Employees.Add(Employee);
        //        ErrorText = Employee.ValidateEntity(IsValid);
        //        if (IsValid)
        //        {
        //            if (DbContext.Database.ExecuteSqlCommand(InsertStatement) > 0)
        //            {
        //                Initialized = true;
        //            }
        //        }
        //        else
        //        {
        //            AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Initialized = false;
        //    }
        //    finally
        //    {
        //        InitializeRet = Initialized;
        //    }

        //    return InitializeRet;
        //}

        //public static bool UpdateDirectHours(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode, decimal DirectHours)
        //{
        //    bool UpdateDirectHoursRet = default;

        //    // objects
        //    bool Updated = false;
        //    try
        //    {
        //        DbContext.Database.ExecuteSqlCommand(string.Format("UPDATE dbo.EMPLOYEE SET DIRECT_HRS_PER = {0} WHERE EMP_CODE = '{1}'", DirectHours, EmployeeCode));
        //        Updated = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Updated = false;
        //    }

        //    UpdateDirectHoursRet = Updated;
        //    return UpdateDirectHoursRet;
        //}

        //public static bool UpdateDirectHours(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Views.Employee Employee, decimal DirectHours)
        //{
        //    bool UpdateDirectHoursRet = default;
        //    UpdateDirectHoursRet = UpdateDirectHours(DbContext, Employee.Code, DirectHours);
        //    return UpdateDirectHoursRet;
        //}

        //public static bool Update(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.DataContext DataContext, AdvantageFramework.Core.Database.Views.Employee Employee)
        //{
        //    bool UpdateRet = default;

        //    // objects
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    bool Updated = false;
        //    AdvantageFramework.Core.Database.Entities.SettingValue SettingValue = default;
        //    AdvantageFramework.Core.Database.Entities.Setting Setting = default;
        //    try
        //    {
        //        ErrorText = Employee.ValidateEntity(IsValid);
        //        if (IsValid)
        //        {
        //            if (SaveEmployee(DbContext, Employee))
        //            {
        //                Updated = true;
        //                try
        //                {
        //                    if (Employee.TerminationDate is object)
        //                    {
        //                        Setting = AdvantageFramework.Core.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT.ToString);
        //                        if (Setting is object)
        //                        {
        //                            if (Setting.Value != Employee.Code)
        //                            {
        //                                AdvantageFramework.Core.Database.Procedures.SettingValue.DeleteBySettingCodeAndLookupValue(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT.ToString, Employee.Code.Replace("'", "''"));
        //                            }
        //                        }
        //                    }
        //                    else if (AdvantageFramework.Core.Database.Procedures.SettingValue.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT.ToString).Any(Entity => Entity.Value.ToString == Employee.Code) == false)
        //                    {
        //                        SettingValue = new AdvantageFramework.Core.Database.Entities.SettingValue();
        //                        SettingValue.DataContext = DataContext;
        //                        SettingValue.SettingCode = AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT.ToString;
        //                        SettingValue.DisplayText = Employee.FirstName + " " + (Employee.MiddleInitial != "" ? Employee.MiddleInitial + ". " : "") + Employee.LastName;
        //                        SettingValue.Value = Employee.Code;
        //                        AdvantageFramework.Core.Database.Procedures.SettingValue.Insert(DataContext, SettingValue);
        //                    }
        //                    else
        //                    {
        //                        SettingValue = AdvantageFramework.Core.Database.Procedures.SettingValue.LoadBySettingCodeAndValue(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT.ToString, Employee.Code.ToString);
        //                        SettingValue.DisplayText = Employee.FirstName + " " + (Employee.MiddleInitial != "" ? Employee.MiddleInitial + ". " : "") + Employee.LastName;
        //                        AdvantageFramework.Core.Database.Procedures.SettingValue.Update(DataContext, SettingValue);
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Updated = false;
        //    }
        //    finally
        //    {
        //        UpdateRet = Updated;
        //    }

        //    return UpdateRet;
        //}

        //private static bool SaveEmployee(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Views.Employee Employee)
        //{
        //    bool SaveEmployeeRet = default;

        //    // objects
        //    string ErrorText = "";
        //    bool Saved = false;
        //    string UpdateStatement = null;
        //    UpdateStatement = string.Format(" UPDATE dbo.EMPLOYEE SET " + " EMP_ACCOUNT_NBR = {0}, " + " EMP_ADDRESS1 = {1}, " + " EMP_ADDRESS2 = {2}, " + " ALERT_EMAIL = {3}, " + " PO_GL_SELECTION = {4}, " + " EMP_PHONE_ALT = {5}, " + " STD_ANNUAL_HRS = {6}, " + " EMP_ANNUAL_SALARY = {7}, " + " EMP_BIRTH_DATE = {8}, " + " EMP_PHONE_CELL = {9}, " + " EMP_CITY = {10}, " + " EMP_COMMENT = {11}, " + " EMP_COST_RATE = {12}, " + " EMP_COUNTRY = {13}, " + " EMP_COUNTY = {14}, " + " CC_DESC = {15}, " + " CC_GL_ACCOUNT = {16}, " + " CC_NUMBER = {17}, " + " DP_TM_CODE = {18}, " + " DIRECT_HRS_PER = {19}, " + " EMP_EMAIL = {20}, " + " EMAIL_PWD = {21}, " + " EMAIL_USERNAME = {22}, " + " EMPLOYEE_TITLE_ID = {23}, " + " VN_CODE_EXP = {24}, " + " EMP_END_TIME = {25}, " + " EMP_FNAME = {26}, " + " FREELANCE = {27}, " + " FRI_HRS = {28}, " + " DEF_FNC_CODE = {29}, " + " MISSING_TIME = {30}, " + " EMP_LAST_INCREASE = {31}, " + " LAST_MODIFIED_BY = {32}, " + " LAST_MODIFIED_DATE = {33}, " + " EMP_LNAME = {34}, " + " PO_GL_LIMIT_BY_OFFICE = {35}, " + " EMP_MI = {36}, " + " MON_HRS = {37}, " + " MTH_HRS_GOAL = {38}, " + " EMP_MONTHLY_SALARY = {39}, " + " EMP_NEXT_REVIEW = {40}, " + " OFFICE_CODE = {41}, " + " EMP_PAY_TO_ADDR1 = {42}, " + " EMP_PAY_TO_ADDR2 = {43}, " + " EMP_PAY_TO_CITY = {44}, " + " EMP_PAY_TO_COUNTRY = {45}, " + " EMP_PAY_TO_COUNTY = {46}, " + " EMP_PAY_TO_STATE = {47}, " + " EMP_PAY_TO_ZIP = {48}, " + " PERS_HRS = {49}, " + " PERS_FROM_DATE = {50}, " + " PERS_TO_DATE = {51}, " + " EMP_PHONE = {52}, " + " PO_APPR_RULE_CODE = {53}, " + " PO_LIMIT = {54}, " + " EMAIL_REPLY_TO = {55}, " + " DEF_TRF_ROLE = {56}, " + " SAT_HRS = {57}, " + " SENIORITY = {58}, " + " SICK_FROM_DATE = {59}, " + " SICK_TO_DATE = {60}, " + " SICK_HRS = {61}, " + " SMTP_SERVER = {62}, " + " EMP_OTHER_INFO = {63}, " + " STD_WORK_HRS = {64}, " + " EMP_DATE = {65}, " + " EMP_START_TIME = {66}, " + " EMP_STATE = {67}, " + " STATUS = {68}, " + " SUN_HRS = {69}, " + " EXP_APPR_REQ = {70}, " + " SUPERVISOR_CODE = {71}, " + " EMP_TERM_DATE = {72}, " + " THU_HRS = {73}, " + " EMP_TIME_ALERT = {74}, " + " TUE_HRS = {75}, " + " VAC_FROM_DATE = {76}, " + " VAC_TO_DATE = {77}, " + " VAC_HRS = {78}, " + " WED_HRS = {79}, " + " WEEKLY_TIME = {80}, " + " EMP_WORK_DAYS = {81}, " + " EMP_PHONE_WORK = {82}, " + " EMP_PHONE_WORK_EXT = {83}, " + " EMP_ZIP = {84}, " + " EXP_RPT_APPROVER = {85}, " + " ALT_COST_RATE = {86}, " + " ALT_DATE_FRM = {87}, " + " ALT_DATE_TO = {88}, " + " EMP_END_TIME_FRI = {89}, " + " EMP_START_TIME_FRI = {90}, " + " EMP_END_TIME_MON = {91}, " + " EMP_START_TIME_MON = {92}, " + " PERS_TIME_RULE_ID = {93}, " + " SICK_TIME_RULE_ID  = {94}, " + " VAC_TIME_RULE_ID = {95}, " + " EMP_END_TIME_SAT = {96}, " + " EMP_START_TIME_SAT = {97}, " + " EMP_END_TIME_SUN = {98}, " + " EMP_START_TIME_SUN = {99}, " + " EMP_END_TIME_THU = {100}, " + " EMP_START_TIME_THU = {101}, " + " EMP_END_TIME_TUE = {102}, " + " EMP_START_TIME_TUE = {103}, " + " EMP_END_TIME_WED = {104}, " + " EMP_START_TIME_WED = {105}, " + " SIGNATURE_PATH = {106}, " + " EMP_CODE = {107}, " + " TS_APPR_FLAG = {108}, " + " IS_ACTIVE_FREELANCE = {109}, " + " SUGAR_USERNAME = {110}, " + " SUGAR_PASSWORD = {111}, " + " PROOFHQ_USERNAME = {112}, " + " PROOFHQ_PASSWORD = {113}, " + " IS_API_USER = {114}, " + " ADOBE_SIGNATURE_FILE_PASSWORD = {115}, " + " VCC_USERNAME = {116}, " + " VCC_PASSWORD = {117}, " + " EMP_OMIT_MISSING = {118}, " + " IGNORE_CALENDAR_SYNC = {119}, " + " CAL_TIME_TYPE = {120}, " + " CAL_TIME_EMAIL = {121}, " + " CAL_TIME_USERNAME = {122}, " + " CAL_TIME_PASSWORD = {123}, " + " CAL_TIME_HOST = {124}, " + " CAL_TIME_PORT = {125}, " + " CAL_TIME_SSL = {126} " + " WHERE EMP_CODE  = {127}", Employee.AccountNumber is object && Employee.AccountNumber != "" ? "'" + Employee.AccountNumber.Replace("'", "''") + "'" : "NULL", Employee.Address is object && Employee.Address != "" ? "'" + Employee.Address.Replace("'", "''") + "'" : "NULL", Employee.Address2 is object && Employee.Address2 != "" ? "'" + Employee.Address2.Replace("'", "''") + "'" : "NULL", Employee.AlertNotificationType is object ? Employee.AlertNotificationType.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.AllowPOGLSelection is object ? Employee.AllowPOGLSelection.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.AlternatePhoneNumber is object && Employee.AlternatePhoneNumber != "" ? "'" + Employee.AlternatePhoneNumber.Replace("'", "''") + "'" : "NULL", Employee.AnnualHours is object ? Employee.AnnualHours.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.AnnualSalary is object ? Employee.AnnualSalary.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.BirthDate is object ? "'" + Employee.BirthDate.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.CellPhoneNumber is object && Employee.CellPhoneNumber != "" ? "'" + Employee.CellPhoneNumber.Replace("'", "''") + "'" : "NULL", Employee.City is object && Employee.City != "" ? "'" + Employee.City.Replace("'", "''") + "'" : "NULL", Employee.Comments is object && Employee.Comments != "" ? "'" + Employee.Comments.Replace("'", "''") + "'" : "NULL", Employee.CostRate is object ? Employee.CostRate.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.Country is object && Employee.Country != "" ? "'" + Employee.Country.Replace("'", "''") + "'" : "NULL", Employee.County is object && Employee.County != "" ? "'" + Employee.County.Replace("'", "''") + "'" : "NULL", Employee.CreditCardDescription is object && Employee.CreditCardDescription != "" ? "'" + Employee.CreditCardDescription.Replace("'", "''") + "'" : "NULL", Employee.CreditCardGLAccount is object && Employee.CreditCardGLAccount != "" ? "'" + Employee.CreditCardGLAccount.Replace("'", "''") + "'" : "NULL", Employee.CreditCardNumber is object && Employee.CreditCardNumber != "" ? "'" + Employee.CreditCardNumber.Replace("'", "''") + "'" : "NULL", Employee.DepartmentTeamCode is object && Employee.DepartmentTeamCode != "" ? "'" + Employee.DepartmentTeamCode.Replace("'", "''") + "'" : "NULL", Employee.DirectHours is object ? Employee.DirectHours.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.Email is object && Employee.Email != "" ? "'" + Employee.Email.Replace("'", "''") + "'" : "NULL", Employee.EmailPassword is object && Employee.EmailPassword != "" ? "'" + Employee.EmailPassword.Replace("'", "''") + "'" : "NULL", Employee.EmailUserName is object && Employee.EmailUserName != "" ? "'" + Employee.EmailUserName.Replace("'", "''") + "'" : "NULL", Employee.EmployeeTitleID is object ? Employee.EmployeeTitleID.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.EmployeeVendorCode is object && Employee.EmployeeVendorCode != "" ? "'" + Employee.EmployeeVendorCode.Replace("'", "''") + "'" : "NULL", Employee.EndTime is object ? "'" + Employee.EndTime.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.FirstName is object && Employee.FirstName != "" ? "'" + Employee.FirstName.Replace("'", "''") + "'" : "NULL", Employee.Freelance is object ? Employee.Freelance.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.FridayHours is object ? Employee.FridayHours.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.FunctionCode is object && Employee.FunctionCode != "" ? "'" + Employee.FunctionCode.Replace("'", "''") + "'" : "NULL", Employee.IsMissingTime is object ? Employee.IsMissingTime.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.LastIncrease is object ? "'" + Employee.LastIncrease.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.LastModifiedByUserCode is object && Employee.LastModifiedByUserCode != "" ? "'" + Employee.LastModifiedByUserCode.Replace("'", "''") + "'" : "NULL", Employee.LastModifiedDate is object ? "'" + Employee.LastModifiedDate.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.LastName is object && Employee.LastName != "" ? "'" + Employee.LastName.Replace("'", "''") + "'" : "NULL", Employee.LimitPOGLSelectionOffice is object ? Employee.LimitPOGLSelectionOffice.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.MiddleInitial is object && Employee.MiddleInitial != "" ? "'" + Employee.MiddleInitial.Replace("'", "''") + "'" : "NULL", Employee.MondayHours is object ? Employee.MondayHours.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.MonthHoursGoal is object ? Employee.MonthHoursGoal.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.MonthlySalary is object ? Employee.MonthlySalary.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.NextReview is object ? "'" + Employee.NextReview.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.OfficeCode is object && Employee.OfficeCode != "" ? "'" + Employee.OfficeCode.Replace("'", "''") + "'" : "NULL", Employee.PayToAddress is object && Employee.PayToAddress != "" ? "'" + Employee.PayToAddress.Replace("'", "''") + "'" : "NULL", Employee.PayToAddress2 is object && Employee.PayToAddress2 != "" ? "'" + Employee.PayToAddress2.Replace("'", "''") + "'" : "NULL", Employee.PayToCity is object && Employee.PayToCity != "" ? "'" + Employee.PayToCity.Replace("'", "''") + "'" : "NULL", Employee.PayToCountry is object && Employee.PayToCountry != "" ? "'" + Employee.PayToCountry.Replace("'", "''") + "'" : "NULL", Employee.PayToCounty is object && Employee.PayToCounty != "" ? "'" + Employee.PayToCounty.Replace("'", "''") + "'" : "NULL", Employee.PayToState is object && Employee.PayToState != "" ? "'" + Employee.PayToState.Replace("'", "''") + "'" : "NULL", Employee.PayToZip is object && Employee.PayToZip != "" ? "'" + Employee.PayToZip.Replace("'", "''") + "'" : "NULL", Employee.PersonalHours is object ? Employee.PersonalHours.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.PersonalHoursDateFrom is object ? "'" + Employee.PersonalHoursDateFrom.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.PersonalHoursDateTo is object ? "'" + Employee.PersonalHoursDateTo.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.PhoneNumber is object && Employee.PhoneNumber != "" ? "'" + Employee.PhoneNumber.Replace("'", "''") + "'" : "NULL", Employee.PurchaseOrderApprovalRuleCode is object && Employee.PurchaseOrderApprovalRuleCode != "" ? "'" + Employee.PurchaseOrderApprovalRuleCode.Replace("'", "''") + "'" : "NULL", Employee.PurchaseOrderLimit is object ? Employee.PurchaseOrderLimit.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.ReplyToEmail is object && Employee.ReplyToEmail != "" ? "'" + Employee.ReplyToEmail.Replace("'", "''") + "'" : "NULL", Employee.RoleCode is object && Employee.RoleCode != "" ? "'" + Employee.RoleCode.Replace("'", "''") + "'" : "NULL", Employee.SaturdayHours is object ? Employee.SaturdayHours.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.Seniority is object ? Employee.Seniority.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.SickDateFrom is object ? "'" + Employee.SickDateFrom.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.SickDateTo is object ? "'" + Employee.SickDateTo.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.SickHours is object ? Employee.SickHours.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.SMTPServer is object && Employee.SMTPServer != "" ? "'" + Employee.SMTPServer.Replace("'", "''") + "'" : "NULL", Employee.OtherInfo is object && Employee.OtherInfo != "" ? "'" + Employee.OtherInfo.Replace("'", "''") + "'" : "NULL", Employee.StandardWorkHours is object ? Employee.StandardWorkHours.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.StartDate is object ? "'" + Employee.StartDate.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.StartTime is object ? "'" + Employee.StartTime.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.State is object && Employee.State != "" ? "'" + Employee.State.Replace("'", "''") + "'" : "NULL", Employee.Status is object ? Employee.Status.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.SundayHours is object ? Employee.SundayHours.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.SupervisorApprovalRequired is object ? Employee.SupervisorApprovalRequired.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.SupervisorEmployeeCode is object && Employee.SupervisorEmployeeCode != "" ? "'" + Employee.SupervisorEmployeeCode.Replace("'", "''") + "'" : "NULL", Employee.TerminationDate is object ? "'" + Employee.TerminationDate.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.ThursdayHours is object ? Employee.ThursdayHours.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.TimeAlert is object ? Employee.TimeAlert.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.TuesdayHours is object ? Employee.TuesdayHours.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.VacationDateFrom is object ? "'" + Employee.VacationDateFrom.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.VacationDateTo is object ? "'" + Employee.VacationDateTo.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.VacationHours is object ? Employee.VacationHours.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.WednesdayHours is object ? Employee.WednesdayHours.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.WeeklyTimeType is object ? Employee.WeeklyTimeType.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.WorkDays is object && Employee.WorkDays != "" ? "'" + Employee.WorkDays.Replace("'", "''") + "'" : "NULL", Employee.WorkPhoneNumber is object && Employee.WorkPhoneNumber != "" ? "'" + Employee.WorkPhoneNumber.Replace("'", "''") + "'" : "NULL", Employee.WorkPhoneNumberExtension is object && Employee.WorkPhoneNumberExtension != "" ? "'" + Employee.WorkPhoneNumberExtension.Replace("'", "''") + "'" : "NULL", Employee.Zip is object && Employee.Zip != "" ? "'" + Employee.Zip.Replace("'", "''") + "'" : "NULL", Employee.AlternateApproverCode is object && Employee.AlternateApproverCode != "" ? "'" + Employee.AlternateApproverCode.Replace("'", "''") + "'" : "NULL", Employee.AlternateCostRate is object ? Employee.AlternateCostRate.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.AlternateDateFrom is object ? "'" + Employee.AlternateDateFrom.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.AlternateDateTo is object ? "'" + Employee.AlternateDateTo.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.FridayEndTime is object ? "'" + Employee.FridayEndTime.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.FridayStartTime is object ? "'" + Employee.FridayStartTime.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.MondayEndTime is object ? "'" + Employee.MondayEndTime.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.MondayStartTime is object ? "'" + Employee.MondayStartTime.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.PersonalTimeRule is object ? Employee.PersonalTimeRule.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.SickTimeRule is object ? Employee.SickTimeRule.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.VacationTimeRule is object ? Employee.VacationTimeRule.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.SaturdayEndTime is object ? "'" + Employee.SaturdayEndTime.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.SaturdayStartTime is object ? "'" + Employee.SaturdayStartTime.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.SundayEndTime is object ? "'" + Employee.SundayEndTime.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.SundayStartTime is object ? "'" + Employee.SundayStartTime.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.ThursdayEndTime is object ? "'" + Employee.ThursdayEndTime.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.ThursdayStartTime is object ? "'" + Employee.ThursdayStartTime.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.TuesdayEndTime is object ? "'" + Employee.TuesdayEndTime.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.TuesdayStartTime is object ? "'" + Employee.TuesdayStartTime.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.WednesdayEndTime is object ? "'" + Employee.WednesdayEndTime.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.WednesdayStartTime is object ? "'" + Employee.WednesdayStartTime.Value.ToString(CultureInfo.InvariantCulture) + "'" : "NULL", Employee.SignaturePath is object && Employee.SignaturePath != "" ? "'" + Employee.SignaturePath.Replace("'", "''") + "'" : "NULL", Employee.Code is object ? "'" + Employee.Code.Replace("'", "''") + "'" : "NULL", Employee.TimesheetApprovalFlag.HasValue ? (object)(Employee.TimesheetApprovalFlag.Value ? 1 : 0) : "NULL", Information.IsNothing(Employee.IsActiveFreelance) == false ? (short)(Employee.IsActiveFreelance ? 1 : 0) : (short)0, Employee.SugarCRMUserName is object ? "'" + Employee.SugarCRMUserName + "'" : "NULL", Employee.SugarCRMPassword is object ? "'" + Employee.SugarCRMPassword + "'" : "NULL", Employee.ProofHQUserName is object ? "'" + Employee.ProofHQUserName + "'" : "NULL", Employee.ProofHQPassword is object ? "'" + Employee.ProofHQPassword + "'" : "NULL", Employee.IsAPIUser is object ? "'" + Employee.IsAPIUser + "'" : "NULL", Employee.AdobeSignatureFilePassword is object ? "'" + Employee.AdobeSignatureFilePassword + "'" : "NULL", Employee.VCCUserName is object ? "'" + Employee.VCCUserName + "'" : "NULL", Employee.VCCPassword is object ? "'" + Employee.VCCPassword + "'" : "NULL", Employee.OmitFromMissingTimeTracking is object ? Employee.OmitFromMissingTimeTracking.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.IgnoreCalendarSync ? 1 : 0, Employee.CalendarTimeType.HasValue ? Employee.CalendarTimeType.Value : "NULL", Employee.CalendarTimeEmailAddress is object && Employee.CalendarTimeEmailAddress != "" ? "'" + Employee.CalendarTimeEmailAddress.Replace("'", "''") + "'" : "NULL", Employee.CalendarTimeUserName is object && Employee.CalendarTimeUserName != "" ? "'" + Employee.CalendarTimeUserName.Replace("'", "''") + "'" : "NULL", Employee.CalendarTimePassword is object && Employee.CalendarTimePassword != "" ? "'" + Employee.CalendarTimePassword.Replace("'", "''") + "'" : "NULL", Employee.CalendarTimeHost is object && Employee.CalendarTimeHost != "" ? "'" + Employee.CalendarTimeHost.Replace("'", "''") + "'" : "NULL", Employee.CalendarTimePort is object ? Employee.CalendarTimePort.Value.ToString(CultureInfo.InvariantCulture) : "NULL", Employee.CalendarTimeSSL ? 1 : 0, "'" + Employee.Code.Replace("'", "''") + "'");
        //    try
        //    {
        //        if (DbContext.Database.ExecuteSqlCommand(UpdateStatement) > 0)
        //        {
        //            try
        //            {
        //                if (Employee.SignatureImage is object)
        //                {
        //                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.EMPLOYEE SET [EMP_SIG] = {0} WHERE [EMP_CODE] = {1}", Employee.SignatureImage, Employee.Code.Replace("'", "''"));
        //                }
        //                else
        //                {
        //                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.EMPLOYEE SET [EMP_SIG] = NULL WHERE [EMP_CODE] = {0}", Employee.Code.Replace("'", "''"));
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //            }

        //            try
        //            {
        //                if (Employee.AdobeSignatureFile is object)
        //                {
        //                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.EMPLOYEE SET [ADOBE_SIGNATURE_FILE] = {0} WHERE [EMP_CODE] = {1}", Employee.AdobeSignatureFile, Employee.Code.Replace("'", "''"));
        //                }
        //                else
        //                {
        //                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.EMPLOYEE SET [ADOBE_SIGNATURE_FILE] = NULL WHERE [EMP_CODE] = {0}", Employee.Code.Replace("'", "''"));
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //            }

        //            Saved = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Saved = false;
        //    }
        //    finally
        //    {
        //        SaveEmployeeRet = Saved;
        //    }

        //    return SaveEmployeeRet;
        //}

        //public static bool Delete(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.DataContext DataContext, string EmployeeCode)
        //{
        //    bool DeleteRet = default;

        //    // objects
        //    bool Deleted = false;
        //    try
        //    {
        //        if (DbContext.Database.ExecuteSqlCommand(string.Format("EXEC dbo.advsp_delete_employee '{0}', 0", EmployeeCode.Replace("'", "''"))) > 0)
        //        {
        //            Deleted = true;
        //            foreach (AdvantageFramework.Core.Database.Entities.EmployeeDepartment EmployeeDepartment in AdvantageFramework.Core.Database.Procedures.EmployeeDepartment.LoadByEmployeeCode(DbContext, EmployeeCode).ToList)
        //            {
        //                try
        //                {
        //                    DbContext.DeleteEntityObject(EmployeeDepartment);
        //                }
        //                catch (Exception ex)
        //                {
        //                }
        //            }

        //            foreach (AdvantageFramework.Core.Database.Entities.EmployeeRole EmployeeRole in AdvantageFramework.Core.Database.Procedures.EmployeeRole.LoadByEmployeeCode(DbContext, EmployeeCode).ToList)
        //            {
        //                try
        //                {
        //                    DbContext.DeleteEntityObject(EmployeeRole);
        //                }
        //                catch (Exception ex)
        //                {
        //                }
        //            }

        //            foreach (AdvantageFramework.Core.Database.Entities.AlertGroup AlertGroup in AdvantageFramework.Core.Database.Procedures.AlertGroup.LoadByEmployeeCode(DbContext, EmployeeCode).ToList)
        //            {
        //                try
        //                {
        //                    DbContext.DeleteEntityObject(AlertGroup);
        //                }
        //                catch (Exception ex)
        //                {
        //                }
        //            }

        //            try
        //            {
        //                DbContext.SaveChanges();
        //            }
        //            catch (Exception ex)
        //            {
        //            }

        //            try
        //            {
        //                AdvantageFramework.Core.Database.Procedures.SettingValue.DeleteBySettingCodeAndLookupValue(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT.ToString, EmployeeCode.Replace("'", "''"));
        //            }
        //            catch (Exception ex)
        //            {
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Deleted = false;
        //    }

        //    DeleteRet = Deleted;
        //    return DeleteRet;
        //}

        //public static bool Terminate(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.DataContext DataContext, AdvantageFramework.Core.Database.Views.Employee Employee, bool RemoveSecuritySettings, ref string ErrorText)
        //{
        //    bool TerminateRet = default;

        //    // objects
        //    bool Terminated = false;
        //    List<string> SercuritySettingsQueries = null;
        //    List<string> MediaBuyerQueries = null;
        //    bool IsValid = true;
        //    try
        //    {
        //        ErrorText = Employee.ValidateEntity(IsValid);
        //        if (IsValid)
        //        {
        //            if (SaveEmployee(DbContext, Employee))
        //            {
        //                if (RemoveSecuritySettings)
        //                {
        //                    SercuritySettingsQueries = new List<string>();
        //                    SercuritySettingsQueries.Add(string.Format("DELETE FROM dbo.WV_USER_TABS WHERE USERID IN (SELECT USER_CODE FROM dbo.SEC_USER WHERE EMP_CODE ='{0}')", Employee.Code.Replace("'", "''")));
        //                    SercuritySettingsQueries.Add(string.Format("UPDATE dbo.EMPLOYEE_CLOAK SET WV_TMPLT_HDR_ID = NULL WHERE EMP_CODE = '{0}'", Employee.Code.Replace("'", "''")));
        //                    SercuritySettingsQueries.Add(string.Format("DELETE FROM dbo.APPR_PASSWORD WHERE ACCT_EXEC = '{0}'", Employee.Code.Replace("'", "''")));
        //                    SercuritySettingsQueries.Add(string.Format("DELETE FROM dbo.QTE_APP_PWD WHERE EMP_CODE = '{0}'", Employee.Code.Replace("'", "''")));
        //                    SercuritySettingsQueries.Add(string.Format("DELETE FROM dbo.EMAIL_GROUP WHERE EMP_CODE = '{0}'", Employee.Code.Replace("'", "''")));
        //                    SercuritySettingsQueries.Add(string.Format("DELETE FROM dbo.EMP_TRAFFIC_ROLE WHERE EMP_CODE = '{0}'", Employee.Code.Replace("'", "''")));
        //                    SercuritySettingsQueries.Add(string.Format("DELETE FROM dbo.EMP_TS_FNC WHERE EMP_CODE = '{0}'", Employee.Code.Replace("'", "''")));
        //                    SercuritySettingsQueries.Add(string.Format("DELETE FROM dbo.EMP_OFFICE WHERE EMP_CODE = '{0}'", Employee.Code.Replace("'", "''")));
        //                    SercuritySettingsQueries.Add(string.Format("DELETE FROM dbo.SEC_GROUP_USER WHERE SEC_USER_ID IN (SELECT SEC_USER_ID FROM dbo.SEC_USER WHERE EMP_CODE ='{0}')", Employee.Code.Replace("'", "''")));
        //                    SercuritySettingsQueries.Add(string.Format("UPDATE dbo.SEC_USER_SETTING SET STRING_VALUE = NULL WHERE SEC_USER_ID IN ( SELECT SEC_USER_ID FROM dbo.SEC_USER WHERE EMP_CODE ='{0}')", Employee.Code.Replace("'", "''")));
        //                    SercuritySettingsQueries.Add(string.Format("UPDATE dbo.SEC_USER SET IS_INACTIVE = 1 WHERE EMP_CODE = '{0}'", Employee.Code.Replace("'", "''")));
        //                    SercuritySettingsQueries.Add(string.Format("UPDATE dbo.SEC_USER SET [PASSWORD] = '' WHERE EMP_CODE = '{0}'", Employee.Code.Replace("'", "''")));
        //                    foreach (var SecuritySettingsQuery in SercuritySettingsQueries.OfType<string>())
        //                    {
        //                        try
        //                        {
        //                            DbContext.Database.ExecuteSqlCommand(SecuritySettingsQuery);
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                        }
        //                    }
        //                }

        //                MediaBuyerQueries = new List<string>();
        //                MediaBuyerQueries.Add(string.Format("UPDATE dbo.MEDIA_BUYER SET IS_INACTIVE = 1 WHERE EMP_CODE = '{0}'", Employee.Code.Replace("'", "''")));
        //                foreach (var MediaBuyerQuery in MediaBuyerQueries.OfType<string>())
        //                {
        //                    try
        //                    {
        //                        DbContext.Database.ExecuteSqlCommand(MediaBuyerQuery);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                    }
        //                }

        //                Terminated = true;
        //                try
        //                {
        //                    AdvantageFramework.Core.Database.Procedures.SettingValue.DeleteBySettingCodeAndLookupValue(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT.ToString, Employee.Code.Replace("'", "''"));
        //                }
        //                catch (Exception ex)
        //                {
        //                }
        //            }
        //            else
        //            {
        //                ErrorText = "Failed saving employee data.";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Terminated = false;
        //        ErrorText = ex.Message;
        //    }

        //    TerminateRet = Terminated;
        //    return TerminateRet;
        //}
    }
}
