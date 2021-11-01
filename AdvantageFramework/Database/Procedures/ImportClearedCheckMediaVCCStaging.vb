Namespace Database.Procedures.ImportClearedCheckMediaVCCStaging

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

        Public Function LoadByImportClearedCheckMediaVCCStagingID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportClearedCheckMediaVCCStagingID As Integer) As Database.Entities.ImportClearedCheckMediaVCCStaging

            Try

                LoadByImportClearedCheckMediaVCCStagingID = (From ImportClearedCheckMediaVCCStaging In DbContext.GetQuery(Of Database.Entities.ImportClearedCheckMediaVCCStaging)
                                                             Where ImportClearedCheckMediaVCCStaging.ID = ImportClearedCheckMediaVCCStagingID
                                                             Select ImportClearedCheckMediaVCCStaging).SingleOrDefault

            Catch ex As Exception
                LoadByImportClearedCheckMediaVCCStagingID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ImportClearedCheckMediaVCCStaging)

            Load = DbContext.GetQuery(Of Database.Entities.ImportClearedCheckMediaVCCStaging)

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportClearedCheckMediaVCCStaging As AdvantageFramework.Database.Entities.ImportClearedCheckMediaVCCStaging, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.ImportClearedCheckMediaVCCStagings.Add(ImportClearedCheckMediaVCCStaging)

                ErrorMessage = ImportClearedCheckMediaVCCStaging.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception

                Inserted = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportClearedCheckMediaVCCStaging As AdvantageFramework.Database.Entities.ImportClearedCheckMediaVCCStaging, ByRef ErrorMessage As String) As Boolean

            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                If IsValid Then

                    DbContext.Entry(ImportClearedCheckMediaVCCStaging).State = Entity.EntityState.Deleted

                    DbContext.SaveChanges()

                    Deleted = True

                End If

            Catch ex As Exception

                Deleted = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
