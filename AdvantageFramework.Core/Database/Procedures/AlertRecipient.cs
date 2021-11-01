using System;
using System.Linq;

namespace AdvantageFramework.Core.Database.Procedures
{
    class AlertRecipient
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

        public static System.Linq.IQueryable<Entities.AlertRecipient> LoadByAlertID(AdvantageFramework.Core.Database.DbContext DbContext, long AlertID)
        {
            System.Linq.IQueryable<Entities.AlertRecipient> LoadByAlertIDRet = default;
            LoadByAlertIDRet = from AlertRecipient in DbContext.AlertRecipients.AsQueryable()
                               where AlertRecipient.AlertId == AlertID
                               select AlertRecipient;
            return LoadByAlertIDRet;
        }

        public static AdvantageFramework.Core.Database.Entities.AlertRecipient LoadByAlertIDAndEmployeeCodeExcludeAssignee(AdvantageFramework.Core.Database.DbContext DbContext, long AlertID, string EmployeeCode)
        {
            AdvantageFramework.Core.Database.Entities.AlertRecipient LoadByAlertIDAndEmployeeCodeExcludeAssigneeRet = default;
            LoadByAlertIDAndEmployeeCodeExcludeAssigneeRet = (from AlertRecipient in DbContext.AlertRecipients.AsQueryable()
                                                              where AlertRecipient.AlertId == AlertID && AlertRecipient.EmpCode == EmployeeCode && (AlertRecipient.CurrentNotify == null || AlertRecipient.CurrentNotify == 0)

                                                              select AlertRecipient).SingleOrDefault();
            return LoadByAlertIDAndEmployeeCodeExcludeAssigneeRet;
        }

        public static AdvantageFramework.Core.Database.Entities.AlertRecipient LoadByAlertIDAndEmployeeCode(AdvantageFramework.Core.Database.DbContext DbContext, long AlertID, string EmployeeCode)
        {
            AdvantageFramework.Core.Database.Entities.AlertRecipient LoadByAlertIDAndEmployeeCodeRet = default;
            try
            {
                LoadByAlertIDAndEmployeeCodeRet = (from AlertRecipient in DbContext.AlertRecipients.AsQueryable()
                                                   where AlertRecipient.AlertId == AlertID && AlertRecipient.EmpCode == EmployeeCode
                                                   select AlertRecipient).SingleOrDefault();
            }
            catch (Exception )
            {
                return default;
            }

            return LoadByAlertIDAndEmployeeCodeRet;
        }

        public static AdvantageFramework.Core.Database.Entities.AlertRecipient LoadAssigneeByAlertIDAndEmployeeCode(AdvantageFramework.Core.Database.DbContext DbContext, long AlertID, string EmployeeCode)
        {
            AdvantageFramework.Core.Database.Entities.AlertRecipient LoadAssigneeByAlertIDAndEmployeeCodeRet = default;
            try
            {
                LoadAssigneeByAlertIDAndEmployeeCodeRet = (from AlertRecipient in DbContext.AlertRecipients.AsQueryable()
                                                           where AlertRecipient.AlertId == AlertID & AlertRecipient.EmpCode == EmployeeCode & AlertRecipient.CurrentNotify == 1
                                                           select AlertRecipient).SingleOrDefault();
            }
            catch (Exception )
            {
                return default;
            }

            return LoadAssigneeByAlertIDAndEmployeeCodeRet;
        }

        public static AdvantageFramework.Core.Database.Entities.AlertRecipient LoadAssigneeByAlertIDEmployeeCodeTemplateState(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Alert Alert, string EmployeeCode)
        {
            AdvantageFramework.Core.Database.Entities.AlertRecipient LoadAssigneeByAlertIDEmployeeCodeTemplateStateRet = default;
            try
            {
                LoadAssigneeByAlertIDEmployeeCodeTemplateStateRet = (from AlertRecipient in DbContext.AlertRecipients.AsQueryable()
                                                                     where AlertRecipient.AlertId == Alert.AlertId & AlertRecipient.EmpCode == EmployeeCode & AlertRecipient.CurrentNotify == 1 & AlertRecipient.AlrtNotifyHdrId == Alert.AlrtNotifyHdrId & AlertRecipient.AlertStateId == Alert.AlertStateId
                                                                     select AlertRecipient).SingleOrDefault();
            }
            catch (Exception )
            {
                return default;
            }

            return LoadAssigneeByAlertIDEmployeeCodeTemplateStateRet;
        }

