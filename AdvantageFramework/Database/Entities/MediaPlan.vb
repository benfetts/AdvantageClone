Namespace Database.Entities

    <Table("MEDIA_PLAN")>
    Public Class MediaPlan
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Description
            CreatedByUserCode
            CreatedDate
            ModifiedByUserCode
            ModifiedDate
            Comment
            ClientCode
            DivisionCode
            ProductCode
            ClientContactID
            StartDate
            EndDate
            GrossBudgetAmount
            SyncDetailSettings
            IsInactive
            SyncFieldWidths
            IsTemplate
            CampaignID
            CountryID
            MediaPlanTemplateHeaderID
            Client
            MediaPlanDetails
            MediaPlanDetailLevelLineDatas
            MediaPlanDetailLevelLines
            MediaPlanDetailLevels
            MediaPlanDetailFields
            MediaPlanDetailLevelLineTags
            MediaPlanDetailSettings
            MediaPlanDetailChangeLogs
            DigitalResults
            MediaPlanMasterPlanDetails
            Campaign
            Country
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_PLAN_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <MaxLength(100)>
        <Column("DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Description() As String
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
        <Required(AllowEmptyStrings:=True)>
        <Column("COMMENT", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comment() As String
        <Required>
        <MaxLength(6)>
        <Column("CL_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ClientCode() As String
        <Required>
        <MaxLength(6)>
        <Column("DIV_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DivisionCode() As String
        <Required>
        <MaxLength(6)>
        <Column("PRD_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ProductCode() As String
        <Column("CDP_CONTACT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactID() As Nullable(Of Integer)
        <Required>
        <Column("START_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StartDate() As Date
        <Required>
        <Column("END_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EndDate() As Date
        <Column("GROSS_BUDGET_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(19, 2)>
        Public Property GrossBudgetAmount() As Nullable(Of Decimal)
        <Required>
        <Column("SYNC_DETAIL_SETTINGS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SyncDetailSettings() As Boolean
        <Required>
        <Column("IS_INACTIVE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Boolean
        <Required>
        <Column("SYNC_FIELD_WIDTHS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property SyncFieldWidths() As Boolean
        <Required>
        <Column("IS_TEMPLATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsTemplate() As Boolean
        <Column("CMP_IDENTIFIER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.CampaignID)>
        Public Property CampaignID() As Nullable(Of Integer)
        <Required>
        <Column("COUNTRY_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CountryID() As Integer
        <Column("MEDIA_PLAN_TEMPLATE_HEADER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaPlanTemplateHeaderID() As Nullable(Of Integer)

        Public Overridable Property Client As Database.Entities.Client
        <ForeignKey("ClientCode, DivisionCode")>
        Public Overridable Property Division As Database.Entities.Division
        <ForeignKey("ClientCode, DivisionCode, ProductCode")>
        Public Overridable Property Product As Database.Entities.Product
        Public Overridable Property MediaPlanDetails As ICollection(Of Database.Entities.MediaPlanDetail)
        Public Overridable Property MediaPlanDetailLevelLineDatas As ICollection(Of Database.Entities.MediaPlanDetailLevelLineData)
        Public Overridable Property MediaPlanDetailLevelLines As ICollection(Of Database.Entities.MediaPlanDetailLevelLine)
        Public Overridable Property MediaPlanDetailLevels As ICollection(Of Database.Entities.MediaPlanDetailLevel)
        Public Overridable Property MediaPlanDetailFields As ICollection(Of Database.Entities.MediaPlanDetailField)
        Public Overridable Property MediaPlanDetailLevelLineTags As ICollection(Of Database.Entities.MediaPlanDetailLevelLineTag)
        Public Overridable Property MediaPlanDetailSettings As ICollection(Of Database.Entities.MediaPlanDetailSetting)
        Public Overridable Property MediaPlanDetailChangeLogs As ICollection(Of Database.Entities.MediaPlanDetailChangeLog)
        Public Overridable Property DigitalResults As ICollection(Of Database.Entities.DigitalResult)
        Public Overridable Property MediaPlanMasterPlanDetails As ICollection(Of Database.Entities.MediaPlanMasterPlanDetail)
        Public Overridable Property MediaPlanDetailPackageDetails As ICollection(Of Database.Entities.MediaPlanDetailPackageDetail)
        Public Overridable Property Campaign As Database.Entities.Campaign
        Public Overridable Property MediaPlanDetailPackagePlacementNames As ICollection(Of Database.Entities.MediaPlanDetailPackagePlacementName)
        Public Overridable Property Country As Database.Entities.Country

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
