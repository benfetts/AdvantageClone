Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing
Imports System.Drawing
Imports AdvantageFramework.Database.Entities
Imports Kendo.Mvc.Extensions
Imports Newtonsoft.Json
Imports Webvantage.ViewModels


Namespace Controllers.Utilities

    Public Class SettingsController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "Utilities/Settings/"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Private _Controller As AdvantageFramework.Controller.Maintenance.General.SettingsSetupController = Nothing
        Protected _SettingModuleID As Integer = -1

#End Region

#Region " Methods "

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New AdvantageFramework.Controller.Maintenance.General.SettingsSetupController(Me.SecuritySession, _SettingModuleID)

        End Sub
        Public Function SettingsPage() As ViewResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing
            Dim Title As String = Nothing

            AureliaModel = New AureliaModel

            AureliaModel.App = "modules/utilities/settings-page/settings-page"
            AureliaModel.Parameters.Add("SettingModule", _SettingModuleID)

            Select Case _SettingModuleID

                Case 0

                    Title = "Project Schedule Settings"

                Case 2

                    Title = "Production Settings"

                Case 7

                    Title = "Integration Settings"

                Case 10

                    Title = "Password Settings"

            End Select

            ViewBag.Title = Title

            Return Aurelia(AureliaModel)

        End Function

#End Region

