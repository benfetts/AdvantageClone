Imports System.ComponentModel

Namespace FinanceAndAccounting.Presentation

    Public Class AccountsPayableDenyExpenseReportDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _InvoiceNumbers As Integer() = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal InvoiceNumbers As Integer())

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _InvoiceNumbers = InvoiceNumbers

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal InvoiceNumbers As Integer()) As Windows.Forms.DialogResult

            'objects
            Dim AccountsPayableDenyExpenseReportDialog As AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableDenyExpenseReportDialog = Nothing

            AccountsPayableDenyExpenseReportDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableDenyExpenseReportDialog(InvoiceNumbers)

            ShowFormDialog = AccountsPayableDenyExpenseReportDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountsPayableDenyExpenseReportDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim ExpenseSummaryList As Generic.List(Of AdvantageFramework.Database.Views.ExpenseSummary) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ExpenseSummaryList = (From Item In AdvantageFramework.Database.Procedures.ExpenseSummary.Load(DbContext)
                                      Where _InvoiceNumbers.Contains(Item.InvoiceNumber) = True
                                      Select Item).ToList

                For Each ExpenseSummary In ExpenseSummaryList

                    ExpenseSummary.IsApproved = AdvantageFramework.ExpenseReports.ApprovedFlag.Denied

                Next

                DataGridViewForm_ExpenseReports.DataSource = ExpenseSummaryList

                DataGridViewForm_ExpenseReports.CurrentView.BestFitColumns()

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim IsValid As Boolean = False
            Dim ErrorMessage As String = Nothing
            Dim ExpenseSummaryList As Generic.List(Of AdvantageFramework.Database.Views.ExpenseSummary) = Nothing

            If Me.Validator Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ExpenseSummaryList = DataGridViewForm_ExpenseReports.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Views.ExpenseSummary).ToList

                    AdvantageFramework.ExpenseReports.DenyExpenseReportsInAccounting(Me.Session, DbContext, ExpenseSummaryList, ErrorMessage)

                End Using

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_ExpenseReports_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ExpenseReports.DataSourceChangedEvent

            If DataGridViewForm_ExpenseReports.Columns IsNot Nothing AndAlso DataGridViewForm_ExpenseReports.Columns.Count > 0 Then

                DataGridViewForm_ExpenseReports.HideOrShowColumn(AdvantageFramework.Database.Views.ExpenseSummary.Properties.DocumentCount.ToString, False)
                DataGridViewForm_ExpenseReports.HideOrShowColumn(AdvantageFramework.Database.Views.ExpenseSummary.Properties.DetailDescription.ToString, False)
                DataGridViewForm_ExpenseReports.Columns(AdvantageFramework.Database.Views.ExpenseSummary.Properties.ApproverNotes.ToString).Caption = "Comments"

                For Each Column In DataGridViewForm_ExpenseReports.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)

                    If Column.FieldName <> AdvantageFramework.Database.Views.ExpenseSummary.Properties.ApproverNotes.ToString Then

                        Column.OptionsColumn.AllowEdit = False
                        Column.OptionsColumn.ReadOnly = True
                        Column.OptionsColumn.AllowFocus = False

                    End If

                Next

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace