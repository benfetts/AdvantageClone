<Table("CLIENT_DISCOUNT")>
Public Class ClientDiscount

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <Key>
    <Required>
    <MaxLength(6)>
    <Column("CLIENT_DISCOUNT_CODE", TypeName:="varchar")>
    Public Property Code() As String
    <Required>
    <MaxLength(100)>
    <Column("NAME", TypeName:="varchar")>
    Public Property Name() As String
    <Required>
    <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(3, 2)>
    <Column("PERCENT")>
    Public Property Percent() As Decimal
    <Required>
    <Column("IS_INACTIVE")>
    Public Property IsInactive() As Boolean

#End Region

#Region " Methods "



#End Region

End Class
