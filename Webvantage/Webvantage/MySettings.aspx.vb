Imports System.Text
Imports System.IO
Imports Telerik.Web.UI

Public Class MySettings
    Inherits Webvantage.BaseChildPage

#Region " Constants "

    Private Const WallpaperLimit As Integer = 614400

#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Public ImacBackgroundCSS As String = ""

#End Region

#Region " Properties "

    Private Property _IsUsingAgencyBranding As Boolean
        Get
            If ViewState("_IsUsingAgencyBranding") IsNot Nothing Then
                Return ViewState("_IsUsingAgencyBranding")
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("_IsUsingAgencyBranding") = value
        End Set
    End Property
    Private Property _AllowUserToSetWallpaper As Boolean
        Get
            If ViewState("_AllowUserToSetWallpaper") IsNot Nothing Then
                Return ViewState("_AllowUserToSetWallpaper")
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("_AllowUserToSetWallpaper") = value
        End Set
    End Property

#End Region

#Region " Page Events "

    Protected Sub MySettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Dim uts As New UserThemeSettings()
            With uts

                .BindColorPicker(Me.RadColorPickerSimpleLayoutBackground)
                .BindPrimaryColorPicker(Me.RadColorPickerSideBar)

            End With

            Me.LoadTimeZones()

            Me.LoadSettings()

            If CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_General_ProfileAdministration, False) = 1 Then

                Me.RadToolbarMySettings.FindItemByValue("RadToolBarButtonProfileAdministrationSeparator").Visible = True
                Me.RadToolbarMySettings.FindItemByValue("ProfileAdministration").Visible = True

            Else

                Me.RadToolbarMySettings.FindItemByValue("RadToolBarButtonProfileAdministrationSeparator").Visible = False
                Me.RadToolbarMySettings.FindItemByValue("ProfileAdministration").Visible = False

            End If

        End If

        If Me.LoadUserSetting(AdvantageFramework.Security.UserSettings.AllowProfileUpdate) = True Then

            LoadEmployeeProfile()
            Me.DivMyProfile.Visible = True

        Else

            Me.DivMyProfile.Visible = False

        End If

    End Sub
    Private Sub MySettings_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Me.SetupImac()

    End Sub

#End Region

#Region " Controls Events "

    Private Sub CheckBoxSimpleLayout_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxLegacyLayout.CheckedChanged

        Me.SetLayoutOptions()

    End Sub
    Private Sub LinkButtonUploadEmployeePicture_Click(sender As Object, e As EventArgs) Handles LinkButtonUploadEmployeePicture.Click

        Dim s As String = ""
        If Me.SaveSettings(s) = True Then

            Dim qs As New AdvantageFramework.Web.QueryString()

            qs.Page = "AgencySettings_Upload.aspx"
            qs.Add("uploadtype", CType(UserThemeSettings.ImageType.EmployeePictrue, Integer))
            qs.Add("pm", CType(AgencySettings_Upload.PageMode.EmployeePicture, Integer).ToString())
            qs.UserCode = Session("UserCode")
            qs.EmployeeCode = Session("EmpCode")
            qs.Add("nickname", Me.Sanitize(Me.TextBoxNickName.Text.Trim()))
            Me.OpenWindow("", qs.ToString(True), , , , True)

        Else

            If s <> "" Then

                Me.ShowMessage(s)
                Exit Sub

            End If

        End If

    End Sub
    Private Sub LinkButtonDeleteEmployeePicture_Click(sender As Object, e As EventArgs) Handles LinkButtonDeleteEmployeePicture.Click

        Dim s As String = ""
        If Me.SaveSettings(s) = True Then

            Dim a As New cAgency(Session("ConnString"))
            If a.EmployeePicture_DeleteBinaryImage(Session("EmpCode"), s) = False Then

                If s <> "" Then

                    Me.ShowMessage(s)
                    Exit Sub

                End If

            Else

                Me.LoadEmployeeProfile()

            End If

        Else

            If s <> "" Then

                Me.ShowMessage(s)
                Exit Sub

            End If

        End If

    End Sub
    Private Sub RadToolbarMySettings_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolbarMySettings.ButtonClick

        Select Case e.Item.Value
            Case "Save"

                Dim s As String = ""

                If Me.SaveSettings(s) = True Then

                    Me.RefreshMDIPage()

                Else

                    If s <> "" Then

                        Me.ShowMessage(s)
                        Exit Sub

                    End If

                End If

            Case "Cancel"

                Me.CloseThisWindow()

            Case "ProfileAdministration"

                Me.OpenWindow("", "Maintenance_ProfileAdministration.aspx")

        End Select
    End Sub

