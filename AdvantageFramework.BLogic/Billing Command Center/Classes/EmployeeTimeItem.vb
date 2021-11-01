Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class EmployeeTimeItem
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeTimeID
            EmployeeTimeDetailID
            SequenceNumber
            EmployeeName
            EmployeeDate
            Hours
            BillableRate
            TotalBill
            CommissionPercentage
            MarkupAmount
            Total
            SalesTaxCode
            IsResaleTax
            TaxCommission
            TaxCommissionOnly
            SalesTaxStatePercentage
            SalesTaxCountyPercentage
            SalesTaxCityPercentage
            StateResaleAmount
            CountyResaleAmount
            CityResaleAmount
            ResaleTax
            LineTotal
            IsNonBillable
            IsBillOnHold
            FeeTimeType
            Comment
            EmployeeCode
            JobNumber
            JobComponentNumber
            FunctionCode
            NetApprovedAmount
            ApprovalComment
            Instruction
            BillingCommandCenterID
            EmployeeRateFrom
            Reconcile
            FunctionDescription
            TransferFromJob
            TransferFromJobComponent
            TransferFromFunctionCode
            TransferFromJCF
            AdjustmentTransferUserCode
            AdjustmentTransferDate
            AdjustmentTransferComment
            TaskCode
        End Enum

#End Region

