Namespace Database.MasterTable.Procedures.Table

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Methods "

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.MasterDatabase.DataContext) As IQueryable(Of AdvantageFramework.Database.MasterDatabase.Entities.Table)

            Load = From Table In DataContext.Tables _
                   Select Table

        End Function

#End Region

    End Module

End Namespace
