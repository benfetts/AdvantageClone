Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.BRDCAST_IMPORT")>
    Public Class BroadcastImport
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            LinkID
            LineNumber
            RevisionNumber
            MediaType
            SalesClassCode
            ClientCode
            ProductCode
            VendorCode
            LineFlightFrom
            LineFlightTo
            HeaderFlightFrom
            HeaderFlightTo
            FlightType
            Rate
            NetRate
            GrossRate
            WeeklyNumber
            DivisionCode
            CampaignCode
            OrderDescription
            MarketCode
            StartTime
            EndTime
            TotalSpots
            CommissionPercent
            DeleteFlag
            Buyer
            ClientPO
            Length
            Programming
            Monday
            Tuesday
            Wednesday
            Thrursday
            Friday
            Saturday
            Sunday
            OrderComment
            LineComment
            ClientName
            VendorName
            MarketDescription
            MediaInterface
            PostFlag
            DeleteOrder
            ConvertImportLine
            IsPossibleDupe
            JobNumber
            JobComponentNumber
            VendorRepCode
            VendorRepCode2
            WeeklyCost
            NetGross
            VendorCrossReferenceCode
            AirDate
            BroadcastWeeks
            NetworkID
            Netcharge
            AdditionalCharge
            Date1
            Date2
            Date3
            Date4
            Date5
            Date6
            BuyMonth
            BuyYear
            RebateAmount
            RebatePercent
            MarkupPercent
            PlanIDs
            CalendarType
            DaypartCode
            EstimateNumber
            PackageName
            UserCode
            IsQuote
            ProcessStatus
            OrderCopy
            MiscInfo
            MaterialNotes
            PositionInfo
            CloseInfo
            RateInfo
            Remarks
			BuyerEmployeeCode
			AdNumber
			CableNetworkStationCode
			DaypartID
			ValueAdded
            Bookend
            VendorOrderLine
            BatchID
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _LinkID As Long = 0
        Private _LineNumber As String = Nothing
        Private _RevisionNumber As Long = 0
        Private _MediaType As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _VendorCode As String = Nothing
        Private _LineFlightFrom As DateTime = "1/1/1900"
        Private _LineFlightTo As DateTime = "1/1/1900"
        Private _HeaderFlightFrom As DateTime = "1/1/1900"
        Private _HeaderFlightTo As DateTime = "1/1/1900"
        Private _FlightType As String = Nothing
        Private _Rate As Decimal = 0
        Private _NetRate As Decimal = 0
        Private _GrossRate As Decimal = 0
        Private _WeeklyNumber As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _CampaignCode As String = Nothing
        Private _OrderDescription As String = Nothing
        Private _MarketCode As String = Nothing
        Private _StartTime As String = Nothing
        Private _EndTime As String = Nothing
        Private _TotalSpots As System.Nullable(Of Long) = Nothing
        Private _CommissionPercent As System.Nullable(Of Decimal) = Nothing
        Private _DeleteFlag As System.Nullable(Of Long) = Nothing
        Private _Buyer As String = Nothing
        Private _ClientPO As String = Nothing
        Private _Length As System.Nullable(Of Long) = Nothing
        Private _Programming As String = Nothing
        Private _Monday As System.Nullable(Of Long) = Nothing
        Private _Tuesday As System.Nullable(Of Long) = Nothing
        Private _Wednesday As System.Nullable(Of Long) = Nothing
        Private _Thrursday As System.Nullable(Of Long) = Nothing
        Private _Friday As System.Nullable(Of Long) = Nothing
        Private _Saturday As System.Nullable(Of Long) = Nothing
        Private _Sunday As System.Nullable(Of Long) = Nothing
        Private _OrderComment As String = Nothing
        Private _LineComment As String = Nothing
        Private _ClientName As String = Nothing
        Private _VendorName As String = Nothing
        Private _MarketDescription As String = Nothing
        Private _MediaInterface As String = Nothing
        Private _PostFlag As Long = 0
        Private _DeleteOrder As System.Nullable(Of Long) = Nothing
        Private _ConvertImportLine As System.Nullable(Of Long) = Nothing
        Private _IsPossibleDupe As System.Nullable(Of Long) = Nothing
        Private _JobNumber As System.Nullable(Of Long) = Nothing
        Private _JobComponentNumber As System.Nullable(Of Long) = Nothing
        Private _VendorRepCode As String = Nothing
        Private _VendorRepCode2 As String = Nothing
        Private _WeeklyCost As System.Nullable(Of Decimal) = Nothing
        Private _NetGross As System.Nullable(Of Long) = Nothing
        Private _VendorCrossReferenceCode As String = Nothing
        Private _AirDate As System.Nullable(Of DateTime) = Nothing
        Private _BroadcastWeeks As System.Nullable(Of Long) = Nothing
        Private _NetworkID As String = Nothing
        Private _Netcharge As System.Nullable(Of Decimal) = Nothing
        Private _AdditionalCharge As System.Nullable(Of Decimal) = Nothing
        Private _Date1 As System.Nullable(Of DateTime) = Nothing
        Private _Date2 As System.Nullable(Of DateTime) = Nothing
        Private _Date3 As System.Nullable(Of DateTime) = Nothing
        Private _Date4 As System.Nullable(Of DateTime) = Nothing
        Private _Date5 As System.Nullable(Of DateTime) = Nothing
        Private _Date6 As System.Nullable(Of DateTime) = Nothing
        Private _BuyMonth As System.Nullable(Of Long) = Nothing
        Private _BuyYear As System.Nullable(Of Long) = Nothing
        Private _RebateAmount As System.Nullable(Of Decimal) = Nothing
        Private _RebatePercent As System.Nullable(Of Decimal) = Nothing
        Private _MarkupPercent As System.Nullable(Of Decimal) = Nothing
        Private _PlanIDs As String = Nothing
        Private _CalendarType As String = Nothing
        Private _DaypartCode As String = Nothing
        Private _EstimateNumber As String = Nothing
        Private _PackageName As String = Nothing
        Private _UserCode As String = Nothing
        Private _IsQuote As System.Nullable(Of Long) = Nothing
        Private _ProcessStatus As System.Nullable(Of Long) = Nothing
        Private _OrderCopy As String = Nothing
        Private _MiscInfo As String = Nothing
        Private _MaterialNotes As String = Nothing
        Private _PositionInfo As String = Nothing
        Private _CloseInfo As String = Nothing
        Private _RateInfo As String = Nothing
        Private _Remarks As String = Nothing
		Private _BuyerEmployeeCode As String = Nothing
		Private _AdNumber As String = Nothing
		Private _CableNetworkStationCode As String = Nothing
		Private _DaypartID As Nullable(Of Long) = Nothing
		Private _ValueAdded As Boolean = Nothing
        Private _Bookend As Boolean = Nothing
        Private _VendorOrderLine As System.Nullable(Of Long) = Nothing
        Private _BatchID As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="RECSEQ", Storage:="_ID", DBType:="int", IsPrimaryKey:=True), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LINK_ID", Storage:="_LinkID", DBType:="int"), _
        System.ComponentModel.DisplayName("LinkID")> _
        Public Property LinkID() As Long
            Get
                LinkID = _LinkID
            End Get
            Set(ByVal value As Long)
                _LinkID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LINE_NBR", Storage:="_LineNumber", DbType:="varchar"),
		System.ComponentModel.DisplayName("LineNumber"),
		System.ComponentModel.DataAnnotations.MaxLength(8)>
		Public Property LineNumber() As String
			Get
				LineNumber = _LineNumber
			End Get
			Set(ByVal value As String)
				_LineNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="REV_NBR", Storage:="_RevisionNumber", DbType:="smallint"),
		System.ComponentModel.DisplayName("RevisionNumber")>
		Public Property RevisionNumber() As Long
			Get
				RevisionNumber = _RevisionNumber
			End Get
			Set(ByVal value As Long)
				_RevisionNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MEDIA_TYPE", Storage:="_MediaType", DbType:="varchar"),
		System.ComponentModel.DisplayName("MediaType"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property MediaType() As String
			Get
				MediaType = _MediaType
			End Get
			Set(ByVal value As String)
				_MediaType = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SALES_CLASS_CODE", Storage:="_SalesClassCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("SalesClassCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property SalesClassCode() As String
			Get
				SalesClassCode = _SalesClassCode
			End Get
			Set(ByVal value As String)
				_SalesClassCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CL_CODE", Storage:="_ClientCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("ClientCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property ClientCode() As String
			Get
				ClientCode = _ClientCode
			End Get
			Set(ByVal value As String)
				_ClientCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRD_CODE", Storage:="_ProductCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("ProductCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property ProductCode() As String
			Get
				ProductCode = _ProductCode
			End Get
			Set(ByVal value As String)
				_ProductCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VN_CODE", Storage:="_VendorCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("VendorCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property VendorCode() As String
			Get
				VendorCode = _VendorCode
			End Get
			Set(ByVal value As String)
				_VendorCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LINE_FLIGHT_FROM", Storage:="_LineFlightFrom", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("LineFlightFrom")>
		Public Property LineFlightFrom() As DateTime
			Get
				LineFlightFrom = _LineFlightFrom
			End Get
			Set(ByVal value As DateTime)
				_LineFlightFrom = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LINE_FLIGHT_TO", Storage:="_LineFlightTo", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("LineFlightTo")>
		Public Property LineFlightTo() As DateTime
			Get
				LineFlightTo = _LineFlightTo
			End Get
			Set(ByVal value As DateTime)
				_LineFlightTo = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="HDR_FLIGHT_FROM", Storage:="_HeaderFlightFrom", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("HeaderFlightFrom")>
		Public Property HeaderFlightFrom() As DateTime
			Get
				HeaderFlightFrom = _HeaderFlightFrom
			End Get
			Set(ByVal value As DateTime)
				_HeaderFlightFrom = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="HDR_FLIGHT_TO", Storage:="_HeaderFlightTo", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("HeaderFlightTo")>
		Public Property HeaderFlightTo() As DateTime
			Get
				HeaderFlightTo = _HeaderFlightTo
			End Get
			Set(ByVal value As DateTime)
				_HeaderFlightTo = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FLIGHT_TYPE", Storage:="_FlightType", DbType:="varchar"),
		System.ComponentModel.DisplayName("FlightType"),
		System.ComponentModel.DataAnnotations.MaxLength(1)>
		Public Property FlightType() As String
			Get
				FlightType = _FlightType
			End Get
			Set(ByVal value As String)
				_FlightType = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="RATE", Storage:="_Rate", DbType:="decimal"),
		System.ComponentModel.DisplayName("Rate")>
		Public Property Rate() As Decimal
			Get
				Rate = _Rate
			End Get
			Set(ByVal value As Decimal)
				_Rate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="NET_RATE", Storage:="_NetRate", DbType:="decimal"),
		System.ComponentModel.DisplayName("NetRate")>
		Public Property NetRate() As Decimal
			Get
				NetRate = _NetRate
			End Get
			Set(ByVal value As Decimal)
				_NetRate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="GROSS_RATE", Storage:="_GrossRate", DbType:="decimal"),
		System.ComponentModel.DisplayName("GrossRate")>
		Public Property GrossRate() As Decimal
			Get
				GrossRate = _GrossRate
			End Get
			Set(ByVal value As Decimal)
				_GrossRate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="P1_52", Storage:="_WeeklyNumber", DbType:="varchar"),
		System.ComponentModel.DisplayName("WeeklyNumber"),
		System.ComponentModel.DataAnnotations.MaxLength(156)>
		Public Property WeeklyNumber() As String
			Get
				WeeklyNumber = _WeeklyNumber
			End Get
			Set(ByVal value As String)
				_WeeklyNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DIV_CODE", Storage:="_DivisionCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("DivisionCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property DivisionCode() As String
			Get
				DivisionCode = _DivisionCode
			End Get
			Set(ByVal value As String)
				_DivisionCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CMP_CODE", Storage:="_CampaignCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("CampaignCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property CampaignCode() As String
			Get
				CampaignCode = _CampaignCode
			End Get
			Set(ByVal value As String)
				_CampaignCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ORDER_DESC", Storage:="_OrderDescription", DbType:="varchar"),
		System.ComponentModel.DisplayName("OrderDescription"),
		System.ComponentModel.DataAnnotations.MaxLength(40)>
		Public Property OrderDescription() As String
			Get
				OrderDescription = _OrderDescription
			End Get
			Set(ByVal value As String)
				_OrderDescription = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MARKET_CODE", Storage:="_MarketCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("MarketCode"),
		System.ComponentModel.DataAnnotations.MaxLength(10)>
		Public Property MarketCode() As String
			Get
				MarketCode = _MarketCode
			End Get
			Set(ByVal value As String)
				_MarketCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="START_TIME", Storage:="_StartTime", DbType:="varchar"),
		System.ComponentModel.DisplayName("StartTime"),
		System.ComponentModel.DataAnnotations.MaxLength(10)>
		Public Property StartTime() As String
			Get
				StartTime = _StartTime
			End Get
			Set(ByVal value As String)
				_StartTime = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="END_TIME", Storage:="_EndTime", DbType:="varchar"),
		System.ComponentModel.DisplayName("EndTime"),
		System.ComponentModel.DataAnnotations.MaxLength(10)>
		Public Property EndTime() As String
			Get
				EndTime = _EndTime
			End Get
			Set(ByVal value As String)
				_EndTime = value
			End Set
		End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TOTAL_SPOTS", Storage:="_TotalSpots", DbType:="int"),
        System.ComponentModel.DisplayName("TotalSpots")>
        Public Property TotalSpots() As System.Nullable(Of Long)
			Get
				TotalSpots = _TotalSpots
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_TotalSpots = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="COMM_PCT", Storage:="_CommissionPercent", DbType:="decimal"),
		System.ComponentModel.DisplayName("CommissionPercent")>
		Public Property CommissionPercent() As System.Nullable(Of Decimal)
			Get
				CommissionPercent = _CommissionPercent
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_CommissionPercent = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DELETE_FLAG", Storage:="_DeleteFlag", DbType:="int"),
		System.ComponentModel.DisplayName("DeleteFlag")>
		Public Property DeleteFlag() As System.Nullable(Of Long)
			Get
				DeleteFlag = _DeleteFlag
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_DeleteFlag = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="BUYER", Storage:="_Buyer", DbType:="varchar"),
		System.ComponentModel.DisplayName("Buyer"),
		System.ComponentModel.DataAnnotations.MaxLength(40)>
		Public Property Buyer() As String
			Get
				Buyer = _Buyer
			End Get
			Set(ByVal value As String)
				_Buyer = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CLIENT_PO", Storage:="_ClientPO", DbType:="varchar"),
		System.ComponentModel.DisplayName("ClientPO"),
		System.ComponentModel.DataAnnotations.MaxLength(25)>
		Public Property ClientPO() As String
			Get
				ClientPO = _ClientPO
			End Get
			Set(ByVal value As String)
				_ClientPO = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LENGTH", Storage:="_Length", DbType:="smallint"),
		System.ComponentModel.DisplayName("Length")>
		Public Property Length() As System.Nullable(Of Long)
			Get
				Length = _Length
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_Length = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PROGRAMMING", Storage:="_Programming", DbType:="varchar"),
		System.ComponentModel.DisplayName("Programming"),
		System.ComponentModel.DataAnnotations.MaxLength(50)>
		Public Property Programming() As String
			Get
				Programming = _Programming
			End Get
			Set(ByVal value As String)
				_Programming = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MONDAY", Storage:="_Monday", DbType:="smallint"),
		System.ComponentModel.DisplayName("Monday")>
		Public Property Monday() As System.Nullable(Of Long)
			Get
				Monday = _Monday
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_Monday = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TUESDAY", Storage:="_Tuesday", DbType:="smallint"),
		System.ComponentModel.DisplayName("Tuesday")>
		Public Property Tuesday() As System.Nullable(Of Long)
			Get
				Tuesday = _Tuesday
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_Tuesday = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="WEDNESDAY", Storage:="_Wednesday", DbType:="smallint"),
		System.ComponentModel.DisplayName("Wednesday")>
		Public Property Wednesday() As System.Nullable(Of Long)
			Get
				Wednesday = _Wednesday
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_Wednesday = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="THURSDAY", Storage:="_Thrursday", DbType:="smallint"),
		System.ComponentModel.DisplayName("Thrursday")>
		Public Property Thrursday() As System.Nullable(Of Long)
			Get
				Thrursday = _Thrursday
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_Thrursday = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FRIDAY", Storage:="_Friday", DbType:="smallint"),
		System.ComponentModel.DisplayName("Friday")>
		Public Property Friday() As System.Nullable(Of Long)
			Get
				Friday = _Friday
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_Friday = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SATURDAY", Storage:="_Saturday", DbType:="smallint"),
		System.ComponentModel.DisplayName("Saturday")>
		Public Property Saturday() As System.Nullable(Of Long)
			Get
				Saturday = _Saturday
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_Saturday = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SUNDAY", Storage:="_Sunday", DbType:="smallint"),
		System.ComponentModel.DisplayName("Sunday")>
		Public Property Sunday() As System.Nullable(Of Long)
			Get
				Sunday = _Sunday
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_Sunday = value
			End Set
		End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ORDER_COMMENT", Storage:="_OrderComment", DbType:="varchar"),
        System.ComponentModel.DisplayName("OrderComment")>
        Public Property OrderComment() As String
            Get
                OrderComment = _OrderComment
            End Get
            Set(ByVal value As String)
				_OrderComment = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LINE_COMMENT", Storage:="_LineComment", DbType:="varchar"),
		System.ComponentModel.DisplayName("LineComment"),
		System.ComponentModel.DataAnnotations.MaxLength(254)>
		Public Property LineComment() As String
			Get
				LineComment = _LineComment
			End Get
			Set(ByVal value As String)
				_LineComment = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CL_NAME", Storage:="_ClientName", DbType:="varchar"),
		System.ComponentModel.DisplayName("ClientName"),
		System.ComponentModel.DataAnnotations.MaxLength(40)>
		Public Property ClientName() As String
			Get
				ClientName = _ClientName
			End Get
			Set(ByVal value As String)
				_ClientName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VN_NAME", Storage:="_VendorName", DbType:="varchar"),
		System.ComponentModel.DisplayName("VendorName"),
		System.ComponentModel.DataAnnotations.MaxLength(40)>
		Public Property VendorName() As String
			Get
				VendorName = _VendorName
			End Get
			Set(ByVal value As String)
				_VendorName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MARKET_DESC", Storage:="_MarketDescription", DbType:="varchar"),
		System.ComponentModel.DisplayName("MarketDescription"),
		System.ComponentModel.DataAnnotations.MaxLength(40)>
		Public Property MarketDescription() As String
			Get
				MarketDescription = _MarketDescription
			End Get
			Set(ByVal value As String)
				_MarketDescription = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MEDIA_INTERFACE", Storage:="_MediaInterface", DbType:="varchar"),
		System.ComponentModel.DisplayName("MediaInterface"),
		System.ComponentModel.DataAnnotations.MaxLength(2)>
		Public Property MediaInterface() As String
			Get
				MediaInterface = _MediaInterface
			End Get
			Set(ByVal value As String)
				_MediaInterface = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="POST_FLAG", Storage:="_PostFlag", DbType:="smallint"),
		System.ComponentModel.DisplayName("PostFlag")>
		Public Property PostFlag() As Long
			Get
				PostFlag = _PostFlag
			End Get
			Set(ByVal value As Long)
				_PostFlag = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DELETE_ORDER", Storage:="_DeleteOrder", DbType:="smallint"),
		System.ComponentModel.DisplayName("DeleteOrder")>
		Public Property DeleteOrder() As System.Nullable(Of Long)
			Get
				DeleteOrder = _DeleteOrder
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_DeleteOrder = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CNVT_IMPRT_LINE", Storage:="_ConvertImportLine", DbType:="smallint"),
		System.ComponentModel.DisplayName("ConvertImportLine")>
		Public Property ConvertImportLine() As System.Nullable(Of Long)
			Get
				ConvertImportLine = _ConvertImportLine
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_ConvertImportLine = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="POSSIBLE_DUPE", Storage:="_IsPossibleDupe", DbType:="smallint"),
		System.ComponentModel.DisplayName("IsPossibleDupe")>
		Public Property IsPossibleDupe() As System.Nullable(Of Long)
			Get
				IsPossibleDupe = _IsPossibleDupe
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_IsPossibleDupe = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_NUMBER", Storage:="_JobNumber", DbType:="int"),
		System.ComponentModel.DisplayName("JobNumber")>
		Public Property JobNumber() As System.Nullable(Of Long)
			Get
				JobNumber = _JobNumber
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_JobNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_COMPONENT_NBR", Storage:="_JobComponentNumber", DbType:="smallint"),
		System.ComponentModel.DisplayName("JobComponentNumber")>
		Public Property JobComponentNumber() As System.Nullable(Of Long)
			Get
				JobComponentNumber = _JobComponentNumber
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_JobComponentNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_CODE", Storage:="_VendorRepCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("VendorRepCode"),
		System.ComponentModel.DataAnnotations.MaxLength(4)>
		Public Property VendorRepCode() As String
			Get
				VendorRepCode = _VendorRepCode
			End Get
			Set(ByVal value As String)
				_VendorRepCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_CODE2", Storage:="_VendorRepCode2", DbType:="varchar"),
		System.ComponentModel.DisplayName("VendorRepCode2"),
		System.ComponentModel.DataAnnotations.MaxLength(4)>
		Public Property VendorRepCode2() As String
			Get
				VendorRepCode2 = _VendorRepCode2
			End Get
			Set(ByVal value As String)
				_VendorRepCode2 = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="WEEKLY_COST", Storage:="_WeeklyCost", DbType:="decimal"),
		System.ComponentModel.DisplayName("WeeklyCost")>
		Public Property WeeklyCost() As System.Nullable(Of Decimal)
			Get
				WeeklyCost = _WeeklyCost
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_WeeklyCost = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="NET_GROSS_FLAG", Storage:="_NetGross", DbType:="smallint"),
		System.ComponentModel.DisplayName("NetGross")>
		Public Property NetGross() As System.Nullable(Of Long)
			Get
				NetGross = _NetGross
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_NetGross = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VN_CODE_XREF", Storage:="_VendorCrossReferenceCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("VendorCrossReferenceCode"),
		System.ComponentModel.DataAnnotations.MaxLength(12)>
		Public Property VendorCrossReferenceCode() As String
			Get
				VendorCrossReferenceCode = _VendorCrossReferenceCode
			End Get
			Set(ByVal value As String)
				_VendorCrossReferenceCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AIR_DATE", Storage:="_AirDate", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("AirDate")>
		Public Property AirDate() As System.Nullable(Of DateTime)
			Get
				AirDate = _AirDate
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_AirDate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="BC_WEEKS", Storage:="_BroadcastWeeks", DbType:="smallint"),
		System.ComponentModel.DisplayName("BroadcastWeeks")>
		Public Property BroadcastWeeks() As System.Nullable(Of Long)
			Get
				BroadcastWeeks = _BroadcastWeeks
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_BroadcastWeeks = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="NETWORK_ID", Storage:="_NetworkID", DbType:="varchar"),
		System.ComponentModel.DisplayName("NetworkID"),
		System.ComponentModel.DataAnnotations.MaxLength(10)>
		Public Property NetworkID() As String
			Get
				NetworkID = _NetworkID
			End Get
			Set(ByVal value As String)
				_NetworkID = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="NETCHARGE", Storage:="_Netcharge", DbType:="decimal"),
		System.ComponentModel.DisplayName("Netcharge")>
		Public Property Netcharge() As System.Nullable(Of Decimal)
			Get
				Netcharge = _Netcharge
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_Netcharge = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ADDL_CHARGE", Storage:="_AdditionalCharge", DbType:="decimal"),
		System.ComponentModel.DisplayName("AdditionalCharge")>
		Public Property AdditionalCharge() As System.Nullable(Of Decimal)
			Get
				AdditionalCharge = _AdditionalCharge
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_AdditionalCharge = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DATE1", Storage:="_Date1", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("Date1")>
		Public Property Date1() As System.Nullable(Of DateTime)
			Get
				Date1 = _Date1
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_Date1 = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DATE2", Storage:="_Date2", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("Date2")>
		Public Property Date2() As System.Nullable(Of DateTime)
			Get
				Date2 = _Date2
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_Date2 = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DATE3", Storage:="_Date3", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("Date3")>
		Public Property Date3() As System.Nullable(Of DateTime)
			Get
				Date3 = _Date3
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_Date3 = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DATE4", Storage:="_Date4", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("Date4")>
		Public Property Date4() As System.Nullable(Of DateTime)
			Get
				Date4 = _Date4
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_Date4 = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DATE5", Storage:="_Date5", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("Date5")>
		Public Property Date5() As System.Nullable(Of DateTime)
			Get
				Date5 = _Date5
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_Date5 = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DATE6", Storage:="_Date6", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("Date6")>
		Public Property Date6() As System.Nullable(Of DateTime)
			Get
				Date6 = _Date6
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_Date6 = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="BUY_MONTH", Storage:="_BuyMonth", DbType:="smallint"),
		System.ComponentModel.DisplayName("BuyMonth")>
		Public Property BuyMonth() As System.Nullable(Of Long)
			Get
				BuyMonth = _BuyMonth
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_BuyMonth = value
			End Set
		End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="BUY_YEAR", Storage:="_BuyYear", DbType:="smallint"),
        System.ComponentModel.DisplayName("BuyYear")>
        Public Property BuyYear() As System.Nullable(Of Long)
            Get
                BuyYear = _BuyYear
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _BuyYear = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="REBATE_PCT", Storage:="_RebatePercent", DbType:="decimal"),
        System.ComponentModel.DisplayName("RebatePercent")>
        Public Property RebatePercent() As System.Nullable(Of Decimal)
            Get
                RebatePercent = _RebatePercent
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _RebatePercent = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="REBATE_AMT", Storage:="_RebateAmount", DbType:="decimal"),
        System.ComponentModel.DisplayName("RebateAmount")>
        Public Property RebateAmount() As System.Nullable(Of Decimal)
            Get
                RebateAmount = _RebateAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _RebateAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MARKUP_PCT", Storage:="_MarkupPercent", DbType:="decimal"),
		System.ComponentModel.DisplayName("MarkupPercent")>
		Public Property MarkupPercent() As System.Nullable(Of Decimal)
			Get
				MarkupPercent = _MarkupPercent
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_MarkupPercent = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PLAN_IDS", Storage:="_PlanIDs", DbType:="varchar"),
		System.ComponentModel.DisplayName("PlanIDs")>
		Public Property PlanIDs() As String
			Get
				PlanIDs = _PlanIDs
			End Get
			Set(ByVal value As String)
				_PlanIDs = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CAL_TYPE", Storage:="_CalendarType", DbType:="varchar"),
		System.ComponentModel.DisplayName("CalendarType"),
		System.ComponentModel.DataAnnotations.MaxLength(2)>
		Public Property CalendarType() As String
			Get
				CalendarType = _CalendarType
			End Get
			Set(ByVal value As String)
				_CalendarType = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DAYPART_CODE", Storage:="_DaypartCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("DaypartCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property DaypartCode() As String
			Get
				DaypartCode = _DaypartCode
			End Get
			Set(ByVal value As String)
				_DaypartCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ESTIMATE_NBR", Storage:="_EstimateNumber", DbType:="varchar"),
		System.ComponentModel.DisplayName("EstimateNumber"),
		System.ComponentModel.DataAnnotations.MaxLength(30)>
		Public Property EstimateNumber() As String
			Get
				EstimateNumber = _EstimateNumber
			End Get
			Set(ByVal value As String)
				_EstimateNumber = value
			End Set
		End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PACKAGE_NAME", Storage:="_PackageName", DbType:="varchar"),
        System.ComponentModel.DisplayName("PackageName"),
        System.ComponentModel.DataAnnotations.MaxLength(50)>
        Public Property PackageName() As String
            Get
                PackageName = _PackageName
            End Get
            Set(ByVal value As String)
                _PackageName = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="REMARKS", Storage:="_Remarks", DbType:="varchar"),
        System.ComponentModel.DisplayName("Remarks")>
        Public Property Remarks() As String
            Get
                Remarks = _Remarks
            End Get
            Set(ByVal value As String)
                _Remarks = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="USER_ID", Storage:="_UserCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("UserCode"),
		System.ComponentModel.DataAnnotations.MaxLength(100)>
		Public Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
            Set(ByVal value As String)
                _UserCode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IS_QUOTE", Storage:="_IsQuote", DBType:="smallint"), _
        System.ComponentModel.DisplayName("IsQuote")> _
        Public Property IsQuote() As System.Nullable(Of Long)
            Get
                IsQuote = _IsQuote
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _IsQuote = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRC_STATUS", Storage:="_ProcessStatus", DBType:="smallint"), _
        System.ComponentModel.DisplayName("ProcessStatus")> _
        Public Property ProcessStatus() As System.Nullable(Of Long)
            Get
                ProcessStatus = _ProcessStatus
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _ProcessStatus = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ORDER_COPY", Storage:="_OrderCopy", DBType:="text"), _
        System.ComponentModel.DisplayName("OrderCopy")> _
        Public Property OrderCopy() As String
            Get
                OrderCopy = _OrderCopy
            End Get
            Set(ByVal value As String)
                _OrderCopy = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MISC_INFO", Storage:="_MiscInfo", DBType:="text"), _
        System.ComponentModel.DisplayName("MiscInfo")> _
        Public Property MiscInfo() As String
            Get
                MiscInfo = _MiscInfo
            End Get
            Set(ByVal value As String)
                _MiscInfo = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MATL_NOTES", Storage:="_MaterialNotes", DBType:="text"), _
        System.ComponentModel.DisplayName("MaterialNotes")> _
        Public Property MaterialNotes() As String
            Get
                MaterialNotes = _MaterialNotes
            End Get
            Set(ByVal value As String)
                _MaterialNotes = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="POSITION_INFO", Storage:="_PositionInfo", DBType:="text"), _
        System.ComponentModel.DisplayName("PositionInfo")> _
        Public Property PositionInfo() As String
            Get
                PositionInfo = _PositionInfo
            End Get
            Set(ByVal value As String)
                _PositionInfo = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CLOSE_INFO", Storage:="_CloseInfo", DBType:="text"), _
        System.ComponentModel.DisplayName("CloseInfo")> _
        Public Property CloseInfo() As String
            Get
                CloseInfo = _CloseInfo
            End Get
            Set(ByVal value As String)
                _CloseInfo = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="RATE_INFO", Storage:="_RateInfo", DBType:="text"),
        System.ComponentModel.DisplayName("RateInfo")>
        Public Property RateInfo() As String
            Get
                RateInfo = _RateInfo
            End Get
            Set(ByVal value As String)
                _RateInfo = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AD_NBR", Storage:="_AdNumber", DbType:="varchar"),
        System.ComponentModel.DisplayName("AdNumber"),
        System.ComponentModel.DataAnnotations.MaxLength(30)>
        Public Property AdNumber() As String
            Get
                AdNumber = _AdNumber
            End Get
            Set(ByVal value As String)
                _AdNumber = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="BUYER_EMP_CODE", Storage:="_BuyerEmployeeCode", DbType:="varchar"),
        System.ComponentModel.DisplayName("BuyerEmployeeCode"),
        System.ComponentModel.DataAnnotations.MaxLength(6)>
        Public Property BuyerEmployeeCode() As String
            Get
                BuyerEmployeeCode = _BuyerEmployeeCode
            End Get
            Set(ByVal value As String)
                _BuyerEmployeeCode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CABLE_NETWORK_STATION_CODE", Storage:="_CableNetworkStationCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("Cable Network Station")>
		Public Property CableNetworkStationCode() As String
			Get
				CableNetworkStationCode = _CableNetworkStationCode
			End Get
			Set(ByVal value As String)
				_CableNetworkStationCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DAY_PART_ID", Storage:="_DaypartID", DbType:="int"),
		System.ComponentModel.DisplayName("Daypart")>
		Public Property DaypartID() As System.Nullable(Of Long)
			Get
				DaypartID = _DaypartID
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_DaypartID = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ADDED_VALUE", Storage:="_ValueAdded", DbType:="bit", CanBeNull:=False),
		System.ComponentModel.DisplayName("Value Added")>
		Public Property ValueAdded() As Boolean
			Get
				ValueAdded = _ValueAdded
			End Get
			Set(ByVal value As Boolean)
				_ValueAdded = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="BOOKEND", Storage:="_Bookend", DbType:="bit", CanBeNull:=False),
		System.ComponentModel.DisplayName("Bookend")>
		Public Property Bookend() As Boolean
			Get
				Bookend = _Bookend
			End Get
			Set(ByVal value As Boolean)
				_Bookend = value
			End Set
		End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VENDOR_ORDER_LINE", Storage:="_VendorOrderLine", DbType:="int"),
        System.ComponentModel.DisplayName("VendorOrderLine")>
        Public Property VendorOrderLine() As System.Nullable(Of Long)
            Get
                VendorOrderLine = _VendorOrderLine
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _VendorOrderLine = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="BATCH_ID", Storage:="_BatchID", DbType:="varchar"),
        System.ComponentModel.DisplayName("Batch ID")>
        Public Property BatchID() As String
            Get
                BatchID = _BatchID
            End Get
            Set(ByVal value As String)
                _BatchID = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
