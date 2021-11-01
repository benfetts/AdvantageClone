Namespace Media

    Public Class MediaBroadcastWorksheetBroadcastScheduleDetailReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0
        Private _CurrentDataLine As Database.Classes.MediaBroadcastWorksheetBroadcastScheduleDetail = Nothing
        Private _Reportdata As Generic.List(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleDetail) = Nothing

        Private _Week1GRP As Double
        Private _Week2GRP As Double
        Private _Week3GRP As Double
        Private _Week4GRP As Double
        Private _Week5GRP As Double
        Private _Week6GRP As Double
        Private _Week7GRP As Double
        Private _Week8GRP As Double
        Private _Week9GRP As Double
        Private _Week10GRP As Double
        Private _Week11GRP As Double
        Private _Week12GRP As Double
        Private _Week13GRP As Double
        Private _Week14GRP As Double
        Private _ShowNet As Boolean = True
        Private _ShowSpotCosts As Boolean = True
        Private _ShowTotalCosts As Boolean = True
        Private _ShowComments As Boolean = True
        Private _ShowImpressions As Boolean = True
        Private _ShowBookends As Boolean = True
        Private _ShowRatings As Boolean = True
        Private _ShowCPPM As Boolean = True
        Private _ShowRF As Boolean = True
        Private _WorksheetIsGross As Boolean = True
        Private _ShowAddedValue As Boolean = True
        Private _Date As String = String.Empty
        Private _LocationName As String = String.Empty
        Private _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

#End Region

#Region " Properties "

        Public Property UserDefinedReportID As Integer Implements IUserDefinedReport.UserDefinedReportID
            Get
                UserDefinedReportID = _UserDefinedReportID
            End Get
            Set(value As Integer)
                _UserDefinedReportID = value
            End Set
        End Property
        Public ReadOnly Property AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports Implements IUserDefinedReport.AdvancedReportWriterReport
            Get
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaBroadcastWorksheetBroadCastSchedule
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property
        Public Property ParameterDictionary As Dictionary(Of String, Object)
        Public Property Session As AdvantageFramework.Security.Session

#End Region

#Region " Methods "
        Private Function EarliestDay(
              Day1 As Nullable(Of Date) _
              , Day2 As Nullable(Of Date) _
              , Day3 As Nullable(Of Date) _
              , Day4 As Nullable(Of Date) _
              , Day5 As Nullable(Of Date) _
              , Day6 As Nullable(Of Date) _
              , Day7 As Nullable(Of Date) _
              , Day8 As Nullable(Of Date) _
              , Day9 As Nullable(Of Date) _
              , Day10 As Nullable(Of Date) _
              , Day11 As Nullable(Of Date) _
              , Day12 As Nullable(Of Date) _
              , Day13 As Nullable(Of Date) _
              , Day14 As Nullable(Of Date)) As Date

            Dim TempEarliestDay As Date

            If (Day1.HasValue) Then
                TempEarliestDay = Day1.Value
            ElseIf (Day2.HasValue) Then
                TempEarliestDay = Day2.Value
            ElseIf (Day3.HasValue) Then
                TempEarliestDay = Day3.Value
            ElseIf (Day4.HasValue) Then
                TempEarliestDay = Day4.Value
            ElseIf (Day5.HasValue) Then
                TempEarliestDay = Day5.Value
            ElseIf (Day6.HasValue) Then
                TempEarliestDay = Day6.Value
            ElseIf (Day7.HasValue) Then
                TempEarliestDay = Day7.Value
            ElseIf (Day7.HasValue) Then
                TempEarliestDay = Day7.Value
            ElseIf (Day8.HasValue) Then
                TempEarliestDay = Day8.Value
            ElseIf (Day9.HasValue) Then
                TempEarliestDay = Day9.Value
            ElseIf (Day10.HasValue) Then
                TempEarliestDay = Day10.Value
            ElseIf (Day11.HasValue) Then
                TempEarliestDay = Day11.Value
            ElseIf (Day12.HasValue) Then
                TempEarliestDay = Day12.Value
            ElseIf (Day13.HasValue) Then
                TempEarliestDay = Day13.Value
            ElseIf (Day14.HasValue) Then
                TempEarliestDay = Day14.Value
            Else
                Date.Parse("1/1/1900")
            End If

            EarliestDay = TempEarliestDay
        End Function

        Private Sub MediaBroadcastWorksheetBroadcastScheduleDetailReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded
            'Braxton
            Dim MediaBroadcastWorksheetBroadcastScheduleDetails As Generic.List(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleDetail) = Nothing
            Dim MarketWorksheetMarketIdList As Generic.List(Of Integer) = Nothing
            Dim UsePrimaryDemoList As Generic.List(Of Boolean) = Nothing

            'Nullable Integers
            Dim BroadcastStartYearMonthList As Generic.List(Of Nullable(Of Integer)) = Nothing
            Dim BroadcastEndYearMonthList As Generic.List(Of Nullable(Of Integer)) = Nothing

            Dim MediaBroadcastWorksheetMarketBooks As Generic.List(Of AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook) = Nothing
            Dim NielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook) = Nothing
            Dim ComScoreTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook) = Nothing
            Dim NielsenTVBook1 As AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook = Nothing
            Dim NielsenTVBook2 As AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook = Nothing
            Dim NielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod) = Nothing
            Dim NielsenRadioPeriod1 As AdvantageFramework.DTO.Media.NielsenRadioPeriod = Nothing
            Dim NielsenRadioPeriod2 As AdvantageFramework.DTO.Media.NielsenRadioPeriod = Nothing
            Dim NielsenRadioPeriod3 As AdvantageFramework.DTO.Media.NielsenRadioPeriod = Nothing
            Dim NielsenRadioPeriod4 As AdvantageFramework.DTO.Media.NielsenRadioPeriod = Nothing
            Dim NielsenRadioPeriod5 As AdvantageFramework.DTO.Media.NielsenRadioPeriod = Nothing


            Try
                If ParameterDictionary.ContainsKey("LocationName") Then
                    _LocationName = ParameterDictionary("LocationName")
                End If
            Catch ex As Exception

            End Try

            Dim VendorCodeList As String = ""

            Try
                If ParameterDictionary.ContainsKey("VendorFilter") Then
                    VendorCodeList = ParameterDictionary("VendorFilter")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("ShowRatings") Then
                    _ShowRatings = ParameterDictionary("ShowRatings")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("ShowComments") Then
                    _ShowComments = ParameterDictionary("ShowComments")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("ShowSpotCosts") Then
                    _ShowSpotCosts = ParameterDictionary("ShowSpotCosts")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("ShowImpressions") Then
                    _ShowImpressions = ParameterDictionary("ShowImpressions")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("ShowBookends") Then
                    _ShowBookends = ParameterDictionary("ShowBookends")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("ShowTotalCosts") Then
                    _ShowTotalCosts = ParameterDictionary("ShowTotalCosts")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("ShowCPPM") Then
                    _ShowCPPM = ParameterDictionary("ShowCPPM")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("ShowAddedValue") Then
                    _ShowAddedValue = ParameterDictionary("ShowAddedValue")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("ShowRF") Then
                    _ShowRF = ParameterDictionary("ShowRF")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("ShowNetCost") Then
                    _ShowNet = ParameterDictionary("ShowNetCost")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("WorksheetIsGross") Then
                    _WorksheetIsGross = ParameterDictionary("WorksheetIsGross")
                End If
            Catch ex As Exception

            End Try

            'Init
            MarketWorksheetMarketIdList = New Generic.List(Of Integer)
            UsePrimaryDemoList = New Generic.List(Of Boolean)
            BroadcastStartYearMonthList = New Generic.List(Of Nullable(Of Integer))
            BroadcastEndYearMonthList = New Generic.List(Of Nullable(Of Integer))

            Try

                If ParameterDictionary.ContainsKey("MediaBroadcastWorksheetMarketBooks") Then
                    MediaBroadcastWorksheetMarketBooks = ParameterDictionary("MediaBroadcastWorksheetMarketBooks")
                    For Each WorksheetMarket In MediaBroadcastWorksheetMarketBooks
                        MarketWorksheetMarketIdList.Add(WorksheetMarket.MediaBroadcastWorksheetMarketID)
                        UsePrimaryDemoList.Add(WorksheetMarket.UsePrimaryDemo)

                        'Handle Nullable Integers
                        BroadcastStartYearMonthList.Add(WorksheetMarket.BroadcastStartYearMonth)
                        BroadcastEndYearMonthList.Add(WorksheetMarket.BroadcastEndYearMonth)
                    Next
                End If

                Using DbContext = New Database.DbContext(Session.ConnectionString, Session.UserCode)

                    MediaBroadcastWorksheetBroadcastScheduleDetails =
                        Reporting.Database.Procedures.MediaBroadcastWorksheetBroadcastScheduleReport.
                            LoadDetail(DbContext, MarketWorksheetMarketIdList, BroadcastStartYearMonthList, BroadcastEndYearMonthList, UsePrimaryDemoList, "Media Broadcast Schedule Detail", VendorCodeList, _LocationName, _ShowNet, _WorksheetIsGross) _
                            .ToList()


                End Using

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If String.IsNullOrWhiteSpace(_LocationName) = False Then

                        _LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _LocationName, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderLandscape)

                    Else

                        _LocationLogo = Nothing

                    End If

                End Using

                Dim LinesAndVendors As List(Of LineAndVendor) = Nothing

                LinesAndVendors = New List(Of LineAndVendor)

                'Determine unmatched weeks

                If (MediaBroadcastWorksheetBroadcastScheduleDetails IsNot Nothing) Then

                    For Each Datum In MediaBroadcastWorksheetBroadcastScheduleDetails
                        Datum.EarliestDate = EarliestDay(Datum.Week1Date, Datum.Week2Date, Datum.Week3Date, Datum.Week4Date, Datum.Week5Date, Datum.Week6Date, Datum.Week7Date _
                                                         , Datum.Week8Date, Datum.Week9Date, Datum.Week10Date, Datum.Week11Date, Datum.Week12Date, Datum.Week13Date, Datum.Week14Date)
                    Next

                    Dim tAllGroupings As List(Of GroupingHolder) = MediaBroadcastWorksheetBroadcastScheduleDetails _
                    .OrderBy(Function(x) x.Market) _
                    .ThenBy(Function(x) x.LineNumber) _
                    .ThenBy(Function(x) x.VendorCode) _
                    .ThenBy(Function(x) x.Days) _
                    .ThenBy(Function(x) x.Rate) _
                    .Select(Function(x) New GroupingHolder(x.Market, 0, x.VendorCode, x.ProgramName, x.Days, x.Rate, x.EarliestDate)).ToList

                    Dim AllGroupings As List(Of GroupingHolder) = New List(Of GroupingHolder) ' because Linq .Distinct does not work Above

                    For Each Datum In tAllGroupings
                        If Not (AllGroupings.Where(Function(x) (x.Market = Datum.Market) AndAlso (x.LineNumber = Datum.LineNumber) AndAlso (x.VendorCode = Datum.VendorCode) AndAlso (x.Days = Datum.Days) AndAlso (x.Rate = Datum.Rate)).Any) Then
                            AllGroupings.Add(Datum)
                        End If
                    Next

                    For Each Grouping In AllGroupings

                        Dim DoesLastRowExist As Boolean =
                            MediaBroadcastWorksheetBroadcastScheduleDetails _
                                .Where(Function(x) (x.Market = Grouping.Market) AndAlso (x.VendorCode = Grouping.VendorCode) AndAlso (x.ProgramName = Grouping.ProgramName) AndAlso (x.Days = Grouping.Days) AndAlso (x.Rate = Grouping.Rate) AndAlso (x.BucketLastRow = True)).Any

                        Dim LastRowLineNumber As Integer


                        If Not (MediaBroadcastWorksheetBroadcastScheduleDetails _
                                .Where(Function(x) (x.Market = Grouping.Market) AndAlso (x.VendorCode = Grouping.VendorCode) AndAlso (x.ProgramName = Grouping.ProgramName) AndAlso (x.BucketLastRow = True)).Any) Then
                            LastRowLineNumber = 0
                        Else
                            LastRowLineNumber = MediaBroadcastWorksheetBroadcastScheduleDetails _
                                .Where(Function(x) (x.Market = Grouping.Market) AndAlso (x.VendorCode = Grouping.VendorCode) AndAlso (x.ProgramName = Grouping.ProgramName) AndAlso (x.BucketLastRow = True)).FirstOrDefault.LineNumber
                        End If

                        Dim LastRowBucketRowNumber As Integer

                        If Not (MediaBroadcastWorksheetBroadcastScheduleDetails _
                                .Where(Function(x) (x.Market = Grouping.Market) AndAlso (x.VendorCode = Grouping.VendorCode) AndAlso (x.ProgramName = Grouping.ProgramName) AndAlso (x.BucketLastRow = True)).Any) Then
                            LastRowBucketRowNumber = 0
                        Else
                            LastRowBucketRowNumber = MediaBroadcastWorksheetBroadcastScheduleDetails _
                                .Where(Function(x) (x.Market = Grouping.Market) AndAlso (x.VendorCode = Grouping.VendorCode) AndAlso (x.ProgramName = Grouping.ProgramName) AndAlso (x.BucketLastRow = True)).FirstOrDefault.BucketRow
                        End If

                        If Not (DoesLastRowExist) Then
                            AddReportPlaceHolder(MediaBroadcastWorksheetBroadcastScheduleDetails, Grouping, LastRowLineNumber, LastRowBucketRowNumber, True)
                        End If

                    Next


                    'Redo the sort on MediaBroadcastWorksheetBroadcastScheduleDetails

                    MediaBroadcastWorksheetBroadcastScheduleDetails =
                         MediaBroadcastWorksheetBroadcastScheduleDetails _
                            .OrderBy(Function(x) x.Market) _
                            .ThenBy(Function(x) x.BucketRow) _
                            .ThenBy(Function(x) x.BucketLastRow) _
                            .ThenBy(Function(x) x.LineNumber) _
                            .ThenBy(Function(x) x.MakeGoodNumber) _
                            .ThenBy(Function(x) x.VendorCode) _
                            .ThenBy(Function(x) x.Days) _
                            .ThenBy(Function(x) x.ProgramName) _
                            .ThenBy(Function(x) x.Rate) _
                            .ThenBy(Function(x) x.EarliestDate) _
                        .ToList
                End If


                For Each DataLine In MediaBroadcastWorksheetBroadcastScheduleDetails

                    If (DataLine.BucketLastRow = True) Then

                        DataLine.StationGross = MediaBroadcastWorksheetBroadcastScheduleDetails _
                        .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.LineNumber = DataLine.LineNumber) AndAlso (DRW.MakeGoodNumber = DataLine.MakeGoodNumber) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.Days = DataLine.Days) AndAlso (DRW.ProgramName = DataLine.ProgramName) AndAlso (DRW.Rate = DataLine.Rate)) _
                        .Select(Function(DRW2) DRW2.StationGross).Sum()

                        DataLine.TotalGIMP = MediaBroadcastWorksheetBroadcastScheduleDetails _
                        .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.LineNumber = DataLine.LineNumber) AndAlso (DRW.MakeGoodNumber = DataLine.MakeGoodNumber) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.Days = DataLine.Days) AndAlso (DRW.ProgramName = DataLine.ProgramName) AndAlso (DRW.Rate = DataLine.Rate)) _
                        .Select(Function(DRW2) DRW2.TotalGIMP).Sum()

                        DataLine.TotalGRP = MediaBroadcastWorksheetBroadcastScheduleDetails _
                        .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.LineNumber = DataLine.LineNumber) AndAlso (DRW.MakeGoodNumber = DataLine.MakeGoodNumber) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.Days = DataLine.Days) AndAlso (DRW.ProgramName = DataLine.ProgramName) AndAlso (DRW.Rate = DataLine.Rate)) _
                        .Select(Function(DRW2) DRW2.TotalGRP).Sum()

                        DataLine.TotalSpots = MediaBroadcastWorksheetBroadcastScheduleDetails _
                        .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.LineNumber = DataLine.LineNumber) AndAlso (DRW.MakeGoodNumber = DataLine.MakeGoodNumber) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.Days = DataLine.Days) AndAlso (DRW.ProgramName = DataLine.ProgramName) AndAlso (DRW.Rate = DataLine.Rate)) _
                        .Select(Function(DRW2) DRW2.TotalSpots).Sum()

                    End If

                    If (DataLine.Week1Date Is Nothing) Then
                        DataLine.Week1Date = MediaBroadcastWorksheetBroadcastScheduleDetails _
                            .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.Week1Date IsNot Nothing) AndAlso DRW.BucketRow = DataLine.BucketRow) _
                            .Select(Function(DRW2) DRW2.Week1Date).FirstOrDefault
                    End If

                    If (DataLine.Week2Date Is Nothing) Then
                        DataLine.Week2Date = MediaBroadcastWorksheetBroadcastScheduleDetails _
                            .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.Week2Date IsNot Nothing) AndAlso DRW.BucketRow = DataLine.BucketRow) _
                            .Select(Function(DRW2) DRW2.Week2Date).FirstOrDefault

                        If (DataLine.Week2Date < DataLine.Week1Date) Then
                            DataLine.Week2Date = Nothing
                        End If

                    End If

                    If (DataLine.Week3Date Is Nothing) Then
                        DataLine.Week3Date = MediaBroadcastWorksheetBroadcastScheduleDetails _
                            .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.Week3Date IsNot Nothing) AndAlso DRW.BucketRow = DataLine.BucketRow) _
                            .Select(Function(DRW2) DRW2.Week3Date).FirstOrDefault

                        If (DataLine.Week3Date < DataLine.Week1Date) Then
                            DataLine.Week3Date = Nothing
                        End If

                    End If

                    If (DataLine.Week4Date Is Nothing) Then
                        DataLine.Week4Date = MediaBroadcastWorksheetBroadcastScheduleDetails _
                            .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.Week4Date IsNot Nothing) AndAlso DRW.BucketRow = DataLine.BucketRow) _
                            .Select(Function(DRW2) DRW2.Week4Date).FirstOrDefault

                        If (DataLine.Week4Date < DataLine.Week1Date) Then
                            DataLine.Week4Date = Nothing
                        End If

                    End If

                    If (DataLine.Week5Date Is Nothing) Then
                        DataLine.Week5Date = MediaBroadcastWorksheetBroadcastScheduleDetails _
                            .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.Week5Date IsNot Nothing) AndAlso DRW.BucketRow = DataLine.BucketRow) _
                            .Select(Function(DRW2) DRW2.Week5Date).FirstOrDefault

                        If (DataLine.Week5Date < DataLine.Week1Date) Then
                            DataLine.Week5Date = Nothing
                        End If

                    End If

                    If (DataLine.Week6Date Is Nothing) Then
                        DataLine.Week6Date = MediaBroadcastWorksheetBroadcastScheduleDetails _
                            .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.Week6Date IsNot Nothing) AndAlso DRW.BucketRow = DataLine.BucketRow) _
                            .Select(Function(DRW2) DRW2.Week6Date).FirstOrDefault

                        If (DataLine.Week6Date < DataLine.Week1Date) Then
                            DataLine.Week6Date = Nothing
                        End If

                    End If

                    If (DataLine.Week7Date Is Nothing) Then
                        DataLine.Week7Date = MediaBroadcastWorksheetBroadcastScheduleDetails _
                            .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.Week7Date IsNot Nothing) AndAlso DRW.BucketRow = DataLine.BucketRow) _
                            .Select(Function(DRW2) DRW2.Week7Date).FirstOrDefault

                        If (DataLine.Week7Date < DataLine.Week1Date) Then
                            DataLine.Week7Date = Nothing
                        End If

                    End If

                    If (DataLine.Week8Date Is Nothing) Then
                        DataLine.Week8Date = MediaBroadcastWorksheetBroadcastScheduleDetails _
                            .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.Week8Date IsNot Nothing) AndAlso DRW.BucketRow = DataLine.BucketRow) _
                            .Select(Function(DRW2) DRW2.Week8Date).FirstOrDefault

                        If (DataLine.Week8Date < DataLine.Week1Date) Then
                            DataLine.Week8Date = Nothing
                        End If

                    End If

                    If (DataLine.Week9Date Is Nothing) Then
                        DataLine.Week9Date = MediaBroadcastWorksheetBroadcastScheduleDetails _
                           .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.Week9Date IsNot Nothing) AndAlso DRW.BucketRow = DataLine.BucketRow) _
                            .Select(Function(DRW2) DRW2.Week9Date).FirstOrDefault

                        If (DataLine.Week9Date < DataLine.Week1Date) Then
                            DataLine.Week9Date = Nothing
                        End If

                    End If

                    If (DataLine.Week10Date Is Nothing) Then
                        DataLine.Week10Date = MediaBroadcastWorksheetBroadcastScheduleDetails _
                            .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.Week10Date IsNot Nothing) AndAlso DRW.BucketRow = DataLine.BucketRow) _
                            .Select(Function(DRW2) DRW2.Week10Date).FirstOrDefault

                        If (DataLine.Week10Date < DataLine.Week1Date) Then
                            DataLine.Week10Date = Nothing
                        End If

                    End If

                    If (DataLine.Week11Date Is Nothing) Then
                        DataLine.Week11Date = MediaBroadcastWorksheetBroadcastScheduleDetails _
                            .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.Week11Date IsNot Nothing) AndAlso DRW.BucketRow = DataLine.BucketRow) _
                            .Select(Function(DRW2) DRW2.Week11Date).FirstOrDefault

                        If (DataLine.Week11Date < DataLine.Week1Date) Then
                            DataLine.Week11Date = Nothing
                        End If

                    End If

                    If (DataLine.Week12Date Is Nothing) Then
                        DataLine.Week12Date = MediaBroadcastWorksheetBroadcastScheduleDetails _
                            .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.Week12Date IsNot Nothing) AndAlso DRW.BucketRow = DataLine.BucketRow) _
                            .Select(Function(DRW2) DRW2.Week12Date).FirstOrDefault

                        If (DataLine.Week12Date < DataLine.Week1Date) Then
                            DataLine.Week12Date = Nothing
                        End If

                    End If

                    If (DataLine.Week13Date Is Nothing) Then
                        DataLine.Week13Date = MediaBroadcastWorksheetBroadcastScheduleDetails _
                            .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.Week13Date IsNot Nothing) AndAlso DRW.BucketRow = DataLine.BucketRow) _
                            .Select(Function(DRW2) DRW2.Week13Date).FirstOrDefault

                        If (DataLine.Week13Date < DataLine.Week1Date) Then
                            DataLine.Week13Date = Nothing
                        End If

                    End If

                    If (DataLine.Week14Date Is Nothing) Then
                        DataLine.Week14Date = MediaBroadcastWorksheetBroadcastScheduleDetails _
                            .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.Week14Date IsNot Nothing) AndAlso DRW.BucketRow = DataLine.BucketRow) _
                            .Select(Function(DRW2) DRW2.Week14Date).FirstOrDefault

                        If (DataLine.Week14Date < DataLine.Week1Date) Then
                            DataLine.Week14Date = Nothing
                        End If

                    End If

                    If (DataLine.BuyOrder Is Nothing) Then
                        DataLine.BuyOrder = MediaBroadcastWorksheetBroadcastScheduleDetails _
                            .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.LineNumber = DataLine.LineNumber) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.BuyOrder IsNot Nothing)) _
                            .Select(Function(DRW2) DRW2.BuyOrder).Max

                    End If

                    If (DataLine.TotalSpots = 0) Then

                        If MediaBroadcastWorksheetBroadcastScheduleDetails.Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso
                                                                                               (DRW.LineNumber = DataLine.LineNumber) AndAlso
                                                                                               (DRW.MakeGoodNumber = DataLine.MakeGoodNumber) AndAlso
                                                                                               (DRW.VendorCode = DataLine.VendorCode) AndAlso
                                                                                               (DRW.Days = DataLine.Days) AndAlso
                                                                                               (DRW.ProgramName = DataLine.ProgramName) AndAlso
                                                                                               (DRW.Rate = DataLine.Rate)).Select(Function(DRW2) DRW2.TotalSpots).Sum() = 0 Then

                            LinesAndVendors.Add(New LineAndVendor(DataLine.Market, DataLine.LineNumber, DataLine.MakeGoodNumber, DataLine.VendorCode, DataLine.Days, DataLine.ProgramName, DataLine.Rate))

                        End If

                    End If

                    DataLine.ShowRatings = _ShowRatings
                    DataLine.ShowComments = _ShowComments
                    DataLine.ShowSpotCosts = _ShowSpotCosts
                    DataLine.ShowImpressions = _ShowImpressions
                    DataLine.ShowBookends = _ShowBookends
                    DataLine.ShowTotalCosts = _ShowTotalCosts
                    DataLine.ShowCPPM = _ShowCPPM
                    DataLine.ShowAddedValue = _ShowAddedValue
                    DataLine.ShowRF = _ShowRF
                Next

                For Each Line In LinesAndVendors
                    MediaBroadcastWorksheetBroadcastScheduleDetails.RemoveAll(Function(DRW) (DRW.Market = Line.Market) AndAlso (DRW.LineNumber = Line.LineNumber) AndAlso (DRW.MakeGoodNumber = Line.MakegoodNumber) AndAlso (DRW.VendorCode = Line.VendorCode) AndAlso (DRW.Days = Line.Days) AndAlso (DRW.ProgramName = Line.ProgramName) AndAlso (DRW.Rate = Line.Rate))
                Next

                If Session.IsNielsenSetup Then

                    Using DbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Session.UserCode)

                        DbContext.Database.Connection.Open()

                        NielsenTVBooks = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.Load(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook(Entity)).ToList
                        NielsenRadioPeriods = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.Load(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.NielsenRadioPeriod(Entity)).ToList

                    End Using

                End If

                If Session.IsComscoreSetup Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        DbContext.Database.Connection.Open()

                        ComScoreTVBooks = AdvantageFramework.Database.Procedures.ComscoreTVBook.Load(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook(Entity)).ToList

                    End Using

                End If
                For Each DataLine In MediaBroadcastWorksheetBroadcastScheduleDetails

                    DataLine.Survey = String.Empty
                    DataLine.SurveyLine2 = String.Empty

                    If DataLine.RatingsServiceID.GetValueOrDefault(0) = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                        DataLine.RatingsSource = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen.ToString

                        If DataLine.MediaTypeCode = "T" Then

                            If DataLine.SharebookNielsenTVBookID.GetValueOrDefault(0) > 0 AndAlso NielsenTVBooks IsNot Nothing AndAlso NielsenTVBooks.Count > 0 Then

                                NielsenTVBook1 = NielsenTVBooks.FirstOrDefault(Function(Entity) Entity.ID = DataLine.SharebookNielsenTVBookID.GetValueOrDefault(0))

                                If NielsenTVBook1 IsNot Nothing Then

                                    DataLine.Survey = NielsenTVBook1.Description

                                Else

                                    DataLine.Survey = String.Empty

                                End If

                            Else

                                DataLine.Survey = String.Empty

                            End If

                            If DataLine.HutputNielsenTVBookID.GetValueOrDefault(0) > 0 AndAlso NielsenTVBooks IsNot Nothing AndAlso NielsenTVBooks.Count > 0 Then

                                NielsenTVBook2 = NielsenTVBooks.FirstOrDefault(Function(Entity) Entity.ID = DataLine.HutputNielsenTVBookID.GetValueOrDefault(0))

                                If NielsenTVBook2 IsNot Nothing Then

                                    DataLine.SurveyLine2 = NielsenTVBook2.Description

                                Else

                                    DataLine.SurveyLine2 = String.Empty

                                End If

                            Else

                                DataLine.SurveyLine2 = String.Empty

                            End If

                        ElseIf DataLine.MediaTypeCode = "R" Then

                            If (NielsenRadioPeriods IsNot Nothing) Then
                                DataLine.Survey = AdvantageFramework.Reporting.Reports.
                                    RadioPeriods(NielsenRadioPeriods, DataLine.RadioBookID1.GetValueOrDefault(0), DataLine.RadioBookID2.GetValueOrDefault(0), DataLine.RadioBookID3.GetValueOrDefault(0), DataLine.RadioBookID4.GetValueOrDefault(0), DataLine.RadioBookID5.GetValueOrDefault(0))
                            Else
                                DataLine.Survey = String.Empty
                            End If

                            DataLine.SurveyLine2 = String.Empty

                        End If

                    ElseIf DataLine.RatingsServiceID.GetValueOrDefault(0) = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                        DataLine.RatingsSource = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore.ToString

                        If DataLine.MediaTypeCode = "T" Then


                            If DataLine.SharebookNielsenTVBookID.GetValueOrDefault(0) > 0 AndAlso ComScoreTVBooks IsNot Nothing AndAlso ComScoreTVBooks.Count > 0 Then

                                NielsenTVBook1 = ComScoreTVBooks.FirstOrDefault(Function(Entity) Entity.ID = DataLine.SharebookNielsenTVBookID.GetValueOrDefault(0))

                                If NielsenTVBook1 IsNot Nothing Then

                                    DataLine.Survey = NielsenTVBook1.Description

                                Else

                                    DataLine.Survey = String.Empty

                                End If

                            Else

                                DataLine.Survey = String.Empty

                            End If

                            If DataLine.HutputNielsenTVBookID.GetValueOrDefault(0) > 0 AndAlso ComScoreTVBooks IsNot Nothing AndAlso ComScoreTVBooks.Count > 0 Then

                                NielsenTVBook2 = ComScoreTVBooks.FirstOrDefault(Function(Entity) Entity.ID = DataLine.HutputNielsenTVBookID.GetValueOrDefault(0))

                                If NielsenTVBook2 IsNot Nothing Then

                                    DataLine.SurveyLine2 = NielsenTVBook2.Description

                                Else

                                    DataLine.SurveyLine2 = String.Empty

                                End If

                            Else

                                DataLine.SurveyLine2 = String.Empty

                            End If

                        Else

                            DataLine.Survey = String.Empty
                            DataLine.SurveyLine2 = String.Empty

                        End If

                    Else

                        DataLine.Survey = String.Empty
                        DataLine.SurveyLine2 = String.Empty

                    End If

                    If (DataLine.MediaTypeCode = "R") Then
                        DataLine.RatingsSource = DataLine.RadioSource
                    End If
                Next

                _Reportdata = MediaBroadcastWorksheetBroadcastScheduleDetails

                Me.DataSource = MediaBroadcastWorksheetBroadcastScheduleDetails

                If (MediaBroadcastWorksheetBroadcastScheduleDetails IsNot Nothing) Then
                    If (MediaBroadcastWorksheetBroadcastScheduleDetails.Count > 0) Then

                        _CurrentDataLine = MediaBroadcastWorksheetBroadcastScheduleDetails.FirstOrDefault

                        If (_CurrentDataLine.MediaTypeCode = "R") Then
                            XrTableCell253.TextFormatString = "{0:#,#}"
                        Else
                            XrTableCell253.TextFormatString = "{0:#,#.0}"
                        End If
                    Else
                        'Blank record - protection from null exceptions
                        _CurrentDataLine = New Database.Classes.MediaBroadcastWorksheetBroadcastScheduleDetail
                    End If
                End If

            Catch ex As Exception

            End Try

        End Sub

        Private Sub AddReportPlaceHolder(ScheduleDetails As List(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleDetail), Grouping As GroupingHolder, LineNumber As Integer, BucketRow As Integer, IsLastRow As Boolean)

            Dim PlaceholderScheduleDetail = New Database.Classes.MediaBroadcastWorksheetBroadcastScheduleDetail

            Dim FirstMatchingDetail = ScheduleDetails.Where(Function(x) (x.Market = Grouping.Market) AndAlso (x.VendorCode = Grouping.VendorCode) AndAlso (x.ProgramName = Grouping.ProgramName) AndAlso (x.Days = Grouping.Days) AndAlso (x.LineNumber = LineNumber) AndAlso (x.Rate = Grouping.Rate)).FirstOrDefault

            If FirstMatchingDetail IsNot Nothing Then

                CopyPropertiesByName(PlaceholderScheduleDetail, FirstMatchingDetail)

                PlaceholderScheduleDetail.Week1Spots = 0
                PlaceholderScheduleDetail.Week2Spots = 0
                PlaceholderScheduleDetail.Week3Spots = 0
                PlaceholderScheduleDetail.Week4Spots = 0
                PlaceholderScheduleDetail.Week5Spots = 0
                PlaceholderScheduleDetail.Week6Spots = 0
                PlaceholderScheduleDetail.Week7Spots = 0
                PlaceholderScheduleDetail.Week8Spots = 0
                PlaceholderScheduleDetail.Week9Spots = 0
                PlaceholderScheduleDetail.Week10Spots = 0
                PlaceholderScheduleDetail.Week11Spots = 0
                PlaceholderScheduleDetail.Week12Spots = 0
                PlaceholderScheduleDetail.Week13Spots = 0
                PlaceholderScheduleDetail.Week14Spots = 0

                PlaceholderScheduleDetail.Week1PrimaryGRP = 0
                PlaceholderScheduleDetail.Week2PrimaryGRP = 0
                PlaceholderScheduleDetail.Week3PrimaryGRP = 0
                PlaceholderScheduleDetail.Week4PrimaryGRP = 0
                PlaceholderScheduleDetail.Week5PrimaryGRP = 0
                PlaceholderScheduleDetail.Week6PrimaryGRP = 0
                PlaceholderScheduleDetail.Week7PrimaryGRP = 0
                PlaceholderScheduleDetail.Week8PrimaryGRP = 0
                PlaceholderScheduleDetail.Week9PrimaryGRP = 0
                PlaceholderScheduleDetail.Week10PrimaryGRP = 0
                PlaceholderScheduleDetail.Week11PrimaryGRP = 0
                PlaceholderScheduleDetail.Week12PrimaryGRP = 0
                PlaceholderScheduleDetail.Week13PrimaryGRP = 0

                PlaceholderScheduleDetail.Week1PrimaryGrossImpressions = 0
                PlaceholderScheduleDetail.Week2PrimaryGrossImpressions = 0
                PlaceholderScheduleDetail.Week3PrimaryGrossImpressions = 0
                PlaceholderScheduleDetail.Week4PrimaryGrossImpressions = 0
                PlaceholderScheduleDetail.Week5PrimaryGrossImpressions = 0
                PlaceholderScheduleDetail.Week6PrimaryGrossImpressions = 0
                PlaceholderScheduleDetail.Week7PrimaryGrossImpressions = 0
                PlaceholderScheduleDetail.Week8PrimaryGrossImpressions = 0
                PlaceholderScheduleDetail.Week9PrimaryGrossImpressions = 0
                PlaceholderScheduleDetail.Week10PrimaryGrossImpressions = 0
                PlaceholderScheduleDetail.Week11PrimaryGrossImpressions = 0
                PlaceholderScheduleDetail.Week12PrimaryGrossImpressions = 0
                PlaceholderScheduleDetail.Week13PrimaryGrossImpressions = 0
                PlaceholderScheduleDetail.Week14PrimaryGrossImpressions = 0

                PlaceholderScheduleDetail.Week1PrimaryCPP = 0
                PlaceholderScheduleDetail.Week2PrimaryCPP = 0
                PlaceholderScheduleDetail.Week3PrimaryCPP = 0
                PlaceholderScheduleDetail.Week4PrimaryCPP = 0
                PlaceholderScheduleDetail.Week5PrimaryCPP = 0
                PlaceholderScheduleDetail.Week6PrimaryCPP = 0
                PlaceholderScheduleDetail.Week7PrimaryCPP = 0
                PlaceholderScheduleDetail.Week8PrimaryCPP = 0
                PlaceholderScheduleDetail.Week9PrimaryCPP = 0
                PlaceholderScheduleDetail.Week10PrimaryCPP = 0
                PlaceholderScheduleDetail.Week11PrimaryCPP = 0
                PlaceholderScheduleDetail.Week12PrimaryCPP = 0
                PlaceholderScheduleDetail.Week13PrimaryCPP = 0
                PlaceholderScheduleDetail.Week14PrimaryCPP = 0

                PlaceholderScheduleDetail.Week1PrimaryCPM = 0
                PlaceholderScheduleDetail.Week2PrimaryCPM = 0
                PlaceholderScheduleDetail.Week3PrimaryCPM = 0
                PlaceholderScheduleDetail.Week4PrimaryCPM = 0
                PlaceholderScheduleDetail.Week5PrimaryCPM = 0
                PlaceholderScheduleDetail.Week6PrimaryCPM = 0
                PlaceholderScheduleDetail.Week7PrimaryCPM = 0
                PlaceholderScheduleDetail.Week8PrimaryCPM = 0
                PlaceholderScheduleDetail.Week9PrimaryCPM = 0
                PlaceholderScheduleDetail.Week10PrimaryCPM = 0
                PlaceholderScheduleDetail.Week11PrimaryCPM = 0
                PlaceholderScheduleDetail.Week12PrimaryCPM = 0
                PlaceholderScheduleDetail.Week13PrimaryCPM = 0
                PlaceholderScheduleDetail.Week14PrimaryCPM = 0

                PlaceholderScheduleDetail.Week1Date = Nothing
                PlaceholderScheduleDetail.Week2Date = Nothing
                PlaceholderScheduleDetail.Week3Date = Nothing
                PlaceholderScheduleDetail.Week4Date = Nothing
                PlaceholderScheduleDetail.Week5Date = Nothing
                PlaceholderScheduleDetail.Week6Date = Nothing
                PlaceholderScheduleDetail.Week7Date = Nothing
                PlaceholderScheduleDetail.Week8Date = Nothing
                PlaceholderScheduleDetail.Week9Date = Nothing
                PlaceholderScheduleDetail.Week10Date = Nothing
                PlaceholderScheduleDetail.Week11Date = Nothing
                PlaceholderScheduleDetail.Week12Date = Nothing
                PlaceholderScheduleDetail.Week13Date = Nothing
                PlaceholderScheduleDetail.Week14Date = Nothing




                PlaceholderScheduleDetail.StationGross = 0
                PlaceholderScheduleDetail.TotalGIMP = 0
                PlaceholderScheduleDetail.TotalGRP = 0
                PlaceholderScheduleDetail.TotalSpots = 0

                PlaceholderScheduleDetail.LineNumber = LineNumber

                PlaceholderScheduleDetail.BucketRow = BucketRow
                PlaceholderScheduleDetail.BucketLastRow = IsLastRow

                ScheduleDetails.Add(PlaceholderScheduleDetail)

            End If

        End Sub

        Private Function ShowYear(ByRef PreviousXRLabelYear As Nullable(Of Date), ByRef CurrentXRLabelYear As Nullable(Of Date)) As Boolean

            Dim DoShowYear As Boolean = False

            If (PreviousXRLabelYear.HasValue AndAlso CurrentXRLabelYear.HasValue) Then
                DoShowYear = Not (PreviousXRLabelYear.Value.Year = CurrentXRLabelYear.Value.Year)
            ElseIf ((PreviousXRLabelYear.HasValue = False) AndAlso CurrentXRLabelYear.HasValue) Then
                DoShowYear = True
            End If

            ShowYear = DoShowYear
        End Function
        Private Function ShowDecimalNumber(TestNumber As Nullable(Of Decimal))
            Dim DoShowNumber As Boolean = False

            If (TestNumber.HasValue) Then
                If Not (TestNumber.Value = 0) Then
                    DoShowNumber = True
                End If
            End If

            ShowDecimalNumber = DoShowNumber
        End Function
        Private Function NullOutZero(TestNumber As Nullable(Of Decimal))
            Dim NulledValue As Nullable(Of Decimal) = TestNumber

            If (TestNumber.HasValue) Then
                If (TestNumber.Value = 0) Then
                    TestNumber = Nothing
                ElseIf (TestNumber.Value > -0.01 AndAlso TestNumber.Value < 0.01) Then
                    TestNumber = Nothing
                End If
            End If

            Return NulledValue
        End Function

        Public Sub CopyPropertiesByName(Of T1, T2)(dest As T1, src As T2)

            Dim srcProps = src.GetType().GetProperties()
            Dim destProps = dest.GetType().GetProperties()

            For Each loSrcProp In srcProps
                If loSrcProp.CanRead Then
                    Dim loDestProp = destProps.FirstOrDefault(Function(x) x.Name = loSrcProp.Name)
                    If loDestProp IsNot Nothing AndAlso loDestProp.CanWrite Then
                        Dim loVal = loSrcProp.GetValue(src, Nothing)
                        loDestProp.SetValue(dest, loVal, Nothing)
                    End If
                End If
            Next
        End Sub

        Private Sub MediaBroadcastWorksheetBroadcastScheduleDetailReport_DataSourceRowChanged(sender As Object, e As DevExpress.XtraReports.UI.DataSourceRowEventArgs) Handles MyBase.DataSourceRowChanged
            _CurrentDataLine = TryCast(Me.GetCurrentRow(), Database.Classes.MediaBroadcastWorksheetBroadcastScheduleDetail)
        End Sub
        Private Sub GroupHeader2_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupHeader2.BeforePrint
            If (_CurrentDataLine IsNot Nothing) Then
                Dim WorksheetMarketNielsenTVBook As AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook = Nothing

                _CurrentDataLine.Buyer = ""
                _CurrentDataLine.EstimateComments = ""

                XrTableCell39.Visible = Not String.IsNullOrWhiteSpace(_CurrentDataLine.Buyer)
                XrTableCell43.Visible = Not String.IsNullOrWhiteSpace(_CurrentDataLine.EstimateComments)

                XrTableRow7.Visible = Not String.IsNullOrWhiteSpace(_CurrentDataLine.Buyer)
                XrTableRow8.Visible = Not String.IsNullOrWhiteSpace(_CurrentDataLine.EstimateComments)
            End If


        End Sub
        Private Sub GroupFooter1_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupFooter1.BeforePrint

            If (_CurrentDataLine IsNot Nothing) Then

                XrTableCell186.Visible = _CurrentDataLine.Week1Date.HasValue
                XrTableCell170.Visible = _CurrentDataLine.Week2Date.HasValue
                XrTableCell189.Visible = _CurrentDataLine.Week3Date.HasValue
                XrTableCell152.Visible = _CurrentDataLine.Week4Date.HasValue
                XrTableCell172.Visible = _CurrentDataLine.Week5Date.HasValue
                XrTableCell192.Visible = _CurrentDataLine.Week6Date.HasValue
                XrTableCell155.Visible = _CurrentDataLine.Week7Date.HasValue
                XrTableCell175.Visible = _CurrentDataLine.Week8Date.HasValue
                XrTableCell195.Visible = _CurrentDataLine.Week9Date.HasValue
                XrTableCell158.Visible = _CurrentDataLine.Week10Date.HasValue
                XrTableCell178.Visible = _CurrentDataLine.Week11Date.HasValue
                XrTableCell198.Visible = _CurrentDataLine.Week12Date.HasValue
                XrTableCell161.Visible = _CurrentDataLine.Week13Date.HasValue
                XrTableCell181.Visible = _CurrentDataLine.Week14Date.HasValue

                XrTableCell123.Visible = _CurrentDataLine.Week1Date.HasValue
                XrTableCell124.Visible = _CurrentDataLine.Week2Date.HasValue
                XrTableCell156.Visible = _CurrentDataLine.Week3Date.HasValue
                XrTableCell159.Visible = _CurrentDataLine.Week4Date.HasValue
                XrTableCell162.Visible = _CurrentDataLine.Week5Date.HasValue
                XrTableCell169.Visible = _CurrentDataLine.Week6Date.HasValue
                XrTableCell173.Visible = _CurrentDataLine.Week7Date.HasValue
                XrTableCell176.Visible = _CurrentDataLine.Week8Date.HasValue
                XrTableCell179.Visible = _CurrentDataLine.Week9Date.HasValue
                XrTableCell182.Visible = _CurrentDataLine.Week10Date.HasValue
                XrTableCell200.Visible = _CurrentDataLine.Week11Date.HasValue


                XrTableCell228.Visible = _CurrentDataLine.Week12Date.HasValue
                XrTableCell229.Visible = _CurrentDataLine.Week13Date.HasValue
                XrTableCell230.Visible = _CurrentDataLine.Week14Date.HasValue


                XrTableCell132.Visible = _CurrentDataLine.Week1Date.HasValue
                XrTableCell133.Visible = _CurrentDataLine.Week2Date.HasValue
                XrTableCell134.Visible = _CurrentDataLine.Week3Date.HasValue
                XrTableCell135.Visible = _CurrentDataLine.Week4Date.HasValue
                XrTableCell136.Visible = _CurrentDataLine.Week5Date.HasValue
                XrTableCell137.Visible = _CurrentDataLine.Week6Date.HasValue
                XrTableCell138.Visible = _CurrentDataLine.Week7Date.HasValue
                XrTableCell139.Visible = _CurrentDataLine.Week8Date.HasValue
                XrTableCell140.Visible = _CurrentDataLine.Week9Date.HasValue
                XrTableCell141.Visible = _CurrentDataLine.Week10Date.HasValue
                XrTableCell142.Visible = _CurrentDataLine.Week11Date.HasValue
                XrTableCell143.Visible = _CurrentDataLine.Week12Date.HasValue
                XrTableCell144.Visible = _CurrentDataLine.Week13Date.HasValue
                XrTableCell145.Visible = _CurrentDataLine.Week14Date.HasValue

                Dim ShowDemographicBand As Boolean = HasDemographicBand(_CurrentDataLine)

                XrTableCell105.Visible = ShowDemographicBand
                XrTableCell108.Visible = ShowDemographicBand

                XrTableCell126.Visible = ShowDemographicBand

                XrTableCell165.Visible = ShowDemographicBand

                If Not (_CurrentDataLine.ShowCPPM) Then
                    XrTableCell165.Visible = False
                    XrTableCell166.Visible = False
                Else

                    If _CurrentDataLine.ShowRatings Then

                        XrTableCell165.Visible = ShowDemographicBand

                    Else

                        XrTableCell165.Visible = False

                    End If

                    If _CurrentDataLine.ShowImpressions Then

                        XrTableCell166.Visible = ShowDemographicBand

                    Else

                        XrTableCell166.Visible = False

                    End If

                End If

                If Not (_CurrentDataLine.ShowImpressions) Then

                    XrTableCell107.Visible = False
                    XrTableCell109.Visible = False
                    XrTableCell123.Visible = False
                    XrTableCell124.Visible = False
                    XrTableCell156.Visible = False
                    XrTableCell159.Visible = False
                    XrTableCell162.Visible = False
                    XrTableCell169.Visible = False
                    XrTableCell173.Visible = False
                    XrTableCell176.Visible = False
                    XrTableCell179.Visible = False
                    XrTableCell182.Visible = False
                    XrTableCell200.Visible = False
                    XrTableCell228.Visible = False
                    XrTableCell229.Visible = False
                    XrTableCell230.Visible = False


                    XrTableCell253.Visible = False
                    XrTableRow12.Visible = False

                Else
                    XrTableCell253.Visible = ShowDemographicBand
                End If

                If Not (_CurrentDataLine.ShowRatings) Then

                    XrTableCell130.Visible = False
                    XrTableCell132.Visible = False
                    XrTableCell133.Visible = False
                    XrTableCell134.Visible = False
                    XrTableCell135.Visible = False
                    XrTableCell136.Visible = False
                    XrTableCell137.Visible = False
                    XrTableCell138.Visible = False
                    XrTableCell139.Visible = False
                    XrTableCell140.Visible = False
                    XrTableCell141.Visible = False
                    XrTableCell142.Visible = False
                    XrTableCell143.Visible = False
                    XrTableCell144.Visible = False
                    XrTableCell145.Visible = False


                    XrTableCell147.Visible = False
                    XrTableRow14.Visible = False
                Else
                    XrTableCell147.Visible = ShowDemographicBand
                End If

                If Not (_CurrentDataLine.ShowTotalCosts) Then
                    XrTableCell105.Visible = False
                    XrTableCell108.Visible = False

                    XrTableCell149.Visible = False
                    XrTableCell186.Visible = False
                    XrTableCell152.Visible = False
                    XrTableCell155.Visible = False
                    XrTableCell158.Visible = False
                    XrTableCell161.Visible = False

                    XrTableCell170.Visible = False
                    XrTableCell172.Visible = False
                    XrTableCell175.Visible = False
                    XrTableCell178.Visible = False
                    XrTableCell181.Visible = False

                    XrTableCell189.Visible = False
                    XrTableCell192.Visible = False
                    XrTableCell195.Visible = False
                    XrTableCell198.Visible = False

                End If

                Dim MaxGRPOnFooterLine As Double = MaxLineGRP(_CurrentDataLine)

                If (MaxGRPOnFooterLine < 10) Then
                    _CurrentDataLine.GRPFormat = "{0:#.00}"
                ElseIf (MaxGRPOnFooterLine < 100) Then
                    _CurrentDataLine.GRPFormat = "{0:#.0}"
                Else
                    _CurrentDataLine.GRPFormat = "{0:#}"
                End If

            End If

        End Sub

        Private Function MaxLineGRP(DataLine As Database.Classes.MediaBroadcastWorksheetBroadcastScheduleDetail) As Double

            Dim TempMaxGRP As Double = 0.00

            '.Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.Vendor = DataLine.Vendor) AndAlso (DRW.BucketRow = DataLine.BucketRow)) _

            _Week1GRP = _Reportdata _
                        .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.BucketRow = DataLine.BucketRow) AndAlso (DRW.Week1Date = DataLine.Week1Date)) _
                        .Select(Function(DRW2) DRW2.Week1PrimaryGRP).Sum()

            If (_Week1GRP > TempMaxGRP) Then
                TempMaxGRP = _Week1GRP
            End If

            _Week2GRP = _Reportdata _
                        .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.BucketRow = DataLine.BucketRow) AndAlso (DRW.Week1Date = DataLine.Week1Date)) _
                        .Select(Function(DRW2) DRW2.Week2PrimaryGRP).Sum()

            If (_Week2GRP > TempMaxGRP) Then
                TempMaxGRP = _Week2GRP
            End If

            _Week3GRP = _Reportdata _
                        .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.BucketRow = DataLine.BucketRow) AndAlso (DRW.Week1Date = DataLine.Week1Date)) _
                        .Select(Function(DRW2) DRW2.Week3PrimaryGRP).Sum()

            If (_Week3GRP > TempMaxGRP) Then
                TempMaxGRP = _Week3GRP
            End If

            _Week4GRP = _Reportdata _
                       .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.BucketRow = DataLine.BucketRow) AndAlso (DRW.Week1Date = DataLine.Week1Date)) _
                        .Select(Function(DRW2) DRW2.Week4PrimaryGRP).Sum()

            If (_Week4GRP > TempMaxGRP) Then
                TempMaxGRP = _Week4GRP
            End If

            _Week5GRP = _Reportdata _
                       .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.BucketRow = DataLine.BucketRow) AndAlso (DRW.Week1Date = DataLine.Week1Date)) _
                        .Select(Function(DRW2) DRW2.Week5PrimaryGRP).Sum()

            If (_Week5GRP > TempMaxGRP) Then
                TempMaxGRP = _Week5GRP
            End If

            _Week6GRP = _Reportdata _
                        .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.BucketRow = DataLine.BucketRow) AndAlso (DRW.Week1Date = DataLine.Week1Date)) _
                        .Select(Function(DRW2) DRW2.Week6PrimaryGRP).Sum()

            If (_Week6GRP > TempMaxGRP) Then
                TempMaxGRP = _Week6GRP
            End If

            _Week7GRP = _Reportdata _
                        .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.BucketRow = DataLine.BucketRow) AndAlso (DRW.Week1Date = DataLine.Week1Date)) _
                        .Select(Function(DRW2) DRW2.Week7PrimaryGRP).Sum()

            If (_Week7GRP > TempMaxGRP) Then
                TempMaxGRP = _Week7GRP
            End If

            _Week8GRP = _Reportdata _
                        .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.BucketRow = DataLine.BucketRow) AndAlso (DRW.Week1Date = DataLine.Week1Date)) _
                        .Select(Function(DRW2) DRW2.Week8PrimaryGRP).Sum()

            If (_Week8GRP > TempMaxGRP) Then
                TempMaxGRP = _Week8GRP
            End If

            _Week9GRP = _Reportdata _
                        .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.BucketRow = DataLine.BucketRow) AndAlso (DRW.Week1Date = DataLine.Week1Date)) _
                        .Select(Function(DRW2) DRW2.Week9PrimaryGRP).Sum()

            If (_Week9GRP > TempMaxGRP) Then
                TempMaxGRP = _Week9GRP
            End If

            _Week10GRP = _Reportdata _
                        .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.BucketRow = DataLine.BucketRow) AndAlso (DRW.Week1Date = DataLine.Week1Date)) _
                        .Select(Function(DRW2) DRW2.Week10PrimaryGRP).Sum()

            If (_Week10GRP > TempMaxGRP) Then
                TempMaxGRP = _Week10GRP
            End If

            _Week11GRP = _Reportdata _
                        .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.BucketRow = DataLine.BucketRow) AndAlso (DRW.Week1Date = DataLine.Week1Date)) _
                        .Select(Function(DRW2) DRW2.Week11PrimaryGRP).Sum()

            If (_Week11GRP > TempMaxGRP) Then
                TempMaxGRP = _Week11GRP
            End If

            _Week12GRP = _Reportdata _
                        .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.BucketRow = DataLine.BucketRow) AndAlso (DRW.Week1Date = DataLine.Week1Date)) _
                        .Select(Function(DRW2) DRW2.Week12PrimaryGRP).Sum()

            If (_Week12GRP > TempMaxGRP) Then
                TempMaxGRP = _Week12GRP
            End If

            _Week13GRP = _Reportdata _
                        .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.BucketRow = DataLine.BucketRow) AndAlso (DRW.Week1Date = DataLine.Week1Date)) _
                        .Select(Function(DRW2) DRW2.Week13PrimaryGRP).Sum()

            If (_Week13GRP > TempMaxGRP) Then
                TempMaxGRP = _Week13GRP
            End If

            _Week14GRP = _Reportdata _
                        .Where(Function(DRW) (DRW.MediaBroadcastWorksheetMarketID = DataLine.MediaBroadcastWorksheetMarketID) AndAlso (DRW.VendorCode = DataLine.VendorCode) AndAlso (DRW.BucketRow = DataLine.BucketRow) AndAlso (DRW.Week1Date = DataLine.Week1Date)) _
                        .Select(Function(DRW2) DRW2.Week14PrimaryGRP).Sum()

            If (_Week14GRP > TempMaxGRP) Then
                TempMaxGRP = _Week14GRP
            End If

            MaxLineGRP = TempMaxGRP
        End Function

        Private Sub GroupHeader1_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupHeader1.BeforePrint

            XrTableCell51.Visible = False
            XrTableCell53.Visible = False
            XrTableCell55.Visible = False
            XrTableCell57.Visible = False
            XrTableCell59.Visible = False
            XrTableCell61.Visible = False
            XrTableCell63.Visible = False
            XrTableCell65.Visible = False
            XrTableCell67.Visible = False
            XrTableCell69.Visible = False
            XrTableCell71.Visible = False
            XrTableCell73.Visible = False
            XrTableCell75.Visible = False
            XrTableCell77.Visible = False

            If (_CurrentDataLine IsNot Nothing) Then
                Dim ShowDemographicBand As Boolean = HasDemographicBand(_CurrentDataLine)

                XrTableCell81.Visible = ShowDemographicBand

                XrTableCell84.Visible = ShowDemographicBand
                XrTableCell221.Visible = ShowDemographicBand
                XrTableCell222.Visible = ShowDemographicBand

                If (_CurrentDataLine.IsGross) Then
                    XrTableCell49.Text = "Gross"
                    If (_ShowNet) Then
                        XrTableCell49.Text = "Net"
                    End If
                Else
                    XrTableCell49.Text = "Net"
                    If (_ShowNet) Then
                        XrTableCell49.Text = "Gross"
                    End If
                End If

                If ((Not _CurrentDataLine.ShowSpotCosts) And (Not _CurrentDataLine.ShowTotalCosts)) Then
                    XrTableCell49.Visible = False
                    XrTableCell205.Visible = False
                End If

                If _CurrentDataLine.ShowCPPM = False Then
                    XrTableCell222.Visible = False
                    XrTableCell223.Visible = False
                Else

                    If _CurrentDataLine.ShowRatings Then

                        XrTableCell222.Visible = ShowDemographicBand

                    Else

                        XrTableCell222.Visible = False

                    End If

                    If _CurrentDataLine.ShowImpressions Then

                        XrTableCell223.Visible = ShowDemographicBand

                    Else

                        XrTableCell223.Visible = False

                    End If

                End If

                If _CurrentDataLine.ShowRatings = False Then
                    XrTableCell82.Visible = False
                Else
                    XrTableCell82.Visible = ShowDemographicBand
                End If

                If _CurrentDataLine.ShowImpressions = False Then
                    XrTableCell84.Visible = False
                Else
                    XrTableCell84.Visible = ShowDemographicBand
                End If

                If Not (_CurrentDataLine.ShowRatings AndAlso _CurrentDataLine.ShowImpressions AndAlso _CurrentDataLine.ShowCPPM) Then
                    'XrTableCell81.Visible = False
                    XrTableCell21.Visible = False
                    XrTableCell22.Visible = False
                    XrTableCell27.Visible = False
                    XrTableCell28.Visible = False
                    XrTableCell33.Visible = False
                    XrTableCell34.Visible = False
                Else
                    XrTableCell21.Visible = True
                    XrTableCell22.Visible = True
                    XrTableCell27.Visible = Not String.IsNullOrWhiteSpace(_CurrentDataLine.Survey)
                    XrTableCell28.Visible = True
                    XrTableCell33.Visible = Not String.IsNullOrWhiteSpace(_CurrentDataLine.SurveyLine2)
                    XrTableCell34.Visible = True
                End If

                If _CurrentDataLine.ShowRatings = False AndAlso _CurrentDataLine.ShowImpressions = False AndAlso _CurrentDataLine.ShowCPPM = False Then

                    XrTableCell81.Visible = False

                End If

            End If

            If (_CurrentDataLine IsNot Nothing) Then

                Dim WorksheetMarketNielsenTVBook As AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook = Nothing

                _CurrentDataLine.Buyer = ""
                _CurrentDataLine.EstimateComments = ""

                XrTableCell39.Visible = Not String.IsNullOrWhiteSpace(_CurrentDataLine.Buyer)
                XrTableCell43.Visible = Not String.IsNullOrWhiteSpace(_CurrentDataLine.EstimateComments)

                XrTableRow6.CanShrink = True
                XrTableRow7.CanShrink = True
                XrTableRow8.CanShrink = True

                XrTableRow6.Visible = (Not String.IsNullOrWhiteSpace(_CurrentDataLine.PrimaryDemographic)) AndAlso (Not String.IsNullOrWhiteSpace(_CurrentDataLine.SurveyLine2))
                XrTableRow7.Visible = Not String.IsNullOrWhiteSpace(_CurrentDataLine.Buyer)
                XrTableRow8.Visible = Not String.IsNullOrWhiteSpace(_CurrentDataLine.EstimateComments)
            End If

        End Sub
        Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

            Dim Cancel As Boolean = True

            If (_CurrentDataLine IsNot Nothing) Then

                If String.IsNullOrWhiteSpace(_LocationName) = False Then

                    If String.IsNullOrWhiteSpace(_CurrentDataLine.PageHeaderLogoPathLand) = False Then

                        If My.Computer.FileSystem.FileExists(_CurrentDataLine.PageHeaderLogoPathLand) Then

                            XrPictureBoxHeaderLogo.ImageUrl = _CurrentDataLine.PageHeaderLogoPathLand

                            Cancel = False

                        End If

                    ElseIf _LocationLogo IsNot Nothing AndAlso _LocationLogo.Image IsNot Nothing Then

                        Using MemoryStream = New System.IO.MemoryStream(_LocationLogo.Image)

                            XrPictureBoxHeaderLogo.ImageSource = New DevExpress.XtraPrinting.Drawing.ImageSource(System.Drawing.Image.FromStream(MemoryStream))

                            Cancel = False

                        End Using

                    End If

                End If

            End If

            e.Cancel = Cancel

        End Sub
        Private Sub XrLabelLocationHeaderInfo_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelLocationHeaderInfo.BeforePrint
            If (_CurrentDataLine IsNot Nothing) Then
                If Not String.IsNullOrEmpty(_CurrentDataLine.PageHeaderComment) Then
                    XrLabelLocationHeaderInfo.Text = _CurrentDataLine.PageHeaderComment
                End If
            End If

        End Sub

        Private Sub Detail_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
            If (_CurrentDataLine IsNot Nothing) Then
                If (_CurrentDataLine.MediaTypeCode = "T") Then
                    XrTableCell104.TextFormatString = "{0:#,#.0}"
                Else
                    XrTableCell104.TextFormatString = "{0:#,#}"
                End If

                Dim FormattedLineNumber As String = _CurrentDataLine.LineNumber.ToString.PadLeft(3, "0")
                Dim FormattedMakeGoodLine As String = IIf(_CurrentDataLine.MakeGoodNumber > 0, "-" + _CurrentDataLine.MakeGoodNumber.ToString.PadLeft(2, "0"), "")

                Dim FormattedSpacing As String = IIf(_CurrentDataLine.MakeGoodNumber = 0, "    ", " ")
                Dim FormattedCableNetwork As String = IIf(Not String.IsNullOrEmpty(_CurrentDataLine.CableNetwork), FormattedSpacing + _CurrentDataLine.CableNetwork, "")

                XrTableCell85.Text = FormattedLineNumber + FormattedMakeGoodLine + FormattedCableNetwork

                Dim ShowDemographicBand As Boolean = HasDemographicBand(_CurrentDataLine)

                XrTableCell86.Visible = _CurrentDataLine.ShowSpotCosts
                XrTableCell102.Visible = ShowDemographicBand
                XrTableCell249.Visible = ShowDemographicBand

                If Not (_CurrentDataLine.ShowCPPM) Then
                    XrTableCell249.Visible = False
                    XrTableCell250.Visible = False
                Else

                    If _CurrentDataLine.ShowRatings Then

                        XrTableCell249.Visible = ShowDemographicBand

                    Else

                        XrTableCell249.Visible = False

                    End If

                    If _CurrentDataLine.ShowImpressions Then

                        XrTableCell250.Visible = ShowDemographicBand

                    Else

                        XrTableCell250.Visible = False

                    End If

                End If

                If Not (_CurrentDataLine.ShowImpressions) Then
                    XrTableCell104.Visible = False
                Else
                    XrTableCell104.Visible = ShowDemographicBand
                End If

                If Not (_CurrentDataLine.ShowRatings) Then
                    XrTableCell103.Visible = False
                Else
                    XrTableCell103.Visible = ShowDemographicBand
                End If

                If (_CurrentDataLine.ShowComments) Then
                    If Not (String.IsNullOrEmpty(_CurrentDataLine.Comments)) Then
                        XrTableCell35.Text = "Comments:" + _CurrentDataLine.Comments
                        XrTableRow18.Visible = True
                    Else
                        XrTableRow18.Visible = False
                    End If
                Else
                    XrTableRow18.Visible = False
                End If

                XrTableRow19.Visible = False

                If (Not _CurrentDataLine.ShowBookends) Then
                    _CurrentDataLine.IsBookend = False
                End If

                If (Not _CurrentDataLine.ShowAddedValue) Then
                    _CurrentDataLine.IsAddedValue = False
                End If

                If (_CurrentDataLine.IsBookend Or _CurrentDataLine.IsAddedValue) Then
                    XrTableRow19.Visible = True
                    If (_CurrentDataLine.IsBookend And _CurrentDataLine.IsAddedValue) Then
                        XrTableCell272.Text = "Bookend, Added Value"
                    ElseIf (_CurrentDataLine.IsBookend And Not _CurrentDataLine.IsAddedValue) Then
                        XrTableCell272.Text = "Bookend"
                    Else
                        XrTableCell272.Text = "Added Value"
                    End If
                Else
                    XrTableRow19.Visible = False
                End If


            End If

        End Sub

        Private Function HasDemographicBand(DataLine As Database.Classes.MediaBroadcastWorksheetBroadcastScheduleDetail) As Boolean
            HasDemographicBand = DataLine.BucketLastRow And Not String.IsNullOrEmpty(DataLine.DemographicGroupName)
        End Function
        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_Date.Text = _Date
            LabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub MediaBroadcastWorksheetBroadcastScheduleDetailReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub

#End Region

    End Class

    Friend Class LineAndVendor
        Public Property Market As String
        Public Property LineNumber As Integer
        Public Property MakegoodNumber As Integer
        Public Property VendorCode As String
        Public Property Days As String
        Public Property ProgramName As String
        Public Property Rate As Nullable(Of Decimal)
        Public Sub New(ByVal Market As String, ByVal LineNumber As Integer, MakegoodNumber As Integer, ByVal VendorCode As String, ByVal Days As String, ByVal ProgramName As String, Rate As Nullable(Of Decimal))
            Me.Market = Market
            Me.LineNumber = LineNumber
            Me.MakegoodNumber = MakegoodNumber
            Me.VendorCode = VendorCode
            Me.Days = Days
            Me.ProgramName = ProgramName
            Me.Rate = Rate
        End Sub
    End Class

    Friend Class GroupingHolder

        Public Property Market As String
        Public Property LineNumber As Integer
        Public Property VendorCode As String
        Public Property ProgramName As String
        Public Property Days As String
        Public Property Rate As Decimal

        Public Property EarliestDate
        Public Sub New(ByVal Market As String, LineNumber As Integer, VendorCode As String, ProgramName As String, Days As String, Rate As Decimal, EarliestDate As Date)
            Me.Market = Market
            Me.LineNumber = LineNumber
            Me.VendorCode = VendorCode
            Me.ProgramName = ProgramName
            Me.Days = Days
            Me.Rate = Rate
            Me.EarliestDate = EarliestDate
        End Sub

    End Class
End Namespace
