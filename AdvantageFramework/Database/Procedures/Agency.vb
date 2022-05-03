Namespace Database.Procedures.Agency

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function TimesheetAddUniqueRowWhenComment(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                TimesheetAddUniqueRowWhenComment = (DbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(ISNULL(TIME_UNIQUE_ROW, 0) AS BIT) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault)

            Catch ex As Exception
                TimesheetAddUniqueRowWhenComment = False
            End Try

        End Function
        Public Function TimesheetRequireAssignment(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                TimesheetRequireAssignment = (DbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(ISNULL(TIME_REQ_ASSN, 0) AS BIT) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault)

            Catch ex As Exception
                TimesheetRequireAssignment = False
            End Try

        End Function
        Public Function TimesheetCopyHours(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                TimesheetCopyHours = (DbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(TS_COPY_HRS AS BIT) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault)

            Catch ex As Exception
                TimesheetCopyHours = False
            End Try

        End Function
        Public Function ClearDetailTax(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ApplyTaxUponBilling As Boolean) As Boolean

            'objects
            Dim Cleared As Boolean = True
            Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
            Dim InvoiceTaxFlag As Short = 0

            Try

                If ApplyTaxUponBilling = True Then

                    SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
                    SqlParameterReturnValue.Direction = ParameterDirection.Output
                    SqlParameterReturnValue.Value = 0

                    DbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_clear_detail_tax @ret_val OUTPUT", SqlParameterReturnValue)

                    If SqlParameterReturnValue.Value Is Nothing OrElse CInt(SqlParameterReturnValue.Value) <> 0 Then

                        Cleared = False

                    Else

                        InvoiceTaxFlag = 1

                    End If

                End If

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGENCY] WITH(ROWLOCK) SET [INV_TAX_FLAG] = {0};", InvoiceTaxFlag))

            Catch ex As Exception
                Cleared = False
            Finally
                ClearDetailTax = Cleared
            End Try

        End Function
        Public Function InvoiceTaxFlag(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                InvoiceTaxFlag = (DbContext.Database.SqlQuery(Of Boolean)("SELECT INV_TAX_FLAG FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault = True)

            Catch ex As Exception
                InvoiceTaxFlag = False
            End Try

        End Function
        Public Function JobComponentTaxable(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                JobComponentTaxable = (DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(FLAG_TAX_JOBS, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault = 1)

            Catch ex As Exception
                JobComponentTaxable = False
            End Try

        End Function
        Public Function APLockGLAccountCode(ByVal DbContext As AdvantageFramework.Database.DbContext) As Short

            Try

                APLockGLAccountCode = DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(AP_LOCK_GLCODE, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                APLockGLAccountCode = 0
            End Try

        End Function
        Public Function APFlagVendor1099(ByVal DbContext As AdvantageFramework.Database.DbContext) As Short

            Try

                APFlagVendor1099 = DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(FLAG_1099, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                APFlagVendor1099 = 0
            End Try

        End Function
        Public Function APViewDeletedInvoices(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                APViewDeletedInvoices = (DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(DELETE_INVOICE, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault = 1)

            Catch ex As Exception
                APViewDeletedInvoices = False
            End Try

        End Function
        Public Function IsAPLimitByOfficeEnabled(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                IsAPLimitByOfficeEnabled = (DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(AP_OFFICE, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault = 1)

            Catch ex As Exception
                IsAPLimitByOfficeEnabled = False
            End Try

        End Function
        Public Function IsInterCompanyTransactionsEnabled(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                IsInterCompanyTransactionsEnabled = (DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(INTER_COMPANY, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault = 1)

            Catch ex As Exception
                IsInterCompanyTransactionsEnabled = False
            End Try

        End Function
        Public Function AllowCostOfSaleEntry(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                AllowCostOfSaleEntry = (DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(COS_ENTRY_FLAG, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault = 1)

            Catch ex As Exception
                AllowCostOfSaleEntry = False
            End Try

        End Function
        Public Function UseAPAccountOnImport(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                UseAPAccountOnImport = (DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(AP_ACCT_OFF_IMP, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault = 1)

            Catch ex As Exception
                UseAPAccountOnImport = False
            End Try

        End Function
        Public Function APShowPayToInformation(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                APShowPayToInformation = (DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(VN_PAY_TO_INFO, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault = 1)

            Catch ex As Exception
                APShowPayToInformation = False
            End Try

        End Function
        Public Function ActivateApprovals(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                ActivateApprovals = (DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(AP_APPROVAL, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault = 1)

            Catch ex As Exception
                ActivateApprovals = False
            End Try

        End Function
        Public Function PrintMediaPercent(ByVal DbContext As AdvantageFramework.Database.DbContext) As Nullable(Of Decimal)

            Try

                PrintMediaPercent = (DbContext.Database.SqlQuery(Of Nullable(Of Decimal))("SELECT AP_APP_PRINT_PCT FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault)

            Catch ex As Exception
                PrintMediaPercent = Nothing
            End Try

        End Function
        Public Function InternetPercent(ByVal DbContext As AdvantageFramework.Database.DbContext) As Nullable(Of Decimal)

            Try

                InternetPercent = (DbContext.Database.SqlQuery(Of Nullable(Of Decimal))("SELECT AP_APP_INET_PCT FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault)

            Catch ex As Exception
                InternetPercent = Nothing
            End Try

        End Function
        Public Function OutOfHomePercent(ByVal DbContext As AdvantageFramework.Database.DbContext) As Nullable(Of Decimal)

            Try

                OutOfHomePercent = (DbContext.Database.SqlQuery(Of Nullable(Of Decimal))("SELECT AP_APP_OOH_PCT FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault)

            Catch ex As Exception
                OutOfHomePercent = Nothing
            End Try

        End Function
        Public Function RadioPercent(ByVal DbContext As AdvantageFramework.Database.DbContext) As Nullable(Of Decimal)

            Try

                RadioPercent = (DbContext.Database.SqlQuery(Of Nullable(Of Decimal))("SELECT AP_APP_RADIO_PCT FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault)

            Catch ex As Exception
                RadioPercent = Nothing
            End Try

        End Function
        Public Function TelevisionPercent(ByVal DbContext As AdvantageFramework.Database.DbContext) As Nullable(Of Decimal)

            Try

                TelevisionPercent = (DbContext.Database.SqlQuery(Of Nullable(Of Decimal))("SELECT AP_APP_TV_PCT FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault)

            Catch ex As Exception
                TelevisionPercent = Nothing
            End Try

        End Function
        Public Function APPOMessage(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                APPOMessage = (DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(AP_PO_MESSAGE, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault = 1)

            Catch ex As Exception
                APPOMessage = False
            End Try

        End Function
        Public Function APPOMessageText(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Try

                APPOMessageText = (DbContext.Database.SqlQuery(Of String)("SELECT AP_PO_MESSAGE_TEXT FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault)

            Catch ex As Exception
                APPOMessageText = Nothing
            End Try

        End Function
        Public Function APPOReject(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                APPOReject = (DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(AP_PO_REJECT, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault = 1)

            Catch ex As Exception
                APPOReject = False
            End Try

        End Function
        Public Function APPORejectText(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Try

                APPORejectText = (DbContext.Database.SqlQuery(Of String)("SELECT AP_PO_REJECT_TEXT FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault)

            Catch ex As Exception
                APPORejectText = Nothing
            End Try

        End Function
        Public Function IsAgencyASP(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                IsAgencyASP = (DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(ASP_ACTIVE, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault = 1)

            Catch ex As Exception
                IsAgencyASP = False
            End Try

        End Function
        Public Function IsAgencyASP(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            Try

                IsAgencyASP = (DataContext.ExecuteQuery(Of Short)("SELECT ISNULL(ASP_ACTIVE, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault = 1)

            Catch ex As Exception
                IsAgencyASP = False
            End Try

        End Function
        Public Function GetHomeCurrency(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Try

                GetHomeCurrency = (DbContext.Database.SqlQuery(Of String)("SELECT HOME_CRNCY FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault)

            Catch ex As Exception
                GetHomeCurrency = Nothing
            End Try

        End Function
        Public Function LoadReportTempPath(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Try

                LoadReportTempPath = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(ACCESS_TMP_PATH, '') FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                LoadReportTempPath = ""
            End Try

        End Function
        Public Function LoadReportPath(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Try

                LoadReportPath = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(ACCESS_RPT_PATH, '') FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                LoadReportPath = ""
            End Try

        End Function
        Public Function LoadLogoPath(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Try

                LoadLogoPath = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(LOGO, '') FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                LoadLogoPath = ""
            End Try

        End Function
        Public Function LoadName(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Try

                LoadName = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(NAME, '') FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                LoadName = ""
            End Try

        End Function
        Public Function LoadImportPath(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Try

                LoadImportPath = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(IMPORT_PATH, '') FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                LoadImportPath = ""
            End Try

        End Function
        Public Function LoadFileSystemDirectory(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Try

                LoadFileSystemDirectory = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(DOC_REPOSITORY_PATH, '') FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                LoadFileSystemDirectory = ""
            End Try

        End Function
        Public Function LoadLicenseKey(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Try

                LoadLicenseKey = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(LICENSE_KEY, '') FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                LoadLicenseKey = ""
            End Try

        End Function
        Public Function IsMultiCurrencyEnabled(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                IsMultiCurrencyEnabled = (DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(MULTI_CRNCY, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault = 1)

            Catch ex As Exception
                IsMultiCurrencyEnabled = False
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.Agency

            Try

                Load = (From Agency In DbContext.GetQuery(Of Database.Entities.Agency)
                        Select Agency).FirstOrDefault

            Catch ex As Exception
                Load = Nothing
            End Try

        End Function
        Public Function ValidateClosedArchivedJobs(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                ValidateClosedArchivedJobs = (DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(VALIDATE_JOB_CLOSE, 0) FROM [dbo].[AGENCY] WITH(NOLOCK);").FirstOrDefault = 1)

            Catch ex As Exception
                ValidateClosedArchivedJobs = False
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Agency As AdvantageFramework.Database.Entities.Agency) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Agency)

                ErrorText = Agency.ValidateEntity(IsValid)

                If IsValid Then

                    If DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGENCY] SET " &
                                                                       "ACCESS_RPT_PATH = {0}, " &
                                                                       "ACCESS_TMP_PATH = {1}, " &
                                                                       "ACCT_NBR_R = {2}, " &
                                                                       "AP_IMPORT_TYPE = {3}, " &
                                                                       "AP_APPROVAL = {4}, " &
                                                                       "AUTO_EMAIL = {5}, " &
                                                                       "ADDRESS1 = {6}, " &
                                                                       "ADDRESS2 = {7}, " &
                                                                       "CHK_BODY_LINES_DN = {8}, " &
                                                                       "CHK_STUB_LINES_UP = {9}, " &
                                                                       "AD_NBR_R = {10}, " &
                                                                       "EMAIL_GR_CODE_R = {11}, " &
                                                                       "AP_CALC_PO = {12}, " &
                                                                       "CHECK_FORMAT = {13}, " &
                                                                       "FLAG_1099 = {14}, " &
                                                                       "AP_OFFICE = {15}, " &
                                                                       "AP_LOCK_GLCODE = {16}, " &
                                                                       "NON_CLIENT_GL_DET = {17}, " &
                                                                       "AP_PO_MESSAGE = {18}, " &
                                                                       "AP_PO_MESSAGE_TEXT = {19}, " &
                                                                       "AP_PO_REJECT = {20}, " &
                                                                       "AP_PO_REJECT_TEXT = {21}, " &
                                                                       "APPR_EST_REQ = {22}, " &
                                                                       "VN_PAY_TO_INFO = {23}, " &
                                                                       "DELETE_INVOICE = {24}, " &
                                                                       "AUTO_ALERT_SUPER = {25}, " &
                                                                       "BLACKPLATE_VER_R = {26}, " &
                                                                       "BLACKPLATE_VER2_R = {27}, " &
                                                                       "CMP_CODE_R = {28}, " &
                                                                       "WORD_CHECK_AMT = {29}, " &
                                                                       "TS_PPERIOD_CHK = {30}, " &
                                                                       "CITY = {31}, " &
                                                                       "CONTACT_OPT = {32}, " &
                                                                       "JOB_CLI_REF_R = {33}, " &
                                                                       "COIN_TEXT = {34}, " &
                                                                       "COMPLEX_CODE_R = {35}, " &
                                                                       "JOB_COMP_BUDGET_R = {36}, " &
                                                                       "BILL_COOP_CODE_R = {37}, " &
                                                                       "COPY_TS = {38}, " &
                                                                       "COUNTRY = {39}, " &
                                                                       "CRNCY_IMPORT_TYPE = {40}, " &
                                                                       "CURRENCY_SYMBOL = {41}, " &
                                                                       "CURRENCY_TEXT = {42}, " &
                                                                       "JOB_DATE_OPENED_R = {43}, " &
                                                                       "DEF_EMAIL_GROUP = {44}, " &
                                                                       "TS_DAYS_PER_WK = {45}, " &
                                                                       "DP_TM_CODE_R = {46}, " &
                                                                       "JOB_FIRST_USE_DT_R = {47}, " &
                                                                       "EDIT_JOB_REQ_EST = {48}, " &
                                                                       "EMAIL_IT_CONTACT = {49}, " &
                                                                       "EMAIL_PWD = {50}, " &
                                                                       "EMAIL_SUPERVISOR = {51}, " &
                                                                       "EMAIL_USERNAME = {52}, " &
                                                                       "EMP_NOTES = {53}, " &
                                                                       "ALERT_NOTIFY = {54}, " &
                                                                       "ENABLE_ATTACHMENTS = {55}, " &
                                                                       "USE_PROD_CAT = {56}, " &
                                                                       "START_END_TIME = {57}, " &
                                                                       "EST_COMMENT = {58}, " &
                                                                       "EMAIL_ATTACH_DEF = {59}, " &
                                                                       "DOC_REPOSITORY_PATH = {60}, " &
                                                                       "DOC_REPOSITORY_USER_DOMAIN = {61}, " &
                                                                       "DOC_REPOSITORY_USER_PASSWORD = {62}, " &
                                                                       "DOC_REPOSITORY_USER_NAME = {63}, " &
                                                                       "FISCAL_PD_R = {64}, " &
                                                                       "JOB_AD_SIZE_R = {65}, " &
                                                                       "NOBILL_FLAG_H = {66}, " &
                                                                       "IMPORT_PATH = {67}, " &
                                                                       "EMP_ON_ALERT_LIST = {68}, " &
                                                                       "PDF_ALERT_ONLY = {69}, " &
                                                                       "IO_IMPORT_TYPE = {70}, " &
                                                                       "INTER_COMPANY = {71}, " &
                                                                       "INET_COMMENT = {72}, " &
                                                                       "AP_APP_INET_PCT = {73}, " &
                                                                       "ASP_ACTIVE = {74}, " &
                                                                       "IT_CONTACT_EMAIL = {75}, " &
                                                                       "JOB_CMP_UDV1_R = {76}, " &
                                                                       "JOB_CMP_UDV2_R = {77}, " &
                                                                       "JOB_CMP_UDV3_R = {78}, " &
                                                                       "JOB_CMP_UDV4_R = {79}, " &
                                                                       "JOB_CMP_UDV5_R = {80}, " &
                                                                       "FLAG_TAX_JOBS = {81}, " &
                                                                       "JOB_LOG_UDV1_R = {82}, " &
                                                                       "JOB_LOG_UDV2_R = {83}, " &
                                                                       "JOB_LOG_UDV3_R = {84}, " &
                                                                       "JOB_LOG_UDV4_R = {85}, " &
                                                                       "JOB_LOG_UDV5_R = {86}, " &
                                                                       "JT_CODE_R = {87}, " &
                                                                       "LICENSE_KEY = {88}, " &
                                                                       "MAG_COMMENT = {89}, " &
                                                                       "MB_KEY = {90}, " &
                                                                       "MARKET_CODE_R = {91}, " &
                                                                       "MD_INTERFACE = {92}, " &
                                                                       "NAME = {93}, " &
                                                                       "NEWS_COMMENT = {94}, " &
                                                                       "MRP_DSN = {95}, " &
                                                                       "EDIT_OFFICE = {96}, " &
                                                                       "OTDR_COMMENT = {97}, " &
                                                                       "AP_APP_OOH_PCT = {98}, " &
                                                                       "PHONE = {99}, " &
                                                                       "PO_AMT_REQ = {100}, " &
                                                                       "PO_FOOTER = {101}, " &
                                                                       "POP3_AUTH_METHOD = {102}, " &
                                                                       "POP3_REPLY_TO = {103}, " &
                                                                       "POP3_DEL_PROCESSED = {104}, " &
                                                                       "POP3_PWD = {105}, " &
                                                                       "POP3_PORT_NUMBER = {106}, " &
                                                                       "POP3_SECURE_TYPE = {107}, " &
                                                                       "POP3_SERVER = {108}, " &
                                                                       "POP3_USERNAME = {109}, " &
                                                                       "AP_APP_PRINT_PCT = {110}, " &
                                                                       "VN_ACCT_NBR = {111}, " &
                                                                       "PROD_CONT_CODE_R = {112}, " &
                                                                       "PROMO_CODE_R = {113}, " &
                                                                       "QA_PWD_REQ = {114}, " &
                                                                       "QVA_QUERY = {115}, " &
                                                                       "RADIO_COMMENT = {116}, " &
                                                                       "AP_APP_RADIO_PCT = {117}, " &
                                                                       "MD_RENAME = {118}, " &
                                                                       "EMAIL_REPLY_TO = {119}, " &
                                                                       "AUTO_EST_REV = {120}, " &
                                                                       "BILL_MEDIA_TYPE = {121}, " &
                                                                       "FORMAT_SC_CODE_R = {122}, " &
                                                                       "SERVICE_FEE_TYPE_R = {123}, " &
                                                                       "CR_AR_DESC = {124}, " &
                                                                       "SMTP_AUTH_METHOD = {125}, " &
                                                                       "SMTP_SENDER_PWD = {126}, " &
                                                                       "SMTP_PORT_NUMBER = {127}, " &
                                                                       "SMTP_SECURE_TYPE = {128}, " &
                                                                       "SMTP_SERVER = {129}, " &
                                                                       "SMTP_SENDER = {130}, " &
                                                                       "STATE = {131}, " &
                                                                       "STRATA_PATH = {132}, " &
                                                                       "TIME_APPR_ACTIVE = {133}, " &
                                                                       "EDIT_OTHER_TIME = {134}, " &
                                                                       "TAX_FLAG_R = {135}, " &
                                                                       "TV_COMMENT = {136}, " &
                                                                       "AP_APP_TV_PCT = {137}, " &
                                                                       "TIME_COMMENTS_REQ = {138}, " &
                                                                       "CLIENT_REF = {139}, " &
                                                                       "AP_ACCT_OFF_IMP = {140}, " &
                                                                       "ET_BATCH = {141}, " &
                                                                       "SMTP_USE_EMP_LOGIN = {142}, " &
                                                                       "GL_FILTER = {143}, " &
                                                                       "USE_SMTP_FOR_PDF = {144}, " &
                                                                       "VALIDATE_JOB_CLOSE = {145}, " &
                                                                       "WEBVANTAGE_URL = {146}, " &
                                                                       "WEEKLY_TIME = {147}, " &
                                                                       "ZIP = {148}, " &
                                                                       "HOME_CRNCY = {149}, " &
                                                                       "COUNTY = {150}, " &
                                                                       "COS_ENTRY_FLAG = {151}, " &
                                                                       "EDIT_CDP = {152}, " &
                                                                       "TIMEZONE_ID = {153}, " &
                                                                       "DB_TIMEZONE_ID = {154}, " &
                                                                       "CLIENTPORTAL_URL = {155}, " &
                                                                       "TIME_REQ_ASSN = {156}, " &
                                                                       "TIME_UNIQUE_ROW = {157}, " &
                                                                       "ALLOW_PROOFHQ = {158}, " &
                                                                       "PROOFING_URL = {159};",
                                                                        If(Agency.AccessReportPath IsNot Nothing, "'" & Agency.AccessReportPath.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.AccessReportTemporaryPath IsNot Nothing, "'" & Agency.AccessReportTemporaryPath.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.AccountNumberRequired.GetValueOrDefault(0),
                                                                        If(Agency.AccountPayableImportType IsNot Nothing, "'" & Agency.AccountPayableImportType.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.ActivateApprovals.GetValueOrDefault(0),
                                                                        Agency.ActivateSystemAlerts.GetValueOrDefault(0),
                                                                        If(Agency.Address IsNot Nothing, "'" & Agency.Address.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.Address2 IsNot Nothing, "'" & Agency.Address2.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.AdjustCheckBodyLinesDown.GetValueOrDefault(0),
                                                                        Agency.AdjustCheckStubLinesUp.GetValueOrDefault(0),
                                                                        Agency.AdNumberRequired.GetValueOrDefault(0),
                                                                        Agency.AlertGroupRequired.GetValueOrDefault(0),
                                                                        Agency.APCalculatePOBalance.GetValueOrDefault(0),
                                                                        Agency.APComputerCheckFormat.GetValueOrDefault(0),
                                                                        Agency.APFlagVendor1099.GetValueOrDefault(0),
                                                                        Agency.APLimitByOffice.GetValueOrDefault(0),
                                                                        Agency.APLockGLAccountCode.GetValueOrDefault(0),
                                                                        Agency.APNonClientGLDetail.GetValueOrDefault(0),
                                                                        Agency.APPOMessage.GetValueOrDefault(0),
                                                                        If(Agency.APPOMessageText IsNot Nothing, "'" & Agency.APPOMessageText.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.APPOReject.GetValueOrDefault(0),
                                                                        If(Agency.APPORejectText IsNot Nothing, "'" & Agency.APPORejectText.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.ApprovedEstimateRequired.GetValueOrDefault(0),
                                                                        Agency.APShowPayToInformation.GetValueOrDefault(0),
                                                                        Agency.APViewDeletedInvoices.GetValueOrDefault(0),
                                                                        Agency.AutoAlertSupervisor.GetValueOrDefault(0),
                                                                        Agency.Blackplate1Required.GetValueOrDefault(0),
                                                                        Agency.Blackplate2Required.GetValueOrDefault(0),
                                                                        Agency.CampaignCodeRequired.GetValueOrDefault(0),
                                                                        Agency.CheckAmountInWords.GetValueOrDefault(0),
                                                                        Agency.CheckClosedPeriods.GetValueOrDefault(0),
                                                                        If(Agency.City IsNot Nothing, "'" & Agency.City.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.ClientContactOption.GetValueOrDefault(0),
                                                                        Agency.ClientReferenceRequired.GetValueOrDefault(0),
                                                                        If(Agency.CoinText IsNot Nothing, "'" & Agency.CoinText.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.ComplexityCodeRequired.GetValueOrDefault(0),
                                                                        Agency.ComponentBudgetRequired.GetValueOrDefault(0),
                                                                        Agency.CoopBillingCodeRequired.GetValueOrDefault(0),
                                                                        Agency.CopyTimesheetFeature.GetValueOrDefault(0),
                                                                        If(Agency.Country IsNot Nothing, "'" & Agency.Country.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.CurrencyRateImportType IsNot Nothing, "'" & Agency.CurrencyRateImportType.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.CurrencySymbol IsNot Nothing, "'" & Agency.CurrencySymbol.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.CurrencyText IsNot Nothing, "'" & Agency.CurrencyText.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.DateOpenedRequired.GetValueOrDefault(0),
                                                                        If(Agency.DefaultAlertGroup IsNot Nothing, "'" & Agency.DefaultAlertGroup.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.DefaultDisplayDays.GetValueOrDefault(0),
                                                                        Agency.DepartmentTeamRequired.GetValueOrDefault(0),
                                                                        Agency.DueDateRequired.GetValueOrDefault(0),
                                                                        Agency.EditJobRequiredEstimate.GetValueOrDefault(0),
                                                                        Agency.EmailITContact.GetValueOrDefault(0),
                                                                        If(Agency.EmailPassword IsNot Nothing, "'" & Agency.EmailPassword.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.EmailSupervisor.GetValueOrDefault(0),
                                                                        If(Agency.EmailUserName IsNot Nothing, "'" & Agency.EmailUserName.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.EmployeeNote,
                                                                        Agency.EnableAlertNotification.GetValueOrDefault(0),
                                                                        Agency.EnableAttachmentsInJobJacket.GetValueOrDefault(0),
                                                                        Agency.EnableProductCategory.GetValueOrDefault(0),
                                                                        Agency.EnableStartEndTimeRealTIME.GetValueOrDefault(0),
                                                                        If(Agency.EstimateDefaultComments IsNot Nothing, "'" & Agency.EstimateDefaultComments.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.ExcludeAttachmentByDefault.GetValueOrDefault(0),
                                                                        If(Agency.FileSystemDirectory IsNot Nothing, "'" & Agency.FileSystemDirectory.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.FileSystemDomain IsNot Nothing, "'" & Agency.FileSystemDomain.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.FileSystemPassword IsNot Nothing, "'" & Agency.FileSystemPassword.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.FileSystemUserName IsNot Nothing, "'" & Agency.FileSystemUserName.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.FiscalPeriodRequired.GetValueOrDefault(0),
                                                                        Agency.FormatAdSizeRequired.GetValueOrDefault(0),
                                                                        Agency.HideNonBillableFlag.GetValueOrDefault(0),
                                                                        If(Agency.ImportPath IsNot Nothing, "'" & Agency.ImportPath.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.IncludeAlertGroups.GetValueOrDefault(0),
                                                                        Agency.IncludeAttachmentsWithAlerts.GetValueOrDefault(0),
                                                                        If(Agency.IncomeOnlyImportType IsNot Nothing, "'" & Agency.IncomeOnlyImportType.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.InterCompanyTransactions.GetValueOrDefault(0),
                                                                        If(Agency.InternetFooterComments IsNot Nothing, "'" & Agency.InternetFooterComments.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.InternetPercent.HasValue, Agency.InternetPercent, "NULL"),
                                                                        Agency.IsASP.GetValueOrDefault(0),
                                                                        If(Agency.ITContactEmail IsNot Nothing, "'" & Agency.ITContactEmail.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.JobComponentCustom1.GetValueOrDefault(0),
                                                                        Agency.JobComponentCustom2.GetValueOrDefault(0),
                                                                        Agency.JobComponentCustom3.GetValueOrDefault(0),
                                                                        Agency.JobComponentCustom4.GetValueOrDefault(0),
                                                                        Agency.JobComponentCustom5.GetValueOrDefault(0),
                                                                        Agency.JobComponentTaxable.GetValueOrDefault(0),
                                                                        Agency.JobLogCustom1.GetValueOrDefault(0),
                                                                        Agency.JobLogCustom2.GetValueOrDefault(0),
                                                                        Agency.JobLogCustom3.GetValueOrDefault(0),
                                                                        Agency.JobLogCustom4.GetValueOrDefault(0),
                                                                        Agency.JobLogCustom5.GetValueOrDefault(0),
                                                                        Agency.JobTypeRequired.GetValueOrDefault(0),
                                                                        If(Agency.LicenseKey IsNot Nothing, "'" & Agency.LicenseKey.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.MagazineFooterComments IsNot Nothing, "'" & Agency.MagazineFooterComments.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.MailBeeLicenseKey IsNot Nothing, "'" & Agency.MailBeeLicenseKey.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.MarketCodeRequired.GetValueOrDefault(0),
                                                                        If(Agency.MediaImportDefault IsNot Nothing, "'" & Agency.MediaImportDefault.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.Name IsNot Nothing, "'" & Agency.Name.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.NewspaperFooterComments IsNot Nothing, "'" & Agency.NewspaperFooterComments.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.NFusionDatasourceName IsNot Nothing, "'" & Agency.NFusionDatasourceName.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.OfficeCodeOverride.GetValueOrDefault(0),
                                                                        If(Agency.OutOfHomeFooterComments IsNot Nothing, "'" & Agency.OutOfHomeFooterComments.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.OutOfHomePercent.HasValue, Agency.OutOfHomePercent, "NULL"),
                                                                        If(Agency.Phone IsNot Nothing, "'" & Agency.Phone.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.POAmountRequired.GetValueOrDefault(0), '100
                                                                        If(Agency.POFooterComments IsNot Nothing, "'" & Agency.POFooterComments.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.POP3AuthenticationMethod.GetValueOrDefault(0),
                                                                        If(Agency.POP3DefaultReplyToEmail IsNot Nothing, "'" & Agency.POP3DefaultReplyToEmail.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.POP3DeleteMessages.GetValueOrDefault(0),
                                                                        If(Agency.POP3Password IsNot Nothing, "'" & Agency.POP3Password.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.POP3PortNumber.GetValueOrDefault(0),
                                                                        Agency.POP3SecureType.GetValueOrDefault(0),
                                                                        If(Agency.POP3Server IsNot Nothing, "'" & Agency.POP3Server.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.POP3UserName IsNot Nothing, "'" & Agency.POP3UserName.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.PrintMediaPercent.HasValue, Agency.PrintMediaPercent, "NULL"),
                                                                        Agency.PrintVendorAccountNumber.GetValueOrDefault(0),
                                                                        Agency.ProductContactRequired.GetValueOrDefault(0),
                                                                        Agency.PromotionRequired.GetValueOrDefault(0),
                                                                        Agency.QuoteApprovalPasswordRequired.GetValueOrDefault(0),
                                                                        Agency.QVAQuery.GetValueOrDefault(0),
                                                                        If(Agency.RadioFooterComments IsNot Nothing, "'" & Agency.RadioFooterComments.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.RadioPercent.HasValue, Agency.RadioPercent, "NULL"),
                                                                        Agency.RenameFinanceFile.GetValueOrDefault(0),
                                                                        If(Agency.ReplyToEmail IsNot Nothing, "'" & Agency.ReplyToEmail.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.RequireNewRevisions.GetValueOrDefault(0),
                                                                        Agency.RequireProductSetupComplete.GetValueOrDefault(0),
                                                                        Agency.SCFormatRequired.GetValueOrDefault(0),
                                                                        Agency.ServiceFeeTypeRequired.GetValueOrDefault(0),
                                                                        Agency.ShowARDescription.GetValueOrDefault(0),
                                                                        Agency.SMTPAuthenticationMethodType.GetValueOrDefault(0),
                                                                        If(Agency.SMTPPassword IsNot Nothing, "'" & Agency.SMTPPassword.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.SMTPPortNumber.GetValueOrDefault(0),
                                                                        Agency.SMTPSecurityType.GetValueOrDefault(0),
                                                                        If(Agency.SMTPServer IsNot Nothing, "'" & Agency.SMTPServer.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.SMTPUserName IsNot Nothing, "'" & Agency.SMTPUserName.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.State IsNot Nothing, "'" & Agency.State.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.StrataConnectPath IsNot Nothing, "'" & Agency.StrataConnectPath.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.SupervisorApprovalActive.GetValueOrDefault(0),
                                                                        Agency.SupervisorCanEditTime.GetValueOrDefault(0),
                                                                        Agency.TaxFlagRequired.GetValueOrDefault(0),
                                                                        If(Agency.TelevisionFooterComments IsNot Nothing, "'" & Agency.TelevisionFooterComments.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.TelevisionPercent.HasValue, Agency.TelevisionPercent, "NULL"),
                                                                        Agency.TimeCommentsRequired.GetValueOrDefault(0),
                                                                        Agency.UniqueClientReference.GetValueOrDefault(0),
                                                                        Agency.UseAPAccountOnImport.GetValueOrDefault(0),
                                                                        Agency.UseBatchMethod.GetValueOrDefault(0),
                                                                        Agency.UseEmployeeLogin.GetValueOrDefault(0),
                                                                        Agency.UseGLFilter.GetValueOrDefault(0),
                                                                        Agency.UseSMTPToSendPDF.GetValueOrDefault(0),
                                                                        Agency.ValidateJobClose.GetValueOrDefault(0),
                                                                        If(Agency.WebvantageURL IsNot Nothing, "'" & Agency.WebvantageURL.Replace("'", "''") & "'", "NULL"),
                                                                        Agency.WeeklyTimeType.GetValueOrDefault(0),
                                                                        If(Agency.Zip IsNot Nothing, "'" & Agency.Zip.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.HomeCurrency IsNot Nothing, "'" & Agency.HomeCurrency.Replace("'", "''") & "'", "NULL"),
                                                                        If(Agency.County IsNot Nothing, "'" & Agency.County.Replace("'", "''") & "'", "NULL"), '150
                                                                        Agency.AllowCostOfSaleEntry,
                                                                        Agency.CDPOverride.GetValueOrDefault(0),
                                                                        If(Agency.TimeZoneID IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Agency.TimeZoneID) = False, "'" & Agency.TimeZoneID & "'", "NULL"),
                                                                        If(Agency.DatabaseServerTimeZoneID IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Agency.DatabaseServerTimeZoneID) = False, "'" & Agency.DatabaseServerTimeZoneID & "'", "NULL"),
                                                                        If(Agency.ClientPortalURL IsNot Nothing, "'" & Agency.ClientPortalURL & "'", "NULL"),
                                                                        If(Agency.TimesheetRequireAssignment IsNot Nothing AndAlso Agency.TimesheetRequireAssignment = True, 1, 0),
                                                                        If(Agency.TimesheetAddUniqueRowWhenComment IsNot Nothing AndAlso Agency.TimesheetAddUniqueRowWhenComment = True, 1, 0),
                                                                        If(Agency.AllowProofHQ IsNot Nothing AndAlso Agency.AllowProofHQ = True, 1, 0),
                                                                        If(Agency.ProofingURL IsNot Nothing, "'" & Agency.ProofingURL.Replace("'", "''") & "'", "NULL"))) > 0 Then

                        Updated = True

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function UpdateAvaTaxEnabled(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Enabled As Boolean) As Boolean

            Dim Updated As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = '{0}' WHERE [AGY_SETTINGS_CODE] = '{1}'", If(Enabled, 1, 0), AdvantageFramework.Agency.Settings.AVATAX_ENABLED.ToString))

            Catch ex As Exception
                Updated = False
            End Try

            UpdateAvaTaxEnabled = Updated

        End Function
        Public Function UpdateTimesheetCopyHours(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Enabled As Boolean) As Boolean

            Dim Updated As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGENCY] SET [TS_COPY_HRS] = '{0}';", If(Enabled, 1, 0)))

            Catch ex As Exception
                Updated = False
            End Try

            UpdateTimesheetCopyHours = Updated

        End Function
        Public Function UpdateTimesheetRequireAssignment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Enabled As Boolean) As Boolean

            Dim Updated As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGENCY] SET [TIME_REQ_ASSN] = '{0}';", If(Enabled, 1, 0)))

            Catch ex As Exception
                Updated = False
            End Try

            UpdateTimesheetRequireAssignment = Updated

        End Function
        Public Function UpdateTimesheetAddUniqueRowWhenComment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Enabled As Boolean) As Boolean

            Dim Updated As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGENCY] SET [TIME_UNIQUE_ROW] = '{0}';", If(Enabled, 1, 0)))

            Catch ex As Exception
                Updated = False
            End Try

            UpdateTimesheetAddUniqueRowWhenComment = Updated

        End Function
        Public Function UpdateAllowProofHQ(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Enabled As Boolean) As Boolean

            Dim Updated As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGENCY] SET [ALLOW_PROOFHQ] = {0};", If(Enabled = True, 1, 0)))

            Catch ex As Exception
                Updated = False
            End Try

            UpdateAllowProofHQ = Updated

        End Function

#End Region

    End Module

End Namespace
