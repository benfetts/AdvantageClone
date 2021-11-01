Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class BillingWorksheetMediaReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            AccountExecutive
            AECode
            AEFirstName
            AELastName
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
            BillingCoopDescription
            Buyer
            MaxRevision
            OrderDescription
            MediaFrom
            OrderDate
            InsertionDate
            BroadcastMonth
            CloseDate
            DateToBill
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
            FiscalPeriod
            StartDate
            EndDate
            BillingUser
            Headline
            Programming
            JobMediaDateToBill
            Units
            MonthNumber
            YearNumber
            BillingBatchName
        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _AccountExecutive As String = Nothing
        Private _AECode As String = Nothing
        Private _AEFirstName As String = Nothing
        Private _AELastName As String = Nothing
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
        Private _BillingCoopDescription As String = Nothing
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
        Private _BillStatus As String = Nothing
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
        Private _FiscalPeriod As String = Nothing
        Private _StartDate As Nullable(Of Date) = Nothing
        Private _EndDate As Nullable(Of Date) = Nothing
        Private _BillingUser As String = Nothing
        Private _Headline As String = Nothing
        Private _Programming As String = Nothing
        Private _JobMediaDateToBill As Nullable(Of Date) = Nothing
        Private _Units As String = Nothing
        Private _MonthNumber As Nullable(Of Short) = Nothing
        Private _YearNumber As Nullable(Of Short) = Nothing
        Private _BillingBatchName As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
            Get
                ID = _ID
            End Get
            Set(ByVal value As System.Guid)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Order Type")>
        Public Property MediaFrom() As String
            Get
                MediaFrom = _MediaFrom
            End Get
            Set(value As String)
                _MediaFrom = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OfficeDescription() As String
            Get
                OfficeDescription = _OfficeDescription
            End Get
            Set(value As String)
                _OfficeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AccountExecutive() As String
            Get
                AccountExecutive = _AccountExecutive
            End Get
            Set(value As String)
                _AccountExecutive = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AECode() As String
            Get
                AECode = _AECode
            End Get
            Set(value As String)
                _AECode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AEFirstName() As String
            Get
                AEFirstName = _AEFirstName
            End Get
            Set(value As String)
                _AEFirstName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AELastName() As String
            Get
                AELastName = _AELastName
            End Get
            Set(value As String)
                _AELastName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property OrderNumber() As Integer
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Integer)
                _OrderNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OrderDescription() As String
            Get
                OrderDescription = _OrderDescription
            End Get
            Set(value As String)
                _OrderDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(value As Nullable(Of Integer))
                _CampaignID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Campaign Description")>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(value As String)
                _CampaignName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MarketCode() As String
            Get
                MarketCode = _MarketCode
            End Get
            Set(value As String)
                _MarketCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MarketDescription() As String
            Get
                MarketDescription = _MarketDescription
            End Get
            Set(value As String)
                _MarketDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(value As String)
                _VendorName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Billing Co-op Code")>
        Public Property BillingCoopCode() As String
            Get
                BillingCoopCode = _BillingCoopCode
            End Get
            Set(value As String)
                _BillingCoopCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BillingCoopDescription() As String
            Get
                BillingCoopDescription = _BillingCoopDescription
            End Get
            Set(value As String)
                _BillingCoopDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OrderDate() As Nullable(Of Date)
            Get
                OrderDate = _OrderDate
            End Get
            Set(value As Nullable(Of Date))
                _OrderDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FiscalPeriod() As String
            Get
                FiscalPeriod = _FiscalPeriod
            End Get
            Set(value As String)
                _FiscalPeriod = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property LinkID() As Nullable(Of Integer)
            Get
                LinkID = _LinkID
            End Get
            Set(value As Nullable(Of Integer))
                _LinkID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Buyer() As String
            Get
                Buyer = _Buyer
            End Get
            Set(value As String)
                _Buyer = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(value As String)
                _ClientPO = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StartDate() As Nullable(Of Date)
            Get
                StartDate = _StartDate
            End Get
            Set(value As Nullable(Of Date))
                _StartDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EndDate() As Nullable(Of Date)
            Get
                EndDate = _EndDate
            End Get
            Set(value As Nullable(Of Date))
                _EndDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Order Status")>
        Public Property OrderProcessControl() As String
            Get
                OrderProcessControl = _OrderProcessControl
            End Get
            Set(value As String)
                _OrderProcessControl = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property LineNumber() As Nullable(Of Integer)
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Nullable(Of Integer))
                _LineNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Insertion/Post Date")>
        Public Property InsertionDate() As Nullable(Of Date)
            Get
                InsertionDate = _InsertionDate
            End Get
            Set(value As Nullable(Of Date))
                _InsertionDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Month/Year")>
        Public Property MonthYear() As String
            Get
                MonthYear = _MonthYear
            End Get
            Set(value As String)
                _MonthYear = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CloseDate() As Nullable(Of Date)
            Get
                CloseDate = _CloseDate
            End Get
            Set(value As Nullable(Of Date))
                _CloseDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DateToBill() As Nullable(Of Date)
            Get
                DateToBill = _DateToBill
            End Get
            Set(value As Nullable(Of Date))
                _DateToBill = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property NetAmount() As Nullable(Of Decimal)
            Get
                NetAmount = _NetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property NetChargeAmount() As Nullable(Of Decimal)
            Get
                NetChargeAmount = _NetChargeAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NetChargeAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property DiscountAmount() As Nullable(Of Decimal)
            Get
                DiscountAmount = _DiscountAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _DiscountAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property CommissionAmount() As Nullable(Of Decimal)
            Get
                CommissionAmount = _CommissionAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _CommissionAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property RebateAmount() As Nullable(Of Decimal)
            Get
                RebateAmount = _RebateAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _RebateAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AdditionalChargeAmount() As Nullable(Of Decimal)
            Get
                AdditionalChargeAmount = _AdditionalChargeAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdditionalChargeAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Non Resale Tax")>
        Public Property VendorTaxAmount() As Nullable(Of Decimal)
            Get
                VendorTaxAmount = _VendorTaxAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _VendorTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Resale Tax")>
        Public Property ResaleTaxAmount() As Nullable(Of Decimal)
            Get
                ResaleTaxAmount = _ResaleTaxAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ResaleTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property BillableAmount() As Decimal
            Get
                BillableAmount = _BillableTotal.GetValueOrDefault(0) - _ResaleTaxAmount.GetValueOrDefault(0)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property BillableTotal() As Nullable(Of Decimal)
            Get
                BillableTotal = _BillableTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BillableTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property BilledResaleTax() As Nullable(Of Decimal)
            Get
                BilledResaleTax = _BilledResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property BilledTotal() As Nullable(Of Decimal)
            Get
                BilledTotal = _BilledTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property BilledAmount() As Decimal
            Get
                BilledAmount = _BilledTotal.GetValueOrDefault(0) - _BilledResaleTax.GetValueOrDefault(0)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property UnbilledAmount() As Decimal
            Get
                UnbilledAmount = _UnbilledTotal.GetValueOrDefault(0) - Me.UnbilledResaleTax
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property UnbilledResaleTax() As Decimal
            Get
                UnbilledResaleTax = _ResaleTaxAmount.GetValueOrDefault(0) - _BilledResaleTax.GetValueOrDefault(0)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property UnbilledTotal() As Nullable(Of Decimal)
            Get
                UnbilledTotal = _UnbilledTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Actual Amount Posted")>
        Public Property APPostedAmount() As Nullable(Of Decimal)
            Get
                APPostedAmount = _APPostedAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _APPostedAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BillStatus() As String
            Get
                BillStatus = _BillStatus
            End Get
            Set(value As String)
                _BillStatus = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BillType() As String
            Get
                BillType = _BillType
            End Get
            Set(value As String)
                _BillType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BillingUser() As String
            Get
                BillingUser = _BillingUser
            End Get
            Set(value As String)
                _BillingUser = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Headline() As String
            Get
                Headline = _Headline
            End Get
            Set(value As String)
                _Headline = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Programming() As String
            Get
                Programming = _Programming
            End Get
            Set(value As String)
                _Programming = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobMediaDateToBill() As Nullable(Of Date)
            Get
                JobMediaDateToBill = _JobMediaDateToBill
            End Get
            Set(value As Nullable(Of Date))
                _JobMediaDateToBill = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Units() As String
            Get
                Units = _Units
            End Get
            Set(value As String)
                _Units = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MonthNumber() As Nullable(Of Short)
            Get
                MonthNumber = _MonthNumber
            End Get
            Set(value As Nullable(Of Short))
                _MonthNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property YearNumber() As Nullable(Of Short)
            Get
                YearNumber = _YearNumber
            End Get
            Set(value As Nullable(Of Short))
                _YearNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BillingBatchName() As String
            Get
                BillingBatchName = _BillingBatchName
            End Get
            Set(value As String)
                _BillingBatchName = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
