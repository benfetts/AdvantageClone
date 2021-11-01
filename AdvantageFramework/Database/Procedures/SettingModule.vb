Namespace Database.Procedures.SettingModule

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

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.SettingModule)

            Load = From SettingModule In DataContext.SettingModules
                   Select SettingModule

        End Function

#End Region

    End Module

End Namespace
