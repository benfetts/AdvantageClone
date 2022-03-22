Namespace Controller.Maintenance.General

    Public Class SettingsSetupController

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum InputTypes
            Textbox = 0
            Password = 1
            NumericTextbox = 2
            Combobox = 3
            Checkbox = 4
            ParentCombobox = 5
        End Enum

#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _SettingModuleID As Integer = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(Session As AdvantageFramework.Security.Session, ByVal SettingModuleID As Integer)

            _Session = Session
            _SettingModuleID = SettingModuleID

        End Sub

        Public Function GetSettings() As Generic.List(Of AdvantageFramework.DTO.Maintenance.General.Settings.Tab)

            'objects
            Dim SettingModuleTabs As Generic.List(Of AdvantageFramework.DTO.Maintenance.General.Settings.Tab) = Nothing
            Dim SettingDatabaseTypes As Generic.List(Of AdvantageFramework.Database.Entities.SettingDatabaseType) = Nothing
            Dim IntegrationSettingTabIDsRemoveFromWV As Generic.List(Of Long) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    SettingModuleTabs = GetSettingTabs(DataContext).Select(Function(t) AdvantageFramework.DTO.Maintenance.General.Settings.Tab.FromEntity(t)).ToList

                    If Session.Application = AdvantageFramework.Security.Application.Webvantage AndAlso _SettingModuleID = 7 Then

                        IntegrationSettingTabIDsRemoveFromWV = New Generic.List(Of Long)({7, 8, 9})

                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

                            IntegrationSettingTabIDsRemoveFromWV.Add(10)

                        End If

                        SettingModuleTabs = SettingModuleTabs.Where(Function(Entity) IntegrationSettingTabIDsRemoveFromWV.Contains(Entity.ID) = False).ToList

                    End If

                    SettingDatabaseTypes = AdvantageFramework.Database.Procedures.SettingDatabaseType.Load(DataContext).ToList

                    For Each SettingModuleTab In SettingModuleTabs

                        SettingModuleTab.Settings = GetSettingsByTab(SettingModuleTab.ID).Select(Function(t) AdvantageFramework.DTO.Maintenance.General.Settings.Setting.FromEntity(t)).ToList

                        LoadSettingTabProperties(SettingModuleTab)

                        For Each Setting In SettingModuleTab.Settings

                            Try

                                Setting.SettingDatabaseType = AdvantageFramework.DTO.Maintenance.General.Settings.SettingDatabaseType.FromEntity(SettingDatabaseTypes.Where(Function(sdt) sdt.ID = Setting.SettingDatabaseTypeID).SingleOrDefault)

                            Catch ex As Exception

                            End Try

                            LoadSettingProperties(DataContext, Setting)

                            If Setting.InputType = InputTypes.Checkbox Then

                                If Setting.Value IsNot Nothing Then

                                    Try

                                        Setting.Value = CBool(Setting.Value)

                                    Catch ex As Exception

                                    End Try

                                End If

                            End If

                        Next

                    Next

                End Using

            End Using

            Return SettingModuleTabs

        End Function

        Private Sub LoadSettingTabProperties(ByVal SettingTab As AdvantageFramework.DTO.Maintenance.General.Settings.Tab)

            Select Case _SettingModuleID

                Case 0

                    LoadSettingTabProperties_ProjectSchedule(SettingTab)

            End Select

        End Sub
        Private Sub LoadSettingProperties(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Setting As AdvantageFramework.DTO.Maintenance.General.Settings.Setting)

            Select Case _SettingModuleID

                Case 0

                    LoadSettingProperties_ProjectSchedule(DataContext, Setting)

                Case 2

                    LoadSettingProperties_ProductionSettings(DataContext, Setting)

                Case 7

                    LoadSettingProperties_IntegrationSettings(DataContext, Setting)

                Case 10

                    LoadSettingProperties_PasswordSettings(DataContext, Setting)

            End Select

        End Sub

        Public Function GetSettingTabs() As Generic.List(Of AdvantageFramework.Database.Entities.SettingModuleTab)

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                Return GetSettingTabs(DataContext)

            End Using

        End Function
        Public Function GetSettingTabs(ByVal DataContext As AdvantageFramework.Database.DataContext) As Generic.List(Of AdvantageFramework.Database.Entities.SettingModuleTab)

            Return AdvantageFramework.Database.Procedures.SettingModuleTab.LoadBySettingModuleID(DataContext, _SettingModuleID).ToList

        End Function

        Public Function GetSettingsByTab(ByVal SettingModuleTabID As Integer) As Generic.List(Of AdvantageFramework.Database.Entities.Setting)

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                Return GetSettingsByTab(DataContext, SettingModuleTabID)

            End Using

        End Function
        Public Function GetSettingsByTab(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingModuleTabID As Integer) As Generic.List(Of AdvantageFramework.Database.Entities.Setting)

            Return AdvantageFramework.Database.Procedures.Setting.LoadBySettingModuleIDAndSettingModuleTabID(DataContext, _SettingModuleID, SettingModuleTabID).ToList

        End Function

        Public Function GetSettingByCode(ByVal Code As String) As AdvantageFramework.DTO.Maintenance.General.Settings.Setting

            'objects
            Dim IntegrationSetting As AdvantageFramework.DTO.Maintenance.General.Settings.Setting = Nothing

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                IntegrationSetting = AdvantageFramework.DTO.Maintenance.General.Settings.Setting.FromEntity(GetSettingByCode(DataContext, Code))

            End Using

            Return IntegrationSetting

        End Function

        Public Function GetSettingByCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Code As String) As AdvantageFramework.Database.Entities.Setting

            Return AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, Code)

        End Function

        Public Function GetSettingValueListByCode(ByVal Code As String) As Generic.List(Of AdvantageFramework.Database.Entities.SettingValue)

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                Return GetSettingValueListByCode(DataContext, Code)

            End Using

        End Function

        Public Function GetSettingValueListByCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Code As String) As Generic.List(Of AdvantageFramework.Database.Entities.SettingValue)

            Return AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCode(DataContext, Code).OrderBy(Function(SettingValue) SettingValue.DisplayText).ToList()

        End Function

        Public Function GetAlertAssignmentStates(ByVal Value As Integer) As Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateState)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Return GetAlertAssignmentStates(DbContext, Value)

            End Using

        End Function

        Public Function GetAlertAssignmentStates(ByVal DBContext As AdvantageFramework.Database.DbContext, ByVal Value As Integer) As Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateState)

            Return AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateID(DBContext, Value).OrderBy(Function(AlertAssignmentTemplateState) AlertAssignmentTemplateState.AlertState.Name).ToList()

        End Function

        Public Function GetSettingDatabaseType(ByVal SettingDatabaseTypeID As Integer) As AdvantageFramework.Database.Entities.SettingDatabaseType

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                Return GetSettingDatabaseType(DataContext, SettingDatabaseTypeID)

            End Using

        End Function

        Public Function GetSettingDatabaseType(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingDatabaseTypeID As Integer) As AdvantageFramework.Database.Entities.SettingDatabaseType

            Return AdvantageFramework.Database.Procedures.SettingDatabaseType.LoadBySettingDatabaseTypeID(DataContext, SettingDatabaseTypeID)

        End Function

        Public Function GetEmployees() As Generic.List(Of AdvantageFramework.Database.Views.Employee)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Return GetEmployees(DbContext, SecurityDbContext)

                End Using

            End Using

        End Function

        Public Function GetEmployees(DbContext As Object, SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Views.Employee)

            Return AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext).ToList

        End Function

        Public Function Save(Setting As AdvantageFramework.DTO.Maintenance.General.Settings.Setting) As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim SettingEntity As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim SettingDatabaseType As AdvantageFramework.Database.Entities.SettingDatabaseType = Nothing

            Try

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    SettingEntity = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, Setting.Code)

                    If SettingEntity IsNot Nothing Then

                        If Setting.Value IsNot Nothing Then

                            SettingEntity.Value = Setting.Value

                            SettingDatabaseType = AdvantageFramework.Database.Procedures.SettingDatabaseType.LoadBySettingDatabaseTypeID(DataContext, SettingEntity.SettingDatabaseTypeID)

                            If SettingDatabaseType IsNot Nothing Then

                                Select Case SettingDatabaseType.DatabaseTypeID

                                    Case 7

                                        SettingEntity.Value = If(CBool(Setting.Value) = True, 1, 0)

                                End Select

                            End If

                        Else

                            SettingEntity.Value = Nothing

                        End If

                        Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, SettingEntity)

                    End If

                End Using

            Catch ex As Exception
                Saved = False
            Finally
                Save = Saved
            End Try

        End Function

        Public Function LoadSettingLookupValues(ByVal Code As String) As Generic.List(Of AdvantageFramework.DTO.Maintenance.General.Settings.SettingValue)

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return LoadSettingLookupValues(DataContext, Code)

            End Using

        End Function
        Private Function LoadSettingLookupValues(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Code As String) As Generic.List(Of AdvantageFramework.DTO.Maintenance.General.Settings.SettingValue)

            Return AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCode(DataContext, Code).Select(Function(s) AdvantageFramework.DTO.Maintenance.General.Settings.SettingValue.FromEntity(s)).ToList

        End Function
        Private Function LoadAlertAssignmentTemplateState() As Generic.List(Of AdvantageFramework.DTO.Maintenance.General.Settings.SettingValue)

            Dim AlertAssignmentStates As Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateState) = Nothing
            Dim SettingValues As Generic.List(Of AdvantageFramework.DTO.Maintenance.General.Settings.SettingValue) = Nothing
            Dim SettingValue As DTO.Maintenance.General.Settings.SettingValue = Nothing

            SettingValues = New List(Of DTO.Maintenance.General.Settings.SettingValue)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                AlertAssignmentStates = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.Load(DbContext).OrderBy(Function(AlertAssignmentTemplateState) AlertAssignmentTemplateState.AlertState.Name).ToList()

                For Each State As AdvantageFramework.Database.Entities.AlertAssignmentTemplateState In AlertAssignmentStates

                    SettingValue = New DTO.Maintenance.General.Settings.SettingValue
                    With SettingValue
                        .DisplayText = State.AlertState.Name
                        .ID = State.AlertStateID
                        .Value = State.AlertStateID
                        .ParentID = State.AlertAssignmentTemplateID
                    End With

                    SettingValues.Add(SettingValue)
                Next

            End Using

            Return SettingValues

        End Function

        Public Function LoadDefaults(ByVal SettingModuleID As Integer) As Boolean
            Try
                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    For Each Setting In AdvantageFramework.Database.Procedures.Setting.LoadBySettingModuleID(DataContext, SettingModuleID)

                        Setting.Value = Setting.DefaultValue

                        AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                    Next

                    Return True

                End Using

            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function GetQuickbooksURL(ByRef RevocationEndpoint As String) As String

            Dim AuthorizationRequest As String = Nothing
            Dim ClientID As String = Nothing
            Dim DiscoveryData As AdvantageFramework.Quickbooks.Classes.DiscoveryData = Nothing
            Dim ScopeVal As String = "com.intuit.quickbooks.accounting com.intuit.quickbooks.payment openid email profile phone address"
            Dim RedirectURI As String = Nothing

            Try

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    RedirectURI = DbContext.Database.SqlQuery(Of String)("SELECT WEBVANTAGE_URL from dbo.AGENCY").FirstOrDefault

                    If RedirectURI.EndsWith("/") Then

                        RedirectURI += "Quickbooks_Authentication.aspx"

                    Else

                        RedirectURI += "/Quickbooks_Authentication.aspx"

                    End If

                End Using

                ClientID = AdvantageFramework.Quickbooks.GetClientID()

                DiscoveryData = AdvantageFramework.Quickbooks.GetDiscoveryData()

                If DiscoveryData IsNot Nothing Then

                    RevocationEndpoint = DiscoveryData.RevocationEndpoint

                    AuthorizationRequest = String.Format("{0}?client_id={1}&response_type=code&scope={2}&redirect_uri={3}&state={4}",
                                DiscoveryData.AuthorizationEndpoint,
                                ClientID,
                                System.Uri.EscapeDataString(ScopeVal),
                                System.Uri.EscapeDataString(RedirectURI),
                                System.Uri.EscapeDataString(AdvantageFramework.Security.Encryption.Encrypt("Database=" & Session.DatabaseName & "&DateTime=" & Now.ToString("yyyyMMddHHmmss"))))

                End If

            Catch ex As Exception

            End Try

            'GetQuickbooksURL = "https://appcenter.intuit.com/connect/oauth2?client_id=ABCQhnvDbWL4Jn4Cy0sUEm6Vejs6kSzOlJ4BpgjFq7lpRxhsNF&response_type=code&scope=com.intuit.quickbooks.accounting+com.intuit.quickbooks.payment+openid+address+email+phone+profile&redirect_uri=http%3A%2F%2Flocalhost%2FWebvantageDevNext%2FQuickbooks_Authentication.aspx&state=968ba5ccdfce49ec83fd84f8ea5a8d31"

            GetQuickbooksURL = AuthorizationRequest

        End Function

