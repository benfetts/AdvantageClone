Namespace DocumentManager

    <HideModuleName()>
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


        'https://support.office.com/en-us/article/Blocked-attachments-in-Outlook-434752e1-02d3-4e90-9124-8b81e49a8519
        Public Function BlackListedFileTypes() As Generic.List(Of String)

            Dim BlackList As New Generic.List(Of String)

            BlackList.Add(".ade")
            BlackList.Add(".adp")
            BlackList.Add(".app")
            BlackList.Add(".asp")
            BlackList.Add(".aspx")
            BlackList.Add(".asx")
            BlackList.Add(".bas")
            BlackList.Add(".bat")
            BlackList.Add(".cer")
            BlackList.Add(".chm")
            BlackList.Add(".cmd")
            BlackList.Add(".cnt")
            BlackList.Add(".com")
            BlackList.Add(".cpl")
            BlackList.Add(".csh")
            BlackList.Add(".der")
            BlackList.Add(".diagcab")
            BlackList.Add(".exe")
            BlackList.Add(".fxp")
            BlackList.Add(".gadget")
            BlackList.Add(".grp")
            BlackList.Add(".hlp")
            BlackList.Add(".hpj")
            BlackList.Add(".hta")
            BlackList.Add(".htc")
            BlackList.Add(".inf")
            BlackList.Add(".ins")
            BlackList.Add(".isp")
            BlackList.Add(".its")
            BlackList.Add(".jar")
            BlackList.Add(".jnlp")
            BlackList.Add(".js")
            BlackList.Add(".jse")
            BlackList.Add(".ksh")
            BlackList.Add(".lnk")
            BlackList.Add(".mad")
            BlackList.Add(".maf")
            BlackList.Add(".mag")
            BlackList.Add(".mam")
            BlackList.Add(".maq")
            BlackList.Add(".mar")
            BlackList.Add(".mas")
            BlackList.Add(".mat")
            BlackList.Add(".mau")
            BlackList.Add(".mav")
            BlackList.Add(".maw")
            BlackList.Add(".mcf")
            BlackList.Add(".mda")
            BlackList.Add(".mdb")
            BlackList.Add(".mde")
            BlackList.Add(".mdt")
            BlackList.Add(".mdw")
            BlackList.Add(".mdz")
            BlackList.Add(".msc")
            BlackList.Add(".msh")
            BlackList.Add(".msh1")
            BlackList.Add(".msh2")
            BlackList.Add(".mshxml")
            BlackList.Add(".msh1xml")
            BlackList.Add(".msh2xml")
            BlackList.Add(".msi")
            BlackList.Add(".msp")
            BlackList.Add(".mst")
            BlackList.Add(".msu")
            BlackList.Add(".ops")
            BlackList.Add(".osd")
            BlackList.Add(".pcd")
            BlackList.Add(".pif")
            BlackList.Add(".pl")
            BlackList.Add(".plg")
            BlackList.Add(".prf")
            BlackList.Add(".prg")
            BlackList.Add(".printerexport")
            BlackList.Add(".ps1")
            BlackList.Add(".ps1xml")
            BlackList.Add(".ps2")
            BlackList.Add(".ps2xml")
            BlackList.Add(".psc1")
            BlackList.Add(".psc2")
            BlackList.Add(".psd1")
            BlackList.Add(".psdm1")
            BlackList.Add(".pst")
            BlackList.Add(".py")
            BlackList.Add(".pyc")
            BlackList.Add(".pyo")
            BlackList.Add(".pyw")
            BlackList.Add(".pyz")
            BlackList.Add(".pyzw")
            BlackList.Add(".reg")
            BlackList.Add(".scf")
            BlackList.Add(".scr")
            BlackList.Add(".sct")
            BlackList.Add(".shb")
            BlackList.Add(".shs")
            BlackList.Add(".theme")
            BlackList.Add(".tmp")
            BlackList.Add(".url")
            BlackList.Add(".vb")
            BlackList.Add(".vbe")
            BlackList.Add(".fbp")
            BlackList.Add(".vbs")
            BlackList.Add(".vhd")
            BlackList.Add(".vhdx")
            BlackList.Add(".vsmacros")
            BlackList.Add(".vsw")
            BlackList.Add(".webpnp")
            BlackList.Add(".website")
            BlackList.Add(".ws")
            BlackList.Add(".wsc")
            BlackList.Add(".wsf")
            BlackList.Add(".wsh")
            BlackList.Add(".xbap")
            BlackList.Add(".xll")
            BlackList.Add(".xnk")

            Return BlackList

        End Function
        Public Function CopyDocument(DbContext As AdvantageFramework.Database.DbContext, CopyDocumentID As Integer, ByRef NewDocumentID As Integer) As Boolean

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim DocumentToCopy As AdvantageFramework.Database.Entities.Document = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim ByteFile() As Byte = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim FileSystemFile As String = Nothing
            Dim FileSystemFileName As String = Nothing
            Dim Copied As Boolean = False

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            DocumentToCopy = DbContext.Documents.Find(CopyDocumentID)

            If DocumentToCopy IsNot Nothing Then

                Document = DocumentToCopy.DuplicateEntity

                Document.ID = 0
                Document.UploadedDate = Now
                Document.UserCode = DbContext.UserCode

                If DocumentToCopy.MIMEType <> "URL" Then

                    If AdvantageFramework.FileSystem.Download(Agency, Document, ByteFile) Then

                        MemoryStream = New IO.MemoryStream(ByteFile)

                        If AdvantageFramework.FileSystem.Add(DbContext, Agency, MemoryStream, Document.FileName, Document.Description, Document.Keywords, DbContext.UserCode, "", "", FileSystem.DocumentSource.DocumentUpload, FileSystemFile, FileSystemFileName) Then

                            Document.FileSystemFileName = FileSystemFileName

                        End If

                    End If

                End If

                If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then

                    NewDocumentID = Document.ID

                    Copied = True

                End If

            End If

            CopyDocument = Copied

        End Function