#Region " Variables "

        Private _EmployeeTimeID As Integer = Nothing
        Private _EmployeeTimeDetailID As Short = Nothing
        Private _SequenceNumber As Short = Nothing
        Private _EmployeeName As String = Nothing
        Private _EmployeeDate As Date = Nothing
        Private _BillableRate As Decimal = Nothing
        Private _CommissionPercentage As Decimal = Nothing
        Private _MarkupAmount As Decimal = Nothing
        Private _SalesTaxCode As String = Nothing
        Private _IsResaleTax As Nullable(Of Short) = Nothing
        Private _StateResaleAmount As Decimal = Nothing
        Private _CountyResaleAmount As Decimal = Nothing
        Private _CityResaleAmount As Decimal = Nothing
        Private _TaxCommission As Nullable(Of Short) = Nothing
        Private _TaxCommissionOnly As Nullable(Of Short) = Nothing
        Private _IsNonBillable As Nullable(Of Short) = Nothing
        Private _SalesTaxStatePercentage As Decimal = Nothing
        Private _SalesTaxCountyPercentage As Decimal = Nothing
        Private _SalesTaxCityPercentage As Decimal = Nothing
        Private _Comment As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _TotalBill As Decimal = Nothing
        Private _Hours As Decimal = Nothing
        Private _FeeTimeType As Short = Nothing
        Private _EmployeeTimeFlag As Short = Nothing
        Private _IsBillOnHold As Nullable(Of Short) = Nothing
        Private _MarkupPercentChanged As Boolean = False
        Private _MarkupAmountChanged As Boolean = False
        Private _TaxCodeChanged As Boolean = False
        Private _TaxAmountChanged As Boolean = False
        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _FunctionCode As String = Nothing
        Private _NetApprovedAmount As Nullable(Of Decimal) = Nothing
        Private _ApprovalComment As String = Nothing
        Private _Instruction As String = Nothing
        Private _BillingCommandCenterID As Nullable(Of Integer) = Nothing
        Private _EmployeeRateFrom As String = Nothing
        Private _Reconcile As Boolean = False
        Private _FunctionDescription As String = Nothing
        Private _ABFlag As Nullable(Of Short) = Nothing
        Private _TransferFromJob As Nullable(Of Integer) = Nothing
        Private _TransferFromJobComponent As Nullable(Of Short) = Nothing
        Private _TransferFromFunctionCode As String = Nothing
        Private _AdjustmentTransferUserCode As String = Nothing
        Private _AdjustmentTransferDate As Nullable(Of Date) = Nothing
        Private _AdjustmentTransferComment As String = Nothing
        Private _TaskCode As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeTimeID() As Integer
            Get
                EmployeeTimeID = _EmployeeTimeID
            End Get
            Set(value As Integer)
                _EmployeeTimeID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeTimeDetailID() As Short
            Get
                EmployeeTimeDetailID = _EmployeeTimeDetailID
            End Get
            Set(value As Short)
                _EmployeeTimeDetailID = value
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
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Date", IsReadOnlyColumn:=True)>
        Public Property EmployeeDate() As Date
            Get
                EmployeeDate = _EmployeeDate
            End Get
            Set(value As Date)
                _EmployeeDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Name", IsReadOnlyColumn:=True)>
        Public Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(value As String)
                _EmployeeName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property Hours() As Decimal
            Get
                Hours = _Hours
            End Get
            Set(value As Decimal)
                _Hours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Rate")>
        Public Property BillableRate() As Decimal
            Get
                BillableRate = _BillableRate
            End Get
            Set(value As Decimal)
                _BillableRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", IsReadOnlyColumn:=True, CustomColumnCaption:="Amount")>
        Public Property TotalBill() As Decimal
            Get
                TotalBill = _TotalBill
            End Get
            Set(value As Decimal)
                _TotalBill = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Markup/Down %", UseMaxValue:=True, MaxValue:=999999.999, UseMinValue:=True, MinValue:=-999999.999)>
        Public Property CommissionPercentage() As Decimal
            Get
                CommissionPercentage = _CommissionPercentage
            End Get
            Set(value As Decimal)
                _CommissionPercentage = value
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
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Total() As Decimal
            Get
                Total = _TotalBill + _MarkupAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property ResaleTax As Decimal
            Get
                ResaleTax = _StateResaleAmount + _CountyResaleAmount + _CityResaleAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Total with Tax")>
        Public ReadOnly Property LineTotal() As Decimal
            Get
                LineTotal = _TotalBill + _MarkupAmount + _StateResaleAmount + _CountyResaleAmount + _CityResaleAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Billable", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ReversedCheckBox)>
        Public Property IsNonBillable As Nullable(Of Short)
            Get
                IsNonBillable = _IsNonBillable
            End Get
            Set(value As Nullable(Of Short))
                _IsNonBillable = value
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
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Fee Flag")>
        Public Property FeeTimeType As Short
            Get
                FeeTimeType = _FeeTimeType
            End Get
            Set(value As Short)
                _FeeTimeType = value
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
        Public Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property EmployeeTimeFlag As Short
            Get
                EmployeeTimeFlag = _EmployeeTimeFlag
            End Get
            Set(value As Short)
                _EmployeeTimeFlag = value
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
        Public Property JobNumber As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Integer)
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property JobComponentNumber As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Short)
                _JobComponentNumber = value
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
        Public Property TaxCommission As Nullable(Of Short)
            Get
                TaxCommission = _TaxCommission.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommission = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Tax Markup Only", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property TaxCommissionOnly As Nullable(Of Short)
            Get
                TaxCommissionOnly = _TaxCommissionOnly.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommissionOnly = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", IsReadOnlyColumn:=True, CustomColumnCaption:="State Percent")>
        Public Property SalesTaxStatePercentage As Decimal
            Get
                SalesTaxStatePercentage = _SalesTaxStatePercentage
            End Get
            Set(value As Decimal)
                _SalesTaxStatePercentage = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", IsReadOnlyColumn:=True, CustomColumnCaption:="County Percent")>
        Public Property SalesTaxCountyPercentage As Decimal
            Get
                SalesTaxCountyPercentage = _SalesTaxCountyPercentage
            End Get
            Set(value As Decimal)
                _SalesTaxCountyPercentage = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", IsReadOnlyColumn:=True, CustomColumnCaption:="City Percent")>
        Public Property SalesTaxCityPercentage As Decimal
            Get
                SalesTaxCityPercentage = _SalesTaxCityPercentage
            End Get
            Set(value As Decimal)
                _SalesTaxCityPercentage = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="State Amount")>
        Public Property StateResaleAmount As Decimal
            Get
                StateResaleAmount = _StateResaleAmount
            End Get
            Set(value As Decimal)
                _StateResaleAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="County Amount")>
        Public Property CountyResaleAmount As Decimal
            Get
                CountyResaleAmount = _CountyResaleAmount
            End Get
            Set(value As Decimal)
                _CountyResaleAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="City Amount")>
        Public Property CityResaleAmount As Decimal
            Get
                CityResaleAmount = _CityResaleAmount
            End Get
            Set(value As Decimal)
                _CityResaleAmount = value
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
        Public Property EmployeeRateFrom As String
            Get
                EmployeeRateFrom = _EmployeeRateFrom
            End Get
            Set(value As String)
                _EmployeeRateFrom = value
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
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="Task", PropertyType:=BaseClasses.Methods.PropertyTypes.TaskCode)>
        Public Property TaskCode As String
            Get
                TaskCode = _TaskCode
            End Get
            Set(value As String)
                _TaskCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Function ShallowCopy() As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem

            Dim EmployeeTimeItemCopy As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem = Nothing

            EmployeeTimeItemCopy = DirectCast(Me.MemberwiseClone(), AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem)

            ShallowCopy = EmployeeTimeItemCopy

        End Function

#End Region

    End Class

End Namespace