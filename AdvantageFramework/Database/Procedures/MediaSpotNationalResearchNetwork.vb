Namespace Database.Procedures.MediaSpotNationalResearchNetwork

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

        Public Function LoadByMediaSpotNationalResearchID(DbContext As Database.DbContext, MediaSpotNationalResearchID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotNationalResearchNetwork)

            LoadByMediaSpotNationalResearchID = From MediaSpotNationalResearchNetwork In DbContext.GetQuery(Of Database.Entities.MediaSpotNationalResearchNetwork)
                                                Where MediaSpotNationalResearchNetwork.MediaSpotNationalResearchID = MediaSpotNationalResearchID
                                                Select MediaSpotNationalResearchNetwork

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotNationalResearchNetwork)

            Load = From MediaSpotNationalResearchNetwork In DbContext.GetQuery(Of Database.Entities.MediaSpotNationalResearchNetwork)
                   Select MediaSpotNationalResearchNetwork

        End Function

#End Region

    End Module

End Namespace
