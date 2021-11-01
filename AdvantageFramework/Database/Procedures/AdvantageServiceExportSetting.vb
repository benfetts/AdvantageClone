Namespace Database.Procedures.AdvantageServiceExportSetting

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

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of Database.Entities.AdvantageServiceExportSetting)

            Load = From AdvantageServiceExportSetting In DataContext.AdvantageServiceExportSettings
                   Select AdvantageServiceExportSetting

        End Function
        Public Function LoadByAdvantageServiceExportIDAndCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceExportID As Long, ByVal Code As String) As Database.Entities.AdvantageServiceExportSetting

            Try

                LoadByAdvantageServiceExportIDAndCode = (From AdvantageServiceImportSetting In DataContext.AdvantageServiceExportSettings _
                                                         Where AdvantageServiceImportSetting.AdvantageServiceExportID = AdvantageServiceExportID AndAlso _
                                                               AdvantageServiceImportSetting.Code = Code _
                                                         Select AdvantageServiceImportSetting).SingleOrDefault

            Catch ex As Exception
                LoadByAdvantageServiceExportIDAndCode = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceExportSetting As AdvantageFramework.Database.Entities.AdvantageServiceExportSetting) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                AdvantageServiceExportSetting.DataContext = DataContext

                AdvantageServiceExportSetting.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.AdvantageServiceExportSettings.InsertOnSubmit(AdvantageServiceExportSetting)

                ErrorText = AdvantageServiceExportSetting.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceExportSetting As AdvantageFramework.Database.Entities.AdvantageServiceExportSetting) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                AdvantageServiceExportSetting.DataContext = DataContext

                AdvantageServiceExportSetting.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = AdvantageServiceExportSetting.ValidateEntity(IsValid)

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
