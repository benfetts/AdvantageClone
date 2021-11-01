Namespace ViewModels.Media

    Public Class MediaTrafficResponseViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Vendors As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Vendor)

        Public Property AlertComments As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.AlertComment)

#End Region

#Region " Methods "

        Public Sub New()

            Vendors = New Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Vendor)

            AlertComments = New Generic.List(Of AdvantageFramework.DTO.Media.Traffic.AlertComment)

        End Sub

#End Region

    End Class

End Namespace