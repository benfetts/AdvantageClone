Public Class Expense_CopyExpenseReport
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _InvoiceNumber As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadExpense()

        'objects
        Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadCombobox_Employee.DataSource = (From Entity In AdvantageFramework.ExpenseReports.LoadExpenseEmployees(_Session, DbContext, SecurityDbContext, False).ToList
                                                   Select Entity.Code,
                                                          [Name] = Entity.ToString).ToList

                RadCombobox_Employee.DataBind()

                ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, _InvoiceNumber)

            End Using

        End Using

        If ExpenseReport IsNot Nothing Then

            RadCombobox_Employee.SelectedValue = ExpenseReport.EmployeeCode
            RadDatePicker_ReportDate.DbSelectedDate = ExpenseReport.InvoiceDate
            RadTextBox_Description.Text = ExpenseReport.Description
            RadTextBox_Details.Text = ExpenseReport.Details

        End If

    End Sub

#Region "  Form Event Handlers "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim QueryString As New AdvantageFramework.Web.QueryString()

        QueryString = QueryString.FromCurrent()

        Try

            _InvoiceNumber = QueryString.ExpenseID

        Catch ex As Exception

        End Try

        If IsPostBack = False Then

            LoadExpense()

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub Button_Copy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_Copy.Click

        'objects
        Dim EmployeeCode As String = Nothing
        Dim Description As String = Nothing
        Dim Details As String = Nothing
        Dim ReportDate As System.DateTime = Nothing
        Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
        Dim DuplicateExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
        Dim DuplicateExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim Copied As Boolean = False
        Dim ErrorText As String = Nothing
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        EmployeeCode = RadCombobox_Employee.SelectedValue
        Description = RadTextBox_Description.Text

        If EmployeeCode.Trim = "" Then

            Me.ShowMessage("Please selected an employee.")

        ElseIf Description.Trim = "" Then

            Me.ShowMessage("Description is required.")

        Else

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Details = RadTextBox_Details.Text
                ReportDate = RadDatePicker_ReportDate.SelectedDate

                If AdvantageFramework.ExpenseReports.CopyExpenseReport(DbContext, _InvoiceNumber, EmployeeCode, ReportDate, Description, Details, ErrorText) Then

                    QueryString = New AdvantageFramework.Web.QueryString

                    QueryString.Page = "expense_edit_v2.aspx"
                    QueryString.Add("invoice", _InvoiceNumber)

                    'Me.CloseThisWindowAndRefreshCaller(QueryString.ToString(True), True)
                    Me.OpenWindow(QueryString, "Expense report")

                    Me.CloseThisWindow()

                Else

                    Me.ShowMessage(ErrorText)

                End If

            End Using

        End If

    End Sub

#End Region

#End Region

End Class
