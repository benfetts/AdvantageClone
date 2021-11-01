Namespace Database.Procedures.MediaSpotRadioCountyResearch

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

        Public Function LoadByID(DbContext As Database.DbContext, ID As Integer) As Database.Entities.MediaSpotRadioCountyResearch

            LoadByID = (From MediaSpotRadioCountyResearch In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioCountyResearch).Include("MediaSpotRadioCountyResearchMetrics").Include("MediaSpotRadioCountyResearchStations").Include("MediaSpotRadioCountyResearchYears")
                        Where MediaSpotRadioCountyResearch.ID = ID
                        Select MediaSpotRadioCountyResearch).SingleOrDefault

        End Function
        Public Function LoadByUserCode(DbContext As Database.DbContext, UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotRadioCountyResearch)

            LoadByUserCode = From MediaSpotRadioCountyResearch In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioCountyResearch)
                             Where MediaSpotRadioCountyResearch.UserCode.ToUpper = UserCode.ToUpper
                             Select MediaSpotRadioCountyResearch

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotRadioCountyResearch)

            Load = From MediaSpotRadioCountyResearch In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioCountyResearch)
                   Select MediaSpotRadioCountyResearch

        End Function
        Public Function Delete(DbContext As AdvantageFramework.Database.DbContext, MediaSpotRadioCountyResearch As AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearch,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                If IsValid Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_RADIO_COUNTY_RESEARCH_STATION WHERE MEDIA_SPOT_RADIO_COUNTY_RESEARCH_ID = {0}", MediaSpotRadioCountyResearch.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_RADIO_COUNTY_RESEARCH_METRIC WHERE MEDIA_SPOT_RADIO_COUNTY_RESEARCH_ID = {0}", MediaSpotRadioCountyResearch.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_RADIO_COUNTY_RESEARCH_YEAR WHERE MEDIA_SPOT_RADIO_COUNTY_RESEARCH_ID = {0}", MediaSpotRadioCountyResearch.ID))

                    DbContext.DeleteEntityObject(MediaSpotRadioCountyResearch)

                    DbContext.SaveChanges()

                    Deleted = True

                End If

            Catch ex As Exception
                Deleted = False
                ErrorText = ex.Message
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function Update(DbContext As AdvantageFramework.Database.DbContext, MediaSpotRadioCountyResearch As AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearch,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.UpdateObject(MediaSpotRadioCountyResearch)

                ErrorText = MediaSpotRadioCountyResearch.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                End If

            Catch ex As Exception
                Updated = False
                ErrorText = ex.Message
            Finally
                Update = Updated
            End Try

        End Function

#End Region

    End Module

End Namespace
