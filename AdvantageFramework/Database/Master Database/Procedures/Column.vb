Namespace Database.MasterDatabase.Procedures.Column

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Methods "

        Public Function LoadByObjectID(ByVal DataContext As AdvantageFramework.Database.MasterDatabase.DataContext, ByVal ObjectID As Long) As IQueryable(Of AdvantageFramework.Database.MasterDatabase.Entities.Column)

            LoadByObjectID = From Column In DataContext.Columns _
                             Where Column.ObjectID = ObjectID _
                             Select Column

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.MasterDatabase.DataContext) As IQueryable(Of AdvantageFramework.Database.MasterDatabase.Entities.Column)

            Load = From Column In DataContext.Columns _
                   Select Column

        End Function

#End Region

    End Module

End Namespace
