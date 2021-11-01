Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="EstimateTask")>
    <Serializable()>
    Public Class EstimateTask
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FunctionCode
            EstimateFunctionCode
            DefaultRole
            EmployeeCode
            EmployeeName
            EstimateRevisionRate
            EstimateRevisionExtendedAmount
            ExtendedMarkupAmount
            ExtendedContingency
            IncludeCPU
            TaxStatePercent
            TaxCountyPercent
            TaxCityPercent
            TaxCommissionOnly
            ExtendedStateResale
            ExtendedCountyResale
            ExtendedCityResale
            ExtendedMarkupContingency
            FunctionType
            EstimatePhaseDescription
            FunctionHeadingID
            FunctionConsolidation
            FunctionConsolodationDescription
            EmployeeTitle
            TaskCode
            TaskDescription
            TaskOrder
            DaysToComplete
            HoursAllowed
            IsMilestone
            DefaultStatus
            FunctionDescription
            EstimateFunctionComment
            EstimateRevisionSuppliedByCode
            EstimateRevisionQuantity
            TaxCode
            EstimateRevisionCommissionPercent
            LineTotal
            EstimateRevisionContingencyPercent
            TaxCommission
            TaxReslae
            ExtendedNonresaleTax
            ExtendedStateContingency
            ExtendedCountyContingency
            ExtendedCityContingency
            ExtendedNonresaleContingency
            LineTotalContingency
            EstimateCPMFlag
            EstimateFunctionType
            EstimateCommissionFlag
            EstimateTaxFlag
            EstimateNonbillFlag
            FeeTime
            EmployeeTitleID
            EstimatePhaseID
            FunctionHeadingDescription
            FunctionHeadingSequence
            SalesTaxStatePercent
            SalesTaxCountyPercent
            SalesTaxCityPercent
        End Enum

#End Region

