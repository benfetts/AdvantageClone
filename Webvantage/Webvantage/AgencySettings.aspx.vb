Imports System.Collections.Generic

Partial Public Class AgencySettings
    Inherits Webvantage.BaseChildPage

#Region " Constants "

    Private Const DefaultText As String = "Using Default"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private CssForPreview As String = "vertical-align:top;"
    Private ClientPortalClCode As String = ""

#End Region

#Region " Properties "

    Private Property _ClientPortalMode As Boolean = False ' this is for the page to run it in 2 different modes; this is NOT the indicator that the entire app is running as client portal

#End Region

#Region " Page Events "

    Private Sub AgencySettings_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        Me._ClientPortalMode = qs.Get("pm") = "1"
        Me.ClientPortalClCode = qs.ClientCode

    End Sub
    Protected Sub AgencySettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Dim uts As New UserThemeSettings()
            With uts

                .BindThemeComboBox(Me.RadComboBoxTheme)
                .BindColorPicker(Me.RadColorPickerSimpleLayoutBackground)
                .BindPrimaryColorPicker(Me.RadColorPickerSideBar)

            End With

            Me.RadComboBoxClientPortalClients.Visible = Me._ClientPortalMode
            Me.TrEnableWeather.Visible = Not Me._ClientPortalMode
            Me.DivWeatherWarning.Visible = Not Me._ClientPortalMode

            If Me._ClientPortalMode = False Then

                Me.LoadAgencySettings()

            Else

                Me.SetClientPortal()
                Me.TableAgencyBranding.Visible = False
                Me.LoadClientPortalSettings(Me.ClientPortalClCode)

            End If

        End If

    End Sub

#End Region

#Region " Controls Events "

    Private Sub ButtonCancel_Click(sender As Object, e As System.EventArgs) Handles ButtonCancel.Click

        Me.CloseThisWindow()

    End Sub
    Private Sub ButtonCloseAndRefresh_Click(sender As Object, e As System.EventArgs) Handles ButtonCloseAndRefresh.Click

        If Me._ClientPortalMode = False Then

            Me.SaveAgencySettings(False)

        Else

        End If

        Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
        t.Reload()

        Me.RefreshMDIPage()

    End Sub
    Private Sub ButtonOpenPreviewWindow_Click(sender As Object, e As EventArgs) Handles ButtonOpenPreviewWindow.Click

        Me.OpenPreviewWindow(True)

    End Sub
    Private Sub ButtonSaveBrandingOptions_Click(sender As Object, e As System.EventArgs) Handles ButtonSaveBrandingOptions.Click

        Me.Save()
        Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
        t.Reload()

        Me.OpenPreviewWindow()

    End Sub
    Private Sub LinkButtonRemoveAgencyLogo_Click(sender As Object, e As System.EventArgs) Handles LinkButtonRemoveAgencyLogo.Click

        'Me.Save()

        Dim a As New cAgency(Session("ConnString"))
        Dim s As String = ""

        If Me._ClientPortalMode = False Then

            If a.DeleteBinaryImage(UserThemeSettings.CustomImageId.WV_DEFAULT_LOGO, s) = False Then

                If s.Trim() <> "" Then Me.ShowMessage(s)
                Exit Sub

            Else

                Me.LoadAgencySettings()

            End If

        Else

            Me.SetClientPortalCode()
            If a.ClientPortal_DeleteBinaryImage(Me.ClientPortalClCode, UserThemeSettings.ImageType.Logo, s) = False Then

                If s.Trim() <> "" Then Me.ShowMessage(s)
                Exit Sub

            Else

                Me.LoadClientPortalSettings(Me.ClientPortalClCode)

            End If

        End If

    End Sub
    Private Sub LinkButtonUploadAgencyLogo_Click(sender As Object, e As System.EventArgs) Handles LinkButtonUploadAgencyLogo.Click

        Me.Save()

        Dim qs As New AdvantageFramework.Web.QueryString()

        qs.Page = "AgencySettings_Upload.aspx"
        qs.Add("uploadtype", CType(UserThemeSettings.ImageType.Logo, Integer))

        If Me._ClientPortalMode = False Then

            qs.Add("pm", CType(AgencySettings_Upload.PageMode.Agency, Integer).ToString())

        Else

            Me.SetClientPortalCode()
            qs.Add("pm", CType(AgencySettings_Upload.PageMode.ClientPortal, Integer).ToString())
            If Me.RadComboBoxClientPortalClients.SelectedIndex > 0 Then

                qs.ClientCode = Me.RadComboBoxClientPortalClients.SelectedValue

            End If

        End If

        Me.OpenWindow("Upload", qs.ToString(True), , , , True)

    End Sub
    Private Sub RadComboBoxClientPortalClients_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxClientPortalClients.SelectedIndexChanged

        Me.LoadClientPortalSettings(Me.RadComboBoxClientPortalClients.SelectedValue)

        Me.SetClientPortalCode()
        If Me.RadComboBoxClientPortalClients.SelectedIndex > 0 Then

            Me.OpenPreviewWindow()

        End If

    End Sub

