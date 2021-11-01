Namespace Database.Entities

    <System.ComponentModel.DataAnnotations.Schema.Table("COLLECTED_COST_INFO")>
    Public Class CollectedCostInformation
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OrderNumber
            LineNumber
            GrossAmount
            CommissionPercentage
            NetAmount
            Notes
            AuthorizedBy
            TimeStamp
            AuthorizedByName
            Comments
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Schema.Column("COLLECTED_COST_INFO_ID"),
        System.ComponentModel.DataAnnotations.Key,
        System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer

        <System.ComponentModel.DataAnnotations.Schema.Column("ORDER_NBR"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property OrderNumber() As Integer

        <System.ComponentModel.DataAnnotations.Schema.Column("LINE_NBR"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property LineNumber() As Short

        <System.ComponentModel.DataAnnotations.Schema.Column("REV_NBR"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RevisionNumber() As Short

        <System.ComponentModel.DataAnnotations.Schema.Column("GROSS_AMT"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        Public Property GrossAmount() As Decimal

        <System.ComponentModel.DataAnnotations.Schema.Column("COMISSION_PCT"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        Public Property CommissionPercentage() As Decimal

        <System.ComponentModel.DataAnnotations.Schema.Column("NET_AMOUNT"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        Public Property NetAmount() As Decimal

        <System.ComponentModel.DataAnnotations.Schema.Column("NOTES"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Notes() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("AUTHORIZED_BY"),
        System.ComponentModel.DataAnnotations.MaxLength(100),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property AuthorizedBy() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("CREATED_DATE"),
        System.ComponentModel.DataAnnotations.Required,
        System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CreatedDate() As Date

        <System.ComponentModel.DataAnnotations.Schema.Column("MODIFIED_DATE"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ModifiedDate() As Nullable(Of Date)

        <System.ComponentModel.DataAnnotations.Schema.Column("AUTHORIZED_BY_NAME"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AuthorizedByName() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("IS_QUOTE"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsQuote() As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("COMMENTS"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Comments() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
