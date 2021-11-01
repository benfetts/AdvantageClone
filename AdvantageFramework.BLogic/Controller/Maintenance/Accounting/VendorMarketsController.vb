Namespace Controller.Maintenance.Accounting

    Public Class VendorMarketsController
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
        Public Function Load(VendorCode As String, MarketCode As String) As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorMarketsViewModel

            'objects
            Dim VendorMarketsViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorMarketsViewModel = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorMarket As AdvantageFramework.Database.Entities.VendorMarket = Nothing

            VendorMarketsViewModel = New AdvantageFramework.ViewModels.Maintenance.Accounting.VendorMarketsViewModel
            VendorMarketsViewModel.MarketCode = MarketCode

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Vendor = DbContext.Vendors.Find(VendorCode)

                If (From Entity In DbContext.GetQuery(Of Database.Entities.VendorMarket)
                    Where Entity.VendorCode = VendorCode AndAlso
                          Entity.MarketCode = MarketCode).Any = False Then

                    VendorMarket = New AdvantageFramework.Database.Entities.VendorMarket
                    VendorMarket.DbContext = DbContext
                    VendorMarket.VendorCode = VendorCode
                    VendorMarket.MarketCode = MarketCode

                    DbContext.Entry(VendorMarket).State = Entity.EntityState.Added
                    DbContext.SaveChanges()

                End If

                DbContext.Entry(Vendor).Reference("Market").Load()
                DbContext.Entry(Vendor).Collection("VendorMarkets").Load()

                VendorMarketsViewModel.VendorCode = VendorCode
                VendorMarketsViewModel.Vendor = New AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Vendor(Vendor)

                VendorMarketsViewModel.VendorMarkets = Vendor.VendorMarkets.Select(Function(Entity) New AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorMarket(Entity)).ToList
                VendorMarketsViewModel.VendorMarkets = VendorMarketsViewModel.VendorMarkets.OrderBy(Function(Entity) Entity.Order).ToList
                VendorMarketsViewModel.SelectedVendorMarket = Nothing

                VendorMarketsViewModel.Markets = DbContext.Markets.Where(Function(Entity) Entity.CountryID = VendorMarketsViewModel.Vendor.MarketCountryID).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Market(Entity)).ToList

                VendorMarketsViewModel.Markets = VendorMarketsViewModel.Markets.Where(Function(Entity) Entity.IsInactive = False).ToList

                VendorMarketsViewModel.SaveEnabled = True
                VendorMarketsViewModel.CancelEnabled = True

                VendorMarketsViewModel.IsNewRow = False
                VendorMarketsViewModel.MarketCancelEnabled = False
                VendorMarketsViewModel.MarketMoveUpEnabled = False
                VendorMarketsViewModel.MarketMoveDownEnabled = False

            End Using

            Load = VendorMarketsViewModel

        End Function
        Public Function Save(ByRef VendorMarketsViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorMarketsViewModel,
                             ByRef ErrorMessage As String) As Boolean

            Dim Saved As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorMarket As AdvantageFramework.Database.Entities.VendorMarket = Nothing
            Dim VendorMarkets As Generic.List(Of AdvantageFramework.Database.Entities.VendorMarket) = Nothing
            Dim VendorMarketIDs As Generic.List(Of Integer) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    Vendor = DbContext.Vendors.Find(VendorMarketsViewModel.Vendor.Code)

                    VendorMarketsViewModel.Vendor.SaveToEntity(Vendor)

                    VendorMarkets = DbContext.VendorMarkets.Where(Function(Entity) Entity.VendorCode = Vendor.Code).ToList

                    VendorMarketIDs = New Generic.List(Of Integer)

                    For Each SSubmarket In VendorMarketsViewModel.VendorMarkets.ToList

                        SSubmarket.Order = VendorMarketsViewModel.VendorMarkets.IndexOf(SSubmarket)

                    Next

                    For Each SSubmarket In VendorMarketsViewModel.VendorMarkets

                        If SSubmarket.ID = 0 Then

                            VendorMarket = New AdvantageFramework.Database.Entities.VendorMarket

                            VendorMarket.VendorCode = Vendor.Code

                            DbContext.VendorMarkets.Add(VendorMarket)

                        Else

                            Try

                                VendorMarket = VendorMarkets.FirstOrDefault(Function(Entity) Entity.ID = SSubmarket.ID)

                            Catch ex As Exception
                                VendorMarket = Nothing
                            End Try

                            If VendorMarket Is Nothing Then

                                Throw New Exception("Failed to find Vendor submarket.")

                            End If

                        End If

                        SSubmarket.SaveToEntity(VendorMarket)

                        VendorMarketIDs.Add(VendorMarket.ID)

                    Next

                    VendorMarketIDs = VendorMarketIDs.Distinct.ToList

                    If VendorMarketIDs.Contains(0) Then

                        VendorMarketIDs.Remove(0)

                    End If

                    For Each SSubmarket In VendorMarkets.ToList.Where(Function(Entity) VendorMarketIDs.Contains(Entity.ID) = False)

                        DbContext.VendorMarkets.Remove(SSubmarket)

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
        Public Function LoadMarkets(ByRef VendorMarketsViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorMarketsViewModel) As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Market)

            'objects
            Dim Markets As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Market) = Nothing
            Dim MarketCodes As Generic.List(Of String) = Nothing

            Markets = VendorMarketsViewModel.Markets.Where(Function(Entity) Entity.IsInactive = False AndAlso Entity.CountryID = DTO.Countries.Canada).ToList

            MarketCodes = VendorMarketsViewModel.VendorMarkets.Select(Function(Entity) Entity.MarketCode).ToList

            MarketCodes.Add(VendorMarketsViewModel.Vendor.MarketCode)

            Markets = Markets.Where(Function(Entity) MarketCodes.Contains(Entity.Code) = False).ToList

            LoadMarkets = Markets

        End Function
        Public Sub SelectionChanged(ByRef VendorMarketsViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorMarketsViewModel,
                                    IsNewRow As Boolean,
                                    SelectedVendorMarket As AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorMarket)

            VendorMarketsViewModel.IsNewRow = IsNewRow
            VendorMarketsViewModel.MarketCancelEnabled = IsNewRow
            VendorMarketsViewModel.MarketMoveUpEnabled = Not IsNewRow
            VendorMarketsViewModel.MarketMoveDownEnabled = Not IsNewRow

            VendorMarketsViewModel.SelectedVendorMarket = SelectedVendorMarket

            If VendorMarketsViewModel.MarketMoveUpEnabled AndAlso VendorMarketsViewModel.SelectedVendorMarket Is Nothing Then

                VendorMarketsViewModel.MarketMoveUpEnabled = False

            End If

            If VendorMarketsViewModel.MarketMoveDownEnabled AndAlso VendorMarketsViewModel.SelectedVendorMarket Is Nothing Then

                VendorMarketsViewModel.MarketMoveDownEnabled = False

            End If

        End Sub
        'Public Sub HomeMarketSelectionChanged(ByRef VendorMarketsViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorMarketsViewModel,
        '                                      MarketCode As String)

        '    If String.IsNullOrWhiteSpace(MarketCode) = False Then

        '        VendorMarketsViewModel.Vendor.MarketCode = MarketCode

        '        For Each VendorMarket In VendorMarketsViewModel.VendorMarkets.ToList

        '            If VendorMarket.MarketCode = MarketCode Then

        '                VendorMarketsViewModel.VendorMarkets.Remove(VendorMarket)

        '            End If

        '        Next

        '        For Each VendorMarket In VendorMarketsViewModel.VendorMarkets.ToList

        '            VendorMarket.Order = VendorMarketsViewModel.VendorMarkets.IndexOf(VendorMarket)

        '        Next

        '    End If

        'End Sub
        Public Sub InitNewRowEvent(ByRef VendorMarketsViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorMarketsViewModel,
                                   VendorMarket As AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorMarket)

            VendorMarket.VendorCode = VendorMarketsViewModel.VendorCode

            VendorMarketsViewModel.IsNewRow = True
            VendorMarketsViewModel.MarketCancelEnabled = True
            VendorMarketsViewModel.MarketMoveUpEnabled = False
            VendorMarketsViewModel.MarketMoveDownEnabled = False

        End Sub
        Public Sub CancelNewItemRow(ByRef VendorMarketsViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorMarketsViewModel)

            VendorMarketsViewModel.IsNewRow = False
            VendorMarketsViewModel.MarketCancelEnabled = False
            VendorMarketsViewModel.MarketMoveUpEnabled = VendorMarketsViewModel.HasASelectedVendorMarket
            VendorMarketsViewModel.MarketMoveDownEnabled = VendorMarketsViewModel.HasASelectedVendorMarket

        End Sub
        Public Sub AddMarket(ByRef VendorMarketsViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorMarketsViewModel,
                             VendorMarket As AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorMarket)

            VendorMarketsViewModel.VendorMarkets.Add(VendorMarket)

            For Each SSubmarket In VendorMarketsViewModel.VendorMarkets.ToList

                SSubmarket.Order = VendorMarketsViewModel.VendorMarkets.IndexOf(SSubmarket)

            Next

        End Sub
        Public Sub DeleteMarket(ByRef VendorMarketsViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorMarketsViewModel)

            If VendorMarketsViewModel.SelectedVendorMarket IsNot Nothing Then

                VendorMarketsViewModel.VendorMarkets.Remove(VendorMarketsViewModel.SelectedVendorMarket)

                VendorMarketsViewModel.SelectedVendorMarket = Nothing

                For Each VendorMarket In VendorMarketsViewModel.VendorMarkets.ToList

                    VendorMarket.Order = VendorMarketsViewModel.VendorMarkets.IndexOf(VendorMarket)

                Next

            End If

        End Sub
        Public Sub MoveUpMarkets(ByRef VendorMarketsViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorMarketsViewModel)

            'objects
            Dim SelectedVendorMarket As AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorMarket = Nothing
            Dim Index As Integer = 0

            If VendorMarketsViewModel.SelectedVendorMarket IsNot Nothing Then

                SelectedVendorMarket = VendorMarketsViewModel.SelectedVendorMarket

                If VendorMarketsViewModel.VendorMarkets.Contains(SelectedVendorMarket) Then

                    Index = VendorMarketsViewModel.VendorMarkets.IndexOf(SelectedVendorMarket)

                    VendorMarketsViewModel.VendorMarkets.Remove(SelectedVendorMarket)

                    If Index > 0 Then

                        VendorMarketsViewModel.VendorMarkets.Insert(Index - 1, SelectedVendorMarket)

                    Else

                        VendorMarketsViewModel.VendorMarkets.Insert(0, SelectedVendorMarket)

                    End If

                End If

                For Each VendorMarket In VendorMarketsViewModel.VendorMarkets.ToList

                    VendorMarket.Order = VendorMarketsViewModel.VendorMarkets.IndexOf(VendorMarket)

                Next

            End If

        End Sub
        Public Sub MoveDownMarkets(ByRef VendorMarketsViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorMarketsViewModel)

            'objects
            Dim SelectedVendorMarket As AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorMarket = Nothing
            Dim Index As Integer = 0

            If VendorMarketsViewModel.SelectedVendorMarket IsNot Nothing Then

                SelectedVendorMarket = VendorMarketsViewModel.SelectedVendorMarket

                If VendorMarketsViewModel.VendorMarkets.Contains(SelectedVendorMarket) Then

                    Index = VendorMarketsViewModel.VendorMarkets.IndexOf(SelectedVendorMarket)

                    VendorMarketsViewModel.VendorMarkets.Remove(SelectedVendorMarket)

                    If Index < VendorMarketsViewModel.VendorMarkets.Count - 1 Then

                        VendorMarketsViewModel.VendorMarkets.Insert(Index + 1, SelectedVendorMarket)

                    Else

                        VendorMarketsViewModel.VendorMarkets.Insert(VendorMarketsViewModel.VendorMarkets.Count, SelectedVendorMarket)

                    End If

                End If

                For Each VendorMarket In VendorMarketsViewModel.VendorMarkets.ToList

                    VendorMarket.Order = VendorMarketsViewModel.VendorMarkets.IndexOf(VendorMarket)

                Next

            End If

        End Sub
        Public Function ValidateEntity(VendorMarket As AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorMarket, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTO(DbContext, DataContext, VendorMarket, IsValid)

                End Using

            End Using

            ValidateEntity = ErrorText

        End Function

#End Region

#End Region

    End Class

End Namespace
