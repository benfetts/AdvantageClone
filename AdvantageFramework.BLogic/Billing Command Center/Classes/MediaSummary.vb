Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class MediaSummary
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            OrderNumber
            LineNumber
            RevisionNumber
            OfficeCode
            CampaignID
            CampaignCode
            CampaignName
            SalesClassCode
            SalesClassDescription
            MarketCode
            MarketDescription
            VendorCode
            VendorName
            ClientPO
            LinkID
            BillingCoopCode
            Buyer
            MaxRevision
            OrderDescription
            MediaFrom
            OrderDate
            InsertionDate
            BroadcastMonth
            CloseDate
            DateToBill
            BillingUser
            NetAmount
            CommissionAmount
            RebateAmount
            AdditionalChargeAmount
            DiscountAmount
            NetChargeAmount
            VendorTaxAmount
            BillableAmount
            ResaleTaxAmount
            BillableTotal
            APPostedAmount
            BilledAmount
            BilledResaleTax
            BilledTotal
            UnbilledAmount
            UnbilledResaleTax
            UnbilledTotal
            HasUnbilled
            AmountSelectedforBilling
            BillStatus
            IsSetupComplete
            OrderProcessControl
            MonthYear
            BillType
            BillingSelectionSelect
            IsSelected
            BillingSelectionResult
            OfficeDescription
            JobNumber
            JobComponentNumber
            LinkLineID
            Spots
            Headline
            Programming
            JobMediaDateToBill
            JobDescription
            CompDescription
            HasBillingApprovalStatus
            BillingApprovedDateBy
            GrossAmount
            AdjustedMarkupPercent
            MarginPercent
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _OrderNumber As Integer = Nothing
        Private _LineNumber As Nullable(Of Integer) = Nothing
        Private _RevisionNumber As Nullable(Of Integer) = Nothing
        Private _OfficeCode As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _ClientPO As String = Nothing
        Private _LinkID As Nullable(Of Integer) = Nothing
        Private _BillingCoopCode As String = Nothing
        Private _MarketCode As String = Nothing
        Private _MarketDescription As String = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _Buyer As String = Nothing
        Private _MaxRevision As Nullable(Of Integer) = Nothing
        Private _OrderDescription As String = Nothing
        Private _MediaFrom As String = Nothing
        Private _OrderDate As Nullable(Of Date) = Nothing
        Private _InsertionDate As Nullable(Of Date) = Nothing
        Private _BroadcastMonth As Nullable(Of Date) = Nothing
        Private _CloseDate As Nullable(Of Date) = Nothing
        Private _DateToBill As Nullable(Of Date) = Nothing
        Private _BillingUser As String = Nothing
        Private _NetAmount As Nullable(Of Decimal) = Nothing
        Private _CommissionAmount As Nullable(Of Decimal) = Nothing
        Private _RebateAmount As Nullable(Of Decimal) = Nothing
        Private _AdditionalChargeAmount As Nullable(Of Decimal) = Nothing
        Private _DiscountAmount As Nullable(Of Decimal) = Nothing
        Private _NetChargeAmount As Nullable(Of Decimal) = Nothing
        Private _VendorTaxAmount As Nullable(Of Decimal) = Nothing
        Private _ResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _BillableTotal As Nullable(Of Decimal) = Nothing
        Private _BilledTotal As Nullable(Of Decimal) = Nothing
        Private _HasUnbilled As Nullable(Of Boolean) = Nothing
        Private _UnbilledTotal As Nullable(Of Decimal) = Nothing
        Private _APPostedAmount As Nullable(Of Decimal) = Nothing
        Private _AmountSelectedforBilling As Nullable(Of Decimal) = Nothing
        Private _BillStatus As Integer = Nothing
        Private _IsSetupComplete As Nullable(Of Short) = Nothing
        Private _OrderProcessControl As String = Nothing
        Private _MonthYear As String = Nothing
        Private _BillType As String = Nothing
        Private _BillingSelectionSelect As Boolean = False
        Private _BillingSelectionResult As String = Nothing
        Private _OfficeDescription As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _LinkLineID As Nullable(Of Integer) = Nothing
        Private _BilledResaleTax As Nullable(Of Decimal) = Nothing
        Private _Spots As Nullable(Of Integer) = Nothing
        Private _Headline As String = Nothing
        Private _Programming As String = Nothing
        Private _JobMediaDateToBill As Nullable(Of Date) = Nothing
        Private _JobDescription As String = Nothing
        Private _CompDescription As String = Nothing
        Private _HasBillingApprovalStatus As Boolean = False
        Private _BillingApprovedDateBy As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Bill" & vbCrLf & "Status")>
        Public Property BillStatus() As Integer
            Get
                BillStatus = _BillStatus
            End Get
            Set(value As Integer)
                _BillStatus = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Bill" & vbCrLf & "Type")>
        Public Property BillType() As String
            Get
                BillType = _BillType
            End Get
            Set(value As String)
                _BillType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Office" & vbCrLf & "Code")>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Office" & vbCrLf & "Description")>
        Public Property OfficeDescription() As String
            Get
                OfficeDescription = _OfficeDescription
            End Get
            Set(value As String)
                _OfficeDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client" & vbCrLf & "Code")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client" & vbCrLf & "Name")>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division" & vbCrLf & "Code")>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division" & vbCrLf & "Name")>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product" & vbCrLf & "Code")>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product" & vbCrLf & "Description")>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Order" & vbCrLf & "Number")>
        Public Property OrderNumber() As Integer
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Integer)
                _OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Order" & vbCrLf & "Description")>
        Public Property OrderDescription() As String
            Get
                OrderDescription = _OrderDescription
            End Get
            Set(value As String)
                _OrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Campaign" & vbCrLf & "ID")>
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(value As Nullable(Of Integer))
                _CampaignID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Campaign" & vbCrLf & "Code")>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Campaign" & vbCrLf & "Description")>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(value As String)
                _CampaignName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="SC" & vbCrLf & "Code")>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="SC" & vbCrLf & "Description")>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client" & vbCrLf & "PO")>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(value As String)
                _ClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Link" & vbCrLf & "ID")>
        Public Property LinkID() As Nullable(Of Integer)
            Get
                LinkID = _LinkID
            End Get
            Set(value As Nullable(Of Integer))
                _LinkID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Billing" & vbCrLf & "Co-op Code")>
        Public Property BillingCoopCode() As String
            Get
                BillingCoopCode = _BillingCoopCode
            End Get
            Set(value As String)
                _BillingCoopCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Market" & vbCrLf & "Code")>
        Public Property MarketCode() As String
            Get
                MarketCode = _MarketCode
            End Get
            Set(value As String)
                _MarketCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Market" & vbCrLf & "Description")>
        Public Property MarketDescription() As String
            Get
                MarketDescription = _MarketDescription
            End Get
            Set(value As String)
                _MarketDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Vendor" & vbCrLf & "Code")>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Vendor" & vbCrLf & "Description")>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(value As String)
                _VendorName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Buyer() As String
            Get
                Buyer = _Buyer
            End Get
            Set(value As String)
                _Buyer = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Line" & vbCrLf & "Number")>
        Public Property LineNumber() As Nullable(Of Integer)
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Nullable(Of Integer))
                _LineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Insertion/" & vbCrLf & "Run Date")>
        Public Property InsertionDate() As Nullable(Of Date)
            Get
                InsertionDate = _InsertionDate
            End Get
            Set(value As Nullable(Of Date))
                _InsertionDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Month/" & vbCrLf & "Year")>
        Public Property MonthYear() As String
            Get
                MonthYear = _MonthYear
            End Get
            Set(value As String)
                _MonthYear = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Close" & vbCrLf & "Date")>
        Public Property CloseDate() As Nullable(Of Date)
            Get
                CloseDate = _CloseDate
            End Get
            Set(value As Nullable(Of Date))
                _CloseDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Date" & vbCrLf & "to Bill")>
        Public Property DateToBill() As Nullable(Of Date)
            Get
                DateToBill = _DateToBill
            End Get
            Set(value As Nullable(Of Date))
                _DateToBill = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Spots() As Nullable(Of Integer)
            Get
                Spots = _Spots
            End Get
            Set(value As Nullable(Of Integer))
                _Spots = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Net" & vbCrLf & "Amount")>
        Public Property NetAmount() As Nullable(Of Decimal)
            Get
                NetAmount = _NetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Commission" & vbCrLf & "Amount")>
        Public Property CommissionAmount() As Nullable(Of Decimal)
            Get
                CommissionAmount = _CommissionAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _CommissionAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Rebate" & vbCrLf & "Amount")>
        Public Property RebateAmount() As Nullable(Of Decimal)
            Get
                RebateAmount = _RebateAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _RebateAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Additional" & vbCrLf & "Charge Amount")>
        Public Property AdditionalChargeAmount() As Nullable(Of Decimal)
            Get
                AdditionalChargeAmount = _AdditionalChargeAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdditionalChargeAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Discount" & vbCrLf & "Amount")>
        Public Property DiscountAmount() As Nullable(Of Decimal)
            Get
                DiscountAmount = _DiscountAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _DiscountAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Net Charge" & vbCrLf & "Amount")>
        Public Property NetChargeAmount() As Nullable(Of Decimal)
            Get
                NetChargeAmount = _NetChargeAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NetChargeAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Non Resale" & vbCrLf & "Tax")>
        Public Property VendorTaxAmount() As Nullable(Of Decimal)
            Get
                VendorTaxAmount = _VendorTaxAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _VendorTaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Billable" & vbCrLf & "Amount")>
        Public ReadOnly Property BillableAmount() As Decimal
            Get
                BillableAmount = _BillableTotal.GetValueOrDefault(0) - _ResaleTaxAmount.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Resale" & vbCrLf & "Tax")>
        Public Property ResaleTaxAmount() As Nullable(Of Decimal)
            Get
                ResaleTaxAmount = _ResaleTaxAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ResaleTaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Billable" & vbCrLf & "Total")>
        Public Property BillableTotal() As Nullable(Of Decimal)
            Get
                BillableTotal = _BillableTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BillableTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Actual" & vbCrLf & "Amount Posted")>
        Public Property APPostedAmount() As Nullable(Of Decimal)
            Get
                APPostedAmount = _APPostedAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _APPostedAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Billed" & vbCrLf & "Amount")>
        Public ReadOnly Property BilledAmount() As Decimal
            Get
                BilledAmount = _BilledTotal.GetValueOrDefault(0) - _BilledResaleTax.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Billed" & vbCrLf & "Resale Tax")>
        Public Property BilledResaleTax() As Nullable(Of Decimal)
            Get
                BilledResaleTax = _BilledResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Billed" & vbCrLf & "Total")>
        Public Property BilledTotal() As Nullable(Of Decimal)
            Get
                BilledTotal = _BilledTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Amount")>
        Public ReadOnly Property UnbilledAmount() As Decimal
            Get
                UnbilledAmount = _UnbilledTotal.GetValueOrDefault(0) - Me.UnbilledResaleTax
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Resale Tax")>
        Public ReadOnly Property UnbilledResaleTax() As Decimal
            Get
                UnbilledResaleTax = _ResaleTaxAmount.GetValueOrDefault(0) - _BilledResaleTax.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Total")>
        Public Property UnbilledTotal() As Nullable(Of Decimal)
            Get
                UnbilledTotal = _UnbilledTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Order Process" & vbCrLf & "Control")>
        Public Property OrderProcessControl() As String
            Get
                OrderProcessControl = _OrderProcessControl
            End Get
            Set(value As String)
                _OrderProcessControl = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BillingUser() As String
            Get
                BillingUser = _BillingUser
            End Get
            Set(value As String)
                _BillingUser = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Amount Selected" & vbCrLf & "for Billing")>
        Public Property AmountSelectedforBilling() As Decimal
            Get
                AmountSelectedforBilling = _AmountSelectedforBilling
            End Get
            Set(value As Decimal)
                _AmountSelectedforBilling = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, CustomColumnCaption:="Media Type")>
        Public Property MediaFrom() As String
            Get
                MediaFrom = _MediaFrom
            End Get
            Set(value As String)
                _MediaFrom = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Select", ShowColumnInGrid:=False)>
        Public Property BillingSelectionSelect() As Boolean
            Get
                BillingSelectionSelect = _BillingSelectionSelect
            End Get
            Set(value As Boolean)
                _BillingSelectionSelect = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Select", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public ReadOnly Property IsSelected() As Boolean
            Get
                IsSelected = If(_BillingUser IsNot Nothing, True, False)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, CustomColumnCaption:="Result")>
        Public Property BillingSelectionResult() As String
            Get
                BillingSelectionResult = _BillingSelectionResult
            End Get
            Set(value As String)
                _BillingSelectionResult = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job" & vbCrLf & "Number")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Component" & vbCrLf & "Number")>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Link" & vbCrLf & "Line ID")>
        Public Property LinkLineID() As Nullable(Of Integer)
            Get
                LinkLineID = _LinkLineID
            End Get
            Set(value As Nullable(Of Integer))
                _LinkLineID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Headline() As String
            Get
                Headline = _Headline
            End Get
            Set(value As String)
                _Headline = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Programming() As String
            Get
                Programming = _Programming
            End Get
            Set(value As String)
                _Programming = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job Media" & vbCrLf & "Date to Bill")>
        Public Property JobMediaDateToBill() As Nullable(Of Date)
            Get
                JobMediaDateToBill = _JobMediaDateToBill
            End Get
            Set(value As Nullable(Of Date))
                _JobMediaDateToBill = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job" & vbCrLf & "Description")>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Comp" & vbCrLf & "Description")>
        Public Property CompDescription() As String
            Get
                CompDescription = _CompDescription
            End Get
            Set(value As String)
                _CompDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox, CustomColumnCaption:="Billing" & vbCrLf & "Approval Status")>
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
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property GrossAmount() As Decimal
            Get
                GrossAmount = Me.NetAmount.GetValueOrDefault(0) + Me.CommissionAmount.GetValueOrDefault(0)
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
                MarginPercent = If(Me.GrossAmount <> 0, (Me.CommissionAmount.GetValueOrDefault(0) + Me.AdditionalChargeAmount.GetValueOrDefault(0)) / Me.GrossAmount * 100, 0)
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace