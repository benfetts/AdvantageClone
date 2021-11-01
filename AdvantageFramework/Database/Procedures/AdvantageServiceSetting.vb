Namespace Database.Procedures.AdvantageServiceSetting

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

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of Database.Entities.AdvantageServiceSetting)

            Load = From AdvantageServiceSetting In DataContext.AdvantageServiceSettings
                   Select AdvantageServiceSetting

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                AdvantageServiceSetting.DataContext = DataContext

                AdvantageServiceSetting.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.AdvantageServiceSettings.InsertOnSubmit(AdvantageServiceSetting)

                ErrorText = AdvantageServiceSetting.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                AdvantageServiceSetting.DataContext = DataContext

                AdvantageServiceSetting.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = AdvantageServiceSetting.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.AdvantageServiceSettings.DeleteOnSubmit(AdvantageServiceSetting)

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
