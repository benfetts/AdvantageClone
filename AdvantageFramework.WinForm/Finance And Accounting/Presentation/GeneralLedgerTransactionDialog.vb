Namespace FinanceAndAccounting.Presentation

    Public Class GeneralLedgerTransactionDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _Transaction As Integer = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal Transaction As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Transaction = Transaction

        End Sub
        Private Sub LoadTransactionDetail()

            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetailList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerDetail) = Nothing
            Dim GeneralLedgerTransactionsList As Generic.List(Of AdvantageFramework.Database.Classes.GeneralLedgerTransaction) = Nothing
            Dim ControlAmount As Decimal = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                GeneralLedger = AdvantageFramework.Database.Procedures.GeneralLedger.LoadByTransaction(DbContext, _Transaction)

                If GeneralLedger IsNot Nothing Then

                    TextBoxPanel_Transaction.Text = GeneralLedger.Transaction
                    TextBoxPanel_Source.Text = GeneralLedger.GLSourceCode
                    TextBoxPanel_CreatedBy.Text = GeneralLedger.UserCode
                    TextBoxPanel_PostPeriod.Text = GeneralLedger.PostPeriodCode
                    TextBoxPanel_TransactionDate.Text = GeneralLedger.EnteredDate
                    TextBoxPanel_Description.Text = GeneralLedger.Description
                    CheckBoxPanel_Posted.Checked = If(GeneralLedger.PostedDate IsNot Nothing, True, False)

                End If

                GeneralLedgerDetailList = (From GeneralLedgerDetail In AdvantageFramework.Database.Procedures.GeneralLedgerDetail.LoadByTransaction(DbContext, _Transaction)
                                           Select GeneralLedgerDetail).ToList

                GeneralLedgerTransactionsList = New Generic.List(Of AdvantageFramework.Database.Classes.GeneralLedgerTransaction)

                GeneralLedgerTransactionsList.AddRange(From Entity In GeneralLedgerDetailList
                                                       Select New AdvantageFramework.Database.Classes.GeneralLedgerTransaction(Entity, Entity.GeneralLedgerAccount.Description))

                Try

                    ControlAmount = GeneralLedgerDetailList.Where(Function(GLD) GLD.DebitAmount > 0).Sum(Function(GLD) GLD.DebitAmount)

                Catch ex As Exception
                    ControlAmount = 0
                End Try

                NumericInputPanel_ControlAmount.SetFormat("c2")
                NumericInputPanel_ControlAmount.EditValue = ControlAmount 'Format(ControlAmount, "#0.00")

                DataGridViewPanel_TransactionDetails.DataSource = GeneralLedgerTransactionsList

                DataGridViewPanel_TransactionDetails.CurrentView.BestFitColumns()

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal Transaction As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim GeneralLedgerDrillDown As AdvantageFramework.FinanceAndAccounting.Presentation.GeneralLedgerTransactionDialog = Nothing

            GeneralLedgerDrillDown = New AdvantageFramework.FinanceAndAccounting.Presentation.GeneralLedgerTransactionDialog(Transaction)

            ShowFormDialog = GeneralLedgerDrillDown.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub GeneralLedgerTransactionDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DataGridViewPanel_TransactionDetails.MultiSelect = False

            NumericInputPanel_ControlAmount.Properties.ReadOnly = True

            LoadTransactionDetail()

        End Sub
        Private Sub DataGridViewPanel_TransactionDetails_CustomDrawCellEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewPanel_TransactionDetails.CustomDrawCellEvent

            If e.Column.FieldName = AdvantageFramework.Database.Classes.GeneralLedgerTransaction.Properties.CreditAmount.ToString OrElse _
                e.Column.FieldName = AdvantageFramework.Database.Classes.GeneralLedgerTransaction.Properties.DebitAmount.ToString Then

                If e.CellValue < 0 Then

                    e.Appearance.ForeColor = Drawing.Color.Red

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonForm_Close.Click

            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace