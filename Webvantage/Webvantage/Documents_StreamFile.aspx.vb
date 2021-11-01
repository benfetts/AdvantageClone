Public Class Documents_StreamFile
    Inherits System.Web.UI.Page
    Private ConnectionString As String = ""
    Private DocumentId As Integer = 0
    Private AccessPrivate As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim FromMobile As Boolean = False

        'If HttpContext.Current.Request.Headers("Authorization") IsNot Nothing Then

        '    FromMobile = True

        'End If

        If FromMobile = False Then

            Dim SecuritySession
            If Request.QueryString("cp") = "True" Then

                SecuritySession = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Client_Portal, HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), CInt(HttpContext.Current.Session("AdvantageUserLicenseInUseID")), HttpContext.Current.Session("ConnString"))

            Else

                SecuritySession = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), CInt(HttpContext.Current.Session("AdvantageUserLicenseInUseID")), HttpContext.Current.Session("ConnString"))

            End If
            If Session("ConnString") IsNot Nothing Then

                Me.ConnectionString = Session("ConnString")

            End If
            Me.AccessPrivate = AdvantageFramework.Security.LoadUserGroupSetting(SecuritySession, AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments).Any(Function(SettingValue) SettingValue = True)

        Else

            'Get/parse mobile security header
            'test
            Me.AccessPrivate = True
            Dim AuthString As String = ""

            Dim Cred As New AdvantageFramework.Mobile.Classes.Credential(HttpContext.Current.Request.Headers("Authorization"))


        End If

        If Not Request.QueryString("id") Is Nothing Then

            Me.DocumentId = CType(Request.QueryString("id"), Integer)

        End If

        If DocumentId > 0 Then

            Dim Document As New Document(Me.ConnectionString)
            Document.LoadByPrimaryKey(DocumentId)
            Dim DocumentRepository As New DocumentRepository(Me.ConnectionString)
            Dim RealFilename As String = Document.FILENAME  ' Filename

            If AccessPrivate = False And Document.PRIVATE_FLAG = 1 Then

                Exit Sub

            End If

            Dim MimeType As String = ""
            Try

                MimeType = Document.MIME_TYPE

            Catch ex As Exception

                MimeType = String.Empty

            End Try

            If RealFilename.ToLower().EndsWith(".docx") = True Then MimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
            If RealFilename.ToLower().EndsWith(".xlsx") = True Then MimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            If RealFilename.ToLower().EndsWith(".pptx") = True Then MimeType = "application/vnd.openxmlformats-officedocument.presentationml.presentation"

            With HttpContext.Current.Response

                Try

                    Dim FileBytes() As Byte = DocumentRepository.GetDocument(DocumentId)
                    .Buffer = True
                    .AddHeader("Content-Disposition", "attachment;filename=""" & RealFilename & """")
                    '.AddHeader("Content-Length", FileBytes.Length.ToString())
                    .AddHeader("Content-Length", Document.s_FILE_SIZE)
                    .ContentType = MimeType
                    .BinaryWrite(FileBytes)
                    .End()
                    .Flush()
                    .Clear()

                Catch ex As Exception

                    .End()
                    .Clear()

                End Try

            End With

        End If

    End Sub

End Class
