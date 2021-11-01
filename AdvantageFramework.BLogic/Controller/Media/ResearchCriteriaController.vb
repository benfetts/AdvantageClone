Namespace Controller.Media

    Public Class ResearchCriteriaController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Load(ResearchID As Nullable(Of Integer), Type As String, IsCopy As Boolean) As AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel

            'objects
            Dim ResearchCriteriaViewModel As AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If Type = "SpotTV" Then

                    ResearchCriteriaViewModel = New AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel(AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel.ResearchType.SpotTV, IsCopy)

                    If ResearchID.HasValue Then

                        ResearchCriteriaViewModel.ResearchCriteria = New AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria(AdvantageFramework.Database.Procedures.MediaSpotTVResearch.LoadByID(DbContext, ResearchID.Value))

                    Else

                        ResearchCriteriaViewModel.ResearchCriteria = New AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria

                    End If

                ElseIf Type = "SpotRadio" Then

                    ResearchCriteriaViewModel = New AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel(AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel.ResearchType.SpotRadio, IsCopy)

                    If ResearchID.HasValue Then

                        ResearchCriteriaViewModel.ResearchCriteria = New AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria(AdvantageFramework.Database.Procedures.MediaSpotRadioResearch.LoadByID(DbContext, ResearchID.Value))

                    Else

                        ResearchCriteriaViewModel.ResearchCriteria = New AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria

                    End If

                ElseIf Type = "SpotRadioCounty" Then

                    ResearchCriteriaViewModel = New AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel(AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel.ResearchType.SpotRadioCounty, IsCopy)

                    If ResearchID.HasValue Then

                        ResearchCriteriaViewModel.ResearchCriteria = New AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria(AdvantageFramework.Database.Procedures.MediaSpotRadioCountyResearch.LoadByID(DbContext, ResearchID.Value))

                    Else

                        ResearchCriteriaViewModel.ResearchCriteria = New AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria

                    End If

                ElseIf Type = "National" Then

                    ResearchCriteriaViewModel = New AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel(AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel.ResearchType.National, IsCopy)

                    If ResearchID.HasValue Then

                        ResearchCriteriaViewModel.ResearchCriteria = New AdvantageFramework.DTO.Media.National.ResearchCriteria(AdvantageFramework.Database.Procedures.MediaSpotNationalResearch.LoadByID(DbContext, ResearchID.Value))

                    Else

                        ResearchCriteriaViewModel.ResearchCriteria = New AdvantageFramework.DTO.Media.National.ResearchCriteria

                    End If

                End If

            End Using

            Load = ResearchCriteriaViewModel

        End Function
        Public Function AddRadio(ResearchCriteriaViewModel As AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel,
                                 CriteriaName As String, ByRef ErrorText As String, ByRef MediaSpotRadioResearchID As Nullable(Of Integer)) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim MediaSpotRadioResearch As AdvantageFramework.Database.Entities.MediaSpotRadioResearch = Nothing
            Dim IsValid As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    MediaSpotRadioResearch = New AdvantageFramework.Database.Entities.MediaSpotRadioResearch

                    MediaSpotRadioResearch.DbContext = DbContext
                    MediaSpotRadioResearch.UserCode = DbContext.UserCode
                    MediaSpotRadioResearch.CriteriaName = CriteriaName
                    MediaSpotRadioResearch.NielsenRadioQualitativeID = 1
                    MediaSpotRadioResearch.OutputType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.Ranker
                    MediaSpotRadioResearch.Geography = AdvantageFramework.Database.Entities.SpotRadioResearchGeography.Metro
                    MediaSpotRadioResearch.ListeningType = AdvantageFramework.Database.Entities.SpotRadioResearchListeningType.Total
                    MediaSpotRadioResearch.Ethnicity = AdvantageFramework.Database.Entities.SpotRadioResearchEthnicity.All
                    MediaSpotRadioResearch.ShowFormat = True
                    MediaSpotRadioResearch.ShowSpill = False

                    If Session.IsNielsenSetup Then

                        MediaSpotRadioResearch.Source = Nielsen.Database.Entities.Methods.RadioSource.Nielsen

                    ElseIf Session.IsEastlanSetup Then

                        MediaSpotRadioResearch.Source = Nielsen.Database.Entities.Methods.RadioSource.Eastlan

                    End If

                    ErrorText = MediaSpotRadioResearch.ValidateEntity(IsValid)

                    If IsValid Then

                        DbContext.MediaSpotRadioResearchs.Add(MediaSpotRadioResearch)
                        DbContext.SaveChanges()

                        MediaSpotRadioResearchID = MediaSpotRadioResearch.ID

                        Added = True

                    End If

                End Using

            End Using

            AddRadio = Added

        End Function
        Public Function AddTV(ResearchCriteriaViewModel As AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel,
                              CriteriaName As String, ByRef ErrorText As String, ByRef MediaSpotTVResearchID As Nullable(Of Integer)) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim MediaSpotTVResearch As AdvantageFramework.Database.Entities.MediaSpotTVResearch = Nothing
            Dim IsValid As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaSpotTVResearch = New AdvantageFramework.Database.Entities.MediaSpotTVResearch

                MediaSpotTVResearch.DbContext = DbContext
                MediaSpotTVResearch.UserCode = DbContext.UserCode
                MediaSpotTVResearch.CriteriaName = CriteriaName
                MediaSpotTVResearch.MarketCode = Nothing
                MediaSpotTVResearch.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.Ranker
                MediaSpotTVResearch.DominantProgramming = False
                MediaSpotTVResearch.ShowProgramName = True
                MediaSpotTVResearch.ShowSpill = False

                If Session.IsNielsenSetup Then

                    MediaSpotTVResearch.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen

                ElseIf Session.IsComscoreSetup Then

                    MediaSpotTVResearch.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore

                End If

                ErrorText = MediaSpotTVResearch.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.MediaSpotTVResearchs.Add(MediaSpotTVResearch)
                    DbContext.SaveChanges()

                    MediaSpotTVResearchID = MediaSpotTVResearch.ID

                    Added = True

                End If

            End Using

            AddTV = Added

        End Function
        Public Function CopyRadio(ResearchCriteriaViewModel As AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel,
                                  CriteriaName As String, CopyResearchID As Integer, ByRef ErrorText As String, ByRef MediaSpotTVResearchID As Integer) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim MediaSpotRadioResearch As AdvantageFramework.Database.Entities.MediaSpotRadioResearch = Nothing
            Dim IsValid As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaSpotRadioResearch = AdvantageFramework.Database.Procedures.MediaSpotRadioResearch.LoadByID(DbContext, CopyResearchID)

                If MediaSpotRadioResearch IsNot Nothing Then

                    Try

                        If Not (From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearch.Load(DbContext)
                                Where Entity.CriteriaName.ToUpper = DirectCast(CriteriaName, String).Trim.ToUpper
                                Select Entity).Any Then

                            MediaSpotRadioResearch.UserCode = Session.UserCode
                            MediaSpotRadioResearch.CriteriaName = CriteriaName
                            MediaSpotRadioResearch.Market = Nothing

                            DbContext.MediaSpotRadioResearchs.Add(MediaSpotRadioResearch)
                            DbContext.SaveChanges()

                            MediaSpotTVResearchID = MediaSpotRadioResearch.ID

                            Copied = True

                        Else

                            ErrorText = "Report name exists."

                        End If

                    Catch ex As Exception
                        ErrorText = ex.Message
                    End Try

                Else

                    ErrorText = "Cannot find selected report to copy from."

                End If

            End Using

            CopyRadio = Copied

        End Function
        Public Function CopyTV(ResearchCriteriaViewModel As AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel,
                               CriteriaName As String, CopyResearchID As Integer, ByRef ErrorText As String, ByRef MediaSpotTVResearchID As Integer) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim MediaSpotTVResearch As AdvantageFramework.Database.Entities.MediaSpotTVResearch = Nothing
            Dim IsValid As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaSpotTVResearch = AdvantageFramework.Database.Procedures.MediaSpotTVResearch.LoadByID(DbContext, CopyResearchID)

                If MediaSpotTVResearch IsNot Nothing Then

                    Try

                        If Not (From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearch.Load(DbContext)
                                Where Entity.CriteriaName.ToUpper = DirectCast(CriteriaName, String).Trim.ToUpper
                                Select Entity).Any Then

                            MediaSpotTVResearch.UserCode = Session.UserCode
                            MediaSpotTVResearch.CriteriaName = CriteriaName
                            MediaSpotTVResearch.Market = Nothing

                            DbContext.MediaSpotTVResearchs.Add(MediaSpotTVResearch)
                            DbContext.SaveChanges()

                            MediaSpotTVResearchID = MediaSpotTVResearch.ID

                            Copied = True

                        Else

                            ErrorText = "Report name exists."

                        End If

                    Catch ex As Exception
                        ErrorText = ex.Message
                    End Try

                Else

                    ErrorText = "Cannot find selected report to copy from."

                End If

            End Using

            CopyTV = Copied

        End Function
        Public Function UpdateTV(ResearchCriteriaViewModel As AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel,
                                 CriteriaName As String, ByRef ErrorText As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim MediaSpotTVResearch As AdvantageFramework.Database.Entities.MediaSpotTVResearch = Nothing
            Dim IsValid As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaSpotTVResearch = AdvantageFramework.Database.Procedures.MediaSpotTVResearch.LoadByID(DbContext, ResearchCriteriaViewModel.ID)

                If MediaSpotTVResearch IsNot Nothing Then

                    MediaSpotTVResearch.DbContext = DbContext
                    MediaSpotTVResearch.CriteriaName = CriteriaName.Trim

                    ErrorText = MediaSpotTVResearch.ValidateCustomProperties(AdvantageFramework.Database.Entities.MediaSpotTVResearch.Properties.CriteriaName.ToString, IsValid, CriteriaName.Trim)

                    If IsValid Then

                        DbContext.Entry(Of AdvantageFramework.Database.Entities.MediaSpotTVResearch)(MediaSpotTVResearch).State = Entity.EntityState.Modified

                        DbContext.SaveChanges()

                        Updated = True

                    End If

                End If

            End Using

            UpdateTV = Updated

        End Function
        Public Function UpdateRadio(ResearchCriteriaViewModel As AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel,
                                    CriteriaName As String, ByRef ErrorText As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim MediaSpotRadioResearch As AdvantageFramework.Database.Entities.MediaSpotRadioResearch = Nothing
            Dim IsValid As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaSpotRadioResearch = AdvantageFramework.Database.Procedures.MediaSpotRadioResearch.LoadByID(DbContext, ResearchCriteriaViewModel.ID)

                If MediaSpotRadioResearch IsNot Nothing Then

                    MediaSpotRadioResearch.DbContext = DbContext
                    MediaSpotRadioResearch.CriteriaName = CriteriaName.Trim

                    ErrorText = MediaSpotRadioResearch.ValidateCustomProperties(AdvantageFramework.Database.Entities.MediaSpotRadioResearch.Properties.CriteriaName.ToString, IsValid, CriteriaName.Trim)

                    If IsValid Then

                        DbContext.Entry(Of AdvantageFramework.Database.Entities.MediaSpotRadioResearch)(MediaSpotRadioResearch).State = Entity.EntityState.Modified

                        DbContext.SaveChanges()

                        Updated = True

                    End If

                End If

            End Using

            UpdateRadio = Updated

        End Function
        Public Function AddRadioCounty(ResearchCriteriaViewModel As AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel,
                                       CriteriaName As String, ByRef ErrorText As String, ByRef MediaSpotRadioCountyResearchID As Nullable(Of Integer)) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim MediaSpotRadioCountyResearch As AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearch = Nothing
            Dim IsValid As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    MediaSpotRadioCountyResearch = New AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearch

                    MediaSpotRadioCountyResearch.DbContext = DbContext
                    MediaSpotRadioCountyResearch.UserCode = DbContext.UserCode
                    MediaSpotRadioCountyResearch.CriteriaName = CriteriaName
                    MediaSpotRadioCountyResearch.CountyCode = Nothing
                    MediaSpotRadioCountyResearch.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.Ranker
                    MediaSpotRadioCountyResearch.Ethnicity = AdvantageFramework.Database.Entities.SpotRadioCountyResearchEthnicity.All
                    MediaSpotRadioCountyResearch.Daypart68 = False
                    MediaSpotRadioCountyResearch.Daypart84 = False
                    MediaSpotRadioCountyResearch.ShowFrequency = False

                    ErrorText = MediaSpotRadioCountyResearch.ValidateEntity(IsValid)

                    If IsValid Then

                        DbContext.MediaSpotRadioCountyResearchs.Add(MediaSpotRadioCountyResearch)
                        DbContext.SaveChanges()

                        MediaSpotRadioCountyResearchID = MediaSpotRadioCountyResearch.ID

                        Added = True

                    End If

                End Using

            End Using

            AddRadioCounty = Added

        End Function
        Public Function UpdateRadioCounty(ResearchCriteriaViewModel As AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel,
                                          CriteriaName As String, ByRef ErrorText As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim MediaSpotRadioCountyResearch As AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearch = Nothing
            Dim IsValid As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaSpotRadioCountyResearch = AdvantageFramework.Database.Procedures.MediaSpotRadioCountyResearch.LoadByID(DbContext, ResearchCriteriaViewModel.ID)

                If MediaSpotRadioCountyResearch IsNot Nothing Then

                    MediaSpotRadioCountyResearch.DbContext = DbContext
                    MediaSpotRadioCountyResearch.CriteriaName = CriteriaName.Trim

                    ErrorText = MediaSpotRadioCountyResearch.ValidateCustomProperties(AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearch.Properties.CriteriaName.ToString, IsValid, CriteriaName.Trim)

                    If IsValid Then

                        DbContext.Entry(Of AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearch)(MediaSpotRadioCountyResearch).State = Entity.EntityState.Modified

                        DbContext.SaveChanges()

                        Updated = True

                    End If

                End If

            End Using

            UpdateRadioCounty = Updated

        End Function
        Public Function CopyRadioCounty(ResearchCriteriaViewModel As AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel,
                                        CriteriaName As String, CopyResearchID As Integer, ByRef ErrorText As String, ByRef MediaSpotRadioCountyResearchID As Integer) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim MediaSpotRadioCountyResearch As AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearch = Nothing
            Dim IsValid As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaSpotRadioCountyResearch = AdvantageFramework.Database.Procedures.MediaSpotRadioCountyResearch.LoadByID(DbContext, CopyResearchID)

                If MediaSpotRadioCountyResearch IsNot Nothing Then

                    Try

                        If Not (From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioCountyResearch.Load(DbContext)
                                Where Entity.CriteriaName.ToUpper = DirectCast(CriteriaName, String).Trim.ToUpper
                                Select Entity).Any Then

                            MediaSpotRadioCountyResearch.UserCode = Session.UserCode
                            MediaSpotRadioCountyResearch.CriteriaName = CriteriaName

                            DbContext.MediaSpotRadioCountyResearchs.Add(MediaSpotRadioCountyResearch)
                            DbContext.SaveChanges()

                            MediaSpotRadioCountyResearchID = MediaSpotRadioCountyResearch.ID

                            Copied = True

                        Else

                            ErrorText = "Report name exists."

                        End If

                    Catch ex As Exception
                        ErrorText = ex.Message
                    End Try

                Else

                    ErrorText = "Cannot find selected report to copy from."

                End If

            End Using

            CopyRadioCounty = Copied

        End Function
        Public Function AddNational(ResearchCriteriaViewModel As AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel,
                                    CriteriaName As String, ByRef ErrorText As String, ByRef MediaNationalResearchID As Nullable(Of Integer)) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ResearchCriteria As AdvantageFramework.DTO.Media.National.ResearchCriteria = Nothing
            Dim MediaSpotNationalResearch As AdvantageFramework.Database.Entities.MediaSpotNationalResearch = Nothing
            Dim IsValid As Boolean = True

            ResearchCriteria = New AdvantageFramework.DTO.Media.National.ResearchCriteria

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ResearchCriteria.UserCode = DbContext.UserCode
                ResearchCriteria.CriteriaName = CriteriaName

                MediaSpotNationalResearch = New AdvantageFramework.Database.Entities.MediaSpotNationalResearch

                ResearchCriteria.SaveToEntity(MediaSpotNationalResearch)

                MediaSpotNationalResearch.DbContext = DbContext

                ErrorText = MediaSpotNationalResearch.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.MediaSpotNationalResearchs.Add(MediaSpotNationalResearch)
                    DbContext.SaveChanges()

                    MediaNationalResearchID = MediaSpotNationalResearch.ID

                    Added = True

                End If

            End Using

            AddNational = Added

        End Function
        Public Function CopyNational(ResearchCriteriaViewModel As AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel,
                                     CriteriaName As String, CopyResearchID As Integer, ByRef ErrorText As String, ByRef MediaSpotRadioCountyResearchID As Integer) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim MediaSpotNationalResearch As AdvantageFramework.Database.Entities.MediaSpotNationalResearch = Nothing
            Dim IsValid As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaSpotNationalResearch = AdvantageFramework.Database.Procedures.MediaSpotNationalResearch.LoadByID(DbContext, CopyResearchID)

                If MediaSpotNationalResearch IsNot Nothing Then

                    Try

                        If Not (From Entity In AdvantageFramework.Database.Procedures.MediaSpotNationalResearch.Load(DbContext)
                                Where Entity.CriteriaName.ToUpper = DirectCast(CriteriaName, String).Trim.ToUpper
                                Select Entity).Any Then

                            MediaSpotNationalResearch.UserCode = Session.UserCode
                            MediaSpotNationalResearch.CriteriaName = CriteriaName

                            DbContext.MediaSpotNationalResearchs.Add(MediaSpotNationalResearch)
                            DbContext.SaveChanges()

                            MediaSpotRadioCountyResearchID = MediaSpotNationalResearch.ID

                            Copied = True

                        Else

                            ErrorText = "Report name exists."

                        End If

                    Catch ex As Exception
                        ErrorText = ex.Message
                    End Try

                Else

                    ErrorText = "Cannot find selected report to copy from."

                End If

            End Using

            CopyNational = Copied

        End Function
        Public Function UpdateNational(ResearchCriteriaViewModel As AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel,
                                       CriteriaName As String, ByRef ErrorText As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim MediaSpotNationalResearch As AdvantageFramework.Database.Entities.MediaSpotNationalResearch = Nothing
            Dim IsValid As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaSpotNationalResearch = AdvantageFramework.Database.Procedures.MediaSpotNationalResearch.LoadByID(DbContext, ResearchCriteriaViewModel.ID)

                If MediaSpotNationalResearch IsNot Nothing Then

                    MediaSpotNationalResearch.DbContext = DbContext
                    MediaSpotNationalResearch.CriteriaName = CriteriaName.Trim

                    ErrorText = MediaSpotNationalResearch.ValidateCustomProperties(AdvantageFramework.Database.Entities.MediaSpotNationalResearch.Properties.CriteriaName.ToString, IsValid, CriteriaName.Trim)

                    If IsValid Then

                        DbContext.Entry(Of AdvantageFramework.Database.Entities.MediaSpotNationalResearch)(MediaSpotNationalResearch).State = Entity.EntityState.Modified

                        DbContext.SaveChanges()

                        Updated = True

                    End If

                End If

            End Using

            UpdateNational = Updated

        End Function

#End Region

#End Region

    End Class

End Namespace
