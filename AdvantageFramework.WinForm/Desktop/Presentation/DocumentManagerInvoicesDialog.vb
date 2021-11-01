Namespace Desktop.Presentation

    Public Class DocumentManagerInvoicesDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum InvoiceTypes
            ARInvoices
            APInvoices
        End Enum

#End Region

#Region " Variables "

        Private _InvoiceType As InvoiceTypes = InvoiceTypes.APInvoices
        Private _IsProofHQEnabled As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(InvoiceType As InvoiceTypes)

            ' This call is required by the designer.
            InitializeComponent()

            _InvoiceType = InvoiceType

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim Documents As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing

            If SearchableComboBoxForm_Criteria.HasASelectedValue Then

                If _InvoiceType = InvoiceTypes.APInvoices Then

                    Documents = AdvantageFramework.DocumentManager.LoadAccountPayableInvoiceDocumentsByVendor(Me.Session, SearchableComboBoxForm_Criteria.GetSelectedValue)

                ElseIf _InvoiceType = InvoiceTypes.ARInvoices Then

                    Documents = AdvantageFramework.DocumentManager.LoadAccountReceivableInvoiceDocumentsByClient(Me.Session, SearchableComboBoxForm_Criteria.GetSelectedValue)

                End If

            Else

                Documents = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            DataGridViewForm_Documents.DataSource = Documents

            If _IsProofHQEnabled Then

                DataGridViewForm_Documents.OptionsBehavior.Editable = True

                For Each GridColumn In DataGridViewForm_Documents.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    If GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.ProofHQUrl.ToString Then

                        GridColumn.OptionsColumn.AllowEdit = True
                        GridColumn.Visible = True

                    Else

                        GridColumn.OptionsColumn.AllowEdit = False

                    End If

                Next

            Else

                DataGridViewForm_Documents.OptionsBehavior.Editable = False

                If DataGridViewForm_Documents.Columns(AdvantageFramework.DocumentManager.Classes.Document.Properties.ProofHQUrl.ToString) IsNot Nothing Then

                    DataGridViewForm_Documents.Columns(AdvantageFramework.DocumentManager.Classes.Document.Properties.ProofHQUrl.ToString).Visible = False

                End If

            End If

            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.DocumentManager.Classes.Document.Properties.InvoiceDate.ToString)

            DataGridViewForm_Documents.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Download.Enabled = DataGridViewForm_Documents.HasASelectedRow

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(InvoiceType As InvoiceTypes) As System.Windows.Forms.DialogResult

            'objects
            Dim DocumentManagerInvoicesDialog As AdvantageFramework.Desktop.Presentation.DocumentManagerInvoicesDialog = Nothing

            DocumentManagerInvoicesDialog = New AdvantageFramework.Desktop.Presentation.DocumentManagerInvoicesDialog(InvoiceType)

            ShowFormDialog = DocumentManagerInvoicesDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub DocumentManagerInvoicesDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Download.Image = AdvantageFramework.My.Resources.DownloadDocument

            DataGridViewForm_Documents.ControlType = WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            DataGridViewForm_Documents.OptionsBehavior.Editable = False

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            DataGridViewForm_Documents.ClearDatasource(New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document))

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _IsProofHQEnabled = AdvantageFramework.ProofHQ.IsProofHQEnabled(DataContext)

                If _IsProofHQEnabled Then

                    DataGridViewForm_Documents.OptionsBehavior.Editable = True

                    For Each GridColumn In DataGridViewForm_Documents.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        If GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.ProofHQUrl.ToString Then

                            GridColumn.OptionsColumn.AllowEdit = True
                            GridColumn.Visible = True

                        Else

                            GridColumn.OptionsColumn.AllowEdit = False

                        End If

                    Next

                Else

                    DataGridViewForm_Documents.OptionsBehavior.Editable = False

                    If DataGridViewForm_Documents.Columns(AdvantageFramework.DocumentManager.Classes.Document.Properties.ProofHQUrl.ToString) IsNot Nothing Then

                        DataGridViewForm_Documents.Columns(AdvantageFramework.DocumentManager.Classes.Document.Properties.ProofHQUrl.ToString).Visible = False

                    End If

                End If

            End Using

            DataGridViewForm_Documents.MakeColumnVisible(AdvantageFramework.DocumentManager.Classes.Document.Properties.InvoiceDate.ToString)

            SearchableComboBoxForm_Criteria.ExtraComboBoxItem = WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect

            If _InvoiceType = InvoiceTypes.APInvoices Then

                LabelForm_Criteria.Text = "Vendor:"
                SearchableComboBoxForm_Criteria.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.Vendor

            ElseIf _InvoiceType = InvoiceTypes.ARInvoices Then

                LabelForm_Criteria.Text = "Client:"
                SearchableComboBoxForm_Criteria.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.Client

            End If

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If _InvoiceType = InvoiceTypes.APInvoices Then

                        SearchableComboBoxForm_Criteria.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadCore(AdvantageFramework.Database.Procedures.Vendor.Load(DbContext))

                    ElseIf _InvoiceType = InvoiceTypes.ARInvoices Then

                        SearchableComboBoxForm_Criteria.DataSource = AdvantageFramework.Database.Procedures.Client.LoadCore(AdvantageFramework.Database.Procedures.Client.Load(DbContext))

                    End If

                End Using

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub DocumentManagerInvoicesDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewForm_Documents_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Documents.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub SearchableComboBoxForm_Criteria_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_Criteria.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                LoadGrid()

            End If

        End Sub
        Private Sub ButtonItemActions_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Download.Click

            'objects
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing

            If DataGridViewForm_Documents.HasASelectedRow Then

                Try

                    Documents = DataGridViewForm_Documents.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DocumentManager.Classes.Document).Select(Function(Entity) Entity.GetDocumentEntity).ToList

                Catch ex As Exception
                    Documents = New Generic.List(Of AdvantageFramework.Database.Entities.Document)
                End Try

                If Documents IsNot Nothing AndAlso Documents.Count > 0 Then

                    AdvantageFramework.WinForm.Presentation.SaveDocument(Me.Session, Documents, False, Nothing)

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace