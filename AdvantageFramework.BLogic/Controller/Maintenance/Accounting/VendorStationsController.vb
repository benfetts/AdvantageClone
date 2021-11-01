Namespace Controller.Maintenance.Accounting

    Public Class VendorStationsController
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

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorStationsViewModel

            'objects
            Dim VendorStationsViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorStationsViewModel = Nothing
            Dim NielsenRadioStation As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation = Nothing
            Dim NielsenTVStation As AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation = Nothing

            VendorStationsViewModel = New AdvantageFramework.ViewModels.Maintenance.Accounting.VendorStationsViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                VendorStationsViewModel.VendorStations = (From Vendor In AdvantageFramework.Database.Procedures.Vendor.LoadWithOfficeLimits(DbContext, Me.Session).Include("Market")
                                                          Where Vendor.VendorCategory = "T" OrElse
                                                                Vendor.VendorCategory = "R").ToList.Select(Function(Entity) New AdvantageFramework.DTO.VendorStation(Entity)).ToList

                VendorStationsViewModel.RepositoryMarkets = AdvantageFramework.Database.Procedures.Market.LoadAllActive(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Market(Entity)).ToList

                Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Me.Session.NielsenConnectionString, Nothing)

                    If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                        VendorStationsViewModel.RepositoryNCCTVSyscodes = AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.GetSyscodesByMarketHosted(NielsenDbContext, Session.NielsenClientCodeForHosted, Nothing)

                    Else

                        VendorStationsViewModel.RepositoryNCCTVSyscodes = AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.GetSyscodesByMarket(NielsenDbContext, Nothing)

                    End If

                    VendorStationsViewModel.RepositoryNielsenRadioStations.AddRange(AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.LoadByRadioSource(NielsenDbContext, Nielsen.Database.Entities.RadioSource.Nielsen).ToList)

                    VendorStationsViewModel.RepositoryNielsenTVStations.AddRange(AdvantageFramework.Nielsen.Database.Procedures.NielsenTVStation.Load(NielsenDbContext).ToList)

                End Using

            End Using

            'match to only those vendors where the Radio or TV station is blank
            For Each VendorStation In VendorStationsViewModel.VendorStations

                If VendorStation.VendorCategory = "R" AndAlso String.IsNullOrWhiteSpace(VendorStation.MarketCode) = False AndAlso VendorStation.NielsenRadioStationComboID.HasValue = False Then

                    If VendorStation.Market IsNot Nothing AndAlso IsNumeric(VendorStation.Market.NielsenRadioCode) Then

                        NielsenRadioStation = Nothing

                        If (From Entity In VendorStationsViewModel.RepositoryNielsenRadioStations
                            Where Entity.NielsenRadioMarketNumber = CInt(VendorStation.Market.NielsenRadioCode) AndAlso
                                  Entity.Name.Replace("-", "").Replace(" ", "").ToUpper = VendorStation.Code.ToUpper).Count = 1 Then

                            NielsenRadioStation = (From Entity In VendorStationsViewModel.RepositoryNielsenRadioStations
                                                   Where Entity.NielsenRadioMarketNumber = CInt(VendorStation.Market.NielsenRadioCode) AndAlso
                                                         Entity.Name.Replace("-", "").Replace(" ", "").ToUpper = VendorStation.Code.ToUpper).Single

                            VendorStation.NielsenRadioStationComboID = NielsenRadioStation.ComboID
                            VendorStationsViewModel.SaveEnabled = True

                        ElseIf (From Entity In VendorStationsViewModel.RepositoryNielsenRadioStations
                                Where Entity.NielsenRadioMarketNumber = CInt(VendorStation.Market.NielsenRadioCode) AndAlso
                                      Entity.Name.ToUpper = VendorStation.Name.ToUpper).Count = 1 Then

                            NielsenRadioStation = (From Entity In VendorStationsViewModel.RepositoryNielsenRadioStations
                                                   Where Entity.NielsenRadioMarketNumber = CInt(VendorStation.Market.NielsenRadioCode) AndAlso
                                                         Entity.Name.ToUpper = VendorStation.Name.ToUpper).Single

                            VendorStation.NielsenRadioStationComboID = NielsenRadioStation.ComboID
                            VendorStationsViewModel.SaveEnabled = True

                        End If

                    End If

                ElseIf VendorStation.VendorCategory = "T" AndAlso Not VendorStation.IsCableSystem AndAlso String.IsNullOrWhiteSpace(VendorStation.MarketCode) = False AndAlso VendorStation.NielsenTVStationCode.HasValue = False Then

                    If VendorStation.Market IsNot Nothing AndAlso IsNumeric(VendorStation.Market.NielsenTVCode) Then

                        NielsenTVStation = Nothing

                        If (From Entity In VendorStationsViewModel.RepositoryNielsenTVStations
                            Where Entity.NielsenMarketNumber = CInt(VendorStation.Market.NielsenTVCode) AndAlso
                                  Entity.CallLetters.Replace("-", "").Replace(" ", "").ToUpper = VendorStation.Code.ToUpper).Count = 1 Then

                            NielsenTVStation = (From Entity In VendorStationsViewModel.RepositoryNielsenTVStations
                                                Where Entity.NielsenMarketNumber = CInt(VendorStation.Market.NielsenTVCode) AndAlso
                                                      Entity.CallLetters.Replace("-", "").Replace(" ", "").ToUpper = VendorStation.Code.ToUpper).Single

                            VendorStation.NielsenTVStationCode = NielsenTVStation.StationCode
                            VendorStationsViewModel.SaveEnabled = True

                        ElseIf (From Entity In VendorStationsViewModel.RepositoryNielsenTVStations
                                Where Entity.NielsenMarketNumber = CInt(VendorStation.Market.NielsenTVCode) AndAlso
                                      Entity.CallLetters.ToUpper = VendorStation.Name.ToUpper).Count = 1 Then

                            NielsenTVStation = (From Entity In VendorStationsViewModel.RepositoryNielsenTVStations
                                                Where Entity.NielsenMarketNumber = CInt(VendorStation.Market.NielsenTVCode) AndAlso
                                                      Entity.CallLetters.ToUpper = VendorStation.Name.ToUpper).Single

                            VendorStation.NielsenTVStationCode = NielsenTVStation.StationCode
                            VendorStationsViewModel.SaveEnabled = True

                        Else

                            For Each NielsenTVStation In VendorStationsViewModel.RepositoryNielsenTVStations.Where(Function(Entity) Entity.NielsenMarketNumber = CInt(VendorStation.Market.NielsenTVCode)).ToList

                                If NielsenTVStation.CallLetters.StartsWith(VendorStation.Name) Then

                                    VendorStation.NielsenTVStationCode = NielsenTVStation.StationCode
                                    VendorStationsViewModel.SaveEnabled = True

                                ElseIf NielsenTVStation.CallLetters.StartsWith(VendorStation.Name.Replace("-TV", "").Replace(" TV", "")) Then

                                    VendorStation.NielsenTVStationCode = NielsenTVStation.StationCode
                                    VendorStationsViewModel.SaveEnabled = True

                                End If

                            Next

                        End If

                    End If

                End If

            Next

            Load = VendorStationsViewModel

        End Function
        Public Function GetNielsenRadioStations(MarketCode As String) As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation)

            'objects
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim NielsenRadioStations As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation) = Nothing

            NielsenRadioStations = New Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MarketCode)

            End Using

            If Market IsNot Nothing AndAlso IsNumeric(Market.NielsenRadioCode) Then

                Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Me.Session.NielsenConnectionString, Nothing)

                    NielsenRadioStations.AddRange(AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.LoadByNielsenRadioMarketNumberRadioSource(NielsenDbContext, CInt(Market.NielsenRadioCode), Nielsen.Database.Entities.RadioSource.Nielsen).OrderBy(Function(E) E.Name).ToList)

                End Using

            End If

            GetNielsenRadioStations = NielsenRadioStations

        End Function
        Public Function GetNielsenTVStations(MarketCode As String) As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation)

            'objects
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim NielsenTVStations As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation) = Nothing

            NielsenTVStations = New Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MarketCode)

            End Using

            If Market IsNot Nothing AndAlso IsNumeric(Market.NielsenTVCode) Then

                Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Me.Session.NielsenConnectionString, Nothing)

                    NielsenTVStations.AddRange(AdvantageFramework.Nielsen.Database.Procedures.NielsenTVStation.LoadByNielsenMarketNumberAndSourceType(NielsenDbContext, CInt(Market.NielsenTVCode), "B").OrderBy(Function(E) E.CallLetters).ToList)

                End Using

            End If

            GetNielsenTVStations = NielsenTVStations

        End Function
        Public Function GetNCCTVSyscodes(MarketCode As String) As Generic.List(Of AdvantageFramework.Nielsen.Database.Classes.NCCTVSyscode)

            'objects
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim NCCTVSyscodeList As Generic.List(Of AdvantageFramework.Nielsen.Database.Classes.NCCTVSyscode) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MarketCode)

                If Market IsNot Nothing AndAlso IsNumeric(Market.NielsenTVCode) Then

                    Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Me.Session.NielsenConnectionString, Nothing)

                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                            NCCTVSyscodeList = AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.GetSyscodesByMarketHosted(NielsenDbContext, Session.NielsenClientCodeForHosted, Market.NielsenTVCode)

                        Else

                            NCCTVSyscodeList = AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.GetSyscodesByMarket(NielsenDbContext, Market.NielsenTVCode)

                        End If

                    End Using

                End If

            End Using

            GetNCCTVSyscodes = NCCTVSyscodeList

        End Function
        Public Function Save(ByRef VendorStationsViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorStationsViewModel,
                             ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim Vendors As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    DbContext.Configuration.AutoDetectChangesEnabled = False

                    Vendors = DbContext.Vendors.Where(Function(Entity) Entity.VendorCategory = "R" OrElse Entity.VendorCategory = "T").ToList

                    For Each VendorStation In VendorStationsViewModel.VendorStations

                        Vendor = Vendors.SingleOrDefault(Function(Entity) Entity.Code = VendorStation.Code)

                        If Vendor IsNot Nothing Then

                            Vendor.MarketCode = VendorStation.MarketCode
                            Vendor.IsCableSystem = VendorStation.IsCableSystem
                            Vendor.NCCTVSyscodeID = VendorStation.NCCTVSyscodeID
                            Vendor.NielsenRadioStationComboID = VendorStation.NielsenRadioStationComboID
                            Vendor.NielsenTVStationCode = VendorStation.NielsenTVStationCode
                            DbContext.Entry(Vendor).State = Entity.EntityState.Modified

                        End If

                    Next

                    DbContext.SaveChanges()

                    DbContext.Configuration.AutoDetectChangesEnabled = True

                    Saved = True

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message & vbCrLf & If(ex.InnerException IsNot Nothing, ex.InnerException.Message, "")
            End Try

            Save = Saved

        End Function
        Public Sub UserEntryChanged(ByRef VendorStationsViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorStationsViewModel)

            VendorStationsViewModel.SaveEnabled = True

        End Sub
        Public Sub ClearChanged(ByRef VendorStationsViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorStationsViewModel)

            VendorStationsViewModel.SaveEnabled = False

        End Sub

#End Region

    End Class

End Namespace
