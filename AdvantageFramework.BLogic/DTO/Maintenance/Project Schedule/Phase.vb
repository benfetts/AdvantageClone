Namespace DTO.Maintenance.ProjectSchedule

    Public Class Phase

        Public Property ID As Integer
        Public Property Description As String
        Public Property OrderNumber As Integer?
        Public Property IsInactive As Boolean
        'Public Property JobComponentTasks As IEnumerable(Of JobComponentTasks)

        Public Sub New()



        End Sub

        Public Function ToEntity(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.Phase

            'objects
            Dim PhaseEntity As AdvantageFramework.Database.Entities.Phase = Nothing

            If DbContext IsNot Nothing Then

                PhaseEntity = AdvantageFramework.Database.Procedures.Phase.LoadByPhaseID(DbContext, Me.ID)

            End If

            If PhaseEntity Is Nothing Then

                PhaseEntity = New Database.Entities.Phase

            End If

            With PhaseEntity
                .ID = Me.ID
                .Description = Me.Description
                .IsInactive = If(Me.IsInactive, 1, 0)
                .OrderNumber = Me.OrderNumber
                '.JobComponentTasks = Me.JobComponentTasks

            End With


            Return PhaseEntity

        End Function
        Public Shared Function FromEntity(ByVal Entity As AdvantageFramework.Database.Entities.Phase) As Phase

            'objects
            Dim Phase As AdvantageFramework.DTO.Maintenance.ProjectSchedule.Phase = Nothing

            Phase = New AdvantageFramework.DTO.Maintenance.ProjectSchedule.Phase

            With Phase

                .ID = Entity.ID
                .Description = Entity.Description
                .IsInactive = If(Entity.IsInactive, 1, 0)
                .OrderNumber = Entity.OrderNumber
                '.JobComponentTasks = Entity.JobComponentTasks

            End With

            Return Phase

        End Function

    End Class

End Namespace


