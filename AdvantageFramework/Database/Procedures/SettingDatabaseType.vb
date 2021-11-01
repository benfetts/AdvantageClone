Namespace Database.Procedures.SettingDatabaseType

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

        Public Function LoadBySettingDatabaseTypeID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingDatabaseTypeID As Long) As AdvantageFramework.Database.Entities.SettingDatabaseType

            Try

                LoadBySettingDatabaseTypeID = (From SettingDatabaseType In DataContext.SettingDatabaseTypes _
                                               Where SettingDatabaseType.ID = SettingDatabaseTypeID _
                                               Select SettingDatabaseType).SingleOrDefault

            Catch ex As Exception
                LoadBySettingDatabaseTypeID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.SettingDatabaseType)

            Load = From SettingDatabaseType In DataContext.SettingDatabaseTypes
                   Select SettingDatabaseType

        End Function

#End Region

    End Module

End Namespace
