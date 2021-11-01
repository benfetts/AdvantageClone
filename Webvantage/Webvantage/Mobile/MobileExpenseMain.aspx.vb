Imports System.Data
Imports System.Data.SqlClient
Imports Webvantage.wvTimeSheet

Partial Public Class MobileExpenseMain
    Inherits MobileBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_ExpenseReports)
            Me.txtEmpCode.Text = Session("EmpCode")
            CheckEmpStatus() 'always keeps user from changing users. for now...
            LoadMonth()
            LoadYear()

            Try
                If Request.QueryString("empcode") <> "" Then
                    Me.txtEmpCode.Text = Request.QueryString("empcode")
                End If
                If Request.QueryString("month") <> "" Then
                    Me.ddlMonth.SelectedValue = Request.QueryString("month")
                End If
                If Request.QueryString("year") <> "" Then
                    Me.ddlYear.SelectedValue = Request.QueryString("year")
                End If
            Catch ex As Exception

            End Try
            ViewState("EmpCode") = Me.txtEmpCode.Text.Trim
        End If
        LoadExpenses()
        ChangeUser()
        VendorCheck()
    End Sub
    Private Sub lbBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        MiscFN.ResponseRedirect("~/mobile/default.aspx")
        Exit Sub
    End Sub

    Private Sub lbLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Me.SignOut()
    End Sub

   

    Protected Sub ibRefresh_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibRefresh.Click
        RefreshData()
    End Sub
    Private Sub RefreshData()
        ChangeUser()
        ViewState("EmpCode") = Me.txtEmpCode.Text.Trim
        LoadExpenses()
    End Sub
    Protected Sub ibNewExpense_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibNewExpense.Click
        MiscFN.ResponseRedirect("~/mobile/MobileExpenseEdit.aspx?invoice=new&empcode=" & ViewState("EmpCode"))
        Exit Sub
    End Sub


    Private Sub LoadMonth()
        Dim startmonth As String
        Me.ddlMonth.Items.Add(New ListItem(CStr("01"), CStr("01")))
        Me.ddlMonth.Items.Add(New ListItem(CStr("02"), CStr("02")))
        Me.ddlMonth.Items.Add(New ListItem(CStr("03"), CStr("03")))
        Me.ddlMonth.Items.Add(New ListItem(CStr("04"), CStr("04")))
        Me.ddlMonth.Items.Add(New ListItem(CStr("05"), CStr("05")))
        Me.ddlMonth.Items.Add(New ListItem(CStr("06"), CStr("06")))
        Me.ddlMonth.Items.Add(New ListItem(CStr("07"), CStr("07")))
        Me.ddlMonth.Items.Add(New ListItem(CStr("08"), CStr("08")))
        Me.ddlMonth.Items.Add(New ListItem(CStr("09"), CStr("09")))
        Me.ddlMonth.Items.Add(New ListItem(CStr("10"), CStr("10")))
        Me.ddlMonth.Items.Add(New ListItem(CStr("11"), CStr("11")))
        Me.ddlMonth.Items.Add(New ListItem(CStr("12"), CStr("12")))
        If IsNothing(Session("ExpenseMonth")) Then
            Me.ddlMonth.SelectedValue = Now.ToString("MM")
            Session("ExpenseMonth") = ddlMonth.SelectedValue.ToString
        Else
            Me.ddlMonth.SelectedValue = Session("ExpenseMonth")
        End If


    End Sub

    Private Sub LoadYear()
        Dim startyear As String
        Me.ddlYear.Items.Add(New ListItem(Now.AddYears(-5).Year.ToString(), Now.AddYears(-5).Year.ToString()))
        Me.ddlYear.Items.Add(New ListItem(Now.AddYears(-4).Year.ToString(), Now.AddYears(-4).Year.ToString()))
        Me.ddlYear.Items.Add(New ListItem(Now.AddYears(-3).Year.ToString(), Now.AddYears(-3).Year.ToString()))
        Me.ddlYear.Items.Add(New ListItem(Now.AddYears(-2).Year.ToString(), Now.AddYears(-2).Year.ToString()))
        Me.ddlYear.Items.Add(New ListItem(Now.AddYears(-1).Year.ToString(), Now.AddYears(-1).Year.ToString()))
        Me.ddlYear.Items.Add(New ListItem(Now.Year.ToString(), Now.Year.ToString()))
        Me.ddlYear.Items.Add(New ListItem(Now.AddYears(1).Year.ToString(), Now.AddYears(1).Year.ToString()))
        Me.ddlYear.Items.Add(New ListItem(Now.AddYears(2).Year.ToString(), Now.AddYears(2).Year.ToString()))
        Me.ddlYear.Items.Add(New ListItem(Now.AddYears(3).Year.ToString(), Now.AddYears(3).Year.ToString()))
        Me.ddlYear.Items.Add(New ListItem(Now.AddYears(4).Year.ToString(), Now.AddYears(4).Year.ToString()))
        Me.ddlYear.Items.Add(New ListItem(Now.AddYears(5).Year.ToString(), Now.AddYears(5).Year.ToString()))


        If IsNothing(Session("ExpenseYear")) Then
            Me.ddlYear.SelectedValue = Now.Year.ToString
            Session("ExpenseYear") = Me.ddlYear.SelectedValue.ToString
        Else
            Me.ddlYear.SelectedValue = Session("ExpenseYear").ToString
        End If

    End Sub
    Private Sub CheckEmpStatus()
        'Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))

        'If oTS.UserLimited(Session("UserCode")) = True Then
        '    Me.txtEmpCode.Enabled = False

        'End If
        'always keep the empcode disabled for now. per Bug report 404
        Me.txtEmpCode.Enabled = False
    End Sub
    Private Function ChangeUser() As String
        Dim oEmp As cEmployee = New cEmployee(Session("ConnString"))
        'Me.lblEmpName.Text = oEmp.GetName(Me.txtEmpCode.Text.Trim)
        gvExpense.Caption = "Employee:&nbsp;&nbsp;" & oEmp.GetName(Me.txtEmpCode.Text.Trim)
    End Function
    Private Sub VendorCheck()
        Dim oExpense As cExpense = New cExpense(Session("ConnString"))
        If oExpense.CheckVendor(Me.txtEmpCode.Text.Trim) = False Then
            Me.ibNewExpense.Enabled = False
            lblMessage.Text = "This employee code is not associated with a vendor code."
        Else
            Me.ibNewExpense.Enabled = True
            lblMessage.Text = ""
        End If
    End Sub
    Public Sub LoadExpenses()
        Dim oExpense As cExpense = New cExpense(Session("ConnString"))
        Dim TheseHeaders As ExpenseHeaders
        Dim StartDate As Date = CType(Session("ExpenseMonth") & "/1/" & Session("ExpenseYear"), Date)
        Dim EndDate As Date = StartDate.AddDays(Date.DaysInMonth(StartDate.Year, StartDate.Month))
        TheseHeaders = oExpense.GetAllExpenses(Me.txtEmpCode.Text.Trim, StartDate, EndDate)
        gvExpense.DataSource = TheseHeaders
        gvExpense.DataBind()
    End Sub

    Private Sub gvExpense_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvExpense.RowDataBound
        Dim StrStatus As String
        Dim StrInvoiceNum As String
        Dim lit As Literal
        Dim PaidImage As Web.UI.WebControls.HyperLink
        Dim inv_nbr As Long
        Dim emp_code As String
        Dim image_path As String

        emp_code = Me.txtEmpCode.Text
        If e.Row.RowType = DataControlRowType.DataRow Then
            StrStatus = DataBinder.Eval(e.Row.DataItem, "STATUS")
            lit = CType(e.Row.Cells(0).Controls(1), Literal)
            StrInvoiceNum = DataBinder.Eval(e.Row.DataItem, "INV_NBR")
            Select Case StrStatus
                Case "Approved", "Approved by Supervisor", "Approved in Accounting"
                    lit.Text = "<a href='MobileExpenseEdit.aspx?invoice=" & StrInvoiceNum & "' Title='View Expense Report'>" + StrInvoiceNum + "</a>"

                Case Else
                    lit.Text = "<a href='MobileExpenseEdit.aspx?invoice=" & StrInvoiceNum & "' Title='Edit Expense Report'>" + StrInvoiceNum + "</a>"

                    'Case "Pending"
                    '    lit.Text = "<a href='MobileExpenseEdit.aspx?invoice=" & StrInvoiceNum & "' Title='You may only view this expense because it is pending!'>" + StrInvoiceNum + "</a>"
                    'Case "Approved"
                    '    lit.Text = "<a href='MobileExpenseEdit.aspx?invoice=" & StrInvoiceNum & "' Title='You may only view this expense because it has been approved!'>" + StrInvoiceNum + "</a>"
                    'Case Else
                    '    lit.Text = "<a href='MobileExpenseEdit.aspx?invoice=" & StrInvoiceNum & "' Title='Click to edit.'>" + StrInvoiceNum + "</a>"
            End Select
            PaidImage = CType(e.Row.Cells(5).Controls(1), System.Web.UI.WebControls.HyperLink)
            PaidImage.Visible = SetImage(emp_code, CInt(StrInvoiceNum))

            'If PaidImage.Visible = True Then
            '    PaidImage.NavigateUrl = "expense_paid_popup.aspx?Inv=" & StrInvoiceNum & "&Emp=" & emp_code
            'End If
        End If
    End Sub
    Private Function SetImage(ByVal emp_code As String, ByVal inv_nbr As Integer) As Boolean
        Dim SQL_STRING As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim chk_ct As Int32

        SQL_STRING = ""
        SQL_STRING = "SELECT count(*) "
        SQL_STRING += " FROM AP_PMT_HIST APH "
        SQL_STRING += " WHERE APH.AP_ID = ( SELECT AH.AP_ID "
        SQL_STRING += " FROM AP_HEADER AH, EXPENSE_HEADER EH "
        SQL_STRING += " WHERE AH.VN_FRL_EMP_CODE = EH.VN_CODE "
        SQL_STRING += " AND AH.AP_INV_VCHR = cast(EH.INV_NBR AS varchar(20)) "
        SQL_STRING += " AND EH.EMP_CODE = '" & emp_code & "'"
        SQL_STRING += " AND EH.INV_NBR = " & inv_nbr & ") "
        SQL_STRING += " GROUP BY APH.AP_ID, AP_CHK_NBR "
        SQL_STRING += " HAVING SUM(APH.AP_CHK_AMT) > 0 "

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:expense_main Routine:GetImage", Err.Description)
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

    Protected Sub gvExpense_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvExpense.SelectedIndexChanged

    End Sub

    Protected Sub ddlMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMonth.SelectedIndexChanged
        Session("ExpenseMonth") = ddlMonth.SelectedValue.ToString
        RefreshData()
    End Sub

    Protected Sub ddlYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlYear.SelectedIndexChanged
        Session("ExpenseYear") = ddlYear.SelectedValue.ToString
        RefreshData()
    End Sub
End Class