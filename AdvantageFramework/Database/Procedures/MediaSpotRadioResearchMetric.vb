Namespace Database.Procedures.MediaSpotRadioResearchMetric

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

        Public Function LoadByMediaSpotRadioResearchID(DbContext As Database.DbContext, MediaSpotRadioResearchID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotRadioResearchMetric)

            LoadByMediaSpotRadioResearchID = From MediaSpotRadioResearchMetric In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioResearchMetric).Include("MediaMetric")
                                             Where MediaSpotRadioResearchMetric.MediaSpotRadioResearchID = MediaSpotRadioResearchID
                                             Select MediaSpotRadioResearchMetric

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotRadioResearchMetric)

            Load = From MediaSpotRadioResearchMetric In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioResearchMetric)
                   Select MediaSpotRadioResearchMetric

        End Function

#End Region

    End Module

End Namespace
