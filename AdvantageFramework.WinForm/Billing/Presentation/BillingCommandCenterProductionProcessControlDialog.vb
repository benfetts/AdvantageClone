Namespace Billing.Presentation

    Public Class BillingCommandCenterProductionProcessControlDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BillingCommandCenterID As Integer = 0
        Private _IncludeContingency As Short = 0
        Private _ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing
        Private _StatusesNotAllowingAPEntry As IEnumerable(Of Short) = {2, 5, 6, 7, 10, 11, 12}

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal BillingCommandCenterID As Integer, ByVal IncludeContingency As Short, ByVal ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary))

            ' This call is required by the designer.
            InitializeComponent()

            _BillingCommandCenterID = BillingCommandCenterID
            _IncludeContingency = IncludeContingency
            _ProductionSummaryList = ProductionSummaryList

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim LayoutLoaded As Boolean = False
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim JobProcessList As Generic.List(Of AdvantageFramework.Database.Entities.JobProcess) = Nothing

            BindingSource = DataGridViewForm_ProductionProcessControl.DataSource

            If BindingSource IsNot Nothing AndAlso BindingSource.DataSource IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewForm_ProductionProcessControl, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterProcessControl)

            End If

            DataGridViewForm_ProductionProcessControl.SetBookmarkColumnIndex(-1)
            DataGridViewForm_ProductionProcessControl.ClearGridCustomization()
            DataGridViewForm_ProductionProcessControl.ClearDatasource(New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl))
            DataGridViewForm_ProductionProcessControl.ItemDescription = "Job Component(s)"

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewForm_ProductionProcessControl, Database.Entities.GridAdvantageType.BillingCommandCenterProcessControl)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    JobProcessList = AdvantageFramework.Database.Procedures.JobProcess.Load(DataContext).ToList

                End Using

                DataGridViewForm_ProductionProcessControl.DataSource = (From Entity In _ProductionSummaryList
                                                                        Select New AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl(DbContext, Entity, JobProcessList)).ToList

            End Using

            If Not LayoutLoaded Then

                SetColumnDefaultVisibility()

                For Each GridColumn In DataGridViewForm_ProductionProcessControl.Columns

                    If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.ClientCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.JobNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.JobDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.ComponentNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.ProcessControlDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.NewProcessControl.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.QualifiedToClose.ToString Then

                        GridColumn.OptionsColumn.AllowShowHide = False
                        GridColumn.OptionsColumn.ShowInCustomizationForm = False

                    End If

                Next

                'always sort 735-2-966
                'Else

                '    AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewForm_ProductionProcessControl)

            End If

            DataGridViewForm_ProductionProcessControl.CurrentView.ClearSorting()
            DataGridViewForm_ProductionProcessControl.CurrentView.BeginSort()
            DataGridViewForm_ProductionProcessControl.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.JobNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            DataGridViewForm_ProductionProcessControl.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.ComponentNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            DataGridViewForm_ProductionProcessControl.CurrentView.EndSort()

            DataGridViewForm_ProductionProcessControl.CurrentView.BestFitColumns()

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

            For Each GridColumn In DataGridViewForm_ProductionProcessControl.CurrentView.Columns

                If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.EstimateAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.ActualBillableAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.OpenPOAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.BilledAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.UnbilledAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.AdvanceBilledAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.UnbilledAdvanceAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.TotalBilledAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.FlatIncomeRecognized.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.BillingApprovalHeaderComment.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.IsNonBillable.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.ProcessedDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.LastProcessControl.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.NewScheduleStatus.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.ScheduleStatus.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.ScheduleCompletedDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.ClientName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.DivisionName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.ProductDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.JobDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.ComponentDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.ClientName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.DivisionCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.DivisionName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.ProductCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.ProductDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.ComponentDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.CreatedDate.ToString Then

                    GridColumn.Visible = False

                End If

            Next

        End Sub
        Private Sub SetNewProcessControl()

            'objects
            Dim ValidateClosedArchivedJobs As Boolean = True
            Dim ProductionProcessControlList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl) = Nothing
            Dim NewProcessControl As Nullable(Of Short) = Nothing
            Dim OneOrMoreJobsOnOpenPO As Boolean = False

            DataGridViewForm_ProductionProcessControl.CurrentView.CloseEditorForUpdating()

            NewProcessControl = ComboBoxProcessControl_JobProcess.GetSelectedValue

            If NewProcessControl.HasValue Then

                ProductionProcessControlList = DataGridViewForm_ProductionProcessControl.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl).ToList()

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    ValidateClosedArchivedJobs = AdvantageFramework.Database.Procedures.Agency.ValidateClosedArchivedJobs(DbContext)

                    For Each ProductionProcessControl In ProductionProcessControlList

                        If _StatusesNotAllowingAPEntry.Contains(NewProcessControl) Then

                            If (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByJobNumber(DbContext, ProductionProcessControl.JobNumber).Include("PurchaseOrder").ToList
                                Where Entity.JobNumber = ProductionProcessControl.JobNumber AndAlso
                                      Entity.IsComplete.GetValueOrDefault(0) = 0 AndAlso
                                      Entity.PurchaseOrder.IsVoid.GetValueOrDefault(0) = 0).Any = True Then

                                OneOrMoreJobsOnOpenPO = True

                            ElseIf (NewProcessControl = 6 OrElse NewProcessControl = 12) Then

                                If ProductionProcessControl.QualifiedToClose OrElse Not ValidateClosedArchivedJobs Then

                                    ProductionProcessControl.NewProcessControl = NewProcessControl

                                    DataGridViewForm_ProductionProcessControl.SetUserEntryChanged()

                                End If

                            Else

                                ProductionProcessControl.NewProcessControl = NewProcessControl

                                DataGridViewForm_ProductionProcessControl.SetUserEntryChanged()

                            End If

                        Else

                            If ProductionProcessControl.ProductionSummary.ProcessControl <> NewProcessControl Then

                                ProductionProcessControl.NewProcessControl = NewProcessControl

                                DataGridViewForm_ProductionProcessControl.SetUserEntryChanged()

                            ElseIf ProductionProcessControl.ProductionSummary.ProcessControl = NewProcessControl Then

                                ProductionProcessControl.NewProcessControl = Nothing

                            End If

                        End If

                    Next

                End Using

                If OneOrMoreJobsOnOpenPO Then

                    AdvantageFramework.WinForm.MessageBox.Show("The status cannot be changed on selected job(s) because open purchase orders have been found.  Select a status that allows A/P to be entered.")

                End If

                DataGridViewForm_ProductionProcessControl.CurrentView.RefreshData()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub SetNewScheduleStatus()

            Dim ProductionProcessControlList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl) = Nothing
            Dim NewScheduleStatus As String = Nothing

            DataGridViewForm_ProductionProcessControl.CurrentView.CloseEditorForUpdating()

            ProductionProcessControlList = DataGridViewForm_ProductionProcessControl.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl).ToList()

            For Each ProductionProcessControl In ProductionProcessControlList

                NewScheduleStatus = ComboBoxScheduleStatus_Status.GetSelectedValue

                If ProductionProcessControl.NewProcessControl = 6 AndAlso String.IsNullOrWhiteSpace(ProductionProcessControl.ScheduleStatus) = False Then

                    ProductionProcessControl.NewScheduleStatus = NewScheduleStatus

                    DataGridViewForm_ProductionProcessControl.SetUserEntryChanged()

                End If

            Next

            DataGridViewForm_ProductionProcessControl.CurrentView.RefreshData()

            EnableOrDisableActions()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal BillingCommandCenterID As Integer, ByVal IncludeContingency As Short, ByVal ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)) As System.Windows.Forms.DialogResult

            'objects
            Dim BillingCommandCenterProductionProcessControlDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionProcessControlDialog = Nothing

            BillingCommandCenterProductionProcessControlDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionProcessControlDialog(BillingCommandCenterID, IncludeContingency, ProductionSummaryList)

            ShowFormDialog = BillingCommandCenterProductionProcessControlDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCommandCenterProductionProcessControlDialog_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If e.CloseReason = Windows.Forms.CloseReason.UserClosing Then

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewForm_ProductionProcessControl, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterProcessControl)

            End If

        End Sub
        Private Sub BillingCommandCenterProductionProcessControlDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemGridOptions_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemGridOptions_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            ButtonItemProcessControl_ClearComments.Image = AdvantageFramework.My.Resources.ClearImage
            ButtonItemProcessControl_CloseQualified.Image = AdvantageFramework.My.Resources.JobProcessControlCloseImage

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                ComboBoxProcessControl_JobProcess.DataSource = AdvantageFramework.Database.Procedures.JobProcess.Load(DataContext).ToList

            End Using

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ComboBoxScheduleStatus_Status.DataSource = AdvantageFramework.Database.Procedures.Status.LoadAllActive(DbContext).ToList

            End Using

            ComboBoxProcessControl_JobProcess.ByPassUserEntryChanged = True
            ComboBoxScheduleStatus_Status.ByPassUserEntryChanged = True

            DataGridViewForm_ProductionProcessControl.CurrentView.OptionsLayout.StoreDataSettings = True
            DataGridViewForm_ProductionProcessControl.CurrentView.OptionsLayout.StoreAppearance = True
            DataGridViewForm_ProductionProcessControl.CurrentView.OptionsLayout.StoreVisualOptions = True

            DataGridViewForm_ProductionProcessControl.CurrentView.OptionsLayout.Columns.StoreAllOptions = True
            DataGridViewForm_ProductionProcessControl.CurrentView.OptionsLayout.Columns.StoreAppearance = True

            DataGridViewForm_ProductionProcessControl.AutoloadRepositoryDatasource = True
            DataGridViewForm_ProductionProcessControl.AddFixedColumnCheckItemsToGridMenu = True
            DataGridViewForm_ProductionProcessControl.OptionsMenu.EnableColumnMenu = True

            DataGridViewForm_ProductionProcessControl.OptionsCustomization.AllowColumnMoving = True

            DataGridViewForm_ProductionProcessControl.ShowSelectDeselectAllButtons = True

        End Sub
        Private Sub BillingCommandCenterProductionProcessControlDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadGrid()

            DataGridViewForm_ProductionProcessControl.SelectAll()

            EnableOrDisableActions()

        End Sub

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
            Dim AnyJobsToBeClosed As Boolean = False
            Dim AllowContinue As Boolean = True
            Dim ReturnValue As Integer = -1
            Dim ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing

            DataGridViewForm_ProductionProcessControl.CurrentView.CloseEditorForUpdating()

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                AnyJobsToBeClosed = (From Entity In DataGridViewForm_ProductionProcessControl.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl).ToList
                                     Where Entity.NewProcessControl.GetValueOrDefault(0) = 6 OrElse
                                           Entity.NewProcessControl.GetValueOrDefault(0) = 12).Any

                If AnyJobsToBeClosed AndAlso Not AdvantageFramework.Database.Procedures.Agency.ValidateClosedArchivedJobs(DbContext) Then

                    If AdvantageFramework.WinForm.MessageBox.Show("Validate closed/archived jobs is turned off.  Any selected jobs, marked to be Closed or Archive, with open charges will be closed/archived.  Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.No Then

                        AllowContinue = False

                    End If

                End If

                If AllowContinue Then

                    Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        For Each DataBoundItem In DataGridViewForm_ProductionProcessControl.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl).Where(Function(Entity) Entity.NewProcessControl.GetValueOrDefault(0) > 0).ToList

                            If DataBoundItem.NewProcessControl <> DataBoundItem.ProductionSummary.ProcessControl Then

                                ReturnValue = AdvantageFramework.BillingCommandCenter.UpdateProductionJobProcessControl(BCCDbContext, DataBoundItem.JobNumber, DataBoundItem.ComponentNumber, DataBoundItem.NewProcessControl, DataBoundItem.ProcessControlComments)

                                If DataBoundItem.ScheduleStatus IsNot Nothing AndAlso DataBoundItem.NewScheduleStatus IsNot Nothing AndAlso
                                        DataBoundItem.NewScheduleStatus <> DataBoundItem.ScheduleStatus Then

                                    AdvantageFramework.BillingCommandCenter.UpdateProductionJobProcessScheduleStatus(BCCDbContext, DataBoundItem.JobNumber, DataBoundItem.ComponentNumber, DataBoundItem.NewScheduleStatus)

                                End If

                                If ReturnValue = 0 Then

                                    ProductionSummary = _ProductionSummaryList.Where(Function(PS) PS.JobNumber = DataBoundItem.JobNumber AndAlso PS.ComponentNumber = DataBoundItem.ComponentNumber).FirstOrDefault

                                    If ProductionSummary IsNot Nothing Then

                                        _ProductionSummaryList.Remove(ProductionSummary)

                                        ProductionSummary = AdvantageFramework.BillingCommandCenter.GetProductionSummary(BCCDbContext, _BillingCommandCenterID, _IncludeContingency, DataBoundItem.JobNumber, DataBoundItem.ComponentNumber).FirstOrDefault

                                        If ProductionSummary IsNot Nothing Then

                                            _ProductionSummaryList.Add(ProductionSummary)

                                        End If

                                    End If

                                End If

                            End If

                        Next

                        LoadGrid()

                        Me.ClearChanged()

                        EnableOrDisableActions()

                    End Using

                End If

            End Using

        End Sub
        Private Sub DataGridViewForm_ProductionProcessControl_ColumnValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs, ViaCellValueChangedEvent As Boolean) Handles DataGridViewForm_ProductionProcessControl.ColumnValueChangedEvent

            'objects
            Dim ProductionProcessControl As AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl = Nothing

            If ViaCellValueChangedEvent AndAlso e.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.NewProcessControl.ToString Then

                ProductionProcessControl = DirectCast(DataGridViewForm_ProductionProcessControl.CurrentView.GetRow(DataGridViewForm_ProductionProcessControl.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl)

                If ProductionProcessControl IsNot Nothing AndAlso _StatusesNotAllowingAPEntry.Contains(e.Value) Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByJobNumber(DbContext, ProductionProcessControl.JobNumber).ToList
                            Where Entity.JobNumber = ProductionProcessControl.JobNumber AndAlso
                                  Entity.IsComplete.GetValueOrDefault(0) = 0).Any = True Then

                            AdvantageFramework.WinForm.MessageBox.Show("The status cannot be changed on selected job(s) because open purchase orders have been found.  Select a status that allows A/P to be entered.")

                            ProductionProcessControl.NewProcessControl = Nothing

                            DataGridViewForm_ProductionProcessControl.CurrentView.CloseEditor()

                            DataGridViewForm_ProductionProcessControl.CurrentView.RefreshData()

                        End If

                    End Using

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ProductionProcessControl_HideCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ProductionProcessControl.HideCustomizationFormEvent

            If ButtonItemGridOptions_ChooseColumns.Checked Then

                ButtonItemGridOptions_ChooseColumns.Checked = False

            End If

        End Sub
        Private Sub DataGridViewForm_ProductionProcessControl_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_ProductionProcessControl.QueryPopupNeedDatasourceEvent

            Dim ProductionProcessControl As AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl = Nothing

            If FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.NewProcessControl.ToString Then

                ProductionProcessControl = DirectCast(DataGridViewForm_ProductionProcessControl.CurrentView.GetRow(DataGridViewForm_ProductionProcessControl.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl)

                If ProductionProcessControl IsNot Nothing Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If AdvantageFramework.Database.Procedures.Agency.ValidateClosedArchivedJobs(DbContext) AndAlso
                            DataGridViewForm_ProductionProcessControl.CurrentView.GetRowCellValue(DataGridViewForm_ProductionProcessControl.CurrentView.FocusedRowHandle, AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.QualifiedToClose.ToString) = False Then

                            OverrideDefaultDatasource = True

                            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                                Datasource = (From Entity In AdvantageFramework.Database.Procedures.JobProcess.LoadOpen(DataContext)
                                              Where Entity.ID <> ProductionProcessControl.ProductionSummary.ProcessControl
                                              Select Entity).ToList

                            End Using

                        Else

                            OverrideDefaultDatasource = True

                            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                                Datasource = (From Entity In AdvantageFramework.Database.Procedures.JobProcess.Load(DataContext)
                                              Where Entity.ID <> ProductionProcessControl.ProductionSummary.ProcessControl
                                              Select Entity).ToList

                            End Using

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ProductionProcessControl_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_ProductionProcessControl.ShowingEditorEvent

            Dim ProductionProcessControl As AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl = Nothing

            ProductionProcessControl = DirectCast(DataGridViewForm_ProductionProcessControl.CurrentView.GetRow(DataGridViewForm_ProductionProcessControl.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl)

            If DataGridViewForm_ProductionProcessControl.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.NewScheduleStatus.ToString Then

                If Not (ProductionProcessControl.NewProcessControl.GetValueOrDefault(0) = 6 AndAlso String.IsNullOrWhiteSpace(ProductionProcessControl.ScheduleStatus) = False) Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_ProductionProcessControl.CurrentView.FocusedColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.ProcessControlComments.ToString Then

                If ProductionProcessControl.NewProcessControl.GetValueOrDefault(0) <= 0 Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub ButtonItemGridOptions_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_ChooseColumns.CheckedChanged

            Try

                If ButtonItemGridOptions_ChooseColumns.Checked Then

                    If DataGridViewForm_ProductionProcessControl.CurrentView.CustomizationForm Is Nothing Then

                        DataGridViewForm_ProductionProcessControl.CurrentView.ShowCustomization()

                    End If

                Else

                    If DataGridViewForm_ProductionProcessControl.CurrentView.CustomizationForm IsNot Nothing Then

                        DataGridViewForm_ProductionProcessControl.CurrentView.DestroyCustomization()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemGridOptions_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_RestoreDefaults.Click

            Me.ShowWaitForm("Loading...")

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterProcessControl, Session.UserCode)

            End Using

            DataGridViewForm_ProductionProcessControl.SetBookmarkColumnIndex(-1)
            DataGridViewForm_ProductionProcessControl.Columns.Clear()

            DataGridViewForm_ProductionProcessControl.ClearDatasource()

            LoadGrid()

            Me.ClearChanged()

            EnableOrDisableActions()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemProcessControl_ClearComments_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessControl_ClearComments.Click

            DataGridViewForm_ProductionProcessControl.CurrentView.CloseEditorForUpdating()

            For Each DataBoundItem In DataGridViewForm_ProductionProcessControl.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl).ToList

                DataBoundItem.ProcessControlComments = Nothing

                DataGridViewForm_ProductionProcessControl.SetUserEntryChanged()

            Next

            DataGridViewForm_ProductionProcessControl.CurrentView.RefreshData()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemProcessControl_CloseQualified_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessControl_CloseQualified.Click

            DataGridViewForm_ProductionProcessControl.CurrentView.CloseEditorForUpdating()

            For Each DataBoundItem In DataGridViewForm_ProductionProcessControl.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl).Where(Function(Entity) Entity.QualifiedToClose = True).ToList

                DataBoundItem.NewProcessControl = 6

                DataGridViewForm_ProductionProcessControl.SetUserEntryChanged()

            Next

            DataGridViewForm_ProductionProcessControl.CurrentView.RefreshData()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemProcessControl_MarkSelected_Click(sender As Object, e As EventArgs) Handles ButtonItemProcessControl_MarkSelected.Click

            SetNewProcessControl()

        End Sub
        Private Sub ButtonItemScheduleStatus_MarkSelected_Click(sender As Object, e As EventArgs) Handles ButtonItemScheduleStatus_MarkSelected.Click

            SetNewScheduleStatus()

        End Sub
        Private Sub ComboBoxProcessControl_JobProcess_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxProcessControl_JobProcess.SelectedValueChanged

            If ComboBoxProcessControl_JobProcess.GetSelectedValue = 6 AndAlso DataGridViewForm_ProductionProcessControl.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionProcessControl.Properties.NewScheduleStatus.ToString).Visible Then

                RibbonBarOptions_ScheduleStatus.Visible = True

            Else

                RibbonBarOptions_ScheduleStatus.Visible = False

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ComboBoxScheduleStatus_Status_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxScheduleStatus_Status.SelectedValueChanged

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
