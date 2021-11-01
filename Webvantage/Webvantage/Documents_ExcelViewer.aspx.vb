Public Class Documents_ExcelViewer
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
        Dim Workbook As Aspose.Cells.Workbook = Nothing
        Dim ImageOrPrintOptions As Aspose.Cells.Rendering.ImageOrPrintOptions = Nothing
        Dim SheetRender As Aspose.Cells.Rendering.SheetRender = Nothing
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim License As Aspose.Cells.License = Nothing

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

                If Document.FileName.ToUpper.Contains(".XLS") OrElse Document.FileName.ToUpper.Contains(".XLSX") Then

                    Me.Title = Document.FileName

                    License = New Aspose.Cells.License

                    License.SetLicense("Aspose.Total.lic")

                    Workbook = New Aspose.Cells.Workbook(Folder & Document.FileSystemFileName)

                    ImageOrPrintOptions = New Aspose.Cells.Rendering.ImageOrPrintOptions

                    ImageOrPrintOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Png
                    ImageOrPrintOptions.OnePagePerSheet = True

                    MemoryStream = New System.IO.MemoryStream

                    SheetRender = New Aspose.Cells.Rendering.SheetRender(Workbook.Worksheets(PageNumber), ImageOrPrintOptions)

                    SheetRender.ToImage(0, MemoryStream)

                    RadBinaryImagePage.DataValue = MemoryStream.ToArray()

                    If Workbook.Worksheets.Count <= 1 Then

                        RadToolBarButtonGoToFirstPage.Enabled = False
                        RadToolBarButtonGoToPreviousPage.Enabled = False
                        RadToolBarButtonGoToNextPage.Enabled = False
                        RadToolBarButtonGoToLastPage.Enabled = False

                    ElseIf PageNumber = 0 Then

                        RadToolBarButtonGoToFirstPage.Enabled = False
                        RadToolBarButtonGoToPreviousPage.Enabled = False
                        RadToolBarButtonGoToNextPage.Enabled = True
                        RadToolBarButtonGoToLastPage.Enabled = True

                    ElseIf PageNumber = Workbook.Worksheets.Count - 1 Then

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

                        Session(_DocumentID & "MaxPageNumber") = Workbook.Worksheets.Count - 1

                    End If

                    If Workbook IsNot Nothing Then

                        Workbook = Nothing

                    End If

                    If ImageOrPrintOptions IsNot Nothing Then

                        ImageOrPrintOptions = Nothing

                    End If

                    If SheetRender IsNot Nothing Then

                        SheetRender = Nothing

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

#Region "  Form Event Handlers "

    Private Sub Documents_ExcelViewer_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Me.AllowFloat = True

    End Sub
    Private Sub Documents_ExcelViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

                    Me.Response.Redirect(String.Format("Documents_ExcelViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, 0, _Width, _Height))

                ElseIf Me.EventArgument = "3" Then

                    Me.Response.Redirect(String.Format("Documents_ExcelViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, _PageNumber - 1, _Width, _Height))

                ElseIf Me.EventArgument = "5" Then

                    Me.Response.Redirect(String.Format("Documents_ExcelViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, _PageNumber + 1, _Width, _Height))

                ElseIf Me.EventArgument = "7" Then

                    Me.Response.Redirect(String.Format("Documents_ExcelViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, Session(_DocumentID & "MaxPageNumber"), _Width, _Height))

                ElseIf Me.EventArgument = "10" Then

                    If RadPanelBarComments.SelectedItem Is Nothing Then

                        LoadDocument = True

                    End If

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

                    Me.Response.Redirect(String.Format("Documents_ExcelViewer.aspx?DocumentID={0}&PageNumber={1}&Width={2}&Height={3}", _DocumentID, _PageNumber, _Width, _Height))

                End If

        End Select

    End Sub

#End Region

#End Region

End Class
