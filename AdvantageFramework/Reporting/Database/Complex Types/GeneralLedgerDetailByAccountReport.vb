Namespace Reporting.Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ReportingObjectContext", Name:="GeneralLedgerDetailByAccountReport")>
    <Serializable()>
    Public Class GeneralLedgerDetailByAccountReport
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            TransactionID
            AccountCode
            AccountDescription
            AccountType
            TransactionDate
            AccountBeginningBalance
            DebitAmount
            CreditAmount
            Remark
            PostPeriodCode
            PostPeriodDescription
            PostPeriodStartDate
            PostPeriodEndDate
            GLMonth
            GLYear
            PostedToSummary
            ClientCode
            DivisionCode
            ProductCode
            Source
            OfficeSegment
            BaseAccount
            DepartmentSegment
            OtherSegment
            MappedAccount
            Reversing
            UserCode
        End Enum

#End Region

#Region " Variables "

        Private _ID As Nullable(Of System.Guid) = Nothing
        Private _TransactionID As Nullable(Of Integer) = Nothing
        Private _AccountCode As String = Nothing
        Private _AccountDescription As String = Nothing
        Private _AccountType As String = Nothing
        Private _TransactionDate As Nullable(Of Date) = Nothing
        Private _AccountBeginningBalance As Nullable(Of Double) = Nothing
        Private _DebitAmount As Double = Nothing
        Private _CreditAmount As Double = Nothing
        Private _Remark As String = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _PostPeriodDescription As String = Nothing
        Private _PostPeriodStartDate As Nullable(Of Date) = Nothing
        Private _PostPeriodEndDate As Nullable(Of Date) = Nothing
        Private _GLMonth As Nullable(Of Short) = Nothing
        Private _GLYear As String = Nothing
        Private _PostedToSummary As Nullable(Of Date) = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _Source As String = Nothing
        Private _OfficeSegment As String = Nothing
        Private _BaseAccount As String = Nothing
        Private _DepartmentSegment As String = Nothing
        Private _OtherSegment As String = Nothing
        Private _MappedAccount As String = Nothing
        Private _Reversing As String = Nothing
        Private _UserCode As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of System.Guid)
            Get
                ID = _ID
            End Get
            Set
                _ID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property TransactionID() As Nullable(Of Integer)
            Get
                TransactionID = _TransactionID
            End Get
            Set
                _TransactionID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountCode() As String
            Get
                AccountCode = _AccountCode
            End Get
            Set
                _AccountCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountDescription() As String
            Get
                AccountDescription = _AccountDescription
            End Get
            Set
                _AccountDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountType() As String
            Get
                AccountType = _AccountType
            End Get
            Set
                _AccountType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TransactionDate() As Nullable(Of Date)
            Get
                TransactionDate = _TransactionDate
            End Get
            Set
                _TransactionDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AccountBeginningBalance() As Nullable(Of Double)
            Get
                AccountBeginningBalance = _AccountBeginningBalance
            End Get
            Set
                _AccountBeginningBalance = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property DebitAmount() As Double
            Get
                DebitAmount = _DebitAmount
            End Get
            Set
                _DebitAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property CreditAmount() As Double
            Get
                CreditAmount = _CreditAmount
            End Get
            Set
                _CreditAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Remark() As String
            Get
                Remark = _Remark
            End Get
            Set
                _Remark = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set
                _PostPeriodCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostPeriodDescription() As String
            Get
                PostPeriodDescription = _PostPeriodDescription
            End Get
            Set
                _PostPeriodDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostPeriodStartDate() As Nullable(Of Date)
            Get
                PostPeriodStartDate = _PostPeriodStartDate
            End Get
            Set
                _PostPeriodStartDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostPeriodEndDate() As Nullable(Of Date)
            Get
                PostPeriodEndDate = _PostPeriodEndDate
            End Get
            Set
                _PostPeriodEndDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
    System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLMonth() As Nullable(Of Short)
            Get
                GLMonth = _GLMonth
            End Get
            Set
                _GLMonth = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLYear() As String
            Get
                GLYear = _GLYear
            End Get
            Set
                _GLYear = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="F")>
        Public Property PostedToSummary() As Nullable(Of Date)
            Get
                PostedToSummary = _PostedToSummary
            End Get
            Set
                _PostedToSummary = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set
                _ClientCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set
                _DivisionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set
                _ProductCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Source() As String
            Get
                Source = _Source
            End Get
            Set
                _Source = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OfficeSegment() As String
            Get
                OfficeSegment = _OfficeSegment
            End Get
            Set
                _OfficeSegment = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BaseAccount() As String
            Get
                BaseAccount = _BaseAccount
            End Get
            Set
                _BaseAccount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DepartmentSegment() As String
            Get
                DepartmentSegment = _DepartmentSegment
            End Get
            Set
                _DepartmentSegment = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OtherSegment() As String
            Get
                OtherSegment = _OtherSegment
            End Get
            Set
                _OtherSegment = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MappedAccount() As String
            Get
                MappedAccount = _MappedAccount
            End Get
            Set
                _MappedAccount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Reversing() As String
            Get
                Reversing = _Reversing
            End Get
            Set
                _Reversing = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
            Set
                _UserCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(Value, True)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
