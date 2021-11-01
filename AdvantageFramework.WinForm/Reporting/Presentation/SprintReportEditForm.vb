Namespace Reporting.Presentation

    Public Class SprintReportEditForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DynamicReportID As Integer = 0
        Private _JobVersionTemplateCode As String = ""
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
        Private Sub LoadGrid(ByVal StartWeek As Date)

            Try

                DataGridViewForm_JobVersionReport.DataSource = LoadSprintReportDataTable(StartWeek)

                Me.DataGridViewForm_JobVersionReport.CurrentView.ViewCaption = Me.DataGridViewForm_JobVersionReport.CurrentView.RowCount & " Resource Allocation By Week Report(s)"

                Me.SetColumns()

            Catch ex As Exception
                DataGridViewForm_JobVersionReport.DataSource = Nothing
            End Try

        End Sub
        Private Function LoadSprintReportDataTable(ByVal StartWeek As Date) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    Using SqlCommand = DbContext.CreateCommand()

                        DataTable = New System.Data.DataTable

                        SqlCommand.CommandType = CommandType.StoredProcedure
                        SqlCommand.CommandText = "advsp_agile_load_dataset"

                        SqlCommand.Parameters.AddWithValue("@OFFICE_LIST", "")
                        SqlCommand.Parameters.AddWithValue("@DEPT_LIST", "")
                        SqlCommand.Parameters.AddWithValue("@STARTING_WEEK", StartWeek)
                        SqlCommand.Parameters.AddWithValue("@NUM_WEEKS", Me.ComboBox_Week.SelectedValue)
                        SqlCommand.CommandTimeout = 1200
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

            LoadSprintReportDataTable = DataTable

        End Function
        Private Sub LoadDynamicReportTemplate(ByVal DynamicReportID As Integer)

            'objects
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim GridGroupSummaryItem As DevExpress.XtraGrid.GridGroupSummaryItem = Nothing

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

                    Me.Text = "Resource Allocation By Week Report - " & DynamicReport.Description

                    _Description = DynamicReport.Description
                    _UserDefinedReportCategoryID = DynamicReport.UserDefinedReportCategoryID

                    LoadGrid(CDate(Date.Now.ToShortDateString))



                    DataGridViewForm_JobVersionReport.CurrentView.AFActiveFilterString = DynamicReport.ActiveFilter

                    For Each DynamicReportColumn In AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.LoadByDynamicReportID(ReportingDbContext, DynamicReport.ID).OrderBy(Function(Column) Column.VisibleIndex).ToList

                        GridColumn = DataGridViewForm_JobVersionReport.Columns(DynamicReportColumn.FieldName)

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

                    For Each GridColumn In DataGridViewForm_JobVersionReport.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(GC) GC.UnboundType = DevExpress.Data.UnboundColumnType.Bound).ToList

                        If AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.LoadByDynamicReportID(ReportingDbContext, DynamicReport.ID).Any(Function(Entity) Entity.FieldName = GridColumn.FieldName) = False Then

                            GridColumn.Visible = False

                        End If

                    Next

                    'For Each DynamicReportUnboundColumn In AdvantageFramework.Database.Procedures.DynamicReportUnboundColumn.LoadByDynamicReportID(DbContext, DynamicReport.ID).OrderBy(Function(Column) Column.VisibleIndex).ToList

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

                            GridGroupSummaryItem.ShowInGroupColumnFooter = DataGridViewForm_JobVersionReport.Columns(DynamicReportSummaryItem.FieldName)

                            DataGridViewForm_JobVersionReport.CurrentView.GroupSummary.Add(GridGroupSummaryItem)

                        Else

                            GridColumn = DataGridViewForm_JobVersionReport.Columns(DynamicReportSummaryItem.FieldName)

                            If GridColumn IsNot Nothing Then

                                GridColumn.SummaryItem.SetSummary(DynamicReportSummaryItem.SummaryItemType, DynamicReportSummaryItem.DisplayFormat)

                            End If

                        End If

                    Next

                Else

                    Me.Text = "Resource Allocation By Week Report"

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

                DynamicReport.Type = AdvantageFramework.Reporting.DynamicReports.ResourceAllocationByWeek
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
                DynamicReport.ActiveFilter = DataGridViewForm_JobVersionReport.CurrentView.AFActiveFilterString
                DynamicReport.TemplateCode = _JobVersionTemplateCode

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

                    For Each GridColumn In DataGridViewForm_JobVersionReport.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(GC) GC.UnboundType = DevExpress.Data.UnboundColumnType.Bound).ToList

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

                    For Each GridColumn In DataGridViewForm_JobVersionReport.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(GC) GC.UnboundType <> DevExpress.Data.UnboundColumnType.Bound).ToList

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

                    For Each GridGroupSummaryItem In DataGridViewForm_JobVersionReport.CurrentView.GroupSummary.OfType(Of DevExpress.XtraGrid.GridGroupSummaryItem)()

                        AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.Insert(ReportingDbContext, DynamicReport.ID, GridGroupSummaryItem.SummaryType,
                                                                                               GridGroupSummaryItem.FieldName, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, False, True),
                                                                                               GridGroupSummaryItem.DisplayFormat, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, "", GridGroupSummaryItem.FieldName),
                                                                                               Nothing)

                    Next

                    For Each GridColumn In DataGridViewForm_JobVersionReport.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                        If GridColumn.SummaryItem IsNot Nothing AndAlso GridColumn.SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.None Then

                            AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.Insert(ReportingDbContext, DynamicReport.ID, GridColumn.SummaryItem.SummaryType,
                                                                                                   GridColumn.FieldName, False,
                                                                                                   GridColumn.SummaryItem.DisplayFormat, GridColumn.SummaryItem.FieldName,
                                                                                                   Nothing)

                        End If

                    Next

                    Me.Text = "Resource Allocation By Week Report - " & DynamicReport.Description
                    _DynamicReportID = DynamicReport.ID
                    _Description = DynamicReport.Description
                    _UserDefinedReportCategoryID = DynamicReport.UserDefinedReportCategoryID

                End If

            End Using

        End Sub
        Private Sub SaveAsDynamicReportTemplate()

            'objects
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim Description As String = ""
            Dim UserDefinedReportCategoryID As Nullable(Of Integer) = 0

            If AdvantageFramework.Reporting.Presentation.SprintReportUpdateDialog.ShowFormDialog(0, Description, UserDefinedReportCategoryID, False) = System.Windows.Forms.DialogResult.OK Then

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Insert(ReportingDbContext, AdvantageFramework.Reporting.DynamicReports.ResourceAllocationByWeek, Description, ReportingDbContext.UserCode, Now,
                                                                                   ButtonItemViewLeft_AllowCellMerging.Checked, ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked,
                                                                                   ButtonItemOptionsMiddle_PrintHeader.Checked, ButtonItemOptionsMiddle_PrintFooter.Checked,
                                                                                   ButtonItemOptionsMiddle_PrintGroupFooter.Checked, ButtonItemOptionsRight_PrintSelectedRowsOnly.Checked,
                                                                                   ButtonItemOptionsLeft_PrintFilterInfo.Checked, ButtonItemFilter_ShowAutoFilterRow.Checked,
                                                                                   DataGridViewForm_JobVersionReport.CurrentView.AFActiveFilterString, ButtonItemViewLeft_ShowGroupByBox.Checked,
                                                                                   ButtonItemViewLeft_ShowViewCaption.Checked, UserDefinedReportCategoryID, Nothing, _JobVersionTemplateCode, DynamicReport) Then

                        For Each GridColumn In DataGridViewForm_JobVersionReport.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(GC) GC.UnboundType = DevExpress.Data.UnboundColumnType.Bound).ToList

                            AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.Insert(ReportingDbContext, DynamicReport.ID, GridColumn.FieldName,
                                                                                              GridColumn.Caption, GridColumn.Visible, GridColumn.SortIndex,
                                                                                              GridColumn.SortOrder, GridColumn.GroupIndex, GridColumn.Width,
                                                                                              GridColumn.VisibleIndex, Nothing, Nothing)

                        Next

                        For Each GridGroupSummaryItem In DataGridViewForm_JobVersionReport.CurrentView.GroupSummary.OfType(Of DevExpress.XtraGrid.GridGroupSummaryItem)()

                            AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.Insert(ReportingDbContext, DynamicReport.ID, GridGroupSummaryItem.SummaryType,
                                                                                                   GridGroupSummaryItem.FieldName, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, False, True),
                                                                                                   GridGroupSummaryItem.DisplayFormat, IIf(GridGroupSummaryItem.ShowInGroupColumnFooter Is Nothing, "", GridGroupSummaryItem.ShowInGroupColumnFooter.FieldName),
                                                                                                   Nothing)

                        Next

                        For Each GridColumn In DataGridViewForm_JobVersionReport.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                            If GridColumn.SummaryItem IsNot Nothing AndAlso GridColumn.SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.None Then

                                AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.Insert(ReportingDbContext, DynamicReport.ID, GridColumn.SummaryItem.SummaryType,
                                                                                                       GridColumn.FieldName, False,
                                                                                                       GridColumn.SummaryItem.DisplayFormat, GridColumn.SummaryItem.FieldName,
                                                                                                       Nothing)

                            End If

                        Next

                        Me.Text = "Resource Allocation By Week Report - " & DynamicReport.Description
                        _DynamicReportID = DynamicReport.ID
                        _Description = DynamicReport.Description
                        _UserDefinedReportCategoryID = DynamicReport.UserDefinedReportCategoryID

                    End If

                End Using

            End If

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

                        GridColumn = DataGridViewForm_JobVersionReport.Columns(DynamicReportColumn.FieldName)

                        If GridColumn IsNot Nothing Then

                            GridColumn.Caption = DynamicReportColumn.HeaderText
                            GridColumn.Visible = DynamicReportColumn.IsVisible
                            GridColumn.SortIndex = DynamicReportColumn.SortIndex
                            GridColumn.SortOrder = DynamicReportColumn.SortOrder
                            GridColumn.GroupIndex = DynamicReportColumn.GroupIndex
                            GridColumn.Width = DynamicReportColumn.Width
                            GridColumn.VisibleIndex = DynamicReportColumn.VisibleIndex

                            If DynamicReportColumn.FieldName = "" Then

                            End If

                        End If

                    Next

                Else



                End If

            End Using

        End Sub
        Private Sub Loadweeks()
            Try
                Dim dt As DataTable
                dt = New DataTable
                dt.Columns.Add("Week")
                dt.Columns.Add("Value")

                Dim newrow As DataRow

                newrow = dt.NewRow
                newrow.Item("Week") = 1
                newrow.Item("Value") = 1
                dt.Rows.Add(newrow)

                newrow = dt.NewRow
                newrow.Item("Week") = 2
                newrow.Item("Value") = 2
                dt.Rows.Add(newrow)

                newrow = dt.NewRow
                newrow.Item("Week") = 3
                newrow.Item("Value") = 3
                dt.Rows.Add(newrow)

                newrow = dt.NewRow
                newrow.Item("Week") = 4
                newrow.Item("Value") = 4
                dt.Rows.Add(newrow)

                newrow = dt.NewRow
                newrow.Item("Week") = 5
                newrow.Item("Value") = 5
                dt.Rows.Add(newrow)

                newrow = dt.NewRow
                newrow.Item("Week") = 6
                newrow.Item("Value") = 6
                dt.Rows.Add(newrow)

                newrow = dt.NewRow
                newrow.Item("Week") = 7
                newrow.Item("Value") = 7
                dt.Rows.Add(newrow)

                newrow = dt.NewRow
                newrow.Item("Week") = 8
                newrow.Item("Value") = 8
                dt.Rows.Add(newrow)

                Me.ComboBox_Week.DataSource = dt

            Catch ex As Exception

            End Try
        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(ByVal DynamicReportID As Integer)

            'objects
            Dim SprintReportEditForm As AdvantageFramework.Reporting.Presentation.SprintReportEditForm = Nothing

            SprintReportEditForm = New AdvantageFramework.Reporting.Presentation.SprintReportEditForm(DynamicReportID)

            SprintReportEditForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub SprintReportEditForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True

            ButtonItemReport_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemReport_SaveAs.Image = AdvantageFramework.My.Resources.SaveAsImage

            ButtonItemPrinting_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemQuickCustomize_Columns.Image = AdvantageFramework.My.Resources.ColumnImage

            ButtonItemActions_View.Image = My.Resources.ReportImage

            DateTimePickerDateFrom_From.ReadOnly = True
            DateTimePickerDateTo_To.ReadOnly = True

            DateTimePickerDateFrom_From.ReadOnly = False
            DateTimePickerDateTo_To.ReadOnly = False

            DateTimePickerDateFrom_From.Value = Now
            DateTimePickerDateTo_To.Value = Now

            DateTimePickerStartingWeek.Value = Now

            'ComboBoxTemplates_Templates.SetRequired(True)

            ComboBoxTemplates_Templates.SelectedValue = 1

            Loadweeks()

            DataGridViewForm_JobVersionReport.DataSource = New System.Data.DataTable

            Me.Checkbox_LimitWIP.Checked = True

        End Sub
        Private Sub JobVersionReportEditForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            'objects
            Dim RibbonControl As DevComponents.DotNetBar.RibbonControl = Nothing

            ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked = DataGridViewForm_JobVersionReport.OptionsPrint.AutoWidth
            ButtonItemOptionsLeft_PrintFilterInfo.Checked = DataGridViewForm_JobVersionReport.OptionsPrint.PrintFilterInfo
            ButtonItemOptionsMiddle_PrintFooter.Checked = DataGridViewForm_JobVersionReport.OptionsPrint.PrintFooter
            ButtonItemOptionsMiddle_PrintGroupFooter.Checked = DataGridViewForm_JobVersionReport.OptionsPrint.PrintGroupFooter
            ButtonItemOptionsMiddle_PrintHeader.Checked = DataGridViewForm_JobVersionReport.OptionsPrint.PrintHeader
            ButtonItemOptionsRight_PrintSelectedRowsOnly.Checked = DataGridViewForm_JobVersionReport.OptionsPrint.PrintSelectedRowsOnly
            ButtonItemViewLeft_AllowCellMerging.Checked = DataGridViewForm_JobVersionReport.OptionsView.AllowCellMerge
            ButtonItemViewLeft_ShowGroupByBox.Checked = DataGridViewForm_JobVersionReport.OptionsView.ShowGroupPanel
            ButtonItemViewLeft_ShowViewCaption.Checked = DataGridViewForm_JobVersionReport.OptionsView.ShowViewCaption
            ButtonItemFilter_ShowAutoFilterRow.Checked = DataGridViewForm_JobVersionReport.OptionsView.ShowAutoFilterRow

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

                If AdvantageFramework.Reporting.Presentation.SprintReportUpdateDialog.ShowFormDialog(0, _Description, _UserDefinedReportCategoryID, True) = Windows.Forms.DialogResult.OK Then

                    Try

                        LoadGrid(CDate(Date.Now.ToShortDateString))

                        Me.Text = "Resource Allocation By Week Report - " & _Description

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

                DataGridViewForm_JobVersionReport.Columns.Clear()

                LoadGrid(CDate(DateTimePickerStartingWeek.Value.ToShortDateString))

            End If

        End Sub
        Private Sub ButtonItemDateFrom_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDateFrom_YTD.Click

            DateTimePickerDateTo_To.Value = Now
            DateTimePickerDateFrom_From.Value = New Date(Now.Year, 1, 1)

        End Sub
        Private Sub ButtonItemDateTo_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDateTo_MTD.Click

            'If Now.Month = 4 Or Now.Month = 9 Or Now.Month = 6 Or Now.Month = 11 Then
            '    DateTimePickerDateFrom_From.Value = New Date(Now.Year, Now.Month, 30)
            'End If
            'If Now.Month = 2 Then
            '    If DateTime.IsLeapYear(Now.Year) = True Then
            '        DateTimePickerDateFrom_From.Value = New Date(Now.Year, Now.Month, 29)
            '    Else
            '        DateTimePickerDateFrom_From.Value = New Date(Now.Year, Now.Month, 28)
            '    End If
            'End If
            'If Now.Month = 1 Or Now.Month = 3 Or Now.Month = 5 Or Now.Month = 7 Or Now.Month = 8 Or Now.Month = 10 Or Now.Month = 12 Then
            '    DateTimePickerDateFrom_From.Value = New Date(Now.Year, Now.Month, 31)
            'End If

            DateTimePickerDateTo_To.Value = Now
            DateTimePickerDateFrom_From.Value = New Date(Now.Year, Now.Month, 1)

        End Sub
        Private Sub ButtonItemDateFrom_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDateFrom_1Year.Click

            DateTimePickerDateTo_To.Value = Now
            DateTimePickerDateFrom_From.Value = Now.AddYears(-1)

        End Sub
        Private Sub ButtonItemDateTo_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDateTo_2Years.Click

            DateTimePickerDateTo_To.Value = Now
            DateTimePickerDateFrom_From.Value = Now.AddYears(-2)

        End Sub
        Private Sub DateTimePickerDateTo_To_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerDateTo_To.ValueChanged

            If DateTimePickerDateTo_To.Value < DateTimePickerDateFrom_From.Value Then
                DateTimePickerDateFrom_From.Value = DateTimePickerDateTo_To.Value
            End If
            'DateTimePickerDateFrom_From.MaxDate = DateTimePickerDateTo_To.Value

        End Sub
        Private Sub DateTimePickerDateFrom_From_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            If DateTimePickerDateFrom_From.Value > DateTimePickerDateTo_To.Value Then
                DateTimePickerDateTo_To.Value = DateTimePickerDateFrom_From.Value
            End If
            'DateTimePickerDateTo_To.MinDate = DateTimePickerDateFrom_From.Value

        End Sub
        Private Sub ButtonItemPrinting_Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemPrinting_Print.Click

            DataGridViewForm_JobVersionReport.Print(DefaultLookAndFeel.LookAndFeel, ComboBoxTemplates_Templates.Text)

        End Sub
        Private Sub ButtonItemOptionsLeft_AutoSizeColumnsToPage_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsLeft_AutoSizeColumnsToPage.CheckedChanged

            DataGridViewForm_JobVersionReport.OptionsPrint.AutoWidth = ButtonItemOptionsLeft_AutoSizeColumnsToPage.Checked

        End Sub
        Private Sub ButtonItemOptionsLeft_PrintFilterInfo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsLeft_PrintFilterInfo.CheckedChanged

            DataGridViewForm_JobVersionReport.OptionsPrint.PrintFilterInfo = ButtonItemOptionsLeft_PrintFilterInfo.Checked

        End Sub
        Private Sub ButtonItemOptionsMiddle_PrintFooter_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsMiddle_PrintFooter.CheckedChanged

            DataGridViewForm_JobVersionReport.OptionsPrint.PrintFooter = ButtonItemOptionsMiddle_PrintFooter.Checked

        End Sub
        Private Sub ButtonItemOptionsMiddle_PrintGroupFooter_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsMiddle_PrintGroupFooter.CheckedChanged

            DataGridViewForm_JobVersionReport.OptionsPrint.PrintGroupFooter = ButtonItemOptionsMiddle_PrintGroupFooter.Checked

        End Sub
        Private Sub ButtonItemOptionsMiddle_PrintHeader_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsMiddle_PrintHeader.CheckedChanged

            DataGridViewForm_JobVersionReport.OptionsPrint.PrintHeader = ButtonItemOptionsMiddle_PrintHeader.Checked

        End Sub
        Private Sub ButtonItemOptions_PrintSelectRowsOnly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOptionsRight_PrintSelectedRowsOnly.CheckedChanged

            DataGridViewForm_JobVersionReport.OptionsPrint.PrintSelectedRowsOnly = ButtonItemOptionsRight_PrintSelectedRowsOnly.Checked

        End Sub
        Private Sub ButtonItemViewLeft_AllowCellMerging_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemViewLeft_AllowCellMerging.CheckedChanged

            DataGridViewForm_JobVersionReport.OptionsView.AllowCellMerge = ButtonItemViewLeft_AllowCellMerging.Checked

        End Sub
        Private Sub ButtonItemViewLeft_ShowViewCaption_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemViewLeft_ShowViewCaption.CheckedChanged

            DataGridViewForm_JobVersionReport.OptionsView.ShowViewCaption = ButtonItemViewLeft_ShowViewCaption.Checked

        End Sub
        Private Sub ButtonItemViewLeft_ShowGroupByBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemViewLeft_ShowGroupByBox.CheckedChanged

            DataGridViewForm_JobVersionReport.OptionsView.ShowGroupPanel = ButtonItemViewLeft_ShowGroupByBox.Checked

        End Sub
        Private Sub ButtonItemQuickCustomize_Columns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemQuickCustomize_Columns.Click

            'objects
            Dim DynamicReportColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing
            Dim DynamicReportColumn As AdvantageFramework.Database.Classes.DynamicReportColumn = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            DynamicReportColumnsList = New Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn)

            For Each GridColumn In DataGridViewForm_JobVersionReport.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(Column) Column.OptionsColumn.AllowShowHide = True)

                DynamicReportColumn = New AdvantageFramework.Database.Classes.DynamicReportColumn

                DynamicReportColumn.FieldName = GridColumn.FieldName
                DynamicReportColumn.HeaderText = GridColumn.ToString
                DynamicReportColumn.IsVisible = GridColumn.Visible

                DynamicReportColumnsList.Add(DynamicReportColumn)

            Next

            If AdvantageFramework.Desktop.Presentation.DynamicReportColumnEditDialog.ShowFormDialog(DynamicReportColumnsList) = Windows.Forms.DialogResult.OK Then

                For Each DynamicReportColumn In DynamicReportColumnsList

                    GridColumn = DataGridViewForm_JobVersionReport.CurrentView.Columns(DynamicReportColumn.FieldName)

                    If GridColumn IsNot Nothing Then

                        GridColumn.Caption = DynamicReportColumn.HeaderText
                        GridColumn.Visible = DynamicReportColumn.IsVisible

                    End If

                Next

            End If

        End Sub
        Private Sub ButtonItemFilter_ShowAutoFilterRow_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemFilter_ShowAutoFilterRow.CheckedChanged, ButtonItemFilter_ShowAutoFilterRow.CheckedChanged

            DataGridViewForm_JobVersionReport.CurrentView.OptionsView.ShowAutoFilterRow = ButtonItemFilter_ShowAutoFilterRow.Checked

        End Sub
        Private Sub ButtonItemFilter_ShowFilterEditor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemFilter_ShowFilterEditor.Click

            If DataGridViewForm_JobVersionReport.CurrentView.FocusedColumn IsNot Nothing AndAlso DataGridViewForm_JobVersionReport.CurrentView.FocusedColumn.VisibleIndex <> -1 Then

                DataGridViewForm_JobVersionReport.CurrentView.ShowFilterEditor(DataGridViewForm_JobVersionReport.CurrentView.FocusedColumn)

            Else

                DataGridViewForm_JobVersionReport.CurrentView.ShowFilterEditor(DataGridViewForm_JobVersionReport.CurrentView.VisibleColumns(0))

            End If

        End Sub

        Private Sub DataGridViewForm_JobVersionReport_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_JobVersionReport.DataSourceChangedEvent
            'For Each Column In DataGridViewForm_JobVersionReport.Columns

            'If Column IsNot Nothing Then

            '    If Column.FieldName = "DirectHoursGoal" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "BillableHoursGoal" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "PercentDirect" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "PercentNonDirect" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "PercentOfRequiredHours" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "PercentOfDirectHoursGoal" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "PercentOfBillableHoursGoal" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "PercentBilled" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "PercentBilledOfDirectHoursGoal" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "PercentBilledOfBillableHoursGoal" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "PercentBilledOfRequiredHours" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "AverageHourlyRateBilled" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "AverageHourlyRateAchieved" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If



            '    If Column.FieldName = "RequiredHours" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "BillableHours" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "BillableAmount" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "NonBillableHours" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "NonBillableAmount" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If

            '    If Column.FieldName = "AgencyHours" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "AgencyAmount" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "NewBusinessHours" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "NewBusinessAmount" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "TotalDirectHours" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "TotalDirectAmount" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "NonDirectHours" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "TotalHours" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "Variance" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "BilledHours" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If


            '    If Column.FieldName = "BilledHours" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "BilledAmount" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "WIPHours" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "WIPAmount" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If
            '    If Column.FieldName = "WriteUpDownAmount" Then
            '        Column.DisplayFormat.FormatString = "n2"
            '        Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            '    End If

            'End If

            'Next
        End Sub

        Private Sub ComboBox_Week_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Week.SelectedIndexChanged
        End Sub

        Private Sub DateTimePickerStartingWeek_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerStartingWeek.ValueChanged
            Try
                Dim FirstDayOfWeekDate As Date

                For i As Integer = 0 To 6 Step 1

                    FirstDayOfWeekDate = CDate(DateTimePickerStartingWeek.Value).AddDays(-i)

                    If FirstDayOfWeekDate.DayOfWeek = DayOfWeek.Sunday Then

                        Exit For

                    End If

                Next

                Me.DateTimePickerStartingWeek.Value = FirstDayOfWeekDate

            Catch ex As Exception

            End Try
        End Sub


#End Region

#End Region

    End Class

End Namespace