#Region " Add "

        Public Function AddAlertAttachment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal DocumentID As Integer) As Boolean

            Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing

            AlertAttachment = New AdvantageFramework.Database.Entities.AlertAttachment

            AlertAttachment.AlertID = AlertID
            AlertAttachment.DocumentID = DocumentID
            AlertAttachment.GeneratedDate = Date.Now
            AlertAttachment.UserCode = DbContext.UserCode
            AlertAttachment.HasEmailBeenSent = False

            Return AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, AlertAttachment)


        End Function
        Public Function AddOfficeDocument(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal OfficeCode As String,
                                          ByVal DocumentID As Integer) As Boolean

            Dim Document As AdvantageFramework.Database.Entities.OfficeDocument = Nothing

            Document = New Database.Entities.OfficeDocument

            Document.OfficeCode = OfficeCode
            Document.DocumentID = DocumentID

            Return AdvantageFramework.Database.Procedures.OfficeDocument.Insert(DbContext, Document)

        End Function
        Public Function AddClientDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ClientCode As String, ByVal DocumentID As Integer) As Boolean

            Dim Document As AdvantageFramework.Database.Entities.ClientDocument = Nothing

            Document = New Database.Entities.ClientDocument

            Document.ClientCode = ClientCode
            Document.DocumentID = DocumentID

            Return AdvantageFramework.Database.Procedures.ClientDocument.Insert(DataContext, Document)

        End Function
        Public Function AddDivisionDocument(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                            ByVal ClientCode As String, ByVal DivisionCode As String,
                                            ByVal DocumentID As Integer) As Boolean

            Dim Document As AdvantageFramework.Database.Entities.DivisionDocument = Nothing

            Document = New Database.Entities.DivisionDocument

            Document.ClientCode = ClientCode
            Document.DivisionCode = DivisionCode
            Document.DocumentID = DocumentID

            Return AdvantageFramework.Database.Procedures.DivisionDocument.Insert(DataContext, Document)

        End Function
        Public Function AddProductDocument(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                           ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String,
                                           ByVal DocumentID As Integer) As Boolean

            Dim Document As AdvantageFramework.Database.Entities.ProductDocument = Nothing

            Document = New Database.Entities.ProductDocument

            Document.ClientCode = ClientCode
            Document.DivisionCode = DivisionCode
            Document.ProductCode = ProductCode
            Document.DocumentID = DocumentID

            Return AdvantageFramework.Database.Procedures.ProductDocument.Insert(DataContext, Document)

        End Function
        Public Function AddJobDocument(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                       ByVal JobNumber As Integer,
                                       ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Document As AdvantageFramework.Database.Entities.JobDocument = Nothing

            Document = New Database.Entities.JobDocument

            Document.JobNumber = JobNumber
            Document.DocumentID = DocumentID

            Return AdvantageFramework.Database.Procedures.JobDocument.Insert(DataContext, Document)

        End Function
        Public Function AddJobComponentDocument(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                                ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Document As AdvantageFramework.Database.Entities.JobComponentDocument = Nothing

            Document = New Database.Entities.JobComponentDocument

            Document.JobNumber = JobNumber
            Document.JobComponentNumber = JobComponentNumber
            Document.DocumentID = DocumentID

            Return AdvantageFramework.Database.Procedures.JobComponentDocument.Insert(DataContext, Document)

        End Function
        Public Function AddTaskDocument(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                        ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TaskSequenceNumber As Short,
                                        ByVal DocumentID As Integer) As Boolean

            Dim Document As AdvantageFramework.Database.Entities.JobComponentTaskDocument = Nothing

            Document = New Database.Entities.JobComponentTaskDocument

            Document.JobNumber = JobNumber
            Document.JobComponentNumber = JobComponentNumber
            Document.SequenceNumber = TaskSequenceNumber
            Document.DocumentID = DocumentID

            Return AdvantageFramework.Database.Procedures.JobComponentTaskDocument.Insert(DataContext, Document)

        End Function
        Public Function AddCampaignDocument(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                            ByVal CampaignID As Integer,
                                            ByVal DocumentID As Integer) As Boolean

            Dim Document As AdvantageFramework.Database.Entities.CampaignDocument = Nothing

            Document = New Database.Entities.CampaignDocument

            Document.CampaignID = CampaignID
            Document.DocumentID = DocumentID

            Return AdvantageFramework.Database.Procedures.CampaignDocument.Insert(DataContext, Document)

        End Function
        Public Function AddEmployeeDocument(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                            ByVal EmployeeCode As String,
                                            ByVal DocumentID As Integer) As Boolean

            Dim Document As AdvantageFramework.Database.Entities.EmployeeDocument = Nothing

            Document = New Database.Entities.EmployeeDocument

            Document.EmployeeCode = EmployeeCode
            Document.DocumentID = DocumentID

            Return AdvantageFramework.Database.Procedures.EmployeeDocument.Insert(DataContext, Document)

        End Function

        Public Sub DeleteAttachmentRecordsForDocument(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer)

            Try

                'For Each DocumentAlertAttachment In AdvantageFramework.Database.Procedures.AlertAttachment.LoadByDocumentID(DbContext, DocumentID)

                '    AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, DocumentAlertAttachment)

                'Next
                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM ALERT_ATTACHMENT WITH(ROWLOCK) WHERE DOCUMENT_ID = {0};", DocumentID))

            Catch ex As Exception
            End Try

        End Sub

#End Region

        Private Function ResizeAbort() As Boolean

            Return False

        End Function

        Public Function UpdateDocumentThumbnail(ByRef DbContext As AdvantageFramework.Database.DbContext, ByRef Agency As AdvantageFramework.Database.Entities.Agency,
                                                ByVal DocumentID As Integer, ByRef ByteImage As Byte()) As Boolean

            Dim ThumbnailUpdated As Boolean = False

            If DbContext IsNot Nothing Then

                Dim Document As AdvantageFramework.Database.Entities.Document

                Document = Nothing
                Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                If Document IsNot Nothing AndAlso Document.Thumbnail Is Nothing Then

                    ThumbnailUpdated = UpdateDocumentThumbnailByDocument(DbContext, Agency, Document, ByteImage)

                End If

            End If

            Return ThumbnailUpdated

        End Function
        Public Function UpdateDocumentThumbnailByDocument(ByRef DbContext As AdvantageFramework.Database.DbContext, ByRef Agency As AdvantageFramework.Database.Entities.Agency,
                                                          ByRef Document As AdvantageFramework.Database.Entities.Document, ByRef ByteImage As Byte()) As Boolean

            Dim ThumbnailUpdated As Boolean = False

            Try

                If DbContext IsNot Nothing AndAlso Agency IsNot Nothing Then

                    If Document IsNot Nothing Then

                        AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain,
                                                                                   AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                        Dim FileSystemFile As String = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\") & Document.FileSystemFileName
                        Dim OriginalImage As System.Drawing.Image = Nothing
                        Dim MemoryStream As System.IO.MemoryStream = Nothing

                        If ByteImage IsNot Nothing AndAlso ByteImage.Length > 0 Then

                            MemoryStream = New IO.MemoryStream(ByteImage)
                            OriginalImage = System.Drawing.Image.FromStream(MemoryStream)

                            MemoryStream.Close()

                        Else

                            If System.IO.File.Exists(FileSystemFile) = False Then

                                FileSystemFile = FileSystemFile & "." & AdvantageFramework.StringUtilities.ParseLastDot(Document.FileName)

                            End If
                            If System.IO.File.Exists(FileSystemFile) Then

                                OriginalImage = System.Drawing.Image.FromFile(FileSystemFile)

                            End If

                        End If

                        If OriginalImage IsNot Nothing Then

                            Dim X As Integer = OriginalImage.Width
                            Dim Y As Integer = OriginalImage.Height
                            Dim Width As Integer = 100
                            Dim Height As Integer = CInt((Width * Y) / X)
                            Dim DummyCallBack As New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ResizeAbort)
                            Dim ThumbnailImage As System.Drawing.Image = OriginalImage.GetThumbnailImage(Width, Height, DummyCallBack, IntPtr.Zero)
                            Dim ThumbnailStream As New IO.MemoryStream
                            Dim ThumbnailBytes As Byte() = Nothing

                            If ThumbnailImage IsNot Nothing Then

                                If Document.FileName.ToLower.EndsWith("png") Then

                                    ThumbnailImage.Save(ThumbnailStream, System.Drawing.Imaging.ImageFormat.Png)

                                ElseIf Document.FileName.ToLower.EndsWith("bmp") Then

                                    ThumbnailImage.Save(ThumbnailStream, System.Drawing.Imaging.ImageFormat.Bmp)

                                ElseIf Document.FileName.ToLower.EndsWith("tiff") Then

                                    ThumbnailImage.Save(ThumbnailStream, System.Drawing.Imaging.ImageFormat.Tiff)

                                ElseIf Document.FileName.ToLower.EndsWith("gif") Then

                                    ThumbnailImage.Save(ThumbnailStream, System.Drawing.Imaging.ImageFormat.Gif)

                                Else

                                    ThumbnailImage.Save(ThumbnailStream, System.Drawing.Imaging.ImageFormat.Jpeg)

                                End If

                                ThumbnailBytes = ThumbnailStream.ToArray()

                                If ThumbnailBytes IsNot Nothing AndAlso ThumbnailBytes.Length > 0 Then

                                    Document.Thumbnail = ThumbnailBytes
                                    ThumbnailUpdated = AdvantageFramework.Database.Procedures.Document.Update(DbContext, Document)

                                End If

                            End If

                            OriginalImage.Dispose()
                            ThumbnailStream.Close()

                        End If

                        AdvantageFramework.Security.Impersonate.EndImpersonation()

                    End If

                End If

            Catch ex As Exception
                ThumbnailUpdated = False
            End Try

            Return ThumbnailUpdated

        End Function
        Public Function ImageToThumnbnailBytes(ByVal OriginalImageBytes As Byte(), ByVal FileName As String) As Byte()

            Dim OriginalImage As System.Drawing.Image = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim ThumbnailBytes As Byte() = Nothing

            If OriginalImageBytes IsNot Nothing AndAlso OriginalImageBytes.Length > 0 Then

                MemoryStream = New IO.MemoryStream(OriginalImageBytes)
                OriginalImage = System.Drawing.Image.FromStream(MemoryStream)

                If OriginalImage IsNot Nothing Then

                    Dim X As Integer = OriginalImage.Width
                    Dim Y As Integer = OriginalImage.Height
                    Dim Width As Integer = 100
                    Dim Height As Integer = CInt((Width * Y) / X)
                    Dim DummyCallBack As New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ResizeAbort)
                    Dim ThumbnailImage As System.Drawing.Image = OriginalImage.GetThumbnailImage(Width, Height, DummyCallBack, IntPtr.Zero)
                    Dim ThumbnailStream As New IO.MemoryStream

                    If ThumbnailImage IsNot Nothing Then

                        If FileName.ToLower.EndsWith("png") Then

                            ThumbnailImage.Save(ThumbnailStream, System.Drawing.Imaging.ImageFormat.Png)

                        ElseIf FileName.ToLower.EndsWith("bmp") Then

                            ThumbnailImage.Save(ThumbnailStream, System.Drawing.Imaging.ImageFormat.Bmp)

                        ElseIf FileName.ToLower.EndsWith("tiff") Then

                            ThumbnailImage.Save(ThumbnailStream, System.Drawing.Imaging.ImageFormat.Tiff)

                        ElseIf FileName.ToLower.EndsWith("gif") Then

                            ThumbnailImage.Save(ThumbnailStream, System.Drawing.Imaging.ImageFormat.Gif)

                        Else

                            ThumbnailImage.Save(ThumbnailStream, System.Drawing.Imaging.ImageFormat.Jpeg)

                        End If

                        ThumbnailBytes = ThumbnailStream.ToArray()

                    End If

                End If

            End If

            Return ThumbnailBytes

        End Function
        Public Sub FixEmployeeThumbnails(ByRef DbContext As AdvantageFramework.Database.DbContext)

            Dim EmployeePictures As Generic.List(Of AdvantageFramework.Database.Entities.EmployeePicture) = Nothing

            EmployeePictures = AdvantageFramework.Database.Procedures.EmployeePicture.Load(DbContext).ToList

            If EmployeePictures IsNot Nothing Then

                For Each EmpPic As AdvantageFramework.Database.Entities.EmployeePicture In EmployeePictures

                    If EmpPic.Image.Length > 0 Then

                        EmpPic.Image = ResizeByteArray(DbContext, "", EmpPic.Image)
                        AdvantageFramework.Database.Procedures.EmployeePicture.Update(DbContext, EmpPic)

                    End If

                Next

            End If

        End Sub

        Public Function ResizeByteArray(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal FileName As String,
                                        ByVal ByteImage As Byte()) As Byte()

            Dim OriginalImage As System.Drawing.Image = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            MemoryStream = New IO.MemoryStream(ByteImage)
            OriginalImage = System.Drawing.Image.FromStream(MemoryStream)

            If OriginalImage IsNot Nothing Then

                Dim X As Integer = OriginalImage.Width
                Dim Y As Integer = OriginalImage.Height
                Dim Width As Integer = 100
                Dim Height As Integer = CInt((Width * Y) / X)
                Dim DummyCallBack As New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ResizeAbort)
                Dim ThumbnailImage As System.Drawing.Image = OriginalImage.GetThumbnailImage(Width, Height, DummyCallBack, IntPtr.Zero)

                If ThumbnailImage IsNot Nothing Then

                    If MemoryStream Is Nothing Then

                        MemoryStream = New IO.MemoryStream

                    End If

                    If (FileName.ToLower.EndsWith("jpeg") OrElse FileName.ToLower.EndsWith("jpg")) Then

                        ThumbnailImage.Save(MemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg)

                    ElseIf FileName.ToLower.EndsWith("png") Then

                        ThumbnailImage.Save(MemoryStream, System.Drawing.Imaging.ImageFormat.Png)

                    ElseIf FileName.ToLower.EndsWith("bmp") Then

                        ThumbnailImage.Save(MemoryStream, System.Drawing.Imaging.ImageFormat.Bmp)

                    ElseIf FileName.ToLower.EndsWith("tiff") Then

                        ThumbnailImage.Save(MemoryStream, System.Drawing.Imaging.ImageFormat.Tiff)

                    ElseIf FileName.ToLower.EndsWith("gif") Then

                        ThumbnailImage.Save(MemoryStream, System.Drawing.Imaging.ImageFormat.Gif)

                    Else

                        ThumbnailImage.Save(MemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg)

                    End If

                    If MemoryStream IsNot Nothing Then

                        ByteImage = MemoryStream.ToArray()

                    End If

                End If

                ThumbnailImage = Nothing

            End If

            MemoryStream = Nothing
            OriginalImage = Nothing

            Return ByteImage

        End Function

        Public Sub CreateZip(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document), ByRef ZipFile As Ionic.Zip.ZipFile)

            'Objects
            Dim FileStream As System.IO.FileStream = Nothing
            Dim BinaryReader As System.IO.BinaryReader
            Dim ByteFile() As Byte = Nothing
            Dim FileSystemFile As String = Nothing
            Dim SaveAsFileName As String = Nothing
            Dim FileExtension As String = ""
            Dim Counter As Integer = 0
            Dim Links As String = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

            Try

                If Agency IsNot Nothing Then

                    AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                    For Each Document In Documents.OrderBy(Function(Doc) Doc.FileName).ThenByDescending(Function(Doc) Doc.UploadedDate)

                        Try

                            If Document.FileType <> FileSystem.FileTypes.URL Then

                                FileSystemFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\") & Document.FileSystemFileName

                                If System.IO.File.Exists(FileSystemFile) Then

                                    FileStream = New System.IO.FileStream(FileSystemFile, IO.FileMode.OpenOrCreate)
                                    BinaryReader = New System.IO.BinaryReader(FileStream)
                                    ByteFile = BinaryReader.ReadBytes(New System.IO.FileInfo(FileSystemFile).Length)

                                    FileStream.Read(ByteFile, 0, FileStream.Length)
                                    FileStream.Close()

                                    If (From Doc In Documents
                                        Where Doc.ID <> Document.ID AndAlso
                                              Doc.FileName = Document.FileName
                                        Select Doc).Any Then

                                        FileExtension = New System.IO.FileInfo(Document.FileName).Extension

                                        SaveAsFileName = Document.FileName.Replace(FileExtension, "") & "(" & Counter & ")" & FileExtension

                                        Counter = Counter + 1

                                    Else

                                        SaveAsFileName = Document.FileName

                                        Counter = 0

                                    End If

                                    ZipFile.AddEntry(SaveAsFileName, ByteFile)

                                End If

                            Else

                                Links &= Document.Description & vbTab & "[" & Document.FileSystemFileName & "]" & vbNewLine

                            End If

                        Catch ex As Exception

                        End Try

                    Next

                    If String.IsNullOrEmpty(Links) = False Then

                        ZipFile.AddEntry("Links.txt", Links)

                    End If

                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Sub CreateZipPackage(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document), ByRef ZipFile As Ionic.Zip.ZipFile)

            'Objects
            Dim FileStream As System.IO.FileStream = Nothing
            Dim BinaryReader As System.IO.BinaryReader
            Dim ByteFile() As Byte = Nothing
            Dim FileSystemFile As String = Nothing
            Dim SaveAsFileName As String = Nothing
            Dim FileExtension As String = ""
            Dim Counter As Integer = 0
            Dim Links As String = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim DocumentIndex As Integer = 0
            Dim SaveToLocation As String = Nothing

            Try

                If Agency IsNot Nothing Then

                    AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                    For Each Document In Documents

                        Try

                            If Document.FileType <> FileSystem.FileTypes.URL Then

                                DocumentIndex = DocumentIndex + 1

                                FileSystemFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\") & Document.FileSystemFileName

                                If System.IO.File.Exists(FileSystemFile) Then

                                    FileStream = New System.IO.FileStream(FileSystemFile, IO.FileMode.OpenOrCreate)
                                    BinaryReader = New System.IO.BinaryReader(FileStream)
                                    ByteFile = BinaryReader.ReadBytes(New System.IO.FileInfo(FileSystemFile).Length)

                                    FileStream.Read(ByteFile, 0, FileStream.Length)
                                    FileStream.Close()

                                    If (From Doc In Documents
                                        Where Doc.ID <> Document.ID AndAlso
                                              Doc.FileName.ToUpper = Document.FileName.ToUpper
                                        Select Doc).Any Then

                                        FileExtension = New System.IO.FileInfo(Document.FileName).Extension

                                        SaveAsFileName = DocumentIndex.ToString & "-" & Document.FileName.Replace(FileExtension, "") & "(" & Counter & ")" & FileExtension

                                        Counter = Counter + 1

                                    Else

                                        SaveAsFileName = DocumentIndex.ToString & "-" & Document.FileName

                                        Counter = 0

                                    End If

                                    ZipFile.AddEntry(SaveAsFileName, ByteFile)

                                End If

                            Else

                                Links &= Document.Description & vbTab & "[" & Document.FileSystemFileName & "]" & vbNewLine

                            End If

                        Catch ex As Exception

                        End Try

                    Next

                    If String.IsNullOrEmpty(Links) = False Then

                        ZipFile.AddEntry("Links.txt", Links)

                    End If

                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Sub CreateZipPackage(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document), DocumentIndex As Integer, ByRef ZipFile As Ionic.Zip.ZipFile)

            'Objects
            Dim FileStream As System.IO.FileStream = Nothing
            Dim BinaryReader As System.IO.BinaryReader
            Dim ByteFile() As Byte = Nothing
            Dim FileSystemFile As String = Nothing
            Dim SaveAsFileName As String = Nothing
            Dim FileExtension As String = ""
            Dim Counter As Integer = 0
            Dim Links As String = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim SaveToLocation As String = Nothing

            Try

                If Agency IsNot Nothing Then

                    AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                    For Each Document In Documents

                        Try

                            If Document.FileType <> FileSystem.FileTypes.URL Then

                                DocumentIndex = DocumentIndex + 1

                                FileSystemFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\") & Document.FileSystemFileName

                                If System.IO.File.Exists(FileSystemFile) Then

                                    FileStream = New System.IO.FileStream(FileSystemFile, IO.FileMode.OpenOrCreate)
                                    BinaryReader = New System.IO.BinaryReader(FileStream)
                                    ByteFile = BinaryReader.ReadBytes(New System.IO.FileInfo(FileSystemFile).Length)

                                    FileStream.Read(ByteFile, 0, FileStream.Length)
                                    FileStream.Close()

                                    If (From Doc In Documents
                                        Where Doc.ID <> Document.ID AndAlso
                                              Doc.FileName.ToUpper = Document.FileName.ToUpper
                                        Select Doc).Any Then

                                        FileExtension = New System.IO.FileInfo(Document.FileName).Extension

                                        SaveAsFileName = DocumentIndex.ToString & "-" & Document.FileName.Replace(FileExtension, "") & "(" & Counter & ")" & FileExtension

                                        Counter = Counter + 1

                                    Else

                                        SaveAsFileName = DocumentIndex.ToString & "-" & Document.FileName

                                        Counter = 0

                                    End If

                                    ZipFile.AddEntry(SaveAsFileName, ByteFile)

                                End If

                            Else

                                Links &= Document.Description & vbTab & "[" & Document.FileSystemFileName & "]" & vbNewLine

                            End If

                        Catch ex As Exception

                        End Try

                    Next

                    If String.IsNullOrEmpty(Links) = False Then

                        ZipFile.AddEntry("Links.txt", Links)

                    End If

                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                End If

            Catch ex As Exception

            End Try

        End Sub

        Public Sub AddToAttachments(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document), ByRef Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment))

            'Objects
            Dim FileStream As System.IO.FileStream = Nothing
            Dim BinaryReader As System.IO.BinaryReader
            Dim ByteFile() As Byte = Nothing
            Dim FileSystemFile As String = Nothing
            Dim SaveAsFileName As String = Nothing
            Dim FileExtension As String = ""
            Dim Counter As Integer = 0
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim DocumentIndex As Integer = 0
            Dim SaveToLocation As String = Nothing

            Try

                If Agency IsNot Nothing Then

                    AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                    For Each Document In Documents

                        Try

                            If Document.FileType <> FileSystem.FileTypes.URL Then

                                DocumentIndex = DocumentIndex + 1

                                FileSystemFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\") & Document.FileSystemFileName

                                If System.IO.File.Exists(FileSystemFile) Then

                                    FileStream = New System.IO.FileStream(FileSystemFile, IO.FileMode.OpenOrCreate)
                                    BinaryReader = New System.IO.BinaryReader(FileStream)
                                    ByteFile = BinaryReader.ReadBytes(New System.IO.FileInfo(FileSystemFile).Length)

                                    FileStream.Read(ByteFile, 0, FileStream.Length)
                                    FileStream.Close()

                                    If (From Doc In Documents
                                        Where Doc.ID <> Document.ID AndAlso
                                              Doc.FileName.ToUpper = Document.FileName.ToUpper
                                        Select Doc).Any Then

                                        FileExtension = New System.IO.FileInfo(Document.FileName).Extension

                                        SaveAsFileName = DocumentIndex.ToString & "-" & Document.FileName.Replace(FileExtension, "") & "(" & Counter & ")" & FileExtension

                                        Counter = Counter + 1

                                    Else

                                        SaveAsFileName = DocumentIndex.ToString & "-" & Document.FileName

                                        Counter = 0

                                    End If

                                    Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(SaveAsFileName, ByteFile))

                                End If

                            End If

                        Catch ex As Exception

                        End Try

                    Next

                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                End If

            Catch ex As Exception

            End Try

        End Sub

        Public Function LoadRelatedDocuments(ByVal Session As AdvantageFramework.Security.Session, ByVal DocumentID As Integer, ByVal FileName As String, ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim Documents As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    Select Case DocumentLevel

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Office

                            Documents = LoadRelatedOfficeDocuments(DbContext, DocumentID, FileName)

                        Case Database.Entities.DocumentLevel.Client

                            Documents = LoadRelatedClientDocuments(DbContext, DataContext, DocumentID, FileName)

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Division

                            Documents = LoadRelatedDivisionDocuments(DbContext, DataContext, DocumentID, FileName)

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Product

                            Documents = LoadRelatedProductDocuments(DbContext, DataContext, DocumentID, FileName)

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Campaign

                            Documents = LoadRelatedCampaignDocuments(DbContext, DataContext, DocumentID, FileName)

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Job

                            Documents = LoadRelatedJobDocuments(DbContext, DataContext, DocumentID, FileName)

                        Case AdvantageFramework.Database.Entities.DocumentLevel.JobComponent

                            Documents = LoadRelatedJobComponentDocuments(DbContext, DataContext, DocumentID, FileName)

                        Case AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice

                            Documents = LoadRelatedAccountPayableDocuments(DbContext, DataContext, DocumentID, FileName)

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Employee

                            Documents = LoadRelatedEmployeeDocuments(DbContext, DataContext, DocumentID, FileName)

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Vendor

                            Documents = LoadRelatedVendorDocuments(DbContext, DataContext, DocumentID, FileName)

                        Case AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts

                            Documents = LoadRelatedExpenseDocuments(DbContext, DataContext, DocumentID, FileName)

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Contract

                            Documents = LoadRelatedContractDocuments(DbContext, DocumentID, FileName)

                        Case AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice

                            Documents = LoadRelatedAccountReceivableInvoiceDocuments(DbContext, DocumentID, FileName)

                        Case AdvantageFramework.Database.Entities.DocumentLevel.ContractReport

                            Documents = LoadRelatedContractReportDocuments(DbContext, DataContext, DocumentID, FileName)

                        Case AdvantageFramework.Database.Entities.Methods.DocumentLevel.AgencyDesktop

                            Documents = LoadRelatedAgencyDesktopDocuments(DbContext, DataContext, DocumentID, FileName)

                        Case AdvantageFramework.Database.Entities.Methods.DocumentLevel.ExecutiveDesktop

                            Documents = LoadRelatedExecutiveDesktopDocuments(DbContext, DataContext, DocumentID, FileName)

                        Case Else

                            Documents = Nothing

                    End Select

                End Using

            End Using

            LoadRelatedDocuments = Documents

        End Function
        Public Function SignDocument(DbContext As AdvantageFramework.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext, SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                     UserID As Integer, Agency As AdvantageFramework.Database.Entities.Agency,
                                     AuthorizedByName As String, DocumentID As Integer, MediaFrom As String, Email As String, PhysicalApplicationPath As String,
                                     Optional OrderNumber As Nullable(Of Integer) = Nothing, Optional AlertID As Nullable(Of Integer) = Nothing, Optional VendorCode As String = Nothing, Optional VendorRepCode As String = Nothing) As Boolean

            'objects
            Dim DocumentSigned As Boolean = False
            Dim Folder As String = ""
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim PKCS7 As Aspose.Pdf.InteractiveFeatures.Forms.PKCS7 = Nothing
            Dim Signature As Aspose.Pdf.InteractiveFeatures.Forms.Signature = Nothing
            Dim License As Aspose.Pdf.License = Nothing
            Dim HasBlankSignature As Boolean = False
            Dim DocMDPSignature As Aspose.Pdf.InteractiveFeatures.Forms.DocMDPSignature = Nothing
            Dim SignatureFileMemoryStream As System.IO.MemoryStream = Nothing

            Try

                Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                If Document IsNot Nothing Then

                    If Agency.FileSystemUserName IsNot Nothing AndAlso Agency.FileSystemUserName <> "" Then

                        AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                    End If

                    Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\")

                    If Document.FileName.ToUpper.Contains(".PDF") Then

                        License = New Aspose.Pdf.License

                        License.SetLicense("Aspose.Total.lic")
                        License.Embedded = True

                        Using PDFDocument = New Aspose.Pdf.Document(Folder & Document.FileSystemFileName)

                            Using PdfFileSignature = New Aspose.Pdf.Facades.PdfFileSignature(PDFDocument)

                                PKCS7 = New Aspose.Pdf.InteractiveFeatures.Forms.PKCS7(AdvantageFramework.StringUtilities.AppendTrailingCharacter(PhysicalApplicationPath, "\") & "AdvantagePDFSign.pfx", "APDFSAPDFS")
                                PKCS7.Reason = "Advantage Digital Sign"

                                DocMDPSignature = New Aspose.Pdf.InteractiveFeatures.Forms.DocMDPSignature(PKCS7, Aspose.Pdf.InteractiveFeatures.Forms.DocMDPAccessPermissions.FillingInForms)

                                For Each SignatureName In PdfFileSignature.GetBlankSignNames.OfType(Of String).ToList

                                    PdfFileSignature.Sign(SignatureName, PKCS7)
                                    HasBlankSignature = True

                                Next

                                If HasBlankSignature = False Then

                                    If PDFDocument.PageInfo.IsLandscape OrElse MediaFrom.Substring(0, 1) = "R" OrElse MediaFrom.Substring(0, 1) = "T" Then

                                        PdfFileSignature.Sign(1, AuthorizedByName, AuthorizedByName, "", True, New System.Drawing.Rectangle(400, 450, 300, 100), PKCS7)

                                    Else

                                        PdfFileSignature.Sign(1, AuthorizedByName, AuthorizedByName, "", True, New System.Drawing.Rectangle(300, 650, 300, 100), PKCS7)

                                    End If

                                End If

                                PdfFileSignature.Save(Folder & Document.FileSystemFileName)

                                Document.FileSize = AdvantageFramework.FileSystem.GetFileSize(Folder & Document.FileSystemFileName)

                                DocumentSigned = AdvantageFramework.Database.Procedures.Document.Update(DbContext, Document)

                                If DocumentSigned Then

                                    If OrderNumber.HasValue AndAlso AlertID.HasValue Then

                                        EmailSignedCopy(DbContext, DataContext, SecurityDbContext, UserID, Email, Document.FileName, Folder & Document.FileSystemFileName, Agency, OrderNumber.Value, AlertID.Value, VendorCode, VendorRepCode)

                                    Else

                                        EmailSignedCopy(DbContext, DataContext, SecurityDbContext, UserID, Email, Document.FileName, Folder & Document.FileSystemFileName)

                                    End If

                                End If

                            End Using

                        End Using

                        If PKCS7 IsNot Nothing Then

                            PKCS7 = Nothing

                        End If

                        If License IsNot Nothing Then

                            License = Nothing

                        End If

                    End If

                    If Agency.FileSystemUserName IsNot Nothing AndAlso Agency.FileSystemUserName <> "" Then

                        AdvantageFramework.Security.Impersonate.EndImpersonation()

                    End If

                End If

            Catch ex As Exception
                DocumentSigned = False

                If ex IsNot Nothing Then

                    AdvantageFramework.Security.AddWebvantageEventLog(ex.Message, Diagnostics.EventLogEntryType.Error)

                    If ex.InnerException IsNot Nothing Then

                        AdvantageFramework.Security.AddWebvantageEventLog(ex.InnerException.Message, Diagnostics.EventLogEntryType.Error)

                    End If

                End If

            End Try

            SignDocument = DocumentSigned

        End Function
        Private Sub EmailSignedCopy(DbContext As AdvantageFramework.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext, SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                    UserID As Integer, Email As String, AttachmentName As String, File As String)

            'objects
            Dim HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing

            If AdvantageFramework.MediaManager.LoadDefaultEmailExecutedCopyToVendor(SecurityDbContext, UserID) Then

                HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                HtmlEmail.AddHeaderRow("Message")

                HtmlEmail.AddCustomRow("The approved order has been received and the final executed copy is attached.")

                Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)
                Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(AttachmentName, File))

                HtmlEmail.Finish()

                AdvantageFramework.Email.Send(DbContext, Email, "", "", "Signed Order Attached", HtmlEmail.ToString, 3, Attachments, SendingEmailStatus)

            End If

        End Sub
        Private Sub EmailSignedCopy(DbContext As AdvantageFramework.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext, SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                    UserID As Integer, Email As String, AttachmentName As String, File As String, Agency As AdvantageFramework.Database.Entities.Agency, OrderNumber As Integer, AlertID As Integer,
                                    VendorCodeIn As String, VendorRepCode As String)

            'objects
            Dim HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim VendorReps As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep) = Nothing

            If AdvantageFramework.MediaManager.LoadDefaultEmailExecutedCopyToVendor(SecurityDbContext, UserID) Then

                HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                HtmlEmail.AddCustomRow("<a href=""" & AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.WebvantageURL, "/") & "Media/MakegoodDelivery/MakegoodOutstandingForm?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & DbContext.Database.Connection.Database & "&VendorCode=" & VendorCodeIn & "&VendorRepCode=" & VendorRepCode) & "%7C"" > Click Here</a> to review open orders and take various actions.")

                HtmlEmail.AddHeaderRow("Message")

                HtmlEmail.AddCustomRow("The approved order has been received and the final executed copy is attached.")

                HtmlEmail.AddCustomRow(AdvantageFramework.Email.Classes.HtmlEmail.AppendListenerAlertIDToBody(AlertID, False))

                AdvantageFramework.AlertSystem.CommentsHistory(DbContext, False, AlertID, Agency, HtmlEmail)

                Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)
                Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(AttachmentName, File))

                If (From Entity In AdvantageFramework.Database.Procedures.BroadcastImportCrossReference.Load(DbContext)
                    Where Entity.OrderNumber = OrderNumber AndAlso
                          Entity.ImportedFrom = "AW").Any Then

                    TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, OrderNumber)

                    If TVOrder IsNot Nothing Then

                        VendorReps = New Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep)

                        For Each VR In (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportSentInfo.LoadByOrderNumber(DbContext, OrderNumber)
                                        Select Entity.VendorCode, Entity.VendorRepresentativeCode).Distinct.ToList

                            VendorReps.Add(New AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep(VR.VendorCode, VR.VendorRepresentativeCode))

                        Next

                        Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Advantage, DbContext.ConnectionString, DbContext.UserCode, 0, DbContext.ConnectionString)

                        If (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket")
                            Where Entity.OrderNumber = OrderNumber
                            Select Entity).FirstOrDefault.MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.IsCable Then

                            Try

                                Attachments.Add(New Email.Classes.Attachment("Order.scx", AdvantageFramework.Media.BuildXMLFile(Session, DbContext, DataContext, OrderNumber, VendorReps, VendorReps.First.VendorCode).ToArray))

                            Catch ex As Exception

                            End Try

                        Else

                            Try

                                Attachments.Add(New Email.Classes.Attachment("Order.xml", AdvantageFramework.Media.BuildBroadcastXMLFile(Session, DbContext, DataContext, OrderNumber, "TV", VendorReps).ToArray))

                            Catch ex As Exception

                            End Try

                        End If

                    End If

                End If

                HtmlEmail.Finish()

                AdvantageFramework.Email.Send(DbContext, Email, "", "", "Signed Order #" & OrderNumber.ToString & " Attached - Approved Order Received and Fully Executed", HtmlEmail.ToString, 3, Attachments, SendingEmailStatus)

            End If

        End Sub

