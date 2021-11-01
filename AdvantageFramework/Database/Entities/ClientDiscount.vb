Namespace Database.Entities

    <Table("CLIENT_DISCOUNT")>
    Public Class ClientDiscount
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Name
            Percent
            IsInactive
            ClientDiscountExclusions
            Clients
            JobComponents
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <MaxLength(6)>
        <Column("CLIENT_DISCOUNT_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
        Public Property Code() As String
        <Required>
        <MaxLength(100)>
        <Column("NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(3, 2)>
        <Column("PERCENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Percent() As Decimal
        <Required>
        <Column("IS_INACTIVE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsInactive() As Boolean

        Public Overridable Property ClientDiscountExclusions As ICollection(Of Database.Entities.ClientDiscountExclusion)
        Public Overridable Property Clients As ICollection(Of Database.Entities.Client)
        Public Overridable Property JobComponents As ICollection(Of Database.Entities.JobComponent)
#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Name

        End Function

#End Region

    End Class

End Namespace
