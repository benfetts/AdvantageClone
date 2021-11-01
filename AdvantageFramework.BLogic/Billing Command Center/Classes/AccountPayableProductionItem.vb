Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class AccountPayableProductionItem
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceNumber
            LineNumber
            VendorName
            InvoiceDate
            PostPeriod
            Quantity
            Rate
            ExtendedAmount
            CommissionPercent
            ExtendedMarkupAmount
            Total
            SalesTaxCode
            IsResaleTax
            TaxCommissions
            TaxCommissionsOnly
            StateTaxPercent
            CountyTaxPercent
            CityTaxPercent
            ExtendedStateResale
            ExtendedCountyResale
            ExtendedCityResale
            ResaleTax
            ExtendedNonResaleTax
            LineTotal
            IsNonBillable
            IsBillOnHold
            Comment
            HasDocuments
            NetApprovedAmount
            ApprovalComment
            Instruction
            AccountPayableID
            JobNumber
            JobComponentNumber
            ExpenseReportDetailID
            FunctionCode
            VendorCode
            BillingCommandCenterID
            Reconcile
            FunctionDescription
            WriteOff
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

        Private _VendorName As String = Nothing
        Private _InvoiceDate As Date = Nothing
        Private _PostPeriod As String = Nothing
        Private _Quantity As Nullable(Of Decimal) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _InvoiceNumber As String = Nothing
        Private _LineNumber As Short = Nothing
        Private _ExtendedAmount As Decimal = Nothing
        Private _CommissionPercent As Decimal = Nothing
        Private _ExtendedMarkupAmount As Decimal = Nothing
        Private _SalesTaxCode As String = Nothing
        Private _IsResaleTax As Nullable(Of Short) = Nothing
        Private _ExtendedStateResale As Decimal = Nothing
        Private _ExtendedCountyResale As Decimal = Nothing
        Private _ExtendedCityResale As Decimal = Nothing
        Private _TaxCommissions As Nullable(Of Short) = False
        Private _TaxCommissionsOnly As Nullable(Of Short) = False
        Private _StateTaxPercent As Decimal = Nothing
        Private _CountyTaxPercent As Decimal = Nothing
        Private _CityTaxPercent As Decimal = Nothing
        Private _Comment As String = Nothing
        Private _LineTotal As Decimal = Nothing
        Private _ExtendedNonResaleTax As Decimal = Nothing
        Private _IsNonBillable As Nullable(Of Short) = Nothing
        Private _MarkupPercentChanged As Boolean = False
        Private _MarkupAmountChanged As Boolean = False
        Private _TaxCodeChanged As Boolean = False
        Private _TaxAmountChanged As Boolean = False
        Private _IsBillOnHold As Nullable(Of Short) = Nothing
        Private _HasDocuments As Boolean = False
        Private _NetApprovedAmount As Nullable(Of Decimal) = Nothing
        Private _ApprovalComment As String = Nothing
        Private _Instruction As String = Nothing
        Private _AccountPayableID As Integer = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _ExpenseReportDetailID As Nullable(Of Integer) = Nothing
        Private _FunctionCode As String = Nothing
        Private _VendorCode As String = Nothing
        Private _BillingCommandCenterID As Nullable(Of Integer) = Nothing
        Private _Reconcile As Boolean = False
        Private _FunctionDescription As String = Nothing
        Private _ABFlag As Nullable(Of Short) = Nothing
        Private _WriteOff As Nullable(Of Short) = Nothing
        Private _TransferFromJob As Nullable(Of Integer) = Nothing
        Private _TransferFromJobComponent As Nullable(Of Short) = Nothing
        Private _TransferFromFunctionCode As String = Nothing
        Private _AdjustmentTransferUserCode As String = Nothing
        Private _AdjustmentTransferDate As Nullable(Of Date) = Nothing
        Private _AdjustmentTransferComment As String = Nothing
        Private _ModifyDelete As Boolean = False
        Private _IsBilledReversal As Boolean = False

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Date", IsReadOnlyColumn:=True)>
        Public Property InvoiceDate() As Date
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Date)
                _InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property PostPeriod() As String
            Get
                PostPeriod = _PostPeriod
            End Get
            Set(value As String)
                _PostPeriod = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property LineNumber() As Short
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Short)
                _LineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(value As String)
                _VendorName = value
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
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Quantity() As Nullable(Of Decimal)
            Get
                Quantity = _Quantity
            End Get
            Set(value As Nullable(Of Decimal))
                _Quantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n3")>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Amount")>
        Public Property ExtendedAmount() As Decimal
            Get
                ExtendedAmount = _ExtendedAmount
            End Get
            Set(value As Decimal)
                _ExtendedAmount = value
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
        Public Property ExtendedMarkupAmount() As Decimal
            Get
                ExtendedMarkupAmount = _ExtendedMarkupAmount
            End Get
            Set(value As Decimal)
                _ExtendedMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Non Resale Tax")>
        Public Property ExtendedNonResaleTax As Decimal
            Get
                ExtendedNonResaleTax = _ExtendedNonResaleTax
            End Get
            Set(value As Decimal)
                _ExtendedNonResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Total() As Decimal
            Get
                Total = _ExtendedAmount + _ExtendedMarkupAmount + _ExtendedNonResaleTax
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property ResaleTax As Decimal
            Get
                ResaleTax = _ExtendedStateResale + _ExtendedCountyResale + _ExtendedCityResale
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Total with Tax")>
        Public ReadOnly Property LineTotal() As Decimal
            Get
                LineTotal = _ExtendedAmount + _ExtendedMarkupAmount + _ExtendedStateResale + _ExtendedCountyResale + _ExtendedCityResale + _ExtendedNonResaleTax
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenUnCheckedCheckBox, CustomColumnCaption:="Billable")>
        Public Property IsNonBillable As Nullable(Of Short)
            Get
                IsNonBillable = _IsNonBillable.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Short))
                _IsNonBillable = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property WriteOff As Nullable(Of Short)
            Get
                WriteOff = _WriteOff.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Short))
                _WriteOff = value
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
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property HasDocuments As Boolean
            Get
                HasDocuments = _HasDocuments
            End Get
            Set(value As Boolean)
                _HasDocuments = value
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
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Tax Markup", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property TaxCommissions As Nullable(Of Short)
            Get
                TaxCommissions = _TaxCommissions
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommissions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Tax Markup Only", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property TaxCommissionsOnly As Nullable(Of Short)
            Get
                TaxCommissionsOnly = _TaxCommissionsOnly
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommissionsOnly = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", IsReadOnlyColumn:=True, CustomColumnCaption:="State Percent")>
        Public Property StateTaxPercent As Decimal
            Get
                StateTaxPercent = _StateTaxPercent
            End Get
            Set(value As Decimal)
                _StateTaxPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", IsReadOnlyColumn:=True, CustomColumnCaption:="County Percent")>
        Public Property CountyTaxPercent As Decimal
            Get
                CountyTaxPercent = _CountyTaxPercent
            End Get
            Set(value As Decimal)
                _CountyTaxPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", IsReadOnlyColumn:=True, CustomColumnCaption:="City Percent")>
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
        Public Property ExtendedStateResale As Decimal
            Get
                ExtendedStateResale = _ExtendedStateResale
            End Get
            Set(value As Decimal)
                _ExtendedStateResale = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="County Amount")>
        Public Property ExtendedCountyResale As Decimal
            Get
                ExtendedCountyResale = _ExtendedCountyResale
            End Get
            Set(value As Decimal)
                _ExtendedCountyResale = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="City Amount")>
        Public Property ExtendedCityResale As Decimal
            Get
                ExtendedCityResale = _ExtendedCityResale
            End Get
            Set(value As Decimal)
                _ExtendedCityResale = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AccountPayableID() As Integer
            Get
                AccountPayableID = _AccountPayableID
            End Get
            Set(value As Integer)
                _AccountPayableID = value
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
        Public Property ExpenseReportDetailID() As Nullable(Of Integer)
            Get
                ExpenseReportDetailID = _ExpenseReportDetailID
            End Get
            Set(value As Nullable(Of Integer))
                _ExpenseReportDetailID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionCode As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
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
        Public Property VendorCode As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
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
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ModifyDelete As Boolean
            Get
                ModifyDelete = _ModifyDelete
            End Get
            Set(value As Boolean)
                _ModifyDelete = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsBilledReversal As Boolean
            Get
                IsBilledReversal = _IsBilledReversal
            End Get
            Set(value As Boolean)
                _IsBilledReversal = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub CalculateTax(ByRef AccountPayableProductionItem As AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem)

            Dim TaxableAmount As Decimal = 0

            If AccountPayableProductionItem.IsResaleTax.GetValueOrDefault(0) = 1 Then

                If AccountPayableProductionItem.TaxCommissionsOnly.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableProductionItem.ExtendedMarkupAmount

                ElseIf AccountPayableProductionItem.TaxCommissions.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableProductionItem.ExtendedMarkupAmount + AccountPayableProductionItem.ExtendedAmount

                Else

                    TaxableAmount = AccountPayableProductionItem.ExtendedAmount

                End If

            Else

                If AccountPayableProductionItem.TaxCommissionsOnly.GetValueOrDefault(0) = 1 OrElse AccountPayableProductionItem.TaxCommissions.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableProductionItem.ExtendedMarkupAmount

                End If

            End If

            AccountPayableProductionItem.ExtendedStateResale = FormatNumber(AccountPayableProductionItem.StateTaxPercent * TaxableAmount / 100, 2)
            AccountPayableProductionItem.ExtendedCountyResale = FormatNumber(AccountPayableProductionItem.CountyTaxPercent * TaxableAmount / 100, 2)
            AccountPayableProductionItem.ExtendedCityResale = FormatNumber(AccountPayableProductionItem.CityTaxPercent * TaxableAmount / 100, 2)

        End Sub
        Public Function ShallowCopy() As AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem

            Dim AccountPayableProductionItemCopy As AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem = Nothing

            AccountPayableProductionItemCopy = DirectCast(Me.MemberwiseClone(), AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem)

            ShallowCopy = AccountPayableProductionItemCopy

        End Function

#End Region

    End Class

End Namespace