#Region "  Document Levels "

#Region "  Client Documents "

        Public Function LoadClientDocuments(ByVal Session As AdvantageFramework.Security.Session,
                                             ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting),
                                             ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim ClientDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ClientDocument) = Nothing
            Dim DocumentIDs() As Long = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim ClientCodes As IEnumerable(Of String) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            ClientCodes = (From DLS In DocumentLevelSettings
                                           Where String.IsNullOrWhiteSpace(DLS.ClientCode) = False
                                           Select DLS.ClientCode).ToArray

                            ClientDocuments = (From ClientDocument In AdvantageFramework.Database.Procedures.ClientDocument.LoadCurrentByClientCodes(DataContext, ClientCodes).ToList
                                               Where DocumentLevelSettings.Where(Function(DocumentLevelSetting) DocumentLevelSetting.ClientCode = ClientDocument.ClientCode).Any
                                               Select ClientDocument).ToList

                            DocumentIDs = ClientDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                            If AllowPrivateAccess = False Then

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID) AndAlso
                                                      (Document.IsPrivate Is Nothing OrElse
                                                       Document.IsPrivate = 0)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Client)).ToList

                            Else

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Client)).ToList

                            End If

                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                        End Try

                    End Using

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadClientDocuments = DocumentList

        End Function
        Public Function LoadRelatedClientDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                    ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim ClientDocument As AdvantageFramework.Database.Entities.ClientDocument = Nothing
            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ClientDocument) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs() As Long = Nothing

            Try

                ClientDocument = AdvantageFramework.Database.Procedures.ClientDocument.LoadByDocumentID(DataContext, DocumentID)

                If ClientDocument IsNot Nothing Then

                    RelatedDocuments = AdvantageFramework.Database.Procedures.ClientDocument.LoadRelated(DataContext, ClientDocument.ClientCode, FileName).ToList

                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                    Where DocumentIDs.Contains(Entity.ID)
                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Client)).ToList

                End If

            Catch ex As Exception
                DocumentList = Nothing
            Finally
                LoadRelatedClientDocuments = DocumentList
            End Try

        End Function
        Public Function DeleteClientDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            DeleteClientDocument = AdvantageFramework.Database.Procedures.ClientDocument.Delete(DataContext, DocumentID)

        End Function

#End Region

