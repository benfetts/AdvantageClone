Namespace Database.Entities

    <System.ComponentModel.DataAnnotations.Schema.Table("CR_PAYMENT_TYPE")>
    Public Class CashReceiptPaymentType
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Description
            IsInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Schema.Column("CR_PAYMENT_TYPE_ID"),
        System.ComponentModel.DataAnnotations.Key,
        System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <System.ComponentModel.DataAnnotations.Schema.Column("DESCRIPTION"),
        System.ComponentModel.DataAnnotations.Required,
        System.ComponentModel.DataAnnotations.MaxLength(100),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Description() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("IS_INACTIVE"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
