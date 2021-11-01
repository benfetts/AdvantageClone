Namespace Database.Procedures.MediaSpotRadioCountyResearchStation

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

        Public Function LoadByMediaSpotRadioCountyResearchID(DbContext As Database.DbContext, MediaSpotRadioCountyResearchID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotRadioCountyResearchStation)

            LoadByMediaSpotRadioCountyResearchID = From MediaSpotRadioCountyResearchStation In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioCountyResearchStation)
                                                   Where MediaSpotRadioCountyResearchStation.MediaSpotRadioCountyResearchID = MediaSpotRadioCountyResearchID
                                                   Select MediaSpotRadioCountyResearchStation

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotRadioCountyResearchStation)

            Load = From MediaSpotRadioCountyResearchStation In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioCountyResearchStation)
                   Select MediaSpotRadioCountyResearchStation

        End Function

#End Region

    End Module

End Namespace
