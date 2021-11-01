Namespace Database.Procedures.Setting

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

        Public Function LoadBySettingModuleIDAndSettingModuleTabIDAndSettingModuleGroupID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingModuleID As Long, ByVal SettingModuleTabID As Long, ByVal SettingModuleGroupID As Long) As IQueryable(Of AdvantageFramework.Database.Entities.Setting)

            LoadBySettingModuleIDAndSettingModuleTabIDAndSettingModuleGroupID = From Setting In DataContext.Settings
                                                                                Where Setting.SettingModuleID = SettingModuleID AndAlso
                                                                                      Setting.SettingModuleTabID = SettingModuleTabID AndAlso
                                                                                      Setting.SettingModuleGroupID = SettingModuleGroupID
                                                                                Select Setting
                                                                                Order By Setting.OrderNumber Ascending

        End Function
        Public Function LoadBySettingModuleID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingModuleID As Long) As IQueryable(Of AdvantageFramework.Database.Entities.Setting)

            LoadBySettingModuleID = From Setting In DataContext.Settings
                                    Where Setting.SettingModuleID = SettingModuleID
                                    Select Setting
                                    Order By Setting.OrderNumber Ascending

        End Function
        Public Function LoadBySettingModuleIDAndSettingModuleTabID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingModuleID As Long, ByVal SettingModuleTabID As Long) As IQueryable(Of AdvantageFramework.Database.Entities.Setting)

            LoadBySettingModuleIDAndSettingModuleTabID = From Setting In DataContext.Settings
                                                         Where Setting.SettingModuleID = SettingModuleID AndAlso
                                                                Setting.SettingModuleTabID = SettingModuleTabID AndAlso
                                                                (Setting.IsInactive Is Nothing OrElse Setting.IsInactive = 0)
                                                         Select Setting
                                                         Order By Setting.OrderNumber Ascending

        End Function
        Public Function LoadBySettingCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingCode As String) As AdvantageFramework.Database.Entities.Setting

            Try

                LoadBySettingCode = (From Setting In DataContext.Settings
                                     Where Setting.Code = SettingCode
                                     Select Setting).SingleOrDefault

            Catch ex As Exception
                LoadBySettingCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.Setting)

            Load = From Setting In DataContext.Settings
                   Select Setting

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Setting As AdvantageFramework.Database.Entities.Setting) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Setting.DataContext = DataContext

                Setting.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.Settings.InsertOnSubmit(Setting)

                ErrorText = Setting.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Setting As AdvantageFramework.Database.Entities.Setting) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Setting.DataContext = DataContext

                Setting.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = Setting.ValidateEntity(IsValid)

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
