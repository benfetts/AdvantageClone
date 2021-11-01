Namespace Database.Procedures.State

    <HideModuleName()>
    Public Module State

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "
        Public Function LoadStates(ByVal DbContext As Database.DbContext) As IQueryable(Of AdvantageFramework.Database.Entities.State)

            LoadStates = From State In DbContext.States
                         Select State

        End Function

#End Region

    End Module

End Namespace
