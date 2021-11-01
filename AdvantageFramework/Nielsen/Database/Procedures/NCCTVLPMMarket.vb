Namespace Nielsen.Database.Procedures.NCCTVLPMMarket

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

        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NCCTVLPMMarket)

            Load = From NCCTVLPMMarket In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVLPMMarket)
                   Select NCCTVLPMMarket

        End Function

#End Region

    End Module

End Namespace
