Namespace Database.Procedures.MediaSpotRadioCountyResearchYear

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

        Public Function LoadByMediaSpotRadioCountyResearchID(DbContext As Database.DbContext, MediaSpotRadioCountyResearchID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotRadioCountyResearchYear)

            LoadByMediaSpotRadioCountyResearchID = From MediaSpotRadioCountyResearchYear In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioCountyResearchYear)
                                                   Where MediaSpotRadioCountyResearchYear.MediaSpotRadioCountyResearchID = MediaSpotRadioCountyResearchID
                                                   Select MediaSpotRadioCountyResearchYear

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotRadioCountyResearchYear)

            Load = From MediaSpotRadioCountyResearchYear In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioCountyResearchYear)
                   Select MediaSpotRadioCountyResearchYear

        End Function

#End Region

    End Module

End Namespace
