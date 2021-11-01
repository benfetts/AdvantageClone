Public Class Documents_MediaViewer
    Inherits Webvantage.BaseChildPage

    Private _DocumentId As Integer = 0

    Private Sub Documents_MediaViewer_Init(sender As Object, e As EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        Me._DocumentId = qs.DocumentID()

        If Me._DocumentId > 0 Then

            Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                Dim doc As AdvantageFramework.Database.Entities.Document = Nothing

                doc = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, Me._DocumentId)

                If Not doc Is Nothing Then

                    Select Case doc.FileType

                        Case AdvantageFramework.FileSystem.FileTypes.Zip



                    End Select

                End If

            End Using

        End If

    End Sub

End Class