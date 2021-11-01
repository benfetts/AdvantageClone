Namespace Reporting.Presentation

    Public Class JobVersionReportEditForm

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
        Private Sub LoadGrid(ByVal JobTemplateCode As String, ByVal DateFrom As Date, ByVal DateTo As Date, ByVal DateType As Short, ByVal ShowClosedJobs As Boolean)

            Try

                DataGridViewForm_JobVersionReport.DataSource = LoadJobVersionReportDataTable(JobTemplateCode, DateFrom, DateTo, DateType, ShowClosedJobs)

                Me.DataGridViewForm_JobVersionReport.CurrentView.ViewCaption = Me.DataGridViewForm_JobVersionReport.CurrentView.RowCount & " " & Me.ComboBoxTemplates_Templates.SelectedItem.Description & " Report(s)"

            Catch ex As Exception
                DataGridViewForm_JobVersionReport.DataSource = Nothing
            End Try

        End Sub
        Private Function LoadJobVersionReportDataTable(ByVal JobTemplateCode As String, ByVal DateFrom As Date, ByVal DateTo As Date, ByVal DateType As Short, ByVal ShowClosedJobs As Boolean) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    Using SqlCommand = DbContext.CreateCommand()

                        DataTable = New System.Data.DataTable

                        SqlCommand.CommandType = CommandType.StoredProcedure
                        SqlCommand.CommandText = "advsp_job_versions"

                        SqlCommand.Parameters.AddWithValue("jv_tmplt_code", JobTemplateCode)
                        SqlCommand.Parameters.AddWithValue("date_from", CDate(DateFrom.ToShortDateString))
                        SqlCommand.Parameters.AddWithValue("date_to", CDate(DateTo.ToShortDateString))
                        SqlCommand.Parameters.AddWithValue("date_type", CShort(DateType))
                        SqlCommand.Parameters.AddWithValue("show_closed_jobs", If(ShowClosedJobs, 1, 0))
                        SqlCommand.Parameters.AddWithValue("UserID", Session.User.UserCode)

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

            LoadJobVersionReportDataTable = DataTable

            Me.DataGridViewForm_JobVersionReport.OptionsView.ShowFooter = True
            Me.DataGridViewForm_JobVersionReport.CurrentView.OptionsView.ShowFooter = True

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

                    ComboBoxTemplates_Templates.SelectedValue = DynamicReport.TemplateCode

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

                    Me.Text = "Job Version Report - " & DynamicReport.Description

                    _Description = DynamicReport.Description
                    _UserDefinedReportCategoryID = DynamicReport.UserDefinedReportCategoryID

                    LoadGrid(ComboBoxTemplates_Templates.GetSelectedValue, CDate("01/01/1900"), CDate("01/01/1900"), CShort(0), False)

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

                    Me.Text = "Job Version Report"

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

                DynamicReport.Type = AdvantageFramework.Reporting.DynamicReports.JobVersion
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

                    Me.Text = "Job Version Report - " & DynamicReport.Description
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

            If AdvantageFramework.Reporting.Presentation.JobVersionReportUpdateDialog.ShowFormDialog(0, _JobVersionTemplateCode, Description, UserDefinedReportCategoryID, False) = System.Windows.Forms.DialogResult.OK Then

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Insert(ReportingDbContext, AdvantageFramework.Reporting.DynamicReports.JobVersion, Description, ReportingDbContext.UserCode, Now,
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

                        Me.Text = "Job Version Report - " & DynamicReport.Description
                        _DynamicReportID = DynamicReport.ID
                        _Description = DynamicReport.Description
                        _UserDefinedReportCategoryID = DynamicReport.UserDefinedReportCategoryID

                    End If

                End Using

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(ByVal DynamicReportID As Integer)

            'objects
            Dim JobVersionReportEditForm As AdvantageFramework.Reporting.Presentation.JobVersionReportEditForm = Nothing

            JobVersionReportEditForm = New AdvantageFramework.Reporting.Presentation.JobVersionReportEditForm(DynamicReportID)

            JobVersionReportEditForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub JobVersionReportEditForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True

            ButtonItemReport_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemReport_SaveAs.Image = AdvantageFramework.My.Resources.SaveAsImage

            ButtonItemPrinting_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemQuickCustomize_Columns.Image = AdvantageFramework.My.Resources.ColumnImage

            ButtonItemActions_ShowClosedJobs.Image = My.Resources.JobJacketImage
            ButtonItemActions_View.Image = My.Resources.ReportImage

            DateTimePickerDateFrom_From.ReadOnly = True
            DateTimePickerDateTo_To.ReadOnly = True

            DateTimePickerDateFrom_From.ReadOnly = False
            DateTimePickerDateTo_To.ReadOnly = False

            DateTimePickerDateFrom_From.Value = Now
            DateTimePickerDateTo_To.Value = Now

            ComboBoxTemplates_Templates.SetRequired(True)
            ComboBoxTemplates_Templates.Enabled = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxTemplates_Templates.DataSource = AdvantageFramework.Database.Procedures.JobVersionTemplate.LoadAllActive(DbContext).OrderBy(Function(Entity) Entity.Description)

            End Using

            ComboBoxCriteria_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobVersionInitialCriteria), False)

            DataGridViewForm_JobVersionReport.DataSource = New System.Data.DataTable

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

                If AdvantageFramework.Reporting.Presentation.JobVersionReportUpdateDialog.ShowFormDialog(0, _JobVersionTemplateCode, _Description, _UserDefinedReportCategoryID, True) = Windows.Forms.DialogResult.OK Then

                    Try

                        If String.IsNullOrEmpty(_JobVersionTemplateCode) = False Then

                            ComboBoxTemplates_Templates.SelectedValue = _JobVersionTemplateCode

                            LoadGrid(ComboBoxTemplates_Templates.GetSelectedValue, CDate("01/01/1900"), CDate("01/01/1900"), CShort(0), False)

                        End If

                        Me.Text = "Job Version Report - " & _Description

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

            If String.IsNullOrEmpty(_JobVersionTemplateCode) = False Then

                SaveDynamicReportTemplate()

            End If

        End Sub
        Private Sub ButtonItemReport_SaveAs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemReport_SaveAs.Click

            If String.IsNullOrEmpty(_JobVersionTemplateCode) = False Then

                SaveAsDynamicReportTemplate()

            End If

        End Sub
        Private Sub ButtonItemActions_View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_View.Click

            If Me.Validator Then

                LoadGrid(ComboBoxTemplates_Templates.GetSelectedValue, CDate(DateTimePickerDateFrom_From.Value.ToShortDateString), _
                         CDate(DateTimePickerDateTo_To.Value.ToShortDateString), CShort(ComboBoxCriteria_Criteria.GetSelectedValue), _
                         ButtonItemActions_ShowClosedJobs.Checked)

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
        Private Sub ComboBoxTemplates_Templates_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxTemplates_Templates.SelectedValueChanged

            If ComboBoxTemplates_Templates.HasASelectedValue Then

                _JobVersionTemplateCode = ComboBoxTemplates_Templates.GetSelectedValue

            Else

                _JobVersionTemplateCode = ""

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
