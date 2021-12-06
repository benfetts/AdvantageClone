Imports DevExpress.DashboardWeb
Imports DevExpress.Web
Imports Telerik.Web.UI

Public Class Reporting_DynamicReportEdit
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Protected _DynamicReportTemplateID As Integer = 0
    Protected _DynamicReportType As Integer = 0
    Protected _DynamicReportShowGroupByBox As Boolean = False
    Protected _DynamicReportShowViewCaption As Boolean = False
    Protected _DynamicReportShowAutoFilterRow As Boolean = False
    Protected _DynamicReportActiveFilter As String = ""
    Protected _UserDefinedReportCategoryID As Nullable(Of Integer) = Nothing
    Protected _DynamicReportDescription As String = ""
    Protected _ViewOnly As Boolean = False
    Protected WithEvents LabelUpdate As System.Web.UI.WebControls.Label
    Public _Reload As Boolean = True

#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

#End Region

#Region " Methods "

    Private Sub FormatColumns(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal FirstLoad As Boolean)

        'objects
        Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
        Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
        Dim ObjectType As System.Type = Nothing
        Dim DefaultSort As String = ""
        Dim DynamicReportTemplateColumn As AdvantageFramework.Web.Presentation.Controls.DynamicReportTemplateColumn = Nothing
        Dim DynamicReportUnboundColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportUnboundColumn = Nothing

        If ASPxGridViewDynamicReport.Columns.Count > 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        DefaultSort = AdvantageFramework.Reporting.LoadDynamicReportDefaultSort(RadComboBoxDynamicReport.SelectedValue)

                    Catch ex As Exception
                        DefaultSort = ""
                    End Try

                    ObjectType = AdvantageFramework.Reporting.LoadDynamicReportObjectType(DynamicReport)

                    For Each GridViewColumn In ASPxGridViewDynamicReport.Columns.OfType(Of DevExpress.Web.GridViewDataColumn)()

                        GridViewColumn.Settings.AllowGroup = DevExpress.Utils.DefaultBoolean.True
                        GridViewColumn.Settings.AllowSort = DevExpress.Utils.DefaultBoolean.True

                        Try

                            PropertyDescriptor = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(ObjectType).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                                  Where [Property].Name = GridViewColumn.FieldName
                                                  Select [Property]).SingleOrDefault

                        Catch ex As Exception
                            PropertyDescriptor = Nothing
                        End Try

                        If PropertyDescriptor IsNot Nothing Then

                            If Not (PropertyDescriptor.PropertyType Is GetType(System.Boolean) OrElse PropertyDescriptor.PropertyType Is GetType(System.Nullable(Of System.Boolean))) Then

                                DynamicReportTemplateColumn = New AdvantageFramework.Web.Presentation.Controls.DynamicReportTemplateColumn(GridViewColumn.FieldName)

                                GridViewColumn.DataItemTemplate = DynamicReportTemplateColumn

                            End If

                            If PropertyDescriptor.PropertyType.Name.Contains("ICollection") AndAlso PropertyDescriptor.PropertyType.BaseType IsNot Nothing AndAlso
                                    PropertyDescriptor.PropertyType.BaseType.Name.Contains("Entity") Then

                                ASPxGridViewDynamicReport.Columns.Remove(GridViewColumn)

                            Else

                                Try

                                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                                Catch ex As Exception
                                    EntityAttribute = Nothing
                                Finally

                                    If EntityAttribute IsNot Nothing Then

                                        If EntityAttribute.DisplayFormat <> "" Then

                                            DynamicReportTemplateColumn.DisplayFormat = EntityAttribute.DisplayFormat

                                        End If

                                        GridViewColumn.ReadOnly = EntityAttribute.IsReadOnlyColumn

                                        If EntityAttribute.ShowColumnInGrid = False Then

                                            GridViewColumn.VisibleIndex = -1

                                        End If

                                        GridViewColumn.ShowInCustomizationForm = EntityAttribute.ShowColumnInGrid

                                        If EntityAttribute.ShowColumnInGrid Then

                                            GridViewColumn.Settings.ShowFilterRowMenu = DevExpress.Utils.DefaultBoolean.True
                                            GridViewColumn.Settings.ShowInFilterControl = DevExpress.Utils.DefaultBoolean.True

                                        Else

                                            GridViewColumn.Settings.ShowFilterRowMenu = DevExpress.Utils.DefaultBoolean.False
                                            GridViewColumn.Settings.ShowInFilterControl = DevExpress.Utils.DefaultBoolean.False

                                        End If

                                        If FirstLoad Then

                                            If EntityAttribute.CustomColumnCaption <> "" Then

                                                GridViewColumn.Caption = EntityAttribute.CustomColumnCaption

                                            End If

                                        End If

                                    End If

                                End Try

                                If FirstLoad Then

                                    If GridViewColumn.Caption = "" Then

                                        GridViewColumn.Caption = AdvantageFramework.StringUtilities.GetNameAsWords(GridViewColumn.FieldName)

                                    End If

                                    If GridViewColumn.FieldName = DefaultSort Then

                                        GridViewColumn.SortAscending()

                                    End If

                                    If DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobSummary OrElse
                                                DynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectSchedule OrElse
                                                DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobProjectScheduleSummary OrElse
                                                DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetail OrElse
                                                DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth OrElse
                                                DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction OrElse
                                                DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailItem OrElse
                                                DynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectHoursUsed OrElse
                                                DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobPurchaseOrder OrElse
                                                DynamicReport = AdvantageFramework.Reporting.DynamicReports.EstimatedAndActualIncome OrElse
                                                DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailItemAccountSplit OrElse
                                                DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByFunction OrElse
                                                DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob OrElse
                                                DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJobComponent OrElse
                                                DynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectScheduleTasksByEmployee OrElse
                                                DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByFunctionMinimized OrElse
                                                DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob1Minimized OrElse
                                                DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob2Minimized Then

                                        If GridViewColumn.FieldName.StartsWith("LabelAssign") OrElse
                                                GridViewColumn.FieldName.StartsWith("LabelFromUDFTable") OrElse
                                                GridViewColumn.FieldName.StartsWith("CompLabelFromUDFTable") Then

                                            GridViewColumn.Visible = AdvantageFramework.Reporting.LoadDynamicColumnHeader(DbContext, GridViewColumn.FieldName,
                                                                                                                          GridViewColumn.Caption, False,
                                                                                                                          GridViewColumn.ShowInCustomizationForm, False,
                                                                                                                          GridViewColumn.Settings.ShowFilterRowMenu,
                                                                                                                          GridViewColumn.Settings.ShowInFilterControl)

                                        End If

                                    End If

                                End If

                            End If

                        Else

                            Try

                                DynamicReportUnboundColumn = AdvantageFramework.Reporting.Database.Procedures.DynamicReportUnboundColumn.LoadByDynamicReportID(ReportingDbContext, _DynamicReportTemplateID).SingleOrDefault(Function(Entity) Entity.FieldName = GridViewColumn.FieldName)

                            Catch ex As Exception
                                DynamicReportUnboundColumn = Nothing
                            End Try

                            If DynamicReportUnboundColumn IsNot Nothing Then

                                If GridViewColumn.UnboundType <> DevExpress.Data.UnboundColumnType.Boolean Then

                                    DynamicReportTemplateColumn = New AdvantageFramework.Web.Presentation.Controls.DynamicReportTemplateColumn(GridViewColumn.FieldName)

                                    If String.IsNullOrEmpty(DynamicReportUnboundColumn.Format) = False Then

                                        If GridViewColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal Then

                                            DynamicReportTemplateColumn.DisplayFormat = DynamicReportUnboundColumn.Format

                                        End If

                                    End If

                                    GridViewColumn.DataItemTemplate = DynamicReportTemplateColumn

                                End If

                            End If

                        End If

                    Next

                End Using

            End Using

        End If

    End Sub
    Private Sub LoadReportData(ByVal DynamicReportType As AdvantageFramework.Reporting.DynamicReports, ByVal FirstLoad As Boolean, ByVal BlankData As Boolean)

        'objects
        Dim SummaryItem As DevExpress.Web.ASPxSummaryItem = Nothing
        Dim GridViewColumn As DevExpress.Web.GridViewColumn = Nothing
        Dim GridViewDataColumn As DevExpress.Web.GridViewDataColumn = Nothing
        Dim DynamicReportTemplateColumn As AdvantageFramework.Web.Presentation.Controls.DynamicReportTemplateColumn = Nothing
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
        Dim DynamicReportColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing
        Dim ReportColumns As Generic.List(Of AdvantageFramework.Reporting.Classes.ReportColumn) = Nothing
        Dim DynamicReportData As IEnumerable = Nothing

        If DynamicReportType > 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetail OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailItem OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction Then

                        ReportColumns = New Generic.List(Of AdvantageFramework.Reporting.Classes.ReportColumn)

                        ReportColumns.Add(New AdvantageFramework.Reporting.Classes.ReportColumn With {.Index = -1, .ColumnName = "ID", .ReportColumnType = AdvantageFramework.Reporting.ReportColumnType.JobDetailItem})

                        'If Session("DRPT_ColumnsList") Is Nothing Then

                        For Each GridColumn In ASPxGridViewDynamicReport.VisibleColumns.OfType(Of DevExpress.Web.GridViewDataColumn).ToList

                            If GridColumn.UnboundType = DevExpress.Data.UnboundColumnType.Bound Then

                                ReportColumns.Add(New AdvantageFramework.Reporting.Classes.ReportColumn With {.Index = GridColumn.Index, .ColumnName = GridColumn.FieldName, .ReportColumnType = AdvantageFramework.Reporting.ReportColumnType.JobDetailItem})

                            End If

                        Next

                        'Else

                        '    DynamicReportColumnsList = Session("DRPT_ColumnsList")

                        '    For Each DynamicReportColumnClass In DynamicReportColumnsList.Where(Function(Entity) Entity.IsVisible).ToList

                        '        ReportColumns.Add(New AdvantageFramework.Reporting.Classes.ReportColumn With {.Index = DynamicReportColumnClass.VisibleIndex, .ColumnName = DynamicReportColumnClass.FieldName, .ReportColumnType = AdvantageFramework.Reporting.ReportColumnType.JobDetailItem})

                        '    Next

                        'End If

                    End If

                    ASPxGridViewDynamicReport.AutoGenerateColumns = True
                    DynamicReportData = AdvantageFramework.Reporting.LoadDynamicReportData(DbContext, ReportingDbContext, DynamicReportType, BlankData, Session("DRPT_Criteria"), Session("DRPT_FilterString"),
                                                                                           Session("DRPT_From"), Session("DRPT_To"), Session("DRPT_ShowJobsWithNoDetails"), Session("DRPT_ParameterDictionary"), ReportColumns)

                    ASPxGridViewDynamicReport.DataSource = DynamicReportData
                    ASPxGridViewDynamicReport.KeyFieldName = AdvantageFramework.Reporting.LoadDynamicReportKeyExpression(DynamicReportType)
                    ASPxGridViewDynamicReport.DataBind()

                    Session("DRPT_Data") = DynamicReportData

                    Me.FormatColumns(DynamicReportType, FirstLoad)

                    If FirstLoad AndAlso _DynamicReportTemplateID > 0 Then

                        For Each DynamicReportUnboundColumn In AdvantageFramework.Reporting.Database.Procedures.DynamicReportUnboundColumn.LoadByDynamicReportID(ReportingDbContext, _DynamicReportTemplateID).OrderBy(Function(Column) Column.VisibleIndex).ToList

                            GridViewDataColumn = New DevExpress.Web.GridViewDataColumn

                            If ASPxGridViewDynamicReport.Columns.OfType(Of DevExpress.Web.GridViewDataColumn).Any(Function(GVC) GVC.FieldName = DynamicReportUnboundColumn.FieldName) = False Then

                                GridViewDataColumn.FieldName = DynamicReportUnboundColumn.FieldName
                                GridViewDataColumn.Caption = DynamicReportUnboundColumn.HeaderText
                                GridViewDataColumn.Visible = DynamicReportUnboundColumn.IsVisible
                                GridViewDataColumn.SortIndex = DynamicReportUnboundColumn.SortIndex
                                GridViewDataColumn.SortOrder = DynamicReportUnboundColumn.SortOrder
                                GridViewDataColumn.GroupIndex = DynamicReportUnboundColumn.GroupIndex
                                GridViewDataColumn.Width = DynamicReportUnboundColumn.Width
                                GridViewDataColumn.VisibleIndex = DynamicReportUnboundColumn.VisibleIndex
                                GridViewDataColumn.UnboundType = DynamicReportUnboundColumn.UnboundType
                                GridViewDataColumn.UnboundExpression = DynamicReportUnboundColumn.Expression

                                If GridViewDataColumn.UnboundType <> DevExpress.Data.UnboundColumnType.Boolean Then

                                    DynamicReportTemplateColumn = New AdvantageFramework.Web.Presentation.Controls.DynamicReportTemplateColumn(GridViewDataColumn.FieldName)

                                    If String.IsNullOrEmpty(DynamicReportUnboundColumn.Format) = False Then

                                        If GridViewDataColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal Then

                                            DynamicReportTemplateColumn.DisplayFormat = DynamicReportUnboundColumn.Format

                                        End If

                                    End If

                                    GridViewDataColumn.DataItemTemplate = DynamicReportTemplateColumn

                                End If

                                ASPxGridViewDynamicReport.Columns.Add(GridViewDataColumn)

                                GridViewDataColumn.VisibleIndex = DynamicReportUnboundColumn.VisibleIndex

                            End If

                        Next

                        Try

                            DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _DynamicReportTemplateID)

                            If Session("DRPT_ColumnsList") Is Nothing Then

                                For Each DynamicReportColumn In DynamicReport.DynamicReportColumns.OrderBy(Function(Column) Column.VisibleIndex).ToList

                                    GridViewColumn = ASPxGridViewDynamicReport.Columns(DynamicReportColumn.FieldName)

                                    If GridViewColumn IsNot Nothing Then

                                        GridViewColumn.Caption = DynamicReportColumn.HeaderText

                                    End If

                                Next

                            Else

                                DynamicReportColumnsList = Session("DRPT_ColumnsList")

                                For Each DynamicReportColumnClass In DynamicReportColumnsList

                                    GridViewColumn = ASPxGridViewDynamicReport.Columns(DynamicReportColumnClass.FieldName)

                                    If GridViewColumn IsNot Nothing Then

                                        GridViewColumn.Caption = DynamicReportColumnClass.HeaderText

                                    End If

                                Next

                            End If

                        Catch ex As Exception

                        End Try

                        For Each DynamicReportSummaryItem In AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.LoadByDynamicReportID(ReportingDbContext, _DynamicReportTemplateID).ToList

                            If DynamicReportSummaryItem.OnFooter = False AndAlso String.IsNullOrWhiteSpace(DynamicReportSummaryItem.ColumnName) = False Then

                                Try

                                    GridViewDataColumn = ASPxGridViewDynamicReport.Columns(DynamicReportSummaryItem.FieldName)

                                Catch ex As Exception
                                    GridViewDataColumn = Nothing
                                End Try

                                If GridViewDataColumn IsNot Nothing Then

                                    SummaryItem = New DevExpress.Web.ASPxSummaryItem

                                    SummaryItem.ShowInColumn = DynamicReportSummaryItem.ColumnName
                                    SummaryItem.FieldName = DynamicReportSummaryItem.FieldName
                                    SummaryItem.SummaryType = DynamicReportSummaryItem.SummaryItemType
                                    SummaryItem.DisplayFormat = DynamicReportSummaryItem.DisplayFormat

                                    ASPxGridViewDynamicReport.TotalSummary.Add(SummaryItem)

                                    If ASPxGridViewDynamicReport.Settings.ShowFooter = False Then

                                        ASPxGridViewDynamicReport.Settings.ShowFooter = True

                                    End If

                                End If

                            Else

                                If DynamicReportSummaryItem.OnFooter Then

                                    If ASPxGridViewDynamicReport.Columns(DynamicReportSummaryItem.ColumnName) IsNot Nothing Then

                                        SummaryItem = New DevExpress.Web.ASPxSummaryItem

                                        SummaryItem.ShowInGroupFooterColumn = DynamicReportSummaryItem.ColumnName
                                        SummaryItem.FieldName = DynamicReportSummaryItem.FieldName
                                        SummaryItem.SummaryType = DynamicReportSummaryItem.SummaryItemType
                                        SummaryItem.DisplayFormat = DynamicReportSummaryItem.DisplayFormat

                                        ASPxGridViewDynamicReport.GroupSummary.Add(SummaryItem)

                                    End If

                                Else

                                    SummaryItem = New DevExpress.Web.ASPxSummaryItem

                                    SummaryItem.FieldName = DynamicReportSummaryItem.FieldName
                                    SummaryItem.SummaryType = DynamicReportSummaryItem.SummaryItemType
                                    SummaryItem.DisplayFormat = DynamicReportSummaryItem.DisplayFormat

                                    ASPxGridViewDynamicReport.GroupSummary.Add(SummaryItem)

                                End If

                            End If

                        Next

                    End If

                End Using

            End Using

        End If

    End Sub
    Private Sub ClearReportData()

        ASPxGridViewDynamicReport.ClearSort()
        ASPxGridViewDynamicReport.GroupSummary.Clear()
        ASPxGridViewDynamicReport.GroupSummarySortInfo.Clear()
        ASPxGridViewDynamicReport.FilterExpression = ""

        ASPxGridViewDynamicReport.DataSource = Nothing
        ASPxGridViewDynamicReport.KeyFieldName = ""

        If ASPxGridViewDynamicReport.Columns.Count > 0 Then

            ASPxGridViewDynamicReport.Columns.Clear()

        End If

    End Sub
    Private Sub LoadDynamicReport()

        'objects
        Dim DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing
        Dim ClearData As Boolean = False

        If RadComboBoxDynamicReport.SelectedIndex = 0 Then

            ClearData = True

        Else

            If AdvantageFramework.EnumUtilities.IsMemberOfEnum(GetType(AdvantageFramework.Reporting.DynamicReports), CInt(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.DynamicReports), RadComboBoxDynamicReport.SelectedValue))) Then

                DynamicReport = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.DynamicReports), RadComboBoxDynamicReport.SelectedValue)

            Else

                ClearData = True

            End If

        End If

        ClearReportData()

        If ClearData Then

            RadToolBarButtonSave.Enabled = False
            RadToolBarButtonSaveAs.Enabled = False

        Else

            LoadReportData(DynamicReport, True, Session("DRPT_UseBlankData"))

            RadToolBarButtonSave.Enabled = Not _ViewOnly
            RadToolBarButtonSaveAs.Enabled = Not _ViewOnly

        End If

    End Sub
    Private Sub SaveDynamicReportTemplate(ByRef ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByRef DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport)

        'objects
        Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing
        Dim DynamicReportSummaryItem As AdvantageFramework.Reporting.Database.Entities.DynamicReportSummaryItem = Nothing
        Dim DynamicReportUnboundColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportUnboundColumn = Nothing

        DynamicReport.Type = RadComboBoxDynamicReport.SelectedValue
        DynamicReport.ShowGroupByBox = RadToolBarButtonShowGroupByBox.Checked
        DynamicReport.ShowViewCaption = RadToolBarButtonShowViewCaption.Checked
        DynamicReport.ShowAutoFilterRow = RadToolBarButtonShowAutoFilterRow.Checked
        DynamicReport.ActiveFilter = ASPxGridViewDynamicReport.FilterExpression

        DynamicReport.UpdatedByUserCode = ReportingDbContext.UserCode
        DynamicReport.UpdatedDate = Now

        If AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Update(ReportingDbContext, DynamicReport) Then

            For Each GridViewColumn In ASPxGridViewDynamicReport.Columns.OfType(Of DevExpress.Web.GridViewDataColumn)()

                If GridViewColumn.UnboundType = DevExpress.Data.UnboundColumnType.Bound Then

                    DynamicReportColumn = AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.LoadByDynamicReportIDAndFieldName(ReportingDbContext, DynamicReport.ID, GridViewColumn.FieldName)

                    If DynamicReportColumn IsNot Nothing Then

                        DynamicReportColumn.HeaderText = GridViewColumn.Caption
                        DynamicReportColumn.IsVisible = GridViewColumn.Visible
                        DynamicReportColumn.SortIndex = GridViewColumn.SortIndex
                        DynamicReportColumn.SortOrder = GridViewColumn.SortOrder
                        DynamicReportColumn.GroupIndex = GridViewColumn.GroupIndex
                        DynamicReportColumn.Width = GridViewColumn.Width.Value

                        If DynamicReportColumn.IsVisible AndAlso DynamicReportColumn.Width = 0 Then

                            DynamicReportColumn.Width = 100

                        End If

                        If GridViewColumn.Visible AndAlso GridViewColumn.GroupIndex = -1 Then

                            DynamicReportColumn.VisibleIndex = ASPxGridViewDynamicReport.VisibleColumns.IndexOf(GridViewColumn)

                        Else

                            DynamicReportColumn.VisibleIndex = -1

                        End If

                        AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.Update(ReportingDbContext, DynamicReportColumn)

                    Else

                        AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.Insert(ReportingDbContext, DynamicReport.ID, GridViewColumn.FieldName,
                                                                                              GridViewColumn.Caption, GridViewColumn.Visible, GridViewColumn.SortIndex,
                                                                                              GridViewColumn.SortOrder, GridViewColumn.GroupIndex, GridViewColumn.Width.Value,
                                                                                              If(GridViewColumn.Visible, ASPxGridViewDynamicReport.VisibleColumns.IndexOf(GridViewColumn), -1), Nothing, Nothing)

                    End If

                Else

                    DynamicReportUnboundColumn = AdvantageFramework.Reporting.Database.Procedures.DynamicReportUnboundColumn.LoadByDynamicReportIDAndFieldName(ReportingDbContext, DynamicReport.ID, GridViewColumn.FieldName)

                    If DynamicReportUnboundColumn IsNot Nothing Then

                        DynamicReportUnboundColumn.HeaderText = GridViewColumn.Caption
                        DynamicReportUnboundColumn.IsVisible = GridViewColumn.Visible
                        DynamicReportUnboundColumn.SortIndex = GridViewColumn.SortIndex
                        DynamicReportUnboundColumn.SortOrder = GridViewColumn.SortOrder
                        DynamicReportUnboundColumn.GroupIndex = GridViewColumn.GroupIndex
                        DynamicReportUnboundColumn.Width = GridViewColumn.Width.Value

                        If DynamicReportUnboundColumn.IsVisible AndAlso DynamicReportUnboundColumn.Width = 0 Then

                            DynamicReportUnboundColumn.Width = 100

                        End If

                        If GridViewColumn.Visible AndAlso GridViewColumn.GroupIndex = -1 Then

                            DynamicReportUnboundColumn.VisibleIndex = ASPxGridViewDynamicReport.VisibleColumns.IndexOf(GridViewColumn)

                        Else

                            DynamicReportUnboundColumn.VisibleIndex = -1

                        End If

                        AdvantageFramework.Reporting.Database.Procedures.DynamicReportUnboundColumn.Update(ReportingDbContext, DynamicReportUnboundColumn)

                    End If

                End If

            Next

            Me.Title = "Report Writer - " & DynamicReport.Description

            'Response.Redirect([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", DynamicReport.ID))

        End If

    End Sub
    Private Sub SaveNewDynamicReportTemplate(ByRef ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext)

        'objects
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
        Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing
        Dim DynamicReportSummaryItem As AdvantageFramework.Reporting.Database.Entities.DynamicReportSummaryItem = Nothing

        DynamicReport = New AdvantageFramework.Reporting.Database.Entities.DynamicReport

        DynamicReport.Description = _DynamicReportDescription
        DynamicReport.UserDefinedReportCategoryID = _UserDefinedReportCategoryID
        DynamicReport.Type = RadComboBoxDynamicReport.SelectedValue
        DynamicReport.ShowGroupByBox = RadToolBarButtonShowGroupByBox.Checked
        DynamicReport.ShowViewCaption = RadToolBarButtonShowViewCaption.Checked
        DynamicReport.ShowAutoFilterRow = RadToolBarButtonShowAutoFilterRow.Checked
        DynamicReport.ActiveFilter = ASPxGridViewDynamicReport.FilterExpression

        DynamicReport.AllowCellMerge = False
        DynamicReport.AutoSizeColumnsWhenPrinting = False
        DynamicReport.PrintHeader = False
        DynamicReport.PrintFooter = False
        DynamicReport.PrintGroupFooter = False
        DynamicReport.PrintSelectedRowsOnly = False
        DynamicReport.PrintFilterInformation = False

        DynamicReport.CreatedByUserCode = ReportingDbContext.UserCode
        DynamicReport.CreatedDate = Now

        DynamicReport.UpdatedByUserCode = ReportingDbContext.UserCode
        DynamicReport.UpdatedDate = Now

        If AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Insert(ReportingDbContext, DynamicReport) Then

            For Each GridViewColumn In ASPxGridViewDynamicReport.Columns.OfType(Of DevExpress.Web.GridViewDataColumn)()

                AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.Insert(ReportingDbContext, DynamicReport.ID, GridViewColumn.FieldName,
                                                                                      GridViewColumn.Caption, GridViewColumn.Visible, GridViewColumn.SortIndex,
                                                                                      GridViewColumn.SortOrder, GridViewColumn.GroupIndex, GridViewColumn.Width.Value,
                                                                                      If(GridViewColumn.Visible, ASPxGridViewDynamicReport.VisibleColumns.IndexOf(GridViewColumn), -1), Nothing, Nothing)

            Next

            Me.Title = "Report Writer - " & DynamicReport.Description

            Session("DynamicReportID") = DynamicReport.ID

            'Response.Redirect([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", DynamicReport.ID))

        End If

    End Sub
    Private Sub SaveAsDynamicReportTemplate()

        SaveReportStateToSession()

        Me.OpenWindow("", "Reporting_SaveDynamicReportTemplate.aspx", 200, 600)

    End Sub
    Private Sub InitialLoadingSaveDynamicReportTemplate()

        If Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTime OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTimeWithEmployeeCost OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.DirectTimeWithEmployeeCost OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityDetail OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityToInvestment OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CRMClientContracts OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobPurchaseOrder OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AuthorizationToBuy OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeApproval OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ExpenseReportAndApproval OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.VendorContracts OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.TimeReport Then

            Me.OpenWindow("Set Initial Criteria", String.Format("Reporting_InitialLoading.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaResults Then

            Me.OpenWindow("Media Results Criteria", String.Format("Reporting_InitialLoadingMediaResults.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 900, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaPlan Then

            Me.OpenWindow("Media Plan Criteria", String.Format("Reporting_InitialLoadingMediaPlan.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 900, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.DigitalResultsComparison Then

            Me.OpenWindow("Digital Results Comparison Criteria", String.Format("Reporting_InitialLoadingDigitalResultsComparison.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 900, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobProjectScheduleSummary OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobSummary OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ProjectHoursUsed OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ProjectSummary OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ProjectSummaryTask Then

            Me.OpenWindow("Job Project Schedule Summary Inital Criteria", String.Format("Reporting_InitialLoadingJobProjectScheduleSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ProjectSchedule Then

            Me.OpenWindow("Job Project Schedule Summary Inital Criteria", String.Format("Reporting_InitialLoadingJobProjectScheduleSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ClientPL Then

            Me.OpenWindow("Client PL Inital Criteria", String.Format("Reporting_InitialLoadingPostPeriod.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EstimatedAndActualIncome Then

            Me.OpenWindow("Estimated And Actual Income Inital Criteria", String.Format("Reporting_InitialLoadingEstimatedAndActualIncome.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatus Then

            Me.OpenWindow("Media Current Status Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusNew.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatusSummary Then

            Me.OpenWindow("Media Current Status Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonSummary Then

            Me.OpenWindow("Media Plan Comparison Summary Criteria", String.Format("Reporting_InitialLoadingMediaPlanComparisonSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AROpenAged Then

            Me.OpenWindow("AR Open Aged Criteria", String.Format("Reporting_InitialLoadingAROpenAged.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ServiceFee Then

            Me.OpenWindow("Service Fee Criteria", String.Format("Reporting_InitialLoadingServiceFee.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.Campaign Then

            Me.OpenWindow("Campaign Criteria", String.Format("Reporting_InitialLoadingCampaign.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CashAnalysis Then

            Me.OpenWindow("Cash Transactions", String.Format("Reporting_InitialLoadingCashAnalysis.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CashTransactions Then

            Me.OpenWindow("Cash Transactions Criteria", String.Format("Reporting_InitialLoadingCashTransaction.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SalesJournal OrElse
               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SalesJournalWithComments Then

            Me.OpenWindow("Sales Journal Criteria", String.Format("Reporting_InitialLoadingSalesJournal.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CampaignWithProductionAndMedia OrElse
               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CampaignWithProductionAndMediaSummary Then

            Me.OpenWindow("Campaign with Production and Media Criteria", String.Format("Reporting_InitialLoadingCampaignProductionMedia.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.GeneralLedgerDetail Then

            Me.OpenWindow("General Ledger Detail Criteria", String.Format("Reporting_InitialLoadingGeneralLedgerDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EstimateDetailApproved Then

            Me.OpenWindow("Estimate Detail Approved", String.Format("Reporting_InitialLoadingEstimateDetailApproved.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.Transfer Then

            Me.OpenWindow("Transfer Criteria", String.Format("Reporting_InitialLoadingTransfer.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobWriteOff Then

            Me.OpenWindow("Job WriteOff Criteria", String.Format("Reporting_InitialLoadingJobWriteOff.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceDetail Then

            Me.OpenWindow("Accounts Payable Invoice Detail Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceDetailPayments Then

            'Me.OpenWindow("Accounts Payable Invoice Detail Payments Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)
            Me.OpenWindow("Accounts Payable Invoice Detail Payments Criteria", String.Format("Reporting_InitialLoadingCheckRegister.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceDetailPaidByClient Then

            Me.OpenWindow("Accounts Payable Invoice Detail Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceWithBalanceAging Then

            Me.OpenWindow("Accounts Payable Invoice With Balance Aging Criteria", String.Format("Reporting_InitialLoadingAccountsPayableInvoiceWithBalanceAging.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EstimateForm Then

            Me.OpenWindow("Estimate Criteria", String.Format("Reporting_InitialLoadingEstimate.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ProjectSummaryAnalysis Then

            Me.OpenWindow("Project Summary Analysis Criteria", String.Format("Reporting_InitialLoadingProjectSummaryAnalysis.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ClientPLDetail Then

            Me.OpenWindow("Client PL Detail Criteria", String.Format("Reporting_InitialLoadingClientPLDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.BillingWorksheetProduction Then

            Me.OpenWindow("Billing Worksheet Production Criteria", String.Format("Reporting_InitialLoadingBillingWorksheetProduction.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.BillingWorksheetMedia Then

            Me.OpenWindow("Billing Worksheet Media Criteria", String.Format("Reporting_InitialLoadingBillingWorksheetMedia.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobForecast Then

            Me.OpenWindow("Job Forecast Criteria", String.Format("Reporting_InitialLoadingJobForecast.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.OpenPurchaseOrderDetail Then

            Me.OpenWindow("Open Purchase Order Detail", String.Format("Reporting_InitialLoadingOpenPurchaseOrderDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CRMProspects Then

            Me.OpenWindow("CRM Prospects Criteria", String.Format("Reporting_InitialLoadingCRMProspects.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ARPaymentHistory Then

            Me.OpenWindow("AR Payment History Criteria", String.Format("Reporting_InitialLoadingARPaymentHistory.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.GeneralLedgerReport Then

            Me.OpenWindow("General Ledger Report Criteria", String.Format("GeneralLedger/Reports/GeneralLedgerReport/DetailByAccountReport/{0}/1/{1}", _DynamicReportTemplateID, Session("DRPT_Type")), 525, 900, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.TrialBalance Then

            Me.OpenWindow("Trial Balance Criteria", String.Format("GeneralLedger/Reports/GeneralLedgerReport/DetailByAccountReport/{0}/1/{1}", _DynamicReportTemplateID, Session("DRPT_Type")), 525, 900, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaResultsComparisonByClientAndType Then

            Me.OpenWindow("Media Results Comparison by Client and Type Criteria", String.Format("Reporting_InitialLoadingMediaResultsComparisonByClientAndType.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AccountsPayableBalanceByVendor Then

            Me.OpenWindow("Accounts Payable Balance by Vendor Criteria", String.Format("Reporting/AccountsPayableBalanceByVendorReportCriteria/{0}/0", _DynamicReportTemplateID), 400, 725, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AccountsReceivableBalanceByClient Then

            Me.OpenWindow("Accounts Receivable Balance by Client Criteria", String.Format("Reporting/AccountsReceivableBalanceByClientReportCriteria/{0}/0", _DynamicReportTemplateID), 400, 725, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SalesAndCostOfSalesByClient Then

            Me.OpenWindow("Sales and COS by Client Criteria", String.Format("Reporting/SalesAndCostOfSalesByClientReportCriteria/{0}/0", _DynamicReportTemplateID), 400, 725, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.RevenueBreakdownByClient Then

            Me.OpenWindow("Revenue Breakdown by Client Criteria", String.Format("Reporting/RevenueBreakdownByClientReportCriteria/{0}/0", _DynamicReportTemplateID), 400, 725, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailItem OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetail OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailItemAccountSplit Then

            Me.OpenWindow("Job Detail", String.Format("Reporting_InitialLoadingJobDetail.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EmployeeUtilization Then

            Me.OpenWindow("Employee Utilization", String.Format("Reporting_InitialLoadingEmployeeUtilization.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeForecast Then

            Me.OpenWindow("Employee Time Forecast", String.Format("Reporting_InitialLoadingEmployeeTimeForecast.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CheckRegister _
            Or Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CheckRegisterWithInvoiceDetails Then

            Me.OpenWindow("Check Register Criteria", String.Format("Reporting_InitialLoadingCheckRegister.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EmployeeInOutBoard Then

            Me.OpenWindow("Employee In-Out Board Criteria", String.Format("Reporting_InitialLoadingEmployeeInOutBoard.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonByVendor OrElse Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonDetailByVendor Then

            Me.OpenWindow("Media Plan Comparison Summary By Vendor Criteria", String.Format("Reporting_InitialLoadingMediaPlanComparisonSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.Alerts OrElse
                   Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AlertsWithComments OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.AlertsWithRecipients Then

            Me.OpenWindow("Alerts Inital Criteria", String.Format("Reporting_InitialLoadingAlert.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ResourceAllocationByWeek Then

            Me.OpenWindow("Resources Allocation by Week Inital Criteria", String.Format("Reporting_InitialLoadingResourceAllocationByWeek.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.DirectTime Then

            Me.OpenWindow("Direct Time Inital Criteria", String.Format("Reporting_InitialLoadingDirectTime.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatusCoopBreakout Then

            Me.OpenWindow("Media Current Status Coop Breakout Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusNew.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByFunction OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJobComponent OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByCampaign OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByFunctionMinimized OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob1Minimized OrElse
                    Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobDetailFeesAndOOPByJob2Minimized Then

            Me.OpenWindow("Job Detail Fees OOP Criteria", String.Format("Reporting_InitialLoadingJobDetailFeesOOP.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SecurityGroupModuleAccess OrElse
               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SecurityGroupSettings OrElse
               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SecurityGroupUserSettings OrElse
               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SecurityUserModuleAccess OrElse
               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SecurityUserSettings Then

            Me.OpenWindow("Security Criteria", String.Format("Reporting_InitialLoadingSecurity.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.SecurityUserLoginAudit Then

            Me.OpenWindow("Set Initial Criteria", String.Format("Reporting_InitialLoadingSecurityUserLoginAudit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.ProjectScheduleTasksByEmployee Then

            Me.OpenWindow("Job Project Schedule Tasks by Employee Inital Criteria", String.Format("Reporting_InitialLoadingJobProjectScheduleSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 700, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MonthEndMediaWIP OrElse
               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MonthEndAccruedLiability OrElse
               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MonthEndAccountsPayable Then

            Me.OpenWindow("Month End Report Criteria", String.Format("Reporting_InitialLoadingMonthEndMediaWIP.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EmployeeHoursAllocation Then

            Me.OpenWindow("Employee Hours Allocation Criteria", String.Format("Reporting_InitialLoadingEmployeeHoursAllocation.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.InvoiceBilledBackup Then

            Me.OpenWindow("Invoice Billed Backup Criteria", String.Format("Reporting_InitialLoadingInvoiceBilledBackup.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.CashManagementProduction Then

            Me.OpenWindow("Cash Management Production Criteria", String.Format("Reporting_InitialLoadingCashManagementProduction.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaTrafficInstructions OrElse
               Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaTrafficMissingInstructions Then

            Me.OpenWindow("Media Traffic Instructions Criteria", String.Format("Reporting_InitialLoadingMediaTrafficInstructions.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 1400, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.VendorSpendWithEEOCAndMinorityStatusSummary Then

            Me.OpenWindow("Vendor Spend With EEOC and Minority Status Summary Initial Criteria", String.Format("Reporting_InitialLoadingVendorSpendWithEEOCAndMinorityStatusSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.VendorSpendWithEEOCAndMinorityStatusDetail Then

            Me.OpenWindow("Vendor Spend With EEOC and Minority Status Detail Initial Criteria", String.Format("Reporting_InitialLoadingVendorSpendWithEEOCAndMinorityStatusSummary.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.BillingApproval Then

            Me.OpenWindow("Billing Approval Initial Criteria", String.Format("Reporting_InitialLoadingBillingApproval.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, False, True)

        ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeAnalysis Then

            Me.OpenWindow("Employee Time Analysis Criteria", String.Format("Reporting_InitialLoadingEmployeeTimeAnalysis.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 875, False, True)

        Else

            Session("DRPT_UseBlankData") = False
            Session("DRPT_DashboardLoaded") = False

            If _DynamicReportTemplateID <> 0 Then

                Response.Redirect([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID))

            Else

                Response.Redirect("Reporting_DynamicReportEdit.aspx")

            End If

        End If

    End Sub
    Private Sub ShowViewCaption()

        If RadToolBarButtonShowViewCaption.Checked Then

            ASPxGridViewDynamicReport.Caption = ASPxGridViewDynamicReport.VisibleRowCount & " Items"

        Else

            ASPxGridViewDynamicReport.Caption = String.Empty

        End If

    End Sub
    Private Sub ShowGroupByBox()

        If RadToolBarButtonShowGroupByBox.Checked Then

            ASPxGridViewDynamicReport.Settings.ShowGroupPanel = True

        Else

            ASPxGridViewDynamicReport.Settings.ShowGroupPanel = False

        End If

    End Sub
    Private Sub ShowAutoFilterRow()

        If RadToolBarButtonShowAutoFilterRow.Checked Then

            ASPxGridViewDynamicReport.Settings.ShowFilterRow = True

        Else

            ASPxGridViewDynamicReport.Settings.ShowFilterRow = False

        End If

    End Sub
    Private Sub SaveReportStateToSession()

        Try

            Session("DRPT_Type") = Convert.ToInt32(RadComboBoxDynamicReport.SelectedValue)

        Catch ex As Exception
            Session("DRPT_Type") = 0
        End Try

        Try

            Session("DRPT_ShowGroupByBox") = RadToolBarButtonShowGroupByBox.Checked

        Catch ex As Exception
            Session("DRPT_ShowGroupByBox") = False
        End Try

        Try

            Session("DRPT_ShowViewCaption") = RadToolBarButtonShowViewCaption.Checked

        Catch ex As Exception
            Session("DRPT_ShowViewCaption") = False
        End Try

        Try

            Session("DRPT_ShowAutoFilterRow") = RadToolBarButtonShowAutoFilterRow.Checked

        Catch ex As Exception
            Session("DRPT_ShowAutoFilterRow") = False
        End Try

        Try

            Session("DRPT_ActiveFilter") = ASPxGridViewDynamicReport.FilterExpression

        Catch ex As Exception
            Session("DRPT_ActiveFilter") = ""
        End Try

        SaveReportColumnsStateToSession()

    End Sub
    Private Sub SaveReportColumnsStateToSession()

        'objects
        Dim DynamicReportColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing
        Dim DynamicReportColumn As AdvantageFramework.Database.Classes.DynamicReportColumn = Nothing
        Dim ObjectType As System.Type = Nothing
        Dim DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing
        Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
        Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
        Dim DReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing

        DynamicReportColumnsList = New Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn)

        For Each GridViewColumn In ASPxGridViewDynamicReport.Columns.OfType(Of DevExpress.Web.GridViewDataColumn)().Where(Function(Column) Column.ShowInCustomizationForm)

            DynamicReportColumn = New AdvantageFramework.Database.Classes.DynamicReportColumn

            DynamicReportColumn.FieldName = GridViewColumn.FieldName
            DynamicReportColumn.HeaderText = GridViewColumn.Caption
            DynamicReportColumn.IsVisible = GridViewColumn.Visible
            DynamicReportColumn.SortIndex = GridViewColumn.SortIndex
            DynamicReportColumn.SortOrder = GridViewColumn.SortOrder
            DynamicReportColumn.GroupIndex = GridViewColumn.GroupIndex
            DynamicReportColumn.Width = GridViewColumn.Width.Value

            If GridViewColumn.Visible Then

                DynamicReportColumn.VisibleIndex = ASPxGridViewDynamicReport.VisibleColumns.IndexOf(GridViewColumn) + 1

            Else

                DynamicReportColumn.VisibleIndex = -1

            End If

            ObjectType = AdvantageFramework.Reporting.LoadDynamicReportObjectType(_DynamicReportType)

            Try

                PropertyDescriptor = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(ObjectType).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                      Where [Property].Name = GridViewColumn.FieldName
                                      Select [Property]).SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            If PropertyDescriptor IsNot Nothing Then

                Try

                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                Catch ex As Exception
                    EntityAttribute = Nothing
                Finally

                    If EntityAttribute IsNot Nothing Then

                        If EntityAttribute.CustomColumnCaption <> "" Then

                            DynamicReportColumn.OriginalText = EntityAttribute.CustomColumnCaption

                        Else

                            DynamicReportColumn.OriginalText = AdvantageFramework.StringUtilities.GetNameAsWords(GridViewColumn.FieldName)

                        End If

                    End If

                End Try

            Else

                DynamicReportColumn.OriginalText = GridViewColumn.ToString

            End If


            DynamicReportColumnsList.Add(DynamicReportColumn)

        Next

        Session("DRPT_ColumnsList") = DynamicReportColumnsList

    End Sub
    Private Sub SaveReportColumnsStateToSession(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport)

        'objects
        Dim DynamicReportColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing
        Dim DRColumn As AdvantageFramework.Database.Classes.DynamicReportColumn = Nothing
        Dim ObjectType As System.Type = Nothing
        Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
        Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
        Dim DReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing

        DynamicReportColumnsList = New Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn)

        For Each DynamicReportColumn In DynamicReport.DynamicReportColumns.OrderBy(Function(Column) Column.VisibleIndex).ToList

            DRColumn = New AdvantageFramework.Database.Classes.DynamicReportColumn

            DRColumn.FieldName = DynamicReportColumn.FieldName
            DRColumn.HeaderText = DynamicReportColumn.HeaderText
            DRColumn.Width = System.Web.UI.WebControls.Unit.Pixel(DynamicReportColumn.Width).Value

            If DynamicReportColumn.IsVisible = False Then

                DRColumn.IsVisible = False
                DRColumn.VisibleIndex = -1

            Else

                DRColumn.IsVisible = True

                If DynamicReportColumn.VisibleIndex > -1 Then

                    DRColumn.VisibleIndex = DynamicReportColumn.VisibleIndex + 1

                End If

            End If

            If DRColumn.IsVisible AndAlso DRColumn.Width = 0 Then

                DRColumn.Width = System.Web.UI.WebControls.Unit.Pixel(100).Value

            End If

            DRColumn.SortIndex = DynamicReportColumn.SortIndex
            DRColumn.SortOrder = DynamicReportColumn.SortOrder
            DRColumn.GroupIndex = DynamicReportColumn.GroupIndex

            ObjectType = AdvantageFramework.Reporting.LoadDynamicReportObjectType(DynamicReport.Type)

            Try

                PropertyDescriptor = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(ObjectType).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                      Where [Property].Name = DynamicReportColumn.FieldName
                                      Select [Property]).SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            If PropertyDescriptor IsNot Nothing Then

                Try

                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                Catch ex As Exception
                    EntityAttribute = Nothing
                Finally

                    If EntityAttribute IsNot Nothing Then

                        If EntityAttribute.CustomColumnCaption <> "" Then

                            DRColumn.OriginalText = EntityAttribute.CustomColumnCaption

                        Else

                            DRColumn.OriginalText = AdvantageFramework.StringUtilities.GetNameAsWords(DynamicReportColumn.FieldName)

                        End If

                    End If

                End Try

            Else

                DRColumn.OriginalText = DynamicReportColumn.ToString

            End If


            DynamicReportColumnsList.Add(DRColumn)

        Next

        For Each GridColumn In ASPxGridViewDynamicReport.Columns.OfType(Of DevExpress.Web.GridViewDataColumn)().Where(Function(GC) GC.UnboundType = DevExpress.Data.UnboundColumnType.Bound).ToList

            If DynamicReport.DynamicReportColumns.Any(Function(Entity) Entity.FieldName = GridColumn.FieldName) = False Then

                DRColumn = New AdvantageFramework.Database.Classes.DynamicReportColumn

                DRColumn.FieldName = GridColumn.FieldName
                DRColumn.HeaderText = GridColumn.Caption
                DRColumn.Width = GridColumn.Width.Value

                DRColumn.IsVisible = False
                DRColumn.VisibleIndex = -1

                DRColumn.SortIndex = GridColumn.SortIndex
                DRColumn.SortOrder = GridColumn.SortOrder
                DRColumn.GroupIndex = GridColumn.GroupIndex

                DynamicReportColumnsList.Add(DRColumn)

                GridColumn.Visible = False

            End If

        Next

        For Each DynamicReportUnboundColumn In DynamicReport.DynamicReportUnboundColumns.OrderBy(Function(Column) Column.VisibleIndex).ToList

            DRColumn = New AdvantageFramework.Database.Classes.DynamicReportColumn

            DRColumn.FieldName = DynamicReportUnboundColumn.FieldName
            DRColumn.HeaderText = DynamicReportUnboundColumn.HeaderText
            DRColumn.Width = System.Web.UI.WebControls.Unit.Pixel(DynamicReportUnboundColumn.Width).Value

            If DynamicReportUnboundColumn.IsVisible = False Then

                DRColumn.IsVisible = False
                DRColumn.VisibleIndex = -1

            Else

                DRColumn.IsVisible = True

                If DynamicReportUnboundColumn.VisibleIndex > -1 Then

                    DRColumn.VisibleIndex = DynamicReportUnboundColumn.VisibleIndex + 1

                End If

            End If

            If DRColumn.IsVisible AndAlso DRColumn.Width = 0 Then

                DRColumn.Width = System.Web.UI.WebControls.Unit.Pixel(100).Value

            End If

            DRColumn.SortIndex = DynamicReportUnboundColumn.SortIndex
            DRColumn.SortOrder = DynamicReportUnboundColumn.SortOrder
            DRColumn.GroupIndex = DynamicReportUnboundColumn.GroupIndex

            DynamicReportColumnsList.Add(DRColumn)

        Next

        Session("DRPT_ColumnsList") = DynamicReportColumnsList

    End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_DynamicReportEdit_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Me.LabelUpdate = CType(Me.RadToolBarOptions.FindItemByValue("RadToolBarButtonLabelUpdate").FindControl("LabelUpdate"), Label)

        If Session("DRPT_UseBlankData") Is Nothing Then

            Session("DRPT_UseBlankData") = True
            Session("DRPT_DashboardLoaded") = False

        End If

        If Not Me.IsPostBack Then
            Session("DynamicReportID") = Nothing
        End If

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            RadComboBoxDynamicReport.DataTextField = "Value"
            RadComboBoxDynamicReport.DataValueField = "Key"

            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Reporting.DynamicReports)).OrderBy(Function(KeyValue) KeyValue.Value)

                RadComboBoxDynamicReport.Items.Add(New Telerik.Web.UI.RadComboBoxItem(KeyValuePair.Value, KeyValuePair.Key))

            Next

            RadComboBoxDynamicReport.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "0"))

            RadComboBoxDynamicReport.SelectedIndex = 0


        End If


        Try

            If Request.QueryString("DynamicReportTemplateID") IsNot Nothing AndAlso Session("DynamicReportID") = Nothing Then

                _DynamicReportTemplateID = CType(Request.QueryString("DynamicReportTemplateID"), Integer)

            ElseIf Session("DynamicReportID") IsNot Nothing Then

                _DynamicReportTemplateID = Session("DynamicReportID")

            End If

        Catch ex As Exception
            _DynamicReportTemplateID = 0
        End Try

        Try

            _ViewOnly = Session("DRPT_ViewOnly")

        Catch ex As Exception
            _ViewOnly = True
        End Try

        Try

            _DynamicReportType = Session("DRPT_Type")

        Catch ex As Exception
            _DynamicReportType = 0
        End Try

        Try

            _DynamicReportShowGroupByBox = Session("DRPT_ShowGroupByBox")

        Catch ex As Exception
            _DynamicReportShowGroupByBox = False
        End Try

        Try

            _DynamicReportShowViewCaption = Session("DRPT_ShowViewCaption")

        Catch ex As Exception
            _DynamicReportShowViewCaption = False
        End Try

        Try

            _DynamicReportShowAutoFilterRow = Session("DRPT_ShowAutoFilterRow")

        Catch ex As Exception
            _DynamicReportShowAutoFilterRow = False
        End Try

        Try

            _DynamicReportActiveFilter = Session("DRPT_ActiveFilter")

        Catch ex As Exception
            _DynamicReportActiveFilter = ""
        End Try

        Try

            _UserDefinedReportCategoryID = If(IsNumeric(Session("DRPT_UDRCategory")), CInt(Session("DRPT_UDRCategory")), Nothing)

        Catch ex As Exception
            _UserDefinedReportCategoryID = Nothing
        End Try

        Try

            _DynamicReportDescription = Session("DRPT_Description")

        Catch ex As Exception
            _DynamicReportDescription = ""
        End Try

        RadToolBarButtonCustomizeColumns.Enabled = Not _ViewOnly
        RadToolBarButtonSave.Enabled = Not _ViewOnly
        RadToolBarButtonSaveAs.Enabled = Not _ViewOnly

    End Sub
    Private Sub Reporting_DynamicReportEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing

        If ASPxGridViewDynamicReport.FilterEnabled = False Then

            ASPxGridViewDynamicReport.FilterEnabled = True

        End If

        System.Threading.Thread.Sleep(500)

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            If System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("~\") & "TEMP") = False Then

                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~\") & "TEMP")

            End If

            If _DynamicReportTemplateID > 0 Then

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _DynamicReportTemplateID)

                    If DynamicReport IsNot Nothing Then

                        If DynamicReport.DashboardLayout IsNot Nothing AndAlso DynamicReport.DashboardLayout.Count > 0 Then

                            System.IO.File.WriteAllBytes(HttpContext.Current.Server.MapPath("~\") & "TEMP\Dashboard" & _DynamicReportTemplateID & ".xml", DynamicReport.DashboardLayout)

                            ASPxDashboardViewer.DashboardXmlPath = HttpContext.Current.Server.MapPath("~\") & "TEMP\Dashboard" & _DynamicReportTemplateID & ".xml"
                            'ASPxDashboardViewer.DashboardSource = HttpContext.Current.Server.MapPath("~\") & "TEMP\Dashboard.xml"

                        Else

                            System.IO.File.WriteAllText(HttpContext.Current.Server.MapPath("~\") & "TEMP\Dashboard" & _DynamicReportTemplateID & ".xml", "")

                        End If

                    Else

                        System.IO.File.WriteAllText(HttpContext.Current.Server.MapPath("~\") & "TEMP\Dashboard" & _DynamicReportTemplateID & ".xml", "")

                    End If

                End Using

            End If

            Dim DynamicReportDataset As AdvantageFramework.Reporting.Database.Entities.DynamicReportDataset = Nothing

            Using ReportDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                DynamicReportDataset = AdvantageFramework.Reporting.Database.Procedures.DynamicReportDataset.LoadByDynamicReportType(ReportDbContext, _DynamicReportType)
            End Using

            If DynamicReportDataset IsNot Nothing AndAlso DynamicReportDataset.LastUpdated IsNot Nothing Then
                Me.LabelUpdate.Text = "Data Last Updated on " & DynamicReportDataset.LastUpdated
            End If

        End If
    End Sub
    Private Sub Reporting_DynamicReportEdit_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        'objects
        Dim DynamicReportColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing
        Dim DynamicReportColumnClass As AdvantageFramework.Database.Classes.DynamicReportColumn = Nothing
        Dim GridViewColumn As DevExpress.Web.GridViewDataColumn = Nothing
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
        Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing
        Dim EventArgs As String = ""

        If (Not Me.IsPostBack AndAlso Not Me.IsCallback) Or Me.EventArgument = "Refresh" Then

            If _DynamicReportTemplateID > 0 Then

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _DynamicReportTemplateID)

                    If DynamicReport IsNot Nothing Then

                        ASPxGridViewDynamicReport.BeginUpdate()

                        RadComboBoxDynamicReport.SelectedValue = DynamicReport.Type

                        _DynamicReportDescription = DynamicReport.Description
                        _UserDefinedReportCategoryID = DynamicReport.UserDefinedReportCategoryID

                        'LoadReportData(DynamicReport.Type, True, True)
                        LoadReportData(DynamicReport.Type, True, Session("DRPT_UseBlankData"))

                        RadToolBarButtonShowGroupByBox.Checked = If(Session("DRPT_ShowGroupByBox") Is Nothing, DynamicReport.ShowGroupByBox, Session("DRPT_ShowGroupByBox"))
                        RadToolBarButtonShowViewCaption.Checked = If(Session("DRPT_ShowViewCaption") Is Nothing, DynamicReport.ShowViewCaption, Session("DRPT_ShowViewCaption"))
                        RadToolBarButtonShowAutoFilterRow.Checked = If(Session("DRPT_ShowAutoFilterRow") Is Nothing, DynamicReport.ShowAutoFilterRow, Session("DRPT_ShowAutoFilterRow"))

                        ShowGroupByBox()
                        ShowViewCaption()
                        ShowAutoFilterRow()

                        If Session("DRPT_ActiveFilter") Is Nothing Then

                            ASPxGridViewDynamicReport.FilterExpression = DynamicReport.ActiveFilter

                        Else

                            ASPxGridViewDynamicReport.FilterExpression = Session("DRPT_ActiveFilter")

                        End If

                        'If DynamicReport.DashboardLayout IsNot Nothing AndAlso DynamicReport.DashboardLayout.Count > 0 Then

                        '    If System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("~\") & "Temp") = False Then

                        '        System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~\") & "Temp")

                        '    End If

                        '    System.IO.File.WriteAllBytes(HttpContext.Current.Server.MapPath("~\") & "Temp\Dashboard.xml", DynamicReport.DashboardLayout)

                        '    'ASPxDashboardViewer.DashboardXmlFile = HttpContext.Current.Server.MapPath("~\") & "Temp\Dashboard.xml"
                        '    ASPxDashboardViewer.DashboardSource = HttpContext.Current.Server.MapPath("~\") & "Temp\Dashboard.xml"

                        'End If

                        ASPxGridViewDynamicReport.EndUpdate()

                        ASPxGridViewDynamicReport.BeginUpdate()

                        If Session("DRPT_ColumnsList") Is Nothing Then

                            SaveReportColumnsStateToSession(ReportingDbContext, DynamicReport)

                        End If

                        'If Session("DRPT_ColumnsList") Is Nothing Then

                        '    For Each DynamicReportColumn In DynamicReport.DynamicReportColumns.OrderBy(Function(Column) Column.VisibleIndex).ToList

                        '        GridViewColumn = ASPxGridViewDynamicReport.Columns(DynamicReportColumn.FieldName)

                        '        If GridViewColumn IsNot Nothing Then

                        '            GridViewColumn.Caption = DynamicReportColumn.HeaderText
                        '            GridViewColumn.Width = System.Web.UI.WebControls.Unit.Pixel(DynamicReportColumn.Width)

                        '            If DynamicReportColumn.IsVisible = False Then

                        '                GridViewColumn.Visible = False
                        '                GridViewColumn.VisibleIndex = -1

                        '            Else

                        '                GridViewColumn.Visible = True

                        '                If DynamicReportColumn.VisibleIndex > -1 Then

                        '                    GridViewColumn.VisibleIndex = DynamicReportColumn.VisibleIndex

                        '                End If

                        '            End If

                        '            If GridViewColumn.Visible AndAlso GridViewColumn.Width.Value = 0 Then

                        '                GridViewColumn.Width = System.Web.UI.WebControls.Unit.Pixel(100)

                        '            End If

                        '            GridViewColumn.SortIndex = DynamicReportColumn.SortIndex
                        '            GridViewColumn.SortOrder = DynamicReportColumn.SortOrder
                        '            GridViewColumn.GroupIndex = DynamicReportColumn.GroupIndex

                        '        End If

                        '    Next

                        '    For Each GridColumn In ASPxGridViewDynamicReport.Columns.OfType(Of DevExpress.Web.GridViewDataColumn)().Where(Function(GC) GC.UnboundType = DevExpress.Data.UnboundColumnType.Bound).ToList

                        '        If AdvantageFramework.Database.Procedures.DynamicReportColumn.LoadByDynamicReportID(DbContext, DynamicReport.ID).Any(Function(Entity) Entity.FieldName = GridColumn.FieldName) = False Then

                        '            GridColumn.Visible = False

                        '        End If

                        '    Next

                        'Else
                        If Session("DRPT_ColumnsList") IsNot Nothing Then

                            For Each GridViewColumn In ASPxGridViewDynamicReport.Columns.OfType(Of DevExpress.Web.GridViewDataColumn).ToList

                                GridViewColumn.Visible = False

                            Next

                            Try

                                DynamicReportColumnsList = Session("DRPT_ColumnsList")

                                For Each DynamicReportColumnClass In DynamicReportColumnsList.OrderByDescending(Function(Entity) Entity.VisibleIndex).ToList

                                    GridViewColumn = ASPxGridViewDynamicReport.Columns(DynamicReportColumnClass.FieldName)

                                    If GridViewColumn IsNot Nothing Then

                                        GridViewColumn.Caption = DynamicReportColumnClass.HeaderText
                                        GridViewColumn.Width = System.Web.UI.WebControls.Unit.Pixel(DynamicReportColumnClass.Width)

                                        If DynamicReportColumnClass.IsVisible = False Then

                                            GridViewColumn.Visible = False
                                            GridViewColumn.VisibleIndex = -1

                                        Else

                                            GridViewColumn.Visible = True

                                            If DynamicReportColumnClass.VisibleIndex > -1 Then

                                                GridViewColumn.VisibleIndex = DynamicReportColumnClass.VisibleIndex

                                            End If

                                        End If

                                        If GridViewColumn.Visible AndAlso GridViewColumn.Width.Value = 0 Then

                                            GridViewColumn.Width = 100

                                        End If

                                        GridViewColumn.SortIndex = DynamicReportColumnClass.SortIndex
                                        GridViewColumn.SortOrder = DynamicReportColumnClass.SortOrder
                                        GridViewColumn.GroupIndex = DynamicReportColumnClass.GroupIndex

                                    End If

                                Next

                            Catch ex As Exception

                            End Try

                        End If

                        Me.Title = "Report Writer - " & DynamicReport.Description

                        ASPxGridViewDynamicReport.EndUpdate()

                    Else

                        Me.Title = "Report Writer"

                    End If

                End Using

            Else

                If _DynamicReportType > 0 Then

                    ASPxGridViewDynamicReport.BeginUpdate()

                    RadComboBoxDynamicReport.SelectedValue = _DynamicReportType

                    LoadReportData(_DynamicReportType, True, Session("DRPT_UseBlankData"))

                    RadToolBarButtonShowGroupByBox.Checked = _DynamicReportShowGroupByBox
                    RadToolBarButtonShowViewCaption.Checked = _DynamicReportShowViewCaption
                    RadToolBarButtonShowAutoFilterRow.Checked = _DynamicReportShowAutoFilterRow

                    ShowGroupByBox()
                    ShowViewCaption()
                    ShowAutoFilterRow()

                    If _DynamicReportActiveFilter <> "" Then

                        ASPxGridViewDynamicReport.FilterExpression = _DynamicReportActiveFilter

                    Else

                        ASPxGridViewDynamicReport.FilterExpression = ""

                    End If

                    Try

                        DynamicReportColumnsList = Session("DRPT_ColumnsList")

                        For Each DynamicReportColumnClass In DynamicReportColumnsList

                            GridViewColumn = ASPxGridViewDynamicReport.Columns(DynamicReportColumnClass.FieldName)

                            If GridViewColumn IsNot Nothing Then

                                GridViewColumn.Caption = DynamicReportColumnClass.HeaderText
                                GridViewColumn.Width = System.Web.UI.WebControls.Unit.Pixel(DynamicReportColumnClass.Width)

                                If DynamicReportColumnClass.IsVisible = False Then

                                    GridViewColumn.VisibleIndex = -1

                                Else

                                    GridViewColumn.Visible = True

                                    If DynamicReportColumnClass.VisibleIndex = -1 Then

                                        GridViewColumn.VisibleIndex = ASPxGridViewDynamicReport.VisibleColumns.Count + 1

                                    Else

                                        GridViewColumn.VisibleIndex = DynamicReportColumnClass.VisibleIndex

                                    End If

                                End If

                                If GridViewColumn.Visible AndAlso GridViewColumn.Width.Value = 0 Then

                                    GridViewColumn.Width = 100

                                End If

                                GridViewColumn.SortIndex = DynamicReportColumnClass.SortIndex
                                GridViewColumn.SortOrder = DynamicReportColumnClass.SortOrder
                                GridViewColumn.GroupIndex = DynamicReportColumnClass.GroupIndex

                            End If

                        Next

                    Catch ex As Exception

                    End Try

                    Me.Title = "Report Writer - " & _DynamicReportDescription

                    ASPxGridViewDynamicReport.EndUpdate()

                End If

            End If

        Else

            If _DynamicReportType > 0 AndAlso
                    ((Me.IsPostBack AndAlso Me.IsCallback AndAlso Me.ASPxGridViewDynamicReport.IsCallback AndAlso Me.EventArgument = String.Empty) OrElse
                      Me.EventArgument = "{""type"":0,""index"":""0""}") Then

                RadComboBoxDynamicReport.SelectedValue = _DynamicReportType

                LoadReportData(_DynamicReportType, False, Session("DRPT_UseBlankData"))

            End If

        End If

        If RadComboBoxDynamicReport.SelectedValue <> "" AndAlso RadComboBoxDynamicReport.SelectedValue <> "0" Then

            RadToolBarButtonSave.Enabled = Not _ViewOnly
            RadToolBarButtonSaveAs.Enabled = Not _ViewOnly
            RadToolBarButtonCustomizeColumns.Enabled = Not _ViewOnly

        Else

            RadToolBarButtonSave.Enabled = False
            RadToolBarButtonSaveAs.Enabled = False
            RadToolBarButtonCustomizeColumns.Enabled = False

        End If

        'If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailItem OrElse
        '       _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetail OrElse
        '       _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction OrElse
        '       _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth Then

        '    Me.RadToolBarButtonRefresh.Visible = True
        '    Me.RadToolBarOptions.FindItemByValue("RadToolBarButtonLabelUpdate").Visible = True
        '    Me.RadToolBarButton1.Visible = True

        'Else

        Me.RadToolBarButtonRefresh.Visible = False
        Me.RadToolBarOptions.FindItemByValue("RadToolBarButtonLabelUpdate").Visible = False
        Me.RadToolBarButton1.Visible = False

        'End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarOptions_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarOptions.ButtonClick

        'objects
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
        Dim DynamicReportDataset As AdvantageFramework.Reporting.Database.Entities.DynamicReportDataset = Nothing

        ASPxLoadingPanel1.Visible = True

        Try

            SaveReportStateToSession()

            If TypeOf e.Item Is Telerik.Web.UI.RadToolBarButton Then

                Select Case DirectCast(e.Item, Telerik.Web.UI.RadToolBarButton).CommandName

                    Case RadToolBarButtonLoadData.CommandName

                        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            If _DynamicReportTemplateID > 0 Then

                                DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _DynamicReportTemplateID)

                                If DynamicReport IsNot Nothing Then

                                    SaveDynamicReportTemplate(ReportingDbContext, DynamicReport)

                                Else

                                    SaveAsDynamicReportTemplate()

                                End If

                            Else

                                SaveNewDynamicReportTemplate(ReportingDbContext)

                            End If

                        End Using

                        InitialLoadingSaveDynamicReportTemplate()

                    Case RadToolBarButtonShowViewCaption.CommandName

                        ShowViewCaption()

                    Case RadToolBarButtonShowGroupByBox.CommandName

                        ShowGroupByBox()

                    Case RadToolBarButtonShowAutoFilterRow.CommandName

                        ShowAutoFilterRow()

                    Case RadToolBarButtonShowFilterEditor.CommandName

                        Session("DRPT_ActiveFilter") = ASPxGridViewDynamicReport.FilterExpression

                        Me.OpenWindow("Filter Report", String.Format("Reporting_FilterReport.aspx?Type=2&DynamicReportTemplateID={0}&DRPT_Type={1}", _DynamicReportTemplateID, RadComboBoxDynamicReport.SelectedValue), 525, 1100, False, True)

                    Case RadToolBarButtonCustomizeColumns.CommandName

                        Me.OpenWindow("Edit Report Columns", String.Format("Reporting_DynamicReportColumnEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, True)

                    'Case RadToolBarButtonLoadTemplate.CommandName

                    '    Me.OpenWindow("", "Reporting_DynamicReportTemplates.aspx?Mode=0", 525, 1000)

                    'Case RadToolBarButtonTemplates.CommandName

                    '    Me.OpenWindow("", "Reporting_DynamicReportTemplates.aspx?Mode=1", 525, 1000)

                    Case RadToolBarButtonSave.CommandName

                        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            If _DynamicReportTemplateID > 0 Then

                                DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _DynamicReportTemplateID)

                                If DynamicReport IsNot Nothing Then

                                    SaveDynamicReportTemplate(ReportingDbContext, DynamicReport)

                                Else

                                    SaveAsDynamicReportTemplate()

                                End If

                            Else

                                SaveNewDynamicReportTemplate(ReportingDbContext)

                            End If

                        End Using

                    Case RadToolBarButtonSaveAs.CommandName

                        SaveAsDynamicReportTemplate()

                    'Case RadToolBarButtonEditDashboard.CommandName

                    '    Me.OpenWindow("", [String].Format("Reporting_EditDashboard.aspx?DynamicReportTemplateID={0}&DRPT_Type={1}", _DynamicReportTemplateID, RadComboBoxDynamicReport.SelectedValue), IsModal:=True)

                    Case RadToolBarButtonRefresh.Value

                        Using ReportDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                AdvantageFramework.Reporting.LoadJobDetailItemDataSet(DbContext)

                                DynamicReportDataset = AdvantageFramework.Reporting.Database.Procedures.DynamicReportDataset.LoadByDynamicReportType(ReportDbContext, _DynamicReportType)

                                DynamicReportDataset.LastUpdated = Date.Now
                                DynamicReportDataset.UpdatedBy = _Session.UserCode

                                AdvantageFramework.Reporting.Database.Procedures.DynamicReportDataset.Update(ReportDbContext, DynamicReportDataset)

                                Me.LabelUpdate.Text = "Data Last Updated on " & Date.Now.ToString

                            End Using

                        End Using

                End Select

            End If

        Catch ex As Exception

        End Try

        ASPxLoadingPanel1.Visible = False

    End Sub
    Private Sub RadToolBarPrinting_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarPrinting.ButtonClick

        'objects
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
        Dim GridViewLink As DevExpress.Web.Export.GridViewLink = Nothing
        Dim CompositeLink As DevExpress.XtraPrintingLinks.CompositeLink = Nothing
        Dim PrintingSystem As DevExpress.XtraPrinting.PrintingSystem = Nothing
        Dim FileName As String = ""

        ASPxLoadingPanel1.Visible = True

        Try

            LoadReportData(RadComboBoxDynamicReport.SelectedValue, False, Session("DRPT_UseBlankData"))

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _DynamicReportTemplateID)

                If DynamicReport IsNot Nothing Then

                    ASPxGridViewExporter.ReportHeader = DynamicReport.Description

                    ASPxGridViewExporter.ReportFooter = DynamicReport.ActiveFilter

                    ASPxGridViewExporter.FileName = DynamicReport.Description

                    ASPxGridViewExporter.PageHeader.Font.Name = "Arial"
                    ASPxGridViewExporter.PageFooter.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.Cell.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.AlternatingRowCell.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.Default.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.Footer.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.GroupFooter.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.GroupRow.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.Header.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.HyperLink.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.Preview.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.Title.Font.Name = "Arial"

                    FileName = ASPxGridViewExporter.FileName

                Else

                    If AdvantageFramework.EnumUtilities.IsMemberOfEnum(GetType(AdvantageFramework.Reporting.DynamicReports), CInt(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.DynamicReports), RadComboBoxDynamicReport.SelectedValue))) Then

                        FileName = CType(RadComboBoxDynamicReport.SelectedValue, AdvantageFramework.Reporting.DynamicReports).ToString

                    Else

                        FileName = "ASPxGridViewExporter"

                    End If

                End If

                GridViewLink = New DevExpress.Web.Export.GridViewLink(ASPxGridViewExporter)

                PrintingSystem = New DevExpress.XtraPrinting.PrintingSystem

                CompositeLink = New DevExpress.XtraPrintingLinks.CompositeLink(PrintingSystem)

                CompositeLink.Links.Add(GridViewLink)

                CompositeLink.CreateDocument(False)

                Using MemoryStream As New System.IO.MemoryStream()

                    Select Case e.Item.Value

                        Case RadToolBarButtonPrintToPDF.Value

                            'ASPxGridViewExporter.WritePdfToResponse()
                            CompositeLink.ExportToPdf(MemoryStream)

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/pdf")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=""" & FileName & """.pdf")

                        Case RadToolBarButtonPrintToXLS.Value

                            'ASPxGridViewExporter.WriteXlsToResponse()
                            CompositeLink.ExportToXls(MemoryStream, New DevExpress.XtraPrinting.XlsExportOptions(DevExpress.XtraPrinting.TextExportMode.Text, False, False))

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/ms-excel")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=""" & FileName & """.xls")

                        Case RadToolBarButtonPrintToXLSValue.Value

                            'ASPxGridViewExporter.WriteXlsToResponse()
                            CompositeLink.ExportToXls(MemoryStream, New DevExpress.XtraPrinting.XlsExportOptions(DevExpress.XtraPrinting.TextExportMode.Value, False, False))

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/ms-excel")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=""" & FileName & """.xls")

                        Case RadToolBarButtonPrintToXLSX.Value

                            'ASPxGridViewExporter.WriteXlsxToResponse()
                            CompositeLink.ExportToXlsx(MemoryStream, New DevExpress.XtraPrinting.XlsxExportOptions(DevExpress.XtraPrinting.TextExportMode.Text, False, False))

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=""" & FileName & """.xlsx")

                        Case RadToolBarButtonPrintToXLSXValue.Value

                            'ASPxGridViewExporter.WriteXlsxToResponse()
                            CompositeLink.ExportToXlsx(MemoryStream, New DevExpress.XtraPrinting.XlsxExportOptions(DevExpress.XtraPrinting.TextExportMode.Value, False, False))

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=""" & FileName & """.xlsx")

                        Case RadToolBarButtonPrintToRTF.Value

                            'ASPxGridViewExporter.WriteRtfToResponse()
                            CompositeLink.ExportToRtf(MemoryStream)

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/rtf")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=""" & FileName & """.rtf")

                        Case RadToolBarButtonPrintToCSV.Value

                            'ASPxGridViewExporter.WriteCsvToResponse()
                            CompositeLink.ExportToCsv(MemoryStream)

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/csv")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=""" & FileName & """.csv")

                    End Select

                    System.Web.HttpContext.Current.Response.BinaryWrite(MemoryStream.ToArray)
                    'System.Web.HttpContext.Current.Response.Flush()
                    'System.Web.HttpContext.Current.Response.End()
                    'System.Web.HttpContext.Current.Response.Clear()

                    'Response.BinaryWrite(MemoryStream.GetBuffer())

                    HttpContext.Current.ApplicationInstance.CompleteRequest()

                    Try

                        System.Web.HttpContext.Current.Response.End()

                    Catch ex As Exception

                    End Try

                End Using

                PrintingSystem.Dispose()

            End Using

        Catch ex As Exception
            'AdvantageFramework.Navigation.ShowMessageBox(ex.Message)
        End Try

        ASPxLoadingPanel1.Visible = False

    End Sub
    Private Sub ASPxDashboardViewer_DashboardLoading(sender As Object, e As DevExpress.DashboardWeb.DashboardLoadingWebEventArgs) Handles ASPxDashboardViewer.DashboardLoading

        If _DynamicReportTemplateID > 0 Then

            If My.Computer.FileSystem.FileExists(HttpContext.Current.Server.MapPath("~\") & "TEMP\Dashboard" & _DynamicReportTemplateID & ".xml") Then

                e.DashboardXml = System.Xml.Linq.XDocument.Load(HttpContext.Current.Server.MapPath("~\") & "TEMP\Dashboard" & _DynamicReportTemplateID & ".xml")

            End If

        End If

    End Sub
    'Private Sub ASPxDashboardViewer_DashboardLoaded(sender As Object, e As DevExpress.DashboardWeb.DataLoadingWebEventHandler) Handles ASPxDashboardViewer.DataLoading

    '    'objects
    '    Dim DashboardObjectDataSource As DevExpress.DashboardCommon.DashboardObjectDataSource = Nothing

    '    If RadMultiPageReport.SelectedIndex = 1 OrElse Session("DRPT_UseBlankData") Then

    '        If TypeOf e.Dashboard.DataSources(0) Is DevExpress.DashboardCommon.DashboardObjectDataSource Then

    '            DashboardObjectDataSource = e.Dashboard.DataSources(0)

    '            DashboardObjectDataSource.Filter = ASPxGridViewDynamicReport.FilterExpression

    '            Try

    '                DashboardObjectDataSource.Fill()

    '            Catch ex As Exception

    '                DashboardObjectDataSource.Filter = Nothing

    '                DashboardObjectDataSource.Fill()

    '            End Try

    '            e.Dashboard.RebuildLayout()

    '        End If

    '    End If

    'End Sub
    Private Sub ASPxDashboardViewer_DataLoading(sender As Object, e As DevExpress.DashboardWeb.DataLoadingWebEventArgs) Handles ASPxDashboardViewer.DataLoading

        'objects
        Dim DashboardObjectDataSource As DevExpress.DashboardCommon.DashboardObjectDataSource = Nothing
        Dim ReportColumns As Generic.List(Of AdvantageFramework.Reporting.Classes.ReportColumn) = Nothing
        Dim DynamicReportData As IEnumerable = Nothing

        'If RadMultiPageReport.SelectedIndex = 1 OrElse Session("DRPT_UseBlankData") Then

        If Session("DRPT_Data") Is Nothing OrElse ASPxDashboardViewer.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailItem OrElse
                           _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetail OrElse
                           _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction OrElse
                           _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth Then

                        ReportColumns = New Generic.List(Of AdvantageFramework.Reporting.Classes.ReportColumn)

                        ReportColumns.Add(New AdvantageFramework.Reporting.Classes.ReportColumn With {.Index = -1, .ColumnName = "ID", .ReportColumnType = AdvantageFramework.Reporting.ReportColumnType.JobDetailItem})

                        For Each GridColumn In ASPxGridViewDynamicReport.VisibleColumns.OfType(Of DevExpress.Web.GridViewDataColumn).ToList

                            ReportColumns.Add(New AdvantageFramework.Reporting.Classes.ReportColumn With {.Index = GridColumn.Index, .ColumnName = GridColumn.FieldName, .ReportColumnType = AdvantageFramework.Reporting.ReportColumnType.JobDetailItem})

                        Next

                    End If

                    DynamicReportData = AdvantageFramework.Reporting.LoadDynamicReportData(DbContext, ReportingDbContext, RadComboBoxDynamicReport.SelectedValue,
                                                                                           Session("DRPT_UseBlankData"), Session("DRPT_Criteria"), Session("DRPT_FilterString"),
                                                                                           Session("DRPT_From"), Session("DRPT_To"), Session("DRPT_ShowJobsWithNoDetails"),
                                                                                           Session("DRPT_ParameterDictionary"), ReportColumns).OfType(Of Object).ToList

                    DashboardObjectDataSource = New DevExpress.DashboardCommon.DashboardObjectDataSource(DynamicReportData)

                    DashboardObjectDataSource.Filter = ASPxGridViewDynamicReport.FilterExpression

                    Try

                        DashboardObjectDataSource.Fill()

                    Catch ex As Exception

                        DashboardObjectDataSource.Filter = Nothing

                        DashboardObjectDataSource.Fill()

                    End Try

                    e.OverwriteDataSourceProperty = True

                    e.Data = DashboardObjectDataSource

                End Using

            End Using

        Else

            DashboardObjectDataSource = New DevExpress.DashboardCommon.DashboardObjectDataSource(Session("DRPT_Data"))

            DashboardObjectDataSource.Filter = ASPxGridViewDynamicReport.FilterExpression

            Try

                DashboardObjectDataSource.Fill()

            Catch ex As Exception

                DashboardObjectDataSource.Filter = Nothing

                DashboardObjectDataSource.Fill()

            End Try

            e.OverwriteDataSourceProperty = True

            e.Data = DashboardObjectDataSource

        End If

        Session("DRPT_Data") = Nothing

    End Sub
    Private Sub ASPxGridViewDynamicReport_ClientLayout(sender As Object, e As DevExpress.Web.ASPxClientLayoutArgs) Handles ASPxGridViewDynamicReport.ClientLayout

        If e.LayoutMode = DevExpress.Web.ClientLayoutMode.Saving Then

            Session("DRPT_Layout") = e.LayoutData

        Else

            e.LayoutData = Session("DRPT_Layout")

        End If

    End Sub
    Private Sub ASPxGridViewDynamicReport_CustomColumnDisplayText(sender As Object, e As DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs) Handles ASPxGridViewDynamicReport.CustomColumnDisplayText

        'If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AROpenAged Then

        '    If e.Column.FieldName = AdvantageFramework.Reporting.Database.Classes.AROpenAged.Properties.InvoiceNumber.ToString Then

        '        If e.Value.ToString <> "" Then

        '            e.DisplayText = e.Value.ToString.PadLeft(6, "0")

        '        End If

        '    End If

        'End If

        'If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatus Then

        '    If e.Column.FieldName = AdvantageFramework.Reporting.Database.Classes.MediaCurrentStatusReport.Properties.ARPaymentFlag.ToString OrElse
        '            e.Column.FieldName = AdvantageFramework.Reporting.Database.Classes.MediaCurrentStatusReport.Properties.APPaymentFlag.ToString Then

        '        If e.Value = 0 Then

        '            e.DisplayText = "No Payment"

        '        ElseIf e.Value = 1 Then

        '            e.DisplayText = "Full Payment"

        '        ElseIf e.Value = 2 Then

        '            e.DisplayText = "Partial Payment"

        '        End If

        '    End If

        'ElseIf _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatusSummary Then

        '    If e.Column.FieldName = AdvantageFramework.Reporting.Database.Classes.MediaCurrentStatusSummaryReport.Properties.ARPaymentFlag.ToString OrElse
        '            e.Column.FieldName = AdvantageFramework.Reporting.Database.Classes.MediaCurrentStatusSummaryReport.Properties.APPaymentFlag.ToString Then

        '        If e.Value = 0 Then

        '            e.DisplayText = "No Payment"

        '        ElseIf e.Value = 1 Then

        '            e.DisplayText = "Full Payment"

        '        ElseIf e.Value = 2 Then

        '            e.DisplayText = "Partial Payment"

        '        End If

        '    End If

        'End If

    End Sub

    Private Sub ASPxGridViewDynamicReport_RowValidating(sender As Object, e As DevExpress.Web.Data.ASPxDataValidationEventArgs) Handles ASPxGridViewDynamicReport.RowValidating

    End Sub

    Private Sub ASPxGridViewDynamicReport_SubstituteFilter(sender As Object, e As DevExpress.Data.SubstituteFilterEventArgs) Handles ASPxGridViewDynamicReport.SubstituteFilter



    End Sub

    Private Sub ASPxGridViewDynamicReport_PreRender(sender As Object, e As EventArgs) Handles ASPxGridViewDynamicReport.PreRender

        If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EmployeeUtilization Then
            For Each GridViewColumn In ASPxGridViewDynamicReport.Columns.OfType(Of DevExpress.Web.GridViewDataColumn)()

                If GridViewColumn IsNot Nothing Then

                    If GridViewColumn.FieldName = "DirectHoursGoal" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "BillableHoursGoal" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "PercentDirect" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "PercentNonDirect" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "PercentOfRequiredHours" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "PercentOfDirectHoursGoal" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "PercentOfBillableHoursGoal" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "PercentBilled" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "PercentBilledOfDirectHoursGoal" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "PercentBilledOfBillableHoursGoal" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "PercentBilledOfRequiredHours" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "AverageHourlyRateBilled" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "AverageHourlyRateAchieved" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If



                    If GridViewColumn.FieldName = "RequiredHours" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "BillableHours" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "BillableAmount" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "NonBillableHours" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "NonBillableAmount" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If

                    If GridViewColumn.FieldName = "AgencyHours" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "AgencyAmount" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "NewBusinessHours" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "NewBusinessAmount" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "TotalDirectHours" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "TotalDirectAmount" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "NonDirectHours" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "TotalHours" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "Variance" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "BilledHours" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If


                    If GridViewColumn.FieldName = "BilledHours" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "BilledAmount" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "WIPHours" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "WIPAmount" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If
                    If GridViewColumn.FieldName = "WriteUpDownAmount" Then
                        GridViewColumn.PropertiesEdit.DisplayFormatString = "n2"
                    End If


                End If
            Next
        End If


    End Sub

    'Private Sub ASPxGridViewDynamicReport_AfterPerformCallback(sender As Object, e As ASPxGridViewAfterPerformCallbackEventArgs) Handles ASPxGridViewDynamicReport.AfterPerformCallback
    '    Try
    '        ShowViewCaption()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub ASPxGridViewExporter_RenderBrick(sender As Object, e As ASPxGridViewExportRenderingEventArgs) Handles ASPxGridViewExporter.RenderBrick
    '    Try
    '        Dim dataColumn As GridViewDataColumn = TryCast(e.Column, GridViewDataColumn)

    '        If e.Value IsNot Nothing Then
    '            Dim t As Type = e.Value.GetType()

    '            If t.Name Then

    '            End If


    '        End If

    '        'If e.RowType = GridViewRowType.Data AndAlso dataColumn IsNot Nothing AndAlso dataColumn.FieldName = "PercentDirect" Then
    '        '    e.Text = String.Format(e.Text, "#,##0.00")
    '        'End If

    '    Catch ex As Exception

    '    End Try
    'End Sub


#End Region

#End Region

End Class
