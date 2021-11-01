Namespace ConceptShare.Classes

    <Serializable()>
    Public Class FullReview

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ReviewID As Integer = 0
        Public Property AlertID As Integer = 0
        Public Property JobNumber As Integer = 0
        Public Property JobComponentNumber As Short = 0

        Public Property Project As AdvantageFramework.ConceptShareAPI.Project = Nothing
        Public Property Review As AdvantageFramework.ConceptShareAPI.Review = Nothing
        Public Property Alert As AdvantageFramework.Database.Entities.Alert = Nothing
        Public Property Assets As Generic.List(Of AdvantageFramework.ConceptShareAPI.Asset) = Nothing
        Public Property Members As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember) = Nothing

        Private Property _DataContext As AdvantageFramework.Database.DataContext
        Private Property _Employee As AdvantageFramework.Database.Views.Employee
        Private Property _APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
        Private Property _APIContext As ConceptShareAPI.APIContext = Nothing
        Private Property _User As ConceptShareAPI.User = Nothing

#End Region

#Region " Methods "

        Private Sub LoadProject()

        End Sub
        Private Sub LoadReview()

        End Sub
        Private Sub LoadAlert()

        End Sub
        Private Sub LoadAssets()

        End Sub
        Private Sub LoadMembers()

        End Sub

        Sub New(ByRef DataContext As AdvantageFramework.Database.DataContext, ByRef Employee As AdvantageFramework.Database.Views.Employee)

            _DataContext = DataContext
            _Employee = Employee

            CreateUserConecptShareConnection(_DataContext, _Employee, _APIServiceClient, _APIContext, _User)

            If ReviewID = 0 AndAlso AlertID = 0 Then

            ElseIf ReviewID > 0 AndAlso AlertID = 0 Then

            ElseIf ReviewID = 0 AndAlso AlertID > 0 Then

            ElseIf ReviewID > 0 AndAlso AlertID > 0 Then

            End If

        End Sub

#End Region

    End Class

End Namespace
