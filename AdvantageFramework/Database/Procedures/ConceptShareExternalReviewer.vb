Namespace Database.Procedures.ConceptShareExternalReviewer

    <HideModuleName()>
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

        Public Function LoadByEmailAddressAndReviewID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ConceptShareReviewID As Integer, ByVal EmailAddress As String) As AdvantageFramework.Database.Entities.ConceptShareExternalReviewer

            Try

                LoadByEmailAddressAndReviewID = (From Entity In DbContext.GetQuery(Of Database.Entities.ConceptShareExternalReviewer)
                                                 Where Entity.ConceptShareReviewID = ConceptShareReviewID And Entity.EmailAddress = EmailAddress
                                                 Select Entity).SingleOrDefault

            Catch ex As Exception
                LoadByEmailAddressAndReviewID = Nothing
            End Try

        End Function

        Public Function LoadByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ConceptShareExternalReviewer)

            LoadByAlertID = From Entity In DbContext.GetQuery(Of Database.Entities.ConceptShareExternalReviewer)
                            Where Entity.AlertID = AlertID
                            Select Entity

        End Function
        Public Function LoadByReviewID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ConceptShareReviewID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ConceptShareExternalReviewer)

            LoadByReviewID = From Entity In DbContext.GetQuery(Of Database.Entities.ConceptShareExternalReviewer)
                             Where Entity.ConceptShareReviewID = ConceptShareReviewID
                             Select Entity

        End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ConceptShareExternalReviewer As AdvantageFramework.Database.Entities.ConceptShareExternalReviewer) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try


                DbContext.ConceptShareExternalReviewers.Add(ConceptShareExternalReviewer)

                ErrorText = ConceptShareExternalReviewer.ValidateEntity(IsValid)

                If IsValid Then


                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ConceptShareExternalReviewer As AdvantageFramework.Database.Entities.ConceptShareExternalReviewer) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ConceptShareExternalReviewer)

                ErrorText = ConceptShareExternalReviewer.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ConceptShareExternalReviewer As AdvantageFramework.Database.Entities.ConceptShareExternalReviewer) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ConceptShareExternalReviewer)

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
        Public Function DeleteByEmailAndReviewID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ConceptShareReviewID As Integer, ByVal EmailAddress As String) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM CS_EXT_REVIEWER WHERE CS_REVIEW_ID = {0} AND EMAIL_ADDRESS = '{1}';", ConceptShareReviewID, EmailAddress))

                    Catch ex As Exception
                        Deleted = False
                        ErrorText = ex.Message.ToString
                    End Try

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByEmailAndReviewID = Deleted
            End Try

        End Function
        Public Function DeleteByConceptShareUserIDAndReviewID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ConceptShareReviewID As Integer, ByVal ConceptShareUserID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM CS_EXT_REVIEWER WHERE CS_REVIEW_ID = {0} AND CS_USERID = {1};", ConceptShareReviewID, ConceptShareUserID))

                    Catch ex As Exception
                        Deleted = False
                        ErrorText = ex.Message.ToString
                    End Try

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByConceptShareUserIDAndReviewID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
