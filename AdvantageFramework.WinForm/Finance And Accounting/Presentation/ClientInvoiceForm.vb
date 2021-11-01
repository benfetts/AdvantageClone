Namespace FinanceAndAccounting.Presentation

    Public Class ClientInvoiceForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private WithEvents _GridViewClientInvoiceDetailsLevel1Tab1 As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private WithEvents _GridViewClientInvoiceGLTransactionsLevel1Tab2 As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private WithEvents _GridViewClientInvoicePaymentHistoryLevel1Tab3 As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private WithEvents _GridViewClientInvoiceCheckDetailLevel2Tab1 As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private _BatchDate As Date = Nothing
        Private _FromDate As Date = Nothing
        Private _ToDate As Date = Nothing
        Private _IsQuickbooksEnabled As Boolean = False
        Private _QBCustomerID As String = Nothing

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

            Dim ClientCodes As IEnumerable(Of String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ClientCodes = (From Entity In AdvantageFramework.Database.Procedures.Client.LoadWithOfficeLimits(DbContext, Me.Session)
                                   Select Entity.Code).ToArray

                    DataGridViewLeftSection_Clients.DataSource = (From Client In AdvantageFramework.Database.Procedures.Client.LoadByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode)
                                                                  Where ClientCodes.Contains(Client.Code)
                                                                  Select Client).ToList

                End Using

            End Using

            If DataGridViewLeftSection_Clients.Columns(AdvantageFramework.Database.Entities.Client.Properties.IsNewBusiness.ToString) IsNot Nothing Then

                DataGridViewLeftSection_Clients.Columns(AdvantageFramework.Database.Entities.Client.Properties.IsNewBusiness.ToString).Visible = False

            End If

            DataGridViewLeftSection_Clients.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            Dim ClientCode As String = Nothing

            Try

                Me.FormAction = WinForm.Presentation.FormActions.Clearing

                SearchableComboBoxRightSection_Client.SelectedValue = Nothing
                SearchableComboBoxRightSection_Division.SelectedValue = Nothing
                SearchableComboBoxRightSection_Product.SelectedValue = Nothing
                SearchableComboBoxRightSection_Product.Enabled = False

                SearchableComboBoxRightSection_Office.SelectedValue = Nothing
                SearchableComboBoxRightSection_SalesClass.SelectedValue = Nothing
                NumericInputRightSection_AvgDaystoPay.EditValue = Nothing
                DateTimePickerRightSection_LastPaymentDate.Value = Nothing

                _QBCustomerID = Nothing

                If DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow Then

                    Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

                    ClientCode = DataGridViewLeftSection_Clients.GetFirstSelectedRowBookmarkValue

                    SearchableComboBoxRightSection_Client.SelectedValue = ClientCode

                    ClientContactManagerControlRightSection_ClientContacts.LoadControl(ClientCode, Nothing, Nothing)

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        _QBCustomerID = AdvantageFramework.Quickbooks.GetClientCrossReferenceCustomerID(DbContext, ClientCode, Nothing)

                    End Using

                    LoadInvoices()

                End If

                Me.ClearChanged()

            Catch ex As Exception

            Finally

                Me.FormAction = WinForm.Presentation.FormActions.None

            End Try

        End Sub
        Private Sub LoadInvoices()

            Dim ClientCode As String = Nothing
            Dim ClientInvoiceList As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoice) = Nothing
            Dim AllOpenPaid As Short = 0
            Dim HideVoidComment As Boolean = True

            If SearchableComboBoxRightSection_Client.HasASelectedValue Then

                Me.ShowWaitForm("Loading ...")

                ClientCode = SearchableComboBoxRightSection_Client.GetSelectedValue

                DataGridViewInvoices_InvoiceData.CurrentView.BeginUpdate()

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If ButtonItemClientInvoices_Voided.Checked Then

                        ClientInvoiceList = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoice) _
                            (String.Format("exec advsp_ar_invoice_select_voided_by_client '{0}','{1}',{2},{3},{4},{5}",
                                            Me.Session.UserCode,
                                            ClientCode,
                                            If(SearchableComboBoxRightSection_Division.GetSelectedValue IsNot Nothing, "'" & SearchableComboBoxRightSection_Division.GetSelectedValue & "'", "NULL"),
                                            If(SearchableComboBoxRightSection_Product.GetSelectedValue IsNot Nothing, "'" & SearchableComboBoxRightSection_Product.GetSelectedValue & "'", "NULL"),
                                            If(SearchableComboBoxRightSection_Office.GetSelectedValue IsNot Nothing, "'" & SearchableComboBoxRightSection_Office.GetSelectedValue & "'", "NULL"),
                                            If(SearchableComboBoxRightSection_SalesClass.GetSelectedValue IsNot Nothing, "'" & SearchableComboBoxRightSection_SalesClass.GetSelectedValue & "'", "NULL"))).ToList

                        HideVoidComment = False

                    Else

                        If ButtonItemClientInvoices_Open.Checked Then

                            AllOpenPaid = 1

                        ElseIf ButtonItemClientInvoices_Paid.Checked Then

                            AllOpenPaid = 2

                        End If

                        ClientInvoiceList = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoice) _
                            (String.Format("exec advsp_ar_invoice_select_by_client '{0}','{1}',{2},{3},{4},{5},{6}",
                                            Me.Session.UserCode,
                                            ClientCode,
                                            If(SearchableComboBoxRightSection_Division.GetSelectedValue IsNot Nothing, "'" & SearchableComboBoxRightSection_Division.GetSelectedValue & "'", "NULL"),
                                            If(SearchableComboBoxRightSection_Product.GetSelectedValue IsNot Nothing, "'" & SearchableComboBoxRightSection_Product.GetSelectedValue & "'", "NULL"),
                                            If(SearchableComboBoxRightSection_Office.GetSelectedValue IsNot Nothing, "'" & SearchableComboBoxRightSection_Office.GetSelectedValue & "'", "NULL"),
                                            If(SearchableComboBoxRightSection_SalesClass.GetSelectedValue IsNot Nothing, "'" & SearchableComboBoxRightSection_SalesClass.GetSelectedValue & "'", "NULL"),
                                            AllOpenPaid)).ToList

                    End If

                    If ButtonItemClientInvoices_All.Checked Then

                        DataGridViewInvoices_InvoiceData.ItemDescription = "Open/Paid Client Invoice(s)"

                    ElseIf ButtonItemClientInvoices_Open.Checked Then

                        DataGridViewInvoices_InvoiceData.ItemDescription = "Open Client Invoice(s)"

                    ElseIf ButtonItemClientInvoices_Paid.Checked Then

                        DataGridViewInvoices_InvoiceData.ItemDescription = "Paid Client Invoice(s)"

                    Else

                        DataGridViewInvoices_InvoiceData.ItemDescription = "Voided Client Invoice(s)"

                        If DataGridViewInvoices_InvoiceData.Columns(AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.HasDocuments) IsNot Nothing Then

                            DataGridViewInvoices_InvoiceData.Columns(AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.HasDocuments).Visible = False

                        End If

                    End If

                    DataGridViewInvoices_InvoiceData.DataSource = ClientInvoiceList

                    If DataGridViewInvoices_InvoiceData.CurrentView.Columns(AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.VoidComment.ToString) IsNot Nothing Then

                        If HideVoidComment Then

                            DataGridViewInvoices_InvoiceData.CurrentView.Columns(AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.VoidComment.ToString).Visible = False

                        Else

                            DataGridViewInvoices_InvoiceData.CurrentView.Columns(AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.VoidComment.ToString).OptionsColumn.ReadOnly = True

                        End If

                    End If

                    If _IsQuickbooksEnabled = False AndAlso DataGridViewInvoices_InvoiceData.CurrentView.Columns(AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.QuickBooks.ToString) IsNot Nothing Then

                        DataGridViewInvoices_InvoiceData.CurrentView.Columns(AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.QuickBooks.ToString).Visible = False

                    End If

                    ButtonItemZeroInvoices_Exclude.Checked = True

                    DataGridViewInvoices_InvoiceData.CurrentView.AFActiveFilterString = "[Amount] <> 0"

                    ApplyGrouping()

                    DataGridViewInvoices_InvoiceData.CurrentView.BestFitColumns()

                End Using

                DataGridViewInvoices_InvoiceData.CurrentView.EndUpdate()

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub LoadDetailViews()

            Dim ClientInvoicePaymentHistoryGridLevelNode As DevExpress.XtraGrid.GridLevelNode = Nothing

            DataGridViewInvoices_InvoiceData.CurrentView.BeginUpdate()

            ' Invoice Detail
            _GridViewClientInvoiceDetailsLevel1Tab1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView

            DataGridViewInvoices_InvoiceData.GridControl.LevelTree.Nodes.Add("ClientInvoiceDetailsLevel1Tab1", _GridViewClientInvoiceDetailsLevel1Tab1)

            _GridViewClientInvoiceDetailsLevel1Tab1.LevelIndent = 1

            '_GridViewClientInvoiceDetailsLevel1Tab1.DefaultRelationIndex = 0
            _GridViewClientInvoiceDetailsLevel1Tab1.ChildGridLevelName = "ClientInvoiceDetailsLevel1Tab1"
            _GridViewClientInvoiceDetailsLevel1Tab1.GridControl = DataGridViewInvoices_InvoiceData.GridControl
            _GridViewClientInvoiceDetailsLevel1Tab1.Name = "_GridViewClientInvoiceDetailsLevel1Tab1"

            _GridViewClientInvoiceDetailsLevel1Tab1.Session = Me.Session

            _GridViewClientInvoiceDetailsLevel1Tab1.OptionsDetail.AllowExpandEmptyDetails = True
            _GridViewClientInvoiceDetailsLevel1Tab1.OptionsDetail.EnableMasterViewMode = False
            _GridViewClientInvoiceDetailsLevel1Tab1.AutoloadRepositoryDatasource = True
            _GridViewClientInvoiceDetailsLevel1Tab1.ControlType = WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid

            _GridViewClientInvoiceDetailsLevel1Tab1.ObjectType = GetType(AdvantageFramework.AccountReceivable.Classes.ClientInvoiceDetail)

            _GridViewClientInvoiceDetailsLevel1Tab1.OptionsDetail.ShowDetailTabs = False
            _GridViewClientInvoiceDetailsLevel1Tab1.OptionsSelection.MultiSelect = False
            _GridViewClientInvoiceDetailsLevel1Tab1.OptionsView.ShowViewCaption = False
            _GridViewClientInvoiceDetailsLevel1Tab1.OptionsNavigation.UseTabKey = False

            _GridViewClientInvoiceDetailsLevel1Tab1.CreateColumnsBasedOnObjectType(True)

            _GridViewClientInvoiceDetailsLevel1Tab1.OptionsView.ShowFooter = False

            ' GL Transactions
            _GridViewClientInvoiceGLTransactionsLevel1Tab2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView

            DataGridViewInvoices_InvoiceData.GridControl.LevelTree.Nodes.Add("ClientInvoiceGLTransactionsLevel1Tab2", _GridViewClientInvoiceGLTransactionsLevel1Tab2)

            _GridViewClientInvoiceGLTransactionsLevel1Tab2.LevelIndent = 1

            '_GridViewClientInvoiceGLTransactionsLevel1Tab2.DefaultRelationIndex = 1
            _GridViewClientInvoiceGLTransactionsLevel1Tab2.ChildGridLevelName = "ClientInvoiceGLTransactionsLevel1Tab2"
            _GridViewClientInvoiceGLTransactionsLevel1Tab2.GridControl = DataGridViewInvoices_InvoiceData.GridControl
            _GridViewClientInvoiceGLTransactionsLevel1Tab2.Name = "_GridViewClientInvoiceGLTransactionsLevel1Tab2"

            _GridViewClientInvoiceGLTransactionsLevel1Tab2.Session = Me.Session

            _GridViewClientInvoiceGLTransactionsLevel1Tab2.OptionsDetail.AllowExpandEmptyDetails = True
            _GridViewClientInvoiceGLTransactionsLevel1Tab2.OptionsDetail.EnableMasterViewMode = False
            _GridViewClientInvoiceGLTransactionsLevel1Tab2.AutoloadRepositoryDatasource = True
            _GridViewClientInvoiceGLTransactionsLevel1Tab2.ControlType = WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid

            _GridViewClientInvoiceGLTransactionsLevel1Tab2.ObjectType = GetType(AdvantageFramework.AccountReceivable.Classes.AccountReceivableTransaction)

            _GridViewClientInvoiceGLTransactionsLevel1Tab2.OptionsDetail.ShowDetailTabs = False
            _GridViewClientInvoiceGLTransactionsLevel1Tab2.OptionsSelection.MultiSelect = False
            _GridViewClientInvoiceGLTransactionsLevel1Tab2.OptionsView.ShowViewCaption = False
            _GridViewClientInvoiceGLTransactionsLevel1Tab2.OptionsNavigation.UseTabKey = False

            _GridViewClientInvoiceGLTransactionsLevel1Tab2.CreateColumnsBasedOnObjectType(True)

            _GridViewClientInvoiceGLTransactionsLevel1Tab2.OptionsView.ShowFooter = False

            ' Payment History
            _GridViewClientInvoicePaymentHistoryLevel1Tab3 = New AdvantageFramework.WinForm.Presentation.Controls.GridView

            ClientInvoicePaymentHistoryGridLevelNode = DataGridViewInvoices_InvoiceData.GridControl.LevelTree.Nodes.Add("ClientInvoicePaymentHistoryLevel1Tab3", _GridViewClientInvoicePaymentHistoryLevel1Tab3)

            _GridViewClientInvoicePaymentHistoryLevel1Tab3.LevelIndent = 1

            '_GridViewClientInvoicePaymentHistoryLevel1Tab3.DefaultRelationIndex = 2
            _GridViewClientInvoicePaymentHistoryLevel1Tab3.ChildGridLevelName = "ClientInvoicePaymentHistoryLevel1Tab3"
            _GridViewClientInvoicePaymentHistoryLevel1Tab3.GridControl = DataGridViewInvoices_InvoiceData.GridControl
            _GridViewClientInvoicePaymentHistoryLevel1Tab3.Name = "_GridViewClientInvoicePaymentHistoryLevel1Tab3"

            _GridViewClientInvoicePaymentHistoryLevel1Tab3.Session = Me.Session

            _GridViewClientInvoicePaymentHistoryLevel1Tab3.ControlType = WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid

            _GridViewClientInvoicePaymentHistoryLevel1Tab3.ObjectType = GetType(AdvantageFramework.AccountReceivable.Classes.ClientInvoicePayment)

            _GridViewClientInvoicePaymentHistoryLevel1Tab3.OptionsDetail.AllowExpandEmptyDetails = True
            _GridViewClientInvoicePaymentHistoryLevel1Tab3.OptionsDetail.ShowDetailTabs = False
            _GridViewClientInvoicePaymentHistoryLevel1Tab3.OptionsSelection.MultiSelect = False
            _GridViewClientInvoicePaymentHistoryLevel1Tab3.OptionsView.ShowViewCaption = False
            _GridViewClientInvoicePaymentHistoryLevel1Tab3.OptionsNavigation.UseTabKey = False

            _GridViewClientInvoicePaymentHistoryLevel1Tab3.CreateColumnsBasedOnObjectType(True)

            _GridViewClientInvoicePaymentHistoryLevel1Tab3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

            _GridViewClientInvoicePaymentHistoryLevel1Tab3.OptionsView.ShowFooter = False


            ' Check Detail
            _GridViewClientInvoiceCheckDetailLevel2Tab1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView

            ClientInvoicePaymentHistoryGridLevelNode.Nodes.Add("ClientInvoiceCheckDetailLevel2Tab1", _GridViewClientInvoiceCheckDetailLevel2Tab1)

            _GridViewClientInvoiceCheckDetailLevel2Tab1.LevelIndent = 2

            '_GridViewClientInvoiceCheckDetailLevel2Tab1.DefaultRelationIndex = 0
            _GridViewClientInvoiceCheckDetailLevel2Tab1.ChildGridLevelName = "ClientInvoiceCheckDetailLevel2Tab1"
            _GridViewClientInvoiceCheckDetailLevel2Tab1.GridControl = DataGridViewInvoices_InvoiceData.GridControl
            _GridViewClientInvoiceCheckDetailLevel2Tab1.Name = "_GridViewClientInvoiceCheckDetailLevel2Tab1"

            _GridViewClientInvoiceCheckDetailLevel2Tab1.Session = Me.Session

            _GridViewClientInvoiceCheckDetailLevel2Tab1.ControlType = WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid

            _GridViewClientInvoiceCheckDetailLevel2Tab1.ObjectType = GetType(AdvantageFramework.AccountReceivable.Classes.ClientInvoicePaymentCheckDetail)

            _GridViewClientInvoiceCheckDetailLevel2Tab1.OptionsDetail.ShowDetailTabs = False
            _GridViewClientInvoiceCheckDetailLevel2Tab1.OptionsSelection.MultiSelect = False
            _GridViewClientInvoiceCheckDetailLevel2Tab1.OptionsView.ShowViewCaption = False
            _GridViewClientInvoiceCheckDetailLevel2Tab1.OptionsNavigation.UseTabKey = False

            _GridViewClientInvoiceCheckDetailLevel2Tab1.CreateColumnsBasedOnObjectType(True)

            _GridViewClientInvoiceCheckDetailLevel2Tab1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

            _GridViewClientInvoiceCheckDetailLevel2Tab1.OptionsView.ShowFooter = False

            DataGridViewInvoices_InvoiceData.CurrentView.EndUpdate()

        End Sub
        Private Function GetAccountPayableInvoiceDocumentLevelSettings(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                       ByVal InvoiceNumber As Integer,
                                                                       ByVal InvoiceSequenceNumber As Short,
                                                                       ByVal Type As String) As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

            'objects
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing

            DocumentLevelSettings = (From ARS In AdvantageFramework.Database.Procedures.AccountReceivableSummary.Load(DbContext)
                                     Join APP In AdvantageFramework.Database.Procedures.AccountPayableProduction.Load(DbContext)
                                                On ARS.ARInvoiceNumber.Value Equals APP.AccountReceivableInvoiceNumber.Value And
                                                   ARS.ARInvoiceSequence.Value Equals APP.AccountReceivableInvoiceSequenceNumber.Value And
                                                   ARS.JobNumber.Value Equals APP.JobNumber And
                                                   ARS.JobComponentNumber.Value Equals APP.JobComponentNumber
                                     Join APH In AdvantageFramework.Database.Procedures.AccountPayable.Load(DbContext) On APP.AccountPayableID Equals APH.ID
                                     Where (APP.ModifyDelete Is Nothing OrElse APP.ModifyDelete = 0) AndAlso
                                           (APH.Modified Is Nothing OrElse APH.Modified = 0) AndAlso
                                           (APH.Deleted Is Nothing OrElse APH.Deleted = 0) AndAlso
                                           ARS.ARInvoiceNumber = InvoiceNumber AndAlso
                                           ARS.ARInvoiceSequence = InvoiceSequenceNumber AndAlso
                                           ARS.ARType = Type
                                     Select APH.ID, ARS.ARInvoiceNumber, ARS.ARInvoiceSequence, ARS.ARType).Distinct.ToList.Select(Function(DLS) _
                                            New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice) With
                                                                                                           {.AccountPayableID = DLS.ID,
                                                                                                            .AccountReceivableInvoiceNumber = DLS.ARInvoiceNumber,
                                                                                                            .AccountReceivableSequenceNumber = DLS.ARInvoiceSequence,
                                                                                                            .AccountReceivableType = DLS.ARType}).ToList

            GetAccountPayableInvoiceDocumentLevelSettings = DocumentLevelSettings

        End Function
        Private Function GetExpenseReportDetailDocumentLevelSettings(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                     ByVal InvoiceNumber As Integer,
                                                                     ByVal InvoiceSequenceNumber As Short,
                                                                     ByVal Type As String) As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

            'objects
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing

            DocumentLevelSettings = (From ARS In AdvantageFramework.Database.Procedures.AccountReceivableSummary.Load(DbContext)
                                     Join APP In AdvantageFramework.Database.Procedures.AccountPayableProduction.Load(DbContext)
                                                On ARS.ARInvoiceNumber.Value Equals APP.AccountReceivableInvoiceNumber.Value And
                                                   ARS.ARInvoiceSequence.Value Equals APP.AccountReceivableInvoiceSequenceNumber.Value And
                                                   ARS.JobNumber.Value Equals APP.JobNumber And
                                                   ARS.JobComponentNumber.Value Equals APP.JobComponentNumber
                                     Join APH In AdvantageFramework.Database.Procedures.AccountPayable.Load(DbContext) On APP.AccountPayableID Equals APH.ID
                                     Where (APP.ModifyDelete Is Nothing OrElse APP.ModifyDelete = 0) AndAlso
                                           (APH.Modified Is Nothing OrElse APH.Modified = 0) AndAlso
                                           (APH.Deleted Is Nothing OrElse APH.Deleted = 0) AndAlso
                                           APP.ExpenseReportDetailID IsNot Nothing AndAlso
                                           ARS.ARInvoiceNumber = InvoiceNumber AndAlso
                                           ARS.ARInvoiceSequence = InvoiceSequenceNumber AndAlso
                                           ARS.ARType = Type
                                     Select APH.ID, ARS.ARInvoiceNumber, ARS.ARInvoiceSequence, ARS.ARType, APP.ExpenseReportDetailID).Distinct.ToList.Select(Function(DLS) _
                                            New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts, Database.Entities.DocumentSubLevel.ExpenseDetailDocument) With
                                                                                                           {.AccountPayableID = DLS.ID,
                                                                                                            .AccountReceivableInvoiceNumber = DLS.ARInvoiceNumber,
                                                                                                            .AccountReceivableSequenceNumber = DLS.ARInvoiceSequence,
                                                                                                            .AccountReceivableType = DLS.ARType,
                                                                                                            .ExpenseDetailID = DLS.ExpenseReportDetailID}).ToList

            GetExpenseReportDetailDocumentLevelSettings = DocumentLevelSettings

        End Function
        Private Function GetAccountPayableInvoicesWithMediaDocumentLevelSettings(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                                 ByVal ARInvoiceNumber As Integer,
                                                                                 ByVal ARInvoiceSequenceNumber As Short,
                                                                                 ByVal ARType As String) As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

            'objects
            Dim ClientInvoiceMediaWithAPDocumentList As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoiceMediaWithAPDocument) = Nothing
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing

            ClientInvoiceMediaWithAPDocumentList = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoiceMediaWithAPDocument) _
                                                            (String.Format("exec advsp_ar_invoice_select_ap_media_documents {0},{1},'{2}'",
                                                                            ARInvoiceNumber, ARInvoiceSequenceNumber, ARType)).ToList

            DocumentLevelSettings = (From Entity In ClientInvoiceMediaWithAPDocumentList
                                     Select Entity.AccountPayableID, Entity.InvoiceNumber, Entity.SequenceNumber, Entity.Type).Distinct.ToList.Select(Function(Doc) _
                                            New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice) With
                                                                                                           {.AccountPayableID = Doc.AccountPayableID,
                                                                                                            .AccountReceivableInvoiceNumber = Doc.InvoiceNumber,
                                                                                                            .AccountReceivableSequenceNumber = Doc.SequenceNumber,
                                                                                                            .AccountReceivableType = Doc.Type}).ToList

            GetAccountPayableInvoicesWithMediaDocumentLevelSettings = DocumentLevelSettings

        End Function
        Private Sub LoadInvoiceDocuments()

            'objects
            Dim ClientInvoice As AdvantageFramework.AccountReceivable.Classes.ClientInvoice = Nothing
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing

            ClientInvoice = DataGridViewInvoices_InvoiceData.CurrentView.GetRow(DataGridViewInvoices_InvoiceData.CurrentView.FocusedRowHandle)

            If ClientInvoice IsNot Nothing AndAlso TabItemInvoiceDetails_DocumentsTab.Visible Then

                DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice) With {.AccountReceivableInvoiceNumber = ClientInvoice.InvoiceNumber, .AccountReceivableSequenceNumber = ClientInvoice.SequenceNumber, .AccountReceivableType = ClientInvoice.Type})

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DocumentLevelSettings.AddRange(GetAccountPayableInvoiceDocumentLevelSettings(DbContext, ClientInvoice.InvoiceNumber, ClientInvoice.SequenceNumber, ClientInvoice.Type))

                    DocumentLevelSettings.AddRange(GetExpenseReportDetailDocumentLevelSettings(DbContext, ClientInvoice.InvoiceNumber, ClientInvoice.SequenceNumber, ClientInvoice.Type))

                    DocumentLevelSettings.AddRange(GetAccountPayableInvoicesWithMediaDocumentLevelSettings(DbContext, ClientInvoice.InvoiceNumber, ClientInvoice.SequenceNumber, ClientInvoice.Type))

                End Using

                DocumentManagerControlInvoices_Documents.ClearControl()

                DocumentManagerControlInvoices_Documents.Enabled = DocumentManagerControlInvoices_Documents.LoadControl(Database.Entities.DocumentLevel.AccountReceivableInvoice, DocumentLevelSettings, WinForm.Presentation.Controls.DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default, True, True)

            End If

        End Sub
        Private Function LoadDetailLevel(ByVal RowHandle As Integer, ByVal RelationIndex As Integer,
                                         ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView) As IEnumerable

            'objects
            Dim Details As IEnumerable = Nothing
            Dim InvoiceNumber As Integer = 0
            Dim InvoiceSequenceNumber As Short = 0
            Dim Type As String = Nothing
            Dim AccountReceivableTransactionList As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.AccountReceivableTransaction) = Nothing
            Dim Transactions As IEnumerable(Of Integer) = Nothing

            Try

                InvoiceNumber = GridView.GetRowCellValue(RowHandle, AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.InvoiceNumber.ToString)
                InvoiceSequenceNumber = GridView.GetRowCellValue(RowHandle, AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.SequenceNumber.ToString)
                Type = GridView.GetRowCellValue(RowHandle, AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.Type.ToString)

            Catch ex As Exception
                InvoiceNumber = 0
                InvoiceSequenceNumber = 0
            End Try

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Select Case RelationIndex

                    Case 0

                        Details = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoiceDetail) _
                            (String.Format("exec advsp_ar_invoice_select_summary_detail {0},{1},'{2}','{3}',{4},{5},{6}", InvoiceNumber, InvoiceSequenceNumber, Type, SearchableComboBoxRightSection_Client.GetSelectedValue,
                                           If(SearchableComboBoxRightSection_Division.GetSelectedValue IsNot Nothing, "'" & SearchableComboBoxRightSection_Division.GetSelectedValue & "'", "NULL"),
                                           If(SearchableComboBoxRightSection_Product.GetSelectedValue IsNot Nothing, "'" & SearchableComboBoxRightSection_Product.GetSelectedValue & "'", "NULL"),
                                           If(SearchableComboBoxRightSection_Office.GetSelectedValue IsNot Nothing, "'" & SearchableComboBoxRightSection_Office.GetSelectedValue & "'", "NULL"))).ToList

                        ApplyGrouping()

                    Case 1

                        AccountReceivableTransactionList = New Generic.List(Of AdvantageFramework.AccountReceivable.Classes.AccountReceivableTransaction)

                        Transactions = (From Entity In AdvantageFramework.Database.Procedures.AccountReceivableSummary.Load(DbContext)
                                        Where Entity.ARInvoiceNumber = InvoiceNumber AndAlso
                                              Entity.GLTransactionDeferred IsNot Nothing
                                        Select Entity.GLTransactionDeferred.Value).Union(
                                       (From Entity In AdvantageFramework.Database.Procedures.AccountReceivableSummary.Load(DbContext)
                                        Where Entity.ARInvoiceNumber = InvoiceNumber AndAlso
                                              Entity.GLTransaction IsNot Nothing
                                        Select Entity.GLTransaction.Value)).Union(
                                       (From Entity In AdvantageFramework.Database.Procedures.AccountReceivable.LoadAllByInvoiceNumberAndSequenceNumber(DbContext, InvoiceNumber, InvoiceSequenceNumber)
                                        Where Entity.GLTransaction IsNot Nothing
                                        Select Entity.GLTransaction.Value)).ToList

                        For Each Transaction In Transactions

                            AccountReceivableTransactionList.Add(New AdvantageFramework.AccountReceivable.Classes.AccountReceivableTransaction(DbContext, Transaction))

                        Next

                        Details = AccountReceivableTransactionList

                    Case 2

                        Details = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoicePayment)(String.Format("exec advsp_ar_invoice_select_payments {0},{1}", InvoiceNumber, InvoiceSequenceNumber)).ToList

                End Select

            End Using

            LoadDetailLevel = Details

        End Function
        Private Sub EnableOrDisableActions()

            RibbonBarMergeContainerForm_Options.SuspendLayout()

            PanelForm_RightSection.Enabled = (DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            TabItemInvoiceDetails_DocumentsTab.Visible = DataGridViewInvoices_InvoiceData.HasOnlyOneSelectedRow AndAlso Not ButtonItemClientInvoices_Voided.Checked

            RibbonBarOptions_ClientInvoices.Visible = PanelForm_RightSection.Enabled
            RibbonBarOptions_DaysToPay.Visible = PanelForm_RightSection.Enabled
            RibbonBarOptions_ZeroInvoices.Visible = PanelForm_RightSection.Enabled
            RibbonBarOptions_Package.Visible = PanelForm_RightSection.Enabled
            RibbonBarOptions_Documents.Visible = PanelForm_RightSection.Enabled AndAlso (TabControlRightSection_InvoiceDetails.SelectedTab Is TabItemInvoiceDetails_DocumentsTab)

            If RibbonBarOptions_Documents.Visible Then

                ButtonItemDocuments_Delete.Enabled = DocumentManagerControlInvoices_Documents.CanDelete
                ButtonItemDocuments_Download.Enabled = If(DocumentManagerControlInvoices_Documents.HasOnlyOneSelectedDocument, Not DocumentManagerControlInvoices_Documents.IsSelectedDocumentAURL, DocumentManagerControlInvoices_Documents.HasASelectedDocument)
                ButtonItemDocuments_OpenURL.Enabled = If(DocumentManagerControlInvoices_Documents.HasOnlyOneSelectedDocument, DocumentManagerControlInvoices_Documents.IsSelectedDocumentAURL, False)
                ButtonItemDocuments_Upload.Enabled = DocumentManagerControlInvoices_Documents.CanUpload

            Else

                ButtonItemDocuments_Upload.Enabled = False
                ButtonItemDocuments_Delete.Enabled = False
                ButtonItemDocuments_Download.Enabled = False
                ButtonItemDocuments_OpenURL.Enabled = False

            End If

            If RibbonBarOptions_Quickbooks.Visible Then

                ButtonItemQuickbooks_Send.Enabled = (DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow AndAlso Me.FormShown AndAlso String.IsNullOrWhiteSpace(_QBCustomerID) = False)

            End If

            ButtonItemPrinting_Export.Enabled = PanelForm_RightSection.Enabled

            RibbonBarMergeContainerForm_Options.Invalidate(True)
            RibbonBarMergeContainerForm_Options.ResumeLayout()

        End Sub
        Private Sub SetAverageDaysToPay()

            Dim ClientCode As String = Nothing
            Dim InvoiceCheckDates As IEnumerable(Of Object) = Nothing
            Dim AvgDays As Generic.List(Of Long) = Nothing

            ClientCode = SearchableComboBoxRightSection_Client.GetSelectedValue

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                InvoiceCheckDates = (From CR In AdvantageFramework.Database.Procedures.ClientCashReceiptDetail.Load(DbContext).Include("AccountReceivable")
                                     Join AR In AdvantageFramework.Database.Procedures.AccountReceivable.Load(DbContext)
                                             On CR.AccountReceivable.InvoiceNumber Equals AR.InvoiceNumber And
                                                CR.ARInvoiceSequenceNumber Equals AR.SequenceNumber And
                                                CR.ARType Equals AR.Type
                                     Where AR.SequenceNumber <> 99 AndAlso
                                           (AR.IsVoided Is Nothing OrElse
                                            AR.IsVoided = 0) AndAlso
                                           AR.ClientCode = ClientCode AndAlso
                                           AR.InvoiceDate >= _FromDate AndAlso
                                           AR.InvoiceDate <= _ToDate AndAlso
                                           AR.InvoiceAmount <> 0
                                     Select New With {.InvoiceDate = AR.InvoiceDate.Value,
                                                      .CheckDate = CR.ClientCashReceipt.CheckDate,
                                                      .DepositDate = CR.ClientCashReceipt.DepositDate}).ToList

                AvgDays = New Generic.List(Of Long)

                For Each InvoiceCheckDate In InvoiceCheckDates

                    If ButtonItemDaysToPay_ByCheckDate.Checked Then

                        AvgDays.Add(DateDiff(DateInterval.Day, InvoiceCheckDate.InvoiceDate, InvoiceCheckDate.CheckDate))

                    ElseIf ButtonItemDaysToPay_ByDepositDate.Checked Then

                        AvgDays.Add(DateDiff(DateInterval.Day, InvoiceCheckDate.InvoiceDate, InvoiceCheckDate.DepositDate))

                    End If

                Next

                If AvgDays.Count > 0 Then

                    NumericInputRightSection_AvgDaystoPay.EditValue = AvgDays.Sum / AvgDays.Count

                Else

                    NumericInputRightSection_AvgDaystoPay.EditValue = Nothing

                End If

            End Using

        End Sub
        Private Sub ApplyGrouping()

            Try

                DataGridViewInvoices_InvoiceData.OptionsView.ShowGroupedColumns = True
                DataGridViewInvoices_InvoiceData.Columns(AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.CustomGroup.ToString).GroupIndex = 0
                DataGridViewInvoices_InvoiceData.CurrentView.ExpandAllGroups()

            Catch ex As Exception

            End Try

        End Sub
        Private Function CreateTextBrick(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer) As DevExpress.XtraPrinting.TextBrick

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing

            TextBrick = New DevExpress.XtraPrinting.TextBrick

            TextBrick.Rect = New System.Drawing.Rectangle(X, Y, Width, Height)
            TextBrick.BackColor = System.Drawing.Color.White
            TextBrick.BorderWidth = 0
            TextBrick.BorderStyle = DevExpress.XtraPrinting.BrickBorderStyle.Inset
            TextBrick.Font = New System.Drawing.Font("Arial", TextBrick.Font.Size)

            CreateTextBrick = TextBrick

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ClientInvoiceForm As AdvantageFramework.FinanceAndAccounting.Presentation.ClientInvoiceForm = Nothing

            ClientInvoiceForm = New AdvantageFramework.FinanceAndAccounting.Presentation.ClientInvoiceForm()

            ClientInvoiceForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientInvoiceForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            _BatchDate = Now

            _FromDate = DateAdd(DateInterval.Year, -2, Now).ToShortDateString
            _ToDate = Now.ToShortDateString()

            LabelRightSection_DateRange.Text = _FromDate.ToShortDateString & " to " & _ToDate.ToShortDateString

            ButtonItemActions_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemActions_Import.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.FinanceAccounting_ClientInvoicesImport)

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Add.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.FinanceAccounting_ClientInvoicesManual)

            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage

            ButtonItemClientInvoices_All.Image = AdvantageFramework.My.Resources.InvoiceListImage
            ButtonItemClientInvoices_Open.Image = AdvantageFramework.My.Resources.InvoiceOpenImage
            ButtonItemClientInvoices_Paid.Image = AdvantageFramework.My.Resources.InvoicePaidImage
            ButtonItemClientInvoices_Voided.Image = AdvantageFramework.My.Resources.InvoiceVoidImage

            ButtonItemDaysToPay_ByCheckDate.Image = AdvantageFramework.My.Resources.CheckingImage
            ButtonItemDaysToPay_ByDepositDate.Image = AdvantageFramework.My.Resources.DepositImage

            ButtonItemDocuments_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemUpload_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
            ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

            ButtonItemPackage_Documents.Image = AdvantageFramework.My.Resources.DocumentPackageImage

            ButtonItemPrinting_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemPrinting_PrintReport.Image = AdvantageFramework.My.Resources.PrintImage

            ButtonItemQuickbooks_Send.Image = AdvantageFramework.My.Resources.UpdateImage

            DataGridViewLeftSection_Clients.MultiSelect = False
            DataGridViewLeftSection_Clients.ByPassUserEntryChanged = True

            DataGridViewInvoices_InvoiceData.MultiSelect = True
            DataGridViewInvoices_InvoiceData.ByPassUserEntryChanged = True
            DataGridViewInvoices_InvoiceData.CurrentView.OptionsDetail.AllowExpandEmptyDetails = True
            DataGridViewInvoices_InvoiceData.CurrentView.OptionsMenu.EnableFooterMenu = False

            SearchableComboBoxRightSection_Client.ByPassUserEntryChanged = True
            SearchableComboBoxRightSection_Division.ByPassUserEntryChanged = True
            SearchableComboBoxRightSection_Product.ByPassUserEntryChanged = True
            SearchableComboBoxRightSection_Office.ByPassUserEntryChanged = True
            SearchableComboBoxRightSection_SalesClass.ByPassUserEntryChanged = True

            Me.ByPassUserEntryChanged = True

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _IsQuickbooksEnabled = AdvantageFramework.Quickbooks.IsQuickBooksEnabled(DbContext)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

                    ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
                    ButtonItemDocuments_Upload.SplitButton = False

                End If

            End Using

            Me.RibbonBarOptions_Quickbooks.Visible = _IsQuickbooksEnabled
            ButtonItemQuickbooks_Send.Enabled = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SearchableComboBoxRightSection_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadCore(DbContext).ToList

                SearchableComboBoxRightSection_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadWithOfficeLimits(DbContext, Session).Where(Function(Office) Office.IsInactive Is Nothing OrElse Office.IsInactive = 0).ToList

                SearchableComboBoxRightSection_SalesClass.DataSource = AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext).ToList

            End Using

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_Clients.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            NumericInputRightSection_AvgDaystoPay.EditValue = Nothing
            NumericInputRightSection_AvgDaystoPay.ByPassUserEntryChanged = True

            DateTimePickerRightSection_LastPaymentDate.Value = Nothing
            DateTimePickerRightSection_LastPaymentDate.ByPassUserEntryChanged = True

            LoadDetailViews()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            ButtonItemClientInvoices_Open.Checked = True

            ButtonItemDaysToPay_ByCheckDate.Checked = True

            EnableOrDisableActions()

        End Sub
        Private Sub ClientInvoiceForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            'objects
            Dim RibbonControl As DevComponents.DotNetBar.RibbonControl = Nothing

            If RibbonBarMergeContainerForm_Options.RibbonTabItem IsNot Nothing Then

                Try

                    RibbonControl = Me.MdiParent.Controls("RibbonControlForm_MainRibbon")

                Catch ex As Exception
                    RibbonControl = Nothing
                End Try

                If RibbonControl IsNot Nothing Then

                    RibbonControl.SelectedRibbonTabItem = RibbonBarMergeContainerForm_Options.RibbonTabItem

                End If

            End If

            DataGridViewLeftSection_Clients.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            Dim ClientCode As String = Nothing

            If PanelForm_RightSection.Enabled AndAlso DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow AndAlso DataGridViewLeftSection_Clients.GetFirstSelectedRowBookmarkValue IsNot Nothing Then

                ClientCode = DataGridViewLeftSection_Clients.GetFirstSelectedRowBookmarkValue

            End If

            AdvantageFramework.FinanceAndAccounting.Presentation.ClientInvoiceNewDialog.ShowFormDialog(_BatchDate, ClientCode)

            LoadInvoices()

        End Sub
        Private Sub ButtonItemActions_Import_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Import.Click

            If TypeOf Me.MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).OpenModule(AdvantageFramework.Security.Modules.FinanceAccounting_ClientInvoicesImport)

            End If

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Print.Click

            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim ClientInvoiceBatchReportList As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoiceBatchReport) = Nothing
            Dim ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
            Dim [From] As Date = Nothing
            Dim [To] As Date = Nothing
            Dim UserCode As String = Nothing
            Dim IsBatch As Boolean = False
            Dim ReportRange As String = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFromDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterToDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIsBatch As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)
            SqlParameterFromDate = New SqlClient.SqlParameter("@from_date", SqlDbType.SmallDateTime)
            SqlParameterToDate = New SqlClient.SqlParameter("@to_date", SqlDbType.SmallDateTime)
            SqlParameterIsBatch = New SqlClient.SqlParameter("@is_batch", SqlDbType.Int)

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                UserCode = Me.Session.UserCode

                If AdvantageFramework.FinanceAndAccounting.Presentation.ClientInvoiceBatchReportDialog.ShowFormDialog(ReportType, [From], [To], UserCode, IsBatch) = System.Windows.Forms.DialogResult.OK Then

                    SqlParameterUserCode.Value = UserCode
                    SqlParameterFromDate.Value = [From]

                    If IsBatch Then

                        SqlParameterToDate.Value = System.DBNull.Value
                        SqlParameterIsBatch.Value = 1
                        ReportRange = "Batch: " & [From].ToString

                    Else

                        SqlParameterToDate.Value = [To]
                        SqlParameterIsBatch.Value = 0
                        ReportRange = "Date Range: " & [From].ToShortDateString & " - " & [To].ToShortDateString

                    End If

                    ClientInvoiceBatchReportList = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoiceBatchReport)("exec advsp_clientinvoice_batch_report @user_code, @from_date, @to_date, @is_batch", SqlParameterUserCode, SqlParameterFromDate, SqlParameterToDate, SqlParameterIsBatch).ToList()

                    ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    ParameterDictionary.Add("DataSource", ClientInvoiceBatchReportList)
                    ParameterDictionary.Add("ForUser", UserCode)
                    ParameterDictionary.Add("ReportRange", ReportRange)

                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                End If

            End Using

        End Sub
        Private Sub ButtonItemPackage_Documents_Click(sender As Object, e As EventArgs) Handles ButtonItemPackage_Documents.Click

            'objects
            Dim ClientInvoiceList As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoice) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing

            If DataGridViewLeftSection_Clients.HasASelectedRow AndAlso DataGridViewInvoices_InvoiceData.HasASelectedRow Then

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

                DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                ClientInvoiceList = DataGridViewInvoices_InvoiceData.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoice).ToList

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each ClientInvoice In ClientInvoiceList

                        DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice) With {.AccountReceivableInvoiceNumber = ClientInvoice.InvoiceNumber, .AccountReceivableSequenceNumber = ClientInvoice.SequenceNumber, .AccountReceivableType = ClientInvoice.Type})

                        DocumentLevelSettings.AddRange(GetAccountPayableInvoiceDocumentLevelSettings(DbContext, ClientInvoice.InvoiceNumber, ClientInvoice.SequenceNumber, ClientInvoice.Type))

                        DocumentLevelSettings.AddRange(GetExpenseReportDetailDocumentLevelSettings(DbContext, ClientInvoice.InvoiceNumber, ClientInvoice.SequenceNumber, ClientInvoice.Type))

                        DocumentLevelSettings.AddRange(GetAccountPayableInvoicesWithMediaDocumentLevelSettings(DbContext, ClientInvoice.InvoiceNumber, ClientInvoice.SequenceNumber, ClientInvoice.Type))

                    Next

                End Using

                DocumentList.AddRange(AdvantageFramework.DocumentManager.LoadAccountPayableInvoiceDocuments(DocumentLevelSettings, Session))
                DocumentList.AddRange(AdvantageFramework.DocumentManager.LoadAccountReceivableInvoiceDocuments(DocumentLevelSettings, Session))
                DocumentList.AddRange(AdvantageFramework.DocumentManager.LoadExpenseDetailDocuments(DocumentLevelSettings, Session))

                If DocumentList.Count = 0 Then

                    AdvantageFramework.WinForm.MessageBox.Show("No documents for selected invoices.")

                Else

                    AdvantageFramework.WinForm.Presentation.DocumentPrintDialog.ShowFormDialog(DataGridViewLeftSection_Clients.GetFirstSelectedRowBookmarkValue, DocumentList)

                End If

            End If

        End Sub
        Private Sub ButtonItemClientInvoices_All_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemClientInvoices_All.CheckedChanged

            If ButtonItemClientInvoices_All.Checked AndAlso Me.FormShown Then

                LoadInvoices()

            End If

        End Sub
        Private Sub ButtonItemClientInvoices_Open_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemClientInvoices_Open.CheckedChanged

            If ButtonItemClientInvoices_Open.Checked AndAlso Me.FormShown Then

                LoadInvoices()

            End If

        End Sub
        Private Sub ButtonItemClientInvoices_Paid_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemClientInvoices_Paid.CheckedChanged

            If ButtonItemClientInvoices_Paid.Checked AndAlso Me.FormShown Then

                LoadInvoices()

            End If

        End Sub
        Private Sub ButtonItemClientInvoices_Voided_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemClientInvoices_Voided.CheckedChanged

            If ButtonItemClientInvoices_Voided.Checked AndAlso Me.FormShown Then

                LoadInvoices()

            End If

        End Sub
        Private Sub ButtonItemDaysToPay_ByCheckDate_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemDaysToPay_ByCheckDate.CheckedChanged

            If ButtonItemDaysToPay_ByCheckDate.Checked AndAlso Me.FormShown Then

                SetAverageDaysToPay()

            End If

        End Sub
        Private Sub ButtonItemDaysToPay_ByDepositDate_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemDaysToPay_ByDepositDate.CheckedChanged

            If ButtonItemDaysToPay_ByDepositDate.Checked AndAlso Me.FormShown Then

                SetAverageDaysToPay()

            End If

        End Sub
        Private Sub ButtonItemDocuments_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Delete.Click

            DocumentManagerControlInvoices_Documents.DeleteSelectedDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            DocumentManagerControlInvoices_Documents.DownloadSelectedDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            DocumentManagerControlInvoices_Documents.DownloadSelectedDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

            DocumentManagerControlInvoices_Documents.UploadNewDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

            DocumentManagerControlInvoices_Documents.SendASPUploadEmail()

        End Sub
        Private Sub ButtonItemZeroInvoices_Exclude_CheckedChanged1(sender As Object, e As EventArgs) Handles ButtonItemZeroInvoices_Exclude.CheckedChanged

            If Me.FormShown AndAlso ButtonItemZeroInvoices_Exclude.Checked Then

                DataGridViewInvoices_InvoiceData.CurrentView.AFActiveFilterString = "[Amount] <> 0"

            End If

        End Sub
        Private Sub ButtonItemZeroInvoices_Include_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemZeroInvoices_Include.CheckedChanged

            If Me.FormShown AndAlso ButtonItemZeroInvoices_Include.Checked Then

                DataGridViewInvoices_InvoiceData.CurrentView.AFActiveFilterString = ""

            End If

        End Sub
        Private Sub SearchableComboBoxRightSection_Client_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxRightSection_Client.EditValueChanged

            Dim ClientCode As String = Nothing
            Dim DivisionCodes As IEnumerable(Of String) = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem Then

                ClientCode = SearchableComboBoxRightSection_Client.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DivisionCodes = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadWithOfficeLimits(DbContext, Me.Session)
                                         Where Entity.ClientCode = ClientCode
                                         Select Entity.Code).ToArray

                        SearchableComboBoxRightSection_Division.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode)
                                                                              Where Entity.ClientCode = ClientCode AndAlso
                                                                                    DivisionCodes.Contains(Entity.Code)
                                                                              Select Entity).ToList

                    End Using

                    DateTimePickerRightSection_LastPaymentDate.Value = AdvantageFramework.Database.Procedures.ClientCashReceipt.LoadByClient(DbContext, ClientCode).Where(Function(CR) CR.Status Is Nothing).Max(Function(CR) CR.DepositDate).GetValueOrDefault(Nothing)

                    SetAverageDaysToPay()

                End Using

            End If

        End Sub
        Private Sub SearchableComboBoxRightSection_Division_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxRightSection_Division.EditValueChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                SearchableComboBoxRightSection_Product.SelectedValue = Nothing

                If SearchableComboBoxRightSection_Division.HasASelectedValue Then

                    SearchableComboBoxRightSection_Product.Enabled = True

                    SearchableComboBoxRightSection_Product.DataSource = Nothing

                Else

                    SearchableComboBoxRightSection_Product.Enabled = False

                End If

                LoadInvoices()

                ClientContactManagerControlRightSection_ClientContacts.LoadControl(SearchableComboBoxRightSection_Client.GetSelectedValue, SearchableComboBoxRightSection_Division.GetSelectedValue, Nothing)

            End If

        End Sub
        Private Sub SearchableComboBoxRightSection_Office_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxRightSection_Office.EditValueChanged

            LoadInvoices()

        End Sub
        Private Sub SearchableComboBoxRightSection_Product_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxRightSection_Product.EditValueChanged

            LoadInvoices()

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                ClientContactManagerControlRightSection_ClientContacts.LoadControl(SearchableComboBoxRightSection_Client.GetSelectedValue, SearchableComboBoxRightSection_Division.GetSelectedValue, SearchableComboBoxRightSection_Product.GetSelectedValue)

            End If

        End Sub
        Private Sub SearchableComboBoxRightSection_Product_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxRightSection_Product.QueryPopupNeedDataSource

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCodes As IEnumerable(Of String) = Nothing

            ClientCode = SearchableComboBoxRightSection_Client.GetSelectedValue
            DivisionCode = SearchableComboBoxRightSection_Division.GetSelectedValue

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ProductCodes = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadWithOfficeLimits(DbContext, Me.Session)
                                    Where Entity.ClientCode = ClientCode AndAlso
                                          Entity.DivisionCode = DivisionCode AndAlso
                                          Entity.IsActive = 1
                                    Select Entity.Code).ToArray

                    SearchableComboBoxRightSection_Product.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadCoreByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode, False)
                                                                         Where Entity.ClientCode = ClientCode AndAlso
                                                                               Entity.DivisionCode = DivisionCode AndAlso
                                                                               Entity.IsActive = 1 AndAlso
                                                                               ProductCodes.Contains(Entity.Code)
                                                                         Select Entity).ToList

                End Using

            End Using

            DataSourceSet = True

        End Sub
        Private Sub SearchableComboBoxRightSection_SalesClass_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxRightSection_SalesClass.EditValueChanged

            LoadInvoices()

        End Sub
        Private Sub DataGridViewLeftSection_Clients_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Clients.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()

                EnableOrDisableActions()

                LoadInvoiceDocuments()

            End If

        End Sub
        Private Sub DataGridViewInvoices_InvoiceData_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewInvoices_InvoiceData.CellValueChangedEvent

            'objects
            Dim ClientInvoice As AdvantageFramework.AccountReceivable.Classes.ClientInvoice = Nothing
            Dim AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable = Nothing

            If e.Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.DueDate.ToString Then

                Try

                    ClientInvoice = DataGridViewInvoices_InvoiceData.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    ClientInvoice = Nothing
                End Try

                If ClientInvoice IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        AccountReceivable = AdvantageFramework.Database.Procedures.AccountReceivable.LoadByInvoiceNumberAndSequenceNumberAndType(DbContext, ClientInvoice.InvoiceNumber, ClientInvoice.SequenceNumber, ClientInvoice.Type)

                        If AccountReceivable IsNot Nothing Then

                            AccountReceivable.DueDate = e.Value

                            AdvantageFramework.Database.Procedures.AccountReceivable.Update(DbContext, AccountReceivable)

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub DataGridViewInvoices_InvoiceData_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewInvoices_InvoiceData.CellValueChangingEvent

            'objects
            Dim ClientInvoice As AdvantageFramework.AccountReceivable.Classes.ClientInvoice = Nothing
            Dim AccountReceivableCollectionNote As AdvantageFramework.Database.Entities.AccountReceivableCollectionNote = Nothing
            Dim AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable = Nothing

            If e.Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.CollectionNotes.ToString Then

                Try

                    ClientInvoice = DataGridViewInvoices_InvoiceData.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    ClientInvoice = Nothing
                End Try

                If ClientInvoice IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        AccountReceivableCollectionNote = AdvantageFramework.Database.Procedures.AccountReceivableCollectionNote.LoadByARInvoiceNumberAndSequenceAndType(DbContext,
                                                                ClientInvoice.InvoiceNumber, ClientInvoice.SequenceNumber, ClientInvoice.Type)

                        If String.IsNullOrWhiteSpace(e.Value) AndAlso AccountReceivableCollectionNote IsNot Nothing Then

                            Saved = AdvantageFramework.Database.Procedures.AccountReceivableCollectionNote.Delete(DbContext, AccountReceivableCollectionNote)

                        ElseIf Not String.IsNullOrWhiteSpace(e.Value) Then

                            If AccountReceivableCollectionNote Is Nothing Then

                                AccountReceivableCollectionNote = New AdvantageFramework.Database.Entities.AccountReceivableCollectionNote

                                AccountReceivableCollectionNote.DbContext = DbContext
                                AccountReceivableCollectionNote.ARInvoiceNumber = ClientInvoice.InvoiceNumber
                                AccountReceivableCollectionNote.ARInvoiceSequenceNumber = ClientInvoice.SequenceNumber
                                AccountReceivableCollectionNote.ARType = ClientInvoice.Type
                                AccountReceivableCollectionNote.Note = e.Value

                                Saved = AdvantageFramework.Database.Procedures.AccountReceivableCollectionNote.Insert(DbContext, AccountReceivableCollectionNote)

                            Else

                                AccountReceivableCollectionNote.Note = e.Value

                                Saved = AdvantageFramework.Database.Procedures.AccountReceivableCollectionNote.Update(DbContext, AccountReceivableCollectionNote)

                            End If

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub DataGridViewInvoices_InvoiceData_CreateReportHeaderAreaEvent(sender As Object, e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles DataGridViewInvoices_InvoiceData.CreateReportHeaderAreaEvent

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim SalesClass As AdvantageFramework.Database.Entities.SalesClass = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, SearchableComboBoxRightSection_Client.GetSelectedValue)

                    Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, SearchableComboBoxRightSection_Client.GetSelectedValue, SearchableComboBoxRightSection_Division.GetSelectedValue)

                    Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, SearchableComboBoxRightSection_Client.GetSelectedValue, SearchableComboBoxRightSection_Division.GetSelectedValue, SearchableComboBoxRightSection_Product.GetSelectedValue)

                    Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, SearchableComboBoxRightSection_Office.GetSelectedValue)

                    SalesClass = AdvantageFramework.Database.Procedures.SalesClass.LoadBySalesClassCode(DbContext, SearchableComboBoxRightSection_SalesClass.GetSelectedValue)

                End Using

            Catch ex As Exception

            End Try

            Try

                TextBrick = CreateTextBrick(0, 30, e.Graph.ClientPageSize.Width, 15)

                TextBrick.Text = "Client: " & Client.ToString

                e.Graph.DrawBrick(TextBrick)

            Catch ex As Exception

            End Try

            Try

                TextBrick = CreateTextBrick(0, 45, e.Graph.ClientPageSize.Width, 15)

                TextBrick.Text = "Division: " & If(Division IsNot Nothing, Division.ToString, "")

                e.Graph.DrawBrick(TextBrick)

            Catch ex As Exception

            End Try

            Try

                TextBrick = CreateTextBrick(0, 60, e.Graph.ClientPageSize.Width, 15)

                TextBrick.Text = "Product: " & If(Product IsNot Nothing, Product.ToString, "")

                e.Graph.DrawBrick(TextBrick)

            Catch ex As Exception

            End Try

            Try

                TextBrick = CreateTextBrick(0, 75, e.Graph.ClientPageSize.Width, 15)

                TextBrick.Text = "Office: " & If(Office IsNot Nothing, Office.ToString, "")

                e.Graph.DrawBrick(TextBrick)

            Catch ex As Exception

            End Try

            Try

                TextBrick = CreateTextBrick(0, 90, e.Graph.ClientPageSize.Width, 15)

                TextBrick.Text = "Sales Class: " & If(SalesClass IsNot Nothing, SalesClass.ToString, "")

                e.Graph.DrawBrick(TextBrick)

            Catch ex As Exception

            End Try

            Try

                TextBrick = CreateTextBrick(0, 105, e.Graph.ClientPageSize.Width, 15)

                TextBrick.Text = "Average Days to Pay: " & NumericInputRightSection_AvgDaystoPay.Text

                e.Graph.DrawBrick(TextBrick)

            Catch ex As Exception

            End Try

            Try

                TextBrick = CreateTextBrick(0, 120, e.Graph.ClientPageSize.Width, 15)

                TextBrick.Text = "Last Payment Date: " & DateTimePickerRightSection_LastPaymentDate.GetValue

                e.Graph.DrawBrick(TextBrick)

            Catch ex As Exception

            End Try

        End Sub
        Private Sub DataGridViewInvoices_InvoiceData_CustomDrawGroupRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles DataGridViewInvoices_InvoiceData.CustomDrawGroupRowEvent

            'objects
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim GridGroupRowInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = Nothing
            Dim ClientInvoice As AdvantageFramework.AccountReceivable.Classes.ClientInvoice = Nothing
            Dim GroupText As Generic.List(Of String) = Nothing

            GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            GridGroupRowInfo = TryCast(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo)

            If GridView IsNot Nothing AndAlso GridGroupRowInfo IsNot Nothing Then

                If GridGroupRowInfo.Column.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.CustomGroup.ToString Then

                    ClientInvoice = DataGridViewInvoices_InvoiceData.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoice)().Where(Function(Entity) Entity.CustomGroup = GridGroupRowInfo.EditValue).FirstOrDefault

                    If ClientInvoice IsNot Nothing Then

                        GroupText = New Generic.List(Of String)

                        If ClientInvoice.DivisionName IsNot Nothing Then

                            GroupText.Add("Division: " & ClientInvoice.DivisionName)

                        End If

                        If ClientInvoice.ProductDescription IsNot Nothing Then

                            GroupText.Add("<color=Blue>Product: " & ClientInvoice.ProductDescription & "</color>")

                        End If

                        If ClientInvoice.OfficeName IsNot Nothing Then

                            GroupText.Add("<color=Purple>Office: " & ClientInvoice.OfficeName & "</color>")

                        End If

                        GridGroupRowInfo.GroupText = String.Join(" | ", GroupText)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewInvoices_InvoiceData_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewInvoices_InvoiceData.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If Not Me.IsFormClosing Then

                DataGridViewInvoices_InvoiceData.CurrentView.OptionsView.ShowFooter = True

                For Each GridColumn In DataGridViewInvoices_InvoiceData.Columns

                    If GridColumn.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.Amount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.AmountPaid.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.AmountWriteoff.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.BalanceDue.ToString Then

                        GridColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        GridColumn.SummaryItem.DisplayFormat = "{0:n2}"

                    End If

                Next

            End If

        End Sub
        Private Sub DataGridViewInvoices_InvoiceData_MasterRowEmptyEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles DataGridViewInvoices_InvoiceData.MasterRowEmptyEvent

            e.IsEmpty = False

        End Sub
        Private Sub DataGridViewInvoices_InvoiceData_MasterRowExpandedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles DataGridViewInvoices_InvoiceData.MasterRowExpandedEvent

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            BaseView = DataGridViewInvoices_InvoiceData.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                BaseView.ClearSelection()

                BaseView.SelectRow(BaseView.SourceRowHandle)

                If BaseView.ChildGridLevelName = "ClientInvoiceDetailsLevel1Tab1" Then

                    If BaseView.RowCount > 0 Then

                        BaseView.SelectRow(0)

                    End If

                ElseIf BaseView.ChildGridLevelName = "ClientInvoiceGLTransactionsLevel1Tab2" Then

                    If BaseView.RowCount > 0 Then

                        BaseView.SelectRow(0)

                    End If

                ElseIf BaseView.ChildGridLevelName = "ClientInvoicePaymentHistoryLevel1Tab3" Then

                    If BaseView.RowCount > 0 Then

                        BaseView.SelectRow(0)

                    End If

                End If

                BaseView.BestFitColumns()

            End If

        End Sub
        Private Sub DataGridViewInvoices_InvoiceData_MasterRowGetChildListEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles DataGridViewInvoices_InvoiceData.MasterRowGetChildListEvent

            e.ChildList = LoadDetailLevel(e.RowHandle, e.RelationIndex, DataGridViewInvoices_InvoiceData.CurrentView)

        End Sub
        Private Sub DataGridViewInvoices_InvoiceData_MasterRowGetRelationCountEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles DataGridViewInvoices_InvoiceData.MasterRowGetRelationCountEvent

            e.RelationCount = 3

        End Sub
        Private Sub DataGridViewInvoices_InvoiceData_MasterRowGetRelationDisplayCaptionEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewInvoices_InvoiceData.MasterRowGetRelationDisplayCaptionEvent

            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim RowCount As Integer = 0

            BaseView = DataGridViewInvoices_InvoiceData.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                RowCount = BaseView.RowCount

                Select Case e.RelationIndex

                    Case 0

                        e.RelationName = RowCount & " Invoice Detail(s)"

                    Case 1

                        e.RelationName = RowCount & " GL Transaction(s)"

                    Case 2

                        e.RelationName = RowCount & " Payment History(ies)"

                End Select

            Else

                Select Case e.RelationIndex

                    Case 0

                        e.RelationName = " Invoice Detail(s)"

                    Case 1

                        e.RelationName = " GL Transaction(s)"

                    Case 2

                        e.RelationName = " Payment History(ies)"

                End Select

            End If

        End Sub
        Private Sub DataGridViewInvoices_InvoiceData_MasterRowGetRelationNameEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewInvoices_InvoiceData.MasterRowGetRelationNameEvent

            Select Case e.RelationIndex

                Case 0

                    e.RelationName = "ClientInvoiceDetailsLevel1Tab1"

                Case 1

                    e.RelationName = "ClientInvoiceGLTransactionsLevel1Tab2"

                Case 2

                    e.RelationName = "ClientInvoicePaymentHistoryLevel1Tab3"

            End Select

        End Sub
        Private Sub DataGridViewInvoices_InvoiceData_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewInvoices_InvoiceData.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

                If TabItemInvoiceDetails_DocumentsTab.Visible Then

                    LoadInvoiceDocuments()

                End If

            End If

        End Sub
        Private Sub DataGridViewInvoices_InvoiceData_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewInvoices_InvoiceData.ShowingEditorEvent

            If DataGridViewInvoices_InvoiceData.CurrentView.FocusedColumn.Name <> AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.VoidComment.ToString AndAlso ButtonItemClientInvoices_Voided.Checked Then

                e.Cancel = True

            End If

        End Sub
        Private Sub _GridViewClientInvoiceGLTransactionsLevel1Tab2_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles _GridViewClientInvoiceGLTransactionsLevel1Tab2.RowClick

            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim Transaction As Integer = 0

            If e.Clicks = 2 AndAlso e.Button = Windows.Forms.MouseButtons.Left Then

                GridView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

                If GridView IsNot Nothing AndAlso e.RowHandle >= 0 Then

                    Transaction = GridView.GetRowCellValue(e.RowHandle, AdvantageFramework.AccountReceivable.Classes.AccountReceivableTransaction.Properties.Transaction.ToString)

                    AdvantageFramework.FinanceAndAccounting.Presentation.GeneralLedgerTransactionDialog.ShowFormDialog(Transaction)

                End If

            End If

        End Sub
        Private Sub _GridViewClientInvoicePaymentHistoryLevel1Tab3_MasterRowEmpty(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles _GridViewClientInvoicePaymentHistoryLevel1Tab3.MasterRowEmpty

            e.IsEmpty = False

        End Sub
        Private Sub _GridViewClientInvoicePaymentHistoryLevel1Tab3_MasterRowExpanded(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles _GridViewClientInvoicePaymentHistoryLevel1Tab3.MasterRowExpanded

            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            BaseView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetDetailView(e.RowHandle, e.RelationIndex)

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                BaseView.ClearSelection()

                BaseView.SelectRow(BaseView.SourceRowHandle)

                If BaseView.ChildGridLevelName = "ClientInvoiceCheckDetailLevel2Tab1" Then

                    If BaseView.RowCount > 0 Then

                        BaseView.SelectRow(0)

                    End If

                End If

                BaseView.BestFitColumns()

            End If

        End Sub
        Private Sub _GridViewClientInvoicePaymentHistoryLevel1Tab3_MasterRowGetChildList(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles _GridViewClientInvoicePaymentHistoryLevel1Tab3.MasterRowGetChildList

            Dim ClientInvoicePayment As AdvantageFramework.AccountReceivable.Classes.ClientInvoicePayment = Nothing

            Try

                ClientInvoicePayment = DataGridViewInvoices_InvoiceData.GridControl.FocusedView.GetRow(e.RowHandle)

            Catch ex As Exception
                ClientInvoicePayment = Nothing
            End Try

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                e.ChildList = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoicePaymentCheckDetail)(String.Format("exec advsp_ar_invoice_select_check_detail {0}", ClientInvoicePayment.ClientCashReceiptID)).ToList

            End Using

        End Sub
        Private Sub _GridViewClientInvoicePaymentHistoryLevel1Tab3_MasterRowGetRelationCount(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles _GridViewClientInvoicePaymentHistoryLevel1Tab3.MasterRowGetRelationCount

            e.RelationCount = 1

        End Sub
        'Private Sub _GridViewClientInvoicePaymentHistoryLevel1Tab3_MasterRowGetRelationDisplayCaption(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles _GridViewClientInvoicePaymentHistoryLevel1Tab3.MasterRowGetRelationDisplayCaption

        '    Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        '    Dim RowCount As Integer = 0

        '    'BaseView = DataGridViewInvoices_InvoiceData.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

        '    BaseView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetDetailView(e.RowHandle, e.RelationIndex)

        '    'BaseView = DirectCast(DataGridViewInvoices_InvoiceData.CurrentView.GridControl.FocusedView, DevExpress.XtraGrid.Views.Grid.GridView).GetDetailView(e.RowHandle, e.RelationIndex)

        '    If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

        '        RowCount = BaseView.RowCount

        '        Select Case e.RelationIndex

        '            Case 0

        '                e.RelationName = RowCount & " Check Detail(s)"

        '        End Select

        '    Else

        '        Select Case e.RelationIndex

        '            Case 0

        '                e.RelationName = " Check Detail(s)"

        '        End Select

        '    End If

        'End Sub
        Private Sub _GridViewClientInvoicePaymentHistoryLevel1Tab3_MasterRowGetRelationName(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles _GridViewClientInvoicePaymentHistoryLevel1Tab3.MasterRowGetRelationName

            Select Case e.RelationIndex

                Case 0

                    e.RelationName = "ClientInvoiceCheckDetailLevel2Tab1"

            End Select

        End Sub
        Private Sub ButtonRightSection_Dates_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_Dates.Click

            Dim [From] As Date = Nothing
            Dim [To] As Date = Nothing

            [From] = _FromDate
            [To] = _ToDate

            If AdvantageFramework.WinForm.Presentation.SelectDateRangeDialog.ShowFormDialog([From], [To]) = Windows.Forms.DialogResult.OK Then

                _FromDate = [From]
                _ToDate = [To]

                LabelRightSection_DateRange.Text = _FromDate.ToShortDateString & " to " & _ToDate.ToShortDateString

                SetAverageDaysToPay()

            End If

        End Sub
        Private Sub TabControlRightSection_InvoiceDetails_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlRightSection_InvoiceDetails.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub DocumentManagerControlInvoices_Documents_SelectedDocumentChanged() Handles DocumentManagerControlInvoices_Documents.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemPrinting_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemPrinting_Export.Click

            DataGridViewInvoices_InvoiceData.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("Form", ""), UseLandscape:=True)

        End Sub
        Private Sub ButtonItemPrinting_PrintReport_Click(sender As Object, e As EventArgs) Handles ButtonItemPrinting_PrintReport.Click

            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim ClientInvoiceList As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoice) = Nothing
            Dim ClientCode As String = Nothing
            Dim [From] As Date = Nothing
            Dim [To] As Date = Nothing
            Dim ReportType As AdvantageFramework.Reporting.ReportTypes = AdvantageFramework.Reporting.ReportTypes.ClientInvoiceReport

            ClientCode = DataGridViewLeftSection_Clients.GetFirstSelectedRowBookmarkValue(0)

            If AdvantageFramework.FinanceAndAccounting.Presentation.ClientInvoiceReportDialog.ShowFormDialog(ReportType, ClientCode, [From], [To]) = System.Windows.Forms.DialogResult.OK Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ClientInvoiceList = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoice) _
                        (String.Format("exec advsp_ar_invoice_select_by_client '{0}','{1}'",
                                        Me.Session.UserCode,
                                        ClientCode)).ToList

                    ClientInvoiceList = ClientInvoiceList.Where(Function(CI) CI.InvoiceDate IsNot Nothing AndAlso CI.InvoiceDate.Value >= [From] AndAlso CI.InvoiceDate.Value <= [To]).ToList

                    If ClientInvoiceList.Count = 0 Then

                        AdvantageFramework.WinForm.MessageBox.Show("No client invoices match criteria.")

                    Else

                        ParameterDictionary = New Generic.Dictionary(Of String, Object)

                        ParameterDictionary.Add("DataSource", ClientInvoiceList)
                        ParameterDictionary.Add("ClientCode", ClientCode)
                        ParameterDictionary.Add("From", [From])
                        ParameterDictionary.Add("To", [To])

                        AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    End If

                End Using

            End If

        End Sub
        Private Sub ButtonItemQuickbooks_Send_Click(sender As Object, e As EventArgs) Handles ButtonItemQuickbooks_Send.Click

            'objects
            Dim ClientInvoices As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoice) = Nothing
            Dim Details As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoiceDetail) = Nothing
            Dim InvoiceNumber As Integer = 0
            Dim InvoiceSequenceNumber As Short = 0
            Dim Type As String = Nothing
            Dim ErrorMessage As String = Nothing
            Dim AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable = Nothing
            Dim Created As Boolean = False

            ClientInvoices = DataGridViewInvoices_InvoiceData.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoice).ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each ClientInvoice In ClientInvoices.Where(Function(CI) CI.QuickBooks = False AndAlso CI.IsManualInvoice = False AndAlso CI.IsVoided = False)

                    InvoiceNumber = ClientInvoice.InvoiceNumber
                    InvoiceSequenceNumber = ClientInvoice.SequenceNumber
                    Type = ClientInvoice.Type

                    AccountReceivable = AdvantageFramework.Database.Procedures.AccountReceivable.LoadByInvoiceNumberAndSequenceNumberAndType(DbContext, InvoiceNumber, InvoiceSequenceNumber, Type)

                    If AccountReceivable IsNot Nothing AndAlso String.IsNullOrWhiteSpace(AccountReceivable.QuickbooksInvoiceID) Then

                        Details = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoiceDetail) _
                                (String.Format("exec advsp_ar_invoice_select_summary_detail {0},{1},'{2}','{3}',{4},{5},{6}", InvoiceNumber, InvoiceSequenceNumber, Type, ClientInvoice.ClientCode, "NULL", "NULL", "NULL")).ToList

                        If AdvantageFramework.Quickbooks.CreateInvoice(Session, InvoiceNumber, InvoiceSequenceNumber, Type, _QBCustomerID, Details, ErrorMessage) = False Then

                            AdvantageFramework.WinForm.MessageBox.Show("Could not create QuickBooks invoice for:" & InvoiceNumber & vbCrLf & "Error:" & ErrorMessage & "")

                        Else

                            Created = True
                            ClientInvoice.QuickBooks = True

                        End If

                    End If

                Next

                If Created Then

                    DataGridViewInvoices_InvoiceData.CurrentView.RefreshData()
                    AdvantageFramework.WinForm.MessageBox.Show("Client invoices successfully sent to Quickbooks.")

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Nothing created, please select 'non-manual', non-voided and invoices not already sent to QuickBooks.")

                End If

            End Using

        End Sub

#End Region

#End Region

    End Class

End Namespace
