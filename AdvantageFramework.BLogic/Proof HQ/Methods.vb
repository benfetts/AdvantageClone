Namespace ProofHQ

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function UseProofHQSingleAccount(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim ProofHQSingleAccountEnabled As Boolean = False
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.PROOFHQ_USE_SA.ToString)

            If Setting IsNot Nothing Then

                If IsNumeric(Setting.Value) AndAlso Setting.Value = 1 Then

                    ProofHQSingleAccountEnabled = True

                End If

            End If

            UseProofHQSingleAccount = ProofHQSingleAccountEnabled

        End Function
        Public Function UseProofHQSingleAccount(ByVal Session As AdvantageFramework.Security.Session) As Boolean

            'objects
            Dim ProofHQSingleAccountEnabled As Boolean = False

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                ProofHQSingleAccountEnabled = UseProofHQSingleAccount(DataContext)

            End Using

            UseProofHQSingleAccount = ProofHQSingleAccountEnabled

        End Function
        Public Function IsProofHQEnabled(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim ProofHQIsEnabled As Boolean = False
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.PROOFHQ_ENABLED.ToString)

            If Setting IsNot Nothing Then

                If IsNumeric(Setting.Value) AndAlso Setting.Value = 1 Then

                    ProofHQIsEnabled = True

                End If

            End If

            IsProofHQEnabled = ProofHQIsEnabled

        End Function
        Public Function IsProofHQEnabled(ByVal Session As AdvantageFramework.Security.Session) As Boolean

            'objects
            Dim ProofHQIsEnabled As Boolean = False

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                ProofHQIsEnabled = IsProofHQEnabled(DataContext)

            End Using

            IsProofHQEnabled = ProofHQIsEnabled

        End Function
        Public Function GetProofHQUserNameAndPassword(ByVal Session As AdvantageFramework.Security.Session, ByVal EmployeeCode As String, ByRef ProofHQUserName As String, ByRef ProofHQPassword As String) As Boolean

            'objects
            Dim HasProofUserNameAndPassword As Boolean = False

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    HasProofUserNameAndPassword = GetProofHQUserNameAndPassword(DbContext, DataContext, EmployeeCode, ProofHQUserName, ProofHQPassword)

                End Using

            End Using

            GetProofHQUserNameAndPassword = HasProofUserNameAndPassword

        End Function
        Public Function GetProofHQUserNameAndPassword(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                      ByVal EmployeeCode As String, ByRef ProofHQUserName As String, ByRef ProofHQPassword As String) As Boolean

            'objects
            Dim HasProofUserNameAndPassword As Boolean = False
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            ProofHQUserName = Nothing
            ProofHQPassword = Nothing

            If DbContext IsNot Nothing AndAlso DataContext IsNot Nothing Then

                If IsProofHQEnabled(DataContext) Then

                    If UseProofHQSingleAccount(DataContext) Then

                        Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.PROOFHQ_SA_USERNAME.ToString)

                        If Setting IsNot Nothing Then

                            ProofHQUserName = Setting.Value

                        End If

                        Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.PROOFHQ_SA_PASSWORD.ToString)

                        If Setting IsNot Nothing Then

                            ProofHQPassword = Setting.Value

                        End If

                    Else

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                        If Employee IsNot Nothing Then

                            ProofHQUserName = Employee.ProofHQUserName
                            ProofHQPassword = Employee.ProofHQPassword

                        End If

                    End If

                End If

            End If

            If String.IsNullOrEmpty(ProofHQUserName) = False AndAlso String.IsNullOrEmpty(ProofHQPassword) = False Then

                HasProofUserNameAndPassword = True

            End If

            GetProofHQUserNameAndPassword = HasProofUserNameAndPassword

        End Function
        Public Function GetFolders(ByVal Session As AdvantageFramework.Security.Session) As Generic.List(Of AdvantageFramework.ProofHQRef.SOAPWorkspaceObject)

            'objects
            Dim Folders As Generic.List(Of AdvantageFramework.ProofHQRef.SOAPWorkspaceObject) = Nothing

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Folders = GetFolders(DbContext, DataContext, Session.User.EmployeeCode)

                End Using

            End Using

            GetFolders = Folders

        End Function
        Public Function GetFolders(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EmployeeCode As String) As Generic.List(Of AdvantageFramework.ProofHQRef.SOAPWorkspaceObject)

            'objects
            Dim Folders As Generic.List(Of AdvantageFramework.ProofHQRef.SOAPWorkspaceObject) = Nothing
            Dim ProofHQ As AdvantageFramework.ProofHQRef.soapService = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim SOAPLoginObject As AdvantageFramework.ProofHQRef.SOAPLoginObject = Nothing
            Dim ProofHQUserName As String = Nothing
            Dim ProofHQPassword As String = Nothing

            Try

                If GetProofHQUserNameAndPassword(DbContext, DataContext, EmployeeCode, ProofHQUserName, ProofHQPassword) Then

                    ProofHQ = New AdvantageFramework.ProofHQRef.soapService()

                    SOAPLoginObject = ProofHQ.doLogin(ProofHQUserName, ProofHQPassword)

                    If SOAPLoginObject IsNot Nothing AndAlso String.IsNullOrEmpty(SOAPLoginObject.session) = False Then

                        Folders = ProofHQ.getWorkspaces(SOAPLoginObject.session).ToList

                    End If

                End If

            Catch ex As Exception
                Folders = Nothing
            End Try

            If Folders Is Nothing Then

                Folders = New Generic.List(Of AdvantageFramework.ProofHQRef.SOAPWorkspaceObject)

            End If

            GetFolders = Folders

        End Function
        'Public Function UploadFile(ByVal Session As AdvantageFramework.Security.Session, ByVal File As String, ByVal Name As String, _
        '                           ByRef ErrorCode As String, ByRef ErrorString As String, Optional ByVal FolderID As Integer = 0) As Boolean

        '    'objects
        '    Dim Uploaded As Boolean = False

        '    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

        '        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

        '            Uploaded = UploadFile(DbContext, DataContext, Session.User.EmployeeCode, File, Name, ErrorCode, ErrorString, FolderID, "", 0)

        '        End Using

        '    End Using

        '    UploadFile = Uploaded

        'End Function
        'Public Function UploadFile(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, _
        '                           ByVal EmployeeCode As String, ByVal File As String, ByVal Name As String, _
        '                           ByRef ErrorCode As String, ByRef ErrorString As String, ByVal FolderID As Integer, _
        '                           ByRef ProofHQUrl As String, ByRef ProofHQFileID As Integer) As Boolean

        '    'objects
        '    Dim Uploaded As Boolean = False
        '    Dim FileInfo As System.IO.FileInfo = Nothing
        '    Dim ByteFile() As Byte = Nothing

        '    If My.Computer.FileSystem.FileExists(File) Then

        '        FileInfo = My.Computer.FileSystem.GetFileInfo(File)

        '        Using FileStream = New System.IO.FileStream(File, System.IO.FileMode.Open, System.IO.FileAccess.Read)

        '            Using BinaryReader = New System.IO.BinaryReader(FileStream)

        '                ByteFile = BinaryReader.ReadBytes(FileInfo.Length)

        '            End Using

        '        End Using

        '    End If

        '    If ByteFile IsNot Nothing Then

        '        Uploaded = UploadFile(DbContext, DataContext, EmployeeCode, ByteFile, File, Name, ErrorCode, ErrorString, FolderID, ProofHQUrl, ProofHQFileID)

        '    End If

        '    UploadFile = Uploaded

        'End Function
        Public Function UploadFile(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                   ByVal EmployeeCode As String, ByVal ByteFile() As Byte, ByVal FileName As String, ByVal Name As String,
                                   ByRef ErrorCode As String, ByRef ErrorString As String, ByVal FolderID As Integer,
                                   ByRef ProofHQUrl As String, ByRef ProofHQFileID As Integer) As Boolean

            'objects
            Dim Uploaded As Boolean = False
            Dim ProofHQ As AdvantageFramework.ProofHQRef.soapService = Nothing
            Dim SOAPLoginObject As AdvantageFramework.ProofHQRef.SOAPLoginObject = Nothing
            Dim ResponseMessage As String = ""
            Dim FileHash As String = ""
            Dim SourceFileName As String = ""
            Dim MD5 As String = ""
            Dim SOAPFileObject As AdvantageFramework.ProofHQRef.SOAPFileObject = Nothing
            Dim ProofHQUserName As String = Nothing
            Dim ProofHQPassword As String = Nothing

            If ByteFile IsNot Nothing Then

                If FolderID = 0 Then

                    FolderID = -1

                End If

                If GetProofHQUserNameAndPassword(DbContext, DataContext, EmployeeCode, ProofHQUserName, ProofHQPassword) Then

                    ProofHQ = New AdvantageFramework.ProofHQRef.soapService

                    SOAPLoginObject = ProofHQ.doLogin(ProofHQUserName, ProofHQPassword)

                    If SOAPLoginObject IsNot Nothing AndAlso SOAPLoginObject.session <> "" Then

                        If PostFileToProofHQ(ByteFile, Name, ResponseMessage) Then

                            If ReadWebReponseXML(ResponseMessage, FileHash, SourceFileName, MD5, ErrorCode, ErrorString) Then

                                If String.IsNullOrEmpty(FileHash) = False AndAlso String.IsNullOrEmpty(SourceFileName) = False AndAlso String.IsNullOrEmpty(ErrorCode) = True Then

                                    Try

                                        'SOAPFileObject = ProofHQ.createFile(SOAPLoginObject.session, 0, FileHash, Name, SourceFileName, "Uploaded from Advantage", "Uploaded from Advantage", "", "", FolderID, 0, "", False)

                                        SOAPFileObject = ProofHQ.createProof(SOAPLoginObject.session, 0, FileHash, Name, SourceFileName, "Uploaded from Advantage", "Uploaded from Advantage", "", "", FolderID, 0,
                                                                             True, True, "", "", False, True, False, True, True, True, True, True, True, True, True, True, True, True, True, True, "", "", False, "", True)

                                    Catch ex As Exception
                                        ErrorString = ex.Message
                                        ErrorCode = "ADV Msg"
                                        SOAPFileObject = Nothing
                                    End Try

                                    If SOAPFileObject IsNot Nothing AndAlso SOAPFileObject.file_id <> 0 Then

                                        'ProofHQUrl = ProofHQ.getFileDownloadLink(SOAPLoginObject.session, SOAPFileObject.file_id)
                                        ProofHQUrl = ProofHQ.getProofURL(SOAPLoginObject.session, SOAPFileObject.file_id)
                                        Uploaded = True

                                    End If

                                End If

                            Else

                                ErrorString = "Failed reading response message from Proof HQ."
                                ErrorCode = "ADV Msg"

                            End If

                        Else

                            ErrorString = "Failed uploading file to Proof HQ."
                            ErrorCode = "ADV Msg"

                        End If

                    Else

                        ErrorString = "Cannot login to Proof HQ.  Please verify Proof HQ user name and password."
                        ErrorCode = "ADV Msg"

                    End If

                Else

                    ErrorString = "Cannot find valid Proof HQ account. Please enter this information in Integration Settings or Employee Maintenance."
                    ErrorCode = "ADV Msg"

                End If

            Else

                ErrorString = "File that you are trying to upload does not exist."
                ErrorCode = "ADV Msg"

            End If

            UploadFile = Uploaded

        End Function
        Public Function UploadNewVersion(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                         ByVal EmployeeCode As String, ByVal ByteFile() As Byte, ByVal ParentProofHQFileID As Integer, ByVal FileName As String, ByVal Name As String,
                                         ByRef ErrorCode As String, ByRef ErrorString As String, ByVal FolderID As Integer,
                                         ByRef ProofHQUrl As String, ByRef ProofHQFileID As Integer) As Boolean

            'objects
            Dim Uploaded As Boolean = False
            Dim ProofHQ As AdvantageFramework.ProofHQRef.soapService = Nothing
            Dim SOAPLoginObject As AdvantageFramework.ProofHQRef.SOAPLoginObject = Nothing
            Dim ResponseMessage As String = ""
            Dim FileHash As String = ""
            Dim SourceFileName As String = ""
            Dim MD5 As String = ""
            Dim SOAPFileObject As AdvantageFramework.ProofHQRef.SOAPFileObject = Nothing
            Dim ProofHQUserName As String = Nothing
            Dim ProofHQPassword As String = Nothing

            If ByteFile IsNot Nothing Then

                If GetProofHQUserNameAndPassword(DbContext, DataContext, EmployeeCode, ProofHQUserName, ProofHQPassword) Then

                    ProofHQ = New AdvantageFramework.ProofHQRef.soapService

                    SOAPLoginObject = ProofHQ.doLogin(ProofHQUserName, ProofHQPassword)

                    If SOAPLoginObject IsNot Nothing AndAlso SOAPLoginObject.session <> "" Then

                        If PostFileToProofHQ(ByteFile, Name, ResponseMessage) Then

                            If ReadWebReponseXML(ResponseMessage, FileHash, SourceFileName, MD5, ErrorCode, ErrorString) Then

                                If String.IsNullOrEmpty(FileHash) = False AndAlso String.IsNullOrEmpty(SourceFileName) = False AndAlso String.IsNullOrEmpty(ErrorCode) = True Then

                                    Try

                                        SOAPFileObject = ProofHQ.createProofVersion(SOAPLoginObject.session, ParentProofHQFileID, 0, FileHash, Name, SourceFileName, "Uploaded from Advantage", "Uploaded from Advantage", "", "", FolderID, 0,
                                                                                    True, True, "", "", False, True, False, True, True, True, True, True, True, True, True, True, True, True, True, True, "", "", False, "", True)

                                    Catch ex As Exception
                                        ErrorString = ex.Message
                                        ErrorCode = "ADV Msg"
                                        SOAPFileObject = Nothing
                                    End Try

                                    If SOAPFileObject IsNot Nothing AndAlso SOAPFileObject.file_id <> 0 Then

                                        'ProofHQUrl = ProofHQ.getFileDownloadLink(SOAPLoginObject.session, SOAPFileObject.file_id)
                                        ProofHQUrl = ProofHQ.getProofURL(SOAPLoginObject.session, SOAPFileObject.file_id)
                                        Uploaded = True

                                    End If

                                End If

                            Else

                                ErrorString = "Failed reading response message from Proof HQ."
                                ErrorCode = "ADV Msg"

                            End If

                        Else

                            ErrorString = "Failed uploading file to Proof HQ."
                            ErrorCode = "ADV Msg"

                        End If

                    Else

                        ErrorString = "Cannot login to Proof HQ.  Please verify Proof HQ user name and password."
                        ErrorCode = "ADV Msg"

                    End If

                Else

                    ErrorString = "Cannot find valid Proof HQ account. Please enter this information in Integration Settings or Employee Maintenance."
                    ErrorCode = "ADV Msg"

                End If

            Else

                ErrorString = "File that you are trying to upload does not exist."
                ErrorCode = "ADV Msg"

            End If

            UploadNewVersion = Uploaded

        End Function
        Private Function ReadWebReponseXML(ByVal XML As String, ByRef FileHash As String, ByRef FileName As String, ByRef MD5 As String, ByRef ErrorCode As String, ByRef ErrorString As String) As Boolean

            'objects
            Dim ReadXML As Boolean = False
            Dim XmlReader As System.Xml.XmlReader = Nothing
            Dim StringReader As System.IO.StringReader = Nothing

            FileHash = ""
            FileName = ""
            MD5 = ""
            ErrorCode = ""
            ErrorString = ""

            Try

                StringReader = New System.IO.StringReader(XML)
                XmlReader = System.Xml.XmlReader.Create(StringReader)

                If XmlReader.ReadToDescendant("result") Then

                    If XmlReader.ReadToDescendant("item") Then

                        If XmlReader.Read() Then

                            ReadXML = True

                            Try

                                FileHash = XmlReader.ReadElementString("filehash")

                            Catch ex As Exception
                                ReadXML = False
                            End Try

                            If ReadXML Then

                                Try

                                    FileName = XmlReader.ReadElementString("filename")

                                Catch ex As Exception
                                    ReadXML = False
                                End Try

                            End If

                            If ReadXML Then

                                Try

                                    MD5 = XmlReader.ReadElementString("md5")

                                Catch ex As Exception
                                    ReadXML = False
                                End Try

                            End If

                            If ReadXML Then

                                Try

                                    ErrorCode = XmlReader.ReadElementString("errorcode")

                                Catch ex As Exception
                                    ReadXML = False
                                End Try

                            End If

                            If ReadXML Then

                                Try

                                    ErrorString = XmlReader.ReadElementString("errorstring")

                                Catch ex As Exception
                                    ReadXML = False
                                End Try

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                ReadXML = False
            End Try

            ReadWebReponseXML = ReadXML

        End Function
        Private Function PostFileToProofHQ(ByVal ByteFile() As Byte, ByVal FileName As String, ByRef ResponseMessage As String) As Boolean

            'objects
            Dim FilePostedToProofHQ As Boolean = False
            Dim Boundary As String = ""
            Dim HttpWebRequest As System.Net.HttpWebRequest = Nothing
            Dim BoundaryBytes As Byte() = Nothing
            Dim FormDataTemplate As String = ""
            Dim HeaderTemplate As String = ""
            Dim Header As String = ""
            Dim HeaderBytes As Byte() = Nothing
            Dim TempBuffer As Byte() = Nothing
            Dim WebResponse As System.Net.WebResponse = Nothing
            Dim Stream As System.IO.Stream = Nothing
            Dim StreamReader As System.IO.StreamReader = Nothing

            Boundary = "----------------------------" & DateTime.Now.Ticks.ToString("x")

            HttpWebRequest = DirectCast(System.Net.WebRequest.Create("http://soap.proofhq.com/soap/upload"), System.Net.HttpWebRequest)
            HttpWebRequest.ContentType = "multipart/form-data; boundary=" & Boundary
            HttpWebRequest.Method = "POST"
            HttpWebRequest.KeepAlive = True
            HttpWebRequest.Credentials = System.Net.CredentialCache.DefaultCredentials

            Using MemoryStream = New System.IO.MemoryStream

                BoundaryBytes = System.Text.Encoding.ASCII.GetBytes(vbCr & vbLf & "--" & Boundary & vbCr & vbLf)
                FormDataTemplate = vbCr & vbLf & "--" & Boundary & vbCr & vbLf & "Content-Disposition:  form-data; name=""{0}"";" & vbCr & vbLf & vbCr & vbLf & "{1}"
                HeaderTemplate = "Content-Disposition: form-data; name=""{0}""; filename=""{1}""" & vbCr & vbLf & " Content-Type: application/octet-stream" & vbCr & vbLf & vbCr & vbLf
                MemoryStream.Write(BoundaryBytes, 0, BoundaryBytes.Length)

                Header = String.Format(HeaderTemplate, "file1", FileName)
                HeaderBytes = System.Text.Encoding.UTF8.GetBytes(Header)
                MemoryStream.Write(HeaderBytes, 0, HeaderBytes.Length)

                MemoryStream.Write(ByteFile, 0, ByteFile.Length)

                MemoryStream.Write(BoundaryBytes, 0, BoundaryBytes.Length)

                HttpWebRequest.ContentLength = MemoryStream.Length

                Using RequestStream = HttpWebRequest.GetRequestStream()

                    MemoryStream.Position = 0

                    TempBuffer = New Byte(MemoryStream.Length - 1) {}

                    MemoryStream.Read(TempBuffer, 0, TempBuffer.Length)
                    MemoryStream.Close()

                    RequestStream.Write(TempBuffer, 0, TempBuffer.Length)
                    RequestStream.Close()

                End Using

            End Using

            Try

                WebResponse = HttpWebRequest.GetResponse()
                Stream = WebResponse.GetResponseStream()
                StreamReader = New System.IO.StreamReader(Stream)

                ResponseMessage = StreamReader.ReadToEnd()

                FilePostedToProofHQ = True

            Catch ex As Exception
                FilePostedToProofHQ = False
            End Try

            HttpWebRequest = Nothing
            WebResponse = Nothing
            Stream = Nothing
            StreamReader = Nothing

            PostFileToProofHQ = FilePostedToProofHQ

        End Function
        Public Function GetProofs(ByVal Session As AdvantageFramework.Security.Session, ByVal SearchQuery As String) As Generic.List(Of AdvantageFramework.ProofHQRef.SOAPFileObject)

            'objects
            Dim Proofs As Generic.List(Of AdvantageFramework.ProofHQRef.SOAPFileObject) = Nothing

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Proofs = GetProofs(DbContext, DataContext, Session.User.EmployeeCode, SearchQuery)

                End Using

            End Using

            GetProofs = Proofs

        End Function
        Public Function GetProofs(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EmployeeCode As String, ByVal SearchQuery As String) As Generic.List(Of AdvantageFramework.ProofHQRef.SOAPFileObject)

            'objects
            Dim Proofs As Generic.List(Of AdvantageFramework.ProofHQRef.SOAPFileObject) = Nothing
            Dim ProofHQ As AdvantageFramework.ProofHQRef.soapService = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim SOAPLoginObject As AdvantageFramework.ProofHQRef.SOAPLoginObject = Nothing
            Dim ProofHQUserName As String = Nothing
            Dim ProofHQPassword As String = Nothing

            Try

                If GetProofHQUserNameAndPassword(DbContext, DataContext, EmployeeCode, ProofHQUserName, ProofHQPassword) Then

                    ProofHQ = New AdvantageFramework.ProofHQRef.soapService()

                    SOAPLoginObject = ProofHQ.doLogin(ProofHQUserName, ProofHQPassword)

                    If SOAPLoginObject IsNot Nothing AndAlso String.IsNullOrEmpty(SOAPLoginObject.session) = False Then

                        Proofs = ProofHQ.getAllProofs(SOAPLoginObject.session, 0, SearchQuery, 0).ToList

                    End If

                End If

            Catch ex As Exception
                Proofs = Nothing
            End Try

            If Proofs Is Nothing Then

                Proofs = New Generic.List(Of AdvantageFramework.ProofHQRef.SOAPFileObject)

            End If

            GetProofs = Proofs

        End Function
        Public Function DownloadFile(ByVal Session As AdvantageFramework.Security.Session, ByVal FileID As Integer, ByRef Bytes() As Byte, ByRef ProofHQUrl As String, ByRef ErrorString As String) As Boolean

            'objects
            Dim Downloaded As Boolean = False

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Downloaded = DownloadFile(DbContext, DataContext, Session.User.EmployeeCode, FileID, Bytes, ProofHQUrl, ErrorString)

                End Using

            End Using

            DownloadFile = Downloaded

        End Function
        Public Function DownloadFile(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                     ByVal EmployeeCode As String, ByVal FileID As Integer, ByRef Bytes() As Byte, ByRef ProofHQUrl As String, ByRef ErrorString As String) As Boolean

            'objects
            Dim Downloaded As Boolean = False
            Dim ProofHQ As AdvantageFramework.ProofHQRef.soapService = Nothing
            Dim SOAPLoginObject As AdvantageFramework.ProofHQRef.SOAPLoginObject = Nothing
            Dim ProofHQUserName As String = Nothing
            Dim ProofHQPassword As String = Nothing
            Dim WebClient As System.Net.WebClient = Nothing

            If GetProofHQUserNameAndPassword(DbContext, DataContext, EmployeeCode, ProofHQUserName, ProofHQPassword) Then

                Bytes = Nothing

                ProofHQ = New AdvantageFramework.ProofHQRef.soapService

                SOAPLoginObject = ProofHQ.doLogin(ProofHQUserName, ProofHQPassword)

                If SOAPLoginObject IsNot Nothing AndAlso SOAPLoginObject.session <> "" Then

                    WebClient = New System.Net.WebClient

                    Try

                        Bytes = WebClient.DownloadData(ProofHQ.getProofDownloadURL(SOAPLoginObject.session, FileID))

                    Catch ex As Exception
                        ErrorString = ex.Message
                        Bytes = Nothing
                    End Try

                    Try

                        ProofHQUrl = ProofHQ.getProofURL(SOAPLoginObject.session, FileID)

                    Catch ex As Exception
                        ErrorString = ex.Message
                        ProofHQUrl = ""
                    End Try

                    If Bytes IsNot Nothing AndAlso String.IsNullOrWhiteSpace(ProofHQUrl) = False Then

                        Downloaded = True

                    End If

                Else

                    ErrorString = "Cannot login to Proof HQ.  Please verify Proof HQ user name and password."

                End If

            Else

                ErrorString = "Cannot find valid Proof HQ account. Please enter this information in Integration Settings or Employee Maintenance."

            End If

            DownloadFile = Downloaded

        End Function

#End Region

    End Module

End Namespace
