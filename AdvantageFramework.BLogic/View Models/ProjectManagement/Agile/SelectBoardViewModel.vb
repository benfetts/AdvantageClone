Namespace ViewModels.ProjectManagement.Agile

    <Serializable()>
    Public Class SelectBoardViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SecuritySession As AdvantageFramework.Security.Database.DbContext

#End Region

#Region " Properties "

        Public Property BoardID As Integer = 0
        Public Property JobNumber As Integer = 0
        Public Property JobComponentNumber As Short = 0
        Public Property AvailableBoards As New Generic.List(Of AvailableBoard)
        Public Property Board As AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard
        Public Property Header As AdvantageFramework.Database.Entities.SprintHeader

#End Region

#Region " Methods "

        Public Sub New()

            BoardID = 0
            JobNumber = 0
            JobComponentNumber = 0
            AvailableBoards = New List(Of AvailableBoard)
            Board = New AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard
            Header = New Database.Entities.SprintHeader

        End Sub
        Public Sub New(ByRef SecuritySession As AdvantageFramework.Security.Database.DbContext)

            Me._SecuritySession = SecuritySession

        End Sub

#End Region

        <Serializable()>
        Public Class AvailableBoard

            Public Property ID As Integer = 0
            Public Property Name As String = String.Empty

            Sub New()

            End Sub

        End Class

    End Class

End Namespace
