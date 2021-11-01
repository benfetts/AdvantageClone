Imports Telerik.Web.UI

Public Class JobForecast_Print
    Inherits Webvantage.BasePrintSendPage

#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
    Private _DataContext As AdvantageFramework.Database.DataContext = Nothing
    Private _JobForecastRevisionID As Integer = Nothing
    Private _JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing
    Private _JobForecastSettings As Webvantage.cAppVars = Nothing

#End Region

#Region " Properties "

    Private ReadOnly Property DbContext As AdvantageFramework.Database.DbContext
        Get
            If _DbContext Is Nothing Then
                _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            End If
            Return _DbContext
        End Get
    End Property
    Private ReadOnly Property DataContext As AdvantageFramework.Database.DataContext
        Get
            If _DataContext Is Nothing Then
                _DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
            End If
            Return _DataContext
        End Get
    End Property
    Protected ReadOnly Property JobForecast As AdvantageFramework.Database.Entities.JobForecast
        Get
            If _JobForecastRevision Is Nothing Then
                _JobForecastRevision = Me.JobForecastRevision
            End If
            Return _JobForecastRevision.JobForecast
        End Get
    End Property
    Private ReadOnly Property JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision
        Get
            If _JobForecastRevision Is Nothing Then
                _JobForecastRevision = AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(Me.DbContext, _JobForecastRevisionID)
            End If
            Return _JobForecastRevision
        End Get
    End Property
    Protected ReadOnly Property JobForecastSettings As Webvantage.cAppVars
        Get
            If _JobForecastSettings Is Nothing Then
                _JobForecastSettings = New cAppVars(cAppVars.Application.JOB_FORECAST, _Session.UserCode, _Session.User.EmployeeCode)
                _JobForecastSettings.getAllAppVars()
            End If
            Return _JobForecastSettings
        End Get
    End Property
    Protected ReadOnly Property ShowEstimateAmount As Boolean
        Get
            Try
                Return CBool(Me.JobForecastSettings.getAppVar("ShowApprovedEstimateAmount", "Boolean", "False"))
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property
    Protected ReadOnly Property ShowSalesClass As Boolean
        Get
            Try
                Return CBool(Me.JobForecastSettings.getAppVar("ShowSalesClass", "Boolean", "False"))
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property
    Protected Property LocationToOverride As AdvantageFramework.Database.Entities.Location
        Get
            LocationToOverride = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.Database.Entities.Location)(Session("JF_LocationOverride"))
        End Get
        Set(value As AdvantageFramework.Database.Entities.Location)
            Session("JF_LocationOverride") = Newtonsoft.Json.JsonConvert.SerializeObject(value)
        End Set
    End Property
    Protected ReadOnly Property CanUserPrint As Boolean
        Get
            If ViewState("JF_CanUserPrint") Is Nothing Then
                ViewState("JF_CanUserPrint") = AdvantageFramework.Security.CanUserPrintInModule(_Session, AdvantageFramework.Security.Methods.Modules.FinanceAccounting_JobForecast)
            End If
            Return ViewState("JF_CanUserPrint")
        End Get
    End Property
    Protected Property GridGroupByOption As String
        Get
            Try
                Return Me.JobForecastSettings.getAppVar("GridGroupByOption", "String", "C").ToString
            Catch ex As Exception
                Return "C"
            End Try
        End Get
        Set(value As String)
            Me.JobForecastSettings.setAppVarDB("GridGroupByOption", value, "String")
        End Set
    End Property

#End Region

