Namespace Database.Entities

	<Table("MEDIA_PLAN_MASTER_PLAN_DETAIL")>
	Public Class MediaPlanMasterPlanDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			MediaPlanMasterPlanID
			MediaPlanID
			MediaPlan
			MediaPlanMasterPlan

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("MEDIA_PLAN_MASTER_PLAN_DETAIL_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("MEDIA_PLAN_MASTER_PLAN_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaPlanMasterPlanID() As Integer
		<Required>
		<Column("MEDIA_PLAN_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaPlanID() As Integer

        Public Overridable Property MediaPlan As Database.Entities.MediaPlan
        Public Overridable Property MediaPlanMasterPlan As Database.Entities.MediaPlanMasterPlan

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
