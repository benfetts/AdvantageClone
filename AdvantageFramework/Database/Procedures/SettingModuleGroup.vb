Namespace Database.Procedures.SettingModuleGroup

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

        Public Function LoadBySettingModuleIDAndSettingModuleTabID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingModuleID As Long, ByVal SettingModuleTabID As Long) As IQueryable(Of AdvantageFramework.Database.Entities.SettingModuleGroup)

            LoadBySettingModuleIDAndSettingModuleTabID = From SettingModuleGroup In DataContext.SettingModuleGroups
                                                         Where SettingModuleGroup.SettingModuleID = SettingModuleID AndAlso
                                                                SettingModuleGroup.SettingModuleTabID = SettingModuleTabID
                                                         Select SettingModuleGroup
                                                         Order By SettingModuleGroup.ID Ascending

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.SettingModuleGroup)

            Load = From SettingModuleGroup In DataContext.SettingModuleGroups
                   Select SettingModuleGroup

        End Function

#End Region

    End Module

End Namespace
