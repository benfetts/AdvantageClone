Namespace Database.Procedures.ImportClientContactStaging

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

        Public Function LoadByImportClientContactStagingID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportClientContactStagingID As Integer) As Database.Entities.ImportClientContactStaging

            Try

                LoadByImportClientContactStagingID = (From ImportClientContactStaging In DbContext.GetQuery(Of Database.Entities.ImportClientContactStaging)
                                                      Where ImportClientContactStaging.ID = ImportClientContactStagingID
                                                      Select ImportClientContactStaging).SingleOrDefault

            Catch ex As Exception
                LoadByImportClientContactStagingID = Nothing
            End Try

        End Function
        Public Function LoadByBatchName(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BatchName As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ImportClientContactStaging)

            LoadByBatchName = From ImportClientContactStaging In DbContext.GetQuery(Of Database.Entities.ImportClientContactStaging)
                              Where ImportClientContactStaging.BatchName = BatchName
                              Select ImportClientContactStaging

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ImportClientContactStaging)

            Load = DbContext.GetQuery(Of Database.Entities.ImportClientContactStaging)

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportClientContactStaging As AdvantageFramework.Database.Entities.ImportClientContactStaging, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.ImportClientContactStagings.Add(ImportClientContactStaging)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportClientContactStaging As AdvantageFramework.Database.Entities.ImportClientContactStaging, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Entry(ImportClientContactStaging).State = Entity.EntityState.Modified

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                End If

            Catch ex As Exception

                Updated = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportClientContactStaging As AdvantageFramework.Database.Entities.ImportClientContactStaging, ByRef ErrorMessage As String) As Boolean

            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                If IsValid Then

                    DbContext.Entry(ImportClientContactStaging).State = Entity.EntityState.Deleted

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
