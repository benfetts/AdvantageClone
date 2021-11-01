Namespace Database.Entities

	<Table("CONTRACT_REPORT")>
	Public Class ContractReport
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			ContractID
			Description
			CycleCode
			LastCompletedDate
			NextStartDate
			NotifyInternalContacts
			EmployeeCode
			AlertDaysPrior
			SendAlertDaysPrior
			SendAlertUponCompletion
			UpcomingAlertSentDate
			LastCompletedAlertSentDate
			Contract
			Cycle

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("CONTRACT_REPORT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<Column("CONTRACT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ContractID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<MaxLength(6)>
		<Column("CYCODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Frequency")>
		Public Property CycleCode() As String
		<Column("LAST_COMPLETED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastCompletedDate() As Nullable(Of Date)
		<Column("NEXT_START_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NextStartDate() As Nullable(Of Date)
		<Required>
		<Column("NOTIFY_INTERNAL_CONTACTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property NotifyInternalContacts() As Boolean
		<MaxLength(6)>
		<Column("EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.EmployeeCode)>
		Public Property EmployeeCode() As String
		<Column("ALERT_DAYS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=999, UseMinValue:=True, MinValue:=0)>
        Public Property AlertDaysPrior() As Nullable(Of Short)
		<Required>
		<Column("SEND_ALERT_DAYS_PRIOR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property SendAlertDaysPrior() As Boolean
		<Required>
		<Column("SEND_ALERT_UPON_COMPLETION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property SendAlertUponCompletion() As Boolean
		<Column("UPCOMING_ALERT_SENT_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UpcomingAlertSentDate() As Nullable(Of Date)
		<Column("LAST_COMPLETED_ALERT_SENT_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastCompletedAlertSentDate() As Nullable(Of Date)

        Public Overridable Property Contract As Database.Entities.Contract
        Public Overridable Property Cycle As Database.Entities.Cycle

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
