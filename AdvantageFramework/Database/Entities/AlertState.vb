Namespace Database.Entities

	<Table("ALERT_STATES")>
	Public Class AlertState
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Name
			SortOrder
			IsActive
			DefaultAlertCategoryID
			Alerts
			AlertCategory
			AlertAssignmentTemplateEmployees
			AlertAssignmentTemplateStates
			WorkflowAlertState
			EndWorkflowAlertState

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ALERT_STATE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("ALERT_STATE_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Name() As String
		<Column("SORT_ORDER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SortOrder() As Nullable(Of Integer)
		<Column("ACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsActive() As Nullable(Of Boolean)
		<Column("DFLT_ALERT_CAT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DefaultAlertCategoryID() As Nullable(Of Integer)

        Public Overridable Property Alerts As ICollection(Of Database.Entities.Alert)
        <ForeignKey("DefaultAlertCategoryID")>
        Public Overridable Property AlertCategory As Database.Entities.AlertCategory
        Public Overridable Property AlertAssignmentTemplateEmployees As ICollection(Of Database.Entities.AlertAssignmentTemplateEmployee)
        Public Overridable Property AlertAssignmentTemplateStates As ICollection(Of Database.Entities.AlertAssignmentTemplateState)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
