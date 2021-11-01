Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.PRINT_ORDER")>
    Public Class PrintOrder
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            AccountOrderNumber
            ItemNumber
            MediaType
            Trade
            RevisionNumber
            AdvertiserName
            AdvertiserCode
            CampaignDescription
            CampaignCode
            ProductCode
            BrandCode
            VendorName
            VendorCode
            InsertDate
            AdSize
            RatePer
            PreviousRatePer
            InsertStatus
            Caption
            POSRequest
            MaterialCloseDate
            EstimateNumber
            AgencyNetRate
            SpaceCloseDate
            Buyer
            OrderDescription
            OrderComment
            MediaInterface
            InterfaceSequenceNumber
            ClientPO
            ImportYear
            SectionIssue
            Zone
            Location
            LineComment
            SalesClassCode
            PostFlag
            PremiumCharges
            FlatNetCharge
            FlatAdditionalCharge
            FlatDiscountAmount
            ModifiedComments
            RevisedFlag
            DeleteOrder
            JobNumber
            JobComponentNumber
            MarketCode
            MarketDescription
            VendorRepresentativeCode
            VendorRepresentativeCode2
            BuyerName
            EndDate
            SizeCode
            AdNumber
            AdNumberDescription
            URL
            CreativeSize
            Placement2
            InternetType
            CostType
            ProjectedImpressions
            GuaranteedImpressions
            ActiveImpressions
            CostRate
            ProductionSize
            Material
            RateType
            OutdoorType
            PrintColumns
            PrintInches
            PrintLines
            VenderCodeCrossRefrence
            NetBaseRate
            GrossBaseRate
            NetRate
            GrossRate
            MarkupPercent
            RebatePercent
            RebateAmount
			PlanIDs
			OrderCopy
			MaterialNotes
			PositionInfo
			CloseInfo
			RateInfo
			MiscInfo
            UserCode
			BuyerEmployeeCode
            Units
            LineMarketCode
            Circulation
            MediaChannelID
            MediaTacticID
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _AccountOrderNumber As Long = 0
        Private _ItemNumber As String = Nothing
        Private _MediaType As String = Nothing
        Private _Trade As System.Nullable(Of Long) = Nothing
        Private _RevisionNumber As Long = 0
        Private _AdvertiserName As String = Nothing
        Private _AdvertiserCode As String = Nothing
        Private _CampaignDescription As String = Nothing
        Private _CampaignCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _BrandCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _VendorCode As String = Nothing
        Private _InsertDate As DateTime = "1/1/1900"
        Private _AdSize As String = Nothing
        Private _RatePer As System.Nullable(Of Decimal) = Nothing
        Private _PreviousRatePer As System.Nullable(Of Decimal) = Nothing
        Private _InsertStatus As String = Nothing
        Private _Caption As String = Nothing
        Private _POSRequest As String = Nothing
        Private _MaterialCloseDate As System.Nullable(Of DateTime) = Nothing
        Private _EstimateNumber As String = Nothing
        Private _AgencyNetRate As System.Nullable(Of Decimal) = 0
        Private _SpaceCloseDate As System.Nullable(Of DateTime) = Nothing
        Private _Buyer As String = Nothing
        Private _OrderDescription As String = Nothing
        Private _OrderComment As String = Nothing
        Private _MediaInterface As String = Nothing
        Private _InterfaceSequenceNumber As System.Nullable(Of Long) = Nothing
        Private _ClientPO As String = Nothing
        Private _ImportYear As System.Nullable(Of Long) = Nothing
        Private _SectionIssue As String = Nothing
        Private _Zone As String = Nothing
        Private _Location As String = Nothing
        Private _LineComment As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _PostFlag As Long = 0
        Private _PremiumCharges As System.Nullable(Of Decimal) = Nothing
        Private _FlatNetCharge As System.Nullable(Of Decimal) = Nothing
        Private _FlatAdditionalCharge As System.Nullable(Of Decimal) = Nothing
        Private _FlatDiscountAmount As System.Nullable(Of Decimal) = Nothing
        Private _ModifiedComments As String = Nothing
        Private _RevisedFlag As System.Nullable(Of Long) = Nothing
        Private _DeleteOrder As System.Nullable(Of Long) = Nothing
        Private _JobNumber As System.Nullable(Of Long) = Nothing
        Private _JobComponentNumber As System.Nullable(Of Long) = Nothing
        Private _MarketCode As String = Nothing
        Private _MarketDescription As String = Nothing
        Private _VendorRepresentativeCode As String = Nothing
        Private _VendorRepresentativeCode2 As String = Nothing
        Private _BuyerName As String = Nothing
        Private _EndDate As System.Nullable(Of DateTime) = Nothing
        Private _SizeCode As String = Nothing
        Private _AdNumber As String = Nothing
        Private _AdNumberDescription As String = Nothing
        Private _URL As String = Nothing
        Private _CreativeSize As String = Nothing
        Private _Placement2 As String = Nothing
        Private _InternetType As String = Nothing
        Private _CostType As String = Nothing
        Private _ProjectedImpressions As System.Nullable(Of Long) = Nothing
        Private _GuaranteedImpressions As System.Nullable(Of Long) = Nothing
        Private _ActiveImpressions As System.Nullable(Of Long) = Nothing
        Private _CostRate As System.Nullable(Of Decimal) = Nothing
        Private _ProductionSize As String = Nothing
        Private _Material As String = Nothing
        Private _RateType As String = Nothing
        Private _OutdoorType As String = Nothing
        Private _PrintColumns As System.Nullable(Of Decimal) = Nothing
        Private _PrintInches As System.Nullable(Of Decimal) = Nothing
        Private _PrintLines As System.Nullable(Of Decimal) = Nothing
        Private _VenderCodeCrossRefrence As String = Nothing
        Private _NetBaseRate As System.Nullable(Of Decimal) = Nothing
        Private _GrossBaseRate As System.Nullable(Of Decimal) = Nothing
        Private _NetRate As System.Nullable(Of Decimal) = Nothing
        Private _GrossRate As System.Nullable(Of Decimal) = Nothing
        Private _MarkupPercent As System.Nullable(Of Decimal) = Nothing
        Private _RebatePercent As System.Nullable(Of Decimal) = Nothing
        Private _RebateAmount As System.Nullable(Of Decimal) = Nothing
        Private _PlanIDs As String = Nothing
        Private _OrderCopy As String = Nothing
        Private _MaterialNotes As String = Nothing
        Private _PositionInfo As String = Nothing
        Private _CloseInfo As String = Nothing
        Private _RateInfo As String = Nothing
		Private _MiscInfo As String = Nothing
		Private _UserCode As String = Nothing
		Private _BuyerEmployeeCode As String = Nothing
		Private _Units As String = Nothing
        Private _LineMarketCode As String = Nothing
        Private _Circulation As System.Nullable(Of Long) = Nothing
        Private _MediaChannelID As System.Nullable(Of Long) = Nothing
        Private _MediaTacticID As System.Nullable(Of Long) = Nothing

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
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ACCT_ORD_NBR", Storage:="_AccountOrderNumber", DBType:="int"), _
        System.ComponentModel.DisplayName("AccountOrderNumber")> _
        Public Property AccountOrderNumber() As Long
            Get
                AccountOrderNumber = _AccountOrderNumber
            End Get
            Set(ByVal value As Long)
                _AccountOrderNumber = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ITEM_NBR", Storage:="_ItemNumber", DbType:="varchar"),
		System.ComponentModel.DisplayName("ItemNumber"),
		System.ComponentModel.DataAnnotations.MaxLength(4)>
		Public Property ItemNumber() As String
			Get
				ItemNumber = _ItemNumber
			End Get
			Set(ByVal value As String)
				_ItemNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MEDIA_TYPE", Storage:="_MediaType", DbType:="varchar"),
		System.ComponentModel.DisplayName("MediaType"),
		System.ComponentModel.DataAnnotations.MaxLength(3)>
		Public Property MediaType() As String
			Get
				MediaType = _MediaType
			End Get
			Set(ByVal value As String)
				_MediaType = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TRADE", Storage:="_Trade", DbType:="int"),
		System.ComponentModel.DisplayName("Trade")>
		Public Property Trade() As System.Nullable(Of Long)
			Get
				Trade = _Trade
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_Trade = value
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
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ADVERTISER_NAME", Storage:="_AdvertiserName", DbType:="varchar"),
		System.ComponentModel.DisplayName("AdvertiserName"),
		System.ComponentModel.DataAnnotations.MaxLength(30)>
		Public Property AdvertiserName() As String
			Get
				AdvertiserName = _AdvertiserName
			End Get
			Set(ByVal value As String)
				_AdvertiserName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ADVERTISER_CODE", Storage:="_AdvertiserCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("AdvertiserCode"),
		System.ComponentModel.DataAnnotations.MaxLength(20)>
		Public Property AdvertiserCode() As String
			Get
				AdvertiserCode = _AdvertiserCode
			End Get
			Set(ByVal value As String)
				_AdvertiserCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CAMP_DESC", Storage:="_CampaignDescription", DbType:="varchar"),
		System.ComponentModel.DisplayName("CampaignDescription"),
		System.ComponentModel.DataAnnotations.MaxLength(20)>
		Public Property CampaignDescription() As String
			Get
				CampaignDescription = _CampaignDescription
			End Get
			Set(ByVal value As String)
				_CampaignDescription = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CAMP_CODE", Storage:="_CampaignCode", DbType:="varchar"),
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
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PROD_CODE", Storage:="_ProductCode", DbType:="varchar"),
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
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="BRAND_CODE", Storage:="_BrandCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("BrandCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property BrandCode() As String
			Get
				BrandCode = _BrandCode
			End Get
			Set(ByVal value As String)
				_BrandCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VENDOR_NAME", Storage:="_VendorName", DbType:="varchar"),
		System.ComponentModel.DisplayName("VendorName"),
		System.ComponentModel.DataAnnotations.MaxLength(48)>
		Public Property VendorName() As String
			Get
				VendorName = _VendorName
			End Get
			Set(ByVal value As String)
				_VendorName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VENDOR_CODE", Storage:="_VendorCode", DbType:="varchar"),
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
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="INSERT_DATE", Storage:="_InsertDate", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("InsertDate")>
		Public Property InsertDate() As DateTime
			Get
				InsertDate = _InsertDate
			End Get
			Set(ByVal value As DateTime)
				_InsertDate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AD_SIZE", Storage:="_AdSize", DbType:="varchar"),
		System.ComponentModel.DisplayName("AdSize"),
		System.ComponentModel.DataAnnotations.MaxLength(66)>
		Public Property AdSize() As String
			Get
				AdSize = _AdSize
			End Get
			Set(ByVal value As String)
				_AdSize = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="RATE_PER", Storage:="_RatePer", DbType:="decimal"),
		System.ComponentModel.DisplayName("RatePer")>
		Public Property RatePer() As System.Nullable(Of Decimal)
			Get
				RatePer = _RatePer
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_RatePer = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PREV_RATE_PER", Storage:="_PreviousRatePer", DbType:="decimal"),
		System.ComponentModel.DisplayName("PreviousRatePer")>
		Public Property PreviousRatePer() As System.Nullable(Of Decimal)
			Get
				PreviousRatePer = _PreviousRatePer
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_PreviousRatePer = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="INSERT_STATUS", Storage:="_InsertStatus", DbType:="varchar"),
		System.ComponentModel.DisplayName("InsertStatus"),
		System.ComponentModel.DataAnnotations.MaxLength(1)>
		Public Property InsertStatus() As String
			Get
				InsertStatus = _InsertStatus
			End Get
			Set(ByVal value As String)
				_InsertStatus = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CAPTION", Storage:="_Caption", DbType:="varchar"),
		System.ComponentModel.DisplayName("Caption"),
		System.ComponentModel.DataAnnotations.MaxLength(60)>
		Public Property Caption() As String
			Get
				Caption = _Caption
			End Get
			Set(ByVal value As String)
				_Caption = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="POS_REQUEST", Storage:="_POSRequest", DbType:="varchar"),
		System.ComponentModel.DisplayName("POSRequest"),
		System.ComponentModel.DataAnnotations.MaxLength(50)>
		Public Property POSRequest() As String
			Get
				POSRequest = _POSRequest
			End Get
			Set(ByVal value As String)
				_POSRequest = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MAT_CLOSE_DATE", Storage:="_MaterialCloseDate", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("MaterialCloseDate")>
		Public Property MaterialCloseDate() As System.Nullable(Of DateTime)
			Get
				MaterialCloseDate = _MaterialCloseDate
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_MaterialCloseDate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ESTIMATE_NUMBER", Storage:="_EstimateNumber", DbType:="varchar"),
		System.ComponentModel.DisplayName("EstimateNumber"),
		System.ComponentModel.DataAnnotations.MaxLength(16)>
		Public Property EstimateNumber() As String
			Get
				EstimateNumber = _EstimateNumber
			End Get
			Set(ByVal value As String)
				_EstimateNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGENCY_NET_RATE", Storage:="_AgencyNetRate", DbType:="decimal"),
		System.ComponentModel.DisplayName("AgencyNetRate")>
		Public Property AgencyNetRate() As System.Nullable(Of Decimal)
			Get
				AgencyNetRate = _AgencyNetRate
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_AgencyNetRate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SPACE_CLOSE_DATE", Storage:="_SpaceCloseDate", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("SpaceCloseDate")>
		Public Property SpaceCloseDate() As System.Nullable(Of DateTime)
			Get
				SpaceCloseDate = _SpaceCloseDate
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_SpaceCloseDate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="BUYER", Storage:="_Buyer", DbType:="varchar"),
		System.ComponentModel.DisplayName("Buyer"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property Buyer() As String
			Get
				Buyer = _Buyer
			End Get
			Set(ByVal value As String)
				_Buyer = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ORDER_DESC", Storage:="_OrderDescription", DbType:="varchar"),
		System.ComponentModel.DisplayName("OrderDescription"),
		System.ComponentModel.DataAnnotations.MaxLength(50)>
		Public Property OrderDescription() As String
			Get
				OrderDescription = _OrderDescription
			End Get
			Set(ByVal value As String)
				_OrderDescription = value
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
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="INTERFACE_SEQ_NBR", Storage:="_InterfaceSequenceNumber", DbType:="int"),
		System.ComponentModel.DisplayName("InterfaceSequenceNumber")>
		Public Property InterfaceSequenceNumber() As System.Nullable(Of Long)
			Get
				InterfaceSequenceNumber = _InterfaceSequenceNumber
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_InterfaceSequenceNumber = value
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
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IMPORT_YEAR", Storage:="_ImportYear", DbType:="smallint"),
		System.ComponentModel.DisplayName("ImportYear")>
		Public Property ImportYear() As System.Nullable(Of Long)
			Get
				ImportYear = _ImportYear
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_ImportYear = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SECTION_ISSUE", Storage:="_SectionIssue", DbType:="varchar"),
		System.ComponentModel.DisplayName("SectionIssue"),
		System.ComponentModel.DataAnnotations.MaxLength(50)>
		Public Property SectionIssue() As String
			Get
				SectionIssue = _SectionIssue
			End Get
			Set(ByVal value As String)
				_SectionIssue = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ZONE", Storage:="_Zone", DbType:="varchar"),
		System.ComponentModel.DisplayName("Zone"),
		System.ComponentModel.DataAnnotations.MaxLength(60)>
		Public Property Zone() As String
			Get
				Zone = _Zone
			End Get
			Set(ByVal value As String)
				_Zone = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LOCATION", Storage:="_Location", DbType:="varchar"),
		System.ComponentModel.DisplayName("Location"),
		System.ComponentModel.DataAnnotations.MaxLength(254)>
		Public Property Location() As String
			Get
				Location = _Location
			End Get
			Set(ByVal value As String)
				_Location = value
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
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PREMIUM_CHGS", Storage:="_PremiumCharges", DbType:="decimal"),
		System.ComponentModel.DisplayName("PremiumCharges")>
		Public Property PremiumCharges() As System.Nullable(Of Decimal)
			Get
				PremiumCharges = _PremiumCharges
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_PremiumCharges = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FLAT_NETCHARGE", Storage:="_FlatNetCharge", DbType:="decimal"),
		System.ComponentModel.DisplayName("FlatNetCharge")>
		Public Property FlatNetCharge() As System.Nullable(Of Decimal)
			Get
				FlatNetCharge = _FlatNetCharge
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_FlatNetCharge = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FLAT_ADDL_CHARGE", Storage:="_FlatAdditionalCharge", DbType:="decimal"),
		System.ComponentModel.DisplayName("FlatAdditionalCharge")>
		Public Property FlatAdditionalCharge() As System.Nullable(Of Decimal)
			Get
				FlatAdditionalCharge = _FlatAdditionalCharge
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_FlatAdditionalCharge = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FLAT_DISCOUNT_AMT", Storage:="_FlatDiscountAmount", DbType:="decimal"),
		System.ComponentModel.DisplayName("FlatDiscountAmount")>
		Public Property FlatDiscountAmount() As System.Nullable(Of Decimal)
			Get
				FlatDiscountAmount = _FlatDiscountAmount
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_FlatDiscountAmount = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MODIFIED_COMMENTS", Storage:="_ModifiedComments", DbType:="text"),
		System.ComponentModel.DisplayName("ModifiedComments")>
		Public Property ModifiedComments() As String
			Get
				ModifiedComments = _ModifiedComments
			End Get
			Set(ByVal value As String)
				_ModifiedComments = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="REVISED_FLAG", Storage:="_RevisedFlag", DbType:="smallint"),
		System.ComponentModel.DisplayName("RevisedFlag")>
		Public Property RevisedFlag() As System.Nullable(Of Long)
			Get
				RevisedFlag = _RevisedFlag
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_RevisedFlag = value
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
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_CODE", Storage:="_VendorRepresentativeCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("VendorRepresentativeCode"),
		System.ComponentModel.DataAnnotations.MaxLength(4)>
		Public Property VendorRepresentativeCode() As String
			Get
				VendorRepresentativeCode = _VendorRepresentativeCode
			End Get
			Set(ByVal value As String)
				_VendorRepresentativeCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_CODE2", Storage:="_VendorRepresentativeCode2", DbType:="varchar"),
		System.ComponentModel.DisplayName("VendorRepresentativeCode2"),
		System.ComponentModel.DataAnnotations.MaxLength(4)>
		Public Property VendorRepresentativeCode2() As String
			Get
				VendorRepresentativeCode2 = _VendorRepresentativeCode2
			End Get
			Set(ByVal value As String)
				_VendorRepresentativeCode2 = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="BUYER_NAME", Storage:="_BuyerName", DbType:="varchar"),
		System.ComponentModel.DisplayName("BuyerName"),
		System.ComponentModel.DataAnnotations.MaxLength(40)>
		Public Property BuyerName() As String
			Get
				BuyerName = _BuyerName
			End Get
			Set(ByVal value As String)
				_BuyerName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="END_DATE", Storage:="_EndDate", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("EndDate")>
		Public Property EndDate() As System.Nullable(Of DateTime)
			Get
				EndDate = _EndDate
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_EndDate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SIZE_CODE", Storage:="_SizeCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("SizeCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property SizeCode() As String
			Get
				SizeCode = _SizeCode
			End Get
			Set(ByVal value As String)
				_SizeCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AD_NUMBER", Storage:="_AdNumber", DbType:="varchar"),
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
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AD_NUMBER_DESC", Storage:="_AdNumberDescription", DbType:="varchar"),
		System.ComponentModel.DisplayName("AdNumberDescription"),
		System.ComponentModel.DataAnnotations.MaxLength(60)>
		Public Property AdNumberDescription() As String
			Get
				AdNumberDescription = _AdNumberDescription
			End Get
			Set(ByVal value As String)
				_AdNumberDescription = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="URL", Storage:="_URL", DbType:="varchar"),
		System.ComponentModel.DisplayName("URL"),
		System.ComponentModel.DataAnnotations.MaxLength(60)>
		Public Property URL() As String
			Get
				URL = _URL
			End Get
			Set(ByVal value As String)
				_URL = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CREATIVE_SIZE", Storage:="_CreativeSize", DbType:="varchar"),
		System.ComponentModel.DisplayName("CreativeSize"),
		System.ComponentModel.DataAnnotations.MaxLength(60)>
		Public Property CreativeSize() As String
			Get
				CreativeSize = _CreativeSize
			End Get
			Set(ByVal value As String)
				_CreativeSize = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PLACEMENT_2", Storage:="_Placement2", DbType:="varchar"),
		System.ComponentModel.DisplayName("Placement2"),
		System.ComponentModel.DataAnnotations.MaxLength(160)>
		Public Property Placement2() As String
			Get
				Placement2 = _Placement2
			End Get
			Set(ByVal value As String)
				_Placement2 = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="INTERNET_TYPE", Storage:="_InternetType", DbType:="varchar"),
		System.ComponentModel.DisplayName("InternetType"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property InternetType() As String
			Get
				InternetType = _InternetType
			End Get
			Set(ByVal value As String)
				_InternetType = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="COST_TYPE", Storage:="_CostType", DbType:="varchar"),
		System.ComponentModel.DisplayName("CostType"),
		System.ComponentModel.DataAnnotations.MaxLength(3)>
		Public Property CostType() As String
			Get
				CostType = _CostType
			End Get
			Set(ByVal value As String)
				_CostType = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PROJ_IMPRESSIONS", Storage:="_ProjectedImpressions", DbType:="int"),
		System.ComponentModel.DisplayName("ProjectedImpressions")>
		Public Property ProjectedImpressions() As System.Nullable(Of Long)
			Get
				ProjectedImpressions = _ProjectedImpressions
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_ProjectedImpressions = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="GUARANTEED_IMPRESS", Storage:="_GuaranteedImpressions", DbType:="int"),
		System.ComponentModel.DisplayName("GuaranteedImpressions")>
		Public Property GuaranteedImpressions() As System.Nullable(Of Long)
			Get
				GuaranteedImpressions = _GuaranteedImpressions
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_GuaranteedImpressions = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ACT_IMPRESSIONS", Storage:="_ActiveImpressions", DbType:="int"),
		System.ComponentModel.DisplayName("ActiveImpressions")>
		Public Property ActiveImpressions() As System.Nullable(Of Long)
			Get
				ActiveImpressions = _ActiveImpressions
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_ActiveImpressions = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="COST_RATE", Storage:="_CostRate", DbType:="decimal"),
		System.ComponentModel.DisplayName("CostRate")>
		Public Property CostRate() As System.Nullable(Of Decimal)
			Get
				CostRate = _CostRate
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_CostRate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRODUCTION_SIZE", Storage:="_ProductionSize", DbType:="varchar"),
		System.ComponentModel.DisplayName("ProductionSize"),
		System.ComponentModel.DataAnnotations.MaxLength(30)>
		Public Property ProductionSize() As String
			Get
				ProductionSize = _ProductionSize
			End Get
			Set(ByVal value As String)
				_ProductionSize = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MATERIAL", Storage:="_Material", DbType:="varchar"),
		System.ComponentModel.DisplayName("Material"),
		System.ComponentModel.DataAnnotations.MaxLength(60)>
		Public Property Material() As String
			Get
				Material = _Material
			End Get
			Set(ByVal value As String)
				_Material = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="RATE_TYPE", Storage:="_RateType", DbType:="varchar"),
		System.ComponentModel.DisplayName("RateType"),
		System.ComponentModel.DataAnnotations.MaxLength(3)>
		Public Property RateType() As String
			Get
				RateType = _RateType
			End Get
			Set(ByVal value As String)
				_RateType = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="OUTDOOR_TYPE", Storage:="_OutdoorType", DbType:="varchar"),
		System.ComponentModel.DisplayName("OutdoorType"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property OutdoorType() As String
			Get
				OutdoorType = _OutdoorType
			End Get
			Set(ByVal value As String)
				_OutdoorType = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRINT_COLUMNS", Storage:="_PrintColumns", DbType:="decimal"),
		System.ComponentModel.DisplayName("PrintColumns")>
		Public Property PrintColumns() As System.Nullable(Of Decimal)
			Get
				PrintColumns = _PrintColumns
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_PrintColumns = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRINT_INCHES", Storage:="_PrintInches", DbType:="decimal"),
		System.ComponentModel.DisplayName("PrintInches")>
		Public Property PrintInches() As System.Nullable(Of Decimal)
			Get
				PrintInches = _PrintInches
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_PrintInches = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRINT_LINES", Storage:="_PrintLines", DbType:="decimal"),
		System.ComponentModel.DisplayName("PrintLines")>
		Public Property PrintLines() As System.Nullable(Of Decimal)
			Get
				PrintLines = _PrintLines
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_PrintLines = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VN_CODE_XREF", Storage:="_VenderCodeCrossRefrence", DbType:="varchar"),
		System.ComponentModel.DisplayName("VenderCodeCrossRefrence"),
		System.ComponentModel.DataAnnotations.MaxLength(12)>
		Public Property VenderCodeCrossRefrence() As String
			Get
				VenderCodeCrossRefrence = _VenderCodeCrossRefrence
			End Get
			Set(ByVal value As String)
				_VenderCodeCrossRefrence = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="NET_BASE_RATE", Storage:="_NetBaseRate", DbType:="decimal"),
		System.ComponentModel.DisplayName("NetBaseRate")>
		Public Property NetBaseRate() As System.Nullable(Of Decimal)
			Get
				NetBaseRate = _NetBaseRate
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_NetBaseRate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="GROSS_BASE_RATE", Storage:="_GrossBaseRate", DbType:="decimal"),
		System.ComponentModel.DisplayName("GrossBaseRate")>
		Public Property GrossBaseRate() As System.Nullable(Of Decimal)
			Get
				GrossBaseRate = _GrossBaseRate
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_GrossBaseRate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="NET_RATE", Storage:="_NetRate", DbType:="decimal"),
		System.ComponentModel.DisplayName("NetRate")>
		Public Property NetRate() As System.Nullable(Of Decimal)
			Get
				NetRate = _NetRate
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_NetRate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="GROSS_RATE", Storage:="_GrossRate", DbType:="decimal"),
		System.ComponentModel.DisplayName("GrossRate")>
		Public Property GrossRate() As System.Nullable(Of Decimal)
			Get
				GrossRate = _GrossRate
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_GrossRate = value
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
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ORDER_COPY", Storage:="_OrderCopy", DbType:="text"),
		System.ComponentModel.DisplayName("OrderCopy")>
		Public Property OrderCopy() As String
			Get
				OrderCopy = _OrderCopy
			End Get
			Set(value As String)
				_OrderCopy = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MATL_NOTES", Storage:="_MaterialNotes", DbType:="text"),
		System.ComponentModel.DisplayName("MaterialNotes")>
		Public Property MaterialNotes() As String
			Get
				MaterialNotes = _MaterialNotes
			End Get
			Set(value As String)
				_MaterialNotes = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="POSITION_INFO", Storage:="_PositionInfo", DbType:="text"),
		System.ComponentModel.DisplayName("PositionInfo")>
		Public Property PositionInfo() As String
			Get
				PositionInfo = _PositionInfo
			End Get
			Set(value As String)
				_PositionInfo = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CLOSE_INFO", Storage:="_CloseInfo", DbType:="text"),
		System.ComponentModel.DisplayName("CloseInfo")>
		Public Property CloseInfo() As String
			Get
				CloseInfo = _CloseInfo
			End Get
			Set(value As String)
				_CloseInfo = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="RATE_INFO", Storage:="_RateInfo", DbType:="text"),
		System.ComponentModel.DisplayName("RateInfo")>
		Public Property RateInfo() As String
			Get
				RateInfo = _RateInfo
			End Get
			Set(value As String)
				_RateInfo = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MISC_INFO", Storage:="_MiscInfo", DbType:="text"),
		System.ComponentModel.DisplayName("MiscInfo")>
		Public Property MiscInfo() As String
			Get
				MiscInfo = _MiscInfo
			End Get
			Set(value As String)
				_MiscInfo = value
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
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="UNITS", Storage:="_Units", DbType:="varchar"),
        System.ComponentModel.DisplayName("Units"),
        System.ComponentModel.DataAnnotations.MaxLength(2)>
        Public Property Units() As String
            Get
                Units = _Units
            End Get
            Set(ByVal value As String)
                _Units = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LINE_MARKET_CODE", Storage:="_LineMarketCode", DbType:="varchar"),
        System.ComponentModel.DisplayName("MarketCode"),
        System.ComponentModel.DataAnnotations.MaxLength(10)>
        Public Property LineMarketCode() As String
            Get
                LineMarketCode = _LineMarketCode
            End Get
            Set(ByVal value As String)
                _LineMarketCode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CIRCULATION", Storage:="_Circulation", DbType:="int"),
        System.ComponentModel.DisplayName("Circulation")>
        Public Property Circulation() As System.Nullable(Of Long)
            Get
                Circulation = _Circulation
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _Circulation = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MEDIA_CHANNEL_ID", Storage:="_MediaChannelID", DbType:="int"),
        System.ComponentModel.DisplayName("MediaChannel")>
        Public Property MediaChannelID() As System.Nullable(Of Long)
            Get
                MediaChannelID = _MediaChannelID
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _MediaChannelID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MEDIA_TACTIC_ID", Storage:="_MediaTacticID", DbType:="int"),
        System.ComponentModel.DisplayName("MediaTactic")>
        Public Property MediaTacticID() As System.Nullable(Of Long)
            Get
                MediaTacticID = _MediaTacticID
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _MediaTacticID = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
