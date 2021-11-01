Imports Webvantage.wvTimeSheet
Imports Microsoft.VisualBasic

Imports System.Data.SqlClient
Imports System.Drawing
Imports Telerik.Web.UI

Partial Public Class QuoteVsActualSummaryPopup
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Dim dtThisDate As Date
    Dim drQvaData As SqlDataReader
    Dim nbTotal As Decimal = CDec(0.0)
    Dim nbAmt As Decimal = CDec(0.0)
    Dim nbTax As Decimal = CDec(0.0)
    Dim nbHours As Decimal = CDec(0.0)
    Dim nbMarkup As Decimal = CDec(0.0)
    Dim ActualAmt As Decimal = CDec(0.0)
    Dim ActualTax As Decimal = CDec(0.0)
    Dim ActualMarkup As Decimal = CDec(0.0)
    Dim ActualHours As Decimal = CDec(0.0)

    Private JobNum As Integer = 0
    Private JobCompNum As Integer = 0
    Private CampaignID As Integer = 0
    Private CampaignCode As String = ""
    Private CampaignName As String = ""

    Private AppVarsInitialized As Boolean = False
    Private QvaFilterIncludeNB As Boolean = False
    Private QvaFilterBreakoutAllNB As Boolean = False
    Private QvaFilterBreakoutNBForFT As Boolean = False
    Private QvaFilterEmployeeTime As Boolean = False
    Private QvaFilterIncomeOnly As Boolean = False
    Private QvaFilterVendor As Boolean = False
    Private QvaFilterSalesTax As Boolean = False

    Private IncludeClosedJobs As Integer = 0

    Dim QuotedHoursTotal As Decimal = CDec(0.0)
    Dim QuotedAmountTotal As Decimal = CDec(0.0)
    Dim QuotedMarkupTotal As Decimal = CDec(0.0)
    Dim QuotedTaxTotal As Decimal = CDec(0.0)
    Dim QuotedTotal As Decimal = CDec(0.0)
    Dim QuotedTotal2 As Decimal = CDec(0.0)
    Dim ActualHoursTotal As Decimal = CDec(0.0)
    Dim ActualAmountTotal As Decimal = CDec(0.0)
    Dim ActualMarkupTotal As Decimal = CDec(0.0)
    Dim ActualTaxTotal As Decimal = CDec(0.0)
    Dim ActualAmountSubTotal As Decimal = CDec(0.0)
    Dim ActualMarkupSubTotal As Decimal = CDec(0.0)
    Dim ActualTaxSubTotal As Decimal = CDec(0.0)
    Dim ActualHoursSubTotal As Decimal = CDec(0.0)
    Dim ActualTotal As Decimal = CDec(0.0)
    Dim ActualTotal2 As Decimal = CDec(0.0)
    Dim NonBillableSubTotal As Decimal = CDec(0.0)
    Dim NonBillableTotal As Decimal = CDec(0.0)
    Dim NonBillableHoursSubTotal As Decimal = CDec(0.0)
    Dim NonBillableHoursTotal As Decimal = CDec(0.0)
    Dim OpenPONetAmountTotal As Decimal = CDec(0.0)
    Dim BilledToDateTotal As Decimal = CDec(0.0)
    Dim BilledToDateSubTotal As Decimal = CDec(0.0)
    Dim QuoteVsActualPOTotal As Decimal = CDec(0.0)
    Dim QuoteVsActualPOTotal2 As Decimal = CDec(0.0)
    Dim ActualPOVsBilled As Decimal = CDec(0.0)
    Dim ActualPOVsBilled2 As Decimal = CDec(0.0)
    Dim DecTemp As Decimal = CDec(0.0)
    Dim ApprovedAmtTotal As Decimal = CDec(0.0)
    Dim PercOfQuoteTotal As Decimal = CDec(0.0)
    Dim camp As AdvantageFramework.Database.Entities.Campaign = Nothing


#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property
    Private Property CurrentGridPageIndex As Integer = 0

#End Region

