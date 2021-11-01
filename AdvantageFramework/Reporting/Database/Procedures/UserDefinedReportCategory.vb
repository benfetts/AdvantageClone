Namespace Reporting.Database.Procedures.UserDefinedReportCategory

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

        Public Function LoadByUserDefinedReportCategoryID(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal UserDefinedReportCategoryID As Long) As AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory

            Try

                LoadByUserDefinedReportCategoryID = (From UserDefinedReportCategory In ReportingDbContext.GetQuery(Of Database.Entities.UserDefinedReportCategory)
                                                     Where UserDefinedReportCategory.ID = UserDefinedReportCategoryID
                                                     Select UserDefinedReportCategory).SingleOrDefault

            Catch ex As Exception
                LoadByUserDefinedReportCategoryID = Nothing
            End Try

        End Function
        Public Function Load(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory)

            Load = From UserDefinedReportCategory In ReportingDbContext.GetQuery(Of Database.Entities.UserDefinedReportCategory)
                   Select UserDefinedReportCategory

        End Function
        Public Function Insert(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal UserDefinedReportCategory As AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ReportingDbContext.UserDefinedReportCategories.Add(UserDefinedReportCategory)

                ErrorText = UserDefinedReportCategory.ValidateEntity(IsValid)

                If IsValid Then

                    ReportingDbContext.SaveChanges()

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
        Public Function Update(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal UserDefinedReportCategory As AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ReportingDbContext.UpdateObject(UserDefinedReportCategory)

                ErrorText = UserDefinedReportCategory.ValidateEntity(IsValid)

                If IsValid Then

                    ReportingDbContext.SaveChanges()

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
        Public Function Delete(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal UserDefinedReportCategory As AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportCategoryID(ReportingDbContext, UserDefinedReportCategory.ID).Any Then

                    IsValid = False
                    ErrorText = "This category is in use and cannot be deleted."

                End If

                If IsValid Then

                    If AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByUserDefinedReportCategoryID(ReportingDbContext, UserDefinedReportCategory.ID).Any Then

                        IsValid = False
                        ErrorText = "This category is in use and cannot be deleted."

                    End If

                End If

                If IsValid Then

                    ReportingDbContext.DeleteEntityObject(UserDefinedReportCategory)

                    ReportingDbContext.SaveChanges()

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
