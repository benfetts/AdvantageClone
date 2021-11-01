Namespace ViewModels.Media

    Public Class MediaTrafficGenerateViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property GenerateList As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Generate)

        Public Property ContactTypeList As Generic.List(Of AdvantageFramework.Database.Entities.ContactType)

        Public Property ContactTypeIDs As Generic.List(Of String)

#End Region

#Region " Methods "

        Public Sub New()

            GenerateList = New Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Generate)

            ContactTypeList = New Generic.List(Of AdvantageFramework.Database.Entities.ContactType)

        End Sub

#End Region

    End Class

End Namespace