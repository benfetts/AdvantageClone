Imports Webvantage.wvTimeSheet
Imports Microsoft.VisualBasic

Imports System.Data.SqlClient
Imports System.Drawing
Imports Telerik.Web.UI

Partial Public Class QuoteVsActualDetail
    Inherits Webvantage.BaseChildPage

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


    Dim dtThisDate As Date
    Private JobNum As Integer = 0
    Private JobCompNum As Integer = 0
    Private CampaignID As Integer = 0
    Private CampaignCode As String = ""
    Private CampaignName As String = ""
    Private AppVarsInitialized As Boolean = False
    Private QvaFilterSalesTax As Boolean = False

    Dim camp As AdvantageFramework.Database.Entities.Campaign = Nothing


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

        If Request.QueryString("group") <> "job" And Request.QueryString("group") <> "campaign" Then
            If JobNum = 0 Or JobCompNum = 0 Then
                Me.lblMsg.Text = "Please select a Job and Job Component on Filter Tab"
            End If
        End If

        'Clean up old querystring names by letting clean qs class override
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.JobNumber > 0 Then Me.JobNum = qs.JobNumber
        If qs.JobComponentNumber > 0 Then Me.JobCompNum = qs.JobComponentNumber

        Me.MyUnityContextMenu.JobNumber = Me.JobNum
        Me.MyUnityContextMenu.JobComponentNumber = Me.JobCompNum
        Me.MyUnityContextMenu.HideItems = New UnityUC.UnityItem() {UnityUC.UnityItem.QvA}

        LoadTabs("ChildPage.Master")

        If Page.IsPostBack = True Then

            dtThisDate = CDate(ViewState("ThisDte"))

        Else

            LoadGrid()

            If AppVarsInitialized = False Then

                Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
                oAppVars.getAllAppVars()
                Me.QvaFilterSalesTax = CType(oAppVars.getAppVar("QvaFilterSalesTax", "Boolean"), Boolean)
                Me.RadToolbarButtonSalesTax.Checked = Me.QvaFilterSalesTax
                Me.AppVarsInitialized = True

            End If

        End If
    End Sub

    Private Sub LoadTabs(Optional ByVal strTheme As String = "ThreePointOhOatmeal.Master")
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
                tab = 1
            End Try

            DetailTabs.Tabs.Clear()
            Try
                If Not Request.QueryString("JobNo") Is Nothing Then
                    JobNum = CType(Request.QueryString("JobNo"), Integer)
                End If
            Catch ex As Exception
                JobNum = 0
            End Try
            Try
                If Not Request.QueryString("JobComp") Is Nothing Then
                    JobCompNum = CType(Request.QueryString("JobComp"), Integer)
                End If
            Catch ex As Exception
                JobCompNum = 0
            End Try
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
            Me.DetailTabs.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Detail"
            newTab.Value = 1
            newTab.NavigateUrl = "QuoteVsActualDetail.aspx?tab=1" & PassIt
            Me.DetailTabs.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Billing"
            newTab.Value = 2
            newTab.NavigateUrl = "QuoteVsActualBilling.aspx?tab=2" & PassIt
            Me.DetailTabs.Tabs.Add(newTab)
            'newTab = New Telerik.Web.UI.RadTab
            'newTab.Text = "Filter"
            'newTab.Value = 1
            'newTab.NavigateUrl = "QuoteVsActualFilterPopup.aspx?tab=3" & PassIt
            'Me.DetailTabs.Tabs.Add(newTab)

            Dim selectTab As Telerik.Web.UI.RadTab = Me.DetailTabs.FindTabByValue(tab)
            selectTab.Selected = True

        Catch ex As Exception
            Me.ShowMessage("err loading tabs " & ex.Message.ToString())
        End Try
    End Sub

    Private Sub LoadGrid()
        Dim cts As cTimeSheet = New cTimeSheet(Session("ConnString"))
        Dim job, comp As String
        Dim dr As SqlDataReader
        Dim dt As DataTable
        Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
        oAppVars.getAllAppVars()

        If Request.QueryString("group") = "job" Then
            dr = cts.GetQvADetailJob(Me.JobNum, Me.JobCompNum, Session("UserCode"))
        ElseIf Request.QueryString("group") = "campaign" Then
            dr = cts.GetQvADetailCampaign(Me.CampaignID, Request.QueryString("grouptype"), Session("UserCode"), Request.QueryString("DO"))
        Else
            dr = cts.GetQvADetail(Me.JobNum, Me.JobCompNum, Session("UserCode"))
        End If

        dt = createDetailTable(dr)
        Me.RadGrid_Detail.DataSource = dt
        SetGridSort(oAppVars.getAppVar("QvaFilterGroup"))

    End Sub

    Private Sub RadGrid_Detail_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid_Detail.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim btn As Button
        Select Case e.Item.ItemType
            Case GridItemType.CommandItem
                If e.CommandName = "Expand" Then
                    btn = e.Item.FindControl("btnExpand")
                    If btn.Text = "Collapse" Then
                        Me.RadGrid_Detail.MasterTableView.GroupsDefaultExpanded = False
                        btn.Text = "Expand"
                    ElseIf btn.Text = "Expand" Then
                        Me.RadGrid_Detail.MasterTableView.GroupsDefaultExpanded = True
                        btn.Text = "Collapse"
                    End If
                    Me.RadGrid_Detail.Rebind()
                End If

                'If e.CommandName = "GoToTask" Then
                '    Dim qs As New AdvantageFramework.Web.QueryString
                '    qs.Page = "Desktop_AlertView"
                '    If IsDBNull(CurrentGridRow.GetDataKeyValue("ALERT_ID")) = False Then
                '        qs.Add("AlertID", CurrentGridRow.GetDataKeyValue("ALERT_ID"))
                '    End If
                '    If IsDBNull(CurrentGridRow.GetDataKeyValue("SPRINT_ID")) = False Then
                '        qs.Add("SprintID", CurrentGridRow.GetDataKeyValue("SPRINT_ID"))
                '    Else
                '        qs.Add("SprintID", 0)
                '    End If
                '    CurrentGridRow.ExtractValues(newValues)

                '    Me.OpenWindow(qs, newValues("TASK_DESCRIPTION"))
                'End If

        End Select
    End Sub

    Dim actualhours As Decimal = 0
    Dim actualtotalhours As Decimal = 0
    Dim actualamount As Decimal = 0
    Dim actualtotal As Decimal = 0
    Dim markupamount As Decimal = 0
    Dim markuptotal As Decimal = 0
    Dim taxamount As Decimal = 0
    Dim taxtotal As Decimal = 0
    Dim totalamount As Decimal = 0
    Dim totaltotal As Decimal = 0
    Dim openpoamount As Decimal = 0
    Dim openpototal As Decimal = 0
    Dim billedtodate As Decimal = 0
    Dim billedtodatetotal As Decimal = 0
    Dim groupHeaderData As New System.Collections.Generic.Dictionary(Of String, String)
    Private Sub RadGrid_Detail_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid_Detail.ItemDataBound
        Dim btn As Button
        Dim di As Telerik.Web.UI.GridDataItem

        Dim qs2 As New AdvantageFramework.Web.QueryString()
        qs2 = qs2.FromCurrent()

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

                btn = e.Item.FindControl("btnExpand")
                If Me.RadGrid_Detail.MasterTableView.GroupsDefaultExpanded = False Then
                    btn.Text = "Expand"
                Else
                    btn.Text = "Collapse"
                End If
            Case GridItemType.AlternatingItem, GridItemType.Item
                di = e.Item

                If e.Item.DataItem("cc_fnc_desc") = "Estimate Total:" Then
                    e.Item.Font.Bold = True
                    di("cc_date").Text = "Estimate Total:"
                    Dim i As Int16
                    For i = 0 To e.Item.Cells.Count - 1
                        e.Item.Cells(i).Font.Bold = True
                        e.Item.Cells(i).Font.Italic = True
                        e.Item.Cells(i).ForeColor = Color.Black
                    Next
                Else
                    actualhours += CDec(e.Item.DataItem("cc_actual_hrs"))
                    actualamount += CDec(e.Item.DataItem("cc_actual_amount"))
                    markupamount += CDec(e.Item.DataItem("cc_actual_mkp"))
                    taxamount += CDec(e.Item.DataItem("cc_actual_tax"))
                    totalamount += CDec(e.Item.DataItem("cc_actual_total"))
                    openpoamount += CDec(e.Item.DataItem("cc_open_po"))
                    billedtodate += CDec(e.Item.DataItem("cc_billed"))
                End If

                Dim IsNonBillableDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivIsNonBillable")
                If e.Item.DataItem("cc_fnc_desc") = "Estimate Total:" OrElse e.Item.DataItem("cc_nonbill_flag") = 0 Then

                    AdvantageFramework.Web.Presentation.Controls.DivHide(IsNonBillableDiv)

                End If

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = e.Item
                Dim DocumentsInvoiceLinkButton As System.Web.UI.WebControls.LinkButton = CType(e.Item.FindControl("LinkButtonDocumentsInvoice"), LinkButton)
                Dim DocumentsInvoiceDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivDocumentsInvoice")

                If Not DocumentsInvoiceLinkButton Is Nothing Then

                    If e.Item.DataItem("cc_fnc_desc") = "Estimate Total:" Or CType(e.Item.DataItem("cc_attachment_count_ap"), Integer) = 0 Then

                        AdvantageFramework.Web.Presentation.Controls.DivHide(DocumentsInvoiceDiv)

                    Else

                        Dim qs As New AdvantageFramework.Web.QueryString()
                        With qs

                            .Page = "Documents_List2.aspx"
                            .DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice
                            .APID = CurrentGridRow.GetDataKeyValue("cc_rec_id")
                            .APInvoice = CurrentGridRow.GetDataKeyValue("cc_ap_inv")
                            .VendorCode = CurrentGridRow.GetDataKeyValue("cc_supplier_code")

                        End With

                        With DocumentsInvoiceLinkButton

                            .Attributes.Remove("onclick")
                            .Attributes.Add("onclick", Me.HookUpOpenWindow("Document List", qs.ToString(True)))

                        End With

                    End If



                End If

                Dim DocumentsARLinkButton As System.Web.UI.WebControls.LinkButton = CType(e.Item.FindControl("LinkButtonDocumentsAR"), LinkButton)
                Dim DocumentsARDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivDocumentsAR")

                If Not DocumentsARLinkButton Is Nothing Then

                    If CType(e.Item.DataItem("cc_attachment_count"), Integer) > 0 Then

                        Dim qs As New AdvantageFramework.Web.QueryString()
                        With qs

                            .Page = "Documents_List2.aspx"
                            .DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice
                            .InvoiceNumber = CurrentGridRow.GetDataKeyValue("cc_ar_inv_nbr")
                            .InvoiceSequenceNumber = CurrentGridRow.GetDataKeyValue("cc_ar_inv_seq")

                        End With

                        With DocumentsARLinkButton

                            .Attributes.Remove("onclick")
                            .Attributes.Add("onclick", Me.HookUpOpenWindow("Document List", qs.ToString(True)))
                            '.AlternateText = e.Item.DataItem("cc_attachment_count") & " attachments"
                            .ToolTip = e.Item.DataItem("cc_attachment_count") & " attachments"

                        End With

                    Else

                        AdvantageFramework.Web.Presentation.Controls.DivHide(DocumentsARDiv)

                    End If

                End If

                Dim TaskLinkButton As System.Web.UI.WebControls.LinkButton = CType(e.Item.FindControl("LinkButtonTask"), LinkButton)
                Dim AssignmentLinkButton As System.Web.UI.WebControls.LinkButton = CType(e.Item.FindControl("LinkButtonAssignment"), LinkButton)
                Dim TaskDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivGoToTask")
                Dim AssignmentDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivGoToAssignment")

                If Not TaskLinkButton Is Nothing AndAlso Not AssignmentLinkButton Is Nothing Then

                    If e.Item.DataItem("cc_fnc_desc") = "Estimate Total:" Or e.Item.DataItem("cc_alert_type") = "" Then

                        AdvantageFramework.Web.Presentation.Controls.DivHide(DocumentsInvoiceDiv)
                        AdvantageFramework.Web.Presentation.Controls.DivHide(TaskDiv)
                        AdvantageFramework.Web.Presentation.Controls.DivHide(AssignmentDiv)

                    Else

                        If e.Item.DataItem("cc_alert_type") = "T" Then

                            AdvantageFramework.Web.Presentation.Controls.DivHide(AssignmentDiv)

                            Dim qs As New AdvantageFramework.Web.QueryString()
                            With qs

                                .Page = "Desktop_AlertView"
                                If e.Item.DataItem("cc_alert_id") > 0 Then
                                    '.AlertID = e.Item.DataItem("cc_alert_id")
                                    qs.Add("AlertID", e.Item.DataItem("cc_alert_id"))
                                End If
                                'If IsDBNull(CurrentGridRow.GetDataKeyValue("SPRINT_ID")) = False Then
                                '    qs.Add("SprintID", CurrentGridRow.GetDataKeyValue("SPRINT_ID"))
                                'Else
                                qs.Add("SprintID", 0)
                                'End If

                            End With

                            With TaskLinkButton

                                .Attributes.Remove("onclick")

                                Try

                                    If IsDBNull(e.Item.DataItem("cc_fnc_desc")) = False Then

                                        .Attributes.Add("onclick", Me.HookUpOpenWindow(e.Item.DataItem("cc_fnc_desc"), qs.ToString(True)))

                                    Else

                                        .Attributes.Add("onclick", Me.HookUpOpenWindow("Task", qs.ToString(True)))

                                    End If

                                Catch ex As Exception
                                    .Attributes.Add("onclick", Me.HookUpOpenWindow("Task", qs.ToString(True)))
                                End Try


                            End With

                        End If

                        If e.Item.DataItem("cc_alert_type") = "A" Then

                            AdvantageFramework.Web.Presentation.Controls.DivHide(TaskDiv)

                            Dim qs As New AdvantageFramework.Web.QueryString()
                            With qs

                                .Page = "Desktop_AlertView"
                                If e.Item.DataItem("cc_alert_id") > 0 Then
                                    qs.Add("AlertID", e.Item.DataItem("cc_alert_id"))
                                End If
                                'If IsDBNull(CurrentGridRow.GetDataKeyValue("SPRINT_ID")) = False Then
                                '    qs.Add("SprintID", CurrentGridRow.GetDataKeyValue("SPRINT_ID"))
                                'Else
                                qs.Add("SprintID", 0)
                                'End If

                            End With

                            With AssignmentLinkButton

                                .Attributes.Remove("onclick")

                                Try

                                    If IsDBNull(e.Item.DataItem("cc_alert_desc")) = False Then

                                        .Attributes.Add("onclick", Me.HookUpOpenWindow(e.Item.DataItem("cc_alert_desc"), qs.ToString(True)))

                                    Else

                                        .Attributes.Add("onclick", Me.HookUpOpenWindow("Assignment", qs.ToString(True)))

                                    End If

                                Catch ex As Exception
                                    .Attributes.Add("onclick", Me.HookUpOpenWindow("Assignment", qs.ToString(True)))
                                End Try

                            End With

                        End If

                    End If

                End If

            Case GridItemType.GroupHeader

                Dim GrpHdr As Telerik.Web.UI.GridGroupHeaderItem
                GrpHdr = e.Item

                If Not GrpHdr Is Nothing Then

                    groupHeaderData.Add(e.Item.GroupIndex, GrpHdr.DataCell.Text)

                End If

            Case GridItemType.GroupFooter

                e.Item.Font.Bold = True

                Dim GrpFtr As Telerik.Web.UI.GridGroupFooterItem
                GrpFtr = e.Item

                If Not GrpFtr Is Nothing Then
                    If GrpFtr.GroupIndex.Length > 1 Then
                        GrpFtr("cc_date").Text = "Total Actuals:"
                        GrpFtr("cc_actual_hrs").Text = String.Format("{0:#,##0.00}", actualhours)
                        GrpFtr("cc_actual_amount").Text = String.Format("{0:#,##0.00}", actualamount)
                        GrpFtr("cc_actual_mkp").Text = String.Format("{0:#,##0.00}", markupamount)
                        GrpFtr("cc_actual_tax").Text = String.Format("{0:#,##0.00}", taxamount)
                        GrpFtr("cc_actual_total").Text = String.Format("{0:#,##0.00}", totalamount)
                        GrpFtr("cc_open_po").Text = String.Format("{0:#,##0.00}", openpoamount)
                        GrpFtr("cc_billed").Text = String.Format("{0:#,##0.00}", billedtodate)
                        actualtotalhours += actualhours
                        actualtotal += actualamount
                        markuptotal += markupamount
                        taxtotal += taxamount
                        totaltotal += totalamount
                        openpototal += openpoamount
                        billedtodatetotal += billedtodate
                        actualhours = 0
                        actualamount = 0
                        markupamount = 0
                        taxamount = 0
                        totalamount = 0
                        openpoamount = 0
                        billedtodate = 0
                    Else
                        Dim g() As String = groupHeaderData(GrpFtr.GroupIndex).Split(New String() {":"}, StringSplitOptions.RemoveEmptyEntries)
                        GrpFtr("cc_date").Text = g(1) & " Totals for Page:"
                        GrpFtr("cc_actual_hrs").Text = String.Format("{0:#,##0.00}", actualtotalhours)
                        GrpFtr("cc_actual_amount").Text = String.Format("{0:#,##0.00}", actualtotal)
                        GrpFtr("cc_actual_mkp").Text = String.Format("{0:#,##0.00}", markuptotal)
                        GrpFtr("cc_actual_tax").Text = String.Format("{0:#,##0.00}", taxtotal)
                        GrpFtr("cc_actual_total").Text = String.Format("{0:#,##0.00}", totaltotal)
                        GrpFtr("cc_open_po").Text = String.Format("{0:#,##0.00}", openpototal)
                        GrpFtr("cc_billed").Text = String.Format("{0:#,##0.00}", billedtodatetotal)
                        actualtotalhours = 0
                        actualtotal = 0
                        markuptotal = 0
                        taxtotal = 0
                        totaltotal = 0
                        openpototal = 0
                        billedtodatetotal = 0
                    End If
                End If

        End Select

    End Sub

    Private Sub RadGrid_Detail_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid_Detail.NeedDataSource
        Dim cts As cTimeSheet = New cTimeSheet(Session("ConnString"))
        Dim dr As SqlDataReader
        Dim dt As DataTable
        Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
        oAppVars.getAllAppVars()
        If Request.QueryString("group") = "job" Then
            dr = cts.GetQvADetailJob(Me.JobNum, Me.JobCompNum, Session("UserCode"))
        ElseIf Request.QueryString("group") = "campaign" Then
            dr = cts.GetQvADetailCampaign(Me.CampaignID, Request.QueryString("grouptype"), Session("UserCode"), Request.QueryString("DO"))
        Else
            dr = cts.GetQvADetail(Me.JobNum, Me.JobCompNum, Session("UserCode"))
        End If
        'dr = cts.GetQvADetail(Me.JobNum, Me.JobCompNum, Session("UserCode"))
        dt = createDetailTable(dr)
        Me.RadGrid_Detail.DataSource = dt
        If Me.RadToolbarButtonSalesTax.Checked = False Then
            Me.RadGrid_Detail.MasterTableView.Columns.FindByUniqueName("cc_actual_tax").Visible = False
        Else
            Me.RadGrid_Detail.MasterTableView.Columns.FindByUniqueName("cc_actual_tax").Visible = True
        End If
        SetGridSort(oAppVars.getAppVar("QvaFilterGroup"))
    End Sub

    Private Function createDetailTable(ByVal dr As SqlDataReader)
        Dim dt As DataTable
        Dim row As DataRow
        Dim est As Int32
        Dim ar_inv As Integer
        Dim ar_seq As Integer

        dt = New DataTable("detail")
        Dim cc_fnc_code As DataColumn = New DataColumn("cc_fnc_code")
        Dim cc_fnc_desc As DataColumn = New DataColumn("cc_fnc_desc")
        Dim cc_fnc_type As DataColumn = New DataColumn("cc_fnc_type")
        Dim cc_est As DataColumn = New DataColumn("cc_est")
        Dim cc_date As DataColumn = New DataColumn("cc_date")
        Dim cc_dve_field As DataColumn = New DataColumn("cc_dve_field")
        Dim cc_ref_invoice As DataColumn = New DataColumn("cc_ref_invoice")
        Dim cc_actual_hrs As DataColumn = New DataColumn("cc_actual_hrs", System.Type.GetType("System.Decimal"))
        Dim cc_actual_amount As DataColumn = New DataColumn("cc_actual_amount", System.Type.GetType("System.Decimal"))
        Dim cc_actual_mkp As DataColumn = New DataColumn("cc_actual_mkp", System.Type.GetType("System.Decimal"))
        Dim cc_actual_tax As DataColumn = New DataColumn("cc_actual_tax", System.Type.GetType("System.Decimal"))
        Dim cc_actual_total As DataColumn = New DataColumn("cc_actual_total", System.Type.GetType("System.Decimal"))
        Dim cc_nonbill_flag As DataColumn = New DataColumn("cc_nonbill_flag")
        Dim cc_open_po As DataColumn = New DataColumn("cc_open_po", System.Type.GetType("System.Decimal"))
        Dim cc_billed As DataColumn = New DataColumn("cc_billed", System.Type.GetType("System.Decimal"))
        Dim cc_ar_inv_nbr As DataColumn = New DataColumn("cc_ar_inv_nbr")
        Dim cc_adj_comment As DataColumn = New DataColumn("cc_adj_comment")
        Dim cc_attachment_count As DataColumn = New DataColumn("cc_attachment_count")
        Dim cc_attachment_count_ap As DataColumn = New DataColumn("cc_attachment_count_ap")
        ' Dim cc_job As DataColumn = New DataColumn("cc_job")

        Dim cc_group As DataColumn = New DataColumn("cc_group")
        Dim cc_fnc_name As DataColumn = New DataColumn("cc_fnc_name")
        Dim cc_fnc_headingid As DataColumn = New DataColumn("cc_fnc_headingid")
        Dim cc_fnc_headingdesc As DataColumn = New DataColumn("cc_fnc_headingdesc")
        Dim cc_fnc_consolidationcode As DataColumn = New DataColumn("cc_fnc_consolidationcode")
        Dim cc_fnc_consolidationname As DataColumn = New DataColumn("cc_fnc_consolidationname")
        Dim cc_ar_inv_seq As DataColumn = New DataColumn("cc_ar_inv_seq")
        Dim cc_ap_inv As DataColumn = New DataColumn("cc_ap_inv")
        Dim cc_supplier_code As DataColumn = New DataColumn("cc_supplier_code")
        Dim cc_rec_id As DataColumn = New DataColumn("cc_rec_id")
        Dim cc_ap_id As DataColumn = New DataColumn("cc_ap_id")
        Dim cc_alert_id As DataColumn = New DataColumn("cc_alert_id")
        Dim cc_alert_type As DataColumn = New DataColumn("cc_alert_type")
        Dim cc_alert_desc As DataColumn = New DataColumn("cc_alert_desc")

        dt.Columns.Add(cc_fnc_code)
        dt.Columns.Add(cc_fnc_desc)
        dt.Columns.Add(cc_fnc_type)
        dt.Columns.Add(cc_est)
        dt.Columns.Add(cc_date)
        dt.Columns.Add(cc_dve_field)
        dt.Columns.Add(cc_ref_invoice)
        dt.Columns.Add(cc_actual_hrs)
        dt.Columns.Add(cc_actual_amount)
        dt.Columns.Add(cc_actual_mkp)
        dt.Columns.Add(cc_actual_tax)
        dt.Columns.Add(cc_actual_total)
        dt.Columns.Add(cc_nonbill_flag)
        dt.Columns.Add(cc_open_po)
        dt.Columns.Add(cc_billed)
        dt.Columns.Add(cc_ar_inv_nbr)
        dt.Columns.Add(cc_adj_comment)

        dt.Columns.Add(cc_group)
        dt.Columns.Add(cc_fnc_name)
        dt.Columns.Add(cc_fnc_headingid)
        dt.Columns.Add(cc_fnc_headingdesc)
        dt.Columns.Add(cc_fnc_consolidationcode)
        dt.Columns.Add(cc_fnc_consolidationname)
        dt.Columns.Add(cc_ar_inv_seq)
        dt.Columns.Add(cc_ap_inv)
        dt.Columns.Add(cc_supplier_code)
        dt.Columns.Add(cc_attachment_count)
        dt.Columns.Add(cc_attachment_count_ap)
        dt.Columns.Add(cc_rec_id)
        dt.Columns.Add(cc_ap_id)
        dt.Columns.Add(cc_alert_id)
        dt.Columns.Add(cc_alert_type)
        dt.Columns.Add(cc_alert_desc)

        row = dt.NewRow

        Do While dr.Read
            est = dr.GetInt32(3)

            row.Item("cc_fnc_code") = dr.GetString(0)
            row.Item("cc_supplier_code") = dr.GetString(20)
            row.Item("cc_attachment_count") = dr.GetInt32(35)
            row.Item("cc_attachment_count_ap") = dr.GetInt32(36)

            Try

                If IsDBNull(dr.GetValue(37)) = False Then row.Item("cc_alert_id") = dr.GetInt32(37)

            Catch ex As Exception
            End Try
            Try

                If IsDBNull(dr.GetValue(38)) = False Then row.Item("cc_alert_type") = dr.GetString(38)

            Catch ex As Exception
            End Try
            Try

                If IsDBNull(dr.GetValue(39)) = False Then row.Item("cc_alert_desc") = dr.GetString(39)

            Catch ex As Exception
            End Try

            If IsDBNull(dr("cc_fnc_desc")) = True Then
                row.Item("cc_fnc_desc") = ""
            Else
                row.Item("cc_fnc_desc") = dr.GetString(1)
            End If

            row.Item("cc_est") = dr.GetInt32(3)
            row.Item("cc_group") = dr.GetString(26)

            row.Item("cc_fnc_name") = dr.GetString(27)
            If IsDBNull(dr("cc_fnc_headingid")) = True Then
                row.Item("cc_fnc_headingid") = 0
            Else
                row.Item("cc_fnc_headingid") = dr.GetInt32(28)
            End If
            If IsDBNull(dr("cc_fnc_headingdesc")) = True Then
                row.Item("cc_fnc_headingdesc") = ""
            Else
                row.Item("cc_fnc_headingdesc") = dr.GetString(29)
            End If
            If IsDBNull(dr("cc_fnc_consolidationcode")) = True Then
                row.Item("cc_fnc_consolidationcode") = ""
            Else
                row.Item("cc_fnc_consolidationcode") = dr.GetString(30)
            End If
            If IsDBNull(dr("cc_fnc_consolidationname")) = True Then
                row.Item("cc_fnc_consolidationname") = ""
            Else
                row.Item("cc_fnc_consolidationname") = dr.GetString(31)
            End If

            If IsDBNull(dr("cc_fnc_type")) = True Then
                row.Item("cc_fnc_type") = ""
            Else
                row.Item("cc_fnc_type") = dr.GetString(2)
            End If

            If IsDBNull(dr("cc_date")) = True Then
                row.Item("cc_date") = ""
            Else
                row.Item("cc_date") = dr.GetDateTime(4).ToShortDateString
            End If

            If IsDBNull(dr("cc_dve_field")) = True Then
                row.Item("cc_dve_field") = ""
            Else
                row.Item("cc_dve_field") = dr.GetString(5)
            End If

            If IsDBNull(dr("cc_ref_invoice")) = True Then
                row.Item("cc_ref_invoice") = ""
            Else
                row.Item("cc_ref_invoice") = dr.GetString(6)
            End If

            If IsDBNull(dr("cc_ap_inv")) = True Then
                row.Item("cc_ap_inv") = ""
            Else
                row.Item("cc_ap_inv") = dr.GetString(34)
            End If

            If est = 1 Then
                If IsDBNull(dr("cc_est_hrs")) = True Then
                    row.Item("cc_actual_hrs") = "0.00"
                Else
                    row.Item("cc_actual_hrs") = dr.GetDecimal(7).ToString("#,##0.00")   'cc_est_hrs
                End If

                If IsDBNull(dr("cc_est_amount")) = True Then
                    row.Item("cc_actual_amount") = "0.00"
                Else
                    row.Item("cc_actual_amount") = dr.GetDecimal(8).ToString("#,##0.00") 'cc_est_amount
                End If

                If IsDBNull(dr("cc_est_mkp")) = True Then
                    row.Item("cc_actual_mkp") = "0.00"
                Else
                    row.Item("cc_actual_mkp") = dr.GetDecimal(11).ToString("#,##0.00")   'cc_est_mkp
                End If

                If IsDBNull(dr("cc_est_tax")) = True Then
                    row.Item("cc_actual_tax") = "0.00"
                Else
                    row.Item("cc_actual_tax") = dr.GetDecimal(9).ToString("#,##0.00")   'cc_est_tax
                End If

                If IsDBNull(dr("cc_est_total")) = True Then
                    row.Item("cc_actual_total") = "0.00"
                Else
                    row.Item("cc_actual_total") = dr.GetDecimal(10).ToString("#,##0.00") 'cc_est_total
                End If

            Else
                If IsDBNull(dr("cc_actual_hrs")) = True Then
                    row.Item("cc_actual_hrs") = "0.00"
                Else
                    row.Item("cc_actual_hrs") = dr.GetDecimal(12).ToString("#,##0.00")
                End If

                If IsDBNull(dr("cc_actual_amount")) = True Then
                    row.Item("cc_actual_amount") = "0.00"
                Else
                    row.Item("cc_actual_amount") = dr.GetDecimal(13).ToString("#,##0.00")
                End If

                If IsDBNull(dr("cc_actual_mkp")) = True Then
                    row.Item("cc_actual_mkp") = "0.00"
                Else
                    row.Item("cc_actual_mkp") = dr.GetDecimal(16).ToString("#,##0.00")
                End If

                If IsDBNull(dr("cc_actual_tax")) = True Then
                    row.Item("cc_actual_tax") = "0.00"
                Else
                    row.Item("cc_actual_tax") = dr.GetDecimal(14).ToString("#,##0.00")
                End If

                If IsDBNull(dr("cc_actual_total")) = True Then
                    row.Item("cc_actual_total") = "0.00"
                Else
                    row.Item("cc_actual_total") = dr.GetDecimal(15).ToString("#,##0.00")
                End If
            End If

            If IsDBNull(dr("cc_nonbill_flag")) = True Then
                row.Item("cc_nonbill_flag") = 0
            Else
                row.Item("cc_nonbill_flag") = dr.GetInt32(21)
            End If

            If IsDBNull(dr("cc_open_po")) = True Then
                row.Item("cc_open_po") = "0.00"
            Else
                row.Item("cc_open_po") = dr.GetDecimal(18).ToString("#,##0.00")
            End If

            If IsDBNull(dr("cc_billed")) = True Then
                row.Item("cc_billed") = "0.00"
            Else
                row.Item("cc_billed") = dr.GetDecimal(17).ToString("#,##0.00")
            End If

            If IsDBNull(dr("cc_ar_inv_nbr")) = True Then
                'row.Item("cc_ar_inv_nbr") = 0
            Else
                ar_inv = dr.GetInt32(19)
                If ar_inv > 0 Then
                    row.Item("cc_ar_inv_nbr") = ar_inv
                End If
            End If

            If IsDBNull(dr("cc_ar_inv_seq")) = True Then
                'row.Item("cc_ar_inv_nbr") = 0
            Else
                ar_seq = dr.GetInt32(32)
                If ar_seq >= 0 Then
                    row.Item("cc_ar_inv_seq") = ar_seq
                End If
            End If

            If IsDBNull(dr("cc_adj_comment")) = True Then
                row.Item("cc_adj_comment") = ""
            Else
                row.Item("cc_adj_comment") = dr.GetString(23)
            End If

            If IsDBNull(dr("cc_rec_id")) = True Then
                row.Item("cc_rec_id") = 0
            Else
                row.Item("cc_rec_id") = dr.GetInt32(24)
            End If

            If IsDBNull(dr("cc_ap_id")) = True Then
                row.Item("cc_ap_id") = 0
            Else
                row.Item("cc_ap_id") = dr.GetInt32(33)
            End If
            'row.Item("cc_job") = dr.GetInt32(37)
            dt.Rows.Add(row)
            row = dt.NewRow
        Loop
        dr.Close()
        Return dt
    End Function

    Private Sub RadToolbarQvA_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarQvA.ButtonClick
        Select Case e.Item.Value
            Case "Export"
                Dim str As String = ""
                If Me.CampaignID > 0 Then
                    str = "QvA_Detail" & "_" & CampaignID & "_" & CampaignCode & AdvantageFramework.StringUtilities.GUID_Date()
                Else
                    str = "QvA_Detail" & "_" & MiscFN.PadJobNum(Me.JobNum) & "_" & MiscFN.PadJobCompNum(Me.JobCompNum) & AdvantageFramework.StringUtilities.GUID_Date()
                End If

                Dim oJob As New Job(Session("ConnString"))
                Dim lab As String
                If Request.QueryString("group") = "job" Then
                    oJob.GetJob(Me.JobNum)
                    lab = "Job:" & Me.JobNum.ToString().PadLeft(6, "0") & " - " & oJob.JOB_DESC & " / Job Comp: All"
                ElseIf Request.QueryString("group") = "campaign" Then
                    lab = "Campaign:  " & Me.CampaignCode & "-" & Me.CampaignName
                Else
                    oJob.GetJob(Me.JobNum, Me.JobCompNum)
                    lab = "Job:" & Me.JobNum.ToString().PadLeft(6, "0") & " - " & oJob.JOB_DESC & " / Job Comp:" & Me.JobCompNum.ToString().PadLeft(3, "0") & " - " & oJob.JobComponent.JOB_COMP_DESC
                End If

                RadGrid_Detail.MasterTableView.Caption = lab
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGrid_Detail, str)
                RadGrid_Detail.MasterTableView.ExportToExcel()
            Case "SalesTax"
                Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
                oAppVars.getAllAppVars()
                oAppVars.setAppVar("QvaFilterSalesTax", CStr(Me.RadToolbarButtonSalesTax.Checked), "Boolean")
                oAppVars.SaveAllAppVars()
                Me.RadGrid_Detail.Rebind()
        End Select
    End Sub

    Private Sub RadGrid_Detail_PreRender(sender As Object, e As System.EventArgs) Handles RadGrid_Detail.PreRender
        Try


        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetGridSort(ByVal StrSort As String)
        Try
            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
            Dim GrpExpr2 As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
            Dim gbf As Telerik.Web.UI.GridGroupByField
            Select Case StrSort
                Case "Type"
                    gbf = New Telerik.Web.UI.GridGroupByField
                    gbf.FieldName = "cc_fnc_name"
                    gbf.FieldAlias = "Type"
                    gbf.HeaderText = ""
                    GrpExpr.SelectFields.Add(gbf)
                    gbf = New Telerik.Web.UI.GridGroupByField
                    gbf.FieldName = "cc_fnc_type"
                    gbf.FieldAlias = "cc_fnc_type"
                    gbf.HeaderText = ""
                    GrpExpr.GroupByFields.Add(gbf)
                    With Me.RadGrid_Detail
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                    End With
                Case "Heading"
                    gbf = New Telerik.Web.UI.GridGroupByField
                    gbf.FieldName = "cc_fnc_headingdesc"
                    gbf.FieldAlias = "Heading"
                    gbf.HeaderText = ""
                    GrpExpr.SelectFields.Add(gbf)
                    gbf = New Telerik.Web.UI.GridGroupByField
                    gbf.FieldName = "cc_fnc_headingid"
                    gbf.FieldAlias = "cc_fnc_headingid"
                    gbf.HeaderText = ""
                    GrpExpr.GroupByFields.Add(gbf)
                    With Me.RadGrid_Detail
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                    End With
                Case "Consolidation"
                    gbf = New Telerik.Web.UI.GridGroupByField
                    gbf.FieldName = "cc_fnc_consolidationname"
                    gbf.FieldAlias = "Consolidation"
                    gbf.HeaderText = ""
                    GrpExpr.SelectFields.Add(gbf)
                    gbf = New Telerik.Web.UI.GridGroupByField
                    gbf.FieldName = "cc_fnc_consolidationcode"
                    gbf.FieldAlias = "cc_fnc_consolidationcode"
                    gbf.HeaderText = ""
                    GrpExpr.GroupByFields.Add(gbf)
                    With Me.RadGrid_Detail
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                    End With
                Case Else
                    gbf = New Telerik.Web.UI.GridGroupByField
                    gbf.FieldName = "cc_fnc_name"
                    gbf.FieldAlias = "Type"
                    gbf.HeaderText = ""
                    GrpExpr.SelectFields.Add(gbf)
                    gbf = New Telerik.Web.UI.GridGroupByField
                    gbf.FieldName = "cc_fnc_type"
                    gbf.HeaderText = ""
                    GrpExpr.GroupByFields.Add(gbf)
                    With Me.RadGrid_Detail
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                    End With
            End Select
            gbf = New Telerik.Web.UI.GridGroupByField
            gbf.FieldName = "cc_group"
            gbf.FieldAlias = "Function"
            gbf.HeaderText = ""
            GrpExpr2.SelectFields.Add(gbf)
            gbf = New Telerik.Web.UI.GridGroupByField
            gbf.FieldName = "cc_group"
            gbf.HeaderText = ""
            GrpExpr2.GroupByFields.Add(gbf)
            With Me.RadGrid_Detail
                .MasterTableView.GroupByExpressions.Add(GrpExpr2)
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGrid_Detail_DataBound(sender As Object, e As EventArgs) Handles RadGrid_Detail.DataBound
        Try
            'Dim ccest As Integer
            'Dim cctype As String
            'Dim emptimetotal As Decimal
            'For Each item As Telerik.Web.UI.GridDataItem In Me.RadGrid_Detail.MasterTableView.Items
            '    ccest = item.GetDataKeyValue("cc_est")
            '    cctype = item.GetDataKeyValue("cc_fnc_type")

            '    If ccest = 0 And cctype = "E" Then
            '        emptimetotal += item.GetDataKeyValue("cc_actual_hrs")
            '    End If

            'Next

            'Dim gf As GridFooterItem = RadGrid_Detail.MasterTableView.GetItems(GridItemType.Footer)(0)
            'gf("cc_actual_hrs").Text = emptimetotal

        Catch ex As Exception

        End Try
    End Sub

    Private Sub QuoteVsActualDetail_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Try
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()

            If qs.IsJobDashboard = True Then
                Dim di As GridItem = RadGrid_Detail.MasterTableView.GetItems(GridItemType.CommandItem)(0)
                di.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
