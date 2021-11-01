Namespace Billing.Presentation

    Public Class BillingCommandCenterMediaBillingSelectionDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BillingCommandCenterID As Integer = 0
        Private _MediaSummaryBillingSelectionList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary) = Nothing
        Private _BillingUser As String = Nothing
        Private _BillingStatus As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingStatus = Nothing
        Private _BatchFinished As Boolean = False
        Private WithEvents _ToolTipController As DevExpress.Utils.ToolTipController = Nothing
        Private _ObjectTypePropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
        Private _IsMultiCurrencyEnabled As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property BatchFinished As Boolean
            Get
                BatchFinished = _BatchFinished
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal BillingCommandCenterID As Integer, ByVal MediaSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary))

            ' This call is required by the designer.
            InitializeComponent()

            _BillingCommandCenterID = BillingCommandCenterID

            _MediaSummaryBillingSelectionList = MediaSummaryList

        End Sub
        Private Sub LoadBillingSelection()

            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim BillingCommandCenterInvoiceDatePostPeriod As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingCommandCenterInvoiceDatePostPeriod = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID)

                If BillingCommandCenter IsNot Nothing Then

                    _BillingUser = BillingCommandCenter.BillingUser

                    _BillingStatus = AdvantageFramework.BillingCommandCenter.GetBillingStatus(BCCDbContext, BillingCommandCenter.ID)

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        ComboBoxBS_PostingPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveARPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                    End Using

                    BillingCommandCenterInvoiceDatePostPeriod = AdvantageFramework.BillingCommandCenter.GetBillingCommandCenterInvoiceDatePostPeriod(BCCDbContext, BillingCommandCenter.BillingUser)

                    If BillingCommandCenterInvoiceDatePostPeriod IsNot Nothing Then

                        DateTimePickerBS_InvoiceDate.Value = BillingCommandCenterInvoiceDatePostPeriod.InvoiceDate

                        ComboBoxBS_PostingPeriod.SelectedValue = BillingCommandCenterInvoiceDatePostPeriod.PostPeriodCode

                    End If

                    LoadGrid()

                End If

            End Using

            Me.ClearChanged()

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub LoadGrid()

            Dim LayoutLoaded As Boolean = False

            For Each MediaSummaryBillingSelection In _MediaSummaryBillingSelectionList

                MediaSummaryBillingSelection.BillingSelectionSelect = If(MediaSummaryBillingSelection.BillingUser IsNot Nothing, True, False)

            Next

            DataGridViewForm_BillingSelection.SetBookmarkColumnIndex(-1)
            DataGridViewForm_BillingSelection.ClearGridCustomization()
            DataGridViewForm_BillingSelection.ClearDatasource(New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary))
            DataGridViewForm_BillingSelection.ItemDescription = "Row(s) Available for Billing Selection"

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewForm_BillingSelection, Database.Entities.GridAdvantageType.BillingCommandCenterMediaReview)

            DataGridViewForm_BillingSelection.DataSource = _MediaSummaryBillingSelectionList

            If LayoutLoaded Then

                AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewForm_BillingSelection)

            End If

            DataGridViewForm_BillingSelection.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            If DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillStatus.ToString) IsNot Nothing Then

                AddSubItemImageComboBoxMediaBillStatus(DataGridViewForm_BillingSelection, DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillStatus.ToString))

            End If

            If DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.IsSelected.ToString) IsNot Nothing Then

                DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.IsSelected.ToString).Visible = False

            End If

            If DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.AmountSelectedforBilling.ToString) IsNot Nothing Then

                DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.AmountSelectedforBilling.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.AmountSelectedforBilling.ToString).VisibleIndex = 0

            End If

            If DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillingSelectionSelect.ToString) IsNot Nothing Then

                DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillingSelectionSelect.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillingSelectionSelect.ToString).VisibleIndex = 0
                DataGridViewForm_BillingSelection.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillingSelectionSelect.ToString).Caption = "Select"

            End If

            DataGridViewForm_BillingSelection.CurrentView.ExpandAllGroups()

            DataGridViewForm_BillingSelection.CurrentView.OptionsBehavior.Editable = True
            DataGridViewForm_BillingSelection.ShowColumnMenuOnRightClick = False

            If Not LayoutLoaded Then

                DataGridViewForm_BillingSelection.CurrentView.BestFitColumns()

            End If

            DataGridViewForm_BillingSelection.CurrentView.FocusedColumn = DataGridViewForm_BillingSelection.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillingSelectionSelect.ToString)

            DataGridViewForm_BillingSelection.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemBillingSelectionActions_Save.Enabled = DataGridViewForm_BillingSelection.UserEntryChanged OrElse DateTimePickerBS_InvoiceDate.UserEntryChanged OrElse ComboBoxBS_PostingPeriod.UserEntryChanged
            ButtonItemBillingSelectionActions_Cancel.Enabled = DataGridViewForm_BillingSelection.UserEntryChanged OrElse DateTimePickerBS_InvoiceDate.UserEntryChanged OrElse ComboBoxBS_PostingPeriod.UserEntryChanged

            ButtonItemProcessInvoices_Process.Enabled = _BillingUser IsNot Nothing AndAlso Not Me.CheckUserEntryChangedSetting AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed = False
            ButtonItemProcessInvoices_Draft.Enabled = _BillingUser IsNot Nothing AndAlso Not Me.CheckUserEntryChangedSetting AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.IsPrinted = 0

            If _BillingUser IsNot Nothing AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsAssigned = 1 Then

                ButtonItemProcessInvoices_Assign.Enabled = True
                ButtonItemProcessInvoices_Assign.Image = AdvantageFramework.My.Resources.InvoiceAssignedImage

                RibbonBarOptions_BillingSelectionActions.Enabled = False

                DataGridViewForm_BillingSelection.Enabled = False
                ComboBoxBS_PostingPeriod.Enabled = False
                DateTimePickerBS_InvoiceDate.Enabled = False
                ButtonItemProcessInvoices_Draft.Enabled = False

                Me.ClearChanged()

            Else

                ButtonItemProcessInvoices_Assign.Enabled = _BillingUser IsNot Nothing AndAlso Not Me.CheckUserEntryChangedSetting AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.IsAssigned = 0
                ButtonItemProcessInvoices_Assign.Image = AdvantageFramework.My.Resources.InvoiceNewImage

            End If

            ButtonItemProcessInvoices_Currency.Enabled = _BillingUser IsNot Nothing AndAlso Not Me.CheckUserEntryChangedSetting AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.IsAssigned = 0

            ButtonItemProcessInvoices_Print.Enabled = _BillingUser IsNot Nothing AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.IsAssigned = 1
            ButtonItemProcessInvoices_Finish.Enabled = _BillingUser IsNot Nothing AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.IsAssigned = 1
            ButtonItemProcessInvoices_FinishDelete.Enabled = _BillingUser IsNot Nothing AndAlso _BillingStatus IsNot Nothing AndAlso _BillingStatus.IsProcessed AndAlso _BillingStatus.IsAssigned = 1

        End Sub
        Private Sub SelectAllRows()

            For Each MediaSummary In DataGridViewForm_BillingSelection.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary).ToList

                MediaSummary.BillingSelectionSelect = True

            Next

            DataGridViewForm_BillingSelection.CurrentView.RefreshData()
            DataGridViewForm_BillingSelection.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal BillingCommandCenterID As Integer, ByVal MediaSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary),
                                              ByRef IsBatchFinished As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim BillingCommandCenterMediaBillingSelectionDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterMediaBillingSelectionDialog = Nothing

            BillingCommandCenterMediaBillingSelectionDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterMediaBillingSelectionDialog(BillingCommandCenterID, MediaSummaryList)

            ShowFormDialog = BillingCommandCenterMediaBillingSelectionDialog.ShowDialog()

            IsBatchFinished = BillingCommandCenterMediaBillingSelectionDialog.BatchFinished

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub _ToolTipController_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles _ToolTipController.GetActiveObjectInfo

            'objects
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim RowID As Integer = 0
            Dim ToolTipText As String = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            If e.SelectedControl Is DataGridViewForm_BillingSelection.GridControl Then

                Try

                    GridView = CType(DataGridViewForm_BillingSelection.GridControl.GetViewAt(e.ControlMousePosition), DevExpress.XtraGrid.Views.Grid.GridView)

                    If GridView IsNot Nothing Then

                        GridHitInfo = GridView.CalcHitInfo(e.ControlMousePosition)

                        If GridHitInfo.InRowCell AndAlso GridHitInfo.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillStatus.ToString Then

                            Try

                                RowID = DataGridViewForm_BillingSelection.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillStatus.ToString)

                            Catch ex As Exception

                            End Try

                            If RowID > -1 Then

                                Select Case RowID

                                    Case 1

                                        ToolTipText = "Prebill"

                                    Case 2

                                        ToolTipText = "Post Bill"

                                End Select

                            End If

                        ElseIf GridHitInfo.InRowCell Then

                            If _ObjectTypePropertyDescriptors Is Nothing Then

                                _ObjectTypePropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList()

                            End If

                            Try

                                PropertyDescriptor = (From [Property] In _ObjectTypePropertyDescriptors
                                                      Where [Property].Name = GridHitInfo.Column.FieldName
                                                      Select [Property]).SingleOrDefault

                            Catch ex As Exception
                                PropertyDescriptor = Nothing
                            End Try

                            If PropertyDescriptor IsNot Nothing AndAlso PropertyDescriptor.PropertyType Is GetType(String) Then

                                ToolTipText = DataGridViewForm_BillingSelection.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, GridHitInfo.Column.FieldName)

                            End If

                        End If

                        If String.IsNullOrEmpty(ToolTipText) = False Then

                            ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RowID, ToolTipText)

                        End If

                    End If

                Catch ex As Exception

                Finally
                    e.Info = ToolTipControlInfo
                End Try

            End If

        End Sub
        Private Sub BillingCommandCenterMediaBillingSelectionDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            ButtonItemBillingSelectionActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemBillingSelectionActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemProcessInvoices_Process.Image = AdvantageFramework.My.Resources.ProcessImage
            ButtonItemProcessInvoices_Currency.Image = AdvantageFramework.My.Resources.CurrencyDollarImage
            ButtonItemProcessInvoices_Draft.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemProcessInvoices_Assign.Image = AdvantageFramework.My.Resources.InvoiceNewImage
            ButtonItemProcessInvoices_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemProcessInvoices_Finish.Image = AdvantageFramework.My.Resources.FinishImage
            ButtonItemProcessInvoices_FinishDelete.Image = AdvantageFramework.My.Resources.FinishDeleteImage

            _ToolTipController = New DevExpress.Utils.ToolTipController()

            DataGridViewForm_BillingSelection.GridControl.ToolTipController = _ToolTipController
            DataGridViewForm_BillingSelection.ShowSelectDeselectAllButtons = True
            DataGridViewForm_BillingSelection.MultiSelect = False

            DateTimePickerBS_InvoiceDate.ByPassUserEntryChanged = False
            ComboBoxBS_PostingPeriod.ByPassUserEntryChanged = False

            DateTimePickerBS_InvoiceDate.SetRequired(True)
            ComboBoxBS_PostingPeriod.SetRequired(True)
            ComboBoxBS_PostingPeriod.DisableMouseWheel = True

            LoadBillingSelection()

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                _IsMultiCurrencyEnabled = AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext)

            End Using

            ButtonItemProcessInvoices_Currency.Visible = _IsMultiCurrencyEnabled

            Me.ClearChanged()

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub BillingCommandCenterMediaBillingSelectionDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Dim MediaSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary) = Nothing

            MediaSummaryList = DataGridViewForm_BillingSelection.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary).ToList

            If MediaSummaryList.Where(Function(PS) PS.IsSelected = True).Any = False Then

                SelectAllRows()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemBillingSelectionActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemBillingSelectionActions_Cancel.Click

            LoadBillingSelection()

        End Sub
        Private Sub ButtonItemBillingSelectionActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemBillingSelectionActions_Save.Click

            'objects
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim ErrorMessage As String = ""
            Dim Result As Integer = Nothing
            Dim SetupIncomplete As Boolean = False
            Dim SelectionFailed As Boolean = False
            Dim AmountSelectedforBilling As Decimal = 0

            If AdvantageFramework.BillingCommandCenter.ValidateBillingSelectionCriteria(Me.Session, DateTimePickerBS_InvoiceDate.GetValue, ComboBoxBS_PostingPeriod.GetSelectedValue, ErrorMessage) Then

                Me.ShowWaitForm("Saving...")

                DataGridViewForm_BillingSelection.CurrentView.CloseEditorForUpdating()

                _MediaSummaryBillingSelectionList = DataGridViewForm_BillingSelection.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary).ToList()

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID)

                    If BillingCommandCenter IsNot Nothing Then

                        AdvantageFramework.BillingCommandCenter.UpdateBillingSelectionInvoiceDatePostPeriodCode(BCCDbContext, DateTimePickerBS_InvoiceDate.GetValue, ComboBoxBS_PostingPeriod.SelectedValue, BillingCommandCenter.BillingUser)

                        For Each MediaSummary In _MediaSummaryBillingSelectionList

                            If MediaSummary.BillingUser IsNot Nothing AndAlso MediaSummary.BillingSelectionSelect = False Then

                                If AdvantageFramework.BillingCommandCenter.BillingSelectUnmarkMediaItem(BCCDbContext, BillingCommandCenter.BillingUser, MediaSummary.OrderNumber, MediaSummary.LineNumber, MediaSummary.BillingSelectionResult) = 0 Then

                                    MediaSummary.BillingUser = Nothing
                                    MediaSummary.BillingSelectionSelect = False
                                    MediaSummary.AmountSelectedforBilling = 0

                                End If

                            ElseIf MediaSummary.BillingUser Is Nothing AndAlso MediaSummary.BillingSelectionSelect Then

                                Result = AdvantageFramework.BillingCommandCenter.BillingSelectMarkMediaItem(BCCDbContext, BillingCommandCenter, MediaSummary, DateTimePickerBS_InvoiceDate.GetValue, ComboBoxBS_PostingPeriod.SelectedValue, MediaSummary.BillingSelectionResult, AmountSelectedforBilling)

                                If Result = 0 Then

                                    MediaSummary.BillingUser = Mid(BillingCommandCenter.BillingUser, 1, BillingCommandCenter.BillingUser.Length - 2)
                                    MediaSummary.BillingSelectionSelect = True
                                    MediaSummary.AmountSelectedforBilling = AmountSelectedforBilling

                                Else

                                    MediaSummary.BillingSelectionSelect = False

                                    If Result = -30 Then

                                        SetupIncomplete = True

                                    Else

                                        SelectionFailed = True

                                    End If

                                End If

                            End If

                        Next

                        AdvantageFramework.BillingCommandCenter.UpdateBillingSetInvoicesProcessedFlag(BCCDbContext, BillingCommandCenter.BillingUser, False)

                        ' update/delete BILLING row if no production/media jobs/orders are selected for billing
                        AdvantageFramework.BillingCommandCenter.DeleteBillingSelection(BCCDbContext, BillingCommandCenter.BillingUser)

                        LoadBillingSelection()

                    End If

                End Using

                If SetupIncomplete Then

                    ErrorMessage = "One or more records has not been selected for billing because billing setup has not been completed." & vbCrLf

                End If

                If SelectionFailed Then

                    ErrorMessage &= "One or more records has not been selected for billing because either order is marked post bill and AP has not been posted or no qualified amount to bill."

                End If

                If ErrorMessage <> "" Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

                Me.CloseWaitForm()

            Else

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub DataGridViewForm_BillingSelection_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_BillingSelection.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillingSelectionSelect.ToString Then

                DataGridViewForm_BillingSelection.SetUserEntryChanged()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewForm_BillingSelection_DeselectAllEvent() Handles DataGridViewForm_BillingSelection.DeselectAllEvent

            For Each MediaSummary In DataGridViewForm_BillingSelection.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary).ToList

                MediaSummary.BillingSelectionSelect = False

            Next

            DataGridViewForm_BillingSelection.CurrentView.RefreshData()
            DataGridViewForm_BillingSelection.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_BillingSelection_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewForm_BillingSelection.PopupMenuShowingEvent

            AdvantageFramework.Billing.Presentation.HideGroupByMenuOptions(e)

        End Sub
        Private Sub DataGridViewForm_BillingSelection_SelectAllEvent() Handles DataGridViewForm_BillingSelection.SelectAllEvent

            SelectAllRows()

        End Sub
        Private Sub DataGridViewForm_BillingSelection_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_BillingSelection.ShowingEditorEvent

            If DataGridViewForm_BillingSelection.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillingSelectionSelect.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DateTimePickerBS_InvoiceDate_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerBS_InvoiceDate.ValueChanged

            If Me.Session IsNot Nothing AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ComboBoxBS_PostingPeriod_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxBS_PostingPeriod.SelectedValueChanged

            If Me.Session IsNot Nothing AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemProcessInvoices_Assign_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_Assign.Click

            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing

            If AdvantageFramework.Billing.Presentation.OkayToAssignInvoices(Session, _BillingCommandCenterID, _BillingStatus, BillingCommandCenter) Then

                Me.ShowWaitForm()

                AdvantageFramework.Billing.Presentation.AssignInvoices(Me.Session, BillingCommandCenter, _BillingStatus)

                EnableOrDisableActions()

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemProcessInvoices_Draft_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_Draft.Click

            AdvantageFramework.Billing.Presentation.DraftInvoices(Me.Session, _BillingUser)

        End Sub
        Private Sub ButtonItemProcessInvoices_Finish_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_Finish.Click

            If AdvantageFramework.Billing.Presentation.FinishBatch(Me.Session, _BillingCommandCenterID) Then

                Me.DialogResult = Windows.Forms.DialogResult.OK

            End If

        End Sub
        Private Sub ButtonItemProcessInvoices_FinishDelete_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_FinishDelete.Click

            If AdvantageFramework.Billing.Presentation.FinishDeleteBatch(Me.Session, _BillingCommandCenterID) Then

                _BatchFinished = True
                Me.DialogResult = Windows.Forms.DialogResult.OK

            End If

        End Sub
        Private Sub ButtonItemProcessInvoices_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_Print.Click

            AdvantageFramework.Billing.Presentation.PrintInvoices(Me.Session, _BillingUser)

        End Sub
        Private Sub ButtonItemProcessInvoices_Process_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_Process.Click

            Dim ErrorMessage As String = Nothing

            If AdvantageFramework.BillingCommandCenter.ValidateBillingSelectionCriteria(Me.Session, DateTimePickerBS_InvoiceDate.GetValue, ComboBoxBS_PostingPeriod.GetSelectedValue, ErrorMessage) Then

                If AdvantageFramework.Billing.Presentation.ProcessInvoices(Me.Session, _BillingCommandCenterID, _BillingStatus, False) Then

                    LoadBillingSelection()

                End If

                EnableOrDisableActions()

            Else

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemProcessInvoices_Currency_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessInvoices_Currency.Click

            AdvantageFramework.Billing.Presentation.BillingCommandCenterCurrencyDialog.ShowDialog(_BillingUser)

        End Sub

#End Region

#End Region

    End Class

End Namespace
