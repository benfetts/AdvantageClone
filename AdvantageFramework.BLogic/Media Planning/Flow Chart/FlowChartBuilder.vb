Namespace MediaPlanning.FlowChart

    Public Class FlowChartBuilder

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _CurrentRow As Integer
        Private _CurrentColumn As Integer
        Private _Workbook As Aspose.Cells.Workbook = Nothing
        Private _License As Aspose.Cells.License = Nothing
        Private _Worksheet As Aspose.Cells.Worksheet = Nothing
        Private _LocationPicture As Aspose.Cells.Drawing.Picture = Nothing
        Private _LocationRow As Integer

#End Region

#Region " Properties "

        Public ReadOnly Property CurrentRow As Integer
            Get
                CurrentRow = _CurrentRow
            End Get
        End Property
        Public ReadOnly Property CurrentColumn As Integer
            Get
                CurrentColumn = _CurrentColumn
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            'objects
            Dim Style As Aspose.Cells.Style = Nothing

            _CurrentRow = -1
            _CurrentColumn = 0

            _License = New Aspose.Cells.License

            _License.SetLicense("Aspose.Total.lic")

            _Workbook = New Aspose.Cells.Workbook

            _Workbook.Worksheets.Clear()

            _Workbook.Worksheets.Add(Aspose.Cells.SheetType.Worksheet)

            _Worksheet = _Workbook.Worksheets(0)

            Style = New Aspose.Cells.Style
            Style.Font.Name = "Arial"
            Style.Font.Size = 11
            _Worksheet.Cells.ApplyStyle(Style, New Aspose.Cells.StyleFlag With {.Font = True})
            _Worksheet.Zoom = 100
            _Worksheet.IsGridlinesVisible = False
            _Worksheet.Cells.StandardHeight = 15
            _Worksheet.Cells.StandardWidth = 30

        End Sub
        Public Sub Construct(FlowChart As FlowChart)

            'objects
            Dim Column As Integer = 0
            Dim Image As AdvantageFramework.Database.Entities.Image = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim PictureIndex As Integer = 0
            Dim Picture As Aspose.Cells.Drawing.Picture = Nothing
            Dim EstimateCounter As Integer = 0
            Dim ErrorCheckingOptionIndex As Integer = 0
            Dim ErrorCheckOption As Aspose.Cells.ErrorCheckOption = Nothing

            _Worksheet.FreezePanes(0, FlowChart.NumberOfLevels, 0, FlowChart.NumberOfLevels)

            'create location header
            CreateLocationHeader(FlowChart)
            'create plan header
            CreatePlanHeader(FlowChart)
            'create estimate flow chart
            For Each FlowChartEstimate In FlowChart.FlowChartEstimates.OrderBy(Function(FCE) FCE.MediaPlanEstimate.OrderNumber).ToList

                If EstimateCounter = 0 Then

                    CreateRowGrandTotalsColumnHeader(FlowChartEstimate)

                    CreateEstimateFieldHeader(FlowChartEstimate)

                Else

                    CreateEstimateHeader(FlowChartEstimate)

                    CreateRowGrandTotalsColumnHeader(FlowChartEstimate)

                End If

                CreateEstimateRowsDefault(FlowChartEstimate)

                If FlowChart.FlowChartMediaPlanOptions.PrintEstimateColumnTotals Then

                    If FlowChart.FlowChartMediaPlanOptions.EstimateColumnTotalsType = EstimateColumnTotalsTypes.Default Then

                        CreateEstimateGrandTotalRow(FlowChartEstimate)

                    ElseIf FlowChart.FlowChartMediaPlanOptions.EstimateColumnTotalsType = EstimateColumnTotalsTypes.ByMonth Then

                        CreateMonthTotalsRow(FlowChartEstimate)

                    ElseIf FlowChart.FlowChartMediaPlanOptions.EstimateColumnTotalsType = EstimateColumnTotalsTypes.Both Then

                        CreateEstimateGrandTotalRow(FlowChartEstimate)
                        CreateMonthTotalsRow(FlowChartEstimate)

                    End If

                End If

                EstimateCounter += 1

                _CurrentRow += 3

            Next

            _CurrentRow -= 2

            If FlowChart.FlowChartMediaPlanOptions.PrintGrandTotals Then

                If FlowChart.FlowChartMediaPlanOptions.GrandTotalsType = GrandTotalsTypes.Default Then

                    CreateGrandTotalRow(FlowChart)
                    _CurrentRow += 1

                ElseIf FlowChart.FlowChartMediaPlanOptions.GrandTotalsType = GrandTotalsTypes.ByMonth Then

                    CreateMonthGrandTotalsRow(FlowChart)
                    _CurrentRow += 1

                ElseIf FlowChart.FlowChartMediaPlanOptions.GrandTotalsType = GrandTotalsTypes.Both Then

                    CreateGrandTotalRow(FlowChart)
                    _CurrentRow += 1

                    CreateMonthGrandTotalsRow(FlowChart)
                    _CurrentRow += 1

                End If

            End If

            If FlowChart.FlowChartMediaPlanOptions.FlowChartSummaryOption <> FlowChartSummaryOptions.None Then

                _CurrentRow += 2

                CreateSummary(FlowChart)

            End If

            For Column = 0 To FlowChart.NumberOfLevels - 1

                _Worksheet.Cells.SetColumnWidth(Column, 30)

            Next

            For Each FlowChartEstimateDate In FlowChart.FlowChartEstimateDates

                _Worksheet.AutoFitColumn(Column)

                Column += 1

            Next

            If FlowChart.FlowChartEstimates.Any(Function(Entity) Entity.FlowChartMediaPlanEstimateOptions.ShowEstimateRowTotals) Then

                _Worksheet.AutoFitColumn(Column)

            End If

            _Worksheet.AutoFitRows()

            If _LocationPicture IsNot Nothing Then

                _Worksheet.Cells.SetRowHeightPixel(_LocationRow, _LocationPicture.Height)
                _Worksheet.Cells.SetColumnWidthPixel(_LocationRow, _LocationPicture.Width)

            End If

            If FlowChart.FlowChartMediaPlanOptions.ImageID.GetValueOrDefault(0) > 0 Then

                _CurrentColumn = 0

                Using DbContext = New AdvantageFramework.Database.DbContext(FlowChart.Session.ConnectionString, FlowChart.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    Image = DbContext.Images.Find(FlowChart.FlowChartMediaPlanOptions.ImageID.GetValueOrDefault(0))

                End Using

                If Image IsNot Nothing Then

                    MemoryStream = New System.IO.MemoryStream(Image.Bytes)

                    _CurrentRow += 3

                    _Worksheet.Cells(_CurrentRow, _CurrentColumn).Value = ""

                    PictureIndex = _Worksheet.Pictures.Add(_CurrentRow, _CurrentColumn, MemoryStream)

                    Picture = _Worksheet.Pictures(PictureIndex)
                    Picture.Placement = Aspose.Cells.Drawing.PlacementType.FreeFloating

                    _Worksheet.Cells.SetRowHeightPixel(_CurrentRow, Picture.Height)
                    _Worksheet.Cells.SetColumnWidthPixel(_CurrentRow, Picture.Width)

                End If

                _CurrentRow += 1

            End If

            ErrorCheckingOptionIndex = _Worksheet.ErrorCheckOptions.Add

            ErrorCheckOption = _Worksheet.ErrorCheckOptions(ErrorCheckingOptionIndex)

            ErrorCheckOption.AddRange(Aspose.Cells.CellArea.CreateCellArea(0, 0, _Worksheet.Cells.MaxDataRow, _Worksheet.Cells.MaxDataColumn))
            ErrorCheckOption.SetErrorCheck(Aspose.Cells.ErrorCheckType.TextNumber, False)

        End Sub
        Private Sub CreateLocationHeader(FlowChart As FlowChart)

            'objects
            Dim Cell As Aspose.Cells.Cell = Nothing
            Dim CellStyle As CellStyle = Nothing
            Dim PictureIndex As Integer = 0
            Dim Picture As Aspose.Cells.Drawing.Picture = Nothing
            Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
            Dim LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

            If String.IsNullOrWhiteSpace(FlowChart.FlowChartMediaPlanOptions.LocationID) = False Then

                Using DataContext = New AdvantageFramework.Database.DataContext(FlowChart.Session.ConnectionString, FlowChart.Session.UserCode)

                    Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, FlowChart.FlowChartMediaPlanOptions.LocationID)

                End Using

            Else

                Location = Nothing

            End If

            If Location IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Location.LogoPath) = False AndAlso
                    My.Computer.FileSystem.FileExists(Location.LogoPath) Then

                _CurrentRow += 1

                _Worksheet.Cells(_CurrentRow, _CurrentColumn).Value = ""

                PictureIndex = _Worksheet.Pictures.Add(_CurrentRow, _CurrentColumn, Location.LogoPath)

                Picture = _Worksheet.Pictures(PictureIndex)
                Picture.Placement = Aspose.Cells.Drawing.PlacementType.FreeFloating

                _Worksheet.Cells.SetRowHeightPixel(_CurrentRow, Picture.Height)
                _Worksheet.Cells.SetColumnWidthPixel(_CurrentRow, Picture.Width)

            ElseIf Location IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(FlowChart.Session.ConnectionString, FlowChart.Session.UserCode)

                    LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Location.ID, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)

                End Using

                If LocationLogo IsNot Nothing Then

                    _CurrentRow += 1

                    _LocationRow = _CurrentRow

                    _Worksheet.Cells(_CurrentRow, _CurrentColumn).Value = ""

                    Using MemoryStream = New System.IO.MemoryStream(LocationLogo.Image)

                        PictureIndex = _Worksheet.Pictures.Add(_CurrentRow, _CurrentColumn, MemoryStream)

                    End Using

                    _LocationPicture = _Worksheet.Pictures(PictureIndex)
                    _LocationPicture.Placement = Aspose.Cells.Drawing.PlacementType.FreeFloating

                    _Worksheet.Cells.SetRowHeightPixel(_LocationRow, _LocationPicture.Height)
                    _Worksheet.Cells.SetColumnWidthPixel(_LocationRow, _LocationPicture.Width)

                End If

            End If

            '_CurrentRow += 1

            'CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
            '                                .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
            '                                .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
            '                                .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
            '                                .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
            '                                .BackgroundColor = System.Drawing.Color.Empty}

            'SetCell(_CurrentRow, _CurrentColumn, FlowChart.MediaPlan.Description, CellStyle)

            _CurrentRow += 2

        End Sub
        Private Sub CreatePlanHeader(FlowChart As FlowChart)

            'objects
            Dim PrintableFlowChartEstimate As FlowChartEstimate = Nothing
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing
            Dim MediaPlanDetailFields As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailField) = Nothing
            Dim IsCalendarMonth As Boolean = False
            Dim WeeklyDisplayType As AdvantageFramework.MediaPlanning.WeekDisplayTypes = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekNumber
            Dim CellStyle As CellStyle = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim BillingTotal As Decimal = 0

            CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                            .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
                                            .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
                                            .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
                                            .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
                                            .BackgroundColor = System.Drawing.Color.Empty}

            Using DbContext = New AdvantageFramework.Database.DbContext(FlowChart.Session.ConnectionString, FlowChart.Session.UserCode)

                DbContext.Database.Connection.Open()

                Try


                    ClientContact = AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(FlowChart.MediaPlan.DbContext, FlowChart.MediaPlan.ClientContactID.GetValueOrDefault(0))

                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(FlowChart.MediaPlan.DbContext, FlowChart.MediaPlan.ClientCode)

                    Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(FlowChart.MediaPlan.DbContext, FlowChart.MediaPlan.ClientCode, FlowChart.MediaPlan.DivisionCode)

                    Product = FlowChart.MediaPlan.Product

                Catch ex As Exception

                End Try

                For Each MediaPlanEstimate In FlowChart.MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)()

                    BillingTotal += MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.BillAmount.GetValueOrDefault(0)).Sum

                Next

            End Using

            'set plan name
            SetCell(_CurrentRow, _CurrentColumn, FlowChart.MediaPlan.Description, CellStyle)

            _CurrentRow += 1
            'set client
            If Client IsNot Nothing Then

                SetCell(_CurrentRow, _CurrentColumn, "Client: " & Client.Name, CellStyle)

                _CurrentRow += 1

            End If
            'set division
            If Client IsNot Nothing AndAlso Division IsNot Nothing AndAlso Client.Name <> Division.Name Then

                SetCell(_CurrentRow, _CurrentColumn, "Division: " & Division.Name, CellStyle)

                _CurrentRow += 1

            End If

            'set product
            If Client IsNot Nothing AndAlso Division IsNot Nothing AndAlso Product IsNot Nothing AndAlso Division.Name <> Product.Name Then

                SetCell(_CurrentRow, _CurrentColumn, "Product: " & Product.Name, CellStyle)

                _CurrentRow += 1

            End If

            'set client contact
            If ClientContact IsNot Nothing Then

                SetCell(_CurrentRow, _CurrentColumn, "Client Contact: " & ClientContact.ToString, CellStyle)

                _CurrentRow += 1

            End If

            'set start date
            SetCell(_CurrentRow, _CurrentColumn, "Date Range: " & FlowChart.FlowChartMediaPlanOptions.StartDate.ToShortDateString & " - " & FlowChart.FlowChartMediaPlanOptions.EndDate.ToShortDateString, CellStyle)

            _CurrentRow += 1
            'set gross budget
            SetCell(_CurrentRow, _CurrentColumn, "Budget: " & FormatCurrency(FlowChart.MediaPlan.GrossBudgetAmount.GetValueOrDefault(0)), CellStyle)

            _CurrentRow += 1
            'set billing total
            SetCell(_CurrentRow, _CurrentColumn, "Billing Total: " & FormatCurrency(BillingTotal), CellStyle)

            _CurrentRow += 1
            'set variance
            SetCell(_CurrentRow, _CurrentColumn, "Variance: " & FormatCurrency(FlowChart.MediaPlan.GrossBudgetAmount.GetValueOrDefault(0) - BillingTotal), CellStyle)

            _CurrentRow += 1
            'set commment
            If String.IsNullOrWhiteSpace(FlowChart.MediaPlan.Comment) = False Then

                SetCell(_CurrentRow, _CurrentColumn, "Comment: " & FlowChart.MediaPlan.Comment, CellStyle)

                _CurrentRow += 1

            End If

            _CurrentRow += 2

            SetCell(_CurrentRow, _CurrentColumn, FlowChart.FlowChartEstimates(0).MediaPlanEstimate.Name, CellStyle)

            _CurrentRow += 1

            For Each FlowChartEstimate In FlowChart.FlowChartEstimates

                If FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailFields.Where(Function(Entity) Entity.Area = 1 AndAlso Entity.IsVisible = True).Count > 0 Then

                    If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.PrintDateHeader Then

                        PrintableFlowChartEstimate = FlowChartEstimate
                        Exit For

                    End If

                End If

            Next

            If PrintableFlowChartEstimate Is Nothing Then

                PrintableFlowChartEstimate = FlowChart.FlowChartEstimates(0)

            End If

            If FlowChart.FlowChartMediaPlanOptions.FlowChartDateHeaderOption = FlowChartDateHeaderOptions.FromPlan Then

                MediaPlanDetailFields = PrintableFlowChartEstimate.MediaPlanEstimate.MediaPlanDetailFields.Where(Function(Entity) Entity.Area = 1 AndAlso Entity.IsVisible = True).OrderBy(Function(Entity) Entity.AreaIndex).ToList

                If MediaPlanDetailFields.Count > 0 Then

                    For Each MediaPlanDetailField In MediaPlanDetailFields

                        _CurrentColumn = PrintableFlowChartEstimate.FlowChart.NumberOfLevels

                        _CurrentRow += 1

                        'If PrintableFlowChartEstimate.FlowChartMediaPlanEstimateOptions.PrintDateHeader Then

                        CreateDateHeaderRow(PrintableFlowChartEstimate, MediaPlanDetailField.FieldID, True)

                        'End If

                    Next

                End If

            Else

                If FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                    IsCalendarMonth = PrintableFlowChartEstimate.MediaPlanEstimate.IsCalendarMonth

                ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                    IsCalendarMonth = False

                ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                    IsCalendarMonth = True

                End If

                If FlowChart.FlowChartMediaPlanOptions.FlowChartWeekDisplayType = FlowChartWeekDisplayTypes.FromPlan Then

                    WeeklyDisplayType = PrintableFlowChartEstimate.MediaPlanEstimate.WeekDisplayType

                ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartWeekDisplayType = FlowChartWeekDisplayTypes.WeekNumber Then

                    WeeklyDisplayType = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekNumber

                ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartWeekDisplayType = FlowChartWeekDisplayTypes.WeekStartDate Then

                    WeeklyDisplayType = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekStartDate

                ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartWeekDisplayType = FlowChartWeekDisplayTypes.WeekStartDay Then

                    WeeklyDisplayType = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekStartDay

                End If

                If FlowChart.FlowChartMediaPlanOptions.PrintYear Then

                    _CurrentColumn = FlowChart.NumberOfLevels

                    _CurrentRow += 1

                    CreateDateHeaderRow(FlowChart, AdvantageFramework.MediaPlanning.DataColumns.Year.ToString, IsCalendarMonth, WeeklyDisplayType, True)

                End If

                If FlowChart.FlowChartMediaPlanOptions.PrintQuarter Then

                    _CurrentColumn = FlowChart.NumberOfLevels

                    _CurrentRow += 1

                    CreateDateHeaderRow(FlowChart, AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString, IsCalendarMonth, WeeklyDisplayType, True)

                End If

                If FlowChart.FlowChartMediaPlanOptions.PrintMonth Then

                    _CurrentColumn = FlowChart.NumberOfLevels

                    _CurrentRow += 1

                    CreateDateHeaderRow(FlowChart, AdvantageFramework.MediaPlanning.DataColumns.Month.ToString, IsCalendarMonth, WeeklyDisplayType, True)

                End If

                If FlowChart.FlowChartMediaPlanOptions.PrintMonthName Then

                    _CurrentColumn = FlowChart.NumberOfLevels

                    _CurrentRow += 1

                    CreateDateHeaderRow(FlowChart, AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString, IsCalendarMonth, WeeklyDisplayType, True)

                End If

                If FlowChart.FlowChartMediaPlanOptions.PrintWeek Then

                    _CurrentColumn = FlowChart.NumberOfLevels

                    _CurrentRow += 1

                    CreateDateHeaderRow(FlowChart, AdvantageFramework.MediaPlanning.DataColumns.Week.ToString, IsCalendarMonth, WeeklyDisplayType, True)

                End If

                If FlowChart.FlowChartMediaPlanOptions.PrintDay Then

                    _CurrentColumn = FlowChart.NumberOfLevels

                    _CurrentRow += 1

                    CreateDateHeaderRow(FlowChart, AdvantageFramework.MediaPlanning.DataColumns.Day.ToString, IsCalendarMonth, WeeklyDisplayType, True)

                End If

                If FlowChart.FlowChartMediaPlanOptions.PrintDate Then

                    _CurrentColumn = FlowChart.NumberOfLevels

                    _CurrentRow += 1

                    CreateDateHeaderRow(FlowChart, AdvantageFramework.MediaPlanning.DataColumns.Date.ToString, IsCalendarMonth, WeeklyDisplayType, True)

                End If

            End If

        End Sub
        Private Sub CreateEstimateHeader(FlowChartEstimate As FlowChartEstimate)

            'objects
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing
            Dim MediaPlanDetailFields As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailField) = Nothing
            Dim CellStyle As CellStyle = Nothing

            _CurrentColumn = FlowChartEstimate.FlowChart.NumberOfLevels

            CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                            .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
                                            .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
                                            .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
                                            .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
                                            .BackgroundColor = System.Drawing.Color.Empty}

            SetCell(_CurrentRow, 0, FlowChartEstimate.MediaPlanEstimate.Name, CellStyle)

            _CurrentRow += 1

            If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.FlowChartMediaPlanOptions.FlowChartDateHeaderOption = FlowChartDateHeaderOptions.FromPlan Then

                If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.PrintDateHeader Then

                    MediaPlanDetailFields = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailFields.Where(Function(Entity) Entity.Area = 1 AndAlso Entity.IsVisible = True).OrderBy(Function(Entity) Entity.AreaIndex).ToList

                    If MediaPlanDetailFields.Count > 0 Then

                        For Each MediaPlanDetailField In MediaPlanDetailFields

                            _CurrentColumn = FlowChartEstimate.FlowChart.NumberOfLevels

                            _CurrentRow += 1

                            CreateDateHeaderRow(FlowChartEstimate, MediaPlanDetailField.FieldID)

                            'If MediaPlanDetailField Is MediaPlanDetailFields.Last Then

                            '    MergeAndFillExtraLevelColumns(FlowChartEstimate)

                            'End If

                        Next

                        CreateEstimateFieldHeader(FlowChartEstimate)

                    Else

                        CreateEstimateFieldHeader(FlowChartEstimate)

                    End If

                Else

                    CreateDateHeaderRow(FlowChartEstimate, String.Empty)

                    CreateEstimateFieldHeader(FlowChartEstimate)

                End If

            ElseIf FlowChartEstimate.FlowChartMediaPlanEstimateOptions.FlowChartMediaPlanOptions.FlowChartDateHeaderOption = FlowChartDateHeaderOptions.ChooseLevels Then

                If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.PrintDateHeader Then

                    If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.FlowChartMediaPlanOptions.PrintYear Then

                        _CurrentColumn = FlowChartEstimate.FlowChart.NumberOfLevels

                        _CurrentRow += 1

                        CreateDateHeaderRow(FlowChartEstimate, AdvantageFramework.MediaPlanning.DataColumns.Year.ToString)

                    End If

                    If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.FlowChartMediaPlanOptions.PrintQuarter Then

                        _CurrentColumn = FlowChartEstimate.FlowChart.NumberOfLevels

                        _CurrentRow += 1

                        CreateDateHeaderRow(FlowChartEstimate, AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString)

                    End If

                    If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.FlowChartMediaPlanOptions.PrintMonth Then

                        _CurrentColumn = FlowChartEstimate.FlowChart.NumberOfLevels

                        _CurrentRow += 1

                        CreateDateHeaderRow(FlowChartEstimate, AdvantageFramework.MediaPlanning.DataColumns.Month.ToString)

                    End If

                    If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.FlowChartMediaPlanOptions.PrintMonthName Then

                        _CurrentColumn = FlowChartEstimate.FlowChart.NumberOfLevels

                        _CurrentRow += 1

                        CreateDateHeaderRow(FlowChartEstimate, AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString)

                    End If

                    If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.FlowChartMediaPlanOptions.PrintWeek Then

                        _CurrentColumn = FlowChartEstimate.FlowChart.NumberOfLevels

                        _CurrentRow += 1

                        CreateDateHeaderRow(FlowChartEstimate, AdvantageFramework.MediaPlanning.DataColumns.Week.ToString)

                    End If

                    If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.FlowChartMediaPlanOptions.PrintDay Then

                        _CurrentColumn = FlowChartEstimate.FlowChart.NumberOfLevels

                        _CurrentRow += 1

                        CreateDateHeaderRow(FlowChartEstimate, AdvantageFramework.MediaPlanning.DataColumns.Day.ToString)

                    End If

                    If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.FlowChartMediaPlanOptions.PrintDate Then

                        _CurrentColumn = FlowChartEstimate.FlowChart.NumberOfLevels

                        _CurrentRow += 1

                        CreateDateHeaderRow(FlowChartEstimate, AdvantageFramework.MediaPlanning.DataColumns.Date.ToString)

                    End If

                    CreateEstimateFieldHeader(FlowChartEstimate)

                Else

                    CreateDateHeaderRow(FlowChartEstimate, String.Empty)

                    CreateEstimateFieldHeader(FlowChartEstimate)

                End If

            End If

        End Sub
        Private Sub CreateEstimateRowsDefault(FlowChartEstimate As FlowChartEstimate)

            'objects
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing
            Dim MediaPlanDetailFields As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailField) = Nothing
            Dim LastColumn As Integer = -1
            Dim LastDate As Date = Date.MinValue
            Dim Cell As Aspose.Cells.Cell = Nothing
            Dim Range As Aspose.Cells.Range = Nothing
            Dim Style As Aspose.Cells.Style = Nothing
            Dim CellStyle As CellStyle = Nothing
            Dim DefaultCellStyle As CellStyle = Nothing
            Dim PreviousCellStyle As CellStyle = Nothing
            Dim RowIndex As Integer = 0
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim DataValue As Double = 0
            Dim WeekStartDate As Date = Date.MinValue
            Dim WeekEndDate As Date = Date.MinValue
            Dim MonthStartDate As Date = Date.MinValue
            Dim MonthEndDate As Date = Date.MinValue
            Dim QuarterStartDate As Date = Date.MinValue
            Dim QuarterEndDate As Date = Date.MinValue
            Dim YearStartDate As Date = Date.MinValue
            Dim YearEndDate As Date = Date.MinValue
            Dim Color As Integer = 0
            Dim BackgroundColor As System.Drawing.Color = System.Drawing.Color.Empty
            Dim MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim Note As String = String.Empty
            Dim LastNote As String = String.Empty
            Dim EndDate As Date = Date.MinValue
            Dim CellData As CellData = Nothing
            Dim PreviousCellData As CellData = Nothing
            Dim IsHighestDateDataColumn As Boolean = True
            Dim FlowChartEstimateLevels As Generic.List(Of FlowChartEstimateLevel) = Nothing
            Dim GroupRow As FlowChartGroupData = Nothing
            Dim PrevGroupRow As FlowChartGroupData = Nothing
            Dim GroupRows As Generic.List(Of FlowChartGroupData) = Nothing
            Dim FinalGroupRows As Generic.List(Of FlowChartGroupData) = Nothing
            Dim IsNotTheSameGroupRow As Boolean = False
            Dim StartingExcelRowIndex As Integer = 0
            Dim ExcelRowIndex As Integer = 0
            Dim LastExcelRowIndex As Integer = 0
            Dim ExcelColumnIndex As Integer = 0
            Dim LineData As String = String.Empty
            Dim LastLineData As String = String.Empty
            Dim CustomLevelData As String = String.Empty
            Dim IsActualized As Boolean = False

            _CurrentColumn = 0

            If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.FlowChartMediaPlanOptions.FlowChartDateHeaderOption = FlowChartDateHeaderOptions.FromPlan Then

                MediaPlanDetailField = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailFields.Where(Function(Entity) Entity.Area = 1 AndAlso Entity.IsVisible = True).OrderBy(Function(Entity) Entity.AreaIndex).ToList.LastOrDefault

            ElseIf FlowChartEstimate.FlowChartMediaPlanEstimateOptions.FlowChartMediaPlanOptions.FlowChartDateHeaderOption = FlowChartDateHeaderOptions.ChooseLevels Then

                MediaPlanDetailField = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailFields.FirstOrDefault(Function(Entity) Entity.FieldID = FlowChartEstimate.FlowChart.HighestDateDataColumn.ToString)

            End If

            If MediaPlanDetailField IsNot Nothing Then

                If FlowChartEstimate.FlowChart.HighestDateDataColumn <> AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.MediaPlanning.DataColumns), MediaPlanDetailField.FieldID) Then

                    IsHighestDateDataColumn = False

                End If

            End If

            If FlowChartEstimate.MediaPlanEstimate.LevelsAndLinesDataTable Is Nothing Then

                FlowChartEstimate.MediaPlanEstimate.CreateLevelsAndLinesDataTable()

            End If

            If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.GroupByLevel = GroupByLevels.None Then

                For Each RowIndex In FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Select(Function(Entity) Entity.RowIndex).OrderBy(Function(RI) RI).Distinct.ToList

                    _CurrentRow += 1

                    CellStyle = New CellStyle With {.IsItalic = False, .IsBold = False, .Underline = False, .TextWrapped = True,
                                                        .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                        .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                        .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                        .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                        .BackgroundColor = FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FieldAreaColor}

                    _CurrentColumn = 0

                    For Each FlowChartEstimateLevel In FlowChartEstimate.FlowChartEstimateLevels.Where(Function(Entity) Entity.IsVisible = True).OrderBy(Function(Entity) Entity.OrderNumber).ToList

                        CustomLevelData = String.Empty

                        If FlowChartEstimateLevel.FlowChartEstimateCustomLevel = FlowChartEstimateCustomLevels.None Then

                            For Each FlowChartEstimateLevelLine In FlowChartEstimateLevel.FlowChartEstimateLevelLines.Where(Function(Entity) Entity.RowIndex = RowIndex).ToList

                                SetCell(_CurrentRow, _CurrentColumn, FlowChartEstimateLevelLine.Description, CellStyle)

                            Next

                        ElseIf FlowChartEstimateLevel.FlowChartEstimateCustomLevel = FlowChartEstimateCustomLevels.Package Then

                            CustomLevelData = FlowChartEstimate.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString) = RowIndex).Select(Function(DR) CStr(DR(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString))).FirstOrDefault

                            SetCell(_CurrentRow, _CurrentColumn, CustomLevelData, CellStyle)

                        ElseIf FlowChartEstimateLevel.FlowChartEstimateCustomLevel = FlowChartEstimateCustomLevels.AdSizes Then

                            CustomLevelData = FlowChartEstimate.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString) = RowIndex).Select(Function(DR) CStr(DR(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString))).FirstOrDefault

                            SetCell(_CurrentRow, _CurrentColumn, CustomLevelData, CellStyle)

                        ElseIf FlowChartEstimateLevel.FlowChartEstimateCustomLevel = FlowChartEstimateCustomLevels.DateRange Then

                            CustomLevelData = FlowChartEstimate.MediaPlanEstimate.GetDateRangeForRow(RowIndex)

                            SetCell(_CurrentRow, _CurrentColumn, CustomLevelData, CellStyle)

                        End If

                        _CurrentColumn += 1

                    Next

                    LastColumn = _CurrentColumn

                    For RC As Integer = _CurrentColumn To FlowChartEstimate.FlowChart.NumberOfLevels - 1

                        SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                        _CurrentColumn += 1

                    Next

                    If _CurrentColumn - LastColumn > 1 Then

                        Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                        Range.Merge()

                    End If

                    LastColumn = _CurrentColumn

                    If MediaPlanDetailField IsNot Nothing Then

                        If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString OrElse
                                MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Date.ToString Then

                            LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).Date

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                            If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                                If FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth Then

                                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).WeekStartDate

                                Else

                                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastWeekStartDate

                                End If

                            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                                LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).WeekStartDate

                            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                                LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastWeekStartDate

                            End If

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                                    MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                            If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                                If FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth Then

                                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).MonthStartDate

                                Else

                                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastMonthStartDate

                                End If

                            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                                LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).MonthStartDate

                            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                                LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastMonthStartDate

                            End If

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString Then

                            If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                                If FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth Then

                                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).QuarterStartDate

                                Else

                                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastQuarterStartDate

                                End If

                            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                                LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).QuarterStartDate

                            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                                LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastQuarterStartDate

                            End If

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString Then

                            If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                                If FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth Then

                                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).YearStartDate

                                Else

                                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastYearStartDate

                                End If

                            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                                LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).YearStartDate

                            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                                LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastYearStartDate

                            End If

                        End If

                        DefaultCellStyle = New CellStyle With {.IsItalic = False, .IsBold = False, .Underline = False,
                                                                   .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                                   .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                                   .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                                   .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                                   .BackgroundColor = System.Drawing.Color.Empty, .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center}

                        For Each FlowChartEstimateDate In FlowChartEstimate.FlowChart.FlowChartEstimateDates

                            PreviousCellStyle = If(CellStyle Is Nothing, DefaultCellStyle.Copy, CellStyle.Copy)
                            CellStyle = DefaultCellStyle.Copy

                            Color = 0
                            BackgroundColor = System.Drawing.Color.Empty
                            DataValue = 0
                            IsActualized = False
                            Note = String.Empty
                            Range = Nothing
                            EndDate = Date.MinValue
                            PreviousCellData = If(CellData IsNot Nothing, CellData.Copy, Nothing)

                            If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                                If FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth Then

                                    WeekStartDate = FlowChartEstimateDate.WeekStartDate
                                    WeekEndDate = FlowChartEstimateDate.WeekEndDate
                                    MonthStartDate = FlowChartEstimateDate.MonthStartDate
                                    MonthEndDate = FlowChartEstimateDate.MonthEndDate
                                    QuarterStartDate = FlowChartEstimateDate.QuarterStartDate
                                    QuarterEndDate = FlowChartEstimateDate.QuarterEndDate
                                    YearStartDate = FlowChartEstimateDate.YearStartDate
                                    YearEndDate = FlowChartEstimateDate.YearEndDate

                                Else

                                    WeekStartDate = FlowChartEstimateDate.BroadcastWeekStartDate
                                    WeekEndDate = FlowChartEstimateDate.BroadcastWeekEndDate
                                    MonthStartDate = FlowChartEstimateDate.BroadcastMonthStartDate
                                    MonthEndDate = FlowChartEstimateDate.BroadcastMonthEndDate
                                    QuarterStartDate = FlowChartEstimateDate.BroadcastQuarterStartDate
                                    QuarterEndDate = FlowChartEstimateDate.BroadcastQuarterEndDate
                                    YearStartDate = FlowChartEstimateDate.BroadcastYearStartDate
                                    YearEndDate = FlowChartEstimateDate.BroadcastYearEndDate

                                End If

                            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                                WeekStartDate = FlowChartEstimateDate.WeekStartDate
                                WeekEndDate = FlowChartEstimateDate.WeekEndDate
                                MonthStartDate = FlowChartEstimateDate.MonthStartDate
                                MonthEndDate = FlowChartEstimateDate.MonthEndDate
                                QuarterStartDate = FlowChartEstimateDate.QuarterStartDate
                                QuarterEndDate = FlowChartEstimateDate.QuarterEndDate
                                YearStartDate = FlowChartEstimateDate.YearStartDate
                                YearEndDate = FlowChartEstimateDate.YearEndDate

                            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                                WeekStartDate = FlowChartEstimateDate.BroadcastWeekStartDate
                                WeekEndDate = FlowChartEstimateDate.BroadcastWeekEndDate
                                MonthStartDate = FlowChartEstimateDate.BroadcastMonthStartDate
                                MonthEndDate = FlowChartEstimateDate.BroadcastMonthEndDate
                                QuarterStartDate = FlowChartEstimateDate.BroadcastQuarterStartDate
                                QuarterEndDate = FlowChartEstimateDate.BroadcastQuarterEndDate
                                YearStartDate = FlowChartEstimateDate.BroadcastYearStartDate
                                YearEndDate = FlowChartEstimateDate.BroadcastYearEndDate

                            End If

                            If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString OrElse
                                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Date.ToString Then

                                MediaPlanDetailLevelLineDatas = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.StartDate = FlowChartEstimateDate.Date).ToList

                                If MediaPlanDetailLevelLineDatas.Count > 0 Then

                                    Note = MediaPlanDetailLevelLineDatas.Where(Function(Entity) String.IsNullOrEmpty(Entity.Note) = False).Select(Function(Entity) Entity.Note).Max
                                    DataValue = GetDataValue(FlowChartEstimate, MediaPlanDetailLevelLineDatas)
                                    IsActualized = MediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.IsActualized = True)
                                    Color = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Color).Max
                                    EndDate = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.EndDate).Max

                                    CellData = New CellData(DataValue, Color, BackgroundColor, Note, FlowChartEstimateDate.Date, EndDate, IsActualized)

                                ElseIf CellData IsNot Nothing Then

                                    If FlowChartEstimateDate.Date >= CellData.StartDate AndAlso FlowChartEstimateDate.Date <= CellData.EndDate Then

                                        'Note = CellData.Note
                                        'DataValue = CellData.DataValue
                                        Color = CellData.Color
                                        EndDate = CellData.EndDate

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor
                                        CellStyle.IsItalic = CellData.IsActualized

                                        CellData = New CellData(DataValue, Color, BackgroundColor, Note, FlowChartEstimateDate.Date, EndDate, CellStyle.IsItalic)

                                    Else

                                        CellData = Nothing

                                    End If

                                End If

                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) OrElse
                                        DataValue <> 0 OrElse FlowChartEstimate.FlowChartMediaPlanEstimateOptions.BlockingChart = True Then

                                    CellStyle.IsItalic = If(CellData IsNot Nothing, CellData.IsActualized, False)

                                    If Color <> 0 Then

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor

                                    End If

                                End If

                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) Then

                                    CellStyle.CellValueType = CellValueType.Text

                                    SetCell(_CurrentRow, _CurrentColumn, Note, CellStyle)

                                ElseIf DataValue <> 0 Then

                                    SetCellValueType(FlowChartEstimate, CellStyle)

                                    SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                                Else

                                    SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                                End If

                                LastDate = FlowChartEstimateDate.Date

                            ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                                MediaPlanDetailLevelLineDatas = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = RowIndex AndAlso
                                                                                                                                                             Entity.StartDate >= WeekStartDate AndAlso
                                                                                                                                                             Entity.StartDate <= WeekEndDate).ToList

                                If MediaPlanDetailLevelLineDatas.Count > 0 Then

                                    Note = MediaPlanDetailLevelLineDatas.Where(Function(Entity) String.IsNullOrEmpty(Entity.Note) = False).Select(Function(Entity) Entity.Note).Max
                                    DataValue = GetDataValue(FlowChartEstimate, MediaPlanDetailLevelLineDatas)
                                    IsActualized = MediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.IsActualized = True)
                                    Color = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Color).Max
                                    EndDate = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.EndDate).Max

                                    CellData = New CellData(DataValue, Color, BackgroundColor, Note, WeekStartDate, EndDate, IsActualized)

                                ElseIf CellData IsNot Nothing Then

                                    If (WeekStartDate >= CellData.StartDate AndAlso WeekStartDate <= CellData.EndDate) OrElse
                                                (WeekEndDate >= CellData.StartDate AndAlso WeekEndDate <= CellData.EndDate) Then

                                        'Note = CellData.Note
                                        'DataValue = CellData.DataValue
                                        Color = CellData.Color
                                        EndDate = CellData.EndDate

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor
                                        CellStyle.IsItalic = CellData.IsActualized

                                        CellData = New CellData(DataValue, Color, BackgroundColor, Note, FlowChartEstimateDate.Date, EndDate, CellStyle.IsItalic)

                                    Else

                                        CellData = Nothing

                                    End If

                                End If


                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) OrElse
                                        DataValue <> 0 OrElse FlowChartEstimate.FlowChartMediaPlanEstimateOptions.BlockingChart = True Then

                                    CellStyle.IsItalic = If(CellData IsNot Nothing, CellData.IsActualized, False)

                                    If Color <> 0 Then

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor

                                    End If

                                End If


                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) Then

                                    CellStyle.CellValueType = CellValueType.Text

                                    SetCell(_CurrentRow, _CurrentColumn, Note, CellStyle)

                                ElseIf DataValue <> 0 Then

                                    SetCellValueType(FlowChartEstimate, CellStyle)

                                    SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                                Else

                                    SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                                End If

                                If LastDate <> WeekStartDate Then

                                    If (_CurrentColumn - LastColumn) > 1 Then

                                        Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                                    End If

                                    If Range IsNot Nothing Then

                                        If PreviousCellData IsNot Nothing AndAlso FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(PreviousCellData.Note) = False Then

                                            PreviousCellStyle.CellValueType = CellValueType.Text

                                            SetRange(Range, PreviousCellData.Note, PreviousCellStyle)

                                        ElseIf PreviousCellData IsNot Nothing AndAlso PreviousCellData.DataValue <> 0 Then

                                            SetCellValueType(FlowChartEstimate, PreviousCellStyle)

                                            SetRange(Range, PreviousCellData.DataValue, PreviousCellStyle)

                                            Range.Merge()

                                        Else

                                            SetRange(Range, String.Empty, DefaultCellStyle)

                                            If IsHighestDateDataColumn = False Then

                                                Range.Merge()

                                            End If

                                        End If

                                    End If

                                    LastColumn = _CurrentColumn
                                    LastDate = WeekStartDate

                                End If

                            ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                                MediaPlanDetailLevelLineDatas = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = RowIndex AndAlso
                                                                                                                                                             Entity.StartDate >= MonthStartDate AndAlso
                                                                                                                                                             Entity.StartDate <= MonthEndDate).ToList

                                If MediaPlanDetailLevelLineDatas.Count > 0 Then

                                    Note = MediaPlanDetailLevelLineDatas.Where(Function(Entity) String.IsNullOrEmpty(Entity.Note) = False).Select(Function(Entity) Entity.Note).Max
                                    DataValue = GetDataValue(FlowChartEstimate, MediaPlanDetailLevelLineDatas)
                                    IsActualized = MediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.IsActualized = True)
                                    Color = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Color).Max
                                    EndDate = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.EndDate).Max

                                    CellData = New CellData(DataValue, Color, BackgroundColor, Note, MonthStartDate, EndDate, IsActualized)

                                ElseIf CellData IsNot Nothing Then

                                    If (MonthStartDate >= CellData.StartDate AndAlso MonthStartDate <= CellData.EndDate) OrElse
                                                (MonthEndDate >= CellData.StartDate AndAlso MonthEndDate <= CellData.EndDate) Then

                                        'Note = CellData.Note
                                        'DataValue = CellData.DataValue
                                        Color = CellData.Color
                                        EndDate = CellData.EndDate

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor
                                        CellStyle.IsItalic = CellData.IsActualized

                                        CellData = New CellData(DataValue, Color, BackgroundColor, Note, FlowChartEstimateDate.Date, EndDate, CellStyle.IsItalic)

                                    Else

                                        CellData = Nothing

                                    End If

                                End If


                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) OrElse
                                        DataValue <> 0 OrElse FlowChartEstimate.FlowChartMediaPlanEstimateOptions.BlockingChart = True Then

                                    CellStyle.IsItalic = If(CellData IsNot Nothing, CellData.IsActualized, False)

                                    If Color <> 0 Then

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor

                                    End If

                                End If


                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) Then

                                    CellStyle.CellValueType = CellValueType.Text

                                    SetCell(_CurrentRow, _CurrentColumn, Note, CellStyle)

                                ElseIf DataValue <> 0 Then

                                    SetCellValueType(FlowChartEstimate, CellStyle)

                                    SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                                Else

                                    SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                                End If

                                If LastDate <> MonthStartDate Then

                                    If (_CurrentColumn - LastColumn) > 1 Then

                                        Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                                    End If

                                    If Range IsNot Nothing Then

                                        If PreviousCellData IsNot Nothing AndAlso FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(PreviousCellData.Note) = False Then

                                            PreviousCellStyle.CellValueType = CellValueType.Text

                                            SetRange(Range, PreviousCellData.Note, PreviousCellStyle)

                                        ElseIf PreviousCellData IsNot Nothing AndAlso PreviousCellData.DataValue <> 0 Then

                                            SetCellValueType(FlowChartEstimate, PreviousCellStyle)

                                            SetRange(Range, PreviousCellData.DataValue, PreviousCellStyle)

                                            Range.Merge()

                                        Else

                                            SetRange(Range, String.Empty, DefaultCellStyle)

                                            If IsHighestDateDataColumn = False Then

                                                Range.Merge()

                                            End If

                                        End If

                                    End If

                                    LastColumn = _CurrentColumn
                                    LastDate = MonthStartDate

                                End If

                            ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString Then

                                MediaPlanDetailLevelLineDatas = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = RowIndex AndAlso
                                                                                                                                                             Entity.StartDate >= QuarterStartDate AndAlso
                                                                                                                                                             Entity.StartDate <= QuarterEndDate).ToList

                                If MediaPlanDetailLevelLineDatas.Count > 0 Then

                                    Note = MediaPlanDetailLevelLineDatas.Where(Function(Entity) String.IsNullOrEmpty(Entity.Note) = False).Select(Function(Entity) Entity.Note).Max
                                    DataValue = GetDataValue(FlowChartEstimate, MediaPlanDetailLevelLineDatas)
                                    IsActualized = MediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.IsActualized = True)
                                    Color = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Color).Max
                                    EndDate = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.EndDate).Max

                                    CellData = New CellData(DataValue, Color, BackgroundColor, Note, QuarterStartDate, EndDate, IsActualized)

                                ElseIf CellData IsNot Nothing Then

                                    If (QuarterStartDate >= CellData.StartDate AndAlso QuarterStartDate <= CellData.EndDate) OrElse
                                                (QuarterEndDate >= CellData.StartDate AndAlso QuarterEndDate <= CellData.EndDate) Then

                                        'Note = CellData.Note
                                        'DataValue = CellData.DataValue
                                        Color = CellData.Color
                                        EndDate = CellData.EndDate

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor
                                        CellStyle.IsItalic = CellData.IsActualized

                                        CellData = New CellData(DataValue, Color, BackgroundColor, Note, FlowChartEstimateDate.Date, EndDate, CellStyle.IsItalic)

                                    Else

                                        CellData = Nothing

                                    End If

                                End If


                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) OrElse
                                        DataValue <> 0 OrElse FlowChartEstimate.FlowChartMediaPlanEstimateOptions.BlockingChart = True Then

                                    CellStyle.IsItalic = If(CellData IsNot Nothing, CellData.IsActualized, False)

                                    If Color <> 0 Then

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor

                                    End If

                                End If


                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) Then

                                    CellStyle.CellValueType = CellValueType.Text

                                    SetCell(_CurrentRow, _CurrentColumn, Note, CellStyle)

                                ElseIf DataValue <> 0 Then

                                    SetCellValueType(FlowChartEstimate, CellStyle)

                                    SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                                Else

                                    SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                                End If

                                If LastDate <> QuarterStartDate Then

                                    If (_CurrentColumn - LastColumn) > 1 Then

                                        Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                                    End If

                                    If Range IsNot Nothing Then

                                        If PreviousCellData IsNot Nothing AndAlso FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(PreviousCellData.Note) = False Then

                                            PreviousCellStyle.CellValueType = CellValueType.Text

                                            SetRange(Range, PreviousCellData.Note, PreviousCellStyle)

                                        ElseIf PreviousCellData IsNot Nothing AndAlso PreviousCellData.DataValue <> 0 Then

                                            SetCellValueType(FlowChartEstimate, PreviousCellStyle)

                                            SetRange(Range, PreviousCellData.DataValue, PreviousCellStyle)

                                            Range.Merge()

                                        Else

                                            SetRange(Range, String.Empty, DefaultCellStyle)

                                            If IsHighestDateDataColumn = False Then

                                                Range.Merge()

                                            End If

                                        End If

                                    End If

                                    LastColumn = _CurrentColumn
                                    LastDate = QuarterStartDate

                                End If

                            ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString Then

                                MediaPlanDetailLevelLineDatas = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = RowIndex AndAlso
                                                                                                                                                             Entity.StartDate >= YearStartDate AndAlso
                                                                                                                                                             Entity.StartDate <= YearEndDate).ToList

                                If MediaPlanDetailLevelLineDatas.Count > 0 Then

                                    Note = MediaPlanDetailLevelLineDatas.Where(Function(Entity) String.IsNullOrEmpty(Entity.Note) = False).Select(Function(Entity) Entity.Note).Max
                                    DataValue = GetDataValue(FlowChartEstimate, MediaPlanDetailLevelLineDatas)
                                    IsActualized = MediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.IsActualized = True)
                                    Color = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Color).Max
                                    EndDate = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.EndDate).Max

                                    CellData = New CellData(DataValue, Color, BackgroundColor, Note, YearStartDate, EndDate, IsActualized)

                                ElseIf CellData IsNot Nothing Then

                                    If (YearStartDate >= CellData.StartDate AndAlso YearStartDate <= CellData.EndDate) OrElse
                                                (YearEndDate >= CellData.StartDate AndAlso YearEndDate <= CellData.EndDate) Then

                                        'Note = CellData.Note
                                        'DataValue = CellData.DataValue
                                        Color = CellData.Color
                                        EndDate = CellData.EndDate

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor
                                        CellStyle.IsItalic = CellData.IsActualized

                                        CellData = New CellData(DataValue, Color, BackgroundColor, Note, FlowChartEstimateDate.Date, EndDate, CellStyle.IsItalic)

                                    Else

                                        CellData = Nothing

                                    End If

                                End If


                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) OrElse
                                        DataValue <> 0 OrElse FlowChartEstimate.FlowChartMediaPlanEstimateOptions.BlockingChart = True Then

                                    CellStyle.IsItalic = If(CellData IsNot Nothing, CellData.IsActualized, False)

                                    If Color <> 0 Then

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor

                                    End If

                                End If


                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) Then

                                    CellStyle.CellValueType = CellValueType.Text

                                    SetCell(_CurrentRow, _CurrentColumn, Note, CellStyle)

                                ElseIf DataValue <> 0 Then

                                    SetCellValueType(FlowChartEstimate, CellStyle)

                                    SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                                Else

                                    SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                                End If

                                If LastDate <> YearStartDate Then

                                    If (_CurrentColumn - LastColumn) > 1 Then

                                        Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                                    End If

                                    If Range IsNot Nothing Then

                                        If PreviousCellData IsNot Nothing AndAlso FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(PreviousCellData.Note) = False Then

                                            PreviousCellStyle.CellValueType = CellValueType.Text

                                            SetRange(Range, PreviousCellData.Note, PreviousCellStyle)

                                        ElseIf PreviousCellData IsNot Nothing AndAlso PreviousCellData.DataValue <> 0 Then

                                            SetCellValueType(FlowChartEstimate, PreviousCellStyle)

                                            SetRange(Range, PreviousCellData.DataValue, PreviousCellStyle)

                                            Range.Merge()

                                        Else

                                            SetRange(Range, String.Empty, DefaultCellStyle)

                                            If IsHighestDateDataColumn = False Then

                                                Range.Merge()

                                            End If

                                        End If

                                    End If

                                    LastColumn = _CurrentColumn
                                    LastDate = YearStartDate

                                End If

                            End If

                            _CurrentColumn += 1

                        Next

                        If (MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString OrElse
                                    MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                                    MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString OrElse
                                    MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString OrElse
                                    MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString) AndAlso
                               (_CurrentColumn - LastColumn) > 1 Then

                            If DataValue <> 0 OrElse IsHighestDateDataColumn = False Then

                                Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                                If DataValue <> 0 Then

                                    SetCellValueType(FlowChartEstimate, CellStyle)

                                End If

                                SetRange(Range, CellStyle)

                                Range.Merge()

                            End If

                        End If

                        'loop make through and merge notes
                        _CurrentColumn = FlowChartEstimate.FlowChart.NumberOfLevels
                        LastColumn = _CurrentColumn

                        LastNote = If(_Worksheet.Cells(_CurrentRow, _CurrentColumn).Type = Aspose.Cells.CellValueType.IsString, _Worksheet.Cells(_CurrentRow, _CurrentColumn).StringValue, String.Empty)

                        For Each FlowChartEstimateDate In FlowChartEstimate.FlowChart.FlowChartEstimateDates

                            CellStyle = New CellStyle With {.IsItalic = False, .IsBold = False, .Underline = False,
                                                                .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                                .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                                .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                                .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                                .BackgroundColor = System.Drawing.Color.Empty, .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center}

                            If _CurrentColumn > FlowChartEstimate.FlowChart.NumberOfLevels Then

                                Note = String.Empty

                                Note = If(_Worksheet.Cells(_CurrentRow, _CurrentColumn).Type = Aspose.Cells.CellValueType.IsString, _Worksheet.Cells(_CurrentRow, _CurrentColumn).StringValue, String.Empty)

                                If String.IsNullOrEmpty(Note) = False OrElse
                                            (String.IsNullOrEmpty(Note) AndAlso String.IsNullOrEmpty(LastNote) = False) Then

                                    If Note <> LastNote AndAlso String.IsNullOrEmpty(LastNote) = False Then

                                        If (_CurrentColumn - LastColumn) > 1 Then

                                            Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                                            SetRange(Range, CellStyle)

                                            Range.Merge()

                                        End If

                                        LastNote = String.Empty

                                    ElseIf String.IsNullOrEmpty(Note) = False AndAlso String.IsNullOrEmpty(LastNote) Then

                                        LastNote = Note
                                        LastColumn = _CurrentColumn

                                    End If

                                End If

                            End If

                            _CurrentColumn += 1

                        Next

                    Else

                        DefaultCellStyle = New CellStyle With {.IsItalic = False, .IsBold = False, .Underline = False,
                                                               .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                               .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                               .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                               .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                               .BackgroundColor = System.Drawing.Color.Empty, .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center}

                        MediaPlanDetailLevelLineDatas = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = RowIndex).ToList
                        CellStyle = DefaultCellStyle.Copy

                        If MediaPlanDetailLevelLineDatas.Count > 0 Then

                            Note = MediaPlanDetailLevelLineDatas.Where(Function(Entity) String.IsNullOrEmpty(Entity.Note) = False).Select(Function(Entity) Entity.Note).Max
                            DataValue = GetDataValue(FlowChartEstimate, MediaPlanDetailLevelLineDatas)
                            IsActualized = MediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.IsActualized = True)
                            Color = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Color).Max
                            EndDate = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.EndDate).Max

                        End If


                        If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) OrElse
                                        DataValue <> 0 OrElse FlowChartEstimate.FlowChartMediaPlanEstimateOptions.BlockingChart = True Then

                            CellStyle.IsItalic = If(CellData IsNot Nothing, CellData.IsActualized, False)

                            If Color <> 0 Then

                                BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                CellStyle.BackgroundColor = BackgroundColor

                            End If

                        End If


                        If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) Then

                            CellStyle.CellValueType = CellValueType.Text

                            SetCell(_CurrentRow, _CurrentColumn, Note, CellStyle)

                        ElseIf DataValue <> 0 Then

                            SetCellValueType(FlowChartEstimate, CellStyle)

                            SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                        Else

                            SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                        End If

                        _CurrentColumn += 1

                    End If

                    CreateRowGrandTotalsColumns(FlowChartEstimate, New Generic.List(Of Integer)({RowIndex}))

                Next

            Else

                FlowChartEstimateLevels = FlowChartEstimate.FlowChartEstimateLevels.Where(Function(Entity) Entity.IsVisible = True AndAlso Entity.OrderNumber <= FlowChartEstimate.FlowChartMediaPlanEstimateOptions.GroupByLevel - 1).OrderBy(Function(Entity) Entity.OrderNumber).ToList

                If FlowChartEstimateLevels IsNot Nothing Then

                    GroupRows = New Generic.List(Of FlowChartGroupData)

                    For Each RowIndex In FlowChartEstimateLevels.SelectMany(Function(Entity) Entity.FlowChartEstimateLevelLines).Select(Function(Entity) Entity.RowIndex).OrderBy(Function(RI) RI).Distinct.ToList

                        GroupRow = New FlowChartGroupData

                        For Each FlowChartEstimateLevel In FlowChartEstimateLevels

                            CustomLevelData = String.Empty

                            If FlowChartEstimateLevel.FlowChartEstimateCustomLevel = FlowChartEstimateCustomLevels.None Then

                                For Each FlowChartEstimateLevelLine In FlowChartEstimateLevel.FlowChartEstimateLevelLines.Where(Function(Entity) Entity.RowIndex = RowIndex).ToList

                                    GroupRow.LevelData.Add(FlowChartEstimateLevelLine.Description)

                                Next

                            ElseIf FlowChartEstimateLevel.FlowChartEstimateCustomLevel = FlowChartEstimateCustomLevels.Package Then

                                CustomLevelData = FlowChartEstimate.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString) = RowIndex).Select(Function(DR) CStr(DR(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString))).FirstOrDefault

                                GroupRow.LevelData.Add(CustomLevelData)

                            ElseIf FlowChartEstimateLevel.FlowChartEstimateCustomLevel = FlowChartEstimateCustomLevels.AdSizes Then

                                CustomLevelData = FlowChartEstimate.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString) = RowIndex).Select(Function(DR) CStr(DR(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString))).FirstOrDefault

                                GroupRow.LevelData.Add(CustomLevelData)

                            ElseIf FlowChartEstimateLevel.FlowChartEstimateCustomLevel = FlowChartEstimateCustomLevels.DateRange Then

                                CustomLevelData = FlowChartEstimate.MediaPlanEstimate.GetDateRangeForRow(RowIndex)

                                GroupRow.LevelData.Add(CustomLevelData)

                            End If

                        Next

                        GroupRow.RowIndexes.Add(RowIndex)

                        GroupRows.Add(GroupRow)

                    Next

                    FinalGroupRows = New Generic.List(Of FlowChartGroupData)

                    For Each GroupRow In GroupRows

                        If FinalGroupRows.Count = 0 Then

                            FinalGroupRows.Add(GroupRow)

                            PrevGroupRow = GroupRow

                        Else

                            IsNotTheSameGroupRow = Not GroupRow.LevelData.SequenceEqual(PrevGroupRow.LevelData)

                            If IsNotTheSameGroupRow Then

                                FinalGroupRows.Add(GroupRow)

                                PrevGroupRow = GroupRow

                            Else

                                PrevGroupRow.RowIndexes.AddRange(GroupRow.RowIndexes)

                            End If

                        End If

                    Next

                    StartingExcelRowIndex = _CurrentRow + 1

                    For Each GroupRow In FinalGroupRows

                        CellStyle = New CellStyle With {.IsItalic = False, .IsBold = False, .Underline = False, .TextWrapped = True,
                                                        .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                        .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                        .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                        .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                        .BackgroundColor = FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FieldAreaColor}

                        _CurrentColumn = 0
                        _CurrentRow += 1

                        For Each LevelData In GroupRow.LevelData

                            SetCell(_CurrentRow, _CurrentColumn, LevelData, CellStyle)

                            _CurrentColumn += 1

                        Next

                        LastColumn = _CurrentColumn

                        For RC As Integer = _CurrentColumn To FlowChartEstimate.FlowChart.NumberOfLevels - 1

                            SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                            _CurrentColumn += 1

                        Next

                        If _CurrentColumn - LastColumn > 1 Then

                            Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                            Range.Merge()

                        End If

                        LastColumn = _CurrentColumn

                        LastDate = GetLastDate(FlowChartEstimate, MediaPlanDetailField)

                        DefaultCellStyle = New CellStyle With {.IsItalic = False, .IsBold = False, .Underline = False,
                                                               .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                               .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                               .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                               .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                               .BackgroundColor = System.Drawing.Color.Empty, .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center}

                        For Each FlowChartEstimateDate In FlowChartEstimate.FlowChart.FlowChartEstimateDates

                            PreviousCellStyle = If(CellStyle Is Nothing, DefaultCellStyle.Copy, CellStyle.Copy)
                            CellStyle = DefaultCellStyle.Copy

                            Color = 0
                            BackgroundColor = System.Drawing.Color.Empty
                            DataValue = 0
                            IsActualized = False
                            Note = String.Empty
                            Range = Nothing
                            EndDate = Date.MinValue
                            PreviousCellData = If(CellData IsNot Nothing, CellData.Copy, Nothing)

                            If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                                If FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth Then

                                    WeekStartDate = FlowChartEstimateDate.WeekStartDate
                                    WeekEndDate = FlowChartEstimateDate.WeekEndDate
                                    MonthStartDate = FlowChartEstimateDate.MonthStartDate
                                    MonthEndDate = FlowChartEstimateDate.MonthEndDate
                                    QuarterStartDate = FlowChartEstimateDate.QuarterStartDate
                                    QuarterEndDate = FlowChartEstimateDate.QuarterEndDate
                                    YearStartDate = FlowChartEstimateDate.YearStartDate
                                    YearEndDate = FlowChartEstimateDate.YearEndDate

                                Else

                                    WeekStartDate = FlowChartEstimateDate.BroadcastWeekStartDate
                                    WeekEndDate = FlowChartEstimateDate.BroadcastWeekEndDate
                                    MonthStartDate = FlowChartEstimateDate.BroadcastMonthStartDate
                                    MonthEndDate = FlowChartEstimateDate.BroadcastMonthEndDate
                                    QuarterStartDate = FlowChartEstimateDate.BroadcastQuarterStartDate
                                    QuarterEndDate = FlowChartEstimateDate.BroadcastQuarterEndDate
                                    YearStartDate = FlowChartEstimateDate.BroadcastYearStartDate
                                    YearEndDate = FlowChartEstimateDate.BroadcastYearEndDate

                                End If

                            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                                WeekStartDate = FlowChartEstimateDate.WeekStartDate
                                WeekEndDate = FlowChartEstimateDate.WeekEndDate
                                MonthStartDate = FlowChartEstimateDate.MonthStartDate
                                MonthEndDate = FlowChartEstimateDate.MonthEndDate
                                QuarterStartDate = FlowChartEstimateDate.QuarterStartDate
                                QuarterEndDate = FlowChartEstimateDate.QuarterEndDate
                                YearStartDate = FlowChartEstimateDate.YearStartDate
                                YearEndDate = FlowChartEstimateDate.YearEndDate

                            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                                WeekStartDate = FlowChartEstimateDate.BroadcastWeekStartDate
                                WeekEndDate = FlowChartEstimateDate.BroadcastWeekEndDate
                                MonthStartDate = FlowChartEstimateDate.BroadcastMonthStartDate
                                MonthEndDate = FlowChartEstimateDate.BroadcastMonthEndDate
                                QuarterStartDate = FlowChartEstimateDate.BroadcastQuarterStartDate
                                QuarterEndDate = FlowChartEstimateDate.BroadcastQuarterEndDate
                                YearStartDate = FlowChartEstimateDate.BroadcastYearStartDate
                                YearEndDate = FlowChartEstimateDate.BroadcastYearEndDate

                            End If

                            If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString OrElse
                                    MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Date.ToString Then

                                MediaPlanDetailLevelLineDatas = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) GroupRow.RowIndexes.Contains(Entity.RowIndex) AndAlso
                                                                                                                                                         Entity.StartDate = FlowChartEstimateDate.Date).ToList

                                If MediaPlanDetailLevelLineDatas.Count > 0 Then

                                    Note = MediaPlanDetailLevelLineDatas.Where(Function(Entity) String.IsNullOrEmpty(Entity.Note) = False).Select(Function(Entity) Entity.Note).Max
                                    DataValue = GetDataValue(FlowChartEstimate, MediaPlanDetailLevelLineDatas)
                                    IsActualized = MediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.IsActualized = True)
                                    Color = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Color).Max
                                    EndDate = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.EndDate).Max

                                    CellData = New CellData(DataValue, Color, BackgroundColor, Note, FlowChartEstimateDate.Date, EndDate, IsActualized)

                                ElseIf CellData IsNot Nothing Then

                                    If FlowChartEstimateDate.Date >= CellData.StartDate AndAlso FlowChartEstimateDate.Date <= CellData.EndDate Then

                                        'Note = CellData.Note
                                        'DataValue = CellData.DataValue
                                        Color = CellData.Color

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor
                                        CellStyle.IsItalic = CellData.IsActualized

                                        CellData = New CellData(DataValue, Color, BackgroundColor, Note, FlowChartEstimateDate.Date, EndDate, CellStyle.IsItalic)

                                    Else

                                        CellData = Nothing

                                    End If

                                End If


                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) OrElse
                                        DataValue <> 0 OrElse FlowChartEstimate.FlowChartMediaPlanEstimateOptions.BlockingChart = True Then

                                    CellStyle.IsItalic = If(CellData IsNot Nothing, CellData.IsActualized, False)

                                    If Color <> 0 Then

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor

                                    End If

                                End If


                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) Then

                                    CellStyle.CellValueType = CellValueType.Text

                                    SetCell(_CurrentRow, _CurrentColumn, Note, CellStyle)

                                ElseIf DataValue <> 0 Then

                                    SetCellValueType(FlowChartEstimate, CellStyle)

                                    SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                                Else

                                    SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                                End If

                                LastDate = FlowChartEstimateDate.Date

                            ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                                MediaPlanDetailLevelLineDatas = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) GroupRow.RowIndexes.Contains(Entity.RowIndex) AndAlso
                                                                                                                                                         Entity.StartDate >= WeekStartDate AndAlso
                                                                                                                                                         Entity.StartDate <= WeekEndDate).ToList

                                If MediaPlanDetailLevelLineDatas.Count > 0 Then

                                    Note = MediaPlanDetailLevelLineDatas.Where(Function(Entity) String.IsNullOrEmpty(Entity.Note) = False).Select(Function(Entity) Entity.Note).Max
                                    DataValue = GetDataValue(FlowChartEstimate, MediaPlanDetailLevelLineDatas)
                                    IsActualized = MediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.IsActualized = True)
                                    Color = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Color).Max
                                    EndDate = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.EndDate).Max

                                    CellData = New CellData(DataValue, Color, BackgroundColor, Note, WeekStartDate, EndDate, IsActualized)

                                ElseIf CellData IsNot Nothing Then

                                    If (WeekStartDate >= CellData.StartDate AndAlso WeekStartDate <= CellData.EndDate) OrElse
                                            (WeekEndDate >= CellData.StartDate AndAlso WeekEndDate <= CellData.EndDate) Then

                                        'Note = CellData.Note
                                        'DataValue = CellData.DataValue
                                        Color = CellData.Color

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor
                                        CellStyle.IsItalic = CellData.IsActualized

                                        CellData = New CellData(DataValue, Color, BackgroundColor, Note, FlowChartEstimateDate.Date, EndDate, CellStyle.IsItalic)

                                    Else

                                        CellData = Nothing

                                    End If

                                End If


                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) OrElse
                                        DataValue <> 0 OrElse FlowChartEstimate.FlowChartMediaPlanEstimateOptions.BlockingChart = True Then

                                    CellStyle.IsItalic = If(CellData IsNot Nothing, CellData.IsActualized, False)

                                    If Color <> 0 Then

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor

                                    End If

                                End If


                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) Then

                                    CellStyle.CellValueType = CellValueType.Text

                                    SetCell(_CurrentRow, _CurrentColumn, Note, CellStyle)

                                ElseIf DataValue <> 0 Then

                                    SetCellValueType(FlowChartEstimate, CellStyle)

                                    SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                                Else

                                    SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                                End If

                                If LastDate <> WeekStartDate Then

                                    If (_CurrentColumn - LastColumn) > 1 Then

                                        Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                                    End If

                                    If Range IsNot Nothing Then

                                        If PreviousCellData IsNot Nothing AndAlso FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(PreviousCellData.Note) = False Then

                                            PreviousCellStyle.CellValueType = CellValueType.Text

                                            SetRange(Range, PreviousCellData.Note, PreviousCellStyle)

                                        ElseIf PreviousCellData IsNot Nothing AndAlso PreviousCellData.DataValue <> 0 Then

                                            SetCellValueType(FlowChartEstimate, PreviousCellStyle)

                                            SetRange(Range, PreviousCellData.DataValue, PreviousCellStyle)

                                            Range.Merge()

                                        Else

                                            SetRange(Range, String.Empty, DefaultCellStyle)

                                            If IsHighestDateDataColumn = False Then

                                                Range.Merge()

                                            End If

                                        End If

                                    End If

                                    LastColumn = _CurrentColumn
                                    LastDate = WeekStartDate

                                End If

                            ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                                    MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                                MediaPlanDetailLevelLineDatas = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) GroupRow.RowIndexes.Contains(Entity.RowIndex) AndAlso
                                                                                                                                                         Entity.StartDate >= MonthStartDate AndAlso
                                                                                                                                                         Entity.StartDate <= MonthEndDate).ToList

                                If MediaPlanDetailLevelLineDatas.Count > 0 Then

                                    Note = MediaPlanDetailLevelLineDatas.Where(Function(Entity) String.IsNullOrEmpty(Entity.Note) = False).Select(Function(Entity) Entity.Note).Max
                                    DataValue = GetDataValue(FlowChartEstimate, MediaPlanDetailLevelLineDatas)
                                    IsActualized = MediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.IsActualized = True)
                                    Color = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Color).Max
                                    EndDate = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.EndDate).Max

                                    CellData = New CellData(DataValue, Color, BackgroundColor, Note, MonthStartDate, EndDate, IsActualized)

                                ElseIf CellData IsNot Nothing Then

                                    If (MonthStartDate >= CellData.StartDate AndAlso MonthStartDate <= CellData.EndDate) OrElse
                                            (MonthEndDate >= CellData.StartDate AndAlso MonthEndDate <= CellData.EndDate) Then

                                        'Note = CellData.Note
                                        'DataValue = CellData.DataValue
                                        Color = CellData.Color

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor
                                        CellStyle.IsItalic = CellData.IsActualized

                                        CellData = New CellData(DataValue, Color, BackgroundColor, Note, FlowChartEstimateDate.Date, EndDate, CellStyle.IsItalic)

                                    Else

                                        CellData = Nothing

                                    End If

                                End If


                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) OrElse
                                        DataValue <> 0 OrElse FlowChartEstimate.FlowChartMediaPlanEstimateOptions.BlockingChart = True Then

                                    CellStyle.IsItalic = If(CellData IsNot Nothing, CellData.IsActualized, False)

                                    If Color <> 0 Then

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor

                                    End If

                                End If


                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) Then

                                    CellStyle.CellValueType = CellValueType.Text

                                    SetCell(_CurrentRow, _CurrentColumn, Note, CellStyle)

                                ElseIf DataValue <> 0 Then

                                    SetCellValueType(FlowChartEstimate, CellStyle)

                                    SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                                Else

                                    SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                                End If

                                If LastDate <> MonthStartDate Then

                                    If (_CurrentColumn - LastColumn) > 1 Then

                                        Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                                    End If

                                    If Range IsNot Nothing Then

                                        If PreviousCellData IsNot Nothing AndAlso FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(PreviousCellData.Note) = False Then

                                            PreviousCellStyle.CellValueType = CellValueType.Text

                                            SetRange(Range, PreviousCellData.Note, PreviousCellStyle)

                                        ElseIf PreviousCellData IsNot Nothing AndAlso PreviousCellData.DataValue <> 0 Then

                                            SetCellValueType(FlowChartEstimate, PreviousCellStyle)

                                            SetRange(Range, PreviousCellData.DataValue, PreviousCellStyle)

                                            Range.Merge()

                                        Else

                                            SetRange(Range, String.Empty, DefaultCellStyle)

                                            If IsHighestDateDataColumn = False Then

                                                Range.Merge()

                                            End If

                                        End If

                                    End If

                                    LastColumn = _CurrentColumn
                                    LastDate = MonthStartDate

                                End If

                            ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString Then

                                MediaPlanDetailLevelLineDatas = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) GroupRow.RowIndexes.Contains(Entity.RowIndex) AndAlso
                                                                                                                                                         Entity.StartDate >= QuarterStartDate AndAlso
                                                                                                                                                         Entity.StartDate <= QuarterEndDate).ToList

                                If MediaPlanDetailLevelLineDatas.Count > 0 Then

                                    Note = MediaPlanDetailLevelLineDatas.Where(Function(Entity) String.IsNullOrEmpty(Entity.Note) = False).Select(Function(Entity) Entity.Note).Max
                                    DataValue = GetDataValue(FlowChartEstimate, MediaPlanDetailLevelLineDatas)
                                    IsActualized = MediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.IsActualized = True)
                                    Color = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Color).Max
                                    EndDate = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.EndDate).Max

                                    CellData = New CellData(DataValue, Color, BackgroundColor, Note, QuarterStartDate, EndDate, IsActualized)

                                ElseIf CellData IsNot Nothing Then

                                    If (QuarterStartDate >= CellData.StartDate AndAlso QuarterStartDate <= CellData.EndDate) OrElse
                                            (QuarterEndDate >= CellData.StartDate AndAlso QuarterEndDate <= CellData.EndDate) Then

                                        'Note = CellData.Note
                                        'DataValue = CellData.DataValue
                                        Color = CellData.Color

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor
                                        CellStyle.IsItalic = CellData.IsActualized

                                        CellData = New CellData(DataValue, Color, BackgroundColor, Note, FlowChartEstimateDate.Date, EndDate, CellStyle.IsItalic)

                                    Else

                                        CellData = Nothing

                                    End If

                                End If


                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) OrElse
                                        DataValue <> 0 OrElse FlowChartEstimate.FlowChartMediaPlanEstimateOptions.BlockingChart = True Then

                                    CellStyle.IsItalic = If(CellData IsNot Nothing, CellData.IsActualized, False)

                                    If Color <> 0 Then

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor

                                    End If

                                End If


                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) Then

                                    CellStyle.CellValueType = CellValueType.Text

                                    SetCell(_CurrentRow, _CurrentColumn, Note, CellStyle)

                                ElseIf DataValue <> 0 Then

                                    SetCellValueType(FlowChartEstimate, CellStyle)

                                    SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                                Else

                                    SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                                End If

                                If LastDate <> QuarterStartDate Then

                                    If (_CurrentColumn - LastColumn) > 1 Then

                                        Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                                    End If

                                    If Range IsNot Nothing Then

                                        If PreviousCellData IsNot Nothing AndAlso FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(PreviousCellData.Note) = False Then

                                            PreviousCellStyle.CellValueType = CellValueType.Text

                                            SetRange(Range, PreviousCellData.Note, PreviousCellStyle)

                                        ElseIf PreviousCellData IsNot Nothing AndAlso PreviousCellData.DataValue <> 0 Then

                                            SetCellValueType(FlowChartEstimate, PreviousCellStyle)

                                            SetRange(Range, PreviousCellData.DataValue, PreviousCellStyle)

                                            Range.Merge()

                                        Else

                                            SetRange(Range, String.Empty, DefaultCellStyle)

                                            If IsHighestDateDataColumn = False Then

                                                Range.Merge()

                                            End If

                                        End If

                                    End If

                                    LastColumn = _CurrentColumn
                                    LastDate = QuarterStartDate

                                End If

                            ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString Then

                                MediaPlanDetailLevelLineDatas = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) GroupRow.RowIndexes.Contains(Entity.RowIndex) AndAlso
                                                                                                                                                         Entity.StartDate >= YearStartDate AndAlso
                                                                                                                                                         Entity.StartDate <= YearEndDate).ToList

                                If MediaPlanDetailLevelLineDatas.Count > 0 Then

                                    Note = MediaPlanDetailLevelLineDatas.Where(Function(Entity) String.IsNullOrEmpty(Entity.Note) = False).Select(Function(Entity) Entity.Note).Max
                                    DataValue = GetDataValue(FlowChartEstimate, MediaPlanDetailLevelLineDatas)
                                    IsActualized = MediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.IsActualized = True)
                                    Color = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Color).Max
                                    EndDate = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.EndDate).Max

                                    CellData = New CellData(DataValue, Color, BackgroundColor, Note, YearStartDate, EndDate, IsActualized)

                                ElseIf CellData IsNot Nothing Then

                                    If (YearStartDate >= CellData.StartDate AndAlso YearStartDate <= CellData.EndDate) OrElse
                                            (YearEndDate >= CellData.StartDate AndAlso YearEndDate <= CellData.EndDate) Then

                                        'Note = CellData.Note
                                        'DataValue = CellData.DataValue
                                        Color = CellData.Color

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor
                                        CellStyle.IsItalic = CellData.IsActualized

                                        CellData = New CellData(DataValue, Color, BackgroundColor, Note, FlowChartEstimateDate.Date, EndDate, CellStyle.IsItalic)

                                    Else

                                        CellData = Nothing

                                    End If

                                End If


                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) OrElse
                                        DataValue <> 0 OrElse FlowChartEstimate.FlowChartMediaPlanEstimateOptions.BlockingChart = True Then

                                    CellStyle.IsItalic = If(CellData IsNot Nothing, CellData.IsActualized, False)

                                    If Color <> 0 Then

                                        BackgroundColor = System.Drawing.Color.FromArgb(Color)

                                        CellStyle.BackgroundColor = BackgroundColor

                                    End If

                                End If


                                If (FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(Note) = False) Then

                                    CellStyle.CellValueType = CellValueType.Text

                                    SetCell(_CurrentRow, _CurrentColumn, Note, CellStyle)

                                ElseIf DataValue <> 0 Then

                                    SetCellValueType(FlowChartEstimate, CellStyle)

                                    SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                                Else

                                    SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                                End If

                                If LastDate <> YearStartDate Then

                                    If (_CurrentColumn - LastColumn) > 1 Then

                                        Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                                    End If

                                    If Range IsNot Nothing Then

                                        If PreviousCellData IsNot Nothing AndAlso FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowNote = True AndAlso String.IsNullOrEmpty(PreviousCellData.Note) = False Then

                                            PreviousCellStyle.CellValueType = CellValueType.Text

                                            SetRange(Range, PreviousCellData.Note, PreviousCellStyle)

                                        ElseIf PreviousCellData IsNot Nothing AndAlso PreviousCellData.DataValue <> 0 Then

                                            SetCellValueType(FlowChartEstimate, PreviousCellStyle)

                                            SetRange(Range, PreviousCellData.DataValue, PreviousCellStyle)

                                            Range.Merge()

                                        Else

                                            SetRange(Range, String.Empty, DefaultCellStyle)

                                            If IsHighestDateDataColumn = False Then

                                                Range.Merge()

                                            End If

                                        End If

                                    End If

                                    LastColumn = _CurrentColumn
                                    LastDate = YearStartDate

                                End If

                            End If

                            _CurrentColumn += 1

                        Next

                        If (MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString OrElse
                                MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                                MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString OrElse
                                MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString OrElse
                                MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString) AndAlso
                           (_CurrentColumn - LastColumn) > 1 Then

                            If DataValue <> 0 OrElse IsHighestDateDataColumn = False Then

                                Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                                If DataValue <> 0 Then

                                    SetCellValueType(FlowChartEstimate, CellStyle)

                                End If

                                SetRange(Range, CellStyle)

                                Range.Merge()

                            End If

                        End If

                        'loop make through and merge notes
                        _CurrentColumn = FlowChartEstimate.FlowChart.NumberOfLevels
                        LastColumn = _CurrentColumn

                        LastNote = If(_Worksheet.Cells(_CurrentRow, _CurrentColumn).Type = Aspose.Cells.CellValueType.IsString, _Worksheet.Cells(_CurrentRow, _CurrentColumn).StringValue, String.Empty)

                        For Each FlowChartEstimateDate In FlowChartEstimate.FlowChart.FlowChartEstimateDates

                            CellStyle = New CellStyle With {.IsItalic = False, .IsBold = False, .Underline = False,
                                                            .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                            .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                            .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                            .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                            .BackgroundColor = System.Drawing.Color.Empty, .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center}

                            If _CurrentColumn > FlowChartEstimate.FlowChart.NumberOfLevels Then

                                Note = String.Empty

                                Note = If(_Worksheet.Cells(_CurrentRow, _CurrentColumn).Type = Aspose.Cells.CellValueType.IsString, _Worksheet.Cells(_CurrentRow, _CurrentColumn).StringValue, String.Empty)

                                If String.IsNullOrEmpty(Note) = False OrElse
                                        (String.IsNullOrEmpty(Note) AndAlso String.IsNullOrEmpty(LastNote) = False) Then

                                    If Note <> LastNote AndAlso String.IsNullOrEmpty(LastNote) = False Then

                                        If (_CurrentColumn - LastColumn) > 1 Then

                                            Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                                            SetRange(Range, CellStyle)

                                            Range.Merge()

                                        End If

                                        LastNote = String.Empty

                                    ElseIf String.IsNullOrEmpty(Note) = False AndAlso String.IsNullOrEmpty(LastNote) Then

                                        LastNote = Note
                                        LastColumn = _CurrentColumn

                                    End If

                                End If

                            End If

                            _CurrentColumn += 1

                        Next

                        CreateRowGrandTotalsColumns(FlowChartEstimate, GroupRow.RowIndexes)

                    Next

                    ExcelRowIndex = StartingExcelRowIndex
                    LastExcelRowIndex = StartingExcelRowIndex
                    ExcelColumnIndex = 0
                    PrevGroupRow = Nothing

                    Dim LineDataCount As Integer = 0

                    CellStyle = New CellStyle With {.IsItalic = False, .IsBold = False, .Underline = False,
                                                    .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .BackgroundColor = FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FieldAreaColor}

                    For Each FlowChartEstimateLevel In FlowChartEstimateLevels

                        LineData = String.Empty
                        LastLineData = String.Empty
                        ExcelRowIndex = StartingExcelRowIndex
                        LastExcelRowIndex = StartingExcelRowIndex
                        ExcelColumnIndex = FlowChartEstimateLevels.IndexOf(FlowChartEstimateLevel)

                        For Each GroupRow In FinalGroupRows

                            LineData = GroupRow.LevelData(FlowChartEstimateLevels.IndexOf(FlowChartEstimateLevel))

                            If FinalGroupRows.IndexOf(GroupRow) = FinalGroupRows.Count - 1 Then

                                If LineData = LastLineData Then

                                    If ExcelRowIndex > LastExcelRowIndex Then

                                        Range = _Worksheet.Cells.CreateRange(LastExcelRowIndex, ExcelColumnIndex, ((ExcelRowIndex + 1) - LastExcelRowIndex), 1)

                                        SetRange(Range, CellStyle)

                                        Range.Merge()

                                    End If

                                End If

                            ElseIf FinalGroupRows.IndexOf(GroupRow) > 0 Then

                                If LineData <> LastLineData Then

                                    Range = _Worksheet.Cells.CreateRange(LastExcelRowIndex, ExcelColumnIndex, (ExcelRowIndex - LastExcelRowIndex), 1)

                                    SetRange(Range, CellStyle)

                                    Range.Merge()

                                    LastExcelRowIndex = ExcelRowIndex

                                End If

                            End If

                            LastLineData = LineData

                            ExcelRowIndex += 1

                        Next

                        ExcelColumnIndex += 1

                    Next

                End If

            End If

        End Sub
        Private Sub CreateEstimateGrandTotalRow(FlowChartEstimate As FlowChartEstimate)

            'objects
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing
            Dim LastColumn As Integer = -1
            Dim Range As Aspose.Cells.Range = Nothing
            Dim CellStyle As CellStyle = Nothing
            Dim DataValue As Double = 0
            Dim WeekStartDate As Date = Date.MinValue
            Dim WeekEndDate As Date = Date.MinValue
            Dim MonthStartDate As Date = Date.MinValue
            Dim MonthEndDate As Date = Date.MinValue
            Dim QuarterStartDate As Date = Date.MinValue
            Dim QuarterEndDate As Date = Date.MinValue
            Dim YearStartDate As Date = Date.MinValue
            Dim YearEndDate As Date = Date.MinValue
            Dim MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim AllMediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim LastDate As Date = Date.MinValue
            Dim CurrentDate As Date = Date.MinValue
            Dim PreviousDataValue As Double = 0

            If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.FlowChartMediaPlanOptions.FlowChartDateHeaderOption = FlowChartDateHeaderOptions.FromPlan Then

                MediaPlanDetailField = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailFields.Where(Function(Entity) Entity.Area = 1 AndAlso Entity.IsVisible = True).OrderBy(Function(Entity) Entity.AreaIndex).ToList.LastOrDefault

            ElseIf FlowChartEstimate.FlowChartMediaPlanEstimateOptions.FlowChartMediaPlanOptions.FlowChartDateHeaderOption = FlowChartDateHeaderOptions.ChooseLevels Then

                MediaPlanDetailField = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailFields.FirstOrDefault(Function(Entity) Entity.FieldID = FlowChartEstimate.FlowChart.HighestDateDataColumn.ToString)

            End If

            _CurrentRow += 1

            CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                            .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                            .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                            .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                            .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                            .BackgroundColor = FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.EstimateColumnTotalsAreaColor}

            _CurrentColumn = 0

            For RC As Integer = _CurrentColumn To FlowChartEstimate.FlowChart.NumberOfLevels - 1

                If _CurrentColumn = 0 Then

                    SetCell(_CurrentRow, _CurrentColumn, "Totals", CellStyle)

                Else

                    SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                End If

                _CurrentColumn += 1

            Next

            LastColumn = 0

            'For RC As Integer = _CurrentColumn To FlowChartEstimate.FlowChart.NumberOfLevels - 1

            '    SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

            '    _CurrentColumn += 1

            'Next

            If _CurrentColumn - LastColumn > 1 Then

                Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                Range.Merge()

            End If

            LastColumn = _CurrentColumn

            AllMediaPlanDetailLevelLineDatas = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.ToList

            AllMediaPlanDetailLevelLineDatas = AllMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.StartDate >= FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.StartDate AndAlso
                                                                                                       Entity.StartDate <= FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.EndDate).ToList

            If MediaPlanDetailField IsNot Nothing Then

                If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString OrElse
                    MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Date.ToString Then

                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).Date

                ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                    If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                        If FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth Then

                            LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).WeekStartDate

                        Else

                            LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastWeekStartDate

                        End If

                    ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                        LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).WeekStartDate

                    ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                        LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastWeekStartDate

                    End If

                ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                    MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                    If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                        If FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth Then

                            LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).MonthStartDate

                        Else

                            LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastMonthStartDate

                        End If

                    ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                        LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).MonthStartDate

                    ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                        LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastMonthStartDate

                    End If

                ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString Then

                    If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                        If FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth Then

                            LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).QuarterStartDate

                        Else

                            LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastQuarterStartDate

                        End If

                    ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                        LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).QuarterStartDate

                    ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                        LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastQuarterStartDate

                    End If

                ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString Then

                    If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                        If FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth Then

                            LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).YearStartDate

                        Else

                            LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastYearStartDate

                        End If

                    ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                        LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).YearStartDate

                    ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                        LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastYearStartDate

                    End If

                End If

                For Each FlowChartEstimateDate In FlowChartEstimate.FlowChart.FlowChartEstimateDates

                    CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                                    .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .BackgroundColor = FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.EstimateColumnTotalsAreaColor, .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center}

                    PreviousDataValue = DataValue
                    DataValue = 0
                    Range = Nothing

                    If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                        If FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth Then

                            WeekStartDate = FlowChartEstimateDate.WeekStartDate
                            WeekEndDate = FlowChartEstimateDate.WeekEndDate
                            MonthStartDate = FlowChartEstimateDate.MonthStartDate
                            MonthEndDate = FlowChartEstimateDate.MonthEndDate
                            QuarterStartDate = FlowChartEstimateDate.QuarterStartDate
                            QuarterEndDate = FlowChartEstimateDate.QuarterEndDate
                            YearStartDate = FlowChartEstimateDate.YearStartDate
                            YearEndDate = FlowChartEstimateDate.YearEndDate

                        Else

                            WeekStartDate = FlowChartEstimateDate.BroadcastWeekStartDate
                            WeekEndDate = FlowChartEstimateDate.BroadcastWeekEndDate
                            MonthStartDate = FlowChartEstimateDate.BroadcastMonthStartDate
                            MonthEndDate = FlowChartEstimateDate.BroadcastMonthEndDate
                            QuarterStartDate = FlowChartEstimateDate.BroadcastQuarterStartDate
                            QuarterEndDate = FlowChartEstimateDate.BroadcastQuarterEndDate
                            YearStartDate = FlowChartEstimateDate.BroadcastYearStartDate
                            YearEndDate = FlowChartEstimateDate.BroadcastYearEndDate

                        End If

                    ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                        WeekStartDate = FlowChartEstimateDate.WeekStartDate
                        WeekEndDate = FlowChartEstimateDate.WeekEndDate
                        MonthStartDate = FlowChartEstimateDate.MonthStartDate
                        MonthEndDate = FlowChartEstimateDate.MonthEndDate
                        QuarterStartDate = FlowChartEstimateDate.QuarterStartDate
                        QuarterEndDate = FlowChartEstimateDate.QuarterEndDate
                        YearStartDate = FlowChartEstimateDate.YearStartDate
                        YearEndDate = FlowChartEstimateDate.YearEndDate

                    ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                        WeekStartDate = FlowChartEstimateDate.BroadcastWeekStartDate
                        WeekEndDate = FlowChartEstimateDate.BroadcastWeekEndDate
                        MonthStartDate = FlowChartEstimateDate.BroadcastMonthStartDate
                        MonthEndDate = FlowChartEstimateDate.BroadcastMonthEndDate
                        QuarterStartDate = FlowChartEstimateDate.BroadcastQuarterStartDate
                        QuarterEndDate = FlowChartEstimateDate.BroadcastQuarterEndDate
                        YearStartDate = FlowChartEstimateDate.BroadcastYearStartDate
                        YearEndDate = FlowChartEstimateDate.BroadcastYearEndDate

                    End If

                    If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString OrElse
                            MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Date.ToString Then

                        MediaPlanDetailLevelLineDatas = AllMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.StartDate = FlowChartEstimateDate.Date).ToList

                        CurrentDate = FlowChartEstimateDate.Date

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                        MediaPlanDetailLevelLineDatas = AllMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.StartDate >= WeekStartDate AndAlso
                                                                                                                Entity.StartDate <= WeekEndDate).ToList

                        CurrentDate = WeekStartDate

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                        MediaPlanDetailLevelLineDatas = AllMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.StartDate >= MonthStartDate AndAlso
                                                                                                                Entity.StartDate <= MonthEndDate).ToList

                        CurrentDate = MonthStartDate

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString Then

                        MediaPlanDetailLevelLineDatas = AllMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.StartDate >= QuarterStartDate AndAlso
                                                                                                                Entity.StartDate <= QuarterEndDate).ToList

                        CurrentDate = QuarterStartDate

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString Then

                        MediaPlanDetailLevelLineDatas = AllMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.StartDate >= YearStartDate AndAlso
                                                                                                                Entity.StartDate <= YearEndDate).ToList

                        CurrentDate = YearStartDate

                    End If

                    If MediaPlanDetailLevelLineDatas.Count > 0 Then

                        DataValue = GetDataValue(FlowChartEstimate.FlowChartMediaPlanEstimateOptions.DisplayValue, False,
                                                 FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar,
                                                 MediaPlanDetailLevelLineDatas)

                    End If

                    SetCellValueType(FlowChartEstimate, CellStyle)

                    SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                    If LastDate <> CurrentDate Then

                        If (_CurrentColumn - LastColumn) > 1 Then

                            Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                        End If

                        If Range IsNot Nothing Then

                            SetCellValueType(FlowChartEstimate, CellStyle)

                            SetRange(Range, PreviousDataValue, CellStyle)

                            Range.Merge()

                        End If

                        LastColumn = _CurrentColumn
                        LastDate = CurrentDate

                    End If

                    _CurrentColumn += 1

                Next

                If (MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString) AndAlso
                    (_CurrentColumn - LastColumn) > 1 Then

                    Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                    SetRange(Range, CellStyle)

                    Range.Merge()

                End If

            Else

                CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                                .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .BackgroundColor = FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.EstimateColumnTotalsAreaColor, .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center}

                If AllMediaPlanDetailLevelLineDatas.Count > 0 Then

                    DataValue = GetDataValue(FlowChartEstimate.FlowChartMediaPlanEstimateOptions.DisplayValue, False,
                                             FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar,
                                             AllMediaPlanDetailLevelLineDatas)

                End If

                SetCellValueType(FlowChartEstimate, CellStyle)

                SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                _CurrentColumn += 1

            End If

            DataValue = 0

            If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowEstimateRowTotals Then

                If AllMediaPlanDetailLevelLineDatas.Count > 0 Then

                    DataValue = GetDataValue(FlowChartEstimate.FlowChartMediaPlanEstimateOptions.DisplayValue, False,
                                             FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar,
                                             AllMediaPlanDetailLevelLineDatas)

                End If

                SetCellValueType(FlowChartEstimate, CellStyle)

                SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                _CurrentColumn += 1

            End If

        End Sub
        Private Sub CreateMonthTotalsRow(FlowChartEstimate As FlowChartEstimate)

            'objects
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing
            Dim LastColumn As Integer = -1
            Dim Range As Aspose.Cells.Range = Nothing
            Dim CellStyle As CellStyle = Nothing
            Dim DataValue As Double = 0
            Dim WeekStartDate As Date = Date.MinValue
            Dim WeekEndDate As Date = Date.MinValue
            Dim MonthStartDate As Date = Date.MinValue
            Dim MonthEndDate As Date = Date.MinValue
            Dim QuarterStartDate As Date = Date.MinValue
            Dim QuarterEndDate As Date = Date.MinValue
            Dim YearStartDate As Date = Date.MinValue
            Dim YearEndDate As Date = Date.MinValue
            Dim MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim AllMediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim LastDate As Date = Date.MinValue
            Dim CurrentDate As Date = Date.MinValue
            Dim PreviousDataValue As Double = 0

            If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.FlowChartMediaPlanOptions.FlowChartDateHeaderOption = FlowChartDateHeaderOptions.FromPlan Then

                MediaPlanDetailField = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailFields.Where(Function(Entity) Entity.Area = 1 AndAlso Entity.IsVisible = True).OrderBy(Function(Entity) Entity.AreaIndex).ToList.LastOrDefault

            ElseIf FlowChartEstimate.FlowChartMediaPlanEstimateOptions.FlowChartMediaPlanOptions.FlowChartDateHeaderOption = FlowChartDateHeaderOptions.ChooseLevels Then

                MediaPlanDetailField = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailFields.FirstOrDefault(Function(Entity) Entity.FieldID = FlowChartEstimate.FlowChart.HighestDateDataColumn.ToString)

            End If

            If (MediaPlanDetailField IsNot Nothing AndAlso MediaPlanDetailField.FieldID <> AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString AndAlso
                    MediaPlanDetailField.FieldID <> AdvantageFramework.MediaPlanning.DataColumns.Year.ToString) OrElse MediaPlanDetailField Is Nothing Then

                _CurrentRow += 1

                CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                                .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .BackgroundColor = FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.EstimateColumnTotalsAreaColor}

                _CurrentColumn = 0

                For RC As Integer = _CurrentColumn To FlowChartEstimate.FlowChart.NumberOfLevels - 1

                    If _CurrentColumn = 0 Then

                        SetCell(_CurrentRow, _CurrentColumn, "Totals by Month", CellStyle)

                    Else

                        SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                    End If

                    _CurrentColumn += 1

                Next

                LastColumn = 0

                'For RC As Integer = _CurrentColumn To FlowChartEstimate.FlowChart.NumberOfLevels - 1

                '    SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                '    _CurrentColumn += 1

                'Next

                If _CurrentColumn - LastColumn > 1 Then

                    Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                    Range.Merge()

                End If

                LastColumn = _CurrentColumn

                If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                    If FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth Then

                        LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).MonthStartDate

                    Else

                        LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastMonthStartDate

                    End If

                ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).MonthStartDate

                ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastMonthStartDate

                End If

                AllMediaPlanDetailLevelLineDatas = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.ToList

                AllMediaPlanDetailLevelLineDatas = AllMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.StartDate >= FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.StartDate AndAlso
                                                                                                           Entity.StartDate <= FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.EndDate).ToList

                For Each FlowChartEstimateDate In FlowChartEstimate.FlowChart.FlowChartEstimateDates

                    CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                                    .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .BackgroundColor = FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.EstimateColumnTotalsAreaColor, .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center}

                    PreviousDataValue = DataValue
                    DataValue = 0
                    Range = Nothing

                    If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                        If FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth Then

                            WeekStartDate = FlowChartEstimateDate.WeekStartDate
                            WeekEndDate = FlowChartEstimateDate.WeekEndDate
                            MonthStartDate = FlowChartEstimateDate.MonthStartDate
                            MonthEndDate = FlowChartEstimateDate.MonthEndDate
                            QuarterStartDate = FlowChartEstimateDate.QuarterStartDate
                            QuarterEndDate = FlowChartEstimateDate.QuarterEndDate
                            YearStartDate = FlowChartEstimateDate.YearStartDate
                            YearEndDate = FlowChartEstimateDate.YearEndDate

                        Else

                            WeekStartDate = FlowChartEstimateDate.BroadcastWeekStartDate
                            WeekEndDate = FlowChartEstimateDate.BroadcastWeekEndDate
                            MonthStartDate = FlowChartEstimateDate.BroadcastMonthStartDate
                            MonthEndDate = FlowChartEstimateDate.BroadcastMonthEndDate
                            QuarterStartDate = FlowChartEstimateDate.BroadcastQuarterStartDate
                            QuarterEndDate = FlowChartEstimateDate.BroadcastQuarterEndDate
                            YearStartDate = FlowChartEstimateDate.BroadcastYearStartDate
                            YearEndDate = FlowChartEstimateDate.BroadcastYearEndDate

                        End If

                    ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                        WeekStartDate = FlowChartEstimateDate.WeekStartDate
                        WeekEndDate = FlowChartEstimateDate.WeekEndDate
                        MonthStartDate = FlowChartEstimateDate.MonthStartDate
                        MonthEndDate = FlowChartEstimateDate.MonthEndDate
                        QuarterStartDate = FlowChartEstimateDate.QuarterStartDate
                        QuarterEndDate = FlowChartEstimateDate.QuarterEndDate
                        YearStartDate = FlowChartEstimateDate.YearStartDate
                        YearEndDate = FlowChartEstimateDate.YearEndDate

                    ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                        WeekStartDate = FlowChartEstimateDate.BroadcastWeekStartDate
                        WeekEndDate = FlowChartEstimateDate.BroadcastWeekEndDate
                        MonthStartDate = FlowChartEstimateDate.BroadcastMonthStartDate
                        MonthEndDate = FlowChartEstimateDate.BroadcastMonthEndDate
                        QuarterStartDate = FlowChartEstimateDate.BroadcastQuarterStartDate
                        QuarterEndDate = FlowChartEstimateDate.BroadcastQuarterEndDate
                        YearStartDate = FlowChartEstimateDate.BroadcastYearStartDate
                        YearEndDate = FlowChartEstimateDate.BroadcastYearEndDate

                    End If

                    MediaPlanDetailLevelLineDatas = AllMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.StartDate >= MonthStartDate AndAlso
                                                                                                            Entity.StartDate <= MonthEndDate).ToList

                    CurrentDate = MonthStartDate

                    If MediaPlanDetailLevelLineDatas.Count > 0 Then

                        DataValue = GetDataValue(FlowChartEstimate.FlowChartMediaPlanEstimateOptions.DisplayValue, False,
                                                 FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar,
                                                 MediaPlanDetailLevelLineDatas)

                    End If

                    SetCellValueType(FlowChartEstimate, CellStyle)

                    SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                    If LastDate <> CurrentDate Then

                        If (_CurrentColumn - LastColumn) > 1 Then

                            Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                        End If

                        If Range IsNot Nothing Then

                            SetCellValueType(FlowChartEstimate, CellStyle)

                            SetRange(Range, PreviousDataValue, CellStyle)

                            Range.Merge()

                        End If

                        LastColumn = _CurrentColumn
                        LastDate = CurrentDate

                    End If

                    _CurrentColumn += 1

                Next

                If MediaPlanDetailField IsNot Nothing Then

                    If (MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString OrElse
                            MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Date.ToString OrElse
                            MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString OrElse
                            MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                            MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString OrElse
                            MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString OrElse
                            MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString) AndAlso
                        (_CurrentColumn - LastColumn) > 1 Then

                        Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                        SetRange(Range, CellStyle)

                        Range.Merge()

                    End If

                End If

                DataValue = 0

                If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowEstimateRowTotals Then

                    If AllMediaPlanDetailLevelLineDatas.Count > 0 Then

                        DataValue = GetDataValue(FlowChartEstimate.FlowChartMediaPlanEstimateOptions.DisplayValue, False,
                                                 FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar,
                                                 AllMediaPlanDetailLevelLineDatas)

                    End If

                    SetCellValueType(FlowChartEstimate, CellStyle)

                    SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                    _CurrentColumn += 1

                End If

            End If

        End Sub
        Private Sub CreateGrandTotalRow(FlowChart As FlowChart)

            'objects
            Dim LastColumn As Integer = -1
            Dim Range As Aspose.Cells.Range = Nothing
            Dim CellStyle As CellStyle = Nothing
            Dim DataValue As Double = 0
            Dim WeekStartDate As Date = Date.MinValue
            Dim WeekEndDate As Date = Date.MinValue
            Dim MonthStartDate As Date = Date.MinValue
            Dim MonthEndDate As Date = Date.MinValue
            Dim QuarterStartDate As Date = Date.MinValue
            Dim QuarterEndDate As Date = Date.MinValue
            Dim YearStartDate As Date = Date.MinValue
            Dim YearEndDate As Date = Date.MinValue
            Dim MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim AllMediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim LastDate As Date = Date.MinValue
            Dim CurrentDate As Date = Date.MinValue

            CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                            .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                            .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                            .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                            .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                            .BackgroundColor = FlowChart.FlowChartMediaPlanOptions.GrandTotalsAreaColor}

            _CurrentColumn = 0
            LastColumn = 0

            For Column = 0 To FlowChart.NumberOfLevels - 1

                SetCell(_CurrentRow, _CurrentColumn, "Grand Totals", CellStyle)

                _CurrentColumn += 1

            Next

            If _CurrentColumn - LastColumn > 1 Then

                Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                Range.Merge()

            End If

            LastColumn = _CurrentColumn

            If FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString OrElse
                    FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Date.ToString Then

                LastDate = FlowChart.FlowChartEstimateDates(0).Date

            ElseIf FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                If FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                    If FlowChart.IsUsingBroadcastDates = False Then

                        LastDate = FlowChart.FlowChartEstimateDates(0).WeekStartDate

                    Else

                        LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastWeekStartDate

                    End If

                ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                    LastDate = FlowChart.FlowChartEstimateDates(0).WeekStartDate

                ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                    LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastWeekStartDate

                End If

            ElseIf FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                    FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                If FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                    If FlowChart.IsUsingBroadcastDates = False Then

                        LastDate = FlowChart.FlowChartEstimateDates(0).MonthStartDate

                    Else

                        LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastMonthStartDate

                    End If

                ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                    LastDate = FlowChart.FlowChartEstimateDates(0).MonthStartDate

                ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                    LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastMonthStartDate

                End If

            ElseIf FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString Then

                If FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                    If FlowChart.IsUsingBroadcastDates = False Then

                        LastDate = FlowChart.FlowChartEstimateDates(0).QuarterStartDate

                    Else

                        LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastQuarterStartDate

                    End If

                ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                    LastDate = FlowChart.FlowChartEstimateDates(0).QuarterStartDate

                ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                    LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastQuarterStartDate

                End If

            ElseIf FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString Then

                If FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                    If FlowChart.IsUsingBroadcastDates = False Then

                        LastDate = FlowChart.FlowChartEstimateDates(0).YearStartDate

                    Else

                        LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastYearStartDate

                    End If

                ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                    LastDate = FlowChart.FlowChartEstimateDates(0).YearStartDate

                ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                    LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastYearStartDate

                End If

            End If

            AllMediaPlanDetailLevelLineDatas = FlowChart.FlowChartEstimates.Select(Function(Entity) Entity.MediaPlanEstimate).SelectMany(Function(MPE) MPE.MediaPlanDetailLevelLineDatas).ToList

            AllMediaPlanDetailLevelLineDatas = AllMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.StartDate >= FlowChart.FlowChartMediaPlanOptions.StartDate AndAlso
                                                                                                       Entity.StartDate <= FlowChart.FlowChartMediaPlanOptions.EndDate).ToList

            For Each FlowChartEstimateDate In FlowChart.FlowChartEstimateDates

                CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                                .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .BackgroundColor = FlowChart.FlowChartMediaPlanOptions.GrandTotalsAreaColor, .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center}

                DataValue = 0
                Range = Nothing

                If FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                    If FlowChart.IsUsingBroadcastDates = False Then

                        WeekStartDate = FlowChartEstimateDate.WeekStartDate
                        WeekEndDate = FlowChartEstimateDate.WeekEndDate
                        MonthStartDate = FlowChartEstimateDate.MonthStartDate
                        MonthEndDate = FlowChartEstimateDate.MonthEndDate
                        QuarterStartDate = FlowChartEstimateDate.QuarterStartDate
                        QuarterEndDate = FlowChartEstimateDate.QuarterEndDate
                        YearStartDate = FlowChartEstimateDate.YearStartDate
                        YearEndDate = FlowChartEstimateDate.YearEndDate

                    Else

                        WeekStartDate = FlowChartEstimateDate.BroadcastWeekStartDate
                        WeekEndDate = FlowChartEstimateDate.BroadcastWeekEndDate
                        MonthStartDate = FlowChartEstimateDate.BroadcastMonthStartDate
                        MonthEndDate = FlowChartEstimateDate.BroadcastMonthEndDate
                        QuarterStartDate = FlowChartEstimateDate.BroadcastQuarterStartDate
                        QuarterEndDate = FlowChartEstimateDate.BroadcastQuarterEndDate
                        YearStartDate = FlowChartEstimateDate.BroadcastYearStartDate
                        YearEndDate = FlowChartEstimateDate.BroadcastYearEndDate

                    End If

                ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                    WeekStartDate = FlowChartEstimateDate.WeekStartDate
                    WeekEndDate = FlowChartEstimateDate.WeekEndDate
                    MonthStartDate = FlowChartEstimateDate.MonthStartDate
                    MonthEndDate = FlowChartEstimateDate.MonthEndDate
                    QuarterStartDate = FlowChartEstimateDate.QuarterStartDate
                    QuarterEndDate = FlowChartEstimateDate.QuarterEndDate
                    YearStartDate = FlowChartEstimateDate.YearStartDate
                    YearEndDate = FlowChartEstimateDate.YearEndDate

                ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                    WeekStartDate = FlowChartEstimateDate.BroadcastWeekStartDate
                    WeekEndDate = FlowChartEstimateDate.BroadcastWeekEndDate
                    MonthStartDate = FlowChartEstimateDate.BroadcastMonthStartDate
                    MonthEndDate = FlowChartEstimateDate.BroadcastMonthEndDate
                    QuarterStartDate = FlowChartEstimateDate.BroadcastQuarterStartDate
                    QuarterEndDate = FlowChartEstimateDate.BroadcastQuarterEndDate
                    YearStartDate = FlowChartEstimateDate.BroadcastYearStartDate
                    YearEndDate = FlowChartEstimateDate.BroadcastYearEndDate

                End If

                If FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString OrElse
                        FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Date.ToString Then

                    MediaPlanDetailLevelLineDatas = AllMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.StartDate = FlowChartEstimateDate.Date).ToList

                    CurrentDate = FlowChartEstimateDate.Date

                ElseIf FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                    MediaPlanDetailLevelLineDatas = AllMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.StartDate >= WeekStartDate AndAlso
                                                                                                            Entity.StartDate <= WeekEndDate).ToList

                    CurrentDate = WeekStartDate

                ElseIf FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                        FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                    MediaPlanDetailLevelLineDatas = AllMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.StartDate >= MonthStartDate AndAlso
                                                                                                            Entity.StartDate <= MonthEndDate).ToList

                    CurrentDate = MonthStartDate

                ElseIf FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString Then

                    MediaPlanDetailLevelLineDatas = AllMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.StartDate >= QuarterStartDate AndAlso
                                                                                                            Entity.StartDate <= QuarterEndDate).ToList

                    CurrentDate = QuarterStartDate

                ElseIf FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString Then

                    MediaPlanDetailLevelLineDatas = AllMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.StartDate >= YearStartDate AndAlso
                                                                                                            Entity.StartDate <= YearEndDate).ToList

                    CurrentDate = YearStartDate

                End If

                If MediaPlanDetailLevelLineDatas.Count > 0 Then

                    DataValue = GetDataValue(FlowChart.FlowChartMediaPlanOptions.GrandTotalsDisplayValue, False,
                                             FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar,
                                             MediaPlanDetailLevelLineDatas)

                End If

                SetCellValueType(FlowChart.FlowChartMediaPlanOptions.GrandTotalsDisplayValue, FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar, CellStyle)

                SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                If LastDate <> CurrentDate Then

                    If (_CurrentColumn - LastColumn) > 1 Then

                        Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                    End If

                    If Range IsNot Nothing Then

                        SetCellValueType(FlowChart.FlowChartMediaPlanOptions.GrandTotalsDisplayValue, FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar, CellStyle)

                        SetRange(Range, DataValue, CellStyle)

                        Range.Merge()

                    End If

                    LastColumn = _CurrentColumn
                    LastDate = CurrentDate

                End If

                _CurrentColumn += 1

            Next

            If (FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString OrElse
                    FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                    FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString OrElse
                    FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString OrElse
                    FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString) AndAlso
                (_CurrentColumn - LastColumn) > 1 Then

                Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                SetRange(Range, CellStyle)

                Range.Merge()

            End If

            DataValue = 0

            If FlowChart.FlowChartEstimates.Select(Function(Entity) Entity.FlowChartMediaPlanEstimateOptions).Any(Function(Entity) Entity.ShowEstimateRowTotals) Then

                If AllMediaPlanDetailLevelLineDatas.Count > 0 Then

                    DataValue = GetDataValue(FlowChart.FlowChartMediaPlanOptions.GrandTotalsDisplayValue, False,
                                             FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar,
                                             AllMediaPlanDetailLevelLineDatas)

                End If

                SetCellValueType(FlowChart.FlowChartMediaPlanOptions.GrandTotalsDisplayValue, FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar, CellStyle)

                SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                _CurrentColumn += 1

            End If

        End Sub
        Private Sub CreateMonthGrandTotalsRow(FlowChart As FlowChart)

            'objects
            Dim LastColumn As Integer = -1
            Dim Range As Aspose.Cells.Range = Nothing
            Dim CellStyle As CellStyle = Nothing
            Dim DataValue As Double = 0
            Dim WeekStartDate As Date = Date.MinValue
            Dim WeekEndDate As Date = Date.MinValue
            Dim MonthStartDate As Date = Date.MinValue
            Dim MonthEndDate As Date = Date.MinValue
            Dim QuarterStartDate As Date = Date.MinValue
            Dim QuarterEndDate As Date = Date.MinValue
            Dim YearStartDate As Date = Date.MinValue
            Dim YearEndDate As Date = Date.MinValue
            Dim MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim AllMediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim LastDate As Date = Date.MinValue
            Dim CurrentDate As Date = Date.MinValue
            Dim PreviousDataValue As Double = 0

            If FlowChart.HighestDateDataColumn <> AdvantageFramework.MediaPlanning.DataColumns.Quarter AndAlso
                    FlowChart.HighestDateDataColumn <> AdvantageFramework.MediaPlanning.DataColumns.Year Then

                CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                                .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .BackgroundColor = FlowChart.FlowChartMediaPlanOptions.GrandTotalsAreaColor}

                _CurrentColumn = 0
                LastColumn = 0

                For Column = 0 To FlowChart.NumberOfLevels - 1

                    SetCell(_CurrentRow, _CurrentColumn, "Grand Totals by Month", CellStyle)

                    _CurrentColumn += 1

                Next

                If _CurrentColumn - LastColumn > 1 Then

                    Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                    Range.Merge()

                End If

                LastColumn = _CurrentColumn

                If FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString OrElse
                    FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Date.ToString Then

                    LastDate = FlowChart.FlowChartEstimateDates(0).Date

                ElseIf FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                    If FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                        If FlowChart.IsUsingBroadcastDates = False Then

                            LastDate = FlowChart.FlowChartEstimateDates(0).WeekStartDate

                        Else

                            LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastWeekStartDate

                        End If

                    ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                        LastDate = FlowChart.FlowChartEstimateDates(0).WeekStartDate

                    ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                        LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastWeekStartDate

                    End If

                ElseIf FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                    FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                    If FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                        If FlowChart.IsUsingBroadcastDates = False Then

                            LastDate = FlowChart.FlowChartEstimateDates(0).MonthStartDate

                        Else

                            LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastMonthStartDate

                        End If

                    ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                        LastDate = FlowChart.FlowChartEstimateDates(0).MonthStartDate

                    ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                        LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastMonthStartDate

                    End If

                ElseIf FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString Then

                    If FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                        If FlowChart.IsUsingBroadcastDates = False Then

                            LastDate = FlowChart.FlowChartEstimateDates(0).QuarterStartDate

                        Else

                            LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastQuarterStartDate

                        End If

                    ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                        LastDate = FlowChart.FlowChartEstimateDates(0).QuarterStartDate

                    ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                        LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastQuarterStartDate

                    End If

                ElseIf FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString Then

                    If FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                        If FlowChart.IsUsingBroadcastDates = False Then

                            LastDate = FlowChart.FlowChartEstimateDates(0).YearStartDate

                        Else

                            LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastYearStartDate

                        End If

                    ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                        LastDate = FlowChart.FlowChartEstimateDates(0).YearStartDate

                    ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                        LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastYearStartDate

                    End If

                End If

                AllMediaPlanDetailLevelLineDatas = FlowChart.FlowChartEstimates.Select(Function(Entity) Entity.MediaPlanEstimate).SelectMany(Function(MPE) MPE.MediaPlanDetailLevelLineDatas).ToList

                AllMediaPlanDetailLevelLineDatas = AllMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.StartDate >= FlowChart.FlowChartMediaPlanOptions.StartDate AndAlso
                                                                                                           Entity.StartDate <= FlowChart.FlowChartMediaPlanOptions.EndDate).ToList

                For Each FlowChartEstimateDate In FlowChart.FlowChartEstimateDates

                    CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                                    .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .BackgroundColor = FlowChart.FlowChartMediaPlanOptions.GrandTotalsAreaColor, .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center}

                    PreviousDataValue = DataValue
                    DataValue = 0
                    Range = Nothing

                    If FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                        If FlowChart.IsUsingBroadcastDates = False Then

                            WeekStartDate = FlowChartEstimateDate.WeekStartDate
                            WeekEndDate = FlowChartEstimateDate.WeekEndDate
                            MonthStartDate = FlowChartEstimateDate.MonthStartDate
                            MonthEndDate = FlowChartEstimateDate.MonthEndDate
                            QuarterStartDate = FlowChartEstimateDate.QuarterStartDate
                            QuarterEndDate = FlowChartEstimateDate.QuarterEndDate
                            YearStartDate = FlowChartEstimateDate.YearStartDate
                            YearEndDate = FlowChartEstimateDate.YearEndDate

                        Else

                            WeekStartDate = FlowChartEstimateDate.BroadcastWeekStartDate
                            WeekEndDate = FlowChartEstimateDate.BroadcastWeekEndDate
                            MonthStartDate = FlowChartEstimateDate.BroadcastMonthStartDate
                            MonthEndDate = FlowChartEstimateDate.BroadcastMonthEndDate
                            QuarterStartDate = FlowChartEstimateDate.BroadcastQuarterStartDate
                            QuarterEndDate = FlowChartEstimateDate.BroadcastQuarterEndDate
                            YearStartDate = FlowChartEstimateDate.BroadcastYearStartDate
                            YearEndDate = FlowChartEstimateDate.BroadcastYearEndDate

                        End If

                    ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                        WeekStartDate = FlowChartEstimateDate.WeekStartDate
                        WeekEndDate = FlowChartEstimateDate.WeekEndDate
                        MonthStartDate = FlowChartEstimateDate.MonthStartDate
                        MonthEndDate = FlowChartEstimateDate.MonthEndDate
                        QuarterStartDate = FlowChartEstimateDate.QuarterStartDate
                        QuarterEndDate = FlowChartEstimateDate.QuarterEndDate
                        YearStartDate = FlowChartEstimateDate.YearStartDate
                        YearEndDate = FlowChartEstimateDate.YearEndDate

                    ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                        WeekStartDate = FlowChartEstimateDate.BroadcastWeekStartDate
                        WeekEndDate = FlowChartEstimateDate.BroadcastWeekEndDate
                        MonthStartDate = FlowChartEstimateDate.BroadcastMonthStartDate
                        MonthEndDate = FlowChartEstimateDate.BroadcastMonthEndDate
                        QuarterStartDate = FlowChartEstimateDate.BroadcastQuarterStartDate
                        QuarterEndDate = FlowChartEstimateDate.BroadcastQuarterEndDate
                        YearStartDate = FlowChartEstimateDate.BroadcastYearStartDate
                        YearEndDate = FlowChartEstimateDate.BroadcastYearEndDate

                    End If

                    MediaPlanDetailLevelLineDatas = AllMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.StartDate >= MonthStartDate AndAlso
                                                                                                            Entity.StartDate <= MonthEndDate).ToList

                    CurrentDate = MonthStartDate

                    If MediaPlanDetailLevelLineDatas.Count > 0 Then

                        DataValue = GetDataValue(FlowChart.FlowChartMediaPlanOptions.GrandTotalsDisplayValue, False,
                                                 FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar,
                                                 MediaPlanDetailLevelLineDatas)

                    End If

                    SetCellValueType(FlowChart.FlowChartMediaPlanOptions.GrandTotalsDisplayValue, FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar, CellStyle)

                    SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                    If LastDate <> CurrentDate Then

                        If (_CurrentColumn - LastColumn) > 1 Then

                            Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                        End If

                        If Range IsNot Nothing Then

                            SetCellValueType(FlowChart.FlowChartMediaPlanOptions.GrandTotalsDisplayValue, FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar, CellStyle)

                            SetRange(Range, PreviousDataValue, CellStyle)

                            Range.Merge()

                        End If

                        LastColumn = _CurrentColumn
                        LastDate = CurrentDate

                    End If

                    _CurrentColumn += 1

                Next

                If (FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString OrElse
                        FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Date.ToString OrElse
                        FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString OrElse
                        FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                        FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString OrElse
                        FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString OrElse
                        FlowChart.HighestDateDataColumn.ToString = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString) AndAlso
                    (_CurrentColumn - LastColumn) > 1 Then

                    Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                    SetRange(Range, CellStyle)

                    Range.Merge()

                End If

                DataValue = 0

                If FlowChart.FlowChartEstimates.Select(Function(Entity) Entity.FlowChartMediaPlanEstimateOptions).Any(Function(Entity) Entity.ShowEstimateRowTotals) Then

                    If AllMediaPlanDetailLevelLineDatas.Count > 0 Then

                        DataValue = GetDataValue(FlowChart.FlowChartMediaPlanOptions.GrandTotalsDisplayValue, False,
                                                 FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar,
                                                 AllMediaPlanDetailLevelLineDatas)

                    End If

                    SetCellValueType(FlowChart.FlowChartMediaPlanOptions.GrandTotalsDisplayValue, FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar, CellStyle)

                    SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                    _CurrentColumn += 1

                End If

            End If

        End Sub
        Private Sub CreateSummary(FlowChart As FlowChart)

            'objects
            Dim Range As Aspose.Cells.Range = Nothing
            Dim CellStyle As CellStyle = Nothing
            Dim DataValueCellStyle As CellStyle = Nothing
            Dim DataValue As Double = 0
            Dim MediaPlanEstimates As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate) = Nothing
            Dim MediaPlanFlowChartDatas As Generic.List(Of AdvantageFramework.MediaPlanning.FlowChart.MediaPlanFlowChartData) = Nothing
            Dim AllMediaPlanFlowChartDatas As Generic.List(Of AdvantageFramework.MediaPlanning.FlowChart.MediaPlanFlowChartData) = Nothing
            Dim MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim AllMediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim FlowChartDateRanges As Generic.List(Of AdvantageFramework.MediaPlanning.FlowChart.FlowChartDateRange) = Nothing
            Dim FlowChartMarketAndVendors As Generic.List(Of AdvantageFramework.MediaPlanning.FlowChart.FlowChartMarketAndVendor) = Nothing
            Dim QuarterStartDate As Date = Date.MinValue
            Dim QuarterEndDate As Date = Date.MinValue

            CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                            .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                            .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                            .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                            .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                            .BackgroundColor = FlowChart.FlowChartMediaPlanOptions.GrandTotalsAreaColor, .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center}

            _CurrentColumn = 0

            MediaPlanEstimates = FlowChart.FlowChartEstimates.Select(Function(Entity) Entity.MediaPlanEstimate).ToList

            AllMediaPlanFlowChartDatas = New Generic.List(Of AdvantageFramework.MediaPlanning.FlowChart.MediaPlanFlowChartData)

            Using DbContext = New AdvantageFramework.Database.DbContext(FlowChart.Session.ConnectionString, FlowChart.Session.UserCode)

                DbContext.Database.Connection.Open()

                For Each MPE In MediaPlanEstimates

                    MediaPlanFlowChartDatas = DbContext.Database.SqlQuery(Of MediaPlanFlowChartData)(String.Format("EXEC [dbo].[advsp_mediaplan_flowchart_data] {0}, {1}", MPE.MediaPlan.ID, MPE.ID)).ToList

                    If MediaPlanFlowChartDatas IsNot Nothing Then

                        For Each MPFCD In MediaPlanFlowChartDatas

                            If MPFCD.StartDate >= FlowChart.FlowChartMediaPlanOptions.StartDate AndAlso
                                    MPFCD.StartDate <= FlowChart.FlowChartMediaPlanOptions.EndDate Then

                                AllMediaPlanFlowChartDatas.Add(MPFCD)

                            End If

                        Next

                    End If

                Next

            End Using

            If FlowChart.FlowChartMediaPlanOptions.FlowChartSummaryOption = FlowChartSummaryOptions.ByMediaType Then

                SetCell(_CurrentRow, _CurrentColumn, "Media Type", CellStyle)
                SetCell(_CurrentRow, _CurrentColumn + 1, "Total", CellStyle)

            ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartSummaryOption = FlowChartSummaryOptions.ByMarket Then

                SetCell(_CurrentRow, _CurrentColumn, "Market", CellStyle)
                SetCell(_CurrentRow, _CurrentColumn + 1, "Total", CellStyle)

            ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartSummaryOption = FlowChartSummaryOptions.ByMarket_Vendor Then

                SetCell(_CurrentRow, _CurrentColumn, "Market\Vendor", CellStyle)
                SetCell(_CurrentRow, _CurrentColumn + 1, "Total", CellStyle)

            ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartSummaryOption = FlowChartSummaryOptions.ByVendor Then

                SetCell(_CurrentRow, _CurrentColumn, "Vendor", CellStyle)
                SetCell(_CurrentRow, _CurrentColumn + 1, "Total", CellStyle)

            ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartSummaryOption = FlowChartSummaryOptions.ByQuarter Then

                SetCell(_CurrentRow, _CurrentColumn, "Quarter", CellStyle)
                SetCell(_CurrentRow, _CurrentColumn + 1, "Total", CellStyle)

            ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartSummaryOption = FlowChartSummaryOptions.ByYear Then

                SetCell(_CurrentRow, _CurrentColumn, "Year", CellStyle)
                SetCell(_CurrentRow, _CurrentColumn + 1, "Total", CellStyle)

            End If

            _CurrentRow += 2

            CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                            .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
                                            .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
                                            .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
                                            .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
                                            .BackgroundColor = System.Drawing.Color.Empty}

            DataValueCellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                                     .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
                                                     .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
                                                     .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
                                                     .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.None},
                                                     .BackgroundColor = System.Drawing.Color.Empty}

            SetCellValueType(FlowChart.FlowChartMediaPlanOptions.GrandTotalsDisplayValue, FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar, DataValueCellStyle)

            If FlowChart.FlowChartMediaPlanOptions.FlowChartSummaryOption = FlowChartSummaryOptions.ByMediaType Then

                For Each MediaType In AllMediaPlanFlowChartDatas.Select(Function(MPFCD) MPFCD.MediaType).OrderBy(Function(MT) MT).Distinct

                    DataValue = 0

                    MediaPlanFlowChartDatas = AllMediaPlanFlowChartDatas.Where(Function(MPFCD) MPFCD.MediaType = MediaType).ToList

                    If MediaPlanFlowChartDatas IsNot Nothing AndAlso MediaPlanFlowChartDatas.Count > 0 Then

                        DataValue = GetDataValue(FlowChart.FlowChartMediaPlanOptions.GrandTotalsDisplayValue, FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar, MediaPlanFlowChartDatas)

                    End If

                    SetCell(_CurrentRow, _CurrentColumn, MediaType, CellStyle)
                    SetCell(_CurrentRow, _CurrentColumn + 1, DataValue, DataValueCellStyle)

                    _CurrentRow += 1

                Next

            ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartSummaryOption = FlowChartSummaryOptions.ByMarket Then

                For Each MarketName In AllMediaPlanFlowChartDatas.Select(Function(MPFCD) MPFCD.MarketName).OrderBy(Function(MN) MN).Distinct

                    DataValue = 0

                    MediaPlanFlowChartDatas = AllMediaPlanFlowChartDatas.Where(Function(MPFCD) MPFCD.MarketName = MarketName).ToList

                    If MediaPlanFlowChartDatas IsNot Nothing AndAlso MediaPlanFlowChartDatas.Count > 0 Then

                        DataValue = GetDataValue(FlowChart.FlowChartMediaPlanOptions.GrandTotalsDisplayValue, FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar, MediaPlanFlowChartDatas)

                    End If

                    SetCell(_CurrentRow, _CurrentColumn, MarketName, CellStyle)
                    SetCell(_CurrentRow, _CurrentColumn + 1, DataValue, DataValueCellStyle)

                    _CurrentRow += 1

                Next

            ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartSummaryOption = FlowChartSummaryOptions.ByMarket_Vendor Then

                FlowChartMarketAndVendors = New Generic.List(Of AdvantageFramework.MediaPlanning.FlowChart.FlowChartMarketAndVendor)

                For Each FlowChartMarketAndVendor In AllMediaPlanFlowChartDatas.Select(Function(MPFCD) New FlowChartMarketAndVendor(MPFCD.MarketName, MPFCD.VendorName)).Distinct.OrderBy(Function(Entity) Entity.MarketName).
                                                                                                                                                                                  ThenBy(Function(Entity) Entity.VendorName).ToList

                    If FlowChartMarketAndVendors.Contains(FlowChartMarketAndVendor) = False Then

                        FlowChartMarketAndVendors.Add(FlowChartMarketAndVendor)

                    End If

                Next

                For Each MarketAndVendor In FlowChartMarketAndVendors

                    DataValue = 0

                    MediaPlanFlowChartDatas = AllMediaPlanFlowChartDatas.Where(Function(MPFCD) MPFCD.MarketName = MarketAndVendor.MarketName AndAlso MPFCD.VendorName = MarketAndVendor.VendorName).ToList

                    If MediaPlanFlowChartDatas IsNot Nothing AndAlso MediaPlanFlowChartDatas.Count > 0 Then

                        DataValue = GetDataValue(FlowChart.FlowChartMediaPlanOptions.GrandTotalsDisplayValue, FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar, MediaPlanFlowChartDatas)

                    End If

                    If String.IsNullOrWhiteSpace(MarketAndVendor.MarketName) = False AndAlso String.IsNullOrWhiteSpace(MarketAndVendor.VendorName) = False Then

                        SetCell(_CurrentRow, _CurrentColumn, MarketAndVendor.MarketName & "\" & MarketAndVendor.VendorName, CellStyle)

                    ElseIf String.IsNullOrWhiteSpace(MarketAndVendor.MarketName) AndAlso String.IsNullOrWhiteSpace(MarketAndVendor.VendorName) = False Then

                        SetCell(_CurrentRow, _CurrentColumn, MarketAndVendor.VendorName, CellStyle)

                    ElseIf String.IsNullOrWhiteSpace(MarketAndVendor.MarketName) = False AndAlso String.IsNullOrWhiteSpace(MarketAndVendor.VendorName) Then

                        SetCell(_CurrentRow, _CurrentColumn, MarketAndVendor.MarketName, CellStyle)

                    ElseIf String.IsNullOrWhiteSpace(MarketAndVendor.MarketName) AndAlso String.IsNullOrWhiteSpace(MarketAndVendor.VendorName) Then

                        SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                    End If

                    SetCell(_CurrentRow, _CurrentColumn + 1, DataValue, DataValueCellStyle)

                    _CurrentRow += 1

                Next

            ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartSummaryOption = FlowChartSummaryOptions.ByVendor Then

                For Each VendorName In AllMediaPlanFlowChartDatas.Select(Function(MPFCD) MPFCD.VendorName).OrderBy(Function(VN) VN).Distinct

                    DataValue = 0

                    MediaPlanFlowChartDatas = AllMediaPlanFlowChartDatas.Where(Function(MPFCD) MPFCD.VendorName = VendorName).ToList

                    If MediaPlanFlowChartDatas IsNot Nothing AndAlso MediaPlanFlowChartDatas.Count > 0 Then

                        DataValue = GetDataValue(FlowChart.FlowChartMediaPlanOptions.GrandTotalsDisplayValue, FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar, MediaPlanFlowChartDatas)

                    End If

                    SetCell(_CurrentRow, _CurrentColumn, VendorName, CellStyle)
                    SetCell(_CurrentRow, _CurrentColumn + 1, DataValue, DataValueCellStyle)

                    _CurrentRow += 1

                Next

            ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartSummaryOption = FlowChartSummaryOptions.ByQuarter Then

                FlowChartDateRanges = New Generic.List(Of AdvantageFramework.MediaPlanning.FlowChart.FlowChartDateRange)

                For Each [Date] In AllMediaPlanFlowChartDatas.Select(Function(MPFCD) MPFCD.StartDate).Distinct

                    QuarterStartDate = Date.MinValue
                    QuarterEndDate = Date.MinValue

                    AdvantageFramework.DateUtilities.GetQuarterStartDateAndEndDate([Date], QuarterStartDate, QuarterEndDate)

                    If FlowChartDateRanges.Any(Function(Entity) Entity.StartDate = QuarterStartDate) = False Then

                        FlowChartDateRanges.Add(New FlowChartDateRange(QuarterStartDate, QuarterEndDate))

                    End If

                Next

                For Each FlowChartDateRange In FlowChartDateRanges.OrderBy(Function(Entity) Entity.StartDate).ToList

                    DataValue = 0

                    MediaPlanFlowChartDatas = AllMediaPlanFlowChartDatas.Where(Function(MPFCD) MPFCD.StartDate >= FlowChartDateRange.StartDate AndAlso MPFCD.StartDate <= FlowChartDateRange.EndDate).ToList

                    If MediaPlanFlowChartDatas IsNot Nothing AndAlso MediaPlanFlowChartDatas.Count > 0 Then

                        DataValue = GetDataValue(FlowChart.FlowChartMediaPlanOptions.GrandTotalsDisplayValue, FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar, MediaPlanFlowChartDatas)

                    End If

                    SetCell(_CurrentRow, _CurrentColumn, "Q" & AdvantageFramework.DateUtilities.GetQuarter(FlowChartDateRange.StartDate) & "\" & FlowChartDateRange.StartDate.Year, CellStyle)
                    SetCell(_CurrentRow, _CurrentColumn + 1, DataValue, DataValueCellStyle)

                    _CurrentRow += 1

                Next

            ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartSummaryOption = FlowChartSummaryOptions.ByYear Then

                For Each StartDateYear In AllMediaPlanFlowChartDatas.Select(Function(MPFCD) MPFCD.StartDate.Year).OrderBy(Function(Year) Year).Distinct

                    DataValue = 0

                    MediaPlanFlowChartDatas = AllMediaPlanFlowChartDatas.Where(Function(MPFCD) MPFCD.StartDate.Year = StartDateYear).ToList

                    If MediaPlanFlowChartDatas IsNot Nothing AndAlso MediaPlanFlowChartDatas.Count > 0 Then

                        DataValue = GetDataValue(FlowChart.FlowChartMediaPlanOptions.GrandTotalsDisplayValue, FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar, MediaPlanFlowChartDatas)

                    End If

                    SetCell(_CurrentRow, _CurrentColumn, StartDateYear, CellStyle)
                    SetCell(_CurrentRow, _CurrentColumn + 1, DataValue, DataValueCellStyle)

                    _CurrentRow += 1

                Next

            End If

            DataValue = 0

            If AllMediaPlanFlowChartDatas IsNot Nothing AndAlso AllMediaPlanFlowChartDatas.Count > 0 Then

                DataValue = GetDataValue(FlowChart.FlowChartMediaPlanOptions.GrandTotalsDisplayValue, FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar, AllMediaPlanFlowChartDatas)

            End If

            SetCell(_CurrentRow, _CurrentColumn, "Grand Total", CellStyle)
            SetCell(_CurrentRow, _CurrentColumn + 1, DataValue, DataValueCellStyle)

            _CurrentRow += 1

        End Sub
        Private Function GetDataValue(FlowChartEstimate As FlowChartEstimate, MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)) As Double

            GetDataValue = GetDataValue(FlowChartEstimate.FlowChartMediaPlanEstimateOptions.DisplayValue,
                                        FlowChartEstimate.FlowChartMediaPlanEstimateOptions.BlockingChart,
                                        FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar,
                                        MediaPlanDetailLevelLineDatas)

        End Function
        Private Function GetDataValue(DisplayValue As AdvantageFramework.MediaPlanning.FlowChart.DataColumns, IsBlockingChart As Boolean,
                                      RoundToNearestDollar As Boolean,
                                      MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)) As Double

            'objects
            Dim DataValue As Double = 0
            Dim Columns As Decimal = 0
            Dim Inches As Decimal = 0

            If IsBlockingChart = False Then

                If DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.AgencyFee Then

                    DataValue = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.AgencyFee.GetValueOrDefault(0)).Sum

                    If RoundToNearestDollar Then

                        DataValue = Math.Round(DataValue, 0)

                    End If

                ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.BillAmount Then

                    DataValue = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.BillAmount.GetValueOrDefault(0)).Sum

                    If RoundToNearestDollar Then

                        DataValue = Math.Round(DataValue, 0)

                    End If

                ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Dollars Then

                    DataValue = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Dollars.GetValueOrDefault(0)).Sum

                    If RoundToNearestDollar Then

                        DataValue = Math.Round(DataValue, 0)

                    End If

                ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Rate Then

                    DataValue = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Rate.GetValueOrDefault(0)).FirstOrDefault

                ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Clicks Then

                    DataValue = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Clicks.GetValueOrDefault(0)).Sum

                ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Impressions Then

                    DataValue = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Impressions.GetValueOrDefault(0)).Sum

                ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Units Then

                    DataValue = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Units.GetValueOrDefault(0)).Sum

                ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Columns Then

                    Columns = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Columns.GetValueOrDefault(0)).Sum
                    Inches = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.InchesLines.GetValueOrDefault(0)).Sum

                    DataValue = FormatNumber(Columns, 2, TriState.False, TriState.False, TriState.False) * FormatNumber(Inches, 2, TriState.False, TriState.False, TriState.False)

                ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.InchesLines Then

                    DataValue = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.InchesLines.GetValueOrDefault(0)).Sum

                ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Demo1 Then

                    DataValue = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Demo1.GetValueOrDefault(0)).Sum

                ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Demo2 Then

                    DataValue = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Demo2.GetValueOrDefault(0)).Sum

                ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.NetCharge Then

                    DataValue = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.NetCharge.GetValueOrDefault(0)).Sum

                    If RoundToNearestDollar Then

                        DataValue = Math.Round(DataValue, 0)

                    End If

                End If

            End If

            GetDataValue = DataValue

        End Function
        Private Function GetDataValue(DisplayValue As AdvantageFramework.MediaPlanning.FlowChart.DataColumns, RoundToNearestDollar As Boolean, MediaPlanFlowChartDatas As Generic.List(Of AdvantageFramework.MediaPlanning.FlowChart.MediaPlanFlowChartData)) As Double

            'objects
            Dim DataValue As Double = 0
            Dim Columns As Decimal = 0
            Dim Inches As Decimal = 0

            If DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.AgencyFee Then

                DataValue = MediaPlanFlowChartDatas.Select(Function(Entity) Entity.AgencyFee.GetValueOrDefault(0)).Sum

                If RoundToNearestDollar Then

                    DataValue = Math.Round(DataValue, 0)

                End If

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.BillAmount Then

                DataValue = MediaPlanFlowChartDatas.Select(Function(Entity) Entity.BillAmount.GetValueOrDefault(0)).Sum

                If RoundToNearestDollar Then

                    DataValue = Math.Round(DataValue, 0)

                End If

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Dollars Then

                DataValue = MediaPlanFlowChartDatas.Select(Function(Entity) Entity.Dollars.GetValueOrDefault(0)).Sum

                If RoundToNearestDollar Then

                    DataValue = Math.Round(DataValue, 0)

                End If

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Rate Then

                DataValue = MediaPlanFlowChartDatas.Select(Function(Entity) Entity.Rate.GetValueOrDefault(0)).FirstOrDefault

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Clicks Then

                DataValue = MediaPlanFlowChartDatas.Select(Function(Entity) Entity.Clicks.GetValueOrDefault(0)).Sum

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Impressions Then

                DataValue = MediaPlanFlowChartDatas.Select(Function(Entity) Entity.Impressions.GetValueOrDefault(0)).Sum

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Units Then

                DataValue = MediaPlanFlowChartDatas.Select(Function(Entity) Entity.Units.GetValueOrDefault(0)).Sum

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Columns Then

                Columns = MediaPlanFlowChartDatas.Select(Function(Entity) Entity.Columns.GetValueOrDefault(0)).Sum
                Inches = MediaPlanFlowChartDatas.Select(Function(Entity) Entity.InchesLines.GetValueOrDefault(0)).Sum

                DataValue = FormatNumber(Columns, 2, TriState.False, TriState.False, TriState.False) * FormatNumber(Inches, 2, TriState.False, TriState.False, TriState.False)

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.InchesLines Then

                DataValue = MediaPlanFlowChartDatas.Select(Function(Entity) Entity.InchesLines.GetValueOrDefault(0)).Sum

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Demo1 Then

                DataValue = MediaPlanFlowChartDatas.Select(Function(Entity) Entity.Demo1.GetValueOrDefault(0)).Sum

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Demo2 Then

                DataValue = MediaPlanFlowChartDatas.Select(Function(Entity) Entity.Demo2.GetValueOrDefault(0)).Sum

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.NetCharge Then

                DataValue = MediaPlanFlowChartDatas.Select(Function(Entity) Entity.NetCharge.GetValueOrDefault(0)).Sum

                If RoundToNearestDollar Then

                    DataValue = Math.Round(DataValue, 0)

                End If

            End If

            GetDataValue = DataValue

        End Function
        'Private Function CalculateRate(MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), IsForTotals As Boolean) As Double

        '    'objects
        '    Dim Rate As Decimal = 0
        '    Dim Dollars As Decimal = 0
        '    Dim Quantity As Decimal = 0
        '    Dim DataColumns As Generic.List(Of System.Data.DataColumn) = Nothing
        '    Dim QuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = AdvantageFramework.MediaPlanning.DataColumns.ID
        '    Dim PreviousQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = AdvantageFramework.MediaPlanning.DataColumns.ID
        '    Dim UseAverageCalcuation As Boolean = False

        '    If MediaPlanDetailLevelLineDatas IsNot Nothing AndAlso MediaPlanDetailLevelLineDatas.Count > 0 Then

        '        If IsForTotals Then

        '            DataColumns = MediaPlanEstimate.EstimateDataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Area.ToString) = 3 AndAlso DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.IsVisible.ToString) = True).OrderBy(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.AreaIndex.ToString)).ToList

        '            For Each DataColumn In DataColumns.ToList

        '                If (DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString OrElse
        '                        DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString OrElse
        '                        DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString OrElse
        '                        DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString OrElse
        '                        DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString) = False Then

        '                    DataColumns.Remove(DataColumn)

        '                End If

        '            Next

        '            For Each PivotDrillDownDataRow In PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)

        '                QuantityColumn = AdvantageFramework.MediaPlanning.GetQuantityColumn(MediaPlanEstimate, PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString),
        '                                                                                                    PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString),
        '                                                                                                    PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString),
        '                                                                                                    PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Units.ToString),
        '                                                                                                    PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString),
        '                                                                                                    PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString),
        '                                                                                                    DataColumns)

        '                If QuantityColumn <> AdvantageFramework.MediaPlanning.DataColumns.ID Then

        '                    If QuantityColumn = MediaPlanning.Methods.DataColumns.Units Then

        '                        If MediaPlanEstimate.CheckForUnitsQuantity(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)) Then

        '                            If MediaPlanEstimate.CheckForUnitsCPM(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)) Then

        '                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
        '                                Dollars += (CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)) * 1000)

        '                            Else

        '                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
        '                                Dollars += CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))

        '                            End If

        '                        Else

        '                            If MediaPlanEstimate.IsUnitsCPM Then

        '                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
        '                                Dollars += (CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)) * 1000)

        '                            Else

        '                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
        '                                Dollars += CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))

        '                            End If

        '                        End If

        '                    ElseIf QuantityColumn = MediaPlanning.Methods.DataColumns.Impressions Then

        '                        If MediaPlanEstimate.CheckForImpressionsQuantity(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)) Then

        '                            If MediaPlanEstimate.CheckForImpressionsCPM(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)) Then

        '                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
        '                                Dollars += (CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)) * 1000)

        '                            Else

        '                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
        '                                Dollars += CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))

        '                            End If

        '                        Else

        '                            If MediaPlanEstimate.IsImpressionsCPM Then

        '                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
        '                                Dollars += (CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)) * 1000)

        '                            Else

        '                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
        '                                Dollars += CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))

        '                            End If

        '                        End If

        '                    ElseIf QuantityColumn = MediaPlanning.Methods.DataColumns.Clicks Then

        '                        If MediaPlanEstimate.CheckForClicksQuantity(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)) Then

        '                            If MediaPlanEstimate.CheckForClicksCPM(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)) Then

        '                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
        '                                Dollars += (CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)) * 1000)

        '                            Else

        '                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
        '                                Dollars += CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))

        '                            End If

        '                        Else

        '                            If MediaPlanEstimate.IsClicksCPM Then

        '                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
        '                                Dollars += (CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)) * 1000)

        '                            Else

        '                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
        '                                Dollars += CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))

        '                            End If

        '                        End If

        '                    Else

        '                        Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
        '                        Dollars += CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))

        '                    End If

        '                    If PreviousQuantityColumn = MediaPlanning.Methods.DataColumns.ID Then

        '                        PreviousQuantityColumn = QuantityColumn

        '                    ElseIf PreviousQuantityColumn <> QuantityColumn Then

        '                        UseAverageCalcuation = True
        '                        Exit For

        '                    End If

        '                End If

        '            Next

        '            If UseAverageCalcuation Then

        '                Rate = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Rate.GetValueOrDefault(0)).Average

        '            Else

        '                If Quantity <> 0 Then

        '                    Rate = Dollars / Quantity

        '                Else

        '                    Rate = 0

        '                End If

        '            End If

        '        Else

        '            Rate = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Rate.GetValueOrDefault(0)).Average

        '        End If

        '    Else

        '        Rate = 0

        '    End If

        '    CalculateRate = Rate

        'End Function
        Private Sub SetCellValueType(FlowChartEstimate As FlowChartEstimate, ByRef CellStyle As CellStyle)

            SetCellValueType(FlowChartEstimate.FlowChartMediaPlanEstimateOptions.DisplayValue, FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar, CellStyle)

        End Sub
        Private Sub SetCellValueType(DisplayValue As AdvantageFramework.MediaPlanning.FlowChart.DataColumns, RoundToNearestDollar As Boolean, ByRef CellStyle As CellStyle)

            If DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.AgencyFee Then

                If RoundToNearestDollar Then

                    CellStyle.CellValueType = CellValueType.Currency
                    CellStyle.DisplayString = "$#,##0"

                Else

                    CellStyle.CellValueType = CellValueType.Currency

                End If

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.BillAmount Then

                If RoundToNearestDollar Then

                    CellStyle.CellValueType = CellValueType.Currency
                    CellStyle.DisplayString = "$#,##0"

                Else

                    CellStyle.CellValueType = CellValueType.Currency

                End If

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Dollars Then

                If RoundToNearestDollar Then

                    CellStyle.CellValueType = CellValueType.Currency
                    CellStyle.DisplayString = "$#,##0"

                Else

                    CellStyle.CellValueType = CellValueType.Currency

                End If

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Rate Then

                CellStyle.CellValueType = CellValueType.Currency

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Clicks Then

                CellStyle.CellValueType = CellValueType.Integer

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Impressions Then

                CellStyle.CellValueType = CellValueType.Integer

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Columns Then

                CellStyle.CellValueType = CellValueType.Text

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.InchesLines Then

                CellStyle.CellValueType = CellValueType.Decimal
                CellStyle.DisplayString = "#,##0.00"

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Units Then

                CellStyle.CellValueType = CellValueType.Decimal
                CellStyle.DisplayString = "#,##0"

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Demo1 Then

                CellStyle.CellValueType = CellValueType.Decimal
                CellStyle.DisplayString = "#,##0.0"

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Demo2 Then

                CellStyle.CellValueType = CellValueType.Decimal
                CellStyle.DisplayString = "#,##0.0"

            ElseIf DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.NetCharge Then

                If RoundToNearestDollar Then

                    CellStyle.CellValueType = CellValueType.Currency
                    CellStyle.DisplayString = "$#,##0"

                Else

                    CellStyle.CellValueType = CellValueType.Currency

                End If

            End If

        End Sub
        Private Sub CreateDateHeaderRow(FlowChartEstimate As FlowChartEstimate, FieldID As String)

            'objects
            Dim IsCalendarMonth As Boolean = False
            Dim WeekDisplayType As AdvantageFramework.MediaPlanning.WeekDisplayTypes = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekNumber

            If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                IsCalendarMonth = FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth

            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                IsCalendarMonth = False

            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                IsCalendarMonth = True

            End If

            If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartWeekDisplayType = FlowChartWeekDisplayTypes.FromPlan Then

                WeekDisplayType = FlowChartEstimate.MediaPlanEstimate.WeekDisplayType

            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartWeekDisplayType = FlowChartWeekDisplayTypes.WeekNumber Then

                WeekDisplayType = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekNumber

            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartWeekDisplayType = FlowChartWeekDisplayTypes.WeekStartDate Then

                WeekDisplayType = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekStartDate

            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartWeekDisplayType = FlowChartWeekDisplayTypes.WeekStartDay Then

                WeekDisplayType = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekStartDay

            End If

            CreateDateHeaderRow(FlowChartEstimate.FlowChart, FieldID, IsCalendarMonth, WeekDisplayType, FlowChartEstimate.FlowChartMediaPlanEstimateOptions.PrintDateHeader)

        End Sub
        Private Sub CreateDateHeaderRow(FlowChartEstimate As FlowChartEstimate, FieldID As String, PrintDateHeader As Boolean)

            'objects
            Dim IsCalendarMonth As Boolean = False
            Dim WeekDisplayType As AdvantageFramework.MediaPlanning.WeekDisplayTypes = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekNumber

            If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                IsCalendarMonth = FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth

            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                IsCalendarMonth = False

            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                IsCalendarMonth = True

            End If

            If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartWeekDisplayType = FlowChartWeekDisplayTypes.FromPlan Then

                WeekDisplayType = FlowChartEstimate.MediaPlanEstimate.WeekDisplayType

            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartWeekDisplayType = FlowChartWeekDisplayTypes.WeekNumber Then

                WeekDisplayType = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekNumber

            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartWeekDisplayType = FlowChartWeekDisplayTypes.WeekStartDate Then

                WeekDisplayType = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekStartDate

            ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartWeekDisplayType = FlowChartWeekDisplayTypes.WeekStartDay Then

                WeekDisplayType = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekStartDay

            End If

            CreateDateHeaderRow(FlowChartEstimate.FlowChart, FieldID, IsCalendarMonth, WeekDisplayType, PrintDateHeader)

        End Sub
        Private Sub CreateDateHeaderRow(FlowChart As FlowChart, FieldID As String,
                                        IsCalendarMonth As Boolean, WeekDisplayType As AdvantageFramework.MediaPlanning.WeekDisplayTypes,
                                        PrintDateHeader As Boolean)

            'objects
            Dim LastColumn As Integer = -1
            Dim LastDate As Date = Date.MinValue
            Dim [Date] As Date = Date.MinValue
            Dim Range As Aspose.Cells.Range = Nothing
            Dim Style As Aspose.Cells.Style = Nothing
            Dim CellStyle As CellStyle = Nothing
            Dim Week As Integer = -1
            Dim WeekStartDate As Date = Date.MinValue
            Dim WeekEndDate As Date = Date.MinValue
            Dim Month As Integer = -1
            Dim MonthName As String = String.Empty
            Dim MonthStartDate As Date = Date.MinValue
            Dim MonthEndDate As Date = Date.MinValue
            Dim Quarter As Integer = -1
            Dim QuarterStartDate As Date = Date.MinValue
            Dim QuarterEndDate As Date = Date.MinValue
            Dim YearStartDate As Date = Date.MinValue
            Dim YearEndDate As Date = Date.MinValue
            Dim Year As Integer = -1

            LastColumn = _CurrentColumn

            If PrintDateHeader Then

                If FieldID = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString OrElse
                        FieldID = AdvantageFramework.MediaPlanning.DataColumns.Date.ToString Then

                    LastDate = FlowChart.FlowChartEstimateDates(0).Date

                ElseIf FieldID = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                    If IsCalendarMonth Then

                        LastDate = FlowChart.FlowChartEstimateDates(0).WeekStartDate

                    Else

                        LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastWeekStartDate

                    End If

                ElseIf FieldID = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                        FieldID = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                    If IsCalendarMonth Then

                        LastDate = FlowChart.FlowChartEstimateDates(0).MonthStartDate

                    Else

                        LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastMonthStartDate

                    End If

                ElseIf FieldID = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString Then

                    If IsCalendarMonth Then

                        LastDate = FlowChart.FlowChartEstimateDates(0).QuarterStartDate

                    Else

                        LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastQuarterStartDate

                    End If

                ElseIf FieldID = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString Then

                    If IsCalendarMonth Then

                        LastDate = FlowChart.FlowChartEstimateDates(0).YearStartDate

                    Else

                        LastDate = FlowChart.FlowChartEstimateDates(0).BroadcastYearStartDate

                    End If

                End If

                For Each FlowChartEstimateDate In FlowChart.FlowChartEstimateDates

                    [Date] = FlowChartEstimateDate.Date

                    If IsCalendarMonth Then

                        Week = FlowChartEstimateDate.Week
                        WeekStartDate = FlowChartEstimateDate.WeekStartDate
                        WeekEndDate = FlowChartEstimateDate.WeekEndDate
                        Month = FlowChartEstimateDate.Month
                        MonthName = FlowChartEstimateDate.MonthName
                        MonthStartDate = FlowChartEstimateDate.MonthStartDate
                        MonthEndDate = FlowChartEstimateDate.MonthEndDate
                        Quarter = FlowChartEstimateDate.Quarter
                        QuarterStartDate = FlowChartEstimateDate.QuarterStartDate
                        QuarterEndDate = FlowChartEstimateDate.QuarterEndDate
                        Year = FlowChartEstimateDate.Year
                        YearStartDate = FlowChartEstimateDate.YearStartDate
                        YearEndDate = FlowChartEstimateDate.YearEndDate

                    Else

                        Week = FlowChartEstimateDate.BroadcastWeek
                        WeekStartDate = FlowChartEstimateDate.BroadcastWeekStartDate
                        WeekEndDate = FlowChartEstimateDate.BroadcastWeekEndDate
                        Month = FlowChartEstimateDate.BroadcastMonth
                        MonthName = FlowChartEstimateDate.BroadcastMonthName
                        MonthStartDate = FlowChartEstimateDate.BroadcastMonthStartDate
                        MonthEndDate = FlowChartEstimateDate.BroadcastMonthEndDate
                        Quarter = FlowChartEstimateDate.BroadcastQuarter
                        QuarterStartDate = FlowChartEstimateDate.BroadcastQuarterStartDate
                        QuarterEndDate = FlowChartEstimateDate.BroadcastQuarterEndDate
                        Year = FlowChartEstimateDate.BroadcastYear
                        YearStartDate = FlowChartEstimateDate.BroadcastYearStartDate
                        YearEndDate = FlowChartEstimateDate.BroadcastYearEndDate

                    End If

                    CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                                    .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                    .BackgroundColor = FlowChart.FlowChartMediaPlanOptions.DateHeaderColor}

                    If FieldID = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString Then

                        SetCell(_CurrentRow, _CurrentColumn, [Date].Day, CellStyle)

                    ElseIf FieldID = AdvantageFramework.MediaPlanning.DataColumns.Date.ToString Then

                        SetCell(_CurrentRow, _CurrentColumn, [Date].ToShortDateString, CellStyle)

                    ElseIf FieldID = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                        If FlowChart.FlowChartMediaPlanOptions.FlowChartWeekDisplayType = FlowChartWeekDisplayTypes.FromPlan Then

                            If WeekDisplayType = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekNumber Then

                                SetCell(_CurrentRow, _CurrentColumn, Week, CellStyle)

                            ElseIf WeekDisplayType = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekStartDate Then

                                SetCell(_CurrentRow, _CurrentColumn, WeekStartDate.ToString("MM/dd"), CellStyle)

                            ElseIf WeekDisplayType = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekStartDay Then

                                SetCell(_CurrentRow, _CurrentColumn, WeekStartDate.Day, CellStyle)

                            End If

                        Else

                            If FlowChart.FlowChartMediaPlanOptions.FlowChartWeekDisplayType = FlowChartWeekDisplayTypes.WeekNumber Then

                                SetCell(_CurrentRow, _CurrentColumn, Week, CellStyle)

                            ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartWeekDisplayType = FlowChartWeekDisplayTypes.WeekStartDate Then

                                SetCell(_CurrentRow, _CurrentColumn, WeekStartDate.ToString("MM/dd"), CellStyle)

                            ElseIf FlowChart.FlowChartMediaPlanOptions.FlowChartWeekDisplayType = FlowChartWeekDisplayTypes.WeekStartDay Then

                                SetCell(_CurrentRow, _CurrentColumn, WeekStartDate.Day, CellStyle)

                            End If

                        End If

                        If LastDate <> WeekStartDate Then

                            Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                            SetRange(Range, CellStyle)

                            Range.Merge()

                            LastColumn = _CurrentColumn
                            LastDate = WeekStartDate

                        End If

                    ElseIf FieldID = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString Then

                        SetCell(_CurrentRow, _CurrentColumn, Month, CellStyle)

                        If LastDate <> MonthStartDate Then

                            Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                            SetRange(Range, CellStyle)

                            Range.Merge()

                            LastColumn = _CurrentColumn
                            LastDate = MonthStartDate

                        End If

                    ElseIf FieldID = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                        SetCell(_CurrentRow, _CurrentColumn, MonthName, CellStyle)

                        If LastDate <> MonthStartDate Then

                            Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                            SetRange(Range, CellStyle)

                            Range.Merge()

                            LastColumn = _CurrentColumn
                            LastDate = MonthStartDate

                        End If

                    ElseIf FieldID = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString Then

                        SetCell(_CurrentRow, _CurrentColumn, Quarter, CellStyle)

                        If LastDate <> QuarterStartDate Then

                            Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                            SetRange(Range, CellStyle)

                            Range.Merge()

                            LastColumn = _CurrentColumn
                            LastDate = QuarterStartDate

                        End If

                    ElseIf FieldID = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString Then

                        SetCell(_CurrentRow, _CurrentColumn, Year, CellStyle)

                        If LastDate <> YearStartDate Then

                            Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                            SetRange(Range, CellStyle)

                            Range.Merge()

                            LastColumn = _CurrentColumn
                            LastDate = YearStartDate

                        End If

                    End If

                    _CurrentColumn += 1

                Next

                If (FieldID = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString OrElse
                        FieldID = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                        FieldID = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString OrElse
                        FieldID = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString OrElse
                        FieldID = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString) AndAlso
                    (_CurrentColumn - LastColumn) > 1 Then

                    Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                    SetRange(Range, CellStyle)

                    Range.Merge()

                End If

            Else

                CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                                .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .BackgroundColor = FlowChart.FlowChartMediaPlanOptions.DateHeaderColor}

                For Each FlowChartEstimateDate In FlowChart.FlowChartEstimateDates

                    SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                    _CurrentColumn += 1

                Next

                Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                SetRange(Range, CellStyle)

                Range.Merge()

            End If

        End Sub
        Private Sub CreateRowGrandTotalsColumnHeader(FlowChartEstimate As FlowChartEstimate)

            'objects
            Dim CellStyle As CellStyle = Nothing

            If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowEstimateRowTotals Then

                _CurrentColumn = 0

                For RC As Integer = _CurrentColumn To FlowChartEstimate.FlowChart.NumberOfLevels - 1

                    _CurrentColumn += 1

                Next

                For Each FlowChartEstimateDate In FlowChartEstimate.FlowChart.FlowChartEstimateDates

                    _CurrentColumn += 1

                Next

                CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                                .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .BackgroundColor = FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.GrandTotalsAreaColor, .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center}

                SetCell(_CurrentRow, _CurrentColumn, "Grand Totals", CellStyle)

                _CurrentColumn += 1

            End If

        End Sub
        Private Sub CreateRowGrandTotalsColumns(FlowChartEstimate As FlowChartEstimate, RowIndexes As Generic.List(Of Integer))

            'objects
            Dim CellStyle As CellStyle = Nothing
            Dim MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim DataValue As Double = 0

            If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.ShowEstimateRowTotals Then

                _CurrentColumn = 0

                For RC As Integer = _CurrentColumn To FlowChartEstimate.FlowChart.NumberOfLevels - 1

                    _CurrentColumn += 1

                Next

                For Each FlowChartEstimateDate In FlowChartEstimate.FlowChart.FlowChartEstimateDates

                    _CurrentColumn += 1

                Next

                CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                                .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .BackgroundColor = FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.GrandTotalsAreaColor,
                                                .HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center}

                SetCellValueType(FlowChartEstimate, CellStyle)

                MediaPlanDetailLevelLineDatas = FlowChartEstimate.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) RowIndexes.Contains(Entity.RowIndex) AndAlso
                                                                                                                                         Entity.StartDate >= FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.StartDate AndAlso
                                                                                                                                         Entity.StartDate <= FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.EndDate).ToList

                If MediaPlanDetailLevelLineDatas.Count > 0 Then

                    DataValue = GetDataValue(FlowChartEstimate.FlowChartMediaPlanEstimateOptions.DisplayValue, False,
                                             FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.RoundToNearestDollar,
                                             MediaPlanDetailLevelLineDatas)

                End If

                SetCell(_CurrentRow, _CurrentColumn, DataValue, CellStyle)

                _CurrentColumn += 1

            End If

        End Sub
        Private Sub CreateEstimateFieldHeader(FlowChartEstimate As FlowChartEstimate)

            'objects
            Dim LastColumn As Integer = -1
            Dim Range As Aspose.Cells.Range = Nothing
            Dim CellStyle As CellStyle = Nothing
            Dim FlowChartEstimateLevels As Generic.List(Of FlowChartEstimateLevel) = Nothing

            _CurrentColumn = 0

            If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.PrintFieldHeader Then

                CellStyle = New CellStyle With {.IsItalic = False, .IsBold = True, .Underline = False,
                                                .LeftBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .RightBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .TopBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .BottomBorder = New CellBorder With {.CellBorderType = Aspose.Cells.CellBorderType.Thin},
                                                .BackgroundColor = FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FieldAreaColor}

                If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.GroupByLevel = GroupByLevels.None Then

                    For Each FlowChartEstimateLevel In FlowChartEstimate.FlowChartEstimateLevels.Where(Function(Entity) Entity.IsVisible = True).OrderBy(Function(Entity) Entity.OrderNumber).ToList

                        SetCell(_CurrentRow, _CurrentColumn, FlowChartEstimateLevel.Description, CellStyle)

                        _CurrentColumn += 1

                    Next

                Else

                    FlowChartEstimateLevels = FlowChartEstimate.FlowChartEstimateLevels.Where(Function(Entity) Entity.IsVisible = True AndAlso Entity.OrderNumber <= FlowChartEstimate.FlowChartMediaPlanEstimateOptions.GroupByLevel - 1).OrderBy(Function(Entity) Entity.OrderNumber).ToList

                    If FlowChartEstimateLevels IsNot Nothing Then

                        For Each FlowChartEstimateLevel In FlowChartEstimateLevels

                            SetCell(_CurrentRow, _CurrentColumn, FlowChartEstimateLevel.Description, CellStyle)

                            _CurrentColumn += 1

                        Next

                    End If

                End If

                LastColumn = _CurrentColumn

                For RC As Integer = _CurrentColumn To FlowChartEstimate.FlowChart.NumberOfLevels - 1

                    SetCell(_CurrentRow, _CurrentColumn, String.Empty, CellStyle)

                    _CurrentColumn += 1

                Next

                If _CurrentColumn - LastColumn > 0 Then

                    Range = _Worksheet.Cells.CreateRange(_CurrentRow, LastColumn, 1, _CurrentColumn - LastColumn)

                    Range.Merge()

                End If

            End If

        End Sub
        Public Sub SaveAs(Session As AdvantageFramework.Security.Session, IsASP As Boolean, FileName As String)

            _Workbook.Save(FileName)

            If IsASP Then

                If AdvantageFramework.Email.SendASPReportDownloadEmail(Session, FileName) Then

                    AdvantageFramework.Navigation.ShowMessageBox("Flow chart created successfully and also email link has been sent to your email.")

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Flow chart created successfully!")

                End If

            End If

        End Sub
        Public Sub SaveAsAndOpen(Session As AdvantageFramework.Security.Session, IsASP As Boolean, FileName As String)

            _Workbook.Save(FileName)

            If IsASP Then

                If AdvantageFramework.Email.SendASPReportDownloadEmail(Session, FileName) Then

                    AdvantageFramework.Navigation.ShowMessageBox("Flow chart created successfully and also email link has been sent to your email.")

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Flow chart created successfully!")

                End If

            Else

                Process.Start(FileName)

            End If

        End Sub
        Private Sub SetCell(Row As Integer, Column As Integer, Value As Object, CellStyle As CellStyle)

            'objects
            Dim Cell As Aspose.Cells.Cell = Nothing
            Dim Style As Aspose.Cells.Style = Nothing

            Cell = _Worksheet.Cells(Row, Column)

            Style = Cell.GetStyle

            Style.Font.IsItalic = CellStyle.IsItalic
            Style.Font.IsBold = CellStyle.IsBold

            Style.HorizontalAlignment = CellStyle.HorizontalAlignment
            Style.VerticalAlignment = CellStyle.VerticalAlignment
            Style.IsTextWrapped = CellStyle.TextWrapped

            ' Style.IsGradient = True
            If CellStyle.BackgroundColor.ToArgb <> System.Drawing.Color.Empty.ToArgb Then

                Style.Pattern = Aspose.Cells.BackgroundType.Solid
                Style.ForegroundArgbColor = CellStyle.BackgroundColor.ToArgb()

            End If
            'Style.ForegroundArgbColor = CellStyle.BackgroundColor.ToArgb()
            Style.Font.Color = CellStyle.FontColor

            If CellStyle.Underline Then

                Style.Font.Underline = Aspose.Cells.FontUnderlineType.Single

            End If

            If CellStyle.TopBorder.CellBorderType <> Aspose.Cells.CellBorderType.None Then

                Style.SetBorder(Aspose.Cells.BorderType.TopBorder, CellStyle.TopBorder.CellBorderType, CellStyle.TopBorder.Color)

            End If

            If CellStyle.BottomBorder.CellBorderType <> Aspose.Cells.CellBorderType.None Then

                Style.SetBorder(Aspose.Cells.BorderType.BottomBorder, CellStyle.BottomBorder.CellBorderType, CellStyle.BottomBorder.Color)

            End If

            If CellStyle.LeftBorder.CellBorderType <> Aspose.Cells.CellBorderType.None Then

                Style.SetBorder(Aspose.Cells.BorderType.LeftBorder, CellStyle.LeftBorder.CellBorderType, CellStyle.LeftBorder.Color)

            End If

            If CellStyle.RightBorder.CellBorderType <> Aspose.Cells.CellBorderType.None Then

                Style.SetBorder(Aspose.Cells.BorderType.RightBorder, CellStyle.RightBorder.CellBorderType, CellStyle.RightBorder.Color)

            End If

            If String.IsNullOrWhiteSpace(CellStyle.DisplayString) = False Then

                Style.Custom = CellStyle.DisplayString

            End If

            Cell.SetStyle(Style)

            Cell.Value = Value

        End Sub
        Private Sub SetRange(Range As Aspose.Cells.Range, Value As Object, CellStyle As CellStyle)

            'objects
            Dim Style As Aspose.Cells.Style = Nothing

            Range.Value = Value

            Style = Range(0, 0).GetStyle

            Style.Font.IsItalic = CellStyle.IsItalic
            Style.Font.IsBold = CellStyle.IsBold

            Style.HorizontalAlignment = CellStyle.HorizontalAlignment
            Style.VerticalAlignment = CellStyle.VerticalAlignment

            ' Style.IsGradient = True
            If CellStyle.BackgroundColor <> System.Drawing.Color.Empty Then

                Style.Pattern = Aspose.Cells.BackgroundType.Solid
                Style.ForegroundArgbColor = CellStyle.BackgroundColor.ToArgb()

            End If
            'Style.ForegroundArgbColor = CellStyle.BackgroundColor.ToArgb()
            Style.Font.Color = CellStyle.FontColor

            If CellStyle.Underline Then

                Style.Font.Underline = Aspose.Cells.FontUnderlineType.Single

            End If

            If CellStyle.TopBorder.CellBorderType <> Aspose.Cells.CellBorderType.None Then

                Style.SetBorder(Aspose.Cells.BorderType.TopBorder, CellStyle.TopBorder.CellBorderType, CellStyle.TopBorder.Color)

            End If

            If CellStyle.BottomBorder.CellBorderType <> Aspose.Cells.CellBorderType.None Then

                Style.SetBorder(Aspose.Cells.BorderType.BottomBorder, CellStyle.BottomBorder.CellBorderType, CellStyle.BottomBorder.Color)

            End If

            If CellStyle.LeftBorder.CellBorderType <> Aspose.Cells.CellBorderType.None Then

                Style.SetBorder(Aspose.Cells.BorderType.LeftBorder, CellStyle.LeftBorder.CellBorderType, CellStyle.LeftBorder.Color)

            End If

            If CellStyle.RightBorder.CellBorderType <> Aspose.Cells.CellBorderType.None Then

                Style.SetBorder(Aspose.Cells.BorderType.RightBorder, CellStyle.RightBorder.CellBorderType, CellStyle.RightBorder.Color)

            End If

            Range.SetStyle(Style)

        End Sub
        Private Sub SetRange(Range As Aspose.Cells.Range, CellStyle As CellStyle)

            'objects
            Dim Style As Aspose.Cells.Style = Nothing

            Style = Range(0, 0).GetStyle

            Style.Font.IsItalic = CellStyle.IsItalic
            Style.Font.IsBold = CellStyle.IsBold

            Style.HorizontalAlignment = CellStyle.HorizontalAlignment
            Style.VerticalAlignment = CellStyle.VerticalAlignment

            ' Style.IsGradient = True
            If CellStyle.BackgroundColor <> System.Drawing.Color.Empty Then

                Style.Pattern = Aspose.Cells.BackgroundType.Solid
                Style.ForegroundArgbColor = CellStyle.BackgroundColor.ToArgb()

            End If
            'Style.ForegroundArgbColor = CellStyle.BackgroundColor.ToArgb()
            Style.Font.Color = CellStyle.FontColor

            If CellStyle.Underline Then

                Style.Font.Underline = Aspose.Cells.FontUnderlineType.Single

            End If

            If CellStyle.TopBorder.CellBorderType <> Aspose.Cells.CellBorderType.None Then

                Style.SetBorder(Aspose.Cells.BorderType.TopBorder, CellStyle.TopBorder.CellBorderType, CellStyle.TopBorder.Color)

            End If

            If CellStyle.BottomBorder.CellBorderType <> Aspose.Cells.CellBorderType.None Then

                Style.SetBorder(Aspose.Cells.BorderType.BottomBorder, CellStyle.BottomBorder.CellBorderType, CellStyle.BottomBorder.Color)

            End If

            If CellStyle.LeftBorder.CellBorderType <> Aspose.Cells.CellBorderType.None Then

                Style.SetBorder(Aspose.Cells.BorderType.LeftBorder, CellStyle.LeftBorder.CellBorderType, CellStyle.LeftBorder.Color)

            End If

            If CellStyle.RightBorder.CellBorderType <> Aspose.Cells.CellBorderType.None Then

                Style.SetBorder(Aspose.Cells.BorderType.RightBorder, CellStyle.RightBorder.CellBorderType, CellStyle.RightBorder.Color)

            End If

            Range.SetStyle(Style)

        End Sub
        Private Function GetLastDate(FlowChartEstimate As FlowChartEstimate, MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField) As Date

            'objects
            Dim LastDate As Date = Date.MinValue

            If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString OrElse
                    MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Date.ToString Then

                LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).Date

            ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                    If FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth Then

                        LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).WeekStartDate

                    Else

                        LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastWeekStartDate

                    End If

                ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).WeekStartDate

                ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastWeekStartDate

                End If

            ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                    MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                    If FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth Then

                        LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).MonthStartDate

                    Else

                        LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastMonthStartDate

                    End If

                ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).MonthStartDate

                ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastMonthStartDate

                End If

            ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString Then

                If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                    If FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth Then

                        LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).QuarterStartDate

                    Else

                        LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastQuarterStartDate

                    End If

                ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).QuarterStartDate

                ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastQuarterStartDate

                End If

            ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString Then

                If FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                    If FlowChartEstimate.MediaPlanEstimate.IsCalendarMonth Then

                        LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).YearStartDate

                    Else

                        LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastYearStartDate

                    End If

                ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).YearStartDate

                ElseIf FlowChartEstimate.FlowChart.FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                    LastDate = FlowChartEstimate.FlowChart.FlowChartEstimateDates(0).BroadcastYearStartDate

                End If

            End If

            GetLastDate = LastDate

        End Function

#End Region

    End Class

End Namespace
