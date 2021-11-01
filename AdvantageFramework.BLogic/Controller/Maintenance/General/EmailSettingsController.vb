Namespace Controller.Maintenance.General

    Public Class EmailSettingsController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.General.EmailSettingsViewModel

            Dim EmailSettingsViewModel As AdvantageFramework.ViewModels.Maintenance.General.EmailSettingsViewModel = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Token As String = String.Empty
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim AuthorizationUri As System.Uri = Nothing

            EmailSettingsViewModel = New AdvantageFramework.ViewModels.Maintenance.General.EmailSettingsViewModel

            EmailSettingsViewModel.SMTPAuthenticationMethodTypes = (From SmtpAuthenticationMethod In [Enum].GetValues(GetType(AdvantageFramework.Email.SmtpAuthenticationMethods))
                                                                    Select New AdvantageFramework.DTO.ComboBoxItem(CType(SmtpAuthenticationMethod, AdvantageFramework.Email.SmtpAuthenticationMethods))).ToList

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency IsNot Nothing Then

                    EmailSettingsViewModel.SMTPAuthenticationMethodType = Agency.SMTPAuthenticationMethodType.GetValueOrDefault(0)

                    If Agency.SMTPPortNumber.HasValue Then

                        EmailSettingsViewModel.SMTPPortNumber = Agency.SMTPPortNumber

                    End If

                    EmailSettingsViewModel.SMTPSecurityType = Agency.SMTPSecurityType

                    EmailSettingsViewModel.SMTPServer = Agency.SMTPServer
                    EmailSettingsViewModel.SMTPUserName = Agency.SMTPUserName
                    EmailSettingsViewModel.EmailUserName = Agency.EmailUserName

                    If String.IsNullOrWhiteSpace(Agency.EmailPassword) = False Then

                        EmailSettingsViewModel.EmailPassword = AdvantageFramework.Security.Encryption.Decrypt(Agency.EmailPassword)

                    Else

                        EmailSettingsViewModel.EmailPassword = Agency.EmailPassword

                    End If

                    EmailSettingsViewModel.ReplyToEmail = Agency.ReplyToEmail
                    EmailSettingsViewModel.UseSMTPToSendPDF = CBool(Agency.UseSMTPToSendPDF.GetValueOrDefault(0))
                    EmailSettingsViewModel.UseEmployeeLogin = CBool(Agency.UseEmployeeLogin.GetValueOrDefault(0))

                End If

            End Using

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.SMTP_OAUTH2_TOKEN.ToString)

                If Setting IsNot Nothing Then

                    Token = Setting.Value

                End If

            End Using

            If String.IsNullOrWhiteSpace(Token) = False Then

                EmailSettingsViewModel.HasAgencyOAuth2Key = True

            End If

            Load = EmailSettingsViewModel

        End Function
        Public Function Save(EmailSettingsViewModel As AdvantageFramework.ViewModels.Maintenance.General.EmailSettingsViewModel,
                             ByRef ErrorMessage As String) As Boolean

            Dim Saved As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    Agency = DbContext.Agencies.FirstOrDefault

                    If Agency IsNot Nothing Then

                        Agency.SMTPAuthenticationMethodType = EmailSettingsViewModel.SMTPAuthenticationMethodType
                        Agency.SMTPPortNumber = EmailSettingsViewModel.SMTPPortNumber

                        Agency.SMTPSecurityType = EmailSettingsViewModel.SMTPSecurityType

                        Agency.SMTPServer = EmailSettingsViewModel.SMTPServer
                        Agency.SMTPUserName = EmailSettingsViewModel.SMTPUserName
                        Agency.EmailUserName = EmailSettingsViewModel.EmailUserName

                        Agency.EmailPassword = EmailSettingsViewModel.EmailPassword

                        If String.IsNullOrWhiteSpace(Agency.EmailPassword) = False Then

                            Agency.EmailPassword = AdvantageFramework.Security.Encryption.Encrypt(Agency.EmailPassword)

                        End If

                        Agency.ReplyToEmail = EmailSettingsViewModel.ReplyToEmail
                        Agency.UseSMTPToSendPDF = If(EmailSettingsViewModel.UseSMTPToSendPDF, 1, 0)
                        Agency.UseEmployeeLogin = If(EmailSettingsViewModel.UseEmployeeLogin, 1, 0)

                    End If

                    DbContext.Configuration.AutoDetectChangesEnabled = True
                    DbContext.SaveChanges()

                    DbTransaction.Commit()

                    Saved = True

                Catch ex As Exception
                    DbTransaction.Rollback()
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    ErrorMessage += System.Environment.NewLine & ex.Message
                    Saved = False
                End Try

            End Using

            Save = Saved

        End Function
        Public Function SaveSMTPAuthenticationMethodType(SMTPAuthenticationMethodType As String) As Boolean

            Dim Saved As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            If String.IsNullOrWhiteSpace(SMTPAuthenticationMethodType) Then

                SMTPAuthenticationMethodType = "6"

            End If

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    Agency = DbContext.Agencies.FirstOrDefault

                    If Agency IsNot Nothing Then

                        Agency.SMTPAuthenticationMethodType = SMTPAuthenticationMethodType

                    End If

                    DbContext.Configuration.AutoDetectChangesEnabled = True
                    DbContext.SaveChanges()

                    DbTransaction.Commit()

                    Saved = True

                Catch ex As Exception
                    DbTransaction.Rollback()
                    Saved = False
                End Try

            End Using

            SaveSMTPAuthenticationMethodType = Saved

        End Function
        Public Function InitializeGoogleService() As AdvantageFramework.GoogleServices.Service

            InitializeGoogleService = AdvantageFramework.GoogleServices.Service.Initialize(AdvantageFramework.GoogleServices.Service.ServiceTypes.Gmail, Me.Session, Nothing, True)

        End Function
        Public Function DisableOAuth2() As Boolean

            Dim Disabled As Boolean = False
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing

            Service = Me.InitializeGoogleService

            If Service IsNot Nothing Then

                Disabled = Service.Deauthorize()

            End If

            DisableOAuth2 = Disabled

        End Function

#End Region

    End Class

End Namespace
