Namespace Database.Procedures.MediaSpotRadioResearchDaypart

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

        Public Function LoadByMediaSpotRadioResearchID(DbContext As Database.DbContext, MediaSpotRadioResearchID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotRadioResearchDaypart)

            LoadByMediaSpotRadioResearchID = From MediaSpotRadioResearchDaypart In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioResearchDaypart)
                                             Where MediaSpotRadioResearchDaypart.MediaSpotRadioResearchID = MediaSpotRadioResearchID
                                             Select MediaSpotRadioResearchDaypart

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotRadioResearchDaypart)

            Load = From MediaSpotRadioResearchDaypart In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioResearchDaypart)
                   Select MediaSpotRadioResearchDaypart

        End Function

#End Region

    End Module

End Namespace
