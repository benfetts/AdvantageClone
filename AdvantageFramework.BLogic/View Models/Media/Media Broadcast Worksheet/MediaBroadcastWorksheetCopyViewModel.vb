Namespace ViewModels.Media.MediaBroadcastWorksheet

    Public Class MediaBroadcastWorksheetCopyViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property MediaBroadcastWorksheetID As Integer
        Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet

        Public Property UseLatestRevision As Boolean

        Public Property CopySpots As Boolean
        Public Property CopyRates As Boolean

        Public Property CopyWithNewCDP As Boolean

        Public Property WorksheetCopyCDPs As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetCopyCDP)
        Public Property SelectedWorksheetCopyCDP As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetCopyCDP

        Public ReadOnly Property CopyEnabled As Boolean
            Get
                CopyEnabled = Me.HasASelectedWorksheetCopyCDP
            End Get
        End Property

        Public ReadOnly Property HasASelectedWorksheetCopyCDP As Boolean
            Get

                If CopyWithNewCDP Then

                    HasASelectedWorksheetCopyCDP = (Me.SelectedWorksheetCopyCDP IsNot Nothing)

                Else

                    HasASelectedWorksheetCopyCDP = True

                End If

            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.MediaBroadcastWorksheetID = 0
            Me.Worksheet = Nothing

            Me.UseLatestRevision = True

            Me.CopySpots = True
            Me.CopyRates = True

            Me.CopyWithNewCDP = False

            Me.WorksheetCopyCDPs = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetCopyCDP)
            Me.SelectedWorksheetCopyCDP = Nothing

        End Sub

#End Region

    End Class

End Namespace
