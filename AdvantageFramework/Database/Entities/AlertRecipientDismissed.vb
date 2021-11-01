Namespace Database.Entities

	<Table("ALERT_RCPT_DISMISSED")>
	Public Class AlertRecipientDismissed
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            AlertID
            ID
            EmployeeCode
            EmployeeEmail
            ProcessedDate
            IsNewAlert
            HasBeenRead
            IsCurrentRecipient
            IsCurrentNotify
            CardSequenceNumber
            IsConceptShareReviewer
            IsDeleted
            AlertTemplateID
            AlertStateID
            PercentComplete
            CompletedDate
            TempCompleteDate
            HoursAllowed
            LastAssigned

            Alert

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
		<Required>
        <Column("ALERT_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertID() As Integer
		<Key>
		<Required>
        <Column("ALERT_RCPT_ID", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<MaxLength(6)>
		<Column("EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeCode() As String
		<MaxLength(50)>
		<Column("EMAIL_ADDRESS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeEmail() As String
		<Column("PROCESSED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProcessedDate() As Nullable(Of Date)
		<Column("NEW_ALERT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsNewAlert() As Nullable(Of Short)
		<Column("READ_ALERT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property HasBeenRead() As Nullable(Of Short)
		<Column("CURRENT_RCPT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsCurrentRecipient() As Nullable(Of Short)
		<Column("CURRENT_NOTIFY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsCurrentNotify() As Nullable(Of Integer)
        <Column("CARD_SEQ_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CardSequenceNumber() As Nullable(Of Integer)
        <Column("CS_IS_REVIEWER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsConceptShareReviewer() As Nullable(Of Boolean)
        <Column("IS_DELETED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsDeleted() As Nullable(Of Boolean)
        <Column("ALRT_NOTIFY_HDR_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertTemplateID() As Nullable(Of Integer)
        <Column("ALERT_STATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertStateID() As Nullable(Of Integer)
        <Column("PERC_COMPLETE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PercentComplete() As Nullable(Of Short)
        <Column("COMPLETED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CompletedDate() As Nullable(Of Date)
        <Column("TEMP_COMP_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TempCompleteDate() As Nullable(Of Date)
        <Column("HOURS_ALLOWED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property HoursAllowed() As Nullable(Of Decimal)
        <Column("LAST_ASSIGNED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastAssigned() As Nullable(Of Boolean)

        Public Overridable Property Alert As Database.Entities.Alert

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AlertID

        End Function

#End Region

	End Class

End Namespace
