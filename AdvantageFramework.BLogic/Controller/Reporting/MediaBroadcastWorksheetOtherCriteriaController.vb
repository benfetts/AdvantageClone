Namespace Controller.Reporting

    Public Class MediaBroadcastWorksheetOtherCriteriaController
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
        Public Sub GetVendors(ByRef MediaBroadcastWorksheetOtherCriteriaViewModel As AdvantageFramework.ViewModels.Reporting.MediaBroadcastWorksheetOtherCriteriaViewModel,
                              MediaBroadcastWorksheetMarketIDs As IEnumerable(Of Integer))

            If MediaBroadcastWorksheetOtherCriteriaViewModel.AllWorksheetMarketVendors IsNot Nothing Then

                MediaBroadcastWorksheetOtherCriteriaViewModel.WorksheetMarketVendors = MediaBroadcastWorksheetOtherCriteriaViewModel.AllWorksheetMarketVendors.Where(Function(Entity) MediaBroadcastWorksheetMarketIDs.Contains(Entity.MediaBroadcastWorksheetMarketID)).
                                                                                                                                                                OrderBy(Function(Entity) Entity.MarketCode).
                                                                                                                                                                ThenBy(Function(Entity) Entity.VendorCode).ToList

            Else

                MediaBroadcastWorksheetOtherCriteriaViewModel.WorksheetMarketVendors = New Generic.List(Of AdvantageFramework.DTO.Reporting.WorksheetMarketVendor)

            End If

        End Sub
        Public Function Load(MediaBroadcastWorksheetID As Integer) As AdvantageFramework.ViewModels.Reporting.MediaBroadcastWorksheetOtherCriteriaViewModel

            'objects
            Dim MediaBroadcastWorksheetOtherCriteriaViewModel As AdvantageFramework.ViewModels.Reporting.MediaBroadcastWorksheetOtherCriteriaViewModel = Nothing
            Dim MediaBroadcastWorksheet As AdvantageFramework.Database.Entities.MediaBroadcastWorksheet = Nothing

            MediaBroadcastWorksheetOtherCriteriaViewModel = New AdvantageFramework.ViewModels.Reporting.MediaBroadcastWorksheetOtherCriteriaViewModel

            MediaBroadcastWorksheetOtherCriteriaViewModel.Reports = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.MediaBroadcastWorksheetOtherReportTypes)).OrderBy(Function(EnumObject) EnumObject.Description).ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaBroadcastWorksheet = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheet.LoadByMediaBroadcastWorksheetID(DbContext, MediaBroadcastWorksheetID)

                If MediaBroadcastWorksheet IsNot Nothing Then

                    MediaBroadcastWorksheetOtherCriteriaViewModel.MediaBroadcastWorksheetStartDate = MediaBroadcastWorksheet.StartDate
                    MediaBroadcastWorksheetOtherCriteriaViewModel.MediaBroadcastWorksheetEndDate = MediaBroadcastWorksheet.EndDate

                    MediaBroadcastWorksheetOtherCriteriaViewModel.HasPrimaryMediaDemographic = MediaBroadcastWorksheet.PrimaryMediaDemographicID.HasValue
                    MediaBroadcastWorksheetOtherCriteriaViewModel.MediaBroadcastWorksheetDateTypeID = MediaBroadcastWorksheet.MediaBroadcastWorksheetDateTypeID

                End If

                For Each MediaBroadcastWorksheetMarket In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetID(DbContext, MediaBroadcastWorksheetID).Include("Market").Include("MediaBroadcastWorksheetMarketDetails").ToList

                    MediaBroadcastWorksheetOtherCriteriaViewModel.WorksheetMarkets.Add(New DTO.Media.MediaBroadcastWorksheet.WorksheetMarket(DbContext, MediaBroadcastWorksheetMarket))

                    For Each MediaBroadcastWorksheetMarketDetail In MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails

                        If MediaBroadcastWorksheetOtherCriteriaViewModel.AllWorksheetMarketVendors.Any(Function(Entity) Entity.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarket.ID AndAlso
                                                                                                                        Entity.MarketCode = MediaBroadcastWorksheetMarket.MarketCode AndAlso
                                                                                                                        Entity.VendorCode = MediaBroadcastWorksheetMarketDetail.VendorCode) = False Then

                            MediaBroadcastWorksheetOtherCriteriaViewModel.AllWorksheetMarketVendors.Add(New DTO.Reporting.WorksheetMarketVendor(MediaBroadcastWorksheetMarketDetail))

                        End If

                    Next

                Next

            End Using

            Load = MediaBroadcastWorksheetOtherCriteriaViewModel

        End Function

#End Region

#End Region

    End Class

End Namespace
