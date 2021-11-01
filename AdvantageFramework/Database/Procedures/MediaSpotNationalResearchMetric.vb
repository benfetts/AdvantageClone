Namespace Database.Procedures.MediaSpotNationalResearchMetric

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

        Public Function LoadByMediaSpotNationalResearchID(DbContext As Database.DbContext, MediaSpotNationalResearchID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotNationalResearchMetric)

            LoadByMediaSpotNationalResearchID = From MediaSpotNationalResearchMetric In DbContext.GetQuery(Of Database.Entities.MediaSpotNationalResearchMetric)
                                                Where MediaSpotNationalResearchMetric.MediaSpotNationalResearchID = MediaSpotNationalResearchID
                                                Select MediaSpotNationalResearchMetric

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotNationalResearchMetric)

            Load = From MediaSpotNationalResearchMetric In DbContext.GetQuery(Of Database.Entities.MediaSpotNationalResearchMetric)
                   Select MediaSpotNationalResearchMetric

        End Function

#End Region

    End Module

End Namespace
