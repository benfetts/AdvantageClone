Namespace Database.Procedures.ImportAvalaraTaxStaging

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

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging)

            Load = From ImportAvalaraTaxStaging In DataContext.ImportAvalaraTaxStagings
                   Select ImportAvalaraTaxStaging

        End Function
        Public Function LoadByBatchName(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal BatchName As String) As IQueryable(Of AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging)

            LoadByBatchName = From ImportAvalaraTaxStaging In DataContext.ImportAvalaraTaxStagings
                              Where ImportAvalaraTaxStaging.BatchName = BatchName
                              Select ImportAvalaraTaxStaging

        End Function
        Public Function LoadByImportID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ImportID As Integer) As AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging

            Try

                LoadByImportID = (From ImportAvalaraTaxStaging In DataContext.ImportAvalaraTaxStagings _
                                  Where ImportAvalaraTaxStaging.ImportID = ImportID _
                                  Select ImportAvalaraTaxStaging).SingleOrDefault

            Catch ex As Exception
                LoadByImportID = Nothing
            End Try
            
        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ImportAvalaraTaxStaging As AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ImportAvalaraTaxStaging.DataContext = DataContext

                ImportAvalaraTaxStaging.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.ImportAvalaraTaxStagings.InsertOnSubmit(ImportAvalaraTaxStaging)

                ErrorText = ImportAvalaraTaxStaging.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ImportAvalaraTaxStaging As AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ImportAvalaraTaxStaging.DataContext = DataContext

                ImportAvalaraTaxStaging.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = ImportAvalaraTaxStaging.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ImportAvalaraTaxStaging As AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.ImportAvalaraTaxStagings.DeleteOnSubmit(ImportAvalaraTaxStaging)

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