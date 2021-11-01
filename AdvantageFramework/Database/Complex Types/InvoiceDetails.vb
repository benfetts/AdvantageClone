Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="InvoiceDetails")>
    <Serializable()>
    Public Class InvoiceDetails
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            APID
            APCHKNBR
            APCHKDATE
            CHKAMT
        End Enum

#End Region

#Region " Variables "

        Private _AP_ID As Integer = Nothing
        Private _AP_CHK_NBR As Integer = Nothing
        Private _AP_CHK_DATE As Date = Nothing
        Private _CHK_AMT As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AP_ID() As Integer
            Get
                AP_ID = _AP_ID
            End Get
            Set(value As Integer)
                _AP_ID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Check Number")>
        Public Property AP_CHK_NBR() As Integer
            Get
                AP_CHK_NBR = _AP_CHK_NBR
            End Get
            Set(value As Integer)
                _AP_CHK_NBR = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Date")>
        Public Property AP_CHK_DATE() As Date
            Get
                AP_CHK_DATE = _AP_CHK_DATE
            End Get
            Set(value As Date)
                _AP_CHK_DATE = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Amount")>
        Public Property CHK_AMT() As Nullable(Of Decimal)
            Get
                CHK_AMT = _CHK_AMT
            End Get
            Set(value As Nullable(Of Decimal))
                _CHK_AMT = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AP_ID.ToString

        End Function

#End Region

    End Class

End Namespace
