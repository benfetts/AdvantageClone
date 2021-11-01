Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="NonbilledEmployeeTime")>
    <Serializable()>
    Public Class NonbilledEmployeeTime
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeTimeID
            EmployeeTimeDetailID
            SequenceNumber
            EmployeeCode
            EmployeeName
            EmployeeDate
            DepartmentTeamCode
            DepartmentTeamDescription
            EmployeeTitleID
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            FunctionCode
            FunctionDescription
            EmployeeHours
            EmployeeNonBillableFlag
            FeeTimeFlag
            BillingRate
            TotalBill
            EmployeeTimeFlag
            EmployeeRateFrom
            EmployeeCommissionPercent
            ExtendedMarkupAmount
            TaxCode
            TaxStatePercent
            TaxCountyPercent
            TaxCityPercent
            TaxResale
            TaxCommission
            TaxCommissionOnly
            ExtendedStateResale
            ExtendedCountyResale
            ExtendedCityResale
            LineTotal
            AdjusterComments
            SalesClassCode
            TaskCode
            TaskDescription
        End Enum

        Public Enum EmployeeTimeFlags
            Unbilled = 0
            Billed = 1
            Indirect = 2
            SelectedForBilling = 3
        End Enum

#End Region

#Region " Variables "

        Private _EmployeeTimeID As Integer = Nothing
        Private _EmployeeTimeDetailID As Short = Nothing
        Private _SequenceNumber As Short = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _EmployeeDate As Date = Nothing
        Private _DepartmentTeamCode As String = Nothing
        Private _DepartmentTeamDescription As String = Nothing
        Private _EmployeeTitleID As Nullable(Of Integer) = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _EmployeeHours As Decimal = Nothing
        Private _EmployeeNonBillableFlag As Nullable(Of Short) = Nothing
        Private _FeeTimeFlag As Nullable(Of Short) = Nothing
        Private _BillingRate As Nullable(Of Decimal) = Nothing
        Private _TotalBill As Nullable(Of Decimal) = Nothing
        Private _EmployeeTimeFlag As Integer = Nothing
        Private _EmployeeRateFrom As String = Nothing
        Private _EmployeeCommissionPercent As Nullable(Of Decimal) = Nothing
        Private _ExtendedMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _TaxCode As String = Nothing
        Private _TaxStatePercent As Nullable(Of Decimal) = Nothing
        Private _TaxCountyPercent As Nullable(Of Decimal) = Nothing
        Private _TaxCityPercent As Nullable(Of Decimal) = Nothing
        Private _TaxResale As Nullable(Of Short) = Nothing
        Private _TaxCommission As Nullable(Of Short) = Nothing
        Private _TaxCommissionOnly As Nullable(Of Short) = Nothing
        Private _ExtendedStateResale As Nullable(Of Decimal) = Nothing
        Private _ExtendedCountyResale As Nullable(Of Decimal) = Nothing
        Private _ExtendedCityResale As Nullable(Of Decimal) = Nothing
        Private _LineTotal As Nullable(Of Decimal) = Nothing
        Private _AdjusterComments As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _ChangeLog As Generic.Dictionary(Of String, Boolean) = Nothing
        Private _TaskCode As String = Nothing
        Private _TaskDescription As String = Nothing

#End Region

