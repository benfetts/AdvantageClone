Namespace Nielsen.Database.Procedures.NielsenNationalTVAudience

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

        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenNationalTVAudience)

            Load = From NielsenNationalTVAudience In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenNationalTVAudience)
                   Select NielsenNationalTVAudience

        End Function

#End Region

    End Module

End Namespace
