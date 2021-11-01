Imports Webvantage.cGlobals.Globals

Public Class Reporting_RevenueForecast
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _UserDefinedReportID As Integer = 0
    Private _AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Summary
    Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadUserDefinedReportInformation()

        Try

            If Request.QueryString("UserDefinedReportID") IsNot Nothing Then

                _UserDefinedReportID = CType(Request.QueryString("UserDefinedReportID"), Integer)

            End If

        Catch ex As Exception
            _UserDefinedReportID = 0
        End Try

        Try

            If Request.QueryString("AdvancedReportWriterReport") IsNot Nothing Then

                _AdvancedReportWriterReport = CType(Request.QueryString("AdvancedReportWriterReport"), Integer)

            End If

        Catch ex As Exception
            _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.Alerts
        End Try

    End Sub
    Private Sub LoadOffices()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim UserEmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing

            UserEmployeeOfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList

            If UserEmployeeOfficeList IsNot Nothing AndAlso UserEmployeeOfficeList.Count > 0 Then

                RadListBoxOffices.DataSource = From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext).ToList
                                               Where UserEmployeeOfficeList.Any(Function(UsrOfficeAccess) UsrOfficeAccess.OfficeCode = Entity.Code) = True
                                               Select [Code] = Entity.Code,
                                                      [Name] = Entity.ToString()

            Else

                RadListBoxOffices.DataSource = From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext).ToList
                                               Select [Code] = Entity.Code,
                                                      [Name] = Entity.ToString()

            End If

            RadListBoxOffices.DataBind()

        End Using

    End Sub
    Private Sub LoadSalesClasses()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadListBoxSalesClasses.DataSource = From Entity In AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext).ToList
                                                Select [Code] = Entity.Code,
                                                       [Description] = Entity.ToString

            RadListBoxSalesClasses.DataBind()

        End Using

    End Sub
    Private Sub LoadLocations()
        'objects
        Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
        Using DbContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
            RadComboBoxLocation.DataSource = (From Item In AdvantageFramework.Database.Procedures.Location.Load(DbContext)
                                              Select [ID] = Item.ID,
                                                 [Name] = Item.ID & " - " & Item.Name).ToList
            RadComboBoxLocation.DataBind()
            RadComboBoxLocation.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", ""))
        End Using

    End Sub

    Private Sub ExportToExcel()

        'objects
        Dim Worksheet As Aspose.Cells.Worksheet = Nothing
        Dim Workbook As Aspose.Cells.Workbook = Nothing
        Dim XlsSaveOptions As Aspose.Cells.XlsSaveOptions = Nothing
        Dim RevenueForecastList As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.RevenueForecastReport) = Nothing
        Dim RevenueForecastMonthList As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.RevenueForecastMonthReport) = Nothing
        Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim ColorsBeingUsed As Generic.List(Of System.Drawing.Color) = Nothing
        Dim TotalColumns As Integer = Nothing
        Dim TotalPostPeriodColumns As Integer = Nothing
        Dim TotalHeaderRows As Integer = 0
        Dim Cell As Aspose.Cells.Cell = Nothing
        Dim JobForecastJobColor As System.Drawing.Color = Nothing
        Dim HeaderRow1Cell As Aspose.Cells.Cell = Nothing
        Dim HeaderRow2Cell As Aspose.Cells.Cell = Nothing
        Dim HeaderRow3Cell As Aspose.Cells.Cell = Nothing
        Dim License As Aspose.Cells.License = Nothing
        Dim ActiveRow As Integer = 0
        Dim TableStart As Integer = 0
        Dim CreatedByEmployee As String = Nothing
        Dim ModifiedByEmploee As String = Nothing
        Dim ApprovedByEmployee As String = Nothing
        Dim Style As Aspose.Cells.Style = Nothing
        Dim Filename As String = Nothing
        Dim ProjectNumberColumn As Short = 0 ' merged 0 + 1
        Dim ProjectNameColumn As Short = 1
        Dim ProjectComponentColumn As Short = 2
        Dim ProjectComponentNameColumn As Short = 3
        Dim ProjectProcessControlColumn As Short = 4
        Dim TypeColumn As Short = 5
        Dim FixedFeeColumn As Short = 6
        Dim TotalHoursColumn As Short = 7
        Dim PriorRevenueColumn As Short = 8
        Dim FeeRevenueColumn As Short = 9
        Dim PercentCompleteToDateColumn As Short = 10
        'Dim VarianceColumn As Short = 7
        'Dim SummaryTableColumn As Integer = 8
        Dim FirstDataRow As Integer = 0
        Dim SummaryRows As Generic.List(Of Integer) = Nothing
        Dim SelectedOffices As Generic.List(Of String) = Nothing
        Dim SelectedSalesClass As Generic.List(Of String) = Nothing

        Try

            Using DbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.StartingPostPeriodCode.ToString) = RadComboBoxStart.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.EndingPostPeriodCode.ToString) = RadComboBoxEnd.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.CurrentPeriod.ToString) = RadComboBoxCurrent.SelectedValue
                If Me.RadioButtonWeek.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.DisplayOption.ToString) = 1
                ElseIf Me.RadioButtonMonth.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.DisplayOption.ToString) = 2
                ElseIf Me.RadioButtonActualize.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.DisplayOption.ToString) = 3
                End If
                _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.ActualizeDate.ToString) = Me.RadDatePickerActual.SelectedDate

                If RadButtonAllOffices.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.SelectedOffices.ToString) = Nothing

                Else

                    If RadListBoxOffices.SelectedItems.Count = 0 Then
                        Me.ShowMessage("Please select an Office.")
                        Exit Sub
                    Else
                        SelectedOffices = (From RadListBoxItem In RadListBoxOffices.SelectedItems
                                           Select RadListBoxItem.Value).ToList
                        _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.SelectedOffices.ToString) = Join(SelectedOffices.ToArray, ",")
                    End If

                End If

                If RadButtonAllSalesClasses.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.SelectedSalesClass.ToString) = Nothing

                Else

                    If RadListBoxSalesClasses.SelectedItems.Count = 0 Then
                        Me.ShowMessage("Please select an Sales Class.")
                        Exit Sub
                    Else
                        SelectedSalesClass = (From RadListBoxItem In RadListBoxSalesClasses.SelectedItems
                                              Select RadListBoxItem.Value).ToList
                        _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.SelectedSalesClass.ToString) = Join(SelectedSalesClass.ToArray, ",")

                    End If

                End If

                If Me.RadioButtonWeek.Checked Or Me.RadioButtonActualize.Checked Then
                    RevenueForecastList = AdvantageFramework.Reporting.Database.Procedures.RevenueForecastReport.Load(DbContext, _ParameterDictionary).ToList
                ElseIf Me.RadioButtonMonth.Checked Then
                    RevenueForecastMonthList = AdvantageFramework.Reporting.Database.Procedures.RevenueForecastMonthReport.Load(DbContext, _ParameterDictionary).ToList
                End If

                If RevenueForecastList IsNot Nothing Or RevenueForecastMonthList IsNot Nothing Then

                    Filename = "RevenueForecast.xls"

                    License = New Aspose.Cells.License

                    License.SetLicense("Aspose.Total.lic")
                    'License.Embedded = True

                    Workbook = New Aspose.Cells.Workbook(Aspose.Cells.FileFormatType.Excel97To2003)

                    If Workbook.Worksheets.Count = 0 Then

                        Workbook.Worksheets.Add(Aspose.Cells.SheetType.Worksheet)

                    End If

                    Worksheet = Workbook.Worksheets(0)
                    'Worksheet.Cells.StandardWidth = 30

                    XlsSaveOptions = New Aspose.Cells.XlsSaveOptions(Aspose.Cells.SaveFormat.Excel97To2003)

                    'define colors
                    ColorsBeingUsed = New Generic.List(Of Drawing.Color)
                    ColorsBeingUsed.Add(Drawing.Color.DarkGray)
                    ColorsBeingUsed.Add(Drawing.Color.LightGray)
                    ColorsBeingUsed.Add(Drawing.Color.Silver)

                    FirstDataRow = 0

                    '
                    ' Begin Location Header
                    '

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                        Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, Me.RadComboBoxLocation.SelectedValue)
                    End Using

                    If Location IsNot Nothing Then

                        If Location.LogoLocation <> "N" Then

                            Dim Picture As Aspose.Cells.Drawing.Picture = Nothing

                            Try

                                Picture = Worksheet.Pictures(Worksheet.Pictures.Add(0, 0, Location.LogoLandscapePath))

                                Worksheet.Cells.Merge(0, 0, 1, 10)
                                Worksheet.Cells.Rows(0).Height = Picture.HeightPt
                                FirstDataRow += 1

                                Worksheet.Cells.Rows(FirstDataRow).Height = 5
                                FirstDataRow += 1

                            Catch ex As Exception

                            End Try

                        End If

                        If Location.PrintHeader.GetValueOrDefault(0) = 1 Then

                            Dim LocationString As Generic.List(Of String) = New Generic.List(Of String)

                            If Location.PrintNameHeader.GetValueOrDefault(0) = 1 Then

                                If Not String.IsNullOrWhiteSpace(Location.Name) Then

                                    LocationString.Add(Location.Name)

                                End If

                            End If

                            If Location.PrintAddressHeader.GetValueOrDefault(0) = 1 Then

                                If Not String.IsNullOrWhiteSpace(Location.Address) Then

                                    LocationString.Add(Location.Address)

                                End If

                            End If

                            If Location.PrintAddress2Header.GetValueOrDefault(0) = 1 Then

                                If Not String.IsNullOrWhiteSpace(Location.Address2) Then

                                    LocationString.Add(Location.Address2)

                                End If

                            End If

                            Dim CityStateZipString As String = ""

                            If Location.PrintCityHeader.GetValueOrDefault(0) = 1 Then

                                If Not String.IsNullOrWhiteSpace(Location.City) Then

                                    CityStateZipString = Location.City

                                End If

                            End If

                            If Location.PrintStateHeader.GetValueOrDefault(0) = 1 Then

                                If Not String.IsNullOrWhiteSpace(Location.State) Then

                                    If Not String.IsNullOrWhiteSpace(CityStateZipString) Then

                                        CityStateZipString &= ", "

                                    End If

                                    CityStateZipString &= Location.State

                                End If

                            End If

                            If Location.PrintZipHeader.GetValueOrDefault(0) = 1 Then

                                If Not String.IsNullOrWhiteSpace(Location.Zip) Then

                                    If Not String.IsNullOrWhiteSpace(CityStateZipString) Then

                                        CityStateZipString &= " "

                                    End If

                                    CityStateZipString &= Location.Zip

                                End If

                            End If

                            If Not String.IsNullOrEmpty(CityStateZipString) Then

                                LocationString.Add(CityStateZipString)

                            End If

                            If Location.PrintPhoneHeader.GetValueOrDefault(0) = 1 Then

                                If Not String.IsNullOrWhiteSpace(Location.Phone) Then

                                    LocationString.Add(Location.Phone)

                                End If

                            End If

                            If Location.PrintFaxHeader.GetValueOrDefault(0) = 1 Then

                                If Not String.IsNullOrWhiteSpace(Location.Fax) Then

                                    LocationString.Add(Location.Fax)

                                End If

                            End If

                            If Location.PrintEmailHeader.GetValueOrDefault(0) = 1 Then

                                If Not String.IsNullOrWhiteSpace(Location.Email) Then

                                    LocationString.Add(Location.Email)

                                End If

                            End If

                            If LocationString IsNot Nothing AndAlso LocationString.Count > 0 Then

                                Worksheet.Cells(FirstDataRow, 0).HtmlString = String.Join(" &bull; ", LocationString)
                                Worksheet.Cells.Merge(FirstDataRow, 0, 1, 10) '16384

                            End If

                            FirstDataRow += 1

                            Worksheet.Cells.Rows(FirstDataRow).Height = 25
                            FirstDataRow += 1

                        End If

                    End If

                    '
                    ' Begin Forecast Header Data
                    '
                    ActiveRow = FirstDataRow ' start at top

                    If Me.RadioButtonWeek.Checked Or Me.RadioButtonActualize.Checked Then
                        SetupExcelLabelCell(Worksheet.Cells(ActiveRow, 0), "Weekly Revenue Forecast")
                    ElseIf Me.RadioButtonMonth.Checked Then
                        SetupExcelLabelCell(Worksheet.Cells(ActiveRow, 0), "Monthly Revenue Forecast")
                    End If

                    'Worksheet.Cells(ActiveRow, 1).Value = JobForecastRevision.JobForecast.Description
                    'Worksheet.Cells.Merge(ActiveRow, 1, 1, 5) ' aligns with "Variance" Column

                    'ActiveRow = Worksheet.Cells.MaxRow + 1
                    'Worksheet.Cells.Rows(ActiveRow).Height = 5 ' spacer row

                    'ActiveRow += 1
                    'Worksheet.Cells.Rows(ActiveRow + 1).Height = 5 ' spacer row
                    'Worksheet.Cells.Rows(ActiveRow + 3).Height = 5 ' spacer row
                    'SetupExcelLabelCell(Worksheet.Cells(ActiveRow, 0), "Comment:")
                    'Worksheet.Cells(ActiveRow, 1).Value = JobForecastRevision.Comment
                    'Worksheet.Cells.Merge(ActiveRow, 1, 5, 5) ' aligns with "Variance" Column
                    'Style = Worksheet.Cells(ActiveRow, 1).GetStyle()
                    'Style.VerticalAlignment = Aspose.Cells.TextAlignmentType.Top
                    'Worksheet.Cells(ActiveRow, 1).SetStyle(Style)

                    'ActiveRow = Worksheet.Cells.MaxRow + Worksheet.Cells(Worksheet.Cells.MaxRow, 1).GetMergedRange.RowCount
                    'Worksheet.Cells.Rows(ActiveRow).Height = 5 ' spacer row

                    'ActiveRow += 1
                    'SetupExcelLabelCell(Worksheet.Cells(ActiveRow, 0), "Start/End:")
                    'Worksheet.Cells(ActiveRow, 1).Value = String.Format("{0:MMMM yyyy} - {1:MMMM yyyy}", PostPeriods.OrderBy(Function(item) item.StartDate).First.StartDate.GetValueOrDefault, PostPeriods.OrderByDescending(Function(item) item.StartDate).First.StartDate.GetValueOrDefault)
                    'SetupExcelLabelCell(Worksheet.Cells(ActiveRow, 3), "Created By:")
                    'Worksheet.Cells(ActiveRow, 4).Value = CreatedByEmployee

                    'Worksheet.Cells.Merge(ActiveRow, 4, 1, 4)

                    'ActiveRow = Worksheet.Cells.MaxRow + 1
                    'Worksheet.Cells.Rows(ActiveRow).Height = 5 ' spacer row

                    'ActiveRow += 1
                    'SetupExcelLabelCell(Worksheet.Cells(ActiveRow, 0), "Assigned To:")
                    'Worksheet.Cells(ActiveRow, 1).Value = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(Me.DbContext, JobForecastRevision.JobForecast.AssignedToEmployeeCode).ToString()
                    'SetupExcelLabelCell(Worksheet.Cells(ActiveRow, 3), "Modified By:")
                    'Worksheet.Cells(ActiveRow, 4).Value = ModifiedByEmploee
                    'Worksheet.Cells.Merge(ActiveRow, 4, 1, 4)

                    'ActiveRow = Worksheet.Cells.MaxRow + 1
                    'Worksheet.Cells.Rows(ActiveRow).Height = 5 ' spacer row

                    'ActiveRow += 1
                    'SetupExcelLabelCell(Worksheet.Cells(ActiveRow, 0), "Office:")
                    'Worksheet.Cells(ActiveRow, 1).Value = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(Me.DbContext, JobForecastRevision.JobForecast.OfficeCode).ToString
                    'SetupExcelLabelCell(Worksheet.Cells(ActiveRow, 3), "Approved By:")
                    'Worksheet.Cells(ActiveRow, 4).Value = ApprovedByEmployee
                    'Worksheet.Cells.Merge(ActiveRow, 4, 1, 4)

                    '
                    ' Begin Data Table
                    '

                    'If Not Me.ShowSalesClass Then

                    '    SalesClassColumn = 0
                    '    CommentsColumn -= 1
                    '    EstimateColumn -= 1
                    '    ForecastColumn -= 1
                    '    ActualColumn -= 1
                    '    VarianceColumn -= 1

                    'End If

                    'If Not Me.ShowEstimateAmount Then

                    '    EstimateColumn = 0
                    '    ForecastColumn -= 1
                    '    ActualColumn -= 1
                    '    VarianceColumn -= 1

                    'End If

                    'If ForecastType = AdvantageFramework.JobForecast.JobForecastTypes.BillingAndRevenue Then

                    '    TotalPostPeriodColumns = PostPeriods.Count() * 2
                    '    TotalHeaderRows = 3

                    'Else

                    '    TotalPostPeriodColumns = PostPeriods.Count()
                    '    TotalHeaderRows = 2

                    'End If

                    'TotalColumns = VarianceColumn + TotalPostPeriodColumns + 1

                    ' header row
                    ActiveRow = Worksheet.Cells.MaxRow + 2
                    TableStart = ActiveRow
                    SetupExcelHeaderRowCell(Worksheet.Cells(ActiveRow, ProjectNumberColumn), "Project Number")
                    SetupExcelHeaderRowCell(Worksheet.Cells(ActiveRow, ProjectNameColumn), "Project Name")
                    SetupExcelHeaderRowCell(Worksheet.Cells(ActiveRow, ProjectComponentColumn), "Project Component Number")
                    SetupExcelHeaderRowCell(Worksheet.Cells(ActiveRow, ProjectComponentNameColumn), "Project Component Name")
                    SetupExcelHeaderRowCell(Worksheet.Cells(ActiveRow, ProjectProcessControlColumn), "Project Process Control")

                    SetupExcelHeaderRowCell(Worksheet.Cells(ActiveRow, TypeColumn), "Type")
                    SetupExcelHeaderRowCell(Worksheet.Cells(ActiveRow, FixedFeeColumn), "Fixed Fee")
                    SetupExcelHeaderRowCell(Worksheet.Cells(ActiveRow, TotalHoursColumn), "Total Hours")
                    SetupExcelHeaderRowCell(Worksheet.Cells(ActiveRow, PriorRevenueColumn), "Prior Revenue")
                    SetupExcelHeaderRowCell(Worksheet.Cells(ActiveRow, FeeRevenueColumn), "Fee Revenue")
                    SetupExcelHeaderRowCell(Worksheet.Cells(ActiveRow, PercentCompleteToDateColumn), "Percent Complete to Date")

                    TotalColumns += 11

                    'For ColumnIndex = 0 To VarianceColumn

                    '    If ColumnIndex = JobComponentColumn Then

                    '        Worksheet.Cells.Merge(ActiveRow, ColumnIndex, TotalHeaderRows, 2)

                    '    ElseIf ColumnIndex > (JobComponentColumn + 1) Then

                    '        Worksheet.Cells.Merge(ActiveRow, ColumnIndex, TotalHeaderRows, 1)

                    '    End If

                    'Next

                    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                    Dim dt As DataTable

                    If Me.RadioButtonWeek.Checked Or Me.RadioButtonActualize.Checked Then
                        dt = s.GetProjectSummaryDates(Me.RadComboBoxStart.SelectedValue, Me.RadComboBoxEnd.SelectedValue, "", 1)
                    ElseIf Me.RadioButtonMonth.Checked Then
                        dt = s.GetProjectSummaryDates(Me.RadComboBoxStart.SelectedValue, Me.RadComboBoxEnd.SelectedValue, "", 2)
                    End If

                    For i As Integer = 0 To dt.Rows.Count - 1

                        HeaderRow1Cell = GetNextCell(Worksheet.Cells.Rows(ActiveRow).LastDataCell)
                        HeaderRow2Cell = GetNextCell(Worksheet.Cells(HeaderRow1Cell.Row - 1, HeaderRow1Cell.Column - 1))

                        If Me.RadioButtonWeek.Checked Or Me.RadioButtonActualize.Checked Then
                            SetupExcelHeaderRowCell(HeaderRow1Cell, CDate(dt.Rows(i)("WEEK_START")).ToShortDateString)
                            If Me.RadioButtonActualize.Checked AndAlso Me.RadDatePickerActual.SelectedDate.HasValue Then
                                If DatePart(DateInterval.WeekOfYear, CDate(dt.Rows(i)("WEEK_START")), Microsoft.VisualBasic.FirstDayOfWeek.Sunday) <= DatePart(DateInterval.WeekOfYear, Me.RadDatePickerActual.SelectedDate.Value, Microsoft.VisualBasic.FirstDayOfWeek.Sunday) Then
                                    SetupExcelJobComponentRowCell(HeaderRow2Cell, "Actual", "", False, Drawing.Color.LightGreen)
                                Else
                                    SetupExcelJobComponentRowCell(HeaderRow2Cell, "Forecast", "", False, Drawing.Color.LightBlue)
                                End If
                            End If
                        ElseIf Me.RadioButtonMonth.Checked Then
                            SetupExcelHeaderRowCell(HeaderRow1Cell, dt.Rows(i)("MONTH_OPENED"))
                            'Worksheet.Cells.SetColumnWidth(HeaderRow1Cell.Column, 10)
                        End If
                        TotalColumns += 1
                        Worksheet.Cells.Merge(HeaderRow1Cell.Row, HeaderRow1Cell.Column, 1, 1)

                    Next

                    HeaderRow1Cell = GetNextCell(Worksheet.Cells.Rows(ActiveRow).LastDataCell)
                    SetupExcelHeaderRowCell(HeaderRow1Cell, "Total Revenue")
                    'TotalColumns += 1
                    'End of Header Rows

                    Dim currentJobComp As String = ""
                    Dim weekExists As Boolean = False
                    Dim count As Integer = 0
                    Dim total As Decimal = 0
                    Dim prior As Decimal = 0
                    Dim current As Decimal = 0
                    Dim estimate As Decimal = 0
                    Dim revenuetotal As Decimal = 0

                    SummaryRows = New Generic.List(Of Integer)

                    If Me.RadioButtonWeek.Checked Or Me.RadioButtonActualize.Checked Then
                        For Each RevenueForecast In RevenueForecastList

                            If currentJobComp <> RevenueForecast.JobComponent Or currentJobComp = "" Then

                                count += 1

                                If count > 1 Then

                                    SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, TotalHoursColumn), total, Nothing, True, JobForecastJobColor)
                                    SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, PriorRevenueColumn), prior, Nothing, True, JobForecastJobColor)
                                    SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, FeeRevenueColumn), estimate - prior, Nothing, True, JobForecastJobColor)
                                    SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, TotalColumns), revenuetotal, Nothing, True, JobForecastJobColor)
                                    SummaryRows.Add(ActiveRow)
                                End If

                                total = 0
                                prior = 0
                                estimate = 0
                                revenuetotal = 0

                                ActiveRow = Worksheet.Cells.MaxRow + 1

                                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, ProjectNumberColumn), RevenueForecast.JobNumber, Nothing, False, JobForecastJobColor)
                                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, ProjectNameColumn), RevenueForecast.JobDescription, Nothing, False, JobForecastJobColor)
                                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, ProjectComponentColumn), RevenueForecast.ComponentNumber, Nothing, False, JobForecastJobColor)
                                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, ProjectComponentNameColumn), RevenueForecast.ComponentDescription, Nothing, False, JobForecastJobColor)
                                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, ProjectProcessControlColumn), RevenueForecast.JobProcessControl, Nothing, False, JobForecastJobColor)
                                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, TypeColumn), RevenueForecast.Type, Nothing, False, JobForecastJobColor)
                                'If RevenueForecast.Week = 0 Then
                                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, FixedFeeColumn), RevenueForecast.EstimatedGrossIncome, Nothing, True, JobForecastJobColor)
                                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, PercentCompleteToDateColumn), RevenueForecast.PercentCompleteToDate, Nothing, False, JobForecastJobColor)
                                'Else
                                '    SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, FixedFeeColumn), 0.00, Nothing, True, JobForecastJobColor)
                                'End If
                                estimate = RevenueForecast.EstimatedGrossIncome
                            End If

                            currentJobComp = RevenueForecast.JobComponent
                            total += RevenueForecast.TotalHours
                            prior += RevenueForecast.PriorRevenue

                            For i As Integer = 0 To dt.Rows.Count - 1

                                If CInt(dt.Rows(i)("WEEK")) = RevenueForecast.Week Then
                                    If Me.RadioButtonActualize.Checked AndAlso Me.RadDatePickerActual.SelectedDate.HasValue Then
                                        If RevenueForecast.Week <= DatePart(DateInterval.WeekOfYear, Me.RadDatePickerActual.SelectedDate.Value, Microsoft.VisualBasic.FirstDayOfWeek.Sunday) Then
                                            SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, FeeRevenueColumn + i + 1), RevenueForecast.ActualAmount, Nothing, True, JobForecastJobColor)
                                            revenuetotal += RevenueForecast.ActualAmount
                                            weekExists = True
                                        Else
                                            SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, FeeRevenueColumn + i + 1), RevenueForecast.ProjectedAmount, Nothing, True, JobForecastJobColor)
                                            revenuetotal += RevenueForecast.ProjectedAmount
                                            weekExists = True
                                        End If
                                    Else
                                        SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, FeeRevenueColumn + i + 1), RevenueForecast.ProjectedAmount, Nothing, True, JobForecastJobColor)
                                        revenuetotal += RevenueForecast.ProjectedAmount
                                        weekExists = True
                                    End If
                                End If
                            Next

                        Next

                        SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, TotalHoursColumn), total, Nothing, True, JobForecastJobColor)
                        SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, PriorRevenueColumn), prior, Nothing, True, JobForecastJobColor)
                        SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, FeeRevenueColumn), estimate - prior, Nothing, True, JobForecastJobColor)
                        SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, TotalColumns), revenuetotal, Nothing, True, JobForecastJobColor)

                    ElseIf Me.RadioButtonMonth.Checked Then
                        For Each RevenueForecastMonth In RevenueForecastMonthList

                            If currentJobComp <> RevenueForecastMonth.JobComponent Or currentJobComp = "" Then

                                count += 1

                                If count > 1 Then

                                    SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, TotalHoursColumn), total, Nothing, True, JobForecastJobColor)
                                    SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, PriorRevenueColumn), prior, Nothing, True, JobForecastJobColor)
                                    SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, FeeRevenueColumn), estimate - prior, Nothing, True, JobForecastJobColor)
                                    SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, TotalColumns), revenuetotal, Nothing, True, JobForecastJobColor)
                                    SummaryRows.Add(ActiveRow)
                                End If

                                total = 0
                                prior = 0
                                estimate = 0
                                revenuetotal = 0

                                ActiveRow = Worksheet.Cells.MaxRow + 1

                                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, ProjectNumberColumn), RevenueForecastMonth.JobNumber, Nothing, False, JobForecastJobColor)
                                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, ProjectNameColumn), RevenueForecastMonth.JobDescription, Nothing, False, JobForecastJobColor)
                                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, ProjectComponentColumn), RevenueForecastMonth.ComponentNumber, Nothing, False, JobForecastJobColor)
                                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, ProjectComponentNameColumn), RevenueForecastMonth.ComponentDescription, Nothing, False, JobForecastJobColor)
                                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, ProjectProcessControlColumn), RevenueForecastMonth.JobProcessControl, Nothing, False, JobForecastJobColor)
                                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, TypeColumn), RevenueForecastMonth.Type, Nothing, False, JobForecastJobColor)
                                'If RevenueForecastMonth.Month = 0 Then
                                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, FixedFeeColumn), RevenueForecastMonth.EstimatedGrossIncome, Nothing, True, JobForecastJobColor)
                                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, PercentCompleteToDateColumn), RevenueForecastMonth.PercentCompleteToDate, Nothing, False, JobForecastJobColor)
                                'Else
                                '    SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, FixedFeeColumn), 0.00, Nothing, True, JobForecastJobColor)
                                'End If
                                estimate = RevenueForecastMonth.EstimatedGrossIncome
                            End If

                            currentJobComp = RevenueForecastMonth.JobComponent
                            total += RevenueForecastMonth.TotalHours
                            prior += RevenueForecastMonth.PriorRevenue

                            For i As Integer = 0 To dt.Rows.Count - 1

                                If CInt(dt.Rows(i)("MTH")) = RevenueForecastMonth.Month Then
                                    SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, FeeRevenueColumn + i + 1), RevenueForecastMonth.ProjectedAmount, Nothing, True, JobForecastJobColor)
                                    revenuetotal += RevenueForecastMonth.ProjectedAmount
                                    weekExists = True
                                End If

                            Next

                        Next

                        SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, TotalHoursColumn), total, Nothing, True, JobForecastJobColor)
                        SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, PriorRevenueColumn), prior, Nothing, True, JobForecastJobColor)
                        SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, FeeRevenueColumn), estimate - prior, Nothing, True, JobForecastJobColor)
                        SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, TotalColumns), revenuetotal, Nothing, True, JobForecastJobColor)
                    End If


                    TotalColumns += 1

                    SummaryRows.Add(ActiveRow)

                    ActiveRow = Worksheet.Cells.MaxRow + 2
                    SetupExcelLabelCell(Worksheet.Cells(ActiveRow, ProjectNumberColumn), "Total:")

                    ''summary row
                    For ColumnIndex = 7 To (TotalColumns - 1)

                        Cell = Worksheet.Cells(ActiveRow, ColumnIndex)

                        Dim Formula As String = "=" & String.Join(" + ", (From Item In SummaryRows
                                                                          Select Worksheet.Cells(Item, ColumnIndex).Name))

                        SetupExcelNumericRowCell(Cell, Nothing, Formula, Nothing)

                        'If Cell.Column = ForecastColumn Then

                        '    SetupExcelLabelCell(Worksheet.Cells(FirstDataRow + 2, SummaryTableColumn), "Forecast")
                        '    SetupExcelNumericRowCell(Worksheet.Cells(FirstDataRow + 2, SummaryTableColumn + 1), Nothing, Cell.Formula, Nothing)

                        'End If

                    Next

                    'If Me.RadioButtonWeek.Checked Or Me.RadioButtonActualize.Checked Then
                    Worksheet.AutoFitColumns()
                    'ElseIf Me.RadioButtonMonth.Checked Then

                    'End If


                End If

            End Using

        Catch ex As Exception

        Finally

        End Try

        Try

            MemoryStream = New IO.MemoryStream

            Workbook.Save(MemoryStream, XlsSaveOptions)

            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & Filename)
            HttpContext.Current.Response.BinaryWrite(MemoryStream.ToArray())
            HttpContext.Current.ApplicationInstance.CompleteRequest()
            'HttpContext.Current.Response.Flush()
            'HttpContext.Current.Response.End()
            Try

                HttpContext.Current.Response.End()

            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try

        If License IsNot Nothing Then

            License = Nothing

        End If

    End Sub

    Private Sub SetupExcelLabelCell(ByVal Cell As Aspose.Cells.Cell, ByVal Text As String)

        Dim Style As Aspose.Cells.Style = Nothing

        Cell.PutValue(Text)

        Style = Cell.GetStyle

        With Style

            .Font.IsBold = True
            .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Right

        End With

        Cell.SetStyle(Style)

    End Sub
    Private Sub SetupExcelHeaderRowCell(ByVal Cell As Aspose.Cells.Cell, ByVal Text As String)

        Dim Style As Aspose.Cells.Style = Nothing

        Cell.PutValue(Text)

        Style = Cell.GetStyle

        With Style

            .Font.IsBold = True
            .Pattern = Aspose.Cells.BackgroundType.Solid
            .ForegroundColor = Drawing.Color.Silver

        End With

        Cell.SetStyle(Style)

    End Sub
    Private Sub SetupExcelNumericRowCell(ByVal Cell As Aspose.Cells.Cell, ByVal Value As Decimal?, ByVal Formula As String, ByVal BackgroundColor As System.Drawing.Color)

        Dim Style As Aspose.Cells.Style = Nothing

        With Cell

            .PutValue(Value)

            If Not String.IsNullOrWhiteSpace(Formula) Then

                .Formula = Formula

            End If

            Style = .GetStyle

            If BackgroundColor <> Nothing Then

                Style.ForegroundColor = BackgroundColor

            End If

            Style.Number = 4 ' 4 = decimal #,###.##

            .SetStyle(Style)

        End With

    End Sub
    Private Sub SetBorder(ByVal Range As Aspose.Cells.Range)

        With Range

            .SetOutlineBorder(Aspose.Cells.BorderType.BottomBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.DarkGray)
            .SetOutlineBorder(Aspose.Cells.BorderType.RightBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.DarkGray)
            .SetOutlineBorder(Aspose.Cells.BorderType.LeftBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.DarkGray)
            .SetOutlineBorder(Aspose.Cells.BorderType.TopBorder, Aspose.Cells.CellBorderType.Thin, Drawing.Color.DarkGray)
            .SetOutlineBorder(Aspose.Cells.BorderType.Vertical, Aspose.Cells.CellBorderType.Thin, Drawing.Color.DarkGray)
            .SetOutlineBorder(Aspose.Cells.BorderType.Horizontal, Aspose.Cells.CellBorderType.Thin, Drawing.Color.DarkGray)

        End With

    End Sub
    Private Function GetNextCell(ByVal Cell As Aspose.Cells.Cell) As Aspose.Cells.Cell

        'objects
        Dim NextCell As Aspose.Cells.Cell = Nothing

        While NextCell Is Nothing

            Cell = Cell.Worksheet.Cells(Cell.Row, Cell.Column + 1)

            If Cell.IsMerged = False AndAlso Cell.Value Is Nothing Then

                NextCell = Cell

            End If

        End While

        Return NextCell

    End Function

    Private Sub SetupExcelJobComponentRowCell(ByVal Cell As Aspose.Cells.Cell, ByVal Value As Object, ByVal Formula As String, ByVal IsNumericCell As Boolean, ByVal BackgroundColor As System.Drawing.Color)

        'objects
        Dim Style As Aspose.Cells.Style = Nothing

        With Cell

            .PutValue(Value)

            If Not String.IsNullOrWhiteSpace(Formula) Then

                .Formula = Formula

            End If

            Style = .GetStyle

            If BackgroundColor <> Nothing Then

                Style.Pattern = Aspose.Cells.BackgroundType.Solid
                Style.ForegroundColor = BackgroundColor

            End If

            If IsNumericCell Then

                Style.Number = 4 ' 4 = decimal #,###.##

            End If

            .SetStyle(Style)

        End With

    End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_JobDetailAnalysis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadUserDefinedReportInformation()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.RadioButtonWeek.Checked = True

            'Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Reports_JobDetailAnalysisRTP)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadComboBoxStart.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                RadComboBoxStart.DataBind()

                RadComboBoxEnd.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                RadComboBoxEnd.DataBind()

                RadComboBoxCurrent.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                RadComboBoxCurrent.DataBind()

                Try
                    RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                Catch ex As Exception

                End Try

                Try
                    RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                Catch ex As Exception

                End Try

                Try
                    RadComboBoxCurrent.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                Catch ex As Exception

                End Try

            End Using

            LoadOffices()

            LoadSalesClasses()

            LoadLocations()

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarJobDetailAnalysis_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarJobDetailAnalysis.ButtonClick

        'objects
        Dim Report As AdvantageFramework.Reporting.ReportTypes = Nothing
        Dim CDPString As String

        Dim clients As New System.Collections.Generic.List(Of String)
        Dim divisions As New System.Collections.Generic.List(Of String)
        Dim products As New System.Collections.Generic.List(Of String)

        Select Case e.Item.Value

            Case "View"
                Dim ppStart As AdvantageFramework.Database.Entities.PostPeriod = Nothing
                Dim ppEnd As AdvantageFramework.Database.Entities.PostPeriod = Nothing
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    ppStart = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, Me.RadComboBoxStart.SelectedValue.Substring(0, 6))
                    ppEnd = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, Me.RadComboBoxEnd.SelectedValue.Substring(0, 6))
                End Using

                If CDate(ppEnd.StartDate).Subtract(CDate(ppStart.StartDate)).Days > 365 Then
                    Me.ShowMessage("Post Period range must be less than or equal to 52 weeks.")
                    Exit Sub
                End If

                If Me.RadioButtonActualize.Checked AndAlso Me.RadDatePickerActual.SelectedDate.HasValue = False Then
                    Me.ShowMessage("Please select an actualize date.")
                    Exit Sub
                End If

                Me.ExportToExcel()

        End Select

    End Sub
    'Private Sub RadButtonOpenClosedJobs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonOpenClosedJobs.CheckedChanged

    '    LoadJobs()

    'End Sub
    'Private Sub RadButtonOpenJobs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonOpenJobs.CheckedChanged

    '    LoadJobs()

    'End Sub
    Private Sub RadButtonAllOffices_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonAllOffices.CheckedChanged

        RadListBoxOffices.Enabled = Not RadButtonAllOffices.Checked

    End Sub
    Private Sub RadButtonChooseOffices_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonChooseOffices.CheckedChanged

        RadListBoxOffices.Enabled = RadButtonChooseOffices.Checked

        If RadButtonChooseOffices.Checked Then

            RadListBoxOffices.Items(0).Selected = True

        End If

    End Sub
    Private Sub RadButtonAllSalesClasses_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonAllSalesClasses.CheckedChanged

        RadListBoxSalesClasses.Enabled = Not RadButtonAllSalesClasses.Checked

    End Sub
    Private Sub RadButtonChooseSalesClasses_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonChooseSalesClasses.CheckedChanged

        RadListBoxSalesClasses.Enabled = RadButtonChooseSalesClasses.Checked

        If RadButtonChooseSalesClasses.Checked Then

            RadListBoxSalesClasses.Items(0).Selected = True

        End If

    End Sub

    Private Sub RadButton1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton1Year.Click
        Try
            Dim current As String
            Dim m As Integer
            Dim y As Integer
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                current = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                If current <> "" Then
                    m = CInt(current.Substring(4, 2))
                    y = CInt(current.Substring(0, 4)) - 1
                End If
                Me.RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, m, y.ToString).ToString
                Me.RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadButtonMTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonMTD.Click
        Try
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                Me.RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                Me.RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
            End Using

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadButtonYTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonYTD.Click
        Try
            Dim current As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim m As Integer
            Dim y As Integer
            Dim pp As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                current = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)
                pp = AdvantageFramework.Database.Procedures.PostPeriod.LoadFirstPeriodByYear(DbContext, current.Year)
                Me.RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, pp.Month.GetValueOrDefault(1), pp.Year.ToString).ToString
                Me.RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
            End Using

        Catch ex As Exception

        End Try
    End Sub


#End Region

#End Region
End Class

