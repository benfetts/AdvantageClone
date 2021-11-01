Namespace FinanceAndAccounting.Presentation

    Public Class ClientCashReceiptClientSearchDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ClientCode As String)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            RadioButtonForm_InvoiceNumber.ByPassUserEntryChanged = True
            SearchableComboBoxForm_Criteria.ByPassUserEntryChanged = True

            _ClientCode = ClientCode

        End Sub
        Private Sub LoadComboBox()

            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If Me.Session IsNot Nothing Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    BindingSource = New System.Windows.Forms.BindingSource

                    If RadioButtonForm_InvoiceNumber.Checked Then

                        BindingSource.DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptClientSearchInvoice) _
                                (String.Format("exec advsp_clientcashreceipt_search_invoices_by_client '{0}'", Session.UserCode)).ToList

                        SearchableComboBoxForm_Criteria.Properties.NullText = "Select Invoice Number"
                        SearchableComboBoxForm_Criteria.DisplayName = "Invoice Number"

                    End If

                    SearchableComboBoxForm_Criteria.EditValue = ""
                    SearchableComboBoxForm_Criteria.Text = Nothing
                    SearchableComboBoxForm_Criteria.Properties.DisplayMember = "ClientName"
                    SearchableComboBoxForm_Criteria.Properties.ValueMember = "ARInvoiceNumber"
                    SearchableComboBoxForm_Criteria.DataSource = BindingSource

                End Using

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ClientCode As String) As Windows.Forms.DialogResult

            'objects
            Dim ClientCashReceiptClientSearchDialog As AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptClientSearchDialog = Nothing

            ClientCashReceiptClientSearchDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptClientSearchDialog(ClientCode)

            ShowFormDialog = ClientCashReceiptClientSearchDialog.ShowDialog()

            ClientCode = ClientCashReceiptClientSearchDialog.ClientCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientCashReceiptClientSearchDialog_Load(sender As Object, e As EventArgs) Handles Me.Load



        End Sub
        Private Sub ClientCashReceiptClientSearchDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadComboBox()

            SearchableComboBoxViewCriteria_Criteria.Focus()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Dim ErrorMessage As String = Nothing
            Dim ClientCashReceiptClientSearchInvoice As AdvantageFramework.CashReceipts.Classes.ClientCashReceiptClientSearchInvoice = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim ClientCashReceiptClientSearchInvoices As System.Linq.EnumerableQuery(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptClientSearchInvoice) = Nothing

            If SearchableComboBoxForm_Criteria.HasASelectedValue Then

                BindingSource = CType(SearchableComboBoxForm_Criteria.DataSource, System.Windows.Forms.BindingSource)

                ClientCashReceiptClientSearchInvoices = DirectCast(DirectCast(BindingSource.List, System.Windows.Forms.BindingSource).List.AsQueryable, System.Linq.EnumerableQuery(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptClientSearchInvoice))

                Try
                    ClientCashReceiptClientSearchInvoice = ClientCashReceiptClientSearchInvoices.Where(Function(Entity) Entity.ARInvoiceNumber = SearchableComboBoxForm_Criteria.SelectedValue).FirstOrDefault
                Catch ex As Exception
                    ClientCashReceiptClientSearchInvoice = Nothing
                End Try

                If ClientCashReceiptClientSearchInvoice IsNot Nothing Then

                    _ClientCode = ClientCashReceiptClientSearchInvoice.ClientCode

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            Else

                If RadioButtonForm_InvoiceNumber.Checked Then

                    ErrorMessage = "Please select a valid invoice number."

                End If

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub RadioButtonForm_MediaOrder_CheckedChanged(sender As Object, e As EventArgs)

            If Me.FormShown Then

                LoadComboBox()

            End If

        End Sub
        Private Sub RadioButtonForm_PurchaseOrder_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_InvoiceNumber.CheckedChanged

            If Me.FormShown Then

                LoadComboBox()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace