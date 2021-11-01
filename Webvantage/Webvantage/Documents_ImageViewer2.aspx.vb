Public Class Documents_ImageViewer2
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _DocumentID As Integer = 0
    Private _PageNumber As Integer = 1
    Private _CurrentImage As Telerik.Web.UI.ImageEditor.EditableImage = Nothing

#End Region

#Region " Properties "



#End Region

#Region "  Form Event Handlers "

    Private Sub Documents_ImageViewer2_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

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

    End Sub
    Private Sub Documents_ImageViewer2_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Dim s As String = ""
            If Me.SetImage(s) = True Then

                'LoadComments(Me._DocumentID, Me._PageNumber)

            Else

                Me.ShowMessage(s)

            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "


    Private _Changes As New Generic.List(Of String)

    Private Sub RadImageEditor1_ImageEditing(sender As Object, args As Telerik.Web.UI.ImageEditorEditingEventArgs) Handles RadImageEditor1.ImageEditing

        Select Case args.CommandName
            Case "AddText"
                If Not Session("ImageChanges") Is Nothing Then
                    _Changes = Session("ImageChanges")
                End If
                _Changes.Add("Text added: """ & args.ClientObjectsDictionary("text") & """" & " at " & Now.ToString())
                Session("ImageChanges") = _Changes
        End Select
    End Sub
    Private Sub RadImageEditor1_ImageLoading(sender As Object, args As Telerik.Web.UI.ImageEditorLoadingEventArgs) Handles RadImageEditor1.ImageLoading

        If Not Me._CurrentImage Is Nothing Then

            args.Image = Me._CurrentImage
            args.Cancel = True

        End If

    End Sub
    Private Sub RadImageEditor1_ImageSaving(sender As Object, args As Telerik.Web.UI.ImageEditorSavingEventArgs) Handles RadImageEditor1.ImageSaving
        If Not Session("ImageChanges") Is Nothing Then
            _Changes = Session("ImageChanges")
            If Not _Changes Is Nothing And _Changes.Count > 0 Then

                Dim SbChanges As New System.Text.StringBuilder
                For Each s As String In _Changes
                    SbChanges.Append(s)
                    SbChanges.Append(Environment.NewLine)
                Next

                Dim DocumentComment As AdvantageFramework.Database.Entities.DocumentComment = Nothing

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DocumentComment = New AdvantageFramework.Database.Entities.DocumentComment

                    DocumentComment.DbContext = DbContext

                    DocumentComment.DocumentID = _DocumentID
                    If IsClientPortal = True Then
                        DocumentComment.UserCode = ""
                        DocumentComment.EmployeeCode = ""
                    Else
                        DocumentComment.UserCode = _Session.UserCode
                        DocumentComment.EmployeeCode = _Session.User.EmployeeCode
                    End If

                    DocumentComment.CreatedDate = Now
                    DocumentComment.ModifiedDate = Now
                    DocumentComment.Comment = SbChanges.ToString()
                    DocumentComment.PageNumber = _PageNumber

                    DocumentComment.XPosition = 0 'args.ClientObjectsDictionary("x")
                    DocumentComment.YPosition = 0 'args.ClientObjectsDictionary("y")
                    DocumentComment.FontColor = "" 'args.ClientObjectsDictionary("color")
                    DocumentComment.FontFamily = "" 'args.ClientObjectsDictionary("font")
                    DocumentComment.FontSize = 0 'args.ClientObjectsDictionary("size")

                    If IsClientPortal = True Then
                        DocumentComment.UserCodeCP = Session("UserID")
                    Else
                        DocumentComment.UserCodeCP = 0
                    End If


                    If AdvantageFramework.Database.Procedures.DocumentComment.Insert(DbContext, DocumentComment) Then

                        RadGridImageComments.Rebind()

                    End If

                    'save image
                    ''get orginal image info, save to repository again, (it should save to doc history)

                    'clear session


                End Using

            End If

        End If
    End Sub
    Private Sub RadImageEditor1_PreRender(sender As Object, e As System.EventArgs) Handles RadImageEditor1.PreRender

    End Sub

#End Region

#Region " Methods "

    Private Function SetImage(ByRef ErrorMessage As String) As Boolean
        'objects
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim Folder As String = ""
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim ImageURL As String = ""

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, _DocumentID)

                If Document IsNot Nothing Then


                    If Agency.FileSystemUserName IsNot Nothing AndAlso Agency.FileSystemUserName <> "" Then

                        AliasAccount.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                    End If

                    Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\")

                    If Document.FileName.ToUpper.EndsWith(".GIF") OrElse Document.FileName.ToUpper.EndsWith(".JPEG") OrElse
                            Document.FileName.ToUpper.EndsWith(".PJPEG") OrElse Document.FileName.ToUpper.EndsWith(".PNG") OrElse
                            Document.FileName.ToUpper.EndsWith(".JPG") OrElse Document.FileName.ToUpper.EndsWith(".TIFF") Then

                        Me.Title = Document.FileName

                        'Me.RadImageEditor1.ImageUrl = Folder & Document.FileSystemFileName
                        'LoadComments(Document.ID, PageNumber)
                        ImageURL = Folder & Document.FileSystemFileName

                    Else

                        ImageURL = ""

                    End If

                    If ImageURL <> "" Then

                        Dim ImageBytes As Byte() = Nothing
                        Dim MemoryStream As System.IO.MemoryStream = Nothing

                        Using Stream As System.IO.Stream = My.Computer.FileSystem.GetFileInfo(ImageURL).OpenRead

                            ImageBytes = New Byte(Stream.Length) {}

                            Stream.Read(ImageBytes, 0, ImageBytes.Length)

                            MemoryStream = New System.IO.MemoryStream
                            MemoryStream.Write(ImageBytes, 0, ImageBytes.Length)

                            Using EditableImage As New Telerik.Web.UI.ImageEditor.EditableImage(MemoryStream)

                                Me._CurrentImage = EditableImage.Clone()

                            End Using

                        End Using

                    End If

                    If Agency.FileSystemUserName IsNot Nothing AndAlso Agency.FileSystemUserName <> "" Then

                        AliasAccount.EndImpersonation()

                    End If

                End If


            End Using

        Catch ex As Exception

            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())

            Agency = Nothing
            Folder = Nothing
            Document = Nothing

            Return False

        Finally

            Agency = Nothing
            Folder = Nothing
            Document = Nothing

        End Try

    End Function

    'Private Sub LoadComments(ByVal DocumentID As Integer, ByVal PageNumber As Integer)

    '    'objects
    '    Dim RadPanelItem As Telerik.Web.UI.RadPanelItem = Nothing
    '    Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
    '    Dim ClientContact As AdvantageFramework.Security.Database.Entities.ClientContact = Nothing
    '    Dim CommentPanelItemIndexesList As Generic.List(Of String) = Nothing
    '    Dim HeaderText As String = ""

    '    RadPanelBarComments.Items.Clear()

    '    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '        CommentPanelItemIndexesList = New Generic.List(Of String)

    '        For Each DocumentComment In AdvantageFramework.Database.Procedures.DocumentComment.LoadByDocumentIDAndPageNumber(DbContext, DocumentID, PageNumber)

    '            If DocumentComment.XPosition Is Nothing AndAlso DocumentComment.YPosition Is Nothing Then

    '                RadPanelItem = New Telerik.Web.UI.RadPanelItem

    '                RadPanelItem.Value = DocumentComment.ID

    '                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, DocumentComment.EmployeeCode)

    '                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '                    If DocumentComment.UserCodeCP IsNot Nothing Then
    '                        ClientContact = AdvantageFramework.Security.Database.Procedures.ClientContact.LoadByClientContactID(SecurityDbContext, DocumentComment.UserCodeCP)
    '                    End If

    '                End Using

    '                If Employee IsNot Nothing Then

    '                    HeaderText = Employee.ToString & " - " & DocumentComment.CreatedDate.ToShortDateString & " " & DocumentComment.CreatedDate.ToLongTimeString

    '                ElseIf ClientContact IsNot Nothing Then

    '                    HeaderText = ClientContact.FullNameFML & " - " & DocumentComment.CreatedDate.ToShortDateString & " " & DocumentComment.CreatedDate.ToLongTimeString

    '                Else

    '                    HeaderText = DocumentComment.UserCode & " - " & DocumentComment.CreatedDate.ToShortDateString & " " & DocumentComment.CreatedDate.ToLongTimeString

    '                End If

    '                RadPanelItem.ContentTemplate = New AdvantageFramework.Web.Presentation.Controls.DocumentCommentTemplate(DocumentComment.Comment)

    '                RadPanelItem.Text = HeaderText

    '                RadPanelBarComments.Items.Add(RadPanelItem)

    '                CommentPanelItemIndexesList.Add(RadPanelItem.Index)

    '            End If

    '        Next

    '        Try

    '            If Request.Cookies(RadPanelBarComments.ClientID).Value <> "" AndAlso Request.Cookies(RadPanelBarComments.ClientID).Value <> "{'ExpandedItems':[]}" Then

    '                If CommentPanelItemIndexesList.Count > 0 Then

    '                    Request.Cookies(RadPanelBarComments.ClientID).Value = "{'ExpandedItems':[" & Join(CommentPanelItemIndexesList.ToArray, ",") & "]}"

    '                End If

    '            End If

    '        Catch ex As Exception

    '        End Try

    '        RadGridImageComments.Rebind()

    '    End Using

    'End Sub


#End Region

    Private Sub RadGridImageComments_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridImageComments.NeedDataSource

        Dim DocumentComments As Generic.List(Of AdvantageFramework.Database.Entities.DocumentComment) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            DocumentComments = AdvantageFramework.Database.Procedures.DocumentComment.LoadByDocumentIDAndPageNumber(DbContext, _DocumentID, _PageNumber).Where(Function(DocumentComment) DocumentComment.XPosition IsNot Nothing AndAlso DocumentComment.YPosition IsNot Nothing).ToList

            RadGridImageComments.DataSource = DocumentComments

        End Using

    End Sub

End Class
