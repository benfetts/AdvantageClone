using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvantageFramework.Core.EmployeeUtilities
{
    public static partial class Methods
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
        //public static bool ImportEmployeeFromImportEmployeeStaging(AdvantageFramework.Core.Database.DbContext DbContext, int ImportEmployeeStagingID, string CreatedByUserCode, bool IsUpdating)
        //{
        //    bool ImportEmployeeFromImportEmployeeStagingRet = default;
        //    ImportEmployeeFromImportEmployeeStagingRet = DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_import_employee_from_staging] {0}, {1}, {2}", ImportEmployeeStagingID, CreatedByUserCode, Interaction.IIf(IsUpdating, 1, 0));
        //    return ImportEmployeeFromImportEmployeeStagingRet;
        //}

        public static string LoadEmailWithEmployeeName(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode)
        {
            string LoadEmailWithEmployeeNameRet = default;
            // objects
            string EmailWithEmployeeName = "";
            try
            {
                if (string.IsNullOrWhiteSpace(EmployeeCode) == false)
                {
                    /* TODO ERROR: */
                    //EmailWithEmployeeName = DbContext.Database.SqlQuery<string>("EXEC [dbo].[usp_wv_Employee_GetFromAddress] {0}", EmployeeCode).FirstOrDefault.ToString();
                }
            }
            catch (Exception ex)
            {
                EmailWithEmployeeName = "";
            }
            finally
            {
                LoadEmailWithEmployeeNameRet = EmailWithEmployeeName;
            }

            return LoadEmailWithEmployeeNameRet;
        }

        public static string LoadEmailWithEmployeeName(AdvantageFramework.Core.Database.Views.Employee Employee, string Email)
        {
            string LoadEmailWithEmployeeNameRet = default;

            // objects
            string EmailWithEmployeeName = "";
            try
            {
                if (Employee is object)
                {
                    EmailWithEmployeeName = AdvantageFramework.Core.Email.Methods.LoadEmailWithName(Employee.ToString(), Email);
                }
            }
            catch (Exception ex)
            {
                EmailWithEmployeeName = "";
            }
            finally
            {
                LoadEmailWithEmployeeNameRet = EmailWithEmployeeName;
            }

            return LoadEmailWithEmployeeNameRet;
        }

        public static string LoadEmailWithEmployeeName(AdvantageFramework.Core.Database.Views.Employee Employee)
        {
            string LoadEmailWithEmployeeNameRet = default;

            // objects
            string EmailWithEmployeeName = "";
            try
            {
                if (Employee is object)
                {
                    EmailWithEmployeeName = LoadEmailWithEmployeeName(Employee, Employee.EmpEmail);
                }
            }
            catch (Exception ex)
            {
                EmailWithEmployeeName = "";
            }
            finally
            {
                LoadEmailWithEmployeeNameRet = EmailWithEmployeeName;
            }

            return LoadEmailWithEmployeeNameRet;
        }

        //public static decimal LoadTotalRequiredHours(List<AdvantageFramework.Core.Database.Entities.EmployeeStandardHoursDetail> EmployeeStandardHoursDetailList, string EmployeeCode)
        //{
        //    decimal LoadTotalRequiredHoursRet = default;

        //    // objects
        //    decimal TotalRequiredHours = 0m;
        //    try
        //    {
        //        if (EmployeeStandardHoursDetailList is object)
        //        {
        //            TotalRequiredHours = EmployeeStandardHoursDetailList.Where(Entity => Operators.ConditionalCompareObjectEqual(Entity.EmployeeCode, EmployeeCode, false)).Sum(EmployeeStandardHoursDetail => EmployeeStandardHoursDetail.StandardHours);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TotalRequiredHours = 0m;
        //    }
        //    finally
        //    {
        //        LoadTotalRequiredHoursRet = TotalRequiredHours;
        //    }

        //    return LoadTotalRequiredHoursRet;
        //}

        //public static decimal LoadTotalRequiredHours(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode)
        //{
        //    decimal LoadTotalRequiredHoursRet = default;

        //    // objects
        //    decimal TotalRequiredHours = 0m;
        //    try
        //    {
        //        if (DbContext is object)
        //        {
        //            TotalRequiredHours = LoadTotalRequiredHours(AdvantageFramework.Core.Database.Procedures.EmployeeStandardHoursDetail.LoadByUserCodeAndEmployeeCode(DbContext, DbContext.UserCode, EmployeeCode).ToList, EmployeeCode);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TotalRequiredHours = 0m;
        //    }
        //    finally
        //    {
        //        LoadTotalRequiredHoursRet = TotalRequiredHours;
        //    }

        //    return LoadTotalRequiredHoursRet;
        //}

        //public static bool CreateEmployeeStandardHours(AdvantageFramework.Core.Database.DbContext DbContext, DateTime StartDate, DateTime EndDate)
        //{
        //    bool CreateEmployeeStandardHoursRet = default;

        //    // objects
        //    bool EmployeeStandardHoursCreated = false;
        //    try
        //    {
        //        if (DbContext is object)
        //        {
        //            if (AdvantageFramework.Core.Database.Procedures.EmployeeStandardHours.DeleteByUserCode(DbContext, DbContext.UserCode))
        //            {
        //                EmployeeStandardHoursCreated = AdvantageFramework.Core.Database.Procedures.EmployeeStandardHours.Insert(DbContext, DbContext.UserCode, DateAndTime.Now, StartDate, EndDate, default);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        EmployeeStandardHoursCreated = false;
        //    }
        //    finally
        //    {
        //        CreateEmployeeStandardHoursRet = EmployeeStandardHoursCreated;
        //    }

        //    return CreateEmployeeStandardHoursRet;
        //}

        //public static int LoadTotalWeeklyHours(AdvantageFramework.Core.Database.Views.Employee Employee)
        //{
        //    int LoadTotalWeeklyHoursRet = default;

        //    // objects
        //    decimal TotalWeeklyHours = 0m;
        //    string[] WorkDays = null;
        //    try
        //    {
        //        if (Employee is object && string.IsNullOrWhiteSpace(Employee.WorkDays) == false && Employee.WorkDays.Contains(","))
        //        {
        //            WorkDays = Employee.WorkDays.Split(",");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WorkDays = new string[] { };
        //    }

        //    try
        //    {
        //        if (Employee is object)
        //        {
        //            if (WorkDays.Where(WorkDay => WorkDay == AdvantageFramework.DateUtilities.Days.Monday.ToString.Substring(0, 3)).Any)
        //            {
        //                TotalWeeklyHours += Employee.MonHrs.GetValueOrDefault(0);
        //            }

        //            if (WorkDays.Where(WorkDay => WorkDay == AdvantageFramework.DateUtilities.Days.Tuesday.ToString.Substring(0, 3)).Any)
        //            {
        //                TotalWeeklyHours += Employee.TueHrs.GetValueOrDefault(0);
        //            }

        //            if (WorkDays.Where(WorkDay => WorkDay == AdvantageFramework.DateUtilities.Days.Wednesday.ToString.Substring(0, 3)).Any)
        //            {
        //                TotalWeeklyHours += Employee.WedHrs.GetValueOrDefault(0);
        //            }

        //            if (WorkDays.Where(WorkDay => WorkDay == AdvantageFramework.DateUtilities.Days.Thursday.ToString.Substring(0, 3)).Any)
        //            {
        //                TotalWeeklyHours += Employee.ThuHrs.GetValueOrDefault(0);
        //            }

        //            if (WorkDays.Where(WorkDay => WorkDay == AdvantageFramework.DateUtilities.Days.Friday.ToString.Substring(0, 3)).Any)
        //            {
        //                TotalWeeklyHours += Employee.FriHrs.GetValueOrDefault(0);
        //            }

        //            if (WorkDays.Where(WorkDay => WorkDay == AdvantageFramework.DateUtilities.Days.Saturday.ToString.Substring(0, 3)).Any)
        //            {
        //                TotalWeeklyHours += Employee.SatHrs.GetValueOrDefault(0);
        //            }

        //            if (WorkDays.Where(WorkDay => WorkDay == AdvantageFramework.DateUtilities.Days.Sunday.ToString.Substring(0, 3)).Any)
        //            {
        //                TotalWeeklyHours += Employee.SunHrs.GetValueOrDefault(0);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TotalWeeklyHours = 0m;
        //    }
        //    finally
        //    {
        //        LoadTotalWeeklyHoursRet = (int)Math.Round(TotalWeeklyHours);
        //    }

        //    return LoadTotalWeeklyHoursRet;
        //}

        public static decimal LoadTotalHoursWorked(AdvantageFramework.Core.Database.Views.Employee Employee, DateTime StartDate, DateTime EndDate)
        {
            decimal LoadTotalHoursWorkedRet = default;

            // objects
            decimal TotalHoursWorked = 0m;
            DateTime Date = default;
            int Monday = 0;
            int Tuesday = 0;
            int Wednesday = 0;
            int Thursday = 0;
            int Friday = 0;
            int Saturday = 0;
            int Sunday = 0;
            try
            {
                Date = StartDate;
                for (int Days = 0, loopTo = EndDate.Subtract(StartDate).Days; Days <= loopTo; Days++)
                {
                    if (Date <= EndDate)
                    {
                        if (Date.DayOfWeek == DayOfWeek.Monday)
                        {
                            Monday += 1;
                            Date = Date.AddDays(1d);
                        }
                        else if (Date.DayOfWeek == DayOfWeek.Tuesday)
                        {
                            Tuesday += 1;
                            Date = Date.AddDays(1d);
                        }
                        else if (Date.DayOfWeek == DayOfWeek.Wednesday)
                        {
                            Wednesday += 1;
                            Date = Date.AddDays(1d);
                        }
                        else if (Date.DayOfWeek == DayOfWeek.Thursday)
                        {
                            Thursday += 1;
                            Date = Date.AddDays(1d);
                        }
                        else if (Date.DayOfWeek == DayOfWeek.Friday)
                        {
                            Friday += 1;
                            Date = Date.AddDays(1d);
                        }
                        else if (Date.DayOfWeek == DayOfWeek.Saturday)
                        {
                            Saturday += 1;
                            Date = Date.AddDays(1d);
                        }
                        else if (Date.DayOfWeek == DayOfWeek.Sunday)
                        {
                            Sunday += 1;
                            Date = Date.AddDays(1d);
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (Employee.MonHrs.GetValueOrDefault(0) != 0)
                {
                    TotalHoursWorked += (decimal)Employee.MonHrs * Monday;
                }

                if (Employee.TueHrs.GetValueOrDefault(0) != 0)
                {
                    TotalHoursWorked += (decimal)Employee.TueHrs * Tuesday;
                }

                if (Employee.WedHrs.GetValueOrDefault(0) != 0)
                {
                    TotalHoursWorked += (decimal)Employee.WedHrs * Wednesday;
                }

                if (Employee.ThuHrs.GetValueOrDefault(0) != 0)
                {
                    TotalHoursWorked += (decimal)Employee.ThuHrs * Thursday;
                }

                if (Employee.FriHrs.GetValueOrDefault(0) != 0)
                {
                    TotalHoursWorked += (decimal)Employee.FriHrs * Friday;
                }

                if (Employee.SatHrs.GetValueOrDefault(0) != 0)
                {
                    TotalHoursWorked += (decimal)Employee.SatHrs * Saturday;
                }

                if (Employee.SunHrs.GetValueOrDefault(0) != 0)
                {
                    TotalHoursWorked += (decimal)Employee.SunHrs * Sunday;
                }
            }
            catch (Exception ex)
            {
                TotalHoursWorked = 0m;
            }
            finally
            {
                LoadTotalHoursWorkedRet = TotalHoursWorked;
            }

            return LoadTotalHoursWorkedRet;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                }
            }
