Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class ProductionSummary

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            BillStatus
            OfficeCode
            OfficeDescription
            CampaignID
            CampaignCode
            CampaignDescription
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
            SalesClassCode
            SalesClassDescription
            ClientPO
            ClientReference
            BillingCoopCode
            ScheduleStatus
            ScheduleCompletedDate
            EstimateNumberComponentQuoteRevision
            EstimateApprovedDate
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
            UnbilledAdvanceAmount
            UnbilledAdvanceResaleTax
            UnbilledAdvanceTotal
            FlatIncomeRecognized
            NonBillableHours
            NonBillableQuantity
            NonBillableNetAmount
            NonBillableMarkupAmount
            NonBillableAmount
            FeeHours
            FeeAmount
            FeeResaleTax
            FeeTotal
            BillHoldAmount
            OpenPOAmount
            BillingApprovalAmount
            BillingApprovalHeaderComment
            BillingApprovalHeaderClientComment
            AdvanceBillRequested
            JobBillHoldRequested
            ProcessControl
            AmountSelectedforBilling
            BillingUser
            ProcessControlDescription
            IsCloseable
            JobCompNumber
            JobCompDescription
            BilledOfEstimate
            BillingSelectionResult
            IsSelected
            BillingSelectionSelect
            IsAdjusted
            ReconcileStatus
            AmountToReconcile
            JobBillComment
            BillingApprovalHeaderID
            FlatIncomeToRecognize
            JobBillHold
            ABFlag
            ReconcileMethod
            ReconcileResult
            CampaignComment
            JobComment
            JobComponentComment
            GrossIncome
            JobMediaDateToBill
            AdvanceBillingBalance
            AdvanceBillingRetained
            AccountExecutive
            JobTypeDescription
        End Enum

#End Region

