Namespace WinForm.Presentation

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum FormActions
            [None]
            [Saving]
            [Deleting]
            [Adding]
            [Clearing]
            [Modifying]
            [Refreshing]
            [Loading]
            [LoadingSelectedItem]
            [Printing]
            [Copying]
            [Recalculating]
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function TakeScreenCapture(ByVal Form As System.Windows.Forms.Form,
                                          Optional ByVal Desktop As Boolean = False) As System.Drawing.Image

            'objects
            Dim Image As System.Drawing.Bitmap = Nothing
            Dim ScreenShot As System.Drawing.Graphics = Nothing
            Dim Bounds As System.Drawing.Rectangle = Nothing
            Dim Screen As System.Windows.Forms.Screen = Nothing

            Form.BringToFront()

            If Form.IsMdiContainer Then

                Bounds = Form.Bounds

            ElseIf Form.MdiParent IsNot Nothing Then

                Bounds = Form.MdiParent.Bounds

            Else

                Bounds = Form.Bounds

            End If

            If Desktop Then

                Bounds = System.Windows.Forms.Screen.GetBounds(Form.Location)

            End If

            Try

                Image = New System.Drawing.Bitmap(Bounds.Width, Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                ' Create a Graphics object that will process the screen shot
                ScreenShot = System.Drawing.Graphics.FromImage(Image)
                ' Copy the screen contents
                ScreenShot.CopyFromScreen(Bounds.X, Bounds.Y, 0, 0, Bounds.Size, System.Drawing.CopyPixelOperation.SourceCopy)

            Catch win32Ex As System.ComponentModel.Win32Exception
                Image = Nothing
            Catch ex As Exception
                Image = Nothing
            End Try

            TakeScreenCapture = Image

        End Function
        Public Sub ShowWaitForm(Optional ByVal DisplayText As String = Nothing, Optional ByVal ParentForm As System.Windows.Forms.Form = Nothing)

            If DevExpress.XtraSplashScreen.SplashScreenManager.Default Is Nothing Then

                If ParentForm IsNot Nothing Then

                    DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(ParentForm, GetType(AdvantageFramework.WinForm.Presentation.WaitForm))

                Else

                    DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(GetType(AdvantageFramework.WinForm.Presentation.WaitForm))

                End If

            End If

            If DevExpress.XtraSplashScreen.SplashScreenManager.Default IsNot Nothing AndAlso String.IsNullOrEmpty(DisplayText) = False Then

                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormDescription(DisplayText)

            End If

        End Sub
        Public Sub CloseWaitForm()

            If DevExpress.XtraSplashScreen.SplashScreenManager.Default IsNot Nothing Then

                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()

            End If

        End Sub
        Public Function SelectFilesToOpen(Optional ByVal StartingFolderName As String = "",
                                          Optional ByVal FileFilter As String = "All Files (*.*)|*.*",
                                          Optional ByVal DefaultTitleText As String = "Select a File to Open...") As String()

            'objects
            Dim OpenFileDialog As System.Windows.Forms.OpenFileDialog = Nothing
            Dim Files() As String = Nothing

            Try

                AdvantageFramework.Registry.SetEnabledLinkedConnections()

            Catch ex As Exception

            End Try

            OpenFileDialog = New System.Windows.Forms.OpenFileDialog()

            OpenFileDialog.AddExtension = False
            OpenFileDialog.AutoUpgradeEnabled = True
            OpenFileDialog.CheckPathExists = True
            OpenFileDialog.Filter = FileFilter
            OpenFileDialog.RestoreDirectory = True
            OpenFileDialog.Title = DefaultTitleText
            OpenFileDialog.Multiselect = True

            If System.IO.Directory.Exists(StartingFolderName) Then

                OpenFileDialog.InitialDirectory = StartingFolderName

            End If

            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

                Files = OpenFileDialog.FileNames

            End If

            SelectFilesToOpen = Files

        End Function
        Public Function SelectFileToOpen(Optional ByVal StartingFolderName As String = "",
                                         Optional ByVal FileFilter As String = "All Files (*.*)|*.*",
                                         Optional ByVal DefaultTitleText As String = "Select a File to Open...") As String

            'objects
            Dim OpenFileDialog As System.Windows.Forms.OpenFileDialog = Nothing
            Dim File As String = ""

            Try

                AdvantageFramework.Registry.SetEnabledLinkedConnections()

            Catch ex As Exception

            End Try

            OpenFileDialog = New System.Windows.Forms.OpenFileDialog()

            OpenFileDialog.AddExtension = False
            OpenFileDialog.AutoUpgradeEnabled = True
            OpenFileDialog.CheckPathExists = True
            OpenFileDialog.Filter = FileFilter
            OpenFileDialog.RestoreDirectory = True
            OpenFileDialog.Title = DefaultTitleText
            OpenFileDialog.Multiselect = False

            If System.IO.Directory.Exists(StartingFolderName) Then

                OpenFileDialog.InitialDirectory = StartingFolderName

            End If

            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

                File = OpenFileDialog.FileName

            End If

            SelectFileToOpen = File

        End Function
        Public Function BrowseForFolder(ByRef Folder As String,
                                         Optional ByVal StartingFolderName As String = "",
                                         Optional ByVal Description As String = "Select a Folder") As Boolean

            'objects
            Dim FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog = Nothing
            Dim FolderSelected As Boolean = False

            Try

                AdvantageFramework.Registry.SetEnabledLinkedConnections()

            Catch ex As Exception

            End Try

            FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()

            FolderBrowserDialog.Description = Description
            FolderBrowserDialog.ShowNewFolderButton = True

            If System.IO.Directory.Exists(StartingFolderName) Then

                FolderBrowserDialog.SelectedPath = StartingFolderName

            ElseIf System.IO.File.Exists(StartingFolderName) Then

                FolderBrowserDialog.SelectedPath = (New System.IO.FileInfo(StartingFolderName)).DirectoryName

            End If

            If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

                Folder = FolderBrowserDialog.SelectedPath
                FolderSelected = True

            End If

            BrowseForFolder = FolderSelected

        End Function
        Private Sub OpenDocument(ByVal FileName As String, Optional ByVal Print As Boolean = False)

            'objects
            Dim ProcessStartInfo As ProcessStartInfo = Nothing

            Try

                If Not Print Then

                    Process.Start(FileName)

                Else

                    ProcessStartInfo = New ProcessStartInfo

                    With ProcessStartInfo
                        .Verb = "print"
                        .WindowStyle = ProcessWindowStyle.Hidden
                        .FileName = FileName
                        .UseShellExecute = True
                    End With

                    Process.Start(ProcessStartInfo)

                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Sub SaveDocument(ByVal Session As AdvantageFramework.Security.Session, ByVal Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document), Optional ByVal Print As Boolean = False,
                                Optional ByVal WebBrowserPrint As Windows.Forms.WebBrowser = Nothing)

            'objects
            Dim ErrorMessage As String = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim SaveToLocation As String = ""
            Dim SavedFileName As String = ""
            Dim NewFileName As String = ""
            Dim FileExists As Boolean = True
            Dim Counter As Integer = 0
            Dim ContinueSave As Boolean = False
            Dim IsURL As Boolean = False
            Dim Saved As Boolean = False
            Dim IsAgencyASP As Boolean = False
            Dim DocumentID As Integer = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency.IsASP.GetValueOrDefault(0) = 1 Then

                    IsAgencyASP = True

                End If

                If Documents.Count = 1 AndAlso Documents.FirstOrDefault.FileType = FileSystem.FileTypes.URL Then

                    IsURL = True

                Else

                    If IsAgencyASP = False Then

                        SaveToLocation = AdvantageFramework.FileSystem.GetDefaultNonHostedDownloadLocation()

                        If String.IsNullOrWhiteSpace(SaveToLocation) = False Then

                            ContinueSave = True

                        Else

                            If AdvantageFramework.WinForm.Presentation.BrowseForFolder(SaveToLocation) Then

                                ContinueSave = True

                            End If

                        End If

                    Else

                        SaveToLocation = AdvantageFramework.FileSystem.LoadHostedClientDownloadLocation(Agency)

                        ContinueSave = True

                    End If

                End If

                If ContinueSave OrElse IsURL Then

                    Try

                        If Documents.Count > 1 AndAlso Not Print Then

                            Using ZipFile = New Ionic.Zip.ZipFile

                                AdvantageFramework.DocumentManager.CreateZip(Agency, Documents, ZipFile)

                                SavedFileName = SaveToLocation & "\" & Documents.FirstOrDefault.FileName.Replace(New System.IO.FileInfo(Documents.FirstOrDefault.FileName).Extension, "")

                                Do While New System.IO.FileInfo(SavedFileName & ".zip").Exists

                                    SavedFileName = SavedFileName & "(" & Counter & ")"

                                    Counter = Counter + 1

                                Loop

                                SavedFileName = SavedFileName & ".zip"

                                ZipFile.Save(SavedFileName)

                                Saved = True

                            End Using

                            If IsAgencyASP = False Then

                                If AdvantageFramework.WinForm.MessageBox.Show("Your zip file has been downloaded at " & SaveToLocation & " " & System.Environment.NewLine & System.Environment.NewLine & "Would you like to open the zip file now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Download Complete") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                                    OpenDocument(SavedFileName)

                                End If

                            Else

                                If SendASPDocumentDownloadEmail(Session, Documents.FirstOrDefault.FileName, Documents.Select(Function(Entity) Entity.ID).ToArray) Then

                                    AdvantageFramework.WinForm.MessageBox.Show("Your zip file has been placed on the FTP in the Repository\Out folder and also email link has been sent to your email.")

                                Else

                                    AdvantageFramework.WinForm.MessageBox.Show("Your zip file has been placed on the FTP in the Repository\Out folder.")

                                End If

                            End If

                        Else

                            DocumentID = Documents.FirstOrDefault.ID

                            If IsURL Then

                                If IsAgencyASP = False Then

                                    If Print Then

                                        WebBrowserPrint.Navigate(New System.UriBuilder(Documents.FirstOrDefault.FileSystemFileName).Uri.AbsoluteUri)

                                    Else

                                        Process.Start(New System.UriBuilder(Documents.FirstOrDefault.FileSystemFileName).Uri.AbsoluteUri)

                                    End If

                                Else

                                    ErrorMessage = "Cannot open URL when in ASP mode."

                                End If

                            ElseIf IsAgencyASP AndAlso (From Entity In AdvantageFramework.Database.Procedures.AlertAttachment.Load(DbContext).Include("Alert")
                                                        Where Entity.DocumentID = DocumentID AndAlso
                                                              Entity.Alert.AlertCategoryID = AdvantageFramework.Database.Entities.AlertCategories.RFPGenerated
                                                        Select Entity).Any AndAlso
                                    AdvantageFramework.FileSystem.Download(Agency, Documents.FirstOrDefault, IO.Path.Combine(Agency.ImportPath, "AVAILS", DbContext.UserCode)) Then

                                If SendASPDocumentDownloadEmail(Session, Documents.FirstOrDefault.FileName, New Integer() {Documents.FirstOrDefault.ID}) Then

                                    AdvantageFramework.WinForm.MessageBox.Show("Your document(s) has been placed in the Avails folder and is ready for import.  An email link has also been sent to your email.")

                                Else

                                    AdvantageFramework.WinForm.MessageBox.Show("Your document(s) has been placed in the Avails folder and is ready for import.  An email link could not be sent.")

                                End If

                            ElseIf AdvantageFramework.FileSystem.Download(Agency, Documents.FirstOrDefault, SaveToLocation, NewFileName, FileExists) Then

                                SavedFileName = NewFileName

                                Saved = True

                                If IsAgencyASP = False Then

                                    If Print Then

                                        OpenDocument(SavedFileName, Print)

                                    Else

                                        OpenDocument(SavedFileName, Print)

                                    End If

                                Else

                                    If SendASPDocumentDownloadEmail(Session, Documents.FirstOrDefault.FileName, New Integer() {Documents.FirstOrDefault.ID}) Then

                                        AdvantageFramework.WinForm.MessageBox.Show("Your document(s) has been placed on the FTP in the Repository\Out folder and also email link has been sent to your email.")

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("Your document(s) has been placed on the FTP in the Repository\Out folder.")

                                    End If

                                End If

                            Else

                                If FileExists = False Then

                                    ErrorMessage = "The file you are trying to save no longer exists in document repository."

                                Else

                                    ErrorMessage = "There was a problem saving the file. Please contact software support."

                                End If

                            End If

                        End If

                    Catch ex As Exception
                        ErrorMessage = "There was a problem saving the file. Please contact software support."
                    End Try

                End If

            End Using

            If ErrorMessage <> "" Then

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Function SendASPDocumentDownloadEmail(Session As AdvantageFramework.Security.Session, FileName As String, DocumentIDs() As Integer) As Boolean

            'objects
            Dim EmailSent As Boolean = False
            Dim HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim WebvantageURL As String = ""
            Dim EmployeeEmailAddress As String = ""
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency IsNot Nothing Then

                    Try

                        EmployeeEmailAddress = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode).Email

                    Catch ex As Exception
                        EmployeeEmailAddress = ""
                    End Try

                    If String.IsNullOrWhiteSpace(EmployeeEmailAddress) = False Then

                        WebvantageURL = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.WebvantageURL, "/")

                        HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                        HtmlEmail.AddHeaderRow("Document Link")
                        HtmlEmail.AddCustomRow(Nothing, 3, Nothing, "#FF0000", "<a href=""" & WebvantageURL & "Document/DocumentDownload?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & Session.DatabaseName &
                                                                                                                                                                                             "&Date=" & Now.ToString("MM/dd/yyyy hh:mm:ss tt") &
                                                                                                                                                                                             "&Email=" & EmployeeEmailAddress &
                                                                                                                                                                                             "&FileName=" & FileName.Replace("&", "<>") &
                                                                                                                                                                                             "&DocumentIDs=" & Join(DocumentIDs.Select(Function(ID) CStr(ID)).ToArray, ",")) & "%7C"" > Click Here to download your document</a>")

                        HtmlEmail.AddBlankRow()
                        HtmlEmail.AddBlankRow()

                        HtmlEmail.Finish()

                        EmailSent = AdvantageFramework.Email.Send(DbContext, EmployeeEmailAddress, "", "", "Document Download - " & FileName, HtmlEmail.ToString, 3, New Generic.List(Of AdvantageFramework.Email.Classes.Attachment), SendingEmailStatus)

                    End If

                    End If

            End Using

            SendASPDocumentDownloadEmail = EmailSent

        End Function
		Public Function SendASPReportDownloadEmail(Session As AdvantageFramework.Security.Session, File As String) As Boolean

            SendASPReportDownloadEmail = AdvantageFramework.Email.SendASPReportDownloadEmail(Session, File)

        End Function
		Public Function SendASPUploadEmail(Session As AdvantageFramework.Security.Session, DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel,
										   DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            SendASPUploadEmail = AdvantageFramework.Email.SendASPUploadEmail(Session, DocumentLevel, DocumentSubLevel, DocumentLevelSetting)

        End Function

#End Region

	End Module

End Namespace
