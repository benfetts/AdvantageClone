Namespace Database.Procedures.MediaSpotTVResearchDayTime

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

        Public Function LoadByID(DbContext As Database.DbContext, ID As Integer) As Database.Entities.MediaSpotTVResearchDayTime

            LoadByID = (From MediaSpotTVResearchDayTime In DbContext.GetQuery(Of Database.Entities.MediaSpotTVResearchDayTime)
                        Where MediaSpotTVResearchDayTime.ID = ID
                        Select MediaSpotTVResearchDayTime).SingleOrDefault

        End Function
        Public Function LoadByMediaSpotTVResearchID(DbContext As Database.DbContext, MediaSpotTVResearchID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotTVResearchDayTime)

            LoadByMediaSpotTVResearchID = From MediaSpotTVResearchDayTime In DbContext.GetQuery(Of Database.Entities.MediaSpotTVResearchDayTime)
                                          Where MediaSpotTVResearchDayTime.MediaSpotTVResearchID = MediaSpotTVResearchID
                                          Select MediaSpotTVResearchDayTime

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotTVResearchDayTime)

            Load = From MediaSpotTVResearchDayTime In DbContext.GetQuery(Of Database.Entities.MediaSpotTVResearchDayTime)
                   Select MediaSpotTVResearchDayTime

        End Function

#End Region

    End Module

End Namespace