#Region " Variables "

        Private _FunctionCode As String = Nothing
        Private _EstimateFunctionCode As String = Nothing
        Private _DefaultRole As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _EstimateRevisionRate As Nullable(Of Decimal) = Nothing
        Private _EstimateRevisionExtendedAmount As Nullable(Of Decimal) = Nothing
        Private _ExtendedMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _ExtendedContingency As Nullable(Of Decimal) = Nothing
        Private _IncludeCPU As Short = Nothing
        Private _TaxStatePercent As Decimal = Nothing
        Private _TaxCountyPercent As Decimal = Nothing
        Private _TaxCityPercent As Decimal = Nothing
        Private _TaxCommissionOnly As Nullable(Of Short) = Nothing
        Private _ExtendedStateResale As Decimal = Nothing
        Private _ExtendedCountyResale As Decimal = Nothing
        Private _ExtendedCityResale As Decimal = Nothing
        Private _ExtendedMarkupContingency As Nullable(Of Decimal) = Nothing
        Private _FunctionType As String = Nothing
        Private _EstimatePhaseDescription As String = Nothing
        Private _FunctionHeadingID As Nullable(Of Integer) = Nothing
        Private _FunctionConsolidation As String = Nothing
        Private _FunctionConsolodationDescription As String = Nothing
        Private _EmployeeTitle As String = Nothing
        Private _TaskCode As String = Nothing
        Private _TaskDescription As String = Nothing
        Private _TaskOrder As Nullable(Of Short) = Nothing
        Private _DaysToComplete As Nullable(Of Short) = Nothing
        Private _HoursAllowed As Nullable(Of Decimal) = Nothing
        Private _IsMilestone As Short = Nothing
        Private _DefaultStatus As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _EstimateFunctionComment As String = Nothing
        Private _EstimateRevisionSuppliedByCode As String = Nothing
        Private _EstimateRevisionQuantity As Nullable(Of Decimal) = Nothing
        Private _TaxCode As String = Nothing
        Private _EstimateRevisionCommissionPercent As Nullable(Of Decimal) = Nothing
        Private _LineTotal As Nullable(Of Decimal) = Nothing
        Private _EstimateRevisionContingencyPercent As Nullable(Of Decimal) = Nothing
        Private _TaxCommission As Nullable(Of Short) = Nothing
        Private _TaxReslae As Nullable(Of Short) = Nothing
        Private _ExtendedNonresaleTax As Nullable(Of Decimal) = Nothing
        Private _ExtendedStateContingency As Nullable(Of Decimal) = Nothing
        Private _ExtendedCountyContingency As Nullable(Of Decimal) = Nothing
        Private _ExtendedCityContingency As Nullable(Of Decimal) = Nothing
        Private _ExtendedNonresaleContingency As Nullable(Of Decimal) = Nothing
        Private _LineTotalContingency As Nullable(Of Decimal) = Nothing
        Private _EstimateCPMFlag As Nullable(Of Short) = Nothing
        Private _EstimateFunctionType As String = Nothing
        Private _EstimateCommissionFlag As Nullable(Of Short) = Nothing
        Private _EstimateTaxFlag As Nullable(Of Short) = Nothing
        Private _EstimateNonbillFlag As Nullable(Of Short) = Nothing
        Private _FeeTime As Nullable(Of Short) = Nothing
        Private _EmployeeTitleID As Nullable(Of Integer) = Nothing
        Private _EstimatePhaseID As Nullable(Of Short) = Nothing
        Private _FunctionHeadingDescription As String = Nothing
        Private _FunctionHeadingSequence As Nullable(Of Integer) = Nothing
        Private _SalesTaxStatePercent As Nullable(Of Decimal) = Nothing
        Private _SalesTaxCountyPercent As Nullable(Of Decimal) = Nothing
        Private _SalesTaxCityPercent As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateFunctionCode() As String
            Get
                EstimateFunctionCode = _EstimateFunctionCode
            End Get
            Set(value As String)
                _EstimateFunctionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DefaultRole() As String
            Get
                DefaultRole = _DefaultRole
            End Get
            Set(value As String)
                _DefaultRole = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(value As String)
                _EmployeeName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateRevisionRate() As Nullable(Of Decimal)
            Get
                EstimateRevisionRate = _EstimateRevisionRate
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimateRevisionRate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateRevisionExtendedAmount() As Nullable(Of Decimal)
            Get
                EstimateRevisionExtendedAmount = _EstimateRevisionExtendedAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimateRevisionExtendedAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedMarkupAmount() As Nullable(Of Decimal)
            Get
                ExtendedMarkupAmount = _ExtendedMarkupAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedMarkupAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedContingency() As Nullable(Of Decimal)
            Get
                ExtendedContingency = _ExtendedContingency
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedContingency = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IncludeCPU() As Short
            Get
                IncludeCPU = _IncludeCPU
            End Get
            Set(value As Short)
                _IncludeCPU = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxStatePercent() As Decimal
            Get
                TaxStatePercent = _TaxStatePercent
            End Get
            Set(value As Decimal)
                _TaxStatePercent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCountyPercent() As Decimal
            Get
                TaxCountyPercent = _TaxCountyPercent
            End Get
            Set(value As Decimal)
                _TaxCountyPercent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCityPercent() As Decimal
            Get
                TaxCityPercent = _TaxCityPercent
            End Get
            Set(value As Decimal)
                _TaxCityPercent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCommissionOnly() As Nullable(Of Short)
            Get
                TaxCommissionOnly = _TaxCommissionOnly
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommissionOnly = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedStateResale() As Decimal
            Get
                ExtendedStateResale = _ExtendedStateResale
            End Get
            Set(value As Decimal)
                _ExtendedStateResale = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedCountyResale() As Decimal
            Get
                ExtendedCountyResale = _ExtendedCountyResale
            End Get
            Set(value As Decimal)
                _ExtendedCountyResale = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedCityResale() As Decimal
            Get
                ExtendedCityResale = _ExtendedCityResale
            End Get
            Set(value As Decimal)
                _ExtendedCityResale = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedMarkupContingency() As Nullable(Of Decimal)
            Get
                ExtendedMarkupContingency = _ExtendedMarkupContingency
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedMarkupContingency = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(value As String)
                _FunctionType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimatePhaseDescription() As String
            Get
                EstimatePhaseDescription = _EstimatePhaseDescription
            End Get
            Set(value As String)
                _EstimatePhaseDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionHeadingID() As Nullable(Of Integer)
            Get
                FunctionHeadingID = _FunctionHeadingID
            End Get
            Set(value As Nullable(Of Integer))
                _FunctionHeadingID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionConsolidation() As String
            Get
                FunctionConsolidation = _FunctionConsolidation
            End Get
            Set(value As String)
                _FunctionConsolidation = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionConsolodationDescription() As String
            Get
                FunctionConsolodationDescription = _FunctionConsolodationDescription
            End Get
            Set(value As String)
                _FunctionConsolodationDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeTitle() As String
            Get
                EmployeeTitle = _EmployeeTitle
            End Get
            Set(value As String)
                _EmployeeTitle = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property TaskCode() As String
            Get
                TaskCode = _TaskCode
            End Get
            Set(value As String)
                _TaskCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property TaskDescription() As String
            Get
                TaskDescription = _TaskDescription
            End Get
            Set(value As String)
                _TaskDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaskOrder() As Nullable(Of Short)
            Get
                TaskOrder = _TaskOrder
            End Get
            Set(value As Nullable(Of Short))
                _TaskOrder = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DaysToComplete() As Nullable(Of Short)
            Get
                DaysToComplete = _DaysToComplete
            End Get
            Set(value As Nullable(Of Short))
                _DaysToComplete = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property HoursAllowed() As Nullable(Of Decimal)
            Get
                HoursAllowed = _HoursAllowed
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAllowed = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsMilestone() As Short
            Get
                IsMilestone = _IsMilestone
            End Get
            Set(value As Short)
                _IsMilestone = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DefaultStatus() As String
            Get
                DefaultStatus = _DefaultStatus
            End Get
            Set(value As String)
                _DefaultStatus = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateFunctionComment() As String
            Get
                EstimateFunctionComment = _EstimateFunctionComment
            End Get
            Set(value As String)
                _EstimateFunctionComment = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateRevisionSuppliedByCode() As String
            Get
                EstimateRevisionSuppliedByCode = _EstimateRevisionSuppliedByCode
            End Get
            Set(value As String)
                _EstimateRevisionSuppliedByCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateRevisionQuantity() As Nullable(Of Decimal)
            Get
                EstimateRevisionQuantity = _EstimateRevisionQuantity
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimateRevisionQuantity = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCode() As String
            Get
                TaxCode = _TaxCode
            End Get
            Set(value As String)
                _TaxCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateRevisionCommissionPercent() As Nullable(Of Decimal)
            Get
                EstimateRevisionCommissionPercent = _EstimateRevisionCommissionPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimateRevisionCommissionPercent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property LineTotal() As Nullable(Of Decimal)
            Get
                LineTotal = _LineTotal
            End Get
            Set(value As Nullable(Of Decimal))
                _LineTotal = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateRevisionContingencyPercent() As Nullable(Of Decimal)
            Get
                EstimateRevisionContingencyPercent = _EstimateRevisionContingencyPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimateRevisionContingencyPercent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCommission() As Nullable(Of Short)
            Get
                TaxCommission = _TaxCommission
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommission = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxReslae() As Nullable(Of Short)
            Get
                TaxReslae = _TaxReslae
            End Get
            Set(value As Nullable(Of Short))
                _TaxReslae = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedNonresaleTax() As Nullable(Of Decimal)
            Get
                ExtendedNonresaleTax = _ExtendedNonresaleTax
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedNonresaleTax = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedStateContingency() As Nullable(Of Decimal)
            Get
                ExtendedStateContingency = _ExtendedStateContingency
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedStateContingency = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedCountyContingency() As Nullable(Of Decimal)
            Get
                ExtendedCountyContingency = _ExtendedCountyContingency
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedCountyContingency = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedCityContingency() As Nullable(Of Decimal)
            Get
                ExtendedCityContingency = _ExtendedCityContingency
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedCityContingency = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedNonresaleContingency() As Nullable(Of Decimal)
            Get
                ExtendedNonresaleContingency = _ExtendedNonresaleContingency
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedNonresaleContingency = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property LineTotalContingency() As Nullable(Of Decimal)
            Get
                LineTotalContingency = _LineTotalContingency
            End Get
            Set(value As Nullable(Of Decimal))
                _LineTotalContingency = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateCPMFlag() As Nullable(Of Short)
            Get
                EstimateCPMFlag = _EstimateCPMFlag
            End Get
            Set(value As Nullable(Of Short))
                _EstimateCPMFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateFunctionType() As String
            Get
                EstimateFunctionType = _EstimateFunctionType
            End Get
            Set(value As String)
                _EstimateFunctionType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateCommissionFlag() As Nullable(Of Short)
            Get
                EstimateCommissionFlag = _EstimateCommissionFlag
            End Get
            Set(value As Nullable(Of Short))
                _EstimateCommissionFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateTaxFlag() As Nullable(Of Short)
            Get
                EstimateTaxFlag = _EstimateTaxFlag
            End Get
            Set(value As Nullable(Of Short))
                _EstimateTaxFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimateNonbillFlag() As Nullable(Of Short)
            Get
                EstimateNonbillFlag = _EstimateNonbillFlag
            End Get
            Set(value As Nullable(Of Short))
                _EstimateNonbillFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FeeTime() As Nullable(Of Short)
            Get
                FeeTime = _FeeTime
            End Get
            Set(value As Nullable(Of Short))
                _FeeTime = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeTitleID() As Nullable(Of Integer)
            Get
                EmployeeTitleID = _EmployeeTitleID
            End Get
            Set(value As Nullable(Of Integer))
                _EmployeeTitleID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EstimatePhaseID() As Nullable(Of Short)
            Get
                EstimatePhaseID = _EstimatePhaseID
            End Get
            Set(value As Nullable(Of Short))
                _EstimatePhaseID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionHeadingDescription() As String
            Get
                FunctionHeadingDescription = _FunctionHeadingDescription
            End Get
            Set(value As String)
                _FunctionHeadingDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionHeadingSequence() As Nullable(Of Integer)
            Get
                FunctionHeadingSequence = _FunctionHeadingSequence
            End Get
            Set(value As Nullable(Of Integer))
                _FunctionHeadingSequence = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SalesTaxStatePercent() As Nullable(Of Decimal)
            Get
                SalesTaxStatePercent = _SalesTaxStatePercent
            End Get
            Set(value As Nullable(Of Decimal))
                _SalesTaxStatePercent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SalesTaxCountyPercent() As Nullable(Of Decimal)
            Get
                SalesTaxCountyPercent = _SalesTaxCountyPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _SalesTaxCountyPercent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SalesTaxCityPercent() As Nullable(Of Decimal)
            Get
                SalesTaxCityPercent = _SalesTaxCityPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _SalesTaxCityPercent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.FunctionCode.ToString

        End Function

#End Region

    End Class

End Namespace
