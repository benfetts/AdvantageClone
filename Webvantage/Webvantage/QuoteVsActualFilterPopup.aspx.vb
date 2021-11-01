Imports Webvantage.wvTimeSheet
Imports Microsoft.VisualBasic

Imports System.Data.SqlClient

Public Class QuoteVsActualFilterPopup
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


    Protected WithEvents hlClient As System.Web.UI.WebControls.HyperLink
    Protected WithEvents txtClient As System.Web.UI.WebControls.TextBox
    Protected WithEvents hlDivision As System.Web.UI.WebControls.HyperLink
    Protected WithEvents txtDivision As System.Web.UI.WebControls.TextBox
    Protected WithEvents hlProduct As System.Web.UI.WebControls.HyperLink
    Protected WithEvents txtProduct As System.Web.UI.WebControls.TextBox
    Protected WithEvents hlJob As System.Web.UI.WebControls.HyperLink
    Protected WithEvents txtJob As System.Web.UI.WebControls.TextBox
    Protected WithEvents hlJobComp As System.Web.UI.WebControls.HyperLink
    Protected WithEvents txtJobComp As System.Web.UI.WebControls.TextBox
    Protected WithEvents rbIncludeNB As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbBreakoutAllNB As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbBreakoutNBForFT As System.Web.UI.WebControls.RadioButton
    Protected WithEvents cbEmployeeTime As System.Web.UI.WebControls.CheckBox
    Protected WithEvents cbIncomeOnly As System.Web.UI.WebControls.CheckBox
    Protected WithEvents cbVendor As System.Web.UI.WebControls.CheckBox
    Protected WithEvents hlOffice As System.Web.UI.WebControls.HyperLink
    Protected WithEvents txtOffice As System.Web.UI.WebControls.TextBox
    Protected WithEvents hlSalesClass As System.Web.UI.WebControls.HyperLink
    Protected WithEvents txtSalesClass As System.Web.UI.WebControls.TextBox
    Protected WithEvents hlCampaign As System.Web.UI.WebControls.HyperLink
    Protected WithEvents txtCampaign As System.Web.UI.WebControls.TextBox
    Protected WithEvents hlAE As System.Web.UI.WebControls.HyperLink
    Protected WithEvents txtAE As System.Web.UI.WebControls.TextBox
    Protected WithEvents hlManager As System.Web.UI.WebControls.HyperLink
    Protected WithEvents txtManager As System.Web.UI.WebControls.TextBox
    Protected WithEvents cbClosedJobs As System.Web.UI.WebControls.CheckBox
    Protected WithEvents hfCampaignID As System.Web.UI.WebControls.HiddenField

    Private JobNum As Integer = 0
    Private JobCompNum As Integer = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.hlClient = Me.FilterPanelFilter.Items(0).Items(0).FindControl("hlClient")
            Me.hlDivision = Me.FilterPanelFilter.Items(0).Items(0).FindControl("hlDivision")
            Me.hlProduct = Me.FilterPanelFilter.Items(0).Items(0).FindControl("hlProduct")
            Me.hlJob = Me.FilterPanelFilter.Items(0).Items(0).FindControl("hlJob")
            Me.hlJobComp = Me.FilterPanelFilter.Items(0).Items(0).FindControl("hlJobComp")
            Me.txtClient = Me.FilterPanelFilter.Items(0).Items(0).FindControl("txtClient")
            Me.txtDivision = Me.FilterPanelFilter.Items(0).Items(0).FindControl("txtDivision")
            Me.txtProduct = Me.FilterPanelFilter.Items(0).Items(0).FindControl("txtProduct")
            Me.txtJob = Me.FilterPanelFilter.Items(0).Items(0).FindControl("txtJob")
            Me.txtJobComp = Me.FilterPanelFilter.Items(0).Items(0).FindControl("txtJobComp")
            Me.rbIncludeNB = Me.FilterPanelBreakout.Items(0).Items(0).FindControl("rbIncludeNB")
            Me.rbBreakoutAllNB = Me.FilterPanelBreakout.Items(0).Items(0).FindControl("rbBreakoutAllNB")
            Me.rbBreakoutNBForFT = Me.FilterPanelBreakout.Items(0).Items(0).FindControl("rbBreakoutNBForFT")
            Me.cbEmployeeTime = Me.FilterPanelBreakout.Items(0).Items(0).FindControl("cbEmployeeTime")
            Me.cbIncomeOnly = Me.FilterPanelBreakout.Items(0).Items(0).FindControl("cbIncomeOnly")
            Me.cbVendor = Me.FilterPanelBreakout.Items(0).Items(0).FindControl("cbVendor")
            Me.hlOffice = Me.FilterPanelFilter.Items(0).Items(0).FindControl("hlOffice")
            Me.hlSalesClass = Me.FilterPanelFilter.Items(0).Items(0).FindControl("hlSalesClass")
            Me.hlCampaign = Me.FilterPanelFilter.Items(0).Items(0).FindControl("hlCampaign")
            Me.hlAE = Me.FilterPanelFilter.Items(0).Items(0).FindControl("hlAE")
            Me.hlManager = Me.FilterPanelFilter.Items(0).Items(0).FindControl("hlManager")
            Me.txtOffice = Me.FilterPanelFilter.Items(0).Items(0).FindControl("txtOffice")
            Me.txtSalesClass = Me.FilterPanelFilter.Items(0).Items(0).FindControl("txtSalesClass")
            Me.txtCampaign = Me.FilterPanelFilter.Items(0).Items(0).FindControl("txtCampaign")
            Me.txtAE = Me.FilterPanelFilter.Items(0).Items(0).FindControl("txtAE")
            Me.txtManager = Me.FilterPanelFilter.Items(0).Items(0).FindControl("txtManager")
            Me.cbClosedJobs = Me.FilterPanelFilter.Items(0).Items(0).FindControl("cbClosedJobs")
            Me.hfCampaignID = Me.FilterPanelFilter.Items(0).Items(0).FindControl("hfCampaignID")
            LoadTabs("ChildPage.Master")
            If Page.IsPostBack = True Then

            Else
                Me.hlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobjacket&control=" & Me.txtClient.ClientID & "&type=client&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value);return false;")
                Me.hlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobj&control=" & Me.txtDivision.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value);return false;")
                Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobjacket&control=" & Me.txtProduct.ClientID & "&type=product&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value);return false;")
                'Me.hlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=qvafilter&type=job&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value, 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=500,height=300,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
                'Me.hlJobComp.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=qvafilter&type=jobcompjj&control=" & Me.txtJobComp.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value);return false;")

                If Me.cbClosedJobs.Checked = True Then
                    Me.hlJob.Attributes.Add("onclick", "ClearTB('" & Me.txtJobComp.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=qvafilter&type=job&checked=1&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.txtSalesClass.ClientID & ".value);return false;")
                    Me.hlJobComp.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=qvafilter&type=jobcompjj&checked=1&control=" & Me.txtJobComp.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.txtSalesClass.ClientID & ".value);return false;")
                Else
                    Me.hlJob.Attributes.Add("onclick", "ClearTB('" & Me.txtJobComp.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=qvafilter&type=job&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.txtSalesClass.ClientID & ".value);return false;")
                    Me.hlJobComp.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=qvafilter&type=jobcompjj&control=" & Me.txtJobComp.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.txtSalesClass.ClientID & ".value);return false;")
                End If
                Me.hlOffice.Attributes.Add("onclick", "ClearTB('" & Me.txtClient.ClientID & "');ClearTB('" & Me.txtDivision.ClientID & "');ClearTB('" & Me.txtProduct.ClientID & "');ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtJobComp.ClientID & "');ClearTB('" & Me.txtSalesClass.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobjacketnew&control=" & Me.txtOffice.ClientID & "&type=office&ddtype=client');return false;")
                Me.hlAE.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtAE.ClientID & "&type=accountexec&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=&jobcomp=');return false;")
                Me.hlSalesClass.Attributes.Add("onclick", "ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtJobComp.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtSalesClass.ClientID & "&type=salesclass');return false;")
                'Me.hlCampaign.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtCampaign.ClientID & "&type=campaignfilterjob&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=&jobcomp=');return false;")
                Me.hlCampaign.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?calledfrom=custom&form=calcmpsearch&type=campaign&control=" & Me.txtCampaign.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value + '&cmpID=' + document.forms[0]." & Me.hfCampaignID.ClientID & ".value);return false;")
                Me.hlManager.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtManager.ClientID & "&type=managers');return false;")

                Me.txtOffice.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.txtClient.ClientID & "');ClearTB('" & Me.txtDivision.ClientID & "');ClearTB('" & Me.txtProduct.ClientID & "');ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtJobComp.ClientID & "');ClearTB('" & Me.txtSalesClass.ClientID & "');")
                Me.txtClient.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.txtDivision.ClientID & "');ClearTB('" & Me.txtProduct.ClientID & "');ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtJobComp.ClientID & "');ClearTB('" & Me.txtSalesClass.ClientID & "');")
                Me.txtDivision.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.txtProduct.ClientID & "');ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtJobComp.ClientID & "');ClearTB('" & Me.txtSalesClass.ClientID & "');")
                Me.txtProduct.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtJobComp.ClientID & "');ClearTB('" & Me.txtSalesClass.ClientID & "');")
                Me.txtJob.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.txtJobComp.ClientID & "');")
                Me.txtSalesClass.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtJobComp.ClientID & "');")

                LoadSettings()
                Me.rbIncludeNB.Checked = True

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadTabs(Optional ByVal strTheme As String = "ThreePointOhOatmeal.Master")
        Try

            Dim tab As Integer = 0
            Dim ThisDate As Date
            'If Not Request.QueryString("ThisDate") Is Nothing Then
            '    ThisDate = CDate(Request.QueryString("ThisDate"))
            'Else
            '    ThisDate = Date.Now.Date
            'End If

            Try
                If IsNumeric(Request.QueryString("Tab")) = True Then
                    tab = CInt(Request.QueryString("Tab"))
                Else
                    tab = 0
                End If
            Catch ex As Exception
                tab = 3
            End Try

            FilterTabs.Tabs.Clear()
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
            If IsNumeric(Me.txtJob.Text) = True Then
                JobNum = CType(Me.txtJob.Text, Integer)
            End If
            If IsNumeric(Me.txtJobComp.Text) = True Then
                JobCompNum = CType(Me.txtJobComp.Text, Integer)
            End If
            Dim PassIt As String = ""
            If JobNum > 0 And JobCompNum > 0 Then
                PassIt = "&JobNo=" & JobNum.ToString() & "&JobComp=" & JobCompNum.ToString()
            End If
            Dim newTab As New Telerik.Web.UI.RadTab
            newTab.Text = "Summary"
            newTab.Value = 0
            newTab.NavigateUrl = "QuoteVsActualSummaryPopup.aspx?tab=0" & PassIt
            Me.FilterTabs.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Detail"
            newTab.Value = 1
            newTab.NavigateUrl = "QuoteVsActualDetail.aspx?tab=1" & PassIt
            Me.FilterTabs.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Billing"
            newTab.Value = 2
            newTab.NavigateUrl = "QuoteVsActualBilling.aspx?tab=2" & PassIt
            Me.FilterTabs.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Filter"
            newTab.Value = 3
            newTab.NavigateUrl = "QuoteVsActualFilterPopup.aspx?tab=3" & PassIt
            Me.FilterTabs.Tabs.Add(newTab)

            Dim selectTab As Telerik.Web.UI.RadTab = Me.FilterTabs.FindTabByValue(tab)
            selectTab.Selected = True

        Catch ex As Exception
            Me.ShowError("err loading tabs " & ex.Message.ToString())
        End Try
    End Sub

    Private Sub LoadSettings()
        Dim ojobs As New Job_Specs(Session("ConnString"))
        Dim dr As SqlDataReader
        Dim oAppVars As New cAppVars("QvAPopup")
        oAppVars.getAllAppVars()

        ''Me.txtClient.Text = Session("QvAFilterClient")
        ''Me.txtDivision.Text = Session("QvAFilterDivision")
        ''Me.txtProduct.Text = Session("QvAFilterProduct")
        'Me.txtJob.Text = Session("QvAFilterJob")
        'Me.txtJobComp.Text = Session("QvAFilterJobComp")
        'Me.rbIncludeNB.Checked = Session("QvaFilterIncludeNB")
        'Me.rbBreakoutAllNB.Checked = Session("QvaFilterBreakoutAllNB")
        'Me.rbBreakoutNBForFT.Checked = Session("QvaFilterBreakoutNBForFT")
        'Me.cbEmployeeTime.Checked = Session("QvaFilterEmployeeTime")
        'Me.cbIncomeOnly.Checked = Session("QvaFilterIncomeOnly")
        'Me.cbVendor.Checked = Session("QvaFilterVendor")

        'Me.txtJob.Text = oAppVars.getAppVarDB("QvAFilterJob")
        'Me.txtJobComp.Text = oAppVars.getAppVarDB("QvAFilterJobComp")
        Me.txtJob.Text = Request.QueryString("JobNo")
        Me.txtJobComp.Text = Request.QueryString("JobComp")
        Me.rbIncludeNB.Checked = CType(oAppVars.getAppVar("QvaFilterIncludeNB", "Boolean"), Boolean)
        Me.rbBreakoutAllNB.Checked = CType(oAppVars.getAppVar("QvaFilterBreakoutAllNB", "Boolean"), Boolean)
        Me.rbBreakoutNBForFT.Checked = CType(oAppVars.getAppVar("QvaFilterBreakoutNBForFT", "Boolean"), Boolean)
        Me.cbEmployeeTime.Checked = CType(oAppVars.getAppVar("QvaFilterEmployeeTime", "Boolean"), Boolean)
        Me.cbIncomeOnly.Checked = CType(oAppVars.getAppVar("QvaFilterIncomeOnly", "Boolean"), Boolean)
        Me.cbVendor.Checked = CType(oAppVars.getAppVar("QvaFilterVendor", "Boolean"), Boolean)



        If Me.txtClient.Text = "" Then
            If Me.txtJob.Text <> "" Then
                dr = ojobs.GetJobSpecCDP(CInt(Me.txtJob.Text))
                If dr.HasRows = True Then
                    Do While dr.Read
                        Me.txtClient.Text = dr.GetString(1)
                        Me.txtDivision.Text = dr.GetString(3)
                        Me.txtProduct.Text = dr.GetString(5)
                    Loop
                End If
            End If
        End If
    End Sub

    Private Sub rbBreakoutAllNB_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbBreakoutAllNB.CheckedChanged
        If Me.rbBreakoutAllNB.Checked = True Then
            Me.cbEmployeeTime.Checked = False
            Me.cbIncomeOnly.Checked = False
            Me.cbVendor.Checked = False
        End If
    End Sub

    Private Sub rbBreakoutNBForFT_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbBreakoutNBForFT.CheckedChanged
        If Me.rbBreakoutNBForFT.Checked = True Then
            Me.cbEmployeeTime.Checked = True
            Me.cbIncomeOnly.Checked = True
            Me.cbVendor.Checked = True
        End If
    End Sub

    Private Sub rbIncludeNB_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbIncludeNB.CheckedChanged
        If Me.rbIncludeNB.Checked = True Then
            Me.cbEmployeeTime.Checked = False
            Me.cbIncomeOnly.Checked = False
            Me.cbVendor.Checked = False
        End If
    End Sub

    Private Sub cbEmployeeTime_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEmployeeTime.CheckedChanged
        If Me.cbEmployeeTime.Checked = True Or Me.cbIncomeOnly.Checked = True Or Me.cbVendor.Checked = True Then
            Me.rbIncludeNB.Checked = False
            Me.rbBreakoutAllNB.Checked = False
            Me.rbBreakoutNBForFT.Checked = True
        ElseIf Me.cbEmployeeTime.Checked = False And Me.cbIncomeOnly.Checked = False And Me.cbVendor.Checked = False Then
            Me.rbIncludeNB.Checked = True
            Me.rbBreakoutAllNB.Checked = False
            Me.rbBreakoutNBForFT.Checked = False
        End If
    End Sub

    Private Sub cbIncomeOnly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbIncomeOnly.CheckedChanged
        If Me.cbEmployeeTime.Checked = True Or Me.cbIncomeOnly.Checked = True Or Me.cbVendor.Checked = True Then
            Me.rbIncludeNB.Checked = False
            Me.rbBreakoutAllNB.Checked = False
            Me.rbBreakoutNBForFT.Checked = True
        ElseIf Me.cbEmployeeTime.Checked = False And Me.cbIncomeOnly.Checked = False And Me.cbVendor.Checked = False Then
            Me.rbIncludeNB.Checked = True
            Me.rbBreakoutAllNB.Checked = False
            Me.rbBreakoutNBForFT.Checked = False
        End If
    End Sub

    Private Sub cbVendor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVendor.CheckedChanged
        If Me.cbEmployeeTime.Checked = True Or Me.cbIncomeOnly.Checked = True Or Me.cbVendor.Checked = True Then
            Me.rbIncludeNB.Checked = False
            Me.rbBreakoutAllNB.Checked = False
            Me.rbBreakoutNBForFT.Checked = True
        ElseIf Me.cbEmployeeTime.Checked = False And Me.cbIncomeOnly.Checked = False And Me.cbVendor.Checked = False Then
            Me.rbIncludeNB.Checked = True
            Me.rbBreakoutAllNB.Checked = False
            Me.rbBreakoutNBForFT.Checked = False
        End If
    End Sub

    Private Sub RadToolbarQvA_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarQvA.ButtonClick
        Select Case e.Item.Value
            Case "Save"
                If Me.txtJob.Text = "" Or Me.txtJobComp.Text = "" Then
                    ShowError("Job Number and Component are needed")
                    Exit Sub
                End If
                If IsNumeric(Me.txtJob.Text) = False Or IsNumeric(Me.txtJobComp.Text) = False Then
                    ShowError("Job Number and Component must be valid numbers!")
                    Exit Sub
                End If

                Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
                If myVal.ValidateJobNumber(Me.txtJob.Text) = False Then
                    ShowError("This job does not exist!")
                    Exit Sub
                End If
                If myVal.ValidateJobCompNumber(Me.txtJob.Text, Me.txtJobComp.Text) = False Then
                    ShowError("This is not a valid job/component!")
                    Exit Sub
                End If
                If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.txtClient.Text.Trim, "", "") = False Then
                    ShowError("Access to this client is denied.")
                    Exit Sub
                End If
                If Me.txtDivision.Text <> "" Then
                    If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, "") = False Then
                        ShowError("Access to this division is denied.")
                        Exit Sub
                    End If
                End If
                If Me.txtProduct.Text <> "" Then
                    If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim) = False Then
                        ShowError("Access to this product is denied.")
                        Exit Sub
                    End If
                End If
                If myVal.ValidateJobCompIsViewable(Session("UserCode"), Me.txtJob.Text.Trim, Me.txtJobComp.Text.Trim) = False Then
                    ShowError("Access to this job/comp is denied.")
                    Exit Sub
                End If

                Dim oAppVars As New cAppVars("QvAPopup")
                oAppVars.setAppVarDB("QvAFilterClient", Me.txtClient.Text)
                oAppVars.setAppVarDB("QvAFilterDivision", Me.txtDivision.Text)
                oAppVars.setAppVarDB("QvAFilterProduct", Me.txtProduct.Text)
                oAppVars.setAppVarDB("QvAFilterJob", Me.txtJob.Text)
                oAppVars.setAppVarDB("QvAFilterJobComp", Me.txtJobComp.Text)

                oAppVars.setAppVarDB("QvaFilterIncludeNB", CStr(Me.rbIncludeNB.Checked), "Boolean")
                oAppVars.setAppVarDB("QvaFilterBreakoutAllNB", CStr(Me.rbBreakoutAllNB.Checked), "Boolean")
                oAppVars.setAppVarDB("QvaFilterBreakoutNBForFT", CStr(Me.rbBreakoutNBForFT.Checked), "Boolean")
                oAppVars.setAppVarDB("QvaFilterEmployeeTime", CStr(Me.cbEmployeeTime.Checked), "Boolean")
                oAppVars.setAppVarDB("QvaFilterIncomeOnly", CStr(Me.cbIncomeOnly.Checked), "Boolean")
                oAppVars.setAppVarDB("QvaFilterVendor", CStr(Me.cbVendor.Checked), "Boolean")

            Case "Clear"
                Me.txtClient.Text = ""
                Me.txtDivision.Text = ""
                Me.txtProduct.Text = ""
                Me.txtJob.Text = ""
                Me.txtJobComp.Text = ""
                Me.rbIncludeNB.Checked = False
                Me.rbBreakoutAllNB.Checked = False
                Me.rbBreakoutNBForFT.Checked = False
                Me.cbEmployeeTime.Checked = False
                Me.cbIncomeOnly.Checked = False
                Me.cbVendor.Checked = False

        End Select
    End Sub
End Class