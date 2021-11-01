Imports Telerik.Web.UI

Public Class Documents_ImageViewer
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _DocumentID As Integer = 0
    Private _PageNumber As Integer = 1

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

                If DocumentComment.XPosition Is Nothing AndAlso DocumentComment.YPosition Is Nothing Then

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

                End If

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
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, _DocumentID)

            If Document IsNot Nothing Then

                LoadComments(Document.ID, PageNumber)

                If Agency IsNot Nothing Then

                    If Agency.FileSystemUserName IsNot Nothing AndAlso Agency.FileSystemUserName <> "" Then

                        AliasAccount.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                    End If

                End If

                Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\")

                If Document.FileName.ToUpper.EndsWith(".GIF") OrElse Document.FileName.ToUpper.EndsWith(".JPEG") OrElse
                        Document.FileName.ToUpper.EndsWith(".PJPEG") OrElse Document.FileName.ToUpper.EndsWith(".PNG") OrElse
                        Document.FileName.ToUpper.EndsWith(".JPG") OrElse Document.FileName.ToUpper.EndsWith(".TIFF") OrElse
                        Document.FileName.ToUpper.EndsWith(".BMP") Then

                    Me.Title = Document.FileName

                    RadImageEditorImage.ImageUrl = Folder & Document.FileSystemFileName

                End If

                If Agency IsNot Nothing Then

                    If Agency.FileSystemUserName IsNot Nothing AndAlso Agency.FileSystemUserName <> "" Then

                        AliasAccount.EndImpersonation()

                    End If

                End If

            End If

        End Using

    End Sub

