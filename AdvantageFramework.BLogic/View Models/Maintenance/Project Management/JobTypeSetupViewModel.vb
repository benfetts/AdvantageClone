Namespace ViewModels.Maintenance.ProjectManagement

    Public Class JobTypeSetupViewModel

        'Public Event SelectionChanged()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property CancelEnabled As Boolean
        Public Property DeleteEnabled As Boolean
        Public Property JobTypes As Generic.List(Of AdvantageFramework.Database.Entities.JobType)
        Public ReadOnly Property HasASelectedJobType As Boolean
            Get
                HasASelectedJobType = SelectedJobTypes IsNot Nothing AndAlso SelectedJobTypes.Count > 0
            End Get
        End Property
        Public Property IsNewRow As Boolean
        Public Property SelectedJobTypes As Generic.List(Of AdvantageFramework.Database.Entities.JobType)

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

