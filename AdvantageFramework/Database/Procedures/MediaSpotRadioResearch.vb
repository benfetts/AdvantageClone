Namespace Database.Procedures.MediaSpotRadioResearch

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

        Public Function LoadByID(DbContext As Database.DbContext, ID As Integer) As Database.Entities.MediaSpotRadioResearch

            LoadByID = (From MediaSpotRadioResearch In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioResearch).Include("MediaSpotRadioResearchBooks").Include("MediaSpotRadioResearchDayparts").Include("MediaSpotRadioResearchMetrics").Include("MediaSpotRadioResearchStations")
                        Where MediaSpotRadioResearch.ID = ID
                        Select MediaSpotRadioResearch).SingleOrDefault

        End Function
        Public Function LoadByUserCode(DbContext As Database.DbContext, UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotRadioResearch)

            LoadByUserCode = From MediaSpotRadioResearch In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioResearch)
                             Where MediaSpotRadioResearch.UserCode.ToUpper = UserCode.ToUpper
                             Select MediaSpotRadioResearch

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotRadioResearch)

            Load = From MediaSpotRadioResearch In DbContext.GetQuery(Of Database.Entities.MediaSpotRadioResearch)
                   Select MediaSpotRadioResearch

        End Function
        Public Function Delete(DbContext As AdvantageFramework.Database.DbContext, MediaSpotRadioResearch As AdvantageFramework.Database.Entities.MediaSpotRadioResearch,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                If IsValid Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_RADIO_RESEARCH_BOOK WHERE MEDIA_SPOT_RADIO_RESEARCH_ID = {0}", MediaSpotRadioResearch.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_RADIO_RESEARCH_DAYPART WHERE MEDIA_SPOT_RADIO_RESEARCH_ID = {0}", MediaSpotRadioResearch.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_RADIO_RESEARCH_METRIC WHERE MEDIA_SPOT_RADIO_RESEARCH_ID = {0}", MediaSpotRadioResearch.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_RADIO_RESEARCH_STATION WHERE MEDIA_SPOT_RADIO_RESEARCH_ID = {0}", MediaSpotRadioResearch.ID))

                    DbContext.DeleteEntityObject(MediaSpotRadioResearch)

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
        Public Function Update(DbContext As AdvantageFramework.Database.DbContext, MediaSpotRadioResearch As AdvantageFramework.Database.Entities.MediaSpotRadioResearch,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.UpdateObject(MediaSpotRadioResearch)

                ErrorText = MediaSpotRadioResearch.ValidateEntity(IsValid)

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
