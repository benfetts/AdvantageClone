Namespace DTO.Maintenance.Accounting

    Public Class SalesClass

        Public Property Code As String
        Public Property Description As String
        Public Property SalesClassType As String
        Public Property IsInactive As Boolean

        Public Sub New()



        End Sub

        Public Function ToEntity(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.SalesClass

            'objects
            Dim SalesClassEntity As AdvantageFramework.Database.Entities.SalesClass = Nothing

            If DbContext IsNot Nothing Then

                SalesClassEntity = AdvantageFramework.Database.Procedures.SalesClass.LoadBySalesClassCode(DbContext, Me.Code)

            End If

            If SalesClassEntity Is Nothing Then

                SalesClassEntity = New Database.Entities.SalesClass

            End If

            With SalesClassEntity
                .Code = Me.Code
                .Description = Me.Description
                .SalesClassTypeCode = Me.SalesClassType
                .IsInactive = If(Me.IsInactive, 1, 0)
            End With


            Return SalesClassEntity

        End Function
        Public Shared Function FromEntity(ByVal Entity As AdvantageFramework.Database.Entities.SalesClass) As SalesClass

            'objects
            Dim SalesClass As AdvantageFramework.DTO.Maintenance.Accounting.SalesClass = Nothing

            SalesClass = New AdvantageFramework.DTO.Maintenance.Accounting.SalesClass

            With SalesClass

                .Code = Entity.Code
                .Description = Entity.Description
                .SalesClassType = Entity.SalesClassTypeCode
                .IsInactive = If(Entity.IsInactive.GetValueOrDefault(0) = 1, True, False)

            End With

            Return SalesClass

        End Function

    End Class

End Namespace


