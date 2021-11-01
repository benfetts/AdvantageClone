Namespace Reporting.Database.Procedures.DynamicReport

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

        Public Function LoadByUserDefinedReportCategoryID(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal UserDefinedReportCategoryID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.DynamicReport)

            LoadByUserDefinedReportCategoryID = From DynamicReport In ReportingDbContext.GetQuery(Of Database.Entities.DynamicReport)
                                                Where DynamicReport.UserDefinedReportCategoryID = UserDefinedReportCategoryID
                                                Select DynamicReport

        End Function
        Public Function LoadByDynamicReportID(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal DynamicReportID As Integer) As Reporting.Database.Entities.DynamicReport

            Try

                LoadByDynamicReportID = (From DynamicReport In ReportingDbContext.GetQuery(Of Database.Entities.DynamicReport)
                                         Where DynamicReport.ID = DynamicReportID
                                         Select DynamicReport).SingleOrDefault

            Catch ex As Exception
                LoadByDynamicReportID = Nothing
            End Try

        End Function
        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.DynamicReport)

            Load = From DynamicReport In ReportingDbContext.GetQuery(Of Database.Entities.DynamicReport)
                   Select DynamicReport

        End Function
        Public Function LoadByTemplateCode(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal TemplateCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.DynamicReport)

            LoadByTemplateCode = From DynamicReport In ReportingDbContext.GetQuery(Of Database.Entities.DynamicReport)
                                 Where DynamicReport.TemplateCode = TemplateCode
                                 Select DynamicReport

        End Function
        Public Function Insert(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal Type As AdvantageFramework.Reporting.DynamicReports,
                               ByVal Description As String, ByVal CreatedByUserCode As String, ByVal CreatedDate As Date, ByVal AllowCellMerge As Boolean,
                               ByVal AutoSizeColumnsWhenPrinting As Boolean, ByVal PrintHeader As Boolean, ByVal PrintFooter As Boolean, ByVal PrintGroupFooter As Boolean,
                               ByVal PrintSelectedRowsOnly As Boolean, ByVal PrintFilterInformation As Boolean,
                               ByVal ShowAutoFilterRow As Boolean, ByVal ActiveFilter As String,
                               ByVal ShowViewCaption As Boolean, ByVal ShowGroupByBox As Boolean,
                               ByVal UserDefinedReportCategoryID As Nullable(Of Integer),
                               ByVal DashboardLayout As Byte(),
                               ByVal TemplateCode As String,
                               ByRef DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                DynamicReport = New AdvantageFramework.Reporting.Database.Entities.DynamicReport

                DynamicReport.DbContext = ReportingDbContext
                DynamicReport.Type = Type
                DynamicReport.Description = Description
                DynamicReport.CreatedByUserCode = CreatedByUserCode
                DynamicReport.CreatedDate = CreatedDate
                DynamicReport.AllowCellMerge = AllowCellMerge
                DynamicReport.AutoSizeColumnsWhenPrinting = AutoSizeColumnsWhenPrinting
                DynamicReport.PrintHeader = PrintHeader
                DynamicReport.PrintFooter = PrintFooter
                DynamicReport.PrintGroupFooter = PrintGroupFooter
                DynamicReport.PrintSelectedRowsOnly = PrintSelectedRowsOnly
                DynamicReport.PrintFilterInformation = PrintFilterInformation
                DynamicReport.ShowAutoFilterRow = ShowAutoFilterRow
                DynamicReport.UpdatedByUserCode = CreatedByUserCode
                DynamicReport.UpdatedDate = CreatedDate
                DynamicReport.ActiveFilter = ActiveFilter
                DynamicReport.ShowViewCaption = ShowViewCaption
                DynamicReport.ShowGroupByBox = ShowGroupByBox
                DynamicReport.UserDefinedReportCategoryID = UserDefinedReportCategoryID
                DynamicReport.DashboardLayout = DashboardLayout
                DynamicReport.TemplateCode = TemplateCode

                Inserted = Insert(ReportingDbContext, DynamicReport)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ReportingDbContext.DynamicReports.Add(DynamicReport)

                ErrorText = DynamicReport.ValidateEntity(IsValid)

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
        Public Function Update(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ReportingDbContext.UpdateObject(DynamicReport)

                ErrorText = DynamicReport.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing
            Dim DynamicReportSummaryItem As AdvantageFramework.Reporting.Database.Entities.DynamicReportSummaryItem = Nothing
            Dim DynamicReportUnboundColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportUnboundColumn = Nothing
            Dim DynamicReportSetting As AdvantageFramework.Database.Entities.DynamicReportSettings = Nothing

            Try

                For Each DynamicReportColumn In AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.LoadByDynamicReportID(ReportingDbContext, DynamicReport.ID).ToList

                    If AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.Delete(ReportingDbContext, DynamicReportColumn) = False Then

                        IsValid = False
                        ErrorText = "Failed to delete dynamic report."
                        Exit For

                    End If

                Next

                For Each DynamicReportSummaryItem In AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.LoadByDynamicReportID(ReportingDbContext, DynamicReport.ID).ToList

                    If AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.Delete(ReportingDbContext, DynamicReportSummaryItem) = False Then

                        IsValid = False
                        ErrorText = "Failed to delete dynamic report."
                        Exit For

                    End If

                Next

                For Each DynamicReportUnboundColumn In AdvantageFramework.Reporting.Database.Procedures.DynamicReportUnboundColumn.LoadByDynamicReportID(ReportingDbContext, DynamicReport.ID).ToList

                    If AdvantageFramework.Reporting.Database.Procedures.DynamicReportUnboundColumn.Delete(ReportingDbContext, DynamicReportUnboundColumn) = False Then

                        IsValid = False
                        ErrorText = "Failed to delete dynamic report."
                        Exit For

                    End If

                Next

                For Each DynamicReportSetting In AdvantageFramework.Database.Procedures.DynamicReportSettings.LoadByDynamicReportSettingsReportID(DataContext, DynamicReport.ID).ToList

                    If AdvantageFramework.Database.Procedures.DynamicReportSettings.Delete(DataContext, DynamicReportSetting) = False Then

                        IsValid = False
                        ErrorText = "Failed to delete dynamic report."
                        Exit For

                    End If

                Next

                If IsValid Then

                    ReportingDbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.ADV_SERVICE_REPORT_SCHEDULE WHERE REPORT_ID = {0}", DynamicReport.ID))

                    ReportingDbContext.DeleteEntityObject(DynamicReport)

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