#End Region

#Region " -- Project Schedule Settings -- "
        Private Sub LoadSettingTabProperties_ProjectSchedule(ByVal SettingModuleTab As AdvantageFramework.DTO.Maintenance.General.Settings.Tab)

            If SettingModuleTab.ID = 1 Then

                SettingModuleTab.Footer = "* Not Applicable when using Predecessor"

            End If

        End Sub
        Private Sub LoadSettingProperties_ProjectSchedule(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Setting As AdvantageFramework.DTO.Maintenance.General.Settings.Setting)

            Select Case Setting.Code

                Case "TRF_HRS"

                    Setting.InputType = InputTypes.NumericTextbox

                Case "TRF_SCHEDULE_BY"

                    Setting.DisplayDescription = Setting.Description.Replace("due date", "due date*")
                    Setting.InputType = InputTypes.Checkbox

                Case "TRF_LOCK_DATE"

                    Setting.InputType = InputTypes.Checkbox

                Case "TRF_CALC_BY_CMP"

                    Setting.InputType = InputTypes.Checkbox

                Case "USE_PHASE"

                    Setting.DisplayDescription = Setting.Description & "*"
                    Setting.InputType = InputTypes.Checkbox

                Case "TRF_UPDATE_STATUS"

                    Setting.InputType = InputTypes.Checkbox

                Case "TRF_CALC_CONCUR_DT"

                    Setting.DisplayDescription = Setting.Description & "*"
                    Setting.InputType = InputTypes.Checkbox

                Case "TRF_CALC_BY_DAY"

                    Setting.InputType = InputTypes.Checkbox

                Case "TRF_UPDATE_ALERT_DUE"

                    Setting.InputType = InputTypes.Checkbox

                Case "TRF_ALRT_TMP_CMPLT"

                    Setting.InputType = InputTypes.Checkbox

                Case "TRF_ACTIVE_NEXT_TASK"

                    Setting.InputType = InputTypes.Checkbox

                Case "TRF_NXT_TSK_AUTO_EML"

                    Setting.InputType = InputTypes.Checkbox

                Case "TRF_DEL_TSK_ALRT"

                    Setting.InputType = InputTypes.Checkbox

                Case "TRF_COMP_ALERT"

                    Setting.InputType = InputTypes.Combobox
                    Setting.SettingValues = LoadSettingLookupValues(DataContext, Setting.Code)

                Case "TRF_TEMP_COMP_ALERT"

                    Setting.InputType = InputTypes.Combobox
                    Setting.SettingValues = LoadSettingLookupValues(DataContext, Setting.Code)

                Case "TRF_COMP_NO_TMP"

                    Setting.InputType = InputTypes.Combobox
                    Setting.SettingValues = LoadSettingLookupValues(DataContext, Setting.Code)

                Case "TRF_CMPLT_ON_LAST"

                    Setting.InputType = InputTypes.Checkbox

                Case "TR_TITLE1"

                    Setting.InputType = InputTypes.Textbox

                Case "TR_TITLE2"

                    Setting.InputType = InputTypes.Textbox

                Case "TR_TITLE3"

                    Setting.InputType = InputTypes.Textbox

                Case "TR_TITLE4"

                    Setting.InputType = InputTypes.Textbox

                Case "TR_TITLE5"

                    Setting.InputType = InputTypes.Textbox

                Case "TRAFFIC_MGR_COL"

                    Setting.InputType = InputTypes.Combobox
                    Setting.SettingValues = LoadSettingLookupValues(DataContext, Setting.Code)
                    Setting.ShowPleaseSelect = True

            End Select

        End Sub

