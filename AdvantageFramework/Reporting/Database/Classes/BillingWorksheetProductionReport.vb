Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class BillingWorksheetProductionReport

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
            JobNumber
            JobDescription
            ComponentNumber
            ComponentDescription
            OfficeCode
            OfficeDescription
            CampaignID
            CampaignCode
            CampaignDescription
            SalesClassCode
            SalesClassDescription
            ClientPO
            ClientReference
            EstimateNumber
            EstimateDescription
            EstimateComponentNumber
            EstimateComponentDescription
            BillingCoopCode
            BillingCoopDescription
            ScheduleStatus
            ScheduleCompletedDate
            FunctionHeading
            FunctionCode
            FunctionDescription
            AccountExecutive
            AECode
            AEFirstName
            AELastName
            EstimateHours
            EstimateQuantity
            EstimateNetAmount
            EstimateMarkupAmount
            EstimateAmount
            AmountToBill
            EstimateResaleTax
            EstimateTotal
            ActualBillableHours
            ActualBillableQuantity
            ActualBillableNetAmount
            ActualBillableMarkupAmount
            ActualBillableAmount
            ActualBillableResaleTax
            ActualBillableTotal
            BilledHours
            BilledQuantity
            BilledNet
            BilledMarkup
            BilledAmount
            BilledResaleTax
            BilledTotal
            UnbilledHours
            UnbilledQuantity
            UnbilledNetAmount
            UnbilledMarkupPercentCalc
            UnbilledMarkupAmount
            UnbilledAmount
            UnbilledResaleTax
            UnbilledTotal
            AdvanceHours
            AdvanceQuantity
            AdvanceBilledNetAmount
            AdvanceBilledMarkupAmount
            AdvanceBilledAmount
            AdvanceBilledResaleTax
            AdvanceBilledTotal
            TotalBilledAmount
            TotalBilledTax
            TotalBilled
            UnbilledAdvanceNetAmount
            UnbilledAdvanceMarkupAmount
            UnbilledAdvanceAmount
            UnbilledAdvanceResaleTax
            UnbilledAdvanceTotal
            FlatIncomeRecognized
            NonBillableHours
            NonBillableQuantity
            NonBillableNetAmount
            NonBillableMarkupAmount
            NonBillableAmount
            FeeTimeHours
            FeeAmount
            FeeResaleTax
            FeeTotal
            BillHoldAmount
            OpenPOAmount
            PercentCompleteTime
            PercentCompleteAll
            FunctionType
            FunctionOrder
            FunctionConsolidationCode
            FunctionConsolidationDescription
            BilledOfEstimate
            BillingApprovalFunctionAmount
            BillingApprovalFunctionComment
            BillingApprovalFunctionClientComment
            AdvanceBillRequested
            BillingApprovalDetailID
            FlatIncomeToRecognize
            UnbilledNetOnly
            BillingUser
            GrossIncome
            JobMediaDateToBill
            BillingApprovalBatchID
            BillingApprovalBatchDescription
            BillingApprovalHeaderComment
            BillingApprovalHeaderClientComment
            ItemUnbilledHours
            ItemUnbilledQuantity
            ItemUnbilledNetAmount
            ItemUnbilledMarkupAmount
            ItemUnbilledResaleTax
            ItemUnbilledTotal
            ItemNonBillableHours
            ItemNonBillableQuantity
            ItemNonBillableMarkupAmount
            ItemNonBillableNetAmount
            ItemNonBillableTotalAmount
            ItemBillingTransferFromJob
            ItemBillingTransferFromJobComponent
            ItemBillingTransferFromFunctionCode
            ItemBillingTransferToJob
            ItemBillingTransferToJobComponent
            ItemBillingTransferToFunctionCode
            ItemBillingAdjustmentWriteOffFlag
            ItemBillingTransferAdjustmentUser
            ItemBillingTransferAdjustmentDate
            ItemBillingTransferAdjustmentComment
            ItemID
            ItemDate
            ItemPostPeriodCode
            ItemCode
            ItemDescription
            ItemComment
            ItemFeeFlag
            ItemBillable
            ItemApprovalAmount
            ItemInvoiceNumber
            BillingBatchName
            AdvanceBillingRetained
            ProcessControlDescription
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
        Private _JobNumber As Integer = Nothing
        Private _JobDescription As String = Nothing
        Private _ComponentNumber As Short = Nothing
        Private _ComponentDescription As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeDescription As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignDescription As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _ClientPO As String = Nothing
        Private _ClientReference As String = Nothing
        Private _EstimateNumber As Nullable(Of Integer) = Nothing
        Private _EstimateDescription As String = Nothing
        Private _EstimateComponentNumber As Nullable(Of Short) = Nothing
        Private _EstimateComponentDescription As String = Nothing
        Private _BillingCoopCode As String = Nothing
        Private _BillingCoopDescription As String = Nothing
        Private _ScheduleStatus As String = Nothing
        Private _ScheduleCompletedDate As Nullable(Of Date) = Nothing
        Private _FunctionHeading As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _BillStatus As String = Nothing
        Private _AccountExecutive As String = Nothing
        Private _AECode As String = Nothing
        Private _AEFirstName As String = Nothing
        Private _AELastName As String = Nothing
        Private _EstimateHours As Decimal = Nothing
        Private _EstimateQuantity As Decimal = Nothing
        Private _EstimateNetAmount As Decimal = Nothing
        Private _EstimateMarkupAmount As Decimal = Nothing
        Private _EstimateAmount As Decimal = Nothing
        Private _AmountToBill As Decimal = Nothing
        Private _EstimateResaleTax As Decimal = Nothing
        Private _EstimateTotal As Decimal = Nothing
        Private _ActualBillableHours As Nullable(Of Decimal) = Nothing
        Private _ActualBillableQuantity As Nullable(Of Decimal) = Nothing
        Private _ActualBillableNetAmount As Nullable(Of Decimal) = Nothing
        Private _ActualBillableMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _ActualBillableAmount As Nullable(Of Decimal) = Nothing
        Private _ActualBillableResaleTax As Nullable(Of Decimal) = Nothing
        Private _ActualBillableTotal As Nullable(Of Decimal) = Nothing
        Private _BilledHours As Nullable(Of Decimal) = Nothing
        Private _BilledQuantity As Nullable(Of Decimal) = Nothing
        Private _BilledNet As Nullable(Of Decimal) = Nothing
        Private _BilledMarkup As Nullable(Of Decimal) = Nothing
        Private _BilledAmount As Nullable(Of Decimal) = Nothing
        Private _BilledResaleTax As Nullable(Of Decimal) = Nothing
        Private _BilledTotal As Nullable(Of Decimal) = Nothing
        Private _UnbilledHours As Nullable(Of Decimal) = Nothing
        Private _UnbilledQuantity As Nullable(Of Decimal) = Nothing
        Private _UnbilledNetAmount As Nullable(Of Decimal) = Nothing
        Private _UnbilledMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _UnbilledAmount As Nullable(Of Decimal) = Nothing
        Private _UnbilledResaleTax As Nullable(Of Decimal) = Nothing
        Private _UnbilledTotal As Nullable(Of Decimal) = Nothing
        Private _AdvanceHours As Nullable(Of Decimal) = Nothing
        Private _AdvanceQuantity As Nullable(Of Decimal) = Nothing
        Private _AdvanceBilledNetAmount As Nullable(Of Decimal) = Nothing
        Private _AdvanceBilledMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _AdvanceBilledAmount As Nullable(Of Decimal) = Nothing
        Private _AdvanceBilledResaleTax As Nullable(Of Decimal) = Nothing
        Private _AdvanceBilledTotal As Nullable(Of Decimal) = Nothing
        Private _UnbilledAdvanceNetAmount As Nullable(Of Decimal) = Nothing
        Private _UnbilledAdvanceMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _UnbilledAdvanceAmount As Nullable(Of Decimal) = Nothing
        Private _UnbilledAdvanceResaleTax As Nullable(Of Decimal) = Nothing
        Private _UnbilledAdvanceTotal As Nullable(Of Decimal) = Nothing
        Private _FlatIncomeRecognized As Nullable(Of Decimal) = Nothing
        Private _NonBillableHours As Nullable(Of Decimal) = Nothing
        Private _NonBillableQuantity As Nullable(Of Decimal) = Nothing
        Private _NonBillableNetAmount As Nullable(Of Decimal) = Nothing
        Private _NonBillableMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _NonBillableAmount As Nullable(Of Decimal) = Nothing
        Private _FeeTimeHours As Nullable(Of Decimal) = Nothing
        Private _FeeAmount As Nullable(Of Decimal) = Nothing
        Private _FeeResaleTax As Nullable(Of Decimal) = Nothing
        Private _FeeTotal As Nullable(Of Decimal) = Nothing
        Private _BillHoldAmount As Nullable(Of Decimal) = Nothing
        Private _OpenPOAmount As Nullable(Of Decimal) = Nothing
        Private _PercentCompleteTime As Nullable(Of Decimal) = Nothing
        Private _PercentCompleteAll As Nullable(Of Decimal) = Nothing
        Private _FunctionType As String = Nothing
        Private _FunctionOrder As Nullable(Of Short) = Nothing
        Private _FunctionConsolidationCode As String = Nothing
        Private _FunctionConsolidationDescription As String = Nothing
        Private _BilledOfEstimate As Decimal = Nothing
        Private _BillingApprovalFunctionAmount As Nullable(Of Decimal) = Nothing
        Private _BillingApprovalFunctionComment As String = Nothing
        Private _BillingApprovalFunctionClientComment As String = Nothing
        Private _AdvanceBillRequested As Boolean = False
        Private _BillingApprovalDetailID As Nullable(Of Integer) = Nothing
        Private _FlatIncomeToRecognize As Nullable(Of Decimal) = Nothing
        Private _UnbilledNetOnly As Nullable(Of Decimal) = Nothing
        Private _BillingUser As String = Nothing
        Private _GrossIncome As Nullable(Of Decimal) = Nothing
        Private _JobMediaDateToBill As Nullable(Of Date) = Nothing
        Private _BillingApprovalHeaderComment As String = Nothing
        Private _BillingApprovalHeaderClientComment As String = Nothing
        Private _ItemUnbilledHours As Nullable(Of Decimal) = Nothing
        Private _ItemUnbilledQuantity As Nullable(Of Decimal) = Nothing
        Private _ItemUnbilledNetAmount As Nullable(Of Decimal) = Nothing
        Private _ItemUnbilledMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _ItemUnbilledResaleTax As Nullable(Of Decimal) = Nothing
        Private _ItemUnbilledTotal As Nullable(Of Decimal) = Nothing
        Private _ItemNonBillableHours As Nullable(Of Decimal) = Nothing
        Private _ItemNonBillableQuantity As Nullable(Of Decimal) = Nothing
        Private _ItemNonBillableMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _ItemNonBillableNetAmount As Nullable(Of Decimal) = Nothing
        Private _ItemNonBillableTotalAmount As Nullable(Of Decimal) = Nothing
        Private _ItemBillingTransferFromJob As Nullable(Of Integer) = Nothing
        Private _ItemBillingTransferFromJobComponent As Nullable(Of Short) = Nothing
        Private _ItemBillingTransferFromFunctionCode As String = Nothing
        Private _ItemBillingTransferToJob As Nullable(Of Integer) = Nothing
        Private _ItemBillingTransferToJobComponent As Nullable(Of Short) = Nothing
        Private _ItemBillingTransferToFunctionCode As String = Nothing
        Private _ItemBillingAdjustmentWriteOffFlag As Boolean = False
        Private _ItemBillingTransferAdjustmentUser As String = Nothing
        Private _ItemBillingTransferAdjustmentDate As Nullable(Of Date) = Nothing
        Private _ItemBillingTransferAdjustmentComment As String = Nothing
        Private _ItemID As Nullable(Of Integer) = Nothing
        Private _ItemDate As Nullable(Of Date) = Nothing
        Private _ItemPostPeriodCode As String = Nothing
        Private _ItemCode As String = Nothing
        Private _ItemDescription As String = Nothing
        Private _ItemComment As String = Nothing
        Private _ItemFeeFlag As String = Nothing
        Private _ItemBillable As Nullable(Of Boolean) = False
        Private _ItemApprovalAmount As Nullable(Of Decimal) = Nothing
        Private _ItemInvoiceNumber As String = Nothing
        Private _BillingBatchName As String = Nothing
        Private _AdvanceBillingRetained As Nullable(Of Decimal) = Nothing

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
        Public Property BillStatus() As String
            Get
                BillStatus = _BillStatus
            End Get
            Set(value As String)
                _BillStatus = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Integer)
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property ComponentNumber() As Short
            Get
                ComponentNumber = _ComponentNumber
            End Get
            Set(value As Short)
                _ComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ComponentDescription() As String
            Get
                ComponentDescription = _ComponentDescription
            End Get
            Set(value As String)
                _ComponentDescription = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CampaignDescription() As String
            Get
                CampaignDescription = _CampaignDescription
            End Get
            Set(value As String)
                _CampaignDescription = value
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
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(value As String)
                _ClientPO = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientReference() As String
            Get
                ClientReference = _ClientReference
            End Get
            Set(value As String)
                _ClientReference = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property EstimateNumber() As Nullable(Of Integer)
            Get
                EstimateNumber = _EstimateNumber
            End Get
            Set(value As Nullable(Of Integer))
                _EstimateNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EstimateDescription() As String
            Get
                EstimateDescription = _EstimateDescription
            End Get
            Set(value As String)
                _EstimateDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property EstimateComponentNumber() As Nullable(Of Short)
            Get
                EstimateComponentNumber = _EstimateComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _EstimateComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EstimateComponentDescription() As String
            Get
                EstimateComponentDescription = _EstimateComponentDescription
            End Get
            Set(value As String)
                _EstimateComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
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
        Public Property ScheduleStatus() As String
            Get
                ScheduleStatus = _ScheduleStatus
            End Get
            Set(value As String)
                _ScheduleStatus = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ScheduleCompletedDate() As Nullable(Of Date)
            Get
                ScheduleCompletedDate = _ScheduleCompletedDate
            End Get
            Set(value As Nullable(Of Date))
                _ScheduleCompletedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(value As String)
                _FunctionType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FunctionHeading() As String
            Get
                FunctionHeading = _FunctionHeading
            End Get
            Set(value As String)
                _FunctionHeading = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property EstimateHours() As Decimal
            Get
                EstimateHours = _EstimateHours
            End Get
            Set(value As Decimal)
                _EstimateHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property EstimateQuantity() As Decimal
            Get
                EstimateQuantity = _EstimateQuantity
            End Get
            Set(value As Decimal)
                _EstimateQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property EstimateNetAmount() As Decimal
            Get
                EstimateNetAmount = _EstimateNetAmount
            End Get
            Set(value As Decimal)
                _EstimateNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property EstimateMarkupAmount() As Decimal
            Get
                EstimateMarkupAmount = _EstimateMarkupAmount
            End Get
            Set(value As Decimal)
                _EstimateMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property EstimateAmount() As Decimal
            Get
                EstimateAmount = _EstimateAmount
            End Get
            Set(value As Decimal)
                _EstimateAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property EstimateResaleTax() As Decimal
            Get
                EstimateResaleTax = _EstimateResaleTax
            End Get
            Set(value As Decimal)
                _EstimateResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property EstimateTotal() As Decimal
            Get
                EstimateTotal = _EstimateTotal
            End Get
            Set(value As Decimal)
                _EstimateTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ActualBillableHours() As Nullable(Of Decimal)
            Get
                ActualBillableHours = _ActualBillableHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ActualBillableQuantity() As Nullable(Of Decimal)
            Get
                ActualBillableQuantity = _ActualBillableQuantity.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ActualBillableNetAmount() As Nullable(Of Decimal)
            Get
                ActualBillableNetAmount = _ActualBillableNetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ActualBillableMarkupAmount() As Nullable(Of Decimal)
            Get
                ActualBillableMarkupAmount = _ActualBillableMarkupAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ActualBillableAmount() As Nullable(Of Decimal)
            Get
                ActualBillableAmount = _ActualBillableAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ActualBillableResaleTax() As Nullable(Of Decimal)
            Get
                ActualBillableResaleTax = _ActualBillableResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ActualBillableTotal() As Nullable(Of Decimal)
            Get
                ActualBillableTotal = _ActualBillableTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property BilledHours() As Nullable(Of Decimal)
            Get
                BilledHours = _BilledHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property BilledQuantity() As Nullable(Of Decimal)
            Get
                BilledQuantity = _BilledQuantity.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property BilledNet() As Nullable(Of Decimal)
            Get
                BilledNet = _BilledNet.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledNet = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property BilledMarkup() As Nullable(Of Decimal)
            Get
                BilledMarkup = _BilledMarkup.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledMarkup = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property BilledAmount() As Nullable(Of Decimal)
            Get
                BilledAmount = _BilledAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledAmount = value
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
        Public Property UnbilledHours() As Nullable(Of Decimal)
            Get
                UnbilledHours = _UnbilledHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property UnbilledQuantity() As Nullable(Of Decimal)
            Get
                UnbilledQuantity = _UnbilledQuantity.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property UnbilledNetAmount() As Nullable(Of Decimal)
            Get
                UnbilledNetAmount = _UnbilledNetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Unbilled Markup Percent")>
        Public ReadOnly Property UnbilledMarkupPercentCalc() As Decimal
            Get
                If Me.UnbilledNetAmount.GetValueOrDefault(0) = 0 Then
                    UnbilledMarkupPercentCalc = 0
                Else
                    UnbilledMarkupPercentCalc = Me.UnbilledMarkupAmount.GetValueOrDefault(0) * 100 / Me.UnbilledNetAmount.GetValueOrDefault(0)
                End If
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property UnbilledMarkupAmount() As Nullable(Of Decimal)
            Get
                UnbilledMarkupAmount = _UnbilledMarkupAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property UnbilledAmount() As Nullable(Of Decimal)
            Get
                UnbilledAmount = _UnbilledAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property UnbilledResaleTax() As Nullable(Of Decimal)
            Get
                UnbilledResaleTax = _UnbilledResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledResaleTax = value
            End Set
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AdvanceHours() As Nullable(Of Decimal)
            Get
                AdvanceHours = _AdvanceHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AdvanceQuantity() As Nullable(Of Decimal)
            Get
                AdvanceQuantity = _AdvanceQuantity.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AdvanceBilledNetAmount() As Nullable(Of Decimal)
            Get
                AdvanceBilledNetAmount = _AdvanceBilledNetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilledNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AdvanceBilledMarkupAmount() As Nullable(Of Decimal)
            Get
                AdvanceBilledMarkupAmount = _AdvanceBilledMarkupAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilledMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AdvanceBilledAmount() As Nullable(Of Decimal)
            Get
                AdvanceBilledAmount = _AdvanceBilledAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilledAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AdvanceBilledResaleTax() As Nullable(Of Decimal)
            Get
                AdvanceBilledResaleTax = _AdvanceBilledResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilledResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AdvanceBilledTotal() As Nullable(Of Decimal)
            Get
                AdvanceBilledTotal = _AdvanceBilledTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilledTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property TotalBilledAmount() As Decimal
            Get
                TotalBilledAmount = Me.BilledAmount.GetValueOrDefault(0) + Me.AdvanceBilledAmount.GetValueOrDefault(0)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property TotalBilledTax() As Decimal
            Get
                TotalBilledTax = Me.BilledResaleTax.GetValueOrDefault(0) + Me.AdvanceBilledResaleTax.GetValueOrDefault(0)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property TotalBilled() As Decimal
            Get
                TotalBilled = Me.BilledTotal.GetValueOrDefault(0) + Me.AdvanceBilledTotal.GetValueOrDefault(0)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property UnbilledAdvanceNetAmount() As Nullable(Of Decimal)
            Get
                UnbilledAdvanceNetAmount = _UnbilledAdvanceNetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledAdvanceNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property UnbilledAdvanceMarkupAmount() As Nullable(Of Decimal)
            Get
                UnbilledAdvanceMarkupAmount = _UnbilledAdvanceMarkupAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledAdvanceMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property UnbilledAdvanceAmount() As Nullable(Of Decimal)
            Get
                UnbilledAdvanceAmount = _UnbilledAdvanceAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledAdvanceAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property UnbilledAdvanceResaleTax() As Nullable(Of Decimal)
            Get
                UnbilledAdvanceResaleTax = _UnbilledAdvanceResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledAdvanceResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property UnbilledAdvanceTotal() As Nullable(Of Decimal)
            Get
                UnbilledAdvanceTotal = _UnbilledAdvanceTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledAdvanceTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property FlatIncomeRecognized() As Nullable(Of Decimal)
            Get
                FlatIncomeRecognized = _FlatIncomeRecognized.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _FlatIncomeRecognized = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property FlatIncomeToRecognize() As Nullable(Of Decimal)
            Get
                FlatIncomeToRecognize = _FlatIncomeToRecognize.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _FlatIncomeToRecognize = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property NonBillableHours() As Nullable(Of Decimal)
            Get
                NonBillableHours = _NonBillableHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NonBillableHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property NonBillableQuantity() As Nullable(Of Decimal)
            Get
                NonBillableQuantity = _NonBillableQuantity.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NonBillableQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property NonBillableNetAmount() As Nullable(Of Decimal)
            Get
                NonBillableNetAmount = _NonBillableNetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NonBillableNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property NonBillableMarkupAmount() As Nullable(Of Decimal)
            Get
                NonBillableMarkupAmount = _NonBillableMarkupAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NonBillableMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property NonBillableAmount() As Nullable(Of Decimal)
            Get
                NonBillableAmount = _NonBillableAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NonBillableAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property FeeTimeHours() As Nullable(Of Decimal)
            Get
                FeeTimeHours = _FeeTimeHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _FeeTimeHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Fee Time Amount")>
        Public Property FeeAmount() As Nullable(Of Decimal)
            Get
                FeeAmount = _FeeAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _FeeAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property FeeResaleTax() As Nullable(Of Decimal)
            Get
                FeeResaleTax = _FeeResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _FeeResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property FeeTotal() As Nullable(Of Decimal)
            Get
                FeeTotal = _FeeTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _FeeTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property BillHoldAmount() As Nullable(Of Decimal)
            Get
                BillHoldAmount = _BillHoldAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BillHoldAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property OpenPOAmount() As Nullable(Of Decimal)
            Get
                OpenPOAmount = _OpenPOAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _OpenPOAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property PercentCompleteTime() As Nullable(Of Decimal)
            Get
                PercentCompleteTime = _PercentCompleteTime.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _PercentCompleteTime = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property PercentCompleteAll() As Nullable(Of Decimal)
            Get
                PercentCompleteAll = _PercentCompleteAll.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _PercentCompleteAll = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FunctionOrder() As Nullable(Of Short)
            Get
                FunctionOrder = _FunctionOrder
            End Get
            Set(value As Nullable(Of Short))
                _FunctionOrder = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Consol Code")>
        Public Property FunctionConsolidationCode() As String
            Get
                FunctionConsolidationCode = _FunctionConsolidationCode
            End Get
            Set(value As String)
                _FunctionConsolidationCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Consol Description")>
        Public Property FunctionConsolidationDescription() As String
            Get
                FunctionConsolidationDescription = _FunctionConsolidationDescription
            End Get
            Set(value As String)
                _FunctionConsolidationDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="% Billed of Quote")>
        Public Property BilledOfEstimate() As Decimal
            Get
                BilledOfEstimate = _BilledOfEstimate
            End Get
            Set(value As Decimal)
                _BilledOfEstimate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AmountToBill() As Decimal
            Get
                AmountToBill = _AmountToBill
            End Get
            Set(value As Decimal)
                _AmountToBill = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Approved Amount")>
        Public Property BillingApprovalFunctionAmount() As Nullable(Of Decimal)
            Get
                BillingApprovalFunctionAmount = _BillingApprovalFunctionAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BillingApprovalFunctionAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Approval Comment", IsReadOnlyColumn:=True)>
        Public Property BillingApprovalFunctionComment() As String
            Get
                BillingApprovalFunctionComment = _BillingApprovalFunctionComment
            End Get
            Set(value As String)
                _BillingApprovalFunctionComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Approval Client Comment")>
        Public Property BillingApprovalFunctionClientComment() As String
            Get
                BillingApprovalFunctionClientComment = _BillingApprovalFunctionClientComment
            End Get
            Set(value As String)
                _BillingApprovalFunctionClientComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AdvanceBillRequested() As Boolean
            Get
                AdvanceBillRequested = _AdvanceBillRequested
            End Get
            Set(value As Boolean)
                _AdvanceBillRequested = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BillingApprovalDetailID() As Nullable(Of Integer)
            Get
                BillingApprovalDetailID = _BillingApprovalDetailID
            End Get
            Set(value As Nullable(Of Integer))
                _BillingApprovalDetailID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", ShowColumnInGrid:=False)>
        Public Property UnbilledNetOnly() As Nullable(Of Decimal)
            Get
                UnbilledNetOnly = _UnbilledNetOnly.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledNetOnly = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property GrossIncome() As Nullable(Of Decimal)
            Get
                GrossIncome = _GrossIncome.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _GrossIncome = value
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
        Public Property BillingApprovalBatchID As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BillingApprovalBatchDescription As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BillingApprovalHeaderComment() As String
            Get
                BillingApprovalHeaderComment = _BillingApprovalHeaderComment
            End Get
            Set(value As String)
                _BillingApprovalHeaderComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BillingApprovalHeaderClientComment() As String
            Get
                BillingApprovalHeaderClientComment = _BillingApprovalHeaderClientComment
            End Get
            Set(value As String)
                _BillingApprovalHeaderClientComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property ItemID() As Nullable(Of Integer)
            Get
                ItemID = _ItemID
            End Get
            Set(value As Nullable(Of Integer))
                _ItemID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ItemDate() As Nullable(Of Date)
            Get
                ItemDate = _ItemDate
            End Get
            Set(value As Nullable(Of Date))
                _ItemDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ItemInvoiceNumber() As String
            Get
                ItemInvoiceNumber = _ItemInvoiceNumber
            End Get
            Set(value As String)
                _ItemInvoiceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ItemDescription() As String
            Get
                ItemDescription = _ItemDescription
            End Get
            Set(value As String)
                _ItemDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ItemPostPeriodCode() As String
            Get
                ItemPostPeriodCode = _ItemPostPeriodCode
            End Get
            Set(value As String)
                _ItemPostPeriodCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ItemCode() As String
            Get
                ItemCode = _ItemCode
            End Get
            Set(value As String)
                _ItemCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ItemUnbilledHours() As Nullable(Of Decimal)
            Get
                ItemUnbilledHours = _ItemUnbilledHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ItemUnbilledHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ItemUnbilledQuantity() As Nullable(Of Decimal)
            Get
                ItemUnbilledQuantity = _ItemUnbilledQuantity.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ItemUnbilledQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ItemUnbilledNetAmount() As Nullable(Of Decimal)
            Get
                ItemUnbilledNetAmount = _ItemUnbilledNetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ItemUnbilledNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ItemUnbilledMarkupAmount() As Nullable(Of Decimal)
            Get
                ItemUnbilledMarkupAmount = _ItemUnbilledMarkupAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ItemUnbilledMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ItemUnbilledResaleTax() As Nullable(Of Decimal)
            Get
                ItemUnbilledResaleTax = _ItemUnbilledResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ItemUnbilledResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ItemUnbilledTotal() As Nullable(Of Decimal)
            Get
                ItemUnbilledTotal = _ItemUnbilledTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ItemUnbilledTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ItemNonBillableHours() As Nullable(Of Decimal)
            Get
                ItemNonBillableHours = _ItemNonBillableHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ItemNonBillableHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ItemNonBillableQuantity() As Nullable(Of Decimal)
            Get
                ItemNonBillableQuantity = _ItemNonBillableQuantity.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ItemNonBillableQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ItemNonBillableMarkupAmount() As Nullable(Of Decimal)
            Get
                ItemNonBillableMarkupAmount = _ItemNonBillableMarkupAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ItemNonBillableMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ItemNonBillableNetAmount() As Nullable(Of Decimal)
            Get
                ItemNonBillableNetAmount = _ItemNonBillableNetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ItemNonBillableNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ItemNonBillableTotalAmount() As Nullable(Of Decimal)
            Get
                ItemNonBillableTotalAmount = _ItemNonBillableTotalAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ItemNonBillableTotalAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ItemFeeFlag() As String
            Get
                ItemFeeFlag = _ItemFeeFlag
            End Get
            Set(value As String)
                _ItemFeeFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ItemBillable() As Nullable(Of Boolean)
            Get
                ItemBillable = _ItemBillable.GetValueOrDefault(False)
            End Get
            Set(value As Nullable(Of Boolean))
                _ItemBillable = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ItemApprovalAmount() As Nullable(Of Decimal)
            Get
                ItemApprovalAmount = _ItemApprovalAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ItemApprovalAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ItemComment() As String
            Get
                ItemComment = _ItemComment
            End Get
            Set(value As String)
                _ItemComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property ItemBillingTransferFromJob() As Nullable(Of Integer)
            Get
                ItemBillingTransferFromJob = _ItemBillingTransferFromJob
            End Get
            Set(value As Nullable(Of Integer))
                _ItemBillingTransferFromJob = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ItemBillingTransferFromJobComponent() As Nullable(Of Short)
            Get
                ItemBillingTransferFromJobComponent = _ItemBillingTransferFromJobComponent
            End Get
            Set(value As Nullable(Of Short))
                _ItemBillingTransferFromJobComponent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ItemBillingTransferFromFunctionCode() As String
            Get
                ItemBillingTransferFromFunctionCode = _ItemBillingTransferFromFunctionCode
            End Get
            Set(value As String)
                _ItemBillingTransferFromFunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property ItemBillingTransferToJob() As Nullable(Of Integer)
            Get
                ItemBillingTransferToJob = _ItemBillingTransferToJob
            End Get
            Set(value As Nullable(Of Integer))
                _ItemBillingTransferToJob = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ItemBillingTransferToJobComponent() As Nullable(Of Short)
            Get
                ItemBillingTransferToJobComponent = _ItemBillingTransferToJobComponent
            End Get
            Set(value As Nullable(Of Short))
                _ItemBillingTransferToJobComponent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ItemBillingTransferToFunctionCode() As String
            Get
                ItemBillingTransferToFunctionCode = _ItemBillingTransferToFunctionCode
            End Get
            Set(value As String)
                _ItemBillingTransferToFunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.StandardCheckBox)>
        Public Property ItemBillingAdjustmentWriteOffFlag() As Boolean
            Get
                ItemBillingAdjustmentWriteOffFlag = _ItemBillingAdjustmentWriteOffFlag
            End Get
            Set(value As Boolean)
                _ItemBillingAdjustmentWriteOffFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ItemBillingTransferAdjustmentUser() As String
            Get
                ItemBillingTransferAdjustmentUser = _ItemBillingTransferAdjustmentUser
            End Get
            Set(value As String)
                _ItemBillingTransferAdjustmentUser = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ItemBillingTransferAdjustmentDate() As Nullable(Of Date)
            Get
                ItemBillingTransferAdjustmentDate = _ItemBillingTransferAdjustmentDate
            End Get
            Set(value As Nullable(Of Date))
                _ItemBillingTransferAdjustmentDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ItemBillingTransferAdjustmentComment() As String
            Get
                ItemBillingTransferAdjustmentComment = _ItemBillingTransferAdjustmentComment
            End Get
            Set(value As String)
                _ItemBillingTransferAdjustmentComment = value
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
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AdvanceBillingRetained() As Nullable(Of Decimal)
            Get
                AdvanceBillingRetained = _AdvanceBillingRetained.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBillingRetained = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProcessControlDescription As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property EstimateComponentFormatted() As String
            Get
                If Me.EstimateNumber.HasValue AndAlso Me.EstimateComponentNumber.HasValue Then

                    EstimateComponentFormatted = Me.EstimateNumber.Value.ToString.PadLeft(6, "0") & "-" & Me.EstimateComponentNumber.Value.ToString.PadLeft(3, "0")

                Else

                    EstimateComponentFormatted = Nothing

                End If
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
