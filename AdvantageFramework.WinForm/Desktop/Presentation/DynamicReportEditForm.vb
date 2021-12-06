Namespace Desktop.Presentation

    Public Class DynamicReportEditForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SelectedDynamicReport As AdvantageFramework.Reporting.DynamicReports = -1
        Private _DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
        Private _LoadDynamicReportTemplate As Boolean = False
        Private _FirstAsyncCompleted As Boolean = False
        Private _DynamicReportID As Integer = 0
        Private _Description As String = ""
        Private _UserDefinedReportCategoryID As Nullable(Of Integer) = Nothing
        Private _LoadReportDataOnInitialLoad As Boolean = False
        Private _ViewOnly As Boolean = True
        Private _ParameterDictionaryDrillDown As Generic.Dictionary(Of String, Object) = Nothing
        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal ViewOnly As Boolean, ByVal DynamicReportID As Integer, ByVal LoadReportData As Boolean)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _DynamicReportID = DynamicReportID
            _LoadReportDataOnInitialLoad = LoadReportData
            _ViewOnly = ViewOnly

        End Sub
        Private Sub ClearReportData()

            If _LoadDynamicReportTemplate = False Then

                If _DynamicReport IsNot Nothing Then

                    _DynamicReport = Nothing

                    Me.Text = "Report Writer"

                End If

            End If

            _SelectedDynamicReport = -1

            DataGridViewReport_Report.CurrentView.ClearSorting()
            DataGridViewReport_Report.CurrentView.ClearColumnsFilter()
            DataGridViewReport_Report.CurrentView.ClearGrouping()
            DataGridViewReport_Report.CurrentView.GroupSummary.Clear()

            DataGridViewReport_Report.DataSource = Nothing

            If DataGridViewReport_Report.Columns.Count > 0 Then

                DataGridViewReport_Report.Columns.Clear()

            End If

            If DashboardViewerDashboard_Dashboard.Dashboard IsNot Nothing Then

                DashboardViewerDashboard_Dashboard.Dashboard = Nothing

            End If

            SnapControlQuickText_Report.CreateNewDocument()

        End Sub
        Private Sub SaveDynamicReportTemplate()

            'objects
            Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing
            Dim DynamicReportSummaryItem As AdvantageFramework.Reporting.Database.Entities.DynamicReportSummaryItem = Nothing
            Dim DynamicReportUnboundColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportUnboundColumn = Nothing
            Dim DashboardLayout() As Byte = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim KeepSaving As Boolean = False

            DataGridViewReport_Report.CurrentView.BeginUpdate()

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _DynamicReport Is Nothing Then

                    _DynamicReport = New AdvantageFramework.Reporting.Database.Entities.DynamicReport

                End If

                _DynamicReport.Type = _SelectedDynamicReport
                _DynamicReport.Description = _Description
                _DynamicReport.UserDefinedReportCategoryID = _UserDefinedReportCategoryID
                _DynamicReport.AllowCellMerge = ButtonItemViewLeft_AllowCellMerging.Checked
                _DynamicReport.AutoSizeColumnsWhenPrinting = ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked
                _DynamicReport.PrintHeader = ButtonItemOptionsMiddle_PrintHeader.Checked
                _DynamicReport.PrintFooter = ButtonItemOptionsMiddle_PrintFooter.Checked
                _DynamicReport.PrintGroupFooter = ButtonItemOptionsMiddle_PrintGroupFooter.Checked
                _DynamicReport.PrintSelectedRowsOnly = ButtonItemOptionsRight_PrintSelectedRowsOnly.Checked
                _DynamicReport.PrintFilterInformation = ButtonItemOptionsLeft_PrintFilterInfo.Checked
                _DynamicReport.ShowGroupByBox = ButtonItemViewLeft_ShowGroupByBox.Checked
                _DynamicReport.ShowViewCaption = ButtonItemViewLeft_ShowViewCaption.Checked
                _DynamicReport.ShowAutoFilterRow = ButtonItemFilter_ShowAutoFilterRow.Checked
                _DynamicReport.ActiveFilter = DataGridViewReport_Report.CurrentView.AFActiveFilterString

                Try

                    MemoryStream = New System.IO.MemoryStream

                    If DashboardViewerDashboard_Dashboard.Dashboard IsNot Nothing Then

                        DashboardViewerDashboard_Dashboard.Dashboard.SaveToXml(MemoryStream)

                    End If

                    DashboardLayout = MemoryStream.ToArray

                Catch ex As Exception
                    DashboardLayout = Nothing
                End Try

                _DynamicReport.DashboardLayout = DashboardLayout

                If _DynamicReport.IsEntityBeingAdded() Then

                    _DynamicReport.CreatedByUserCode = Me.Session.UserCode
                    _DynamicReport.CreatedDate = Now

                    _DynamicReport.UpdatedByUserCode = Me.Session.UserCode
                    _DynamicReport.UpdatedDate = Now

                    KeepSaving = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Insert(ReportingDbContext, _DynamicReport)

                Else

                    _DynamicReport.UpdatedByUserCode = Me.Session.UserCode
                    _DynamicReport.UpdatedDate = Now

                    KeepSaving = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Update(ReportingDbContext, _DynamicReport)

                End If

                If KeepSaving Then

                    _DynamicReportID = _DynamicReport.ID

                    For Each GridColumn In DataGridViewReport_Report.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(GC) GC.UnboundType = DevExpress.Data.UnboundColumnType.Bound).ToList

                        DynamicReportColumn = AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.LoadByDynamicReportIDAndFieldName(ReportingDbContext, _DynamicReport.ID, GridColumn.FieldName)

                        If DynamicReportColumn IsNot Nothing Then

                            DynamicReportColumn.HeaderText = GridColumn.ToString
                            DynamicReportColumn.IsVisible = GridColumn.Visible
                            DynamicReportColumn.SortIndex = GridColumn.SortIndex
                            DynamicReportColumn.SortOrder = GridColumn.SortOrder
                            DynamicReportColumn.GroupIndex = GridColumn.GroupIndex
                            DynamicReportColumn.Width = GridColumn.Width
                            DynamicReportColumn.VisibleIndex = GridColumn.VisibleIndex

                            AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.Update(ReportingDbContext, DynamicReportColumn)

                        Else

                            AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.Insert(ReportingDbContext, _DynamicReport.ID, GridColumn.FieldName,
                                                                                              GridColumn.ToString, GridColumn.Visible, GridColumn.SortIndex,
                                                                                              GridColumn.SortOrder, GridColumn.GroupIndex, GridColumn.Width,
                                                                                              GridColumn.VisibleIndex, Nothing, Nothing)

                        End If

                    Next

                    For Each GridColumn In DataGridViewReport_Report.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(GC) GC.UnboundType <> DevExpress.Data.UnboundColumnType.Bound).ToList

                        DynamicReportUnboundColumn = AdvantageFramework.Reporting.Database.Procedures.DynamicReportUnboundColumn.LoadByDynamicReportIDAndFieldName(ReportingDbContext, _DynamicReport.ID, GridColumn.FieldName)

                        If DynamicReportUnboundColumn IsNot Nothing Then

                            DynamicReportUnboundColumn.HeaderText = GridColumn.ToString
                            DynamicReportUnboundColumn.IsVisible = GridColumn.Visible
                            DynamicReportUnboundColumn.SortIndex = GridColumn.SortIndex
                            DynamicReportUnboundColumn.SortOrder = GridColumn.SortOrder
                            DynamicReportUnboundColumn.GroupIndex = GridColumn.GroupIndex
                            DynamicReportUnboundColumn.Width = GridColumn.Width
                            DynamicReportUnboundColumn.VisibleIndex = GridColumn.VisibleIndex
                            DynamicReportUnboundColumn.UnboundType = GridColumn.UnboundType
                            DynamicReportUnboundColumn.Expression = GridColumn.UnboundExpression
                            DynamicReportUnboundColumn.Format = GridColumn.DisplayFormat.FormatString

                            AdvantageFramework.Reporting.Database.Procedures.DynamicReportUnboundColumn.Update(ReportingDbContext, DynamicReportUnboundColumn)

                        Else

                            AdvantageFramework.Reporting.Database.Procedures.DynamicReportUnboundColumn.Insert(ReportingDbContext, _DynamicReport.ID, GridColumn.FieldName,
                                                                                                    GridColumn.Caption, GridColumn.Visible, GridColumn.SortIndex,
                                                                                                    GridColumn.SortOrder, GridColumn.GroupIndex, GridColumn.Width,
                                                                                                    GridColumn.VisibleIndex, GridColumn.UnboundType, GridColumn.UnboundExpression,
                                                                                                    GridColumn.DisplayFormat.FormatString, Nothing)

                        End If

                    Next

                    For Each DynamicReportSummaryItem In AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.LoadByDynamicReportID(ReportingDbContext, _DynamicReport.ID).ToList

                        AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.Delete(ReportingDbContext, DynamicReportSummaryItem)

                    Next

                    For Each GridGroupSummaryItem In DataGridViewReport_Report.CurrentView.GroupSummary.OfType(Of DevExpress.XtraGrid.GridGroupSummaryItem)()

                        AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.Insert(ReportingDbContext, _DynamicReport.ID, GridGroupSummaryItem.SummaryType,
                                                                                                         GridGroupSummaryItem.FieldName,
                                                                                                         If(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, False, True),
                                                                                                         GridGroupSummaryItem.DisplayFormat,
                                                                                                         If(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, "", GridGroupSummaryItem.ShowInGroupColumnFooter.FieldName),
                                                                                                         Nothing)

                    Next

                    For Each GridColumn In DataGridViewReport_Report.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                        If GridColumn.SummaryItem IsNot Nothing AndAlso GridColumn.SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.None Then

                            AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.Insert(ReportingDbContext, _DynamicReport.ID, GridColumn.SummaryItem.SummaryType,
                                                                                                             GridColumn.FieldName, False,
                                                                                                             GridColumn.SummaryItem.DisplayFormat, GridColumn.SummaryItem.FieldName,
                                                                                                             Nothing)

                        End If

                    Next

                    Me.Text = "Report Writer - " & _DynamicReport.Description

                End If

            End Using

            DataGridViewReport_Report.CurrentView.EndUpdate()

            EnableOrDisableActions()

        End Sub
        Private Sub SaveAsDynamicReportTemplate()

            'objects
            Dim UserDefinedReportCategoryID As Nullable(Of Integer) = 0
            Dim DashboardLayout() As Byte = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            If AdvantageFramework.Desktop.Presentation.UserDefinedReportEditDialog.ShowFormDialog(Reporting.UDRTypes.Dynamic, 0, _SelectedDynamicReport, _Description, UserDefinedReportCategoryID, False) = System.Windows.Forms.DialogResult.OK Then

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        MemoryStream = New System.IO.MemoryStream

                        If DashboardViewerDashboard_Dashboard.Dashboard IsNot Nothing Then

                            DashboardViewerDashboard_Dashboard.Dashboard.SaveToXml(MemoryStream)

                        End If

                        DashboardLayout = MemoryStream.ToArray

                    Catch ex As Exception
                        DashboardLayout = Nothing
                    End Try

                    If AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Insert(ReportingDbContext, _SelectedDynamicReport, _Description, ReportingDbContext.UserCode, Now,
                                                                                   ButtonItemViewLeft_AllowCellMerging.Checked, ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked,
                                                                                   ButtonItemOptionsMiddle_PrintHeader.Checked, ButtonItemOptionsMiddle_PrintFooter.Checked,
                                                                                   ButtonItemOptionsMiddle_PrintGroupFooter.Checked, ButtonItemOptionsRight_PrintSelectedRowsOnly.Checked,
                                                                                   ButtonItemOptionsLeft_PrintFilterInfo.Checked, ButtonItemFilter_ShowAutoFilterRow.Checked,
                                                                                   DataGridViewReport_Report.CurrentView.AFActiveFilterString, ButtonItemViewLeft_ShowGroupByBox.Checked,
                                                                                   ButtonItemViewLeft_ShowViewCaption.Checked, UserDefinedReportCategoryID, DashboardLayout, Nothing, _DynamicReport) Then

                        _DynamicReportID = _DynamicReport.ID

                        For Each GridColumn In DataGridViewReport_Report.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(GC) GC.UnboundType = DevExpress.Data.UnboundColumnType.Bound).ToList

                            AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.Insert(ReportingDbContext, _DynamicReport.ID, GridColumn.FieldName,
                                                                                              GridColumn.Caption, GridColumn.Visible, GridColumn.SortIndex,
                                                                                              GridColumn.SortOrder, GridColumn.GroupIndex, GridColumn.Width,
                                                                                              GridColumn.VisibleIndex, Nothing, Nothing)

                        Next

                        For Each GridColumn In DataGridViewReport_Report.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(GC) GC.UnboundType <> DevExpress.Data.UnboundColumnType.Bound).ToList

                            AdvantageFramework.Reporting.Database.Procedures.DynamicReportUnboundColumn.Insert(ReportingDbContext, _DynamicReport.ID, GridColumn.FieldName,
                                                                                                    GridColumn.Caption, GridColumn.Visible, GridColumn.SortIndex,
                                                                                                    GridColumn.SortOrder, GridColumn.GroupIndex, GridColumn.Width,
                                                                                                    GridColumn.VisibleIndex, GridColumn.UnboundType, GridColumn.UnboundExpression,
                                                                                                    GridColumn.DisplayFormat.FormatString, Nothing)

                        Next

                        For Each GridGroupSummaryItem In DataGridViewReport_Report.CurrentView.GroupSummary.OfType(Of DevExpress.XtraGrid.GridGroupSummaryItem)()

                            AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.Insert(ReportingDbContext, _DynamicReport.ID, GridGroupSummaryItem.SummaryType,
                                                                                                             GridGroupSummaryItem.FieldName,
                                                                                                             If(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, False, True),
                                                                                                             GridGroupSummaryItem.DisplayFormat,
                                                                                                             If(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, "", GridGroupSummaryItem.ShowInGroupColumnFooter.FieldName),
                                                                                                             Nothing)

                        Next

                        For Each GridColumn In DataGridViewReport_Report.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                            If GridColumn.SummaryItem IsNot Nothing AndAlso GridColumn.SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.None Then

                                AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.Insert(ReportingDbContext, _DynamicReport.ID, GridColumn.SummaryItem.SummaryType,
                                                                                                                 GridColumn.FieldName, False,
                                                                                                                 GridColumn.SummaryItem.DisplayFormat, GridColumn.SummaryItem.FieldName,
                                                                                                                 Nothing)

                            End If

                        Next

                        Me.Text = "Report Writer - " & _DynamicReport.Description

                        EnableOrDisableActions()

                    End If

                End Using

            End If

        End Sub
        Private Sub LoadDynamicReportTemplate(ByVal DynamicReportID As Integer, ByVal RefreshTemplate As Boolean)

            'objects
            Dim SelectedDynamicReports As IEnumerable = Nothing
            Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    _DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, DynamicReportID)

                Catch ex As Exception
                    _DynamicReport = Nothing
                End Try

                If _DynamicReport IsNot Nothing Then

                    If RefreshTemplate Then

                        _LoadDynamicReportTemplate = True
                        _FirstAsyncCompleted = False

                        ComboBoxItemReport_DynamicReport.SelectedIndex = 0

                        ComboBoxItemReport_DynamicReport.SelectedItem = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Reporting.DynamicReports), _DynamicReport.Type)

                        _Description = _DynamicReport.Description
                        _UserDefinedReportCategoryID = _DynamicReport.UserDefinedReportCategoryID

                        ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked = _DynamicReport.AutoSizeColumnsWhenPrinting
                        ButtonItemOptionsLeft_PrintFilterInfo.Checked = _DynamicReport.PrintFilterInformation
                        ButtonItemOptionsMiddle_PrintFooter.Checked = _DynamicReport.PrintFooter
                        ButtonItemOptionsMiddle_PrintGroupFooter.Checked = _DynamicReport.PrintGroupFooter
                        ButtonItemOptionsMiddle_PrintHeader.Checked = _DynamicReport.PrintHeader
                        ButtonItemOptionsRight_PrintSelectedRowsOnly.Checked = _DynamicReport.PrintSelectedRowsOnly
                        ButtonItemViewLeft_AllowCellMerging.Checked = _DynamicReport.AllowCellMerge
                        ButtonItemViewLeft_ShowGroupByBox.Checked = _DynamicReport.ShowGroupByBox
                        ButtonItemViewLeft_ShowViewCaption.Checked = _DynamicReport.ShowViewCaption
                        ButtonItemFilter_ShowAutoFilterRow.Checked = _DynamicReport.ShowAutoFilterRow

                        Me.Text = "Report Writer - " & _DynamicReport.Description

                        If _DynamicReport.DashboardLayout IsNot Nothing AndAlso _DynamicReport.DashboardLayout.Length > 0 Then

                            If MemoryStream IsNot Nothing Then

                                Try

                                    MemoryStream.Dispose()

                                    MemoryStream = Nothing

                                Catch ex As Exception
                                    MemoryStream = Nothing
                                End Try

                            End If

                            MemoryStream = New System.IO.MemoryStream(_DynamicReport.DashboardLayout)

                            Try
                                DashboardViewerDashboard_Dashboard.LoadDashboard(MemoryStream)
                            Catch ex As Exception

                            End Try

                            LoadDashboard()

                            LoadQuickText()

                        End If

                        _LoadDynamicReportTemplate = False

                    End If

                Else

                    Me.Text = "Report Writer"

                End If

            End Using

        End Sub
        Private Sub LoadDynamicReportTemplateColumnDetails()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim GridGroupSummaryItem As DevExpress.XtraGrid.GridGroupSummaryItem = Nothing
            Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing
            Dim DynamicReportColumns As Generic.List(Of AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn) = Nothing
            Dim GridColumnSummaryItem As DevExpress.XtraGrid.GridColumnSummaryItem = Nothing

            If _DynamicReport IsNot Nothing AndAlso _FirstAsyncCompleted = False Then

                _FirstAsyncCompleted = True

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DynamicReportColumns = AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.LoadByDynamicReportID(ReportingDbContext, _DynamicReport.ID).ToList

                    For Each DynamicReportColumn In DynamicReportColumns.Where(Function(Entity) Entity.IsVisible = False AndAlso Entity.GroupIndex = -1).ToList

                        GridColumn = DataGridViewReport_Report.Columns(DynamicReportColumn.FieldName)

                        If GridColumn IsNot Nothing Then

                            GridColumn.Caption = DynamicReportColumn.HeaderText
                            GridColumn.Visible = DynamicReportColumn.IsVisible
                            GridColumn.SortIndex = DynamicReportColumn.SortIndex
                            GridColumn.SortOrder = DynamicReportColumn.SortOrder
                            GridColumn.GroupIndex = DynamicReportColumn.GroupIndex
                            GridColumn.Width = DynamicReportColumn.Width
                            'GridColumn.VisibleIndex = DynamicReportColumn.VisibleIndex

                        End If

                    Next

                    For Each DynamicReportColumn In DynamicReportColumns.Where(Function(Entity) Entity.GroupIndex > -1).OrderBy(Function(Column) Column.GroupIndex).ToList

                        GridColumn = DataGridViewReport_Report.Columns(DynamicReportColumn.FieldName)

                        If GridColumn IsNot Nothing Then

                            GridColumn.Caption = DynamicReportColumn.HeaderText
                            GridColumn.SortIndex = DynamicReportColumn.SortIndex
                            GridColumn.SortOrder = DynamicReportColumn.SortOrder
                            GridColumn.GroupIndex = DynamicReportColumn.GroupIndex
                            GridColumn.Width = DynamicReportColumn.Width

                        End If

                    Next

                    For Each DynamicReportColumn In DynamicReportColumns.Where(Function(Entity) Entity.IsVisible = True AndAlso Entity.GroupIndex = -1).OrderBy(Function(Column) Column.VisibleIndex).ToList

                        GridColumn = DataGridViewReport_Report.Columns(DynamicReportColumn.FieldName)

                        If GridColumn IsNot Nothing Then

                            GridColumn.Caption = DynamicReportColumn.HeaderText
                            GridColumn.SortIndex = DynamicReportColumn.SortIndex
                            GridColumn.SortOrder = DynamicReportColumn.SortOrder
                            GridColumn.GroupIndex = DynamicReportColumn.GroupIndex
                            GridColumn.Width = DynamicReportColumn.Width
                            GridColumn.VisibleIndex = DynamicReportColumn.VisibleIndex

                        End If

                    Next

                    For Each GridColumn In DataGridViewReport_Report.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(GC) GC.UnboundType = DevExpress.Data.UnboundColumnType.Bound).ToList

                        If DynamicReportColumns.Any(Function(Entity) Entity.FieldName = GridColumn.FieldName) = False Then

                            GridColumn.Visible = False

                        End If

                    Next

                    For Each DynamicReportUnboundColumn In AdvantageFramework.Reporting.Database.Procedures.DynamicReportUnboundColumn.LoadByDynamicReportID(ReportingDbContext, _DynamicReport.ID).OrderBy(Function(Column) Column.VisibleIndex).ToList

                        GridColumn = DataGridViewReport_Report.Columns.AddField(DynamicReportUnboundColumn.FieldName)

                        GridColumn.ShowUnboundExpressionMenu = True

                        GridColumn.VisibleIndex = DataGridViewReport_Report.Columns.Count

                        GridColumn.Caption = DynamicReportUnboundColumn.HeaderText
                        GridColumn.Visible = DynamicReportUnboundColumn.IsVisible
                        GridColumn.SortIndex = DynamicReportUnboundColumn.SortIndex
                        GridColumn.SortOrder = DynamicReportUnboundColumn.SortOrder
                        GridColumn.GroupIndex = DynamicReportUnboundColumn.GroupIndex
                        GridColumn.Width = DynamicReportUnboundColumn.Width
                        GridColumn.VisibleIndex = DynamicReportUnboundColumn.VisibleIndex
                        GridColumn.UnboundType = DynamicReportUnboundColumn.UnboundType
                        GridColumn.UnboundExpression = DynamicReportUnboundColumn.Expression

                        If String.IsNullOrEmpty(DynamicReportUnboundColumn.Format) = False Then

                            If GridColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal Then

                                GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                GridColumn.DisplayFormat.FormatString = DynamicReportUnboundColumn.Format

                            End If

                        End If

                        GridColumn.VisibleIndex = DynamicReportUnboundColumn.VisibleIndex

                    Next

                    For Each DynamicReportSummaryItem In AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.LoadByDynamicReportID(ReportingDbContext, _DynamicReport.ID).ToList

                        If DynamicReportSummaryItem.OnFooter = False AndAlso String.IsNullOrWhiteSpace(DynamicReportSummaryItem.ColumnName) = False Then

                            GridColumn = DataGridViewReport_Report.Columns(DynamicReportSummaryItem.FieldName)

                            If GridColumn IsNot Nothing Then

                                GridColumn.SummaryItem.FieldName = DynamicReportSummaryItem.ColumnName
                                GridColumn.SummaryItem.SummaryType = DynamicReportSummaryItem.SummaryItemType
                                GridColumn.SummaryItem.DisplayFormat = DynamicReportSummaryItem.DisplayFormat

                            End If

                        Else

                            If DynamicReportSummaryItem.OnFooter Then

                                If DataGridViewReport_Report.Columns(DynamicReportSummaryItem.ColumnName) IsNot Nothing Then

                                    DataGridViewReport_Report.CurrentView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DynamicReportSummaryItem.SummaryItemType,
                                                                                                                                                                                        DynamicReportSummaryItem.FieldName,
                                                                                                                                                                                        DataGridViewReport_Report.Columns(DynamicReportSummaryItem.ColumnName),
                                                                                                                                                                                        DynamicReportSummaryItem.DisplayFormat)})

                                End If

                            Else

                                DataGridViewReport_Report.CurrentView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DynamicReportSummaryItem.SummaryItemType,
                                                                                                                                                                                        DynamicReportSummaryItem.FieldName,
                                                                                                                                                                                        Nothing,
                                                                                                                                                                                        DynamicReportSummaryItem.DisplayFormat)})

                            End If

                        End If

                    Next

                End Using

            End If

        End Sub
        Private Sub LoadDashboard()

            If DashboardViewerDashboard_Dashboard.Dashboard IsNot Nothing Then

                If DashboardViewerDashboard_Dashboard.Dashboard.DataSources.Count = 0 Then

                    DashboardViewerDashboard_Dashboard.Dashboard.DataSources.Add(New DevExpress.DashboardCommon.DashboardObjectDataSource(GetLoadedDataSource))

                Else

                    DashboardViewerDashboard_Dashboard.Dashboard.DataSources(0).Data = GetLoadedDataSource()

                End If

                CType(DashboardViewerDashboard_Dashboard.Dashboard.DataSources(0), DevExpress.DashboardCommon.DashboardObjectDataSource).Filter = DataGridViewReport_Report.CurrentView.ActiveFilterString

                Try

                    CType(DashboardViewerDashboard_Dashboard.Dashboard.DataSources(0), DevExpress.DashboardCommon.DashboardObjectDataSource).Fill()

                Catch ex As Exception

                    CType(DashboardViewerDashboard_Dashboard.Dashboard.DataSources(0), DevExpress.DashboardCommon.DashboardObjectDataSource).Filter = Nothing

                    CType(DashboardViewerDashboard_Dashboard.Dashboard.DataSources(0), DevExpress.DashboardCommon.DashboardObjectDataSource).Fill()

                End Try

                DashboardViewerDashboard_Dashboard.Refresh()

            End If

        End Sub
        Public Sub LoadQuickText()

            If SnapControlQuickText_Report.Document IsNot Nothing Then

                SnapControlQuickText_Report.Document.DataSource = GetLoadedDataSource()

                SnapControlQuickText_Report.Refresh()

            End If

        End Sub
        Private Function GetLoadedDataSource() As Object

            'objects
            Dim DataSource As Object = Nothing

            'Try

            '	DataSource = DirectCast(DataGridViewReport_Report.DataSource, System.Windows.Forms.BindingSource).DataSource

            'Catch ex As Exception

            'End Try

            If DataSource Is Nothing Then

                DataSource = DataGridViewReport_Report.DataSource

            End If

            GetLoadedDataSource = DataSource

        End Function
        Private Sub EnableOrDisableActions()

            Select Case _SelectedDynamicReport

                Case AdvantageFramework.Reporting.DynamicReports.Employees, AdvantageFramework.Reporting.DynamicReports.GeneralLedgerDetail, AdvantageFramework.Reporting.DynamicReports.DirectIndirectTime,
                     AdvantageFramework.Reporting.DynamicReports.JobDetail, AdvantageFramework.Reporting.DynamicReports.JobDetailItem, AdvantageFramework.Reporting.DynamicReports.JobDetailFunction,
                     AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth, AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByFunctionMinimized,
                     AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob1Minimized, AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob2Minimized,
                     AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatus, AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatusCoopBreakout, AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatusSummary,
                     AdvantageFramework.Reporting.DynamicReports.VirtualCreditCardTransactionEFS

                    ButtonItemReport_Schedule.Enabled = (_DynamicReportID <> 0)

                Case Else

                    ButtonItemReport_Schedule.Enabled = False

            End Select

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(ByVal ViewOnly As Boolean, Optional ByVal DynamicReportID As Integer = 0, Optional ByVal LoadReportData As Boolean = False)

            'objects
            Dim DynamicReportEditForm As DynamicReportEditForm = Nothing

            DynamicReportEditForm = New DynamicReportEditForm(ViewOnly, DynamicReportID, LoadReportData)

            DynamicReportEditForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub DynamicReportEditForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemPrinting_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemReport_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemReport_SaveAs.Image = AdvantageFramework.My.Resources.SaveAsImage
            ButtonItemReport_LoadTemplate.Image = AdvantageFramework.My.Resources.DynamicReportImage
            ButtonItemReport_Templates.Image = AdvantageFramework.My.Resources.BlankDynamicReportImage
            ButtonItemQuickCustomize_Columns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemData_Load.Image = AdvantageFramework.My.Resources.DatabaseLoadImage
            ButtonItemDashboard_Edit.Image = My.Resources.DynamicReportImage
            ButtonItemQuickText_Edit.Image = My.Resources.ClientBudgetImage
            ButtonItemUnboundColumns_Add.Image = My.Resources.ColumnAddImage
            ButtonItemHeaderFooterImages_Manage.Image = My.Resources.ImagesImage
            ButtonItemReport_Schedule.Image = My.Resources.BroadcastCalendarMonthImage
            ButtonItemDataset_Refresh.Image = My.Resources.RefreshImage

            For Each KeyValuePair In AdvantageFramework.Reporting.LoadAvailableDynamicReportDataSets(Me.Session)

                ComboBoxItemReport_DynamicReport.Items.Add(KeyValuePair.Value)

            Next

            ComboBoxItemReport_DynamicReport.Items.Insert(0, "[Please select]")

            ComboBoxItemReport_DynamicReport.SelectedIndex = 0

            DataGridViewReport_Report.OptionsPrint.AutoWidth = False
            DataGridViewReport_Report.OptionsView.ShowFooter = True
            DataGridViewReport_Report.OptionsView.EnableAppearanceEvenRow = True
            DataGridViewReport_Report.OptionsPrint.EnableAppearanceEvenRow = True
            DataGridViewReport_Report.CurrentView.Appearance.EvenRow.BackColor = System.Drawing.Color.WhiteSmoke
            DataGridViewReport_Report.CurrentView.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.WhiteSmoke
            DataGridViewReport_Report.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleIfExpanded

            ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked = DataGridViewReport_Report.OptionsPrint.AutoWidth
            ButtonItemOptionsLeft_PrintFilterInfo.Checked = DataGridViewReport_Report.OptionsPrint.PrintFilterInfo
            ButtonItemOptionsMiddle_PrintFooter.Checked = DataGridViewReport_Report.OptionsPrint.PrintFooter
            ButtonItemOptionsMiddle_PrintGroupFooter.Checked = DataGridViewReport_Report.OptionsPrint.PrintGroupFooter
            ButtonItemOptionsMiddle_PrintHeader.Checked = DataGridViewReport_Report.OptionsPrint.PrintHeader
            ButtonItemOptionsRight_PrintSelectedRowsOnly.Checked = DataGridViewReport_Report.OptionsPrint.PrintSelectedRowsOnly
            ButtonItemViewLeft_AllowCellMerging.Checked = DataGridViewReport_Report.OptionsView.AllowCellMerge
            ButtonItemViewLeft_ShowGroupByBox.Checked = DataGridViewReport_Report.OptionsView.ShowGroupPanel
            ButtonItemViewLeft_ShowViewCaption.Checked = DataGridViewReport_Report.OptionsView.ShowViewCaption
            ButtonItemFilter_ShowAutoFilterRow.Checked = DataGridViewReport_Report.OptionsView.ShowAutoFilterRow

            TabControlForm_Report.SelectedTab = TabItemReport_ReportTab

            ButtonItemReport_Save.SecurityEnabled = Not _ViewOnly
            ButtonItemReport_SaveAs.SecurityEnabled = Not _ViewOnly
            ButtonItemQuickCustomize_Columns.SecurityEnabled = Not _ViewOnly
            ButtonItemUnboundColumns_Add.SecurityEnabled = Not _ViewOnly
            ButtonItemDashboard_Edit.SecurityEnabled = Not _ViewOnly
            ButtonItemQuickText_Edit.SecurityEnabled = Not _ViewOnly
            ButtonItemReport_LoadTemplate.SecurityEnabled = Not _ViewOnly
            ButtonItemReport_Templates.SecurityEnabled = Not _ViewOnly

            If DashboardViewerDashboard_Dashboard.Dashboard Is Nothing Then

                DashboardViewerDashboard_Dashboard.Dashboard = New DevExpress.DashboardCommon.Dashboard

            End If

            ButtonItemDataset_Refresh.Visible = False
            RibbonBarOptions_Refresh.Visible = False
            LabelItemDataset_LastUpdated.Visible = False

            DashboardViewerDashboard_Dashboard.Refresh()

        End Sub
        Private Sub DynamicReportEditForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            'objects
            Dim RibbonControl As DevComponents.DotNetBar.RibbonControl = Nothing
            Dim DynamicReportDataset As AdvantageFramework.Reporting.Database.Entities.DynamicReportDataset = Nothing
            Dim Message As String = String.Empty

            ClearReportData()

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

            EnableOrDisableActions()

            If _DynamicReportID > 0 Then

                LoadDynamicReportTemplate(_DynamicReportID, True)

                If _LoadReportDataOnInitialLoad Then

                    'If _SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailItem OrElse
                    '       _SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetail OrElse
                    '       _SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction OrElse
                    '       _SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth Then

                    '    Using ReportDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    '        DynamicReportDataset = AdvantageFramework.Reporting.Database.Procedures.DynamicReportDataset.LoadByDynamicReportType(ReportDbContext, _SelectedDynamicReport)

                    '    End Using

                    '    If DynamicReportDataset IsNot Nothing AndAlso DynamicReportDataset.LastUpdated.HasValue Then

                    '        Message = "Report Data Last Updated on " & DynamicReportDataset.LastUpdated.Value.ToShortDateString & " " & DynamicReportDataset.LastUpdated.Value.ToShortTimeString

                    '    Else

                    '        Message = "Report Data has not been updated"

                    '    End If

                    '    Message &= System.Environment.NewLine & " Do you want to update report data now?"

                    '    If AdvantageFramework.WinForm.MessageBox.Show(Message, WinForm.MessageBox.MessageBoxButtons.YesNo, "Refresh?") = WinForm.MessageBox.DialogResults.Yes Then

                    '        ButtonItemDataset_Refresh.Visible = True
                    '        RibbonBarOptions_Refresh.Visible = True
                    '        ButtonItemDataset_Refresh.RaiseClick()

                    '    End If

                    'End If

                    Me.FormAction = WinForm.Presentation.FormActions.Loading

                    ButtonItemData_Load.RaiseClick()

                    Me.FormAction = WinForm.Presentation.FormActions.None

                End If

            Else

                If AdvantageFramework.Desktop.Presentation.UserDefinedReportEditDialog.ShowFormDialog(Reporting.UDRTypes.Dynamic, 0, _SelectedDynamicReport, _Description, _UserDefinedReportCategoryID, True) = Windows.Forms.DialogResult.OK Then

                    Try

                        If _SelectedDynamicReport <> Nothing Then

                            ComboBoxItemReport_DynamicReport.SelectedItem = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Reporting.DynamicReports), _SelectedDynamicReport)

                        End If

                        Me.Text = "Report Writer - " & _Description

                    Catch ex As Exception

                    End Try

                Else

                    Me.Close()

                End If

            End If

            'If _SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailItem OrElse
            '       _SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetail OrElse
            '       _SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction OrElse
            '       _SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth Then

            '    ButtonItemDataset_Refresh.Visible = True
            '    RibbonBarOptions_Refresh.Visible = True
            '    LabelItemDataset_LastUpdated.Visible = True

            '    Using ReportDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            '        DynamicReportDataset = AdvantageFramework.Reporting.Database.Procedures.DynamicReportDataset.LoadByDynamicReportType(ReportDbContext, _SelectedDynamicReport)

            '    End Using

            '    If DynamicReportDataset IsNot Nothing AndAlso DynamicReportDataset.LastUpdated.HasValue Then

            '        LabelItemDataset_LastUpdated.Text = "Data Last Updated on " & DynamicReportDataset.LastUpdated.Value.ToShortDateString & " " & DynamicReportDataset.LastUpdated.Value.ToShortTimeString

            '    Else

            '        LabelItemDataset_LastUpdated.Text = "Has not been updated"

            '    End If

            '    RibbonBarOptions_Refresh.ResetCachedContentSize()

            '    RibbonBarOptions_Refresh.Refresh()

            '    RibbonBarOptions_Refresh.Width = RibbonBarOptions_Refresh.GetAutoSizeWidth

            '    RibbonBarOptions_Refresh.Refresh()

            'Else

            '    ButtonItemDataset_Refresh.Visible = False
            '    RibbonBarOptions_Refresh.Visible = False
            '    LabelItemDataset_LastUpdated.Visible = False

            'End If

            ButtonItemDataset_Refresh.Visible = False
            RibbonBarOptions_Refresh.Visible = False
            LabelItemDataset_LastUpdated.Visible = False

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemPrinting_Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemPrinting_Print.Click

            'objects
            Dim ImagesList As Generic.List(Of System.Drawing.Image) = Nothing
            Dim Image As System.Drawing.Image = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            ImagesList = New Generic.List(Of System.Drawing.Image)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each ImageEntity In AdvantageFramework.Database.Procedures.Image.Load(DbContext).ToList

                    MemoryStream = New System.IO.MemoryStream(ImageEntity.Bytes)

                    ImagesList.Add(System.Drawing.Image.FromStream(MemoryStream))

                    Try

                        MemoryStream.Close()
                        MemoryStream.Dispose()

                        MemoryStream = Nothing

                    Catch ex As Exception
                        MemoryStream = Nothing
                    End Try

                Next

            End Using

            DataGridViewReport_Report.Print(DefaultLookAndFeel.LookAndFeel, _Description, ImagesList.ToArray)

        End Sub
        Private Sub ButtonItemReport_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemReport_Save.Click

            If _SelectedDynamicReport > -1 Then

                SaveDynamicReportTemplate()

            End If

        End Sub
        Private Sub ComboBoxItemReport_DynamicReport_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxItemReport_DynamicReport.SelectedIndexChanged

            'objects
            Dim DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing

            ClearReportData()

            If ComboBoxItemReport_DynamicReport.SelectedIndex > 0 Then

                If AdvantageFramework.EnumUtilities.IsMemberOfEnum(GetType(AdvantageFramework.Reporting.DynamicReports), CInt(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.DynamicReports), ComboBoxItemReport_DynamicReport.SelectedItem))) Then

                    _SelectedDynamicReport = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.DynamicReports), ComboBoxItemReport_DynamicReport.SelectedItem)

                    DataGridViewReport_Report.CurrentView.BeginUpdate()

                    DataGridViewReport_Report.ItemDescription = ""

                    DataGridViewReport_Report.DataSource = AdvantageFramework.Reporting.LoadDynamicReportData(Nothing, Nothing, _SelectedDynamicReport, True, Nothing, "", Nothing, Nothing, False, Nothing, Nothing)

                    ButtonItemReport_Save.Enabled = True
                    ButtonItemReport_SaveAs.Enabled = True

                    If _LoadDynamicReportTemplate Then

                        LoadDynamicReportTemplateColumnDetails()

                        'DataGridViewReport_Report.DataSource = AdvantageFramework.Reporting.LoadDynamicReportData(Nothing, _SelectedDynamicReport, True, Nothing, "", Nothing, Nothing, False, Nothing)

                        DataGridViewReport_Report.CurrentView.AFActiveFilterString = _DynamicReport.ActiveFilter

                    End If

                    DataGridViewReport_Report.CurrentView.EndUpdate()

                    LoadDashboard()

                    LoadQuickText()

                Else

                    ButtonItemReport_Save.Enabled = False
                    ButtonItemReport_SaveAs.Enabled = False

                End If

            Else

                ButtonItemReport_Save.Enabled = False
                ButtonItemReport_SaveAs.Enabled = False

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemOptionsLeft_AutoSizeColumnsToPage_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsLeft_AutoSizeColumnsToPage.CheckedChanged

            DataGridViewReport_Report.OptionsPrint.AutoWidth = ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked

        End Sub
        Private Sub ButtonItemOptionsLeft_PrintFilterInfo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsLeft_PrintFilterInfo.CheckedChanged

            DataGridViewReport_Report.OptionsPrint.PrintFilterInfo = ButtonItemOptionsLeft_PrintFilterInfo.Checked

        End Sub
        Private Sub ButtonItemOptionsMiddle_PrintFooter_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsMiddle_PrintFooter.CheckedChanged

            DataGridViewReport_Report.OptionsPrint.PrintFooter = ButtonItemOptionsMiddle_PrintFooter.Checked

        End Sub
        Private Sub ButtonItemOptionsMiddle_PrintGroupFooter_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsMiddle_PrintGroupFooter.CheckedChanged

            DataGridViewReport_Report.OptionsPrint.PrintGroupFooter = ButtonItemOptionsMiddle_PrintGroupFooter.Checked

        End Sub
        Private Sub ButtonItemOptionsMiddle_PrintHeader_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsMiddle_PrintHeader.CheckedChanged

            DataGridViewReport_Report.OptionsPrint.PrintHeader = ButtonItemOptionsMiddle_PrintHeader.Checked

        End Sub
        Private Sub ButtonItemOptions_PrintSelectRowsOnly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsRight_PrintSelectedRowsOnly.CheckedChanged

            DataGridViewReport_Report.OptionsPrint.PrintSelectedRowsOnly = ButtonItemOptionsRight_PrintSelectedRowsOnly.Checked

        End Sub
        Private Sub ButtonItemViewLeft_AllowCellMerging_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemViewLeft_AllowCellMerging.CheckedChanged

            DataGridViewReport_Report.OptionsView.AllowCellMerge = ButtonItemViewLeft_AllowCellMerging.Checked

        End Sub
        Private Sub ButtonItemViewLeft_ShowViewCaption_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemViewLeft_ShowViewCaption.CheckedChanged

            DataGridViewReport_Report.OptionsView.ShowViewCaption = ButtonItemViewLeft_ShowViewCaption.Checked

        End Sub
        Private Sub ButtonItemViewLeft_ShowGroupByBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemViewLeft_ShowGroupByBox.CheckedChanged

            DataGridViewReport_Report.OptionsView.ShowGroupPanel = ButtonItemViewLeft_ShowGroupByBox.Checked

        End Sub
        Private Sub ButtonItemReport_LoadTemplate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemReport_LoadTemplate.Click

            'objects
            Dim SelectedDynamicReports As IEnumerable = Nothing
            Dim DynamicReportID As Integer = 0
            Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.DynamicReport, True, True, SelectedDynamicReports) = Windows.Forms.DialogResult.OK Then

                    If SelectedDynamicReports IsNot Nothing Then

                        Try

                            DynamicReportID = (From Entity In SelectedDynamicReports
                                               Select Entity.ID).FirstOrDefault

                        Catch ex As Exception
                            DynamicReportID = 0
                        Finally

                            LoadDynamicReportTemplate(DynamicReportID, True)

                        End Try

                    End If

                End If

            End Using

        End Sub
        Private Sub ButtonItemReport_Template_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemReport_Templates.Click

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.DynamicReport, False, False, Nothing) = System.Windows.Forms.DialogResult.OK Then

                    If _DynamicReport IsNot Nothing Then

                        LoadDynamicReportTemplate(_DynamicReport.ID, False)

                    End If

                End If

            End Using

        End Sub
        Private Sub ButtonItemQuickCustomize_Columns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemQuickCustomize_Columns.Click

            'objects
            Dim DynamicReportColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing
            Dim DynamicReportColumn As AdvantageFramework.Database.Classes.DynamicReportColumn = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim ObjectType As System.Type = Nothing
            Dim DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim DReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing

            DynamicReportColumnsList = New Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn)

            For Each GridColumn In DataGridViewReport_Report.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(Column) Column.OptionsColumn.AllowShowHide = True)

                DynamicReportColumn = New AdvantageFramework.Database.Classes.DynamicReportColumn

                DynamicReportColumn.FieldName = GridColumn.FieldName
                DynamicReportColumn.HeaderText = GridColumn.ToString
                DynamicReportColumn.IsVisible = GridColumn.Visible

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)
                    DReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _DynamicReportID)
                End Using

                If DReport IsNot Nothing Then
                    DynamicReport = DReport.Type
                    ObjectType = AdvantageFramework.Reporting.LoadDynamicReportObjectType(DynamicReport)
                End If

                Try

                    PropertyDescriptor = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(ObjectType).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                          Where [Property].Name = GridColumn.FieldName
                                          Select [Property]).Single

                Catch ex As Exception
                    PropertyDescriptor = Nothing
                End Try

                If PropertyDescriptor IsNot Nothing Then

                    Try

                        EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).Single

                    Catch ex As Exception
                        EntityAttribute = Nothing
                    Finally

                        If EntityAttribute IsNot Nothing Then

                            If EntityAttribute.CustomColumnCaption <> "" Then

                                DynamicReportColumn.OriginalText = EntityAttribute.CustomColumnCaption

                            Else

                                DynamicReportColumn.OriginalText = AdvantageFramework.StringUtilities.GetNameAsWords(GridColumn.FieldName)

                            End If

                        End If

                    End Try

                Else

                    DynamicReportColumn.OriginalText = GridColumn.ToString

                End If

                DynamicReportColumnsList.Add(DynamicReportColumn)

            Next

            If AdvantageFramework.Desktop.Presentation.DynamicReportColumnEditDialog.ShowFormDialog(DynamicReportColumnsList) = Windows.Forms.DialogResult.OK Then

                For Each DynamicReportColumn In DynamicReportColumnsList

                    GridColumn = DataGridViewReport_Report.CurrentView.Columns(DynamicReportColumn.FieldName)

                    If GridColumn IsNot Nothing Then

                        GridColumn.Caption = DynamicReportColumn.HeaderText
                        GridColumn.Visible = DynamicReportColumn.IsVisible

                    End If

                Next

            End If

        End Sub
        Private Sub ButtonItemReport_SaveAs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemReport_SaveAs.Click

            If _SelectedDynamicReport > -1 Then

                SaveAsDynamicReportTemplate()

            End If

        End Sub
        Private Sub ButtonItemFilter_ShowAutoFilterRow_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemFilter_ShowAutoFilterRow.CheckedChanged, ButtonItemFilter_ShowAutoFilterRow.CheckedChanged

            DataGridViewReport_Report.CurrentView.OptionsView.ShowAutoFilterRow = ButtonItemFilter_ShowAutoFilterRow.Checked

        End Sub
        Private Sub ButtonItemFilter_ShowFilterEditor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemFilter_ShowFilterEditor.Click

            If DataGridViewReport_Report.CurrentView.FocusedColumn IsNot Nothing AndAlso DataGridViewReport_Report.CurrentView.FocusedColumn.VisibleIndex <> -1 Then

                DataGridViewReport_Report.CurrentView.ShowFilterEditor(DataGridViewReport_Report.CurrentView.FocusedColumn)

            Else

                DataGridViewReport_Report.CurrentView.ShowFilterEditor(DataGridViewReport_Report.CurrentView.VisibleColumns(0))

            End If

        End Sub
        Private Sub DataGridViewReport_Report_CreateReportHeaderAreaEvent(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles DataGridViewReport_Report.CreateReportHeaderAreaEvent

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing
            Dim TextSize As System.Drawing.Size = Nothing

            If _DynamicReport IsNot Nothing Then

                Try

                    TextSize = System.Windows.Forms.TextRenderer.MeasureText(_DynamicReport.Description, New System.Drawing.Font("Arial", 12, Drawing.FontStyle.Bold))

                    If TextSize = Nothing Then

                        If DataGridViewReport_Report.CurrentView.VisibleColumns.Count = 0 Then

                            TextBrick = CreateTextBrick(0, 0, e.Graph.ClientPageSize.Width, 15)

                        Else

                            TextBrick = CreateTextBrick(0, 0, DataGridViewReport_Report.CurrentView.VisibleColumns(0).VisibleWidth, 15)

                        End If

                    Else

                        TextBrick = CreateTextBrick(0, 0, TextSize.Width + 15, TextSize.Height + 5)

                    End If

                    TextBrick.Text = _DynamicReport.Description

                    e.Graph.DrawBrick(TextBrick)

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub ButtonItemData_Load_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemData_Load.Click

            'objects
            Dim LoadData As Boolean = True
            Dim Criteria As Integer = 0
            Dim FilterString As String = ""
            Dim [From] As Date = Nothing
            Dim [To] As Date = Nothing
            Dim ShowJobsWithNoDetails As Boolean = False
            Dim DynamicReportObjects As IEnumerable = Nothing
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim ReportColumns As Generic.List(Of AdvantageFramework.Reporting.Classes.ReportColumn) = Nothing

            If _SelectedDynamicReport > -1 Then

                'If Me.FormAction = WinForm.Presentation.FormActions.None AndAlso _ViewOnly = False Then

                '    If AdvantageFramework.WinForm.MessageBox.Show("Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                SaveDynamicReportTemplate()

                '    End If

                'End If

                LoadData = AdvantageFramework.Desktop.Presentation.LaunchInitialLoadingDialog(_SelectedDynamicReport, Criteria, FilterString, From, [To], ShowJobsWithNoDetails, ParameterDictionary, _ParameterDictionaryDrillDown)

                If LoadData Then

                    _ParameterDictionary = ParameterDictionary

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Me.ShowOverlay()

                            Try

                                If _SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetail OrElse
                                        _SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailItem OrElse
                                        _SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth OrElse
                                        _SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction Then

                                    ReportColumns = New Generic.List(Of AdvantageFramework.Reporting.Classes.ReportColumn)

                                    ReportColumns.Add(New AdvantageFramework.Reporting.Classes.ReportColumn With {.Index = -1, .ColumnName = "ID", .ReportColumnType = AdvantageFramework.Reporting.ReportColumnType.JobDetailItem})

                                    For Each GridColumn In DataGridViewReport_Report.CurrentView.VisibleColumns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                                        If GridColumn.UnboundType = DevExpress.Data.UnboundColumnType.Bound Then

                                            ReportColumns.Add(New AdvantageFramework.Reporting.Classes.ReportColumn With {.Index = GridColumn.AbsoluteIndex, .ColumnName = GridColumn.FieldName, .ReportColumnType = AdvantageFramework.Reporting.ReportColumnType.JobDetailItem})

                                        End If

                                    Next

                                End If

                                DynamicReportObjects = AdvantageFramework.Reporting.LoadDynamicReportData(DbContext, ReportingDbContext, _SelectedDynamicReport, False, Criteria,
                                                                                                          FilterString, [From], [To], ShowJobsWithNoDetails, ParameterDictionary, ReportColumns).OfType(Of Object).ToList

                                DataGridViewReport_Report.DataSource = DynamicReportObjects

                                If DataGridViewReport_Report.Columns(AdvantageFramework.Reporting.LoadDynamicReportDefaultSort(_SelectedDynamicReport)) IsNot Nothing Then

                                    DataGridViewReport_Report.Columns(AdvantageFramework.Reporting.LoadDynamicReportDefaultSort(_SelectedDynamicReport)).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

                                End If

                                LoadDashboard()

                                LoadQuickText()

                            Catch ex As Exception
                                DynamicReportObjects = Nothing
                            End Try

                            Me.CloseOverlay()

                        End Using

                    End Using

                End If

            End If

        End Sub
        Private Sub ButtonItemDashboard_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemDashboard_Edit.Click

            'objects
            Dim XML As String = ""
            Dim DashboardLayout() As Byte = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim DashboardChanged As Boolean = False
            Dim DataSource As Object = Nothing

            MemoryStream = New System.IO.MemoryStream

            If DashboardViewerDashboard_Dashboard.Dashboard IsNot Nothing Then

                DashboardViewerDashboard_Dashboard.Dashboard.SaveToXml(MemoryStream)

            End If

            DashboardLayout = MemoryStream.ToArray

            Try

                Try

                    MemoryStream.Close()

                Catch ex As Exception

                End Try

                MemoryStream.Dispose()
                MemoryStream = Nothing

            Catch ex As Exception
                MemoryStream = Nothing
            End Try

            DataSource = DataGridViewReport_Report.DataSource

            If AdvantageFramework.Reporting.Presentation.DashboardEditorForm.ShowFormDialog(Me.Session, DataSource, DashboardLayout, DashboardChanged) = Windows.Forms.DialogResult.OK Then

                If DashboardChanged Then

                    MemoryStream = New System.IO.MemoryStream

                    MemoryStream.Write(DashboardLayout, 0, DashboardLayout.Length)
                    MemoryStream.Seek(0, IO.SeekOrigin.Begin)

                    DashboardViewerDashboard_Dashboard.LoadDashboard(MemoryStream)

                    LoadDashboard()

                    Try

                        Try

                            MemoryStream.Close()

                        Catch ex As Exception

                        End Try

                        MemoryStream.Dispose()
                        MemoryStream = Nothing

                    Catch ex As Exception
                        MemoryStream = Nothing
                    End Try

                End If

            End If

        End Sub
        Private Sub ButtonItemQuickText_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemQuickText_Edit.Click

            'objects
            Dim XML As String = ""
            Dim DocumentLayout() As Byte = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim DocumentChanged As Boolean = False
            Dim DataSource As Object = Nothing

            MemoryStream = New System.IO.MemoryStream

            If SnapControlQuickText_Report.Document IsNot Nothing Then

                SnapControlQuickText_Report.ExportDocument(MemoryStream, DevExpress.XtraRichEdit.DocumentFormat.Rtf)

            End If

            DocumentLayout = MemoryStream.ToArray

            Try

                Try

                    MemoryStream.Close()

                Catch ex As Exception

                End Try

                MemoryStream.Dispose()
                MemoryStream = Nothing

            Catch ex As Exception
                MemoryStream = Nothing
            End Try

            DataSource = GetLoadedDataSource()

            If AdvantageFramework.Reporting.Presentation.SnapDocumentEditorForm.ShowFormDialog(Me.Session, DataSource, DocumentLayout, DocumentChanged) = Windows.Forms.DialogResult.OK Then

                If DocumentChanged Then

                    MemoryStream = New System.IO.MemoryStream

                    MemoryStream.Write(DocumentLayout, 0, DocumentLayout.Length)
                    MemoryStream.Seek(0, IO.SeekOrigin.Begin)

                    SnapControlQuickText_Report.LoadDocument(MemoryStream, DevExpress.XtraRichEdit.DocumentFormat.Rtf)

                    LoadQuickText()

                    Try

                        Try

                            MemoryStream.Close()

                        Catch ex As Exception

                        End Try

                        MemoryStream.Dispose()
                        MemoryStream = Nothing

                    Catch ex As Exception
                        MemoryStream = Nothing
                    End Try

                End If

            End If

        End Sub
        Private Sub ButtonItemUnboundColumns_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemUnboundColumns_Add.Click

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If AdvantageFramework.WinForm.Presentation.ComplexExpressionEditorDialog.ShowFormDialog("Add Unbound Column", DataGridViewReport_Report.CurrentView, GridColumn, AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn.Properties.HeaderText) = Windows.Forms.DialogResult.OK Then

                DataGridViewReport_Report.CurrentView.BeginUpdate()

                DataGridViewReport_Report.Columns.Add(GridColumn)

                GridColumn.VisibleIndex = DataGridViewReport_Report.CurrentView.VisibleColumns.Count

                DataGridViewReport_Report.CurrentView.EndUpdate()

                If TypeOf DataGridViewReport_Report.DataSource Is System.Windows.Forms.BindingSource Then

                    DataGridViewReport_Report.DataSource = DirectCast(DataGridViewReport_Report.DataSource, System.Windows.Forms.BindingSource).List.OfType(Of Object).ToList

                End If

            End If

        End Sub
        Private Sub ButtonItemHeaderFooterImages_Manage_Click(sender As Object, e As EventArgs) Handles ButtonItemHeaderFooterImages_Manage.Click

            AdvantageFramework.Maintenance.General.Presentation.ImageSetupForm.ShowFormDialog()

        End Sub
        Private Sub DataGridViewReport_Report_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewReport_Report.CustomColumnDisplayTextEvent

            If _SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.AROpenAged Then

                If e.Column.FieldName = AdvantageFramework.Reporting.Database.Classes.AROpenAged.Properties.InvoiceNumber.ToString Then

                    If e.DisplayText <> "" Then

                        e.DisplayText = e.Value.ToString.PadLeft(6, "0")

                    End If

                End If

            ElseIf _SelectedDynamicReport = AdvantageFramework.Reporting.DynamicReports.BroadcastWorksheetTVPreBuy Then

                If e.Column.FieldName = AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPreBuyReport.Properties.SpotEstimate.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPreBuyReport.Properties.SpotUpdatedEstimate.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPreBuyReport.Properties.TotalEstimate.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPreBuyReport.Properties.TotalUpdatedEstimate.ToString Then

                    If e.Value IsNot Nothing Then

                        e.DisplayText = FormatNumber(e.Value, 1)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewReport_Report_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewReport_Report.PopupMenuShowingEvent

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                For Each MenuItem In e.Menu.Items.OfType(Of DevExpress.Utils.Menu.DXMenuItem)()

                    If MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnColumnCustomization)) OrElse
                            MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnRemoveColumn)) Then

                        MenuItem.Visible = Not _ViewOnly

                    End If

                Next

            End If

        End Sub
        Private Sub DataGridViewReport_Report_RowCellDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles DataGridViewReport_Report.RowCellDoubleClickEvent

            Dim ClientCode As String = String.Empty
            Dim CashReport As AdvantageFramework.Database.Classes.CashAnalysisReport = Nothing
            Dim ColumnName As String = String.Empty

            Try

                ColumnName = e.Column.FieldName

                If _SelectedDynamicReport = Reporting.DynamicReports.CashAnalysis Then

                    If DataGridViewReport_Report.HasOnlyOneSelectedRow Then

                        CashReport = DataGridViewReport_Report.GetFirstSelectedRowDataBoundItem

                        If CashReport IsNot Nothing Then

                            AdvantageFramework.Desktop.Presentation.DynamicReportDrillDownDialog.ShowFormDialog(_SelectedDynamicReport, New AdvantageFramework.Reporting.Classes.CashAnalysisDrillDownParameter(_ParameterDictionaryDrillDown("StartingPostPeriodCode"), _ParameterDictionaryDrillDown("EndingPostPeriodCode"), CashReport.ClientCode, ColumnName))

                        End If

                    End If

                End If

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
            TextBrick.Font = New System.Drawing.Font("Arial", 12, Drawing.FontStyle.Bold)

            CreateTextBrick = TextBrick

        End Function
        Private Sub DashboardViewerDashboard_Dashboard_DataLoading(sender As Object, e As DevExpress.DashboardCommon.DataLoadingEventArgs) Handles DashboardViewerDashboard_Dashboard.DataLoading

            e.Data = GetLoadedDataSource()

        End Sub
        Private Sub ButtonItemReport_Schedule_Click(sender As Object, e As EventArgs) Handles ButtonItemReport_Schedule.Click

            AdvantageFramework.Desktop.Presentation.ReportScheduleDialog.ShowFormDialog(_DynamicReportID, _SelectedDynamicReport, _ParameterDictionary)

        End Sub
        Private Sub DataGridViewReport_Report_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewReport_Report.ColumnFilterChangedEvent

            If DashboardViewerDashboard_Dashboard.Dashboard IsNot Nothing AndAlso DashboardViewerDashboard_Dashboard.Dashboard.DataSources.Count > 0 Then

                If TypeOf DashboardViewerDashboard_Dashboard.Dashboard.DataSources(0) Is DevExpress.DashboardCommon.DashboardObjectDataSource Then

                    CType(DashboardViewerDashboard_Dashboard.Dashboard.DataSources(0), DevExpress.DashboardCommon.DashboardObjectDataSource).Filter = DataGridViewReport_Report.CurrentView.ActiveFilterString

                    Try

                        CType(DashboardViewerDashboard_Dashboard.Dashboard.DataSources(0), DevExpress.DashboardCommon.DashboardObjectDataSource).Fill()

                    Catch ex As Exception

                        CType(DashboardViewerDashboard_Dashboard.Dashboard.DataSources(0), DevExpress.DashboardCommon.DashboardObjectDataSource).Filter = Nothing

                        CType(DashboardViewerDashboard_Dashboard.Dashboard.DataSources(0), DevExpress.DashboardCommon.DashboardObjectDataSource).Fill()

                    End Try

                    DashboardViewerDashboard_Dashboard.Refresh()

                End If

            End If

        End Sub
        Private Sub ButtonItemData_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemDataset_Refresh.Click

            'objects
            Dim DynamicReportDataset As AdvantageFramework.Reporting.Database.Entities.DynamicReportDataset = Nothing

            Me.ShowOverlay()

            Try

                Using ReportDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        AdvantageFramework.Reporting.LoadJobDetailItemDataSet(DbContext)

                        DynamicReportDataset = AdvantageFramework.Reporting.Database.Procedures.DynamicReportDataset.LoadByDynamicReportType(ReportDbContext, _SelectedDynamicReport)

                        DynamicReportDataset.LastUpdated = Date.Now
                        DynamicReportDataset.UpdatedBy = Me.Session.UserCode

                        AdvantageFramework.Reporting.Database.Procedures.DynamicReportDataset.Update(ReportDbContext, DynamicReportDataset)

                        LabelItemDataset_LastUpdated.Text = "Data Last Updated on " & DynamicReportDataset.LastUpdated.Value.ToShortDateString & " " & DynamicReportDataset.LastUpdated.Value.ToShortTimeString

                        RibbonBarOptions_Refresh.ResetCachedContentSize()

                        RibbonBarOptions_Refresh.Refresh()

                        RibbonBarOptions_Refresh.Width = RibbonBarOptions_Refresh.GetAutoSizeWidth

                        RibbonBarOptions_Refresh.Refresh()

                    End Using

                End Using

            Catch ex As Exception

            End Try

            Me.CloseOverlay()

        End Sub

#End Region

#End Region

    End Class

End Namespace
