Namespace Database.Procedures.ProofingMarkup
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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ProofingMarkup)

            Load = From ProofingMarkup In DbContext.GetQuery(Of Database.Entities.ProofingMarkup)
                   Select ProofingMarkup

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal ProofingMarkup As AdvantageFramework.Database.Entities.ProofingMarkup) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ProofingMarkups.Add(ProofingMarkup)

                'ErrorText = ProofingMarkup.ValidateEntity(IsValid)

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
                               ByVal ProofingMarkup As AdvantageFramework.Database.Entities.ProofingMarkup) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ProofingMarkup)

                ErrorText = ProofingMarkup.ValidateEntity(IsValid)

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
                               ByVal ProofingMarkup As AdvantageFramework.Database.Entities.ProofingMarkup) As Boolean

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

                        DbContext.DeleteEntityObject(ProofingMarkup)
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

