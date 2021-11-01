Namespace Database.Procedures.MediaSpotTVResearchBook

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

        Public Function LoadByMediaSpotTVResearchID(DbContext As Database.DbContext, MediaSpotTVResearchID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotTVResearchBook)

            LoadByMediaSpotTVResearchID = From MediaSpotTVResearchBook In DbContext.GetQuery(Of Database.Entities.MediaSpotTVResearchBook)
                                          Where MediaSpotTVResearchBook.MediaSpotTVResearchID = MediaSpotTVResearchID
                                          Select MediaSpotTVResearchBook

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotTVResearchBook)

            Load = From MediaSpotTVResearchBook In DbContext.GetQuery(Of Database.Entities.MediaSpotTVResearchBook)
                   Select MediaSpotTVResearchBook

        End Function

#End Region

    End Module

End Namespace
