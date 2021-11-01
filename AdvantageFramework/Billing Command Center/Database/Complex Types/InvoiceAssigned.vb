Namespace BillingCommandCenter.Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="BCCObjectContext", Name:="InvoiceAssigned")>
    <Serializable()>
    Public Class InvoiceAssigned
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ARInvoiceNumber
            ARInvoiceSequence
            ARInvoiceDate
            ARInvoiceAmount
            RecordType
        End Enum

#End Region

#Region " Variables "

        Private _ARInvoiceNumber As Integer = Nothing
        Private _ARInvoiceSequence As Short = Nothing
        Private _ARInvoiceDate As Nullable(Of Date) = Nothing
        Private _ARInvoiceAmount As Nullable(Of Decimal) = Nothing
        Private _RecordType As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ARInvoiceNumber() As Integer
            Get
                ARInvoiceNumber = _ARInvoiceNumber
            End Get
            Set(value As Integer)
                _ARInvoiceNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="AR Inv SEQ")>
        Public Property ARInvoiceSequence() As Short
            Get
                ARInvoiceSequence = _ARInvoiceSequence
            End Get
            Set(value As Short)
                _ARInvoiceSequence = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ARInvoiceDate() As Nullable(Of Date)
            Get
                ARInvoiceDate = _ARInvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _ARInvoiceDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ARInvoiceAmount() As Nullable(Of Decimal)
            Get
                ARInvoiceAmount = _ARInvoiceAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ARInvoiceAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RecordType() As String
            Get
                RecordType = _RecordType
            End Get
            Set(value As String)
                _RecordType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ARInvoiceNumber.ToString

        End Function

#End Region

    End Class

End Namespace
