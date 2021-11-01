Namespace ViewModels.Media

    Public Class ShareHPUTBookViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property RepositoryNielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

        Public Property ShareHPUTBooks As Generic.List(Of AdvantageFramework.DTO.Media.ShareHPUTBook)
        Public ReadOnly Property HasASelectedShareHPUTBook As Boolean
            Get
                HasASelectedShareHPUTBook = (SelectedShareHPUTBooks IsNot Nothing AndAlso SelectedShareHPUTBooks.Count > 0)
            End Get
        End Property
        Public Property IsNewRow As Boolean
        Public Property SelectedShareHPUTBooks As Generic.List(Of AdvantageFramework.DTO.Media.ShareHPUTBook)

        Public Property MarketNumber As Integer

        Public Property UseLatest As Boolean
        Public Property LatestStream As String
        Public Property LatestLOEnabled As Boolean
        Public Property LatestLSEnabled As Boolean
        Public Property LatestL1Enabled As Boolean
        Public Property LatestL3Enabled As Boolean
        Public Property LatestL7Enabled As Boolean

        Public Property RatingsServiceID As Integer

#End Region

#Region " Methods "

        Public Sub New()

            ShareHPUTBooks = New Generic.List(Of AdvantageFramework.DTO.Media.ShareHPUTBook)
            SelectedShareHPUTBooks = New Generic.List(Of AdvantageFramework.DTO.Media.ShareHPUTBook)

        End Sub

#End Region

    End Class

End Namespace

