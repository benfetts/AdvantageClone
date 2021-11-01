using System;
using System.Linq;

namespace AdvantageFramework.Core.Database.Procedures
{
    public static partial class ClientContact
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

        //public static System.Linq.IQueryable<Entities.ClientContact> LoadContactsNotAssignedToDivisionOrProduct(Database.DbContext DbContext, string ClientCode)
        //{
        //    System.Linq.IQueryable<Entities.ClientContact> LoadContactsNotAssignedToDivisionOrProductRet = default;
        //    LoadContactsNotAssignedToDivisionOrProductRet = from ClientContact in DbContext.ClientContacts.AsQueryable()
        //                                                    where DbContext.GetQuery<AdvantageFramework.Core.Security.Database.Entities.ClientContactDetail>.Where(CCDetail => Operators.ConditionalCompareObjectEqual(CCDetail.ContactID, ClientContact.CdpContactId, false)).Any == false && ClientContact.ClCode == ClientCode
        //                                                    select ClientContact;
        //    return LoadContactsNotAssignedToDivisionOrProductRet;
        //}

        public static AdvantageFramework.Core.Database.Entities.ClientContact LoadByContactID(Database.DbContext DbContext, int ContactID)
        {
            AdvantageFramework.Core.Database.Entities.ClientContact LoadByContactIDRet = default;
            try
            {
                LoadByContactIDRet = (from ClientContact in DbContext.ClientContacts.AsQueryable()
                                      where ClientContact.CdpContactId == ContactID
                                      select ClientContact).SingleOrDefault();
            }
            catch (Exception)
            {
                LoadByContactIDRet = default;
            }

            return LoadByContactIDRet;
        }

        public static AdvantageFramework.Core.Database.Entities.ClientContact LoadByClientAndContactCode(Database.DbContext DbContext, string ClientCode, string ContactCode)
        {
            AdvantageFramework.Core.Database.Entities.ClientContact LoadByClientAndContactCodeRet = default;
            try
            {
                LoadByClientAndContactCodeRet = (from ClientContact in DbContext.ClientContacts.AsQueryable()
                                                 where ClientContact.ClCode == ClientCode && ClientContact.ContCode == ContactCode
                                                 select ClientContact).SingleOrDefault();
            }
            catch (Exception )
            {
                LoadByClientAndContactCodeRet = default;
            }

            return LoadByClientAndContactCodeRet;
        }

        public static System.Linq.IQueryable<Entities.ClientContact> LoadAllActiveByClientCode(Database.DbContext DbContext, string ClientCode)
        {
            System.Linq.IQueryable<Entities.ClientContact> LoadAllActiveByClientCodeRet = default;
            LoadAllActiveByClientCodeRet = from ClientContact in LoadAllActive(DbContext)
                                           where ClientContact.ClCode == ClientCode
                                           select ClientContact;
            return LoadAllActiveByClientCodeRet;
        }

        public static System.Linq.IQueryable<Entities.ClientContact> LoadByClientCode(Database.DbContext DbContext, string ClientCode)
        {
            System.Linq.IQueryable<Entities.ClientContact> LoadByClientCodeRet = default;
            LoadByClientCodeRet = from ClientContact in DbContext.ClientContacts.AsQueryable()
                                  where ClientContact.ClCode == ClientCode
                                  select ClientContact;
            return LoadByClientCodeRet;
        }

        public static System.Linq.IQueryable<Entities.ClientContact> LoadAllActive(Database.DbContext DbContext)
        {
            System.Linq.IQueryable<Entities.ClientContact> LoadAllActiveRet = default;
            LoadAllActiveRet = from ClientContact in DbContext.ClientContacts.AsQueryable()
                               where ClientContact.InactiveFlag == null || ClientContact.InactiveFlag == 0
                               select ClientContact;
            return LoadAllActiveRet;
        }

        public static System.Linq.IQueryable<Entities.ClientContact> Load(Database.DbContext DbContext)
        {
            System.Linq.IQueryable<Entities.ClientContact> LoadRet = default;
            LoadRet = from ClientContact in DbContext.ClientContacts.AsQueryable()
                      select ClientContact;
            return LoadRet;
        }

        //public static bool Insert(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.ClientContact ClientContact)
        //{
        //    bool InsertRet = default;

        //    // objects
        //    bool Inserted = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {
        //        DbContext.ClientContact.Add(ClientContact);
        //        ErrorText = ClientContact.ValidateEntity(IsValid);
        //        if (IsValid)
        //        {
        //            DbContext.SaveChanges();
        //            Inserted = true;
        //        }
        //        else
        //        {
        //            //AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
        //        }
        //    }
        //    catch (Exception )
        //    {
        //        Inserted = false;
        //    }
        //    finally
        //    {
        //        InsertRet = Inserted;
        //    }

        //    return InsertRet;
        //}

        //public static bool Update(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.ClientContact ClientContact)
        //{
        //    bool UpdateRet = default;

        //    // objects
        //    bool Updated = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {
        //        DbContext.UpdateObject(ClientContact);
        //        ErrorText = ClientContact.ValidateEntity(IsValid);
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

        //public static bool Delete(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.ClientContact ClientContact)
        //{
        //    bool DeleteRet = default;
        //    DeleteRet = Delete(DbContext, ClientContact.CdpContactId);
        //    return DeleteRet;
        //}

        //public static bool Delete(AdvantageFramework.Core.Database.DbContext DbContext, int ContactID)
        //{
        //    bool DeleteRet = default;

        //    // objects
        //    bool Deleted = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    Global.System.Data.Entity.DbContextTransaction DbTransaction = default;
        //    try
        //    {
        //        if (DbContext.Database.Connection.State != ConnectionState.Open)
        //        {
        //            DbContext.Database.Connection.Open();
        //        }

        //        DbTransaction = DbContext.Database.BeginTransaction;
        //        try
        //        {
        //            DbContext.Database.ExecuteSqlCommand(string.Format("DELETE FROM dbo.CDP_CONTACT_DTL WHERE CDP_CONTACT_ID = {0}", ContactID));
        //            DbContext.Database.ExecuteSqlCommand(string.Format("DELETE FROM dbo.CP_SEC_CLIENT WHERE CDP_CONTACT_ID = {0}", ContactID));
        //            DbContext.Database.ExecuteSqlCommand(string.Format("DELETE FROM dbo.CDP_CONTACT_HDR WHERE CDP_CONTACT_ID = {0}", ContactID));
        //            Deleted = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            Deleted = false;
        //        }

        //        if (Deleted)
        //        {
        //            DbTransaction.Commit();
        //        }
        //        else
        //        {
        //            DbTransaction.Rollback();
        //            AdvantageFramework.Navigation.ShowMessageBox("This Contact is currently in use and cannot be deleted.");
        //        }
        //    }
        //    catch (Exception ex)
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
