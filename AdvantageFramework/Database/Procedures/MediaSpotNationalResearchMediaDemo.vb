Namespace Database.Procedures.MediaSpotNationalResearchMediaDemo

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

        Public Function LoadByMediaSpotNationalResearchID(DbContext As Database.DbContext, MediaSpotNationalResearchID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotNationalResearchMediaDemo)

            LoadByMediaSpotNationalResearchID = From MediaSpotNationalResearchMediaDemo In DbContext.GetQuery(Of Database.Entities.MediaSpotNationalResearchMediaDemo)
                                                Where MediaSpotNationalResearchMediaDemo.MediaSpotNationalResearchID = MediaSpotNationalResearchID
                                                Select MediaSpotNationalResearchMediaDemo

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotNationalResearchMediaDemo)

            Load = From MediaSpotNationalResearchMediaDemo In DbContext.GetQuery(Of Database.Entities.MediaSpotNationalResearchMediaDemo)
                   Select MediaSpotNationalResearchMediaDemo

        End Function

#End Region

    End Module

End Namespace
