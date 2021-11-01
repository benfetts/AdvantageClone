Public Class Reporting_SprintReports
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _UserDefinedReportCategoriesList As Generic.List(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Function UpdateDynamicReport(ByRef GridDataItem As Telerik.Web.UI.GridDataItem) As Boolean

        'objects
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
        Dim DynamicReportUpdated As Boolean = False

        Try

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, GridDataItem.GetDataKeyValue("ID"))

                If DynamicReport IsNot Nothing Then

                    DynamicReport.Description = CType(GridDataItem.FindControl("TextBoxDescription"), TextBox).Text.Trim

                    If IsNumeric(CType(GridDataItem.FindControl("DropDownListReportCategory"), Telerik.Web.UI.RadComboBox).SelectedValue) Then

                        DynamicReport.UserDefinedReportCategoryID = CType(GridDataItem.FindControl("DropDownListReportCategory"), Telerik.Web.UI.RadComboBox).SelectedValue

                    Else

                        DynamicReport.UserDefinedReportCategoryID = Nothing

                    End If

                    DynamicReport.UpdatedDate = Now
                    DynamicReport.UpdatedByUserCode = _Session.UserCode

                    DynamicReportUpdated = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Update(ReportingDbContext, DynamicReport)

                End If

            End Using

        Catch ex As Exception
            DynamicReportUpdated = False
        Finally
            UpdateDynamicReport = DynamicReportUpdated
        End Try

    End Function

