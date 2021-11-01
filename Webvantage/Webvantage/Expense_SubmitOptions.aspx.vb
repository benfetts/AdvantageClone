Public Class Expense_SubmitOptions
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _InvoiceNumber As Integer = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub Submit(ByVal ApprovalRequired As Boolean)

        'objects
        Dim SubmittedToEmployeeCode As String = Nothing
        Dim OkToSubmit As Boolean = True
        Dim ErrorMessage As String = ""
        Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim IncludeReceiptsInEmailAndAlert As Boolean = False
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim CloseWindow As Boolean = False

        If ApprovalRequired Then

            IncludeReceiptsInEmailAndAlert = CheckBox_IncludeReceiptsInEmailAndAlert.Checked
            SubmittedToEmployeeCode = RadComboBox_Employees.SelectedValue

            If SubmittedToEmployeeCode.Trim = "" Then

                ErrorMessage = "Please selected an approver."

                OkToSubmit = False

            End If

        End If

        If OkToSubmit Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, _InvoiceNumber)

                If ExpenseReport IsNot Nothing Then

                    ExpenseReport.SubmittedTo = SubmittedToEmployeeCode

                    If AdvantageFramework.Database.Procedures.ExpenseReport.Update(DbContext, ExpenseReport) Then

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.EmployeeCode)

                        Dim AlertId As Integer = 0
                        If AdvantageFramework.ExpenseReports.SubmitExpenseReport(_Session, ExpenseReport, Employee, IncludeReceiptsInEmailAndAlert, ErrorMessage, False, AlertId) = True Then

                            Dim eso As New EmailSessionObject(HttpContext.Current.Session("ConnString"),
                                                 HttpContext.Current.Session("UserCode"),
                                                 Me._Session,
                                                 HttpContext.Current.Session("WebvantageURL"),
                                                 HttpContext.Current.Session("ClientPortalURL"))

                            With eso

                                .AlertId = AlertId
                                .Subject = ""
                                .AppName = "Expense"
                                .SessionID = HttpContext.Current.Session.SessionID.ToString()
                                .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                                .Send()

                            End With

                            Me.CheckForAsyncMessage()

                            CloseWindow = True

                            QueryString = New AdvantageFramework.Web.QueryString()

                            QueryString.Page = "Expense_Edit_V2.aspx"
                            QueryString.Add("invoice", ExpenseReport.InvoiceNumber)

                        End If

                    End If

                End If

            End Using

        End If

        If ErrorMessage <> "" Then

            Me.ShowMessage(ErrorMessage)

        End If

        If CloseWindow Then

            Me.CloseThisWindowAndRefreshCaller(QueryString.ToString(True), True)

        End If

    End Sub

#Region "  Form Event Handlers "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim QueryString As New AdvantageFramework.Web.QueryString()
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
        Dim AltApprover As AdvantageFramework.Database.Views.Employee = Nothing
        Dim MainApprover As AdvantageFramework.Database.Views.Employee = Nothing

        QueryString = QueryString.FromCurrent()

        Try

            _InvoiceNumber = QueryString.ExpenseID

        Catch ex As Exception
            _InvoiceNumber = Nothing
        End Try

        If IsPostBack = False Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, _InvoiceNumber)

                    If ExpenseReport IsNot Nothing Then

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.EmployeeCode)

                        If Employee IsNot Nothing Then

                            If CBool(Employee.SupervisorApprovalRequired.GetValueOrDefault(0)) = False Then

                                Submit(False)

                            Else

                                Button_Submit.CommandArgument = "1"

                                Label_ExpenseEmployee.Text = Employee.ToString

                                RadComboBox_Employees.DataSource = (From Entity In AdvantageFramework.ExpenseReports.LoadAvailableApprovers(_Session, DbContext, SecurityDbContext, Employee.Code)
                                                                    Select Entity.Code,
                                                                           [Name] = Entity.ToString).ToList

                                RadComboBox_Employees.DataBind()

                                RadComboBox_Employees.SelectedValue = Nothing

                                Try

                                    If String.IsNullOrWhiteSpace(Employee.AlternateApproverCode) = False Then

                                        AltApprover = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Employee.AlternateApproverCode)

                                        If AltApprover IsNot Nothing Then

                                            Label_AlternateApprover.Text = AltApprover.ToString

                                            If AltApprover.TerminationDate.HasValue = False Then

                                                RadComboBox_Employees.SelectedValue = Employee.AlternateApproverCode

                                            End If

                                        Else

                                            Label_AlternateApprover.Text = ""

                                        End If

                                    End If

                                Catch ex As Exception
                                    Label_AlternateApprover.Text = ""
                                End Try

                                Try

                                    If String.IsNullOrWhiteSpace(Employee.SupervisorEmployeeCode) = False Then

                                        MainApprover = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Employee.SupervisorEmployeeCode)

                                        If MainApprover IsNot Nothing Then

                                            Label_Supervisor.Text = MainApprover.ToString

                                            If RadComboBox_Employees.SelectedValue = "" Then

                                                If MainApprover.TerminationDate.HasValue = False Then

                                                    RadComboBox_Employees.SelectedValue = Employee.SupervisorEmployeeCode

                                                End If

                                            End If

                                        Else

                                            Label_Supervisor.Text = ""

                                        End If

                                    End If

                                Catch ex As Exception
                                    Label_Supervisor.Text = ""
                                End Try

                            End If

                        End If

                    End If

                End Using

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub Button_Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_Submit.Click

        Submit(CBool(Button_Submit.CommandArgument))

    End Sub

#End Region

#End Region

End Class
