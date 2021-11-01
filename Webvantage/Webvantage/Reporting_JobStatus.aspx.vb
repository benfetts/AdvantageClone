Public Class Reporting_JobStatus
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Protected _DynamicReportShowGroupByBox As Boolean = False
    Protected _DynamicReportShowViewCaption As Boolean = False
    Protected _DynamicReportShowAutoFilterRow As Boolean = False
    Protected _DynamicReportActiveFilter As String = ""
    Protected _DynamicReportTemplateID As Integer = 0
    Protected _UserDefinedReportCategoryID As Nullable(Of Integer) = Nothing
    Protected _DynamicReportDescription As String = ""
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

    Private Sub LoadDynamicReport()
        Try
            ClearReportData()
            LoadGrid()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub LoadDefaultGrid()
        Try
            Dim DataTable As System.Data.DataTable = Nothing
            ClearReportData()
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    Using SqlCommand = DbContext.CreateCommand()

                        DataTable = New System.Data.DataTable

                        SqlCommand.CommandType = CommandType.StoredProcedure
                        SqlCommand.CommandText = "advsp_job_detail_item_status_load"

                        SqlCommand.Parameters.AddWithValue("START_DATE", RadDatePickerFrom.SelectedDate)
                        SqlCommand.Parameters.AddWithValue("END_DATE", RadDatePickerTo.SelectedDate)
                        SqlCommand.Parameters.AddWithValue("DATE_TYPE", Me.RadComboBoxCriteria.SelectedValue)
                        SqlCommand.Parameters.AddWithValue("SHOW_JOBS_WO_DETAILS", Me.CheckBoxShowJobsWithNoDetails.Checked)
                        SqlCommand.Parameters.AddWithValue("SHOW_INVOICES", Me.CheckBoxShowInvoices.Checked)
                        SqlCommand.Parameters.AddWithValue("SHOW_CLOSED", Me.CheckBoxShowClosedJobs.Checked)
                        SqlCommand.Parameters.AddWithValue("UserID", _Session.User.UserCode)

                        SqlCommand.Connection.Open()

                        Try

                            DataTable.Load(SqlCommand.ExecuteReader)

                        Catch ex As Exception
                            DataTable = Nothing
                        Finally
                            SqlCommand.Connection.Close()
                        End Try

                        ASPxGridViewDynamicReport.AutoGenerateColumns = True
                        ASPxGridViewDynamicReport.DataSource = DataTable
                        ASPxGridViewDynamicReport.DataBind()
                    End Using

                    Session("DynamicReportFromDate") = RadDatePickerFrom.SelectedDate
                    Session("DynamicReportToDate") = RadDatePickerTo.SelectedDate
                    Session("DynamicReportDateType") = CShort(RadComboBoxCriteria.SelectedValue)
                    Session("DynamicReportShowJobsWithNoDetails") = Me.CheckBoxShowJobsWithNoDetails.Checked
                    Session("DynamicReportShowInvoices") = Me.CheckBoxShowInvoices.Checked
                    Session("DynamicReportShowClosedJobs") = Me.CheckBoxShowClosedJobs.Checked

                Catch ex As Exception
                    ASPxGridViewDynamicReport.DataSource = Nothing
                End Try

            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadGrid()

        'objects
        Dim DataTable As System.Data.DataTable = Nothing
        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Try

                Using SqlCommand = DbContext.CreateCommand()

                    DataTable = New System.Data.DataTable

                    SqlCommand.CommandType = CommandType.StoredProcedure
                    SqlCommand.CommandText = "advsp_job_detail_item_status_load"

                    SqlCommand.Parameters.AddWithValue("START_DATE", RadDatePickerFrom.SelectedDate)
                    SqlCommand.Parameters.AddWithValue("END_DATE", RadDatePickerTo.SelectedDate)
                    SqlCommand.Parameters.AddWithValue("DATE_TYPE", CShort(RadComboBoxCriteria.SelectedValue))
                    SqlCommand.Parameters.AddWithValue("SHOW_JOBS_WO_DETAILS", Me.CheckBoxShowJobsWithNoDetails.Checked)
                    SqlCommand.Parameters.AddWithValue("SHOW_INVOICES", Me.CheckBoxShowInvoices.Checked)
                    SqlCommand.Parameters.AddWithValue("SHOW_CLOSED", Me.CheckBoxShowClosedJobs.Checked)
                    SqlCommand.Parameters.AddWithValue("UserID", _Session.User.UserCode)
                    'SqlCommand.CommandTimeout = 1200
                    SqlCommand.Connection.Open()

                    Try

                        DataTable.Load(SqlCommand.ExecuteReader)

                    Catch ex As Exception
                        DataTable = Nothing
                    Finally
                        SqlCommand.Connection.Close()
                    End Try
                    ASPxGridViewDynamicReport.Columns.Clear()
                    ASPxGridViewDynamicReport.AutoGenerateColumns = True
                    ASPxGridViewDynamicReport.DataSource = DataTable
                    ASPxGridViewDynamicReport.DataBind()
                    SetColumns()
                End Using

            Catch ex As Exception
                ASPxGridViewDynamicReport.DataSource = Nothing
            End Try

        End Using

        ' FormatColumns(True)

        'For Each GridViewColumn In ASPxGridViewDynamicReport.Columns.OfType(Of DevExpress.Web.GridViewDataColumn)()
        '    GridViewColumn.Settings.AllowGroup = DevExpress.Utils.DefaultBoolean.True
        '    GridViewColumn.Settings.AllowSort = DevExpress.Utils.DefaultBoolean.True
        '    GridViewColumn.PropertiesEdit.Style.Wrap = DevExpress.Utils.DefaultBoolean.False
        '    If GridViewColumn.Visible Then
        '        GridViewColumn.Width = 100
        '    End If
        'Next


        Session("DynamicReportFromDate") = RadDatePickerFrom.SelectedDate
        Session("DynamicReportToDate") = RadDatePickerTo.SelectedDate
        Session("DynamicReportDateType") = CShort(RadComboBoxCriteria.SelectedValue)
        Session("DynamicReportShowJobsWithNoDetails") = Me.CheckBoxShowJobsWithNoDetails.Checked
        Session("DynamicReportShowInvoices") = Me.CheckBoxShowInvoices.Checked
        Session("DynamicReportDataTable") = DataTable

        'Try

        '    Session("DRPT_ShowGroupByBox") = RadToolBarButtonShowGroupByBox.Checked

        'Catch ex As Exception
        '    Session("DRPT_ShowGroupByBox") = False
        'End Try

        'Try

        '    Session("DRPT_ShowViewCaption") = RadToolBarButtonShowViewCaption.Checked

        'Catch ex As Exception
        '    Session("DRPT_ShowViewCaption") = False
        'End Try

        'Try

        '    Session("DRPT_ShowAutoFilterRow") = RadToolBarButtonShowAutoFilterRow.Checked

        'Catch ex As Exception
        '    Session("DRPT_ShowAutoFilterRow") = False
        'End Try

        'Try

        '    Session("DRPT_ActiveFilter") = ASPxGridViewDynamicReport.FilterExpression

        'Catch ex As Exception
        '    Session("DRPT_ActiveFilter") = ""
        'End Try

    End Sub

    Private Sub LoadSettings(ByVal DynamicReportID As Integer)
        Try
            Dim Setting As AdvantageFramework.Database.Entities.DynamicReportSettings = Nothing
            Dim SettingValue As AdvantageFramework.Database.Entities.DynamicReportSettings = Nothing

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "FromDate") IsNot Nothing Then
                    Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "FromDate")
                    Me.RadDatePickerFrom.SelectedDate = CDate(Setting.DynamicReportSettingValue)
                End If
                If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "ToDate") IsNot Nothing Then
                    Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "ToDate")
                    Me.RadDatePickerTo.SelectedDate = CDate(Setting.DynamicReportSettingValue)
                End If
                If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "Criteria") IsNot Nothing Then
                    Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "Criteria")
                    Me.RadComboBoxCriteria.SelectedValue = Setting.DynamicReportSettingValue
                End If
                If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "ShowJobsWithNoDetails") IsNot Nothing Then
                    Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "ShowJobsWithNoDetails")
                    Me.CheckBoxShowJobsWithNoDetails.Checked = Setting.DynamicReportSettingValue
                End If
                If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "ShowInvoices") IsNot Nothing Then
                    Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "ShowInvoices")
                    Me.CheckBoxShowInvoices.Checked = Setting.DynamicReportSettingValue
                End If
                If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "ShowClosed") IsNot Nothing Then
                    Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "ShowClosed")
                    Me.CheckBoxShowClosedJobs.Checked = Setting.DynamicReportSettingValue
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadComboboxes()
        Try

            RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobDetailInitialCriteria), False)
            RadComboBoxCriteria.DataBind()

            If Request.QueryString("From") = "reportJS" Then
                If Not Session("DynamicReportDateType") Is Nothing Then
                    RadComboBoxCriteria.SelectedValue = Session("DynamicReportDateType")
                End If
                If Not Session("DynamicReportShowClosedJobs") Is Nothing Then
                    CheckBoxShowJobsWithNoDetails.Checked = Session("DynamicReportShowClosedJobs")
                End If
                If Not Session("DynamicReportShowClosedJobs") Is Nothing Then
                    CheckBoxShowClosedJobs.Checked = Session("DynamicReportShowClosedJobs")
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClearReportData()

        ASPxGridViewDynamicReport.ClearSort()
        ASPxGridViewDynamicReport.GroupSummary.Clear()
        ASPxGridViewDynamicReport.GroupSummarySortInfo.Clear()
        ASPxGridViewDynamicReport.FilterExpression = ""
        ASPxGridViewDynamicReport.DataSource = Nothing

        If ASPxGridViewDynamicReport.Columns.Count > 0 Then

            ASPxGridViewDynamicReport.Columns.Clear()

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

    Private Sub FormatColumns(ByVal FirstLoad As Boolean)

        'objects
        Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
        Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
        Dim HeaderText As String = ""
        Dim ObjectType As System.Type = Nothing
        Dim DefaultSort As String = ""

        If ASPxGridViewDynamicReport.Columns.Count > 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    ' DefaultSort = AdvantageFramework.Reporting.LoadDynamicReportDefaultSort(RadComboBoxDynamicReport.SelectedValue)

                Catch ex As Exception
                    DefaultSort = ""
                End Try

                'ObjectType = AdvantageFramework.Reporting.LoadDynamicReportObjectType(DynamicReport)

                For Each GridViewColumn In ASPxGridViewDynamicReport.Columns.OfType(Of DevExpress.Web.GridViewDataColumn)()

                    GridViewColumn.Settings.AllowGroup = DevExpress.Utils.DefaultBoolean.True
                    GridViewColumn.Settings.AllowSort = DevExpress.Utils.DefaultBoolean.True
                    GridViewColumn.DataItemTemplate = New AdvantageFramework.Web.Presentation.Controls.DynamicReportTemplateColumn(GridViewColumn.FieldName)

                    Try

                        PropertyDescriptor = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(ObjectType).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                              Where [Property].Name = GridViewColumn.FieldName
                                              Select [Property]).Single

                    Catch ex As Exception
                        PropertyDescriptor = Nothing
                    End Try

                    If PropertyDescriptor IsNot Nothing Then

                        If PropertyDescriptor.PropertyType.Name.Contains("ICollection") AndAlso PropertyDescriptor.PropertyType.BaseType IsNot Nothing AndAlso
                                    PropertyDescriptor.PropertyType.BaseType.Name.Contains("Entity") Then

                            ASPxGridViewDynamicReport.Columns.Remove(GridViewColumn)

                        Else

                            Try

                                EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).Single

                            Catch ex As Exception
                                EntityAttribute = Nothing
                            Finally

                                If EntityAttribute IsNot Nothing Then

                                    If EntityAttribute.DisplayFormat <> "" Then

                                        GridViewColumn.PropertiesEdit.DisplayFormatString = EntityAttribute.DisplayFormat

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

                                'If DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobSummary OrElse _
                                '            DynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectSchedule OrElse _
                                '            DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobProjectScheduleSummary OrElse _
                                '            DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetail OrElse _
                                '            DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth OrElse _
                                '            DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction OrElse _
                                '            DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailItem OrElse _
                                '            DynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectHoursUsed Then

                                '    If GridViewColumn.FieldName.StartsWith("LabelAssign") OrElse _
                                '            GridViewColumn.FieldName.StartsWith("LabelFromUDFTable") OrElse _
                                '            GridViewColumn.FieldName.StartsWith("CompLabelFromUDFTable") Then

                                '        GridViewColumn.Visible = AdvantageFramework.Reporting.LoadDynamicColumnHeader(DbContext, GridViewColumn.FieldName, _
                                '                                                                                      GridViewColumn.Caption, False, _
                                '                                                                                      GridViewColumn.ShowInCustomizationForm, False, _
                                '                                                                                      GridViewColumn.Settings.ShowFilterRowMenu, _
                                '                                                                                      GridViewColumn.Settings.ShowInFilterControl)

                                '    End If

                                'End If

                            End If

                        End If

                    End If

                Next

            End Using

        End If

    End Sub
    Private Sub SaveDynamicReportTemplate(ByRef ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByRef DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport)

        'objects
        Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing
        Dim DynamicReportSummaryItem As AdvantageFramework.Reporting.Database.Entities.DynamicReportSummaryItem = Nothing
        Dim JobTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing

        DynamicReport.Type = AdvantageFramework.Reporting.DynamicReports.JobStatus
        DynamicReport.ShowGroupByBox = RadToolBarButtonShowGroupByBox.Checked
        DynamicReport.ShowViewCaption = RadToolBarButtonShowViewCaption.Checked
        DynamicReport.ShowAutoFilterRow = RadToolBarButtonShowAutoFilterRow.Checked
        DynamicReport.ActiveFilter = ASPxGridViewDynamicReport.FilterExpression

        DynamicReport.UpdatedByUserCode = ReportingDbContext.UserCode
        DynamicReport.UpdatedDate = Now

        If AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Update(ReportingDbContext, DynamicReport) Then

            For Each GridViewColumn In ASPxGridViewDynamicReport.Columns.OfType(Of DevExpress.Web.GridViewDataColumn)()

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
                                                                                          GridViewColumn.VisibleIndex, Nothing, Nothing)


                End If

            Next

            SaveReportStateToSession()

            SaveDyanmicReportSetting(DynamicReport.ID)

            Me.Title = "Report Writer - " & DynamicReport.Description

            Response.Redirect([String].Format("Reporting_JobStatus.aspx?From=reportJS&DynamicReportTemplateID={0}", DynamicReport.ID))

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
        DynamicReport.Type = AdvantageFramework.Reporting.DynamicReports.JobStatus
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
                                                                                  GridViewColumn.VisibleIndex, Nothing, Nothing)



            Next

            SaveReportStateToSession()

            SaveDyanmicReportSetting(DynamicReport.ID)

            Me.Title = "Report Writer - " & DynamicReport.Description

            Response.Redirect([String].Format("Reporting_JobStatus.aspx?From=reportJS&DynamicReportTemplateID={0}", DynamicReport.ID))

        End If

    End Sub
    Private Sub SaveAsDynamicReportTemplate()

        SaveReportStateToSession()

        Me.OpenWindow("Save As", "Reporting_SaveDynamicJobStatusReportTemplate.aspx", 200, 600)

    End Sub
    Private Sub SaveReportStateToSession()

        'objects
        Dim DynamicReportColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing
        Dim DynamicReportColumn As AdvantageFramework.Database.Classes.DynamicReportColumn = Nothing

        Try

            Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.JobStatus

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
            DynamicReportColumn.VisibleIndex = GridViewColumn.VisibleIndex

            DynamicReportColumnsList.Add(DynamicReportColumn)

        Next

        Session("DRPT_ColumnsListJS") = DynamicReportColumnsList

        Session("DRPT_JobStatusFromDate") = Me.RadDatePickerFrom.SelectedDate
        Session("DRPT_JobStatusToDate") = Me.RadDatePickerTo.SelectedDate
        Session("DRPT_JobStatusCriteria") = Me.RadComboBoxCriteria.SelectedValue
        Session("DRPT_JobStatusShowJobWithNoDetails") = If(CheckBoxShowJobsWithNoDetails.Checked, 1, 0)
        Session("DRPT_JobStatusShowInvoices") = If(CheckBoxShowInvoices.Checked, 1, 0)

    End Sub
    Private Sub SetColumns()
        Try
            Dim DRPT_ColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing
            Dim GridViewColumn As DevExpress.Web.GridViewDataColumn = Nothing
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _DynamicReportTemplateID)

                If Session("DRPT_ColumnsListJS") Is Nothing Then

                    For Each DynamicReportColumn In DynamicReport.DynamicReportColumns.OrderBy(Function(Column) Column.VisibleIndex).ToList

                        GridViewColumn = ASPxGridViewDynamicReport.Columns(DynamicReportColumn.FieldName)

                        If GridViewColumn IsNot Nothing Then

                            GridViewColumn.Caption = DynamicReportColumn.HeaderText
                            GridViewColumn.Width = System.Web.UI.WebControls.Unit.Pixel(DynamicReportColumn.Width)

                            If DynamicReportColumn.IsVisible = False Then

                                GridViewColumn.VisibleIndex = -1

                            Else

                                GridViewColumn.Visible = True
                                GridViewColumn.VisibleIndex = DynamicReportColumn.VisibleIndex

                            End If

                            If GridViewColumn.Visible AndAlso GridViewColumn.Width.Value = 0 Then

                                GridViewColumn.Width = System.Web.UI.WebControls.Unit.Pixel(100)

                            End If

                            GridViewColumn.SortIndex = DynamicReportColumn.SortIndex
                            GridViewColumn.SortOrder = DynamicReportColumn.SortOrder
                            GridViewColumn.GroupIndex = DynamicReportColumn.GroupIndex

                        End If

                    Next

                    'LoadGrid()

                    For Each GridColumn In ASPxGridViewDynamicReport.Columns.OfType(Of DevExpress.Web.GridViewDataColumn)().Where(Function(GC) GC.UnboundType = DevExpress.Data.UnboundColumnType.Bound).ToList

                        If AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.LoadByDynamicReportID(ReportingDbContext, DynamicReport.ID).Any(Function(Entity) Entity.FieldName = GridColumn.FieldName) = False Then

                            GridColumn.Visible = False

                        End If

                    Next

                Else

                    Try
                        DRPT_ColumnsList = Session("DRPT_ColumnsListJS")

                        For Each DynamicReportColumnClass In DRPT_ColumnsList

                            GridViewColumn = ASPxGridViewDynamicReport.Columns(DynamicReportColumnClass.FieldName)

                            If GridViewColumn IsNot Nothing Then

                                GridViewColumn.Caption = DynamicReportColumnClass.HeaderText
                                GridViewColumn.Width = System.Web.UI.WebControls.Unit.Pixel(DynamicReportColumnClass.Width)

                                If DynamicReportColumnClass.IsVisible = False Then

                                    GridViewColumn.VisibleIndex = -1

                                Else

                                    GridViewColumn.Visible = True
                                    GridViewColumn.VisibleIndex = DynamicReportColumnClass.VisibleIndex

                                End If

                                If GridViewColumn.Visible AndAlso GridViewColumn.Width.Value = 0 Then

                                    GridViewColumn.Width = 100

                                End If

                                GridViewColumn.SortIndex = DynamicReportColumnClass.SortIndex
                                GridViewColumn.SortOrder = DynamicReportColumnClass.SortOrder
                                GridViewColumn.GroupIndex = DynamicReportColumnClass.GroupIndex

                            End If

                        Next

                        'LoadGrid()

                    Catch ex As Exception

                    End Try

                End If

            End Using
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SaveDyanmicReportSetting(ByVal DynamicReportID As Integer)
        Dim Setting As AdvantageFramework.Database.Entities.DynamicReportSettings = Nothing
        Dim SettingValue As AdvantageFramework.Database.Entities.DynamicReportSettings = Nothing
        Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.DynamicReportSettings) = Nothing
        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
            Try
                If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "FromDate") Is Nothing Then
                    Setting = New AdvantageFramework.Database.Entities.DynamicReportSettings
                    Setting.DataContext = DataContext
                    Setting.DynamicReportID = DynamicReportID
                    Setting.DynamicReportSettingName = "FromDate"
                    Setting.DynamicReportSettingValue = Me.RadDatePickerFrom.SelectedDate
                    AdvantageFramework.Database.Procedures.DynamicReportSettings.Insert(DataContext, Setting)
                Else
                    Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "FromDate")
                    Setting.DynamicReportSettingValue = Me.RadDatePickerFrom.SelectedDate
                    AdvantageFramework.Database.Procedures.DynamicReportSettings.Update(DataContext, Setting)
                End If
                If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "ToDate") Is Nothing Then
                    Setting = New AdvantageFramework.Database.Entities.DynamicReportSettings
                    Setting.DataContext = DataContext
                    Setting.DynamicReportID = DynamicReportID
                    Setting.DynamicReportSettingName = "ToDate"
                    Setting.DynamicReportSettingValue = Me.RadDatePickerTo.SelectedDate
                    AdvantageFramework.Database.Procedures.DynamicReportSettings.Insert(DataContext, Setting)
                Else
                    Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "ToDate")
                    Setting.DynamicReportSettingValue = Me.RadDatePickerTo.SelectedDate
                    AdvantageFramework.Database.Procedures.DynamicReportSettings.Update(DataContext, Setting)
                End If
                If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "Criteria") Is Nothing Then
                    Setting = New AdvantageFramework.Database.Entities.DynamicReportSettings
                    Setting.DataContext = DataContext
                    Setting.DynamicReportID = DynamicReportID
                    Setting.DynamicReportSettingName = "Criteria"
                    Setting.DynamicReportSettingValue = RadComboBoxCriteria.SelectedValue
                    AdvantageFramework.Database.Procedures.DynamicReportSettings.Insert(DataContext, Setting)
                Else
                    Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "Criteria")
                    Setting.DynamicReportSettingValue = RadComboBoxCriteria.SelectedValue
                    AdvantageFramework.Database.Procedures.DynamicReportSettings.Update(DataContext, Setting)
                End If
                If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "ShowJobsWithNoDetails") Is Nothing Then
                    Setting = New AdvantageFramework.Database.Entities.DynamicReportSettings
                    Setting.DataContext = DataContext
                    Setting.DynamicReportID = DynamicReportID
                    Setting.DynamicReportSettingName = "ShowJobsWithNoDetails"
                    Setting.DynamicReportSettingValue = If(CheckBoxShowJobsWithNoDetails.Checked, 1, 0)
                    AdvantageFramework.Database.Procedures.DynamicReportSettings.Insert(DataContext, Setting)
                Else
                    Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "ShowJobsWithNoDetails")
                    Setting.DynamicReportSettingValue = If(CheckBoxShowJobsWithNoDetails.Checked, 1, 0)
                    AdvantageFramework.Database.Procedures.DynamicReportSettings.Update(DataContext, Setting)
                End If
                If AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "ShowInvoices") Is Nothing Then
                    Setting = New AdvantageFramework.Database.Entities.DynamicReportSettings
                    Setting.DataContext = DataContext
                    Setting.DynamicReportID = DynamicReportID
                    Setting.DynamicReportSettingName = "ShowInvoices"
                    Setting.DynamicReportSettingValue = If(CheckBoxShowInvoices.Checked, 1, 0)
                    AdvantageFramework.Database.Procedures.DynamicReportSettings.Insert(DataContext, Setting)
                Else
                    Setting = AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingReportIDAndSettingName(DataContext, DynamicReportID, "ShowInvoices")
                    Setting.DynamicReportSettingValue = If(CheckBoxShowInvoices.Checked, 1, 0)
                    AdvantageFramework.Database.Procedures.DynamicReportSettings.Update(DataContext, Setting)
                End If


            Catch ex As Exception

            End Try
        End Using
    End Sub


