Namespace Reporting.Presentation.Classes

    Public Class ReportCommandHandler
        Implements DevExpress.XtraReports.UserDesigner.ICommandHandler

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _XRDesignMdiController As DevExpress.XtraReports.UserDesigner.XRDesignMdiController = Nothing
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _Type As Integer = 0
        Private _Description As String = ""
        Private _UserDefinedReportCategoryID As Nullable(Of Integer) = 0
        Private _ReportType As Reporting.UDRTypes = Reporting.UDRTypes.Advanced

#End Region

#Region " Properties "

        Public Property Type As Integer
            Get
                Type = _Type
            End Get
            Set(value As Integer)
                _Type = value
            End Set
        End Property
        Public Property Description As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        Public Property UserDefinedReportCategoryID As Nullable(Of Integer)
            Get
                UserDefinedReportCategoryID = _UserDefinedReportCategoryID
            End Get
            Set(value As Nullable(Of Integer))
                _UserDefinedReportCategoryID = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal XrDesignMdiController As DevExpress.XtraReports.UserDesigner.XRDesignMdiController, ByVal Session As AdvantageFramework.Security.Session,
                       Optional ByVal ReportType As Reporting.UDRTypes = UDRTypes.Advanced)

            _XRDesignMdiController = XrDesignMdiController
            _Session = Session
            _ReportType = ReportType

        End Sub
        Public Overridable Function CanHandleCommand(ByVal ReportCommand As DevExpress.XtraReports.UserDesigner.ReportCommand, ByRef useNextHandler As Boolean) As Boolean Implements DevExpress.XtraReports.UserDesigner.ICommandHandler.CanHandleCommand

            If ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.NewReport Then

                CanHandleCommand = True
                useNextHandler = False

            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.OpenFile Then

                CanHandleCommand = True
                useNextHandler = False

            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.SaveFile Then

                CanHandleCommand = True
                useNextHandler = False

            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.SaveFileAs Then

                CanHandleCommand = True
                useNextHandler = False

            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.ShowPreviewTab Then

                CanHandleCommand = True
                useNextHandler = False

            Else

                CanHandleCommand = False

            End If

        End Function
        Public Overridable Sub HandleCommand(ByVal ReportCommand As DevExpress.XtraReports.UserDesigner.ReportCommand, ByVal Args() As Object) Implements DevExpress.XtraReports.UserDesigner.ICommandHandler.HandleCommand

            'objects
            Dim SelectedObjects As IEnumerable = Nothing
            Dim AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports = AdvancedReportWriterReports.Alerts
            Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
            Dim UserDefinedReportID As Integer = 0
            Dim Description As String = ""
            Dim ReportDefinition As String = ""
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
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

            If ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.NewReport Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.AdvancedReportWriterReport, True, False, SelectedObjects) = System.Windows.Forms.DialogResult.OK Then

                    Try

                        AdvancedReportWriterReport = (From Entity In SelectedObjects
                                                      Select Entity.ID).FirstOrDefault

                    Catch ex As Exception
                        AdvancedReportWriterReport = Nothing
                    Finally

                        Try

                            If AdvancedReportWriterReport <> Nothing Then

                                _XRDesignMdiController.OpenReport(AdvantageFramework.Reporting.Reports.CreateAdvancedReportWriterReport(AdvancedReportWriterReport))

                            End If

                        Catch ex As Exception

                        End Try

                    End Try

                End If

            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.OpenFile Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.UserDefinedReport, True, False, SelectedObjects) = System.Windows.Forms.DialogResult.OK Then

                    Try

                        UserDefinedReportID = (From Entity In SelectedObjects
                                               Select Entity.ID).FirstOrDefault

                    Catch ex As Exception
                        UserDefinedReportID = 0
                    Finally

                        Try

                            If UserDefinedReportID <> 0 Then

                                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                    UserDefinedReport = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(ReportingDbContext, UserDefinedReportID)

                                    If UserDefinedReport IsNot Nothing Then

                                        _XRDesignMdiController.OpenReport(AdvantageFramework.Reporting.Reports.CreateUserDefinedReport(UserDefinedReport))

                                    End If

                                End Using

                            End If

                        Catch ex As Exception
                            Console.WriteLine(ex.Message)
                        End Try

                    End Try

                End If

            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.SaveFile Then

                Save()

            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.SaveFileAs Then

                SaveAs()

            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.ShowPreviewTab Then

                Save()

                If _XRDesignMdiController.ActiveDesignPanel.ReportState = DevExpress.XtraReports.UserDesigner.ReportState.Saved Then

                    If _ReportType = UDRTypes.Estimate Then

                        If DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IEstimateReport).EstimateReport = AdvantageFramework.Reporting.EstimateReportTypes.OneQuotePerPage Then

                            FilterString = Nothing
                            [From] = Nothing
                            [To] = Nothing

                            'ParameterDictionary("UserDefinedReportID") = DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).UserDefinedReportID

                            If AdvantageFramework.ProjectManagement.Reports.Presentation.EstimateReportsDialog.ShowFormDialog(True, ParameterDictionary, DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IEstimateReport).EstimateReport) = System.Windows.Forms.DialogResult.Cancel Then

                                LoadData = False

                            End If

                        End If

                    Else

                        If DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.SecurityPermission OrElse
                            DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeSummary OrElse
                            DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.Custom Then

                            LoadData = True
                            FilterString = Nothing
                            [From] = Nothing
                            [To] = Nothing

                        ElseIf DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Detail OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Summary OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Detail OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Summary OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Detail OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Summary OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11JobComp OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Summary OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Detail OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV3Summary OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV3JobComp OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Summary OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Detail OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5Summary OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5CliDivPrd OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV6 OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV7 OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV8 OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV29 OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Detail OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Summary OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30JobComp OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV31 OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9Detail OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9Summary OrElse
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9JobComp Then

                            FilterString = Nothing
                            [From] = Nothing
                            [To] = Nothing

                            If AdvantageFramework.Reporting.Presentation.JobDetailAnalysisInitialLoadingDialog.ShowFormDialog(AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Summary, ParameterDictionary, True, DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport) = System.Windows.Forms.DialogResult.Cancel Then

                                LoadData = False

                            End If

                        ElseIf DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.PurchaseOrder Then

                            FilterString = Nothing
                            [From] = Nothing
                            [To] = Nothing

                            If AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderReportsDialog.ShowFormDialog(True, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                                LoadData = False

                            End If

                        ElseIf DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.EstimateForm Then

                            FilterString = Nothing
                            [From] = Nothing
                            [To] = Nothing

                            'ParameterDictionary("UserDefinedReportID") = DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).UserDefinedReportID

                            If AdvantageFramework.ProjectManagement.Reports.Presentation.EstimateReportsDialog.ShowFormDialog(True, ParameterDictionary, DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport) = System.Windows.Forms.DialogResult.Cancel Then

                                LoadData = False

                            End If

                        ElseIf DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaSpecifications Then

                            FilterString = Nothing
                            [From] = Nothing
                            [To] = Nothing

                            If AdvantageFramework.Reporting.Presentation.MediaSpecificationsInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                                LoadData = False

                            End If

                        ElseIf DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaSpecificationsByDestination Then

                            FilterString = Nothing
                            [From] = Nothing
                            [To] = Nothing

                            If AdvantageFramework.Reporting.Presentation.MediaSpecificationsInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                                LoadData = False

                            End If

                        ElseIf DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeUtilizationBreakoutNonDirect Then

                            FilterString = Nothing
                            [From] = Nothing
                            [To] = Nothing

                            If AdvantageFramework.Reporting.Presentation.EmployeeUtilizationInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                                LoadData = False

                            End If

                        ElseIf DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeTimeForecast Then

                            'FilterString = Nothing
                            '[From] = Nothing
                            '[To] = Nothing

                            If AdvantageFramework.Reporting.Presentation.EmployeeTimeForecastInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then
                                'ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                                LoadData = False

                            End If

                        ElseIf DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ServiceFeeReconciliation Then

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

                                'Me.ShowWaitForm()
                                'Me.ShowWaitForm("Loading Data...")

                                Try

                                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                            ParameterDictionary("DataSource") = AdvantageFramework.Reporting.LoadServiceFeeReconciliationData(_Session, SecurityDbContext, DbContext, Nothing, SelectedCriteria, IncomeOnlySalesClassCodes,
                                                                                                                                              IncomeOnlyFunctionCodes, ProductionCommissionSalesClassCodes, ProductionCommissionFunctionCodes,
                                                                                                                                              ServiceFeeTypeCodes, FeePostPeriodFrom, FeePostPeriodTo, FeeTimeFrom, FeeTimeTo, Nothing, Nothing, Nothing, 0, True)

                                        End Using

                                    End Using

                                Catch ex As Exception

                                End Try

                                'Me.CloseWaitForm()

                            Else

                                LoadData = False

                            End If

                            'ElseIf DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaSpecifications Then

                            '    If AdvantageFramework.Reporting.Presentation.MediaSpecificationReportInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                            '        LoadData = False

                            '    End If

                        Else

                            Try

                                DynamicReport = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.DynamicReports), CType(DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport, AdvantageFramework.Reporting.AdvancedReportWriterReports).ToString)

                            Catch ex As Exception
                                LoadReport = False
                            End Try

                            If LoadReport Then

                                LoadData = AdvantageFramework.Desktop.Presentation.LaunchInitialLoadingDialog(DynamicReport, Criteria, FilterString, From, [To], ShowJobsWithNoDetails, ParameterDictionary, Nothing)

                            End If

                        End If

                    End If

                End If

                If LoadData Then

                    If ParameterDictionary Is Nothing Then

                        ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    End If

                    If _ReportType = UDRTypes.Estimate Then

                        ParameterDictionary("EstimateReportID") = DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IEstimateReport).EstimateReportID

                    Else

                        ParameterDictionary("UserDefinedReportID") = DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).UserDefinedReportID

                    End If

                    If DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailItemAccountSplit Then

                        ParameterDictionary("ShowJobsWithNoDetails") = ShowJobsWithNoDetails

                    End If

                    If _ReportType = UDRTypes.Estimate Then

                        AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(_Session, AdvantageFramework.Reporting.ReportTypes.EstimateReport, ParameterDictionary, Criteria, FilterString, [From], [To])

                    Else

                        AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(_Session, AdvantageFramework.Reporting.ReportTypes.UserDefined, ParameterDictionary, Criteria, FilterString, [From], [To])

                    End If

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Report must be saved before printing!")

            End If

        End Sub
        Private Sub Save()

            'objects
            Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
            Dim EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport = Nothing
            Dim UserDefinedReportID As Integer = 0

            Try

                UserDefinedReportID = DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).UserDefinedReportID

            Catch ex As Exception
                UserDefinedReportID = 0
            Finally

                Try

                    If UserDefinedReportID <> 0 Then

                        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            UserDefinedReport = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(ReportingDbContext, UserDefinedReportID)

                            If UserDefinedReport IsNot Nothing Then

                                UserDefinedReport.AdvancedReportWriterType = DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport
                                UserDefinedReport.ReportDefinition = LoadReportDefinition()
                                UserDefinedReport.UpdatedByUserCode = ReportingDbContext.UserCode
                                UserDefinedReport.UpdatedDate = Now

                                If AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.Update(ReportingDbContext, UserDefinedReport) Then

                                    _XRDesignMdiController.ActiveDesignPanel.ReportState = DevExpress.XtraReports.UserDesigner.ReportState.Saved

                                End If

                            Else

                                If AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.Insert(ReportingDbContext, DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport, Description,
                                                                                                            ReportingDbContext.UserCode, Now,
                                                                                                            LoadReportDefinition(), UserDefinedReportCategoryID, UserDefinedReport) Then

                                    _XRDesignMdiController.ActiveDesignPanel.Report.DisplayName = UserDefinedReport.Description
                                    DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).UserDefinedReportID = UserDefinedReport.ID
                                    _XRDesignMdiController.ActiveDesignPanel.ReportState = DevExpress.XtraReports.UserDesigner.ReportState.Saved

                                End If

                            End If

                        End Using

                    Else

                        If _XRDesignMdiController.ActiveDesignPanel IsNot Nothing Then

                            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                If _ReportType = UDRTypes.Estimate Then

                                    If AdvantageFramework.Reporting.Database.Procedures.EstimateReport.Insert(ReportingDbContext, DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IEstimateReport).EstimateReport, Description,
                                                                                                            ReportingDbContext.UserCode, Now,
                                                                                                            LoadReportDefinition(), UserDefinedReportCategoryID, EstimateReport) Then

                                        _XRDesignMdiController.ActiveDesignPanel.Report.DisplayName = EstimateReport.Description
                                        DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IEstimateReport).EstimateReportID = EstimateReport.ID
                                        _XRDesignMdiController.ActiveDesignPanel.ReportState = DevExpress.XtraReports.UserDesigner.ReportState.Saved

                                    End If

                                Else

                                    If AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.Insert(ReportingDbContext, DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport, Description,
                                                                                                            ReportingDbContext.UserCode, Now,
                                                                                                            LoadReportDefinition(), UserDefinedReportCategoryID, UserDefinedReport) Then

                                        _XRDesignMdiController.ActiveDesignPanel.Report.DisplayName = UserDefinedReport.Description
                                        DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).UserDefinedReportID = UserDefinedReport.ID
                                        _XRDesignMdiController.ActiveDesignPanel.ReportState = DevExpress.XtraReports.UserDesigner.ReportState.Saved

                                    End If

                                End If

                            End Using

                        End If

                    End If

                Catch ex As Exception

                End Try

            End Try

        End Sub
        Private Sub SaveAs()

            'objects
            Dim AdvancedReportWriterType As AdvantageFramework.Reporting.AdvancedReportWriterReports = AdvancedReportWriterReports.Alerts
            Dim EstimateReportType As AdvantageFramework.Reporting.EstimateReportTypes = EstimateReportTypes.OneQuotePerPage
            Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
            Dim EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport = Nothing
            Dim Description As String = ""
            Dim UserDefinedReportCategoryID As Nullable(Of Integer) = 0
            Dim ReportDefinition As String = ""

            If _ReportType = UDRTypes.Estimate Then

                EstimateReportType = DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IEstimateReport).EstimateReport

                If AdvantageFramework.Desktop.Presentation.UserDefinedReportEditDialog.ShowFormDialog(Reporting.UDRTypes.Estimate, 0, EstimateReportType, Description, UserDefinedReportCategoryID, False) = System.Windows.Forms.DialogResult.OK Then

                    _Description = Description
                    _UserDefinedReportCategoryID = UserDefinedReportCategoryID

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ReportDefinition = LoadReportDefinition()

                        If AdvantageFramework.Reporting.Database.Procedures.EstimateReport.Insert(ReportingDbContext, EstimateReportType, Description,
                                                                                                    ReportingDbContext.UserCode, Now,
                                                                                                    ReportDefinition, UserDefinedReportCategoryID, EstimateReport) Then

                            _XRDesignMdiController.ActiveDesignPanel.Report.DisplayName = EstimateReport.Description
                            DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IEstimateReport).EstimateReportID = EstimateReport.ID
                            _XRDesignMdiController.ActiveDesignPanel.ReportState = DevExpress.XtraReports.UserDesigner.ReportState.Saved

                        End If

                    End Using

                End If

            Else

                AdvancedReportWriterType = DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).AdvancedReportWriterReport

                If AdvantageFramework.Desktop.Presentation.UserDefinedReportEditDialog.ShowFormDialog(Reporting.UDRTypes.Advanced, 0, AdvancedReportWriterType, Description, UserDefinedReportCategoryID, False) = System.Windows.Forms.DialogResult.OK Then

                    _Description = Description
                    _UserDefinedReportCategoryID = UserDefinedReportCategoryID

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ReportDefinition = LoadReportDefinition()

                        If AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.Insert(ReportingDbContext, AdvancedReportWriterType, Description,
                                                                                                    ReportingDbContext.UserCode, Now,
                                                                                                    ReportDefinition, UserDefinedReportCategoryID, UserDefinedReport) Then

                            _XRDesignMdiController.ActiveDesignPanel.Report.DisplayName = UserDefinedReport.Description
                            DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IUserDefinedReport).UserDefinedReportID = UserDefinedReport.ID
                            _XRDesignMdiController.ActiveDesignPanel.ReportState = DevExpress.XtraReports.UserDesigner.ReportState.Saved

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Function LoadReportDefinition() As String

            'objects
            Dim ReportDefinition As String = ""
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            MemoryStream = New System.IO.MemoryStream

            _XRDesignMdiController.ActiveDesignPanel.Report.SaveLayout(MemoryStream)

            MemoryStream.Position = 0

            Using StreamReader = New System.IO.StreamReader(MemoryStream)

                ReportDefinition = StreamReader.ReadToEnd

            End Using

            If MemoryStream IsNot Nothing Then

                MemoryStream.Close()
                MemoryStream.Dispose()

                MemoryStream = Nothing

            End If

            LoadReportDefinition = ReportDefinition

        End Function

#End Region

    End Class

End Namespace