#Region " Variables "

        Private _BillStatus As Integer = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeDescription As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignDescription As String = Nothing
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
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _ClientPO As String = Nothing
        Private _ClientReference As String = Nothing
        Private _BillingCoopCode As String = Nothing
        Private _ScheduleStatus As String = Nothing
        Private _ScheduleCompletedDate As Nullable(Of Date) = Nothing
        Private _EstimateNumberComponentQuoteRevision As String = Nothing
        Private _EstimateApprovedDate As Nullable(Of Date) = Nothing
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
        Private _UnbilledAdvanceAmount As Nullable(Of Decimal) = Nothing
        Private _UnbilledAdvanceResaleTax As Nullable(Of Decimal) = Nothing
        Private _UnbilledAdvanceTotal As Nullable(Of Decimal) = Nothing
        Private _FlatIncomeRecognized As Nullable(Of Decimal) = Nothing
        Private _NonBillableHours As Nullable(Of Decimal) = Nothing
        Private _NonBillableQuantity As Nullable(Of Decimal) = Nothing
        Private _NonBillableNetAmount As Nullable(Of Decimal) = Nothing
        Private _NonBillableMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _NonBillableAmount As Nullable(Of Decimal) = Nothing
        Private _FeeAmount As Nullable(Of Decimal) = Nothing
        Private _FeeResaleTax As Nullable(Of Decimal) = Nothing
        Private _FeeTotal As Nullable(Of Decimal) = Nothing
        Private _BillHoldAmount As Nullable(Of Decimal) = Nothing
        Private _OpenPOAmount As Nullable(Of Decimal) = Nothing
        Private _BillingApprovalAmount As Nullable(Of Decimal) = Nothing
        Private _BillingApprovalHeaderComment As String = Nothing
        Private _BillingApprovalHeaderClientComment As String = Nothing
        Private _AdvanceBillRequested As Boolean = False
        Private _JobBillHoldRequested As Boolean = False
        Private _ProcessControl As Short = Nothing
        Private _AmountSelectedforBilling As Decimal = Nothing
        Private _BillingUser As String = Nothing
        Private _ProcessControlDescription As String = Nothing
        Private _IsCloseable As Boolean = Nothing
        Private _BilledOfEstimate As Decimal = Nothing
        Private _BillingSelectionResult As String = Nothing
        Private _BillingSelectionSelect As Boolean = False
        Private _IsAdjusted As Boolean = False
        Private _ReconcileStatus As String = Nothing
        Private _JobBillComment As String = Nothing
        Private _BillingApprovalHeaderID As Nullable(Of Integer) = Nothing
        Private _FlatIncomeToRecognize As Nullable(Of Decimal) = Nothing
        Private _JobComponentFunctionDetails As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing
        Private _AccountPayableProductionItems As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem) = Nothing
        Private _EmployeeTimeItems As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem) = Nothing
        Private _IncomeOnlyItems As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem) = Nothing
        Private _JobBillHold As Nullable(Of Short) = Nothing
        Private _ABFlag As Nullable(Of Short) = Nothing
        Private _ReconcileMethod As String = Nothing
        Private _ReconcileResult As String = Nothing
        Private _CampaignComment As String = Nothing
        Private _JobComment As String = Nothing
        Private _JobComponentComment As String = Nothing
        Private _AmountToReconcile As Decimal = Nothing
        Private _GrossIncome As Nullable(Of Decimal) = Nothing
        Private _JobMediaDateToBill As Nullable(Of Date) = Nothing
        Private _AdvanceBillingRetained As Nullable(Of Decimal) = Nothing

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
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox, CustomColumnCaption:="Is" & vbCrLf & "Adjusted")>
        Public Property IsAdjusted() As Boolean
            Get
                IsAdjusted = _IsAdjusted
            End Get
            Set(value As Boolean)
                _IsAdjusted = value
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
        Public Property CampaignDescription() As String
            Get
                CampaignDescription = _CampaignDescription
            End Get
            Set(value As String)
                _CampaignDescription = value
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
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job/Comp" & vbCrLf & "Number")>
        Public ReadOnly Property JobCompNumber() As String
            Get
                JobCompNumber = _JobNumber.ToString.PadLeft(6, "0") & "-" & _ComponentNumber.ToString.PadLeft(3, "0")
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job Description/" & vbCrLf & "Comp Description", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public ReadOnly Property JobCompDescription() As String
            Get
                JobCompDescription = (_JobDescription & vbCrLf & _ComponentDescription).ToString
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job" & vbCrLf & "Number")>
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Integer)
                _JobNumber = value
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
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Component" & vbCrLf & "Number")>
        Public Property ComponentNumber() As Short
            Get
                ComponentNumber = _ComponentNumber
            End Get
            Set(value As Short)
                _ComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Component" & vbCrLf & "Description")>
        Public Property ComponentDescription() As String
            Get
                ComponentDescription = _ComponentDescription
            End Get
            Set(value As String)
                _ComponentDescription = value
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
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client" & vbCrLf & "Reference")>
        Public Property ClientReference() As String
            Get
                ClientReference = _ClientReference
            End Get
            Set(value As String)
                _ClientReference = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Billing" & vbCrLf & "Coop Code")>
        Public Property BillingCoopCode() As String
            Get
                BillingCoopCode = _BillingCoopCode
            End Get
            Set(value As String)
                _BillingCoopCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Schedule" & vbCrLf & "Status")>
        Public Property ScheduleStatus() As String
            Get
                ScheduleStatus = _ScheduleStatus
            End Get
            Set(value As String)
                _ScheduleStatus = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Schedule" & vbCrLf & "Completed Date")>
        Public Property ScheduleCompletedDate() As Nullable(Of Date)
            Get
                ScheduleCompletedDate = _ScheduleCompletedDate
            End Get
            Set(value As Nullable(Of Date))
                _ScheduleCompletedDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Estimate Number/" & vbCrLf & "Comp/Quote/Rev")>
        Public Property EstimateNumberComponentQuoteRevision() As String
            Get
                EstimateNumberComponentQuoteRevision = _EstimateNumberComponentQuoteRevision
            End Get
            Set(value As String)
                _EstimateNumberComponentQuoteRevision = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Estimate" & vbCrLf & "Approved Date")>
        Public Property EstimateApprovedDate() As Nullable(Of Date)
            Get
                EstimateApprovedDate = _EstimateApprovedDate
            End Get
            Set(value As Nullable(Of Date))
                _EstimateApprovedDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Estimate" & vbCrLf & "Hours")>
        Public Property EstimateHours() As Decimal
            Get
                EstimateHours = _EstimateHours
            End Get
            Set(value As Decimal)
                _EstimateHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Estimate" & vbCrLf & "Quantity")>
        Public Property EstimateQuantity() As Decimal
            Get
                EstimateQuantity = _EstimateQuantity
            End Get
            Set(value As Decimal)
                _EstimateQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Estimate" & vbCrLf & "Net Amount")>
        Public Property EstimateNetAmount() As Decimal
            Get
                EstimateNetAmount = _EstimateNetAmount
            End Get
            Set(value As Decimal)
                _EstimateNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Estimate" & vbCrLf & "Markup Amount")>
        Public Property EstimateMarkupAmount() As Decimal
            Get
                EstimateMarkupAmount = _EstimateMarkupAmount
            End Get
            Set(value As Decimal)
                _EstimateMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Estimate" & vbCrLf & "Amount")>
        Public Property EstimateAmount() As Decimal
            Get
                EstimateAmount = _EstimateAmount
            End Get
            Set(value As Decimal)
                _EstimateAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Estimate" & vbCrLf & "Resale Tax")>
        Public Property EstimateResaleTax() As Decimal
            Get
                EstimateResaleTax = _EstimateResaleTax
            End Get
            Set(value As Decimal)
                _EstimateResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Estimate" & vbCrLf & "Total")>
        Public Property EstimateTotal() As Decimal
            Get
                EstimateTotal = _EstimateTotal
            End Get
            Set(value As Decimal)
                _EstimateTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Actual" & vbCrLf & "Billable Hours")>
        Public Property ActualBillableHours() As Nullable(Of Decimal)
            Get
                ActualBillableHours = _ActualBillableHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Actual Billable" & vbCrLf & "Quantity")>
        Public Property ActualBillableQuantity() As Nullable(Of Decimal)
            Get
                ActualBillableQuantity = _ActualBillableQuantity.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Actual Billable" & vbCrLf & "Net Amount")>
        Public Property ActualBillableNetAmount() As Nullable(Of Decimal)
            Get
                ActualBillableNetAmount = _ActualBillableNetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Actual Billable" & vbCrLf & "Markup Amount")>
        Public Property ActualBillableMarkupAmount() As Nullable(Of Decimal)
            Get
                ActualBillableMarkupAmount = _ActualBillableMarkupAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Actual" & vbCrLf & "Billable Amount")>
        Public Property ActualBillableAmount() As Nullable(Of Decimal)
            Get
                ActualBillableAmount = _ActualBillableAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Actual Billable" & vbCrLf & "Resale Tax")>
        Public Property ActualBillableResaleTax() As Nullable(Of Decimal)
            Get
                ActualBillableResaleTax = _ActualBillableResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Actual" & vbCrLf & "Billable Total")>
        Public Property ActualBillableTotal() As Nullable(Of Decimal)
            Get
                ActualBillableTotal = _ActualBillableTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Billed" & vbCrLf & "Hours")>
        Public Property BilledHours() As Nullable(Of Decimal)
            Get
                BilledHours = _BilledHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Billed" & vbCrLf & "Quantity")>
        Public Property BilledQuantity() As Nullable(Of Decimal)
            Get
                BilledQuantity = _BilledQuantity.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Billed" & vbCrLf & "Net")>
        Public Property BilledNet() As Nullable(Of Decimal)
            Get
                BilledNet = _BilledNet.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledNet = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Billed" & vbCrLf & "Markup")>
        Public Property BilledMarkup() As Nullable(Of Decimal)
            Get
                BilledMarkup = _BilledMarkup.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledMarkup = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Billed" & vbCrLf & "Amount")>
        Public Property BilledAmount() As Nullable(Of Decimal)
            Get
                BilledAmount = _BilledAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledAmount = value
            End Set
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
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Hours")>
        Public Property UnbilledHours() As Nullable(Of Decimal)
            Get
                UnbilledHours = _UnbilledHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Quantity")>
        Public Property UnbilledQuantity() As Nullable(Of Decimal)
            Get
                UnbilledQuantity = _UnbilledQuantity.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Net Amount")>
        Public Property UnbilledNetAmount() As Nullable(Of Decimal)
            Get
                UnbilledNetAmount = _UnbilledNetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Markup Amount")>
        Public Property UnbilledMarkupAmount() As Nullable(Of Decimal)
            Get
                UnbilledMarkupAmount = _UnbilledMarkupAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Amount")>
        Public Property UnbilledAmount() As Nullable(Of Decimal)
            Get
                UnbilledAmount = _UnbilledAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Resale Tax")>
        Public Property UnbilledResaleTax() As Nullable(Of Decimal)
            Get
                UnbilledResaleTax = _UnbilledResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledResaleTax = value
            End Set
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
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Advance" & vbCrLf & "Hours")>
        Public Property AdvanceHours() As Nullable(Of Decimal)
            Get
                AdvanceHours = _AdvanceHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Advance" & vbCrLf & "Quantity")>
        Public Property AdvanceQuantity() As Nullable(Of Decimal)
            Get
                AdvanceQuantity = _AdvanceQuantity.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Advance Billed" & vbCrLf & "Net Amount")>
        Public Property AdvanceBilledNetAmount() As Nullable(Of Decimal)
            Get
                AdvanceBilledNetAmount = _AdvanceBilledNetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilledNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Advance Billed" & vbCrLf & "Markup Amount")>
        Public Property AdvanceBilledMarkupAmount() As Nullable(Of Decimal)
            Get
                AdvanceBilledMarkupAmount = _AdvanceBilledMarkupAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilledMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Advance" & vbCrLf & "Billed Amount")>
        Public Property AdvanceBilledAmount() As Nullable(Of Decimal)
            Get
                AdvanceBilledAmount = _AdvanceBilledAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilledAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Advance Billed" & vbCrLf & "Resale Tax")>
        Public Property AdvanceBilledResaleTax() As Nullable(Of Decimal)
            Get
                AdvanceBilledResaleTax = _AdvanceBilledResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilledResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Advance Billed" & vbCrLf & "Total")>
        Public Property AdvanceBilledTotal() As Nullable(Of Decimal)
            Get
                AdvanceBilledTotal = _AdvanceBilledTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilledTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Total Billed" & vbCrLf & "Amount")>
        Public ReadOnly Property TotalBilledAmount() As Nullable(Of Decimal)
            Get
                TotalBilledAmount = Me.BilledAmount.GetValueOrDefault(0) + Me.AdvanceBilledAmount.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Total Billed" & vbCrLf & "Tax")>
        Public ReadOnly Property TotalBilledTax() As Nullable(Of Decimal)
            Get
                TotalBilledTax = Me.BilledResaleTax.GetValueOrDefault(0) + Me.AdvanceBilledResaleTax.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Total" & vbCrLf & "Billed")>
        Public ReadOnly Property TotalBilled() As Nullable(Of Decimal)
            Get
                TotalBilled = Me.BilledTotal.GetValueOrDefault(0) + Me.AdvanceBilledTotal.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Advance Amount")>
        Public Property UnbilledAdvanceAmount() As Nullable(Of Decimal)
            Get
                UnbilledAdvanceAmount = _UnbilledAdvanceAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledAdvanceAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled Advance" & vbCrLf & "Resale Tax")>
        Public Property UnbilledAdvanceResaleTax() As Nullable(Of Decimal)
            Get
                UnbilledAdvanceResaleTax = _UnbilledAdvanceResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledAdvanceResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Advance Total")>
        Public Property UnbilledAdvanceTotal() As Nullable(Of Decimal)
            Get
                UnbilledAdvanceTotal = _UnbilledAdvanceTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledAdvanceTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Flat Income" & vbCrLf & "Recognized")>
        Public Property FlatIncomeRecognized() As Nullable(Of Decimal)
            Get
                FlatIncomeRecognized = _FlatIncomeRecognized.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _FlatIncomeRecognized = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Flat Income" & vbCrLf & "to Recognize")>
        Public Property FlatIncomeToRecognize() As Nullable(Of Decimal)
            Get
                FlatIncomeToRecognize = _FlatIncomeToRecognize.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _FlatIncomeToRecognize = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Non Billable" & vbCrLf & "Hours")>
        Public Property NonBillableHours() As Nullable(Of Decimal)
            Get
                NonBillableHours = _NonBillableHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NonBillableHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Non Billable" & vbCrLf & "Quantity")>
        Public Property NonBillableQuantity() As Nullable(Of Decimal)
            Get
                NonBillableQuantity = _NonBillableQuantity.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NonBillableQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Non Billable" & vbCrLf & "Net Amount")>
        Public Property NonBillableNetAmount() As Nullable(Of Decimal)
            Get
                NonBillableNetAmount = _NonBillableNetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NonBillableNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Non Billable" & vbCrLf & "Markup Amount")>
        Public Property NonBillableMarkupAmount() As Nullable(Of Decimal)
            Get
                NonBillableMarkupAmount = _NonBillableMarkupAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NonBillableMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Non Billable" & vbCrLf & "Amount")>
        Public Property NonBillableAmount() As Nullable(Of Decimal)
            Get
                NonBillableAmount = _NonBillableAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NonBillableAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Fee" & vbCrLf & "Hours")>
        Public Property FeeHours() As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Fee Time" & vbCrLf & "Amount")>
        Public Property FeeAmount() As Nullable(Of Decimal)
            Get
                FeeAmount = _FeeAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _FeeAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Fee" & vbCrLf & "Resale Tax")>
        Public Property FeeResaleTax() As Nullable(Of Decimal)
            Get
                FeeResaleTax = _FeeResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _FeeResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Fee" & vbCrLf & "Total")>
        Public Property FeeTotal() As Nullable(Of Decimal)
            Get
                FeeTotal = _FeeTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _FeeTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Bill Hold" & vbCrLf & "Amount")>
        Public Property BillHoldAmount() As Nullable(Of Decimal)
            Get
                BillHoldAmount = _BillHoldAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BillHoldAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Open PO" & vbCrLf & "Amount")>
        Public Property OpenPOAmount() As Nullable(Of Decimal)
            Get
                OpenPOAmount = _OpenPOAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _OpenPOAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Amount" & vbCrLf & "to Bill")>
        Public Property AmountToBill() As Decimal
            Get
                AmountToBill = _AmountToBill
            End Get
            Set(value As Decimal)
                _AmountToBill = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Approved" & vbCrLf & "Amount")>
        Public Property BillingApprovalAmount() As Nullable(Of Decimal)
            Get
                BillingApprovalAmount = _BillingApprovalAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BillingApprovalAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Approval" & vbCrLf & "Comment", DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property BillingApprovalHeaderComment() As String
            Get
                BillingApprovalHeaderComment = _BillingApprovalHeaderComment
            End Get
            Set(value As String)
                _BillingApprovalHeaderComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Approval" & vbCrLf & "Client Comment", DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property BillingApprovalHeaderClientComment() As String
            Get
                BillingApprovalHeaderClientComment = _BillingApprovalHeaderClientComment
            End Get
            Set(value As String)
                _BillingApprovalHeaderClientComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Advance Bill" & vbCrLf & "Requested", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property AdvanceBillRequested() As Boolean
            Get
                AdvanceBillRequested = _AdvanceBillRequested
            End Get
            Set(value As Boolean)
                _AdvanceBillRequested = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job Bill Hold" & vbCrLf & "Requested", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property JobBillHoldRequested() As Boolean
            Get
                JobBillHoldRequested = _JobBillHoldRequested
            End Get
            Set(value As Boolean)
                _JobBillHoldRequested = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, CustomColumnCaption:="Process" & vbCrLf & "Control")>
        Public Property ProcessControl() As Short
            Get
                ProcessControl = _ProcessControl
            End Get
            Set(value As Short)
                _ProcessControl = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Process" & vbCrLf & "Control")>
        Public Property ProcessControlDescription() As String
            Get
                ProcessControlDescription = _ProcessControlDescription
            End Get
            Set(value As String)
                _ProcessControlDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, DisplayFormat:="n2", CustomColumnCaption:="Amount Selected" & vbCrLf & "for Billing")>
        Public Property AmountSelectedforBilling() As Decimal
            Get
                AmountSelectedforBilling = _AmountSelectedforBilling
            End Get
            Set(value As Decimal)
                _AmountSelectedforBilling = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, CustomColumnCaption:="Billing" & vbCrLf & "User")>
        Public Property BillingUser() As String
            Get
                BillingUser = _BillingUser
            End Get
            Set(value As String)
                _BillingUser = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, CustomColumnCaption:="Is" & vbCrLf & "Closeable")>
        Public Property IsCloseable() As Boolean
            Get
                IsCloseable = _IsCloseable
            End Get
            Set(value As Boolean)
                _IsCloseable = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="% Billed" & vbCrLf & "of Quote")>
        Public Property BilledOfEstimate() As Decimal
            Get
                BilledOfEstimate = _BilledOfEstimate
            End Get
            Set(value As Decimal)
                _BilledOfEstimate = value
            End Set
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
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Select", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public ReadOnly Property IsSelected() As Boolean
            Get
                IsSelected = If(_BillingUser IsNot Nothing, True, False)
            End Get
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
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, CustomColumnCaption:="Reconcile" & vbCrLf & "Method")>
        Public Property ReconcileStatus() As String
            Get
                ReconcileStatus = _ReconcileStatus
            End Get
            Set(value As String)
                _ReconcileStatus = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", ShowColumnInGrid:=False, CustomColumnCaption:="Amount" & vbCrLf & "to Reconcile")>
        Public Property AmountToReconcile() As Decimal
            Get
                AmountToReconcile = GetAmountToReconcile()
            End Get
            Set(value As Decimal)
                _AmountToReconcile = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo, CustomColumnCaption:="Job Bill" & vbCrLf & "Comment")>
        Public Property JobBillComment() As String
            Get
                JobBillComment = _JobBillComment
            End Get
            Set(value As String)
                _JobBillComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BillingApprovalHeaderID() As Nullable(Of Integer)
            Get
                BillingApprovalHeaderID = _BillingApprovalHeaderID
            End Get
            Set(value As Nullable(Of Integer))
                _BillingApprovalHeaderID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property JobComponentFunctionDetails As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail)
            Get
                JobComponentFunctionDetails = _JobComponentFunctionDetails
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property AccountPayableProductionItems As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem)
            Get
                AccountPayableProductionItems = _AccountPayableProductionItems
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property EmployeeTimeItems As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem)
            Get
                EmployeeTimeItems = _EmployeeTimeItems
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property IncomeOnlyItems As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem)
            Get
                IncomeOnlyItems = _IncomeOnlyItems
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, CustomColumnCaption:="Job Bill" & vbCrLf & "Hold")>
        Public Property JobBillHold() As Nullable(Of Short)
            Get
                JobBillHold = _JobBillHold
            End Get
            Set(value As Nullable(Of Short))
                _JobBillHold = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ABFlag() As Nullable(Of Short)
            Get
                ABFlag = _ABFlag
            End Get
            Set(value As Nullable(Of Short))
                _ABFlag = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Reconcile" & vbCrLf & "Status")>
        Public Property ReconcileMethod() As String
            Get
                ReconcileMethod = _ReconcileMethod
            End Get
            Set(value As String)
                _ReconcileMethod = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Reconcile" & vbCrLf & "Result")>
        Public Property ReconcileResult() As String
            Get
                ReconcileResult = _ReconcileResult
            End Get
            Set(value As String)
                _ReconcileResult = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Campaign" & vbCrLf & "Comment")>
        Public Property CampaignComment() As String
            Get
                CampaignComment = _CampaignComment
            End Get
            Set(value As String)
                _CampaignComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job" & vbCrLf & "Comment")>
        Public Property JobComment() As String
            Get
                JobComment = _JobComment
            End Get
            Set(value As String)
                _JobComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job Component" & vbCrLf & "Comment")>
        Public Property JobComponentComment() As String
            Get
                JobComponentComment = _JobComponentComment
            End Get
            Set(value As String)
                _JobComponentComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Gross" & vbCrLf & "Income")>
        Public Property GrossIncome() As Nullable(Of Decimal)
            Get
                GrossIncome = _GrossIncome.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _GrossIncome = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="Job Media" & vbCrLf & "Date to Bill")>
        Public Property JobMediaDateToBill() As Nullable(Of Date)
            Get
                JobMediaDateToBill = _JobMediaDateToBill
            End Get
            Set(value As Nullable(Of Date))
                _JobMediaDateToBill = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Advance Billing" & vbCrLf & "Balance")>
        Public ReadOnly Property AdvanceBillingBalance() As Decimal
            Get
                AdvanceBillingBalance = Me.AdvanceBilledAmount.GetValueOrDefault(0) - Me.FlatIncomeRecognized.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Advance" & vbCrLf & "Billing Retained")>
        Public Property AdvanceBillingRetained() As Nullable(Of Decimal)
            Get
                AdvanceBillingRetained = _AdvanceBillingRetained.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBillingRetained = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="Account" & vbCrLf & "Executive")>
        Public Property AccountExecutive() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="Job Type" & vbCrLf & "Description")>
        Public Property JobTypeDescription() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Job Comp" & vbCrLf & "Budget")>
        Public Property JobCompBudget() As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Private Function GetAmountToReconcile() As Decimal

            Dim Amount As Decimal = 0

            If _AccountPayableProductionItems IsNot Nothing Then

                Amount += _AccountPayableProductionItems.Where(Function(Entity) Entity.Reconcile = True AndAlso Entity.IsNonBillable.GetValueOrDefault(0) = 0).Sum(Function(Entity) Entity.Total)

            End If

            If _EmployeeTimeItems IsNot Nothing Then

                Amount += _EmployeeTimeItems.Where(Function(Entity) Entity.Reconcile = True AndAlso Entity.IsNonBillable.GetValueOrDefault(0) = 0).Sum(Function(Entity) Entity.Total)

            End If

            If _IncomeOnlyItems IsNot Nothing Then

                Amount += _IncomeOnlyItems.Where(Function(Entity) Entity.Reconcile = True AndAlso Entity.IsNonBillable = False).Sum(Function(Entity) Entity.Total)

            End If

            GetAmountToReconcile = Amount

        End Function
        Public Sub New()



        End Sub
        Public Sub PopulateReconcileDetails(ByVal Session As AdvantageFramework.Security.Session, ByVal BillingCommandCenterID As Integer, ByVal IncludeContingency As Short)

            'objects
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, BillingCommandCenterID)

                    If BillingCommandCenter IsNot Nothing Then

                        PopulateReconcileDetails(BCCDbContext, BillingCommandCenter, IncludeContingency)

                    End If

                End Using

            End Using

        End Sub
        Public Sub PopulateReconcileDetails(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext,
                                            ByVal BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter,
                                            ByVal IncludeContingency As Short)

            _JobComponentFunctionDetails = AdvantageFramework.BillingCommandCenter.GetProductionSummaryByFunction(BCCDbContext, BillingCommandCenter.ID, IncludeContingency, Me.JobNumber, Me.ComponentNumber)

            For Each JobComponentFunctionDetail In _JobComponentFunctionDetails

                JobComponentFunctionDetail.ProductionSummary = Me

            Next

            _AccountPayableProductionItems = AdvantageFramework.BillingCommandCenter.GetAccountPayableProductionItems(BCCDbContext, Me.JobNumber, Me.ComponentNumber, Nothing, BillingCommandCenter.APPostPeriodCodeCutoff, ProductionSelectFor.Reconcile, BillingCommandCenter.IsProductionSelectionLocked)
            _EmployeeTimeItems = AdvantageFramework.BillingCommandCenter.GetEmployeeTimeItems(BCCDbContext, Me.JobNumber, Me.ComponentNumber, Nothing, BillingCommandCenter.EmployeeTimeDateCutoff.Value, BillingCommandCenter.IsProductionSelectionLocked)
            _IncomeOnlyItems = AdvantageFramework.BillingCommandCenter.GetIncomeOnlyItems(BCCDbContext, Me.JobNumber, Me.ComponentNumber, Nothing, BillingCommandCenter.IncomeOnlyDateCutoff.Value, BillingCommandCenter.IsProductionSelectionLocked, AdvantageFramework.BillingCommandCenter.IncomeOnlySelectFor.Reconcile)

            If Me.ReconcileStatus = "2" Then

                _AccountPayableProductionItems = _AccountPayableProductionItems.Where(Function(Entity) Entity.Instruction = "Bill/Reconcile").ToList
                _EmployeeTimeItems = _EmployeeTimeItems.Where(Function(Entity) Entity.Instruction = "Bill/Reconcile").ToList
                _IncomeOnlyItems = _IncomeOnlyItems.Where(Function(Entity) Entity.Instruction = "Bill/Reconcile").ToList

            End If

            If Me.ReconcileStatus = "1" OrElse Me.ReconcileStatus = "2" Then

                For Each JobComponentFunctionDetail In _JobComponentFunctionDetails

                    JobComponentFunctionDetail.Reconcile = True

                Next

                For Each AccountPayableProductionItem In _AccountPayableProductionItems

                    AccountPayableProductionItem.Reconcile = True

                Next

                For Each EmployeeTimeItem In _EmployeeTimeItems

                    EmployeeTimeItem.Reconcile = True

                Next

                For Each IncomeOnlyItem In _IncomeOnlyItems

                    IncomeOnlyItem.Reconcile = True

                Next

            End If

        End Sub
        Public Sub ClearReconcileDetails()

            _JobComponentFunctionDetails = Nothing
            _AccountPayableProductionItems = Nothing
            _EmployeeTimeItems = Nothing
            _IncomeOnlyItems = Nothing

        End Sub

#End Region

    End Class

End Namespace
