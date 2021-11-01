Namespace ViewModels.Media.MediaBroadcastWorksheet

    Public Class MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherVendorViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property MediaBroadcastWorksheetID As Integer
        Public Property MediaBroadcastWorksheetMarketID As Integer
        Public Property SelectedWorksheetMarketRevisionNumber As Integer
        Public Property CopyFromVendorCode As String
        Public Property RowIndexes As Generic.List(Of Integer)

        Public ReadOnly Property CopyEnabled As Boolean
            Get
                CopyEnabled = Me.HasASelectedWorksheetMarketDetailVendor
            End Get
        End Property

        Public ReadOnly Property HasASelectedWorksheetMarketDetailVendor As Boolean
            Get
                HasASelectedWorksheetMarketDetailVendor = (Me.WorksheetMarketDetailVendors IsNot Nothing AndAlso Me.WorksheetMarketDetailVendors.Where(Function(Entity) Entity.Selected = True).Count > 0)
            End Get
        End Property

        Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet = Nothing
        Public Property WorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket = Nothing
        Public Property WorksheetMarketDetailVendors As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor)

#End Region

#Region " Methods "

        Public Sub New()

            Me.MediaBroadcastWorksheetID = 0
            Me.MediaBroadcastWorksheetMarketID = 0
            Me.SelectedWorksheetMarketRevisionNumber = 0
            Me.CopyFromVendorCode = String.Empty
            Me.RowIndexes = New Generic.List(Of Integer)

            Me.WorksheetMarketDetailVendors = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor)

            Me.Worksheet = Nothing
            Me.WorksheetMarket = Nothing

        End Sub

#End Region

    End Class

End Namespace
