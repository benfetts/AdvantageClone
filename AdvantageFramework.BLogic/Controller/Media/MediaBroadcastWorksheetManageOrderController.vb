Namespace Controller.Media

    Public Class MediaBroadcastWorksheetManageOrderController
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
        Public Function Load(MediaBroadcastWorksheetMarketID As Integer) As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetManageOrderViewModel

            'objects
            Dim MediaBroadcastWorksheetManageOrderViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetManageOrderViewModel = Nothing

            MediaBroadcastWorksheetManageOrderViewModel = New AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetManageOrderViewModel()

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaBroadcastWorksheetManageOrderViewModel.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID

                MediaBroadcastWorksheetManageOrderViewModel.MediaBroadcastWorksheetMarketDetailIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                                                                                      Select Entity.ID).ToArray

                MediaBroadcastWorksheetManageOrderViewModel.VendorOrderStatuses = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.VendorOrderStatus)("exec dbo.advsp_media_broadcast_worksheet_market_vendor_status {0}", MediaBroadcastWorksheetMarketID).ToList

                MediaBroadcastWorksheetManageOrderViewModel.TimezoneOffset = AdvantageFramework.VCC.GetTimezoneOffset(DbContext)

                MediaBroadcastWorksheetManageOrderViewModel.WorksheetVendorOrderStatuses = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetVendorOrderStatus)("exec dbo.advsp_media_broadcast_worksheet_order_status {0}, {1}", MediaBroadcastWorksheetMarketID, 0).OrderBy(Function(Entity) Entity.OrderNumber).ThenBy(Function(Entity) Entity.WorksheetLine).ThenByDescending(Function(Entity) Entity.Date).ToList

            End Using

            Load = MediaBroadcastWorksheetManageOrderViewModel

        End Function
        Public Function GetHighestRevisionStatuses(ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetManageOrderViewModel, VendorCode As String) As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetVendorOrderStatus)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                GetHighestRevisionStatuses = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetVendorOrderStatus)("exec dbo.advsp_media_broadcast_worksheet_order_status {0}, {1}", ViewModel.MediaBroadcastWorksheetMarketID, 1).OrderBy(Function(Entity) Entity.OrderNumber).ThenBy(Function(Entity) Entity.WorksheetLine).ThenByDescending(Function(Entity) Entity.Date).ToList

            End Using

        End Function
        Public Function GetMostRecentStatuses(ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetManageOrderViewModel, VendorCode As String) As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetVendorOrderStatus)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                GetMostRecentStatuses = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetVendorOrderStatus)("exec dbo.advsp_media_broadcast_worksheet_order_status {0}, {1}", ViewModel.MediaBroadcastWorksheetMarketID, 2).OrderBy(Function(Entity) Entity.OrderNumber).ThenBy(Function(Entity) Entity.WorksheetLine).ThenByDescending(Function(Entity) Entity.Date).ToList

            End Using

        End Function
        Public Function GetMostRecentStatusesByLine(ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetManageOrderViewModel, VendorCode As String) As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetVendorOrderStatus)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                GetMostRecentStatusesByLine = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetVendorOrderStatus)("exec dbo.advsp_media_broadcast_worksheet_order_status {0}, {1}", ViewModel.MediaBroadcastWorksheetMarketID, 3).OrderBy(Function(Entity) Entity.OrderNumber).ThenBy(Function(Entity) Entity.WorksheetLine).ThenByDescending(Function(Entity) Entity.Date).ToList

            End Using

        End Function

#End Region

#End Region

    End Class

End Namespace
