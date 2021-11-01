Namespace Security.Database.Procedures.ServiceFeeReconciliationReport

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

        Public Function LoadByServiceFeeReconciliationReportID(ByVal DbContext As Database.DbContext, ByVal ServiceFeeReconciliationReportID As Integer) As Database.Entities.ServiceFeeReconciliationReport

            Try

                LoadByServiceFeeReconciliationReportID = (From ServiceFeeReconciliationReport In DbContext.GetQuery(Of Database.Entities.ServiceFeeReconciliationReport)
                                                          Where ServiceFeeReconciliationReport.ID = ServiceFeeReconciliationReportID
                                                          Select ServiceFeeReconciliationReport).SingleOrDefault

            Catch ex As Exception
                LoadByServiceFeeReconciliationReportID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ServiceFeeReconciliationReport)

            Load = From ServiceFeeReconciliationReport In DbContext.GetQuery(Of Database.Entities.ServiceFeeReconciliationReport)
                   Select ServiceFeeReconciliationReport

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal Description As String, _
                               ByVal CreatedByUserCode As String, ByVal CreatedDate As Date, ByVal AllowCellMerge As Boolean, _
                               ByVal AutoSizeColumnsWhenPrinting As Boolean, ByVal PrintHeader As Boolean, ByVal PrintFooter As Boolean, ByVal PrintGroupFooter As Boolean, _
                               ByVal PrintSelectedRowsOnly As Boolean, ByVal PrintFilterInformation As Boolean, _
                               ByVal ShowAutoFilterRow As Boolean, ByVal ActiveFilter As String, _
                               ByVal ShowViewCaption As Boolean, ByVal ShowGroupByBox As Boolean, _
                               ByVal GroupByOption As AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions, _
                               ByVal SummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles, _
                               ByRef ServiceFeeReconciliationReport As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                ServiceFeeReconciliationReport = New AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport

                ServiceFeeReconciliationReport.DbContext = DbContext
                ServiceFeeReconciliationReport.Description = Description
                ServiceFeeReconciliationReport.CreatedByUserCode = CreatedByUserCode
                ServiceFeeReconciliationReport.CreatedDate = CreatedDate
                ServiceFeeReconciliationReport.AllowCellMerge = AllowCellMerge
                ServiceFeeReconciliationReport.AutoSizeColumnsWhenPrinting = AutoSizeColumnsWhenPrinting
                ServiceFeeReconciliationReport.PrintHeader = PrintHeader
                ServiceFeeReconciliationReport.PrintFooter = PrintFooter
                ServiceFeeReconciliationReport.PrintGroupFooter = PrintGroupFooter
                ServiceFeeReconciliationReport.PrintSelectedRowsOnly = PrintSelectedRowsOnly
                ServiceFeeReconciliationReport.PrintFilterInformation = PrintFilterInformation
                ServiceFeeReconciliationReport.ShowAutoFilterRow = ShowAutoFilterRow
                ServiceFeeReconciliationReport.UpdatedByUserCode = CreatedByUserCode
                ServiceFeeReconciliationReport.UpdatedDate = CreatedDate
                ServiceFeeReconciliationReport.ActiveFilter = ActiveFilter
                ServiceFeeReconciliationReport.ShowViewCaption = ShowViewCaption
                ServiceFeeReconciliationReport.ShowGroupByBox = ShowGroupByBox
                ServiceFeeReconciliationReport.GroupByOption = GroupByOption
                ServiceFeeReconciliationReport.SummaryStyle = SummaryStyle

                Inserted = Insert(DbContext, ServiceFeeReconciliationReport)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationReport As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ServiceFeeReconciliationReports.Add(ServiceFeeReconciliationReport)

                ErrorText = ServiceFeeReconciliationReport.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationReport As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ServiceFeeReconciliationReport)

                ErrorText = ServiceFeeReconciliationReport.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ServiceFeeReconciliationReport As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim ServiceFeeReconciliationReportColumn As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReportColumn = Nothing
            Dim ServiceFeeReconciliationReportSummaryItem As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReportSummaryItem = Nothing

            Try

                For Each ServiceFeeReconciliationReportColumn In AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportColumn.LoadByServiceFeeReconciliationReportID(DbContext, ServiceFeeReconciliationReport.ID).ToList

                    If AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportColumn.Delete(DbContext, ServiceFeeReconciliationReportColumn) = False Then

                        IsValid = False
                        ErrorText = "Failed to delete dynamic report."
                        Exit For

                    End If

                Next

                For Each ServiceFeeReconciliationReportSummaryItem In AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportSummaryItem.LoadByServiceFeeReconciliationReportID(DbContext, ServiceFeeReconciliationReport.ID).ToList

                    If AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReportSummaryItem.Delete(DbContext, ServiceFeeReconciliationReportSummaryItem) = False Then

                        IsValid = False
                        ErrorText = "Failed to delete dynamic report."
                        Exit For

                    End If

                Next

                If IsValid Then

                    DbContext.DeleteEntityObject(ServiceFeeReconciliationReport)

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
