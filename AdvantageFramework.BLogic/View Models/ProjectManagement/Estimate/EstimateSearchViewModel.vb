Namespace ViewModels.ProjectManagement.Estimate

    <Serializable()>
    Public Class EstimateSearchViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property EstimateNumber As Integer? = 0
        Public Property EstimateDescription As String = String.Empty
        Public Property EstimateComponentNumber As Short? = 0
        Public Property EstimateComponentDescription As String = String.Empty
        Public Property ClientCode As String = String.Empty
        Public Property DivisionCode As String = String.Empty
        Public Property ProductCode As String = String.Empty
        Public Property ClientName As String = String.Empty
        Public Property DivisionName As String = String.Empty
        Public Property ProductName As String = String.Empty
        Public Property JobNumber As Integer? = 0
        Public Property JobDescription As String = String.Empty
        Public Property JobComponentNumber As Short? = 0
        Public Property JobComponentDescription As String = String.Empty
        Public Property CampaignCode As String = String.Empty
        Public Property SalesClassCode As String = String.Empty
        Public Property SalesClassDescription As String = String.Empty
        Public Property JobComponentDueDate As Date? = Nothing
        Public Property OfficeCode As String = Nothing
        Public Property OfficeName As String = Nothing
        Public Property InternallyApproved As Date? = Nothing
        Public Property ClientApproved As Date? = Nothing
        Public Property Detail As String = Nothing


#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

