Namespace DTO.Maintenance.ProjectManagement

    Public Class JobType

        Public Property Code As String
        Public Property Description As String
        Public Property IsInactive As Boolean
        Public Property SalesClassCode As String

        Public Sub New()



        End Sub

        Public Function ToEntity(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.JobType

            'objects
            Dim JobTypeEntity As AdvantageFramework.Database.Entities.JobType = Nothing

            If DbContext IsNot Nothing Then

                JobTypeEntity = AdvantageFramework.Database.Procedures.JobType.LoadByJobTypeCode(DbContext, Me.Code)

            End If

            If JobTypeEntity Is Nothing Then

                JobTypeEntity = New Database.Entities.JobType

            End If

            With JobTypeEntity
                .Code = Me.Code
                .Description = Me.Description
                .IsInactive = If(Me.IsInactive, 1, 0)
                .SalesClassCode = Me.SalesClassCode

            End With


            Return JobTypeEntity

        End Function
        Public Shared Function FromEntity(ByVal Entity As AdvantageFramework.Database.Entities.JobType) As JobType

            'objects
            Dim JobType As AdvantageFramework.DTO.Maintenance.ProjectManagement.JobType = Nothing

            JobType = New AdvantageFramework.DTO.Maintenance.ProjectManagement.JobType

            With JobType

                .Code = Entity.Code
                .Description = Entity.Description
                .IsInactive = If(Entity.IsInactive, 1, 0)
                .SalesClassCode = Entity.SalesClassCode


            End With

            Return JobType

        End Function

    End Class

End Namespace


