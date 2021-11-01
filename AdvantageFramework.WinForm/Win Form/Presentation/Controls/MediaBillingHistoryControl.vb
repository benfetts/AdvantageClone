Namespace WinForm.Presentation.Controls

    Public Class MediaBillingHistoryControl

        Public Event SelectedTabChanged()
        Public Event SelectedDocumentChanged()

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum HistoryType
            Production
            Media
        End Enum

#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _OrderNumber As Integer = Nothing
        Private _LineNumbers As IEnumerable(Of Integer) = Nothing
        Private _OrderDescription As String = Nothing
        Private _FilterAllChecked As Boolean = False
        Private _HistoryType As HistoryType = HistoryType.Media
        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentDescription As String = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property CanExportSelectedTab As Boolean
            Get
                CanExportSelectedTab = TabControlControl_BillingHistory.SelectedTab.Equals(TabItemBillingSummary_InvoicesTab) OrElse TabControlControl_BillingHistory.SelectedTab.Equals(TabItemBillingSummary_JournalEntries)
            End Get
        End Property
        Public ReadOnly Property SelectedTabIsDocumentsTab As Boolean
            Get
                SelectedTabIsDocumentsTab = TabControlControl_BillingHistory.SelectedTab.Equals(TabItemBillingSummary_DocumentsTab)
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then


                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadGrid()

            Dim MediaBillingHistoryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.MediaBillingHistory) = Nothing
            Dim BillingHistoryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory) = Nothing

            If _HistoryType = HistoryType.Media Then

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    MediaBillingHistoryList = AdvantageFramework.BillingCommandCenter.GetMediaBillingHistory(BCCDbContext, _OrderNumber, _LineNumbers).ToList

                    DataGridViewInvoice_Invoices.DataSource = MediaBillingHistoryList

                    If MediaBillingHistoryList.Where(Function(IA) IA.CurrencyCode IsNot Nothing).Any = False Then

                        If DataGridViewInvoice_Invoices.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaBillingHistory.Properties.CurrencyCode.ToString) IsNot Nothing Then

                            DataGridViewInvoice_Invoices.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaBillingHistory.Properties.CurrencyCode.ToString).Visible = False

                        End If

                        If DataGridViewInvoice_Invoices.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaBillingHistory.Properties.CurrencyRate.ToString) IsNot Nothing Then

                            DataGridViewInvoice_Invoices.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaBillingHistory.Properties.CurrencyRate.ToString).Visible = False

                        End If

                        If DataGridViewInvoice_Invoices.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaBillingHistory.Properties.CurrencyAmount.ToString) IsNot Nothing Then

                            DataGridViewInvoice_Invoices.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaBillingHistory.Properties.CurrencyAmount.ToString).Visible = False

                        End If

                    End If

                End Using

            Else

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    BillingHistoryList = AdvantageFramework.BillingCommandCenter.GetBillingHistory(BCCDbContext, _JobNumber, _JobComponentNumber).ToList

                    DataGridViewInvoice_Invoices.DataSource = BillingHistoryList

                    If BillingHistoryList.Where(Function(IA) IA.CurrencyCode IsNot Nothing).Any = False Then

                        If DataGridViewInvoice_Invoices.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory.Properties.CurrencyCode.ToString) IsNot Nothing Then

                            DataGridViewInvoice_Invoices.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory.Properties.CurrencyCode.ToString).Visible = False

                        End If

                        If DataGridViewInvoice_Invoices.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory.Properties.CurrencyRate.ToString) IsNot Nothing Then

                            DataGridViewInvoice_Invoices.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory.Properties.CurrencyRate.ToString).Visible = False

                        End If

                        If DataGridViewInvoice_Invoices.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory.Properties.CurrencyAmount.ToString) IsNot Nothing Then

                            DataGridViewInvoice_Invoices.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory.Properties.CurrencyAmount.ToString).Visible = False

                        End If

                    End If

                End Using

            End If

            DataGridViewInvoice_Invoices.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadDocumentsTab()

            'objects
            Dim DocumentLevelSettingList As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing

            DocumentManagerControlDocuments_InvoiceDocuments.ClearControl()

            If _FilterAllChecked Then

                If _HistoryType = HistoryType.Media Then

                    DocumentLevelSettingList = (From DLS In
                                                (From Entity In DataGridViewInvoice_Invoices.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaBillingHistory)()
                                                 Select Entity.InvoiceNumber,
                                                        Entity.InvoiceType).Distinct.ToList
                                                Select New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice) With {.AccountReceivableInvoiceNumber = DLS.InvoiceNumber,
                                                                                                                                                                                                       .AccountReceivableType = DLS.InvoiceType}).ToList

                Else

                    DocumentLevelSettingList = (From DLS In
                                                (From Entity In DataGridViewInvoice_Invoices.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory)()
                                                 Select Entity.InvoiceNumber,
                                                        Entity.InvoiceType).Distinct.ToList
                                                Select New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice) With {.AccountReceivableInvoiceNumber = DLS.InvoiceNumber,
                                                                                                                                                                                                       .AccountReceivableType = DLS.InvoiceType}).ToList

                End If

            Else

                If _HistoryType = HistoryType.Media Then

                    DocumentLevelSettingList = (From DLS In
                                                (From Entity In DataGridViewInvoice_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaBillingHistory)()
                                                 Select Entity.InvoiceNumber,
                                                        Entity.InvoiceType).Distinct.ToList
                                                Select New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice) With {.AccountReceivableInvoiceNumber = DLS.InvoiceNumber,
                                                                                                                                                                                                       .AccountReceivableType = DLS.InvoiceType}).ToList

                Else

                    DocumentLevelSettingList = (From DLS In
                                                (From Entity In DataGridViewInvoice_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory)()
                                                 Select Entity.InvoiceNumber,
                                                        Entity.InvoiceType).Distinct.ToList
                                                Select New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice) With {.AccountReceivableInvoiceNumber = DLS.InvoiceNumber,
                                                                                                                                                                                                      .AccountReceivableType = DLS.InvoiceType}).ToList

                End If

            End If

            DocumentManagerControlDocuments_InvoiceDocuments.Enabled = DocumentManagerControlDocuments_InvoiceDocuments.LoadControl(Database.Entities.DocumentLevel.AccountReceivableInvoice, DocumentLevelSettingList, WinForm.Presentation.Controls.DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default)

            TabItemBillingSummary_DocumentsTab.Tag = True

        End Sub
        Private Sub LoadJournalEntriesTab()

            Dim GLTransactions As IEnumerable(Of Integer) = Nothing

            If _HistoryType = HistoryType.Media Then

                GLTransactions = (From Entity In DataGridViewInvoice_Invoices.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaBillingHistory).ToList
                                  Where Entity.GLTransaction.HasValue
                                  Select Entity.GLTransaction.Value).ToList

            Else

                GLTransactions = (From Entity In DataGridViewInvoice_Invoices.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory).ToList
                                  Where Entity.GLTransaction.HasValue
                                  Select Entity.GLTransaction.Value).ToList

            End If

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DataGridViewJournalEntries_JournalEntries.DataSource = AdvantageFramework.BillingCommandCenter.GetJournalEntiresByTransactionList(BCCDbContext, GLTransactions)

            End Using

            DataGridViewJournalEntries_JournalEntries.CurrentView.BestFitColumns()

            TabItemBillingSummary_JournalEntries.Tag = True

        End Sub
        Private Sub EnableOrDisableActions()

            TabItemBillingSummary_ClientPaymentsTab.Visible = DataGridViewInvoice_Invoices.HasOnlyOneSelectedRow

        End Sub
        Private Sub LoadClientPaymentsTab()

            Dim MediaBillingHistory As AdvantageFramework.BillingCommandCenter.Classes.MediaBillingHistory = Nothing
            Dim BillingHistory As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory = Nothing

            DataGridViewClientPayments_ClientPayments.ClearDatasource(New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ClientCashReceiptPayment))

            If _HistoryType = HistoryType.Media Then

                MediaBillingHistory = DataGridViewInvoice_Invoices.GetRowDataBoundItem(DataGridViewInvoice_Invoices.CurrentView.FocusedRowHandle)

                If MediaBillingHistory IsNot Nothing AndAlso MediaBillingHistory.InvoiceNumber.HasValue Then

                    Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        DataGridViewClientPayments_ClientPayments.DataSource = AdvantageFramework.BillingCommandCenter.GetClientCashReceiptPaymentsByInvoiceNumber(BCCDbContext, MediaBillingHistory.InvoiceNumber.Value)

                    End Using

                End If

            Else

                BillingHistory = DataGridViewInvoice_Invoices.GetRowDataBoundItem(DataGridViewInvoice_Invoices.CurrentView.FocusedRowHandle)

                If BillingHistory IsNot Nothing AndAlso BillingHistory.InvoiceNumber.HasValue Then

                    Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        DataGridViewClientPayments_ClientPayments.DataSource = AdvantageFramework.BillingCommandCenter.GetClientCashReceiptPaymentsByInvoiceNumber(BCCDbContext, BillingHistory.InvoiceNumber.Value)

                    End Using

                End If

            End If

            DataGridViewClientPayments_ClientPayments.CurrentView.BestFitColumns()

            TabItemBillingSummary_ClientPaymentsTab.Tag = True

        End Sub

