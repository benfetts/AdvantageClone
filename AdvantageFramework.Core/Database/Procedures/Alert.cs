using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvantageFramework.Core.Database.Procedures
{
    public static partial class Alert
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

        public static AdvantageFramework.Core.Database.Entities.Alert LoadTaskWorkItem(AdvantageFramework.Core.Database.DbContext DbContext, int JobNumber, short JobComponentNumber, short TaskSequenceNumber)
        {
            AdvantageFramework.Core.Database.Entities.Alert LoadTaskWorkItemRet = default;
            LoadTaskWorkItemRet = (from Alert in DbContext.Alerts.AsQueryable()
                                   where (Alert.AlertLevel == "BRD" | Alert.AlertCatId == 71) & Alert.JobNumber == JobNumber & Alert.JobComponentNbr == JobComponentNumber & Alert.TaskSeqNbr == TaskSequenceNumber
                                   select Alert).SingleOrDefault();
            return LoadTaskWorkItemRet;
        }

        public static System.Linq.IQueryable<Entities.Alert> LoadAssignmentsByJobAndComponent(AdvantageFramework.Core.Database.DbContext DbContext, int JobNumber, short JobComponentNumber)
        {
            System.Linq.IQueryable<Entities.Alert> LoadAssignmentsByJobAndComponentRet = default;
            LoadAssignmentsByJobAndComponentRet = from Alert in DbContext.Alerts.AsQueryable()
                                                  where Alert.JobNumber == JobNumber & Alert.JobComponentNbr == JobComponentNumber & Alert.AlrtNotifyHdrId is object & Alert.AlertStateId is object
                                                  select Alert;
            return LoadAssignmentsByJobAndComponentRet;
        }

        public static AdvantageFramework.Core.Database.Entities.Alert LoadByConceptShareReviewID(AdvantageFramework.Core.Database.DbContext DbContext, int ConceptShareReviewID)
        {
            AdvantageFramework.Core.Database.Entities.Alert LoadByConceptShareReviewIDRet = default;
            try
            {
                LoadByConceptShareReviewIDRet = (from Alert in DbContext.Alerts.AsQueryable()
                                                 where Alert.CsReviewId == ConceptShareReviewID
                                                 select Alert).SingleOrDefault();
            }
            catch (Exception )
            {
                LoadByConceptShareReviewIDRet = default;
            }

            return LoadByConceptShareReviewIDRet;
        }

        public static AdvantageFramework.Core.Database.Entities.Alert LoadByAlertID(AdvantageFramework.Core.Database.DbContext DbContext, long AlertID)
        {
            AdvantageFramework.Core.Database.Entities.Alert LoadByAlertIDRet = default;
            try
            {
                LoadByAlertIDRet = (from Alert in DbContext.Alerts.AsQueryable()
                                    where Alert.AlertId == AlertID
                                    select Alert).SingleOrDefault();
            }
            catch (Exception )
            {
                LoadByAlertIDRet = default;
            }

            return LoadByAlertIDRet;
        }

        public static System.Linq.IQueryable<Entities.Alert> Load(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            System.Linq.IQueryable<Entities.Alert> LoadRet = default;
            LoadRet = from Alert in DbContext.Alerts.AsQueryable()
                      select Alert;
            return LoadRet;
        }

        public static System.Linq.IQueryable<Entities.Alert> LoadByTypeIDAndClientAndDivisionAndProductCode(AdvantageFramework.Core.Database.DbContext DbContext, int TypeID, string ClientCode, string DivisionCode, string ProductCode)
        {
            System.Linq.IQueryable<Entities.Alert> LoadByTypeIDAndClientAndDivisionAndProductCodeRet = default;
            LoadByTypeIDAndClientAndDivisionAndProductCodeRet = from Alert in DbContext.Alerts.AsQueryable()
                                                                where Alert.AlertTypeId == TypeID && Alert.ClCode == ClientCode && Alert.DivCode == DivisionCode && Alert.PrdCode == ProductCode
                                                                select Alert;
            return LoadByTypeIDAndClientAndDivisionAndProductCodeRet;
        }

        public static AdvantageFramework.Core.Database.Entities.Alert LoadByNonTaskID(AdvantageFramework.Core.Database.DbContext DbContext, long NonTaskID)
        {
            AdvantageFramework.Core.Database.Entities.Alert LoadByNonTaskIDRet = default;
            try
            {
                LoadByNonTaskIDRet = (from Alert in DbContext.Alerts.AsQueryable()
                                      where Alert.NonTaskId == NonTaskID
                                      select Alert).SingleOrDefault();
            }
            catch (Exception )
            {
                LoadByNonTaskIDRet = default;
            }

            return LoadByNonTaskIDRet;
        }

        public static System.Linq.IQueryable<Entities.Alert> LoadByJobVersionID(AdvantageFramework.Core.Database.DbContext DbContext, long JobVersionID)
        {
            System.Linq.IQueryable<Entities.Alert> LoadByJobVersionIDRet = default;
            try
            {
                LoadByJobVersionIDRet = from Alert in DbContext.Alerts.AsQueryable()
                                        where Alert.JobVerHdrId == JobVersionID
                                        select Alert;
            }
            catch (Exception )
            {
                LoadByJobVersionIDRet = default;
            }

            return LoadByJobVersionIDRet;
        }

        public static System.Linq.IQueryable<Entities.Alert> LoadClientContactAlerts(AdvantageFramework.Core.Database.DbContext DbContext, int ClientContactID, int Skip, int Take)
        {
            System.Linq.IQueryable<Entities.Alert> LoadClientContactAlertsRet = default;

            // LoadClientContactAlerts = LoadEmployeeAlertsAndAssignments(DbContext, EmployeeCode).Where(Function(Alert) Alert.AlertRecipients.Any(Function(AlertRecipient) AlertRecipient.IsCurrentNotify Is Nothing OrElse AlertRecipient.IsCurrentNotify = 0))
            LoadClientContactAlertsRet = (from Alert in DbContext.Alerts.AsQueryable()
                                          join AlertRecipients in ClientPortalAlertRecipient.Load(DbContext) on Alert.AlertId equals AlertRecipients.AlertId
                                          where AlertRecipients.CdpContactId == ClientContactID
                                          orderby Alert.LastUpdated descending
                                          select Alert).Skip(Skip).Take(Take);
            return LoadClientContactAlertsRet;
        }

        public static System.Linq.IQueryable<Entities.Alert> LoadEmployeeAlerts(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode, int Skip, int Take)
        {
            System.Linq.IQueryable<Entities.Alert> LoadEmployeeAlertsRet = default;

            // LoadEmployeeAlerts = LoadEmployeeAlertsAndAssignments(DbContext, EmployeeCode).Where(Function(Alert) Alert.AlertRecipients.Any(Function(AlertRecipient) AlertRecipient.IsCurrentNotify Is Nothing OrElse AlertRecipient.IsCurrentNotify = 0))
            LoadEmployeeAlertsRet = (from Alert in DbContext.Alerts.AsQueryable()
                                     join AlertRecipients in AlertRecipient.Load(DbContext) on Alert.AlertId equals AlertRecipients.AlertId
                                     where AlertRecipients.EmpCode == EmployeeCode && (AlertRecipients.CurrentNotify == null || AlertRecipients.CurrentNotify == 0)
                                     orderby Alert.LastUpdated descending
                                     select Alert).Skip(Skip).Take(Take);
            return LoadEmployeeAlertsRet;
        }

        public static System.Linq.IQueryable<Entities.Alert> LoadEmployeeAssignments(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode, int Skip, int Take)
        {
            System.Linq.IQueryable<Entities.Alert> LoadEmployeeAssignmentsRet = default;

            // LoadEmployeeAssignments = LoadEmployeeAlertsAndAssignments(DbContext, EmployeeCode).Where(Function(Alert) Alert.AlertRecipients.Any(Function(AlertRecipient) AlertRecipient.IsCurrentNotify = 1))
            LoadEmployeeAssignmentsRet = (from Alert in DbContext.Alerts.AsQueryable()
                                          join AlertRecipients in AlertRecipient.Load(DbContext) on Alert.AlertId equals AlertRecipients.AlertId
                                          where AlertRecipients.EmpCode == EmployeeCode & AlertRecipients.CurrentNotify == 1
                                          orderby Alert.LastUpdated descending
                                          select Alert).Skip(Skip).Take(Take);
            return LoadEmployeeAssignmentsRet;
        }

        public static System.Linq.IQueryable<Entities.Alert> LoadEmployeeAlertsAndAssignments(AdvantageFramework.Core.Database.DbContext DbContext, string EmployeeCode, int Skip, int Take)
        {
            System.Linq.IQueryable<Entities.Alert> query;
            List<int> list;
            list = (from Alert in DbContext.Alerts.AsQueryable()
                    join AlertRecipients in AlertRecipient.Load(DbContext) on Alert.AlertId equals AlertRecipients.AlertId
                    where AlertRecipients.EmpCode == EmployeeCode
                    orderby Alert.LastUpdated descending
                    select Alert.AlertId).Distinct().ToList();
            query = (from Alert in DbContext.Alerts.AsQueryable()
                     where list.Contains(Alert.AlertId)
                     orderby Alert.AlertId
                     select Alert);
            return query.Skip(Skip).Take(Take);
        }

        public static System.Linq.IQueryable<Entities.Alert> LoadDigitalAssetReviewsByJobAndComponentNumber(AdvantageFramework.Core.Database.DbContext DbContext, int JobNumber, short JobComponentNumber)
        {
            System.Linq.IQueryable<Entities.Alert> LoadDigitalAssetReviewsByJobAndComponentNumberRet = default;
            LoadDigitalAssetReviewsByJobAndComponentNumberRet = from Alert in DbContext.Alerts.AsQueryable()
                                                                where Alert.JobNumber == JobNumber && Alert.JobComponentNbr == JobComponentNumber && Alert.AlertTypeId == 15
                                                                select Alert;
            return LoadDigitalAssetReviewsByJobAndComponentNumberRet;
        }

        //public static bool Insert(AdvantageFramework.Core.Database.DbContext DbContext, int AlertTypeID, int AlertCategoryID, string Subject, string Body, DateTime? GeneratedDate, short? PriorityLevel, string EmployeeCode, string UserCode, string AlertLevel, string EmailBody, ref AdvantageFramework.Core.Database.Entities.Alert Alert)




        //{
        //    bool InsertRet = default;

        //    // objects
        //    bool Inserted = false;
        //    try
        //    {
        //        Alert = new AdvantageFramework.Core.Database.Entities.Alert();
        //        Alert.DbContext = DbContext;
        //        Alert.AlertTypeID = AlertTypeID;
        //        Alert.AlertCategoryID = AlertCategoryID;
        //        Alert.Subject = Subject;
        //        Alert.Body = Body;
        //        Alert.GeneratedDate = GeneratedDate;
        //        Alert.PriorityLevel = PriorityLevel;
        //        Alert.EmployeeCode = EmployeeCode;
        //        Alert.UserCode = UserCode;
        //        Alert.AlertLevel = AlertLevel;
        //        Alert.EmailBody = EmailBody;
        //        Alert.LastUpdated = GeneratedDate;
        //        Inserted = Insert(DbContext, Alert);
        //    }
        //    catch (Exception ex)
        //    {
        //        Inserted = false;
        //    }
        //    finally
        //    {
        //        InsertRet = Inserted;
        //    }

        //    return InsertRet;
        //}

        //public static bool Insert(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Alert Alert)
        //{
        //    bool InsertRet = default;

        //    // objects
        //    bool Inserted = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {
        //        DbContext.Alerts.Add(Alert);
        //        //ErrorText = Alert.ValidateEntity(IsValid);
        //        if (IsValid)
        //        {
        //            try
        //            {
        //                Alert.AlertId = (from Entity in Load(DbContext)
        //                            select Entity.AlertId).Max() + 1;
        //            }
        //            catch (Exception )
        //            {
        //                Alert.AlertId = 1;
        //            }

        //            DbContext.SaveChanges();
        //            Inserted = true;
        //        }
        //        else
        //        {
        //            //AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Inserted = false;
        //    }
        //    finally
        //    {
        //        InsertRet = Inserted;
        //    }

        //    return InsertRet;
        //}

        public static bool Update(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Alert Alert)
        {
            bool UpdateRet = default;

            // objects
            bool Updated = false;
            bool IsValid = true;
            string ErrorText = "";
            try
            {
                //TODO: Actually update the alert
                //DbContext.UpdateObject(Alert);
                //ErrorText = Alert.ValidateEntity(IsValid);
                if (IsValid)
                {
                    DbContext.SaveChanges();
                    Updated = true;
                }
                else
                {
                    //AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
                }
            }
            catch (Exception )
            {
                Updated = false;
            }
            finally
            {
                UpdateRet = Updated;
            }

            return UpdateRet;
        }

        //public static bool Delete(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.Alert Alert)
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
        //            DbContext.DeleteEntityObject(Alert);
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
