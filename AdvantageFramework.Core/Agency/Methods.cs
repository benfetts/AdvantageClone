using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdvantageFramework.Core.Agency
{
    public static partial class Methods
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private const int TASK_COMMENT_MAX_LENGTH = 25;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public enum SettingApps
        {
            ProjectScheduleMaintenance = 0,
            AgencyBuilderMaintenance = 1,
            ProductionMaintenance = 2,
            BillingMaintenance = 3,
            EmployeeTimeForecastSettings = 4,
            AgencyBranding = 5,
            Processing1099 = 6,
            IntegrationSettings = 7,
            VCCSettings = 8,
            MeidaManagerSettings = 9
        }

        public enum Settings
        {
            ACC_SETUP_CODE_1,
            ACC_SETUP_CODE_2,
            ACC_SETUP_CODE_3,
            ACC_SETUP_CODE_4,
            ADV_CLIENT_CODE,
            ADV_SERV_USER_CHANGE,
            AGENCY_GOALS_ON,
            AGY_1099_CFSF,
            AGY_1099_COMPANYNAME,
            AGY_1099_CONTACT,
            AGY_1099_STATE_ID,
            AGY_BLD_PPD_END,
            AGY_BLD_PPD_START,
            ALRT_ASSGN_DFLT_SUB,
            AP_APPR_ALERT_GROUP,
            AP_APPR_DFLT_STATE,
            AP_APPR_DFLT_TMPLT,
            AP_APPR_ALERT_AP,
            AP_APPR_ALERT_USER,
            AP_DEF_DESC_VEN_ACCT,
            AP_IMP_DEF_INV_DESC,
            AP_NON_VENDOR_ORDER,
            AP_REMOVE_PMT_HOLD,
            AUTO_ASSGN_KEEP_EMP,
            AVATAX_ACCT_NUMBER,
            AVATAX_ADR_COUNTRIES,
            AVATAX_ADR_ENABLED,
            AVATAX_ENABLED,
            AVATAX_LICENSE_KEY,
            AVATAX_URL,
            AVATAX_USE_CL_ADDR,
            AVATAX_USE_JC_ADDR,
            AVATAX_USE_JOB_SC,
            BA_APPR_INFO_SECT,
            BA_CMNT_SECT,
            BA_DESC_CL_NAME,
            BA_DTLS_SECT,
            BA_JOB_LIST_SECT,
            BA_OPT_INFO_SECT,
            BA_VER_INFO,
            BCC_DEF_WINDOW,
            CAMP_AUTO_GEN_CODE,
            CAMP_REQUIRE_DIV_PRD,
            CCR_DEF_WRITEOFF_GL,
            CCR_PART_PMT_ENABLE,
            CCR_PART_PMT_REQ,
            CLI_INC_ALERT_PCT,
            CLIENTPO_ENBL_AUTONM,
            CLIENTPO_LAST_USED,
            COUNTRY,
            CS_ENABLED,
            CS_PARTNER_KEY,
            CS_PARTNER_PW,
            CS_SA_USERNAME,
            CS_SA_PASSWORD,
            CS_URL,
            CSCORE_AS_CLIENT_ID,
            CSCORE_CLIENT_ID,
            CSCORE_CLIENT_SECRET,
            CSI_CCDATA_FTP,
            CSI_COMDATA_FTP,
            CSI_GVCARD_FTP,
            CSI_IMPORT_PATH,
            CSI_PP_USER,
            CSI_PP_SIGNED,
            CSI_PP_PW,
            CSI_PP_SIGNED_DATE,
            CSI_PP_SIGNED_EMP,
            CSI_VENDOR_FTP,
            CSI_VENDOR_FTP_PW,
            CSI_VENDOR_FTP_USER,
            CUR_RATIO_GOAL,
            CURRENCY_API_KEY,
            CURRENT_RATIO_ON,
            DC_ENABLED,
            DC_OAUTH2_TOKEN,
            DC_HELP,
            DC_PROFILE_ID,
            DC_REPORT_ID,
            DEF_GRP_TYPE_INT,
            DEF_GRP_TYPE_MAG,
            DEF_GRP_TYPE_NEW,
            DEF_GRP_TYPE_OUT,
            DEF_GRP_TYPE_RAD,
            DEF_GRP_TYPE_TV,
            DIRECT_EXP_ALERT_AMT,
            DIRECT_EXPENSE_ON,
            EAG_OVER_PCT_TOTAL,
            EAG_PROP_PCT_DIRECT,
            EAG_PROP_PCT_TOTAL,
            EAG_UNDER_PCT_DIRECT,
            EASTLAN_ENABLED,
            ENCRYPTED_PW_P1,
            ETF_AALT_HRSCHANGED,
            ETF_AALT_HRSEXCEED,
            ETF_HIDE_DIV_COL,
            ETF_HIDE_PRD_COL,
            ETF_HIDE_REVSHAREAMT,
            ETF_REVAMT_CALC,
            ETF_SHOW_CODEONLY,
            ETF_SHOW_JOB_DTL,
            ETF_USE_EMPTTLE_RATE,
            FEDERAL_TAX_ID,
            FILE_UPLOAD_LIMIT,
            FOLD_FUNCTION,
            FTE_BASIS,
            GROSS_INC_PCT_BILL,
            IMP_ALERT_BUYER,
            IMP_PENDING_TV,
            IMP_PENDING_RAD,
            IMP_PENDING_PRI,
            IMP_PENDING_OUT,
            IMP_PENDING_INT,
            IMP_PAYMENT_HOLD,
            INVPRT_CCSENDER,
            INVPRT_COMB_COOP_INV,
            INVPRT_COVER_CC,
            INVPRT_COVER_CC_LOC,
            INVPRT_COVER_CC_TYPE,
            INVPRT_COVER_LAYOUT,
            INVPRT_COVER_TITLE,
            INVPRT_EMAILBODY,
            INVPRT_EMAILSUBJECT,
            INVPRT_FILE_NAME,
            INVPRT_FROMEMAIL,
            INVPRT_INCL_CS,
            INVPRT_PACKAGETYPE,
            INVPRT_PRINTPRD,
            INVPRT_REPLYTO,
            INVPRT_SENDERNAME,
            INVPRT_SINGLEEMAIL,
            INVPRT_SINGLEPDF,
            INVPRT_SORTOPTION,
            INVPRT_UPDOC,
            IO_MEDIA_ORDERLINE,
            IRS_TCC,
            JOB_PS_REQ_ON_NEW,
            JOB_VERSION_DESC,
            JR_ALERT_SETTING,
            JR_ASSIGN_STATE,
            JR_ASSIGN_TMPLT,
            JR_DFLT_ALERT_GROUP,
            JR_DFLT_CONTACT,
            JR_DFLT_TMPLT,
            MAX_EMAIL_SIZE,
            MBW_DEFAULT_RATE,
            MEDIA_EXCL_ORD_PDF,
            MEDIA_REQ_CAMPAIGN,
            MEDIATRAFFIC_STARTDT,
            MO_USE_VENDOR_RATE,
            MP_ADD_TO_ORDER,
            NATIONAL_DB_NAME,
            NATIONAL_DB_PASSWORD,
            NATIONAL_DB_SERVER,
            NATIONAL_DB_USER,
            NATIONAL_WIN_AUTH,
            NET_PROFIT_PCT_GP,
            NEW_LICENSE_KEY,
            NIELSEN_DB_NAME,
            NIELSEN_DB_PASSWORD,
            NIELSEN_DB_SERVER,
            NIELSEN_DB_USER,
            NIELSEN_SVC_TIMEOUT,
            NIELSEN_WINDOWS_AUTH,
            OPER_EXP_PCT_INC,
            ORDER_AP_OUTPATH,
            ORDER_MP_OUTPATH,
            OVERHEAD_FACTOR,
            OVERHEAD_PCT_INC,
            PAYROLL_PCT_INC,
            PROOFHQ_ENABLED,
            PROOFHQ_SA_PASSWORD,
            PROOFHQ_SA_USERNAME,
            PROOFHQ_USE_SA,
            REPOSITORY_LIMIT,
            RPT_JD_FEE_FNC_CODES,
            RSC_RPT_FLX_CLR,
            RSC_RPT_HLD_CLR,
            RSC_RPT_NO_ETI_CLR,
            RSC_RPT_PRE_CLR,
            RSC_RPT_STC_CLR,
            SERVICE_TAX_ENABLED,
            SMTP_OAUTH2_TOKEN,
            SYNC_GOOGLECALENDAR,
            SYNC_OUTLOOK,
            SYNC_OUTLOOK_USE_EX,
            SYNC_SUGARCRM,
            SYNC_SUGARCRM_URL,
            TR_TITLE1,
            TR_TITLE2,
            TR_TITLE3,
            TR_TITLE4,
            TR_TITLE5,
            TRAFFIC_MGR_COL,
            TRF_ACTIVE_NEXT_TASK,
            TRF_ALRT_TMP_CMPLT,
            TRF_CALC_BY_CMP,
            TRF_CALC_BY_DAY,
            TRF_CALC_CONCUR_DT,
            TRF_CMPLT_ON_LAST,
            TRF_COMP_ALERT,
            TRF_COMP_NO_TMP,
            TRF_DEL_TSK_ALRT,
            TRF_DFLT_STATUS,
            TRF_HRS,
            TRF_LOCK_DATE,
            TRF_NXT_TSK_AUTO_EML,
            TRF_SCHEDULE_BY,
            TRF_TEMP_COMP_ALERT,
            TRF_UPDATE_ALERT_DUE,
            TRF_UPDATE_STATUS,
            TS_AGY_OVRRDE,
            TS_DAYS_TO_DISPLAY,
            TS_DIVISION,
            TS_FUNC_CAT,
            TS_JOB,
            TS_JOB_COMP,
            TS_MIN_TIME,
            TS_PROD_CAT,
            TS_PRODUCT,
            TS_REQ_CMT_APPR,
            TS_ROUND_TO,
            TS_SHOW_CMNT_USING,
            TS_START_WEEK_ON,
            TS_STOP_MIN_TIME,
            TS_STOP_ROUND_TO,
            TS_TASK_ONLY,
            USE_PHASE,
            VAT_PPSTART,
            VAT_PPEND,
            VAT_AGENCY_VATNUMBER,
            VAT_CURRENCY_CODE,
            VAT_OUTPUT_DIRECTORY,
            VEN_COST_COL_TERMS,
            VCC_ACCOUNT_ID,
            VCC_API_URL,
            VCC_COMPANY_ID,
            VCC_INCLUDE_CARDINFO,
            VCC_OUTSOURCE_ID,
            VCC_PROVIDER,
            VCC_SA_PASSWORD,
            VCC_SA_USERNAME,
            VCCREM_CCSENDER,
            VCCREM_EMAILBODY,
            VCCREM_EMAILSUBJECT,
            VCCREM_LETTER,
            VCC_USE_SA,
            WV_BRND_BG,
            WV_BRND_BG_TYPE,
            WV_BRND_BGCLR,
            WV_BRND_CLK_APP,
            WV_BRND_CLK_USR,
            WV_BRND_CLR_SN_IN,
            WV_BRND_ENABLE,
            WV_BRND_FLT_DTO,
            WV_BRND_ICON,
            WV_BRND_LOGO,
            WV_BRND_LOGO_ON_WP,
            WV_BRND_LOGO_POS,
            WV_BRND_SHRT_MNU,
            WV_BRND_SMPL_BG_CLR,
            WV_BRND_SMPL_ICON,
            WV_BRND_SMPL_SB_CLR,
            WV_BRND_THEME,
            WV_BRND_USR_BG,
            WV_BRND_USR_THM,
            WV_ENABLE_WTHR,
            WV_WALLPAPER_DEF,
            WV_BRND_TXCLR
        }

        public enum LocalMachineAccess
        {
            [AdvantageFramework.Core.Registry.Attributes.RegistryAttribute("", "AccessRptPath", "")]
            AccessRptPath,
            [AdvantageFramework.Core.Registry.Attributes.RegistryAttribute("", "AccessTmpPath", "")]
            AccessTmpPath,
            [AdvantageFramework.Core.Registry.Attributes.RegistryAttribute("", "WebvantageURL", "")]
            WebvantageURL,
            [AdvantageFramework.Core.Registry.Attributes.RegistryAttribute("", "ClientPortalURL", "")]
            ClientPortalURL
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public static List<short> LoadDefaultDisplayDaysList()
        {
            List<short> LoadDefaultDisplayDaysListRet = default;
            List<short> DefaultDisplayDaysList = null;
            DefaultDisplayDaysList = new List<short>();
            DefaultDisplayDaysList.Add(1);
            DefaultDisplayDaysList.Add(5);
            DefaultDisplayDaysList.Add(7);
            LoadDefaultDisplayDaysListRet = DefaultDisplayDaysList;
            return LoadDefaultDisplayDaysListRet;
        }

        public static List<short> LoadAdjustCheckBodyLinesDownList()
        {
            List<short> LoadAdjustCheckBodyLinesDownListRet = default;
            List<short> AdjustCheckBodyLinesDownList = null;
            AdjustCheckBodyLinesDownList = new List<short>();
            AdjustCheckBodyLinesDownList.Add(0);
            AdjustCheckBodyLinesDownList.Add(1);
            AdjustCheckBodyLinesDownList.Add(2);
            LoadAdjustCheckBodyLinesDownListRet = AdjustCheckBodyLinesDownList;
            return LoadAdjustCheckBodyLinesDownListRet;
        }

        public static List<short> LoadAdjustCheckStubLinesUpList()
        {
            List<short> LoadAdjustCheckStubLinesUpListRet = default;
            List<short> AdjustCheckStubLinesUpList = null;
            AdjustCheckStubLinesUpList = new List<short>();
            AdjustCheckStubLinesUpList.Add(0);
            AdjustCheckStubLinesUpList.Add(1);
            LoadAdjustCheckStubLinesUpListRet = AdjustCheckStubLinesUpList;
            return LoadAdjustCheckStubLinesUpListRet;
        }

        //public static bool UpdateJobComponentTaxOption(AdvantageFramework.Core.Database.DbContext DbContext, bool MarkAsTaxable)
        //{
        //    bool UpdateJobComponentTaxOptionRet = default;
        //    bool Updated = true;
        //    try
        //    {

        //        // For Each Product In AdvantageFramework.Core.Database.Procedures.Product.Load(DbContext).Include("Jobs").Include("Jobs.JobComponents").ToList

        //        // For Each Job In Product.Jobs

        //        // For Each JobComponent In Job.JobComponents

        //        // If MarkAsTaxable Then

        //        // JobComponent.TaxCode = Product.ProductionTaxCode
        //        // JobComponent.TaxFlag = 1

        //        // Else

        //        // JobComponent.TaxCode = Nothing
        //        // JobComponent.TaxFlag = Nothing

        //        // End If

        //        // DbContext.UpdateObject(JobComponent)

        //        // Next

        //        // Next

        //        // Next

        //        DbContext.Database.ExecuteSqlCommand(string.Format("EXEC [dbo].[advsp_job_component_update_tax_option] {0}", MarkAsTaxable ? 1 : 0));
        //    }
        //    catch (Exception ex)
        //    {
        //        Updated = false;
        //    }

        //    // Try

        //    // If Updated Then
        //    // DbContext.SaveChanges()
        //    // End If

        //    // Catch ex As Exception
        //    // Updated = False
        //    // End Try

        //    UpdateJobComponentTaxOptionRet = Updated;
        //    return UpdateJobComponentTaxOptionRet;
        //}

        public static bool DeleteMachineAccessSetting(AdvantageFramework.Core.Agency.Methods.LocalMachineAccess LocalMachineAccess)
        {
            bool DeleteMachineAccessSettingRet = default;

            // objects
            bool Deleted = false;
            Microsoft.Win32.RegistryKey RegistryKey = null;
            AdvantageFramework.Core.Registry.Attributes.RegistryAttribute RegistryAttribute = default;
            string UserSID = "";
            try
            {
                if (Environment.Is64BitOperatingSystem && Environment.Is64BitProcess)
                {
                    RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Advantage", true);
                }
                else
                {
                    RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Advantage", true);
                }

                if (RegistryKey is object)
                {
                    RegistryAttribute = (Registry.Attributes.RegistryAttribute)Attribute.GetCustomAttribute(LocalMachineAccess.GetType().GetField(LocalMachineAccess.ToString()), typeof(AdvantageFramework.Core.Registry.Attributes.RegistryAttribute));
                    if (RegistryAttribute is object)
                    {
                        if (RegistryKey is object)
                        {
                            if (RegistryKey.GetValue(RegistryAttribute.Key) is object)
                            {
                                RegistryKey.DeleteValue(RegistryAttribute.Key);
                            }

                            Deleted = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Deleted = false;
            }

            DeleteMachineAccessSettingRet = Deleted;
            return DeleteMachineAccessSettingRet;
        }

        public static string LoadMachineAccessSettings(AdvantageFramework.Core.Agency.Methods.LocalMachineAccess LocalMachineAccess)
        {
            string LoadMachineAccessSettingsRet = default;

            // objects
            Microsoft.Win32.RegistryKey RegistryKey = null;
            string AgencyAccessValue = "";
            AdvantageFramework.Core.Registry.Attributes.RegistryAttribute RegistryAttribute = default;
            if (Environment.Is64BitOperatingSystem && Environment.Is64BitProcess)
            {
                RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Advantage", false);
            }
            else
            {
                RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Advantage", false);
            }

            if (RegistryKey is object)
            {
                RegistryAttribute = (Registry.Attributes.RegistryAttribute)Attribute.GetCustomAttribute(LocalMachineAccess.GetType().GetField(LocalMachineAccess.ToString()), typeof(AdvantageFramework.Core.Registry.Attributes.RegistryAttribute));
                if (RegistryAttribute is object)
                {
                    if (RegistryKey is object)
                    {
                        AgencyAccessValue = RegistryKey.GetValue(RegistryAttribute.Key, RegistryAttribute.Default).ToString();
                    }
                    else
                    {
                        AgencyAccessValue = RegistryAttribute.Default;
                    }
                }
            }

            LoadMachineAccessSettingsRet = AgencyAccessValue;
            return LoadMachineAccessSettingsRet;
        }

        public static bool UpdateMachineAccessSettings(AdvantageFramework.Core.Agency.Methods.LocalMachineAccess LocalMachineAccess, string LocalMachineAccessValue)
        {
            bool UpdateMachineAccessSettingsRet = default;

            // objects
            bool Updated = false;
            Microsoft.Win32.RegistryKey RegistryKey = null;
            AdvantageFramework.Core.Registry.Attributes.RegistryAttribute RegistryAttribute = default;
            try
            {
                if (Environment.Is64BitOperatingSystem && Environment.Is64BitProcess)
                {
                    RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Advantage", true);
                }
                else
                {
                    RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Advantage", true);
                }

                if (RegistryKey is object)
                {
                    RegistryAttribute = (Registry.Attributes.RegistryAttribute)Attribute.GetCustomAttribute(LocalMachineAccess.GetType().GetField(LocalMachineAccess.ToString()), typeof(AdvantageFramework.Core.Registry.Attributes.RegistryAttribute));
                    if (RegistryAttribute is object)
                    {
                        RegistryKey.SetValue(RegistryAttribute.Key, LocalMachineAccessValue);
                        Updated = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Updated = false;
            }

            UpdateMachineAccessSettingsRet = Updated;
            return UpdateMachineAccessSettingsRet;
        }

        //public static bool UpdateClientReference(AdvantageFramework.Core.Database.DbContext DbContext, bool RequireUniqueClientReferece)
        //{
        //    bool UpdateClientReferenceRet = default;
        //    bool Updated = false;
        //    bool IsValid = true;
        //    string ErrorText = "";
        //    try
        //    {
        //        if (RequireUniqueClientReferece)
        //        {
        //            if ((from Entity in DbContext.Jobs
        //                 where Entity.ClientRef is null && Entity.SalesClassCode is object
        //                 select Entity).Any)
        //            {
        //                //AdvantageFramework.Core.Navigation.ShowMessageBox("One or more of your jobs do not have a client reference. They will not be added to the table " + "and will not be able to be selected from the list of client references.");
        //            }

        //            if (DbContext.Database.ExecuteSqlCommand("INSERT INTO JOB_CLIENT_REF ( JOB_CLI_REF, JOB_NUMBER ) " + "SELECT JOB_CLI_REF, JOB_NUMBER FROM JOB_LOG " + "WHERE JOB_CLI_REF IS NOT NULL AND SC_CODE IS NOT NULL ") > 0)
        //            {
        //                DbContext.Database.ExecuteSqlCommand("UPDATE AGENCY SET CLIENT_REF = 1");
        //                Updated = true;
        //            }
        //        }
        //        else
        //        {
        //            DbContext.Database.ExecuteSqlCommand("UPDATE AGENCY SET CLIENT_REF = 0");
        //            Updated = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Updated = false;
        //    }

        //    UpdateClientReferenceRet = Updated;
        //    return UpdateClientReferenceRet;
        //}

        //public static bool GetOptionAPAllowOrderNotMatchingVendor(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    bool GetOptionAPAllowOrderNotMatchingVendorRet = default;
        //    try
        //    {
        //        GetOptionAPAllowOrderNotMatchingVendorRet = DbContext.Database.SqlQuery<string>("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'AP_NON_VENDOR_ORDER'").SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionAPAllowOrderNotMatchingVendorRet = false;
        //    }

        //    return GetOptionAPAllowOrderNotMatchingVendorRet;
        //}

        //public static string GetOptionAPImportDefaultInvoiceDescription(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    string GetOptionAPImportDefaultInvoiceDescriptionRet = default;
        //    try
        //    {
        //        GetOptionAPImportDefaultInvoiceDescriptionRet = DbContext.Database.SqlQuery<string>("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'AP_IMP_DEF_INV_DESC'").SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionAPImportDefaultInvoiceDescriptionRet = "false";
        //    }

        //    return GetOptionAPImportDefaultInvoiceDescriptionRet;
        //}

        //public static string GetOptionOrderExportFromAPPath(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    string GetOptionOrderExportFromAPPathRet = default;
        //    try
        //    {
        //        GetOptionOrderExportFromAPPathRet = DbContext.Database.SqlQuery<string>("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'ORDER_AP_OUTPATH'").SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionOrderExportFromAPPathRet = "false";
        //    }

        //    return GetOptionOrderExportFromAPPathRet;
        //}

        //public static string GetOptionOrderExportFromMediaPlanPath(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    string GetOptionOrderExportFromMediaPlanPathRet = default;
        //    try
        //    {
        //        GetOptionOrderExportFromMediaPlanPathRet = DbContext.Database.SqlQuery<string>("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'ORDER_MP_OUTPATH'").SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionOrderExportFromMediaPlanPathRet = "false";
        //    }

        //    return GetOptionOrderExportFromMediaPlanPathRet;
        //}

        public static string GetOptionClientCashReceiptsDefaultWriteoffGL(AdvantageFramework.Core.Database.DataContext DataContext)
        {
            string GetOptionClientCashReceiptsDefaultWriteoffGLRet = default;
            AdvantageFramework.Core.Database.Entities.Setting Setting = default;
            string ClientCashReceiptsDefaultWriteoffGL = null;
            try
            {
                Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, AdvantageFramework.Core.Agency.Methods.Settings.CCR_DEF_WRITEOFF_GL.ToString());
            }
            catch (Exception ex)
            {
                Setting = default;
            }

            if (Setting is object)
            {
                ClientCashReceiptsDefaultWriteoffGL = (string)Setting.Value;
            }

            GetOptionClientCashReceiptsDefaultWriteoffGLRet = ClientCashReceiptsDefaultWriteoffGL;
            return GetOptionClientCashReceiptsDefaultWriteoffGLRet;
        }

        //public static bool GetOptionClientCashReceiptsPartialPaymentEnabled(AdvantageFramework.Core.Database.DataContext DataContext)
        //{
        //    bool GetOptionClientCashReceiptsPartialPaymentEnabledRet = default;
        //    AdvantageFramework.Core.Database.Entities.Setting Setting = default;
        //    bool ClientCashReceiptsPartialPaymentEnabled = false;
        //    try
        //    {
        //        Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, AdvantageFramework.Core.Agency.Methods.Settings.CCR_PART_PMT_ENABLE.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Setting = default;
        //    }

        //    if (Setting is object && Information.IsNumeric(Setting.Value) && (int)Setting.Value == 1)
        //    {
        //        ClientCashReceiptsPartialPaymentEnabled = true;
        //    }

        //    GetOptionClientCashReceiptsPartialPaymentEnabledRet = ClientCashReceiptsPartialPaymentEnabled;
        //    return GetOptionClientCashReceiptsPartialPaymentEnabledRet;
        //}

        //public static bool GetOptionClientCashReceiptsPartialPaymentRequired(AdvantageFramework.Core.Database.DataContext DataContext)
        //{
        //    bool GetOptionClientCashReceiptsPartialPaymentRequiredRet = default;
        //    AdvantageFramework.Core.Database.Entities.Setting Setting = default;
        //    bool ClientCashReceiptsPartialPaymentRequired = false;
        //    try
        //    {
        //        Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.CCR_PART_PMT_REQ.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Setting = default;
        //    }

        //    if (Setting is object && Information.IsNumeric(Setting.Value) && Setting.Value == 1)
        //    {
        //        ClientCashReceiptsPartialPaymentRequired = true;
        //    }

        //    GetOptionClientCashReceiptsPartialPaymentRequiredRet = ClientCashReceiptsPartialPaymentRequired;
        //    return GetOptionClientCashReceiptsPartialPaymentRequiredRet;
        //}

        //public static bool GetOptionAutomaticallyRemovePaymentHoldOnApproval(AdvantageFramework.Core.Database.DataContext DataContext)
        //{
        //    bool GetOptionAutomaticallyRemovePaymentHoldOnApprovalRet = default;
        //    AdvantageFramework.Core.Database.Entities.Setting Setting = default;
        //    bool AutomaticallyRemovePaymentHoldOnApproval = false;
        //    try
        //    {
        //        Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.AP_REMOVE_PMT_HOLD.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Setting = default;
        //    }

        //    if (Setting is object && Information.IsNumeric(Setting.Value) && (int)Setting.Value == 1)
        //    {
        //        AutomaticallyRemovePaymentHoldOnApproval = true;
        //    }

        //    GetOptionAutomaticallyRemovePaymentHoldOnApprovalRet = AutomaticallyRemovePaymentHoldOnApproval;
        //    return GetOptionAutomaticallyRemovePaymentHoldOnApprovalRet;
        //}

        public static string GetWebFormTerms(AdvantageFramework.Core.Database.DataContext DataContext)
        {
            string GetWebFormTermsRet = default;
            AdvantageFramework.Core.Database.Entities.Setting Setting = default;
            string WebFormTerms = "";
            try
            {
                Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.VEN_COST_COL_TERMS.ToString());
            }
            catch (Exception ex)
            {
                Setting = default;
            }

            if (Setting is object)
            {
                WebFormTerms = (string)Setting.Value;
            }

            GetWebFormTermsRet = WebFormTerms;
            return GetWebFormTermsRet;
        }

        //public static bool SaveWebFormTerms(AdvantageFramework.Core.Database.DataContext DataContext, string WebFormTerms)
        //{
        //    bool SaveWebFormTermsRet = default;
        //    AdvantageFramework.Core.Database.Entities.Setting Setting = default;
        //    bool Saved = false;
        //    try
        //    {
        //        Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.VEN_COST_COL_TERMS.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Setting = default;
        //    }

        //    if (Setting is object)
        //    {
        //        Setting.Value = WebFormTerms;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Update(DataContext, Setting);
        //    }
        //    else
        //    {
        //        Setting = new AdvantageFramework.Core.Database.Entities.Setting();
        //        Setting.DataContext = DataContext;
        //        Setting.Code = AdvantageFramework.Agency.Settings.VEN_COST_COL_TERMS.ToString;
        //        Setting.Description = "Vendor Cost Collection Terms";
        //        Setting.Value = WebFormTerms;
        //        Setting.SettingDatabaseTypeID = 11;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Setting.Insert(DataContext, Setting);
        //    }

        //    SaveWebFormTermsRet = Saved;
        //    return SaveWebFormTermsRet;
        //}

        //public static bool GetOptionServiceTaxEnabled(AdvantageFramework.Core.Database.DataContext DataContext)
        //{
        //    bool GetOptionServiceTaxEnabledRet = default;
        //    AdvantageFramework.Core.Database.Entities.Setting Setting = default;
        //    bool ServiceTaxEnabled = false;
        //    try
        //    {
        //        Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.SERVICE_TAX_ENABLED.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Setting = default;
        //    }

        //    if (Setting is object && Information.IsNumeric(Setting.Value) && (int)Setting.Value == 1)
        //    {
        //        ServiceTaxEnabled = true;
        //    }

        //    GetOptionServiceTaxEnabledRet = ServiceTaxEnabled;
        //    return GetOptionServiceTaxEnabledRet;
        //}

        public static string LoadDefaultGroupingType(AdvantageFramework.Core.Database.DataContext DataContext, Settings DefaultGroupingTypeSetting)
        {
            string LoadDefaultGroupingTypeRet = default;
            AdvantageFramework.Core.Database.Entities.Setting Setting = default;
            string DefaultGroupingTypeSettingValue = null;
            try
            {
                Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, DefaultGroupingTypeSetting.ToString());
            }
            catch (Exception ex)
            {
                Setting = default;
            }

            if (Setting is object)
            {
                DefaultGroupingTypeSettingValue = (string)Setting.Value;
            }

            LoadDefaultGroupingTypeRet = DefaultGroupingTypeSettingValue;
            return LoadDefaultGroupingTypeRet;
        }

        //public static bool SaveDefaultGroupingType(AdvantageFramework.Core.Database.DataContext DataContext, Settings DefaultGroupingTypeSetting, string DefaultGroupingTypeSettingValue)
        //{
        //    bool SaveDefaultGroupingTypeRet = default;
        //    AdvantageFramework.Core.Database.Entities.Setting Setting = default;
        //    bool Saved = false;
        //    try
        //    {
        //        Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, DefaultGroupingTypeSetting.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Setting = default;
        //    }

        //    if (Setting is object)
        //    {
        //        Setting.Value = DefaultGroupingTypeSettingValue;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Update(DataContext, Setting);
        //    }
        //    else
        //    {
        //        Setting = new AdvantageFramework.Core.Database.Entities.Setting();
        //        Setting.DataContext = DataContext;
        //        Setting.Code = DefaultGroupingTypeSetting.ToString();
        //        Setting.Description = DefaultGroupingTypeSetting.ToString();
        //        Setting.Value = DefaultGroupingTypeSettingValue;
        //        Setting.DefaultValue = null;
        //        Setting.SettingDatabaseTypeID = 20;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Insert(DataContext, Setting);
        //    }

        //    SaveDefaultGroupingTypeRet = Saved;
        //    return SaveDefaultGroupingTypeRet;
        //}

        public static bool LoadMediaOrderLineSelectionInIncomeOnly(AdvantageFramework.Core.Database.DataContext DataContext)
        {
            bool LoadMediaOrderLineSelectionInIncomeOnlyRet = default;
            AdvantageFramework.Core.Database.Entities.Setting Setting = default;
            bool MediaOrderLineSelectionInIncomeOnlyEnabled = false;
            try
            {
                Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.IO_MEDIA_ORDERLINE.ToString());
            }
            catch (Exception ex)
            {
                Setting = default;
            }

            if (Setting is object)
            {
                MediaOrderLineSelectionInIncomeOnlyEnabled = (bool)Setting.Value;
            }

            LoadMediaOrderLineSelectionInIncomeOnlyRet = MediaOrderLineSelectionInIncomeOnlyEnabled;
            return LoadMediaOrderLineSelectionInIncomeOnlyRet;
        }

        //public static bool SaveMediaOrderLineSelectionInIncomeOnly(AdvantageFramework.Core.Database.DataContext DataContext, bool MediaOrderLineSelectionInIncomeOnly)
        //{
        //    bool SaveMediaOrderLineSelectionInIncomeOnlyRet = default;
        //    AdvantageFramework.Core.Database.Entities.Setting Setting = default;
        //    bool Saved = false;
        //    try
        //    {
        //        Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.IO_MEDIA_ORDERLINE.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Setting = default;
        //    }

        //    if (Setting is object)
        //    {
        //        Setting.Value = MediaOrderLineSelectionInIncomeOnly;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Update(DataContext, Setting);
        //    }
        //    else
        //    {
        //        Setting = new AdvantageFramework.Core.Database.Entities.Setting();
        //        Setting.DataContext = DataContext;
        //        Setting.Code = AdvantageFramework.Agency.Settings.IO_MEDIA_ORDERLINE.ToString;
        //        Setting.Description = "Activate media order/line selection in Income Only";
        //        Setting.Value = MediaOrderLineSelectionInIncomeOnly;
        //        Setting.DefaultValue = false;
        //        Setting.SettingDatabaseTypeID = 16;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Insert(DataContext, Setting);
        //    }

        //    SaveMediaOrderLineSelectionInIncomeOnlyRet = Saved;
        //    return SaveMediaOrderLineSelectionInIncomeOnlyRet;
        //}

        public static bool LoadMediaPlanningAddLinesToExistingOrder(AdvantageFramework.Core.Database.DataContext DataContext)
        {
            bool LoadMediaPlanningAddLinesToExistingOrderRet = default;
            AdvantageFramework.Core.Database.Entities.Setting Setting = default;
            bool MediaPlanningAddLinesToExistingOrder = false;
            try
            {
                Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.MP_ADD_TO_ORDER.ToString());
            }
            catch (Exception ex)
            {
                Setting = default;
            }

            if (Setting is object)
            {
                MediaPlanningAddLinesToExistingOrder = (bool)Setting.Value;
            }

            LoadMediaPlanningAddLinesToExistingOrderRet = MediaPlanningAddLinesToExistingOrder;
            return LoadMediaPlanningAddLinesToExistingOrderRet;
        }

        //public static bool SaveMediaPlanningAddLinesToExistingOrder(AdvantageFramework.Core.Database.DataContext DataContext, bool MediaPlanningAddLinesToExistingOrder)
        //{
        //    bool SaveMediaPlanningAddLinesToExistingOrderRet = default;
        //    AdvantageFramework.Core.Database.Entities.Setting Setting = default;
        //    bool Saved = false;
        //    try
        //    {
        //        Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.MP_ADD_TO_ORDER.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Setting = default;
        //    }

        //    if (Setting is object)
        //    {
        //        Setting.Value = MediaPlanningAddLinesToExistingOrder;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Update(DataContext, Setting);
        //    }
        //    else
        //    {
        //        Setting = new AdvantageFramework.Core.Database.Entities.Setting();
        //        Setting.DataContext = DataContext;
        //        Setting.Code = AdvantageFramework.Agency.Settings.MP_ADD_TO_ORDER.ToString;
        //        Setting.Description = "Media Planning - Add lines to existing order";
        //        Setting.Value = MediaPlanningAddLinesToExistingOrder;
        //        Setting.DefaultValue = true;
        //        Setting.MinimumValue = 0;
        //        Setting.MaximumValue = 1;
        //        Setting.SettingDatabaseTypeID = 16;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Insert(DataContext, Setting);
        //    }

        //    SaveMediaPlanningAddLinesToExistingOrderRet = Saved;
        //    return SaveMediaPlanningAddLinesToExistingOrderRet;
        //}

        public static bool LoadBroadcastWorksheetDefaultRateType(AdvantageFramework.Core.Database.DataContext DataContext)
        {
            bool LoadBroadcastWorksheetDefaultRateTypeRet = default;
            AdvantageFramework.Core.Database.Entities.Setting Setting = default;
            bool IsNetRateType = false;
            try
            {
                Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.MBW_DEFAULT_RATE.ToString());
            }
            catch (Exception ex)
            {
                Setting = default;
            }

            if (Setting is object)
            {
                IsNetRateType = (bool)Setting.Value;
            }

            LoadBroadcastWorksheetDefaultRateTypeRet = IsNetRateType;
            return LoadBroadcastWorksheetDefaultRateTypeRet;
        }

        //public static bool SaveBroadcastWorksheetDefaultRateType(AdvantageFramework.Core.Database.DataContext DataContext, bool IsNetRateType)
        //{
        //    bool SaveBroadcastWorksheetDefaultRateTypeRet = default;
        //    AdvantageFramework.Core.Database.Entities.Setting Setting = default;
        //    bool Saved = false;
        //    try
        //    {
        //        Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.MBW_DEFAULT_RATE.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Setting = default;
        //    }

        //    if (Setting is object)
        //    {
        //        Setting.Value = IsNetRateType;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Update(DataContext, Setting);
        //    }
        //    else
        //    {
        //        Setting = new AdvantageFramework.Core.Database.Entities.Setting();
        //        Setting.DataContext = DataContext;
        //        Setting.Code = AdvantageFramework.Agency.Settings.MBW_DEFAULT_RATE.ToString;
        //        Setting.Description = "Broadcast Worksheet Default Rate Type";
        //        Setting.Value = IsNetRateType;
        //        Setting.DefaultValue = false;
        //        Setting.MinimumValue = 0;
        //        Setting.MaximumValue = 1;
        //        Setting.SettingDatabaseTypeID = 16;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Insert(DataContext, Setting);
        //    }

        //    SaveBroadcastWorksheetDefaultRateTypeRet = Saved;
        //    return SaveBroadcastWorksheetDefaultRateTypeRet;
        //}

        public static bool LoadVendorsRateTypeSetting(AdvantageFramework.Core.Database.DataContext DataContext)
        {
            bool LoadVendorsRateTypeSettingRet = default;
            AdvantageFramework.Core.Database.Entities.Setting Setting = default;
            bool UseVendorsRateType = false;
            try
            {
                Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.MO_USE_VENDOR_RATE.ToString());
            }
            catch (Exception ex)
            {
                Setting = default;
            }

            if (Setting is object)
            {
                UseVendorsRateType = (bool)Setting.Value;
            }

            LoadVendorsRateTypeSettingRet = UseVendorsRateType;
            return LoadVendorsRateTypeSettingRet;
        }

        //public static bool SaveVendorsRateTypeSetting(AdvantageFramework.Core.Database.DataContext DataContext, bool UseVendorsRateType)
        //{
        //    bool SaveVendorsRateTypeSettingRet = default;
        //    AdvantageFramework.Core.Database.Entities.Setting Setting = default;
        //    bool Saved = false;
        //    try
        //    {
        //        Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.MO_USE_VENDOR_RATE.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Setting = default;
        //    }

        //    if (Setting is object)
        //    {
        //        Setting.Value = UseVendorsRateType;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Update(DataContext, Setting);
        //    }
        //    else
        //    {
        //        Setting = new AdvantageFramework.Core.Database.Entities.Setting();
        //        Setting.DataContext = DataContext;
        //        Setting.Code = AdvantageFramework.Agency.Settings.MO_USE_VENDOR_RATE.ToString;
        //        Setting.Description = "Use Vendors Rate Type Setting when Creating Orders from Planning and Worksheet";
        //        Setting.Value = UseVendorsRateType;
        //        Setting.DefaultValue = false;
        //        Setting.MinimumValue = 0;
        //        Setting.MaximumValue = 1;
        //        Setting.SettingDatabaseTypeID = 16;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Insert(DataContext, Setting);
        //    }

        //    SaveVendorsRateTypeSettingRet = Saved;
        //    return SaveVendorsRateTypeSettingRet;
        //}

        public static bool LoadMediaRequireCampaign(AdvantageFramework.Core.Database.DataContext DataContext)
        {
            bool LoadMediaRequireCampaignRet = default;
            AdvantageFramework.Core.Database.Entities.Setting Setting = default;
            bool MediaRequireCampaign = false;
            try
            {
                Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.MEDIA_REQ_CAMPAIGN.ToString());
            }
            catch (Exception ex)
            {
                Setting = default;
            }

            if (Setting is object)
            {
                MediaRequireCampaign = (bool)Setting.Value;
            }

            LoadMediaRequireCampaignRet = MediaRequireCampaign;
            return LoadMediaRequireCampaignRet;
        }

        //public static bool SaveMediaRequireCampaign(AdvantageFramework.Core.Database.DataContext DataContext, bool MediaRequireCampaign)
        //{
        //    bool SaveMediaRequireCampaignRet = default;
        //    AdvantageFramework.Core.Database.Entities.Setting Setting = default;
        //    bool Saved = false;
        //    try
        //    {
        //        Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.MEDIA_REQ_CAMPAIGN.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Setting = default;
        //    }

        //    if (Setting is object)
        //    {
        //        Setting.Value = MediaRequireCampaign;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Update(DataContext, Setting);
        //    }
        //    else
        //    {
        //        Setting = new AdvantageFramework.Core.Database.Entities.Setting();
        //        Setting.DataContext = DataContext;
        //        Setting.Code = AdvantageFramework.Agency.Settings.MEDIA_REQ_CAMPAIGN.ToString;
        //        Setting.Description = "Media - Require Campaign Selection";
        //        Setting.Value = MediaRequireCampaign;
        //        Setting.DefaultValue = true;
        //        Setting.MinimumValue = 0;
        //        Setting.MaximumValue = 1;
        //        Setting.SettingDatabaseTypeID = 16;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Insert(DataContext, Setting);
        //    }

        //    SaveMediaRequireCampaignRet = Saved;
        //    return SaveMediaRequireCampaignRet;
        //}

        public static List<string> LoadJobDetailFeesFunctionCodes(AdvantageFramework.Core.Database.DataContext DataContext)
        {
            List<string> LoadJobDetailFeesFunctionCodesRet = default;
            AdvantageFramework.Core.Database.Entities.Setting Setting = default;
            List<string> FunctionCodes = null;
            string FunctionCodeList = string.Empty;
            try
            {
                Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.RPT_JD_FEE_FNC_CODES.ToString());
            }
            catch (Exception ex)
            {
                Setting = default;
            }

            if (Setting is object)
            {
                FunctionCodeList = (string)Setting.Value;
            }

            if (string.IsNullOrWhiteSpace(FunctionCodeList) == false)
            {
                if (FunctionCodeList.Contains(","))
                {
                    FunctionCodes = FunctionCodeList.Split(",").ToList();
                }
                else
                {
                    FunctionCodes = new List<string>();
                    FunctionCodes.Add(FunctionCodeList);
                }
            }
            else
            {
                FunctionCodes = new List<string>();
            }

            LoadJobDetailFeesFunctionCodesRet = FunctionCodes;
            return LoadJobDetailFeesFunctionCodesRet;
        }

        //public static bool SaveJobDetailFeesFunctionCodes(AdvantageFramework.Core.Database.DataContext DataContext, List<string> FunctionCodes)
        //{
        //    bool SaveJobDetailFeesFunctionCodesRet = default;
        //    AdvantageFramework.Core.Database.Entities.Setting Setting = default;
        //    bool Saved = false;
        //    try
        //    {
        //        Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.RPT_JD_FEE_FNC_CODES.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Setting = default;
        //    }

        //    if (Setting is object)
        //    {
        //        if (FunctionCodes is object && FunctionCodes.Count > 0)
        //        {
        //            Setting.Value = Strings.Join(FunctionCodes.ToArray(), ",");
        //        }
        //        else
        //        {
        //            Setting.Value = string.Empty;
        //        }

        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Update(DataContext, Setting);
        //    }
        //    else
        //    {
        //        Setting = new AdvantageFramework.Core.Database.Entities.Setting();
        //        Setting.DataContext = DataContext;
        //        Setting.Code = AdvantageFramework.Agency.Settings.RPT_JD_FEE_FNC_CODES.ToString;
        //        Setting.Description = "Job Detail Fees Function Codes";
        //        if (FunctionCodes is object && FunctionCodes.Count > 0)
        //        {
        //            Setting.Value = Strings.Join(FunctionCodes.ToArray(), ",");
        //        }
        //        else
        //        {
        //            Setting.Value = string.Empty;
        //        }

        //        Setting.DefaultValue = string.Empty;
        //        Setting.SettingDatabaseTypeID = 11;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Insert(DataContext, Setting);
        //    }

        //    SaveJobDetailFeesFunctionCodesRet = Saved;
        //    return SaveJobDetailFeesFunctionCodesRet;
        //}

        public static bool LoadEncryptedPasswordsPhase1(AdvantageFramework.Core.Database.DataContext DataContext)
        {
            bool LoadEncryptedPasswordsPhase1Ret = default;
            AdvantageFramework.Core.Database.Entities.Setting Setting = default;
            bool EncryptedPasswordsPhase1 = false;
            try
            {
                Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.ENCRYPTED_PW_P1.ToString());
            }
            catch (Exception ex)
            {
                Setting = default;
            }

            if (Setting is object)
            {
                EncryptedPasswordsPhase1 = (bool)Setting.Value;
            }

            LoadEncryptedPasswordsPhase1Ret = EncryptedPasswordsPhase1;
            return LoadEncryptedPasswordsPhase1Ret;
        }

        //public static bool SaveEncryptedPasswordsPhase1(AdvantageFramework.Core.Database.DataContext DataContext, bool EncryptedPasswordsPhase1)
        //{
        //    bool SaveEncryptedPasswordsPhase1Ret = default;
        //    AdvantageFramework.Core.Database.Entities.Setting Setting = default;
        //    bool Saved = false;
        //    try
        //    {
        //        Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.ENCRYPTED_PW_P1.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Setting = default;
        //    }

        //    if (Setting is object)
        //    {
        //        Setting.Value = EncryptedPasswordsPhase1;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Update(DataContext, Setting);
        //    }
        //    else
        //    {
        //        Setting = new AdvantageFramework.Core.Database.Entities.Setting();
        //        Setting.DataContext = DataContext;
        //        Setting.Code = AdvantageFramework.Agency.Settings.ENCRYPTED_PW_P1.ToString;
        //        Setting.Description = "Encryption for passwords phase 1";
        //        Setting.Value = EncryptedPasswordsPhase1;
        //        Setting.DefaultValue = true;
        //        Setting.MinimumValue = 0;
        //        Setting.MaximumValue = 1;
        //        Setting.SettingDatabaseTypeID = 16;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Insert(DataContext, Setting);
        //    }

        //    SaveEncryptedPasswordsPhase1Ret = Saved;
        //    return SaveEncryptedPasswordsPhase1Ret;
        //}

        public static int? LoadCountry(AdvantageFramework.Core.Database.DataContext DataContext)
        {
            int? LoadCountryRet = default;
            AdvantageFramework.Core.Database.Entities.Setting Setting = default;
            int? Country = default;
            try
            {
                Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.COUNTRY.ToString());
            }
            catch (Exception ex)
            {
                Setting = default;
            }

            if (Setting is object)
            {
                Country = (int?)Setting.Value;
            }

            LoadCountryRet = Country;
            return LoadCountryRet;
        }

        //public static bool SaveCountry(AdvantageFramework.Core.Database.DataContext DataContext, int? Country)
        //{
        //    bool SaveCountryRet = default;
        //    AdvantageFramework.Core.Database.Entities.Setting Setting = default;
        //    bool Saved = false;
        //    try
        //    {
        //        Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.COUNTRY.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Setting = default;
        //    }

        //    if (Setting is object)
        //    {
        //        Setting.Value = Country;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Update(DataContext, Setting);
        //    }
        //    else
        //    {
        //        Setting = new AdvantageFramework.Core.Database.Entities.Setting();
        //        Setting.DataContext = DataContext;
        //        Setting.Code = AdvantageFramework.Agency.Settings.COUNTRY.ToString;
        //        Setting.Description = "Country";
        //        Setting.Value = Country;
        //        Setting.DefaultValue = null;
        //        Setting.SettingDatabaseTypeID = 19;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Insert(DataContext, Setting);
        //    }

        //    SaveCountryRet = Saved;
        //    return SaveCountryRet;
        //}

        //public static string GetOptionAvaTaxAccountNumber(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    string GetOptionAvaTaxAccountNumberRet = default;
        //    try
        //    {
        //        GetOptionAvaTaxAccountNumberRet = DbContext.Database.SqlQuery<string>(string.Format("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AVATAX_ACCT_NUMBER.ToString)).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionAvaTaxAccountNumberRet = null;
        //    }

        //    return GetOptionAvaTaxAccountNumberRet;
        //}

        //public static string GetOptionAvaTaxLicenseKey(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    string GetOptionAvaTaxLicenseKeyRet = default;
        //    try
        //    {
        //        GetOptionAvaTaxLicenseKeyRet = DbContext.Database.SqlQuery<string>(string.Format("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AVATAX_LICENSE_KEY.ToString)).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionAvaTaxLicenseKeyRet = null;
        //    }

        //    return GetOptionAvaTaxLicenseKeyRet;
        //}

        //public static string GetOptionAvaTaxURL(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    string GetOptionAvaTaxURLRet = default;
        //    try
        //    {
        //        GetOptionAvaTaxURLRet = DbContext.Database.SqlQuery<string>(string.Format("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AVATAX_URL.ToString)).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionAvaTaxURLRet = null;
        //    }

        //    return GetOptionAvaTaxURLRet;
        //}

        //public static bool GetOptionAvaTaxEnabled(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    bool GetOptionAvaTaxEnabledRet = default;
        //    try
        //    {
        //        GetOptionAvaTaxEnabledRet = DbContext.Database.SqlQuery<string>(string.Format("SELECT CAST([AGY_SETTINGS_VALUE] as varchar(1)) FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AVATAX_ENABLED.ToString)).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionAvaTaxEnabledRet = false;
        //    }

        //    return GetOptionAvaTaxEnabledRet;
        //}

        //public static bool GetOptionAvaTaxAddressValidationEnabled(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    bool GetOptionAvaTaxAddressValidationEnabledRet = default;
        //    try
        //    {
        //        GetOptionAvaTaxAddressValidationEnabledRet = DbContext.Database.SqlQuery<string>(string.Format("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AVATAX_ADR_ENABLED.ToString)).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionAvaTaxAddressValidationEnabledRet = false;
        //    }

        //    return GetOptionAvaTaxAddressValidationEnabledRet;
        //}

        //public static List<string> GetOptionAvaTaxEnableAddressValidationForCountries(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    List<string> GetOptionAvaTaxEnableAddressValidationForCountriesRet = default;
        //    string Countries = null;
        //    try
        //    {
        //        Countries = DbContext.Database.SqlQuery<string>(string.Format("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AVATAX_ADR_COUNTRIES.ToString)).SingleOrDefault;
        //        if (Countries is object)
        //        {
        //            GetOptionAvaTaxEnableAddressValidationForCountriesRet = Countries.Split(",").ToList();
        //        }
        //        else
        //        {
        //            GetOptionAvaTaxEnableAddressValidationForCountriesRet = null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionAvaTaxEnableAddressValidationForCountriesRet = null;
        //    }

        //    return GetOptionAvaTaxEnableAddressValidationForCountriesRet;
        //}

        //public static bool GetOptionAvaTaxUseClientStreetAddress(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    bool GetOptionAvaTaxUseClientStreetAddressRet = default;
        //    try
        //    {
        //        GetOptionAvaTaxUseClientStreetAddressRet = DbContext.Database.SqlQuery<string>(string.Format("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AVATAX_USE_CL_ADDR.ToString)).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionAvaTaxUseClientStreetAddressRet = false;
        //    }

        //    return GetOptionAvaTaxUseClientStreetAddressRet;
        //}

        //public static bool GetOptionAvaTaxUseJobContactAddress(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    bool GetOptionAvaTaxUseJobContactAddressRet = default;
        //    try
        //    {
        //        GetOptionAvaTaxUseJobContactAddressRet = DbContext.Database.SqlQuery<string>(string.Format("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AVATAX_USE_JC_ADDR.ToString)).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionAvaTaxUseJobContactAddressRet = false;
        //    }

        //    return GetOptionAvaTaxUseJobContactAddressRet;
        //}

        //public static bool GetOptionDefaultAPDescriptionFromVendorAccount(AdvantageFramework.Core.Database.DataContext DataContext)
        //{
        //    bool GetOptionDefaultAPDescriptionFromVendorAccountRet = default;
        //    AdvantageFramework.Core.Database.Entities.Setting Setting = default;
        //    bool DefaultFromVendorAccount = false;
        //    try
        //    {
        //        Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.AP_DEF_DESC_VEN_ACCT.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Setting = default;
        //    }

        //    if (Setting is object && Information.IsNumeric(Setting.Value) && (int)Setting.Value == 1)
        //    {
        //        DefaultFromVendorAccount = true;
        //    }

        //    GetOptionDefaultAPDescriptionFromVendorAccountRet = DefaultFromVendorAccount;
        //    return GetOptionDefaultAPDescriptionFromVendorAccountRet;
        //}

        //public static int GetOptionAPApprovalAlertDefaultTemplate(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    int GetOptionAPApprovalAlertDefaultTemplateRet = default;
        //    try
        //    {
        //        GetOptionAPApprovalAlertDefaultTemplateRet = DbContext.Database.SqlQuery<int>("SELECT COALESCE(CAST([AGY_SETTINGS_VALUE] AS INT), 0) FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'AP_APPR_DFLT_TMPLT'").SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionAPApprovalAlertDefaultTemplateRet = 0;
        //    }

        //    return GetOptionAPApprovalAlertDefaultTemplateRet;
        //}

        //public static int GetOptionAPApprovalAlertDefaultState(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    int GetOptionAPApprovalAlertDefaultStateRet = default;
        //    try
        //    {
        //        GetOptionAPApprovalAlertDefaultStateRet = DbContext.Database.SqlQuery<int>("SELECT COALESCE(CAST([AGY_SETTINGS_VALUE] AS INT), 0) FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'AP_APPR_DFLT_STATE'").SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionAPApprovalAlertDefaultStateRet = 0;
        //    }

        //    return GetOptionAPApprovalAlertDefaultStateRet;
        //}

        //public static bool GetOptionAPMediaImportAlertBuyer(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    bool GetOptionAPMediaImportAlertBuyerRet = default;
        //    try
        //    {
        //        GetOptionAPMediaImportAlertBuyerRet = DbContext.Database.SqlQuery<string>("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'IMP_ALERT_BUYER'").SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionAPMediaImportAlertBuyerRet = false;
        //    }

        //    return GetOptionAPMediaImportAlertBuyerRet;
        //}

        //public static bool GetOptionAPMediaApprovalAlertAP(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    bool GetOptionAPMediaApprovalAlertAPRet = default;
        //    try
        //    {
        //        GetOptionAPMediaApprovalAlertAPRet = DbContext.Database.SqlQuery<string>("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'AP_APPR_ALERT_AP'").SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionAPMediaApprovalAlertAPRet = false;
        //    }

        //    return GetOptionAPMediaApprovalAlertAPRet;
        //}

        //public static short GetOptionAPMediaApprovalAlertAPUser(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    short GetOptionAPMediaApprovalAlertAPUserRet = default;
        //    try
        //    {
        //        GetOptionAPMediaApprovalAlertAPUserRet = DbContext.Database.SqlQuery<string>("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'AP_APPR_ALERT_USER'").SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionAPMediaApprovalAlertAPUserRet = 0;
        //    }

        //    return GetOptionAPMediaApprovalAlertAPUserRet;
        //}

        //public static string GetOptionAPDefaultAlertGroup(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    string GetOptionAPDefaultAlertGroupRet = default;
        //    try
        //    {
        //        GetOptionAPDefaultAlertGroupRet = DbContext.Database.SqlQuery<string>("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'AP_APPR_ALERT_GROUP'").SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionAPDefaultAlertGroupRet = "";
        //    }

        //    return GetOptionAPDefaultAlertGroupRet;
        //}

        public static bool LoadMediaExcludeOrderPDFWithEmail(AdvantageFramework.Core.Database.DataContext DataContext)
        {
            bool LoadMediaExcludeOrderPDFWithEmailRet = default;
            AdvantageFramework.Core.Database.Entities.Setting Setting = default;
            bool MediaExcludeOrderPDFWithEmail = false;
            try
            {
                Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.MEDIA_EXCL_ORD_PDF.ToString());
            }
            catch (Exception ex)
            {
                Setting = default;
            }

            if (Setting is object)
            {
                MediaExcludeOrderPDFWithEmail = (bool)Setting.Value;
            }

            LoadMediaExcludeOrderPDFWithEmailRet = MediaExcludeOrderPDFWithEmail;
            return LoadMediaExcludeOrderPDFWithEmailRet;
        }

        //public static bool SaveMediaExcludeOrderPDFWithEmail(AdvantageFramework.Core.Database.DataContext DataContext, bool MediaExcludeOrderPDFWithEmail)
        //{
        //    bool SaveMediaExcludeOrderPDFWithEmailRet = default;
        //    AdvantageFramework.Core.Database.Entities.Setting Setting = default;
        //    bool Saved = false;
        //    try
        //    {
        //        Setting = AdvantageFramework.Core.Database.Procedures.Settings.LoadBySettingCode(DataContext, Settings.MEDIA_EXCL_ORD_PDF.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Setting = default;
        //    }

        //    if (Setting is object)
        //    {
        //        Setting.Value = MediaExcludeOrderPDFWithEmail;
        //        Saved = AdvantageFramework.Core.Database.Procedures.Settings.Update(DataContext, Setting);
        //    }

        //    SaveMediaExcludeOrderPDFWithEmailRet = Saved;
        //    return SaveMediaExcludeOrderPDFWithEmailRet;
        //}

        // please test if you change the below
        //public static string GetValue(string ConnectionString, string UserCode, Settings Setting)
        //{
        //    string GetValueRet = default;

        //    // objects
        //    string SettingValue = "";
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(ConnectionString, UserCode))
        //    {
        //        SettingValue = GetValue(DbContext, Setting);
        //    }

        //    GetValueRet = SettingValue;
        //    return GetValueRet;
        //}

        //public static string GetValue(AdvantageFramework.Core.Security.Session Session, Settings Setting)
        //{
        //    string GetValueRet = default;

        //    // objects
        //    string SettingValue = "";
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //    {
        //        SettingValue = GetValue(DbContext, Setting);
        //    }

        //    GetValueRet = SettingValue;
        //    return GetValueRet;
        //}

        //public static string GetValue(AdvantageFramework.Core.Database.DbContext DbContext, Settings Setting)
        //{
        //    string GetValueRet = default;

        //    // objects
        //    string SettingValue = "";
        //    try
        //    {
        //        SettingValue = DbContext.Database.SqlQuery<string>(string.Format("SELECT CAST(ISNULL(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF) AS VARCHAR(MAX)) AS AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = '{0}';", Setting.ToString())).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        SettingValue = "";
        //    }

        //    GetValueRet = SettingValue;
        //    return GetValueRet;
        //}

        //public static bool GetOptionAvaTaxUseJobSalesClass(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    bool GetOptionAvaTaxUseJobSalesClassRet = default;
        //    try
        //    {
        //        GetOptionAvaTaxUseJobSalesClassRet = DbContext.Database.SqlQuery<int>(string.Format("SELECT CAST([AGY_SETTINGS_VALUE] as int) FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AVATAX_USE_JOB_SC.ToString)).SingleOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        GetOptionAvaTaxUseJobSalesClassRet = false;
        //    }

        //    return GetOptionAvaTaxUseJobSalesClassRet;
        //}

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

        public static string GetWebvantageURL(string ConnectionString)
        {
            using (AdvantageFramework.Core.Database.DbContext DbContext = new AdvantageFramework.Core.Database.DbContext(ConnectionString))
            {
                return GetWebvantageURL(DbContext);
            }
        }

        public static string GetWebvantageURL(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            string rv = DbContext.Agency.FirstOrDefault().WebvantageUrl;

            return rv;
        }
    }
}
