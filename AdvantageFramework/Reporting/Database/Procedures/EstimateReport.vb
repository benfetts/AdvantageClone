Namespace Reporting.Database.Procedures.EstimateReport

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

        Public Function LoadByEstimateReportCategoryID(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal EstimateReportCategoryID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.EstimateReport)

            LoadByEstimateReportCategoryID = From EstimateReport In ReportingDbContext.GetQuery(Of Database.Entities.EstimateReport)
                                             Where EstimateReport.EstimateReportCategoryID = EstimateReportCategoryID
                                             Select EstimateReport

        End Function
        Public Function LoadByEstimateReportID(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal EstimateReportID As Integer) As Reporting.Database.Entities.EstimateReport

            Try

                LoadByEstimateReportID = (From EstimateReport In ReportingDbContext.GetQuery(Of Database.Entities.EstimateReport)
                                          Where EstimateReport.ID = EstimateReportID
                                          Select EstimateReport).SingleOrDefault

            Catch ex As Exception
                LoadByEstimateReportID = Nothing
            End Try

        End Function

        Public Function LoadEstimateReports(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.EstimateReport)

            LoadEstimateReports = From EstimateReport In ReportingDbContext.GetQuery(Of Database.Entities.EstimateReport)
                                  Where EstimateReport.EstimateReportType <> 99
                                  Select EstimateReport

        End Function
        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.EstimateReport)

            Load = From EstimateReport In ReportingDbContext.GetQuery(Of Database.Entities.EstimateReport)
                   Select EstimateReport

        End Function
        Public Function Insert(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext,
                               ByVal EstimateReportType As AdvantageFramework.Reporting.EstimateReportTypes,
                               ByVal Description As String, ByVal CreatedByUserCode As String,
                               ByVal CreatedDate As Date, ByVal ReportDefinition As String,
                               ByVal EstimateReportCategoryID As Nullable(Of Integer),
                               ByRef EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                EstimateReport = New AdvantageFramework.Reporting.Database.Entities.EstimateReport

                EstimateReport.DbContext = ReportingDbContext
                EstimateReport.EstimateReportType = EstimateReportType
                EstimateReport.Description = Description
                EstimateReport.CreateByUserCode = CreatedByUserCode
                EstimateReport.CreatedDate = CreatedDate
                EstimateReport.UpdatedByUserCode = CreatedByUserCode
                EstimateReport.UpdatedDate = CreatedDate
                EstimateReport.ReportDefinition = ReportDefinition
                EstimateReport.EstimateReportCategoryID = EstimateReportCategoryID

                Inserted = Insert(ReportingDbContext, EstimateReport)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ReportingDbContext.EstimateReports.Add(EstimateReport)

                ErrorText = EstimateReport.ValidateEntity(IsValid)

                If IsValid Then

                    ReportingDbContext.SaveChanges()

                    Inserted = True

                    Try

                        ReportingDbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[SEC_USER_UDRACCESS]([SEC_USER_ID], [USER_DEF_REPORT_ID], [IS_BLOCKED]) " &
                                                                        "SELECT [SEC_USER_ID], {0}, 1 FROM [dbo].[SEC_USER]", EstimateReport.ID))

                    Catch ex As Exception

                    End Try

                    Try

                        ReportingDbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[SEC_GROUP_UDRACCESS]([SEC_GROUP_ID], [USER_DEF_REPORT_ID], [IS_BLOCKED]) " &
                                                                        "SELECT [SEC_GROUP_ID], {0}, 1 FROM [dbo].[SEC_GROUP]", EstimateReport.ID))

                    Catch ex As Exception

                    End Try

                    Try

                        ReportingDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[SEC_USER_UDRACCESS] SET IS_BLOCKED = 0 " &
                                                                        "WHERE USER_DEF_REPORT_ID = {0} AND " &
                                                                        "SEC_USER_ID IN (SELECT SU.SEC_USER_ID FROM [dbo].[SEC_USER] SU WHERE SU.USER_CODE = '{1}')", EstimateReport.ID, EstimateReport.CreateByUserCode))

                    Catch ex As Exception

                    End Try

                    Try

                        ReportingDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[SEC_GROUP_UDRACCESS] SET IS_BLOCKED = 0 " &
                                                                        "WHERE USER_DEF_REPORT_ID = {0} AND " &
                                                                        "SEC_GROUP_ID IN (SELECT SGU.SEC_GROUP_ID FROM [dbo].[SEC_GROUP_USER] SGU INNER JOIN [dbo].[SEC_USER] SU ON SU.SEC_USER_ID = SGU.SEC_USER_ID WHERE SU.USER_CODE = '{1}')", EstimateReport.ID, EstimateReport.CreateByUserCode))

                    Catch ex As Exception

                    End Try

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ReportingDbContext.UpdateObject(EstimateReport)

                ErrorText = EstimateReport.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    If AdvantageFramework.Security.Database.Procedures.GroupUserDefinedReportAccess.DeleteByUserDefinedReportID(ReportingDbContext, EstimateReport.ID) Then

                        If AdvantageFramework.Security.Database.Procedures.UserUserDefinedReportAccess.DeleteByUserDefinedReportID(ReportingDbContext, EstimateReport.ID) Then

                            ReportingDbContext.DeleteEntityObject(EstimateReport)

                            ReportingDbContext.SaveChanges()

                            Deleted = True

                        End If

                    End If

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
