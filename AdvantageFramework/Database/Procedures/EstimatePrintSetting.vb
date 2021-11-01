Namespace Database.Procedures.EstimatePrintSetting

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

        Public Function LoadByEstimatePrintSettingUserID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal UserID As String) As AdvantageFramework.Database.Entities.EstimatePrintSetting

            Try

                LoadByEstimatePrintSettingUserID = (From EstimatePrintSetting In DataContext.EstimatePrintSetting _
                                    Where EstimatePrintSetting.UserID = UserID _
                                    Select EstimatePrintSetting).SingleOrDefault

            Catch ex As Exception
                LoadByEstimatePrintSettingUserID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.EstimatePrintSetting)

            Load = From EstimatePrintSetting In DataContext.Settings
                   Select EstimatePrintSetting

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Setting As AdvantageFramework.Database.Entities.EstimatePrintSetting) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Setting.DataContext = DataContext

                Setting.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.EstimatePrintSetting.InsertOnSubmit(Setting)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Setting As AdvantageFramework.Database.Entities.EstimatePrintSetting) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Setting.DataContext = DataContext

                Setting.DatabaseAction = AdvantageFramework.Database.Action.Updating

                'ErrorText = EstimatePrintSetting.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingValue As AdvantageFramework.Database.Entities.EstimatePrintSetting) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.EstimatePrintSetting.DeleteOnSubmit(SettingValue)

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
