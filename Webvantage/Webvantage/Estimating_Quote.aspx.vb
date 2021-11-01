Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports Webvantage.cGlobals
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports System.Threading
Imports System.Web.UI.HtmlControls
Imports System.Drawing
Imports AdvantageFramework.AlertSystem.Classes

Partial Public Class Estimating_Quote
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

#Region " Private vars: "
    Private EstNum As Integer = 0
    Private EstCompNum As Integer = 0
    Private QuoteNum As Integer = 0
    Private RevNum As Integer = 0
    Private JobNum As Integer = 0
    Private JobCompNum As Integer = 0
    Private CampaignID As Integer = 0
    Private count As Integer = 0
    Private ReloadMe As Boolean = False
    Private SetPhase As Boolean = False
    Private del As Boolean = False
    Private mess As String = ""
    Private rights As String = ""
    Private _GridIsGrouped As Boolean = False
    Private approvalType As String = ""
    Public HeaderDatakey As String = ""
    Protected WithEvents txtBlendRate As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddPhase As Telerik.Web.UI.RadComboBox
    Protected WithEvents DropSort As Telerik.Web.UI.RadComboBox
    Private _CanUserInsertPO As Boolean = True
    Private _LoadingDatasource As Boolean = False

#End Region

    Public JavascriptArrayQuantityHours As String = ""
    Public JavascriptArrayExtendedAmount As String = ""
    Public JavascriptArrayMarkupAmount As String = ""
    Public JavascriptArrayFunctionTotal As String = ""
    Public JavascriptArrayGrossIncome As String = ""
    Public JavascriptArrayContingencyAmount As String = ""
    Public JavascriptArrayTotalWithContingencyAmount As String = ""

    Public Property DtQuoteFunctions() As DataTable
        Get
            Try
                Dim o As Object = Session("DT_EST_QUOTE_FNC")
                If o Is Nothing Then
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Return est.GetEstimateQuoteDetails(Me.TxtEstimate.Text, Me.TxtEstimateComponent.Text, Me.TxtQuoteNum.Text, Me.RevNum, Me.ddPhase.SelectedValue)
                Else
                    Return CType(Session("DT_EST_QUOTE_FNC"), DataTable)
                End If
            Catch ex As Exception
            End Try
        End Get
        Set(ByVal value As DataTable)
            Session("DT_EST_QUOTE_FNC") = value
        End Set
    End Property

    Private Sub Page_Init2(sender As Object, e As System.EventArgs) Handles Me.Init

        HiddenFieldSecMod.Value = AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Security.Modules.ProjectManagement_Estimating)

        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()
        If IsNumeric(qs.GetValue("EstNum")) = True Then
            Me.EstNum = qs.GetValue("EstNum")
        End If
        If IsNumeric(qs.GetValue("EstComp")) = True Then
            Me.EstCompNum = qs.GetValue("EstComp")
        End If
        If IsNumeric(qs.GetValue("QuoteNum")) = True Then
            Me.QuoteNum = qs.GetValue("QuoteNum")
        End If
        If IsNumeric(qs.GetValue("RevNum")) = True Then
            Me.RevNum = qs.GetValue("RevNum")
        End If

        If est.GetEstimateQuoteInfo(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum).HasRows = False Then
            If qs.GetValue("bm") = "1" Then

                'Me.ShowMessage("Estimate is no longer available. Please delete your bookmark.")
                Me.CloseThisWindow()
                Me.Page.ClientScript.RegisterClientScriptBlock(Me.Page.GetType(), "close",
                                                               "ShowMessage('Quote is no longer available. Please delete your bookmark.');CloseThisWindow();", True)
                Exit Sub

            End If

        End If

        Me.txtBlendRate = CType(Me.RadToolbarEstimateGrid.FindItemByValue("RadToolBarButtonTxtBlendRate").FindControl("txtBlendRate"), TextBox)
        Me.ddPhase = CType(Me.RadToolbarEstimateGrid.FindItemByValue("RadToolBarButtonDdPhase").FindControl("ddPhase"), Telerik.Web.UI.RadComboBox)
        Me.DropSort = CType(Me.RadToolbarEstimateGrid.FindItemByValue("RadToolBarButtonDropSort").FindControl("DropSort"), Telerik.Web.UI.RadComboBox)
        Me.RadToolbarEstimateGrid.FindItemByValue("RadToolBarButtonFunctionsTooltip").Attributes.Add("id", "RadToolBarButtonFunctionsTooltip")
        Me.RadToolbarEstimateGrid.FindItemByValue("RadToolBarButtonPhaseTooltip").Attributes.Add("id", "RadToolBarButtonPhaseTooltip")

        Me.ButtonDeleteSelectedFunctions.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.PageTitle = "Estimate Quote"
        Try
            Dim estimate As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim oAppVars As New cAppVars(cAppVars.Application.ESTIMATE_QUOTE)
            Dim taskVar As String

            If IsNumeric(Me.TxtEstimate.Text) Then
                EstNum = CType(Me.TxtEstimate.Text, Integer)
            Else
                If IsNumeric(Me.CurrentQuerystring.GetValue("EstNum")) Then
                    EstNum = Me.CurrentQuerystring.GetValue("EstNum")
                    Me.TxtEstimate.Text = EstNum
                Else
                    Me.TxtEstimate.Text = ""
                End If
            End If
            If IsNumeric(Me.TxtEstimateComponent.Text) Then
                EstCompNum = CType(Me.TxtEstimateComponent.Text, Integer)
            Else
                If IsNumeric(Me.CurrentQuerystring.GetValue("EstComp")) Then
                    EstCompNum = Me.CurrentQuerystring.GetValue("EstComp")
                    Me.TxtEstimateComponent.Text = EstCompNum
                Else
                    Me.TxtEstimateComponent.Text = ""
                End If
            End If
            If IsNumeric(Me.TxtQuoteNum.Text) Then
                QuoteNum = CType(Me.TxtQuoteNum.Text, Integer)
            Else
                If IsNumeric(Me.CurrentQuerystring.GetValue("QuoteNum")) Then
                    QuoteNum = Me.CurrentQuerystring.GetValue("QuoteNum")
                    Me.TxtQuoteNum.Text = QuoteNum
                Else
                    Me.TxtQuoteNum.Text = ""
                End If
            End If
            If IsNumeric(Me.ddRevision.SelectedValue) Then
                RevNum = Me.ddRevision.SelectedValue
            Else
                If Session("EstimateSetupRev") IsNot Nothing Then
                    Me.ddRevision.SelectedValue = Session("EstimateSetupRev")
                    Me.hfRev.Value = Session("EstimateSetupRev")
                    Session("EstimateSetupRev") = Nothing
                ElseIf IsNumeric(Me.CurrentQuerystring.GetValue("RevNum")) Then
                    RevNum = Me.CurrentQuerystring.GetValue("RevNum")
                    Me.ddRevision.SelectedValue = RevNum
                    Me.hfRev.Value = RevNum
                Else
                    'Me.TxtQuoteNum.Text = ""
                End If
            End If
            If Session("EstimateQuoteSetPhase") = 1 Then
                Me.LoadPhaseList()
                Session("EstimateQuoteSetPhase") = 0
            End If
            If IsNumeric(Me.CurrentQuerystring.GetValue("j")) Then
                JobNum = Me.CurrentQuerystring.GetValue("j")
            End If
            If IsNumeric(Me.CurrentQuerystring.GetValue("jc")) Then
                JobCompNum = Me.CurrentQuerystring.GetValue("jc")
            End If
            If Me.JobNum > 0 AndAlso Me.JobCompNum > 0 Then

                Me.MyUnityContextMenu.JobNumber = Me.JobNum
                Me.MyUnityContextMenu.JobComponentNumber = Me.JobCompNum

            End If

            If IsNumeric(Me.CurrentQuerystring.GetValue("cmpid")) Then
                CampaignID = Me.CurrentQuerystring.GetValue("cmpid")
                If CampaignID > 0 Then
                    approvalType = "CMP"
                End If
            End If

            If Me.EstNum > 0 And Me.EstCompNum > 0 Then
                Me.HeaderDatakey = Me.EstNum.ToString() & "|" & Me.EstCompNum.ToString()
            End If

            If Not Page.IsPostBack Then
                HttpContext.Current.Session("EstimateRateValid") = Nothing
                HttpContext.Current.Session("EstimateQtyValid") = Nothing
                HttpContext.Current.Session("EstimateMarkupPercentValid") = Nothing
                HttpContext.Current.Session("EstimateContingencyPercentValid") = Nothing
                HttpContext.Current.Session("EstimateExtendedValid") = Nothing
                HttpContext.Current.Session("EstimateMarkupAmountValid") = Nothing
                'Me.RadToolbarEstimatingQuote.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks
                loadRevisions()
                LoadLookups()
                LoadPhaseList()
                LoadQuoteHeader()
                SetEstimateGridColumns()
                If estimate.GetEstBillRateFlag(Me.hfClientCode.Value, Me.hfDivisionCode.Value, Me.hfProductCode.Value) = 0 Then
                    Me.RadToolbarEstimateGrid.FindItemByValue("RadToolBarButtonLblBlendRate").Visible = False
                    Me.RadToolbarEstimateGrid.FindItemByValue("RadToolBarButtonTxtBlendRate").Visible = False
                End If

                taskVar = oAppVars.getAppVar("QvAExcludeCA")

                If taskVar <> "" Then
                    Me.SetGridSort(taskVar)
                    Try
                        MiscFN.RadComboBoxSetIndex(Me.DropSort, taskVar, False)
                    Catch ex As Exception
                    End Try
                Else
                    SetGridSort(Me.DropSort.SelectedValue)
                End If

                Me.CollapsablePanelComments.Collapsed = True
            Else
                Select Case Me.EventArgument.ToString().Replace("onclick#", "")
                    Case "Refresh"
                        'MiscFN.RadWindowsClose(Me.RadWindowManager)
                        Me.lblMSG.Text = ""
                        Session("DT_EST_QUOTE_FNC") = Nothing
                        Me.SetEstimateGridColumns()
                        Me.LoadQuoteHeader()
                        Me.CheckApproval()
                        Me.RadGridEstimateQuoteDetails.Rebind()
                    Case "HidePopups"
                        'Me.RadWindowManager.Windows(0).VisibleOnPageLoad = False
                        Me.RadGridEstimateQuoteDetails.Rebind()
                        Me.LoadQuoteHeader()
                    Case "Cancel"
                        Session("NewJSNew") = 0
                        Dim cScript As String
                        cScript = "<script language='javascript'> window.opener.location=window.opener.location; </script>"
                        RegisterStartupScript("parentwindow2", cScript)
                        Dim sbScript As System.Text.StringBuilder = New System.Text.StringBuilder
                        With sbScript
                            .Append("<script type=""text/javascript"">")
                            .Append("window.close();</script>")
                        End With
                        Try
                            If Not Page.IsStartupScriptRegistered("JS") Then
                                Dim str As String = sbScript.ToString
                                Page.RegisterStartupScript("JS", str)
                            End If
                        Catch ex As Exception
                            Me.ShowMessage("Error! " & ex.Message.ToString())
                        End Try
                End Select
            End If
            If Not IsPostBack And Not IsCallback Then

                Dim v As New cValidations(Session("ConnString"))
                Dim t As New cTimeSheet(Session("ConnString"))
                Dim c, d, p, s As String

                c = Me.hfClientCode.Value.Trim()
                d = Me.hfDivisionCode.Value.Trim()
                p = Me.hfProductCode.Value.Trim()

                If JobNum > 0 And JobCompNum > 0 Then

                    t.GetJobComponentInfo(JobNum, JobCompNum, , , , c, d, p)

                End If

                If v.ValidateCDPIsViewable(c, d, p, 0, 0, s) = False Then

                    If s.Trim() <> "" Then

                        Me.ShowMessage(s)
                        Me.CloseThisWindow()
                        Exit Sub

                    End If

                End If

            End If
            'Me.LoadQuoteHeader()
            Me.CheckApproval()
            Me.CheckApprovalInternal()
            ' Me.CheckForNewRow()
            Me.ToggleTBonApproval()
            Me.CheckUserRights()
            'CheckRevApprovals()

            If Me.IsClientPortal = True Then

                Me.RadToolbarEstimatingQuote.FindItemByValue("SendAssignment").Visible = False

            End If

            _CanUserInsertPO = AdvantageFramework.Security.CanUserAddInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)

            If (_CanUserInsertPO = False) Or (hlApproved.Visible = False And hlApprovedInternal.Visible = False) Then
                Me.RadToolbarEstimateGrid.Items.FindItemByValue("CreatePO").Enabled = False
            Else
                Me.RadToolbarEstimateGrid.Items.FindItemByValue("CreatePO").Enabled = True
            End If

        Catch ex As Exception
            'Me.ShowMessage("err pageload: " & ex.Message.ToString())
        End Try
    End Sub
    Private Sub Estimating_Quote_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        Try
            Select Case Me.EventArgument
                Case "Phase"

                    If Me.ReloadMe = True Then

                        Me.reloadForm()

                    End If

                Case "SaveAll"

                    If Me.ReloadMe = True Then

                        Me.reloadForm()

                    End If

            End Select

            Me.CheckForNewRow()

        Catch ex As Exception
        End Try

        Try

            Me.JavascriptArrayQuantityHours = ""
            Me.JavascriptArrayExtendedAmount = ""
            Me.JavascriptArrayMarkupAmount = ""
            Me.JavascriptArrayFunctionTotal = ""
            Me.JavascriptArrayGrossIncome = ""
            Me.JavascriptArrayContingencyAmount = ""
            Me.JavascriptArrayTotalWithContingencyAmount = ""
            Dim tb As System.Web.UI.WebControls.TextBox = Nothing

            For i As Integer = 0 To Me.RadGridEstimateQuoteDetails.MasterTableView.Items.Count - 1

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridEstimateQuoteDetails.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)

                If Not CurrentGridRow Is Nothing Then

                    Try
                        tb = CType(CurrentGridRow.FindControl("TxtEST_REV_QUANTITY"), TextBox)
                        If Not tb Is Nothing Then

                            JavascriptArrayQuantityHours &= "try { JavascriptArrayQuantityHours[" & i.ToString() & "] = document.getElementById('" & tb.ClientID & "').value; }catch(err){}" & Environment.NewLine

                        End If
                        tb = Nothing
                    Catch ex As Exception
                    End Try
                    Try
                        tb = CType(CurrentGridRow.FindControl("TxtEST_REV_EXT_AMT"), TextBox)
                        If Not tb Is Nothing Then

                            JavascriptArrayExtendedAmount &= "try { JavascriptArrayExtendedAmount[" & i.ToString() & "] = document.getElementById('" & tb.ClientID & "').value; }catch(err){}" & Environment.NewLine

                        End If
                        tb = Nothing
                    Catch ex As Exception
                    End Try
                    Try
                        tb = CType(CurrentGridRow.FindControl("TxtMARKUP_AMT"), TextBox)
                        If Not tb Is Nothing Then

                            JavascriptArrayMarkupAmount &= "try { JavascriptArrayMarkupAmount[" & i.ToString() & "] = document.getElementById('" & tb.ClientID & "').value; }catch(err){}" & Environment.NewLine

                        End If
                        tb = Nothing
                    Catch ex As Exception
                    End Try
                    Try
                        tb = CType(CurrentGridRow.FindControl("TxtLINE_TOTAL"), TextBox)
                        If Not tb Is Nothing Then

                            JavascriptArrayFunctionTotal &= "try { JavascriptArrayFunctionTotal[" & i.ToString() & "] = document.getElementById('" & tb.ClientID & "').value; }catch(err){}" & Environment.NewLine

                        End If
                        tb = Nothing
                    Catch ex As Exception
                    End Try
                    Try
                        tb = CType(CurrentGridRow.FindControl("TxtGrossIncome"), TextBox)
                        If Not tb Is Nothing Then

                            JavascriptArrayGrossIncome &= "try { JavascriptArrayGrossIncome[" & i.ToString() & "] = document.getElementById('" & tb.ClientID & "').value; }catch(err){}" & Environment.NewLine

                        End If
                        tb = Nothing
                    Catch ex As Exception
                    End Try
                    Try
                        tb = CType(CurrentGridRow.FindControl("TxtEXT_CONTINGENCY"), TextBox)
                        If Not tb Is Nothing Then

                            JavascriptArrayContingencyAmount &= "try { JavascriptArrayContingencyAmount[" & i.ToString() & "] = document.getElementById('" & tb.ClientID & "').value; }catch(err){}" & Environment.NewLine

                        End If
                        tb = Nothing
                    Catch ex As Exception
                    End Try
                    Try
                        tb = CType(CurrentGridRow.FindControl("TxtQUOTE_W_CONTINGENCY"), TextBox)
                        If Not tb Is Nothing Then

                            JavascriptArrayTotalWithContingencyAmount &= "try { JavascriptArrayTotalWithContingencyAmount[" & i.ToString() & "] = document.getElementById('" & tb.ClientID & "').value; }catch(err){}" & Environment.NewLine

                        End If
                        tb = Nothing
                    Catch ex As Exception
                    End Try

                End If

            Next

        Catch ex As Exception

        End Try

        Dim Deep As New AdvantageFramework.Web.DeepLink(Me._Session)
        Deep.BuildJavascriptFromQueryString(Me.CurrentQuerystring, WebvantageLink, ClientPortalLink)
        Me.RadToolbarEstimatingQuote.FindItemByValue("CpPermaLink").Visible = Deep.ClientPortalVisible
        If Me.IsClientPortal = True Then

            Me.RadToolbarEstimatingQuote.FindItemByValue("WvPermaLink").Visible = False
            Me.RadToolbarEstimatingQuote.FindItemByValue("CpPermaLink").Visible = False

        End If

        If Me.CurrentQuerystring.GetValue("bm") <> "1" Then
            Me.Page.Title = "E " & Me.EstNum.ToString.PadLeft(6, "0") & "-" & Me.EstCompNum.ToString.PadLeft(2, "0") & "-" & Me.QuoteNum.ToString.PadLeft(2, "0") & " - " & Me.TxtQuoteDescription.Text
        End If


    End Sub


#Region " Controls: "

    Private Sub hlApproved_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles hlApproved.Click
        Try
            Me.LoadQuoteHeader()
            Dim StrURL As String = "Estimating_Approval.aspx?appr=1&EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&edit=1" & "&CampaignID=" & Me.CampaignID
            Me.OpenWindow("Client Approval", StrURL, 300, 450, False, True, "RefreshPage")
            'With Me.RadWindowManager.Windows(0)
            '    .NavigateUrl = "Estimating_Approval.aspx?appr=1&EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&edit=1"
            '    .Title = "Client Approval"
            '    .Modal = True
            '    .Height = New Unit(300, UnitType.Pixel)
            '    .Width = New Unit(450, UnitType.Pixel)
            '    .InitialBehavior = Telerik.Web.UI.WindowBehaviors.None
            '    .ReloadOnShow = True
            '    .Behavior = Telerik.Web.UI.WindowBehaviors.None

            '    .VisibleOnPageLoad = True
            '    .VisibleStatusbar = False
            'End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub hlApprovedInternal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles hlApprovedInternal.Click
        Try
            Me.LoadQuoteHeader()
            Dim StrURL As String = "Estimating_Approval.aspx?appr=2&EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&edit=1" & "&CampaignID=" & Me.CampaignID
            Me.OpenWindow("Internal Approval", StrURL, 300, 450, False, True, "RefreshPage")
            'With Me.RadWindowManager.Windows(0)
            '    .NavigateUrl = "Estimating_Approval.aspx?appr=2&EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&edit=1"
            '    .Title = "Internal Approval"
            '    .Modal = True
            '    .Height = New Unit(300, UnitType.Pixel)
            '    .Width = New Unit(450, UnitType.Pixel)
            '    .InitialBehavior = Telerik.Web.UI.WindowBehaviors.None
            '    .ReloadOnShow = True
            '    .Behavior = Telerik.Web.UI.WindowBehaviors.None

            '    .VisibleOnPageLoad = True
            '    .VisibleStatusbar = False
            'End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HlVersion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles HlVersion.Click
        Try
            Me.LoadQuoteHeader()
            Dim StrURL As String = "Estimating_JobSpecs.aspx?EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&edit=1"
            Me.OpenWindow("Associate Estimate with Spec Version/Revision", StrURL, 300, 450, False, True, "RefreshPage")
            'With Me.RadWindowManager.Windows(0)
            '    .NavigateUrl = "Estimating_JobSpecs.aspx?EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&edit=1"
            '    .Title = "Associate Estimate with Spec Version/Revision"
            '    .Modal = True
            '    .Height = New Unit(300, UnitType.Pixel)
            '    .Width = New Unit(450, UnitType.Pixel)
            '    .InitialBehavior = Telerik.Web.UI.WindowBehaviors.None
            '    .ReloadOnShow = True
            '    .Behavior = Telerik.Web.UI.WindowBehaviors.None

            '    .VisibleOnPageLoad = True
            '    .VisibleStatusbar = False
            'End With
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ddRevision_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddRevision.SelectedIndexChanged
        Try
            Me.RevNum = Me.ddRevision.SelectedValue
            Me.LoadQuoteHeader()
            Me.CheckApproval()
            LoadLookups()
            Me.RadGridEstimateQuoteDetails.Rebind()
            'CheckRevApprovals()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropSort_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropSort.SelectedIndexChanged
        Try
            SaveSort()
            SetGridSort(Me.DropSort.SelectedValue)
            Me.RadGridEstimateQuoteDetails.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ddPhase_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddPhase.SelectedIndexChanged
        Try
            Me.RadGridEstimateQuoteDetails.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtQuoteNum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtQuoteNum.TextChanged
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Me.hfRev.Value = est.GetEstimateQuoteMaxRevision(Me.EstNum, Me.EstCompNum, Me.QuoteNum)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LbQuote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbQuote.Click
        Try
            If Me.CurrentQuerystring.IsJobDashboard = True Then
                Dim qs As New AdvantageFramework.Web.QueryString

                qs.JobNumber = JobNum
                qs.JobComponentNumber = JobCompNum
                qs.EstimateNumber = Me.TxtEstimate.Text
                qs.EstimateComponentNumber = Me.TxtEstimateComponent.Text
                qs.IsJobDashboard = True

                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates

                qs.Page = "Context.aspx"

                Me.CloseThisWindowAndRefreshCaller(qs.ToString, True, False)

            Else
                Me.OpenWindow("Estimating", "Estimating.aspx?EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&newEst=edit")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub imgbtnSpecsQuote_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnSpecsQuote.Click
        Try
            If Me.TxtJobNum.Text = "" Then
                Me.ShowMessage("There are no specs associated with this quote.")
                Exit Sub
            End If
            Me.SaveGrid()
            'Me.SaveQuoteHeader()
            Me.SaveSort()
            Dim strUrlSpecs As String
            strUrlSpecs = "Estimating_ImportSpecs.aspx?EstNum=" & EstNum & "&EstComp=" & EstCompNum & "&QuoteNum=" & QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&SeqNum=&JobNum=" & Me.JobNum & "&JobComp=" & Me.JobCompNum & "&SpecVer=" & Me.TxtVersion.Text & "&SpecRev=" & Me.TxtRevision.Text & "&control=" & Me.RadEditorQuoteComment.ClientID
            Me.OpenWindow("Estimating Import Specs", strUrlSpecs, 500, 700, False, True, "RefreshPage")
            'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "ImportSpecsWindow", "", strUrlSpecs, 500, 700, True)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub imgbtnSpecsRev_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnSpecsRev.Click
        Try
            If Me.TxtJobNum.Text = "" Then
                Me.ShowMessage("There are no specs associated with this quote.")
                Exit Sub
            End If
            Me.SaveGrid()
            'Me.SaveQuoteHeader()
            Me.SaveSort()
            Dim strUrlSpecs As String
            strUrlSpecs = "Estimating_ImportSpecs.aspx?EstNum=" & EstNum & "&EstComp=" & EstCompNum & "&QuoteNum=" & QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&SeqNum=&JobNum=" & Me.JobNum & "&JobComp=" & Me.JobCompNum & "&SpecVer=" & Me.TxtVersion.Text & "&SpecRev=" & Me.TxtRevision.Text & "&control=" & Me.RadEditorRevisionComment.ClientID
            Me.OpenWindow("Estimating Import Specs", strUrlSpecs, 500, 700, False, True, "RefreshPage")
            'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "ImportSpecsWindow", "", strUrlSpecs, 500, 700, True)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub ButtonAddFunctionsFromListOfFunctions_Click(sender As Object, e As EventArgs) Handles ButtonAddFunctionsFromListOfFunctions.Click

        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        QueryString = New AdvantageFramework.Web.QueryString

        Dim appr As Integer = 0
        If hlApproved.Visible = True Or hlApprovedInternal.Visible = True Then
            appr = 1
        End If

        With QueryString

            .Page = "Estimating_AddRow.aspx"
            .EstimateNumber = EstNum
            .EstimateComponentNumber = EstCompNum
            .EstimateQuoteNumber = QuoteNum
            .EstimateRevisionNumber = Me.ddRevision.SelectedValue
            .ClientCode = Me.hfClientCode.Value
            .DivisionCode = Me.hfDivisionCode.Value
            .ProductCode = Me.hfProductCode.Value
            .SalesClassCode = Me.hfSalesClass.Value
            If Me.TxtJobNum.Text = "" Then
                .JobNumber = 0
            Else
                .JobNumber = Me.TxtJobNum.Text
            End If
            If Me.TxtJobCompNum.Text = "" Then
                .JobComponentNumber = 0
            Else
                .JobComponentNumber = Me.TxtJobCompNum.Text
            End If
            .Add("appr", appr)

        End With

        Me.OpenWindow("Add New Rows", QueryString.ToString(True), 550, 900, False, True, "RefreshPage")
    End Sub
    Private Sub ButtonAddFunctionsFromFunctionTemplates_Click(sender As Object, e As EventArgs) Handles ButtonAddFunctionsFromFunctionTemplates.Click

        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        QueryString = New AdvantageFramework.Web.QueryString

        Dim appr As Integer = 0
        If hlApproved.Visible = True Or hlApprovedInternal.Visible = True Then
            appr = 1
        End If

        With QueryString

            .Page = "Estimating_QuickAdd.aspx"
            .EstimateNumber = EstNum
            .EstimateComponentNumber = EstCompNum
            .EstimateQuoteNumber = QuoteNum
            .EstimateRevisionNumber = Me.ddRevision.SelectedValue
            .ClientCode = Me.hfClientCode.Value
            .DivisionCode = Me.hfDivisionCode.Value
            .ProductCode = Me.hfProductCode.Value
            .SalesClassCode = Me.hfSalesClass.Value
            If Me.TxtJobNum.Text = "" Then
                .JobNumber = 0
            Else
                .JobNumber = Me.TxtJobNum.Text
            End If
            If Me.TxtJobNum.Text = "" Then
                .JobComponentNumber = 0
            Else
                .JobComponentNumber = Me.TxtJobCompNum.Text
            End If
            .Add("appr", appr)

        End With

        Me.OpenWindow("Template Options", QueryString.ToString(True), 550, 725, False, True, "RefreshPage")
    End Sub
    Private Sub ButtonAddFunctionsCopyFromExistingQuote_Click(sender As Object, e As EventArgs) Handles ButtonAddFunctionsCopyFromExistingQuote.Click

        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        QueryString = New AdvantageFramework.Web.QueryString

        Dim appr As Integer = 0
        If hlApproved.Visible = True Or hlApprovedInternal.Visible = True Then
            appr = 1
        End If

        With QueryString

            .Page = "Estimating_CopyFrom.aspx"
            .EstimateNumber = EstNum
            .EstimateComponentNumber = EstCompNum
            .EstimateQuoteNumber = QuoteNum
            .EstimateRevisionNumber = Me.ddRevision.SelectedValue
            .ClientCode = Me.hfClientCode.Value
            .DivisionCode = Me.hfDivisionCode.Value
            .ProductCode = Me.hfProductCode.Value
            .SalesClassCode = Me.hfSalesClass.Value
            If Me.TxtJobNum.Text = "" Then
                .JobNumber = 0
            Else
                .JobNumber = Me.TxtJobNum.Text
            End If
            If Me.TxtJobNum.Text = "" Then
                .JobComponentNumber = 0
            Else
                .JobComponentNumber = Me.TxtJobCompNum.Text
            End If
            .Add("appr", appr)

        End With

        Me.OpenWindow("Copy From Quote", QueryString.ToString(True), 590, 980, False, True, "RefreshPage")
    End Sub
    Private Sub ButtonAddFunctionsCreateFromSchedule_Click(sender As Object, e As EventArgs) Handles ButtonAddFunctionsCreateFromSchedule.Click

        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        QueryString = New AdvantageFramework.Web.QueryString

        Dim appr As Integer = 0
        If hlApproved.Visible = True Or hlApprovedInternal.Visible = True Then
            appr = 1
        End If

        With QueryString

            .Page = "Estimating_QuoteFromPS.aspx"
            .EstimateNumber = EstNum
            .EstimateComponentNumber = EstCompNum
            .EstimateQuoteNumber = QuoteNum
            .EstimateRevisionNumber = Me.ddRevision.SelectedValue
            .ClientCode = Me.hfClientCode.Value
            .DivisionCode = Me.hfDivisionCode.Value
            .ProductCode = Me.hfProductCode.Value
            .SalesClassCode = Me.hfSalesClass.Value
            If Me.TxtJobNum.Text = "" Then
                .JobNumber = 0
            Else
                .JobNumber = Me.TxtJobNum.Text
            End If
            If Me.TxtJobNum.Text = "" Then
                .JobComponentNumber = 0
            Else
                .JobComponentNumber = Me.TxtJobCompNum.Text
            End If
            .Add("appr", appr)

        End With

        Me.OpenWindow("Create Quote From Schedule", QueryString.ToString(True), 400, 1000, False, True, "RefreshPage")
    End Sub
    Private Sub ButtonAddFunctionsCreateFromJobHistory_Click(sender As Object, e As EventArgs) Handles ButtonAddFunctionsCreateFromJobHistory.Click
        Try
            Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

            QueryString = New AdvantageFramework.Web.QueryString

            Dim appr As Integer = 0
            If hlApproved.Visible = True Or hlApprovedInternal.Visible = True Then
                appr = 1
            End If

            With QueryString

                .Page = "Estimating_JobHistory.aspx"
                .EstimateNumber = EstNum
                .EstimateComponentNumber = EstCompNum
                .EstimateQuoteNumber = QuoteNum
                .EstimateRevisionNumber = Me.ddRevision.SelectedValue
                .Add("appr", appr)

            End With

            Me.OpenWindow("Review Job History", QueryString.ToString(True), 700, 1200, False, True, "RefreshPage")

        Catch ex As Exception
        End Try
    End Sub
    Private Sub ButtonDeleteSelectedFunctions_Click(sender As Object, e As EventArgs) Handles ButtonDeleteSelectedFunctions.Click
        Dim chk As CheckBox
        Dim DelString As String = ""
        Dim count As Integer = 0
        Dim dtKey As String
        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstimateQuoteDetails.MasterTableView.Items
            ' chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
            If gridDataItem.Selected Then
                Dim d As String = gridDataItem.GetDataKeyValue("INDEX")
                If IsNumeric(gridDataItem.GetDataKeyValue("SEQ_NBR")) Then
                    If gridDataItem.GetDataKeyValue("SEQ_NBR") = "-1" Then
                        dtKey &= gridDataItem.GetDataKeyValue("INDEX") & ","
                    Else
                        DelString &= gridDataItem.GetDataKeyValue("SEQ_NBR") & ","
                    End If
                End If
                count += 1
            End If
        Next
        If count = 0 Then
            Me.ShowMessage("No rows were selected for deletion.")
        End If
        DelString = MiscFN.RemoveTrailingDelimiter(DelString, ",")
        dtKey = MiscFN.RemoveTrailingDelimiter(dtKey, ",")
        If dtKey <> "" Then
            Dim seq() As String = dtKey.Split(",")
            Dim i As Integer
            For i = seq.Length - 1 To 0 Step -1
                Me.DtQuoteFunctions.Rows.RemoveAt(seq(i) - 1)
            Next
        End If
        Dim DelSQL As String = ""
        If EstNum > 0 And EstCompNum > 0 And DelString.Length > 0 Then
            DelSQL = "DELETE FROM ESTIMATE_REV_DET WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstCompNum & " AND EST_QUOTE_NBR = " & QuoteNum & " AND EST_REV_NBR = " & Me.ddRevision.SelectedValue & " AND SEQ_NBR IN (" & DelString & ")"
            Using MyConn As New SqlConnection(Session("ConnString"))
                MyConn.Open()
                Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                Dim MyCmd As New SqlCommand(DelSQL, MyConn, MyTrans)
                Try
                    MyCmd.ExecuteNonQuery()
                    MyTrans.Commit()
                Catch ex As Exception
                    MyTrans.Rollback()
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try
            End Using
        End If
        Session("DT_EST_QUOTE_FNC") = Nothing
        Me.RadGridEstimateQuoteDetails.Rebind()
    End Sub
    Private Sub ButtonQuotefromCampaign_Click(sender As Object, e As EventArgs) Handles ButtonQuotefromCampaign.Click
        Try
            'SaveAlmostEverything()    
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim jc As AdvantageFramework.Database.Entities.Job = Nothing
            Dim jcmaster As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim estimate As String()
            Dim estimatemaster As String()
            Dim EstApproval As Generic.List(Of AdvantageFramework.Database.Views.EstimateApproval) = Nothing
            Dim hasFunction As Boolean = False
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                If Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "" Then
                    jc = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, CInt(Me.TxtJobNum.Text))
                    If jc.CampaignID Is Nothing Then
                        Me.ShowMessage("There is no matching campaign.  The rates will not be updated.")
                        Exit Sub
                    End If
                End If
                If jc IsNot Nothing Then
                    campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, jc.CampaignID)
                    If campaign.JobNumber Is Nothing Then
                        Me.ShowMessage("There were no matching functions to update.")
                        Exit Sub
                    Else
                        jcmaster = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, campaign.JobNumber, campaign.JobComponentNumber)
                        If jcmaster.EstimateNumber Is Nothing Then
                            Exit Sub
                            Me.ShowMessage("There were no matching functions to update.")
                        Else
                            EstApproval = AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(DbContext).ToList.Where(Function(EstimateApproval) EstimateApproval.EstimateNumber = jcmaster.EstimateNumber And EstimateApproval.EstimateComponentNumber = jcmaster.EstimateComponentNumber).ToList
                            If EstApproval.Count = 0 Then
                                Me.ShowMessage("There were no matching functions to update.")
                                Exit Sub
                            Else
                                For Each EstimateApproval In EstApproval
                                    estimatemaster = (From Approval In AdvantageFramework.Database.Procedures.EstimateRevisionDetail.Load(DbContext)
                                                      Where Approval.EstimateNumber = EstimateApproval.EstimateNumber _
                                                            And Approval.EstimateComponentNumber = EstimateApproval.EstimateComponentNumber _
                                                            And Approval.EstimateQuoteNumber = EstimateApproval.EstimateQuoteNumber _
                                                            And Approval.EstimateRevisionNumber = EstimateApproval.EstimateRevisionNumber
                                                      Select Approval.FunctionCode).ToArray
                                    estimate = (From Approval In AdvantageFramework.Database.Procedures.EstimateRevisionDetail.Load(DbContext)
                                                Where Approval.EstimateNumber = EstNum _
                                                      And Approval.EstimateComponentNumber = EstCompNum _
                                                      And Approval.EstimateQuoteNumber = QuoteNum _
                                                     And Approval.EstimateRevisionNumber = ddRevision.SelectedValue
                                                Select Approval.FunctionCode).ToArray
                                Next
                                For i As Integer = 0 To estimatemaster.Count - 1
                                    For j As Integer = 0 To estimate.Count - 1
                                        If estimatemaster(i) = estimate(j) Then
                                            hasFunction = True
                                        End If
                                    Next
                                Next
                                If hasFunction = False Then
                                    Me.ShowMessage("There were no matching functions to update.")
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If

                End If
            End Using


            If EstNum > 0 And EstCompNum > 0 Then
                Dim update As Boolean = False
                update = est.UpdateQuoteFromCampaign(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, Me.TxtJobNum.Text, Me.TxtJobCompNum.Text)
                Me.RadGridEstimateQuoteDetails.Rebind()
                If update = True Then
                    Me.ShowMessage("All matching functions were updated.")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            If EstNum > 0 And EstCompNum > 0 Then

                Dim check As Integer = 0
                check = est.CheckQuotesApprovals(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, Me.TxtJobNum.Text, Me.TxtJobCompNum.Text, "Quote")
                If check = 0 Then
                    Me.ShowMessage("There is no existing quote to add from.  Process cancelled.")
                    Exit Sub
                End If

                check = est.CheckQuotesApprovals(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, Me.TxtJobNum.Text, Me.TxtJobCompNum.Text, "Approvals")
                If check = 0 Then
                    Me.ShowMessage("There are no internally or client approved quotes available.  Nothing to update")
                    Exit Sub
                End If

                Dim update As Boolean = False
                update = est.UpdateMasterEstimateFromQuotes(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, Me.TxtJobNum.Text, Me.TxtJobCompNum.Text, "Add")
                If update = True Then
                    Me.RadGridEstimateQuoteDetails.Rebind()
                    Me.ShowMessage("Quote updated.")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ButtonSubtract_Click(sender As Object, e As EventArgs) Handles ButtonSubtract.Click
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            If EstNum > 0 And EstCompNum > 0 Then

                Dim check As Integer = 0
                check = est.CheckQuotesApprovals(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, Me.TxtJobNum.Text, Me.TxtJobCompNum.Text, "Quote")
                If check = 0 Then
                    Me.ShowMessage("There is no existing quote to subtract from.  Process cancelled.")
                    Exit Sub
                End If

                check = est.CheckQuotesApprovals(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, Me.TxtJobNum.Text, Me.TxtJobCompNum.Text, "Approvals")
                If check = 0 Then
                    Me.ShowMessage("There are no internally or client approved quotes available.  Nothing to update")
                    Exit Sub
                End If

                Dim update As Boolean = False
                update = est.UpdateMasterEstimateFromQuotes(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, Me.TxtJobNum.Text, Me.TxtJobCompNum.Text, "Subtract")
                If update = True Then
                    Me.RadGridEstimateQuoteDetails.Rebind()
                    Me.ShowMessage("Quote updated.")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ButtonPhaseSetPhase_Click(sender As Object, e As EventArgs) Handles ButtonPhaseSetPhase.Click
        Dim chk As CheckBox
        Dim count As Integer = 0
        Dim UpdateString As String = ""
        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstimateQuoteDetails.MasterTableView.Items
            'chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
            If gridDataItem.Selected Then
                If IsNumeric(gridDataItem.GetDataKeyValue("SEQ_NBR")) Then
                    UpdateString &= gridDataItem.GetDataKeyValue("SEQ_NBR") & ","
                End If
                count += 1
            End If
        Next
        UpdateString = MiscFN.RemoveTrailingDelimiter(UpdateString, ",")
        If count = 0 Then
            Me.ShowMessage("No rows were selected for phase.")
            Exit Sub
        End If
        Dim StrURL As String = "Estimating_Phase.aspx?EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&uStr=" & UpdateString
        'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "PhaseWindow", "Phase", StrURL, 200, 400, True)
        Me.OpenWindow("Phase", StrURL, 200, 400, False, True, "RefreshPage")
    End Sub
    Private Sub ButtonPhaseClearPhase_Click(sender As Object, e As EventArgs) Handles ButtonPhaseClearPhase.Click
        Dim chk As CheckBox
        Dim UpdateString As String = ""
        Dim count As Integer = 0
        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstimateQuoteDetails.MasterTableView.Items
            'chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
            If gridDataItem.Selected Then
                If IsNumeric(gridDataItem.GetDataKeyValue("SEQ_NBR")) Then
                    UpdateString &= gridDataItem.GetDataKeyValue("SEQ_NBR") & ","
                End If
                count += 1
            End If
        Next
        If count = 0 Then
            Me.ShowMessage("No rows were selected for clearing phase.")
        End If
        UpdateString = MiscFN.RemoveTrailingDelimiter(UpdateString, ",")
        Dim UpdateSQL As String = ""
        If EstNum > 0 And EstCompNum > 0 And UpdateString.Length > 0 Then
            est.UpdateQuotePhase(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, UpdateString, -1, "")
            Me.RadGridEstimateQuoteDetails.Rebind()
            LoadPhaseList()
        End If
    End Sub

    Protected Sub RadContextMenuGridItem_ItemClick(sender As Object, e As Telerik.Web.UI.RadMenuEventArgs)

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim FunctionCode As String = Nothing
        Dim WindowURL As String = Nothing
        Dim SequenceNumber As Short = Nothing
        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim DelSQL As String = ""

        GridDataItem = RadGridEstimateQuoteDetails.Items.OfType(Of Telerik.Web.UI.GridDataItem).Where(Function(i) i.ItemIndexHierarchical = HiddenFieldSelectedRow.Value).FirstOrDefault

        'Me.CurrentGridPageIndex = RadGridProjectSchedule.CurrentPageIndex

        If GridDataItem IsNot Nothing Then

            SequenceNumber = CShort(GridDataItem.GetDataKeyValue("SEQ_NBR"))

            Select Case e.Item.Value
                Case "DeleteTask"

                    If Me.RadGridEstimateQuoteDetails.MasterTableView.GetSelectedItems.Length > 1 Then

                        For Each gridItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstimateQuoteDetails.MasterTableView.Items
                            If gridItem.Selected = True Then
                                SequenceNumber = CShort(gridItem.GetDataKeyValue("SEQ_NBR"))
                                DelSQL = "DELETE FROM ESTIMATE_REV_DET WHERE ESTIMATE_NUMBER = " & EstNum & " And EST_COMPONENT_NBR = " & EstCompNum & " And EST_QUOTE_NBR = " & QuoteNum & " And EST_REV_NBR = " & Me.ddRevision.SelectedValue & " And SEQ_NBR In (" & SequenceNumber & ")"
                                Using MyConn As New SqlConnection(Session("ConnString"))
                                    MyConn.Open()
                                    Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                                    Dim MyCmd As New SqlCommand(DelSQL, MyConn, MyTrans)
                                    Try
                                        MyCmd.ExecuteNonQuery()
                                        MyTrans.Commit()
                                    Catch ex As Exception
                                        MyTrans.Rollback()
                                    Finally
                                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                                    End Try
                                End Using
                                DelSQL = ""
                            End If
                        Next

                    Else

                        If EstNum > 0 And EstCompNum > 0 Then
                            DelSQL = "DELETE FROM ESTIMATE_REV_DET WHERE ESTIMATE_NUMBER = " & EstNum & " And EST_COMPONENT_NBR = " & EstCompNum & " And EST_QUOTE_NBR = " & QuoteNum & " And EST_REV_NBR = " & Me.ddRevision.SelectedValue & " And SEQ_NBR In (" & SequenceNumber & ")"
                            Using MyConn As New SqlConnection(Session("ConnString"))
                                MyConn.Open()
                                Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                                Dim MyCmd As New SqlCommand(DelSQL, MyConn, MyTrans)
                                Try
                                    MyCmd.ExecuteNonQuery()
                                    MyTrans.Commit()
                                Catch ex As Exception
                                    MyTrans.Rollback()
                                Finally
                                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                                End Try
                            End Using
                        End If
                    End If

                    Session("DT_EST_QUOTE_FNC") = Nothing
                    Me.RadGridEstimateQuoteDetails.Rebind()

                Case "CopyTask"

                    If Me.RadGridEstimateQuoteDetails.MasterTableView.GetSelectedItems.Length > 1 Then

                        For Each gridItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstimateQuoteDetails.MasterTableView.Items
                            If gridItem.Selected = True Then
                                SequenceNumber = CShort(gridItem.GetDataKeyValue("SEQ_NBR"))
                                est.GetEstimateQuoteFunctionCopy(EstNum, EstCompNum, QuoteNum, Me.ddRevision.SelectedValue, SequenceNumber)
                            End If
                        Next

                    Else

                        est.GetEstimateQuoteFunctionCopy(EstNum, EstCompNum, QuoteNum, Me.ddRevision.SelectedValue, SequenceNumber)

                    End If



                    Me.RadGridEstimateQuoteDetails.Rebind()


            End Select

        End If

    End Sub


#End Region

#Region " SubRoutines "

    Private Sub PageLoadJS(ByVal strJS As String)
        Dim strTmpJS As String = String.Empty
        strTmpJS = "<script type=""text/javascript"">function init() { " & strJS & " } window.onload = init;</script>"
        If Not Page.IsStartupScriptRegistered("JSPageLoad" & Now.Millisecond) Then
            Page.RegisterStartupScript("JSAlert", strTmpJS)
        End If
    End Sub

    Private Function GetEmailAddressFromGroup(ByVal strEmailGroup As String) As SqlDataReader
        Try
            Dim oSQL As SqlHelper
            Dim strReturn As String = String.Empty
            Dim dr As SqlDataReader
            If strEmailGroup <> "" Then
                Dim arParams(1) As SqlParameter
                Dim paramEmailGroup As New SqlParameter("@EmailGroup", SqlDbType.VarChar, 50)
                paramEmailGroup.Value = strEmailGroup
                arParams(0) = paramEmailGroup
                dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_GetEmailAddressFromGroup", arParams)
            End If
            Return dr
        Catch ex As Exception
        End Try
    End Function

    Private Function GetYesNo(ByVal ThisShort As Short) As String
        If ThisShort = 1 Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function

    Private Sub LoadLookups()

    End Sub

    Private Sub loadRevisions(Optional ByVal currentRevision As Integer = -1)
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim dr As SqlDataReader
            dr = est.GetEstimateQuoteRevisions(Me.TxtEstimate.Text, Me.TxtEstimateComponent.Text, Me.TxtQuoteNum.Text)
            With Me.ddRevision
                .DataSource = dr
                .DataTextField = "EST_REV_NBR_PAD"
                .DataValueField = "EST_REV_NBR"
                .DataBind()
            End With
            If currentRevision <> -1 Then
                Me.ddRevision.SelectedValue = currentRevision
                Me.hfRev.Value = currentRevision
            End If
            If Me.ddRevision.SelectedValue <> "" Then
                Me.RevNum = Me.ddRevision.SelectedValue
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Function LoadQuoteHeader() As Boolean
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim oAppVars As New cAppVars(cAppVars.Application.ESTIMATE_QUOTE)
            Dim taskVar As String
            Dim dr As SqlDataReader
            Dim max As Integer
            Dim sort As Integer
            dr = est.GetEstimateQuoteInfo(Me.TxtEstimate.Text, Me.TxtEstimateComponent.Text, Me.TxtQuoteNum.Text, Me.RevNum)
            If dr.HasRows = True Then
                Do While dr.Read
                    Me.TxtEstimate.Text = dr("ESTIMATE_NUMBER")
                    Me.TxtEstimateComponent.Text = dr("EST_COMPONENT_NBR")
                    Me.TxtQuoteNum.Text = dr("EST_QUOTE_NBR")
                    Me.ddRevision.SelectedValue = dr("EST_REV_NBR")
                    Me.hfRev.Value = dr("EST_REV_NBR")
                    Me.TxtEstimateDescription.Text = dr("EST_LOG_DESC")
                    Me.TxtEstimateComponentDescription.Text = dr("EST_COMP_DESC")
                    Me.TxtQuoteDescription.Text = dr("EST_QUOTE_DESC")
                    'Me.HiddenFieldCreateDate.Value = dr("EST_CREATE_DATE")

                    If dr("EST_QTE_COMMENT_HTML") <> "" Then
                        Me.RadEditorQuoteComment.Html = dr("EST_QTE_COMMENT_HTML")
                    Else
                        Me.RadEditorQuoteComment.Content = dr("EST_QTE_COMMENT").Replace(vbLf, "<br />").Replace(vbCrLf, "<br />")
                    End If

                    If dr("EST_REV_COMMENT_HTML") <> "" Then
                        Me.RadEditorRevisionComment.Html = dr("EST_REV_COMMENT_HTML")
                    Else
                        Me.RadEditorRevisionComment.Content = dr("EST_REV_COMMENT").Replace(vbLf, "<br />").Replace(vbCrLf, "<br />")
                    End If

                    Me.TxtVersion.Text = dr("SPEC_VER")
                    Me.TextBoxVersionDescription.Text = dr("SPEC_VER_DESC")
                    Me.TxtQty.Text = String.Format("{0:#,##0}", CDec(dr("JOB_QTY")))
                    Me.TxtRevision.Text = dr("SPEC_REV")

                    Me.hfClientCode.Value = dr("CL_CODE")
                    Me.hfDivisionCode.Value = dr("DIV_CODE")
                    Me.hfProductCode.Value = dr("PRD_CODE")

                    If IsDBNull(dr("CMP_IDENTIFIER")) = False Then
                        Me.CampaignID = dr("CMP_IDENTIFIER")
                        Me.hfCampaignID.Value = dr("CMP_IDENTIFIER")
                        If hfCampaignID.Value <> "" And hfCampaignID.Value <> "0" Then
                            approvalType = "CMP"
                        End If
                    End If

                    Me.hfSalesClass.Value = dr("SC_CODE")
                    If IsDBNull(dr("JOB_NUMBER")) = True Then
                        Me.HlVersion.Enabled = False
                        Me.TxtVersion.Enabled = False
                        Me.TxtRevision.Enabled = False
                        Me.TxtRevision.Text = "0"
                    ElseIf dr("JOB_NUMBER") = 0 Then
                        Me.HlVersion.Enabled = False
                        Me.TxtVersion.Enabled = False
                        Me.TxtRevision.Enabled = False
                        Me.TxtRevision.Text = "0"
                    Else
                        Me.JobNum = dr("JOB_NUMBER")
                        Me.TxtJobNum.Text = dr("JOB_NUMBER")
                        Me.TxtJobDescription.Text = dr("JOB_DESC")
                    End If
                    If IsDBNull(dr("JOB_COMPONENT_NBR")) = False Then
                        If dr("JOB_COMPONENT_NBR") <> 0 Then
                            Me.JobCompNum = dr("JOB_COMPONENT_NBR")
                            Me.TxtJobCompNum.Text = dr("JOB_COMPONENT_NBR")
                            Me.TxtJobCompDescription.Text = dr("JOB_COMP_DESC")
                        End If
                    End If

                    If IsDBNull(dr("JOB_COMP_BUDGET_AM")) = False Then
                        Me.lblJobBudgetAmount.Text = String.Format("{0:#,##0.00}", dr("JOB_COMP_BUDGET_AM"))
                    End If

                    taskVar = oAppVars.getAppVar("QvAExcludeCA")

                    If taskVar = "" Then
                        sort = dr("FNC_SORT_ORDER")
                        If sort = 1 Then
                            Me.DropSort.SelectedValue = "funccode"
                            ' Session("EstimateGridSort") = "funccode"
                        ElseIf sort = 2 Then
                            Me.DropSort.SelectedValue = "functype"
                            ' Session("EstimateGridSort") = "functype"
                        ElseIf sort = 3 Then
                            Me.DropSort.SelectedValue = "conscode"
                            ' Session("EstimateGridSort") = "conscode"
                        ElseIf sort = 4 Then
                            Me.DropSort.SelectedValue = "funcheading"
                            ' Session("EstimateGridSort") = "funcheading"
                        ElseIf sort = 5 Then
                            Me.DropSort.SelectedValue = "seqnbr"
                        End If

                    End If
                    If IsDBNull(dr("BLENDED_TIME_RATE")) = False Then
                        Me.txtBlendRate.Text = String.Format("{0:#,##0.00}", dr("BLENDED_TIME_RATE"))
                    End If

                    If Me.JobNum = 0 And Me.CampaignID = 0 Then
                        Me.RadToolbarEstimatingQuote.FindItemByValue("ClientApprove").Enabled = False
                        Me.RadToolbarEstimatingQuote.FindItemByValue("InternalApprove").Enabled = False
                    End If

                Loop
            Else

                Return False

            End If
            If Me.TxtQuoteDescription.Text = "" Then
                Me.TxtQuoteDescription.Text = "Quote " & Me.TxtQuoteNum.Text
            End If
            dr.Close()
            'Check max revision, if not max revision disable editing.
            Dim ag As New cAgency(Session("ConnString"))
            Dim agrev As Boolean = ag.AutoEstRevFlag()
            Dim drApp As SqlDataReader
            Dim drInt As SqlDataReader
            Dim approvalInt As Boolean = False
            Dim approval As Boolean = False
            If Me.ddRevision.SelectedValue <> "" Then
                drInt = est.GetQuoteApprovalInternal(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, approvalType)
                drApp = est.GetQuoteApproval(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, approvalType)
            Else
                drInt = est.GetQuoteApprovalInternal(Me.EstNum, Me.EstCompNum, Me.QuoteNum, 0, approvalType)
                drApp = est.GetQuoteApproval(Me.EstNum, Me.EstCompNum, Me.QuoteNum, 0, approvalType)
            End If
            If drApp.HasRows = True Then
                approval = True
            End If
            If drInt.HasRows = True Then
                approvalInt = True
            End If
            max = est.GetEstimateQuoteMaxRevision(Me.EstNum, Me.EstCompNum, Me.QuoteNum)
            If Me.ddRevision.SelectedValue <> "" Then
                If (max <> Me.ddRevision.SelectedValue) Or (agrev = True And approval = True) Or (agrev = True And approvalInt = True) Then
                    Me.TxtQty.Enabled = False
                    Me.TxtCPU.Enabled = False
                    Me.txtCPM.Enabled = False
                    Me.TxtQuoteDescription.Enabled = False
                    Me.RadEditorQuoteComment.Enabled = False
                    Me.RadEditorRevisionComment.Enabled = False
                    Me.TxtVersion.Enabled = False
                    Me.TxtRevision.Enabled = False
                    Me.HlVersion.Enabled = False
                    Me.txtBlendRate.Enabled = False
                    'Me.RadToolbarEstimatingQuote.FindItemByValue("Save").Enabled = False

                    Me.RadToolbarEstimatingQuote.FindItemByValue("DelRev").Enabled = False
                    Me.RadToolbarEstimatingQuote.FindItemByValue("NewQuote").Enabled = False
                    Me.RadToolbarEstimatingQuote.FindItemByValue("EventGenerator").Enabled = False

                    Me.ButtonAddFunctionsFromListOfFunctions.Enabled = False
                    Me.ButtonDeleteSelectedFunctions.Enabled = False
                    Me.ButtonAddFunctionsFromFunctionTemplates.Enabled = False
                    Me.ButtonAddFunctionsCopyFromExistingQuote.Enabled = False
                    Me.ButtonAddFunctionsCreateFromSchedule.Enabled = False
                    Me.ButtonAddFunctionsCreateFromJobHistory.Enabled = False
                    Me.ButtonQuotefromCampaign.Enabled = False
                    Me.ButtonAdd.Enabled = False
                    Me.ButtonSubtract.Enabled = False
                    Me.ButtonPhaseSetPhase.Enabled = False
                    Me.ButtonPhaseClearPhase.Enabled = False
                Else
                    Me.TxtQty.Enabled = True
                    Me.TxtCPU.Enabled = True
                    Me.txtCPM.Enabled = True
                    Me.TxtQuoteDescription.Enabled = True
                    Me.RadEditorQuoteComment.Enabled = True
                    Me.RadEditorRevisionComment.Enabled = True
                    Me.TxtVersion.Enabled = True
                    Me.TxtRevision.Enabled = True
                    Me.HlVersion.Enabled = True
                    Me.txtBlendRate.Enabled = True
                    'Me.RadToolbarEstimatingQuote.FindItemByValue("Save").Enabled = True
                    Me.RadToolbarEstimatingQuote.FindItemByValue("NewRev").Enabled = True
                    Me.RadToolbarEstimatingQuote.FindItemByValue("DelRev").Enabled = True
                    Me.RadToolbarEstimatingQuote.FindItemByValue("NewQuote").Enabled = True
                    Me.RadToolbarEstimatingQuote.FindItemByValue("EventGenerator").Enabled = True
                    Me.ButtonAddFunctionsFromListOfFunctions.Enabled = True
                    Me.ButtonDeleteSelectedFunctions.Enabled = True
                    Me.ButtonAddFunctionsFromFunctionTemplates.Enabled = True
                    Me.ButtonAddFunctionsCopyFromExistingQuote.Enabled = True
                    Me.ButtonAddFunctionsCreateFromSchedule.Enabled = True
                    Me.ButtonAddFunctionsCreateFromJobHistory.Enabled = True
                    Me.ButtonQuotefromCampaign.Enabled = True
                    Me.ButtonAdd.Enabled = True
                    Me.ButtonSubtract.Enabled = True
                    Me.ButtonPhaseSetPhase.Enabled = True
                    Me.ButtonPhaseClearPhase.Enabled = True
                End If
            End If


            Dim cts As cTimeSheet = New cTimeSheet(Session("ConnString"))
            Dim DtPOData As New DataTable
            Dim actualamt As Decimal = 0.0
            Dim actualmarkup As Decimal = 0.0
            Dim actualtax As Decimal = 0.0
            Dim pototal As Decimal = 0.0
            Dim poapplied As Decimal = 0.0

            DtPOData = cts.GetQuoteVsActualSummary(Me.JobNum, Me.JobCompNum, Session("UserCode"), "Type")

            If Not DtPOData Is Nothing Then

                If DtPOData.Rows.Count > 0 Then

                    actualamt = DtPOData.Compute("Sum(ActualAmount)", "ActualAmount = ActualAmount")
                    actualmarkup = DtPOData.Compute("Sum(ActualMarkup)", "ActualMarkup = ActualMarkup")
                    actualtax = DtPOData.Compute("Sum(ActualTax)", "ActualTax = ActualTax")
                    pototal = DtPOData.Compute("Sum(POTotal)", "POTotal = POTotal")
                    poapplied = DtPOData.Compute("Sum(POApplied)", "POApplied = POApplied")

                End If

            End If

            Me.lblActualPOAmount.Text = String.Format("{0:#,##0.00}", (actualamt + actualmarkup + actualtax + (pototal - poapplied)))
            Me.HookUpHeaderPageMethods()
            Me.CheckUserRights()
        Catch ex As Exception
        End Try

        Return True

    End Function

    Private Sub SaveQuoteHeader()
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim val As New cValidations(Session("ConnString"))
            Dim save As Boolean
            Dim job As Integer
            Dim comp As Integer
            If Me.TxtJobNum.Text = "" Then
                job = 0
            Else
                job = Me.TxtJobNum.Text
            End If
            If Me.TxtJobCompNum.Text = "" Then
                comp = 0
            Else
                comp = Me.TxtJobCompNum.Text
            End If
            If Me.TxtQty.Text <> "" Then
                If IsNumeric(Me.TxtQty.Text) = True Then
                    If Me.TxtQty.Text.Contains(".") = True Then
                        Me.lblMSG.Text = "Qty is invalid"
                        Exit Sub
                    End If
                Else
                    Me.lblMSG.Text = "Qty is invalid"
                    Exit Sub
                End If
            End If
            If Me.TxtVersion.Text <> "" And Me.TxtVersion.Text <> "0" Then
                If IsNumeric(Me.TxtVersion.Text) = True Then
                    If val.ValidateJobSpecsVersion(job, comp, CInt(Me.TxtVersion.Text), CInt(Me.TxtRevision.Text)) = False Then
                        'Me.lblMSG.Text = "Version is invalid"
                        'Exit Sub
                        Me.TxtVersion.Text = ""
                        Me.TxtRevision.Text = ""
                    End If
                Else
                    Me.lblMSG.Text = "Version is invalid"
                    Exit Sub
                End If
            End If
            If Me.txtBlendRate.Text <> "" Then
                If IsNumeric(Me.txtBlendRate.Text) = False Then
                    Me.lblMSG.Text = "Blended Time Bill Rate is invalid"
                    Exit Sub
                End If
            End If
            save = est.UpdateQuote(CInt(Me.TxtEstimate.Text), CInt(Me.TxtEstimateComponent.Text), CInt(Me.TxtQuoteNum.Text), Me.TxtQuoteDescription.Text, Me.ddRevision.SelectedValue, Me.RadEditorQuoteComment.Text, Me.RadEditorRevisionComment.Text,
                            Me.TxtVersion.Text, Me.TxtRevision.Text, 0, Me.TxtQty.Text, "", Session("UserCode"), Me.txtBlendRate.Text, Me.RadEditorQuoteComment.Html, RadEditorRevisionComment.Html)
            If save = True Then
                loadRevisions(Me.ddRevision.SelectedValue)
                LoadQuoteHeader()
            Else
                Me.lblMSG.Text = "Save Failed."
            End If
        Catch ex As Exception
            Me.lblMSG.Text = "Save Failed."
        End Try
    End Sub

    Private Sub HookUpHeaderPageMethods()

        If Me.EstNum > 0 And Me.EstCompNum > 0 And Me.QuoteNum > 0 And Me.RevNum >= 0 Then

            Dim key As String = Me.EstNum.ToString() & "|" & Me.EstCompNum.ToString() & "|" & Me.QuoteNum.ToString() & "|" & Me.RevNum.ToString() & "|" & Me.JobNum.ToString() & "|" & Me.JobCompNum.ToString() & "|" & Me.TxtRevision.Text
            Me.HiddenFieldKey.Value = key
            Me.TxtQuoteDescription.Attributes.Add("onblur", "DataChangeEstimateHeader('" & key & "', 'EST_QUOTE_DESC', this.value, '" & Me.TxtQuoteDescription.ClientID & "');")
            'Me.RadEditorQuoteComment.Attributes.Add("blur", "DataChangeEstimateHeader('" & key & "', 'EST_QTE_COMMENT', this.value, '" & Me.RadEditorQuoteComment.ClientID & "');")
            ' Me.RadEditorRevisionComment.Attributes.Add("blur", "DataChangeEstimateHeader('" & key & "', 'EST_REV_COMMENT', this.value, '" & Me.RadEditorRevisionComment.ClientID & "');")
            Me.TxtQty.Attributes.Add("onblur", "DataChangeEstimateHeader('" & key & "', 'JOB_QTY', this.value, '" & Me.TxtQty.ClientID & "');")
            Me.txtBlendRate.Attributes.Add("onblur", "DataChangeEstimateHeader('" & key & "', 'BLENDED_TIME_RATE', this.value, '" & Me.txtBlendRate.ClientID & "');")
            Me.TxtVersion.Attributes.Add("onblur", "DataChangeEstimateHeader('" & key & "', 'SPEC_VER', this.value, '" & Me.TxtVersion.ClientID & "');")

        End If

    End Sub

    Private Sub SaveGrid(Optional ByVal RebindGrid As Boolean = True, Optional ByVal SaveUserRows As Boolean = True)
        Dim RowCount As Integer = Me.RadGridEstimateQuoteDetails.MasterTableView.Items.Count
        Dim RowFunctionCode As String = ""
        Dim RowFunctionType As String = ""
        Dim RowSuppliedBy As String = ""
        Dim dt As DataTable
        Dim v As New cValidations(Session("ConnString"))
        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim tb As System.Web.UI.WebControls.TextBox
        Dim curCode As String = ""
        If RowCount > 0 Then
            For j As Integer = 0 To RowCount - 1
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridEstimateQuoteDetails.Items(j), Telerik.Web.UI.GridDataItem)
                Try
                    If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colFNC_CODE").Display = True Then
                        RowFunctionCode = DirectCast(CurrentGridRow.FindControl("TxtFunctionCode"), TextBox).Text
                        '	ESTIMATE_REV_DET.FNC_CODE, 
                        If RowFunctionCode <> "" Then
                            If v.ValidateFunctionCodeEst(RowFunctionCode) = False Then
                                Me.lblMSG.Text = "Invalid Function Code."
                                Exit Sub
                            End If
                        Else
                            Me.lblMSG.Text = "Function Code is Required."
                            Exit Sub
                        End If
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colEST_REV_SUP_BY_CDE").Display = True Then
                        RowSuppliedBy = DirectCast(CurrentGridRow.FindControl("TxtEST_REV_SUP_BY_CDE"), TextBox).Text
                        RowFunctionType = DirectCast(CurrentGridRow.FindControl("HfFunctionType"), HiddenField).Value
                        tb = DirectCast(CurrentGridRow.FindControl("TxtEST_REV_SUP_BY_CDE"), TextBox)
                        If tb.ReadOnly Then
                            RowSuppliedBy = DirectCast(CurrentGridRow.FindControl("HfSuppliedByCode"), HiddenField).Value
                            curCode = DirectCast(CurrentGridRow.FindControl("TxtEST_REV_SUP_BY_CDE"), TextBox).Text
                        Else
                            RowSuppliedBy = DirectCast(CurrentGridRow.FindControl("TxtEST_REV_SUP_BY_CDE"), TextBox).Text
                            curCode = DirectCast(CurrentGridRow.FindControl("HfSuppliedByCode"), HiddenField).Value
                        End If
                        If RowFunctionType = "" Then
                            dt = est.GetAddNewFunctionData(RowFunctionCode)
                            If dt.Rows.Count > 0 Then
                                RowFunctionType = dt.Rows(0)("FNC_TYPE")
                            End If
                        End If
                        '	ESTIMATE_REV_DET.EST_REV_SUP_BY_CDE, 
                        If RowFunctionType = "E" Then
                            If RowSuppliedBy <> "" Then
                                If curCode <> RowSuppliedBy Then
                                    If v.ValidateEmpCodetd(RowSuppliedBy) = True Then

                                    Else
                                        Me.lblMSG.Text = "Invalid Employee Code."
                                        Exit Sub
                                    End If
                                End If
                            End If
                        ElseIf RowFunctionType = "V" Then
                            If RowSuppliedBy <> "" Then
                                If curCode <> RowSuppliedBy Then
                                    If v.ValidateVendor(RowSuppliedBy) = True Then

                                    Else
                                        Me.lblMSG.Text = "Invalid Vendor Code."
                                        Exit Sub
                                    End If
                                End If
                            End If
                        End If

                    End If
                Catch ex As Exception
                End Try
            Next
            For i As Integer = 0 To RowCount - 1
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridEstimateQuoteDetails.Items(i), Telerik.Web.UI.GridDataItem)
                Dim CurrentTaskSeq As Integer
                Dim IsUserRow As Integer
                Try
                    CurrentTaskSeq = CType(CurrentGridRow.GetDataKeyValue("SEQ_NBR"), Integer)
                Catch ex As Exception
                    CurrentTaskSeq = -1
                End Try

                Try
                    IsUserRow = CType(CurrentGridRow("ColTESTING_COLUMN").Text, Integer)
                Catch ex As Exception
                    IsUserRow = 0
                End Try


                If EstNum > 0 And EstCompNum > 0 And (CurrentTaskSeq > -1 Or IsUserRow = 1) Then
                    SaveGridRow(i, EstNum, EstCompNum, CurrentTaskSeq, CurrentGridRow, QuoteNum, Me.ddRevision.SelectedValue, False, IsUserRow, SaveUserRows)
                    If Me.lblMSG.Text <> "" Then
                        Exit Sub
                    End If
                End If
            Next
            'If RebindGrid = True Then
            '    Me.RadGridEstimateQuoteDetails.Rebind()
            'End If
        End If
    End Sub

    Private Sub CheckApproval()
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim dr As SqlDataReader
            Dim drInt As SqlDataReader
            Dim approval As Boolean = False
            Dim approvalInt As Boolean = False
            If Me.ddRevision.SelectedValue <> "" Then
                dr = est.GetQuoteApproval(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, approvalType)
                drInt = est.GetQuoteApprovalInternal(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, approvalType)
            Else
                dr = est.GetQuoteApproval(Me.EstNum, Me.EstCompNum, Me.QuoteNum, 0, approvalType)
                drInt = est.GetQuoteApprovalInternal(Me.EstNum, Me.EstCompNum, Me.QuoteNum, 0, approvalType)
            End If
            If drInt.HasRows = True Then
                approvalInt = True
            End If
            Dim button As New Telerik.Web.UI.RadToolBarButton
            button = Me.RadToolbarEstimatingQuote.FindItemByValue("ClientApprove")
            If dr.HasRows = True Then
                Me.hlApproved.Visible = True
                Me.hfApproved.Value = 1
                approval = True
                button.Text = "Unapprove Client"
                button.ToolTip = "Unapprove Client"
            ElseIf button.Text <> "Client Approval" Then
                Me.hlApproved.Visible = False
                Me.hfApproved.Value = 0
                button.Text = "Client Approval"
                button.ToolTip = "Approve"
            Else
                Me.hlApproved.Visible = False
                Me.hfApproved.Value = 0
            End If
            dr.Close()
            drInt.Close()
            Dim max As Integer
            Dim dr2 As SqlDataReader
            Dim dr3 As SqlDataReader
            dr2 = est.GetApprovals(Me.EstNum, Me.EstCompNum, approvalType)
            dr3 = est.GetInternalApprovals(Me.EstNum, Me.EstCompNum, approvalType)
            max = est.GetEstimateQuoteMaxRevision(Me.EstNum, Me.EstCompNum, Me.QuoteNum)
            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                If Me.CheckAdvantageModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_QuoteApproval) = 0 Then
                    Me.RadToolbarEstimatingQuote.FindItemByValue("ClientApprove").Enabled = False
                Else
                    If approval = False And approvalInt = False And (dr2.HasRows = True Or dr3.HasRows = True) Then
                        If dr2.HasRows = True Then
                            Do While dr2.Read
                                Dim nbr As Integer = dr2("EST_QUOTE_NBR")
                                If dr2("EST_QUOTE_NBR") = Me.TxtQuoteNum.Text And Me.ddRevision.SelectedValue = max Then
                                    Me.RadToolbarEstimatingQuote.FindItemByValue("ClientApprove").Enabled = True
                                Else
                                    Me.RadToolbarEstimatingQuote.FindItemByValue("ClientApprove").Enabled = False
                                End If
                            Loop
                        ElseIf dr3.HasRows = True Then
                            Do While dr3.Read
                                Dim nbr2 As Integer = dr3("EST_QUOTE_NBR")
                                If dr3("EST_QUOTE_NBR") = Me.TxtQuoteNum.Text And Me.ddRevision.SelectedValue = max Then
                                    Me.RadToolbarEstimatingQuote.FindItemByValue("ClientApprove").Enabled = True
                                Else
                                    Me.RadToolbarEstimatingQuote.FindItemByValue("ClientApprove").Enabled = False
                                End If
                            Loop
                        Else
                            Me.RadToolbarEstimatingQuote.FindItemByValue("ClientApprove").Enabled = False
                        End If
                    Else
                        If Me.ddRevision.SelectedValue <> max Then
                            'button.Visible = False
                            Me.RadToolbarEstimatingQuote.FindItemByValue("ClientApprove").Enabled = False
                        Else
                            If Me.TxtJobNum.Text <> "" Or Me.hfCampaignID.Value > 0 Then
                                Me.RadToolbarEstimatingQuote.FindItemByValue("ClientApprove").Enabled = True
                            Else
                                Me.RadToolbarEstimatingQuote.FindItemByValue("ClientApprove").Enabled = False
                            End If
                            'button.Visible = True
                        End If
                    End If
                End If
            End Using

            dr2.Close()
            dr3.Close()
            'SetGridSort(Me.DropSort.SelectedValue)
            'Me.RadGridEstimateQuoteDetails.Rebind()
        Catch ex As Exception
            Me.ShowMessage("Error checkapproval!<BR />" & ex.Message.ToString())
        End Try
    End Sub

    Private Sub CheckApprovalInternal()
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim dr As SqlDataReader
            Dim drInt As SqlDataReader
            Dim approvalInt As Boolean = False
            Dim approval As Boolean = False
            If Me.ddRevision.SelectedValue <> "" Then
                drInt = est.GetQuoteApprovalInternal(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, approvalType)
                dr = est.GetQuoteApproval(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, approvalType)
            Else
                drInt = est.GetQuoteApprovalInternal(Me.EstNum, Me.EstCompNum, Me.QuoteNum, 0, approvalType)
                dr = est.GetQuoteApproval(Me.EstNum, Me.EstCompNum, Me.QuoteNum, 0, approvalType)
            End If
            If dr.HasRows = True Then
                approval = True
            End If
            Dim button As New Telerik.Web.UI.RadToolBarButton
            button = Me.RadToolbarEstimatingQuote.FindItemByValue("InternalApprove")
            If drInt.HasRows = True Then
                Me.hlApprovedInternal.Visible = True
                Me.hfInternalApproved.Value = 1
                approvalInt = True
                button.Text = "Unapprove Internal"
                button.ToolTip = "Unapprove Internal"
            ElseIf button.Text <> "Internal Approval" Then
                'Me.LblApprovedInternal.Visible = False
                Me.hlApprovedInternal.Visible = False
                Me.hfInternalApproved.Value = 0
                button.Text = "Internal Approval"
                button.ToolTip = "Internal Approve"
            Else
                'Me.LblApprovedInternal.Visible = False
                Me.hlApprovedInternal.Visible = False
                Me.hfInternalApproved.Value = 0
            End If
            dr.Close()
            drInt.Close()
            Dim max As Integer
            Dim dr2 As SqlDataReader
            Dim dr3 As SqlDataReader
            dr3 = est.GetApprovals(Me.EstNum, Me.EstCompNum, approvalType)
            dr2 = est.GetInternalApprovals(Me.EstNum, Me.EstCompNum, approvalType)
            max = est.GetEstimateQuoteMaxRevision(Me.EstNum, Me.EstCompNum, Me.QuoteNum)
            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                If Me.CheckAdvantageModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_QuoteApproval) = 0 Then
                    Me.RadToolbarEstimatingQuote.FindItemByValue("InternalApprove").Enabled = False
                Else
                    If approval = False And approvalInt = False And (dr2.HasRows = True Or dr3.HasRows = True) Then
                        If dr2.HasRows = True Then
                            Do While dr2.Read
                                Dim nbr As Integer = dr2("EST_QUOTE_NBR")
                                If dr2("EST_QUOTE_NBR") = Me.TxtQuoteNum.Text And Me.ddRevision.SelectedValue = max Then
                                    Me.RadToolbarEstimatingQuote.FindItemByValue("InternalApprove").Enabled = True
                                Else
                                    Me.RadToolbarEstimatingQuote.FindItemByValue("InternalApprove").Enabled = False
                                End If
                            Loop
                        ElseIf dr3.HasRows = True Then
                            Do While dr3.Read
                                Dim nbr2 As Integer = dr3("EST_QUOTE_NBR")
                                If dr3("EST_QUOTE_NBR") = Me.TxtQuoteNum.Text And Me.ddRevision.SelectedValue = max Then
                                    Me.RadToolbarEstimatingQuote.FindItemByValue("InternalApprove").Enabled = True
                                Else
                                    Me.RadToolbarEstimatingQuote.FindItemByValue("InternalApprove").Enabled = False
                                End If
                            Loop
                        Else
                            Me.RadToolbarEstimatingQuote.FindItemByValue("InternalApprove").Enabled = False
                        End If
                    Else
                        If Me.ddRevision.SelectedValue <> max Then
                            'button.Visible = False
                            Me.RadToolbarEstimatingQuote.FindItemByValue("InternalApprove").Enabled = False
                        Else
                            'button.Visible = True
                            If Me.TxtJobCompNum.Text <> "" Or Me.hfCampaignID.Value > 0 Then
                                Me.RadToolbarEstimatingQuote.FindItemByValue("InternalApprove").Enabled = True
                            Else
                                Me.RadToolbarEstimatingQuote.FindItemByValue("InternalApprove").Enabled = False
                            End If

                        End If
                    End If
                End If
            End Using

            dr2.Close()
            dr3.Close()
            'SetGridSort(Me.DropSort.SelectedValue)
            'Me.RadGridEstimateQuoteDetails.Rebind()
        Catch ex As Exception
            Me.ShowMessage("Error checkapproval!<BR />" & ex.Message.ToString())
        End Try
    End Sub

    Private Function AddNewRevision()
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim save As Boolean
            Dim max As Integer
            max = est.GetEstimateQuoteMaxRevision(Me.EstNum, Me.EstCompNum, Me.QuoteNum)
            save = est.AddNewRevision(CInt(Me.TxtEstimate.Text), CInt(Me.TxtEstimateComponent.Text), CInt(Me.TxtQuoteNum.Text), max + 1, CInt(Me.TxtVersion.Text), CInt(Me.TxtRevision.Text), 0, CInt(Me.TxtQty.Text))
            If save = True Then
                loadRevisions(max + 1)
                'LoadQuoteHeader()
            Else
                Me.lblMSG.Text = "Save Failed."
            End If
            Return max
        Catch ex As Exception

        End Try

    End Function

    Private Sub AddRevisionDetails(ByVal maxRev As Integer)
        Try
            Dim estQuote As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim save As Boolean
            Dim dsQuote As Boolean
            Dim i As Integer
            dsQuote = estQuote.GetEstimateQuoteDetailsCopy(Me.EstNum, Me.EstCompNum, Me.QuoteNum, maxRev)
            If dsQuote = False Then
                Me.lblMSG.Text = "Save Failed"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadPhaseList()
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Me.ddPhase.DataSource = est.GetEstimatePhaseDesc(Me.EstNum, Me.EstCompNum)
            Me.ddPhase.DataTextField = "Description"
            Me.ddPhase.DataValueField = "Description"
            Me.ddPhase.DataBind()
            Me.ddPhase.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("None", "0"))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaveSort()
        Try
            Dim SQLPrefix As String = "UPDATE [ESTIMATE_COMPONENT] WITH(ROWLOCK) SET "
            Dim sort As Integer
            Dim SQLBody As StringBuilder = New StringBuilder
            If Me.DropSort.SelectedValue = "funccode" Then
                sort = 1
            ElseIf Me.DropSort.SelectedValue = "conscode" Then
                sort = 3
            ElseIf Me.DropSort.SelectedValue = "functype" Then
                sort = 2
            ElseIf Me.DropSort.SelectedValue = "funcheading" Then
                sort = 4
            ElseIf Me.DropSort.SelectedValue = "seqnbr" Then
                sort = 5
            End If
            With SQLBody
                .Append("FNC_SORT_ORDER = ")
                .Append(sort)
            End With
            Dim SQLSuffix As String = " WHERE (ESTIMATE_NUMBER = " & Me.EstNum & ") AND (EST_COMPONENT_NBR = " & Me.EstCompNum & ")"

            Dim str As String = SQLBody.ToString
            'str = MiscFN.RemoveTrailingDelimiter(str, ",")

            Dim FullSQLString As String = SQLPrefix & str & SQLSuffix

            'Save:
            Using MyConn As New SqlConnection(Session("ConnString"))
                MyConn.Open()
                Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                Dim MyCmd As New SqlCommand(FullSQLString, MyConn, MyTrans)
                Try
                    MyCmd.ExecuteNonQuery()
                    MyTrans.Commit()
                Catch ex As Exception
                    MyTrans.Rollback()
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try
            End Using

            Dim oAppVars As New cAppVars(cAppVars.Application.ESTIMATE_QUOTE)
            oAppVars.setAppVarDB("GridSort", Me.DropSort.SelectedValue)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckForNewRow()
        Try
            Dim newrowpresent As Boolean = False
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstimateQuoteDetails.MasterTableView.Items
                If IsNumeric(gridDataItem.GetDataKeyValue("SEQ_NBR")) Then
                    If gridDataItem.GetDataKeyValue("SEQ_NBR") = "-1" Then
                        newrowpresent = True
                    End If
                End If
            Next
            If newrowpresent = False Then
                Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colFUNCTION_CODE_LOOKUP").Display = False
            Else
                Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colFUNCTION_CODE_LOOKUP").Display = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToggleTBonApproval()
        Try
            Dim ag As New cAgency(Session("ConnString"))
            Dim agrev As Boolean = ag.AutoEstRevFlag()
            Dim max As Integer
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            max = est.GetEstimateQuoteMaxRevision(Me.EstNum, Me.EstCompNum, Me.QuoteNum)
            If (max <> Me.ddRevision.SelectedValue) Or (agrev = True And Me.hlApproved.Visible = True) Or (agrev = True And Me.hlApprovedInternal.Visible = True) Then
                Me.TxtQty.Enabled = False
                Me.TxtCPU.Enabled = False
                Me.txtCPM.Enabled = False
                Me.TxtQuoteDescription.Enabled = False
                Me.RadEditorQuoteComment.Enabled = False
                Me.RadEditorRevisionComment.Enabled = False
                Me.TxtVersion.Enabled = False
                Me.TxtRevision.Enabled = False
                Me.HlVersion.Enabled = False
                Me.txtBlendRate.Enabled = False
                Me.RadToolbarEstimatingQuote.FindItemByValue("Save").Enabled = False
                ' Me.RadToolbarEstimatingQuote.FindItemByValue("NewRev").Enabled = False
                Me.RadToolbarEstimatingQuote.FindItemByValue("DelRev").Enabled = False
                Me.RadToolbarEstimatingQuote.FindItemByValue("NewQuote").Enabled = False
                Me.RadToolbarEstimatingQuote.FindItemByValue("EventGenerator").Enabled = False
                Me.RadToolbarEstimateGrid.Items(1).Enabled = False
                Me.RadToolbarEstimateGrid.Items(3).Enabled = False
                Me.RadToolbarEstimateGrid.Items(4).Enabled = False
                Me.RadToolbarEstimateGrid.Items(6).Enabled = False
                Me.RadToolbarEstimateGrid.Items(7).Enabled = False
                Me.RadToolbarEstimateGrid.Items(8).Enabled = False
                Me.RadToolbarEstimateGrid.Items(9).Enabled = False
                Me.RadToolbarEstimateGrid.Items(10).Enabled = False
                Me.RadToolbarEstimateGrid.Items(11).Enabled = False
                Me.RadToolbarEstimateGrid.Items(12).Enabled = False
                Me.RadToolbarEstimateGrid.Items(13).Enabled = False
            Else
                Me.TxtQty.Enabled = True
                Me.TxtCPU.Enabled = True
                Me.txtCPM.Enabled = True
                Me.TxtQuoteDescription.Enabled = True
                Me.RadEditorQuoteComment.Enabled = True
                Me.RadEditorRevisionComment.Enabled = True
                Me.TxtVersion.Enabled = True
                Me.TxtRevision.Enabled = True
                Me.HlVersion.Enabled = True
                Me.txtBlendRate.Enabled = True
                'Me.RadToolbarEstimatingQuote.FindItemByValue("Save").Enabled = True
                Me.RadToolbarEstimatingQuote.FindItemByValue("NewRev").Enabled = True
                Me.RadToolbarEstimatingQuote.FindItemByValue("DelRev").Enabled = True
                Me.RadToolbarEstimatingQuote.FindItemByValue("NewQuote").Enabled = True
                Me.RadToolbarEstimatingQuote.FindItemByValue("EventGenerator").Enabled = True
                Me.RadToolbarEstimateGrid.Items(1).Enabled = True
                Me.RadToolbarEstimateGrid.Items(3).Enabled = True
                Me.RadToolbarEstimateGrid.Items(4).Enabled = True
                Me.RadToolbarEstimateGrid.Items(6).Enabled = True
                Me.RadToolbarEstimateGrid.Items(7).Enabled = True
                Me.RadToolbarEstimateGrid.Items(8).Enabled = True
                Me.RadToolbarEstimateGrid.Items(9).Enabled = True
                Me.RadToolbarEstimateGrid.Items(10).Enabled = True
                Me.RadToolbarEstimateGrid.Items(11).Enabled = True
                Me.RadToolbarEstimateGrid.Items(12).Enabled = True
                'Me.RadToolbarEstimateGrid.Items(13).Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckRevApprovals()
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim dr As SqlDataReader
            Dim dr2 As SqlDataReader
            Dim drclient As SqlDataReader
            Dim drinternal As SqlDataReader
            Dim max As Integer
            max = est.GetEstimateQuoteMaxRevision(Me.EstNum, Me.EstCompNum, Me.QuoteNum)
            dr = est.GetApprovalByQuote(Me.EstNum, Me.EstCompNum, Me.QuoteNum)
            dr2 = est.GetInternalApprovalByQuote(Me.EstNum, Me.EstCompNum, Me.QuoteNum)
            If max = Me.ddRevision.SelectedValue Then
                drclient = est.GetQuoteApproval(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, approvalType)
                drinternal = est.GetQuoteApprovalInternal(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, approvalType)
                If drclient.HasRows = False And dr.HasRows = True And dr2.HasRows = False Then
                    Me.RadToolbarEstimatingQuote.FindItemByValue("InternalApprove").Enabled = False
                ElseIf drinternal.HasRows = False And dr.HasRows = False And dr2.HasRows = True Then
                    Me.RadToolbarEstimatingQuote.FindItemByValue("ClientApprove").Enabled = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Recalculate()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Function AddNewFunctionRow(ByVal griditem As Telerik.Web.UI.GridDataItem)
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim v As New cValidations(Session("ConnString"))

            Dim functioncode As String = ""
            Dim suppliedby As String = ""
            Dim markuppct As Decimal = 0.0
            Dim contpct As Decimal = 0.0
            Dim contamt As Decimal = 0.0
            Dim quantityhours As Decimal = 0.0
            Dim rate As Decimal = 0.0
            Dim extamt As Decimal = 0.0
            Dim markupamt As Decimal = 0.0
            Dim fnctype As String = ""
            Dim fnccpmflag As Integer
            Dim taxcomm As Integer
            Dim taxcommonly As Integer
            Dim fncnobillflag As Integer
            Dim fnctaxflag As Integer
            Dim fnccommflag As Integer
            Dim taxstatepct As Decimal = 0.0
            Dim taxcountypct As Decimal = 0.0
            Dim taxcitypct As Decimal = 0.0
            Dim taxresale As Integer = 0
            Dim taxresalenbr As String = ""
            Dim extnonresaletax As Decimal = 0.0
            Dim extstateresale As Decimal = 0.0
            Dim extcountyresale As Decimal = 0.0
            Dim extcityresale As Decimal = 0.0
            Dim extstatenonresale As Decimal = 0.0
            Dim extcountynonresale As Decimal = 0.0
            Dim extcitynonresale As Decimal = 0.0
            Dim extstatemarkup As Decimal = 0.0
            Dim extcountymarkup As Decimal = 0.0
            Dim extcitymarkup As Decimal = 0.0
            Dim extmucont As Decimal = 0.0
            Dim extstatecont As Decimal = 0.0
            Dim extcountycont As Decimal = 0.0
            Dim extcitycont As Decimal = 0.0
            Dim extnrcont As Decimal = 0.0
            Dim linetotal As Decimal = 0.0
            Dim linetotalcont As Decimal = 0.0
            Dim taxcode As String = ""
            Dim estmarkuppct As Decimal = 0
            Dim jobmarkuppct As Decimal = 0
            Dim feetime As Integer = 0
            Dim estbillrateflag As Integer = 0
            Dim clcode As String
            Dim divcode As String
            Dim prdcode As String
            Dim sccode As String = ""
            Dim blendedrate As Decimal = 0.0
            Dim job As Integer = 0
            Dim jobcomp As Integer = 0
            Dim cpu As Integer = 0
            Dim effectivedate As Date = Nothing
            Dim employeetitleid As Integer = 0

            Dim dr As SqlClient.SqlDataReader
            Dim max As Integer
            Dim sort As Integer
            dr = est.GetEstimateQuoteInfo(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum)
            If dr.HasRows = True Then
                Do While dr.Read
                    contpct = dr("PRD_CONT_PCT")
                    estmarkuppct = dr("EST_MARKUP_PCT")
                    jobmarkuppct = dr("JOB_MARKUP_PCT")
                    clcode = dr("CL_CODE")
                    divcode = dr("DIV_CODE")
                    prdcode = dr("PRD_CODE")
                    job = dr("JOB_NUMBER")
                    jobcomp = dr("JOB_COMPONENT_NBR")
                    If IsDBNull(dr("BLENDED_TIME_RATE")) = False Then
                        blendedrate = dr("BLENDED_TIME_RATE")
                    Else
                        blendedrate = -1.0
                    End If
                    If IsDBNull(dr("SC_CODE")) = False Then
                        sccode = dr("SC_CODE")
                    End If
                    'effectivedate = dr("EST_CREATE_DATE")
                Loop
            End If
            dr.Close()

            estbillrateflag = est.GetEstBillRateFlag(clcode, divcode, prdcode)

            Dim chk As CheckBox
            Dim dt As DataTable
            Dim dtInfo As New DataTable
            Dim FunctionTextbox As System.Web.UI.WebControls.TextBox = Nothing
            Dim DetailCommentsTextbox As System.Web.UI.WebControls.TextBox = Nothing
            Dim SuppliedByTextbox As System.Web.UI.WebControls.TextBox = Nothing
            Dim SuppliedByHiddenField As System.Web.UI.WebControls.HiddenField = Nothing
            Dim SuppliedByNotesTextBox As System.Web.UI.WebControls.TextBox = Nothing
            Dim QuantityHoursTextBox As System.Web.UI.WebControls.TextBox = Nothing
            Dim RateTextbox As System.Web.UI.WebControls.TextBox = Nothing
            Dim ExtendedAmountTextBox As System.Web.UI.WebControls.TextBox = Nothing
            Dim TaxCodeTextBox As System.Web.UI.WebControls.TextBox = Nothing
            Dim TaxCodeHiddenField As HtmlInputHidden = Nothing
            Dim TaxAmountTextBox As System.Web.UI.WebControls.TextBox = Nothing
            Dim MarkupPercentTextbox As System.Web.UI.WebControls.TextBox = Nothing
            Dim MarkupAmountTextBox As System.Web.UI.WebControls.TextBox = Nothing
            Dim ContingencyPercentTextbox As System.Web.UI.WebControls.TextBox = Nothing
            Dim ContingencyAmountTextBox As System.Web.UI.WebControls.TextBox = Nothing
            Dim CPUCheckbox As System.Web.UI.WebControls.CheckBox = Nothing
            Dim EmployeeTitleTextBox As System.Web.UI.WebControls.TextBox = Nothing
            Dim EmployeeTitleHiddenField As HtmlInputHidden = Nothing

            If griditem IsNot Nothing Then

                LoadGridItemControls(griditem, FunctionTextbox, DetailCommentsTextbox, SuppliedByTextbox, SuppliedByNotesTextBox, QuantityHoursTextBox,
                                     RateTextbox, ExtendedAmountTextBox, TaxCodeTextBox, TaxAmountTextBox, MarkupPercentTextbox, MarkupAmountTextBox,
                                     ContingencyPercentTextbox, ContingencyAmountTextBox, CPUCheckbox, TaxCodeHiddenField, SuppliedByHiddenField, EmployeeTitleTextBox, EmployeeTitleHiddenField)

                'Set variables:
                rate = IIf(RateTextbox.Text = "", 0, RateTextbox.Text)
                functioncode = FunctionTextbox.Text.Replace("&nbsp;", "")
                suppliedby = SuppliedByTextbox.Text 'SuppliedByHiddenField.Value
                quantityhours = IIf(QuantityHoursTextBox.Text = "", 0, QuantityHoursTextBox.Text)
                extamt = IIf(ExtendedAmountTextBox.Text = "", 0, ExtendedAmountTextBox.Text)
                markuppct = IIf(MarkupPercentTextbox.Text = "", 0, MarkupPercentTextbox.Text)
                markupamt = IIf(MarkupAmountTextBox.Text = "", 0, MarkupAmountTextBox.Text)
                taxcode = TaxCodeTextBox.Text 'TaxCodeHiddenField.Value
                contpct = IIf(ContingencyPercentTextbox.Text = "", 0, ContingencyPercentTextbox.Text)
                'employeetitleid = If(EmployeeTitleHiddenField.Value = "", 0, EmployeeTitleHiddenField.Value)

                If JobNumber = 0 AndAlso String.IsNullOrWhiteSpace(Me.TxtJobNum.Text) = False AndAlso IsNumeric(Me.TxtJobNum.Text) = True Then

                    JobNumber = CType(Me.TxtJobNum.Text, Integer)

                End If

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        employeetitleid = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadByEmployeeTitleDescription(DbContext, EmployeeTitleTextBox.Text).ID

                    End Using

                Catch ex As Exception
                End Try


                If CPUCheckbox.Checked = True Then
                    cpu = 1
                End If

                dt = est.GetDefaultFunctionData(functioncode, job, jobcomp, clcode, divcode, prdcode, sccode, suppliedby, employeetitleid)

                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows(0)("FNC_TYPE")) = False Then
                        fnctype = dt.Rows(0)("FNC_TYPE")
                    End If
                End If

                'If fnctype = "E" Then
                '    If suppliedby <> "" Then
                '        If v.ValidateEmpCodetd(suppliedby) = False Then
                '            suppliedby = ""
                '        End If

                '    End If
                'ElseIf fnctype = "V" Then
                '    If suppliedby <> "" Then
                '        If v.ValidateVendor(suppliedby) = False Then
                '            suppliedby = ""
                '        End If
                '    End If
                'End If

                If functioncode = "" Then
                    '"Function Code Required."
                    Exit Function
                Else

                    If JobNumber > 0 OrElse String.IsNullOrEmpty(clcode) = False Then
                        If v.ValidateFunctionCodeEst(functioncode, JobNumber, clcode) = False Then
                            Me.lblMSG.Text = "Invalid Function Code."
                            Exit Function
                        End If
                    Else
                        If v.ValidateFunctionCodeEst(functioncode) = False Then
                            Me.lblMSG.Text = "Invalid Function Code."
                            Exit Function
                        End If
                    End If

                    If dt.Rows.Count > 0 Then
                        If estbillrateflag = 1 And fnctype = "E" And blendedrate <> -1.0 Then
                            rate = blendedrate
                        Else
                            'If IsDBNull(dt.Rows(0)("BILLING_RATE")) = False Then
                            '    rate = dt.Rows(0)("BILLING_RATE")
                            'End If
                        End If
                        If IsDBNull(dt.Rows(0)("NOBILL_FLAG")) = False Then
                            fncnobillflag = dt.Rows(0)("NOBILL_FLAG")
                        End If
                        If IsDBNull(dt.Rows(0)("TAX_COMM")) = False Then
                            taxcomm = dt.Rows(0)("TAX_COMM")
                        End If
                        If IsDBNull(dt.Rows(0)("TAX_COMM_ONLY")) = False Then
                            taxcommonly = dt.Rows(0)("TAX_COMM_ONLY")
                        End If
                        'If IsDBNull(dt.Rows(0)("TAX_CODE")) = False And taxcode = "" Then
                        '    taxcode = dt.Rows(0)("TAX_CODE")
                        '    taxstatepct = dt.Rows(0)("TAX_STATE_PERCENT")
                        '    taxcountypct = dt.Rows(0)("TAX_COUNTY_PERCENT")
                        '    taxcitypct = dt.Rows(0)("TAX_CITY_PERCENT")
                        '    fnctaxflag = 1

                        '    If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                        '        taxresale = dt.Rows(0)("TAX_RESALE")
                        '    End If

                        'Else
                        If taxcode <> "" Then
                            fnctaxflag = 1
                            dtInfo = est.GetAddNewTaxData(taxcode)
                            If dtInfo.Rows.Count > 0 Then
                                taxstatepct = dtInfo.Rows(0)("TAX_STATE_PERCENT")
                                taxcountypct = dtInfo.Rows(0)("TAX_COUNTY_PERCENT")
                                taxcitypct = dtInfo.Rows(0)("TAX_CITY_PERCENT")
                                taxresale = dtInfo.Rows(0)("TAX_RESALE")
                            End If
                        Else
                            fnctaxflag = 0
                        End If
                        '    'taxcode = ""
                        'End If
                        If IsDBNull(dt.Rows(0)("TAX_RESALE_NUMBER")) = False Then
                            taxresalenbr = dt.Rows(0)("TAX_RESALE_NUMBER")
                        End If
                        If IsDBNull(dt.Rows(0)("FEE_TIME_FLAG")) = False Then
                            feetime = dt.Rows(0)("FEE_TIME_FLAG")
                        End If
                        'If IsDBNull(dt.Rows(0)("COMM")) = False Then
                        '    If markuppct = 0 Then
                        '        markuppct = dt.Rows(0)("COMM")
                        '    End If
                        If markuppct = 0 Then
                            fnccommflag = 0
                        Else
                            fnccommflag = 1
                        End If
                        'Else
                        '    fnccommflag = 1
                        '    If markuppct = 0 Then
                        '        markuppct = estmarkuppct
                        '    End If
                        'End If
                        If rate > 0 And quantityhours > 0 And extamt = 0 Then
                            extamt = quantityhours * rate
                        End If
                        If markuppct <> 0 And extamt > 0 And markupamt = 0 Then
                            markupamt = extamt * (markuppct / 100)
                            extmucont = markupamt * (contpct / 100)
                        Else
                            If markupamt <> 0 Then
                                extmucont = markupamt * (contpct / 100)
                            End If
                        End If
                        If contpct <> 0 Then
                            contamt = extamt * (contpct / 100)
                            'If markuppct <> 0 Then
                            linetotalcont += (markupamt * (contpct / 100))
                            'End If
                        End If
                        If taxresale = 1 Then
                            If taxcommonly <> 1 Then
                                extstateresale = extamt * (taxstatepct / 100)
                                extcountyresale = extamt * (taxcountypct / 100)
                                extcityresale = extamt * (taxcitypct / 100)
                            End If
                            If taxcomm = 1 Then
                                If markupamt > 0 Then
                                    extstatemarkup = markupamt * (taxstatepct / 100)
                                    extcountymarkup = markupamt * (taxcountypct / 100)
                                    extcitymarkup = markupamt * (taxcitypct / 100)
                                End If
                            End If
                            extstateresale += extstatemarkup
                            extcountyresale += extcountymarkup
                            extcityresale += extcitymarkup
                            If contamt > 0 Then
                                If taxcomm = 1 And taxcommonly = 1 Then
                                    extstatecont = extmucont * (taxstatepct / 100)
                                    extcountycont = extmucont * (taxcountypct / 100)
                                    extcitycont = extmucont * (taxcitypct / 100)
                                ElseIf taxcomm = 1 Then
                                    extstatecont = (contamt + extmucont) * (taxstatepct / 100)
                                    extcountycont = (contamt + extmucont) * (taxcountypct / 100)
                                    extcitycont = (contamt + extmucont) * (taxcitypct / 100)
                                Else
                                    extstatecont = contamt * (taxstatepct / 100)
                                    extcountycont = contamt * (taxcountypct / 100)
                                    extcitycont = contamt * (taxcitypct / 100)
                                End If
                            End If
                        End If
                        If taxresale <> 1 Then
                            If fnctype = "V" Then
                                If taxcommonly <> 1 Then
                                    extstatenonresale = extamt * (taxstatepct / 100)
                                    extcountynonresale = extamt * (taxcountypct / 100)
                                    extcitynonresale = extamt * (taxcitypct / 100)
                                    extnonresaletax = extstatenonresale + extcountynonresale + extcitynonresale
                                End If
                                If contamt > 0 Then
                                    If taxcomm = 1 And taxcommonly = 1 Then
                                        extnrcont = extmucont * (taxstatepct / 100) + extmucont * (taxcountypct / 100) + extmucont * (taxcitypct / 100)
                                    ElseIf taxcomm = 1 Then
                                        extnrcont = (contamt + extmucont) * (taxstatepct / 100) + (contamt + extmucont) * (taxcountypct / 100) + (contamt + extmucont) * (taxcitypct / 100)
                                    Else
                                        extnrcont = contamt * (taxstatepct / 100) + contamt * (taxcountypct / 100) + contamt * (taxcitypct / 100)
                                    End If
                                End If
                            ElseIf fnctype = "E" Or fnctype = "I" Then
                                If taxcommonly <> 1 Then
                                    extstateresale = extamt * (taxstatepct / 100)
                                    extcountyresale = extamt * (taxcountypct / 100)
                                    extcityresale = extamt * (taxcitypct / 100)
                                End If
                                If contamt > 0 Then
                                    If taxcomm = "1" And taxcommonly = "1" Then
                                        extstatecont = extmucont * (taxstatepct / 100)
                                        extcountycont = extmucont * (taxcountypct / 100)
                                        extcitycont = extmucont * (taxcitypct / 100)
                                    ElseIf taxcomm = "1" Then
                                        extstatecont = (contamt + extmucont) * (taxstatepct / 100)
                                        extcountycont = (contamt + extmucont) * (taxcountypct / 100)
                                        extcitycont = (contamt + extmucont) * (taxcitypct / 100)
                                    Else
                                        extstatecont = contamt * (taxstatepct / 100)
                                        extcountycont = contamt * (taxcountypct / 100)
                                        extcitycont = contamt * (taxcitypct / 100)
                                    End If
                                End If
                            End If
                            If taxcomm = 1 Then
                                If markupamt > 0 Then
                                    extstatemarkup = markupamt * (taxstatepct / 100)
                                    extcountymarkup = markupamt * (taxcountypct / 100)
                                    extcitymarkup = markupamt * (taxcitypct / 100)
                                End If
                            End If
                            extstateresale += extstatemarkup
                            extcountyresale += extcountymarkup
                            extcityresale += extcitymarkup
                        End If
                    End If
                    dt = est.GetAddNewFunctionData(functioncode)
                    If dt.Rows.Count > 0 Then
                        fnccpmflag = dt.Rows(0)("FNC_CPM_FLAG")
                    End If
                    If fnctype <> "E" Then
                        employeetitleid = 0
                    End If
                End If

                linetotal = extamt + markupamt + Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extnonresaletax, 2, MidpointRounding.AwayFromZero)
                linetotalcont += contamt + Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extnrcont, 2, MidpointRounding.AwayFromZero)
                'Save:
                Try
                    Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
                    'straighten out the phaseID and description! (also on quick add)
                    oEstimating.AddNewFunction(EstNum, EstCompNum, QuoteNum, RevNum, 0, functioncode, markuppct, contpct, quantityhours,
                                                    rate, suppliedby, SuppliedByNotesTextBox.Text, extamt, taxcode, DetailCommentsTextbox.Text, markupamt,
                                                    contamt, linetotal, cpu, Session("UserCode"), fnctype, fnccpmflag, taxstatepct, taxcountypct, taxcitypct, taxcomm, taxcommonly,
                                                    taxresale, fnccommflag, fnctaxflag, fncnobillflag, extnonresaletax, extstateresale, extcountyresale,
                                                    extcityresale, extmucont, extstatecont, extcountycont, extcitycont, extnrcont, linetotalcont, feetime, employeetitleid)

                Catch ex As Exception

                End Try
            End If

        Catch ex As Exception

        End Try
    End Function

    Private Sub LoadGridItemControls(ByVal GridItem As Telerik.Web.UI.GridItem, Optional ByRef FunctionTextbox As System.Web.UI.WebControls.TextBox = Nothing,
                                     Optional ByRef DetailCommentsTextbox As System.Web.UI.WebControls.TextBox = Nothing, Optional ByRef SuppliedByTextbox As System.Web.UI.WebControls.TextBox = Nothing,
                                     Optional ByRef SuppliedByNotesTextBox As System.Web.UI.WebControls.TextBox = Nothing, Optional ByRef QuantityHoursTextBox As System.Web.UI.WebControls.TextBox = Nothing,
                                     Optional ByRef RateTextbox As System.Web.UI.WebControls.TextBox = Nothing, Optional ByRef ExtendedAmountTextBox As System.Web.UI.WebControls.TextBox = Nothing,
                                     Optional ByRef TaxCodeTextBox As System.Web.UI.WebControls.TextBox = Nothing, Optional ByRef TaxAmountTextBox As System.Web.UI.WebControls.TextBox = Nothing,
                                     Optional ByRef MarkupPercentTextbox As System.Web.UI.WebControls.TextBox = Nothing, Optional ByRef MarkupAmountTextBox As System.Web.UI.WebControls.TextBox = Nothing,
                                     Optional ByRef ContingencyPercentTextbox As System.Web.UI.WebControls.TextBox = Nothing, Optional ByRef ContingencyAmountTextBox As System.Web.UI.WebControls.TextBox = Nothing,
                                     Optional ByRef CPUCheckbox As System.Web.UI.WebControls.CheckBox = Nothing, Optional ByRef TaxCodeHiddenfield As HtmlInputHidden = Nothing,
                                     Optional ByRef SuppliedByHiddenfield As System.Web.UI.WebControls.HiddenField = Nothing, Optional ByRef EmployeeTitleTextBox As System.Web.UI.WebControls.TextBox = Nothing, Optional ByRef EmployeeTitleHiddenField As HtmlInputHidden = Nothing, Optional ByRef FeeTimeDiv As HtmlControls.HtmlControl = Nothing,
                                     Optional ByRef SaveImageButton As System.Web.UI.WebControls.ImageButton = Nothing, Optional ByRef CopyImageButton As System.Web.UI.WebControls.ImageButton = Nothing, Optional ByRef DeleteImageButton As System.Web.UI.WebControls.ImageButton = Nothing,
                                     Optional ByRef CancelImageButton As System.Web.UI.WebControls.ImageButton = Nothing, Optional ByRef AddItemImageButton As System.Web.UI.WebControls.ImageButton = Nothing)

        If GridItem IsNot Nothing Then

            Try

                FunctionTextbox = GridItem.FindControl("TxtFunctionCode")
                DetailCommentsTextbox = GridItem.FindControl("TxtEST_FNC_COMMENT")
                SuppliedByTextbox = GridItem.FindControl("TxtEST_REV_SUP_BY_CDE")
                SuppliedByHiddenfield = GridItem.FindControl("HfSuppliedByCode")
                SuppliedByNotesTextBox = GridItem.FindControl("TxtEST_REV_SUP_BY_NTE")
                TaxCodeTextBox = GridItem.FindControl("TxtTaxCode")
                TaxCodeHiddenfield = GridItem.FindControl("HiddenFieldTaxCode")
                TaxAmountTextBox = GridItem.FindControl("TxtTAX_AMOUNT")

                QuantityHoursTextBox = GridItem.FindControl("TxtEST_REV_QUANTITY")
                RateTextbox = GridItem.FindControl("TxtEST_REV_RATE")
                ExtendedAmountTextBox = GridItem.FindControl("TxtEST_REV_EXT_AMT")
                MarkupPercentTextbox = GridItem.FindControl("TxtEST_REV_COMM_PCT")
                MarkupAmountTextBox = GridItem.FindControl("TxtMARKUP_AMT")
                ContingencyPercentTextbox = GridItem.FindControl("TxtEST_REV_CONT_PCT")
                ContingencyAmountTextBox = GridItem.FindControl("TxtEXT_CONTINGENCY")
                FeeTimeDiv = GridItem.FindControl("DivFlagColor")
                CPUCheckbox = GridItem.FindControl("ChkCPU")
                SaveImageButton = GridItem.FindControl("ImageButton_SaveFunction")
                CopyImageButton = GridItem.FindControl("ImageButton_CopyFunction")
                DeleteImageButton = GridItem.FindControl("ImageButton_DeleteFunction")
                CancelImageButton = GridItem.FindControl("ImageButton_CancelFunction")
                AddItemImageButton = GridItem.FindControl("ImageButton_AddFunction")

                EmployeeTitleTextBox = GridItem.FindControl("TxtEMPLOYEE_TITLE")
                EmployeeTitleHiddenField = GridItem.FindControl("HiddenEmployeeTitleID")

            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub ClearGridRow(ByVal GridItem As Telerik.Web.UI.GridItem)

        If GridItem IsNot Nothing Then

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        DirectCast(GridItem.FindControl("TxtFunctionCode"), System.Web.UI.WebControls.TextBox).Text = ""
                        DirectCast(GridItem.FindControl("TxtFNC_DESCRIPTION"), System.Web.UI.WebControls.TextBox).Text = ""
                        DirectCast(GridItem.FindControl("TxtEST_FNC_COMMENT"), System.Web.UI.WebControls.TextBox).Text = ""
                        DirectCast(GridItem.FindControl("TxtEST_REV_SUP_BY_CDE"), System.Web.UI.WebControls.TextBox).Text = ""
                        DirectCast(GridItem.FindControl("TxtEST_REV_SUP_BY_NTE"), System.Web.UI.WebControls.TextBox).Text = ""
                        DirectCast(GridItem.FindControl("TxtTaxCode"), System.Web.UI.WebControls.TextBox).Text = ""
                        DirectCast(GridItem.FindControl("TxtTAX_AMOUNT"), System.Web.UI.WebControls.TextBox).Text = ""
                        DirectCast(GridItem.FindControl("TxtEST_REV_QUANTITY"), System.Web.UI.WebControls.TextBox).Text = ""
                        DirectCast(GridItem.FindControl("TxtEST_REV_RATE"), System.Web.UI.WebControls.TextBox).Text = ""
                        DirectCast(GridItem.FindControl("TxtEST_REV_EXT_AMT"), System.Web.UI.WebControls.TextBox).Text = ""
                        DirectCast(GridItem.FindControl("TxtEST_REV_COMM_PCT"), System.Web.UI.WebControls.TextBox).Text = ""
                        DirectCast(GridItem.FindControl("TxtEST_REV_CONT_PCT"), System.Web.UI.WebControls.TextBox).Text = ""
                        DirectCast(GridItem.FindControl("TxtMARKUP_AMT"), System.Web.UI.WebControls.TextBox).Text = ""
                        DirectCast(GridItem.FindControl("TxtLINE_TOTAL"), System.Web.UI.WebControls.TextBox).Text = ""
                        DirectCast(GridItem.FindControl("TxtGrossIncome"), System.Web.UI.WebControls.TextBox).Text = ""
                        DirectCast(GridItem.FindControl("TxtQUOTE_W_CONTINGENCY"), System.Web.UI.WebControls.TextBox).Text = ""

                    Catch ex As Exception

                    End Try

                End Using

            End Using

            'SetupGridItem(GridItem, Nothing)

        End If

    End Sub

    Private Function ValidateGridRow(ByVal griditem As Telerik.Web.UI.GridDataItem)

        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim v As New cValidations(Session("ConnString"))
        Dim dt As DataTable
        Dim RowFunctionCode As String = ""
        Dim RowSuppliedBy As String = ""
        Dim RowQuantityHours As Decimal = 0
        Dim RowRevRate As Decimal = 0
        Dim RowExtAmount As Decimal = 0
        Dim RowTaxCode As String = ""
        Dim RowContPct As Decimal = 0
        Dim RowMarkupPct As Decimal = 0
        Dim RowMarkupAmt As Decimal = 0
        Dim RowFunctionType As String = ""
        Dim RowEmployeeTitle As String = ""

        If JobNumber = 0 AndAlso String.IsNullOrWhiteSpace(Me.TxtJobNum.Text) = False AndAlso IsNumeric(Me.TxtJobNum.Text) = True Then

            JobNumber = CType(Me.TxtJobNum.Text, Integer)

        End If

        'Function Code
        Try

            RowFunctionCode = DirectCast(griditem.FindControl("TxtFunctionCode"), TextBox).Text

            If String.IsNullOrWhiteSpace(RowFunctionCode) = False Then

                If JobNumber > 0 OrElse String.IsNullOrEmpty(hfClientCode.Value) = False Then

                    If v.ValidateFunctionCodeEst(RowFunctionCode, JobNumber, hfClientCode.Value) = False Then

                        Me.ShowMessage("Invalid Function Code.")
                        Return False

                    End If

                Else

                    If v.ValidateFunctionCodeEst(RowFunctionCode) = False Then

                        Me.ShowMessage("Invalid Function Code.")
                        Return False

                    End If

                End If

            Else

                Me.ShowMessage("Function Code is Required.")
                Return False

            End If

        Catch ex As Exception
        End Try

        'Supplied By
        Try
            If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colEST_REV_SUP_BY_CDE").Display = True Then
                RowSuppliedBy = DirectCast(griditem.FindControl("TxtEST_REV_SUP_BY_CDE"), TextBox).Text
                RowFunctionType = DirectCast(griditem.FindControl("HfFunctionType"), HiddenField).Value
                If RowFunctionType = "" Then
                    dt = est.GetAddNewFunctionData(RowFunctionCode)
                    If dt.Rows.Count > 0 Then
                        RowFunctionType = dt.Rows(0)("FNC_TYPE")
                    End If
                End If
                If RowFunctionType = "E" Then
                    If RowSuppliedBy <> "" Then
                        If v.ValidateEmpCodetd(RowSuppliedBy) = True Then

                        Else
                            Me.ShowMessage("Invalid Employee Code.")
                            Return False
                        End If
                    End If
                ElseIf RowFunctionType = "V" Then
                    If RowSuppliedBy <> "" Then
                        If v.ValidateVendor(RowSuppliedBy) = True Then

                        Else
                            Me.ShowMessage("Invalid Vendor Code.")
                            Return False
                        End If
                    End If
                End If

            End If
        Catch ex As Exception
        End Try

        'Employee title
        Try
            Dim EpTitle As AdvantageFramework.Database.Entities.EmployeeTitle = Nothing
            If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colEMPLOYEE_TITLE").Display = True Then
                RowEmployeeTitle = DirectCast(griditem.FindControl("TxtEMPLOYEE_TITLE"), TextBox).Text
                If RowEmployeeTitle <> "" Then
                    Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
                        Try
                            EpTitle = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadByEmployeeTitleDescription(DbContext, RowEmployeeTitle)
                        Catch ex As Exception
                            EpTitle = Nothing
                        End Try

                        If EpTitle Is Nothing Then
                            Me.ShowMessage("Invalid Employee Title.")
                            Return False
                        End If
                    End Using
                End If
            End If

        Catch ex As Exception
        End Try



        'tax code
        Try
            If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colTAX_CODE").Display = True Then
                RowTaxCode = DirectCast(griditem.FindControl("TxtTaxCode"), TextBox).Text
                If RowTaxCode <> "" Then
                    If v.ValidateTaxCode(RowTaxCode) = False Then
                        Me.ShowMessage("Invalid Tax Code.")
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

        Try
            If DirectCast(griditem.FindControl("TxtEST_REV_QUANTITY"), TextBox).Text = "" Then
                DirectCast(griditem.FindControl("TxtEST_REV_QUANTITY"), TextBox).Text = "0.00"
            End If
            If DirectCast(griditem.FindControl("TxtEST_REV_RATE"), TextBox).Text = "" Then
                DirectCast(griditem.FindControl("TxtEST_REV_RATE"), TextBox).Text = "0.00"
            End If
            If DirectCast(griditem.FindControl("TxtEST_REV_EXT_AMT"), TextBox).Text = "" Then
                DirectCast(griditem.FindControl("TxtEST_REV_EXT_AMT"), TextBox).Text = "0.00"
            End If
            If DirectCast(griditem.FindControl("TxtEST_REV_COMM_PCT"), TextBox).Text = "" Then
                DirectCast(griditem.FindControl("TxtEST_REV_COMM_PCT"), TextBox).Text = "0.00"
            End If
            If DirectCast(griditem.FindControl("TxtEST_REV_CONT_PCT"), TextBox).Text = "" Then
                DirectCast(griditem.FindControl("TxtEST_REV_CONT_PCT"), TextBox).Text = "0.00"
            End If
            If DirectCast(griditem.FindControl("TxtMARKUP_AMT"), TextBox).Text = "" Then
                DirectCast(griditem.FindControl("TxtMARKUP_AMT"), TextBox).Text = "0.00"
            End If
            If IsNumeric(DirectCast(griditem.FindControl("TxtEST_REV_QUANTITY"), TextBox).Text) = False Then
                Me.ShowMessage("Invalid Qty.")
                Return False
            End If
            If IsNumeric(DirectCast(griditem.FindControl("TxtEST_REV_RATE"), TextBox).Text) = False Then
                Me.ShowMessage("Invalid Rate.")
                Return False
            End If
            If IsNumeric(DirectCast(griditem.FindControl("TxtEST_REV_EXT_AMT"), TextBox).Text) = False Then
                Me.ShowMessage("Invalid Extended Amount.")
                Return False
            End If
            If IsNumeric(DirectCast(griditem.FindControl("TxtEST_REV_COMM_PCT"), TextBox).Text) = False Then
                Me.ShowMessage("Invalid Markup Percent.")
                Return False
            End If
            If IsNumeric(DirectCast(griditem.FindControl("TxtEST_REV_CONT_PCT"), TextBox).Text) = False Then
                Me.ShowMessage("Invalid Contingency Percent.")
                Return False
            End If
            If IsNumeric(DirectCast(griditem.FindControl("TxtMARKUP_AMT"), TextBox).Text) = False Then
                Me.ShowMessage("Invalid Markup Amount.")
                Return False
            End If

        Catch ex As Exception
        End Try

        Return True

    End Function

#End Region

#Region " RadGrid Events "



    Protected Sub RadGridEstimateQuoteDetails_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridEstimateQuoteDetails.ItemCommand

        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))

        If e.Item Is Nothing Then Exit Sub

        Try
            Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
            Dim index As Integer = 0
            If Not e.Item Is Nothing Then
                index = e.Item.ItemIndex
            Else
                Exit Sub
            End If
            If e.CommandName = "Page" Then 'command item
                MiscFN.SavePageSize(Me.RadGridEstimateQuoteDetails.ID, Me.RadGridEstimateQuoteDetails.PageSize)
                Exit Sub
            End If

            Try

                GridDataItem = DirectCast(e.Item, Telerik.Web.UI.GridDataItem)

            Catch ex As Exception
                GridDataItem = Nothing
            End Try

            Select Case e.CommandName
                Case "ShowComments"
                    Me.SaveGrid()
                    'Me.SaveQuoteHeader()
                    Me.SaveSort()

                    Dim StrCommentsURL As String = "Estimating_FunctionComments.aspx?EstNum=" & EstNum & "&EstComp=" & EstCompNum & "&QuoteNum=" & QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&SeqNum=" & e.CommandArgument & "&JobNum=" & Me.JobNum & "&JobComp=" & Me.JobCompNum & "&SpecVer=" & Me.TxtVersion.Text & "&SpecRev=" & Me.TxtRevision.Text & "&CampaignID=" & Me.CampaignID
                    Me.OpenWindow("Estimating Function Comments", StrCommentsURL, 710, 670, False, True, "RefreshPage")
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "SetCommentsWindow", "", StrCommentsURL, 600, 650, True)
                Case "AddItem"
                    If GridDataItem IsNot Nothing Then
                        If ValidateGridRow(GridDataItem) = True Then
                            AddNewFunctionRow(GridDataItem)
                            Me.RadGridEstimateQuoteDetails.Rebind()
                        End If
                    End If
                Case "Delete"
                    Dim DelSQL As String = ""
                    Dim SeqNumber As String = e.CommandArgument
                    If EstNum > 0 And EstCompNum > 0 Then
                        DelSQL = "DELETE FROM ESTIMATE_REV_DET WHERE ESTIMATE_NUMBER = " & EstNum & " And EST_COMPONENT_NBR = " & EstCompNum & " And EST_QUOTE_NBR = " & QuoteNum & " And EST_REV_NBR = " & Me.ddRevision.SelectedValue & " And SEQ_NBR In (" & SeqNumber & ")"
                        Using MyConn As New SqlConnection(Session("ConnString"))
                            MyConn.Open()
                            Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                            Dim MyCmd As New SqlCommand(DelSQL, MyConn, MyTrans)
                            Try
                                MyCmd.ExecuteNonQuery()
                                MyTrans.Commit()
                            Catch ex As Exception
                                MyTrans.Rollback()
                            Finally
                                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                            End Try
                        End Using
                    End If
                    Session("DT_EST_QUOTE_FNC") = Nothing
                    Me.RadGridEstimateQuoteDetails.Rebind()
                Case "CancelItem"
                    ClearGridRow(GridDataItem)
                Case "Copy"
                    If GridDataItem IsNot Nothing Then
                        est.GetEstimateQuoteFunctionCopy(EstNum, EstCompNum, QuoteNum, Me.ddRevision.SelectedValue, e.CommandArgument)
                        Me.RadGridEstimateQuoteDetails.Rebind()
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Dim sumQH As Decimal = CType(0.0, Decimal)
    Dim sumEA As Decimal = CType(0.0, Decimal)
    Dim sumMA As Decimal = CType(0.0, Decimal)
    Dim sumGI As Decimal = CType(0.0, Decimal)
    Dim sumTA As Decimal = CType(0.0, Decimal)
    Dim sumLT As Decimal = CType(0.0, Decimal)
    Dim sumCT As Decimal = CType(0.0, Decimal)
    Dim sumCPU As Decimal = CType(0.0, Decimal)
    Dim sumQWC As Decimal = CType(0.0, Decimal)
    Dim sumEMU As Decimal = CType(0.0, Decimal)

    Dim sumQHTotal As Decimal = CType(0.0, Decimal)
    Dim sumEATotal As Decimal = CType(0.0, Decimal)
    Dim sumMATotal As Decimal = CType(0.0, Decimal)
    Dim sumGITotal As Decimal = CType(0.0, Decimal)
    Dim sumTATotal As Decimal = CType(0.0, Decimal)
    Dim sumLTTotal As Decimal = CType(0.0, Decimal)
    Dim sumCTTotal As Decimal = CType(0.0, Decimal)
    Dim sumCPUTotal As Decimal = CType(0.0, Decimal)
    Dim sumQWCTotal As Decimal = CType(0.0, Decimal)
    Dim sumEMUTotal As Decimal = CType(0.0, Decimal)

    Dim ft As String = ""
    Dim fh As String = ""
    Dim fc As String = ""

    Dim dr As SqlDataReader
    Dim drInt As SqlDataReader

    Dim approvalInt As Boolean = False
    Dim approval As Boolean = False

    Private Sub RadGridEstimateQuoteDetails_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEstimateQuoteDetails.ItemDataBound
        Try

            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim ag As New cAgency(Session("ConnString"))
            Dim dt As DataTable
            Dim IsUserRow As Boolean = False
            Dim max As Integer = 0
            Dim agrev As Boolean = False

            max = est.GetEstimateQuoteMaxRevision(Me.EstNum, Me.EstCompNum, Me.QuoteNum)

            agrev = ag.AutoEstRevFlag()


            Select Case e.Item.ItemType
                Case GridItemType.Header

                    sumQH = 0.0
                    sumEA = 0.0
                    sumMA = 0.0
                    sumGI = 0.0
                    sumTA = 0.0
                    sumLT = 0.0
                    sumCT = 0.0
                    sumCPU = 0.0
                    sumQWC = 0.0
                    sumEMU = 0.0

                    sumQHTotal = 0.0
                    sumEATotal = 0.0
                    sumMATotal = 0.0
                    sumGITotal = 0.0
                    sumTATotal = 0.0
                    sumLTTotal = 0.0
                    sumCTTotal = 0.0
                    sumCPUTotal = 0.0
                    sumQWCTotal = 0.0
                    sumEMUTotal = 0.0

                    ft = ""
                    fh = ""
                    fc = ""

                    If Me.ddRevision.SelectedValue <> "" Then

                        drInt = est.GetQuoteApprovalInternal(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, approvalType)
                        dr = est.GetQuoteApproval(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, approvalType)

                    Else

                        drInt = est.GetQuoteApprovalInternal(Me.EstNum, Me.EstCompNum, Me.QuoteNum, 0, approvalType)
                        dr = est.GetQuoteApproval(Me.EstNum, Me.EstCompNum, Me.QuoteNum, 0, approvalType)

                    End If
                    If dr.HasRows = True Then

                        approval = True

                    End If
                    If drInt.HasRows = True Then

                        approvalInt = True

                    End If


                Case GridItemType.GroupHeader

                    Dim strheader As String = e.Item.Cells(1).Text

                    If strheader = "Type: C" Then
                        e.Item.Cells(1).Text = "Type: Client OOP"
                    End If
                    If strheader = "Type: E" Then
                        e.Item.Cells(1).Text = "Type: Employee"
                    End If
                    If strheader = "Type: V" Then
                        e.Item.Cells(1).Text = "Type: Vendor"
                    End If
                    If strheader = "Type: I" Then
                        e.Item.Cells(1).Text = "Type: Income Only"
                    End If
                    If max <> Me.ddRevision.SelectedValue Then
                        e.Item.Cells(1).Visible = False
                    End If
                    If strheader = "Consol: " Then
                        e.Item.Cells(1).Text = "Consol: [None]"
                    End If
                    If e.Item.Expanded = False Then
                        e.Item.Cells(13).Text = "0.00"
                    End If

                Case GridItemType.Item, GridItemType.AlternatingItem, GridItemType.EditItem

                    Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item

                    Try
                        If e.Item.DataItem("IS_USER_ROW").ToString() = "1" Then
                            IsUserRow = True
                        End If
                    Catch ex As Exception
                    End Try
                    Dim CurrentTaskSeq As Integer
                    Try
                        CurrentTaskSeq = CType(dataItem.GetDataKeyValue("SEQ_NBR"), Integer)
                    Catch ex As Exception
                        CurrentTaskSeq = -1
                    End Try

                    Dim Datakey As String = "'" & Me.EstNum.ToString() & "|" & Me.EstCompNum.ToString() & "|" & Me.QuoteNum.ToString() & "|" & Me.RevNum.ToString() & "|" & CurrentTaskSeq & "'"
                    Dim DK As String = Me.EstNum.ToString() & "|" & Me.EstCompNum.ToString() & "|" & Me.QuoteNum.ToString() & "|" & Me.RevNum.ToString() & "|" & CurrentTaskSeq

                    Dim str As System.Web.UI.WebControls.TextBox = e.Item.FindControl("TxtLINE_TOTAL")
                    Dim cb As CheckBox = e.Item.FindControl("ChkCPU")

                    If e.Item.ItemType <> GridItemType.EditItem Then
                        If dataItem.GetDataKeyValue("INCL_CPU") = "1" Then
                            cb.Checked = True
                        End If
                    Else
                        cb.Checked = True
                    End If

                    If str.Text <> "&nbsp;" And str.Text <> "" Then
                        sumLT = sumLT + CDec(str.Text)
                        sumLTTotal = sumLTTotal + CDec(str.Text)
                        If cb.Checked = True Then
                            sumCPU = sumCPU + CDec(str.Text)
                            sumCPUTotal = sumCPUTotal + CDec(str.Text)
                        End If
                    End If
                    str = e.Item.FindControl("TxtEXT_CONTINGENCY")
                    If str.Text <> "&nbsp;" And str.Text <> "" Then
                        sumCT = sumCT + CDec(str.Text)
                        sumCTTotal = sumCTTotal + CDec(str.Text)
                    End If

                    str = e.Item.FindControl("TxtEST_REV_QUANTITY")
                    If str.Text <> "&nbsp;" And str.Text <> "" Then
                        sumQH = sumQH + CDec(str.Text)
                        sumQHTotal = sumQHTotal + CDec(str.Text)
                    End If

                    str = e.Item.FindControl("TxtMARKUP_AMT")
                    If str.Text <> "&nbsp;" And str.Text <> "" Then
                        sumMA = sumMA + CDec(str.Text)
                        sumMATotal = sumMATotal + CDec(str.Text)
                    End If

                    str = e.Item.FindControl("TxtEST_REV_EXT_AMT")
                    If str.Text <> "&nbsp;" And str.Text <> "" Then
                        sumEA = sumEA + CDec(str.Text)
                        sumEATotal = sumEATotal + CDec(str.Text)
                    End If

                    str = e.Item.FindControl("TxtTAX_AMOUNT")
                    If str.Text <> "&nbsp;" And str.Text <> "" Then
                        sumTA = sumTA + CDec(str.Text)
                        sumTATotal = sumTATotal + CDec(str.Text)
                    End If

                    str = e.Item.FindControl("TxtGrossIncome")
                    If str.Text <> "&nbsp;" And str.Text <> "" Then
                        sumGI = sumGI + CDec(str.Text)
                        sumGITotal = sumGITotal + CDec(str.Text)
                    End If

                    str = e.Item.FindControl("TxtEST_FNC_COMMENT")
                    If str.Text <> "&nbsp;" And str.Text <> "" Then
                        str.Text = str.Text.Replace("#apostrophe#", "'")
                    End If

                    str = e.Item.FindControl("TxtEST_REV_SUP_BY_NTE")
                    If str.Text <> "&nbsp;" And str.Text <> "" Then
                        str.Text = str.Text.Replace("#apostrophe#", "'")
                    End If

                    str = e.Item.FindControl("TxtQUOTE_W_CONTINGENCY")
                    If str.Text <> "&nbsp;" And str.Text <> "" Then
                        sumQWC = sumQWC + CDec(str.Text)
                        sumQWCTotal = sumQWCTotal + CDec(str.Text)
                    End If

                    str = e.Item.FindControl("TxtEST_REV_EXT_MU_AMT")
                    If str.Text <> "&nbsp;" And str.Text <> "" Then
                        sumEMU = sumEMU + CDec(str.Text)
                        sumEMUTotal = sumEMUTotal + CDec(str.Text)
                    End If

                    'Dim rcb As RadComboBox = CType(e.Item.FindControl("DropDownListEmployeeTitle"), RadComboBox)
                    'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    '    rcb.DataSource = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadAllActive(DbContext).ToList
                    '    rcb.DataBind()
                    '    rcb.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
                    'End Using

                    'If IsDBNull(dataItem.GetDataKeyValue("EMPLOYEE_TITLE_ID")) = False AndAlso dataItem.GetDataKeyValue("EMPLOYEE_TITLE_ID").ToString <> "" Then
                    '    rcb.SelectedValue = dataItem.GetDataKeyValue("EMPLOYEE_TITLE_ID").ToString
                    'End If

                    Dim tb As System.Web.UI.WebControls.TextBox
                    Dim tb2 As System.Web.UI.WebControls.TextBox
                    Dim tb3 As System.Web.UI.WebControls.TextBox
                    Dim tb4 As System.Web.UI.WebControls.TextBox
                    Dim tb5 As System.Web.UI.WebControls.TextBox
                    Dim tb6 As System.Web.UI.WebControls.TextBox
                    Dim tb7 As System.Web.UI.WebControls.TextBox
                    Dim tb8 As System.Web.UI.WebControls.TextBox
                    Dim tb9 As System.Web.UI.WebControls.TextBox
                    Dim tb10 As System.Web.UI.WebControls.TextBox
                    Dim tb11 As System.Web.UI.WebControls.TextBox
                    Dim tb12 As System.Web.UI.WebControls.TextBox
                    Dim tb13 As System.Web.UI.WebControls.TextBox
                    Dim tb14 As System.Web.UI.WebControls.TextBox
                    Dim tb15 As System.Web.UI.WebControls.TextBox
                    Dim tb16 As System.Web.UI.WebControls.TextBox
                    Dim tb17 As System.Web.UI.WebControls.TextBox
                    Dim tb18 As System.Web.UI.WebControls.TextBox
                    Dim tb19 As System.Web.UI.WebControls.TextBox
                    Dim tb20 As System.Web.UI.WebControls.TextBox
                    Dim tb21 As System.Web.UI.WebControls.TextBox
                    Dim tb22 As System.Web.UI.WebControls.TextBox

                    Dim imgbtn As System.Web.UI.WebControls.ImageButton
                    Dim hf As System.Web.UI.WebControls.HiddenField
                    Dim hf2 As System.Web.UI.WebControls.HiddenField
                    Dim hf3 As System.Web.UI.WebControls.HiddenField
                    Dim hf4 As System.Web.UI.WebControls.HiddenField
                    Dim hf5 As System.Web.UI.WebControls.HiddenField
                    Dim hf6 As System.Web.UI.WebControls.HiddenField
                    Dim hf7 As System.Web.UI.WebControls.HiddenField
                    Dim hf8 As System.Web.UI.WebControls.HiddenField
                    Dim hf9 As System.Web.UI.WebControls.HiddenField
                    Dim hfCPM As System.Web.UI.WebControls.HiddenField
                    Dim hffh As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfFunctionHeadingDesc"), HiddenField)
                    Dim hfc As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfFuncConsolidation"), HiddenField)
                    Dim lbl As System.Web.UI.WebControls.Label
                    Dim hfMU As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfMarkupAmt"), HiddenField)

                    Dim hfield As HtmlInputHidden
                    Dim hfield2 As HtmlInputHidden
                    Dim hfield3 As HtmlInputHidden
                    Dim hfield4 As HtmlInputHidden
                    Dim hfield5 As HtmlInputHidden
                    Dim hfieldCPM As HtmlInputHidden

                    Dim AddCommentsDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivAddComments")
                    'Dim LookupFunctionCodeDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivLookupFunctionCode")
                    'Dim LookupSuppliedByDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivLookupSuppliedBy")
                    'Dim LookupTaxCodeDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivLookupTaxCode")
                    Dim LookupCopyFunctionDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivCopyFunction")
                    Dim LookupDeleteFunctionDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivDeleteFunction")
                    Dim FlagColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")

                    Dim AddCommentsImageButton As System.Web.UI.WebControls.ImageButton = CType(e.Item.FindControl("ImageButtonAddComments"), ImageButton)
                    'Dim LookupFunctionCodeImageButton As System.Web.UI.WebControls.ImageButton = CType(e.Item.FindControl("ImageButtonLookupFunctionCode"), ImageButton)
                    'Dim LookupSuppliedByImageButton As System.Web.UI.WebControls.ImageButton = CType(e.Item.FindControl("ImageButtonLookupSuppliedBy"), ImageButton)
                    'Dim LookupTaxCodeImageButton As System.Web.UI.WebControls.ImageButton = CType(e.Item.FindControl("ImageButtonLookupTaxCode"), ImageButton)

                    Dim FlagImage As WebControls.Image = e.Item.FindControl("ImageFlag")

                    tb = CType(e.Item.FindControl("TxtFunctionCode"), TextBox)
                    tb2 = CType(e.Item.FindControl("TxtFNC_DESCRIPTION"), TextBox)
                    tb3 = CType(e.Item.FindControl("TxtEST_REV_RATE"), TextBox)
                    hf = CType(e.Item.FindControl("HfFunctionType"), HiddenField)
                    hf2 = CType(e.Item.FindControl("HfFNC_DESCRIPTION"), HiddenField)

                    tb6 = e.Item.FindControl("TxtEST_REV_EXT_AMT")
                    tb5 = e.Item.FindControl("TxtMARKUP_AMT")
                    tb4 = e.Item.FindControl("TxtEST_REV_COMM_PCT")
                    tb9 = e.Item.FindControl("TxtEST_REV_CONT_PCT")
                    tb14 = e.Item.FindControl("TxtEST_REV_QUANTITY")
                    tb10 = e.Item.FindControl("TxtTaxCode")
                    tb15 = e.Item.FindControl("TxtEST_REV_SUP_BY_CDE")

                    hf7 = e.Item.FindControl("HfLineTotal")
                    hf5 = e.Item.FindControl("HfContingency")
                    hf6 = e.Item.FindControl("HfMUContingency")
                    hf2 = e.Item.FindControl("HfTaxResale")
                    hf3 = e.Item.FindControl("HfTaxComm")
                    hf4 = e.Item.FindControl("HfTaxCommOnly")

                    ft = hf.Value
                    fh = hffh.Value
                    fc = hfc.Value

                    'If IsUserRow = True Then

                    Try

                        Session("EstFunctionEstJobNum") = Me.JobNum
                        Session("EstFunctionEstJobCompNum") = Me.JobCompNum
                        Session("EstFunctionEstClient") = Me.hfClientCode.Value
                        Session("EstFunctionEstDivision") = Me.hfDivisionCode.Value
                        Session("EstFunctionEstProduct") = Me.hfProductCode.Value
                        Session("EstFunctionEstSalesClass") = Me.hfSalesClass.Value
                        'LookupFunctionCodeImageButton.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=funcEst&control=" & tb.ClientID & "&control2=" & hf.ClientID & "&control3=" & tb2.ClientID & "&control4=" & hf2.ClientID & "&type=funcEst');return false;")
                        'tb.Attributes.Add("ondblclick", "OpenRadWindowLookup('LookUp.aspx?form=funcEst&control=" & tb.ClientID & "&control2=" & hf.ClientID & "&control3=" & tb2.ClientID & "&control4=" & hf2.ClientID & "&type=funcEst');return false;")

                    Catch ex As Exception
                    End Try

                    'End If

                    Dim fcode As String = tb.Text
                    Session("EstFunctionEstFunctionCodeSB") = tb.Text

                    tb = e.Item.FindControl("TxtTaxCode")
                    tb2 = e.Item.FindControl("TxtTAX_AMOUNT")
                    tb3 = e.Item.FindControl("TxtEST_REV_EXT_AMT")
                    tb5 = e.Item.FindControl("TxtMARKUP_AMT")
                    tb4 = e.Item.FindControl("TxtEST_REV_COMM_PCT")
                    tb9 = e.Item.FindControl("TxtEST_REV_CONT_PCT")
                    tb14 = e.Item.FindControl("TxtEST_REV_QUANTITY")

                    hfield = e.Item.FindControl("HiddenFieldTaxComm")
                    hfield2 = e.Item.FindControl("HiddenFieldTaxCommOnly")
                    hfield3 = e.Item.FindControl("HiddenFieldTaxResale")


                    If hf.Value = "C" Then

                        'LookupTaxCodeImageButton.Attributes.Add("onclick", "return false;")
                        'LookupTaxCodeImageButton.Enabled = False
                        tb.Attributes.Add("ondblclick", "return false")

                    Else

                        'LookupTaxCodeImageButton.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=taxcodes&dk=" & DK & "&control=" & tb.ClientID & "&control2=" & tb2.ClientID & "&type=taxcodes&extamt=' + document.forms[0]." & tb3.ClientID & ".value + '&line=' + document.forms[0]." & hf7.ClientID & ".value + '&contamt=' + document.forms[0]." & tb9.ClientID & ".value + '&mucontamt=' + document.forms[0]." & hf6.ClientID & ".value + '&muamt=' + document.forms[0]." & tb4.ClientID & ".value + '&taxr=' + document.forms[0]." & hf2.ClientID & ".value + '&taxc=' + document.forms[0]." & hf3.ClientID & ".value + '&taxco=' + document.forms[0]." & hf4.ClientID & ".value + '&functype=' + document.forms[0]." & hf.ClientID & ".value);return false;")
                        'tb.Attributes.Add("ondblclick", "OpenRadWindowLookup('LookUp.aspx?form=taxcodes&dk=" & DK & "&control=" & tb.ClientID & "&control2=" & tb2.ClientID & "&type=taxcodes&extamt=' + document.forms[0]." & tb3.ClientID & ".value + '&line=' + document.forms[0]." & hf7.ClientID & ".value + '&contamt=' + document.forms[0]." & tb9.ClientID & ".value + '&mucontamt=' + document.forms[0]." & hf6.ClientID & ".value + '&muamt=' + document.forms[0]." & tb4.ClientID & ".value + '&taxr=' + document.forms[0]." & hf2.ClientID & ".value + '&taxc=' + document.forms[0]." & hf3.ClientID & ".value + '&taxco=' + document.forms[0]." & hf4.ClientID & ".value + '&functype=' + document.forms[0]." & hf.ClientID & ".value);return false;")

                    End If

                    Session("EstFunctionEstJobNumSB") = Me.JobNum
                    Session("EstFunctionEstJobCompNumSB") = Me.JobCompNum
                    Session("EstFunctionEstClientSB") = Me.hfClientCode.Value
                    Session("EstFunctionEstDivisionSB") = Me.hfDivisionCode.Value
                    Session("EstFunctionEstProductSB") = Me.hfProductCode.Value
                    Session("EstFunctionEstSalesClassSB") = Me.hfSalesClass.Value
                    Session("EstFunctionEstFunctionSB") = fcode
                    Session("EstFunctionEstQuantitySB") = tb14.Text
                    Session("EstFunctionTaxCode") = tb.Text
                    Session("EstFunctionTaxComm") = hfield.Value
                    Session("EstFunctionTaxCommOnly") = hfield2.Value
                    Session("EstFunctionEstMarkupPct") = tb4.Text

                    tb = e.Item.FindControl("TxtEST_REV_SUP_BY_CDE")
                    tb10 = e.Item.FindControl("TxtTaxCode")
                    tb2 = e.Item.FindControl("TxtFunctionCode")
                    lbl = e.Item.FindControl("LblFunctionCode")
                    hf2 = e.Item.FindControl("HfSuppliedByCode")

                    If e.Item.ItemType = GridItemType.EditItem Then
                        Try

                            'LookupSuppliedByImageButton.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=suppliedby&dk=" & DK & "&control=" & tb.ClientID & "&type=suppliedby&functype=' + document.forms[0]." & hf.ClientID & ".value + '&funccode=' + document.forms[0]." & tb2.ClientID & ".value + '&qty=' + document.forms[0]." & tb14.ClientID & ".value + '&contpct=' + document.forms[0]." & tb9.ClientID & ".value + '&taxcode=' + document.forms[0]." & tb10.ClientID & ".value + '&tc=' + document.forms[0]." & hf3.ClientID & ".value + '&tco=' + document.forms[0]." & hf4.ClientID & ".value + '&markuppct=' + document.forms[0]." & tb4.ClientID & ".value);return false;")
                            'tb.Attributes.Add("ondblclick", "OpenRadWindowLookup('LookUp.aspx?form=suppliedby&dk=" & DK & "&control=" & tb.ClientID & "&type=suppliedby&functype=' + document.forms[0]." & hf.ClientID & ".value + '&funccode=' + document.forms[0]." & tb2.ClientID & ".value + '&qty=' + document.forms[0]." & tb14.ClientID & ".value + '&contpct=' + document.forms[0]." & tb9.ClientID & ".value + '&taxcode=' + document.forms[0]." & tb10.ClientID & ".value + '&tc=' + document.forms[0]." & hf3.ClientID & ".value + '&tco=' + document.forms[0]." & hf4.ClientID & ".value + '&markuppct=' + document.forms[0]." & tb4.ClientID & ".value);return false;")

                        Catch ex As Exception
                        End Try
                    Else
                        If hf.Value = "I" Or hf.Value = "C" Then

                            'LookupSuppliedByImageButton.Attributes.Add("onclick", "alert('Supplied By can only be specified for employee time or vendor functions');")
                            tb.Attributes.Add("ondblclick", "ShowMessage('Supplied By can only be specified for employee time or vendor functions');")

                        Else

                            'LookupSuppliedByImageButton.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=suppliedby&funccode=" & fcode & "&dk=" & DK & "&control=" & tb.ClientID & "&type=suppliedby&functype=' + document.forms[0]." & hf.ClientID & ".value + '&qty=' + document.forms[0]." & tb14.ClientID & ".value + '&contpct=' + document.forms[0]." & tb9.ClientID & ".value + '&taxcode=' + document.forms[0]." & tb10.ClientID & ".value + '&tc=' + document.forms[0]." & hf3.ClientID & ".value + '&tco=' + document.forms[0]." & hf4.ClientID & ".value + '&markuppct=' + document.forms[0]." & tb4.ClientID & ".value);return false;")
                            'tb.Attributes.Add("ondblclick", "OpenRadWindowLookup('LookUp.aspx?form=suppliedby&funccode=" & fcode & "&dk=" & DK & "&control=" & tb.ClientID & "&type=suppliedby&functype=' + document.forms[0]." & hf.ClientID & ".value + '&qty=' + document.forms[0]." & tb14.ClientID & ".value + '&contpct=' + document.forms[0]." & tb9.ClientID & ".value + '&taxcode=' + document.forms[0]." & tb10.ClientID & ".value + '&tc=' + document.forms[0]." & hf3.ClientID & ".value + '&tco=' + document.forms[0]." & hf4.ClientID & ".value + '&markuppct=' + document.forms[0]." & tb4.ClientID & ".value);return false;")

                        End If

                    End If

                    DirectCast(dataItem("colEST_REV_SUP_BY_CDE").FindControl("TxtEST_REV_SUP_BY_CDE"), TextBox).Attributes.Add("onblur", "DataChangeSuppliedByCode(" & Datakey & "," & tb.ClientID & ",," &
                                                                                                                               hf2.ClientID & "," & hf.ClientID & ",this.value);")

                    tb = e.Item.FindControl("TxtEST_REV_QUANTITY") 'Quantity/Hours
                    tb2 = e.Item.FindControl("TxtEST_REV_RATE") 'Rate
                    tb3 = e.Item.FindControl("TxtEST_REV_EXT_AMT") 'Extended Amount
                    tb4 = e.Item.FindControl("TxtEST_REV_COMM_PCT") 'Markup Percent
                    tb5 = e.Item.FindControl("TxtMARKUP_AMT") 'Markup Amount
                    tb6 = e.Item.FindControl("TxtTaxCode")
                    tb7 = e.Item.FindControl("TxtTAX_AMOUNT")
                    tb8 = e.Item.FindControl("TxtLINE_TOTAL") 'Functional Total
                    tb9 = e.Item.FindControl("TxtEST_REV_CONT_PCT") 'Contingency Percent
                    tb10 = e.Item.FindControl("TxtEXT_CONTINGENCY") 'Contingency Amount
                    tb11 = e.Item.FindControl("TxtGrossIncome") 'Gross income
                    tb15 = e.Item.FindControl("TxtFunctionCode")
                    tb16 = e.Item.FindControl("TxtQUOTE_W_CONTINGENCY")
                    tb17 = e.Item.FindControl("TxtFunctionCode")
                    tb18 = e.Item.FindControl("TxtEST_REV_SUP_BY_CDE")
                    tb20 = e.Item.FindControl("TxtEST_REV_EXT_MU_AMT")

                    hf8 = e.Item.FindControl("HfSuppliedByCode")
                    hf2 = e.Item.FindControl("HfTaxStatePct")
                    hf3 = e.Item.FindControl("HfTaxCountyPct")
                    hf4 = e.Item.FindControl("HfTaxCityPct")
                    hf5 = e.Item.FindControl("HfContingency")
                    hfCPM = e.Item.FindControl("HfCPM")
                    hf6 = e.Item.FindControl("HfTaxComm")
                    hf7 = e.Item.FindControl("HfTaxCommOnly")
                    hf9 = e.Item.FindControl("HfFunctionCode")

                    Dim taxstatepct As Decimal = 0.0
                    Dim taxcitypct As Decimal = 0.0
                    Dim taxcountypct As Decimal = 0.0
                    Dim taxresale As Decimal = 0.0

                    hfield = e.Item.FindControl("HiddenFieldTaxComm")
                    hfield2 = e.Item.FindControl("HiddenFieldTaxCommOnly")
                    hfield3 = e.Item.FindControl("HiddenFieldTaxStatePct")
                    hfield4 = e.Item.FindControl("HiddenFieldTaxCountyPct")
                    hfield5 = e.Item.FindControl("HiddenFieldTaxCityPct")
                    hfieldCPM = e.Item.FindControl("HiddenFieldCPM")

                    If hfield3.Value <> "" Then
                        taxstatepct = CDec(hfield3.Value)
                    End If
                    If hfield4.Value <> "" Then
                        taxcountypct = CDec(hfield4.Value)
                    End If
                    If hfield5.Value <> "" Then
                        taxcitypct = CDec(hfield5.Value)
                    End If

                    tb21 = e.Item.FindControl("TxtEMPLOYEE_TITLE")

                    If e.Item.ItemType <> GridItemType.EditItem Then
                        tb17.Attributes.Add("onblur", "DataChangeQty(" & Datakey & "," & tb.ClientID & "," & tb2.ClientID & "," & hfieldCPM.ClientID & "," & tb4.ClientID & "," & tb6.ClientID & "," & tb9.ClientID & "," &
                                      hfield.ClientID & "," & hfield2.ClientID & "," & hf.ClientID & "," & tb3.ClientID & "," & tb5.ClientID & "," & tb17.ClientID & "," & hf8.ClientID & "," & tb21.ClientID & ",'function',this.value);")
                        tb21.Attributes.Add("onblur", "DataChangeQty(" & Datakey & "," & tb.ClientID & "," & tb2.ClientID & "," & hfieldCPM.ClientID & "," & tb4.ClientID & "," & tb6.ClientID & "," & tb9.ClientID & "," &
                                      hfield.ClientID & "," & hfield2.ClientID & "," & hf.ClientID & "," & tb3.ClientID & "," & tb5.ClientID & "," & tb17.ClientID & "," & hf8.ClientID & "," & tb21.ClientID & ",'emptitle',this.value);")

                    End If



                    Dim JavascriptFooterFunction As String = ""

                    If Me._GridIsGrouped = True Then

                        JavascriptFooterFunction = ""

                    Else

                        JavascriptFooterFunction = "SumItUpQuantityHours();"

                    End If
                    tb.Attributes.Add("onkeyup", "CalcRateEst('" & tb.ClientID & "','" & tb2.ClientID & "','" & tb3.ClientID & "');Multiply('" & tb.ClientID & "','" & tb2.ClientID & "','" &
                                      hfieldCPM.ClientID & "','" & tb3.ClientID & "');MultiplyPerc('" & tb3.ClientID & "','" & tb4.ClientID & "','" & tb5.ClientID & "','" & hfMU.ClientID & "');CalcTaxAmount('" &
                                      tb3.ClientID & "','" & tb7.ClientID & "','" & hfield3.ClientID & "','" & hfield4.ClientID & "','" & hfield5.ClientID & "','" & hfield.ClientID & "','" & hfield2.ClientID & "','" &
                                      tb5.ClientID & "');AddTotal('" & tb3.ClientID & "','" & tb5.ClientID & "','" & tb7.ClientID & "','" & tb8.ClientID & "');CalcContAmount('" & tb3.ClientID & "','" &
                                      tb9.ClientID & "','" & tb10.ClientID & "','" & hf5.ClientID & "','" & hfield3.ClientID & "','" & hfield4.ClientID & "','" & hfield5.ClientID & "','" & tb5.ClientID & "','" &
                                      hfield.ClientID & "','" & hfield2.ClientID & "');AddTotalExtMU('" & tb3.ClientID & "','" & tb5.ClientID & "','" & tb20.ClientID & "');AddGrossIncome('" & tb3.ClientID & "','" &
                                      tb5.ClientID & "','" & hf.ClientID & "','" & tb11.ClientID & "');AddTotalQuoteContingency('" & tb3.ClientID & "','" & tb5.ClientID & "','" & tb7.ClientID & "','" & tb10.ClientID & "','" & tb16.ClientID & "');" & JavascriptFooterFunction)
                    If e.Item.ItemType <> GridItemType.EditItem Then
                        tb.Attributes.Add("onblur", "DataChangeQty(" & Datakey & "," & tb.ClientID & "," & tb2.ClientID & "," & hfieldCPM.ClientID & "," & tb4.ClientID & "," & tb6.ClientID & "," & tb9.ClientID & "," &
                                      hfield.ClientID & "," & hfield2.ClientID & "," & hf.ClientID & "," & tb3.ClientID & "," & tb5.ClientID & "," & hf9.ClientID & "," & hf8.ClientID & "," & tb21.ClientID & ",'quantity',this.value);")
                    End If

                    If Me._GridIsGrouped = True Then

                        JavascriptFooterFunction = ""

                    Else

                        JavascriptFooterFunction = "OnRateChange();"

                    End If
                    tb2.Attributes.Add("onkeyup", "Multiply('" & tb.ClientID & "','" & tb2.ClientID & "','" & hfieldCPM.ClientID & "','" & tb3.ClientID & "');MultiplyPerc('" & tb3.ClientID & "','" &
                                                    tb4.ClientID & "','" & tb5.ClientID & "','" & hfMU.ClientID & "');CalcTaxAmount('" & tb3.ClientID & "','" & tb7.ClientID & "','" & hfield3.ClientID & "','" & hfield4.ClientID & "','" & hfield5.ClientID &
                                                    "','" & hfield.ClientID & "','" & hfield2.ClientID & "','" & tb5.ClientID & "');AddTotal('" & tb3.ClientID & "','" & tb5.ClientID & "','" & tb7.ClientID & "','" & tb8.ClientID &
                                                    "');CalcContAmount('" & tb3.ClientID & "','" & tb9.ClientID & "','" & tb10.ClientID & "','" & hf5.ClientID & "','" & hfield3.ClientID & "','" & hfield4.ClientID & "','" & hfield5.ClientID & "','" &
                                                    tb5.ClientID & "','" & hfield.ClientID & "','" & hfield2.ClientID & "');AddGrossIncome('" & tb3.ClientID & "','" & tb5.ClientID & "','" & hf.ClientID & "','" &
                                                    tb11.ClientID & "');AddTotalExtMU('" & tb3.ClientID & "','" & tb5.ClientID & "','" & tb20.ClientID & "');AddTotalQuoteContingency('" & tb3.ClientID & "','" & tb5.ClientID & "','" & tb7.ClientID & "','" & tb10.ClientID & "','" & tb16.ClientID & "');" & JavascriptFooterFunction)
                    If e.Item.ItemType <> GridItemType.EditItem Then
                        tb2.Attributes.Add("onblur", "DataChangeQty(" & Datakey & "," & tb.ClientID & "," & tb2.ClientID & "," & hfieldCPM.ClientID & "," & tb4.ClientID & "," & tb6.ClientID & "," & tb9.ClientID & "," &
                                       hfield.ClientID & "," & hfield2.ClientID & "," & hf.ClientID & "," & tb3.ClientID & "," & tb5.ClientID & "," & hf9.ClientID & "," & hf8.ClientID & "," & tb21.ClientID & ",'rate',this.value);")
                    End If


                    If Me._GridIsGrouped = True Then

                        JavascriptFooterFunction = ""

                    Else

                        JavascriptFooterFunction = "OnMarkupPercentChange();"

                    End If
                    tb4.Attributes.Add("onkeyup", "MultiplyPerc('" & tb3.ClientID & "','" & tb4.ClientID & "','" & tb5.ClientID & "','" & hfMU.ClientID & "');CalcTaxAmount('" & tb3.ClientID & "','" & tb7.ClientID & "','" & hfield3.ClientID &
                                                       "','" & hfield4.ClientID & "','" & hfield5.ClientID & "','" & hfield.ClientID & "','" & hfield2.ClientID & "','" & tb5.ClientID & "');AddTotal('" & tb3.ClientID & "','" & tb5.ClientID & "','" &
                                                       tb7.ClientID & "','" & tb8.ClientID & "');CalcContAmount('" & tb3.ClientID & "','" & tb9.ClientID & "','" & tb10.ClientID & "','" & hf5.ClientID & "','" & hfield3.ClientID & "','" &
                                                       hfield4.ClientID & "','" & hfield5.ClientID & "','" & tb5.ClientID & "','" & hfield.ClientID & "','" & hfield2.ClientID & "');AddGrossIncome('" & tb3.ClientID & "','" & tb5.ClientID & "','" & hf.ClientID &
                                                       "','" & tb11.ClientID & "');AddTotalExtMU('" & tb3.ClientID & "','" & tb5.ClientID & "','" & tb20.ClientID & "');AddTotalQuoteContingency('" & tb3.ClientID & "','" & tb5.ClientID & "','" & tb7.ClientID & "','" & tb10.ClientID & "','" & tb16.ClientID & "');" & JavascriptFooterFunction)
                    If e.Item.ItemType <> GridItemType.EditItem Then
                        tb4.Attributes.Add("onblur", "DataChangeQty(" & Datakey & "," & tb.ClientID & "," & tb2.ClientID & "," & hfieldCPM.ClientID & "," & tb4.ClientID & "," & tb6.ClientID & "," & tb9.ClientID & "," & hfield.ClientID & "," &
                                      hfield2.ClientID & "," & hf.ClientID & "," & tb3.ClientID & "," & tb5.ClientID & "," & hf9.ClientID & "," & hf8.ClientID & "," & tb21.ClientID & ",'markuppct',this.value);")
                    End If

                    If Me._GridIsGrouped = True Then

                        JavascriptFooterFunction = ""

                    Else

                        JavascriptFooterFunction = "SumItUpMarkupAmount();"

                    End If
                    tb5.Attributes.Add("onkeyup", "CalcPerc('" & tb5.ClientID & "','" & tb3.ClientID & "','" & tb4.ClientID & "','" & hfMU.ClientID & "');AddTotal('" & tb3.ClientID & "','" & tb5.ClientID & "','" & tb7.ClientID & "','" &
                                                      tb8.ClientID & "');AddGrossIncome('" & tb3.ClientID & "','" & tb5.ClientID & "','" & hf.ClientID & "','" & tb11.ClientID & "');AddTotalExtMU('" & tb3.ClientID & "','" & tb5.ClientID & "','" & tb20.ClientID & "');AddTotalQuoteContingency('" & tb3.ClientID & "','" & tb5.ClientID & "','" & tb7.ClientID & "','" & tb10.ClientID & "','" & tb16.ClientID & "');" & JavascriptFooterFunction)
                    If e.Item.ItemType <> GridItemType.EditItem Then
                        tb5.Attributes.Add("onblur", "DataChangeQty(" & Datakey & "," & tb.ClientID & "," & tb2.ClientID & "," & hfieldCPM.ClientID & "," & tb4.ClientID & "," & tb6.ClientID & "," &
                                       tb9.ClientID & "," & hfield.ClientID & "," & hfield2.ClientID & "," & hf.ClientID & "," & tb3.ClientID & "," & tb5.ClientID & "," & hf9.ClientID & "," & hf8.ClientID & "," & tb21.ClientID & ",'markupamt',this.value);")
                    End If


                    If Me._GridIsGrouped = True Then

                        JavascriptFooterFunction = ""

                    Else

                        JavascriptFooterFunction = "SumItUpContingencyAmount();"

                    End If
                    tb9.Attributes.Add("onkeyup", "CalcContAmount('" & tb3.ClientID & "','" & tb9.ClientID & "','" & tb10.ClientID & "','" & hf5.ClientID & "','" & hfield3.ClientID & "','" &
                                                     hfield4.ClientID & "','" & hfield5.ClientID & "','" & tb5.ClientID & "','" & hfield.ClientID & "','" & hfield2.ClientID & "');AddTotalExtMU('" & tb3.ClientID & "','" & tb5.ClientID & "','" & tb20.ClientID & "');AddTotalQuoteContingency('" & tb3.ClientID & "','" & tb5.ClientID & "','" & tb7.ClientID & "','" & tb10.ClientID & "','" & tb16.ClientID & "');" & JavascriptFooterFunction)
                    If e.Item.ItemType <> GridItemType.EditItem Then
                        tb9.Attributes.Add("onblur", "DataChangeQty(" & Datakey & "," & tb.ClientID & "," &
                                        tb2.ClientID & "," & hfieldCPM.ClientID & "," & tb4.ClientID & "," & tb6.ClientID & "," &
                                        tb9.ClientID & "," & hfield.ClientID & "," & hfield2.ClientID & "," & hf.ClientID & "," &
                                        tb3.ClientID & "," & tb5.ClientID & "," & hf9.ClientID & "," & hf8.ClientID & "," & tb21.ClientID & ",'contpct',this.value);")
                    End If

                    If Me._GridIsGrouped = True Then

                        JavascriptFooterFunction = ""

                    Else

                        JavascriptFooterFunction = "SumItUpExtendedAmount();"

                    End If
                    tb3.Attributes.Add("onkeyup", "CalcRateOverrideEst('" & tb.ClientID & "','" & tb2.ClientID & "','" & tb3.ClientID & "','" & hfieldCPM.ClientID & "');MultiplyPerc('" &
                                                      tb3.ClientID & "','" & tb4.ClientID & "','" & tb5.ClientID & "','" & hfMU.ClientID & "');CalcTaxAmount('" & tb3.ClientID & "','" & tb7.ClientID & "','" & hfield3.ClientID & "','" &
                                                      hfield4.ClientID & "','" & hfield5.ClientID & "','" & hfield.ClientID & "','" & hfield2.ClientID & "','" & tb5.ClientID & "');AddTotal('" & tb3.ClientID & "','" &
                                                      tb5.ClientID & "','" & tb7.ClientID & "','" & tb8.ClientID & "');AddGrossIncome('" & tb3.ClientID & "','" & tb5.ClientID & "','" & hf.ClientID & "','" &
                                                      tb11.ClientID & "');CalcContAmount('" & tb3.ClientID & "','" & tb9.ClientID & "','" & tb10.ClientID & "','" & hf5.ClientID & "','" & hfield3.ClientID & "','" &
                                                      hfield4.ClientID & "','" & hfield5.ClientID & "','" & tb5.ClientID & "','" & hfield.ClientID & "','" & hfield2.ClientID & "');AddTotalExtMU('" & tb3.ClientID & "','" & tb5.ClientID & "','" & tb20.ClientID & "');AddTotalQuoteContingency('" & tb3.ClientID & "','" & tb5.ClientID & "','" & tb7.ClientID & "','" & tb10.ClientID & "','" & tb16.ClientID & "');" & JavascriptFooterFunction)
                    If e.Item.ItemType <> GridItemType.EditItem Then
                        tb3.Attributes.Add("onblur", "DataChangeQty(" & Datakey & "," & tb.ClientID & "," & tb2.ClientID & "," & hfieldCPM.ClientID & "," & tb4.ClientID & "," & tb6.ClientID & "," &
                                       tb9.ClientID & "," & hfield.ClientID & "," & hfield2.ClientID & "," & hf.ClientID & "," & tb3.ClientID & "," & tb5.ClientID & "," & hf9.ClientID & "," & hf8.ClientID & "," & tb21.ClientID & ",'extamt',this.value);")

                    End If

                    tb6.Attributes.Add("onkeyup", "CalcTaxAmount('" & tb3.ClientID & "','" & tb7.ClientID & "','" & hfield3.ClientID &
                                                       "','" & hfield4.ClientID & "','" & hfield5.ClientID & "','" & hfield.ClientID & "','" & hfield2.ClientID & "','" & tb5.ClientID & "');AddTotal('" & tb3.ClientID & "','" & tb5.ClientID & "','" &
                                                       tb7.ClientID & "','" & tb8.ClientID & "');CalcContAmount('" & tb3.ClientID & "','" & tb9.ClientID & "','" & tb10.ClientID & "','" & hf5.ClientID & "','" & hfield3.ClientID & "','" &
                                                       hfield4.ClientID & "','" & hfield5.ClientID & "','" & tb5.ClientID & "','" & hfield.ClientID & "','" & hfield2.ClientID & "');AddGrossIncome('" & tb3.ClientID & "','" & tb5.ClientID & "','" & hf.ClientID &
                                                       "','" & tb11.ClientID & "');AddTotalQuoteContingency('" & tb3.ClientID & "','" & tb5.ClientID & "','" & tb7.ClientID & "','" & tb10.ClientID & "','" & tb16.ClientID & "');" & JavascriptFooterFunction)

                    If e.Item.ItemType <> GridItemType.EditItem Then
                        'DirectCast(dataItem("colEST_FNC_COMMENT").FindControl("TxtEST_FNC_COMMENT"), TextBox).Attributes.Add("ondblclick", "OpenRadWindow('Estimating_FunctionComments.aspx?EstNum=" & EstNum & "&EstComp=" & EstCompNum & "&QuoteNum=" & QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&SeqNum=" & dataItem.GetDataKeyValue("SEQ_NBR") & "&dk=" & Datakey & "&control=" & tb.ClientID & "&type=suppliedby&functype=' + document.forms[0]." & hf.ClientID & ".value + '&qty=' + document.forms[0]." & tb14.ClientID & ".value + '&contpct=' + document.forms[0]." & tb9.ClientID & ".value + '&taxcode=' + document.forms[0]." & tb10.ClientID & ".value + '&tc=' + document.forms[0]." & hf3.ClientID & ".value + '&tco=' + document.forms[0]." & hf4.ClientID & ".value + '&markuppct=' + document.forms[0]." & tb4.ClientID & ".value);return false;")
                        DirectCast(dataItem("colEST_FNC_COMMENT").FindControl("TxtEST_FNC_COMMENT"), TextBox).Attributes.Add("onblur", "DataChange(" & Datakey & ",'txt',this.name,this.value);")
                        DirectCast(dataItem("colEST_REV_SUP_BY_NTE").FindControl("TxtEST_REV_SUP_BY_NTE"), TextBox).Attributes.Add("onblur", "DataChange(" & Datakey & ",'txt',this.name,this.value);")

                        tb6.Attributes.Add("onblur", "DataChangeQty(" & Datakey & "," & tb.ClientID & "," & tb2.ClientID & "," & hfieldCPM.ClientID & "," & tb4.ClientID & "," & tb6.ClientID & "," & tb9.ClientID & "," & hfield.ClientID & "," & hfield2.ClientID & "," & hf.ClientID & "," & tb3.ClientID & "," & tb5.ClientID & "," & hf9.ClientID & "," & hf8.ClientID & "," & tb21.ClientID & ",'taxcode',this.value);")

                        DirectCast(dataItem("colEST_REV_SUP_BY_CDE").FindControl("TxtEST_REV_SUP_BY_CDE"), TextBox).Attributes.Add("onblur", "DataChangeQty(" & Datakey & "," & tb.ClientID & "," & tb2.ClientID & "," & hfieldCPM.ClientID & "," & tb4.ClientID & "," & tb6.ClientID & "," & tb9.ClientID & "," & hfield.ClientID & "," & hfield2.ClientID & "," & hf.ClientID & "," & tb3.ClientID & "," & tb5.ClientID & "," & hf9.ClientID & "," & tb18.ClientID & "," & tb21.ClientID & ",'suppliedby',this.value);")
                        DirectCast(dataItem("colCPU").FindControl("ChkCPU"), CheckBox).InputAttributes.Add("onclick", "DataChangeCheckboxCPU(" & Datakey & ",'" & DirectCast(dataItem("colCPU").FindControl("ChkCPU"), CheckBox).ClientID & "');")
                    End If

                    If e.Item.ItemType <> GridItemType.EditItem Then
                        tb.Text = String.Format("{0:#,##0.00}", CDec(tb.Text))
                        tb2.Text = String.Format("{0:#,##0.0000}", CDec(tb2.Text))
                        tb3.Text = String.Format("{0:#,##0.00}", CDec(tb3.Text))
                        tb7.Text = String.Format("{0:#,##0.00}", CDec(tb7.Text))
                        tb5.Text = String.Format("{0:#,##0.00}", CDec(tb5.Text))
                        tb8.Text = String.Format("{0:#,##0.00}", CDec(tb8.Text))
                        tb10.Text = String.Format("{0:#,##0.00}", CDec(tb10.Text))
                        tb16.Text = String.Format("{0:#,##0.00}", CDec(tb16.Text))

                        'Calculate Gross Income based on Function Type
                        tb = e.Item.FindControl("TxtGrossIncome")
                        tb22 = e.Item.FindControl("TxtEST_REV_QUANTITY")
                        If hf.Value = "E" Or hf.Value = "I" Then

                            tb.Text = String.Format("{0:#,##0.00}", CDec(tb3.Text) + CDec(tb5.Text))

                        End If
                        If hf.Value = "V" Then

                            tb.Text = String.Format("{0:#,##0.00}", CDec(tb5.Text))

                            'If hf8.Value <> "" Then



                            'End If

                        End If
                        If hf.Value = "C" Then

                            tb.Text = "0.00"

                        End If
                        If tb.Text <> "" And tb.Text <> "&nbsp;" Then

                            sumGI = sumGI + CDec(tb.Text)
                            sumGITotal = sumGITotal + CDec(tb.Text)

                        End If

                        tb2.Attributes.Add("ondblclick", "OpenRadWindowLookup('LookUp_VendorPrice.aspx?from=est&caller=Estimating_Quote.aspx&dk=" & DK & "&RateControl=" & tb2.ClientID & "&ExtControl=" & tb3.ClientID & "&Qty=' + document.forms[0]." & tb22.ClientID & ".value + '&Vendor=' + document.forms[0]." & hf8.ClientID & ".value);return false;")
                        tb2.Attributes.Add("onclick", "select();")

                    Else

                        Dim TextboxPhase As System.Web.UI.WebControls.TextBox = e.Item.FindControl("TxtPhase")
                        TextboxPhase.Visible = False

                        'Dim chk As CheckBox = CType(dataItem("ColumnClientSelect").Controls(0), CheckBox)
                        'chk.Visible = False

                        AddCommentsDiv.Visible = False

                    End If

                    If e.Item.ItemType <> GridItemType.EditItem Then
                        If hf.Value <> "E" Then
                            tb21.ReadOnly = True
                            tb21.Attributes.Clear()
                        End If
                    End If

                    tb = e.Item.FindControl("TxtEST_REV_QUANTITY")
                    tb12 = e.Item.FindControl("TxtEST_REV_SUP_BY_CDE")
                    tb13 = e.Item.FindControl("TxtEST_REV_SUP_BY_NTE")
                    tb14 = e.Item.FindControl("TxtEST_FNC_COMMENT")

                    Try

                        Dim TbFncCode As System.Web.UI.WebControls.TextBox = CType(e.Item.FindControl("TxtFunctionCode"), TextBox)
                        Dim LbFncCode As System.Web.UI.WebControls.Label = CType(e.Item.FindControl("LblFunctionCode"), Label)

                        If IsUserRow = True Then

                            TbFncCode.Visible = True
                            LbFncCode.Visible = False
                            'AdvantageFramework.Web.Presentation.Controls.DivHide(LookupTaxCodeDiv)
                            AdvantageFramework.Web.Presentation.Controls.DivHide(AddCommentsDiv)
                            tb.ReadOnly = True
                            tb2.ReadOnly = True
                            tb3.ReadOnly = True
                            tb4.ReadOnly = True
                            tb5.ReadOnly = True
                            tb6.ReadOnly = True
                            tb8.ReadOnly = True
                            tb9.ReadOnly = True
                            tb10.ReadOnly = True
                            tb11.ReadOnly = True
                            tb.Attributes.Add("onkeyup", "")
                            tb2.Attributes.Add("onkeyup", "")
                            tb4.Attributes.Add("onkeyup", "")
                            tb5.Attributes.Add("onkeyup", "")
                            tb9.Attributes.Add("onkeyup", "")

                        Else

                            tb11.ReadOnly = True
                            'If e.Item.ItemType = GridItemType.EditItem Then
                            TbFncCode.Visible = True
                            LbFncCode.Visible = False
                            'Else
                            '    TbFncCode.Visible = False
                            '    LbFncCode.Visible = True
                            'End If
                            'AdvantageFramework.Web.Presentation.Controls.DivHide(LookupFunctionCodeDiv)
                            'AdvantageFramework.Web.Presentation.Controls.DivHide(LookupTaxCodeDiv)
                            'tb12.ReadOnly = True
                            'tb6.ReadOnly = True

                        End If

                    Catch ex As Exception
                    End Try

                    Try

                        Dim hfType As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfEST_NONBILL_FLAG"), HiddenField)
                        Dim hfType2 As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfFEE_TIME"), HiddenField)

                        If hfType2.Value = "1" OrElse hfType2.Value = "2" OrElse hfType2.Value = "3" Then 'It is fee time

                            FlagImage.AlternateText = "This function is fee time"
                            FlagImage.ToolTip = "This function is fee time"
                            AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagColorDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.Amber)

                        ElseIf hfType.Value = "1" AndAlso (hfType2.Value <> "1" OrElse hfType2.Value <> "2" OrElse hfType2.Value <> "3") Then 'It is non-billable and not fee time

                            FlagImage.AlternateText = "This function is non billable"
                            FlagImage.ToolTip = "This function is non billable"
                            AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagColorDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.Red)

                        Else

                            AdvantageFramework.Web.Presentation.Controls.DivHide(FlagColorDiv)

                        End If

                    Catch ex As Exception
                    End Try
                    Try

                        If (max <> Me.ddRevision.SelectedValue) Or (agrev = True And approval = True) Or (agrev = True And approvalInt = True) Or rights = "N" Then

                            tb.ReadOnly = True
                            tb2.ReadOnly = True
                            tb3.ReadOnly = True
                            tb4.ReadOnly = True
                            tb5.ReadOnly = True
                            tb6.ReadOnly = True
                            tb8.ReadOnly = True
                            tb9.ReadOnly = True
                            tb10.ReadOnly = True
                            tb11.ReadOnly = True
                            tb12.ReadOnly = True
                            tb13.ReadOnly = True
                            tb14.ReadOnly = True
                            tb15.ReadOnly = True
                            cb.Enabled = False

                            ' Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("ColumnClientSelect").Display = False

                            'AdvantageFramework.Web.Presentation.Controls.DivHide(LookupTaxCodeDiv)
                            AdvantageFramework.Web.Presentation.Controls.DivHide(LookupCopyFunctionDiv)
                            AdvantageFramework.Web.Presentation.Controls.DivHide(LookupDeleteFunctionDiv)
                            tb6.Attributes.Add("ondblclick", "")
                            tb6.Attributes.Add("ondblclick", "")

                            'AdvantageFramework.Web.Presentation.Controls.DivHide(LookupSuppliedByDiv)
                            tb12.Attributes.Add("ondblclick", "")

                            tb.Attributes.Add("onkeyup", "")
                            tb2.Attributes.Add("onkeyup", "")
                            tb4.Attributes.Add("onkeyup", "")
                            tb5.Attributes.Add("onkeyup", "")
                            tb9.Attributes.Add("onkeyup", "")

                            RadContextMenuGridItem.FindItemByValue("CopyTask").Enabled = False
                            RadContextMenuGridItem.FindItemByValue("DeleteTask").Enabled = False

                        Else

                            'Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("ColumnClientSelect").Display = True

                        End If
                    Catch ex As Exception

                    End Try

                Case GridItemType.GroupFooter

                    Dim CurrentGridFooter As Telerik.Web.UI.GridGroupFooterItem = e.Item

                    If DropSort.SelectedValue = "funccode" Then

                        e.Item.Cells(13).Text = String.Format("{0:#,##0.00}", sumQH)
                        e.Item.Cells(15).Text = String.Format("{0:#,##0.00}", sumEA)
                        e.Item.Cells(18).Text = String.Format("{0:#,##0.00}", sumTA)
                        e.Item.Cells(20).Text = String.Format("{0:#,##0.00}", sumMA)
                        e.Item.Cells(22).Text = String.Format("{0:#,##0.00}", sumGI)
                        e.Item.Cells(21).Text = String.Format("{0:#,##0.00}", sumLT)
                        e.Item.Cells(24).Text = String.Format("{0:#,##0.00}", sumCT)
                        e.Item.Cells(25).Text = String.Format("{0:#,##0.00}", sumCPU)
                        e.Item.Cells(26).Text = String.Format("{0:#,##0.00}", sumQWC)
                        e.Item.Cells(25).Visible = False

                    Else

                        e.Item.Cells(13).Text = String.Format("{0:#,##0.00}", sumQH)
                        e.Item.Cells(15).Text = String.Format("{0:#,##0.00}", sumEA)
                        e.Item.Cells(20).Text = String.Format("{0:#,##0.00}", sumTA)
                        e.Item.Cells(17).Text = String.Format("{0:#,##0.00}", sumMA)
                        e.Item.Cells(22).Text = String.Format("{0:#,##0.00}", sumGI)
                        e.Item.Cells(21).Text = String.Format("{0:#,##0.00}", sumLT)
                        e.Item.Cells(24).Text = String.Format("{0:#,##0.00}", sumCT)
                        e.Item.Cells(26).Text = String.Format("{0:#,##0.00}", sumCPU)
                        e.Item.Cells(25).Text = String.Format("{0:#,##0.00}", sumQWC)
                        e.Item.Cells(18).Text = String.Format("{0:#,##0.00}", sumEMU)
                        e.Item.Cells(26).Visible = False

                    End If

                    If DropSort.SelectedValue = "funccode" Then

                        e.Item.Cells(6).Text = "SubTotal:"

                    ElseIf DropSort.SelectedValue = "conscode" Then

                        If fc <> "" Then

                            CurrentGridFooter("colFNC_DESCRIPTION").Text = "Total for " & fc & ":"

                        Else

                            CurrentGridFooter("colFNC_DESCRIPTION").Text = "Total for [None]:"

                        End If
                    ElseIf DropSort.SelectedValue = "functype" Then

                        If ft = "E" Then

                            CurrentGridFooter("colFNC_DESCRIPTION").Text = "Total for Employee:"

                        End If
                        If ft = "V" Then

                            CurrentGridFooter("colFNC_DESCRIPTION").Text = "Total for Vendor:"

                        End If
                        If ft = "I" Then

                            CurrentGridFooter("colFNC_DESCRIPTION").Text = "Total for Income Only:"

                        End If
                        If ft = "C" Then

                            CurrentGridFooter("colFNC_DESCRIPTION").Text = "Total for Client OOP:"

                        End If


                    ElseIf DropSort.SelectedValue = "funcheading" Then

                        If fh <> "" Then

                            CurrentGridFooter("colFNC_DESCRIPTION").Text = "Total for " & fh & ":"

                        End If

                    End If
                    If DropSort.SelectedValue = "funccode" Then

                        e.Item.Cells(7).Font.Bold = True
                        e.Item.Cells(7).HorizontalAlign = WebControls.HorizontalAlign.Right

                    End If

                    'CurrentGridFooter.Style.Add("text-align", "right")
                    'CurrentGridFooter.Style.Add("font-size", "9")
                    'CurrentGridFooter.Font.Size = 9.0F
                    If Me.CurrentTheme = TkTheme.Large Then
                        CurrentGridFooter("colEST_REV_QUANTITY").Width = 90
                        CurrentGridFooter("colEST_REV_QUANTITY").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colEST_REV_QUANTITY").Text = CurrentGridFooter("colEST_REV_QUANTITY").Text & "&nbsp;&nbsp;&nbsp;"
                        CurrentGridFooter("colEST_REV_RATE").Width = 90
                        CurrentGridFooter("colEST_REV_RATE").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colEST_REV_RATE").Text = CurrentGridFooter("colEST_REV_RATE").Text & "&nbsp;&nbsp;&nbsp;"
                        CurrentGridFooter("colEST_REV_EXT_AMT").Width = 90
                        CurrentGridFooter("colEST_REV_EXT_AMT").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colEST_REV_EXT_AMT").Text = CurrentGridFooter("colEST_REV_EXT_AMT").Text & "&nbsp;&nbsp;&nbsp;"
                        CurrentGridFooter("colTAX_AMOUNT").Width = 90
                        CurrentGridFooter("colTAX_AMOUNT").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colTAX_AMOUNT").Text = CurrentGridFooter("colTAX_AMOUNT").Text & "&nbsp;&nbsp;&nbsp;"
                        CurrentGridFooter("colEST_REV_COMM_PCT").Width = 80
                        CurrentGridFooter("colEST_REV_COMM_PCT").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colEST_REV_COMM_PCT").Text = CurrentGridFooter("colEST_REV_COMM_PCT").Text & "&nbsp;&nbsp;&nbsp;"
                        CurrentGridFooter("colMARKUP_AMT").Width = 90
                        CurrentGridFooter("colMARKUP_AMT").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colMARKUP_AMT").Text = CurrentGridFooter("colMARKUP_AMT").Text & "&nbsp;&nbsp;&nbsp;"
                        CurrentGridFooter("colLINE_TOTAL").Width = 90
                        CurrentGridFooter("colLINE_TOTAL").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colLINE_TOTAL").Text = CurrentGridFooter("colLINE_TOTAL").Text & "&nbsp;&nbsp;&nbsp;"
                        CurrentGridFooter("colGrossIncome").Width = 90
                        CurrentGridFooter("colGrossIncome").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colGrossIncome").Text = CurrentGridFooter("colGrossIncome").Text & "&nbsp;&nbsp;&nbsp;"
                        CurrentGridFooter("colEST_REV_CONT_PCT").Width = 80
                        CurrentGridFooter("colEST_REV_CONT_PCT").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colEST_REV_CONT_PCT").Text = CurrentGridFooter("colEST_REV_CONT_PCT").Text & "&nbsp;&nbsp;&nbsp;"
                        CurrentGridFooter("colEXT_CONTINGENCY").Width = 90
                        CurrentGridFooter("colEXT_CONTINGENCY").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colEXT_CONTINGENCY").Text = CurrentGridFooter("colEXT_CONTINGENCY").Text & "&nbsp;&nbsp;&nbsp;&nbsp;"
                        CurrentGridFooter("colQUOTE_W_CONTINGENCY").Width = 90
                        CurrentGridFooter("colQUOTE_W_CONTINGENCY").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colQUOTE_W_CONTINGENCY").Text = CurrentGridFooter("colQUOTE_W_CONTINGENCY").Text & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                        CurrentGridFooter("colEST_REV_EXT_MU_AMT").Width = 90
                        CurrentGridFooter("colEST_REV_EXT_MU_AMT").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colEST_REV_EXT_MU_AMT").Text = CurrentGridFooter("colEST_REV_EXT_MU_AMT").Text & "&nbsp;&nbsp;&nbsp;"
                    Else
                        CurrentGridFooter("colEST_REV_QUANTITY").Width = 84
                        CurrentGridFooter("colEST_REV_QUANTITY").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colEST_REV_RATE").Width = 90
                        CurrentGridFooter("colEST_REV_RATE").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colEST_REV_EXT_AMT").Width = 90
                        CurrentGridFooter("colEST_REV_EXT_AMT").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colTAX_AMOUNT").Width = 90
                        CurrentGridFooter("colTAX_AMOUNT").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colEST_REV_COMM_PCT").Width = 80
                        CurrentGridFooter("colEST_REV_COMM_PCT").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colMARKUP_AMT").Width = 90
                        CurrentGridFooter("colMARKUP_AMT").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colLINE_TOTAL").Width = 90
                        CurrentGridFooter("colLINE_TOTAL").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colGrossIncome").Width = 90
                        CurrentGridFooter("colGrossIncome").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colEST_REV_CONT_PCT").Width = 80
                        CurrentGridFooter("colEST_REV_CONT_PCT").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colEXT_CONTINGENCY").Width = 90
                        CurrentGridFooter("colEXT_CONTINGENCY").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colQUOTE_W_CONTINGENCY").Width = 90
                        CurrentGridFooter("colQUOTE_W_CONTINGENCY").HorizontalAlign = WebControls.HorizontalAlign.Right
                        CurrentGridFooter("colEST_REV_EXT_MU_AMT").Width = 90
                        CurrentGridFooter("colEST_REV_EXT_MU_AMT").HorizontalAlign = WebControls.HorizontalAlign.Right
                    End If


                    sumQH = 0.0
                    sumEA = 0.0
                    sumTA = 0.0
                    sumMA = 0.0
                    sumGI = 0.0
                    sumLT = 0.0
                    sumCT = 0.0
                    sumCPU = 0.0
                    sumQWC = 0.0
                    sumEMU = 0.0

                Case GridItemType.Footer

                    Dim CurrentGridFooter As Telerik.Web.UI.GridFooterItem = Me.RadGridEstimateQuoteDetails.MasterTableView.GetItems(GridItemType.Footer)(0)

                    CType(CurrentGridFooter.FindControl("TxtSumEST_REV_QUANTITY"), TextBox).Text = String.Format("{0:#,##0.00}", sumQHTotal)
                    CType(CurrentGridFooter.FindControl("TxtSumEST_REV_EXT_AMT"), TextBox).Text = String.Format("{0:#,##0.00}", sumEATotal)
                    CType(CurrentGridFooter.FindControl("TxtSumEXT_MARKUP_AMT"), TextBox).Text = String.Format("{0:#,##0.00}", sumMATotal)
                    CType(CurrentGridFooter.FindControl("TxtSumGrossIncome"), TextBox).Text = String.Format("{0:#,##0.00}", sumGITotal)
                    CType(CurrentGridFooter.FindControl("TxtSumLINE_TOTAL"), TextBox).Text = String.Format("{0:#,##0.00}", sumLTTotal)
                    CType(CurrentGridFooter.FindControl("TxtSumEXT_CONTINGENCY"), TextBox).Text = String.Format("{0:#,##0.00}", sumCTTotal)
                    CType(CurrentGridFooter.FindControl("TxtSumQUOTE_W_CONTINGENCY"), TextBox).Text = String.Format("{0:#,##0.00}", sumQWCTotal)
                    CType(CurrentGridFooter.FindControl("TxtSumEST_REV_EXT_MU_AMT"), TextBox).Text = String.Format("{0:#,##0.00}", sumEMUTotal)

                    'CurrentGridFooter("colCPU").Visible = False
                    If CurrentGridFooter("colCPU").Visible = True Then CType(CurrentGridFooter("colCPU").FindControl("TxtSumCPU"), TextBox).Text = String.Format("{0:#,##0.00}", sumCPUTotal)

                    'CurrentGridFooter("colTAX_AMOUNT").Visible = False
                    If CurrentGridFooter("colTAX_AMOUNT").Visible = True Then CType(CurrentGridFooter("colTAX_AMOUNT").FindControl("TxtSumTAX_AMOUNT"), TextBox).Text = String.Format("{0:#,##0.00}", sumTATotal)


                    With CurrentGridFooter("colFNC_DESCRIPTION")

                        .Text = "Total for Quote:"
                        .Font.Bold = True
                        .HorizontalAlign = WebControls.HorizontalAlign.Right

                    End With

                    If Me.TxtQty.Text <> "" And Me.TxtQty.Text <> "0" Then

                        Dim cpu As Decimal = (sumCPUTotal / CDec(Me.TxtQty.Text))
                        Me.TxtCPU.Text = String.Format("{0:#,##0.000}", cpu)

                    End If
                    If IsNumeric(Me.TxtCPU.Text) = True Then

                        Me.txtCPM.Text = String.Format("{0:#,##0.00}", (sumCPUTotal / (CDec(Me.TxtQty.Text) / 1000)))

                    End If
                    If max <> Me.ddRevision.SelectedValue Then

                        e.Item.Cells(1).Visible = False

                    End If

                    Me.lblQuoteAmt.Text = String.Format("{0:#,##0.00}", sumLTTotal)
                    Me.lblContingencyAmount.Text = String.Format("{0:#,##0.00}", sumCTTotal)
                    Me.lblQuotewithContingnecyAmount.Text = String.Format("{0:#,##0.00}", sumQWCTotal)

            End Select

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub RadGridEstimateQuoteDetails_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEstimateQuoteDetails.NeedDataSource
        _LoadingDatasource = True
        Try

            Me._GridIsGrouped = Not DropSort.SelectedValue = "funccode"
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim ag As New cAgency(Session("ConnString"))
            Dim max As Integer = 0
            Dim agrev As Boolean = False

            Me.RadGridEstimateQuoteDetails.DataSource = Me.DtQuoteFunctions

            max = est.GetEstimateQuoteMaxRevision(Me.EstNum, Me.EstCompNum, Me.QuoteNum)
            agrev = ag.AutoEstRevFlag()

            If Me.ddRevision.SelectedValue <> "" Then

                drInt = est.GetQuoteApprovalInternal(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, approvalType)
                dr = est.GetQuoteApproval(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, approvalType)

            Else

                drInt = est.GetQuoteApprovalInternal(Me.EstNum, Me.EstCompNum, Me.QuoteNum, 0, approvalType)
                dr = est.GetQuoteApproval(Me.EstNum, Me.EstCompNum, Me.QuoteNum, 0, approvalType)

            End If
            If dr.HasRows = True Then

                approval = True

            End If
            If drInt.HasRows = True Then

                approvalInt = True

            End If

            If (max <> Me.ddRevision.SelectedValue) Or (agrev = True And approval = True) Or (agrev = True And approvalInt = True) Or rights = "N" Then
                Me.RadGridEstimateQuoteDetails.MasterTableView.IsItemInserted = False
            Else
                Me.RadGridEstimateQuoteDetails.MasterTableView.IsItemInserted = True
            End If

            Me.RadGridEstimateQuoteDetails.CurrentPageIndex = Me.CurrentGridPageIndex
            Me.RadGridEstimateQuoteDetails.PageSize = MiscFN.LoadPageSize(Me.RadGridEstimateQuoteDetails.ID)

        Catch ex As Exception

        End Try
        _LoadingDatasource = False
    End Sub


    Private Sub RadGridEstimateQuoteDetails_ItemCreated(sender As Object, e As GridItemEventArgs) Handles RadGridEstimateQuoteDetails.ItemCreated
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim TextBox As System.Web.UI.WebControls.TextBox = Nothing
        Dim RadComboBox As Telerik.Web.UI.RadComboBox = Nothing
        Dim Hiddenfield As HtmlInputHidden = Nothing
        Dim DeleteImageButton As System.Web.UI.WebControls.ImageButton = Nothing

        Dim agrev As Boolean = False
        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim ag As New cAgency(Session("ConnString"))
        Dim max As Integer = 0

        max = est.GetEstimateQuoteMaxRevision(Me.EstNum, Me.EstCompNum, Me.QuoteNum)
        agrev = ag.AutoEstRevFlag()

        If (max <> Me.ddRevision.SelectedValue) Or (agrev = True And approval = True) Or (agrev = True And approvalInt = True) Or rights = "N" Then

        Else
            If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

                GridDataItem = TryCast(e.Item, Telerik.Web.UI.GridDataItem)

                If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then

                    Hiddenfield = GridDataItem.FindControl("HiddenFunctionSequence")
                    If Hiddenfield IsNot Nothing Then
                        Hiddenfield.Attributes.Add("adv-lookup", "FunctionSeq")
                    End If

                    TextBox = GridDataItem.FindControl("TxtEST_REV_QUANTITY")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-lookup", "EstimateQuantity")
                    End If

                    'TextBox = GridDataItem.FindControl("TxtEST_REV_RATE")
                    'If TextBox IsNot Nothing Then
                    '    TextBox.Attributes.Add("adv-lookup", "EstimateRate")
                    'End If

                    TextBox = GridDataItem.FindControl("TxtEST_REV_CONT_PCT")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-lookup", "EstimateContingencyPct")
                    End If

                    TextBox = GridDataItem.FindControl("TxtEST_REV_COMM_PCT")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-lookup", "EstimateCommissionPercent")
                    End If

                    TextBox = GridDataItem.FindControl("TxtMARKUP_AMT")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-lookup", "EstimateCommissionAmount")
                    End If

                    TextBox = GridDataItem.FindControl("TxtEST_REV_EXT_AMT")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-lookup", "EstimateAmount")
                    End If

                    DeleteImageButton = GridDataItem.FindControl("ImageButton_DeleteFunction")

                    If DeleteImageButton IsNot Nothing Then

                        DeleteImageButton.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this function?');")

                    End If

                End If

                If e.Item.ItemType = GridItemType.EditItem Or e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then


                    TextBox = GridDataItem.FindControl("TxtFunctionCode")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-lookup", "Function")
                    End If

                    TextBox = GridDataItem.FindControl("TxtEST_REV_QUANTITY")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-calc", "Quantity")
                    End If

                    TextBox = GridDataItem.FindControl("TxtEST_REV_RATE")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-calc", "Rate")
                    End If

                    TextBox = GridDataItem.FindControl("TxtEST_REV_EXT_AMT")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-calc", "ExtendedAmount")
                    End If

                    TextBox = GridDataItem.FindControl("TxtTaxCode")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-calc", "TaxCode")
                    End If

                    TextBox = GridDataItem.FindControl("TxtTAX_AMOUNT")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-calc", "TaxAmount")
                    End If

                    TextBox = GridDataItem.FindControl("TxtEST_REV_COMM_PCT")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-calc", "CommissionPercent")
                    End If

                    TextBox = GridDataItem.FindControl("TxtMARKUP_AMT")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-calc", "CommissionAmount")
                    End If

                    TextBox = GridDataItem.FindControl("TxtMARKUP_AMT")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-calc", "Commission")
                    End If

                    TextBox = GridDataItem.FindControl("TxtLINE_TOTAL")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-calc", "LineTotal")
                    End If

                    TextBox = GridDataItem.FindControl("TxtEST_REV_CONT_PCT")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-calc", "ContingencyPercent")
                    End If

                    TextBox = GridDataItem.FindControl("TxtEXT_CONTINGENCY")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-calc", "ContingencyAmount")
                    End If

                    TextBox = GridDataItem.FindControl("TxtFNC_DESCRIPTION")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-desc", "Function")
                    End If

                    TextBox = GridDataItem.FindControl("TxtTaxCode")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-lookup", "TaxCode")
                    End If

                    TextBox = GridDataItem.FindControl("TxtEST_REV_SUP_BY_CDE")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-lookup", "Employee")
                    End If

                    TextBox = GridDataItem.FindControl("TxtEST_REV_SUP_BY_CDE")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-desc", "SuppliedBy")
                    End If

                    TextBox = GridDataItem.FindControl("TxtEMPLOYEE_TITLE")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-desc", "Employee")
                    End If

                    TextBox = GridDataItem.FindControl("TxtEMPLOYEE_TITLE")
                    If TextBox IsNot Nothing Then
                        TextBox.Attributes.Add("adv-lookup", "EmployeeTitle")
                    End If

                    Hiddenfield = GridDataItem.FindControl("HiddenEmployeeTitleID")
                    If Hiddenfield IsNot Nothing Then
                        Hiddenfield.Attributes.Add("adv-desc", "EmployeeTitleID")
                    End If

                    Hiddenfield = GridDataItem.FindControl("HiddenFieldTaxComm")
                    If Hiddenfield IsNot Nothing Then
                        Hiddenfield.Attributes.Add("adv-calc", "TaxComm")
                    End If

                    Hiddenfield = GridDataItem.FindControl("HiddenFieldTaxCommOnly")
                    If Hiddenfield IsNot Nothing Then
                        Hiddenfield.Attributes.Add("adv-calc", "TaxCommOnly")
                    End If

                    Hiddenfield = GridDataItem.FindControl("HiddenFieldNonbillFlag")
                    If Hiddenfield IsNot Nothing Then
                        Hiddenfield.Attributes.Add("adv-calc", "NonBillFlag")
                    End If

                    Hiddenfield = GridDataItem.FindControl("HiddenFieldTaxCode")
                    If Hiddenfield IsNot Nothing Then
                        Hiddenfield.Attributes.Add("adv-calc", "TaxCode")
                    End If

                    Hiddenfield = GridDataItem.FindControl("HiddenFieldTaxStatePct")
                    If Hiddenfield IsNot Nothing Then
                        Hiddenfield.Attributes.Add("adv-calc", "TaxStatePct")
                    End If

                    Hiddenfield = GridDataItem.FindControl("HiddenFieldTaxCountyPct")
                    If Hiddenfield IsNot Nothing Then
                        Hiddenfield.Attributes.Add("adv-calc", "TaxCountyPct")
                    End If

                    Hiddenfield = GridDataItem.FindControl("HiddenFieldTaxCityPct")
                    If Hiddenfield IsNot Nothing Then
                        Hiddenfield.Attributes.Add("adv-calc", "TaxCityPct")
                    End If

                    Hiddenfield = GridDataItem.FindControl("HiddenFieldTaxResale")
                    If Hiddenfield IsNot Nothing Then
                        Hiddenfield.Attributes.Add("adv-calc", "TaxResale")
                    End If

                    Hiddenfield = GridDataItem.FindControl("HiddenFunctionType")
                    If Hiddenfield IsNot Nothing Then
                        Hiddenfield.Attributes.Add("adv-lookup", "FunctionType")
                    End If

                    Hiddenfield = GridDataItem.FindControl("HiddenFieldCPM")
                    If Hiddenfield IsNot Nothing Then
                        Hiddenfield.Attributes.Add("adv-calc", "CPM")
                    End If

                End If

            End If
        End If


    End Sub

    'this is going to need to handle insert as well...
    Private JobNumber As Integer = 0
    Private Function SaveGridRow(ByVal RowIndex As Integer, ByVal RowTask_EstNum As Integer, ByVal RowTask_EstComp As Integer,
                                 ByVal RowTask_SeqNum As Integer, ByVal TheGridRow As Telerik.Web.UI.GridDataItem,
                                 ByVal RowTask_QuoteNum As Integer, ByVal RowTask_RevNum As Integer, Optional ByVal RebindGrid As Boolean = True,
                                 Optional ByVal IsUserRow As Integer = 0, Optional ByVal SaveUserRow As Boolean = True) As String
        'Create variables:
        Dim RowHasChange As Boolean = False

        Dim RowFunctionCode As String = ""
        Dim RowFunctionComment As String = ""
        Dim RowFunctionType As String = ""
        Dim RowSuppliedBy As String = ""
        Dim RowSuppliedByNotes As String = ""
        Dim RowQuantityHours As Decimal = 0
        Dim RowRevRate As Decimal = 0
        Dim RowExtAmount As Decimal = 0
        Dim RowTaxCode As String = ""
        Dim RowCPU As Boolean
        Dim RowContPct As Decimal = 0
        Dim RowMarkupPct As Decimal = 0
        Dim RowMarkupAmt As Decimal = 0
        Dim RowContAmt As Decimal = 0
        Dim RowMuContAmt As Decimal = 0
        Dim RowLineTotal As Decimal = 0
        Dim RowLineTotalCont As Decimal = 0
        Dim RowTaxComm As String = ""
        Dim RowTaxCommOnly As String = ""

        If JobNumber = 0 AndAlso String.IsNullOrWhiteSpace(Me.TxtJobNum.Text) = False AndAlso IsNumeric(Me.TxtJobNum.Text) = True Then

            JobNumber = CType(Me.TxtJobNum.Text, Integer)

        End If

        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim v As New cValidations(Session("ConnString"))
        Dim dt As DataTable
        Dim tb As System.Web.UI.WebControls.TextBox

        If IsUserRow = 1 And SaveUserRow = True Then
            Try
                If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colFNC_CODE").Display = True Then
                    RowFunctionCode = DirectCast(TheGridRow.FindControl("TxtFunctionCode"), TextBox).Text
                    '	ESTIMATE_REV_DET.FNC_CODE, 
                    If RowFunctionCode <> "" Then
                        If JobNumber > 0 OrElse String.IsNullOrEmpty(hfClientCode.Value) = False Then
                            If v.ValidateFunctionCodeEst(RowFunctionCode, JobNumber, hfClientCode.Value) = False Then
                                Me.lblMSG.Text = "Invalid Function Code."
                                Exit Function
                            End If
                        Else
                            If v.ValidateFunctionCodeEst(RowFunctionCode) = False Then
                                Me.lblMSG.Text = "Invalid Function Code."
                                Exit Function
                            End If
                        End If
                    Else
                        Me.lblMSG.Text = "Function Code is Required."
                        Exit Function
                    End If
                End If
            Catch ex As Exception
            End Try

            Try
                If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colEST_FNC_COMMENT").Display = True Then
                    RowFunctionComment = DirectCast(TheGridRow.FindControl("TxtEST_FNC_COMMENT"), TextBox).Text
                    'ESTIMATE_REV_DET.EST_FNC_COMMENT                    
                End If
            Catch ex As Exception
            End Try

            Try
                If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colEST_REV_SUP_BY_CDE").Display = True Then
                    RowSuppliedBy = DirectCast(TheGridRow.FindControl("TxtEST_REV_SUP_BY_CDE"), TextBox).Text
                    RowFunctionType = DirectCast(TheGridRow.FindControl("HfFunctionType"), HiddenField).Value
                    If RowFunctionType = "" Then
                        dt = est.GetAddNewFunctionData(RowFunctionCode)
                        If dt.Rows.Count > 0 Then
                            RowFunctionType = dt.Rows(0)("FNC_TYPE")
                        End If
                    End If
                    '	ESTIMATE_REV_DET.EST_REV_SUP_BY_CDE, 
                    If RowFunctionType = "E" Then
                        If RowSuppliedBy <> "" Then
                            If v.ValidateEmpCodetd(RowSuppliedBy) = True Then

                            Else
                                Me.lblMSG.Text = "Invalid Employee Code."
                                Exit Function
                            End If
                        End If
                    ElseIf RowFunctionType = "V" Then
                        If RowSuppliedBy <> "" Then
                            If v.ValidateVendor(RowSuppliedBy) = True Then

                            Else
                                Me.lblMSG.Text = "Invalid Vendor Code."
                                Exit Function
                            End If
                        End If
                    End If

                End If
            Catch ex As Exception
            End Try

            Try
                If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colEST_REV_SUP_BY_NTE").Display = True Then
                    RowSuppliedByNotes = DirectCast(TheGridRow.FindControl("TxtEST_REV_SUP_BY_NTE"), TextBox).Text
                    '	ESTIMATE_REV_DET.EST_REV_SUP_BY_NTE,                     
                End If
            Catch ex As Exception
            End Try
            Try
                If Me.txtBlendRate.Text <> "" Then
                    If IsNumeric(Me.txtBlendRate.Text) = False Then
                        Me.lblMSG.Text = "Blended Time Bill Rate is invalid"
                        Exit Function
                    End If
                End If
            Catch ex As Exception
            End Try

            Dim strSave As String = est.InsertNewFunction(RowTask_EstNum, RowTask_EstComp, RowTask_QuoteNum, RowTask_RevNum, RowFunctionCode, Session("UserCode"), RowSuppliedBy, RowFunctionComment, RowSuppliedByNotes, 0, 0, 0, Me.txtBlendRate.Text)


        ElseIf IsUserRow = 0 Then
            Dim SQLPrefix As String = "UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET "
            Dim SQLBody As StringBuilder = New StringBuilder
            Dim SQLSuffix As String = " WHERE (ESTIMATE_NUMBER = " & RowTask_EstNum & ") AND (EST_COMPONENT_NBR = " & RowTask_EstComp & ") AND (EST_QUOTE_NBR = " & RowTask_QuoteNum & ") AND (EST_REV_NBR = " & RowTask_RevNum & ") AND (SEQ_NBR = " & RowTask_SeqNum & ")"
            Dim arP(34) As SqlParameter

            Try

                If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colFNC_CODE").Display = True Then
                    RowFunctionCode = DirectCast(TheGridRow.FindControl("TxtFunctionCode"), TextBox).Text
                    RowFunctionType = DirectCast(TheGridRow.FindControl("HfFunctionType"), HiddenField).Value
                    '	ESTIMATE_REV_DET.FNC_CODE, 
                    If RowFunctionCode <> "" Then
                        'If v.ValidateFunctionCodeEst(RowFunctionCode) = False Then
                        '    Me.lblMSG.Text = "Invalid Function Code."
                        '    Exit Function
                        'Else
                        dt = est.GetAddNewFunctionData(RowFunctionCode)
                        With SQLBody

                            .Append("FNC_CODE = @FNC_CODE")



                            .Append(", ")
                            Dim parameterFNC_CODE As New SqlParameter("@FNC_CODE", SqlDbType.VarChar)
                            parameterFNC_CODE.Value = RowFunctionCode
                            arP(0) = parameterFNC_CODE

                            '.Append("'")
                            '.Append(RowFunctionCode)
                            '.Append("'")
                            '.Append(", ")
                            If dt.Rows.Count > 0 Then
                                '.Append("EST_FNC_TYPE = ")
                                '.Append("'")
                                '.Append(dt.Rows(0)("FNC_TYPE"))
                                '.Append("'")
                                '.Append(", ")
                                .Append("EST_CPM_FLAG = @EST_CPM_FLAG")

                                .Append(", ")
                                Dim parameterEST_CPM_FLAG As New SqlParameter("@EST_CPM_FLAG", SqlDbType.SmallInt)
                                parameterEST_CPM_FLAG.Value = dt.Rows(0)("FNC_CPM_FLAG")
                                arP(1) = parameterEST_CPM_FLAG
                                '.Append("EST_CPM_FLAG = ")
                                '.Append(dt.Rows(0)("FNC_CPM_FLAG"))
                                '.Append(", ")
                                '.Append("TAX_COMM = ")
                                '.Append(dt.Rows(0)("TAX_COMM"))
                                '.Append(", ")
                                '.Append("TAX_COMM_ONLY = ")
                                '.Append(dt.Rows(0)("TAX_COMM_ONLY"))
                                '.Append(", ")
                                '.Append("EST_NONBILL_FLAG = ")
                                '.Append(dt.Rows(0)("FNC_NONBILL_FLAG"))
                                '.Append(", ")
                                '.Append("EST_TAX_FLAG = ")
                                '.Append(dt.Rows(0)("FNC_TAX_FLAG"))
                                '.Append(", ")
                                '.Append("EST_COMM_FLAG = ")
                                '.Append(dt.Rows(0)("FNC_COMM_FLAG"))
                                '.Append(", ")
                            End If
                        End With
                        'End If
                    Else
                        Me.lblMSG.Text = "Function Code is Required."
                        Exit Function
                    End If
                End If
            Catch ex As Exception
            End Try



            Try
                If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colEST_FNC_COMMENT").Display = True Then
                    RowFunctionComment = DirectCast(TheGridRow.FindControl("TxtEST_FNC_COMMENT"), TextBox).Text
                    'ESTIMATE_REV_DET.EST_FNC_COMMENT
                    With SQLBody
                        .Append("EST_FNC_COMMENT = @EST_FNC_COMMENT")
                        .Append(", ")
                        Dim parameterEST_FNC_COMMENT As New SqlParameter("@EST_FNC_COMMENT", SqlDbType.Text)
                        parameterEST_FNC_COMMENT.Value = RowFunctionComment
                        arP(2) = parameterEST_FNC_COMMENT
                        '.Append("EST_FNC_COMMENT = ")
                        '.Append("'")
                        '.Append(RowFunctionComment.Replace("'", "''"))
                        '.Append("'")
                        '.Append(", ")







                    End With
                End If
            Catch ex As Exception
            End Try



            Try
                Dim curCode As String = ""
                If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colEST_REV_SUP_BY_CDE").Display = True Then
                    tb = DirectCast(TheGridRow.FindControl("TxtEST_REV_SUP_BY_CDE"), TextBox)
                    If tb.ReadOnly Then
                        RowSuppliedBy = DirectCast(TheGridRow.FindControl("HfSuppliedByCode"), HiddenField).Value
                        curCode = DirectCast(TheGridRow.FindControl("TxtEST_REV_SUP_BY_CDE"), TextBox).Text
                    Else
                        RowSuppliedBy = DirectCast(TheGridRow.FindControl("TxtEST_REV_SUP_BY_CDE"), TextBox).Text
                        curCode = DirectCast(TheGridRow.FindControl("HfSuppliedByCode"), HiddenField).Value
                    End If
                    RowFunctionType = DirectCast(TheGridRow.FindControl("HfFunctionType"), HiddenField).Value
                    '	ESTIMATE_REV_DET.EST_REV_SUP_BY_CDE, 
                    If RowFunctionType = "E" Then
                        If RowSuppliedBy <> "" Then
                            If curCode <> RowSuppliedBy Then
                                If v.ValidateEmpCodetd(RowSuppliedBy) = True Then
                                    With SQLBody

                                        .Append("EST_REV_SUP_BY_CDE = @EST_REV_SUP_BY_CDE")


                                        .Append(", ")
                                        Dim parameterEST_REV_SUP_BY_CDE As New SqlParameter("@EST_REV_SUP_BY_CDE", SqlDbType.VarChar)
                                        parameterEST_REV_SUP_BY_CDE.Value = RowSuppliedBy
                                        arP(3) = parameterEST_REV_SUP_BY_CDE

                                        '.Append("EST_REV_SUP_BY_CDE = ")
                                        '.Append("'")
                                        '.Append(RowSuppliedBy)
                                        '.Append("'")
                                        '.Append(", ")
                                    End With
                                Else
                                    Me.lblMSG.Text = "Invalid Employee Code."
                                    Exit Function
                                End If
                            End If
                        Else
                            SQLBody.Append("EST_REV_SUP_BY_CDE = NULL,")
                        End If
                    ElseIf RowFunctionType = "V" Then
                        If RowSuppliedBy <> "" Then
                            If curCode <> RowSuppliedBy Then
                                If v.ValidateVendor(RowSuppliedBy) = True Then
                                    With SQLBody

                                        .Append("EST_REV_SUP_BY_CDE = @EST_REV_SUP_BY_CDE")


                                        .Append(", ")
                                        Dim parameterEST_REV_SUP_BY_CDE As New SqlParameter("@EST_REV_SUP_BY_CDE", SqlDbType.VarChar)
                                        parameterEST_REV_SUP_BY_CDE.Value = RowSuppliedBy
                                        arP(3) = parameterEST_REV_SUP_BY_CDE

                                        '.Append("EST_REV_SUP_BY_CDE = ")
                                        '.Append("'")
                                        '.Append(RowSuppliedBy)
                                        '.Append("'")
                                        '.Append(", ")
                                    End With
                                Else
                                    Me.lblMSG.Text = "Invalid Vendor Code."
                                    Exit Function
                                End If
                            End If
                        Else
                            SQLBody.Append("EST_REV_SUP_BY_CDE = NULL,")
                        End If
                    End If

                End If
            Catch ex As Exception
            End Try

            Try
                If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colEST_REV_SUP_BY_NTE").Display = True Then
                    RowSuppliedByNotes = DirectCast(TheGridRow.FindControl("TxtEST_REV_SUP_BY_NTE"), TextBox).Text
                    '	ESTIMATE_REV_DET.EST_REV_SUP_BY_NTE, 
                    With SQLBody

                        .Append("EST_REV_SUP_BY_NTE = @EST_REV_SUP_BY_NTE")


                        .Append(", ")
                        Dim parameterEST_REV_SUP_BY_NTE As New SqlParameter("@EST_REV_SUP_BY_NTE", SqlDbType.Text)
                        parameterEST_REV_SUP_BY_NTE.Value = RowSuppliedByNotes
                        arP(4) = parameterEST_REV_SUP_BY_NTE

                        '.Append("EST_REV_SUP_BY_NTE = ")
                        '.Append("'")
                        '.Append(RowSuppliedByNotes.Replace("'", "''"))
                        '.Append("'")
                        '.Append(", ")
                    End With
                End If
            Catch ex As Exception
            End Try

            Try
                If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colEST_REV_QUANTITY").Display = True Then
                    If IsNumeric(DirectCast(TheGridRow.FindControl("TxtEST_REV_QUANTITY"), TextBox).Text) Then
                        RowQuantityHours = CType(DirectCast(TheGridRow.FindControl("TxtEST_REV_QUANTITY"), TextBox).Text, Decimal)
                        '	ESTIMATE_REV_DET.EST_REV_QUANTITY, 
                        With SQLBody

                            .Append("EST_REV_QUANTITY = @EST_REV_QUANTITY")
                            .Append(", ")
                            Dim parameterEST_REV_QUANTITY As New SqlParameter("@EST_REV_QUANTITY", SqlDbType.Decimal)
                            parameterEST_REV_QUANTITY.Value = RowQuantityHours
                            arP(5) = parameterEST_REV_QUANTITY

                            '.Append("EST_REV_QUANTITY = ")
                            '.Append(RowQuantityHours)
                            '.Append(", ")
                        End With
                    Else
                        SQLBody.Append("EST_REV_QUANTITY = 0, ")
                    End If
                End If
            Catch ex As Exception
            End Try

            Try
                If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colEST_REV_RATE").Display = True Then
                    If IsNumeric(DirectCast(TheGridRow.FindControl("TxtEST_REV_RATE"), TextBox).Text) Then
                        RowRevRate = CType(DirectCast(TheGridRow.FindControl("TxtEST_REV_RATE"), TextBox).Text, Decimal)
                        '	ESTIMATE_REV_DET.EST_REV_RATE, 
                        With SQLBody

                            .Append("EST_REV_RATE = @EST_REV_RATE")
                            .Append(", ")
                            Dim parameterEST_REV_RATE As New SqlParameter("@EST_REV_RATE", SqlDbType.Decimal)
                            parameterEST_REV_RATE.Value = RowRevRate
                            arP(6) = parameterEST_REV_RATE

                            '.Append("EST_REV_RATE = ")
                            '.Append(RowRevRate)
                            '.Append(", ")
                        End With
                    Else
                        SQLBody.Append("EST_REV_RATE = 0, ")
                    End If
                End If
            Catch ex As Exception
            End Try

            Try
                If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colEST_REV_EXT_AMT").Display = True Then
                    If IsNumeric(DirectCast(TheGridRow.FindControl("TxtEST_REV_EXT_AMT"), TextBox).Text) Then
                        RowExtAmount = CType(DirectCast(TheGridRow.FindControl("TxtEST_REV_EXT_AMT"), TextBox).Text, Decimal)
                        '	ESTIMATE_REV_DET.EST_REV_EXT_AMT, 
                        With SQLBody

                            .Append("EST_REV_EXT_AMT = @EST_REV_EXT_AMT")
                            .Append(", ")
                            Dim parameterEST_REV_EXT_AMT As New SqlParameter("@EST_REV_EXT_AMT", SqlDbType.Decimal)
                            parameterEST_REV_EXT_AMT.Value = RowExtAmount
                            arP(7) = parameterEST_REV_EXT_AMT

                            '.Append("EST_REV_EXT_AMT = ")
                            '.Append(RowExtAmount)
                            '.Append(", ")
                        End With
                    Else
                        SQLBody.Append("EST_REV_EXT_AMT = 0, ")
                    End If
                End If
            Catch ex As Exception
            End Try

            Try
                'If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colEST_REV_COMM_PCT").Display = True Then
                If IsNumeric(DirectCast(TheGridRow.FindControl("TxtEST_REV_COMM_PCT"), TextBox).Text) Then
                    RowMarkupPct = CType(DirectCast(TheGridRow.FindControl("TxtEST_REV_COMM_PCT"), TextBox).Text, Decimal)
                    '	ESTIMATE_REV_DET.EST_REV_COMM_PCT, 
                    With SQLBody

                        .Append("EST_REV_COMM_PCT = @EST_REV_COMM_PCT")
                        .Append(", ")
                        Dim parameterEST_REV_COMM_PCT As New SqlParameter("@EST_REV_COMM_PCT", SqlDbType.Decimal)
                        parameterEST_REV_COMM_PCT.Value = RowMarkupPct
                        arP(8) = parameterEST_REV_COMM_PCT

                        '.Append("EST_REV_COMM_PCT = ")
                        '.Append(RowMarkupPct)
                        '.Append(", ")
                    End With
                Else
                    SQLBody.Append("EST_REV_COMM_PCT = 0, ")
                End If
                'End If
            Catch ex As Exception
            End Try

            Try
                'If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colMARKUP_AMT").Display = True Then
                If IsNumeric(DirectCast(TheGridRow.FindControl("TxtMARKUP_AMT"), TextBox).Text) Then
                    RowMarkupAmt = CType(DirectCast(TheGridRow.FindControl("TxtMARKUP_AMT"), TextBox).Text, Decimal)
                    '	ESTIMATE_REV_DET.EXT.MARKUP_AMT, 
                    If RowMarkupPct <> 0 Then
                        With SQLBody

                            .Append("EXT_MARKUP_AMT = @EXT_MARKUP_AMT")
                            .Append(", ")
                            Dim parameterEXT_MARKUP_AMT As New SqlParameter("@EXT_MARKUP_AMT", SqlDbType.Decimal)
                            parameterEXT_MARKUP_AMT.Value = RowMarkupAmt
                            arP(9) = parameterEXT_MARKUP_AMT

                            '.Append("EXT_MARKUP_AMT = ")
                            '.Append(RowMarkupAmt)
                            '.Append(", ")
                        End With
                    Else
                        With SQLBody

                            .Append("EXT_MARKUP_AMT = @EXT_MARKUP_AMT")
                            .Append(", ")
                            Dim parameterEXT_MARKUP_AMT As New SqlParameter("@EXT_MARKUP_AMT", SqlDbType.Decimal)
                            parameterEXT_MARKUP_AMT.Value = RowMarkupAmt
                            arP(9) = parameterEXT_MARKUP_AMT

                            '.Append("EXT_MARKUP_AMT = ")
                            '.Append(RowMarkupAmt)
                            '.Append(", ")
                        End With
                    End If
                Else
                    SQLBody.Append("EXT_MARKUP_AMT = 0, ")
                End If
                'End If
            Catch ex As Exception
            End Try

            Try
                'If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colEST_REV_CONT_PCT").Display = True Then
                If IsNumeric(DirectCast(TheGridRow.FindControl("TxtEST_REV_CONT_PCT"), TextBox).Text) Then
                    RowContPct = CType(DirectCast(TheGridRow.FindControl("TxtEST_REV_CONT_PCT"), TextBox).Text, Decimal)
                    '	ESTIMATE_REV_DET.EST_REV_CONT_PCT, 
                    With SQLBody

                        .Append("EST_REV_CONT_PCT = @EST_REV_CONT_PCT")
                        .Append(", ")
                        Dim parameterEST_REV_CONT_PCT As New SqlParameter("@EST_REV_CONT_PCT", SqlDbType.Decimal)
                        parameterEST_REV_CONT_PCT.Value = RowContPct
                        arP(10) = parameterEST_REV_CONT_PCT

                        '.Append("EST_REV_CONT_PCT = ")
                        '.Append(RowContPct)
                        '.Append(", ")
                        If RowContPct > 0 Then

                            .Append("EXT_CONTINGENCY = @EXT_CONTINGENCY")
                            .Append(", ")
                            Dim parameterEXT_CONTINGENCY As New SqlParameter("@EXT_CONTINGENCY", SqlDbType.Decimal)
                            parameterEXT_CONTINGENCY.Value = RowExtAmount * (RowContPct / 100)
                            arP(11) = parameterEXT_CONTINGENCY

                            '.Append("EXT_CONTINGENCY = ")
                            '.Append(RowExtAmount * (RowContPct / 100))
                            RowContAmt = RowExtAmount * (RowContPct / 100)
                            RowLineTotalCont += RowContAmt
                            '.Append(", ")
                            If RowMarkupPct > 0 Then

                                .Append("EXT_MU_CONT = @EXT_MU_CONT")
                                .Append(", ")
                                Dim parameterEXT_MU_CONT As New SqlParameter("@EXT_MU_CONT", SqlDbType.Decimal)
                                parameterEXT_MU_CONT.Value = (RowMarkupAmt * (RowContPct / 100))
                                arP(12) = parameterEXT_MU_CONT

                                '.Append("EXT_MU_CONT = ")
                                '.Append((RowMarkupAmt * (RowContPct / 100)))
                                RowMuContAmt = RowMarkupAmt * (RowContPct / 100)
                                '.Append(", ")
                                RowLineTotalCont += (RowMarkupAmt * (RowContPct / 100))
                            Else
                                .Append("EXT_MU_CONT = 0, ")
                            End If
                        Else
                            .Append("EXT_CONTINGENCY = 0, ")
                            .Append("EXT_MU_CONT = 0, ")
                        End If
                    End With
                Else
                    SQLBody.Append("EST_REV_CONT_PCT = 0, ")
                    SQLBody.Append("EXT_CONTINGENCY = 0, ")
                    SQLBody.Append("EXT_MU_CONT = 0, ")
                End If
                'End If
            Catch ex As Exception
            End Try

            'Try
            '    If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colEXT_CONTINGENCY").Display = True Then
            '        If IsNumeric(DirectCast(TheGridRow.FindControl("TxtEXT_CONTINGENCY"), TextBox).Text) Then
            '            RowContAmt = CType(DirectCast(TheGridRow.FindControl("TxtEXT_CONTINGENCY"), TextBox).Text, Decimal)
            '            '	ESTIMATE_REV_DET.EST_REV_CONT_PCT, 
            '            With SQLBody
            '                .Append("EXT_CONTINGENCY = ")
            '                .Append(RowContAmt)
            '                .Append(", ")
            '                'If RowContPct > 0 Then
            '                '    .Append("EXT_CONTINGENCY = ")
            '                '    .Append(RowExtAmount * (RowContPct / 100))
            '                '    RowContAmt = RowExtAmount * (RowContPct / 100)
            '                '    .Append(", ")
            '                'End If
            '            End With
            '        Else
            '            SQLBody.Append("EXT_CONTINGENCY = NULL, ")
            '        End If
            '    End If
            'Catch ex As Exception
            'End Try

            Try
                'If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colTAX_CODE").Display = True Then
                tb = DirectCast(TheGridRow.FindControl("TxtTaxCode"), TextBox)
                If tb.ReadOnly Then
                    RowTaxCode = DirectCast(TheGridRow.FindControl("HfTaxCode"), HiddenField).Value
                Else
                    RowTaxCode = DirectCast(TheGridRow.FindControl("TxtTaxCode"), TextBox).Text
                End If
                RowTaxComm = DirectCast(TheGridRow.FindControl("HfTaxComm"), HiddenField).Value
                RowTaxCommOnly = DirectCast(TheGridRow.FindControl("HfTaxCommOnly"), HiddenField).Value
                '	ESTIMATE_REV_DET.TAX_CODE,                
                If RowTaxCode <> "" Then
                    If v.ValidateTaxCode(RowTaxCode) = True Then
                        With SQLBody

                            .Append("TAX_CODE = @TAX_CODE")


                            .Append(", ")
                            Dim parameterTAX_CODE As New SqlParameter("@TAX_CODE", SqlDbType.VarChar)
                            parameterTAX_CODE.Value = RowTaxCode
                            arP(13) = parameterTAX_CODE

                            '.Append("TAX_CODE = ")
                            '.Append("'")
                            '.Append(RowTaxCode)
                            '.Append("'")
                            '.Append(", ")
                        End With
                    Else
                        Me.lblMSG.Text = "Invalid Tax Code."
                        Exit Function
                    End If
                    dt = est.GetAddNewTaxData(RowTaxCode)
                    Dim taxresalestate As Double = 0.0
                    Dim taxresalecity As Double = 0.0
                    Dim taxresalecounty As Double = 0.0
                    Dim taxnonresalestate As Decimal = 0.0
                    Dim taxnonresalecity As Decimal = 0.0
                    Dim taxnonresalecounty As Decimal = 0.0
                    Dim taxmarkupstate As Decimal = 0.0
                    Dim taxmarkupcity As Decimal = 0.0
                    Dim taxmarkupcounty As Decimal = 0.0
                    Dim taxcontstate As Decimal = 0.0
                    Dim taxcontcity As Decimal = 0.0
                    Dim taxcontcounty As Decimal = 0.0
                    If dt.Rows.Count > 0 Then
                        With SQLBody

                            .Append("TAX_STATE_PCT = @TAX_STATE_PCT")
                            .Append(", ")
                            Dim parameterTAX_STATE_PCT As New SqlParameter("@TAX_STATE_PCT", SqlDbType.Decimal)
                            parameterTAX_STATE_PCT.Value = dt.Rows(0)("TAX_STATE_PERCENT")
                            arP(14) = parameterTAX_STATE_PCT

                            .Append("TAX_COUNTY_PCT = @TAX_COUNTY_PCT")
                            .Append(", ")
                            Dim parameterTAX_COUNTY_PCT As New SqlParameter("@TAX_COUNTY_PCT", SqlDbType.Decimal)
                            parameterTAX_COUNTY_PCT.Value = dt.Rows(0)("TAX_COUNTY_PERCENT")
                            arP(15) = parameterTAX_COUNTY_PCT

                            .Append("TAX_CITY_PCT = @TAX_CITY_PCT")
                            .Append(", ")
                            Dim parameterTAX_CITY_PCT As New SqlParameter("@TAX_CITY_PCT", SqlDbType.Decimal)
                            parameterTAX_CITY_PCT.Value = dt.Rows(0)("TAX_CITY_PERCENT")
                            arP(16) = parameterTAX_CITY_PCT

                            .Append("TAX_RESALE = @TAX_RESALE")
                            .Append(", ")
                            Dim parameterTAX_RESALE As New SqlParameter("@TAX_RESALE", SqlDbType.SmallInt)
                            parameterTAX_RESALE.Value = dt.Rows(0)("TAX_RESALE")
                            arP(17) = parameterTAX_RESALE



                            '.Append("TAX_STATE_PCT = ")
                            '.Append(dt.Rows(0)("TAX_STATE_PERCENT"))
                            '.Append(", ")
                            '.Append("TAX_COUNTY_PCT = ")
                            '.Append(dt.Rows(0)("TAX_COUNTY_PERCENT"))
                            '.Append(", ")
                            '.Append("TAX_CITY_PCT = ")
                            '.Append(dt.Rows(0)("TAX_CITY_PERCENT"))
                            '.Append(", ")
                            '.Append("TAX_RESALE = ")
                            '.Append(dt.Rows(0)("TAX_RESALE"))
                            '.Append(", ")
                            If dt.Rows(0)("TAX_RESALE") = 1 Then
                                If RowTaxCommOnly <> "1" Then
                                    taxresalestate = RowExtAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                    taxresalecounty = RowExtAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                    taxresalecity = RowExtAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                    'RowLineTotal += Decimal.Parse(taxresalestate.ToString("0.00")) + Decimal.Parse(taxresalecounty.ToString("0.00")) + Decimal.Parse(taxresalecity.ToString("0.00"))
                                    RowLineTotal += Math.Round(taxresalestate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxresalecounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxresalecity, 2, MidpointRounding.AwayFromZero)
                                End If
                                If RowTaxComm = "1" Then
                                    If RowMarkupAmt > 0 Then
                                        taxmarkupstate = RowMarkupAmt * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                        taxmarkupcounty = RowMarkupAmt * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                        taxmarkupcity = RowMarkupAmt * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                        RowLineTotal += Math.Round(taxmarkupstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxmarkupcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxmarkupcity, 2, MidpointRounding.AwayFromZero)
                                        'RowLineTotal += Decimal.Parse(taxmarkupstate.ToString("0.00")) + Decimal.Parse(taxmarkupcounty.ToString("0.00")) + Decimal.Parse(taxmarkupcity.ToString("0.00"))
                                    End If
                                End If

                                .Append("EXT_STATE_RESALE = @EXT_STATE_RESALE")
                                .Append(", ")
                                Dim parameterEXT_STATE_RESALE As New SqlParameter("@EXT_STATE_RESALE", SqlDbType.Decimal)
                                parameterEXT_STATE_RESALE.Value = taxresalestate + taxmarkupstate
                                arP(18) = parameterEXT_STATE_RESALE

                                .Append("EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE")
                                .Append(", ")
                                Dim parameterEXT_COUNTY_RESALE As New SqlParameter("@EXT_COUNTY_RESALE", SqlDbType.Decimal)
                                parameterEXT_COUNTY_RESALE.Value = taxresalecounty + taxmarkupcounty
                                arP(19) = parameterEXT_COUNTY_RESALE

                                .Append("EXT_CITY_RESALE = @EXT_CITY_RESALE")
                                .Append(", ")
                                Dim parameterEXT_CITY_RESALE As New SqlParameter("@EXT_CITY_RESALE", SqlDbType.Decimal)
                                parameterEXT_CITY_RESALE.Value = taxresalecity + taxmarkupcity
                                arP(20) = parameterEXT_CITY_RESALE

                                '.Append("EXT_STATE_RESALE = ")
                                '.Append(taxresalestate + taxmarkupstate)
                                '.Append(", ")
                                '.Append("EXT_COUNTY_RESALE = ")
                                '.Append(taxresalecounty + taxmarkupcounty)
                                '.Append(", ")
                                '.Append("EXT_CITY_RESALE = ")
                                '.Append(taxresalecity + taxmarkupcity)
                                '.Append(", ")
                                If RowContAmt > 0 Then
                                    If RowTaxComm = "1" And RowTaxCommOnly = "1" Then
                                        RowContAmt = RowMuContAmt
                                    ElseIf RowTaxComm = "1" Then
                                        RowContAmt += RowMuContAmt
                                    End If
                                    taxcontstate = RowContAmt * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                    taxcontcounty = RowContAmt * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                    taxcontcity = RowContAmt * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)

                                    .Append("EXT_STATE_CONT = @EXT_STATE_CONT")
                                    .Append(", ")
                                    Dim parameterEXT_STATE_CONT As New SqlParameter("@EXT_STATE_CONT", SqlDbType.Decimal)
                                    parameterEXT_STATE_CONT.Value = taxcontstate
                                    arP(21) = parameterEXT_STATE_CONT

                                    .Append("EXT_COUNTY_CONT = @EXT_COUNTY_CONT")
                                    .Append(", ")
                                    Dim parameterEXT_COUNTY_CONT As New SqlParameter("@EXT_COUNTY_CONT", SqlDbType.Decimal)
                                    parameterEXT_COUNTY_CONT.Value = taxcontcounty
                                    arP(22) = parameterEXT_COUNTY_CONT

                                    .Append("EXT_CITY_CONT = @EXT_CITY_CONT")
                                    .Append(", ")
                                    Dim parameterEXT_CITY_CONT As New SqlParameter("@EXT_CITY_CONT", SqlDbType.Decimal)
                                    parameterEXT_CITY_CONT.Value = taxcontcity
                                    arP(23) = parameterEXT_CITY_CONT

                                    '.Append("EXT_STATE_CONT = ")
                                    '.Append(taxcontstate)
                                    '.Append(", ")
                                    '.Append("EXT_COUNTY_CONT = ")
                                    '.Append(taxcontcounty)
                                    '.Append(", ")
                                    '.Append("EXT_CITY_CONT = ")
                                    '.Append(taxcontcity)
                                    '.Append(", ")
                                    RowLineTotalCont += Math.Round(taxcontstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcity, 2, MidpointRounding.AwayFromZero)
                                End If
                            End If
                            If dt.Rows(0)("TAX_RESALE") <> 1 Then
                                If RowFunctionType = "V" Then
                                    If RowTaxCommOnly <> "1" Then
                                        taxnonresalestate = RowExtAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                        taxnonresalecounty = RowExtAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                        taxnonresalecity = RowExtAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                        Dim trstate As Decimal = RowExtAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                        Dim trcounty As Decimal = RowExtAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                        Dim trcity As Decimal = RowExtAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                        RowLineTotal += Math.Round(trstate, 2, MidpointRounding.AwayFromZero) + Math.Round(trcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(trcity, 2, MidpointRounding.AwayFromZero)

                                        .Append("EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                                        .Append(", ")
                                        Dim parameterEXT_NONRESALE_TAX As New SqlParameter("@EXT_NONRESALE_TAX", SqlDbType.Decimal)
                                        parameterEXT_NONRESALE_TAX.Value = taxnonresalestate + taxnonresalecounty + taxnonresalecity
                                        arP(24) = parameterEXT_NONRESALE_TAX

                                        '.Append("EXT_NONRESALE_TAX = ")
                                        '.Append(taxnonresalestate + taxnonresalecounty + taxnonresalecity)
                                        '.Append(", ")
                                    End If
                                    If RowContAmt > 0 Then
                                        If RowTaxComm = "1" And RowTaxCommOnly = "1" Then
                                            RowContAmt = RowMuContAmt
                                        ElseIf RowTaxComm = "1" Then
                                            RowContAmt += RowMuContAmt
                                        End If
                                        taxcontstate = RowContAmt * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                        taxcontcounty = RowContAmt * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                        taxcontcity = RowContAmt * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)

                                        .Append("EXT_NR_CONT = @EXT_NR_CONT")
                                        .Append(", ")
                                        Dim parameterEXT_NR_CONT As New SqlParameter("@EXT_NR_CONT", SqlDbType.Decimal)
                                        parameterEXT_NR_CONT.Value = taxcontstate + taxcontcounty + taxcontcity
                                        arP(25) = parameterEXT_NR_CONT

                                        '.Append("EXT_NR_CONT = ")
                                        '.Append(taxcontstate + taxcontcounty + taxcontcity)
                                        '.Append(", ")
                                        RowLineTotalCont += Math.Round(taxcontstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcity, 2, MidpointRounding.AwayFromZero)
                                    End If
                                ElseIf RowFunctionType = "E" Or RowFunctionType = "I" Then
                                    If RowTaxCommOnly <> "1" Then
                                        taxresalestate = RowExtAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                        taxresalecounty = RowExtAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                        taxresalecity = RowExtAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                        RowLineTotal += Math.Round(taxresalestate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxresalecounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxresalecity, 2, MidpointRounding.AwayFromZero)
                                    End If
                                    If RowContAmt > 0 Then
                                        If RowTaxComm = "1" And RowTaxCommOnly = "1" Then
                                            RowContAmt = RowMuContAmt
                                        ElseIf RowTaxComm = "1" Then
                                            RowContAmt += RowMuContAmt
                                        End If
                                        taxcontstate = RowContAmt * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                        taxcontcounty = RowContAmt * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                        taxcontcity = RowContAmt * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)

                                        .Append("EXT_STATE_CONT = @EXT_STATE_CONT")
                                        .Append(", ")
                                        Dim parameterEXT_STATE_CONT As New SqlParameter("@EXT_STATE_CONT", SqlDbType.Decimal)
                                        parameterEXT_STATE_CONT.Value = taxcontstate
                                        arP(26) = parameterEXT_STATE_CONT

                                        .Append("EXT_COUNTY_CONT = @EXT_COUNTY_CONT")
                                        .Append(", ")
                                        Dim parameterEXT_COUNTY_CONT As New SqlParameter("@EXT_COUNTY_CONT", SqlDbType.Decimal)
                                        parameterEXT_COUNTY_CONT.Value = taxcontcounty
                                        arP(27) = parameterEXT_COUNTY_CONT

                                        .Append("EXT_CITY_CONT = @EXT_CITY_CONT")
                                        .Append(", ")
                                        Dim parameterEXT_CITY_CONT As New SqlParameter("@EXT_CITY_CONT", SqlDbType.Decimal)
                                        parameterEXT_CITY_CONT.Value = taxcontcity
                                        arP(28) = parameterEXT_CITY_CONT

                                        '.Append("EXT_STATE_CONT = ")
                                        '.Append(taxcontstate)
                                        '.Append(", ")
                                        '.Append("EXT_COUNTY_CONT = ")
                                        '.Append(taxcontcounty)
                                        '.Append(", ")
                                        '.Append("EXT_CITY_CONT = ")
                                        '.Append(taxcontcity)
                                        '.Append(", ")
                                        RowLineTotalCont += Math.Round(taxcontstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcity, 2, MidpointRounding.AwayFromZero)
                                    End If
                                End If
                                If RowTaxComm = "1" Then
                                    If RowMarkupAmt > 0 Then
                                        taxmarkupstate = RowMarkupAmt * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                        taxmarkupcounty = RowMarkupAmt * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                        taxmarkupcity = RowMarkupAmt * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                        RowLineTotal += Math.Round(taxmarkupstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxmarkupcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxmarkupcity, 2, MidpointRounding.AwayFromZero)
                                    End If
                                End If

                                .Append("EXT_STATE_RESALE = @EXT_STATE_RESALE")
                                .Append(", ")
                                Dim parameterEXT_STATE_RESALE As New SqlParameter("@EXT_STATE_RESALE", SqlDbType.Decimal)
                                parameterEXT_STATE_RESALE.Value = taxresalestate + taxmarkupstate
                                arP(29) = parameterEXT_STATE_RESALE

                                .Append("EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE")
                                .Append(", ")
                                Dim parameterEXT_COUNTY_RESALE As New SqlParameter("@EXT_COUNTY_RESALE", SqlDbType.Decimal)
                                parameterEXT_COUNTY_RESALE.Value = taxresalecounty + taxmarkupcounty
                                arP(30) = parameterEXT_COUNTY_RESALE

                                .Append("EXT_CITY_RESALE = @EXT_CITY_RESALE")
                                .Append(", ")
                                Dim parameterEXT_CITY_RESALE As New SqlParameter("@EXT_CITY_RESALE", SqlDbType.Decimal)
                                parameterEXT_CITY_RESALE.Value = taxresalecity + taxmarkupcity
                                arP(31) = parameterEXT_CITY_RESALE

                                '.Append("EXT_STATE_RESALE = ")
                                '.Append(taxresalestate + taxmarkupstate)
                                '.Append(", ")
                                '.Append("EXT_COUNTY_RESALE = ")
                                '.Append(taxresalecounty + taxmarkupcounty)
                                '.Append(", ")
                                '.Append("EXT_CITY_RESALE = ")
                                '.Append(taxresalecity + taxmarkupcity)
                                '.Append(", ")
                            End If


                        End With
                    End If
                Else
                    SQLBody.Append("TAX_CODE = NULL, ")
                    SQLBody.Append("TAX_STATE_PCT = 0, ")
                    SQLBody.Append("TAX_COUNTY_PCT = 0, ")
                    SQLBody.Append("TAX_CITY_PCT = 0, ")
                    SQLBody.Append("TAX_RESALE = 0, ")
                    SQLBody.Append("EXT_STATE_RESALE = 0, ")
                    SQLBody.Append("EXT_COUNTY_RESALE = 0, ")
                    SQLBody.Append("EXT_CITY_RESALE = 0, ")
                    SQLBody.Append("EXT_STATE_CONT = 0, ")
                    SQLBody.Append("EXT_COUNTY_CONT = 0, ")
                    SQLBody.Append("EXT_CITY_CONT = 0, ")
                End If
                'End If
            Catch ex As Exception
            End Try

            'Try
            '    If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colLINE_TOTAL").Display = True Then
            '        If IsNumeric(DirectCast(TheGridRow.FindControl("TxtLINE_TOTAL"), TextBox).Text) Then
            '            RowLineTotal = CType(DirectCast(TheGridRow.FindControl("TxtLINE_TOTAL"), TextBox).Text, Decimal)
            '            With SQLBody
            '                .Append("LINE_TOTAL = ")
            '                .Append(RowLineTotal)
            '                .Append(", ")        '                
            '            End With
            '        Else
            '            SQLBody.Append("LINE_TOTAL = NULL, ")
            '        End If
            '    End If
            'Catch ex As Exception
            'End Try

            'RowLineTotalCont += RowContAmt
            RowLineTotal += RowExtAmount + RowMarkupAmt
            Try
                With SQLBody

                    .Append("LINE_TOTAL = @LINE_TOTAL")
                    .Append(", ")
                    Dim parameterLINE_TOTAL As New SqlParameter("@LINE_TOTAL", SqlDbType.Decimal)
                    parameterLINE_TOTAL.Value = RowLineTotal
                    arP(32) = parameterLINE_TOTAL

                    .Append("LINE_TOTAL_CONT = @LINE_TOTAL_CONT")
                    .Append(", ")
                    Dim parameterLINE_TOTAL_CONT As New SqlParameter("@LINE_TOTAL_CONT", SqlDbType.Decimal)
                    parameterLINE_TOTAL_CONT.Value = RowLineTotalCont
                    arP(33) = parameterLINE_TOTAL_CONT

                    '.Append("LINE_TOTAL = ")
                    '.Append(RowLineTotal)
                    '.Append(", ")
                    '.Append("LINE_TOTAL_CONT = ")
                    '.Append(RowLineTotalCont)
                    '.Append(", ")
                End With
            Catch ex As Exception
            End Try
            RowExtAmount = 0.0
            RowLineTotal = 0.0
            RowLineTotalCont = 0.0
            RowContAmt = 0.0
            RowMarkupAmt = 0.0
            Try
                If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colCPU").Display = True Then
                    RowCPU = DirectCast(TheGridRow.FindControl("ChkCPU"), CheckBox).Checked
                    'JOB_TRAFFIC_DET.MILESTONE
                    With SQLBody
                        .Append("INCL_CPU = ")
                        If RowCPU = True Then
                            .Append("1")
                        Else
                            .Append("0")
                        End If
                        .Append(", ")
                    End With
                End If
            Catch ex As Exception
            End Try

            Dim str As String = SQLBody.ToString
            str = MiscFN.RemoveTrailingDelimiter(str, ",")

            Dim FullSQLString As String = SQLPrefix & str & SQLSuffix

            'FullSQLString &= SavePredList(RowTask_JobNum, RowTask_JobComp, RowTask_SeqNum, RowPredecessorsString)

            'Compare to dataset to get changes,Validate changes:


            'Save:
            SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, FullSQLString, arP)
            'Using MyConn As New SqlConnection(Session("ConnString"))
            '    MyConn.Open()
            '    Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
            '    Dim MyCmd As New SqlCommand(FullSQLString, MyConn, MyTrans)
            '    Try
            '        MyCmd.ExecuteNonQuery()
            '        MyTrans.Commit()
            '    Catch ex As Exception
            '        MyTrans.Rollback()
            '    Finally
            '        If MyConn.State = ConnectionState.Open Then MyConn.Close()
            '    End Try
            'End Using

        End If




        'If RebindGrid = True Then
        '    Me.RefreshGrid()
        'End If

    End Function

    Private Sub SetGridSort(ByVal StrSort As String)
        Try
            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression
            Dim GrpByField As Telerik.Web.UI.GridGroupByField
            Dim SortExpr As Telerik.Web.UI.GridSortExpression
            Select Case StrSort
                Case "seqnbr"
                    Me.RadGridEstimateQuoteDetails.MasterTableView.GroupByExpressions.Clear()
                    'SortExpr.FieldName = "SEQ_NBR"
                    'SortExpr.SortOrder = GridSortOrder.Ascending
                    Me.RadGridEstimateQuoteDetails.MasterTableView.SortExpressions.AddSortExpression("SEQ_NBR")
                Case "funccode"
                    Me.RadGridEstimateQuoteDetails.MasterTableView.GroupByExpressions.Clear()
                    Me.RadGridEstimateQuoteDetails.MasterTableView.SortExpressions.AddSortExpression("IS_USER_ROW DESC")
                    'SortExpr = Telerik.Web.UI.GridSortExpression.Parse("IS_USER_ROW")
                    'With Me.RadGridEstimateQuoteDetails
                    '    .MasterTableView.SortExpressions.Clear()
                    '    .MasterTableView.SortExpressions.Add(GrpExpr)
                    'End With
                Case "conscode"
                    GrpExpr = Telerik.Web.UI.GridGroupByExpression.Parse("FNC_CONSOL_DESC Consol Group By FNC_CONSOLIDATION, IS_USER_ROW DESC")
                    'GrpByField.Aggregate = Telerik.Web.UI.GridAggregateFunction.Sum
                    'GrpExpr.GroupByFields.Add(GrpByField)
                    With Me.RadGridEstimateQuoteDetails
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True
                        .MasterTableView.ShowGroupFooter = True
                        .MasterTableView.GroupHeaderItemStyle.HorizontalAlign = WebControls.HorizontalAlign.Left
                        '.MasterTableView.GetColumn("colPHASE_DESC").Display = False
                    End With
                Case "functype"
                    'GrpExpr = New Telerik.Web.UI.GridGroupByExpression
                    'GrpByField = New Telerik.Web.UI.GridGroupByField
                    GrpExpr = Telerik.Web.UI.GridGroupByExpression.Parse("FNC_TYPE Type Group By FNC_TYPE, IS_USER_ROW DESC")
                    'GrpByField.FieldName = "EST_REV_QUANTITY"
                    'GrpByField.Aggregate = Telerik.Web.UI.GridAggregateFunction.Sum
                    'GrpExpr.GroupByFields.Add(GrpByField)
                    With Me.RadGridEstimateQuoteDetails
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True
                        .MasterTableView.ShowGroupFooter = True
                        .MasterTableView.GroupHeaderItemStyle.HorizontalAlign = WebControls.HorizontalAlign.Left
                        .MasterTableView.FooterStyle.HorizontalAlign = WebControls.HorizontalAlign.Center
                        '.MasterTableView.GetColumn("colPHASE_DESC").Display = False
                    End With
                Case "funcheading"
                    GrpExpr = Telerik.Web.UI.GridGroupByExpression.Parse("FNC_HEADING_DESC Heading Group By FNC_HEADING_SEQ, FNC_HEADING_DESC")
                    'GrpByField.Aggregate = Telerik.Web.UI.GridAggregateFunction.Sum
                    'GrpExpr.GroupByFields.Add(GrpByField)
                    With Me.RadGridEstimateQuoteDetails
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True
                        .MasterTableView.ShowGroupFooter = True
                        .MasterTableView.GroupHeaderItemStyle.HorizontalAlign = WebControls.HorizontalAlign.Left
                        '.MasterTableView.GetColumn("colPHASE_DESC").Display = False
                    End With
            End Select
            'Session("EstimateGridSort") = StrSort
        Catch ex As Exception

        End Try
    End Sub

    Dim dtColumns As New DataTable
    Private Function GetGridColumnsToDisplay() As DataTable
        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim dt As New DataTable
        dt = est.GetEstimateColumns(Session("EmpCode"), True, False, False)
        Return dt
    End Function

    Private Sub SetEstimateGridColumns()
        dtColumns = GetGridColumnsToDisplay()
        If dtColumns.Rows.Count > 0 Then
            Dim ThisColumnName As String = ""
            For i As Integer = 0 To dtColumns.Rows.Count - 1
                ThisColumnName = dtColumns.Rows(i)("COLUMN_NAME")
                If ThisColumnName.IndexOf(",") > 0 Then
                    Dim ar() As String
                    ar = ThisColumnName.Split(",")
                    For j As Integer = 0 To ar.Length - 1
                        Try
                            With Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn(ar(j))
                                .Display = CType(dtColumns.Rows(i)("SHOW_ON_GRID"), Boolean)
                                If j = 0 Then
                                    '.HeaderText = dtColumns.Rows(i)("HEADER_TEXT")
                                End If
                            End With
                        Catch ex As Exception
                        End Try
                    Next
                Else
                    Try
                        With Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn(ThisColumnName)
                            .Display = CType(dtColumns.Rows(i)("SHOW_ON_GRID"), Boolean)
                            '.HeaderText = dtColumns.Rows(i)("HEADER_TEXT")
                        End With
                    Catch ex As Exception
                    End Try
                End If
                Try
                    'If Me.RadGridEstimate.MasterTableView.GetColumn("colPHASE_DESC").Display = True Then
                    '    Session("HasPhaseColumn") = "True"
                    'ElseIf Me.RadGridEstimate.MasterTableView.GetColumn("colPHASE_DESC").Display = False Then
                    '    Session("HasPhaseColumn") = "False"
                    'End If
                    'If ThisColumnName = "colPHASE_DESC" Then
                    '    Session("HasPhaseColumn") = "True"
                    '    'Else
                    '    '    Session("HasPhaseColumn") = "False"
                    'End If
                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    'Private mDtQuoteFunctions As New DataTable
    'Private Function createSummaryTable(ByVal dr As SqlDataReader)
    '    Dim dt As DataTable
    '    Dim row As DataRow
    '    Dim prevFncType, fncType, fncCode, fncDesc As String

    '    Me.CreateEstimateQuoteDetailsDatatable()
    '    Try
    '        prevFncType = ""

    '        Do While dr.Read
    '            fncType = dr.GetString(2)
    '            QoutQtyHrs = dr.GetDecimal(3)
    '            QQuoteAmountGrpTotal = dr.GetDecimal(4)
    '            QQuotedMarkupTotal = dr.GetDecimal(5)
    '            QQuotedTaxTotal = dr.GetDecimal(6)
    '            ' QQuotedTotalTotal = dr.GetDecimal(7)
    '            QActualHoursTotal = dr.GetDecimal(8)
    '            QActualAmountTotal = dr.GetDecimal(9)
    '            QActualMarkupTotal = dr.GetDecimal(10)
    '            QActualTaxTotal = dr.GetDecimal(11)
    '            QActualTotalTotal = dr.GetDecimal(12)
    '            QOpenPONetAmtTotal = dr.GetDecimal(13)
    '            QBilledToDateTotal = dr.GetDecimal(14)
    '            QQuotedvsActualPOTotal = dr.GetDecimal(15)
    '            QActualPOvsBilledTotal = dr.GetDecimal(16)
    '            QPERCENT_QUOTETOTAL = dr.GetDecimal(29)
    '            QBillingApprovedPendingTotlal = dr.GetDecimal(28)

    '            ActQtyHrs = dr.GetDecimal(8)

    '            If fncType <> prevFncType Then
    '                If prevFncType <> "" Then
    '                    row.Item("FNC_TYPE") = "Subtotal"
    '                    If QuotedHrsGrpTotal > 0 Then
    '                        PERCENT_QUOOTETOTAL = (ActualHrsGrpTotal / QuotedHrsGrpTotal) * 100
    '                    Else
    '                        PERCENT_QUOOTETOTAL = 0.0
    '                    End If
    '                    row.Item("QuotedAmount") = QuoteAmountGrpTotal.ToString("#,##0.00")
    '                    row.Item("QuotedQtyHrs") = QuotedHrsGrpTotal.ToString("#,##0.00")
    '                    row.Item("QuotedMarkup") = QuotedMarkupTotal.ToString("#,##0.00")
    '                    row.Item("QuotedTax") = QuotedTaxTotal.ToString("#,##0.00")
    '                    '  row.Item("QuotedTotal") = QuotedTotalTotal.ToString("#,##0.00")
    '                    row.Item("ActualHours") = ActualHrsGrpTotal.ToString("#,##0.00")
    '                    row.Item("ActualAmount") = ActualAmountTotal.ToString("#,##0.00")
    '                    row.Item("ActualMarkup") = ActualMarkupTotal.ToString("#,##0.00")
    '                    row.Item("ActualTax") = ActualTaxTotal.ToString("#,##0.00")
    '                    row.Item("ActualTotal") = ActualTotalTotal.ToString("#,##0.00")
    '                    row.Item("OpenPONetAmt") = OpenPONetAmtTotal.ToString("#,##0.00")
    '                    row.Item("BilledToDate") = BilledToDateTotal.ToString("#,##0.00")
    '                    row.Item("QuotedvsActualPO") = QuotedvsActualPOTotal.ToString("#,##0.00")
    '                    row.Item("ActualPOvsBilled") = ActualPOvsBilledTotal.ToString("#,##0.00")
    '                    row.Item("APPROVED_AMT") = BillingApprovedPendingTotlal.ToString("#,##0.00")
    '                    row.Item("PERCENT_QUOTE") = PERCENT_QUOOTETOTAL.ToString("#,##0.00")


    '                    'Add row for space
    '                    dt.Rows.Add(row)
    '                    row = dt.NewRow
    '                    row.Item("FNC_TYPE") = ""

    '                    'Add another row for next detail row of data
    '                    dt.Rows.Add(row)
    '                    row = dt.NewRow
    '                End If

    '                QuotedHrsGrpTotal = QoutQtyHrs
    '                QuoteAmountGrpTotal = QQuoteAmountGrpTotal
    '                ActualHrsGrpTotal = ActQtyHrs
    '                QuotedMarkupTotal = QQuotedMarkupTotal
    '                QuotedTaxTotal = QQuotedTaxTotal
    '                ' QuotedTotalTotal = QQuotedTotalTotal
    '                ActualHoursTotal = QActualHoursTotal
    '                ActualAmountTotal = QActualAmountTotal
    '                ActualMarkupTotal = QActualMarkupTotal
    '                ActualTaxTotal = QActualTaxTotal
    '                ActualTotalTotal = QActualTotalTotal
    '                OpenPONetAmtTotal = QOpenPONetAmtTotal
    '                BilledToDateTotal = QBilledToDateTotal
    '                QuotedvsActualPOTotal = QQuotedvsActualPOTotal
    '                ActualPOvsBilledTotal = QActualPOvsBilledTotal
    '                PERCENT_QUOOTETOTAL = QPERCENT_QUOTETOTAL
    '                BillingApprovedPendingTotlal = QBillingApprovedPendingTotlal

    '                prevFncType = fncType

    '            Else
    '                QuoteAmountGrpTotal = QuoteAmountGrpTotal + QQuoteAmountGrpTotal
    '                QuotedHrsGrpTotal = QuotedHrsGrpTotal + QoutQtyHrs
    '                ActualHrsGrpTotal = ActualHrsGrpTotal + ActQtyHrs
    '                QuotedMarkupTotal += QQuotedMarkupTotal
    '                QuotedTaxTotal += QQuotedTaxTotal
    '                '   QuotedTotalTotal += QQuotedTotalTotal
    '                ActualHoursTotal += QActualHoursTotal
    '                ActualAmountTotal += QActualAmountTotal
    '                ActualMarkupTotal += QActualMarkupTotal
    '                ActualTaxTotal += QActualTaxTotal
    '                ActualTotalTotal += QActualTotalTotal
    '                OpenPONetAmtTotal += QOpenPONetAmtTotal
    '                BilledToDateTotal += QBilledToDateTotal
    '                QuotedvsActualPOTotal += QQuotedvsActualPOTotal
    '                ActualPOvsBilledTotal += QActualPOvsBilledTotal
    '                PERCENT_QUOOTETOTAL += QPERCENT_QUOTETOTAL
    '                BillingApprovedPendingTotlal += QBillingApprovedPendingTotlal

    '            End If

    '            row.Item("FNC_TYPE") = fncType
    '            row.Item("FNC_CODE") = dr.GetString(0)
    '            row.Item("FNC_DESC") = dr.GetString(1)
    '            row.Item("QuotedQtyHrs") = QoutQtyHrs.ToString("#,##0.00")
    '            row.Item("QuotedAmount") = QQuoteAmountGrpTotal.ToString("#,##0.00") 'dr.GetDecimal(4).ToString("#,##0.00")
    '            row.Item("QuotedMarkup") = QQuotedMarkupTotal.ToString("#,##0.00")
    '            row.Item("QuotedTax") = QQuotedTaxTotal.ToString("#,##0.00")
    '            '    row.Item("QuotedTotal") = QQuotedTotalTotal.ToString("#,##0.00")

    '            row.Item("ActualHours") = ActQtyHrs.ToString("#,##0.00")

    '            row.Item("ActualAmount") = QActualAmountTotal.ToString("#,##0.00")
    '            row.Item("ActualMarkup") = QActualMarkupTotal.ToString("#,##0.00")
    '            row.Item("ActualTax") = QActualTaxTotal.ToString("#,##0.00")
    '            row.Item("ActualTotal") = QActualTotalTotal.ToString("#,##0.00")
    '            row.Item("OpenPONetAmt") = QOpenPONetAmtTotal.ToString("#,##0.00")
    '            row.Item("BilledToDate") = QBilledToDateTotal.ToString("#,##0.00")
    '            row.Item("QuotedvsActualPO") = QQuotedvsActualPOTotal.ToString("#,##0.00")
    '            row.Item("ActualPOvsBilled") = QActualPOvsBilledTotal.ToString("#,##0.00")
    '            row.Item("Qva") = dr.GetDecimal(17)
    '            row.Item("Avb") = dr.GetDecimal(18)
    '            row.Item("QvaPO") = dr.GetDecimal(19)
    '            row.Item("AvbPO") = dr.GetDecimal(20)
    '            row.Item("NBActualTotal") = dr.GetDecimal(21)
    '            row.Item("AdvBilled") = dr.GetDecimal(22)
    '            row.Item("POTotal") = dr.GetDecimal(23)
    '            row.Item("POApplied") = dr.GetDecimal(24)
    '            row.Item("NBTax") = dr.GetDecimal(25)
    '            row.Item("NBMarkup") = dr.GetDecimal(26)
    '            row.Item("NBAmount") = dr.GetDecimal(27)
    '            row.Item("APPROVED_AMT") = QBillingApprovedPendingTotlal.ToString("#,##0.00")
    '            row.Item("PERCENT_QUOTE") = QPERCENT_QUOTETOTAL.ToString("#,##0.00") 'dr.Item("PERCENT_QUOTE").ToString("#,##0.00")
    '            dt.Rows.Add(row)
    '            row = dt.NewRow
    '        Loop

    '        row.Item("FNC_TYPE") = "Subtotal"
    '        row.Item("QuotedAmount") = QuoteAmountGrpTotal.ToString("#,##0.00")
    '        row.Item("QuotedQtyHrs") = QuotedHrsGrpTotal.ToString("#,##0.00")
    '        row.Item("ActualHours") = ActualHrsGrpTotal.ToString("#,##0.00")
    '        '***************************************
    '        row.Item("QuotedMarkup") = QuotedMarkupTotal.ToString("#,##0.00")
    '        row.Item("QuotedTax") = QuotedTaxTotal.ToString("#,##0.00")
    '        ' row.Item("QuotedTotal") = QuotedTotalTotal.ToString("#,##0.00")
    '        row.Item("ActualAmount") = ActualAmountTotal.ToString("#,##0.00")
    '        row.Item("ActualMarkup") = ActualMarkupTotal.ToString("#,##0.00")
    '        row.Item("ActualTax") = ActualTaxTotal.ToString("#,##0.00")
    '        row.Item("ActualTotal") = ActualTotalTotal.ToString("#,##0.00")
    '        row.Item("OpenPONetAmt") = OpenPONetAmtTotal.ToString("#,##0.00")
    '        row.Item("BilledToDate") = BilledToDateTotal.ToString("#,##0.00")
    '        row.Item("QuotedvsActualPO") = QuotedvsActualPOTotal.ToString("#,##0.00")
    '        row.Item("ActualPOvsBilled") = ActualPOvsBilledTotal.ToString("#,##0.00")
    '        row.Item("APPROVED_AMT") = BillingApprovedPendingTotlal.ToString("#,##0.00")
    '        row.Item("PERCENT_QUOTE") = PERCENT_QUOOTETOTAL.ToString("#,##0.00")

    '        '***************************************
    '        dt.Rows.Add(row)
    '        row = dt.NewRow

    '        dr.Close()
    '        Return dt

    '    Catch ex As Exception
    '        lblMsg.Text = ex.Message.Trim
    '    End Try

    'End Function

    'Private Sub CreateEstimateQuoteDetailsDatatable()
    '    'Initial mod of this base table
    '    'once it comes in and out of the class, mods should be there for use in other fn's
    '    Dim Pk(0) As DataColumn

    '    Dim COL_INDEX As DataColumn = New DataColumn("INDEX")
    '    With COL_INDEX
    '        .DataType = GetType(Int32)
    '        .AutoIncrement = True
    '        .AutoIncrementSeed = 1
    '        .AutoIncrementStep = 1
    '    End With
    '    Pk(0) = COL_INDEX

    '    Dim COL_ESTIMATE_NUMBER As DataColumn = New DataColumn("ESTIMATE_NUMBER")
    '    COL_ESTIMATE_NUMBER.DataType = GetType(Int32)

    '    Dim COL_EST_COMPONENT_NBR As DataColumn = New DataColumn("EST_COMPONENT_NBR")
    '    COL_EST_COMPONENT_NBR.DataType = GetType(Int32)

    '    Dim COL_EST_QUOTE_NBR As DataColumn = New DataColumn("EST_QUOTE_NBR")
    '    COL_EST_QUOTE_NBR.DataType = GetType(Int32)

    '    Dim COL_EST_QUOTE_DESC As DataColumn = New DataColumn("EST_QUOTE_DESC")
    '    COL_EST_QUOTE_DESC.DataType = GetType(String)

    '    Dim COL_EST_REV_NBR As DataColumn = New DataColumn("EST_REV_NBR")
    '    COL_EST_REV_NBR.DataType = GetType(Int32)

    '    Dim COL_SEQ_NBR As DataColumn = New DataColumn("SEQ_NBR")
    '    COL_SEQ_NBR.DataType = GetType(Int32)

    '    Dim COL_FNC_CODE As DataColumn = New DataColumn("FNC_CODE")
    '    COL_FNC_CODE.DataType = GetType(String)

    '    Dim COL_FNC_DESCRIPTION As DataColumn = New DataColumn("FNC_DESCRIPTION")
    '    COL_FNC_DESCRIPTION.DataType = GetType(String)

    '    Dim COL_EST_FNC_COMMENT As DataColumn = New DataColumn("EST_FNC_COMMENT")
    '    COL_EST_FNC_COMMENT.DataType = GetType(String)

    '    Dim COL_EST_REV_SUP_BY_CDE As DataColumn = New DataColumn("EST_REV_SUP_BY_CDE")
    '    COL_EST_REV_SUP_BY_CDE.DataType = GetType(String)

    '    Dim COL_EST_REV_SUP_BY_NTE As DataColumn = New DataColumn("EST_REV_SUP_BY_NTE")
    '    COL_EST_REV_SUP_BY_NTE.DataType = GetType(String)

    '    Dim COL_EST_REV_QUANTITY As DataColumn = New DataColumn("EST_REV_QUANTITY")
    '    COL_EST_REV_QUANTITY.DataType = GetType(Decimal)

    '    Dim COL_EST_REV_RATE As DataColumn = New DataColumn("EST_REV_RATE")
    '    COL_EST_REV_RATE.DataType = GetType(Decimal)

    '    Dim COL_EST_REV_EXT_AMT As DataColumn = New DataColumn("EST_REV_EXT_AMT")
    '    COL_EST_REV_EXT_AMT.DataType = GetType(Decimal)

    '    Dim COL_TAX_CODE As DataColumn = New DataColumn("TAX_CODE")
    '    COL_TAX_CODE.DataType = GetType(String)

    '    Dim COL_EST_REV_COMM_PCT As DataColumn = New DataColumn("EST_REV_COMM_PCT")
    '    COL_EST_REV_COMM_PCT.DataType = GetType(Decimal)

    '    Dim COL_EXT_MARKUP_AMT As DataColumn = New DataColumn("EXT_MARKUP_AMT")
    '    COL_EXT_MARKUP_AMT.DataType = GetType(Decimal)

    '    Dim COL_LINE_TOTAL As DataColumn = New DataColumn("LINE_TOTAL")
    '    COL_LINE_TOTAL.DataType = GetType(Decimal)

    '    Dim COL_EST_REV_CONT_PCT As DataColumn = New DataColumn("EST_REV_CONT_PCT")
    '    COL_EST_REV_CONT_PCT.DataType = GetType(Decimal)

    '    Dim COL_EXT_CONTINGENCY As DataColumn = New DataColumn("EXT_CONTINGENCY")
    '    COL_EXT_CONTINGENCY.DataType = GetType(Decimal)

    '    Dim COL_INCL_CPU As DataColumn = New DataColumn("INCL_CPU")
    '    COL_INCL_CPU.DataType = GetType(Int32)

    '    Dim COL_TAX_STATE_PCT As DataColumn = New DataColumn("TAX_STATE_PCT")
    '    COL_TAX_STATE_PCT.DataType = GetType(Decimal)

    '    Dim COL_TAX_COUNTY_PCT As DataColumn = New DataColumn("TAX_COUNTY_PCT")
    '    COL_TAX_COUNTY_PCT.DataType = GetType(Decimal)

    '    Dim COL_TAX_CITY_PCT As DataColumn = New DataColumn("TAX_CITY_PCT")
    '    COL_TAX_CITY_PCT.DataType = GetType(Decimal)

    '    Dim COL_TAX_COMM As DataColumn = New DataColumn("TAX_COMM")
    '    COL_TAX_COMM.DataType = GetType(Int32)

    '    Dim COL_TAX_COMM_ONLY As DataColumn = New DataColumn("TAX_COMM_ONLY")
    '    COL_TAX_COMM_ONLY.DataType = GetType(Int32)

    '    Dim COL_TAX_RESALE As DataColumn = New DataColumn("TAX_RESALE")
    '    COL_TAX_RESALE.DataType = GetType(Int32)

    '    Dim COL_EXT_NONRESALE_TAX As DataColumn = New DataColumn("EXT_NONRESALE_TAX")
    '    COL_EXT_NONRESALE_TAX.DataType = GetType(Decimal)

    '    Dim COL_EXT_STATE_RESALE As DataColumn = New DataColumn("EXT_STATE_RESALE")
    '    COL_EXT_STATE_RESALE.DataType = GetType(Decimal)

    '    Dim COL_EXT_COUNTY_RESALE As DataColumn = New DataColumn("EXT_COUNTY_RESALE")
    '    COL_EXT_COUNTY_RESALE.DataType = GetType(Decimal)

    '    Dim COL_EXT_CITY_RESALE As DataColumn = New DataColumn("EXT_CITY_RESALE")
    '    COL_EXT_CITY_RESALE.DataType = GetType(Decimal)

    '    Dim COL_EXT_MU_CONT As DataColumn = New DataColumn("EXT_MU_CONT")
    '    COL_EXT_MU_CONT.DataType = GetType(Decimal)

    '    Dim COL_EXT_STATE_CONT As DataColumn = New DataColumn("EXT_STATE_CONT")
    '    COL_EXT_STATE_CONT.DataType = GetType(Decimal)

    '    Dim COL_EXT_COUNTY_CONT As DataColumn = New DataColumn("EXT_COUNTY_CONT")
    '    COL_EXT_COUNTY_CONT.DataType = GetType(Decimal)

    '    Dim COL_EXT_CITY_CONT As DataColumn = New DataColumn("EXT_CITY_CONT")
    '    COL_EXT_CITY_CONT.DataType = GetType(Decimal)

    '    Dim COL_EXT_NR_CONT As DataColumn = New DataColumn("EXT_NR_CONT")
    '    COL_EXT_NR_CONT.DataType = GetType(Decimal)

    '    Dim COL_LINE_TOTAL_CONT As DataColumn = New DataColumn("LINE_TOTAL_CONT")
    '    COL_LINE_TOTAL_CONT.DataType = GetType(Decimal)

    '    Dim COL_EST_CPM_FLAG As DataColumn = New DataColumn("EST_CPM_FLAG")
    '    COL_EST_CPM_FLAG.DataType = GetType(Int32)

    '    Dim COL_EST_FNC_TYPE As DataColumn = New DataColumn("EST_FNC_TYPE")
    '    COL_EST_FNC_TYPE.DataType = GetType(String)

    '    Dim COL_EST_COMM_FLAG As DataColumn = New DataColumn("EST_COMM_FLAG")
    '    COL_EST_COMM_FLAG.DataType = GetType(Int32)

    '    Dim COL_EST_TAX_FLAG As DataColumn = New DataColumn("EST_TAX_FLAG")
    '    COL_EST_TAX_FLAG.DataType = GetType(Int32)

    '    Dim COL_EST_NONBILL_FLAG As DataColumn = New DataColumn("EST_NONBILL_FLAG")
    '    COL_EST_NONBILL_FLAG.DataType = GetType(Int32)

    '    Dim COL_FEE_TIME As DataColumn = New DataColumn("FEE_TIME")
    '    COL_FEE_TIME.DataType = GetType(Int32)

    '    Dim COL_EMPLOYEE_TITLE_ID As DataColumn = New DataColumn("EMPLOYEE_TITLE_ID")
    '    COL_EMPLOYEE_TITLE_ID.DataType = GetType(Int32)

    '    Dim COL_FNC_TYPE As DataColumn = New DataColumn("FNC_TYPE")
    '    COL_FNC_TYPE.DataType = GetType(String)

    '    Dim COL_EST_PHASE_ID As DataColumn = New DataColumn("EST_PHASE_ID")
    '    COL_EST_PHASE_ID.DataType = GetType(Int32)

    '    Dim COL_EST_PHASE_DESC As DataColumn = New DataColumn("EST_PHASE_DESC")
    '    COL_EST_PHASE_DESC.DataType = GetType(String)

    '    Dim COL_FNC_HEADING_ID As DataColumn = New DataColumn("FNC_HEADING_ID")
    '    COL_FNC_HEADING_ID.DataType = GetType(Int32)

    '    Dim COL_FNC_HEADING_DESC As DataColumn = New DataColumn("FNC_HEADING_DESC")
    '    COL_FNC_HEADING_DESC.DataType = GetType(String)

    '    Dim COL_FNC_HEADING_SEQ As DataColumn = New DataColumn("FNC_HEADING_SEQ")
    '    COL_FNC_HEADING_SEQ.DataType = GetType(Int32)

    '    Dim COL_FNC_CONSOLIDATION As DataColumn = New DataColumn("FNC_CONSOLIDATION")
    '    COL_FNC_CONSOLIDATION.DataType = GetType(String)

    '    Dim COL_FNC_CONSOL_DESC As DataColumn = New DataColumn("FNC_CONSOL_DESC")
    '    COL_FNC_CONSOL_DESC.DataType = GetType(String)

    '    Dim COL_DFLT_TAX_STATE_PERCENT As DataColumn = New DataColumn("DFLT_TAX_STATE_PERCENT")
    '    COL_DFLT_TAX_STATE_PERCENT.DataType = GetType(Decimal)

    '    Dim COL_DFLT_TAX_COUNTY_PERCENT As DataColumn = New DataColumn("DFLT_TAX_COUNTY_PERCENT")
    '    COL_DFLT_TAX_COUNTY_PERCENT.DataType = GetType(Decimal)

    '    Dim COL_DFLT_TAX_CITY_PERCENT As DataColumn = New DataColumn("DFLT_TAX_CITY_PERCENT")
    '    COL_DFLT_TAX_CITY_PERCENT.DataType = GetType(Decimal)

    '    'Custom Columns
    '    Dim COL_IS_USER_ROW As DataColumn = New DataColumn("IS_USER_ROW")
    '    COL_IS_USER_ROW.DataType = GetType(Int32)

    '    'Add columns to dt
    '    With Me.mDtQuoteFunctions.Columns
    '        .Add(COL_INDEX)

    '        .Add(COL_ESTIMATE_NUMBER)
    '        .Add(COL_EST_COMPONENT_NBR)
    '        .Add(COL_EST_QUOTE_NBR)
    '        .Add(COL_EST_QUOTE_DESC)
    '        .Add(COL_EST_REV_NBR)
    '        .Add(COL_SEQ_NBR)
    '        .Add(COL_FNC_CODE)
    '        .Add(COL_FNC_DESCRIPTION)
    '        .Add(COL_EST_FNC_COMMENT)
    '        .Add(COL_EST_REV_SUP_BY_CDE)
    '        .Add(COL_EST_REV_SUP_BY_NTE)
    '        .Add(COL_EST_REV_QUANTITY)
    '        .Add(COL_EST_REV_RATE)
    '        .Add(COL_EST_REV_EXT_AMT)
    '        .Add(COL_TAX_CODE)
    '        .Add(COL_EST_REV_COMM_PCT)
    '        .Add(COL_EXT_MARKUP_AMT)
    '        .Add(COL_LINE_TOTAL)
    '        .Add(COL_EST_REV_CONT_PCT)
    '        .Add(COL_EXT_CONTINGENCY)
    '        .Add(COL_INCL_CPU)
    '        .Add(COL_TAX_STATE_PCT)
    '        .Add(COL_TAX_COUNTY_PCT)
    '        .Add(COL_TAX_CITY_PCT)
    '        .Add(COL_TAX_COMM)
    '        .Add(COL_TAX_COMM_ONLY)
    '        .Add(COL_TAX_RESALE)
    '        .Add(COL_EXT_NONRESALE_TAX)
    '        .Add(COL_EXT_STATE_RESALE)
    '        .Add(COL_EXT_COUNTY_RESALE)
    '        .Add(COL_EXT_CITY_RESALE)
    '        .Add(COL_EXT_MU_CONT)
    '        .Add(COL_EXT_STATE_CONT)
    '        .Add(COL_EXT_COUNTY_CONT)
    '        .Add(COL_EXT_CITY_CONT)
    '        .Add(COL_EXT_NR_CONT)
    '        .Add(COL_LINE_TOTAL_CONT)
    '        .Add(COL_EST_CPM_FLAG)
    '        .Add(COL_EST_FNC_TYPE)
    '        .Add(COL_EST_COMM_FLAG)
    '        .Add(COL_EST_TAX_FLAG)
    '        .Add(COL_EST_NONBILL_FLAG)
    '        .Add(COL_FEE_TIME)
    '        .Add(COL_EMPLOYEE_TITLE_ID)
    '        .Add(COL_FNC_TYPE)
    '        .Add(COL_EST_PHASE_ID)
    '        .Add(COL_EST_PHASE_DESC)
    '        .Add(COL_FNC_HEADING_ID)
    '        .Add(COL_FNC_HEADING_DESC)
    '        .Add(COL_FNC_HEADING_SEQ)
    '        .Add(COL_FNC_CONSOLIDATION)
    '        .Add(COL_FNC_CONSOL_DESC)
    '        .Add(COL_DFLT_TAX_STATE_PERCENT)
    '        .Add(COL_DFLT_TAX_COUNTY_PERCENT)
    '        .Add(COL_DFLT_TAX_CITY_PERCENT)

    '        .Add(COL_IS_USER_ROW)
    '    End With

    '    Me.mDtQuoteFunctions.PrimaryKey = Pk

    'End Sub

    Private Sub RadGridEstimateSummary_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridEstimateSummary.ItemDataBound
        Try
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                If Me.RadToolbarButtonFunction.Checked = True Then

                End If
                If Me.RadToolbarButtonHeading.Checked = True Then

                End If
                If Me.RadToolbarButtonConsolidation.Checked = True Then

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridEstimateSummary_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridEstimateSummary.NeedDataSource
        Try
            Dim group As String = ""
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression

            If Me.RadToolbarButtonType.Checked Then
                group = "Type"
                Dim strFT() As String = {"EST_FNC_TYPE"}
                Me.RadGridEstimateSummary.MasterTableView.DataKeyNames = strFT
            ElseIf Me.RadToolbarButtonHeading.Checked Then
                group = "Heading"
                Dim strFH() As String = {"FNC_HEADING_ID"}
                Me.RadGridEstimateSummary.MasterTableView.DataKeyNames = strFH
            ElseIf Me.RadToolbarButtonConsolidation.Checked Then
                group = "Consolidation"
                Dim strFC() As String = {"FNC_CONSOLIDATION"}
                Me.RadGridEstimateSummary.MasterTableView.DataKeyNames = strFC
            Else
                group = "Function"
                Me.RadGridEstimateSummary.MasterTableView.DataKeyNames = Nothing
            End If

            Me.RadGridEstimateSummary.DataSource = est.GetEstimateQuoteSummary(Me.TxtEstimate.Text, Me.TxtEstimateComponent.Text, Me.TxtQuoteNum.Text, Me.RevNum, Me.ddPhase.SelectedValue, group)

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Functions "

    Private Sub reloadForm()
        Try
            If Me.ReloadMe = True Then
                If Me.SetPhase = True Then
                    Session("EstimateQuoteSetPhase") = 1
                End If
                MiscFN.ResponseRedirect("Estimating_Quote.aspx?EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&QuoteNum=" & Me.TxtQuoteNum.Text & "&RevNum=" & Me.ddRevision.SelectedValue)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckUserRights()
        Try
            Dim sec As New cSecurity(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim secView As String
            Dim secEdit As String
            Dim secInsert As String

            secView = IIf(Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.ProjectManagement_Estimating), "Y", "N")
            secEdit = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_Estimating), "Y", "N")
            secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_Estimating), "Y", "N")

            If secView = "N" Then
                Me.RadToolbarEstimatingQuote.FindItemByValue("Print").Enabled = False
            End If
            If secEdit = "N" And secInsert = "N" Then
                'Me.RadToolbarEstimatingQuote.FindItemByValue("Save").Enabled = False
                Me.RadToolbarEstimatingQuote.FindItemByValue("NewQuote").Enabled = False
                Me.RadToolbarEstimatingQuote.FindItemByValue("NewRev").Enabled = False
                Me.RadToolbarEstimatingQuote.FindItemByValue("DelRev").Enabled = False
                Me.RadToolbarEstimatingQuote.FindItemByValue("EventGenerator").Enabled = False
                Me.TxtQuoteDescription.ReadOnly = True
                Me.TxtQty.ReadOnly = True
                Me.ddRevision.Enabled = False
                Me.RadEditorQuoteComment.Enabled = False
                Me.RadEditorRevisionComment.Enabled = False
                'Me.imgbtnSpecsQuote.Enabled = False
                'Me.imgbtnSpecsRev.Enabled = False
                Me.TxtVersion.ReadOnly = True
                Me.HlVersion.Attributes.Add("onclick", "")
                Me.HlVersion.Enabled = False
                'Me.RadToolbarEstimateGrid.FindItemByValue("Save").Enabled = False
                Me.RadToolbarEstimateGrid.FindItemByValue("RadToolBarButtonFunctionsTooltip").Enabled = False
                Me.RadToolbarEstimateGrid.FindItemByValue("RadToolBarButtonPhaseTooltip").Enabled = False
                Me.ButtonAddFunctionsFromListOfFunctions.Enabled = False
                Me.ButtonDeleteSelectedFunctions.Enabled = False
                Me.ButtonAddFunctionsFromFunctionTemplates.Enabled = False
                Me.ButtonAddFunctionsCopyFromExistingQuote.Enabled = False
                Me.ButtonAddFunctionsCreateFromSchedule.Enabled = False
                Me.ButtonAddFunctionsCreateFromJobHistory.Enabled = False
                Me.ButtonQuotefromCampaign.Enabled = False
                Me.ButtonAdd.Enabled = False
                Me.ButtonSubtract.Enabled = False
                Me.ButtonPhaseSetPhase.Enabled = False
                Me.ButtonPhaseClearPhase.Enabled = False
                rights = "N"
            ElseIf secEdit = "Y" And secInsert = "N" Then
                Me.RadToolbarEstimatingQuote.FindItemByValue("NewQuote").Enabled = False
                Me.RadToolbarEstimatingQuote.FindItemByValue("NewRev").Enabled = False
                'Me.RadToolbarEstimatingQuote.FindItemByValue("EventGenerator").Enabled = False
                'Me.ddRevision.Enabled = False
            ElseIf secEdit = "N" And secInsert = "Y" Then
                'Me.RadToolbarEstimatingQuote.FindItemByValue("Save").Enabled = False
                Me.RadToolbarEstimatingQuote.FindItemByValue("DelRev").Enabled = False
                Me.TxtQuoteDescription.ReadOnly = True
                Me.TxtQty.ReadOnly = True
                Me.ddRevision.Enabled = False
                Me.RadEditorQuoteComment.Enabled = False
                Me.RadEditorRevisionComment.Enabled = False
                'Me.imgbtnSpecsQuote.Enabled = False
                'Me.imgbtnSpecsRev.Enabled = False
                Me.TxtVersion.ReadOnly = True
                Me.HlVersion.Attributes.Add("onclick", "")
                Me.HlVersion.Enabled = False
                'Me.RadToolbarEstimateGrid.FindItemByValue("Save").Enabled = False
                'Me.RadToolbarEstimateGrid.FindItemByValue("Save").Enabled = False

                Me.RadToolbarEstimateGrid.FindItemByValue("RadToolBarButtonFunctionsTooltip").Enabled = False
                Me.RadToolbarEstimateGrid.FindItemByValue("RadToolBarButtonPhaseTooltip").Enabled = False
                Me.ButtonAddFunctionsFromListOfFunctions.Enabled = False
                Me.ButtonDeleteSelectedFunctions.Enabled = False
                Me.ButtonAddFunctionsFromFunctionTemplates.Enabled = False
                Me.ButtonAddFunctionsCopyFromExistingQuote.Enabled = False
                Me.ButtonAddFunctionsCreateFromSchedule.Enabled = False
                Me.ButtonAddFunctionsCreateFromJobHistory.Enabled = False
                Me.ButtonQuotefromCampaign.Enabled = False
                Me.ButtonAdd.Enabled = False
                Me.ButtonSubtract.Enabled = False
                Me.ButtonPhaseSetPhase.Enabled = False
                Me.ButtonPhaseClearPhase.Enabled = False
                Me.RadToolbarEstimatingQuote.FindItemByValue("EventGenerator").Enabled = False
                rights = "N"
            End If


            'Quote Approval
            Try
                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    'secView = IIf(AdvantageFramework.Security.CanUserPrintInModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.ProjectManagement_QuoteApproval.ToString, _Session.UserCode), "Y", "N")
                    If Me.CheckAdvantageModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_QuoteApproval) = 1 Then

                        'secEdit = IIf(AdvantageFramework.Security.CanUserUpdateInModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.ProjectManagement_QuoteApproval.ToString, _Session.UserCode), "Y", "N")
                        'secInsert = IIf(AdvantageFramework.Security.CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.ProjectManagement_QuoteApproval.ToString, _Session.UserCode), "Y", "N")

                        secEdit = IIf(Me.UserCanUpdateInModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.ProjectManagement_QuoteApproval), "Y", "N")
                        secInsert = IIf(Me.UserCanAddInModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.ProjectManagement_QuoteApproval), "Y", "N")

                        'secView = IIf(Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.ProjectManagement_Estimating), "Y", "N")

                        If secView = "N" And secEdit = "N" And secInsert = "N" Then
                            Me.RadToolbarEstimatingQuote.FindItemByValue("ClientApprove").Enabled = False
                            Me.RadToolbarEstimatingQuote.FindItemByValue("InternalApprove").Enabled = False
                            Me.hlApproved.Attributes.Add("onclick", "")
                            Me.hlApprovedInternal.Attributes.Add("onclick", "")
                            Me.hlApproved.Enabled = False
                            Me.hlApprovedInternal.Enabled = False
                        ElseIf secView = "N" And secEdit = "Y" And secInsert = "N" Then
                            Me.RadToolbarEstimatingQuote.FindItemByValue("ClientApprove").Enabled = False
                            Me.RadToolbarEstimatingQuote.FindItemByValue("InternalApprove").Enabled = False
                        ElseIf secView = "N" And secEdit = "N" And secInsert = "Y" Then
                        ElseIf secView = "N" And secEdit = "Y" And secInsert = "Y" Then
                        ElseIf secView = "Y" And secEdit = "N" And secInsert = "N" Then
                            Me.RadToolbarEstimatingQuote.FindItemByValue("ClientApprove").Enabled = False
                            Me.RadToolbarEstimatingQuote.FindItemByValue("InternalApprove").Enabled = False
                        ElseIf secView = "Y" And secEdit = "Y" And secInsert = "N" Then
                            Me.RadToolbarEstimatingQuote.FindItemByValue("ClientApprove").Enabled = False
                            Me.RadToolbarEstimatingQuote.FindItemByValue("InternalApprove").Enabled = False
                        ElseIf secView = "Y" And secEdit = "N" And secInsert = "Y" Then
                            Me.RadToolbarEstimatingQuote.FindItemByValue("ClientApprove").Enabled = False
                            Me.RadToolbarEstimatingQuote.FindItemByValue("InternalApprove").Enabled = False
                        End If

                    End If

                End Using

            Catch ex As Exception
            End Try




        Catch ex As Exception
        End Try
    End Sub

#End Region

    Private Sub RadToolbarEstimatingQuote_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarEstimatingQuote.ButtonClick
        Select Case e.Item.Value
            Case "Save"
                Try
                    Me.lblMSG.Text = ""
                    Me.SaveGrid()
                    'Me.SaveQuoteHeader()
                    'Me.CheckApproval()
                    'Me.CheckApprovalInternal()
                    Me.SaveSort()
                    If Me.lblMSG.Text <> "" Then
                        Me.ShowMessage(Me.lblMSG.Text)
                        Me.lblMSG.Text = ""
                        Exit Sub
                    Else
                        Session("QuoteErrorMessage") = ""
                    End If
                    Dim gf As Telerik.Web.UI.GridFooterItem = Me.RadGridEstimateQuoteDetails.MasterTableView.GetItems(GridItemType.Footer)(0)
                    If Me.TxtQty.Text <> "" And Me.TxtQty.Text <> "0" Then
                        If DropSort.SelectedValue = "funccode" Then
                            Me.TxtCPU.Text = String.Format("{0:#,##0.000}", (CDec(gf.Cells(25).Text) / CDec(Me.TxtQty.Text)))
                        Else
                            Me.TxtCPU.Text = String.Format("{0:#,##0.000}", (CDec(gf.Cells(26).Text) / CDec(Me.TxtQty.Text)))
                        End If
                    End If
                    Me.LoadQuoteHeader()
                    Session("DT_EST_QUOTE_FNC") = Nothing
                    'Me.ReloadMe = True
                    Me.RadGridEstimateQuoteDetails.Rebind()
                    'MiscFN.ResponseRedirect("Estimating_Quote.aspx?EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&QuoteNum=" & Me.TxtQuoteNum.Text & "&RevNum=" & Me.ddRevision.SelectedValue)
                Catch ex As Exception
                    'Throw (ex)
                    'lblMSG.Text = "Error!<br />" & ex.Message.ToString()& "<br />" & ex.InnerException.ToString
                    lblMSG.Text = ""
                End Try
            Case "Refresh"
                Me.lblMSG.Text = ""
                Session("DT_EST_QUOTE_FNC") = Nothing
                Me.LoadQuoteHeader()
                Me.CheckApproval()
                Me.RadGridEstimateQuoteDetails.Rebind()

                If (_CanUserInsertPO = False) Or (hlApproved.Visible = False And hlApprovedInternal.Visible = False) Then
                    Me.RadToolbarEstimateGrid.Items.FindItemByValue("CreatePO").Enabled = False
                Else
                    Me.RadToolbarEstimateGrid.Items.FindItemByValue("CreatePO").Enabled = True
                End If
            Case "SpecsQuote"
                'Me.RadWindowManager.Windows(0).VisibleOnPageLoad = False
                Me.lblMSG.Text = ""
                Session("DT_EST_QUOTE_FNC") = Nothing
                Me.RadGridEstimateQuoteDetails.Rebind()
                If Not Session("EstImportSpecText") Is Nothing Then
                    If Session("EstImportSpecText") <> "" Then
                        Me.RadEditorQuoteComment.Content = Session("EstImportSpecText")
                        Me.CollapsablePanelComments.Collapsed = False
                        Session("EstImportSpecText") = Nothing
                    End If
                End If
                'Me.LoadQuoteHeader()
            Case "SpecsRev"
                'Me.RadWindowManager.Windows(0).VisibleOnPageLoad = False
                Me.lblMSG.Text = ""
                Session("DT_EST_QUOTE_FNC") = Nothing
                Me.RadGridEstimateQuoteDetails.Rebind()
                If Not Session("EstImportSpecText") Is Nothing Then
                    If Session("EstImportSpecText") <> "" Then
                        Me.RadEditorRevisionComment.Content = Session("EstImportSpecText")
                        Me.CollapsablePanelComments.Collapsed = False
                        Session("EstImportSpecText") = Nothing
                    End If
                End If
                'Me.LoadQuoteHeader()
            Case "DelRev"
                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                Dim max As Integer
                Dim DelSQL As String = ""
                If Me.hlApproved.Visible = True Or Me.hlApprovedInternal.Visible = True Then
                    Session("EstDelRev") = 1
                    Exit Sub
                End If
                If EstNum > 0 And EstCompNum > 0 And QuoteNum > 0 Then
                    DelSQL = "DELETE FROM ESTIMATE_REV_DET WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstCompNum & " AND EST_QUOTE_NBR = " & QuoteNum & " AND EST_REV_NBR = " & Me.ddRevision.SelectedValue & ";DELETE FROM ESTIMATE_REV WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstCompNum & " AND EST_QUOTE_NBR = " & QuoteNum & " AND EST_REV_NBR = " & Me.ddRevision.SelectedValue & ";"
                    If Me.ddRevision.SelectedValue = 0 Then
                        DelSQL &= "DELETE FROM ESTIMATE_QUOTE WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstCompNum & " AND EST_QUOTE_NBR = " & QuoteNum & ";"
                        Session("EstDelRevZero") = 1
                    End If
                    Using MyConn As New SqlConnection(Session("ConnString"))
                        MyConn.Open()
                        Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                        Dim MyCmd As New SqlCommand(DelSQL, MyConn, MyTrans)
                        Try
                            MyCmd.ExecuteNonQuery()
                            MyTrans.Commit()
                        Catch ex As Exception
                            MyTrans.Rollback()
                        Finally
                            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        End Try
                    End Using
                    'If Me.ddRevision.SelectedValue = 0 Then
                    '    MiscFN.ResponseRedirect("Estimating.aspx?EstNum=" & EstNum & "&EstComp=" & EstCompNum & "&newEst=edit")
                    'End If
                End If
                max = est.GetEstimateQuoteMaxRevision(Me.EstNum, Me.EstCompNum, Me.QuoteNum)
                If (ddRevision.SelectedValue = 0 Or ddRevision.SelectedValue = "") And Session("EstDelRevZero") = 1 Then
                    Session("EstDelRevZero") = 0
                    Me.CloseThisWindow()
                    Me.OpenWindow("Estimating", "Estimating.aspx?EstNum=" & EstNum & "&EstComp=" & EstCompNum & "&newEst=edit")
                Else
                    Me.OpenWindow("Estimating Quote", "Estimating_Quote.aspx?EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&QuoteNum=" & Me.TxtQuoteNum.Text & "&RevNum=" & max)
                End If
                If Me.ddRevision.SelectedValue <> 0 Then
                    Me.loadRevisions(max)
                    Me.LoadQuoteHeader()
                    Me.CheckApproval()
                    Me.CheckApprovalInternal()
                    LoadLookups()
                End If
                Me.RadGridEstimateQuoteDetails.Rebind()
            Case "ClientApprove"
                Try
                    Dim dr As SqlDataReader
                    Dim dr2 As SqlDataReader
                    Dim dr3 As SqlDataReader
                    Dim dr4 As SqlDataReader
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim appr As Integer
                    Dim rev As Integer
                    Dim button As New Telerik.Web.UI.RadToolBarButton
                    button = Me.RadToolbarEstimatingQuote.FindItemByValue("ClientApprove")
                    Me.LoadQuoteHeader()
                    If button.Visible = True Then
                        If button.Text = "Client Approval" Then
                            dr = est.GetApprovals(Me.EstNum, Me.EstCompNum, approvalType)
                            dr2 = est.GetInternalApprovals(Me.EstNum, Me.EstCompNum, approvalType)
                            dr3 = est.GetApprovalByQuoteMax(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedItem.Text, approvalType)
                            dr4 = est.GetInternalApprovalByQuoteMax(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedItem.Text, approvalType)
                            If (dr.HasRows = True And dr3.HasRows = False And dr4.HasRows = False) Or (dr2.HasRows = True And dr3.HasRows = False And dr4.HasRows = False) Then
                                If dr.HasRows = True Then
                                    Do While dr.Read
                                        appr = dr.GetInt16(0)
                                        rev = dr.GetInt16(1)
                                        Me.ShowMessage("Warning, approvals of quote " & appr.ToString() & "/revision " & rev.ToString.PadLeft(3, "0") & " will be deleted and quote " & Me.QuoteNum.ToString() & "/revision " & Me.ddRevision.SelectedItem.Text & " will be approved.")
                                    Loop
                                ElseIf dr2.HasRows = True Then
                                    Do While dr2.Read
                                        appr = dr2.GetInt16(0)
                                        rev = dr2.GetInt16(1)
                                        Me.ShowMessage("Warning, approvals of quote " & appr.ToString() & "/revision " & rev.ToString.PadLeft(3, "0") & " will be deleted and quote " & Me.QuoteNum.ToString() & "/revision " & Me.ddRevision.SelectedItem.Text & " will be approved.")
                                    Loop
                                End If
                                dr.Close()
                            End If
                            'With Me.RadWindowManager.Windows(0)
                            '    .NavigateUrl = "Estimating_Approval.aspx?appr=1&EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum
                            '    .Title = "Client Approval"
                            '    .Modal = True
                            '    .Height = New Unit(300, UnitType.Pixel)
                            '    .Width = New Unit(450, UnitType.Pixel)
                            '    .InitialBehavior = Telerik.Web.UI.WindowBehaviors.None
                            '    .ReloadOnShow = True
                            '    .Behavior = Telerik.Web.UI.WindowBehaviors.None

                            '    .VisibleOnPageLoad = True
                            '    .VisibleStatusbar = False
                            'End With
                            Dim StrURL As String = "Estimating_Approval.aspx?appr=1&EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&CampaignID=" & Me.CampaignID
                            Me.OpenWindow("Client Approval", StrURL, 300, 450, False, True, "RefreshPage")
                        End If

                        If button.Text = "Unapprove Client" Then


                            If est.DeleteQuoteApproval(Me.EstNum, Me.EstCompNum) = True Then

                                If Me.JobNum > 0 And Me.JobCompNum > 0 Then

                                    Dim UpdatedAlertIDs As New Generic.List(Of Integer)
                                    AdvantageFramework.Database.Procedures.Workflow.UpdateAlertAssignments(_Session, HttpContext.Current.Session("UserCode"),
                                                                         AdvantageFramework.Database.Procedures.Workflow.WorkflowEvent.Estimate_ClientUnapprove,
                                                                         True, Me.JobNum, Me.JobCompNum,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,, UpdatedAlertIDs)
                                    Try

                                        If UpdatedAlertIDs IsNot Nothing AndAlso UpdatedAlertIDs.Count > 0 Then

                                            For Each AlertId In UpdatedAlertIDs

                                                Try

                                                    SignalR.Classes.NotificationHub.NotifyRecipientsAll(AlertId, HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                                                Catch ex As Exception
                                                End Try

                                            Next

                                        End If

                                    Catch ex As Exception
                                    End Try

                                End If

                                'Me.LblApproved.Visible = False
                                Me.hlApproved.Visible = False
                                button.Text = "Client Approval"
                                'Me.lblMSG.Text = "Approval Deleted"
                                button.ToolTip = "Approve"
                                Me.hfApproved.Value = 0
                            End If

                            Me.RadGridEstimateQuoteDetails.Rebind()

                        End If

                    End If

                    If (_CanUserInsertPO = False) Or (hlApproved.Visible = False And hlApprovedInternal.Visible = False) Then
                        Me.RadToolbarEstimateGrid.Items.FindItemByValue("CreatePO").Enabled = False
                    Else
                        Me.RadToolbarEstimateGrid.Items.FindItemByValue("CreatePO").Enabled = True
                    End If
                Catch ex As Exception

                End Try

            Case "InternalApprove"
                Dim dr As SqlDataReader
                Dim dr2 As SqlDataReader
                Dim dr3 As SqlDataReader
                Dim dr4 As SqlDataReader
                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                Dim appr As Integer
                Dim rev As Integer
                Dim button As New Telerik.Web.UI.RadToolBarButton
                button = CType(Me.RadToolbarEstimatingQuote.FindItemByValue("InternalApprove"), Telerik.Web.UI.RadToolBarButton)
                Me.LoadQuoteHeader()
                If button.Visible = True Then
                    If button.Text = "Internal Approval" Then
                        dr = est.GetInternalApprovals(Me.EstNum, Me.EstCompNum, approvalType)
                        dr2 = est.GetApprovals(Me.EstNum, Me.EstCompNum, approvalType)
                        dr3 = est.GetApprovalByQuoteMax(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedItem.Text, approvalType)
                        dr4 = est.GetInternalApprovalByQuoteMax(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedItem.Text, approvalType)
                        If (dr.HasRows = True And dr3.HasRows = False And dr4.HasRows = False) Or (dr2.HasRows = True And dr3.HasRows = False And dr4.HasRows = False) Then
                            If dr.HasRows = True Then
                                Do While dr.Read
                                    appr = dr.GetInt16(0)
                                    rev = dr.GetInt16(1)
                                    Me.ShowMessage("Warning, approvals of quote " & appr.ToString() & "/revision " & rev.ToString.PadLeft(3, "0") & " will be deleted and quote " & Me.QuoteNum.ToString() & "/revision " & Me.ddRevision.SelectedItem.Text & " will be approved.")
                                Loop
                            ElseIf dr2.HasRows = True Then
                                Do While dr2.Read
                                    appr = dr2.GetInt16(0)
                                    rev = dr2.GetInt16(1)
                                    Me.ShowMessage("Warning, approvals of quote " & appr.ToString() & "/revision " & rev.ToString.PadLeft(3, "0") & " will be deleted and quote " & Me.QuoteNum.ToString() & "/revision " & Me.ddRevision.SelectedItem.Text & " will be approved.")
                                Loop
                            End If
                            dr.Close()
                        End If
                        'With Me.RadWindowManager.Windows(0)
                        '    .NavigateUrl = "Estimating_Approval.aspx?appr=2&EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum
                        '    .Title = "Internal Approval"
                        '    .Modal = True
                        '    .Height = New Unit(300, UnitType.Pixel)
                        '    .Width = New Unit(450, UnitType.Pixel)
                        '    .InitialBehavior = Telerik.Web.UI.WindowBehaviors.None
                        '    .ReloadOnShow = True
                        '    .Behavior = Telerik.Web.UI.WindowBehaviors.None

                        '    .VisibleOnPageLoad = True
                        '    .VisibleStatusbar = False
                        'End With
                        Dim StrURL As String = "Estimating_Approval.aspx?appr=2&EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&CampaignID=" & Me.CampaignID
                        Me.OpenWindow("Internal Approval", StrURL, 300, 450, False, True, "RefreshPage")
                    End If
                    If button.Text = "Unapprove Internal" Then

                        If est.DeleteQuoteApprovalInternal(Me.EstNum, Me.EstCompNum) = True Then

                            If Me.JobNum > 0 And Me.JobCompNum > 0 Then

                                Dim UpdatedAlertIDs As New Generic.List(Of Integer)
                                AdvantageFramework.Database.Procedures.Workflow.UpdateAlertAssignments(_Session, HttpContext.Current.Session("UserCode"),
                                                                                                       AdvantageFramework.Database.Procedures.Workflow.WorkflowEvent.Estimate_InternalUnapprove,
                                                                                                       True, Me.JobNum, Me.JobCompNum)
                                Try

                                    If UpdatedAlertIDs IsNot Nothing AndAlso UpdatedAlertIDs.Count > 0 Then

                                        For Each AlertId In UpdatedAlertIDs

                                            Try

                                                SignalR.Classes.NotificationHub.NotifyRecipientsAll(AlertId, HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                                            Catch ex As Exception
                                            End Try

                                        Next

                                    End If

                                Catch ex As Exception
                                End Try

                            End If

                            'Me.LblApproved.Visible = False
                            Me.hlApprovedInternal.Visible = False
                            button.Text = "Internal Approval"
                            'Me.lblMSG.Text = "Approval Deleted"
                            button.ToolTip = "Internal Approve"
                            Me.hfInternalApproved.Value = 0

                        End If

                        Me.RadGridEstimateQuoteDetails.Rebind()

                    End If

                End If

                If (_CanUserInsertPO = False) Or (hlApproved.Visible = False And hlApprovedInternal.Visible = False) Then
                    Me.RadToolbarEstimateGrid.Items.FindItemByValue("CreatePO").Enabled = False
                Else
                    Me.RadToolbarEstimateGrid.Items.FindItemByValue("CreatePO").Enabled = True
                End If
            Case "EventGenerator"
                If EstNum > 0 And EstCompNum > 0 And QuoteNum > 0 Then
                    Dim j As String = ""
                    Dim jc As String = ""
                    If IsNumeric(Me.CurrentQuerystring.GetValue("j")) = True Then
                        j = Me.CurrentQuerystring.GetValue("j")
                    End If
                    If IsNumeric(Me.CurrentQuerystring.GetValue("jc")) = True Then
                        jc = Me.CurrentQuerystring.GetValue("jc")
                    End If
                    Dim StrURL1 As String = "" ' "Event_Generator.aspx" '?f=0&e=" & EstNum.ToString() & "&ec=" & EstCompNum.ToString() & "&eq" = QuoteNum.ToString()
                    StrURL1 = "Event_Generator.aspx?f=0&e=" & Me.EstNum & "&ec=" & Me.EstCompNum & "&eq=" & Me.QuoteNum & "&er=" & Me.ddRevision.SelectedValue.ToString() & "&j=" & j & "&jc=" & jc
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "WinEventGenerator", "Event Generator", StrURL1, 650, 650, False)
                    Me.OpenWindow("Event Generator", StrURL1, 650, 650, False, False, "RefreshPage")
                End If
            Case "NewQuote"
                Try
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim save As Boolean
                    Dim max As Integer
                    max = est.GetEstimateQuoteMax(Me.EstNum, Me.EstCompNum)
                    save = est.AddNewQuote(Me.EstNum, Me.EstCompNum, max + 1, 0)
                    If save = True Then
                        Me.TxtEstimate.Text = ""
                        Me.TxtEstimateComponent.Text = ""
                        Me.TxtQuoteNum.Text = ""
                        Me.OpenWindow("Estimating Quote", "Estimating_Quote.aspx?EstNum=" & Me.EstNum & "&EstComp=" & Me.EstCompNum & "&QuoteNum=" & max + 1)
                        'MiscFN.ResponseRedirect("Estimating_Quote.aspx?EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&QuoteNum=" & max + 1)
                    Else
                        Me.ShowMessage("Save Failed.")
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try
            Case "ColumnSettings"
                Session("EstimateSetupRev") = Me.ddRevision.SelectedValue
                Me.OpenWindow("Settings/Options", "Estimating_Setup.aspx?EstNum=" & EstNum & "&EstComp=" & EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue, 0, 0, False, False, "RefreshPage")
                'MiscFN.ResponseRedirect("Estimating_Setup.aspx?EstNum=" & EstNum & "&EstComp=" & EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue)
            Case "NewRev"
                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                Dim dr As SqlDataReader
                Dim dr2 As SqlDataReader
                dr = est.GetApprovalByQuote(Me.EstNum, Me.EstCompNum, Me.QuoteNum)
                dr2 = est.GetInternalApprovalByQuote(Me.EstNum, Me.EstCompNum, Me.QuoteNum)
                Dim approval As Boolean = False
                If dr.HasRows = True Then
                    approval = True
                ElseIf dr2.HasRows = True Then
                    approval = True
                End If
                If approval = True Then
                    Me.ShowMessage("An earlier revision has been approved.  The new revision must be approved before it can be accessed in other areas.")
                End If

                Dim maxRev As Integer
                maxRev = Me.AddNewRevision()
                Me.AddRevisionDetails(maxRev)
                Me.loadRevisions(maxRev + 1)
                Me.RevNum = maxRev + 1
                Me.LoadQuoteHeader()
                Me.CheckApproval()
                Me.CheckApprovalInternal()
                LoadLookups()
                Me.RadGridEstimateQuoteDetails.Rebind()

            Case "Print"

                If EstNum = 0 Or EstCompNum = 0 Then

                    Me.ShowMessage("Please enter an Estimate/Component number.")
                    Exit Sub

                End If

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs.Page = "Estimating_PrintSettings.aspx"

                If IsNumeric(Me.TxtEstimate.Text) = True Then qs.EstimateNumber = CType(Me.TxtEstimate.Text, Integer)
                If IsNumeric(Me.TxtEstimateComponent.Text) = True Then qs.EstimateComponentNumber = CType(Me.TxtEstimateComponent.Text, Integer)
                If IsNumeric(Me.TxtJobNum.Text) = True Then qs.JobNumber = CType(Me.TxtJobNum.Text, Integer)
                If IsNumeric(Me.TxtJobCompNum.Text) = True Then qs.JobComponentNumber = CType(Me.TxtJobCompNum.Text, Integer)
                If IsNumeric(Me.TxtQuoteNum.Text) = True Then qs.EstimateQuoteNumber = CType(Me.TxtQuoteNum.Text, Integer)
                If Not Me.ddRevision.SelectedValue Is Nothing AndAlso IsNumeric(Me.ddRevision.SelectedValue) = True Then qs.EstimateRevisionNumber = CType(Me.ddRevision.SelectedValue, Integer)

                qs.Add("from", "EstQuote")
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Print)
                qs.Add("sel_quotes", Me.QuoteNum)

                Me.OpenPrintSendSilently(qs)
                Me.RadGridEstimateQuoteDetails.Rebind()

            Case "SendAlert"

                If EstNum = 0 Or EstCompNum = 0 Then

                    Me.ShowMessage("Please enter an Estimate/Component number.")
                    Exit Sub

                End If

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs.Page = "Estimating_PrintSettings.aspx"

                If IsNumeric(Me.TxtEstimate.Text) = True Then qs.EstimateNumber = CType(Me.TxtEstimate.Text, Integer)
                If IsNumeric(Me.TxtEstimateComponent.Text) = True Then qs.EstimateComponentNumber = CType(Me.TxtEstimateComponent.Text, Integer)
                If IsNumeric(Me.TxtJobNum.Text) = True Then qs.JobNumber = CType(Me.TxtJobNum.Text, Integer)
                If IsNumeric(Me.TxtJobCompNum.Text) = True Then qs.JobComponentNumber = CType(Me.TxtJobCompNum.Text, Integer)
                If IsNumeric(Me.TxtQuoteNum.Text) = True Then qs.EstimateQuoteNumber = CType(Me.TxtQuoteNum.Text, Integer)
                If Not Me.ddRevision.SelectedValue Is Nothing AndAlso IsNumeric(Me.ddRevision.SelectedValue) = True Then qs.EstimateRevisionNumber = CType(Me.ddRevision.SelectedValue, Integer)

                qs.Add("from", "EstQuote")
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)
                qs.Add("sel_quotes", Me.QuoteNum)

                Me.OpenPrintSendSilently(qs)
                Me.RadGridEstimateQuoteDetails.Rebind()

            Case "SendAssignment"

                If EstNum = 0 Or EstCompNum = 0 Then

                    Me.ShowMessage("Please enter an Estimate/Component number.")
                    Exit Sub

                End If

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs.Page = "Estimating_PrintSettings.aspx"

                If IsNumeric(Me.TxtEstimate.Text) = True Then qs.EstimateNumber = CType(Me.TxtEstimate.Text, Integer)
                If IsNumeric(Me.TxtEstimateComponent.Text) = True Then qs.EstimateComponentNumber = CType(Me.TxtEstimateComponent.Text, Integer)
                If IsNumeric(Me.TxtJobNum.Text) = True Then qs.JobNumber = CType(Me.TxtJobNum.Text, Integer)
                If IsNumeric(Me.TxtJobCompNum.Text) = True Then qs.JobComponentNumber = CType(Me.TxtJobCompNum.Text, Integer)
                If IsNumeric(Me.TxtQuoteNum.Text) = True Then qs.EstimateQuoteNumber = CType(Me.TxtQuoteNum.Text, Integer)
                If Not Me.ddRevision.SelectedValue Is Nothing AndAlso IsNumeric(Me.ddRevision.SelectedValue) = True Then qs.EstimateRevisionNumber = CType(Me.ddRevision.SelectedValue, Integer)

                qs.Add("from", "EstQuote")
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)
                qs.Add("sel_quotes", Me.QuoteNum)

                Me.OpenPrintSendSilently(qs)
                Me.RadGridEstimateQuoteDetails.Rebind()

            Case "SendEmail"

                If EstNum = 0 Or EstCompNum = 0 Then

                    Me.ShowMessage("Please enter an Estimate/Component number.")
                    Exit Sub

                End If

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs.Page = "Estimating_PrintSettings.aspx"

                If IsNumeric(Me.TxtEstimate.Text) = True Then qs.EstimateNumber = CType(Me.TxtEstimate.Text, Integer)
                If IsNumeric(Me.TxtEstimateComponent.Text) = True Then qs.EstimateComponentNumber = CType(Me.TxtEstimateComponent.Text, Integer)
                If IsNumeric(Me.TxtJobNum.Text) = True Then qs.JobNumber = CType(Me.TxtJobNum.Text, Integer)
                If IsNumeric(Me.TxtJobCompNum.Text) = True Then qs.JobComponentNumber = CType(Me.TxtJobCompNum.Text, Integer)
                If IsNumeric(Me.TxtQuoteNum.Text) = True Then qs.EstimateQuoteNumber = CType(Me.TxtQuoteNum.Text, Integer)
                If Not Me.ddRevision.SelectedValue Is Nothing AndAlso IsNumeric(Me.ddRevision.SelectedValue) = True Then qs.EstimateRevisionNumber = CType(Me.ddRevision.SelectedValue, Integer)

                qs.Add("from", "EstQuote")
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendEmail)
                qs.Add("sel_quotes", Me.QuoteNum)

                Me.OpenPrintSendSilently(qs)
                Me.RadGridEstimateQuoteDetails.Rebind()

            Case "PrintSendOptions"

                If EstNum = 0 Or EstCompNum = 0 Then

                    Me.ShowMessage("Please enter an Estimate/Component number.")
                    Exit Sub

                End If

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs.Page = "Estimating_PrintSettings.aspx"

                If IsNumeric(Me.TxtEstimate.Text) = True Then qs.EstimateNumber = CType(Me.TxtEstimate.Text, Integer)
                If IsNumeric(Me.TxtEstimateComponent.Text) = True Then qs.EstimateComponentNumber = CType(Me.TxtEstimateComponent.Text, Integer)
                If IsNumeric(Me.TxtJobNum.Text) = True Then qs.JobNumber = CType(Me.TxtJobNum.Text, Integer)
                If IsNumeric(Me.TxtJobCompNum.Text) = True Then qs.JobComponentNumber = CType(Me.TxtJobCompNum.Text, Integer)
                If IsNumeric(Me.TxtQuoteNum.Text) = True Then qs.EstimateQuoteNumber = CType(Me.TxtQuoteNum.Text, Integer)
                If Not Me.ddRevision.SelectedValue Is Nothing AndAlso IsNumeric(Me.ddRevision.SelectedValue) = True Then qs.EstimateRevisionNumber = CType(Me.ddRevision.SelectedValue, Integer)

                qs.Add("from", "EstQuote")
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Options)
                qs.Add("sel_quotes", Me.QuoteNum)

                Me.OpenWindow(qs, "Options", 0, 0, False, False, "RefreshPage")
                Me.RadGridEstimateQuoteDetails.Rebind()





            Case "Bookmark"

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim qs As New AdvantageFramework.Web.QueryString()

                qs = qs.FromCurrent()

                qs.Add("bm", "1")

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_Estimating
                    .UserCode = Session("UserCode")
                    .Name = "Est. Quote: " & EstNum.ToString() & "/" & EstCompNum.ToString() & "/" & QuoteNum & "/" & Me.ddRevision.SelectedValue
                    .PageURL = "Estimating_Quote.aspx" & qs.ToString()

                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then
                    Me.ShowMessage(s)
                Else
                    Me.RefreshBookmarksDesktopObject()
                End If
            Case "Type", "Heading", "Consolidation", "Function"
                If Me.RadToolbarButtonFunction.Checked = True Or Me.RadToolbarButtonHeading.Checked = True Or Me.RadToolbarButtonConsolidation.Checked = True Or Me.RadToolbarButtonType.Checked = True Then
                    Me.RadGridEstimateQuoteDetails.Visible = False
                    Me.RadGridEstimateSummary.Visible = True
                    Me.RadToolbarEstimateGrid.Visible = False
                    Me.RadGridEstimateSummary.Rebind()
                Else
                    Me.RadGridEstimateQuoteDetails.Visible = True
                    Me.RadGridEstimateSummary.Visible = False
                    Me.RadToolbarEstimateGrid.Visible = True
                    Me.RadGridEstimateQuoteDetails.Rebind()
                End If

            Case "Back"
                MiscFN.ResponseRedirect("Estimating.aspx?EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&newEst=edit")

            Case "Alerts"

                Dim qs As New AdvantageFramework.Web.QueryString

                qs.Page = "Alert_List.aspx"
                qs.EstimateNumber = Me.EstNum
                qs.EstimateComponentNumber = Me.EstCompNum
                qs.EstimateQuoteNumber = Me.QuoteNum
                qs.Add("lstlvl", AdvantageFramework.Database.Entities.AlertListLevel.EstimateQuote)
                If Me.JobNum > 0 AndAlso Me.JobCompNum > 0 Then
                    qs.Page = "Alert_Inbox.aspx"
                    qs.JobNumber = Me.JobNum
                    qs.JobComponentNumber = Me.JobCompNum
                End If

                Me.OpenWindow(qs)


        End Select
    End Sub
    Private Sub RadToolbarEstimateGrid_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarEstimateGrid.ButtonClick
        Select Case e.Item.Value
            Case "Save"
                Try
                    Me.lblMSG.Text = ""
                    Me.SaveGrid()
                    'Me.SaveQuoteHeader()
                    'Me.CheckApproval()
                    'Me.CheckApprovalInternal()
                    Me.SaveSort()
                    If Me.lblMSG.Text <> "" Then
                        Me.ShowMessage(Me.lblMSG.Text)
                        Me.lblMSG.Text = ""
                        Exit Sub
                    Else
                        Session("QuoteErrorMessage") = ""
                    End If
                    Dim gf As Telerik.Web.UI.GridFooterItem = Me.RadGridEstimateQuoteDetails.MasterTableView.GetItems(GridItemType.Footer)(0)
                    If Me.TxtQty.Text <> "" And Me.TxtQty.Text <> "0" Then
                        If DropSort.SelectedValue = "funccode" Then
                            Me.TxtCPU.Text = String.Format("{0:#,##0.000}", (CDec(gf.Cells(25).Text) / CDec(Me.TxtQty.Text)))
                        Else
                            Me.TxtCPU.Text = String.Format("{0:#,##0.000}", (CDec(gf.Cells(26).Text) / CDec(Me.TxtQty.Text)))
                        End If
                    End If
                    Me.LoadQuoteHeader()
                    Session("DT_EST_QUOTE_FNC") = Nothing
                    'Me.ReloadMe = True
                    Me.RadGridEstimateQuoteDetails.Rebind()
                    'MiscFN.ResponseRedirect("Estimating_Quote.aspx?EstNum=" & Me.TxtEstimate.Text & "&EstComp=" & Me.TxtEstimateComponent.Text & "&QuoteNum=" & Me.TxtQuoteNum.Text & "&RevNum=" & Me.ddRevision.SelectedValue)
                Catch ex As Exception
                    'Throw (ex)
                    'lblMSG.Text = "Error!<br />" & ex.Message.ToString()& "<br />" & ex.InnerException.ToString
                    lblMSG.Text = ""
                End Try
            Case "CreatePO"
                Dim chk As CheckBox
                Dim SequenceString As String = ""
                Dim count As Integer = 0
                Dim dtKey As String
                Dim RowSuppliedBy As String = ""
                Dim VendorCode As String = ""
                Dim PONumber As Integer = 0
                Dim FunctionCode As String = ""
                Dim Rate As Decimal = 0
                Dim Quantity As Decimal = 0
                Dim ExtendedAmount As Decimal = 0
                Dim MarkupPercent As Decimal = 0
                Dim ExtendedMarkupAmount As Decimal = 0
                Dim fnctype As String = ""

                Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing

                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstimateQuoteDetails.MasterTableView.Items
                    'chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                    fnctype = gridDataItem.GetDataKeyValue("FNC_TYPE")
                    If gridDataItem.Selected And fnctype = "V" Then

                        Try
                            If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colEST_REV_SUP_BY_CDE").Display = True Then
                                RowSuppliedBy = DirectCast(gridDataItem.FindControl("TxtEST_REV_SUP_BY_CDE"), TextBox).Text
                            End If
                        Catch ex As Exception
                            RowSuppliedBy = ""
                        End Try

                        If RowSuppliedBy = "" Then
                            Me.ShowMessage("Vendor Code is required.")
                            Exit Sub
                        Else
                            If VendorCode <> "" AndAlso VendorCode <> RowSuppliedBy Then
                                Me.ShowMessage("Only one Vendor code is allowed for new Purchase Order.")
                                Exit Sub
                            Else
                                VendorCode = RowSuppliedBy
                            End If
                        End If

                        If IsNumeric(gridDataItem.GetDataKeyValue("SEQ_NBR")) Then
                            If gridDataItem.GetDataKeyValue("SEQ_NBR") = "-1" Then
                                dtKey &= gridDataItem.GetDataKeyValue("INDEX") & ","
                            Else
                                SequenceString &= gridDataItem.GetDataKeyValue("SEQ_NBR") & ","
                            End If
                        End If

                        count += 1
                    End If
                Next
                If count = 0 Then
                    Me.ShowMessage("No rows were selected for Purchase Order creation.")
                    Exit Sub
                Else
                    Dim insert As Boolean

                    insert = Me.InsertPO(PONumber, VendorCode, SequenceString)

                    If insert = True AndAlso PONumber > 0 Then

                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstimateQuoteDetails.MasterTableView.Items
                            fnctype = gridDataItem.GetDataKeyValue("FNC_TYPE")
                            If gridDataItem.Selected And fnctype = "V" Then

                                Dim PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing

                                Try
                                    FunctionCode = DirectCast(gridDataItem.FindControl("TxtFunctionCode"), TextBox).Text
                                Catch ex As Exception
                                    FunctionCode = ""
                                End Try

                                Try
                                    Quantity = CDec(DirectCast(gridDataItem.FindControl("TxtEST_REV_QUANTITY"), TextBox).Text)
                                Catch ex As Exception
                                    Quantity = 0
                                End Try

                                Try
                                    Rate = CDec(DirectCast(gridDataItem.FindControl("TxtEST_REV_RATE"), TextBox).Text)
                                Catch ex As Exception
                                    Rate = 0
                                End Try

                                Try
                                    ExtendedAmount = CDec(DirectCast(gridDataItem.FindControl("TxtEST_REV_EXT_AMT"), TextBox).Text)
                                Catch ex As Exception
                                    ExtendedAmount = 0
                                End Try

                                Try
                                    MarkupPercent = CDec(DirectCast(gridDataItem.FindControl("TxtEST_REV_COMM_PCT"), TextBox).Text)
                                Catch ex As Exception
                                    MarkupPercent = 0
                                End Try

                                Try
                                    ExtendedMarkupAmount = CDec(DirectCast(gridDataItem.FindControl("TxtMARKUP_AMT"), TextBox).Text)
                                Catch ex As Exception
                                    ExtendedMarkupAmount = 0
                                End Try

                                PurchaseOrderDetail = New AdvantageFramework.Database.Entities.PurchaseOrderDetail

                                PurchaseOrderDetail.JobNumber = Me.JobNum
                                PurchaseOrderDetail.JobComponentNumber = Me.JobCompNum
                                PurchaseOrderDetail.FunctionCode = FunctionCode
                                PurchaseOrderDetail.Quantity = Quantity
                                PurchaseOrderDetail.Rate = Rate
                                PurchaseOrderDetail.ExtendedAmount = ExtendedAmount
                                PurchaseOrderDetail.CommissionPercent = MarkupPercent
                                PurchaseOrderDetail.ExtendedMarkupAmount = ExtendedMarkupAmount

                                PurchaseOrderDetail.PurchaseOrderNumber = PONumber

                                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                    AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Insert(DbContext, PurchaseOrderDetail)
                                End Using

                            End If
                        Next

                        Dim StringBuilder As System.Text.StringBuilder = Nothing
                        StringBuilder = New System.Text.StringBuilder

                        StringBuilder.Append("purchaseorder.aspx?po_number=")

                        StringBuilder.Append(AdvantageFramework.Security.Encryption.EncryptPO(PONumber.ToString))
                        StringBuilder.Append("&pagemode=edit")

                        Dim DisplayPONumber As String = Nothing

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                            DisplayPONumber = AdvantageFramework.PurchaseOrders.LoadPurchaseOrderDisplayNumber(DbContext, PONumber)
                        End Using

                        Me.OpenWindow("PO " & DisplayPONumber & " - New Purchase Order", StringBuilder.ToString())
                    End If
                End If
            Case "DeleteRows" '**Grid** Toolbar event
                'SaveAlmostEverything(False)

                Dim chk As CheckBox
                Dim DelString As String = ""
                Dim count As Integer = 0
                Dim dtKey As String
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstimateQuoteDetails.MasterTableView.Items
                    chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                    If chk.Checked Then
                        Dim d As String = gridDataItem.GetDataKeyValue("INDEX")
                        If IsNumeric(gridDataItem.GetDataKeyValue("SEQ_NBR")) Then
                            If gridDataItem.GetDataKeyValue("SEQ_NBR") = "-1" Then
                                dtKey &= gridDataItem.GetDataKeyValue("INDEX") & ","
                            Else
                                DelString &= gridDataItem.GetDataKeyValue("SEQ_NBR") & ","
                            End If
                        End If
                        count += 1
                    End If
                Next
                If count = 0 Then
                    Me.ShowMessage("No rows were selected for deletion.")
                End If
                DelString = MiscFN.RemoveTrailingDelimiter(DelString, ",")
                dtKey = MiscFN.RemoveTrailingDelimiter(dtKey, ",")
                If dtKey <> "" Then
                    Dim seq() As String = dtKey.Split(",")
                    Dim i As Integer
                    For i = seq.Length - 1 To 0 Step -1
                        Me.DtQuoteFunctions.Rows.RemoveAt(seq(i) - 1)
                    Next
                End If
                Dim DelSQL As String = ""
                If EstNum > 0 And EstCompNum > 0 And DelString.Length > 0 Then
                    DelSQL = "DELETE FROM ESTIMATE_REV_DET WHERE ESTIMATE_NUMBER = " & EstNum & " AND EST_COMPONENT_NBR = " & EstCompNum & " AND EST_QUOTE_NBR = " & QuoteNum & " AND EST_REV_NBR = " & Me.ddRevision.SelectedValue & " AND SEQ_NBR IN (" & DelString & ")"
                    Using MyConn As New SqlConnection(Session("ConnString"))
                        MyConn.Open()
                        Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                        Dim MyCmd As New SqlCommand(DelSQL, MyConn, MyTrans)
                        Try
                            MyCmd.ExecuteNonQuery()
                            MyTrans.Commit()
                        Catch ex As Exception
                            MyTrans.Rollback()
                        Finally
                            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        End Try
                    End Using
                End If
                Session("DT_EST_QUOTE_FNC") = Nothing
                Me.RadGridEstimateQuoteDetails.Rebind()
            Case "QuickAdd" '**Grid** Toolbar event
                'SaveAlmostEverything()
                If Me.TxtJobNum.Text = "" Then
                    Session("QuickAddEstJobNum") = 0
                Else
                    Session("QuickAddEstJobNum") = Me.TxtJobNum.Text
                End If
                If Me.TxtJobCompNum.Text = "" Then
                    Session("QuickAddEstJobCompNum") = 0
                Else
                    Session("QuickAddEstJobCompNum") = Me.TxtJobCompNum.Text
                End If
                Session("QuickAddEstClient") = Me.hfClientCode.Value
                Session("QuickAddEstDivision") = Me.hfDivisionCode.Value
                Session("QuickAddEstProduct") = Me.hfProductCode.Value
                Session("QuickAddEstSalesClass") = Me.hfSalesClass.Value
                'Session("QuickAddEstEmpCode") = ""
                Dim appr As Integer = 0
                If hlApproved.Visible = True Or hlApprovedInternal.Visible = True Then
                    appr = 1
                End If
                Dim StrURL As String = "Estimating_QuickAdd.aspx?EstNum=" & Me.EstNum & "&EstComp=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&appr=" & appr
                'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "QuickAddWindow", "Template Options", StrURL, 550, 725, True)
                Me.OpenWindow("Template Options", StrURL, 550, 725, False, True, "RefreshPage")
            Case "CopyQuote" '**Grid** Toolbar event
                'SaveAlmostEverything()    
                If Me.TxtJobNum.Text = "" Then
                    Session("QuickAddEstJobNum") = 0
                Else
                    Session("QuickAddEstJobNum") = Me.TxtJobNum.Text
                End If
                If Me.TxtJobCompNum.Text = "" Then
                    Session("QuickAddEstJobCompNum") = 0
                Else
                    Session("QuickAddEstJobCompNum") = Me.TxtJobCompNum.Text
                End If
                Session("QuickAddEstClient") = Me.hfClientCode.Value
                Session("QuickAddEstDivision") = Me.hfDivisionCode.Value
                Session("QuickAddEstProduct") = Me.hfProductCode.Value
                Session("QuickAddEstSalesClass") = Me.hfSalesClass.Value
                Dim appr As Integer = 0
                If hlApproved.Visible = True Or hlApprovedInternal.Visible = True Then
                    appr = 1
                End If
                Dim StrURL As String = "Estimating_CopyFrom.aspx?EstNum=" & Me.EstNum & "&EstComp=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&appr=" & appr
                'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "CopyFromWindow", "Copy From Quote", StrURL, 590, 900, True)
                Me.OpenWindow("Copy From Quote", StrURL, 590, 980, False, True, "RefreshPage")
            Case "SetPhase" '**Grid** Toolbar event
                'SaveAlmostEverything()    
                Dim chk As CheckBox
                Dim count As Integer = 0
                Dim UpdateString As String = ""
                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstimateQuoteDetails.MasterTableView.Items
                    chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                    If chk.Checked Then
                        If IsNumeric(gridDataItem.GetDataKeyValue("SEQ_NBR")) Then
                            UpdateString &= gridDataItem.GetDataKeyValue("SEQ_NBR") & ","
                        End If
                        count += 1
                    End If
                Next
                UpdateString = MiscFN.RemoveTrailingDelimiter(UpdateString, ",")
                If count = 0 Then
                    Me.ShowMessage("No rows were selected for phase.")
                    Exit Sub
                End If
                Dim StrURL As String = "Estimating_Phase.aspx?EstNum=" & Me.EstNum & "&EstCompNum=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&uStr=" & UpdateString
                'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "PhaseWindow", "Phase", StrURL, 200, 400, True)
                Me.OpenWindow("Phase", StrURL, 200, 400, False, True, "RefreshPage")
            Case "ClearPhase"
                'SaveAlmostEverything(False)

                Dim chk As CheckBox
                Dim UpdateString As String = ""
                Dim count As Integer = 0
                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstimateQuoteDetails.MasterTableView.Items
                    chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                    If chk.Checked Then
                        If IsNumeric(gridDataItem.GetDataKeyValue("SEQ_NBR")) Then
                            UpdateString &= gridDataItem.GetDataKeyValue("SEQ_NBR") & ","
                        End If
                        count += 1
                    End If
                Next
                If count = 0 Then
                    Me.ShowMessage("No rows were selected for clearing phase.")
                End If
                UpdateString = MiscFN.RemoveTrailingDelimiter(UpdateString, ",")
                Dim UpdateSQL As String = ""
                If EstNum > 0 And EstCompNum > 0 And UpdateString.Length > 0 Then
                    est.UpdateQuotePhase(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, UpdateString, -1, "")
                    Me.RadGridEstimateQuoteDetails.Rebind()
                    LoadPhaseList()
                End If
            Case "NewRow" '**Grid** Toolbar event
                'Me.SaveGrid(False, False)
                'Me.SaveQuoteHeader()
                If Me.JobNum = 0 Then
                    If Me.TxtJobNum.Text = "" Then
                        Session("NewRowEstJobNum") = 0
                    Else
                        Session("NewRowEstJobNum") = Me.TxtJobNum.Text
                        Me.JobNum = Me.TxtJobNum.Text
                    End If
                End If
                If Me.TxtJobCompNum.Text = "" Then
                    Session("NewRowEstJobCompNum") = 0
                Else
                    Session("NewRowEstJobCompNum") = Me.TxtJobCompNum.Text
                End If
                Session("NewRowEstClient") = Me.hfClientCode.Value
                Session("NewRowEstDivision") = Me.hfDivisionCode.Value
                Session("NewRowEstProduct") = Me.hfProductCode.Value
                Session("NewRowEstSalesClass") = Me.hfSalesClass.Value
                'Session("QuickAddEstEmpCode") = ""
                Dim appr As Integer = 0
                If hlApproved.Visible = True Or hlApprovedInternal.Visible = True Then
                    appr = 1
                End If
                Dim StrURL As String = "Estimating_AddRow.aspx?EstNum=" & Me.EstNum & "&EstComp=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&appr=" & appr
                Dim AddRowQuerystring As New AdvantageFramework.Web.QueryString

                AddRowQuerystring.Page = "Estimating_AddRow.aspx"
                AddRowQuerystring.EstimateNumber = Me.EstNum
                AddRowQuerystring.EstimateComponentNumber = Me.EstCompNum
                AddRowQuerystring.EstimateQuoteNumber = Me.QuoteNum
                AddRowQuerystring.JobNumber = Me.JobNum
                AddRowQuerystring.ClientCode = Me.hfClientCode.Value
                AddRowQuerystring.DivisionCode = Me.hfDivisionCode.Value
                AddRowQuerystring.ProductCode = Me.hfProductCode.Value
                AddRowQuerystring.SalesClassCode = Me.hfSalesClass.Value



                'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "QuickAddWindow", "Template Options", StrURL, 550, 725, True)
                Me.OpenWindow("Add New Rows", AddRowQuerystring.ToString(True), 550, 725, False, True, "RefreshPage")
                'If Me.RadGridEstimateQuoteDetails.MasterTableView.Items.Count > 0 Then
                '    Dim ests As New cEstimating(Session("ConnString"), Session("UserCode"))
                '    Dim RowIndex As Integer = 0
                '    For i As Integer = 0 To Me.RadGridEstimateQuoteDetails.MasterTableView.Items.Count - 1
                '        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridEstimateQuoteDetails.Items(i), Telerik.Web.UI.GridDataItem)
                '        Dim CurrentTaskSeq As Integer
                '        Dim IsUserRow As Integer
                '        Dim RowFunctionCode As String = ""
                '        Dim RowFunctionDesc As String = ""
                '        Dim RowSuppliedBy As String = ""
                '        Try
                '            CurrentTaskSeq = CType(CurrentGridRow.GetDataKeyValue("SEQ_NBR"), Integer)
                '        Catch ex As Exception
                '            CurrentTaskSeq = -1
                '        End Try

                '        Try
                '            IsUserRow = CType(CurrentGridRow.Item("ColTESTING_COLUMN").Text, Integer)
                '        Catch ex As Exception
                '            IsUserRow = 0
                '        End Try
                '        If IsUserRow = 1 Then
                '            Try
                '                If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colFNC_CODE").Display = True Then
                '                    RowFunctionCode = DirectCast(CurrentGridRow.FindControl("TxtFunctionCode"), TextBox).Text
                '                End If
                '            Catch ex As Exception
                '                RowFunctionCode = ""
                '            End Try
                '            Try
                '                'If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("HfFNC_DESCRIPTION").Display = True Then
                '                RowFunctionDesc = DirectCast(CurrentGridRow.FindControl("HfFNC_DESCRIPTION"), HiddenField).Value
                '                'End If
                '            Catch ex As Exception
                '                RowFunctionDesc = ""
                '            End Try
                '            Try
                '                If Me.RadGridEstimateQuoteDetails.MasterTableView.GetColumn("colEST_REV_SUP_BY_CDE").Display = True Then
                '                    RowSuppliedBy = DirectCast(CurrentGridRow.FindControl("TxtEST_REV_SUP_BY_CDE"), TextBox).Text
                '                End If
                '            Catch ex As Exception
                '                RowSuppliedBy = ""
                '            End Try
                '            Dim PK As Integer = -1
                '            Try
                '                PK = CurrentGridRow.OwnerTableView.DataKeyValues(RowIndex)("INDEX")
                '            Catch ex As Exception
                '                PK = -1
                '            End Try
                '            If PK >= 0 Then
                '                ests.EstimateQuoteDetailsDatatable_UpdateRow_User(Me.DtQuoteFunctions, PK, RowFunctionCode, RowFunctionDesc, RowSuppliedBy)
                '            End If
                '        End If
                '        RowIndex += 1
                '    Next
                'End If
                ''add a blank row
                'Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                'est.EstimateQuoteDetailsDatatable_AddUserRow(Me.DtQuoteFunctions, Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum, "")
                'Session("DT_EST_QUOTE_FNC") = Me.DtQuoteFunctions
                'Me.RadGridEstimateQuoteDetails.Rebind()
            Case "QuoteFromPS" '**Grid** Toolbar event
                'SaveAlmostEverything()     
                Dim appr As Integer = 0
                If hlApproved.Visible = True Or hlApprovedInternal.Visible = True Then
                    appr = 1
                End If
                Session("QuoteFromPSJobNum") = Me.TxtJobNum.Text
                Session("QuoteFromPSJobCompNum") = Me.TxtJobCompNum.Text
                Session("QuoteFromPSClient") = Me.hfClientCode.Value
                Session("QuoteFromPSDivision") = Me.hfDivisionCode.Value
                Session("QuoteFromPSProduct") = Me.hfProductCode.Value
                Session("QuoteFromPSSalesClass") = Me.hfSalesClass.Value
                Dim StrURL As String = "Estimating_QuoteFromPS.aspx?EstNum=" & Me.EstNum & "&EstComp=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&appr=" & appr
                'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "QuoteFromPSWindow", "Create Quote From Schedule", StrURL, 400, 1000, True)
                Me.OpenWindow("Create Quote From Schedule", StrURL, 400, 1000, False, True, "RefreshPage")

            Case "JobHistory"
                Try
                    'SaveAlmostEverything()                         
                    Dim appr As Integer = 0
                    If hlApproved.Visible = True Or hlApprovedInternal.Visible = True Then
                        appr = 1
                    End If
                    Dim StrURL As String = "Estimating_JobHistory.aspx?EstNum=" & Me.EstNum & "&EstComp=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & Me.ddRevision.SelectedValue & "&appr=" & appr
                    Me.OpenWindow("Review Job History", StrURL, 700, 1200, False, True, "RefreshPage")
                Catch ex As Exception
                End Try


            Case "Campaign"
                Try
                    'SaveAlmostEverything()    
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
                    Dim jc As AdvantageFramework.Database.Entities.Job = Nothing
                    Dim jcmaster As AdvantageFramework.Database.Entities.JobComponent = Nothing
                    Dim estimate As String()
                    Dim estimatemaster As String()
                    Dim EstApproval As Generic.List(Of AdvantageFramework.Database.Views.EstimateApproval) = Nothing
                    Dim hasFunction As Boolean = False
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        If Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "" Then
                            jc = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, CInt(Me.TxtJobNum.Text))
                            If jc.CampaignID Is Nothing Then
                                Me.ShowMessage("There is no matching campaign.  The rates will not be updated.")
                                Exit Sub
                            End If
                        End If
                        If jc IsNot Nothing Then
                            campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, jc.CampaignID)
                            If campaign.JobNumber Is Nothing Then
                                Me.ShowMessage("There were no matching functions to update.")
                                Exit Sub
                            Else
                                jcmaster = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, campaign.JobNumber, campaign.JobComponentNumber)
                                If jcmaster.EstimateNumber Is Nothing Then
                                    Exit Sub
                                    Me.ShowMessage("There were no matching functions to update.")
                                Else
                                    EstApproval = AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(DbContext).ToList.Where(Function(EstimateApproval) EstimateApproval.EstimateNumber = jcmaster.EstimateNumber And EstimateApproval.EstimateComponentNumber = jcmaster.EstimateComponentNumber).ToList
                                    If EstApproval.Count = 0 Then
                                        Me.ShowMessage("There were no matching functions to update.")
                                        Exit Sub
                                    Else
                                        For Each EstimateApproval In EstApproval
                                            estimatemaster = (From Approval In AdvantageFramework.Database.Procedures.EstimateRevisionDetail.Load(DbContext)
                                                              Where Approval.EstimateNumber = EstimateApproval.EstimateNumber _
                                                                    And Approval.EstimateComponentNumber = EstimateApproval.EstimateComponentNumber _
                                                                    And Approval.EstimateQuoteNumber = EstimateApproval.EstimateQuoteNumber _
                                                                    And Approval.EstimateRevisionNumber = EstimateApproval.EstimateRevisionNumber
                                                              Select Approval.FunctionCode).ToArray
                                            estimate = (From Approval In AdvantageFramework.Database.Procedures.EstimateRevisionDetail.Load(DbContext)
                                                        Where Approval.EstimateNumber = EstNum _
                                                              And Approval.EstimateComponentNumber = EstCompNum _
                                                              And Approval.EstimateQuoteNumber = QuoteNum _
                                                             And Approval.EstimateRevisionNumber = ddRevision.SelectedValue
                                                        Select Approval.FunctionCode).ToArray
                                        Next
                                        For i As Integer = 0 To estimatemaster.Count - 1
                                            For j As Integer = 0 To estimate.Count - 1
                                                If estimatemaster(i) = estimate(j) Then
                                                    hasFunction = True
                                                End If
                                            Next
                                        Next
                                        If hasFunction = False Then
                                            Me.ShowMessage("There were no matching functions to update.")
                                            Exit Sub
                                        End If
                                    End If
                                End If
                            End If

                        End If
                    End Using


                    If EstNum > 0 And EstCompNum > 0 Then
                        Dim update As Boolean = False
                        update = est.UpdateQuoteFromCampaign(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, Me.TxtJobNum.Text, Me.TxtJobCompNum.Text)
                        Me.RadGridEstimateQuoteDetails.Rebind()
                        If update = True Then
                            Me.ShowMessage("All matching functions were updated.")
                        End If
                    End If
                Catch ex As Exception
                End Try

            Case "Add"
                Try
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    If EstNum > 0 And EstCompNum > 0 Then

                        Dim check As Integer = 0
                        check = est.CheckQuotesApprovals(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, Me.TxtJobNum.Text, Me.TxtJobCompNum.Text, "Quote")
                        If check = 0 Then
                            Me.ShowMessage("There is no existing quote to add from.  Process cancelled.")
                            Exit Sub
                        End If

                        check = est.CheckQuotesApprovals(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, Me.TxtJobNum.Text, Me.TxtJobCompNum.Text, "Approvals")
                        If check = 0 Then
                            Me.ShowMessage("There are no internally or client approved quotes available.  Nothing to update")
                            Exit Sub
                        End If

                        Dim update As Boolean = False
                        update = est.UpdateMasterEstimateFromQuotes(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, Me.TxtJobNum.Text, Me.TxtJobCompNum.Text, "Add")
                        If update = True Then
                            Me.RadGridEstimateQuoteDetails.Rebind()
                            Me.ShowMessage("Quote updated.")
                        End If
                    End If
                Catch ex As Exception
                End Try
            Case "Subtract"
                Try
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    If EstNum > 0 And EstCompNum > 0 Then

                        Dim check As Integer = 0
                        check = est.CheckQuotesApprovals(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, Me.TxtJobNum.Text, Me.TxtJobCompNum.Text, "Quote")
                        If check = 0 Then
                            Me.ShowMessage("There is no existing quote to subtract from.  Process cancelled.")
                            Exit Sub
                        End If

                        check = est.CheckQuotesApprovals(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, Me.TxtJobNum.Text, Me.TxtJobCompNum.Text, "Approvals")
                        If check = 0 Then
                            Me.ShowMessage("There are no internally or client approved quotes available.  Nothing to update")
                            Exit Sub
                        End If

                        Dim update As Boolean = False
                        update = est.UpdateMasterEstimateFromQuotes(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.ddRevision.SelectedValue, Me.TxtJobNum.Text, Me.TxtJobCompNum.Text, "Subtract")
                        If update = True Then
                            Me.RadGridEstimateQuoteDetails.Rebind()
                            Me.ShowMessage("Quote updated.")
                        End If
                    End If
                Catch ex As Exception
                End Try
        End Select
    End Sub

    Private Property CurrentGridPageIndex As Integer = 0
    Private Sub RadGridEstimateQuoteDetails_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridEstimateQuoteDetails.PageIndexChanged
        Me.SaveGrid()
        Me.CurrentGridPageIndex = e.NewPageIndex
        Me.RadGridEstimateQuoteDetails.Rebind()
    End Sub

    Private Sub RadGridEstimateQuoteDetails_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridEstimateQuoteDetails.PageSizeChanged

        If _LoadingDatasource = False Then

            MiscFN.SavePageSize(Me.RadGridEstimateQuoteDetails.ID, e.NewPageSize)

        End If

    End Sub


    'Purchase Order From Estimate
    Public Function InsertPO(ByRef PONumber As Integer, ByVal VendorCode As String, ByVal SequenceString As String) As Boolean

        'objects
        Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
        Dim PurchaseOrderDetail As AdvantageFramework.Database.Classes.PurchaseOrderDetail = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim ErrorMessage As String = Nothing
        Dim Inserted As Boolean = False
        Dim POApprovalCode As String = Nothing
        Dim PurchaseOrderDetailList As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetail) = Nothing
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing

        If _CanUserInsertPO Then

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    PurchaseOrder = Me.FillObject(True, VendorCode)

                    If PurchaseOrder IsNot Nothing Then

                        PurchaseOrder.DbContext = DbContext

                        PurchaseOrder.Number = Nothing

                        If AdvantageFramework.PurchaseOrders.ValidatePurchaseOrderWithOfficeLimits(_Session, DbContext, PurchaseOrder, ErrorMessage) Then

                            PurchaseOrder.CreatedDate = cEmployee.TimeZoneToday
                            Inserted = AdvantageFramework.Database.Procedures.PurchaseOrder.Insert(DbContext, PurchaseOrder)

                        End If

                        If Inserted Then

                            PONumber = PurchaseOrder.Number



                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
                Inserted = False
            End Try

            If ErrorMessage <> "" Then

                Me.ShowMessage(ErrorMessage)

            End If

        End If

        Return Inserted

    End Function

    Private Function FillObject(ByVal IsNew As Boolean, ByVal VendorCode As String) As AdvantageFramework.Database.Entities.PurchaseOrder

        'objects
        Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim PurchaseOrderApprovalRuleCode As String = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If IsNew Then

                    PurchaseOrder = New AdvantageFramework.Database.Entities.PurchaseOrder

                    PurchaseOrder.CreatedDate = cEmployee.TimeZoneToday
                    PurchaseOrder.UserCode = _Session.UserCode

                    PurchaseOrder.EmployeeCode = _Session.User.EmployeeCode
                    PurchaseOrder.VendorCode = VendorCode

                    LoadEntity(PurchaseOrder)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, PurchaseOrder.EmployeeCode)

                    If String.IsNullOrEmpty(Employee.PurchaseOrderApprovalRuleCode) = False Then

                        PurchaseOrderApprovalRuleCode = Employee.PurchaseOrderApprovalRuleCode

                    Else

                        Try

                            PurchaseOrderApprovalRuleCode = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(DbContext, Employee.DepartmentTeamCode).PurchaseOrderApprovalRuleCode

                        Catch ex As Exception
                            PurchaseOrderApprovalRuleCode = Nothing
                        End Try

                    End If

                    PurchaseOrder.PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleCode

                Else

                    'PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, _PONumber)

                    'If PurchaseOrder IsNot Nothing Then

                    '    LoadEntity(PurchaseOrder)

                    'End If

                End If

            End Using

        Catch ex As Exception
            PurchaseOrder = Nothing
        End Try

        FillObject = PurchaseOrder

    End Function

    Private Sub LoadEntity(ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder)

        'objects
        Dim FooterType As AdvantageFramework.PurchaseOrders.FooterTypes = AdvantageFramework.PurchaseOrders.FooterTypes.Custom
        Dim Limit As Decimal = Nothing
        Dim POTotal As Decimal = Nothing
        Dim vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

        If PurchaseOrder IsNot Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, PurchaseOrder.VendorCode)
            End Using

            PurchaseOrder.Description = "New Purchase Order"
            PurchaseOrder.Revision = 0
            PurchaseOrder.Date = Now.Date
            PurchaseOrder.DueDate = Nothing
            PurchaseOrder.VendorContactCode = vendor.DefaultVendorContactCode
            PurchaseOrder.IsWorkComplete = 0

            PurchaseOrder.DeliveryInstruction = ""
            PurchaseOrder.MainInstruction = ""

            FooterType = AdvantageFramework.PurchaseOrders.FooterTypes.AgencyDefined

            PurchaseOrder.Footer = AdvantageFramework.PurchaseOrders.SetFooterText(FooterType, "")

            PurchaseOrder.ExceedFlag = 0

            'If Me.RadNumericTextBoxPOLimit.Value.HasValue Then

            '    Try

            '        POTotal = CDec(Me.RadNumericTextBoxPOTotal.Value.GetValueOrDefault(0))

            '    Catch ex As Exception
            '        POTotal = 0
            '    End Try

            '    Try

            '        Limit = CDec(Me.RadNumericTextBoxPOLimit.Value.GetValueOrDefault(0))

            '    Catch ex As Exception
            '        Limit = 0
            '    End Try

            '    If POTotal > Limit Then

            '        PurchaseOrder.ExceedFlag = 1

            '    End If

            'End If

        End If

    End Sub


#Region " Pagemethods for Estimating "

    <System.Web.Services.WebMethod(True)>
    Public Shared Function DetailAutoSaveEst(ByVal DataKey As String, ByVal ControlType As String, ByVal ControlName As String, ByVal ControlValue As String) As String
        'Dim ci As System.Globalization.CultureInfo
        'Dim lg As New LoGlo()
        'ci = lg.GetCultureInfo
        LoGlo.UserCultureSet(LoGlo.UserCultureGet())
        Try
            Dim EstNumber As Integer = 0
            Dim EstComponentNbr As Integer = 0
            Dim EstQuoteNbr As Integer = 0
            Dim EstRevNbr As Integer = 0
            Dim JobNumber As Integer = 0
            Dim JobComponentNbr As Integer = 0
            Dim SeqNbr As Integer = -1
            Dim ReturnMessage As String = ""
            Dim RunSQL As Boolean = True
            Dim est As New cEstimating

            Dim ar() As String
            ar = DataKey.Split("|")
            If ar.Length <> 5 Then
                Return "Error: Could not get datakey"
                Exit Function
            End If
            Try
                EstNumber = ar(0)
            Catch ex As Exception
                EstNumber = 0
            End Try
            Try
                EstComponentNbr = ar(1)
            Catch ex As Exception
                EstComponentNbr = 0
            End Try
            Try
                EstQuoteNbr = ar(2)
            Catch ex As Exception
                EstQuoteNbr = 0
            End Try
            Try
                EstRevNbr = ar(3)
            Catch ex As Exception
                EstRevNbr = 0
            End Try
            Try
                SeqNbr = ar(4)
            Catch ex As Exception
                SeqNbr = -1
            End Try

            If EstNumber > 0 And EstComponentNbr > 0 And SeqNbr > -1 Then

                Try
                    Dim SQL As New System.Text.StringBuilder
                    Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                        Dim MyTrans As SqlTransaction
                        MyConn.Open()
                        MyTrans = MyConn.BeginTransaction
                        Dim MyCmd As New SqlCommand()

                        SQL.Append("UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET ")

                        Dim pVALUE As New SqlParameter
                        pVALUE.ParameterName = "@VALUE"

                        ControlValue = ControlValue.Trim()
                        Select Case ControlType
                            Case "txt"
                                If ControlName.IndexOf("TxtEST_REV_QUANTITY") > -1 Then
                                    If ControlValue.Trim() <> "" And IsNumeric(ControlValue) = False Then
                                        ReturnMessage = "Invalid Quantity"
                                    End If
                                    SQL.Append("EST_REV_QUANTITY")
                                    With pVALUE
                                        .SqlDbType = SqlDbType.Decimal
                                        If ControlValue = "" Then
                                            .Value = 0.0
                                        Else
                                            .Value = CType(ControlValue, Decimal)
                                        End If
                                    End With
                                ElseIf ControlName.IndexOf("TxtEST_REV_RATE") > -1 Then
                                    If ControlValue.Trim() <> "" And IsNumeric(ControlValue) = False Then
                                        ReturnMessage = "Invalid Rate"
                                    End If
                                    SQL.Append("EST_REV_RATE")
                                    With pVALUE
                                        .SqlDbType = SqlDbType.Decimal
                                        If ControlValue = "" Then
                                            .Value = 0.0
                                        Else
                                            .Value = CType(ControlValue, Decimal)
                                        End If
                                    End With
                                ElseIf ControlName.IndexOf("TxtEST_REV_EXT_AMT") > -1 Then
                                    If ControlValue.Trim() <> "" And IsNumeric(ControlValue) = False Then
                                        ReturnMessage = "Invalid Amount"
                                    End If
                                    SQL.Append("EST_REV_EXT_AMT")
                                    With pVALUE
                                        .SqlDbType = SqlDbType.Decimal
                                        If ControlValue = "" Then
                                            .Value = 0.0
                                        Else
                                            .Value = CType(ControlValue, Decimal)
                                        End If
                                    End With
                                ElseIf ControlName.IndexOf("TxtEST_REV_COMM_PCT") > -1 Then
                                    If ControlValue.Trim() <> "" And IsNumeric(ControlValue) = False Then
                                        ReturnMessage = "Invalid Markup Percentage"
                                    End If
                                    SQL.Append("EST_REV_COMM_PCT")
                                    With pVALUE
                                        .SqlDbType = SqlDbType.Decimal
                                        If ControlValue = "" Then
                                            .Value = 0.0
                                        Else
                                            .Value = CType(ControlValue, Decimal)
                                        End If
                                    End With
                                ElseIf ControlName.IndexOf("TxtMARKUP_AMT") > -1 Then
                                    If ControlValue.Trim() <> "" And IsNumeric(ControlValue) = False Then
                                        ReturnMessage = "Invalid Markup Amount"
                                    End If
                                    SQL.Append("EXT_MARKUP_AMT")
                                    With pVALUE
                                        .SqlDbType = SqlDbType.Decimal
                                        If ControlValue = "" Then
                                            .Value = 0.0
                                        Else
                                            .Value = CType(ControlValue, Decimal)
                                        End If
                                    End With
                                ElseIf ControlName.IndexOf("TxtEST_FNC_COMMENT") > -1 Then
                                    SQL.Append("EST_FNC_COMMENT")
                                    With pVALUE
                                        .SqlDbType = SqlDbType.Text
                                        If ControlValue = "" Then
                                            .Value = System.DBNull.Value
                                        Else
                                            .Value = ControlValue
                                        End If
                                    End With
                                ElseIf ControlName.IndexOf("TxtEST_REV_SUP_BY_NTE") > -1 Then
                                    SQL.Append("EST_REV_SUP_BY_NTE")
                                    With pVALUE
                                        .SqlDbType = SqlDbType.Text
                                        If ControlValue = "" Then
                                            .Value = System.DBNull.Value
                                        Else
                                            .Value = ControlValue
                                        End If
                                    End With
                                End If
                            Case "chk"
                                If ControlName.IndexOf("ChkCPU") > -1 Then
                                    SQL.Append("INCL_CPU")
                                End If
                                With pVALUE
                                    .SqlDbType = SqlDbType.SmallInt
                                    .Value = CType(ControlValue, Integer)
                                End With
                        End Select
                        SQL.Append(" = @VALUE")
                        If ControlName.IndexOf("TxtEST_FNC_COMMENT") > -1 Then
                            SQL.Append(", EST_FNC_COMMENT_HTML = @VALUE")
                        End If
                        If ControlName.IndexOf("TxtEST_REV_SUP_BY_NTE") > -1 Then
                            SQL.Append(", EST_REV_SUP_BY_HTML = @VALUE")
                        End If
                        SQL.Append(" WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR AND SEQ_NBR = @SEQ_NBR;")

                        Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
                        pESTIMATE_NUMBER.Value = EstNumber
                        MyCmd.Parameters.Add(pESTIMATE_NUMBER)

                        Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
                        pEST_COMPONENT_NBR.Value = EstComponentNbr
                        MyCmd.Parameters.Add(pEST_COMPONENT_NBR)

                        Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
                        pEST_QUOTE_NBR.Value = EstQuoteNbr
                        MyCmd.Parameters.Add(pEST_QUOTE_NBR)

                        Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
                        pEST_REV_NBR.Value = EstRevNbr
                        MyCmd.Parameters.Add(pEST_REV_NBR)

                        Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                        pSEQ_NBR.Value = SeqNbr
                        MyCmd.Parameters.Add(pSEQ_NBR)

                        MyCmd.Parameters.Add(pVALUE)

                        Try
                            If RunSQL = True And ReturnMessage = "" Then
                                With MyCmd
                                    .CommandText = SQL.ToString()
                                    .CommandType = CommandType.Text
                                    .Connection = MyConn
                                    .Transaction = MyTrans
                                    .ExecuteNonQuery()
                                End With
                                MyTrans.Commit()
                                ReturnMessage = ""
                            End If
                        Catch ex As Exception
                            MyTrans.Rollback()
                            ReturnMessage = ex.Message.ToString()
                        Finally
                            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        End Try
                    End Using
                Catch ex As Exception
                    ReturnMessage = ex.Message.ToString()
                End Try

                Return ReturnMessage
            Else
                Return "Invalid datakey:  " & EstNumber.ToString() & "," & EstComponentNbr.ToString() & "," & SeqNbr.ToString()
                Exit Function
            End If


        Catch ex As Exception
            Return "Error:  " & ex.Message.ToString().Replace("'", "").Replace(";", "").Replace("%", "").Replace("""", "")
        End Try
    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function SaveSuppliedByCode(ByVal DataKey As String, ByVal SuppliedByCodeId As String, ByVal TheHfSupByCode As String, ByVal TheFunctionType As String, ByVal SuppliedByCodeValue As String) As String

        Dim EstNumber As Integer = 0
        Dim EstComponentNbr As Integer = 0
        Dim EstQuoteNbr As Integer = 0
        Dim EstRevNbr As Integer = 0
        Dim JobNumber As Integer = 0
        Dim JobComponentNbr As Integer = 0
        Dim SeqNbr As Integer = -1
        Dim ReturnMessage As String = ""
        Dim SQL As New System.Text.StringBuilder

        Dim ar() As String
        ar = DataKey.Split("|")
        If ar.Length <> 5 Then
            Return "Error:  Could not get datakey"
            Exit Function
        End If
        Try
            EstNumber = ar(0)
        Catch ex As Exception
            EstNumber = 0
        End Try
        Try
            EstComponentNbr = ar(1)
        Catch ex As Exception
            EstComponentNbr = 0
        End Try
        Try
            EstQuoteNbr = ar(2)
        Catch ex As Exception
            EstQuoteNbr = 0
        End Try
        Try
            EstRevNbr = ar(3)
        Catch ex As Exception
            EstRevNbr = 0
        End Try
        Try
            SeqNbr = ar(2)
        Catch ex As Exception
            SeqNbr = -1
        End Try

        If EstNumber > 0 And EstComponentNbr > 0 And EstQuoteNbr > 0 And SeqNbr > -1 Then
            Dim IsValid As Boolean = False
            Dim GoodFncCode As String = ""
            Dim dt As New DataTable
            Dim v As New cValidations(HttpContext.Current.Session("ConnString"))
            Dim parameterEST_REV_SUP_BY_CDE As New SqlParameter("@EST_REV_SUP_BY_CDE", SqlDbType.VarChar)

            If TheFunctionType = "E" Then
                If SuppliedByCodeValue <> "" Then
                    If TheHfSupByCode <> SuppliedByCodeValue Then
                        If v.ValidateEmpCodetd(SuppliedByCodeValue) = True Then
                            parameterEST_REV_SUP_BY_CDE.Value = SuppliedByCodeValue
                        Else
                            ReturnMessage = "Invalid Employee Code"
                        End If
                    End If
                Else
                    parameterEST_REV_SUP_BY_CDE.Value = System.DBNull.Value
                End If
            ElseIf TheFunctionType = "V" Then
                If SuppliedByCodeValue <> "" Then
                    If TheHfSupByCode <> SuppliedByCodeValue Then
                        If v.ValidateVendor(SuppliedByCodeValue) Then
                            parameterEST_REV_SUP_BY_CDE.Value = SuppliedByCodeValue
                        Else
                            ReturnMessage = "Invalid Vendor Code"
                        End If
                    End If
                Else
                    parameterEST_REV_SUP_BY_CDE.Value = System.DBNull.Value
                End If
            End If


            'if input is something that is custom, save, clear fnc code and push back empty to fnc
            With SQL
                .Append("UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET EST_REV_SUP_BY_CDE = @EST_REV_SUP_BY_CDE")
                .Append("WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR AND SEQ_NBR = @SEQ_NBR;")
            End With

            Dim MyCmd As New SqlCommand()
            MyCmd.Parameters.Add(parameterEST_REV_SUP_BY_CDE)

            Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            pESTIMATE_NUMBER.Value = EstNumber
            MyCmd.Parameters.Add(pESTIMATE_NUMBER)

            Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            pEST_COMPONENT_NBR.Value = EstComponentNbr
            MyCmd.Parameters.Add(pEST_COMPONENT_NBR)

            Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            pEST_QUOTE_NBR.Value = EstQuoteNbr
            MyCmd.Parameters.Add(pEST_QUOTE_NBR)

            Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
            pEST_REV_NBR.Value = EstRevNbr
            MyCmd.Parameters.Add(pEST_REV_NBR)

            Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
            pSEQ_NBR.Value = SeqNbr
            MyCmd.Parameters.Add(pSEQ_NBR)

            Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                Dim MyTrans As SqlTransaction
                MyConn.Open()
                MyTrans = MyConn.BeginTransaction
                Try
                    With MyCmd
                        .CommandText = SQL.ToString()
                        .CommandType = CommandType.Text
                        .Connection = MyConn
                        .Transaction = MyTrans
                        .ExecuteNonQuery()
                        ReturnMessage = "OK|" & SuppliedByCodeId
                    End With
                    MyTrans.Commit()
                Catch ex As Exception
                    MyTrans.Rollback()
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try
            End Using



        End If


        Return ReturnMessage
    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function SaveContingency(ByVal DataKey As String, ByVal ContPctClientId As String, ByVal TheExtAmount As Decimal, ByVal TheMarkupAmount As Decimal, ByVal ContPctValue As Decimal) As String

        Dim EstNumber As Integer = 0
        Dim EstComponentNbr As Integer = 0
        Dim EstQuoteNbr As Integer = 0
        Dim EstRevNbr As Integer = 0
        Dim JobNumber As Integer = 0
        Dim JobComponentNbr As Integer = 0
        Dim SeqNbr As Integer = -1
        Dim ReturnMessage As String = ""
        Dim SQL As New System.Text.StringBuilder

        Dim ar() As String
        ar = DataKey.Split("|")
        If ar.Length <> 5 Then
            Return "Error:  Could not get datakey"
            Exit Function
        End If
        Try
            EstNumber = ar(0)
        Catch ex As Exception
            EstNumber = 0
        End Try
        Try
            EstComponentNbr = ar(1)
        Catch ex As Exception
            EstComponentNbr = 0
        End Try
        Try
            EstQuoteNbr = ar(2)
        Catch ex As Exception
            EstQuoteNbr = 0
        End Try
        Try
            EstRevNbr = ar(3)
        Catch ex As Exception
            EstRevNbr = 0
        End Try
        Try
            SeqNbr = ar(2)
        Catch ex As Exception
            SeqNbr = -1
        End Try

        If EstNumber > 0 And EstComponentNbr > 0 And EstQuoteNbr > 0 And SeqNbr > -1 Then
            Dim IsValid As Boolean = False
            Dim GoodFncCode As String = ""
            Dim dt As New DataTable
            Dim v As New cValidations(HttpContext.Current.Session("ConnString"))
            Dim parameterEST_REV_CONT_PCT As New SqlParameter("@EST_REV_CONT_PCT", SqlDbType.Decimal)
            Dim parameterEXT_CONTINGENCY As New SqlParameter("@EXT_CONTINGENCY", SqlDbType.Decimal)
            Dim parameterEXT_MU_CONT As New SqlParameter("@EXT_MU_CONT", SqlDbType.Decimal)

            If IsNumeric(ContPctValue) Then
                If ContPctValue > 0 Then
                    parameterEXT_CONTINGENCY.Value = TheExtAmount * (ContPctValue / 100)
                    If TheMarkupAmount > 0 Then
                        parameterEXT_MU_CONT.Value = (TheMarkupAmount * (ContPctValue / 100))
                    Else
                        parameterEXT_MU_CONT.Value = 0
                    End If
                Else
                    parameterEXT_CONTINGENCY.Value = 0
                End If
            Else
                ReturnMessage = "Invalid Contingency Percentage"
            End If

            With SQL
                .Append("UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET EST_REV_CONT_PCT = @EST_REV_CONT_PCT AND EXT_CONTINGENCY = @EXT_CONTINGENCY AND EXT_MU_CONT = @EXT_MU_CONT")
                .Append("WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR AND SEQ_NBR = @SEQ_NBR;")
            End With

            Dim MyCmd As New SqlCommand()
            MyCmd.Parameters.Add(parameterEST_REV_CONT_PCT)
            MyCmd.Parameters.Add(parameterEXT_CONTINGENCY)
            MyCmd.Parameters.Add(parameterEXT_MU_CONT)

            Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            pESTIMATE_NUMBER.Value = EstNumber
            MyCmd.Parameters.Add(pESTIMATE_NUMBER)

            Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            pEST_COMPONENT_NBR.Value = EstComponentNbr
            MyCmd.Parameters.Add(pEST_COMPONENT_NBR)

            Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            pEST_QUOTE_NBR.Value = EstQuoteNbr
            MyCmd.Parameters.Add(pEST_QUOTE_NBR)

            Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
            pEST_REV_NBR.Value = EstRevNbr
            MyCmd.Parameters.Add(pEST_REV_NBR)

            Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
            pSEQ_NBR.Value = SeqNbr
            MyCmd.Parameters.Add(pSEQ_NBR)

            Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                Dim MyTrans As SqlTransaction
                MyConn.Open()
                MyTrans = MyConn.BeginTransaction
                Try
                    With MyCmd
                        .CommandText = SQL.ToString()
                        .CommandType = CommandType.Text
                        .Connection = MyConn
                        .Transaction = MyTrans
                        .ExecuteNonQuery()
                        ReturnMessage = "OK|" & ContPctClientId
                    End With
                    MyTrans.Commit()
                Catch ex As Exception
                    MyTrans.Rollback()
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try
            End Using



        End If


        Return ReturnMessage
    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function SaveTaxCode(ByVal DataKey As String, ByVal TaxCodeClientId As String, ByVal TheHfTaxComm As String, ByVal TheHfTaxCommOnly As String, ByVal TheExtAmount As Decimal, ByVal TheMarkupAmount As Decimal, ByVal TheContPct As Decimal, ByVal TheFunctionType As String, ByVal TaxCodeValue As Decimal) As String

        Dim EstNumber As Integer = 0
        Dim EstComponentNbr As Integer = 0
        Dim EstQuoteNbr As Integer = 0
        Dim EstRevNbr As Integer = 0
        Dim JobNumber As Integer = 0
        Dim JobComponentNbr As Integer = 0
        Dim SeqNbr As Integer = -1
        Dim ReturnMessage As String = ""
        Dim SQL As New System.Text.StringBuilder

        Dim ar() As String
        ar = DataKey.Split("|")
        If ar.Length <> 5 Then
            Return "Error:  Could not get datakey"
            Exit Function
        End If
        Try
            EstNumber = ar(0)
        Catch ex As Exception
            EstNumber = 0
        End Try
        Try
            EstComponentNbr = ar(1)
        Catch ex As Exception
            EstComponentNbr = 0
        End Try
        Try
            EstQuoteNbr = ar(2)
        Catch ex As Exception
            EstQuoteNbr = 0
        End Try
        Try
            EstRevNbr = ar(3)
        Catch ex As Exception
            EstRevNbr = 0
        End Try
        Try
            SeqNbr = ar(2)
        Catch ex As Exception
            SeqNbr = -1
        End Try

        If EstNumber > 0 And EstComponentNbr > 0 And EstQuoteNbr > 0 And SeqNbr > -1 Then
            Dim IsValid As Boolean = False
            Dim GoodFncCode As String = ""
            Dim dt As New DataTable
            Dim v As New cValidations(HttpContext.Current.Session("ConnString"))
            Dim est As New cEstimating(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
            Dim parameterTAX_CODE As New SqlParameter("@TAX_CODE", SqlDbType.VarChar)
            Dim parameterTAX_STATE_PCT As New SqlParameter("@TAX_STATE_PCT", SqlDbType.Decimal)
            Dim parameterTAX_COUNTY_PCT As New SqlParameter("@TAX_COUNTY_PCT", SqlDbType.Decimal)
            Dim parameterTAX_CITY_PCT As New SqlParameter("@TAX_CITY_PCT", SqlDbType.Decimal)
            Dim parameterTAX_RESALE As New SqlParameter("@TAX_RESALE", SqlDbType.SmallInt)
            Dim parameterEXT_STATE_RESALE As New SqlParameter("@EXT_STATE_RESALE", SqlDbType.Decimal)
            Dim parameterEXT_COUNTY_RESALE As New SqlParameter("@EXT_COUNTY_RESALE", SqlDbType.Decimal)
            Dim parameterEXT_CITY_RESALE As New SqlParameter("@EXT_CITY_RESALE", SqlDbType.Decimal)
            Dim parameterEXT_STATE_CONT As New SqlParameter("@EXT_STATE_CONT", SqlDbType.Decimal)
            Dim parameterEXT_COUNTY_CONT As New SqlParameter("@EXT_COUNTY_CONT", SqlDbType.Decimal)
            Dim parameterEXT_CITY_CONT As New SqlParameter("@EXT_CITY_CONT", SqlDbType.Decimal)
            Dim parameterEXT_NONRESALE_TAX As New SqlParameter("@EXT_NONRESALE_TAX", SqlDbType.Decimal)
            Dim parameterEXT_NR_CONT As New SqlParameter("@EXT_NR_CONT", SqlDbType.Decimal)

            Dim taxresalestate As Decimal = 0.0
            Dim taxresalecity As Decimal = 0.0
            Dim taxresalecounty As Decimal = 0.0
            Dim taxnonresalestate As Decimal = 0.0
            Dim taxnonresalecity As Decimal = 0.0
            Dim taxnonresalecounty As Decimal = 0.0
            Dim taxmarkupstate As Decimal = 0.0
            Dim taxmarkupcity As Decimal = 0.0
            Dim taxmarkupcounty As Decimal = 0.0
            Dim taxcontstate As Decimal = 0.0
            Dim taxcontcity As Decimal = 0.0
            Dim taxcontcounty As Decimal = 0.0
            Dim RowContAmt As Decimal = TheExtAmount * (TheContPct / 100)
            Dim RowMuContAmt As Decimal = (TheMarkupAmount * (TheContPct / 100))

            If TaxCodeValue <> "" Then
                SQL.Append("UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET")
                If v.ValidateTaxCode(TaxCodeValue) = True Then
                    parameterTAX_CODE.Value = TaxCodeValue
                    SQL.Append(" TAX_CODE = @TAX_CODE")
                Else
                    ReturnMessage = "Invalid Tax Code."
                End If
                dt = est.GetAddNewTaxData(TaxCodeValue)
                If dt.Rows.Count > 0 Then
                    parameterTAX_STATE_PCT.Value = dt.Rows(0)("TAX_STATE_PERCENT")
                    parameterTAX_COUNTY_PCT.Value = dt.Rows(0)("TAX_COUNTY_PERCENT")
                    parameterTAX_CITY_PCT.Value = dt.Rows(0)("TAX_CITY_PERCENT")
                    parameterTAX_RESALE.Value = dt.Rows(0)("TAX_RESALE")
                    SQL.Append(", TAX_STATE_PCT = @TAX_STATE_PCT, TAX_COUNTY_PCT = @TAX_COUNTY_PCT, TAX_CITY_PCT = @TAX_CITY_PCT, TAX_RESALE = @TAX_RESALE")
                    If dt.Rows(0)("TAX_RESALE") = 1 Then
                        If TheHfTaxCommOnly <> "1" Then
                            taxresalestate = TheExtAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                            taxresalecounty = TheExtAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                            taxresalecity = TheExtAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                            'RowLineTotal += taxresalestate + taxresalecounty + taxresalecity
                        End If
                        If TheHfTaxComm = "1" Then
                            If TheMarkupAmount > 0 Then
                                taxmarkupstate = TheMarkupAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                taxmarkupcounty = TheMarkupAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                taxmarkupcity = TheMarkupAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                'RowLineTotal += taxmarkupstate + taxmarkupcounty + taxmarkupcity
                            End If
                        End If

                        parameterEXT_STATE_RESALE.Value = taxresalestate + taxmarkupstate
                        parameterEXT_COUNTY_RESALE.Value = taxresalecounty + taxmarkupcounty
                        parameterEXT_CITY_RESALE.Value = taxresalecity + taxmarkupcity

                        If RowContAmt > 0 Then
                            If TheHfTaxComm = "1" And TheHfTaxCommOnly = "1" Then
                                RowContAmt = RowMuContAmt
                            ElseIf TheHfTaxComm = "1" Then
                                RowContAmt += RowMuContAmt
                            End If
                            taxcontstate = RowContAmt * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                            taxcontcounty = RowContAmt * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                            taxcontcity = RowContAmt * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)

                            parameterEXT_STATE_CONT.Value = taxcontstate
                            parameterEXT_COUNTY_CONT.Value = taxcontcounty
                            parameterEXT_CITY_CONT.Value = taxcontcity
                            'RowLineTotalCont += taxcontstate + taxcontcounty + taxcontcity
                        End If
                        SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE, EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                    End If
                    If dt.Rows(0)("TAX_RESALE") <> 1 Then
                        If TheFunctionType = "V" Then
                            If TheHfTaxCommOnly <> "1" Then
                                taxnonresalestate = TheExtAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                taxnonresalecounty = TheExtAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                taxnonresalecity = TheExtAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                'RowLineTotal += (RowExtAmount * (CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100) + (RowExtAmount * (CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100) + (RowExtAmount * (CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)

                                parameterEXT_NONRESALE_TAX.Value = taxnonresalestate + taxnonresalecounty + taxnonresalecity
                                SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                            End If
                            If RowContAmt > 0 Then
                                If TheHfTaxComm = "1" And TheHfTaxCommOnly = "1" Then
                                    RowContAmt = RowMuContAmt
                                ElseIf TheHfTaxComm = "1" Then
                                    RowContAmt += RowMuContAmt
                                End If
                                taxcontstate = RowContAmt * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                taxcontcounty = RowContAmt * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                taxcontcity = RowContAmt * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)

                                parameterEXT_NR_CONT.Value = taxcontstate + taxcontcounty + taxcontcity
                                SQL.Append(", EXT_NR_CONT = @EXT_NR_CONT")
                                'RowLineTotalCont += taxcontstate + taxcontcounty + taxcontcity
                            End If
                        ElseIf TheFunctionType = "E" Or TheFunctionType = "I" Then
                            If TheHfTaxCommOnly <> "1" Then
                                taxresalestate = TheExtAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                taxresalecounty = TheExtAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                taxresalecity = TheExtAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                'RowLineTotal += taxresalestate + taxresalecounty + taxresalecity
                            End If
                            If RowContAmt > 0 Then
                                If TheHfTaxComm = "1" And TheHfTaxCommOnly = "1" Then
                                    RowContAmt = RowMuContAmt
                                ElseIf TheHfTaxComm = "1" Then
                                    RowContAmt += RowMuContAmt
                                End If
                                taxcontstate = RowContAmt * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                taxcontcounty = RowContAmt * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                taxcontcity = RowContAmt * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)

                                parameterEXT_STATE_CONT.Value = taxcontstate
                                parameterEXT_COUNTY_CONT.Value = taxcontcounty
                                parameterEXT_CITY_CONT.Value = taxcontcity
                                'RowLineTotalCont += taxcontstate + taxcontcounty + taxcontcity
                                SQL.Append(", EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                            End If
                        End If
                        If TheHfTaxComm = "1" Then
                            If TheMarkupAmount > 0 Then
                                taxmarkupstate = TheMarkupAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                taxmarkupcounty = TheMarkupAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                taxmarkupcity = TheMarkupAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                'RowLineTotal += taxmarkupstate + taxmarkupcounty + taxmarkupcity
                            End If
                        End If

                        parameterEXT_STATE_RESALE.Value = taxresalestate + taxmarkupstate
                        parameterEXT_COUNTY_RESALE.Value = taxresalecounty + taxmarkupcounty
                        parameterEXT_CITY_RESALE.Value = taxresalecity + taxmarkupcity
                        SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE")
                    End If
                End If
            Else
                parameterTAX_CODE.Value = ""
            End If

            With SQL
                .Append("WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR AND SEQ_NBR = @SEQ_NBR;")
            End With

            Dim MyCmd As New SqlCommand()
            MyCmd.Parameters.Add(parameterTAX_CODE)
            MyCmd.Parameters.Add(parameterTAX_STATE_PCT)
            MyCmd.Parameters.Add(parameterTAX_COUNTY_PCT)
            MyCmd.Parameters.Add(parameterTAX_CITY_PCT)
            MyCmd.Parameters.Add(parameterTAX_RESALE)
            MyCmd.Parameters.Add(parameterEXT_STATE_RESALE)
            MyCmd.Parameters.Add(parameterEXT_COUNTY_RESALE)
            MyCmd.Parameters.Add(parameterEXT_CITY_RESALE)
            MyCmd.Parameters.Add(parameterEXT_STATE_CONT)
            MyCmd.Parameters.Add(parameterEXT_COUNTY_CONT)
            MyCmd.Parameters.Add(parameterEXT_CITY_CONT)
            MyCmd.Parameters.Add(parameterEXT_NONRESALE_TAX)
            MyCmd.Parameters.Add(parameterEXT_NR_CONT)

            Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            pESTIMATE_NUMBER.Value = EstNumber
            MyCmd.Parameters.Add(pESTIMATE_NUMBER)

            Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            pEST_COMPONENT_NBR.Value = EstComponentNbr
            MyCmd.Parameters.Add(pEST_COMPONENT_NBR)

            Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            pEST_QUOTE_NBR.Value = EstQuoteNbr
            MyCmd.Parameters.Add(pEST_QUOTE_NBR)

            Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
            pEST_REV_NBR.Value = EstRevNbr
            MyCmd.Parameters.Add(pEST_REV_NBR)

            Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
            pSEQ_NBR.Value = SeqNbr
            MyCmd.Parameters.Add(pSEQ_NBR)

            Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                Dim MyTrans As SqlTransaction
                MyConn.Open()
                MyTrans = MyConn.BeginTransaction
                Try
                    With MyCmd
                        .CommandText = SQL.ToString()
                        .CommandType = CommandType.Text
                        .Connection = MyConn
                        .Transaction = MyTrans
                        .ExecuteNonQuery()
                        ReturnMessage = "OK|" & TaxCodeClientId
                    End With
                    MyTrans.Commit()
                Catch ex As Exception
                    MyTrans.Rollback()
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try
            End Using



        End If


        Return ReturnMessage
    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function SaveEstQty(ByVal DataKey As String, ByVal Qty As String, ByVal Rate As String, ByVal CPM As String,
                                      ByVal MarkupPct As String, ByVal TaxCode As String,
                                      ByVal ContPct As String, ByVal TaxComm As String, ByVal TaxCommOnly As String,
                                      ByVal TheFunctionType As String, ByVal ExtAmountRow As String, ByVal ExtMarkupAmt As String,
                                      ByVal FunctionCode As String, ByVal SuppliedBy As String, ByVal EmpTitle As String, ByVal ctrlChange As String, ByVal controlid As String) As String

        LoGlo.UserCultureSet(LoGlo.UserCultureGet())

        Dim ci As New System.Globalization.CultureInfo(LoGlo.UserCultureGet())
        Dim cultureStr As String = LoGlo.UserCultureGet
        'LoGlo.UserCultureSet("en-US")

        Dim est As New cEstimating(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
        Dim v As New cValidations(HttpContext.Current.Session("ConnString"))
        Dim groupSeparator As String = ci.NumberFormat.NumberGroupSeparator
        Dim decimalSeparator As String = ci.NumberFormat.NumberDecimalSeparator
        'Dim extat As String = ExtAmountRow.Replace(groupSeparator, "").Replace(decimalSeparator, ".")
        'Dim ext As Decimal = CDec(ExtAmountRow.Replace(groupSeparator, "").Replace(decimalSeparator, "."))

        Dim ReturnMessage As String = ""
        Try
            Dim EstNumber As Integer = 0
            Dim EstComponentNbr As Integer = 0
            Dim EstQuoteNbr As Integer = 0
            Dim EstRevNbr As Integer = 0
            Dim JobNumber As Integer = 0
            Dim JobComponentNbr As Integer = 0
            Dim SeqNbr As Integer = -1
            Dim SQL As New System.Text.StringBuilder
            Dim emptitleid As Integer = 0

            Dim ar() As String
            ar = DataKey.Split("|")
            If ar.Length <> 5 Then
                Return "Error:  Could not get datakey"
                Exit Function
            End If
            Try
                EstNumber = ar(0)
            Catch ex As Exception
                EstNumber = 0
            End Try
            Try
                EstComponentNbr = ar(1)
            Catch ex As Exception
                EstComponentNbr = 0
            End Try
            Try
                EstQuoteNbr = ar(2)
            Catch ex As Exception
                EstQuoteNbr = 0
            End Try
            Try
                EstRevNbr = ar(3)
            Catch ex As Exception
                EstRevNbr = 0
            End Try
            Try
                SeqNbr = ar(4)
            Catch ex As Exception
                SeqNbr = -1
            End Try

            If ctrlChange = "function" Then
                Try
                    If FunctionCode <> "" Then
                        If v.ValidateFunctionCodeEst(FunctionCode) = False Then
                            ReturnMessage = "Invalid Function Code."
                        Else
                            'Double check the function type
                            Dim Func As AdvantageFramework.Database.Entities.Function = Nothing
                            Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
                                Func = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, FunctionCode)
                                If Func IsNot Nothing Then
                                    TheFunctionType = Func.Type
                                End If
                            End Using

                        End If
                    Else
                        ReturnMessage = "Function Code is Required."
                    End If
                Catch ex As Exception
                End Try
            End If

            If ctrlChange = "suppliedby" Then
                'Supplied By
                Try
                    If TheFunctionType = "E" Then
                        If SuppliedBy <> "" Then
                            If v.ValidateEmpCodetd(SuppliedBy) = True Then

                            Else
                                ReturnMessage = "Invalid Employee Code."
                            End If
                            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
                            Dim Employeeoffice As System.Collections.Generic.List(Of String) = Nothing
                            Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
                                Employeeoffice = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, HttpContext.Current.Session("EmpCode")).Select(Function(Entity) Entity.OfficeCode).ToList

                                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
                                    Try
                                        Employee = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllEmployeesByUser(DbContext, SecurityDbContext, HttpContext.Current.Session("UserCode"))
                                                    Where Entity.Code = SuppliedBy
                                                    Select Entity).Single
                                    Catch ex As Exception
                                        Employee = Nothing
                                    End Try

                                    If Employeeoffice.Count > 0 And Employee.Code <> HttpContext.Current.Session("EmpCode") Then
                                        If Employeeoffice.Contains(Employee.OfficeCode) = False Then
                                            ReturnMessage = "Invalid Employee Code."
                                            SuppliedBy = ""
                                        End If
                                    End If
                                End Using
                            End Using
                        End If
                    ElseIf TheFunctionType = "V" Then
                        If SuppliedBy <> "" Then
                            If v.ValidateVendor(SuppliedBy) = True Then

                            Else
                                ReturnMessage = "Invalid Vendor Code."
                                SuppliedBy = ""
                            End If
                        End If
                    ElseIf TheFunctionType = "I" Then
                        If SuppliedBy <> "" Then
                            ReturnMessage = "Supplied By can only be specified for employee time or vendor functions."
                            SuppliedBy = ""
                        End If
                    End If
                Catch ex As Exception
                End Try
            End If

            If ctrlChange = "taxcode" And TaxCode <> "" Then
                If v.ValidateTaxCode(TaxCode) = False Then
                    ReturnMessage = "Invalid Tax Code."
                End If
            End If

            If ctrlChange = "emptitle" Then
                Try
                    Dim EpTitle As AdvantageFramework.Database.Entities.EmployeeTitle = Nothing
                    If EmpTitle <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
                            Try
                                EpTitle = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadByEmployeeTitleDescription(DbContext, EmpTitle)
                            Catch ex As Exception
                                EpTitle = Nothing
                            End Try

                            If EpTitle Is Nothing Then
                                ReturnMessage = "Invalid Employee Title."
                            Else
                                emptitleid = EpTitle.ID
                            End If
                        End Using
                    End If
                Catch ex As Exception
                End Try
            End If

            If HttpContext.Current.Session("EstimateQtyValid") Is Nothing Or HttpContext.Current.Session("EstimateQtyValid") = 1 Then
                If Qty.Trim <> "" And IsNumeric(Qty.Replace(groupSeparator, "")) = False Then
                    ReturnMessage = "INVALID|Invalid Qty|" & controlid
                    HttpContext.Current.Session("EstimateQtyValid") = 0
                Else
                    HttpContext.Current.Session("EstimateQtyValid") = 1
                End If
            Else
                HttpContext.Current.Session("EstimateQtyValid") = 1
            End If
            If HttpContext.Current.Session("EstimateRateValid") Is Nothing Or HttpContext.Current.Session("EstimateRateValid") = 1 Then
                If Rate.Trim <> "" And IsNumeric(Rate.Replace(groupSeparator, "")) = False Then
                    ReturnMessage = "INVALID|Invalid Rate|" & controlid
                    HttpContext.Current.Session("EstimateRateValid") = 0
                Else
                    HttpContext.Current.Session("EstimateRateValid") = 1
                End If
            Else
                HttpContext.Current.Session("EstimateRateValid") = 1
            End If
            If HttpContext.Current.Session("EstimateMarkupPercentValid") Is Nothing Or HttpContext.Current.Session("EstimateMarkupPercentValid") = 1 Then
                If MarkupPct.Trim <> "" And IsNumeric(MarkupPct.Replace(groupSeparator, "")) = False Then
                    ReturnMessage = "INVALID|Invalid Markup Percent|" & controlid
                    HttpContext.Current.Session("EstimateMarkupPercentValid") = 0
                Else
                    HttpContext.Current.Session("EstimateMarkupPercentValid") = 1
                End If
            Else
                HttpContext.Current.Session("EstimateMarkupPercentValid") = 1
            End If
            If HttpContext.Current.Session("EstimateContingencyPercentValid") Is Nothing Or HttpContext.Current.Session("EstimateContingencyPercentValid") = 1 Then
                If ContPct.Trim <> "" And IsNumeric(ContPct.Replace(groupSeparator, "")) = False Then
                    ReturnMessage = "INVALID|Invalid Contingency Percent|" & controlid
                    HttpContext.Current.Session("EstimateContingencyPercentValid") = 0
                Else
                    HttpContext.Current.Session("EstimateContingencyPercentValid") = 1
                End If
            Else
                HttpContext.Current.Session("EstimateContingencyPercentValid") = 1
            End If
            If HttpContext.Current.Session("EstimateExtendedValid") Is Nothing Or HttpContext.Current.Session("EstimateExtendedValid") = 1 Then
                If ExtAmountRow.Trim <> "" And IsNumeric(ExtAmountRow.Replace(groupSeparator, "")) = False Then
                    ReturnMessage = "INVALID|Invalid Extended Amount|" & controlid
                    HttpContext.Current.Session("EstimateExtendedValid") = 0
                Else
                    HttpContext.Current.Session("EstimateExtendedValid") = 1
                End If
            Else
                HttpContext.Current.Session("EstimateExtendedValid") = 1
            End If
            If HttpContext.Current.Session("EstimateMarkupAmountValid") Is Nothing Or HttpContext.Current.Session("EstimateMarkupAmountValid") = 1 Then
                If ExtMarkupAmt.Trim <> "" And IsNumeric(ExtMarkupAmt.Replace(groupSeparator, "")) = False Then
                    ReturnMessage = "INVALID|Invalid Markup Amount|" & controlid
                    HttpContext.Current.Session("EstimateMarkupAmountValid") = 0
                Else
                    HttpContext.Current.Session("EstimateMarkupAmountValid") = 1
                End If
            Else
                HttpContext.Current.Session("EstimateMarkupAmountValid") = 1
            End If

            If EstNumber > 0 And EstComponentNbr > 0 And EstQuoteNbr > 0 And SeqNbr > -1 And ReturnMessage = "" And HttpContext.Current.Session("EstimateRateValid") = 1 Then
                Dim IsValid As Boolean = False
                Dim GoodFncCode As String = ""
                Dim dt As New DataTable
                Dim parameterFNC_CODE As SqlParameter = New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 6)
                Dim parameterFNC_TYPE As SqlParameter = New SqlParameter("@FNC_TYPE", SqlDbType.VarChar, 6)
                Dim parameterEST_REV_SUP_BY_CDE As SqlParameter = New SqlParameter("@EST_REV_SUP_BY_CDE", SqlDbType.VarChar, 6)
                Dim parameterEST_REV_QUANTITY As New SqlParameter("@EST_REV_QUANTITY", SqlDbType.Decimal)
                Dim parameterEST_REV_RATE As New SqlParameter("@EST_REV_RATE", SqlDbType.Decimal)
                Dim parameterEST_REV_EXT_AMT As New SqlParameter("@EST_REV_EXT_AMT", SqlDbType.Decimal)
                Dim parameterEST_REV_COMM_PCT As New SqlParameter("@EST_REV_COMM_PCT", SqlDbType.Decimal)
                Dim parameterEXT_MARKUP_AMT As New SqlParameter("@EXT_MARKUP_AMT", SqlDbType.Decimal)
                Dim parameterEST_REV_CONT_PCT As New SqlParameter("@EST_REV_CONT_PCT", SqlDbType.Decimal)
                Dim parameterEXT_CONTINGENCY As New SqlParameter("@EXT_CONTINGENCY", SqlDbType.Decimal)
                Dim parameterEXT_MU_CONT As New SqlParameter("@EXT_MU_CONT", SqlDbType.Decimal)
                Dim parameterLINE_TOTAL As New SqlParameter("@LINE_TOTAL", SqlDbType.Decimal)
                Dim parameterLINE_TOTAL_CONT As New SqlParameter("@LINE_TOTAL_CONT", SqlDbType.Decimal)
                Dim parameterEXT_STATE_RESALE As New SqlParameter("@EXT_STATE_RESALE", SqlDbType.Decimal)
                Dim parameterEXT_COUNTY_RESALE As New SqlParameter("@EXT_COUNTY_RESALE", SqlDbType.Decimal)
                Dim parameterEXT_CITY_RESALE As New SqlParameter("@EXT_CITY_RESALE", SqlDbType.Decimal)
                Dim parameterEXT_STATE_CONT As New SqlParameter("@EXT_STATE_CONT", SqlDbType.Decimal)
                Dim parameterEXT_COUNTY_CONT As New SqlParameter("@EXT_COUNTY_CONT", SqlDbType.Decimal)
                Dim parameterEXT_CITY_CONT As New SqlParameter("@EXT_CITY_CONT", SqlDbType.Decimal)
                Dim parameterEXT_NONRESALE_TAX As New SqlParameter("@EXT_NONRESALE_TAX", SqlDbType.Decimal)
                Dim parameterEXT_NR_CONT As New SqlParameter("@EXT_NR_CONT", SqlDbType.Decimal)
                Dim parameterTAX_CODE As New SqlParameter("@TAX_CODE", SqlDbType.VarChar)
                Dim parameterTAX_STATE_PCT As New SqlParameter("@TAX_STATE_PCT", SqlDbType.Decimal)
                Dim parameterTAX_COUNTY_PCT As New SqlParameter("@TAX_COUNTY_PCT", SqlDbType.Decimal)
                Dim parameterTAX_CITY_PCT As New SqlParameter("@TAX_CITY_PCT", SqlDbType.Decimal)
                Dim parameterTAX_RESALE As New SqlParameter("@TAX_RESALE", SqlDbType.SmallInt)
                Dim parameterEMP_TITLE_ID As New SqlParameter("@EMPLOYEE_TITLE_ID", SqlDbType.Int)

                parameterEST_REV_QUANTITY.Value = 0
                parameterEST_REV_RATE.Value = 0
                parameterEST_REV_EXT_AMT.Value = 0
                parameterEXT_MARKUP_AMT.Value = 0
                parameterEXT_CONTINGENCY.Value = 0
                parameterEXT_MU_CONT.Value = 0
                parameterLINE_TOTAL.Value = 0
                parameterLINE_TOTAL_CONT.Value = 0
                parameterEXT_STATE_RESALE.Value = 0
                parameterEXT_COUNTY_RESALE.Value = 0
                parameterEXT_CITY_RESALE.Value = 0
                parameterEXT_STATE_CONT.Value = 0
                parameterEXT_COUNTY_CONT.Value = 0
                parameterEXT_CITY_CONT.Value = 0
                parameterEXT_NONRESALE_TAX.Value = 0
                parameterEXT_NR_CONT.Value = 0

                Dim taxresalestate As Decimal = 0
                Dim taxresalecity As Decimal = 0
                Dim taxresalecounty As Decimal = 0
                Dim taxnonresalestate As Decimal = 0
                Dim taxnonresalecity As Decimal = 0
                Dim taxnonresalecounty As Decimal = 0
                Dim taxmarkupstate As Decimal = 0
                Dim taxmarkupcity As Decimal = 0
                Dim taxmarkupcounty As Decimal = 0
                Dim taxcontstate As Decimal = 0
                Dim taxcontcity As Decimal = 0
                Dim taxcontcounty As Decimal = 0
                Dim ExtAmount As Decimal = 0
                Dim MarkupAmount As Decimal = 0
                Dim LineTotal As Decimal = 0
                Dim LineTotalCont As Decimal = 0
                Dim RowContAmt As Decimal = 0
                Dim RowMuContAmt As Decimal = 0
                Dim RowRate As Decimal = 0
                Dim taxState As Decimal = 0
                Dim taxCounty As Decimal = 0
                Dim taxCity As Decimal = 0
                Dim taxResale As Integer = 0
                Dim fnctype As String = ""

                SQL.Append("UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET")
                If ctrlChange = "function" Then
                    SQL.Append(" FNC_CODE = @FNC_CODE,")
                    parameterFNC_CODE.Value = FunctionCode
                    SQL.Append(" EST_FNC_TYPE = @FNC_TYPE,")
                    parameterFNC_TYPE.Value = TheFunctionType

                    'Try
                    '    If TheFunctionType = "E" Then
                    '        If SuppliedBy <> "" Then
                    '            If v.ValidateEmpCodetd(SuppliedBy) = True Then

                    '            Else
                    '                ReturnMessage = "Invalid Employee Code."
                    '            End If
                    '            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
                    '            Dim Employeeoffice As System.Collections.Generic.List(Of String) = Nothing
                    '            Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
                    '                Employeeoffice = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, HttpContext.Current.Session("EmpCode")).Select(Function(Entity) Entity.OfficeCode).ToList

                    '                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
                    '                    Try
                    '                        Employee = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllEmployeesByUser(DbContext, SecurityDbContext, HttpContext.Current.Session("UserCode"))
                    '                                    Where Entity.Code = SuppliedBy
                    '                                    Select Entity).Single
                    '                    Catch ex As Exception
                    '                        Employee = Nothing
                    '                    End Try

                    '                    If Employeeoffice.Count > 0 And Employee.Code <> HttpContext.Current.Session("EmpCode") Then
                    '                        If Employeeoffice.Contains(Employee.OfficeCode) = False Then
                    '                            ReturnMessage = "Invalid Employee Code."
                    '                            SuppliedBy = ""
                    '                        End If
                    '                    End If
                    '                End Using
                    '            End Using
                    '        End If
                    '    ElseIf TheFunctionType = "V" Then
                    '        If SuppliedBy <> "" Then
                    '            If v.ValidateVendor(SuppliedBy) = True Then

                    '            Else
                    '                ReturnMessage = "Invalid Vendor Code."
                    '                SuppliedBy = ""
                    '            End If
                    '        End If
                    '    ElseIf TheFunctionType = "I" Then
                    '        If SuppliedBy <> "" Then
                    '            ReturnMessage = "Supplied By can only be specified for employee time or vendor functions."
                    '            SuppliedBy = ""
                    '        End If
                    '    End If
                    'Catch ex As Exception
                    'End Try


                End If
                If ctrlChange = "suppliedby" Then
                    SQL.Append(" EST_REV_SUP_BY_CDE = @EST_REV_SUP_BY_CDE,")
                    parameterEST_REV_SUP_BY_CDE.Value = SuppliedBy
                End If
                SQL.Append(" EST_REV_QUANTITY = @EST_REV_QUANTITY,")
                parameterEST_REV_QUANTITY.Value = Qty.Replace(groupSeparator, "").Replace(decimalSeparator, ".")

                If CDec(ExtAmountRow.Replace(groupSeparator, "").Replace(decimalSeparator, ".")) <> 0 And CDec(Qty.Replace(groupSeparator, "").Replace(decimalSeparator, ".")) <> 0 And (ctrlChange <> "rate" Or ctrlChange = "extamt") Then
                    If CPM = "1" Then
                        RowRate = (ExtAmountRow.Replace(groupSeparator, "").Replace(decimalSeparator, ".")) / (Qty.Replace(groupSeparator, "").Replace(decimalSeparator, ".")) * 1000
                    Else
                        RowRate = (ExtAmountRow.Replace(groupSeparator, "").Replace(decimalSeparator, ".")) / (Qty.Replace(groupSeparator, "").Replace(decimalSeparator, "."))
                    End If
                    SQL.Append(" EST_REV_RATE = @EST_REV_RATE,")
                    parameterEST_REV_RATE.Value = RowRate
                Else
                    RowRate = CDec(Rate.Replace(groupSeparator, "").Replace(decimalSeparator, "."))
                    If ctrlChange = "rate" Then
                        SQL.Append(" EST_REV_RATE = @EST_REV_RATE,")
                        parameterEST_REV_RATE.Value = RowRate
                    End If
                End If

                SQL.Append(" EST_REV_EXT_AMT = @EST_REV_EXT_AMT,")
                If ctrlChange <> "extamt" Then
                    If ctrlChange = "rate" Or ctrlChange = "quantity" Then
                        If CPM = "1" Then
                            ExtAmount = (CDec(Qty.Replace(groupSeparator, "").Replace(decimalSeparator, ".")) / 1000) * RowRate
                        Else
                            ExtAmount = CDec(Qty.Replace(groupSeparator, "").Replace(decimalSeparator, ".")) * RowRate
                        End If
                    Else
                        ExtAmount = CDec(ExtAmountRow.Replace(groupSeparator, "").Replace(decimalSeparator, "."))
                    End If
                Else
                    ExtAmount = CDec(ExtAmountRow.Replace(groupSeparator, "").Replace(decimalSeparator, "."))
                End If

                parameterEST_REV_EXT_AMT.Value = ExtAmount

                SQL.Append(" EST_REV_COMM_PCT = @EST_REV_COMM_PCT,")
                parameterEST_REV_COMM_PCT.Value = CDec(MarkupPct.Replace(groupSeparator, "").Replace(decimalSeparator, "."))

                SQL.Append(" EXT_MARKUP_AMT = @EXT_MARKUP_AMT,")
                If MarkupPct <> 0 And ctrlChange <> "markupamt" And ctrlChange <> "taxcode" And ctrlChange <> "contpct" Then
                    MarkupAmount = ExtAmount * (CDec(MarkupPct.Replace(groupSeparator, "").Replace(decimalSeparator, ".")) / 100)
                Else
                    MarkupAmount = ExtMarkupAmt
                End If
                parameterEXT_MARKUP_AMT.Value = MarkupAmount

                If ContPct <> 0 Then
                    RowContAmt = ExtAmount * (CDec(ContPct.Replace(groupSeparator, "").Replace(decimalSeparator, ".")) / 100)
                    RowMuContAmt = (MarkupAmount * (CDec(ContPct.Replace(groupSeparator, "").Replace(decimalSeparator, ".")) / 100))
                    LineTotalCont += RowContAmt + RowMuContAmt
                End If
                LineTotal += ExtAmount + MarkupAmount

                SQL.Append(" EST_REV_CONT_PCT = @EST_REV_CONT_PCT,")
                parameterEST_REV_CONT_PCT.Value = CDec(ContPct.Replace(groupSeparator, "").Replace(decimalSeparator, "."))
                SQL.Append(" EXT_CONTINGENCY = @EXT_CONTINGENCY,")
                parameterEXT_CONTINGENCY.Value = RowContAmt
                SQL.Append(" EXT_MU_CONT = @EXT_MU_CONT,")
                parameterEXT_MU_CONT.Value = RowMuContAmt
                SQL.Append(" TAX_CODE = @TAX_CODE")
                parameterTAX_CODE.Value = TaxCode

                If ctrlChange = "emptitle" Then
                    SQL.Append(", EMPLOYEE_TITLE_ID = @EMPLOYEE_TITLE_ID")
                    parameterEMP_TITLE_ID.Value = If(emptitleid = 0, DBNull.Value, emptitleid)
                Else

                End If

                If TaxCode <> "" Then
                    dt = est.GetAddNewTaxData(TaxCode)
                    taxState = dt.Rows(0)("TAX_STATE_PERCENT")
                    taxCounty = dt.Rows(0)("TAX_COUNTY_PERCENT")
                    taxCity = dt.Rows(0)("TAX_CITY_PERCENT")
                    If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                        taxResale = dt.Rows(0)("TAX_RESALE")
                    End If
                    SQL.Append(", TAX_STATE_PCT = @TAX_STATE_PCT")
                    SQL.Append(", TAX_COUNTY_PCT = @TAX_COUNTY_PCT")
                    SQL.Append(", TAX_CITY_PCT = @TAX_CITY_PCT")
                    SQL.Append(", TAX_RESALE = @TAX_RESALE")
                    parameterTAX_STATE_PCT.Value = taxState
                    parameterTAX_COUNTY_PCT.Value = taxCounty
                    parameterTAX_CITY_PCT.Value = taxCity
                    parameterTAX_RESALE.Value = taxResale
                    If dt.Rows.Count > 0 Then
                        If taxResale = 1 Then
                            If TaxCommOnly <> "1" Then
                                taxresalestate = ExtAmount * (taxState / 100)
                                taxresalecounty = ExtAmount * (taxCounty / 100)
                                taxresalecity = ExtAmount * (taxCity / 100)
                                'LineTotal += Math.Round(taxresalestate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxresalecounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxresalecity, 2, MidpointRounding.AwayFromZero)
                            End If
                            If TaxComm = "1" Then
                                If MarkupAmount > 0 Then
                                    taxmarkupstate = MarkupAmount * (taxState / 100)
                                    taxmarkupcounty = MarkupAmount * (taxCounty / 100)
                                    taxmarkupcity = MarkupAmount * (taxCity / 100)
                                    'LineTotal += Math.Round(taxmarkupstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxmarkupcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxmarkupcity, 2, MidpointRounding.AwayFromZero)
                                End If
                            End If

                            parameterEXT_STATE_RESALE.Value = taxresalestate + taxmarkupstate
                            parameterEXT_COUNTY_RESALE.Value = taxresalecounty + taxmarkupcounty
                            parameterEXT_CITY_RESALE.Value = taxresalecity + taxmarkupcity

                            If RowContAmt <> 0 Then
                                If TaxComm = "1" And TaxCommOnly = "1" Then
                                    RowContAmt = RowMuContAmt
                                ElseIf TaxComm = "1" Then
                                    RowContAmt += RowMuContAmt
                                End If
                                taxcontstate = RowContAmt * (taxState / 100)
                                taxcontcounty = RowContAmt * (taxCounty / 100)
                                taxcontcity = RowContAmt * (taxCity / 100)

                                parameterEXT_STATE_CONT.Value = taxcontstate
                                parameterEXT_COUNTY_CONT.Value = taxcontcounty
                                parameterEXT_CITY_CONT.Value = taxcontcity
                                'LineTotalCont += Math.Round(taxcontstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcity, 2, MidpointRounding.AwayFromZero)
                            End If
                            SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE, EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                            parameterEXT_NONRESALE_TAX.Value = taxnonresalestate + taxnonresalecounty + taxnonresalecity
                            SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                        End If
                        If taxResale <> 1 Then
                            If TheFunctionType = "V" Then
                                If TaxCommOnly <> "1" Then
                                    taxnonresalestate = ExtAmount * (taxState / 100)
                                    taxnonresalecounty = ExtAmount * (taxCounty / 100)
                                    taxnonresalecity = ExtAmount * (taxCity / 100)
                                    Dim trstate As Decimal = ExtAmount * (taxState / 100)
                                    Dim trcounty As Decimal = ExtAmount * (taxCounty / 100)
                                    Dim trcity As Decimal = ExtAmount * (taxCity / 100)
                                    'LineTotal += Math.Round(trstate, 2, MidpointRounding.AwayFromZero) + Math.Round(trcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(trcity, 2, MidpointRounding.AwayFromZero)

                                    parameterEXT_NONRESALE_TAX.Value = taxnonresalestate + taxnonresalecounty + taxnonresalecity
                                    SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                                End If
                                If RowContAmt <> 0 Then
                                    If TaxComm = "1" And TaxCommOnly = "1" Then
                                        RowContAmt = RowMuContAmt
                                    ElseIf TaxComm = "1" Then
                                        RowContAmt += RowMuContAmt
                                    End If
                                    taxcontstate = RowContAmt * (taxState / 100)
                                    taxcontcounty = RowContAmt * (taxCounty / 100)
                                    taxcontcity = RowContAmt * (taxCity / 100)

                                    parameterEXT_NR_CONT.Value = taxcontstate + taxcontcounty + taxcontcity
                                    SQL.Append(", EXT_NR_CONT = @EXT_NR_CONT")
                                    'LineTotalCont += Math.Round(taxcontstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcity, 2, MidpointRounding.AwayFromZero)
                                End If
                            ElseIf TheFunctionType = "E" Or TheFunctionType = "I" Then
                                If TaxCommOnly <> "1" Then
                                    taxresalestate = ExtAmount * (taxState / 100)
                                    taxresalecounty = ExtAmount * (taxCounty / 100)
                                    taxresalecity = ExtAmount * (taxCity / 100)
                                    'LineTotal += Math.Round(taxresalestate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxresalecounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxresalecity, 2, MidpointRounding.AwayFromZero)
                                End If
                                If RowContAmt <> 0 Then
                                    If TaxComm = "1" And TaxCommOnly = "1" Then
                                        RowContAmt = RowMuContAmt
                                    ElseIf TaxComm = "1" Then
                                        RowContAmt += RowMuContAmt
                                    End If
                                    taxcontstate = RowContAmt * (taxState / 100)
                                    taxcontcounty = RowContAmt * (taxCounty / 100)
                                    taxcontcity = RowContAmt * (taxCity / 100)

                                    parameterEXT_STATE_CONT.Value = taxcontstate
                                    parameterEXT_COUNTY_CONT.Value = taxcontcounty
                                    parameterEXT_CITY_CONT.Value = taxcontcity
                                    'LineTotalCont += Math.Round(taxcontstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcity, 2, MidpointRounding.AwayFromZero)
                                    SQL.Append(", EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                                End If
                            End If
                            If TaxComm = "1" Then
                                If MarkupAmount <> 0 Then
                                    taxmarkupstate = MarkupAmount * (taxState / 100)
                                    taxmarkupcounty = MarkupAmount * (taxCounty / 100)
                                    taxmarkupcity = MarkupAmount * (taxCity / 100)
                                    'LineTotal += Math.Round(taxmarkupstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxmarkupcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxmarkupcity, 2, MidpointRounding.AwayFromZero)
                                End If
                            End If

                            parameterEXT_STATE_RESALE.Value = taxresalestate + taxmarkupstate
                            parameterEXT_COUNTY_RESALE.Value = taxresalecounty + taxmarkupcounty
                            parameterEXT_CITY_RESALE.Value = taxresalecity + taxmarkupcity
                            SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE")
                        End If
                    End If
                Else
                    SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE, EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                    SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                    SQL.Append(", EXT_NR_CONT = @EXT_NR_CONT")
                    SQL.Append(", TAX_STATE_PCT = @TAX_STATE_PCT")
                    SQL.Append(", TAX_COUNTY_PCT = @TAX_COUNTY_PCT")
                    SQL.Append(", TAX_CITY_PCT = @TAX_CITY_PCT")
                    SQL.Append(", TAX_RESALE = @TAX_RESALE")
                    parameterEXT_STATE_RESALE.Value = 0
                    parameterEXT_COUNTY_RESALE.Value = 0
                    parameterEXT_CITY_RESALE.Value = 0
                    parameterEXT_STATE_CONT.Value = 0
                    parameterEXT_COUNTY_CONT.Value = 0
                    parameterEXT_CITY_CONT.Value = 0
                    parameterEXT_NONRESALE_TAX.Value = 0
                    parameterEXT_NR_CONT.Value = 0
                    parameterTAX_STATE_PCT.Value = taxState
                    parameterTAX_COUNTY_PCT.Value = taxCounty
                    parameterTAX_CITY_PCT.Value = taxCity
                    parameterTAX_RESALE.Value = taxResale
                End If
                SQL.Append(", LINE_TOTAL = @LINE_TOTAL")
                parameterLINE_TOTAL.Value = LineTotal + Math.Round(taxresalestate + taxmarkupstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxresalecounty + taxmarkupcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxresalecity + taxmarkupcity, 2, MidpointRounding.AwayFromZero) + Math.Round(taxnonresalestate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxnonresalecounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxnonresalecity, 2, MidpointRounding.AwayFromZero)
                SQL.Append(", LINE_TOTAL_CONT = @LINE_TOTAL_CONT")
                parameterLINE_TOTAL_CONT.Value = LineTotalCont + Math.Round(taxcontstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcity, 2, MidpointRounding.AwayFromZero)
                With SQL
                    .Append(" WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR AND SEQ_NBR = @SEQ_NBR;")
                End With

                Dim MyCmd As New SqlCommand()
                If ctrlChange = "function" Then
                    MyCmd.Parameters.Add(parameterFNC_CODE)
                    MyCmd.Parameters.Add(parameterFNC_TYPE)
                    MyCmd.Parameters.Add(parameterEST_REV_SUP_BY_CDE)
                End If
                If ctrlChange = "suppliedby" Then
                    MyCmd.Parameters.Add(parameterEST_REV_SUP_BY_CDE)
                End If
                MyCmd.Parameters.Add(parameterEST_REV_QUANTITY)
                If (ExtAmountRow.Replace(groupSeparator, "").Replace(decimalSeparator, ".") <> 0) Or ctrlChange = "rate" Then
                    MyCmd.Parameters.Add(parameterEST_REV_RATE)
                End If
                MyCmd.Parameters.Add(parameterEST_REV_EXT_AMT)
                MyCmd.Parameters.Add(parameterEST_REV_COMM_PCT)
                MyCmd.Parameters.Add(parameterEST_REV_CONT_PCT)
                MyCmd.Parameters.Add(parameterEXT_MARKUP_AMT)
                MyCmd.Parameters.Add(parameterEXT_CONTINGENCY)
                MyCmd.Parameters.Add(parameterEXT_MU_CONT)
                MyCmd.Parameters.Add(parameterLINE_TOTAL)
                MyCmd.Parameters.Add(parameterLINE_TOTAL_CONT)
                MyCmd.Parameters.Add(parameterTAX_CODE)
                MyCmd.Parameters.Add(parameterTAX_STATE_PCT)
                MyCmd.Parameters.Add(parameterTAX_COUNTY_PCT)
                MyCmd.Parameters.Add(parameterTAX_CITY_PCT)
                MyCmd.Parameters.Add(parameterTAX_RESALE)
                'If TaxCode <> "" Then
                MyCmd.Parameters.Add(parameterEXT_STATE_RESALE)
                MyCmd.Parameters.Add(parameterEXT_COUNTY_RESALE)
                MyCmd.Parameters.Add(parameterEXT_CITY_RESALE)
                MyCmd.Parameters.Add(parameterEXT_STATE_CONT)
                MyCmd.Parameters.Add(parameterEXT_COUNTY_CONT)
                MyCmd.Parameters.Add(parameterEXT_CITY_CONT)
                MyCmd.Parameters.Add(parameterEXT_NONRESALE_TAX)
                MyCmd.Parameters.Add(parameterEXT_NR_CONT)
                'End If
                If ctrlChange = "emptitle" Then
                    MyCmd.Parameters.Add(parameterEMP_TITLE_ID)
                End If

                Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
                pESTIMATE_NUMBER.Value = EstNumber
                MyCmd.Parameters.Add(pESTIMATE_NUMBER)

                Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
                pEST_COMPONENT_NBR.Value = EstComponentNbr
                MyCmd.Parameters.Add(pEST_COMPONENT_NBR)

                Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
                pEST_QUOTE_NBR.Value = EstQuoteNbr
                MyCmd.Parameters.Add(pEST_QUOTE_NBR)

                Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
                pEST_REV_NBR.Value = EstRevNbr
                MyCmd.Parameters.Add(pEST_REV_NBR)

                Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                pSEQ_NBR.Value = SeqNbr
                MyCmd.Parameters.Add(pSEQ_NBR)

                Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                    Dim MyTrans As SqlTransaction
                    MyConn.Open()
                    MyTrans = MyConn.BeginTransaction
                    Try
                        With MyCmd
                            .CommandText = SQL.ToString()
                            .CommandType = CommandType.Text
                            .Connection = MyConn
                            .Transaction = MyTrans
                            .ExecuteNonQuery()
                            'ReturnMessage = "OK|" & Qty
                        End With
                        MyTrans.Commit()
                    Catch ex As Exception
                        MyTrans.Rollback()
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using

            End If

            'LoGlo.UserCultureSet(cultureStr)

            Return ReturnMessage
        Catch ex As Exception
            ReturnMessage = ex.Message.ToString()
        End Try


    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function SaveEstFnc(ByVal DataKey As String, ByVal Qty As String, ByVal Rate As String, ByVal CPM As String,
                                      ByVal MarkupPct As String, ByVal TaxCode As String,
                                      ByVal ContPct As String, ByVal TaxComm As String, ByVal TaxCommOnly As String,
                                      ByVal TheFunctionType As String, ByVal ExtAmountRow As String, ByVal ExtMarkupAmt As String,
                                      ByVal FunctionCode As String, ByVal SuppliedBy As String, ByVal ctrlChange As String) As String

        LoGlo.UserCultureSet(LoGlo.UserCultureGet())

        Dim ci As New System.Globalization.CultureInfo(LoGlo.UserCultureGet())
        Dim cultureStr As String = LoGlo.UserCultureGet
        'LoGlo.UserCultureSet("en-US")

        Dim groupSeparator As String = ci.NumberFormat.NumberGroupSeparator
        Dim decimalSeparator As String = ci.NumberFormat.NumberDecimalSeparator
        Dim extat As String = ExtAmountRow.Replace(groupSeparator, "").Replace(decimalSeparator, ".")
        Dim ext As Decimal = CDec(ExtAmountRow.Replace(groupSeparator, "").Replace(decimalSeparator, "."))

        Dim ReturnMessage As String = ""
        Try
            Dim EstNumber As Integer = 0
            Dim EstComponentNbr As Integer = 0
            Dim EstQuoteNbr As Integer = 0
            Dim EstRevNbr As Integer = 0
            Dim JobNumber As Integer = 0
            Dim JobComponentNbr As Integer = 0
            Dim SeqNbr As Integer = -1
            Dim SQL As New System.Text.StringBuilder

            Dim ar() As String
            ar = DataKey.Split("|")
            If ar.Length <> 5 Then
                Return "Error:  Could not get datakey"
                Exit Function
            End If
            Try
                EstNumber = ar(0)
            Catch ex As Exception
                EstNumber = 0
            End Try
            Try
                EstComponentNbr = ar(1)
            Catch ex As Exception
                EstComponentNbr = 0
            End Try
            Try
                EstQuoteNbr = ar(2)
            Catch ex As Exception
                EstQuoteNbr = 0
            End Try
            Try
                EstRevNbr = ar(3)
            Catch ex As Exception
                EstRevNbr = 0
            End Try
            Try
                SeqNbr = ar(4)
            Catch ex As Exception
                SeqNbr = -1
            End Try

            If Qty.Trim <> "" And IsNumeric(Qty.Replace(groupSeparator, "")) = False Then
                ReturnMessage = "Invalid Qty"
            End If
            If Rate.Trim <> "" And IsNumeric(Rate.Replace(groupSeparator, "")) = False Then
                ReturnMessage = "Invalid Rate"
            End If
            If MarkupPct.Trim <> "" And IsNumeric(MarkupPct.Replace(groupSeparator, "")) = False Then
                ReturnMessage = "Invalid Markup Percent"
            End If
            If ContPct.Trim <> "" And IsNumeric(ContPct.Replace(groupSeparator, "")) = False Then
                ReturnMessage = "Invalid Contingency Percent"
            End If
            If ExtAmountRow.Trim <> "" And IsNumeric(ExtAmountRow.Replace(groupSeparator, "")) = False Then
                ReturnMessage = "Invalid Extended Amount"
            End If
            If ExtMarkupAmt.Trim <> "" And IsNumeric(ExtMarkupAmt.Replace(groupSeparator, "")) = False Then
                ReturnMessage = "Invalid Markup Amount"
            End If

            If EstNumber > 0 And EstComponentNbr > 0 And EstQuoteNbr > 0 And SeqNbr > -1 And ReturnMessage = "" Then
                Dim IsValid As Boolean = False
                Dim GoodFncCode As String = ""
                Dim dt As New DataTable
                Dim v As New cValidations(HttpContext.Current.Session("ConnString"))
                Dim est As New cEstimating(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                Dim parameterFNC_CODE As SqlParameter = New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 6)
                Dim parameterEST_REV_SUP_BY_CDE As SqlParameter = New SqlParameter("@EST_REV_SUP_BY_CDE", SqlDbType.VarChar, 6)
                Dim parameterEST_REV_QUANTITY As New SqlParameter("@EST_REV_QUANTITY", SqlDbType.Decimal)
                Dim parameterEST_REV_RATE As New SqlParameter("@EST_REV_RATE", SqlDbType.Decimal)
                Dim parameterEST_REV_EXT_AMT As New SqlParameter("@EST_REV_EXT_AMT", SqlDbType.Decimal)
                Dim parameterEST_REV_COMM_PCT As New SqlParameter("@EST_REV_COMM_PCT", SqlDbType.Decimal)
                Dim parameterEXT_MARKUP_AMT As New SqlParameter("@EXT_MARKUP_AMT", SqlDbType.Decimal)
                Dim parameterEST_REV_CONT_PCT As New SqlParameter("@EST_REV_CONT_PCT", SqlDbType.Decimal)
                Dim parameterEXT_CONTINGENCY As New SqlParameter("@EXT_CONTINGENCY", SqlDbType.Decimal)
                Dim parameterEXT_MU_CONT As New SqlParameter("@EXT_MU_CONT", SqlDbType.Decimal)
                Dim parameterLINE_TOTAL As New SqlParameter("@LINE_TOTAL", SqlDbType.Decimal)
                Dim parameterLINE_TOTAL_CONT As New SqlParameter("@LINE_TOTAL_CONT", SqlDbType.Decimal)
                Dim parameterEXT_STATE_RESALE As New SqlParameter("@EXT_STATE_RESALE", SqlDbType.Decimal)
                Dim parameterEXT_COUNTY_RESALE As New SqlParameter("@EXT_COUNTY_RESALE", SqlDbType.Decimal)
                Dim parameterEXT_CITY_RESALE As New SqlParameter("@EXT_CITY_RESALE", SqlDbType.Decimal)
                Dim parameterEXT_STATE_CONT As New SqlParameter("@EXT_STATE_CONT", SqlDbType.Decimal)
                Dim parameterEXT_COUNTY_CONT As New SqlParameter("@EXT_COUNTY_CONT", SqlDbType.Decimal)
                Dim parameterEXT_CITY_CONT As New SqlParameter("@EXT_CITY_CONT", SqlDbType.Decimal)
                Dim parameterEXT_NONRESALE_TAX As New SqlParameter("@EXT_NONRESALE_TAX", SqlDbType.Decimal)
                Dim parameterEXT_NR_CONT As New SqlParameter("@EXT_NR_CONT", SqlDbType.Decimal)
                Dim parameterTAX_CODE As New SqlParameter("@TAX_CODE", SqlDbType.VarChar)

                parameterEST_REV_QUANTITY.Value = 0
                parameterEST_REV_RATE.Value = 0
                parameterEST_REV_EXT_AMT.Value = 0
                parameterEXT_MARKUP_AMT.Value = 0
                parameterEXT_CONTINGENCY.Value = 0
                parameterEXT_MU_CONT.Value = 0
                parameterLINE_TOTAL.Value = 0
                parameterLINE_TOTAL_CONT.Value = 0
                parameterEXT_STATE_RESALE.Value = 0
                parameterEXT_COUNTY_RESALE.Value = 0
                parameterEXT_CITY_RESALE.Value = 0
                parameterEXT_STATE_CONT.Value = 0
                parameterEXT_COUNTY_CONT.Value = 0
                parameterEXT_CITY_CONT.Value = 0
                parameterEXT_NONRESALE_TAX.Value = 0
                parameterEXT_NR_CONT.Value = 0

                Dim taxresalestate As Decimal = 0
                Dim taxresalecity As Decimal = 0
                Dim taxresalecounty As Decimal = 0
                Dim taxnonresalestate As Decimal = 0
                Dim taxnonresalecity As Decimal = 0
                Dim taxnonresalecounty As Decimal = 0
                Dim taxmarkupstate As Decimal = 0
                Dim taxmarkupcity As Decimal = 0
                Dim taxmarkupcounty As Decimal = 0
                Dim taxcontstate As Decimal = 0
                Dim taxcontcity As Decimal = 0
                Dim taxcontcounty As Decimal = 0
                Dim ExtAmount As Decimal = 0
                Dim MarkupAmount As Decimal = 0
                Dim LineTotal As Decimal = 0
                Dim LineTotalCont As Decimal = 0
                Dim RowContAmt As Decimal = 0
                Dim RowMuContAmt As Decimal = 0
                Dim RowRate As Decimal = 0

                SQL.Append("UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET")

                SQL.Append(" FNC_CODE = @FNC_CODE,")
                parameterFNC_CODE.Value = FunctionCode

                SQL.Append(" EST_REV_QUANTITY = @EST_REV_QUANTITY,")
                parameterEST_REV_QUANTITY.Value = Qty.Replace(groupSeparator, "").Replace(decimalSeparator, ".")

                RowRate = CDec(Rate.Replace(groupSeparator, "").Replace(decimalSeparator, "."))

                SQL.Append(" EST_REV_RATE = @EST_REV_RATE,")
                parameterEST_REV_RATE.Value = RowRate

                SQL.Append(" EST_REV_EXT_AMT = @EST_REV_EXT_AMT,")
                If CPM = "1" Then
                    ExtAmount = (CDec(Qty.Replace(groupSeparator, "").Replace(decimalSeparator, ".")) / 1000) * RowRate
                Else
                    ExtAmount = CDec(Qty.Replace(groupSeparator, "").Replace(decimalSeparator, ".")) * RowRate
                End If

                parameterEST_REV_EXT_AMT.Value = ExtAmount

                SQL.Append(" EST_REV_COMM_PCT = @EST_REV_COMM_PCT,")
                parameterEST_REV_COMM_PCT.Value = CDec(MarkupPct.Replace(groupSeparator, "").Replace(decimalSeparator, "."))

                SQL.Append(" EXT_MARKUP_AMT = @EXT_MARKUP_AMT,")

                MarkupAmount = ExtAmount * (CDec(MarkupPct.Replace(groupSeparator, "").Replace(decimalSeparator, ".")) / 100)

                parameterEXT_MARKUP_AMT.Value = MarkupAmount

                If ContPct <> 0 Then
                    RowContAmt = ExtAmount * (CDec(ContPct.Replace(groupSeparator, "").Replace(decimalSeparator, ".")) / 100)
                    RowMuContAmt = (MarkupAmount * (CDec(ContPct.Replace(groupSeparator, "").Replace(decimalSeparator, ".")) / 100))
                    LineTotalCont += RowContAmt + RowMuContAmt
                End If
                LineTotal += ExtAmount + MarkupAmount

                SQL.Append(" EST_REV_CONT_PCT = @EST_REV_CONT_PCT,")
                parameterEST_REV_CONT_PCT.Value = CDec(ContPct.Replace(groupSeparator, "").Replace(decimalSeparator, "."))
                SQL.Append(" EXT_CONTINGENCY = @EXT_CONTINGENCY,")
                parameterEXT_CONTINGENCY.Value = RowContAmt
                SQL.Append(" EXT_MU_CONT = @EXT_MU_CONT,")
                parameterEXT_MU_CONT.Value = RowMuContAmt
                SQL.Append(" TAX_CODE = @TAX_CODE")
                parameterTAX_CODE.Value = TaxCode

                If TaxCode <> "" Then
                    dt = est.GetAddNewTaxData(TaxCode)
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0)("TAX_RESALE") = 1 Then
                            If TaxCommOnly <> "1" Then
                                taxresalestate = ExtAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                taxresalecounty = ExtAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                taxresalecity = ExtAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                LineTotal += Math.Round(taxresalestate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxresalecounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxresalecity, 2, MidpointRounding.AwayFromZero)
                            End If
                            If TaxComm = "1" Then
                                If MarkupAmount > 0 Then
                                    taxmarkupstate = MarkupAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                    taxmarkupcounty = MarkupAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                    taxmarkupcity = MarkupAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                    LineTotal += Math.Round(taxmarkupstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxmarkupcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxmarkupcity, 2, MidpointRounding.AwayFromZero)
                                End If
                            End If

                            parameterEXT_STATE_RESALE.Value = taxresalestate + taxmarkupstate
                            parameterEXT_COUNTY_RESALE.Value = taxresalecounty + taxmarkupcounty
                            parameterEXT_CITY_RESALE.Value = taxresalecity + taxmarkupcity

                            If RowContAmt <> 0 Then
                                If TaxComm = "1" And TaxCommOnly = "1" Then
                                    RowContAmt = RowMuContAmt
                                ElseIf TaxComm = "1" Then
                                    RowContAmt += RowMuContAmt
                                End If
                                taxcontstate = RowContAmt * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                taxcontcounty = RowContAmt * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                taxcontcity = RowContAmt * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)

                                parameterEXT_STATE_CONT.Value = taxcontstate
                                parameterEXT_COUNTY_CONT.Value = taxcontcounty
                                parameterEXT_CITY_CONT.Value = taxcontcity
                                LineTotalCont += Math.Round(taxcontstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcity, 2, MidpointRounding.AwayFromZero)
                            End If
                            SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE, EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                        End If
                        If dt.Rows(0)("TAX_RESALE") <> 1 Then
                            If TheFunctionType = "V" Then
                                If TaxCommOnly <> "1" Then
                                    taxnonresalestate = ExtAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                    taxnonresalecounty = ExtAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                    taxnonresalecity = ExtAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                    Dim trstate As Decimal = ExtAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                    Dim trcounty As Decimal = ExtAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                    Dim trcity As Decimal = ExtAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                    LineTotal += Math.Round(trstate, 2, MidpointRounding.AwayFromZero) + Math.Round(trcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(trcity, 2, MidpointRounding.AwayFromZero)

                                    parameterEXT_NONRESALE_TAX.Value = taxnonresalestate + taxnonresalecounty + taxnonresalecity
                                    SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                                End If
                                If RowContAmt <> 0 Then
                                    If TaxComm = "1" And TaxCommOnly = "1" Then
                                        RowContAmt = RowMuContAmt
                                    ElseIf TaxComm = "1" Then
                                        RowContAmt += RowMuContAmt
                                    End If
                                    taxcontstate = RowContAmt * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                    taxcontcounty = RowContAmt * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                    taxcontcity = RowContAmt * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)

                                    parameterEXT_NR_CONT.Value = taxcontstate + taxcontcounty + taxcontcity
                                    SQL.Append(", EXT_NR_CONT = @EXT_NR_CONT")
                                    LineTotalCont += Math.Round(taxcontstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcity, 2, MidpointRounding.AwayFromZero)
                                End If
                            ElseIf TheFunctionType = "E" Or TheFunctionType = "I" Then
                                If TaxCommOnly <> "1" Then
                                    taxresalestate = ExtAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                    taxresalecounty = ExtAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                    taxresalecity = ExtAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                    LineTotal += Math.Round(taxresalestate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxresalecounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxresalecity, 2, MidpointRounding.AwayFromZero)
                                End If
                                If RowContAmt <> 0 Then
                                    If TaxComm = "1" And TaxCommOnly = "1" Then
                                        RowContAmt = RowMuContAmt
                                    ElseIf TaxComm = "1" Then
                                        RowContAmt += RowMuContAmt
                                    End If
                                    taxcontstate = RowContAmt * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                    taxcontcounty = RowContAmt * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                    taxcontcity = RowContAmt * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)

                                    parameterEXT_STATE_CONT.Value = taxcontstate
                                    parameterEXT_COUNTY_CONT.Value = taxcontcounty
                                    parameterEXT_CITY_CONT.Value = taxcontcity
                                    LineTotalCont += Math.Round(taxcontstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcity, 2, MidpointRounding.AwayFromZero)
                                    SQL.Append(", EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                                End If
                            End If
                            If TaxComm = "1" Then
                                If MarkupAmount <> 0 Then
                                    taxmarkupstate = MarkupAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                    taxmarkupcounty = MarkupAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                    taxmarkupcity = MarkupAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                    LineTotal += Math.Round(taxmarkupstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxmarkupcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxmarkupcity, 2, MidpointRounding.AwayFromZero)
                                End If
                            End If

                            parameterEXT_STATE_RESALE.Value = taxresalestate + taxmarkupstate
                            parameterEXT_COUNTY_RESALE.Value = taxresalecounty + taxmarkupcounty
                            parameterEXT_CITY_RESALE.Value = taxresalecity + taxmarkupcity
                            SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE")
                        End If
                    End If
                End If
                SQL.Append(", LINE_TOTAL = @LINE_TOTAL")
                parameterLINE_TOTAL.Value = LineTotal
                SQL.Append(", LINE_TOTAL_CONT = @LINE_TOTAL_CONT")
                parameterLINE_TOTAL_CONT.Value = LineTotalCont
                With SQL
                    .Append(" WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR AND SEQ_NBR = @SEQ_NBR;")
                End With

                Dim MyCmd As New SqlCommand()

                MyCmd.Parameters.Add(parameterFNC_CODE)
                MyCmd.Parameters.Add(parameterEST_REV_QUANTITY)
                MyCmd.Parameters.Add(parameterEST_REV_RATE)
                MyCmd.Parameters.Add(parameterEST_REV_EXT_AMT)
                MyCmd.Parameters.Add(parameterEST_REV_COMM_PCT)
                MyCmd.Parameters.Add(parameterEST_REV_CONT_PCT)
                MyCmd.Parameters.Add(parameterEXT_MARKUP_AMT)
                MyCmd.Parameters.Add(parameterEXT_CONTINGENCY)
                MyCmd.Parameters.Add(parameterEXT_MU_CONT)
                MyCmd.Parameters.Add(parameterLINE_TOTAL)
                MyCmd.Parameters.Add(parameterLINE_TOTAL_CONT)
                MyCmd.Parameters.Add(parameterTAX_CODE)
                If TaxCode <> "" Then
                    MyCmd.Parameters.Add(parameterEXT_STATE_RESALE)
                    MyCmd.Parameters.Add(parameterEXT_COUNTY_RESALE)
                    MyCmd.Parameters.Add(parameterEXT_CITY_RESALE)
                    MyCmd.Parameters.Add(parameterEXT_STATE_CONT)
                    MyCmd.Parameters.Add(parameterEXT_COUNTY_CONT)
                    MyCmd.Parameters.Add(parameterEXT_CITY_CONT)
                    MyCmd.Parameters.Add(parameterEXT_NONRESALE_TAX)
                    MyCmd.Parameters.Add(parameterEXT_NR_CONT)
                End If

                Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
                pESTIMATE_NUMBER.Value = EstNumber
                MyCmd.Parameters.Add(pESTIMATE_NUMBER)

                Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
                pEST_COMPONENT_NBR.Value = EstComponentNbr
                MyCmd.Parameters.Add(pEST_COMPONENT_NBR)

                Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
                pEST_QUOTE_NBR.Value = EstQuoteNbr
                MyCmd.Parameters.Add(pEST_QUOTE_NBR)

                Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
                pEST_REV_NBR.Value = EstRevNbr
                MyCmd.Parameters.Add(pEST_REV_NBR)

                Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                pSEQ_NBR.Value = SeqNbr
                MyCmd.Parameters.Add(pSEQ_NBR)

                Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                    Dim MyTrans As SqlTransaction
                    MyConn.Open()
                    MyTrans = MyConn.BeginTransaction
                    Try
                        With MyCmd
                            .CommandText = SQL.ToString()
                            .CommandType = CommandType.Text
                            .Connection = MyConn
                            .Transaction = MyTrans
                            .ExecuteNonQuery()
                            'ReturnMessage = "OK|" & Qty
                        End With
                        MyTrans.Commit()
                    Catch ex As Exception
                        MyTrans.Rollback()
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using

            End If

            'LoGlo.UserCultureSet(cultureStr)

            Return ReturnMessage
        Catch ex As Exception
            ReturnMessage = ex.Message.ToString()
        End Try


    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function AutoSaveEstimateHeader(ByVal DataKey As String, ByVal FieldName As String, ByVal ControlValue As String, ByVal ControlClientId As String) As String

        Dim EstNumber As Integer = 0
        Dim EstComponentNbr As Integer = 0
        Dim QuoteNumber As Integer = 0
        Dim RevNumber As Integer = 0
        Dim JobNumber As Integer = 0
        Dim JobCompNumber As Integer = 0
        Dim revision As Integer = 0
        Dim ReturnMessage As String = ""
        Dim IsUpdatingStatusCode As Boolean = False

        Dim Sql As New System.Text.StringBuilder
        Dim ar() As String

        ar = DataKey.Split("|")

        If ar.Length <> 7 Then

            Return "ERROR|Could not get datakey"
            Exit Function

        End If

        Try

            EstNumber = ar(0)

        Catch ex As Exception

            EstNumber = 0

        End Try
        Try

            EstComponentNbr = ar(1)

        Catch ex As Exception

            EstComponentNbr = 0

        End Try
        Try

            QuoteNumber = ar(2)

        Catch ex As Exception

            QuoteNumber = 0

        End Try
        Try

            RevNumber = ar(3)

        Catch ex As Exception

            RevNumber = 0

        End Try
        Try

            JobNumber = ar(4)

        Catch ex As Exception

            JobNumber = 0

        End Try
        Try

            JobCompNumber = ar(5)

        Catch ex As Exception

            JobCompNumber = 0

        End Try
        Try

            revision = ar(6)

        Catch ex As Exception

            revision = 0

        End Try

        ControlValue = ControlValue.Trim()

        Try

            Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            pESTIMATE_NUMBER.Value = EstNumber

            Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
            pEST_COMPONENT_NBR.Value = EstComponentNbr

            Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
            pEST_QUOTE_NBR.Value = QuoteNumber

            Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
            pEST_REV_NBR.Value = RevNumber

            Dim pVALUE As New SqlParameter
            pVALUE.ParameterName = "@VALUE"

            Dim pVALUE2 As New SqlParameter
            pVALUE2.ParameterName = "@VALUE2"

            If ControlValue = "" Or ControlValue = "[None]" Then

                pVALUE.Value = System.DBNull.Value
                pVALUE2.Value = System.DBNull.Value

            Else

                pVALUE.Value = ControlValue.Replace(vbLf, vbCrLf)

            End If

            If FieldName = "EST_QTE_COMMENT" Or FieldName = "EST_QTE_COMMENT_HTML" Or FieldName = "EST_QUOTE_DESC" Then

                Sql.Append("UPDATE [ESTIMATE_QUOTE] WITH(ROWLOCK) SET ")

            Else

                Sql.Append("UPDATE [ESTIMATE_REV] WITH(ROWLOCK) SET ")

            End If

            Sql.Append(FieldName)
            Sql.Append(" = @VALUE")

            If FieldName = "SPEC_VER" Then
                Sql.Append(", SPEC_REV ")
                Sql.Append(" = @VALUE2")
            End If

            Dim v As New cValidations(HttpContext.Current.Session("ConnString"))
            Select Case FieldName
                Case "EST_QTE_COMMENT", "EST_REV_COMMENT", "EST_QTE_COMMENT_HTML", "EST_REV_COMMENT_HTML"

                    pVALUE.SqlDbType = SqlDbType.Text

                Case "SPEC_VER"

                    If ControlValue <> "" Then
                        If IsNumeric(ControlValue) = True Then
                            If v.ValidateJobSpecsVersion(JobNumber, JobCompNumber, ControlValue, revision) = False Then
                                ReturnMessage = "ERROR|Invalid Version."
                            End If
                        Else
                            ReturnMessage = "ERROR|Invalid Version."
                        End If
                    End If

                    With pVALUE

                        .SqlDbType = SqlDbType.Int

                    End With

                    With pVALUE2

                        .SqlDbType = SqlDbType.Int
                        If ControlValue = "" Or ControlValue = "0" Then
                            .Value = System.DBNull.Value
                        Else
                            .Value = revision
                        End If


                    End With

                Case "EST_QUOTE_DESC"

                    With pVALUE

                        .SqlDbType = SqlDbType.VarChar
                        .Size = 60

                    End With

                Case "JOB_QTY"

                    If ControlValue <> "" AndAlso IsNumeric(ControlValue) = False AndAlso ControlValue.Contains(".") = False Then

                        ReturnMessage = "ERROR|Invalid Job Quantity."

                    End If

                    With pVALUE

                        .SqlDbType = SqlDbType.Int
                        If ControlValue = "" Then
                            .Value = System.DBNull.Value
                        End If

                    End With

                Case "BLENDED_TIME_RATE"

                    If ControlValue <> "" AndAlso IsNumeric(ControlValue) = False Then

                        ReturnMessage = "ERROR|Invalid Blended Rate."

                    End If

                    With pVALUE

                        .SqlDbType = SqlDbType.Decimal

                    End With

            End Select

            With Sql
                If FieldName = "EST_QTE_COMMENT" Or FieldName = "EST_QTE_COMMENT_HTML" Or FieldName = "EST_QUOTE_DESC" Then
                    .Append(" WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR;")
                Else
                    .Append(" WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR;")
                End If
            End With

            If ReturnMessage = "" Then

                Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))

                    Dim MyTrans As SqlTransaction
                    MyConn.Open()
                    MyTrans = MyConn.BeginTransaction
                    Dim MyCmd As New SqlCommand()

                    Try

                        With MyCmd

                            .Parameters.Add(pESTIMATE_NUMBER)
                            .Parameters.Add(pEST_COMPONENT_NBR)
                            .Parameters.Add(pEST_QUOTE_NBR)
                            If FieldName <> "EST_QTE_COMMENT" Or FieldName <> "EST_QTE_COMMENT_HTML" Or FieldName <> "EST_QUOTE_DESC" Then
                                .Parameters.Add(pEST_REV_NBR)
                            End If
                            .Parameters.Add(pVALUE)
                            If FieldName = "SPEC_VER" Then
                                .Parameters.Add(pVALUE2)
                            End If
                            .CommandText = Sql.ToString()
                            .CommandType = CommandType.Text
                            .Connection = MyConn
                            .Transaction = MyTrans
                            .ExecuteNonQuery()

                        End With

                        MyTrans.Commit()


                    Catch ex As Exception

                        MyTrans.Rollback()
                        ReturnMessage = "ERROR|" & AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())

                    Finally

                        If MyConn.State = ConnectionState.Open Then MyConn.Close()

                    End Try

                End Using

            End If

        Catch ex As Exception

            ReturnMessage = "ERROR|" & AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())

        End Try

        Return ReturnMessage

    End Function







#End Region


End Class
