Namespace Database.Procedures.MediaSpotRadioCountyResearchMetric

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

        Public Function LoadByMediaSpotRadioCountyResearchID(DbContext As Database.DbContext, MediaSpotRadioCountyResearchID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotRadioCountyResearchMetric)

            LoadByMediaSpotRadioCountyResearchID = From MediaSpotRadioCountyResearchMetric In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioCountyResearchMetric).Include("MediaMetric")
                                                   Where MediaSpotRadioCountyResearchMetric.MediaSpotRadioCountyResearchID = MediaSpotRadioCountyResearchID
                                                   Select MediaSpotRadioCountyResearchMetric

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotRadioCountyResearchMetric)

            Load = From MediaSpotRadioCountyResearchMetric In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioCountyResearchMetric)
                   Select MediaSpotRadioCountyResearchMetric

        End Function

#End Region

    End Module

End Namespace
