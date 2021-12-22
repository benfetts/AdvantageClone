Namespace MediaManager

    Public Class BroadcastOrderByWeekReport

#Region " Constants "

        Private Const _ConstNielsenRadioDisclaimer As String = "AUDIENCE ESTIMATES FOR NON-STANDARD DEMOS ARE DERIVED BY ADVANTAGE SOFTWARE BASED ON NIELSEN COPYRIGHTED AND PROPRIETARY RADIO AUDIENCE ESTIMATES AND ARE NOT ESTIMATES PRODUCED BY NIELSEN."

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _OrderNumber As Integer = Nothing
        Private _LineNumbers As Generic.List(Of Integer) = Nothing
        Private _MediaFrom As String = Nothing
        Private _EmployeeEmail As String = Nothing
        Private _AgencyList As Generic.List(Of AdvantageFramework.Database.Entities.Agency) = Nothing
        Private _PrintCardInfo As Boolean = False
        Private _BroadcastOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.BroadcastOrder) = Nothing
        Private _MediaOrderPrintSetting As AdvantageFramework.Database.Entities.MediaOrderPrintSetting = Nothing
        Private _NielsenCopyright As String = "Copyright © " & Now.Year.ToString & " The Nielsen Company"
        Private _IsRadioPPMMarket As Boolean = False
        Private _VendorTax As Decimal? = Nothing
        Private _NetCharge As Decimal? = Nothing
        Private _Discount As Decimal? = Nothing
        Private _Commission As Decimal? = Nothing
        Private _NetAmount As Decimal? = Nothing
        Private _RadioOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.RadioOrderDetail) = Nothing
        Private _TVOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetail) = Nothing
        Private _DetailRowCount As Integer = 0
        Private _Units As String = Nothing
        Private _BroadcastCals As Generic.List(Of BroadcastCal) = Nothing
        Private _NetChargeDescription As String = Nothing
        Private _DiscountDescription As String = Nothing
        Private _IsFirstPage As Boolean = True
        Private _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

#End Region

