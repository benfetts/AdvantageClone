Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class IncomeOnlyItem
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceNumber
            SequenceNumber
            InvoiceDate
            Quantity
            Rate
            Amount
            CommissionPercent
            MarkupAmount
            Total
            SalesTaxCode
            IsResaleTax
            TaxCommission
            TaxCommissionOnly
            StateTaxPercent
            CountyTaxPercent
            CityTaxPercent
            StateResaleTaxAmount
            CountyResaleTaxAmount
            CityResaleTaxAmount
            TotalTax
            LineTotal
            IsNonBillable
            IsBillOnHold
            Comment
            NetApprovedAmount
            ApprovalComment
            Instruction
            ID
            JobNumber
            JobComponentNumber
            FunctionCode
            Description
            BillingCommandCenterID
            Reconcile
            FunctionDescription
            TransferFromJob
            TransferFromJobComponent
            TransferFromFunctionCode
            TransferFromJCF
            AdjustmentTransferUserCode
            AdjustmentTransferDate
            AdjustmentTransferComment
        End Enum

#End Region

#Region " Variables "

        Private _InvoiceNumber As String = Nothing
        Private _SequenceNumber As Short = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _Quantity As Nullable(Of Decimal) = Nothing
        Private _Amount As Decimal = Nothing
        Private _LineTotal As Decimal = Nothing
        Private _CommissionPercent As Decimal = Nothing
        Private _MarkupAmount As Decimal = Nothing
        Private _SalesTaxCode As String = Nothing
        Private _IsResaleTax As Nullable(Of Short) = Nothing
        Private _StateTaxPercent As Decimal = Nothing
        Private _CountyTaxPercent As Decimal = Nothing
        Private _CityTaxPercent As Decimal = Nothing
        Private _StateResaleTaxAmount As Decimal = Nothing
        Private _CountyResaleTaxAmount As Decimal = Nothing
        Private _CityResaleTaxAmount As Decimal = Nothing
        Private _TaxCommission As Boolean = False
        Private _TaxCommissionOnly As Boolean = False
        Private _Comment As String = Nothing
        Private _NetApprovedAmount As Nullable(Of Decimal) = Nothing
        Private _ApprovalComment As String = Nothing
        Private _Instruction As String = Nothing
        Private _IsNonbillable As Boolean = Nothing
        Private _MarkupPercentChanged As Boolean = False
        Private _MarkupAmountChanged As Boolean = False
        Private _TaxCodeChanged As Boolean = False
        Private _TaxAmountChanged As Boolean = False
        Private _IsBillOnHold As Nullable(Of Short) = Nothing
        Private _ID As Integer = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _FunctionCode As String = Nothing
        Private _Description As String = Nothing
        Private _BillingCommandCenterID As Nullable(Of Integer) = Nothing
        Private _Reconcile As Boolean = False
        Private _FunctionDescription As String = Nothing
        Private _ABFlag As Nullable(Of Short) = Nothing
        Private _TransferFromJob As Nullable(Of Integer) = Nothing
        Private _TransferFromJobComponent As Nullable(Of Short) = Nothing
        Private _TransferFromFunctionCode As String = Nothing
        Private _AdjustmentTransferUserCode As String = Nothing
        Private _AdjustmentTransferDate As Nullable(Of Date) = Nothing
        Private _AdjustmentTransferComment As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Date", IsReadOnlyColumn:=True)>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property InvoiceNumber() As String
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(value As String)
                _InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SequenceNumber() As Short
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(value As Short)
                _SequenceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property Quantity() As Nullable(Of Decimal)
            Get
                Quantity = _Quantity
            End Get
            Set(value As Nullable(Of Decimal))
                _Quantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n4")>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Amount() As Decimal
            Get
                Amount = _Amount
            End Get
            Set(value As Decimal)
                _Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Markup/Down %", UseMaxValue:=True, MaxValue:=999999.999, UseMinValue:=True, MinValue:=-999999.999)>
        Public Property CommissionPercent() As Decimal
            Get
                CommissionPercent = _CommissionPercent
            End Get
            Set(value As Decimal)
                _CommissionPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Markup/Down Amount")>
        Public Property MarkupAmount() As Decimal
            Get
                MarkupAmount = _MarkupAmount
            End Get
            Set(value As Decimal)
                _MarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Total")>
        Public ReadOnly Property Total() As Decimal
            Get
                Total = _Amount + _MarkupAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Resale Tax")>
        Public ReadOnly Property TotalTax As Decimal
            Get
                TotalTax = _StateResaleTaxAmount + _CountyResaleTaxAmount + _CityResaleTaxAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Total with Tax")>
        Public ReadOnly Property LineTotal() As Decimal
            Get
                LineTotal = _Amount + _MarkupAmount + _StateResaleTaxAmount + _CountyResaleTaxAmount + _CityResaleTaxAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.ReversedCheckBox, CustomColumnCaption:="Billable")>
        Public Property IsNonBillable As Boolean
            Get
                IsNonBillable = _IsNonbillable
            End Get
            Set(value As Boolean)
                _IsNonbillable = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Bill Hold")>
        Public Property IsBillOnHold As Nullable(Of Short)
            Get
                IsBillOnHold = _IsBillOnHold
            End Get
            Set(value As Nullable(Of Short))
                _IsBillOnHold = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Comment As String
            Get
                Comment = _Comment
            End Get
            Set(value As String)
                _Comment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property NetApprovedAmount As Nullable(Of Decimal)
            Get
                NetApprovedAmount = _NetApprovedAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _NetApprovedAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo, IsReadOnlyColumn:=True)>
        Public Property ApprovalComment As String
            Get
                ApprovalComment = _ApprovalComment
            End Get
            Set(value As String)
                _ApprovalComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Instruction As String
            Get
                Instruction = _Instruction
            End Get
            Set(value As String)
                _Instruction = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Tax Code", PropertyType:=BaseClasses.PropertyTypes.SalesTaxCode)>
        Public Property SalesTaxCode() As String
            Get
                SalesTaxCode = _SalesTaxCode
            End Get
            Set(value As String)
                _SalesTaxCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsResaleTax As Nullable(Of Short)
            Get
                IsResaleTax = _IsResaleTax
            End Get
            Set(value As Nullable(Of Short))
                _IsResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Tax Markup", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property TaxCommission As Boolean
            Get
                TaxCommission = _TaxCommission
            End Get
            Set(value As Boolean)
                _TaxCommission = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Tax Markup Only", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property TaxCommissionOnly As Boolean
            Get
                TaxCommissionOnly = _TaxCommissionOnly
            End Get
            Set(value As Boolean)
                _TaxCommissionOnly = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="State Percent", IsReadOnlyColumn:=True)>
        Public Property StateTaxPercent As Decimal
            Get
                StateTaxPercent = _StateTaxPercent
            End Get
            Set(value As Decimal)
                _StateTaxPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="County Percent", IsReadOnlyColumn:=True)>
        Public Property CountyTaxPercent As Decimal
            Get
                CountyTaxPercent = _CountyTaxPercent
            End Get
            Set(value As Decimal)
                _CountyTaxPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="City Percent", IsReadOnlyColumn:=True)>
        Public Property CityTaxPercent As Decimal
            Get
                CityTaxPercent = _CityTaxPercent
            End Get
            Set(value As Decimal)
                _CityTaxPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="State Amount")>
        Public Property StateResaleTaxAmount As Decimal
            Get
                StateResaleTaxAmount = _StateResaleTaxAmount
            End Get
            Set(value As Decimal)
                _StateResaleTaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="County Amount")>
        Public Property CountyResaleTaxAmount As Decimal
            Get
                CountyResaleTaxAmount = _CountyResaleTaxAmount
            End Get
            Set(value As Decimal)
                _CountyResaleTaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="City Amount")>
        Public Property CityResaleTaxAmount As Decimal
            Get
                CityResaleTaxAmount = _CityResaleTaxAmount
            End Get
            Set(value As Decimal)
                _CityResaleTaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MarkupPercentChanged As Boolean
            Get
                MarkupPercentChanged = _MarkupPercentChanged
            End Get
            Set(value As Boolean)
                _MarkupPercentChanged = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MarkupAmountChanged As Boolean
            Get
                MarkupAmountChanged = _MarkupAmountChanged
            End Get
            Set(value As Boolean)
                _MarkupAmountChanged = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCodeChanged As Boolean
            Get
                TaxCodeChanged = _TaxCodeChanged
            End Get
            Set(value As Boolean)
                _TaxCodeChanged = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxAmountChanged As Boolean
            Get
                TaxAmountChanged = _TaxAmountChanged
            End Get
            Set(value As Boolean)
                _TaxAmountChanged = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Integer)
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property JobComponentNumber() As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Short)
                _JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BillingCommandCenterID As Nullable(Of Integer)
            Get
                BillingCommandCenterID = _BillingCommandCenterID
            End Get
            Set(value As Nullable(Of Integer))
                _BillingCommandCenterID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Reconcile As Boolean
            Get
                Reconcile = _Reconcile
            End Get
            Set(value As Boolean)
                _Reconcile = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionDescription As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ABFlag As Nullable(Of Short)
            Get
                ABFlag = _ABFlag
            End Get
            Set(value As Nullable(Of Short))
                _ABFlag = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property TransferFromJob As Nullable(Of Integer)
            Get
                TransferFromJob = _TransferFromJob
            End Get
            Set(value As Nullable(Of Integer))
                _TransferFromJob = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property TransferFromJobComponent As Nullable(Of Short)
            Get
                TransferFromJobComponent = _TransferFromJobComponent
            End Get
            Set(value As Nullable(Of Short))
                _TransferFromJobComponent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property TransferFromFunctionCode As String
            Get
                TransferFromFunctionCode = _TransferFromFunctionCode
            End Get
            Set(value As String)
                _TransferFromFunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="Transfer From Job/Comp/Function")>
        Public ReadOnly Property TransferFromJCF As String
            Get
                If _TransferFromJob.HasValue AndAlso _TransferFromJobComponent.HasValue Then
                    TransferFromJCF = _TransferFromJob.Value.ToString.PadLeft(6, "0") & "-" & _TransferFromJobComponent.Value.ToString.PadLeft(2, "0") & " | " & _TransferFromFunctionCode
                Else
                    TransferFromJCF = Nothing
                End If
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Adj/Trans User")>
        Public Property AdjustmentTransferUserCode As String
            Get
                AdjustmentTransferUserCode = _AdjustmentTransferUserCode
            End Get
            Set(value As String)
                _AdjustmentTransferUserCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Adj/Trans Date")>
        Public Property AdjustmentTransferDate As Nullable(Of Date)
            Get
                AdjustmentTransferDate = _AdjustmentTransferDate
            End Get
            Set(value As Nullable(Of Date))
                _AdjustmentTransferDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Adj/Trans Comment", DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property AdjustmentTransferComment As String
            Get
                AdjustmentTransferComment = _AdjustmentTransferComment
            End Get
            Set(value As String)
                _AdjustmentTransferComment = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Function ShallowCopy() As AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem

            Dim IncomeOnlyItemCopy As AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem = Nothing

            IncomeOnlyItemCopy = DirectCast(Me.MemberwiseClone(), AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem)

            ShallowCopy = IncomeOnlyItemCopy

        End Function

#End Region

    End Class

End Namespace