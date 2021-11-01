Namespace Database.Procedures.MediaSpotNationalResearch

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

        Public Function LoadByID(DbContext As Database.DbContext, ID As Integer) As Database.Entities.MediaSpotNationalResearch

            LoadByID = (From MediaSpotNationalResearch In DbContext.GetQuery(Of Database.Entities.MediaSpotNationalResearch).Include("MediaSpotNationalResearchMediaDemos").Include("MediaSpotNationalResearchMetrics").Include("MediaSpotNationalResearchNetworks")
                        Where MediaSpotNationalResearch.ID = ID
                        Select MediaSpotNationalResearch).SingleOrDefault

        End Function
        Public Function LoadByUserCode(DbContext As Database.DbContext, UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotNationalResearch)

            LoadByUserCode = From MediaSpotNationalResearch In DbContext.GetQuery(Of Database.Entities.MediaSpotNationalResearch)
                             Where MediaSpotNationalResearch.UserCode.ToUpper = UserCode.ToUpper
                             Select MediaSpotNationalResearch

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpotNationalResearch)

            Load = From MediaSpotNationalResearch In DbContext.GetQuery(Of Database.Entities.MediaSpotNationalResearch)
                   Select MediaSpotNationalResearch

        End Function
        Public Function Delete(DbContext As AdvantageFramework.Database.DbContext, MediaSpotNationalResearch As AdvantageFramework.Database.Entities.MediaSpotNationalResearch,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                If IsValid Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_NATIONAL_RESEARCH_MEDIA_DEMO WHERE MEDIA_SPOT_NATIONAL_RESEARCH_ID = {0}", MediaSpotNationalResearch.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_NATIONAL_RESEARCH_METRIC WHERE MEDIA_SPOT_NATIONAL_RESEARCH_ID = {0}", MediaSpotNationalResearch.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_NATIONAL_RESEARCH_NETWORK WHERE MEDIA_SPOT_NATIONAL_RESEARCH_ID = {0}", MediaSpotNationalResearch.ID))

                    DbContext.DeleteEntityObject(MediaSpotNationalResearch)

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
        Public Function Update(DbContext As AdvantageFramework.Database.DbContext, MediaSpotNationalResearch As AdvantageFramework.Database.Entities.MediaSpotNationalResearch,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.UpdateObject(MediaSpotNationalResearch)

                ErrorText = MediaSpotNationalResearch.ValidateEntity(IsValid)

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
