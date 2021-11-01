Namespace Desktop.Presentation

    Public Class UserDefinedReportsForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FromInternalReportExport As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal FromInternalReportExport As Boolean)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _FromInternalReportExport = FromInternalReportExport

        End Sub
        Private Sub LoadGrids()

            'objects
            Dim UserDefinedReportCategoryID As Integer = 0
            Dim Application As AdvantageFramework.Security.Application = AdvantageFramework.Security.Application.Advantage

            If _FromInternalReportExport Then

                Application = Security.Application.Advantage

            Else

                Application = Session.Application

            End If

            Try

                UserDefinedReportCategoryID = ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.SelectedValue

            Catch ex As Exception
                UserDefinedReportCategoryID = 0
            End Try

            If UserDefinedReportCategoryID > 0 Then

                DataGridViewAdvancedReportWriter_Reports.DataSource = AdvantageFramework.Reporting.LoadAvailableUserDefinedReports(Me.Session).Where(Function(Entity) Entity.UserDefinedReportCategoryID.GetValueOrDefault(0) = UserDefinedReportCategoryID).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DataGridViewDynamic_Reports.DataSource = AdvantageFramework.Reporting.LoadAvailableDynamicReports(SecurityDbContext, AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Load(ReportingDbContext).Include("UserDefinedReportCategory").ToList, Application, Session.User.ID).Where(Function(Entity) Entity.UserDefinedReportCategoryID.GetValueOrDefault(0) = UserDefinedReportCategoryID).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

                    End Using

                End Using

            Else

                DataGridViewAdvancedReportWriter_Reports.DataSource = AdvantageFramework.Reporting.LoadAvailableUserDefinedReports(Me.Session).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DataGridViewDynamic_Reports.DataSource = AdvantageFramework.Reporting.LoadAvailableDynamicReports(SecurityDbContext, AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Load(ReportingDbContext).Include("UserDefinedReportCategory").ToList, Application, Session.User.ID).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

                    End Using

                End Using

            End If

            DataGridViewAdvancedReportWriter_Reports.CurrentView.BestFitColumns()
            DataGridViewDynamic_Reports.CurrentView.BestFitColumns()

            EnableOrDisableActions()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Add.Enabled = True

            If TabControlForm_ReportTypes.SelectedTab Is TabItemReportTypes_AdvancedReportWriterTab Then

                ButtonItemActions_View.Enabled = DataGridViewAdvancedReportWriter_Reports.HasOnlyOneSelectedRow
                ButtonItemActions_UpdateInfo.Enabled = DataGridViewAdvancedReportWriter_Reports.HasOnlyOneSelectedRow
                ButtonItemActions_EditReport.Enabled = DataGridViewAdvancedReportWriter_Reports.HasOnlyOneSelectedRow
                ButtonItemActions_Delete.Enabled = DataGridViewAdvancedReportWriter_Reports.HasASelectedRow
                ButtonItemActions_Copy.Enabled = DataGridViewAdvancedReportWriter_Reports.HasOnlyOneSelectedRow
                ButtonItemActions_Export.Enabled = DataGridViewAdvancedReportWriter_Reports.HasOnlyOneSelectedRow

            ElseIf TabControlForm_ReportTypes.SelectedTab Is TabItemReportTypes_DynamicTab Then

                ButtonItemActions_View.Enabled = DataGridViewDynamic_Reports.HasOnlyOneSelectedRow
                ButtonItemActions_UpdateInfo.Enabled = DataGridViewDynamic_Reports.HasOnlyOneSelectedRow
                ButtonItemActions_EditReport.Enabled = DataGridViewDynamic_Reports.HasOnlyOneSelectedRow
                ButtonItemActions_Delete.Enabled = DataGridViewDynamic_Reports.HasASelectedRow
                ButtonItemActions_Copy.Enabled = DataGridViewDynamic_Reports.HasOnlyOneSelectedRow
                ButtonItemActions_Export.Enabled = DataGridViewDynamic_Reports.HasOnlyOneSelectedRow

            Else

                ButtonItemActions_View.Enabled = False
                ButtonItemActions_UpdateInfo.Enabled = False
                ButtonItemActions_EditReport.Enabled = False
                ButtonItemActions_Delete.Enabled = False
                ButtonItemActions_Copy.Enabled = False
                ButtonItemActions_Export.Enabled = False

            End If

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

            If DataGridViewAdvancedReportWriter_Reports.HasOnlyOneSelectedRow Then

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        UserDefinedReportID = DataGridViewAdvancedReportWriter_Reports.GetFirstSelectedRowBookmarkValue(0)

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

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a report to view.")

            End If

        End Sub
        Private Sub ViewDynamicReport()

            'objects
            Dim UDReport As AdvantageFramework.Database.Classes.UDReport = Nothing

            If DataGridViewDynamic_Reports.HasOnlyOneSelectedRow Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        UDReport = DataGridViewDynamic_Reports.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        UDReport = Nothing
                    End Try

                    If UDReport IsNot Nothing Then

                        AdvantageFramework.Desktop.Presentation.DynamicReportEditForm.ShowForm(True, UDReport.ID, True)

                    End If

                End Using

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a report to view.")

            End If

        End Sub
        Private Function CreateXML(ByVal AFObject As Object, ParamArray ExtraTypes() As System.Type) As String

            'objects
            Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
            Dim XmlAttributeOverrides As System.Xml.Serialization.XmlAttributeOverrides = Nothing
            Dim XmlAttributes As System.Xml.Serialization.XmlAttributes = Nothing
            Dim XmlElementAttribute As System.Xml.Serialization.XmlElementAttribute = Nothing
            Dim StringWriter As System.IO.StringWriter = Nothing
            Dim XML As String = ""

            Try

                XmlAttributeOverrides = New System.Xml.Serialization.XmlAttributeOverrides

                For Each ExtraType In ExtraTypes

                    XmlAttributes = New System.Xml.Serialization.XmlAttributes

                    XmlElementAttribute = New System.Xml.Serialization.XmlElementAttribute

                    XmlElementAttribute.ElementName = ExtraType.Name & "s"
                    XmlElementAttribute.Type = ExtraType

                    XmlAttributes.XmlElements.Add(XmlElementAttribute)

                    XmlAttributeOverrides.Add(AFObject.GetType, XmlElementAttribute.ElementName, XmlAttributes)

                Next

                XmlSerializer = New System.Xml.Serialization.XmlSerializer(AFObject.GetType, XmlAttributeOverrides)
                StringWriter = New System.IO.StringWriter

                XmlSerializer.Serialize(StringWriter, AFObject)

                StringWriter.Close()

            Catch ex As Exception

                If StringWriter IsNot Nothing Then

                    StringWriter.Close()
                    StringWriter = Nothing

                End If

            Finally

                If StringWriter IsNot Nothing Then

                    XML = StringWriter.ToString

                End If

                CreateXML = XML

            End Try

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(Optional ByVal FromInternalReportExport As Boolean = False)

            'objects
            Dim UserDefinedReportsForm As UserDefinedReportsForm = Nothing

            UserDefinedReportsForm = New UserDefinedReportsForm(FromInternalReportExport)

            UserDefinedReportsForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub UserDefinedReportsForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

            DataGridViewAdvancedReportWriter_Reports.MultiSelect = True
            DataGridViewDynamic_Reports.MultiSelect = True

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

                LoadGrids()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxItemReportCategory_ReportCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxItemReportCategory_ReportCategory.SelectedIndexChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.ShowWaitForm()

                Try

                    LoadGrids()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_View.Click

            If TabControlForm_ReportTypes.SelectedTab Is TabItemReportTypes_AdvancedReportWriterTab Then

                If DataGridViewAdvancedReportWriter_Reports.HasOnlyOneSelectedRow Then

                    ViewAdvancedReport()

                End If

            ElseIf TabControlForm_ReportTypes.SelectedTab Is TabItemReportTypes_DynamicTab Then

                If DataGridViewDynamic_Reports.HasOnlyOneSelectedRow Then

                    ViewDynamicReport()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            If TabControlForm_ReportTypes.SelectedTab Is TabItemReportTypes_AdvancedReportWriterTab Then

                AdvantageFramework.Desktop.Presentation.AdvancedReportWriterEditForm.ShowFormDialog(Me.Session, Reporting.UDRTypes.Advanced)

            ElseIf TabControlForm_ReportTypes.SelectedTab Is TabItemReportTypes_DynamicTab Then

                AdvantageFramework.Desktop.Presentation.DynamicReportEditForm.ShowForm(False)

            End If

        End Sub
        Private Sub ButtonItemActions_EditReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_EditReport.Click

            'objects
            Dim ReportID As Integer = 0

            If TabControlForm_ReportTypes.SelectedTab Is TabItemReportTypes_AdvancedReportWriterTab Then

                Try

                    ReportID = DataGridViewAdvancedReportWriter_Reports.GetFirstSelectedRowBookmarkValue(0)

                Catch ex As Exception
                    ReportID = 0
                End Try

                If ReportID > 0 Then

                    AdvantageFramework.Desktop.Presentation.AdvancedReportWriterEditForm.ShowFormDialog(Me.Session, Reporting.UDRTypes.Advanced, ReportID)

                End If

            ElseIf TabControlForm_ReportTypes.SelectedTab Is TabItemReportTypes_DynamicTab Then

                Try

                    ReportID = DataGridViewDynamic_Reports.GetFirstSelectedRowBookmarkValue(0)

                Catch ex As Exception
                    ReportID = 0
                End Try

                If ReportID > 0 Then

                    AdvantageFramework.Desktop.Presentation.DynamicReportEditForm.ShowForm(False, ReportID, False)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_UpdateInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_UpdateInfo.Click

            'objects
            Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim UserDefinedReportType As AdvantageFramework.Reporting.UDRTypes = Reporting.UDRTypes.Advanced
            Dim ReportID As Integer = 0
            Dim ReloadGrid As Boolean = False

            If TabControlForm_ReportTypes.SelectedTab Is TabItemReportTypes_AdvancedReportWriterTab Then

                UserDefinedReportType = Reporting.UDRTypes.Advanced

                Try

                    ReportID = DataGridViewAdvancedReportWriter_Reports.GetFirstSelectedRowBookmarkValue(0)

                Catch ex As Exception
                    ReportID = 0
                End Try

            ElseIf TabControlForm_ReportTypes.SelectedTab Is TabItemReportTypes_DynamicTab Then

                UserDefinedReportType = Reporting.UDRTypes.Dynamic

                Try

                    ReportID = DataGridViewDynamic_Reports.GetFirstSelectedRowBookmarkValue(0)

                Catch ex As Exception
                    ReportID = 0
                End Try

            End If

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If UserDefinedReportType = Reporting.UDRTypes.Advanced Then

                    UserDefinedReport = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(ReportingDbContext, ReportID)

                Else

                    DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, ReportID)

                End If

            End Using

            If UserDefinedReport IsNot Nothing Then

                If AdvantageFramework.Desktop.Presentation.UserDefinedReportEditDialog.ShowFormDialog(UserDefinedReportType, UserDefinedReport.ID, UserDefinedReport.AdvancedReportWriterType, UserDefinedReport.Description, UserDefinedReport.UserDefinedReportCategoryID, False) = Windows.Forms.DialogResult.OK Then

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        UserDefinedReport.UpdatedByUserCode = Me.Session.UserCode
                        UserDefinedReport.UpdatedDate = Now

                        ReloadGrid = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.Update(ReportingDbContext, UserDefinedReport)

                    End Using

                End If

            ElseIf DynamicReport IsNot Nothing Then

                If AdvantageFramework.Desktop.Presentation.UserDefinedReportEditDialog.ShowFormDialog(UserDefinedReportType, DynamicReport.ID, DynamicReport.Type, DynamicReport.Description, DynamicReport.UserDefinedReportCategoryID, False) = Windows.Forms.DialogResult.OK Then

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DynamicReport.UpdatedByUserCode = Me.Session.UserCode
                        DynamicReport.UpdatedDate = Now

                        ReloadGrid = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Update(ReportingDbContext, DynamicReport)

                    End Using

                End If

            End If

            If ReloadGrid Then

                LoadGrids()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim ReportID As Integer = 0
            Dim ReloadGrid As Boolean = False

            If TabControlForm_ReportTypes.SelectedTab Is TabItemReportTypes_AdvancedReportWriterTab Then

                If DataGridViewAdvancedReportWriter_Reports.HasASelectedRow Then

                    If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete this report?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        Me.ShowWaitForm()

                        Try

                            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                For Each ReportID In DataGridViewAdvancedReportWriter_Reports.GetAllSelectedRowsBookmarkValues.OfType(Of Integer).ToList

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

                                LoadGrids()

                            End If

                        Catch ex As Exception

                        End Try

                        Me.CloseWaitForm()

                    End If

                End If

            ElseIf TabControlForm_ReportTypes.SelectedTab Is TabItemReportTypes_DynamicTab Then

                If DataGridViewDynamic_Reports.HasASelectedRow Then

                    If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete this report?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        Me.ShowWaitForm()

                        Try

                            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                    For Each ReportID In DataGridViewDynamic_Reports.GetAllSelectedRowsBookmarkValues.OfType(Of Integer).ToList

                                        Try

                                            DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, ReportID)

                                        Catch ex As Exception
                                            DynamicReport = Nothing
                                        End Try

                                        If DynamicReport IsNot Nothing Then

                                            ReloadGrid = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Delete(ReportingDbContext, DataContext, DynamicReport)

                                        End If

                                    Next

                                End Using

                            End Using

                            If ReloadGrid Then

                                LoadGrids()

                            End If

                        Catch ex As Exception

                        End Try

                        Me.CloseWaitForm()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.ShowWaitForm()

                Try

                    LoadGrids()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewAdvancedReportWriter_Reports_RowDoubleClickEvent() Handles DataGridViewAdvancedReportWriter_Reports.RowDoubleClickEvent

            If DataGridViewAdvancedReportWriter_Reports.HasOnlyOneSelectedRow Then

                ViewAdvancedReport()

            End If

        End Sub
        Private Sub DataGridViewAdvancedReportWriter_Reports_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewAdvancedReportWriter_Reports.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewDynamic_Reports_RowDoubleClickEvent() Handles DataGridViewDynamic_Reports.RowDoubleClickEvent

            If DataGridViewAdvancedReportWriter_Reports.HasOnlyOneSelectedRow Then

                ViewDynamicReport()

            End If

        End Sub
        Private Sub DataGridViewDynamic_Reports_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewDynamic_Reports.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub TabControlForm_ReportTypes_SelectedTabChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlForm_ReportTypes.SelectedTabChanged

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

                    If TabControlForm_ReportTypes.SelectedTab Is TabItemReportTypes_AdvancedReportWriterTab Then

                        Try

                            UserDefinedReportID = DataGridViewAdvancedReportWriter_Reports.GetFirstSelectedRowBookmarkValue(0)

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

                    ElseIf TabControlForm_ReportTypes.SelectedTab Is TabItemReportTypes_DynamicTab Then

                        Try

                            DynamicReportID = DataGridViewDynamic_Reports.GetFirstSelectedRowBookmarkValue(0)

                        Catch ex As Exception
                            DynamicReportID = 0
                        End Try

                        DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Load(ReportingDbContext).Include("DynamicReportColumns").Include("DynamicReportSummaryItems").Include("DynamicReportUnboundColumns").Where(Function(Entity) Entity.ID = DynamicReportID).SingleOrDefault

                        If DynamicReport IsNot Nothing Then

                            DynamicReportXML = New Reporting.Database.Classes.DynamicReportXML(DynamicReport)

                            XMLString = CreateXML(DynamicReportXML, GetType(AdvantageFramework.Reporting.Database.Classes.DynamicReportColumnXML),
                                                  GetType(AdvantageFramework.Reporting.Database.Classes.DynamicReportSummaryItemXML), GetType(AdvantageFramework.Reporting.Database.Classes.DynamicReportUnboundColumnXML))

                            My.Computer.FileSystem.WriteAllText(Folder & AdvantageFramework.FileSystem.CreateValidFileName(DynamicReport.Description) & ".xml", XMLString, False)

                        End If

                    End If

                End Using

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
