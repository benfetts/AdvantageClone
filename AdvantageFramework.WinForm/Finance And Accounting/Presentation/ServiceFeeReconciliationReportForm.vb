Namespace FinanceAndAccounting.Presentation

    Public Class ServiceFeeReconciliationReportForm

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum NavigationType
            First
            Previous
            [Next]
            Last
            Refresh
        End Enum

#End Region

#Region " Variables "

        Private _ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile) = Nothing
        Private _ClientList As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
        Private _DivisionList As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
        Private _ProductList As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
        Private _ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting = Nothing
        Private _FeePostPeriodFrom As AdvantageFramework.Database.Entities.PostPeriod = Nothing
        Private _FeePostPeriodTo As AdvantageFramework.Database.Entities.PostPeriod = Nothing
        Private _FeeTimeFrom As Date = Nothing
        Private _FeeTimeTo As Date = Nothing
        Private _Index As Integer = 0
        Private _MaxIndex As Integer = 0
        Private WithEvents _BackgroundWorker As System.ComponentModel.BackgroundWorker = Nothing
        Private _IncomeOnlySalesClassCodes As Generic.List(Of String) = Nothing
        Private _IncomeOnlyFunctionCodes As Generic.List(Of String) = Nothing
        Private _ProductionCommissionSalesClassCodes As Generic.List(Of String) = Nothing
        Private _ProductionCommissionFunctionCodes As Generic.List(Of String) = Nothing
        Private _ServiceFeeTypeCodes As Generic.List(Of String) = Nothing
        Private _SelectedCriteria As IEnumerable = Nothing
        Private _ServiceFeeReconciliationReport As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport = Nothing
        Private _LoadServiceFeeReconciliationReportTemplate As Boolean = False
        Private _FirstAsyncCompleted As Boolean = False
        Private _FirstDetailAsyncCompleted As Boolean = False
        Private _SelectingAllRowsForReconciliation As Boolean = False
        Private WithEvents _GridViewServiceFeeDetailsLevel1Tab1 As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private WithEvents _GridViewServiceFeeDetailsLevel1Tab2 As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private _ServiceFeeReconciliationGroupByOption As AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job
        Private _ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee
        Private _SFRFilteredList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile) = Nothing
        Private _ClearColumnFilters As Boolean = True

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal FeePostPeriodFrom As AdvantageFramework.Database.Entities.PostPeriod, ByVal FeePostPeriodTo As AdvantageFramework.Database.Entities.PostPeriod,
                        ByVal SelectedCriteria As IEnumerable, ByVal FeeTimeFrom As Date, ByVal FeeTimeTo As Date, ByVal IncomeOnlySalesClassCodes As Generic.List(Of String), ByVal IncomeOnlyFunctionCodes As Generic.List(Of String),
                        ByVal ProductionCommissionSalesClassCodes As Generic.List(Of String), ByVal ProductionCommissionFunctionCodes As Generic.List(Of String), ServiceFeeTypeCodes As Generic.List(Of String),
                        ByVal ServiceFeeReconciliationGroupByOption As AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions,
                        ByVal ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _FeePostPeriodFrom = FeePostPeriodFrom
            _FeePostPeriodTo = FeePostPeriodTo
            _FeeTimeFrom = FeeTimeFrom
            _FeeTimeTo = FeeTimeTo
            _IncomeOnlySalesClassCodes = IncomeOnlySalesClassCodes
            _IncomeOnlyFunctionCodes = IncomeOnlyFunctionCodes
            _ProductionCommissionSalesClassCodes = ProductionCommissionSalesClassCodes
            _ProductionCommissionFunctionCodes = ProductionCommissionFunctionCodes
            _ServiceFeeTypeCodes = ServiceFeeTypeCodes
            _SelectedCriteria = SelectedCriteria
            _ServiceFeeReconciliationGroupByOption = ServiceFeeReconciliationGroupByOption
            _ServiceFeeReconciliationSummaryStyle = ServiceFeeReconciliationSummaryStyle

        End Sub
        Private Sub Navigate(ByVal NavigationType As NavigationType)

            If NavigationType = ServiceFeeReconciliationReportForm.NavigationType.First Then

                _Index = 0

            ElseIf NavigationType = ServiceFeeReconciliationReportForm.NavigationType.Previous Then

                If _Index > 0 Then

                    _Index -= 1

                End If

            ElseIf NavigationType = ServiceFeeReconciliationReportForm.NavigationType.Next Then

                If _Index < _MaxIndex Then

                    _Index += 1

                End If

            ElseIf NavigationType = ServiceFeeReconciliationReportForm.NavigationType.Last Then

                _Index = _MaxIndex

            ElseIf NavigationType = ServiceFeeReconciliationReportForm.NavigationType.Refresh Then

                _Index = _Index

            End If

            If NavigationType = ServiceFeeReconciliationReportForm.NavigationType.Refresh Then

                _ClearColumnFilters = False

            Else

                _ClearColumnFilters = True

            End If

            ButtonItemNavigation_First.Enabled = False
            ButtonItemNavigation_Previous.Enabled = False
            ButtonItemNavigation_Next.Enabled = False
            ButtonItemNavigation_Last.Enabled = False
            ButtonItemPrinting_PrintGrid.Enabled = False
            ButtonItemPrinting_PrintFullReport.Enabled = False
            ButtonItemPrinting_PrintSelectedReport.Enabled = False
            ButtonItemSystem_Close.Enabled = False
            DataGridViewForm_ServiceFees.Enabled = False

            ButtonItemReconcile_Reconcile.Enabled = False
            ButtonItemReconcile_Unreconcile.Enabled = False

            ProgressBarItemStatusBar_ProgressBar.Minimum = 0
            ProgressBarItemStatusBar_ProgressBar.Maximum = 9
            ProgressBarItemStatusBar_ProgressBar.Value = 0
            ProgressBarItemStatusBar_ProgressBar.Visible = True

            Me.ShowWaitForm("Processing...")

            Me.Refresh()

            _BackgroundWorker = New System.ComponentModel.BackgroundWorker

            _BackgroundWorker.WorkerReportsProgress = True

            _BackgroundWorker.RunWorkerAsync()

        End Sub
        Private Sub SaveServiceFeeReconciliationReportTemplate()

            'objects
            Dim ServiceFeeReconciliationReportColumn As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReportColumn = Nothing
            Dim ServiceFeeReconciliationReportSummaryItem As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReportSummaryItem = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _ServiceFeeReconciliationReport.AllowCellMerge = ButtonItemViewLeft_AllowCellMerging.Checked
                _ServiceFeeReconciliationReport.AutoSizeColumnsWhenPrinting = ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked
                _ServiceFeeReconciliationReport.PrintHeader = ButtonItemOptionsMiddle_PrintHeader.Checked
                _ServiceFeeReconciliationReport.PrintFooter = ButtonItemOptionsMiddle_PrintFooter.Checked
                _ServiceFeeReconciliationReport.PrintGroupFooter = ButtonItemOptionsMiddle_PrintGroupFooter.Checked
                _ServiceFeeReconciliationReport.PrintSelectedRowsOnly = ButtonItemOptionsRight_PrintSelectedRowsOnly.Checked
                _ServiceFeeReconciliationReport.PrintFilterInformation = ButtonItemOptionsLeft_PrintFilterInfo.Checked
                _ServiceFeeReconciliationReport.ShowGroupByBox = ButtonItemViewLeft_ShowGroupByBox.Checked
                _ServiceFeeReconciliationReport.ShowViewCaption = ButtonItemViewLeft_ShowViewCaption.Checked
                _ServiceFeeReconciliationReport.ShowAutoFilterRow = ButtonItemFilter_ShowAutoFilterRow.Checked
                _ServiceFeeReconciliationReport.ActiveFilter = DataGridViewForm_ServiceFees.CurrentView.AFActiveFilterString

                _ServiceFeeReconciliationReport.UpdatedByUserCode = Me.Session.UserCode
                _ServiceFeeReconciliationReport.UpdatedDate = Now

                _ServiceFeeReconciliationReport.GroupByOption = _ServiceFeeReconciliationGroupByOption
                _ServiceFeeReconciliationReport.SummaryStyle = _ServiceFeeReconciliationSummaryStyle

                If AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReport.Update(SecurityDbContext, _ServiceFeeReconciliationReport) Then

                    For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(Column) Column.OptionsColumn.AllowShowHide = True).ToList

                        ServiceFeeReconciliationReportColumn = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportColumn.LoadByServiceFeeReconciliationReportIDAndFieldNameAndGridViewID(SecurityDbContext, _ServiceFeeReconciliationReport.ID, GridColumn.FieldName, 0)

                        If ServiceFeeReconciliationReportColumn IsNot Nothing Then

                            ServiceFeeReconciliationReportColumn.HeaderText = GridColumn.ToString
                            ServiceFeeReconciliationReportColumn.IsVisible = GridColumn.Visible
                            ServiceFeeReconciliationReportColumn.SortIndex = GridColumn.SortIndex
                            ServiceFeeReconciliationReportColumn.SortOrder = GridColumn.SortOrder
                            ServiceFeeReconciliationReportColumn.GroupIndex = GridColumn.GroupIndex
                            ServiceFeeReconciliationReportColumn.Width = GridColumn.Width
                            ServiceFeeReconciliationReportColumn.VisibleIndex = GridColumn.VisibleIndex

                            AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportColumn.Update(SecurityDbContext, ServiceFeeReconciliationReportColumn)

                        Else

                            AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportColumn.Insert(SecurityDbContext, _ServiceFeeReconciliationReport.ID, GridColumn.FieldName,
                                                                                                                        GridColumn.ToString, GridColumn.Visible, GridColumn.SortIndex,
                                                                                                                        GridColumn.SortOrder, GridColumn.GroupIndex, GridColumn.Width,
                                                                                                                        GridColumn.VisibleIndex, 0, Nothing)

                        End If

                    Next

                    For Each GridColumn In _GridViewServiceFeeDetailsLevel1Tab1.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(Column) Column.OptionsColumn.AllowShowHide = True).ToList

                        ServiceFeeReconciliationReportColumn = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportColumn.LoadByServiceFeeReconciliationReportIDAndFieldNameAndGridViewID(SecurityDbContext, _ServiceFeeReconciliationReport.ID, GridColumn.FieldName, 1)

                        If ServiceFeeReconciliationReportColumn IsNot Nothing Then

                            ServiceFeeReconciliationReportColumn.HeaderText = GridColumn.ToString
                            ServiceFeeReconciliationReportColumn.IsVisible = GridColumn.Visible
                            ServiceFeeReconciliationReportColumn.SortIndex = GridColumn.SortIndex
                            ServiceFeeReconciliationReportColumn.SortOrder = GridColumn.SortOrder
                            ServiceFeeReconciliationReportColumn.GroupIndex = GridColumn.GroupIndex
                            ServiceFeeReconciliationReportColumn.Width = GridColumn.Width
                            ServiceFeeReconciliationReportColumn.VisibleIndex = GridColumn.VisibleIndex

                            AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportColumn.Update(SecurityDbContext, ServiceFeeReconciliationReportColumn)

                        Else

                            AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportColumn.Insert(SecurityDbContext, _ServiceFeeReconciliationReport.ID, GridColumn.FieldName,
                                                                                                                        GridColumn.ToString, GridColumn.Visible, GridColumn.SortIndex,
                                                                                                                        GridColumn.SortOrder, GridColumn.GroupIndex, GridColumn.Width,
                                                                                                                        GridColumn.VisibleIndex, 1, Nothing)

                        End If

                    Next

                    For Each GridColumn In _GridViewServiceFeeDetailsLevel1Tab2.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(Column) Column.OptionsColumn.AllowShowHide = True).ToList

                        ServiceFeeReconciliationReportColumn = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportColumn.LoadByServiceFeeReconciliationReportIDAndFieldNameAndGridViewID(SecurityDbContext, _ServiceFeeReconciliationReport.ID, GridColumn.FieldName, 2)

                        If ServiceFeeReconciliationReportColumn IsNot Nothing Then

                            ServiceFeeReconciliationReportColumn.HeaderText = GridColumn.ToString
                            ServiceFeeReconciliationReportColumn.IsVisible = GridColumn.Visible
                            ServiceFeeReconciliationReportColumn.SortIndex = GridColumn.SortIndex
                            ServiceFeeReconciliationReportColumn.SortOrder = GridColumn.SortOrder
                            ServiceFeeReconciliationReportColumn.GroupIndex = GridColumn.GroupIndex
                            ServiceFeeReconciliationReportColumn.Width = GridColumn.Width
                            ServiceFeeReconciliationReportColumn.VisibleIndex = GridColumn.VisibleIndex

                            AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportColumn.Update(SecurityDbContext, ServiceFeeReconciliationReportColumn)

                        Else

                            AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportColumn.Insert(SecurityDbContext, _ServiceFeeReconciliationReport.ID, GridColumn.FieldName,
                                                                                                                        GridColumn.ToString, GridColumn.Visible, GridColumn.SortIndex,
                                                                                                                        GridColumn.SortOrder, GridColumn.GroupIndex, GridColumn.Width,
                                                                                                                        GridColumn.VisibleIndex, 2, Nothing)

                        End If

                    Next

                    For Each ServiceFeeReconciliationReportSummaryItem In AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportSummaryItem.LoadByServiceFeeReconciliationReportID(SecurityDbContext, _ServiceFeeReconciliationReport.ID).ToList

                        AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportSummaryItem.Delete(SecurityDbContext, ServiceFeeReconciliationReportSummaryItem)

                    Next

                    For Each GridGroupSummaryItem In DataGridViewForm_ServiceFees.CurrentView.GroupSummary.OfType(Of DevExpress.XtraGrid.GridGroupSummaryItem)()

                        AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportSummaryItem.Insert(SecurityDbContext, _ServiceFeeReconciliationReport.ID, GridGroupSummaryItem.SummaryType,
                                                                                                                         GridGroupSummaryItem.FieldName, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, False, True),
                                                                                                                         GridGroupSummaryItem.DisplayFormat, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, "", GridGroupSummaryItem.FieldName),
                                                                                                                         0, Nothing)

                    Next

                    For Each GridGroupSummaryItem In _GridViewServiceFeeDetailsLevel1Tab1.GroupSummary.OfType(Of DevExpress.XtraGrid.GridGroupSummaryItem)()

                        AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportSummaryItem.Insert(SecurityDbContext, _ServiceFeeReconciliationReport.ID, GridGroupSummaryItem.SummaryType,
                                                                                                                         GridGroupSummaryItem.FieldName, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, False, True),
                                                                                                                         GridGroupSummaryItem.DisplayFormat, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, "", GridGroupSummaryItem.FieldName),
                                                                                                                         1, Nothing)

                    Next

                    For Each GridGroupSummaryItem In _GridViewServiceFeeDetailsLevel1Tab2.GroupSummary.OfType(Of DevExpress.XtraGrid.GridGroupSummaryItem)()

                        AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportSummaryItem.Insert(SecurityDbContext, _ServiceFeeReconciliationReport.ID, GridGroupSummaryItem.SummaryType,
                                                                                                                         GridGroupSummaryItem.FieldName, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, False, True),
                                                                                                                         GridGroupSummaryItem.DisplayFormat, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, "", GridGroupSummaryItem.FieldName),
                                                                                                                         2, Nothing)

                    Next

                End If

            End Using

        End Sub
        Private Sub SaveAsServiceFeeReconciliationReportTemplate()

            'objects
            Dim Description As String = ""

            If AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Report Template",
                                                                                  "Enter Report Template Description:", "", Description,
                                                                                  AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport.Properties.Description) = System.Windows.Forms.DialogResult.OK Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReport.Insert(SecurityDbContext, Description, SecurityDbContext.UserCode, Now,
                                                                                                             ButtonItemViewLeft_AllowCellMerging.Checked, ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked,
                                                                                                             ButtonItemOptionsMiddle_PrintHeader.Checked, ButtonItemOptionsMiddle_PrintFooter.Checked,
                                                                                                             ButtonItemOptionsMiddle_PrintGroupFooter.Checked, ButtonItemOptionsRight_PrintSelectedRowsOnly.Checked,
                                                                                                             ButtonItemOptionsLeft_PrintFilterInfo.Checked, ButtonItemFilter_ShowAutoFilterRow.Checked,
                                                                                                             DataGridViewForm_ServiceFees.CurrentView.AFActiveFilterString, ButtonItemViewLeft_ShowGroupByBox.Checked,
                                                                                                             ButtonItemViewLeft_ShowViewCaption.Checked, _ServiceFeeReconciliationGroupByOption, _ServiceFeeReconciliationSummaryStyle,
                                                                                                             _ServiceFeeReconciliationReport) Then

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(Column) Column.OptionsColumn.AllowShowHide = True).ToList

                            AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportColumn.Insert(SecurityDbContext, _ServiceFeeReconciliationReport.ID, GridColumn.FieldName,
                                                                                                                        GridColumn.Caption, GridColumn.Visible, GridColumn.SortIndex,
                                                                                                                        GridColumn.SortOrder, GridColumn.GroupIndex, GridColumn.Width,
                                                                                                                        GridColumn.VisibleIndex, 0, Nothing)

                        Next

                        For Each GridColumn In _GridViewServiceFeeDetailsLevel1Tab1.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(Column) Column.OptionsColumn.AllowShowHide = True).ToList

                            AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportColumn.Insert(SecurityDbContext, _ServiceFeeReconciliationReport.ID, GridColumn.FieldName,
                                                                                                                        GridColumn.Caption, GridColumn.Visible, GridColumn.SortIndex,
                                                                                                                        GridColumn.SortOrder, GridColumn.GroupIndex, GridColumn.Width,
                                                                                                                        GridColumn.VisibleIndex, 1, Nothing)

                        Next

                        For Each GridColumn In _GridViewServiceFeeDetailsLevel1Tab2.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(Column) Column.OptionsColumn.AllowShowHide = True).ToList

                            AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportColumn.Insert(SecurityDbContext, _ServiceFeeReconciliationReport.ID, GridColumn.FieldName,
                                                                                                                        GridColumn.Caption, GridColumn.Visible, GridColumn.SortIndex,
                                                                                                                        GridColumn.SortOrder, GridColumn.GroupIndex, GridColumn.Width,
                                                                                                                        GridColumn.VisibleIndex, 2, Nothing)

                        Next

                        For Each GridGroupSummaryItem In DataGridViewForm_ServiceFees.CurrentView.GroupSummary.OfType(Of DevExpress.XtraGrid.GridGroupSummaryItem)()

                            AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportSummaryItem.Insert(SecurityDbContext, _ServiceFeeReconciliationReport.ID, GridGroupSummaryItem.SummaryType,
                                                                                                                             GridGroupSummaryItem.FieldName, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, False, True),
                                                                                                                             GridGroupSummaryItem.DisplayFormat, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, "", GridGroupSummaryItem.ShowInGroupColumnFooter.FieldName),
                                                                                                                             0, Nothing)

                        Next

                        For Each GridGroupSummaryItem In _GridViewServiceFeeDetailsLevel1Tab1.GroupSummary.OfType(Of DevExpress.XtraGrid.GridGroupSummaryItem)()

                            AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportSummaryItem.Insert(SecurityDbContext, _ServiceFeeReconciliationReport.ID, GridGroupSummaryItem.SummaryType,
                                                                                                                             GridGroupSummaryItem.FieldName, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, False, True),
                                                                                                                             GridGroupSummaryItem.DisplayFormat, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, "", GridGroupSummaryItem.FieldName),
                                                                                                                             1, Nothing)

                        Next

                        For Each GridGroupSummaryItem In _GridViewServiceFeeDetailsLevel1Tab2.GroupSummary.OfType(Of DevExpress.XtraGrid.GridGroupSummaryItem)()

                            AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportSummaryItem.Insert(SecurityDbContext, _ServiceFeeReconciliationReport.ID, GridGroupSummaryItem.SummaryType,
                                                                                                                             GridGroupSummaryItem.FieldName, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, False, True),
                                                                                                                             GridGroupSummaryItem.DisplayFormat, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, "", GridGroupSummaryItem.FieldName),
                                                                                                                             2, Nothing)

                        Next

                    End If

                End Using

            End If

        End Sub
        Private Sub LoadServiceFeeReconciliationReportTemplate(ByVal ServiceFeeReconciliationReportID As Integer, ByVal RefreshTemplate As Boolean)

            'objects
            Dim ServiceFeeReconciliationReportColumn As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReportColumn = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim GridGroupSummaryItem As DevExpress.XtraGrid.GridGroupSummaryItem = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    _ServiceFeeReconciliationReport = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReport.LoadByServiceFeeReconciliationReportID(SecurityDbContext, ServiceFeeReconciliationReportID)

                Catch ex As Exception
                    _ServiceFeeReconciliationReport = Nothing
                End Try

                If _ServiceFeeReconciliationReport IsNot Nothing Then

                    If RefreshTemplate Then

                        _LoadServiceFeeReconciliationReportTemplate = True
                        _FirstAsyncCompleted = True

                        If _ServiceFeeReconciliationReport.SummaryStyle <> _ServiceFeeReconciliationSummaryStyle Then

                            _ServiceFeeReconciliationSummaryStyle = _ServiceFeeReconciliationReport.SummaryStyle

                            DataGridViewForm_ServiceFees.GridControl.LevelTree.Nodes.Clear()

                            LoadDetailViews()

                        End If

                        If _ServiceFeeReconciliationReport.GroupByOption <> _ServiceFeeReconciliationGroupByOption Then

                            _ServiceFeeReconciliationGroupByOption = _ServiceFeeReconciliationReport.GroupByOption

                            DataGridViewForm_ServiceFees.CurrentView.ClearSorting()
                            DataGridViewForm_ServiceFees.CurrentView.ClearColumnsFilter()
                            DataGridViewForm_ServiceFees.CurrentView.ClearGrouping()
                            DataGridViewForm_ServiceFees.CurrentView.GroupSummary.Clear()

                            DataGridViewForm_ServiceFees.ClearColumns()

                            Navigate(NavigationType.First)

                        End If

                        ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked = _ServiceFeeReconciliationReport.AutoSizeColumnsWhenPrinting
                        ButtonItemOptionsLeft_PrintFilterInfo.Checked = _ServiceFeeReconciliationReport.PrintFilterInformation
                        ButtonItemOptionsMiddle_PrintFooter.Checked = _ServiceFeeReconciliationReport.PrintFooter
                        ButtonItemOptionsMiddle_PrintGroupFooter.Checked = _ServiceFeeReconciliationReport.PrintGroupFooter
                        ButtonItemOptionsMiddle_PrintHeader.Checked = _ServiceFeeReconciliationReport.PrintHeader
                        ButtonItemOptionsRight_PrintSelectedRowsOnly.Checked = _ServiceFeeReconciliationReport.PrintSelectedRowsOnly
                        ButtonItemViewLeft_AllowCellMerging.Checked = _ServiceFeeReconciliationReport.AllowCellMerge
                        ButtonItemViewLeft_ShowGroupByBox.Checked = _ServiceFeeReconciliationReport.ShowGroupByBox
                        ButtonItemViewLeft_ShowViewCaption.Checked = _ServiceFeeReconciliationReport.ShowViewCaption
                        ButtonItemFilter_ShowAutoFilterRow.Checked = _ServiceFeeReconciliationReport.ShowAutoFilterRow

                        DataGridViewForm_ServiceFees.CurrentView.AFActiveFilterString = _ServiceFeeReconciliationReport.ActiveFilter

                        For Each ServiceFeeReconciliationReportColumn In AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportColumn.LoadByServiceFeeReconciliationReportIDAndGridViewID(SecurityDbContext, _ServiceFeeReconciliationReport.ID, 0).OrderBy(Function(Column) Column.VisibleIndex).ToList

                            GridColumn = DataGridViewForm_ServiceFees.Columns(ServiceFeeReconciliationReportColumn.FieldName)

                            If GridColumn IsNot Nothing Then

                                GridColumn.Caption = ServiceFeeReconciliationReportColumn.HeaderText
                                GridColumn.Visible = ServiceFeeReconciliationReportColumn.IsVisible
                                GridColumn.SortIndex = ServiceFeeReconciliationReportColumn.SortIndex
                                GridColumn.SortOrder = ServiceFeeReconciliationReportColumn.SortOrder
                                GridColumn.GroupIndex = ServiceFeeReconciliationReportColumn.GroupIndex
                                GridColumn.Width = ServiceFeeReconciliationReportColumn.Width
                                GridColumn.VisibleIndex = ServiceFeeReconciliationReportColumn.VisibleIndex

                            End If

                        Next

                        For Each ServiceFeeReconciliationReportColumn In AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportColumn.LoadByServiceFeeReconciliationReportIDAndGridViewID(SecurityDbContext, _ServiceFeeReconciliationReport.ID, 1).OrderBy(Function(Column) Column.VisibleIndex).ToList

                            GridColumn = _GridViewServiceFeeDetailsLevel1Tab1.Columns(ServiceFeeReconciliationReportColumn.FieldName)

                            If GridColumn IsNot Nothing Then

                                GridColumn.Caption = ServiceFeeReconciliationReportColumn.HeaderText
                                GridColumn.Visible = ServiceFeeReconciliationReportColumn.IsVisible
                                GridColumn.SortIndex = ServiceFeeReconciliationReportColumn.SortIndex
                                GridColumn.SortOrder = ServiceFeeReconciliationReportColumn.SortOrder
                                GridColumn.GroupIndex = ServiceFeeReconciliationReportColumn.GroupIndex
                                GridColumn.Width = ServiceFeeReconciliationReportColumn.Width
                                GridColumn.VisibleIndex = ServiceFeeReconciliationReportColumn.VisibleIndex

                            End If

                        Next

                        For Each ServiceFeeReconciliationReportColumn In AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportColumn.LoadByServiceFeeReconciliationReportIDAndGridViewID(SecurityDbContext, _ServiceFeeReconciliationReport.ID, 2).OrderBy(Function(Column) Column.VisibleIndex).ToList

                            GridColumn = _GridViewServiceFeeDetailsLevel1Tab2.Columns(ServiceFeeReconciliationReportColumn.FieldName)

                            If GridColumn IsNot Nothing Then

                                GridColumn.Caption = ServiceFeeReconciliationReportColumn.HeaderText
                                GridColumn.Visible = ServiceFeeReconciliationReportColumn.IsVisible
                                GridColumn.SortIndex = ServiceFeeReconciliationReportColumn.SortIndex
                                GridColumn.SortOrder = ServiceFeeReconciliationReportColumn.SortOrder
                                GridColumn.GroupIndex = ServiceFeeReconciliationReportColumn.GroupIndex
                                GridColumn.Width = ServiceFeeReconciliationReportColumn.Width
                                GridColumn.VisibleIndex = ServiceFeeReconciliationReportColumn.VisibleIndex

                            End If

                        Next

                        For Each ServiceFeeReconciliationReportSummaryItem In AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportSummaryItem.LoadByServiceFeeReconciliationReportIDAndGridViewID(SecurityDbContext, _ServiceFeeReconciliationReport.ID, 0).ToList

                            GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem

                            GridGroupSummaryItem.SummaryType = ServiceFeeReconciliationReportSummaryItem.SummaryItemType
                            GridGroupSummaryItem.FieldName = ServiceFeeReconciliationReportSummaryItem.FieldName
                            GridGroupSummaryItem.DisplayFormat = ServiceFeeReconciliationReportSummaryItem.DisplayFormat

                            If ServiceFeeReconciliationReportSummaryItem.OnFooter Then

                                GridGroupSummaryItem.ShowInGroupColumnFooter = DataGridViewForm_ServiceFees.Columns(ServiceFeeReconciliationReportSummaryItem.FieldName)

                            End If

                            DataGridViewForm_ServiceFees.CurrentView.GroupSummary.Add(GridGroupSummaryItem)

                        Next

                        For Each ServiceFeeReconciliationReportSummaryItem In AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportSummaryItem.LoadByServiceFeeReconciliationReportIDAndGridViewID(SecurityDbContext, _ServiceFeeReconciliationReport.ID, 1).ToList

                            GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem

                            GridGroupSummaryItem.SummaryType = ServiceFeeReconciliationReportSummaryItem.SummaryItemType
                            GridGroupSummaryItem.FieldName = ServiceFeeReconciliationReportSummaryItem.FieldName
                            GridGroupSummaryItem.DisplayFormat = ServiceFeeReconciliationReportSummaryItem.DisplayFormat

                            If ServiceFeeReconciliationReportSummaryItem.OnFooter Then

                                GridGroupSummaryItem.ShowInGroupColumnFooter = _GridViewServiceFeeDetailsLevel1Tab1.Columns(ServiceFeeReconciliationReportSummaryItem.FieldName)

                            End If

                            _GridViewServiceFeeDetailsLevel1Tab1.GroupSummary.Add(GridGroupSummaryItem)

                        Next

                        For Each ServiceFeeReconciliationReportSummaryItem In AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportSummaryItem.LoadByServiceFeeReconciliationReportIDAndGridViewID(SecurityDbContext, _ServiceFeeReconciliationReport.ID, 2).ToList

                            GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem

                            GridGroupSummaryItem.SummaryType = ServiceFeeReconciliationReportSummaryItem.SummaryItemType
                            GridGroupSummaryItem.FieldName = ServiceFeeReconciliationReportSummaryItem.FieldName
                            GridGroupSummaryItem.DisplayFormat = ServiceFeeReconciliationReportSummaryItem.DisplayFormat

                            If ServiceFeeReconciliationReportSummaryItem.OnFooter Then

                                GridGroupSummaryItem.ShowInGroupColumnFooter = _GridViewServiceFeeDetailsLevel1Tab2.Columns(ServiceFeeReconciliationReportSummaryItem.FieldName)

                            End If

                            _GridViewServiceFeeDetailsLevel1Tab2.GroupSummary.Add(GridGroupSummaryItem)

                        Next

                        _LoadServiceFeeReconciliationReportTemplate = False

                    End If

                End If

            End Using

        End Sub
		Private Sub LoadReportData()

			'objects
			Dim FeeTypesList As Generic.List(Of String) = Nothing

			Me.ShowWaitForm()
			Me.ShowWaitForm("Loading Data...")

			Try

				Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

					Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

						_ServiceFeeReconcileDetailList = AdvantageFramework.Reporting.LoadServiceFeeReconciliationData(Me.Session, SecurityDbContext, DbContext, _ServiceFeeReconciliationSetting,
																													   _SelectedCriteria, _IncomeOnlySalesClassCodes, _IncomeOnlyFunctionCodes,
																													   _ProductionCommissionSalesClassCodes, _ProductionCommissionFunctionCodes, _ServiceFeeTypeCodes,
																													   _FeePostPeriodFrom, _FeePostPeriodTo, _FeeTimeFrom, _FeeTimeTo,
																													   _ClientList, _DivisionList, _ProductList, _MaxIndex, True)

					End Using

				End Using

			Catch ex As Exception

			End Try

			Me.CloseWaitForm()

		End Sub
		Private Sub Reconciliation(ByVal IsReconciled As Short)

            'objects
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Integer = 0
            Dim FunctionCode As String = ""
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim ServiceFeeReconcileDetail As AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail = Nothing
            Dim EmployeeTimeDetail As AdvantageFramework.Database.Entities.EmployeeTimeDetail = Nothing
            Dim EmployeeTimeDetailList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeDetail) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For RowHandle = 0 To DataGridViewForm_ServiceFees.CurrentView.RowCount - 1

                    Try

                        BaseView = DataGridViewForm_ServiceFees.CurrentView.GetDetailView(RowHandle, 0)

                    Catch ex As Exception
                        BaseView = Nothing
                    End Try

                    If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                        For BaseViewRowHandle = 0 To BaseView.RowCount - 1

                            JobNumber = BaseView.GetRowCellValue(BaseViewRowHandle, "JobNumber")
                            JobComponentNumber = BaseView.GetRowCellValue(BaseViewRowHandle, "ComponentNumber")
                            FunctionCode = BaseView.GetRowCellValue(BaseViewRowHandle, "FunctionCode")

                            Try

                                ServiceFeeReconcileDetail = BaseView.GetRow(BaseViewRowHandle)

                            Catch ex As Exception
                                ServiceFeeReconcileDetail = Nothing
                            End Try

                            If ServiceFeeReconcileDetail IsNot Nothing Then

                                If ServiceFeeReconcileDetail.Reconcile Then

                                    EmployeeTimeDetailList = AdvantageFramework.Database.Procedures.EmployeeTimeDetail.Load(DbContext).Include("EmployeeTime").Where(Function(ETD) ETD.JobNumber = JobNumber AndAlso ETD.JobComponentNumber = JobComponentNumber AndAlso ETD.FunctionCode = FunctionCode AndAlso ETD.EmployeeTime.Date = ServiceFeeReconcileDetail.FeeDate).ToList

                                    For Each EmployeeTimeDetail In EmployeeTimeDetailList

                                        If EmployeeTimeDetail.EmployeeTime.Date >= _FeeTimeFrom AndAlso EmployeeTimeDetail.EmployeeTime.Date <= _FeeTimeTo Then

                                            EmployeeTimeDetail.IsReconciled = IsReconciled

                                            If IsReconciled = 0 Then

                                                EmployeeTimeDetail.ReconciledUserCode = Nothing
                                                EmployeeTimeDetail.ReconciledDate = Nothing

                                            Else

                                                EmployeeTimeDetail.ReconciledUserCode = Me.Session.User.UserCode
                                                EmployeeTimeDetail.ReconciledDate = Now

                                            End If

                                            DbContext.UpdateObject(EmployeeTimeDetail)

                                        End If

                                    Next

                                    Try

                                        DbContext.SaveChanges()

                                    Catch ex As Exception

                                    End Try

                                End If

                            End If

                        Next

                    End If

                Next

            End Using

        End Sub
        Private Sub SelectDeselectAll(ByVal Reconcile As Boolean)

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim ServiceFeeReconcileDetail As AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail = Nothing
            Dim EnableButtons As Boolean = False

            _SelectingAllRowsForReconciliation = True

            For RowHandle = 0 To DataGridViewForm_ServiceFees.CurrentView.RowCount - 1

                If DataGridViewForm_ServiceFees.CurrentView.GetRowExpanded(RowHandle) = False Then

                    Try

                        DataGridViewForm_ServiceFees.CurrentView.ExpandMasterRow(RowHandle, 0)

                    Catch ex As Exception

                    End Try

                End If

                Try

                    BaseView = DataGridViewForm_ServiceFees.CurrentView.GetDetailView(RowHandle, 0)

                Catch ex As Exception
                    BaseView = Nothing
                End Try

                If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                    For BaseViewRowHandle = 0 To BaseView.RowCount - 1

                        BaseView.SetRowCellValue(BaseViewRowHandle, AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.Reconcile.ToString, Reconcile)

                        EnableButtons = Reconcile

                        Try

                            ServiceFeeReconcileDetail = BaseView.GetRow(BaseViewRowHandle)

                        Catch ex As Exception
                            ServiceFeeReconcileDetail = Nothing
                        End Try

                        If ServiceFeeReconcileDetail IsNot Nothing Then

                            ServiceFeeReconcileDetail.Reconcile = Reconcile

                        End If

                    Next

                End If

                Try

                    If Reconcile = False Then

                        DataGridViewForm_ServiceFees.CurrentView.CollapseMasterRow(RowHandle)

                    End If

                Catch ex As Exception

                End Try

            Next

            _SelectingAllRowsForReconciliation = False

            ButtonItemReconcile_Reconcile.Enabled = EnableButtons
            ButtonItemReconcile_Unreconcile.Enabled = EnableButtons

        End Sub
        Private Sub LoadDetailViews()

            DataGridViewForm_ServiceFees.CurrentView.BeginUpdate()

            _GridViewServiceFeeDetailsLevel1Tab1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView
            _GridViewServiceFeeDetailsLevel1Tab2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView

            _GridViewServiceFeeDetailsLevel1Tab1.SkipAddingControlsOnModifyColumn = True
            _GridViewServiceFeeDetailsLevel1Tab2.SkipAddingControlsOnModifyColumn = True

            _GridViewServiceFeeDetailsLevel1Tab1.SkipSettingFontOnModifyColumn = True
            _GridViewServiceFeeDetailsLevel1Tab2.SkipSettingFontOnModifyColumn = True

            DataGridViewForm_ServiceFees.GridControl.LevelTree.Nodes.Add("ServiceFeeDetailsLevel1Tab1", _GridViewServiceFeeDetailsLevel1Tab1)
            DataGridViewForm_ServiceFees.GridControl.LevelTree.Nodes.Add("ServiceFeeDetailsLevel1Tab2", _GridViewServiceFeeDetailsLevel1Tab2)

            _GridViewServiceFeeDetailsLevel1Tab1.LevelIndent = 1
            _GridViewServiceFeeDetailsLevel1Tab2.LevelIndent = 1

            _GridViewServiceFeeDetailsLevel1Tab1.ChildGridLevelName = "ServiceFeeDetailsLevel1Tab1"
            _GridViewServiceFeeDetailsLevel1Tab1.GridControl = DataGridViewForm_ServiceFees.GridControl
            _GridViewServiceFeeDetailsLevel1Tab1.Name = "_GridViewServiceFeeDetailsLevel1Tab1"

            _GridViewServiceFeeDetailsLevel1Tab2.ChildGridLevelName = "ServiceFeeDetailsLevel1Tab2"
            _GridViewServiceFeeDetailsLevel1Tab2.GridControl = DataGridViewForm_ServiceFees.GridControl
            _GridViewServiceFeeDetailsLevel1Tab2.Name = "_GridViewServiceFeeDetailsLevel1Tab2"

            _GridViewServiceFeeDetailsLevel1Tab1.Session = Me.Session
            _GridViewServiceFeeDetailsLevel1Tab2.Session = Me.Session

            _GridViewServiceFeeDetailsLevel1Tab1.ControlType = WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            _GridViewServiceFeeDetailsLevel1Tab2.ControlType = WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid

            _GridViewServiceFeeDetailsLevel1Tab1.ObjectType = GetType(AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail)
            _GridViewServiceFeeDetailsLevel1Tab2.ObjectType = GetType(AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail)

            _GridViewServiceFeeDetailsLevel1Tab1.OptionsDetail.ShowDetailTabs = False
            _GridViewServiceFeeDetailsLevel1Tab2.OptionsDetail.ShowDetailTabs = False

            _GridViewServiceFeeDetailsLevel1Tab1.OptionsView.ShowViewCaption = False
            _GridViewServiceFeeDetailsLevel1Tab2.OptionsView.ShowViewCaption = False

            _GridViewServiceFeeDetailsLevel1Tab1.CreateColumnsBasedOnObjectType()
            _GridViewServiceFeeDetailsLevel1Tab2.CreateColumnsBasedOnObjectType()

            _GridViewServiceFeeDetailsLevel1Tab1.OptionsBehavior.Editable = True
            _GridViewServiceFeeDetailsLevel1Tab2.OptionsBehavior.Editable = False

            If _ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    For Each GridColumn In _GridViewServiceFeeDetailsLevel1Tab1.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.TotalHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.TotalAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeTimeType.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.Reconcile.ToString Then

                            GridColumn.AppearanceCell.Font = New System.Drawing.Font("Arial", 8)
                            GridColumn.AppearanceHeader.Font = New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold)

                            GridColumn.Visible = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.TotalHours.ToString Then

                                GridColumn.Caption = "Total Hrs\Qty"

                            End If

                        Else

                            _GridViewServiceFeeDetailsLevel1Tab1.Columns.Remove(GridColumn)
                            'GridColumn.Visible = False
                            'GridColumn.OptionsColumn.AllowShowHide = False
                            'GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            'GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                ElseIf _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Employee Then

                    For Each GridColumn In _GridViewServiceFeeDetailsLevel1Tab1.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeDate.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.TotalHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.TotalAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.Reconcile.ToString Then

                            GridColumn.AppearanceCell.Font = New System.Drawing.Font("Arial", 8)
                            GridColumn.AppearanceHeader.Font = New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold)

                            GridColumn.Visible = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.TotalHours.ToString Then

                                GridColumn.Caption = "Total Hrs\Qty"

                            End If

                        Else

                            _GridViewServiceFeeDetailsLevel1Tab1.Columns.Remove(GridColumn)
                            'GridColumn.Visible = False
                            'GridColumn.OptionsColumn.AllowShowHide = False
                            'GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            'GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                End If

            Else

                If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    For Each GridColumn In _GridViewServiceFeeDetailsLevel1Tab1.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeDate.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.Description.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.TotalHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.TotalAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeTimeType.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.Reconcile.ToString Then

                            GridColumn.AppearanceCell.Font = New System.Drawing.Font("Arial", 8)
                            GridColumn.AppearanceHeader.Font = New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold)

                            GridColumn.Visible = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.TotalHours.ToString Then

                                GridColumn.Caption = "Total Hrs\Qty"

                            End If

                        Else

                            _GridViewServiceFeeDetailsLevel1Tab1.Columns.Remove(GridColumn)
                            'GridColumn.Visible = False
                            'GridColumn.OptionsColumn.AllowShowHide = False
                            'GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            'GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                ElseIf _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Employee Then

                    For Each GridColumn In _GridViewServiceFeeDetailsLevel1Tab1.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.Description.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.TotalHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.TotalAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.Reconcile.ToString Then

                            GridColumn.AppearanceCell.Font = New System.Drawing.Font("Arial", 8)
                            GridColumn.AppearanceHeader.Font = New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold)

                            GridColumn.Visible = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.TotalHours.ToString Then

                                GridColumn.Caption = "Total Hrs\Qty"

                            End If

                        Else

                            _GridViewServiceFeeDetailsLevel1Tab1.Columns.Remove(GridColumn)
                            'GridColumn.Visible = False
                            'GridColumn.OptionsColumn.AllowShowHide = False
                            'GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            'GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                End If

            End If

            If _ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    For Each GridColumn In _GridViewServiceFeeDetailsLevel1Tab2.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeQuantity.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeTimeType.ToString Then

                            GridColumn.AppearanceCell.Font = New System.Drawing.Font("Arial", 8)
                            GridColumn.AppearanceHeader.Font = New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold)

                            GridColumn.Visible = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeQuantity.ToString Then

                                GridColumn.Caption = "Fee Hrs\Qty"

                            End If

                        Else

                            _GridViewServiceFeeDetailsLevel1Tab2.Columns.Remove(GridColumn)
                            'GridColumn.Visible = False
                            'GridColumn.OptionsColumn.AllowShowHide = False
                            'GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            'GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                ElseIf _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Employee Then

                    For Each GridColumn In _GridViewServiceFeeDetailsLevel1Tab2.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeDate.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeQuantity.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeAmount.ToString Then

                            GridColumn.AppearanceCell.Font = New System.Drawing.Font("Arial", 8)
                            GridColumn.AppearanceHeader.Font = New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold)

                            GridColumn.Visible = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeQuantity.ToString Then

                                GridColumn.Caption = "Fee Hrs\Qty"

                            End If

                        Else

                            _GridViewServiceFeeDetailsLevel1Tab2.Columns.Remove(GridColumn)
                            'GridColumn.Visible = False
                            'GridColumn.OptionsColumn.AllowShowHide = False
                            'GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            'GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                End If

            Else

                If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    For Each GridColumn In _GridViewServiceFeeDetailsLevel1Tab2.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeDate.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.Description.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeQuantity.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeTimeType.ToString Then

                            GridColumn.AppearanceCell.Font = New System.Drawing.Font("Arial", 8)
                            GridColumn.AppearanceHeader.Font = New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold)

                            GridColumn.Visible = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeQuantity.ToString Then

                                GridColumn.Caption = "Fee Hrs\Qty"

                            End If

                        Else

                            _GridViewServiceFeeDetailsLevel1Tab2.Columns.Remove(GridColumn)
                            'GridColumn.Visible = False
                            'GridColumn.OptionsColumn.AllowShowHide = False
                            'GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            'GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                ElseIf _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Employee Then

                    For Each GridColumn In _GridViewServiceFeeDetailsLevel1Tab2.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.Description.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeQuantity.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeAmount.ToString Then

                            GridColumn.AppearanceCell.Font = New System.Drawing.Font("Arial", 8)
                            GridColumn.AppearanceHeader.Font = New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold)

                            GridColumn.Visible = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.FeeQuantity.ToString Then

                                GridColumn.Caption = "Fee Hrs\Qty"

                            End If

                        Else

                            _GridViewServiceFeeDetailsLevel1Tab2.Columns.Remove(GridColumn)
                            'GridColumn.Visible = False
                            'GridColumn.OptionsColumn.AllowShowHide = False
                            'GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            'GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                End If

            End If

            If _GridViewServiceFeeDetailsLevel1Tab1.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString) IsNot Nothing Then

                If _GridViewServiceFeeDetailsLevel1Tab1.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                    _GridViewServiceFeeDetailsLevel1Tab1.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    _GridViewServiceFeeDetailsLevel1Tab1.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString).DisplayFormat.FormatString = "n2"
                    _GridViewServiceFeeDetailsLevel1Tab1.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                End If

            End If

            If _GridViewServiceFeeDetailsLevel1Tab1.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString) IsNot Nothing Then

                If _GridViewServiceFeeDetailsLevel1Tab1.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                    _GridViewServiceFeeDetailsLevel1Tab1.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    _GridViewServiceFeeDetailsLevel1Tab1.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString).DisplayFormat.FormatString = "n2"
                    _GridViewServiceFeeDetailsLevel1Tab1.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                End If

            End If

            If _GridViewServiceFeeDetailsLevel1Tab2.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString) IsNot Nothing Then

                If _GridViewServiceFeeDetailsLevel1Tab2.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                    _GridViewServiceFeeDetailsLevel1Tab2.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    _GridViewServiceFeeDetailsLevel1Tab2.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString).DisplayFormat.FormatString = "n2"
                    _GridViewServiceFeeDetailsLevel1Tab2.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                End If

            End If

            If _GridViewServiceFeeDetailsLevel1Tab2.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString) IsNot Nothing Then

                If _GridViewServiceFeeDetailsLevel1Tab2.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                    _GridViewServiceFeeDetailsLevel1Tab2.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    _GridViewServiceFeeDetailsLevel1Tab2.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString).DisplayFormat.FormatString = "n2"
                    _GridViewServiceFeeDetailsLevel1Tab2.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                End If

            End If

            DataGridViewForm_ServiceFees.CurrentView.EndUpdate()

        End Sub
        Private Function LoadDetails(ByVal ServiceReconcileDetails As Generic.List(Of IEnumerable(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile))) As IEnumerable

            'objects
            Dim ServiceFeeDetails As IEnumerable = Nothing

            ServiceFeeDetails = (From ServiceFeeReconcileDetail In ServiceReconcileDetails
                                 Select New With {.[EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode),
                                                  .[JobServiceFeeTypeCode] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.JobServiceFeeTypeCode),
                                                  .[EmployeeDepartmentTeamServiceFeeTypeCode] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.EmployeeDepartmentTeamServiceFeeTypeCode),
                                                  .[ClientCode] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.ClientCode),
                                                  .[ClientDescription] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.ClientDescription),
                                                  .[DivisionCode] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.DivisionCode),
                                                  .[DivisionDescription] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.DivisionDescription),
                                                  .[ProductCode] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.ProductCode),
                                                  .[ProductDescription] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.ProductDescription),
                                                  .[CampaignCode] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.CampaignCode),
                                                  .[CampaignName] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.CampaignName),
                                                  .[JobNumber] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.JobNumber),
                                                  .[JobDescription] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.JobDescription),
                                                  .[ComponentNumber] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.ComponentNumber),
                                                  .[ComponentDescription] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.ComponentDescription),
                                                  .[JobComponent] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.JobComponent),
                                                  .[SalesClassCode] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.SalesClassCode),
                                                  .[SalesClassDescription] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.SalesClassDescription),
                                                  .[FunctionCode] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.FunctionCode),
                                                  .[FunctionDescription] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.FunctionDescription),
                                                  .[FeeDate] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.FeeDate),
                                                  .[Description] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.Description),
                                                  .[IsServiceFeeJob] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.IsServiceFeeJob),
                                                  .[FunctionConsolidation] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.FunctionConsolidation),
                                                  .[FunctionHeading] = ServiceFeeReconcileDetail.Max(Function(EntityView) EntityView.FunctionHeading),
                                                  .[FeeQuantity] = ServiceFeeReconcileDetail.Sum(Function(EntityView) EntityView.FeeQuantity),
                                                  .[FeeAmount] = ServiceFeeReconcileDetail.Sum(Function(EntityView) EntityView.FeeAmount),
                                                  .[ReconciledHours] = ServiceFeeReconcileDetail.Sum(Function(EntityView) EntityView.ReconciledHours),
                                                  .[ReconciledAmount] = ServiceFeeReconcileDetail.Sum(Function(EntityView) EntityView.ReconciledAmount),
                                                  .[UnreconciledHours] = ServiceFeeReconcileDetail.Sum(Function(EntityView) EntityView.UnreconciledHours),
                                                  .[UnreconciledAmount] = ServiceFeeReconcileDetail.Sum(Function(EntityView) EntityView.UnreconciledAmount),
                                                  .[TotalHours] = ServiceFeeReconcileDetail.Sum(Function(EntityView) EntityView.TotalHours),
                                                  .[TotalAmount] = ServiceFeeReconcileDetail.Sum(Function(EntityView) EntityView.TotalAmount)}).ToList

            LoadDetails = ServiceFeeDetails

        End Function
        Private Function LoadDetailsGroupByJob(ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting,
                                               ByVal ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles,
                                               ByVal ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) As IEnumerable

            'objects
            Dim ServiceReconcileDetails As Generic.List(Of IEnumerable(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) = Nothing

            If ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                If ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.FeeDate,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                End If

            Else

                If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                    If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                               Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                  ServiceFeeReconcileDetail.ClientCode,
                                                                                  ServiceFeeReconcileDetail.ClientDescription,
                                                                                  ServiceFeeReconcileDetail.DivisionCode,
                                                                                  ServiceFeeReconcileDetail.DivisionDescription,
                                                                                  ServiceFeeReconcileDetail.ProductCode,
                                                                                  ServiceFeeReconcileDetail.ProductDescription,
                                                                                  ServiceFeeReconcileDetail.CampaignCode,
                                                                                  ServiceFeeReconcileDetail.CampaignName,
                                                                                  ServiceFeeReconcileDetail.SalesClassCode,
                                                                                  ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                  ServiceFeeReconcileDetail.JobDescription Into ServiceFeeReconcile = Group
                                               Select ServiceFeeReconcile).ToList

                End If

            End If

            LoadDetailsGroupByJob = LoadDetails(ServiceReconcileDetails)

        End Function
        Private Function LoadDetailsGroupByJobComponent(ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting,
                                                        ByVal ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles,
                                                        ByVal ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) As IEnumerable

            'objects
            Dim ServiceReconcileDetails As Generic.List(Of IEnumerable(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) = Nothing

            If ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                If ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                      ServiceFeeReconcileDetail.FeeDate,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                End If

            Else

                If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                    If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                               Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                  ServiceFeeReconcileDetail.ClientCode,
                                                                                  ServiceFeeReconcileDetail.ClientDescription,
                                                                                  ServiceFeeReconcileDetail.DivisionCode,
                                                                                  ServiceFeeReconcileDetail.DivisionDescription,
                                                                                  ServiceFeeReconcileDetail.ProductCode,
                                                                                  ServiceFeeReconcileDetail.ProductDescription,
                                                                                  ServiceFeeReconcileDetail.CampaignCode,
                                                                                  ServiceFeeReconcileDetail.CampaignName,
                                                                                  ServiceFeeReconcileDetail.SalesClassCode,
                                                                                  ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                  ServiceFeeReconcileDetail.JobDescription,
                                                                                  ServiceFeeReconcileDetail.ComponentNumber,
                                                                                  ServiceFeeReconcileDetail.JobComponent,
                                                                                  ServiceFeeReconcileDetail.ComponentDescription,
                                                                                  ServiceFeeReconcileDetail.IsServiceFeeJob Into ServiceFeeReconcile = Group
                                               Select ServiceFeeReconcile).ToList

                End If

            End If

            LoadDetailsGroupByJobComponent = LoadDetails(ServiceReconcileDetails)

        End Function
        Private Function LoadDetailsGroupByJobComponentFunction(ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting,
                                                                ByVal ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles,
                                                                ByVal ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) As IEnumerable

            'objects
            Dim ServiceReconcileDetails As Generic.List(Of IEnumerable(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) = Nothing

            If ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                If ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionCode,
                                                                                          ServiceFeeReconcileDetail.FunctionDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionCode,
                                                                                          ServiceFeeReconcileDetail.FunctionDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionCode,
                                                                                          ServiceFeeReconcileDetail.FunctionDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionCode,
                                                                                      ServiceFeeReconcileDetail.FunctionDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading,
                                                                                      ServiceFeeReconcileDetail.FeeDate,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionCode,
                                                                                          ServiceFeeReconcileDetail.FunctionDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionCode,
                                                                                          ServiceFeeReconcileDetail.FunctionDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionCode,
                                                                                          ServiceFeeReconcileDetail.FunctionDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionCode,
                                                                                      ServiceFeeReconcileDetail.FunctionDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                End If

            Else

                If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                    If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionCode,
                                                                                      ServiceFeeReconcileDetail.FunctionDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionCode,
                                                                                      ServiceFeeReconcileDetail.FunctionDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionCode,
                                                                                      ServiceFeeReconcileDetail.FunctionDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                               Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                  ServiceFeeReconcileDetail.ClientCode,
                                                                                  ServiceFeeReconcileDetail.ClientDescription,
                                                                                  ServiceFeeReconcileDetail.DivisionCode,
                                                                                  ServiceFeeReconcileDetail.DivisionDescription,
                                                                                  ServiceFeeReconcileDetail.ProductCode,
                                                                                  ServiceFeeReconcileDetail.ProductDescription,
                                                                                  ServiceFeeReconcileDetail.CampaignCode,
                                                                                  ServiceFeeReconcileDetail.CampaignName,
                                                                                  ServiceFeeReconcileDetail.SalesClassCode,
                                                                                  ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                  ServiceFeeReconcileDetail.JobDescription,
                                                                                  ServiceFeeReconcileDetail.ComponentNumber,
                                                                                  ServiceFeeReconcileDetail.JobComponent,
                                                                                  ServiceFeeReconcileDetail.ComponentDescription,
                                                                                  ServiceFeeReconcileDetail.FunctionCode,
                                                                                  ServiceFeeReconcileDetail.FunctionDescription,
                                                                                  ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                  ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                  ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                               Select ServiceFeeReconcile).ToList

                End If

            End If

            LoadDetailsGroupByJobComponentFunction = LoadDetails(ServiceReconcileDetails)

        End Function
        Private Function LoadDetailsGroupByJobFunction(ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting,
                                                       ByVal ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles,
                                                       ByVal ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) As IEnumerable

            'objects
            Dim ServiceReconcileDetails As Generic.List(Of IEnumerable(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) = Nothing

            If ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                If ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionCode,
                                                                                          ServiceFeeReconcileDetail.FunctionDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionCode,
                                                                                          ServiceFeeReconcileDetail.FunctionDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionCode,
                                                                                          ServiceFeeReconcileDetail.FunctionDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionCode,
                                                                                      ServiceFeeReconcileDetail.FunctionDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading,
                                                                                      ServiceFeeReconcileDetail.FeeDate,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionCode,
                                                                                          ServiceFeeReconcileDetail.FunctionDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionCode,
                                                                                          ServiceFeeReconcileDetail.FunctionDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionCode,
                                                                                          ServiceFeeReconcileDetail.FunctionDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionCode,
                                                                                      ServiceFeeReconcileDetail.FunctionDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                End If

            Else

                If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                    If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionCode,
                                                                                      ServiceFeeReconcileDetail.FunctionDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionCode,
                                                                                      ServiceFeeReconcileDetail.FunctionDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionCode,
                                                                                      ServiceFeeReconcileDetail.FunctionDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                               Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                  ServiceFeeReconcileDetail.ClientCode,
                                                                                  ServiceFeeReconcileDetail.ClientDescription,
                                                                                  ServiceFeeReconcileDetail.DivisionCode,
                                                                                  ServiceFeeReconcileDetail.DivisionDescription,
                                                                                  ServiceFeeReconcileDetail.ProductCode,
                                                                                  ServiceFeeReconcileDetail.ProductDescription,
                                                                                  ServiceFeeReconcileDetail.CampaignCode,
                                                                                  ServiceFeeReconcileDetail.CampaignName,
                                                                                  ServiceFeeReconcileDetail.SalesClassCode,
                                                                                  ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                  ServiceFeeReconcileDetail.JobDescription,
                                                                                  ServiceFeeReconcileDetail.FunctionCode,
                                                                                  ServiceFeeReconcileDetail.FunctionDescription,
                                                                                  ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                  ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                               Select ServiceFeeReconcile).ToList

                End If

            End If

            LoadDetailsGroupByJobFunction = LoadDetails(ServiceReconcileDetails)

        End Function
        Private Function LoadDetailsGroupByCampaign(ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting,
                                                    ByVal ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles,
                                                    ByVal ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) As IEnumerable

            'objects
            Dim ServiceReconcileDetails As Generic.List(Of IEnumerable(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) = Nothing

            If ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                If ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.FeeDate,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                End If

            Else

                If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                    If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                               Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.CampaignCode,
                                                                                  ServiceFeeReconcileDetail.CampaignName Into ServiceFeeReconcile = Group
                                               Select ServiceFeeReconcile).ToList

                End If

            End If

            LoadDetailsGroupByCampaign = LoadDetails(ServiceReconcileDetails)

        End Function
        Private Function LoadDetailsGroupByFunction(ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting,
                                                    ByVal ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles,
                                                    ByVal ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) As IEnumerable

            'objects
            Dim ServiceReconcileDetails As Generic.List(Of IEnumerable(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) = Nothing

            If ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                If ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Order By ServiceFeeReconcileDetail.FunctionType Descending, ServiceFeeReconcileDetail.FunctionOrderNumber, ServiceFeeReconcileDetail.FunctionDescription
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.FunctionCode,
                                                                                          ServiceFeeReconcileDetail.FunctionDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Order By ServiceFeeReconcileDetail.FunctionType Descending, ServiceFeeReconcileDetail.FunctionOrderNumber, ServiceFeeReconcileDetail.FunctionDescription
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.FunctionCode,
                                                                                          ServiceFeeReconcileDetail.FunctionDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Order By ServiceFeeReconcileDetail.FunctionType Descending, ServiceFeeReconcileDetail.FunctionOrderNumber, ServiceFeeReconcileDetail.FunctionDescription
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.FunctionCode,
                                                                                          ServiceFeeReconcileDetail.FunctionDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Order By ServiceFeeReconcileDetail.FunctionType Descending, ServiceFeeReconcileDetail.FunctionOrderNumber, ServiceFeeReconcileDetail.FunctionDescription
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.FunctionCode,
                                                                                      ServiceFeeReconcileDetail.FunctionDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading,
                                                                                      ServiceFeeReconcileDetail.FeeDate,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Order By ServiceFeeReconcileDetail.FunctionType Descending, ServiceFeeReconcileDetail.FunctionOrderNumber, ServiceFeeReconcileDetail.FunctionDescription
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.FunctionCode,
                                                                                          ServiceFeeReconcileDetail.FunctionDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Order By ServiceFeeReconcileDetail.FunctionType Descending, ServiceFeeReconcileDetail.FunctionOrderNumber, ServiceFeeReconcileDetail.FunctionDescription
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.FunctionCode,
                                                                                          ServiceFeeReconcileDetail.FunctionDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Order By ServiceFeeReconcileDetail.FunctionType Descending, ServiceFeeReconcileDetail.FunctionOrderNumber, ServiceFeeReconcileDetail.FunctionDescription
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.FunctionCode,
                                                                                          ServiceFeeReconcileDetail.FunctionDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Order By ServiceFeeReconcileDetail.FunctionType Descending, ServiceFeeReconcileDetail.FunctionOrderNumber, ServiceFeeReconcileDetail.FunctionDescription
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.FunctionCode,
                                                                                      ServiceFeeReconcileDetail.FunctionDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                End If

            Else

                If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                    If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Order By ServiceFeeReconcileDetail.FunctionType Descending, ServiceFeeReconcileDetail.FunctionOrderNumber, ServiceFeeReconcileDetail.FunctionDescription
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.FunctionCode,
                                                                                      ServiceFeeReconcileDetail.FunctionDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Order By ServiceFeeReconcileDetail.FunctionType Descending, ServiceFeeReconcileDetail.FunctionOrderNumber, ServiceFeeReconcileDetail.FunctionDescription
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.FunctionCode,
                                                                                      ServiceFeeReconcileDetail.FunctionDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Order By ServiceFeeReconcileDetail.FunctionType Descending, ServiceFeeReconcileDetail.FunctionOrderNumber, ServiceFeeReconcileDetail.FunctionDescription
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.FunctionCode,
                                                                                      ServiceFeeReconcileDetail.FunctionDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                               Order By ServiceFeeReconcileDetail.FunctionType Descending, ServiceFeeReconcileDetail.FunctionOrderNumber, ServiceFeeReconcileDetail.FunctionDescription
                                               Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.FunctionCode,
                                                                                  ServiceFeeReconcileDetail.FunctionDescription,
                                                                                  ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                  ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                               Select ServiceFeeReconcile).ToList

                End If

            End If

            LoadDetailsGroupByFunction = LoadDetails(ServiceReconcileDetails)

        End Function
        Private Function LoadDetailsGroupByJobFunctionConsolidation(ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting,
                                                                    ByVal ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles,
                                                                    ByVal ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) As IEnumerable

            'objects
            Dim ServiceReconcileDetails As Generic.List(Of IEnumerable(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) = Nothing

            If ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                If ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.FeeDate,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                End If

            Else

                If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                    If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                               Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                  ServiceFeeReconcileDetail.ClientCode,
                                                                                  ServiceFeeReconcileDetail.ClientDescription,
                                                                                  ServiceFeeReconcileDetail.DivisionCode,
                                                                                  ServiceFeeReconcileDetail.DivisionDescription,
                                                                                  ServiceFeeReconcileDetail.ProductCode,
                                                                                  ServiceFeeReconcileDetail.ProductDescription,
                                                                                  ServiceFeeReconcileDetail.CampaignCode,
                                                                                  ServiceFeeReconcileDetail.CampaignName,
                                                                                  ServiceFeeReconcileDetail.SalesClassCode,
                                                                                  ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                  ServiceFeeReconcileDetail.JobDescription,
                                                                                  ServiceFeeReconcileDetail.FunctionConsolidation Into ServiceFeeReconcile = Group
                                               Select ServiceFeeReconcile).ToList

                End If

            End If

            LoadDetailsGroupByJobFunctionConsolidation = LoadDetails(ServiceReconcileDetails)

        End Function
        Private Function LoadDetailsGroupByJobComponentFunctionConsolidation(ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting,
                                                                             ByVal ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles,
                                                                             ByVal ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) As IEnumerable

            'objects
            Dim ServiceReconcileDetails As Generic.List(Of IEnumerable(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) = Nothing

            If ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                If ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.FeeDate,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                End If

            Else

                If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                    If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                               Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                  ServiceFeeReconcileDetail.ClientCode,
                                                                                  ServiceFeeReconcileDetail.ClientDescription,
                                                                                  ServiceFeeReconcileDetail.DivisionCode,
                                                                                  ServiceFeeReconcileDetail.DivisionDescription,
                                                                                  ServiceFeeReconcileDetail.ProductCode,
                                                                                  ServiceFeeReconcileDetail.ProductDescription,
                                                                                  ServiceFeeReconcileDetail.CampaignCode,
                                                                                  ServiceFeeReconcileDetail.CampaignName,
                                                                                  ServiceFeeReconcileDetail.SalesClassCode,
                                                                                  ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                  ServiceFeeReconcileDetail.JobDescription,
                                                                                  ServiceFeeReconcileDetail.ComponentNumber,
                                                                                  ServiceFeeReconcileDetail.JobComponent,
                                                                                  ServiceFeeReconcileDetail.ComponentDescription,
                                                                                  ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                  ServiceFeeReconcileDetail.FunctionConsolidation Into ServiceFeeReconcile = Group
                                               Select ServiceFeeReconcile).ToList

                End If

            End If

            LoadDetailsGroupByJobComponentFunctionConsolidation = LoadDetails(ServiceReconcileDetails)

        End Function
        Private Function LoadDetailsGroupByFunctionConsolidation(ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting,
                                                                 ByVal ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles,
                                                                 ByVal ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) As IEnumerable

            'objects
            Dim ServiceReconcileDetails As Generic.List(Of IEnumerable(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) = Nothing

            If ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                If ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Order By ServiceFeeReconcileDetail.FunctionConsolidationType Descending, ServiceFeeReconcileDetail.FunctionConsolidationOrderNumber, ServiceFeeReconcileDetail.FunctionConsolidation
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Order By ServiceFeeReconcileDetail.FunctionConsolidationType Descending, ServiceFeeReconcileDetail.FunctionConsolidationOrderNumber, ServiceFeeReconcileDetail.FunctionConsolidation
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Order By ServiceFeeReconcileDetail.FunctionConsolidationType Descending, ServiceFeeReconcileDetail.FunctionConsolidationOrderNumber, ServiceFeeReconcileDetail.FunctionConsolidation
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Order By ServiceFeeReconcileDetail.FunctionConsolidationType Descending, ServiceFeeReconcileDetail.FunctionConsolidationOrderNumber, ServiceFeeReconcileDetail.FunctionConsolidation
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.FeeDate,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Order By ServiceFeeReconcileDetail.FunctionConsolidationType Descending, ServiceFeeReconcileDetail.FunctionConsolidationOrderNumber, ServiceFeeReconcileDetail.FunctionConsolidation
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Order By ServiceFeeReconcileDetail.FunctionConsolidationType Descending, ServiceFeeReconcileDetail.FunctionConsolidationOrderNumber, ServiceFeeReconcileDetail.FunctionConsolidation
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Order By ServiceFeeReconcileDetail.FunctionConsolidationType Descending, ServiceFeeReconcileDetail.FunctionConsolidationOrderNumber, ServiceFeeReconcileDetail.FunctionConsolidation
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Order By ServiceFeeReconcileDetail.FunctionConsolidationType Descending, ServiceFeeReconcileDetail.FunctionConsolidationOrderNumber, ServiceFeeReconcileDetail.FunctionConsolidation
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.FunctionConsolidation,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                End If

            Else

                If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                    If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Order By ServiceFeeReconcileDetail.FunctionConsolidationType Descending, ServiceFeeReconcileDetail.FunctionConsolidationOrderNumber, ServiceFeeReconcileDetail.FunctionConsolidation
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Order By ServiceFeeReconcileDetail.FunctionConsolidationType Descending, ServiceFeeReconcileDetail.FunctionConsolidationOrderNumber, ServiceFeeReconcileDetail.FunctionConsolidation
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Order By ServiceFeeReconcileDetail.FunctionConsolidationType Descending, ServiceFeeReconcileDetail.FunctionConsolidationOrderNumber, ServiceFeeReconcileDetail.FunctionConsolidation
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.FunctionConsolidation Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                               Order By ServiceFeeReconcileDetail.FunctionConsolidationType Descending, ServiceFeeReconcileDetail.FunctionConsolidationOrderNumber, ServiceFeeReconcileDetail.FunctionConsolidation
                                               Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.FunctionConsolidation Into ServiceFeeReconcile = Group
                                               Select ServiceFeeReconcile).ToList

                End If

            End If

            LoadDetailsGroupByFunctionConsolidation = LoadDetails(ServiceReconcileDetails)

        End Function
        Private Function LoadDetailsGroupByJobFunctionHeading(ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting,
                                                            ByVal ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles,
                                                            ByVal ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) As IEnumerable

            'objects
            Dim ServiceReconcileDetails As Generic.List(Of IEnumerable(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) = Nothing

            If ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                If ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading,
                                                                                      ServiceFeeReconcileDetail.FeeDate,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                End If

            Else

                If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                    If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                               Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                  ServiceFeeReconcileDetail.ClientCode,
                                                                                  ServiceFeeReconcileDetail.ClientDescription,
                                                                                  ServiceFeeReconcileDetail.DivisionCode,
                                                                                  ServiceFeeReconcileDetail.DivisionDescription,
                                                                                  ServiceFeeReconcileDetail.ProductCode,
                                                                                  ServiceFeeReconcileDetail.ProductDescription,
                                                                                  ServiceFeeReconcileDetail.CampaignCode,
                                                                                  ServiceFeeReconcileDetail.CampaignName,
                                                                                  ServiceFeeReconcileDetail.SalesClassCode,
                                                                                  ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                  ServiceFeeReconcileDetail.JobDescription,
                                                                                  ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                               Select ServiceFeeReconcile).ToList

                End If

            End If

            LoadDetailsGroupByJobFunctionHeading = LoadDetails(ServiceReconcileDetails)

        End Function
        Private Function LoadDetailsGroupByJobComponentFunctionHeading(ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting,
                                                                             ByVal ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles,
                                                                             ByVal ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) As IEnumerable

            'objects
            Dim ServiceReconcileDetails As Generic.List(Of IEnumerable(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) = Nothing

            If ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                If ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading,
                                                                                      ServiceFeeReconcileDetail.FeeDate,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.JobNumber,
                                                                                          ServiceFeeReconcileDetail.ClientCode,
                                                                                          ServiceFeeReconcileDetail.ClientDescription,
                                                                                          ServiceFeeReconcileDetail.DivisionCode,
                                                                                          ServiceFeeReconcileDetail.DivisionDescription,
                                                                                          ServiceFeeReconcileDetail.ProductCode,
                                                                                          ServiceFeeReconcileDetail.ProductDescription,
                                                                                          ServiceFeeReconcileDetail.CampaignCode,
                                                                                          ServiceFeeReconcileDetail.CampaignName,
                                                                                          ServiceFeeReconcileDetail.SalesClassCode,
                                                                                          ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                          ServiceFeeReconcileDetail.JobDescription,
                                                                                          ServiceFeeReconcileDetail.ComponentNumber,
                                                                                          ServiceFeeReconcileDetail.JobComponent,
                                                                                          ServiceFeeReconcileDetail.ComponentDescription,
                                                                                          ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                End If

            Else

                If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                    If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.JobNumber,
                                                                                      ServiceFeeReconcileDetail.ClientCode,
                                                                                      ServiceFeeReconcileDetail.ClientDescription,
                                                                                      ServiceFeeReconcileDetail.DivisionCode,
                                                                                      ServiceFeeReconcileDetail.DivisionDescription,
                                                                                      ServiceFeeReconcileDetail.ProductCode,
                                                                                      ServiceFeeReconcileDetail.ProductDescription,
                                                                                      ServiceFeeReconcileDetail.CampaignCode,
                                                                                      ServiceFeeReconcileDetail.CampaignName,
                                                                                      ServiceFeeReconcileDetail.SalesClassCode,
                                                                                      ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                      ServiceFeeReconcileDetail.JobDescription,
                                                                                      ServiceFeeReconcileDetail.ComponentNumber,
                                                                                      ServiceFeeReconcileDetail.JobComponent,
                                                                                      ServiceFeeReconcileDetail.ComponentDescription,
                                                                                      ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                               Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobNumber,
                                                                                  ServiceFeeReconcileDetail.ClientCode,
                                                                                  ServiceFeeReconcileDetail.ClientDescription,
                                                                                  ServiceFeeReconcileDetail.DivisionCode,
                                                                                  ServiceFeeReconcileDetail.DivisionDescription,
                                                                                  ServiceFeeReconcileDetail.ProductCode,
                                                                                  ServiceFeeReconcileDetail.ProductDescription,
                                                                                  ServiceFeeReconcileDetail.CampaignCode,
                                                                                  ServiceFeeReconcileDetail.CampaignName,
                                                                                  ServiceFeeReconcileDetail.SalesClassCode,
                                                                                  ServiceFeeReconcileDetail.SalesClassDescription,
                                                                                  ServiceFeeReconcileDetail.JobDescription,
                                                                                  ServiceFeeReconcileDetail.ComponentNumber,
                                                                                  ServiceFeeReconcileDetail.JobComponent,
                                                                                  ServiceFeeReconcileDetail.ComponentDescription,
                                                                                  ServiceFeeReconcileDetail.IsServiceFeeJob,
                                                                                  ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                               Select ServiceFeeReconcile).ToList

                End If

            End If

            LoadDetailsGroupByJobComponentFunctionHeading = LoadDetails(ServiceReconcileDetails)

        End Function
        Private Function LoadDetailsGroupByFunctionHeading(ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting,
                                                                 ByVal ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles,
                                                                 ByVal ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) As IEnumerable

            'objects
            Dim ServiceReconcileDetails As Generic.List(Of IEnumerable(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) = Nothing

            If ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                If ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Order By ServiceFeeReconcileDetail.FunctionHeadingOrderNumber, ServiceFeeReconcileDetail.FunctionHeading
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Order By ServiceFeeReconcileDetail.FunctionHeadingOrderNumber, ServiceFeeReconcileDetail.FunctionHeading
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Order By ServiceFeeReconcileDetail.FunctionHeadingOrderNumber, ServiceFeeReconcileDetail.FunctionHeading
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.FeeDate,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Order By ServiceFeeReconcileDetail.FunctionHeadingOrderNumber, ServiceFeeReconcileDetail.FunctionHeading
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.FunctionHeading,
                                                                                      ServiceFeeReconcileDetail.FeeDate,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                        If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Order By ServiceFeeReconcileDetail.FunctionHeadingOrderNumber, ServiceFeeReconcileDetail.FunctionHeading
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Order By ServiceFeeReconcileDetail.FunctionHeadingOrderNumber, ServiceFeeReconcileDetail.FunctionHeading
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                            ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                       Order By ServiceFeeReconcileDetail.FunctionHeadingOrderNumber, ServiceFeeReconcileDetail.FunctionHeading
                                                       Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                          ServiceFeeReconcileDetail.FunctionHeading,
                                                                                          ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                       Select ServiceFeeReconcile).ToList

                        End If

                    Else

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Order By ServiceFeeReconcileDetail.FunctionHeadingOrderNumber, ServiceFeeReconcileDetail.FunctionHeading
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.FunctionHeading,
                                                                                      ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                End If

            Else

                If ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel Then

                    If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Order By ServiceFeeReconcileDetail.FunctionHeadingOrderNumber, ServiceFeeReconcileDetail.FunctionHeading
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Order By ServiceFeeReconcileDetail.FunctionHeadingOrderNumber, ServiceFeeReconcileDetail.FunctionHeading
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                        ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                                   Order By ServiceFeeReconcileDetail.FunctionHeadingOrderNumber, ServiceFeeReconcileDetail.FunctionHeading
                                                   Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.JobServiceFeeTypeCode,
                                                                                      ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                                   Select ServiceFeeReconcile).ToList

                    End If

                Else

                    ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                               Order By ServiceFeeReconcileDetail.FunctionHeadingOrderNumber, ServiceFeeReconcileDetail.FunctionHeading
                                               Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.FunctionHeading Into ServiceFeeReconcile = Group
                                               Select ServiceFeeReconcile).ToList

                End If

            End If

            LoadDetailsGroupByFunctionHeading = LoadDetails(ServiceReconcileDetails)

        End Function
        Private Function LoadGroupByLevelData(ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting,
                                                      ByVal ServiceFeeReconciliationGroupByOption As AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions,
                                                      ByVal ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles,
                                                      ByVal ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)) As IEnumerable

            'objects
            Dim ServiceReconcileDetails As IEnumerable = Nothing

            If ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job Then

                ServiceReconcileDetails = LoadDetailsGroupByJob(ServiceFeeReconciliationSetting, ServiceFeeReconciliationSummaryStyle, ServiceFeeReconcileDetailList)

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component Then

                ServiceReconcileDetails = LoadDetailsGroupByJobComponent(ServiceFeeReconciliationSetting, ServiceFeeReconciliationSummaryStyle, ServiceFeeReconcileDetailList)

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_Function Then

                ServiceReconcileDetails = LoadDetailsGroupByJobComponentFunction(ServiceFeeReconciliationSetting, ServiceFeeReconciliationSummaryStyle, ServiceFeeReconcileDetailList)

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Function Then

                ServiceReconcileDetails = LoadDetailsGroupByJobFunction(ServiceFeeReconciliationSetting, ServiceFeeReconciliationSummaryStyle, ServiceFeeReconcileDetailList)

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Campaign Then

                ServiceReconcileDetails = LoadDetailsGroupByCampaign(ServiceFeeReconciliationSetting, ServiceFeeReconciliationSummaryStyle, ServiceFeeReconcileDetailList)

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Function Then

                ServiceReconcileDetails = LoadDetailsGroupByFunction(ServiceFeeReconciliationSetting, ServiceFeeReconciliationSummaryStyle, ServiceFeeReconcileDetailList)

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_FunctionConsolidation Then

                ServiceReconcileDetails = LoadDetailsGroupByJobFunctionConsolidation(ServiceFeeReconciliationSetting, ServiceFeeReconciliationSummaryStyle, ServiceFeeReconcileDetailList)

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_FunctionConsolidation Then

                ServiceReconcileDetails = LoadDetailsGroupByJobComponentFunctionConsolidation(ServiceFeeReconciliationSetting, ServiceFeeReconciliationSummaryStyle, ServiceFeeReconcileDetailList)

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.FunctionConsolidation Then

                ServiceReconcileDetails = LoadDetailsGroupByFunctionConsolidation(ServiceFeeReconciliationSetting, ServiceFeeReconciliationSummaryStyle, ServiceFeeReconcileDetailList)

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_FunctionHeading Then

                ServiceReconcileDetails = LoadDetailsGroupByJobFunctionHeading(ServiceFeeReconciliationSetting, ServiceFeeReconciliationSummaryStyle, ServiceFeeReconcileDetailList)

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_FunctionHeading Then

                ServiceReconcileDetails = LoadDetailsGroupByJobComponentFunctionHeading(ServiceFeeReconciliationSetting, ServiceFeeReconciliationSummaryStyle, ServiceFeeReconcileDetailList)

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.FunctionHeading Then

                ServiceReconcileDetails = LoadDetailsGroupByFunctionHeading(ServiceFeeReconciliationSetting, ServiceFeeReconciliationSummaryStyle, ServiceFeeReconcileDetailList)

            End If

            LoadGroupByLevelData = ServiceReconcileDetails

        End Function
        Private Function LoadServiceFeesByRow(ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting,
                                              ByVal ServiceFeeReconciliationGroupByOption As AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions,
                                              ByVal ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles,
                                              ByVal ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile),
                                              ByVal IsMaxIndex As Boolean,
                                              ByVal Client As AdvantageFramework.Database.Entities.Client,
                                              ByVal Division As AdvantageFramework.Database.Entities.Division,
                                              ByVal Product As AdvantageFramework.Database.Entities.Product,
                                              ByVal RowHandle As Integer,
                                              ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView) As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)

            'objects
            Dim JobComponent As String = ""
            Dim FunctionCode As String = ""
            Dim JobNumber As Integer = 0
            Dim CampaignCode As String = ""
            Dim SalesClassCode As String = ""
            Dim FunctionConsolidation As String = ""
            Dim FunctionHeading As String = ""
            Dim FeeDescription As String = ""
            Dim FeeDate As Date = Nothing
            Dim SFRDetailFilteredList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile) = Nothing

            If ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job Then

                Try

                    JobNumber = GridView.GetRowCellValue(RowHandle, "JobNumber")

                Catch ex As Exception
                    JobNumber = 0
                End Try

                If JobNumber = 0 Then

                    Try

                        SalesClassCode = GridView.GetRowCellValue(RowHandle, "SalesClassCode")

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component Then

                Try

                    JobComponent = GridView.GetRowCellValue(RowHandle, "JobComponent")

                Catch ex As Exception
                    JobComponent = ""
                End Try

                If JobComponent Is Nothing OrElse JobComponent = "" Then

                    Try

                        SalesClassCode = GridView.GetRowCellValue(RowHandle, "SalesClassCode")

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_Function Then

                Try

                    JobComponent = GridView.GetRowCellValue(RowHandle, "JobComponent")
                    FunctionCode = GridView.GetRowCellValue(RowHandle, "FunctionCode")

                Catch ex As Exception
                    JobComponent = ""
                    FunctionCode = ""
                End Try

                If (JobComponent Is Nothing OrElse JobComponent = "") AndAlso (FunctionCode Is Nothing OrElse FunctionCode = "") Then

                    Try

                        SalesClassCode = GridView.GetRowCellValue(RowHandle, "SalesClassCode")

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Function Then

                Try

                    JobNumber = GridView.GetRowCellValue(RowHandle, "JobNumber")
                    FunctionCode = GridView.GetRowCellValue(RowHandle, "FunctionCode")

                Catch ex As Exception
                    JobNumber = 0
                    FunctionCode = ""
                End Try

                If JobNumber = 0 AndAlso (FunctionCode Is Nothing OrElse FunctionCode = "") Then

                    Try

                        SalesClassCode = GridView.GetRowCellValue(RowHandle, "SalesClassCode")

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Campaign Then

                Try

                    CampaignCode = GridView.GetRowCellValue(RowHandle, "CampaignCode")

                Catch ex As Exception
                    CampaignCode = ""
                End Try

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Function Then

                Try

                    FunctionCode = GridView.GetRowCellValue(RowHandle, "FunctionCode")

                Catch ex As Exception
                    FunctionCode = ""
                End Try

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_FunctionConsolidation Then

                Try

                    JobNumber = GridView.GetRowCellValue(RowHandle, "JobNumber")
                    FunctionConsolidation = GridView.GetRowCellValue(RowHandle, "FunctionConsolidation")

                Catch ex As Exception
                    JobNumber = 0
                    FunctionConsolidation = ""
                End Try

                If JobNumber = 0 AndAlso (FunctionConsolidation Is Nothing OrElse FunctionConsolidation = "") Then

                    Try

                        SalesClassCode = GridView.GetRowCellValue(RowHandle, "SalesClassCode")

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_FunctionConsolidation Then

                Try

                    JobComponent = GridView.GetRowCellValue(RowHandle, "JobComponent")
                    FunctionConsolidation = GridView.GetRowCellValue(RowHandle, "FunctionConsolidation")

                Catch ex As Exception
                    JobComponent = ""
                    FunctionConsolidation = ""
                End Try

                If (JobComponent Is Nothing OrElse JobComponent = "") AndAlso (FunctionConsolidation Is Nothing OrElse FunctionConsolidation = "") Then

                    Try

                        SalesClassCode = GridView.GetRowCellValue(RowHandle, "SalesClassCode")

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.FunctionConsolidation Then

                Try

                    FunctionConsolidation = GridView.GetRowCellValue(RowHandle, "FunctionConsolidation")

                Catch ex As Exception
                    FunctionConsolidation = ""
                End Try

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_FunctionHeading Then

                Try

                    JobNumber = GridView.GetRowCellValue(RowHandle, "JobNumber")
                    FunctionHeading = GridView.GetRowCellValue(RowHandle, "FunctionHeading")

                Catch ex As Exception
                    JobNumber = 0
                    FunctionHeading = ""
                End Try

                If JobNumber = 0 AndAlso (FunctionHeading Is Nothing OrElse FunctionHeading = "") Then

                    Try

                        SalesClassCode = GridView.GetRowCellValue(RowHandle, "SalesClassCode")

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_FunctionHeading Then

                Try

                    JobComponent = GridView.GetRowCellValue(RowHandle, "JobComponent")
                    FunctionHeading = GridView.GetRowCellValue(RowHandle, "FunctionHeading")

                Catch ex As Exception
                    JobComponent = ""
                    FunctionHeading = ""
                End Try

                If (JobComponent Is Nothing OrElse JobComponent = "") AndAlso (FunctionHeading Is Nothing OrElse FunctionHeading = "") Then

                    Try

                        SalesClassCode = GridView.GetRowCellValue(RowHandle, "SalesClassCode")

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.FunctionHeading Then

                Try

                    FunctionHeading = GridView.GetRowCellValue(RowHandle, "FunctionHeading")

                Catch ex As Exception
                    FunctionHeading = ""
                End Try

            End If

            If ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                If ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    Try

                        FeeDate = GridView.GetRowCellValue(RowHandle, "FeeDate")

                    Catch ex As Exception
                        FeeDate = Nothing
                    End Try

                    Try

                        FeeDescription = GridView.GetRowCellValue(RowHandle, "Description")

                    Catch ex As Exception
                        FeeDescription = ""
                    End Try

                Else

                    Try

                        FeeDescription = GridView.GetRowCellValue(RowHandle, "Description")

                    Catch ex As Exception
                        FeeDescription = ""
                    End Try

                End If

            End If

            If ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job Then

                If JobNumber = 0 Then

                    If IsMaxIndex Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode).ToList

                    Else

                        If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                        End If

                    End If

                Else

                    SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component Then

                If JobComponent Is Nothing OrElse JobComponent = "" Then

                    If IsMaxIndex Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode).ToList

                    Else

                        If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                        End If

                    End If

                Else

                    SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_Function Then

                If (JobComponent Is Nothing OrElse JobComponent = "") AndAlso (FunctionCode Is Nothing OrElse FunctionCode = "") Then

                    If IsMaxIndex Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode).ToList

                    Else

                        If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                        End If

                    End If

                Else

                    SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Function Then

                If JobNumber = 0 AndAlso (FunctionCode Is Nothing OrElse FunctionCode = "") Then

                    If IsMaxIndex Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode).ToList

                    Else

                        If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                        End If

                    End If

                Else

                    SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Campaign Then

                If IsMaxIndex Then

                    SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.CampaignCode = CampaignCode).ToList

                Else

                    If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.CampaignCode = CampaignCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                    ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.CampaignCode = CampaignCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                    ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.CampaignCode = CampaignCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                    End If

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Function Then

                If IsMaxIndex Then

                    SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionCode = FunctionCode).ToList

                Else

                    If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                    ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                    ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                    End If

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_FunctionConsolidation Then

                If JobNumber = 0 AndAlso (FunctionConsolidation Is Nothing OrElse FunctionConsolidation = "") Then

                    If IsMaxIndex Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode).ToList

                    Else

                        If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                        End If

                    End If

                Else

                    SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_FunctionConsolidation Then

                If (JobComponent Is Nothing OrElse JobComponent = "") AndAlso (FunctionConsolidation Is Nothing OrElse FunctionConsolidation = "") Then

                    If IsMaxIndex Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode).ToList

                    Else

                        If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                        End If

                    End If

                Else

                    SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.FunctionConsolidation Then

                If IsMaxIndex Then

                    SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation).ToList

                Else

                    If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                    ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                    ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                    End If

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_FunctionHeading Then

                If JobNumber = 0 AndAlso (FunctionHeading Is Nothing OrElse FunctionHeading = "") Then

                    If IsMaxIndex Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode).ToList

                    Else

                        If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                        End If

                    End If

                Else

                    SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_FunctionHeading Then

                If (JobComponent Is Nothing OrElse JobComponent = "") AndAlso (FunctionHeading Is Nothing OrElse FunctionHeading = "") Then

                    If IsMaxIndex Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode).ToList

                    Else

                        If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                            SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                        End If

                    End If

                Else

                    SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.FunctionHeading Then

                If IsMaxIndex Then

                    SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading).ToList

                Else

                    If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                    ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                    ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        SFRDetailFilteredList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                    End If

                End If

            End If

            If ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                If ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    SFRDetailFilteredList = SFRDetailFilteredList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeDate = FeeDate AndAlso ServiceFeeReconcileDetail.Description = FeeDescription).ToList

                Else

                    SFRDetailFilteredList = SFRDetailFilteredList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.Description = FeeDescription).ToList

                End If

            End If

            LoadServiceFeesByRow = SFRDetailFilteredList

        End Function
        Private Function LoadDetailLevel(ByVal ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting,
                                         ByVal ServiceFeeReconciliationGroupByOption As AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions,
                                         ByVal ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles,
                                         ByVal ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile),
                                         ByVal IsMaxIndex As Boolean,
                                         ByVal Client As AdvantageFramework.Database.Entities.Client,
                                         ByVal Division As AdvantageFramework.Database.Entities.Division,
                                         ByVal Product As AdvantageFramework.Database.Entities.Product,
                                         ByVal RowHandle As Integer, ByVal RelationIndex As Integer,
                                         ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView) As IEnumerable


            'objects
            Dim JobComponent As String = ""
            Dim FunctionCode As String = ""
            Dim JobNumber As Integer = 0
            Dim CampaignCode As String = ""
            Dim SalesClassCode As String = ""
            Dim FunctionConsolidation As String = ""
            Dim FunctionHeading As String = ""
            Dim FeeDescription As String = ""
            Dim FeeDate As Date = Nothing
            Dim ServiceReconcileDetails As IEnumerable = Nothing

            If ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job Then

                Try

                    JobNumber = GridView.GetRowCellValue(RowHandle, "JobNumber")

                Catch ex As Exception
                    JobNumber = 0
                End Try

                If JobNumber = 0 Then

                    Try

                        SalesClassCode = GridView.GetRowCellValue(RowHandle, "SalesClassCode")

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component Then

                Try

                    JobComponent = GridView.GetRowCellValue(RowHandle, "JobComponent")

                Catch ex As Exception
                    JobComponent = ""
                End Try

                If JobComponent Is Nothing OrElse JobComponent = "" Then

                    Try

                        SalesClassCode = GridView.GetRowCellValue(RowHandle, "SalesClassCode")

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_Function Then

                Try

                    JobComponent = GridView.GetRowCellValue(RowHandle, "JobComponent")
                    FunctionCode = GridView.GetRowCellValue(RowHandle, "FunctionCode")

                Catch ex As Exception
                    JobComponent = ""
                    FunctionCode = ""
                End Try

                If (JobComponent Is Nothing OrElse JobComponent = "") AndAlso (FunctionCode Is Nothing OrElse FunctionCode = "") Then

                    Try

                        SalesClassCode = GridView.GetRowCellValue(RowHandle, "SalesClassCode")

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Function Then

                Try

                    JobNumber = GridView.GetRowCellValue(RowHandle, "JobNumber")
                    FunctionCode = GridView.GetRowCellValue(RowHandle, "FunctionCode")

                Catch ex As Exception
                    JobNumber = 0
                    FunctionCode = ""
                End Try

                If JobNumber = 0 AndAlso (FunctionCode Is Nothing OrElse FunctionCode = "") Then

                    Try

                        SalesClassCode = GridView.GetRowCellValue(RowHandle, "SalesClassCode")

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Campaign Then

                Try

                    CampaignCode = GridView.GetRowCellValue(RowHandle, "CampaignCode")

                Catch ex As Exception
                    CampaignCode = ""
                End Try

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Function Then

                Try

                    FunctionCode = GridView.GetRowCellValue(RowHandle, "FunctionCode")

                Catch ex As Exception
                    FunctionCode = ""
                End Try

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_FunctionConsolidation Then

                Try

                    JobNumber = GridView.GetRowCellValue(RowHandle, "JobNumber")
                    FunctionConsolidation = GridView.GetRowCellValue(RowHandle, "FunctionConsolidation")

                Catch ex As Exception
                    JobNumber = 0
                    FunctionConsolidation = ""
                End Try

                If JobNumber = 0 AndAlso (FunctionConsolidation Is Nothing OrElse FunctionConsolidation = "") Then

                    Try

                        SalesClassCode = GridView.GetRowCellValue(RowHandle, "SalesClassCode")

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_FunctionConsolidation Then

                Try

                    JobComponent = GridView.GetRowCellValue(RowHandle, "JobComponent")
                    FunctionConsolidation = GridView.GetRowCellValue(RowHandle, "FunctionConsolidation")

                Catch ex As Exception
                    JobComponent = ""
                    FunctionConsolidation = ""
                End Try

                If (JobComponent Is Nothing OrElse JobComponent = "") AndAlso (FunctionConsolidation Is Nothing OrElse FunctionConsolidation = "") Then

                    Try

                        SalesClassCode = GridView.GetRowCellValue(RowHandle, "SalesClassCode")

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.FunctionConsolidation Then

                Try

                    FunctionConsolidation = GridView.GetRowCellValue(RowHandle, "FunctionConsolidation")

                Catch ex As Exception
                    FunctionConsolidation = ""
                End Try

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_FunctionHeading Then

                Try

                    JobNumber = GridView.GetRowCellValue(RowHandle, "JobNumber")
                    FunctionHeading = GridView.GetRowCellValue(RowHandle, "FunctionHeading")

                Catch ex As Exception
                    JobNumber = 0
                    FunctionHeading = ""
                End Try

                If JobNumber = 0 AndAlso (FunctionHeading Is Nothing OrElse FunctionHeading = "") Then

                    Try

                        SalesClassCode = GridView.GetRowCellValue(RowHandle, "SalesClassCode")

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_FunctionHeading Then

                Try

                    JobComponent = GridView.GetRowCellValue(RowHandle, "JobComponent")
                    FunctionHeading = GridView.GetRowCellValue(RowHandle, "FunctionHeading")

                Catch ex As Exception
                    JobComponent = ""
                    FunctionHeading = ""
                End Try

                If (JobComponent Is Nothing OrElse JobComponent = "") AndAlso (FunctionHeading Is Nothing OrElse FunctionHeading = "") Then

                    Try

                        SalesClassCode = GridView.GetRowCellValue(RowHandle, "SalesClassCode")

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.FunctionHeading Then

                Try

                    FunctionHeading = GridView.GetRowCellValue(RowHandle, "FunctionHeading")

                Catch ex As Exception
                    FunctionHeading = ""
                End Try

            End If

            If ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                If ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    Try

                        FeeDate = GridView.GetRowCellValue(RowHandle, "FeeDate")

                    Catch ex As Exception
                        FeeDate = Nothing
                    End Try

                    Try

                        FeeDescription = GridView.GetRowCellValue(RowHandle, "Description")

                    Catch ex As Exception
                        FeeDescription = ""
                    End Try

                Else

                    Try

                        FeeDescription = GridView.GetRowCellValue(RowHandle, "Description")

                    Catch ex As Exception
                        FeeDescription = ""
                    End Try

                End If

            End If


            If ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job Then

                If JobNumber = 0 Then

                    If IsMaxIndex Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode).ToList

                    Else

                        If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                        End If

                    End If

                Else

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component Then

                If JobComponent Is Nothing OrElse JobComponent = "" Then

                    If IsMaxIndex Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode).ToList

                    Else

                        If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                        End If

                    End If

                Else

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_Function Then

                If (JobComponent Is Nothing OrElse JobComponent = "") AndAlso (FunctionCode Is Nothing OrElse FunctionCode = "") Then

                    If IsMaxIndex Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode).ToList

                    Else

                        If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                        End If

                    End If

                Else

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Function Then

                If JobNumber = 0 AndAlso (FunctionCode Is Nothing OrElse FunctionCode = "") Then

                    If IsMaxIndex Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode).ToList

                    Else

                        If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                        End If

                    End If

                Else

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionCode = FunctionCode).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Campaign Then

                If IsMaxIndex Then

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.CampaignCode = CampaignCode).ToList

                Else

                    If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.CampaignCode = CampaignCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                    ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.CampaignCode = CampaignCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                    ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.CampaignCode = CampaignCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                    End If

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Function Then

                If IsMaxIndex Then

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionCode = FunctionCode).ToList

                Else

                    If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                    ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                    ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                    End If

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_FunctionConsolidation Then

                If JobNumber = 0 AndAlso (FunctionConsolidation Is Nothing OrElse FunctionConsolidation = "") Then

                    If IsMaxIndex Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode).ToList

                    Else

                        If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                        End If

                    End If

                Else

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_FunctionConsolidation Then

                If (JobComponent Is Nothing OrElse JobComponent = "") AndAlso (FunctionConsolidation Is Nothing OrElse FunctionConsolidation = "") Then

                    If IsMaxIndex Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode).ToList

                    Else

                        If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                        End If

                    End If

                Else

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.FunctionConsolidation Then

                If IsMaxIndex Then

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation).ToList

                Else

                    If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                    ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                    ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                    End If

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_FunctionHeading Then

                If JobNumber = 0 AndAlso (FunctionHeading Is Nothing OrElse FunctionHeading = "") Then

                    If IsMaxIndex Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode).ToList

                    Else

                        If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                        End If

                    End If

                Else

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_FunctionHeading Then

                If (JobComponent Is Nothing OrElse JobComponent = "") AndAlso (FunctionHeading Is Nothing OrElse FunctionHeading = "") Then

                    If IsMaxIndex Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode).ToList

                    Else

                        If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                        ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                            ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                        End If

                    End If

                Else

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.JobComponent = JobComponent AndAlso ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.FunctionHeading Then

                If IsMaxIndex Then

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading).ToList

                Else

                    If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                    ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code).ToList

                    ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code).ToList

                    End If

                End If

            End If

            If ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                If ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeDate = FeeDate AndAlso ServiceFeeReconcileDetail.Description = FeeDescription).ToList

                Else

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.Description = FeeDescription).ToList

                End If

            End If

            If RelationIndex = 0 Then

                If ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                               Where ServiceFeeReconcileDetail.FeeTimeType.Contains("Billed") = False
                                               Select New AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail(ServiceFeeReconcileDetail)).ToList

                Else

                    ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                               Where ServiceFeeReconcileDetail.FeeTimeType.Contains("Billed") = False
                                               Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                               Select New AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail(ServiceFeeReconcile.ToList)).ToList

                End If

            Else

                If ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                    ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                               Where ServiceFeeReconcileDetail.FeeTimeType.Contains("Billed") = True
                                               Select New AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail(ServiceFeeReconcileDetail)).ToList

                Else

                    ServiceReconcileDetails = (From ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList
                                               Where ServiceFeeReconcileDetail.FeeTimeType.Contains("Billed") = True
                                               Group ServiceFeeReconcileDetail By ServiceFeeReconcileDetail.Description Into ServiceFeeReconcile = Group
                                               Select New AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail(ServiceFeeReconcile.ToList)).ToList

                End If

            End If

            LoadDetailLevel = ServiceReconcileDetails

        End Function
        Private Sub FormatMainGrid()

            If _ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job Then

                If _ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                    If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeDate.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    Else

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    End If

                Else

                    For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.OptionsColumn.ReadOnly = True

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                            GridColumn.Visible = True
                            GridColumn.OptionsColumn.AllowShowHide = True
                            GridColumn.OptionsColumn.ShowInCustomizationForm = True
                            GridColumn.OptionsColumn.ShowInExpressionEditor = True

                        Else

                            GridColumn.Visible = False
                            GridColumn.OptionsColumn.AllowShowHide = False
                            GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                End If

            ElseIf _ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component Then

                If _ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                    If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobComponent.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeDate.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.IsServiceFeeJob.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    Else

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobComponent.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.IsServiceFeeJob.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    End If

                Else

                    For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.OptionsColumn.ReadOnly = True

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobComponent.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.IsServiceFeeJob.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                            GridColumn.Visible = True
                            GridColumn.OptionsColumn.AllowShowHide = True
                            GridColumn.OptionsColumn.ShowInCustomizationForm = True
                            GridColumn.OptionsColumn.ShowInExpressionEditor = True

                        Else

                            GridColumn.Visible = False
                            GridColumn.OptionsColumn.AllowShowHide = False
                            GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                End If

            ElseIf _ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_Function Then

                If _ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                    If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobComponent.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeDate.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.IsServiceFeeJob.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionConsolidation.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionHeading.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    Else

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobComponent.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.IsServiceFeeJob.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionConsolidation.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionHeading.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    End If

                Else

                    For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.OptionsColumn.ReadOnly = True

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobComponent.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.IsServiceFeeJob.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionConsolidation.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionHeading.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                            GridColumn.Visible = True
                            GridColumn.OptionsColumn.AllowShowHide = True
                            GridColumn.OptionsColumn.ShowInCustomizationForm = True
                            GridColumn.OptionsColumn.ShowInExpressionEditor = True

                        Else

                            GridColumn.Visible = False
                            GridColumn.OptionsColumn.AllowShowHide = False
                            GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                End If

            ElseIf _ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Function Then

                If _ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                    If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeDate.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionConsolidation.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionHeading.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    Else

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionConsolidation.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionHeading.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    End If

                Else

                    For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.OptionsColumn.ReadOnly = True

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionConsolidation.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionHeading.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                            GridColumn.Visible = True
                            GridColumn.OptionsColumn.AllowShowHide = True
                            GridColumn.OptionsColumn.ShowInCustomizationForm = True
                            GridColumn.OptionsColumn.ShowInExpressionEditor = True

                        Else

                            GridColumn.Visible = False
                            GridColumn.OptionsColumn.AllowShowHide = False
                            GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                End If

            ElseIf _ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Campaign Then

                If _ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                    If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeDate.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    Else

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    End If

                Else

                    For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.OptionsColumn.ReadOnly = True

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                            GridColumn.Visible = True
                            GridColumn.OptionsColumn.AllowShowHide = True
                            GridColumn.OptionsColumn.ShowInCustomizationForm = True
                            GridColumn.OptionsColumn.ShowInExpressionEditor = True

                        Else

                            GridColumn.Visible = False
                            GridColumn.OptionsColumn.AllowShowHide = False
                            GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                End If

            ElseIf _ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Function Then

                If _ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                    If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeDate.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionConsolidation.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionHeading.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    Else

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionConsolidation.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionHeading.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    End If

                Else

                    For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.OptionsColumn.ReadOnly = True

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionConsolidation.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionHeading.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                            GridColumn.Visible = True
                            GridColumn.OptionsColumn.AllowShowHide = True
                            GridColumn.OptionsColumn.ShowInCustomizationForm = True
                            GridColumn.OptionsColumn.ShowInExpressionEditor = True

                        Else

                            GridColumn.Visible = False
                            GridColumn.OptionsColumn.AllowShowHide = False
                            GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                End If

            ElseIf _ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_FunctionConsolidation Then

                If _ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                    If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeDate.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionConsolidation.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    Else

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionConsolidation.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    End If

                Else

                    For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.OptionsColumn.ReadOnly = True

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionConsolidation.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                            GridColumn.Visible = True
                            GridColumn.OptionsColumn.AllowShowHide = True
                            GridColumn.OptionsColumn.ShowInCustomizationForm = True
                            GridColumn.OptionsColumn.ShowInExpressionEditor = True

                        Else

                            GridColumn.Visible = False
                            GridColumn.OptionsColumn.AllowShowHide = False
                            GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                End If

            ElseIf _ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_FunctionConsolidation Then

                If _ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                    If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobComponent.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeDate.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.IsServiceFeeJob.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionConsolidation.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    Else

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobComponent.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.IsServiceFeeJob.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionConsolidation.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    End If

                Else

                    For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.OptionsColumn.ReadOnly = True

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobComponent.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.IsServiceFeeJob.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionConsolidation.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                            GridColumn.Visible = True
                            GridColumn.OptionsColumn.AllowShowHide = True
                            GridColumn.OptionsColumn.ShowInCustomizationForm = True
                            GridColumn.OptionsColumn.ShowInExpressionEditor = True

                        Else

                            GridColumn.Visible = False
                            GridColumn.OptionsColumn.AllowShowHide = False
                            GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                End If

            ElseIf _ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.FunctionConsolidation Then

                If _ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                    If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeDate.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionConsolidation.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    Else

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionConsolidation.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    End If

                Else

                    For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.OptionsColumn.ReadOnly = True

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionConsolidation.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                            GridColumn.Visible = True
                            GridColumn.OptionsColumn.AllowShowHide = True
                            GridColumn.OptionsColumn.ShowInCustomizationForm = True
                            GridColumn.OptionsColumn.ShowInExpressionEditor = True

                        Else

                            GridColumn.Visible = False
                            GridColumn.OptionsColumn.AllowShowHide = False
                            GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                End If

            ElseIf _ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_FunctionHeading Then

                If _ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                    If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeDate.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionHeading.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    Else

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionHeading.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    End If

                Else

                    For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.OptionsColumn.ReadOnly = True

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionHeading.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                            GridColumn.Visible = True
                            GridColumn.OptionsColumn.AllowShowHide = True
                            GridColumn.OptionsColumn.ShowInCustomizationForm = True
                            GridColumn.OptionsColumn.ShowInExpressionEditor = True

                        Else

                            GridColumn.Visible = False
                            GridColumn.OptionsColumn.AllowShowHide = False
                            GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                End If

            ElseIf _ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_FunctionHeading Then

                If _ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                    If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobComponent.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeDate.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.IsServiceFeeJob.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionHeading.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    Else

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentNumber.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobComponent.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.IsServiceFeeJob.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionHeading.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    End If

                Else

                    For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.OptionsColumn.ReadOnly = True

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ClientDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.DivisionDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ProductDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.CampaignName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentNumber.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ComponentDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobComponent.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassCode.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.SalesClassDescription.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.IsServiceFeeJob.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionHeading.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                            GridColumn.Visible = True
                            GridColumn.OptionsColumn.AllowShowHide = True
                            GridColumn.OptionsColumn.ShowInCustomizationForm = True
                            GridColumn.OptionsColumn.ShowInExpressionEditor = True

                        Else

                            GridColumn.Visible = False
                            GridColumn.OptionsColumn.AllowShowHide = False
                            GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                End If

            ElseIf _ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.FunctionHeading Then

                If _ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy Then

                    If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeDate.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionHeading.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    Else

                        For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                            GridColumn.OptionsColumn.ReadOnly = True

                            If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.Description.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionHeading.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                    GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                                GridColumn.Visible = True
                                GridColumn.OptionsColumn.AllowShowHide = True
                                GridColumn.OptionsColumn.ShowInCustomizationForm = True
                                GridColumn.OptionsColumn.ShowInExpressionEditor = True

                            Else

                                GridColumn.Visible = False
                                GridColumn.OptionsColumn.AllowShowHide = False
                                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                                GridColumn.OptionsColumn.ShowInExpressionEditor = False

                            End If

                        Next

                    End If

                Else

                    For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.OptionsColumn.ReadOnly = True

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FunctionHeading.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString Then

                            GridColumn.Visible = True
                            GridColumn.OptionsColumn.AllowShowHide = True
                            GridColumn.OptionsColumn.ShowInCustomizationForm = True
                            GridColumn.OptionsColumn.ShowInExpressionEditor = True

                        Else

                            GridColumn.Visible = False
                            GridColumn.OptionsColumn.AllowShowHide = False
                            GridColumn.OptionsColumn.ShowInCustomizationForm = False
                            GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Next

                End If

            End If

        End Sub
        Private Sub UpdateStats(ByVal ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile))

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim ServiceFeeIncomeOnlyList As Generic.List(Of Database.Classes.ServiceFeeReconcile) = Nothing
            Dim ServiceFeeProductionCommissionList As Generic.List(Of Database.Classes.ServiceFeeReconcile) = Nothing
            Dim ServiceFeeMediaCommissionList As Generic.List(Of Database.Classes.ServiceFeeReconcile) = Nothing

            If ServiceFeeReconcileDetailList IsNot Nothing Then

                'LabelForm_StandardFeeBilled.Text = FormatCurrency(ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Standard Billed").ToList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount))
                'LabelForm_ProductCommissionFeeBilled.Text = FormatCurrency(ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Production Billed").ToList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount))
                'LabelForm_MediaCommissionFeeBuild.Text = FormatCurrency(ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Media Billed").ToList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount))
                ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Distinct().ToList

                If _Index = _MaxIndex Then

                    ServiceFeeIncomeOnlyList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Standard Billed").ToList
                    LabelForm_StandardFeeBilled.Text = FormatCurrency(ServiceFeeIncomeOnlyList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount))

                    ServiceFeeProductionCommissionList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Production Billed").ToList
                    LabelForm_ProductCommissionFeeBilled.Text = FormatCurrency(ServiceFeeProductionCommissionList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount))

                    ServiceFeeMediaCommissionList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Media Billed").ToList
                    LabelForm_MediaCommissionFeeBuild.Text = FormatCurrency(ServiceFeeMediaCommissionList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount))

                Else

                    If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        Client = _ClientList(_Index)

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                        ServiceFeeIncomeOnlyList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Standard Billed" AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList
                        LabelForm_StandardFeeBilled.Text = FormatCurrency(ServiceFeeIncomeOnlyList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount))

                        ServiceFeeProductionCommissionList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Production Billed" AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList
                        LabelForm_ProductCommissionFeeBilled.Text = FormatCurrency(ServiceFeeProductionCommissionList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount))

                        ServiceFeeMediaCommissionList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Media Billed" AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList
                        LabelForm_MediaCommissionFeeBuild.Text = FormatCurrency(ServiceFeeMediaCommissionList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount))

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        Division = _DivisionList(_Index)

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.DivisionCode = Division.Code AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode).ToList

                        ServiceFeeIncomeOnlyList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Standard Billed" AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode).ToList
                        LabelForm_StandardFeeBilled.Text = FormatCurrency(ServiceFeeIncomeOnlyList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount))

                        ServiceFeeProductionCommissionList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Production Billed" AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode).ToList
                        LabelForm_ProductCommissionFeeBilled.Text = FormatCurrency(ServiceFeeProductionCommissionList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount))

                        ServiceFeeMediaCommissionList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Media Billed" AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode).ToList
                        LabelForm_MediaCommissionFeeBuild.Text = FormatCurrency(ServiceFeeMediaCommissionList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount))

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        Product = _ProductList(_Index)

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.ProductCode = Product.Code AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode).ToList

                        ServiceFeeIncomeOnlyList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Standard Billed" AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode).ToList
                        LabelForm_StandardFeeBilled.Text = FormatCurrency(ServiceFeeIncomeOnlyList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount))

                        ServiceFeeProductionCommissionList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Production Billed" AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode).ToList
                        LabelForm_ProductCommissionFeeBilled.Text = FormatCurrency(ServiceFeeProductionCommissionList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount))

                        ServiceFeeMediaCommissionList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Media Billed" AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode).ToList
                        LabelForm_MediaCommissionFeeBuild.Text = FormatCurrency(ServiceFeeMediaCommissionList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount))

                    End If

                End If

                LabelForm_StandardFeeTimePosted.Text = FormatCurrency(ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Standard").Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.ReconciledAmount) + ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Standard").Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.UnreconciledAmount))
                LabelForm_ProductCommissionTimePosted.Text = FormatCurrency(ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Production").Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.ReconciledAmount) + ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Production").Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.UnreconciledAmount))
                LabelForm_MediaCommissionTimePosted.Text = FormatCurrency(ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Media").Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.ReconciledAmount) + ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Media").Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.UnreconciledAmount))
                LabelForm_ReconcileIndicator.Text = If(ServiceFeeReconcileDetailList.Sum(Function(Entity) Entity.ReconciledAmount) > 0, "Reconciled and Un-reconciled", "Un-reconciled Only")

            End If

            LabelForm_StandardFeeVariance.Text = FormatCurrency(CDec(LabelForm_StandardFeeBilled.Text) - CDec(LabelForm_StandardFeeTimePosted.Text))
            LabelForm_ProductCommissionVariance.Text = FormatCurrency(CDec(LabelForm_ProductCommissionFeeBilled.Text) - CDec(LabelForm_ProductCommissionTimePosted.Text))
            LabelForm_MediaCommissionVariance.Text = FormatCurrency(CDec(LabelForm_MediaCommissionFeeBuild.Text) - CDec(LabelForm_MediaCommissionTimePosted.Text))

            LabelForm_TotalsFeeBilled.Text = FormatCurrency(CDec(LabelForm_MediaCommissionFeeBuild.Text) + CDec(LabelForm_ProductCommissionFeeBilled.Text) + CDec(LabelForm_StandardFeeBilled.Text))
            LabelForm_TotalsTimePosted.Text = FormatCurrency(CDec(LabelForm_MediaCommissionTimePosted.Text) + CDec(LabelForm_ProductCommissionTimePosted.Text) + CDec(LabelForm_StandardFeeTimePosted.Text))
            LabelForm_TotalsVariance.Text = FormatCurrency(CDec(LabelForm_MediaCommissionVariance.Text) + CDec(LabelForm_ProductCommissionVariance.Text) + CDec(LabelForm_StandardFeeVariance.Text))

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal FeePostPeriodFrom As AdvantageFramework.Database.Entities.PostPeriod, ByVal FeePostPeriodTo As AdvantageFramework.Database.Entities.PostPeriod,
                                              ByVal SelectedCriteria As IEnumerable, ByVal FeeTimeFrom As Date, ByVal FeeTimeTo As Date,
                                              ByVal IncomeOnlySalesClassCodes As Generic.List(Of String), ByVal IncomeOnlyFunctionCodes As Generic.List(Of String),
                                              ByVal ProductionCommissionSalesClassCodes As Generic.List(Of String), ByVal ProductionCommissionFunctionCodes As Generic.List(Of String),
                                              ByVal ServiceFeeTypeCodes As Generic.List(Of String),
                                              ByVal ServiceFeeReconciliationGroupByOption As AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions,
                                              ByVal ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles) As System.Windows.Forms.DialogResult

            'objects
            Dim ServiceFeeReconciliationReportForm As AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeReconciliationReportForm = Nothing

            ServiceFeeReconciliationReportForm = New AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeReconciliationReportForm(FeePostPeriodFrom, FeePostPeriodTo, SelectedCriteria, FeeTimeFrom, FeeTimeTo, IncomeOnlySalesClassCodes, IncomeOnlyFunctionCodes, ProductionCommissionSalesClassCodes, ProductionCommissionFunctionCodes, ServiceFeeTypeCodes, ServiceFeeReconciliationGroupByOption, ServiceFeeReconciliationSummaryStyle)

            ShowFormDialog = ServiceFeeReconciliationReportForm.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ServiceFeeReconciliationReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim ClientList As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim DivisionList As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
            Dim ProductList As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
            Dim FeeTypesList As Generic.List(Of String) = Nothing

            ButtonItemPrinting_PrintGrid.Image = AdvantageFramework.My.Resources.PrintGridImage
            ButtonItemPrinting_PrintFullReport.Image = AdvantageFramework.My.Resources.PrintFullReportImage
            ButtonItemPrinting_PrintSelectedReport.Image = AdvantageFramework.My.Resources.PrintSelectedReportImage

            ButtonItemNavigation_First.Image = AdvantageFramework.My.Resources.FirstImage
            ButtonItemNavigation_Last.Image = AdvantageFramework.My.Resources.LastImage
            ButtonItemNavigation_Next.Image = AdvantageFramework.My.Resources.RightImage
            ButtonItemNavigation_Previous.Image = AdvantageFramework.My.Resources.LeftImage

            ButtonItemReconcile_DeselectAll.Image = AdvantageFramework.My.Resources.DeselectAllImage
            ButtonItemReconcile_SelectAll.Image = AdvantageFramework.My.Resources.ReviewAllImage
            ButtonItemReconcile_Reconcile.Image = AdvantageFramework.My.Resources.ReconcileImage
            ButtonItemReconcile_Unreconcile.Image = AdvantageFramework.My.Resources.UnreconcileImage

            ButtonItemReport_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemReport_SaveAs.Image = AdvantageFramework.My.Resources.SaveAsImage
            ButtonItemReport_LoadTemplate.Image = AdvantageFramework.My.Resources.DynamicReportImage
            ButtonItemReport_Templates.Image = AdvantageFramework.My.Resources.BlankDynamicReportImage
            ButtonItemQuickCustomize_Columns.Image = AdvantageFramework.My.Resources.ColumnImage

            DataGridViewForm_ServiceFees.OptionsView.ShowDetailButtons = True
            DataGridViewForm_ServiceFees.OptionsDetail.EnableMasterViewMode = True
            DataGridViewForm_ServiceFees.OptionsDetail.AllowExpandEmptyDetails = True
            DataGridViewForm_ServiceFees.OptionsDetail.ShowDetailTabs = True
            DataGridViewForm_ServiceFees.CurrentView.ObjectType = GetType(AdvantageFramework.Database.Classes.ServiceFeeReconcile)
            DataGridViewForm_ServiceFees.ItemDescription = "Service Fee(s)"

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _ServiceFeeReconciliationSetting = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSetting.LoadByUserCode(SecurityDbContext, Me.Session.UserCode)

            End Using

            LoadDetailViews()

			LoadReportData()

			LabelForm_FeesBilled.Text = String.Format(LabelForm_FeesBilled.Text, _FeePostPeriodFrom.Code, _FeePostPeriodTo.Code)
            LabelForm_FeeTimePosted.Text = String.Format(LabelForm_FeeTimePosted.Text, _FeeTimeFrom.ToShortDateString, _FeeTimeTo.ToShortDateString)

            ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked = DataGridViewForm_ServiceFees.OptionsPrint.AutoWidth
            ButtonItemOptionsLeft_PrintFilterInfo.Checked = DataGridViewForm_ServiceFees.OptionsPrint.PrintFilterInfo
            ButtonItemOptionsMiddle_PrintFooter.Checked = DataGridViewForm_ServiceFees.OptionsPrint.PrintFooter
            ButtonItemOptionsMiddle_PrintGroupFooter.Checked = DataGridViewForm_ServiceFees.OptionsPrint.PrintGroupFooter
            ButtonItemOptionsMiddle_PrintHeader.Checked = DataGridViewForm_ServiceFees.OptionsPrint.PrintHeader
            ButtonItemOptionsRight_PrintSelectedRowsOnly.Checked = DataGridViewForm_ServiceFees.OptionsPrint.PrintSelectedRowsOnly
            ButtonItemViewLeft_AllowCellMerging.Checked = DataGridViewForm_ServiceFees.OptionsView.AllowCellMerge
            ButtonItemViewLeft_ShowGroupByBox.Checked = DataGridViewForm_ServiceFees.OptionsView.ShowGroupPanel
            ButtonItemViewLeft_ShowViewCaption.Checked = DataGridViewForm_ServiceFees.OptionsView.ShowViewCaption
            ButtonItemFilter_ShowAutoFilterRow.Checked = DataGridViewForm_ServiceFees.OptionsView.ShowAutoFilterRow

            If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                LabelForm_Client.Visible = True
                LabelForm_ClientDescription.Visible = True
                LabelForm_Division.Visible = False
                LabelForm_DivisionDescription.Visible = False
                LabelForm_Product.Visible = False
                LabelForm_ProductDescription.Visible = False

            ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                LabelForm_Client.Visible = True
                LabelForm_ClientDescription.Visible = True
                LabelForm_Division.Visible = True
                LabelForm_DivisionDescription.Visible = True
                LabelForm_Product.Visible = False
                LabelForm_ProductDescription.Visible = False

            ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                LabelForm_Client.Visible = True
                LabelForm_ClientDescription.Visible = True
                LabelForm_Division.Visible = True
                LabelForm_DivisionDescription.Visible = True
                LabelForm_Product.Visible = True
                LabelForm_ProductDescription.Visible = True

            End If

        End Sub
        Private Sub ServiceFeeReconciliationReportForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Navigate(NavigationType.First)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub _GridViewServiceFeeDetailsLevel1Tab1_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

            'objects
            Dim EnableButtons As Boolean = False
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim ServiceFeeReconcileDetail As AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail = Nothing
            Dim FeeTimeType As String = ""

            If _SelectingAllRowsForReconciliation = False AndAlso e.Column.FieldName = AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail.Properties.Reconcile.ToString Then

                Try

                    If e.Value = True Then

                        EnableButtons = True

                    Else

                        For RowHandle = 0 To DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).RowCount - 1

                            FeeTimeType = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(RowHandle, "FeeTimeType")

                            If FeeTimeType.Contains("Billed") = False Then

                                Try

                                    BaseView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetDetailView(RowHandle, 1)

                                Catch ex As Exception
                                    BaseView = Nothing
                                End Try

                                If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                                    For BaseViewRowHandle = 0 To BaseView.RowCount - 1

                                        Try

                                            ServiceFeeReconcileDetail = BaseView.GetRow(BaseViewRowHandle)

                                        Catch ex As Exception
                                            ServiceFeeReconcileDetail = Nothing
                                        End Try

                                        If ServiceFeeReconcileDetail IsNot Nothing Then

                                            If ServiceFeeReconcileDetail.Reconcile Then

                                                EnableButtons = True
                                                Exit For

                                            End If

                                        End If

                                    Next

                                End If

                            End If

                            If EnableButtons Then

                                Exit For

                            End If

                        Next

                    End If

                Catch ex As Exception
                    EnableButtons = False
                End Try

                ButtonItemReconcile_Reconcile.Enabled = EnableButtons
                ButtonItemReconcile_Unreconcile.Enabled = EnableButtons

            End If

        End Sub
        Private Sub ButtonItemNavigation_First_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemNavigation_First.Click

            Navigate(NavigationType.First)

        End Sub
        Private Sub ButtonItemNavigation_Last_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemNavigation_Last.Click

            Navigate(NavigationType.Last)

        End Sub
        Private Sub ButtonItemNavigation_Next_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemNavigation_Next.Click

            Navigate(NavigationType.Next)

        End Sub
        Private Sub ButtonItemNavigation_Previous_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemNavigation_Previous.Click

            Navigate(NavigationType.Previous)

        End Sub
        Private Sub ButtonItemSystem_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemPrinting_PrintGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemPrinting_PrintGrid.Click

            DataGridViewForm_ServiceFees.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("Form", ""))

        End Sub
        Private Sub ButtonItemPrinting_PrintFullReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemPrinting_PrintFullReport.Click

            'objects
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

            ParameterDictionary = New Generic.Dictionary(Of String, Object)

            ParameterDictionary("FeePostPeriodFrom") = _FeePostPeriodFrom
            ParameterDictionary("FeePostPeriodTo") = _FeePostPeriodTo
            ParameterDictionary("FeeTimeFrom") = _FeeTimeFrom
            ParameterDictionary("FeeTimeTo") = _FeeTimeTo
            ParameterDictionary("ServiceFeeReconciliationGroupByOption") = _ServiceFeeReconciliationGroupByOption
            ParameterDictionary("ServiceFeeReconciliationSummaryStyle") = _ServiceFeeReconciliationSummaryStyle

            ParameterDictionary("DataSource") = _ServiceFeeReconcileDetailList

            AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, AdvantageFramework.Reporting.ReportTypes.ServiceFeeReconciliationReport, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

        End Sub
        Private Sub ButtonItemPrinting_PrintSelectedReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemPrinting_PrintSelectedReport.Click

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile) = Nothing

            ParameterDictionary = New Generic.Dictionary(Of String, Object)

            ParameterDictionary("FeePostPeriodFrom") = _FeePostPeriodFrom
            ParameterDictionary("FeePostPeriodTo") = _FeePostPeriodTo
            ParameterDictionary("FeeTimeFrom") = _FeeTimeFrom
            ParameterDictionary("FeeTimeTo") = _FeeTimeTo
            ParameterDictionary("ServiceFeeReconciliationGroupByOption") = _ServiceFeeReconciliationGroupByOption
            ParameterDictionary("ServiceFeeReconciliationSummaryStyle") = _ServiceFeeReconciliationSummaryStyle

            If _Index = _MaxIndex Then

                ServiceFeeReconcileDetailList = _ServiceFeeReconcileDetailList.Select(Function(EntityView) EntityView.Copy).ToList

                For Each ServiceFeeReconcileDetail In ServiceFeeReconcileDetailList

                    ServiceFeeReconcileDetail.ClientCode = "All"
                    ServiceFeeReconcileDetail.ClientDescription = "All Clients"
                    ServiceFeeReconcileDetail.DivisionCode = "All"
                    ServiceFeeReconcileDetail.DivisionDescription = "All Divisions"
                    ServiceFeeReconcileDetail.ProductCode = "All"
                    ServiceFeeReconcileDetail.ProductDescription = "All Products"

                Next

            Else

                If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                    Client = _ClientList(_Index)

                    ServiceFeeReconcileDetailList = _ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                    Division = _DivisionList(_Index)

                    ServiceFeeReconcileDetailList = _ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.DivisionCode = Division.Code AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode).ToList

                ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                    Product = _ProductList(_Index)

                    ServiceFeeReconcileDetailList = _ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.ProductCode = Product.Code AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode).ToList

                End If

            End If

            ParameterDictionary("DataSource") = ServiceFeeReconcileDetailList

            AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, AdvantageFramework.Reporting.ReportTypes.ServiceFeeReconciliationReport, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

        End Sub
        Private Sub DataGridViewForm_ServiceFees_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ServiceFees.ColumnFilterChangedEvent

            'objects
            Dim ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile) = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim IsMaxIndex As Boolean = True

            If DataGridViewForm_ServiceFees.DataSource IsNot Nothing AndAlso DataGridViewForm_ServiceFees.HasRows AndAlso _SFRFilteredList IsNot Nothing Then

                If String.IsNullOrEmpty(DataGridViewForm_ServiceFees.CurrentView.ActiveFilterString) = False Then

                    If _Index < _MaxIndex Then

                        IsMaxIndex = False

                        If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                            Client = _ClientList(_Index)

                        ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                            Division = _DivisionList(_Index)

                        ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                            Product = _ProductList(_Index)

                        End If

                    End If

                    ServiceFeeReconcileDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)

                    For RowHandle = 0 To DataGridViewForm_ServiceFees.CurrentView.RowCount - 1

                        If DataGridViewForm_ServiceFees.CurrentView.IsDataRow(RowHandle) Then

                            ServiceFeeReconcileDetailList.AddRange(LoadServiceFeesByRow(_ServiceFeeReconciliationSetting, _ServiceFeeReconciliationGroupByOption, _ServiceFeeReconciliationSummaryStyle, _SFRFilteredList,
                                                                                        IsMaxIndex, Client, Division, Product, RowHandle, DataGridViewForm_ServiceFees.CurrentView))

                        End If

                    Next

                    UpdateStats(ServiceFeeReconcileDetailList)

                Else

                    UpdateStats(_SFRFilteredList)

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ServiceFees_CreateMarginalHeaderAreaEvent(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles DataGridViewForm_ServiceFees.CreateMarginalHeaderAreaEvent

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing

            e.Graph.Modifier = DevExpress.XtraPrinting.BrickModifier.MarginalHeader

            e.Graph.Font = New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Regular)

            TextBrick = e.Graph.DrawString(LabelForm_FeesBilled.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(0, 0, 150, 15), DevExpress.XtraPrinting.BorderSide.None)
            TextBrick.Font = New System.Drawing.Font(e.Graph.Font.FontFamily.Name, 8, Drawing.FontStyle.Bold)

            TextBrick = e.Graph.DrawString(LabelForm_ReconcileIndicator.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(150, 0, 100, 15), DevExpress.XtraPrinting.BorderSide.None)
            TextBrick.Font = New System.Drawing.Font(e.Graph.Font.FontFamily.Name, 8, Drawing.FontStyle.Bold)

            TextBrick = e.Graph.DrawString(LabelForm_FeeTimePosted.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(0, 15, 150, 15), DevExpress.XtraPrinting.BorderSide.None)
            TextBrick.Font = New System.Drawing.Font(e.Graph.Font.FontFamily.Name, 8, Drawing.FontStyle.Bold)

            TextBrick = e.Graph.DrawString(LabelForm_Client.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(0, 30, 50, 15), DevExpress.XtraPrinting.BorderSide.None)
            TextBrick.Font = New System.Drawing.Font(e.Graph.Font.FontFamily.Name, 8, Drawing.FontStyle.Bold)
            TextBrick = e.Graph.DrawString(LabelForm_ClientDescription.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(50, 30, 200, 15), DevExpress.XtraPrinting.BorderSide.None)

            If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 OrElse _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                TextBrick = e.Graph.DrawString(LabelForm_Division.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(0, 45, 50, 15), DevExpress.XtraPrinting.BorderSide.None)
                TextBrick.Font = New System.Drawing.Font(e.Graph.Font.FontFamily.Name, 8, Drawing.FontStyle.Bold)
                TextBrick = e.Graph.DrawString(LabelForm_DivisionDescription.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(50, 45, 200, 15), DevExpress.XtraPrinting.BorderSide.None)

            End If

            If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                TextBrick = e.Graph.DrawString(LabelForm_Product.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(0, 60, 50, 15), DevExpress.XtraPrinting.BorderSide.None)
                TextBrick.Font = New System.Drawing.Font(e.Graph.Font.FontFamily.Name, 8, Drawing.FontStyle.Bold)
                TextBrick = e.Graph.DrawString(LabelForm_ProductDescription.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(50, 60, 200, 15), DevExpress.XtraPrinting.BorderSide.None)

            End If

            TextBrick = e.Graph.DrawString(LabelForm_RowStandardFee.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(250, 15, 100, 15), DevExpress.XtraPrinting.BorderSide.None)
            TextBrick = e.Graph.DrawString("Product Comm:", System.Drawing.Color.Black, New System.Drawing.RectangleF(250, 30, 100, 15), DevExpress.XtraPrinting.BorderSide.None)
            TextBrick = e.Graph.DrawString("Media Comm:", System.Drawing.Color.Black, New System.Drawing.RectangleF(250, 45, 100, 15), DevExpress.XtraPrinting.BorderSide.None)
            TextBrick = e.Graph.DrawString(LabelForm_RowTotals.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(250, 60, 100, 15), DevExpress.XtraPrinting.BorderSide.Top)
            TextBrick.Font = New System.Drawing.Font(e.Graph.Font.FontFamily.Name, 8, Drawing.FontStyle.Bold)
            TextBrick.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
            TextBrick.BorderWidth = 1
            TextBrick.BorderColor = Drawing.Color.Black

            TextBrick = e.Graph.DrawString(LabelForm_ColumnFeeBilled.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(350, 0, 100, 15), DevExpress.XtraPrinting.BorderSide.Bottom)
            TextBrick.Font = New System.Drawing.Font(e.Graph.Font.FontFamily.Name, 8, Drawing.FontStyle.Bold)
            TextBrick.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
            TextBrick.BorderWidth = 1
            TextBrick.BorderColor = Drawing.Color.Black
            TextBrick = e.Graph.DrawString(LabelForm_StandardFeeBilled.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(350, 15, 100, 15), DevExpress.XtraPrinting.BorderSide.None)
            TextBrick = e.Graph.DrawString(LabelForm_ProductCommissionFeeBilled.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(350, 30, 100, 15), DevExpress.XtraPrinting.BorderSide.None)
            TextBrick = e.Graph.DrawString(LabelForm_MediaCommissionFeeBuild.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(350, 45, 100, 15), DevExpress.XtraPrinting.BorderSide.None)
            TextBrick = e.Graph.DrawString(LabelForm_TotalsFeeBilled.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(350, 60, 100, 15), DevExpress.XtraPrinting.BorderSide.Top)
            TextBrick.Font = New System.Drawing.Font(e.Graph.Font.FontFamily.Name, 8, Drawing.FontStyle.Bold)
            TextBrick.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
            TextBrick.BorderWidth = 1
            TextBrick.BorderColor = Drawing.Color.Black

            TextBrick = e.Graph.DrawString(LabelForm_ColumnTimePosted.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(450, 0, 100, 15), DevExpress.XtraPrinting.BorderSide.Bottom)
            TextBrick.Font = New System.Drawing.Font(e.Graph.Font.FontFamily.Name, 8, Drawing.FontStyle.Bold)
            TextBrick.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
            TextBrick.BorderWidth = 1
            TextBrick.BorderColor = Drawing.Color.Black
            TextBrick = e.Graph.DrawString(LabelForm_StandardFeeTimePosted.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(450, 15, 100, 15), DevExpress.XtraPrinting.BorderSide.None)
            TextBrick = e.Graph.DrawString(LabelForm_ProductCommissionTimePosted.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(450, 30, 100, 15), DevExpress.XtraPrinting.BorderSide.None)
            TextBrick = e.Graph.DrawString(LabelForm_MediaCommissionTimePosted.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(450, 45, 100, 15), DevExpress.XtraPrinting.BorderSide.None)
            TextBrick = e.Graph.DrawString(LabelForm_TotalsTimePosted.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(450, 60, 100, 15), DevExpress.XtraPrinting.BorderSide.Top)
            TextBrick.Font = New System.Drawing.Font(e.Graph.Font.FontFamily.Name, 8, Drawing.FontStyle.Bold)
            TextBrick.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
            TextBrick.BorderWidth = 1
            TextBrick.BorderColor = Drawing.Color.Black

            TextBrick = e.Graph.DrawString(LabelForm_ColumnVariance.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(550, 0, 100, 15), DevExpress.XtraPrinting.BorderSide.Bottom)
            TextBrick.Font = New System.Drawing.Font(e.Graph.Font.FontFamily.Name, 8, Drawing.FontStyle.Bold)
            TextBrick.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
            TextBrick.BorderWidth = 1
            TextBrick.BorderColor = Drawing.Color.Black
            TextBrick = e.Graph.DrawString(LabelForm_StandardFeeVariance.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(550, 15, 100, 15), DevExpress.XtraPrinting.BorderSide.None)
            TextBrick = e.Graph.DrawString(LabelForm_ProductCommissionVariance.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(550, 30, 100, 15), DevExpress.XtraPrinting.BorderSide.None)
            TextBrick = e.Graph.DrawString(LabelForm_MediaCommissionVariance.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(550, 45, 100, 15), DevExpress.XtraPrinting.BorderSide.None)
            TextBrick = e.Graph.DrawString(LabelForm_TotalsVariance.Text, System.Drawing.Color.Black, New System.Drawing.RectangleF(550, 60, 100, 15), DevExpress.XtraPrinting.BorderSide.Top)
            TextBrick.Font = New System.Drawing.Font(e.Graph.Font.FontFamily.Name, 8, Drawing.FontStyle.Bold)
            TextBrick.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
            TextBrick.BorderWidth = 1
            TextBrick.BorderColor = Drawing.Color.Black

        End Sub
        Private Sub DataGridViewForm_ServiceFees_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ServiceFees.DataSourceChangedEvent

            If _ClearColumnFilters Then

                DataGridViewForm_ServiceFees.CurrentView.ClearColumnsFilter()

            End If

            UpdateStats(_SFRFilteredList)

        End Sub
        Private Sub _BackgroundWorker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _BackgroundWorker.DoWork

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile) = Nothing
            'Dim ServiceFeeIncomeOnlyList As Generic.List(Of Database.Classes.ServiceFeeReconcile) = Nothing
            'Dim ServiceFeeProductionCommissionList As Generic.List(Of Database.Classes.ServiceFeeReconcile) = Nothing
            'Dim ServiceFeeMediaCommissionList As Generic.List(Of Database.Classes.ServiceFeeReconcile) = Nothing

            If _Index = _MaxIndex Then

                _BackgroundWorker.ReportProgress(1, "")

                _SFRFilteredList = _ServiceFeeReconcileDetailList
                ServiceFeeReconcileDetailList = _SFRFilteredList

                _BackgroundWorker.ReportProgress(2, ServiceFeeReconcileDetailList)

                'ServiceFeeIncomeOnlyList = _ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Standard Billed").ToList

                '_BackgroundWorker.ReportProgress(3, FormatCurrency(ServiceFeeIncomeOnlyList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount)))

                'ServiceFeeProductionCommissionList = _ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Production Billed").ToList

                '_BackgroundWorker.ReportProgress(4, FormatCurrency(ServiceFeeProductionCommissionList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount)))

                'ServiceFeeMediaCommissionList = _ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Media Billed").ToList

                '_BackgroundWorker.ReportProgress(5, FormatCurrency(ServiceFeeMediaCommissionList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount)))

            Else

                If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                    Client = _ClientList(_Index)

                    _BackgroundWorker.ReportProgress(1, Client)

                    _SFRFilteredList = _ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList
                    ServiceFeeReconcileDetailList = _SFRFilteredList

                    _BackgroundWorker.ReportProgress(2, ServiceFeeReconcileDetailList)

                    'ServiceFeeIncomeOnlyList = _ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Standard Billed" AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                    '_BackgroundWorker.ReportProgress(3, FormatCurrency(ServiceFeeIncomeOnlyList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount)))

                    'ServiceFeeProductionCommissionList = _ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Production Billed" AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                    '_BackgroundWorker.ReportProgress(4, FormatCurrency(ServiceFeeProductionCommissionList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount)))

                    'ServiceFeeMediaCommissionList = _ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Media Billed" AndAlso ServiceFeeReconcileDetail.ClientCode = Client.Code).ToList

                    '_BackgroundWorker.ReportProgress(5, FormatCurrency(ServiceFeeMediaCommissionList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount)))

                ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                    Division = _DivisionList(_Index)

                    _BackgroundWorker.ReportProgress(1, Division)

                    _SFRFilteredList = _ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.DivisionCode = Division.Code AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode).ToList
                    ServiceFeeReconcileDetailList = _SFRFilteredList

                    _BackgroundWorker.ReportProgress(2, ServiceFeeReconcileDetailList)

                    'ServiceFeeIncomeOnlyList = _ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Standard Billed" AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode).ToList

                    '_BackgroundWorker.ReportProgress(3, FormatCurrency(ServiceFeeIncomeOnlyList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount)))

                    'ServiceFeeProductionCommissionList = _ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Production Billed" AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode).ToList

                    '_BackgroundWorker.ReportProgress(4, FormatCurrency(ServiceFeeProductionCommissionList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount)))

                    'ServiceFeeMediaCommissionList = _ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Media Billed" AndAlso ServiceFeeReconcileDetail.DivisionCode = Division.Code AndAlso ServiceFeeReconcileDetail.ClientCode = Division.ClientCode).ToList

                    '_BackgroundWorker.ReportProgress(5, FormatCurrency(ServiceFeeMediaCommissionList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount)))

                ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                    Product = _ProductList(_Index)

                    _BackgroundWorker.ReportProgress(1, Product)

                    _SFRFilteredList = _ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.ProductCode = Product.Code AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode).ToList
                    ServiceFeeReconcileDetailList = _SFRFilteredList

                    _BackgroundWorker.ReportProgress(2, ServiceFeeReconcileDetailList)

                    'ServiceFeeIncomeOnlyList = _ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Standard Billed" AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode).ToList

                    '_BackgroundWorker.ReportProgress(3, FormatCurrency(ServiceFeeIncomeOnlyList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount)))

                    'ServiceFeeProductionCommissionList = _ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Production Billed" AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode).ToList

                    '_BackgroundWorker.ReportProgress(4, FormatCurrency(ServiceFeeProductionCommissionList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount)))

                    'ServiceFeeMediaCommissionList = _ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Media Billed" AndAlso ServiceFeeReconcileDetail.ProductCode = Product.Code AndAlso ServiceFeeReconcileDetail.DivisionCode = Product.DivisionCode AndAlso ServiceFeeReconcileDetail.ClientCode = Product.ClientCode).ToList

                    '_BackgroundWorker.ReportProgress(5, FormatCurrency(ServiceFeeMediaCommissionList.Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeAmount)))

                End If

            End If

            '_BackgroundWorker.ReportProgress(6, FormatCurrency(ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Standard").Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.ReconciledAmount) + ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Standard").Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.UnreconciledAmount)))
            '_BackgroundWorker.ReportProgress(7, FormatCurrency(ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Production").Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.ReconciledAmount) + ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Production").Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.UnreconciledAmount)))
            '_BackgroundWorker.ReportProgress(8, FormatCurrency(ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Media").Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.ReconciledAmount) + ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.FeeTimeType = "Media").Sum(Function(ServiceFeeReconcileDetail) ServiceFeeReconcileDetail.UnreconciledAmount)))
            '_BackgroundWorker.ReportProgress(9, If(ServiceFeeReconcileDetailList.Sum(Function(Entity) Entity.ReconciledAmount) > 0, "Reconciled and Un-reconciled", "Un-reconciled Only"))

        End Sub
        Private Sub _BackgroundWorker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles _BackgroundWorker.ProgressChanged

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile) = Nothing

            If e.ProgressPercentage = 1 Then

                If _Index = _MaxIndex Then

                    LabelForm_ClientDescription.Text = "All Clients"
                    LabelForm_DivisionDescription.Text = "All Divisions"
                    LabelForm_ProductDescription.Text = "All Products"

                Else

                    If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        Client = e.UserState

                        LabelForm_ClientDescription.Text = Client.Name
                        LabelForm_DivisionDescription.Text = ""
                        LabelForm_ProductDescription.Text = ""

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        Division = e.UserState

                        LabelForm_ClientDescription.Text = Division.Client.Name
                        LabelForm_DivisionDescription.Text = Division.Name
                        LabelForm_ProductDescription.Text = ""

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        Product = e.UserState

                        LabelForm_ClientDescription.Text = Product.Client.Name
                        LabelForm_DivisionDescription.Text = Product.Division.Name
                        LabelForm_ProductDescription.Text = Product.Name

                    End If

                End If

            ElseIf e.ProgressPercentage = 2 Then

                ServiceFeeReconcileDetailList = e.UserState

                DataGridViewForm_ServiceFees.DataSource = LoadGroupByLevelData(_ServiceFeeReconciliationSetting, _ServiceFeeReconciliationGroupByOption, _ServiceFeeReconciliationSummaryStyle, ServiceFeeReconcileDetailList)

            ElseIf e.ProgressPercentage = 3 Then

                LabelForm_StandardFeeBilled.Text = e.UserState

            ElseIf e.ProgressPercentage = 4 Then

                LabelForm_ProductCommissionFeeBilled.Text = e.UserState

            ElseIf e.ProgressPercentage = 5 Then

                LabelForm_MediaCommissionFeeBuild.Text = e.UserState

            ElseIf e.ProgressPercentage = 6 Then

                LabelForm_StandardFeeTimePosted.Text = e.UserState

            ElseIf e.ProgressPercentage = 7 Then

                LabelForm_ProductCommissionTimePosted.Text = e.UserState

            ElseIf e.ProgressPercentage = 8 Then

                LabelForm_MediaCommissionTimePosted.Text = e.UserState

            ElseIf e.ProgressPercentage = 9 Then

                LabelForm_ReconcileIndicator.Text = e.UserState

            End If

            ProgressBarItemStatusBar_ProgressBar.Value = e.ProgressPercentage

            Me.Refresh()

        End Sub
        Private Sub _BackgroundWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles _BackgroundWorker.RunWorkerCompleted

            If _FirstAsyncCompleted = False Then

                If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString) IsNot Nothing Then

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString).DisplayFormat.FormatString = "n2"
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                    End If

                End If

                If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString) IsNot Nothing Then

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString).DisplayFormat.FormatString = "n2"
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                    End If

                End If

                If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString) IsNot Nothing Then

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString).DisplayFormat.FormatString = "n2"
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                    End If

                End If

                If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString) IsNot Nothing Then

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString).DisplayFormat.FormatString = "n2"
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                    End If

                End If

                If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString) IsNot Nothing Then

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString).DisplayFormat.FormatString = "n2"
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                    End If

                End If

                If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString) IsNot Nothing Then

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString).DisplayFormat.FormatString = "n2"
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                    End If

                End If

                If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString) IsNot Nothing Then

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString).DisplayFormat.FormatString = "n2"
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                    End If

                End If

                If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString) IsNot Nothing Then

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString).DisplayFormat.FormatString = "n2"
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                    End If

                End If

                If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeDepartmentTeamServiceFeeTypeCode.ToString) IsNot Nothing Then

                    DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeDepartmentTeamServiceFeeTypeCode.ToString).Caption = "Service Fee Type"

                End If

                If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode.ToString) IsNot Nothing Then

                    DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode.ToString).Caption = "Service Fee Type"

                End If

                If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobServiceFeeTypeCode.ToString) IsNot Nothing Then

                    DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobServiceFeeTypeCode.ToString).Caption = "Service Fee Type"

                End If

                FormatMainGrid()

                If _ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 0 Then

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeDepartmentTeamServiceFeeTypeCode.ToString) IsNot Nothing Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeDepartmentTeamServiceFeeTypeCode.ToString).Visible = False
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeDepartmentTeamServiceFeeTypeCode.ToString).OptionsColumn.AllowShowHide = False

                    End If

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode.ToString) IsNot Nothing Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode.ToString).Visible = False
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode.ToString).OptionsColumn.AllowShowHide = False

                    End If

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobServiceFeeTypeCode.ToString) IsNot Nothing Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobServiceFeeTypeCode.ToString).Visible = False
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobServiceFeeTypeCode.ToString).OptionsColumn.AllowShowHide = False

                    End If

                ElseIf _ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeDepartmentTeamServiceFeeTypeCode.ToString) IsNot Nothing Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeDepartmentTeamServiceFeeTypeCode.ToString).Visible = True
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeDepartmentTeamServiceFeeTypeCode.ToString).OptionsColumn.AllowShowHide = True
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeDepartmentTeamServiceFeeTypeCode.ToString).OptionsColumn.ShowInCustomizationForm = True
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeDepartmentTeamServiceFeeTypeCode.ToString).OptionsColumn.ShowInExpressionEditor = True
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeDepartmentTeamServiceFeeTypeCode.ToString).Caption = "Service Fee Type"

                    End If

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode.ToString) IsNot Nothing Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode.ToString).Visible = False
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode.ToString).OptionsColumn.AllowShowHide = False

                    End If

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobServiceFeeTypeCode.ToString) IsNot Nothing Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobServiceFeeTypeCode.ToString).Visible = False
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobServiceFeeTypeCode.ToString).OptionsColumn.AllowShowHide = False

                    End If

                ElseIf _ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeDepartmentTeamServiceFeeTypeCode.ToString) IsNot Nothing Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeDepartmentTeamServiceFeeTypeCode.ToString).Visible = False
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeDepartmentTeamServiceFeeTypeCode.ToString).OptionsColumn.AllowShowHide = False

                    End If

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode.ToString) IsNot Nothing Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode.ToString).Visible = True
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode.ToString).OptionsColumn.AllowShowHide = True
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode.ToString).OptionsColumn.ShowInCustomizationForm = True
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode.ToString).OptionsColumn.ShowInExpressionEditor = True
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode.ToString).Caption = "Service Fee Type"

                    End If

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobServiceFeeTypeCode.ToString) IsNot Nothing Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobServiceFeeTypeCode.ToString).Visible = False
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobServiceFeeTypeCode.ToString).OptionsColumn.AllowShowHide = False

                    End If

                ElseIf _ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeDepartmentTeamServiceFeeTypeCode.ToString) IsNot Nothing Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeDepartmentTeamServiceFeeTypeCode.ToString).Visible = False
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeDepartmentTeamServiceFeeTypeCode.ToString).OptionsColumn.AllowShowHide = False

                    End If

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode.ToString) IsNot Nothing Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode.ToString).Visible = False
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode.ToString).OptionsColumn.AllowShowHide = False

                    End If

                    If DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobServiceFeeTypeCode.ToString) IsNot Nothing Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobServiceFeeTypeCode.ToString).Visible = True
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobServiceFeeTypeCode.ToString).OptionsColumn.AllowShowHide = True
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobServiceFeeTypeCode.ToString).OptionsColumn.ShowInCustomizationForm = True
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobServiceFeeTypeCode.ToString).OptionsColumn.ShowInExpressionEditor = True
                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.JobServiceFeeTypeCode.ToString).Caption = "Service Fee Type"

                    End If

                End If

            End If

            DataGridViewForm_ServiceFees.CurrentView.BestFitColumns()

            LabelForm_StandardFeeVariance.Text = FormatCurrency(CDec(LabelForm_StandardFeeBilled.Text) - CDec(LabelForm_StandardFeeTimePosted.Text))
            LabelForm_ProductCommissionVariance.Text = FormatCurrency(CDec(LabelForm_ProductCommissionFeeBilled.Text) - CDec(LabelForm_ProductCommissionTimePosted.Text))
            LabelForm_MediaCommissionVariance.Text = FormatCurrency(CDec(LabelForm_MediaCommissionFeeBuild.Text) - CDec(LabelForm_MediaCommissionTimePosted.Text))

            LabelForm_TotalsFeeBilled.Text = FormatCurrency(CDec(LabelForm_MediaCommissionFeeBuild.Text) + CDec(LabelForm_ProductCommissionFeeBilled.Text) + CDec(LabelForm_StandardFeeBilled.Text))
            LabelForm_TotalsTimePosted.Text = FormatCurrency(CDec(LabelForm_MediaCommissionTimePosted.Text) + CDec(LabelForm_ProductCommissionTimePosted.Text) + CDec(LabelForm_StandardFeeTimePosted.Text))
            LabelForm_TotalsVariance.Text = FormatCurrency(CDec(LabelForm_MediaCommissionVariance.Text) + CDec(LabelForm_ProductCommissionVariance.Text) + CDec(LabelForm_StandardFeeVariance.Text))

            ProgressBarItemStatusBar_ProgressBar.Visible = False
            ProgressBarItemStatusBar_ProgressBar.Value = 0

            If _Index = 0 Then

                ButtonItemNavigation_First.Enabled = False
                ButtonItemNavigation_Previous.Enabled = False
                ButtonItemNavigation_Next.Enabled = (_Index <> _MaxIndex)
                ButtonItemNavigation_Last.Enabled = (_Index <> _MaxIndex)

            ElseIf _Index > 0 AndAlso _Index < _MaxIndex Then

                ButtonItemNavigation_First.Enabled = True
                ButtonItemNavigation_Previous.Enabled = True
                ButtonItemNavigation_Next.Enabled = True
                ButtonItemNavigation_Last.Enabled = True

            ElseIf _Index = _MaxIndex Then

                ButtonItemNavigation_First.Enabled = (_Index <> 0)
                ButtonItemNavigation_Previous.Enabled = (_Index <> 0)
                ButtonItemNavigation_Next.Enabled = False
                ButtonItemNavigation_Last.Enabled = False

            End If

            ButtonItemPrinting_PrintGrid.Enabled = True
            ButtonItemPrinting_PrintFullReport.Enabled = True
            ButtonItemPrinting_PrintSelectedReport.Enabled = True
            ButtonItemSystem_Close.Enabled = True
            DataGridViewForm_ServiceFees.Enabled = True

            _FirstAsyncCompleted = True

            Me.CloseWaitForm()

            Me.Refresh()

        End Sub
        Private Sub DataGridViewForm_ServiceFees_MasterRowEmptyEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles DataGridViewForm_ServiceFees.MasterRowEmptyEvent

            e.IsEmpty = False

        End Sub
        Private Sub DataGridViewForm_ServiceFees_MasterRowGetChildListEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles DataGridViewForm_ServiceFees.MasterRowGetChildListEvent

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim IsMaxIndex As Boolean = True

            If _Index < _MaxIndex Then

                IsMaxIndex = False

                If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                    Client = _ClientList(_Index)

                ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                    Division = _DivisionList(_Index)

                ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                    Product = _ProductList(_Index)

                End If

            End If

            e.ChildList = LoadDetailLevel(_ServiceFeeReconciliationSetting, _ServiceFeeReconciliationGroupByOption, _ServiceFeeReconciliationSummaryStyle, _ServiceFeeReconcileDetailList, IsMaxIndex, Client, Division, Product, e.RowHandle, e.RelationIndex, DataGridViewForm_ServiceFees.CurrentView)

        End Sub
        Private Sub DataGridViewForm_ServiceFees_MasterRowExpandedEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles DataGridViewForm_ServiceFees.MasterRowExpandedEvent

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            BaseView = DataGridViewForm_ServiceFees.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                If BaseView.ChildGridLevelName = "ServiceFeeDetailsLevel1Tab1" Then

                    Select Case e.RelationIndex

                        Case 0

                            AddHandler BaseView.CellValueChanging, AddressOf _GridViewServiceFeeDetailsLevel1Tab1_CellValueChanging

                        Case 1



                    End Select

                ElseIf BaseView.ChildGridLevelName = "ServiceFeeTypeLevel1" Then

                    If _FirstDetailAsyncCompleted = False Then

                        _FirstDetailAsyncCompleted = True

                        If BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString) IsNot Nothing Then

                            If BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString).DisplayFormat.FormatString = "n2"
                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeQuantity.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                            End If

                        End If

                        If BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString) IsNot Nothing Then

                            If BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString).DisplayFormat.FormatString = "n2"
                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.FeeAmount.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                            End If

                        End If

                        If BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString) IsNot Nothing Then

                            If BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString).DisplayFormat.FormatString = "n2"
                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledAmount.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                            End If

                        End If

                        If BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString) IsNot Nothing Then

                            If BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString).DisplayFormat.FormatString = "n2"
                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.ReconciledHours.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                            End If

                        End If

                        If BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString) IsNot Nothing Then

                            If BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString).DisplayFormat.FormatString = "n2"
                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledAmount.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                            End If

                        End If

                        If BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString) IsNot Nothing Then

                            If BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString).DisplayFormat.FormatString = "n2"
                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.UnreconciledHours.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                            End If

                        End If

                        If BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString) IsNot Nothing Then

                            If BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString).DisplayFormat.FormatString = "n2"
                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalHours.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                            End If

                        End If

                        If BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString) IsNot Nothing Then

                            If BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString).DisplayFormat.FormatString = "n2"
                                BaseView.Columns(AdvantageFramework.Database.Classes.ServiceFeeReconcile.Properties.TotalAmount.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                            End If

                        End If

                    End If

                End If

                BaseView.BestFitColumns()

            End If

        End Sub
        Private Sub DataGridViewForm_ServiceFees_MasterRowGetRelationCountEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles DataGridViewForm_ServiceFees.MasterRowGetRelationCountEvent

            e.RelationCount = 2

        End Sub
        Private Sub DataGridViewForm_ServiceFees_MasterRowGetRelationNameEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewForm_ServiceFees.MasterRowGetRelationNameEvent

            Select Case e.RelationIndex

                Case 0

                    e.RelationName = "ServiceFeeDetailsLevel1Tab1"

                Case 1

                    e.RelationName = "ServiceFeeDetailsLevel1Tab2"

            End Select

        End Sub
        Private Sub ButtonItemReport_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemReport_Save.Click

            If _ServiceFeeReconciliationReport IsNot Nothing Then

                SaveServiceFeeReconciliationReportTemplate()

            Else

                SaveAsServiceFeeReconciliationReportTemplate()

            End If

        End Sub
        Private Sub ButtonItemOptionsLeft_AutoSizeColumnsToPage_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsLeft_AutoSizeColumnsToPage.CheckedChanged

            DataGridViewForm_ServiceFees.OptionsPrint.AutoWidth = ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked

        End Sub
        Private Sub ButtonItemOptionsLeft_PrintFilterInfo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsLeft_PrintFilterInfo.CheckedChanged

            DataGridViewForm_ServiceFees.OptionsPrint.PrintFilterInfo = ButtonItemOptionsLeft_PrintFilterInfo.Checked

        End Sub
        Private Sub ButtonItemOptionsMiddle_PrintFooter_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsMiddle_PrintFooter.CheckedChanged

            DataGridViewForm_ServiceFees.OptionsPrint.PrintFooter = ButtonItemOptionsMiddle_PrintFooter.Checked

        End Sub
        Private Sub ButtonItemOptionsMiddle_PrintGroupFooter_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsMiddle_PrintGroupFooter.CheckedChanged

            DataGridViewForm_ServiceFees.OptionsPrint.PrintGroupFooter = ButtonItemOptionsMiddle_PrintGroupFooter.Checked

        End Sub
        Private Sub ButtonItemOptionsMiddle_PrintHeader_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsMiddle_PrintHeader.CheckedChanged

            DataGridViewForm_ServiceFees.OptionsPrint.PrintHeader = ButtonItemOptionsMiddle_PrintHeader.Checked

        End Sub
        Private Sub ButtonItemOptions_PrintSelectRowsOnly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsRight_PrintSelectedRowsOnly.CheckedChanged

            DataGridViewForm_ServiceFees.OptionsPrint.PrintSelectedRowsOnly = ButtonItemOptionsRight_PrintSelectedRowsOnly.Checked

        End Sub
        Private Sub ButtonItemViewLeft_AllowCellMerging_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemViewLeft_AllowCellMerging.CheckedChanged

            DataGridViewForm_ServiceFees.OptionsView.AllowCellMerge = ButtonItemViewLeft_AllowCellMerging.Checked

        End Sub
        Private Sub ButtonItemViewLeft_ShowViewCaption_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemViewLeft_ShowViewCaption.CheckedChanged

            DataGridViewForm_ServiceFees.OptionsView.ShowViewCaption = ButtonItemViewLeft_ShowViewCaption.Checked

        End Sub
        Private Sub ButtonItemViewLeft_ShowGroupByBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemViewLeft_ShowGroupByBox.CheckedChanged

            DataGridViewForm_ServiceFees.OptionsView.ShowGroupPanel = ButtonItemViewLeft_ShowGroupByBox.Checked

        End Sub
        Private Sub ButtonItemReport_LoadTemplate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemReport_LoadTemplate.Click

            'objects
            Dim SelectedServiceFeeReconciliationReports As IEnumerable = Nothing
            Dim ServiceFeeReconciliationReportID As Integer = 0

            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.ServiceFeeReconciliationReport, True, True, SelectedServiceFeeReconciliationReports) = Windows.Forms.DialogResult.OK Then

                If SelectedServiceFeeReconciliationReports IsNot Nothing Then

                    Try

                        ServiceFeeReconciliationReportID = (From Entity In SelectedServiceFeeReconciliationReports
                                                            Select Entity.ID).FirstOrDefault

                    Catch ex As Exception
                        ServiceFeeReconciliationReportID = 0
                    Finally

                        If ServiceFeeReconciliationReportID <> 0 Then

                            _FirstAsyncCompleted = False

                            LoadServiceFeeReconciliationReportTemplate(ServiceFeeReconciliationReportID, True)

                        End If

                    End Try

                End If

            End If

        End Sub
        Private Sub ButtonItemReport_Template_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemReport_Templates.Click

            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.ServiceFeeReconciliationReport, False, False, Nothing) = System.Windows.Forms.DialogResult.OK Then

                If _ServiceFeeReconciliationReport IsNot Nothing Then

                    LoadServiceFeeReconciliationReportTemplate(_ServiceFeeReconciliationReport.ID, False)

                End If

            End If

        End Sub
        Private Sub ButtonItemQuickCustomize_Columns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemQuickCustomize_Columns.Click

            'objects
            Dim MainGridViewColumnsList As Generic.List(Of AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn) = Nothing
            Dim SubGridViewTab1ColumnsList As Generic.List(Of AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn) = Nothing
            Dim SubGridViewTab2ColumnsList As Generic.List(Of AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn) = Nothing
            Dim ServiceFeeReconciliationReportColumn As AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            MainGridViewColumnsList = New Generic.List(Of AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn)

            For Each GridColumn In DataGridViewForm_ServiceFees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(Column) Column.OptionsColumn.AllowShowHide = True)

                ServiceFeeReconciliationReportColumn = New AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn

                ServiceFeeReconciliationReportColumn.FieldName = GridColumn.FieldName
                ServiceFeeReconciliationReportColumn.HeaderText = GridColumn.ToString
                ServiceFeeReconciliationReportColumn.IsVisible = GridColumn.Visible

                MainGridViewColumnsList.Add(ServiceFeeReconciliationReportColumn)

            Next

            SubGridViewTab1ColumnsList = New Generic.List(Of AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn)

            For Each GridColumn In _GridViewServiceFeeDetailsLevel1Tab1.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(Column) Column.OptionsColumn.AllowShowHide = True)

                ServiceFeeReconciliationReportColumn = New AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn

                ServiceFeeReconciliationReportColumn.FieldName = GridColumn.FieldName
                ServiceFeeReconciliationReportColumn.HeaderText = GridColumn.ToString
                ServiceFeeReconciliationReportColumn.IsVisible = GridColumn.Visible

                SubGridViewTab1ColumnsList.Add(ServiceFeeReconciliationReportColumn)

            Next

            SubGridViewTab2ColumnsList = New Generic.List(Of AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn)

            For Each GridColumn In _GridViewServiceFeeDetailsLevel1Tab2.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(Column) Column.OptionsColumn.AllowShowHide = True)

                ServiceFeeReconciliationReportColumn = New AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn

                ServiceFeeReconciliationReportColumn.FieldName = GridColumn.FieldName
                ServiceFeeReconciliationReportColumn.HeaderText = GridColumn.ToString
                ServiceFeeReconciliationReportColumn.IsVisible = GridColumn.Visible

                SubGridViewTab2ColumnsList.Add(ServiceFeeReconciliationReportColumn)

            Next

            If AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeReconciliationReportColumnEditDialog.ShowFormDialog(MainGridViewColumnsList, SubGridViewTab1ColumnsList, SubGridViewTab2ColumnsList) = Windows.Forms.DialogResult.OK Then

                For Each ServiceFeeReconciliationReportColumn In MainGridViewColumnsList

                    GridColumn = DataGridViewForm_ServiceFees.CurrentView.Columns(ServiceFeeReconciliationReportColumn.FieldName)

                    If GridColumn IsNot Nothing Then

                        GridColumn.Caption = ServiceFeeReconciliationReportColumn.HeaderText
                        GridColumn.Visible = ServiceFeeReconciliationReportColumn.IsVisible

                    End If

                Next

                For Each ServiceFeeReconciliationReportColumn In SubGridViewTab1ColumnsList

                    GridColumn = _GridViewServiceFeeDetailsLevel1Tab1.Columns(ServiceFeeReconciliationReportColumn.FieldName)

                    If GridColumn IsNot Nothing Then

                        GridColumn.Caption = ServiceFeeReconciliationReportColumn.HeaderText
                        GridColumn.Visible = ServiceFeeReconciliationReportColumn.IsVisible

                    End If

                Next

                For Each ServiceFeeReconciliationReportColumn In SubGridViewTab2ColumnsList

                    GridColumn = _GridViewServiceFeeDetailsLevel1Tab2.Columns(ServiceFeeReconciliationReportColumn.FieldName)

                    If GridColumn IsNot Nothing Then

                        GridColumn.Caption = ServiceFeeReconciliationReportColumn.HeaderText
                        GridColumn.Visible = ServiceFeeReconciliationReportColumn.IsVisible

                    End If

                Next

            End If

        End Sub
        Private Sub ButtonItemReport_SaveAs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemReport_SaveAs.Click

            SaveAsServiceFeeReconciliationReportTemplate()

        End Sub
        Private Sub ButtonItemFilter_ShowAutoFilterRow_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemFilter_ShowAutoFilterRow.CheckedChanged, ButtonItemFilter_ShowAutoFilterRow.CheckedChanged

            DataGridViewForm_ServiceFees.CurrentView.OptionsView.ShowAutoFilterRow = ButtonItemFilter_ShowAutoFilterRow.Checked

        End Sub
        Private Sub ButtonItemFilter_ShowFilterEditor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemFilter_ShowFilterEditor.Click

            If DataGridViewForm_ServiceFees.CurrentView.FocusedColumn IsNot Nothing AndAlso DataGridViewForm_ServiceFees.CurrentView.FocusedColumn.VisibleIndex <> -1 Then

                DataGridViewForm_ServiceFees.CurrentView.ShowFilterEditor(DataGridViewForm_ServiceFees.CurrentView.FocusedColumn)

            Else

                DataGridViewForm_ServiceFees.CurrentView.ShowFilterEditor(DataGridViewForm_ServiceFees.CurrentView.VisibleColumns(0))

            End If

        End Sub
        Private Sub ButtonItemReconcile_SelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemReconcile_SelectAll.Click

            SelectDeselectAll(True)

        End Sub
        Private Sub ButtonItemReconcile_Reconcile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemReconcile_Reconcile.Click

            Me.ShowWaitForm("Processing...")

            Try

                Reconciliation(1)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

			LoadReportData()

			Navigate(NavigationType.Refresh)

            ButtonItemReconcile_Reconcile.Enabled = False
            ButtonItemReconcile_Unreconcile.Enabled = False

        End Sub
        Private Sub ButtonItemReconcile_Unreconcile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemReconcile_Unreconcile.Click

            Me.ShowWaitForm("Processing...")

            Try

                Reconciliation(0)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

			LoadReportData()

			Navigate(NavigationType.Refresh)

            ButtonItemReconcile_Reconcile.Enabled = False
            ButtonItemReconcile_Unreconcile.Enabled = False

        End Sub
        Private Sub ButtonItemReconcile_DeselectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemReconcile_DeselectAll.Click

            SelectDeselectAll(False)

        End Sub
        Private Sub DataGridViewForm_ServiceFees_MasterRowGetRelationDisplayCaptionEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewForm_ServiceFees.MasterRowGetRelationDisplayCaptionEvent

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim RowCount As Integer = 0

            BaseView = DataGridViewForm_ServiceFees.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                RowCount = BaseView.RowCount

                Select Case e.RelationIndex

                    Case 0

                        e.RelationName = RowCount & " Time Detail(s)"

                    Case 1

                        e.RelationName = RowCount & " Fee Detail(s)"

                End Select

            Else

                Select Case e.RelationIndex

                    Case 0

                        e.RelationName = "Time Detail(s)"

                    Case 1

                        e.RelationName = "Fee Detail(s)"

                End Select

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace