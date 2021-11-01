Namespace Database.Procedures.SettingModuleTab

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

        Public Function LoadBySettingModuleID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingModuleID As Long) As IQueryable(Of AdvantageFramework.Database.Entities.SettingModuleTab)

            LoadBySettingModuleID = From SettingModuleTab In DataContext.SettingModuleTabs
                                    Where SettingModuleTab.SettingModuleID = SettingModuleID
                                    Select SettingModuleTab

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.SettingModuleTab)

            Load = From SettingModuleTab In DataContext.SettingModuleTabs
                   Select SettingModuleTab

        End Function

#End Region

    End Module

End Namespace
