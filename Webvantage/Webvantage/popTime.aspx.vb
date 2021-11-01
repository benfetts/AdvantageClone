Partial Public Class popTime
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        Try
            If Page.IsPostBack = False Then
                Me.LabelTime.Text = ""
            End If
            Me.butPrint.Attributes.Add("onclick", "window.print();return false;")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridTime_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridTime.ItemDataBound
        Try
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
                Dim str As String = e.Item.Cells(1).Text
                Dim str2 As String = e.Item.Cells(2).Text
                Dim str3 As String = e.Item.Cells(3).Text
                Dim str4 As String = e.Item.Cells(4).Text
                If e.Item.Cells(2).Text <> "" And e.Item.Cells(2).Text <> "&nbsp;" Then
                    e.Item.Cells(2).Text = CDate(e.Item.Cells(2).Text).ToShortDateString
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridTime_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridTime.NeedDataSource
        Try
            Dim startdate As String
            Dim enddate As String
            Dim flag As String
            Dim EmpCode As String
            Dim cat As String
            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            If Request.QueryString("start") <> "" Then
                startdate = Request.QueryString("start")
            End If
            If Request.QueryString("end") <> "" Then
                enddate = Request.QueryString("end")
            End If
            If Request.QueryString("EmpCode") <> "" Then
                EmpCode = Request.QueryString("EmpCode")
            End If
            If Request.QueryString("flag") <> "" Then
                flag = Request.QueryString("flag")
            End If
            If Request.QueryString("cat") <> "" Then
                cat = Request.QueryString("cat")
            End If
            Me.RadGridTime.DataSource = oDO.GetNPTimeData(Session("UserCode"), EmpCode, startdate, enddate, flag, cat)
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub cbShowProducts_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbShowProducts.CheckedChanged
    '    Try
    '        Me.RadGridCA.Rebind()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub butExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butExport.Click
        Try
            Dim str As String = ""
            str = "EmpIndirectTime" & "_" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString()
            AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridTime, str)
            RadGridTime.MasterTableView.ExportToExcel()
        Catch ex As Exception

        End Try
    End Sub

End Class