#Region " Properties "


        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:=" ", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property EmployeeTimeFlag() As Integer
            Get
                EmployeeTimeFlag = _EmployeeTimeFlag
            End Get
            Set(value As Integer)
                _EmployeeTimeFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeTimeID() As Integer
            Get
                EmployeeTimeID = _EmployeeTimeID
            End Get
            Set(value As Integer)
                _EmployeeTimeID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeTimeDetailID() As Short
            Get
                EmployeeTimeDetailID = _EmployeeTimeDetailID
            End Get
            Set(value As Short)
                _EmployeeTimeDetailID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SequenceNumber() As Short
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(value As Short)
                _SequenceNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Employee", IsReadOnlyColumn:=True)>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", IsReadOnlyColumn:=True)>
        Public Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(value As String)
                _EmployeeName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Date", IsReadOnlyColumn:=True)>
        Public Property EmployeeDate() As Date
            Get
                EmployeeDate = _EmployeeDate
            End Get
            Set(value As Date)
                _EmployeeDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Dept / Team", PropertyType:=BaseClasses.PropertyTypes.DepartmentTeamCode)>
        Public Property DepartmentTeamCode() As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
            Set(value As String)
                _DepartmentTeamCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Dept / Team Description", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.DepartmentTeamName)>
        Public Property DepartmentTeamDescription() As String
            Get
                DepartmentTeamDescription = _DepartmentTeamDescription
            End Get
            Set(value As String)
                _DepartmentTeamDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Employee Title", PropertyType:=BaseClasses.PropertyTypes.EmployeeTitleID)>
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
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client", IsReadOnlyColumn:=True)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", IsReadOnlyColumn:=True)>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division", IsReadOnlyColumn:=True)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", IsReadOnlyColumn:=True)>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product", IsReadOnlyColumn:=True)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", IsReadOnlyColumn:=True)>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job", IsReadOnlyColumn:=True)>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", IsReadOnlyColumn:=True)>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job Comp", IsReadOnlyColumn:=True)>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job Comp Description", IsReadOnlyColumn:=True)>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(value As String)
                _JobComponentDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Function", IsReadOnlyColumn:=True)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", IsReadOnlyColumn:=True)>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Hours", IsReadOnlyColumn:=True)>
        Public Property EmployeeHours() As Decimal
            Get
                EmployeeHours = _EmployeeHours
            End Get
            Set(value As Decimal)
                _EmployeeHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Billable", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ReversedCheckBox)>
        Public Property EmployeeNonBillableFlag() As Nullable(Of Short)
            Get
                EmployeeNonBillableFlag = _EmployeeNonBillableFlag
            End Get
            Set(value As Nullable(Of Short))
                _EmployeeNonBillableFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                SetPropertyAutomaticallyChanged("EmployeeNonBillableFlag", False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="")>
        Public Property FeeTimeFlag() As Nullable(Of Short)
            Get
                FeeTimeFlag = _FeeTimeFlag
            End Get
            Set(value As Nullable(Of Short))
                _FeeTimeFlag = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="")>
        Public Property BillingRate() As Nullable(Of Decimal)
            Get
                BillingRate = _BillingRate
            End Get
            Set(value As Nullable(Of Decimal))
                _BillingRate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
                SetPropertyAutomaticallyChanged("BillingRate", False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Total", IsReadOnlyColumn:=True)>
        Public Property TotalBill() As Nullable(Of Decimal)
            Get
                TotalBill = _TotalBill
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalBill = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeRateFrom() As String
            Get
                EmployeeRateFrom = _EmployeeRateFrom
            End Get
            Set(value As String)
                _EmployeeRateFrom = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeCommissionPercent() As Nullable(Of Decimal)
            Get
                EmployeeCommissionPercent = _EmployeeCommissionPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _EmployeeCommissionPercent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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
        Public Property TaxStatePercent() As Nullable(Of Decimal)
            Get
                TaxStatePercent = _TaxStatePercent
            End Get
            Set(value As Nullable(Of Decimal))
                _TaxStatePercent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCountyPercent() As Nullable(Of Decimal)
            Get
                TaxCountyPercent = _TaxCountyPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _TaxCountyPercent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxCityPercent() As Nullable(Of Decimal)
            Get
                TaxCityPercent = _TaxCityPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _TaxCityPercent = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaxResale() As Nullable(Of Short)
            Get
                TaxResale = _TaxResale
            End Get
            Set(value As Nullable(Of Short))
                _TaxResale = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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
        Public Property TaxCommissionOnly() As Nullable(Of Short)
            Get
                TaxCommissionOnly = _TaxCommissionOnly
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommissionOnly = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedStateResale() As Nullable(Of Decimal)
            Get
                ExtendedStateResale = _ExtendedStateResale
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedStateResale = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedCountyResale() As Nullable(Of Decimal)
            Get
                ExtendedCountyResale = _ExtendedCountyResale
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedCountyResale = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ExtendedCityResale() As Nullable(Of Decimal)
            Get
                ExtendedCityResale = _ExtendedCityResale
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedCityResale = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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
        Public Property AdjusterComments() As String
            Get
                AdjusterComments = _AdjusterComments
            End Get
            Set(value As String)
                _AdjusterComments = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaskCode() As String
            Get
                TaskCode = _TaskCode
            End Get
            Set
                _TaskCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TaskDescription() As String
            Get
                TaskDescription = _TaskDescription
            End Get
            Set
                _TaskDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EmployeeTimeID.ToString

        End Function
        Public Sub SetPropertyAutomaticallyChanged(ByVal PropertyName As String, ByVal AutomaticallyChanged As Boolean)

            If _ChangeLog Is Nothing Then

                _ChangeLog = New Generic.Dictionary(Of String, Boolean)

            End If

            _ChangeLog(PropertyName.ToString) = AutomaticallyChanged

        End Sub
        Public Function GetPropertyAutomaticallyChanged(ByVal PropertyName As String) As Boolean

            'objects
            Dim AutomaticallyChanged As Boolean = False

            If _ChangeLog IsNot Nothing Then

                If _ChangeLog.ContainsKey(PropertyName.ToString) Then

                    AutomaticallyChanged = _ChangeLog(PropertyName.ToString)

                End If

            End If

            GetPropertyAutomaticallyChanged = AutomaticallyChanged

        End Function

#End Region

    End Class

End Namespace
