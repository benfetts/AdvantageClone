Namespace National.Database.Procedures.ProgramType

    <HideModuleName()>
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

        Public Function Load(DbContext As National.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of National.Database.Entities.ProgramType)

            Load = From ProgramType In DbContext.GetQuery(Of National.Database.Entities.ProgramType)
                   Select ProgramType

        End Function

#End Region

    End Module

End Namespace
