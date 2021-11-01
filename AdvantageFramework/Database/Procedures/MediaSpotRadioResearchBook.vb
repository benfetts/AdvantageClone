Namespace Database.Procedures.MediaSpotRadioResearchBook

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

        Public Function LoadByMediaSpotRadioResearchID(DbContext As Database.DbContext, MediaSpotRadioResearchID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotRadioResearchBook)

            LoadByMediaSpotRadioResearchID = From MediaSpotRadioResearchBook In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioResearchBook)
                                             Where MediaSpotRadioResearchBook.MediaSpotRadioResearchID = MediaSpotRadioResearchID
                                             Select MediaSpotRadioResearchBook

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotRadioResearchBook)

            Load = From MediaSpotRadioResearchBook In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioResearchBook)
                   Select MediaSpotRadioResearchBook

        End Function

#End Region

    End Module

End Namespace
