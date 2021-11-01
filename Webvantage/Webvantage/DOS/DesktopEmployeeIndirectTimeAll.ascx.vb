Imports System.Data.SqlClient
Imports Webvantage.MiscFN
Imports Webvantage.cGlobals

Partial Public Class DesktopEmployeeIndirectTimeAll
    Inherits Webvantage.BaseDesktopObject



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then

            Dim sdate As Date
            Dim yr As Integer
            Dim yr_str As String

            sdate = System.DateTime.Now
            yr = sdate.Year
            yr_str = yr.ToString

            Me.RadDatePickerStartDate.SelectedDate = LoGlo.FirstOfYear()
            Me.RadDatePickerEndDate.SelectedDate = LoGlo.LastOfYear()

            LoadGrid()

        End If

    End Sub


    Private Sub wvMsgBox(ByVal strMessage As String, Optional ByVal MsgIcon As MsgBoxIcon = MsgBoxIcon.SystemError)
        Dim strScript As String
        strScript = "<script type=""text/javascript"">alert ('" & strMessage & "');</script>"
        If Not Page.IsStartupScriptRegistered("JSAlert") Then
            Page.RegisterStartupScript("JSAlert", strScript)
        End If
    End Sub

    Private Sub LoadGrid()
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))

        If validateData() = 1 Then
            Try
                Me.RadGrid1.DataSource = oDropDowns.GetEmployeesFML(Session("UserCode"))
                Me.RadGrid1.DataBind()

            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Function validateData() As Integer
        If MiscFN.ValidDate(Me.RadDatePickerStartDate) = False Then
            wvMsgBox("Invalid start date")
            Return -1
        End If
        If MiscFN.ValidDate(Me.RadDatePickerEndDate) = False Then
            wvMsgBox("Invalid end date")
            Return -1
        End If
        If MiscFN.ValidDateRange(Me.RadDatePickerStartDate, Me.RadDatePickerEndDate) = False Then
            wvMsgBox("Invalid date range")
            Return -1
        End If

        Session("STARTDATE_NPTA") = Me.RadDatePickerStartDate.SelectedDate
        Session("ENDDATE_NPTA") = Me.RadDatePickerEndDate.SelectedDate

        Return 1

    End Function

    Private Sub butRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefresh.Click
        LoadGrid()
    End Sub

    Private Sub RadGrid1_DetailTableDataBind(ByVal source As Object, ByVal e As Telerik.Web.UI.GridDetailTableDataBindEventArgs) Handles RadGrid1.DetailTableDataBind
        Dim dataItem As Telerik.Web.UI.GridDataItem = CType(e.DetailTableView.ParentItem, Telerik.Web.UI.GridDataItem)

        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim EmpCode As String = dataItem.GetDataKeyValue("Code").ToString()
        Dim startDate, endDate As String

        startDate = Me.RadDatePickerStartDate.SelectedDate
        endDate = Me.RadDatePickerEndDate.SelectedDate

        If validateData() = 1 Then
            e.DetailTableView.DataSource = oDO.GetNPTime(CStr(Session("UserCode")), EmpCode, startDate, endDate, "emp")
        End If

    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Try
            Dim gtv As Telerik.Web.UI.GridTableView
            Dim imgbtn As System.Web.UI.WebControls.ImageButton
            Dim emp As String
            Dim cat As String
            Dim flag As String
            Dim startdate As String
            Dim enddate As String
            For i As Integer = 0 To Me.RadGrid1.MasterTableView.Items.Count - 1
                emp = Me.RadGrid1.MasterTableView.Items(i).GetDataKeyValue("Code")
                For j As Integer = 0 To Me.RadGrid1.MasterTableView.Items(i).ChildItem.NestedTableViews.Length - 1
                    gtv = CType(Me.RadGrid1.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem).ChildItem.NestedTableViews(j)
                    If gtv.Items.Count > 0 Then
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In gtv.Items
                            If gridDataItem.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or gridDataItem.ItemType = Telerik.Web.UI.GridItemType.Item Then

                                If Not IsDBNull(gridDataItem.GetDataKeyValue("VAC_SICK_FLAG")) Then

                                    Try

                                        flag = gridDataItem.GetDataKeyValue("VAC_SICK_FLAG")

                                    Catch ex As Exception
                                        flag = 0
                                    End Try

                                Else

                                    flag = 0

                                End If

                                cat = gridDataItem.GetDataKeyValue("CATEGORY").ToString

                                If CShort(flag) > 0 Then

                                    cat = ""

                                End If

                                imgbtn = CType(gridDataItem("colDetails").FindControl("ImageButtonViewDetails"), ImageButton)
                                Dim URL As String = "popTime.aspx?EmpCode=" & emp &
                                                    "&start=" & Me.RadDatePickerStartDate.SelectedDate &
                                                    "&end=" & Me.RadDatePickerEndDate.SelectedDate &
                                                    "&flag=" & flag & "&cat=" & cat

                                imgbtn.Attributes.Add("onclick", "OpenRadWindow('Details','" & URL & "', 0, 0);return false;")

                                If gridDataItem("column3").Text <> "" And gridDataItem("column3").Text <> "&nbsp;" Then
                                    Dim strDate() As String = gridDataItem("column3").Text.Split("-")
                                    If strDate.Length > 0 Then
                                        startdate = strDate(0)
                                        enddate = strDate(1)
                                        gridDataItem("column3").Text = LoGlo.FormatDate(startdate).ToString() & " - " & LoGlo.FormatDate(enddate).ToString
                                    End If
                                End If

                            End If
                        Next
                    End If
                Next
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadDatePickerStartDate_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerStartDate.SelectedDateChanged

        LoadGrid()

    End Sub

    Private Sub RadDatePickerEndDate_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerEndDate.SelectedDateChanged

        LoadGrid()

    End Sub

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Employee_IndirectTime
                .UserCode = Session("UserCode")
                .Name = "Indirect Time (All)"
                .Description = "Indirect Time (All)"
                .PageURL = "DesktopObjectLoadWindow.aspx" & qs.ToString().Replace("&bm=1", "")

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                Me.ShowMessage(s)
            Else
                Me.RefreshBookmarksDesktopObject()

            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
