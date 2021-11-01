Namespace Billing.Reports.Presentation.Classes

    Public Class EmailStatusReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property EmailSent As Boolean = False
        Public Property SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToSend
        Public Property EmailAddress As String = ""
        Public Property ErrorMessage As String = ""

#End Region

#Region " Methods "

        Public Sub New(EmailSent As Boolean, SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus, EmailAddress As String, ErrorMessage As String)

            Me.EmailSent = EmailSent
            Me.SendingEmailStatus = SendingEmailStatus
            Me.EmailAddress = EmailAddress
            Me.ErrorMessage = ErrorMessage

        End Sub

#End Region

    End Class

End Namespace
