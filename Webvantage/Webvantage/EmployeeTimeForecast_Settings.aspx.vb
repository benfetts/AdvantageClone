Public Class EmployeeTimeForecast_Settings
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

    Private Sub LoadTab(ByRef [Page] As System.Web.UI.Page)

        If [Page] Is Me Then

            AdvantageFramework.Web.Presentation.SettingPage.LoadTab(PlaceHolderSettings, _Session, 4, 0)

        End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub EmployeeTimeForecast_Settings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_EmployeeTimeForecast)

        AddHandler AdvantageFramework.Web.Presentation.SettingPage.LoadTabEvent, AddressOf LoadTab

        LoadTab(Me)

        If Me.IsPostBack Then

            AdvantageFramework.Web.Presentation.SettingPage.FindControl(Me, PlaceHolderSettings)

        End If

    End Sub
    Private Sub EmployeeTimeForecast_Settings_Unload(sender As Object, e As System.EventArgs) Handles Me.Unload

        RemoveHandler AdvantageFramework.Web.Presentation.SettingPage.LoadTabEvent, AddressOf LoadTab

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarEmployeeTimeForecast_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarEmployeeTimeForecast.ButtonClick

        Select Case e.Item.Value

            Case "Done"

                Me.CloseThisWindow()

            Case "LoadDefaults"

                AdvantageFramework.Web.Presentation.SettingPage.LoadDefaults(Session("ConnString").ToString(), Session("UserCode").ToString(), 4)

                LoadTab(Me)

        End Select

    End Sub

#End Region

#End Region

End Class