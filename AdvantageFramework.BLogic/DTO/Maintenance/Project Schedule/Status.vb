Namespace DTO.Maintenance.ProjectSchedule

    Public Class Status

        Public Property Code As String
        Public Property Description As String
        Public Property IsInactive As Boolean
        'Public Property JobTraffic As IEnumerable(Of JobTraffic)
        'Public Property JobTrafficVersions As IEnumerable(Of JobTrafficVersions)

        Public Sub New()



        End Sub

        Public Function ToEntity(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.Status

            'objects
            Dim StatusEntity As AdvantageFramework.Database.Entities.Status = Nothing

            If DbContext IsNot Nothing Then

                StatusEntity = AdvantageFramework.Database.Procedures.Status.LoadByStatusCode(DbContext, Me.Code)

            End If

            If StatusEntity Is Nothing Then

                StatusEntity = New Database.Entities.Status

            End If

            With StatusEntity
                .Code = Me.Code
                .Description = Me.Description
                .IsInactive = If(Me.IsInactive, 1, 0)
                '.JobTraffic = Me.JobTrafic
                '.JobTrafficVersions = Me.JobTrafficVersions

            End With


            Return StatusEntity

        End Function
        Public Shared Function FromEntity(ByVal Entity As AdvantageFramework.Database.Entities.Status) As Status

            'objects
            Dim Status As AdvantageFramework.DTO.Maintenance.ProjectSchedule.Status = Nothing

            Status = New AdvantageFramework.DTO.Maintenance.ProjectSchedule.Status

            With Status

                .Code = Entity.Code
                .Description = Entity.Description
                .IsInactive = If(Entity.IsInactive, 1, 0)
                '.JobTraffic = Entity.JobTrafic
                '.JobTrafficVersions = Entity.JobTrafficVersions


            End With

            Return Status

        End Function

    End Class

End Namespace