#Region "  Form Event Handlers "

    Private Sub Reporting_JobStatus_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Try
            If Not Me.IsPostBack AndAlso Not Me.IsCallback Then
                LoadComboboxes()
                Me.RadDatePickerFrom.SelectedDate = Date.Now
                Me.RadDatePickerTo.SelectedDate = Date.Now
                If Request.QueryString("From") = "reportJS" Then
                    If Not Session("DynamicReportFromDate") Is Nothing Then
                        RadDatePickerFrom.SelectedDate = Session("DynamicReportFromDate")
                    End If
                    If Not Session("DynamicReportToDate") Is Nothing Then
                        RadDatePickerTo.SelectedDate = Session("DynamicReportToDate")
                    End If
                    If Not Session("DynamicReportShowInvoices") Is Nothing Then
                        Me.CheckBoxShowInvoices.Checked = Session("DynamicReportShowInvoices")
                    End If
                End If

            End If
            Try

                If Request.QueryString("DynamicReportTemplateID") IsNot Nothing Then

                    _DynamicReportTemplateID = CType(Request.QueryString("DynamicReportTemplateID"), Integer)

                End If

            Catch ex As Exception
                _DynamicReportTemplateID = 0
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
                _DynamicReportDescription = Session("DRPT_Description")
            Catch ex As Exception

            End Try

            Try
                _UserDefinedReportCategoryID = If(IsNumeric(Session("DRPT_UDRCategory")), CInt(Session("DRPT_UDRCategory")), Nothing)
            Catch ex As Exception
                _UserDefinedReportCategoryID = ""
            End Try
        Catch ex As Exception
            _DynamicReportDescription = ""
        End Try
    End Sub

    Private Sub Reporting_JobStatus_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            If ASPxGridViewDynamicReport.FilterEnabled = False Then

                ASPxGridViewDynamicReport.FilterEnabled = True

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Reporting_JobStatus_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        Try
            'objects
            Dim DRPT_ColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing
            Dim DynamicReportColumnClass As AdvantageFramework.Database.Classes.DynamicReportColumn = Nothing
            Dim GridViewColumn As DevExpress.Web.GridViewDataColumn = Nothing
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing
            Dim EventArgs As String = ""

            If Me.Request.Form("__CALLBACKID") <> "" AndAlso Me.Request.Form("__CALLBACKID").Contains(ASPxGridViewDynamicReport.ID) Then

                LoadGrid()

            Else

                If (Not Me.IsPostBack AndAlso Not Me.IsCallback) Or Me.EventArgument = "Refresh" Then

                    If _DynamicReportTemplateID > 0 Then

                        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _DynamicReportTemplateID)

                            If DynamicReport IsNot Nothing Then

                                ASPxGridViewDynamicReport.BeginUpdate()

                                _DynamicReportDescription = DynamicReport.Description
                                _UserDefinedReportCategoryID = DynamicReport.UserDefinedReportCategoryID

                                LoadSettings(DynamicReport.ID)

                                LoadGrid()

                                RadToolBarButtonShowGroupByBox.Checked = If(Session("DRPT_ShowGroupByBox") Is Nothing, DynamicReport.ShowGroupByBox, Session("DRPT_ShowGroupByBox"))
                                RadToolBarButtonShowViewCaption.Checked = If(Session("DRPT_ShowViewCaption") Is Nothing, DynamicReport.ShowViewCaption, Session("DRPT_ShowViewCaption"))
                                RadToolBarButtonShowAutoFilterRow.Checked = If(Session("DRPT_ShowAutoFilterRow") Is Nothing, DynamicReport.ShowAutoFilterRow, Session("DRPT_ShowAutoFilterRow"))

                                ShowGroupByBox()
                                ShowViewCaption()
                                ShowAutoFilterRow()

                                If Session("JS_FilterReport_FilterString") Is Nothing Then

                                    ASPxGridViewDynamicReport.FilterExpression = DynamicReport.ActiveFilter

                                Else

                                    ASPxGridViewDynamicReport.FilterExpression = Session("JS_FilterReport_FilterString")

                                End If

                                If Session("DRPT_ColumnsListJS") Is Nothing Then

                                    For Each DynamicReportColumn In DynamicReport.DynamicReportColumns.OrderBy(Function(Column) Column.VisibleIndex).ToList

                                        GridViewColumn = ASPxGridViewDynamicReport.Columns(DynamicReportColumn.FieldName)

                                        If GridViewColumn IsNot Nothing Then

                                            GridViewColumn.Caption = DynamicReportColumn.HeaderText
                                            GridViewColumn.Width = System.Web.UI.WebControls.Unit.Pixel(DynamicReportColumn.Width)

                                            If DynamicReportColumn.IsVisible = False Then

                                                GridViewColumn.VisibleIndex = -1

                                            Else

                                                GridViewColumn.Visible = True
                                                GridViewColumn.VisibleIndex = DynamicReportColumn.VisibleIndex

                                            End If

                                            If GridViewColumn.Visible AndAlso GridViewColumn.Width.Value = 0 Then

                                                GridViewColumn.Width = System.Web.UI.WebControls.Unit.Pixel(100)

                                            End If

                                            GridViewColumn.SortIndex = DynamicReportColumn.SortIndex
                                            GridViewColumn.SortOrder = DynamicReportColumn.SortOrder
                                            GridViewColumn.GroupIndex = DynamicReportColumn.GroupIndex

                                        End If

                                    Next

                                    'LoadGrid()

                                    For Each GridColumn In ASPxGridViewDynamicReport.Columns.OfType(Of DevExpress.Web.GridViewDataColumn)().Where(Function(GC) GC.UnboundType = DevExpress.Data.UnboundColumnType.Bound).ToList

                                        If AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.LoadByDynamicReportID(ReportingDbContext, DynamicReport.ID).Any(Function(Entity) Entity.FieldName = GridColumn.FieldName) = False Then

                                            GridColumn.Visible = False

                                        End If

                                    Next

                                Else

                                    Try
                                        DRPT_ColumnsList = Session("DRPT_ColumnsListJS")

                                        For Each DynamicReportColumnClass In DRPT_ColumnsList

                                            GridViewColumn = ASPxGridViewDynamicReport.Columns(DynamicReportColumnClass.FieldName)

                                            If GridViewColumn IsNot Nothing Then

                                                GridViewColumn.Caption = DynamicReportColumnClass.HeaderText
                                                GridViewColumn.Width = System.Web.UI.WebControls.Unit.Pixel(DynamicReportColumnClass.Width)

                                                If DynamicReportColumnClass.IsVisible = False Then

                                                    GridViewColumn.VisibleIndex = -1

                                                Else

                                                    GridViewColumn.Visible = True
                                                    GridViewColumn.VisibleIndex = DynamicReportColumnClass.VisibleIndex

                                                End If

                                                If GridViewColumn.Visible AndAlso GridViewColumn.Width.Value = 0 Then

                                                    GridViewColumn.Width = 100

                                                End If

                                                GridViewColumn.SortIndex = DynamicReportColumnClass.SortIndex
                                                GridViewColumn.SortOrder = DynamicReportColumnClass.SortOrder
                                                GridViewColumn.GroupIndex = DynamicReportColumnClass.GroupIndex

                                            End If

                                        Next

                                        'LoadGrid()

                                    Catch ex As Exception

                                    End Try

                                End If

                                Me.Title = "Job Status Report - " & DynamicReport.Description

                                ASPxGridViewDynamicReport.EndUpdate()

                            Else

                                Me.Title = "Job Status Report - " & DynamicReport.Description

                            End If

                        End Using

                    Else
                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ASPxGridViewDynamicReport.BeginUpdate()

                            LoadGrid()

                            RadToolBarButtonShowGroupByBox.Checked = _DynamicReportShowGroupByBox
                            RadToolBarButtonShowViewCaption.Checked = _DynamicReportShowViewCaption
                            RadToolBarButtonShowAutoFilterRow.Checked = _DynamicReportShowAutoFilterRow


                            ShowGroupByBox()
                            ShowViewCaption()
                            ShowAutoFilterRow()

                            If Session("JS_FilterReport_FilterString") Is Nothing Then

                                ASPxGridViewDynamicReport.FilterExpression = _DynamicReportActiveFilter

                            End If

                            ASPxGridViewDynamicReport.EndUpdate()

                            If Session("DRPT_ColumnsListJS") IsNot Nothing Then

                                LoadGrid()

                                If Session("JS_FilterReport_FilterString") IsNot Nothing Then
                                    ASPxGridViewDynamicReport.FilterExpression = Session("JS_FilterReport_FilterString")
                                    Session("JS_FilterReport_FilterString") = Nothing
                                End If

                                Try

                                    DRPT_ColumnsList = Session("DRPT_ColumnsListJS")

                                    For Each DynamicReportColumnClass In DRPT_ColumnsList

                                        GridViewColumn = ASPxGridViewDynamicReport.Columns(DynamicReportColumnClass.FieldName)

                                        If GridViewColumn IsNot Nothing Then

                                            GridViewColumn.Caption = DynamicReportColumnClass.HeaderText
                                            GridViewColumn.Visible = DynamicReportColumnClass.IsVisible

                                            If GridViewColumn.Visible AndAlso GridViewColumn.Width.Value = 0 Then

                                                GridViewColumn.Width = 100

                                            End If

                                        End If

                                    Next

                                Catch ex As Exception

                                End Try

                                'Session("DRPT_ColumnsListJV") = Nothing

                            ElseIf Session("JS_FilterReport_FilterString") IsNot Nothing Then

                                LoadGrid()

                                ASPxGridViewDynamicReport.FilterExpression = Session("JS_FilterReport_FilterString")

                                Session("JS_FilterReport_FilterString") = Nothing

                            ElseIf Session("DRPT_FilterString") IsNot Nothing Then

                                LoadGrid()

                            ElseIf Session("DRPT_UseBlankData") = False AndAlso Session("DRPT_FilterString") Is Nothing Then

                                LoadGrid()

                            End If

                        End Using

                        Me.Title = "Job Status Report - " & _DynamicReportDescription

                    End If

                Else
                    Me.Title = "Job Status Report - " & _DynamicReportDescription
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarOptions_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarOptions.ButtonClick

        'objects
        Dim DRPT_ColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing
        Dim DynamicReportColumn As AdvantageFramework.Database.Classes.DynamicReportColumn = Nothing
        Dim GridViewColumn As DevExpress.Web.GridViewDataColumn = Nothing
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing

        If TypeOf e.Item Is Telerik.Web.UI.RadToolBarButton Then

            Select Case DirectCast(e.Item, Telerik.Web.UI.RadToolBarButton).CommandName

                Case RadToolBarButtonRefresh.CommandName

                    Session("DynamicReportFromDate") = RadDatePickerFrom.SelectedDate
                    Session("DynamicReportToDate") = RadDatePickerTo.SelectedDate
                    LoadGrid()

                Case RadToolBarButtonShowViewCaption.CommandName

                    ShowViewCaption()

                Case RadToolBarButtonShowGroupByBox.CommandName

                    ShowGroupByBox()

                Case RadToolBarButtonShowAutoFilterRow.CommandName

                    ShowAutoFilterRow()

                Case RadToolBarButtonShowFilterEditor.CommandName

                    Session("JS_FilterReport_FilterString") = ASPxGridViewDynamicReport.FilterExpression

                    Me.OpenWindow("Filter Report", String.Format("Reporting_FilterReport.aspx?Type=2&From=reportJS&DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 1100, False, True)

                Case RadToolBarButtonCustomizeColumns.CommandName

                    DRPT_ColumnsList = New Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn)

                    For Each GridViewColumn In ASPxGridViewDynamicReport.Columns.OfType(Of DevExpress.Web.GridViewDataColumn)().Where(Function(Column) Column.ShowInCustomizationForm)

                        DynamicReportColumn = New AdvantageFramework.Database.Classes.DynamicReportColumn

                        DynamicReportColumn.FieldName = GridViewColumn.FieldName

                        If GridViewColumn.Caption = Nothing OrElse GridViewColumn.Caption Is Nothing OrElse GridViewColumn.Caption = "" Then

                            DynamicReportColumn.HeaderText = AdvantageFramework.StringUtilities.GetNameAsWords(GridViewColumn.FieldName)

                        Else

                            DynamicReportColumn.HeaderText = GridViewColumn.Caption

                        End If

                        DynamicReportColumn.IsVisible = GridViewColumn.Visible
                        DynamicReportColumn.SortIndex = GridViewColumn.SortIndex
                        DynamicReportColumn.SortOrder = GridViewColumn.SortOrder
                        DynamicReportColumn.GroupIndex = GridViewColumn.GroupIndex
                        DynamicReportColumn.Width = GridViewColumn.Width.Value
                        DynamicReportColumn.VisibleIndex = GridViewColumn.VisibleIndex

                        DRPT_ColumnsList.Add(DynamicReportColumn)

                    Next

                    Session("DRPT_ColumnsListJS") = DRPT_ColumnsList

                    Me.OpenWindow("Edit Report Columns", String.Format("Reporting_DynamicReportColumnEdit.aspx?From=reportJS&DynamicReportTemplateID={0}", _DynamicReportTemplateID), 525, 575, False, False, "Refresh")

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
            End Select

        End If

    End Sub
    Private Sub RadToolBarPrinting_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarPrinting.ButtonClick

        'objects
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
        Dim GridViewLink As DevExpress.Web.Export.GridViewLink = Nothing
        Dim CompositeLink As DevExpress.XtraPrintingLinks.CompositeLink = Nothing
        Dim PrintingSystem As DevExpress.XtraPrinting.PrintingSystem = Nothing
        Dim FileName As String = ""

        Try

            LoadGrid()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                'DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _DynamicReportTemplateID)

                ' If DynamicReport IsNot Nothing Then

                ASPxGridViewExporter.ReportHeader = "JobStatus"

                ASPxGridViewExporter.ReportFooter = _DynamicReportActiveFilter 'DynamicReport.ActiveFilter

                ASPxGridViewExporter.FileName = "Job Status Report"

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

                ' Else

                'If AdvantageFramework.EnumUtilities.IsMemberOfEnum(GetType(AdvantageFramework.Reporting.DynamicReports), CInt(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.DynamicReports), RadComboBoxDynamicReport.SelectedValue))) Then

                '    FileName = CType(RadComboBoxDynamicReport.SelectedValue, AdvantageFramework.Reporting.DynamicReports).ToString

                'Else

                '    FileName = "ASPxGridViewExporter"

                'End If

                'End If

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
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & FileName & ".pdf")

                        Case RadToolBarButtonPrintToXLS.Value

                            'ASPxGridViewExporter.WriteXlsToResponse()
                            CompositeLink.ExportToXls(MemoryStream, New DevExpress.XtraPrinting.XlsExportOptions(DevExpress.XtraPrinting.TextExportMode.Text, False, False))

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/ms-excel")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & FileName & ".xls")

                        Case RadToolBarButtonPrintToXLSValue.Value

                            'ASPxGridViewExporter.WriteXlsToResponse()
                            CompositeLink.ExportToXls(MemoryStream, New DevExpress.XtraPrinting.XlsExportOptions(DevExpress.XtraPrinting.TextExportMode.Value, False, False))

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/ms-excel")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & FileName & ".xls")

                        Case RadToolBarButtonPrintToXLSX.Value

                            'ASPxGridViewExporter.WriteXlsxToResponse()
                            CompositeLink.ExportToXlsx(MemoryStream, New DevExpress.XtraPrinting.XlsxExportOptions(DevExpress.XtraPrinting.TextExportMode.Text, False, False))

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & FileName & ".xlsx")

                        Case RadToolBarButtonPrintToXLSXValue.Value

                            'ASPxGridViewExporter.WriteXlsxToResponse()
                            CompositeLink.ExportToXlsx(MemoryStream, New DevExpress.XtraPrinting.XlsxExportOptions(DevExpress.XtraPrinting.TextExportMode.Value, False, False))

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & FileName & ".xlsx")

                        Case RadToolBarButtonPrintToRTF.Value

                            'ASPxGridViewExporter.WriteRtfToResponse()
                            CompositeLink.ExportToRtf(MemoryStream)

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/rtf")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & FileName & ".rtf")

                        Case RadToolBarButtonPrintToCSV.Value

                            'ASPxGridViewExporter.WriteCsvToResponse()
                            CompositeLink.ExportToCsv(MemoryStream)

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/csv")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & FileName & ".csv")

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

    End Sub

    Private Sub RadButton1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton1Year.Click

        RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday.AddYears(-1)
        RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

    End Sub
    Private Sub RadButton2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton2Years.Click

        RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday.AddYears(-2)
        RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

    End Sub
    Private Sub RadButtonMTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonMTD.Click

        RadDatePickerFrom.SelectedDate = CDate(Now.Month & "/1/" & Now.Year)
        RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

    End Sub
    Private Sub RadButtonYTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonYTD.Click

        RadDatePickerFrom.SelectedDate = CDate("1/1/" & Now.Year)
        RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

    End Sub
    Private Sub RadDatePickerFrom_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerFrom.SelectedDateChanged

        RadDatePickerTo.MinDate = RadDatePickerFrom.SelectedDate

    End Sub
    Private Sub RadDatePickerTo_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerTo.SelectedDateChanged

        RadDatePickerFrom.MaxDate = RadDatePickerTo.SelectedDate

    End Sub

    Private Sub ASPxGridViewDynamicReport_HtmlDataCellPrepared(sender As Object, e As DevExpress.Web.ASPxGridViewTableDataCellEventArgs) Handles ASPxGridViewDynamicReport.HtmlDataCellPrepared
        ' If e.DataColumn.FieldName = "Description" Then
        If e.CellValue IsNot Nothing Then
            e.Cell.ToolTip = e.CellValue.ToString()
        End If
        ' End If
    End Sub

#End Region

#End Region


    Private Sub CheckBoxShowJobsWithNoDetails_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowJobsWithNoDetails.CheckedChanged
        Try
            'LoadGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadComboBoxCriteria_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxCriteria.SelectedIndexChanged
        Try
            LoadGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ASPxGridViewExporter_RenderBrick(sender As Object, e As DevExpress.Web.ASPxGridViewExportRenderingEventArgs) Handles ASPxGridViewExporter.RenderBrick
        Try
            If e.Column.GetType().ToString = "DevExpress.Web.GridViewDataCheckColumn" And e.RowType = DevExpress.Web.GridViewRowType.Data Then
                If e.Value = False Then
                    e.Text = "No"
                Else
                    e.Text = "Yes"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBoxShowInvoices_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowInvoices.CheckedChanged
        Try
            'LoadGrid()
        Catch ex As Exception

        End Try
    End Sub
End Class
