Namespace Database.Procedures.MediaSpotTVResearchDemo

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

        Public Function LoadByMediaSpotTVResearchID(DbContext As Database.DbContext, MediaSpotTVResearchID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotTVResearchDemo)

            LoadByMediaSpotTVResearchID = From MediaSpotTVResearchDemo In DbContext.GetQuery(Of Database.Entities.MediaSpotTVResearchDemo)
                                          Where MediaSpotTVResearchDemo.MediaSpotTVResearchID = MediaSpotTVResearchID
                                          Select MediaSpotTVResearchDemo

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotTVResearchDemo)

            Load = From MediaSpotTVResearchDemo In DbContext.GetQuery(Of Database.Entities.MediaSpotTVResearchDemo)
                   Select MediaSpotTVResearchDemo

        End Function

#End Region

    End Module

End Namespace
