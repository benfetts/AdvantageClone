Namespace Database.Entities

    <Table("MEDIA_PLAN_DTL")>
    Public Class MediaPlanDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaPlanID
            SalesClassType
            SalesClassCode
            IsEstimateGrossAmount
            IsCalendarMonth
            Color
            Notes
            CreatedByUserCode
            CreatedDate
            ModifiedByUserCode
            ModifiedDate
            CalculateDollars
            ShowColumnTotals
            ShowRowTotals
            CampaignID
            ShowRowGrandTotals
            ShowColumnGrandTotals
            Name
            IsApproved
            ApprovedBy
            ApprovedDate
            SplitWeeks
            OrderGrouping
            OrderNumber
            BuyerEmployeeCode
            IsCable
            CreateOrderOption
            ShowRowTotalsValues
            ShowRowGrandTotalsValues
            AllowCampaignLevel
            PeriodType
            LockedByUserCode
            LevelLineEditLockedByUserCode
            MediaPlanEstimateTemplateID
            MediaDemographicID
            RatingsServiceID
            MediaPlan
            SalesClass
            MediaPlanDetailLevelLineDatas
            MediaPlanDetailLevelLines
            MediaPlanDetailLevels
            MediaPlanDetailFields
            MediaPlanDetailLevelLineTags
            MediaPlanDetailSettings
            MediaPlanDetailChangeLogs
            DigitalResults
            MediaDemographic
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_PLAN_DTL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_PLAN_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanID() As Integer
        <Required>
        <MaxLength(1)>
        <Column("SC_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SalesClassType() As String
        <MaxLength(6)>
        <Column("SC_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SalesClassCode() As String
        <Required>
        <Column("IS_ESTIMATE_GROSS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsEstimateGrossAmount() As Boolean
        <Required>
        <Column("IS_CALENDAR_MONTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsCalendarMonth() As Boolean
        <Required>
        <Column("COLOR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Color() As Integer
        <Column("NOTES", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Notes() As String
        <Required>
        <MaxLength(100)>
        <Column("USER_CREATED", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedByUserCode() As String
        <Required>
        <Column("CREATED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedDate() As Date
        <MaxLength(100)>
        <Column("USER_MODIFIED", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedByUserCode() As String
        <Column("MODIFIED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedDate() As Nullable(Of Date)
        <Required>
        <Column("CALCULATE_DOLLARS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CalculateDollars() As Boolean
        <Required>
        <Column("SHOW_COLUMN_TOTALS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowColumnTotals() As Boolean
        <Required>
        <Column("SHOW_ROW_TOTALS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowRowTotals() As Boolean
        <Column("CMP_IDENTIFIER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignID() As Nullable(Of Integer)
        <Required>
        <Column("SHOW_ROW_GRAND_TOTALS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowRowGrandTotals() As Boolean
        <Required>
        <Column("SHOW_COLUMN_GRAND_TOTALS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowColumnGrandTotals() As Boolean
        <Required>
        <MaxLength(50)>
        <Column("NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name() As String
        <Required>
        <Column("APPROVED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsApproved() As Boolean
        <MaxLength(6)>
        <Column("APPROVED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovedBy() As String
        <Column("APPROVED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovedDate() As Nullable(Of Date)
        <Required>
        <Column("SPLIT_WEEKS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SplitWeeks() As Boolean
        <Required>
        <Column("ORDER_GROUPING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OrderGrouping() As Integer
        <Required>
        <Column("ORDER_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OrderNumber() As Integer
        <MaxLength(6)>
        <Column("BUYER_EMP_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BuyerEmployeeCode() As String
        <Column("GROSS_BUDGET_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(19, 2)>
        Public Property GrossBudgetAmount() As Decimal
        <Required>
        <Column("IS_CABLE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsCable() As Boolean
        <Required>
        <Column("CREATE_ORDER_OPTION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreateOrderOption() As Integer
        <Required>
        <Column("SHOW_ROW_TOTALS_VALUES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowRowTotalsValues() As Boolean
        <Required>
        <Column("SHOW_ROW_GRAND_TOTALS_VALUES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowRowGrandTotalsValues() As Boolean
        <Required>
        <Column("ALLOW_CAMPAIGN_LEVEL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AllowCampaignLevel() As Boolean
        <Required>
        <Column("PERIOD_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PeriodType() As Integer
        <MaxLength(100)>
        <Column("LOCKED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LockedByUserCode() As String
        <MaxLength(100)>
        <Column("LEVEL_LINE_EDIT_LOCKED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LevelLineEditLockedByUserCode() As String
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaPlanEstimateTemplateID() As Nullable(Of Integer)
        <Column("MEDIA_DEMO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaDemographicID() As Nullable(Of Integer)
        <Required>
        <Column("RATINGS_SERVICE_ID")>
        Public Property RatingsServiceID() As AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID

        Public Overridable Property MediaPlan As Database.Entities.MediaPlan
        Public Overridable Property SalesClass As Database.Entities.SalesClass
        Public Overridable Property MediaPlanDetailLevelLineDatas As ICollection(Of Database.Entities.MediaPlanDetailLevelLineData)
        Public Overridable Property MediaPlanDetailLevelLines As ICollection(Of Database.Entities.MediaPlanDetailLevelLine)
        Public Overridable Property MediaPlanDetailLevels As ICollection(Of Database.Entities.MediaPlanDetailLevel)
        Public Overridable Property MediaPlanDetailFields As ICollection(Of Database.Entities.MediaPlanDetailField)
        Public Overridable Property MediaPlanDetailLevelLineTags As ICollection(Of Database.Entities.MediaPlanDetailLevelLineTag)
        Public Overridable Property MediaPlanDetailSettings As ICollection(Of Database.Entities.MediaPlanDetailSetting)
        Public Overridable Property MediaPlanDetailChangeLogs As ICollection(Of Database.Entities.MediaPlanDetailChangeLog)
        Public Overridable Property DigitalResults As ICollection(Of Database.Entities.DigitalResult)
        Public Overridable Property MediaPlanDetailPackageDetails As ICollection(Of Database.Entities.MediaPlanDetailPackageDetail)
        Public Overridable Property MediaPlanDetailPackagePlacementNames As ICollection(Of Database.Entities.MediaPlanDetailPackagePlacementName)
        Public Overridable Property MediaDemographic As Database.Entities.MediaDemographic
        Public Overridable Property MediaPlanDetailGRPBudgets As ICollection(Of Database.Entities.MediaPlanDetailGRPBudget)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
