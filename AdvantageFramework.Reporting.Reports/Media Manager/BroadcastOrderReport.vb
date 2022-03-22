Namespace MediaManager

    Public Class BroadcastOrderReport

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
        Private _SuppressRatings As Boolean = True
        Private _ComscoreCopyright As String = "Copyright © " & Now.Year.ToString & " Comscore"
        Private _EastlanCopyright As String = "Copyright © " & Now.Year.ToString & " EASTLAN"
        Private _RatingsServiceID As Nullable(Of Integer) = Nothing
        Private _UseImpersonation As Boolean = False
        Private _ExchangeRate As Decimal = 1
        Private _CurrencyCode As String = String.Empty
        Private _CurrencySymbol As String = String.Empty
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
        Public WriteOnly Property UseImpersonation As Boolean
            Set(value As Boolean)
                _UseImpersonation = value
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

                        BroadcastOrderYearMonth.TotalNet += Spots.Value * CostRate.GetValueOrDefault(0) '* _ExchangeRate

                    End If

                Else

                    BroadcastOrderYearMonth = New AdvantageFramework.MediaManager.Classes.BroadcastOrderYearMonth

                    BroadcastOrderYearMonth.Spots = Spots.Value
                    BroadcastOrderYearMonth.YearMonth = BroadcastCal.brd_year.ToString & MonthAbbrevToNumber(BroadcastCal.brd_month)
                    BroadcastOrderYearMonth.MonthYear = BroadcastCal.brd_month & Space(1) & "'" & Mid(BroadcastCal.brd_year.ToString, 3, 2)
                    BroadcastOrderYearMonth.BroadcastMonthAbbrev = BroadcastCal.brd_month
                    BroadcastOrderYearMonth.BroadcastYear = BroadcastCal.brd_year

                    If _Units <> "BM" AndAlso _Units <> "DB" Then

                        BroadcastOrderYearMonth.TotalNet = Spots.Value * CostRate.GetValueOrDefault(0) '* _ExchangeRate

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
        Private Sub BroadcastOrderReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim MediaBroadcastWorksheetMarketID As Integer = 0
            Dim NielsenRadioPeriodID As Nullable(Of Integer) = Nothing
            Dim NielsenRadioPeriod As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim OrderPrintSetting As AdvantageFramework.Media.Classes.OrderPrintSetting = Nothing
            Dim VendorCode As String = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim MultiCurrencyOn As Boolean = False
            Dim HomeCurrencyCode As String = Nothing
            Dim CurrencyDetail As AdvantageFramework.Database.Entities.CurrencyDetail = Nothing

            _AgencyList = New Generic.List(Of AdvantageFramework.Database.Entities.Agency)

            If _LineNumbers IsNot Nothing AndAlso _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _AgencyList.Add(AdvantageFramework.Database.Procedures.Agency.Load(DbContext))

                    If _AgencyList IsNot Nothing AndAlso _AgencyList.Count = 1 Then

                        If _AgencyList(0).UseMultipleCurrencies.GetValueOrDefault(0) = 1 Then

                            MultiCurrencyOn = True

                            HomeCurrencyCode = _AgencyList(0).HomeCurrency

                        End If

                    End If

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

                        _LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _MediaOrderPrintSetting.LocationID, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderLandscape)

                    Else

                        _LocationLogo = Nothing

                    End If

                    If Mid(_MediaFrom, 1, 1).ToUpper = "R" Then

                        RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, _OrderNumber)

                        If RadioOrder IsNot Nothing Then

                            _Units = RadioOrder.Units

                            If MultiCurrencyOn AndAlso Not String.IsNullOrWhiteSpace(RadioOrder.Vendor.CurrencyCode) AndAlso RadioOrder.Vendor.CurrencyCode <> HomeCurrencyCode Then

                                _CurrencyCode = RadioOrder.Vendor.CurrencyCode

                                Try

                                    _CurrencySymbol = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(CURRENCY_SYMBOL, '') FROM dbo.CURRENCY_CODES WHERE CURRENCY_CODE = '{0}'", _CurrencyCode)).FirstOrDefault

                                Catch ex As Exception
                                    _CurrencySymbol = String.Empty
                                End Try

                                CurrencyDetail = AdvantageFramework.Database.Procedures.CurrencyDetail.LoadLatestByCurrencyCodeAndCurrencyCodeComparison(DbContext, RadioOrder.Vendor.CurrencyCode, HomeCurrencyCode)

                                If CurrencyDetail IsNot Nothing Then

                                    _ExchangeRate = CurrencyDetail.ReciprocalExchangeRate

                                End If

                            End If

                        End If

                    ElseIf Mid(_MediaFrom, 1, 1).ToUpper = "T" Then

                        TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, _OrderNumber)

                        If TVOrder IsNot Nothing Then

                            _Units = TVOrder.Units

                            If MultiCurrencyOn AndAlso Not String.IsNullOrWhiteSpace(TVOrder.Vendor.CurrencyCode) AndAlso TVOrder.Vendor.CurrencyCode <> HomeCurrencyCode Then

                                _CurrencyCode = TVOrder.Vendor.CurrencyCode

                                Try

                                    _CurrencySymbol = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(CURRENCY_SYMBOL, '') FROM dbo.CURRENCY_CODES WHERE CURRENCY_CODE = '{0}'", _CurrencyCode)).FirstOrDefault

                                Catch ex As Exception
                                    _CurrencySymbol = String.Empty
                                End Try

                                CurrencyDetail = AdvantageFramework.Database.Procedures.CurrencyDetail.LoadLatestByCurrencyCodeAndCurrencyCodeComparison(DbContext, TVOrder.Vendor.CurrencyCode, HomeCurrencyCode)

                                If CurrencyDetail IsNot Nothing Then

                                    _ExchangeRate = CurrencyDetail.ReciprocalExchangeRate

                                End If

                            End If

                        End If

                    End If

                    If MultiCurrencyOn Then

                        _BroadcastOrders = AdvantageFramework.MediaManager.LoadBroadcastOrder(DbContext, _OrderNumber, String.Join(",", _LineNumbers), _MediaFrom, _MediaOrderPrintSetting.BroadcastShowEmptyWeeks, _ExchangeRate).ToList

                    Else

                        If _MediaOrderPrintSetting.ApplyExchangeRate Then

                            _ExchangeRate = _MediaOrderPrintSetting.ExchangeRate.GetValueOrDefault(1)

                        End If

                        _BroadcastOrders = AdvantageFramework.MediaManager.LoadBroadcastOrder(DbContext, _OrderNumber, String.Join(",", _LineNumbers), _MediaFrom, _MediaOrderPrintSetting.BroadcastShowEmptyWeeks, _ExchangeRate).ToList

                    End If

                    _PrintCardInfo = DbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(AGY_SETTINGS_VALUE as bit) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'VCC_INCLUDE_CARDINFO'").FirstOrDefault

                    If _BroadcastOrders IsNot Nothing AndAlso _BroadcastOrders.Count > 0 Then

                        VendorCode = _BroadcastOrders.First.VendorCode

                        Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorCode)

                        If Vendor IsNot Nothing Then

                            If Mid(_MediaFrom, 1, 1).ToUpper = "R" Then

                                _RatingsServiceID = DbContext.Database.SqlQuery(Of Integer)(String.Format("Select Top 1 CAST(MBWM.EXTERNAL_RADIO_SOURCE As int) From [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL] MBWMD " &
                                    "INNER Join [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE] MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID " &
                                    "INNER Join [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET] MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID  " &
                                    "WHERE ORDER_NBR = {0}", _OrderNumber)).FirstOrDefault

                                If _RatingsServiceID.HasValue AndAlso _RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                                    _SuppressRatings = Not Vendor.IsNielsenSubsciber

                                ElseIf _RatingsServiceID.HasValue AndAlso _RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                                    _SuppressRatings = False

                                End If

                            Else

                                _RatingsServiceID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT TOP 1 MBW.RATINGS_SERVICE_ID FROM [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL] MBWMD " &
                                    "INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE] MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID " &
                                    "INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET] MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID " &
                                    "INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET] MBW ON MBWM.MEDIA_BROADCAST_WORKSHEET_ID = MBW.MEDIA_BROADCAST_WORKSHEET_ID WHERE ORDER_NBR = {0}", _OrderNumber)).FirstOrDefault

                                If _RatingsServiceID.HasValue AndAlso _RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                                    _SuppressRatings = Not Vendor.IsNielsenSubsciber

                                ElseIf _RatingsServiceID.HasValue AndAlso _RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                                    _SuppressRatings = Not Vendor.IsComscoreSubsciber

                                End If

                            End If

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

                        _VendorTax = _RadioOrderDetails.Sum(Function(D) D.NonResaleAmount) * _ExchangeRate
                        _NetCharge = _RadioOrderDetails.Sum(Function(D) D.NetCharge) * _ExchangeRate
                        _Discount = _RadioOrderDetails.Sum(Function(D) D.DiscountAmount) * _ExchangeRate
                        _Commission = _RadioOrderDetails.Sum(Function(D) D.CommissionAmount) * -1 * _ExchangeRate

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

                    ElseIf Mid(_MediaFrom, 1, 1).ToUpper = "T" Then

                        _TVOrderDetails = (From TOD In AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, _OrderNumber)
                                           Where _LineNumbers.Contains(TOD.LineNumber) AndAlso
                                                 (TOD.IsLineCancelled Is Nothing OrElse TOD.IsLineCancelled = 0) AndAlso
                                                 (TOD.CostRate > 0 OrElse TOD.TotalSpots > 0)
                                           Select TOD).ToList

                        _VendorTax = _TVOrderDetails.Sum(Function(D) D.NonResaleAmount) * _ExchangeRate
                        _NetCharge = _TVOrderDetails.Sum(Function(D) D.NetCharges) * _ExchangeRate
                        _Discount = _TVOrderDetails.Sum(Function(D) D.DiscountAmount) * _ExchangeRate
                        _Commission = _TVOrderDetails.Sum(Function(D) D.CommissionAmount) * -1 * _ExchangeRate

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

                    End If

                End Using

            Else

                _BroadcastOrders = New Generic.List(Of AdvantageFramework.MediaManager.Classes.BroadcastOrder)

            End If

            For Each BroadcastOrder In _BroadcastOrders

                If String.IsNullOrEmpty(BroadcastOrder.LocationHeader) = False Then

                    BroadcastOrder.LocationHeader = BroadcastOrder.LocationHeader.Trim

                End If

                If String.IsNullOrEmpty(BroadcastOrder.LocationFooter) = False Then

                    BroadcastOrder.LocationFooter = BroadcastOrder.LocationFooter.Trim

                End If

            Next

            If _MediaOrderPrintSetting.ShowLineNumbers Then

                LabelLine_Label.Visible = True
                LabelLine.Visible = True

            End If

            Me.DataSource = _BroadcastOrders

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub GroupHeaderCycle_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderCycle.BeforePrint

            LabelGroupHeaderCycle_NetGross.Text = If(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 1, "Gross", "Net")

        End Sub
        Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

            Dim Cancel As Boolean = True

            If _MediaOrderPrintSetting IsNot Nothing Then

                If String.IsNullOrWhiteSpace(_MediaOrderPrintSetting.LocationID) = False Then

                    If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.PageHeaderLogoPath.ToString)) = False Then

                        If _UseImpersonation Then

                            XrPictureBoxHeaderLogo.Image = AdvantageFramework.Reporting.Reports.GetLogoImage(_AgencyList.FirstOrDefault, Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.PageHeaderLogoPath.ToString))

                            If XrPictureBoxHeaderLogo.Image IsNot Nothing Then

                                Cancel = False

                            End If

                        ElseIf My.Computer.FileSystem.FileExists(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.PageHeaderLogoPath.ToString)) Then

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

            If Not String.IsNullOrWhiteSpace(VendorCode) Then

                Try

                    Vendors = New Generic.List(Of AdvantageFramework.Database.Entities.Vendor)

                    Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Vendors.Add(AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorCode))

                    End Using

                Catch ex As Exception
                    Vendors = Nothing
                End Try

            End If

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
        Private Sub DetailSubreport_ChargeToSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailSubreport_ChargeToSubReport.BeforePrint

            If _LineNumbers.Count = 1 OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.ChargeTo.ToString)) OrElse Not _PrintCardInfo Then

                e.Cancel = True

            Else

                DetailSubreport_ChargeToSubReport.ReportSource.DataSource = _AgencyList

                DirectCast(DetailSubreport_ChargeToSubReport.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.ChargeToSubReport).ChargeTo = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.ChargeTo.ToString)

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
            Dim YearNumber As Short = 0
            Dim MonthNumber As Short = 0

            BroadcastOrderYearMonths = New Generic.List(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderYearMonth)

            For Each BroadcastOrder In _BroadcastOrders

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

                            BroadcastOrderYearMonth.TotalNet = _RadioOrderDetails.Where(Function(ST) ST.YearNumber = YearNumber AndAlso ST.MonthNumber = MonthNumber).Sum(Function(ST) ST.ExtendedGrossAmount) * _ExchangeRate
                            BroadcastOrderYearMonth.TotalNetWhenGrossOrder = _RadioOrderDetails.Where(Function(ST) ST.YearNumber = YearNumber AndAlso ST.MonthNumber = MonthNumber).Sum(Function(ST) ST.ExtendedNetAmount) * _ExchangeRate

                        Else

                            BroadcastOrderYearMonth.TotalNet = _RadioOrderDetails.Where(Function(ST) ST.YearNumber = YearNumber AndAlso ST.MonthNumber = MonthNumber).Sum(Function(ST) ST.ExtendedNetAmount) * _ExchangeRate

                        End If

                    ElseIf Mid(_MediaFrom, 1, 1).ToUpper = "T" Then

                        If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 1 Then

                            BroadcastOrderYearMonth.TotalNet = _TVOrderDetails.Where(Function(ST) ST.YearNumber = YearNumber AndAlso ST.MonthNumber = MonthNumber).Sum(Function(ST) ST.ExtendedGrossAmount) * _ExchangeRate
                            BroadcastOrderYearMonth.TotalNetWhenGrossOrder = _TVOrderDetails.Where(Function(ST) ST.YearNumber = YearNumber AndAlso ST.MonthNumber = MonthNumber).Sum(Function(ST) ST.ExtendedNetAmount) * _ExchangeRate

                        Else

                            BroadcastOrderYearMonth.TotalNet = _TVOrderDetails.Where(Function(ST) ST.YearNumber = YearNumber AndAlso ST.MonthNumber = MonthNumber).Sum(Function(ST) ST.ExtendedNetAmount) * _ExchangeRate

                        End If

                    End If

                    BroadcastOrderYearMonth.ShowTotalNetWhenGrossOrder = _MediaOrderPrintSetting.ShowTotalNetForGrossOrder

                Next

            End If

            If BroadcastOrderYearMonths IsNot Nothing AndAlso BroadcastOrderYearMonths.Count > 0 Then

                BroadcastOrderYearMonth = New AdvantageFramework.MediaManager.Classes.BroadcastOrderYearMonth
                BroadcastOrderYearMonth.YearMonth = "999999"
                BroadcastOrderYearMonth.MonthYear = "Total"
                BroadcastOrderYearMonth.Spots = BroadcastOrderYearMonths.Sum(Function(Entity) Entity.Spots)
                BroadcastOrderYearMonth.TotalNet = BroadcastOrderYearMonths.Sum(Function(Entity) Entity.TotalNet)
                BroadcastOrderYearMonth.TotalNetWhenGrossOrder = BroadcastOrderYearMonths.Sum(Function(Entity) Entity.TotalNetWhenGrossOrder)
                BroadcastOrderYearMonth.ShowTotalNetWhenGrossOrder = _MediaOrderPrintSetting.ShowTotalNetForGrossOrder

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
        Private Sub RichTextGroupFooterOrderNumber_OrderHeaderComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles RichTextGroupFooterOrderNumber_OrderHeaderComment.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInFooter OrElse
                    _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                e.Cancel = True

            ElseIf TypeOf sender Is DevExpress.XtraReports.UI.XRRichText Then

                CType(sender, DevExpress.XtraReports.UI.XRRichText).Text = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.OrderHeaderComment.ToString)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderCommentBottom_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderCommentBottom.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInFooter OrElse
                    _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                LabelGroupFooterOrderCommentBottom.Text = Nothing

            End If

        End Sub
        Private Sub LabelRating_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelRating.BeforePrint

            If _SuppressRatings OrElse _MediaOrderPrintSetting.PrimaryRatings.GetValueOrDefault(False) = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelCPP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelCPP.BeforePrint

            If _SuppressRatings OrElse _MediaOrderPrintSetting.PrimaryCPP.GetValueOrDefault(False) = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupHeaderCycleDemographic_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderCycleDemographic.BeforePrint

            If _SuppressRatings OrElse (_MediaOrderPrintSetting.PrimaryRatings.GetValueOrDefault(False) = False AndAlso _MediaOrderPrintSetting.PrimaryCPP.GetValueOrDefault(False) = False) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterCyleCPM_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterCyleCPM.BeforePrint

            If _SuppressRatings Then

                e.Cancel = True

            Else

                If _MediaOrderPrintSetting.PrimaryCPM = False Then

                    e.Cancel = True

                ElseIf Mid(_MediaFrom, 1, 1).ToUpper = "T" AndAlso GroupFooterCyleLabelAmountTotal.Summary.GetResult IsNot Nothing AndAlso GroupFooterCycleTotalImpressions.Summary.GetResult IsNot Nothing AndAlso GroupFooterCycleTotalImpressions.Summary.GetResult <> 0 Then

                    GroupFooterCyleCPM.Text = FormatNumber(GroupFooterCyleLabelAmountTotal.Summary.GetResult / GroupFooterCycleTotalImpressions.Summary.GetResult * 1000, 2)

                ElseIf Mid(_MediaFrom, 1, 1).ToUpper = "R" AndAlso GroupFooterCyleLabelAmountTotal.Summary.GetResult IsNot Nothing AndAlso GroupFooterCycleTotalImpressions.Summary.GetResult IsNot Nothing AndAlso GroupFooterCycleTotalImpressions.Summary.GetResult <> 0 Then

                    GroupFooterCyleCPM.Text = FormatNumber(GroupFooterCyleLabelAmountTotal.Summary.GetResult / GroupFooterCycleTotalImpressions.Summary.GetResult * 1000, 2)

                End If

            End If

        End Sub
        Private Sub GroupFooterCyleTotalCPP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterCyleTotalCPP.BeforePrint

            If _SuppressRatings Then

                e.Cancel = True

            Else

                If _MediaOrderPrintSetting.PrimaryCPP.GetValueOrDefault(False) = False Then

                    e.Cancel = True

                ElseIf GroupFooterCyleLabelAmountTotal.Summary.GetResult IsNot Nothing AndAlso
                    GroupFooterCyleGRP.Summary.GetResult IsNot Nothing AndAlso GroupFooterCyleGRP.Summary.GetResult <> 0 Then

                    GroupFooterCyleTotalCPP.Text = FormatNumber(GroupFooterCyleLabelAmountTotal.Summary.GetResult / GroupFooterCyleGRP.Summary.GetResult, 2)

                Else

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub GroupFooterCyleGRP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterCyleGRP.BeforePrint

            If _SuppressRatings OrElse _MediaOrderPrintSetting.PrimaryRatings.GetValueOrDefault(False) = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailSpotsTotalWeek1.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek1.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailSpotsTotalWeek2.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek2.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek3_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailSpotsTotalWeek3.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek3.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek4_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailSpotsTotalWeek4.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek4.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek5_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailSpotsTotalWeek5.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek5.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek6_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailSpotsTotalWeek6.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek6.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek7_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailSpotsTotalWeek7.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek7.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek8_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailSpotsTotalWeek8.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek8.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek9_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailSpotsTotalWeek9.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek9.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek10_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailSpotsTotalWeek10.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek10.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek11_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailSpotsTotalWeek11.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek11.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek12_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailSpotsTotalWeek12.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SpotsWeek12.ToString) <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailSpotsTotalWeek13_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailSpotsTotalWeek13.BeforePrint

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

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.ShowNielsenCopyright.ToString) AndAlso _RatingsServiceID.HasValue Then

                If Mid(_MediaFrom, 1, 1).ToUpper = "R" Then

                    If _RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                        PageFooterLabelNielsenCopyright.Text = _NielsenCopyright

                    ElseIf _RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                        PageFooterLabelNielsenCopyright.Text = _EastlanCopyright

                    End If

                Else

                    If _RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                        PageFooterLabelNielsenCopyright.Text = _NielsenCopyright

                    ElseIf _RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                        PageFooterLabelNielsenCopyright.Text = _ComscoreCopyright

                    End If

                End If

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

                If String.IsNullOrWhiteSpace(_CurrencySymbol) = False Then

                    LabelGroupFooterOrderNumber_TotalNet.Text = _CurrencySymbol & FormatNumber(Total, 2)

                Else


                    LabelGroupFooterOrderNumber_TotalNet.Text = FormatNumber(Total, 2)

                End If

            End If

        End Sub
        Private Sub LabelGroupFooterOrderNumber_TotalNetLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderNumber_TotalNetLabel.BeforePrint

            If Not _MediaOrderPrintSetting.AgencyCommission AndAlso Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.NetGross.ToString) = 1 Then

                e.Cancel = True

            Else

                If String.IsNullOrWhiteSpace(_CurrencyCode) = False Then

                    LabelGroupFooterOrderNumber_TotalNetLabel.Text &= "(" & _CurrencyCode & ")"

                End If

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
        Private Sub GroupFooterCyleLabelSpotsTotal_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterCyleLabelSpotsTotal.BeforePrint

            If _DetailRowCount < 2 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub Detail_AfterPrint(sender As Object, e As EventArgs) Handles Detail.AfterPrint

            _DetailRowCount += 1

        End Sub
        Private Sub GroupFooterCyleLabelSpotsTotalWeek1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterCyleLabelSpotsTotalWeek1.BeforePrint, GroupFooterCyleLabelSpotsTotalWeek2.BeforePrint,
                GroupFooterCyleLabelSpotsTotalWeek3.BeforePrint, GroupFooterCyleLabelSpotsTotalWeek4.BeforePrint, GroupFooterCyleLabelSpotsTotalWeek5.BeforePrint, GroupFooterCyleLabelSpotsTotalWeek6.BeforePrint,
                GroupFooterCyleLabelSpotsTotalWeek7.BeforePrint, GroupFooterCyleLabelSpotsTotalWeek8.BeforePrint, GroupFooterCyleLabelSpotsTotalWeek9.BeforePrint, GroupFooterCyleLabelSpotsTotalWeek10.BeforePrint,
                GroupFooterCyleLabelSpotsTotalWeek11.BeforePrint, GroupFooterCyleLabelSpotsTotalWeek12.BeforePrint, GroupFooterCyleLabelSpotsTotalWeek13.BeforePrint

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
        Private Sub RichTextGroupFooterOrderNumber_OrderHeaderCommentTop_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles RichTextGroupFooterOrderNumber_OrderHeaderCommentTop.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInFooter OrElse
                    Not _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                e.Cancel = True

            ElseIf TypeOf sender Is DevExpress.XtraReports.UI.XRRichText Then

                CType(sender, DevExpress.XtraReports.UI.XRRichText).Text = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.OrderHeaderComment.ToString)

            End If

        End Sub
        Private Sub LabelGroupFooterOrderCommentTop_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterOrderCommentTop.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInFooter OrElse
                    Not _MediaOrderPrintSetting.PutSignatureBelowAllComments Then

                LabelGroupFooterOrderCommentTop.Text = Nothing

            End If

        End Sub
        Private Sub LabelRemarks_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelRemarks.BeforePrint

            If _MediaOrderPrintSetting.Remarks.GetValueOrDefault(0) = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailDisplayImpressions_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailDisplayImpressions.BeforePrint

            If _SuppressRatings Then

                e.Cancel = True

            Else

                If Mid(_MediaFrom, 1, 1).ToUpper = "R" Then

                    If Not _MediaOrderPrintSetting.PrimaryAQH Then

                        e.Cancel = True

                    Else

                        DetailDisplayImpressions.Text = FormatNumber(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.DisplayImpressions.ToString), 0)

                    End If

                Else

                    If Not _MediaOrderPrintSetting.PrimaryImpressions Then

                        e.Cancel = True

                    Else

                        DetailDisplayImpressions.Text = FormatNumber(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.DisplayImpressions.ToString), 1)

                    End If

                End If

            End If

        End Sub
        Private Sub LabelCPM_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelCPM.BeforePrint

            e.Cancel = _SuppressRatings OrElse Not _MediaOrderPrintSetting.PrimaryCPM

        End Sub
        Private Sub LabelImpressionsAQH_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelImpressionsAQH.BeforePrint

            If _SuppressRatings Then

                e.Cancel = True

            Else

                If Mid(_MediaFrom, 1, 1).ToUpper = "R" Then

                    If _MediaOrderPrintSetting.PrimaryAQH Then

                        LabelImpressionsAQH.Text = "AQH(00)"

                    Else

                        e.Cancel = True

                    End If

                Else

                    e.Cancel = Not _MediaOrderPrintSetting.PrimaryImpressions

                End If

            End If

        End Sub
        Private Sub XrTableRowHeaderSeparationPolicy_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableRowHeaderSeparationPolicy.BeforePrint

            If _MediaOrderPrintSetting.SeparationPolicy.GetValueOrDefault(False) = False OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.SeparationPolicy.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LineDetailDots_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LineDetailDots.BeforePrint

            Dim Cycle As Integer? = Nothing

            Cycle = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.Cycle.ToString)

            If _BroadcastOrders.Where(Function(BO) BO.Cycle.GetValueOrDefault(0) = Cycle.GetValueOrDefault(0)).Count - 1 = _DetailRowCount Then

                e.Cancel = True

            End If

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
        Private Sub GroupFooterCycleTotalDisplayImpressions_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterCycleTotalDisplayImpressions.BeforePrint

            If _SuppressRatings Then

                e.Cancel = True

            Else

                If Mid(_MediaFrom, 1, 1).ToUpper = "T" AndAlso Not _MediaOrderPrintSetting.PrimaryImpressions Then

                    e.Cancel = True

                ElseIf Mid(_MediaFrom, 1, 1).ToUpper = "R" AndAlso Not _MediaOrderPrintSetting.PrimaryAQH Then

                    e.Cancel = True

                End If

                If Not e.Cancel AndAlso GroupFooterCycleTotalImpressions.Summary.GetResult IsNot Nothing Then

                    If GroupFooterCycleTotalImpressions.Summary.GetResult = 0 Then

                        If Mid(_MediaFrom, 1, 1).ToUpper = "R" Then

                            GroupFooterCycleTotalDisplayImpressions.Text = "0"

                        ElseIf Mid(_MediaFrom, 1, 1).ToUpper = "T" Then

                            GroupFooterCycleTotalDisplayImpressions.Text = "0.0"

                        End If

                    Else

                        If Mid(_MediaFrom, 1, 1).ToUpper = "R" Then

                            GroupFooterCycleTotalDisplayImpressions.Text = FormatNumber(GroupFooterCycleTotalImpressions.Summary.GetResult / 100, 0)

                        ElseIf Mid(_MediaFrom, 1, 1).ToUpper = "T" Then

                            GroupFooterCycleTotalDisplayImpressions.Text = FormatNumber(GroupFooterCycleTotalImpressions.Summary.GetResult / 1000, 1)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DetailPrimaryCPM_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailPrimaryCPM.BeforePrint

            If _SuppressRatings OrElse Not _MediaOrderPrintSetting.PrimaryCPM Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailPrimaryCPP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailPrimaryCPP.BeforePrint

            If _SuppressRatings OrElse Not _MediaOrderPrintSetting.PrimaryCPP.GetValueOrDefault(False) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailRating_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailRating.BeforePrint

            If _SuppressRatings OrElse _MediaOrderPrintSetting.PrimaryRatings.GetValueOrDefault(False) = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub SubBandSignatures_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubBandSignatures.BeforePrint

            If _MediaOrderPrintSetting.RemoveSignatureLines Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_LineCancelled_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_LineCancelled.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.LineCancelled.ToString) = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelPageHeaderOrderCommentLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelPageHeaderOrderCommentLabel.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.OrderHeaderComment.ToString)) OrElse
                    Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInHeader Then

                e.Cancel = True

            End If

        End Sub
        Private Sub RichTextPageHeaderOrderComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles RichTextPageHeaderOrderComment.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.OrderHeaderComment.ToString)) OrElse
                    Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.OrderHeaderCommentOption.ToString) <> AdvantageFramework.Media.MediaOrderHeaderCommentOption.PrintInHeader Then

                e.Cancel = True

            ElseIf TypeOf sender Is DevExpress.XtraReports.UI.XRRichText Then

                CType(sender, DevExpress.XtraReports.UI.XRRichText).Text = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.OrderHeaderComment.ToString)

            End If

        End Sub
        Private Sub TableCellClient_Address1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_Address1.BeforePrint

            If _MediaOrderPrintSetting.IncludeClientAddress = False OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.ClientAddress1.ToString)) Then

                TableCellClient_Address1.Text = Nothing

            End If

        End Sub
        Private Sub TableCellClient_Address2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_Address2.BeforePrint

            If _MediaOrderPrintSetting.IncludeClientAddress = False OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.ClientAddress2.ToString)) Then

                TableCellClient_Address2.Text = Nothing

            End If

        End Sub
        Private Sub TableCellClient_CityStateZip_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_CityStateZip.BeforePrint

            If _MediaOrderPrintSetting.IncludeClientAddress = False OrElse String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.BroadcastOrder.Properties.ClientCSZ.ToString)) Then

                TableCellClient_CityStateZip.Text = Nothing

            End If

        End Sub
        Private Sub TableCellClient_Address1Value_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_Address1Value.BeforePrint

            If _MediaOrderPrintSetting.IncludeClientAddress = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub TableCellClient_Address2Value_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_Address2Value.BeforePrint

            If _MediaOrderPrintSetting.IncludeClientAddress = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub TableCellClient_CityStateZipValue_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TableCellClient_CityStateZipValue.BeforePrint

            If _MediaOrderPrintSetting.IncludeClientAddress = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterLabelTotalNetWhenGross_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterLabelTotalNetWhenGross.BeforePrint

            If _MediaOrderPrintSetting.ShowTotalNetForGrossOrder = False Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

    Friend Class BroadcastCal

        Public Property brd_year As Short
        Public Property weeknum As Short
        Public Property brd_month As String
        Public Property weekdate As Date

    End Class

End Namespace
