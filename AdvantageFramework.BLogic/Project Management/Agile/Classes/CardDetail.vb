Namespace ProjectManagement.Agile.Classes

    <Serializable()>
    Public Class CardDetail

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        Public Property AlertID As Integer?
        Public Property SprintDetailID As Integer?
        Public Property Alert As AdvantageFramework.Database.Entities.Alert = Nothing
        Public Property Comments As List(Of Comment) = Nothing

#End Region

#Region " Methods "

        Public Sub Load()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AlertID IsNot Nothing AndAlso AlertID > 0 Then

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                    If Alert IsNot Nothing Then

                        Dim AlertComments As Generic.List(Of AdvantageFramework.Database.Entities.AlertComment) = Nothing

                        AlertComments = AdvantageFramework.Database.Procedures.AlertComment.LoadByAlertID(DbContext, AlertID).ToList

                        If AlertComments IsNot Nothing Then

                            Dim Cmt As Comment = Nothing

                            For Each Comment As AdvantageFramework.Database.Entities.AlertComment In AlertComments

                                Cmt = New Comment

                                Cmt.UserCode = Comment.UserCode
                                Cmt.Comment = Comment.Comment
                                Cmt.CommentDate = Comment.GeneratedDate

                                Comments.Add(Cmt)
                                Cmt = Nothing

                            Next

                        End If

                    End If

                End If

            End Using

        End Sub

        Public Sub New()

            Comments = New List(Of Comment)

        End Sub
        Public Sub New(ByVal Session As AdvantageFramework.Security.Session)

            Me.New
            _Session = Session

        End Sub

#End Region

#Region " Classes "

        <Serializable()>
        Public Class Comment

            Public Property CommentID As Integer?
            Public Property Comment As String = String.Empty
            Public Property CommentDate As DateTime?
            Public Property UserCode As String = String.Empty
            Public Property CommentDateString As String = String.Empty
            Public Property FullName As String = String.Empty
            Public Property EmployeePicture As Byte()
            Public Property EmployeePictureURL As String = String.Empty

            Sub New()

            End Sub

        End Class

#End Region

    End Class

End Namespace

