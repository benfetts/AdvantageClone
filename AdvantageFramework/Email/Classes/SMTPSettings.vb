Namespace Email.Classes

    Public Class SMTPSettings

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        Public Property SMTPAuthMethod() As Short
        <Required>
        Public Property SMTPPortNumber() As Short
        <Required>
        Public Property SMTPSecureType() As Short
        <Required>
        <MaxLength(100)>
        Public Property SMTPServer() As String
        <Required>
        <MaxLength(100)>
        Public Property SMTPSender() As String
        <Required>
        <MaxLength(100)>
        Public Property EmailUsername() As String
        <Required>
        Public Property EmailPassword() As String
        <Required>
        <MaxLength(100)>
        Public Property EmailReplyTo() As String
        Public Property UseEmployeeLogin As Boolean
        Public Property POP3DefaultReplyToEmail() As String

#End Region

#Region " Methods "

        Public Sub New(DbContext As AdvantageFramework.Database.DbContext, UseAdvantageSESIfHosted As Boolean)

            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim AdvantageSES As AdvantageFramework.Database.Entities.AdvantageSES = Nothing

            Try

                AdvantageSES = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.AdvantageSES)
                                Select Entity).FirstOrDefault

            Catch ex As Exception
                AdvantageSES = Nothing
            End Try

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            Load(Agency, AdvantageSES, UseAdvantageSESIfHosted)

        End Sub
        Public Sub New(DbContext As AdvantageFramework.Database.DbContext, Agency As AdvantageFramework.Database.Entities.Agency, UseAdvantageSESIfHosted As Boolean)

            Dim AdvantageSES As AdvantageFramework.Database.Entities.AdvantageSES = Nothing

            Try

                AdvantageSES = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.AdvantageSES)
                                Select Entity).FirstOrDefault

            Catch ex As Exception
                AdvantageSES = Nothing
            End Try

            Load(Agency, AdvantageSES, UseAdvantageSESIfHosted)

        End Sub
        Public Sub New(DbContext As AdvantageFramework.Database.DbContext, AdvantageSES As AdvantageFramework.Database.Entities.AdvantageSES, UseAdvantageSESIfHosted As Boolean)

            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            Load(Agency, AdvantageSES, UseAdvantageSESIfHosted)

        End Sub
        Public Sub New(Agency As AdvantageFramework.Database.Entities.Agency, AdvantageSES As AdvantageFramework.Database.Entities.AdvantageSES, UseAdvantageSESIfHosted As Boolean)

            Load(Agency, AdvantageSES, UseAdvantageSESIfHosted)

        End Sub
        Private Sub Load(Agency As AdvantageFramework.Database.Entities.Agency, AdvantageSES As AdvantageFramework.Database.Entities.AdvantageSES, UseAdvantageSESIfHosted As Boolean)

            If UseAdvantageSESIfHosted AndAlso Agency IsNot Nothing AndAlso Agency.IsASP.GetValueOrDefault(0) = 1 Then

                If AdvantageSES IsNot Nothing Then

                    Me.SMTPAuthMethod = AdvantageSES.SMTPAuthMethod
                    Me.SMTPPortNumber = AdvantageSES.SMTPPortNumber
                    Me.SMTPSecureType = AdvantageSES.SMTPSecureType

                    Me.SMTPServer = AdvantageSES.SMTPServer
                    Me.SMTPSender = AdvantageSES.SMTPSender
                    Me.EmailUsername = AdvantageSES.EmailUsername
                    Me.EmailPassword = AdvantageSES.EmailPassword
                    Me.EmailReplyTo = AdvantageSES.EmailReplyTo
                    Me.UseEmployeeLogin = False
                    Me.POP3DefaultReplyToEmail = String.Empty

                Else

                    Me.SMTPAuthMethod = Agency.SMTPAuthenticationMethodType.GetValueOrDefault(0)
                    Me.SMTPPortNumber = Agency.SMTPPortNumber.GetValueOrDefault(0)
                    Me.SMTPSecureType = Agency.SMTPSecurityType.GetValueOrDefault(0)

                    Me.SMTPServer = Agency.SMTPServer
                    Me.SMTPSender = Agency.SMTPUserName
                    Me.EmailUsername = Agency.EmailUserName
                    Me.EmailPassword = Agency.EmailPassword
                    Me.EmailReplyTo = Agency.ReplyToEmail
                    Me.UseEmployeeLogin = (Agency.UseEmployeeLogin.GetValueOrDefault(0) = 1)

                    If (Not Agency.POP3Server Is Nothing AndAlso Agency.POP3Server <> "") AndAlso
                            (Not Agency.POP3UserName Is Nothing AndAlso Agency.POP3UserName <> "") AndAlso
                            (Not Agency.POP3Password Is Nothing AndAlso Agency.POP3Password <> "") AndAlso
                            (Not Agency.POP3DefaultReplyToEmail Is Nothing AndAlso Agency.POP3DefaultReplyToEmail <> "") Then

                        Me.POP3DefaultReplyToEmail = Agency.POP3DefaultReplyToEmail

                    End If

                End If

            Else

                If Agency IsNot Nothing Then

                    Me.SMTPAuthMethod = Agency.SMTPAuthenticationMethodType.GetValueOrDefault(0)
                    Me.SMTPPortNumber = Agency.SMTPPortNumber.GetValueOrDefault(0)
                    Me.SMTPSecureType = Agency.SMTPSecurityType.GetValueOrDefault(0)

                    Me.SMTPServer = Agency.SMTPServer
                    Me.SMTPSender = Agency.SMTPUserName
                    Me.EmailUsername = Agency.EmailUserName
                    Me.EmailPassword = Agency.EmailPassword
                    Me.EmailReplyTo = Agency.ReplyToEmail
                    Me.UseEmployeeLogin = (Agency.UseEmployeeLogin.GetValueOrDefault(0) = 1)

                    If (Not Agency.POP3Server Is Nothing AndAlso Agency.POP3Server <> "") AndAlso
                            (Not Agency.POP3UserName Is Nothing AndAlso Agency.POP3UserName <> "") AndAlso
                            (Not Agency.POP3Password Is Nothing AndAlso Agency.POP3Password <> "") AndAlso
                            (Not Agency.POP3DefaultReplyToEmail Is Nothing AndAlso Agency.POP3DefaultReplyToEmail <> "") Then

                        Me.POP3DefaultReplyToEmail = Agency.POP3DefaultReplyToEmail

                    End If

                End If

                'If Agency IsNot Nothing AndAlso AdvantageSES IsNot Nothing Then

                '        If String.IsNullOrWhiteSpace(Agency.SMTPServer) = False AndAlso String.IsNullOrWhiteSpace(Agency.EmailUserName) = False AndAlso
                '            String.IsNullOrWhiteSpace(Agency.EmailPassword) = False Then

                '            Me.SMTPAuthMethod = Agency.SMTPAuthenticationMethodType.GetValueOrDefault(0)
                '            Me.SMTPPortNumber = Agency.SMTPPortNumber.GetValueOrDefault(0)
                '            Me.SMTPSecureType = Agency.SMTPSecurityType.GetValueOrDefault(0)

                '            Me.SMTPServer = Agency.SMTPServer
                '            Me.SMTPSender = Agency.SMTPUserName
                '            Me.EmailUsername = Agency.EmailUserName
                '            Me.EmailPassword = Agency.EmailPassword
                '            Me.EmailReplyTo = Agency.ReplyToEmail
                '            Me.UseEmployeeLogin = (Agency.UseEmployeeLogin.GetValueOrDefault(0) = 1)

                '            If (Not Agency.POP3Server Is Nothing AndAlso Agency.POP3Server <> "") AndAlso
                '                   (Not Agency.POP3UserName Is Nothing AndAlso Agency.POP3UserName <> "") AndAlso
                '                   (Not Agency.POP3Password Is Nothing AndAlso Agency.POP3Password <> "") AndAlso
                '                   (Not Agency.POP3DefaultReplyToEmail Is Nothing AndAlso Agency.POP3DefaultReplyToEmail <> "") Then

                '                Me.POP3DefaultReplyToEmail = Agency.POP3DefaultReplyToEmail

                '            End If

                '        ElseIf String.IsNullOrWhiteSpace(AdvantageSES.SMTPServer) = False AndAlso String.IsNullOrWhiteSpace(AdvantageSES.EmailUsername) = False AndAlso
                '            String.IsNullOrWhiteSpace(AdvantageSES.EmailPassword) = False Then

                '            Me.SMTPAuthMethod = AdvantageSES.SMTPAuthMethod
                '            Me.SMTPPortNumber = AdvantageSES.SMTPPortNumber
                '            Me.SMTPSecureType = AdvantageSES.SMTPSecureType

                '            Me.SMTPServer = AdvantageSES.SMTPServer
                '            Me.SMTPSender = AdvantageSES.SMTPSender
                '            Me.EmailUsername = AdvantageSES.EmailUsername
                '            Me.EmailPassword = AdvantageSES.EmailPassword
                '            Me.EmailReplyTo = AdvantageSES.EmailReplyTo
                '            Me.UseEmployeeLogin = False
                '            Me.POP3DefaultReplyToEmail = String.Empty

                '        End If

                '    ElseIf Agency IsNot Nothing AndAlso AdvantageSES Is Nothing Then

                '        Me.SMTPAuthMethod = Agency.SMTPAuthenticationMethodType.GetValueOrDefault(0)
                '        Me.SMTPPortNumber = Agency.SMTPPortNumber.GetValueOrDefault(0)
                '        Me.SMTPSecureType = Agency.SMTPSecurityType.GetValueOrDefault(0)

                '        Me.SMTPServer = Agency.SMTPServer
                '        Me.SMTPSender = Agency.SMTPUserName
                '        Me.EmailUsername = Agency.EmailUserName
                '        Me.EmailPassword = Agency.EmailPassword
                '        Me.EmailReplyTo = Agency.ReplyToEmail
                '        Me.UseEmployeeLogin = (Agency.UseEmployeeLogin.GetValueOrDefault(0) = 1)

                '        If (Not Agency.POP3Server Is Nothing AndAlso Agency.POP3Server <> "") AndAlso
                '                (Not Agency.POP3UserName Is Nothing AndAlso Agency.POP3UserName <> "") AndAlso
                '                (Not Agency.POP3Password Is Nothing AndAlso Agency.POP3Password <> "") AndAlso
                '                (Not Agency.POP3DefaultReplyToEmail Is Nothing AndAlso Agency.POP3DefaultReplyToEmail <> "") Then

                '            Me.POP3DefaultReplyToEmail = Agency.POP3DefaultReplyToEmail

                '        End If

                '    ElseIf Agency Is Nothing AndAlso AdvantageSES IsNot Nothing Then

                '        Me.SMTPAuthMethod = AdvantageSES.SMTPAuthMethod
                '        Me.SMTPPortNumber = AdvantageSES.SMTPPortNumber
                '        Me.SMTPSecureType = AdvantageSES.SMTPSecureType

                '        Me.SMTPServer = AdvantageSES.SMTPServer
                '        Me.SMTPSender = AdvantageSES.SMTPSender
                '        Me.EmailUsername = AdvantageSES.EmailUsername
                '        Me.EmailPassword = AdvantageSES.EmailPassword
                '        Me.EmailReplyTo = AdvantageSES.EmailReplyTo
                '        Me.UseEmployeeLogin = False
                '        Me.POP3DefaultReplyToEmail = String.Empty

                '    Else

                '        Me.SMTPAuthMethod = 0
                '        Me.SMTPPortNumber = 0
                '        Me.SMTPSecureType = 0

                '        Me.SMTPServer = String.Empty
                '        Me.SMTPSender = String.Empty
                '        Me.EmailUsername = String.Empty
                '        Me.EmailPassword = String.Empty
                '        Me.EmailReplyTo = String.Empty
                '        Me.UseEmployeeLogin = False
                '        Me.POP3DefaultReplyToEmail = String.Empty

                '    End If

            End If

        End Sub

#End Region

    End Class

End Namespace
