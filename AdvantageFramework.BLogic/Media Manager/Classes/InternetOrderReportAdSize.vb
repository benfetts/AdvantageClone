Namespace MediaManager.Classes

    Public Class InternetOrderReportAdSize

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AdSizeDescription
            PlacementName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AdSizeDescription As String
        Public Property PlacementName As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(PlacementName As String, AdSizeDescription As String)

            Me.PlacementName = PlacementName
            Me.AdSizeDescription = AdSizeDescription

        End Sub

#End Region

    End Class

End Namespace
