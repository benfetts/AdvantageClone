Namespace Reporting.Presentation
    Public Class MediaBroadcastWorksheetBroadcastScheduleCriteriaDialog

#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Reporting.MediaBroadcastWorksheetCriteriaViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Reporting.MediaBroadcastWorksheetCriteriaController = Nothing
        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing
        Private _MediaBroadcastWorksheetBroadcastScheduleCriteriaBuyType _
                As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetBroadcastScheduleReportCriteriaBuyType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetBroadcastScheduleReportCriteriaBuyType.Pre
        Private _MediaBroadcastWorksheetID As Nullable(Of Integer) = Nothing

        '---
        Private _OfficeListLocations As List(Of AdvantageFramework.Reporting.Database.Classes.Location) = Nothing
        Private _Criteria As List(Of AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetCriteria) = Nothing

        Private _MonthNameDictionary As Dictionary(Of String, Integer) = Nothing
        Private _MonthNumberDictionary As Dictionary(Of Integer, String) = Nothing

        Private _BroadcastTemplates As List(Of Reporting.Presentation.Classes.BroadcastTemplate) = Nothing
        Private _TemplateID As Integer = -1
        Private _InitialLoad As Boolean = False
        Private _NoSpots As Boolean = False
        Private _WorksheetIsGross As Boolean = False

        Dim _Location As AdvantageFramework.Database.Entities.Location = Nothing
        Dim _ComscoreUseNewMarket As Boolean = False
        Private _HideReachFrequency As Boolean = False

#End Region

#Region " Properties "
        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property
#End Region

