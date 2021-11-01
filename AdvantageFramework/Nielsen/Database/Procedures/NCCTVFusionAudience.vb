Namespace Nielsen.Database.Procedures.NCCTVFusionAudience

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

            If (From NCCTVFusionAudience In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVFusionAudience)
                Where NCCTVFusionAudience.NCCTVFusionUniverseID = NCCTVFusionUniverseID
                Select NCCTVFusionAudience.ID).Any Then


                GetMaxIDByNCCTVFusionUniverseID = (From NCCTVFusionAudience In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVFusionAudience)
                                                   Where NCCTVFusionAudience.NCCTVFusionUniverseID = NCCTVFusionUniverseID
                                                   Select NCCTVFusionAudience.ID).Max

            Else

                GetMaxIDByNCCTVFusionUniverseID = 0

            End If

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NCCTVFusionAudience)

            Load = From NCCTVFusionAudience In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVFusionAudience)
                   Select NCCTVFusionAudience

        End Function

#End Region

    End Module

End Namespace