#Region " Properties "

        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property OrderNumber As Integer
            Set(value As Integer)
                _OrderNumber = value
            End Set
        End Property
        Public WriteOnly Property LineNumbers As Generic.List(Of Integer)
            Set(value As Generic.List(Of Integer))
                _LineNumbers = value
            End Set
        End Property
        Public WriteOnly Property MediaFrom As String
            Set(value As String)
                _MediaFrom = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Function MonthAbbrevToNumber(MonthAbbrev As String) As String

            'objects
            Dim Number As String = String.Empty

            Select Case MonthAbbrev

                Case "JAN"
                    Number = "01"

                Case "FEB"
                    Number = "02"

                Case "MAR"
                    Number = "03"

                Case "APR"
                    Number = "04"

                Case "MAY"
                    Number = "05"

                Case "JUN"
                    Number = "06"

                Case "JUL"
                    Number = "07"

                Case "AUG"
                    Number = "08"

                Case "SEP"
                    Number = "09"

                Case "OCT"
                    Number = "10"

                Case "NOV"
                    Number = "11"

                Case "DEC"
                    Number = "12"

            End Select

            MonthAbbrevToNumber = Number

        End Function
        Private Sub AddSpots(Spots As Short?, StartWeekIn As Date?, ByRef BroadcastOrderYearMonths As Generic.List(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderYearMonth), CostRate As Decimal?)

            'objects
            Dim BroadcastOrderYearMonth As AdvantageFramework.MediaManager.Classes.BroadcastOrderYearMonth = Nothing
            Dim BroadcastCal As BroadcastCal = Nothing
            Dim StartWeek As Date = Nothing

            If Spots.GetValueOrDefault(0) > 0 AndAlso StartWeekIn.HasValue Then

                BroadcastCal = _BroadcastCals.Where(Function(Entity) Entity.weekdate >= StartWeekIn.Value).OrderBy(Function(Entity) Entity.weekdate).FirstOrDefault

                If BroadcastCal IsNot Nothing Then

                    StartWeek = BroadcastCal.weekdate

                End If

                BroadcastOrderYearMonth = BroadcastOrderYearMonths.Where(Function(BOYM) BOYM.BroadcastYear = BroadcastCal.brd_year AndAlso BOYM.BroadcastMonthAbbrev = BroadcastCal.brd_month).SingleOrDefault

                If BroadcastOrderYearMonth IsNot Nothing Then

                    BroadcastOrderYearMonth.Spots += Spots.Value

                    If _Units <> "BM" AndAlso _Units <> "DB" Then

                        BroadcastOrderYearMonth.TotalNet += Spots.Value * CostRate.GetValueOrDefault(0)

                    End If

                Else

                    BroadcastOrderYearMonth = New AdvantageFramework.MediaManager.Classes.BroadcastOrderYearMonth With {
                        .Spots = Spots.Value,
                        .YearMonth = BroadcastCal.brd_year.ToString & MonthAbbrevToNumber(BroadcastCal.brd_month),
                        .MonthYear = BroadcastCal.brd_month & Space(1) & "'" & Mid(BroadcastCal.brd_year.ToString, 3, 2),
                        .BroadcastMonthAbbrev = BroadcastCal.brd_month,
                        .BroadcastYear = BroadcastCal.brd_year
                    }

                    If _Units <> "BM" AndAlso _Units <> "DB" Then

                        BroadcastOrderYearMonth.TotalNet = Spots.Value * CostRate.GetValueOrDefault(0)

                    End If

                    BroadcastOrderYearMonths.Add(BroadcastOrderYearMonth)

                End If

            End If

        End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub BroadcastOrderReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            Dim Buyer As String = Nothing
            Dim Names() As String = Nothing
            Dim FirstName As String = Nothing
            Dim LastName As String = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Buyer = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.Buyer.ToString)

            If Buyer IsNot Nothing Then

                Names = Buyer.Split(" ")

                If Names.Length = 2 Then

                    FirstName = Names(0)
                    LastName = Names(1)

                    Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Employee = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                    Where Entity.FirstName = FirstName AndAlso
                                          Entity.LastName = LastName
                                    Select Entity).FirstOrDefault

                    End Using

                    If Employee IsNot Nothing Then

                        _EmployeeEmail = Employee.Email

                    End If

                End If

            End If

        End Sub



        Private Function SundayOf(ByRef InsertDate As Date) As Date
            Dim SundayDate As Date

            Select Case InsertDate.DayOfWeek
                Case DayOfWeek.Sunday
                    SundayDate = InsertDate

                Case DayOfWeek.Monday
                    SundayDate = InsertDate.AddDays(-1)

                Case DayOfWeek.Tuesday
                    SundayDate = InsertDate.AddDays(-2)

                Case DayOfWeek.Wednesday
                    SundayDate = InsertDate.AddDays(-3)

                Case DayOfWeek.Thursday
                    SundayDate = InsertDate.AddDays(-4)

                Case DayOfWeek.Friday
                    SundayDate = InsertDate.AddDays(-5)

                Case DayOfWeek.Saturday
                    SundayDate = InsertDate.AddDays(-6)

            End Select


            Return SundayDate
        End Function

        Private Function MondayOf(ByRef InsertDate As Date) As Date

            Dim MondayDate As Date

            Select Case InsertDate.DayOfWeek
                Case DayOfWeek.Sunday
                    MondayDate = InsertDate.AddDays(1)

                Case DayOfWeek.Monday
                    MondayDate = InsertDate

                Case DayOfWeek.Tuesday
                    MondayDate = InsertDate.AddDays(-1)

                Case DayOfWeek.Wednesday
                    MondayDate = InsertDate.AddDays(-2)

                Case DayOfWeek.Thursday
                    MondayDate = InsertDate.AddDays(-3)

                Case DayOfWeek.Friday
                    MondayDate = InsertDate.AddDays(-4)

                Case DayOfWeek.Saturday
                    MondayDate = InsertDate.AddDays(-5)

            End Select


            Return MondayDate
        End Function

        Private Function SaturdayOf(ByRef InsertDate As Date) As Date
            Return MondayOf(InsertDate).AddDays(5)
        End Function

        Private Function NextSundayOf(ByRef InsertDate As Date) As Date
            Return MondayOf(InsertDate).AddDays(6)
        End Function

        Private Sub UpdateDay(ByRef InsertDate As Date, ByRef InsertSpots As Integer, InsertRate As Decimal, AirTime As String, NetworkID As String, Programming As String,
                              DaypartID As Nullable(Of Integer), Length As Integer, ByRef Week As MediaManager.Classes.WeekData)

            Select Case InsertDate.DayOfWeek
                Case DayOfWeek.Sunday
                    Week.SunDate = InsertDate
                    Week.SunSpots += InsertSpots
                    Week.SunRate += InsertRate
                Case DayOfWeek.Monday
                    Week.MonDate = InsertDate
                    Week.MonSpots += InsertSpots
                    Week.MonRate += InsertRate
                Case DayOfWeek.Tuesday
                    Week.TueDate = InsertDate
                    Week.TueSpots += InsertSpots
                    Week.TueRate += InsertRate
                Case DayOfWeek.Wednesday
                    Week.WedDate = InsertDate
                    Week.WedSpots += InsertSpots
                    Week.WedRate += InsertRate
                Case DayOfWeek.Thursday
                    Week.ThrDate = InsertDate
                    Week.ThrSpots += InsertSpots
                    Week.ThrRate += InsertRate
                Case DayOfWeek.Friday
                    Week.FriDate = InsertDate
                    Week.FriSpots += InsertSpots
                    Week.FriRate += InsertRate
                Case DayOfWeek.Saturday
                    Week.SatDate = InsertDate
                    Week.SatSpots += InsertSpots
                    Week.SatRate += InsertRate
            End Select

            Week.NetworkID = NetworkID
            Week.Programming = Programming
            Week.AirTime = AirTime
            Week.DaypartID = DaypartID
            Week.Length = Length

        End Sub

        Private Sub InsertOrderDetail(ByVal Media As String, ByVal InsertDate As Date, ByVal InsertSpots As Integer, ByVal InsertRate As Decimal,
                                      ByVal StartTime As String, ByVal EndTime As String, ByVal NetworkID As String, ByVal Programming As String,
                                      DaypartID As Nullable(Of Integer), Length As Integer,
                                      ByRef WeekList As Generic.List(Of MediaManager.Classes.WeekData))


            Dim StartHour As String = ""
            Dim StartAMPM As String = ""
            Dim EndHour As String = ""
            Dim EndAMPM As String = ""
            Dim AirTime As String = ""
            Dim WeekData As MediaManager.Classes.WeekData = Nothing

            If String.IsNullOrWhiteSpace(StartTime) = False AndAlso StartTime.Length > 5 Then

                StartHour = Integer.Parse(StartTime.Substring(0, 2))
                If StartTime.Substring(3, 2) <> "00" Then
                    StartHour = StartHour & (StartTime.Substring(3, 2))
                End If

                StartAMPM = IIf(StartTime.Contains("AM"), "a", "p")

            End If

            If String.IsNullOrWhiteSpace(EndTime) = False AndAlso EndTime.Length > 5 Then

                EndHour = Integer.Parse(EndTime.Substring(0, 2))
                If EndTime.Substring(3, 2) <> "00" Then
                    EndHour = EndHour & (EndTime.Substring(3, 2))
                End If

                EndAMPM = IIf(EndTime.Contains("AM"), "a", "p")

            End If

            AirTime = StartHour + StartAMPM + "-" + EndHour + EndAMPM

            If (WeekList Is Nothing) Then
                WeekList = New List(Of MediaManager.Classes.WeekData)

                Dim NewWeek As MediaManager.Classes.WeekData = New MediaManager.Classes.WeekData With {
                    .BeginWeekDate = MondayOf(InsertDate),
                    .EndWeekDate = NextSundayOf(InsertDate),
                    .Rate = InsertRate
                }

                UpdateDay(InsertDate, InsertSpots, InsertRate, AirTime, NetworkID, Programming, DaypartID, Length, NewWeek)
                WeekList.Add(NewWeek)

            ElseIf WeekList.Where(Function(x) x.BeginWeekDate <= InsertDate AndAlso x.EndWeekDate >= InsertDate AndAlso x.Rate = InsertRate AndAlso
                                              x.AirTime = AirTime AndAlso x.NetworkID = NetworkID AndAlso x.Programming = Programming AndAlso
                                              (x.DaypartID IsNot Nothing AndAlso x.DaypartID = DaypartID) AndAlso x.Length = Length).Count = 0 Then

                Dim NewWeek As MediaManager.Classes.WeekData = New MediaManager.Classes.WeekData With {
                    .BeginWeekDate = MondayOf(InsertDate),
                    .EndWeekDate = NextSundayOf(InsertDate),
                    .Rate = InsertRate
                }

                UpdateDay(InsertDate, InsertSpots, InsertRate, AirTime, NetworkID, Programming, DaypartID, Length, NewWeek)
                WeekList.Add(NewWeek)
            Else

                Try

                    WeekData = WeekList.FirstOrDefault(Function(x) x.BeginWeekDate <= InsertDate AndAlso x.EndWeekDate >= InsertDate AndAlso x.Rate = InsertRate AndAlso
                                                                   x.AirTime = AirTime AndAlso x.NetworkID = NetworkID AndAlso x.Programming = Programming AndAlso
                                                                   x.DaypartID = DaypartID AndAlso x.Length = Length)

                Catch ex As Exception
                    WeekData = Nothing
                End Try

                If WeekData IsNot Nothing Then

                    UpdateDay(InsertDate, InsertSpots, InsertRate, AirTime, NetworkID, Programming, DaypartID, Length, WeekData)

                End If

            End If

        End Sub

        Private Function ObjectDOW(RelativeDate As Date, Sun As Boolean?, Mon As Boolean?, Tue As Boolean?, Wed As Boolean?, Thr As Boolean?, Fri As Boolean?, Sat As Boolean?, IsDaily As Boolean) As Date

            If (IsDaily) Then
                ObjectDOW = RelativeDate
            Else
                Dim FoundDay As Integer
                Dim Adjust As Integer
                If (Sun.GetValueOrDefault(False)) Then
                    FoundDay = 0
                ElseIf (Mon.GetValueOrDefault(False)) Then
                    FoundDay = 1
                ElseIf (Tue.GetValueOrDefault(False)) Then
                    FoundDay = 2
                ElseIf (Wed.GetValueOrDefault(False)) Then
                    FoundDay = 3
                ElseIf (Thr.GetValueOrDefault(False)) Then
                    FoundDay = 4
                ElseIf (Fri.GetValueOrDefault(False)) Then
                    FoundDay = 5
                ElseIf (Sat.GetValueOrDefault(False)) Then
                    FoundDay = 6
                End If

                If (RelativeDate.DayOfWeek = DayOfWeek.Sunday) Then
                    Adjust = 0
                ElseIf (RelativeDate.DayOfWeek = DayOfWeek.Monday) Then
                    Adjust = 1
                ElseIf (RelativeDate.DayOfWeek = DayOfWeek.Tuesday) Then
                    Adjust = 2
                ElseIf (RelativeDate.DayOfWeek = DayOfWeek.Wednesday) Then
                    Adjust = 3
                ElseIf (RelativeDate.DayOfWeek = DayOfWeek.Thursday) Then
                    Adjust = 4
                ElseIf (RelativeDate.DayOfWeek = DayOfWeek.Friday) Then
                    Adjust = 5
                ElseIf (RelativeDate.DayOfWeek = DayOfWeek.Saturday) Then
                    Adjust = 6
                End If

                ObjectDOW = RelativeDate.AddDays(FoundDay - Adjust)
            End If

        End Function
        Private Sub BroadcastOrderReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim MediaBroadcastWorksheetMarketID As Integer = 0
            Dim NielsenRadioPeriodID As Nullable(Of Integer) = Nothing
            Dim NielsenRadioPeriod As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim OrderPrintSetting As AdvantageFramework.Media.Classes.OrderPrintSetting = Nothing
            Dim Dayparts As Generic.List(Of AdvantageFramework.Database.Entities.Daypart) = Nothing
            Dim Daypart As AdvantageFramework.Database.Entities.Daypart = Nothing

            Dim WeeksOnReport As Generic.List(Of MediaManager.Classes.WeekData) = Nothing

            _AgencyList = New Generic.List(Of AdvantageFramework.Database.Entities.Agency)

            If _LineNumbers IsNot Nothing AndAlso _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _BroadcastOrders = AdvantageFramework.MediaManager.LoadBroadcastOrder(DbContext, _OrderNumber, String.Join(",", _LineNumbers), _MediaFrom).ToList

                    _AgencyList.Add(AdvantageFramework.Database.Procedures.Agency.Load(DbContext))
                    Dayparts = AdvantageFramework.Database.Procedures.Daypart.Load(DbContext).ToList

                    _PrintCardInfo = DbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(AGY_SETTINGS_VALUE as bit) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'VCC_INCLUDE_CARDINFO'").FirstOrDefault

                    _MediaOrderPrintSetting = AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.LoadByUserCodeAndMediaType(DbContext, _Session.UserCode, Mid(_MediaFrom, 1, 1).ToUpper)

                    If _MediaOrderPrintSetting Is Nothing Then

                        OrderPrintSetting = New AdvantageFramework.Media.Classes.OrderPrintSetting(Mid(_MediaFrom, 1, 1).ToUpper)

                        _MediaOrderPrintSetting = New AdvantageFramework.Database.Entities.MediaOrderPrintSetting

                        _MediaOrderPrintSetting.UserCode = _Session.UserCode.ToUpper
                        _MediaOrderPrintSetting.MediaType = Mid(_MediaFrom, 1, 1).ToUpper

                        OrderPrintSetting.Save(_MediaOrderPrintSetting)

                        AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.Insert(DbContext, _MediaOrderPrintSetting, Nothing)

                    End If

                    If String.IsNullOrWhiteSpace(_MediaOrderPrintSetting.LocationID) = False Then

                        _LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _MediaOrderPrintSetting.LocationID, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)

                    Else

                        _LocationLogo = Nothing

                    End If

                    If Mid(_MediaFrom, 1, 1).ToUpper = "R" Then

                        RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, _OrderNumber)

                        If RadioOrder IsNot Nothing Then

                            _Units = RadioOrder.Units

                        End If

                    ElseIf Mid(_MediaFrom, 1, 1).ToUpper = "T" Then

                        TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, _OrderNumber)

                        If TVOrder IsNot Nothing Then

                            _Units = TVOrder.Units

                        End If

                    End If

                    _BroadcastCals = DbContext.Database.SqlQuery(Of BroadcastCal)("SELECT * FROM dbo.fn_BroadcastCal()").ToList

                    If Mid(_MediaFrom, 1, 1).ToUpper = "R" AndAlso _MediaOrderPrintSetting.PrimaryRatings.GetValueOrDefault(False) AndAlso
                            (From Entity In AdvantageFramework.Database.Procedures.RadioOrderDetail.Load(DbContext)
                             Where Entity.RadioOrderNumber = _OrderNumber AndAlso
                                   Entity.LinkLineNumber IsNot Nothing).Any AndAlso _Session.IsNielsenSetup Then

                        NielsenRadioPeriodID = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetail").Include("MediaBroadcastWorksheetMarket")
                                                Where Entity.OrderNumber = _OrderNumber
                                                Select Entity.MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID1).FirstOrDefault

                        If NielsenRadioPeriodID.HasValue Then

                            Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(_Session.NielsenConnectionString, Nothing)

                                NielsenRadioPeriod = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByID(NielsenDbContext, NielsenRadioPeriodID.Value)

                                If NielsenRadioPeriod IsNot Nothing AndAlso (NielsenRadioPeriod.NielsenRadioReportTypeCode = "5" OrElse
                                                                             NielsenRadioPeriod.NielsenRadioReportTypeCode = "7" OrElse
                                                                             NielsenRadioPeriod.NielsenRadioReportTypeCode = "8") Then

                                    _IsRadioPPMMarket = True

                                End If

                            End Using

                        End If

                    End If

                    If Mid(_MediaFrom, 1, 1).ToUpper = "R" Then

                        _RadioOrderDetails = (From ROD In AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumber(DbContext, _OrderNumber)
                                              Where _LineNumbers.Contains(ROD.LineNumber) AndAlso
                                                   (ROD.IsLineCancelled Is Nothing OrElse ROD.IsLineCancelled = 0) AndAlso
                                                   (ROD.CostRate > 0 OrElse ROD.TotalSpots > 0)
                                              Select ROD).ToList

                        _VendorTax = _RadioOrderDetails.Sum(Function(D) D.NonResaleAmount)
                        _NetCharge = _RadioOrderDetails.Sum(Function(D) D.NetCharge)
                        _Discount = _RadioOrderDetails.Sum(Function(D) D.DiscountAmount)
                        _Commission = _RadioOrderDetails.Sum(Function(D) D.CommissionAmount) * -1

                        If _RadioOrderDetails IsNot Nothing AndAlso _RadioOrderDetails.Count > 0 Then

                            _NetChargeDescription = _RadioOrderDetails.OrderByDescending(Function(D) D.NetChargeDescription).First.NetChargeDescription

                            If String.IsNullOrWhiteSpace(_NetChargeDescription) Then

                                _NetChargeDescription = "Net Charge"

                            End If

                            _DiscountDescription = _RadioOrderDetails.OrderByDescending(Function(D) D.DiscountDescription).First.DiscountDescription

                            If String.IsNullOrWhiteSpace(_DiscountDescription) Then

                                _DiscountDescription = "Discount"

                            End If

                        End If

                        If Not AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumber(DbContext, _OrderNumber).ToList.Where(Function(Entity) Entity.IsLineCancelled.GetValueOrDefault(0) = 0).Any Then

                            Me.Watermark.Text = "CANCELLED"

                        End If

                        Dim IsDaily As Boolean = False

                        For Each OrderDetail In _RadioOrderDetails

                            IsDaily = (OrderDetail.StartDate = OrderDetail.EndDate)

                            If (OrderDetail.Spots1 > 0) Then
                                InsertOrderDetail("R", ObjectDOW(OrderDetail.Date1, OrderDetail.Sunday, OrderDetail.Monday, OrderDetail.Tuesday, OrderDetail.Wednesday, OrderDetail.Thursday, OrderDetail.Friday, OrderDetail.Saturday, IsDaily),
                                                  OrderDetail.Spots1, OrderDetail.Rate, OrderDetail.StartTime, OrderDetail.EndTime, OrderDetail.NetworkID, OrderDetail.Programming, OrderDetail.DaypartID, OrderDetail.Length.GetValueOrDefault(0), WeeksOnReport)
                            End If

                            If (OrderDetail.Spots2 > 0) Then
                                InsertOrderDetail("R", ObjectDOW(OrderDetail.Date2, OrderDetail.Sunday, OrderDetail.Monday, OrderDetail.Tuesday, OrderDetail.Wednesday, OrderDetail.Thursday, OrderDetail.Friday, OrderDetail.Saturday, IsDaily) _
                                                  , OrderDetail.Spots2, OrderDetail.Rate, OrderDetail.StartTime, OrderDetail.EndTime, OrderDetail.NetworkID, OrderDetail.Programming, OrderDetail.DaypartID, OrderDetail.Length.GetValueOrDefault(0), WeeksOnReport)
                            End If

                            If (OrderDetail.Spots3 > 0) Then
                                InsertOrderDetail("R", ObjectDOW(OrderDetail.Date3, OrderDetail.Sunday, OrderDetail.Monday, OrderDetail.Tuesday, OrderDetail.Wednesday, OrderDetail.Thursday, OrderDetail.Friday, OrderDetail.Saturday, IsDaily) _
                                                  , OrderDetail.Spots3, OrderDetail.Rate, OrderDetail.StartTime, OrderDetail.EndTime, OrderDetail.NetworkID, OrderDetail.Programming, OrderDetail.DaypartID, OrderDetail.Length.GetValueOrDefault(0), WeeksOnReport)
                            End If

                            If (OrderDetail.Spots4 > 0) Then
                                InsertOrderDetail("R", ObjectDOW(OrderDetail.Date4, OrderDetail.Sunday, OrderDetail.Monday, OrderDetail.Tuesday, OrderDetail.Wednesday, OrderDetail.Thursday, OrderDetail.Friday, OrderDetail.Saturday, IsDaily) _
                                                  , OrderDetail.Spots4, OrderDetail.Rate, OrderDetail.StartTime, OrderDetail.EndTime, OrderDetail.NetworkID, OrderDetail.Programming, OrderDetail.DaypartID, OrderDetail.Length.GetValueOrDefault(0), WeeksOnReport)
                            End If

                            If (OrderDetail.Spots5 > 0) Then
                                InsertOrderDetail("R", ObjectDOW(OrderDetail.Date5, OrderDetail.Sunday, OrderDetail.Monday, OrderDetail.Tuesday, OrderDetail.Wednesday, OrderDetail.Thursday, OrderDetail.Friday, OrderDetail.Saturday, IsDaily) _
                                                  , OrderDetail.Spots5, OrderDetail.Rate, OrderDetail.StartTime, OrderDetail.EndTime, OrderDetail.NetworkID, OrderDetail.Programming, OrderDetail.DaypartID, OrderDetail.Length.GetValueOrDefault(0), WeeksOnReport)
                            End If

                            If (OrderDetail.Spots6 > 0) Then
                                InsertOrderDetail("R", ObjectDOW(OrderDetail.Date6, OrderDetail.Sunday, OrderDetail.Monday, OrderDetail.Tuesday, OrderDetail.Wednesday, OrderDetail.Thursday, OrderDetail.Friday, OrderDetail.Saturday, IsDaily) _
                                                  , OrderDetail.Spots6, OrderDetail.Rate, OrderDetail.StartTime, OrderDetail.EndTime, OrderDetail.NetworkID, OrderDetail.Programming, OrderDetail.DaypartID, OrderDetail.Length.GetValueOrDefault(0), WeeksOnReport)
                            End If

                            If (OrderDetail.Spots7 > 0) Then
                                InsertOrderDetail("R", ObjectDOW(OrderDetail.Date7, OrderDetail.Sunday, OrderDetail.Monday, OrderDetail.Tuesday, OrderDetail.Wednesday, OrderDetail.Thursday, OrderDetail.Friday, OrderDetail.Saturday, IsDaily) _
                                                  , OrderDetail.Spots7, OrderDetail.Rate, OrderDetail.StartTime, OrderDetail.EndTime, OrderDetail.NetworkID, OrderDetail.Programming, OrderDetail.DaypartID, OrderDetail.Length.GetValueOrDefault(0), WeeksOnReport)
                            End If

                        Next

                    ElseIf Mid(_MediaFrom, 1, 1).ToUpper = "T" Then

                        _TVOrderDetails = (From TOD In AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, _OrderNumber)
                                           Where _LineNumbers.Contains(TOD.LineNumber) AndAlso
                                                 (TOD.IsLineCancelled Is Nothing OrElse TOD.IsLineCancelled = 0) AndAlso
                                                 (TOD.CostRate > 0 OrElse TOD.TotalSpots > 0)
                                           Select TOD).ToList

                        _VendorTax = _TVOrderDetails.Sum(Function(D) D.NonResaleAmount)
                        _NetCharge = _TVOrderDetails.Sum(Function(D) D.NetCharges)
                        _Discount = _TVOrderDetails.Sum(Function(D) D.DiscountAmount)
                        _Commission = _TVOrderDetails.Sum(Function(D) D.CommissionAmount) * -1

                        If _TVOrderDetails IsNot Nothing AndAlso _TVOrderDetails.Count > 0 Then

                            _NetChargeDescription = _TVOrderDetails.OrderByDescending(Function(D) D.NetChargesDescription).First.NetChargesDescription

                            If String.IsNullOrWhiteSpace(_NetChargeDescription) Then

                                _NetChargeDescription = "Net Charge"

                            End If

                            _DiscountDescription = _TVOrderDetails.OrderByDescending(Function(D) D.DiscountDescription).First.DiscountDescription

                            If String.IsNullOrWhiteSpace(_DiscountDescription) Then

                                _DiscountDescription = "Discount"

                            End If

                        End If

                        If Not AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, _OrderNumber).ToList.Where(Function(Entity) Entity.IsLineCancelled.GetValueOrDefault(0) = 0).Any Then

                            Me.Watermark.Text = "CANCELLED"

                        End If

                        Dim IsDaily As Boolean = False

                        For Each OrderDetail In _TVOrderDetails

                            IsDaily = (OrderDetail.StartDate = OrderDetail.EndDate)

                            If (OrderDetail.Spots1 > 0) Then
                                InsertOrderDetail("TV", ObjectDOW(OrderDetail.Date1, OrderDetail.Sunday, OrderDetail.Monday, OrderDetail.Tuesday, OrderDetail.Wednesday, OrderDetail.Thursday, OrderDetail.Friday, OrderDetail.Saturday, IsDaily) _
                                                  , OrderDetail.Spots1, OrderDetail.Rate, OrderDetail.StartTime, OrderDetail.EndTime, OrderDetail.NetworkID, OrderDetail.Programming, OrderDetail.DaypartID, OrderDetail.Length.GetValueOrDefault(0), WeeksOnReport)
                            End If

                            If (OrderDetail.Spots2 > 0) Then
                                InsertOrderDetail("TV", ObjectDOW(OrderDetail.Date2, OrderDetail.Sunday, OrderDetail.Monday, OrderDetail.Tuesday, OrderDetail.Wednesday, OrderDetail.Thursday, OrderDetail.Friday, OrderDetail.Saturday, IsDaily) _
                                                  , OrderDetail.Spots2, OrderDetail.Rate, OrderDetail.StartTime, OrderDetail.EndTime, OrderDetail.NetworkID, OrderDetail.Programming, OrderDetail.DaypartID, OrderDetail.Length.GetValueOrDefault(0), WeeksOnReport)
                            End If

                            If (OrderDetail.Spots3 > 0) Then
                                InsertOrderDetail("TV", ObjectDOW(OrderDetail.Date3, OrderDetail.Sunday, OrderDetail.Monday, OrderDetail.Tuesday, OrderDetail.Wednesday, OrderDetail.Thursday, OrderDetail.Friday, OrderDetail.Saturday, IsDaily) _
                                                  , OrderDetail.Spots3, OrderDetail.Rate, OrderDetail.StartTime, OrderDetail.EndTime, OrderDetail.NetworkID, OrderDetail.Programming, OrderDetail.DaypartID, OrderDetail.Length.GetValueOrDefault(0), WeeksOnReport)
                            End If

                            If (OrderDetail.Spots4 > 0) Then
                                InsertOrderDetail("TV", ObjectDOW(OrderDetail.Date4, OrderDetail.Sunday, OrderDetail.Monday, OrderDetail.Tuesday, OrderDetail.Wednesday, OrderDetail.Thursday, OrderDetail.Friday, OrderDetail.Saturday, IsDaily) _
                                                  , OrderDetail.Spots4, OrderDetail.Rate, OrderDetail.StartTime, OrderDetail.EndTime, OrderDetail.NetworkID, OrderDetail.Programming, OrderDetail.DaypartID, OrderDetail.Length.GetValueOrDefault(0), WeeksOnReport)
                            End If

                            If (OrderDetail.Spots5 > 0) Then
                                InsertOrderDetail("TV", ObjectDOW(OrderDetail.Date5, OrderDetail.Sunday, OrderDetail.Monday, OrderDetail.Tuesday, OrderDetail.Wednesday, OrderDetail.Thursday, OrderDetail.Friday, OrderDetail.Saturday, IsDaily) _
                                                  , OrderDetail.Spots5, OrderDetail.Rate, OrderDetail.StartTime, OrderDetail.EndTime, OrderDetail.NetworkID, OrderDetail.Programming, OrderDetail.DaypartID, OrderDetail.Length.GetValueOrDefault(0), WeeksOnReport)
                            End If

                            If (OrderDetail.Spots6 > 0) Then
                                InsertOrderDetail("TV", ObjectDOW(OrderDetail.Date6, OrderDetail.Sunday, OrderDetail.Monday, OrderDetail.Tuesday, OrderDetail.Wednesday, OrderDetail.Thursday, OrderDetail.Friday, OrderDetail.Saturday, IsDaily) _
                                                  , OrderDetail.Spots6, OrderDetail.Rate, OrderDetail.StartTime, OrderDetail.EndTime, OrderDetail.NetworkID, OrderDetail.Programming, OrderDetail.DaypartID, OrderDetail.Length.GetValueOrDefault(0), WeeksOnReport)
                            End If

                            If (OrderDetail.Spots7 > 0) Then
                                InsertOrderDetail("TV", ObjectDOW(OrderDetail.Date7, OrderDetail.Sunday, OrderDetail.Monday, OrderDetail.Tuesday, OrderDetail.Wednesday, OrderDetail.Thursday, OrderDetail.Friday, OrderDetail.Saturday, IsDaily) _
                                                  , OrderDetail.Spots7, OrderDetail.Rate, OrderDetail.StartTime, OrderDetail.EndTime, OrderDetail.NetworkID, OrderDetail.Programming, OrderDetail.DaypartID, OrderDetail.Length.GetValueOrDefault(0), WeeksOnReport)
                            End If

                        Next

                    End If

                End Using

            Else

                _BroadcastOrders = New Generic.List(Of AdvantageFramework.MediaManager.Classes.BroadcastOrder)

            End If

            Dim _BroadcastOrdersXWeeks As Generic.List(Of AdvantageFramework.MediaManager.Classes.BroadcastOrder) = Nothing

            For Each BroadcastOrder In _BroadcastOrders

                If String.IsNullOrEmpty(BroadcastOrder.LocationHeader) = False Then

                    BroadcastOrder.LocationHeader = BroadcastOrder.LocationHeader.Trim

                End If

                If String.IsNullOrEmpty(BroadcastOrder.LocationFooter) = False Then

                    BroadcastOrder.LocationFooter = BroadcastOrder.LocationFooter.Trim

                End If

                _BroadcastOrdersXWeeks = New List(Of AdvantageFramework.MediaManager.Classes.BroadcastOrder)

                For Each Week In WeeksOnReport
                    Dim CrossOrder As New AdvantageFramework.MediaManager.Classes.BroadcastOrder
                    'CrossOrder = BroadcastOrder

                    CopyPropertiesByName(CrossOrder, BroadcastOrder)

                    CrossOrder.StartWeek = Week.MonDate
                    CrossOrder.SpotsWeek1 = Week.MonSpots

                    CrossOrder.StartWeek2 = Week.TueDate
                    CrossOrder.SpotsWeek2 = Week.TueSpots

                    CrossOrder.StartWeek3 = Week.WedDate
                    CrossOrder.SpotsWeek3 = Week.WedSpots

                    CrossOrder.StartWeek4 = Week.ThrDate
                    CrossOrder.SpotsWeek4 = Week.ThrSpots

                    CrossOrder.StartWeek5 = Week.FriDate
                    CrossOrder.SpotsWeek5 = Week.FriSpots

                    CrossOrder.StartWeek6 = Week.SatDate
                    CrossOrder.SpotsWeek6 = Week.SatSpots

                    CrossOrder.StartWeek7 = Week.SunDate
                    CrossOrder.SpotsWeek7 = Week.SunSpots

                    CrossOrder.TotalSpots = Week.SunSpots + Week.MonSpots + Week.TueSpots + Week.WedSpots + Week.ThrSpots + Week.FriSpots + Week.SatSpots

                    'CrossOrder.Amount = (Week.SunSpots * Week.SunRate) + (Week.MonSpots * Week.MonRate) + (Week.TueSpots * Week.TueRate) _
                    '    + (Week.WedSpots * Week.WedRate) + (Week.ThrSpots * Week.ThrRate) + (Week.FriSpots * Week.FriRate) + (Week.SatSpots * Week.SatRate)

                    CrossOrder.Amount = CrossOrder.TotalSpots * Week.Rate

                    CrossOrder.CableNetwork = Week.NetworkID
                    CrossOrder.Programming = Week.Programming
                    CrossOrder.AirTime = Week.AirTime
                    CrossOrder.CostRate = Week.Rate
                    CrossOrder.Length = Week.Length

                    If Week.DaypartID.GetValueOrDefault(0) > 0 Then

                        Try

                            Daypart = Dayparts.SingleOrDefault(Function(Entity) Entity.ID = Week.DaypartID)

                        Catch ex As Exception
                            Daypart = Nothing
                        End Try

                        If Daypart IsNot Nothing Then

                            CrossOrder.Daypart = Daypart.Code

                        End If

                    End If

                    FillDates(CrossOrder.StartWeek, CrossOrder.StartWeek2, CrossOrder.StartWeek3, CrossOrder.StartWeek4, CrossOrder.StartWeek5, CrossOrder.StartWeek6, CrossOrder.StartWeek7)

                    _BroadcastOrdersXWeeks.Add(CrossOrder)
                Next
            Next

            _BroadcastOrdersXWeeks = _BroadcastOrdersXWeeks _
                .OrderBy(Function(x) x.OrderNumber) _
                .ThenBy(Function(x) x.StartWeek) _
                .ThenBy(Function(x) x.CableNetwork) _
                .ThenBy(Function(x) x.Programming) _
                .ThenBy(Function(x) x.AirTime) _
                .ThenBy(Function(x) x.CostRate).ToList

            Me.DataSource = _BroadcastOrdersXWeeks

        End Sub

        Private Sub FillDates(ByRef Date1 As Nullable(Of Date), ByRef Date2 As Nullable(Of Date), ByRef Date3 As Nullable(Of Date), ByRef Date4 As Nullable(Of Date), ByRef Date5 As Nullable(Of Date), ByRef Date6 As Nullable(Of Date), ByRef Date7 As Nullable(Of Date))

            Dim VirtMonday As Date

            If (Date1.HasValue) Then
                VirtMonday = Date1
            ElseIf (Date2.HasValue) Then
                VirtMonday = Date2.Value.AddDays(-1)
            ElseIf (Date3.HasValue) Then
                VirtMonday = Date3.Value.AddDays(-2)
            ElseIf (Date4.HasValue) Then
                VirtMonday = Date4.Value.AddDays(-3)
            ElseIf (Date5.HasValue) Then
                VirtMonday = Date5.Value.AddDays(-4)
            ElseIf (Date6.HasValue) Then
                VirtMonday = Date6.Value.AddDays(-5)
            ElseIf (Date7.HasValue) Then
                VirtMonday = Date7.Value.AddDays(-6)
            End If


            Date1 = VirtMonday
            Date2 = VirtMonday.AddDays(1)
            Date3 = VirtMonday.AddDays(2)
            Date4 = VirtMonday.AddDays(3)
            Date5 = VirtMonday.AddDays(4)
            Date6 = VirtMonday.AddDays(5)
            Date7 = VirtMonday.AddDays(6)

        End Sub
