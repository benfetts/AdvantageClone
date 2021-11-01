Namespace ViewModels.Media

    Public Class MediaTrafficViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property IsAgencyASP As Boolean
        Public Property AgencyImportPath As String
        Public ReadOnly Property SaveEnabled As Boolean
            Get
                SaveEnabled = Me.Revisions.Where(Function(R) R.Modified = True).Any OrElse
                    Me.CreativeGroups.Where(Function(D) D.Modified = True).Any OrElse
                    Me.Details.Where(Function(D) D.Modified = True OrElse D.IsDeleted = True).Any
            End Get
        End Property

        Public Property SelectedRevision As AdvantageFramework.DTO.Media.Traffic.Revision
        Public Property SelectedCreativeGroup As AdvantageFramework.DTO.Media.Traffic.CreativeGroup
        Public Property SelectedDetails As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Detail)
        Public Property SelectedVendor As AdvantageFramework.DTO.Media.Traffic.Vendor

        Public Property Revisions As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Revision)
        Public Property CreativeGroups As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.CreativeGroup)
        Public Property Details As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Detail)
        Public Property Vendors As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Vendor)
        Public Property WorksheetMarketVendors As Generic.List(Of AdvantageFramework.Database.Entities.Vendor)
        Public Property VendorStatuses As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.VendorStatus)

        Public Property SelectedRevisionRevisionNumbers As Generic.List(Of Integer)

        Public ReadOnly Property IsAnyVendorCableSystem As Boolean
            Get
                IsAnyVendorCableSystem = Vendors IsNot Nothing AndAlso Vendors.Any(Function(V) V.IsCableSystem = True)
            End Get
        End Property

        Public Property RepositoryStatusList As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

        Public Property RepositoryDaypartList As Generic.List(Of AdvantageFramework.DTO.Daypart)

        Public Property RepositoryAdNumberList As Generic.List(Of AdvantageFramework.DTO.AdNumber)

        Public Property RepositoryMediaTrafficCreativeGroupList As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.CreativeGroup)

        Public Property TrafficGuidelines As String

        Public Property MediaBroadcastWorksheetMarketID As Integer
        Public Property MediaBroadcastWorksheetID As Integer
        Public Property MediaBroadcastWorksheetName As String
        Public Property DefaultLength As Short

        Public Property MediaBroadcastWorksheetStartDate As Date
        Public Property MediaBroadcastWorksheetEndDate As Date
        Public Property ClientCode As String
        Public Property MediaType As String

        Public ReadOnly Property InstructionFilename As String
            Get
                InstructionFilename = AdvantageFramework.FileSystem.CreateValidFileName(Me.MediaBroadcastWorksheetMarketID.ToString & "_" & Me.MediaBroadcastWorksheetName & "_" & Me.SelectedVendor.MediaTrafficRevisionDescription & "_" & Me.SelectedVendor.MediaTrafficRevisionID & "_" & Me.SelectedVendor.VendorName & ".PDF")
            End Get
        End Property

        Public Property Location As AdvantageFramework.Database.Entities.Location
        Public Property IncludeGuidelines As Boolean
        Public Property DoesUserHaveAccessToAdNumberMaintenance As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            SelectedDetails = New Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Detail)

            Revisions = New Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Revision)
            CreativeGroups = New Generic.List(Of AdvantageFramework.DTO.Media.Traffic.CreativeGroup)
            Details = New Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Detail)
            Vendors = New Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Vendor)
            WorksheetMarketVendors = New Generic.List(Of AdvantageFramework.Database.Entities.Vendor)
            VendorStatuses = New Generic.List(Of AdvantageFramework.DTO.Media.Traffic.VendorStatus)

            SelectedRevisionRevisionNumbers = New Generic.List(Of Integer)

            RepositoryStatusList = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

            RepositoryDaypartList = New Generic.List(Of AdvantageFramework.DTO.Daypart)

            RepositoryAdNumberList = New Generic.List(Of AdvantageFramework.DTO.AdNumber)

            RepositoryMediaTrafficCreativeGroupList = New Generic.List(Of AdvantageFramework.DTO.Media.Traffic.CreativeGroup)

            DoesUserHaveAccessToAdNumberMaintenance = False

        End Sub

#End Region

    End Class

End Namespace