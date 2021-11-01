Namespace Database.Entities

    <Table("MEDIA_PLAN_DTL_GRP_BUDGET")>
    Public Class MediaPlanDetailGRPBudget
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaPlanDetailID
            EntryDate
            GRPBudget
            MarketCode
            SpotLength
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_PLAN_DTL_GRP_BUDGET_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_PLAN_DTL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanDetailID() As Integer
        <Required>
        <Column("ENTRY_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EntryDate() As Date
        <Required>
        <Column("GRP_BUDGET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(19, 2)>
        Public Property GRPBudget() As Decimal
        <MaxLength(10)>
        <Column("MARKET_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarketCode() As String
        <Column("SPOT_LENGTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SpotLength() As Nullable(Of Short)

        <ForeignKey("MediaPlanDetailID")>
        Public Overridable Property MediaPlanDetail As Database.Entities.MediaPlanDetail

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
