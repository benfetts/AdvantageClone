Imports DevExpress.XtraGrid.Views.Base

Namespace FinanceAndAccounting.Presentation

    Public Class AccountsPayableImportExpenseReportsForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _PreviousStatus1and4Invoices As Generic.List(Of Integer) = Nothing
        Private _PreviousStatus3Invoices As Generic.List(Of Integer) = Nothing
        Private _OfficeCode As String = Nothing
        Private _DepartmentTeamCode As String = Nothing
        Private _DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel = Database.Entities.DocumentSubLevel.Default

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub ApplyGrouping()

            Try

                DataGridViewInvoices_ExpenseReportData.OptionsView.ShowGroupedColumns = True
                DataGridViewInvoices_ExpenseReportData.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.EmployeeName.ToString).GroupIndex = 0
                DataGridViewInvoices_ExpenseReportData.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.InvoiceNumber.ToString).GroupIndex = 1
                DataGridViewInvoices_ExpenseReportData.CurrentView.ExpandAllGroups()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub EnableOrDisableActions(Optional ByVal IsTabChanging As Boolean = False)

            RibbonBarMergeContainerForm_Options.SuspendLayout()

            If IsTabChanging Then

                RibbonBarOptions_Actions.Visible = False
                RibbonBarOptions_OnHold.Visible = False
                RibbonBarOptions_Receipts.Visible = False
                RibbonBarOptions_Filter.Visible = False

            End If

            ButtonItemActions_Export.Enabled = DataGridViewInvoices_ExpenseReportData.HasRows
            ButtonItemActions_Approve.Enabled = DataGridViewInvoices_ExpenseReportData.HasRows
            ButtonItemActions_Deny.Enabled = DataGridViewInvoices_ExpenseReportData.HasRows
            ButtonItemActions_SetGLAccount.Enabled = DataGridViewInvoices_ExpenseReportData.HasRows
            ButtonItemActions_Receipts.Enabled = ExpenseDocumentsExist()

            TabItemExpenseReportDetails_ReceiptsTab.Visible = DataGridViewInvoices_ExpenseReportData.HasOnlyOneSelectedRow

            If TabControlForm_ExpenseReportDetails.SelectedTab.Equals(TabItemExpenseReportDetails_ReceiptsTab) AndAlso DataGridViewInvoices_ExpenseReportData.HasOnlyOneSelectedRow Then

                RibbonBarOptions_Receipts.Visible = True
                RibbonBarOptions_Filter.Visible = True

                ButtonItemReceipts_Download.Enabled = DocumentManagerControlReceipts_Receipts.HasASelectedDocument

            Else

                RibbonBarOptions_Actions.Visible = True
                RibbonBarOptions_OnHold.Visible = True

                ButtonItemReceipts_Download.Enabled = False

            End If

            RibbonBarMergeContainerForm_Options.ResumeLayout()

        End Sub
        Private Function ExpenseDocumentsExist() As Boolean

            Dim DocumentsExist As Boolean = False
            Dim AccountPayableExpenseReportItem As AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem = Nothing

            If DataGridViewInvoices_ExpenseReportData.HasOnlyOneSelectedRow Then

                AccountPayableExpenseReportItem = DataGridViewInvoices_ExpenseReportData.CurrentView.GetRow(DataGridViewInvoices_ExpenseReportData.CurrentView.FocusedRowHandle)

                If AccountPayableExpenseReportItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DocumentsExist = AdvantageFramework.Database.Procedures.ExpenseReportDocument.LoadByInvoiceNumber(DbContext, AccountPayableExpenseReportItem.InvoiceNumber).Any()

                    End Using

                End If

            End If

            ExpenseDocumentsExist = DocumentsExist

        End Function
        Private Sub LoadExpenseReportDocuments()

            'objects
            Dim AccountPayableExpenseReportItem As AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem = Nothing
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing

            AccountPayableExpenseReportItem = DataGridViewInvoices_ExpenseReportData.CurrentView.GetRow(DataGridViewInvoices_ExpenseReportData.CurrentView.FocusedRowHandle)

            If AccountPayableExpenseReportItem IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DocumentManagerControlReceipts_Receipts.ClearControl()

                    Try

                        If _DocumentSubLevel = Database.Entities.DocumentSubLevel.ExpenseDetailDocument Then

                            DocumentLevelSettings = (From Entity In DataGridViewInvoices_ExpenseReportData.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).ToList
                                                     Select New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts, _DocumentSubLevel) With {.ExpenseReportInvoiceNumber = AccountPayableExpenseReportItem.InvoiceNumber,
                                                                                                                                                                                                                      .ExpenseDetailID = AccountPayableExpenseReportItem.ExpenseReportDetailID}).ToList

                        End If

                    Catch ex As Exception
                        DocumentLevelSettings = Nothing
                    End Try

                    If DocumentLevelSettings Is Nothing OrElse DocumentLevelSettings.Count = 0 Then

                        DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                        DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts) With {.ExpenseReportInvoiceNumber = AccountPayableExpenseReportItem.InvoiceNumber})

                    End If

                    DocumentManagerControlReceipts_Receipts.Enabled = DocumentManagerControlReceipts_Receipts.LoadControl(AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts, DocumentLevelSettings,
                                                                                                                          AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl.Type.Default, _DocumentSubLevel)

                End Using

            End If

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim AccountPayableExpenseReportItemList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem) = Nothing
            Dim InvoiceNumberList As Generic.List(Of Integer) = Nothing

            Me.ShowWaitForm("Loading...")

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AccountPayableExpenseReportItemList = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem) _
                                                      (String.Format("exec advsp_ap_expense_report_import_items {0}, {1}, '{2}'",
                                                                     If(_OfficeCode IsNot Nothing, "'" & _OfficeCode & "'", "NULL"),
                                                                     If(_DepartmentTeamCode IsNot Nothing, "'" & _DepartmentTeamCode & "'", "NULL"),
                                                                     Session.UserCode)).ToList

                For Each AccountPayableExpenseReportItem In AccountPayableExpenseReportItemList

                    AccountPayableExpenseReportItem.Session = Session

                Next

                _PreviousStatus1and4Invoices = AccountPayableExpenseReportItemList.Where(Function(I) I.HeaderStatus = 1 OrElse I.HeaderStatus = 4).Select(Function(I) I.InvoiceNumber).Distinct.ToList

                _PreviousStatus3Invoices = AccountPayableExpenseReportItemList.Where(Function(I) I.HeaderStatus = 3).Select(Function(I) I.InvoiceNumber).Distinct.ToList

                InvoiceNumberList = AccountPayableExpenseReportItemList.Select(Function(I) I.InvoiceNumber).Distinct.ToList

                For Each ExpenseReport In AdvantageFramework.Database.Procedures.ExpenseReport.Load(DbContext).Where(Function(H) InvoiceNumberList.Contains(H.InvoiceNumber) = True).ToList

                    If AccountPayableExpenseReportItemList.Where(Function(APARI) APARI.InvoiceNumber = ExpenseReport.InvoiceNumber).Any(Function(APARI) APARI.CanModifyIsOnHold = True) Then

                        ExpenseReport.Status = 4

                        DbContext.UpdateObject(ExpenseReport)

                    End If

                Next

                DbContext.SaveChanges()

                AdvantageFramework.AccountPayable.ValidateAccountPayableExpenseReportItemList(DbContext, AccountPayableExpenseReportItemList, Session)

            End Using

            DataGridViewInvoices_ExpenseReportData.DataSource = AccountPayableExpenseReportItemList

            ApplyGrouping()

            DataGridViewInvoices_ExpenseReportData.CurrentView.BestFitColumns()

            If DataGridViewInvoices_ExpenseReportData.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.APComment.ToString) IsNot Nothing Then

                DataGridViewInvoices_ExpenseReportData.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.APComment.ToString).Width = 100

            End If

            If DataGridViewInvoices_ExpenseReportData.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.ClientName.ToString) IsNot Nothing Then

                DataGridViewInvoices_ExpenseReportData.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.ClientName.ToString).Width = 100

            End If

            If DataGridViewInvoices_ExpenseReportData.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.Status.ToString) IsNot Nothing Then

                DataGridViewInvoices_ExpenseReportData.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.Status.ToString).Width = 200

            End If

            DataGridViewInvoices_ExpenseReportData.CurrentView.ViewCaption = AccountPayableExpenseReportItemList.Select(Function(Entity) Entity.InvoiceNumber).Distinct.Count & " Expense Report(s)"

            If DataGridViewInvoices_ExpenseReportData.CurrentView.RowCount > 0 Then

                DataGridViewInvoices_ExpenseReportData.CurrentView.BeginSelection()

                DataGridViewInvoices_ExpenseReportData.CurrentView.ClearSelection()

                DataGridViewInvoices_ExpenseReportData.CurrentView.EndSelection()

            End If

            EnableOrDisableActions()

            Me.CloseWaitForm()

        End Sub
        Private Sub LoadReceiptsTab()

            Me.ShowWaitForm()

            LoadExpenseReportDocuments()

            TabItemExpenseReportDetails_ReceiptsTab.Tag = True

            Me.CloseWaitForm()

        End Sub
        Private Sub ResetExpenseHeaders()

            Dim ExpenseReportList As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReport) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ExpenseReportList = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReport.Load(DbContext)
                                     Where _PreviousStatus1and4Invoices.Contains(Entity.InvoiceNumber) = True
                                     Select Entity).ToList

                For Each ExpenseReport In ExpenseReportList

                    If ExpenseReport.Status = 4 Then

                        ExpenseReport.Status = 1
                        DbContext.UpdateObject(ExpenseReport)

                    End If

                Next

                DbContext.SaveChanges()


                ExpenseReportList = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReport.Load(DbContext)
                                     Where _PreviousStatus3Invoices.Contains(Entity.InvoiceNumber) = True
                                     Select Entity).ToList

                For Each ExpenseReport In ExpenseReportList

                    If ExpenseReport.Status = 4 Then

                        ExpenseReport.Status = 3
                        DbContext.UpdateObject(ExpenseReport)

                    End If

                Next

                DbContext.SaveChanges()

            End Using

        End Sub
        Private Function HasAnyInvalidRowsNotOnHoldOrNotFlaggedForDelete() As Boolean

            'objects
            Dim HasInvalidRows As Boolean = False
            Dim ValidatingClass As AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase = Nothing
            Dim IsOnHold As Boolean = False
            Dim FlaggedForDelete As Boolean = False

            Try

                For RowHandle = 0 To DataGridViewInvoices_ExpenseReportData.CurrentView.RowCount - 1

                    If DataGridViewInvoices_ExpenseReportData.CurrentView.IsDataRow(RowHandle) Then

                        IsOnHold = DirectCast(DirectCast(DataGridViewInvoices_ExpenseReportData.DataSource, System.Windows.Forms.BindingSource).Item(DataGridViewInvoices_ExpenseReportData.CurrentView.GetDataSourceRowIndex(RowHandle)), AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).IsOnHold
                        FlaggedForDelete = DirectCast(DirectCast(DataGridViewInvoices_ExpenseReportData.DataSource, System.Windows.Forms.BindingSource).Item(DataGridViewInvoices_ExpenseReportData.CurrentView.GetDataSourceRowIndex(RowHandle)), AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).Delete

                        If Not IsOnHold AndAlso Not FlaggedForDelete Then

                            Try

                                ValidatingClass = DirectCast(DataGridViewInvoices_ExpenseReportData.DataSource, System.Windows.Forms.BindingSource).Item(DataGridViewInvoices_ExpenseReportData.CurrentView.GetDataSourceRowIndex(RowHandle))

                            Catch ex As Exception
                                ValidatingClass = Nothing
                            End Try

                            If ValidatingClass IsNot Nothing Then

                                If ValidatingClass.HasError Then

                                    HasInvalidRows = True
                                    Exit For

                                End If

                            End If

                        End If

                    End If

                Next

            Catch ex As Exception
                HasInvalidRows = False
            End Try

            HasAnyInvalidRowsNotOnHoldOrNotFlaggedForDelete = HasInvalidRows

        End Function
        Private Sub LoadExpenseReportDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            If DataGridViewInvoices_ExpenseReportData.HasOnlyOneSelectedRow Then

                If TabItem Is Nothing Then

                    For Each TabItem In TabControlForm_ExpenseReportDetails.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                        TabItem.Tag = False

                    Next

                    TabItem = TabControlForm_ExpenseReportDetails.SelectedTab

                End If

                If TabItem.Tag = False Then

                    If TabItem Is TabItemExpenseReportDetails_ReceiptsTab Then

                        LoadReceiptsTab()

                    End If

                ElseIf TabItem Is TabItemExpenseReportDetails_ReceiptsTab Then

                    If _DocumentSubLevel = Database.Entities.DocumentSubLevel.ExpenseDetailDocument Then

                        FilterDocuments(Database.Entities.DocumentSubLevel.ExpenseDetailDocument)

                    End If

                End If

            Else

                DocumentManagerControlReceipts_Receipts.ClearControl()

            End If

        End Sub
        Private Sub FilterDocuments()

            'objects
            Dim DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel = Nothing

            If ButtonItemFilter_SelectedLineItem.Checked Then

                DocumentSubLevel = Database.Entities.DocumentSubLevel.ExpenseDetailDocument

            ElseIf ButtonItemFilter_All.Checked Then

                DocumentSubLevel = Database.Entities.DocumentSubLevel.Default

            End If

            FilterDocuments(DocumentSubLevel)

        End Sub
        Private Sub FilterDocuments(ByVal DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel)

            _DocumentSubLevel = DocumentSubLevel

            LoadExpenseReportDocuments()

            EnableOrDisableActions()

        End Sub
        Private Sub SetOnHold(ByVal Checked As Boolean)

            For Each Row In DataGridViewInvoices_ExpenseReportData.GetAllSelectedRowsDataBoundItems

                If DirectCast(Row, AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).CanModifyIsOnHold Then

                    DirectCast(Row, AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).IsOnHold = Checked

                End If

            Next

            DataGridViewInvoices_ExpenseReportData.SetUserEntryChanged()

            DataGridViewInvoices_ExpenseReportData.CurrentView.RefreshData()

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AccountsPayableImportExpenseReportsForm As AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableImportExpenseReportsForm = Nothing

            AccountsPayableImportExpenseReportsForm = New AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableImportExpenseReportsForm

            AccountsPayableImportExpenseReportsForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountsPayableImportExpenseReportsForm_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            ResetExpenseHeaders()

        End Sub
        Private Sub AccountsPayableImportExpenseReportsForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ByPassUserEntryChanged = True
            DataGridViewInvoices_ExpenseReportData.ByPassUserEntryChanged = True

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Search.Image = AdvantageFramework.My.Resources.ExpenseReportSearch
            ButtonItemActions_AutoFill.Image = AdvantageFramework.My.Resources.AutoFillImage
            ButtonItemActions_Approve.Image = AdvantageFramework.My.Resources.ExpenseReportApproved
            ButtonItemActions_Deny.Image = AdvantageFramework.My.Resources.ExpenseReportDenied
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemActions_SetGLAccount.Image = AdvantageFramework.My.Resources.GeneralLedgerReplaceImage
            ButtonItemActions_Receipts.Image = AdvantageFramework.My.Resources.DocumentManagerImage

            ButtonItemReceipts_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemReceipts_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemReceipts_Upload.Image = AdvantageFramework.My.Resources.UpdateImage

            ButtonItemFilter_All.Image = AdvantageFramework.My.Resources.TableSelectedAllImage
            ButtonItemFilter_SelectedLineItem.Image = AdvantageFramework.My.Resources.TableSelectedRowImage

            _PreviousStatus1and4Invoices = New Generic.List(Of Integer)
            _PreviousStatus3Invoices = New Generic.List(Of Integer)

            DataGridViewInvoices_ExpenseReportData.OptionsView.AllowHtmlDrawGroups = True
            DataGridViewInvoices_ExpenseReportData.ShowSelectDeselectAllButtons = True
            DataGridViewInvoices_ExpenseReportData.AutoFilterLookupColumns = True

            DataGridViewInvoices_ExpenseReportData.DataSource = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem)

            DataGridViewInvoices_ExpenseReportData.CurrentView.BestFitColumns()

            ButtonItemFilter_All.Checked = True
            ButtonItemFilter_SelectedLineItem.Checked = False

            TabItemExpenseReportDetails_ReceiptsTab.Visible = False

            EnableOrDisableActions()

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewInvoices_ExpenseReportData.CurrentView.CloseEditorForUpdating()

            DataGridViewInvoices_ExpenseReportData.OptionsPrint.AutoWidth = False

            DataGridViewInvoices_ExpenseReportData.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("Form", ""), UseLandscape:=True)

        End Sub
        Private Sub ButtonItemActions_Search_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Search.Click

            ResetExpenseHeaders()

            If AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableImportExpenseReportSearchDialog.ShowFormDialog(_OfficeCode, _DepartmentTeamCode) = Windows.Forms.DialogResult.OK Then

                LoadGrid()

            End If

        End Sub
        Private Sub ButtonItemActions_Approve_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Approve.Click

            Dim AccountPayableExpenseReportItems As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem) = Nothing
            Dim SelectedPostPeriods As IEnumerable = Nothing
            Dim PostPeriodCode As String = Nothing
            Dim Imported As Boolean = False
            Dim DisplayMessage As String = ""
            Dim PassedMessage As String = ""
            Dim FailedMessage As String = Nothing
            Dim SelectedInvoiceNumbers As Generic.List(Of Integer) = Nothing

            DisplayMessage = "Are you sure you want to continue?"
            PassedMessage = "All items were successfully saved."

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AdvantageFramework.AccountPayable.ValidateAccountPayableExpenseReportItemList(DbContext, DataGridViewInvoices_ExpenseReportData.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).ToList, Session)

            End Using

            SelectedInvoiceNumbers = DataGridViewInvoices_ExpenseReportData.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).Select(Function(Entity) Entity.InvoiceNumber).Distinct.ToList

            For Each InvoiceNumber In DataGridViewInvoices_ExpenseReportData.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).Where(Function(Entity) SelectedInvoiceNumbers.Contains(Entity.InvoiceNumber) AndAlso
                                                                                                                                                                                                                  Entity.IsOnHold OrElse
                                                                                                                                                                                                                  (Entity.HasError AndAlso
                                                                                                                                                                                                                   Not Entity.Delete)).Select(Function(Entity) Entity.InvoiceNumber).Distinct.ToList

                SelectedInvoiceNumbers.Remove(InvoiceNumber)

            Next

            AccountPayableExpenseReportItems = DataGridViewInvoices_ExpenseReportData.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).Where(Function(Entity) SelectedInvoiceNumbers.Contains(Entity.InvoiceNumber)).ToList

            Me.FormAction = WinForm.Presentation.FormActions.Adding
            Me.ShowWaitForm()
            Me.ShowWaitForm("Approving...")

            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

            If AccountPayableExpenseReportItems IsNot Nothing AndAlso AccountPayableExpenseReportItems.Any Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.PostPeriodActiveAP, True, True, SelectedPostPeriods, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedPostPeriods IsNot Nothing Then

                        Try

                            PostPeriodCode = (From Entity In SelectedPostPeriods
                                              Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            PostPeriodCode = Nothing
                        End Try

                    End If

                    If PostPeriodCode IsNot Nothing Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Imported = AdvantageFramework.AccountPayable.CreateInvoicesFromExpenseReportImport(DbContext, AccountPayableExpenseReportItems, PostPeriodCode, Me.Session, FailedMessage)

                        End Using

                    Else

                        FailedMessage = "Invalid post period selected."

                    End If

                End If

            ElseIf DataGridViewInvoices_ExpenseReportData.HasRows Then

                FailedMessage = "Nothing to save.  Selected invoices are either marked 'On Hold', or 'Delete' or have errors."

            Else

                FailedMessage = "Nothing to save."

            End If

            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            If Imported Then

                AdvantageFramework.WinForm.MessageBox.Show(PassedMessage, WinForm.MessageBox.MessageBoxButtons.OK)

            ElseIf FailedMessage IsNot Nothing Then

                AdvantageFramework.WinForm.MessageBox.Show(FailedMessage, WinForm.MessageBox.MessageBoxButtons.OK)

            End If

            ResetExpenseHeaders()

            LoadGrid()


        End Sub
        Private Sub ButtonItemActions_Deny_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Deny.Click

            Dim Imported As Boolean = False
            Dim PassedMessage As String = ""
            Dim FailedMessage As String = Nothing
            Dim SelectedInvoiceNumbers As Generic.List(Of Integer) = Nothing

            PassedMessage = "All items were successfully saved."

            'Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            '    AdvantageFramework.AccountPayable.ValidateAccountPayableExpenseReportItemList(DbContext, DataGridViewInvoices_ExpenseReportData.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).ToList, Session)

            'End Using

            SelectedInvoiceNumbers = DataGridViewInvoices_ExpenseReportData.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).Select(Function(Entity) Entity.InvoiceNumber).Distinct.ToList

            'For Each InvoiceNumber In DataGridViewInvoices_ExpenseReportData.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).Where(Function(Entity) SelectedInvoiceNumbers.Contains(Entity.InvoiceNumber) AndAlso
            '                                                                                                                                                                                                      (Entity.IsOnHold OrElse
            '                                                                                                                                                                                                       Entity.Delete OrElse
            '                                                                                                                                                                                                       Entity.HasError)).Select(Function(Entity) Entity.InvoiceNumber).Distinct.ToList

            '    SelectedInvoiceNumbers.Remove(InvoiceNumber)

            'Next

            Me.FormAction = WinForm.Presentation.FormActions.Adding
            Me.ShowWaitForm()
            Me.ShowWaitForm("Denying...")

            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

            If SelectedInvoiceNumbers IsNot Nothing AndAlso SelectedInvoiceNumbers.Count > 0 Then

                If AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableDenyExpenseReportDialog.ShowFormDialog(SelectedInvoiceNumbers.ToArray) = Windows.Forms.DialogResult.OK Then

                    Imported = True

                End If

            ElseIf DataGridViewInvoices_ExpenseReportData.HasRows Then

                FailedMessage = "Nothing to save.  Selected invoices are either marked 'On Hold', or 'Delete' or have errors."

            Else

                FailedMessage = "Nothing to save."

            End If

            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            If Imported Then

                AdvantageFramework.WinForm.MessageBox.Show(PassedMessage, WinForm.MessageBox.MessageBoxButtons.OK)

            ElseIf FailedMessage IsNot Nothing Then

                AdvantageFramework.WinForm.MessageBox.Show(FailedMessage, WinForm.MessageBox.MessageBoxButtons.OK)

            End If

            ResetExpenseHeaders()

            LoadGrid()

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Print.Click

            Dim UserCode As String = Nothing
            Dim BatchDate As Date = Nothing
            Dim AccountPayableExpenseImportBatchReportList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseImportBatchReport) = Nothing
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim ReportRange As String = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBatchDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim DetailPageBreak As Boolean = False

            UserCode = Me.Session.UserCode

            If AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableBatchReportDialog.ShowFormDialog(UserCode, BatchDate, DetailPageBreak) = System.Windows.Forms.DialogResult.OK Then

                SqlParameterUserCode = New SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)
                SqlParameterBatchDate = New SqlClient.SqlParameter("@batch_date", SqlDbType.SmallDateTime)

                SqlParameterUserCode.Value = UserCode
                SqlParameterBatchDate.Value = BatchDate

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AccountPayableExpenseImportBatchReportList = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseImportBatchReport)("exec advsp_ap_expense_import_batch_report @user_code, @batch_date", SqlParameterUserCode, SqlParameterBatchDate).ToList

                End Using

                ReportRange = "AP Expense Report Batch: " & BatchDate.ToString

                ParameterDictionary = New Generic.Dictionary(Of String, Object)

                ParameterDictionary.Add("DataSource", AccountPayableExpenseImportBatchReportList)
                ParameterDictionary.Add("ForUser", UserCode)
                ParameterDictionary.Add("ReportRange", ReportRange)
                ParameterDictionary.Add("DetailPageBreak", DetailPageBreak)

                AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.AccountPayableImportExpenseReport, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

            End If

        End Sub
        Private Sub ButtonItemActions_Receipts_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Receipts.Click

            FilterDocuments(Database.Entities.DocumentSubLevel.Default)

            ButtonItemFilter_All.Checked = True
            ButtonItemFilter_SelectedLineItem.Checked = False

            TabControlForm_ExpenseReportDetails.SelectedTab = TabItemExpenseReportDetails_ReceiptsTab

        End Sub
        Private Sub ButtonItemActions_SetGLAccount_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_SetGLAccount.Click

            Dim AccountPayableExpenseReportItemList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim NumberReplaced As Integer = 0
            Dim OfficeCode As String = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            DataGridViewInvoices_ExpenseReportData.CurrentView.CloseEditorForUpdating()

            AccountPayableExpenseReportItemList = DataGridViewInvoices_ExpenseReportData.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each AccountPayableExpenseReportItem In AccountPayableExpenseReportItemList

                    If (AccountPayableExpenseReportItem.JobNumber Is Nothing OrElse (AccountPayableExpenseReportItem.JobNumber.HasValue AndAlso AccountPayableExpenseReportItem.IsNonbillable.GetValueOrDefault(0) = 1)) AndAlso
                            AccountPayableExpenseReportItem.IsOnHold = False AndAlso AccountPayableExpenseReportItem.GLACode IsNot Nothing Then

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, AccountPayableExpenseReportItem.EmployeeCode)

                        If Employee IsNot Nothing Then

                            If AccountPayableExpenseReportItem.IsNonbillable.GetValueOrDefault(0) = 0 AndAlso String.IsNullOrWhiteSpace(Employee.OfficeCode) = False Then

                                OfficeCode = Employee.OfficeCode

                            Else

                                If AccountPayableExpenseReportItem.JobNumber Is Nothing Then

                                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, Employee.EmployeeVendorCode)

                                    If Vendor IsNot Nothing AndAlso Vendor.GeneralLedgerAccount IsNot Nothing AndAlso Vendor.GeneralLedgerAccount.GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                        OfficeCode = Vendor.GeneralLedgerAccount.GeneralLedgerOfficeCrossReference.OfficeCode

                                    End If

                                Else

                                    OfficeCode = AccountPayableExpenseReportItem.OfficeCode

                                End If

                            End If

                        End If

                        If Employee IsNot Nothing AndAlso String.IsNullOrWhiteSpace(OfficeCode) = False Then

                            GeneralLedgerAccount = AdvantageFramework.GeneralLedger.SubstituteOfficeDepartmentSegments(DbContext, AccountPayableExpenseReportItem.GLACode, OfficeCode, Employee.DepartmentTeamCode)

                            If GeneralLedgerAccount IsNot Nothing Then

                                AccountPayableExpenseReportItem.GLACode = GeneralLedgerAccount.Code

                                If GeneralLedgerAccount.GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                    AccountPayableExpenseReportItem.OfficeCode = GeneralLedgerAccount.GeneralLedgerOfficeCrossReference.OfficeCode

                                End If

                                NumberReplaced += 1

                            End If

                        End If

                    End If

                Next

            End Using

            DataGridViewInvoices_ExpenseReportData.ValidateAllRows()

            DataGridViewInvoices_ExpenseReportData.CurrentView.RefreshData()

            AdvantageFramework.WinForm.MessageBox.Show(NumberReplaced.ToString & " GL Account(s) adjusted.")

        End Sub
        Private Sub DataGridViewInvoices_ExpenseReportData_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewInvoices_ExpenseReportData.CellValueChangedEvent

            'objects
            Dim AccountPayableExpenseReportItem As AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem = Nothing

            AccountPayableExpenseReportItem = DataGridViewInvoices_ExpenseReportData.CurrentView.GetRow(e.RowHandle)

            If AccountPayableExpenseReportItem IsNot Nothing Then

                If e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.JobNumber.ToString Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        If AccountPayableExpenseReportItem.JobNumber Is Nothing Then

                            AccountPayableExpenseReportItem.ClientName = Nothing
                            AccountPayableExpenseReportItem.JobComponentNumber = Nothing
                            AccountPayableExpenseReportItem.FunctionCode = Nothing
                            AccountPayableExpenseReportItem.GLACode = Nothing

                        End If

                        AccountPayableExpenseReportItem.SetBillingRateValues(DbContext)

                    End Using

                    DataGridViewInvoices_ExpenseReportData.CurrentView.RefreshRow(e.RowHandle)

                ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.FunctionCode.ToString Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        AccountPayableExpenseReportItem.SetBillingRateValues(DbContext)

                        'If AccountPayableExpenseReportItem.JobNumber Is Nothing Then

                        '    AccountPayableExpenseReportItem.SetGLACodeBasedOnFunction(DbContext)

                        'End If

                    End Using

                    DataGridViewInvoices_ExpenseReportData.CurrentView.RefreshRow(e.RowHandle)

                ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.JobComponentNumber.ToString Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        AccountPayableExpenseReportItem.SetBillingRateValues(DbContext)
                        DataGridViewInvoices_ExpenseReportData.CurrentView.RefreshRow(e.RowHandle)

                    End Using

                ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.GLACode.ToString Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        AccountPayableExpenseReportItem.SetOfficeByGLACode(DbContext)

                    End Using

                End If

            End If

        End Sub
        Private Sub DataGridViewInvoices_ExpenseReportData_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewInvoices_ExpenseReportData.CellValueChangingEvent

            Dim AccountPayableExpenseReportItem As AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim AccountPayableExpenseReportItemList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem) = Nothing

            Try

                AccountPayableExpenseReportItem = DataGridViewInvoices_ExpenseReportData.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                AccountPayableExpenseReportItem = Nothing
            End Try

            If AccountPayableExpenseReportItem IsNot Nothing Then

                If e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.IsOnHold.ToString Then

                    BindingSource = DataGridViewInvoices_ExpenseReportData.DataSource

                    AccountPayableExpenseReportItemList = BindingSource.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem)() _
                                                                    .Where(Function(Entity) Entity.VendorCode = AccountPayableExpenseReportItem.VendorCode AndAlso
                                                                                            Entity.InvoiceNumber = AccountPayableExpenseReportItem.InvoiceNumber).ToList

                    For Each AccountPayableExpenseReportItem In AccountPayableExpenseReportItemList

                        AccountPayableExpenseReportItem.IsOnHold = e.Value
                        AccountPayableExpenseReportItem.Delete = False

                    Next

                    DataGridViewInvoices_ExpenseReportData.CurrentView.RefreshData()

                    EnableOrDisableActions()

                ElseIf e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.Delete.ToString Then

                    BindingSource = DataGridViewInvoices_ExpenseReportData.DataSource

                    AccountPayableExpenseReportItemList = BindingSource.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem)() _
                                                                    .Where(Function(Entity) Entity.VendorCode = AccountPayableExpenseReportItem.VendorCode AndAlso
                                                                                            Entity.InvoiceNumber = AccountPayableExpenseReportItem.InvoiceNumber).ToList

                    For Each AccountPayableExpenseReportItem In AccountPayableExpenseReportItemList

                        AccountPayableExpenseReportItem.Delete = e.Value
                        AccountPayableExpenseReportItem.IsOnHold = False

                    Next

                    DataGridViewInvoices_ExpenseReportData.CurrentView.RefreshData()

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        'Private Sub DataGridViewInvoices_ExpenseReportData_CustomDrawGroupRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles DataGridViewInvoices_ExpenseReportData.CustomDrawGroupRowEvent

        '    Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        '    Dim GridGroupRowInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = Nothing
        '    Dim AccountPayableExpenseReportItem As AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem = Nothing

        '    GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        '    GridGroupRowInfo = TryCast(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo)

        '    If GridView IsNot Nothing AndAlso GridGroupRowInfo IsNot Nothing Then

        '        If GridGroupRowInfo.Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.InvoiceNumber.ToString Then

        '            AccountPayableExpenseReportItem = DataGridViewInvoices_ExpenseReportData.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem)().Where(Function(Entity) Entity.InvoiceNumber = GridGroupRowInfo.EditValue).FirstOrDefault

        '            If AccountPayableExpenseReportItem IsNot Nothing Then

        '                GridGroupRowInfo.GroupText = "Invoice Number: " & AccountPayableExpenseReportItem.InvoiceNumber & " | " &
        '                                             "<color=Blue>Vendor Code: " & AccountPayableExpenseReportItem.VendorCode & "</color> | " &
        '                                             "<color=Purple>Invoice Date: " & AccountPayableExpenseReportItem.InvoiceDate.Value.ToShortDateString & "</color> | " &
        '                                             "<color=Green>Invoice Description: " & AccountPayableExpenseReportItem.InvoiceDescription & "</color>"

        '            End If

        '        End If

        '    End If

        'End Sub
        Private Sub DataGridViewInvoices_ExpenseReportData_CustomColumnDisplayTextEvent(sender As Object, e As CustomColumnDisplayTextEventArgs) Handles DataGridViewInvoices_ExpenseReportData.CustomColumnDisplayTextEvent

            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim GridGroupRowInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = Nothing
            Dim AccountPayableExpenseReportItem As AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem = Nothing

            GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            If GridView IsNot Nothing Then
                If e.IsForGroupRow Then
                    If e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.InvoiceNumber.ToString Then

                        AccountPayableExpenseReportItem = DataGridViewInvoices_ExpenseReportData.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem)().Where(Function(Entity) Entity.InvoiceNumber = e.Value).FirstOrDefault

                        If AccountPayableExpenseReportItem IsNot Nothing Then

                            e.DisplayText = AccountPayableExpenseReportItem.InvoiceNumber & " | " &
                                            "Vendor Code: " & AccountPayableExpenseReportItem.VendorCode & " | " &
                                            "Invoice Date: " & AccountPayableExpenseReportItem.InvoiceDate.Value.ToShortDateString & " | " &
                                            "Invoice Description: " & AccountPayableExpenseReportItem.InvoiceDescription &
                                            If(AccountPayableExpenseReportItem.HasHeaderDocuments, " | <color=Green>Has Documents</color>", "")

                        End If

                    End If
                End If
            End If

        End Sub
        Private Sub DataGridViewInvoices_ExpenseReportData_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewInvoices_ExpenseReportData.QueryPopupNeedDatasourceEvent

            Dim JobNumber As Integer = 0
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim OfficeCode As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, DataGridViewInvoices_ExpenseReportData.CurrentView.GetRowCellValue(DataGridViewInvoices_ExpenseReportData.CurrentView.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.VendorCode.ToString))

                If AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext) Then

                    If Vendor.GeneralLedgerAccount IsNot Nothing AndAlso Vendor.GeneralLedgerAccount.GeneralLedgerOfficeCrossReference IsNot Nothing Then

                        OfficeCode = Vendor.GeneralLedgerAccount.GeneralLedgerOfficeCrossReference.OfficeCode

                    End If

                End If

                Select Case FieldName

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.JobNumber.ToString

                        OverrideDefaultDatasource = True

                        Datasource = AdvantageFramework.AccountPayable.GetAvailableProductionJobs(DbContext, DbContext.UserCode, OfficeCode, Nothing, Nothing, Nothing)

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.JobComponentNumber.ToString

                        OverrideDefaultDatasource = True

                        JobNumber = DataGridViewInvoices_ExpenseReportData.CurrentView.GetRowCellValue(DataGridViewInvoices_ExpenseReportData.CurrentView.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.JobNumber.ToString)

                        If JobNumber <> 0 Then

                            Datasource = AdvantageFramework.AccountPayable.GetJobComponentsByJob(DbContext, JobNumber)

                        Else

                            Datasource = Nothing

                        End If

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.FunctionCode.ToString

                        OverrideDefaultDatasource = True

                        Datasource = AdvantageFramework.Database.Procedures.Function.LoadAllActiveVendorFunctions(DbContext).ToList

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.GLACode.ToString

                        OverrideDefaultDatasource = True

                        If DataGridViewInvoices_ExpenseReportData.CurrentView.GetRowCellValue(DataGridViewInvoices_ExpenseReportData.CurrentView.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.JobNumber.ToString) IsNot Nothing Then

                            Datasource = AdvantageFramework.AccountPayable.GetProductionGLAccountList(DbContext, OfficeCode, Session)

                        Else

                            Datasource = AdvantageFramework.AccountPayable.GetNonClientGLAccountList(DbContext, Session, OfficeCode, Nothing)

                        End If

                End Select

            End Using

        End Sub
        Private Sub DataGridViewInvoices_ExpenseReportData_RowDoubleClickEvent() Handles DataGridViewInvoices_ExpenseReportData.RowDoubleClickEvent

            FilterDocuments(Database.Entities.DocumentSubLevel.ExpenseDetailDocument)

            If _DocumentSubLevel = Database.Entities.DocumentSubLevel.ExpenseDetailDocument Then

                ButtonItemFilter_All.Checked = False
                ButtonItemFilter_SelectedLineItem.Checked = True

            Else

                ButtonItemFilter_All.Checked = True
                ButtonItemFilter_SelectedLineItem.Checked = False

            End If

            TabControlForm_ExpenseReportDetails.SelectedTab = TabItemExpenseReportDetails_ReceiptsTab

        End Sub
        Private Sub DataGridViewInvoices_ExpenseReportData_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewInvoices_ExpenseReportData.SelectionChangedEvent

            TabItemExpenseReportDetails_ReceiptsTab.Tag = False

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewInvoices_ExpenseReportData_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewInvoices_ExpenseReportData.ShowingEditorEvent

            If DataGridViewInvoices_ExpenseReportData.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.HasDocuments.ToString Then

                e.Cancel = True

            ElseIf DirectCast(DataGridViewInvoices_ExpenseReportData.CurrentView.GetRow(DataGridViewInvoices_ExpenseReportData.CurrentView.FocusedRowHandle), AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).CanModifyIsOnHold = False AndAlso
                    DirectCast(DataGridViewInvoices_ExpenseReportData.CurrentView.GetRow(DataGridViewInvoices_ExpenseReportData.CurrentView.FocusedRowHandle), AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).IsOnHold = True Then

                e.Cancel = True

            ElseIf DataGridViewInvoices_ExpenseReportData.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.GLACode.ToString Then

                If DirectCast(DataGridViewInvoices_ExpenseReportData.CurrentView.GetRow(DataGridViewInvoices_ExpenseReportData.CurrentView.FocusedRowHandle), AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).IsNonbillable = 0 Then

                    e.Cancel = True

                ElseIf DirectCast(DataGridViewInvoices_ExpenseReportData.CurrentView.GetRow(DataGridViewInvoices_ExpenseReportData.CurrentView.FocusedRowHandle), AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).IsSystemGenerated AndAlso
                        DirectCast(DataGridViewInvoices_ExpenseReportData.CurrentView.GetRow(DataGridViewInvoices_ExpenseReportData.CurrentView.FocusedRowHandle), AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).CreditCardGLAccountIsEmpty = False Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewInvoices_ExpenseReportData.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.JobComponentNumber.ToString AndAlso
                    DirectCast(DataGridViewInvoices_ExpenseReportData.CurrentView.GetRow(DataGridViewInvoices_ExpenseReportData.CurrentView.FocusedRowHandle), AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem).JobNumber.GetValueOrDefault(0) = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewInvoices_ExpenseReportData_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewInvoices_ExpenseReportData.ShownEditorEvent

            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing

            If TypeOf DataGridViewInvoices_ExpenseReportData.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit AndAlso
                    DataGridViewInvoices_ExpenseReportData.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.JobNumber.ToString Then

                GridLookUpEdit = DataGridViewInvoices_ExpenseReportData.CurrentView.ActiveEditor

                If GridLookUpEdit.Properties.View.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableProductionJobs.Properties.ClientCode.ToString) IsNot Nothing Then

                    GridLookUpEdit.Properties.View.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableProductionJobs.Properties.ClientCode.ToString).Visible = True

                End If

                If GridLookUpEdit.Properties.View.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableProductionJobs.Properties.DivisionCode.ToString) IsNot Nothing Then

                    GridLookUpEdit.Properties.View.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableProductionJobs.Properties.DivisionCode.ToString).Visible = True

                End If

                If GridLookUpEdit.Properties.View.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableProductionJobs.Properties.ProductCode.ToString) IsNot Nothing Then

                    GridLookUpEdit.Properties.View.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableProductionJobs.Properties.ProductCode.ToString).Visible = True

                End If

            End If

        End Sub
        Private Sub ButtonItemReceipts_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemReceipts_Download.Click

            DocumentManagerControlReceipts_Receipts.DownloadSelectedDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub TabControlForm_ExpenseReportDetails_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlForm_ExpenseReportDetails.SelectedTabChanged

            LoadExpenseReportDetails(e.NewTab)

            EnableOrDisableActions(True)

            DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuspendedForLoading = False

        End Sub
        Private Sub TabControlForm_ExpenseReportDetails_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlForm_ExpenseReportDetails.SelectedTabChanging

            DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuspendedForLoading = True

        End Sub
        Private Sub ButtonItemFilter_All_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_All.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Refreshing

                ButtonItemFilter_SelectedLineItem.Checked = Not ButtonItemFilter_All.Checked

                FilterDocuments()

                Me.FormAction = WinForm.Presentation.FormActions.None

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemFilter_SelectedLineItem_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_SelectedLineItem.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Refreshing

                ButtonItemFilter_All.Checked = Not ButtonItemFilter_SelectedLineItem.Checked

                FilterDocuments()

                Me.FormAction = WinForm.Presentation.FormActions.None

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemOnHold_Check_Click(sender As Object, e As EventArgs) Handles ButtonItemOnHold_Check.Click

            SetOnHold(True)

        End Sub
        Private Sub ButtonItemOnHold_Uncheck_Click(sender As Object, e As EventArgs) Handles ButtonItemOnHold_Uncheck.Click

            SetOnHold(False)

        End Sub

#End Region

#End Region

    End Class

End Namespace
