Namespace MediaManager.Classes

    <Serializable()>
    Public Class MediaManagerReviewDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ForceRevision
            Buyer
            BuyerEmployeeCode
            AccountExecutiveDefault
            AccountExecutiveJob
            OfficeCode
            OfficeDescription
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            CampaignCode
            CampaignID
            CampaignName
            OrderProcessControl
            OrderNumber
            OrderDescription
            Quote
            NetGross
            SalesClassCode
            SalesClassDescription
            LinkID
            ClientPO
            VendorCode
            VendorName
            MarketCode
            MarketDescription
            LineNumber
            LinkLineID
            RevisionNumber
            Cancelled
            OrderLineStatus
            AcceptanceDetails
            HasBillingApprovalStatus
            BillingApprovedDateBy
            JobNumber
            JobDescription
            JobComponentNumber
            JobCompDescription
            Headline
            Material
            AdNumber
            AdSizeCode
            AdSizeDescription
            JobMediaBillDate
            StartDate
            EndDate
            MonthYear
            CloseDate
            MaterialDate
            DateToBill
            Spots
            BillType
            NetAmount
            CommissionAmount
            RebateAmount
            AdditionalChargeAmount
            DiscountAmount
            NetChargeAmount
            NonResaleTax
            ResaleTax
            BillableAmount
            TotalCostPayableToVendor
            ActualAmountPosted
            VendorCollected
            VendorCollectedQuote
            VendorCollectedCopy
            PaidWithOrderAmount
            BilledAmount
            CashReceived
            UnbilledTotal
            MediaFrom
            NewspaperCostRate
            InternetCostType
            Rate
            ProjectedImpressions
            GuaranteedImpressions
            ActualImpressions
            QuoteColumnUpdated
            ReviseUpdateOrder
            ReviseOrderTo
            ExtendedCloseDate
            ExtendedMaterialDate
            InternetType
            InternetPlacement1
            InternetPlacement2
            InternetURL
            InternetTargetAudience
            Issue
            ProductionSize
            MagazineCirculationQTY
            NewspaperSection
            NewspaperCirculationQTY
            NewspaperCirculation
            NewspaperColumns
            NewspaperInches
            OutdoorType
            OutdoorLocation
            OutdoorCopyArea
            BroadcastStartTime
            BroadcastEndTime
            BroadcastProgramming
            BroadcastNetworkCode
            BroadcastLength
            BroadcastRemarks
            BroadcastDaysofWeek
            BroadcastSpotsbyWeek
            BroadcastDatesbyWeek
            GrossAmount
            BillingUser
            OrderLineIsBilled
            VCCCardID
            MarkupPercent
            RebatePercent
            NewspaperCost
            NewspaperRate
            ProcessControl
            JobMediaBillDateColumnUpdated
            PaymentMethod
            APPostedVariance
            VendorCollectedVariance
            VCCClearedAmount
            VCCClearedVariance
            IsOrderClosed
            AdjustedMarkupPercent
            MarginPercent
            JobOrMediaDateToBill
            BillCoopCode
            CampaignStartDate
            CampaignEndDate
            AdServerName
            AdServerPlacementID
            AdServerPackageID
            ImportedFrom
            PackageParent
            OrderAccepted
            RevisedBy
            BillTypeFlag
            APExists
            SourceCode
            WorksheetID
            WorksheetName
            PlanID
            PlanName
            EstimateID
            EstimateName
            MatCompDate
            DCProfileID
            DCReportID
            LineMarketCode
            LineMarketDescription
        End Enum

        Public Enum ReviseOrderToAmount
            DoNotReviseAmount = 0
            ActualAmountPosted = 1
            VendorCollected = 2
        End Enum

#End Region

