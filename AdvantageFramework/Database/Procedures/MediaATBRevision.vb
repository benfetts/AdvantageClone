Namespace Database.Procedures.MediaATBRevision

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaATBRevision)

            Load = From MediaATBRevision In DbContext.GetQuery(Of Database.Entities.MediaATBRevision)
                   Select MediaATBRevision

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Database.Entities.MediaATBRevision

            Try

                LoadByID = (From MediaATBRevision In DbContext.GetQuery(Of Database.Entities.MediaATBRevision)
                            Where MediaATBRevision.RevisionID = ID
                            Select MediaATBRevision).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function LoadByATBNumber(ByVal DbContext As Database.DbContext, ByVal ATBNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaATBRevision)

            LoadByATBNumber = From MediaATBRevision In DbContext.GetQuery(Of Database.Entities.MediaATBRevision)
                              Where MediaATBRevision.ATBNumber = ATBNumber
                              Select MediaATBRevision

        End Function
        Public Function LoadByATBNumberAndRevisionNumber(ByVal DbContext As Database.DbContext, ByVal ATBNumber As Integer, ByVal RevisionNumber As Integer) As Database.Entities.MediaATBRevision

            Try

                LoadByATBNumberAndRevisionNumber = (From MediaATBRevision In DbContext.GetQuery(Of Database.Entities.MediaATBRevision)
                                                    Where MediaATBRevision.ATBNumber = ATBNumber And
                                                          MediaATBRevision.RevisionNumber = RevisionNumber
                                                    Select MediaATBRevision).SingleOrDefault

            Catch ex As Exception
                LoadByATBNumberAndRevisionNumber = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaATBRevisions.Add(MediaATBRevision)

                ErrorText = MediaATBRevision.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaATBRevision)

                ErrorText = MediaATBRevision.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision) As Boolean

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

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM [dbo].[ATB_REV_DTL] WHERE [ATB_REV_ID] = {0}", MediaATBRevision.RevisionID))

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM [dbo].[ATB_REV] WHERE [ATB_REV_ID] = {0}", MediaATBRevision.RevisionID))

                        Deleted = True

                    Catch ex As Exception
                        Deleted = False
                    End Try

                    If Deleted Then

                        DbTransaction.Commit()

                    Else

                        DbTransaction.Rollback()

                    End If

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
