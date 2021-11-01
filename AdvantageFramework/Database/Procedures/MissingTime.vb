Namespace Database.Procedures.MissingTime

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Methods "

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.MissingTime)

            Load = From MissingTime In DataContext.MissingTimes
                   Select MissingTime

        End Function

#End Region

    End Module

End Namespace
