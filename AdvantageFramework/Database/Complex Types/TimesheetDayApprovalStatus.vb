Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="TimesheetDayApprovalStatus")>
    <Serializable()>
    Public Class TimesheetDayApprovalStatus
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeDate
            TotalHours
            ApprovalType
            PercentOfStandardHours
            StandardHours
            PostPeriodClosed
        End Enum

#End Region

#Region " Variables "

        Private _EmployeeDate As Nullable(Of Date) = Nothing
        Private _TotalHours As Nullable(Of Decimal) = Nothing
        Private _ApprovalType As Nullable(Of Short) = Nothing
        Private _PercentOfStandardHours As Nullable(Of Decimal) = Nothing
        Private _StandardHours As Nullable(Of Decimal) = Nothing
        Private _PostPeriodClosed As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Day")>
        Public Property EmployeeDate() As Nullable(Of Date)
            Get
                EmployeeDate = _EmployeeDate
            End Get
            Set(value As Nullable(Of Date))
                _EmployeeDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Status")>
        Public Property ApprovalType() As Nullable(Of Short)
            Get
                ApprovalType = _ApprovalType
            End Get
            Set(value As Nullable(Of Short))
                _ApprovalType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Hours", DisplayFormat:="F2")>
        Public Property TotalHours() As Nullable(Of Decimal)
            Get
                TotalHours = _TotalHours
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="%", DisplayFormat:="P")>
        Public Property PercentOfStandardHours() As Nullable(Of Decimal)
            Get
                PercentOfStandardHours = _PercentOfStandardHours
            End Get
            Set(value As Nullable(Of Decimal))
                _PercentOfStandardHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property StandardHours() As Nullable(Of Decimal)
            Get
                StandardHours = _StandardHours
            End Get
            Set(value As Nullable(Of Decimal))
                _StandardHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property PostPeriodClosed() As Nullable(Of Integer)
            Get
                PostPeriodClosed = _PostPeriodClosed
            End Get
            Set(value As Nullable(Of Integer))
                _PostPeriodClosed = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EmployeeDate.ToString

        End Function

#End Region

    End Class

End Namespace
