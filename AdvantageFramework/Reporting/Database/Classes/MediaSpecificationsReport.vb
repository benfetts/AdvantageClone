Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class MediaSpecificationsReport
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OrderType
            OrderNumber
            OrderDescription
            OfficeCode
            OfficeName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            MarketCode
            MarketDescription
            CampaignCode
            CampaignID
            CampaignName
            VendorCode
            VendorName
            VendorRepCode
            VendorLabel
            VendorRepName
            VendorRepEmail
            VendorRepPhone
            VendorRepCode2
            VendorLabel2
            VendorRepName2
            VendorRepEmail2
            VendorRepPhone2
            ClientPO
            OrderDate
            MediaType
            MediaTypeDescription
            FlightFrom
            FlightTo
            Buyer
            OrderAccepted
            OrderCommentLimited
            LineNumber
            LineRevisionNumber
            Period
            Month
            Year
            StartDate
            EndDate
            CloseDate
            MaterialCloseDate
            ExtendedCloseDate
            ExtendedMaterialCloseDate
            HeadlineOrProgram
            SizeCode
            Size
            EditionOrIssue
            Section
            Material
            BroadcastRemarks
            CompletedDate
            URL
            CopyArea
            AdNumber
            AdNumberDescription
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            NewspaperPrintQuantity
            InternetGuaranteedImpressions
            BroadcastSpots
            BroadcastCommercialLength
            LineCancelled
            NewspaperCirculation
            Instructions
            OrderCopy
            MaterialNotes
            PositionInfo
            CloseInfo
            MiscInfo
            VendorSundayCirculation
            VendorDailyCirculation
            VendorShippingName
            VendorShippingAddress1
            VendorShippingAddress2
            VendorShippingAddress3
            VendorShippingCity
            VendorShippingCounty
            VendorShippingState
            VendorShippingZip
            VendorShippingCountry
            VendorShippingPhone
            VendorShippingPhoneExt
            VendorAcceptedMedia
            VendorEFILEInfo
            VendorPreferenceMaterial
            VendorFTPUser
            VendorFTPPassword
            VendorFTPDirectory
        End Enum

#End Region

#Region " Variables "

        Private _OrderType As String = Nothing
        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _OrderDescription As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _MarketCode As String = Nothing
        Private _MarketDescription As String = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignName As String = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _VendorRepCode As String = Nothing
        Private _VendorLabel As String = Nothing
        Private _VendorRepName As String = Nothing
        Private _VendorRepEmail As String = Nothing
        Private _VendorRepPhone As String = Nothing
        Private _VendorRepCode2 As String = Nothing
        Private _VendorLabel2 As String = Nothing
        Private _VendorRepName2 As String = Nothing
        Private _VendorRepEmail2 As String = Nothing
        Private _VendorRepPhone2 As String = Nothing
        Private _ClientPO As String = Nothing
        Private _OrderDate As Nullable(Of Date) = Nothing
        Private _MediaType As String = Nothing
        Private _MediaTypeDescription As String = Nothing
        Private _FlightFrom As Nullable(Of Date) = Nothing
        Private _FlightTo As Nullable(Of Date) = Nothing
        Private _Buyer As String = Nothing
        Private _OrderAccepted As Nullable(Of Short) = Nothing
        Private _OrderCommentLimited As String = Nothing
        Private _LineNumber As Nullable(Of Integer) = Nothing
        Private _LineRevisionNumber As Nullable(Of Short) = Nothing
        Private _Period As Nullable(Of Integer) = Nothing
        Private _Month As Nullable(Of Integer) = Nothing
        Private _Year As Nullable(Of Integer) = Nothing
        Private _StartDate As Nullable(Of Date) = Nothing
        Private _EndDate As Nullable(Of Date) = Nothing
        Private _CloseDate As Nullable(Of Date) = Nothing
        Private _MaterialCloseDate As Nullable(Of Date) = Nothing
        Private _ExtendedCloseDate As Nullable(Of Date) = Nothing
        Private _ExtendedMaterialCloseDate As Nullable(Of Date) = Nothing
        Private _HeadlineOrProgram As String = Nothing
        Private _SizeCode As String = Nothing
        Private _Size As String = Nothing
        Private _EditionOrIssue As String = Nothing
        Private _Section As String = Nothing
        Private _Material As String = Nothing
        Private _BroadcastRemarks As String = Nothing
        Private _CompletedDate As Nullable(Of Date) = Nothing
        Private _URL As String = Nothing
        Private _CopyArea As String = Nothing
        Private _AdNumber As String = Nothing
        Private _AdNumberDescription As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _NewspaperPrintQuantity As Nullable(Of Decimal) = Nothing
        Private _InternetGuaranteedImpressions As Nullable(Of Integer) = Nothing
        Private _BroadcastSpots As Nullable(Of Integer) = Nothing
        Private _BroadcastCommercialLength As Nullable(Of Short) = Nothing
        Private _LineCancelled As Nullable(Of Short) = Nothing
        Private _NewspaperCirculation As Nullable(Of Integer) = Nothing
        Private _Instructions As String = Nothing
        Private _OrderCopy As String = Nothing
        Private _MaterialNotes As String = Nothing
        Private _PositionInfo As String = Nothing
        Private _CloseInfo As String = Nothing
        Private _MiscInfo As String = Nothing
        Private _VendorSundayCirculation As Nullable(Of Integer) = Nothing
        Private _VendorDailyCirculation As Nullable(Of Integer) = Nothing
        Private _VendorShippingName As String = Nothing
        Private _VendorShippingAddress1 As String = Nothing
        Private _VendorShippingAddress2 As String = Nothing
        Private _VendorShippingAddress3 As String = Nothing
        Private _VendorShippingCity As String = Nothing
        Private _VendorShippingCounty As String = Nothing
        Private _VendorShippingState As String = Nothing
        Private _VendorShippingZip As String = Nothing
        Private _VendorShippingCountry As String = Nothing
        Private _VendorShippingPhone As String = Nothing
        Private _VendorShippingPhoneExt As String = Nothing
        Private _VendorAcceptedMedia As String = Nothing
        Private _VendorEFILEInfo As String = Nothing
        Private _VendorPreferenceMaterial As String = Nothing
        Private _VendorFTPUser As String = Nothing
        Private _VendorFTPPassword As String = Nothing
        Private _VendorFTPDirectory As String = Nothing
