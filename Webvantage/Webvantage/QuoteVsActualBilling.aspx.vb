Imports Webvantage.wvTimeSheet
Imports Microsoft.VisualBasic

Imports System.Data.SqlClient
Imports Telerik.Web.UI

Partial Public Class QuoteVsActualBilling
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

    Dim camp As AdvantageFramework.Database.Entities.Campaign = Nothing

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        End If

    End Sub

    Private Sub LoadTabs(Optional ByVal strTheme As String = "ThreePointOhOatmeal.Master")
        Try

            Dim tab As Integer = 0
            Dim ThisDate As Date
            If Not Request.QueryString("ThisDate") Is Nothing Then
                ThisDate = CDate(Request.QueryString("ThisDate"))
            Else
                ThisDate = Date.Now.Date
            End If

            Try
                If IsNumeric(Request.QueryString("Tab")) = True Then
                    tab = CInt(Request.QueryString("Tab"))
                Else
                    tab = 0
                End If
            Catch ex As Exception
                tab = 2
            End Try

            BillingTabs.Tabs.Clear()

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
            Me.BillingTabs.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Detail"
            newTab.Value = 1
            newTab.NavigateUrl = "QuoteVsActualDetail.aspx?tab=1" & PassIt
            Me.BillingTabs.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Billing"
            newTab.Value = 2
            newTab.NavigateUrl = "QuoteVsActualBilling.aspx?tab=2" & PassIt
            Me.BillingTabs.Tabs.Add(newTab)
            'newTab = New Telerik.Web.UI.RadTab
            'newTab.Text = "Filter"
            'newTab.Value = 3
            'newTab.NavigateUrl = "QuoteVsActualFilterPopup.aspx?tab=3" & PassIt
            'Me.BillingTabs.Tabs.Add(newTab)

            Dim selectTab As Telerik.Web.UI.RadTab = Me.BillingTabs.FindTabByValue(tab)
            selectTab.Selected = True

        Catch ex As Exception
            Me.ShowMessage("err loading tabs " & ex.Message.ToString())
        End Try
    End Sub

    Private Sub LoadGrid()
        'Dim cts As cTimeSheet = New cTimeSheet(Session("ConnString"))
        'Me.RadTabStrip_Billing.DataSource = cts.GetQvABilling(Me.JobNum, Me.JobCompNum, Request.QueryString("group"))
        Dim Group As String = Nothing

        Group = Request.QueryString("group")

        If Group Is Nothing Then

            Group = ""

        End If

        Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Me.RadTabStrip_Billing.DataSource = AdvantageFramework.ProjectManagement.GetQvABilling(DbContext, Me.JobNum, Me.JobCompNum, Group, CampaignID, 0, Request.QueryString("DO"))
            Me.RadTabStrip_Billing.DataBind()

        End Using
        
    End Sub

    Private Sub RadTabStrip_Billing_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadTabStrip_Billing.ItemDataBound

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
            Case GridItemType.AlternatingItem, GridItemType.Item
                Dim DocumentsLinkButton As System.Web.UI.WebControls.ImageButton = CType(e.Item.FindControl("ImageButtonDocuments"), ImageButton)
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = e.Item
                Dim DocumentsDiv As System.Web.UI.HtmlControls.HtmlControl = CurrentGridRow.FindControl("DivDocuments")
                If Not DocumentsLinkButton Is Nothing Then

                    If CType(e.Item.DataItem, AdvantageFramework.ProjectManagement.Classes.QouteVsActualInvoiceBillingSummary).AttachmentCount > 0 Then

                        Dim qs As New AdvantageFramework.Web.QueryString()
                        With qs

                            .Page = "Documents_List2.aspx"
                            .DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice
                            .InvoiceNumber = CurrentGridRow.GetDataKeyValue("AR_INV_NBR")
                            .InvoiceSequenceNumber = CurrentGridRow.GetDataKeyValue("AR_INV_SEQ")

                        End With

                        With DocumentsLinkButton

                            .Attributes.Remove("onclick")
                            .Attributes.Add("onclick", Me.HookUpOpenWindow("Document List", qs.ToString(True)))
                            .AlternateText = CType(e.Item.DataItem, AdvantageFramework.ProjectManagement.Classes.QouteVsActualInvoiceBillingSummary).AttachmentCount & " attachments"
                            .ToolTip = CType(e.Item.DataItem, AdvantageFramework.ProjectManagement.Classes.QouteVsActualInvoiceBillingSummary).AttachmentCount & " attachments"

                        End With

                    Else

                        With DocumentsLinkButton

                            .Attributes.Remove("onclick")
                            .ImageUrl = "~\Images\spacer.gif"
                            .Enabled = False
                            .AlternateText = ""
                            .ToolTip = ""

                        End With

                        If DocumentsDiv IsNot Nothing Then AdvantageFramework.Web.Presentation.Controls.DivHide(DocumentsDiv)

                    End If

                End If
        End Select
    End Sub

    Private Sub RadToolbarQvA_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarQvA.ButtonClick
        Select Case e.Item.Value
            Case "Export"
                Dim str As String = ""
                If Me.CampaignID > 0 Then
                    str = "QvA_Billing" & "_" & CampaignID & "_" & CampaignCode & AdvantageFramework.StringUtilities.GUID_Date()
                Else
                    str = "QvA_Billing" & "_" & MiscFN.PadJobNum(Me.JobNum) & "_" & MiscFN.PadJobCompNum(Me.JobCompNum) & AdvantageFramework.StringUtilities.GUID_Date()
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

                RadTabStrip_Billing.MasterTableView.Caption = lab

                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadTabStrip_Billing, str)
                RadTabStrip_Billing.MasterTableView.ExportToExcel()
        End Select
    End Sub

    Private Sub RadTabStrip_Billing_PageIndexChanged(sender As Object, e As GridPageChangedEventArgs) Handles RadTabStrip_Billing.PageIndexChanged
        Try
            LoadGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub QuoteVsActualBilling_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Try
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()

            If qs.IsJobDashboard = True Then
                Dim di As GridItem = RadTabStrip_Billing.MasterTableView.GetItems(GridItemType.CommandItem)(0)
                di.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
