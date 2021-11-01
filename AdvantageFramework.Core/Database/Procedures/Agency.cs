using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvantageFramework.Core.Database.Procedures
{
    public static class Agency
    {

        #region Constants



        #endregion

        #region Enum



        #endregion

        #region Variables



        #endregion

        #region Properties

        public static bool TimesheetAddUniqueRowWhenComment(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return DbContext.SqlQueryBool("SELECT CAST(ISNULL(TIME_UNIQUE_ROW, 0) AS BIT) FROM [dbo].[AGENCY] WITH(NOLOCK);");
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool TimesheetRequireAssignment(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return DbContext.SqlQueryBool("SELECT CAST(ISNULL(TIME_REQ_ASSN, 0) AS BIT) FROM [dbo].[AGENCY] WITH(NOLOCK);");
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool TimesheetCopyHours(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return (DbContext.SqlQueryBool("SELECT CAST(TS_COPY_HRS AS BIT) FROM [dbo].[AGENCY] WITH(NOLOCK);"));
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //public static bool ClearDetailTax(AdvantageFramework.Core.Database.DbContext DbContext, bool ApplyTaxUponBilling)
        //{

        //    // objects
        //    bool Cleared = true;
        //    System.Data.SqlClient.SqlParameter SqlParameterReturnValue = null;
        //    short InvoiceTaxFlag = 0;

        //    try
        //    {
        //        if (ApplyTaxUponBilling == true)
        //        {
        //            SqlParameterReturnValue = new System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int);
        //            SqlParameterReturnValue.Direction = ParameterDirection.Output;
        //            SqlParameterReturnValue.Value = 0;

        //            DbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_clear_detail_tax @ret_val OUTPUT", SqlParameterReturnValue);

        //            if (SqlParameterReturnValue.Value == null || System.Convert.ToInt32(SqlParameterReturnValue.Value) != 0)
        //                Cleared = false;
        //            else
        //                InvoiceTaxFlag = 1;
        //        }

        //        DbContext.Database.ExecuteSqlCommand(string.Format("UPDATE [dbo].[AGENCY] WITH(ROWLOCK) SET [INV_TAX_FLAG] = {0};", InvoiceTaxFlag));
        //    }
        //    catch (Exception ex)
        //    {
        //        Cleared = false;
        //    }

        //    return Cleared;
        //}
        public static bool InvoiceTaxFlag(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return (DbContext.SqlQueryBool("SELECT INV_TAX_FLAG FROM [dbo].[AGENCY] WITH(NOLOCK);") == true);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool JobComponentTaxable(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return (DbContext.SqlQueryShort("SELECT ISNULL(FLAG_TAX_JOBS, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);") == 1);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static short APLockGLAccountCode(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return DbContext.SqlQueryShort("SELECT ISNULL(AP_LOCK_GLCODE, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);");
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static short APFlagVendor1099(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return DbContext.SqlQueryShort("SELECT ISNULL(FLAG_1099, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);");
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static bool APViewDeletedInvoices(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return (DbContext.SqlQueryShort("SELECT ISNULL(DELETE_INVOICE, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);") == 1);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool IsAPLimitByOfficeEnabled(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return (DbContext.SqlQueryShort("SELECT ISNULL(AP_OFFICE, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);") == 1);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool IsInterCompanyTransactionsEnabled(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return (DbContext.SqlQueryShort("SELECT ISNULL(INTER_COMPANY, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);") == 1);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool AllowCostOfSaleEntry(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return (DbContext.SqlQueryShort("SELECT ISNULL(COS_ENTRY_FLAG, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);") == 1);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool UseAPAccountOnImport(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return (DbContext.SqlQueryShort("SELECT ISNULL(AP_ACCT_OFF_IMP, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);") == 1);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool APShowPayToInformation(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return (DbContext.SqlQueryShort("SELECT ISNULL(VN_PAY_TO_INFO, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);") == 1);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool ActivateApprovals(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return (DbContext.SqlQueryShort("SELECT ISNULL(AP_APPROVAL, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);") == 1);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //public static Nullable<decimal> PrintMediaPercent(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    try
        //    {
        //        return (DbContext.Database.SqlQuery<Nullable<decimal>>("SELECT AP_APP_PRINT_PCT FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault);
        //    }
        //    catch (Exception ex)
        //    {
        //        return default(Decimal?);
        //    }
        //}
        //public static Nullable<decimal> InternetPercent(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    try
        //    {
        //        return (DbContext.Database.SqlQuery<Nullable<decimal>>("SELECT AP_APP_INET_PCT FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault);
        //    }
        //    catch (Exception ex)
        //    {
        //        return default(Decimal?);
        //    }
        //}
        //public static Nullable<decimal> OutOfHomePercent(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    try
        //    {
        //        return (DbContext.Database.SqlQuery<Nullable<decimal>>("SELECT AP_APP_OOH_PCT FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault);
        //    }
        //    catch (Exception ex)
        //    {
        //        return default(Decimal?);
        //    }
        //}
        //public static Nullable<decimal> RadioPercent(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    try
        //    {
        //        return (DbContext.Database.SqlQuery<Nullable<decimal>>("SELECT AP_APP_RADIO_PCT FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault);
        //    }
        //    catch (Exception ex)
        //    {
        //        return default(Decimal?);
        //    }
        //}
        //public static Nullable<decimal> TelevisionPercent(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    try
        //    {
        //        return (DbContext.Database.SqlQuery<Nullable<decimal>>("SELECT AP_APP_TV_PCT FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault);
        //    }
        //    catch (Exception ex)
        //    {
        //        return default(Decimal?);
        //    }
        //}
        public static bool APPOMessage(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return (DbContext.SqlQueryShort("SELECT ISNULL(AP_PO_MESSAGE, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);") == 1);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //public static string APPOMessageText(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    try
        //    {
        //        return (DbContext.Database.SqlQuery<string>("SELECT AP_PO_MESSAGE_TEXT FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        public static bool APPOReject(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return (DbContext.SqlQueryShort("SELECT ISNULL(AP_PO_REJECT, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);") == 1);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //public static string APPORejectText(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    try
        //    {
        //        return (DbContext.Database.SqlQuery<string>("SELECT AP_PO_REJECT_TEXT FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        public static bool IsAgencyASP(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return (DbContext.SqlQueryShort("SELECT ISNULL(ASP_ACTIVE, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);") == 1);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //public static string GetHomeCurrency(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    try
        //    {
        //        return (DbContext.Database.SqlQuery<string>("SELECT HOME_CRNCY FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        //public static string LoadReportTempPath(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    try
        //    {
        //        return DbContext.Database.SqlQuery<string>("SELECT ISNULL(ACCESS_TMP_PATH, '') FROM [dbo].[AGENCY] WITH(NOLOCK);");
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}
        //public static string LoadReportPath(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    try
        //    {
        //        return DbContext.Database.SqlQuery<string>("SELECT ISNULL(ACCESS_RPT_PATH, '') FROM [dbo].[AGENCY] WITH(NOLOCK);");
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}
        //public static string LoadLogoPath(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    try
        //    {
        //        return DbContext.Database.SqlQuery<string>("SELECT ISNULL(LOGO, '') FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}
        //public static string LoadName(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    try
        //    {
        //        return DbContext.Database.SqlQuery<string>("SELECT ISNULL(NAME, '') FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}
        //public static string LoadImportPath(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    try
        //    {
        //        return DbContext.Database.SqlQuery<string>("SELECT ISNULL(IMPORT_PATH, '') FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}
        public static string LoadFileSystemDirectory(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return "";
                //TODO Fix this
                //return DbContext.Database.SqlQuery<string>("SELECT ISNULL(DOC_REPOSITORY_PATH, '') FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        //public static string LoadLicenseKey(AdvantageFramework.Core.Database.DbContext DbContext)
        //{
        //    try
        //    {
        //        return DbContext.Database.SqlQuery<string>("SELECT ISNULL(LICENSE_KEY, '') FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault;
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}
        public static bool IsMultiCurrencyEnabled(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return (DbContext.SqlQueryShort("SELECT ISNULL(MULTI_CRNCY, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);") == 1);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static AdvantageFramework.Core.Database.Entities.Agency Load(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return DbContext.Agency.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool ValidateClosedArchivedJobs(AdvantageFramework.Core.Database.DbContext DbContext)
        {
            try
            {
                return (DbContext.SqlQueryShort("SELECT ISNULL(VALIDATE_JOB_CLOSE, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);") == 1);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //public static bool Update(AdvantageFramework.Core.Database.DbContext DbContext, AdvantageFramework.Database.Entities.Agency Agency)
        //{

        //    // objects
        //    bool Updated = false;
        //    bool IsValid = true;
        //    string ErrorText = "";

        //    try
        //    {
        //        DbContext.UpdateObject(Agency);

        //        ErrorText = Agency.ValidateEntity(IsValid);

        //        if (IsValid)
        //        {
        //            if (DbContext.Database.ExecuteSqlCommand(string.Format("UPDATE [dbo].[AGENCY] SET " + "ACCESS_RPT_PATH = {0}, " + "ACCESS_TMP_PATH = {1}, " + "ACCT_NBR_R = {2}, " + "AP_IMPORT_TYPE = {3}, " + "AP_APPROVAL = {4}, " + "AUTO_EMAIL = {5}, " + "ADDRESS1 = {6}, " + "ADDRESS2 = {7}, " + "CHK_BODY_LINES_DN = {8}, " + "CHK_STUB_LINES_UP = {9}, " + "AD_NBR_R = {10}, " + "EMAIL_GR_CODE_R = {11}, " + "AP_CALC_PO = {12}, " + "CHECK_FORMAT = {13}, " + "FLAG_1099 = {14}, " + "AP_OFFICE = {15}, " + "AP_LOCK_GLCODE = {16}, " + "NON_CLIENT_GL_DET = {17}, " + "AP_PO_MESSAGE = {18}, " + "AP_PO_MESSAGE_TEXT = {19}, " + "AP_PO_REJECT = {20}, " + "AP_PO_REJECT_TEXT = {21}, " + "APPR_EST_REQ = {22}, " + "VN_PAY_TO_INFO = {23}, " + "DELETE_INVOICE = {24}, " + "AUTO_ALERT_SUPER = {25}, " + "BLACKPLATE_VER_R = {26}, " + "BLACKPLATE_VER2_R = {27}, " + "CMP_CODE_R = {28}, " + "WORD_CHECK_AMT = {29}, " + "TS_PPERIOD_CHK = {30}, " + "CITY = {31}, " + "CONTACT_OPT = {32}, " + "JOB_CLI_REF_R = {33}, " + "COIN_TEXT = {34}, " + "COMPLEX_CODE_R = {35}, " + "JOB_COMP_BUDGET_R = {36}, " + "BILL_COOP_CODE_R = {37}, " + "COPY_TS = {38}, " + "COUNTRY = {39}, " + "CRNCY_IMPORT_TYPE = {40}, " + "CURRENCY_SYMBOL = {41}, " + "CURRENCY_TEXT = {42}, " + "JOB_DATE_OPENED_R = {43}, " + "DEF_EMAIL_GROUP = {44}, " + "TS_DAYS_PER_WK = {45}, " + "DP_TM_CODE_R = {46}, " + "JOB_FIRST_USE_DT_R = {47}, " + "EDIT_JOB_REQ_EST = {48}, " + "EMAIL_IT_CONTACT = {49}, " + "EMAIL_PWD = {50}, " + "EMAIL_SUPERVISOR = {51}, " + "EMAIL_USERNAME = {52}, " + "EMP_NOTES = {53}, " + "ALERT_NOTIFY = {54}, " + "ENABLE_ATTACHMENTS = {55}, " + "USE_PROD_CAT = {56}, " + "START_END_TIME = {57}, " + "EST_COMMENT = {58}, " + "EMAIL_ATTACH_DEF = {59}, " + "DOC_REPOSITORY_PATH = {60}, " + "DOC_REPOSITORY_USER_DOMAIN = {61}, " + "DOC_REPOSITORY_USER_PASSWORD = {62}, " + "DOC_REPOSITORY_USER_NAME = {63}, " + "FISCAL_PD_R = {64}, " + "JOB_AD_SIZE_R = {65}, " + "NOBILL_FLAG_H = {66}, " + "IMPORT_PATH = {67}, " + "EMP_ON_ALERT_LIST = {68}, " + "PDF_ALERT_ONLY = {69}, " + "IO_IMPORT_TYPE = {70}, " + "INTER_COMPANY = {71}, " + "INET_COMMENT = {72}, " + "AP_APP_INET_PCT = {73}, " + "ASP_ACTIVE = {74}, " + "IT_CONTACT_EMAIL = {75}, " + "JOB_CMP_UDV1_R = {76}, " + "JOB_CMP_UDV2_R = {77}, " + "JOB_CMP_UDV3_R = {78}, " + "JOB_CMP_UDV4_R = {79}, " + "JOB_CMP_UDV5_R = {80}, " + "FLAG_TAX_JOBS = {81}, " + "JOB_LOG_UDV1_R = {82}, " + "JOB_LOG_UDV2_R = {83}, " + "JOB_LOG_UDV3_R = {84}, " + "JOB_LOG_UDV4_R = {85}, " + "JOB_LOG_UDV5_R = {86}, " + "JT_CODE_R = {87}, " + "LICENSE_KEY = {88}, " + "MAG_COMMENT = {89}, " + "MB_KEY = {90}, " + "MARKET_CODE_R = {91}, " + "MD_INTERFACE = {92}, " + "NAME = {93}, " + "NEWS_COMMENT = {94}, " + "MRP_DSN = {95}, " + "EDIT_OFFICE = {96}, " + "OTDR_COMMENT = {97}, " + "AP_APP_OOH_PCT = {98}, " + "PHONE = {99}, " + "PO_AMT_REQ = {100}, " + "PO_FOOTER = {101}, " + "POP3_AUTH_METHOD = {102}, " + "POP3_REPLY_TO = {103}, " + "POP3_DEL_PROCESSED = {104}, " + "POP3_PWD = {105}, " + "POP3_PORT_NUMBER = {106}, " + "POP3_SECURE_TYPE = {107}, " + "POP3_SERVER = {108}, " + "POP3_USERNAME = {109}, " + "AP_APP_PRINT_PCT = {110}, " + "VN_ACCT_NBR = {111}, " + "PROD_CONT_CODE_R = {112}, " + "PROMO_CODE_R = {113}, " + "QA_PWD_REQ = {114}, " + "QVA_QUERY = {115}, " + "RADIO_COMMENT = {116}, " + "AP_APP_RADIO_PCT = {117}, " + "MD_RENAME = {118}, " + "EMAIL_REPLY_TO = {119}, " + "AUTO_EST_REV = {120}, " + "BILL_MEDIA_TYPE = {121}, " + "FORMAT_SC_CODE_R = {122}, " + "SERVICE_FEE_TYPE_R = {123}, " + "CR_AR_DESC = {124}, " + "SMTP_AUTH_METHOD = {125}, " + "SMTP_SENDER_PWD = {126}, " + "SMTP_PORT_NUMBER = {127}, " + "SMTP_SECURE_TYPE = {128}, " + "SMTP_SERVER = {129}, " + "SMTP_SENDER = {130}, " + "STATE = {131}, " + "STRATA_PATH = {132}, " + "TIME_APPR_ACTIVE = {133}, " + "EDIT_OTHER_TIME = {134}, " + "TAX_FLAG_R = {135}, " + "TV_COMMENT = {136}, " + "AP_APP_TV_PCT = {137}, " + "TIME_COMMENTS_REQ = {138}, " + "CLIENT_REF = {139}, " + "AP_ACCT_OFF_IMP = {140}, " + "ET_BATCH = {141}, " + "SMTP_USE_EMP_LOGIN = {142}, " + "GL_FILTER = {143}, " + "USE_SMTP_FOR_PDF = {144}, " + "VALIDATE_JOB_CLOSE = {145}, " + "WEBVANTAGE_URL = {146}, " + "WEEKLY_TIME = {147}, " + "ZIP = {148}, " + "HOME_CRNCY = {149}, " + "COUNTY = {150}, " + "COS_ENTRY_FLAG = {151}, " + "EDIT_CDP = {152}, " + "TIMEZONE_ID = {153}, " + "DB_TIMEZONE_ID = {154}, " + "CLIENTPORTAL_URL = {155}, " + "TIME_REQ_ASSN = {156}, " + "TIME_UNIQUE_ROW = {157}, " + "ALLOW_PROOFHQ = {158} ", Agency.AccessReportPath != null ? "'" + Agency.AccessReportPath.Replace("'", "''") + "'" : "NULL", Agency.AccessReportTemporaryPath != null ? "'" + Agency.AccessReportTemporaryPath.Replace("'", "''") + "'" : "NULL", Agency.AccountNumberRequired.GetValueOrDefault(0), Agency.AccountPayableImportType != null ? "'" + Agency.AccountPayableImportType.Replace("'", "''") + "'" : "NULL", Agency.ActivateApprovals.GetValueOrDefault(0), Agency.ActivateSystemAlerts.GetValueOrDefault(0), Agency.Address != null ? "'" + Agency.Address.Replace("'", "''") + "'" : "NULL", Agency.Address2 != null ? "'" + Agency.Address2.Replace("'", "''") + "'" : "NULL", Agency.AdjustCheckBodyLinesDown.GetValueOrDefault(0), Agency.AdjustCheckStubLinesUp.GetValueOrDefault(0), Agency.AdNumberRequired.GetValueOrDefault(0), Agency.AlertGroupRequired.GetValueOrDefault(0), Agency.APCalculatePOBalance.GetValueOrDefault(0), Agency.APComputerCheckFormat.GetValueOrDefault(0), Agency.APFlagVendor1099.GetValueOrDefault(0), Agency.APLimitByOffice.GetValueOrDefault(0), Agency.APLockGLAccountCode.GetValueOrDefault(0), Agency.APNonClientGLDetail.GetValueOrDefault(0), Agency.APPOMessage.GetValueOrDefault(0), Agency.APPOMessageText != null ? "'" + Agency.APPOMessageText.Replace("'", "''") + "'" : "NULL", Agency.APPOReject.GetValueOrDefault(0), Agency.APPORejectText != null ? "'" + Agency.APPORejectText.Replace("'", "''") + "'" : "NULL", Agency.ApprovedEstimateRequired.GetValueOrDefault(0), Agency.APShowPayToInformation.GetValueOrDefault(0), Agency.APViewDeletedInvoices.GetValueOrDefault(0), Agency.AutoAlertSupervisor.GetValueOrDefault(0), Agency.Blackplate1Required.GetValueOrDefault(0), Agency.Blackplate2Required.GetValueOrDefault(0), Agency.CampaignCodeRequired.GetValueOrDefault(0), Agency.CheckAmountInWords.GetValueOrDefault(0), Agency.CheckClosedPeriods.GetValueOrDefault(0), Agency.City != null ? "'" + Agency.City.Replace("'", "''") + "'" : "NULL", Agency.ClientContactOption.GetValueOrDefault(0), Agency.ClientReferenceRequired.GetValueOrDefault(0), Agency.CoinText != null ? "'" + Agency.CoinText.Replace("'", "''") + "'" : "NULL", Agency.ComplexityCodeRequired.GetValueOrDefault(0), Agency.ComponentBudgetRequired.GetValueOrDefault(0), Agency.CoopBillingCodeRequired.GetValueOrDefault(0), Agency.CopyTimesheetFeature.GetValueOrDefault(0), Agency.Country != null ? "'" + Agency.Country.Replace("'", "''") + "'" : "NULL", Agency.CurrencyRateImportType != null ? "'" + Agency.CurrencyRateImportType.Replace("'", "''") + "'" : "NULL", Agency.CurrencySymbol != null ? "'" + Agency.CurrencySymbol.Replace("'", "''") + "'" : "NULL", Agency.CurrencyText != null ? "'" + Agency.CurrencyText.Replace("'", "''") + "'" : "NULL", Agency.DateOpenedRequired.GetValueOrDefault(0), Agency.DefaultAlertGroup != null ? "'" + Agency.DefaultAlertGroup.Replace("'", "''") + "'" : "NULL", Agency.DefaultDisplayDays.GetValueOrDefault(0), Agency.DepartmentTeamRequired.GetValueOrDefault(0), Agency.DueDateRequired.GetValueOrDefault(0), Agency.EditJobRequiredEstimate.GetValueOrDefault(0), Agency.EmailITContact.GetValueOrDefault(0), Agency.EmailPassword != null ? "'" + Agency.EmailPassword.Replace("'", "''") + "'" : "NULL", Agency.EmailSupervisor.GetValueOrDefault(0), Agency.EmailUserName != null ? "'" + Agency.EmailUserName.Replace("'", "''") + "'" : "NULL", Agency.EmployeeNote, Agency.EnableAlertNotification.GetValueOrDefault(0), Agency.EnableAttachmentsInJobJacket.GetValueOrDefault(0), Agency.EnableProductCategory.GetValueOrDefault(0), Agency.EnableStartEndTimeRealTIME.GetValueOrDefault(0), Agency.EstimateDefaultComments != null ? "'" + Agency.EstimateDefaultComments.Replace("'", "''") + "'" : "NULL", Agency.ExcludeAttachmentByDefault.GetValueOrDefault(0), Agency.FileSystemDirectory != null ? "'" + Agency.FileSystemDirectory.Replace("'", "''") + "'" : "NULL", Agency.FileSystemDomain != null ? "'" + Agency.FileSystemDomain.Replace("'", "''") + "'" : "NULL", Agency.FileSystemPassword != null ? "'" + Agency.FileSystemPassword.Replace("'", "''") + "'" : "NULL", Agency.FileSystemUserName != null ? "'" + Agency.FileSystemUserName.Replace("'", "''") + "'" : "NULL", Agency.FiscalPeriodRequired.GetValueOrDefault(0), Agency.FormatAdSizeRequired.GetValueOrDefault(0), Agency.HideNonBillableFlag.GetValueOrDefault(0), Agency.ImportPath != null ? "'" + Agency.ImportPath.Replace("'", "''") + "'" : "NULL", Agency.IncludeAlertGroups.GetValueOrDefault(0), Agency.IncludeAttachmentsWithAlerts.GetValueOrDefault(0), Agency.IncomeOnlyImportType != null ? "'" + Agency.IncomeOnlyImportType.Replace("'", "''") + "'" : "NULL", Agency.InterCompanyTransactions.GetValueOrDefault(0), Agency.InternetFooterComments != null ? "'" + Agency.InternetFooterComments.Replace("'", "''") + "'" : "NULL", Agency.InternetPercent.HasValue ? Agency.InternetPercent : "NULL", Agency.IsASP.GetValueOrDefault(0), Agency.ITContactEmail != null ? "'" + Agency.ITContactEmail.Replace("'", "''") + "'" : "NULL", Agency.JobComponentCustom1.GetValueOrDefault(0), Agency.JobComponentCustom2.GetValueOrDefault(0), Agency.JobComponentCustom3.GetValueOrDefault(0), Agency.JobComponentCustom4.GetValueOrDefault(0), Agency.JobComponentCustom5.GetValueOrDefault(0), Agency.JobComponentTaxable.GetValueOrDefault(0), Agency.JobLogCustom1.GetValueOrDefault(0), Agency.JobLogCustom2.GetValueOrDefault(0), Agency.JobLogCustom3.GetValueOrDefault(0), Agency.JobLogCustom4.GetValueOrDefault(0), Agency.JobLogCustom5.GetValueOrDefault(0), Agency.JobTypeRequired.GetValueOrDefault(0), Agency.LicenseKey != null ? "'" + Agency.LicenseKey.Replace("'", "''") + "'" : "NULL", Agency.MagazineFooterComments != null ? "'" + Agency.MagazineFooterComments.Replace("'", "''") + "'" : "NULL", Agency.MailBeeLicenseKey != null ? "'" + Agency.MailBeeLicenseKey.Replace("'", "''") + "'" : "NULL", Agency.MarketCodeRequired.GetValueOrDefault(0), Agency.MediaImportDefault != null ? "'" + Agency.MediaImportDefault.Replace("'", "''") + "'" : "NULL", Agency.Name != null ? "'" + Agency.Name.Replace("'", "''") + "'" : "NULL", Agency.NewspaperFooterComments != null ? "'" + Agency.NewspaperFooterComments.Replace("'", "''") + "'" : "NULL", Agency.NFusionDatasourceName != null ? "'" + Agency.NFusionDatasourceName.Replace("'", "''") + "'" : "NULL", Agency.OfficeCodeOverride.GetValueOrDefault(0), Agency.OutOfHomeFooterComments != null ? "'" + Agency.OutOfHomeFooterComments.Replace("'", "''") + "'" : "NULL", Agency.OutOfHomePercent.HasValue ? Agency.OutOfHomePercent : "NULL", Agency.Phone != null ? "'" + Agency.Phone.Replace("'", "''") + "'" : "NULL", Agency.POAmountRequired.GetValueOrDefault(0), Agency.POFooterComments != null ? "'" + Agency.POFooterComments.Replace("'", "''") + "'" : "NULL", Agency.POP3AuthenticationMethod.GetValueOrDefault(0), Agency.POP3DefaultReplyToEmail != null ? "'" + Agency.POP3DefaultReplyToEmail.Replace("'", "''") + "'" : "NULL", Agency.POP3DeleteMessages.GetValueOrDefault(0), Agency.POP3Password != null ? "'" + Agency.POP3Password.Replace("'", "''") + "'" : "NULL", Agency.POP3PortNumber.GetValueOrDefault(0), Agency.POP3SecureType.GetValueOrDefault(0), Agency.POP3Server != null ? "'" + Agency.POP3Server.Replace("'", "''") + "'" : "NULL", Agency.POP3UserName != null ? "'" + Agency.POP3UserName.Replace("'", "''") + "'" : "NULL", Agency.PrintMediaPercent.HasValue ? Agency.PrintMediaPercent : "NULL", Agency.PrintVendorAccountNumber.GetValueOrDefault(0), Agency.ProductContactRequired.GetValueOrDefault(0), Agency.PromotionRequired.GetValueOrDefault(0), Agency.QuoteApprovalPasswordRequired.GetValueOrDefault(0), Agency.QVAQuery.GetValueOrDefault(0), Agency.RadioFooterComments != null ? "'" + Agency.RadioFooterComments.Replace("'", "''") + "'" : "NULL", Agency.RadioPercent.HasValue ? Agency.RadioPercent : "NULL", Agency.RenameFinanceFile.GetValueOrDefault(0), Agency.ReplyToEmail != null ? "'" + Agency.ReplyToEmail.Replace("'", "''") + "'" : "NULL", Agency.RequireNewRevisions.GetValueOrDefault(0), Agency.RequireProductSetupComplete.GetValueOrDefault(0), Agency.SCFormatRequired.GetValueOrDefault(0), Agency.ServiceFeeTypeRequired.GetValueOrDefault(0), Agency.ShowARDescription.GetValueOrDefault(0), Agency.SMTPAuthenticationMethodType.GetValueOrDefault(0), Agency.SMTPPassword != null ? "'" + Agency.SMTPPassword.Replace("'", "''") + "'" : "NULL", Agency.SMTPPortNumber.GetValueOrDefault(0), Agency.SMTPSecurityType.GetValueOrDefault(0), Agency.SMTPServer != null ? "'" + Agency.SMTPServer.Replace("'", "''") + "'" : "NULL", Agency.SMTPUserName != null ? "'" + Agency.SMTPUserName.Replace("'", "''") + "'" : "NULL", Agency.State != null ? "'" + Agency.State.Replace("'", "''") + "'" : "NULL", Agency.StrataConnectPath != null ? "'" + Agency.StrataConnectPath.Replace("'", "''") + "'" : "NULL", Agency.SupervisorApprovalActive.GetValueOrDefault(0), Agency.SupervisorCanEditTime.GetValueOrDefault(0), Agency.TaxFlagRequired.GetValueOrDefault(0), Agency.TelevisionFooterComments != null ? "'" + Agency.TelevisionFooterComments.Replace("'", "''") + "'" : "NULL", Agency.TelevisionPercent.HasValue ? Agency.TelevisionPercent : "NULL", Agency.TimeCommentsRequired.GetValueOrDefault(0), Agency.UniqueClientReference.GetValueOrDefault(0), Agency.UseAPAccountOnImport.GetValueOrDefault(0), Agency.UseBatchMethod.GetValueOrDefault(0), Agency.UseEmployeeLogin.GetValueOrDefault(0), Agency.UseGLFilter.GetValueOrDefault(0), Agency.UseSMTPToSendPDF.GetValueOrDefault(0), Agency.ValidateJobClose.GetValueOrDefault(0), Agency.WebvantageURL != null ? "'" + Agency.WebvantageURL.Replace("'", "''") + "'" : "NULL", Agency.WeeklyTimeType.GetValueOrDefault(0), Agency.Zip != null ? "'" + Agency.Zip.Replace("'", "''") + "'" : "NULL", Agency.HomeCurrency != null ? "'" + Agency.HomeCurrency.Replace("'", "''") + "'" : "NULL", Agency.County != null ? "'" + Agency.County.Replace("'", "''") + "'" : "NULL", Agency.AllowCostOfSaleEntry, Agency.CDPOverride.GetValueOrDefault(0), Agency.TimeZoneID != null && string.IsNullOrWhiteSpace(Agency.TimeZoneID) == false ? "'" + Agency.TimeZoneID + "'" : "NULL", Agency.DatabaseServerTimeZoneID != null && string.IsNullOrWhiteSpace(Agency.DatabaseServerTimeZoneID) == false ? "'" + Agency.DatabaseServerTimeZoneID + "'" : "NULL", Agency.ClientPortalURL != null ? "'" + Agency.ClientPortalURL + "'" : "NULL", Agency.TimesheetRequireAssignment != null && Agency.TimesheetRequireAssignment == true ? 1 : 0, Agency.TimesheetAddUniqueRowWhenComment != null && Agency.TimesheetAddUniqueRowWhenComment == true ? 1 : 0, Agency.AllowProofHQ != null && Agency.AllowProofHQ == true ? 1 : 0)) > 0)
        //                Updated = true;
        //        }
        //        else
        //            AdvantageFramework.Core.Navigation.Methods.ShowMessageBox(ErrorText);
        //    }
        //    catch (Exception ex)
        //    {
        //        Updated = false;
        //    }

        //    return Updated;
        //}
        //public static bool UpdateAvaTaxEnabled(AdvantageFramework.Core.Database.DbContext DbContext, bool Enabled)
        //{
        //    bool Updated = true;

        //    try
        //    {
        //        DbContext.Database.ExecuteSqlCommand(string.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", Enabled ? 1 : 0, AdvantageFramework.Agency.Settings.AVATAX_ENABLED.ToString));
        //    }
        //    catch (Exception ex)
        //    {
        //        Updated = false;
        //    }

        //    return Updated;
        //}
        //public static bool UpdateTimesheetCopyHours(AdvantageFramework.Core.Database.DbContext DbContext, bool Enabled)
        //{
        //    bool Updated = true;

        //    try
        //    {
        //        DbContext.Database.ExecuteSqlCommand(string.Format("UPDATE [dbo].[AGENCY] SET [TS_COPY_HRS] = '{0}';", Enabled ? 1 : 0));
        //    }
        //    catch (Exception ex)
        //    {
        //        Updated = false;
        //    }

        //    return Updated;
        //}
        //public static bool UpdateTimesheetRequireAssignment(AdvantageFramework.Core.Database.DbContext DbContext, bool Enabled)
        //{
        //    bool Updated = true;

        //    try
        //    {
        //        DbContext.Database.ExecuteSqlCommand(string.Format("UPDATE [dbo].[AGENCY] SET [TIME_REQ_ASSN] = '{0}';", Enabled ? 1 : 0));
        //    }
        //    catch (Exception ex)
        //    {
        //        Updated = false;
        //    }

        //    return Updated;
        //}
        //public static bool UpdateTimesheetAddUniqueRowWhenComment(AdvantageFramework.Core.Database.DbContext DbContext, bool Enabled)
        //{
        //    bool Updated = true;

        //    try
        //    {
        //        DbContext.Database.ExecuteSqlCommand(string.Format("UPDATE [dbo].[AGENCY] SET [TIME_UNIQUE_ROW] = '{0}';", Enabled ? 1 : 0));
        //    }
        //    catch (Exception ex)
        //    {
        //        Updated = false;
        //    }

        //    return Updated;
        //}
        //public static bool UpdateAllowProofHQ(AdvantageFramework.Core.Database.DbContext DbContext, bool Enabled)
        //{
        //    bool Updated = true;

        //    try
        //    {
        //        DbContext.Database.ExecuteSqlCommand(string.Format("UPDATE [dbo].[AGENCY] SET [ALLOW_PROOFHQ] = {0};", Enabled == true ? 1 : 0));
        //    }
        //    catch (Exception ex)
        //    {
        //        Updated = false;
        //    }

        //    return Updated;
        //}

        #endregion

        #region Methods



        #endregion

    }
}
