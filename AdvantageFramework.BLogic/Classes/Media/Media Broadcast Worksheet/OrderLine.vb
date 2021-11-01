Namespace Classes.Media.MediaBroadcastWorksheet

    Public Class OrderLine

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OrderNumber
            LineNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property OrderNumber As Integer
        Public Property LineNumber As Integer

#End Region

#Region " Methods "

        Public Sub New()

            Me.OrderNumber = 0
            Me.LineNumber = 0

        End Sub

#End Region

    End Class

End Namespace