#Region " Page Events "

    Private Sub QuoteVsActualSummaryPopup_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.AllowFloat = True

        'This has to be called on every load
        'If AdvantageFramework.Web.Presentation.Controls.CheckUserColumns(Session("Connstring"), "RadGridQvASummary", _Session.UserCode) = 0 Then

        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnQuotedMarkup", True)
        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnQuotedTax", True)
        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnQuotedQtyHrs", True)
        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnQuotedTotal", True)
        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnActualAmount", True)
        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnActualMarkup", True)
        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnActualTax", True)
        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnActualHours", True)
        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnPercentOfQuote", True)

        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnActualTotal", True)
        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnNBActualHours", True)
        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnNBActualTotal", True)
        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnOpenPONetAmount", True)
        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnAPPROVED_AMT", True)
        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnBilledToDate", True)
        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnQuotevsActualPO", True)
        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnActualPOvsBilled", True)
        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnFNC_DESCRIPTION", True)
        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnQuotedAmount", True)
        '    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridQvASummary", "GridBoundColumnPercentOfQuoteAmt", True)

        '    AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridQvASummary)
        'Else
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridQvASummary)
        'End If

        If Not Me.IsPostBack And Not Me.IsCallback Then

            '' ''Dim GridSettings As New GridSettingsPersister(Me.RadGridQvASummary)
            '' ''GridSettings.LoadFromDatabase()

        End If

    End Sub
    Private Sub QuoteVsActualSummaryPopup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            If Not Request.QueryString("JobNo") Is Nothing Then
                JobNum = Request.QueryString("JobNo")
            End If
        Catch ex As Exception
            JobNum = 0
        End Try
        Try
            If Not Request.QueryString("JobComp") Is Nothing Then
                JobCompNum = Request.QueryString("JobComp")
            End If
        Catch ex As Exception
            JobCompNum = 0
        End Try
        Try
            If Not Request.QueryString("CampaignID") Is Nothing Then
                CampaignID = Request.QueryString("CampaignID")
            End If
            If Me.CampaignID > 0 Then
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    camp = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, Me.CampaignID)
                    If camp IsNot Nothing Then
                        Me.CampaignCode = camp.Code
                        Me.CampaignName = camp.Name
                    End If
                End Using
            End If
        Catch ex As Exception
            CampaignID = 0
        End Try

        'Clean up old querystring names by letting clean qs class override
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.JobNumber > 0 Then Me.JobNum = qs.JobNumber
        If qs.JobComponentNumber > 0 Then Me.JobCompNum = qs.JobComponentNumber

        If Not Request.QueryString("group") Is Nothing Then
            If Request.QueryString("group") <> "job" And Request.QueryString("group") <> "campaign" Then
                If JobNum = 0 Or JobCompNum = 0 Then
                    Me.ShowMessage("Please select a Job and Job Component on Filter Tab")
                End If
            End If
        End If

        LoadTabs()

        Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
        oAppVars.getAllAppVars()
        If Page.IsPostBack = True Then

            dtThisDate = CDate(ViewState("ThisDate"))

        Else

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_DashboardQueries_QuotevsActualsDQ)

            'If Request.QueryString("group") = "job" Then
            '    Me.RadToolbarButtonGroupJob.Checked = True
            'End If

            Dim group As String = ""
            If AppVarsInitialized = False Then
                group = oAppVars.getAppVar("QvaFilterGroup")
                If group = "Type" Then
                    Me.RadToolbarButtonType.Checked = True
                End If
                If group = "Heading" Then
                    Me.RadToolbarButtonHeading.Checked = True
                End If
                If group = "Consolidation" Then
                    Me.RadToolbarButtonConsolidation.Checked = True
                End If
                If group = "Function" Then
                    Me.RadToolbarButtonFunction.Checked = True
                End If
                If group = "" Then
                    Me.RadToolbarButtonFunction.Checked = True
                End If

                Me.QvaFilterIncludeNB = CType(oAppVars.getAppVar("QvaFilterIncludeNB", "Boolean"), Boolean)
                Me.QvaFilterBreakoutAllNB = CType(oAppVars.getAppVar("QvaFilterBreakoutAllNB", "Boolean"), Boolean)
                Me.QvaFilterBreakoutNBForFT = CType(oAppVars.getAppVar("QvaFilterBreakoutNBForFT", "Boolean"), Boolean)
                Me.QvaFilterEmployeeTime = CType(oAppVars.getAppVar("QvaFilterEmployeeTime", "Boolean"), Boolean)
                Me.QvaFilterIncomeOnly = CType(oAppVars.getAppVar("QvaFilterIncomeOnly", "Boolean"), Boolean)
                Me.QvaFilterVendor = CType(oAppVars.getAppVar("QvaFilterVendor", "Boolean"), Boolean)
                Me.QvaFilterSalesTax = CType(oAppVars.getAppVar("QvaFilterSalesTax", "Boolean"), Boolean)
                Me.RadToolbarButtonIncludeNB.Checked = Me.QvaFilterIncludeNB
                Me.RadToolbarButtonBreakoutAllNB.Checked = Me.QvaFilterBreakoutAllNB
                Me.RadToolbarButtonBreakoutNBForFT.Checked = Me.QvaFilterBreakoutNBForFT
                Me.RadToolbarButtonEmployeeTime.Checked = Me.QvaFilterEmployeeTime
                Me.RadToolbarButtonIncomeOnly.Checked = Me.QvaFilterIncomeOnly
                Me.RadToolbarButtonVendor.Checked = Me.QvaFilterVendor
                Me.RadToolbarButtonSalesTax.Checked = Me.QvaFilterSalesTax
                If Me.RadToolbarButtonBreakoutNBForFT.Checked = False Then
                    Me.RadToolbarButtonEmployeeTime.Enabled = False
                    Me.RadToolbarButtonIncomeOnly.Enabled = False
                    Me.RadToolbarButtonVendor.Enabled = False
                End If
                Me.AppVarsInitialized = True
            End If

            If Me.RadToolbarButtonSalesTax.Checked = False Then

                Me.RadGridQvASummary.MasterTableView.Columns.FindByUniqueName("GridBoundColumnQuotedTax").Visible = False
                Me.RadGridQvASummary.MasterTableView.Columns.FindByUniqueName("GridBoundColumnActualTax").Visible = False
                Me.RadGridQvaSummaryFunction.MasterTableView.Columns.FindByUniqueName("GridBoundColumnQuotedTax").Visible = False
                Me.RadGridQvaSummaryFunction.MasterTableView.Columns.FindByUniqueName("GridBoundColumnActualTax").Visible = False

            Else

                Me.RadGridQvASummary.MasterTableView.Columns.FindByUniqueName("GridBoundColumnQuotedTax").Visible = True
                Me.RadGridQvASummary.MasterTableView.Columns.FindByUniqueName("GridBoundColumnActualTax").Visible = True
                Me.RadGridQvaSummaryFunction.MasterTableView.Columns.FindByUniqueName("GridBoundColumnQuotedTax").Visible = True
                Me.RadGridQvaSummaryFunction.MasterTableView.Columns.FindByUniqueName("GridBoundColumnActualTax").Visible = True

            End If

        End If

    End Sub
    Private Sub QuoteVsActualSummaryPopup_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
            oAppVars.getAllAppVars()

            'If Session("QvaFilterBreakoutAllNB") = True Or Session("QvaFilterBreakoutNBForFT") = True Then
            If CType(oAppVars.getAppVar("QvaFilterBreakoutAllNB", "Boolean"), Boolean) = True Or CType(oAppVars.getAppVar("QvaFilterBreakoutNBForFT", "Boolean"), Boolean) = True Then
                Me.RadGridQvASummary.MasterTableView.GetColumn("GridBoundColumnNBActualHours").Display = True
                Me.RadGridQvASummary.MasterTableView.GetColumn("GridBoundColumnNBActualTotal").Display = True
                Me.RadGridQvaSummaryFunction.MasterTableView.GetColumn("GridBoundColumnNBActualHours").Display = True
                Me.RadGridQvaSummaryFunction.MasterTableView.GetColumn("GridBoundColumnNBActualTotal").Display = True
                Me.RadGridQvASummary.MasterTableView.DetailTables(0).GetColumn("GridBoundColumnNBActualHours2").Display = True
                Me.RadGridQvASummary.MasterTableView.DetailTables(0).GetColumn("GridBoundColumnNBActualTotal2").Display = True
            Else
                Me.RadGridQvASummary.MasterTableView.GetColumn("GridBoundColumnNBActualHours").Display = False
                Me.RadGridQvASummary.MasterTableView.GetColumn("GridBoundColumnNBActualTotal").Display = False
                Me.RadGridQvaSummaryFunction.MasterTableView.GetColumn("GridBoundColumnNBActualHours").Display = False
                Me.RadGridQvaSummaryFunction.MasterTableView.GetColumn("GridBoundColumnNBActualTotal").Display = False
                Me.RadGridQvASummary.MasterTableView.DetailTables(0).GetColumn("GridBoundColumnNBActualHours2").Display = False
                Me.RadGridQvASummary.MasterTableView.DetailTables(0).GetColumn("GridBoundColumnNBActualTotal2").Display = False
            End If

            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()

            If qs.IsJobDashboard = True Then
                Dim di As GridItem = RadGridQvaSummaryFunction.MasterTableView.GetItems(GridItemType.CommandItem)(0)
                di.Visible = False
            End If

            'If Me.RadToolbarButtonType.Checked = True Then
            '    Session("QVAGroupingSummary") = "Type"
            'End If
            'If Me.RadToolbarButtonHeading.Checked = True Then
            '    Session("QVAGroupingSummary") = "Heading"
            'End If
            'If Me.RadToolbarButtonConsolidation.Checked = True Then
            '    Session("QVAGroupingSummary") = "Consolidation"
            'End If
            'If Me.RadToolbarButtonFunction.Checked = True Then
            '    Session("QVAGroupingSummary") = "Function"
            'End If

            If Request.QueryString("bm") <> "1" Then
                If Me.CampaignCode <> "" Then
                    Me.Page.Title = "QVA - Campaign: " & Me.CampaignCode & "/" & Me.CampaignName
                Else
                    If Me.JobCompNum = 0 Then
                        Me.Page.Title = "QVA - Job: " & Me.JobNum.ToString.PadLeft(6, "0")
                    Else
                        Me.Page.Title = "QVA - Job: " & Me.JobNum.ToString.PadLeft(6, "0") & "/" & Me.JobCompNum.ToString.PadLeft(2, "0")
                    End If
                End If

            End If

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region " Controls Events "

    Private Sub RadGridQvASummary_DetailTableDataBind(sender As Object, e As Telerik.Web.UI.GridDetailTableDataBindEventArgs) Handles RadGridQvASummary.DetailTableDataBind
        Try
            Dim group As String = ""
            Dim fnctype As String = ""
            Dim fncConsolcode As String = ""
            Dim fncHeadingid As Integer = 0
            Dim dt As DataTable
            Dim dv As DataView
            For Each rtb As RadToolBarButton In Me.RadToolbarQvA.Items
                If rtb.Checked = True And rtb.Group = "Function" Then
                    group = rtb.Value
                End If
            Next
            If group = "" Then
                group = "Function"
            End If
            dt = Session("QVADatasetDD")
            Dim parentItem As Telerik.Web.UI.GridDataItem = CType(e.DetailTableView.ParentItem, Telerik.Web.UI.GridDataItem)
            If group = "Type" Then
                fnctype = parentItem.GetDataKeyValue("FNC_TYPE")
                dv = New DataView(dt)
                dv.RowFilter = "FNC_TYPE = '" & fnctype & "'"
                e.DetailTableView.DataSource = dv.ToTable()
            ElseIf group = "Heading" Then
                fncHeadingid = parentItem.GetDataKeyValue("FNC_HEADING_ID")
                dv = New DataView(dt)
                dv.RowFilter = "FNC_HEADING_ID = " & fncHeadingid
                e.DetailTableView.DataSource = dv.ToTable()
            ElseIf group = "Consolidation" Then
                fncConsolcode = parentItem.GetDataKeyValue("FNC_CONSOL_CODE")
                dv = New DataView(dt)
                dv.RowFilter = "FNC_CONSOL_CODE = '" & fncConsolcode & "'"
                e.DetailTableView.DataSource = dv.ToTable()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridQvASummary_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridQvASummary.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Try
            Dim btn As Button
            Select Case e.Item.ItemType
                Case GridItemType.CommandItem
                    If e.CommandName = "Expand" Then
                        btn = e.Item.FindControl("btnExpand")
                        If btn.Text = "Collapse" Then
                            Me.RadGridQvASummary.MasterTableView.HierarchyDefaultExpanded = False
                            btn.Text = "Expand"
                        ElseIf btn.Text = "Expand" Then
                            Me.RadGridQvASummary.MasterTableView.HierarchyDefaultExpanded = True
                            btn.Text = "Collapse"
                        End If
                        Me.RadGridQvASummary.Rebind()
                    End If
            End Select
        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadGridQvASummary_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridQvASummary.ItemDataBound

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        Select Case e.Item.ItemType

            Case GridItemType.CommandItem

                Dim oJob As New Job(Session("ConnString"))
                Dim lab As System.Web.UI.WebControls.Label
                If Request.QueryString("group") = "job" Then
                    oJob.GetJob(Me.JobNum)
                    lab = e.Item.FindControl("lblJobNumber")
                    lab.Text = Me.JobNum.ToString().PadLeft(6, "0") & " - " & oJob.JOB_DESC
                    lab = e.Item.FindControl("lblJobCompNum")
                    lab.Text = "All"
                ElseIf Request.QueryString("group") = "campaign" Then
                    lab = e.Item.FindControl("lblJob")
                    lab.Text = "Campaign:  "
                    lab = e.Item.FindControl("lblJobNumber")
                    lab.Text = Me.CampaignCode
                    lab = e.Item.FindControl("lblJobComp")
                    lab.Text = Me.CampaignName
                Else
                    If qs.IsJobDashboard = False Then
                        oJob.GetJob(Me.JobNum, Me.JobCompNum)
                        lab = e.Item.FindControl("lblJobNumber")
                        lab.Text = Me.JobNum.ToString().PadLeft(6, "0") & " - " & oJob.JOB_DESC
                        lab = e.Item.FindControl("lblJobCompNum")
                        lab.Text = Me.JobCompNum.ToString().PadLeft(3, "0") & " - " & oJob.JobComponent.JOB_COMP_DESC
                    Else
                        e.Item.Visible = False
                    End If
                End If


            Case GridItemType.Header

            Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item

            Case GridItemType.GroupFooter

                e.Item.Font.Bold = True

                Dim GrpFtr As Telerik.Web.UI.GridGroupFooterItem
                GrpFtr = e.Item

                If Not GrpFtr Is Nothing Then

                    GrpFtr("GridBoundColumnFNC_DESCRIPTION").Text = "Total:"

                End If

            Case GridItemType.Footer
                Dim qhrs As Decimal
                Dim qamt As Decimal
                Dim ahrs As Decimal
                Dim aamt As Decimal

                e.Item.Font.Bold = True

                Dim GrpFtr As Telerik.Web.UI.GridFooterItem
                GrpFtr = e.Item

                If Not GrpFtr Is Nothing Then

                    If GrpFtr("GridBoundColumnQuotedQtyHrs").Text <> "" Then
                        qhrs = CDec(GrpFtr("GridBoundColumnQuotedQtyHrs").Text)
                    End If
                    If GrpFtr("GridBoundColumnQuotedAmount").Text <> "" Then
                        qamt = CDec(GrpFtr("GridBoundColumnQuotedAmount").Text)
                    End If
                    If GrpFtr("GridBoundColumnActualHours").Text <> "" Then
                        ahrs = CDec(GrpFtr("GridBoundColumnActualHours").Text)
                    End If
                    If GrpFtr("GridBoundColumnActualAmount").Text <> "" Then
                        aamt = CDec(GrpFtr("GridBoundColumnActualAmount").Text)
                    End If

                    If qhrs > 0 Then
                        GrpFtr("GridBoundColumnPercentOfQuote").Text = String.Format("{0:#,##0.00}%", (ahrs / qhrs) * 100)
                    End If
                    If qamt > 0 Then
                        GrpFtr("GridBoundColumnPercentOfQuoteAmt").Text = String.Format("{0:#,##0.00}%", (aamt / qamt) * 100)
                    End If

                End If

        End Select

    End Sub
    Private Sub RadGridQvASummary_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridQvASummary.NeedDataSource
        Try
            Dim cts As cTimeSheet = New cTimeSheet(Session("ConnString"))
            Dim ds As DataSet
            Dim group As String = ""
            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression
            For Each rtb As RadToolBarButton In Me.RadToolbarQvA.Items
                If rtb.Checked = True And rtb.Group = "Function" Then
                    group = rtb.Value
                End If
            Next

            If group = "" Then
                group = "Function"
            End If

            If group = "Type" Then
                Dim strFT() As String = {"FNC_TYPE"}
                Me.RadGridQvASummary.MasterTableView.DataKeyNames = strFT
            ElseIf group = "Heading" Then
                Dim strFH() As String = {"FNC_HEADING_ID"}
                Me.RadGridQvASummary.MasterTableView.DataKeyNames = strFH
            ElseIf group = "Consolidation" Then
                Dim strFC() As String = {"FNC_CONSOL_CODE"}
                Me.RadGridQvASummary.MasterTableView.DataKeyNames = strFC
            End If

            If Request.QueryString("group") = "job" Then
                ds = cts.GetQuoteVsActualSummaryJobDS(Me.JobNum, Me.JobCompNum, Session("UserCode"), group)
            ElseIf Request.QueryString("group") = "campaign" Then
                ds = cts.GetQuoteVsActualSummaryCampaignDS(Me.CampaignID, Session("UserCode"), group, Request.QueryString("grouptype"), Request.QueryString("DO"))
            Else
                ds = cts.GetQuoteVsActualSummaryDS(Me.JobNum, Me.JobCompNum, Session("UserCode"), group)
            End If

            If group <> "Function" Then
                Me.RadGridQvASummary.DataSource = ds.Tables(1)
            End If
            Session("QVADatasetDD") = ds.Tables(0)


            Me.RadGridQvASummary.PageSize = MiscFN.LoadPageSize(Me.RadGridQvASummary.ID)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridQvASummary_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridQvASummary.PageIndexChanged

        Me.CurrentGridPageIndex = e.NewPageIndex
        Me.RadGridQvASummary.Rebind()

    End Sub
    Private Sub RadGridQvASummary_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridQvASummary.PageSizeChanged

        MiscFN.SavePageSize(Me.RadGridQvASummary.ID, e.NewPageSize)

    End Sub
    Private Sub RadGridQvASummary_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridQvASummary.PreRender
        Try
            Dim gtv As Telerik.Web.UI.GridTableView
            Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
            oAppVars.getAllAppVars()

            If CType(oAppVars.getAppVar("QvaFilterBreakoutAllNB", "Boolean"), Boolean) = True Or CType(oAppVars.getAppVar("QvaFilterBreakoutNBForFT", "Boolean"), Boolean) = True Then

                Me.RadGridQvASummary.MasterTableView.Columns.FindByUniqueName("GridBoundColumnPercentOfQuote").Visible = True

            End If

            If Me.RadToolbarButtonSalesTax.Checked = False Then

                For i As Integer = 0 To Me.RadGridQvASummary.MasterTableView.Items.Count - 1
                    For j As Integer = 0 To Me.RadGridQvASummary.MasterTableView.Items(i).ChildItem.NestedTableViews.Length - 1
                        gtv = CType(Me.RadGridQvASummary.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem).ChildItem.NestedTableViews(j)
                        If gtv.Items.Count > 0 Then
                            gtv.Columns.FindByUniqueName("GridBoundColumnQuotedTax2").Visible = False
                            gtv.Columns.FindByUniqueName("GridBoundColumnActualTax2").Visible = False
                        End If
                    Next
                Next

            Else

                For i As Integer = 0 To Me.RadGridQvASummary.MasterTableView.Items.Count - 1
                    For j As Integer = 0 To Me.RadGridQvASummary.MasterTableView.Items(i).ChildItem.NestedTableViews.Length - 1
                        gtv = CType(Me.RadGridQvASummary.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem).ChildItem.NestedTableViews(j)
                        If gtv.Items.Count > 0 Then
                            gtv.Columns.FindByUniqueName("GridBoundColumnQuotedTax2").Visible = True
                            gtv.Columns.FindByUniqueName("GridBoundColumnActualTax2").Visible = True
                        End If
                    Next
                Next

            End If

            '' ''Dim GridSettings As New GridSettingsPersister(Me.RadGridQvASummary)
            '' ''GridSettings.SaveToDatabase()
        Catch ex As Exception

        End Try

    End Sub


    Private Sub RadGridQvaSummaryFunction_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridQvaSummaryFunction.ItemDataBound
        Try

            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()

            Select Case e.Item.ItemType

                Case GridItemType.CommandItem

                    Dim oJob As New Job(Session("ConnString"))
                    Dim lab As System.Web.UI.WebControls.Label
                    If Request.QueryString("group") = "job" Then
                        oJob.GetJob(Me.JobNum)
                        lab = e.Item.FindControl("lblJobNumber")
                        lab.Text = Me.JobNum.ToString().PadLeft(6, "0") & " - " & oJob.JOB_DESC
                        lab = e.Item.FindControl("lblJobCompNum")
                        lab.Text = "All"
                    ElseIf Request.QueryString("group") = "campaign" Then
                        lab = e.Item.FindControl("lblJob")
                        lab.Text = "Campaign:  "
                        lab = e.Item.FindControl("lblJobNumber")
                        lab.Text = Me.CampaignCode
                        lab = e.Item.FindControl("lblJobComp")
                        lab.Text = Me.CampaignName
                    Else
                        oJob.GetJob(Me.JobNum, Me.JobCompNum)
                        lab = e.Item.FindControl("lblJobNumber")
                        lab.Text = Me.JobNum.ToString().PadLeft(6, "0") & " - " & oJob.JOB_DESC
                        lab = e.Item.FindControl("lblJobCompNum")
                        lab.Text = Me.JobCompNum.ToString().PadLeft(3, "0") & " - " & oJob.JobComponent.JOB_COMP_DESC

                    End If
                Case GridItemType.Header

                Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item

                Case GridItemType.GroupFooter

                    e.Item.Font.Bold = True

                    Dim GrpFtr As Telerik.Web.UI.GridGroupFooterItem
                    GrpFtr = e.Item

                    If Not GrpFtr Is Nothing Then

                        GrpFtr("GridBoundColumnFNC_DESCRIPTION").Text = "Total:"

                    End If

                Case GridItemType.Footer
                    Dim qhrs As Decimal
                    Dim qamt As Decimal
                    Dim ahrs As Decimal
                    Dim aamt As Decimal

                    e.Item.Font.Bold = True

                    Dim GrpFtr As Telerik.Web.UI.GridFooterItem
                    GrpFtr = e.Item

                    If Not GrpFtr Is Nothing Then

                        If GrpFtr("GridBoundColumnQuotedQtyHrs").Text <> "" Then
                            qhrs = CDec(GrpFtr("GridBoundColumnQuotedQtyHrs").Text)
                        End If
                        If GrpFtr("GridBoundColumnQuotedAmount").Text <> "" Then
                            qamt = CDec(GrpFtr("GridBoundColumnQuotedAmount").Text)
                        End If
                        If GrpFtr("GridBoundColumnActualHours").Text <> "" Then
                            ahrs = CDec(GrpFtr("GridBoundColumnActualHours").Text)
                        End If
                        If GrpFtr("GridBoundColumnActualAmount").Text <> "" Then
                            aamt = CDec(GrpFtr("GridBoundColumnActualAmount").Text)
                        End If

                        If qhrs > 0 Then
                            GrpFtr("GridBoundColumnPercentOfQuote").Text = String.Format("{0:#,##0.00}%", (ahrs / qhrs) * 100)
                        End If
                        If qamt > 0 Then
                            GrpFtr("GridBoundColumnPercentOfQuoteAmt").Text = String.Format("{0:#,##0.00}%", (aamt / qamt) * 100)
                        End If

                    End If

            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridQvaSummaryFunction_PageIndexChanged(sender As Object, e As GridPageChangedEventArgs) Handles RadGridQvaSummaryFunction.PageIndexChanged
        Me.CurrentGridPageIndex = e.NewPageIndex
        Me.RadGridQvaSummaryFunction.Rebind()
    End Sub
    Private Sub RadGridQvaSummaryFunction_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGridQvaSummaryFunction.PageSizeChanged
        MiscFN.SavePageSize(Me.RadGridQvaSummaryFunction.ID, e.NewPageSize)
    End Sub
    Private Sub RadGridQvaSummaryFunction_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridQvaSummaryFunction.NeedDataSource
        Try
            Dim cts As cTimeSheet = New cTimeSheet(Session("ConnString"))
            Dim group As String = ""
            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression
            For Each rtb As RadToolBarButton In Me.RadToolbarQvA.Items
                If rtb.Checked = True And rtb.Group = "Function" Then
                    group = rtb.Value
                End If
            Next

            If group = "" Then
                group = "Function"
            End If
            If group = "Function" Then
                If Request.QueryString("group") = "job" Then
                    Me.RadGridQvaSummaryFunction.DataSource = cts.GetQuoteVsActualSummaryJobDS(Me.JobNum, Me.JobCompNum, Session("UserCode"), group)
                ElseIf Request.QueryString("group") = "campaign" Then
                    Me.RadGridQvaSummaryFunction.DataSource = cts.GetQuoteVsActualSummaryCampaignDS(Me.CampaignID, Session("UserCode"), group, Request.QueryString("grouptype"), Request.QueryString("DO"))
                Else
                    Me.RadGridQvaSummaryFunction.DataSource = cts.GetQuoteVsActualSummaryDS(Me.JobNum, Me.JobCompNum, Session("UserCode"), group)
                End If
            End If
            Me.RadGridQvaSummaryFunction.PageSize = MiscFN.LoadPageSize(Me.RadGridQvaSummaryFunction.ID)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridQvASummaryFunction_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridQvaSummaryFunction.PreRender
        Try
            Dim gtv As Telerik.Web.UI.GridTableView
            Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
            oAppVars.getAllAppVars()

            If CType(oAppVars.getAppVar("QvaFilterBreakoutAllNB", "Boolean"), Boolean) = True Or CType(oAppVars.getAppVar("QvaFilterBreakoutNBForFT", "Boolean"), Boolean) = True Then

                Me.RadGridQvaSummaryFunction.MasterTableView.Columns.FindByUniqueName("GridBoundColumnPercentOfQuote").Visible = True

            End If

            '' ''Dim GridSettings As New GridSettingsPersister(Me.RadGridQvaSummaryFunction)
            '' ''GridSettings.SaveToDatabase()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadToolbarQvA_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarQvA.ButtonClick
        Select Case e.Item.Value
            Case "GroupJob"
                Me.RadGridQvASummary.Rebind()
                Me.RadGridQvaSummaryFunction.Rebind()
            Case "Type", "Heading", "Consolidation"
                Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
                oAppVars.getAllAppVars()
                Me.RadGridQvASummary.Rebind()
                Me.RadGridQvASummary.Visible = True
                Me.RadGridQvaSummaryFunction.Visible = False
                oAppVars.setAppVar("QvaFilterGroup", e.Item.Value)
                oAppVars.SaveAllAppVars()
            Case "Function"
                Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
                oAppVars.getAllAppVars()
                Me.RadGridQvaSummaryFunction.Rebind()
                Me.RadGridQvASummary.Visible = False
                Me.RadGridQvaSummaryFunction.Visible = True
                oAppVars.setAppVar("QvaFilterGroup", e.Item.Value)
                oAppVars.SaveAllAppVars()
            Case "Export"
                Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
                oAppVars.getAllAppVars()

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs = qs.FromCurrent()

                If CType(oAppVars.getAppVar("QvaFilterBreakoutAllNB", "Boolean"), Boolean) = True Or CType(oAppVars.getAppVar("QvaFilterBreakoutNBForFT", "Boolean"), Boolean) = True Then
                    Me.RadGridQvASummary.MasterTableView.DetailTables(0).GetColumn("GridBoundColumnNBActualHours2").Visible = True
                    Me.RadGridQvASummary.MasterTableView.DetailTables(0).GetColumn("GridBoundColumnNBActualTotal2").Visible = True
                Else
                    Me.RadGridQvASummary.MasterTableView.DetailTables(0).GetColumn("GridBoundColumnNBActualHours2").Visible = False
                    Me.RadGridQvASummary.MasterTableView.DetailTables(0).GetColumn("GridBoundColumnNBActualTotal2").Visible = False
                End If


                Dim str As String = ""
                If Me.RadToolbarButtonFunction.Checked = True Then
                    If Me.CampaignID > 0 Then
                        str = "QvA_Summary" & "_" & CampaignID & "_" & CampaignCode & AdvantageFramework.StringUtilities.GUID_Date()
                    Else
                        str = "QvA_Summary" & "_" & MiscFN.PadJobNum(Me.JobNum) & "_" & MiscFN.PadJobCompNum(Me.JobCompNum) & AdvantageFramework.StringUtilities.GUID_Date()
                    End If
                    AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridQvASummary, str,, False)
                    RadGridQvaSummaryFunction.MasterTableView.ExportToExcel()
                Else
                    If Me.CampaignID > 0 Then
                        str = "QvA_Summary" & "_" & CampaignID & "_" & CampaignCode & AdvantageFramework.StringUtilities.GUID_Date()
                    Else
                        str = "QvA_Summary" & "_" & MiscFN.PadJobNum(Me.JobNum) & "_" & MiscFN.PadJobCompNum(Me.JobCompNum) & AdvantageFramework.StringUtilities.GUID_Date()
                    End If
                    Me.RadGridQvASummary.MasterTableView.HierarchyDefaultExpanded = True
                    With Me.RadGridQvASummary.ExportSettings
                        .ExportOnlyData = False
                        .FileName = str
                        .IgnorePaging = True
                        .OpenInNewWindow = True
                    End With
                    RadGridQvASummary.MasterTableView.ExportToExcel()
                End If
            Case "NonBillable"
                Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
                oAppVars.getAllAppVars()
                oAppVars.setAppVar("QvaFilterIncludeNB", CStr(Me.RadToolbarButtonIncludeNB.Checked), "Boolean")
                oAppVars.setAppVar("QvaFilterBreakoutAllNB", CStr(Me.RadToolbarButtonBreakoutAllNB.Checked), "Boolean")
                oAppVars.setAppVar("QvaFilterBreakoutNBForFT", CStr(Me.RadToolbarButtonBreakoutNBForFT.Checked), "Boolean")
                If Me.RadToolbarButtonIncludeNB.Checked = True Then
                    Me.RadToolbarButtonEmployeeTime.Enabled = False
                    Me.RadToolbarButtonIncomeOnly.Enabled = False
                    Me.RadToolbarButtonVendor.Enabled = False
                    Me.RadToolbarButtonEmployeeTime.Checked = False
                    Me.RadToolbarButtonIncomeOnly.Checked = False
                    Me.RadToolbarButtonVendor.Checked = False
                End If
                oAppVars.setAppVar("QvaFilterEmployeeTime", CStr(Me.RadToolbarButtonEmployeeTime.Checked), "Boolean")
                oAppVars.setAppVar("QvaFilterIncomeOnly", CStr(Me.RadToolbarButtonIncomeOnly.Checked), "Boolean")
                oAppVars.setAppVar("QvaFilterVendor", CStr(Me.RadToolbarButtonVendor.Checked), "Boolean")
                oAppVars.SaveAllAppVars()
                Me.RadGridQvASummary.Rebind()
                Me.RadGridQvaSummaryFunction.Rebind()
            Case "BreakoutNonBillable"
                Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
                oAppVars.getAllAppVars()
                oAppVars.setAppVar("QvaFilterIncludeNB", CStr(Me.RadToolbarButtonIncludeNB.Checked), "Boolean")
                oAppVars.setAppVar("QvaFilterBreakoutAllNB", CStr(Me.RadToolbarButtonBreakoutAllNB.Checked), "Boolean")
                oAppVars.setAppVar("QvaFilterBreakoutNBForFT", CStr(Me.RadToolbarButtonBreakoutNBForFT.Checked), "Boolean")
                If Me.RadToolbarButtonBreakoutAllNB.Checked = True Then
                    Me.RadToolbarButtonEmployeeTime.Enabled = False
                    Me.RadToolbarButtonIncomeOnly.Enabled = False
                    Me.RadToolbarButtonVendor.Enabled = False
                    Me.RadToolbarButtonEmployeeTime.Checked = False
                    Me.RadToolbarButtonIncomeOnly.Checked = False
                    Me.RadToolbarButtonVendor.Checked = False
                End If
                oAppVars.setAppVar("QvaFilterEmployeeTime", CStr(Me.RadToolbarButtonEmployeeTime.Checked), "Boolean")
                oAppVars.setAppVar("QvaFilterIncomeOnly", CStr(Me.RadToolbarButtonIncomeOnly.Checked), "Boolean")
                oAppVars.setAppVar("QvaFilterVendor", CStr(Me.RadToolbarButtonVendor.Checked), "Boolean")
                oAppVars.SaveAllAppVars()
                Me.RadGridQvASummary.Rebind()
                Me.RadGridQvaSummaryFunction.Rebind()
            Case "BreakoutNonBillableFT"
                Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
                oAppVars.getAllAppVars()
                oAppVars.setAppVar("QvaFilterIncludeNB", CStr(Me.RadToolbarButtonIncludeNB.Checked), "Boolean")
                oAppVars.setAppVar("QvaFilterBreakoutAllNB", CStr(Me.RadToolbarButtonBreakoutAllNB.Checked), "Boolean")
                oAppVars.setAppVar("QvaFilterBreakoutNBForFT", CStr(Me.RadToolbarButtonBreakoutNBForFT.Checked), "Boolean")
                If Me.RadToolbarButtonBreakoutNBForFT.Checked = True Then
                    Me.RadToolbarButtonEmployeeTime.Enabled = True
                    Me.RadToolbarButtonIncomeOnly.Enabled = True
                    Me.RadToolbarButtonVendor.Enabled = True
                    Me.RadToolbarButtonEmployeeTime.Checked = True
                    Me.RadToolbarButtonIncomeOnly.Checked = True
                    Me.RadToolbarButtonVendor.Checked = True
                Else
                    Me.RadToolbarButtonEmployeeTime.Enabled = False
                    Me.RadToolbarButtonIncomeOnly.Enabled = False
                    Me.RadToolbarButtonVendor.Enabled = False
                    Me.RadToolbarButtonEmployeeTime.Checked = False
                    Me.RadToolbarButtonIncomeOnly.Checked = False
                    Me.RadToolbarButtonVendor.Checked = False
                End If
                oAppVars.setAppVar("QvaFilterEmployeeTime", CStr(Me.RadToolbarButtonEmployeeTime.Checked), "Boolean")
                oAppVars.setAppVar("QvaFilterIncomeOnly", CStr(Me.RadToolbarButtonIncomeOnly.Checked), "Boolean")
                oAppVars.setAppVar("QvaFilterVendor", CStr(Me.RadToolbarButtonVendor.Checked), "Boolean")
                oAppVars.SaveAllAppVars()
                Me.RadGridQvASummary.Rebind()
                Me.RadGridQvaSummaryFunction.Rebind()
            Case "EmployeeTime"
                Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
                oAppVars.getAllAppVars()
                oAppVars.setAppVar("QvaFilterEmployeeTime", CStr(Me.RadToolbarButtonEmployeeTime.Checked), "Boolean")
                If Me.RadToolbarButtonEmployeeTime.Checked = True Or Me.RadToolbarButtonIncomeOnly.Checked = True Or Me.RadToolbarButtonVendor.Checked = True Then
                    Me.RadToolbarButtonIncludeNB.Checked = False
                    Me.RadToolbarButtonBreakoutAllNB.Checked = False
                    Me.RadToolbarButtonBreakoutNBForFT.Checked = True
                ElseIf Me.RadToolbarButtonEmployeeTime.Checked = False And Me.RadToolbarButtonIncomeOnly.Checked = False And Me.RadToolbarButtonVendor.Checked = False Then
                    Me.RadToolbarButtonIncludeNB.Checked = True
                    Me.RadToolbarButtonBreakoutAllNB.Checked = False
                    Me.RadToolbarButtonBreakoutNBForFT.Checked = False
                    Me.RadToolbarButtonEmployeeTime.Enabled = False
                    Me.RadToolbarButtonIncomeOnly.Enabled = False
                    Me.RadToolbarButtonVendor.Enabled = False
                End If
                oAppVars.setAppVar("QvaFilterIncludeNB", CStr(Me.RadToolbarButtonIncludeNB.Checked), "Boolean")
                oAppVars.setAppVar("QvaFilterBreakoutAllNB", CStr(Me.RadToolbarButtonBreakoutAllNB.Checked), "Boolean")
                oAppVars.setAppVar("QvaFilterBreakoutNBForFT", CStr(Me.RadToolbarButtonBreakoutNBForFT.Checked), "Boolean")
                oAppVars.SaveAllAppVars()
                Me.RadGridQvASummary.Rebind()
                Me.RadGridQvaSummaryFunction.Rebind()
            Case "IncomeOnly"
                Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
                oAppVars.getAllAppVars()
                oAppVars.setAppVar("QvaFilterIncomeOnly", CStr(Me.RadToolbarButtonIncomeOnly.Checked), "Boolean")
                If Me.RadToolbarButtonEmployeeTime.Checked = True Or Me.RadToolbarButtonIncomeOnly.Checked = True Or Me.RadToolbarButtonVendor.Checked = True Then
                    Me.RadToolbarButtonIncludeNB.Checked = False
                    Me.RadToolbarButtonBreakoutAllNB.Checked = False
                    Me.RadToolbarButtonBreakoutNBForFT.Checked = True
                ElseIf Me.RadToolbarButtonEmployeeTime.Checked = False And Me.RadToolbarButtonIncomeOnly.Checked = False And Me.RadToolbarButtonVendor.Checked = False Then
                    Me.RadToolbarButtonIncludeNB.Checked = True
                    Me.RadToolbarButtonBreakoutAllNB.Checked = False
                    Me.RadToolbarButtonBreakoutNBForFT.Checked = False
                    Me.RadToolbarButtonEmployeeTime.Enabled = False
                    Me.RadToolbarButtonIncomeOnly.Enabled = False
                    Me.RadToolbarButtonVendor.Enabled = False
                End If
                oAppVars.setAppVar("QvaFilterIncludeNB", CStr(Me.RadToolbarButtonIncludeNB.Checked), "Boolean")
                oAppVars.setAppVar("QvaFilterBreakoutAllNB", CStr(Me.RadToolbarButtonBreakoutAllNB.Checked), "Boolean")
                oAppVars.setAppVar("QvaFilterBreakoutNBForFT", CStr(Me.RadToolbarButtonBreakoutNBForFT.Checked), "Boolean")
                oAppVars.SaveAllAppVars()
                Me.RadGridQvASummary.Rebind()
                Me.RadGridQvaSummaryFunction.Rebind()
            Case "Vendor"
                Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
                oAppVars.getAllAppVars()
                oAppVars.setAppVar("QvaFilterVendor", CStr(Me.RadToolbarButtonVendor.Checked), "Boolean")
                If Me.RadToolbarButtonEmployeeTime.Checked = True Or Me.RadToolbarButtonIncomeOnly.Checked = True Or Me.RadToolbarButtonVendor.Checked = True Then
                    Me.RadToolbarButtonIncludeNB.Checked = False
                    Me.RadToolbarButtonBreakoutAllNB.Checked = False
                    Me.RadToolbarButtonBreakoutNBForFT.Checked = True
                ElseIf Me.RadToolbarButtonEmployeeTime.Checked = False And Me.RadToolbarButtonIncomeOnly.Checked = False And Me.RadToolbarButtonVendor.Checked = False Then
                    Me.RadToolbarButtonIncludeNB.Checked = True
                    Me.RadToolbarButtonBreakoutAllNB.Checked = False
                    Me.RadToolbarButtonBreakoutNBForFT.Checked = False
                    Me.RadToolbarButtonEmployeeTime.Enabled = False
                    Me.RadToolbarButtonIncomeOnly.Enabled = False
                    Me.RadToolbarButtonVendor.Enabled = False
                End If
                oAppVars.setAppVar("QvaFilterIncludeNB", CStr(Me.RadToolbarButtonIncludeNB.Checked), "Boolean")
                oAppVars.setAppVar("QvaFilterBreakoutAllNB", CStr(Me.RadToolbarButtonBreakoutAllNB.Checked), "Boolean")
                oAppVars.setAppVar("QvaFilterBreakoutNBForFT", CStr(Me.RadToolbarButtonBreakoutNBForFT.Checked), "Boolean")
                oAppVars.SaveAllAppVars()
                Me.RadGridQvASummary.Rebind()
                Me.RadGridQvaSummaryFunction.Rebind()
            Case "SalesTax"
                Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
                oAppVars.getAllAppVars()
                oAppVars.setAppVar("QvaFilterSalesTax", CStr(Me.RadToolbarButtonSalesTax.Checked), "Boolean")
                oAppVars.SaveAllAppVars()
                Try
                    Dim gtv As Telerik.Web.UI.GridTableView

                    If CType(oAppVars.getAppVar("QvaFilterBreakoutAllNB", "Boolean"), Boolean) = True Or CType(oAppVars.getAppVar("QvaFilterBreakoutNBForFT", "Boolean"), Boolean) = True Then

                        Me.RadGridQvASummary.MasterTableView.Columns.FindByUniqueName("GridBoundColumnPercentOfQuote").Visible = True
                        Me.RadGridQvaSummaryFunction.MasterTableView.Columns.FindByUniqueName("GridBoundColumnPercentOfQuote").Visible = True

                    End If

                    If Me.RadToolbarButtonSalesTax.Checked = False Then

                        Me.RadGridQvASummary.MasterTableView.Columns.FindByUniqueName("GridBoundColumnQuotedTax").Visible = False
                        Me.RadGridQvASummary.MasterTableView.Columns.FindByUniqueName("GridBoundColumnActualTax").Visible = False
                        Me.RadGridQvaSummaryFunction.MasterTableView.Columns.FindByUniqueName("GridBoundColumnQuotedTax").Visible = False
                        Me.RadGridQvaSummaryFunction.MasterTableView.Columns.FindByUniqueName("GridBoundColumnActualTax").Visible = False

                    Else

                        Me.RadGridQvASummary.MasterTableView.Columns.FindByUniqueName("GridBoundColumnQuotedTax").Visible = True
                        Me.RadGridQvASummary.MasterTableView.Columns.FindByUniqueName("GridBoundColumnActualTax").Visible = True
                        Me.RadGridQvaSummaryFunction.MasterTableView.Columns.FindByUniqueName("GridBoundColumnQuotedTax").Visible = True
                        Me.RadGridQvaSummaryFunction.MasterTableView.Columns.FindByUniqueName("GridBoundColumnActualTax").Visible = True

                    End If

                    '' ''Dim GridSettings As New GridSettingsPersister(Me.RadGridQvASummary)
                    '' ''GridSettings.SaveToDatabase()
                Catch ex As Exception

                End Try
                Me.RadGridQvASummary.Rebind()
                Me.RadGridQvaSummaryFunction.Rebind()
        End Select
    End Sub

