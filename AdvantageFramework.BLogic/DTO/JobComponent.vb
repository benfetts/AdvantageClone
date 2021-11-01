Namespace DTO

    <Serializable()>
    Public Class JobComponent

        Public Property OfficeCode As String = String.Empty
        Public Property OfficeName As String = String.Empty
        Public Property ClientCode As String = String.Empty
        Public Property ClientName As String = String.Empty
        Public Property DivisionCode As String = String.Empty
        Public Property DivisionName As String = String.Empty
        Public Property ProductCode As String = String.Empty
        Public Property ProductName As String = String.Empty
        Public Property JobNumber As Integer = 0
        Public Property JobDescription As String = String.Empty
        Public Property JobComponentNumber As Short = 0
        Public Property JobComponentDescription As String = String.Empty
        Public Property HasSchedule As Boolean = False
        Public Property Text As String = String.Empty
        Sub New()

        End Sub

    End Class

End Namespace
