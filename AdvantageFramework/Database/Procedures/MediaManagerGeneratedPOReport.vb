Namespace Database.Procedures.MediaManagerGeneratedPOReport

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

        Public Function LoadByPONumber(DbContext As AdvantageFramework.Database.DbContext, PONumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.MediaManagerGeneratedPOReport)

            LoadByPONumber = From MediaManagerGeneratedPOReport In DbContext.GetQuery(Of Database.Entities.MediaManagerGeneratedPOReport)
                             Where MediaManagerGeneratedPOReport.PONumber = PONumber
                             Select MediaManagerGeneratedPOReport

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.MediaManagerGeneratedPOReport)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.MediaManagerGeneratedPOReport)()

        End Function
        Public Function Update(DbContext As AdvantageFramework.Database.DbContext, MediaManagerGeneratedPOReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedPOReport, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.Entry(MediaManagerGeneratedPOReport).State = Entity.EntityState.Modified

                ErrorMessage = MediaManagerGeneratedPOReport.ValidateEntity(IsValid)

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
