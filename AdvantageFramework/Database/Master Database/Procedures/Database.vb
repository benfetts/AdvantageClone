Namespace Database.MasterDatabase.Procedures.Database

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Methods "

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.MasterDatabase.DataContext) As IQueryable(Of AdvantageFramework.Database.MasterDatabase.Entities.Database)

            Load = From Database In DataContext.Databases _
                   Select Database

        End Function

#End Region

    End Module

End Namespace
