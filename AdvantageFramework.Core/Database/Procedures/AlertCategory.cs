using System;
using System.Linq;

namespace AdvantageFramework.Core.Database.Procedures
{
    public static partial class AlertCategory
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

        public static Database.Entities.AlertCategory LoadByAlertTypeIDAndAlertCategoryDescription(Database.DbContext DbContext, string AlertTypeID, string AlertCategoryDescription)
        {
            Database.Entities.AlertCategory LoadByAlertTypeIDAndAlertCategoryDescriptionRet = default;
            try
            {
                LoadByAlertTypeIDAndAlertCategoryDescriptionRet = (from AlertCategory in DbContext.AlertCategories.AsQueryable()
                                                                   where AlertCategory.AlertDesc == AlertCategoryDescription && AlertCategory.AlertTypeId.ToString() == AlertTypeID
                                                                   select AlertCategory).SingleOrDefault();
            }
            catch (Exception)
            {
                LoadByAlertTypeIDAndAlertCategoryDescriptionRet = default;
            }

            return LoadByAlertTypeIDAndAlertCategoryDescriptionRet;
        }

        public static System.Linq.IQueryable<AdvantageFramework.Core.Database.Entities.AlertCategory> LoadByAlertTypeID(Database.DbContext DbContext, string AlertTypeID)
        {
            System.Linq.IQueryable<AdvantageFramework.Core.Database.Entities.AlertCategory> LoadByAlertTypeIDRet = default;
            LoadByAlertTypeIDRet = from AlertCategory in DbContext.AlertCategories.AsQueryable()
                                   where AlertCategory.AlertTypeId.ToString() == AlertTypeID
                                   select AlertCategory;
            return LoadByAlertTypeIDRet;
        }

        public static System.Linq.IQueryable<AdvantageFramework.Core.Database.Entities.AlertCategory> LoadUserDefined(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            System.Linq.IQueryable < AdvantageFramework.Core.Database.Entities.AlertCategory> LoadUserDefinedRet = default;
            LoadUserDefinedRet = (from AlertCategory in DbContext.AlertCategories.AsQueryable()
                                  where AlertCategory.IsUserDefined == true
                                  orderby AlertCategory.AlertDesc
                                  select AlertCategory);
            return LoadUserDefinedRet;
        }

        public static System.Linq.IQueryable<AdvantageFramework.Core.Database.Entities.AlertCategory> LoadUserDefinedActive(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            System.Linq.IQueryable<AdvantageFramework.Core.Database.Entities.AlertCategory> LoadUserDefinedActiveRet = default;
            LoadUserDefinedActiveRet = (from AlertCategory in DbContext.AlertCategories.AsQueryable()
                                        where AlertCategory.IsUserDefined == true && (AlertCategory.IsInactive == null || AlertCategory.IsInactive == false)
                                        orderby AlertCategory.AlertDesc
                                        select AlertCategory);
            return LoadUserDefinedActiveRet;
        }

        public static Database.Entities.AlertCategory LoadByID(Database.DbContext DbContext, int AlertCategoryID)
        {
            Database.Entities.AlertCategory LoadByIDRet = default;
            try
            {
                LoadByIDRet = (from AlertCategory in DbContext.AlertCategories.AsQueryable()
                               where AlertCategory.AlertCatId == AlertCategoryID
                               select AlertCategory).SingleOrDefault();
            }
            catch (Exception)
            {
                LoadByIDRet = default;
            }

            return LoadByIDRet;
        }

        public static System.Linq.IQueryable<AdvantageFramework.Core.Database.Entities.AlertCategory> Load(Database.DbContext DbContext)
        {
            System.Linq.IQueryable<AdvantageFramework.Core.Database.Entities.AlertCategory> LoadRet = default;
            LoadRet = from AlertCategory in DbContext.AlertCategories.AsQueryable()
                      select AlertCategory;
            return LoadRet;
        }

        //public static bool Insert(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.AlertCategory AlertCategory, ref string ErrorMessage)
        //{
        //    bool InsertRet = default;

        //    // objects
        //    bool Inserted = false;
        //    bool IsValid = true;
        //    int NextID = 0;
        //    try
        //    {
        //        try
        //        {
        //            NextID = Conversions.ToInteger(DbContext.Database.SqlQuery<int>("SELECT ISNULL(MAX(ALERT_CAT_ID), 0) + 1 FROM ALERT_CATEGORY WITH(NOLOCK);").FirstOrDefault);
        //        }
        //        catch (Exception)
        //        {
        //            NextID = 0;
        //        }

        //        if (NextID > 0)
        //        {
        //            AlertCategory.ID = NextID;
        //            DbContext.AlertCategories.Add(AlertCategory);
        //            ErrorMessage = AlertCategory.ValidateEntity(IsValid);
        //            if (IsValid)
        //            {
        //                DbContext.SaveChanges();
        //                Inserted = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Inserted = false;
        //        ErrorMessage = ex.Message;
        //        if (ex.InnerException is object)
        //        {
        //            ErrorMessage += ex.InnerException.Message.ToString();
        //        }
        //    }
        //    finally
        //    {
        //        InsertRet = Inserted;
        //    }

        //    return InsertRet;
        //}

        //public static bool Update(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.AlertCategory AlertCategory, ref string ErrorMessage)
        //{
        //    bool UpdateRet = default;

        //    // objects
        //    bool Updated = false;
        //    bool IsValid = true;
        //    try
        //    {
        //        DbContext.Entry(AlertCategory).State = Entity.EntityState.Modified;
        //        ErrorMessage = AlertCategory.ValidateEntity(IsValid);
        //        if (IsValid)
        //        {
        //            DbContext.SaveChanges();
        //            Updated = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Updated = false;
        //        ErrorMessage = ex.Message;
        //        if (ex.InnerException is object)
        //        {
        //            ErrorMessage += Environment.NewLine + Environment.NewLine + ex.InnerException.Message;
        //        }
        //    }
        //    finally
        //    {
        //        UpdateRet = Updated;
        //    }

        //    return UpdateRet;
        //}

        //public static bool Delete(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Core.Database.Entities.AlertCategory AlertCategory)
        //{
        //    bool DeleteRet = default;
        //    bool Deleted = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {
        //        if (IsValid)
        //        {
        //            DbContext.Entry(AlertCategory).State = Entity.EntityState.Deleted;
        //            DbContext.SaveChanges();
        //            Deleted = true;
        //        }
        //        else
        //        {
        //            AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
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
