Namespace ViewModels.Media.MediaBroadcastWorksheet

    Public Class MediaBroadcastWorksheetMarketDetailsCopyDateViewModel

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
        Public Property CopyFromDateColumnName As String

        Public Property CopySpots As Boolean
        Public Property CopyRates As Boolean

        Public ReadOnly Property CopyEnabled As Boolean
            Get
                CopyEnabled = (Me.HasASelectedWorksheetMarketDetailDate AndAlso Me.HasASelectedWorksheetMarketVendor)
            End Get
        End Property

        Public ReadOnly Property HasASelectedWorksheetMarketDetailDate As Boolean
            Get
                HasASelectedWorksheetMarketDetailDate = (Me.WorksheetMarketDetailDateCopyList IsNot Nothing AndAlso Me.WorksheetMarketDetailDateCopyList.Where(Function(Entity) Entity.Selected = True).Count > 0)
            End Get
        End Property
        Public ReadOnly Property HasASelectedWorksheetMarketVendor As Boolean
            Get
                HasASelectedWorksheetMarketVendor = (Me.WorksheetMarketVendorDateCopyList IsNot Nothing AndAlso Me.WorksheetMarketVendorDateCopyList.Where(Function(Entity) Entity.Selected = True).Count > 0)
            End Get
        End Property

        Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet = Nothing
        Public Property WorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket = Nothing
        Public Property WorksheetMarketDetailDateCopyList As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailDateCopy)
        Public Property WorksheetMarketVendorDateCopyList As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorDateCopy)

        Public ReadOnly Property DateColumnCaption As String
            Get

                If Me.Worksheet IsNot Nothing Then

                    If Me.Worksheet.MediaBroadcastWorksheetDateTypeID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Weekly Then

                        DateColumnCaption = "Week"

                    Else

                        DateColumnCaption = "Date"

                    End If

                Else

                    DateColumnCaption = String.Empty

                End If

            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.MediaBroadcastWorksheetID = 0
            Me.MediaBroadcastWorksheetMarketID = 0
            Me.SelectedWorksheetMarketRevisionNumber = 0
            Me.CopyFromDateColumnName = String.Empty

            Me.CopySpots = True
            Me.CopyRates = True

            Me.Worksheet = Nothing
            Me.WorksheetMarket = Nothing
            Me.WorksheetMarketDetailDateCopyList = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailDateCopy)
            Me.WorksheetMarketVendorDateCopyList = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorDateCopy)

        End Sub

#End Region

    End Class

End Namespace
