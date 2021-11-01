Namespace Database.Procedures.ImportPTOStaging

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

        Public Function Load(DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.ImportPTOStaging)

            Load = From ImportPTOStaging In DataContext.ImportPTOStagings
                   Select ImportPTOStaging

        End Function
        Public Function LoadByBatchName(DataContext As AdvantageFramework.Database.DataContext, BatchName As String) As IQueryable(Of AdvantageFramework.Database.Entities.ImportPTOStaging)

            LoadByBatchName = From ImportPTOStaging In DataContext.ImportPTOStagings
                              Where ImportPTOStaging.BatchName = BatchName
                              Select ImportPTOStaging

        End Function
        Public Function LoadByImportID(DataContext As AdvantageFramework.Database.DataContext, ImportID As Integer) As AdvantageFramework.Database.Entities.ImportPTOStaging

            Try

                LoadByImportID = (From ImportPTOStaging In DataContext.ImportPTOStagings
                                  Where ImportPTOStaging.ImportID = ImportID
                                  Select ImportPTOStaging).SingleOrDefault

            Catch ex As Exception
                LoadByImportID = Nothing
            End Try

        End Function
        Public Function Insert(DataContext As AdvantageFramework.Database.DataContext, ImportPTOStaging As AdvantageFramework.Database.Entities.ImportPTOStaging,
                               BypassValidation As Boolean) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ImportPTOStaging.DataContext = DataContext

                ImportPTOStaging.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.ImportPTOStagings.InsertOnSubmit(ImportPTOStaging)

                If Not BypassValidation Then

                    ErrorText = ImportPTOStaging.ValidateEntity(IsValid)

                End If

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Update(DataContext As AdvantageFramework.Database.DataContext, ImportPTOStaging As AdvantageFramework.Database.Entities.ImportPTOStaging,
                               BypassValidation As Boolean) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ImportPTOStaging.DataContext = DataContext

                ImportPTOStaging.DatabaseAction = AdvantageFramework.Database.Action.Updating

                If Not BypassValidation Then

                    ErrorText = ImportPTOStaging.ValidateEntity(IsValid)

                End If

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Delete(DataContext As AdvantageFramework.Database.DataContext, ImportPTOStaging As AdvantageFramework.Database.Entities.ImportPTOStaging) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.ImportPTOStagings.DeleteOnSubmit(ImportPTOStaging)

                    DataContext.SubmitChanges()

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