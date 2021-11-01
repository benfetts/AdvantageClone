Namespace Employee.Presentation

    Public Class ExpenseReportSubmitDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EmployeeCode As String = Nothing
        Private _ApproverCode As String = Nothing
        Private _IncludeReceiptsInEmailAndAlert As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
        End Property
        Private ReadOnly Property ApproverCode As String
            Get
                ApproverCode = _ApproverCode
            End Get
        End Property
        Private ReadOnly Property IncludeReceiptsInEmailAndAlert As String
            Get
                IncludeReceiptsInEmailAndAlert = _IncludeReceiptsInEmailAndAlert
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal EmployeeCode As String, ByRef ApproverCode As String, ByRef IncludeReceiptsInEmailAndAlert As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _EmployeeCode = EmployeeCode
            _ApproverCode = ApproverCode
            _IncludeReceiptsInEmailAndAlert = IncludeReceiptsInEmailAndAlert

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal EmployeeCode As String, ByRef ApproverCode As String, ByRef IncludeReceiptsInEmailAndAlert As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim ExpenseReportSubmitDialog As AdvantageFramework.Employee.Presentation.ExpenseReportSubmitDialog = Nothing

            ExpenseReportSubmitDialog = New AdvantageFramework.Employee.Presentation.ExpenseReportSubmitDialog(EmployeeCode, ApproverCode, IncludeReceiptsInEmailAndAlert)

            ShowFormDialog = ExpenseReportSubmitDialog.ShowDialog()

            EmployeeCode = ExpenseReportSubmitDialog.EmployeeCode
            ApproverCode = ExpenseReportSubmitDialog.ApproverCode
            IncludeReceiptsInEmailAndAlert = ExpenseReportSubmitDialog.IncludeReceiptsInEmailAndAlert

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ExpenseReportSubmitDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim AlternateApprover As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Supervisor As AdvantageFramework.Database.Views.Employee = Nothing
            Dim SupervisorText As String = Nothing
            Dim AlternateApproverText As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                    If Employee IsNot Nothing Then

                        LabelForm_Employee.Text = Employee.ToString

                        SearchableComboBoxForm_Approver.DataSource = AdvantageFramework.ExpenseReports.LoadAvailableApprovers(Me.Session, DbContext, SecurityDbContext, Employee.Code)

                        SearchableComboBoxForm_Approver.SetRequired(True)

                        Try

                            AlternateApprover = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Employee.AlternateApproverCode)

                            AlternateApproverText = AlternateApprover.ToString

                            SearchableComboBoxForm_Approver.SelectedValue = AlternateApprover.Code

                        Catch ex As Exception
                            AlternateApprover = Nothing
                            AlternateApproverText = "No Alternate Approver Selected"
                        End Try

                        Try

                            Supervisor = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Employee.SupervisorEmployeeCode)

                            SupervisorText = Supervisor.ToString

                            If SearchableComboBoxForm_Approver.HasASelectedValue = False Then

                                SearchableComboBoxForm_Approver.SelectedValue = Supervisor.Code

                            End If

                        Catch ex As Exception
                            Supervisor = Nothing
                            SupervisorText = "No Supervisor Selected"
                        End Try

                        LabelForm_Supervisor.Text = SupervisorText
                        LabelForm_AlternateApprover.Text = AlternateApproverText

                        CheckBoxForm_IncludeReceipts.Checked = True

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Error loading employee information.")

                        Me.DialogResult = Windows.Forms.DialogResult.Cancel
                        Me.Close()

                    End If

                End Using

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Submit_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Submit.Click

            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                _ApproverCode = SearchableComboBoxForm_Approver.GetSelectedValue
                _IncludeReceiptsInEmailAndAlert = CheckBoxForm_IncludeReceipts.Checked

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
