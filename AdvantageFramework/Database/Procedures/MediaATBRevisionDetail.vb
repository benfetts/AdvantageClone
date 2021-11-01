Namespace Database.Procedures.MediaATBRevisionDetail

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaATBRevisionDetail)

            Load = From MediaATBRevisionDetail In DbContext.GetQuery(Of Database.Entities.MediaATBRevisionDetail)
                   Select MediaATBRevisionDetail

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Database.Entities.MediaATBRevisionDetail

            Try

                LoadByID = (From MediaATBRevisionDetail In DbContext.GetQuery(Of Database.Entities.MediaATBRevisionDetail)
                            Where MediaATBRevisionDetail.DetailID = ID
                            Select MediaATBRevisionDetail).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function LoadByRevisionID(ByVal DbContext As Database.DbContext, ByVal RevisionID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaATBRevisionDetail)

            LoadByRevisionID = From MediaATBRevisionDetail In DbContext.GetQuery(Of Database.Entities.MediaATBRevisionDetail)
                               Where MediaATBRevisionDetail.RevisionID = RevisionID
                               Select MediaATBRevisionDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaATBRevisionDetail As AdvantageFramework.Database.Entities.MediaATBRevisionDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim ErrorText As String = ""

            Try

                If DbContext.Database.Connection.State <> ConnectionState.Open Then

                    DbContext.Database.Connection.Open()

                End If

                DbTransaction = DbContext.Database.BeginTransaction()

                Try

                    MediaATBRevisionDetail.DetailID = (From Entity In Load(DbContext)
                                                       Select [ID] = Entity.DetailID).Max + 1

                Catch ex As Exception
                    MediaATBRevisionDetail.DetailID = 1
                End Try

                DbContext.MediaATBRevisionDetails.Add(MediaATBRevisionDetail)

                ErrorText = MediaATBRevisionDetail.ValidateEntity(IsValid)

                If IsValid Then

                    If MediaATBRevisionDetail.AdServingForDetailID.HasValue Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ATB_REV_DTL] SET [AD_SRV_ATB_REV_DTL_ID] = NULL WHERE [AD_SRV_ATB_REV_DTL_ID] = {0}", MediaATBRevisionDetail.AdServingForDetailID))

                    End If

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

                If Inserted Then

                    DbTransaction.Commit()

                Else

                    DbTransaction.Rollback()

                End If

                DbContext.Database.Connection.Close()

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaATBRevisionDetail As AdvantageFramework.Database.Entities.MediaATBRevisionDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim ErrorText As String = ""

            Try

                If DbContext.Database.Connection.State <> ConnectionState.Open Then

                    DbContext.Database.Connection.Open()

                End If

                DbTransaction = DbContext.Database.BeginTransaction()

                DbContext.UpdateObject(MediaATBRevisionDetail)

                ErrorText = MediaATBRevisionDetail.ValidateEntity(IsValid)

                If IsValid Then

                    If MediaATBRevisionDetail.AdServingForDetailID.HasValue Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ATB_REV_DTL] SET [AD_SRV_ATB_REV_DTL_ID] = NULL WHERE [AD_SRV_ATB_REV_DTL_ID] = {0}", MediaATBRevisionDetail.AdServingForDetailID))

                    End If

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

                If Updated Then

                    DbTransaction.Commit()

                Else

                    DbTransaction.Rollback()

                End If

                DbContext.Database.Connection.Close()

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaATBRevisionDetail As AdvantageFramework.Database.Entities.MediaATBRevisionDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Try

                If DbContext.Database.Connection.State <> ConnectionState.Open Then

                    DbContext.Database.Connection.Open()

                End If

                DbTransaction = DbContext.Database.BeginTransaction()

                If IsValid Then

                    If MediaATBRevisionDetail.AdServingForDetailID.HasValue Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ATB_REV_DTL] SET [AD_SRV_ATB_REV_DTL_ID] = NULL WHERE [AD_SRV_ATB_REV_DTL_ID] = {0}", MediaATBRevisionDetail.DetailID))

                    End If

                    DbContext.DeleteEntityObject(MediaATBRevisionDetail)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

                If Deleted Then

                    DbTransaction.Commit()

                Else

                    DbTransaction.Rollback()

                End If

                DbContext.Database.Connection.Close()

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