#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderType() As String
            Get
                OrderType = _OrderType
            End Get
            Set(value As String)
                _OrderType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Nullable(Of Integer))
                _OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderDescription() As String
            Get
                OrderDescription = _OrderDescription
            End Get
            Set(value As String)
                _OrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OfficeName() As String
            Get
                OfficeName = _OfficeName
            End Get
            Set(value As String)
                _OfficeName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketCode() As String
            Get
                MarketCode = _MarketCode
            End Get
            Set(value As String)
                _MarketCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketDescription() As String
            Get
                MarketDescription = _MarketDescription
            End Get
            Set(value As String)
                _MarketDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property CampaignID() As Nullable(Of Short)
            Get
                CampaignID = _CampaignID
            End Get
            Set(value As Nullable(Of Short))
                _CampaignID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(value As String)
                _CampaignName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(value As String)
                _VendorName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepCode() As String
            Get
                VendorRepCode = _VendorRepCode
            End Get
            Set(value As String)
                _VendorRepCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorLabel() As String
            Get
                VendorLabel = _VendorLabel
            End Get
            Set(value As String)
                _VendorLabel = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepName() As String
            Get
                VendorRepName = _VendorRepName
            End Get
            Set(value As String)
                _VendorRepName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepEmail() As String
            Get
                VendorRepEmail = _VendorRepEmail
            End Get
            Set(value As String)
                _VendorRepEmail = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepPhone() As String
            Get
                VendorRepPhone = _VendorRepPhone
            End Get
            Set(value As String)
                _VendorRepPhone = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepCode2() As String
            Get
                VendorRepCode2 = _VendorRepCode2
            End Get
            Set(value As String)
                _VendorRepCode2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorLabel2() As String
            Get
                VendorLabel2 = _VendorLabel2
            End Get
            Set(value As String)
                _VendorLabel2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepName2() As String
            Get
                VendorRepName2 = _VendorRepName2
            End Get
            Set(value As String)
                _VendorRepName2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepEmail2() As String
            Get
                VendorRepEmail2 = _VendorRepEmail2
            End Get
            Set(value As String)
                _VendorRepEmail2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepPhone2() As String
            Get
                VendorRepPhone2 = _VendorRepPhone2
            End Get
            Set(value As String)
                _VendorRepPhone2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(value As String)
                _ClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderDate() As Nullable(Of Date)
            Get
                OrderDate = _OrderDate
            End Get
            Set(value As Nullable(Of Date))
                _OrderDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaType() As String
            Get
                MediaType = _MediaType
            End Get
            Set(value As String)
                _MediaType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaTypeDescription() As String
            Get
                MediaTypeDescription = _MediaTypeDescription
            End Get
            Set(value As String)
                _MediaTypeDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FlightFrom() As Nullable(Of Date)
            Get
                FlightFrom = _FlightFrom
            End Get
            Set(value As Nullable(Of Date))
                _FlightFrom = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FlightTo() As Nullable(Of Date)
            Get
                FlightTo = _FlightTo
            End Get
            Set(value As Nullable(Of Date))
                _FlightTo = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Buyer() As String
            Get
                Buyer = _Buyer
            End Get
            Set(value As String)
                _Buyer = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderAccepted() As Nullable(Of Short)
            Get
                OrderAccepted = _OrderAccepted
            End Get
            Set(value As Nullable(Of Short))
                _OrderAccepted = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderCommentLimited() As String
            Get
                OrderCommentLimited = _OrderCommentLimited
            End Get
            Set(value As String)
                _OrderCommentLimited = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineNumber() As Nullable(Of Integer)
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Nullable(Of Integer))
                _LineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineRevisionNumber() As Nullable(Of Short)
            Get
                LineRevisionNumber = _LineRevisionNumber
            End Get
            Set(value As Nullable(Of Short))
                _LineRevisionNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property Period() As Nullable(Of Integer)
            Get
                Period = _Period
            End Get
            Set(value As Nullable(Of Integer))
                _Period = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property Month() As Nullable(Of Integer)
            Get
                Month = _Month
            End Get
            Set(value As Nullable(Of Integer))
                _Month = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="Year")>
        Public Property Year() As Nullable(Of Short)
            Get
                Year = _Year
            End Get
            Set(value As Nullable(Of Short))
                _Year = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartDate() As Nullable(Of Date)
            Get
                StartDate = _StartDate
            End Get
            Set(value As Nullable(Of Date))
                _StartDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EndDate() As Nullable(Of Date)
            Get
                EndDate = _EndDate
            End Get
            Set(value As Nullable(Of Date))
                _EndDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CloseDate() As Nullable(Of Date)
            Get
                CloseDate = _CloseDate
            End Get
            Set(value As Nullable(Of Date))
                _CloseDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MaterialCloseDate() As Nullable(Of Date)
            Get
                MaterialCloseDate = _MaterialCloseDate
            End Get
            Set(value As Nullable(Of Date))
                _MaterialCloseDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExtendedCloseDate() As Nullable(Of Date)
            Get
                ExtendedCloseDate = _ExtendedCloseDate
            End Get
            Set(value As Nullable(Of Date))
                _ExtendedCloseDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExtendedMaterialCloseDate() As Nullable(Of Date)
            Get
                ExtendedMaterialCloseDate = _ExtendedMaterialCloseDate
            End Get
            Set(value As Nullable(Of Date))
                _ExtendedMaterialCloseDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HeadlineOrProgram() As String
            Get
                HeadlineOrProgram = _HeadlineOrProgram
            End Get
            Set(value As String)
                _HeadlineOrProgram = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SizeCode() As String
            Get
                SizeCode = _SizeCode
            End Get
            Set(value As String)
                _SizeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Size() As String
            Get
                Size = _Size
            End Get
            Set(value As String)
                _Size = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EditionOrIssue() As String
            Get
                EditionOrIssue = _EditionOrIssue
            End Get
            Set(value As String)
                _EditionOrIssue = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Section() As String
            Get
                Section = _Section
            End Get
            Set(value As String)
                _Section = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Material() As String
            Get
                Material = _Material
            End Get
            Set(value As String)
                _Material = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BroadcastRemarks() As String
            Get
                BroadcastRemarks = _BroadcastRemarks
            End Get
            Set(value As String)
                _BroadcastRemarks = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CompletedDate() As Nullable(Of Date)
            Get
                CompletedDate = _CompletedDate
            End Get
            Set(value As Nullable(Of Date))
                _CompletedDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property URL() As String
            Get
                URL = _URL
            End Get
            Set(value As String)
                _URL = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CopyArea() As String
            Get
                CopyArea = _CopyArea
            End Get
            Set(value As String)
                _CopyArea = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdNumber() As String
            Get
                AdNumber = _AdNumber
            End Get
            Set(value As String)
                _AdNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdNumberDescription() As String
            Get
                AdNumberDescription = _AdNumberDescription
            End Get
            Set(value As String)
                _AdNumberDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f0")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(value As String)
                _JobComponentDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperPrintQuantity() As Nullable(Of Decimal)
            Get
                NewspaperPrintQuantity = _NewspaperPrintQuantity
            End Get
            Set(value As Nullable(Of Decimal))
                _NewspaperPrintQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetGuaranteedImpressions() As Nullable(Of Integer)
            Get
                InternetGuaranteedImpressions = _InternetGuaranteedImpressions
            End Get
            Set(value As Nullable(Of Integer))
                _InternetGuaranteedImpressions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BroadcastSpots() As Nullable(Of Integer)
            Get
                BroadcastSpots = _BroadcastSpots
            End Get
            Set(value As Nullable(Of Integer))
                _BroadcastSpots = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BroadcastCommercialLength() As Nullable(Of Short)
            Get
                BroadcastCommercialLength = _BroadcastCommercialLength
            End Get
            Set(value As Nullable(Of Short))
                _BroadcastCommercialLength = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineCancelled() As Nullable(Of Short)
            Get
                LineCancelled = _LineCancelled
            End Get
            Set(value As Nullable(Of Short))
                _LineCancelled = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperCirculation() As Nullable(Of Integer)
            Get
                NewspaperCirculation = _NewspaperCirculation
            End Get
            Set(value As Nullable(Of Integer))
                _NewspaperCirculation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Instructions() As String
            Get
                Instructions = _Instructions
            End Get
            Set(value As String)
                _Instructions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderCopy() As String
            Get
                OrderCopy = _OrderCopy
            End Get
            Set(value As String)
                _OrderCopy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MaterialNotes() As String
            Get
                MaterialNotes = _MaterialNotes
            End Get
            Set(value As String)
                _MaterialNotes = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PositionInfo() As String
            Get
                PositionInfo = _PositionInfo
            End Get
            Set(value As String)
                _PositionInfo = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CloseInfo() As String
            Get
                CloseInfo = _CloseInfo
            End Get
            Set(value As String)
                _CloseInfo = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MiscInfo() As Nullable(Of Integer)
            Get
                MiscInfo = _MiscInfo
            End Get
            Set(value As Nullable(Of Integer))
                _MiscInfo = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorSundayCirculation() As Nullable(Of Integer)
            Get
                VendorSundayCirculation = _VendorSundayCirculation
            End Get
            Set(value As Nullable(Of Integer))
                _VendorSundayCirculation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorDailyCirculation() As Nullable(Of Integer)
            Get
                VendorDailyCirculation = _VendorDailyCirculation
            End Get
            Set(value As Nullable(Of Integer))
                _VendorDailyCirculation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorShippingName() As String
            Get
                VendorShippingName = _VendorShippingName
            End Get
            Set(value As String)
                _VendorShippingName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorShippingAddress1() As String
            Get
                VendorShippingAddress1 = _VendorShippingAddress1
            End Get
            Set(value As String)
                _VendorShippingAddress1 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorShippingAddress2() As String
            Get
                VendorShippingAddress2 = _VendorShippingAddress2
            End Get
            Set(value As String)
                _VendorShippingAddress2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorShippingAddress3() As String
            Get
                VendorShippingAddress3 = _VendorShippingAddress3
            End Get
            Set(value As String)
                _VendorShippingAddress3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorShippingCity() As String
            Get
                VendorShippingCity = _VendorShippingCity
            End Get
            Set(value As String)
                _VendorShippingCity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorShippingCounty() As String
            Get
                VendorShippingCounty = _VendorShippingCounty
            End Get
            Set(value As String)
                _VendorShippingCounty = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorShippingState() As String
            Get
                VendorShippingState = _VendorShippingState
            End Get
            Set(value As String)
                _VendorShippingState = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorShippingZip() As String
            Get
                VendorShippingZip = _VendorShippingZip
            End Get
            Set(value As String)
                _VendorShippingZip = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorShippingCountry() As String
            Get
                VendorShippingCountry = _VendorShippingCountry
            End Get
            Set(value As String)
                _VendorShippingCountry = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorShippingPhone() As String
            Get
                VendorShippingPhone = _VendorShippingPhone
            End Get
            Set(value As String)
                _VendorShippingPhone = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorShippingPhoneExt() As String
            Get
                VendorShippingPhoneExt = _VendorShippingPhoneExt
            End Get
            Set(value As String)
                _VendorShippingPhoneExt = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorAcceptedMedia() As String
            Get
                VendorAcceptedMedia = _VendorAcceptedMedia
            End Get
            Set(value As String)
                _VendorAcceptedMedia = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorEFILEInfo() As String
            Get
                VendorEFILEInfo = _VendorEFILEInfo
            End Get
            Set(value As String)
                _VendorEFILEInfo = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorPreferenceMaterial() As String
            Get
                VendorPreferenceMaterial = _VendorPreferenceMaterial
            End Get
            Set(value As String)
                _VendorPreferenceMaterial = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorFTPUser() As String
            Get
                VendorFTPUser = _VendorFTPUser
            End Get
            Set(value As String)
                _VendorFTPUser = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorFTPPassword() As String
            Get
                VendorFTPPassword = _VendorFTPPassword
            End Get
            Set(value As String)
                _VendorFTPPassword = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorFTPDirectory() As String
            Get
                VendorFTPDirectory = _VendorFTPDirectory
            End Get
            Set(value As String)
                _VendorFTPDirectory = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OrderNumber.ToString

        End Function

#End Region

    End Class

End Namespace
