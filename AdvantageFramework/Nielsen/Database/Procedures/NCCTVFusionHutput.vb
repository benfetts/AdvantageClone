Namespace Nielsen.Database.Procedures.NCCTVFusionHutput

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

        Public Function GetMaxIDByNCCTVFusionUniverseID(DbContext As Nielsen.Database.DbContext, NCCTVFusionUniverseID As Int64) As Long

            If (From NCCTVFusionHutput In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVFusionHutput)
                Where NCCTVFusionHutput.NCCTVFusionUniverseID = NCCTVFusionUniverseID
                Select NCCTVFusionHutput.ID).Any Then

                GetMaxIDByNCCTVFusionUniverseID = (From NCCTVFusionHutput In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVFusionHutput)
                                                   Where NCCTVFusionHutput.NCCTVFusionUniverseID = NCCTVFusionUniverseID
                                                   Select NCCTVFusionHutput.ID).Max

            Else

                GetMaxIDByNCCTVFusionUniverseID = 0

            End If

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NCCTVFusionHutput)

            Load = From NCCTVFusionHutput In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVFusionHutput)
                   Select NCCTVFusionHutput

        End Function

#End Region

    End Module

End Namespace
