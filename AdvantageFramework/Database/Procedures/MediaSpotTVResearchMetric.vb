Namespace Database.Procedures.MediaSpotTVResearchMetric

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

        Public Function LoadByMediaSpotTVResearchID(DbContext As Database.DbContext, MediaSpotTVResearchID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotTVResearchMetric)

            LoadByMediaSpotTVResearchID = From MediaSpotTVResearchMetric In DbContext.GetQuery(Of Database.Entities.MediaSpotTVResearchMetric).Include("MediaMetric")
                                          Where MediaSpotTVResearchMetric.MediaSpotTVResearchID = MediaSpotTVResearchID
                                          Select MediaSpotTVResearchMetric

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotTVResearchMetric)

            Load = From MediaSpotTVResearchMetric In DbContext.GetQuery(Of Database.Entities.MediaSpotTVResearchMetric)
                   Select MediaSpotTVResearchMetric

        End Function

#End Region

    End Module

End Namespace