#End Region

#Region " Methods "

    Private Sub LoadTabs()
        Try

            Dim tab As Integer = 0
            Dim ThisDate As Date

            Try
                If IsNumeric(Request.QueryString("Tab")) = True Then
                    tab = CInt(Request.QueryString("Tab"))
                Else
                    tab = 0
                End If
            Catch ex As Exception
                Me.ShowMessage("err getting tab id from qs")
            End Try

            SummaryTabs.Tabs.Clear()

            Dim PassIt As String = ""
            If JobNum > 0 And JobCompNum > 0 Then
                PassIt = "&JobNo=" & JobNum.ToString() & "&JobComp=" & JobCompNum.ToString()
            End If
            If Request.QueryString("group") = "job" Then
                PassIt &= "&JobNo=" & JobNum.ToString() & "&group=job"
            End If
            If Request.QueryString("group") = "campaign" Then
                PassIt &= "&CampaignID=" & CampaignID.ToString() & "&group=campaign&grouptype=" & Request.QueryString("grouptype") & "&DO=" & Request.QueryString("DO")
            End If
            If Request.QueryString("jd") = "1" Then
                PassIt &= "&jd=" & Request.QueryString("jd")
            End If
            Dim newTab As New Telerik.Web.UI.RadTab
            newTab.Text = "Summary"
            newTab.Value = 0
            newTab.NavigateUrl = "QuoteVsActualSummaryPopup.aspx?tab=0" & PassIt
            Me.SummaryTabs.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Detail"
            newTab.Value = 1
            newTab.NavigateUrl = "QuoteVsActualDetail.aspx?tab=1" & PassIt
            Me.SummaryTabs.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Billing"
            newTab.Value = 2
            newTab.NavigateUrl = "QuoteVsActualBilling.aspx?tab=2" & PassIt
            Me.SummaryTabs.Tabs.Add(newTab)
            'newTab = New Telerik.Web.UI.RadTab
            'newTab.Text = "Filter"
            'newTab.Value = 3
            'newTab.NavigateUrl = "QuoteVsActualFilterPopup.aspx?tab=3" & PassIt
            'Me.SummaryTabs.Tabs.Add(newTab)

            Dim selectTab As Telerik.Web.UI.RadTab = Me.SummaryTabs.FindTabByValue(tab)
            selectTab.Selected = True



        Catch ex As Exception
            Me.ShowMessage("err loading tabs " & ex.Message.ToString())
        End Try
    End Sub
    Private Function getApprovedHeaderAmount(ByVal jobNbr As String, ByVal jobComp As String) As Decimal
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim approvedAmount As Decimal = 0.0

        SQL_STRING = " SELECT ISNULL(SUM(APPROVED_AMT), 0) AS APPROVED_AMT FROM BILL_APPR_HDR "
        SQL_STRING = SQL_STRING & " WHERE JOB_NUMBER = '" & jobNbr & "' And JOB_COMPONENT_NBR = '" & jobComp & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:QuoteVsActualSummaryPopup Routine:getApprovedHeaderAmount", Err.Description)
        Finally

        End Try

        If dr.HasRows Then
            dr.Read()
            approvedAmount = dr.GetDecimal(0)
        End If

        Return approvedAmount

    End Function
    Private Sub SetGrantTotals(ByVal data As DataTable)
        Try

            If Not data Is Nothing Then

                If data.Rows.Count > 0 Then

                    With data

                        'Me.ActualAmount_GrandTotal = data.Compute("Sum(ActualAmount)", "FNC_TYPE = 'Subtotal'") - data.Compute("Sum(NBAmount)", "FNC_TYPE = 'Subtotal'")




                    End With

                End If

            End If

        Catch ex As Exception
            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))
        End Try
    End Sub

#End Region

End Class
