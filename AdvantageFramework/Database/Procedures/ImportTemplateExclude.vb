Namespace Database.Procedures.ImportTemplateExclude

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

        Public Function Load(DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.ImportTemplateExclude)

            Load = From ImportTemplateExclude In DataContext.ImportTemplateExcludes
                   Select ImportTemplateExclude

        End Function
        Public Function LoadByImportTemplateID(DataContext As AdvantageFramework.Database.DataContext, ImportTemplateID As Integer) As IQueryable(Of AdvantageFramework.Database.Entities.ImportTemplateExclude)

            LoadByImportTemplateID = From ImportTemplateExclude In DataContext.ImportTemplateExcludes
                                     Where ImportTemplateExclude.ImportTemplateID = ImportTemplateID
                                     Select ImportTemplateExclude

        End Function
        Public Function LoadByImportTemplateIDAndFieldName(DataContext As AdvantageFramework.Database.DataContext, ImportTemplateID As Integer, FieldName As String) As IQueryable(Of AdvantageFramework.Database.Entities.ImportTemplateExclude)

            LoadByImportTemplateIDAndFieldName = From ImportTemplateExclude In DataContext.ImportTemplateExcludes
                                                 Where ImportTemplateExclude.ImportTemplateID = ImportTemplateID AndAlso
                                                       ImportTemplateExclude.FieldName = FieldName
                                                 Select ImportTemplateExclude

        End Function
        Public Function Insert(DataContext As AdvantageFramework.Database.DataContext, ImportTemplateExclude As AdvantageFramework.Database.Entities.ImportTemplateExclude) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ImportTemplateExclude.DataContext = DataContext

                ImportTemplateExclude.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.ImportTemplateExcludes.InsertOnSubmit(ImportTemplateExclude)

                ErrorText = ImportTemplateExclude.ValidateEntity(IsValid)

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
        Public Function Delete(DataContext As AdvantageFramework.Database.DataContext, ImportTemplateExclude As AdvantageFramework.Database.Entities.ImportTemplateExclude) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.ImportTemplateExcludes.DeleteOnSubmit(ImportTemplateExclude)

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