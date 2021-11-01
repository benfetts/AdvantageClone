Namespace ViewModels.Media

    Public Class MediaPlanCopyViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property MediaPlanCopyList As Generic.List(Of AdvantageFramework.DTO.Media.MediaPlanCopy)
        Public Property RepositorySalesClassList As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)

#End Region

#Region " Methods "

        Public Sub New()

            MediaPlanCopyList = New Generic.List(Of AdvantageFramework.DTO.Media.MediaPlanCopy)
            RepositorySalesClassList = New Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)

        End Sub

#End Region

    End Class

End Namespace