Namespace Reporting.Presentation

    Public Class JobStatusReportEditForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DynamicReportID As Integer = 0
        Private _Description As String = ""
        Private _UserDefinedReportCategoryID As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal DynamicReportID As Integer)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _DynamicReportID = DynamicReportID

        End Sub
        Private Sub LoadGrid(ByVal DateFrom As Date, ByVal DateTo As Date, ByVal DateType As Short, ByVal ShowJobsWithNoDetails As Boolean, ByVal ShowInvoices As Boolean, ByVal ShowClosed As Boolean)

            Try
                Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
                Dim DataTable As System.Data.DataTable = Nothing

                DataGridViewForm_JobStatusReport.DataSource = LoadJobStatusReportDataTable(DateFrom, DateTo, DateType, ShowJobsWithNoDetails, ShowInvoices, ShowClosed)

                Me.FormatColumns()
                Me.SetColumns()

                Me.DataGridViewForm_JobStatusReport.CurrentView.ViewCaption = "Job Status Report"
                Me.DataGridViewForm_JobStatusReport.CurrentView.FocusedColumn = DataGridViewForm_JobStatusReport.Columns("JobNumber")

            Catch ex As Exception
                DataGridViewForm_JobStatusReport.DataSource = Nothing
            End Try

        End Sub
        Private Function LoadJobStatusReportDataTable(ByVal DateFrom As Date, ByVal DateTo As Date, ByVal DateType As Short, ByVal ShowJobsWithNoDetails As Boolean, ByVal ShowInvoices As Boolean, ByVal ShowClosed As Boolean) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    Using SqlCommand = DbContext.CreateCommand()

                        DataTable = New System.Data.DataTable

                        SqlCommand.CommandType = CommandType.StoredProcedure
                        SqlCommand.CommandText = "advsp_job_detail_item_status_load"

                        SqlCommand.Parameters.AddWithValue("DATE_TYPE", CShort(DateType))
                        SqlCommand.Parameters.AddWithValue("START_DATE", CDate(DateFrom.ToShortDateString))
                        SqlCommand.Parameters.AddWithValue("END_DATE", CDate(DateTo.ToShortDateString))
                        SqlCommand.Parameters.AddWithValue("SHOW_JOBS_WO_DETAILS", If(ShowJobsWithNoDetails, 1, 0))
                        SqlCommand.Parameters.AddWithValue("SHOW_INVOICES", If(ShowInvoices, 1, 0))
                        SqlCommand.Parameters.AddWithValue("SHOW_CLOSED", If(ShowClosed, 1, 0))
                        SqlCommand.Parameters.AddWithValue("UserID", Me.Session.UserCode)

                        SqlCommand.Connection.Open()

                        Try

                            DataTable.Load(SqlCommand.ExecuteReader)

                        Catch ex As Exception
                            DataTable = Nothing
                        Finally
                            SqlCommand.Connection.Close()
                        End Try

                    End Using

                Catch ex As Exception

                End Try

            End Using

            LoadJobStatusReportDataTable = DataTable

        End Function
        Private Sub LoadDynamicReportTemplate(ByVal DynamicReportID As Integer)

            'objects
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim GridGroupSummaryItem As DevExpress.XtraGrid.GridGroupSummaryItem = Nothing

            Dim Setting As AdvantageFramework.Database.Entities.DynamicReportSettings = Nothing
            Dim SettingValue As AdvantageFramework.Database.Entities.DynamicReportSettings = Nothing
            Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.DynamicReportSettings) = Nothing

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, DynamicReportID)

                Catch ex As Exception
                    DynamicReport = Nothing
                End Try

                If DynamicReport IsNot Nothing Then

                    ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked = DynamicReport.AutoSizeColumnsWhenPrinting
                    ButtonItemOptionsLeft_PrintFilterInfo.Checked = DynamicReport.PrintFilterInformation
                    ButtonItemOptionsMiddle_PrintFooter.Checked = DynamicReport.PrintFooter
                    ButtonItemOptionsMiddle_PrintGroupFooter.Checked = DynamicReport.PrintGroupFooter
                    ButtonItemOptionsMiddle_PrintHeader.Checked = DynamicReport.PrintHeader
                    ButtonItemOptionsRight_PrintSelectedRowsOnly.Checked = DynamicReport.PrintSelectedRowsOnly
                    ButtonItemViewLeft_AllowCellMerging.Checked = DynamicReport.AllowCellMerge
                    ButtonItemViewLeft_ShowGroupByBox.Checked = DynamicReport.ShowGroupByBox
                    ButtonItemViewLeft_ShowViewCaption.Checked = DynamicReport.ShowViewCaption
                    ButtonItemFilter_ShowAutoFilterRow.Checked = DynamicReport.ShowAutoFilterRow

                    Me.Text = "Job Status Report - " & DynamicReport.Description

                    _Description = DynamicReport.Description
                    _UserDefinedReportCategoryID = DynamicReport.UserDefinedReportCategoryID

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)
                        If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReport.ID, "FromDate") IsNot Nothing Then
                            Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReport.ID, "FromDate")
                            DateTimePickerDateFrom_From.Value = CDate(Setting.DynamicReportSettingValue)
                        End If
                        If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReport.ID, "ToDate") IsNot Nothing Then
                            Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReport.ID, "ToDate")
                            DateTimePickerDateTo_To.Value = CDate(Setting.DynamicReportSettingValue)
                        End If
                        If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReport.ID, "Criteria") IsNot Nothing Then
                            Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReport.ID, "Criteria")
                            ComboBoxCriteria_Criteria.SelectedValue = Setting.DynamicReportSettingValue
                        End If
                        If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReport.ID, "ShowJobsWithNoDetails") IsNot Nothing Then
                            Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReport.ID, "ShowJobsWithNoDetails")
                            ButtonItemActions_ShowClosedJobs.Checked = Setting.DynamicReportSettingValue
                        End If
                        If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReport.ID, "ShowInvoices") IsNot Nothing Then
                            Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReport.ID, "ShowInvoices")
                            ButtonItemActions_ShowInvoices.Checked = Setting.DynamicReportSettingValue
                        End If
                        If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReport.ID, "ShowClosed") IsNot Nothing Then
                            Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReport.ID, "ShowClosed")
                            ButtonItem_ClosedJobs.Checked = Setting.DynamicReportSettingValue
                        End If
                    End Using

                    LoadGrid(CDate("01/01/1900"), CDate("01/01/1900"), CShort(0), False, False, False)

                    For Each DynamicReportColumn In AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.LoadByDynamicReportID(ReportingDbContext, DynamicReport.ID).OrderBy(Function(Column) Column.VisibleIndex).ToList

                        GridColumn = DataGridViewForm_JobStatusReport.Columns(DynamicReportColumn.FieldName)

                        If GridColumn IsNot Nothing Then

                            GridColumn.Caption = DynamicReportColumn.HeaderText
                            GridColumn.Visible = DynamicReportColumn.IsVisible
                            GridColumn.SortIndex = DynamicReportColumn.SortIndex
                            GridColumn.SortOrder = DynamicReportColumn.SortOrder
                            GridColumn.GroupIndex = DynamicReportColumn.GroupIndex
                            GridColumn.Width = DynamicReportColumn.Width
                            GridColumn.VisibleIndex = DynamicReportColumn.VisibleIndex

                        End If

                    Next

                    For Each GridColumn In DataGridViewForm_JobStatusReport.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(GC) GC.UnboundType = DevExpress.Data.UnboundColumnType.Bound).ToList

                        If AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.LoadByDynamicReportID(ReportingDbContext, DynamicReport.ID).Any(Function(Entity) Entity.FieldName = GridColumn.FieldName) = False Then

                            GridColumn.Visible = False

                        End If

                    Next

                    DataGridViewForm_JobStatusReport.CurrentView.AFActiveFilterString = DynamicReport.ActiveFilter

                    'For Each DynamicReportUnboundColumn In AdvantageFramework.Reporting.Database.Procedures.DynamicReportUnboundColumn.LoadByDynamicReportID(ReportingDbContext, DynamicReport.ID).OrderBy(Function(Column) Column.VisibleIndex).ToList

                    '    GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

                    '    GridColumn.FieldName = DynamicReportUnboundColumn.FieldName
                    '    GridColumn.ShowUnboundExpressionMenu = True

                    '    GridColumn.Caption = DynamicReportUnboundColumn.HeaderText
                    '    GridColumn.Visible = DynamicReportUnboundColumn.IsVisible
                    '    GridColumn.SortIndex = DynamicReportUnboundColumn.SortIndex
                    '    GridColumn.SortOrder = DynamicReportUnboundColumn.SortOrder
                    '    GridColumn.GroupIndex = DynamicReportUnboundColumn.GroupIndex
                    '    GridColumn.Width = DynamicReportUnboundColumn.Width
                    '    GridColumn.VisibleIndex = DynamicReportUnboundColumn.VisibleIndex

                    '    GridColumn.UnboundType = DynamicReportUnboundColumn.UnboundType
                    '    GridColumn.UnboundExpression = DynamicReportUnboundColumn.Expression

                    '    If String.IsNullOrEmpty(DynamicReportUnboundColumn.Format) = False Then

                    '        If GridColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal Then

                    '            GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    '            GridColumn.DisplayFormat.FormatString = DynamicReportUnboundColumn.Format

                    '        End If

                    '    End If

                    '    DataGridViewForm_JobVersionReport.Columns.Add(GridColumn)

                    'Next

                    For Each DynamicReportSummaryItem In AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.LoadByDynamicReportID(ReportingDbContext, DynamicReport.ID).ToList

                        If DynamicReportSummaryItem.OnFooter Then

                            GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem

                            GridGroupSummaryItem.SummaryType = DynamicReportSummaryItem.SummaryItemType
                            GridGroupSummaryItem.FieldName = DynamicReportSummaryItem.FieldName
                            GridGroupSummaryItem.DisplayFormat = DynamicReportSummaryItem.DisplayFormat

                            GridGroupSummaryItem.ShowInGroupColumnFooter = DataGridViewForm_JobStatusReport.Columns(DynamicReportSummaryItem.FieldName)

                            DataGridViewForm_JobStatusReport.CurrentView.GroupSummary.Add(GridGroupSummaryItem)

                        Else

                            GridColumn = DataGridViewForm_JobStatusReport.Columns(DynamicReportSummaryItem.FieldName)

                            If GridColumn IsNot Nothing Then

                                GridColumn.SummaryItem.SetSummary(DynamicReportSummaryItem.SummaryItemType, DynamicReportSummaryItem.DisplayFormat)

                            End If

                        End If

                    Next

                Else

                    Me.Text = "Job Status Report"

                End If

            End Using

        End Sub
        Private Sub SaveDynamicReportTemplate()

            'objects
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing
            Dim DynamicReportSummaryItem As AdvantageFramework.Reporting.Database.Entities.DynamicReportSummaryItem = Nothing
            Dim DynamicReportUnboundColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportUnboundColumn = Nothing
            Dim KeepSaving As Boolean = False

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _DynamicReportID = 0 Then

                    DynamicReport = New AdvantageFramework.Reporting.Database.Entities.DynamicReport

                Else

                    DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _DynamicReportID)

                End If

                DynamicReport.Type = AdvantageFramework.Reporting.DynamicReports.JobStatus
                DynamicReport.Description = _Description
                DynamicReport.UserDefinedReportCategoryID = _UserDefinedReportCategoryID
                DynamicReport.AllowCellMerge = ButtonItemViewLeft_AllowCellMerging.Checked
                DynamicReport.AutoSizeColumnsWhenPrinting = ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked
                DynamicReport.PrintHeader = ButtonItemOptionsMiddle_PrintHeader.Checked
                DynamicReport.PrintFooter = ButtonItemOptionsMiddle_PrintFooter.Checked
                DynamicReport.PrintGroupFooter = ButtonItemOptionsMiddle_PrintGroupFooter.Checked
                DynamicReport.PrintSelectedRowsOnly = ButtonItemOptionsRight_PrintSelectedRowsOnly.Checked
                DynamicReport.PrintFilterInformation = ButtonItemOptionsLeft_PrintFilterInfo.Checked
                DynamicReport.ShowGroupByBox = ButtonItemViewLeft_ShowGroupByBox.Checked
                DynamicReport.ShowViewCaption = ButtonItemViewLeft_ShowViewCaption.Checked
                DynamicReport.ShowAutoFilterRow = ButtonItemFilter_ShowAutoFilterRow.Checked
                DynamicReport.ActiveFilter = DataGridViewForm_JobStatusReport.CurrentView.AFActiveFilterString

                DynamicReport.DashboardLayout = Nothing

                If DynamicReport.IsEntityBeingAdded() Then

                    DynamicReport.CreatedByUserCode = Me.Session.UserCode
                    DynamicReport.CreatedDate = Now

                    DynamicReport.UpdatedByUserCode = Me.Session.UserCode
                    DynamicReport.UpdatedDate = Now

                    KeepSaving = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Insert(ReportingDbContext, DynamicReport)

                Else

                    DynamicReport.UpdatedByUserCode = Me.Session.UserCode
                    DynamicReport.UpdatedDate = Now

                    KeepSaving = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Update(ReportingDbContext, DynamicReport)

                End If

                If KeepSaving Then

                    For Each GridColumn In DataGridViewForm_JobStatusReport.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(GC) GC.UnboundType = DevExpress.Data.UnboundColumnType.Bound).ToList

                        DynamicReportColumn = AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.LoadByDynamicReportIDAndFieldName(ReportingDbContext, DynamicReport.ID, GridColumn.FieldName)

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

                            AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.Insert(ReportingDbContext, DynamicReport.ID, GridColumn.FieldName,
                                                                                              GridColumn.ToString, GridColumn.Visible, GridColumn.SortIndex,
                                                                                              GridColumn.SortOrder, GridColumn.GroupIndex, GridColumn.Width,
                                                                                              GridColumn.VisibleIndex, Nothing, Nothing)

                        End If

                    Next

                    For Each GridColumn In DataGridViewForm_JobStatusReport.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(GC) GC.UnboundType <> DevExpress.Data.UnboundColumnType.Bound).ToList

                        DynamicReportUnboundColumn = AdvantageFramework.Reporting.Database.Procedures.DynamicReportUnboundColumn.LoadByDynamicReportIDAndFieldName(ReportingDbContext, DynamicReport.ID, GridColumn.FieldName)

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

                            AdvantageFramework.Reporting.Database.Procedures.DynamicReportUnboundColumn.Insert(ReportingDbContext, DynamicReport.ID, GridColumn.FieldName,
                                                                                                    GridColumn.Caption, GridColumn.Visible, GridColumn.SortIndex,
                                                                                                    GridColumn.SortOrder, GridColumn.GroupIndex, GridColumn.Width,
                                                                                                    GridColumn.VisibleIndex, GridColumn.UnboundType, GridColumn.UnboundExpression,
                                                                                                    GridColumn.DisplayFormat.FormatString, Nothing)

                        End If

                    Next

                    For Each DynamicReportSummaryItem In AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.LoadByDynamicReportID(ReportingDbContext, DynamicReport.ID).ToList

                        AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.Delete(ReportingDbContext, DynamicReportSummaryItem)

                    Next

                    For Each GridGroupSummaryItem In DataGridViewForm_JobStatusReport.CurrentView.GroupSummary.OfType(Of DevExpress.XtraGrid.GridGroupSummaryItem)()

                        AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.Insert(ReportingDbContext, DynamicReport.ID, GridGroupSummaryItem.SummaryType,
                                                                                               GridGroupSummaryItem.FieldName, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, False, True),
                                                                                               GridGroupSummaryItem.DisplayFormat, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, "", GridGroupSummaryItem.FieldName),
                                                                                               Nothing)

                    Next

                    For Each GridColumn In DataGridViewForm_JobStatusReport.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                        If GridColumn.SummaryItem IsNot Nothing AndAlso GridColumn.SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.None Then

                            AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.Insert(ReportingDbContext, DynamicReport.ID, GridColumn.SummaryItem.SummaryType,
                                                                                                   GridColumn.FieldName, False,
                                                                                                   GridColumn.SummaryItem.DisplayFormat, GridColumn.SummaryItem.FieldName,
                                                                                                   Nothing)

                        End If

                    Next

                    Me.Text = "Job Status Report - " & DynamicReport.Description
                    _DynamicReportID = DynamicReport.ID
                    _Description = DynamicReport.Description
                    _UserDefinedReportCategoryID = DynamicReport.UserDefinedReportCategoryID


                    SaveDyanmicReportSetting()

                End If

            End Using

        End Sub
        Private Sub SaveAsDynamicReportTemplate()

            'objects
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim Description As String = ""
            Dim UserDefinedReportCategoryID As Nullable(Of Integer) = 0

            If AdvantageFramework.Reporting.Presentation.JobStatusReportUpdateDialog.ShowFormDialog(0, Description, UserDefinedReportCategoryID, False) = System.Windows.Forms.DialogResult.OK Then

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Insert(ReportingDbContext, AdvantageFramework.Reporting.DynamicReports.JobStatus, Description, ReportingDbContext.UserCode, Now,
                                                                                            ButtonItemViewLeft_AllowCellMerging.Checked, ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked,
                                                                                            ButtonItemOptionsMiddle_PrintHeader.Checked, ButtonItemOptionsMiddle_PrintFooter.Checked,
                                                                                            ButtonItemOptionsMiddle_PrintGroupFooter.Checked, ButtonItemOptionsRight_PrintSelectedRowsOnly.Checked,
                                                                                            ButtonItemOptionsLeft_PrintFilterInfo.Checked, ButtonItemFilter_ShowAutoFilterRow.Checked,
                                                                                            DataGridViewForm_JobStatusReport.CurrentView.AFActiveFilterString, ButtonItemViewLeft_ShowGroupByBox.Checked,
                                                                                            ButtonItemViewLeft_ShowViewCaption.Checked, UserDefinedReportCategoryID, Nothing, Nothing, DynamicReport) Then

                        For Each GridColumn In DataGridViewForm_JobStatusReport.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(GC) GC.UnboundType = DevExpress.Data.UnboundColumnType.Bound).ToList

                            AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.Insert(ReportingDbContext, DynamicReport.ID, GridColumn.FieldName,
                                                                                                          GridColumn.Caption, GridColumn.Visible, GridColumn.SortIndex,
                                                                                                          GridColumn.SortOrder, GridColumn.GroupIndex, GridColumn.Width,
                                                                                                          GridColumn.VisibleIndex, Nothing, Nothing)

                        Next

                        For Each GridGroupSummaryItem In DataGridViewForm_JobStatusReport.CurrentView.GroupSummary.OfType(Of DevExpress.XtraGrid.GridGroupSummaryItem)()

                            AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.Insert(ReportingDbContext, DynamicReport.ID, GridGroupSummaryItem.SummaryType,
                                                                                                            GridGroupSummaryItem.FieldName, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, False, True),
                                                                                                            GridGroupSummaryItem.DisplayFormat, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, "", GridGroupSummaryItem.ShowInGroupColumnFooter.FieldName),
                                                                                                            Nothing)

                        Next

                        For Each GridColumn In DataGridViewForm_JobStatusReport.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                            If GridColumn.SummaryItem IsNot Nothing AndAlso GridColumn.SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.None Then

                                AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.Insert(ReportingDbContext, DynamicReport.ID, GridColumn.SummaryItem.SummaryType,
                                                                                                                GridColumn.FieldName, False,
                                                                                                                GridColumn.SummaryItem.DisplayFormat, GridColumn.SummaryItem.FieldName,
                                                                                                                Nothing)

                            End If

                        Next

                        Me.Text = "Job Status Report - " & DynamicReport.Description
                        _DynamicReportID = DynamicReport.ID
                        _Description = DynamicReport.Description
                        _UserDefinedReportCategoryID = DynamicReport.UserDefinedReportCategoryID

                        SaveDyanmicReportSetting()
                    End If

                End Using

            End If

        End Sub
        Private Sub SaveDyanmicReportSetting()

            Dim Setting As AdvantageFramework.Database.Entities.DynamicReportSettings = Nothing
            Dim SettingValue As AdvantageFramework.Database.Entities.DynamicReportSettings = Nothing
            Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.DynamicReportSettings) = Nothing

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, _DynamicReportID, "FromDate") Is Nothing Then

                        Setting = New AdvantageFramework.Database.Entities.DynamicReportSettings
                        Setting.DataContext = DataContext
                        Setting.DynamicReportID = _DynamicReportID
                        Setting.DynamicReportSettingName = "FromDate"
                        Setting.DynamicReportSettingValue = CDate(DateTimePickerDateFrom_From.Value.ToShortDateString)
                        AdvantageFramework.Database.Procedures.DynamicReportSettings.Insert(DataContext, Setting)

                    Else

                        Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, _DynamicReportID, "FromDate")
                        Setting.DynamicReportSettingValue = CDate(DateTimePickerDateFrom_From.Value.ToShortDateString)
                        AdvantageFramework.Database.Procedures.DynamicReportSettings.Update(DataContext, Setting)

                    End If

                    If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, _DynamicReportID, "ToDate") Is Nothing Then

                        Setting = New AdvantageFramework.Database.Entities.DynamicReportSettings
                        Setting.DataContext = DataContext
                        Setting.DynamicReportID = _DynamicReportID
                        Setting.DynamicReportSettingName = "ToDate"
                        Setting.DynamicReportSettingValue = CDate(DateTimePickerDateTo_To.Value.ToShortDateString)
                        AdvantageFramework.Database.Procedures.DynamicReportSettings.Insert(DataContext, Setting)

                    Else

                        Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, _DynamicReportID, "ToDate")
                        Setting.DynamicReportSettingValue = CDate(DateTimePickerDateTo_To.Value.ToShortDateString)
                        AdvantageFramework.Database.Procedures.DynamicReportSettings.Update(DataContext, Setting)

                    End If

                    If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, _DynamicReportID, "Criteria") Is Nothing Then

                        Setting = New AdvantageFramework.Database.Entities.DynamicReportSettings
                        Setting.DataContext = DataContext
                        Setting.DynamicReportID = _DynamicReportID
                        Setting.DynamicReportSettingName = "Criteria"
                        Setting.DynamicReportSettingValue = CShort(ComboBoxCriteria_Criteria.GetSelectedValue)
                        AdvantageFramework.Database.Procedures.DynamicReportSettings.Insert(DataContext, Setting)

                    Else

                        Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, _DynamicReportID, "Criteria")
                        Setting.DynamicReportSettingValue = CShort(ComboBoxCriteria_Criteria.GetSelectedValue)
                        AdvantageFramework.Database.Procedures.DynamicReportSettings.Update(DataContext, Setting)

                    End If

                    If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, _DynamicReportID, "ShowJobsWithNoDetails") Is Nothing Then

                        Setting = New AdvantageFramework.Database.Entities.DynamicReportSettings
                        Setting.DataContext = DataContext
                        Setting.DynamicReportID = _DynamicReportID
                        Setting.DynamicReportSettingName = "ShowJobsWithNoDetails"
                        Setting.DynamicReportSettingValue = If(ButtonItemActions_ShowClosedJobs.Checked, 1, 0)
                        AdvantageFramework.Database.Procedures.DynamicReportSettings.Insert(DataContext, Setting)

                    Else

                        Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, _DynamicReportID, "ShowJobsWithNoDetails")
                        Setting.DynamicReportSettingValue = If(ButtonItemActions_ShowClosedJobs.Checked, 1, 0)
                        AdvantageFramework.Database.Procedures.DynamicReportSettings.Update(DataContext, Setting)

                    End If

                    If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, _DynamicReportID, "ShowInvoices") Is Nothing Then

                        Setting = New AdvantageFramework.Database.Entities.DynamicReportSettings
                        Setting.DataContext = DataContext
                        Setting.DynamicReportID = _DynamicReportID
                        Setting.DynamicReportSettingName = "ShowInvoices"
                        Setting.DynamicReportSettingValue = If(ButtonItemActions_ShowInvoices.Checked, 1, 0)
                        AdvantageFramework.Database.Procedures.DynamicReportSettings.Insert(DataContext, Setting)

                    Else

                        Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, _DynamicReportID, "ShowInvoices")
                        Setting.DynamicReportSettingValue = If(ButtonItemActions_ShowInvoices.Checked, 1, 0)
                        AdvantageFramework.Database.Procedures.DynamicReportSettings.Update(DataContext, Setting)

                    End If
                    If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, _DynamicReportID, "ShowClosed") Is Nothing Then
                        Setting = New AdvantageFramework.Database.Entities.DynamicReportSettings
                        Setting.DataContext = DataContext
                        Setting.DynamicReportID = _DynamicReportID
                        Setting.DynamicReportSettingName = "ShowClosed"
                        Setting.DynamicReportSettingValue = If(ButtonItem_ClosedJobs.Checked, 1, 0)
                        AdvantageFramework.Database.Procedures.DynamicReportSettings.Insert(DataContext, Setting)
                    Else
                        Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, _DynamicReportID, "ShowClosed")
                        Setting.DynamicReportSettingValue = If(ButtonItem_ClosedJobs.Checked, 1, 0)
                        AdvantageFramework.Database.Procedures.DynamicReportSettings.Update(DataContext, Setting)
                    End If

                Catch ex As Exception

                End Try

            End Using

        End Sub
        Private Sub SetColumns()
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _DynamicReportID)

                Catch ex As Exception
                    DynamicReport = Nothing
                End Try

                If DynamicReport IsNot Nothing Then

                    For Each DynamicReportColumn In AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.LoadByDynamicReportID(ReportingDbContext, DynamicReport.ID).OrderBy(Function(Column) Column.VisibleIndex).ToList

                        GridColumn = DataGridViewForm_JobStatusReport.Columns(DynamicReportColumn.FieldName)

                        If GridColumn IsNot Nothing Then

                            GridColumn.Caption = DynamicReportColumn.HeaderText
                            GridColumn.Visible = DynamicReportColumn.IsVisible
                            GridColumn.SortIndex = DynamicReportColumn.SortIndex
                            GridColumn.SortOrder = DynamicReportColumn.SortOrder
                            GridColumn.GroupIndex = DynamicReportColumn.GroupIndex
                            GridColumn.Width = DynamicReportColumn.Width
                            GridColumn.VisibleIndex = DynamicReportColumn.VisibleIndex

                        End If

                    Next

                End If

            End Using

        End Sub
        Private Sub FormatColumns()
            Try
                For Each GridColumn In DataGridViewForm_JobStatusReport.Columns
                    If GridColumn.FieldName = "BillingBudget" Or GridColumn.FieldName = "IncomeBudget" Or GridColumn.FieldName = "Hours" Or GridColumn.FieldName = "Quantity" Or _
                       GridColumn.FieldName = "ComponentBudget" Or GridColumn.FieldName = "JobQuantity" Or GridColumn.FieldName = "BillableLessResale" Or GridColumn.FieldName = "BillableTotal" Or _
                       GridColumn.FieldName = "ExtMarkupAmount" Or GridColumn.FieldName = "NonResaleTaxAmount" Or GridColumn.FieldName = "ResaleTaxAmount" Or GridColumn.FieldName = "Total" Or _
                       GridColumn.FieldName = "CostAmount" Or GridColumn.FieldName = "NetAmount" Or GridColumn.FieldName = "EstimateHours" Or GridColumn.FieldName = "EstimateQuantity" Or _
                       GridColumn.FieldName = "EstimateTotalAmount" Or GridColumn.FieldName = "EstimateContTotalAmount" Or GridColumn.FieldName = "EstimateNonResaleTaxAmount" Or GridColumn.FieldName = "EstimateResaleTaxAmount" Or _
                       GridColumn.FieldName = "EstimateMarkupAmount" Or GridColumn.FieldName = "EstimateCostAmount" Or GridColumn.FieldName = "EstimateFeeTime" Or GridColumn.FieldName = "EstimateNetAmount" Or _
                       GridColumn.FieldName = "EstimateVariance" Or GridColumn.FieldName = "OpenPurchaseOrderAmount" Or GridColumn.FieldName = "OpenPurchaseOrderGrossAmount" Or GridColumn.FieldName = "BilledAmount" Or _
                       GridColumn.FieldName = "BilledWithResale" Or GridColumn.FieldName = "BilledHours" Or GridColumn.FieldName = "BilledQuantity" Or GridColumn.FieldName = "FeeTimeAmount" Or _
                       GridColumn.FieldName = "FeeTimeHours" Or GridColumn.FieldName = "UnbilledAmount" Or GridColumn.FieldName = "UnbilledAmountLessResale" Or GridColumn.FieldName = "UnbilledHours" Or _
                       GridColumn.FieldName = "UnbilledQuantity" Or GridColumn.FieldName = "NonBillableAmount" Or GridColumn.FieldName = "NonBillableHours" Or GridColumn.FieldName = "NonBillableQuantity" Or _
                       GridColumn.FieldName = "BillingApprovalHours" Or GridColumn.FieldName = "BillingApprovalCostAmount" Or GridColumn.FieldName = "BillingApprovalExtNetAmount" Or GridColumn.FieldName = "BillingApprovalTotalAmount" Or _
                       GridColumn.FieldName.ToString.Contains("InvoiceAmount") Then
                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "n2"
                    End If
                Next
            Catch ex As Exception

            End Try
        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(ByVal DynamicReportID As Integer)

            'objects
            Dim JobStatusReportEditForm As AdvantageFramework.Reporting.Presentation.JobStatusReportEditForm = Nothing

            JobStatusReportEditForm = New AdvantageFramework.Reporting.Presentation.JobStatusReportEditForm(DynamicReportID)

            JobStatusReportEditForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub JobStatusReportEditForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True

            ButtonItemReport_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemReport_SaveAs.Image = AdvantageFramework.My.Resources.SaveAsImage

            ButtonItemPrinting_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemQuickCustomize_Columns.Image = AdvantageFramework.My.Resources.ColumnImage

            ButtonItemActions_ShowClosedJobs.Image = AdvantageFramework.My.Resources.JobJacketImage
            ButtonItemActions_View.Image = AdvantageFramework.My.Resources.ReportImage

            ButtonItem_ClosedJobs.Image = AdvantageFramework.My.Resources.JobJacketImage
            ButtonItemActions_ShowInvoices.Image = AdvantageFramework.My.Resources.InvoiceListImage

            DateTimePickerDateFrom_From.ReadOnly = True
            DateTimePickerDateTo_To.ReadOnly = True

            DateTimePickerDateFrom_From.ReadOnly = False
            DateTimePickerDateTo_To.ReadOnly = False

            DateTimePickerDateFrom_From.Value = Now
            DateTimePickerDateTo_To.Value = Now

            ComboBoxCriteria_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobDetailInitialCriteria), False)

            DataGridViewForm_JobStatusReport.DataSource = New System.Data.DataTable

        End Sub
        Private Sub JobStatusReportEditForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            'objects
            Dim RibbonControl As DevComponents.DotNetBar.RibbonControl = Nothing

            ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked = DataGridViewForm_JobStatusReport.OptionsPrint.AutoWidth
            ButtonItemOptionsLeft_PrintFilterInfo.Checked = DataGridViewForm_JobStatusReport.OptionsPrint.PrintFilterInfo
            ButtonItemOptionsMiddle_PrintFooter.Checked = DataGridViewForm_JobStatusReport.OptionsPrint.PrintFooter
            ButtonItemOptionsMiddle_PrintGroupFooter.Checked = DataGridViewForm_JobStatusReport.OptionsPrint.PrintGroupFooter
            ButtonItemOptionsMiddle_PrintHeader.Checked = DataGridViewForm_JobStatusReport.OptionsPrint.PrintHeader
            ButtonItemOptionsRight_PrintSelectedRowsOnly.Checked = DataGridViewForm_JobStatusReport.OptionsPrint.PrintSelectedRowsOnly
            ButtonItemViewLeft_AllowCellMerging.Checked = DataGridViewForm_JobStatusReport.OptionsView.AllowCellMerge
            ButtonItemViewLeft_ShowGroupByBox.Checked = DataGridViewForm_JobStatusReport.OptionsView.ShowGroupPanel
            ButtonItemViewLeft_ShowViewCaption.Checked = DataGridViewForm_JobStatusReport.OptionsView.ShowViewCaption
            ButtonItemFilter_ShowAutoFilterRow.Checked = DataGridViewForm_JobStatusReport.OptionsView.ShowAutoFilterRow

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

            If _DynamicReportID > 0 Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                Try

                    LoadDynamicReportTemplate(_DynamicReportID)

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None

            Else

                If AdvantageFramework.Reporting.Presentation.JobStatusReportUpdateDialog.ShowFormDialog(0, _Description, _UserDefinedReportCategoryID, True) = Windows.Forms.DialogResult.OK Then

                    Try

                        LoadGrid(CDate("01/01/1900"), CDate("01/01/1900"), CShort(0), False, False, False)

                        Me.Text = "Job Status Report - " & _Description

                    Catch ex As Exception

                    End Try

                Else

                    Me.Close()

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemReport_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemReport_Save.Click

            SaveDynamicReportTemplate()

        End Sub
        Private Sub ButtonItemReport_SaveAs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemReport_SaveAs.Click

            SaveAsDynamicReportTemplate()

        End Sub
        Private Sub ButtonItemActions_View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_View.Click

            If Me.Validator Then

                If Me.ButtonItemActions_ShowInvoices.Checked Then
                    For Each col As DevExpress.XtraGrid.Columns.GridColumn In DataGridViewForm_JobStatusReport.Columns
                        If col.GroupIndex > -1 Then
                            col.GroupIndex = -1
                        End If
                    Next
                    DataGridViewForm_JobStatusReport.Columns.Clear()
                End If

                LoadGrid(CDate(DateTimePickerDateFrom_From.Value.ToShortDateString),
                         CDate(DateTimePickerDateTo_To.Value.ToShortDateString), CShort(ComboBoxCriteria_Criteria.GetSelectedValue),
                         ButtonItemActions_ShowClosedJobs.Checked, ButtonItemActions_ShowInvoices.Checked, ButtonItem_ClosedJobs.Checked)

            End If

        End Sub
        Private Sub ButtonItemDateFrom_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDateFrom_YTD.Click

			DateTimePickerDateFrom_From.Value = New Date(Now.Year, 1, 1)
			DateTimePickerDateTo_To.Value = Now

        End Sub
        Private Sub ButtonItemDateTo_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDateTo_MTD.Click

			DateTimePickerDateFrom_From.Value = New Date(Now.Year, Now.Month, 1)
			DateTimePickerDateTo_To.Value = Now

        End Sub
        Private Sub ButtonItemDateFrom_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDateFrom_1Year.Click

            DateTimePickerDateFrom_From.Value = Now.AddYears(-1)
            DateTimePickerDateTo_To.Value = Now

        End Sub
        Private Sub ButtonItemDateTo_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDateTo_2Years.Click

            DateTimePickerDateFrom_From.Value = Now.AddYears(-2)
            DateTimePickerDateTo_To.Value = Now

        End Sub
        Private Sub DateTimePickerDateTo_To_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerDateTo_To.ValueChanged

            DateTimePickerDateFrom_From.MaxDate = DateTimePickerDateTo_To.Value

        End Sub
        Private Sub DateTimePickerDateFrom_From_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerDateFrom_From.ValueChanged

            DateTimePickerDateTo_To.MinDate = DateTimePickerDateFrom_From.Value

        End Sub
        Private Sub ButtonItemPrinting_Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemPrinting_Print.Click

            DataGridViewForm_JobStatusReport.Print(DefaultLookAndFeel.LookAndFeel, "Job Status")

        End Sub
        Private Sub ButtonItemOptionsLeft_AutoSizeColumnsToPage_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsLeft_AutoSizeColumnsToPage.CheckedChanged

            DataGridViewForm_JobStatusReport.OptionsPrint.AutoWidth = ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked

        End Sub
        Private Sub ButtonItemOptionsLeft_PrintFilterInfo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsLeft_PrintFilterInfo.CheckedChanged

            DataGridViewForm_JobStatusReport.OptionsPrint.PrintFilterInfo = ButtonItemOptionsLeft_PrintFilterInfo.Checked

        End Sub
        Private Sub ButtonItemOptionsMiddle_PrintFooter_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsMiddle_PrintFooter.CheckedChanged

            DataGridViewForm_JobStatusReport.OptionsPrint.PrintFooter = ButtonItemOptionsMiddle_PrintFooter.Checked

        End Sub
        Private Sub ButtonItemOptionsMiddle_PrintGroupFooter_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsMiddle_PrintGroupFooter.CheckedChanged

            DataGridViewForm_JobStatusReport.OptionsPrint.PrintGroupFooter = ButtonItemOptionsMiddle_PrintGroupFooter.Checked

        End Sub
        Private Sub ButtonItemOptionsMiddle_PrintHeader_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsMiddle_PrintHeader.CheckedChanged

            DataGridViewForm_JobStatusReport.OptionsPrint.PrintHeader = ButtonItemOptionsMiddle_PrintHeader.Checked

        End Sub
        Private Sub ButtonItemOptions_PrintSelectRowsOnly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsRight_PrintSelectedRowsOnly.CheckedChanged

            DataGridViewForm_JobStatusReport.OptionsPrint.PrintSelectedRowsOnly = ButtonItemOptionsRight_PrintSelectedRowsOnly.Checked

        End Sub
        Private Sub ButtonItemViewLeft_AllowCellMerging_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemViewLeft_AllowCellMerging.CheckedChanged

            DataGridViewForm_JobStatusReport.OptionsView.AllowCellMerge = ButtonItemViewLeft_AllowCellMerging.Checked

        End Sub
        Private Sub ButtonItemViewLeft_ShowViewCaption_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemViewLeft_ShowViewCaption.CheckedChanged

            DataGridViewForm_JobStatusReport.OptionsView.ShowViewCaption = ButtonItemViewLeft_ShowViewCaption.Checked

        End Sub
        Private Sub ButtonItemViewLeft_ShowGroupByBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemViewLeft_ShowGroupByBox.CheckedChanged

            DataGridViewForm_JobStatusReport.OptionsView.ShowGroupPanel = ButtonItemViewLeft_ShowGroupByBox.Checked

        End Sub
        Private Sub ButtonItemQuickCustomize_Columns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemQuickCustomize_Columns.Click

            'objects
            Dim DynamicReportColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing
            Dim DynamicReportColumn As AdvantageFramework.Database.Classes.DynamicReportColumn = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            DynamicReportColumnsList = New Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn)

            For Each GridColumn In DataGridViewForm_JobStatusReport.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(Column) Column.OptionsColumn.AllowShowHide = True)

                DynamicReportColumn = New AdvantageFramework.Database.Classes.DynamicReportColumn

                DynamicReportColumn.FieldName = GridColumn.FieldName
                DynamicReportColumn.HeaderText = GridColumn.ToString
                DynamicReportColumn.IsVisible = GridColumn.Visible

                DynamicReportColumnsList.Add(DynamicReportColumn)

            Next

            If AdvantageFramework.Desktop.Presentation.DynamicReportColumnEditDialog.ShowFormDialog(DynamicReportColumnsList) = Windows.Forms.DialogResult.OK Then

                For Each DynamicReportColumn In DynamicReportColumnsList

                    GridColumn = DataGridViewForm_JobStatusReport.CurrentView.Columns(DynamicReportColumn.FieldName)

                    If GridColumn IsNot Nothing Then

                        GridColumn.Caption = DynamicReportColumn.HeaderText
                        GridColumn.Visible = DynamicReportColumn.IsVisible

                    End If

                Next

            End If

        End Sub
        Private Sub ButtonItemFilter_ShowAutoFilterRow_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemFilter_ShowAutoFilterRow.CheckedChanged, ButtonItemFilter_ShowAutoFilterRow.CheckedChanged

            DataGridViewForm_JobStatusReport.CurrentView.OptionsView.ShowAutoFilterRow = ButtonItemFilter_ShowAutoFilterRow.Checked

        End Sub
        Private Sub ButtonItemFilter_ShowFilterEditor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemFilter_ShowFilterEditor.Click
            Try
                If DataGridViewForm_JobStatusReport.CurrentView.FocusedColumn IsNot Nothing AndAlso DataGridViewForm_JobStatusReport.CurrentView.FocusedColumn.VisibleIndex <> -1 Then

                    DataGridViewForm_JobStatusReport.CurrentView.ShowFilterEditor(DataGridViewForm_JobStatusReport.CurrentView.FocusedColumn)

                Else

                    DataGridViewForm_JobStatusReport.CurrentView.ShowFilterEditor(DataGridViewForm_JobStatusReport.CurrentView.VisibleColumns(0))

                End If
            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemActions_ShowInvoices_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemActions_ShowInvoices.CheckedChanged
            Try
                For Each col As DevExpress.XtraGrid.Columns.GridColumn In DataGridViewForm_JobStatusReport.Columns
                    If col.GroupIndex > -1 Then
                        col.GroupIndex = -1
                    End If
                Next
                DataGridViewForm_JobStatusReport.Columns.Clear()

                LoadGrid(CDate(DateTimePickerDateFrom_From.Value.ToShortDateString),
                        CDate(DateTimePickerDateTo_To.Value.ToShortDateString), CShort(ComboBoxCriteria_Criteria.GetSelectedValue),
                        ButtonItemActions_ShowClosedJobs.Checked, ButtonItemActions_ShowInvoices.Checked, ButtonItem_ClosedJobs.Checked)
            Catch ex As Exception

            End Try

        End Sub

#End Region

#End Region


    End Class

End Namespace