#Region " Methods "

        Private Sub FillMonthDictionaries()
            _MonthNameDictionary = New Dictionary(Of String, Integer) From {
                {"JAN", 1},
                {"FEB", 2},
                {"MAR", 3},
                {"APR", 4},
                {"MAY", 5},
                {"JUN", 6},
                {"JUL", 7},
                {"AUG", 8},
                {"SEP", 9},
                {"OCT", 10},
                {"NOV", 11},
                {"DEC", 12}
            }

            _MonthNumberDictionary = New Dictionary(Of Integer, String) From {
                {1, "JAN"},
                {2, "FEB"},
                {3, "MAR"},
                {4, "APR"},
                {5, "MAY"},
                {6, "JUN"},
                {7, "JUL"},
                {8, "AUG"},
                {9, "SEP"},
                {10, "OCT"},
                {11, "NOV"},
                {12, "DEC"}
            }
        End Sub
        Private Function DecodeMonthYear(Line As String) As String

            Dim Month As String = Line.Split(" ")(0)
            Dim Year As String = Line.Split(" ")(1)

            Month = _MonthNameDictionary(Month).ToString
            Month = Month.PadLeft(2, "0")

            DecodeMonthYear = Year + Month
        End Function
        Function ListYearMonths(BeginingDate As Date, EndingDate As Date) As List(Of String)

            Dim BeginMonth As Integer = BeginingDate.Year * 100 + BeginingDate.Month
            Dim EndingMonth As Integer = EndingDate.Year * 100 + EndingDate.Month

            Dim MonthLists As List(Of String) = Nothing

            MonthLists = New List(Of String)

            Dim RunningMonth As Date = BeginingDate

            While (RunningMonth < EndingDate)
                MonthLists.Add(RunningMonth.Year * 100 + RunningMonth.Month)
                RunningMonth = RunningMonth.AddMonths(1)
            End While


            If Not (MonthLists.Contains(EndingMonth)) Then
                MonthLists.Add(EndingMonth)
            End If

            ListYearMonths = MonthLists
        End Function
        Private Function GetLastDayOfBroadcastMonth(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Day As Date, BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Date

            Dim MaxWeekDate As Nullable(Of Date) = Nothing
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing
            Dim LastDay As Nullable(Of Date) = Nothing

            MaxWeekDate = (From Dates In BroadcastCalendarWeeks
                           Where Dates.WeekDate <= Day
                           Select Dates.WeekDate).Max

            If MaxWeekDate IsNot Nothing Then

                BroadcastCalendarWeek = (From Dates In BroadcastCalendarWeeks
                                         Where Dates.WeekDate = MaxWeekDate).SingleOrDefault

                If BroadcastCalendarWeek IsNot Nothing Then

                    LastDay = (From Dates In BroadcastCalendarWeeks
                               Where Dates.Month = BroadcastCalendarWeek.Month AndAlso
                                     Dates.Year = BroadcastCalendarWeek.Year
                               Select Dates.WeekDate).Max.AddDays(6)

                End If

            End If

            GetLastDayOfBroadcastMonth = LastDay

        End Function
        Public Function GetBroadcastDate(RequestDate As Date, Period As String,
                                         BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Date

            Dim FullDate As Date = Date.MinValue
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing
            'Braxton
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If Period = "'B'" Then

                    BroadcastCalendarWeek = (From Entity In BroadcastCalendarWeeks
                                             Where Entity.WeekDate <= RequestDate).OrderByDescending(Function(Entity) Entity.WeekDate).FirstOrDefault

                    If BroadcastCalendarWeek IsNot Nothing Then

                        FullDate = New Date(BroadcastCalendarWeek.Year, BroadcastCalendarWeek.Month, 1)

                    End If

                Else

                    FullDate = GetLastDayOfBroadcastMonth(DbContext, RequestDate, BroadcastCalendarWeeks)

                End If

            End Using

            GetBroadcastDate = FullDate

        End Function
        Public Sub PopulateTemplateScreen(MediaBroadcastWorksheetID As Integer)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _ComscoreUseNewMarket = True

                _BroadcastTemplates = DbContext.Database.SqlQuery(Of Reporting.Presentation.Classes.BroadcastTemplate)(String.Format("EXEC dbo.proc_MEDIA_BROADCAST_SCHEDULE_TEMPLATELoad @WorkSheetID = {0}", MediaBroadcastWorksheetID)).ToList

            End Using

            For Each Template In _BroadcastTemplates
                Template.MarketList = Template.Markets.Split("|").ToList
                Template.VendorList = Template.Vendors.Split("|").ToList
            Next

            Templates_ListboxTemplates.Items.Clear()

            For Each Template In _BroadcastTemplates
                Templates_ListboxTemplates.Items.Add(Template.TemplateName)
            Next

            Templates_ButtonSaveOK.Enabled = False

        End Sub
        Public Sub PopulateReportOptionsScreen(MediaBroadcastWorksheetID As Integer)

            'objects
            Dim MediaBroadcastWorksheet As AdvantageFramework.Database.Entities.MediaBroadcastWorksheet = Nothing

            TabReportOptions.PerformClick()

            Dim BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek) = Nothing

            FillMonthDictionaries()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try
                    BroadcastCalendarWeeks = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)("EXEC dbo.advsp_broadcast_calendar_load").ToList
                Catch ex As Exception
                    BroadcastCalendarWeeks = New Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)
                End Try

                Try

                    MediaBroadcastWorksheet = DbContext.MediaBroadcastWorksheets.Find(MediaBroadcastWorksheetID)

                Catch ex As Exception
                    MediaBroadcastWorksheet = Nothing
                End Try

            End Using

            _Criteria = GetCriteria(_MediaBroadcastWorksheetID.Value)

            If (_Criteria IsNot Nothing) Then

                If (_Criteria.Count > 0) Then

                    If (_Criteria.First.MediaBroadcastWorksheetDateTypeID = 1) Then
                        ReportOptions_CheckBoxScheduleWDSummary.Text = "Daily Summary"
                    Else
                        ReportOptions_CheckBoxScheduleWDSummary.Text = "Weekly Summary"
                    End If

                    If (_Criteria.First.MediaTypeCode = "R") Then
                        ReportOptions_CheckBoxShowImpressions.Text = "Show AQH"
                    End If

                    _WorksheetIsGross = _Criteria.First.IsGross
                    If (_WorksheetIsGross) Then
                        ReportOptions_CheckBoxShowNetCost.Text = "Show Net Cost"
                    Else
                        ReportOptions_CheckBoxShowNetCost.Text = "Show Gross Cost"
                    End If


                    If (_Criteria.Where(Function(x) x.VendorCode IsNot Nothing).Any) Then
                        _OfficeListLocations = GetLocations()


                        If (_OfficeListLocations IsNot Nothing) Then
                            If (_OfficeListLocations.Count > 0) Then
                                ReportOptions_ComboBoxLocation.SelectedText = _OfficeListLocations.First.NAME
                                For Each OfficeLocation In _OfficeListLocations.Where(Function(x) Not String.IsNullOrEmpty(x.NAME)).OrderBy(Function(x) x.NAME)
                                    ReportOptions_ComboBoxLocation.Items.Add(OfficeLocation.NAME)
                                Next
                                ReportOptions_ComboBoxLocation.SelectedIndex = 0
                            Else
                                ReportOptions_ComboBoxLocation.SelectedIndex = 0
                            End If

                        End If

                        Dim BroadcastBeginDate As Date = GetBroadcastDate(_Criteria.First.StartDate, "'B'", BroadcastCalendarWeeks)
                        Dim BroadcastEndDate As Date = GetBroadcastDate(_Criteria.First.EndDate, "'E'", BroadcastCalendarWeeks)
                        Dim YearMonthList As List(Of String) = ListYearMonths(BroadcastBeginDate, BroadcastEndDate)

                        For Each YearMonth In YearMonthList
                            ReportOptions_ComboBoxFrom.Items.Add(_MonthNumberDictionary(YearMonth.Substring(4, 2)) + " " + YearMonth.Substring(0, 4))
                            ReportOptions_ComboBoxTo.Items.Add(_MonthNumberDictionary(YearMonth.Substring(4, 2)) + " " + YearMonth.Substring(0, 4))
                        Next

                        ReportOptions_ComboBoxFrom.SelectedIndex = 0

                        ReportOptions_ComboBoxTo.SelectedIndex = ReportOptions_ComboBoxTo.Items.Count - 1

                        Dim MarketList As List(Of Reporting.Presentation.Classes.MarketElem) = _Criteria.Select(Function(x) New Reporting.Presentation.Classes.MarketElem(x.MarketCode, x.IsCable, x.MarketDescription)).Distinct.ToList

                        Dim VendorList As List(Of Reporting.Presentation.Classes.VendorElem) = _Criteria.Select(Function(x) New Reporting.Presentation.Classes.VendorElem(x.MarketCode, x.MarketDescription + If(x.IsCable, " (Cable)", ""), x.VendorCode, x.VendorName, x.IsCable)).Distinct.ToList

                        For Each MarketLine In MarketList.OrderBy(Function(x) x.MarketDescription)
                            Dim Market As String
                            Market = MarketLine.MarketCode + " : " + MarketLine.MarketDescription + If(MarketLine.IsCable, " (Cable)", "")
                            If (ReportOptions_ListBoxMarkets.Items.IndexOf(Market) = -1) Then
                                ReportOptions_ListBoxMarkets.Items.Add(Market)
                            End If
                        Next

                        ReportOptions_ListBoxMarkets.SelectionMode = Windows.Forms.SelectionMode.MultiExtended

                        For Line As Integer = 0 To ReportOptions_ListBoxMarkets.Items.Count - 1
                            ReportOptions_ListBoxMarkets.SetSelected(Line, True)
                        Next

                        For Each Vendor In VendorList.OrderBy(Function(x) x.VendorName)
                            Dim tmpVendor As String
                            tmpVendor = Vendor.MarketCode + " : " + Vendor.VendorName
                            If (ReportOptions_ListBoxVendor.Items.IndexOf(tmpVendor) = -1) Then
                                ReportOptions_ListBoxVendor.Items.Add(tmpVendor)
                            End If
                        Next
                    Else
                        _NoSpots = True
                        Me.Close()
                        AdvantageFramework.WinForm.MessageBox.Show("No spots entered for this worksheet.")
                    End If

                End If

                ReportOptions_CheckBoxScheduleDetail.Checked = True
                ReportOptions_CheckBoxScheduleMarket.Checked = True
                ReportOptions_CheckBoxScheduleStation.Checked = True
                ReportOptions_CheckBoxScheduleWDSummary.Checked = True

                ReportOptions_CheckBoxShowSecondary.Checked = False
                ReportOptions_CheckBoxShowRatings.Checked = True
                ReportOptions_CheckBoxShowComments.Checked = True
                ReportOptions_CheckBoxShowSpotCosts.Checked = True
                ReportOptions_CheckBoxShowImpressions.Checked = True
                ReportOptions_CheckBoxShowBookends.Checked = True
                ReportOptions_CheckBoxShowTotalCosts.Checked = True
                ReportOptions_CheckBoxShowCPPM.Checked = True
                ReportOptions_CheckBoxShowAddedValue.Checked = True
                ReportOptions_CheckBoxShowRF.Checked = True


            Else
                AdvantageFramework.WinForm.MessageBox.Show("No defined markets.")
            End If

            _InitialLoad = True

        End Sub
        Private Function GetCriteria(ByVal MediaBroadcastWorksheetID As Integer) As List(Of AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetCriteria)
            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)
                GetCriteria = DbContext.Database.SqlQuery(Of AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetCriteria) _
                    (String.Format("advsp_media_broadcast_criteria @MediaBroadcastWorksheetID = {0}", MediaBroadcastWorksheetID)).ToList
            End Using
        End Function
        Private Function GetLocations() As List(Of AdvantageFramework.Reporting.Database.Classes.Location)
            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)
                GetLocations = DbContext.Database.SqlQuery(Of AdvantageFramework.Reporting.Database.Classes.Location)("advsp_location_query").ToList
            End Using
        End Function
        Public Function NumberChecked() As Integer

            Dim CheckCount As Integer = 0

            If (ReportOptions_CheckBoxScheduleDetail.Checked) Then CheckCount += 1

            If (ReportOptions_CheckBoxScheduleMarket.Checked) Then CheckCount += 1

            If (ReportOptions_CheckBoxScheduleStation.Checked) Then CheckCount += 1

            If (ReportOptions_CheckBoxScheduleWDSummary.Checked) Then CheckCount += 1

            NumberChecked = CheckCount
        End Function

