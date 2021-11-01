Namespace BillingCommandCenter.Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="BCCObjectContext", Name:="InvoiceAssignedJournalEntry")>
    <Serializable()>
    Public Class InvoiceAssignedJournalEntry
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GLTransaction
            GLSequenceNumber
            GLACode
            GLDescription
            PostPeriodCode
            Amount
            Remark
            ClientCode
            DivisionCode
            ProductCode
        End Enum

#End Region

#Region " Variables "

        Private _GLTransaction As Integer = Nothing
        Private _GLSequenceNumber As Short = Nothing
        Private _GLACode As String = Nothing
        Private _GLDescription As String = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _Amount As Double = Nothing
        Private _Remark As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLTransaction() As Integer
            Get
                GLTransaction = _GLTransaction
            End Get
            Set(value As Integer)
                _GLTransaction = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="GL SEQ")>
        Public Property GLSequenceNumber() As Short
            Get
                GLSequenceNumber = _GLSequenceNumber
            End Get
            Set(value As Short)
                _GLSequenceNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLACode() As String
            Get
                GLACode = _GLACode
            End Get
            Set(value As String)
                _GLACode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, False)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLDescription() As String
            Get
                GLDescription = _GLDescription
            End Get
            Set(value As String)
                _GLDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(value As String)
                _PostPeriodCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Amount() As Double
            Get
                Amount = _Amount
            End Get
            Set(value As Double)
                _Amount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Remark() As String
            Get
                Remark = _Remark
            End Get
            Set(value As String)
                _Remark = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.GLTransaction.ToString

        End Function

#End Region

    End Class

End Namespace
