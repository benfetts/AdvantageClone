Namespace Database.Procedures.ProofingExternalReviewer

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

        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                 ByVal ID As Integer) As AdvantageFramework.Database.Entities.ProofingExternalReviewer

            LoadByID = (From ProofingExternalReviewer In DbContext.GetQuery(Of Database.Entities.ProofingExternalReviewer)
                        Where ProofingExternalReviewer.ID = ID
                        Select ProofingExternalReviewer).SingleOrDefault

        End Function
        Public Function LoadByName(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                   ByVal Name As String) As AdvantageFramework.Database.Entities.ProofingExternalReviewer


            LoadByName = (From ProofingExternalReviewer In DbContext.GetQuery(Of Database.Entities.ProofingExternalReviewer)
                          Where ProofingExternalReviewer.Name = Name
                          Select ProofingExternalReviewer).SingleOrDefault

        End Function
        Public Function LoadByEmailAddress(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                           ByVal EmailAddress As String) As AdvantageFramework.Database.Entities.ProofingExternalReviewer

            LoadByEmailAddress = (From ProofingExternalReviewer In DbContext.GetQuery(Of Database.Entities.ProofingExternalReviewer)
                                  Where ProofingExternalReviewer.Email.ToLower = EmailAddress.ToLower
                                  Select ProofingExternalReviewer).SingleOrDefault

        End Function
        Public Function LoadActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ProofingExternalReviewer)

            LoadActive = From ProofingExternalReviewer In DbContext.GetQuery(Of Database.Entities.ProofingExternalReviewer)
                         Where ProofingExternalReviewer.IsActive Is Nothing OrElse ProofingExternalReviewer.IsActive = True
                         Select ProofingExternalReviewer

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ProofingExternalReviewer)

            Load = From ProofingExternalReviewer In DbContext.GetQuery(Of Database.Entities.ProofingExternalReviewer)
                   Select ProofingExternalReviewer

        End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal ProofingExternalReviewer As AdvantageFramework.Database.Entities.ProofingExternalReviewer,
                               Optional ByRef ErrorText As String = "") As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.ProofingExternalReviewers.Add(ProofingExternalReviewer)
                ProofingExternalReviewer.DbContext = DbContext

                ErrorText = ProofingExternalReviewer.ValidateInsert(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal ProofingExternalReviewer As AdvantageFramework.Database.Entities.ProofingExternalReviewer,
                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            ErrorMessage = String.Empty

            Try

                If ProofingExternalReviewer.DbContext Is Nothing AndAlso DbContext IsNot Nothing Then

                    ProofingExternalReviewer.DbContext = DbContext

                End If

                DbContext.UpdateObject(ProofingExternalReviewer)
                ErrorMessage = ProofingExternalReviewer.ValidateUpdate(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()
                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal ProofingExternal As AdvantageFramework.Database.Entities.ProofingExternalReviewer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Try

                If IsValid Then

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    Try

                        DbContext.DeleteEntityObject(ProofingExternal)
                        DbContext.SaveChanges()

                        Deleted = True

                    Catch ex As Exception
                        Deleted = False
                    End Try
                    Try

                        If Deleted Then

                            DbTransaction.Commit()

                        Else

                            DbTransaction.Rollback()

                        End If

                    Catch ex As Exception
                        Deleted = False
                    End Try

                    DbContext.Database.Connection.Close()

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
