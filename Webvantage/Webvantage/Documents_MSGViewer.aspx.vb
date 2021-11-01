Imports System.Drawing
Public Class Documents_MSGViewer
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _DocumentID As Integer = 0
    Private _PageNumber As Integer = 1
    Private _Width As Double = 0.8
    Private _Height As Double = 100

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
        Dim MailMessage As Aspose.Network.Mail.MailMessage = Nothing
        Dim WordDocument As Aspose.Words.Document = Nothing
        Dim LoadOptions As Aspose.Words.LoadOptions = Nothing
        Dim PageInfo As Aspose.Words.Rendering.PageInfo = Nothing
        Dim PageSize As System.Drawing.Size = Nothing
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim MhtmlMemoryStream As System.IO.MemoryStream = Nothing
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim License As Aspose.Words.License = Nothing
        Dim NetworkLicense As Aspose.Network.License = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, _DocumentID)

            If Document IsNot Nothing Then

                LoadComments(Document.ID, PageNumber)

                If Agency.FileSystemUserName IsNot Nothing AndAlso Agency.FileSystemUserName <> "" Then

                    AliasAccount.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                End If

                Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\")

                If Document.FileName.ToUpper.Contains(".MSG") Then

                    Me.Title = Document.FileName

                    License = New Aspose.Words.License

                    License.SetLicense("Aspose.Total.lic")

                    NetworkLicense = New Aspose.Network.License

                    NetworkLicense.SetLicense("Aspose.Total.lic")

                    MailMessage = Aspose.Network.Mail.MailMessage.Load(Folder & Document.FileSystemFileName, Aspose.Network.Mail.MessageFormat.Msg)

                    MhtmlMemoryStream = New System.IO.MemoryStream

                    MailMessage.Save(MhtmlMemoryStream, Aspose.Network.Mail.MailMessageSaveType.MHtmlFromat)

                    MhtmlMemoryStream.Position = 0

                    LoadOptions = New Aspose.Words.LoadOptions

                    LoadOptions.LoadFormat = Aspose.Words.LoadFormat.Mhtml

                    WordDocument = New Aspose.Words.Document(MhtmlMemoryStream, LoadOptions)

                    PageInfo = WordDocument.GetPageInfo(_PageNumber - 1)

                    PageSize = PageInfo.GetSizeInPixels(_Width, _Height)

                    Using Bitmap = New System.Drawing.Bitmap(PageSize.Width, PageSize.Height)

                        Bitmap.SetResolution(100, 100)

                        Using Graphics = System.Drawing.Graphics.FromImage(Bitmap)

                            Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

                            Graphics.FillRectangle(Drawing.Brushes.White, 0, 0, PageSize.Width, PageSize.Height)

                            WordDocument.RenderToScale(_PageNumber - 1, Graphics, 0, 0, _Width)

                        End Using

                        MemoryStream = New System.IO.MemoryStream

                        Bitmap.Save(MemoryStream, System.Drawing.Imaging.ImageFormat.Bmp)

                    End Using

                    RadBinaryImagePage.DataValue = MemoryStream.ToArray()

                    If WordDocument.PageCount <= 1 Then

                        RadToolBarButtonGoToFirstPage.Enabled = False
                        RadToolBarButtonGoToPreviousPage.Enabled = False
                        RadToolBarButtonGoToNextPage.Enabled = False
                        RadToolBarButtonGoToLastPage.Enabled = False

                    ElseIf PageNumber = 1 Then

                        RadToolBarButtonGoToFirstPage.Enabled = False
                        RadToolBarButtonGoToPreviousPage.Enabled = False
                        RadToolBarButtonGoToNextPage.Enabled = True
                        RadToolBarButtonGoToLastPage.Enabled = True

                    ElseIf PageNumber = WordDocument.PageCount Then

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

                        Session(_DocumentID & "MaxPageNumber") = WordDocument.PageCount

                    End If

                    If WordDocument IsNot Nothing Then

                        WordDocument = Nothing

                    End If

                    Try

                        If MemoryStream IsNot Nothing Then

                            MemoryStream.Close()

                            MemoryStream.Dispose()

                            MemoryStream = Nothing

                        End If

                    Catch ex As Exception

                    End Try

                    Try

                        If MhtmlMemoryStream IsNot Nothing Then

                            MhtmlMemoryStream.Close()

                            MhtmlMemoryStream.Dispose()

                            MhtmlMemoryStream = Nothing

                        End If

                    Catch ex As Exception

                    End Try

                    If License IsNot Nothing Then

                        License = Nothing

                    End If

                    If NetworkLicense IsNot Nothing Then

                        NetworkLicense = Nothing

                    End If

                End If

                If Agency.FileSystemUserName IsNot Nothing AndAlso Agency.FileSystemUserName <> "" Then

                    AliasAccount.EndImpersonation()

                End If

            End If

        End Using

    End Sub

#Region "  Form Event Handlers "

    Private Sub Documents_MSGViewer_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Me.AllowFloat = True

    End Sub
    Private Sub Documents_MSGViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

                    Me.Response.Redirect(String.Format("Documents_MSGViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, 1, _Width, _Height))

                ElseIf Me.EventArgument = "3" Then

                    Me.Response.Redirect(String.Format("Documents_MSGViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, _PageNumber - 1, _Width, _Height))

                ElseIf Me.EventArgument = "5" Then

                    Me.Response.Redirect(String.Format("Documents_MSGViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, _PageNumber + 1, _Width, _Height))

                ElseIf Me.EventArgument = "7" Then

                    Me.Response.Redirect(String.Format("Documents_MSGViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, Session(_DocumentID & "MaxPageNumber"), _Width, _Height))

                ElseIf Me.EventArgument = "10" Then

                    If RadPanelBarComments.SelectedItem Is Nothing Then

                        LoadDocument = True

                    End If

                ElseIf Me.EventArgument = "17" Then

                    _Width = _Width + 0.1

                    _Height = _Height + 10

                    Me.Response.Redirect(String.Format("Documents_MSGViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, _PageNumber, _Width, _Height))

                ElseIf Me.EventArgument = "19" Then

                    If _Width > 0.1 Then

                        _Width = _Width - 0.1

                    End If

                    If _Height > 10 Then

                        _Height = _Height - 10

                    End If

                    Me.Response.Redirect(String.Format("Documents_MSGViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, _PageNumber, _Width, _Height))

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

                    Me.Response.Redirect(String.Format("Documents_MSGViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, _PageNumber, _Width, _Height))

                End If

        End Select

    End Sub

#End Region

#End Region

End Class
