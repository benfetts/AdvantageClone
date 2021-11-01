Namespace ViewModels.Maintenance.General

    Public Class EmailSettingsViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SMTPAuthenticationMethodType As Short
        Public Property SMTPPortNumber As Short
        Public Property SMTPSecurityType As Short
        <MaxLength(50)>
        Public Property SMTPServer As String
        <MaxLength(100)>
        Public Property SMTPUserName As String
        <MaxLength(100)>
        Public Property EmailUserName As String
        Public Property EmailPassword As String
        <MaxLength(50)>
        Public Property ReplyToEmail As String
        Public Property UseSMTPToSendPDF As Boolean
        Public Property UseEmployeeLogin As Boolean

        Public Property HasAgencyOAuth2Key As Boolean

        Public Property SMTPAuthenticationMethodTypes As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

#End Region

#Region " Methods "

        Public Sub New()

            Me.SMTPAuthenticationMethodType = 0
            Me.SMTPPortNumber = 0
            Me.SMTPSecurityType = 0
            Me.SMTPServer = String.Empty
            Me.SMTPUserName = String.Empty
            Me.EmailUserName = String.Empty
            Me.EmailPassword = String.Empty
            Me.ReplyToEmail = String.Empty
            Me.UseSMTPToSendPDF = False
            Me.UseEmployeeLogin = False

            Me.HasAgencyOAuth2Key = False

            Me.SMTPAuthenticationMethodTypes = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

        End Sub

#End Region

    End Class

End Namespace