#Region "  Division Documents "

        Public Function LoadDivisionDocuments(ByVal Session As AdvantageFramework.Security.Session,
                                                ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting),
                                                ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim DivisionDocuments As Generic.List(Of AdvantageFramework.Database.Entities.DivisionDocument) = Nothing
            Dim DocumentIDs() As Long = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim ClientDivisionCodes As IEnumerable(Of String) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            ClientDivisionCodes = (From DLS In DocumentLevelSettings
                                                   Where String.IsNullOrWhiteSpace(DLS.ClientCode) = False AndAlso
                                                         String.IsNullOrWhiteSpace(DLS.DivisionCode) = False
                                                   Select [Code] = DLS.ClientCode & "|" & DLS.DivisionCode).ToArray

                            DivisionDocuments = (From DivisionDocument In AdvantageFramework.Database.Procedures.DivisionDocument.LoadCurrentByClientDivisionCodes(DataContext, ClientDivisionCodes).ToList
                                                 Select DivisionDocument).ToList

                            DocumentIDs = DivisionDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                            If AllowPrivateAccess = False Then

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID) AndAlso
                                                      (Document.IsPrivate Is Nothing OrElse
                                                       Document.IsPrivate = 0)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Division)).ToList

                            Else

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Division)).ToList

                            End If

                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                        End Try

                    End Using

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadDivisionDocuments = DocumentList

        End Function
        Public Function LoadRelatedDivisionDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                      ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim DivisionDocument As AdvantageFramework.Database.Entities.DivisionDocument = Nothing
            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.DivisionDocument) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs() As Long = Nothing

            Try

                DivisionDocument = AdvantageFramework.Database.Procedures.DivisionDocument.LoadByDocumentID(DataContext, DocumentID)

                If DivisionDocument IsNot Nothing Then

                    RelatedDocuments = AdvantageFramework.Database.Procedures.DivisionDocument.LoadRelated(DataContext, DivisionDocument.ClientCode, DivisionDocument.DivisionCode, FileName).ToList

                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                    Where DocumentIDs.Contains(Entity.ID)
                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Division)).ToList

                End If

            Catch ex As Exception
                DocumentList = Nothing
            Finally
                LoadRelatedDivisionDocuments = DocumentList
            End Try

        End Function
        Public Function DeleteDivisionDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            DeleteDivisionDocument = AdvantageFramework.Database.Procedures.DivisionDocument.Delete(DataContext, DocumentID)

        End Function

#End Region

#Region "  Product Documents "

        Public Function LoadProductDocuments(ByVal Session As AdvantageFramework.Security.Session,
                                             ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting),
                                             ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim ProductDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ProductDocument) = Nothing
            Dim DocumentIDs() As Long = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim ClientDivisionProductCodes As IEnumerable(Of String) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            ClientDivisionProductCodes = (From DLS In DocumentLevelSettings
                                                          Where String.IsNullOrWhiteSpace(DLS.ClientCode) = False AndAlso
                                                                String.IsNullOrWhiteSpace(DLS.DivisionCode) = False AndAlso
                                                                String.IsNullOrWhiteSpace(DLS.ProductCode) = False
                                                          Select [Code] = DLS.ClientCode & "|" & DLS.DivisionCode & "|" & DLS.ProductCode).ToArray

                            ProductDocuments = (From ProductDocument In AdvantageFramework.Database.Procedures.ProductDocument.LoadCurrentByClientDivisionProductCodes(DataContext, ClientDivisionProductCodes).ToList
                                                Select ProductDocument).ToList

                            DocumentIDs = ProductDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                            If AllowPrivateAccess = False Then

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID) AndAlso
                                                      (Document.IsPrivate Is Nothing OrElse
                                                       Document.IsPrivate = 0)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Product)).ToList

                            Else

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Product)).ToList

                            End If

                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                        End Try

                    End Using

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadProductDocuments = DocumentList

        End Function
        Public Function LoadRelatedProductDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                     ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim ProductDocument As AdvantageFramework.Database.Entities.ProductDocument = Nothing
            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ProductDocument) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs() As Long = Nothing

            Try

                ProductDocument = AdvantageFramework.Database.Procedures.ProductDocument.LoadByDocumentID(DataContext, DocumentID)

                If ProductDocument IsNot Nothing Then

                    RelatedDocuments = AdvantageFramework.Database.Procedures.ProductDocument.LoadRelated(DataContext, ProductDocument.ClientCode, ProductDocument.DivisionCode, ProductDocument.ProductCode, FileName).ToList

                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                    Where DocumentIDs.Contains(Entity.ID)
                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Product)).ToList

                End If

            Catch ex As Exception
                DocumentList = Nothing
            Finally
                LoadRelatedProductDocuments = DocumentList
            End Try

        End Function
        Public Function DeleteProductDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            DeleteProductDocument = AdvantageFramework.Database.Procedures.ProductDocument.Delete(DataContext, DocumentID)

        End Function

#End Region

#Region "  Campaign Documents "

        Public Function LoadCampaignDocuments(ByVal Session As AdvantageFramework.Security.Session, ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting), ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim CampaignDocuments As Generic.List(Of AdvantageFramework.Database.Entities.CampaignDocument) = Nothing
            Dim DocumentIDs() As Long = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim CampaignIDs As IEnumerable(Of Integer) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            CampaignIDs = (From DLS In DocumentLevelSettings
                                           Where String.IsNullOrWhiteSpace(DLS.CampaignID) = False
                                           Select CInt(DLS.CampaignID)).ToArray

                            CampaignDocuments = (From CampaignDocument In AdvantageFramework.Database.Procedures.CampaignDocument.LoadCurrentByCampaignIDs(DataContext, CampaignIDs)
                                                 Select CampaignDocument).ToList

                            DocumentIDs = CampaignDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                            If AllowPrivateAccess = False Then

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID) AndAlso
                                                      (Document.IsPrivate Is Nothing OrElse
                                                       Document.IsPrivate = 0)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Campaign)).ToList

                            Else

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Campaign)).ToList

                            End If

                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                        End Try

                    End Using

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadCampaignDocuments = DocumentList

        End Function
        Public Function LoadRelatedCampaignDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                      ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim CampaignDocument As AdvantageFramework.Database.Entities.CampaignDocument = Nothing
            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.CampaignDocument) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs() As Long = Nothing

            Try

                CampaignDocument = AdvantageFramework.Database.Procedures.CampaignDocument.LoadByDocumentID(DataContext, DocumentID)

                If CampaignDocument IsNot Nothing Then

                    RelatedDocuments = AdvantageFramework.Database.Procedures.CampaignDocument.LoadRelated(DataContext, CampaignDocument.CampaignID, FileName).ToList

                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                    Where DocumentIDs.Contains(Entity.ID)
                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Campaign)).ToList

                End If

            Catch ex As Exception
                DocumentList = Nothing
            Finally
                LoadRelatedCampaignDocuments = DocumentList
            End Try

        End Function
        Public Function DeleteCampaignDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            DeleteCampaignDocument = AdvantageFramework.Database.Procedures.CampaignDocument.Delete(DataContext, DocumentID)

        End Function

#End Region

#Region "  Employee Documents "

        Public Function LoadEmployeeDocuments(ByVal Session As AdvantageFramework.Security.Session, ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting), ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim EmployeeDocuments As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeDocument) = Nothing
            Dim DocumentIDs() As Long = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim EmployeeCodes As IEnumerable(Of String) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            EmployeeCodes = (From DLS In DocumentLevelSettings
                                             Where String.IsNullOrWhiteSpace(DLS.EmployeeCode) = False
                                             Select DLS.EmployeeCode).ToArray

                            EmployeeDocuments = (From EmployeeDocument In AdvantageFramework.Database.Procedures.EmployeeDocument.LoadCurrentByEmployeeCodes(DataContext, EmployeeCodes).ToList
                                                 Select EmployeeDocument).ToList

                            DocumentIDs = EmployeeDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                            If AllowPrivateAccess = False Then

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID) AndAlso
                                                                               (Document.IsPrivate Is Nothing OrElse
                                                                                Document.IsPrivate = 0)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Employee)).ToList

                            Else

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Employee)).ToList

                            End If

                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                        End Try

                    End Using

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadEmployeeDocuments = DocumentList

        End Function
        Public Function LoadRelatedEmployeeDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                      ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim EmployeeDocument As AdvantageFramework.Database.Entities.EmployeeDocument = Nothing
            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeDocument) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs() As Long = Nothing

            Try

                EmployeeDocument = AdvantageFramework.Database.Procedures.EmployeeDocument.LoadByDocumentID(DataContext, DocumentID)

                If EmployeeDocument IsNot Nothing Then

                    RelatedDocuments = AdvantageFramework.Database.Procedures.EmployeeDocument.LoadRelated(DataContext, EmployeeDocument.EmployeeCode, FileName).ToList

                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                    Where DocumentIDs.Contains(Entity.ID)
                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Employee)).ToList

                End If

            Catch ex As Exception
                DocumentList = Nothing
            Finally
                LoadRelatedEmployeeDocuments = DocumentList
            End Try

        End Function
        Public Function DeleteEmployeeDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            DeleteEmployeeDocument = AdvantageFramework.Database.Procedures.EmployeeDocument.Delete(DataContext, DocumentID)

        End Function

#End Region

#Region "  Expense Documents "

        Public Function LoadExpenseDetailDocuments(ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting),
                                                   ByVal Session As AdvantageFramework.Security.Session,
                                                   Optional ByVal AllowPrivateAccess As Nullable(Of Boolean) = Nothing) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim ExpenseDetailIDs() As Integer = Nothing
            Dim DocumentIDs() As Integer = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentLevelSettingsExpenseDetail As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing
            Dim ExpenseDetailDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseDetailDocument) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        DocumentLevelSettingsExpenseDetail = (From DocumentLevelSetting In DocumentLevelSettings
                                                              Where DocumentLevelSetting.DocumentLevel = Database.Entities.DocumentLevel.ExpenseReceipts AndAlso
                                                                    String.IsNullOrWhiteSpace(DocumentLevelSetting.ExpenseDetailID) = False
                                                              Select DocumentLevelSetting).ToList

                        ExpenseDetailIDs = DocumentLevelSettingsExpenseDetail.Select(Function(Entity) CInt(Entity.ExpenseDetailID)).ToArray

                        If AllowPrivateAccess Is Nothing Then

                            Try

                                AllowPrivateAccess = AdvantageFramework.Security.LoadUserGroupSetting(Session, Security.GroupSettings.DocumentManager_ViewPrivateDocuments).Where(Function(Setting) Setting = True).Any

                            Catch ex As Exception
                                AllowPrivateAccess = False
                            End Try

                        End If

                        If AllowPrivateAccess = False Then

                            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT EDD.DOCUMENT_ID FROM dbo.EXPENSE_DETAIL_DOCS EDD " &
                                                                                                    "INNER JOIN dbo.EXPENSE_DETAIL ED ON EDD.EXPDETAILID = ED.EXPDETAILID " &
                                                                                                    "INNER JOIN dbo.EXPENSE_HEADER EH ON ED.INV_NBR = EH.INV_NBR " &
                                                                                                    "INNER JOIN dbo.DOCUMENTS D ON EDD.DOCUMENT_ID = D.DOCUMENT_ID " &
                                                                                                    "WHERE (EH.EMP_CODE = '{0}' OR D.PRIVATE_FLAG IS NULL OR D.PRIVATE_FLAG = 0) " &
                                                                                                    "AND EDD.EXPDETAILID IN ({2})", Session.User.EmployeeCode, Session.UserCode, String.Join(",", ExpenseDetailIDs))).ToArray

                        Else

                            DocumentIDs = (From ExpenseDetailDocument In AdvantageFramework.Database.Procedures.ExpenseDetailDocument.Load(DbContext)
                                           Where ExpenseDetailIDs.Contains(ExpenseDetailDocument.ExpenseDetailID)
                                           Select ExpenseDetailDocument.DocumentID).ToArray

                        End If

                        ExpenseDetailDocuments = (From ExpenseDetailDocument In AdvantageFramework.Database.Procedures.ExpenseDetailDocument.Load(DbContext)
                                                  Where DocumentIDs.Contains(ExpenseDetailDocument.DocumentID)
                                                  Select ExpenseDetailDocument).ToList

                        DocumentList = (From EDD In ExpenseDetailDocuments
                                        Join DocumentLevelSetting In DocumentLevelSettingsExpenseDetail On EDD.ExpenseDetailID Equals CInt(DocumentLevelSetting.ExpenseDetailID)
                                        Join Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) On EDD.DocumentID Equals Document.ID
                                        Where DocumentIDs.Contains(EDD.DocumentID)
                                        Select Document, DocumentLevelSetting).ToList.Select(Function(Entity) New AdvantageFramework.DocumentManager.Classes.Document(Entity.Document, Database.Entities.DocumentLevel.ExpenseReceipts, Entity.DocumentLevelSetting)).ToList

                    Catch ex As Exception
                        DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                    End Try

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadExpenseDetailDocuments = DocumentList

        End Function
        Public Function LoadExpenseDetailDocuments(ByVal Session As AdvantageFramework.Security.Session, ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting), ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            LoadExpenseDetailDocuments = AdvantageFramework.DocumentManager.LoadExpenseDetailDocuments(DocumentLevelSettings, Session, AllowPrivateAccess)

        End Function
        Public Function LoadExpenseDocuments(ByVal Session As AdvantageFramework.Security.Session, ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting), ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim ExpenseReportDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReportDocument) = Nothing
            Dim DocumentIDs() As Integer = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim InvoiceNumbers As IEnumerable(Of String) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            InvoiceNumbers = (From DLS In DocumentLevelSettings
                                              Where String.IsNullOrWhiteSpace(DLS.ExpenseReportInvoiceNumber) = False
                                              Select DLS.ExpenseReportInvoiceNumber).ToArray

                            ExpenseReportDocuments = (From ExpenseReportDocument In AdvantageFramework.Database.Procedures.ExpenseReportDocument.LoadCurrentByInvoiceNumbers(DbContext, InvoiceNumbers).ToList
                                                      Select ExpenseReportDocument).ToList

                            DocumentIDs = ExpenseReportDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                            If AllowPrivateAccess = False Then

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID) AndAlso
                                                      (Document.IsPrivate Is Nothing OrElse
                                                       Document.IsPrivate = 0)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.ExpenseReceipts)).ToList

                            Else

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.ExpenseReceipts)).ToList

                            End If

                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                        End Try

                    End Using

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadExpenseDocuments = DocumentList

        End Function
        Public Function LoadRelatedExpenseDocuments(DbContext As AdvantageFramework.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext,
                                                    DocumentID As Long, FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim ExpenseReportDocument As AdvantageFramework.Database.Entities.ExpenseReportDocument = Nothing
            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReportDocument) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs() As Integer = Nothing

            Try

                ExpenseReportDocument = AdvantageFramework.Database.Procedures.ExpenseReportDocument.LoadByDocumentID(DbContext, DocumentID)

                If ExpenseReportDocument IsNot Nothing Then

                    RelatedDocuments = AdvantageFramework.Database.Procedures.ExpenseReportDocument.LoadRelated(DbContext, ExpenseReportDocument.InvoiceNumber, FileName).ToList

                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                    Where DocumentIDs.Contains(Entity.ID)
                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.ExpenseReceipts)).ToList

                End If

            Catch ex As Exception
                DocumentList = Nothing
            Finally
                LoadRelatedExpenseDocuments = DocumentList
            End Try

        End Function
        Public Function DeleteExpenseDocument(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer,
                                               ByVal DeleteExpenseDetailDocumentOnly As Boolean, Optional ByVal ExpenseDetailID As String = Nothing) As Boolean

            'objects
            Dim Deleted As Boolean = False

            If DeleteExpenseDetailDocumentOnly Then

                Deleted = AdvantageFramework.Database.Procedures.ExpenseDetailDocument.Delete(DbContext, DocumentID, ExpenseDetailID)

            Else

                Deleted = AdvantageFramework.Database.Procedures.ExpenseReportDocument.Delete(DbContext, DocumentID)

            End If

            DeleteExpenseDocument = Deleted

        End Function