#Region "  Form Event Handlers "

    Private Sub Documents_ImageViewer_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Me.AllowFloat = True

    End Sub
    Private Sub Documents_ImageViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim LoadMaxPageNumber As Boolean = False
        Dim LoadDocument As Boolean = True

        LoadQueryStringValues()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            LoadMaxPageNumber = True

        Else

            If Me.EventTarget.Contains(RadToolBarDocumentViewer.ID) Then

                If Me.EventArgument = "2" Then

                    LoadDocument = False

                End If

            ElseIf Me.EventTarget.Contains(RadImageEditorImage.ID) AndAlso Me.EventArgument = "Refresh" Then

                RadGridImageComments.Rebind()

            ElseIf Me.EventArgument = "Refresh" Then

                LoadDocument = True

            Else

                LoadDocument = False

            End If

        End If

        If LoadDocument Then

            LoadDocumentPage(_PageNumber, LoadMaxPageNumber)

        End If

    End Sub
    Protected Overrides Sub RaisePostBackEvent(ByVal sourceControl As System.Web.UI.IPostBackEventHandler, ByVal eventArgument As String)

        MyBase.RaisePostBackEvent(sourceControl, eventArgument)

        If sourceControl Is RadImageEditorImage AndAlso eventArgument = "Refresh" Then

            LoadQueryStringValues()

            Me.Response.Redirect(String.Format("Documents_ImageViewer.aspx?DocumentID={0}&PageNumber={1}", _DocumentID, _PageNumber))

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

                Me.OpenWindow("Add Comment", String.Format("Documents_AddComment.aspx?DocumentID={0}&PageNumber={1}", _DocumentID, _PageNumber), 0, 0, False, True, "RefreshPage")

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

                    Me.Response.Redirect(String.Format("Documents_ImageViewer.aspx?DocumentID={0}&PageNumber={1}", _DocumentID, _PageNumber))

                End If

        End Select

    End Sub
    Private Sub RadImageEditorImage_ImageLoading(ByVal sender As Object, ByVal args As Telerik.Web.UI.ImageEditorLoadingEventArgs) Handles RadImageEditorImage.ImageLoading

        'objects
        Dim ImageBytes As Byte() = Nothing
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim DocumentComments As Generic.List(Of AdvantageFramework.Database.Entities.DocumentComment) = Nothing
        Dim ImageText As Telerik.Web.UI.ImageEditor.ImageText = Nothing
        Dim Graphic As System.Drawing.Graphics = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        If Not Me.IsCallback Then

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    DocumentComments = AdvantageFramework.Database.Procedures.DocumentComment.LoadByDocumentIDAndPageNumber(DbContext, _DocumentID, _PageNumber).Where(Function(DocumentComment) DocumentComment.XPosition IsNot Nothing AndAlso DocumentComment.YPosition IsNot Nothing).ToList

                End Using

            Catch ex As Exception
                DocumentComments = New Generic.List(Of AdvantageFramework.Database.Entities.DocumentComment)
            End Try

            Try

                If Agency IsNot Nothing Then

                    If Agency.FileSystemUserName IsNot Nothing AndAlso Agency.FileSystemUserName <> "" Then

                        AliasAccount.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                    End If

                End If

                Using Stream As System.IO.Stream = My.Computer.FileSystem.GetFileInfo(RadImageEditorImage.ImageUrl).OpenRead

                    ImageBytes = New Byte(Stream.Length) {}

                    Stream.Read(ImageBytes, 0, ImageBytes.Length)

                    MemoryStream = New System.IO.MemoryStream
                    MemoryStream.Write(ImageBytes, 0, ImageBytes.Length)

                    Using EditableImage As New Telerik.Web.UI.ImageEditor.EditableImage(MemoryStream)

                        Try

                            Graphic = System.Drawing.Graphics.FromImage(EditableImage.Image)

                            For Each DocumentComment In DocumentComments

                                If DocumentComment.XPosition IsNot Nothing AndAlso DocumentComment.YPosition IsNot Nothing Then

                                    ImageText = New Telerik.Web.UI.ImageEditor.ImageText

                                    ImageText.Color = DocumentComment.FontColor
                                    ImageText.FontFamily = DocumentComment.FontFamily

                                    ImageText.Value = DocumentComment.Comment
                                    ImageText.Size = DocumentComment.FontSize.GetValueOrDefault(12)

                                    EditableImage.AddText(New System.Drawing.Point(DocumentComment.XPosition.Value, DocumentComment.YPosition.Value), ImageText)

                                End If

                            Next

                        Catch ex As Exception

                        End Try

                        args.Image = EditableImage.Clone()
                        args.Cancel = True

                    End Using

                End Using

                If Agency IsNot Nothing Then

                    If Agency.FileSystemUserName IsNot Nothing AndAlso Agency.FileSystemUserName <> "" Then

                        AliasAccount.EndImpersonation()

                    End If

                End If

            Catch ex As Exception

            End Try

        End If

    End Sub
    Protected Sub RadImageEditorImage_OnImageEditing(ByVal sender As Object, ByVal args As Telerik.Web.UI.ImageEditorEditingEventArgs) Handles RadImageEditorImage.ImageEditing

        'objects
        Dim DocumentComment As AdvantageFramework.Database.Entities.DocumentComment = Nothing

        If args.CommandName = "AddText" Then

            Try

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
                    DocumentComment.Comment = args.ClientObjectsDictionary("text")
                    DocumentComment.XPosition = args.ClientObjectsDictionary("x")
                    DocumentComment.YPosition = args.ClientObjectsDictionary("y")
                    DocumentComment.PageNumber = _PageNumber
                    DocumentComment.FontColor = args.ClientObjectsDictionary("color")
                    DocumentComment.FontFamily = args.ClientObjectsDictionary("font")
                    DocumentComment.FontSize = args.ClientObjectsDictionary("size")
                    If IsClientPortal = True Then
                        DocumentComment.UserCodeCP = Session("UserID")
                    Else
                        DocumentComment.UserCodeCP = 0
                    End If


                    If AdvantageFramework.Database.Procedures.DocumentComment.Insert(DbContext, DocumentComment) Then

                        'RadGridImageComments.Rebind()

                    End If

                End Using

            Catch ex As Exception

            End Try

        End If
    End Sub
    Private Sub RadGridImageComments_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridImageComments.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim DocumentComment As AdvantageFramework.Database.Entities.DocumentComment = Nothing

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridImageComments.Items(e.Item.ItemIndex)

        End If

        LoadQueryStringValues()

        Select Case e.CommandName

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                        DocumentComment = AdvantageFramework.Database.Procedures.DocumentComment.LoadByDocumentCommentID(DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                        If DocumentComment IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.DocumentComment.Delete(DbContext, DocumentComment) Then

                                Me.Response.Redirect(String.Format("Documents_ImageViewer.aspx?DocumentID={0}&PageNumber={1}", _DocumentID, _PageNumber))

                            End If

                        End If

                    End Using

                End If

        End Select

    End Sub
    Private Sub RadGridImageComments_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridImageComments.ItemDataBound

        'objects
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

        Try
            Dim csec As New cSecurity(Session("ConnString"))
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
                Dim dt As Telerik.Web.UI.GridDataItem = e.Item
                Dim usercode As String = dt.GetDataKeyValue("UserCode")
                Dim usercodecp As String = dt.GetDataKeyValue("UserCodeCP")
                If usercode = "" Then
                    Dim dr As SqlClient.SqlDataReader = csec.getCPUsersData(usercodecp)
                    If dr.HasRows Then
                        dr.Read()
                        If IsDBNull(dr("CONT_FML")) = False Then
                            e.Item.Cells(3).Text = dr("CONT_FML")
                        End If
                        dr.Close()
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadGridImageComments_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridImageComments.NeedDataSource

        'objects
        Dim DocumentComments As Generic.List(Of AdvantageFramework.Database.Entities.DocumentComment) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            DocumentComments = AdvantageFramework.Database.Procedures.DocumentComment.LoadByDocumentIDAndPageNumber(DbContext, _DocumentID, _PageNumber).Where(Function(DocumentComment) DocumentComment.XPosition IsNot Nothing AndAlso DocumentComment.YPosition IsNot Nothing).ToList

            RadGridImageComments.DataSource = DocumentComments

        End Using

    End Sub
    Private Sub RadImageEditorImage_DialogLoading(sender As Object, e As ImageEditorDialogEventArgs) Handles RadImageEditorImage.DialogLoading

        Dim RadColorPicker As Telerik.Web.UI.RadColorPicker = Nothing
        Dim UserThemeSettings As Webvantage.UserThemeSettings = Nothing

        If e.DialogName = "AddText" Then

            Try

                RadColorPicker = FindRadColorPickerControl(e.Panel)

                If RadColorPicker IsNot Nothing Then

                    UserThemeSettings = New Webvantage.UserThemeSettings

                    UserThemeSettings.BindColorPicker(RadColorPicker)

                End If

            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Function FindRadColorPickerControl(ByVal Control As System.Web.UI.Control)

        Dim ChildCtrl As System.Web.UI.Control

        For Each ChildControl In Control.Controls

            If TypeOf ChildControl Is Telerik.Web.UI.RadColorPicker Then

                Return ChildControl

            Else

                ChildCtrl = FindRadColorPickerControl(ChildControl)

                If ChildCtrl IsNot Nothing Then

                    Return ChildCtrl

                End If

            End If

        Next

        Return Nothing

    End Function

#End Region

#End Region

End Class
