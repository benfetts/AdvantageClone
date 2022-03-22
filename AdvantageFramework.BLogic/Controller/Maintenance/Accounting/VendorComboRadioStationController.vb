Namespace Controller.Maintenance.Accounting

    Public Class VendorComboRadioStationController
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
        Public Function Load(VendorCode As String) As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorComboRadioStationViewModel

            'objects
            Dim VendorComboRadioStationViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorComboRadioStationViewModel = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorComboRadioStations As Generic.List(Of AdvantageFramework.Database.Entities.VendorComboRadioStation) = Nothing
            Dim VendorComboRadioStation As AdvantageFramework.Database.Entities.VendorComboRadioStation = Nothing
            Dim VendorComboStation As AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation = Nothing
            Dim NielsenRadioStationList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation) = Nothing
            Dim NielsenRadioMarketNumber As Integer = 0

            VendorComboRadioStationViewModel = New AdvantageFramework.ViewModels.Maintenance.Accounting.VendorComboRadioStationViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                VendorComboRadioStationViewModel.VendorCode = VendorCode

                Vendor = DbContext.Vendors.Include("VendorComboRadioStations").Include("Market").SingleOrDefault(Function(Entity) Entity.Code = VendorCode)

                Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Me.Session.NielsenConnectionString, Me.Session.UserCode)

                    If Vendor.Market IsNot Nothing Then

                        If IsNumeric(Vendor.Market.NielsenRadioCode) Then

                            NielsenRadioMarketNumber = CInt(Vendor.Market.NielsenRadioCode)

                        End If

                        NielsenRadioStationList = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.LoadByRadioSource(NielsenDbContext, Nielsen.Database.Entities.RadioSource.Nielsen)
                                                   Where Entity.NielsenRadioMarketNumber = NielsenRadioMarketNumber
                                                   Select Entity).OrderBy(Function(Entity) Entity.CallLetters).ToList

                    End If

                End Using

                If NielsenRadioStationList Is Nothing Then

                    NielsenRadioStationList = New Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation)

                End If

                VendorComboRadioStations = Vendor.VendorComboRadioStations.ToList

                VendorComboRadioStationViewModel.Vendors = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation)

                VendorComboRadioStationViewModel.AvailableVendors = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation)
                VendorComboRadioStationViewModel.SelectedVendors = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation)

                For Each NielsenRadioStation In NielsenRadioStationList

                    VendorComboRadioStation = Nothing
                    VendorComboStation = Nothing

                    Try

                        VendorComboRadioStation = VendorComboRadioStations.SingleOrDefault(Function(Entity) Entity.NielsenRadioStationID = NielsenRadioStation.ComboID)

                    Catch ex As Exception
                        VendorComboRadioStation = Nothing
                    End Try

                    If VendorComboRadioStation IsNot Nothing Then

                        VendorComboStation = New AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation(VendorComboRadioStation, NielsenRadioStation)

                        VendorComboRadioStationViewModel.SelectedVendors.Add(VendorComboStation)

                    Else

                        VendorComboStation = New AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation(Vendor, NielsenRadioStation)

                        VendorComboRadioStationViewModel.AvailableVendors.Add(VendorComboStation)

                    End If

                    If VendorComboStation IsNot Nothing Then

                        VendorComboRadioStationViewModel.Vendors.Add(VendorComboStation)

                    End If

                Next

            End Using

            RefreshAllEnabled(VendorComboRadioStationViewModel)

            Load = VendorComboRadioStationViewModel

        End Function
        Public Function Save(ByRef VendorComboRadioStationViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorComboRadioStationViewModel,
                             ByRef ErrorMessage As String) As Boolean

            Dim Saved As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim VendorComboRadioStation As AdvantageFramework.Database.Entities.VendorComboRadioStation = Nothing
            Dim SelectedVendorComboRadioStation As AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation = Nothing
            Dim AvailableVendorComboRadioStation As AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation = Nothing
            Dim VendorCode As String = String.Empty

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    VendorCode = VendorComboRadioStationViewModel.VendorCode

                    For Each SelectedVendorComboRadioStation In VendorComboRadioStationViewModel.SelectedVendors

                        If SelectedVendorComboRadioStation.ID = 0 Then

                            VendorComboRadioStation = New AdvantageFramework.Database.Entities.VendorComboRadioStation

                            SelectedVendorComboRadioStation.SaveToEntity(VendorComboRadioStation)

                            DbContext.VendorComboRadioStations.Add(VendorComboRadioStation)

                        End If

                    Next

                    For Each AvailableVendorComboRadioStation In VendorComboRadioStationViewModel.AvailableVendors

                        If AvailableVendorComboRadioStation.ID > 0 Then

                            VendorComboRadioStation = DbContext.VendorComboRadioStations.Find(AvailableVendorComboRadioStation.ID)

                            If VendorComboRadioStation IsNot Nothing Then

                                DbContext.VendorComboRadioStations.Remove(VendorComboRadioStation)

                            End If

                        End If

                    Next

                    DbContext.Configuration.AutoDetectChangesEnabled = True
                    DbContext.SaveChanges()

                    DbTransaction.Commit()

                    Saved = True

                Catch ex As Exception
                    DbTransaction.Rollback()
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    ErrorMessage += System.Environment.NewLine & ex.Message
                    Saved = False
                End Try

            End Using

            Save = Saved

        End Function
        Public Sub AvailableVendorsSelectedChanged(ByRef VendorComboRadioStationViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorComboRadioStationViewModel,
                                                   AvailableVendors As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation))

            If AvailableVendors IsNot Nothing Then

                If AvailableVendors.Count > 0 Then

                    VendorComboRadioStationViewModel.AddEnabled = True

                Else

                    VendorComboRadioStationViewModel.AddEnabled = False

                End If

            Else

                VendorComboRadioStationViewModel.AddEnabled = False

            End If

        End Sub
        Public Sub SelectedVendorsSelectedChanged(ByRef VendorComboRadioStationViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorComboRadioStationViewModel,
                                                                   SelectedVendors As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation))

            If SelectedVendors IsNot Nothing Then

                If SelectedVendors.Count > 0 Then

                    VendorComboRadioStationViewModel.RemoveEnabled = True

                Else

                    VendorComboRadioStationViewModel.RemoveEnabled = False

                End If

            Else

                VendorComboRadioStationViewModel.RemoveEnabled = False

            End If

        End Sub
        Public Sub AddVendors(ByRef VendorComboRadioStationViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorComboRadioStationViewModel,
                              AvailableVendors As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation))

            If AvailableVendors IsNot Nothing AndAlso AvailableVendors.Count > 0 Then

                For Each AvailableVendor In AvailableVendors

                    VendorComboRadioStationViewModel.AvailableVendors.Remove(AvailableVendor)
                    VendorComboRadioStationViewModel.SelectedVendors.Add(AvailableVendor)

                Next

            End If

            RefreshAllEnabled(VendorComboRadioStationViewModel)

        End Sub
        Public Sub AddAllVendors(ByRef VendorComboRadioStationViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorComboRadioStationViewModel)

            For Each AvailableVendor In VendorComboRadioStationViewModel.AvailableVendors.ToList

                VendorComboRadioStationViewModel.AvailableVendors.Remove(AvailableVendor)
                VendorComboRadioStationViewModel.SelectedVendors.Add(AvailableVendor)

            Next

            RefreshAllEnabled(VendorComboRadioStationViewModel)

        End Sub
        Public Sub RemoveVendors(ByRef VendorComboRadioStationViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorComboRadioStationViewModel,
                                                   SelectedVendors As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation))

            If SelectedVendors IsNot Nothing AndAlso SelectedVendors.Count > 0 Then

                For Each SelectedVendor In SelectedVendors

                    VendorComboRadioStationViewModel.SelectedVendors.Remove(SelectedVendor)
                    VendorComboRadioStationViewModel.AvailableVendors.Add(SelectedVendor)

                Next

            End If

            RefreshAllEnabled(VendorComboRadioStationViewModel)

        End Sub
        Public Sub RemoveAllVendors(ByRef VendorComboRadioStationViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorComboRadioStationViewModel)

            For Each SelectedVendor In VendorComboRadioStationViewModel.SelectedVendors.ToList

                VendorComboRadioStationViewModel.SelectedVendors.Remove(SelectedVendor)
                VendorComboRadioStationViewModel.AvailableVendors.Add(SelectedVendor)

            Next

            RefreshAllEnabled(VendorComboRadioStationViewModel)

        End Sub
        Private Sub RefreshAllEnabled(ByRef VendorComboRadioStationViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorComboRadioStationViewModel)

            If VendorComboRadioStationViewModel.AvailableVendors.Count = 0 Then

                VendorComboRadioStationViewModel.AddAllEnabled = False

            Else

                VendorComboRadioStationViewModel.AddAllEnabled = True

            End If

            If VendorComboRadioStationViewModel.SelectedVendors.Count = 0 Then

                VendorComboRadioStationViewModel.RemoveAllEnabled = False

            Else

                VendorComboRadioStationViewModel.RemoveAllEnabled = True

            End If

        End Sub

#End Region

    End Class

End Namespace
