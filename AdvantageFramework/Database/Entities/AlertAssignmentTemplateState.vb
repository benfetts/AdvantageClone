Namespace Database.Entities

	<Table("ALERT_NOTIFY_STATES")>
	Public Class AlertAssignmentTemplateState
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			AlertAssignmentTemplateID
			AlertStateID
			SortOrder
			DefaultEmployeeCode
			IsDefault
			IsCompleted
			EmployeeLookupType
			DefaultRoleCode
			DefaultDepartmentTeamCode
			DefaultAlertGroupCode
			AlertAssignmentTemplate
			AlertState

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("ALRT_NOTIFY_HDR_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertAssignmentTemplateID() As Integer
		<Key>
		<Required>
        <Column("ALERT_STATE_ID", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertStateID() As Integer
		<Column("SORT_ORDER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SortOrder() As Nullable(Of Integer)
		<MaxLength(6)>
		<Column("DFLT_EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DefaultEmployeeCode() As String
		<Column("IS_DFLT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsDefault() As Nullable(Of Boolean)
		<Column("IS_COMPLETED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsCompleted() As Nullable(Of Boolean)
		<Column("EMP_LOOKUP_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeLookupType() As Nullable(Of Byte)
        <MaxLength(6)>
		<Column("DFLT_ROLE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DefaultRoleCode() As String
		<MaxLength(4)>
		<Column("DFLT_DEPT_TEAM_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DefaultDepartmentTeamCode() As String
		<MaxLength(50)>
		<Column("DFLT_ALERT_GROUP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DefaultAlertGroupCode() As String

        Public Overridable Property AlertAssignmentTemplate As Database.Entities.AlertAssignmentTemplate
        Public Overridable Property AlertState As Database.Entities.AlertState

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AlertAssignmentTemplateID.ToString

        End Function

#End Region

	End Class

End Namespace
