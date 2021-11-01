Namespace Database.Entities

    <Table("CLIENT_DISCOUNT_EXCLUSION")>
    Public Class ClientDiscountExclusion
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientDiscountCode
            FunctionCode
            ClientDiscount
            [Function]
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("CLIENT_DISCOUNT_EXCLUSION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <MaxLength(6)>
        <Column("CLIENT_DISCOUNT_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ClientDiscountCode() As String
        <Required>
        <MaxLength(6)>
        <Column("FNC_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.FunctionCode)>
        Public Property FunctionCode() As String

        Public Overridable Property ClientDiscount As Database.Entities.ClientDiscount
        Public Overridable Property [Function] As Database.Entities.Function

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.ClientDiscountCode & " - " & Me.FunctionCode

        End Function

#End Region

    End Class

End Namespace