#End Region

#Region " -- Production Settings -- "

        Private Sub LoadSettingProperties_ProductionSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Setting As AdvantageFramework.DTO.Maintenance.General.Settings.Setting)

            Select Case Setting.Code

                Case "JOB_VERSION_DESC"

                    Setting.InputType = InputTypes.Textbox

                Case "JR_DFLT_TMPLT"

                    Setting.InputType = InputTypes.Combobox
                    Setting.SettingValues = LoadSettingLookupValues(DataContext, Setting.Code)
                    Setting.ShowPleaseSelect = True

                Case "JR_ALERT_SETTING"

                    Setting.InputType = InputTypes.Combobox
                    Setting.SettingValues = LoadSettingLookupValues(DataContext, Setting.Code)
                    Setting.ShowPleaseSelect = True

                Case "JR_ASSIGN_TMPLT"

                    Setting.InputType = InputTypes.ParentCombobox
                    Setting.SettingValues = LoadSettingLookupValues(DataContext, Setting.Code)
                    Setting.ChildCode = "JR_ASSIGN_STATE"
                    Setting.ShowPleaseSelect = True

                Case "JR_ASSIGN_STATE"

                    Setting.InputType = InputTypes.Combobox
                    Setting.SettingValues = LoadAlertAssignmentTemplateState()
                    Setting.ShowPleaseSelect = True

                Case "JR_DFLT_ALERT_GROUP"

                    Setting.InputType = InputTypes.Combobox
                    Setting.SettingValues = LoadSettingLookupValues(DataContext, Setting.Code)
                    Setting.ShowPleaseSelect = True

                Case "JR_DFLT_CONTACT"

                    Setting.InputType = InputTypes.Combobox
                    Setting.SettingValues = LoadSettingLookupValues(DataContext, Setting.Code)
                    Setting.ShowPleaseSelect = True

                Case "JOB_PS_REQ_ON_NEW"

                    Setting.InputType = InputTypes.Checkbox

                Case "PS_REQ_MGR"

                    Setting.InputType = InputTypes.Checkbox

                Case "TRF_DFLT_STATUS"

                    Setting.InputType = InputTypes.Combobox
                    Setting.SettingValues = LoadSettingLookupValues(DataContext, Setting.Code)
                    Setting.ShowPleaseSelect = True

                Case "FOLD_FUNCTION"

                    Setting.InputType = InputTypes.Textbox

                Case "ACC_SETUP_CODE_1"

                    Setting.InputType = InputTypes.Textbox

                Case "ACC_SETUP_CODE_2"

                    Setting.InputType = InputTypes.Textbox

                Case "ACC_SETUP_CODE_3"

                    Setting.InputType = InputTypes.Textbox

                Case "ACC_SETUP_CODE_4"

                    Setting.InputType = InputTypes.Textbox

                Case "CAMP_AUTO_GEN_CODE"

                    Setting.InputType = InputTypes.Checkbox

                Case "ASSIGN_TYPE_DEFAULT"

                    Setting.InputType = InputTypes.Checkbox

                Case "CAMP_REQUIRE_DIV_PRD"

                    Setting.InputType = InputTypes.Checkbox

            End Select

        End Sub

