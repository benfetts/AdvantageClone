using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvantageFramework.Core.Database.Procedures
{
    public static partial class MediaTrafficVendor
    {
        #region  Constants 

        private const string _GENERATED = "Cannot delete vendor as instruction has already been generated.";

        #endregion

        #region  Enum 



        #endregion

        #region  Variables 



        #endregion

        #region  Properties 



        #endregion

        #region  Methods 

        public static Database.Entities.MediaTrafficVendor LoadByID(Database.DbContext DbContext, int ID)
        {
            Database.Entities.MediaTrafficVendor LoadByIDRet = default;
            LoadByIDRet = (from MediaTrafficVendor in DbContext.MediaTrafficVendors.AsQueryable()
                           where MediaTrafficVendor.MediaTrafficVendorId == ID
                           select MediaTrafficVendor).SingleOrDefault();
            return LoadByIDRet;
        }

        public static System.Linq.IQueryable<Entities.MediaTrafficVendor> LoadByMediaTrafficRevisionIDs(Database.DbContext DbContext, IEnumerable<int> RevisionIDs)
        {
            System.Linq.IQueryable<Entities.MediaTrafficVendor> LoadByMediaTrafficRevisionIDsRet = default;
            LoadByMediaTrafficRevisionIDsRet = from MediaTrafficVendor in DbContext.MediaTrafficVendors.AsQueryable()
                                               where RevisionIDs.Contains(MediaTrafficVendor.MediaTrafficRevisionId) == true
                                               select MediaTrafficVendor;
            return LoadByMediaTrafficRevisionIDsRet;
        }

        public static System.Linq.IQueryable<Entities.MediaTrafficVendor> Load(Database.DbContext DbContext)
        {
            System.Linq.IQueryable<Entities.MediaTrafficVendor> LoadRet = default;
            LoadRet = from MediaTrafficVendor in DbContext.MediaTrafficVendors.AsQueryable()
                      select MediaTrafficVendor;
            return LoadRet;
        }

        //public static bool Insert(AdvantageFramework.Database.DbContext DbContext, AdvantageFramework.Database.Entities.MediaTrafficVendor MediaTrafficVendor, ref string ErrorText)
        //{
        //    bool InsertRet = default;

        //    // objects
        //    bool Inserted = false;
        //    bool IsValid = true;
        //    try
        //    {
        //        DbContext.MediaTrafficVendors.Add(MediaTrafficVendor);
        //        ErrorText = MediaTrafficVendor.ValidateEntity(IsValid);
        //        if (IsValid)
        //        {
        //            DbContext.SaveChanges();
        //            Inserted = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Inserted = false;
        //        ErrorText = ex.Message;
        //    }
        //    finally
        //    {
        //        InsertRet = Inserted;
        //    }

        //    return InsertRet;
        //}

        //public static bool Update(AdvantageFramework.Database.DbContext DbContext, AdvantageFramework.Database.Entities.MediaTrafficVendor MediaTrafficVendor)
        //{
        //    bool UpdateRet = default;

        //    // objects
        //    bool Updated = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {
        //        DbContext.UpdateObject(MediaTrafficVendor);
        //        ErrorText = MediaTrafficVendor.ValidateEntity(IsValid);
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

        //public static bool DeleteByID(AdvantageFramework.Database.DbContext DbContext, int MediaTrafficVendorID, ref string ErrorText)
        //{
        //    bool DeleteByIDRet = default;

        //    // objects
        //    AdvantageFramework.Database.Entities.MediaTrafficVendor MediaTrafficVendor = default;
        //    bool Deleted = false;
        //    bool IsValid = true;
        //    try
        //    {
        //        if (AdvantageFramework.Database.Procedures.MediaTrafficVendorStatus.LoadByMediaTrafficVendorID(DbContext, MediaTrafficVendorID).Where(MTVS => Operators.ConditionalCompareObjectEqual(MTVS.MediaTrafficStatusID, Entities.Methods.MediaTrafficStatusID.Generated, false)).Any)
        //        {
        //            IsValid = false;
        //            ErrorText = _GENERATED;
        //        }

        //        if (IsValid)
        //        {
        //            DbContext.Database.ExecuteSqlCommand(string.Format("DELETE dbo.MEDIA_TRAFFIC_VENDOR_STATUS WHERE MEDIA_TRAFFIC_VENDOR_ID = {0}", MediaTrafficVendorID));
        //            DbContext.Database.ExecuteSqlCommand(string.Format("DELETE dbo.MEDIA_TRAFFIC_VENDOR_CREATIVE_GROUP WHERE MEDIA_TRAFFIC_VENDOR_ID = {0}", MediaTrafficVendorID));
        //            DbContext.Database.ExecuteSqlCommand(string.Format("DELETE dbo.MEDIA_TRAFFIC_VENDOR WHERE MEDIA_TRAFFIC_VENDOR_ID = {0}", MediaTrafficVendorID));
        //            Deleted = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Deleted = false;
        //        ErrorText = ex.Message;
        //    }
        //    finally
        //    {
        //        DeleteByIDRet = Deleted;
        //    }

        //    return DeleteByIDRet;
        //}

        //public static bool HasInstructionBeenGenerated(AdvantageFramework.Core.Database.DbContext DbContext, int MediaTrafficVendorID, ref string Message)
        //{
        //    bool HasInstructionBeenGeneratedRet = default;
        //    Message = _GENERATED;
        //    HasInstructionBeenGeneratedRet = AdvantageFramework.Core.Database.Procedures.MediaTrafficVendorStatus.LoadByMediaTrafficVendorID(DbContext, MediaTrafficVendorID).Where(MTVS => Operators.ConditionalCompareObjectEqual(MTVS.MediaTrafficStatusID, Entities.Methods.MediaTrafficStatusID.Generated, false)).Any;
        //    return HasInstructionBeenGeneratedRet;
        //}

        #endregion
    }
}
