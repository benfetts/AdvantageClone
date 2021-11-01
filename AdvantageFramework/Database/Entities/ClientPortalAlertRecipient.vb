Namespace Database.Entities

	<Table("CP_ALERT_RCPT")>
	Public Class ClientPortalAlertRecipient
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            AlertID
            AlertRecipientID
            ClientContactID
            EmailAddress
            ProcessedDate
            IsNewAlert
            HasBeenRead
            IsConceptShareReviewer
            IsDeleted
            IsCurrentRecipient
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
		Public Property AlertRecipientID() As Integer
		<Required>
		<Column("CDP_CONTACT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientContactID() As Integer
		<MaxLength(50)>
		<Column("EMAIL_ADDRESS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmailAddress() As String
		<Column("PROCESSED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProcessedDate() As Nullable(Of Date)
		<Column("NEW_ALERT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsNewAlert() As Nullable(Of Short)
		<Column("READ_ALERT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property HasBeenRead() As Nullable(Of Short)
        <Column("CS_IS_REVIEWER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsConceptShareReviewer() As Nullable(Of Boolean)
        <Column("IS_DELETED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsDeleted() As Nullable(Of Boolean)
        <Column("CURRENT_RCPT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsCurrentRecipient() As Nullable(Of Short)


        Public Overridable Property Alert As Database.Entities.Alert

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AlertID

        End Function

#End Region

	End Class

End Namespace
