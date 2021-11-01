Namespace Database.Entities

	<Table("MEDIA_PLAN_DTL_LEVEL_LINE_TAG")>
	Public Class MediaPlanDetailLevelLineTag
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			MediaPlanDetailLevelLineID
			MediaPlanDetailID
			MediaPlanID
			MarketCode
			VendorCode
			MediaType
			SizeCode
			InternetTypeCode
			DaypartID
			CreatedByUserCode
			CreatedDate
			ModifiedByUserCode
			ModifiedDate
			StartDate
			EndDate
			OutOfHomeTypeCode
			AdNumber
			JobComponentNumber
            JobNumber
            VendorCommission
            VendorMarkup
            CampaignID
            MediaChannelID
            MediaTacticID
            AdSize
			InternetType
			Market
			MediaPlan
			MediaPlanDetail
			MediaPlanDetailLevelLine
			Vendor
			Daypart
			OutOfHomeType
			Ad
			Job
            JobComponent
            Campaign
            MediaChannel
            MediaTactic
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("MEDIA_PLAN_DTL_LEVEL_LINE_TAG_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("MEDIA_PLAN_DTL_LEVEL_LINE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaPlanDetailLevelLineID() As Integer
		<Required>
		<Column("MEDIA_PLAN_DTL_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaPlanDetailID() As Integer
		<Required>
		<Column("MEDIA_PLAN_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaPlanID() As Integer
		<MaxLength(10)>
		<Column("MARKET_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MarketCode() As String
		<MaxLength(6)>
		<Column("VN_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorCode() As String
        <MaxLength(1)>
        <Column("MEDIA_TYPE", Order:=0, TypeName:="varchar")>
        <ForeignKey("AdSize")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaType() As String
		<MaxLength(6)>
        <Column("SIZE_CODE", Order:=1, TypeName:="varchar")>
        <ForeignKey("AdSize")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SizeCode() As String
		<MaxLength(6)>
		<Column("OD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetTypeCode() As String
		<Column("DAY_PART_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DaypartID)>
		Public Property DaypartID() As Nullable(Of Integer)
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
		<Column("START_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StartDate() As Nullable(Of Date)
		<Column("END_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EndDate() As Nullable(Of Date)
		<MaxLength(6)>
		<Column("OUTDOOR_TYPE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutOfHomeTypeCode() As String
		<MaxLength(30)>
		<Column("AD_NBR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdNumber() As String
		<Column("JOB_COMPONENT_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentNumber() As Nullable(Of Short)
		<Column("JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobNumber() As Nullable(Of Integer)
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
		<Column("VN_COMM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F3")>
		Public Property VendorCommission() As Nullable(Of Decimal)
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
		<Column("VN_MARKUP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F3")>
        Public Property VendorMarkup() As Nullable(Of Decimal)
        <Column("CMP_IDENTIFIER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.CampaignID)>
        Public Property CampaignID() As Nullable(Of Integer)
        <Column("MEDIA_CHANNEL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MediaChannelID() As Nullable(Of Integer)
        <Column("MEDIA_TACTIC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MediaTacticID() As Nullable(Of Integer)

        Public Overridable Property AdSize As Database.Entities.AdSize
        Public Overridable Property InternetType As Database.Entities.InternetType
        Public Overridable Property Market As Database.Entities.Market
        Public Overridable Property MediaPlan As Database.Entities.MediaPlan
        Public Overridable Property MediaPlanDetail As Database.Entities.MediaPlanDetail
        Public Overridable Property MediaPlanDetailLevelLine As Database.Entities.MediaPlanDetailLevelLine
        Public Overridable Property Vendor As Database.Entities.Vendor
        Public Overridable Property Daypart As Database.Entities.Daypart
        Public Overridable Property OutOfHomeType As Database.Entities.OutOfHomeType
        Public Overridable Property Ad As Database.Entities.Ad
        Public Overridable Property Job As Database.Entities.Job
        <ForeignKey("JobNumber, JobComponentNumber")>
        Public Overridable Property JobComponent As Database.Entities.JobComponent
        Public Overridable Property Campaign As Database.Entities.Campaign
        Public Overridable Property MediaChannel As Database.Entities.MediaChannel
        Public Overridable Property MediaTactic As Database.Entities.MediaTactic

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
