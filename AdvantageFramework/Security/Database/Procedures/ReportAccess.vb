Namespace Security.Database.Procedures.ReportAccess

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

        Public Function LoadByUserCodeAndReportCode(ByVal DbContext As Database.DbContext, ByVal UserCode As String, ByVal ReportCode As String) As Security.Database.Entities.ReportAccess

            Try

                LoadByUserCodeAndReportCode = (From ReportAccess In DbContext.GetQuery(Of Database.Entities.ReportAccess)
                                               Where ReportAccess.UserCode = UserCode AndAlso
                                                     ReportAccess.ReportCode = ReportCode
                                               Select ReportAccess).SingleOrDefault

            Catch ex As Exception
                LoadByUserCodeAndReportCode = Nothing
            End Try

        End Function
        Public Function LoadByReportCode(ByVal DbContext As Database.DbContext, ByVal ReportCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ReportAccess)

            LoadByReportCode = From ReportAccess In DbContext.GetQuery(Of Database.Entities.ReportAccess)
                               Where ReportAccess.ReportCode = ReportCode
                               Select ReportAccess

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ReportAccess)

            Load = From ReportAccess In DbContext.GetQuery(Of Database.Entities.ReportAccess)
                   Select ReportAccess

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String, _
                               ByVal ReportCode As String, ByVal Enabled As String, _
                               ByRef ReportAccess As AdvantageFramework.Security.Database.Entities.ReportAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                ReportAccess = New AdvantageFramework.Security.Database.Entities.ReportAccess

                ReportAccess.DbContext = DbContext
                ReportAccess.UserCode = UserCode
                ReportAccess.ReportCode = ReportCode
                ReportAccess.Enabled = Enabled

                Inserted = Insert(DbContext, ReportAccess)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ReportAccess As AdvantageFramework.Security.Database.Entities.ReportAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ReportAccesses.Add(ReportAccess)

                ErrorText = ReportAccess.ValidateEntity(IsValid)

                If IsValid Then

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ReportAccess As AdvantageFramework.Security.Database.Entities.ReportAccess) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ReportAccess)

                ErrorText = ReportAccess.ValidateEntity(IsValid)

                If IsValid Then

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ReportAccess As AdvantageFramework.Security.Database.Entities.ReportAccess) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ReportAccess)

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
