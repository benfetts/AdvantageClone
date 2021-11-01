using System;
using System.Linq;

namespace AdvantageFramework.Core.Database.Procedures
{
    public static partial class ClientPortalAlertRecipient
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

        public static System.Linq.IQueryable<Entities.ClientPortalAlertRecipient> LoadByAlertID(AdvantageFramework.Core.Database.DbContext DbContext, long AlertID)
        {
            System.Linq.IQueryable<Entities.ClientPortalAlertRecipient> LoadByAlertIDRet = default;
            LoadByAlertIDRet = from ClientPortalAlertRecipient in DbContext.ClientPortalAlertRecipients.AsQueryable()
                               where ClientPortalAlertRecipient.AlertId == AlertID
                               select ClientPortalAlertRecipient;
            return LoadByAlertIDRet;
        }

        public static AdvantageFramework.Core.Database.Entities.ClientPortalAlertRecipient LoadByAlertIDAndContactID(AdvantageFramework.Core.Database.DbContext DbContext, long AlertID, int ClientContactID)
        {
            AdvantageFramework.Core.Database.Entities.ClientPortalAlertRecipient LoadByAlertIDAndContactIDRet = default;
            LoadByAlertIDAndContactIDRet = (from ClientPortalAlertRecipient in DbContext.ClientPortalAlertRecipients.AsQueryable()
                                            where ClientPortalAlertRecipient.AlertId == AlertID & ClientPortalAlertRecipient.CdpContactId == ClientContactID
                                            select ClientPortalAlertRecipient).SingleOrDefault();
            return LoadByAlertIDAndContactIDRet;
        }

        public static System.Linq.IQueryable<Entities.ClientPortalAlertRecipient> Load(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            System.Linq.IQueryable<Entities.ClientPortalAlertRecipient> LoadRet = default;
            LoadRet = from ClientPortalAlertRecipient in DbContext.ClientPortalAlertRecipients.AsQueryable()
                      select ClientPortalAlertRecipient;
            return LoadRet;
        }

        //public static bool Insert(AdvantageFramework.Core.Database.DbContext DbContext, int AlertID, int ClientContactID, string EmailAddress, DateTime? ProcessedDate, short? IsNewAlert, short? HasBeenRead, ref AdvantageFramework.Core.Database.Entities.ClientPortalAlertRecipient ClientPortalAlertRecipient)


        //{
        //    bool InsertRet = default;

        //    // objects
        //    bool Inserted = false;
        //    try
        //    {
        //        ClientPortalAlertRecipient = new AdvantageFramework.Core.Database.Entities.ClientPortalAlertRecipient();
        //        ClientPortalAlertRecipient.DbContext = DbContext;
        //        ClientPortalAlertRecipient.AlertID = AlertID;
        //        ClientPortalAlertRecipient.ClientContactID = ClientContactID;
        //        ClientPortalAlertRecipient.EmailAddress = EmailAddress;
        //        ClientPortalAlertRecipient.ProcessedDate = ProcessedDate;
        //        ClientPortalAlertRecipient.IsNewAlert = IsNewAlert;
        //        ClientPortalAlertRecipient.HasBeenRead = HasBeenRead;
        //        Inserted = Insert(DbContext, ClientPortalAlertRecipient);
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

        //public static bool Insert(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.ClientPortalAlertRecipient ClientPortalAlertRecipient)
        //{
        //    bool InsertRet = default;

        //    // objects
        //    bool Inserted = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {
        //        DbContext.ClientPortalAlertRecipients.Add(ClientPortalAlertRecipient);
        //        ErrorText = ClientPortalAlertRecipient.ValidateEntity(IsValid);
        //        if (IsValid)
        //        {
        //            if (ClientPortalAlertRecipient.AlertRecipientID == 0)
        //            {
        //                try
        //                {
        //                    ClientPortalAlertRecipient.AlertRecipientID = (from Entity in AdvantageFramework.Core.Database.Procedures.ClientPortalAlertRecipient.LoadByAlertID(DbContext, ClientPortalAlertRecipient.AlertID)
        //                                                                   select Entity.AlertRecipientID).Max + 1;
        //                }
        //                catch (Exception ex)
        //                {
        //                    ClientPortalAlertRecipient.AlertRecipientID = 1;
        //                }
        //            }

        //            DbContext.SaveChanges();
        //            Inserted = true;
        //        }
        //        else
        //        {
        //            //AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Inserted = false;
        //    }
        //    finally
        //    {
        //        InsertRet = Inserted;
        //    }

        //    return InsertRet;
        //}

        //public static bool Update(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.ClientPortalAlertRecipient ClientPortalAlertRecipient)
        //{
        //    bool UpdateRet = default;

        //    // objects
        //    bool Updated = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {
        //        DbContext.UpdateObject(ClientPortalAlertRecipient);
        //        ErrorText = ClientPortalAlertRecipient.ValidateEntity(IsValid);
        //        if (IsValid)
        //        {
        //            DbContext.SaveChanges();
        //            Updated = true;
        //        }
        //        else
        //        {
        //            AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
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

        //public static bool Delete(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.ClientPortalAlertRecipient ClientPortalAlertRecipient)
        //{
        //    bool DeleteRet = default;

        //    // objects
        //    bool Deleted = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {
        //        if (IsValid)
        //        {
        //            DbContext.DeleteEntityObject(ClientPortalAlertRecipient);
        //            DbContext.SaveChanges();
        //            Deleted = true;
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

        #endregion

    }
}
