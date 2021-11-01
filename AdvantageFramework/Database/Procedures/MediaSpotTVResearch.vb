Namespace Database.Procedures.MediaSpotTVResearch

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

        Public Function LoadByID(DbContext As Database.DbContext, ID As Integer) As Database.Entities.MediaSpotTVResearch

            LoadByID = (From MediaSpotTVResearch In DbContext.GetQuery(Of Database.Entities.MediaSpotTVResearch).Include("MediaSpotTVResearchBooks").Include("MediaSpotTVResearchDayTimes").Include("MediaSpotTVResearchDemos").Include("MediaSpotTVResearchMetrics").Include("MediaSpotTVResearchStations")
                        Where MediaSpotTVResearch.ID = ID
                        Select MediaSpotTVResearch).SingleOrDefault

        End Function
        Public Function LoadByUserCode(DbContext As Database.DbContext, UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotTVResearch)

            LoadByUserCode = From MediaSpotTVResearch In DbContext.GetQuery(Of Database.Entities.MediaSpotTVResearch)
                             Where MediaSpotTVResearch.UserCode.ToUpper = UserCode.ToUpper
                             Select MediaSpotTVResearch

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotTVResearch)

            Load = From MediaSpotTVResearch In DbContext.GetQuery(Of Database.Entities.MediaSpotTVResearch)
                   Select MediaSpotTVResearch

        End Function
        Public Function Delete(DbContext As AdvantageFramework.Database.DbContext, MediaSpotTVResearch As AdvantageFramework.Database.Entities.MediaSpotTVResearch,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                If IsValid Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_TV_RESEARCH_BOOK WHERE MEDIA_SPOT_TV_RESEARCH_ID = {0}", MediaSpotTVResearch.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_TV_RESEARCH_DAYTIME WHERE MEDIA_SPOT_TV_RESEARCH_ID = {0}", MediaSpotTVResearch.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_TV_RESEARCH_DEMO WHERE MEDIA_SPOT_TV_RESEARCH_ID = {0}", MediaSpotTVResearch.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_TV_RESEARCH_METRIC WHERE MEDIA_SPOT_TV_RESEARCH_ID = {0}", MediaSpotTVResearch.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_TV_RESEARCH_STATION WHERE MEDIA_SPOT_TV_RESEARCH_ID = {0}", MediaSpotTVResearch.ID))

                    DbContext.DeleteEntityObject(MediaSpotTVResearch)

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
        Public Function Update(DbContext As AdvantageFramework.Database.DbContext, MediaSpotTVResearch As AdvantageFramework.Database.Entities.MediaSpotTVResearch,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.UpdateObject(MediaSpotTVResearch)

                ErrorText = MediaSpotTVResearch.ValidateEntity(IsValid)

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
