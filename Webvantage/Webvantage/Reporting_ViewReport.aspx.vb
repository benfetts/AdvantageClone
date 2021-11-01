
Imports DevExpress.Pdf
Imports DevExpress.XtraReports.Web

Public Class Reporting_ViewReport
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _Report As Integer = -1
    Protected _BackButtonURL As String = ""

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Protected Overrides Sub OnInit(ByVal e As EventArgs)

        'objects
        Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
        Dim Criteria As Integer = Nothing
        Dim FilterString As String = Nothing
        Dim [From] As Date = Nothing
        Dim [To] As Date = Nothing
        Dim exReport As AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReport = Nothing
        Dim RecReport As AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts = Nothing
        Dim InvoiceNumbers As Integer() = Nothing
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing

        MyBase.OnInit(e)



        If Me.IsPostBack = False AndAlso Me.IsCallback = False Then

            Session("ReportViewer") = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        If Request.QueryString("Report") IsNot Nothing Then

                            _Report = CType(Request.QueryString("Report"), Long)

                            If AdvantageFramework.EnumUtilities.IsMemberOfEnum(GetType(AdvantageFramework.Reporting.ReportTypes), _Report) = False Then

                                _Report = -1

                            End If

                        End If

                    Catch ex As Exception
                        _Report = -1
                    End Try

                    If _Report <> -1 Then

                        ParameterDictionary = New Generic.Dictionary(Of String, Object)

                        If _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV10Detail OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV10Summary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Detail OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Summary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11Detail OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11Summary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11JobComp OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV2Summary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV2Detail OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV3Summary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV3JobComp OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV4Summary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV4Detail OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV5Summary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV5CliDivPrd OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV6 OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV7 OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV8 OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV29 OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30Detail OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30Summary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30JobComp OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV31 OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9Detail OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9Summary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9JobComp Then

                            ParameterDictionary("JobDetailAnalysis_Include") = Session("JobDetailAnalysis_Include")
                            ParameterDictionary("JobDetailAnalysis_ExcludeNonBillableHours") = Session("JobDetailAnalysis_ExcludeNonBillableHours")
                            ParameterDictionary("JobDetailAnalysis_ExcludeZeroHours") = Session("JobDetailAnalysis_ExcludeZeroHours")
                            ParameterDictionary("JobDetailAnalysis_SelectedOffices") = Session("JobDetailAnalysis_SelectedOffices")
                            ParameterDictionary("JobDetailAnalysis_SelectedClients") = Session("JobDetailAnalysis_SelectedClients")
                            ParameterDictionary("JobDetailAnalysis_SelectedJobs") = Session("JobDetailAnalysis_SelectedJobs")
                            ParameterDictionary("JobDetailAnalysis_SelectedAccountExecutives") = Session("JobDetailAnalysis_SelectedAccountExecutives")
                            ParameterDictionary("JobDetailAnalysis_SelectedSalesClasses") = Session("JobDetailAnalysis_SelectedSalesClasses")
                            ParameterDictionary("JobDetailAnalysis_SortBy") = Session("JobDetailAnalysis_SortBy")
                            ParameterDictionary("JobDetailAnalysis_SelectedDivisions") = Session("JobDetailAnalysis_SelectedDivisions")
                            ParameterDictionary("JobDetailAnalysis_SelectedProducts") = Session("JobDetailAnalysis_SelectedProducts")
                            ParameterDictionary("JobDetailAnalysis_DateCutOff") = Session("JobDetailAnalysis_DateCutOff")
                            ParameterDictionary("JobDetailAnalysis_SuppressZeroMU") = Session("JobDetailAnalysis_SuppressZeroMUDown")

                            Page.Title = "Job Detail Analysis Report"

                        ElseIf _Report = AdvantageFramework.Reporting.ReportTypes.UserDefined Then

                            ParameterDictionary("UserDefinedReportID") = Session("UserDefinedReportID")

                            _BackButtonURL = "Reporting_UserDefinedReports.aspx"

                            UserDefinedReport = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(ReportingDbContext, Session("UserDefinedReportID"))

                            If UserDefinedReport IsNot Nothing Then

                                Me.Title = UserDefinedReport.Description

                                If UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11JobComp OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV3Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV3JobComp OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5CliDivPrd OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV6 OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV7 OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV8 OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV29 OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30JobComp OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV31 OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9JobComp Then

                                    ParameterDictionary("JobDetailAnalysis_Include") = Session("JobDetailAnalysis_Include")
                                    ParameterDictionary("JobDetailAnalysis_ExcludeNonBillableHours") = Session("JobDetailAnalysis_ExcludeNonBillableHours")
                                    ParameterDictionary("JobDetailAnalysis_ExcludeZeroHours") = Session("JobDetailAnalysis_ExcludeZeroHours")
                                    ParameterDictionary("JobDetailAnalysis_SelectedOffices") = Session("JobDetailAnalysis_SelectedOffices")
                                    ParameterDictionary("JobDetailAnalysis_SelectedClients") = Session("JobDetailAnalysis_SelectedClients")
                                    ParameterDictionary("JobDetailAnalysis_SelectedJobs") = Session("JobDetailAnalysis_SelectedJobs")
                                    ParameterDictionary("JobDetailAnalysis_SelectedAccountExecutives") = Session("JobDetailAnalysis_SelectedAccountExecutives")
                                    ParameterDictionary("JobDetailAnalysis_SelectedSalesClasses") = Session("JobDetailAnalysis_SelectedSalesClasses")
                                    ParameterDictionary("JobDetailAnalysis_SortBy") = Session("JobDetailAnalysis_SortBy")
                                    ParameterDictionary("JobDetailAnalysis_SelectedDivisions") = Session("JobDetailAnalysis_SelectedDivisions")
                                    ParameterDictionary("JobDetailAnalysis_SelectedProducts") = Session("JobDetailAnalysis_SelectedProducts")
                                    ParameterDictionary("JobDetailAnalysis_DateCutOff") = Session("JobDetailAnalysis_DateCutOff")
                                    ParameterDictionary("JobDetailAnalysis_SuppressZeroMU") = Session("JobDetailAnalysis_SuppressZeroMUDown")

                                ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.EstimateForm Then

                                    '_ParameterDictionary("EstimateQuote") = EstimateQuote
                                    ParameterDictionary("EstimateNumber") = Session("Estimate_SelectedEstimateNumber")
                                    ParameterDictionary("EstimateComponent") = Session("Estimate_SelectedEstimateComponentNumber")
                                    ParameterDictionary("EstimateQuote") = Session("Estimate_SelectedEstimateQuote")
                                    ParameterDictionary("EstimateUserID") = Session("Estimate_SelectedUserCode")

                                ElseIf UserDefinedReport.AdvancedReportWriterType <> AdvantageFramework.Reporting.AdvancedReportWriterReports.SecurityPermission AndAlso
                                        UserDefinedReport.AdvancedReportWriterType <> AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeSummary AndAlso
                                        UserDefinedReport.AdvancedReportWriterType <> AdvantageFramework.Reporting.AdvancedReportWriterReports.Custom Then

                                    Criteria = Session("DRPT_Criteria")
                                    FilterString = Session("DRPT_FilterString")
                                    [From] = Session("DRPT_From")
                                    [To] = Session("DRPT_To")

                                    If TypeOf Session("DRPT_ParameterDictionary") Is Generic.Dictionary(Of String, Object) Then

                                        ParameterDictionary = Session("DRPT_ParameterDictionary")
                                        ParameterDictionary("UserDefinedReportID") = Session("UserDefinedReportID")

                                    End If

                                    Try

                                        ParameterDictionary("ShowJobsWithNoDetails") = Session("DRPT_ShowJobsWithNoDetails")

                                    Catch ex As Exception
                                        ParameterDictionary("ShowJobsWithNoDetails") = False
                                    End Try

                                End If

                            End If

                        ElseIf _Report = AdvantageFramework.Reporting.ReportTypes.SecurityPermission OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.EmployeeSummary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.GroupSecurityPermission OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.GroupSummary Then

                            _BackButtonURL = "Security_SelectReport.aspx"

                            If Session("SecurityReportParameterDictionary") IsNot Nothing Then

                                ParameterDictionary = Session("SecurityReportParameterDictionary")

                            End If

                            Page.Title = "Security Report"

                        ElseIf _Report = AdvantageFramework.Reporting.ReportTypes.DirectTime Then

                            ParameterDictionary("DirectTimeStartDate") = Session("DirectTime_StartDate")
                            ParameterDictionary("DirectTimeEndDate") = Session("DirectTime_EndDate")
                            ParameterDictionary("DirectTimeClientCode") = Session("DirectTime_ClientCode")
                            ParameterDictionary("DirectTimeJobNumber") = Session("DirectTime_JobNumber")
                            ParameterDictionary("DirectTimeComponentNumber") = Session("DirectTime_ComponentNumber")
                            ParameterDictionary("DirectTimeEmployeeCode") = Session("DirectTime_EmployeeCode")
                            ParameterDictionary("DirectTimePageBreak") = Session("DirectTime_PageBreak")

                            Page.Title = "Direct TIme Report"

                        Else

                            If Session("Report_ParameterDictionary") IsNot Nothing Then

                                ParameterDictionary = Session("Report_ParameterDictionary")

                            End If

                            Page.Title = "View Report"

                        End If


                        If _Report = AdvantageFramework.Reporting.ReportTypes.EmployeeExpenseReport AndAlso ParameterDictionary("IncludeReceipts") = True Then

                            InvoiceNumbers = ParameterDictionary("InvoiceNumbers")

                            If ParameterDictionary("IncludeReport") = False Then

                                RecReport = ExpenseReciptPrinting(Nothing, InvoiceNumbers(0))

                                If RecReport IsNot Nothing Then

                                    ASPxDocumentViewer.Report = RecReport

                                    'Session("ReportViewer") = RecReport

                                End If

                            Else

                                exReport = AdvantageFramework.Reporting.Reports.CreateReport(_Session, _Report, ParameterDictionary, Criteria, FilterString, [From], [To])

                                exReport.CreateDocument()

                                ExpenseReciptPrinting(exReport, InvoiceNumbers(0))

                                ASPxDocumentViewer.Report = exReport

                                'Session("ReportViewer") = exReport

                            End If

                            Page.Title = "View Report"

                        ElseIf _Report = AdvantageFramework.Reporting.ReportTypes.EmployeeExpenseReport Then

                            XtraReport = AdvantageFramework.Reporting.Reports.CreateReport(_Session, _Report, ParameterDictionary, Criteria, FilterString, [From], [To])

                            ASPxDocumentViewer.Report = XtraReport

                            'Session("ReportViewer") = XtraReport

                            Page.Title = "View Report"

                        Else

                            XtraReport = AdvantageFramework.Reporting.Reports.CreateReport(_Session, _Report, ParameterDictionary, Criteria, FilterString, [From], [To])

                            ASPxDocumentViewer.Report = XtraReport

                            'Session("ReportViewer") = XtraReport

                        End If

                        If XtraReport IsNot Nothing Then
                            If XtraReport.Parameters.Count > 0 Then
                                Session("ReportParameters") = 1
                            End If
                        End If

                        If UserDefinedReport IsNot Nothing Then

                            If String.IsNullOrWhiteSpace(Session("UDR_FilterReport_FilterString")) = False Then

                                ASPxDocumentViewer.Report.FilterString = Session("UDR_FilterReport_FilterString")

                            Else

                                If String.IsNullOrWhiteSpace(ASPxDocumentViewer.Report.FilterString) = False Then

                                    Session("UDR_FilterReport_FilterString") = ASPxDocumentViewer.Report.FilterString

                                End If

                            End If

                        End If

                    End If

                End Using

            End Using

        Else

            If Session("ReportParameters") = 1 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            If Request.QueryString("Report") IsNot Nothing Then

                                _Report = CType(Request.QueryString("Report"), Long)

                                If AdvantageFramework.EnumUtilities.IsMemberOfEnum(GetType(AdvantageFramework.Reporting.ReportTypes), _Report) = False Then

                                    _Report = -1

                                End If

                            End If

                        Catch ex As Exception
                            _Report = -1
                        End Try

                        If _Report <> -1 Then

                            ParameterDictionary = New Generic.Dictionary(Of String, Object)

                            If _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV10Detail OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV10Summary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Detail OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Summary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11Detail OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11Summary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11JobComp OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV2Summary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV2Detail OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV3Summary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV3JobComp OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV4Summary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV4Detail OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV5Summary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV5CliDivPrd OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV6 OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV7 OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV8 OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV29 OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30Detail OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30Summary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30JobComp OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV31 OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9Detail OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9Summary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9JobComp Then

                                ParameterDictionary("JobDetailAnalysis_Include") = Session("JobDetailAnalysis_Include")
                                ParameterDictionary("JobDetailAnalysis_ExcludeNonBillableHours") = Session("JobDetailAnalysis_ExcludeNonBillableHours")
                                ParameterDictionary("JobDetailAnalysis_ExcludeZeroHours") = Session("JobDetailAnalysis_ExcludeZeroHours")
                                ParameterDictionary("JobDetailAnalysis_SelectedOffices") = Session("JobDetailAnalysis_SelectedOffices")
                                ParameterDictionary("JobDetailAnalysis_SelectedClients") = Session("JobDetailAnalysis_SelectedClients")
                                ParameterDictionary("JobDetailAnalysis_SelectedJobs") = Session("JobDetailAnalysis_SelectedJobs")
                                ParameterDictionary("JobDetailAnalysis_SelectedAccountExecutives") = Session("JobDetailAnalysis_SelectedAccountExecutives")
                                ParameterDictionary("JobDetailAnalysis_SelectedSalesClasses") = Session("JobDetailAnalysis_SelectedSalesClasses")
                                ParameterDictionary("JobDetailAnalysis_SortBy") = Session("JobDetailAnalysis_SortBy")
                                ParameterDictionary("JobDetailAnalysis_SelectedDivisions") = Session("JobDetailAnalysis_SelectedDivisions")
                                ParameterDictionary("JobDetailAnalysis_SelectedProducts") = Session("JobDetailAnalysis_SelectedProducts")
                                ParameterDictionary("JobDetailAnalysis_DateCutOff") = Session("JobDetailAnalysis_DateCutOff")
                                ParameterDictionary("JobDetailAnalysis_SuppressZeroMU") = Session("JobDetailAnalysis_SuppressZeroMUDown")

                            ElseIf _Report = AdvantageFramework.Reporting.ReportTypes.UserDefined Then

                                ParameterDictionary("UserDefinedReportID") = Session("UserDefinedReportID")

                                _BackButtonURL = "Reporting_UserDefinedReports.aspx"

                                UserDefinedReport = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(ReportingDbContext, Session("UserDefinedReportID"))

                                If UserDefinedReport IsNot Nothing Then

                                    If UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11JobComp OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV3Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV3JobComp OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5CliDivPrd OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV6 OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV7 OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV8 OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV29 OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30JobComp OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV31 OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9JobComp Then

                                        ParameterDictionary("JobDetailAnalysis_Include") = Session("JobDetailAnalysis_Include")
                                        ParameterDictionary("JobDetailAnalysis_ExcludeNonBillableHours") = Session("JobDetailAnalysis_ExcludeNonBillableHours")
                                        ParameterDictionary("JobDetailAnalysis_ExcludeZeroHours") = Session("JobDetailAnalysis_ExcludeZeroHours")
                                        ParameterDictionary("JobDetailAnalysis_SelectedOffices") = Session("JobDetailAnalysis_SelectedOffices")
                                        ParameterDictionary("JobDetailAnalysis_SelectedClients") = Session("JobDetailAnalysis_SelectedClients")
                                        ParameterDictionary("JobDetailAnalysis_SelectedJobs") = Session("JobDetailAnalysis_SelectedJobs")
                                        ParameterDictionary("JobDetailAnalysis_SelectedAccountExecutives") = Session("JobDetailAnalysis_SelectedAccountExecutives")
                                        ParameterDictionary("JobDetailAnalysis_SelectedSalesClasses") = Session("JobDetailAnalysis_SelectedSalesClasses")
                                        ParameterDictionary("JobDetailAnalysis_SortBy") = Session("JobDetailAnalysis_SortBy")
                                        ParameterDictionary("JobDetailAnalysis_SelectedDivisions") = Session("JobDetailAnalysis_SelectedDivisions")
                                        ParameterDictionary("JobDetailAnalysis_SelectedProducts") = Session("JobDetailAnalysis_SelectedProducts")
                                        ParameterDictionary("JobDetailAnalysis_DateCutOff") = Session("JobDetailAnalysis_DateCutOff")
                                        ParameterDictionary("JobDetailAnalysis_SuppressZeroMU") = Session("JobDetailAnalysis_SuppressZeroMUDown")

                                    ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.EstimateForm Then

                                        '_ParameterDictionary("EstimateQuote") = EstimateQuote
                                        ParameterDictionary("EstimateNumber") = Session("Estimate_SelectedEstimateNumber")
                                        ParameterDictionary("EstimateComponent") = Session("Estimate_SelectedEstimateComponentNumber")
                                        ParameterDictionary("EstimateQuote") = Session("Estimate_SelectedEstimateQuote")
                                        ParameterDictionary("EstimateUserID") = Session("Estimate_SelectedUserCode")

                                    ElseIf UserDefinedReport.AdvancedReportWriterType <> AdvantageFramework.Reporting.AdvancedReportWriterReports.SecurityPermission AndAlso
                                        UserDefinedReport.AdvancedReportWriterType <> AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeSummary AndAlso
                                        UserDefinedReport.AdvancedReportWriterType <> AdvantageFramework.Reporting.AdvancedReportWriterReports.Custom Then

                                        Criteria = Session("DRPT_Criteria")
                                        FilterString = Session("DRPT_FilterString")
                                        [From] = Session("DRPT_From")
                                        [To] = Session("DRPT_To")

                                        If TypeOf Session("DRPT_ParameterDictionary") Is Generic.Dictionary(Of String, Object) Then

                                            ParameterDictionary = Session("DRPT_ParameterDictionary")
                                            ParameterDictionary("UserDefinedReportID") = Session("UserDefinedReportID")

                                        End If

                                        Try

                                            ParameterDictionary("ShowJobsWithNoDetails") = Session("DRPT_ShowJobsWithNoDetails")

                                        Catch ex As Exception
                                            ParameterDictionary("ShowJobsWithNoDetails") = False
                                        End Try

                                    End If

                                End If

                            ElseIf _Report = AdvantageFramework.Reporting.ReportTypes.SecurityPermission OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.EmployeeSummary OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.GroupSecurityPermission OrElse
                                _Report = AdvantageFramework.Reporting.ReportTypes.GroupSummary Then

                                _BackButtonURL = "Security_SelectReport.aspx"

                                If Session("SecurityReportParameterDictionary") IsNot Nothing Then

                                    ParameterDictionary = Session("SecurityReportParameterDictionary")

                                End If

                            ElseIf _Report = AdvantageFramework.Reporting.ReportTypes.DirectTime Then

                                ParameterDictionary("DirectTimeStartDate") = Session("DirectTime_StartDate")
                                ParameterDictionary("DirectTimeEndDate") = Session("DirectTime_EndDate")
                                ParameterDictionary("DirectTimeClientCode") = Session("DirectTime_ClientCode")
                                ParameterDictionary("DirectTimeJobNumber") = Session("DirectTime_JobNumber")
                                ParameterDictionary("DirectTimeComponentNumber") = Session("DirectTime_ComponentNumber")
                                ParameterDictionary("DirectTimeEmployeeCode") = Session("DirectTime_EmployeeCode")
                                ParameterDictionary("DirectTimePageBreak") = Session("DirectTime_PageBreak")

                            Else

                                If Session("Report_ParameterDictionary") IsNot Nothing Then

                                    ParameterDictionary = Session("Report_ParameterDictionary")

                                End If

                            End If


                            If _Report = AdvantageFramework.Reporting.ReportTypes.EmployeeExpenseReport AndAlso ParameterDictionary("IncludeReceipts") = True Then

                                InvoiceNumbers = ParameterDictionary("InvoiceNumbers")

                                If ParameterDictionary("IncludeReport") = False Then

                                    RecReport = ExpenseReciptPrinting(Nothing, InvoiceNumbers(0))

                                    If RecReport IsNot Nothing Then

                                        ASPxDocumentViewer.Report = RecReport

                                        'Session("ReportViewer") = RecReport

                                    End If

                                Else

                                    exReport = AdvantageFramework.Reporting.Reports.CreateReport(_Session, _Report, ParameterDictionary, Criteria, FilterString, [From], [To])

                                    exReport.CreateDocument()

                                    ExpenseReciptPrinting(exReport, InvoiceNumbers(0))

                                    ASPxDocumentViewer.Report = exReport

                                    'Session("ReportViewer") = exReport

                                End If

                            ElseIf _Report = AdvantageFramework.Reporting.ReportTypes.EmployeeExpenseReport Then

                                XtraReport = AdvantageFramework.Reporting.Reports.CreateReport(_Session, _Report, ParameterDictionary, Criteria, FilterString, [From], [To])

                                ASPxDocumentViewer.Report = XtraReport

                                'Session("ReportViewer") = XtraReport

                            Else

                                XtraReport = AdvantageFramework.Reporting.Reports.CreateReport(_Session, _Report, ParameterDictionary, Criteria, FilterString, [From], [To])

                                ASPxDocumentViewer.Report = XtraReport

                                'Session("ReportViewer") = XtraReport

                            End If

                            If XtraReport.Parameters.Count > 0 Then
                                Session("ReportParameters") = 1
                            End If

                            If UserDefinedReport IsNot Nothing Then

                                If String.IsNullOrWhiteSpace(Session("UDR_FilterReport_FilterString")) = False Then

                                    ASPxDocumentViewer.Report.FilterString = Session("UDR_FilterReport_FilterString")

                                Else

                                    If String.IsNullOrWhiteSpace(ASPxDocumentViewer.Report.FilterString) = False Then

                                        Session("UDR_FilterReport_FilterString") = ASPxDocumentViewer.Report.FilterString

                                    End If

                                End If

                            End If

                        End If

                    End Using

                End Using

            End If

            'If _Report <> AdvantageFramework.Reporting.ReportTypes.EmployeeExpenseReport Then

            '    XtraReport = AdvantageFramework.Reporting.Reports.CreateReport(_Session, _Report, ParameterDictionary, Criteria, FilterString, [From], [To])

            '    ASPxDocumentViewer.Report = XtraReport

            'End If

            'If Session("ReportViewer") IsNot Nothing Then

            '    ASPxDocumentViewer.Report = Session("ReportViewer")

            'End If

        End If

    End Sub

    Private Function ExpenseReciptPrinting(ByRef Report As AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReport, ByVal InvoiceNumber As Integer)

        Dim RecReportAll As AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts = Nothing

        Try

            Dim RecReport As AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts = Nothing
            Dim picture As DevExpress.XtraReports.UI.XRPictureBox
            Dim DocumentRepository As New DocumentRepository(_Session.ConnectionString)
            Dim DocumentIDs As Generic.List(Of Integer) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If InvoiceNumber > 0 Then


                    Try

                        DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC [dbo].[advsp_expense_get_receipts] {0};", InvoiceNumber)).ToList

                    Catch ex As Exception
                        DocumentIDs = Nothing
                    End Try

                    If DocumentIDs IsNot Nothing AndAlso DocumentIDs.Count > 0 Then

                        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                        RecReportAll = New AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts
                        RecReportAll.CreateDocument()

                        For Each DocumentID As Integer In DocumentIDs

                            Document = Nothing

                            Try

                                Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                            Catch ex As Exception
                                Document = Nothing
                            End Try
                            If Document IsNot Nothing Then

                                If Report Is Nothing Then

                                    Try

                                        If Document.MIMEType.Contains("image") Then

                                            RecReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts

                                            picture = New DevExpress.XtraReports.UI.XRPictureBox

                                            Dim impersonateUser As Boolean
                                            Dim AliasAccount As AliasAccount

                                            impersonateUser = DocumentRepository.UserName <> ""

                                            If impersonateUser = True Then

                                                AliasAccount.BeginImpersonation(DocumentRepository.UserName, DocumentRepository.UserDomain, DocumentRepository.UserPassword)

                                            End If

                                            picture.Image = System.Drawing.Image.FromFile(DocumentRepository.Path & "\" & Document.FileSystemFileName)

                                            If impersonateUser Then

                                                AliasAccount.EndImpersonation()

                                            End If


                                            picture.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze
                                            picture.Size = New Drawing.Size(750, 750)

                                            RecReport.Bands(DevExpress.XtraReports.UI.BandKind.Detail).Controls.Add(picture)

                                            RecReport.CreateDocument()

                                            RecReportAll.Pages.Add(RecReport.Pages(0))

                                        End If
                                        If Document.FileName.ToUpper.EndsWith(".PDF") Then

                                            Dim PDFDocument As Aspose.Pdf.Document = Nothing
                                            Dim Resolution As Aspose.Pdf.Devices.Resolution = Nothing
                                            Dim PDFPngDevice As Aspose.Pdf.Devices.PngDevice = Nothing
                                            Dim MemoryStream As System.IO.MemoryStream = Nothing
                                            Dim License As Aspose.Pdf.License = Nothing

                                            License = New Aspose.Pdf.License

                                            License.SetLicense("Aspose.Total.lic")
                                            License.Embedded = True

                                            Dim impersonateUser As Boolean
                                            Dim AliasAccount As AliasAccount

                                            impersonateUser = DocumentRepository.UserName <> ""

                                            If impersonateUser = True Then

                                                AliasAccount.BeginImpersonation(DocumentRepository.UserName, DocumentRepository.UserDomain, DocumentRepository.UserPassword)

                                            End If

                                            PDFDocument = New Aspose.Pdf.Document(DocumentRepository.Path & "\" & Document.FileSystemFileName)

                                            If impersonateUser Then

                                                AliasAccount.EndImpersonation()

                                            End If


                                            Resolution = New Aspose.Pdf.Devices.Resolution(1900)
                                            PDFPngDevice = New Aspose.Pdf.Devices.PngDevice(750, 1000, Resolution)

                                            For Each pdfpage In PDFDocument.Pages

                                                MemoryStream = New System.IO.MemoryStream

                                                PDFPngDevice.Process(pdfpage, MemoryStream)

                                                If PDFDocument.PageInfo.IsLandscape Then
                                                    RecReport.Landscape = True
                                                End If

                                                RecReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts

                                                picture = New DevExpress.XtraReports.UI.XRPictureBox
                                                picture.Image = System.Drawing.Image.FromStream(MemoryStream)
                                                picture.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
                                                picture.Size = New Drawing.Size(750, 1000)


                                                RecReport.Bands(DevExpress.XtraReports.UI.BandKind.Detail).Controls.Add(picture)

                                                RecReport.CreateDocument()

                                                RecReportAll.Pages.Add(RecReport.Pages(0))

                                            Next

                                        End If
                                        If Document.FileName.ToUpper.EndsWith(".DOC") OrElse Document.FileName.ToUpper.EndsWith(".DOCX") Then

                                            Dim WordDocument As Aspose.Words.Document = Nothing
                                            Dim PageInfo As Aspose.Words.Rendering.PageInfo = Nothing
                                            Dim PageSize As System.Drawing.Size = Nothing
                                            Dim MemoryStream As System.IO.MemoryStream = Nothing
                                            Dim License As Aspose.Words.License = Nothing

                                            License = New Aspose.Words.License

                                            License.SetLicense("Aspose.Total.lic")

                                            Dim impersonateUser As Boolean
                                            Dim AliasAccount As AliasAccount

                                            impersonateUser = DocumentRepository.UserName <> ""

                                            If impersonateUser = True Then

                                                AliasAccount.BeginImpersonation(DocumentRepository.UserName, DocumentRepository.UserDomain, DocumentRepository.UserPassword)

                                            End If

                                            WordDocument = New Aspose.Words.Document(DocumentRepository.Path & "\" & Document.FileSystemFileName)

                                            If impersonateUser Then

                                                AliasAccount.EndImpersonation()

                                            End If

                                            For x As Integer = 0 To WordDocument.PageCount - 1

                                                PageInfo = WordDocument.GetPageInfo(x)

                                                PageSize = PageInfo.GetSizeInPixels(0.8, 100)

                                                Using Bitmap = New System.Drawing.Bitmap(PageSize.Width, PageSize.Height)

                                                    Bitmap.SetResolution(100, 100)

                                                    Using Graphics = System.Drawing.Graphics.FromImage(Bitmap)

                                                        Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

                                                        Graphics.FillRectangle(Drawing.Brushes.White, 0, 0, PageSize.Width, PageSize.Height)

                                                        WordDocument.RenderToScale(x, Graphics, 0, 0, 0.8)

                                                    End Using

                                                    MemoryStream = New System.IO.MemoryStream

                                                    Bitmap.Save(MemoryStream, System.Drawing.Imaging.ImageFormat.Bmp)

                                                End Using

                                                RecReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts

                                                picture = New DevExpress.XtraReports.UI.XRPictureBox
                                                picture.Image = System.Drawing.Image.FromStream(MemoryStream)
                                                picture.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
                                                picture.Size = New Drawing.Size(750, 1000)

                                                RecReport.Bands(DevExpress.XtraReports.UI.BandKind.Detail).Controls.Add(picture)

                                                RecReport.CreateDocument()

                                                RecReportAll.Pages.Add(RecReport.Pages(0))

                                            Next

                                        End If

                                    Catch ex As Exception
                                    End Try

                                Else

                                    Try

                                        If Document.MIMEType.Contains("image") Then

                                            RecReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts

                                            picture = New DevExpress.XtraReports.UI.XRPictureBox

                                            Dim impersonateUser As Boolean
                                            Dim AliasAccount As AliasAccount

                                            impersonateUser = DocumentRepository.UserName <> ""

                                            If impersonateUser = True Then

                                                AliasAccount.BeginImpersonation(DocumentRepository.UserName, DocumentRepository.UserDomain, DocumentRepository.UserPassword)

                                            End If

                                            picture.Image = System.Drawing.Image.FromFile(DocumentRepository.Path & "\" & Document.FileSystemFileName)

                                            If impersonateUser Then

                                                AliasAccount.EndImpersonation()

                                            End If

                                            picture.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze
                                            picture.Size = New Drawing.Size(400, 750)

                                            RecReport.Bands(DevExpress.XtraReports.UI.BandKind.Detail).Controls.Add(picture)

                                            RecReport.CreateDocument()

                                            Report.Pages.Add(RecReport.Pages(0))

                                        End If
                                        If Document.FileName.ToUpper.EndsWith(".PDF") Then

                                            Dim PDFDocument As Aspose.Pdf.Document = Nothing
                                            Dim Resolution As Aspose.Pdf.Devices.Resolution = Nothing
                                            Dim PDFPngDevice As Aspose.Pdf.Devices.PngDevice = Nothing
                                            Dim MemoryStream As System.IO.MemoryStream = Nothing
                                            Dim License As Aspose.Pdf.License = Nothing

                                            License = New Aspose.Pdf.License

                                            License.SetLicense("Aspose.Total.lic")
                                            License.Embedded = True

                                            Dim impersonateUser As Boolean
                                            Dim AliasAccount As AliasAccount

                                            impersonateUser = DocumentRepository.UserName <> ""

                                            If impersonateUser = True Then

                                                AliasAccount.BeginImpersonation(DocumentRepository.UserName, DocumentRepository.UserDomain, DocumentRepository.UserPassword)

                                            End If

                                            PDFDocument = New Aspose.Pdf.Document(DocumentRepository.Path & "\" & Document.FileSystemFileName)

                                            If impersonateUser Then

                                                AliasAccount.EndImpersonation()

                                            End If

                                            Resolution = New Aspose.Pdf.Devices.Resolution(1900)
                                            PDFPngDevice = New Aspose.Pdf.Devices.PngDevice(750, 1000, Resolution)

                                            For Each pdfpage In PDFDocument.Pages

                                                MemoryStream = New System.IO.MemoryStream

                                                PDFPngDevice.Process(pdfpage, MemoryStream)

                                                If PDFDocument.PageInfo.IsLandscape Then
                                                    RecReport.Landscape = True
                                                End If

                                                RecReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts

                                                picture = New DevExpress.XtraReports.UI.XRPictureBox
                                                picture.Image = System.Drawing.Image.FromStream(MemoryStream)
                                                picture.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
                                                picture.Size = New Drawing.Size(750, 1000)

                                                RecReport.Bands(DevExpress.XtraReports.UI.BandKind.Detail).Controls.Add(picture)

                                                RecReport.CreateDocument()

                                                Report.Pages.Add(RecReport.Pages(0))

                                            Next

                                        End If
                                        If Document.FileName.ToUpper.EndsWith(".DOC") OrElse Document.FileName.ToUpper.EndsWith(".DOCX") Then

                                            Dim WordDocument As Aspose.Words.Document = Nothing
                                            Dim PageInfo As Aspose.Words.Rendering.PageInfo = Nothing
                                            Dim PageSize As System.Drawing.Size = Nothing
                                            Dim MemoryStream As System.IO.MemoryStream = Nothing
                                            Dim License As Aspose.Words.License = Nothing

                                            License = New Aspose.Words.License

                                            License.SetLicense("Aspose.Total.lic")

                                            Dim impersonateUser As Boolean
                                            Dim AliasAccount As AliasAccount

                                            impersonateUser = DocumentRepository.UserName <> ""

                                            If impersonateUser = True Then

                                                AliasAccount.BeginImpersonation(DocumentRepository.UserName, DocumentRepository.UserDomain, DocumentRepository.UserPassword)

                                            End If

                                            WordDocument = New Aspose.Words.Document(DocumentRepository.Path & "\" & Document.FileSystemFileName)

                                            If impersonateUser Then

                                                AliasAccount.EndImpersonation()

                                            End If

                                            For x As Integer = 0 To WordDocument.PageCount - 1

                                                PageInfo = WordDocument.GetPageInfo(x)

                                                PageSize = PageInfo.GetSizeInPixels(0.8, 100)

                                                Using Bitmap = New System.Drawing.Bitmap(PageSize.Width, PageSize.Height)

                                                    Bitmap.SetResolution(100, 100)

                                                    Using Graphics = System.Drawing.Graphics.FromImage(Bitmap)

                                                        Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

                                                        Graphics.FillRectangle(Drawing.Brushes.White, 0, 0, PageSize.Width, PageSize.Height)

                                                        WordDocument.RenderToScale(x, Graphics, 0, 0, 0.8)

                                                    End Using

                                                    MemoryStream = New System.IO.MemoryStream

                                                    Bitmap.Save(MemoryStream, System.Drawing.Imaging.ImageFormat.Bmp)

                                                End Using

                                                RecReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts

                                                picture = New DevExpress.XtraReports.UI.XRPictureBox
                                                picture.Image = System.Drawing.Image.FromStream(MemoryStream)
                                                picture.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
                                                picture.Size = New Drawing.Size(750, 1000)

                                                RecReport.Bands(DevExpress.XtraReports.UI.BandKind.Detail).Controls.Add(picture)

                                                RecReport.CreateDocument()

                                                Report.Pages.Add(RecReport.Pages(0))

                                            Next

                                        End If

                                    Catch ex As Exception
                                    End Try

                                End If

                            End If

                        Next

                    End If

                End If

            End Using

        Catch ex As Exception
            RecReportAll = Nothing
        End Try

        Return RecReportAll

    End Function

#Region "  Form Event Handlers "

    Private Sub Reporting_ViewReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim ReportToolbarButtonFilter As DevExpress.XtraReports.Web.ReportToolbarButton = Nothing
        Dim ReportToolbarButtonBack As DevExpress.XtraReports.Web.ReportToolbarButton = Nothing
        Dim ReportToolbarButtonExpandAll As DevExpress.XtraReports.Web.ReportToolbarButton = Nothing
        Dim ReportToolbarButtonCollapseAll As DevExpress.XtraReports.Web.ReportToolbarButton = Nothing
        Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing

        Try

            If Request.QueryString("Report") IsNot Nothing Then

                _Report = CType(Request.QueryString("Report"), Long)

                If AdvantageFramework.EnumUtilities.IsMemberOfEnum(GetType(AdvantageFramework.Reporting.ReportTypes), _Report) = False Then

                    _Report = -1

                End If

            End If

        Catch ex As Exception
            _Report = -1
        End Try

        Try

            ReportToolbarButtonFilter = ASPxDocumentViewer.ToolbarItems.OfType(Of DevExpress.XtraReports.Web.ReportToolbarButton).Single(Function(Button) Button.Name = "Filter")

        Catch ex As Exception

        End Try

        Try

            ReportToolbarButtonBack = ASPxDocumentViewer.ToolbarItems.OfType(Of DevExpress.XtraReports.Web.ReportToolbarButton).Single(Function(Button) Button.Name = "Back")

        Catch ex As Exception

        End Try

        Try

            ReportToolbarButtonExpandAll = ASPxDocumentViewer.ToolbarItems.OfType(Of DevExpress.XtraReports.Web.ReportToolbarButton).Single(Function(Button) Button.Name = "ExpandAll")

        Catch ex As Exception

        End Try

        Try

            ReportToolbarButtonCollapseAll = ASPxDocumentViewer.ToolbarItems.OfType(Of DevExpress.XtraReports.Web.ReportToolbarButton).Single(Function(Button) Button.Name = "CollapseAll")

        Catch ex As Exception

        End Try

        If ReportToolbarButtonFilter IsNot Nothing Then

            If _Report = AdvantageFramework.Reporting.ReportTypes.UserDefined OrElse _Report = AdvantageFramework.Reporting.ReportTypes.BillingWorksheetProductionSummary OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.BillingWorksheetProductionUnbilledDetail OrElse _Report = AdvantageFramework.Reporting.ReportTypes.BillingWorksheetMediaSummary OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.BillingWorksheetProductionUnbilledDetailV2 OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.BillingWorksheetProductionUnbilledDetailWithComments Then

                ReportToolbarButtonFilter.Enabled = True

            Else

                ReportToolbarButtonFilter.Enabled = False

            End If

        End If

        If ReportToolbarButtonBack IsNot Nothing Then

            If _Report = AdvantageFramework.Reporting.ReportTypes.UserDefined Then

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    UserDefinedReport = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(ReportingDbContext, Session("UserDefinedReportID"))


                    If UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11JobComp OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV3Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV3JobComp OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5CliDivPrd OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV6 OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV7 OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV8 OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV29 OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30JobComp OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV31 OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9Detail OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9Summary OrElse
                                       UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9JobComp Then

                        ReportToolbarButtonBack.Enabled = True
                        _BackButtonURL = String.Format("Reporting_JobDetailAnalysis.aspx?UserDefinedReportID={0}&AdvancedReportWriterReport={1}", Session("UserDefinedReportID"), UserDefinedReport.AdvancedReportWriterType)

                    ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.SecurityPermission OrElse
                            UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeSummary OrElse
                            UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.GroupSecurityPermission OrElse
                            UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.GroupSummary Then

                        ReportToolbarButtonBack.Enabled = True
                        _BackButtonURL = "Security_SelectReport.aspx"
                    Else
                        ReportToolbarButtonBack.Enabled = False
                        _BackButtonURL = "Reporting_UserDefinedReports.aspx"
                    End If


                End Using


            ElseIf _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV10Detail OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV10Summary OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Detail OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Summary OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11Detail OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11Summary OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11JobComp OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV2Summary OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV2Detail OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV3Summary OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV3JobComp OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV4Summary OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV4Detail OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV5Summary OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV5CliDivPrd OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV6 OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV7 OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV8 OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV29 OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30Detail OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30Summary OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30JobComp OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV31 OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9Detail OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9Summary OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9JobComp Then

                ReportToolbarButtonBack.Enabled = True
                _BackButtonURL = "Reporting_JobDetailAnalysis.aspx"

            ElseIf _Report = AdvantageFramework.Reporting.ReportTypes.SecurityPermission OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.EmployeeSummary OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.GroupSecurityPermission OrElse
                    _Report = AdvantageFramework.Reporting.ReportTypes.GroupSummary Then

                ReportToolbarButtonBack.Enabled = True
                _BackButtonURL = "Security_SelectReport.aspx"

            Else

                ReportToolbarButtonBack.Enabled = False

            End If

        End If

        If ReportToolbarButtonExpandAll IsNot Nothing Then

            If _Report = AdvantageFramework.Reporting.ReportTypes.ServiceFeeReconciliationReport OrElse (_Report = AdvantageFramework.Reporting.ReportTypes.UserDefined AndAlso TypeOf ASPxDocumentViewer.Report Is AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ServiceFeeReconciliationReport) Then

                ReportToolbarButtonExpandAll.Enabled = True

            Else

                ReportToolbarButtonExpandAll.Enabled = False

            End If

        End If

        If ReportToolbarButtonCollapseAll IsNot Nothing Then

            If _Report = AdvantageFramework.Reporting.ReportTypes.ServiceFeeReconciliationReport OrElse (_Report = AdvantageFramework.Reporting.ReportTypes.UserDefined AndAlso TypeOf ASPxDocumentViewer.Report Is AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ServiceFeeReconciliationReport) Then

                ReportToolbarButtonCollapseAll.Enabled = True

            Else

                ReportToolbarButtonCollapseAll.Enabled = False

            End If

        End If

    End Sub

    Private Sub ASPxDocumentViewer_CacheReportDocument(sender As Object, e As CacheReportDocumentEventArgs) Handles ASPxDocumentViewer.CacheReportDocument
        Try
            Session("ReportViewer") = e.SaveDocumentToMemoryStream()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ASPxDocumentViewer_RestoreReportDocumentFromCache(sender As Object, e As RestoreReportDocumentFromCacheEventArgs) Handles ASPxDocumentViewer.RestoreReportDocumentFromCache
        Try
            If Session("ReportViewer") IsNot Nothing Then
                e.RestoreDocumentFromStream(Session("ReportViewer"))
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

End Class
