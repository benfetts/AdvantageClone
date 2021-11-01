Namespace ViewModels.ProjectManagement.JobJacket
    <Serializable()>
    Public Class JobJacketSearchDTO
#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "
        Public Property JobNumber As Integer? = 0
        Public Property JobDescription As String = String.Empty
        Public Property JobComponentDescription As String = String.Empty
        Public Property JobComponentNumber As Short? = 0
        Public Property ClientName As String = String.Empty
        Public Property ClientCode As String = String.Empty
        Public Property DivisionCode As String = String.Empty
        Public Property DivisionName As String = String.Empty
        Public Property ProductCode As String = String.Empty
        Public Property ProductName As String = String.Empty
        Public Property DueDate As Date? = Nothing
        Public Property SalesClass As String = String.Empty
        Public Property StartDate As Date? = Nothing
        Public Property OfficeName As String = String.Empty
        Public Property JobType As String = String.Empty
        Public Property Budget As Decimal? = 0
        Public Property EstimateStatus As String = String.Empty
        Public Property JobCompDesc As String = String.Empty
        Public Property CDPName As String = String.Empty
#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class
End Namespace
