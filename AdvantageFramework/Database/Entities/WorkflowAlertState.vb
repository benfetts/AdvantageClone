Namespace Database.Entities

	<Table("WORKFLOW_ALERT_STATE")>
	Public Class WorkflowAlertState
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			WorkflowID
			AlertAssignmentTemplateID
			AlertStateID
			EndAlertAssignmentTemplateID
			EndAlertStateID
			AllowAlertDemotion
			IsActionTrigger
			ChangeAllStatesInTemplate
			AlertAssignmentTemplate
			EndAlertAssignmentTemplate
			AlertState
			EndAlertState
			Workflow

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("WORKFLOW_ALERT_STATE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("WORKFLOW_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property WorkflowID() As Integer
		<Column("ALRT_NOTIFY_HDR_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertAssignmentTemplateID() As Nullable(Of Integer)
		<Column("ALERT_STATE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertStateID() As Nullable(Of Integer)
		<Column("END_ALRT_NOTIFY_HDR_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EndAlertAssignmentTemplateID() As Nullable(Of Integer)
		<Column("END_STATE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EndAlertStateID() As Nullable(Of Integer)
		<Column("ALLOW_ALERT_DEMOTION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AllowAlertDemotion() As Nullable(Of Boolean)
		<Column("IS_ACTION_TRIGGER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsActionTrigger() As Nullable(Of Boolean)
		<Column("CHANGE_ALL_STATES_IN_TEMPLATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ChangeAllStatesInTemplate() As Nullable(Of Boolean)

        <ForeignKey("AlertAssignmentTemplateID")>
        Public Overridable Property AlertAssignmentTemplate As Database.Entities.AlertAssignmentTemplate
        <ForeignKey("EndAlertAssignmentTemplateID")>
        Public Overridable Property EndAlertAssignmentTemplate As Database.Entities.AlertAssignmentTemplate
        <ForeignKey("AlertStateID")>
        Public Overridable Property AlertState As Database.Entities.AlertState
        <ForeignKey("EndAlertStateID")>
        Public Overridable Property EndAlertState As Database.Entities.AlertState
        Public Overridable Property Workflow As Database.Entities.Workflow

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
