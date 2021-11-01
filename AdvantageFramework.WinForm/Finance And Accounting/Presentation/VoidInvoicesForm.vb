Namespace FinanceAndAccounting.Presentation

    Public Class VoidInvoicesForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewForm_ClientInvoices.DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.AccountReceivableClientInvoicesForVoid) _
                                                    (String.Format("exec advsp_ar_select_client_invoices_for_void '{0}', '{1}'", Session.User.EmployeeCode, Session.User.UserCode)).ToList

                DataGridViewForm_ClientInvoices.SetBookmarkColumnIndex(0)

                DataGridViewForm_ClientInvoices.CurrentView.BestFitColumns()

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim VoidInvoicesForm As AdvantageFramework.FinanceAndAccounting.Presentation.VoidInvoicesForm = Nothing

            VoidInvoicesForm = New AdvantageFramework.FinanceAndAccounting.Presentation.VoidInvoicesForm()

            VoidInvoicesForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub VoidInvoicesForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage

            Me.ByPassUserEntryChanged = True

            LoadGrid()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Dim PostPeriodCode As String = Nothing
            Dim VoidComment As String = Nothing
            Dim ErrorMessage As String = Nothing
            Dim InvoiceNumber As Integer = 0
            Dim ClientName As String = Nothing
            Dim InvoicePostPeriodCode As String = Nothing
            Dim HasClosedJob As Integer = 0
            Dim AllowContinue As Boolean = True
            Dim AvaTaxPosted As Boolean = False
            Dim IsQuickBooksEnabled As Boolean = False
            Dim AccountReceivables As Generic.List(Of AdvantageFramework.Database.Entities.AccountReceivable) = Nothing

            If DataGridViewForm_ClientInvoices.HasOnlyOneSelectedRow Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    IsQuickBooksEnabled = AdvantageFramework.Quickbooks.IsQuickBooksEnabled(DbContext)

                    ButtonItemActions_Save.Enabled = False

                    Me.ShowWaitForm("Please wait...")

                    InvoiceNumber = DataGridViewForm_ClientInvoices.GetFirstSelectedRowBookmarkValue
                    ClientName = DataGridViewForm_ClientInvoices.CurrentView.GetRowCellValue(DataGridViewForm_ClientInvoices.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.AccountReceivableClientInvoicesForVoid.Properties.ClientName.ToString)
                    InvoicePostPeriodCode = DataGridViewForm_ClientInvoices.CurrentView.GetRowCellValue(DataGridViewForm_ClientInvoices.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.AccountReceivableClientInvoicesForVoid.Properties.PostPeriodCode.ToString)
                    AvaTaxPosted = DataGridViewForm_ClientInvoices.CurrentView.GetRowCellValue(DataGridViewForm_ClientInvoices.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.AccountReceivableClientInvoicesForVoid.Properties.AvaTaxPosted.ToString)

                    HasClosedJob = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec [advsp_ar_invoice_has_closed_job] {0}", InvoiceNumber)).FirstOrDefault

                    If HasClosedJob = 1 Then

                        If AdvantageFramework.WinForm.MessageBox.Show("This invoice includes job/components that are closed.  Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo, MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.No Then

                            AllowContinue = False

                        End If

                    End If

                    If AllowContinue AndAlso AdvantageFramework.FinanceAndAccounting.Presentation.VoidInvoiceDialog.ShowFormDialog(PostPeriodCode, VoidComment, InvoiceNumber, ClientName, InvoicePostPeriodCode) = Windows.Forms.DialogResult.OK Then

                        ErrorMessage = DbContext.Database.SqlQuery(Of String)(String.Format("exec [advsp_ar_void_client_invoice] {0}, '{1}','{2}','{3}'", InvoiceNumber, PostPeriodCode, Me.Session.UserCode, VoidComment.Replace("'", "''"))).FirstOrDefault

                        If ErrorMessage.StartsWith("INFO:") Then

                            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage.Substring(5))

                            LoadGrid()

                        ElseIf ErrorMessage <> "" Then

                            ErrorMessage += vbCrLf & "Failed to Void Invoice. Please contact software support."

                            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                        Else

                            If IsQuickBooksEnabled Then

                                AccountReceivables = (From Entity In AdvantageFramework.Database.Procedures.AccountReceivable.Load(DbContext)
                                                      Where Entity.InvoiceNumber = InvoiceNumber
                                                      Select Entity).ToList

                                For Each AR In AccountReceivables

                                    If String.IsNullOrWhiteSpace(AR.QuickbooksInvoiceID) = False Then

                                        If AdvantageFramework.Quickbooks.VoidInvoice(Session, InvoiceNumber, AR.SequenceNumber, AR.Type, ErrorMessage) = False Then

                                            AdvantageFramework.WinForm.MessageBox.Show("Could not void invoice:" & InvoiceNumber & " in Quickbooks.")

                                        End If

                                    End If

                                Next

                            End If

                            If AvaTaxPosted AndAlso AdvantageFramework.AvaTax.VoidInvoice(DbContext, InvoiceNumber) = False Then

                                AdvantageFramework.WinForm.MessageBox.Show(InvoiceNumber.ToString & " failed to post to AvaTax.  Please review your AvaTax console.")

                            End If

                            LoadGrid()

                        End If

                    End If

                    Me.CloseWaitForm()

                    ButtonItemActions_Save.Enabled = True

                End Using

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
