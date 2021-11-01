Namespace Database.Procedures.MediaSpotRadioResearchStation

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

        Public Function LoadByMediaSpotRadioResearchID(DbContext As Database.DbContext, MediaSpotRadioResearchID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotRadioResearchStation)

            LoadByMediaSpotRadioResearchID = From MediaSpotRadioResearchStation In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioResearchStation)
                                             Where MediaSpotRadioResearchStation.MediaSpotRadioResearchID = MediaSpotRadioResearchID
                                             Select MediaSpotRadioResearchStation

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotRadioResearchStation)

            Load = From MediaSpotRadioResearchStation In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioResearchStation)
                   Select MediaSpotRadioResearchStation

        End Function

#End Region

    End Module

End Namespace
