Namespace Billing.Presentation

    Public Class BillingCommandCenterBillingHistoryDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentDescription As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal JobDescription As String, JobComponentDescription As String)

            ' This call is required by the designer.
            InitializeComponent()

            _JobNumber = JobNumber
            _JobComponentNumber = JobComponentNumber
            _JobDescription = JobDescription
            _JobComponentDescription = JobComponentDescription

        End Sub
        Private Sub LoadGrid()

            Using BCCObjectContext As New AdvantageFramework.BillingCommandCenter.Database.BCCObjectContext(Session.ConnectionString, Session.UserCode)

                DataGridViewPanel_Invoices.DataSource = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingHistoryComplexType.Load(BCCObjectContext, _JobNumber, _JobComponentNumber).ToList

            End Using

            DataGridViewPanel_Invoices.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Export.Enabled = (TabControlPanel_BillingSummary.SelectedTab Is TabItemBillingSummary_InvoicesTab) OrElse (TabControlPanel_BillingSummary.SelectedTab Is TabItemBillingSummary_JournalEntries)

            RibbonBarOptions_Documents.Visible = TabControlPanel_BillingSummary.SelectedTab.Equals(TabItemBillingSummary_DocumentsTab)
            RibbonBarOptions_Filter.Visible = TabControlPanel_BillingSummary.SelectedTab.Equals(TabItemBillingSummary_DocumentsTab)

            RibbonBarOptions_Documents.Left = 114
            RibbonBarOptions_Filter.Left = 183

            ButtonItemDocuments_Download.Enabled = DocumentManagerControlDocuments_InvoiceDocuments.HasASelectedDocument

        End Sub
        Private Sub LoadDocumentsTab()

            'objects
            Dim DocumentLevelSettingList As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing

            DocumentManagerControlDocuments_InvoiceDocuments.ClearControl()

            If ButtonItemFilter_All.Checked Then

                DocumentLevelSettingList = (From DLS In
                                            (From Entity In DataGridViewPanel_Invoices.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.ComplexTypes.BillingHistory)() _
                                             Select Entity.InvoiceNumber, _
                                                    Entity.InvoiceType).Distinct.ToList _
                                            Select New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice) With {.AccountReceivableInvoiceNumber = DLS.InvoiceNumber, _
                                                                                                                                                                                                   .AccountReceivableType = DLS.InvoiceType}).ToList

            Else

                DocumentLevelSettingList = (From DLS In
                                            (From Entity In DataGridViewPanel_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.ComplexTypes.BillingHistory)() _
                                             Select Entity.InvoiceNumber, _
                                                    Entity.InvoiceType).Distinct.ToList _
                                            Select New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice) With {.AccountReceivableInvoiceNumber = DLS.InvoiceNumber, _
                                                                                                                                                                                                   .AccountReceivableType = DLS.InvoiceType}).ToList

            End If

            DocumentManagerControlDocuments_InvoiceDocuments.Enabled = DocumentManagerControlDocuments_InvoiceDocuments.LoadControl(Database.Entities.DocumentLevel.AccountReceivableInvoice, DocumentLevelSettingList, WinForm.Presentation.Controls.DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default)

        End Sub
        Private Sub LoadJournalEntriesTab()

            Dim GLTransactions As IEnumerable(Of Integer) = Nothing

            GLTransactions = (From Entity In DataGridViewPanel_Invoices.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Database.ComplexTypes.BillingHistory).ToList
                              Where Entity.GLTransaction.HasValue
                              Select Entity.GLTransaction.Value).ToList

            Using BCCObjectContext As New AdvantageFramework.BillingCommandCenter.Database.BCCObjectContext(Session.ConnectionString, Session.UserCode)

                DataGridViewPanel_JournalEntries.DataSource = AdvantageFramework.BillingCommandCenter.GetJournalEntiresByTransactionList(BCCObjectContext, GLTransactions)

            End Using

            DataGridViewPanel_JournalEntries.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, _
                                              ByVal JobDescription As String, JobComponentDescription As String) As System.Windows.Forms.DialogResult

            'objects
            Dim BillingCommandCenterBillingHistoryDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterBillingHistoryDialog = Nothing

            BillingCommandCenterBillingHistoryDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterBillingHistoryDialog(JobNumber, JobComponentNumber, JobDescription, JobComponentDescription)

            ShowFormDialog = BillingCommandCenterBillingHistoryDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCommandCenterBillingHistoryDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage

            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument

            ButtonItemFilter_All.Image = AdvantageFramework.My.Resources.TableSelectedAllImage
            ButtonItemFilter_SelectedLineItem.Image = AdvantageFramework.My.Resources.TableSelectedRowImage

            ButtonItemFilter_SelectedLineItem.Checked = True

            LabelPanel_JobValue.Text = _JobNumber.ToString.PadLeft(6, "0") & " - " & _JobDescription
            LabelPanel_JobComponentValue.Text = _JobComponentNumber.ToString.PadLeft(3, "0") & " - " & _JobComponentDescription

            LoadGrid()

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            Try

                DataGridViewForm_Export.ClearGridCustomization()

                If TabControlPanel_BillingSummary.SelectedTab Is TabItemBillingSummary_InvoicesTab Then

                    DataGridViewForm_Export.DataSource = DataGridViewPanel_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.ComplexTypes.BillingHistory)().ToList
                    DataGridViewForm_Export.CurrentView.ViewCaption = DataGridViewPanel_Invoices.CurrentView.ViewCaption

                ElseIf TabControlPanel_BillingSummary.SelectedTab Is TabItemBillingSummary_JournalEntries Then

                    DataGridViewForm_Export.DataSource = DataGridViewPanel_JournalEntries.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JournalEntry)().ToList
                    DataGridViewForm_Export.CurrentView.ViewCaption = DataGridViewPanel_JournalEntries.CurrentView.ViewCaption

                End If

            Catch ex As Exception

            End Try

            DataGridViewForm_Export.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("Dialog", ""), UseLandscape:=True)

        End Sub
        Private Sub ButtonItemFilter_All_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_All.CheckedChanged

            If Me.FormShown AndAlso ButtonItemFilter_All.Checked Then

                ButtonItemFilter_SelectedLineItem.Checked = False

                LoadDocumentsTab()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemFilter_SelectedLineItem_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_SelectedLineItem.CheckedChanged

            If Me.FormShown AndAlso ButtonItemFilter_SelectedLineItem.Checked Then

                ButtonItemFilter_All.Checked = False

                LoadDocumentsTab()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemExpenseReceipts_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            DocumentManagerControlDocuments_InvoiceDocuments.DownloadSelectedDocument()

        End Sub
        Private Sub DataGridViewPanel_Invoices_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewPanel_Invoices.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If Not Me.IsFormClosing Then

                DataGridViewPanel_Invoices.CurrentView.OptionsView.ShowFooter = True

                'DataGridViewPanel_Invoices.CurrentView.OptionsView.EnableAppearanceOddRow = True
                'DataGridViewPanel_Invoices.CurrentView.Appearance.OddRow.BackColor = Drawing.Color.FromArgb(240, 240, 240)

                For Each GridColumn In DataGridViewPanel_Invoices.Columns

                    If GridColumn.ColumnType Is GetType(System.Decimal) OrElse _
                            GridColumn.ColumnType Is GetType(System.Nullable(Of Decimal)) Then

                        AdvantageFramework.Billing.Presentation.SetColumnAsSumColumn(DataGridViewPanel_Invoices, GridColumn.FieldName)

                    End If

                Next

            End If

        End Sub
        Private Sub TabControlPanel_BillingSummary_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlPanel_BillingSummary.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub TabControlPanel_BillingSummary_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlPanel_BillingSummary.SelectedTabChanging

            If e.NewTab.Equals(TabItemBillingSummary_DocumentsTab) Then

                LoadDocumentsTab()

            ElseIf e.NewTab.Equals(TabItemBillingSummary_JournalEntries) Then

                LoadJournalEntriesTab()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace