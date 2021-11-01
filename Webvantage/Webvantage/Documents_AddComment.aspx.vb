Public Class Documents_AddComment
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Function LoadDocumentID() As Integer

        'objects
        Dim DocumentID As Integer = 0

        Try

            If Request.QueryString("DocumentID") IsNot Nothing Then

                DocumentID = CType(Request.QueryString("DocumentID"), Integer)

            End If

        Catch ex As Exception
            DocumentID = 0
        End Try

        If Me.CurrentQuerystring.DocumentID > 0 Then DocumentID = Me.CurrentQuerystring.DocumentID

        LoadDocumentID = DocumentID

    End Function
    Private Function LoadPageNumber() As Integer

        'objects
        Dim PageNumber As Integer = 1

        Try

            If Request.QueryString("PageNumber") IsNot Nothing Then

                PageNumber = CType(Request.QueryString("PageNumber"), Integer)

            End If

        Catch ex As Exception
            PageNumber = 1
        End Try

        LoadPageNumber = PageNumber

    End Function
    Private Function LoadHeight(ByVal FileName As String) As Double

        'objects
        Dim Height As Double = 1

        Try

            If Request.QueryString("Height") IsNot Nothing Then

                Height = CType(Request.QueryString("Height"), Double)

            ElseIf FileName.ToUpper.EndsWith(".PDF") Then

                Height = 1000

            ElseIf FileName.ToUpper.EndsWith(".DOC") OrElse FileName.ToUpper.EndsWith(".DOCX") Then

                Height = 100

            Else

                Height = 1

            End If

        Catch ex As Exception

            If FileName.ToUpper.EndsWith(".PDF") Then

                Height = 1000

            ElseIf FileName.ToUpper.EndsWith(".DOC") OrElse FileName.ToUpper.EndsWith(".DOCX") Then

                Height = 100

            Else

                Height = 1

            End If

        End Try

        LoadHeight = Height

    End Function
    Private Function LoadWidth(ByVal FileName As String) As Double

        'objects
        Dim Width As Double = 1

        Try

            If Request.QueryString("Width") IsNot Nothing Then

                Width = CType(Request.QueryString("Width"), Double)

            ElseIf FileName.ToUpper.EndsWith(".PDF") Then

                Width = 800

            ElseIf FileName.ToUpper.EndsWith(".DOC") OrElse FileName.ToUpper.EndsWith(".DOCX") Then

                Width = 0.1

            Else

                Width = 1

            End If

        Catch ex As Exception

            If FileName.ToUpper.EndsWith(".PDF") Then

                Width = 800

            ElseIf FileName.ToUpper.EndsWith(".DOC") OrElse FileName.ToUpper.EndsWith(".DOCX") Then

                Width = 0.1

            Else

                Width = 1

            End If

        End Try

        LoadWidth = Width

    End Function

#Region "  Form Event Handlers "

    Private Sub Documents_AddComment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.FocusControl(TextBoxComment)

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarAddComment_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarAddComment.ButtonClick

        Select Case e.Item.Value
            Case "Save"

                'objects
                Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
                Dim Success As Boolean = False

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, LoadDocumentID)

                    If Document IsNot Nothing Then

                        If Me.IsClientPortal = True Then

                            Success = AdvantageFramework.Database.Procedures.DocumentComment.Insert(DbContext, Document.ID, "",
                                                                                        Now, Now, TextBoxComment.Text, LoadPageNumber, "", Session("UserID"), Nothing)

                        Else

                            Success = AdvantageFramework.Database.Procedures.DocumentComment.Insert(DbContext, Document.ID, Session("UserCode").ToString(),
                                                                                         Now, Now, TextBoxComment.Text, LoadPageNumber, _Session.User.EmployeeCode, 0, Nothing)

                        End If

                        If Success = True Then

                            Dim CallingPage As String = ""

                            If Document.FileName.ToUpper.EndsWith(".PDF") Then

                                CallingPage = "Documents_PDFViewer.aspx"

                            ElseIf Document.FileName.ToUpper.EndsWith(".DOC") OrElse Document.FileName.ToUpper.EndsWith(".DOCX") Then

                                CallingPage = "Documents_WordViewer.aspx"

                            ElseIf Document.FileName.ToUpper.EndsWith(".GIF") OrElse Document.FileName.ToUpper.EndsWith(".JPEG") OrElse _
                                    Document.FileName.ToUpper.EndsWith(".PJPEG") OrElse Document.FileName.ToUpper.EndsWith(".PNG") OrElse _
                                    Document.FileName.ToUpper.EndsWith(".JPG") OrElse Document.FileName.ToUpper.EndsWith(".TIFF") OrElse _
                                    Document.FileName.ToUpper.EndsWith(".BMP") Then

                                CallingPage = "Documents_ImageViewer.aspx"

                            ElseIf Document.FileName.ToUpper.EndsWith(".MSG") Then

                                CallingPage = "Documents_MSGViewer.aspx"

                            ElseIf Document.FileName.ToUpper.Contains(".XLS") OrElse Document.FileName.ToUpper.Contains(".XLSX") Then

                                CallingPage = "Documents_ExcelViewer.aspx"

                            End If

                            Me.CloseThisWindowAndRefreshCaller(CallingPage)

                        Else

                            Me.ShowMessage("Error saving comment")

                        End If

                    End If

                End Using

            Case "Cancel"

                Me.CloseThisWindow()

        End Select

    End Sub

#End Region

#End Region

End Class