#End Region

#Region " Methods "

    Private Sub Save()

        If Me._ClientPortalMode = False Then

            Me.SaveAgencySettings(True)

        Else

            If Me.RadComboBoxClientPortalClients.SelectedIndex > 0 Then

                Me.SaveClientPortalSettings(Me.RadComboBoxClientPortalClients.SelectedValue, True)

            Else

                Me.ShowMessage("Select a client")
                Me.RadComboBoxClientPortalClients.Focus()
                Exit Sub

            End If

        End If

    End Sub

    Private Sub LoadAgencySettings()
        Dim AgyStg As New AdvantageFramework.Web.AgencySettings.Methods(Session("ConnString"),
                                                                        Session("UserCode"), HttpContext.Current)

        AgyStg.GetValuesFromDatabase(AdvantageFramework.Agency.SettingApps.AgencyBranding)

        With AgyStg.SettingsDictionary

            Dim Value As String = ""

            If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_ENABLE, Value) = True Then

                Me.CheckboxUseAgencyBranding.Checked = Value = "1"
                Value = ""

            End If
            If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_USR_THM, Value) = True Then

                Me.CheckboxUsersCanChangeTheme.Checked = Value = "1"
                Value = ""

            End If
            If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_THEME, Value) = True Then

                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxTheme, Value, False)
                Value = ""

            End If
            If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_FLT_DTO, Value) = True Then

                Me.CheckBoxFloatObjects.Checked = Value = "1"
                Value = ""

            End If
            If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_USR_BG, Value) = True Then

                Me.CheckboxAllowUsersToSetTheirOwnColors.Checked = Value = "1"
                Value = ""

            End If
            If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_SHRT_MNU, Value) = True Then

                Me.RadioButtonMenuSingeNode.Checked = Value = "1"
                Value = ""

            End If

            Me.RadioButtonMenuFull.Checked = Not Me.RadioButtonMenuSingeNode.Checked

            If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_CLK_APP, Value) = True Then

                Me.CheckBoxClickToOpenAppMenu.Checked = Value = "1"
                Value = ""

            End If
            If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_CLK_USR, Value) = True Then

                Me.CheckBoxClickToOpenUserMenu.Checked = Value = "1"
                Value = ""

            End If
            If .TryGetValue(AdvantageFramework.Agency.Settings.WV_ENABLE_WTHR, Value) = True Then

                Me.CheckBoxEnableWeather.Checked = Value = "1"
                Value = ""

            End If
            If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_USR_BG, Value) = True Then

                Me.CheckBoxClickToOpenUserMenu.Checked = Value = "1"
                Value = ""

            End If
            If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_SMPL_BG_CLR, Value) = True Then

                Me.RadColorPickerSimpleLayoutBackground.SelectedColor = Drawing.ColorTranslator.FromHtml(Value)
                Value = ""

            End If
            If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_SMPL_SB_CLR, Value) = True Then

                Me.RadColorPickerSideBar.SelectedColor = Drawing.ColorTranslator.FromHtml(Value)
                Value = ""

            End If
            If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_SMPL_ICON, Value) = True AndAlso IsNumeric(Value) = True Then

                Select Case CType(Value, Integer)
                    Case 2
                        Me.RadioButtonListIconStyle.Items.FindByValue("2").Selected = True
                    Case Else
                        Me.RadioButtonListIconStyle.Items.FindByValue("1").Selected = True
                End Select

                Value = ""

            End If
            If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_LOGO_ON_WP, Value) = True Then

                Me.CheckBoxShowLogoOnWorkspaces.Checked = Value = "1"
                Value = ""

            End If
            If .TryGetValue(AdvantageFramework.Agency.Settings.WV_BRND_LOGO_POS, Value) = True Then

                Me.RadioButtonListWorkspaceLogoPosition.Items.FindByValue(Value).Selected = True
                Value = ""

            End If

            Me.RadioButtonListWorkspaceLogoPosition.Enabled = Me.CheckBoxShowLogoOnWorkspaces.Checked

            Me.SetPreview()

        End With
    End Sub
    Private Sub SaveAgencySettings(ByVal Reload As Boolean)

        Dim AgencyTheme As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))

        With AgencyTheme.Settings

            .Agency_UseAgencyBranding = Me.CheckboxUseAgencyBranding.Checked
            .Agency_AllowUserToSetTheme = Me.CheckboxUsersCanChangeTheme.Checked

            If Me.RadComboBoxTheme.SelectedIndex > -1 Then

                .Agency_TelerikTheme = Me.RadComboBoxTheme.SelectedValue

            End If

            .Agency_FloatDesktopObjects = Me.CheckBoxFloatObjects.Checked
            .Agency_SingleNodeMainMenu = Me.RadioButtonMenuSingeNode.Checked
            .Agency_ClickToOpenAppMenu = Me.CheckBoxClickToOpenAppMenu.Checked
            .Agency_ClickToOpenUserMenu = Me.CheckBoxClickToOpenUserMenu.Checked
            .Agency_EnableWeather = Me.CheckBoxEnableWeather.Checked

            .Agency_SimpleLayoutBackgroundColor = Drawing.ColorTranslator.ToHtml(Me.RadColorPickerSimpleLayoutBackground.SelectedColor)
            .Agency_SimpleLayoutSideBarColor = Drawing.ColorTranslator.ToHtml(Me.RadColorPickerSideBar.SelectedColor)
            .Agency_SimpleLayoutIconStyle = Me.RadioButtonListIconStyle.SelectedValue
            .Agency_ShowLogoOnWorkspace = Me.CheckBoxShowLogoOnWorkspaces.Checked
            .Agency_WorkspaceLogoPosition = Me.RadioButtonListWorkspaceLogoPosition.SelectedValue

            .Agency_AllowUserToSetColors = Me.CheckboxAllowUsersToSetTheirOwnColors.Checked

        End With

        Dim s As String = ""
        If AgencyTheme.Agency_Save(s) = False Then

            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(s))
            Exit Sub

        Else

            If Reload = True Then

                Me.LoadAgencySettings()

            End If

        End If

    End Sub

    Private Sub SetPreview(Optional ByVal ClCode As String = "")

        Dim CurrentTheme As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))

        'CurrentTheme.LoadFromDatabase()

        If Me._ClientPortalMode = False Then

            CurrentTheme.Agency_Load()

        Else

            CurrentTheme.ClientPortal_Load(ClCode)

        End If

        Select Case CurrentTheme.Settings.Agency_BackgroundType
            Case UserThemeSettings.ImageType.SolidColor

                If CurrentTheme.Settings.BackgroundColor <> "" Then

                    CssForPreview &= "background-color: " & CurrentTheme.Settings.Agency_BackgroundColor & ";"

                End If

            Case Else

                If CurrentTheme.Settings.Agency_FullPathToWallpaper <> "" Then

                    CssForPreview &= "background-image: url('" & CurrentTheme.Settings.Agency_FullPathToWallpaper & "');"

                End If

        End Select

        If CurrentTheme.Settings.Agency_Logo = "" Or CurrentTheme.Settings.Agency_Logo = CurrentTheme.Settings.DefaultLogo Then

            Me.LabelCurrentAgencyLogoFilename.Text = ""
            Me.LinkButtonRemoveAgencyLogo.Visible = False

        Else

            Me.LabelCurrentAgencyLogoFilename.Text = "Current:  " & CurrentTheme.Settings.Agency_Logo
            Me.LinkButtonRemoveAgencyLogo.Visible = True

        End If
        If CurrentTheme.Settings.ClientPortal_IsUsingDefaultClientPortalLogo = True And Me._ClientPortalMode = True And ClCode <> "" Then

            Me.LabelCurrentAgencyLogoFilename.Text = DefaultText
            Me.LinkButtonRemoveAgencyLogo.Visible = False

        End If

    End Sub

    Private Sub SetClientPortal()

        If Me._ClientPortalMode = True Then

            Me.PageTitle = "Client Portal Customization"

            Me.LabelUseAgencyBranding.Text = "Enable Client Portal Branding"

            Dim d As New cDropDowns(Session("ConnString"))

            With Me.RadComboBoxClientPortalClients

                .DataSource = d.GetClientList(Session("UserCode"))
                .DataTextField = "description"
                .DataValueField = "code"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select a Client]", "PleaseSelect"))
                .Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem("[Default Client Portal Settings]", ""))

            End With

            MiscFN.RadComboBoxSetIndex(Me.RadComboBoxClientPortalClients, Me.ClientPortalClCode, False)

            Me.ButtonCloseAndRefresh.Visible = False
            Me.RadioButtonMenuSingeNode.Visible = False
            Me.RadioButtonMenuFull.Visible = False
            Me.CheckBoxClickToOpenAppMenu.Visible = False
            Me.CheckBoxClickToOpenUserMenu.Visible = False
            Me.DivLogo.Visible = False

            Me.LabelLogin.Text = "Login color"
            Me.LabelAccent.Text = "Accent color"

            Me.RadComboBoxTheme.Visible = False
            Me.CheckBoxSignInBackground.Visible = False
            Me.DivIconStyle.Visible = False
            Me.DivTheme.Visible = False
            Me.DivWorkspace.Visible = False
            Me.CheckBoxSignInBackground.Visible = False

        End If

        Me.TableClientPortalSelect.Visible = Me._ClientPortalMode
        Me.CheckboxUsersCanChangeTheme.Visible = Not Me._ClientPortalMode

    End Sub
    Private Sub LoadClientPortalSettings(Optional ByVal ClCode As String = "")

        If ClCode = "PleaseSelect" Then
            'hide
            Me.TableAgencyBranding.Visible = False

        Else

            Me.TableAgencyBranding.Visible = True

            If ClCode = "" Then

                Me.RadComboBoxClientPortalClients.SelectedIndex = 1

                Me.CheckboxUseAgencyBranding.Checked = True
                Me.TrEnableBranding.Visible = False

            Else

                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxClientPortalClients, ClCode, False, True)
                Me.TrEnableBranding.Visible = True

            End If

            Dim SelectedTheme As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"), True, ClCode)
            SelectedTheme.ClientPortal_Load(ClCode)

            If Not SelectedTheme Is Nothing Then

                Me.CheckboxUseAgencyBranding.Checked = SelectedTheme.Settings.Agency_UseAgencyBranding

                Me.CheckboxUsersCanChangeTheme.Checked = SelectedTheme.Settings.Agency_AllowUserToSetTheme
                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxTheme, SelectedTheme.Settings.Agency_TelerikTheme, False)
                Me.CheckBoxFloatObjects.Checked = SelectedTheme.Settings.Agency_FloatDesktopObjects
                Me.RadioButtonMenuSingeNode.Checked = SelectedTheme.Settings.Agency_SingleNodeMainMenu
                Me.RadioButtonMenuFull.Checked = Not Me.RadioButtonMenuSingeNode.Checked
                Me.CheckBoxClickToOpenAppMenu.Checked = SelectedTheme.Settings.Agency_ClickToOpenAppMenu
                Me.CheckBoxClickToOpenUserMenu.Checked = SelectedTheme.Settings.Agency_ClickToOpenUserMenu

                Me.HiddenFieldAgencyLogoFilename.Value = SelectedTheme.Settings.Agency_Logo

                Me.RadColorPickerSimpleLayoutBackground.SelectedColor = Drawing.ColorTranslator.FromHtml(SelectedTheme.Settings.SimpleLayoutBackgroundColor)
                Me.RadColorPickerSideBar.SelectedColor = Drawing.ColorTranslator.FromHtml(SelectedTheme.Settings.SimpleLayoutSideBarColor)
                Me.RadioButtonListIconStyle.SelectedValue = CType(SelectedTheme.Settings.SimpleLayoutIconStyle, Integer).ToString()

                Me.OpenPreviewWindow()
                Me.SetPreview(ClCode)

            End If

            Dim AgyStg As New AdvantageFramework.Web.AgencySettings.Methods(Session("ConnString"),
                                                                            Session("UserCode"), HttpContext.Current)

            AgyStg.GetValuesFromDatabase(AdvantageFramework.Agency.SettingApps.AgencyBranding)

            With AgyStg.SettingsDictionary

                Dim Value As String = ""

                If .TryGetValue(AdvantageFramework.Agency.Settings.WV_ENABLE_WTHR, Value) = True Then

                    If Value <> "1" Then

                        Me.CheckBoxEnableWeather.Checked = False
                        Me.TrEnableWeather.Visible = False

                    End If

                End If

            End With

        End If

    End Sub
    Private Sub SaveClientPortalSettings(ByVal ClCode As String, ByVal Reload As Boolean)

        Dim ClientPortalTheme As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"), True, ClCode)

        With ClientPortalTheme.Settings

            .Agency_UseAgencyBranding = Me.CheckboxUseAgencyBranding.Checked
            .Agency_AllowUserToSetTheme = Me.CheckboxUsersCanChangeTheme.Checked
            .Agency_FloatDesktopObjects = Me.CheckBoxFloatObjects.Checked
            .Agency_SingleNodeMainMenu = Me.RadioButtonMenuSingeNode.Checked
            .Agency_ClickToOpenAppMenu = Me.CheckBoxClickToOpenAppMenu.Checked
            .Agency_ClickToOpenUserMenu = Me.CheckBoxClickToOpenUserMenu.Checked
            .Agency_TelerikTheme = Me.RadComboBoxTheme.SelectedValue
            .BackgroundType = UserThemeSettings.ImageType.SolidColor
            .Agency_BackgroundColor = Drawing.ColorTranslator.ToHtml(Me.RadColorPickerSimpleLayoutBackground.SelectedColor).ToString()
            .Agency_TextColor = Drawing.ColorTranslator.ToHtml(Me.RadColorPickerSimpleLayoutBackground.SelectedColor).ToString()
            .BackgroundColor = Drawing.ColorTranslator.ToHtml(Me.RadColorPickerSimpleLayoutBackground.SelectedColor).ToString()
            .SimpleLayoutBackgroundColor = Drawing.ColorTranslator.ToHtml(Me.RadColorPickerSimpleLayoutBackground.SelectedColor).ToString()
            .SimpleLayoutSideBarColor = Drawing.ColorTranslator.ToHtml(Me.RadColorPickerSideBar.SelectedColor).ToString()
            .SimpleLayoutIconStyle = Me.RadioButtonListIconStyle.SelectedValue

        End With

        Dim s As String = ""
        If ClientPortalTheme.ClientPortal_Save(ClCode, s) = False Then

            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(s))
            Exit Sub

        Else

            If Reload = True Then

                Me.LoadClientPortalSettings(ClCode)

            End If

        End If

    End Sub
    Private Sub SetClientPortalCode()
        Try

            If Me._ClientPortalMode = True Then

                If Me.RadComboBoxClientPortalClients.Items.Count > 0 Then

                    If Me.RadComboBoxClientPortalClients.SelectedIndex > 1 Then

                        Me.ClientPortalClCode = Me.RadComboBoxClientPortalClients.SelectedValue

                    Else

                        Me.ClientPortalClCode = ""

                    End If

                End If

            End If

        Catch ex As Exception

            Me.ClientPortalClCode = ""

        End Try
    End Sub

    Private Sub OpenPreviewWindow(Optional OpenNewWindow As Boolean = False)

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs.Page = "AgencySettings_Preview.aspx"

        If Me._ClientPortalMode = False Then

        Else

            Me.SetClientPortalCode()
            qs.Add("cp", "1")
            If Me.RadComboBoxClientPortalClients.SelectedIndex > 0 Then

                qs.ClientCode = Me.RadComboBoxClientPortalClients.SelectedValue

            End If

        End If

        If OpenNewWindow = True Then

            Me.OpenWindow("", qs.ToString(True), 560, 800)

        Else

            Me.RefreshCaller(qs.ToString(True), , True, False)

        End If

    End Sub

    Private Sub CheckBoxShowLogoOnWorkspaces_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowLogoOnWorkspaces.CheckedChanged

        Me.RadioButtonListWorkspaceLogoPosition.Enabled = Me.CheckBoxShowLogoOnWorkspaces.Checked

    End Sub

#End Region

End Class

'If Me._ClientPortalMode = False Then

'Else

'End If
