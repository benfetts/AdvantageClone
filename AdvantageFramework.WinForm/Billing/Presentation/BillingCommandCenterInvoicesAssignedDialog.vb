Namespace Billing.Presentation

    Public Class BillingCommandCenterInvoicesAssignedDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BillingUser As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal BillingUser As String)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _BillingUser = BillingUser

        End Sub
        Private Sub LoadInvoicesAssigned()

            Dim InvoiceAssignedList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssigned) = Nothing

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                InvoiceAssignedList = AdvantageFramework.BillingCommandCenter.GetInvoiceAssigned(BCCDbContext, _BillingUser).ToList

                DataGridViewJournalEntries_InvoicesAssigned.DataSource = InvoiceAssignedList

                If InvoiceAssignedList.Where(Function(IA) IA.CurrencyCode IsNot Nothing).Any = False Then

                    If DataGridViewJournalEntries_InvoicesAssigned.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssigned.Properties.CurrencyCode.ToString) IsNot Nothing Then

                        DataGridViewJournalEntries_InvoicesAssigned.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssigned.Properties.CurrencyCode.ToString).Visible = False

                    End If

                    If DataGridViewJournalEntries_InvoicesAssigned.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssigned.Properties.CurrencyRate.ToString) IsNot Nothing Then

                        DataGridViewJournalEntries_InvoicesAssigned.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssigned.Properties.CurrencyRate.ToString).Visible = False

                    End If

                    If DataGridViewJournalEntries_InvoicesAssigned.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssigned.Properties.CurrencyAmount.ToString) IsNot Nothing Then

                        DataGridViewJournalEntries_InvoicesAssigned.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssigned.Properties.CurrencyAmount.ToString).Visible = False

                    End If

                End If

                DataGridViewJournalEntries_InvoicesAssigned.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadInvoicesAssignedDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            If TabItem Is TabItemInvoicesAssigned_JournalEntries AndAlso TabItem.Tag = False Then

                LoadJournalEntries()

            End If

        End Sub
        Private Sub LoadJournalEntries()

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DataGridViewJournalEntries_JournalEntries.DataSource = AdvantageFramework.BillingCommandCenter.GetInvoiceAssignedJournalEntry(BCCDbContext, _BillingUser).ToList

                DataGridViewJournalEntries_JournalEntries.CurrentView.BestFitColumns()

            End Using

            TabItemInvoicesAssigned_JournalEntries.Tag = True

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal BillingUser As String) As System.Windows.Forms.DialogResult

            'objects
            Dim BillingCommandCenterInvoicesAssignedDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterInvoicesAssignedDialog = Nothing

            BillingCommandCenterInvoicesAssignedDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterInvoicesAssignedDialog(BillingUser)

            ShowFormDialog = BillingCommandCenterInvoicesAssignedDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCommandCenterInvoicesAssignedDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DataGridViewJournalEntries_JournalEntries.OptionsMenu.EnableColumnMenu = False
            DataGridViewJournalEntries_InvoicesAssigned.OptionsMenu.EnableColumnMenu = False

            LoadInvoicesAssigned()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub TabControlForm_InvoicesAssigned_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlForm_InvoicesAssigned.SelectedTabChanging

            If Session IsNot Nothing AndAlso e.NewTab IsNot Nothing Then

                LoadInvoicesAssignedDetails(e.NewTab)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace