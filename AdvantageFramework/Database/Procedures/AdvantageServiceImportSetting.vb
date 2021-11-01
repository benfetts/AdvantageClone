Namespace Database.Procedures.AdvantageServiceImportSetting

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

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of Database.Entities.AdvantageServiceImportSetting)

            Load = From AdvantageServiceImportSetting In DataContext.AdvantageServiceImportSettings
                   Select AdvantageServiceImportSetting

        End Function
        Public Function LoadByAdvantageServiceImportIDAndCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceImportID As Long, ByVal Code As String) As Database.Entities.AdvantageServiceImportSetting

            Try

                LoadByAdvantageServiceImportIDAndCode = (From AdvantageServiceImportSetting In DataContext.AdvantageServiceImportSettings _
                                                         Where AdvantageServiceImportSetting.AdvantageServiceImportID = AdvantageServiceImportID AndAlso _
                                                               AdvantageServiceImportSetting.Code = Code _
                                                         Select AdvantageServiceImportSetting).SingleOrDefault

            Catch ex As Exception
                LoadByAdvantageServiceImportIDAndCode = Nothing
            End Try
            
        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceImportSetting As AdvantageFramework.Database.Entities.AdvantageServiceImportSetting) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                AdvantageServiceImportSetting.DataContext = DataContext

                AdvantageServiceImportSetting.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.AdvantageServiceImportSettings.InsertOnSubmit(AdvantageServiceImportSetting)

                ErrorText = AdvantageServiceImportSetting.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceImportSetting As AdvantageFramework.Database.Entities.AdvantageServiceImportSetting) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                AdvantageServiceImportSetting.DataContext = DataContext

                AdvantageServiceImportSetting.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = AdvantageServiceImportSetting.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace
