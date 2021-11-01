Namespace ViewModels

    Public Class AlertRecipientViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
        Public Property DistinctAlertGroups As Generic.List(Of AdvantageFramework.Database.Entities.AlertGroup) = Nothing
        Public Property AlertGroups As Generic.List(Of AdvantageFramework.Database.Entities.AlertGroup) = Nothing
        Public Property SelectedEmployees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

#End Region

#Region " Methods "

        Public Sub New()

            Me.Employees = New Generic.List(Of AdvantageFramework.Database.Views.Employee)
            Me.DistinctAlertGroups = New Generic.List(Of AdvantageFramework.Database.Entities.AlertGroup)
            Me.AlertGroups = New Generic.List(Of AdvantageFramework.Database.Entities.AlertGroup)
            Me.SelectedEmployees = New Generic.List(Of AdvantageFramework.Database.Views.Employee)

        End Sub

#End Region

    End Class

End Namespace
