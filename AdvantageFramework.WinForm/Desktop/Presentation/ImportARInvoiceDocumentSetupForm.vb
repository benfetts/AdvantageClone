Namespace Desktop.Presentation

    Public Class ImportARInvoiceDocumentSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _AgencyImportPath As String = ""
        Private _IsAgencyASP As Boolean = False
        Private _ImportARInvoiceDocuments As Generic.List(Of AdvantageFramework.FileSystem.Classes.ImportARInvoiceDocument) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_Documents.DataSource = _ImportARInvoiceDocuments

            DataGridViewForm_Documents.CurrentView.BestFitColumns()

        End Sub
        Private Sub UploadDocument(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal Employee As AdvantageFramework.Database.Views.Employee, ByVal ImportARInvoiceDocument As AdvantageFramework.FileSystem.Classes.ImportARInvoiceDocument)

            'objects
            Dim Uploaded As Boolean = False
            Dim FileName As String = Nothing
            Dim FileSystemFile As String = Nothing
            Dim FileSystemFileName As String = Nothing
            Dim FileSize As Integer = Nothing
            Dim MimeType As String = Nothing
            Dim FinalLevelDescription As String = Nothing
            Dim FinalLevel As String = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim AccountReceivableDocument As AdvantageFramework.Database.Entities.AccountReceivableDocument = Nothing
            Dim IsValid As Boolean = True
            Dim ErrorMessage As String = Nothing

            If ImportARInvoiceDocument.HasError = False Then

                Try

                    FileName = ImportARInvoiceDocument.FileInfo.Name
                    MimeType = AdvantageFramework.FileSystem.GetMIMEType(ImportARInvoiceDocument.FileInfo)
                    FileSize = AdvantageFramework.FileSystem.GetFileSize(ImportARInvoiceDocument.FileInfo)
                    FinalLevelDescription = AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice.ToString & ":" & ImportARInvoiceDocument.InvoiceNumber
                    FinalLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice.ToString

                    If AdvantageFramework.FileSystem.Add(Agency, ImportARInvoiceDocument.FileInfo.FullName, "Invoice", "Invoice", If(Employee IsNot Nothing, Employee.ToString, Me.Session.UserCode), FinalLevel, FinalLevelDescription, FileSystem.DocumentSource.DocumentUpload, FileSystemFile, Nothing, FileSystemFileName) Then

                        Document = New AdvantageFramework.Database.Entities.Document

                        Document.DbContext = DbContext
                        Document.FileName = FileName
                        Document.FileSystemFileName = FileSystemFileName
                        Document.MIMEType = MimeType
                        Document.Description = "Invoice"
                        Document.Keywords = "Invoice"
                        Document.UploadedDate = System.DateTime.Now
                        Document.UserCode = Me.Session.UserCode
                        Document.FileSize = FileSize
                        Document.DocumentTypeID = 1
                        Document.IsPrivate = False

                        If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then

                            AccountReceivableDocument = New AdvantageFramework.Database.Entities.AccountReceivableDocument

                            AccountReceivableDocument.DocumentID = Document.ID
                            AccountReceivableDocument.InvoiceNumber = ImportARInvoiceDocument.InvoiceNumber
                            AccountReceivableDocument.SequenceNumber = ImportARInvoiceDocument.SequenceNumber
                            AccountReceivableDocument.Type = ImportARInvoiceDocument.Type

                            Uploaded = AdvantageFramework.Database.Procedures.AccountReceivableDocument.Insert(DbContext, AccountReceivableDocument)

                        End If

                    End If

                Catch ex As Exception
                    Uploaded = False
                End Try

                If Uploaded Then

                    _ImportARInvoiceDocuments.Remove(ImportARInvoiceDocument)

                End If

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Import.Enabled = DataGridViewForm_Documents.HasRows
            ButtonItemImport_SelectedRows.Enabled = DataGridViewForm_Documents.HasASelectedRow
            ButtonItemImport_AllRows.Enabled = DataGridViewForm_Documents.HasRows
            ButtonItemActions_Delete.Enabled = DataGridViewForm_Documents.HasASelectedRow

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ImportARInvoiceDocumentSetupForm As Presentation.ImportARInvoiceDocumentSetupForm = Nothing

            ImportARInvoiceDocumentSetupForm = New Presentation.ImportARInvoiceDocumentSetupForm()

            ImportARInvoiceDocumentSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ImportARInvoiceDocumentSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_SelectFiles.Image = AdvantageFramework.My.Resources.DocumentFindImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage

            DataGridViewForm_Documents.AutoFilterLookupColumns = True

            _ImportARInvoiceDocuments = New Generic.List(Of AdvantageFramework.FileSystem.Classes.ImportARInvoiceDocument)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                If _IsAgencyASP Then

                    _AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext), "\")

                    If My.Computer.FileSystem.DirectoryExists(_AgencyImportPath) Then

                        _AgencyImportPath = _AgencyImportPath & "Reports\"

                    End If

                End If

            End Using

            LoadGrid()

        End Sub
        Private Sub ImportARInvoiceDocumentSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            EnableOrDisableActions()

            RibbonBarOptions_Actions.ResetCachedContentSize()

            RibbonBarOptions_Actions.Refresh()

            RibbonBarOptions_Actions.Width = RibbonBarOptions_Actions.GetAutoSizeWidth

            RibbonBarOptions_Actions.Refresh()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemImport_AllRows_Click(sender As Object, e As EventArgs) Handles ButtonItemImport_AllRows.Click

            'objects
            Dim ImportARInvoiceDocument As AdvantageFramework.FileSystem.Classes.ImportARInvoiceDocument = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            DataGridViewForm_Documents.ValidateAllRows()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode)

                For Each ImportARInvoiceDocument In DataGridViewForm_Documents.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.FileSystem.Classes.ImportARInvoiceDocument).ToList

                    UploadDocument(DbContext, Agency, Employee, ImportARInvoiceDocument)

                Next

            End Using

            LoadGrid()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemImport_SelectedRows_Click(sender As Object, e As EventArgs) Handles ButtonItemImport_SelectedRows.Click

            'objects
            Dim ImportARInvoiceDocument As AdvantageFramework.FileSystem.Classes.ImportARInvoiceDocument = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            DataGridViewForm_Documents.ValidateAllRows()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode)

                For Each ImportARInvoiceDocument In DataGridViewForm_Documents.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.FileSystem.Classes.ImportARInvoiceDocument).ToList

                    UploadDocument(DbContext, Agency, Employee, ImportARInvoiceDocument)

                Next

            End Using

            LoadGrid()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            For Each ImportARInvoiceDocument In DataGridViewForm_Documents.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.FileSystem.Classes.ImportARInvoiceDocument).ToList

                _ImportARInvoiceDocuments.Remove(ImportARInvoiceDocument)

            Next

            LoadGrid()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_SelectFiles_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_SelectFiles.Click

            'objects
            Dim Files() As String = Nothing
            Dim FileName As String = ""
            Dim InvoiceNumber As Integer = 0
            Dim SequenceNumber As Short = 0
            Dim Client As String = ""
            Dim ImportARInvoiceDocument As AdvantageFramework.FileSystem.Classes.ImportARInvoiceDocument = Nothing
            Dim FileInfo As System.IO.FileInfo = Nothing
            Dim AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable = Nothing

            If _IsAgencyASP Then

                AdvantageFramework.WinForm.Presentation.FolderBrowserDialog.ShowFormDialog(_AgencyImportPath, Nothing, True, Files)

            Else

                Files = AdvantageFramework.WinForm.Presentation.SelectFilesToOpen(, , "Select AR Invoice Files...")

            End If

            If Files IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each File In Files

                        If System.IO.File.Exists(File) Then

                            FileInfo = New System.IO.FileInfo(File)

                            Try

                                InvoiceNumber = FileInfo.Name.Substring(0, 9)
                                SequenceNumber = FileInfo.Name.Substring(10, 3)

                            Catch ex As Exception
                                InvoiceNumber = 0
                                SequenceNumber = 0
                            End Try

                            Try

                                AccountReceivable = AdvantageFramework.Database.Procedures.AccountReceivable.LoadByInvoiceNumberAndSequenceNumber(DbContext, InvoiceNumber, SequenceNumber)

                            Catch ex As Exception
                                AccountReceivable = Nothing
                            End Try

                            If AccountReceivable IsNot Nothing Then

                                _ImportARInvoiceDocuments.Add(New AdvantageFramework.FileSystem.Classes.ImportARInvoiceDocument(FileInfo, AccountReceivable.InvoiceNumber, AccountReceivable.SequenceNumber, AccountReceivable.Type, AccountReceivable.ClientCode))

                            Else

                                _ImportARInvoiceDocuments.Add(New AdvantageFramework.FileSystem.Classes.ImportARInvoiceDocument(FileInfo, 0, 0, "", ""))

                            End If

                        End If

                    Next

                End Using

                LoadGrid()

                DataGridViewForm_Documents.ValidateAllRows()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewForm_Documents_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_Documents.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
