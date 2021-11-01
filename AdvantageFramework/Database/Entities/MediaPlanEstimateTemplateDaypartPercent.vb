Namespace Database.Entities

    <Table("MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART_PERCENT")>
    Public Class MediaPlanEstimateTemplateDaypartPercent
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaPlanEstimateTemplateDaypartID
            Percentage
            MarketCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART_PERCENT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaPlanEstimateTemplateDaypartID() As Integer
        <Required>
        <Column("PERCENTAGE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Percentage() As Short
        <MaxLength(10)>
        <Column("MARKET_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MarketCode() As String

        <ForeignKey("MediaPlanEstimateTemplateDaypartID")>
        Public Overridable Property MediaPlanEstimateTemplateDaypart As Database.Entities.MediaPlanEstimateTemplateDaypart
        <ForeignKey("MarketCode")>
        Public Overridable Property Daypart As Database.Entities.Market

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