#End Region

#Region "  Vendor Documents "

        Public Function LoadVendorDocuments(ByVal Session As AdvantageFramework.Security.Session, ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting), ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim VendorDocuments As Generic.List(Of AdvantageFramework.Database.Entities.VendorDocument) = Nothing
            Dim DocumentIDs() As Long = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim VendorCodes As IEnumerable(Of String) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            VendorCodes = (From DLS In DocumentLevelSettings
                                           Where String.IsNullOrWhiteSpace(DLS.VendorCode) = False
                                           Select DLS.VendorCode).ToArray

                            VendorDocuments = (From VendorDocument In AdvantageFramework.Database.Procedures.VendorDocument.LoadCurrentByVendorCodes(DataContext, VendorCodes).ToList
                                               Select VendorDocument).ToList

                            DocumentIDs = VendorDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                            If AllowPrivateAccess = False Then

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID) AndAlso
                                                      (Document.IsPrivate Is Nothing OrElse
                                                       Document.IsPrivate = 0)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Vendor)).ToList

                            Else

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Vendor)).ToList

                            End If

                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                        End Try

                    End Using

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadVendorDocuments = DocumentList

        End Function
        Public Function LoadRelatedVendorDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                    ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim VendorDocument As AdvantageFramework.Database.Entities.VendorDocument = Nothing
            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.VendorDocument) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs() As Long = Nothing

            Try

                VendorDocument = AdvantageFramework.Database.Procedures.VendorDocument.LoadByDocumentID(DataContext, DocumentID)

                If VendorDocument IsNot Nothing Then

                    RelatedDocuments = AdvantageFramework.Database.Procedures.VendorDocument.LoadRelated(DataContext, VendorDocument.VendorCode, FileName).ToList

                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                    Where DocumentIDs.Contains(Entity.ID)
                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Vendor)).ToList

                End If

            Catch ex As Exception
                DocumentList = Nothing
            Finally
                LoadRelatedVendorDocuments = DocumentList
            End Try

        End Function
        Public Function DeleteVendorDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            DeleteVendorDocument = AdvantageFramework.Database.Procedures.VendorDocument.Delete(DataContext, DocumentID)

        End Function

#End Region

#Region "  Job Documents "

        Public Function LoadJobDocuments(ByVal Session As AdvantageFramework.Security.Session, ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting), ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim JobNumbers As IEnumerable(Of Integer) = Nothing
            Dim DocumentIDs() As Long = Nothing
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            JobNumbers = DocumentLevelSettings.Where(Function(Entity) Entity.JobNumber <> "").Select(Function(Entity) CInt(Entity.JobNumber)).ToArray

                            DocumentIDs = AdvantageFramework.Database.Procedures.JobDocument.LoadCurrentDocumentIDsByJobNumbers(DataContext, JobNumbers).Select(Function(DocumentID) CLng(DocumentID)).ToArray

                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

                            If AllowPrivateAccess Then

                                Documents = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                             Where DocumentIDs.Contains(Document.ID)
                                             Select Document).ToList

                            Else

                                Documents = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                             Where DocumentIDs.Contains(Document.ID) AndAlso
                                                   (Document.IsPrivate Is Nothing OrElse
                                                    Document.IsPrivate = 0)
                                             Select Document).ToList

                            End If

                            DocumentList.AddRange((From Document In Documents
                                                   Join JobDocument In AdvantageFramework.Database.Procedures.JobDocument.Load(DataContext).ToList On JobDocument.DocumentID Equals Document.ID
                                                   Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Job)).ToList)

                            DocumentList.AddRange((From Document In Documents
                                                   Join AccountPayableDocument In AdvantageFramework.Database.Procedures.AccountPayableDocument.Load(DataContext).ToList On AccountPayableDocument.DocumentID Equals Document.ID
                                                   Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.AccountPayableInvoice)).ToList)

                            DocumentList.AddRange((From Document In Documents
                                                   Join AccountReceivableDocument In AdvantageFramework.Database.Procedures.AccountReceivableDocument.Load(DbContext).ToList On AccountReceivableDocument.DocumentID Equals Document.ID
                                                   Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.AccountReceivableInvoice)).ToList)


                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                        End Try

                    End Using

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadJobDocuments = DocumentList

        End Function
        Public Function LoadRelatedJobDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                 ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim JobDocument As AdvantageFramework.Database.Entities.JobDocument = Nothing
            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.JobDocument) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs() As Long = Nothing

            Try

                JobDocument = AdvantageFramework.Database.Procedures.JobDocument.LoadByDocumentID(DataContext, DocumentID)

                If JobDocument IsNot Nothing Then

                    RelatedDocuments = AdvantageFramework.Database.Procedures.JobDocument.LoadRelated(DataContext, JobDocument.JobNumber, FileName).ToList

                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                    Where DocumentIDs.Contains(Entity.ID)
                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Job)).ToList

                End If

            Catch ex As Exception
                DocumentList = Nothing
            Finally
                LoadRelatedJobDocuments = DocumentList
            End Try

        End Function
        Public Function DeleteJobDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            DeleteJobDocument = AdvantageFramework.Database.Procedures.JobDocument.Delete(DataContext, DocumentID)

        End Function

#End Region

#Region "  Job Component Documents "

        Public Function LoadJobComponentDocuments(ByVal Session As AdvantageFramework.Security.Session, ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting), ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim DocumentIDs() As Long = Nothing
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim JobNumberComponents As IEnumerable(Of String) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            JobNumberComponents = (From DLS In DocumentLevelSettings
                                                   Where String.IsNullOrWhiteSpace(DLS.JobNumber) = False AndAlso
                                                         String.IsNullOrWhiteSpace(DLS.JobComponentNumber) = False
                                                   Select [Code] = DLS.JobNumber & "|" & DLS.JobComponentNumber).ToArray

                            DocumentIDs = AdvantageFramework.Database.Procedures.JobComponentDocument.LoadCurrentDocumentIDsByJobNumberComponents(DataContext, JobNumberComponents).Select(Function(DocumentID) CLng(DocumentID)).ToArray

                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

                            If AllowPrivateAccess Then

                                Documents = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                             Where DocumentIDs.Contains(Document.ID)
                                             Select Document).ToList

                            Else

                                Documents = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                             Where DocumentIDs.Contains(Document.ID) AndAlso
                                                   (Document.IsPrivate Is Nothing OrElse
                                                    Document.IsPrivate = 0)
                                             Select Document).ToList

                            End If

                            DocumentList.AddRange((From Document In Documents
                                                   Join JobComponentDocument In AdvantageFramework.Database.Procedures.JobComponentDocument.Load(DataContext).ToList On JobComponentDocument.DocumentID Equals Document.ID
                                                   Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.JobComponent)).ToList)

                            DocumentList.AddRange((From Document In Documents
                                                   Join AccountPayableDocument In AdvantageFramework.Database.Procedures.AccountPayableDocument.Load(DataContext).ToList On AccountPayableDocument.DocumentID Equals Document.ID
                                                   Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.AccountPayableInvoice)).ToList)

                            DocumentList.AddRange((From Document In Documents
                                                   Join AccountReceivableDocument In AdvantageFramework.Database.Procedures.AccountReceivableDocument.Load(DbContext).ToList On AccountReceivableDocument.DocumentID Equals Document.ID
                                                   Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.AccountReceivableInvoice)).ToList)

                            DocumentList.AddRange((From Document In Documents
                                                   Join JobComponentTaskDocument In AdvantageFramework.Database.Procedures.JobComponentTaskDocument.Load(DataContext).ToList On JobComponentTaskDocument.DocumentID Equals Document.ID
                                                   Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Task)).ToList)

                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                        End Try

                    End Using

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadJobComponentDocuments = DocumentList

        End Function
        Public Function LoadRelatedJobComponentDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                          ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim JobComponentDocument As AdvantageFramework.Database.Entities.JobComponentDocument = Nothing
            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentDocument) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs() As Long = Nothing

            Try

                JobComponentDocument = AdvantageFramework.Database.Procedures.JobComponentDocument.LoadByDocumentID(DataContext, DocumentID)

                If JobComponentDocument IsNot Nothing Then

                    RelatedDocuments = AdvantageFramework.Database.Procedures.JobComponentDocument.LoadRelated(DataContext, JobComponentDocument.JobNumber, JobComponentDocument.JobComponentNumber, FileName).ToList

                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                    Where DocumentIDs.Contains(Entity.ID)
                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.JobComponent)).ToList

                End If

            Catch ex As Exception
                DocumentList = Nothing
            Finally
                LoadRelatedJobComponentDocuments = DocumentList
            End Try

        End Function
        Public Function DeleteJobComponentDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            Try

                AdvantageFramework.Database.Procedures.JobComponentDocument.Delete(DataContext, DocumentID)

                Try

                    DataContext.ExecuteCommand(String.Format("DELETE FROM [dbo].[JOB_TRAFFIC_DET_DOCS] WHERE [DOCUMENT_ID] = {0}", DocumentID))

                Catch ex As Exception

                End Try

                DeleteJobComponentDocument = True

            Catch ex As Exception
                DeleteJobComponentDocument = True
            End Try

        End Function

#End Region

#Region "  Contract Documents "

        Public Function LoadContractDocuments(ByVal Session As AdvantageFramework.Security.Session, ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting), ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim ContractDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ContractDocument) = Nothing
            Dim DocumentIDs() As Long = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim ContractIDs As IEnumerable(Of Integer) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        ContractIDs = (From DLS In DocumentLevelSettings
                                       Where String.IsNullOrWhiteSpace(DLS.ContractID) = False
                                       Select CInt(DLS.ContractID)).ToArray

                        ContractDocuments = (From ContractDocument In AdvantageFramework.Database.Procedures.ContractDocument.LoadCurrentByContractIDs(DbContext, ContractIDs).ToList
                                             Where DocumentLevelSettings.Where(Function(DocumentLevelSetting) DocumentLevelSetting.ContractID = ContractDocument.ContractID).Any
                                             Select ContractDocument).ToList

                        DocumentIDs = ContractDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

                        If AllowPrivateAccess = False Then

                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                            Where DocumentIDs.Contains(Document.ID) AndAlso
                                                  (Document.IsPrivate Is Nothing OrElse
                                                   Document.IsPrivate = 0)
                                            Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Contract)).ToList

                        Else

                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                            Where DocumentIDs.Contains(Document.ID)
                                            Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Contract)).ToList

                        End If

                    Catch ex As Exception
                        DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                    End Try

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadContractDocuments = DocumentList

        End Function
        Public Function LoadRelatedContractDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                      ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim ContractDocument As AdvantageFramework.Database.Entities.ContractDocument = Nothing
            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ContractDocument) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs() As Long = Nothing

            Try

                ContractDocument = AdvantageFramework.Database.Procedures.ContractDocument.LoadByDocumentID(DbContext, DocumentID)

                If ContractDocument IsNot Nothing Then

                    RelatedDocuments = AdvantageFramework.Database.Procedures.ContractDocument.LoadRelated(DbContext, ContractDocument.ContractID, FileName).ToList

                    DocumentIDs = RelatedDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                    Where DocumentIDs.Contains(Entity.ID)
                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Contract)).ToList

                End If

            Catch ex As Exception
                DocumentList = Nothing
            Finally
                LoadRelatedContractDocuments = DocumentList
            End Try

        End Function
        Public Function DeleteContractDocument(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            DeleteContractDocument = AdvantageFramework.Database.Procedures.ContractDocument.Delete(DbContext, DocumentID)

        End Function

#End Region

#Region "  Account Payable Documents "

        Public Function LoadAccountPayableInvoiceDocuments(ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting),
                                                           ByVal Session As AdvantageFramework.Security.Session,
                                                           Optional ByVal AllowPrivateAccess As Nullable(Of Boolean) = Nothing) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim AccountPayableIDs As Generic.List(Of Integer) = Nothing
            Dim AccountPayableDocuments As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableDocument) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentLevelSettingsAP As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            DocumentLevelSettingsAP = (From DocumentLevelSetting In DocumentLevelSettings
                                                       Where DocumentLevelSetting.DocumentLevel = Database.Entities.DocumentLevel.AccountPayableInvoice AndAlso
                                                             DocumentLevelSetting.AccountPayableID <> ""
                                                       Select DocumentLevelSetting).ToList

                            AccountPayableIDs = DocumentLevelSettingsAP.Select(Function(Entity) CInt(Entity.AccountPayableID)).ToList

                            AccountPayableDocuments = (From AccountPayableDocument In AdvantageFramework.Database.Procedures.AccountPayableDocument.LoadCurrentByAPIDs(DataContext, AccountPayableIDs)
                                                       Select AccountPayableDocument).ToList

                            If AllowPrivateAccess Is Nothing Then

                                Try

                                    AllowPrivateAccess = AdvantageFramework.Security.LoadUserGroupSetting(Session, Security.GroupSettings.DocumentManager_ViewPrivateDocuments).Where(Function(Setting) Setting = True).Any

                                Catch ex As Exception
                                    AllowPrivateAccess = False
                                End Try

                            End If

                            If AllowPrivateAccess Then

                                DocumentList = (From AccountPayableDocument In AccountPayableDocuments
                                                Join DocumentLevelSetting In DocumentLevelSettingsAP On AccountPayableDocument.AccountPayableID Equals CLng(DocumentLevelSetting.AccountPayableID)
                                                Join Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) On CInt(AccountPayableDocument.DocumentID) Equals Document.ID
                                                Where DocumentLevelSetting.DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice
                                                Select Document, DocumentLevelSetting).ToList.Select(Function(Entity) New AdvantageFramework.DocumentManager.Classes.Document(Entity.Document, Database.Entities.DocumentLevel.AccountPayableInvoice, Entity.DocumentLevelSetting)).ToList

                            Else

                                DocumentList = (From AccountPayableDocument In AccountPayableDocuments
                                                Join DocumentLevelSetting In DocumentLevelSettingsAP On AccountPayableDocument.AccountPayableID Equals CLng(DocumentLevelSetting.AccountPayableID)
                                                Join Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) On CInt(AccountPayableDocument.DocumentID) Equals Document.ID
                                                Where DocumentLevelSetting.DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice AndAlso
                                                      (Document.IsPrivate Is Nothing OrElse
                                                       Document.IsPrivate = 0)
                                                Select Document, DocumentLevelSetting).ToList.Select(Function(Entity) New AdvantageFramework.DocumentManager.Classes.Document(Entity.Document, Database.Entities.DocumentLevel.AccountPayableInvoice, Entity.DocumentLevelSetting)).ToList

                            End If

                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                        End Try

                    End Using

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadAccountPayableInvoiceDocuments = DocumentList

        End Function
        Public Function LoadAccountPayableInvoiceDocumentsByVendor(ByVal Session As AdvantageFramework.Security.Session, VendorCode As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim InvoiceDocuments As Generic.List(Of AdvantageFramework.DocumentManager.Classes.InvoiceDocument) = Nothing
            Dim DocumentIDs As Generic.List(Of Integer) = Nothing
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim AllowPrivateAccess As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    Try

                        AllowPrivateAccess = AdvantageFramework.Security.LoadUserGroupSetting(Session, Security.GroupSettings.DocumentManager_ViewPrivateDocuments).Where(Function(Setting) Setting = True).Any

                    Catch ex As Exception
                        AllowPrivateAccess = False
                    End Try

                    Try

                        InvoiceDocuments = DbContext.Database.SqlQuery(Of AdvantageFramework.DocumentManager.Classes.InvoiceDocument)(String.Format("SELECT [DocumentID] = APD.DOCUMENT_ID, [InvoiceDate] = AP.AP_INV_DATE FROM dbo.WV_CURRENT_AP_DOCUMENTS APD INNER JOIN dbo.AP_HEADER AP ON AP.AP_ID = APD.AP_ID WHERE AP.MODIFY_FLAG IS NULL AND AP.DELETE_FLAG IS NULL AND AP.VN_FRL_EMP_CODE = '{0}'", VendorCode)).ToList

                    Catch ex As Exception
                        InvoiceDocuments = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.InvoiceDocument)
                    End Try

                    Try

                        DocumentIDs = InvoiceDocuments.Select(Function(Entity) Entity.DocumentID).ToList

                    Catch ex As Exception
                        DocumentIDs = New Generic.List(Of Integer)
                    End Try

                    If AllowPrivateAccess = False Then

                        Documents = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                     Where DocumentIDs.Contains(Document.ID) = True AndAlso
                                           (Document.IsPrivate Is Nothing OrElse
                                            Document.IsPrivate = 0)
                                     Select Document).ToList

                    Else

                        Documents = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                     Where DocumentIDs.Contains(Document.ID) = True
                                     Select Document).ToList

                    End If

                    DocumentList = (From Document In Documents
                                    Join InvoiceDocument In InvoiceDocuments On InvoiceDocument.DocumentID Equals Document.ID
                                    Select New With {.Document = Document,
                                                     .InvoiceDocument = InvoiceDocument}).ToList.Select(Function(Entity) New AdvantageFramework.DocumentManager.Classes.Document(Entity.Document, Database.Entities.DocumentLevel.AccountPayableInvoice, Entity.InvoiceDocument)).ToList

                Catch ex As Exception
                    DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                End Try

            End Using

            LoadAccountPayableInvoiceDocumentsByVendor = DocumentList

        End Function
        Public Function LoadAccountPayableInvoiceDocuments(ByVal Session As AdvantageFramework.Security.Session, ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting), ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            LoadAccountPayableInvoiceDocuments = AdvantageFramework.DocumentManager.LoadAccountPayableInvoiceDocuments(DocumentLevelSettings, Session, AllowPrivateAccess)

        End Function
        Public Function LoadRelatedAccountPayableDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                            ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim AccountPayableDocument As AdvantageFramework.Database.Entities.AccountPayableDocument = Nothing
            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableDocument) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs() As Long = Nothing

            Try

                AccountPayableDocument = AdvantageFramework.Database.Procedures.AccountPayableDocument.LoadByDocumentID(DataContext, DocumentID)

                If AccountPayableDocument IsNot Nothing Then

                    RelatedDocuments = AdvantageFramework.Database.Procedures.AccountPayableDocument.LoadRelated(DataContext, AccountPayableDocument.AccountPayableID, FileName).ToList

                    DocumentIDs = RelatedDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                    Where DocumentIDs.Contains(Entity.ID)
                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.AccountPayableInvoice)).ToList

                End If

            Catch ex As Exception
                DocumentList = Nothing
            Finally
                LoadRelatedAccountPayableDocuments = DocumentList
            End Try

        End Function
        Public Function DeleteAccountPayableInvoiceDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            DeleteAccountPayableInvoiceDocument = AdvantageFramework.Database.Procedures.AccountPayableDocument.Delete(DataContext, DocumentID)

        End Function

