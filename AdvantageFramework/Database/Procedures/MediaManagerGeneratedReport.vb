Namespace Database.Procedures.MediaManagerGeneratedReport

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadByMediaManagerGeneratedReportID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaManagerGeneratedReportID As Integer) As AdvantageFramework.Database.Entities.MediaManagerGeneratedReport

            Try

                LoadByMediaManagerGeneratedReportID = (From MediaManagerGeneratedReport In DbContext.GetQuery(Of Database.Entities.MediaManagerGeneratedReport)
                                                       Where MediaManagerGeneratedReport.ID = MediaManagerGeneratedReportID
                                                       Select MediaManagerGeneratedReport).SingleOrDefault

            Catch ex As Exception
                LoadByMediaManagerGeneratedReportID = Nothing
            End Try

        End Function
        Public Function GetCreateDateByOrderNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer) As Nullable(Of Date)

            Try

                If (From MediaManagerGeneratedReport In DbContext.GetQuery(Of Database.Entities.MediaManagerGeneratedReport)
                    Where MediaManagerGeneratedReport.OrderNumber = OrderNumber).Any Then

                    GetCreateDateByOrderNumber = (From MediaManagerGeneratedReport In DbContext.GetQuery(Of Database.Entities.MediaManagerGeneratedReport)
                                                  Where MediaManagerGeneratedReport.OrderNumber = OrderNumber
                                                  Select MediaManagerGeneratedReport).Min(Function(Entity) Entity.CreatedDate)

                End If

            Catch ex As Exception
                GetCreateDateByOrderNumber = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.MediaManagerGeneratedReport)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.MediaManagerGeneratedReport)()

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaManagerGeneratedReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedReport, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.Entry(MediaManagerGeneratedReport).State = Entity.EntityState.Modified

                ErrorMessage = MediaManagerGeneratedReport.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                End If

            Catch ex As Exception

                Updated = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Update = Updated
            End Try

        End Function

#End Region

    End Module

End Namespace
