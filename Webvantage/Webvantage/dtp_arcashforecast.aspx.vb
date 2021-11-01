Public Class dtp_arcashforecast
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    LoadAR(Request.QueryString("client"), Request.QueryString("office"))
                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub
    Private Sub LoadAR(ByVal strClient As String, ByVal strOffice As String)
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        Me.ARForcastRG.Columns(3).HeaderText = Date.Now.ToString("MMMM")
        Me.ARForcastRG.Columns(4).HeaderText = Date.Now.AddMonths(1).ToString("MMMM")
        Me.ARForcastRG.Columns(5).HeaderText = Date.Now.AddMonths(2).ToString("MMMM")
        Me.ARForcastRG.Columns(6).HeaderText = Date.Now.AddMonths(3).ToString("MMMM")

        If (strClient.ToUpper = "ALL" Or strClient.Trim = "") And (strOffice.ToUpper = "ALL" Or strOffice.Trim = "") Then
            Me.ARForcastRG.DataSource = oDO.GetARForecast(CStr(Session("UserCode")))
            Me.ARForcastRG.DataBind()
        Else
            Me.ARForcastRG.DataSource = oDO.GetARForecast(CStr(Session("UserCode")), strClient.Trim, strOffice.Trim)
            Me.ARForcastRG.DataBind()
        End If
    End Sub

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            If Request.QueryString("export") = 1 Then
                Dim str As String = ""
                str = "ARForecast" & "_" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString()
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.ARForcastRG, str)
                ARForcastRG.MasterTableView.ExportToExcel()
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class