#Region "  Public "

        Public Function LoadControl(ByVal OrderNumber As Integer, ByVal LineNumbers As IEnumerable(Of Integer), ByVal OrderDescription As String) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _OrderNumber = OrderNumber
            _LineNumbers = LineNumbers
            _OrderDescription = OrderDescription

            LabelControl_OrderJob.Text = "Order:"
            LabelControl_OrderJobValue.Text = _OrderNumber.ToString.PadLeft(6, "0") & " - " & _OrderDescription

            LabelControl_LineNumberJobComponent.Text = "Line Number(s):"
            LabelControl_LineNumberJobComponentValue.Text = String.Join(",", _LineNumbers)

            For Each TabItem In TabControlControl_BillingHistory.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                TabItem.Tag = False

            Next

            TabControlControl_BillingHistory.SelectedTab = TabItemBillingSummary_InvoicesTab

            LoadGrid()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function LoadControl(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal JobDescription As String, JobComponentDescription As String) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _HistoryType = HistoryType.Production

            _JobNumber = JobNumber
            _JobComponentNumber = JobComponentNumber
            _JobDescription = JobDescription
            _JobComponentDescription = JobComponentDescription

            LabelControl_OrderJob.Text = "Job:"
            LabelControl_OrderJobValue.Text = _JobNumber.ToString.PadLeft(6, "0") & " - " & _JobDescription

            LabelControl_LineNumberJobComponent.Text = "Job Component:"
            LabelControl_LineNumberJobComponentValue.Text = _JobComponentNumber.ToString.PadLeft(3, "0") & " - " & _JobComponentDescription

            For Each TabItem In TabControlControl_BillingHistory.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                TabItem.Tag = False

            Next

            TabControlControl_BillingHistory.SelectedTab = TabItemBillingSummary_InvoicesTab

            LoadGrid()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            DataGridViewInvoice_Invoices.ClearDatasource()
            DataGridViewJournalEntries_JournalEntries.ClearDatasource()
            DataGridViewClientPayments_ClientPayments.ClearDatasource()
            DocumentManagerControlDocuments_InvoiceDocuments.ClearControl()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub RefreshDocumentsTab(ByVal FilterAllChecked As Boolean)

            _FilterAllChecked = FilterAllChecked

            LoadDocumentsTab()

        End Sub
        Public Sub ExportData(ByVal DefaultLookAndFeel As DevExpress.LookAndFeel.DefaultLookAndFeel, ByVal DocumentDescription As String)

            Try

                DataGridViewControl_Export.ClearGridCustomization()

                If TabControlControl_BillingHistory.SelectedTab.Equals(TabItemBillingSummary_InvoicesTab) Then

                    If _HistoryType = HistoryType.Media Then

                        DataGridViewControl_Export.DataSource = DataGridViewInvoice_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaBillingHistory)().ToList
                        DataGridViewControl_Export.CurrentView.ViewCaption = DataGridViewInvoice_Invoices.CurrentView.ViewCaption

                    Else

                        DataGridViewControl_Export.DataSource = DataGridViewInvoice_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory)().ToList
                        DataGridViewControl_Export.CurrentView.ViewCaption = DataGridViewInvoice_Invoices.CurrentView.ViewCaption

                    End If

                ElseIf TabControlControl_BillingHistory.SelectedTab.Equals(TabItemBillingSummary_JournalEntries) Then

                    DataGridViewControl_Export.DataSource = DataGridViewJournalEntries_JournalEntries.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.JournalEntry)().ToList
                    DataGridViewControl_Export.CurrentView.ViewCaption = DataGridViewJournalEntries_JournalEntries.CurrentView.ViewCaption

                End If

            Catch ex As Exception

            End Try

            DataGridViewControl_Export.Print(DefaultLookAndFeel.LookAndFeel, DocumentDescription, UseLandscape:=True)

        End Sub
        Public Sub DownloadSelectedDocument()

            DocumentManagerControlDocuments_InvoiceDocuments.DownloadSelectedDocument()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub MediaBillingHistoryControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewInvoice_Invoices_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewInvoice_Invoices.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            DataGridViewInvoice_Invoices.CurrentView.OptionsView.ShowFooter = True

            For Each GridColumn In DataGridViewInvoice_Invoices.Columns

                If GridColumn.ColumnType Is GetType(System.Decimal) OrElse
                            GridColumn.ColumnType Is GetType(System.Nullable(Of Decimal)) Then

                    AdvantageFramework.Billing.Presentation.SetColumnAsSumColumn(DataGridViewInvoice_Invoices, GridColumn.FieldName)

                End If

            Next

        End Sub
        Private Sub DataGridViewInvoice_Invoices_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewInvoice_Invoices.SelectionChangedEvent

            For Each TabItem In TabControlControl_BillingHistory.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                TabItem.Tag = False

            Next

            EnableOrDisableActions()

        End Sub
        Private Sub DocumentManagerControlDocuments_InvoiceDocuments_SelectedDocumentChanged() Handles DocumentManagerControlDocuments_InvoiceDocuments.SelectedDocumentChanged

            RaiseEvent SelectedDocumentChanged()

        End Sub
        Private Sub TabControlControl_BillingHistory_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlControl_BillingHistory.SelectedTabChanged

            RaiseEvent SelectedTabChanged()

        End Sub
        Private Sub TabControlControl_BillingHistory_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlControl_BillingHistory.SelectedTabChanging

            If e.NewTab.Equals(TabItemBillingSummary_DocumentsTab) AndAlso e.NewTab.Tag = False Then

                LoadDocumentsTab()

            ElseIf e.NewTab.Equals(TabItemBillingSummary_JournalEntries) AndAlso e.NewTab.Tag = False Then

                LoadJournalEntriesTab()

            ElseIf e.NewTab.Equals(TabItemBillingSummary_ClientPaymentsTab) AndAlso e.NewTab.Tag = False Then

                LoadClientPaymentsTab()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
