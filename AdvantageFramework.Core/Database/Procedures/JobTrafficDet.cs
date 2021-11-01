using System;
using System.Linq;

namespace AdvantageFramework.Core.Database.Procedures
{
    public static partial class JobTrafficDet
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

        public static System.Linq.IQueryable<Entities.JobTrafficDet> LoadByEmployeeCode(Database.DbContext DbContext, string EmployeeCode)
        {
            System.Linq.IQueryable<Entities.JobTrafficDet> LoadByEmployeeCodeRet = default;
            LoadByEmployeeCodeRet = from JobComponentTask in DbContext.JobTrafficDet.AsQueryable()
                                    where JobComponentTask.EmpCode == EmployeeCode
                                    select JobComponentTask;
            return LoadByEmployeeCodeRet;
        }

        //public static Global.System.Data.Entity.Infrastructure.DbQuery LoadByJobNumberAndJobComponentNumberComplete(Database.DbContext DbContext, int JobNumber, short JobComponentNumber)
        //{
        //    Global.System.Data.Entity.Infrastructure.DbQuery LoadByJobNumberAndJobComponentNumberCompleteRet = default;
        //    try
        //    {
        //        LoadByJobNumberAndJobComponentNumberCompleteRet = (from JobComponentTask in DbContext.GetQuery<Database.Entities.JobComponentTask>.Include("Phase")
        //                                                           where JobComponentTask.JobNumber == JobNumber && JobComponentTask.JobComponentNumber == JobComponentNumber
        //                                                           select JobComponentTask);
        //    }
        //    catch (Exception ex)
        //    {
        //        LoadByJobNumberAndJobComponentNumberCompleteRet = default;
        //    }

        //    return LoadByJobNumberAndJobComponentNumberCompleteRet;
        //}

        public static System.Linq.IQueryable<Entities.JobTrafficDet> LoadByJobNumberAndJobComponentNumber(Database.DbContext DbContext, int JobNumber, short JobComponentNumber)
        {
            System.Linq.IQueryable<Entities.JobTrafficDet> LoadByJobNumberAndJobComponentNumberRet = default;
            try
            {
                LoadByJobNumberAndJobComponentNumberRet = (from JobComponentTask in DbContext.JobTrafficDet.AsQueryable()
                                                           where JobComponentTask.JobNumber == JobNumber && JobComponentTask.JobComponentNbr == JobComponentNumber
                                                           select JobComponentTask);
            }
            catch (Exception )
            {
                LoadByJobNumberAndJobComponentNumberRet = default;
            }

            return LoadByJobNumberAndJobComponentNumberRet;
        }

        public static Database.Entities.JobTrafficDet LoadByJobNumberAndJobComponentNumberAndSequenceNumber(Database.DbContext DbContext, int JobNumber, short JobComponentNumber, short SequenceNumber)
        {
            Database.Entities.JobTrafficDet LoadByJobNumberAndJobComponentNumberAndSequenceNumberRet = default;
            try
            {
                LoadByJobNumberAndJobComponentNumberAndSequenceNumberRet = (from JobComponentTask in DbContext.JobTrafficDet.AsQueryable()
                                                                            where JobComponentTask.JobNumber == JobNumber && JobComponentTask.JobComponentNbr == JobComponentNumber && JobComponentTask.SeqNbr == SequenceNumber
                                                                            select JobComponentTask).SingleOrDefault();
            }
            catch (Exception )
            {
                LoadByJobNumberAndJobComponentNumberAndSequenceNumberRet = default;
            }

            return LoadByJobNumberAndJobComponentNumberAndSequenceNumberRet;
        }

        public static AdvantageFramework.Core.Database.Entities.JobTrafficDet LoadByJobComponentTaskID(AdvantageFramework.Core.Database.DbContext DbContext, long JobComponentTaskID)
        {
            AdvantageFramework.Core.Database.Entities.JobTrafficDet LoadByJobComponentTaskIDRet = default;
            try
            {
                LoadByJobComponentTaskIDRet = (from JobComponentTask in DbContext.JobTrafficDet.AsQueryable()
                                               where JobComponentTask.Rowid == JobComponentTaskID
                                               select JobComponentTask).SingleOrDefault();
            }
            catch (Exception ex)
            {
                LoadByJobComponentTaskIDRet = default;
            }

            return LoadByJobComponentTaskIDRet;
        }

