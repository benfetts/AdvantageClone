Namespace Database.Classes

    <Serializable()>
    Public Class ClientPortalAlertEmailRecipient

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AlertID
            AlertRecipientID
            CDPContactID
            EmailAddress
            ContactFullName
            MailBeeTitle
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AlertID() As Integer

        Public Property AlertRecipientID() As Integer

        Public Property CDPContactID() As Integer

        Public Property EmailAddress() As String

        Public Property ContactFullName() As String

        Public Property MailBeeTitle() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AlertID.ToString

        End Function

#End Region

    End Class

End Namespace
