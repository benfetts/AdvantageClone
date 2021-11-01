Namespace ViewModels.Maintenance.Media

    Public Class MarketGroupEditViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AddEnabled As Boolean
        Public Property UpdateEnabled As Boolean
        Public Property CancelEnabled As Boolean

        Public Property MarketGroupID As Integer
        Public Property MarketGroup As AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup

        Public Property Countries As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Country)
        Public Property MediaTypes As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)


#End Region

#Region " Methods "

        Public Sub New()

            Me.AddEnabled = False
            Me.UpdateEnabled = False
            Me.CancelEnabled = False

            Me.MarketGroupID = 0
            Me.MarketGroup = Nothing

            Me.Countries = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Country)
            Me.MediaTypes = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

        End Sub

#End Region

    End Class

End Namespace