#Region " Variables "

        Private _ForceRevision As Boolean = False
        Private _Buyer As String = Nothing
        Private _AccountExecutiveDefault As String = Nothing
        Private _AccountExecutiveJob As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeDescription As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignName As String = Nothing
        Private _OrderProcessControl As String = Nothing
        Private _OrderNumber As Integer = Nothing
        Private _OrderDescription As String = Nothing
        Private _Quote As Boolean = False
        Private _NetGross As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _LinkID As Nullable(Of Integer) = Nothing
        Private _ClientPO As String = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _MarketCode As String = Nothing
        Private _MarketDescription As String = Nothing
        Private _LineNumber As Integer = Nothing
        Private _LinkLineID As Nullable(Of Integer) = Nothing
        Private _RevisionNumber As Nullable(Of Integer) = Nothing
        Private _Cancelled As Boolean = False
        Private _OrderLineStatus As String = Nothing
        Private _HasBillingApprovalStatus As Boolean = False
        Private _BillingApprovedDateBy As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobCompDescription As String = Nothing
        Private _Headline As String = Nothing
        Private _Material As String = Nothing
        Private _AdNumber As String = Nothing
        Private _AdSizeCode As String = Nothing
        Private _AdSizeDescription As String = Nothing
        Private _JobMediaBillDate As Nullable(Of Date) = Nothing
        Private _StartDate As Nullable(Of Date) = Nothing
        Private _EndDate As Nullable(Of Date) = Nothing
        Private _MonthYear As String = Nothing
        Private _CloseDate As Nullable(Of Date) = Nothing
        Private _MaterialDate As Nullable(Of Date) = Nothing
        Private _DateToBill As Nullable(Of Date) = Nothing
        Private _Spots As Nullable(Of Integer) = Nothing
        Private _BillType As String = Nothing
        Private _NetAmount As Nullable(Of Decimal) = Nothing
        Private _CommissionAmount As Nullable(Of Decimal) = Nothing
        Private _RebateAmount As Nullable(Of Decimal) = Nothing
        Private _AdditionalChargeAmount As Nullable(Of Decimal) = Nothing
        Private _DiscountAmount As Nullable(Of Decimal) = Nothing
        Private _NetChargeAmount As Nullable(Of Decimal) = Nothing
        Private _NonResaleTax As Nullable(Of Decimal) = Nothing
        Private _ResaleTax As Nullable(Of Decimal) = Nothing
        Private _BillableAmount As Decimal = Nothing
        Private _TotalCostPayableToVendor As Nullable(Of Decimal) = Nothing
        Private _ActualAmountPosted As Nullable(Of Decimal) = Nothing
        Private _VendorCollected As Nullable(Of Decimal) = Nothing
        Private _VendorCollectedQuote As Nullable(Of Decimal) = Nothing
        Private _VendorCollectedCopy As Nullable(Of Decimal) = Nothing
        Private _PaidWithOrderAmount As Nullable(Of Decimal) = Nothing
        Private _BilledAmount As Decimal = Nothing
        Private _CashReceived As Nullable(Of Decimal) = Nothing
        Private _UnbilledTotal As Nullable(Of Decimal) = Nothing
        Private _MediaFrom As String = Nothing
        Private _NewspaperCostRate As String = Nothing
        Private _InternetCostType As String = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _ProjectedImpressions As Nullable(Of Integer) = Nothing
        Private _GuaranteedImpressions As Nullable(Of Integer) = Nothing
        Private _ActualImpressions As Nullable(Of Integer) = Nothing
        Private _QuoteColumnUpdated As Boolean = False
        Private _ReviseUpdateOrder As Boolean = False
        Private _ExtendedCloseDate As Nullable(Of Date) = Nothing
        Private _ExtendedMaterialDate As Nullable(Of Date) = Nothing
        Private _InternetType As String = Nothing
        Private _InternetPlacement1 As String = Nothing
        Private _InternetPlacement2 As String = Nothing
        Private _InternetURL As String = Nothing
        Private _InternetTargetAudience As String = Nothing
        Private _Issue As String = Nothing
        Private _ProductionSize As String = Nothing
        Private _MagazineCirculationQTY As Nullable(Of Integer) = Nothing
        Private _NewspaperSection As String = Nothing
        Private _NewspaperCirculationQTY As Nullable(Of Decimal) = Nothing
        Private _NewspaperColumns As Nullable(Of Decimal) = Nothing
        Private _NewspaperInches As Nullable(Of Decimal) = Nothing
        Private _OutdoorType As String = Nothing
        Private _OutdoorLocation As String = Nothing
        Private _OutdoorCopyArea As String = Nothing
        Private _BroadcastStartTime As String = Nothing
        Private _BroadcastEndTime As String = Nothing
        Private _BroadcastProgramming As String = Nothing
        Private _BroadcastNetworkCode As String = Nothing
        Private _BroadcastLength As Nullable(Of Short) = Nothing
        Private _BroadcastRemarks As String = Nothing
        Private _BroadcastDaysofWeek As String = Nothing
        Private _BroadcastSpotsbyWeek As String = Nothing
        Private _BroadcastDatesbyWeek As String = Nothing
        Private _GrossAmount As Nullable(Of Decimal) = Nothing
        Private _BillingUser As String = Nothing
        Private _OrderLineIsBilled As Boolean = False
        Private _VCCCardID As Nullable(Of Integer) = Nothing
        Private _MarkupPercent As Nullable(Of Decimal) = Nothing
        Private _RebatePercent As Nullable(Of Decimal) = Nothing
        Private _NewspaperCost As String = Nothing
        Private _NewspaperRate As String = Nothing
        Private _IsDailyNewspaper As Boolean = False
        Private _ProcessControl As Nullable(Of Short) = Nothing
        Private _JobMediaBillDateColumnUpdated As Boolean = False
        Private _PaymentMethod As String = Nothing
        Private _VCCClearedAmount As Nullable(Of Decimal) = Nothing
        Private _JobOrMediaDateToBill As Nullable(Of Date) = Nothing
        Private _ImportedFrom As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Create" & vbCrLf & "Revision")>
        Public Property ForceRevision() As Boolean
            Get
                ForceRevision = _ForceRevision
            End Get
            Set(value As Boolean)
                _ForceRevision = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Media" & vbCrLf & "Type")>
        Public Property MediaFrom() As String
            Get
                MediaFrom = _MediaFrom
            End Get
            Set(value As String)
                _MediaFrom = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Buyer" & vbCrLf & "Code", PropertyType:=BaseClasses.Methods.PropertyTypes.BuyerEmployeeCode, IsAutoFillProperty:=True)>
        Public Property BuyerEmployeeCode() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.BuyerEmployeeName, IsAutoFillProperty:=True)>
        Public Property Buyer() As String
            Get
                Buyer = _Buyer
            End Get
            Set(value As String)
                _Buyer = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Account" & vbCrLf & "Executive")>
        Public Property AccountExecutiveDefault() As String
            Get
                AccountExecutiveDefault = _AccountExecutiveDefault
            End Get
            Set(value As String)
                _AccountExecutiveDefault = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Account" & vbCrLf & "Executive Job")>
        Public Property AccountExecutiveJob() As String
            Get
                AccountExecutiveJob = _AccountExecutiveJob
            End Get
            Set(value As String)
                _AccountExecutiveJob = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Office" & vbCrLf & "Code")>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Office" & vbCrLf & "Description")>
        Public Property OfficeDescription() As String
            Get
                OfficeDescription = _OfficeDescription
            End Get
            Set(value As String)
                _OfficeDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Client" & vbCrLf & "Code")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Client" & vbCrLf & "Name")>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Division" & vbCrLf & "Code")>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Division" & vbCrLf & "Name")>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Product" & vbCrLf & "Code")>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Product" & vbCrLf & "Description")>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Campaign" & vbCrLf & "ID", PropertyType:=BaseClasses.Methods.PropertyTypes.CampaignID, IsAutoFillProperty:=True)>
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(value As Nullable(Of Integer))
                _CampaignID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Campaign" & vbCrLf & "Code", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.CampaignCode)>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Campaign" & vbCrLf & "Name", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.CampaignName)>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(value As String)
                _CampaignName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Order Process" & vbCrLf & "Control")>
        Public Property OrderProcessControl() As String
            Get
                OrderProcessControl = _OrderProcessControl
            End Get
            Set(value As String)
                _OrderProcessControl = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Order" & vbCrLf & "Number")>
        Public Property OrderNumber() As Integer
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Integer)
                _OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Order" & vbCrLf & "Description", IsAutoFillProperty:=True)>
        Public Property OrderDescription() As String
            Get
                OrderDescription = _OrderDescription
            End Get
            Set(value As String)
                _OrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Quote() As Boolean
            Get
                Quote = _Quote
            End Get
            Set(value As Boolean)
                _Quote = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Net/" & vbCrLf & "Gross")>
        Public Property NetGross() As String
            Get
                NetGross = _NetGross
            End Get
            Set(value As String)
                _NetGross = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Sales Class" & vbCrLf & "Code")>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Sales Class" & vbCrLf & "Description")>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Link" & vbCrLf & "ID")>
        Public Property LinkID() As Nullable(Of Integer)
            Get
                LinkID = _LinkID
            End Get
            Set(value As Nullable(Of Integer))
                _LinkID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client" & vbCrLf & "PO", IsAutoFillProperty:=True)>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(value As String)
                _ClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Vendor" & vbCrLf & "Code")>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Vendor" & vbCrLf & "Name")>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(value As String)
                _VendorName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Market" & vbCrLf & "Code", PropertyType:=BaseClasses.Methods.PropertyTypes.MarketCode, IsAutoFillProperty:=True)>
        Public Property MarketCode() As String
            Get
                MarketCode = _MarketCode
            End Get
            Set(value As String)
                _MarketCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Market" & vbCrLf & "Description", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.MarketDescription)>
        Public Property MarketDescription() As String
            Get
                MarketDescription = _MarketDescription
            End Get
            Set(value As String)
                _MarketDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Line" & vbCrLf & "Number")>
        Public Property LineNumber() As Integer
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Integer)
                _LineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Order Line" & vbCrLf & "Status")>
        Public Property OrderLineStatus() As String
            Get
                If Me.RevisionNumber.GetValueOrDefault(0) > 0 Then
                    OrderLineStatus = If(_OrderLineStatus Is Nothing, "Revision Pending", _OrderLineStatus)
                Else
                    OrderLineStatus = If(_OrderLineStatus Is Nothing, "Pending", _OrderLineStatus)
                End If
            End Get
            Set(value As String)
                _OrderLineStatus = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Acceptance" & vbCrLf & "Details")>
        Public Property AcceptanceDetails As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox, CustomColumnCaption:="Billing Approval" & vbCrLf & "Status")>
        Public Property HasBillingApprovalStatus() As Boolean
            Get
                HasBillingApprovalStatus = _HasBillingApprovalStatus
            End Get
            Set(value As Boolean)
                _HasBillingApprovalStatus = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BillingApprovedDateBy() As String
            Get
                BillingApprovedDateBy = _BillingApprovedDateBy
            End Get
            Set(value As String)
                _BillingApprovedDateBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Link" & vbCrLf & "Line ID")>
        Public Property LinkLineID() As Nullable(Of Integer)
            Get
                LinkLineID = _LinkLineID
            End Get
            Set(value As Nullable(Of Integer))
                _LinkLineID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Revision" & vbCrLf & "Number")>
        Public Property RevisionNumber() As Nullable(Of Integer)
            Get
                RevisionNumber = _RevisionNumber
            End Get
            Set(value As Nullable(Of Integer))
                _RevisionNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Cancelled() As Boolean
            Get
                Cancelled = _Cancelled
            End Get
            Set(value As Boolean)
                _Cancelled = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job" & vbCrLf & "Number", PropertyType:=BaseClasses.Methods.PropertyTypes.JobNumber, IsAutoFillProperty:=True)>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Job" & vbCrLf & "Description", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.JobDescription)>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job" & vbCrLf & "Comp", PropertyType:=BaseClasses.Methods.PropertyTypes.JobComponent, IsAutoFillProperty:=True)>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Job Comp" & vbCrLf & "Description", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.JobComponentDescription)>
        Public Property JobCompDescription() As String
            Get
                JobCompDescription = _JobCompDescription
            End Get
            Set(value As String)
                _JobCompDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsAutoFillProperty:=True)>
        Public Property Headline() As String
            Get
                Headline = _Headline
            End Get
            Set(value As String)
                _Headline = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsAutoFillProperty:=True)>
        Public Property Material() As String
            Get
                Material = _Material
            End Get
            Set(value As String)
                _Material = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Ad" & vbCrLf & "Number", IsAutoFillProperty:=True)>
        Public Property AdNumber() As String
            Get
                AdNumber = _AdNumber
            End Get
            Set(value As String)
                _AdNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Ad Size", IsAutoFillProperty:=True)>
        Public Property AdSizeCode() As String
            Get
                AdSizeCode = _AdSizeCode
            End Get
            Set(value As String)
                _AdSizeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Ad Size" & vbCrLf & "Description", IsReadOnlyColumn:=True)>
        Public Property AdSizeDescription() As String
            Get
                AdSizeDescription = _AdSizeDescription
            End Get
            Set(value As String)
                _AdSizeDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job Media" & vbCrLf & "Date to Bill", IsAutoFillProperty:=True)>
        Public Property JobMediaBillDate() As Nullable(Of Date)
            Get
                JobMediaBillDate = _JobMediaBillDate
            End Get
            Set(value As Nullable(Of Date))
                _JobMediaBillDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Start" & vbCrLf & "Date", IsAutoFillProperty:=True)>
        Public Property StartDate() As Nullable(Of Date)
            Get
                StartDate = _StartDate
            End Get
            Set(value As Nullable(Of Date))
                _StartDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="End" & vbCrLf & "Date", IsAutoFillProperty:=True)>
        Public Property EndDate() As Nullable(Of Date)
            Get
                EndDate = _EndDate
            End Get
            Set(value As Nullable(Of Date))
                _EndDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Month/Year")>
        Public Property MonthYear() As String
            Get
                MonthYear = _MonthYear
            End Get
            Set(value As String)
                _MonthYear = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Close" & vbCrLf & "Date")>
        Public Property CloseDate() As Nullable(Of Date)
            Get
                CloseDate = _CloseDate
            End Get
            Set(value As Nullable(Of Date))
                _CloseDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Material" & vbCrLf & "Date")>
        Public Property MaterialDate() As Nullable(Of Date)
            Get
                MaterialDate = _MaterialDate
            End Get
            Set(value As Nullable(Of Date))
                _MaterialDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Date" & vbCrLf & "to Bill", IsAutoFillProperty:=True)>
        Public Property DateToBill() As Nullable(Of Date)
            Get
                DateToBill = _DateToBill
            End Get
            Set(value As Nullable(Of Date))
                _DateToBill = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=9999, UseMinValue:=True, MinValue:=-9999)>
        Public Property Spots() As Nullable(Of Integer)
            Get
                Spots = _Spots.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Integer))
                _Spots = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Bill" & vbCrLf & "Type")>
        Public Property BillType() As String
            Get
                BillType = _BillType
            End Get
            Set(value As String)
                _BillType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Net" & vbCrLf & "Amount")>
        Public Property NetAmount() As Nullable(Of Decimal)
            Get
                NetAmount = _NetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Markup" & vbCrLf & "Percent", UseMaxValue:=True, MaxValue:=999.999, UseMinValue:=True, MinValue:=-999.999, IsAutoFillProperty:=True)>
        Public Property MarkupPercent() As Nullable(Of Decimal)
            Get
                MarkupPercent = _MarkupPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _MarkupPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Commission" & vbCrLf & "Amount")>
        Public Property CommissionAmount() As Nullable(Of Decimal)
            Get
                CommissionAmount = _CommissionAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _CommissionAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Rebate" & vbCrLf & "Percent", UseMaxValue:=True, MaxValue:=999.999, UseMinValue:=True, MinValue:=-999.999, IsAutoFillProperty:=True)>
        Public Property RebatePercent() As Nullable(Of Decimal)
            Get
                RebatePercent = _RebatePercent
            End Get
            Set(value As Nullable(Of Decimal))
                _RebatePercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Rebate" & vbCrLf & "Amount")>
        Public Property RebateAmount() As Nullable(Of Decimal)
            Get
                RebateAmount = _RebateAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _RebateAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Agency" & vbCrLf & "Fee", IsAutoFillProperty:=True, UseMaxValue:=True, MaxValue:=999999999.99, UseMinValue:=True, MinValue:=-999999999.99)>
        Public Property AdditionalChargeAmount() As Nullable(Of Decimal)
            Get
                AdditionalChargeAmount = _AdditionalChargeAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _AdditionalChargeAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Discount" & vbCrLf & "Amount")>
        Public Property DiscountAmount() As Nullable(Of Decimal)
            Get
                DiscountAmount = _DiscountAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _DiscountAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Net Charge" & vbCrLf & "Amount", IsAutoFillProperty:=True, UseMaxValue:=True, MaxValue:=999999999.99, UseMinValue:=True, MinValue:=-999999999.99)>
        Public Property NetChargeAmount() As Nullable(Of Decimal)
            Get
                NetChargeAmount = _NetChargeAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _NetChargeAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Vendor" & vbCrLf & "Tax")>
        Public Property NonResaleTax() As Nullable(Of Decimal)
            Get
                NonResaleTax = _NonResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NonResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Sales" & vbCrLf & "Tax")>
        Public Property ResaleTax() As Nullable(Of Decimal)
            Get
                ResaleTax = _ResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Billable" & vbCrLf & "Amount")>
        Public Property BillableAmount() As Decimal
            Get
                BillableAmount = _BillableAmount
            End Get
            Set(value As Decimal)
                _BillableAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Total Cost" & vbCrLf & "Payable to Vendor")>
        Public ReadOnly Property TotalCostPayableToVendor() As Nullable(Of Decimal)
            Get
                If Me.BillTypeFlag = AdvantageFramework.Database.Entities.BillTypeFlag.CommissionOnly Then
                    TotalCostPayableToVendor = 0
                Else
                    TotalCostPayableToVendor = Me.NetAmount.GetValueOrDefault(0) + Me.DiscountAmount.GetValueOrDefault(0) + Me.NetChargeAmount.GetValueOrDefault(0) + Me.NonResaleTax.GetValueOrDefault(0)
                End If
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Actual Amount" & vbCrLf & "Posted")>
        Public Property ActualAmountPosted() As Nullable(Of Decimal)
            Get
                ActualAmountPosted = _ActualAmountPosted.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualAmountPosted = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", UseMinValue:=True, MinValue:=0, CustomColumnCaption:="Vendor" & vbCrLf & "Collected", UseMaxValue:=True, MaxValue:=999999999.99)>
        Public Property VendorCollected() As Nullable(Of Decimal)
            Get
                VendorCollected = _VendorCollected.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _VendorCollected = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Vendor Collected" & vbCrLf & "Quote")>
        Public Property VendorCollectedQuote() As Nullable(Of Decimal)
            Get
                VendorCollectedQuote = _VendorCollectedQuote.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _VendorCollectedQuote = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorCollectedCopy() As Nullable(Of Decimal)
            Get
                VendorCollectedCopy = _VendorCollectedCopy.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _VendorCollectedCopy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Paid with" & vbCrLf & "Order Amount")>
        Public Property PaidWithOrderAmount() As Nullable(Of Decimal)
            Get
                PaidWithOrderAmount = _PaidWithOrderAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _PaidWithOrderAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Billed" & vbCrLf & "Amount")>
        Public Property BilledAmount() As Decimal
            Get
                BilledAmount = _BilledAmount
            End Get
            Set(value As Decimal)
                _BilledAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Cash" & vbCrLf & "Received")>
        Public Property CashReceived() As Nullable(Of Decimal)
            Get
                CashReceived = _CashReceived.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _CashReceived = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Total")>
        Public Property UnbilledTotal() As Nullable(Of Decimal)
            Get
                UnbilledTotal = _UnbilledTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Newspaper" & vbCrLf & "Cost (Rate)", PropertyType:=BaseClasses.Methods.PropertyTypes.NewspaperCostRate)>
        Public Property NewspaperCostRate() As String
            Get

                If _MediaFrom = "Newspaper" Then
                    NewspaperCostRate = _NewspaperCost.PadRight(3, " ") & _NewspaperRate
                Else
                    NewspaperCostRate = Nothing
                End If

            End Get
            Set(value As String)

                _NewspaperCostRate = value

                If Not String.IsNullOrWhiteSpace(value) Then

                    _NewspaperCost = value.Substring(0, 3)
                    _NewspaperRate = value.Substring(3, 3)

                End If

            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Internet" & vbCrLf & "Cost Type", PropertyType:=BaseClasses.Methods.PropertyTypes.InternetCostType)>
        Public Property InternetCostType() As String
            Get
                InternetCostType = _InternetCostType
            End Get
            Set(value As String)
                _InternetCostType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n4", IsAutoFillProperty:=True)>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0", CustomColumnCaption:="Projected" & vbCrLf & "Impressions", UseMaxValue:=True, MaxValue:=999999999, UseMinValue:=True, MinValue:=-999999999)>
        Public Property ProjectedImpressions() As Nullable(Of Integer)
            Get
                ProjectedImpressions = _ProjectedImpressions.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Integer))
                _ProjectedImpressions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0", CustomColumnCaption:="Guaranteed" & vbCrLf & "Impressions", UseMaxValue:=True, MaxValue:=999999999, UseMinValue:=True, MinValue:=-999999999)>
        Public Property GuaranteedImpressions() As Nullable(Of Integer)
            Get
                GuaranteedImpressions = _GuaranteedImpressions.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Integer))
                _GuaranteedImpressions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0", CustomColumnCaption:="Actual" & vbCrLf & "Impressions")>
        Public Property ActualImpressions() As Nullable(Of Integer)
            Get
                ActualImpressions = _ActualImpressions.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Integer))
                _ActualImpressions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property QuoteColumnUpdated() As Boolean
            Get
                QuoteColumnUpdated = _QuoteColumnUpdated
            End Get
            Set(value As Boolean)
                _QuoteColumnUpdated = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ReviseUpdateOrder() As Boolean
            Get
                ReviseUpdateOrder = _ReviseUpdateOrder
            End Get
            Set(value As Boolean)
                _ReviseUpdateOrder = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Extended" & vbCrLf & "Close Date")>
        Public Property ExtendedCloseDate() As Nullable(Of Date)
            Get
                ExtendedCloseDate = _ExtendedCloseDate
            End Get
            Set(value As Nullable(Of Date))
                _ExtendedCloseDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Extended" & vbCrLf & "Material Date")>
        Public Property ExtendedMaterialDate() As Nullable(Of Date)
            Get
                ExtendedMaterialDate = _ExtendedMaterialDate
            End Get
            Set(value As Nullable(Of Date))
                _ExtendedMaterialDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Internet" & vbCrLf & "Type", PropertyType:=BaseClasses.Methods.PropertyTypes.InternetType, IsAutoFillProperty:=True)>
        Public Property InternetType() As String
            Get
                InternetType = _InternetType
            End Get
            Set(value As String)
                _InternetType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Internet" & vbCrLf & "Placement", IsAutoFillProperty:=True)>
        Public Property InternetPlacement1() As String
            Get
                InternetPlacement1 = _InternetPlacement1
            End Get
            Set(value As String)
                _InternetPlacement1 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Package" & vbCrLf & "Name", IsAutoFillProperty:=True)>
        Public Property InternetPlacement2() As String
            Get
                InternetPlacement2 = _InternetPlacement2
            End Get
            Set(value As String)
                _InternetPlacement2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Internet" & vbCrLf & "URL", IsAutoFillProperty:=True)>
        Public Property InternetURL() As String
            Get
                InternetURL = _InternetURL
            End Get
            Set(value As String)
                _InternetURL = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Target" & vbCrLf & "Audience", IsAutoFillProperty:=True)>
        Public Property InternetTargetAudience() As String
            Get
                InternetTargetAudience = _InternetTargetAudience
            End Get
            Set(value As String)
                _InternetTargetAudience = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Issue", IsAutoFillProperty:=True)>
        Public Property Issue() As String
            Get
                Issue = _Issue
            End Get
            Set(value As String)
                _Issue = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Production" & vbCrLf & "Size", IsAutoFillProperty:=True)>
        Public Property ProductionSize() As String
            Get
                ProductionSize = _ProductionSize
            End Get
            Set(value As String)
                _ProductionSize = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0", CustomColumnCaption:="Magazine" & vbCrLf & "Circulation/QTY", IsAutoFillProperty:=True, UseMaxValue:=True, MaxValue:=999999999, UseMinValue:=True, MinValue:=-999999999)>
        Public Property MagazineCirculationQTY() As Nullable(Of Integer)
            Get
                MagazineCirculationQTY = _MagazineCirculationQTY
            End Get
            Set(value As Nullable(Of Integer))
                _MagazineCirculationQTY = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Newspaper" & vbCrLf & "Section", IsAutoFillProperty:=True)>
        Public Property NewspaperSection() As String
            Get
                NewspaperSection = _NewspaperSection
            End Get
            Set(value As String)
                _NewspaperSection = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Newspaper" & vbCrLf & "Quantity", UseMaxValue:=True, MaxValue:=999999999, UseMinValue:=True, MinValue:=0)>
        Public Property NewspaperCirculationQTY() As Nullable(Of Decimal)
            Get
                NewspaperCirculationQTY = _NewspaperCirculationQTY.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NewspaperCirculationQTY = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0", CustomColumnCaption:="Newspaper" & vbCrLf & "Circulation", IsAutoFillProperty:=True, UseMaxValue:=True, MaxValue:=999999999, UseMinValue:=True, MinValue:=0)>
        Public Property NewspaperCirculation() As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Newspaper" & vbCrLf & "Columns", UseMaxValue:=True, MaxValue:=9999.99, UseMinValue:=True, MinValue:=0)>
        Public Property NewspaperColumns() As Nullable(Of Decimal)
            Get
                NewspaperColumns = _NewspaperColumns.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NewspaperColumns = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Newspaper" & vbCrLf & "Inches", UseMaxValue:=True, MaxValue:=9999.99, UseMinValue:=True, MinValue:=0)>
        Public Property NewspaperInches() As Nullable(Of Decimal)
            Get
                NewspaperInches = _NewspaperInches.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NewspaperInches = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Outdoor" & vbCrLf & "Type", PropertyType:=BaseClasses.Methods.PropertyTypes.OutOfHomeType, IsAutoFillProperty:=True)>
        Public Property OutdoorType() As String
            Get
                OutdoorType = _OutdoorType
            End Get
            Set(value As String)
                _OutdoorType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Outdoor" & vbCrLf & "Location", IsAutoFillProperty:=True)>
        Public Property OutdoorLocation() As String
            Get
                OutdoorLocation = _OutdoorLocation
            End Get
            Set(value As String)
                _OutdoorLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Outdoor" & vbCrLf & "Copy Area", IsAutoFillProperty:=True)>
        Public Property OutdoorCopyArea() As String
            Get
                OutdoorCopyArea = _OutdoorCopyArea
            End Get
            Set(value As String)
                _OutdoorCopyArea = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Broadcast" & vbCrLf & "Start Time", IsAutoFillProperty:=True)>
        Public Property BroadcastStartTime() As String
            Get
                BroadcastStartTime = _BroadcastStartTime
            End Get
            Set(value As String)
                _BroadcastStartTime = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Broadcast" & vbCrLf & "End Time", IsAutoFillProperty:=True)>
        Public Property BroadcastEndTime() As String
            Get
                BroadcastEndTime = _BroadcastEndTime
            End Get
            Set(value As String)
                _BroadcastEndTime = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Broadcast" & vbCrLf & "Programming", IsAutoFillProperty:=True)>
        Public Property BroadcastProgramming() As String
            Get
                BroadcastProgramming = _BroadcastProgramming
            End Get
            Set(value As String)
                _BroadcastProgramming = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Broadcast" & vbCrLf & "Network Code")>
        Public Property BroadcastNetworkCode() As String
            Get
                BroadcastNetworkCode = _BroadcastNetworkCode
            End Get
            Set(value As String)
                _BroadcastNetworkCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Broadcast" & vbCrLf & "Length", IsAutoFillProperty:=True, UseMaxValue:=True, MaxValue:=999, UseMinValue:=True, MinValue:=-999)>
        Public Property BroadcastLength() As Nullable(Of Short)
            Get
                BroadcastLength = _BroadcastLength
            End Get
            Set(value As Nullable(Of Short))
                _BroadcastLength = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Broadcast" & vbCrLf & "Remarks", IsAutoFillProperty:=True)>
        Public Property BroadcastRemarks() As String
            Get
                BroadcastRemarks = _BroadcastRemarks
            End Get
            Set(value As String)
                _BroadcastRemarks = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Broadcast" & vbCrLf & "Days of Week")>
        Public Property BroadcastDaysofWeek() As String
            Get
                BroadcastDaysofWeek = _BroadcastDaysofWeek
            End Get
            Set(value As String)
                _BroadcastDaysofWeek = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Gross" & vbCrLf & "Amount")>
        Public Property GrossAmount() As Nullable(Of Decimal)
            Get
                GrossAmount = _GrossAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _GrossAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Billing" & vbCrLf & "User")>
        Public Property BillingUser() As String
            Get
                BillingUser = _BillingUser
            End Get
            Set(value As String)
                _BillingUser = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Payment" & vbCrLf & "Method")>
        Public Property PaymentMethod() As String
            Get
                PaymentMethod = _PaymentMethod
            End Get
            Set(value As String)
                _PaymentMethod = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="AP Posted" & vbCrLf & "Variance")>
        Public ReadOnly Property APPostedVariance() As Decimal
            Get
                If Me.BillTypeFlag = AdvantageFramework.Database.Entities.BillTypeFlag.CommissionOnly Then
                    APPostedVariance = 0
                Else
                    APPostedVariance = Me.ActualAmountPosted.GetValueOrDefault(0) - Me.TotalCostPayableToVendor.GetValueOrDefault(0)
                End If
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Vendor Collected" & vbCrLf & "Variance")>
        Public ReadOnly Property VendorCollectedVariance() As Decimal
            Get
                VendorCollectedVariance = Me.VendorCollected.GetValueOrDefault(0) - Me.TotalCostPayableToVendor.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", IsReadOnlyColumn:=True, CustomColumnCaption:="VCC Cleared" & vbCrLf & "Amount")>
        Public Property VCCClearedAmount() As Nullable(Of Decimal)
            Get
                VCCClearedAmount = _VCCClearedAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _VCCClearedAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="VCC Cleared" & vbCrLf & "Variance")>
        Public ReadOnly Property VCCClearedVariance() As Nullable(Of Decimal)
            Get
                VCCClearedVariance = Me.VCCClearedAmount.GetValueOrDefault(0) - Me.TotalCostPayableToVendor.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Adjusted" & vbCrLf & "Markup %")>
        Public ReadOnly Property AdjustedMarkupPercent() As Decimal
            Get
                AdjustedMarkupPercent = If(Me.NetAmount.GetValueOrDefault(0) <> 0, (Me.CommissionAmount.GetValueOrDefault(0) + Me.AdditionalChargeAmount.GetValueOrDefault(0)) / Me.NetAmount.GetValueOrDefault(0) * 100, 0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Margin %")>
        Public ReadOnly Property MarginPercent() As Decimal
            Get
                MarginPercent = If(Me.GrossAmount.GetValueOrDefault(0) <> 0, (Me.CommissionAmount.GetValueOrDefault(0) + Me.AdditionalChargeAmount.GetValueOrDefault(0)) / Me.GrossAmount.GetValueOrDefault(0) * 100, 0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Cleared %")>
        Public ReadOnly Property ClearedPercent() As Decimal
            Get
                ClearedPercent = If(Me.TotalCostPayableToVendor.GetValueOrDefault(0) <> 0, Me.VCCClearedAmount.GetValueOrDefault(0) / Me.TotalCostPayableToVendor.GetValueOrDefault(0) * 100, 0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property OrderLineIsBilled() As Boolean
            Get
                OrderLineIsBilled = _OrderLineIsBilled
            End Get
            Set(value As Boolean)
                _OrderLineIsBilled = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VCCCardID() As Nullable(Of Integer)
            Get
                VCCCardID = _VCCCardID
            End Get
            Set(value As Nullable(Of Integer))
                _VCCCardID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property OrderNumberLineNumber() As String
            Get
                OrderNumberLineNumber = Me.OrderNumber.ToString & "|" & Me.LineNumber.ToString
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property NewspaperCost() As String
            Get
                NewspaperCost = _NewspaperCost
            End Get
            Set(value As String)
                _NewspaperCost = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property NewspaperRate() As String
            Get
                NewspaperRate = _NewspaperRate
            End Get
            Set(value As String)
                _NewspaperRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsDailyNewspaper() As Boolean
            Get
                IsDailyNewspaper = _IsDailyNewspaper
            End Get
            Set(value As Boolean)
                _IsDailyNewspaper = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ProcessControl() As Nullable(Of Short)
            Get
                ProcessControl = _ProcessControl
            End Get
            Set(value As Nullable(Of Short))
                _ProcessControl = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property JobMediaBillDateColumnUpdated() As Boolean
            Get
                JobMediaBillDateColumnUpdated = _JobMediaBillDateColumnUpdated
            End Get
            Set(value As Boolean)
                _JobMediaBillDateColumnUpdated = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ImportedFrom() As String
            Get
                ImportedFrom = _ImportedFrom
            End Get
            Set(value As String)
                _ImportedFrom = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property IsOrderClosed() As Boolean
            Get
                IsOrderClosed = IIf(_ProcessControl.HasValue AndAlso _ProcessControl.Value = 6, True, False)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job or Media" & vbCrLf & "Date to Bill", IsReadOnlyColumn:=True)>
        Public Property JobOrMediaDateToBill() As Nullable(Of Date)
            Get
                JobOrMediaDateToBill = _JobOrMediaDateToBill
            End Get
            Set(value As Nullable(Of Date))
                _JobOrMediaDateToBill = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.Methods.PropertyTypes.BillingCoopCode, CustomColumnCaption:="Coop" & vbCrLf & "Code", IsAutoFillProperty:=True)>
        Public Property BillCoopCode As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Campaign" & vbCrLf & "Start")>
        Public Property CampaignStartDate As Nullable(Of Date)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Campaign" & vbCrLf & "End")>
        Public Property CampaignEndDate As Nullable(Of Date)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Ad" & vbCrLf & "Server")>
        Public Property AdServerName As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Ad Server" & vbCrLf & "Placement ID")>
        Public Property AdServerPlacementID As Nullable(Of Long)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Ad Server" & vbCrLf & "Package ID")>
        Public Property AdServerPackageID As Nullable(Of Long)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property OrderQtySpots() As Integer
            Get
                OrderQtySpots = Me.Spots.GetValueOrDefault(0) + Me.ActualImpressions.GetValueOrDefault(0)
            End Get
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Package" & vbCrLf & "Parent")>
        'Public Property PackageParent As Boolean
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Order" & vbCrLf & "Accepted")>
        Public Property OrderAccepted As Boolean
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property RevisedBy As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BillTypeFlag() As Nullable(Of Short)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property APExists() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property WorksheetLineNumber() As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property SourceCode As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property WorksheetID As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property WorksheetName As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property PlanID As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property PlanName As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EstimateID As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EstimateName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MatCompDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DCProfileID() As Nullable(Of Long)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property DCReportID() As Nullable(Of Long)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Line Market" & vbCrLf & "Code", PropertyType:=BaseClasses.Methods.PropertyTypes.MarketCode, IsReadOnlyColumn:=True)>
        Public Property LineMarketCode() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Line Market" & vbCrLf & "Description")>
        Public Property LineMarketDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Media" & vbCrLf & "Channel", PropertyType:=BaseClasses.Methods.PropertyTypes.MediaChannelID, IsReadOnlyColumn:=True)>
        Public Property MediaChannelID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Media" & vbCrLf & "Tactic", PropertyType:=BaseClasses.Methods.PropertyTypes.MediaTacticID, IsReadOnlyColumn:=True)>
        Public Property MediaTacticID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaPlanID As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaPlanDetailID As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Function Copy() As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail

            Dim ClassCopy As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing
            Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            XmlSerializer = New System.Xml.Serialization.XmlSerializer(Me.GetType)
            MemoryStream = New System.IO.MemoryStream

            XmlSerializer.Serialize(MemoryStream, Me)
            MemoryStream.Seek(0, IO.SeekOrigin.Begin)

            Try

                ClassCopy = CType(XmlSerializer.Deserialize(MemoryStream), AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)

            Catch ex As Exception
                ClassCopy = Nothing
            End Try

            Copy = ClassCopy

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            For Each PropertyDescriptor In PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperCostRate.ToString

                        If _MediaFrom = "Newspaper" Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetCostType.ToString

                        If _MediaFrom = "Internet" Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.EndDate.ToString

                        If _MediaFrom = "Out Of Home" OrElse (_MediaFrom = "Newspaper" AndAlso _IsDailyNewspaper) Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                End Select

            Next

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.CloseDate.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso _StartDate.HasValue Then

                        If PropertyValue > _StartDate.Value Then

                            IsValid = False

                            ErrorText = "Close date must be before or the same as start date."

                        End If

                    End If

                Case AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.MaterialDate.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso _StartDate.HasValue Then

                        If PropertyValue > _StartDate.Value Then

                            IsValid = False

                            ErrorText = "Material date must be before or the same as start date."

                        End If

                    End If

                Case AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobMediaBillDateColumnUpdated.ToString

                    If Me.IsOrderClosed Then

                        IsValid = True

                        ErrorText = "Order is closed."

                    ElseIf _Cancelled Then

                        IsValid = True

                        ErrorText = "Order Line is cancelled."

                    ElseIf Not String.IsNullOrWhiteSpace(_BillingUser) Then

                        IsValid = True

                        ErrorText = "Order Line is selected for billing."

                    End If

                Case AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdNumber.ToString

                    PropertyValue = Value

                    If Not String.IsNullOrWhiteSpace(PropertyValue) AndAlso (From Entity In AdvantageFramework.MediaManager.GetAdNumberDatasource(DbContext, Me.ClientCode)
                                                                             Where Entity.Number = DirectCast(PropertyValue, String)
                                                                             Select Entity).Any = False Then

                        IsValid = False

                        ErrorText = "Invalid Ad Number."

                    End If

                Case AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdSizeCode.ToString

                    PropertyValue = Value

                    If Not String.IsNullOrWhiteSpace(PropertyValue) AndAlso (From Entity In AdvantageFramework.MediaManager.GetAdSizeCodeDatasource(DbContext, Me.MediaFrom.Substring(0, 1))
                                                                             Where Entity.Code = DirectCast(PropertyValue, String)
                                                                             Select Entity).Any = False Then

                        IsValid = False

                        ErrorText = "Invalid Ad Size Code."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Sub SetCloseAndMaterialDates(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim OrderDate As AdvantageFramework.MediaManager.Classes.OrderDate = Nothing

            If _StartDate.HasValue Then

                OrderDate = AdvantageFramework.MediaManager.LoadOrderDate(DbContext, Mid(Me.MediaFrom, 1, 1), _StartDate.Value, If(Me.NetGross = "Gross", 1, 0), Me.VendorCode)

                _MaterialDate = OrderDate.MATL_CLOSE_DATE
                _CloseDate = OrderDate.SPACE_CLOSE_DATE

            End If

        End Sub

#End Region

    End Class

End Namespace