        public static System.Linq.IQueryable<Entities.JobTrafficDet> Load(Database.DbContext DbContext)
        {
            System.Linq.IQueryable<Entities.JobTrafficDet> LoadRet = default;
            LoadRet = from JobComponentTask in DbContext.JobTrafficDet.AsQueryable()
                      select JobComponentTask;
            return LoadRet;
        }

//        public static bool Insert(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.JobComponentTask JobComponentTask)
//        {
//            bool InsertRet = default;

//            // objects
//            bool Inserted = false;
//            bool IsValid = true;
//            string ErrorText = "";
//            int SequenceNumber = default;
//            try
//            {
//                try
//                {
//                    ;
//#error Cannot convert AssignmentStatementSyntax - see comment for details
//                    /* Cannot convert ParenthesizedExpressionSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.CSharp.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax'.
//                       at ICSharpCode.CodeConverter.CSharp.CommentConvertingVisitorWrapper.ConvertHandledAsync[T](SyntaxNode vbNode, SourceTriviaMapKind sourceTriviaMap) in D:\GitWorkspace\CodeConverter\CodeConverter\CSharp\CommentConvertingVisitorWrapper.cs:line 47

//                    Input: (From Entity In Load(DbContext)
//                                                          Where Entity.JobNumber = JobComponentTask.JobNumber AndAlso
//                                                                Entity.JobComponentNumber = JobComponentTask.JobComponentNumber
//                                                          Select [SN] = Entity.SequenceNumber)
//                    Context:

//                                        SequenceNumber = (From Entity In Load(DbContext)
//                                                          Where Entity.JobNumber = JobComponentTask.JobNumber AndAlso
//                                                                Entity.JobComponentNumber = JobComponentTask.JobComponentNumber
//                                                          Select [SN] = Entity.SequenceNumber).Max + 1

//                     */
//                }
//                catch (Exception ex)
//                {
//                    SequenceNumber = 0;
//                }

//                try
//                {
//                    if (string.IsNullOrWhiteSpace(JobComponentTask.OriginalDueTime) == true && string.IsNullOrWhiteSpace(JobComponentTask.DueTime == false))
//                    {
//                        JobComponentTask.OriginalDueTime = JobComponentTask.DueTime;
//                    }
//                }
//                catch (Exception ex)
//                {
//                }

//                JobComponentTask.SequenceNumber = SequenceNumber;
//                DbContext.JobComponentTasks.Add(JobComponentTask);
//                ErrorText = JobComponentTask.ValidateEntity(IsValid);
//                if (IsValid)
//                {
//                    DbContext.SaveChanges();
//                    CreateWorkItemAlert(DbContext, JobComponentTask);
//                    Inserted = true;
//                }
//                else
//                {
//                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
//                }
//            }
//            catch (Exception ex)
//            {
//                Inserted = false;
//            }
//            finally
//            {
//                InsertRet = Inserted;
//            }

//            return InsertRet;
//        }

        //public static bool Update(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.JobComponentTask JobComponentTask)
        //{
        //    bool UpdateRet = default;

        //    // objects
        //    bool Updated = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {

        //        // Employee Code is a Calculated Field. If more than one employee is assigned to a task, the calculated field returns "..." 
        //        // and causes an error when updating because of the association between JobComponentTask & Employee. 
        //        // Setting EmployeeCode to nothing does not delete the employees.

        //        JobComponentTask.EmployeeCode = null;
        //        DbContext.UpdateObject(JobComponentTask);
        //        ErrorText = JobComponentTask.ValidateEntity(IsValid);
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
        //    catch (Exception )
        //    {
        //        Updated = false;
        //    }
        //    finally
        //    {
        //        UpdateRet = Updated;
        //    }

        //    return UpdateRet;
        //}

        //public static bool Delete(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.JobComponentTask JobComponentTask)
        //{
        //    bool DeleteRet = default;
        //    DeleteRet = Delete(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber, JobComponentTask.SequenceNumber);
        //    return DeleteRet;
        //}

        //public static bool Delete(AdvantageFramework.Core.Database.DbContext DbContext, int JobNumber, short JobComponentNumber, short SequenceNumber)
        //{
        //    bool DeleteRet = default;

        //    // objects
        //    bool Deleted = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    Global.System.Data.Entity.DbContextTransaction DbTransaction = default;
        //    try
        //    {
        //        if (IsValid)
        //        {
        //            DbContext.Database.Connection.Open();
        //            DbTransaction = DbContext.Database.BeginTransaction;
        //            try
        //            {
        //                DbContext.Database.ExecuteSqlCommand(string.Format("EXEC [dbo].[advsp_project_schedule_delete_task] {0}, {1}, {2};", JobNumber, JobComponentNumber, SequenceNumber));
        //                Deleted = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                Deleted = false;
        //            }

        //            if (Deleted)
        //            {
        //                DbTransaction.Commit();
        //            }
        //            else
        //            {
        //                DbTransaction.Rollback();
        //            }
        //        }
        //        else
        //        {
        //            //AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Deleted = false;
        //    }
        //    finally
        //    {
        //        DeleteRet = Deleted;
        //    }

        //    return DeleteRet;
        //}

        //public static bool CreateWorkItemAlert(AdvantageFramework.Database.DbContext DbContext, int JobNumber, short JobComponentNumber, short SequenceNumber)
        //{
        //    bool CreateWorkItemAlertRet = default;

        //    // objects
        //    System.Data.SqlClient.SqlParameter JobNumberSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter JobComponentNumberSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter SequenceNumberSqlParameter = null;
        //    System.Data.SqlClient.SqlParameter UserCodeSqlParameter = null;
        //    bool Created = false;
        //    try
        //    {
        //        JobNumberSqlParameter = new System.Data.SqlClient.SqlParameter("JobNumber", JobNumber);
        //        JobComponentNumberSqlParameter = new System.Data.SqlClient.SqlParameter("JobComponentNumber", JobComponentNumber);
        //        SequenceNumberSqlParameter = new System.Data.SqlClient.SqlParameter("SequenceNumber", SequenceNumber);
        //        UserCodeSqlParameter = new System.Data.SqlClient.SqlParameter("UserCode", DbContext.UserCode);
        //        DbContext.Database.ExecuteSqlCommand("EXEC dbo.[advsp_agile_add_assignment_from_task] @JobNumber, @JobComponentNumber, @SequenceNumber, @UserCode", JobNumberSqlParameter, JobComponentNumberSqlParameter, SequenceNumberSqlParameter, UserCodeSqlParameter);
        //        Created = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Created = false;
        //    }

        //    CreateWorkItemAlertRet = Created;
        //    return CreateWorkItemAlertRet;
        //}

        //public static bool CreateWorkItemAlert(AdvantageFramework.Database.DbContext DbContext, AdvantageFramework.Database.Entities.JobComponentTask JobComponentTask)
        //{
        //    bool CreateWorkItemAlertRet = default;
        //    CreateWorkItemAlertRet = CreateWorkItemAlert(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber, JobComponentTask.SequenceNumber);
        //    return CreateWorkItemAlertRet;
        //}



        #endregion
    }
}
