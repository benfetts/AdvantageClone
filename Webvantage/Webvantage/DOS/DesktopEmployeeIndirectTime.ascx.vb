Imports System.Data.SqlClient
Imports Webvantage.MiscFN
Imports Webvantage.cGlobals

Partial Public Class DesktopEmployeeIndirectTime
    Inherits Webvantage.BaseDesktopObject


    Public ibSupervisor As Boolean
    Private StartDate As DateTime = Nothing
    Private EndDate As DateTime = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then
            Dim empl As String
            empl = CStr(Session("EmpCode"))
            ibSupervisor = isEmployeeSupervisor(CStr(Session("EmpCode")))
            Me.RadDatePickerStartDate.SelectedDate = LoGlo.FirstOfYear()
            Me.RadDatePickerEndDate.SelectedDate = LoGlo.LastOfYear()
            LoadGrid()
        Else
            Me.validateData()
        End If
    End Sub

    Private Sub LoadGrid()
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim empl As String

        Me.StartDate = Me.RadDatePickerStartDate.SelectedDate
        Me.EndDate = Me.RadDatePickerEndDate.SelectedDate

        If validateData() = 1 Then
            Me.RadGrid1.DataSource = oDO.GetNPTime(CStr(Session("UserCode")), CStr(Session("EmpCode")), Me.StartDate, Me.EndDate, "emp")
            Me.RadGrid1.DataBind()

            empl = CStr(Session("EmpCode"))
            ibSupervisor = isEmployeeSupervisor(CStr(Session("EmpCode")))

            If ibSupervisor Then
                Me.ImageButton1.Visible = True
                Me.lblShowUsers.Visible = True
            Else
                Me.ImageButton1.Visible = False
                Me.lblShowUsers.Visible = False
            End If
        End If

    End Sub

    Private Function validateData() As Integer

        Me.StartDate = Me.RadDatePickerStartDate.SelectedDate
        Me.EndDate = Me.RadDatePickerEndDate.SelectedDate

        If Me.StartDate = Nothing Or cGlobals.wvIsDate(StartDate) = False Then
            wvMsgBox("Please enter valid Start Date.")
            Return -1
        End If

        If Me.EndDate = Nothing Or cGlobals.wvIsDate(EndDate) = False Then
            wvMsgBox("Please enter valid End Date.")

            Return -1
        End If

        If MiscFN.StartIsBeforeEnd(cGlobals.wvCDate(Me.RadDatePickerStartDate.SelectedDate), cGlobals.wvCDate(Me.RadDatePickerEndDate.SelectedDate)) = False Then
            Me.StartDate = cGlobals.wvCDate(Me.RadDatePickerEndDate.SelectedDate)
            Me.EndDate = cGlobals.wvCDate(Me.RadDatePickerStartDate.SelectedDate)
            Me.RadDatePickerStartDate.SelectedDate = Me.StartDate
            Me.RadDatePickerEndDate.SelectedDate = Me.EndDate
        End If

        Session("STARTDATE_NPT") = Me.RadDatePickerStartDate.SelectedDate
        Session("ENDDATE_NPT") = Me.RadDatePickerEndDate.SelectedDate

        Return 1

    End Function

    Private Sub wvMsgBox(ByVal strMessage As String, Optional ByVal MsgIcon As MsgBoxIcon = MsgBoxIcon.SystemError)
        Dim strScript As String
        strScript = "<script type=""text/javascript"">alert ('" & strMessage & "');</script>"
        If Not Page.IsStartupScriptRegistered("JSAlert") Then
            Page.RegisterStartupScript("JSAlert", strScript)
        End If
    End Sub

    Private Sub butRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefresh.Click
        Me.validateData()
        LoadGrid()
    End Sub

    Private Function isEmployeeSupervisor(ByVal emp_code As String) As Boolean
        Dim SQL_STRING As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim chk_ct As Int32

        SQL_STRING = "SELECT count(*) FROM EMPLOYEE Where EMP_TERM_DATE IS NULL AND EMPLOYEE.SUPERVISOR_CODE = '" & emp_code & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:dt_np_time_emp.ascx Routine:isEmployeeSupervisor", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            dr.Read()
            chk_ct = dr.GetInt32(0)
        Else
            chk_ct = 0
        End If

        dr.Close()

        If chk_ct > 0 Then
            Return True
        Else
            Return False
        End If


    End Function

    Private Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim lbltext As String

        lbltext = Me.lblShowUsers.Text
        If lbltext = "Show Supervisor Employees" Then
            Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
            Dim view As String
            Dim super As String

            super = Session("EmpCode")

            Me.RadGrid2.DataSource = oDropDowns.GetEmployeesBySupervisor(Session("UserCode"), Session("EmpCode"))
            Me.RadGrid2.DataBind()

            Me.RadGrid2.Visible = True

            Me.lblShowUsers.Text = "Collapse Supervisor Employees"
        Else
            Me.lblShowUsers.Text = "Show Supervisor Employees"
            Me.RadGrid2.Visible = False

        End If

    End Sub

    Private Sub RadGrid2_DetailTableDataBind(ByVal source As Object, ByVal e As Telerik.Web.UI.GridDetailTableDataBindEventArgs) Handles RadGrid2.DetailTableDataBind
        Me.validateData()
        Dim dataItem As Telerik.Web.UI.GridDataItem = CType(e.DetailTableView.ParentItem, Telerik.Web.UI.GridDataItem)

        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim EmpCode As String = dataItem.GetDataKeyValue("Code").ToString()

        If validateData() = 1 Then
            e.DetailTableView.DataSource = oDO.GetNPTime(CStr(Session("UserCode")), EmpCode, Me.StartDate, Me.EndDate, "emp")
        End If

    End Sub

    Private Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        Try
            Dim gridDataItem As Telerik.Web.UI.GridDataItem
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
                gridDataItem = e.Item
                Dim emp As String
                Dim flag As String = e.Item.Cells(4).Text
                Dim cat As String = gridDataItem.GetDataKeyValue("CATEGORY").ToString
                Dim str As String = e.Item.Cells(3).Text
                Dim sdate As DateTime
                Dim edate As DateTime
                'If str = "Vacation" Then
                '    flag = 1
                'ElseIf str = "Sick" Then
                '    flag = 2
                'ElseIf str = "Personal" Then
                '    flag = 3
                'Else
                '    flag = 0
                'End If

                If gridDataItem.DataItem IsNot Nothing Then

                    Try

                        flag = CType(gridDataItem.DataItem, System.Data.DataRowView)("VAC_SICK_FLAG")

                    Catch ex As Exception
                        flag = 0
                    End Try

                End If

                If flag > 0 Then

                    cat = ""

                End If

                Try
                    Dim ViewImage As WebControls.ImageButton = e.Item.FindControl("ImageButtonViewDetails")
                    Dim URL As String = "popTime.aspx?EmpCode=" & Session("EmpCode") & _
                        "&start=" & Me.StartDate.ToShortDateString() & _
                        "&end=" & Me.EndDate.ToShortDateString() & _
                        "&flag=" & flag & "&cat=" & cat

                    ViewImage.Attributes.Add("onclick", "OpenRadWindow('Details','" & URL & "', 0, 0);return false;")
                Catch ex As Exception
                End Try

                Try
                    Dim strDate() As String = e.Item.Cells(4).Text.Split("-")
                    If strDate.Length > 0 Then
                        sdate = LoGlo.FormatDate(strDate(0))
                        edate = LoGlo.FormatDate(strDate(1))
                        e.Item.Cells(4).Text = sdate.ToShortDateString & " - " & edate.ToShortDateString
                    End If
                Catch ex As Exception
                End Try

            End If
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

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Employee_MyIndirectTime
                .UserCode = Session("UserCode")
                .Name = "Indirect Time (My)"
                .Description = "Indirect Time (My)"
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
