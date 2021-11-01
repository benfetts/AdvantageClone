<Microsoft.VisualBasic.ComClass(FTP.ClassId, FTP.InterfaceId, FTP.EventsId)>
Public Class FTP
    Implements AdvantageFramework.Com.Interfaces.IFTP

#Region " Constants "

    Public Const ClassId As String = "3A423BF5-C2B7-4B48-81B0-4E29D26F65D2"
    Public Const InterfaceId As String = "D4639A86-F93C-4249-B0AB-444B3C00226D"
    Public Const EventsId As String = "4E751C11-BB8B-4582-AE89-750FA29FE747"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Function PaymentManagerExport(Server As String, Database As String, UserCode As String, BankCode As String, FileName As String, ByRef ErrorMessage As String) As Boolean Implements AdvantageFramework.Com.Interfaces.IFTP.PaymentManagerExport

        'objects
        Dim Exported As Boolean = False
        Dim Session As AdvantageFramework.Security.Session = Nothing
        Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing
        Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
        Dim IsFTPValidationSuccessful As Boolean = False

        If String.IsNullOrWhiteSpace(Server) = False AndAlso String.IsNullOrWhiteSpace(Database) = False AndAlso String.IsNullOrWhiteSpace(UserCode) = False AndAlso
                String.IsNullOrWhiteSpace(BankCode) = False AndAlso String.IsNullOrWhiteSpace(FileName) = False Then

            Try

                ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfileForAdvantage()

                Try

                    ConnectionDatabaseProfile = ConnectionDatabaseProfiles.SingleOrDefault(Function(Entity) Entity.ServerName = Server AndAlso Entity.DatabaseName = Database)

                Catch ex As Exception
                    ConnectionDatabaseProfile = Nothing
                End Try

                If ConnectionDatabaseProfile IsNot Nothing Then

                    Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Methods.Application.Advantage,
                                                                      ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Advantage),
                                                                      UserCode, 0, ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Advantage))

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        DbContext.Database.Connection.Open()

                        Bank = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, BankCode)

                        If Bank IsNot Nothing Then

                            If Bank.PaymentManagerFTPSSL Then

                                If Bank.PaymentManagerFTPPrivateKey IsNot Nothing Then

                                    IsFTPValidationSuccessful = AdvantageFramework.FTP.SSHFTPValidation(Bank.PaymentManagerFTPAddress, Bank.PaymentManagerFTPPort, Bank.PaymentManagerFTPUsername,
                                                                                                        Bank.PaymentManagerFTPPrivateKey, "", ErrorMessage)

                                Else

                                    IsFTPValidationSuccessful = AdvantageFramework.FTP.FTPValidation(Bank.PaymentManagerFTPSSL, Bank.PaymentManagerFTPAddress, Bank.PaymentManagerFTPPort,
                                                                                                     Bank.PaymentManagerFTPUsername, Bank.PaymentManagerFTPPassword, Bank.PaymentManagerFTPSSLMode, ErrorMessage)

                                End If

                            Else

                                IsFTPValidationSuccessful = AdvantageFramework.FTP.FTPValidation(Bank.PaymentManagerFTPSSL, Bank.PaymentManagerFTPAddress, Bank.PaymentManagerFTPPort,
                                                                                                 Bank.PaymentManagerFTPUsername, Bank.PaymentManagerFTPPassword, Bank.PaymentManagerFTPSSLMode, ErrorMessage)

                            End If

                            If IsFTPValidationSuccessful Then

                                FileName = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Bank.PaymentManagerFTPExportFolder, "\") & FileName

                                If Bank.PaymentManagerFTPSSL Then

                                    If Bank.PaymentManagerFTPPrivateKey IsNot Nothing Then

                                        Exported = AdvantageFramework.FTP.UploadToSSHFTP(Bank.PaymentManagerFTPAddress, Bank.PaymentManagerFTPPort, Bank.PaymentManagerFTPUsername,
                                                                                         Bank.PaymentManagerFTPPrivateKey, "", Bank.PaymentManagerFTPFolder, FileName, ErrorMessage)

                                    Else

                                        Exported = AdvantageFramework.FTP.UploadToFTP(Bank.PaymentManagerFTPSSL, Bank.PaymentManagerFTPAddress, Bank.PaymentManagerFTPPort, Bank.PaymentManagerFTPFolder,
                                                                                      Bank.PaymentManagerFTPUsername, Bank.PaymentManagerFTPPassword, Bank.PaymentManagerFTPSSLMode, FileName, ErrorMessage)

                                    End If

                                Else

                                    Exported = AdvantageFramework.FTP.UploadToFTP(Bank.PaymentManagerFTPSSL, Bank.PaymentManagerFTPAddress, Bank.PaymentManagerFTPPort, Bank.PaymentManagerFTPFolder,
                                                                                  Bank.PaymentManagerFTPUsername, Bank.PaymentManagerFTPPassword, Bank.PaymentManagerFTPSSLMode, FileName, ErrorMessage)

                                End If

                            End If

                        End If

                    End Using

                End If

            Catch ex As Exception

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                End If

                Session = Nothing
            End Try

        Else

            ErrorMessage = "None of the parameters can be null."

        End If

        PaymentManagerExport = Exported

    End Function

#End Region

End Class
