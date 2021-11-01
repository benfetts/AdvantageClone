Namespace Nielsen.Database.Procedures.NCCTVFusionUniverse

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

        Public Function LoadByID(DbContext As Nielsen.Database.DbContext, ID As Int64) As Nielsen.Database.Entities.NCCTVFusionUniverse

            LoadByID = (From NCCTVFusionUniverse In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVFusionUniverse)
                        Where NCCTVFusionUniverse.ID = ID
                        Select NCCTVFusionUniverse).SingleOrDefault

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NCCTVFusionUniverse)

            Load = From NCCTVFusionUniverse In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVFusionUniverse)
                   Select NCCTVFusionUniverse

        End Function
        Public Function LoadValidatedByNielsenMarketNumberAndIDs(DbContext As Database.DbContext, NielsenMarketNumber As Integer, IDs As IEnumerable(Of Long)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NCCTVFusionUniverse)

            LoadValidatedByNielsenMarketNumberAndIDs = From NCCTVFusionUniverse In DbContext.GetQuery(Of Database.Entities.NCCTVFusionUniverse)
                                                       Where NCCTVFusionUniverse.NielsenMarketNumber = NielsenMarketNumber AndAlso
                                                             IDs.Contains(NCCTVFusionUniverse.ID) AndAlso
                                                             NCCTVFusionUniverse.Validated = True
                                                       Select NCCTVFusionUniverse

        End Function

#End Region

    End Module

End Namespace
