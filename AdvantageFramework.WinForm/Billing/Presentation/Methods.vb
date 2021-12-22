Namespace Billing.Presentation

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub AddSubItemImageComboBox(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            Dim RepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox = Nothing
            Dim ImagesCollection As DevExpress.Utils.ImageCollection = Nothing

            RepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox

            ImagesCollection = New DevExpress.Utils.ImageCollection

            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatGreenCircleImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatYellowCircleImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatRedCircleImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatDarkBlueCircleImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallRedCircleOutlineImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatOrangeCircleImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatPurpleCircleImage)

            RepositoryItemImageComboBox.SmallImages = ImagesCollection

            RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Progress Bill - Green", 1, 0))
            RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Advance Bill - Yellow", 2, 1))
            RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Job on Permanent Bill Hold - Red", 3, 2))
            RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Job on Temporary Bill Hold - Blue", 4, 3))
            RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Job Details on Hold - Half Red", 5, 4))
            RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Reconciled - Orange", 6, 5))
            RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Final Reconciled w/Pending Advance Bill- Purple", 7, 6))

            RepositoryItemImageComboBox.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center

            If RepositoryItemImageComboBox.Buttons.VisibleCount = 1 Then

                RepositoryItemImageComboBox.Buttons(0).Visible = False

            End If

            DataGridView.GridControl.RepositoryItems.Add(RepositoryItemImageComboBox)

            GridColumn.ColumnEdit = RepositoryItemImageComboBox

        End Sub
        Public Sub AddSubItemImageCheckBox(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            Dim SubItemImageCheckEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageCheckEditControl = Nothing

            SubItemImageCheckEditControl = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemImageCheckBox(True, AdvantageFramework.WinForm.Presentation.Controls.SubItemImageCheckEditControl.Type.ImageWhenChecked, GetType(AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary), AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary.Properties.IsSelected.ToString)

            If SubItemImageCheckEditControl IsNot Nothing Then

                DataGridView.GridControl.RepositoryItems.Add(SubItemImageCheckEditControl)

                GridColumn.ColumnEdit = SubItemImageCheckEditControl

            End If

        End Sub
        Public Sub AddSubItemMemoItem(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn,
                                      ByVal Session As AdvantageFramework.Security.Session)

            Dim SubItemMemoEdit As AdvantageFramework.WinForm.Presentation.Controls.SubItemMemoEdit = Nothing

            SubItemMemoEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemMemoEdit(Session, GridColumn.FieldName, Nothing) '_ObjectType)

            If SubItemMemoEdit IsNot Nothing Then

                DataGridView.GridControl.RepositoryItems.Add(SubItemMemoEdit)

                GridColumn.ColumnEdit = SubItemMemoEdit

            End If

        End Sub
        Public Sub AddSubItemImageComboBoxMediaBillStatus(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            Dim RepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox = Nothing
            Dim ImagesCollection As DevExpress.Utils.ImageCollection = Nothing

            RepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox

            ImagesCollection = New DevExpress.Utils.ImageCollection

            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatGreenCircleImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatYellowCircleImage)

            RepositoryItemImageComboBox.SmallImages = ImagesCollection

            RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Prebill - Green", 1, 0))
            RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Post Bill - Yellow", 2, 1))

            RepositoryItemImageComboBox.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center

            If RepositoryItemImageComboBox.Buttons.VisibleCount = 1 Then

                RepositoryItemImageComboBox.Buttons(0).Visible = False

            End If

            DataGridView.GridControl.RepositoryItems.Add(RepositoryItemImageComboBox)

            GridColumn.ColumnEdit = RepositoryItemImageComboBox

        End Sub
        Public Sub SetColumnAsSumColumn(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal ColumnName As String)

            If DataGridView.Columns(ColumnName) IsNot Nothing Then

                If DataGridView.Columns(ColumnName).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                    DataGridView.Columns(ColumnName).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridView.Columns(ColumnName).SummaryItem.DisplayFormat = "{0:n2}"

                End If

            End If

        End Sub
        Public Function ProcessInvoices(ByVal Session As AdvantageFramework.Security.Session, ByVal BillingCommandCenterID As Integer,
                                        ByRef BillingStatus As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingStatus,
                                        ByVal BypassInvoiceDatePostPeriodConfirmation As Boolean) As Boolean

            'objects
            Dim BillingCommandCenterInvoiceDatePostPeriod As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingCommandCenterInvoiceDatePostPeriod = Nothing
            Dim BillingSelectionCriteria As AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria = Nothing
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim Result As Integer = Nothing
            Dim Message As String = Nothing
            Dim ErrorMessage As String = Nothing
            Dim ReturnValue As Short = 0
            Dim Processed As Boolean = False

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, BillingCommandCenterID)

                If BillingCommandCenter IsNot Nothing Then

                    BillingCommandCenterInvoiceDatePostPeriod = AdvantageFramework.BillingCommandCenter.GetBillingCommandCenterInvoiceDatePostPeriod(BCCDbContext, BillingCommandCenter.BillingUser)

                    If BillingCommandCenterInvoiceDatePostPeriod IsNot Nothing Then

                        BillingSelectionCriteria = New AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria(BillingCommandCenterInvoiceDatePostPeriod)

                        If BypassInvoiceDatePostPeriodConfirmation OrElse AdvantageFramework.WinForm.Presentation.GenericPropertyGridDialog.ShowFormDialog("Confirm Options", BillingSelectionCriteria, False) = Windows.Forms.DialogResult.OK Then

                            AdvantageFramework.BillingCommandCenter.UpdateBillingSelectionInvoiceDatePostPeriodCode(BCCDbContext, BillingSelectionCriteria.InvoiceDate, BillingSelectionCriteria.PostPeriodCode, BillingCommandCenter.BillingUser, BillingSelectionCriteria)

                            'exec dbo.advsp_get_bcc_coop_dist_prod 'SYSADM',0

                            'GetBillingStatus(BCCDbContext, BillingCommandCenter.ID)

                            AdvantageFramework.BillingCommandCenter.PopulateARCoopTmp(BCCDbContext, BillingCommandCenter.BillingUser)

                            Result = AdvantageFramework.BillingCommandCenter.PopulateARFunction(BCCDbContext, BillingCommandCenter.BillingUser)

                            Select Case Result

                                Case 0

                                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                        If AdvantageFramework.Agency.GetOptionAvaTaxEnabled(DbContext) Then

                                            AdvantageFramework.Billing.Presentation.AvaTaxProcessDialog.ShowFormDialog(Session.ConnectionString, BillingCommandCenter.BillingUser, AvaTaxProcessDialog.AvaTaxMode.CalculateTax, Session.UserCode, ErrorMessage, ReturnValue)

                                            If ReturnValue = 0 Then

                                                AdvantageFramework.WinForm.MessageBox.Show("AvaTax values successfully calculated.")

                                                AdvantageFramework.BillingCommandCenter.UpdateBillingSetInvoicesProcessedFlag(BCCDbContext, BillingCommandCenter.BillingUser, True)

                                                Processed = True

                                            Else

                                                If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                                                End If

                                            End If

                                        Else

                                            AdvantageFramework.BillingCommandCenter.UpdateBillingSetInvoicesProcessedFlag(BCCDbContext, BillingCommandCenter.BillingUser, True)

                                            Processed = True

                                        End If

                                    End Using

                                    BillingStatus = AdvantageFramework.BillingCommandCenter.GetBillingStatus(BCCDbContext, BillingCommandCenter.ID)

                                Case -1

                                    Message = "Invoices have already been assigned."

                                Case -3

                                    Message = "No billing record exists for the current user."

                                Case -4

                                    Message = "Another user currently has invoice assignment locked."

                                Case -5

                                    Message = "A co-op code used in the selection does not sum to 100%."

                                Case -6

                                    Message = "A NULL office code was returned. Please ensure your set up for the coop split by newspaper quantity feature is complete."

                                Case -10

                                    Message = "The deferred posting period is invalid or closed."

                                Case -11

                                    Message = "Invoice tax has been specified but detail level tax is present in the selection."

                                Case Else

                                    Message = "An error occurred while assigning invoices.  Please contact software support."

                            End Select

                            If Message IsNot Nothing Then

                                AdvantageFramework.WinForm.MessageBox.Show(Message)

                            End If

                            'SELECT COUNT ( *) FROM dbo.advtf_get_billing_function_var ( 'SYSADM' ) 

                        End If

                    End If

                End If

            End Using

            ProcessInvoices = Processed

        End Function
        Public Function AssignInvoices(ByVal Session As AdvantageFramework.Security.Session, ByVal BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter,
                                       ByRef BillingStatus As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingStatus,
                                       Optional ByVal ShowInvoicesAssignedDialog As Boolean = True) As Boolean

            Dim AssignInvoicesList As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.AssignInvoices) = Nothing
            Dim Message As String = Nothing
            Dim RejectedCoopJobs As IEnumerable(Of String) = Nothing
            Dim ErrorMessage As String = Nothing
            Dim ReturnValue As Short = 0
            Dim Assigned As Boolean = False
            Dim RejectedCoopOrders As IEnumerable(Of String) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If AdvantageFramework.Agency.GetOptionAvaTaxEnabled(DbContext) Then

                        AdvantageFramework.Billing.Presentation.AvaTaxProcessDialog.ShowFormDialog(Session.ConnectionString, BillingCommandCenter.BillingUser, AvaTaxProcessDialog.AvaTaxMode.PostTax, Session.UserCode, ErrorMessage, ReturnValue)

                        If ReturnValue = 0 AndAlso ErrorMessage Is Nothing Then

                            Message = "AvaTax values successfully posted."

                        ElseIf ReturnValue = 0 AndAlso ErrorMessage IsNot Nothing Then

                            Message = "Invoices were successfully assigned, but one or more failed to post to AvaTax." & vbCrLf & "Please review your AvaTax console." & vbCrLf & ErrorMessage

                        ElseIf ErrorMessage IsNot Nothing Then

                            Message = ErrorMessage

                        End If

                    Else

                        AssignInvoicesList = AdvantageFramework.BillingCommandCenter.AssignInvoices(BCCDbContext, BillingCommandCenter.BillingUser)

                        If AssignInvoicesList IsNot Nothing Then

                            ReturnValue = AssignInvoicesList.FirstOrDefault.ReturnValue

                            If ReturnValue = 0 Then

                                Message = "Invoice assignment completed successfully."

                            End If

                        End If

                    End If

                    BillingStatus = AdvantageFramework.BillingCommandCenter.GetBillingStatus(BCCDbContext, BillingCommandCenter.ID)

                    Select Case ReturnValue

                        Case -1

                            Message = "Invoices have already been assigned."

                        Case -3

                            Message = "No billing record exists for the current user."

                        Case -4

                            Message = "Another user currently has invoice assignment locked."

                        Case -6

                            Message = "GL entries are out of balance."

                        Case -7

                            Message = "GL transaction number cannot be NULL."

                        Case -8

                            Message = "GL transaction sequence number cannot be NULL."

                        Case -9

                            Message = "GL source cannot be NULL."

                        Case -10

                            Message = "GL amount cannot be NULL."

                        Case -11

                            Message = "Posting period cannot be NULL."

                        Case -12

                            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                                RejectedCoopJobs = AdvantageFramework.BillingCommandCenter.GetRejectedCoopJobs(DataContext, BillingCommandCenter.BillingUser)

                                RejectedCoopOrders = AdvantageFramework.BillingCommandCenter.GetRejectedCoopOrders(DataContext, BillingCommandCenter.BillingUser)

                                If RejectedCoopJobs.Count > 0 Then

                                    Message = "Co-op job(s) (" & String.Join(", ", RejectedCoopJobs.ToArray) & ") has multiple office codes.  In order to continue, the job(s) must be removed from the billing selection."

                                End If

                                If RejectedCoopOrders.Count > 0 Then

                                    Message = "Co-op order(s) (" & String.Join(", ", RejectedCoopOrders.ToArray) & ") has multiple office codes.  In order to continue, the order(s) must be removed from the billing selection."

                                End If

                            End Using

                    End Select

                    AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                    AdvantageFramework.WinForm.MessageBox.Show(Message)

                    If ReturnValue = 0 Then

                        Assigned = True

                        If ShowInvoicesAssignedDialog Then

                            AdvantageFramework.Billing.Presentation.BillingCommandCenterInvoicesAssignedDialog.ShowFormDialog(BillingCommandCenter.BillingUser)

                        End If

                    End If

                End Using

            End Using

            AssignInvoices = Assigned

        End Function
        Public Function OkayToAssignInvoices(ByVal Session As AdvantageFramework.Security.Session, ByVal BillingCommandCenterID As Integer,
                                             ByRef BillingStatus As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingStatus,
                                             ByRef BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter,
                                             Optional ByVal BypassInvoiceDatePostPeriodConfirmation As Boolean = False) As Boolean

            Dim BillingCommandCenterInvoiceDatePostPeriod As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingCommandCenterInvoiceDatePostPeriod = Nothing
            Dim BillingSelectionCriteria As AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria = Nothing
            Dim Billing As AdvantageFramework.Database.Entities.Billing = Nothing
            Dim IsOkay As Boolean = False
            Dim SalePostPeriodCodes As IEnumerable(Of String) = Nothing
            Dim [Continue] As Boolean = True

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, BillingCommandCenterID)

                If BillingCommandCenter IsNot Nothing Then

                    If BillingStatus IsNot Nothing AndAlso BillingStatus.IsAssigned.GetValueOrDefault(0) = 0 Then

                        If BillingStatus.IsProcessed Then

                            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                    SalePostPeriodCodes = (From Entity In AdvantageFramework.Database.Procedures.WorkARFunction.LoadByBillingUserCode(DataContext, BillingCommandCenter.BillingUser)
                                                           Select Entity.SalePostPeriodCode).Distinct.ToArray

                                    If (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext)
                                        Where SalePostPeriodCodes.Contains(Entity.Code) AndAlso
                                              Entity.ARStatus = "X").Any Then

                                        AdvantageFramework.WinForm.MessageBox.Show("The posting period has changed since the initial processing.  Please-reprocess before assigning invoices.")

                                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.BILLING SET INV_PROCESSED = 0 WHERE BILLING_USER = '{0}'", BillingCommandCenter.BillingUser))

                                        BillingStatus = AdvantageFramework.BillingCommandCenter.GetBillingStatus(BCCDbContext, BillingCommandCenter.ID)

                                        [Continue] = False

                                    End If

                                End Using

                            End Using

                        End If

                        If [Continue] Then

                            BillingCommandCenterInvoiceDatePostPeriod = AdvantageFramework.BillingCommandCenter.GetBillingCommandCenterInvoiceDatePostPeriod(BCCDbContext, BillingCommandCenter.BillingUser)

                            If BillingCommandCenterInvoiceDatePostPeriod IsNot Nothing Then

                                BillingSelectionCriteria = New AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria(BillingCommandCenterInvoiceDatePostPeriod)
                                BillingSelectionCriteria.ShowPostPeriodWarning = True
                                BillingSelectionCriteria.IsProcessed = BillingStatus.IsProcessed

                                If BypassInvoiceDatePostPeriodConfirmation OrElse AdvantageFramework.WinForm.Presentation.GenericPropertyGridDialog.ShowFormDialog("Confirm Options", BillingSelectionCriteria, False) = Windows.Forms.DialogResult.OK Then

                                    Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                                        Billing = AdvantageFramework.Database.Procedures.Billing.LoadByBillingUserCode(DataContext, BillingCommandCenter.BillingUser)

                                        If Billing IsNot Nothing Then

                                            Billing.InvoiceDate = BillingSelectionCriteria.InvoiceDate
                                            Billing.PostPeriodCode = BillingSelectionCriteria.PostPeriodCode

                                            If AdvantageFramework.Database.Procedures.Billing.Update(DataContext, Billing) Then

                                                IsOkay = True

                                            End If

                                        End If

                                    End Using

                                End If

                            End If

                        End If

                    Else

                        AdvantageFramework.Billing.Presentation.BillingCommandCenterInvoicesAssignedDialog.ShowFormDialog(BillingCommandCenter.BillingUser)

                    End If

                End If

            End Using

            OkayToAssignInvoices = IsOkay

        End Function
        Public Sub DraftInvoices(BaseFormParent As AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm, ByVal Session As AdvantageFramework.Security.Session, ByVal BillingUser As String)

            'objects
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                AccountReceivableInvoices = AdvantageFramework.InvoicePrinting.LoadAccountReceivableInvoices(DbContext, BillingUser, Now, Now, True, True, True, True, True, True, True, True, 0, False)

                AdvantageFramework.Billing.Reports.Presentation.InvoicePrintingSetupDialog.ShowForm(BaseFormParent, AccountReceivableInvoices, True)

            End Using

        End Sub
        Public Sub DraftInvoices(ByVal Session As AdvantageFramework.Security.Session, ByVal BillingUser As String)

            'objects
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                AccountReceivableInvoices = AdvantageFramework.InvoicePrinting.LoadAccountReceivableInvoices(DbContext, BillingUser, Now, Now, True, True, True, True, True, True, True, True, 0, False)

                AdvantageFramework.Billing.Reports.Presentation.InvoicePrintingSetupDialog.ShowFormDialog(AccountReceivableInvoices, True)

            End Using

        End Sub
        Public Sub PrintInvoices(BaseFormParent As AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm, ByVal Session As AdvantageFramework.Security.Session, ByVal BillingUser As String)

            'objects
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                AccountReceivableInvoices = AdvantageFramework.InvoicePrinting.LoadAccountReceivableBillingInvoices(DbContext, BillingUser)

            End Using

            AdvantageFramework.Billing.Reports.Presentation.InvoicePrintingSetupDialog.ShowForm(BaseFormParent, AccountReceivableInvoices, False)

        End Sub
        Public Sub PrintInvoices(ByVal Session As AdvantageFramework.Security.Session, ByVal BillingUser As String)

            'objects
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                AccountReceivableInvoices = AdvantageFramework.InvoicePrinting.LoadAccountReceivableBillingInvoices(DbContext, BillingUser)

            End Using

            AdvantageFramework.Billing.Reports.Presentation.InvoicePrintingSetupDialog.ShowFormDialog(AccountReceivableInvoices, False)

        End Sub
        Public Function FinishBatch(ByVal Session As AdvantageFramework.Security.Session, ByVal BillingCommandCenterID As Integer) As Boolean

            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim Message As String = Nothing
            Dim Finished As Boolean = False

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, BillingCommandCenterID)

                If BillingCommandCenter IsNot Nothing Then

                    Using TransactionScope As New System.Transactions.TransactionScope()

                        If AdvantageFramework.BillingCommandCenter.Finish(BCCDbContext, BillingCommandCenter) Then

                            BCCDbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.W_INVOICE_PRINT WHERE PRINT_USER = '{0}'", BillingCommandCenter.BillingUser))

                            TransactionScope.Complete()

                            Finished = True

                            Message = "Successfully finished billing run."

                        Else

                            Message = "The billing record does not qualify to be finished or no longer exists."

                        End If

                    End Using

                Else

                    Message = "The batch cannot be found."

                End If

            End Using

            AdvantageFramework.WinForm.MessageBox.Show(Message)

            FinishBatch = Finished

        End Function
        Public Function FinishDeleteBatch(ByVal Session As AdvantageFramework.Security.Session, ByVal BillingCommandCenterID As Integer) As Boolean

            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim Message As String = Nothing
            Dim Finished As Boolean = False

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, BillingCommandCenterID)

                If BillingCommandCenter IsNot Nothing Then

                    Try

                        Using TransactionScope As New System.Transactions.TransactionScope()

                            If AdvantageFramework.BillingCommandCenter.Finish(BCCDbContext, BillingCommandCenter) Then

                                BCCDbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.W_INVOICE_PRINT WHERE PRINT_USER = '{0}'", BillingCommandCenter.BillingUser))

                                BCCDbContext.Database.ExecuteSqlCommand(String.Format("exec advsp_clear_temp_bill_hold {0}, 0, 0", BillingCommandCenter.ID))

                                BCCDbContext.Database.ExecuteSqlCommand(String.Format("exec advsp_delete_billing_cmd_center_prod '{0}', 0", BillingCommandCenter.BillingUser))

                                BCCDbContext.Database.ExecuteSqlCommand(String.Format("exec advsp_delete_billing_cmd_center_media '{0}', 0", BillingCommandCenter.BillingUser))

                                BCCDbContext.Database.ExecuteSqlCommand(String.Format("exec advsp_delete_billing_cmd_center '{0}', 0", BillingCommandCenter.BillingUser))

                                TransactionScope.Complete()

                                Finished = True

                                Message = "Successfully finished billing run."

                            Else

                                Message = "The billing record does not qualify to be finished or no longer exists."

                            End If

                        End Using

                    Catch ex As Exception
                        Message = "Failed to finish batch.  Please contact software support."
                        Message += vbCrLf & ex.Message
                    End Try

                Else

                    Message = "The batch cannot be found."

                End If

            End Using

            AdvantageFramework.WinForm.MessageBox.Show(Message)

            FinishDeleteBatch = Finished

        End Function
        Public Function GetProductionSummaryReconcileable(ByVal ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)

            Dim List As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing

            List = (From Entity In ProductionSummaryList
                    Where (Entity.BillStatus = 2 OrElse Entity.BillStatus = 6) AndAlso
                          (Entity.JobBillHold.GetValueOrDefault(0) = 0 OrElse Entity.JobBillHold = 2) AndAlso
                          Entity.ABFlag.GetValueOrDefault(0) <> 0 AndAlso
                          Entity.BillingUser Is Nothing
                    Select Entity).ToList

            GetProductionSummaryReconcileable = List

        End Function
        Public Sub HideGroupByMenuOptions(ByVal PopupMenuShowingEventArgs As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing

            If PopupMenuShowingEventArgs.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                For Each DXMenuItem In PopupMenuShowingEventArgs.Menu.Items

                    If DXMenuItem.Tag IsNot Nothing AndAlso DXMenuItem.Tag.GetType Is GetType(DevExpress.XtraGrid.Localization.GridStringId) Then

                        If CType(DXMenuItem.Tag, DevExpress.XtraGrid.Localization.GridStringId) = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup OrElse
                                CType(DXMenuItem.Tag, DevExpress.XtraGrid.Localization.GridStringId) = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox OrElse
                                CType(DXMenuItem.Tag, DevExpress.XtraGrid.Localization.GridStringId) = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnRemoveColumn OrElse
                                CType(DXMenuItem.Tag, DevExpress.XtraGrid.Localization.GridStringId) = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnColumnCustomization Then

                            DXMenuItem.Visible = False

                        End If

                    End If

                Next

            End If

        End Sub
        Public Function GetTransferToJobList(ByVal Session As AdvantageFramework.Security.Session, ByVal BillingUser As String,
                                             ByVal ClientCode As String, ByVal DivisionCode As String, ProductCode As String) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.TransferToJob)

            Dim TransferToJobs As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.TransferToJob) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                TransferToJobs = DbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Classes.TransferToJob) _
                                        (String.Format("exec advsp_bcc_get_transfer_to_jobs '{0}',{1},{2},{3}",
                                        BillingUser,
                                        If(String.IsNullOrEmpty(ClientCode), "NULL", "'" & ClientCode & "'"),
                                        If(String.IsNullOrEmpty(DivisionCode), "NULL", "'" & DivisionCode & "'"),
                                        If(String.IsNullOrEmpty(ProductCode), "NULL", "'" & ProductCode & "'"))).ToList

            End Using

            GetTransferToJobList = TransferToJobs

        End Function

#End Region

    End Module

End Namespace

