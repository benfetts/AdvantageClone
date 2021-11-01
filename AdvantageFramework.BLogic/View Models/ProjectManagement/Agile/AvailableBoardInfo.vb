Namespace ViewModels.ProjectManagement.Agile

    <Serializable()>
    Public Class AvailableBoardInfo

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property HasActiveBoard As Boolean = False
        Public ReadOnly Property BoardCount As Integer
            Get
                If DisplayBoards Is Nothing Then
                    Return 0
                Else
                    Return DisplayBoards.Count
                End If
            End Get
        End Property

        Public Property ActiveSprintID As Integer = 0
        Public Property DisplayBoards As Generic.List(Of AdvantageFramework.Database.Entities.Board) = Nothing
        Public Property Sprints As Generic.List(Of AdvantageFramework.Database.Entities.SprintHeader) = Nothing
        Public Property States As Generic.List(Of AdvantageFramework.Database.Entities.AlertState) = Nothing

#End Region

#Region " Methods "

        Sub New()

            DisplayBoards = New List(Of Database.Entities.Board)
            Sprints = New List(Of Database.Entities.SprintHeader)
            States = New List(Of Database.Entities.AlertState)

        End Sub

#End Region

    End Class

End Namespace