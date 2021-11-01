Namespace Database.Entities

	<Table("ALERT_NOTIFY_EMPS")>
	Public Class AlertAssignmentTemplateEmployee
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			AlertStateID
			AlertAssignmentTemplateID
			EmployeeCode
			AlertAssignmentTemplate
			AlertState

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("ALERT_STATE_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertStateID() As Integer
		<Key>
		<Required>
        <Column("ALRT_NOTIFY_HDR_ID", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertAssignmentTemplateID() As Integer
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("EMP_CODE", Order:=2, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeCode() As String

        Public Overridable Property AlertAssignmentTemplate As Database.Entities.AlertAssignmentTemplate
        Public Overridable Property AlertState As Database.Entities.AlertState

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AlertStateID.ToString

        End Function

#End Region

	End Class

End Namespace
