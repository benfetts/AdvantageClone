Namespace Database.Procedures.MediaSpotTVResearchStation

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

        Public Function LoadByMediaSpotTVResearchID(DbContext As Database.DbContext, MediaSpotTVResearchID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotTVResearchStation)

            LoadByMediaSpotTVResearchID = From MediaSpotTVResearchStation In DbContext.GetQuery(Of Database.Entities.MediaSpotTVResearchStation)
                                          Where MediaSpotTVResearchStation.MediaSpotTVResearchID = MediaSpotTVResearchID
                                          Select MediaSpotTVResearchStation

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotTVResearchStation)

            Load = From MediaSpotTVResearchStation In DbContext.GetQuery(Of Database.Entities.MediaSpotTVResearchStation)
                   Select MediaSpotTVResearchStation

        End Function

#End Region

    End Module

End Namespace
