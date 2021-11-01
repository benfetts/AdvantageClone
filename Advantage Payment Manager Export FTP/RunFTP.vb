Module RunFTP

#Region " Constants "



#End Region

#Region " Enums "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Sub Main(args() As String)

        'objects
        Dim Session As AdvantageFramework.Security.Session = Nothing
        Dim FileName As String = String.Empty
        Dim Server As String = String.Empty
        Dim Database As String = String.Empty
        Dim UserCode As String = String.Empty
        Dim BankCode As String = String.Empty
        Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing
        Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
        Dim IsFTPValidationSuccessful As Boolean = False

        If args IsNot Nothing AndAlso args.Count > 0 Then

            Try

                Server = args(0)
                Database = args(1)
                UserCode = args(2)
                BankCode = args(3)
                FileName = args(4)

                ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfileForAdvantage()

                Try

                    ConnectionDatabaseProfile = ConnectionDatabaseProfiles.SingleOrDefault(Function(Entity) Entity.ServerName = Server AndAlso Entity.DatabaseName = Database)

                Catch ex As Exception
                    ConnectionDatabaseProfile = Nothing
                End Try

                If ConnectionDatabaseProfile IsNot Nothing Then

                    Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Methods.Application.Advantage, ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Advantage), UserCode, 0, ConnectionDatabaseProfile.GetConnectionString(AdvantageFramework.Security.Application.Advantage))

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        DbContext.Database.Connection.Open()

                        Bank = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, BankCode)

                        If Bank IsNot Nothing Then

                            If Bank.PaymentManagerFTPSSL Then

                                If Bank.PaymentManagerFTPPrivateKey IsNot Nothing Then

                                    IsFTPValidationSuccessful = AdvantageFramework.FTP.SSHFTPValidation(Bank.PaymentManagerFTPAddress, Bank.PaymentManagerFTPPort, Bank.PaymentManagerFTPUsername, Bank.PaymentManagerFTPPrivateKey, "")

                                Else

                                    IsFTPValidationSuccessful = AdvantageFramework.FTP.FTPValidation(Bank.PaymentManagerFTPSSL, Bank.PaymentManagerFTPAddress, Bank.PaymentManagerFTPPort, Bank.PaymentManagerFTPUsername, Bank.PaymentManagerFTPPassword, Bank.PaymentManagerFTPSSLMode)

                                End If

                            Else

                                IsFTPValidationSuccessful = AdvantageFramework.FTP.FTPValidation(Bank.PaymentManagerFTPSSL, Bank.PaymentManagerFTPAddress, Bank.PaymentManagerFTPPort, Bank.PaymentManagerFTPUsername, Bank.PaymentManagerFTPPassword, Bank.PaymentManagerFTPSSLMode)

                            End If

                            If IsFTPValidationSuccessful Then

                                If Right(Bank.PaymentManagerFTPExportFolder, 1) <> "\" Then
                                    FileName = "\" + FileName
                                End If

                                FileName = Bank.PaymentManagerFTPExportFolder + FileName

                                If Bank.PaymentManagerFTPSSL Then

                                    If Bank.PaymentManagerFTPPrivateKey IsNot Nothing Then

                                        AdvantageFramework.FTP.UploadToSSHFTP(Bank.PaymentManagerFTPAddress, Bank.PaymentManagerFTPPort, Bank.PaymentManagerFTPUsername, Bank.PaymentManagerFTPPrivateKey, "", Bank.PaymentManagerFTPFolder, FileName)

                                    Else

                                        AdvantageFramework.FTP.UploadToFTP(Bank.PaymentManagerFTPSSL, Bank.PaymentManagerFTPAddress, Bank.PaymentManagerFTPPort, Bank.PaymentManagerFTPFolder, Bank.PaymentManagerFTPUsername, Bank.PaymentManagerFTPPassword, Bank.PaymentManagerFTPSSLMode, FileName)

                                    End If

                                Else

                                    AdvantageFramework.FTP.UploadToFTP(Bank.PaymentManagerFTPSSL, Bank.PaymentManagerFTPAddress, Bank.PaymentManagerFTPPort, Bank.PaymentManagerFTPFolder, Bank.PaymentManagerFTPUsername, Bank.PaymentManagerFTPPassword, Bank.PaymentManagerFTPSSLMode, FileName)

                                End If

                            End If

                        End If

                    End Using

                End If

            Catch ex As Exception
                Session = Nothing
            End Try

        End If

    End Sub

#End Region

End Module