#Region " Methods "

    Private Sub SaveSettings()

        'objects
        Dim AppVars As Webvantage.cAppVars = Nothing

        If Me.JobForecastSettings IsNot Nothing Then

            Me.JobForecastSettings.setAppVar("LocationID", RadComboBoxLocation.SelectedValue, "String")

            Me.JobForecastSettings.SaveAllAppVars()

        End If

    End Sub
    Private Sub LoadLocationInformation()

        'objects
        Dim Location As AdvantageFramework.Database.Entities.Location = Nothing

        If Not String.IsNullOrWhiteSpace(RadComboBoxLocation.SelectedValue) Then

            RadButtonOverrideLocation.Visible = True
            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(Me.DataContext, RadComboBoxLocation.SelectedValue)

        Else

            RadButtonOverrideLocation.Visible = False

        End If

        Me.LocationToOverride = Location

    End Sub
    Private Sub ExportToExcel()

        'objects
        Dim Worksheet As Aspose.Cells.Worksheet = Nothing
        Dim Workbook As Aspose.Cells.Workbook = Nothing
        Dim XlsSaveOptions As Aspose.Cells.XlsSaveOptions = Nothing
        Dim JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing
        Dim JobForecastJobDetails As Generic.List(Of AdvantageFramework.Database.Entities.JobForecastJobDetail) = Nothing
        Dim JobForecastJobDetail As AdvantageFramework.Database.Entities.JobForecastJobDetail = Nothing
        Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
        Dim JobForecastJobSummaryList As Generic.List(Of AdvantageFramework.JobForecast.Classes.JobForecastJobSummary) = Nothing
        Dim JobForecastJobSummary As AdvantageFramework.JobForecast.Classes.JobForecastJobSummary = Nothing
        Dim ForecastType As AdvantageFramework.JobForecast.JobForecastTypes = AdvantageFramework.JobForecast.JobForecastTypes.Billing
        Dim JobForecastActuals As Generic.List(Of AdvantageFramework.JobForecast.Classes.JobForecastActual) = Nothing
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
        Dim JobComponentColumn As Short = 0 ' merged 0 + 1
        Dim SalesClassColumn As Short = 2
        Dim CommentsColumn As Short = 3
        Dim EstimateColumn As Short = 4
        Dim ForecastColumn As Short = 5
        Dim ActualColumn As Short = 6
        Dim VarianceColumn As Short = 7
        Dim SummaryTableColumn As Integer = 8
        Dim FirstDataRow As Integer = 0
        Dim SummaryRows As Generic.List(Of Integer) = Nothing

        Try

            If Me.DbContext IsNot Nothing Then

                JobForecastRevision = Me.JobForecastRevision

                If JobForecastRevision IsNot Nothing Then

                    Filename = String.Format("{0} ({1}).xls", JobForecastRevision.JobForecast.Description, AdvantageFramework.StringUtilities.PadWithCharacter(JobForecastRevision.RevisionNumber, 3, "0"))

                    License = New Aspose.Cells.License

                    License.SetLicense("Aspose.Total.lic")
                    'License.Embedded = True

                    Workbook = New Aspose.Cells.Workbook(Aspose.Cells.FileFormatType.Excel97To2003)

                    If Workbook.Worksheets.Count = 0 Then

                        Workbook.Worksheets.Add(Aspose.Cells.SheetType.Worksheet)

                    End If

                    Worksheet = Workbook.Worksheets(0)

                    XlsSaveOptions = New Aspose.Cells.XlsSaveOptions(Aspose.Cells.SaveFormat.Excel97To2003)

                    ForecastType = JobForecastRevision.JobForecast.ForecastType.GetValueOrDefault(0)

                    PostPeriods = AdvantageFramework.JobForecast.LoadPostPeriodsByJobForecast(Me.DbContext, JobForecastRevision.JobForecast)
                    JobForecastJobDetails = AdvantageFramework.Database.Procedures.JobForecastJobDetail.LoadByJobForecastRevisionID(Me.DbContext, JobForecastRevision.ID).ToList
                    JobForecastJobSummaryList = AdvantageFramework.JobForecast.LoadJobForecastJobsSummary(Me.DbContext, JobForecastRevision.ID).ToList

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each SecEmployee In (From SecUser In AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).Include("Employee")
                                                 Where SecUser.UserCode = Me.JobForecastRevision.CreatedByUserCode OrElse
                                                       SecUser.UserCode = Me.JobForecastRevision.ModifiedByUserCode OrElse
                                                       SecUser.UserCode = Me.JobForecastRevision.ApprovedByUserCode
                                                 Select SecUser.Employee).ToList

                            If JobForecastRevision.CreatedByUserCode <> "" Then

                                CreatedByEmployee = SecEmployee.ToString & " on " & LoGlo.FormatDateTime(cEmployee.UserDate(JobForecastRevision.CreatedDate))

                            End If

                            If JobForecastRevision.ModifiedByUserCode IsNot Nothing Then

                                ModifiedByEmploee = SecEmployee.ToString & " on " & LoGlo.FormatDateTime(cEmployee.UserDate(JobForecastRevision.ModifiedDate))

                            End If

                            If JobForecastRevision.ApprovedByUserCode IsNot Nothing Then

                                ApprovedByEmployee = SecEmployee.ToString & " on " & LoGlo.FormatDateTime(cEmployee.UserDate(JobForecastRevision.ApprovedDate))

                            End If

                        Next

                    End Using

                    'define colors
                    ColorsBeingUsed = New Generic.List(Of Drawing.Color)
                    ColorsBeingUsed.Add(Drawing.Color.DarkGray)
                    ColorsBeingUsed.Add(Drawing.Color.LightGray)
                    ColorsBeingUsed.Add(Drawing.Color.Silver)

                    For Each JobForecastJobSummary In JobForecastJobSummaryList.Where(Function(item) item.Color.HasValue).ToList

                        ColorsBeingUsed.Add(System.Drawing.Color.FromArgb(JobForecastJobSummary.Color))

                    Next

                    ColorsBeingUsed = ColorsBeingUsed.Where(Function(item) Not Workbook.IsColorInPalette(item)).Distinct.ToList

                    For Each Color In ColorsBeingUsed

                        Workbook.ChangePalette(Color, 55 - ColorsBeingUsed.IndexOf(Color)) '55 total colors allowed on the palette

                    Next

                    FirstDataRow = 0

                    '
                    ' Begin Location Header
                    '

                    Location = Me.LocationToOverride

                    If Location IsNot Nothing Then

                        If Location.LogoLocation <> "N" Then

                            Dim Picture As Aspose.Cells.Drawing.Picture = Nothing

                            Try

                                Picture = Worksheet.Pictures(Worksheet.Pictures.Add(0, 0, Location.LogoLandscapePath))

                                Worksheet.Cells.Merge(0, 0, 1, 16384)
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
                                Worksheet.Cells.Merge(FirstDataRow, 0, 1, 16384)

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

                    SetupExcelLabelCell(Worksheet.Cells(ActiveRow, 0), "Description:")
                    Worksheet.Cells(ActiveRow, 1).Value = JobForecastRevision.JobForecast.Description
                    Worksheet.Cells.Merge(ActiveRow, 1, 1, 5) ' aligns with "Variance" Column

                    ActiveRow = Worksheet.Cells.MaxRow + 1
                    Worksheet.Cells.Rows(ActiveRow).Height = 5 ' spacer row

                    ActiveRow += 1
                    Worksheet.Cells.Rows(ActiveRow + 1).Height = 5 ' spacer row
                    Worksheet.Cells.Rows(ActiveRow + 3).Height = 5 ' spacer row
                    SetupExcelLabelCell(Worksheet.Cells(ActiveRow, 0), "Comment:")
                    Worksheet.Cells(ActiveRow, 1).Value = JobForecastRevision.Comment
                    Worksheet.Cells.Merge(ActiveRow, 1, 5, 5) ' aligns with "Variance" Column
                    Style = Worksheet.Cells(ActiveRow, 1).GetStyle()
                    Style.VerticalAlignment = Aspose.Cells.TextAlignmentType.Top
                    Worksheet.Cells(ActiveRow, 1).SetStyle(Style)

                    ActiveRow = Worksheet.Cells.MaxRow + Worksheet.Cells(Worksheet.Cells.MaxRow, 1).GetMergedRange.RowCount
                    Worksheet.Cells.Rows(ActiveRow).Height = 5 ' spacer row

                    ActiveRow += 1
                    SetupExcelLabelCell(Worksheet.Cells(ActiveRow, 0), "Start/End:")
                    Worksheet.Cells(ActiveRow, 1).Value = String.Format("{0:MMMM yyyy} - {1:MMMM yyyy}", PostPeriods.OrderBy(Function(item) item.StartDate).First.StartDate.GetValueOrDefault, PostPeriods.OrderByDescending(Function(item) item.StartDate).First.StartDate.GetValueOrDefault)
                    SetupExcelLabelCell(Worksheet.Cells(ActiveRow, 3), "Created By:")
                    Worksheet.Cells(ActiveRow, 4).Value = CreatedByEmployee

                    Worksheet.Cells.Merge(ActiveRow, 4, 1, 4)

                    ActiveRow = Worksheet.Cells.MaxRow + 1
                    Worksheet.Cells.Rows(ActiveRow).Height = 5 ' spacer row

                    ActiveRow += 1
                    SetupExcelLabelCell(Worksheet.Cells(ActiveRow, 0), "Assigned To:")
                    Worksheet.Cells(ActiveRow, 1).Value = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(Me.DbContext, JobForecastRevision.JobForecast.AssignedToEmployeeCode).ToString()
                    SetupExcelLabelCell(Worksheet.Cells(ActiveRow, 3), "Modified By:")
                    Worksheet.Cells(ActiveRow, 4).Value = ModifiedByEmploee
                    Worksheet.Cells.Merge(ActiveRow, 4, 1, 4)

                    ActiveRow = Worksheet.Cells.MaxRow + 1
                    Worksheet.Cells.Rows(ActiveRow).Height = 5 ' spacer row

                    ActiveRow += 1
                    SetupExcelLabelCell(Worksheet.Cells(ActiveRow, 0), "Office:")
                    Worksheet.Cells(ActiveRow, 1).Value = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(Me.DbContext, JobForecastRevision.JobForecast.OfficeCode).ToString
                    SetupExcelLabelCell(Worksheet.Cells(ActiveRow, 3), "Approved By:")
                    Worksheet.Cells(ActiveRow, 4).Value = ApprovedByEmployee
                    Worksheet.Cells.Merge(ActiveRow, 4, 1, 4)

                    '
                    ' Begin Data Table
                    '

                    If Not Me.ShowSalesClass Then

                        SalesClassColumn = 0
                        CommentsColumn -= 1
                        EstimateColumn -= 1
                        ForecastColumn -= 1
                        ActualColumn -= 1
                        VarianceColumn -= 1

                    End If

                    If Not Me.ShowEstimateAmount Then

                        EstimateColumn = 0
                        ForecastColumn -= 1
                        ActualColumn -= 1
                        VarianceColumn -= 1

                    End If

                    If ForecastType = AdvantageFramework.JobForecast.JobForecastTypes.BillingAndRevenue Then

                        TotalPostPeriodColumns = PostPeriods.Count() * 2
                        TotalHeaderRows = 3

                    Else

                        TotalPostPeriodColumns = PostPeriods.Count()
                        TotalHeaderRows = 2

                    End If

                    TotalColumns = VarianceColumn + TotalPostPeriodColumns + 1

                    ' header row
                    ActiveRow = Worksheet.Cells.MaxRow + 2
                    TableStart = ActiveRow
                    SetupExcelHeaderRowCell(Worksheet.Cells(ActiveRow, JobComponentColumn), "Job/Component")

                    If Me.ShowSalesClass Then

                        SetupExcelHeaderRowCell(Worksheet.Cells(ActiveRow, SalesClassColumn), "Sales Class")

                    End If

                    SetupExcelHeaderRowCell(Worksheet.Cells(ActiveRow, CommentsColumn), "Comments")

                    If Me.ShowEstimateAmount Then

                        SetupExcelHeaderRowCell(Worksheet.Cells(ActiveRow, EstimateColumn), "Estimate")

                    End If

                    SetupExcelHeaderRowCell(Worksheet.Cells(ActiveRow, ForecastColumn), "Forecast")
                    SetupExcelHeaderRowCell(Worksheet.Cells(ActiveRow, ActualColumn), "Actual")
                    SetupExcelHeaderRowCell(Worksheet.Cells(ActiveRow, VarianceColumn), "Variance")

                    For ColumnIndex = 0 To VarianceColumn

                        If ColumnIndex = JobComponentColumn Then

                            Worksheet.Cells.Merge(ActiveRow, ColumnIndex, TotalHeaderRows, 2)

                        ElseIf ColumnIndex > (JobComponentColumn + 1) Then

                            Worksheet.Cells.Merge(ActiveRow, ColumnIndex, TotalHeaderRows, 1)

                        End If

                    Next

                    For Each PostPeriodYear In PostPeriods.Select(Function(Item) Item.Year).Distinct

                        HeaderRow1Cell = GetNextCell(Worksheet.Cells.Rows(ActiveRow).LastDataCell)

                        If ForecastType = AdvantageFramework.JobForecast.JobForecastTypes.BillingAndRevenue Then

                            SetupExcelHeaderRowCell(HeaderRow1Cell, PostPeriodYear)
                            Worksheet.Cells.Merge(HeaderRow1Cell.Row, HeaderRow1Cell.Column, 1, PostPeriods.Where(Function(Item) Item.Year = PostPeriodYear).Count * 2)

                        Else

                            SetupExcelHeaderRowCell(HeaderRow1Cell, PostPeriodYear & " " & AdvantageFramework.StringUtilities.GetNameAsWords(ForecastType.ToString))
                            Worksheet.Cells.Merge(HeaderRow1Cell.Row, HeaderRow1Cell.Column, 1, PostPeriods.Where(Function(Item) Item.Year = PostPeriodYear).Count)

                        End If

                        For Each PostPeriod In PostPeriods.Where(Function(Item) Item.Year = PostPeriodYear).ToList

                            HeaderRow2Cell = GetNextCell(Worksheet.Cells(HeaderRow1Cell.Row + 1, HeaderRow1Cell.Column - 1))
                            SetupExcelHeaderRowCell(HeaderRow2Cell, [Enum].GetName(GetType(AdvantageFramework.DateUtilities.Months), PostPeriod.Month))

                            If ForecastType = AdvantageFramework.JobForecast.JobForecastTypes.BillingAndRevenue Then

                                Worksheet.Cells.Merge(HeaderRow2Cell.Row, HeaderRow2Cell.Column, 1, 2)

                                HeaderRow3Cell = Worksheet.Cells(HeaderRow2Cell.Row + 1, HeaderRow2Cell.Column)
                                SetupExcelHeaderRowCell(HeaderRow3Cell, "Billing")

                                HeaderRow3Cell = Worksheet.Cells(HeaderRow2Cell.Row + 1, HeaderRow2Cell.Column + 1)
                                SetupExcelHeaderRowCell(HeaderRow3Cell, "Revenue")

                            End If

                        Next

                    Next

                    'End of Header Rows

                    JobForecastActuals = AdvantageFramework.JobForecast.LoadBillingAndActualData(Me.DbContext)

                    SummaryRows = New Generic.List(Of Integer)

                    If Me.GridGroupByOption = "S" Then

                        For Each JobForecastJobBySalesClass In JobForecastJobSummaryList.OrderBy(Function(item) item.SalesClassDescription).GroupBy(Function(item) item.SalesClassCode)

                            SetupGroupHeaderRow(Worksheet, TotalColumns, If(String.IsNullOrWhiteSpace(JobForecastJobBySalesClass.First.SalesClassCode), "[None]", JobForecastJobBySalesClass.First.SalesClassDescription), ActiveRow, Cell)

                            BuildGroupDetailRows(Worksheet,
                                                 JobForecastJobSummaryList.Where(Function(item) JobForecastJobBySalesClass.Any(Function(jc) jc.JobNumber = item.JobNumber)).OrderByDescending(Function(item) item.JobNumber).ThenBy(Function(item) item.JobComponentNumber).ToList,
                                                 JobForecastActuals, PostPeriods, JobForecastJobDetails, ForecastType, JobComponentColumn, SalesClassColumn, CommentsColumn, EstimateColumn, ForecastColumn, ActualColumn, VarianceColumn, TotalColumns, ActiveRow, SummaryRows)

                        Next

                    ElseIf Me.GridGroupByOption = "CS" Then

                        For Each JobForecastJobByClientAndSalesClass In JobForecastJobSummaryList.OrderBy(Function(item) item.ClientName).ThenBy(Function(item) item.SalesClassDescription).GroupBy(Function(JobComp) New With {JobComp.ClientCode, JobComp.SalesClassCode})

                            SetupGroupHeaderRow(Worksheet, TotalColumns, String.Format("Client: {0} | Sales Class: {1}", JobForecastJobByClientAndSalesClass.First.ClientName, If(String.IsNullOrWhiteSpace(JobForecastJobByClientAndSalesClass.Key.SalesClassCode), "[None]", JobForecastJobByClientAndSalesClass.First.SalesClassDescription)), ActiveRow, Cell)

                            BuildGroupDetailRows(Worksheet,
                                                 JobForecastJobSummaryList.Where(Function(item) JobForecastJobByClientAndSalesClass.Any(Function(jc) jc.JobNumber = item.JobNumber)).OrderByDescending(Function(item) item.JobNumber).ThenBy(Function(item) item.JobComponentNumber).ToList,
                                                 JobForecastActuals, PostPeriods, JobForecastJobDetails, ForecastType, JobComponentColumn, SalesClassColumn, CommentsColumn, EstimateColumn, ForecastColumn, ActualColumn, VarianceColumn, TotalColumns, ActiveRow, SummaryRows)

                        Next

                    Else ' Me.GridGroupByOption = "C" or Default

                        For Each JobForecastJobByClient In JobForecastJobSummaryList.OrderBy(Function(item) item.ClientName).GroupBy(Function(JobComp) JobComp.ClientCode)

                            SetupGroupHeaderRow(Worksheet, TotalColumns, JobForecastJobByClient.First.ClientName, ActiveRow, Cell)

                            BuildGroupDetailRows(Worksheet,
                                                 JobForecastJobSummaryList.Where(Function(item) JobForecastJobByClient.Any(Function(jc) jc.JobNumber = item.JobNumber)).OrderByDescending(Function(item) item.JobNumber).ThenBy(Function(item) item.JobComponentNumber).ToList,
                                                 JobForecastActuals, PostPeriods, JobForecastJobDetails, ForecastType, JobComponentColumn, SalesClassColumn, CommentsColumn, EstimateColumn, ForecastColumn, ActualColumn, VarianceColumn, TotalColumns, ActiveRow, SummaryRows)

                        Next

                    End If

                    ActiveRow = Worksheet.Cells.MaxRow + 1

                    'summary row
                    For ColumnIndex = ForecastColumn To (TotalColumns - 1)

                        Cell = Worksheet.Cells(ActiveRow, ColumnIndex)

                        Dim Formula As String = "=" & String.Join(" + ", (From Item In SummaryRows
                                                                          Select Worksheet.Cells(Item, ColumnIndex).Name))

                        SetupExcelNumericRowCell(Cell, Nothing, Formula, Nothing)

                        If Cell.Column = ForecastColumn Then

                            SetupExcelLabelCell(Worksheet.Cells(FirstDataRow + 2, SummaryTableColumn), "Forecast")
                            SetupExcelNumericRowCell(Worksheet.Cells(FirstDataRow + 2, SummaryTableColumn + 1), Nothing, Cell.Formula, Nothing)

                        End If

                    Next

                    SetupExcelLabelCell(Worksheet.Cells(FirstDataRow, SummaryTableColumn), "Budget Total")
                    SetupExcelNumericRowCell(Worksheet.Cells(FirstDataRow, SummaryTableColumn + 1), JobForecast.Budget, Nothing, Nothing)

                    SetupExcelLabelCell(Worksheet.Cells(FirstDataRow + 4, SummaryTableColumn), "Variance")
                    SetupExcelNumericRowCell(Worksheet.Cells(FirstDataRow + 4, SummaryTableColumn + 1), Nothing, String.Format("={0}-{1}", Worksheet.Cells(FirstDataRow, SummaryTableColumn + 1).Name, Worksheet.Cells(FirstDataRow + 2, SummaryTableColumn + 1).Name), Nothing)

                    Worksheet.AutoFitColumns()

                End If

            End If

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
    Private Sub SetupExcelJobComponentHeaderRowCell(ByVal Cell As Aspose.Cells.Cell, ByVal ClientName As String)

        'objects
        Dim Style As Aspose.Cells.Style = Nothing

        With Cell

            .PutValue(ClientName)

            Style = .GetStyle()

            Style.Pattern = Aspose.Cells.BackgroundType.Solid
            Style.ForegroundColor = Drawing.Color.LightGray

            .SetStyle(Style)

        End With

    End Sub
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
    Private Sub SetupGroupHeaderRow(ByVal Worksheet As Aspose.Cells.Worksheet, ByVal TotalColumns As Integer, ByVal HeaderRowText As String, ByRef ActiveRow As Integer, ByRef Cell As Aspose.Cells.Cell)

        ActiveRow = Worksheet.Cells.MaxRow + 1
        Cell = Worksheet.Cells(ActiveRow, 0)
        SetupExcelJobComponentHeaderRowCell(Cell, HeaderRowText)
        Worksheet.Cells.Merge(Cell.Row, Cell.Column, 1, TotalColumns)

    End Sub
    Private Sub BuildGroupDetailRows(ByVal Worksheet As Aspose.Cells.Worksheet,
                                     ByVal JobForecastJobSummaryList As Generic.List(Of AdvantageFramework.JobForecast.Classes.JobForecastJobSummary),
                                     ByVal JobForecastActuals As Generic.List(Of AdvantageFramework.JobForecast.Classes.JobForecastActual),
                                     ByVal PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod),
                                     ByVal JobForecastJobDetails As Generic.List(Of AdvantageFramework.Database.Entities.JobForecastJobDetail),
                                     ByVal ForecastType As AdvantageFramework.JobForecast.JobForecastTypes,
                                     ByVal JobComponentColumn As Short, ByVal SalesClassColumn As Short, ByVal CommentsColumn As Short, ByVal EstimateColumn As Short,
                                     ByVal ForecastColumn As Short, ByVal ActualColumn As Short, ByVal VarianceColumn As Short, ByVal TotalColumns As Short,
                                     ByRef ActiveRow As Integer, ByRef SummaryRows As Generic.List(Of Integer))

        'objects
        Dim JobForecastJobColor As System.Drawing.Color = Nothing
        Dim BillingAmount As Decimal? = Nothing
        Dim RevenueAmount As Decimal? = Nothing
        Dim JobForecastJobDetail As AdvantageFramework.Database.Entities.JobForecastJobDetail = Nothing
        Dim RowStart As Integer = -1
        Dim Cell As Aspose.Cells.Cell = Nothing

        RowStart = Worksheet.Cells.MaxRow + 1

        For Each JobForecastJobSummary In JobForecastJobSummaryList

            JobForecastJobColor = Nothing

            If JobForecastJobSummary.Color.HasValue Then

                JobForecastJobColor = System.Drawing.Color.FromArgb(JobForecastJobSummary.Color)

            End If

            ActiveRow = Worksheet.Cells.MaxRow + 1
            SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, JobComponentColumn), String.Format("{0} - {1} {2}", AdvantageFramework.StringUtilities.PadWithCharacter(JobForecastJobSummary.JobNumber, 6, "0", True), AdvantageFramework.StringUtilities.PadWithCharacter(JobForecastJobSummary.JobComponentNumber, 6, "0", True), JobForecastJobSummary.JobComponentDescription), Nothing, False, JobForecastJobColor)
            Worksheet.Cells.Merge(ActiveRow, JobComponentColumn, 1, 2)

            If Me.ShowSalesClass Then

                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, SalesClassColumn), JobForecastJobSummary.SalesClassDescription, Nothing, False, JobForecastJobColor)

            End If

            SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, CommentsColumn), JobForecastJobSummary.Comments, Nothing, False, JobForecastJobColor)

            If Me.ShowEstimateAmount Then

                If ForecastType = AdvantageFramework.JobForecast.JobForecastTypes.Billing Then

                    SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, EstimateColumn), JobForecastJobSummary.ApprovedEstimateBillingAmount, Nothing, True, JobForecastJobColor) ' billing

                ElseIf ForecastType = AdvantageFramework.JobForecast.JobForecastTypes.Revenue Then

                    SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, EstimateColumn), JobForecastJobSummary.ApprovedEstimateRevenueAmount, Nothing, True, JobForecastJobColor) ' revenue

                Else

                    SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, EstimateColumn), JobForecastJobSummary.ApprovedEstimateBillingAmount, Nothing, True, JobForecastJobColor) ' billing

                End If

            End If

            If ForecastType = AdvantageFramework.JobForecast.JobForecastTypes.BillingAndRevenue Then

                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, ForecastColumn), Nothing, String.Format("=SUMPRODUCT((MOD(COLUMN({0}:{1}),2) = {2})*({0}:{1}))", Worksheet.Cells(ActiveRow, VarianceColumn + 1).Name, Worksheet.Cells(ActiveRow, TotalColumns - 1).Name, VarianceColumn Mod 2), True, JobForecastJobColor)

            Else

                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, ForecastColumn), Nothing, String.Format("=SUM({0}:{1})", Worksheet.Cells(ActiveRow, VarianceColumn + 1).Name, Worksheet.Cells(ActiveRow, TotalColumns - 1).Name), True, JobForecastJobColor)

            End If

            If ForecastType = AdvantageFramework.JobForecast.JobForecastTypes.Revenue Then

                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, ActualColumn), AdvantageFramework.JobForecast.CalculateActualRevenue(JobForecastActuals, Nothing, JobForecastJobSummary.JobNumber, JobForecastJobSummary.JobComponentNumber), Nothing, True, JobForecastJobColor)

            Else

                SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, ActualColumn), AdvantageFramework.JobForecast.CalculateActualBilling(JobForecastActuals, Nothing, JobForecastJobSummary.JobNumber, JobForecastJobSummary.JobComponentNumber), Nothing, True, JobForecastJobColor)

            End If

            SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, VarianceColumn), Nothing, String.Format("={0}-{1}", Worksheet.Cells(ActiveRow, ForecastColumn).Name, Worksheet.Cells(ActiveRow, ActualColumn).Name), True, JobForecastJobColor)

            For Each PostPeriod In PostPeriods

                BillingAmount = Nothing
                RevenueAmount = Nothing

                JobForecastJobDetail = JobForecastJobDetails.FirstOrDefault(Function(item) item.JobForecastJobID = JobForecastJobSummary.JobForecastJobID AndAlso item.PostPeriod = PostPeriod.Code)

                If JobForecastJobDetail IsNot Nothing Then

                    BillingAmount = JobForecastJobDetail.BillingAmount
                    RevenueAmount = JobForecastJobDetail.RevenueAmount

                End If

                If ForecastType = AdvantageFramework.JobForecast.JobForecastTypes.BillingAndRevenue Then

                    SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, (VarianceColumn + 1) + (2 * PostPeriods.IndexOf(PostPeriod))), BillingAmount, Nothing, True, JobForecastJobColor) ' billing
                    SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, (VarianceColumn + 2) + (2 * PostPeriods.IndexOf(PostPeriod))), RevenueAmount, Nothing, True, JobForecastJobColor) ' revenue

                ElseIf ForecastType = AdvantageFramework.JobForecast.JobForecastTypes.Billing Then

                    SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, (VarianceColumn + 1) + PostPeriods.IndexOf(PostPeriod)), BillingAmount, Nothing, True, JobForecastJobColor) ' billing

                ElseIf ForecastType = AdvantageFramework.JobForecast.JobForecastTypes.Revenue Then

                    SetupExcelJobComponentRowCell(Worksheet.Cells(ActiveRow, (VarianceColumn + 1) + PostPeriods.IndexOf(PostPeriod)), RevenueAmount, Nothing, True, JobForecastJobColor) ' revenue

                End If

            Next

        Next

        Worksheet.Cells.GroupRows(RowStart, ActiveRow)

        ActiveRow = Worksheet.Cells.MaxRow + 1

        SummaryRows.Add(ActiveRow)

        'Group Summary Row
        For ColumnIndex = ForecastColumn To (TotalColumns - 1)

            Cell = Worksheet.Cells(ActiveRow, ColumnIndex)

            SetupExcelNumericRowCell(Cell, Nothing, String.Format("=SUM({0}:{1})", Worksheet.Cells(RowStart, Cell.Column).Name, Worksheet.Cells(Cell.Row - 1, Cell.Column).Name), Nothing)

        Next

        ActiveRow = Worksheet.Cells.MaxRow + 1

    End Sub

