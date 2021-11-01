using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvantageFramework.Core.Database.Procedures
{
    class VendorRepresentative
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

        public static IQueryable<AdvantageFramework.Core.Database.Entities.VendorRepresentative> Load(AdvantageFramework.Core.Database.DataContext DataContext)
        {
            IQueryable<AdvantageFramework.Core.Database.Entities.VendorRepresentative> LoadRet = default;
            LoadRet = from VendorRepresentative in DataContext.VendorRepresentatives.AsQueryable()
                      select VendorRepresentative;
            return LoadRet;
        }

        public static Database.Entities.VendorRepresentative LoadActiveByCodeAndVendorCode(Database.DataContext DataContext, string VendorRepresentativeCode, string VendorCode)
        {
            Database.Entities.VendorRepresentative LoadActiveByCodeAndVendorCodeRet = default;
            if ((from VendorRepresentative in DataContext.VendorRepresentatives.AsQueryable()
                 where VendorRepresentative.VnCode == VendorCode && VendorRepresentative.VrCode == VendorRepresentativeCode
                 select VendorRepresentative).Any())
            {
                LoadActiveByCodeAndVendorCodeRet = (from VendorRepresentative in DataContext.VendorRepresentatives.AsQueryable()
                                                    where VendorRepresentative.VnCode == VendorCode && VendorRepresentative.VrCode == VendorRepresentativeCode
                                                    select VendorRepresentative).SingleOrDefault();
            }
            else
            {
                LoadActiveByCodeAndVendorCodeRet = default;
            }

            return LoadActiveByCodeAndVendorCodeRet;
        }

        public static Database.Entities.VendorRepresentative LoadByCodeAndVendorCode(Database.DataContext DataContext, string VendorRepresentativeCode, string VendorCode)
        {
            Database.Entities.VendorRepresentative LoadByCodeAndVendorCodeRet = default;
            try
            {
                LoadByCodeAndVendorCodeRet = (from VendorRepresentative in DataContext.VendorRepresentatives.AsQueryable()
                                              where VendorRepresentative.VnCode == VendorCode && VendorRepresentative.VrCode == VendorRepresentativeCode
                                              select VendorRepresentative).SingleOrDefault();
            }
            catch (Exception ex)
            {
                LoadByCodeAndVendorCodeRet = default;
            }

            return LoadByCodeAndVendorCodeRet;
        }

        public static IQueryable<Database.Entities.VendorRepresentative> LoadActiveByVendorCode(Database.DataContext DataContext, string VendorCode)
        {
            IQueryable<Database.Entities.VendorRepresentative> LoadActiveByVendorCodeRet = default;
            LoadActiveByVendorCodeRet = from VendorRepresentative in DataContext.VendorRepresentatives.AsQueryable()
                                        where VendorRepresentative.VnCode == VendorCode && (VendorRepresentative.VrInactiveFlag == null || VendorRepresentative.VrInactiveFlag == 0)
                                        select VendorRepresentative;
            return LoadActiveByVendorCodeRet;
        }

        public static IQueryable<Database.Entities.VendorRepresentative> LoadByVendorCode(Database.DataContext DataContext, string VendorCode)
        {
            IQueryable<Database.Entities.VendorRepresentative> LoadByVendorCodeRet = default;
            LoadByVendorCodeRet = from VendorRepresentative in DataContext.VendorRepresentatives.AsQueryable()
                                  where VendorRepresentative.VnCode == VendorCode
                                  select VendorRepresentative;
            return LoadByVendorCodeRet;
        }

        //public static IQueryable<Database.Entities.VendorRepresentative> LoadWithOfficeLimits(AdvantageFramework.Core.Database.DbContext DbContext, Database.DataContext DataContext, AdvantageFramework.Security.Session Session)
        //{
        //    IQueryable<Database.Entities.VendorRepresentative> LoadWithOfficeLimitsRet = default;
        //    LoadWithOfficeLimitsRet = LoadWithOfficeLimits(DbContext, DataContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes);
        //    return LoadWithOfficeLimitsRet;
        //}

        //public static IQueryable<Database.Entities.VendorRepresentative> LoadWithOfficeLimits(AdvantageFramework.Core.Database.DbContext DbContext, Database.DataContext DataContext, List<string> OfficeCodes, bool HasLimitedOfficeCodes)
        //{
        //    IQueryable<Database.Entities.VendorRepresentative> LoadWithOfficeLimitsRet = default;
        //    LoadWithOfficeLimitsRet = LoadWithOfficeLimits(DataContext.VendorRepresentatives.AsQueryable(), DbContext, OfficeCodes, HasLimitedOfficeCodes);
        //    return LoadWithOfficeLimitsRet;
        //}

        //public static IQueryable<Database.Entities.VendorRepresentative> LoadWithOfficeLimits(IQueryable<AdvantageFramework.Core.Database.Entities.VendorRepresentative> VendorRepresentatives, AdvantageFramework.Database.DbContext DbContext, List<string> OfficeCodes, bool HasLimitedOfficeCodes)
        //{
        //    IQueryable<Database.Entities.VendorRepresentative> LoadWithOfficeLimitsRet = default;
        //    List<string> VendorCodes = null;
        //    VendorCodes = AdvantageFramework.Core.Database.Procedures.Vendor.LoadWithOfficeLimits(DbContext, OfficeCodes, HasLimitedOfficeCodes).Select(Entity => Entity.Code).ToList;
        //    LoadWithOfficeLimitsRet = (IQueryable<Database.Entities.VendorRepresentative>)(from VendorRepresentative in VendorRepresentatives
        //                                                                                   where HasLimitedOfficeCodes == false || VendorCodes.Contains(Conversions.ToString(VendorRepresentative.VendorCode))
        //                                                                                   select VendorRepresentative);
        //    return LoadWithOfficeLimitsRet;
        //}

        //public static bool Insert(AdvantageFramework.Core.Database.DataContext DataContext, AdvantageFramework.Core.Database.Entities.VendorRepresentative VendorRepresentative)
        //{
        //    bool InsertRet = default;

        //    // objects
        //    bool Inserted = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {
        //        VendorRepresentative.DataContext = DataContext;
        //        VendorRepresentative.DatabaseAction = AdvantageFramework.Database.Action.Inserting;
        //        DataContext.VendorRepresentatives.InsertOnSubmit(VendorRepresentative);
        //        ErrorText = VendorRepresentative.ValidateEntity(IsValid);
        //        if (IsValid)
        //        {
        //            DataContext.SubmitChanges();
        //            Inserted = true;
        //        }
        //        else
        //        {
        //            AdvantageFramework.Navigation.ShowMessageBox(ErrorText);
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

        //public static bool Update(AdvantageFramework.Core.Database.DataContext DataContext, AdvantageFramework.Core.Database.Entities.VendorRepresentative VendorRepresentative)
        //{
        //    bool UpdateRet = default;

        //    // objects
        //    bool Updated = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {
        //        VendorRepresentative.DataContext = DataContext;
        //        VendorRepresentative.DatabaseAction = AdvantageFramework.Database.Action.Updating;
        //        ErrorText = VendorRepresentative.ValidateEntity(IsValid);
        //        if (IsValid)
        //        {
        //            DataContext.SubmitChanges();
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

        //public static bool Delete(AdvantageFramework.Core.Database.DataContext DataContext, AdvantageFramework.Core.Database.Entities.VendorRepresentative VendorRepresentative)
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
        //            try
        //            {
        //                DataContext.ExecuteCommand(string.Format("DELETE FROM dbo.VEN_REP WHERE VN_CODE = '{0}' AND VR_CODE = '{1}'", VendorRepresentative.VendorCode, VendorRepresentative.Code));
        //            }
        //            catch (Exception ex)
        //            {
        //                IsValid = false;
        //            }

        //            if (IsValid)
        //            {
        //                DataContext.ExecuteCommand(string.Format("DELETE FROM dbo.VEN_REP_CLIENTS WHERE VN_CODE = '{0}' AND VR_CODE = '{1}'", VendorRepresentative.VendorCode, VendorRepresentative.Code));
        //                Deleted = true;
        //            }
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
