Namespace Database.Entities

	<Table("MEDIA_PLAN_DTL_FIELD")>
	Public Class MediaPlanDetailField
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			MediaPlanDetailID
			MediaPlanID
			FieldID
			IsVisible
			Index
			Area
			AreaIndex
			SortOrder
			Width
			CreatedByUserCode
			CreatedDate
			ModifiedByUserCode
			ModifiedDate
			Caption
			ShowInValues
			ShowInTotals
			ShowInGrandTotals
			MediaPlan
			MediaPlanDetail

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("MEDIA_PLAN_DTL_FIELD_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("MEDIA_PLAN_DTL_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaPlanDetailID() As Integer
		<Required>
		<Column("MEDIA_PLAN_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaPlanID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("FIELD_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FieldID() As String
		<Required>
		<Column("IS_VISIBLE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsVisible() As Boolean
		<Required>
		<Column("INDEX")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Index() As Integer
		<Required>
		<Column("AREA")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Area() As Integer
		<Required>
		<Column("AREA_INDEX")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AreaIndex() As Integer
		<Required>
		<Column("SORT_ORDER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SortOrder() As Integer
		<Required>
		<Column("WIDTH")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Width() As Integer
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
		<MaxLength(100)>
		<Column("CAPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Caption() As String
		<Required>
		<Column("SHOW_VALUES")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowInValues() As Boolean
		<Required>
		<Column("SHOW_TOTALS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowInTotals() As Boolean
		<Required>
		<Column("SHOW_GRAND_TOTALS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowInGrandTotals() As Boolean

        Public Overridable Property MediaPlan As Database.Entities.MediaPlan
        Public Overridable Property MediaPlanDetail As Database.Entities.MediaPlanDetail

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