#End Region

#Region "  Office Documents "

        Public Function LoadOfficeDocuments(ByVal Session As AdvantageFramework.Security.Session, ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting), ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim OfficeDocuments As Generic.List(Of AdvantageFramework.Database.Entities.OfficeDocument) = Nothing
            Dim DocumentIDs() As Long = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim OfficeCodes As IEnumerable(Of String) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        OfficeCodes = (From DLS In DocumentLevelSettings
                                       Where String.IsNullOrWhiteSpace(DLS.OfficeCode) = False
                                       Select DLS.OfficeCode).ToArray

                        OfficeDocuments = (From OfficeDocument In AdvantageFramework.Database.Procedures.OfficeDocument.LoadCurrentByOfficeCodes(DbContext, OfficeCodes).ToList
                                           Select OfficeDocument).ToList

                        DocumentIDs = OfficeDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

                        If AllowPrivateAccess = False Then

                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                            Where DocumentIDs.Contains(Document.ID) AndAlso
                                                  (Document.IsPrivate Is Nothing OrElse
                                                   Document.IsPrivate = 0)
                                            Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Office)).ToList

                        Else

                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                            Where DocumentIDs.Contains(Document.ID)
                                            Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Office)).ToList

                        End If

                    Catch ex As Exception
                        DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                    End Try

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadOfficeDocuments = DocumentList

        End Function
        Public Function LoadRelatedOfficeDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim OfficeDocument As AdvantageFramework.Database.Entities.OfficeDocument = Nothing
            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.OfficeDocument) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs() As Long = Nothing

            Try

                OfficeDocument = AdvantageFramework.Database.Procedures.OfficeDocument.LoadByDocumentID(DbContext, DocumentID)

                If OfficeDocument IsNot Nothing Then

                    RelatedDocuments = AdvantageFramework.Database.Procedures.OfficeDocument.LoadRelated(DbContext, OfficeDocument.OfficeCode, FileName).ToList

                    DocumentIDs = RelatedDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                    Where DocumentIDs.Contains(Entity.ID)
                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.Office)).ToList

                End If

            Catch ex As Exception
                DocumentList = Nothing
            Finally
                LoadRelatedOfficeDocuments = DocumentList
            End Try

        End Function
        Public Function DeleteOfficeDocument(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            DeleteOfficeDocument = AdvantageFramework.Database.Procedures.OfficeDocument.Delete(DbContext, DocumentID)

        End Function

#End Region

#Region "  Ad Number Documents "

        Public Function LoadAdNumberDocuments(ByVal Session As AdvantageFramework.Security.Session, ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting), ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim Ads As Generic.List(Of AdvantageFramework.Database.Entities.Ad) = Nothing
            Dim DocumentIDs() As Long = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        Ads = (From Ad In AdvantageFramework.Database.Procedures.Ad.Load(DbContext).ToList
                               Where DocumentLevelSettings.Where(Function(DocumentLevelSetting) DocumentLevelSetting.AdNumber = Ad.Number).Any
                               Select Ad).ToList

                        DocumentIDs = Ads.Where(Function(Entity) Entity.DocumentID.HasValue).Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

                        If AllowPrivateAccess = False Then

                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                            Where DocumentIDs.Contains(Document.ID) AndAlso
                                                  (Document.IsPrivate Is Nothing OrElse
                                                   Document.IsPrivate = 0)
                                            Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.AdNumber)).ToList

                        Else

                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                            Where DocumentIDs.Contains(Document.ID)
                                            Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.AdNumber)).ToList

                        End If

                    Catch ex As Exception
                        DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                    End Try

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadAdNumberDocuments = DocumentList

        End Function
        Public Function DeleteAdDocument(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing
            Dim Deleted As Boolean = False

            Try

                Ad = (From Entity In AdvantageFramework.Database.Procedures.Ad.Load(DbContext)
                      Where Entity.DocumentID = DocumentID
                      Select Entity).SingleOrDefault

            Catch ex As Exception
                Ad = Nothing
            End Try

            If Ad IsNot Nothing Then

                Ad.DocumentID = Nothing

                Deleted = AdvantageFramework.Database.Procedures.Ad.Update(DbContext, Ad)

            End If

            DeleteAdDocument = Deleted

        End Function

#End Region

#Region "  Account Receivable Documents "

        Public Function LoadAccountReceivableInvoiceDocuments(ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting),
                                                              ByVal Session As AdvantageFramework.Security.Session,
                                                              Optional ByVal AllowPrivateAccess As Nullable(Of Boolean) = Nothing) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        If AllowPrivateAccess Is Nothing Then

                            Try

                                AllowPrivateAccess = AdvantageFramework.Security.LoadUserGroupSetting(Session, Security.GroupSettings.DocumentManager_ViewPrivateDocuments).Where(Function(Setting) Setting = True).Any

                            Catch ex As Exception
                                AllowPrivateAccess = False
                            End Try

                        End If

                        If AllowPrivateAccess = False Then

                            DocumentList = (From AccountReceivableDocument In AdvantageFramework.Database.Procedures.AccountReceivableDocument.LoadCurrentByDocumentLevelSettings(DbContext, DocumentLevelSettings)
                                            Join DocumentLevelSetting In DocumentLevelSettings On AccountReceivableDocument.InvoiceNumber Equals DocumentLevelSetting.AccountReceivableInvoiceNumber _
                                                                                               And AccountReceivableDocument.SequenceNumber Equals DocumentLevelSetting.AccountReceivableSequenceNumber _
                                                                                               And AccountReceivableDocument.Type Equals DocumentLevelSetting.AccountReceivableType
                                            Join Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) On AccountReceivableDocument.DocumentID Equals Document.ID
                                            Where DocumentLevelSetting.DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice AndAlso
                                                  (Document.IsPrivate Is Nothing OrElse
                                                   Document.IsPrivate = 0)
                                            Select Document, DocumentLevelSetting).ToList.Select(Function(Entity) New AdvantageFramework.DocumentManager.Classes.Document(Entity.Document, Database.Entities.DocumentLevel.AccountReceivableInvoice, Entity.DocumentLevelSetting)).ToList

                        Else

                            DocumentList = (From AccountReceivableDocument In AdvantageFramework.Database.Procedures.AccountReceivableDocument.LoadCurrentByDocumentLevelSettings(DbContext, DocumentLevelSettings)
                                            Join DocumentLevelSetting In DocumentLevelSettings On AccountReceivableDocument.InvoiceNumber Equals DocumentLevelSetting.AccountReceivableInvoiceNumber _
                                                                                               And AccountReceivableDocument.SequenceNumber Equals DocumentLevelSetting.AccountReceivableSequenceNumber _
                                                                                               And AccountReceivableDocument.Type Equals DocumentLevelSetting.AccountReceivableType
                                            Join Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext) On AccountReceivableDocument.DocumentID Equals Document.ID
                                            Where DocumentLevelSetting.DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice
                                            Select Document, DocumentLevelSetting).ToList.Select(Function(Entity) New AdvantageFramework.DocumentManager.Classes.Document(Entity.Document, Database.Entities.DocumentLevel.AccountReceivableInvoice, Entity.DocumentLevelSetting)).ToList

                        End If

                    Catch ex As Exception
                        DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                    End Try

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadAccountReceivableInvoiceDocuments = DocumentList

        End Function
        Public Function LoadAccountReceivableInvoiceDocumentsByClient(ByVal Session As AdvantageFramework.Security.Session, ClientCode As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim InvoiceDocuments As Generic.List(Of AdvantageFramework.DocumentManager.Classes.InvoiceDocument) = Nothing
            Dim DocumentIDs As Generic.List(Of Integer) = Nothing
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim AllowPrivateAccess As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    Try

                        AllowPrivateAccess = AdvantageFramework.Security.LoadUserGroupSetting(Session, Security.GroupSettings.DocumentManager_ViewPrivateDocuments).Where(Function(Setting) Setting = True).Any

                    Catch ex As Exception
                        AllowPrivateAccess = False
                    End Try

                    Try

                        InvoiceDocuments = DbContext.Database.SqlQuery(Of AdvantageFramework.DocumentManager.Classes.InvoiceDocument)(String.Format("SELECT  [DocumentID] = ARD.DOCUMENT_ID, [InvoiceDate] = AR.AR_INV_DATE FROM dbo.CURRENT_ARINVOICE_DOCUMENTS ARD INNER JOIN dbo.ACCT_REC AR ON AR.AR_INV_NBR = ARD.AR_INV_NBR AND AR.AR_INV_SEQ = ARD.AR_INV_SEQ AND AR.AR_TYPE = ARD.AR_TYPE WHERE AR.CL_CODE = '{0}'", ClientCode)).ToList

                    Catch ex As Exception
                        InvoiceDocuments = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.InvoiceDocument)
                    End Try

                    Try

                        DocumentIDs = InvoiceDocuments.Select(Function(Entity) Entity.DocumentID).ToList

                    Catch ex As Exception
                        DocumentIDs = New Generic.List(Of Integer)
                    End Try

                    If AllowPrivateAccess = False Then

                        Documents = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                     Where DocumentIDs.Contains(Document.ID) = True AndAlso
                                           (Document.IsPrivate Is Nothing OrElse
                                            Document.IsPrivate = 0)
                                     Select Document).ToList

                    Else

                        Documents = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                     Where DocumentIDs.Contains(Document.ID) = True
                                     Select Document).ToList

                    End If

                    DocumentList = (From Document In Documents
                                    Join InvoiceDocument In InvoiceDocuments On InvoiceDocument.DocumentID Equals Document.ID
                                    Select New With {.Document = Document,
                                                     .InvoiceDocument = InvoiceDocument}).ToList.Select(Function(Entity) New AdvantageFramework.DocumentManager.Classes.Document(Entity.Document, Database.Entities.DocumentLevel.AccountReceivableInvoice, Entity.InvoiceDocument)).ToList

                Catch ex As Exception
                    DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                End Try

            End Using

            LoadAccountReceivableInvoiceDocumentsByClient = DocumentList

        End Function
        Public Function LoadAccountReceivableInvoiceDocuments(ByVal Session As AdvantageFramework.Security.Session, ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting), ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            LoadAccountReceivableInvoiceDocuments = AdvantageFramework.DocumentManager.LoadAccountReceivableInvoiceDocuments(DocumentLevelSettings, Session, AllowPrivateAccess)

        End Function
        Public Function LoadRelatedAccountReceivableInvoiceDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                      ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim AccountReceivableDocument As AdvantageFramework.Database.Entities.AccountReceivableDocument = Nothing
            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.AccountReceivableDocument) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs() As Long = Nothing

            Try

                AccountReceivableDocument = AdvantageFramework.Database.Procedures.AccountReceivableDocument.LoadByDocumentID(DbContext, DocumentID)

                If AccountReceivableDocument IsNot Nothing Then

                    RelatedDocuments = AdvantageFramework.Database.Procedures.AccountReceivableDocument.LoadRelated(DbContext, AccountReceivableDocument.InvoiceNumber, AccountReceivableDocument.SequenceNumber, AccountReceivableDocument.Type, FileName).ToList

                    DocumentIDs = RelatedDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

                    DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                    Where DocumentIDs.Contains(Document.ID)
                                    Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.AccountReceivableInvoice)).ToList

                End If

            Catch ex As Exception
                DocumentList = Nothing
            Finally
                LoadRelatedAccountReceivableInvoiceDocuments = DocumentList
            End Try

        End Function
        Public Function DeleteAccountReceivableInvoiceDocument(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            DeleteAccountReceivableInvoiceDocument = AdvantageFramework.Database.Procedures.AccountReceivableDocument.Delete(DbContext, DocumentID)

        End Function

#End Region

#Region "  Contract Report Documents "

        Public Function LoadContractReportDocuments(ByVal Session As AdvantageFramework.Security.Session, ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting), ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim ContractReportDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ContractReportDocument) = Nothing
            Dim DocumentIDs() As Long = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim ContractReportIDs As IEnumerable(Of Integer) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            ContractReportIDs = (From DLS In DocumentLevelSettings
                                                 Where String.IsNullOrWhiteSpace(DLS.ContractReportID) = False
                                                 Select CInt(DLS.ContractReportID)).ToArray

                            ContractReportDocuments = (From ContractReportDocument In AdvantageFramework.Database.Procedures.ContractReportDocument.LoadCurrentByContractReportIDs(DataContext, ContractReportIDs).ToList
                                                       Where DocumentLevelSettings.Where(Function(DocumentLevelSetting) DocumentLevelSetting.ContractReportID = ContractReportDocument.ContractReportID).Any
                                                       Select ContractReportDocument).ToList

                            DocumentIDs = ContractReportDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                            If AllowPrivateAccess = False Then

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID) AndAlso
                                                      (Document.IsPrivate Is Nothing OrElse
                                                       Document.IsPrivate = 0)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.ContractReport)).ToList

                            Else

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.ContractReport)).ToList

                            End If

                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                        End Try

                    End Using

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadContractReportDocuments = DocumentList

        End Function
        Public Function LoadRelatedContractReportDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                            ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim ContractReportDocument As AdvantageFramework.Database.Entities.ContractReportDocument = Nothing
            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ContractReportDocument) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs() As Long = Nothing

            Try

                ContractReportDocument = AdvantageFramework.Database.Procedures.ContractReportDocument.LoadByDocumentID(DataContext, DocumentID)

                If ContractReportDocument IsNot Nothing Then

                    RelatedDocuments = AdvantageFramework.Database.Procedures.ContractReportDocument.LoadRelated(DataContext, ContractReportDocument.ContractReportID, FileName).ToList

                    DocumentIDs = RelatedDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                    Where DocumentIDs.Contains(Entity.ID)
                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.ContractReport)).ToList

                End If

            Catch ex As Exception
                DocumentList = Nothing
            Finally
                LoadRelatedContractReportDocuments = DocumentList
            End Try

        End Function
        Public Function DeleteContractReportDocument(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Integer) As Boolean

            DeleteContractReportDocument = AdvantageFramework.Database.Procedures.ContractReportDocument.Delete(DataContext, DocumentID)

        End Function