#Region "  Form Event Handlers "

    Private Sub Reporting_DynamicReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadComboBoxReportCategory.DataSource = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Load(ReportingDbContext).ToList.OrderBy(Function(UserDefinedReportCategory) UserDefinedReportCategory.Description).ToList
                RadComboBoxReportCategory.DataBind()
                RadComboBoxReportCategory.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", ""))

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportTemplates_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportTemplates.ButtonClick

        'objects
        Dim FunctionName As String = ""
        Dim DynamicReportTemplateID As Integer = 0
        Dim DynamicReportType As Integer = 0
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing

        Select Case e.Item.Value

            Case RadToolBarButtonAdd.Value

                Me.OpenWindow("", [String].Format("Reporting_SprintReportEdit.aspx"), 0, 0, False, True)

        End Select

    End Sub
    Private Sub RadGridDynamicReportTemplates_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridDynamicReportTemplates.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
        Dim DynamicReportTemplateID As Integer = 0
        Dim DynamicReportType As Integer = 0
        Dim Reload As Boolean = True
        Dim Inactive As Boolean = False

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridDynamicReportTemplates.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAllReports"

                For Each GridDataItem In RadGridDynamicReportTemplates.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    If UpdateDynamicReport(GridDataItem) = False Then

                        Reload = False
                        Exit For

                    End If

                Next

            Case "SaveReport"

                If CurrentGridDataItem IsNot Nothing Then

                    Reload = UpdateDynamicReport(CurrentGridDataItem)

                End If

            Case "DeleteReport"

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                        If DynamicReport IsNot Nothing Then

                            Reload = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Delete(ReportingDbContext, DataContext, DynamicReport)

                        Else

                            Reload = False

                        End If

                    End Using

                End Using

            Case "EditReport"

                Reload = False

                Try

                    DynamicReportTemplateID = CurrentGridDataItem.GetDataKeyValue("ID")

                Catch ex As Exception
                    DynamicReportTemplateID = 0
                End Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    If DynamicReportTemplateID > 0 Then

                    End If
                End Using

                Try

                    DynamicReportType = CurrentGridDataItem.GetDataKeyValue("DatasetTypeID")

                Catch ex As Exception
                    DynamicReportType = 0
                End Try

                If DynamicReportTemplateID > 0 AndAlso DynamicReportType > 0 Then

                    Session("DRPT_UseBlankData") = True
                    Session("DRPT_DashboardLoaded") = False
                    Session("DRPT_Data") = Nothing

                    Session("DRPT_Criteria") = Nothing
                    Session("DRPT_FilterString") = Nothing
                    Session("DRPT_From") = Nothing
                    Session("DRPT_To") = Nothing
                    Session("DRPT_ShowJobsWithNoDetails") = Nothing
                    Session("DRPT_ParameterDictionary") = Nothing
                    Session("DRPT_ShowGroupByBox") = Nothing
                    Session("DRPT_ShowViewCaption") = Nothing
                    Session("DRPT_ShowAutoFilterRow") = Nothing
                    Session("DRPT_ActiveFilter") = Nothing
                    Session("DRPT_ColumnsListJV") = Nothing
                    Session("DRPT_Layout") = Nothing
                    Session("DRPT_UDRCategory") = Nothing
                    Session("DRPT_Description") = Nothing
                    Session("SP_FilterReport_FilterString") = Nothing

                    Session("DRPT_Type") = DynamicReportType

                    Try

                        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, DynamicReportTemplateID)

                            If DynamicReport IsNot Nothing Then

                                Session("DRPT_UDRCategory") = DynamicReport.UserDefinedReportCategoryID
                                Session("DRPT_Description") = DynamicReport.Description

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.OpenWindow("", [String].Format("Reporting_Sprint.aspx?DynamicReportTemplateID={0}", CurrentGridDataItem.GetDataKeyValue("ID")))

                End If

            Case "ViewReport"

                Reload = False

                Try

                    DynamicReportTemplateID = CurrentGridDataItem.GetDataKeyValue("ID")

                Catch ex As Exception
                    DynamicReportTemplateID = 0
                End Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    If DynamicReportTemplateID > 0 Then

                    End If
                End Using

                Try

                    DynamicReportType = CurrentGridDataItem.GetDataKeyValue("DatasetTypeID")

                Catch ex As Exception
                    DynamicReportType = 0
                End Try

                If DynamicReportTemplateID > 0 AndAlso DynamicReportType > 0 Then

                    Session("DRPT_Criteria") = Nothing
                    Session("DRPT_FilterString") = Nothing
                    Session("DRPT_From") = Nothing
                    Session("DRPT_To") = Nothing
                    Session("DRPT_ShowJobsWithNoDetails") = Nothing
                    Session("DRPT_ParameterDictionary") = Nothing
                    Session("DRPT_ShowGroupByBox") = Nothing
                    Session("DRPT_ShowViewCaption") = Nothing
                    Session("DRPT_ShowAutoFilterRow") = Nothing
                    Session("DRPT_ActiveFilter") = Nothing
                    Session("DRPT_ColumnsListJV") = Nothing
                    Session("DRPT_Layout") = Nothing
                    Session("DRPT_UDRCategory") = Nothing
                    Session("DRPT_Description") = Nothing
                    Session("SP_FilterReport_FilterString") = Nothing

                    Session("DRPT_Type") = DynamicReportType
                    Session("DRPT_Data") = Nothing

                    Try

                        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, DynamicReportTemplateID)

                            If DynamicReport IsNot Nothing Then

                                Session("DRPT_UDRCategory") = DynamicReport.UserDefinedReportCategoryID
                                Session("DRPT_Description") = DynamicReport.Description

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                    If DynamicReportType = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTime OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.DirectTime OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTimeWithEmployeeCost OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.DirectTimeWithEmployeeCost OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetail OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailItem OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobProjectScheduleSummary OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobSummary OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ProjectHoursUsed OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ProjectSchedule OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ProjectSummary OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ProjectSummaryTask OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityDetail OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityToInvestment OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CRMClientContracts OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobPurchaseOrder OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AuthorizationToBuy OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeApproval OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ExpenseReportAndApproval OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobDetailItemAccountSplit OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.VendorContracts OrElse
                            DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ProjectScheduleTasksByEmployee Then

                        Me.OpenWindow("Set Initial Criteria", String.Format("Reporting_InitialLoading.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ClientPL Then

                        Me.OpenWindow("Client PL Inital Criteria", String.Format("Reporting_InitialLoadingPostPeriod.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 700, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EstimatedAndActualIncome Then

                        Me.OpenWindow("Estimated and Actual Income Inital Criteria", String.Format("Reporting_InitialLoadingEstimatedAndActualIncome.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatus Then

                        Me.OpenWindow("Media Current Status Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusNew.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaCurrentStatusSummary Then

                        Me.OpenWindow("Media Current Status Summary Criteria", String.Format("Reporting_InitialLoadingMediaCurrentStatusSummary.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonSummary Then

                        Me.OpenWindow("Media Current Status Criteria", String.Format("Reporting_InitialLoadingMediaPlanComparisonSummary.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AROpenAged Then

                        Me.OpenWindow("AR Open Aged Criteria", String.Format("Reporting_InitialLoadingAROpenAged.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ServiceFee Then

                        Me.OpenWindow("Service Fee Criteria", String.Format("Reporting_InitialLoadingServiceFee.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.Campaign Then

                        Me.OpenWindow("Campaign Criteria", String.Format("Reporting_InitialLoadingCampaign.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CashAnalysis Then

                        Me.OpenWindow("Cash Analysis Criteria", String.Format("Reporting_InitialLoadingCashAnalysis.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SalesJournal Then

                        Me.OpenWindow("Sales Journal Criteria", String.Format("Reporting_InitialLoadingSalesJournal.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.GeneralLedgerDetail Then

                        Me.OpenWindow("General Ledger Detail Criteria", String.Format("Reporting_InitialLoadingGeneralLedgerDetail.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.JobForecast Then

                        Me.OpenWindow("Job Forecast Criteria", String.Format("Reporting_InitialLoadingJobForecast.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.OpenPurchaseOrderDetail Then

                        Me.OpenWindow("Open Purchase Order Detail", String.Format("Reporting_InitialLoadingOpenPurchaseOrderDetail.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CRMProspects Then

                        Me.OpenWindow("CRM Prospects Criteria", String.Format("Reporting_InitialLoadingCRMProspects.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.ARPaymentHistory Then

                        Me.OpenWindow("AR Payment History Criteria", String.Format("Reporting_InitialLoadingARPaymentHistory.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 575, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.GeneralLedgerReport Then

                        Me.OpenWindow("General Ledger Report Criteria", String.Format("GeneralLedger/Reports/GeneralLedgerReport/DetailByAccountReport/{0}/1/{1}", DynamicReportTemplateID, DynamicReportType), 525, 900, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.TrialBalance Then

                        Me.OpenWindow("Trial Balance Criteria", String.Format("GeneralLedger/Reports/GeneralLedgerReport/DetailByAccountReport/{0}/1/{1}", DynamicReportTemplateID, DynamicReportType), 525, 900, False, True)

                    ElseIf DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaPlanComparisonByVendor Then

                        Me.OpenWindow("Media Current Status Criteria", String.Format("Reporting_InitialLoadingMediaPlanComparisonSummary.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), 525, 875, False, True)

                    Else

                        Session("DRPT_UseBlankData") = False
                        Session("DRPT_DashboardLoaded") = False

                        Me.OpenWindow("", [String].Format("Reporting_Sprint.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID))

                    End If

                End If

        End Select

        If Reload Then

            RadGridDynamicReportTemplates.Rebind()

        End If

    End Sub
    Private Sub RadGridDynamicReportTemplates_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridDynamicReportTemplates.ItemDataBound

        'objects
        Dim DropDownListReportCategory As Telerik.Web.UI.RadComboBox = Nothing
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing

        If _UserDefinedReportCategoriesList Is Nothing Then

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _UserDefinedReportCategoriesList = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Load(ReportingDbContext).ToList

            End Using

        End If

        Try

            DropDownListReportCategory = DirectCast(e.Item.FindControl("DropDownListReportCategory"), Telerik.Web.UI.RadComboBox)

            If DropDownListReportCategory IsNot Nothing Then

                DropDownListReportCategory.DataSource = (From UserDefinedReportCategory In _UserDefinedReportCategoriesList
                                                         Select UserDefinedReportCategory.ID,
                                                                UserDefinedReportCategory.Description).ToList.OrderBy(Function(UserDefinedReportCategory) UserDefinedReportCategory.Description).ToList

                DropDownListReportCategory.DataBind()

                DropDownListReportCategory.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    DropDownListReportCategory.SelectedValue = e.Item.DataItem.ReportCategoryID

                End If

            End If

        Catch ex As Exception
            DropDownListReportCategory = Nothing
        End Try

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

    End Sub
    Private Sub RadGridDynamicReportTemplates_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridDynamicReportTemplates.NeedDataSource

        'objects
        Dim UserDefinedReportCategoryID As Integer = 0

        Try

            UserDefinedReportCategoryID = RadComboBoxReportCategory.SelectedValue

        Catch ex As Exception
            UserDefinedReportCategoryID = 0
        End Try

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If UserDefinedReportCategoryID > 0 Then

                    RadGridDynamicReportTemplates.DataSource = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Load(ReportingDbContext).Include("UserDefinedReportCategory").ToList.Where(Function(DynamicReport) (DynamicReport.Type = AdvantageFramework.Reporting.DynamicReports.ResourceAllocationByWeek)).ToList.Where(Function(Entity) Entity.UserDefinedReportCategoryID.GetValueOrDefault(0) = UserDefinedReportCategoryID).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

                Else

                    RadGridDynamicReportTemplates.DataSource = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Load(ReportingDbContext).Include("UserDefinedReportCategory").ToList.Where(Function(DynamicReport) (DynamicReport.Type = AdvantageFramework.Reporting.DynamicReports.ResourceAllocationByWeek)).ToList.Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

                End If

            End Using

        End Using

    End Sub
    Private Sub RadComboBoxReportCategory_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxReportCategory.SelectedIndexChanged

        RadGridDynamicReportTemplates.Rebind()

    End Sub

#End Region

#End Region

End Class
