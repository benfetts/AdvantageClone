Namespace DTO.Maintenance.ProjectSchedule

    Public Class Task

        Public Property Code As String
        Public Property Description As String
        Public Property ProcessOrderNumber As Short?
        Public Property DaysToComplete As Short?
        Public Property HoursAllowed As Decimal?
        Public Property IsInactive As Boolean
        Public Property IsMilestone As Boolean
        Public Property FunctionCode As String
        Public Property RoleCode As String
        Public Property StatusCode As String

        Public Sub New()



        End Sub

        Public Function ToEntity(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.Task

            'objects
            Dim TaskEntity As AdvantageFramework.Database.Entities.Task = Nothing

            If DbContext IsNot Nothing Then

                TaskEntity = AdvantageFramework.Database.Procedures.Task.LoadByTaskCode(DbContext, Me.Code)

            End If

            If TaskEntity Is Nothing Then

                TaskEntity = New Database.Entities.Task

            End If

            With TaskEntity
                .Code = Me.Code
                .Description = Me.Description
                .ProcessOrderNumber = Me.ProcessOrderNumber
                .DaysToComplete = Me.DaysToComplete
                .HoursAllowed = Me.HoursAllowed
                .IsInactive = If(Me.IsInactive, 1, 0)
                .IsMilestone = If(Me.IsMilestone, 1, 0)
                .FunctionCode = Me.FunctionCode
                .RoleCode = Me.RoleCode
                .StatusCode = Me.StatusCode
            End With


            Return TaskEntity

        End Function
        Public Shared Function FromEntity(ByVal Entity As AdvantageFramework.Database.Entities.Task) As Task

            'objects
            Dim Task As AdvantageFramework.DTO.Maintenance.ProjectSchedule.Task = Nothing

            Task = New AdvantageFramework.DTO.Maintenance.ProjectSchedule.Task

            With Task

                .Code = Entity.Code
                .Description = Entity.Description
                .ProcessOrderNumber = Entity.ProcessOrderNumber
                .DaysToComplete = Entity.DaysToComplete
                .HoursAllowed = Entity.HoursAllowed
                .IsInactive = If(Entity.IsInactive.GetValueOrDefault(0) = 1, True, False)
                .IsMilestone = If(Entity.IsMilestone = 1, True, False)
                .FunctionCode = Entity.FunctionCode
                .RoleCode = Entity.RoleCode
                .StatusCode = Entity.StatusCode

            End With

            Return Task

        End Function

    End Class

End Namespace


