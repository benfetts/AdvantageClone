Namespace Database.Procedures.ImportEmployeeStaging

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportEmployeeStaging)

            Load = From ImportEmployeeStaging In DbContext.GetQuery(Of Database.Entities.ImportEmployeeStaging)
                   Select ImportEmployeeStaging

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportEmployeeStaging As AdvantageFramework.Database.Entities.ImportEmployeeStaging) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ImportEmployeeStagings.Add(ImportEmployeeStaging)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportEmployeeStaging As AdvantageFramework.Database.Entities.ImportEmployeeStaging) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try
                
                DbContext.UpdateObject(ImportEmployeeStaging)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportEmployeeStaging As AdvantageFramework.Database.Entities.ImportEmployeeStaging) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ImportEmployeeStaging)

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
        Public Function DeleteByImportEmployeeStagingIDs(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportEmployeeStagingIDs() As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.IMP_EMP_STAGING WHERE IMPORT_ID IN (" & Join(ImportEmployeeStagingIDs.Select(Function(ID) CStr(ID)).ToArray, ", ") & ")")

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByImportEmployeeStagingIDs = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
