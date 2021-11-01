Imports System.Data.SqlClient
Imports Webvantage.MiscFN

Partial Public Class dtp_np_time_emp_all
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim startDate, endDate, Office As String

        startDate = Session("STARTDATE_NPTA")
        endDate = Session("ENDDATE_NPTA")

        LoadHeader()

        Me.RadGrid1.DataSource = oDO.GetNPTime(CStr(Session("UserCode")), CStr(Session("EmpCode")), startDate, endDate, "all")
        Me.RadGrid1.DataBind()

    End Sub

    Private Sub LoadHeader()
        Dim startDate, endDate As String
        Dim header_str As String

        startDate = Session("STARTDATE_NPTA")
        endDate = Session("ENDDATE_NPTA")

        header_str = "All Employees Indirect Time "
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