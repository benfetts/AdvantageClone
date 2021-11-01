Namespace Database.Entities

    <Table("ADVANTAGE_SES")>
    Public Class AdvantageSES

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            SMTPAuthMethod
            SMTPPortNumber
            SMTPSecureType
            SMTPServer
            SMTPSender
            EmailUsername
            EmailPassword
            EmailReplyTo
        End Enum

#End Region

#Region " Variables "


#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("ADVANTAGE_SES_ID")>
        Public Property ID() As Integer
        <Required>
        <Column("SMTP_AUTH_METHOD")>
        Public Property SMTPAuthMethod() As Short
        <Required>
        <Column("SMTP_PORT_NUMBER")>
        Public Property SMTPPortNumber() As Short
        <Required>
        <Column("SMTP_SECURE_TYPE")>
        Public Property SMTPSecureType() As Short
        <Required>
        <Column("SMTP_SERVER", TypeName:="varchar")>
        <MaxLength(100)>
        Public Property SMTPServer() As String
        <Required>
        <Column("SMTP_SENDER", TypeName:="varchar")>
        <MaxLength(100)>
        Public Property SMTPSender() As String
        <Required>
        <Column("EMAIL_USERNAME", TypeName:="varchar")>
        <MaxLength(100)>
        Public Property EmailUsername() As String
        <Required>
        <Column("EMAIL_PWD", TypeName:="varchar(MAX)")>
        Public Property EmailPassword() As String
        <Required>
        <Column("EMAIL_REPLY_TO", TypeName:="varchar")>
        <MaxLength(100)>
        Public Property EmailReplyTo() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
