Namespace FTP

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enums "

        Public Enum FTPSSLMode As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "None")>
            None = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Implicit")>
            Implicit = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Explicit")>
            Explicit = 2
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function ValidateSFTP(ByVal FTPHost As String, ByVal FTPPort As Integer,
                                     ByVal UserName As String, ByVal Password As String) As Boolean

            'objects
            Dim SFTP As Rebex.Net.Sftp = Nothing
            Dim Validated As Boolean = False

            Try

                SFTP = New Rebex.Net.Sftp

                SFTP.Timeout = 30000

                SFTP.Connect(FTPHost, FTPPort)

                If SFTP.IsConnected Then

                    SFTP.Login(UserName, Password)

                End If

            Catch ex As Exception

                If SFTP IsNot Nothing Then

                    SFTP.Dispose()

                End If

                SFTP = Nothing

            End Try

            If SFTP IsNot Nothing AndAlso SFTP.IsAuthenticated Then

                Validated = True

            End If

            ValidateSFTP = Validated

        End Function
        Public Function DownloadFilesFromFTPSExplicit(ByVal FTPHost As String, ByVal FTPPort As Integer,
                                                      ByVal UserName As String, ByVal Password As String,
                                                      ByVal FTPPath As String, ByVal LocalPath As String,
                                                      ByRef DownloadedFiles As Generic.List(Of String)) As Boolean

            'objects
            Dim Downloaded As Boolean = False

            Downloaded = DownloadFilesFromFTP(FTPHost, FTPPort, Rebex.Net.SslMode.Explicit, UserName, Password, FTPPath, LocalPath, DownloadedFiles)

            DownloadFilesFromFTPSExplicit = Downloaded

        End Function
        Public Function DownloadFilesFromFTPSImplicit(ByVal FTPHost As String, ByVal FTPPort As Integer,
                                                      ByVal UserName As String, ByVal Password As String,
                                                      ByVal FTPPath As String, ByVal LocalPath As String,
                                                      ByRef DownloadedFiles As Generic.List(Of String)) As Boolean

            'objects
            Dim Downloaded As Boolean = False

            Downloaded = DownloadFilesFromFTP(FTPHost, FTPPort, Rebex.Net.SslMode.Implicit, UserName, Password, FTPPath, LocalPath, DownloadedFiles)

            DownloadFilesFromFTPSImplicit = Downloaded

        End Function
        Private Sub ValidatingCertificate(sender As Object, e As Rebex.Net.SslCertificateValidationEventArgs)

            e.Accept()

        End Sub
        Public Function DownloadFilesFromFTP(ByVal FTPHost As String, ByVal FTPPort As Integer,
                                             ByVal SSLMode As Rebex.Net.SslMode,
                                             ByVal UserName As String, ByVal Password As String,
                                             ByVal FTPPath As String, ByVal LocalPath As String,
                                             ByRef DownloadedFiles As Generic.List(Of String),
                                             Optional ByVal ActionOnExistingFiles As Rebex.IO.ActionOnExistingFiles = Rebex.IO.ActionOnExistingFiles.OverwriteAll,
                                             Optional ByVal ExcludeFiles As Generic.List(Of String) = Nothing) As Boolean

            'objects
            Dim Downloaded As Boolean = False
            Dim FTP As Rebex.Net.Ftp = Nothing
            Dim FtpItemCollection As Rebex.Net.FtpItemCollection = Nothing

            Try

                FTP = New Rebex.Net.Ftp

                FTP.Timeout = 30000

                If SSLMode <> Rebex.Net.SslMode.None Then

                    AddHandler FTP.ValidatingCertificate, AddressOf ValidatingCertificate

                End If

                FTP.Connect(FTPHost, FTPPort, SSLMode)

                If FTP.IsConnected Then

                    FTP.Login(UserName, Password)

                End If

            Catch ex As Exception

                If FTP IsNot Nothing Then

                    FTP.Dispose()

                End If

                FTP = Nothing

            End Try

            If FTP IsNot Nothing AndAlso FTP.IsAuthenticated Then

                If DownloadedFiles Is Nothing Then

                    DownloadedFiles = New Generic.List(Of String)

                End If

                LocalPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(LocalPath, "\")

                Try

                    Downloaded = True

                    If String.IsNullOrWhiteSpace(FTPPath) OrElse FTPPath = "/" Then

                        FtpItemCollection = FTP.GetList()

                    Else

                        FTP.ChangeDirectory(FTPPath)

                        FtpItemCollection = FTP.GetList(FTPPath)

                    End If

                    For Each RebexItem In FtpItemCollection

                        If RebexItem.IsFile Then

                            If ExcludeFiles Is Nothing OrElse (ExcludeFiles IsNot Nothing AndAlso ExcludeFiles.Contains(LocalPath & RebexItem.Path) = False) Then

                                Try

                                    FTP.Download(System.IO.Path.Combine(FTPPath, RebexItem.Path), LocalPath, Rebex.IO.TraversalMode.NonRecursive, Rebex.IO.TransferMethod.Copy, ActionOnExistingFiles)

                                    DownloadedFiles.Add(LocalPath & RebexItem.Name)

                                Catch ex As Exception
                                    Downloaded = False
                                End Try

                            End If

                        End If

                    Next

                Catch ex As Exception
                    Downloaded = False
                End Try

            End If

            DownloadFilesFromFTP = Downloaded

        End Function
        Public Function DownloadFilesFromSFTP(ByVal FTPHost As String, ByVal FTPPort As Integer,
                                              ByVal UserName As String, ByVal Password As String,
                                              ByVal FTPPath As String, ByVal LocalPath As String,
                                              ByRef DownloadedFiles As Generic.List(Of String),
                                              ByRef SftpExceptionStatus As Rebex.Net.SftpExceptionStatus,
                                              ByRef SFtpExceptionMessage As String,
                                              Optional ByVal ExcludeFiles As Generic.List(Of String) = Nothing) As Boolean

            'objects
            Dim Downloaded As Boolean = False
            Dim SFTP As Rebex.Net.Sftp = Nothing
            Dim SftpItemCollection As Rebex.Net.SftpItemCollection = Nothing

            Try

                SFTP = New Rebex.Net.Sftp

                SFTP.Timeout = 30000

                SFTP.Connect(FTPHost, FTPPort)

                If SFTP.IsConnected Then

                    SFTP.Login(UserName, Password)

                End If

            Catch ex As Exception

                If TypeOf ex Is Rebex.Net.SftpException Then

                    SftpExceptionStatus = CType(ex, Rebex.Net.SftpException).Status
                    SFtpExceptionMessage = CType(ex, Rebex.Net.SftpException).Message

                Else

                    If SFTP IsNot Nothing Then

                        SFTP.Dispose()

                    End If

                    SFTP = Nothing

                End If

            End Try

            If SFTP IsNot Nothing AndAlso SFTP.IsAuthenticated Then

                If DownloadedFiles Is Nothing Then

                    DownloadedFiles = New Generic.List(Of String)

                End If

                LocalPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(LocalPath, "\")

                Try

                    Downloaded = True

                    If String.IsNullOrWhiteSpace(FTPPath) OrElse FTPPath = "/" Then

                        SftpItemCollection = SFTP.GetList()

                    Else

                        SftpItemCollection = SFTP.GetList(FTPPath)

                    End If

                    For Each RebexItem In SftpItemCollection

                        If RebexItem.IsFile Then

                            Try

                                If System.IO.File.Exists(System.IO.Path.Combine(LocalPath, RebexItem.Name)) = False Then

                                    SFTP.Download(RebexItem.Path, LocalPath)

                                    If DownloadedFiles.Contains(LocalPath & RebexItem.Name) = False Then

                                        DownloadedFiles.Add(LocalPath & RebexItem.Name)

                                    End If

                                ElseIf ExcludeFiles IsNot Nothing AndAlso ExcludeFiles.Contains(LocalPath & RebexItem.Name) = False Then

                                    If DownloadedFiles.Contains(LocalPath & RebexItem.Name) = False Then

                                        DownloadedFiles.Add(LocalPath & RebexItem.Name)

                                    End If

                                End If

                            Catch ex As Exception
                                Downloaded = False
                            End Try

                        End If

                    Next

                Catch ex As Exception
                    Downloaded = False
                End Try

            End If

            DownloadFilesFromSFTP = Downloaded

        End Function
        Private Function FTPValidation(FTPHost As String, FTPPort As Integer,
                                      UserName As String, Password As String,
                                      SSLModeForFTP As Rebex.Net.SslMode, ErrorMessage As String) As Boolean

            'objects
            Dim FTP As Rebex.Net.Ftp = Nothing
            Dim Validated As Boolean = False

            Try

                FTP = New Rebex.Net.Ftp

                FTP.Timeout = 30000

                If SSLModeForFTP <> Rebex.Net.SslMode.None Then

                    AddHandler FTP.ValidatingCertificate, AddressOf ValidatingCertificate

                End If

                FTP.Connect(FTPHost, FTPPort)

                If FTP.IsConnected Then

                    FTP.Login(UserName, Password)

                Else

                    ErrorMessage = "Connection to FTP failed."

                End If

            Catch ex As Exception

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                End If

                If FTP IsNot Nothing Then

                    FTP.Dispose()

                End If

                FTP = Nothing

            End Try

            If FTP IsNot Nothing AndAlso FTP.IsAuthenticated Then

                Validated = True

            End If

            FTPValidation = Validated

        End Function
        Public Function FTPValidation(UseSSLForFTP As Boolean, FTPAddress As String, FTPPort As Integer, FTPUserName As String, FTPPassword As String, SSLModeForFTP As Rebex.Net.SslMode, Optional ErrorMessage As String = "") As Boolean

            'objects
            Dim Validated As Boolean = False

            If UseSSLForFTP Then

                Validated = SFTPValidation(FTPAddress, FTPPort, FTPUserName, FTPPassword, ErrorMessage)

            Else

                Validated = FTPValidation(FTPAddress, FTPPort, FTPUserName, FTPPassword, SSLModeForFTP, ErrorMessage)

            End If

            FTPValidation = Validated

        End Function
        Public Function SSHFTPValidation(Host As String, Port As Integer, UserName As String, PrivateKey As String, PrivateKeyPassphrase As String, Optional ErrorMessage As String = "") As Boolean

            'objects
            Dim SFTP As Rebex.Net.Sftp = Nothing
            Dim SshPrivateKey As Rebex.Net.SshPrivateKey = Nothing
            Dim Validated As Boolean = False

            Try

                SFTP = New Rebex.Net.Sftp

                SFTP.Timeout = 30000

                SFTP.Connect(Host, Port)

                If SFTP.IsConnected Then

                    If String.IsNullOrWhiteSpace(PrivateKeyPassphrase) = False Then

                        SshPrivateKey = New Rebex.Net.SshPrivateKey(PrivateKey, PrivateKeyPassphrase)

                    Else

                        SshPrivateKey = New Rebex.Net.SshPrivateKey(PrivateKey)

                    End If

                    SFTP.Login(UserName, SshPrivateKey)

                Else

                    ErrorMessage = "Connection to FTP failed."

                End If

            Catch ex As Exception

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                End If

                If SFTP IsNot Nothing Then

                    SFTP.Dispose()

                End If

                SFTP = Nothing

            End Try

            If SFTP IsNot Nothing AndAlso SFTP.IsAuthenticated Then

                Validated = True

            End If

            SSHFTPValidation = Validated

        End Function
        Public Function SSHFTPValidation(Host As String, Port As Integer, UserName As String, PrivateKey As Byte(), PrivateKeyPassphrase As String, Optional ByRef ErrorMessage As String = "") As Boolean

            'objects
            Dim SFTP As Rebex.Net.Sftp = Nothing
            Dim SshPrivateKey As Rebex.Net.SshPrivateKey = Nothing
            Dim Validated As Boolean = False

            Try

                SFTP = New Rebex.Net.Sftp

                SFTP.Timeout = 30000

                SFTP.Connect(Host, Port)

                If SFTP.IsConnected Then

                    If String.IsNullOrWhiteSpace(PrivateKeyPassphrase) = False Then

                        SshPrivateKey = New Rebex.Net.SshPrivateKey(PrivateKey, PrivateKeyPassphrase)

                    Else

                        SshPrivateKey = New Rebex.Net.SshPrivateKey(PrivateKey)

                    End If

                    SFTP.Login(UserName, SshPrivateKey)

                Else

                    ErrorMessage = "Connection to FTP failed."

                End If

            Catch ex As Exception

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    If ErrorMessage <> ex.InnerException.Message Then

                        ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                    End If

                End If

                If SFTP IsNot Nothing Then

                    SFTP.Dispose()

                End If

                SFTP = Nothing

            End Try

            If SFTP IsNot Nothing AndAlso SFTP.IsAuthenticated Then

                Validated = True

            End If

            SSHFTPValidation = Validated

        End Function
        Private Function SFTPValidation(FTPHost As String, FTPPort As Integer,
                                        UserName As String, Password As String, ErrorMessage As String) As Boolean

            'objects
            Dim SFTP As Rebex.Net.Sftp = Nothing
            Dim Validated As Boolean = False

            Try

                SFTP = New Rebex.Net.Sftp

                SFTP.Timeout = 30000

                SFTP.Connect(FTPHost, FTPPort)

                If SFTP.IsConnected Then

                    SFTP.Login(UserName, Password)

                Else

                    ErrorMessage = "Connection to FTP failed."

                End If

            Catch ex As Exception

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                End If

                If SFTP IsNot Nothing Then

                    SFTP.Dispose()

                End If

                SFTP = Nothing

            End Try

            If SFTP IsNot Nothing AndAlso SFTP.IsAuthenticated Then

                Validated = True

            End If

            SFTPValidation = Validated

        End Function
        Public Function RenameFileOnSFTPServer(ByVal FTPAddress As String, ByVal FTPPort As Integer, ByVal UserName As String, ByVal Password As String, ByVal OldFileName As String, ByVal NewFileName As String) As Boolean

            Dim SFTP As Rebex.Net.Sftp = Nothing
            Dim FilePath As String = Nothing
            Dim Renamed As Boolean = False

            Try

                SFTP = New Rebex.Net.Sftp

                SFTP.Timeout = 30000

                SFTP.Connect(FTPAddress, FTPPort)

                If SFTP.IsConnected Then

                    SFTP.Login(UserName, Password)

                End If

            Catch ex As Exception

                If SFTP IsNot Nothing Then

                    SFTP.Dispose()

                End If

                SFTP = Nothing

            End Try

            If SFTP IsNot Nothing AndAlso SFTP.IsAuthenticated Then

                Try

                    Renamed = True

                    SFTP.Rename(OldFileName, NewFileName)

                Catch ex As Exception
                    Renamed = False
                End Try

            End If

            RenameFileOnSFTPServer = Renamed

        End Function
        Public Function UploadToFTP(UseSSLForFTP As Boolean, FTPAddress As String, FTPPort As Integer, FTPFolder As String, FTPUserName As String,
                                    FTPPassword As String, SSLModeForFTP As Rebex.Net.SslMode, File As String, Optional ErrorMessage As String = "") As Boolean

            'objects
            Dim Uploaded As Boolean = False

            If UseSSLForFTP Then

                Uploaded = UploadToSFTP(FTPAddress, FTPPort, FTPFolder, FTPUserName, FTPPassword, File, ErrorMessage)

            Else

                Uploaded = UploadToFTP(FTPAddress, FTPPort, FTPFolder, FTPUserName, FTPPassword, SSLModeForFTP, File, ErrorMessage)

            End If

            UploadToFTP = Uploaded

        End Function
        Private Function UploadToFTP(FTPAddress As String, FTPPort As Integer, FTPFolder As String, FTPUserName As String,
                                     FTPPassword As String, SSLModeForFTP As Rebex.Net.SslMode, File As String, ErrorMessage As String) As Boolean

            'objects
            Dim Uploaded As Boolean = False
            Dim FTP As Rebex.Net.Ftp = Nothing

            Try

                FTP = New Rebex.Net.Ftp

                FTP.Timeout = 30000

                If SSLModeForFTP <> Rebex.Net.SslMode.None Then

                    AddHandler FTP.ValidatingCertificate, AddressOf ValidatingCertificate

                End If

                FTP.Connect(FTPAddress, FTPPort)

                If FTP.IsConnected Then

                    FTP.Login(FTPUserName, FTPPassword)

                Else

                    ErrorMessage = "Connection to FTP failed."

                End If

            Catch ex As Exception

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                End If

                If FTP IsNot Nothing Then

                    FTP.Dispose()

                End If

                FTP = Nothing

            End Try

            If FTP IsNot Nothing AndAlso FTP.IsAuthenticated Then

                If String.IsNullOrWhiteSpace(FTPFolder) = False Then

                    Try

                        FTP.Upload(File, FTPFolder)

                        Uploaded = True

                    Catch ex As Exception

                        Uploaded = False

                        ErrorMessage = ex.Message

                        If ex.InnerException IsNot Nothing Then

                            ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                        End If

                    End Try

                Else

                    Try

                        FTP.Upload(File, "/")

                        Uploaded = True

                    Catch ex As Exception

                        Uploaded = False

                        ErrorMessage = ex.Message

                        If ex.InnerException IsNot Nothing Then

                            ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                        End If

                    End Try

                End If

            End If

            UploadToFTP = Uploaded

        End Function
        Private Function UploadToSFTP(FTPAddress As String, FTPPort As Integer, FTPFolder As String, FTPUserName As String, FTPPassword As String, File As String, ErrorMessage As String) As Boolean

            'objects
            Dim Uploaded As Boolean = False
            Dim SFTP As Rebex.Net.Sftp = Nothing

            Try

                SFTP = New Rebex.Net.Sftp

                SFTP.Timeout = 30000

                SFTP.Connect(FTPAddress, FTPPort)

                If SFTP.IsConnected Then

                    SFTP.Login(FTPUserName, FTPPassword)

                Else

                    ErrorMessage = "Connection to FTP failed."

                End If

            Catch ex As Exception

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                End If

                If SFTP IsNot Nothing Then

                    SFTP.Dispose()

                End If

                SFTP = Nothing

            End Try

            If SFTP IsNot Nothing AndAlso SFTP.IsAuthenticated Then

                If String.IsNullOrWhiteSpace(FTPFolder) = False Then

                    Try

                        SFTP.Upload(File, FTPFolder)

                        Uploaded = True

                    Catch ex As Exception

                        Uploaded = False

                        ErrorMessage = ex.Message

                        If ex.InnerException IsNot Nothing Then

                            ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                        End If

                    End Try

                Else

                    Try

                        SFTP.Upload(File, "/")

                        Uploaded = True

                    Catch ex As Exception

                        Uploaded = False

                        ErrorMessage = ex.Message

                        If ex.InnerException IsNot Nothing Then

                            ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                        End If

                    End Try

                End If

            End If

            UploadToSFTP = Uploaded

        End Function
        Public Function UploadToSSHFTP(Host As String, Port As Integer, UserName As String, PrivateKey As Byte(), PrivateKeyPassphrase As String,
                                       Folder As String, File As String, Optional ErrorMessage As String = "") As Boolean

            'objects
            Dim Uploaded As Boolean = False
            Dim SFTP As Rebex.Net.Sftp = Nothing
            Dim SshPrivateKey As Rebex.Net.SshPrivateKey = Nothing

            Try

                SFTP = New Rebex.Net.Sftp

                SFTP.Timeout = 30000

                SFTP.Connect(Host, Port)

                If SFTP.IsConnected Then

                    If String.IsNullOrWhiteSpace(PrivateKeyPassphrase) = False Then

                        SshPrivateKey = New Rebex.Net.SshPrivateKey(PrivateKey, PrivateKeyPassphrase)

                    Else

                        SshPrivateKey = New Rebex.Net.SshPrivateKey(PrivateKey)

                    End If

                    SFTP.Login(UserName, SshPrivateKey)

                Else

                    ErrorMessage = "Connection to FTP failed."

                End If

            Catch ex As Exception

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                End If

                If SFTP IsNot Nothing Then

                    SFTP.Dispose()

                End If

                SFTP = Nothing

            End Try

            If SFTP IsNot Nothing AndAlso SFTP.IsAuthenticated Then

                If String.IsNullOrWhiteSpace(Folder) = False Then

                    Try

                        SFTP.Upload(File, Folder)

                        Uploaded = True

                    Catch ex As Exception

                        Uploaded = False

                        ErrorMessage = ex.Message

                        If ex.InnerException IsNot Nothing Then

                            ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                        End If

                    End Try

                Else

                    Try

                        SFTP.Upload(File, "/")

                        Uploaded = True

                    Catch ex As Exception

                        Uploaded = False

                        ErrorMessage = ex.Message

                        If ex.InnerException IsNot Nothing Then

                            ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                        End If

                    End Try

                End If

            End If

            UploadToSSHFTP = Uploaded

        End Function
        Public Function UploadToSSHFTP(Host As String, Port As Integer, UserName As String, PrivateKey As String, PrivateKeyPassphrase As String, Folder As String, File As String, Optional ErrorMessage As String = "") As Boolean

            'objects
            Dim Uploaded As Boolean = False
            Dim SFTP As Rebex.Net.Sftp = Nothing
            Dim SshPrivateKey As Rebex.Net.SshPrivateKey = Nothing

            Try

                SFTP = New Rebex.Net.Sftp

                SFTP.Timeout = 30000

                SFTP.Connect(Host, Port)

                If SFTP.IsConnected Then

                    If String.IsNullOrWhiteSpace(PrivateKeyPassphrase) = False Then

                        SshPrivateKey = New Rebex.Net.SshPrivateKey(PrivateKey, PrivateKeyPassphrase)

                    Else

                        SshPrivateKey = New Rebex.Net.SshPrivateKey(PrivateKey)

                    End If

                    SFTP.Login(UserName, SshPrivateKey)

                Else

                    ErrorMessage = "Connection to FTP failed."

                End If

            Catch ex As Exception

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                End If

                If SFTP IsNot Nothing Then

                    SFTP.Dispose()

                End If

                SFTP = Nothing

            End Try

            If SFTP IsNot Nothing AndAlso SFTP.IsAuthenticated Then

                If String.IsNullOrWhiteSpace(Folder) = False Then

                    Try

                        SFTP.Upload(File, Folder)

                        Uploaded = True

                    Catch ex As Exception

                        Uploaded = False

                        ErrorMessage = ex.Message

                        If ex.InnerException IsNot Nothing Then

                            ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                        End If

                    End Try

                Else

                    Try

                        SFTP.Upload(File, "/")

                        Uploaded = True

                    Catch ex As Exception

                        Uploaded = False

                        ErrorMessage = ex.Message

                        If ex.InnerException IsNot Nothing Then

                            ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                        End If

                    End Try

                End If

            End If

            UploadToSSHFTP = Uploaded

        End Function
        Public Function GetDirectoriesFromFTP(FTPHost As String, FTPPort As Integer,
                                              SSLMode As Rebex.Net.SslMode,
                                              UserName As String, Password As String,
                                              FTPPath As String, LocalPath As String,
                                              ByRef Directories As Generic.List(Of String)) As Boolean

            'objects
            Dim Downloaded As Boolean = False
            Dim FTP As Rebex.Net.Ftp = Nothing
            Dim FtpItemCollection As Rebex.Net.FtpItemCollection = Nothing

            Try

                FTP = New Rebex.Net.Ftp

                FTP.Timeout = 30000

                If SSLMode <> Rebex.Net.SslMode.None Then

                    AddHandler FTP.ValidatingCertificate, AddressOf ValidatingCertificate

                End If

                FTP.Connect(FTPHost, FTPPort, SSLMode)

                If FTP.IsConnected Then

                    FTP.Login(UserName, Password)

                End If

            Catch ex As Exception

                If FTP IsNot Nothing Then

                    FTP.Dispose()

                End If

                FTP = Nothing

            End Try

            If FTP IsNot Nothing AndAlso FTP.IsAuthenticated Then

                If Directories Is Nothing Then

                    Directories = New Generic.List(Of String)

                End If

                LocalPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(LocalPath, "\")

                Try

                    Downloaded = True

                    If String.IsNullOrWhiteSpace(FTPPath) OrElse FTPPath = "/" Then

                        FtpItemCollection = FTP.GetList()

                    Else

                        FtpItemCollection = FTP.GetList(FTPPath)

                    End If

                    For Each RebexItem In FtpItemCollection

                        If RebexItem.IsDirectory Then

                            Directories.Add(RebexItem.Name)

                        End If

                    Next

                Catch ex As Exception
                    Downloaded = False
                End Try

            End If

            GetDirectoriesFromFTP = Downloaded

        End Function
        Public Function GetDirectoriesFromSFTP(FTPHost As String, FTPPort As Integer,
                                               SSLMode As Rebex.Net.SslMode,
                                               UserName As String, Password As String,
                                               FTPPath As String, LocalPath As String,
                                               ByRef Directories As Generic.List(Of String)) As Boolean

            'objects
            Dim Downloaded As Boolean = False
            Dim SFTP As Rebex.Net.Sftp = Nothing
            Dim SFtpItemCollection As Rebex.Net.SftpItemCollection = Nothing

            Try

                SFTP = New Rebex.Net.Sftp

                SFTP.Timeout = 30000

                SFTP.Connect(FTPHost, FTPPort)

                If SFTP.IsConnected Then

                    SFTP.Login(UserName, Password)

                End If

            Catch ex As Exception

                If SFTP IsNot Nothing Then

                    SFTP.Dispose()

                End If

                SFTP = Nothing

            End Try

            If SFTP IsNot Nothing AndAlso SFTP.IsAuthenticated Then

                If Directories Is Nothing Then

                    Directories = New Generic.List(Of String)

                End If

                LocalPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(LocalPath, "\")

                Try

                    Downloaded = True

                    If String.IsNullOrWhiteSpace(FTPPath) OrElse FTPPath = "/" Then

                        SFtpItemCollection = SFTP.GetList()

                    Else

                        SFtpItemCollection = SFTP.GetList(FTPPath)

                    End If

                    For Each RebexItem In SFtpItemCollection

                        If RebexItem.IsDirectory Then

                            Directories.Add(RebexItem.Name)

                        End If

                    Next

                Catch ex As Exception
                    Downloaded = False
                End Try

            End If

            GetDirectoriesFromSFTP = Downloaded

        End Function

#End Region

    End Module

End Namespace
