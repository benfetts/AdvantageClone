using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdvantageFramework.Core.Database.Procedures
{
    public static class Settings
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
        public static IQueryable<AdvantageFramework.Core.Database.Entities.Setting> LoadBySettingModuleIDAndSettingModuleTabIDAndSettingModuleGroupID(AdvantageFramework.Core.Database.DataContext DataContext, long SettingModuleID, long SettingModuleTabID, long SettingModuleGroupID)
        {
            IQueryable<AdvantageFramework.Core.Database.Entities.Setting> LoadBySettingModuleIDAndSettingModuleTabIDAndSettingModuleGroupIDRet = default;
            LoadBySettingModuleIDAndSettingModuleTabIDAndSettingModuleGroupIDRet = from Setting in DataContext.Settings.AsQueryable()
                                                                                   where Setting.AgySettingsApp == SettingModuleID && Setting.AgySettingsApp == SettingModuleTabID && Setting.AgySettingsGrp == SettingModuleGroupID
                                                                                   select Setting;
            return LoadBySettingModuleIDAndSettingModuleTabIDAndSettingModuleGroupIDRet;
        }

        public static IQueryable<AdvantageFramework.Core.Database.Entities.Setting> LoadBySettingModuleID(AdvantageFramework.Core.Database.DataContext DataContext, long SettingModuleID)
        {
            IQueryable<AdvantageFramework.Core.Database.Entities.Setting> LoadBySettingModuleIDRet = default;
            LoadBySettingModuleIDRet = from Setting in DataContext.Settings.AsQueryable()
                                       where Setting.AgySettingsApp == SettingModuleID
                                       select Setting;
            return LoadBySettingModuleIDRet;
        }

        public static IQueryable<AdvantageFramework.Core.Database.Entities.Setting> LoadBySettingModuleIDAndSettingModuleTabID(AdvantageFramework.Core.Database.DataContext DataContext, long SettingModuleID, long SettingModuleTabID)
        {
            IQueryable<AdvantageFramework.Core.Database.Entities.Setting> LoadBySettingModuleIDAndSettingModuleTabIDRet = default;
            LoadBySettingModuleIDAndSettingModuleTabIDRet = from Setting in DataContext.Settings.AsQueryable()
                                                            where Setting.AgySettingsApp == SettingModuleID && Setting.AgySettingsApp == SettingModuleTabID && (Setting.InactiveFlag == null || Setting.InactiveFlag == 0)
                                                            select Setting;
            return LoadBySettingModuleIDAndSettingModuleTabIDRet;
        }

        public static AdvantageFramework.Core.Database.Entities.Setting LoadBySettingCode(AdvantageFramework.Core.Database.DataContext DataContext, string SettingCode)
        {
            AdvantageFramework.Core.Database.Entities.Setting LoadBySettingCodeRet = default;
            try
            {
                LoadBySettingCodeRet = (from Setting in DataContext.Settings.AsQueryable()
                                        where Setting.AgySettingsCode == SettingCode
                                        select Setting).SingleOrDefault();
            }
            catch (Exception ex)
            {
                LoadBySettingCodeRet = default;
            }

            return LoadBySettingCodeRet;
        }

        public static IQueryable<AdvantageFramework.Core.Database.Entities.Setting> Load(AdvantageFramework.Core.Database.DataContext DataContext)
        {
            IQueryable<AdvantageFramework.Core.Database.Entities.Setting> LoadRet = default;
            LoadRet = from Setting in DataContext.Settings.AsQueryable()
                      select Setting;
            return LoadRet;
        }

        //public static bool Insert(AdvantageFramework.Core.Database.DataContext DataContext, AdvantageFramework.Core.Database.Entities.Setting Setting)
        //{
        //    bool InsertRet = default;

        //    // objects
        //    bool Inserted = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {
        //        Setting.DataContext = DataContext;
        //        Setting.DatabaseAction = AdvantageFramework.Core.Database.Action.Inserting;
        //        DataContext.Settings.InsertOnSubmit(Setting);
        //        ErrorText = Setting.ValidateEntity(IsValid);
        //        if (IsValid)
        //        {
        //            DataContext.SubmitChanges();
        //            Inserted = true;
        //        }
        //        else
        //        {
        //            AdvantageFramework.Core.Navigation.ShowMessageBox(ErrorText);
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

        //public static bool Update(AdvantageFramework.Core.Database.DataContext DataContext, AdvantageFramework.Database.Entities.Setting Setting)
        //{
        //    bool UpdateRet = default;

        //    // objects
        //    bool Updated = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {
        //        Setting.DataContext = DataContext;
        //        Setting.DatabaseAction = AdvantageFramework.Core.Database.Action.Updating;
        //        ErrorText = Setting.ValidateEntity(IsValid);
        //        if (IsValid)
        //        {
        //            DataContext.SubmitChanges();
        //            Updated = true;
        //        }
        //        else
        //        {
        //            AdvantageFramework.Core.Navigation.ShowMessageBox(ErrorText);
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}
