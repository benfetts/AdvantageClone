Namespace BillingCommandCenter.Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="BCCObjectContext", Name:="OtherUsersProductionSelection")>
    <Serializable()>
    Public Class OtherUsersProductionSelection
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            BillingCommandCenterID
            BillingUser
            EmployeeName
            JobNumber
            JobComponentNumber
            ClientCode
            DivisionCode
            ProductCode
            BatchName
        End Enum

#End Region

#Region " Variables "

        Private _BillingCommandCenterID As Integer = Nothing
        Private _BillingUser As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _BatchName As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BillingCommandCenterID() As Integer
            Get
                BillingCommandCenterID = _BillingCommandCenterID
            End Get
            Set(value As Integer)
                _BillingCommandCenterID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BillingUser() As String
            Get
                BillingUser = _BillingUser
            End Get
            Set(value As String)
                _BillingUser = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
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
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Integer)
                _JobNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Component")>
        Public Property JobComponentNumber() As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Short)
                _JobComponentNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BatchName() As String
            Get
                BatchName = _BatchName
            End Get
            Set(value As String)
                _BatchName = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.BillingCommandCenterID.ToString

        End Function

#End Region

    End Class

End Namespace
