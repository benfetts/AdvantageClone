Public Class Maintenance_AlertDefaultSubject
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Page Events "

    Private Sub Maintenance_AlertDefaultSubject_Init(sender As Object, e As EventArgs) Handles Me.Init

    End Sub

    Private Sub Maintenance_AlertDefaultSubject_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub Maintenance_AlertDefaultSubject_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

    End Sub

#End Region

#Region " Controls Events "

    Private Sub RadComboBoxAlertLevel_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxAlertLevel.SelectedIndexChanged

    End Sub

#End Region

#Region " Methods "

    Private Sub BindRadComboBoxAlertLevel()

        With Me.RadComboBoxAlertLevel

            .DataSource = AdvantageFramework.AlertSystem.LoadSourceApps(Session("ConnString"), AdvantageFramework.Security.Application.Webvantage, True)
            .DataTextField = "SOURCE_APP_DESC"
            .DataValueField = "ID"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        End With

    End Sub

#End Region

End Class