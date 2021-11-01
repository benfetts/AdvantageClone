Namespace Database.Classes

    <Serializable()>
    Public Class AlertEmailRecipient

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            RecipientAlertID
            RecipientID
            RecipientEmployeeCode
            RecipientEmailAddress
            RecipientEmployeeName
            EmployeeCode
            EmployeeEmail
            MailBeeTitle
            IsAssignee
            IsCC
            IsClientPortal
            IsCurrentRecipient
            SendEmail
            IsTaskEmployee

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property RecipientAlertID As Integer = 0
        Public Property RecipientID As Integer = 0
        Public Property RecipientEmployeeCode As String = String.Empty
        Public Property RecipientEmailAddress As String = String.Empty
        Public Property RecipientEmployeeName As String = String.Empty
        Public Property EmployeeCode As String = String.Empty
        Public Property EmployeeEmail As String = String.Empty
        Public Property MailBeeTitle As String = String.Empty
        Public Property IsAssignee As Boolean = False
        Public Property IsCC As Boolean = False
        Public Property IsClientPortal As Boolean = False
        Public Property IsCurrentRecipient As Boolean = False
        Public Property SendEmail As Boolean = False
        Public Property IsTaskEmployee As Boolean = False

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.RecipientAlertID.ToString

        End Function

#End Region

    End Class

End Namespace