#Region "  Page Methods "

    Private Sub JobForecast_Print_Init(sender As Object, e As EventArgs) Handles Me.Init

        Try

            If Not String.IsNullOrWhiteSpace("JobForecastRevisionID") Then

                _JobForecastRevisionID = Me.Request.QueryString("JobForecastRevisionID")

            End If

        Catch ex As Exception
            _JobForecastRevisionID = Nothing
        End Try

    End Sub
    Private Sub JobForecast_Print_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_JobForecast)

            If _JobForecastRevisionID > 0 Then

                RadComboBoxLocation.DataSource = (From Item In AdvantageFramework.Database.Procedures.Location.Load(Me.DataContext)
                                                  Select [ID] = Item.ID,
                                                         [Name] = Item.ID & " - " & Item.Name).ToList
                RadComboBoxLocation.DataBind()
                RadComboBoxLocation.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", ""))

                If Not String.IsNullOrWhiteSpace(Me.JobForecastSettings.getAppVar("LocationID", "String", "")) Then

                    RadComboBoxLocation.SelectedValue = Me.JobForecastSettings.getAppVar("LocationID", "String", "")

                End If

            End If

            LoadLocationInformation()

        End If

        RadToolBarPOPrintOptions.Enabled = Me.CanUserPrint

    End Sub
    Private Sub JobForecast_Print_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        Try

            If _DbContext IsNot Nothing Then

                _DbContext.Dispose()
                _DbContext = Nothing

            End If

        Catch ex As Exception

        End Try

        Try

            If _DbContext IsNot Nothing Then

                _DbContext.Dispose()
                _DbContext = Nothing

            End If

        Catch ex As Exception

        End Try

        Try

            If _DataContext IsNot Nothing Then

                _DataContext.Dispose()
                _DataContext = Nothing

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub JobForecast_Print_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Select Case Me.CurrentPageMode

            Case PageMode.Print

                Me.ExportToExcel()
                Me.CloseThisWindow()

        End Select

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadComboBoxLocation_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxLocation.SelectedIndexChanged

        LoadLocationInformation()

    End Sub
    Private Sub RadToolBarPOPrintOptions_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarPOPrintOptions.ButtonClick

        Select Case e.Item.Value

            Case "ExportToExcel"

                ExportToExcel()

            Case "Save"

                SaveSettings()

        End Select

    End Sub

#End Region

#End Region

End Class