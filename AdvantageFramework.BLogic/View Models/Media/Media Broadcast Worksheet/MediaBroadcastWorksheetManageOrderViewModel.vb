Namespace ViewModels.Media.MediaBroadcastWorksheet

    Public Class MediaBroadcastWorksheetManageOrderViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property WorksheetVendorOrderStatuses As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetVendorOrderStatus)

        Public MediaBroadcastWorksheetMarketDetailIDs As IEnumerable(Of Integer)
        Public MediaBroadcastWorksheetMarketID As Integer

        Public Property VendorOrderStatuses As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.VendorOrderStatus)

        Public Property TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset

#End Region

#Region " Methods "

        Public Sub New()

            WorksheetVendorOrderStatuses = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetVendorOrderStatus)

            VendorOrderStatuses = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.VendorOrderStatus)

        End Sub

#End Region

    End Class

End Namespace