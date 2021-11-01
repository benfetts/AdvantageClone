Namespace Database.Entities

    <System.ComponentModel.DataAnnotations.Schema.Table("IMP_CLR_CHK_MEDIA_VCC_STAGING")>
    Public Class ImportClearedCheckMediaVCCStaging
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BatchName
            BankCode
            BankReference
            BankAmount
            MerchantName
            ClearedDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Schema.Column("ID"),
        System.ComponentModel.DataAnnotations.Key,
        System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer

        <System.ComponentModel.DataAnnotations.Schema.Column("BATCH_NAME"),
        System.ComponentModel.DataAnnotations.Required,
        System.ComponentModel.DataAnnotations.MaxLength(50),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property BatchName() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("BANK_CODE"),
        System.ComponentModel.DataAnnotations.Required,
        System.ComponentModel.DataAnnotations.MaxLength(4),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property BankCode() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("BANK_REFERENCE"),
        System.ComponentModel.DataAnnotations.Required,
        System.ComponentModel.DataAnnotations.MaxLength(50),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property BankReference() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("BANK_AMT"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        Public Property BankAmount() As Decimal

        <System.ComponentModel.DataAnnotations.Schema.Column("MERCHANT_NAME"),
        System.ComponentModel.DataAnnotations.Required,
        System.ComponentModel.DataAnnotations.MaxLength(30),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MerchantName() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("CLEARED_DATE", TypeName:="datetime"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClearedDate() As Date

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