#End Region

#Region "  Vendor Contract Documents "

        Public Function LoadVendorContractDocuments(ByVal Session As AdvantageFramework.Security.Session, ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting), ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim VendorContractDocuments As Generic.List(Of AdvantageFramework.Database.Entities.VendorContractDocument) = Nothing
            Dim DocumentIDs() As Integer = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim VendorContractIDs As IEnumerable(Of Integer) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        VendorContractIDs = (From DLS In DocumentLevelSettings
                                             Where String.IsNullOrWhiteSpace(DLS.VendorContractID) = False
                                             Select CInt(DLS.VendorContractID)).ToArray

                        VendorContractDocuments = (From VendorContractDocument In AdvantageFramework.Database.Procedures.VendorContractDocument.Load(DbContext).ToList
                                                   Where DocumentLevelSettings.Where(Function(DocumentLevelSetting) DocumentLevelSetting.VendorContractID = VendorContractDocument.ContractID).Any
                                                   Select VendorContractDocument).ToList

                        DocumentIDs = VendorContractDocuments.Select(Function(Entity) Entity.DocumentID).ToArray

                        If AllowPrivateAccess = False Then

                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                            Where DocumentIDs.Contains(Document.ID) AndAlso
                                                  (Document.IsPrivate Is Nothing OrElse
                                                   Document.IsPrivate = 0)
                                            Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.VendorContract)).ToList

                        Else

                            DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                            Where DocumentIDs.Contains(Document.ID)
                                            Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.VendorContract)).ToList

                        End If

                    Catch ex As Exception
                        DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                    End Try

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadVendorContractDocuments = DocumentList

        End Function
        Public Function LoadRelatedVendorContractDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                           ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim VendorContractDocument As AdvantageFramework.Database.Entities.VendorContractDocument = Nothing
            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.VendorContractDocument) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs() As Long = Nothing

            Try

                VendorContractDocument = AdvantageFramework.Database.Procedures.VendorContractDocument.LoadByDocumentID(DbContext, DocumentID)

                If VendorContractDocument IsNot Nothing Then

                    RelatedDocuments = AdvantageFramework.Database.Procedures.VendorContractDocument.LoadRelated(DbContext, VendorContractDocument.ID, FileName).ToList

                    DocumentIDs = RelatedDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                    Where DocumentIDs.Contains(Entity.ID)
                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.VendorContract)).ToList

                End If

            Catch ex As Exception
                DocumentList = Nothing
            Finally
                LoadRelatedVendorContractDocuments = DocumentList
            End Try

        End Function
        Public Function DeleteVendorContractDocument(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            DeleteVendorContractDocument = AdvantageFramework.Database.Procedures.VendorContractDocument.Delete(DbContext, DocumentID)

        End Function

#End Region

#Region "  Agency Desktop Documents "

        Public Function LoadAgencyDesktopDocuments(ByVal Session As AdvantageFramework.Security.Session,
                                                   ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting),
                                                   ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim AgencyDesktopDocuments As Generic.List(Of AdvantageFramework.Database.Entities.AgencyDesktopDocument) = Nothing
            Dim DocumentIDs() As Long = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim AgencyDesktopCodes As IEnumerable(Of String) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            AgencyDesktopDocuments = New Generic.List(Of AdvantageFramework.Database.Entities.AgencyDesktopDocument)

                            For Each DocumentLevelSetting In DocumentLevelSettings

                                If String.IsNullOrWhiteSpace(DocumentLevelSetting.OfficeCode) = True AndAlso String.IsNullOrWhiteSpace(DocumentLevelSetting.DepartmentCode) = True Then

                                    AgencyDesktopDocuments.AddRange(AdvantageFramework.Database.Procedures.AgencyDesktopDocument.LoadCurrent(DbContext))

                                ElseIf String.IsNullOrWhiteSpace(DocumentLevelSetting.OfficeCode) = True AndAlso String.IsNullOrWhiteSpace(DocumentLevelSetting.DepartmentCode) = False Then

                                    AgencyDesktopDocuments.AddRange(AdvantageFramework.Database.Procedures.AgencyDesktopDocument.LoadCurrentByDepartmentTeamCode(DbContext, DocumentLevelSetting.DepartmentCode))

                                ElseIf String.IsNullOrWhiteSpace(DocumentLevelSetting.OfficeCode) = False AndAlso String.IsNullOrWhiteSpace(DocumentLevelSetting.DepartmentCode) = True Then

                                    AgencyDesktopDocuments.AddRange(AdvantageFramework.Database.Procedures.AgencyDesktopDocument.LoadCurrentByOfficeCode(DbContext, DocumentLevelSetting.OfficeCode))

                                ElseIf String.IsNullOrWhiteSpace(DocumentLevelSetting.OfficeCode) = False AndAlso String.IsNullOrWhiteSpace(DocumentLevelSetting.DepartmentCode) = False Then

                                    AgencyDesktopDocuments.AddRange(AdvantageFramework.Database.Procedures.AgencyDesktopDocument.LoadCurrentByOfficeCodeAndDepartmentTeamCode(DbContext, DocumentLevelSetting.OfficeCode, DocumentLevelSetting.DepartmentCode))

                                End If

                            Next

                            DocumentIDs = AgencyDesktopDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

                            If AllowPrivateAccess = False Then

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID) AndAlso
                                                      (Document.IsPrivate Is Nothing OrElse
                                                       Document.IsPrivate = 0)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.AgencyDesktop)).ToList

                            Else

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.AgencyDesktop)).ToList

                            End If

                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                        End Try

                    End Using

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadAgencyDesktopDocuments = DocumentList

        End Function
        Public Function LoadRelatedAgencyDesktopDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                          ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim AgencyDesktopDocument As AdvantageFramework.Database.Entities.AgencyDesktopDocument = Nothing
            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.AgencyDesktopDocument) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs() As Long = Nothing

            Try

                AgencyDesktopDocument = AdvantageFramework.Database.Procedures.AgencyDesktopDocument.LoadByDocumentID(DbContext, DocumentID)

                If AgencyDesktopDocument IsNot Nothing Then

                    RelatedDocuments = AdvantageFramework.Database.Procedures.AgencyDesktopDocument.LoadRelated(DbContext, FileName, AgencyDesktopDocument.OfficeCode, AgencyDesktopDocument.DepartmentTeamCode).ToList

                    DocumentIDs = RelatedDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                    Where DocumentIDs.Contains(Entity.ID)
                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.AgencyDesktop)).ToList

                End If

            Catch ex As Exception
                DocumentList = Nothing
            Finally
                LoadRelatedAgencyDesktopDocuments = DocumentList
            End Try

        End Function
        Public Function DeleteAgencyDesktopDocument(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            DeleteAgencyDesktopDocument = AdvantageFramework.Database.Procedures.AgencyDesktopDocument.Delete(DbContext, DocumentID)

        End Function

#End Region

#Region "  Executive Desktop Documents "

        Public Function LoadExecutiveDesktopDocuments(ByVal Session As AdvantageFramework.Security.Session,
                                                      ByVal DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting),
                                                      ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim ExecutiveDesktopDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ExecutiveDesktopDocument) = Nothing
            Dim DocumentIDs() As Long = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim ExecutiveDesktopCodes As IEnumerable(Of String) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            ExecutiveDesktopDocuments = New Generic.List(Of AdvantageFramework.Database.Entities.ExecutiveDesktopDocument)

                            For Each DocumentLevelSetting In DocumentLevelSettings

                                If String.IsNullOrWhiteSpace(DocumentLevelSetting.OfficeCode) = True AndAlso String.IsNullOrWhiteSpace(DocumentLevelSetting.EmployeeCode) = True Then

                                    ExecutiveDesktopDocuments.AddRange(AdvantageFramework.Database.Procedures.ExecutiveDesktopDocument.LoadCurrent(DbContext))

                                ElseIf String.IsNullOrWhiteSpace(DocumentLevelSetting.OfficeCode) = True AndAlso String.IsNullOrWhiteSpace(DocumentLevelSetting.EmployeeCode) = False Then

                                    ExecutiveDesktopDocuments.AddRange(AdvantageFramework.Database.Procedures.ExecutiveDesktopDocument.LoadCurrentByEmployeeCode(DbContext, DocumentLevelSetting.EmployeeCode))

                                ElseIf String.IsNullOrWhiteSpace(DocumentLevelSetting.OfficeCode) = False AndAlso String.IsNullOrWhiteSpace(DocumentLevelSetting.EmployeeCode) = True Then

                                    ExecutiveDesktopDocuments.AddRange(AdvantageFramework.Database.Procedures.ExecutiveDesktopDocument.LoadCurrentByOfficeCode(DbContext, DocumentLevelSetting.OfficeCode))

                                ElseIf String.IsNullOrWhiteSpace(DocumentLevelSetting.OfficeCode) = False AndAlso String.IsNullOrWhiteSpace(DocumentLevelSetting.EmployeeCode) = False Then

                                    ExecutiveDesktopDocuments.AddRange(AdvantageFramework.Database.Procedures.ExecutiveDesktopDocument.LoadCurrentByOfficeCodeAndEmployeeCode(DbContext, DocumentLevelSetting.OfficeCode, DocumentLevelSetting.EmployeeCode))

                                End If

                            Next

                            DocumentIDs = ExecutiveDesktopDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

                            If AllowPrivateAccess = False Then

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID) AndAlso
                                                      (Document.IsPrivate Is Nothing OrElse
                                                       Document.IsPrivate = 0)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.ExecutiveDesktop)).ToList

                            Else

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.ExecutiveDesktop)).ToList

                            End If

                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                        End Try

                    End Using

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadExecutiveDesktopDocuments = DocumentList

        End Function
        Public Function LoadRelatedExecutiveDesktopDocuments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                          ByVal DocumentID As Integer, ByVal FileName As String) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim ExecutiveDesktopDocument As AdvantageFramework.Database.Entities.ExecutiveDesktopDocument = Nothing
            Dim RelatedDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ExecutiveDesktopDocument) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIDs() As Long = Nothing

            Try

                ExecutiveDesktopDocument = AdvantageFramework.Database.Procedures.ExecutiveDesktopDocument.LoadByDocumentID(DbContext, DocumentID)

                If ExecutiveDesktopDocument IsNot Nothing Then

                    RelatedDocuments = AdvantageFramework.Database.Procedures.ExecutiveDesktopDocument.LoadRelated(DbContext, FileName, ExecutiveDesktopDocument.OfficeCode, ExecutiveDesktopDocument.EmployeeCode).ToList

                    DocumentIDs = RelatedDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

                    DocumentList = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                    Where DocumentIDs.Contains(Entity.ID)
                                    Select Entity).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.ExecutiveDesktop)).ToList

                End If

            Catch ex As Exception
                DocumentList = Nothing
            Finally
                LoadRelatedExecutiveDesktopDocuments = DocumentList
            End Try

        End Function
        Public Function DeleteExecutiveDesktopDocument(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As Boolean

            DeleteExecutiveDesktopDocument = AdvantageFramework.Database.Procedures.ExecutiveDesktopDocument.Delete(DbContext, DocumentID)

        End Function

#End Region

#End Region

#Region " Document Labels "

        Public Function LoadLabelDocumentsByJobNumberAndJobComponentNumber(ByVal Session As AdvantageFramework.Security.Session,
                                                                           ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                                                           ByVal AllowPrivateAccess As Boolean,
                                                                           Optional ByVal LabelID As Long = 0) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim DocumentIDs() As Long = Nothing
            Dim LabelIDs() As Long = Nothing

            Dim DocumentManagerDocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim LabelDocumentList As Generic.List(Of AdvantageFramework.Database.Entities.LabelDocument) = Nothing
            Dim LabelList As Generic.List(Of AdvantageFramework.Database.Entities.Label) = Nothing

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                If LabelID = 0 Then

                    DocumentIDs = (From JobComponentDocument In AdvantageFramework.Database.Procedures.JobComponentDocument.LoadByJobNumberAndJobComponentNumber(DataContext, JobNumber, JobComponentNumber).ToList
                                   Select JobComponentDocument.DocumentID).ToArray

                Else

                    DocumentIDs = (From JobComponentDocument In AdvantageFramework.Database.Procedures.JobComponentDocument.LoadByJobNumberAndJobComponentNumber(DataContext, JobNumber, JobComponentNumber)
                                   Join LabelDocuments In DataContext.LabelDocuments On LabelDocuments.DocumentID Equals JobComponentDocument.DocumentID
                                   Where LabelDocuments.LabelID = LabelID
                                   Select JobComponentDocument.DocumentID).ToArray

                End If

                LoadLabelListAndLabelDocumentList(Session, DocumentIDs, LabelIDs, LabelList, LabelDocumentList)

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If AllowPrivateAccess = True Then

                        DocumentManagerDocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                       Where DocumentIDs.Contains(Document.ID)
                                                       Select Document).ToList().Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document,
                                                                                                                                                               LabelList,
                                                                                                                                                               LabelDocumentList)).ToList()

                    Else

                        DocumentManagerDocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                       Where DocumentIDs.Contains(Document.ID) AndAlso
                                                       (Document.IsPrivate Is Nothing OrElse
                                                       Document.IsPrivate = 0)
                                                       Select Document).ToList().Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document,
                                                                                                                                                               LabelList,
                                                                                                                                                               LabelDocumentList)).ToList()

                    End If


                End Using

            End Using

            If DocumentManagerDocumentList Is Nothing Then DocumentManagerDocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            LoadLabelDocumentsByJobNumberAndJobComponentNumber = DocumentManagerDocumentList

        End Function
        Public Function LoadDocumentsByLabelID(ByVal Session As AdvantageFramework.Security.Session, ByVal Label_ID As Integer, ByVal AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim DocumentIDs() As Long = Nothing
            Dim LabelIDs() As Long = Nothing

            Dim DocumentManagerDocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim LabelDocumentList As Generic.List(Of AdvantageFramework.Database.Entities.LabelDocument) = Nothing
            Dim LabelList As Generic.List(Of AdvantageFramework.Database.Entities.Label) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    DocumentIDs = (From Entity In AdvantageFramework.Database.Procedures.LabelDocument.LoadByLabelID(DataContext, Label_ID)
                                   Select Entity.DocumentID).Distinct().ToArray()

                    LoadLabelListAndLabelDocumentList(Session, DocumentIDs, LabelIDs, LabelList, LabelDocumentList)
                    ''LabelDocumentList = (From Entity In AdvantageFramework.Database.Procedures.LabelDocument.LoadByDocumentIDs(DataContext, DocumentIDs)).ToList()

                    ''LabelIDs = (From Entity In LabelDocumentList
                    ''            Select Entity.LabelID).Distinct().ToArray()

                    ''LabelList = (From Entity In AdvantageFramework.Database.Procedures.Label.LoadByLabelIDs(DataContext, LabelIDs)).ToList()

                    If AllowPrivateAccess = True Then

                        DocumentManagerDocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                       Where DocumentIDs.Contains(Document.ID)
                                                       Select Document).ToList().Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, LabelList, LabelDocumentList)).Distinct.ToList()

                    Else

                        DocumentManagerDocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                       Where DocumentIDs.Contains(Document.ID) AndAlso
                                                      (Document.IsPrivate Is Nothing OrElse
                                                       Document.IsPrivate = 0)
                                                       Select Document).ToList().Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, LabelList, LabelDocumentList)).Distinct.ToList()

                    End If

                End Using

            End Using

            If DocumentManagerDocumentList Is Nothing Then DocumentManagerDocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            LoadDocumentsByLabelID = DocumentManagerDocumentList

        End Function
        Public Function LoadLabelListAndLabelDocumentList(ByVal Session As AdvantageFramework.Security.Session,
                                                          ByRef DocumentIDs() As Long,
                                                          ByRef LabelIDs() As Long,
                                                          ByRef LabelList As Generic.List(Of AdvantageFramework.Database.Entities.Label),
                                                          ByRef LabelDocumentList As Generic.List(Of AdvantageFramework.Database.Entities.LabelDocument)) As Boolean

            Try

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    LabelDocumentList = (From Entity In AdvantageFramework.Database.Procedures.LabelDocument.LoadByDocumentIDs(DataContext, DocumentIDs)).ToList()

                    LabelIDs = (From Entity In LabelDocumentList
                                Join Labels In DataContext.Labels On Entity.LabelID Equals Labels.ID
                                Where (Labels.IsInactive Is Nothing OrElse Labels.IsInactive = 0)
                                Select Entity.LabelID).Distinct().ToArray()

                    LabelList = (From Entity In AdvantageFramework.Database.Procedures.Label.LoadByLabelIDs(DataContext, LabelIDs)).ToList()

                End Using

                Return True

            Catch ex As Exception

                Return False

            End Try

        End Function

