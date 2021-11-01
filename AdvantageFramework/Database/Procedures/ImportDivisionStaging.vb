Namespace Database.Procedures.ImportDivisionStaging

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

        Public Function LoadByBatchName(ByVal DbContext As Database.DbContext, ByVal BatchName As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportDivisionStaging)

            LoadByBatchName = From ImportDivisionStaging In DbContext.GetQuery(Of Database.Entities.ImportDivisionStaging)
                              Where ImportDivisionStaging.BatchName = BatchName
                              Select ImportDivisionStaging

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportDivisionStaging)

            Load = From ImportDivisionStaging In DbContext.GetQuery(Of Database.Entities.ImportDivisionStaging)
                   Select ImportDivisionStaging

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportDivisionStaging As AdvantageFramework.Database.Entities.ImportDivisionStaging) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ImportDivisionStagings.Add(ImportDivisionStaging)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportDivisionStaging As AdvantageFramework.Database.Entities.ImportDivisionStaging) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ImportDivisionStaging)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportDivisionStaging As AdvantageFramework.Database.Entities.ImportDivisionStaging) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ImportDivisionStaging)

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
