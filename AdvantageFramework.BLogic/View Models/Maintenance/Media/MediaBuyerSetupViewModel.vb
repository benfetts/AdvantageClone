Namespace ViewModels.Maintenance.Media

    Public Class MediaBuyerSetupViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property CancelEnabled As Boolean
        Public Property DeleteEnabled As Boolean
        Public Property RepositoryEmployeeList As Generic.List(Of AdvantageFramework.Database.Core.Employee)
        Public ReadOnly Property HasASelectedMediaBuyer As Boolean
            Get
                HasASelectedMediaBuyer = (SelectedMediaBuyers IsNot Nothing AndAlso SelectedMediaBuyers.Count > 0)
            End Get
        End Property
        Public Property IsNewRow As Boolean
        Public Property MediaBuyers As Generic.List(Of AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel)
        Public Property SelectedMediaBuyers As Generic.List(Of AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel)

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

