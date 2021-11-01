Namespace Billing.Presentation

    Public Class BillingCommandCenterMediaBillingHistoryDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _OrderNumber As Integer = Nothing
        Private _LineNumbers As IEnumerable(Of Integer) = Nothing
        Private _OrderDescription As String = Nothing
        Private _IsMediaHistory As Boolean = True
        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentDescription As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal OrderNumber As Integer, ByVal LineNumbers As IEnumerable(Of Integer), ByVal OrderDescription As String)

            ' This call is required by the designer.
            InitializeComponent()

            _OrderNumber = OrderNumber
            _LineNumbers = LineNumbers
            _OrderDescription = OrderDescription

        End Sub
        Private Sub New(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal JobDescription As String, JobComponentDescription As String)

            ' This call is required by the designer.
            InitializeComponent()

            _JobNumber = JobNumber
            _JobComponentNumber = JobComponentNumber
            _JobDescription = JobDescription
            _JobComponentDescription = JobComponentDescription

            _IsMediaHistory = False

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Export.Enabled = MediaBillingHistoryControl_BillingInvoices.CanExportSelectedTab

            RibbonBarOptions_Documents.Visible = MediaBillingHistoryControl_BillingInvoices.SelectedTabIsDocumentsTab
            RibbonBarOptions_Filter.Visible = MediaBillingHistoryControl_BillingInvoices.SelectedTabIsDocumentsTab

            RibbonBarOptions_Documents.Left = 114
            RibbonBarOptions_Filter.Left = 183

            ButtonItemDocuments_Download.Enabled = If(MediaBillingHistoryControl_BillingInvoices.DocumentManagerControlDocuments_InvoiceDocuments.HasOnlyOneSelectedDocument, Not MediaBillingHistoryControl_BillingInvoices.DocumentManagerControlDocuments_InvoiceDocuments.IsSelectedDocumentAURL, MediaBillingHistoryControl_BillingInvoices.DocumentManagerControlDocuments_InvoiceDocuments.HasASelectedDocument)

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal OrderNumber As Integer, ByVal LineNumbers As IEnumerable(Of Integer),
                                              ByVal OrderDescription As String) As System.Windows.Forms.DialogResult

            'objects
            Dim BillingCommandCenterMediaBillingHistoryDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterMediaBillingHistoryDialog = Nothing

            BillingCommandCenterMediaBillingHistoryDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterMediaBillingHistoryDialog(OrderNumber, LineNumbers, OrderDescription)

            ShowFormDialog = BillingCommandCenterMediaBillingHistoryDialog.ShowDialog()

        End Function
        Public Shared Function ShowFormDialog(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                              ByVal JobDescription As String, JobComponentDescription As String) As System.Windows.Forms.DialogResult

            'objects
            Dim BillingCommandCenterMediaBillingHistoryDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterMediaBillingHistoryDialog = Nothing

            BillingCommandCenterMediaBillingHistoryDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterMediaBillingHistoryDialog(JobNumber, JobComponentNumber, JobDescription, JobComponentDescription)

            ShowFormDialog = BillingCommandCenterMediaBillingHistoryDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCommandCenterBillingHistoryDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage

            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument

            ButtonItemFilter_All.Image = AdvantageFramework.My.Resources.TableSelectedAllImage
            ButtonItemFilter_SelectedLineItem.Image = AdvantageFramework.My.Resources.TableSelectedRowImage

            ButtonItemFilter_SelectedLineItem.Checked = True

            If _IsMediaHistory Then

                Me.Text = "Media Billing History"
                MediaBillingHistoryControl_BillingInvoices.LoadControl(_OrderNumber, _LineNumbers, _OrderDescription)

            Else

                Me.Text = "Production Billing History"
                MediaBillingHistoryControl_BillingInvoices.LoadControl(_JobNumber, _JobComponentNumber, _JobDescription, _JobComponentDescription)

            End If

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            MediaBillingHistoryControl_BillingInvoices.ExportData(Me.DefaultLookAndFeel, Me.Name.Replace("Dialog", ""))

        End Sub
        Private Sub ButtonItemFilter_All_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_All.CheckedChanged

            If Me.FormShown AndAlso ButtonItemFilter_All.Checked Then

                ButtonItemFilter_SelectedLineItem.Checked = False

                MediaBillingHistoryControl_BillingInvoices.RefreshDocumentsTab(True)

            End If

        End Sub
        Private Sub ButtonItemFilter_SelectedLineItem_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_SelectedLineItem.CheckedChanged

            If Me.FormShown AndAlso ButtonItemFilter_SelectedLineItem.Checked Then

                ButtonItemFilter_All.Checked = False

                MediaBillingHistoryControl_BillingInvoices.RefreshDocumentsTab(False)

            End If

        End Sub
        Private Sub ButtonItemExpenseReceipts_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            MediaBillingHistoryControl_BillingInvoices.DownloadSelectedDocument()

        End Sub
        Private Sub MediaBillingHistoryControl_BillingInvoices_SelectedTabChanged() Handles MediaBillingHistoryControl_BillingInvoices.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub MediaBillingHistoryControl_BillingInvoices_SelectedDocumentChanged() Handles MediaBillingHistoryControl_BillingInvoices.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace