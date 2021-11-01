Namespace Media

    Public Class MediaBroadcastWorksheetBroadcastScheduleWeeklySummaryReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0
        Private _CurrentDataLine As Database.Classes.MediaBroadcastWorksheetBroadcastScheduleWeeklySummary = Nothing
        Private _PrintGroup2 As Boolean = False
        Private _ShowNet As Boolean = True
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
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaBroadcastWorksheetBroadcastScheduleWeeklySummary
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property
        Public Property ParameterDictionary As Dictionary(Of String, Object)
        Public Property Session As AdvantageFramework.Security.Session
        Public Property DbContext As Database.DbContext
        Public Property MediaBroadcastWorksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet
        Public Property MediaBroadcastWorksheetMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)
#End Region

#Region " Methods "

        Private Sub MediaBroadcastWorksheetBroadcastScheduleWeeklySummaryReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded
            Dim MediaBroadcastWorksheetBroadcastScheduleWeeklySummary As Generic.List(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleWeeklySummary) = Nothing
            Dim ReachFreqDetailLines As Generic.List(Of Database.Classes.ReachFreqDetail) = Nothing
            Dim ReachFreqWeekDetailLines As Generic.List(Of Database.Classes.ReachFreqDetail) = Nothing

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

            Dim ShowRatings As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowRatings") Then
                    ShowRatings = ParameterDictionary("ShowRatings")
                End If
            Catch ex As Exception

            End Try

            Dim ShowComments As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowComments") Then
                    ShowComments = ParameterDictionary("ShowComments")
                End If
            Catch ex As Exception

            End Try

            Dim ShowSpotCosts As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowSpotCosts") Then
                    ShowSpotCosts = ParameterDictionary("ShowSpotCosts")
                End If
            Catch ex As Exception

            End Try

            Dim ShowImpressions As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowImpressions") Then
                    ShowImpressions = ParameterDictionary("ShowImpressions")
                End If
            Catch ex As Exception

            End Try

            Dim ShowBookends As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowBookends") Then
                    ShowBookends = ParameterDictionary("ShowBookends")
                End If
            Catch ex As Exception

            End Try

            Dim ShowTotalCosts As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowTotalCosts") Then
                    ShowTotalCosts = ParameterDictionary("ShowTotalCosts")
                End If
            Catch ex As Exception

            End Try

            Dim ShowCPPM As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowCPPM") Then
                    ShowCPPM = ParameterDictionary("ShowCPPM")
                End If
            Catch ex As Exception

            End Try

            Dim ShowAddedValue As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowAddedValue") Then
                    ShowAddedValue = ParameterDictionary("ShowAddedValue")
                End If
            Catch ex As Exception

            End Try


            Dim ShowRF As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("ShowRF") Then
                    ShowRF = ParameterDictionary("ShowRF")
                End If
            Catch ex As Exception

            End Try



            Try
                If ParameterDictionary.ContainsKey("ShowNetCost") Then
                    _ShowNet = ParameterDictionary("ShowNetCost")
                End If
            Catch ex As Exception

            End Try

            Dim WorksheetIsGross As Boolean = True

            Try
                If ParameterDictionary.ContainsKey("WorksheetIsGross") Then
                    WorksheetIsGross = ParameterDictionary("WorksheetIsGross")
                End If
            Catch ex As Exception

            End Try

            'Init

            MarketWorksheetMarketIdList = New Generic.List(Of Integer)
            UsePrimaryDemoList = New Generic.List(Of Boolean)
            BroadcastStartYearMonthList = New Generic.List(Of Nullable(Of Integer))
            BroadcastEndYearMonthList = New Generic.List(Of Nullable(Of Integer))


            Try
                If Me.ParameterDictionary.ContainsKey("MediaBroadcastWorksheetMarketBooks") Then
                    MediaBroadcastWorksheetMarketBooks = Me.ParameterDictionary("MediaBroadcastWorksheetMarketBooks")
                    MarketWorksheetMarketIdList = New List(Of Integer)
                    For Each WorksheetMarket In MediaBroadcastWorksheetMarketBooks
                        MarketWorksheetMarketIdList.Add(WorksheetMarket.MediaBroadcastWorksheetMarketID)
                        UsePrimaryDemoList.Add(WorksheetMarket.UsePrimaryDemo)

                        'Handle Nullable Integers
                        BroadcastStartYearMonthList.Add(WorksheetMarket.BroadcastStartYearMonth)
                        BroadcastEndYearMonthList.Add(WorksheetMarket.BroadcastEndYearMonth)
                    Next
                End If

                Using DbContext = New Database.DbContext(Session.ConnectionString, Session.UserCode)
                    MediaBroadcastWorksheetBroadcastScheduleWeeklySummary =
                    Reporting.Database.Procedures.MediaBroadcastWorksheetBroadcastScheduleReport.
                        LoadWeeklySummary(DbContext, MarketWorksheetMarketIdList, BroadcastStartYearMonthList, BroadcastEndYearMonthList, UsePrimaryDemoList, "Broadcast Schedule Weekly Report", VendorCodeList, _LocationName, _ShowNet, WorksheetIsGross).ToList()

                    ReachFreqDetailLines =
                    Reporting.Database.Procedures.MediaBroadcastWorksheetBroadcastScheduleReport.
                        LoadReachFreqDetails(DbContext, MarketWorksheetMarketIdList, BroadcastStartYearMonthList, BroadcastEndYearMonthList, UsePrimaryDemoList, VendorCodeList).ToList()

                    ReachFreqWeekDetailLines =
                   Reporting.Database.Procedures.MediaBroadcastWorksheetBroadcastScheduleReport.
                       LoadReachFreqWeekDetails(DbContext, MarketWorksheetMarketIdList, BroadcastStartYearMonthList, BroadcastEndYearMonthList, UsePrimaryDemoList, VendorCodeList).ToList()
                End Using

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If String.IsNullOrWhiteSpace(_LocationName) = False Then

                        _LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _LocationName, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderLandscape)

                    Else

                        _LocationLogo = Nothing

                    End If

                End Using

                CalculateReachAndFreq(MediaBroadcastWorksheetBroadcastScheduleWeeklySummary, ReachFreqWeekDetailLines, True)
                CalculateReachAndFreq(MediaBroadcastWorksheetBroadcastScheduleWeeklySummary, ReachFreqWeekDetailLines, False)

                CalculateTotalReachAndFreq(MediaBroadcastWorksheetBroadcastScheduleWeeklySummary, ReachFreqDetailLines, True)
                CalculateTotalReachAndFreq(MediaBroadcastWorksheetBroadcastScheduleWeeklySummary, ReachFreqDetailLines, False)

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

                For Each DataLine In MediaBroadcastWorksheetBroadcastScheduleWeeklySummary

                    If (DataLine.Spots = 0) Then
                        DataLine.Group1ReachPCT = 0
                        DataLine.Group2ReachPCT = 0
                        DataLine.PrimaryGrossImpressions = 0
                        DataLine.SecondaryGrossImpressions = 0
                    End If

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

                                End If

                            End If

                            If DataLine.HutputNielsenTVBookID.GetValueOrDefault(0) > 0 AndAlso ComScoreTVBooks IsNot Nothing AndAlso ComScoreTVBooks.Count > 0 Then

                                NielsenTVBook2 = ComScoreTVBooks.FirstOrDefault(Function(Entity) Entity.ID = DataLine.HutputNielsenTVBookID.GetValueOrDefault(0))

                                If NielsenTVBook2 IsNot Nothing Then

                                    DataLine.SurveyLine2 = NielsenTVBook2.Description

                                Else

                                    DataLine.SurveyLine2 = String.Empty

                                End If

                            End If

                        End If

                    Else

                        DataLine.Survey = String.Empty
                        DataLine.SurveyLine2 = String.Empty

                    End If

                    If Not (String.IsNullOrEmpty(DataLine.TRSource1)) Then
                        DataLine.TRSource1 += ":"
                    End If

                    If Not (String.IsNullOrEmpty(DataLine.TRSource2)) Then
                        DataLine.TRSource2 += ":"
                    End If

                    If (DataLine.MediaTypeCode = "R") Then
                        DataLine.RatingsSource = DataLine.RadioSource
                    End If

                    DataLine.ShowRatings = ShowRatings
                    DataLine.ShowComments = ShowComments
                    DataLine.ShowSpotCosts = ShowSpotCosts
                    DataLine.ShowImpressions = ShowImpressions
                    DataLine.ShowBookends = ShowBookends
                    DataLine.ShowTotalCosts = ShowTotalCosts
                    DataLine.ShowCPPM = ShowCPPM
                    DataLine.ShowAddedValue = ShowAddedValue
                    DataLine.ShowRF = ShowRF
                Next

                Me.DataSource = MediaBroadcastWorksheetBroadcastScheduleWeeklySummary

                If (MediaBroadcastWorksheetBroadcastScheduleWeeklySummary IsNot Nothing) Then
                    If (MediaBroadcastWorksheetBroadcastScheduleWeeklySummary.Count > 0) Then
                        _CurrentDataLine = MediaBroadcastWorksheetBroadcastScheduleWeeklySummary.FirstOrDefault
                        _CurrentDataLine = SetDateType(_CurrentDataLine)

                        If (_CurrentDataLine.MediaTypeCode = "R") Then
                            XrLabel1.TextFormatString = "{0:#,#}"
                            XrLabel2.TextFormatString = "{0:#,#}"
                        Else
                            XrLabel1.TextFormatString = "{0:#,#.0}"
                            XrLabel2.TextFormatString = "{0:#,#.0}"
                        End If

                        _PrintGroup2 = Not String.IsNullOrWhiteSpace(_CurrentDataLine.Group2Name)
                    Else
                        _CurrentDataLine = New Database.Classes.MediaBroadcastWorksheetBroadcastScheduleWeeklySummary
                        _PrintGroup2 = False
                    End If
                Else
                    _CurrentDataLine = New Database.Classes.MediaBroadcastWorksheetBroadcastScheduleWeeklySummary
                End If



            Catch ex As Exception

            End Try
        End Sub

        Private Function SetDateType(DataLine As Database.Classes.MediaBroadcastWorksheetBroadcastScheduleWeeklySummary) As Database.Classes.MediaBroadcastWorksheetBroadcastScheduleWeeklySummary
            If (DataLine.DateTypeName = "Daily") Then
                DataLine.HeaderBand = "Broadcast Schedule Daily Report"
                DataLine.DateLabel2 = "Date"
            Else
                DataLine.HeaderBand = "Broadcast Schedule Weekly Report"
                DataLine.DateLabel2 = "Week Of"
            End If
            SetDateType = DataLine
        End Function

        Private Sub MediaBroadcastWorksheetBroadcastScheduleWeeklySummaryReport_DataSourceRowChanged(sender As Object, e As DevExpress.XtraReports.UI.DataSourceRowEventArgs) Handles MyBase.DataSourceRowChanged
            _CurrentDataLine = TryCast(Me.GetCurrentRow(), Database.Classes.MediaBroadcastWorksheetBroadcastScheduleWeeklySummary)
            _CurrentDataLine = SetDateType(_CurrentDataLine)
            _PrintGroup2 = Not String.IsNullOrWhiteSpace(_CurrentDataLine.Group2Name)
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

        Private Sub GroupHeader1_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupHeader1.BeforePrint

            XrTableCell17.Visible = _PrintGroup2
            XrTableCell58.Visible = _PrintGroup2
            XrTableCell59.Visible = _PrintGroup2
            XrTableCell60.Visible = _PrintGroup2
            XrTableCell77.Visible = _PrintGroup2
            XrTableCell78.Visible = _PrintGroup2
            XrTableCell84.Visible = _PrintGroup2
            XrTableCell88.Visible = _PrintGroup2

            XrTableCell66.Visible = _PrintGroup2
            XrTableCell67.Visible = _PrintGroup2
            XrTableCell107.Visible = _PrintGroup2

            If (_CurrentDataLine IsNot Nothing) Then
                If (_CurrentDataLine.MediaTypeCode = "R") Then
                    XrTableCell23.TextFormatString = "{0:#,#}"
                    XrTableCell91.TextFormatString = "{0:#,#}"

                    XrTableRow3.CanShrink = True
                    XrTableRow4.CanShrink = True

                    XrTableRow3.Visible = (Not String.IsNullOrEmpty(_CurrentDataLine.MarketDescription)) AndAlso (Not String.IsNullOrEmpty(_CurrentDataLine.SurveyLine2))
                    XrTableRow4.Visible = (Not String.IsNullOrEmpty(_CurrentDataLine.Buyer)) AndAlso (Not String.IsNullOrEmpty(_CurrentDataLine.PrimaryDemographic))
                Else
                    XrTableCell23.TextFormatString = "{0:#,#.0}"
                    XrTableCell91.TextFormatString = "{0:#,#.0}"
                End If

                If (_CurrentDataLine.IsGross) Then
                    XrTableCell51.Text = "Gross Cost"
                    If (_ShowNet) Then
                        XrTableCell51.Text = "Net Cost"
                    End If
                Else
                    XrTableCell51.Text = "Net Cost"
                    If (_ShowNet) Then
                        XrTableCell51.Text = "Gross Cost"
                    End If
                End If

                If Not (_CurrentDataLine.ShowImpressions) Then
                    XrTableCell11.Visible = False
                    XrTableCell17.Visible = False
                End If

                If Not (_CurrentDataLine.ShowCPPM) Then
                    XrTableCell54.Visible = False
                    XrTableCell76.Visible = False

                    XrTableCell58.Visible = False
                    XrTableCell88.Visible = False

                Else

                    If _CurrentDataLine.ShowRatings Then

                        XrTableCell54.Visible = True
                        XrTableCell58.Visible = _PrintGroup2

                    Else

                        XrTableCell54.Visible = False
                        XrTableCell58.Visible = False

                    End If

                    If _CurrentDataLine.ShowImpressions Then

                        XrTableCell76.Visible = True
                        XrTableCell88.Visible = _PrintGroup2

                    Else

                        XrTableCell76.Visible = False
                        XrTableCell88.Visible = False

                    End If

                End If

                If Not (_CurrentDataLine.ShowTotalCosts) Then
                    XrTableCell51.Visible = False
                    XrTableCell52.Visible = False
                End If

                If Not (_CurrentDataLine.ShowRatings) Then
                    XrTableCell55.Visible = False
                    XrTableCell56.Visible = False

                    XrTableCell59.Visible = False
                    XrTableCell60.Visible = False
                End If

                If Not (_CurrentDataLine.ShowRF) Then
                    XrTableCell74.Visible = False
                    XrTableCell75.Visible = False

                    XrTableCell78.Visible = False
                    XrTableCell84.Visible = False
                End If

                If _CurrentDataLine.ShowRatings = False AndAlso _CurrentDataLine.ShowImpressions = False AndAlso
                        _CurrentDataLine.ShowRF = False AndAlso _CurrentDataLine.ShowCPPM = False Then

                    XrTableCell25.Visible = False
                    XrTableCell57.Visible = False
                    XrTableCell63.Visible = False

                    XrTableCell107.Visible = False
                    XrTableCell66.Visible = False
                    XrTableCell67.Visible = False
                End If

            End If

        End Sub

        Private Sub Detail_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
            XrTableCell29.Visible = _PrintGroup2
            XrTableCell89.Visible = _PrintGroup2
            XrTableCell90.Visible = _PrintGroup2
            XrTableCell91.Visible = _PrintGroup2
            XrTableCell103.Visible = _PrintGroup2
            XrTableCell104.Visible = _PrintGroup2
            XrTableCell105.Visible = _PrintGroup2

            If (_CurrentDataLine IsNot Nothing) Then

                If Not (_CurrentDataLine.ShowTotalCosts) Then
                    XrTableCell82.Visible = False
                    XrTableCell83.Visible = False
                End If

                If Not (_CurrentDataLine.ShowCPPM) Then
                    XrTableCell85.Visible = False
                    XrTableCell101.Visible = False

                    XrTableCell89.Visible = False
                    XrTableCell105.Visible = False

                Else

                    If _CurrentDataLine.ShowRatings Then

                        XrTableCell85.Visible = True
                        XrTableCell89.Visible = _PrintGroup2

                    Else

                        XrTableCell85.Visible = False
                        XrTableCell89.Visible = False

                    End If

                    If _CurrentDataLine.ShowImpressions Then

                        XrTableCell101.Visible = True
                        XrTableCell105.Visible = _PrintGroup2

                    Else

                        XrTableCell101.Visible = False
                        XrTableCell105.Visible = False

                    End If

                End If

                If Not (_CurrentDataLine.ShowRatings) Then
                    XrTableCell86.Visible = False
                    XrTableCell87.Visible = False

                    XrTableCell90.Visible = False
                    XrTableCell29.Visible = False
                End If

                If Not (_CurrentDataLine.ShowImpressions) Then
                    XrTableCell23.Visible = False
                    XrTableCell91.Visible = False
                End If

                'If _CurrentDataLine.MediaTypeCode = "R" OrElse
                '        _CurrentDataLine.DateTypeName = "Daily" OrElse
                '        _CurrentDataLine.RatingsServiceID.GetValueOrDefault(1) = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                '    XrTableCell99.Visible = False
                '    XrTableCell100.Visible = False

                '    XrTableCell103.Visible = False
                '    XrTableCell104.Visible = False

                'Else

                If Not (_CurrentDataLine.ShowRF) Then
                    XrTableCell99.Visible = False
                    XrTableCell100.Visible = False

                    XrTableCell103.Visible = False
                    XrTableCell104.Visible = False
                End If

                'End If

            End If

        End Sub

        Private Sub GroupFooter1_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupFooter1.BeforePrint
            XrLabel2.Visible = _PrintGroup2

            XrLabel5.Visible = _PrintGroup2
            XrLabel7.Visible = _PrintGroup2
            XrLabel9.Visible = _PrintGroup2

            xrLabel34.Visible = _PrintGroup2
            XrLabel37.Visible = _PrintGroup2

            If (_CurrentDataLine IsNot Nothing) Then

                If Not (_CurrentDataLine.ShowTotalCosts) Then
                    xrLabel32.Visible = False
                End If

                If Not (_CurrentDataLine.ShowCPPM) Then
                    xrLabel33.Visible = False
                    XrLabel8.Visible = False

                    xrLabel34.Visible = False
                    XrLabel9.Visible = False

                Else

                    If _CurrentDataLine.ShowRatings Then

                        xrLabel33.Visible = True
                        xrLabel34.Visible = _PrintGroup2

                    Else

                        xrLabel33.Visible = False
                        xrLabel34.Visible = False

                    End If

                    If _CurrentDataLine.ShowImpressions Then

                        XrLabel8.Visible = True
                        XrLabel9.Visible = _PrintGroup2

                    Else

                        XrLabel8.Visible = False
                        XrLabel9.Visible = False

                    End If

                End If

                If Not (_CurrentDataLine.ShowRatings) Then
                    XrLabel36.Visible = False
                    XrLabel37.Visible = False
                End If

                If Not (_CurrentDataLine.ShowImpressions) Then
                    XrLabel1.Visible = False
                    XrLabel2.Visible = False
                End If

                If Not (_CurrentDataLine.ShowRF) Then
                    XrLabel4.Visible = False
                    XrLabel6.Visible = False

                    XrLabel5.Visible = False
                    XrLabel7.Visible = False
                End If

                If Not (_CurrentDataLine.ShowRatings And _CurrentDataLine.ShowImpressions And _CurrentDataLine.ShowCPPM And _CurrentDataLine.ShowRF) Then

                End If
            End If

        End Sub

        Private Sub PageHeader_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint
            If (_CurrentDataLine IsNot Nothing) Then
                XrLabel71.Text = _CurrentDataLine.PageHeaderComment
                XrTableCell41.Visible = Not String.IsNullOrEmpty(_CurrentDataLine.Survey)
                XrTableCell15.Visible = Not String.IsNullOrEmpty(_CurrentDataLine.SurveyLine2)
                XrTableCell21.Visible = Not String.IsNullOrEmpty(_CurrentDataLine.Buyer)

                If (_CurrentDataLine IsNot Nothing) Then
                    If Not (_CurrentDataLine.ShowRatings And _CurrentDataLine.ShowImpressions And _CurrentDataLine.ShowCPPM And _CurrentDataLine.ShowRF) Then
                        XrTableCell41.Visible = False
                        XrTableCell42.Visible = False

                        XrTableCell15.Visible = False
                        XrTableCell16.Visible = False
                    End If
                End If

            End If
        End Sub

        Private Sub CalculateReachAndFreq(MediaBroadcastWorksheetBroadcastScheduleWeeklySummary As Generic.List(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleWeeklySummary),
                                          ReachFreqDetailLines As Generic.List(Of Database.Classes.ReachFreqDetail),
                                          UsePrimaryDemo As Boolean)

            'objects
            Dim ReachTotal As Double = 0
            Dim MediaBroadcastWorksheetBroadcastScheduleWeeklySummaries As Generic.List(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleWeeklySummary) = Nothing
            Dim DemoInfos As Generic.List(Of Database.Classes.ReachFreqDetail) = Nothing
            Dim CumeImpressionsValues As Generic.List(Of Long) = Nothing
            Dim CumesValues As Generic.List(Of Long) = Nothing
            Dim AllReachValuesList As Generic.List(Of Double) = Nothing
            Dim AllReachValues() As Double = Nothing
            Dim TotalSpots As Integer = 0
            Dim Impressions As Long = 0
            Dim RowSpots As Integer = 0
            Dim TotalImpressions As Long = 0
            Dim TotalSpotImpressions As Long = 0
            Dim TotalRating As Decimal = 0
            Dim Universe As Long = 0
            Dim TotalAQH As Long = 0
            Dim AQH As Long = 0
            Dim BookRating As Decimal = 0

            Dim MarketDescriptionList As Object = MediaBroadcastWorksheetBroadcastScheduleWeeklySummary.Where(Function(DRW) DRW.MarketDescription.Length > 0).Select(Function(Entity) Entity.MarketDescription).Distinct.ToList

            For Each MarketDescription In MarketDescriptionList

                ReachTotal = 0
                CumeImpressionsValues = Nothing
                CumesValues = Nothing
                AllReachValuesList = Nothing
                AllReachValues = Nothing
                TotalSpots = 0
                Impressions = 0
                RowSpots = 0
                TotalImpressions = 0
                TotalSpotImpressions = 0
                TotalRating = 0
                Universe = 0
                TotalAQH = 0
                AQH = 0
                BookRating = 0

                Dim BroadCastWeekKeyList As Object = MediaBroadcastWorksheetBroadcastScheduleWeeklySummary.Where(Function(DRV) DRV.MarketDescription = MarketDescription).Select(Function(Entity) Entity.BroadCastWeekKey).Distinct.ToList

                For Each BroadCastWeekKey In BroadCastWeekKeyList

                    ReachTotal = 0
                    CumeImpressionsValues = Nothing
                    CumesValues = Nothing
                    AllReachValuesList = Nothing
                    AllReachValues = Nothing
                    TotalSpots = 0
                    Impressions = 0
                    RowSpots = 0
                    TotalImpressions = 0
                    TotalSpotImpressions = 0
                    TotalRating = 0
                    Universe = 0
                    TotalAQH = 0
                    AQH = 0
                    BookRating = 0

                    DemoInfos = ReachFreqDetailLines.Where(Function(Entity) (Entity.BroadCastWeekKey = BroadCastWeekKey) AndAlso (Entity.MarketDescription = MarketDescription) AndAlso Entity.OnHold = False).ToList

                    MediaBroadcastWorksheetBroadcastScheduleWeeklySummaries = MediaBroadcastWorksheetBroadcastScheduleWeeklySummary.Where(Function(Entity) (Entity.MarketDescription = MarketDescription) AndAlso (Entity.BroadCastWeekKey = BroadCastWeekKey)).ToList

                    Dim NielsenTVBookGood As Boolean = DemoInfos.Any(Function(Entity) Entity.SharebookNielsenTVBookID.GetValueOrDefault(0) > 0)
                    Dim NielsenTVStationCodeGood As Boolean = DemoInfos.Any(Function(Entity) Entity.VendorNielsenTVStationCode.GetValueOrDefault(0) <> 0)
                    Dim NetworkNielsenTVStationCodeGood As Boolean = DemoInfos.Any(Function(Entity) Entity.CableNetworkNielsenTVStationCode.GetValueOrDefault(0) <> 0)

                    If DemoInfos.Any(Function(Entity) Entity.SharebookNielsenTVBookID.GetValueOrDefault(0) > 0) AndAlso
                            DemoInfos.Any(Function(Entity) Entity.VendorNielsenTVStationCode.GetValueOrDefault(0) <> 0 OrElse
                                                           Entity.CableNetworkNielsenTVStationCode.GetValueOrDefault(0) <> 0) Then

                        CumeImpressionsValues = DemoInfos.Select(Function(Entity) If(UsePrimaryDemo, Entity.PrimaryCumeImpressions.GetValueOrDefault(0), Entity.SecondaryCumeImpressions.GetValueOrDefault(0))).Distinct.ToList

                    Else

                        CumeImpressionsValues = New Generic.List(Of Long)

                    End If

                    AllReachValuesList = New Generic.List(Of Double)

                    If CumeImpressionsValues.Count > 0 Then

                        For Each CumeInpression In CumeImpressionsValues

                            TotalSpots = 0
                            TotalImpressions = 0
                            TotalRating = 0
                            TotalSpotImpressions = 0
                            Universe = 0

                            For Each DemoInfo In DemoInfos.Where(Function(Entity) CumeInpression = If(UsePrimaryDemo, Entity.PrimaryCumeImpressions, Entity.SecondaryCumeImpressions))

                                RowSpots = 0
                                Impressions = If(UsePrimaryDemo, DemoInfo.PrimaryBuyImpressions.GetValueOrDefault(0), DemoInfo.SecondaryBuyImpressions.GetValueOrDefault(0))

                                TotalImpressions = Impressions
                                TotalRating += CDec(If(UsePrimaryDemo, DemoInfo.PrimaryRating.GetValueOrDefault(0), DemoInfo.SecondaryRating.GetValueOrDefault(0)))

                                If Universe = 0 Then

                                    Universe = CLng(If(UsePrimaryDemo, DemoInfo.PrimaryUniverse.GetValueOrDefault(0), DemoInfo.SecondaryUniverse.GetValueOrDefault(0)))

                                End If

                                RowSpots += DemoInfo.Spots

                                TotalSpots = RowSpots

                                TotalSpotImpressions += (Impressions * RowSpots)

                                BookRating = CDec(If(UsePrimaryDemo, DemoInfo.PrimaryBookRating.GetValueOrDefault(0), DemoInfo.SecondaryBookRating.GetValueOrDefault(0)))

                                If CumeInpression < Impressions Then

                                    AllReachValuesList.Add(CalculateCumlessReach(CDec(If(UsePrimaryDemo, DemoInfo.PrimaryRating.GetValueOrDefault(0), DemoInfo.SecondaryRating.GetValueOrDefault(0))), TotalSpots))

                                Else

                                    AllReachValuesList.Add(CalculateTVReach(Impressions, CumeInpression, RowSpots, Universe, CDec(If(UsePrimaryDemo, DemoInfo.PrimaryRating.GetValueOrDefault(0), DemoInfo.SecondaryRating.GetValueOrDefault(0))), BookRating))

                                End If

                            Next

                        Next

                    ElseIf MediaBroadcastWorksheetBroadcastScheduleWeeklySummaries IsNot Nothing AndAlso MediaBroadcastWorksheetBroadcastScheduleWeeklySummaries.Count > 0 Then

                        For Each DemoInfo In DemoInfos

                            If DemoInfo.MediaTypeCode = "R" Then

                                AllReachValuesList.Add(CalculateRadioReach(DemoInfo.PrimaryAQH.GetValueOrDefault(0), DemoInfo.PrimaryCume.GetValueOrDefault(0),
                                                                           DemoInfo.Spots.GetValueOrDefault(0), DemoInfo.PrimaryUniverse.GetValueOrDefault(0),
                                                                           DemoInfo.PrimaryAQHRating.GetValueOrDefault(0), DemoInfo.PrimaryBookAQHRating.GetValueOrDefault(0)))

                            ElseIf DemoInfo.MediaTypeCode = "T" Then

                                AllReachValuesList.Add(CalculateTVReach(DemoInfo.PrimaryBuyImpressions.GetValueOrDefault(0), DemoInfo.PrimaryCumeImpressions.GetValueOrDefault(0),
                                                                        DemoInfo.Spots.GetValueOrDefault(0), DemoInfo.PrimaryUniverse.GetValueOrDefault(0),
                                                                        DemoInfo.PrimaryRating.GetValueOrDefault(0), DemoInfo.PrimaryBookRating.GetValueOrDefault(0)))

                            End If

                        Next

                    End If

                    AllReachValues = AllReachValuesList.ToArray

                    If AllReachValues.Length > 2 Then

                        ReachTotal = (AllReachValues(0) + AllReachValues(1)) - (AllReachValues(0) * AllReachValues(1))

                        ReachTotal = Math.Round(ReachTotal, 3)

                        For ReachValueIndex As Integer = 2 To AllReachValues.Length - 1

                            ReachTotal = (ReachTotal + AllReachValues(ReachValueIndex)) - (ReachTotal * AllReachValues(ReachValueIndex))

                            ReachTotal = Math.Round(ReachTotal, 3)

                        Next

                    ElseIf AllReachValues.Length = 2 Then

                        ReachTotal = (AllReachValues(0) + AllReachValues(1)) - (AllReachValues(0) * AllReachValues(1))

                        ReachTotal = Math.Round(ReachTotal, 3)

                    ElseIf AllReachValues.Length = 1 Then

                        ReachTotal = AllReachValues(0)

                    End If

                    If Double.IsNaN(ReachTotal) Then

                        ReachTotal = 0

                    End If

                    For Each MDODOD In MediaBroadcastWorksheetBroadcastScheduleWeeklySummary.Where(Function(Entity) (Entity.MarketDescription = MarketDescription) AndAlso (Entity.BroadCastWeekKey = BroadCastWeekKey)).ToList
                        If (UsePrimaryDemo) Then
                            MDODOD.Group1ReachPCT = ReachTotal

                            MDODOD.Group1Frequency = CalcFreq(MDODOD.Group1ReachPCT, MDODOD.Group1PrimaryGRP)
                        Else
                            MDODOD.Group2ReachPCT = ReachTotal

                            MDODOD.Group2Frequency = CalcFreq(MDODOD.Group2ReachPCT, MDODOD.Group2PrimaryGRP)
                        End If

                    Next

                Next
            Next



        End Sub

        Private Sub CalculateTotalReachAndFreq(MediaBroadcastWorksheetBroadcastScheduleWeeklySummary As Generic.List(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleWeeklySummary),
                                          ReachFreqDetailLines As Generic.List(Of Database.Classes.ReachFreqDetail),
                                          UsePrimaryDemo As Boolean)

            'objects
            Dim ReachTotal As Double = 0
            Dim MediaBroadcastWorksheetBroadcastScheduleWeeklySummaries As Generic.List(Of Database.Classes.MediaBroadcastWorksheetBroadcastScheduleWeeklySummary) = Nothing
            Dim DemoInfos As Generic.List(Of Database.Classes.ReachFreqDetail) = Nothing
            Dim CumeImpressionsValues As Generic.List(Of Long) = Nothing
            Dim CumesValues As Generic.List(Of Long) = Nothing
            Dim AllReachValuesList As Generic.List(Of Double) = Nothing
            Dim AllReachValues() As Double = Nothing
            Dim TotalSpots As Integer = 0
            Dim Impressions As Long = 0
            Dim RowSpots As Integer = 0
            Dim TotalImpressions As Long = 0
            Dim TotalSpotImpressions As Long = 0
            Dim TotalRating As Decimal = 0
            Dim Universe As Long = 0
            Dim TotalAQH As Long = 0
            Dim AQH As Long = 0
            Dim BookRating As Decimal = 0

            Dim MarketDescriptionList As Object = MediaBroadcastWorksheetBroadcastScheduleWeeklySummary.Where(Function(DRW) DRW.MarketDescription.Length > 0).Select(Function(Entity) Entity.MarketDescription).Distinct.ToList

            For Each MarketDescription In MarketDescriptionList



                ReachTotal = 0
                CumeImpressionsValues = Nothing
                CumesValues = Nothing
                AllReachValuesList = Nothing
                AllReachValues = Nothing
                TotalSpots = 0
                Impressions = 0
                RowSpots = 0
                TotalImpressions = 0
                TotalSpotImpressions = 0
                TotalRating = 0
                Universe = 0
                TotalAQH = 0
                AQH = 0
                BookRating = 0

                DemoInfos = ReachFreqDetailLines.Where(Function(Entity) (Entity.MarketDescription = MarketDescription) AndAlso Entity.OnHold = False).ToList

                MediaBroadcastWorksheetBroadcastScheduleWeeklySummaries = MediaBroadcastWorksheetBroadcastScheduleWeeklySummary.Where(Function(Entity) (Entity.MarketDescription = MarketDescription)).ToList

                Dim _Total1GRP As Double = MediaBroadcastWorksheetBroadcastScheduleWeeklySummary.Where(Function(Entity) (Entity.MarketDescription = MarketDescription)).Select(Function(x) x.Group1PrimaryGRP).Sum
                Dim _Total2GRP As Double = MediaBroadcastWorksheetBroadcastScheduleWeeklySummary.Where(Function(Entity) (Entity.MarketDescription = MarketDescription)).Select(Function(x) x.Group2PrimaryGRP).Sum

                If DemoInfos.Any(Function(Entity) Entity.SharebookNielsenTVBookID.GetValueOrDefault(0) > 0) AndAlso
                            DemoInfos.Any(Function(Entity) Entity.VendorNielsenTVStationCode.GetValueOrDefault(0) <> 0 OrElse
                                                           Entity.CableNetworkNielsenTVStationCode.GetValueOrDefault(0) <> 0) Then
                    CumeImpressionsValues = DemoInfos.Select(Function(Entity) If(UsePrimaryDemo, Entity.PrimaryCumeImpressions.GetValueOrDefault(0), Entity.SecondaryCumeImpressions.GetValueOrDefault(0))).Distinct.ToList
                Else
                    CumeImpressionsValues = New Generic.List(Of Long)
                End If

                AllReachValuesList = New Generic.List(Of Double)


                If CumeImpressionsValues.Count > 0 Then

                    For Each CumeInpression In CumeImpressionsValues

                        TotalSpots = 0
                        TotalImpressions = 0
                        TotalRating = 0
                        TotalSpotImpressions = 0
                        Universe = 0

                        For Each DemoInfo In DemoInfos.Where(Function(Entity) CumeInpression = If(UsePrimaryDemo, Entity.PrimaryCumeImpressions, Entity.SecondaryCumeImpressions))

                            RowSpots = 0
                            Impressions = If(UsePrimaryDemo, DemoInfo.PrimaryBuyImpressions.GetValueOrDefault(0), DemoInfo.SecondaryBuyImpressions.GetValueOrDefault(0))

                            TotalImpressions = Impressions
                            TotalRating += CDec(If(UsePrimaryDemo, DemoInfo.PrimaryRating.GetValueOrDefault(0), DemoInfo.SecondaryRating.GetValueOrDefault(0)))

                            If Universe = 0 Then
                                Universe = CLng(If(UsePrimaryDemo, DemoInfo.PrimaryUniverse.GetValueOrDefault(0), DemoInfo.SecondaryUniverse.GetValueOrDefault(0)))
                            End If

                            RowSpots += DemoInfo.Spots

                            TotalSpots = RowSpots

                            TotalSpotImpressions += (Impressions * RowSpots)

                            BookRating = CDec(If(UsePrimaryDemo, DemoInfo.PrimaryBookRating.GetValueOrDefault(0), DemoInfo.SecondaryBookRating.GetValueOrDefault(0)))

                            If CumeInpression < Impressions Then

                                AllReachValuesList.Add(CalculateCumlessReach(CDec(If(UsePrimaryDemo, DemoInfo.PrimaryRating.GetValueOrDefault(0), DemoInfo.SecondaryRating.GetValueOrDefault(0))), TotalSpots))

                            Else

                                AllReachValuesList.Add(CalculateTVReach(Impressions, CumeInpression, RowSpots, Universe, CDec(If(UsePrimaryDemo, DemoInfo.PrimaryRating.GetValueOrDefault(0), DemoInfo.SecondaryRating.GetValueOrDefault(0))), BookRating))

                            End If

                        Next

                    Next

                ElseIf MediaBroadcastWorksheetBroadcastScheduleWeeklySummaries IsNot Nothing AndAlso MediaBroadcastWorksheetBroadcastScheduleWeeklySummaries.Count > 0 Then

                    For Each DemoInfo In DemoInfos

                        AllReachValuesList.Add(If(UsePrimaryDemo, DemoInfo.PrimaryReach.GetValueOrDefault(0), DemoInfo.SecondaryReach.GetValueOrDefault(0)))

                    Next


                End If

                AllReachValues = AllReachValuesList.ToArray

                If AllReachValues.Length > 2 Then

                    ReachTotal = (AllReachValues(0) + AllReachValues(1)) - (AllReachValues(0) * AllReachValues(1))

                    ReachTotal = Math.Round(ReachTotal, 3)

                    For ReachValueIndex As Integer = 2 To AllReachValues.Length - 1

                        ReachTotal = (ReachTotal + AllReachValues(ReachValueIndex)) - (ReachTotal * AllReachValues(ReachValueIndex))

                        ReachTotal = Math.Round(ReachTotal, 3)

                    Next

                ElseIf AllReachValues.Length = 2 Then

                    ReachTotal = (AllReachValues(0) + AllReachValues(1)) - (AllReachValues(0) * AllReachValues(1))

                    ReachTotal = Math.Round(ReachTotal, 3)

                ElseIf AllReachValues.Length = 1 Then

                    ReachTotal = AllReachValues(0)

                End If

                If Double.IsNaN(ReachTotal) Then

                    ReachTotal = 0

                End If

                For Each MDODOD In MediaBroadcastWorksheetBroadcastScheduleWeeklySummary.Where(Function(Entity) (Entity.MarketDescription = MarketDescription)).ToList
                    If (UsePrimaryDemo) Then
                        MDODOD.Group1TotalReachPCT = ReachTotal

                        MDODOD.Group1TotalFrequency = CalcFreq(MDODOD.Group1TotalReachPCT, _Total1GRP)
                    Else
                        MDODOD.Group2TotalReachPCT = ReachTotal

                        MDODOD.Group2TotalFrequency = CalcFreq(MDODOD.Group2TotalReachPCT, _Total2GRP)
                    End If
                Next

            Next
        End Sub

        Private Function CalcFreq(ByRef Reach As Double, GRP As Double) As Double

            Dim FrequencyTotal As Decimal
            If Reach = 0 Then

                FrequencyTotal = 0

            Else

                FrequencyTotal = GRP / (Reach * 100)

            End If

            If Double.IsNaN(FrequencyTotal) Then

                FrequencyTotal = 0

            End If

            CalcFreq = FrequencyTotal
        End Function

        Private Sub XrLabelDisclamier_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelDisclamier.BeforePrint

            If _CurrentDataLine IsNot Nothing Then

                If _CurrentDataLine.ShowRF = False Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub XrLabelLocationHeaderInfo_PrintOnPage(sender As Object, e As DevExpress.XtraReports.UI.PrintOnPageEventArgs) Handles XrLabelLocationHeaderInfo.PrintOnPage

            If e.PageIndex > 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub XrLine3_PrintOnPage(sender As Object, e As DevExpress.XtraReports.UI.PrintOnPageEventArgs) Handles XrLine3.PrintOnPage

            If e.PageIndex > 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_Date.Text = _Date
            LabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub MediaBroadcastWorksheetBroadcastScheduleWeeklySummaryReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub

#End Region

    End Class

End Namespace