#End Region

#Region "Show Form Methods"

        Private Sub New(ParameterDictionary As Generic.Dictionary(Of String, Object), MediaBroadcastWorksheetID As Nullable(Of Integer), HideReachFrequency As Boolean)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary
            _MediaBroadcastWorksheetID = MediaBroadcastWorksheetID
            _HideReachFrequency = HideReachFrequency

        End Sub

        Private Sub MediaBroadcastWorksheetBroadcastScheduleCriteriaDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            PopulateTemplateScreen(_MediaBroadcastWorksheetID.Value)
            PopulateReportOptionsScreen(_MediaBroadcastWorksheetID.Value)
            Me.TabControl_Criteria.SelectedTabIndex = 0

            If _HideReachFrequency Then

                ReportOptions_CheckBoxShowRF.Visible = False
                ReportOptions_CheckBoxShowRF.Checked = False

            End If

        End Sub

        Public Shared Function ShowFormDialog(ByRef ParameterDictionary As Generic.Dictionary(Of String, Object), MediaBroadcastWorksheetID As Integer?, HideReachFrequency As Boolean) As Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetBroadcastScheduleCriteriaDialog As AdvantageFramework.Reporting.Presentation.MediaBroadcastWorksheetBroadcastScheduleCriteriaDialog = Nothing

            MediaBroadcastWorksheetBroadcastScheduleCriteriaDialog = New AdvantageFramework.Reporting.Presentation.MediaBroadcastWorksheetBroadcastScheduleCriteriaDialog(ParameterDictionary, MediaBroadcastWorksheetID, HideReachFrequency)

            ShowFormDialog = MediaBroadcastWorksheetBroadcastScheduleCriteriaDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = MediaBroadcastWorksheetBroadcastScheduleCriteriaDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "Form Event Handlers"
#End Region

