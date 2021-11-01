Namespace Database.Procedures.ProofingDocument

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

        Public Function LoadByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ProofingDocument)

            LoadByAlertID = From ProofingDocument In DbContext.GetQuery(Of Database.Entities.ProofingDocument)
                            Select ProofingDocument

        End Function
        Public Function LoadByDocumentID(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ProofingDocument)

            LoadByDocumentID = From ProofingDocument In DbContext.GetQuery(Of Database.Entities.ProofingDocument)
                               Select ProofingDocument

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ProofingDocument)

            Load = From ProofingDocument In DbContext.GetQuery(Of Database.Entities.ProofingDocument)
                   Select ProofingDocument

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal ProofingDocument As AdvantageFramework.Database.Entities.ProofingDocument) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ProofingDocuments.Add(ProofingDocument)

                'ErrorText = ProofingDocument.ValidateEntity(IsValid)

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
                               ByVal ProofingDocument As AdvantageFramework.Database.Entities.ProofingDocument) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ProofingDocument)

                ErrorText = ProofingDocument.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal ProofingDocument As AdvantageFramework.Database.Entities.ProofingDocument) As Boolean

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

                        DbContext.DeleteEntityObject(ProofingDocument)
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
