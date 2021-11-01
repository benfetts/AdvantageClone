Namespace Database.Procedures.DynamicReportSettings

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

        Public Function LoadByDynamicReportSettingsReportID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DynamicReportSettingsReportID As Long) As IQueryable(Of AdvantageFramework.Database.Entities.DynamicReportSettings)

            LoadByDynamicReportSettingsReportID = From DynamicReportSettings In DataContext.DynamicReportSettings
                                                  Where DynamicReportSettings.DynamicReportID = DynamicReportSettingsReportID
                                                  Select DynamicReportSettings

        End Function
        Public Function LoadByDynamicReportSettingReportIDAndSettingName(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DynamicReportSettingsReportID As Long, ByVal SettingName As String) As AdvantageFramework.Database.Entities.DynamicReportSettings

            Try

                LoadByDynamicReportSettingReportIDAndSettingName = (From DynamicReportSettings In DataContext.DynamicReportSettings
                                                                    Where DynamicReportSettings.DynamicReportID = DynamicReportSettingsReportID AndAlso
                                           DynamicReportSettings.DynamicReportSettingName = SettingName
                                                                    Select DynamicReportSettings).SingleOrDefault

            Catch ex As Exception
                LoadByDynamicReportSettingReportIDAndSettingName = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.DynamicReportSettings)

            Load = From DynamicReportSettings In DataContext.Settings
                   Select DynamicReportSettings

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Setting As AdvantageFramework.Database.Entities.DynamicReportSettings) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Setting.DataContext = DataContext

                Setting.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.DynamicReportSettings.InsertOnSubmit(Setting)

                'ErrorText = DynamicReportSettings.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Setting As AdvantageFramework.Database.Entities.DynamicReportSettings) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Setting.DataContext = DataContext

                Setting.DatabaseAction = AdvantageFramework.Database.Action.Updating

                'ErrorText = DynamicReportSettings.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingValue As AdvantageFramework.Database.Entities.DynamicReportSettings) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.DynamicReportSettings.DeleteOnSubmit(SettingValue)

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
