Public Class dtp_arcashforecastproduct
    Inherits Webvantage.BaseChildPage

    Private IsMy As Boolean = False

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Request.QueryString("my") Is Nothing Then
                If CType(Request.QueryString("my"), Integer) = 1 Then
                    IsMy = True
                Else
                    IsMy = False
                End If
            End If
        Catch ex As Exception
            IsMy = False
        End Try
        If IsMy = True Then
            Me.Page.Title = "My AR Cash Forecast"
            Me.LblTitle.Text = "My AR Cash Forecast"
        Else
            Me.Page.Title = "AR Cash Forecast Product"
            Me.LblTitle.Text = "AR Cash Forecast Product"
        End If
        Try
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    LoadAR(Request.QueryString("client"), Request.QueryString("office"), Request.QueryString("division"), Request.QueryString("product"), Request.QueryString("From"))
                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private Sub LoadAR(ByVal strClient As String, ByVal strOffice As String, ByVal strDivision As String, ByVal strProduct As String, ByVal from As String)
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        Me.ARForcastRG.Columns(5).HeaderText = Date.Now.ToString("MMMM")
        Me.ARForcastRG.Columns(6).HeaderText = Date.Now.AddMonths(1).ToString("MMMM")
        Me.ARForcastRG.Columns(7).HeaderText = Date.Now.AddMonths(2).ToString("MMMM")
        Me.ARForcastRG.Columns(8).HeaderText = Date.Now.AddMonths(3).ToString("MMMM")

        If (strClient.ToUpper = "ALL" Or strClient.Trim = "") And (strOffice.ToUpper = "ALL" Or strOffice.Trim = "") And (strDivision.ToUpper = "ALL" Or strDivision.Trim = "") And (strProduct.ToUpper = "ALL" Or strProduct.Trim = "") Then
            Me.ARForcastRG.DataSource = oDO.GetARForecastProduct(CStr(Session("UserCode")))
            Me.ARForcastRG.DataBind()
        Else
            Me.ARForcastRG.DataSource = oDO.GetARForecastProduct(CStr(Session("UserCode")), strClient.Trim, strOffice.Trim, strDivision.Trim, strProduct.Trim, from)
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