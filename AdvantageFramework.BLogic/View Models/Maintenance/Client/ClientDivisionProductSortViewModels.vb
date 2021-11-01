Namespace ViewModels.Maintenance.General
    <Serializable()> Public Class ClientSortViewModel
        Public Property ClientCode As String = String.Empty
        Public Property SortKey As String = String.Empty
        Sub New()

        End Sub
    End Class
    <Serializable()> Public Class DivisionSortViewModel
        Public Property ClientCode As String = String.Empty
        Public Property DivisionCode As String = String.Empty
        Public Property SortKey As String = String.Empty
        Sub New()

        End Sub
    End Class
    <Serializable()> Public Class ProductSortViewModel
        Public Property ClientCode As String = String.Empty
        Public Property DivisionCode As String = String.Empty
        Public Property ProductCode As String = String.Empty
        Public Property SortKey As String = String.Empty
        Sub New()

        End Sub

    End Class

    <Serializable()> Public Class CompanyProfileAffiliationViewModel
        Public Property ID As Integer = 0
        Public Property CompanyProfileID As Integer = 0
        Public Property AffiliationID As Integer = 0
        Public Property IsEntityBeingAdded As Boolean = False
        Sub New()

        End Sub

    End Class
    <Serializable()> Public Class AffiliationViewModel
        Public Property ID As Integer = 0
        Public Property Description As String = String.Empty
        Public Property IsInactive As Boolean = False
        Sub New()

        End Sub

    End Class

    <Serializable()> Public Class ActivityCompetitionViewModel
        Public Property ID As Integer = 0
        Public Property ActivityID As Integer = 0
        Public Property CompetitionID As Integer = 0
        Public Property IsEntityBeingAdded As Boolean = False
        Sub New()

        End Sub

    End Class

    <Serializable()> Public Class CompetitionViewModel
        Public Property ID As Integer = 0
        Public Property Description As String = String.Empty
        Public Property IsInactive As Boolean = False
        Sub New()

        End Sub

    End Class

End Namespace


