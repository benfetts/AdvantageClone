Namespace ViewModels.Maintenance.ProjectManagement

    Public Class AdNumberSetupViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SaveEnabled As Boolean
        Public Property CancelEnabled As Boolean
        Public Property DeleteEnabled As Boolean

        Public Property Clients As Generic.List(Of AdvantageFramework.Database.Entities.Client)
        Public Property Divisions As Generic.List(Of AdvantageFramework.Database.Entities.Division)
        Public Property Products As Generic.List(Of AdvantageFramework.Database.Entities.Product)
        Public Property Blackplates As Generic.List(Of AdvantageFramework.Database.Entities.Blackplate)
        Public Property MediaTypes As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

        Public Property AdNumbers As Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber)

        Public ReadOnly Property HasASelectedAdNumber As Boolean
            Get
                HasASelectedAdNumber = SelectedAdNumbers IsNot Nothing AndAlso SelectedAdNumbers.Count > 0
            End Get
        End Property
        Public ReadOnly Property HasOnlyOneSelectedAdNumber As Boolean
            Get
                HasOnlyOneSelectedAdNumber = SelectedAdNumbers IsNot Nothing AndAlso SelectedAdNumbers.Count = 1
            End Get
        End Property
        Public ReadOnly Property SelectedAdNumberHasDocument As Boolean
            Get
                SelectedAdNumberHasDocument = SelectedAdNumbers IsNot Nothing AndAlso SelectedAdNumbers.Count = 1 AndAlso SelectedAdNumbers.First.DocumentID.HasValue
            End Get
        End Property
        Public Property IsNewRow As Boolean
        Public Property SelectedAdNumbers As Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber)

        Public Property ClientCode As String = Nothing
        Public Property UserCanUploadDocument As Boolean
        Public Property Session As AdvantageFramework.Security.Session
        Public Property IsAgencyASP As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Clients = New Generic.List(Of AdvantageFramework.Database.Entities.Client)
            Divisions = New Generic.List(Of AdvantageFramework.Database.Entities.Division)
            Products = New Generic.List(Of AdvantageFramework.Database.Entities.Product)

            Blackplates = New Generic.List(Of AdvantageFramework.Database.Entities.Blackplate)
            MediaTypes = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

            AdNumbers = New Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber)

            SelectedAdNumbers = New Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber)

            UserCanUploadDocument = False

        End Sub

#End Region

    End Class

End Namespace

