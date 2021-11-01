Namespace FTP

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enums "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function CreateFTPClient(ByVal FTPAddress As String, ByVal Port As Integer, ByVal UserName As String, ByVal Password As String, ByVal FtpEncryptionMode As System.Net.FtpClient.FtpEncryptionMode) As System.Net.FtpClient.FtpClient

            'objects
            Dim FTPClient As System.Net.FtpClient.FtpClient = Nothing

            FTPClient = New System.Net.FtpClient.FtpClient()

            FTPClient.Host = FTPAddress
            FTPClient.Port = Port
            FTPClient.Credentials = New System.Net.NetworkCredential(UserName, Password)
            FTPClient.EncryptionMode = FtpEncryptionMode
            AddHandler FTPClient.ValidateCertificate, AddressOf OnValidateCertificate

            CreateFTPClient = FTPClient

        End Function
        Public Sub OnValidateCertificate(ByVal FtpClient As System.Net.FtpClient.FtpClient, ByVal e As System.Net.FtpClient.FtpSslValidationEventArgs)

            e.Accept = True

        End Sub
        Private Function CheckAndConvertFTPPathFormat(ByVal FTPPath As String) As String

            'objects
            Dim NewFTPPath As String = ""

            If Left(FTPPath, 4).ToUpper = "FTP." Then

                NewFTPPath = "ftp://" & FTPPath.Substring(4)

            Else

                NewFTPPath = FTPPath

            End If

            CheckAndConvertFTPPathFormat = NewFTPPath

        End Function
        Public Function ValidateFTP(ByVal FTPClient As System.Net.FtpClient.FtpClient, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim FTPIsValid As Boolean = False

            Try

                FTPClient.Connect()

                FTPIsValid = FTPClient.IsConnected

            Catch ex As Exception
                FTPIsValid = False
                ErrorMessage = ex.Message
            Finally
                ValidateFTP = FTPIsValid
            End Try

        End Function
        Public Function GetFilesInDirectory(ByVal FTPClient As System.Net.FtpClient.FtpClient) As List(Of String)

            'objects
            Dim Files As Generic.List(Of String) = Nothing

            Try

                If FTPClient.IsConnected = False Then

                    FTPClient.Connect()

                End If

                Files = New List(Of String)

                For Each FtpListItem In FTPClient.GetListing()

                    Files.Add(FtpListItem.Name)

                Next

            Catch ex As Exception
                Files = Nothing
            Finally
                GetFilesInDirectory = Files
            End Try

        End Function
        Public Function UploadFile(ByVal FTPClient As System.Net.FtpClient.FtpClient, ByVal TargetDirectory As String, ByVal FileToBeUploaded As String) As Boolean

            'objects
            Dim FileUploaded As Boolean = True
            Dim FileInfo As System.IO.FileInfo = Nothing
            Dim FileContents() As Byte = Nothing
            Dim Bytes As Integer = 0
            Dim TargetDirectorySet As Boolean = True

            Try

                If FTPClient.IsConnected = False Then

                    FTPClient.Connect()

                End If

                If String.IsNullOrWhiteSpace(TargetDirectory) = False AndAlso TargetDirectory.StartsWith("/") = False Then

                    TargetDirectory = AdvantageFramework.StringUtilities.PadWithCharacter(TargetDirectory, TargetDirectory.Length + 1, "/", True, False)

                End If

                If String.IsNullOrWhiteSpace(TargetDirectory) = False Then

                    Try

                        FTPClient.SetWorkingDirectory(TargetDirectory)

                    Catch ex As Exception
                        TargetDirectorySet = False
                    End Try

                End If

                If TargetDirectorySet Then

                    FileInfo = My.Computer.FileSystem.GetFileInfo(FileToBeUploaded)

                    ReDim FileContents(FileInfo.Length)

                    Using FileStream = FileInfo.OpenRead, Stream As System.IO.Stream = FTPClient.OpenWrite(FTPClient.GetWorkingDirectory() & FileInfo.Name, Net.FtpClient.FtpDataType.Binary)

                        Try

                            Bytes = FileStream.Read(FileContents, 0, FileContents.Length)

                            While Bytes > 0

                                Stream.Write(FileContents, 0, Bytes)

                                Bytes = FileStream.Read(FileContents, 0, FileContents.Length)

                            End While

                        Finally
                            FileStream.Close()
                            Stream.Close()
                        End Try

                    End Using

                End If

            Catch ex As Exception
                FileUploaded = False
            Finally
                UploadFile = FileUploaded
            End Try

        End Function
        Public Function DownloadFile(ByVal FTPClient As System.Net.FtpClient.FtpClient, ByVal FTPFileName As String, ByVal DestinationFile As String) As Boolean

            'objects
            Dim FileDownloaded As Boolean = True

            Try

                Using Stream As System.IO.Stream = FTPClient.OpenRead(FTPFileName), FileStream As System.IO.FileStream = New System.IO.FileStream(DestinationFile, IO.FileMode.Create)

                    Try

                        Stream.CopyTo(FileStream, 8192)

                    Finally
                        Stream.Close()
                        FileStream.Close()
                    End Try

                End Using

            Catch ex As Exception
                FileDownloaded = False
            Finally
                DownloadFile = FileDownloaded
            End Try

        End Function
        Public Function ValidateFTP(ByVal FTPAddress As String, ByVal UserName As String, ByVal Password As String, ByVal EnableSSL As Boolean, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim FTPIsValid As Boolean = True
            Dim FTP As System.Net.FtpWebRequest = Nothing
            Dim FtpWebResponse As System.Net.FtpWebResponse = Nothing

            Try

                FTPAddress = AdvantageFramework.StringUtilities.AppendTrailingCharacter(CheckAndConvertFTPPathFormat(FTPAddress), "/")

                FTP = System.Net.FtpWebRequest.Create(FTPAddress)

                FTP.EnableSsl = EnableSSL

                FTP.Credentials = New System.Net.NetworkCredential(UserName, Password)

                FTP.Method = System.Net.WebRequestMethods.Ftp.ListDirectory

                FtpWebResponse = FTP.GetResponse

                If FtpWebResponse Is Nothing Then

                    ErrorMessage = "No Response"
                    FTPIsValid = False

                End If

            Catch ex As Exception
                ErrorMessage = ex.Message
                FTPIsValid = False
            Finally

                ValidateFTP = FTPIsValid

                If FtpWebResponse IsNot Nothing Then

                    FtpWebResponse.Close()

                End If

                FtpWebResponse = Nothing
                FTP = Nothing

            End Try

        End Function
        Public Function GetFilesInDirectory(ByVal FTPAddress As String, ByVal UserName As String, ByVal Password As String, ByVal EnableSSL As Boolean) As List(Of String)

            'objects
            Dim FTP As System.Net.FtpWebRequest = Nothing
            Dim FtpWebResponse As System.Net.FtpWebResponse = Nothing
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim Files As Generic.List(Of String) = Nothing

            Try

                FTPAddress = AdvantageFramework.StringUtilities.AppendTrailingCharacter(CheckAndConvertFTPPathFormat(FTPAddress), "/")

                FTP = System.Net.FtpWebRequest.Create(FTPAddress)

                FTP.EnableSsl = EnableSSL

                FTP.Credentials = New System.Net.NetworkCredential(UserName, Password)

                FTP.Method = System.Net.WebRequestMethods.Ftp.ListDirectory

                FtpWebResponse = FTP.GetResponse

                StreamReader = New System.IO.StreamReader(FtpWebResponse.GetResponseStream())

                Files = New List(Of String)

                Do Until StreamReader.EndOfStream = True

                    Files.Add(StreamReader.ReadLine)

                Loop

                StreamReader.Close()
                FtpWebResponse.Close()

            Catch ex As Exception
                Files = Nothing
            Finally

                GetFilesInDirectory = Files

                If StreamReader IsNot Nothing Then

                    StreamReader.Dispose()

                End If

                StreamReader = Nothing

                FtpWebResponse = Nothing
                FTP = Nothing

            End Try

        End Function
        Public Function DownloadFile(ByVal FTPAddress As String, ByVal UserName As String, ByVal Password As String, ByVal EnableSSL As Boolean, ByVal FTPFileName As String, ByVal DestinationFile As String) As Boolean

            'objects
            Dim FileDownloaded As Boolean = True
            Dim FTP As System.Net.FtpWebRequest = Nothing
            Dim FtpWebResponse As System.Net.FtpWebResponse = Nothing
            Dim Stream As System.IO.Stream = Nothing
            Dim FileStream As System.IO.FileStream = Nothing
            Dim Buffer() As Byte = Nothing
            Dim KeepReading As Integer = 1

            Try

                FTPAddress = AdvantageFramework.StringUtilities.AppendTrailingCharacter(CheckAndConvertFTPPathFormat(FTPAddress), "/") & FTPFileName

                FTP = System.Net.FtpWebRequest.Create(FTPAddress)

                FTP.EnableSsl = EnableSSL

                FTP.Credentials = New System.Net.NetworkCredential(UserName, Password)

                FTP.Method = System.Net.WebRequestMethods.Ftp.DownloadFile

                FTP.UseBinary = True

                FtpWebResponse = FTP.GetResponse

                Stream = FtpWebResponse.GetResponseStream()

                FileStream = New System.IO.FileStream(DestinationFile, IO.FileMode.Create)

                ReDim Buffer(2047)

                Do While KeepReading <> 0

                    KeepReading = Stream.Read(Buffer, 0, KeepReading)
                    FileStream.Write(Buffer, 0, KeepReading)

                Loop

                Stream.Close()
                FileStream.Flush()
                FileStream.Close()
                Stream.Close()
                FtpWebResponse.Close()

            Catch ex As Exception
                FileDownloaded = False
            Finally

                DownloadFile = FileDownloaded

                If Stream IsNot Nothing Then

                    Stream.Dispose()

                End If

                Stream = Nothing

                If FileStream IsNot Nothing Then

                    FileStream.Dispose()

                End If

                FileStream = Nothing

                FtpWebResponse = Nothing
                FTP = Nothing

            End Try

        End Function
        Public Function UploadFile(ByVal FTPAddress As String, ByVal UserName As String, ByVal Password As String, ByVal EnableSSL As Boolean, ByVal FileToBeUploaded As String) As Boolean

            'objects
            Dim FileUploaded As Boolean = True
            Dim FTP As System.Net.FtpWebRequest = Nothing
            Dim FtpWebResponse As System.Net.FtpWebResponse = Nothing
            Dim FileInfo As System.IO.FileInfo = Nothing
            Dim FileContents() As Byte = Nothing

            Try

                FileInfo = My.Computer.FileSystem.GetFileInfo(FileToBeUploaded)

                FTPAddress = AdvantageFramework.StringUtilities.AppendTrailingCharacter(CheckAndConvertFTPPathFormat(FTPAddress), "/") & FileInfo.Name

                FTP = System.Net.FtpWebRequest.Create(FTPAddress)

                FTP.EnableSsl = EnableSSL

                FTP.Credentials = New System.Net.NetworkCredential(UserName, Password)

                FTP.Method = System.Net.WebRequestMethods.Ftp.UploadFile

                FTP.UseBinary = True

                ReDim FileContents(FileInfo.Length)

                Using FileStream = FileInfo.OpenRead

                    FileStream.Read(FileContents, 0, Convert.ToInt32(FileInfo.Length))

                End Using

                Using Stream = FTP.GetRequestStream

                    Stream.Write(FileContents, 0, FileContents.Length)

                End Using

                FtpWebResponse = FTP.GetResponse

                FtpWebResponse.Close()

            Catch ex As Exception
                FileUploaded = False
            Finally

                UploadFile = FileUploaded

                FtpWebResponse = Nothing
                FTP = Nothing

            End Try

        End Function
        Public Function RenameFileOnServer(ByVal FTPAddress As String, ByVal UserName As String, ByVal Password As String, ByVal EnableSSL As Boolean, ByVal OldFileName As String, ByVal NewFileName As String) As Boolean

            Dim FtpWebRequest As System.Net.FtpWebRequest = Nothing
            Dim FtpWebResponse As System.Net.FtpWebResponse = Nothing
            Dim FilePath As String = Nothing
            Dim FileRenamed As Boolean = True

            If FTPAddress.EndsWith("/") = False Then

                FilePath = FTPAddress & "/" & OldFileName

            Else

                FilePath = FTPAddress & OldFileName

            End If

            FtpWebRequest = CType(System.Net.FtpWebRequest.Create(FilePath), System.Net.FtpWebRequest)

            FtpWebRequest.EnableSsl = EnableSSL

            FtpWebRequest.Credentials = New System.Net.NetworkCredential(UserName, Password)
            FtpWebRequest.Method = System.Net.WebRequestMethods.Ftp.Rename
            FtpWebRequest.RenameTo() = NewFileName

            Try

                FtpWebResponse = CType(FtpWebRequest.GetResponse, System.Net.FtpWebResponse)

                If FtpWebResponse.StatusCode <> Net.FtpStatusCode.FileActionOK Then

                    FileRenamed = False

                End If

            Catch ex As Exception

                FileRenamed = False

            Finally

                RenameFileOnServer = FileRenamed

                FtpWebRequest = Nothing
                FtpWebResponse = Nothing

            End Try

        End Function

#End Region

    End Module

End Namespace
