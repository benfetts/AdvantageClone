Namespace Desktop.Presentation

    Public Class CustomReportsForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadCustomReports()

            For Each Assembly In My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath).GetFiles("*ADVCR.dll")



            Next

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim CustomReportsForm As CustomReportsForm = Nothing

            CustomReportsForm = New CustomReportsForm

            CustomReportsForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub CustomReportsForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_ViewReport.Image = My.Resources.DynamicReportImage

            LoadCustomReports()

            ButtonItemActions_ViewReport.Enabled = DataGridViewForm_CustomReports.HasOnlyOneSelectedRow

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_ViewReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_ViewReport.Click

            'objects
            Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim UserDefinedReportID As Integer = 0
            Dim DynamicReport As Reporting.DynamicReports = AdvantageFramework.Reporting.DynamicReports.Alerts
            Dim LoadReport As Boolean = True
            Dim Criteria As Integer = 0
            Dim FilterString As String = ""
            Dim [From] As Date = Nothing
            Dim [To] As Date = Nothing
            Dim ShowJobsWithNoDetails As Boolean = False
            Dim LoadData As Boolean = True
            Dim FeePostPeriodFrom As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim FeePostPeriodTo As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim SelectedCriteria As IEnumerable = Nothing
            Dim FeeTimeFrom As Date = Nothing
            Dim FeeTimeTo As Date = Nothing
            Dim IncomeOnlySalesClassCodes As Generic.List(Of String) = Nothing
            Dim IncomeOnlyFunctionCodes As Generic.List(Of String) = Nothing
            Dim ProductionCommissionSalesClassCodes As Generic.List(Of String) = Nothing
            Dim ProductionCommissionFunctionCodes As Generic.List(Of String) = Nothing
            Dim ServiceFeeTypeCodes As Generic.List(Of String) = Nothing
            Dim ServiceFeeReconciliationGroupByOption As AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions = Nothing
            Dim ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles = Nothing

            If DataGridViewForm_CustomReports.HasOnlyOneSelectedRow Then

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    UserDefinedReportID = DataGridViewForm_CustomReports.GetFirstSelectedRowBookmarkValue

                    UserDefinedReport = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(ReportingDbContext, UserDefinedReportID)

                    If UserDefinedReport IsNot Nothing Then

                        If UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.SecurityPermission OrElse
                                UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeSummary OrElse
                                UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.Custom Then

                            LoadData = True
                            FilterString = Nothing
                            [From] = Nothing
                            [To] = Nothing

                        Else

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

                                FilterString = Nothing
                                [From] = Nothing
                                [To] = Nothing

                                If AdvantageFramework.Reporting.Presentation.JobDetailAnalysisInitialLoadingDialog.ShowFormDialog(AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Summary, ParameterDictionary, True, UserDefinedReport.AdvancedReportWriterType) = System.Windows.Forms.DialogResult.Cancel Then

                                    LoadData = False

                                End If

                            ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.ServiceFeeReconciliation Then

                                If AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeReconciliationForm.ShowFormDialog(FeePostPeriodFrom, FeePostPeriodTo, SelectedCriteria, FeeTimeFrom, FeeTimeTo,
                                                                                                                                    IncomeOnlySalesClassCodes, IncomeOnlyFunctionCodes, ProductionCommissionSalesClassCodes, ProductionCommissionFunctionCodes,
                                                                                                                                    ServiceFeeTypeCodes, ServiceFeeReconciliationGroupByOption, ServiceFeeReconciliationSummaryStyle) = System.Windows.Forms.DialogResult.OK Then

                                    ParameterDictionary = New Generic.Dictionary(Of String, Object)

                                    ParameterDictionary("FeePostPeriodFrom") = FeePostPeriodFrom
                                    ParameterDictionary("FeePostPeriodTo") = FeePostPeriodTo
                                    ParameterDictionary("FeeTimeFrom") = FeeTimeFrom
                                    ParameterDictionary("FeeTimeTo") = FeeTimeTo
                                    ParameterDictionary("ServiceFeeReconciliationGroupByOption") = ServiceFeeReconciliationGroupByOption
                                    ParameterDictionary("ServiceFeeReconciliationSummaryStyle") = ServiceFeeReconciliationSummaryStyle

                                    Me.ShowWaitForm()
                                    Me.ShowWaitForm("Loading Data...")

                                    Try

                                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                                ParameterDictionary("DataSource") = AdvantageFramework.Reporting.LoadServiceFeeReconciliationData(Me.Session, SecurityDbContext, DbContext, Nothing, SelectedCriteria, IncomeOnlySalesClassCodes,
                                                                                                                                                  IncomeOnlyFunctionCodes, ProductionCommissionSalesClassCodes, ProductionCommissionFunctionCodes,
                                                                                                                                                  ServiceFeeTypeCodes, FeePostPeriodFrom, FeePostPeriodTo, FeeTimeFrom, FeeTimeTo, Nothing, Nothing, Nothing, 0, True)

                                            End Using

                                        End Using

                                    Catch ex As Exception

                                    End Try

                                    Me.CloseWaitForm()

                                Else

                                    LoadData = False

                                End If

                            Else

                                Try

                                    DynamicReport = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.DynamicReports), CType(UserDefinedReport.AdvancedReportWriterType, AdvantageFramework.Reporting.AdvancedReportWriterReports).ToString)

                                Catch ex As Exception
                                    LoadReport = False
                                End Try

                                If LoadReport Then

                                    LoadData = AdvantageFramework.Desktop.Presentation.LaunchInitialLoadingDialog(DynamicReport, Criteria, FilterString, From, [To], ShowJobsWithNoDetails, ParameterDictionary, Nothing)

                                End If

                            End If

                        End If

                        If LoadData Then

                            If ParameterDictionary Is Nothing Then

                                ParameterDictionary = New Generic.Dictionary(Of String, Object)

                            End If

                            ParameterDictionary("UserDefinedReportID") = UserDefinedReportID

                            If DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailItemAccountSplit Then

                                ParameterDictionary("ShowJobsWithNoDetails") = ShowJobsWithNoDetails

                            End If

                            AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, AdvantageFramework.Reporting.ReportTypes.UserDefined, ParameterDictionary, Criteria, FilterString, [From], [To])

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridViewForm_UserDefinedReports_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_CustomReports.SelectionChangedEvent

            ButtonItemActions_ViewReport.Enabled = DataGridViewForm_CustomReports.HasOnlyOneSelectedRow

        End Sub

#End Region

#End Region

    End Class

End Namespace
