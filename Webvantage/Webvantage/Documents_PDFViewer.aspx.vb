Public Class Documents_PDFViewer
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _DocumentID As Integer = 0
    Private _PageNumber As Integer = 1
    Private _Width As Integer = 800
    Private _Height As Integer = 1000
    Private _AlertID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadQueryStringValues()

        Try

            If Request.QueryString("DocumentID") IsNot Nothing Then

                _DocumentID = CType(Request.QueryString("DocumentID"), Integer)

            End If

        Catch ex As Exception
            _DocumentID = 0
        End Try

        Try

            If Request.QueryString("PageNumber") IsNot Nothing Then

                _PageNumber = CType(Request.QueryString("PageNumber"), Integer)

            End If

        Catch ex As Exception
            _PageNumber = 1
        End Try

        Try

            If Request.QueryString("Width") IsNot Nothing Then

                _Width = CType(Request.QueryString("Width"), Integer)

            End If

        Catch ex As Exception
            _Width = 800
        End Try

        Try

            If Request.QueryString("Height") IsNot Nothing Then

                _Height = CType(Request.QueryString("Height"), Integer)

            End If

        Catch ex As Exception
            _Height = 1000
        End Try

        Try

            If Request.QueryString("AlertID") IsNot Nothing Then

                _AlertID = CType(Request.QueryString("AlertID"), Integer)

            End If

        Catch ex As Exception
            _AlertID = 0
        End Try

    End Sub
    Private Sub LoadComments(ByVal DocumentID As Integer, ByVal PageNumber As Integer)

        'objects
        Dim RadPanelItem As Telerik.Web.UI.RadPanelItem = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim ClientContact As AdvantageFramework.Security.Database.Entities.ClientContact = Nothing
        Dim PanelItemIndexesList As Generic.List(Of String) = Nothing

        RadPanelBarComments.Items.Clear()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            PanelItemIndexesList = New Generic.List(Of String)

            For Each DocumentComment In AdvantageFramework.Database.Procedures.DocumentComment.LoadByDocumentIDAndPageNumber(DbContext, DocumentID, PageNumber)

                RadPanelItem = New Telerik.Web.UI.RadPanelItem

                RadPanelItem.Value = DocumentComment.ID

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, DocumentComment.EmployeeCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If DocumentComment.UserCodeCP IsNot Nothing Then
                        ClientContact = AdvantageFramework.Security.Database.Procedures.ClientContact.LoadByClientContactID(SecurityDbContext, DocumentComment.UserCodeCP)
                    End If

                End Using

                If Employee IsNot Nothing Then

                    RadPanelItem.Text = Employee.ToString & " - " & DocumentComment.CreatedDate.ToShortDateString & " " & DocumentComment.CreatedDate.ToLongTimeString

                ElseIf ClientContact IsNot Nothing Then

                    RadPanelItem.Text = ClientContact.FullNameFML & " - " & DocumentComment.CreatedDate.ToShortDateString & " " & DocumentComment.CreatedDate.ToLongTimeString

                Else

                    RadPanelItem.Text = DocumentComment.UserCode & " - " & DocumentComment.CreatedDate.ToShortDateString & " " & DocumentComment.CreatedDate.ToLongTimeString

                End If

                RadPanelItem.ContentTemplate = New AdvantageFramework.Web.Presentation.Controls.DocumentCommentTemplate(DocumentComment.Comment)

                RadPanelBarComments.Items.Add(RadPanelItem)

                PanelItemIndexesList.Add(RadPanelItem.Index)

            Next

            Try

                If Request.Cookies(RadPanelBarComments.ClientID).Value <> "" AndAlso Request.Cookies(RadPanelBarComments.ClientID).Value <> "{'ExpandedItems':[]}" Then

                    If PanelItemIndexesList.Count > 0 Then

                        Request.Cookies(RadPanelBarComments.ClientID).Value = "{'ExpandedItems':[" & Join(PanelItemIndexesList.ToArray, ",") & "]}"

                    End If

                End If

            Catch ex As Exception

            End Try

        End Using

    End Sub
    Private Sub LoadDocumentPage(ByVal PageNumber As Integer, ByVal LoadMaxPageNumber As Boolean)

        'objects
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim Folder As String = ""
        Dim PDFDocument As Aspose.Pdf.Document = Nothing
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim Resolution As Aspose.Pdf.Devices.Resolution = Nothing
        Dim PDFPngDevice As Aspose.Pdf.Devices.PngDevice = Nothing
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim License As Aspose.Pdf.License = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, _DocumentID)

            If Document IsNot Nothing Then

                LoadComments(Document.ID, PageNumber)

                MemoryStream = New System.IO.MemoryStream

                If Agency.FileSystemUserName IsNot Nothing AndAlso Agency.FileSystemUserName <> "" Then

                    AliasAccount.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                End If

                Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\")

                If Document.FileName.ToUpper.Contains(".PDF") Then

                    Me.Title = Document.FileName

                    License = New Aspose.Pdf.License

                    License.SetLicense("Aspose.Total.lic")
                    License.Embedded = True

                    PDFDocument = New Aspose.Pdf.Document(Folder & Document.FileSystemFileName)

                    Resolution = New Aspose.Pdf.Devices.Resolution(300)
                    PDFPngDevice = New Aspose.Pdf.Devices.PngDevice(_Width, _Height, Resolution)

                    PDFPngDevice.Process(PDFDocument.Pages(PageNumber), MemoryStream)

                    RadBinaryImagePage.DataValue = MemoryStream.ToArray()

                    If PDFDocument.Pages.Count <= 1 Then

                        RadToolBarButtonGoToFirstPage.Enabled = False
                        RadToolBarButtonGoToPreviousPage.Enabled = False
                        RadToolBarButtonGoToNextPage.Enabled = False
                        RadToolBarButtonGoToLastPage.Enabled = False

                    ElseIf PageNumber = 1 Then

                        RadToolBarButtonGoToFirstPage.Enabled = False
                        RadToolBarButtonGoToPreviousPage.Enabled = False
                        RadToolBarButtonGoToNextPage.Enabled = True
                        RadToolBarButtonGoToLastPage.Enabled = True

                    ElseIf PageNumber = PDFDocument.Pages.Count Then

                        RadToolBarButtonGoToFirstPage.Enabled = True
                        RadToolBarButtonGoToPreviousPage.Enabled = True
                        RadToolBarButtonGoToNextPage.Enabled = False
                        RadToolBarButtonGoToLastPage.Enabled = False

                    Else

                        RadToolBarButtonGoToFirstPage.Enabled = True
                        RadToolBarButtonGoToPreviousPage.Enabled = True
                        RadToolBarButtonGoToNextPage.Enabled = True
                        RadToolBarButtonGoToLastPage.Enabled = True

                    End If

                    If LoadMaxPageNumber Then

                        Session(_DocumentID & "MaxPageNumber") = PDFDocument.Pages.Count

                    End If

                    If PDFDocument IsNot Nothing Then

                        PDFDocument = Nothing

                    End If

                    If Resolution IsNot Nothing Then

                        Resolution = Nothing

                    End If

                    If PDFPngDevice IsNot Nothing Then

                        PDFPngDevice = Nothing

                    End If

                    Try

                        If MemoryStream IsNot Nothing Then

                            MemoryStream.Close()

                            MemoryStream.Dispose()

                            MemoryStream = Nothing

                        End If

                    Catch ex As Exception

                    End Try

                    If License IsNot Nothing Then

                        License = Nothing

                    End If

                End If

                If Agency.FileSystemUserName IsNot Nothing AndAlso Agency.FileSystemUserName <> "" Then

                    AliasAccount.EndImpersonation()

                End If

            End If

        End Using

    End Sub
    Private Function SignDocument(ByVal Session As AdvantageFramework.Security.Session, ByVal DocumentID As Integer) As Boolean

        'objects
        Dim DocumentSigned As Boolean = False
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim Folder As String = ""
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim PKCS7 As Aspose.Pdf.InteractiveFeatures.Forms.PKCS7 = Nothing
        Dim Signature As Aspose.Pdf.InteractiveFeatures.Forms.Signature = Nothing
        Dim License As Aspose.Pdf.License = Nothing
        Dim HasBlankSignature As Boolean = False
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim DocMDPSignature As Aspose.Pdf.InteractiveFeatures.Forms.DocMDPSignature = Nothing
        Dim SignatureFileMemoryStream As System.IO.MemoryStream = Nothing
        Dim AlertComment As AlertComment = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                If Document IsNot Nothing Then

                    If Agency.FileSystemUserName IsNot Nothing AndAlso Agency.FileSystemUserName <> "" Then

                        AliasAccount.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                    End If

                    Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\")

                    If Document.FileName.ToUpper.Contains(".PDF") Then

                        License = New Aspose.Pdf.License

                        License.SetLicense("Aspose.Total.lic")
                        License.Embedded = True

                        Using PDFDocument = New Aspose.Pdf.Document(Folder & Document.FileSystemFileName)

                            Using PdfFileSignature = New Aspose.Pdf.Facades.PdfFileSignature(PDFDocument)

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode)

                                If Employee IsNot Nothing Then

                                    If Employee.AdobeSignatureFile IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Employee.AdobeSignatureFilePassword) = False Then

                                        Try

                                            SignatureFileMemoryStream = New System.IO.MemoryStream(Employee.AdobeSignatureFile)

                                            PKCS7 = New Aspose.Pdf.InteractiveFeatures.Forms.PKCS7(SignatureFileMemoryStream, Employee.AdobeSignatureFilePassword)
                                            PKCS7.Reason = "Advantage Digital Sign"

                                        Catch ex As Exception

                                        End Try

                                    End If

                                End If

                                If PKCS7 Is Nothing Then

                                    PKCS7 = New Aspose.Pdf.InteractiveFeatures.Forms.PKCS7(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Request.PhysicalApplicationPath, "\") & "AdvantagePDFSign.pfx", "APDFSAPDFS")
                                    PKCS7.Reason = "Advantage Digital Sign"

                                End If

                                DocMDPSignature = New Aspose.Pdf.InteractiveFeatures.Forms.DocMDPSignature(PKCS7, Aspose.Pdf.InteractiveFeatures.Forms.DocMDPAccessPermissions.FillingInForms)

                                If Employee IsNot Nothing Then

                                    If Employee.SignatureImage IsNot Nothing Then

                                        MemoryStream = New System.IO.MemoryStream(Employee.SignatureImage)

                                        PdfFileSignature.SignatureAppearanceStream = MemoryStream

                                    End If

                                    PKCS7.ContactInfo = Employee.ToString

                                End If

                                For Each SignatureName In PdfFileSignature.GetBlankSignNames.OfType(Of String).ToList

                                    PdfFileSignature.Sign(SignatureName, PKCS7)
                                    HasBlankSignature = True

                                Next

                                If HasBlankSignature = False Then

                                    PdfFileSignature.Sign(1, "Advantage Digital Sign", Employee.ToString, "", True, New System.Drawing.Rectangle(100, 100, 200, 100), PKCS7)

                                End If

                                PdfFileSignature.Save(Folder & Document.FileSystemFileName)

                                Document.FileSize = AdvantageFramework.FileSystem.GetFileSize(Folder & Document.FileSystemFileName)

                                DocumentSigned = AdvantageFramework.Database.Procedures.Document.Update(DbContext, Document)

                            End Using

                        End Using

                        Try

                            If MemoryStream IsNot Nothing Then

                                MemoryStream.Close()
                                MemoryStream.Dispose()
                                MemoryStream = Nothing

                            End If

                        Catch ex As Exception

                        End Try

                        If PKCS7 IsNot Nothing Then

                            PKCS7 = Nothing

                        End If

                        If License IsNot Nothing Then

                            License = Nothing

                        End If

                    End If

                    If Agency.FileSystemUserName IsNot Nothing AndAlso Agency.FileSystemUserName <> "" Then

                        AliasAccount.EndImpersonation()

                    End If

                End If

            End Using

        Catch ex As Exception
            DocumentSigned = False

            If ex IsNot Nothing Then

                AdvantageFramework.Security.AddWebvantageEventLog(ex.Message, Diagnostics.EventLogEntryType.Error)

                If ex.InnerException IsNot Nothing Then

                    AdvantageFramework.Security.AddWebvantageEventLog(ex.InnerException.Message, Diagnostics.EventLogEntryType.Error)

                End If

            End If

        End Try

        If DocumentSigned Then

            If _AlertID > 0 Then

                AlertComment = New AlertComment(CStr(HttpContext.Current.Session("ConnString")))

                If Me.IsClientPortal = True Then

                    AlertComment.AddNewComment(_AlertID, "", "Digitally Signed - " & Document.FileName, HttpContext.Current.Session("UserID"))

                Else

                    AlertComment.AddNewComment(_AlertID, HttpContext.Current.Session("UserCode"), "Digitally Signed - " & Document.FileName)

                End If

                Me.RefreshCaller("Alert_View.aspx")

            End If

        End If

        SignDocument = DocumentSigned

    End Function

#Region "  Form Event Handlers "

    Private Sub Documents_PDFViewer_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Me.AllowFloat = True

    End Sub
    Private Sub Documents_PDFViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim LoadMaxPageNumber As Boolean = False
        Dim LoadDocument As Boolean = False

        LoadQueryStringValues()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            LoadDocument = True
            LoadMaxPageNumber = True

        Else

            If Me.EventTarget.Contains(RadToolBarDocumentViewer.ID) Then

                If Me.EventArgument = "1" Then

                    Me.Response.Redirect(String.Format("Documents_PDFViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, 1, _Width, _Height))

                ElseIf Me.EventArgument = "3" Then

                    Me.Response.Redirect(String.Format("Documents_PDFViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, _PageNumber - 1, _Width, _Height))

                ElseIf Me.EventArgument = "5" Then

                    Me.Response.Redirect(String.Format("Documents_PDFViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, _PageNumber + 1, _Width, _Height))

                ElseIf Me.EventArgument = "7" Then

                    Me.Response.Redirect(String.Format("Documents_PDFViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, Session(_DocumentID & "MaxPageNumber"), _Width, _Height))

                ElseIf Me.EventArgument = "10" Then

                    If RadPanelBarComments.SelectedItem Is Nothing Then

                        LoadDocument = True

                    End If

                ElseIf Me.EventArgument = "17" Then

                    _Width = _Width + 80

                    _Height = _Height + 100

                    Me.Response.Redirect(String.Format("Documents_PDFViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, _PageNumber, _Width, _Height))

                ElseIf Me.EventArgument = "19" Then

                    If _Width > 80 Then

                        _Width = _Width - 80

                    End If

                    If _Height > 100 Then

                        _Height = _Height - 100

                    End If

                    Me.Response.Redirect(String.Format("Documents_PDFViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, _PageNumber, _Width, _Height))

                End If

            ElseIf Me.EventArgument = "Refresh" Then

                LoadDocument = True

            End If

        End If

        If LoadDocument Then

            LoadDocumentPage(_PageNumber, LoadMaxPageNumber)

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDocumentViewer_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDocumentViewer.ButtonClick

        'objects
        Dim DocumentComment As AdvantageFramework.Database.Entities.DocumentComment = Nothing

        LoadQueryStringValues()

        Select Case e.Item.Value

            Case RadToolBarButtonAddComment.Value

                Me.OpenWindow("Add Comment", String.Format("Documents_AddComment.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, _PageNumber, _Width, _Height), 0, 0, False, True, "RefreshPage")

            Case RadToolBarButtonDeleteComment.Value

                If RadPanelBarComments.SelectedItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            DocumentComment = AdvantageFramework.Database.Procedures.DocumentComment.LoadByDocumentCommentID(DbContext, CLng(RadPanelBarComments.SelectedItem.Value))

                        Catch ex As Exception
                            DocumentComment = Nothing
                        End Try

                        If DocumentComment IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.DocumentComment.Delete(DbContext, DocumentComment)

                        End If

                    End Using

                    Me.Response.Redirect(String.Format("Documents_PDFViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, _PageNumber, _Width, _Height))

                End If

            Case RadToolBarButtonDigitallySign.Value

                SignDocument(_Session, _DocumentID)

                Me.Response.Redirect(String.Format("Documents_PDFViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, _PageNumber, _Width, _Height))

        End Select

    End Sub

#End Region

#End Region

End Class
