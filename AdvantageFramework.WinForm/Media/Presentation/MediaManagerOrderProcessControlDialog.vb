Namespace Media.Presentation

    Public Class MediaManagerOrderProcessControlDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _OrderNumbers As IEnumerable(Of Integer) = Nothing
        Private _MediaManagerReviewDetailList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal OrderNumbers As IEnumerable(Of Integer))

            ' This call is required by the designer.
            InitializeComponent()

            _OrderNumbers = OrderNumbers

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim LayoutLoaded As Boolean = False
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim JobProcessList As Generic.List(Of AdvantageFramework.Database.Entities.JobProcess) = Nothing
            Dim OrderProcessControlList As Generic.List(Of AdvantageFramework.MediaManager.Classes.OrderProcessControl) = Nothing
            Dim OrderNumbers As IEnumerable(Of Integer) = Nothing

            BindingSource = DataGridViewForm_ProcessControl.DataSource

            If BindingSource IsNot Nothing AndAlso BindingSource.DataSource IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewForm_ProcessControl, Database.Entities.Methods.GridAdvantageType.MediaManagerOrderProcessControl)

            End If

            DataGridViewForm_ProcessControl.SetBookmarkColumnIndex(-1)
            DataGridViewForm_ProcessControl.ClearGridCustomization()
            DataGridViewForm_ProcessControl.CurrentView.ClearDisabledRows()
            DataGridViewForm_ProcessControl.ClearDatasource(New Generic.List(Of AdvantageFramework.MediaManager.Classes.OrderProcessControl))

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewForm_ProcessControl, Database.Entities.GridAdvantageType.MediaManagerOrderProcessControl)

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    JobProcessList = AdvantageFramework.Database.Procedures.JobProcess.LoadMediaProcesses(DataContext).ToList

                    _MediaManagerReviewDetailList = AdvantageFramework.MediaManager.LoadMediaManagerReviewDetails(DbContext, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, _OrderNumbers, Nothing, Nothing, Nothing, Nothing, True, Nothing, False, Nothing, False, False)

                    OrderProcessControlList = New Generic.List(Of AdvantageFramework.MediaManager.Classes.OrderProcessControl)

                    OrderProcessControlList.AddRange(From Entity In _MediaManagerReviewDetailList
                                                     Select New AdvantageFramework.MediaManager.Classes.OrderProcessControl(DbContext, Entity, JobProcessList))

                    OrderNumbers = OrderProcessControlList.Select(Function(OPC) OPC.OrderNumber).Distinct.ToArray

                    For Each OrderNumber In OrderNumbers

                        If OrderProcessControlList.Where(Function(OPC) OPC.OrderNumber = OrderNumber AndAlso OPC.LineComplete = False).Any = False OrElse
                                OrderProcessControlList.Where(Function(OPC) OPC.OrderNumber = OrderNumber AndAlso OPC.Quote).Any Then

                            For Each OrderProcessControl In OrderProcessControlList.Where(Function(OPC) OPC.OrderNumber = OrderNumber)

                                OrderProcessControl.QualifiedToClose = True

                            Next

                        ElseIf OrderProcessControlList.Where(Function(OPC) OPC.OrderNumber = OrderNumber AndAlso OPC.AmountsAreZero = False).Any = False AndAlso
                                OrderProcessControlList.Where(Function(OPC) OPC.OrderNumber = OrderNumber AndAlso OPC.MediaManagerReviewDetail.VCCCardID.HasValue = True).Any = False Then

                            For Each OrderProcessControl In OrderProcessControlList.Where(Function(OPC) OPC.OrderNumber = OrderNumber)

                                OrderProcessControl.QualifiedToClose = True

                            Next

                        End If

                    Next

                    DataGridViewForm_ProcessControl.DataSource = OrderProcessControlList

                End Using

            End Using

            If Not LayoutLoaded Then

                SetColumnDefaultVisibility()

                For Each GridColumn In DataGridViewForm_ProcessControl.Columns

                    If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.ClientCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.OrderNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.OrderDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.LineNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.OrderProcessControl.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.NewProcessControl.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.QualifiedToClose.ToString Then

                        GridColumn.OptionsColumn.AllowShowHide = False
                        GridColumn.OptionsColumn.ShowInCustomizationForm = False

                    End If

                Next

                DataGridViewForm_ProcessControl.CurrentView.ClearSorting()
                DataGridViewForm_ProcessControl.CurrentView.BeginSort()
                DataGridViewForm_ProcessControl.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.OrderNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                DataGridViewForm_ProcessControl.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.LineNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                DataGridViewForm_ProcessControl.CurrentView.EndSort()

                DataGridViewForm_ProcessControl.CurrentView.BestFitColumns()

            Else

                AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewForm_ProcessControl)

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Cancel.Enabled = Me.UserEntryChanged

            ButtonItemGridOptions_ChooseColumns.Enabled = Not Me.UserEntryChanged
            ButtonItemGridOptions_RestoreDefaults.Enabled = Not Me.UserEntryChanged

        End Sub
        Private Sub SetColumnDefaultVisibility()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridViewForm_ProcessControl.CurrentView.Columns

                If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.ClientName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.DivisionCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.DivisionName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.ProductCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.ProductDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.LineComplete.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.ProcessControlComments.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.BillableAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.BilledAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.TotalCostPayableToVendor.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.ActualAmountPosted.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.ProcessedDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.LastProcessControl.ToString Then

                    GridColumn.Visible = False

                End If

            Next

        End Sub
        Private Sub SetOrderProcessControl()

            Dim OrderProcessControlList As Generic.List(Of AdvantageFramework.MediaManager.Classes.OrderProcessControl) = Nothing
            Dim OrderProcessControl As AdvantageFramework.MediaManager.Classes.OrderProcessControl = Nothing
            Dim NewProcessControl As Nullable(Of Short) = Nothing

            DataGridViewForm_ProcessControl.CurrentView.CloseEditorForUpdating()

            OrderProcessControlList = DataGridViewForm_ProcessControl.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.OrderProcessControl).ToList()

            For Each OrderProcessControl In OrderProcessControlList

                NewProcessControl = ComboBoxProcessControl_JobProcess.GetSelectedValue

                If (NewProcessControl = 6) Then

                    If OrderProcessControl.QualifiedToClose Then

                        OrderProcessControl.NewProcessControl = NewProcessControl

                        DataGridViewForm_ProcessControl.SetUserEntryChanged()

                    End If

                Else

                    OrderProcessControl.NewProcessControl = NewProcessControl

                    DataGridViewForm_ProcessControl.SetUserEntryChanged()

                End If

            Next

            DataGridViewForm_ProcessControl.CurrentView.RefreshData()

            EnableOrDisableActions()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal OrderNumbers As IEnumerable(Of Integer)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaManagerOrderProcessControlDialog As AdvantageFramework.Media.Presentation.MediaManagerOrderProcessControlDialog = Nothing

            MediaManagerOrderProcessControlDialog = New AdvantageFramework.Media.Presentation.MediaManagerOrderProcessControlDialog(OrderNumbers)

            ShowFormDialog = MediaManagerOrderProcessControlDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaManagerOrderProcessControlDialog_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If e.CloseReason = Windows.Forms.CloseReason.UserClosing Then

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewForm_ProcessControl, Database.Entities.GridAdvantageType.MediaManagerOrderProcessControl)

            End If

        End Sub
        Private Sub MediaManagerOrderProcessControlDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemGridOptions_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemGridOptions_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            ButtonItemProcessControl_CloseQualified.Image = AdvantageFramework.My.Resources.JobProcessControlCloseImage

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                ComboBoxProcessControl_JobProcess.DataSource = AdvantageFramework.Database.Procedures.JobProcess.LoadMediaProcesses(DataContext).ToList

            End Using

            ComboBoxProcessControl_JobProcess.ByPassUserEntryChanged = True

            DataGridViewForm_ProcessControl.CurrentView.OptionsLayout.StoreDataSettings = True
            DataGridViewForm_ProcessControl.CurrentView.OptionsLayout.StoreAppearance = True
            DataGridViewForm_ProcessControl.CurrentView.OptionsLayout.StoreVisualOptions = True

            DataGridViewForm_ProcessControl.CurrentView.OptionsLayout.Columns.StoreAllOptions = True
            DataGridViewForm_ProcessControl.CurrentView.OptionsLayout.Columns.StoreAppearance = True

            DataGridViewForm_ProcessControl.AutoloadRepositoryDatasource = True
            DataGridViewForm_ProcessControl.AddFixedColumnCheckItemsToGridMenu = True
            DataGridViewForm_ProcessControl.OptionsMenu.EnableColumnMenu = True

            DataGridViewForm_ProcessControl.OptionsCustomization.AllowColumnMoving = True

            DataGridViewForm_ProcessControl.ShowSelectDeselectAllButtons = True

        End Sub
        Private Sub MediaManagerOrderProcessControlDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.ShowWaitForm("Loading...")

            LoadGrid()

            DataGridViewForm_ProcessControl.SelectAll()

            EnableOrDisableActions()

            Me.CloseWaitForm()

        End Sub
        Private Function CanCloseOrder(OrderNumber As Integer, OrderProcessControlList As Generic.List(Of AdvantageFramework.MediaManager.Classes.OrderProcessControl)) As Boolean

            Dim CanClose As Boolean = False

            If OrderProcessControlList.Where(Function(OPC) OPC.OrderNumber = OrderNumber AndAlso OPC.LineComplete = False).Any = False OrElse
                                OrderProcessControlList.Where(Function(OPC) OPC.OrderNumber = OrderNumber AndAlso OPC.Quote).Any Then

                CanClose = True

            ElseIf OrderProcessControlList.Where(Function(OPC) OPC.OrderNumber = OrderNumber AndAlso OPC.AmountsAreZero = False).Any = False AndAlso
                                OrderProcessControlList.Where(Function(OPC) OPC.OrderNumber = OrderNumber AndAlso OPC.MediaManagerReviewDetail.VCCCardID.HasValue = True).Any = False Then

                CanClose = True

            End If

            CanCloseOrder = CanClose

        End Function

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            LoadGrid()

            Me.ClearChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim OrderProcessLog As AdvantageFramework.Database.Entities.OrderProcessLog = Nothing
            Dim ErrorMessage As String = Nothing
            Dim ProcessedOrderNumbers As Generic.List(Of Integer) = Nothing
            Dim RowsUpdated As Integer = 0
            Dim JobProcessList As Generic.List(Of AdvantageFramework.Database.Entities.JobProcess) = Nothing
            Dim MediaManagerReviewDetailList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) = Nothing
            Dim OrderProcessControlList As Generic.List(Of AdvantageFramework.MediaManager.Classes.OrderProcessControl) = Nothing

            ProcessedOrderNumbers = New Generic.List(Of Integer)

            DataGridViewForm_ProcessControl.CurrentView.CloseEditorForUpdating()

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    JobProcessList = AdvantageFramework.Database.Procedures.JobProcess.LoadMediaProcesses(DataContext).ToList

                    MediaManagerReviewDetailList = AdvantageFramework.MediaManager.LoadMediaManagerReviewDetails(DbContext, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, _OrderNumbers, Nothing, Nothing, Nothing, Nothing, True, Nothing, False, Nothing, False, False)

                    OrderProcessControlList = New Generic.List(Of AdvantageFramework.MediaManager.Classes.OrderProcessControl)

                    OrderProcessControlList.AddRange(From Entity In _MediaManagerReviewDetailList
                                                     Select New AdvantageFramework.MediaManager.Classes.OrderProcessControl(DbContext, Entity, JobProcessList))

                    For Each DataBoundItem In DataGridViewForm_ProcessControl.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.OrderProcessControl).Where(Function(Entity) Entity.NewProcessControl.GetValueOrDefault(0) > 0).ToList

                        If DataBoundItem.NewProcessControl <> DataBoundItem.MediaManagerReviewDetail.ProcessControl Then

                            If Not ProcessedOrderNumbers.Contains(DataBoundItem.OrderNumber) Then

                                If (DataBoundItem.NewProcessControl = 6 AndAlso CanCloseOrder(DataBoundItem.OrderNumber, OrderProcessControlList)) OrElse
                                            DataBoundItem.NewProcessControl <> 6 Then

                                    RowsUpdated = 0

                                    Select Case DataBoundItem.MediaManagerReviewDetail.MediaFrom.Substring(0, 1)

                                        Case "I"

                                            RowsUpdated = DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.INTERNET_HEADER SET ORD_PROCESS_CONTRL = {1} WHERE ORDER_NBR = {0} AND ORD_PROCESS_CONTRL <> {1}", DataBoundItem.OrderNumber, DataBoundItem.NewProcessControl.Value))

                                        Case "M"

                                            RowsUpdated = DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MAGAZINE_HEADER SET ORD_PROCESS_CONTRL = {1} WHERE ORDER_NBR = {0} AND ORD_PROCESS_CONTRL <> {1}", DataBoundItem.OrderNumber, DataBoundItem.NewProcessControl.Value))

                                        Case "N"

                                            RowsUpdated = DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.NEWSPAPER_HEADER SET ORD_PROCESS_CONTRL = {1} WHERE ORDER_NBR = {0} AND ORD_PROCESS_CONTRL <> {1}", DataBoundItem.OrderNumber, DataBoundItem.NewProcessControl.Value))

                                        Case "O"

                                            RowsUpdated = DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.OUTDOOR_HEADER SET ORD_PROCESS_CONTRL = {1} WHERE ORDER_NBR = {0} AND ORD_PROCESS_CONTRL <> {1}", DataBoundItem.OrderNumber, DataBoundItem.NewProcessControl.Value))

                                        Case "R"

                                            RowsUpdated = DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.RADIO_HDR SET ORD_PROCESS_CONTRL = {1} WHERE ORDER_NBR = {0} AND ORD_PROCESS_CONTRL <> {1}", DataBoundItem.OrderNumber, DataBoundItem.NewProcessControl.Value))

                                        Case "T"

                                            RowsUpdated = DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.TV_HDR SET ORD_PROCESS_CONTRL = {1} WHERE ORDER_NBR = {0} AND ORD_PROCESS_CONTRL <> {1}", DataBoundItem.OrderNumber, DataBoundItem.NewProcessControl.Value))

                                    End Select

                                    If RowsUpdated = 1 Then

                                        OrderProcessLog = New AdvantageFramework.Database.Entities.OrderProcessLog

                                        OrderProcessLog.OrderNumber = DataBoundItem.MediaManagerReviewDetail.OrderNumber
                                        OrderProcessLog.OriginalProcessControl = DataBoundItem.MediaManagerReviewDetail.ProcessControl
                                        OrderProcessLog.NewProcessControl = DataBoundItem.NewProcessControl
                                        OrderProcessLog.ProcessedDate = Now
                                        OrderProcessLog.ProcessedByUserCode = Session.UserCode
                                        OrderProcessLog.Comments = DataBoundItem.ProcessControlComments

                                        If Not AdvantageFramework.Database.Procedures.OrderProcessLog.Insert(DbContext, OrderProcessLog, ErrorMessage) Then

                                            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                                        Else

                                            ProcessedOrderNumbers.Add(DataBoundItem.OrderNumber)

                                        End If

                                    End If

                                End If

                            End If

                            End If

                        Next

                    End Using

                End Using

                LoadGrid()

                Me.ClearChanged()

                EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ProcessControl_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_ProcessControl.CellValueChangedEvent

            Dim OrderProcessControl As AdvantageFramework.MediaManager.Classes.OrderProcessControl = Nothing
            Dim OrderProcessControls As IEnumerable(Of AdvantageFramework.MediaManager.Classes.OrderProcessControl) = Nothing

            OrderProcessControl = DataGridViewForm_ProcessControl.GetRowDataBoundItem(e.RowHandle)

            If e.Column.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.ProcessControlComments.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.NewProcessControl.ToString Then

                OrderProcessControls = DataGridViewForm_ProcessControl.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.OrderProcessControl).Where(Function(Entity) Entity.OrderNumber = OrderProcessControl.OrderNumber).ToList

                For Each OPC In OrderProcessControls

                    OPC.ProcessControlComments = OrderProcessControl.ProcessControlComments
                    OPC.NewProcessControl = OrderProcessControl.NewProcessControl

                Next

                DataGridViewForm_ProcessControl.CurrentView.RefreshData()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ProcessControl_ColumnValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs, ViaCellValueChangedEvent As Boolean) Handles DataGridViewForm_ProcessControl.ColumnValueChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ProcessControl_HideCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ProcessControl.HideCustomizationFormEvent

            If ButtonItemGridOptions_ChooseColumns.Checked Then

                ButtonItemGridOptions_ChooseColumns.Checked = False

            End If

        End Sub
        Private Sub DataGridViewForm_ProcessControl_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_ProcessControl.QueryPopupNeedDatasourceEvent

            If FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.NewProcessControl.ToString Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If DataGridViewForm_ProcessControl.CurrentView.GetRowCellValue(DataGridViewForm_ProcessControl.CurrentView.FocusedRowHandle, AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.QualifiedToClose.ToString) = False Then

                        OverrideDefaultDatasource = True

                        Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                            Datasource = AdvantageFramework.Database.Procedures.JobProcess.LoadMediaProcessesOpen(DataContext).ToList

                        End Using

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridViewForm_ProcessControl_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_ProcessControl.ShowingEditorEvent

            Dim OrderProcessControl As AdvantageFramework.MediaManager.Classes.OrderProcessControl = Nothing

            OrderProcessControl = DirectCast(DataGridViewForm_ProcessControl.CurrentView.GetRow(DataGridViewForm_ProcessControl.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.OrderProcessControl)

            If DataGridViewForm_ProcessControl.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.ProcessControlComments.ToString Then

                If OrderProcessControl.NewProcessControl.GetValueOrDefault(0) <= 0 Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub ButtonItemGridOptions_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_ChooseColumns.CheckedChanged

            Try

                If ButtonItemGridOptions_ChooseColumns.Checked Then

                    If DataGridViewForm_ProcessControl.CurrentView.CustomizationForm Is Nothing Then

                        DataGridViewForm_ProcessControl.CurrentView.ShowCustomization()

                    End If

                Else

                    If DataGridViewForm_ProcessControl.CurrentView.CustomizationForm IsNot Nothing Then

                        DataGridViewForm_ProcessControl.CurrentView.DestroyCustomization()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemGridOptions_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_RestoreDefaults.Click

            Me.ShowWaitForm("Loading...")

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, Database.Entities.GridAdvantageType.MediaManagerOrderProcessControl, Session.UserCode)

            End Using

            DataGridViewForm_ProcessControl.SetBookmarkColumnIndex(-1)
            DataGridViewForm_ProcessControl.Columns.Clear()

            DataGridViewForm_ProcessControl.ClearDatasource()

            LoadGrid()

            Me.ClearChanged()

            EnableOrDisableActions()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemProcessControl_CloseQualified_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessControl_CloseQualified.Click

            DataGridViewForm_ProcessControl.CurrentView.CloseEditorForUpdating()

            For Each DataBoundItem In DataGridViewForm_ProcessControl.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.OrderProcessControl).Where(Function(Entity) Entity.QualifiedToClose = True).ToList

                DataBoundItem.NewProcessControl = 6

                DataGridViewForm_ProcessControl.SetUserEntryChanged()

            Next

            DataGridViewForm_ProcessControl.CurrentView.RefreshData()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemProcessControl_MarkSelected_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessControl_MarkSelected.Click

            SetOrderProcessControl()

        End Sub
        Private Sub ComboBoxProcessControl_JobProcess_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxProcessControl_JobProcess.SelectedValueChanged

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace