Namespace FileSystem

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Public Const KBInBytes As Long = 1024
        Public Const MBInBytes As Long = 1048576
        Public Const GBInBytes As Long = 1073741824

#End Region

#Region " Enum "

        Public Enum FileFilters
            [Default]
            CSV
            TXT
            ADVLIC
            PRNX
            ZIP
            REPX
            INV
            V51
            XML
            P12
            PFX
            MIT
            DAT
            BUY
            BUYandDATandTXT
            PDF
            XMLandSCXandPRP
            SCX
            GIF
            PPK
            PRP
        End Enum

        Public Enum FileTypes
            Word
            Powerpoint
            Project
            PDF
            Excel
            Image
            Text
            Photoshop
            Illustrator
            Zip
            URL
            Outlook
            Generic
        End Enum

        Public Enum DocumentSource
            [Default]
            DocumentUpload
            Alert
        End Enum

#End Region

#Region " Variables "

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function IsValidImage(ByVal File As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim Image As System.Drawing.Image = Nothing

            Try

                Image = System.Drawing.Image.FromFile(File)

            Catch generatedExceptionName As OutOfMemoryException
                IsValid = False
            End Try

            IsValidImage = IsValid

        End Function
        Private Function LoadDocumentPrefix(ByVal DocumentSource As AdvantageFramework.FileSystem.DocumentSource) As String

            Select Case DocumentSource

                Case DocumentSource.DocumentUpload

                    LoadDocumentPrefix = "d_"

                Case DocumentSource.Alert

                    LoadDocumentPrefix = "a_"

                Case Else

                    LoadDocumentPrefix = ""

            End Select

        End Function
        Public Function IsFileInUse(ByVal File As String) As Boolean

            'objects
            Dim FileIsInUse As Boolean = False
            Dim FileStream As System.IO.FileStream = Nothing

            Try

                FileStream = System.IO.File.Open(File, IO.FileMode.OpenOrCreate, IO.FileAccess.Read, IO.FileShare.None)

            Catch ex As Exception
                FileIsInUse = True
            End Try

            Try

                If FileStream IsNot Nothing Then

                    FileStream.Close()
                    FileStream.Dispose()

                End If

            Catch ex As Exception

            Finally
                FileStream = Nothing
            End Try

            IsFileInUse = FileIsInUse

        End Function
        Public Function LoadFileFilterString(ByVal FileFilter As FileFilters)

            'objects
            Dim FileFilterString As String = ""

            Select Case FileFilter

                Case FileFilters.Default

                    FileFilterString = "All Files (*.*)|*.*"

                Case FileFilters.CSV

                    FileFilterString = "CSV Files (*.csv)|*.csv"

                Case FileFilters.TXT

                    FileFilterString = "Text Files (*.txt)|*.txt"

                Case FileFilters.ADVLIC

                    FileFilterString = "Advantage License Files (*.advlic)|*.advlic"

                Case FileFilters.PRNX

                    FileFilterString = "Printed Report Files (*.prnx)|*.prnx"

                Case FileFilters.ZIP

                    FileFilterString = "Zip Files (*.zip)|*.zip"

                Case FileFilters.REPX

                    FileFilterString = "DX Report Files (*.repx)|*.repx"

                Case FileFilters.INV

                    FileFilterString = "Invoice Import Files (*.inv)|*.inv"

                Case FileFilters.V51

                    FileFilterString = "Invoice Import Files (*.v51)|*.v51"

                Case FileFilters.XML

                    FileFilterString = "XML Files (*.xml)|*.xml"

                Case FileFilters.DAT

                    FileFilterString = "DAT Files (*.dat)|*.dat"

                Case FileFilters.BUY

                    FileFilterString = "BUY Files (*.buy)|*.buy"

                Case FileFilters.BUYandDATandTXT

                    FileFilterString = "BUY, DAT, & Text Files (*.buy, *.dat, *.txt)|*.buy;*.dat;*.txt"

                Case FileFilters.PDF

                    FileFilterString = "PDF Files (*.pdf)|*.pdf"

                Case FileFilters.XMLandSCXandPRP

                    FileFilterString = "XML, SCX, & PRP Files (*.xml, *.scx, *.prp)|*.xml;*.scx;*.prp"

            End Select

            LoadFileFilterString = FileFilterString

        End Function
        Public Function LoadFileFilterString(ByVal FileFilters As FileFilters())

            'objects
            Dim FilterStrings As Generic.List(Of String) = Nothing
            Dim FileFilterString As String = ""

            FilterStrings = New List(Of String)

            For Each FileFilter In FileFilters

                FilterStrings.Add(LoadFileFilterString(FileFilter))

            Next

            FileFilterString = String.Join("|", FilterStrings)

            LoadFileFilterString = FileFilterString

        End Function
        Public Function GetFileName(ByVal File As String) As String

            'objects
            Dim FileName As String = ""
            Dim FileInfo As System.IO.FileInfo = Nothing

            Try

                FileInfo = My.Computer.FileSystem.GetFileInfo(File)

                If FileInfo IsNot Nothing Then

                    FileName = FileInfo.Name

                End If

            Catch ex As Exception
                FileName = ""
            Finally
                GetFileName = FileName
            End Try

        End Function
        Public Function GetFileSize(ByVal FileInfo As System.IO.FileInfo) As Long

            'objects
            Dim FileSize As Long = 0

            Try

                If FileInfo IsNot Nothing Then

                    FileSize = FileInfo.Length

                End If

            Catch ex As Exception
                FileSize = 0
            Finally
                GetFileSize = FileSize
            End Try

        End Function
        Public Function GetFileSize(ByVal File As String) As Long

            'objects
            Dim FileSize As Long = 0
            Dim FileInfo As System.IO.FileInfo = Nothing

            Try

                FileSize = GetFileSize(My.Computer.FileSystem.GetFileInfo(File))

            Catch ex As Exception
                FileSize = 0
            Finally
                GetFileSize = FileSize
            End Try

        End Function
        Public Function GetFileSizeWithNotation(ByVal FileSize As Double) As String

            Dim Notations(9) As String
            Dim i As Integer = Nothing
            Dim FileSizeWithNotation As String = Nothing


            Notations(0) = "Bytes"
            Notations(1) = "KB" 'Kilobytes
            Notations(2) = "MB" 'Megabytes
            Notations(3) = "GB" 'Gigabytes
            Notations(4) = "TB" 'Terabytes
            Notations(5) = "PB" 'Petabytes
            Notations(6) = "EB" 'Exabytes
            Notations(7) = "ZB" 'Zettabytes
            Notations(8) = "YB" 'Yottabytes

            Try

                For i = UBound(Notations) To 0 Step -1

                    If FileSize >= (1024 ^ i) Then

                        If i >= 2 Then

                            FileSizeWithNotation = String.Format("{0:N2} {1}", FileSize / (1024 ^ i), Notations(i))

                        Else

                            FileSizeWithNotation = String.Format("{0:N0} {1}", FileSize / (1024 ^ i), Notations(i))

                        End If

                        Exit For

                    End If

                Next

            Catch ex As Exception
                FileSizeWithNotation = Nothing
            Finally
                GetFileSizeWithNotation = FileSizeWithNotation
            End Try

        End Function
        Public Function GetFileType(ByVal FileName As String, ByVal MIMEType As String) As AdvantageFramework.FileSystem.FileTypes

            'objects
            Dim FileType As AdvantageFramework.FileSystem.FileTypes = Nothing

            Try

                FileType = GetFileTypeByMIMEType(MIMEType)

                If FileType = FileTypes.Generic Then

                    FileType = GetFileTypeByExtension(FileName)

                End If

            Catch ex As Exception
                FileType = FileTypes.Generic
            Finally
                GetFileType = FileType
            End Try

        End Function
        Public Function GetFileTypeByMIMEType(ByVal MIMEType As String) As AdvantageFramework.FileSystem.FileTypes

            Dim FileType As AdvantageFramework.FileSystem.FileTypes = Nothing

            Select Case MIMEType

                Case "application/msword", "application/vnd.openxmlformats-officedocument.word", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Word

                Case "application/mspowerpoint", "application/vnd.ms-powerpoint"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Powerpoint

                Case "application/msproject", "application/vnd.ms-msproject"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Project

                Case "application/pdf"

                    FileType = AdvantageFramework.FileSystem.FileTypes.PDF

                Case "application/msexcel", "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spre"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Excel

                Case "image/bmp"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Image

                Case "image/gif"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Image

                Case "image/jpeg", "image/pjpeg"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Image

                Case "image/x-png", "image/png"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Image

                Case "image/tiff"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Image

                Case "text/plain"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Text

                Case "image/x-photoshop"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Photoshop

                Case "application/illustrator"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Illustrator

                Case "URL"

                    FileType = AdvantageFramework.FileSystem.FileTypes.URL

                Case "application/x-zip-compressed", "application/zip"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Zip

                Case "application/vnd.ms-outlook"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Outlook

                Case Else

                    FileType = AdvantageFramework.FileSystem.FileTypes.Generic

            End Select

            GetFileTypeByMIMEType = FileType

        End Function
        Public Function GetFileTypeByExtension(ByVal FileName As String) As AdvantageFramework.FileSystem.FileTypes

            Dim FileType As AdvantageFramework.FileSystem.FileTypes = Nothing
            Dim FileExtension As String = ""

            Try

                FileExtension = New System.IO.FileInfo(FileName).Extension

            Catch ex As Exception
                FileExtension = ""
            End Try

            Select Case FileExtension

                Case ".doc", ".docx"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Word

                Case ".ppt", ".pptx"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Powerpoint

                Case ".mpg"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Project

                Case ".pdf"

                    FileType = AdvantageFramework.FileSystem.FileTypes.PDF

                Case ".xls", ".xlsx", ".csv"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Excel

                Case ".bmp", ".gif", ".jpg", ".jpeg", ".png", ".tiff"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Image

                Case ".txt"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Text

                Case ".psd"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Photoshop

                Case ".ai"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Illustrator

                Case ".com", ".org", ".net"

                    FileType = AdvantageFramework.FileSystem.FileTypes.URL

                Case ".zip", "rar"

                    FileType = AdvantageFramework.FileSystem.FileTypes.Zip

                Case Else

                    FileType = AdvantageFramework.FileSystem.FileTypes.Generic

            End Select

            GetFileTypeByExtension = FileType

        End Function
        Public Function GetMIMETypeByExtension(ByVal Extension As String) As String

            'objects
            Dim MIMEType As String = ""
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            Try

                MIMEType = "application/unknown"

                Extension = Extension.Trim
                If Extension.StartsWith(".") = False Then Extension = "." & Extension

                RegistryKey = My.Computer.Registry.ClassesRoot.OpenSubKey(Extension.ToLower)

                If RegistryKey IsNot Nothing Then

                    If RegistryKey.GetValue("Content Type") IsNot Nothing Then

                        MIMEType = RegistryKey.GetValue("Content Type").ToString

                    Else

                        MIMEType = "application/unknown"

                    End If

                End If

            Catch ex As Exception
                MIMEType = "application/unknown"
            Finally
                GetMIMETypeByExtension = MIMEType
            End Try

        End Function
        Public Function GetMIMEType(ByVal FileInfo As System.IO.FileInfo) As String

            'objects
            Dim MIMEType As String = ""

            Try

                If FileInfo IsNot Nothing Then

                    MIMEType = GetMIMETypeByExtension(FileInfo.Extension)

                End If

            Catch ex As Exception
                MIMEType = "application/unknown"
            Finally
                GetMIMEType = MIMEType
            End Try

        End Function
        Public Function GetMIMEType(ByVal File As String) As String

            'objects
            Dim MIMEType As String = ""

            Try

                MIMEType = GetMIMEType(My.Computer.FileSystem.GetFileInfo(File))

            Catch ex As Exception
                MIMEType = "application/unknown"
            Finally
                GetMIMEType = MIMEType
            End Try

        End Function
        Public Function GetFileImage(ByVal FileType As AdvantageFramework.FileSystem.FileTypes) As Object

            Dim FileImage As Object = Nothing

            Select Case FileType

                Case AdvantageFramework.FileSystem.FileTypes.Word

                    FileImage = AdvantageFramework.My.Resources.WordImage

                Case AdvantageFramework.FileSystem.FileTypes.Powerpoint

                    FileImage = AdvantageFramework.My.Resources.DocumentPowerpoint

                Case AdvantageFramework.FileSystem.FileTypes.Project

                    FileImage = AdvantageFramework.My.Resources.DocumentProject

                Case AdvantageFramework.FileSystem.FileTypes.PDF

                    FileImage = AdvantageFramework.My.Resources.PDFImage

                Case AdvantageFramework.FileSystem.FileTypes.Excel

                    FileImage = AdvantageFramework.My.Resources.ExcelImage

                Case AdvantageFramework.FileSystem.FileTypes.Image

                    FileImage = AdvantageFramework.My.Resources.DocumentImage

                Case AdvantageFramework.FileSystem.FileTypes.Text

                    FileImage = AdvantageFramework.My.Resources.DocumentText

                Case AdvantageFramework.FileSystem.FileTypes.Photoshop

                    FileImage = AdvantageFramework.My.Resources.DocumentPhotoshop

                Case AdvantageFramework.FileSystem.FileTypes.Illustrator

                    FileImage = AdvantageFramework.My.Resources.DocumentIllustrator

                Case AdvantageFramework.FileSystem.FileTypes.Zip

                    FileImage = AdvantageFramework.My.Resources.DocumentZip

                Case AdvantageFramework.FileSystem.FileTypes.URL

                    FileImage = AdvantageFramework.My.Resources.DocumentURL

                Case AdvantageFramework.FileSystem.FileTypes.Outlook

                    FileImage = AdvantageFramework.My.Resources.MicrosoftOutlookImage

                Case AdvantageFramework.FileSystem.FileTypes.Generic

                    FileImage = AdvantageFramework.My.Resources.DocumentGeneric

            End Select

            GetFileImage = FileImage

        End Function
        Public Function Download(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal Document As AdvantageFramework.Database.Entities.Document,
                                 ByRef ByteFile() As Byte, Optional ByRef FileExists As Boolean = False) As Boolean

            'objects
            Dim Downloaded As Boolean = False
            Dim FileStream As System.IO.FileStream = Nothing
            Dim FileSystemFile As String = Nothing
            Dim BinaryReader As System.IO.BinaryReader = Nothing

            Try

                If Agency IsNot Nothing AndAlso Document IsNot Nothing Then

                    AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                    Try

                        If LoadRepositoryFilePath(Agency, Document.FileSystemFileName, FileSystemFile) Then

                            FileExists = True

                            FileStream = New System.IO.FileStream(FileSystemFile, IO.FileMode.OpenOrCreate)
                            BinaryReader = New System.IO.BinaryReader(FileStream)
                            ByteFile = BinaryReader.ReadBytes(New System.IO.FileInfo(FileSystemFile).Length)

                            FileStream.Close()
                            BinaryReader.Close()

                            Downloaded = True

                        End If

                    Catch ex As Exception
                        Downloaded = False
                    End Try

                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                End If

            Catch ex As Exception
                Downloaded = False
            Finally
                Download = Downloaded
            End Try

        End Function
        Public Function Download(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal Document As AdvantageFramework.Database.Entities.Document,
                                 ByVal SaveLocation As String, Optional ByRef NewFileName As String = Nothing, Optional ByRef FileExists As Boolean = False) As Boolean

            'objects
            Dim Downloaded As Boolean = Nothing
            Dim FileStream As System.IO.FileStream = Nothing
            Dim FileSystemFile As String = Nothing
            Dim File As String = Nothing
            Dim BinaryReader As System.IO.BinaryReader = Nothing
            Dim ByteFile() As Byte = Nothing
            Dim FileWriter As System.IO.FileStream = Nothing
            Dim Counter As Integer = 0
            Dim FileExtension As String = Nothing

            Try

                If Agency IsNot Nothing AndAlso Document IsNot Nothing Then

                    AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                    Try

                        If LoadRepositoryFilePath(Agency, Document.FileSystemFileName, FileSystemFile) Then

                            FileExists = True

                            FileStream = New System.IO.FileStream(FileSystemFile, IO.FileMode.OpenOrCreate)
                            BinaryReader = New System.IO.BinaryReader(FileStream)
                            ByteFile = BinaryReader.ReadBytes(New System.IO.FileInfo(FileSystemFile).Length)

                            FileStream.Close()
                            BinaryReader.Close()

                        End If

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                    If FileExists Then

                        If ByteFile IsNot Nothing Then

                            NewFileName = AdvantageFramework.StringUtilities.AppendTrailingCharacter(SaveLocation, "\") & Document.FileName

                            FileExtension = New System.IO.FileInfo(NewFileName).Extension

                            While System.IO.File.Exists(NewFileName)

                                Counter = Counter + 1

                                NewFileName = AdvantageFramework.StringUtilities.AppendTrailingCharacter(SaveLocation, "\") & Document.FileName.Replace(FileExtension, String.Format("({0})" & FileExtension, Counter.ToString))

                            End While

                            Try

                                FileWriter = New System.IO.FileStream(NewFileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
                                FileWriter.Write(ByteFile, 0, ByteFile.Length)

                                Downloaded = True

                            Catch ex As Exception
                                Downloaded = False
                            End Try

                            If FileWriter IsNot Nothing Then

                                FileWriter.Close()

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                Downloaded = False
            Finally
                Download = Downloaded
            End Try

        End Function
        Public Function Download(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal AlertAttachmentView As AdvantageFramework.Database.Views.AlertAttachmentView,
                                 ByVal SaveLocation As String, Optional ByRef NewFileName As String = Nothing, Optional ByRef FileExists As Boolean = False) As Boolean

            'objects
            Dim Downloaded As Boolean = Nothing
            Dim FileStream As System.IO.FileStream = Nothing
            Dim FileSystemFile As String = Nothing
            Dim File As String = Nothing
            Dim BinaryReader As System.IO.BinaryReader = Nothing
            Dim ByteFile() As Byte = Nothing
            Dim FileWriter As System.IO.FileStream = Nothing
            Dim Counter As Integer = 0
            Dim FileExtension As String = Nothing

            Try

                If Agency IsNot Nothing AndAlso AlertAttachmentView IsNot Nothing Then

                    AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                    If LoadRepositoryFilePath(Agency, AlertAttachmentView.RepositoryFilename, FileSystemFile) Then

                        FileExists = True

                        FileStream = New System.IO.FileStream(FileSystemFile, IO.FileMode.OpenOrCreate, IO.FileAccess.Read, IO.FileShare.ReadWrite)
                        BinaryReader = New System.IO.BinaryReader(FileStream)
                        ByteFile = BinaryReader.ReadBytes(New System.IO.FileInfo(FileSystemFile).Length)

                    End If

                    If FileExists Then

                        If ByteFile IsNot Nothing Then

                            NewFileName = SaveLocation & "\" & AlertAttachmentView.RealFileName

                            FileExtension = New System.IO.FileInfo(NewFileName).Extension

                            While System.IO.File.Exists(NewFileName)

                                Counter = Counter + 1

                                NewFileName = SaveLocation & "\" & AlertAttachmentView.RealFileName.Replace(FileExtension, String.Format("({0})" & FileExtension, Counter.ToString))

                            End While

                            FileWriter = New System.IO.FileStream(NewFileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
                            FileWriter.Write(ByteFile, 0, ByteFile.Length)
                            FileWriter.Close()

                            Downloaded = True

                        End If

                    End If

                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                End If

            Catch ex As Exception
                Downloaded = False
            Finally
                Download = Downloaded
            End Try

        End Function
        Public Function Add(ByVal Session As AdvantageFramework.Security.Session, ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal MemoryStream As System.IO.MemoryStream,
                            ByVal RealFileName As String, ByVal Description As String, ByVal Keywords As String, ByVal UserCodeOrEmployeeName As String, Optional ByVal FinalLevel As String = "",
                            Optional ByVal FinalLevelDescription As String = "", Optional ByVal DocumentSource As AdvantageFramework.FileSystem.DocumentSource = DocumentSource.Default,
                            Optional ByRef FileSystemFile As String = "", Optional ByRef FileName As String = "", Optional ByVal AddToDocumentRepository As Boolean = False,
                            Optional ByRef DocumentID As Integer = Nothing) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Add = Add(DbContext, Agency, MemoryStream, RealFileName, Description, Keywords, UserCodeOrEmployeeName, FinalLevel, FinalLevelDescription, DocumentSource, FileSystemFile, FileName, AddToDocumentRepository, DocumentID)

            End Using

        End Function
        Public Function Add(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal MemoryStream As System.IO.MemoryStream,
                            ByVal RealFileName As String, ByVal Description As String, ByVal Keywords As String, ByVal UserCodeOrEmployeeName As String, Optional ByVal FinalLevel As String = "",
                            Optional ByVal FinalLevelDescription As String = "", Optional ByVal DocumentSource As AdvantageFramework.FileSystem.DocumentSource = DocumentSource.Default,
                            Optional ByRef FileSystemFile As String = "", Optional ByRef FileName As String = "", Optional ByVal AddToDocumentRepository As Boolean = False,
                            Optional ByRef DocumentID As Integer = Nothing) As Boolean

            'objects
            Dim FileAdded As Boolean = False
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim XMLDocument As System.Xml.XmlDocument = Nothing
            Dim IndexFile() As Byte = Nothing
            Dim FileWriter As System.IO.FileStream = Nothing
            Dim ImpersonateUser As Boolean = False
            Dim FilePrefix As String = Nothing
            Dim ByteFile() As System.Byte = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

            Try

                If Agency IsNot Nothing Then

                    FilePrefix = LoadDocumentPrefix(DocumentSource)

                    If FileSystemFile = "" Then

                        FileName = FilePrefix & Guid.NewGuid.ToString()

                    End If

                    StringBuilder = New System.Text.StringBuilder

                    StringBuilder.AppendLine("<?xml version=""1.0"" encoding=""utf-8"" ?>")
                    StringBuilder.AppendLine("<documents>")
                    StringBuilder.AppendLine("<document filename="""" realfilename=""""  description="""" keywords="""" author="""" finallevel="""" finalleveldetail="""" ></document>")
                    StringBuilder.AppendLine("</documents>")

                    XMLDocument = New System.Xml.XmlDocument

                    XMLDocument.LoadXml(StringBuilder.ToString)
                    XMLDocument.SelectSingleNode("//documents/document").Attributes("filename").Value = FileName
                    XMLDocument.SelectSingleNode("//documents/document").Attributes("realfilename").Value = RealFileName
                    XMLDocument.SelectSingleNode("//documents/document").Attributes("description").Value = Description
                    XMLDocument.SelectSingleNode("//documents/document").Attributes("author").Value = UserCodeOrEmployeeName
                    XMLDocument.SelectSingleNode("//documents/document").Attributes("keywords").Value = Keywords
                    XMLDocument.SelectSingleNode("//documents/document").Attributes("finallevel").Value = FinalLevel
                    XMLDocument.SelectSingleNode("//documents/document").Attributes("finalleveldetail").Value = FinalLevelDescription

                    IndexFile = System.Text.ASCIIEncoding.ASCII.GetBytes(XMLDocument.OuterXml)

                    ByteFile = MemoryStream.ToArray()

                    If Agency.FileSystemUserName IsNot Nothing Then

                        ImpersonateUser = True

                        AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                    End If

                    Try

                        FileSystemFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\") & FileName

                        FileWriter = New System.IO.FileStream(FileSystemFile, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
                        FileWriter.Write(ByteFile, 0, ByteFile.Length)
                        FileWriter.Close()

                        FileWriter = New System.IO.FileStream(FileSystemFile & ".index.xml", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
                        FileWriter.Write(IndexFile, 0, IndexFile.Length)
                        FileWriter.Close()

                        FileAdded = True

                    Catch ex As Exception
                        FileAdded = False
                    End Try

                    If ImpersonateUser Then

                        AdvantageFramework.Security.Impersonate.EndImpersonation()

                    End If

                    If FileAdded Then

                        If AddToDocumentRepository Then

                            Document = New AdvantageFramework.Database.Entities.Document
                            Document.FileSystemFileName = FileName
                            Document.FileName = RealFileName
                            Document.Description = Description
                            Document.Keywords = Keywords
                            Document.MIMEType = AdvantageFramework.FileSystem.GetMIMEType(RealFileName)
                            Document.UploadedDate = System.DateTime.Now
                            Document.UserCode = DbContext.UserCode
                            Document.FileSize = ByteFile.Length
                            Document.IsPrivate = Nothing
                            Document.DocumentTypeID = 2 'File

                            Dim CurrentWindowsIdentity As System.Security.Principal.WindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
                            Dim ImpersonationContext As System.Security.Principal.WindowsImpersonationContext = Nothing

                            If ImpersonateUser = True Then

                                Try
                                    CurrentWindowsIdentity = CType(System.Web.HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                Catch ex As Exception
                                    CurrentWindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
                                End Try

                                ImpersonationContext = CurrentWindowsIdentity.Impersonate()

                            End If

                            Try

                                Document.ID = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                               Select Entity.ID).Max + 1

                            Catch ex As Exception
                                Document.ID = 1
                            End Try

                            If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then

                                DocumentID = Document.ID

                            End If

                            If ImpersonateUser Then

                                ImpersonationContext.Undo()

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                FileAdded = False
            Finally
                Add = FileAdded
            End Try

        End Function
        Public Function Add(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal File As String, ByVal Description As String, ByVal Keywords As String,
                             ByVal UserCodeOrEmployeeName As String, Optional ByVal FinalLevel As String = "", Optional ByVal FinalLevelDescription As String = "",
                             Optional ByVal DocumentSource As AdvantageFramework.FileSystem.DocumentSource = DocumentSource.Default, Optional ByRef FileSystemFile As String = "", Optional ByRef byteFile() As Byte = Nothing,
                             Optional ByRef FileName As String = "", Optional ByVal EventLog As System.Diagnostics.EventLog = Nothing) As Boolean

            'objects
            Dim FileAdded As Boolean = False
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim XMLDocument As System.Xml.XmlDocument = Nothing
            Dim IndexFile() As Byte = Nothing
            Dim FileWriter As System.IO.FileStream = Nothing
            Dim ImpersonateUser As Boolean = False
            Dim FileStream As System.IO.FileStream = Nothing
            Dim BinaryReader As System.IO.BinaryReader = Nothing
            Dim FilePrefix As String = Nothing

            Try

                If Agency IsNot Nothing Then

                    FilePrefix = LoadDocumentPrefix(DocumentSource)

                    If FileSystemFile = "" Then

                        FileName = FilePrefix & Guid.NewGuid.ToString()

                    End If

                    StringBuilder = New System.Text.StringBuilder

                    StringBuilder.AppendLine("<?xml version=""1.0"" encoding=""utf-8"" ?>")
                    StringBuilder.AppendLine("<documents>")
                    StringBuilder.AppendLine("<document filename="""" realfilename=""""  description="""" keywords="""" author="""" finallevel="""" finalleveldetail="""" ></document>")
                    StringBuilder.AppendLine("</documents>")

                    XMLDocument = New System.Xml.XmlDocument

                    XMLDocument.LoadXml(StringBuilder.ToString)
                    XMLDocument.SelectSingleNode("//documents/document").Attributes("filename").Value = FileName
                    XMLDocument.SelectSingleNode("//documents/document").Attributes("realfilename").Value = New System.IO.FileInfo(File).Name
                    XMLDocument.SelectSingleNode("//documents/document").Attributes("description").Value = Description
                    XMLDocument.SelectSingleNode("//documents/document").Attributes("author").Value = UserCodeOrEmployeeName
                    XMLDocument.SelectSingleNode("//documents/document").Attributes("keywords").Value = Keywords
                    XMLDocument.SelectSingleNode("//documents/document").Attributes("finallevel").Value = FinalLevel
                    XMLDocument.SelectSingleNode("//documents/document").Attributes("finalleveldetail").Value = FinalLevelDescription

                    IndexFile = System.Text.ASCIIEncoding.ASCII.GetBytes(XMLDocument.OuterXml)

                    If byteFile Is Nothing Then

                        FileStream = New System.IO.FileStream(File, IO.FileMode.OpenOrCreate)
                        BinaryReader = New System.IO.BinaryReader(FileStream)
                        byteFile = BinaryReader.ReadBytes(New System.IO.FileInfo(File).Length)

                        FileStream.Close()
                        FileStream.Dispose()
                        BinaryReader.Close()

                    End If

                    If Agency.FileSystemUserName IsNot Nothing Then

                        ImpersonateUser = True

                        AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                    End If

                    Try

                        If EventLog IsNot Nothing Then

                            EventLog.WriteEntry("Saving file to document repository --> " & Agency.FileSystemDirectory)

                        End If

                        FileSystemFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\") & FileName

                        FileWriter = New System.IO.FileStream(FileSystemFile, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
                        FileWriter.Write(byteFile, 0, byteFile.Length)
                        FileWriter.Close()

                        FileWriter = New System.IO.FileStream(FileSystemFile & ".index.xml", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
                        FileWriter.Write(IndexFile, 0, IndexFile.Length)
                        FileWriter.Close()

                        FileAdded = True

                    Catch ex As Exception
                        FileAdded = False
                    End Try

                    If Not FileAdded Then

                        If EventLog IsNot Nothing Then

                            If Not System.IO.Directory.Exists(Agency.FileSystemDirectory) Then

                                EventLog.WriteEntry("Directory does not exist --> " & Agency.FileSystemDirectory)

                            Else

                                EventLog.WriteEntry("Saving file to document repository failed! Please check document repository settings.")

                            End If

                        End If

                    End If

                    If ImpersonateUser Then

                        AdvantageFramework.Security.Impersonate.EndImpersonation()

                    End If

                End If

            Catch ex As Exception

                FileAdded = False

                If EventLog IsNot Nothing Then

                    EventLog.WriteEntry("Saving file to document repository failed! --> " & ex.Message)

                End If

            Finally
                Add = FileAdded
            End Try

        End Function
        Public Function Delete(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal RepositoryFilename As String) As Boolean

            Dim ErrorMessage As String = String.Empty
            Return Delete(Agency, RepositoryFilename, ErrorMessage)

        End Function
        Public Function Delete(ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                               ByVal RepositoryFilename As String,
                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim ImpersonateUser As Boolean = False
            Dim FileExists As Boolean = False
            Dim FileDeleted As Boolean = False
            Dim XmlFileExists As Boolean = False
            Dim XmlFileDeleted As Boolean = False

            Try

                If Agency IsNot Nothing Then

                    If Agency.FileSystemUserName IsNot Nothing Then

                        ImpersonateUser = True

                        AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                    End If
                    If System.IO.File.Exists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\") & RepositoryFilename) Then

                        FileExists = True

                        System.GC.Collect()
                        System.GC.WaitForPendingFinalizers()

                        Try

                            System.IO.File.Delete(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\") & RepositoryFilename)
                            FileDeleted = True

                        Catch ex As Exception
                            FileDeleted = False
                        End Try

                    ElseIf System.IO.File.Exists(RepositoryFilename) Then

                        FileExists = True

                        System.GC.Collect()
                        System.GC.WaitForPendingFinalizers()

                        Try

                            System.IO.File.Delete(RepositoryFilename)
                            FileDeleted = True

                        Catch ex As Exception
                            FileDeleted = False
                        End Try

                    End If
                    If System.IO.File.Exists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\") & RepositoryFilename & ".index.xml") Then

                        XmlFileExists = True

                        System.GC.Collect()
                        System.GC.WaitForPendingFinalizers()

                        Try

                            System.IO.File.Delete(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\") & RepositoryFilename & ".index.xml")

                        Catch ex As Exception
                            XmlFileExists = False
                        End Try

                    ElseIf System.IO.File.Exists(RepositoryFilename & ".index.xml") Then

                        XmlFileExists = True

                        System.GC.Collect()
                        System.GC.WaitForPendingFinalizers()

                        Try

                            System.IO.File.Delete(RepositoryFilename & ".index.xml")

                        Catch ex As Exception
                            XmlFileExists = False
                        End Try

                    End If
                    If ImpersonateUser Then

                        AdvantageFramework.Security.Impersonate.EndImpersonation()

                    End If

                End If

            Catch ex As Exception
                Deleted = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            If FileExists = False Then

                Deleted = True

            ElseIf FileDeleted = True Then

                Deleted = True

            End If

            Return Deleted

        End Function
        Public Function GetDocumentRepositoryFileSizeLimit(ByVal DbContext As AdvantageFramework.Database.DbContext) As Long

            'objects
            Dim RepositoryLimit As Long = Nothing

            Try

                RepositoryLimit = Convert.ToInt64(DbContext.Database.SqlQuery(Of String)("exec usp_wv_DocumentManager_Limit_Get 1").Single)

            Catch ex As Exception
                RepositoryLimit = Nothing
            End Try

            GetDocumentRepositoryFileSizeLimit = RepositoryLimit

        End Function
        Public Sub GetDocumentRepositoryFileSizeLimit(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef RespositoryLimit As Long, ByRef LimitText As String)

            'objects
            Dim MaxFileSize As Long = Nothing

            Try

                MaxFileSize = GetDocumentRepositoryFileSizeLimit(DbContext)

            Catch ex As Exception
                MaxFileSize = Nothing
            End Try

            If MaxFileSize >= 0 Then

                LimitText = "Files larger than " & Math.Round((MaxFileSize / 1024) / 1024, 0).ToString & "MB will automatically be excluded."

            Else

                LimitText = ""

            End If

        End Sub
        Public Sub GetDocumentRepositoryMaxFileSizeLimit(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef MaxFileSize As Long, ByRef LimitText As String)

            Try

                MaxFileSize = GetDocumentRepositoryFileSizeLimit(DbContext)

            Catch ex As Exception
                MaxFileSize = -1
            End Try
            If MaxFileSize >= 0 Then

                LimitText = "Files larger than " & Math.Round((MaxFileSize / 1024) / 1024, 0).ToString & "MB will automatically be excluded."

            Else

                LimitText = ""

            End If

        End Sub

        Public Function GetDocumentRepositoryLimit(ByVal DbContext As AdvantageFramework.Database.DbContext) As Long

            'objects
            Dim RepositoryLimit As Long = Nothing

            Try

                RepositoryLimit = Convert.ToInt64(DbContext.Database.SqlQuery(Of String)("exec usp_wv_DocumentManager_Limit_Get 0").Single)

            Catch ex As Exception
                RepositoryLimit = Nothing
            End Try

            GetDocumentRepositoryLimit = RepositoryLimit

        End Function
        Public Function GetDocumentRepositorySize(ByVal DbContext As AdvantageFramework.Database.DbContext) As Long

            ' objects
            Dim RepositorySize As Int64 = Nothing

            Try

                'RepositorySize = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                '                  Select Entity.FileSize).Sum
                RepositorySize = DbContext.Database.SqlQuery(Of Int64)("SELECT SUM(CAST(FILE_SIZE AS BIGINT)) FROM DOCUMENTS WITH(NOLOCK);").SingleOrDefault

            Catch ex As Exception
                RepositorySize = Nothing
            End Try

            GetDocumentRepositorySize = RepositorySize

        End Function
        Public Function LoadRepositoryFilePath(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FileName As String, ByRef RepositoryFilePath As String) As Boolean

            Dim FileLoaded As Boolean = False
            Dim FileSystemDirectory As String = ""

            Try

                If DbContext IsNot Nothing Then

                    FileSystemDirectory = AdvantageFramework.Database.Procedures.Agency.LoadFileSystemDirectory(DbContext)

                    FileLoaded = LoadRepositoryFilePath(FileSystemDirectory, FileName, RepositoryFilePath)

                End If

            Catch ex As Exception
                FileLoaded = False
            Finally
                LoadRepositoryFilePath = FileLoaded
            End Try

        End Function
        Public Function LoadRepositoryFilePath(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal FileName As String, ByRef RepositoryFilePath As String) As Boolean

            Dim FileLoaded As Boolean = False

            Try

                If Agency IsNot Nothing Then

                    FileLoaded = LoadRepositoryFilePath(Agency.FileSystemDirectory, FileName, RepositoryFilePath)

                End If

            Catch ex As Exception
                FileLoaded = False
            Finally
                LoadRepositoryFilePath = FileLoaded
            End Try

        End Function
        Public Function LoadRepositoryFilePath(ByVal FileSystemDirectory As String, ByVal FileName As String, ByRef RepositoryFilePath As String) As Boolean

            Dim FileLoaded As Boolean = False

            Try

                RepositoryFilePath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(FileSystemDirectory, "\") & FileName

                If System.IO.File.Exists(RepositoryFilePath) Then

                    FileLoaded = True

                End If

            Catch ex As Exception
                FileLoaded = False
            Finally
                LoadRepositoryFilePath = FileLoaded
            End Try

        End Function
        Public Sub CheckRepositoryConstraints(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FileName As String, ByRef IsValid As Boolean, ByRef ErrorMessage As String)

            'objects
            Dim FileInfo As System.IO.FileInfo = Nothing

            Try

                FileInfo = New System.IO.FileInfo(FileName)

                CheckFileForRepositoryConstraints(DbContext, FileInfo.Length, IsValid, ErrorMessage)

            Catch ex As Exception

            End Try

        End Sub
        Public Sub CheckFileForRepositoryConstraints(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FileLength As Long,
                                                     ByRef IsValid As Boolean,
                                                     ByRef ErrorMessage As String)

            'objects
            Dim MaxFileSize As Long = Nothing
            Dim DocumentRepositoryLimit As Long = -1

            IsValid = True

            Try

                MaxFileSize = GetDocumentRepositoryFileSizeLimit(DbContext)
                DocumentRepositoryLimit = AdvantageFramework.FileSystem.GetDocumentRepositoryLimit(DbContext)

                If (DocumentRepositoryLimit > 0) AndAlso
                        (GetDocumentRepositorySize(DbContext) + FileLength > DocumentRepositoryLimit) Then

                    ErrorMessage = "The file size exceeds the space left in the repository. File will not be uploaded! Please contact an administrator."
                    IsValid = False

                ElseIf MaxFileSize = 0 Then

                    ErrorMessage = "*Upload file size is set to 0 MB. File will not be uploaded! Please contact an administrator."
                    IsValid = False

                ElseIf (MaxFileSize > 0) AndAlso (FileLength > MaxFileSize) Then

                    ErrorMessage = "The file size exceeds the max file size limit. File will not be uploaded! Please contact an administrator."
                    IsValid = False

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                IsValid = False
            End Try

        End Sub
        Public Function CheckRepositoryLimit(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentRepositoryLimit As Long, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim ValidRepositoryLimit As Boolean = True
            Dim DocumentRepositorySize As Long = 0

            Try

                If DocumentRepositoryLimit > 0 Then

                    DocumentRepositorySize = GetDocumentRepositorySize(DbContext)

                    If (DocumentRepositoryLimit - DocumentRepositorySize) < 1 Then

                        ErrorMessage = "There is no more space left in the repository. File(s) will not be uploaded! Please contact an administrator."
                        ValidRepositoryLimit = False

                    End If

                End If

            Catch ex As Exception
            End Try

            CheckRepositoryLimit = ValidRepositoryLimit

        End Function
        Public Function CheckRepositoryLimit(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim ValidRepositoryLimit As Boolean = True
            Dim DocumentRepositoryLimit As Long = -1
            Dim DocumentRepositorySize As Long = 0

            Try

                DocumentRepositoryLimit = GetDocumentRepositoryLimit(DbContext)
                DocumentRepositorySize = GetDocumentRepositorySize(DbContext)

                If DocumentRepositoryLimit > 0 Then

                    If (DocumentRepositoryLimit - DocumentRepositorySize) < 1 Then

                        ErrorMessage = "There is no more space left in the repository. File(s) will not be uploaded! Please contact an administrator."
                        ValidRepositoryLimit = False

                    End If

                End If

            Catch ex As Exception

            End Try

            CheckRepositoryLimit = ValidRepositoryLimit

        End Function
        Public Function LoadHostedClientUploadLocation(ByVal Agency As AdvantageFramework.Database.Entities.Agency) As String

            'objects
            Dim UploadLocation As String = ""

            Try

                If Agency.IsASP.GetValueOrDefault(0) = 1 Then

                    UploadLocation = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath, "\") & "Repository\In\"

                End If

            Catch ex As Exception
                UploadLocation = ""
            Finally
                LoadHostedClientUploadLocation = UploadLocation
            End Try

        End Function
        Public Function LoadHostedClientUploadLocation(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            LoadHostedClientUploadLocation = LoadHostedClientUploadLocation(Agency)

        End Function
        Public Function LoadHostedClientDownloadLocation(ByVal Agency As AdvantageFramework.Database.Entities.Agency) As String

            'objects
            Dim DownloadLocation As String = ""

            Try

                If Agency.IsASP.GetValueOrDefault(0) = 1 Then

                    DownloadLocation = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath, "\") & "Repository\Out\"

                End If

            Catch ex As Exception
                DownloadLocation = ""
            Finally
                LoadHostedClientDownloadLocation = DownloadLocation
            End Try

        End Function
        Public Function LoadHostedClientDownloadLocation(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            LoadHostedClientDownloadLocation = LoadHostedClientDownloadLocation(Agency)

        End Function
        Public Function IsValidFileName(ByVal FileName As String) As Boolean

            'objects
            Dim IsValid As Boolean = True

            For Each BadChar In System.IO.Path.GetInvalidFileNameChars

                If FileName.Contains(BadChar) Then

                    IsValid = False
                    Exit For

                End If

            Next

            IsValidFileName = IsValid

        End Function
        Public Function CreateValidFileName(ByVal FileName As String) As String

            'objects
            Dim ValidFileName As String = ""

            ValidFileName = FileName

            Try

                For Each BadChar In System.IO.Path.GetInvalidFileNameChars

                    If ValidFileName.Contains(BadChar) Then

                        ValidFileName = ValidFileName.Replace(BadChar, "")

                    End If

                Next

            Catch ex As Exception
                ValidFileName = FileName
            End Try

            CreateValidFileName = ValidFileName

        End Function
        Public Function LoadAvailableDocumentManagerLevels(ByVal Session As AdvantageFramework.Security.Session) As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

            'objects
            Dim EnumObject As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing
            Dim EnumObjects As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing
            Dim DocumentManagerLevels As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing

            DocumentManagerLevels = New Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

            EnumObjects = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.DocumentLevel))

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

				For Each UserPermission In AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndUser(SecurityDbContext, Session.Application, Session.User.ID).Where(Function(Entity) Entity.ModuleCode.StartsWith("Desktop_DocumentManagerLevels_")).ToList

					If UserPermission.IsBlocked = False Then

						Try

							EnumObject = EnumObjects.SingleOrDefault(Function(EO) EO.Description = UserPermission.Module)

						Catch ex As Exception
							EnumObject = Nothing
						End Try

						If EnumObject IsNot Nothing Then

							DocumentManagerLevels.Add(EnumObject)

						End If

					End If

				Next

			End Using

            LoadAvailableDocumentManagerLevels = DocumentManagerLevels

        End Function
        Public Function AddDateGUID(ByVal File As String) As String
            Try

                Dim FileInfo As System.IO.FileInfo = Nothing
                Dim FileName As String = ""
                Dim FileExtension As String = ""

                FileInfo = My.Computer.FileSystem.GetFileInfo(File)

                FileExtension = FileInfo.Extension
                FileName = FileInfo.Name.ToString().Replace(FileExtension, "")

                If Not FileName Is Nothing AndAlso Not FileExtension Is Nothing Then

                    FileName = FileName & DateGUID(True) & FileExtension

                Else

                    FileName = File

                End If

                Return FileName

            Catch ex As Exception

                Return File

            End Try
        End Function
        Public Function DateGUID(Optional ByVal IncludeSpacer As Boolean = True,
                                 Optional ByVal IncludeTime As Boolean = True,
                                 Optional ByVal IncludeSeconds As Boolean = True,
                                 Optional ByVal IncludeMilliseconds As Boolean = False) As String

            Try
                Dim sb As New System.Text.StringBuilder
                With sb

                    If IncludeSpacer = True Then

                        .Append("_")

                    End If

                    .Append(Now.Year.ToString())
                    .Append(Now.Month.ToString.PadLeft(2, "0"))
                    .Append(Now.Day.ToString().PadLeft(2, "0"))

                    If IncludeSpacer = True Then

                        .Append("_")

                    End If

                    If IncludeTime = True Then

                        .Append(Now.Hour.ToString().PadLeft(2, "0"))
                        .Append(Now.Minute.ToString().PadLeft(2, "0"))

                        If IncludeSeconds = True Then

                            .Append(Now.Second.ToString().PadLeft(2, "0"))

                        End If

                        If IncludeMilliseconds = True Then

                            If IncludeSpacer = True Then

                                .Append("_")

                            End If

                            .Append(Now.Millisecond.ToString().PadLeft(4))

                        End If

                    End If

                End With

                Return sb.ToString()

            Catch ex As Exception

                Return ""

            End Try

        End Function
        Public Function GetDefaultNonHostedDownloadLocation() As String

            'objects
            Dim DownloadLocation As String = ""
            Dim DirectoryInfo As System.IO.DirectoryInfo = Nothing

            If CheckDirectoryForReadWriteAccess(My.Application.Info.DirectoryPath) Then

                DownloadLocation = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "Downloads\"

                If My.Computer.FileSystem.DirectoryExists(DownloadLocation) = False Then

                    My.Computer.FileSystem.CreateDirectory(DownloadLocation)

                End If

                If My.Computer.FileSystem.DirectoryExists(DownloadLocation) = False OrElse CheckDirectoryForReadWriteAccess(My.Application.Info.DirectoryPath) = False Then

                    DownloadLocation = ""

                End If

            End If

            GetDefaultNonHostedDownloadLocation = DownloadLocation

        End Function
        Public Function CheckDirectoryForReadWriteAccess(Directory As String) As Boolean

            'objects
            Dim HasReadWriteAccess As Boolean = False
            Dim FileIOPermission As System.Security.Permissions.FileIOPermission = Nothing

            FileIOPermission = New System.Security.Permissions.FileIOPermission(System.Security.Permissions.FileIOPermissionAccess.Write Or System.Security.Permissions.FileIOPermissionAccess.Read, Directory)

            Try

                FileIOPermission.Demand()

                HasReadWriteAccess = True

            Catch ex As Exception
                HasReadWriteAccess = False
            End Try

            CheckDirectoryForReadWriteAccess = HasReadWriteAccess

        End Function
        Public Function MakeDOSFileDirectory(FilePath As String) As String

            'objects
            Dim DOSFilePathLastPart As String = String.Empty
            Dim Counter As Short = 0
            Dim DirectoryArray() As String = Nothing
            Dim DOSFilePath As String = String.Empty

            DirectoryArray = FilePath.Split("\")
            FilePath = ""

            For Counter = 0 To UBound(DirectoryArray)

                If DirectoryArray(Counter).Length > 8 Then

                    DOSFilePathLastPart = Left(DirectoryArray(Counter), 6) & "~1"

                Else

                    DOSFilePathLastPart = DirectoryArray(Counter)

                End If

                If FilePath <> "" Then

                    FilePath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(FilePath, "\") & DOSFilePathLastPart

                Else

                    FilePath = DOSFilePathLastPart

                End If

            Next Counter

            DOSFilePath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(FilePath, "\")

            MakeDOSFileDirectory = DOSFilePath

        End Function
        Public Function MakeDOSFilePath(FileName As String) As String

            'objects
            Dim DOSFilePathLastPart As String = String.Empty
            Dim Counter As Short = 0
            Dim DirectoryArray() As String = Nothing
            Dim FilePath As String = String.Empty
            Dim DOSFilePath As String = String.Empty

            FilePath = GetFilePath(FileName)
            DirectoryArray = FilePath.Split("\")
            FilePath = ""

            For Counter = 0 To UBound(DirectoryArray)

                If DirectoryArray(Counter).Length > 8 Then

                    DOSFilePathLastPart = Left(DirectoryArray(Counter), 6) & "~1"

                Else

                    DOSFilePathLastPart = DirectoryArray(Counter)

                End If

                If FilePath <> "" Then

                    FilePath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(FilePath, "\") & DOSFilePathLastPart

                Else

                    FilePath = DOSFilePathLastPart

                End If

            Next Counter

            DOSFilePath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(FilePath, "\") & FileName.Replace(GetFilePath(FileName), "").Replace("\", "")

            MakeDOSFilePath = DOSFilePath

        End Function
        Private Function GetFilePath(ByRef FileName As String) As String

            'objects
            Dim Index As Integer = 0
            Dim FilePath As String = ""

            For Index = FileName.Length To 1 Step -1

                Select Case Mid(FileName, Index, 1)

                    Case ":"
                        ' colons are always included in the result
                        FilePath = Left(FileName, Index)
                        Exit For

                    Case "\"
                        ' backslash aren't included in the result
                        FilePath = Left(FileName, Index - 1)
                        Exit For

                End Select

            Next

            GetFilePath = FilePath

        End Function

#End Region

    End Module

End Namespace