#Region "Control Event Handlers"
        Private Sub BtnOkay_Click(sender As Object, e As EventArgs) Handles ReportOptions_ButtonOkay.Click

            'objects
            Dim ReportPrintTool As DevExpress.XtraReports.UI.ReportPrintTool = Nothing
            Dim PrintingSystemCommandHandler As AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler = Nothing
            Dim AgencyImportPath As String = String.Empty
            Dim LocationName As String
            Dim FoundVendor As String = Nothing

            If ReportOptions_ComboBoxLocation.SelectedItem IsNot Nothing AndAlso ReportOptions_ComboBoxLocation.Text = "" Then

                ReportOptions_ComboBoxLocation.SelectedItem = Nothing

            End If

            If ReportOptions_ComboBoxFrom.SelectedItem Is Nothing OrElse ReportOptions_ComboBoxTo.SelectedItem Is Nothing Then

                AdvantageFramework.WinForm.MessageBox.Show("From and To dates are required.")

            ElseIf (DecodeMonthYear(ReportOptions_ComboBoxFrom.SelectedItem) > DecodeMonthYear(ReportOptions_ComboBoxTo.SelectedItem)) Then

                AdvantageFramework.WinForm.MessageBox.Show("From and To dates are out of order.")

            ElseIf ReportOptions_ListBoxMarkets.SelectedItems.Count = 0 Then

                AdvantageFramework.WinForm.MessageBox.Show("Must have at least 1 market selected.")

            ElseIf ReportOptions_ListBoxVendor.SelectedItems.Count = 0 Then

                AdvantageFramework.WinForm.MessageBox.Show("Must have at least 1 station selected.")

            Else

                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.ShowWaitForm()

                Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
                Dim FinalReport As DevExpress.XtraReports.UI.XtraReport = Nothing
                Dim MarketBooksDictionary As Generic.List(Of AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook) = Nothing
                Dim VendorFilter As String = String.Empty

                Dim FoundVendors As List(Of String) = New List(Of String)
                Dim Dupevendors As List(Of String) = New List(Of String)

                For Each SelectedVendor As String In ReportOptions_ListBoxVendor.SelectedItems
                    Dim MarketCode = (SelectedVendor.Split(":"))(0).Trim
                    Dim VendorName = (SelectedVendor.Split(":"))(1).Trim

                    If _Criteria.Where(Function(x) (x.MarketCode = MarketCode) And (x.VendorName = VendorName)).Any Then

                        FoundVendor = _Criteria.Where(Function(x) (x.MarketCode = MarketCode) And (x.VendorName = VendorName)).First.VendorCode

                    Else

                        FoundVendor = Nothing

                    End If

                    If (Not String.IsNullOrEmpty(FoundVendor) AndAlso Not (FoundVendors.Contains(FoundVendor))) Then
                        FoundVendors.Add(FoundVendor)
                        VendorFilter += FoundVendor + ","
                    ElseIf String.IsNullOrWhiteSpace(FoundVendor) = False Then
                        Dupevendors.Add(FoundVendor)
                    End If

                Next

                If (VendorFilter.EndsWith(",")) Then
                    VendorFilter = VendorFilter.Substring(0, VendorFilter.Length - 1)
                End If

                MarketBooksDictionary = New List(Of AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook)
                _ParameterDictionary = New Dictionary(Of String, Object)

                For Each SelectedMarket As String In ReportOptions_ListBoxMarkets.SelectedItems

                    Dim MarketName As String = (SelectedMarket.Split(":"))(0).Trim
                    Dim MarketDescription As String = (SelectedMarket.Split(":"))(1).Trim
                    Dim MarketID As Integer = _Criteria.Where(Function(x) (x.MarketCode = MarketName) And (x.IsCable = IIf(MarketDescription.Contains("(Cable)"), True, False))).First.MediaBroadcastWorksheetMarketID

                    Dim NewWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing

                    NewWorksheetMarket = New AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket With {
                        .MediaBroadcastWorksheetID = _MediaBroadcastWorksheetID,
                        .MediaBroadcastWorksheet = New AdvantageFramework.Database.Entities.MediaBroadcastWorksheet
                    }

                    NewWorksheetMarket.MediaBroadcastWorksheet.Client = New AdvantageFramework.Database.Entities.Client
                    NewWorksheetMarket.MediaBroadcastWorksheet.Division = New AdvantageFramework.Database.Entities.Division
                    NewWorksheetMarket.MediaBroadcastWorksheet.Product = New AdvantageFramework.Database.Entities.Product
                    NewWorksheetMarket.Market = New AdvantageFramework.Database.Entities.Market With {
                        .Code = MarketName,
                        .Description = (SelectedMarket.Split(":"))(1).Trim
                    }

                    NewWorksheetMarket.MediaBroadcastWorksheet.ID = _MediaBroadcastWorksheetID
                    NewWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographicID = 0

                    NewWorksheetMarket.IsCable = (SelectedMarket.Split(":"))(1).Trim.Contains("(Cable)")

                    Dim MediaBroadcastWorksheetMarket As AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook = Nothing

                    Dim UsePrimary As Boolean = Not (ReportOptions_CheckBoxShowSecondary.Checked)

                    MediaBroadcastWorksheetMarket = New AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook(NewWorksheetMarket, _ComscoreUseNewMarket) With {
                    .MediaBroadcastWorksheetID = _MediaBroadcastWorksheetID,
                    .MediaBroadcastWorksheetMarketID = MarketID,
                    .UsePrimaryDemo = UsePrimary,
                    .BroadcastStartYearMonth = CInt(DecodeMonthYear(ReportOptions_ComboBoxFrom.SelectedItem)),
                    .BroadcastEndYearMonth = CInt(DecodeMonthYear(ReportOptions_ComboBoxTo.SelectedItem)),
                    .PrimaryMediaDemographicID = 0,
                    .SecondaryMediaDemographicID = 0
                }

                    MarketBooksDictionary.Add(MediaBroadcastWorksheetMarket)

                Next

                If (_OfficeListLocations.Where(Function(x) x.NAME = ReportOptions_ComboBoxLocation.SelectedItem).Any) Then
                    LocationName = _OfficeListLocations.Where(Function(x) x.NAME = ReportOptions_ComboBoxLocation.SelectedItem).FirstOrDefault.LOC_ID
                Else
                    LocationName = ""
                End If


                If (MarketBooksDictionary IsNot Nothing) Then
                    _ParameterDictionary.Add("MediaBroadcastWorksheetMarketBooks", MarketBooksDictionary)
                    _ParameterDictionary.Add("LocationName", LocationName)
                    _ParameterDictionary.Add("VendorFilter", VendorFilter)

                    _ParameterDictionary.Add("ShowRatings", ReportOptions_CheckBoxShowRatings.Checked.ToString)
                    _ParameterDictionary.Add("ShowComments", ReportOptions_CheckBoxShowComments.Checked.ToString)
                    _ParameterDictionary.Add("ShowSpotCosts", ReportOptions_CheckBoxShowSpotCosts.Checked.ToString)
                    _ParameterDictionary.Add("ShowImpressions", ReportOptions_CheckBoxShowImpressions.Checked.ToString)
                    _ParameterDictionary.Add("ShowBookends", ReportOptions_CheckBoxShowBookends.Checked.ToString)
                    _ParameterDictionary.Add("ShowTotalCosts", ReportOptions_CheckBoxShowTotalCosts.Checked.ToString)
                    _ParameterDictionary.Add("ShowCPPM", ReportOptions_CheckBoxShowCPPM.Checked.ToString)
                    _ParameterDictionary.Add("ShowAddedValue", ReportOptions_CheckBoxShowAddedValue.Checked.ToString)
                    _ParameterDictionary.Add("ShowRF", ReportOptions_CheckBoxShowRF.Checked.ToString)
                    _ParameterDictionary.Add("ShowNetCost", ReportOptions_CheckBoxShowNetCost.Checked.ToString)
                    _ParameterDictionary.Add("WorksheetIsGross", _WorksheetIsGross.ToString)

                    '--------
                    Dim MediaBroadcastWorksheetPrintOptions As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrintOptions = Nothing

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DbContext.Database.Connection.Open()

                        MediaBroadcastWorksheetPrintOptions = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetPrintOptions.LoadByUserCode(DbContext, Me.Session.UserCode)

                        If MediaBroadcastWorksheetPrintOptions IsNot Nothing Then

                            Using DataContext As New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                _Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, MediaBroadcastWorksheetPrintOptions.LocationCode)

                            End Using

                        End If

                    End Using
                    If (NumberChecked() > 0) Then
                        If (NumberChecked() = 1) Then

                            If (ReportOptions_CheckBoxScheduleDetail.Checked) Then
                                Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetBroadcastScheduleDetailReport(Me.Session, ParameterDictionary)
                            End If

                            If (ReportOptions_CheckBoxScheduleMarket.Checked) Then
                                Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetBroadcastScheduleMarketSummaryReport(Me.Session, ParameterDictionary)
                            End If

                            If (ReportOptions_CheckBoxScheduleStation.Checked) Then
                                Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetBroadcastScheduleStationSummaryReport(Me.Session, ParameterDictionary)
                            End If

                            If (ReportOptions_CheckBoxScheduleWDSummary.Checked) Then
                                Report = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetBroadcastScheduleWeeklySummaryReport(Me.Session, ParameterDictionary)
                            End If

                            If Report IsNot Nothing Then

                                Report.CreateDocument()

                                If (Report.RowCount = 0) Then
                                    AdvantageFramework.WinForm.MessageBox.Show("No records found.")
                                    Report = Nothing
                                Else

                                    ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)

                                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                        DbContext.Database.Connection.Open()

                                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                                            AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                                            If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                                                If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\") = False Then

                                                    My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")

                                                End If

                                            End If

                                            ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName("Broadcast Schedule")
                                            ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")
                                            ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                                            ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                                            ReportPrintTool.PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(Me.Session, If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\"), AdvantageFramework.FileSystem.CreateValidFileName("Broadcast Schedule"), False))

                                            ReportPrintTool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                                        Else

                                            ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName("Broadcast Schedule")

                                        End If

                                    End Using

                                    ReportPrintTool.ShowRibbonPreviewDialog()

                                End If

                            End If
                        Else

                            Dim FirstReport As DevExpress.XtraReports.UI.XtraReport = Nothing

                            Dim ScheduleDetail As DevExpress.XtraReports.UI.XtraReport = Nothing
                            Dim ScheduleMarketReport As DevExpress.XtraReports.UI.XtraReport = Nothing
                            Dim ScheduleStationReport As DevExpress.XtraReports.UI.XtraReport = Nothing
                            Dim ScheduleWDSummaryReport As DevExpress.XtraReports.UI.XtraReport = Nothing

                            If (ReportOptions_CheckBoxScheduleDetail.Checked) Then
                                If (FirstReport Is Nothing) Then
                                    FirstReport = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetBroadcastScheduleDetailReport(Me.Session, ParameterDictionary)
                                    If (FirstReport IsNot Nothing) Then
                                        FirstReport.CreateDocument()
                                    End If
                                Else
                                    ScheduleDetail = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetBroadcastScheduleDetailReport(Me.Session, ParameterDictionary)
                                    ScheduleDetail.CreateDocument()
                                    FirstReport.Pages.AddRange(ScheduleDetail.Pages)
                                End If
                            End If

                            If FirstReport IsNot Nothing AndAlso FirstReport.RowCount = 0 Then

                                FirstReport = Nothing

                            End If
                            If (ReportOptions_CheckBoxScheduleMarket.Checked) Then
                                If (FirstReport Is Nothing) Then
                                    FirstReport = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetBroadcastScheduleMarketSummaryReport(Me.Session, ParameterDictionary)
                                    If (FirstReport IsNot Nothing) Then
                                        FirstReport.CreateDocument()
                                    End If
                                Else
                                    ScheduleMarketReport = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetBroadcastScheduleMarketSummaryReport(Me.Session, ParameterDictionary)
                                    If (ScheduleMarketReport IsNot Nothing) Then
                                        ScheduleMarketReport.CreateDocument()
                                        If (ScheduleMarketReport.RowCount > 0) Then
                                            FirstReport.Pages.AddRange(ScheduleMarketReport.Pages)
                                        End If
                                    End If
                                End If
                            End If

                            If FirstReport IsNot Nothing AndAlso FirstReport.RowCount = 0 Then

                                FirstReport = Nothing

                            End If

                            If (ReportOptions_CheckBoxScheduleStation.Checked) Then
                                If (FirstReport Is Nothing) Then
                                    FirstReport = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetBroadcastScheduleStationSummaryReport(Me.Session, ParameterDictionary)
                                    If (FirstReport IsNot Nothing) Then
                                        FirstReport.CreateDocument()
                                    End If
                                Else
                                    ScheduleStationReport = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetBroadcastScheduleStationSummaryReport(Me.Session, ParameterDictionary)
                                    If (ScheduleStationReport IsNot Nothing) Then
                                        ScheduleStationReport.CreateDocument()
                                        If (ScheduleStationReport.RowCount > 0) Then
                                            FirstReport.Pages.AddRange(ScheduleStationReport.Pages)
                                        End If
                                    End If
                                End If
                            End If

                            If FirstReport IsNot Nothing AndAlso FirstReport.RowCount = 0 Then

                                FirstReport = Nothing

                            End If

                            If (ReportOptions_CheckBoxScheduleWDSummary.Checked) Then

                                If (FirstReport Is Nothing) Then
                                    FirstReport = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetBroadcastScheduleWeeklySummaryReport(Me.Session, ParameterDictionary)
                                    If (FirstReport IsNot Nothing) Then
                                        FirstReport.CreateDocument()
                                    End If
                                Else
                                    ScheduleWDSummaryReport = AdvantageFramework.Reporting.Reports.CreateMediaBroadcastWorksheetBroadcastScheduleWeeklySummaryReport(Me.Session, ParameterDictionary)
                                    If (ScheduleWDSummaryReport IsNot Nothing) Then
                                        ScheduleWDSummaryReport.CreateDocument()
                                        If (ScheduleWDSummaryReport.RowCount > 0) Then
                                            FirstReport.Pages.AddRange(ScheduleWDSummaryReport.Pages)
                                        End If
                                    End If
                                End If
                            End If

                            If FirstReport IsNot Nothing AndAlso FirstReport.RowCount = 0 Then

                                FirstReport = Nothing

                            End If

                            If FirstReport Is Nothing OrElse FirstReport.Pages.Count = 0 Then
                                Me.CloseWaitForm()
                                AdvantageFramework.WinForm.MessageBox.Show("No records found.")
                                Me.DialogResult = System.Windows.Forms.DialogResult.None
                                FirstReport = Nothing
                            Else
                                Me.CloseWaitForm()

                                ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(FirstReport)

                                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                    DbContext.Database.Connection.Open()

                                    If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                                        AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                                        If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                                            If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\") = False Then

                                                My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")

                                            End If

                                        End If

                                        ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName("Broadcast Schedule")
                                        ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")
                                        ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                                        ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                                        ReportPrintTool.PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(Me.Session, If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\"), AdvantageFramework.FileSystem.CreateValidFileName("Broadcast Schedule"), False))

                                        ReportPrintTool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                                    Else

                                        ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName("Broadcast Schedule")

                                    End If

                                End Using

                                ReportPrintTool.ShowRibbonPreviewDialog()

                            End If

                        End If
                    Else
                        Me.CloseWaitForm()
                        AdvantageFramework.WinForm.MessageBox.Show("At least 1 report must be selected.")
                        Me.DialogResult = System.Windows.Forms.DialogResult.None
                    End If
                    Me.CloseWaitForm()
                End If
            End If

        End Sub

        Private Sub LbMarkets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ReportOptions_ListBoxMarkets.SelectedIndexChanged
            Dim VendorList As List(Of Reporting.Presentation.Classes.VendorElem) = _Criteria.Select(Function(x) New Reporting.Presentation.Classes.VendorElem(x.MarketCode, x.MarketDescription, x.VendorCode, x.VendorName, x.IsCable)).Distinct.ToList

            Dim SelectedMarkets As List(Of String) = Nothing

            SelectedMarkets = New List(Of String)

            For Each Market As String In ReportOptions_ListBoxMarkets.SelectedItems
                Dim SelMarketDescription As String = Market.Split(":")(1).Trim
                SelectedMarkets.Add(SelMarketDescription)
            Next

            ReportOptions_ListBoxVendor.Items.Clear()

            For Each SelectedMarket In SelectedMarkets
                For Each Vendor In VendorList.Where(Function(x) SelectedMarket.Contains(x.MarketDescription) And (x.IsCable = SelectedMarket.Contains("(Cable)"))).OrderBy(Function(x) x.VendorName)
                    Dim tmpVendor As String
                    tmpVendor = Vendor.MarketCode + " : " + Vendor.VendorName
                    If (ReportOptions_ListBoxVendor.Items.IndexOf(tmpVendor) = -1) Then
                        ReportOptions_ListBoxVendor.Items.Add(tmpVendor)
                    End If
                Next
            Next

            For Line As Integer = 0 To ReportOptions_ListBoxVendor.Items.Count - 1
                ReportOptions_ListBoxVendor.SetSelected(Line, True)
            Next


        End Sub

        Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles ReportOptions_ButtonCancel.Click
            Me.Close()
        End Sub

        Private Sub LbTemplates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Templates_ListboxTemplates.SelectedIndexChanged
            'Read Template and change controls

            Dim FoundTemplate As Reporting.Presentation.Classes.BroadcastTemplate = Nothing
            Dim FoundTemplateName As String = Templates_ListboxTemplates.SelectedItem.ToString

            If (Not String.IsNullOrEmpty(FoundTemplateName)) Then
                FoundTemplate = _BroadcastTemplates.Where(Function(x) x.TemplateName = FoundTemplateName).First

                ReportOptions_CheckBoxScheduleDetail.Checked = FoundTemplate.RunDetail
                ReportOptions_CheckBoxScheduleMarket.Checked = FoundTemplate.RunMarket
                ReportOptions_CheckBoxScheduleStation.Checked = FoundTemplate.RunStation
                ReportOptions_CheckBoxScheduleWDSummary.Checked = FoundTemplate.RunWeeklyDaily

                ReportOptions_CheckBoxShowSecondary.Checked = FoundTemplate.ShowSecondary
                ReportOptions_CheckBoxShowRatings.Checked = FoundTemplate.ShowRatings
                ReportOptions_CheckBoxShowComments.Checked = FoundTemplate.ShowComments
                ReportOptions_CheckBoxShowSpotCosts.Checked = FoundTemplate.ShowSpotCosts
                ReportOptions_CheckBoxShowImpressions.Checked = FoundTemplate.ShowImpressions
                ReportOptions_CheckBoxShowBookends.Checked = FoundTemplate.ShowBookends
                ReportOptions_CheckBoxShowTotalCosts.Checked = FoundTemplate.ShowTotalCosts
                ReportOptions_CheckBoxShowCPPM.Checked = FoundTemplate.ShowCPPM
                ReportOptions_CheckBoxShowAddedValue.Checked = FoundTemplate.ShowAddedValue
                ReportOptions_CheckBoxShowRF.Checked = FoundTemplate.ShowRF

                If (ReportOptions_ComboBoxLocation.Items.IndexOf(FoundTemplate.Location) > -1) Then
                    ReportOptions_ComboBoxLocation.SelectedIndex = ReportOptions_ComboBoxLocation.Items.IndexOf(FoundTemplate.Location)
                End If

                If (ReportOptions_ComboBoxFrom.Items.IndexOf(FoundTemplate.DateFrom) > -1) Then
                    ReportOptions_ComboBoxFrom.SelectedIndex = ReportOptions_ComboBoxFrom.Items.IndexOf(FoundTemplate.DateFrom)
                End If

                If (ReportOptions_ComboBoxTo.Items.IndexOf(FoundTemplate.DateTo) > -1) Then
                    ReportOptions_ComboBoxTo.SelectedIndex = ReportOptions_ComboBoxTo.Items.IndexOf(FoundTemplate.DateTo)
                End If

                Dim ListMarkets As List(Of String) = Nothing
                Dim ListVendors As List(Of String) = Nothing

                ListMarkets = FoundTemplate.MarketList

                If (ListMarkets IsNot Nothing) Then

                    ReportOptions_ListBoxMarkets.SelectedItems.Clear()

                    For Each Market In ListMarkets
                        Dim MarketIndex As Integer = ReportOptions_ListBoxMarkets.Items.IndexOf(Market)
                        ReportOptions_ListBoxMarkets.SetSelected(MarketIndex, True)
                    Next

                End If

                ListVendors = FoundTemplate.VendorList

                If (ListVendors IsNot Nothing) Then

                    ReportOptions_ListBoxVendor.SelectedItems.Clear()

                    For Each Vendor In ListVendors
                        Dim VendorIndex As Integer = ReportOptions_ListBoxVendor.Items.IndexOf(Vendor)
                        ReportOptions_ListBoxVendor.SetSelected(VendorIndex, True)
                    Next

                End If

                _TemplateID = _BroadcastTemplates.Where(Function(x) x.TemplateName = Templates_ListboxTemplates.SelectedItem).Select(Function(x) x.TemplateID).First

                'Templates_TextBoxSaveTemplateName.Text = FoundTemplate.TemplateName
            End If

        End Sub

        Private Sub BtnSaveOK_Click(sender As Object, e As EventArgs) Handles Templates_ButtonSaveOK.Click
            'Read controls and save template

            Dim ListMarkets As List(Of String) = Nothing
            Dim ListVendors As List(Of String) = Nothing

            ListMarkets = New List(Of String)
            ListVendors = New List(Of String)

            For Each Item In ReportOptions_ListBoxMarkets.SelectedItems
                ListMarkets.Add(Item.ToString)
            Next

            For Each Item In ReportOptions_ListBoxVendor.SelectedItems
                ListVendors.Add(Item.ToString)
            Next

            Dim MatchingItems = _BroadcastTemplates.Where(Function(x) x.TemplateID = _TemplateID).Select(Function(x) x.TemplateName)

            If (MatchingItems.Any) Then
                If Not (Templates_TextBoxSaveTemplateName.Text.Trim = MatchingItems.FirstOrDefault()) Then
                    _TemplateID = -1
                End If
            Else
                _TemplateID = -1
            End If



            If (Not String.IsNullOrEmpty(Templates_TextBoxSaveTemplateName.Text)) Then
                Dim ScreenControls As New Reporting.Presentation.Classes.BroadcastTemplate With {
                .TemplateID = _TemplateID,
                .WorksheetID = _MediaBroadcastWorksheetID,
                .TemplateName = Templates_TextBoxSaveTemplateName.Text,
                .RunDetail = ReportOptions_CheckBoxScheduleDetail.Checked,
                .RunMarket = ReportOptions_CheckBoxScheduleMarket.Checked,
                .RunStation = ReportOptions_CheckBoxScheduleStation.Checked,
                .RunWeeklyDaily = ReportOptions_CheckBoxScheduleWDSummary.Checked,
                .Location = ReportOptions_ComboBoxLocation.Text,
                .ShowSecondary = ReportOptions_CheckBoxShowSecondary.Checked,
                .ShowRatings = ReportOptions_CheckBoxShowRatings.Checked,
                .ShowComments = ReportOptions_CheckBoxShowComments.Checked,
                .ShowSpotCosts = ReportOptions_CheckBoxShowSpotCosts.Checked,
                .ShowImpressions = ReportOptions_CheckBoxShowImpressions.Checked,
                .ShowBookends = ReportOptions_CheckBoxShowBookends.Checked,
                .ShowTotalCosts = ReportOptions_CheckBoxShowTotalCosts.Checked,
                .ShowCPPM = ReportOptions_CheckBoxShowCPPM.Checked,
                .ShowAddedValue = ReportOptions_CheckBoxShowAddedValue.Checked,
                .ShowRF = ReportOptions_CheckBoxShowRF.Checked,
                .DateFrom = ReportOptions_ComboBoxFrom.Text,
                .DateTo = ReportOptions_ComboBoxTo.Text,
                .Markets = String.Join("|", ListMarkets.ToArray),
                .Vendors = String.Join("|", ListVendors.ToArray),
                .MarketList = ListMarkets,
                .VendorList = ListVendors
            }

                Dim SqlInsert As String = "EXEC dbo.proc_MEDIA_BROADCAST_SCHEDULE_TEMPLATEInsert"
                Dim SqlUpdate As String = "EXEC dbo.proc_MEDIA_BROADCAST_SCHEDULE_TEMPLATEUpdate"
                Dim Params As String = "@WorkSheetID ,@TemplateName	,@RunDetail ,@RunMarket ,@RunStation ,@RunWeeklyDaily ,@Location "

                Params += " ,@ShowSecondary, @ShowRatings, @ShowComments, @ShowSpotCosts, @ShowImpressions, @ShowBookends, @ShowTotalCosts, @ShowCPPM, @ShowAddedValue, @ShowRF"

                Params += " ,@DateFrom ,@DateTo	,@Markets ,@Vendors"

                Dim Sql As String

                Dim SqlTemplateID As New SqlClient.SqlParameter("@TemplateID", SqlDbType.Int) With {
                    .Value = ScreenControls.TemplateID
                }

                Dim SqlWorksheetID As New SqlClient.SqlParameter("@WorkSheetID", SqlDbType.Int) With {
                    .Value = ScreenControls.WorksheetID
                }

                Dim SqlTemplateName As New SqlClient.SqlParameter("@TemplateName", SqlDbType.VarChar) With {
                    .Value = ScreenControls.TemplateName
                }

                Dim SqlRunDetail As New SqlClient.SqlParameter("@RunDetail", SqlDbType.Bit) With {
                    .Value = ScreenControls.RunDetail
                }

                Dim SqlRunMarket As New SqlClient.SqlParameter("@RunMarket", SqlDbType.Bit) With {
                    .Value = ScreenControls.RunMarket
                }

                Dim SqlRunStation As New SqlClient.SqlParameter("@RunStation", SqlDbType.Bit) With {
                    .Value = ScreenControls.RunStation
                }

                Dim SqlRunWeeklyDaily As New SqlClient.SqlParameter("@RunWeeklyDaily", SqlDbType.Bit) With {
                    .Value = ScreenControls.RunWeeklyDaily
                }


                Dim SqlLocation As New SqlClient.SqlParameter("@Location", SqlDbType.VarChar) With {
                    .Value = ScreenControls.Location
                }

                Dim SqlShowSecondary As New SqlClient.SqlParameter("@ShowSecondary", SqlDbType.Bit) With {
                    .Value = ScreenControls.ShowSecondary
                }

                '-----------------------
                Dim SqlShowRatings As New SqlClient.SqlParameter("@ShowRatings", SqlDbType.Bit) With {
                    .Value = ScreenControls.ShowRatings
                }

                Dim SqlShowComments As New SqlClient.SqlParameter("@ShowComments", SqlDbType.Bit) With {
                    .Value = ScreenControls.ShowComments
                }

                Dim SqlShowSpotCosts As New SqlClient.SqlParameter("@ShowSpotCosts", SqlDbType.Bit) With {
                    .Value = ScreenControls.ShowSpotCosts
                }

                Dim SqlShowImpressions As New SqlClient.SqlParameter("@ShowImpressions", SqlDbType.Bit) With {
                    .Value = ScreenControls.ShowImpressions
                }

                Dim SqlShowBookends As New SqlClient.SqlParameter("@ShowBookends", SqlDbType.Bit) With {
                    .Value = ScreenControls.ShowBookends
                }

                Dim SqlShowTotalCosts As New SqlClient.SqlParameter("@ShowTotalCosts", SqlDbType.Bit) With {
                    .Value = ScreenControls.ShowTotalCosts
                }

                Dim SqlShowCPPM As New SqlClient.SqlParameter("@ShowCPPM", SqlDbType.Bit) With {
                    .Value = ScreenControls.ShowCPPM
                }

                Dim SqlShowAddedValue As New SqlClient.SqlParameter("@ShowAddedValue", SqlDbType.Bit) With {
                    .Value = ScreenControls.ShowAddedValue
                }

                Dim SqlShowRF As New SqlClient.SqlParameter("@ShowRF", SqlDbType.Bit) With {
                    .Value = ScreenControls.ShowRF
                }

                '--------------------------
                Dim SqlDateFrom As New SqlClient.SqlParameter("@DateFrom", SqlDbType.VarChar) With {
                    .Value = ScreenControls.DateFrom
                }

                Dim SqlDateTo As New SqlClient.SqlParameter("@DateTo", SqlDbType.VarChar) With {
                    .Value = ScreenControls.DateTo
                }

                Dim SqlMarkets As New SqlClient.SqlParameter("@Markets", SqlDbType.VarChar) With {
                    .Value = ScreenControls.Markets
                }

                Dim SqlVendors As New SqlClient.SqlParameter("@Vendors", SqlDbType.VarChar) With {
                    .Value = ScreenControls.Vendors
                }


                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)
                    If (_TemplateID = -1) Then 'Insert
                        Sql = SqlInsert + " " + Params
                        _BroadcastTemplates = DbContext.Database.SqlQuery(Of Reporting.Presentation.Classes.BroadcastTemplate)(Sql, SqlWorksheetID, SqlTemplateName _
                                                                                                , SqlRunDetail, SqlRunMarket, SqlRunStation, SqlRunWeeklyDaily, SqlLocation _
                                                                                                , SqlShowSecondary, SqlShowRatings, SqlShowComments, SqlShowSpotCosts, SqlShowImpressions, SqlShowBookends, SqlShowTotalCosts, SqlShowCPPM, SqlShowAddedValue, SqlShowRF _
                                                                                                , SqlDateFrom, SqlDateTo, SqlMarkets, SqlVendors).ToList
                    Else ' Update
                        If (_BroadcastTemplates.Where(Function(x) x.TemplateName = Templates_TextBoxSaveTemplateName.Text).Any) Then

                            If (AdvantageFramework.WinForm.MessageBox.Show("Template with that name Is already on file, would you like to replace it?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Update Template", Nothing, Windows.Forms.MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then

                                Sql = SqlUpdate + " @TemplateID, " + Params
                                _BroadcastTemplates = DbContext.Database.SqlQuery(Of Reporting.Presentation.Classes.BroadcastTemplate)(Sql, SqlTemplateID, SqlWorksheetID, SqlTemplateName _
                                                                                                        , SqlRunDetail, SqlRunMarket, SqlRunStation, SqlRunWeeklyDaily, SqlLocation _
                                                                                                        , SqlShowSecondary, SqlShowRatings, SqlShowComments, SqlShowSpotCosts, SqlShowImpressions, SqlShowBookends, SqlShowTotalCosts, SqlShowCPPM, SqlShowAddedValue, SqlShowRF _
                                                                                                        , SqlDateFrom, SqlDateTo, SqlMarkets, SqlVendors).ToList
                            End If

                        End If


                    End If

                End Using
            End If

            Templates_TextBoxSaveTemplateName.Text = String.Empty

            PopulateTemplateScreen(_MediaBroadcastWorksheetID)
        End Sub

        Private Sub Templates_TextBoxSaveTemplateName_TextChanged(sender As Object, e As EventArgs) Handles Templates_TextBoxSaveTemplateName.TextChanged
            Templates_ButtonSaveOK.Enabled = Not (String.IsNullOrEmpty(Templates_TextBoxSaveTemplateName.Text))

            If (Templates_ButtonSaveOK.Enabled) Then
                If (_BroadcastTemplates.Where(Function(x) x.TemplateName = Templates_TextBoxSaveTemplateName.Text).Any) Then
                    _TemplateID = _BroadcastTemplates.Where(Function(x) x.TemplateName = Templates_TextBoxSaveTemplateName.Text).First.TemplateID
                Else
                    _TemplateID = -1
                End If

            End If

        End Sub

#End Region


    End Class

End Namespace
