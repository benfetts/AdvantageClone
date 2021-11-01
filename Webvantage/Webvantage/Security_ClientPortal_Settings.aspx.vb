Imports System.Text
Imports System.Security.Cryptography
Imports System.Xml
Imports System.IO
Partial Public Class securityClientPortalSettings
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

            getSettings()

            If Me.lblWVFolder.Text = "" Then

                Me.lblWVFolder.Text = "N/A"

            End If

            If Me.lblCPFolder.Text = "" Then

                Me.lblCPFolder.Text = "N/A"

            End If

        Else

        End If

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))
            If SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.AGENCY WHERE ASP_ACTIVE = 1").First >= 1 Then
                Me.txtWVFolder.Enabled = False
                Me.txtCPFolder.Enabled = False
                Me.RadToolbarEventScheduler.FindItemByValue("Save").Enabled = False
                Me.RadToolbarEventScheduler.FindItemByValue("Clear").Enabled = False
            End If
        End Using
    End Sub

#End Region

#Region " Controls Events "

    Private Sub RadToolbarEventScheduler_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarEventScheduler.ButtonClick

        Select Case e.Item.Value

            Case "Save"

                Try
                    Dim oSecurity As cSecurity = New cSecurity(Session("ConnString"))
                    Dim saveLogo As Boolean
                    Dim save As Boolean
                    Dim dr As SqlClient.SqlDataReader

                    If Me.txtWVFolder.Text <> "" And Me.txtCPFolder.Text <> "" Then

                        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            If Agency IsNot Nothing Then
                                Agency.WebvantageURL = Me.txtWVFolder.Text
                                Agency.ClientPortalURL = Me.txtCPFolder.Text
                                AdvantageFramework.Database.Procedures.Agency.Update(DbContext, Agency)
                            End If

                        End Using

                        save = oSecurity.settingsCP(Me.txtWVFolder.Text, Me.txtCPFolder.Text)

                    ElseIf Me.txtWVFolder.Text = "" And Me.txtCPFolder.Text <> "" Then

                        Me.ShowMessage("Please enter Webvantage folder.")

                    ElseIf Me.txtWVFolder.Text <> "" And Me.txtCPFolder.Text = "" Then

                        Me.ShowMessage("Please enter Client Portal folder.")

                    End If

                    getSettings()

                Catch ex As Exception

                    Me.ShowMessage(ex.Message)

                End Try

            Case "Clear"

                Me.txtWVFolder.Text = ""
                Me.txtCPFolder.Text = ""

            Case "CustomizeClientPortalClients"

                Try

                    Dim qs As New AdvantageFramework.Web.QueryString()
                    With qs

                        .Page = "AgencySettings.aspx"
                        .Add("pm", CType(AgencySettings_Upload.PageMode.ClientPortal, Integer).ToString())
                        .ClientCode = ""

                    End With

                    Me.OpenWindow("Client Portal Customization", qs.ToString(True))

                Catch ex As Exception

                End Try

            Case "SetupWorkspaceTemplate"

                Me.OpenWindow("Workspace Manager", "Workspace_Manage.aspx?cp=1")

        End Select

    End Sub

#End Region

#Region " Methods "

    Private Function getSettings()
        'Dim csec As New cSecurity(Session("ConnString"))
        'Dim dr As SqlClient.SqlDataReader
        'dr = csec.getSettingsCP()
        'If dr.HasRows = True Then
        '    Do While dr.Read
        '        Me.lblWVFolder.Text = dr.GetString(0)
        '        Me.lblCPFolder.Text = dr.GetString(1)
        '    Loop
        '    dr.Close()
        'End If

        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then
                Me.lblWVFolder.Text = Agency.WebvantageURL
                Me.lblCPFolder.Text = Agency.ClientPortalURL
            End If

        End Using

    End Function

#End Region

End Class