#End Region

#Region " Methods "

    Private Sub LoadEmployeeProfile()

        Try
            Dim dr As SqlClient.SqlDataReader
            Dim cEmp As New cEmployee(Session("ConnString"))

            dr = cEmp.GetEmployeeProfile(Session("EmpCode"))

            If dr.HasRows Then

                dr.Read()

                If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

                    If IsDBNull(dr("EMP_NICKNAME")) = False Then

                        Me.TextBoxNickName.Text = dr("EMP_NICKNAME")

                    End If

                End If
                If IsDBNull(dr("EMP_IMAGE")) = False Then

                    Me.ASPxBinaryImageEmployeePicture.Value = CType(dr("EMP_IMAGE"), Byte())

                Else

                    Me.ASPxBinaryImageEmployeePicture.Value = Nothing

                End If

                dr.Close()

            End If

        Catch ex As Exception
        End Try

    End Sub
    Private Sub LoadSettings()

        Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))

        With t

            .Reload()

            Try
                Me.RadioButtonListTheme.Items.FindByValue(.Settings.TelerikTheme).Selected = True
            Catch ex As Exception
            End Try
            Me.CheckBoxSignInBackground.Checked = .Settings.UseBackgroundColorOnSignInPage
            Me.CheckBoxFloatObjects.Checked = .Settings.FloatDesktopObjects
            Me.RadioButtonMenuSingeNode.Checked = .Settings.SingleNodeMainMenu
            Me.RadioButtonMenuFull.Checked = Not .Settings.SingleNodeMainMenu
            Me.CheckBoxClickToOpenAppMenu.Checked = .Settings.ClickToOpenAppMenu
            Me.CheckBoxClickToOpenUserMenu.Checked = .Settings.ClickToOpenUserMenu
            Me.CheckBoxEnableWeather.Checked = .Settings.EnableWeather

            If Me.RadComboBoxEmployeeTimeZone.Items.Count > 0 AndAlso String.IsNullOrWhiteSpace(.Settings.TimeZoneID) = False Then

                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxEmployeeTimeZone, .Settings.TimeZoneID, False)

            End If
            Select Case .Settings.Logo
                Case "aqualogo_white.png"
                    MiscFN.RadComboBoxSetIndex(Me.RadComboBoxLogo, "Light", False)
                Case "aqualogo_252525.png"
                    MiscFN.RadComboBoxSetIndex(Me.RadComboBoxLogo, "Dark", False)
                Case Else
                    MiscFN.RadComboBoxSetIndex(Me.RadComboBoxLogo, "Themed", False)
            End Select
            Me.DivEnableWeather.Visible = .Settings.Agency_EnableWeather
            Me.LabelWeatherWarning.Visible = .Settings.Agency_EnableWeather
            Me.RadColorPickerSimpleLayoutBackground.SelectedColor = Drawing.ColorTranslator.FromHtml(.Settings.SimpleLayoutBackgroundColor)
            Me.RadColorPickerSideBar.SelectedColor = Drawing.ColorTranslator.FromHtml(.Settings.SimpleLayoutSideBarColor)
            Me.RadioButtonListIconStyle.SelectedValue = CType(.Settings.SimpleLayoutIconStyle, Integer).ToString()

            Me.CheckBoxShowNewMenu.Checked = .Settings.SimpleLayoutShowNewMenu
            Me.CheckBoxShowApplicationsMenu.Checked = .Settings.SimpleLayoutShowAppMenu

            Me.DivPreviewSidebar.Attributes.Add("style", "float:right; width:66px !important;height:340px;background-color:" & .Settings.SimpleLayoutSideBarColor & " !important;")

            Me._IsUsingAgencyBranding = .Settings.Agency_UseAgencyBranding

            If Me._IsUsingAgencyBranding = True Then

                Me.DivLogo.Visible = False
                Me.DivBackground.Visible = .Settings.Agency_AllowUserToSetColors

                Me.DivTheme.Visible = .Settings.Agency_AllowUserToSetTheme

                If .Settings.Agency_AllowUserToSetTheme = False Then

                    Try
                        Me.RadioButtonListTheme.Items.FindByValue(.Settings.Agency_TelerikTheme).Selected = True
                    Catch ex As Exception
                    End Try
                    Me.RadMenuImac.Skin = .Settings.Agency_TelerikTheme
                    Me.RadWindowImac.Skin = .Settings.Agency_TelerikTheme

                Else

                    Try
                        Me.RadioButtonListTheme.Items.FindByValue(.Settings.TelerikTheme).Selected = True
                    Catch ex As Exception
                    End Try
                    Me.RadMenuImac.Skin = .Settings.TelerikTheme
                    Me.RadWindowImac.Skin = .Settings.TelerikTheme

                End If

                If Me._AllowUserToSetWallpaper = False Then

                    Me.ImacBackgroundCSS = "background-color: " & .Settings.Agency_BackgroundColor & ";"

                Else

                    Me.ImacBackgroundCSS = "background-color: " & .Settings.SimpleLayoutBackgroundColor & ";"

                End If

                If .Settings.FullPathToLogo <> "" Then

                    Me.ImageSignInLogo.ImageUrl = .Settings.FullPathToLogo

                End If

            Else

                Me._AllowUserToSetWallpaper = True

            End If

            Select Case .Settings.SimpleLayoutIconStyle

                Case UserThemeSettings.IconStyle.DarkGrey

                    Me.ImagePreview1.ImageUrl = Me.ImagePreview1.ImageUrl.Replace("/White/", "/Grey/")
                    Me.ImagePreview2.ImageUrl = Me.ImagePreview2.ImageUrl.Replace("/White/", "/Grey/")
                    Me.ImagePreview3.ImageUrl = Me.ImagePreview3.ImageUrl.Replace("/White/", "/Grey/")

            End Select

        End With

        Me.SetLayoutOptions()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim AgencyTimeZoneID As String = String.Empty
            Dim DatabaseTimeZoneID As String = String.Empty
            Dim EmployeeTimeZoneID As String = String.Empty

            Try

                AgencyTimeZoneID = DbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(TIMEZONE_ID, '') FROM AGENCY WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                AgencyTimeZoneID = 0
            End Try
            Try

                DatabaseTimeZoneID = DbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(DB_TIMEZONE_ID, '') FROM AGENCY WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                DatabaseTimeZoneID = 0
            End Try
            Try

                EmployeeTimeZoneID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL(TIME_ZONE_ID, '') FROM EMPLOYEE WITH(NOLOCK) WHERE EMP_CODE = '{0}';",
                                                                                           HttpContext.Current.Session("EmpCode"))).FirstOrDefault

            Catch ex As Exception
                EmployeeTimeZoneID = 0
            End Try

            If (String.IsNullOrEmpty(AgencyTimeZoneID) = False AndAlso String.IsNullOrEmpty(DatabaseTimeZoneID) = False) OrElse
                String.IsNullOrEmpty(EmployeeTimeZoneID) = False OrElse cApplication.IsProofingToolActive(Me.SecuritySession) = True Then

                Me.DivTimeZone.Visible = True

            Else

                Me.DivTimeZone.Visible = False

            End If

        End Using

    End Sub
    Private Function SaveSettings(Optional ByRef ErrorMessage As String = "") As Boolean
        Try
            If Me.DivMyProfile.Visible = True Then

                Dim e As New cEmployee(Session("ConnString"))
                e.EmployeePicture_SaveNickname(Session("EmpCode"), Me.TextBoxNickName.Text)

            End If
        Catch ex As Exception
        End Try

        Try

            Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
            Dim cEmp As New cEmployee(Session("ConnString"))
            Dim dr As SqlClient.SqlDataReader

            t.Load()

            With t.Settings

                .UseLayout = UserThemeSettings.Layout.Simple
                .SimpleLayoutBackgroundColor = Drawing.ColorTranslator.ToHtml(Me.RadColorPickerSimpleLayoutBackground.SelectedColor).ToString()
                .SimpleLayoutSideBarColor = Drawing.ColorTranslator.ToHtml(Me.RadColorPickerSideBar.SelectedColor).ToString()
                .SimpleLayoutIconStyle = Me.RadioButtonListIconStyle.SelectedValue
                .UseBackgroundColorOnSignInPage = Me.CheckBoxSignInBackground.Checked
                .TelerikTheme = Me.RadioButtonListTheme.SelectedItem.Value
                .FloatDesktopObjects = Me.CheckBoxFloatObjects.Checked
                .SingleNodeMainMenu = Me.RadioButtonMenuSingeNode.Checked

                If Me.RadComboBoxLogo.SelectedIndex = -1 Then

                    CType(Me.RadComboBoxLogo.FindItemByValue("Light.png"), Telerik.Web.UI.RadComboBoxItem).Selected = True

                End If

                .Logo = GetLogoFileName()
                .ClickToOpenUserMenu = Me.CheckBoxClickToOpenUserMenu.Checked
                .ClickToOpenAppMenu = Me.CheckBoxClickToOpenAppMenu.Checked
                .EnableWeather = Me.CheckBoxEnableWeather.Checked
                .SimpleLayoutShowNewMenu = Me.CheckBoxShowNewMenu.Checked
                .SimpleLayoutShowAppMenu = Me.CheckBoxShowApplicationsMenu.Checked

                .TimeZoneID = Me.RadComboBoxEmployeeTimeZone.SelectedItem.Value

            End With

            t.Save()
            t.Reload()

            If MiscFN.IsClientPortal = False Then

                cEmployee.ResetTimeZoneOffsetSession()

            Else

                cEmployee.ResetClientPortalUserTimeZoneOffsetSession()

            End If

            ErrorMessage = ""
            Return True

        Catch ex As Exception

            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
            Return False

        End Try

    End Function
    Private Function GetLogoFileName() As String

        Dim SignInImageFilename As String = "aqualogo_white.png"

        Select Case Me.RadComboBoxLogo.SelectedValue.ToString()
            Case "Light"

                SignInImageFilename = "aqualogo_white.png"

            Case "Dark"

                SignInImageFilename = "aqualogo_252525.png"

            Case "Themed"

                SignInImageFilename = "aqualogo_" & Drawing.ColorTranslator.ToHtml(Me.RadColorPickerSideBar.SelectedColor).ToString().Replace("#", "") & ".png"

            Case Else

                SignInImageFilename = "aqualogo_white.png"

        End Select

        Return SignInImageFilename

    End Function
    Private Sub SetupImac()

        Dim CurrUserTheme As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
        CurrUserTheme.Load()

        Me.ImacBackgroundCSS = "background-color: " & Drawing.ColorTranslator.ToHtml(Me.RadColorPickerSimpleLayoutBackground.SelectedColor).ToString() & ";"
        Me.DivPreviewSidebar.Attributes.Add("style", "float:right; width:66px !important;height:340px;background-color:" &
                                            Drawing.ColorTranslator.ToHtml(Me.RadColorPickerSideBar.SelectedColor).ToString() & " !important;")

        Me.RadMenuImac.Skin = Me.RadioButtonListTheme.SelectedItem.Value
        Me.RadWindowImac.Skin = Me.RadioButtonListTheme.SelectedItem.Value
        Me.RadToolBarImac.Skin = Me.RadioButtonListTheme.SelectedItem.Value

        If Me.DivLogo.Visible = True Then

            Me.ImageSignInLogo.ImageUrl = "Images/Logos/" & GetLogoFileName()

        Else

            Me.ImageSignInLogo.ImageUrl = CurrUserTheme.Settings.FullPathToLogo

        End If

        If Me.RadioButtonListIconStyle.SelectedValue = "2" Then

            Me.ImagePreview1.ImageUrl = Me.ImagePreview1.ImageUrl.Replace("/White/", "/Grey/")
            Me.ImagePreview2.ImageUrl = Me.ImagePreview2.ImageUrl.Replace("/White/", "/Grey/")
            Me.ImagePreview3.ImageUrl = Me.ImagePreview3.ImageUrl.Replace("/White/", "/Grey/")

        End If

    End Sub
    Private Sub SetLayoutOptions()

        Me.DivSingleOrFullMenu.Visible = CheckBoxLegacyLayout.Checked
        Me.DivClickToOpen.Visible = CheckBoxLegacyLayout.Checked

        If CheckBoxLegacyLayout.Checked = False Then

            Me.CheckBoxSignInBackground.Text = "Use workspace color on Sign In page"

        Else

            Me.CheckBoxSignInBackground.Text = "Use this background on Sign In page"

        End If

        Me.RadMenuImac.Visible = CheckBoxLegacyLayout.Checked
        Me.DivPreviewSidebar.Visible = Not CheckBoxLegacyLayout.Checked
        Me.DivLeftSideBar.Visible = Not CheckBoxLegacyLayout.Checked

    End Sub
    Private Sub LoadTimeZones()

        Dim TimeZones As System.Collections.Generic.List(Of TimeZoneInfo)

        TimeZones = AdvantageFramework.Database.Procedures.TimeZone.LoadSystemTimeZones

        If TimeZones IsNot Nothing Then

            Me.RadComboBoxEmployeeTimeZone.Items.Clear()
            Me.RadComboBoxEmployeeTimeZone.DataSource = TimeZones
            Me.RadComboBoxEmployeeTimeZone.DataTextField = "StandardName"
            Me.RadComboBoxEmployeeTimeZone.DataValueField = "Id"
            Me.RadComboBoxEmployeeTimeZone.DataBind()
            Me.RadComboBoxEmployeeTimeZone.Items.Insert(0, New RadComboBoxItem("[Don't Change]", ""))

        End If

    End Sub

#End Region


End Class