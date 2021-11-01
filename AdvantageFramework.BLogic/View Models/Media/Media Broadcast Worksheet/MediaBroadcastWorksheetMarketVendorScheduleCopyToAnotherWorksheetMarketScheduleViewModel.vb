Namespace ViewModels.Media.MediaBroadcastWorksheet

    Public Class MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleViewModel

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
        Public Property RowIndexes As Generic.List(Of Integer)

        Public Property CopySpots As Boolean
        Public Property CopyRates As Boolean

        Public ReadOnly Property CopyEnabled As Boolean
            Get
                CopyEnabled = Me.HasASelectedWorksheetMarket
            End Get
        End Property

        Public ReadOnly Property HasASelectedWorksheetMarket As Boolean
            Get
                HasASelectedWorksheetMarket = (Me.WorksheetMarketVendorWorksheetMarketScheduleCopyTos IsNot Nothing AndAlso Me.WorksheetMarketVendorWorksheetMarketScheduleCopyTos.Where(Function(Entity) Entity.Selected = True).Count > 0)
            End Get
        End Property

        Public ReadOnly Property HasASelectedWorksheet As Boolean
            Get
                HasASelectedWorksheet = (Me.SelectedWorksheet IsNot Nothing AndAlso Me.Worksheets.Count > 0)
            End Get
        End Property

        Public Property SelectedWorksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet

        Public Property Worksheets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet)
        Public Property WorksheetMarketVendorWorksheetMarketScheduleCopyTos As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorWorksheetMarketScheduleCopyTo)

        Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet = Nothing
        Public Property WorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket = Nothing

#End Region

#Region " Methods "

        Public Sub New()

            Me.MediaBroadcastWorksheetID = 0
            Me.MediaBroadcastWorksheetMarketID = 0
            Me.SelectedWorksheetMarketRevisionNumber = 0
            Me.RowIndexes = New Generic.List(Of Integer)

            Me.CopySpots = True
            Me.CopyRates = True

            Me.Worksheets = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet)
            Me.WorksheetMarketVendorWorksheetMarketScheduleCopyTos = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorWorksheetMarketScheduleCopyTo)

            Me.SelectedWorksheet = Nothing

            Me.Worksheet = Nothing
            Me.WorksheetMarket = Nothing

        End Sub

#End Region

    End Class

End Namespace