#End Region

#Region "  Control Event Handlers "

        Private Sub GroupHeaderCycle_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderCycle.BeforePrint

            LabelGroupHeaderCycle_NetGross.Text = If(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 1, "Gross", "Net")

        End Sub
        Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

            Dim Cancel As Boolean = True

            If _IsFirstPage AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.PageHeaderLogoPath.ToString) IsNot Nothing Then

                If String.IsNullOrWhiteSpace(_MediaOrderPrintSetting.LocationID) = False Then

                    If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.PageHeaderLogoPath.ToString)) = False Then

                        If My.Computer.FileSystem.FileExists(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.PageHeaderLogoPath.ToString)) Then

                            XrPictureBoxHeaderLogo.ImageUrl = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.PageHeaderLogoPath.ToString)

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
        Private Sub GroupFooterOrderNumberSubreport_VendorShippingSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterOrderNumberSubreport_VendorShippingSubReport.BeforePrint

            Dim VendorCode As String = Nothing
            Dim Vendors As IEnumerable(Of AdvantageFramework.Database.Entities.Vendor) = Nothing

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.ShowShippingAddress.ToString) = 1 Then

                VendorCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.VendorCode.ToString)

                Try

                    Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Vendors = (From Vendor In AdvantageFramework.Database.Procedures.Vendor.Load(DbContext)
                                   Where Vendor.Code = VendorCode
                                   Select Vendor).ToList

                    End Using

                Catch ex As Exception
                    Vendors = Nothing
                End Try

                If Vendors IsNot Nothing AndAlso Vendors.Count > 0 AndAlso (
                        String.IsNullOrWhiteSpace(Vendors(0).ShipToName) = False OrElse String.IsNullOrWhiteSpace(Vendors(0).ShipToAddress) = False OrElse
                        String.IsNullOrWhiteSpace(Vendors(0).ShipToAddress2) = False OrElse String.IsNullOrWhiteSpace(Vendors(0).ShipToAddress3) = False OrElse
                        String.IsNullOrWhiteSpace(Vendors(0).ShipToCity) = False OrElse String.IsNullOrWhiteSpace(Vendors(0).ShipToState) = False OrElse
                        String.IsNullOrWhiteSpace(Vendors(0).ShipToZip) = False OrElse String.IsNullOrWhiteSpace(Vendors(0).ShipToCounty) = False OrElse
                        String.IsNullOrWhiteSpace(Vendors(0).ShipToCountry) = False) Then

                    GroupFooterOrderNumberSubreport_VendorShippingSubReport.ReportSource.DataSource = Vendors

                Else

                    e.Cancel = True

                End If

            Else

                e.Cancel = True

            End If

            If e.Cancel Then

                LabelGroupFooterOrderNumber_ShipToLabel.Visible = False

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_SalesTax_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_SalesTax.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            Else

                If _VendorTax IsNot Nothing AndAlso _VendorTax <> 0 Then

                    LabelGroupFooterOrderNumber_SalesTax.Text = FormatNumber(_VendorTax, 2)

                Else

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_SalesTaxLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_SalesTaxLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            Else

                If _VendorTax IsNot Nothing AndAlso _VendorTax <> 0 Then

                    LabelGroupFooterOrderNumber_SalesTaxLabel.Text = "Sales Tax:"

                End If

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_NetCharge_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_NetCharge.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            Else

                If _NetCharge IsNot Nothing AndAlso _NetCharge <> 0 Then

                    LabelGroupFooterOrderNumber_NetCharge.Text = FormatNumber(_NetCharge, 2)

                Else

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_NetChargeLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_NetChargeLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            Else

                If _NetCharge IsNot Nothing AndAlso _NetCharge <> 0 Then

                    LabelGroupFooterOrderNumber_NetChargeLabel.Text = _NetChargeDescription & ":"

                End If

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_Discount_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_Discount.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            Else

                If _Discount IsNot Nothing AndAlso _Discount <> 0 Then

                    LabelGroupFooterOrderNumber_Discount.Text = FormatNumber(_Discount, 2)

                Else

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_DiscountLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_DiscountLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            Else

                If _Discount IsNot Nothing AndAlso _Discount <> 0 Then

                    LabelGroupFooterOrderNumber_DiscountLabel.Text = _DiscountDescription & ":"

                End If

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_AgencyCommission_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_AgencyCommission.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 0 Then

                _Commission = Nothing

            Else

                If _MediaOrderPrintSetting.AgencyCommission AndAlso _Commission IsNot Nothing AndAlso _Commission <> 0 Then

                    LabelGroupFooterOrderNumber_AgencyCommission.Text = FormatNumber(_Commission, 2)

                Else

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_AgencyCommissionLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_AgencyCommissionLabel.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 0 Then

                LabelGroupFooterOrderNumber_AgencyCommissionLabel.Text = Nothing

            Else

                If _MediaOrderPrintSetting.AgencyCommission AndAlso _Commission IsNot Nothing AndAlso _Commission <> 0 Then

                    LabelGroupFooterOrderNumber_AgencyCommissionLabel.Text = "Agency Commission:"

                End If

            End If

        End Sub
        Private Sub XrPictureBoxSignature_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxSignature.BeforePrint

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim BuyerEmployeeCode As String = Nothing
            Dim NameParts() As String = Nothing
            Dim FirstName As String = Nothing
            Dim LastName As String = Nothing

            If _MediaOrderPrintSetting.ExcludeEmployeeSignature.GetValueOrDefault(0) = 1 Then

                e.Cancel = True

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.BuyerEmployeeCode.ToString)) = False Then

                        BuyerEmployeeCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.BuyerEmployeeCode.ToString)

                        Employee = (From EMP In DbContext.Employees
                                    Where EMP.Code = BuyerEmployeeCode AndAlso
                                          EMP.TerminationDate Is Nothing AndAlso
                                          EMP.SignatureImage IsNot Nothing
                                    Select EMP).FirstOrDefault

                    ElseIf String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.Buyer.ToString)) = False Then

                        NameParts = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.Buyer.ToString).ToString.Split(" ")

                        If NameParts.Length = 2 Then

                            FirstName = NameParts(0)
                            LastName = NameParts(1)

                            Employee = (From EMP In DbContext.Employees
                                        Where EMP.FirstName = FirstName AndAlso
                                              EMP.LastName = LastName AndAlso
                                              EMP.TerminationDate Is Nothing AndAlso
                                              EMP.SignatureImage IsNot Nothing
                                        Select EMP).FirstOrDefault

                        End If

                    End If

                    If Employee IsNot Nothing AndAlso Employee.SignatureImage IsNot Nothing Then

                        Try

                            MemoryStream = New System.IO.MemoryStream(Employee.SignatureImage)

                            XrPictureBoxSignature.Image = System.Drawing.Image.FromStream(MemoryStream)

                        Catch ex As Exception

                        End Try

                    End If

                End Using

            End If

        End Sub
        Private Sub GroupHeaderEveryPageSubreportVendorAddressSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderEveryPageSubreportVendorAddressSubReport.BeforePrint

            Dim VendorCode As String = Nothing
            Dim Vendors As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing

            VendorCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.VendorCode.ToString)

            Try

                Vendors = New Generic.List(Of AdvantageFramework.Database.Entities.Vendor)

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Vendors.Add(AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorCode))

                End Using

            Catch ex As Exception
                Vendors = Nothing
            End Try

            If Vendors IsNot Nothing AndAlso Vendors.Count > 0 Then

                GroupHeaderEveryPageSubreportVendorAddressSubReport.ReportSource.DataSource = Vendors

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupHeaderEveryPageSubreportVendorRep1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderEveryPageSubreportVendorRep1.BeforePrint

            Dim VendorCode As String = Nothing
            Dim VendorRepCode As String = Nothing
            Dim VendorRepresentatives As IEnumerable(Of AdvantageFramework.Database.Entities.VendorRepresentative) = Nothing
            Dim ContactType As AdvantageFramework.Database.Entities.ContactType = Nothing
            Dim RepresentativeLabel As String = Nothing

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.IncludeRep1.ToString) = 1 Then

                VendorCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.VendorCode.ToString)

                VendorRepCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.VendorRepCode1.ToString)

                Try

                    Using DataContext As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        VendorRepresentatives = (From VR In AdvantageFramework.Database.Procedures.VendorRepresentative.Load(DataContext)
                                                 Where VR.VendorCode = VendorCode AndAlso
                                                       VR.Code = VendorRepCode AndAlso
                                                       (VR.IsInactive Is Nothing OrElse
                                                        VR.IsInactive = 0)
                                                 Select VR).ToList

                        If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.DefaultRep1Label.ToString) = 1 AndAlso VendorRepresentatives.Count > 0 AndAlso
                                VendorRepresentatives.First.ContactTypeID.HasValue Then

                            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                ContactType = AdvantageFramework.Database.Procedures.ContactType.LoadByContactTypeID(DbContext, VendorRepresentatives.First.ContactTypeID.Value)

                                If ContactType IsNot Nothing Then

                                    RepresentativeLabel = ContactType.Description

                                End If

                            End Using

                        End If

                    End Using

                Catch ex As Exception
                    VendorRepresentatives = Nothing
                End Try

                If VendorRepresentatives IsNot Nothing AndAlso VendorRepresentatives.Count > 0 Then

                    GroupHeaderEveryPageSubreportVendorRep1.ReportSource.DataSource = VendorRepresentatives

                    If RepresentativeLabel Is Nothing Then

                        RepresentativeLabel = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.RepLabel1.ToString)

                    End If

                    DirectCast(GroupHeaderEveryPageSubreportVendorRep1.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.VendorRepSubReport).RepresentativeLabel = RepresentativeLabel

                Else

                    e.Cancel = True

                End If

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupHeaderEveryPageSubreportVendorRep2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderEveryPageSubreportVendorRep2.BeforePrint

            Dim VendorCode As String = Nothing
            Dim VendorRepCode As String = Nothing
            Dim VendorRepresentatives As IEnumerable(Of AdvantageFramework.Database.Entities.VendorRepresentative) = Nothing
            Dim ContactType As AdvantageFramework.Database.Entities.ContactType = Nothing
            Dim RepresentativeLabel As String = Nothing

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.IncludeRep2.ToString) = 1 Then

                VendorCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.VendorCode.ToString)

                VendorRepCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.VendorRepCode2.ToString)

                Try

                    Using DataContext As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        VendorRepresentatives = (From VR In AdvantageFramework.Database.Procedures.VendorRepresentative.Load(DataContext)
                                                 Where VR.VendorCode = VendorCode AndAlso
                                                       VR.Code = VendorRepCode AndAlso
                                                       (VR.IsInactive Is Nothing OrElse
                                                        VR.IsInactive = 0)
                                                 Select VR).ToList

                        If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.DefaultRep2Label.ToString) = 1 AndAlso VendorRepresentatives.Count > 0 AndAlso
                                VendorRepresentatives.First.ContactTypeID.HasValue Then

                            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                ContactType = AdvantageFramework.Database.Procedures.ContactType.LoadByContactTypeID(DbContext, VendorRepresentatives.First.ContactTypeID.Value)

                                If ContactType IsNot Nothing Then

                                    RepresentativeLabel = ContactType.Description

                                End If

                            End Using

                        End If

                    End Using

                Catch ex As Exception
                    VendorRepresentatives = Nothing
                End Try

                If VendorRepresentatives IsNot Nothing AndAlso VendorRepresentatives.Count > 0 Then

                    GroupHeaderEveryPageSubreportVendorRep2.ReportSource.DataSource = VendorRepresentatives

                    If RepresentativeLabel Is Nothing Then

                        RepresentativeLabel = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.RepLabel2.ToString)

                    End If

                    DirectCast(GroupHeaderEveryPageSubreportVendorRep2.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.VendorRepSubReport).RepresentativeLabel = RepresentativeLabel

                Else

                    e.Cancel = True

                End If

            Else

                e.Cancel = True

            End If

        End Sub

        Private Sub GroupFooterSubreport_ChargeToSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterSubreport_ChargeToSubReport.BeforePrint

            If _LineNumbers.Count = 1 Then

                If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.ChargeTo.ToString)) OrElse Not _PrintCardInfo Then

                    e.Cancel = True

                Else

                    GroupFooterSubreport_ChargeToSubReport.ReportSource.DataSource = _AgencyList

                    DirectCast(GroupFooterSubreport_ChargeToSubReport.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.ChargeToSubReport).ChargeTo = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.ChargeTo.ToString)

                End If

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterSubreport_MonthYearSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterSubreport_MonthYearSubReport.BeforePrint

            'objects
            Dim BroadcastOrderYearMonths As Generic.List(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderYearMonth) = Nothing
            Dim BroadcastOrderYearMonth As AdvantageFramework.MediaManager.Classes.BroadcastOrderYearMonth = Nothing
            Dim CopyBroadcastOrder As AdvantageFramework.MediaManager.Classes.BroadcastOrder = Nothing
            Dim YearNumber As Short = 0
            Dim MonthNumber As Short = 0

            BroadcastOrderYearMonths = New Generic.List(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderYearMonth)

            For Each BroadcastOrder In _BroadcastOrders

                CopyBroadcastOrder = New AdvantageFramework.MediaManager.Classes.BroadcastOrder

                CopyPropertiesByName(CopyBroadcastOrder, BroadcastOrder)

                AddSpots(BroadcastOrder.SpotsWeek1, BroadcastOrder.StartWeek, BroadcastOrderYearMonths, BroadcastOrder.CostRate)
                AddSpots(BroadcastOrder.SpotsWeek2, BroadcastOrder.StartWeek2, BroadcastOrderYearMonths, BroadcastOrder.CostRate)
                AddSpots(BroadcastOrder.SpotsWeek3, BroadcastOrder.StartWeek3, BroadcastOrderYearMonths, BroadcastOrder.CostRate)
                AddSpots(BroadcastOrder.SpotsWeek4, BroadcastOrder.StartWeek4, BroadcastOrderYearMonths, BroadcastOrder.CostRate)
                AddSpots(BroadcastOrder.SpotsWeek5, BroadcastOrder.StartWeek5, BroadcastOrderYearMonths, BroadcastOrder.CostRate)
                AddSpots(BroadcastOrder.SpotsWeek6, BroadcastOrder.StartWeek6, BroadcastOrderYearMonths, BroadcastOrder.CostRate)
                AddSpots(BroadcastOrder.SpotsWeek7, BroadcastOrder.StartWeek7, BroadcastOrderYearMonths, BroadcastOrder.CostRate)
                AddSpots(BroadcastOrder.SpotsWeek8, BroadcastOrder.StartWeek8, BroadcastOrderYearMonths, BroadcastOrder.CostRate)
                AddSpots(BroadcastOrder.SpotsWeek9, BroadcastOrder.StartWeek9, BroadcastOrderYearMonths, BroadcastOrder.CostRate)
                AddSpots(BroadcastOrder.SpotsWeek10, BroadcastOrder.StartWeek10, BroadcastOrderYearMonths, BroadcastOrder.CostRate)
                AddSpots(BroadcastOrder.SpotsWeek11, BroadcastOrder.StartWeek11, BroadcastOrderYearMonths, BroadcastOrder.CostRate)
                AddSpots(BroadcastOrder.SpotsWeek12, BroadcastOrder.StartWeek12, BroadcastOrderYearMonths, BroadcastOrder.CostRate)
                AddSpots(BroadcastOrder.SpotsWeek13, BroadcastOrder.StartWeek13, BroadcastOrderYearMonths, BroadcastOrder.CostRate)

            Next

            If _Units = "BM" OrElse _Units = "DB" Then

                For Each BroadcastOrderYearMonth In BroadcastOrderYearMonths

                    YearNumber = Mid(BroadcastOrderYearMonth.YearMonth.ToString, 1, 4)
                    MonthNumber = Mid(BroadcastOrderYearMonth.YearMonth.ToString, 5, 2)

                    If Mid(_MediaFrom, 1, 1).ToUpper = "R" Then

                        If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 1 Then

                            BroadcastOrderYearMonth.TotalNet = _RadioOrderDetails.Where(Function(ST) ST.YearNumber = YearNumber AndAlso ST.MonthNumber = MonthNumber).Sum(Function(ST) ST.ExtendedGrossAmount)

                        Else

                            BroadcastOrderYearMonth.TotalNet = _RadioOrderDetails.Where(Function(ST) ST.YearNumber = YearNumber AndAlso ST.MonthNumber = MonthNumber).Sum(Function(ST) ST.ExtendedNetAmount)

                        End If

                    ElseIf Mid(_MediaFrom, 1, 1).ToUpper = "T" Then

                        If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 1 Then

                            BroadcastOrderYearMonth.TotalNet = _TVOrderDetails.Where(Function(ST) ST.YearNumber = YearNumber AndAlso ST.MonthNumber = MonthNumber).Sum(Function(ST) ST.ExtendedGrossAmount)

                        Else

                            BroadcastOrderYearMonth.TotalNet = _TVOrderDetails.Where(Function(ST) ST.YearNumber = YearNumber AndAlso ST.MonthNumber = MonthNumber).Sum(Function(ST) ST.ExtendedNetAmount)

                        End If

                    End If

                Next

            End If

            If BroadcastOrderYearMonths IsNot Nothing AndAlso BroadcastOrderYearMonths.Count > 0 Then

                BroadcastOrderYearMonth = New AdvantageFramework.MediaManager.Classes.BroadcastOrderYearMonth With {
                    .YearMonth = "999999",
                    .MonthYear = "Total",
                    .Spots = BroadcastOrderYearMonths.Sum(Function(Entity) Entity.Spots),
                    .TotalNet = BroadcastOrderYearMonths.Sum(Function(Entity) Entity.TotalNet)
                }

                BroadcastOrderYearMonths.Add(BroadcastOrderYearMonth)

                GroupFooterSubreport_MonthYearSubReport.ReportSource.DataSource = BroadcastOrderYearMonths

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_AgencyComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_AgencyComment.BeforePrint

            Dim NewFont As System.Drawing.Font = Nothing

            If _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                e.Cancel = True

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.AgencyCommentFontSize.ToString) IsNot Nothing Then

                NewFont = New Drawing.Font("Arial", Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.AgencyCommentFontSize.ToString), Drawing.FontStyle.Regular Or Drawing.FontStyle.Bold)

                LabelGroupFooterOrderNumber_AgencyComment.Font = NewFont

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_OrderHeaderComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_OrderHeaderComment.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInFooter OrElse
                    _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupFooterOrderCommentBottom_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderCommentBottom.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInFooter OrElse
                    _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                LabelGroupFooterOrderCommentBottom.Text = Nothing

            End If

        End Sub
        Private Sub LabelRating_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If _MediaOrderPrintSetting.PrimaryRatings.GetValueOrDefault(False) = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelCPP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If _MediaOrderPrintSetting.PrimaryCPP.GetValueOrDefault(False) = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupHeaderCycleDemographic_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If _MediaOrderPrintSetting.PrimaryRatings.GetValueOrDefault(False) = False AndAlso _MediaOrderPrintSetting.PrimaryCPP.GetValueOrDefault(False) = False Then

                e.Cancel = True

            End If

        End Sub


        Private Sub GroupFooterCyleGRP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If _MediaOrderPrintSetting.PrimaryRatings.GetValueOrDefault(False) = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek1.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek2.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek3_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek3.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek4_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek4.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek5_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek5.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek6_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek6.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek7_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek7.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek8_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek8.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek9_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek9.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek10_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek10.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek11_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek11.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek12_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek12.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek13_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek13.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_NielsenRadioDisclaimer_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_NielsenRadioDisclaimer.BeforePrint

            If _MediaOrderPrintSetting.PrimaryRatings.GetValueOrDefault(False) = False Then

                e.Cancel = True

            ElseIf Mid(_MediaFrom, 1, 1).ToUpper = "R" AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.CreatedFromWorkSheet.ToString) Then

                LabelGroupFooterOrderNumber_NielsenRadioDisclaimer.Text = Space(1) & vbCrLf & _ConstNielsenRadioDisclaimer & IIf(_IsRadioPPMMarket, vbCrLf & vbCrLf & AdvantageFramework.DTO.Media.ConstNielsenRadioFooter, "")

            End If

        End Sub
        Private Sub PageFooterLabelNielsenCopyright_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageFooterLabelNielsenCopyright.BeforePrint

            If _MediaOrderPrintSetting.PrimaryRatings.GetValueOrDefault(False) = False Then

                e.Cancel = True

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.ShowNielsenCopyright.ToString) Then

                PageFooterLabelNielsenCopyright.Text = _NielsenCopyright

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_TotalNet_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_TotalNet.BeforePrint

            Dim Total As Decimal? = Nothing

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            Else

                If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 0 Then

                    Total = LabelGroupFooterOrderNumber_SubTotal.Summary.GetResult() + _NetCharge.GetValueOrDefault(0) + _Discount.GetValueOrDefault(0) + _VendorTax.GetValueOrDefault(0)

                Else

                    Total = LabelGroupFooterOrderNumber_SubTotal.Summary.GetResult() + _NetCharge.GetValueOrDefault(0) + _Discount.GetValueOrDefault(0) + _Commission.GetValueOrDefault(0) + _VendorTax.GetValueOrDefault(0)

                End If

                LabelGroupFooterOrderNumber_TotalNet.Text = FormatNumber(Total, 2)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_TotalNetLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_TotalNetLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_SubTotalLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_SubTotalLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 1 Then

                LabelGroupFooterOrderNumber_SubTotalLabel.Text = "Total Gross:"

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterLabelTotalNet_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterLabelTotalNet.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 1 Then

                GroupFooterLabelTotalNet.Text = "Total Gross"

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_SubTotal_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_SubTotal.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterCycle_AfterPrint(sender As Object, e As EventArgs) Handles GroupFooterCycle.AfterPrint

            _DetailRowCount = 0

        End Sub
        Private Sub GroupFooterCycleLabelSubTotal_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterCycleLabelSubTotal.BeforePrint

            If _DetailRowCount < 2 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterCyleLabelAmountTotal_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterCyleLabelAmountTotal.BeforePrint

            If _DetailRowCount < 2 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterCyleLabelSpotsTotal_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If _DetailRowCount < 2 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub Detail_AfterPrint(sender As Object, e As EventArgs) Handles Detail.AfterPrint

            _DetailRowCount += 1

            If _IsFirstPage Then

                _IsFirstPage = False

            End If

        End Sub
        Private Sub GroupFooterCyleLabelSpotsTotalWeek1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If DirectCast(sender, DevExpress.XtraReports.UI.XRLabel).Name.StartsWith("GroupFooterCyleLabelSpotsTotalWeek") Then

                If DirectCast(sender, DevExpress.XtraReports.UI.XRLabel).Summary.GetResult <= 0 OrElse _DetailRowCount < 2 Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_AgencyCommentTop_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_AgencyCommentTop.BeforePrint

            Dim NewFont As System.Drawing.Font = Nothing

            If Not _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                e.Cancel = True

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.AgencyCommentFontSize.ToString) IsNot Nothing Then

                NewFont = New Drawing.Font("Arial", Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.AgencyCommentFontSize.ToString), Drawing.FontStyle.Regular Or Drawing.FontStyle.Bold)

                LabelGroupFooterOrderNumber_AgencyComment.Font = NewFont

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_OrderHeaderCommentTop_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_OrderHeaderCommentTop.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInFooter OrElse
                    Not _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupFooterOrderCommentTop_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderCommentTop.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInFooter OrElse
                    Not _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                LabelGroupFooterOrderCommentTop.Text = Nothing

            End If

        End Sub
        Private Sub LabelRemarks_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If _MediaOrderPrintSetting.Remarks.GetValueOrDefault(0) = 0 Then

                e.Cancel = True

            End If

        End Sub

        Private Sub LabelCPM_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            e.Cancel = Not _MediaOrderPrintSetting.PrimaryCPM

        End Sub

        Private Sub XrTableRowHeaderOrderInstructions_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableRowHeaderOrderInstructions.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.OrderHeaderComment.ToString)) OrElse
                    Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInHeader Then

                e.Cancel = True

            End If

        End Sub
        Private Sub XrTableRowHeaderSeparationPolicy_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableRowHeaderSeparationPolicy.BeforePrint

            If _MediaOrderPrintSetting.SeparationPolicy.GetValueOrDefault(False) = False OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SeparationPolicy.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LineDetailDots_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LineDetailDots.BeforePrint

            'Dim Cycle As Integer? = Nothing

            'Cycle = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.Cycle.ToString)

            'If _BroadcastOrders.Where(Function(BO) BO.Cycle.GetValueOrDefault(0) = Cycle.GetValueOrDefault(0)).Count - 1 = _DetailRowCount Then

            '    e.Cancel = True

            'End If

        End Sub
        Private Sub XrTableRowMiddleMarket_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableRowMiddleMarket.BeforePrint

            If _MediaOrderPrintSetting.Market.GetValueOrDefault(0) = 0 OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.MarketName.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub XrTableRowMiddleCampaign_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableRowMiddleCampaign.BeforePrint

            If _MediaOrderPrintSetting.Campaign.GetValueOrDefault(0) = 0 OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.CampaignName.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub XrTableRowRightEmail_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableRowRightEmail.BeforePrint

            If String.IsNullOrWhiteSpace(_EmployeeEmail) Then

                e.Cancel = True

            Else

                XrTableCellRightEmail.Text = _EmployeeEmail

            End If

        End Sub
        Private Sub XrTableRowLeftClient_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableRowLeftClient.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.ClientName.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub XrTableRowLeftDivision_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableRowLeftDivision.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.DivisionName.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub XrTableRowLeftProduct_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableRowLeftProduct.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.ProductionDescription.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub XrTableRowRightBuyer_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableRowRightBuyer.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.Buyer.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterCycleTotalDisplayImpressions_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If Mid(_MediaFrom, 1, 1).ToUpper = "T" AndAlso Not _MediaOrderPrintSetting.PrimaryImpressions Then

                e.Cancel = True

            ElseIf Mid(_MediaFrom, 1, 1).ToUpper = "R" AndAlso Not _MediaOrderPrintSetting.PrimaryAQH Then

                e.Cancel = True

            End If



        End Sub
        Private Sub DetailPrimaryCPM_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If Not _MediaOrderPrintSetting.PrimaryCPM Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailPrimaryCPP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If Not _MediaOrderPrintSetting.PrimaryCPP.GetValueOrDefault(False) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailRating_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If _MediaOrderPrintSetting.PrimaryRatings.GetValueOrDefault(False) = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub SubBandSignatures_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubBandSignatures.BeforePrint

            If _MediaOrderPrintSetting.RemoveSignatureLines Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_LineCancelled_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.LineCancelled.ToString) = 0 Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

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

    End Class

End Namespace
