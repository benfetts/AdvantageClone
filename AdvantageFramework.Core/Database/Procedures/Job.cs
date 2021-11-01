using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdvantageFramework.Core.Database.Procedures
{
    public static partial class Job
    {
        #region  Constants 



        #endregion

        #region  Enum 



        #endregion

        #region  Variables 



        #endregion

        #region  Properties 



        #endregion

        #region  Methods 

        #region   Core Entities 

        public static IEnumerable<AdvantageFramework.Core.Database.Core.Job> LoadCore(System.Linq.IQueryable<Database.Entities.Job> Jobs)
        {
            IEnumerable<AdvantageFramework.Core.Database.Core.Job> LoadCoreRet = default;
            try
            {
                LoadCoreRet = Jobs.Select(Entity => new
                {
                    Entity.JobNumber,
                    Entity.OfficeCode,
                    Entity.ClCode,
                    Entity.DivCode,
                    Entity.PrdCode,
                    Entity.JobDesc,
                    Entity.CompOpen
                }).Select(Entity => new AdvantageFramework.Core.Database.Core.Job()
                {
                    Number = Entity.JobNumber,
                    OfficeCode = Entity.OfficeCode,
                    ClientCode = Entity.ClCode,
                    DivisionCode = Entity.DivCode,
                    ProductCode = Entity.PrdCode,
                    Description = Entity.JobDesc,
                    IsOpen = Entity.CompOpen

                }).ToList();
            }
            catch (Exception)
            {
                LoadCoreRet = null;
            }

            return LoadCoreRet;
        }

        public static IEnumerable<AdvantageFramework.Core.Database.Core.Job> LoadCore(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            IEnumerable<AdvantageFramework.Core.Database.Core.Job> LoadCoreRet = default;
            try
            {
                LoadCoreRet = LoadCore(Load(DbContext));
            }
            catch (Exception ex)
            {
                LoadCoreRet = null;
            }

            return LoadCoreRet;
        }

        #endregion

        public static System.Linq.IQueryable<Database.Entities.Job> LoadAllOpenByClientCode(Database.DbContext DbContext, string ClientCode)
        {
            System.Linq.IQueryable<Database.Entities.Job> LoadAllOpenByClientCodeRet = default;

            LoadAllOpenByClientCodeRet = from Job in LoadAllOpen(DbContext)
                                         where Job.ClCode == ClientCode
                                         select Job;
            return LoadAllOpenByClientCodeRet;
        }

//        public static Global.System.Data.Entity.Infrastructure.DbQuery LoadByUserForEmployeeCode(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Security.Database.DbContext SecurityDbContext, string UserCode, string EmployeeCode, bool OpenByJobProcessNumberOnly)
//        {
//            Global.System.Data.Entity.Infrastructure.DbQuery LoadByUserForEmployeeCodeRet = default;
//            int[] ExcludedJobProcessControlNumbers = null;
//            List<AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess> UserClientDivisionProductAccessList = null;
//            string[] EmployeeUserCodes = null;
//            int[] JobNumbers = null;
//            ExcludedJobProcessControlNumbers = new int[] { 2, 5, 7, 10, 11, 6, 12 };
//            try
//            {
//                try
//                {
//                    ;
//#error Cannot convert AssignmentStatementSyntax - see comment for details
//                    /* Cannot convert ParenthesizedExpressionSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.CSharp.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax'.
//                       at ICSharpCode.CodeConverter.CSharp.CommentConvertingVisitorWrapper.ConvertHandledAsync[T](SyntaxNode vbNode, SourceTriviaMapKind sourceTriviaMap) in D:\GitWorkspace\CodeConverter\CodeConverter\CSharp\CommentConvertingVisitorWrapper.cs:line 47

//                    Input: (From Entity In AdvantageFramework.Security.Database.Procedures.User.LoadByEmployeeCode(SecurityDbContext, EmployeeCode)
//                                                             Select [UC] = Entity.UserCode)
//                    Context:

//                                        EmployeeUserCodes = (From Entity In AdvantageFramework.Security.Database.Procedures.User.LoadByEmployeeCode(SecurityDbContext, EmployeeCode)
//                                                             Select [UC] = Entity.UserCode).ToArray

//                     */
//                }
//                catch (Exception ex)
//                {
//                    EmployeeUserCodes = null;
//                }

//                if (EmployeeUserCodes is object)
//                {
//                    if (EmployeeUserCodes.Contains(UserCode))
//                    {
//                        EmployeeUserCodes = new[] { UserCode };
//                    }

//                    try
//                    {
//                        UserClientDivisionProductAccessList = (from Entity in AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Load(SecurityDbContext)
//                                                               where EmployeeUserCodes.Contains(Entity.UserCode)
//                                                               select Entity).ToList;
//                    }
//                    catch (Exception ex)
//                    {
//                        UserClientDivisionProductAccessList = null;
//                    }
//                }

//                JobNumbers = (from Entity in AdvantageFramework.Core.Database.Procedures.JobComponent.Load(DbContext)
//                              where ExcludedJobProcessControlNumbers.Contains(Entity.JobProcessNumber) == false || ExcludedJobProcessControlNumbers.Contains(Entity.JobProcessNumber) == (OpenByJobProcessNumberOnly == false ? true : false)
//                              select Entity.JobNumber).Distinct.ToArray;
//                if (UserClientDivisionProductAccessList is object && UserClientDivisionProductAccessList.Count > 0)
//                {
//                    JobNumbers = (from Entity in (from Job in LoadAllOpen(DbContext)
//                                                  select new
//                                                  {
//                                                      Job.ClientCode,
//                                                      Job.DivisionCode,
//                                                      Job.ProductCode,
//                                                      Job.Number
//                                                  }).ToList
//                                  where UserClientDivisionProductAccessList.Any(UserAccess => Operators.ConditionalCompareObjectEqual(UserAccess.ClientCode, Entity.ClientCode, false) && Operators.ConditionalCompareObjectEqual(UserAccess.DivisionCode, Entity.DivisionCode, false) && Operators.ConditionalCompareObjectEqual(UserAccess.ProductCode, Entity.ProductCode, false)) && JobNumbers.Contains(Entity.Number)
//                                  select Entity.Number).ToArray;
//                }

//                LoadByUserForEmployeeCodeRet = from Job in LoadAllOpen(DbContext)
//                                               where JobNumbers.Contains(Job.Number)
//                                               select Job;
//            }
//            catch (Exception ex)
//            {
//                LoadByUserForEmployeeCodeRet = default;
//            }

//            return LoadByUserForEmployeeCodeRet;
//        }

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadByUserCode(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Security.Database.DbContext SecurityDbContext, string UserCode)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadByUserCodeRet = default;
        //    List<AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess> UserClientDivisionProductAccess = null;
        //    int[] JobNumbers = null;
        //    string SQL = "";
        //    try
        //    {
        //        UserClientDivisionProductAccess = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, UserCode).ToList;
        //        if (UserClientDivisionProductAccess.Count > 0)
        //        {
        //            SQL = string.Format("SELECT JOB_NUMBER FROM dbo.JOB_LOG JL " + "JOIN dbo.SEC_CLIENT SC ON SC.CL_CODE = JL.CL_CODE AND SC.DIV_CODE = JL.DIV_CODE AND SC.PRD_CODE = JL.PRD_CODE " + "WHERE SC.[USER_ID] = '{0}'", UserCode);
        //            try
        //            {
        //                JobNumbers = DbContext.Database.SqlQuery<int>(SQL).ToArray;
        //            }
        //            catch (Exception ex)
        //            {
        //                JobNumbers = null;
        //            }

        //            LoadByUserCodeRet = from Job in DbContext.Jobs.AsQueryable()
        //                                where JobNumbers.Contains(Job.Number)
        //                                select Job;
        //        }
        //        else
        //        {
        //            LoadByUserCodeRet = Load(DbContext);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LoadByUserCodeRet = default;
        //    }

        //    return LoadByUserCodeRet;
        //}

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadOpenByUserCode(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Security.Database.DbContext SecurityDbContext, string UserCode)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadOpenByUserCodeRet = default;
        //    List<AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess> UserClientDivisionProductAccess = null;
        //    int[] JobNumbers = null;
        //    string SQL = "";
        //    try
        //    {
        //        UserClientDivisionProductAccess = AdvantageFramework.Core.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, UserCode).ToList;
        //        if (UserClientDivisionProductAccess.Count > 0)
        //        {
        //            SQL = string.Format("SELECT JOB_NUMBER FROM dbo.JOB_LOG JL " + "JOIN dbo.SEC_CLIENT SC ON SC.CL_CODE = JL.CL_CODE AND SC.DIV_CODE = JL.DIV_CODE AND SC.PRD_CODE = JL.PRD_CODE " + "WHERE SC.[USER_ID] = '{0}'", UserCode);
        //            try
        //            {
        //                JobNumbers = DbContext.Database.SqlQuery<int>(SQL).ToArray;
        //            }
        //            catch (Exception ex)
        //            {
        //                JobNumbers = null;
        //            }

        //            LoadOpenByUserCodeRet = from Job in LoadAllOpen(DbContext)
        //                                    where JobNumbers.Contains(Job.JobNumber)
        //                                    select Job;
        //        }
        //        else
        //        {
        //            LoadOpenByUserCodeRet = LoadAllOpen(DbContext);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LoadOpenByUserCodeRet = default;
        //    }

        //    return LoadOpenByUserCodeRet;
        //}

        public static System.Linq.IQueryable<Database.Entities.Job> LoadByClientCode(Database.DbContext DbContext, string ClientCode)
        {
            System.Linq.IQueryable<Database.Entities.Job> LoadByClientCodeRet = default;
            LoadByClientCodeRet = from Job in DbContext.Jobs.AsQueryable()
                                  where Job.ClCode == ClientCode
                                  select Job;
            return LoadByClientCodeRet;
        }

        public static System.Linq.IQueryable<Database.Entities.Job> LoadByClientAndDivisionCode(Database.DbContext DbContext, string ClientCode, string DivisionCode)
        {
            System.Linq.IQueryable<Database.Entities.Job> LoadByClientAndDivisionCodeRet = default;
            LoadByClientAndDivisionCodeRet = from Job in DbContext.Jobs.AsQueryable()
                                             where Job.ClCode == ClientCode && Job.DivCode == DivisionCode
                                             select Job;
            return LoadByClientAndDivisionCodeRet;
        }

        public static System.Linq.IQueryable<Database.Entities.Job> LoadByClientAndDivisionAndProductCode(Database.DbContext DbContext, string ClientCode, string DivisionCode, string ProductCode)
        {
            System.Linq.IQueryable<Database.Entities.Job> LoadByClientAndDivisionAndProductCodeRet = default;
            LoadByClientAndDivisionAndProductCodeRet = from Job in DbContext.Jobs.AsQueryable()
                                                       where Job.ClCode == ClientCode && Job.DivCode == DivisionCode && Job.PrdCode == ProductCode
                                                       select Job;
            return LoadByClientAndDivisionAndProductCodeRet;
        }

        public static System.Linq.IQueryable<Database.Entities.Job> LoadByOfficeCode(AdvantageFramework.Core.Database.DbContext DbContext, string OfficeCode)
        {
            System.Linq.IQueryable<Database.Entities.Job> LoadByOfficeCodeRet = default;
            LoadByOfficeCodeRet = from Job in DbContext.Jobs.AsQueryable()
                                  where Job.OfficeCode == OfficeCode
                                  select Job;
            return LoadByOfficeCodeRet;
        }

        public static AdvantageFramework.Core.Database.Entities.Job LoadByJobID(AdvantageFramework.Core.Database.DbContext DbContext, int JobID)
        {
            AdvantageFramework.Core.Database.Entities.Job LoadByJobIDRet = default;
            try
            {
                LoadByJobIDRet = (from Job in DbContext.Jobs.AsQueryable()
                                  where Job.Rowid == JobID
                                  select Job).SingleOrDefault();
            }
            catch (Exception )
            {
                LoadByJobIDRet = default;
            }

            return LoadByJobIDRet;
        }

        public static AdvantageFramework.Core.Database.Entities.Job LoadByJobNumber(AdvantageFramework.Core.Database.DbContext DbContext, int JobNumber)
        {
            AdvantageFramework.Core.Database.Entities.Job LoadByJobNumberRet = default;
            try
            {
                LoadByJobNumberRet = (from Job in DbContext.Jobs.AsQueryable()
                                      where Job.JobNumber == JobNumber
                                      select Job).SingleOrDefault();
            }
            catch (Exception )
            {
                LoadByJobNumberRet = default;
            }

            return LoadByJobNumberRet;
        }

        public static System.Linq.IQueryable<Database.Entities.Job> LoadBySalesClassAndFormatCode(AdvantageFramework.Core.Database.DbContext DbContext, string SalesClassCode, string SalesClassFormatCode)
        {
            System.Linq.IQueryable<Database.Entities.Job> LoadBySalesClassAndFormatCodeRet = default;
            try
            {
                LoadBySalesClassAndFormatCodeRet = (from Job in DbContext.Jobs.AsQueryable()
                                                    where Job.ScCode == SalesClassCode && Job.FormatScCode == SalesClassFormatCode
                                                    select Job);
            }
            catch (Exception )
            {
                LoadBySalesClassAndFormatCodeRet = default;
            }

            return LoadBySalesClassAndFormatCodeRet;
        }

        public static System.Linq.IQueryable<Database.Entities.Job> LoadAllOpen(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            System.Linq.IQueryable<Database.Entities.Job> LoadAllOpenRet = default;
            LoadAllOpenRet = from Job in DbContext.Jobs.AsQueryable()
                             where Job.CompOpen == 1
                             select Job;
            return LoadAllOpenRet;
        }

        public static Microsoft.EntityFrameworkCore.DbSet<Database.Entities.Job> Load(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            return DbContext.Jobs;
        }

        //public static bool Update(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Job Job)
        //{
        //    bool UpdateRet = default;

        //    // objects
        //    bool Updated = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {
        //        DbContext.UpdateObject(Job);
        //        ErrorText = Job.ValidateEntity(IsValid);
        //        if (IsValid)
        //        {
        //            DbContext.SaveChanges();
        //            Updated = true;
        //        }
        //        else
        //        {
        //            //AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
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

        //public static bool ClearUserDefinedValue(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.UserDefinedLabelTables UserDefinedLabelTable)
        //{
        //    bool ClearUserDefinedValueRet = default;

        //    // objects
        //    bool UserDefinedValueCleared = false;
        //    try
        //    {
        //        if (UserDefinedLabelTable == AdvantageFramework.Core.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV1)
        //        {
        //            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.JOB_LOG SET UDV1_CODE = NULL");
        //        }
        //        else if (UserDefinedLabelTable == AdvantageFramework.Core.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV2)
        //        {
        //            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.JOB_LOG SET UDV2_CODE = NULL");
        //        }
        //        else if (UserDefinedLabelTable == AdvantageFramework.Core.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV3)
        //        {
        //            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.JOB_LOG SET UDV3_CODE = NULL");
        //        }
        //        else if (UserDefinedLabelTable == AdvantageFramework.Core.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV4)
        //        {
        //            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.JOB_LOG SET UDV4_CODE = NULL");
        //        }
        //        else if (UserDefinedLabelTable == AdvantageFramework.Core.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV5)
        //        {
        //            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.JOB_LOG SET UDV5_CODE = NULL");
        //        }

        //        UserDefinedValueCleared = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        UserDefinedValueCleared = false;
        //    }
        //    finally
        //    {
        //        ClearUserDefinedValueRet = UserDefinedValueCleared;
        //    }

        //    return ClearUserDefinedValueRet;
        //}

        #endregion
    }
}
