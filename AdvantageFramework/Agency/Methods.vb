Namespace Agency

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Private Const TASK_COMMENT_MAX_LENGTH As Integer = 25

#End Region

#Region " Enum "

        Public Enum SettingApps
            ProjectScheduleMaintenance = 0
            AgencyBuilderMaintenance = 1
            ProductionMaintenance = 2
            BillingMaintenance = 3
            EmployeeTimeForecastSettings = 4
            AgencyBranding = 5
            Processing1099 = 6
            IntegrationSettings = 7
            VCCSettings = 8
            MeidaManagerSettings = 9
        End Enum

        Public Enum Settings
            ACC_SETUP_CODE_1
            ACC_SETUP_CODE_2
            ACC_SETUP_CODE_3
            ACC_SETUP_CODE_4
            ADV_CLIENT_CODE
            ADV_SERV_USER_CHANGE
            AGENCY_GOALS_ON
            AGY_1099_CFSF
            AGY_1099_COMPANYNAME
            AGY_1099_CONTACT
            AGY_1099_STATE_ID
            AGY_BLD_PPD_END
            AGY_BLD_PPD_START
            ALRT_ASSGN_DFLT_SUB
            AP_APPR_ALERT_GROUP
            AP_APPR_DFLT_STATE
            AP_APPR_DFLT_TMPLT
            AP_APPR_ALERT_AP
            AP_APPR_ALERT_USER
            AP_DEF_DESC_VEN_ACCT
            AP_IMP_DEF_INV_DESC
            AP_NON_VENDOR_ORDER
            AP_REMOVE_PMT_HOLD
            AUTO_ASSGN_KEEP_EMP
            AVATAX_ACCT_NUMBER
            AVATAX_ADR_COUNTRIES
            AVATAX_ADR_ENABLED
            AVATAX_ENABLED
            AVATAX_LICENSE_KEY
            AVATAX_URL
            AVATAX_USE_CL_ADDR
            AVATAX_USE_JC_ADDR
            AVATAX_USE_JOB_SC
            BA_APPR_INFO_SECT
            BA_CMNT_SECT
            BA_DESC_CL_NAME
            BA_DTLS_SECT
            BA_JOB_LIST_SECT
            BA_OPT_INFO_SECT
            BA_VER_INFO
            BCC_DEF_WINDOW
            CAMP_AUTO_GEN_CODE
            CAMP_REQUIRE_DIV_PRD
            CCR_DEF_WRITEOFF_GL
            CCR_PART_PMT_ENABLE
            CCR_PART_PMT_REQ
            CLI_INC_ALERT_PCT
            CLIENTPO_ENBL_AUTONM
            CLIENTPO_LAST_USED
            COUNTRY
            CS_ENABLED
            CS_PARTNER_KEY
            CS_PARTNER_PW
            CS_SA_USERNAME
            CS_SA_PASSWORD
            CS_URL
            CSCORE_AS_CLIENT_ID
            CSCORE_CLIENT_ID
            CSCORE_CLIENT_SECRET
            CSCORE_USE_NEW_URL
            CSI_CCDATA_FTP
            CSI_COMDATA_FTP
            CSI_GVCARD_FTP
            CSI_IMPORT_PATH
            CSI_PP_USER
            CSI_PP_SIGNED
            CSI_PP_PW
            CSI_PP_SIGNED_DATE
            CSI_PP_SIGNED_EMP
            CSI_VENDOR_FTP
            CSI_VENDOR_FTP_PW
            CSI_VENDOR_FTP_USER
            CUR_RATIO_GOAL
            CURRENCY_API_KEY
            CURRENT_RATIO_ON
            DC_ENABLED
            DC_OAUTH2_TOKEN
            DC_HELP
            DC_PROFILE_ID
            DC_REPORT_ID
            DEF_GRP_TYPE_INT
            DEF_GRP_TYPE_MAG
            DEF_GRP_TYPE_NEW
            DEF_GRP_TYPE_OUT
            DEF_GRP_TYPE_RAD
            DEF_GRP_TYPE_TV
            DIRECT_EXP_ALERT_AMT
            DIRECT_EXPENSE_ON
            DOT_NET_FOLDER
            EAG_OVER_PCT_TOTAL
            EAG_PROP_PCT_DIRECT
            EAG_PROP_PCT_TOTAL
            EAG_UNDER_PCT_DIRECT
            EASTLAN_ENABLED
            ENCRYPTED_PW_P1
            ETF_AALT_HRSCHANGED
            ETF_AALT_HRSEXCEED
            ETF_HIDE_DIV_COL
            ETF_HIDE_PRD_COL
            ETF_HIDE_REVSHAREAMT
            ETF_REVAMT_CALC
            ETF_SHOW_CODEONLY
            ETF_SHOW_JOB_DTL
            ETF_USE_EMPTTLE_RATE
            FEDERAL_TAX_ID
            FILE_UPLOAD_LIMIT
            FOLD_FUNCTION
            FTE_BASIS
            GROSS_INC_PCT_BILL
            IMP_ALERT_BUYER
            IMP_PENDING_TV
            IMP_PENDING_RAD
            IMP_PENDING_PRI
            IMP_PENDING_OUT
            IMP_PENDING_INT
            IMP_PAYMENT_HOLD
            INVPRT_CCSENDER
            INVPRT_COMB_COOP_INV
            INVPRT_COVER_CC
            INVPRT_COVER_CC_LOC
            INVPRT_COVER_CC_TYPE
            INVPRT_COVER_LAYOUT
            INVPRT_COVER_TITLE
            INVPRT_EMAILBODY
            INVPRT_EMAILSUBJECT
            INVPRT_FILE_NAME
            INVPRT_FROMEMAIL
            INVPRT_INCL_CS
            INVPRT_PACKAGETYPE
            INVPRT_PRINTPRD
            INVPRT_REPLYTO
            INVPRT_SENDERNAME
            INVPRT_SINGLEEMAIL
            INVPRT_SINGLEPDF
            INVPRT_SORTOPTION
            INVPRT_UPDOC
            IO_MEDIA_ORDERLINE
            IRS_TCC
            JOB_PS_REQ_ON_NEW
            JOB_VERSION_DESC
            JR_ALERT_SETTING
            JR_ASSIGN_STATE
            JR_ASSIGN_TMPLT
            JR_DFLT_ALERT_GROUP
            JR_DFLT_CONTACT
            JR_DFLT_TMPLT
            MAX_EMAIL_SIZE
            MBW_DEFAULT_RATE
            MEDIA_EXCL_ORD_PDF
            MEDIA_REQ_CAMPAIGN
            MEDIATRAFFIC_STARTDT
            MO_USE_VENDOR_RATE
            MP_ADD_TO_ORDER
            NATIONAL_DB_NAME
            NATIONAL_DB_PASSWORD
            NATIONAL_DB_SERVER
            NATIONAL_DB_USER
            NATIONAL_WIN_AUTH
            NET_PROFIT_PCT_GP
            NEW_LICENSE_KEY
            NIELSEN_DB_NAME
            NIELSEN_DB_PASSWORD
            NIELSEN_DB_SERVER
            NIELSEN_DB_USER
            NIELSEN_SVC_TIMEOUT
            NIELSEN_WINDOWS_AUTH
            OPER_EXP_PCT_INC
            ORDER_AP_OUTPATH
            ORDER_MP_OUTPATH
            OVERHEAD_FACTOR
            OVERHEAD_PCT_INC
            PAYROLL_PCT_INC
            PROOFHQ_ENABLED
            PROOFHQ_SA_PASSWORD
            PROOFHQ_SA_USERNAME
            PROOFHQ_USE_SA
            QB_ACCESS_TOKEN
            QB_AUTH_CODE
            QB_ENABLED
            QB_REALM_ID
            QB_REFRESH_TOKEN
            REPOSITORY_LIMIT
            RPT_JD_FEE_FNC_CODES
            RSC_RPT_FLX_CLR
            RSC_RPT_HLD_CLR
            RSC_RPT_NO_ETI_CLR
            RSC_RPT_PRE_CLR
            RSC_RPT_STC_CLR
            SERVICE_TAX_ENABLED
            SMTP_OAUTH2_TOKEN
            SYNC_GOOGLECALENDAR
            SYNC_OUTLOOK
            SYNC_OUTLOOK_USE_EX
            SYNC_SUGARCRM
            SYNC_SUGARCRM_URL
            TR_TITLE1
            TR_TITLE2
            TR_TITLE3
            TR_TITLE4
            TR_TITLE5
            TRAFFIC_MGR_COL
            TRF_ACTIVE_NEXT_TASK
            TRF_ALRT_TMP_CMPLT
            TRF_CALC_BY_CMP
            TRF_CALC_BY_DAY
            TRF_CALC_CONCUR_DT
            TRF_CMPLT_ON_LAST
            TRF_COMP_ALERT
            TRF_COMP_NO_TMP
            TRF_DEL_TSK_ALRT
            TRF_DFLT_STATUS
            TRF_HRS
            TRF_LOCK_DATE
            TRF_NXT_TSK_AUTO_EML
            TRF_SCHEDULE_BY
            TRF_TEMP_COMP_ALERT
            TRF_UPDATE_ALERT_DUE
            TRF_UPDATE_STATUS
            TS_AGY_OVRRDE
            TS_DAYS_TO_DISPLAY
            TS_DIVISION
            TS_FUNC_CAT
            TS_JOB
            TS_JOB_COMP
            TS_MIN_TIME
            TS_PROD_CAT
            TS_PRODUCT
            TS_REQ_CMT_APPR
            TS_ROUND_TO
            TS_SHOW_CMNT_USING
            TS_START_WEEK_ON
            TS_STOP_MIN_TIME
            TS_STOP_ROUND_TO
            TS_TASK_ONLY
            USE_PHASE
            VAT_PPSTART
            VAT_PPEND
            VAT_AGENCY_VATNUMBER
            VAT_CURRENCY_CODE
            VAT_OUTPUT_DIRECTORY
            VEN_COST_COL_TERMS
            VCC_ACCOUNT_ID
            VCC_API_URL
            VCC_COMPANY_ID
            VCC_INCLUDE_CARDINFO
            VCC_OUTSOURCE_ID
            VCC_PROVIDER
            VCC_SA_PASSWORD
            VCC_SA_USERNAME
            VCCREM_CCSENDER
            VCCREM_EMAILBODY
            VCCREM_EMAILSUBJECT
            VCCREM_LETTER
            VCC_USE_SA
            WV_BRND_BG
            WV_BRND_BG_TYPE
            WV_BRND_BGCLR
            WV_BRND_CLK_APP
            WV_BRND_CLK_USR
            WV_BRND_CLR_SN_IN
            WV_BRND_ENABLE
            WV_BRND_FLT_DTO
            WV_BRND_ICON
            WV_BRND_LOGO
            WV_BRND_LOGO_ON_WP
            WV_BRND_LOGO_POS
            WV_BRND_SHRT_MNU
            WV_BRND_SMPL_BG_CLR
            WV_BRND_SMPL_ICON
            WV_BRND_SMPL_SB_CLR
            WV_BRND_THEME
            WV_BRND_USR_BG
            WV_BRND_USR_THM
            WV_ENABLE_WTHR
            WV_WALLPAPER_DEF
            WV_BRND_TXCLR
        End Enum

        Public Enum LocalMachineAccess
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("", "AccessRptPath", "")>
            AccessRptPath
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("", "AccessTmpPath", "")>
            AccessTmpPath
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("", "WebvantageURL", "")>
            WebvantageURL
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("", "ClientPortalURL", "")>
            ClientPortalURL
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("", "DotNetPath", "")>
            DotNetPath
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("", "ProofingURL", "")>
            ProofingURL
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadDefaultDisplayDaysList() As Generic.List(Of Int16)

            Dim DefaultDisplayDaysList As Generic.List(Of Int16) = Nothing

            DefaultDisplayDaysList = New Generic.List(Of Int16)

            DefaultDisplayDaysList.Add(1)
            DefaultDisplayDaysList.Add(5)
            DefaultDisplayDaysList.Add(7)

            LoadDefaultDisplayDaysList = DefaultDisplayDaysList

        End Function
        Public Function LoadAdjustCheckBodyLinesDownList() As Generic.List(Of Int16)

            Dim AdjustCheckBodyLinesDownList As Generic.List(Of Int16) = Nothing

            AdjustCheckBodyLinesDownList = New Generic.List(Of Int16)

            AdjustCheckBodyLinesDownList.Add(0)
            AdjustCheckBodyLinesDownList.Add(1)
            AdjustCheckBodyLinesDownList.Add(2)

            LoadAdjustCheckBodyLinesDownList = AdjustCheckBodyLinesDownList

        End Function
        Public Function LoadAdjustCheckStubLinesUpList() As Generic.List(Of Int16)

            Dim AdjustCheckStubLinesUpList As Generic.List(Of Int16) = Nothing

            AdjustCheckStubLinesUpList = New Generic.List(Of Int16)

            AdjustCheckStubLinesUpList.Add(0)
            AdjustCheckStubLinesUpList.Add(1)

            LoadAdjustCheckStubLinesUpList = AdjustCheckStubLinesUpList

        End Function
        Public Function UpdateJobComponentTaxOption(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MarkAsTaxable As Boolean) As Boolean

            Dim Updated As Boolean = True

            Try

                'For Each Product In AdvantageFramework.Database.Procedures.Product.Load(DbContext).Include("Jobs").Include("Jobs.JobComponents").ToList

                '    For Each Job In Product.Jobs

                '        For Each JobComponent In Job.JobComponents

                '            If MarkAsTaxable Then

                '                JobComponent.TaxCode = Product.ProductionTaxCode
                '                JobComponent.TaxFlag = 1

                '            Else

                '                JobComponent.TaxCode = Nothing
                '                JobComponent.TaxFlag = Nothing

                '            End If

                '            DbContext.UpdateObject(JobComponent)

                '        Next

                '    Next

                'Next

                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_job_component_update_tax_option] {0}", If(MarkAsTaxable, 1, 0)))

            Catch ex As Exception
                Updated = False
            End Try

            'Try

            '    If Updated Then
            '        DbContext.SaveChanges()
            '    End If

            'Catch ex As Exception
            '    Updated = False
            'End Try

            UpdateJobComponentTaxOption = Updated

        End Function
        Public Function DeleteMachineAccessSetting(ByVal LocalMachineAccess As AdvantageFramework.Agency.LocalMachineAccess) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing
            Dim RegistryAttribute As AdvantageFramework.Registry.Attributes.RegistryAttribute = Nothing
            Dim UserSID As String = ""

            Try

                If System.Environment.Is64BitOperatingSystem AndAlso System.Environment.Is64BitProcess Then

                    RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Advantage", True)

                Else

                    RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Advantage", True)

                End If

                If RegistryKey IsNot Nothing Then

                    RegistryAttribute = System.Attribute.GetCustomAttribute(LocalMachineAccess.GetType().GetField(LocalMachineAccess.ToString), GetType(AdvantageFramework.Registry.Attributes.RegistryAttribute))

                    If RegistryAttribute IsNot Nothing Then

                        If RegistryKey IsNot Nothing Then

                            If RegistryKey.GetValue(RegistryAttribute.Key) IsNot Nothing Then

                                RegistryKey.DeleteValue(RegistryAttribute.Key)

                            End If

                            Deleted = True

                        End If

                    End If

                End If

            Catch ex As Exception
                Deleted = False
            End Try

            DeleteMachineAccessSetting = Deleted

        End Function
        Public Function LoadMachineAccessSettings(ByVal LocalMachineAccess As AdvantageFramework.Agency.LocalMachineAccess) As String

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing
            Dim AgencyAccessValue As String = ""
            Dim RegistryAttribute As AdvantageFramework.Registry.Attributes.RegistryAttribute = Nothing

            If System.Environment.Is64BitOperatingSystem AndAlso System.Environment.Is64BitProcess Then

                RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Advantage", False)

            Else

                RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Advantage", False)

            End If

            If RegistryKey IsNot Nothing Then

                RegistryAttribute = System.Attribute.GetCustomAttribute(LocalMachineAccess.GetType().GetField(LocalMachineAccess.ToString), GetType(AdvantageFramework.Registry.Attributes.RegistryAttribute))

                If RegistryAttribute IsNot Nothing Then

                    If RegistryKey IsNot Nothing Then

                        AgencyAccessValue = RegistryKey.GetValue(RegistryAttribute.Key, RegistryAttribute.Default)

                    Else

                        AgencyAccessValue = RegistryAttribute.Default

                    End If

                End If

            End If

            LoadMachineAccessSettings = AgencyAccessValue

        End Function
        Public Function UpdateMachineAccessSettings(ByVal LocalMachineAccess As AdvantageFramework.Agency.LocalMachineAccess, ByVal LocalMachineAccessValue As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing
            Dim RegistryAttribute As AdvantageFramework.Registry.Attributes.RegistryAttribute = Nothing

            Try

                If System.Environment.Is64BitOperatingSystem AndAlso System.Environment.Is64BitProcess Then

                    RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Advantage", True)

                Else

                    RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Advantage", True)

                End If

                If RegistryKey IsNot Nothing Then

                    RegistryAttribute = System.Attribute.GetCustomAttribute(LocalMachineAccess.GetType().GetField(LocalMachineAccess.ToString), GetType(AdvantageFramework.Registry.Attributes.RegistryAttribute))

                    If RegistryAttribute IsNot Nothing Then

                        RegistryKey.SetValue(RegistryAttribute.Key, LocalMachineAccessValue)
                        Updated = True

                    End If

                End If

            Catch ex As Exception
                Updated = False
            End Try

            UpdateMachineAccessSettings = Updated

        End Function
        Public Function UpdateClientReference(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RequireUniqueClientReferece As Boolean) As Boolean

            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If RequireUniqueClientReferece Then

                    If (From Entity In DbContext.GetQuery(Of Database.Entities.Job)
                        Where Entity.ClientRef Is Nothing AndAlso
                              Entity.SalesClassCode IsNot Nothing
                        Select Entity).Any Then

                        AdvantageFramework.Navigation.ShowMessageBox("One or more of your jobs do not have a client reference. They will not be added to the table " &
                                                                     "and will not be able to be selected from the list of client references.")

                    End If

                    If DbContext.Database.ExecuteSqlCommand("INSERT INTO JOB_CLIENT_REF ( JOB_CLI_REF, JOB_NUMBER ) " &
                                                         "SELECT JOB_CLI_REF, JOB_NUMBER FROM JOB_LOG " &
                                                         "WHERE JOB_CLI_REF IS NOT NULL AND SC_CODE IS NOT NULL ") > 0 Then

                        DbContext.Database.ExecuteSqlCommand("UPDATE AGENCY SET CLIENT_REF = 1")

                        Updated = True

                    End If

                Else

                    DbContext.Database.ExecuteSqlCommand("UPDATE AGENCY SET CLIENT_REF = 0")

                    Updated = True

                End If

            Catch ex As Exception
                Updated = False
            End Try

            UpdateClientReference = Updated

        End Function
        Public Function GetOptionAPAllowOrderNotMatchingVendor(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                GetOptionAPAllowOrderNotMatchingVendor = CBool(DbContext.Database.SqlQuery(Of String)("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'AP_NON_VENDOR_ORDER'").SingleOrDefault)

            Catch ex As Exception
                GetOptionAPAllowOrderNotMatchingVendor = False
            End Try

        End Function
        Public Function GetOptionAPImportDefaultInvoiceDescription(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Try

                GetOptionAPImportDefaultInvoiceDescription = DbContext.Database.SqlQuery(Of String)("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'AP_IMP_DEF_INV_DESC'").SingleOrDefault

            Catch ex As Exception
                GetOptionAPImportDefaultInvoiceDescription = False
            End Try

        End Function
        Public Function GetOptionOrderExportFromAPPath(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Try

                GetOptionOrderExportFromAPPath = DbContext.Database.SqlQuery(Of String)("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'ORDER_AP_OUTPATH'").SingleOrDefault

            Catch ex As Exception
                GetOptionOrderExportFromAPPath = False
            End Try

        End Function
        Public Function GetOptionOrderExportFromMediaPlanPath(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Try

                GetOptionOrderExportFromMediaPlanPath = DbContext.Database.SqlQuery(Of String)("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'ORDER_MP_OUTPATH'").SingleOrDefault

            Catch ex As Exception
                GetOptionOrderExportFromMediaPlanPath = False
            End Try

        End Function
        Public Function GetOptionClientCashReceiptsDefaultWriteoffGL(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim ClientCashReceiptsDefaultWriteoffGL As String = Nothing

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CCR_DEF_WRITEOFF_GL.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                ClientCashReceiptsDefaultWriteoffGL = Setting.Value

            End If

            GetOptionClientCashReceiptsDefaultWriteoffGL = ClientCashReceiptsDefaultWriteoffGL

        End Function
        Public Function GetOptionClientCashReceiptsPartialPaymentEnabled(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim ClientCashReceiptsPartialPaymentEnabled As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CCR_PART_PMT_ENABLE.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing AndAlso IsNumeric(Setting.Value) AndAlso Setting.Value = 1 Then

                ClientCashReceiptsPartialPaymentEnabled = True

            End If

            GetOptionClientCashReceiptsPartialPaymentEnabled = ClientCashReceiptsPartialPaymentEnabled

        End Function
        Public Function GetOptionClientCashReceiptsPartialPaymentRequired(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim ClientCashReceiptsPartialPaymentRequired As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CCR_PART_PMT_REQ.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing AndAlso IsNumeric(Setting.Value) AndAlso Setting.Value = 1 Then

                ClientCashReceiptsPartialPaymentRequired = True

            End If

            GetOptionClientCashReceiptsPartialPaymentRequired = ClientCashReceiptsPartialPaymentRequired

        End Function
        Public Function GetOptionAutomaticallyRemovePaymentHoldOnApproval(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim AutomaticallyRemovePaymentHoldOnApproval As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.AP_REMOVE_PMT_HOLD.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing AndAlso IsNumeric(Setting.Value) AndAlso Setting.Value = 1 Then

                AutomaticallyRemovePaymentHoldOnApproval = True

            End If

            GetOptionAutomaticallyRemovePaymentHoldOnApproval = AutomaticallyRemovePaymentHoldOnApproval

        End Function
        Public Function GetWebFormTerms(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim WebFormTerms As String = ""

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.VEN_COST_COL_TERMS.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                WebFormTerms = Setting.Value

            End If

            GetWebFormTerms = WebFormTerms

        End Function
        Public Function SaveWebFormTerms(ByVal DataContext As AdvantageFramework.Database.DataContext, WebFormTerms As String) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.VEN_COST_COL_TERMS.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = WebFormTerms

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.VEN_COST_COL_TERMS.ToString
                Setting.Description = "Vendor Cost Collection Terms"
                Setting.Value = WebFormTerms
                Setting.SettingDatabaseTypeID = 11

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveWebFormTerms = Saved

        End Function
        Public Function GetDotNetFolder(DataContext As AdvantageFramework.Database.DataContext) As String

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim DotNetFolder As String = String.Empty

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.DOT_NET_FOLDER.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                DotNetFolder = Setting.Value

            End If

            GetDotNetFolder = DotNetFolder

        End Function
        Public Function SaveDotNetFolder(DataContext As AdvantageFramework.Database.DataContext, DotNetFolder As String) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.DOT_NET_FOLDER.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = DotNetFolder

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.DOT_NET_FOLDER.ToString
                Setting.Description = ".NET Folder"
                Setting.Value = DotNetFolder
                Setting.SettingDatabaseTypeID = 11

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveDotNetFolder = Saved

        End Function
        Public Function GetOptionServiceTaxEnabled(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim ServiceTaxEnabled As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.SERVICE_TAX_ENABLED.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing AndAlso IsNumeric(Setting.Value) AndAlso Setting.Value = 1 Then

                ServiceTaxEnabled = True

            End If

            GetOptionServiceTaxEnabled = ServiceTaxEnabled

        End Function
        Public Function LoadDefaultGroupingType(DataContext As AdvantageFramework.Database.DataContext, DefaultGroupingTypeSetting As Settings) As String

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim DefaultGroupingTypeSettingValue As String = Nothing

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, DefaultGroupingTypeSetting.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                DefaultGroupingTypeSettingValue = Setting.Value

            End If

            LoadDefaultGroupingType = DefaultGroupingTypeSettingValue

        End Function
        Public Function SaveDefaultGroupingType(DataContext As AdvantageFramework.Database.DataContext, DefaultGroupingTypeSetting As Settings, DefaultGroupingTypeSettingValue As String) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, DefaultGroupingTypeSetting.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = DefaultGroupingTypeSettingValue

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = DefaultGroupingTypeSetting.ToString
                Setting.Description = DefaultGroupingTypeSetting.ToString
                Setting.Value = DefaultGroupingTypeSettingValue
                Setting.DefaultValue = Nothing
                Setting.SettingDatabaseTypeID = 20

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveDefaultGroupingType = Saved

        End Function
        Public Function LoadMediaOrderLineSelectionInIncomeOnly(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim MediaOrderLineSelectionInIncomeOnlyEnabled As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.IO_MEDIA_ORDERLINE.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                MediaOrderLineSelectionInIncomeOnlyEnabled = Setting.Value

            End If

            LoadMediaOrderLineSelectionInIncomeOnly = MediaOrderLineSelectionInIncomeOnlyEnabled

        End Function
        Public Function SaveMediaOrderLineSelectionInIncomeOnly(ByVal DataContext As AdvantageFramework.Database.DataContext, MediaOrderLineSelectionInIncomeOnly As Boolean) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.IO_MEDIA_ORDERLINE.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = MediaOrderLineSelectionInIncomeOnly

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.IO_MEDIA_ORDERLINE.ToString
                Setting.Description = "Activate media order/line selection in Income Only"
                Setting.Value = MediaOrderLineSelectionInIncomeOnly
                Setting.DefaultValue = False
                Setting.SettingDatabaseTypeID = 16

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveMediaOrderLineSelectionInIncomeOnly = Saved

        End Function
        Public Function LoadMediaPlanningAddLinesToExistingOrder(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim MediaPlanningAddLinesToExistingOrder As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.MP_ADD_TO_ORDER.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                MediaPlanningAddLinesToExistingOrder = Setting.Value

            End If

            LoadMediaPlanningAddLinesToExistingOrder = MediaPlanningAddLinesToExistingOrder

        End Function
        Public Function SaveMediaPlanningAddLinesToExistingOrder(ByVal DataContext As AdvantageFramework.Database.DataContext, MediaPlanningAddLinesToExistingOrder As Boolean) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.MP_ADD_TO_ORDER.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = MediaPlanningAddLinesToExistingOrder

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.MP_ADD_TO_ORDER.ToString
                Setting.Description = "Media Planning - Add lines to existing order"
                Setting.Value = MediaPlanningAddLinesToExistingOrder
                Setting.DefaultValue = True
                Setting.MinimumValue = 0
                Setting.MaximumValue = 1
                Setting.SettingDatabaseTypeID = 16

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveMediaPlanningAddLinesToExistingOrder = Saved

        End Function
        Public Function LoadBroadcastWorksheetDefaultRateType(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim IsNetRateType As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.MBW_DEFAULT_RATE.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                IsNetRateType = Setting.Value

            End If

            LoadBroadcastWorksheetDefaultRateType = IsNetRateType

        End Function
        Public Function SaveBroadcastWorksheetDefaultRateType(ByVal DataContext As AdvantageFramework.Database.DataContext, IsNetRateType As Boolean) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.MBW_DEFAULT_RATE.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = IsNetRateType

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.MBW_DEFAULT_RATE.ToString
                Setting.Description = "Broadcast Worksheet Default Rate Type"
                Setting.Value = IsNetRateType
                Setting.DefaultValue = False
                Setting.MinimumValue = 0
                Setting.MaximumValue = 1
                Setting.SettingDatabaseTypeID = 16

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveBroadcastWorksheetDefaultRateType = Saved

        End Function
        Public Function LoadVendorsRateTypeSetting(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim UseVendorsRateType As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.MO_USE_VENDOR_RATE.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                UseVendorsRateType = Setting.Value

            End If

            LoadVendorsRateTypeSetting = UseVendorsRateType

        End Function
        Public Function SaveVendorsRateTypeSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, UseVendorsRateType As Boolean) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.MO_USE_VENDOR_RATE.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = UseVendorsRateType

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.MO_USE_VENDOR_RATE.ToString
                Setting.Description = "Use Vendors Rate Type Setting when Creating Orders from Planning and Worksheet"
                Setting.Value = UseVendorsRateType
                Setting.DefaultValue = False
                Setting.MinimumValue = 0
                Setting.MaximumValue = 1
                Setting.SettingDatabaseTypeID = 16

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveVendorsRateTypeSetting = Saved

        End Function
        Public Function LoadMediaRequireCampaign(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim MediaRequireCampaign As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.MEDIA_REQ_CAMPAIGN.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                MediaRequireCampaign = Setting.Value

            End If

            LoadMediaRequireCampaign = MediaRequireCampaign

        End Function
        Public Function SaveMediaRequireCampaign(ByVal DataContext As AdvantageFramework.Database.DataContext, MediaRequireCampaign As Boolean) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.MEDIA_REQ_CAMPAIGN.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = MediaRequireCampaign

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.MEDIA_REQ_CAMPAIGN.ToString
                Setting.Description = "Media - Require Campaign Selection"
                Setting.Value = MediaRequireCampaign
                Setting.DefaultValue = True
                Setting.MinimumValue = 0
                Setting.MaximumValue = 1
                Setting.SettingDatabaseTypeID = 16

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveMediaRequireCampaign = Saved

        End Function
        Public Function LoadJobDetailFeesFunctionCodes(DataContext As AdvantageFramework.Database.DataContext) As Generic.List(Of String)

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim FunctionCodes As Generic.List(Of String) = Nothing
            Dim FunctionCodeList As String = String.Empty

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.RPT_JD_FEE_FNC_CODES.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                FunctionCodeList = Setting.Value

            End If

            If String.IsNullOrWhiteSpace(FunctionCodeList) = False Then

                If FunctionCodeList.Contains(",") Then

                    FunctionCodes = Split(FunctionCodeList, ",").ToList

                Else

                    FunctionCodes = New Generic.List(Of String)

                    FunctionCodes.Add(FunctionCodeList)

                End If

            Else

                FunctionCodes = New Generic.List(Of String)

            End If

            LoadJobDetailFeesFunctionCodes = FunctionCodes

        End Function
        Public Function SaveJobDetailFeesFunctionCodes(ByVal DataContext As AdvantageFramework.Database.DataContext, FunctionCodes As Generic.List(Of String)) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.RPT_JD_FEE_FNC_CODES.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                If FunctionCodes IsNot Nothing AndAlso FunctionCodes.Count > 0 Then

                    Setting.Value = Join(FunctionCodes.ToArray, ",")

                Else

                    Setting.Value = String.Empty

                End If

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.RPT_JD_FEE_FNC_CODES.ToString
                Setting.Description = "Job Detail Fees Function Codes"

                If FunctionCodes IsNot Nothing AndAlso FunctionCodes.Count > 0 Then

                    Setting.Value = Join(FunctionCodes.ToArray, ",")

                Else

                    Setting.Value = String.Empty

                End If

                Setting.DefaultValue = String.Empty
                Setting.SettingDatabaseTypeID = 11

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveJobDetailFeesFunctionCodes = Saved

        End Function
        Public Function LoadEncryptedPasswordsPhase1(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim EncryptedPasswordsPhase1 As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.ENCRYPTED_PW_P1.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                EncryptedPasswordsPhase1 = Setting.Value

            End If

            LoadEncryptedPasswordsPhase1 = EncryptedPasswordsPhase1

        End Function
        Public Function SaveEncryptedPasswordsPhase1(ByVal DataContext As AdvantageFramework.Database.DataContext, EncryptedPasswordsPhase1 As Boolean) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.ENCRYPTED_PW_P1.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = EncryptedPasswordsPhase1

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.ENCRYPTED_PW_P1.ToString
                Setting.Description = "Encryption for passwords phase 1"
                Setting.Value = EncryptedPasswordsPhase1
                Setting.DefaultValue = True
                Setting.MinimumValue = 0
                Setting.MaximumValue = 1
                Setting.SettingDatabaseTypeID = 16

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveEncryptedPasswordsPhase1 = Saved

        End Function
        Public Function LoadCountry(ByVal DataContext As AdvantageFramework.Database.DataContext) As Nullable(Of Integer)

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Country As Nullable(Of Integer) = Nothing

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.COUNTRY.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Country = Setting.Value

            End If

            LoadCountry = Country

        End Function
        Public Function SaveCountry(ByVal DataContext As AdvantageFramework.Database.DataContext, Country As Nullable(Of Integer)) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.COUNTRY.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = Country

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            Else

                Setting = New AdvantageFramework.Database.Entities.Setting

                Setting.DataContext = DataContext
                Setting.Code = AdvantageFramework.Agency.Settings.COUNTRY.ToString
                Setting.Description = "Country"
                Setting.Value = Country
                Setting.DefaultValue = Nothing
                Setting.SettingDatabaseTypeID = 19

                Saved = AdvantageFramework.Database.Procedures.Setting.Insert(DataContext, Setting)

            End If

            SaveCountry = Saved

        End Function
        Public Function GetOptionAvaTaxAccountNumber(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Try

                GetOptionAvaTaxAccountNumber = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AVATAX_ACCT_NUMBER.ToString)).SingleOrDefault

            Catch ex As Exception
                GetOptionAvaTaxAccountNumber = Nothing
            End Try

        End Function
        Public Function GetOptionAvaTaxLicenseKey(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Try

                GetOptionAvaTaxLicenseKey = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AVATAX_LICENSE_KEY.ToString)).SingleOrDefault

            Catch ex As Exception
                GetOptionAvaTaxLicenseKey = Nothing
            End Try

        End Function
        Public Function GetOptionAvaTaxURL(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Try

                GetOptionAvaTaxURL = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AVATAX_URL.ToString)).SingleOrDefault

            Catch ex As Exception
                GetOptionAvaTaxURL = Nothing
            End Try

        End Function
        Public Function GetOptionAvaTaxEnabled(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                GetOptionAvaTaxEnabled = CBool(DbContext.Database.SqlQuery(Of String)(String.Format("SELECT CAST([AGY_SETTINGS_VALUE] as varchar(1)) FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AVATAX_ENABLED.ToString)).SingleOrDefault)

            Catch ex As Exception
                GetOptionAvaTaxEnabled = False
            End Try

        End Function
        Public Function GetOptionAvaTaxAddressValidationEnabled(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                GetOptionAvaTaxAddressValidationEnabled = CBool(DbContext.Database.SqlQuery(Of String)(String.Format("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AVATAX_ADR_ENABLED.ToString)).SingleOrDefault)

            Catch ex As Exception
                GetOptionAvaTaxAddressValidationEnabled = False
            End Try

        End Function
        Public Function GetOptionAvaTaxEnableAddressValidationForCountries(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of String)

            Dim Countries As String = Nothing

            Try

                Countries = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AVATAX_ADR_COUNTRIES.ToString)).SingleOrDefault

                If Countries IsNot Nothing Then

                    GetOptionAvaTaxEnableAddressValidationForCountries = Countries.Split(",").ToList

                Else

                    GetOptionAvaTaxEnableAddressValidationForCountries = Nothing

                End If

            Catch ex As Exception
                GetOptionAvaTaxEnableAddressValidationForCountries = Nothing
            End Try

        End Function
        Public Function GetOptionAvaTaxUseClientStreetAddress(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                GetOptionAvaTaxUseClientStreetAddress = CBool(DbContext.Database.SqlQuery(Of String)(String.Format("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AVATAX_USE_CL_ADDR.ToString)).SingleOrDefault)

            Catch ex As Exception
                GetOptionAvaTaxUseClientStreetAddress = False
            End Try

        End Function
        Public Function GetOptionAvaTaxUseJobContactAddress(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                GetOptionAvaTaxUseJobContactAddress = CBool(DbContext.Database.SqlQuery(Of String)(String.Format("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AVATAX_USE_JC_ADDR.ToString)).SingleOrDefault)

            Catch ex As Exception
                GetOptionAvaTaxUseJobContactAddress = False
            End Try

        End Function
        Public Function GetOptionDefaultAPDescriptionFromVendorAccount(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim DefaultFromVendorAccount As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.AP_DEF_DESC_VEN_ACCT.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing AndAlso IsNumeric(Setting.Value) AndAlso Setting.Value = 1 Then

                DefaultFromVendorAccount = True

            End If

            GetOptionDefaultAPDescriptionFromVendorAccount = DefaultFromVendorAccount

        End Function
        Public Function GetOptionAPApprovalAlertDefaultTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext) As Integer

            Try

                GetOptionAPApprovalAlertDefaultTemplate = CInt(DbContext.Database.SqlQuery(Of Integer)("SELECT COALESCE(CAST([AGY_SETTINGS_VALUE] AS INT), 0) FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'AP_APPR_DFLT_TMPLT'").SingleOrDefault)

            Catch ex As Exception
                GetOptionAPApprovalAlertDefaultTemplate = 0
            End Try

        End Function
        Public Function GetOptionAPApprovalAlertDefaultState(ByVal DbContext As AdvantageFramework.Database.DbContext) As Integer

            Try

                GetOptionAPApprovalAlertDefaultState = CInt(DbContext.Database.SqlQuery(Of Integer)("SELECT COALESCE(CAST([AGY_SETTINGS_VALUE] AS INT), 0) FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'AP_APPR_DFLT_STATE'").SingleOrDefault)

            Catch ex As Exception
                GetOptionAPApprovalAlertDefaultState = 0
            End Try

        End Function
        Public Function GetOptionAPMediaImportAlertBuyer(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                GetOptionAPMediaImportAlertBuyer = CBool(DbContext.Database.SqlQuery(Of String)("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'IMP_ALERT_BUYER'").SingleOrDefault)

            Catch ex As Exception
                GetOptionAPMediaImportAlertBuyer = 0
            End Try

        End Function
        Public Function GetOptionAPMediaApprovalAlertAP(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                GetOptionAPMediaApprovalAlertAP = CBool(DbContext.Database.SqlQuery(Of String)("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'AP_APPR_ALERT_AP'").SingleOrDefault)

            Catch ex As Exception
                GetOptionAPMediaApprovalAlertAP = 0
            End Try

        End Function
        Public Function GetOptionAPMediaApprovalAlertAPUser(ByVal DbContext As AdvantageFramework.Database.DbContext) As Short

            Try

                GetOptionAPMediaApprovalAlertAPUser = CShort(DbContext.Database.SqlQuery(Of String)("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'AP_APPR_ALERT_USER'").SingleOrDefault)

            Catch ex As Exception
                GetOptionAPMediaApprovalAlertAPUser = 0
            End Try

        End Function
        Public Function GetOptionAPDefaultAlertGroup(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Try

                GetOptionAPDefaultAlertGroup = DbContext.Database.SqlQuery(Of String)("SELECT [AGY_SETTINGS_VALUE] FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = 'AP_APPR_ALERT_GROUP'").SingleOrDefault

            Catch ex As Exception
                GetOptionAPDefaultAlertGroup = ""
            End Try

        End Function
        Public Function LoadMediaExcludeOrderPDFWithEmail(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim MediaExcludeOrderPDFWithEmail As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.MEDIA_EXCL_ORD_PDF.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                MediaExcludeOrderPDFWithEmail = Setting.Value

            End If

            LoadMediaExcludeOrderPDFWithEmail = MediaExcludeOrderPDFWithEmail

        End Function
        Public Function SaveMediaExcludeOrderPDFWithEmail(ByVal DataContext As AdvantageFramework.Database.DataContext, MediaExcludeOrderPDFWithEmail As Boolean) As Boolean

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.MEDIA_EXCL_ORD_PDF.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                Setting.Value = MediaExcludeOrderPDFWithEmail

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            End If

            SaveMediaExcludeOrderPDFWithEmail = Saved

        End Function

        'please test if you change the below
        Public Function GetValue(ByVal ConnectionString As String, ByVal UserCode As String, ByVal Setting As Settings) As String

            'objects
            Dim SettingValue As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                SettingValue = GetValue(DbContext, Setting)

            End Using

            GetValue = SettingValue

        End Function
        Public Function GetValue(ByVal Session As AdvantageFramework.Security.Session, ByVal Setting As Settings) As String

            'objects
            Dim SettingValue As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                SettingValue = GetValue(DbContext, Setting)

            End Using

            GetValue = SettingValue

        End Function
        Public Function GetValue(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Setting As Settings) As String

            'objects
            Dim SettingValue As String = ""

            Try

                SettingValue = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT CAST(ISNULL(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF) AS VARCHAR(MAX)) AS AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = '{0}';", Setting.ToString)).SingleOrDefault

            Catch ex As Exception
                SettingValue = ""
            End Try

            GetValue = SettingValue

        End Function
        Public Function GetOptionAvaTaxUseJobSalesClass(DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                GetOptionAvaTaxUseJobSalesClass = CBool(DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT CAST([AGY_SETTINGS_VALUE] as int) FROM [dbo].[AGY_SETTINGS] WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.AVATAX_USE_JOB_SC.ToString)).SingleOrDefault)

            Catch ex As Exception
                GetOptionAvaTaxUseJobSalesClass = False
            End Try

        End Function

#End Region

    End Module

End Namespace
