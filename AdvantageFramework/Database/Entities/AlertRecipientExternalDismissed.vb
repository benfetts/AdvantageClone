Namespace Database.Entities

    <Table("ALERT_RCPT_X_REVIEWER_DISMISSED")>
    Public Class AlertRecipientExternalDismissed
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "
        Public Enum Properties

            ID
            AlertID
            ProofingExternalID
            AlertTemplateID
            AlertStateID
            ProofingStatusID
            IsRead

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <Column("ID")>
        Public Property ID As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <Required>
        <Column("ALERT_ID")>
        Public Property AlertID As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <Required>
        <Column("PROOFING_EXTERNAL_REVIEWER_ID")>
        Public Property ProofingExternalID As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <Column("ALRT_NOTIFY_HDR_ID")>
        Public Property AlertTemplateID As Integer?

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <Column("ALERT_STATE_ID")>
        Public Property AlertStateID As Integer?

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <Column("PROOFING_STATUS_ID")>
        Public Property ProofingStatusID As Integer?

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <Column("IS_READ")>
        Public Property IsRead As Boolean?

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