#End Region

#Region " -- Integration Settings -- "

        Private Sub LoadSettingProperties_IntegrationSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Setting As AdvantageFramework.DTO.Maintenance.General.Settings.Setting)

            Select Case Setting.Code

                Case "SYNC_GOOGLECALENDAR"

                    Setting.InputType = InputTypes.Checkbox

                Case "SYNC_OUTLOOK"

                    Setting.InputType = InputTypes.Checkbox

                Case "SYNC_OUTLOOK_USE_EX"

                    Setting.InputType = InputTypes.Checkbox

                Case "SYNC_SUGARCRM"

                    Setting.InputType = InputTypes.Checkbox

                Case "SYNC_SUGARCRM_URL"

                    Setting.InputType = InputTypes.Textbox

                Case "PROOFHQ_ENABLED"

                    Setting.InputType = InputTypes.Checkbox

                Case "PROOFHQ_USE_SA"

                    Setting.InputType = InputTypes.Checkbox

                Case "PROOFHQ_SA_USERNAME"

                    Setting.InputType = InputTypes.Textbox

                Case "PROOFHQ_SA_PASSWORD"

                    Setting.InputType = InputTypes.Password

                Case "CONCEPTSHARE_ENABLED"

                    Setting.InputType = InputTypes.Checkbox

                Case "CS_ENABLED"

                    Setting.InputType = InputTypes.Checkbox

                Case "CS_URL"

                    Setting.InputType = InputTypes.Textbox

                Case "CS_SA_USERNAME"

                    Setting.InputType = InputTypes.Textbox

                Case "CS_SA_PASSWORD"

                    Setting.InputType = InputTypes.Password

                Case "DC_ENABLED"

                    Setting.InputType = InputTypes.Checkbox

                Case "DC_PROFILE_ID"

                    Setting.InputType = InputTypes.NumericTextbox
                    Setting.FormatString = "#" ' required for Kendo to hide the Comma 

                Case "DC_REPORT_ID"

                    Setting.InputType = InputTypes.NumericTextbox
                    Setting.FormatString = "#" ' required for Kendo to hide the Comma 

                Case "DC_HELP"

                    Setting.InputType = InputTypes.Textbox

                Case "NIELSEN_DB_SERVER"

                    Setting.InputType = InputTypes.Textbox

                Case "NIELSEN_DB_NAME"

                    Setting.InputType = InputTypes.Textbox

                Case "NIELSEN_DB_USER"

                    Setting.InputType = InputTypes.Textbox

                Case "NIELSEN_DB_PASSWORD"

                    Setting.InputType = InputTypes.Password

                Case "NIELSEN_WINDOWS_AUTH"

                    Setting.InputType = InputTypes.Checkbox

                Case "EASTLAN_ENABLED"

                    Setting.InputType = InputTypes.Checkbox

                Case "NATIONAL_DB_NAME"

                    Setting.InputType = InputTypes.Textbox

                Case "NATIONAL_DB_PASSWORD"

                    Setting.InputType = InputTypes.Password

                Case "NATIONAL_DB_SERVER"

                    Setting.InputType = InputTypes.Textbox

                Case "NATIONAL_DB_USER"

                    Setting.InputType = InputTypes.Textbox

                Case "NATIONAL_WIN_AUTH"

                    Setting.InputType = InputTypes.Checkbox

                Case "QB_ENABLED"

                    Setting.InputType = InputTypes.Checkbox

            End Select

        End Sub

