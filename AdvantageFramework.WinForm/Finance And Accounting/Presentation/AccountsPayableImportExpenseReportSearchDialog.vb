Namespace FinanceAndAccounting.Presentation

    Public Class AccountsPayableImportExpenseReportSearchDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _OfficeCode As String = Nothing
        Private _DepartmentTeamCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property OfficeCode As String
            Get
                OfficeCode = _OfficeCode
            End Get
        End Property
        Private ReadOnly Property DepartmentTeamCode As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal OfficeCode As String, ByVal DepartmentTeamCode As String)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.ShowUnsavedChangesOnFormClosing = False

            _OfficeCode = OfficeCode
            _DepartmentTeamCode = DepartmentTeamCode

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef OfficeCode As String, ByRef DepartmentTeamCode As String) As Windows.Forms.DialogResult

            'objects
            Dim AccountsPayableImportExpenseReportSearchDialog As AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableImportExpenseReportSearchDialog = Nothing

            AccountsPayableImportExpenseReportSearchDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableImportExpenseReportSearchDialog(OfficeCode, DepartmentTeamCode)

            ShowFormDialog = AccountsPayableImportExpenseReportSearchDialog.ShowDialog()

            OfficeCode = AccountsPayableImportExpenseReportSearchDialog.OfficeCode
            DepartmentTeamCode = AccountsPayableImportExpenseReportSearchDialog.DepartmentTeamCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountsPayableImportExpenseReportSearchDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SearchableComboBoxForm_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Session).ToList
                SearchableComboBoxForm_DepartmentTeam.DataSource = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext).ToList

            End Using

            If _OfficeCode IsNot Nothing Then

                SearchableComboBoxForm_Office.SelectedValue = _OfficeCode
                RadioButtonOffice_Selected.Checked = True

            End If

            If _DepartmentTeamCode IsNot Nothing Then

                SearchableComboBoxForm_DepartmentTeam.SelectedValue = _DepartmentTeamCode
                RadioButtonDept_Selected.Checked = True

            End If

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Dim ErrorMessage As String = ""

            If Me.Validator Then

                If RadioButtonOffice_All.Checked Then

                    _OfficeCode = Nothing

                Else

                    _OfficeCode = SearchableComboBoxForm_Office.GetSelectedValue

                End If

                If RadioButtonDept_All.Checked Then

                    _DepartmentTeamCode = Nothing

                Else

                    _DepartmentTeamCode = SearchableComboBoxForm_DepartmentTeam.GetSelectedValue

                End If

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    If LastFailedValidationResult.Validator.ErrorMessage.Contains("Enum Data") OrElse LastFailedValidationResult.Validator.ErrorMessage.Trim = "is required." Then

                        ErrorMessage &= "Please select valid criteria." & vbCrLf

                    Else

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    End If

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub RadioButtonOffice_All_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonOffice_All.CheckedChanged

            SearchableComboBoxForm_Office.Visible = Not RadioButtonOffice_All.Checked
            SearchableComboBoxForm_Office.SetRequired(Not RadioButtonOffice_All.Checked)

        End Sub
        Private Sub RadioButtonDept_All_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonDept_All.CheckedChanged

            SearchableComboBoxForm_DepartmentTeam.Visible = Not RadioButtonDept_All.Checked
            SearchableComboBoxForm_DepartmentTeam.SetRequired(Not RadioButtonDept_All.Checked)

        End Sub

#End Region

#End Region

    End Class

End Namespace