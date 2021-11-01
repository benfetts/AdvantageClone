Namespace Database.Procedures.MediaDemographic

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

        Public Function LoadAllActiveByMediaDemoSourceIDAndType(DbContext As Database.DbContext, MediaDemoSourceID As AdvantageFramework.Database.Entities.MediaDemoSourceID, Type As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaDemographic)

            LoadAllActiveByMediaDemoSourceIDAndType = From MediaDemographic In DbContext.GetQuery(Of Database.Entities.MediaDemographic)
                                                      Where MediaDemographic.IsInactive = False AndAlso
                                                            MediaDemographic.MediaDemoSourceID = MediaDemoSourceID AndAlso
                                                            MediaDemographic.Type = Type
                                                      Select MediaDemographic

        End Function
        Public Function LoadAllActiveByMediaDemoSourceID(DbContext As Database.DbContext, MediaDemoSourceID As AdvantageFramework.Database.Entities.MediaDemoSourceID) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaDemographic)

            LoadAllActiveByMediaDemoSourceID = From MediaDemographic In DbContext.GetQuery(Of Database.Entities.MediaDemographic)
                                               Where MediaDemographic.IsInactive = False AndAlso
                                                     MediaDemographic.MediaDemoSourceID = MediaDemoSourceID
                                               Select MediaDemographic

        End Function
        Public Function LoadAllActiveByType(DbContext As Database.DbContext, Type As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaDemographic)

            LoadAllActiveByType = From MediaDemographic In DbContext.GetQuery(Of Database.Entities.MediaDemographic)
                                  Where MediaDemographic.IsInactive = False AndAlso
                                        MediaDemographic.Type = Type
                                  Select MediaDemographic

        End Function
        Public Function LoadActiveNielsenTV(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaDemographic)

            LoadActiveNielsenTV = From MediaDemographic In DbContext.GetQuery(Of Database.Entities.MediaDemographic)
                                  Where MediaDemographic.IsInactive = False AndAlso
                                        MediaDemographic.Type = "T" AndAlso
                                        MediaDemographic.MediaDemoSourceID = AdvantageFramework.Database.Entities.MediaDemoSourceID.Nielsen
                                  Select MediaDemographic

        End Function
        Public Function LoadActiveComscoreTV(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaDemographic)

            LoadActiveComscoreTV = From MediaDemographic In DbContext.GetQuery(Of Database.Entities.MediaDemographic)
                                   Where MediaDemographic.IsInactive = False AndAlso
                                         MediaDemographic.Type = "T" AndAlso
                                         MediaDemographic.MediaDemoSourceID = AdvantageFramework.Database.Entities.MediaDemoSourceID.Comscore
                                   Select MediaDemographic

        End Function
        Public Function LoadByCode(DbContext As Database.DbContext, Code As String) As Database.Entities.MediaDemographic

            LoadByCode = (From MediaDemographic In DbContext.GetQuery(Of Database.Entities.MediaDemographic)
                          Where MediaDemographic.Code = Code
                          Select MediaDemographic).SingleOrDefault

        End Function
        Public Function LoadByID(DbContext As Database.DbContext, ID As Integer) As Database.Entities.MediaDemographic

            LoadByID = (From MediaDemographic In DbContext.GetQuery(Of Database.Entities.MediaDemographic)
                        Where MediaDemographic.ID = ID
                        Select MediaDemographic).SingleOrDefault

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaDemographic)

            Load = From MediaDemographic In DbContext.GetQuery(Of Database.Entities.MediaDemographic)
                   Select MediaDemographic

        End Function
        Public Function LoadRadioReportable(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaDemographic)

            'objects
            Dim IDs As IEnumerable(Of Integer) = Nothing

            IDs = (From MediaDemographic In DbContext.GetQuery(Of Database.Entities.MediaDemographic)
                   Where MediaDemographic.IsInactive = False AndAlso
                         MediaDemographic.Type = "R" AndAlso
                         ((MediaDemographic.AgeFrom = 18 AndAlso MediaDemographic.AgeTo = 20) OrElse
                          (MediaDemographic.AgeFrom = 21 AndAlso MediaDemographic.AgeTo = 24))
                   Select MediaDemographic.ID).ToArray

            LoadRadioReportable = From MediaDemographic In DbContext.GetQuery(Of Database.Entities.MediaDemographic)
                                  Where MediaDemographic.IsInactive = False AndAlso
                                        MediaDemographic.Type = "R" AndAlso
                                        MediaDemographic.Code <> "R" AndAlso
                                        IDs.Contains(MediaDemographic.ID) = False
                                  Select MediaDemographic

        End Function
        Public Function LoadActiveRadioCounty(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaDemographic)

            LoadActiveRadioCounty = From MediaDemographic In DbContext.GetQuery(Of Database.Entities.MediaDemographic)
                                    Where MediaDemographic.IsInactive = False AndAlso
                                          MediaDemographic.Type = "R" AndAlso
                                          MediaDemographic.UseForCounty = True
                                    Select MediaDemographic

        End Function
        Public Function LoadActiveNational(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaDemographic)

            LoadActiveNational = From MediaDemographic In DbContext.GetQuery(Of Database.Entities.MediaDemographic)
                                 Where MediaDemographic.IsInactive = False AndAlso
                                       MediaDemographic.Type = "N"
                                 Select MediaDemographic

        End Function

#End Region

    End Module

End Namespace
