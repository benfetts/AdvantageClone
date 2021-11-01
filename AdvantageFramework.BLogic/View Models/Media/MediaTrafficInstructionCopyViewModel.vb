Namespace ViewModels.Media

    Public Class MediaTrafficInstructionCopyViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property MediaTrafficRevisionID As Integer

        Public Property MediaBroadcastWorksheetMarketIDs As IEnumerable(Of Integer)

        Public Property CopyAllVendors As Boolean

        Public Property Worksheets As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Worksheet)

#End Region

#Region " Methods "

        Public Sub New()

            Worksheets = New Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Worksheet)

        End Sub

#End Region

    End Class

End Namespace