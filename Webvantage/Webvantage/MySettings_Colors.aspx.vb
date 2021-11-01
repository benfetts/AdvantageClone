Public Class MySettings_Colors
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Dim uts As New UserThemeSettings()
            uts.BindColorPicker(Me.RadColorPickerBackground)
            uts.BindPrimaryColorPicker(Me.RadColorPickerSideBar)

            'Dim ColorCombos As New Generic.List(Of ColorCombo)
            'ColorCombos = uts.LoadColorCombos()

            'If ColorCombos IsNot Nothing Then

            '    Me.RadComboBoxColorCombos.DataSource = ColorCombos
            '    Me.RadComboBoxColorCombos.DataBind()

            'End If

            Me.LoadSettings()

        End If

    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click

        Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
        t.Load()

        t.Settings.BackgroundColor = Drawing.ColorTranslator.ToHtml(Me.RadColorPickerBackground.SelectedColor).ToString()
        t.Settings.SimpleLayoutBackgroundColor = Drawing.ColorTranslator.ToHtml(Me.RadColorPickerBackground.SelectedColor).ToString()
        t.Settings.SimpleLayoutSideBarColor = Drawing.ColorTranslator.ToHtml(Me.RadColorPickerSideBar.SelectedColor).ToString()
        t.Settings.SimpleLayoutIconStyle = Me.RadioButtonListIconStyle.SelectedValue
        t.Settings.SimpleLayoutShowNewMenu = Me.CheckBoxShowNewMenu.Checked
        t.Settings.SimpleLayoutShowAppMenu = Me.CheckBoxShowApplicationsMenu.Checked

        t.Save()
        t.Reload()

        Me.RefreshMDIPage()

    End Sub
    Private Sub ButtonGoToMySettings_Click(sender As Object, e As EventArgs) Handles ButtonGoToMySettings.Click

        Me.CloseThisWindowAndOpenNewWindow("MySettings.aspx")

    End Sub

    Private Sub LoadSettings()

        Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
        t.Reload()

        Me.RadColorPickerBackground.SelectedColor = Drawing.ColorTranslator.FromHtml(t.Settings.SimpleLayoutBackgroundColor)
        Me.RadColorPickerSideBar.SelectedColor = Drawing.ColorTranslator.FromHtml(t.Settings.SimpleLayoutSideBarColor)
        Me.RadioButtonListIconStyle.SelectedValue = CType(t.Settings.SimpleLayoutIconStyle, Integer).ToString()
        Me.CheckBoxShowNewMenu.Checked = t.Settings.SimpleLayoutShowNewMenu
        Me.CheckBoxShowApplicationsMenu.Checked = t.Settings.SimpleLayoutShowAppMenu

    End Sub


#End Region

End Class