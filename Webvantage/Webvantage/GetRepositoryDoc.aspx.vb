'' NOTE:  THIS PAGE HANDLES OPENING REPOSITORY DOCS FROM ADVANTAGE!!!
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.Core
Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Webvantage.SqlHelper

Public Class GetRepositoryDocAspx
    Inherits System.Web.UI.Page

    Private ConnectionString As String

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Me.Visible = False
        LoGlo.PageCultureSet(Me.Page)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim filenbr As Integer
        Dim initcatalog, userid, password_encry, password, host As String

        filenbr = CType(Request.Params("docnbr"), Integer)
        initcatalog = CType(Request.Params("cat"), String)
        host = CType(Request.Params("host"), String)
        userid = CType(Request.Params("user"), String)
        password_encry = CType(Request.Params("pw"), String)

        password_encry = password_encry.Replace("-", "+")
        password_encry = password_encry.Replace("_", "/")

        password = AdvantageFramework.Security.Encryption.Decrypt(password_encry)

        Me.ConnectionString = "Initial Catalog=" + initcatalog + ";Data Source=" + host + ";User ID=" + userid + ";Password=" + password + ";"

        DeliverFile(filenbr)
    End Sub

    Private Sub DeliverFile(ByVal documentId As Integer)
        Dim Document As New Document(Me.ConnectionString)
        Document.LoadByPrimaryKey(documentId)
        If Document.MIME_TYPE <> "URL" Then
            Dim DocumentRepository As New DocumentRepository(Me.ConnectionString)
            Dim RealFilename As String = Document.FILENAME  ' Filename

            Dim MimeType As String
            Try
                MimeType = Document.MIME_TYPE
            Catch ex As Exception
                MimeType = String.Empty
            End Try

            Try
                Dim FileBytes() As Byte = DocumentRepository.GetDocument(documentId)

                ' Send the file to the user's browser
                HttpContext.Current.Response.Buffer = True
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" & RealFilename)
                HttpContext.Current.Response.AddHeader("Content-Length", FileBytes.Length.ToString())
                HttpContext.Current.Response.ContentType = MimeType
                HttpContext.Current.Response.BinaryWrite(FileBytes)
                HttpContext.Current.Response.Flush()
                HttpContext.Current.Response.End()
                HttpContext.Current.Response.Clear()
            Catch ex As Exception
                HttpContext.Current.Response.End()
                HttpContext.Current.Response.Clear()
                Me.wvMsgBox(ex.Message)
            End Try
        Else
            Me.wvMsgBox("Unable to download a link. Please click the hyperlink of the linked document to open.")

        End If
    End Sub

    Public Sub wvMsgBox(ByVal strMessage As String, Optional ByVal MsgIcon As MsgBoxIcon = MsgBoxIcon.SystemError)
        Dim strScript As String
        strScript = "<script type=""text/javascript"">alert ('" & strMessage & "');</script>"
        If Not Page.ClientScript.IsStartupScriptRegistered("JSAlert") Then
            Page.ClientScript.RegisterStartupScript(Me.GetType, "JSAlert", strScript)
        End If
    End Sub

End Class
