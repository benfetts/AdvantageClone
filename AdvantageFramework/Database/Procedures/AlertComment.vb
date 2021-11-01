Namespace Database.Procedures.AlertComment

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "
        Public Function LoadByCommentID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CommentID As Integer) As AdvantageFramework.Database.Entities.AlertComment

            LoadByCommentID = (From AlertComment In DbContext.GetQuery(Of Database.Entities.AlertComment)
                               Where AlertComment.ID = CommentID
                               Select AlertComment).SingleOrDefault

        End Function
        Public Function LoadByConceptShareCommentIDAndReplyID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                              ByVal ConceptShareCommentID As Integer, ByVal ConceptShareReplyID As Integer) As AdvantageFramework.Database.Entities.AlertComment

            LoadByConceptShareCommentIDAndReplyID = (From AlertComment In DbContext.GetQuery(Of Database.Entities.AlertComment)
                                                     Where AlertComment.ConceptShareCommentID = ConceptShareCommentID AndAlso AlertComment.ConceptShareReplyID = ConceptShareReplyID
                                                     Order By AlertComment.GeneratedDate Descending
                                                     Select AlertComment).FirstOrDefault

        End Function
        Public Function LoadByConceptShareCommentID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ConceptShareCommentID As Integer) As AdvantageFramework.Database.Entities.AlertComment

            LoadByConceptShareCommentID = (From AlertComment In DbContext.GetQuery(Of Database.Entities.AlertComment)
                                           Where AlertComment.ConceptShareCommentID = ConceptShareCommentID
                                           Order By AlertComment.GeneratedDate Descending
                                           Select AlertComment).SingleOrDefault

        End Function
        Public Function LoadByConceptShareID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer,
                                             ByVal ConceptShareProjectID As Integer, ByVal ConceptShareReviewID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertComment)

            LoadByConceptShareID = From AlertComment In DbContext.GetQuery(Of Database.Entities.AlertComment)
                                   Where AlertComment.AlertID = AlertID AndAlso AlertComment.ConceptShareProjectID = ConceptShareProjectID AndAlso AlertComment.ConceptShareReviewID = ConceptShareReviewID
                                   Order By AlertComment.ID Descending
                                   Select AlertComment

        End Function
        Public Function LoadConceptShareStatusCommentsByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertComment)

            LoadConceptShareStatusCommentsByAlertID = From AlertComment In DbContext.GetQuery(Of Database.Entities.AlertComment)
                                                      Where AlertComment.AlertID = AlertID And
                                                          (AlertComment.Comment.StartsWith("APPROVED"))
                                                      Order By AlertComment.GeneratedDate Descending
                                                      Select AlertComment

        End Function



        Public Function LoadByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertComment)

            LoadByAlertID = From AlertComment In DbContext.GetQuery(Of Database.Entities.AlertComment)
                            Where AlertComment.AlertID = AlertID
                            Order By AlertComment.GeneratedDate Descending
                            Select AlertComment

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertComment)

            Load = From AlertComment In DbContext.GetQuery(Of Database.Entities.AlertComment)
                   Order By AlertComment.GeneratedDate Descending
                   Select AlertComment

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, _
                                       ByVal AlertID As Integer, ByVal UserCode As String, _
                                       ByVal GeneratedDate As Date, ByVal Comment As String, _
                                       ByVal HasEmailBeenSent As Boolean, _
                                       ByRef AlertComment As AdvantageFramework.Database.Entities.AlertComment) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                If String.IsNullOrWhiteSpace(Comment) = False Then

                    AlertComment = New AdvantageFramework.Database.Entities.AlertComment

                    AlertComment.DbContext = DbContext
                    AlertComment.AlertID = AlertID
                    AlertComment.UserCode = UserCode
                    AlertComment.GeneratedDate = GeneratedDate
                    AlertComment.Comment = Comment
                    AlertComment.HasEmailBeenSent = HasEmailBeenSent

                    Inserted = Insert(DbContext, AlertComment)

                Else

                    Inserted = True

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertComment As AdvantageFramework.Database.Entities.AlertComment) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AlertComment IsNot Nothing AndAlso String.IsNullOrWhiteSpace(AlertComment.Comment) = False Then

                    If AlertComment.DocumentID IsNot Nothing AndAlso AlertComment.DocumentID = 0 Then

                        AlertComment.DocumentID = Nothing

                    End If

                    AlertComment.DbContext = DbContext

                    DbContext.AlertComments.Add(AlertComment)

                    ErrorText = AlertComment.ValidateEntity(IsValid)

                    If IsValid Then

                        DbContext.SaveChanges()

                        Inserted = True

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                    End If
                    If Inserted = True Then

                        AdvantageFramework.AlertSystem.UndismissCCsByAlertID(DbContext, AlertComment.AlertID)

                    End If

                Else

                    Inserted = True

                End If


            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertComment As AdvantageFramework.Database.Entities.AlertComment) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AlertComment)

                ErrorText = AlertComment.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                    AdvantageFramework.AlertSystem.UndismissCCsByAlertID(DbContext, AlertComment.AlertID)

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertComment As AdvantageFramework.Database.Entities.AlertComment) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AlertComment)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