#End Region

#Region " -- Password Settings -- "

        Private Sub LoadSettingProperties_PasswordSettings(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                           ByVal Setting As AdvantageFramework.DTO.Maintenance.General.Settings.Setting)

            Select Case Setting.Code

                Case "PWD_CXT_LC" ' Lowercase

                    Setting.InputType = InputTypes.Checkbox

                Case "PWD_CXT_NUM" ' Number

                    Setting.InputType = InputTypes.Checkbox

                Case "PWD_CXT_REQ" ' Password complexity required

                    Setting.InputType = InputTypes.Checkbox

                Case "PWD_CXT_UC" ' Uppercase

                    Setting.InputType = InputTypes.Checkbox

                Case "PWD_EXP_DYS" ' Password expiration (age) days

                    Setting.InputType = InputTypes.NumericTextbox
                    Setting.FormatString = "#" ' required for Kendo to hide the Comma 

                Case "PWD_HIST_CT" ' Password history

                    Setting.InputType = InputTypes.NumericTextbox
                    Setting.FormatString = "#" ' required for Kendo to hide the Comma 

                Case "PWD_MIN_LEN" ' Minimum password length

                    Setting.InputType = InputTypes.NumericTextbox
                    Setting.FormatString = "#" ' required for Kendo to hide the Comma 

                Case "PWD_MAX_FAIL" ' Attempts before lockout

                    Setting.InputType = InputTypes.NumericTextbox
                    Setting.FormatString = "#" ' required for Kendo to hide the Comma 

                Case "PWD_LO_TO" ' Lockout reset (minutes)

                    Setting.InputType = InputTypes.NumericTextbox
                    Setting.FormatString = "#" ' required for Kendo to hide the Comma 

                Case "PWD_XST_SPL" ' Special Character

                    Setting.InputType = InputTypes.Checkbox

                Case "DC_PROFILE_ID" ' 

                    Setting.InputType = InputTypes.NumericTextbox
                    Setting.FormatString = "#" ' required for Kendo to hide the Comma 

                Case "PWD_TWO_FCTR"

                    Setting.InputType = InputTypes.Combobox
                    Setting.SettingValues = LoadSettingLookupValues(DataContext, Setting.Code)
                    Setting.ShowPleaseSelect = True

            End Select

        End Sub

