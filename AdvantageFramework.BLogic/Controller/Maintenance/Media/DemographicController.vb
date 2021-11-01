Namespace Controller.Maintenance.Media

    Public Class DemographicController
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

        Private Function GetGenderCodes(DemographicSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel) As Generic.List(Of String)

            Dim GenderCodes As Generic.List(Of String) = Nothing

            GenderCodes = New Generic.List(Of String)

            If DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsBoys Then

                GenderCodes.Add("B")

            End If

            If DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsGirls Then

                GenderCodes.Add("G")

            End If

            If DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsChildren Then

                GenderCodes.Add("C")

            End If

            If DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsMales Then

                GenderCodes.Add("M")

            End If

            If DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsFemales Then

                GenderCodes.Add("F")

            End If

            If DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsWorkingWomen Then

                GenderCodes.Add("W")

            End If

            GetGenderCodes = GenderCodes

        End Function
        Private Sub SetNielsenDemographics(ByRef DemographicSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel,
                                           UseAges As Boolean)

            Dim MediaType As String = Nothing
            Dim GenderCodes As Generic.List(Of String) = Nothing
            Dim AgeFromValue As Short? = Nothing
            Dim AgeToValue As Short? = Nothing

            MediaType = DemographicSetupDetailViewModel.GetMediaDemographicEntity.Type

            GenderCodes = GetGenderCodes(DemographicSetupDetailViewModel)

            If UseAges Then

                AgeFromValue = DemographicSetupDetailViewModel.GetMediaDemographicEntity.AgeFrom
                AgeToValue = DemographicSetupDetailViewModel.GetMediaDemographicEntity.AgeTo

            End If

            If DemographicSetupDetailViewModel.GetMediaDemographicEntity.MediaDemoSourceID = AdvantageFramework.Database.Entities.MediaDemoSourceID.Nielsen Then

                DemographicSetupDetailViewModel.NielsenDemographics = (From Entity In DemographicSetupDetailViewModel.RepositoryNielsenDemographicList
                                                                       Where Entity.Gender IsNot Nothing AndAlso
                                                                       (AgeFromValue Is Nothing OrElse (AgeFromValue IsNot Nothing AndAlso Entity.AgeFrom >= AgeFromValue.Value)) AndAlso
                                                                       (AgeToValue Is Nothing OrElse (AgeToValue IsNot Nothing AndAlso Entity.AgeTo <= AgeToValue.Value)) AndAlso
                                                                       (Entity.Type = MediaType OrElse
                                                                        MediaType Is Nothing) AndAlso
                                                                       (GenderCodes.Count = 0 OrElse
                                                                        GenderCodes.Contains(Entity.Gender))).OrderBy(Function(Entity) Entity.AgeFrom).ThenBy(Function(Entity) Entity.Gender).ToList

                DemographicSetupDetailViewModel.AgeFromDatasource = (From Entity In (From Entity In DemographicSetupDetailViewModel.RepositoryNielsenDemographicList
                                                                                     Where Entity.Gender IsNot Nothing AndAlso
                                                                                           Entity.Type = MediaType AndAlso
                                                                                           (GenderCodes.Count = 0 OrElse
                                                                                            GenderCodes.Contains(Entity.Gender))
                                                                                     Select Entity.AgeFrom).Distinct.ToList
                                                                     Select New AdvantageFramework.DTO.ComboBoxItem(Entity, Entity.ToString)).ToList

                DemographicSetupDetailViewModel.AgeToDatasource = (From Entity In (From Entity In DemographicSetupDetailViewModel.RepositoryNielsenDemographicList
                                                                                   Where Entity.Gender IsNot Nothing AndAlso
                                                                                         Entity.Type = MediaType AndAlso
                                                                                         (GenderCodes.Count = 0 OrElse
                                                                                          GenderCodes.Contains(Entity.Gender)) AndAlso
                                                                                         Entity.AgeFrom.HasValue AndAlso
                                                                                         Entity.AgeFrom >= AgeFromValue
                                                                                   Select Entity.AgeTo).Distinct.ToList
                                                                   Select New AdvantageFramework.DTO.ComboBoxItem(If(Entity.HasValue, Entity.Value.ToString, "+"), If(Entity.HasValue, Entity.Value.ToString, "+"))).ToList

            ElseIf DemographicSetupDetailViewModel.GetMediaDemographicEntity.MediaDemoSourceID = AdvantageFramework.Database.Entities.MediaDemoSourceID.Numeris Then

                DemographicSetupDetailViewModel.NielsenDemographics = New Generic.List(Of AdvantageFramework.Database.Entities.NielsenDemographic)

                DemographicSetupDetailViewModel.AgeFromDatasource = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

                DemographicSetupDetailViewModel.AgeFromDatasource.Add(New AdvantageFramework.DTO.ComboBoxItem("2", "2"))
                DemographicSetupDetailViewModel.AgeFromDatasource.Add(New AdvantageFramework.DTO.ComboBoxItem("12", "12"))
                DemographicSetupDetailViewModel.AgeFromDatasource.Add(New AdvantageFramework.DTO.ComboBoxItem("18", "18"))
                DemographicSetupDetailViewModel.AgeFromDatasource.Add(New AdvantageFramework.DTO.ComboBoxItem("25", "25"))
                DemographicSetupDetailViewModel.AgeFromDatasource.Add(New AdvantageFramework.DTO.ComboBoxItem("35", "35"))
                DemographicSetupDetailViewModel.AgeFromDatasource.Add(New AdvantageFramework.DTO.ComboBoxItem("50", "50"))
                DemographicSetupDetailViewModel.AgeFromDatasource.Add(New AdvantageFramework.DTO.ComboBoxItem("55", "55"))
                DemographicSetupDetailViewModel.AgeFromDatasource.Add(New AdvantageFramework.DTO.ComboBoxItem("60", "60"))
                DemographicSetupDetailViewModel.AgeFromDatasource.Add(New AdvantageFramework.DTO.ComboBoxItem("65", "65"))

                LoadNumerisAgeToDatasource(DemographicSetupDetailViewModel)

            End If

        End Sub
        Private Sub LoadNumerisAgeToDatasource(ByRef DemographicSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel)

            DemographicSetupDetailViewModel.AgeToDatasource = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

            DemographicSetupDetailViewModel.AgeToDatasource.Add(New AdvantageFramework.DTO.ComboBoxItem("11", "11"))
            DemographicSetupDetailViewModel.AgeToDatasource.Add(New AdvantageFramework.DTO.ComboBoxItem("17", "17"))
            DemographicSetupDetailViewModel.AgeToDatasource.Add(New AdvantageFramework.DTO.ComboBoxItem("24", "24"))
            DemographicSetupDetailViewModel.AgeToDatasource.Add(New AdvantageFramework.DTO.ComboBoxItem("34", "34"))
            DemographicSetupDetailViewModel.AgeToDatasource.Add(New AdvantageFramework.DTO.ComboBoxItem("49", "49"))
            DemographicSetupDetailViewModel.AgeToDatasource.Add(New AdvantageFramework.DTO.ComboBoxItem("54", "54"))
            DemographicSetupDetailViewModel.AgeToDatasource.Add(New AdvantageFramework.DTO.ComboBoxItem("59", "59"))
            DemographicSetupDetailViewModel.AgeToDatasource.Add(New AdvantageFramework.DTO.ComboBoxItem("64", "64"))
            DemographicSetupDetailViewModel.AgeToDatasource.Add(New AdvantageFramework.DTO.ComboBoxItem("+", "+"))

        End Sub
        Private Function GenderSelected(DemographicSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel) As Boolean

            'objects
            Dim IsSelected As Boolean = True

            If (DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsChildren OrElse
                    DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsBoys OrElse
                    DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsGirls OrElse
                    DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsMales OrElse
                    DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsFemales OrElse
                    DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsWorkingWomen) = False Then

                IsSelected = False

            End If

            GenderSelected = IsSelected

        End Function

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Add(DemographicSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel,
                            ByRef MediaDemographicID As Integer, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic = Nothing
            Dim MediaDemographicDetail As AdvantageFramework.Database.Entities.MediaDemographicDetail = Nothing
            Dim IsValid As Boolean = True

            If GenderSelected(DemographicSetupDetailViewModel) Then

                MediaDemographic = New AdvantageFramework.Database.Entities.MediaDemographic

                MediaDemographic.Code = DemographicSetupDetailViewModel.GetMediaDemographicEntity.Code
                MediaDemographic.Description = DemographicSetupDetailViewModel.GetMediaDemographicEntity.Description
                MediaDemographic.IsInactive = DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsInactive

                MediaDemographic.MediaDemoSourceID = DemographicSetupDetailViewModel.GetMediaDemographicEntity.MediaDemoSourceID
                MediaDemographic.Type = DemographicSetupDetailViewModel.GetMediaDemographicEntity.Type
                MediaDemographic.IsChildren = DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsChildren
                MediaDemographic.IsBoys = DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsBoys
                MediaDemographic.IsGirls = DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsGirls
                MediaDemographic.IsMales = DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsMales
                MediaDemographic.IsFemales = DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsFemales
                MediaDemographic.IsWorkingWomen = DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsWorkingWomen

                MediaDemographic.AgeFrom = DemographicSetupDetailViewModel.GetMediaDemographicEntity.AgeFrom
                MediaDemographic.AgeTo = DemographicSetupDetailViewModel.GetMediaDemographicEntity.AgeTo

                MediaDemographic.UseForMarket = DemographicSetupDetailViewModel.GetMediaDemographicEntity.UseForMarket
                MediaDemographic.UseForCounty = DemographicSetupDetailViewModel.GetMediaDemographicEntity.UseForCounty

                MediaDemographic.MediaDemographicDetails = DemographicSetupDetailViewModel.GetMediaDemographicEntity.MediaDemographicDetails

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    MediaDemographic.DbContext = DbContext

                    ErrorMessage = MediaDemographic.ValidateEntity(IsValid)

                    If IsValid Then

                        Try

                            DbContext.MediaDemographics.Add(MediaDemographic)

                            DbContext.SaveChanges()

                            Added = True

                            MediaDemographicID = MediaDemographic.ID

                        Catch ex As Exception
                            ErrorMessage = ex.Message & Space(1) & If(ex.InnerException IsNot Nothing AndAlso ex.InnerException.InnerException IsNot Nothing, ex.InnerException.InnerException.Message, "")
                        End Try

                    End If

                End Using

            Else

                ErrorMessage = "Gender is required."

            End If

            Add = Added

        End Function
        Public Function Delete(MediaDemographicID As Integer, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic = Nothing
            Dim Deleted As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaDemographic = DbContext.MediaDemographics.Find(MediaDemographicID)

                If MediaDemographic IsNot Nothing AndAlso Not MediaDemographic.IsSystem Then

                    Try

                        For Each MediaDemographicDetail In MediaDemographic.MediaDemographicDetails.ToList

                            DbContext.Entry(MediaDemographicDetail).State = Entity.EntityState.Deleted

                        Next

                        DbContext.DeleteEntityObject(MediaDemographic)

                        DbContext.SaveChanges()

                        Deleted = True

                    Catch ex As Exception
                        ErrorMessage = ex.Message & Space(1) & If(ex.InnerException IsNot Nothing AndAlso ex.InnerException.InnerException IsNot Nothing, ex.InnerException.InnerException.Message, "")
                    End Try

                End If

            End Using

            Delete = Deleted

        End Function
        Public Function Load(MediaDemographicID As Integer, Type As String, MediaDemoSourceID As AdvantageFramework.Database.Entities.MediaDemoSourceID) As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel

            Dim DemographicSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel = Nothing

            DemographicSetupDetailViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If MediaDemoSourceID = AdvantageFramework.Database.Entities.MediaDemoSourceID.Nielsen Then

                    DemographicSetupDetailViewModel.RepositoryNielsenDemographicList = AdvantageFramework.Database.Procedures.NielsenDemographic.LoadByType(DbContext, Type).ToList

                Else

                    DemographicSetupDetailViewModel.RepositoryNielsenDemographicList = New Generic.List(Of AdvantageFramework.Database.Entities.NielsenDemographic)

                End If

                If MediaDemographicID <> 0 Then

                    DemographicSetupDetailViewModel.MediaDemographic = DbContext.GetQuery(Of Database.Entities.MediaDemographic).Include("MediaDemographicDetails").Where(Function(MD) MD.ID = MediaDemographicID).SingleOrDefault

                    SetNielsenDemographics(DemographicSetupDetailViewModel, True)

                Else

                    DemographicSetupDetailViewModel.MediaDemographic = New AdvantageFramework.Database.Entities.MediaDemographic

                    DemographicSetupDetailViewModel.MediaDemographic.Type = Type
                    DemographicSetupDetailViewModel.MediaDemographic.MediaDemoSourceID = MediaDemoSourceID

                    SetNielsenDemographics(DemographicSetupDetailViewModel, False)

                End If

            End Using

            Load = DemographicSetupDetailViewModel

        End Function
        Public Sub SetDemoDetailsBasedOnAge(ByRef DemographicSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel,
                                            RefreshAgoToDataSource As Boolean, AgeFrom As String, CurrentAgeTo As String)

            Dim GenderCodes As Generic.List(Of String) = Nothing

            GenderCodes = GetGenderCodes(DemographicSetupDetailViewModel)

            If Not String.IsNullOrWhiteSpace(AgeFrom) Then

                DemographicSetupDetailViewModel.GetMediaDemographicEntity.AgeFrom = CShort(AgeFrom)

            Else

                DemographicSetupDetailViewModel.GetMediaDemographicEntity.AgeFrom = Nothing

            End If

            If Not String.IsNullOrWhiteSpace(CurrentAgeTo) AndAlso CurrentAgeTo <> "+" Then

                DemographicSetupDetailViewModel.GetMediaDemographicEntity.AgeTo = CShort(CurrentAgeTo)

            Else

                DemographicSetupDetailViewModel.GetMediaDemographicEntity.AgeTo = Nothing

            End If

            SetNielsenDemographics(DemographicSetupDetailViewModel, True)

            If RefreshAgoToDataSource Then

                If DemographicSetupDetailViewModel.GetMediaDemographicEntity.MediaDemoSourceID = AdvantageFramework.Database.Entities.MediaDemoSourceID.Nielsen Then

                    DemographicSetupDetailViewModel.AgeToDatasource = (From Entity In (From Entity In DemographicSetupDetailViewModel.NielsenDemographics
                                                                                       Where Entity.AgeFrom.HasValue AndAlso
                                                                                             Entity.AgeFrom >= CShort(AgeFrom)
                                                                                       Select Entity.AgeTo).Distinct.ToList
                                                                       Select New AdvantageFramework.DTO.ComboBoxItem(If(Entity.HasValue, Entity.Value.ToString, "+"), If(Entity.HasValue, Entity.Value.ToString, "+"))).ToList

                ElseIf DemographicSetupDetailViewModel.GetMediaDemographicEntity.MediaDemoSourceID = AdvantageFramework.Database.Entities.MediaDemoSourceID.Numeris Then

                    LoadNumerisAgeToDatasource(DemographicSetupDetailViewModel)

                    DemographicSetupDetailViewModel.AgeToDatasource = DemographicSetupDetailViewModel.AgeToDatasource.Where(Function(Entity) Entity.Value > AgeFrom OrElse Entity.Value = "+").ToList

                End If

            End If

            If Not String.IsNullOrWhiteSpace(AgeFrom) Then

                If DemographicSetupDetailViewModel.GetMediaDemographicEntity.MediaDemoSourceID = AdvantageFramework.Database.Entities.MediaDemoSourceID.Numeris Then

                    DemographicSetupDetailViewModel.GetMediaDemographicEntity.Code = "N" & DemographicSetupDetailViewModel.GetMediaDemographicEntity.Type &
                                                                                     String.Join("", GenderCodes.ToArray) & AgeFrom & If(CurrentAgeTo = "+", "", CurrentAgeTo)

                Else
                    DemographicSetupDetailViewModel.GetMediaDemographicEntity.Code = DemographicSetupDetailViewModel.GetMediaDemographicEntity.Type &
                                                                                     String.Join("", GenderCodes.ToArray) & AgeFrom & If(CurrentAgeTo = "+", "", CurrentAgeTo)

                End If

            End If

        End Sub
        Public Function Update(DemographicSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel,
                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim IsValid As Boolean = True
            Dim Saved As Boolean = False

            If GenderSelected(DemographicSetupDetailViewModel) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    MediaDemographic = DbContext.MediaDemographics.Find(DemographicSetupDetailViewModel.GetMediaDemographicEntity.ID)

                    If MediaDemographic IsNot Nothing Then


                        MediaDemographic.DbContext = DbContext

                        MediaDemographic.Code = DemographicSetupDetailViewModel.GetMediaDemographicEntity.Code
                        MediaDemographic.Description = DemographicSetupDetailViewModel.GetMediaDemographicEntity.Description
                        MediaDemographic.IsInactive = DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsInactive

                        MediaDemographic.Type = DemographicSetupDetailViewModel.GetMediaDemographicEntity.Type
                        MediaDemographic.IsChildren = DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsChildren
                        MediaDemographic.IsBoys = DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsBoys
                        MediaDemographic.IsGirls = DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsGirls
                        MediaDemographic.IsMales = DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsMales
                        MediaDemographic.IsFemales = DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsFemales
                        MediaDemographic.IsWorkingWomen = DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsWorkingWomen

                        MediaDemographic.AgeFrom = DemographicSetupDetailViewModel.GetMediaDemographicEntity.AgeFrom
                        MediaDemographic.AgeTo = DemographicSetupDetailViewModel.GetMediaDemographicEntity.AgeTo

                        MediaDemographic.UseForCounty = DemographicSetupDetailViewModel.GetMediaDemographicEntity.UseForCounty
                        MediaDemographic.UseForMarket = DemographicSetupDetailViewModel.GetMediaDemographicEntity.UseForMarket

                        Try

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_DEMO_DETAIL WHERE MEDIA_DEMO_ID = {0}", MediaDemographic.ID))

                            MediaDemographic.MediaDemographicDetails.Clear()

                            MediaDemographic.MediaDemographicDetails = DemographicSetupDetailViewModel.GetMediaDemographicEntity.MediaDemographicDetails

                            ErrorMessage = MediaDemographic.ValidateEntity(IsValid)

                            If IsValid Then

                                DbContext.SaveChanges()

                                DbTransaction.Commit()

                                Saved = True

                            End If

                        Catch ex As Exception
                            DbTransaction.Rollback()
                            ErrorMessage = ex.Message & Space(1) & If(ex.InnerException IsNot Nothing AndAlso ex.InnerException.InnerException IsNot Nothing, ex.InnerException.InnerException.Message, "")
                        Finally

                            If DbContext.Database.Connection.State = ConnectionState.Open Then

                                DbContext.Database.Connection.Close()

                            End If

                        End Try

                    Else

                        ErrorMessage = "The demographic you are trying to update no longer exists."

                    End If

                End Using

            Else

                ErrorMessage = "Gender is required."

            End If

            Update = Saved

        End Function
        Public Sub UpdateGenderChecked(DemographicSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel, Gender As String, Checked As Boolean)

            Select Case Gender

                Case "B"

                    DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsBoys = Checked

                Case "G"

                    DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsGirls = Checked

                Case "M"

                    DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsMales = Checked

                Case "F"

                    DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsFemales = Checked

                Case "C"

                    DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsChildren = Checked

                Case "W"

                    DemographicSetupDetailViewModel.GetMediaDemographicEntity.IsWorkingWomen = Checked

            End Select

            SetNielsenDemographics(DemographicSetupDetailViewModel, False)

            If DemographicSetupDetailViewModel.GetMediaDemographicEntity.MediaDemoSourceID = AdvantageFramework.Database.Entities.MediaDemoSourceID.Nielsen Then

                DemographicSetupDetailViewModel.AgeToDatasource = (From Entity In (From Entity In DemographicSetupDetailViewModel.NielsenDemographics
                                                                                   Select Entity.AgeTo).Distinct.ToList
                                                                   Select New AdvantageFramework.DTO.ComboBoxItem(If(Entity.HasValue, Entity.Value.ToString, "+"), If(Entity.HasValue, Entity.Value.ToString, "+"))).ToList

            End If

            DemographicSetupDetailViewModel.GetMediaDemographicEntity.AgeTo = Nothing

            If DemographicSetupDetailViewModel.GetMediaDemographicEntity.MediaDemoSourceID = AdvantageFramework.Database.Entities.MediaDemoSourceID.Nielsen Then

                DemographicSetupDetailViewModel.AgeFromDatasource = (From Entity In (From Entity In DemographicSetupDetailViewModel.NielsenDemographics
                                                                                     Select Entity.AgeFrom).Distinct.ToList
                                                                     Select New AdvantageFramework.DTO.ComboBoxItem(Entity, Entity.ToString)).ToList

            End If

            DemographicSetupDetailViewModel.GetMediaDemographicEntity.AgeFrom = Nothing

        End Sub
        Public Sub UpdateUseForMarket(DemographicSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel, Checked As Boolean)

            DemographicSetupDetailViewModel.GetMediaDemographicEntity.UseForMarket = Checked

        End Sub

#End Region

#End Region

    End Class

End Namespace
