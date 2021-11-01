Namespace Proofing.Classes

    <Serializable()> Public Class FeedbackSummary
#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AlertID As Integer = 0
        Public Property Subject As String = String.Empty
        Public Property Description As String = String.Empty
        Public Property DueDate As DateTime? = Nothing

        Public Property Assets As Generic.List(Of Asset)

#End Region

#Region " Methods "

        Sub New()

            Assets = New Generic.List(Of Asset)

        End Sub

#End Region

    End Class

    <Serializable()> Public Class Asset
#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Comments As Generic.List(Of Comment)

#End Region

#Region " Methods "
        Sub New()

            Comments = New List(Of Comment)

        End Sub

#End Region

    End Class
    <Serializable()> Public Class Comment
#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Replies As Generic.List(Of Comment)

#End Region

#Region " Methods "
        Sub New()

            Replies = New List(Of Comment)

        End Sub

#End Region

    End Class

End Namespace