#End Region

#Region " Quickbooks "

        Private Function randomDataBase64url(ByVal length As UInteger) As String
            Dim rng As System.Security.Cryptography.RNGCryptoServiceProvider = New System.Security.Cryptography.RNGCryptoServiceProvider()
            Dim bytes As Byte() = New Byte(length - 1) {}
            rng.GetBytes(bytes)
            Return Base64urlencodeNoPadding(bytes)
        End Function
        Private Function Base64urlencodeNoPadding(ByVal buffer As Byte()) As String
            Dim base64 As String = Convert.ToBase64String(buffer)
            base64 = base64.Replace("+", "-")
            base64 = base64.Replace("/", "_")
            base64 = base64.Replace("=", "")
            Return base64
        End Function
        'Private Sub PerformRefreshToken(ByVal access_token As String, ByVal refresh_token As String)

        '    'output("Performing Revoke tokens.")

        '    Dim cred As String = String.Format("{0}:{1}", clientID, clientSecret)
        '    Dim enc As String = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(cred))
        '    Dim basicAuth As String = String.Format("{0} {1}", "Basic", enc)
        '    Dim tokenRequestBody As String = "{""token"":""" & refresh_token & """}"
        '    Dim tokenRequest As System.Net.HttpWebRequest = CType(System.Net.WebRequest.Create(revokeEndpoint), System.Net.HttpWebRequest)
        '    tokenRequest.Method = "POST"
        '    tokenRequest.ContentType = "application/json"
        '    tokenRequest.Accept = "application/json"
        '    tokenRequest.Headers(System.Net.HttpRequestHeader.Authorization) = basicAuth
        '    Dim _byteVersion As Byte() = System.Text.Encoding.ASCII.GetBytes(tokenRequestBody)
        '    tokenRequest.ContentLength = _byteVersion.Length
        '    Dim stream As System.IO.Stream = tokenRequest.GetRequestStream()
        '    stream.Write(_byteVersion, 0, _byteVersion.Length)
        '    stream.Close()

        '    Try
        '        Dim response As System.Net.HttpWebResponse = CType(tokenRequest.GetResponse(), System.Net.HttpWebResponse)

        '        If response.StatusCode = System.Net.HttpStatusCode.OK Then
        '            'output("Successful Revoke!")
        '        ElseIf response.StatusCode = System.Net.HttpStatusCode.BadRequest Then
        '            'output("One or more of BearerToken, RefreshToken, ClientId or, ClientSecret are incorrect.")
        '        ElseIf response.StatusCode = System.Net.HttpStatusCode.Unauthorized Then
        '            'output("Bad authorization header or no authorization header sent.")
        '        ElseIf response.StatusCode = System.Net.HttpStatusCode.InternalServerError Then
        '            'output("Intuit server internal error, not the fault of the developer.")
        '        End If

        '        'Session.Clear()
        '        'Session.Abandon()

        '        'If Request.Url.Query = "" Then
        '        '    response.Redirect(Request.RawUrl)
        '        'Else
        '        '    response.Redirect(Request.RawUrl.Replace(Request.Url.Query, ""))
        '        'End If

        '    Catch ex As System.Net.WebException
        '        'Session.Clear()
        '        'Session.Abandon()

        '        If ex.Status = System.Net.WebExceptionStatus.ProtocolError Then
        '            Dim response = TryCast(ex.Response, System.Net.HttpWebResponse)

        '            If response IsNot Nothing Then
        '                'output("HTTP Status: " & response.StatusCode)
        '                Dim exceptionDetail = response.GetResponseHeader("WWW-Authenticate")

        '                If exceptionDetail IsNot Nothing AndAlso exceptionDetail <> "" Then
        '                    'output(exceptionDetail)
        '                End If

        '                Using reader As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
        '                    Dim responseText As String = reader.ReadToEnd()

        '                    If responseText IsNot Nothing AndAlso responseText <> "" Then
        '                        'output(responseText)
        '                    End If
        '                End Using
        '            End If
        '        End If
        '    End Try

        '    'output("Token revoked.")

        'End Sub

#End Region

    End Class

End Namespace
