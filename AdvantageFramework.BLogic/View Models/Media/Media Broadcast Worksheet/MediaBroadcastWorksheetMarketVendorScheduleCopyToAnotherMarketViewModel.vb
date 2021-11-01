Namespace ViewModels.Media.MediaBroadcastWorksheet

    Public Class MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherMarketViewModel

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
                CopyEnabled = Me.HasASelectedWorksheetMarket
            End Get
        End Property

        Public ReadOnly Property HasASelectedWorksheetMarket As Boolean
            Get
                HasASelectedWorksheetMarket = (Me.WorksheetMarketVendorScheduleCopyTos IsNot Nothing AndAlso Me.WorksheetMarketVendorScheduleCopyTos.Where(Function(Entity) Entity.Selected = True).Count > 0)
            End Get
        End Property

        Public Property WorksheetMarketVendorScheduleCopyTos As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorScheduleCopyTo)

        Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet = Nothing
        Public Property WorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket = Nothing

#End Region

#Region " Methods "

        Public Sub New()

            Me.MediaBroadcastWorksheetID = 0
            Me.MediaBroadcastWorksheetMarketID = 0
            Me.SelectedWorksheetMarketRevisionNumber = 0
            Me.CopyFromVendorCode = String.Empty
            Me.RowIndexes = New Generic.List(Of Integer)

            Me.WorksheetMarketVendorScheduleCopyTos = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorScheduleCopyTo)

            Me.Worksheet = Nothing
            Me.WorksheetMarket = Nothing

        End Sub

#End Region

    End Class

End Namespace