#Region " API "

        <Mvc.HttpGet>
        Public Function GetSettings() As System.Web.Mvc.JsonResult

            'objects
            Dim Settings As IEnumerable(Of AdvantageFramework.DTO.Maintenance.General.Settings.Tab) = Nothing

            Settings = _Controller.GetSettings()

            Return MaxJson(Settings, Mvc.JsonRequestBehavior.AllowGet)

        End Function
        <Mvc.HttpPost>
        Public Function UpdateSetting(ByVal Setting As AdvantageFramework.DTO.Maintenance.General.Settings.Setting) As Mvc.JsonResult

            'objects
            Dim Updated As Boolean = False

            Updated = _Controller.Save(Setting)

            Return Json(Updated)

        End Function
        <Mvc.HttpGet>
        Public Function GetSettingByCode(ByVal Code As String) As System.Web.Mvc.JsonResult

            Dim Setting As AdvantageFramework.DTO.Maintenance.General.Settings.Setting = Nothing

            'get the setting
            Setting = _Controller.GetSettingByCode(Code)

            'get the setting's database type
            Setting.SettingDatabaseType = AdvantageFramework.DTO.Maintenance.General.Settings.SettingDatabaseType.FromEntity(
            _Controller.GetSettingDatabaseType(Setting.SettingDatabaseTypeID))

            Return Json(Setting, Mvc.JsonRequestBehavior.AllowGet)

        End Function
        <Mvc.HttpGet>
        Public Function GetSettingValueList(ByVal Code As String) As System.Web.Mvc.JsonResult

            Dim SettingValues As Generic.List(Of AdvantageFramework.Database.Entities.SettingValue) = Nothing

            'get the setting
            SettingValues = _Controller.GetSettingValueListByCode(Code)

            Return Json(SettingValues, Mvc.JsonRequestBehavior.AllowGet)

        End Function
        <Mvc.HttpGet>
        Public Function GetEmployees() As System.Web.Mvc.JsonResult

            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

            'get the setting
            Employees = _Controller.GetEmployees

            Return Json(Employees, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <Mvc.HttpPost>
        Public Function loadDefaults(ByVal SettingModuleID As Integer) As System.Web.Mvc.JsonResult

            Dim Loaded As Boolean = True

            'load defaults
            Loaded = _Controller.LoadDefaults(SettingModuleID)

            Return Json(Loaded)

        End Function

        <Mvc.HttpPost>
        Public Function SaveSettings(ByVal NickName As String,
                                     ByVal BackGroundColor As String,
                                     ByVal CustomTextColor As String,
                                     ByVal TimeZone As String,
                                     ByVal ShowDBName As Boolean,
                                     ByVal IsDarkMode As Boolean) As JsonResult
            Try

                Dim e As New cEmployee(Session("ConnString"))
                e.EmployeePicture_SaveNickname(Session("EmpCode"), NickName)

            Catch ex As Exception
            End Try

            Try

                Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
                Dim cEmp As New cEmployee(Session("ConnString"))
                Dim dr As SqlClient.SqlDataReader

                t.Load()

                With t.Settings

                    .BackgroundColor = CustomTextColor
                    .TextColor = CustomTextColor
                    '.UseLayout = UserThemeSettings.Layout.Simple
                    .SimpleLayoutBackgroundColor = BackGroundColor 'Drawing.ColorTranslator.ToHtml(Me.RadColorPickerSimpleLayoutBackground.SelectedColor).ToString()
                    .SimpleLayoutSideBarColor = BackGroundColor
                    .BackgroundType = UserThemeSettings.ImageType.SolidColor
                    '.SimpleLayoutIconStyle = Me.RadioButtonListIconStyle.SelectedValue
                    .UseBackgroundColorOnSignInPage = False
                    .ShowDatabaseName = ShowDBName
                    .IsDarkMode = IsDarkMode
                    '.TelerikTheme = Me.RadioButtonListTheme.SelectedItem.Value
                    '.FloatDesktopObjects = Me.CheckBoxFloatObjects.Checked
                    '.SingleNodeMainMenu = Me.RadioButtonMenuSingeNode.Checked

                    'If Me.RadComboBoxLogo.SelectedIndex = -1 Then

                    '    CType(Me.RadComboBoxLogo.FindItemByValue("Light.png"), Telerik.Web.UI.RadComboBoxItem).Selected = True

                    'End If

                    '.Logo = GetLogoFileName()
                    '.ClickToOpenUserMenu = Me.CheckBoxClickToOpenUserMenu.Checked
                    '.ClickToOpenAppMenu = Me.CheckBoxClickToOpenAppMenu.Checked
                    '.EnableWeather = Me.CheckBoxEnableWeather.Checked
                    '.SimpleLayoutShowNewMenu = Me.CheckBoxShowNewMenu.Checked
                    '.SimpleLayoutShowAppMenu = Me.CheckBoxShowApplicationsMenu.Checked
                    If TimeZone IsNot Nothing Then
                        .TimeZoneID = TimeZone
                    Else
                        .TimeZoneID = ""
                    End If


                End With

                t.Save()
                t.Reload()

                If MiscFN.IsClientPortal = False Then

                    cEmployee.ResetTimeZoneOffsetSession()

                Else

                    cEmployee.ResetClientPortalUserTimeZoneOffsetSession()

                End If

                'ErrorMessage = ""
                Return Json(True)

            Catch ex As Exception

                'ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                Return Json(True)

            End Try

        End Function

        <Mvc.HttpGet>
        Public Function LoadSettings() As JsonResult

            Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
            Dim Settings As UserThemeSettings
            Dim EmployeeSetting As AdvantageFramework.DTO.Maintenance.General.Settings.SettingEmployee = Nothing
            Dim EmployeeSettings As IEnumerable(Of AdvantageFramework.DTO.Maintenance.General.Settings.SettingEmployee) = Nothing
            Dim ModuleAccess As Integer = 0

            Dim dr As SqlClient.SqlDataReader
            Dim cEmp As New cEmployee(Session("ConnString"))

            dr = cEmp.GetEmployeeProfile(Session("EmpCode"))


            'If IsDBNull(dr("EMP_IMAGE")) = False Then

            '        Me.ASPxBinaryImageEmployeePicture.Value = CType(dr("EMP_IMAGE"), Byte())

            '    Else

            '        Me.ASPxBinaryImageEmployeePicture.Value = Nothing

            '    End If

            With t

                .Reload()

                Settings = t.Settings

                EmployeeSetting = New AdvantageFramework.DTO.Maintenance.General.Settings.SettingEmployee

                With EmployeeSetting

                    .Code = Session("EmpCode")

                    If dr.HasRows Then
                        dr.Read()
                        If IsDBNull(dr("EMP_NICKNAME")) = False Then
                            .Nickname = dr("EMP_NICKNAME")
                        End If
                        If IsDBNull(dr("EMP_WALLPAPER")) = False Then
                            .BackgroundPhoto = dr("EMP_WALLPAPER")
                        End If
                        dr.Close()
                    End If

                    .BackgroundColor = Settings.SimpleLayoutBackgroundColor
                    .CustomTextColor = Settings.BackgroundColor
                    .TimeZone = Settings.TimeZoneID
                    .ShowDatabaseName = Settings.ShowDatabaseName
                    .IsDarkMode = Settings.IsDarkMode

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))

                        Try

                            ModuleAccess = AdvantageFramework.Security.DoesUserHaveAccessToModule(SecuritySession, AdvantageFramework.Security.Modules.Maintenance_General_AgencySettings, SecuritySession.User)

                        Catch ex As Exception
                            ModuleAccess = 0
                        End Try

                        If ModuleAccess = -1 Then

                            ModuleAccess = 1

                        End If

                        If ModuleAccess = 1 Then

                            .AgencySettings = True

                        End If

                        Try

                            ModuleAccess = AdvantageFramework.Security.DoesUserHaveAccessToModule(SecuritySession, AdvantageFramework.Security.Modules.Security_ChangePassword, SecuritySession.User)

                        Catch ex As Exception
                            ModuleAccess = 0
                        End Try

                        If ModuleAccess = -1 Then

                            ModuleAccess = 1

                        End If

                        If ModuleAccess = 1 Then

                            .ChangePassword = True

                        End If

                    End Using

                End With



            End With

            Return MaxJson(EmployeeSetting, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <HttpPost>
        Public Function UploadProfilePicture(ByVal ProfilePicFile As HttpPostedFileBase) As JsonResult
            'objects
            Dim NewFilename As String = Nothing
            Dim MIMEType As String = Nothing
            Dim ErrorMessage As String = Nothing
            Dim RealFilename As String = Nothing
            Dim FileLength As Integer = 0
            Dim ValidFileType As Boolean = False
            Dim Saved As Boolean = False
            Dim BitMapFile = Nothing
            Dim cAgency As cAgency = Nothing

            FileLength = ProfilePicFile.InputStream.Length

            RealFilename = ProfilePicFile.FileName

            BitMapFile = New Bitmap(ProfilePicFile.InputStream)

            ProfilePicFile.InputStream.Seek(0, IO.SeekOrigin.Begin)

            If Not ProfilePicFile.ContentType Is Nothing Then

                MIMEType = ProfilePicFile.ContentType

            Else

                MIMEType = ""

            End If

            If MIMEType.Contains("jpeg") OrElse MIMEType.Contains("png") OrElse MIMEType.Contains("gif") OrElse MIMEType.Contains("bmp") Then

                ValidFileType = True

            End If

            If FileLength > 0 Then

                Dim FileBytes(FileLength - 1) As Byte

                If FileBytes.Length > 200000 Then

                    ErrorMessage = ("The selected file exceeds the file size limit.")

                ElseIf Not ValidFileType Then

                    ErrorMessage = ("The selected file must be one of the following types: .jpg, .jpeg, .gif, .png or .bmp.")

                Else

                    If ProfilePicFile.InputStream.Read(FileBytes, 0, FileLength) Then

                        cAgency = New cAgency(Session("ConnString"))

                        If cAgency.EmployeePicture_SaveBinaryImage(Session("EmpCode"), FileBytes) = True Then

                            Saved = True

                        End If

                    End If

                End If


            End If

            If Saved Then

                Return MaxJson(Saved)

            Else

                Response.StatusCode = CInt(Net.HttpStatusCode.InternalServerError)
                Return MaxJson(ErrorMessage)

            End If

        End Function

        <HttpPost>
        Public Function RemoveProfilePicture() As JsonResult
            Dim Saved As Boolean = False
            Dim cAgency As cAgency = Nothing

            cAgency = New cAgency(Session("ConnString"))

            If cAgency.EmployeePicture_DeleteBinaryImage(Session("EmpCode")) = True Then

                Saved = True

            End If

            Return MaxJson(Saved)
        End Function

        <HttpPost>
        Public Function UploadSignature(ByVal SignatureFile As HttpPostedFileBase) As JsonResult
            'objects
            Dim NewFilename As String = ""
            Dim MIMEType As String = ""
            Dim ErrorMessage As String = ""
            Dim RealFilename As String = ""
            Dim FileLength As Integer = 0
            Dim ValidFileType As Boolean = False
            Dim Saved As Boolean = False
            Dim BitMapFile = Nothing
            Dim cAgency As cAgency = Nothing

            FileLength = SignatureFile.InputStream.Length

            RealFilename = SignatureFile.FileName

            BitMapFile = New Bitmap(SignatureFile.InputStream)

            SignatureFile.InputStream.Seek(0, IO.SeekOrigin.Begin)

            If Not SignatureFile.ContentType Is Nothing Then

                MIMEType = SignatureFile.ContentType

            Else

                MIMEType = ""

            End If

            If MIMEType.Contains("jpeg") OrElse MIMEType.Contains("png") OrElse MIMEType.Contains("gif") OrElse MIMEType.Contains("bmp") Then

                ValidFileType = True

            End If

            If FileLength > 0 Then

                Dim FileBytes(FileLength - 1) As Byte

                If FileBytes.Length > 32765 Then

                    ErrorMessage = ("The selected file exceeds the file size limit.")

                ElseIf Not ValidFileType Then

                    ErrorMessage = ("The selected file must be one of the following types: .jpg, .jpeg, .gif, .png or .bmp.")

                ElseIf BitMapFile.Width <> 264 Or BitMapFile.Height <> 72 Then
                    'file must be 2.75" x .75" per requirements; 1" = 96px

                    ErrorMessage = ("The selected file has the incorrect dimensions.")

                Else

                    If SignatureFile.InputStream.Read(FileBytes, 0, FileLength) Then

                        cAgency = New cAgency(Session("ConnString"))

                        If cAgency.EmployeeSignature_SaveBinaryImage(Session("EmpCode"), FileBytes) = True Then

                            Saved = True

                        End If

                    End If

                End If


            End If

            If Saved Then

                Return MaxJson(Saved)

            Else

                Response.StatusCode = CInt(Net.HttpStatusCode.InternalServerError)
                Return MaxJson(ErrorMessage)

            End If

        End Function

        <HttpPost>
        Public Function RemoveSignature() As JsonResult
            Dim Saved As Boolean = False
            Dim cAgency As cAgency = Nothing

            cAgency = New cAgency(Session("ConnString"))

            If cAgency.EmployeeSignature_DeleteBinaryImage(Session("EmpCode")) = True Then

                Saved = True

            End If

            Return MaxJson(Saved)
        End Function

        <HttpPost>
        Public Function UploadBackgroundPhoto(ByVal File As HttpPostedFileBase) As JsonResult

            Dim AgencyTheme As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
            Dim realFilename As String = File.FileName

            Dim NewFilename As String = ""

            Dim MIMEType As String = ""

            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            If Not File.ContentType Is Nothing Then

                MIMEType = File.ContentType

            Else

                MIMEType = ""

            End If

            Dim FileLength As Integer = File.InputStream.Length
            If FileLength > 0 Then

                Dim FileBytes(FileLength - 1) As Byte

                If FileBytes.Length > UserThemeSettings.WallpaperLimit Then

                    ErrorMessage = ("Image file exceeded the file size limit.")
                    Exit Function

                Else

                    If File.InputStream.Read(FileBytes, 0, FileLength) Then

                        Dim EmpPicture As AdvantageFramework.Database.Entities.EmployeePicture = Nothing

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))
                            EmpPicture = AdvantageFramework.Database.Procedures.EmployeePicture.LoadByEmployeeCode(DbContext, Session("EmpCode"))

                            If EmpPicture IsNot Nothing Then
                                EmpPicture.Wallpaper = FileBytes
                                If AdvantageFramework.Database.Procedures.EmployeePicture.Update(DbContext, EmpPicture) Then
                                    Saved = True
                                End If
                            End If

                        End Using

                    End If

                End If


            End If

            If Saved Then

                AgencyTheme.Reload()
                Return MaxJson(Saved)

            Else

                Response.StatusCode = CInt(Net.HttpStatusCode.InternalServerError)
                Return MaxJson(ErrorMessage)

            End If

        End Function

        <Mvc.HttpPost>
        Public Function SaveSettingsAgency(ByVal UseAgencyBranding As Boolean, ByVal AllowUsersToSetTheirOwnColors As Boolean, ByVal BackGroundColor As String, ByVal CustomTextColor As String) As JsonResult

            Try

                Dim AgencyTheme As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))

                With AgencyTheme.Settings

                    .Agency_UseAgencyBranding = UseAgencyBranding
                    .Agency_BackgroundColor = CustomTextColor
                    .Agency_TextColor = CustomTextColor
                    .Agency_SimpleLayoutBackgroundColor = BackGroundColor
                    .Agency_SimpleLayoutSideBarColor = BackGroundColor
                    .Agency_BackgroundType = UserThemeSettings.ImageType.SolidColor
                    '.Agency_SimpleLayoutIconStyle = Me.RadioButtonListIconStyle.SelectedValue
                    '.Agency_ShowLogoOnWorkspace = Me.CheckBoxShowLogoOnWorkspaces.Checked
                    '.Agency_WorkspaceLogoPosition = Me.RadioButtonListWorkspaceLogoPosition.SelectedValue
                    .Agency_AllowUserToSetColors = False

                End With

                Dim s As String = ""
                If AgencyTheme.Agency_Save(s) = False Then

                    Return Json(False)

                Else

                    AgencyTheme.Reload()
                    Return Json(True)

                End If

            Catch ex As Exception

                'ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                Return Json(True)

            End Try

        End Function

        <Mvc.HttpGet>
        Public Function LoadAgencySettings() As JsonResult

            Dim AgencySetting As AdvantageFramework.DTO.Maintenance.Agency.AgencySettings.AgencySetting = Nothing

            Dim AgyStg As New AdvantageFramework.Web.AgencySettings.Methods(Session("ConnString"),
                                                                        Session("UserCode"))

            AgyStg.GetValuesFromDatabase(AdvantageFramework.Agency.SettingApps.AgencyBranding)

            AgencySetting = New AdvantageFramework.DTO.Maintenance.Agency.AgencySettings.AgencySetting

            With AgyStg.SettingsDictionary

                Dim Value As String = ""

                If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_ENABLE, Value) = True Then

                    AgencySetting.UseAgencyBranding = Value = "1"
                    Value = ""

                End If
                If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_USR_BG, Value) = True Then

                    AgencySetting.AllowUsersToSetTheirOwnColors = Value = "1"
                    Value = ""

                End If
                If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_SMPL_BG_CLR, Value) = True Then

                    AgencySetting.BackgroundColor = Value
                    Value = ""

                End If
                If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_BGCLR, Value) = True Then

                    AgencySetting.CustomTextColor = Value
                    Value = ""

                End If
                If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_SMPL_BG_CLR, Value) = True Then

                    AgencySetting.SimpleBackgroundColor = Value
                    Value = ""

                End If
                If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_SMPL_SB_CLR, Value) = True Then

                    AgencySetting.SimpleSideBarColor = Value
                    Value = ""

                End If
                If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_LOGO, Value) = True Then

                    AgencySetting.AgencyLogo = Value
                    Value = ""

                End If

            End With

            Return MaxJson(AgencySetting, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <HttpPost>
        Public Function UploadAgencyLogo(ByVal File As HttpPostedFileBase) As JsonResult

            Dim AgencyTheme As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
            Dim AgyStg As New AdvantageFramework.Web.AgencySettings.Methods(Session("ConnString"), Session("UserCode"))
            Dim cAgency As New cAgency(Session("ConnString"))

            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            Dim realFilename As String = File.FileName
            'Dim FileType As String = File.FileName

            Dim NewFilename As String = ""

            Dim MIMEType As String = ""

            If Not File.ContentType Is Nothing Then

                MIMEType = File.ContentType

            Else

                MIMEType = ""

            End If

            Dim FileLength As Integer = File.InputStream.Length

            If FileLength > 0 Then

                Dim FileBytes(FileLength - 1) As Byte

                If File.InputStream.Read(FileBytes, 0, FileLength) Then

                    If FileBytes.Length > UserThemeSettings.LogoLimit Then

                        ErrorMessage = "Logo file exceeded the file size limit."
                        Saved = False

                    Else

                        cAgency.SaveBinaryImage("WV_DEFAULT_LOGO", "Agency defaulted logo for Webvantage", FileBytes)
                        AgyStg.SettingsDictionary.Add(AdvantageFramework.Agency.Settings.WV_BRND_LOGO, realFilename)
                        AgyStg.UpdateValues()
                        Saved = True

                    End If

                End If


            End If

            If Saved Then

                AgencyTheme.Reload()
                Return MaxJson(Saved)

            Else

                Response.StatusCode = CInt(Net.HttpStatusCode.InternalServerError)
                Return MaxJson(ErrorMessage)

            End If

        End Function
        <HttpPost>
        Public Function RemoveAgencyLogo() As JsonResult

            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            Dim AgencyTheme As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
            Dim a As New cAgency(Session("ConnString"))
            Dim s As String = ""

            If a.DeleteBinaryImage(UserThemeSettings.CustomImageId.WV_DEFAULT_LOGO, s) = False Then

                ErrorMessage = s.Trim()
                Saved = False

            Else

                Saved = True

            End If


            If Saved Then

                AgencyTheme.Reload()
                Return MaxJson(Saved)

            Else

                Response.StatusCode = CInt(Net.HttpStatusCode.InternalServerError)
                Return MaxJson(ErrorMessage)

            End If

        End Function

        <HttpPost>
        Public Function Upload(ByVal File As HttpPostedFileBase) As JsonResult

            'see UploadProfilePicture line 348

        End Function

#End Region

#Region " User Settings "

        <Mvc.HttpGet>
        Public Function GetPageSize(ByVal GridName As String) As System.Web.Mvc.JsonResult

            Dim PageSize As Integer = MiscFN.LoadPageSize(GridName)

            Return Json(PageSize, Mvc.JsonRequestBehavior.AllowGet)

        End Function
        <Mvc.HttpPost>
        Public Function UpdatePageSize(ByVal PageSize As Integer, ByVal GridName As String) As Mvc.JsonResult

            'objects
            Dim Updated As Boolean = False

            Updated = MiscFN.SavePageSize(GridName, PageSize)

            Return Json(Updated)

        End Function
        <Mvc.HttpGet>
        Public Function isClientPortal() As JsonResult

            Dim ClientPortal As Boolean = False

            ClientPortal = MiscFN.IsClientPortal()

            'Return Json(ClientPortal, JsonRequestBehavior.AllowGet)
            Return Json(New With {.ClientPortal = ClientPortal, .ClientCode = Session("CL_CODE")}, JsonRequestBehavior.AllowGet)

        End Function
        <Mvc.HttpPost>
        Public Function DeauthorizeDoubleClick() As System.Web.Mvc.JsonResult

            Dim Loaded As Boolean = True

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing

            Try

                Service = AdvantageFramework.GoogleServices.Service.InitializeDoubleClick(SecuritySession, True)

                If Service IsNot Nothing Then

                    Loaded = Service.Deauthorize()

                End If

            Catch ex As Exception

            End Try

            Return Json(Loaded)

        End Function

        <HttpGet>
        Public Function GetIsEmployeeVendor(ByVal EmployeeCode As String) As JsonResult

            'objects
            Dim HasVendor As Boolean = False
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim VendorCode As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    If AdvantageFramework.ExpenseReports.IsEmployeeVendor(DbContext, EmployeeCode, VendorCode) Then

                        HasVendor = True

                    End If

                Catch ex As Exception

                End Try

            End Using

            Return Json(HasVendor, JsonRequestBehavior.AllowGet)

        End Function
        <Mvc.HttpGet>
        Public Function GetQuickbooksURL() As System.Web.Mvc.JsonResult

            'objects
            Dim URL As String = Nothing
            Dim RevocationEndpoint As String = Nothing

            URL = _Controller.GetQuickbooksURL(RevocationEndpoint)

            Me.Session("QB_RevocationEndpoint") = RevocationEndpoint

            Return Json(URL, Mvc.JsonRequestBehavior.AllowGet)

        End Function
        <Mvc.HttpPost>
        Public Function DeauthorizeQuickbooks() As System.Web.Mvc.JsonResult

            Dim Success As Boolean = False
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim ClientID As String = String.Empty
            Dim ClientSecret As String = String.Empty
            Dim RefreshToken As String = String.Empty
            Dim Credential As String = Nothing
            Dim EncodedCredential As String = Nothing
            Dim BasicAuth As String = Nothing
            Dim TokenRequestBody As String
            Dim TokenRequest As System.Net.HttpWebRequest = Nothing
            Dim ByteVersion As Byte() = Nothing
            Dim Stream As System.IO.Stream = Nothing

            'Private Sub PerformRefreshToken(ByVal access_token As String, ByVal refresh_token As String)
            'output("Performing Revoke tokens.")

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                ClientID = AdvantageFramework.Quickbooks.QB_CLIENT_ID

                ClientSecret = AdvantageFramework.Quickbooks.QB_CLIENT_SECRET

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.QB_REFRESH_TOKEN.ToString)

                If Setting IsNot Nothing Then

                    RefreshToken = Setting.Value

                End If

                Credential = String.Format("{0}:{1}", ClientID, ClientSecret)

                EncodedCredential = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(Credential))

                BasicAuth = String.Format("{0} {1}", "Basic", EncodedCredential)
                TokenRequestBody = "{""token"":""" & RefreshToken & """}"
                TokenRequest = CType(System.Net.WebRequest.Create(Me.Session("QB_RevocationEndpoint")), System.Net.HttpWebRequest)
                TokenRequest.Method = "POST"
                tokenRequest.ContentType = "application/json"
                tokenRequest.Accept = "application/json"
                tokenRequest.Headers(System.Net.HttpRequestHeader.Authorization) = BasicAuth
                ByteVersion = System.Text.Encoding.ASCII.GetBytes(TokenRequestBody)
                TokenRequest.ContentLength = ByteVersion.Length
                Stream = TokenRequest.GetRequestStream()
                Stream.Write(ByteVersion, 0, ByteVersion.Length)
                Stream.Close()

                Try

                    Dim response As System.Net.HttpWebResponse = CType(TokenRequest.GetResponse(), System.Net.HttpWebResponse)

                    If response.StatusCode = System.Net.HttpStatusCode.OK Then
                        'output("Successful Revoke!")
                        'revoke.Visible = False
                        'lblConnected.Visible = True
                        Success = True
                        DataContext.ExecuteCommand("UPDATE dbo.AGY_SETTINGS SET AGY_SETTINGS_VALUE = null WHERE AGY_SETTINGS_CODE IN ('QB_ACCESS_TOKEN','QB_AUTH_CODE','QB_REALM_ID','QB_REFRESH_TOKEN','QB_ENABLED')")

                    ElseIf response.StatusCode = System.Net.HttpStatusCode.BadRequest Then
                        'output("One or more of BearerToken, RefreshToken, ClientId or, ClientSecret are incorrect.")
                    ElseIf response.StatusCode = System.Net.HttpStatusCode.Unauthorized Then
                        'output("Bad authorization header or no authorization header sent.")
                    ElseIf response.StatusCode = System.Net.HttpStatusCode.InternalServerError Then
                        'output("Intuit server internal error, not the fault of the developer.")
                    End If

                    'Session.Clear()
                    'Session.Abandon()

                    'If Request.Url.Query = "" Then
                    '    response.Redirect(Request.RawUrl)
                    'Else
                    '    response.Redirect(Request.RawUrl.Replace(Request.Url.Query, ""))
                    'End If

                Catch ex As System.Net.WebException
                    'Session.Clear()
                    'Session.Abandon()

                    'If ex.Status = System.Net.WebExceptionStatus.ProtocolError Then
                    '    Dim response = TryCast(ex.Response, System.Net.HttpWebResponse)

                    '    If response IsNot Nothing Then
                    '        output("HTTP Status: " & response.StatusCode)
                    '        Dim exceptionDetail = response.GetResponseHeader("WWW-Authenticate")

                    '        If exceptionDetail IsNot Nothing AndAlso exceptionDetail <> "" Then
                    '            output(exceptionDetail)
                    '        End If

                    '        Using reader As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
                    '            Dim responseText As String = reader.ReadToEnd()

                    '            If responseText IsNot Nothing AndAlso responseText <> "" Then
                    '                output(responseText)
                    '            End If
                    '        End Using
                    '    End If
                    'End If

                End Try

            End Using

            'output("Token revoked.")

            Return Json(Success)

        End Function

#End Region

    End Class

End Namespace