#End Region

#Region "  Media Order Documents "

        Public Function LoadMediaOrderDocuments(Session As AdvantageFramework.Security.Session,
                                           DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting),
                                           AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim OrderDocuments As Generic.List(Of AdvantageFramework.Database.Views.OrderDocument) = Nothing
            Dim OrderNumbers As IEnumerable(Of Integer) = Nothing
            Dim DocumentIDs() As Long = Nothing
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            OrderNumbers = DocumentLevelSettings.Where(Function(Entity) Entity.OrderNumber <> "").Select(Function(Entity) CInt(Entity.OrderNumber)).ToArray

                            OrderDocuments = (From OrderDocument In AdvantageFramework.Database.Procedures.OrderDocument.LoadCurrentByOrderNumbers(DbContext, OrderNumbers).ToList
                                              Where DocumentLevelSettings.Where(Function(DocumentLevelSetting) DocumentLevelSetting.OrderNumber = OrderDocument.OrderNumber).Any
                                              Select OrderDocument).ToList

                            DocumentIDs = OrderDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

                            If AllowPrivateAccess = False Then

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID) AndAlso
                                                      (Document.IsPrivate Is Nothing OrElse
                                                       Document.IsPrivate = 0)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.MediaOrder)).ToList

                            Else

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.MediaOrder)).ToList

                            End If

                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                        End Try

                    End Using

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadMediaOrderDocuments = DocumentList

        End Function
        Public Function DeleteMediaOrderDocument(DbContext As AdvantageFramework.Database.DbContext, DocumentID As Integer) As Boolean

            DeleteMediaOrderDocument = AdvantageFramework.Database.Procedures.OrderDocument.Delete(DbContext, DocumentID)

        End Function

#End Region

#Region "  Alert Documents "

        Public Function LoadAlertDocuments(Session As AdvantageFramework.Security.Session,
                                           DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting),
                                           AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim AlertAttachments As Generic.List(Of AdvantageFramework.Database.Entities.AlertAttachment) = Nothing
            Dim AlertIDs As IEnumerable(Of Integer) = Nothing
            Dim DocumentIDs() As Long = Nothing
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            AlertIDs = DocumentLevelSettings.Where(Function(Entity) Entity.AlertID <> "").Select(Function(Entity) CInt(Entity.AlertID)).ToArray

                            AlertAttachments = (From AlertDocument In AdvantageFramework.Database.Procedures.AlertAttachment.Load(DbContext).ToList
                                                Where AlertIDs.Contains(AlertDocument.AlertID)
                                                Select AlertDocument).ToList

                            DocumentIDs = AlertAttachments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

                            If AllowPrivateAccess = False Then

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID) AndAlso
                                                      (Document.IsPrivate Is Nothing OrElse
                                                       Document.IsPrivate = 0)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.AlertAttachment)).ToList

                            Else

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.AlertAttachment)).ToList

                            End If

                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                        End Try

                    End Using

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadAlertDocuments = DocumentList

        End Function

#End Region

#Region "  Media Traffic Detail Documents "

        Public Function LoadMediaTrafficDetailDocuments(Session As AdvantageFramework.Security.Session,
                                                        DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting),
                                                        AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim MediaTrafficDetailDocuments As Generic.List(Of AdvantageFramework.Database.Entities.MediaTrafficDetailDocument) = Nothing
            'Dim MediaTrafficDetailIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaTrafficDetailID As Integer = 0
            Dim DocumentIDs() As Long = Nothing
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            'MediaTrafficDetailIDs = DocumentLevelSettings.Where(Function(Entity) Entity.MediaTrafficDetailID <> "").Select(Function(Entity) CInt(Entity.MediaTrafficDetailID)).ToArray
                            MediaTrafficDetailID = DocumentLevelSettings.Where(Function(Entity) Entity.MediaTrafficDetailID <> "").Select(Function(Entity) CInt(Entity.MediaTrafficDetailID)).FirstOrDefault

                            MediaTrafficDetailDocuments = (From MediaTrafficDetailDocument In AdvantageFramework.Database.Procedures.MediaTrafficDetailDocument.LoadByMediaTrafficDetailID(DbContext, MediaTrafficDetailID).ToList
                                                           Where DocumentLevelSettings.Where(Function(DocumentLevelSetting) DocumentLevelSetting.MediaTrafficDetailID = MediaTrafficDetailDocument.MediaTrafficDetailID).Any
                                                           Select MediaTrafficDetailDocument).ToList

                            DocumentIDs = MediaTrafficDetailDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

                            If AllowPrivateAccess = False Then

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID) AndAlso
                                                      (Document.IsPrivate Is Nothing OrElse
                                                       Document.IsPrivate = 0)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.MediaOrder)).ToList

                            Else

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.MediaOrder)).ToList

                            End If

                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                        End Try

                    End Using

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadMediaTrafficDetailDocuments = DocumentList

        End Function
        Public Function DeleteMediaTrafficDetailDocument(DbContext As AdvantageFramework.Database.DbContext, DocumentID As Integer, MediaTrafficDetailID As Integer) As Boolean

            DeleteMediaTrafficDetailDocument = AdvantageFramework.Database.Procedures.MediaTrafficDetailDocument.Delete(DbContext, DocumentID, MediaTrafficDetailID)

        End Function

#End Region

#Region "  Journal Entry Documents "

        Public Function LoadJournalEntryDocuments(Session As AdvantageFramework.Security.Session,
                                                  DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting),
                                                  AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim GeneralLedgerDocuments As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerDocument) = Nothing
            'Dim JournalEntryIDs As IEnumerable(Of Integer) = Nothing
            Dim GLTransaction As Integer = 0
            Dim DocumentIDs() As Long = Nothing
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            'MediaTrafficDetailIDs = DocumentLevelSettings.Where(Function(Entity) Entity.MediaTrafficDetailID <> "").Select(Function(Entity) CInt(Entity.MediaTrafficDetailID)).ToArray
                            GLTransaction = DocumentLevelSettings.Where(Function(Entity) Entity.GLTransaction <> "").Select(Function(Entity) CInt(Entity.GLTransaction)).FirstOrDefault

                            GeneralLedgerDocuments = (From GeneralLedgerDocument In AdvantageFramework.Database.Procedures.GeneralLedgerDocument.LoadByGLTransaction(DbContext, GLTransaction).ToList
                                                      Where DocumentLevelSettings.Where(Function(DocumentLevelSetting) DocumentLevelSetting.GLTransaction = GeneralLedgerDocument.GLTransaction).Any
                                                      Select GeneralLedgerDocument).ToList

                            DocumentIDs = GeneralLedgerDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

                            If AllowPrivateAccess = False Then

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID) AndAlso
                                                      (Document.IsPrivate Is Nothing OrElse
                                                       Document.IsPrivate = 0)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.MediaOrder)).ToList

                            Else

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.MediaOrder)).ToList

                            End If

                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                        End Try

                    End Using

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadJournalEntryDocuments = DocumentList

        End Function
        Public Function DeleteJournalEntryDocument(DbContext As AdvantageFramework.Database.DbContext, DocumentID As Integer) As Boolean

            DeleteJournalEntryDocument = AdvantageFramework.Database.Procedures.GeneralLedgerDocument.Delete(DbContext, DocumentID)

        End Function

#End Region

#Region "  Media Plan Documents "

        Public Function LoadMediaPlanDocuments(Session As AdvantageFramework.Security.Session,
                                               DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting),
                                               AllowPrivateAccess As Boolean) As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            'objects
            Dim MediaPlanDocuments As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDocument) = Nothing
            Dim MediaPlanID As Integer = 0
            Dim DocumentIDs() As Long = Nothing
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing

            If DocumentLevelSettings IsNot Nothing AndAlso DocumentLevelSettings.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            MediaPlanID = DocumentLevelSettings.Where(Function(Entity) Entity.MediaPlanID <> "").Select(Function(Entity) CInt(Entity.MediaPlanID)).FirstOrDefault

                            MediaPlanDocuments = (From MediaPlanDocument In AdvantageFramework.Database.Procedures.MediaPlanDocument.LoadByMediaPlanID(DbContext, MediaPlanID).ToList
                                                  Where DocumentLevelSettings.Where(Function(DocumentLevelSetting) DocumentLevelSetting.MediaPlanID = MediaPlanDocument.MediaPlanID).Any
                                                  Select MediaPlanDocument).ToList

                            DocumentIDs = MediaPlanDocuments.Select(Function(Entity) CLng(Entity.DocumentID)).ToArray

                            If AllowPrivateAccess = False Then

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID) AndAlso
                                                      (Document.IsPrivate Is Nothing OrElse
                                                       Document.IsPrivate = 0)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.MediaPlan)).ToList

                            Else

                                DocumentList = (From Document In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                Where DocumentIDs.Contains(Document.ID)
                                                Select Document).ToList.Select(Function(Document) New AdvantageFramework.DocumentManager.Classes.Document(Document, Database.Entities.DocumentLevel.MediaPlan)).ToList

                            End If

                        Catch ex As Exception
                            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
                        End Try

                    End Using

                End Using

            Else

                DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            End If

            LoadMediaPlanDocuments = DocumentList

        End Function
        Public Function DeleteMediaPlanDocument(DbContext As AdvantageFramework.Database.DbContext, DocumentID As Integer, MediaPlanID As Integer) As Boolean

            DeleteMediaPlanDocument = AdvantageFramework.Database.Procedures.MediaPlanDocument.Delete(DbContext, MediaPlanID)

        End Function

#End Region

#End Region

    End Module

End Namespace
