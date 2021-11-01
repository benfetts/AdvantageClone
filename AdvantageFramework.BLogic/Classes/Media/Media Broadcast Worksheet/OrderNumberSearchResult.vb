Namespace Classes.Media.MediaBroadcastWorksheet

    Public Class OrderNumberSearchResult

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            WorksheetID
            WorksheetMarketID
            OrderNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property WorksheetID As Integer
        Public Property WorksheetMarketID As Integer
        Public Property OrderNumber As Integer

#End Region

#Region " Methods "

        Public Sub New()

            Me.WorksheetID = 0
            Me.WorksheetMarketID = 0
            Me.OrderNumber = 0

        End Sub

#End Region

    End Class

End Namespace