        public static System.Linq.IQueryable<Entities.AlertRecipient> Load(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            System.Linq.IQueryable<Entities.AlertRecipient> LoadRet = default;
            LoadRet = from AlertRecipient in DbContext.AlertRecipients.AsQueryable()
                      select AlertRecipient;
            return LoadRet;
        }

        public static bool Insert(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, string EmployeeCode, string EmployeeEmail, DateTime? ProcessedDate, short? IsNewAlert, short? HasBeenRead, ref AdvantageFramework.Core.Database.Entities.AlertRecipient AlertRecipient)


        {
            bool InsertRet = default;

            // objects
            bool Inserted = false;
            try
            {
                AlertRecipient = new AdvantageFramework.Core.Database.Entities.AlertRecipient();
                AlertRecipient.AlertId = AlertID;
                AlertRecipient.EmpCode = EmployeeCode;
                AlertRecipient.EmailAddress = EmployeeEmail;
                AlertRecipient.Processed = ProcessedDate;
                AlertRecipient.NewAlert = IsNewAlert;
                AlertRecipient.ReadAlert = HasBeenRead;
                Inserted = Insert(DbContext, AlertRecipient);
            }
            catch (Exception ex)
            {
                Inserted = false;
            }
            finally
            {
                InsertRet = Inserted;
            }

            return InsertRet;
        }

        public static bool Insert(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.AlertRecipient AlertRecipient)
        {
            bool InsertRet = default;

            // objects
            bool Inserted = false;
            bool IsValid = true;
            string ErrorText = "";
            try
            {

                // If AlertRecipient.IsEntityBeingAdded() = True Then <== This doesn't work becaus the ID is part of the Entity Key

                DbContext.AlertRecipients.Add(AlertRecipient);
                DbContext.SaveChanges();

                //ErrorText = AlertRecipient.ValidateEntity(IsValid);
                //if (IsValid)
                //{
                //    if (AlertRecipient.AlertRcptId == 0)
                //    {
                //        try
                //        {

                //            // AlertRecipient.ID = (From Entity In AdvantageFramework.Core.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, AlertRecipient.AlertID) _
                //            // Select Entity.ID).Max + 1
                //            AlertRecipient.AlertRcptId = DbContext.Database.SqlQuery<int>(string.Format("SELECT ISNULL(MAX(R.ALERT_RCPT_ID), 0) + 1  FROM ALERT_RCPT R WITH(NOLOCK) WHERE R.ALERT_ID = {0}", AlertRecipient.AlertID)).SingleOrDefault();
                //        }
                //        catch (Exception)
                //        {
                //            AlertRecipient.AlertRcptId = 1;
                //        }
                //    }

                //    DbContext.SaveChanges();
                //    Inserted = true;
                //}
                //else
                //{
                //    //AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
                //}
            }

            // End If

            catch (Exception)
            {
                Inserted = false;
            }
            finally
            {
                InsertRet = Inserted;
            }

            return InsertRet;
        }

        //public static bool Update(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.AlertRecipient AlertRecipient)
        //{
        //    bool UpdateRet = default;

        //    // objects
        //    bool Updated = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {
        //        DbContext.UpdateObject(AlertRecipient);
        //        ErrorText = AlertRecipient.ValidateEntity(IsValid);
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

        //public static bool Delete(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.AlertRecipient AlertRecipient)
        //{
        //    bool DeleteRet = default;

        //    // objects
        //    bool Deleted = true;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {
        //        if (IsValid)
        //        {
        //            DbContext.DeleteEntityObject(AlertRecipient);
        //            DbContext.SaveChanges();
        //            Deleted = true;
        //        }
        //        else
        //        {
        //            //AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
        //        }
        //    }
        //    catch (Exception )
        //    {
        //        Deleted = false;
        //    }
        //    finally
        //    {
        //        DeleteRet = Deleted;
        //    }

        //    return DeleteRet;
        //}

        #endregion
    }
}
