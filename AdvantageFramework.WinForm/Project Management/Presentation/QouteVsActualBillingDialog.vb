Namespace ProjectManagement.Presentation

    Public Class QuoteVsActualBillingDialog

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

            'objects
            Dim QouteVsActualInvoiceBillingSummaryList As Generic.List(Of AdvantageFramework.ProjectManagement.Classes.QouteVsActualInvoiceBillingSummary) = Nothing

            Using ObjectContext As New AdvantageFramework.Database.ObjectContext(Session.ConnectionString, Session.UserCode)

                QouteVsActualInvoiceBillingSummaryList = New Generic.List(Of AdvantageFramework.ProjectManagement.Classes.QouteVsActualInvoiceBillingSummary)

                QouteVsActualInvoiceBillingSummaryList.AddRange(AdvantageFramework.ProjectManagement.GetQvABilling(ObjectContext, _JobNumber, _JobComponentNumber, "job", 0, 0))

                DataGridViewPanel_Invoices.DataSource = QouteVsActualInvoiceBillingSummaryList.OrderBy(Function(Entity) Entity.AR_INV_NBR)

            End Using

            DataGridViewPanel_Invoices.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

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

                DocumentLevelSettingList = (From Entity In DataGridViewPanel_Invoices.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.ProjectManagement.Classes.QouteVsActualInvoiceBillingSummary).ToList _
                                            Select New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice) With {.AccountReceivableInvoiceNumber = Entity.AR_INV_NBR, _
                                                                                                                                                                                                   .AccountReceivableSequenceNumber = Entity.AR_INV_SEQ, _
                                                                                                                                                                                                   .AccountReceivableType = Entity.AR_TYPE}).ToList

            Else

                DocumentLevelSettingList = (From Entity In DataGridViewPanel_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.ProjectManagement.Classes.QouteVsActualInvoiceBillingSummary).ToList _
                                            Select New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice) With {.AccountReceivableInvoiceNumber = Entity.AR_INV_NBR, _
                                                                                                                                                                                                   .AccountReceivableSequenceNumber = Entity.AR_INV_SEQ, _
                                                                                                                                                                                                   .AccountReceivableType = Entity.AR_TYPE}).ToList

            End If

            DocumentManagerControlDocuments_InvoiceDocuments.Enabled = DocumentManagerControlDocuments_InvoiceDocuments.LoadControl(Database.Entities.DocumentLevel.AccountReceivableInvoice, DocumentLevelSettingList, WinForm.Presentation.Controls.DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default)

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, _
                                              ByVal JobDescription As String, JobComponentDescription As String) As System.Windows.Forms.DialogResult

            'objects
            Dim QuoteVsActualBillingDialog As AdvantageFramework.ProjectManagement.Presentation.QuoteVsActualBillingDialog = Nothing

            QuoteVsActualBillingDialog = New AdvantageFramework.ProjectManagement.Presentation.QuoteVsActualBillingDialog(JobNumber, JobComponentNumber, JobDescription, JobComponentDescription)

            ShowFormDialog = QuoteVsActualBillingDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub QuoteVsActualBillingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage

            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument

            ButtonItemFilter_All.Image = AdvantageFramework.My.Resources.TableSelectedAllImage
            ButtonItemFilter_SelectedLineItem.Image = AdvantageFramework.My.Resources.TableSelectedRowImage

            ButtonItemFilter_SelectedLineItem.Checked = True

            LabelPanel_JobValue.Text = _JobNumber.ToString.PadLeft(6, "0") & " - " & _JobDescription
            LabelPanel_JobComponentValue.Text = _JobComponentNumber.ToString.PadLeft(3, "0") & " - " & _JobComponentDescription

            DataGridViewPanel_Invoices.MultiSelect = False

            LoadGrid()

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewPanel_Invoices.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("Dialog", ""), UseLandscape:=True)

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
        Private Sub TabControlPanel_BillingSummary_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlPanel_BillingSummary.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub TabControlPanel_BillingSummary_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlPanel_BillingSummary.SelectedTabChanging

            If e.NewTab.Equals(TabItemBillingSummary_DocumentsTab) Then

                LoadDocumentsTab()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace