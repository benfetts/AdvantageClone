Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Webvantage.cGlobals
Imports Webvantage.MiscFN

Public Class Documents_Upload
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private Level As String = ""
    Private ForiegnKey As String = ""
    Private Value As String = ""
    Private ConnectionString As String = ""
    Private emailGroup As String = ""
    Private ThisClient As String = ""
    Private ThisDivision As String = ""
    Private ThisProduct As String = ""
    Private ThisOffice As String = ""
    Private DOLevel As String = ""
    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0
    Private SequenceNumber As Integer = 0
    Private _Caller As String = ""
    Public FileSizeMax As Integer = 0
    Public currentWindowsIdentity As System.Security.Principal.WindowsIdentity

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "

    Private Sub ButtonAddRecipients_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAddRecipients.Click

        Dim ThisEmailGroup As String = ""

        Try
            If Me.IsClientPortal = True Then

                If Not _Session.ClientPortalUser.AlertGroupCode Is Nothing Then

                    ThisEmailGroup = _Session.ClientPortalUser.AlertGroupCode

                End If

            Else

                ThisEmailGroup = Me.emailGroup

            End If
            If Not ThisEmailGroup Is Nothing Then

                ThisEmailGroup = ThisEmailGroup.Replace("/", "-").Replace("&", "and").Replace(",", "_").Replace("'", "__")

            End If
        Catch ex As Exception

            ThisEmailGroup = ""

        End Try

        Dim URL As String = ""
        Dim ag As Integer = 0
        If Me.Level = AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation Then ag = 1

        Dim qs As New AdvantageFramework.Web.QueryString()

        qs.Page = "LookUp_Recipients.aspx"
        qs.JobNumber = Me.JobNumber
        qs.JobComponentNumber = Me.JobComponentNbr
        qs.EmailGroup = ThisEmailGroup
        qs.Add("ag", ag)
        qs.Add("NewAlertLevel", Me.Level)
        qs.Add("uac", "1")

        Me.OpenLookUpRecipients(qs.ToString(True))

    End Sub
    Private Sub ButtonClearRecipients_Click(sender As Object, e As EventArgs) Handles ButtonClearRecipients.Click

        Me.AutoCompleteRecipients.Clear()

    End Sub
    Protected Sub RadComboBoxFileOrLink_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadComboBoxFileOrLink.SelectedIndexChanged
        Select Case Me.RadComboBoxFileOrLink.SelectedValue
            Case "Link"

                Me.DivFile.Visible = False
                Me.DivLinkName.Visible = True
                Me.DivLinkURL.Visible = True
                Me.TextBoxLinkName.Visible = True
                Me.RequiredFieldValidatorLinkName.Enabled = True
                Me.RequiredFieldValidatorLinkURL.Enabled = True

            Case "File"

                Me.DivFile.Visible = True
                Me.DivLinkName.Visible = False
                Me.DivLinkURL.Visible = False
                Me.TextBoxLinkName.Visible = False
                Me.RequiredFieldValidatorLinkName.Enabled = False
                Me.RequiredFieldValidatorLinkURL.Enabled = False

        End Select
    End Sub
    Private Sub RadToolbarDocumentUpload_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDocumentUpload.ButtonClick
        Select Case e.Item.Value
            Case "Upload"

                Me.Validate(Me.RadComboBoxFileOrLink.SelectedValue)

                Dim strErr As String = ""
                Dim privateFlag As Integer = 0
                Dim FileUploadedSuccessfully As Boolean = True
                Dim Description As String = ""

                If Me.cbPrivate.Checked = True Then
                    privateFlag = 1
                Else
                    privateFlag = 0
                End If
                If Me.IsValid Then
                    Me.ConnectionString = Session("ConnString")
                    Dim documentID As Integer = 0
                    Dim documentIDs As String = ""
                    Select Case Me.RadComboBoxFileOrLink.SelectedValue
                        Case "File"
                            Try

                                If Me.RadUploadDocument.UploadedFiles.Count > 0 Then

                                    Dim currentWindowsIdentity1 As System.Security.Principal.WindowsIdentity
                                    Dim impersonationContext1 As System.Security.Principal.WindowsImpersonationContext

                                    If IsNTAuth = True Then

                                        Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                        impersonationContext1 = Me.currentWindowsIdentity.Impersonate()

                                    End If

                                    Dim documentRepository As New DocumentRepository(Me.ConnectionString, True)
                                    Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

                                    If IsNTAuth = True Then

                                        impersonationContext1.Undo()

                                    End If

                                    For i = 0 To Me.RadUploadDocument.UploadedFiles.Count - 1

                                        Dim HasMultipleUploads As Boolean = Me.RadUploadDocument.UploadedFiles.Count > 1

                                        If DocumentRepository.RadAsyncUploadFileTypeIsValid(Me.RadUploadDocument.UploadedFiles(i)) = False Then

                                            Me.ShowMessage("Invalid file type.")
                                            Exit Sub

                                        End If
                                        ' Read the uploaded file into a file stream for later
                                        Dim realFilename As String = Me.RadUploadDocument.UploadedFiles(i).GetName
                                        Dim MimeType As String = "" 'Me.RadUploadDocument.UploadedFiles(i).ContentType
                                        If Not Me.RadUploadDocument.UploadedFiles(i).ContentType Is Nothing Then
                                            MimeType = Me.RadUploadDocument.UploadedFiles(i).ContentType
                                        Else
                                            MimeType = ""
                                        End If
                                        Dim FileLength As Integer = Me.RadUploadDocument.UploadedFiles(i).InputStream.Length
                                        Dim DocumentManagerFilename As String

                                        If documentRepository.IsRepositoryLimitFeatureEnabled = True Then
                                            Dim ThisFC As New DocumentRepository.FileCompare
                                            ThisFC.FileByteLength = CType(FileLength, Long)
                                            If documentRepository.IsOverFileSizeLimit(ThisFC) = True Then
                                                Me.ShowMessage(ThisFC.ReturnMessageJS)
                                                Exit Sub
                                            End If
                                        End If
                                        Dim FileBytes(FileLength - 1) As Byte
                                        Me.RadUploadDocument.UploadedFiles(i).InputStream.Read(FileBytes, 0, FileLength)

                                        If Me.RadUploadDocument.UploadedFiles.Count >= 1 Then
                                            If RadioButtonListDocOptions.SelectedValue = "Description" Then
                                                Description = Me.TextBoxDescription.Text
                                            Else
                                                Description = Me.RadUploadDocument.UploadedFiles(i).GetNameWithoutExtension
                                            End If
                                        Else
                                            Description = Me.TextBoxDescription.Text
                                        End If

                                        Dim ThisFinalLevel As String = String.Empty
                                        Dim ThisFinalLevelDescript As String = String.Empty
                                        Select Case Me.Level.ToUpper()
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Abbreviation
                                                ThisFinalLevel = "Vendor"
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation
                                                ThisFinalLevel = "AR Invoice"
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation
                                                ThisFinalLevel = "Employee"
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Client.Abbreviation
                                                ThisFinalLevel = "Client"
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Office.Abbreviation
                                                ThisFinalLevel = "Office"
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Division.Abbreviation
                                                ThisFinalLevel = "Client,Division"
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Product.Abbreviation
                                                ThisFinalLevel = "Client,Division,Product"
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Job.Abbreviation
                                                ThisFinalLevel = "Job"
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation
                                                ThisFinalLevel = "Job,Job Component"
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Campaign.Abbreviation
                                                ThisFinalLevel = "Campaign"
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsPayableInvoice.Abbreviation
                                                ThisFinalLevel = "Vendor"
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.DesktopObject.Abbreviation
                                                Select Case Me.DOLevel
                                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation
                                                        ThisFinalLevel = "Agency Desktop"
                                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation
                                                        ThisFinalLevel = "Executive Desktop"
                                                End Select
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AdNumber.Abbreviation
                                                ThisFinalLevel = "Ad Number"
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseReceipt.Abbreviation
                                                ThisFinalLevel = "Expense Invoice"
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Contract.Abbreviation
                                                ThisFinalLevel = "Contract"
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ContractValueAdded.Abbreviation
                                                ThisFinalLevel = "Contract Value Added"
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ContractReport.Abbreviation
                                                ThisFinalLevel = "Contract Report"
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Task.Abbreviation
                                                ThisFinalLevel = "Task"

                                        End Select
                                        ThisFinalLevelDescript = ThisFinalLevel & ":" & Me.ForiegnKey

                                        Try

                                            'This line uses impersonation:
                                            DocumentManagerFilename = documentRepository.AddDocument(realFilename, FileBytes, Description, Me.TextBoxKeywords.Text, Session("EmployeeName"), ThisFinalLevel, ThisFinalLevelDescript, "d_")

                                        Catch ex As Exception
                                            FileUploadedSuccessfully = False
                                            strErr = "Error saving actual file."
                                        End Try

                                        Me.ConnectionString = Session("ConnString")

                                        If IsNTAuth = True Then ' And HasMultipleUploads = True Then

                                            Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                            impersonationContext1 = Me.currentWindowsIdentity.Impersonate()

                                        End If

                                        Try

                                            'Insert your code that runs under the security context of the authenticating user here.
                                            Select Case Me.Level
                                                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation,
                                                    AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Abbreviation,
                                                    AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Abbreviation
                                                    Dim uploadInfo As New ViewModels.DocumentUploadInfo()

                                                    uploadInfo.FileName = realFilename
                                                    uploadInfo.RepositoryFilename = DocumentManagerFilename
                                                    uploadInfo.Description = Description
                                                    uploadInfo.Keywords = Me.TextBoxKeywords.Text
                                                    uploadInfo.UserCode = Session("UserCode")
                                                    uploadInfo.FileSize = FileLength
                                                    uploadInfo.PrivateFlag = privateFlag
                                                    uploadInfo.DocumentTypeId = Me.RadComboBoxDocumentType.SelectedValue
                                                    uploadInfo.ForeignKey = Me.ForiegnKey
                                                    uploadInfo.Level = Me.Level

                                                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                                                        Dim documentRepo As New Repositories.DocumentRepository(DataContext)
                                                        uploadInfo = documentRepo.InsertAndLinkDocumentToLevel(uploadInfo)
                                                    End Using

                                                    If uploadInfo.DatabaseInsertSuccessful AndAlso uploadInfo.DocumentLinkSuccessful Then
                                                        documentID = uploadInfo.DocumentId
                                                    Else
                                                        Throw New Exception("There was a problem saving to the Repository; please make sure the Repository Settings are correct." & uploadInfo.LastUploadException.Message.ToString(), uploadInfo.LastUploadException)
                                                    End If
                                                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Client.Abbreviation
                                                    Dim newDocument As New ClientDocuments(Me.ConnectionString)
                                                    documentID = newDocument.Add(Me.ForiegnKey, realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Description, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Office.Abbreviation
                                                    Dim newDocument As New OfficeDocuments(Me.ConnectionString)
                                                    documentID = newDocument.Add(Me.ForiegnKey, realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Description, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Division.Abbreviation
                                                    Dim FKs() As String
                                                    If InStr(Me.ForiegnKey, ",") > 0 Then
                                                        FKs = Me.ForiegnKey.Split(",")
                                                    Else
                                                        FKs = Session("UploadFK").ToString.Split(",")
                                                    End If
                                                    Dim newDocument As New DivisionDocuments(Me.ConnectionString)
                                                    documentID = newDocument.Add(FKs(0), FKs(1), realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Description, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Product.Abbreviation
                                                    Dim FKs() As String
                                                    If InStr(Me.ForiegnKey, ",") > 0 Then
                                                        FKs = Me.ForiegnKey.Split(",")
                                                    Else
                                                        FKs = Session("UploadFK").ToString.Split(",")
                                                    End If
                                                    Dim newDocument As New ProductDocuments(Me.ConnectionString)
                                                    documentID = newDocument.Add(FKs(0), FKs(1), FKs(2), realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Description, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Job.Abbreviation
                                                    Dim newDocument As New JobDocument(Me.ConnectionString)
                                                    documentID = newDocument.Add(Me.ForiegnKey, realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Description, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation
                                                    Dim newDocument As New JobComponentDocuments(Me.ConnectionString)
                                                    Dim FKs() As String = Me.ForiegnKey.Split(",")
                                                    documentID = newDocument.Add(CInt(FKs(0)), CInt(FKs(1)), realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Description, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Campaign.Abbreviation
                                                    Dim newDocument As New CampaignDocument(Me.ConnectionString)
                                                    documentID = newDocument.Add(Me.ForiegnKey, realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Description, Me.TextBoxKeywords.Text, Me.Value, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsPayableInvoice.Abbreviation
                                                    Dim newDocument As New APDocument(Me.ConnectionString)
                                                    documentID = newDocument.Add(Me.ForiegnKey, realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Description, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.DesktopObject.Abbreviation
                                                    Select Case Me.DOLevel
                                                        Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation
                                                            Dim newDocument As New AgencyDesktopDocument(Me.ConnectionString)
                                                            Dim FKs() As String = Me.ForiegnKey.Split(",")
                                                            documentID = newDocument.Add(FKs(0), FKs(1), realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Description, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                                        Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation

                                                            Dim ExecutiveDesktopDocument As AdvantageFramework.Database.Entities.ExecutiveDesktopDocument = Nothing
                                                            Dim Document As New Document(Me.ConnectionString)
                                                            Dim FKs() As String = Me.ForiegnKey.Split(",")
                                                            Dim OfficeCode As String = Nothing
                                                            Dim EmployeeCode As String = Nothing

                                                            documentID = Document.Add(realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Description, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)

                                                            If documentID <> -1 AndAlso documentID > 0 Then

                                                                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                                                    If FKs(0) <> "" Then

                                                                        OfficeCode = FKs(0)

                                                                    End If

                                                                    If FKs(1) <> "" Then

                                                                        EmployeeCode = FKs(1)

                                                                    End If

                                                                    AdvantageFramework.Database.Procedures.ExecutiveDesktopDocument.Insert(DbContext, documentID, OfficeCode, EmployeeCode, Nothing)

                                                                End Using

                                                            End If

                                                    End Select
                                                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AdNumber.Abbreviation
                                                    Dim newDocument As New Document(Me.ConnectionString)
                                                    documentID = newDocument.Add(realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Description, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                                    Dim save As Boolean = newDocument.AddAdNumberDocument(Me.Value, documentID)
                                                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseReceipt.Abbreviation
                                                    Dim newDocument As New Document(Me.ConnectionString)
                                                    documentID = newDocument.Add(realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Description, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)

                                                    Dim InvoiceNumber As Integer = 0
                                                    If Me.Value.Contains("|") = True Then
                                                        Dim ar() As String
                                                        ar = Me.Value.Split("|")
                                                        InvoiceNumber = CType(ar(1), Integer)
                                                    Else
                                                        InvoiceNumber = CType(Me.Value, Integer)
                                                    End If

                                                    Dim save As Boolean = newDocument.AddExpenseDocument(documentID, InvoiceNumber)
                                                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Contract.Abbreviation
                                                    Dim newDocument As New Document(Me.ConnectionString)
                                                    documentID = newDocument.Add(realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Description, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                                    Dim save As Boolean = newDocument.AddContractDocument(documentID, Me.Value, Session("UserCode"))
                                                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ContractValueAdded.Abbreviation
                                                    Dim newDocument As New Document(Me.ConnectionString)
                                                    documentID = newDocument.Add(realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Description, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                                    Dim save As Boolean = newDocument.AddContractValueAddedDocument(documentID, Me.Value, Session("UserCode"))
                                                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ContractReport.Abbreviation
                                                    Dim newDocument As New Document(Me.ConnectionString)
                                                    documentID = newDocument.Add(realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Description, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                                    Dim save As Boolean = newDocument.AddContractReportDocument(documentID, Me.Value, Session("UserCode"))
                                                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Task.Abbreviation
                                                    Dim Keys As String() = Nothing
                                                    Keys = Me.Value.Split("|")
                                                    Dim newDocument As New Document(Me.ConnectionString)
                                                    documentID = newDocument.Add(realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Description, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                                    Dim save As Boolean = newDocument.AddTaskDocument(documentID, CInt(Keys(0)), CShort(Keys(1)), CShort(Keys(2)), Session("UserCode"))

                                            End Select

                                            If documentID > 0 Then

                                                Try

                                                    If MimeType.ToLower.Contains("image") = True Then

                                                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                                            Try
                                                                If Agency Is Nothing Then

                                                                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                                                End If
                                                            Catch ex As Exception
                                                                Agency = Nothing
                                                            End Try

                                                            If Agency IsNot Nothing Then

                                                                AdvantageFramework.DocumentManager.UpdateDocumentThumbnail(DbContext, Agency, documentID, Nothing)

                                                            End If

                                                        End Using

                                                    End If

                                                Catch ex As Exception
                                                End Try

                                                Me.AddLabelsToDocument(documentID)

                                            End If

                                            If IsNTAuth = True Then 'And HasMultipleUploads = True Then
                                                impersonationContext1.Undo()
                                            End If

                                            If documentID = -1 Then

                                            Else
                                                documentIDs &= documentID.ToString & ","
                                            End If

                                        Catch ex As Exception
                                            strErr &= "\nError saving document record to db."
                                            FileUploadedSuccessfully = False
                                        End Try

                                    Next

                                    If documentID = -1 Then
                                        FileUploadedSuccessfully = False
                                    End If
                                    Try
                                        If Me.AutoCompleteRecipients.HasEntries() = True AndAlso FileUploadedSuccessfully = True Then
                                            Me.SendAlert(MiscFN.RemoveTrailingDelimiter(documentIDs, ","), Me.TextBoxSubject.Text, Description, Me.DropDownListCategory.SelectedValue)
                                        End If
                                    Catch ex As Exception
                                        strErr &= "\nError Sending alert."
                                    End Try
                                End If
                            Catch ex As Exception
                                Me.ShowMessage("Error saving document.\nPlease check the repository settings.\n" & strErr)
                            End Try
                        Case "Link"
                            Try
                                ' Read the uploaded file into a file stream for later
                                Dim realFilename As String = Me.TextBoxLinkName.Text
                                Dim MimeType As String = "URL"
                                Dim FileLength As Integer = 0

                                Dim DocumentManagerFilename As String = Me.TextBoxURL.Text
                                DocumentManagerFilename = DocumentManagerFilename.Replace("http:\\", "http://")

                                'If InStr(DocumentManagerFilename, "http://") = 0 Then
                                '    DocumentManagerFilename = "http://" & DocumentManagerFilename
                                'End If
                                If DocumentManagerFilename = "http://" Then
                                    Me.ShowMessage("No URL provided, unable to create the link.")
                                End If
                                Select Case Me.Level
                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation,
                                        AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Abbreviation,
                                        AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Abbreviation

                                        Dim uploadInfo As New ViewModels.DocumentUploadInfo()

                                        uploadInfo.FileName = realFilename
                                        uploadInfo.RepositoryFilename = DocumentManagerFilename
                                        uploadInfo.Description = Description
                                        uploadInfo.Keywords = Me.TextBoxKeywords.Text
                                        uploadInfo.UserCode = Session("UserCode")
                                        uploadInfo.FileSize = FileLength
                                        uploadInfo.PrivateFlag = privateFlag
                                        uploadInfo.DocumentTypeId = Me.RadComboBoxDocumentType.SelectedValue
                                        uploadInfo.ForeignKey = Me.ForiegnKey
                                        uploadInfo.Level = Me.Level
                                        uploadInfo.MimeType = "URL"

                                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                                            Dim documentRepo As New Repositories.DocumentRepository(DataContext)

                                            uploadInfo = documentRepo.InsertAndLinkDocumentToLevel(uploadInfo)
                                        End Using

                                        If uploadInfo.DatabaseInsertSuccessful AndAlso uploadInfo.DocumentLinkSuccessful Then
                                            documentID = uploadInfo.DocumentId
                                        Else
                                            Throw New Exception("There was a problem saving to the Repository; please make sure the Repository Settings are correct." & uploadInfo.LastUploadException.Message.ToString(), uploadInfo.LastUploadException)
                                        End If
                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Client.Abbreviation
                                        Dim newDocument As New ClientDocuments(Me.ConnectionString)
                                        documentID = newDocument.Add(Me.ForiegnKey, realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Me.TextBoxDescription.Text, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Office.Abbreviation
                                        Dim newDocument As New OfficeDocuments(Me.ConnectionString)
                                        documentID = newDocument.Add(Me.ForiegnKey, realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Me.TextBoxDescription.Text, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Division.Abbreviation
                                        Dim FKs() As String = Me.ForiegnKey.Split(",")
                                        Dim newDocument As New DivisionDocuments(Me.ConnectionString)
                                        documentID = newDocument.Add(FKs(0), FKs(1), realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Me.TextBoxDescription.Text, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Product.Abbreviation
                                        Dim FKs() As String = Me.ForiegnKey.Split(",")
                                        Dim newDocument As New ProductDocuments(Me.ConnectionString)
                                        documentID = newDocument.Add(FKs(0), FKs(1), FKs(2), realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Me.TextBoxDescription.Text, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Job.Abbreviation
                                        Dim newDocument As New JobDocument(Me.ConnectionString)
                                        documentID = newDocument.Add(Me.ForiegnKey, realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Me.TextBoxDescription.Text, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation
                                        Dim newDocument As New JobComponentDocuments(Me.ConnectionString)
                                        Dim FKs() As String = Me.ForiegnKey.Split(",")
                                        documentID = newDocument.Add(FKs(0), FKs(1), realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Me.TextBoxDescription.Text, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Campaign.Abbreviation
                                        Dim newDocument As New CampaignDocument(Me.ConnectionString)
                                        documentID = newDocument.Add(Me.ForiegnKey, realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Me.TextBoxDescription.Text, Me.TextBoxKeywords.Text, Me.Value, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsPayableInvoice.Abbreviation
                                        Dim newDocument As New APDocument(Me.ConnectionString)
                                        documentID = newDocument.Add(Me.ForiegnKey, realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Me.TextBoxDescription.Text, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.DesktopObject.Abbreviation
                                        Select Case Me.DOLevel
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation
                                                Dim newDocument As New AgencyDesktopDocument(Me.ConnectionString)
                                                Dim FKs() As String = Me.ForiegnKey.Split(",")
                                                documentID = newDocument.Add(FKs(0), FKs(1), realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Me.TextBoxDescription.Text, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation
                                                Dim ExecutiveDesktopDocument As AdvantageFramework.Database.Entities.ExecutiveDesktopDocument = Nothing
                                                Dim Document As New Document(Me.ConnectionString)
                                                Dim FKs() As String = Me.ForiegnKey.Split(",")
                                                Dim OfficeCode As String = Nothing
                                                Dim EmployeeCode As String = Nothing

                                                documentID = Document.Add(realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Me.TextBoxDescription.Text, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)

                                                If documentID <> -1 AndAlso documentID > 0 Then

                                                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                                        If FKs(0) <> "" Then

                                                            OfficeCode = FKs(0)

                                                        End If

                                                        If FKs(1) <> "" Then

                                                            EmployeeCode = FKs(1)

                                                        End If

                                                        AdvantageFramework.Database.Procedures.ExecutiveDesktopDocument.Insert(DbContext, documentID, OfficeCode, EmployeeCode, Nothing)

                                                    End Using

                                                End If

                                        End Select
                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AdNumber.Abbreviation
                                        Dim newDocument As New Document(Me.ConnectionString)
                                        documentID = newDocument.Add(realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Me.TextBoxDescription.Text, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                        Dim save As Boolean = newDocument.AddAdNumberDocument(Me.Value, documentID)
                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseReceipt.Abbreviation
                                        Dim newDocument As New Document(Me.ConnectionString)
                                        documentID = newDocument.Add(realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Me.TextBoxDescription.Text, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)

                                        Dim InvoiceNumber As Integer = 0
                                        If Me.Value.Contains("|") = True Then
                                            Dim ar() As String
                                            ar = Me.Value.Split("|")
                                            InvoiceNumber = CType(ar(1), Integer)
                                        Else
                                            InvoiceNumber = CType(Me.Value, Integer)
                                        End If

                                        Dim save As Boolean = newDocument.AddExpenseDocument(documentID, InvoiceNumber)
                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Contract.Abbreviation
                                        Dim newDocument As New Document(Me.ConnectionString)
                                        documentID = newDocument.Add(realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Me.TextBoxDescription.Text, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                        Dim save As Boolean = newDocument.AddContractDocument(documentID, Me.Value, Session("UserCode"))
                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ContractValueAdded.Abbreviation
                                        Dim newDocument As New Document(Me.ConnectionString)
                                        documentID = newDocument.Add(realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Me.TextBoxDescription.Text, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                        Dim save As Boolean = newDocument.AddContractValueAddedDocument(documentID, Me.Value, Session("UserCode"))
                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ContractReport.Abbreviation
                                        Dim newDocument As New Document(Me.ConnectionString)
                                        documentID = newDocument.Add(realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Me.TextBoxDescription.Text, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                        Dim save As Boolean = newDocument.AddContractReportDocument(documentID, Me.Value, Session("UserCode"))
                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Task.Abbreviation
                                        Dim Keys As String() = Nothing
                                        Keys = Me.Value.Split("|")
                                        Dim newDocument As New Document(Me.ConnectionString)
                                        documentID = newDocument.Add(realFilename, MimeType, DocumentManagerFilename, FileLength, Session("UserCode"), Me.TextBoxDescription.Text, Me.TextBoxKeywords.Text, privateFlag, Me.RadComboBoxDocumentType.SelectedValue)
                                        Dim save As Boolean = newDocument.AddTaskDocument(documentID, CInt(Keys(0)), CShort(Keys(1)), CShort(Keys(2)), Session("UserCode"))
                                End Select
                                If documentID > 0 Then

                                    Me.AddLabelsToDocument(documentID)

                                    Try
                                        If Me.AutoCompleteRecipients.HasEntries() = True AndAlso FileUploadedSuccessfully = True Then
                                            Me.SendAlert(documentID, Me.TextBoxSubject.Text, Description, Me.DropDownListCategory.SelectedValue)
                                        End If
                                    Catch ex As Exception
                                        strErr &= "\nError Sending alert."
                                    End Try
                                End If
                            Catch ex As Exception
                                Me.ShowMessage("Error saving link.\nPlease check the repository settings.\n" & ex.Message)
                            End Try
                    End Select
                    Select Case Me.CallingPage
                        Case "Campaign.aspx" 'need get querystring params back
                            Me.CloseDialog()
                        Case "Documents.aspx"
                            'Me.CloseThisWindowAndRefreshCaller(Me.CallingPage & "?cf=0", True)
                            Me.RefreshCaller(Me.CallingPage & "?cf=0")
                            Me.CloseDialog()
                        Case "expense_edit.aspx"
                            Me.CloseDialog()
                        Case "expense_edit_v2.aspx"

                            Dim OpenSelectItemsWindow As Boolean = False

                            If documentID <> Nothing AndAlso documentID > 0 Then

                                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                    Try

                                        OpenSelectItemsWindow = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, Me.Value, False)
                                                                 Select Entity).Any

                                    Catch ex As Exception

                                    End Try

                                End Using

                            End If

                            If OpenSelectItemsWindow Then

                                'Me.CloseThisWindowAndOpenNewWindow("Expense_SelectItems.aspx?DocID=" & documentID & "&InvNbr=" & Me.Value, False)
                                Me.CloseThisWindowAndRefreshCaller("Expense_SelectItems.aspx?DocID=" & documentID & "&InvNbr=" & Me.Value, False, True)
                                Me.CloseDialog()
                                'Me.OpenWindow("Expense_SelectItems.aspx?DocID=" & documentID & "&InvNbr=" & Me.Value, False)

                            Else

                                Me.CloseDialog()

                            End If

                        Case "Documents_JobComponent.aspx"
                            JobNumber = Request.QueryString("j")
                            JobComponentNbr = Request.QueryString(AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation)
                            'Me.CloseThisWindowAndRefreshCaller("Documents_JobComponent.aspx?m=D&JobNum=" & JobNumber & "&JobCompNum=" & JobComponentNbr, True)
                            Me.RefreshCaller("Documents_JobComponent.aspx?m=D&JobNum=" & JobNumber & "&JobCompNum=" & JobComponentNbr)
                            Me.CloseDialog()
                        Case "Maintenance_ContractEdit.aspx"
                            If Me.Level = AdvantageFramework.DocumentManager.Classes.UploadLevels.ContractValueAdded.Abbreviation OrElse
                               Me.Level = AdvantageFramework.DocumentManager.Classes.UploadLevels.ContractReport.Abbreviation OrElse
                               Me.Level = AdvantageFramework.DocumentManager.Classes.UploadLevels.Contract.Abbreviation Then
                                Dim arCDP() As String
                                If InStr(Me.ForiegnKey, ",") > 0 Then
                                    arCDP = Me.ForiegnKey.Split(",")
                                End If
                                'Me.CloseThisWindowAndRefreshCaller("Maintenance_ContractEdit.aspx?ContractID=" & Request.QueryString("ContractID") & "&ClientCode=" & arCDP(0) & "&DivisionCode=" & arCDP(1) & "&ProductCode=" & arCDP(2))
                                Me.RefreshCaller("Maintenance_ContractEdit.aspx?ContractID=" & Request.QueryString("ContractID") & "&ClientCode=" & arCDP(0) & "&DivisionCode=" & arCDP(1) & "&ProductCode=" & arCDP(2))
                                Me.CloseDialog()
                            End If
                        Case "documents_list2.aspx"
                            If Me.Level = AdvantageFramework.DocumentManager.Classes.UploadLevels.Task.Abbreviation Then
                                'Me.CloseThisWindowAndRefreshCaller("Documents_List2.aspx")
                                Me.RefreshCaller("Documents_List2.aspx")
                                Me.CloseDialog()
                            End If
                        Case "trafficschedule_taskdetail.aspx"
                            If Me.Level = AdvantageFramework.DocumentManager.Classes.UploadLevels.Task.Abbreviation Then
                                'Me.CloseThisWindowAndRefreshCaller("trafficschedule_taskdetail.aspx")
                                Me.RefreshCaller("trafficschedule_taskdetail.aspx")
                                Me.CloseDialog()
                            End If
                        Case Else
                            Me.CloseDialog()
                    End Select
                End If
            Case "Clear"
                Me.cbPrivate.Checked = False
                Me.TextBoxDescription.Text = ""
                Me.TextBoxKeywords.Text = ""
                Me.TextBoxLinkName.Text = ""
                Me.AutoCompleteRecipients.Clear()
                Me.TextBoxSubject.Text = ""
                Me.TextBoxURL.Text = ""
                Me.DropDownListCategory.SelectedIndex = -1
                Me.DropDownListPriority.SelectedIndex = -1

        End Select
    End Sub


#End Region
#Region " Page "

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.Level = Request.QueryString("Level")
        Me.DOLevel = Request.QueryString("DOLevel")
        Me.ForiegnKey = Request.QueryString("FK")
        Me.Value = Request.QueryString("Value")

        Me.ConnectionString = Session("ConnString")

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.GetValue("Level") <> "" Then Me.Level = qs.GetValue("Level")
        If qs.GetValue("DOLevel") <> "" Then Me.DOLevel = qs.GetValue("DOLevel")
        If qs.GetValue("FK") <> "" Then Me.ForiegnKey = qs.GetValue("FK")
        If qs.GetValue("Value") <> "" Then Me.Value = qs.GetValue("Value")
        If qs.GetValue("caller") <> "" Then Me._Caller = qs.GetValue("caller")

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Dim m As New DocumentRepository("", True)
            If m.SetRadAsyncUpload(Me.RadUploadDocument, True, Me.LabelFileSizeLimitMessage.Text) = False Then

                Me.ShowMessage(Me.LabelFileSizeLimitMessage.Text)
                Me.LabelFileSizeLimitMessage.CssClass = "warning"

            End If

        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim ClientCode As String = ""

            Select Case Me.Level

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Client.Abbreviation

                    Dim Client As New CLIENT(Me.ConnectionString)
                    If Me.ForiegnKey <> "" Then

                        ClientCode = Me.ForiegnKey

                    Else

                        ClientCode = Session("UploadFK")

                    End If
                    With Client.Where

                        .CL_CODE.Value = ClientCode

                    End With

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Division.Abbreviation

                    Dim Division As New DIVISION(Me.ConnectionString)
                    Dim arCD() As String

                    If InStr(Me.ForiegnKey, ",") > 0 Then

                        arCD = Me.ForiegnKey.Split(",")

                    Else

                        arCD = Session("UploadFK").ToString.Split(",")

                    End If
                    With Division.Where

                        .CL_CODE.Value = arCD(0)
                        .DIV_CODE.Value = arCD(1)

                    End With

                    ClientCode = arCD(0)

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Product.Abbreviation
                    Dim Product As New PRODUCT(Me.ConnectionString)
                    Dim arCDP() As String
                    If InStr(Me.ForiegnKey, ",") > 0 Then

                        arCDP = Me.ForiegnKey.Split(",")

                    Else

                        arCDP = Session("UploadFK").ToString.Split(",")

                    End If
                    With Product.Where

                        .CL_CODE.Value = arCDP(0)
                        .DIV_CODE.Value = arCDP(1)
                        .PRD_CODE.Value = arCDP(2)

                    End With

                    ClientCode = arCDP(0)

                    If Product.Query.Load() Then

                        If Not Product.IsColumnNull(PRODUCT.ColumnNames.EMAIL_GR_CODE) And Product.EMAIL_GR_CODE <> "" Then

                            Me.emailGroup = Product.EMAIL_GR_CODE

                        End If

                    End If

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation

                    Dim FKs() As String '
                    Try

                        If Me.ForiegnKey.IndexOf(",") > -1 Then

                            FKs = Me.ForiegnKey.Split(",")
                            Me.JobNumber = CType(FKs(0), Integer)
                            Me.JobComponentNbr = CType(FKs(1), Integer)

                        End If

                    Catch ex As Exception

                        Me.JobNumber = 0
                        Me.JobComponentNbr = 0

                    End Try
                    If Me.JobNumber = 0 Then

                        If Not Request.QueryString("j") Is Nothing Then

                            Me.JobNumber = CType(Request.QueryString("j"), Integer)

                        End If

                    End If
                    If Me.JobComponentNbr = 0 Then

                        If Not Request.QueryString(AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation) Is Nothing Then

                            Me.JobComponentNbr = CType(Request.QueryString(AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation), Integer)

                        End If

                    End If
                    If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then

                        Dim JobComponent As New JOB_COMPONENT(Me.ConnectionString)
                        JobComponent.Where.JOB_NUMBER.Value = Me.JobNumber
                        JobComponent.Where.JOB_COMPONENT_NBR.Value = Me.JobComponentNbr

                        If JobComponent.Query.Load() Then

                            If Not JobComponent.IsColumnNull(JobComponent.ColumnNames.EMAIL_GR_CODE) Or JobComponent.ColumnNames.EMAIL_GR_CODE <> "" Then

                                Me.emailGroup = JobComponent.EMAIL_GR_CODE

                            End If

                        End If

                    End If
                    If Me.IsClientPortal = True Then

                        Me.cbPrivate.Visible = False

                    End If

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Task.Abbreviation

                    Dim Keys As String() = Nothing

                    Try

                        Keys = Me.Value.Split("|")

                        Me.JobNumber = CInt(Keys(0))
                        Me.JobComponentNbr = CInt(Keys(1))
                        Me.SequenceNumber = CInt(Keys(2))

                    Catch ex As Exception
                        Me.JobNumber = 0
                        Me.JobComponentNbr = 0
                        Me.SequenceNumber = -1
                    End Try

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AdNumber.Abbreviation

                    RadUploadDocument.MultipleFileSelection = Telerik.Web.UI.AsyncUpload.MultipleFileSelection.Disabled

                Case Else

                    Me.emailGroup = ""

            End Select

            Select Case Me.Level

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Office.Abbreviation, AdvantageFramework.DocumentManager.Classes.UploadLevels.Client.Abbreviation, AdvantageFramework.DocumentManager.Classes.UploadLevels.Division.Abbreviation, AdvantageFramework.DocumentManager.Classes.UploadLevels.Product.Abbreviation, AdvantageFramework.DocumentManager.Classes.UploadLevels.Job.Abbreviation, AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation, AdvantageFramework.DocumentManager.Classes.UploadLevels.Campaign.Abbreviation

                    Me.ShowAlertSection(True)

                Case Else

                    Me.ShowAlertSection(False)

            End Select

            If Not Me.IsPostBack Then

                Me.DivFile.Visible = True
                Me.DivLinkName.Visible = False
                Me.DivLinkURL.Visible = False

                Me.TextBoxLinkName.Visible = False
                Dim ClearScript As String = Me.TextBoxDescription.ClientID & ".value = '';" & Me.TextBoxKeywords.ClientID & ".value = '';ClearUpload();"
                Me.RequiredFieldValidatorLinkName.Enabled = False
                Me.RequiredFieldValidatorLinkURL.Enabled = False
                If Session("DocCaption") <> "" Then

                    Me.TextBoxDescription.Text = Session("DocCaption").ToString

                End If

                Me.TextBoxSubject.Text = "A new document has been uploaded."
                Me.LoadListCategories()
                Me.LoadDocumentTypeList()
                Me.LoadPriority()
                Me.LoadLabels()

            End If

            Me.AutoCompleteRecipients.JobNumber = Me.JobNumber
            Me.AutoCompleteRecipients.ClientCode = ClientCode

        Catch ex As Exception

            Me.ShowMessage("Error in pageload\n" & AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

        End Try

    End Sub

#End Region

    Private Sub AddLabelsToDocument(ByVal DocumentID)

        If DocumentID > 0 Then

            Using dc = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                Dim NewLabelDocument As AdvantageFramework.Database.Entities.LabelDocument

                For Each Entry As Telerik.Web.UI.RadComboBoxItem In Me.RadComboBoxLabels.Items

                    If Entry.Checked = True Then

                        NewLabelDocument = New AdvantageFramework.Database.Entities.LabelDocument

                        NewLabelDocument.DocumentID = DocumentID
                        NewLabelDocument.LabelID = Entry.Value

                        AdvantageFramework.Database.Procedures.LabelDocument.Insert(dc, NewLabelDocument)

                        NewLabelDocument = Nothing

                    End If

                Next

            End Using

        End If

    End Sub
    Private Function GetEmailGroupFromProduct(ByVal strCliCode As String, ByVal strDivCode As String, ByVal strProdCode As String) As String
        Try
            Dim oSQL As SqlHelper
            Dim strReturn As String = String.Empty

            Dim arParams(3) As SqlParameter

            Dim paramCliCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            paramCliCode.Value = strCliCode
            arParams(0) = paramCliCode

            Dim paramDivCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            paramDivCode.Value = strDivCode
            arParams(1) = paramDivCode

            Dim paramProdCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            paramProdCode.Value = strProdCode
            arParams(2) = paramProdCode

            'use mConnString if moving to class instead of session
            strReturn = oSQL.ExecuteScalar(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_GetEmailGroupFromProduct", arParams)

            If strReturn <> "" And strReturn.Length > 0 Then
                Return strReturn
            Else
                Return String.Empty
            End If
        Catch ex As Exception

        Finally
        End Try
    End Function
    Private Sub LoadDocumentTypeList()

        AdvantageFramework.Web.Presentation.Controls.RadComboBoxLoadDocumentTypeList(Me._Session, Me.RadComboBoxDocumentType)

    End Sub
    Private Sub LoadLabels()

        Dim Labels As List(Of AdvantageFramework.Database.Entities.Label)

        Using dc = New AdvantageFramework.Database.DataContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

            Labels = AdvantageFramework.Database.Procedures.Label.LoadActive(dc).ToList()

        End Using

        If Labels Is Nothing Then Labels = New List(Of AdvantageFramework.Database.Entities.Label)

        Me.RadComboBoxLabels.DataSource = Labels
        Me.RadComboBoxLabels.DataTextField = "Name"
        Me.RadComboBoxLabels.DataValueField = "ID"
        Me.RadComboBoxLabels.DataBind()

    End Sub
    Private Sub LoadListCategories()
        Try
            Dim AlertCategories As New AlertCategory(Session("ConnString"))
            With AlertCategories
                .Where.ALERT_TYPE_ID.Value = "6"
                .Where.ALERT_TYPE_ID.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Equal
                .Query.AddOrderBy(AlertCategories.ColumnNames.ALERT_DESC, MyGeneration.dOOdads.WhereParameter.Dir.ASC)
            End With
            If AlertCategories.Query.Load() Then
                Do Until AlertCategories.EOF
                    If AlertCategories.ALERT_CAT_ID < 28 Then
                        Me.DropDownListCategory.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AlertCategories.ALERT_DESC, AlertCategories.ALERT_CAT_ID))
                    End If
                    AlertCategories.MoveNext()
                Loop
            End If
        Catch
            Err.Raise(Err.Number, "Error: Loading Categories", Err.Description)
        End Try

    End Sub
    Private Sub LoadPriority()
        'Me.DropDownListPriority.Items.Add(New Telerik.Web.UI.RadComboBoxItem("High", "1"))
        'Me.DropDownListPriority.Items.Add(New Telerik.Web.UI.RadComboBoxItem("Medium", "2"))
        'Me.DropDownListPriority.Items.Add(New Telerik.Web.UI.RadComboBoxItem("Low", "3"))
        Dim a As New cAlerts()
        a.LoadPrioritiesComboBox(Me.DropDownListPriority)
    End Sub
    Private Sub SendAlert(ByVal documentID As String, ByVal subject As String, ByVal body As String, ByVal category As Integer)
        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim FxAlert As New AdvantageFramework.Database.Entities.Alert
            'Dim alert As New Alert(Me.ConnectionString)
            Dim oAlerts As New cAlerts(Session("ConnString"))
            Dim NowDate As Date = Date.Now
            Dim i As Integer
            Dim RecipientArray() As String
            Dim RecipientArrayCC() As String
            ' Dim dr As SqlDataReader
            Dim NewRecipientList As String
            Dim NewRecipientListCC As String = ""
            Dim OrigionalRecipientList As String = Me.AutoCompleteRecipients.GetCommaDelimitedStringOfEmployeeCodes()

            If OrigionalRecipientList = "No Default Selected" Then

                OrigionalRecipientList = ""

            End If

            OrigionalRecipientList = OrigionalRecipientList.Replace("chk_", "")
            RecipientArray = OrigionalRecipientList.Split(",")

            Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
            Dim currentWindowsIdentity As System.Security.Principal.WindowsIdentity

            If IsNTAuth = True Then

                currentWindowsIdentity = CType(User.Identity, System.Security.Principal.WindowsIdentity)
                impersonationContext = currentWindowsIdentity.Impersonate()

            End If

            For i = 0 To RecipientArray.Length - 1

                ' Loop through the recipients list looking for groups 
                Dim EmailGroup As New EmailGroup(Session("ConnString"))
                EmailGroup.Where.EMAIL_GR_CODE.Value = RecipientArray(i)
                EmailGroup.Query.Load()

                If EmailGroup.RowCount > 0 Then

                Else

                    If RecipientArray(i).ToString.Contains("(CC)") = True Then

                        Dim strRec As String = RecipientArray(i)
                        strRec = strRec.Replace("(CC)", "").Trim
                        NewRecipientListCC = NewRecipientListCC & strRec & ","

                    Else

                        NewRecipientList = NewRecipientList & RecipientArray(i) & ","

                    End If

                End If

            Next

            '''Make sure the logged user is in the list always
            If NewRecipientList <> "" Then

                If Not NewRecipientList.Contains(Session("EmpCode")) Then

                    NewRecipientList = NewRecipientList & "," & Session("EmpCode") ' Add the current user to the recipient's list.

                End If

            Else

                NewRecipientList = Session("EmpCode") ' Add the current user to the recipent's list.

            End If

            NewRecipientList = NewRecipientList.Replace(" ", "")
            NewRecipientList = NewRecipientList.Replace(",,", ",")
            NewRecipientList = MiscFN.RemoveDuplicatesFromString(NewRecipientList, ",")

            RecipientArray = NewRecipientList.Split(",")

            If Me.IsClientPortal = True Then
                If NewRecipientListCC <> "" Then

                    If Not NewRecipientListCC.Contains(oAlerts.getContactCode(Session("UserID"))) Then

                        NewRecipientListCC = NewRecipientListCC & "," & oAlerts.getContactCode(Session("UserID")) ' Add the current user to the recipent's list.

                    End If

                Else

                    NewRecipientListCC = oAlerts.getContactCode(Session("UserID")) ' Add the current user to the recipent's list.

                End If

            End If

            If NewRecipientListCC <> "" Then

                NewRecipientListCC = NewRecipientListCC.Replace(" ", "")
                NewRecipientListCC = NewRecipientListCC.Replace(",,", ",")

            End If

            If NewRecipientListCC <> "" Then

                NewRecipientListCC = MiscFN.RemoveDuplicatesFromString(NewRecipientListCC, ",")

            End If

            If NewRecipientListCC <> "" Then

                RecipientArrayCC = NewRecipientListCC.Split(",")

            End If

            With FxAlert

                If IsClientPortal = True Then

                    .AlertTypeID = 7 'WV Alert

                Else

                    .AlertTypeID = 6 'WV Alert

                End If

                .AlertCategoryID = category
                .Subject = subject

                Dim BodyHTML As String = body

                If Me.TextBoxKeywords.Text.Trim() <> "" Then

                    body = body & Environment.NewLine & Environment.NewLine & "Keywords: " & Me.TextBoxKeywords.Text
                    BodyHTML = BodyHTML & "<br /><br />Keywords: " & Me.TextBoxKeywords.Text

                End If

                .Body = body
                .EmailBody = BodyHTML
                .GeneratedDate = NowDate
                .LastUpdated = .GeneratedDate
                .PriorityLevel = Me.DropDownListPriority.SelectedValue

                Select Case Me.Level
                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation

                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Office.Abbreviation

                        .OfficeCode = Me.ForiegnKey

                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Client.Abbreviation

                        .ClientCode = Me.ForiegnKey

                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Division.Abbreviation

                        Dim arCD() As String
                        If InStr(Me.ForiegnKey, ",") > 0 Then

                            arCD = Me.ForiegnKey.Split(",")

                        Else

                            arCD = Session("UploadFK").ToString.Split(",")

                        End If

                        .ClientCode = arCD(0)
                        .DivisionCode = arCD(1)

                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Product.Abbreviation
                        Dim arCDP() As String

                        If InStr(Me.ForiegnKey, ",") > 0 Then

                            arCDP = Me.ForiegnKey.Split(",")

                        Else

                            arCDP = Session("UploadFK").ToString.Split(",")

                        End If

                        .ClientCode = arCDP(0)
                        .DivisionCode = arCDP(1)
                        .ProductCode = arCDP(2)

                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Job.Abbreviation

                        Dim Job As New JOB_LOG(Me.ConnectionString)
                        Job.Where.JOB_NUMBER.Value = Me.ForiegnKey
                        Job.Query.Load()

                        .ClientCode = Job.CL_CODE
                        .DivisionCode = Job.DIV_CODE
                        .ProductCode = Job.PRD_CODE
                        .JobNumber = Me.ForiegnKey

                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation

                        Dim JobComponent As New JOB_COMPONENT(Me.ConnectionString)
                        Dim FKs() As String = Me.ForiegnKey.Split(",")

                        JobComponent.Where.JOB_NUMBER.Value = FKs(0)
                        JobComponent.Where.JOB_COMPONENT_NBR.Value = FKs(1)
                        JobComponent.Query.Load()
                        Dim Job As New JOB_LOG(Me.ConnectionString)
                        Job.Where.JOB_NUMBER.Value = FKs(0)
                        Job.Query.Load()

                        .ClientCode = Job.CL_CODE
                        .DivisionCode = Job.DIV_CODE
                        .ProductCode = Job.PRD_CODE
                        .JobNumber = FKs(0)
                        .JobComponentNumber = FKs(1)

                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Task.Abbreviation

                        Dim JobComponent As New JOB_COMPONENT(Me.ConnectionString)
                        Dim FKs() As String = Me.Value.Split("|")

                        JobComponent.Where.JOB_NUMBER.Value = FKs(0)
                        JobComponent.Where.JOB_COMPONENT_NBR.Value = FKs(1)
                        JobComponent.Query.Load()
                        Dim Job As New JOB_LOG(Me.ConnectionString)
                        Job.Where.JOB_NUMBER.Value = FKs(0)
                        Job.Query.Load()

                        .ClientCode = Job.CL_CODE
                        .DivisionCode = Job.DIV_CODE
                        .ProductCode = Job.PRD_CODE
                        .JobNumber = FKs(0)
                        .JobComponentNumber = FKs(1)

                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Campaign.Abbreviation

                        .CampaignID = Me.ForiegnKey
                        .CampaignCode = Me.Value

                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsPayableInvoice.Abbreviation

                        If Session("DocVendorCode") <> "" Then

                            .VendorCode = Session("DocVendorCode")

                        End If

                        Session("DocVendorCode") = ""

                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.DesktopObject.Abbreviation
                        Select Case Me.DOLevel
                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation

                                If Me.ForiegnKey <> "," Then

                                    Dim FKs() As String = Me.ForiegnKey.Split(",")
                                    .OfficeCode = FKs(0)

                                End If
                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation

                                If Me.ForiegnKey <> "," Then

                                    .OfficeCode = Me.ForiegnKey

                                End If

                        End Select
                    Case Else

                        .CampaignID = 0

                End Select

                If Me.IsClientPortal = True Then

                    .UserCode = Session("UserID")
                    .IsCPAlert = 1
                    .ClientContactID = Session("UserID")

                Else

                    .EmployeeCode = Session("EmpCode")
                    .UserCode = Session("UserCode")

                End If

                If Me.Level = AdvantageFramework.DocumentManager.Classes.UploadLevels.DesktopObject.Abbreviation Then

                    If Me.DOLevel = AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation Then

                        .AlertLevel = AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation

                    End If
                    If Me.DOLevel = AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation Then

                        .AlertLevel = AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation

                    End If
                Else

                    .AlertLevel = Me.Level

                End If

                If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, FxAlert) = True Then

                    Dim Alert As New Alert(Session("ConnString"))
                    Dim SenderIsRecipient As Boolean = False

                    Alert.LoadByPrimaryKey(FxAlert.ID)

                    If IsNumeric(documentID) = True AndAlso documentID.Contains(",") = False Then

                        Alert.AddAttachment(CInt(documentID), Session("UserCode"), 0)

                    Else

                        Dim docIDs() As String = documentID.Split(",")

                        For w As Integer = 0 To docIDs.Count - 1

                            If IsNumeric(docIDs(w)) = True Then

                                Alert.AddAttachment(CInt(docIDs(w)), Session("UserCode"), 0)

                            End If

                        Next

                    End If

                    If Not RecipientArray Is Nothing Then

                        For i = 0 To RecipientArray.Length - 1

                            If String.IsNullOrWhiteSpace(RecipientArray(i)) = False Then

                                Alert.AddAlertRecipient(RecipientArray(i))

                                Try

                                    If RecipientArray(i) = Session("EmpCode") Then

                                        SenderIsRecipient = True

                                    End If

                                Catch ex As Exception
                                End Try

                            End If

                        Next

                    End If

                    Dim ThisClientCode As String = ""
                    If ThisClientCode = "" Then
                        If Me.JobNumber > 0 Then
                            Dim t As New cSchedule(Session("ConnString"), Session("UserCode"))
                            Dim dt As New DataTable
                            dt = t.GetBaseJobAndCompInfoDT(Me.JobNumber, Me.JobComponentNbr)
                            If Not dt Is Nothing Then
                                If dt.Rows.Count > 0 Then
                                    If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                                        ThisClientCode = dt.Rows(0)("CL_CODE")
                                    End If
                                End If
                            End If
                        End If
                    End If

                    If Not RecipientArrayCC Is Nothing Then

                        For i = 0 To RecipientArrayCC.Length - 1

                            If RecipientArrayCC(i) <> "" Then

                                Dim code As Integer = oAlerts.CPGetContactCodeID(RecipientArrayCC(i).ToString(), ThisClientCode)
                                Alert.AddAlertRecipientCC(code)

                            End If

                        Next

                    End If

                    If SenderIsRecipient = True Then

                        Me.RefreshAlertWindows(False)

                    End If

                    Dim eso As New EmailSessionObject(HttpContext.Current.Session("ConnString"),
                         HttpContext.Current.Session("UserCode"),
                         Me._Session,
                         HttpContext.Current.Session("WebvantageURL"),
                         HttpContext.Current.Session("ClientPortalURL"))
                    With eso

                        .AlertId = Alert.ALERT_ID
                        .Subject = "[New Alert]"
                        .InsertEmailBodyAsAlertDescription = False
                        .IsClientPortal = Me.IsClientPortal
                        .IncludeOriginator = False
                        .SessionID = HttpContext.Current.Session.SessionID.ToString()
                        .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                        .Send()

                    End With

                    Me.CheckForAsyncMessage()

                Else

                    Me.ShowMessage("Alert failed to save")

                End If

            End With

            If IsNTAuth = True Then

                impersonationContext.Undo()

            End If

        End Using
    End Sub
    Private Sub ShowAlertSection(Optional ByVal Show As Boolean = True)

        Me.DivSendAlert.Visible = Show
    End Sub

#End Region

End Class
