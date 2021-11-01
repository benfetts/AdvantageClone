Imports System.Data.SqlClient
Imports Webvantage.MiscFN

Partial Public Class dtp_np_time_emp
    Inherits Webvantage.BaseChildPage

    Public ibSupervisor As Boolean

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim startDate, endDate, Office As String

        startDate = Session("STARTDATE_NPT")
        endDate = Session("ENDDATE_NPT")

        LoadHeader()

        Me.RadGrid1.DataSource = oDO.GetNPTime(CStr(Session("UserCode")), CStr(Session("EmpCode")), startDate, endDate, "emp")
        Me.RadGrid1.DataBind()

        Dim empl As String
        empl = CStr(Session("EmpCode"))
        ibSupervisor = isEmployeeSupervisor(CStr(Session("EmpCode")))

        If ibSupervisor Then
            Me.ImageButton1.Visible = True
            Me.lblShowUsers.Visible = True
        Else
            Me.ImageButton1.Visible = False
            Me.lblShowUsers.Visible = False
        End If

    End Sub

    Private Sub LoadHeader()
        Dim startDate, endDate, Office As String
        Dim header_str As String

        startDate = Session("STARTDATE_NPT")
        endDate = Session("ENDDATE_NPT")

        header_str = "Employee Indirect Time "
        Me.Label1.Text = header_str

        header_str = "Date Range: " & startDate & " to " & endDate
        Me.lblType.Text = header_str

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
            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            Dim startDate, endDate, view As String

            startDate = Session("STARTDATE_NPT")
            endDate = Session("ENDDATE_NPT")

            Me.RadGrid2.DataSource = oDO.GetNPTime(CStr(Session("UserCode")), CStr(Session("EmpCode")), startDate, endDate, "sup")
            Me.RadGrid2.DataBind()

            Me.RadGrid2.Visible = True
            Me.Button2.Visible = True
            Me.Button1.Visible = False

            Me.lblShowUsers.Text = "Collapse Supervisor Employees"

        Else
            Me.lblShowUsers.Text = "Show Supervisor Employees"
            Me.RadGrid2.Visible = False
            Me.Button2.Visible = False
            Me.Button1.Visible = True

        End If

    End Sub

    Private Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        Try
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
                Dim startdate As String
                Dim enddate As String
                Dim strDate() As String = e.Item.Cells(4).Text.Split("-")
                If strDate.Length > 0 Then
                    startdate = strDate(0)
                    enddate = strDate(1)
                    e.Item.Cells(4).Text = LoGlo.FormatDate(startdate).ToString() & " - " & LoGlo.FormatDate(enddate).ToString
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
