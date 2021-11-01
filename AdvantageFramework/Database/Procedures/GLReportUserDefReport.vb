Namespace Database.Procedures.GLReportUserDefReport

    <HideModuleName()> _
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

        Public Function LoadByGLReportUserDefReportID(ByVal DbContext As Database.DbContext, ByVal GLReportUserDefReportID As Integer) As Database.Entities.GLReportUserDefReport

            Try

                LoadByGLReportUserDefReportID = (From GLReportUserDefReport In DbContext.GetQuery(Of Database.Entities.GLReportUserDefReport)
                                                 Where GLReportUserDefReport.ID = GLReportUserDefReportID
                                                 Select GLReportUserDefReport).SingleOrDefault

            Catch ex As Exception
                LoadByGLReportUserDefReportID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GLReportUserDefReport)

            Load = From GLReportUserDefReport In DbContext.GetQuery(Of Database.Entities.GLReportUserDefReport)
                   Select GLReportUserDefReport

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportUserDefReport As AdvantageFramework.Database.Entities.GLReportUserDefReport) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GLReportUserDefReports.Add(GLReportUserDefReport)

                ErrorText = GLReportUserDefReport.ValidateEntity(IsValid)

                If IsValid Then

                    GLReportUserDefReport.CreatedByUserCode = DbContext.UserCode
                    GLReportUserDefReport.CreatedDate = Now

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportUserDefReport As AdvantageFramework.Database.Entities.GLReportUserDefReport) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GLReportUserDefReport)

                ErrorText = GLReportUserDefReport.ValidateEntity(IsValid)

                If IsValid Then

                    GLReportUserDefReport.ModifiedByUserCode = DbContext.UserCode
                    GLReportUserDefReport.ModifiedDate = Now

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLReportUserDefReport As AdvantageFramework.Database.Entities.GLReportUserDefReport) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(GLReportUserDefReport)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
