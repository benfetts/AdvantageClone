Public Class MediaCalendar_Print
    Inherits Webvantage.BaseChildPage

#Region " > Page Level "
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load

        If Page.IsPostBack = False Then
            Try
                Try
                    If Not Session("ConnString") Is Nothing Then
                        If Session("ConnString") <> "" Then
                            LoadLookup()
                        End If
                    End If
                Catch ex As Exception
                    Throw (ex)
                End Try
            Catch ex As Exception
                Me.ShowMessage("Error Page_Load!<BR />" & ex.Message.ToString())
            Finally

            End Try
        End If
    End Sub

#End Region

#Region " > Controls "

    Private Sub butSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butSelect.Click
        Try
            Dim ar() As String
            ar = ddLocations.SelectedItem.Value.ToString.Split("|")

            Session("LogoPath") = ar(1)
            Session("MediaSchPrintText") = txtData.Text
            Dim strURL As String = "popReportViewer.aspx?thisdate=" & Request.QueryString("thisdate") & "&Type=1&Report=mediareport"
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            strBuilder.Append("<script language='javascript'>")
            strBuilder.Append("window.open('" & strURL & "', '', 'screenX=150,left=150,screenY=150,top=150,width=435,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
            strBuilder.Append("</")
            strBuilder.Append("script>")
            'Page.RegisterClientScriptBlock("newpage", strBuilder.ToString())
            Page.RegisterStartupScript("newpage", strBuilder.ToString())
        Catch ex As Exception
            Me.ShowMessage("Error butSelect_Click !<BR />" & ex.Message.ToString())
        Finally

        End Try
    End Sub

#End Region

#Region " > Subs and Functions "

    Private Sub LoadLookup()
        Try
            Dim oReports As cReports = New cReports(CStr(Session("ConnString")))

            Me.ddLocations.DataSource = oReports.GetLocationPO
            Me.ddLocations.DataTextField = "ID"
            Me.ddLocations.DataValueField = "LOGO_PATH"
            Me.ddLocations.DataBind()
            Me.ddLocations.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", "[None]"))
        Catch ex As Exception
            Me.ShowMessage("Error ddlocation!<BR />" & ex.Message.ToString())
        Finally

        End Try
    End Sub


#End Region

End Class