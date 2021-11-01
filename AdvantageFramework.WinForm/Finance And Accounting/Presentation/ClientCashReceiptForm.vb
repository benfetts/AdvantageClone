Namespace FinanceAndAccounting.Presentation

    Public Class ClientCashReceiptForm

#Region " Constants "



#End Region

#Region " Enum "

        Protected Enum CashReceiptsViewLayout
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "By Client")>
            ByClient = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "By Cash Receipt Detail")>
            ByCashReceiptDetail = 1
        End Enum
        Protected Enum OtherReceiptsViewLayout
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "By Other")>
            ByOther = 0
            '<AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "By Other Detail")>
            'ByOtherDetail = 1
        End Enum

#End Region

#Region " Variables "

        Private WithEvents _GridViewClientCashReceiptDetailsLevel1Tab1 As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private _BatchDate As Date = Nothing
        Private _LastAddedBankCode As String = Nothing

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

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    DataGridViewLeftSection_ClientReceipts.DataSource = (From Client In AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext)
                                                                         Where Client.IsActive = 1
                                                                         Select Client.Code,
                                                                                Client.Name).Distinct.ToList

                    DataGridViewLeftSection_ClientReceipts.CurrentView.BestFitColumns()

                End Using

            End Using

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            Dim UnsavedChanges As Boolean = False

            If ClientCashReceiptControlRightSection_CR.Visible Then

                UnsavedChanges = ClientCashReceiptControlRightSection_CR.CheckForUnsavedChanges

            ElseIf OtherCashReceiptControlRightSection_OCR.Visible Then

                UnsavedChanges = OtherCashReceiptControlRightSection_OCR.CheckForUnsavedChanges

            End If

            CheckForUnsavedChanges = UnsavedChanges

        End Function
        Private Sub GridControlFocusedViewChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.ViewFocusEventArgs)

            EnableOrDisableActions()

        End Sub
        Private Sub EnableOrDisableActions()

            RibbonBarMergeContainerForm_Options.SuspendLayout()

            If ClientCashReceiptControlRightSection_CR.Visible Then

                Select Case ComboBoxItemActions_View.SelectedIndex

                    Case 0, 1

                        ClientCashReceiptControlRightSection_CR.Enabled = Me.FormShown
                        ButtonItemActions_Add.Enabled = True
                        ButtonItemActions_AddSearch.Enabled = True

                        ButtonItemActions_Delete.Enabled = ClientCashReceiptControlRightSection_CR.Enabled
                        ButtonItemActions_Save.Enabled = ClientCashReceiptControlRightSection_CR.Enabled

                        ButtonItemPayment_Partial.Enabled = ClientCashReceiptControlRightSection_CR.ClientCashReceiptsPartialPaymentEnabled AndAlso
                                                                ClientCashReceiptControlRightSection_CR.DataGridViewPanel_ClientInvoices.HasOnlyOneSelectedRow AndAlso
                                                                Not ClientCashReceiptControlRightSection_CR.SelectedInvoiceIsManual

                        RibbonBarOptions_InvoiceDetails.Visible = ClientCashReceiptControlRightSection_CR.Visible AndAlso ClientCashReceiptControlRightSection_CR.Enabled
                        RibbonBarOptions_InvoiceDetails.Enabled = ClientCashReceiptControlRightSection_CR.HasCheckSelected

                        RibbonBarOptions_Payment.Visible = ClientCashReceiptControlRightSection_CR.Visible AndAlso ClientCashReceiptControlRightSection_CR.Enabled
                        RibbonBarOptions_Payment.Enabled = ClientCashReceiptControlRightSection_CR.HasCheckSelected

                        RibbonBarOptions_Writeoff.Visible = ClientCashReceiptControlRightSection_CR.Visible AndAlso ClientCashReceiptControlRightSection_CR.Enabled
                        RibbonBarOptions_Writeoff.Enabled = ClientCashReceiptControlRightSection_CR.HasCheckSelected

                        RibbonBarOptions_OnAccount.Visible = ClientCashReceiptControlRightSection_CR.Visible AndAlso ClientCashReceiptControlRightSection_CR.Enabled
                        RibbonBarOptions_OnAccount.Enabled = ClientCashReceiptControlRightSection_CR.HasCheckSelected

                        RibbonBarOptions_OtherCashReceiptDetail.Visible = False

                        If DataGridViewLeftSection_ClientReceipts.GridControl.FocusedView IsNot Nothing AndAlso _GridViewClientCashReceiptDetailsLevel1Tab1 IsNot Nothing OrElse
                                ClientCashReceiptControlRightSection_CR.Visible = False Then

                            ButtonItemActions_Save.Enabled = False
                            ButtonItemActions_Delete.Enabled = False

                            If ClientCashReceiptControlRightSection_CR.Visible Then

                                If DataGridViewLeftSection_ClientReceipts.GridControl.FocusedView.Name = _GridViewClientCashReceiptDetailsLevel1Tab1.Name OrElse
                                        ClientCashReceiptControlRightSection_CR.SearchableComboBoxPanel_Client.HasASelectedValue Then

                                    ButtonItemActions_Save.Enabled = (AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(ClientCashReceiptControlRightSection_CR) AndAlso
                                                                      ClientCashReceiptControlRightSection_CR.NumericInputDisbursedTo_Balance.EditValue = 0)

                                    ButtonItemActions_Delete.Enabled = Not ClientCashReceiptControlRightSection_CR.CheckBoxDepositInfo_Cleared.Checked

                                End If

                            End If

                        End If

                End Select

            Else

                Select Case ComboBoxItemActions_View.SelectedIndex

                    Case 0

                        OtherCashReceiptControlRightSection_OCR.Enabled = (OtherCashReceiptControlRightSection_OCR.TextBoxPanel_CheckNumber.Text <> "" AndAlso Me.FormShown)

                        ButtonItemActions_Add.Enabled = True
                        ButtonItemActions_AddSearch.Enabled = False

                        ButtonItemActions_Delete.Enabled = Not OtherCashReceiptControlRightSection_OCR.CheckBoxDepositInfo_Cleared.Checked
                        ButtonItemActions_Save.Enabled = OtherCashReceiptControlRightSection_OCR.Enabled AndAlso
                                                         (AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(OtherCashReceiptControlRightSection_OCR) AndAlso
                                                          OtherCashReceiptControlRightSection_OCR.NumericInputDisbursedTo_Balance.EditValue = 0)

                        RibbonBarOptions_OnAccount.Visible = False
                        RibbonBarOptions_Writeoff.Visible = False
                        RibbonBarOptions_Payment.Visible = False
                        RibbonBarOptions_InvoiceDetails.Visible = False

                        RibbonBarOptions_OtherCashReceiptDetail.Visible = True

                        ButtonItemOtherCashReceiptDetail_Cancel.Enabled = OtherCashReceiptControlRightSection_OCR.DataGridViewPanel_OtherReceiptDetails.IsNewItemRow
                        ButtonItemOtherCashReceiptDetail_Delete.Enabled = OtherCashReceiptControlRightSection_OCR.DataGridViewPanel_OtherReceiptDetails.HasASelectedRow

                End Select

            End If

            RibbonBarMergeContainerForm_Options.ResumeLayout()

        End Sub
        Private Function LoadDetailLevel(ByVal RowHandle As Integer,
                                         ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView) As IEnumerable

            Dim ClientCashReceiptDetails As IEnumerable = Nothing
            Dim ClientCode As String = Nothing

            Try

                ClientCode = GridView.GetRowCellValue(RowHandle, "Code")

            Catch ex As Exception
                ClientCode = Nothing
            End Try

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ClientCashReceiptDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceipt)(String.Format("exec advsp_clientcashreceipts_by_client '{0}', '{1}' ", ClientCode, Session.UserCode)).ToList

            End Using

            LoadDetailLevel = ClientCashReceiptDetails

        End Function
        Private Sub LoadSelectedClientCashReceipt(ByVal ClientCashReceiptID As Integer, ByVal SequenceNumber As Short)

            Dim ClientCode As String = Nothing

            If Me.FormAction <> WinForm.Presentation.FormActions.Loading AndAlso (ClientCashReceiptControlRightSection_CR.ID <> ClientCashReceiptID OrElse ClientCashReceiptControlRightSection_CR.SequenceNumber <> SequenceNumber) Then

                Me.ShowWaitForm()

                If ClientCashReceiptControlRightSection_CR.LoadControl(ClientCode, ClientCashReceiptID, SequenceNumber, _BatchDate, ButtonItemInvoiceDetails_ShowAllOpen.Checked, Nothing) = False Then

                    ClientCashReceiptControlRightSection_CR.ClearControl()

                Else

                    ClearChanged()
                    ClearValidations()
                    EnableOrDisableActions()

                End If

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub LoadSelectedOtherCashReceipt(ByVal OtherCashReceiptID As Integer, ByVal SequenceNumber As Short)

            If Me.FormAction <> WinForm.Presentation.FormActions.Loading Then

                If OtherCashReceiptControlRightSection_OCR.LoadControl(OtherCashReceiptID, SequenceNumber, _BatchDate, Nothing) = False Then

                    OtherCashReceiptControlRightSection_OCR.ClearControl()

                Else

                    ClearChanged()
                    ClearValidations()
                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub LoadDetailViews()

            DataGridViewLeftSection_ClientReceipts.CurrentView.BeginUpdate()

            _GridViewClientCashReceiptDetailsLevel1Tab1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView

            DataGridViewLeftSection_ClientReceipts.GridControl.LevelTree.Nodes.Add("ClientCashReceiptDetailsLevel1Tab1", _GridViewClientCashReceiptDetailsLevel1Tab1)

            _GridViewClientCashReceiptDetailsLevel1Tab1.LevelIndent = 1

            _GridViewClientCashReceiptDetailsLevel1Tab1.ChildGridLevelName = "ClientCashReceiptDetailsLevel1Tab1"
            _GridViewClientCashReceiptDetailsLevel1Tab1.GridControl = DataGridViewLeftSection_ClientReceipts.GridControl
            _GridViewClientCashReceiptDetailsLevel1Tab1.Name = "_GridViewClientCashReceiptDetailsLevel1Tab1"

            _GridViewClientCashReceiptDetailsLevel1Tab1.Session = Me.Session

            _GridViewClientCashReceiptDetailsLevel1Tab1.ControlType = WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid

            _GridViewClientCashReceiptDetailsLevel1Tab1.ObjectType = GetType(AdvantageFramework.CashReceipts.Classes.ClientCashReceipt)

            _GridViewClientCashReceiptDetailsLevel1Tab1.OptionsDetail.ShowDetailTabs = False
            _GridViewClientCashReceiptDetailsLevel1Tab1.OptionsSelection.MultiSelect = False
            _GridViewClientCashReceiptDetailsLevel1Tab1.OptionsView.ShowViewCaption = False

            _GridViewClientCashReceiptDetailsLevel1Tab1.CreateColumnsBasedOnObjectType()

            _GridViewClientCashReceiptDetailsLevel1Tab1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

            _GridViewClientCashReceiptDetailsLevel1Tab1.OptionsView.ShowFooter = False

            For Each GridColumn In _GridViewClientCashReceiptDetailsLevel1Tab1.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.FieldName = AdvantageFramework.CashReceipts.Classes.ClientCashReceipt.Properties.CheckAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.CashReceipts.Classes.ClientCashReceipt.Properties.CheckDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.CashReceipts.Classes.ClientCashReceipt.Properties.CheckNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.CashReceipts.Classes.ClientCashReceipt.Properties.OnAccountAmount.ToString Then

                    GridColumn.Visible = True

                Else

                    GridColumn.Visible = False
                    GridColumn.OptionsColumn.AllowShowHide = False
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False
                    GridColumn.OptionsColumn.ShowInExpressionEditor = False

                End If

            Next

            DataGridViewLeftSection_ClientReceipts.CurrentView.EndUpdate()

        End Sub
        Private Sub SelectClient()

            Dim ClientCode As String = Nothing

            If DataGridViewLeftSection_ClientReceipts.Visible Then

                ClientCode = DataGridViewLeftSection_ClientReceipts.GetFirstSelectedRowBookmarkValue(0)

                If ClientCashReceiptControlRightSection_CR.SearchableComboBoxPanel_Client.SelectedValue <> ClientCode Then

                    Me.FormAction = WinForm.Presentation.FormActions.Loading

                    ClientCashReceiptControlRightSection_CR.SetClient(ClientCode)

                    Me.ClearValidations()
                    Me.ClearChanged()

                    EnableOrDisableActions()

                    Me.FormAction = WinForm.Presentation.FormActions.None

                End If

            End If

        End Sub
        Private Sub CollapseClientCashReceipts(ByVal ClientCode As String)

            DataGridViewLeftSection_ClientReceipts.SelectRow(ClientCode)

            DataGridViewLeftSection_ClientReceipts.CurrentView.SetMasterRowExpanded(DataGridViewLeftSection_ClientReceipts.CurrentView.FocusedRowHandle, False)

        End Sub
        Private Sub ToggleVisibleControl(ByVal CashReceiptVisible As Boolean)

            ClientCashReceiptControlRightSection_CR.Visible = CashReceiptVisible
            ClientCashReceiptControlRightSection_CR.Enabled = CashReceiptVisible

            If Not ClientCashReceiptControlRightSection_CR.Visible Then

                ClientCashReceiptControlRightSection_CR.ClearControl()

            End If

            OtherCashReceiptControlRightSection_OCR.Visible = Not CashReceiptVisible
            OtherCashReceiptControlRightSection_OCR.Enabled = Not CashReceiptVisible

            If Not OtherCashReceiptControlRightSection_OCR.Visible Then

                OtherCashReceiptControlRightSection_OCR.ClearControl()

            End If

        End Sub
        Private Sub ChangeView()

            Static PreviousSelectedIndex As Integer

            If Me.FormAction <> AdvantageFramework.WinForm.Presentation.FormActions.Loading Then

                If CheckForUnsavedChanges() Then

                    DataGridViewLeftSection_ClientReceipts.CurrentView.SetMasterRowExpanded(DataGridViewLeftSection_ClientReceipts.CurrentView.FocusedRowHandle, False)

                    If ClientCashReceiptControlRightSection_CR.Visible Then

                        If ComboBoxItemActions_View.SelectedIndex = 0 Then

                            DataGridViewLeftSection_ClientReceipts.Visible = True
                            DataGridViewLeftSection_CashReceiptDetail.Visible = False
                            DataGridViewLeftSection_OtherReceipts.Visible = False

                            ToggleVisibleControl(True)

                            PreviousSelectedIndex = 0

                            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                        ElseIf ComboBoxItemActions_View.SelectedIndex = 1 Then

                            If Me.FormAction <> AdvantageFramework.WinForm.Presentation.FormActions.Refreshing Then

                                DataGridViewLeftSection_ClientReceipts.Visible = False
                                DataGridViewLeftSection_CashReceiptDetail.Visible = True
                                DataGridViewLeftSection_OtherReceipts.Visible = False

                                Me.ShowWaitForm()

                                Me.FormAction = WinForm.Presentation.FormActions.Loading

                                LoadClientCashReceiptDetails()

                                DataGridViewLeftSection_CashReceiptDetail.FocusToFindPanel(True)

                                Me.FormAction = WinForm.Presentation.FormActions.None

                                ToggleVisibleControl(True)

                                Me.CloseWaitForm()

                                PreviousSelectedIndex = 1

                            End If

                        End If

                    Else

                        If ComboBoxItemActions_View.SelectedIndex = 0 Then

                            DataGridViewLeftSection_ClientReceipts.Visible = False
                            DataGridViewLeftSection_CashReceiptDetail.Visible = False
                            DataGridViewLeftSection_OtherReceipts.Visible = True

                            Me.ShowWaitForm()

                            Me.FormAction = WinForm.Presentation.FormActions.Loading

                            LoadOtherCashReceipts()

                            DataGridViewLeftSection_OtherReceipts.FocusToFindPanel(True)

                            Me.FormAction = WinForm.Presentation.FormActions.None

                            ToggleVisibleControl(False)

                            Me.CloseWaitForm()

                            PreviousSelectedIndex = 0

                            'ElseIf ComboBoxItemActions_View.SelectedIndex = 1 Then

                            '    DataGridViewLeftSection_ClientReceipts.Visible = False
                            '    DataGridViewLeftSection_CashReceiptDetail.Visible = False
                            '    DataGridViewLeftSection_OtherReceipts.Visible = True

                            '    Me.ShowWaitForm()

                            '    Me.FormAction = WinForm.Presentation.FormActions.Loading

                            '    LoadOtherCashReceiptDetails()

                            '    DataGridViewLeftSection_OtherReceipts.FocusToFindPanel(True)

                            '    Me.FormAction = WinForm.Presentation.FormActions.None

                            '    ToggleVisibleControl(False)

                            '    Me.CloseWaitForm()

                            '    PreviousSelectedIndex = 1

                        End If

                    End If

                    EnableOrDisableActions()

                    SuperValidator.ClearFailedValidations()

                Else

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

                    ComboBoxItemActions_View.SelectedIndex = PreviousSelectedIndex

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                End If

            End If

        End Sub
        Private Sub LoadClientCashReceiptDetails()

            DataGridViewLeftSection_CashReceiptDetail.ClearDatasource()
            DataGridViewLeftSection_CashReceiptDetail.ClearGridCustomization()

            DataGridViewLeftSection_CashReceiptDetail.CurrentView.ObjectType = GetType(AdvantageFramework.CashReceipts.Classes.ClientCashReceiptDetail)

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_CashReceiptDetail.DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptDetail) _
                        (String.Format("exec dbo.advsp_clientcashreceipt_select_all '{0}' ", Session.UserCode)).ToList

            End Using

            Me.FormAction = WinForm.Presentation.FormActions.None

            DataGridViewLeftSection_CashReceiptDetail.CurrentView.BestFitColumns()

            DataGridViewLeftSection_CashReceiptDetail.FocusToFindPanel(True)

        End Sub
        Private Sub LoadOtherCashReceipts()

            Dim OtherCashReceiptList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.OtherCashReceipt) = Nothing

            DataGridViewLeftSection_OtherReceipts.ClearDatasource()
            DataGridViewLeftSection_OtherReceipts.ClearGridCustomization()

            DataGridViewLeftSection_OtherReceipts.CurrentView.ObjectType = GetType(AdvantageFramework.CashReceipts.Classes.OtherCashReceipt)

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            OtherCashReceiptList = New Generic.List(Of AdvantageFramework.CashReceipts.Classes.OtherCashReceipt)

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                OtherCashReceiptList.AddRange(From OCR In AdvantageFramework.Database.Procedures.OtherCashReceipt.LoadWithOfficeLimits(DbContext, Session).Where(Function(OCR) OCR.Status Is Nothing OrElse OCR.Status <> "D").OrderByDescending(Function(OCR) OCR.CheckDate).ToList
                                              Select New AdvantageFramework.CashReceipts.Classes.OtherCashReceipt(OCR))

                DataGridViewLeftSection_OtherReceipts.DataSource = OtherCashReceiptList

            End Using

            Me.FormAction = WinForm.Presentation.FormActions.None

            DataGridViewLeftSection_OtherReceipts.CurrentView.BestFitColumns()

            DataGridViewLeftSection_OtherReceipts.FocusToFindPanel(True)

        End Sub
        Private Sub DeleteClientCashReceipt()

            Dim ClientCode As String = Nothing

            Try

                Me.ShowWaitForm("Deleting...")

                If ClientCashReceiptControlRightSection_CR.Delete(ClientCode) Then

                    ClientCashReceiptControlRightSection_CR.ClearControl(False)

                    CollapseClientCashReceipts(ClientCode)
                    DataGridViewLeftSection_ClientReceipts.FocusToFindPanel(False)

                    EnableOrDisableActions()

                    Me.SuperValidator.ClearFailedValidations()

                    Me.ClearChanged()

                End If

            Catch ex As Exception
                AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
            Finally
                Me.CloseWaitForm()
            End Try

        End Sub
        Private Sub DeleteOtherCashReceipt()

            Try

                If OtherCashReceiptControlRightSection_OCR.Delete() Then

                    Me.ClearChanged()

                    OtherCashReceiptControlRightSection_OCR.ClearControl()

                    LoadOtherCashReceipts()

                    DataGridViewLeftSection_OtherReceipts.FocusToFindPanel(False)

                    EnableOrDisableActions()

                End If

            Catch ex As Exception
                AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
            End Try

        End Sub
        Private Sub AddClientCashReceipt()

            Dim ClienCashReceiptID As Integer = 0
            Dim SequenceNumber As Short = 0
            Dim ClientCode As String = Nothing
            Dim BankCode As String = Nothing

            If ComboBoxItemActions_View.SelectedIndex = 0 Then

                ClientCode = ClientCashReceiptControlRightSection_CR.SearchableComboBoxPanel_Client.GetSelectedValue

            ElseIf ComboBoxItemActions_View.SelectedIndex = 1 Then

                ClientCode = DirectCast(DataGridViewLeftSection_CashReceiptDetail.CurrentView.GetRow(DataGridViewLeftSection_CashReceiptDetail.CurrentView.FocusedRowHandle), AdvantageFramework.CashReceipts.Classes.ClientCashReceiptDetail).ClientCode

            End If

            If ButtonItemDefaultNew_LastBank.Checked Then

                BankCode = _LastAddedBankCode

            End If

            If AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptEditDialog.ShowFormDialog(ClientCode, ClienCashReceiptID, SequenceNumber, _BatchDate, BankCode) = System.Windows.Forms.DialogResult.OK Then

                CollapseClientCashReceipts(ClientCode)
                LoadSelectedClientCashReceipt(ClienCashReceiptID, SequenceNumber)
                DataGridViewLeftSection_CashReceiptDetail.FocusToFindPanel(False)

                _LastAddedBankCode = BankCode

                If ComboBoxItemActions_View.SelectedIndex = 1 Then

                    LoadClientCashReceiptDetails()

                End If

            End If

        End Sub
        Private Sub AddOtherCashReceipt()

            Dim OtherCashReceiptID As Integer = 0
            Dim SequenceNumber As Short = 0
            Dim BankCode As String = Nothing

            If ButtonItemDefaultNew_LastBank.Checked Then

                BankCode = _LastAddedBankCode

            End If

            If AdvantageFramework.FinanceAndAccounting.Presentation.OtherCashReceiptEditDialog.ShowFormDialog(OtherCashReceiptID, SequenceNumber, _BatchDate, BankCode) = System.Windows.Forms.DialogResult.OK Then

                _LastAddedBankCode = BankCode

                If ComboBoxItemActions_View.SelectedIndex = 0 Then

                    LoadOtherCashReceipts()

                    LoadSelectedOtherCashReceipt(OtherCashReceiptID, SequenceNumber)

                End If

            End If

        End Sub
        Private Sub PrintClientCashReceiptBatchReport()

            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim ClientCashReceiptBatchReportList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptBatchReport) = Nothing
            Dim ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
            Dim [From] As Date = Nothing
            Dim [To] As Date = Nothing
            Dim UserCode As String = Nothing
            Dim IsBatch As Boolean = False
            Dim ReportRange As String = Nothing
            Dim DetailPageBreak As Boolean = False
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFromDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterToDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIsBatch As System.Data.SqlClient.SqlParameter = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                UserCode = Me.Session.UserCode

                If AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptBatchReportDialog.ShowFormDialog(ReportType, [From], [To], UserCode, IsBatch, ClientCashReceiptBatchReportDialog.CashReceiptBatchReportType.ClientCashReceipt, DetailPageBreak) = System.Windows.Forms.DialogResult.OK Then

                    SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)
                    SqlParameterFromDate = New System.Data.SqlClient.SqlParameter("@from_date", SqlDbType.SmallDateTime)
                    SqlParameterToDate = New System.Data.SqlClient.SqlParameter("@to_date", SqlDbType.SmallDateTime)
                    SqlParameterIsBatch = New System.Data.SqlClient.SqlParameter("@is_batch", SqlDbType.Int)

                    SqlParameterUserCode.Value = UserCode
                    SqlParameterFromDate.Value = [From]
                    SqlParameterToDate.Value = [To]

                    If IsBatch Then

                        SqlParameterIsBatch.Value = 1
                        ReportRange = "Batch: " & [From].ToString

                    Else

                        SqlParameterIsBatch.Value = 0
                        ReportRange = "Date Range: " & [From].ToShortDateString & " - " & [To].ToShortDateString

                    End If

                    ClientCashReceiptBatchReportList = DbContext.Database.SqlQuery(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptBatchReport)("exec advsp_clientcashreceipt_batch_report @user_code, @from_date, @to_date, @is_batch", SqlParameterUserCode, SqlParameterFromDate, SqlParameterToDate, SqlParameterIsBatch).ToList()

                    If ClientCashReceiptBatchReportList.Count = 0 Then

                        AdvantageFramework.WinForm.MessageBox.Show("Nothing to print.")

                    Else

                        ParameterDictionary = New Generic.Dictionary(Of String, Object)

                        ParameterDictionary.Add("DataSource", ClientCashReceiptBatchReportList)
                        ParameterDictionary.Add("ForUser", UserCode)
                        ParameterDictionary.Add("ReportRange", ReportRange)
                        ParameterDictionary.Add("DetailPageBreak", DetailPageBreak)

                        AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    End If

                End If

            End Using

        End Sub
        Private Sub PrintOtherCashReceiptBatchReport()

            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim OtherCashReceiptBatchReportList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.OtherCashReceiptBatchReport) = Nothing
            Dim ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
            Dim [From] As Date = Nothing
            Dim [To] As Date = Nothing
            Dim UserCode As String = Nothing
            Dim IsBatch As Boolean = False
            Dim ReportRange As String = Nothing
            Dim DetailPageBreak As Boolean = False
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFromDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterToDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIsBatch As System.Data.SqlClient.SqlParameter = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                UserCode = Me.Session.UserCode

                If AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptBatchReportDialog.ShowFormDialog(ReportType, [From], [To], UserCode, IsBatch, ClientCashReceiptBatchReportDialog.CashReceiptBatchReportType.OtherCashReceipt, DetailPageBreak) = System.Windows.Forms.DialogResult.OK Then

                    SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)
                    SqlParameterFromDate = New System.Data.SqlClient.SqlParameter("@from_date", SqlDbType.SmallDateTime)
                    SqlParameterToDate = New System.Data.SqlClient.SqlParameter("@to_date", SqlDbType.SmallDateTime)
                    SqlParameterIsBatch = New System.Data.SqlClient.SqlParameter("@is_batch", SqlDbType.Int)

                    SqlParameterUserCode.Value = UserCode
                    SqlParameterFromDate.Value = [From]
                    SqlParameterToDate.Value = [To]

                    If IsBatch Then

                        SqlParameterIsBatch.Value = 1
                        ReportRange = "Batch: " & [From].ToString

                    Else

                        SqlParameterIsBatch.Value = 0
                        ReportRange = "Date Range: " & [From].ToShortDateString & " - " & [To].ToShortDateString

                    End If

                    OtherCashReceiptBatchReportList = DbContext.Database.SqlQuery(Of AdvantageFramework.CashReceipts.Classes.OtherCashReceiptBatchReport)("exec advsp_othercashreceipt_batch_report @user_code, @from_date, @to_date, @is_batch", SqlParameterUserCode, SqlParameterFromDate, SqlParameterToDate, SqlParameterIsBatch).ToList()

                    If OtherCashReceiptBatchReportList.Count = 0 Then

                        AdvantageFramework.WinForm.MessageBox.Show("Nothing to print.")

                    Else

                        ParameterDictionary = New Generic.Dictionary(Of String, Object)

                        ParameterDictionary.Add("DataSource", OtherCashReceiptBatchReportList)
                        ParameterDictionary.Add("ForUser", UserCode)
                        ParameterDictionary.Add("ReportRange", ReportRange)
                        ParameterDictionary.Add("DetailPageBreak", DetailPageBreak)

                        AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    End If

                End If

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ClientCashReceiptForm As AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptForm = Nothing

            ClientCashReceiptForm = New AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptForm()

            ClientCashReceiptForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientCashReceiptForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ClientCashReceiptForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            _BatchDate = Now

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage

            ButtonItemActions_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemActions_Import.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.FinanceAccounting_ClientCashReceiptsImport)

            ButtonItemView_OtherReceipts.Image = AdvantageFramework.My.Resources.OtherCashReceiptsImage

            ButtonItemDefaultNew_LastBank.Image = AdvantageFramework.My.Resources.BankImage

            ButtonItemInvoiceDetails_ShowAllOpen.Image = AdvantageFramework.My.Resources.InvoiceOpenImage

            ButtonItemPayment_Apply.Image = AdvantageFramework.My.Resources.CheckAttachImage
            ButtonItemPayment_Partial.Image = AdvantageFramework.My.Resources.MediaDateToBillImage
            ButtonItemPayment_Undo.Image = AdvantageFramework.My.Resources.UndoImage

            ButtonItemWriteoff_Apply.Image = AdvantageFramework.My.Resources.WriteoffImage
            ButtonItemWriteoff_Undo.Image = AdvantageFramework.My.Resources.UndoImage

            ButtonItemOnAccount_Apply.Image = AdvantageFramework.My.Resources.WriteoffImage
            ButtonItemOnAccount_Undo.Image = AdvantageFramework.My.Resources.UndoImage

            ButtonItemOtherCashReceiptDetail_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemOtherCashReceiptDetail_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage

            DataGridViewLeftSection_ClientReceipts.MultiSelect = False
            DataGridViewLeftSection_ClientReceipts.ByPassUserEntryChanged = True

            DataGridViewLeftSection_ClientReceipts.OptionsView.ShowDetailButtons = True
            DataGridViewLeftSection_ClientReceipts.OptionsDetail.EnableMasterViewMode = True
            DataGridViewLeftSection_ClientReceipts.OptionsDetail.AllowExpandEmptyDetails = True
            DataGridViewLeftSection_ClientReceipts.OptionsDetail.ShowDetailTabs = True
            DataGridViewLeftSection_ClientReceipts.CurrentView.ObjectType = GetType(AdvantageFramework.Database.Entities.Client)
            DataGridViewLeftSection_ClientReceipts.ItemDescription = "Active Client(s)"

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            ToggleVisibleControl(True)

            ComboBoxItemActions_View.Items.AddRange((From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(CashReceiptsViewLayout))
                                                     Select Entity.Description).ToArray)

            ComboBoxItemActions_View.SelectedIndex = 0

            DataGridViewLeftSection_ClientReceipts.Visible = True
            DataGridViewLeftSection_CashReceiptDetail.Visible = False

            LoadGrid()

            LoadDetailViews()

            DataGridViewLeftSection_CashReceiptDetail.FocusToFindPanel(True)

            ClientCashReceiptControlRightSection_CR.SetBatchDate(_BatchDate)
            ClientCashReceiptControlRightSection_CR.EnableSearch()

            OtherCashReceiptControlRightSection_OCR.SetBatchDate(_BatchDate)
            OtherCashReceiptControlRightSection_OCR.Visible = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub ClientCashReceiptForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_ClientReceipts.FocusToFindPanel(True)

        End Sub
        Private Sub ClientCashReceiptForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub _GridViewClientCashReceiptDetailsLevel1Tab1_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)

            Dim ClientCashReceiptID As Integer = 0
            Dim SequenceNumber As Short = 0
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            BaseView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            If BaseView IsNot Nothing Then

                ClientCashReceiptID = BaseView.GetRowCellValue(e.FocusedRowHandle, AdvantageFramework.CashReceipts.Classes.ClientCashReceipt.Properties.ID.ToString)

                SequenceNumber = BaseView.GetRowCellValue(e.FocusedRowHandle, AdvantageFramework.CashReceipts.Classes.ClientCashReceipt.Properties.SequenceNumber.ToString)

                LoadSelectedClientCashReceipt(ClientCashReceiptID, SequenceNumber)

            End If

        End Sub
        Private Sub _GridViewClientCashReceiptDetailsLevel1Tab1_RowClick(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs)

            Dim ClientCashReceiptID As Integer = 0
            Dim SequenceNumber As Short = 0
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            BaseView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            If BaseView IsNot Nothing Then

                ClientCashReceiptID = BaseView.GetRowCellValue(e.RowHandle, AdvantageFramework.CashReceipts.Classes.ClientCashReceipt.Properties.ID.ToString)

                SequenceNumber = BaseView.GetRowCellValue(e.RowHandle, AdvantageFramework.CashReceipts.Classes.ClientCashReceipt.Properties.SequenceNumber.ToString)

                LoadSelectedClientCashReceipt(ClientCashReceiptID, SequenceNumber)

            End If

        End Sub
        Private Sub _GridViewClientCashReceiptDetailsLevel1Tab1_BeforeLeaveRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles _GridViewClientCashReceiptDetailsLevel1Tab1.BeforeLeaveRow

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            Dim ClientCode As String = Nothing

            If CheckForUnsavedChanges() Then

                If ClientCashReceiptControlRightSection_CR.Visible Then

                    ClientCode = ClientCashReceiptControlRightSection_CR.SearchableComboBoxPanel_Client.GetSelectedValue

                    If ClientCode IsNot Nothing Then

                        AddClientCashReceipt()

                    ElseIf ClientCashReceiptControlRightSection_CR.SearchableComboBoxPanel_Client.DataSource.Count = 0 Then

                        AdvantageFramework.WinForm.MessageBox.Show("No active clients available.")

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please select a client.")

                    End If

                ElseIf OtherCashReceiptControlRightSection_OCR.Visible Then

                    AddOtherCashReceipt()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_AddSearch_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_AddSearch.Click

            Dim ClientCashReceiptID As Integer = 0
            Dim SequenceNumber As Integer = 0
            Dim ClientCode As String = Nothing
            Dim BankCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            ContinueAdd = CheckForUnsavedChanges()

            If ContinueAdd Then

                If AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptClientSearchDialog.ShowFormDialog(ClientCode) = System.Windows.Forms.DialogResult.OK Then

                    If AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptEditDialog.ShowFormDialog(ClientCode, ClientCashReceiptID, SequenceNumber, _BatchDate, BankCode) = System.Windows.Forms.DialogResult.OK Then

                        CollapseClientCashReceipts(ClientCode)
                        LoadSelectedClientCashReceipt(ClientCashReceiptID, SequenceNumber)
                        DataGridViewLeftSection_CashReceiptDetail.FocusToFindPanel(False)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If ClientCashReceiptControlRightSection_CR.Visible Then

                DeleteClientCashReceipt()

            ElseIf OtherCashReceiptControlRightSection_OCR.Visible Then

                DeleteOtherCashReceipt()

            End If

        End Sub
        Private Sub ButtonItemActions_Import_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Import.Click

            AdvantageFramework.Importing.Presentation.ImportForm.ShowForm(AdvantageFramework.Importing.ImportType.CashReceipt)

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Print.Click

            If ClientCashReceiptControlRightSection_CR.Visible Then

                PrintClientCashReceiptBatchReport()

            ElseIf OtherCashReceiptControlRightSection_OCR.Visible Then

                PrintOtherCashReceiptBatchReport()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Dim ErrorMessage As String = ""
            Dim ClientCode As String = Nothing

            If Me.Validator Then

                Me.ShowWaitForm()

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                Try

                    If ClientCashReceiptControlRightSection_CR.Visible AndAlso ClientCashReceiptControlRightSection_CR.Save(ClientCode) Then

                        Me.ClearChanged()

                        CollapseClientCashReceipts(ClientCode)
                        DataGridViewLeftSection_CashReceiptDetail.FocusToFindPanel(False)

                        If ComboBoxItemActions_View.SelectedIndex = 1 Then

                            LoadClientCashReceiptDetails()

                        End If

                    ElseIf OtherCashReceiptControlRightSection_OCR.Visible AndAlso OtherCashReceiptControlRightSection_OCR.Save() Then

                        Me.ClearChanged()

                        If ComboBoxItemActions_View.SelectedIndex = 0 Then

                            LoadOtherCashReceipts()

                        End If

                    End If

                Catch ex As Exception
                    ErrorMessage = ex.Message
                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                End Try

                Me.CloseWaitForm()

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                If ErrorMessage = "" Then

                    DataGridViewLeftSection_CashReceiptDetail.FocusToFindPanel(False)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemInvoiceDetails_ShowAllOpen_Click(sender As Object, e As EventArgs) Handles ButtonItemInvoiceDetails_ShowAllOpen.Click

            If CheckForUnsavedChanges() Then

                ButtonItemInvoiceDetails_ShowAllOpen.Checked = Not ButtonItemInvoiceDetails_ShowAllOpen.Checked

            End If

        End Sub
        Private Sub ButtonItemInvoiceDetails_ShowAllOpen_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemInvoiceDetails_ShowAllOpen.CheckedChanged

            If Me.FormShown Then

                ClientCashReceiptControlRightSection_CR.RefreshInvoices(ButtonItemInvoiceDetails_ShowAllOpen.Checked)

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemOnAccount_Apply_Click(sender As Object, e As EventArgs) Handles ButtonItemOnAccount_Apply.Click

            ClientCashReceiptControlRightSection_CR.ApplyToOnAccount()

        End Sub
        Private Sub ButtonItemOnAccount_Undo_Click(sender As Object, e As EventArgs) Handles ButtonItemOnAccount_Undo.Click

            ClientCashReceiptControlRightSection_CR.UndoOnAccount()

        End Sub
        Private Sub ButtonItemOtherCashReceiptDetail_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemOtherCashReceiptDetail_Cancel.Click

            OtherCashReceiptControlRightSection_OCR.CancelAddNewReceiptDetail()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemOtherCashReceiptDetail_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemOtherCashReceiptDetail_Delete.Click

            OtherCashReceiptControlRightSection_OCR.DeleteSelectedReceiptDetail()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemPayment_Apply_Click(sender As Object, e As EventArgs) Handles ButtonItemPayment_Apply.Click

            ClientCashReceiptControlRightSection_CR.ApplyPaymentsUptoCheckAmountToSelectedInvoices()

        End Sub
        Private Sub ButtonItemPayment_Partial_Click(sender As Object, e As EventArgs) Handles ButtonItemPayment_Partial.Click

            ClientCashReceiptControlRightSection_CR.LaunchPartialPaymentDialog(True)

        End Sub
        Private Sub ButtonItemPayment_Undo_Click(sender As Object, e As EventArgs) Handles ButtonItemPayment_Undo.Click

            ClientCashReceiptControlRightSection_CR.UndoPaymentsOnSelectedInvoices()

        End Sub
        Private Sub ButtonItemView_OtherReceipts_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_OtherReceipts.CheckedChanged

            Dim Cancel As Boolean = False
            Dim Checked As Boolean = False

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Modifying

                Checked = ButtonItemView_OtherReceipts.Checked

                Cancel = Not CheckForUnsavedChanges()

                If Not Cancel Then

                    ToggleVisibleControl(Not ButtonItemView_OtherReceipts.Checked)

                    ComboBoxItemActions_View.Items.Clear()

                    If ButtonItemView_OtherReceipts.Checked Then

                        ComboBoxItemActions_View.Items.AddRange((From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(OtherReceiptsViewLayout))
                                                                 Select Entity.Description).ToArray)

                        ComboBoxItemActions_View.SelectedIndex = 0

                    Else

                        ComboBoxItemActions_View.Items.AddRange((From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(CashReceiptsViewLayout))
                                                                 Select Entity.Description).ToArray)

                        ComboBoxItemActions_View.SelectedIndex = 0

                        DataGridViewLeftSection_ClientReceipts.FocusToFindPanel(True)

                    End If

                Else

                    ButtonItemView_OtherReceipts.Checked = Not Checked

                End If

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemWriteoff_Apply_Click(sender As Object, e As EventArgs) Handles ButtonItemWriteoff_Apply.Click

            ClientCashReceiptControlRightSection_CR.ApplyWriteoffsToSelectedInvoices()

        End Sub
        Private Sub ButtonItemWriteoff_Undo_Click(sender As Object, e As EventArgs) Handles ButtonItemWriteoff_Undo.Click

            ClientCashReceiptControlRightSection_CR.UndoWriteoffsOnSelectedInvoices()

        End Sub
        Private Sub ClientCashReceiptControlRightSection_CR_ClientCheckNumberChanged() Handles ClientCashReceiptControlRightSection_CR.ClientCheckNumberChanged

            Me.ClearChanged()

            EnableOrDisableActions()

            If ClientCashReceiptControlRightSection_CR.SearchableComboBoxPanel_Client.HasASelectedValue AndAlso
                    ClientCashReceiptControlRightSection_CR.SearchableComboBoxPanel_Client.GetSelectedValue <> DataGridViewLeftSection_ClientReceipts.GetFirstSelectedRowBookmarkValue(0) Then

                DataGridViewLeftSection_ClientReceipts.SelectRow(ClientCashReceiptControlRightSection_CR.SearchableComboBoxPanel_Client.GetSelectedValue)

            End If

        End Sub
        Private Sub ClientCashReceiptControlRightSection_CR_ClientInvoiceSelectionChangedEvent(sender As Object, e As EventArgs) Handles ClientCashReceiptControlRightSection_CR.ClientInvoiceSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ClientCashReceiptControlRightSection_CR_CollapseClient(ClientCode As String) Handles ClientCashReceiptControlRightSection_CR.CollapseClient

            CollapseClientCashReceipts(ClientCode)

        End Sub
        Private Sub ClientCashReceiptRightSection_CR_TotalsChanged() Handles ClientCashReceiptControlRightSection_CR.TotalsChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ComboBoxItemActions_View_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemActions_View.SelectedIndexChanged

            ChangeView()

        End Sub
        Private Sub DataGridViewLeftSection_ClientCashReceipts_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_ClientReceipts.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_ClientCashReceipts_MasterRowEmptyEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles DataGridViewLeftSection_ClientReceipts.MasterRowEmptyEvent

            e.IsEmpty = False

        End Sub
        Private Sub DataGridViewLeftSection_ClientCashReceipts_MasterRowExpandedEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles DataGridViewLeftSection_ClientReceipts.MasterRowExpandedEvent

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            BaseView = DataGridViewLeftSection_ClientReceipts.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                BaseView.ClearSelection()

                BaseView.SelectRow(BaseView.SourceRowHandle)

                If BaseView.ChildGridLevelName = "ClientCashReceiptDetailsLevel1Tab1" Then

                    Select Case e.RelationIndex

                        Case 0

                            AddHandler BaseView.FocusedRowChanged, AddressOf _GridViewClientCashReceiptDetailsLevel1Tab1_FocusedRowChanged
                            AddHandler BaseView.RowClick, AddressOf _GridViewClientCashReceiptDetailsLevel1Tab1_RowClick
                            AddHandler BaseView.GridControl.FocusedViewChanged, AddressOf GridControlFocusedViewChanged

                    End Select

                    If BaseView.RowCount > 0 Then

                        BaseView.SelectRow(0)

                    End If

                End If

                BaseView.BestFitColumns()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_ClientCashReceipts_MasterRowGetChildListEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles DataGridViewLeftSection_ClientReceipts.MasterRowGetChildListEvent

            e.ChildList = LoadDetailLevel(e.RowHandle, DataGridViewLeftSection_ClientReceipts.CurrentView)

        End Sub
        Private Sub DataGridViewLeftSection_ClientCashReceipts_MasterRowGetRelationCountEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles DataGridViewLeftSection_ClientReceipts.MasterRowGetRelationCountEvent

            e.RelationCount = 1

        End Sub
        Private Sub DataGridViewLeftSection_ClientCashReceipts_MasterRowGetRelationDisplayCaptionEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewLeftSection_ClientReceipts.MasterRowGetRelationDisplayCaptionEvent

            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim RowCount As Integer = 0

            BaseView = DataGridViewLeftSection_ClientReceipts.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                RowCount = BaseView.RowCount

                Select Case e.RelationIndex

                    Case 0

                        e.RelationName = RowCount & " Cash Receipt(s)"

                End Select

            Else

                Select Case e.RelationIndex

                    Case 0

                        e.RelationName = " Cash Receipt(s)"

                End Select

            End If

        End Sub
        Private Sub DataGridViewLeftSection_ClientCashReceipts_MasterRowGetRelationNameEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewLeftSection_ClientReceipts.MasterRowGetRelationNameEvent

            Select Case e.RelationIndex

                Case 0

                    e.RelationName = "ClientCashReceiptDetailsLevel1Tab1"

            End Select

        End Sub
        Private Sub DataGridViewLeftSection_ClientCashReceipts_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_ClientReceipts.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                SelectClient()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_CashReceiptDetail_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_CashReceiptDetail.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_CashReceiptDetail_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_CashReceiptDetail.SelectionChangedEvent

            Dim ClientCashReceiptID As Integer = 0
            Dim SequenceNumber As Short = 0

            If DataGridViewLeftSection_CashReceiptDetail.HasASelectedRow Then

                ClientCashReceiptID = DirectCast(DataGridViewLeftSection_CashReceiptDetail.CurrentView.GetRow(DataGridViewLeftSection_CashReceiptDetail.CurrentView.FocusedRowHandle), AdvantageFramework.CashReceipts.Classes.ClientCashReceiptDetail).ClientCashReceiptID

                SequenceNumber = DirectCast(DataGridViewLeftSection_CashReceiptDetail.CurrentView.GetRow(DataGridViewLeftSection_CashReceiptDetail.CurrentView.FocusedRowHandle), AdvantageFramework.CashReceipts.Classes.ClientCashReceiptDetail).ClientCashReceiptSequenceNumber

                LoadSelectedClientCashReceipt(ClientCashReceiptID, SequenceNumber)

            End If

        End Sub
        Private Sub DataGridViewLeftSection_OtherReceipts_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_OtherReceipts.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_OtherReceipts_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_OtherReceipts.SelectionChangedEvent

            Dim OtherCashReceiptID As Integer = 0
            Dim SequenceNumber As Short = 0

            If DataGridViewLeftSection_OtherReceipts.HasASelectedRow Then

                OtherCashReceiptID = DirectCast(DataGridViewLeftSection_OtherReceipts.CurrentView.GetRow(DataGridViewLeftSection_OtherReceipts.CurrentView.FocusedRowHandle), AdvantageFramework.CashReceipts.Classes.OtherCashReceipt).ID

                SequenceNumber = DirectCast(DataGridViewLeftSection_OtherReceipts.CurrentView.GetRow(DataGridViewLeftSection_OtherReceipts.CurrentView.FocusedRowHandle), AdvantageFramework.CashReceipts.Classes.OtherCashReceipt).SequenceNumber

                LoadSelectedOtherCashReceipt(OtherCashReceiptID, SequenceNumber)

            End If

        End Sub
        Private Sub OtherCashReceiptControlRightSection_OCR_ReceiptDetailInitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles OtherCashReceiptControlRightSection_OCR.ReceiptDetailInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub OtherCashReceiptControlRightSection_OCR_ReceiptDetailSelectionChangedEvent(sender As Object, e As EventArgs) Handles OtherCashReceiptControlRightSection_OCR.ReceiptDetailSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub OtherCashReceiptControlRightSection_OCR_TotalsChanged() Handles OtherCashReceiptControlRightSection_OCR.TotalsChanged

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace