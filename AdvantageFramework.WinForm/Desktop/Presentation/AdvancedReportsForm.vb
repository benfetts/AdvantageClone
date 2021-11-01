Namespace Desktop.Presentation

    Public Class AdvancedReportsForm

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
        Private Sub LoadGrid()

            'objects
            Dim UserDefinedReportCategoryID As Integer = 0

            Try

                UserDefinedReportCategoryID = ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.SelectedValue

            Catch ex As Exception
                UserDefinedReportCategoryID = 0
            End Try

            If UserDefinedReportCategoryID > 0 Then

                DataGridViewForm_Reports.DataSource = AdvantageFramework.Reporting.LoadAvailableUserDefinedReports(Me.Session).Where(Function(Entity) Entity.UserDefinedReportCategoryID.GetValueOrDefault(0) = UserDefinedReportCategoryID).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

            Else

                DataGridViewForm_Reports.DataSource = AdvantageFramework.Reporting.LoadAvailableUserDefinedReports(Me.Session).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

            End If

            DataGridViewForm_Reports.CurrentView.BestFitColumns()

            EnableOrDisableActions()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Add.Enabled = True

            ButtonItemActions_View.Enabled = DataGridViewForm_Reports.HasOnlyOneSelectedRow
            ButtonItemActions_UpdateInfo.Enabled = DataGridViewForm_Reports.HasOnlyOneSelectedRow
            ButtonItemActions_EditReport.Enabled = DataGridViewForm_Reports.HasOnlyOneSelectedRow
            ButtonItemActions_Delete.Enabled = DataGridViewForm_Reports.HasASelectedRow
            ButtonItemActions_Copy.Enabled = DataGridViewForm_Reports.HasOnlyOneSelectedRow

            ButtonItemActions_Refresh.Enabled = True

        End Sub
        Private Sub ViewAdvancedReport()

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

            If DataGridViewForm_Reports.HasOnlyOneSelectedRow Then

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        UserDefinedReportID = DataGridViewForm_Reports.GetFirstSelectedRowBookmarkValue(0)

                    Catch ex As Exception
                        UserDefinedReportID = 0
                    End Try

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

                            ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.PurchaseOrder Then

                                FilterString = Nothing
                                [From] = Nothing
                                [To] = Nothing

                                If AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderReportsDialog.ShowFormDialog(True, ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                                    LoadData = False

                                End If

                            ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.OneQuotePerPage Then

                                FilterString = Nothing
                                [From] = Nothing
                                [To] = Nothing

                                If AdvantageFramework.ProjectManagement.Reports.Presentation.EstimateReportsDialog.ShowFormDialog(True, ParameterDictionary, UserDefinedReport.AdvancedReportWriterType) = System.Windows.Forms.DialogResult.Cancel Then

                                    LoadData = False

                                End If

                            ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.EstimateForm Then

                                FilterString = Nothing
                                [From] = Nothing
                                [To] = Nothing

                                If AdvantageFramework.ProjectManagement.Reports.Presentation.EstimateReportsDialog.ShowFormDialog(True, ParameterDictionary, UserDefinedReport.AdvancedReportWriterType) = System.Windows.Forms.DialogResult.Cancel Then

                                    LoadData = False

                                End If

                            ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaSpecifications Then

                                FilterString = Nothing
                                [From] = Nothing
                                [To] = Nothing

                                If AdvantageFramework.Reporting.Presentation.MediaSpecificationsInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                                    LoadData = False

                                End If

                            ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaSpecificationsByDestination Then

                                FilterString = Nothing
                                [From] = Nothing
                                [To] = Nothing

                                If AdvantageFramework.Reporting.Presentation.MediaSpecificationsInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

                                    LoadData = False

                                End If

                            ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeUtilizationBreakoutNonDirect Then

                                FilterString = Nothing
                                [From] = Nothing
                                [To] = Nothing

                                If AdvantageFramework.Reporting.Presentation.EmployeeUtilizationInitialLoadingDialog.ShowFormDialog(ParameterDictionary) = System.Windows.Forms.DialogResult.Cancel Then

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

                End Using

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a report to view.")

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AdvancedReportsForm As AdvancedReportsForm = Nothing

            AdvancedReportsForm = New AdvancedReportsForm

            AdvancedReportsForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AdvancedReportsForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim UserDefinedReportCategoryBindingSource As System.Windows.Forms.BindingSource = Nothing

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_View.Image = My.Resources.DynamicReportImage
            ButtonItemActions_Add.Image = My.Resources.AddImage
            ButtonItemActions_UpdateInfo.Image = My.Resources.UpdateReportInfoImage
            ButtonItemActions_EditReport.Image = My.Resources.ReportEditImage
            ButtonItemActions_Delete.Image = My.Resources.DeleteImage
            ButtonItemActions_Copy.Image = My.Resources.CopyImage
            ButtonItemActions_Refresh.Image = My.Resources.RefreshImage
            ButtonItemActions_Export.Image = My.Resources.DatabaseExportImage
            ButtonItemActions_Import.Image = My.Resources.DatabaseImportImage

            DataGridViewForm_Reports.MultiSelect = True

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.DisplayMember = "Description"
                    ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.ValueMember = "ID"

                    UserDefinedReportCategoryBindingSource = New System.Windows.Forms.BindingSource

                    UserDefinedReportCategoryBindingSource.DataSource = (From UserDefinedReportCategory In AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Load(ReportingDbContext)
                                                                         Select New With {.ID = UserDefinedReportCategory.ID,
                                                                                          .Description = UserDefinedReportCategory.Description}).OrderBy(Function(c) c.Description).ToList

                    AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(UserDefinedReportCategoryBindingSource, ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.DisplayMember,
                                                                                                      ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.ValueMember,
                                                                                                      "[All]", -1, True, True)

                    ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.DataSource = UserDefinedReportCategoryBindingSource

                    ComboBoxItemReportCategory_ReportCategory.SelectedIndex = 0

                End Using

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxItemReportCategory_ReportCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxItemReportCategory_ReportCategory.SelectedIndexChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.ShowWaitForm()

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_View.Click

            If DataGridViewForm_Reports.HasOnlyOneSelectedRow Then

                ViewAdvancedReport()

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            AdvantageFramework.Desktop.Presentation.AdvancedReportWriterEditForm.ShowFormDialog(Me.Session, Reporting.UDRTypes.Advanced)

        End Sub
        Private Sub ButtonItemActions_EditReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_EditReport.Click

            'objects
            Dim ReportID As Integer = 0

            Try

                ReportID = DataGridViewForm_Reports.GetFirstSelectedRowBookmarkValue(0)

            Catch ex As Exception
                ReportID = 0
            End Try

            If ReportID > 0 Then

                AdvantageFramework.Desktop.Presentation.AdvancedReportWriterEditForm.ShowFormDialog(Me.Session, Reporting.UDRTypes.Advanced, ReportID)

            End If

        End Sub
        Private Sub ButtonItemActions_UpdateInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_UpdateInfo.Click

            'objects
            Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
            Dim ReportID As Integer = 0
            Dim ReloadGrid As Boolean = False

            Try

                ReportID = DataGridViewForm_Reports.GetFirstSelectedRowBookmarkValue(0)

            Catch ex As Exception
                ReportID = 0
            End Try

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                UserDefinedReport = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(ReportingDbContext, ReportID)

            End Using

            If UserDefinedReport IsNot Nothing Then

                If AdvantageFramework.Desktop.Presentation.UserDefinedReportEditDialog.ShowFormDialog(Reporting.UDRTypes.Advanced, UserDefinedReport.ID, UserDefinedReport.AdvancedReportWriterType, UserDefinedReport.Description, UserDefinedReport.UserDefinedReportCategoryID, False) = Windows.Forms.DialogResult.OK Then

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        UserDefinedReport.UpdatedByUserCode = Me.Session.UserCode
                        UserDefinedReport.UpdatedDate = Now

                        ReloadGrid = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.Update(ReportingDbContext, UserDefinedReport)

                    End Using

                End If

            End If

            If ReloadGrid Then

                LoadGrid()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
            Dim ReportID As Integer = 0
            Dim ReloadGrid As Boolean = False

            If DataGridViewForm_Reports.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete this report?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm()

                    Try

                        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each ReportID In DataGridViewForm_Reports.GetAllSelectedRowsBookmarkValues.OfType(Of Integer).ToList

                                Try

                                    UserDefinedReport = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(ReportingDbContext, ReportID)

                                Catch ex As Exception
                                    UserDefinedReport = Nothing
                                End Try

                                If UserDefinedReport IsNot Nothing Then

                                    ReloadGrid = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.Delete(ReportingDbContext, UserDefinedReport)

                                End If

                            Next

                        End Using

                        If ReloadGrid Then

                            LoadGrid()

                        End If

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.ShowWaitForm()

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_Reports_RowDoubleClickEvent() Handles DataGridViewForm_Reports.RowDoubleClickEvent

            If DataGridViewForm_Reports.HasOnlyOneSelectedRow Then

                ViewAdvancedReport()

            End If

        End Sub
        Private Sub DataGridViewForm_Reports_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_Reports.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            'objects
            Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
            Dim UserDefinedReportID As Integer = 0
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim DynamicReportXML As AdvantageFramework.Reporting.Database.Classes.DynamicReportXML = Nothing
            Dim DynamicReportID As Integer = 0
            Dim Folder As String = ""
            Dim XMLString As String = ""
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim ContinueSave As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            End Using

            If Agency.IsASP.GetValueOrDefault(0) = 0 Then

                ContinueSave = AdvantageFramework.WinForm.Presentation.BrowseForFolder(Folder)

            Else

                Folder = AdvantageFramework.FileSystem.LoadHostedClientDownloadLocation(Agency)

                If My.Computer.FileSystem.DirectoryExists(Folder) Then

                    ContinueSave = True

                End If

            End If

            If ContinueSave Then

                Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder, "\")

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        UserDefinedReportID = DataGridViewForm_Reports.GetFirstSelectedRowBookmarkValue(0)

                    Catch ex As Exception
                        UserDefinedReportID = 0
                    End Try

                    UserDefinedReport = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(ReportingDbContext, UserDefinedReportID)

                    If UserDefinedReport IsNot Nothing Then

                        Try

                            XtraReport = AdvantageFramework.Reporting.Reports.CreateUserDefinedReport(UserDefinedReport)

                        Catch ex As Exception
                            XtraReport = Nothing
                        End Try

                        If XtraReport IsNot Nothing Then

                            XtraReport.SaveLayout(Folder & AdvantageFramework.FileSystem.CreateValidFileName(XtraReport.DisplayName) & ".repx")

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub ButtonItemActions_Import_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Import.Click

            If AdvantageFramework.Reporting.Presentation.ReportImportForm.ShowFormDialog() = Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
