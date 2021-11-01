Imports Webvantage.wvTimeSheet
Imports Microsoft.VisualBasic

Imports System.Data.SqlClient

Public Class QuoteVsActualFilter
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
    Protected WithEvents litTabs As System.Web.UI.WebControls.Literal
    Protected WithEvents rbIncludeNB As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbBreakoutAllNB As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbBreakoutNBForFT As System.Web.UI.WebControls.RadioButton
    Protected WithEvents cbEmployeeTime As System.Web.UI.WebControls.CheckBox
    Protected WithEvents cbIncomeOnly As System.Web.UI.WebControls.CheckBox
    Protected WithEvents cbVendor As System.Web.UI.WebControls.CheckBox
    Protected WithEvents RadTabStrip As Telerik.Web.UI.RadTabStrip
    Protected WithEvents RadPanelbarQVA As Telerik.Web.UI.RadPanelBar
    Protected WithEvents RadPanelbarQVA1 As Telerik.Web.UI.RadPanelBar
    Protected WithEvents RadToolbarQvA As Global.Telerik.Web.UI.RadToolBar


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents LinkButton1 As System.Web.UI.WebControls.LinkButton

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.PageTitle = "Quote Vs Actual Filter"
        LoadTabs("ChildPage.Master")
        Me.hlClient = Me.RadPanelbarQVA.Items(0).Items(0).FindControl("hlClient")
        Me.hlDivision = Me.RadPanelbarQVA.Items(0).Items(0).FindControl("hlDivision")
        Me.hlProduct = Me.RadPanelbarQVA.Items(0).Items(0).FindControl("hlProduct")
        Me.hlJob = Me.RadPanelbarQVA.Items(0).Items(0).FindControl("hlJob")
        Me.hlJobComp = Me.RadPanelbarQVA.Items(0).Items(0).FindControl("hlJobComp")
        Me.txtClient = Me.RadPanelbarQVA.Items(0).Items(0).FindControl("txtClient")
        Me.txtDivision = Me.RadPanelbarQVA.Items(0).Items(0).FindControl("txtDivision")
        Me.txtProduct = Me.RadPanelbarQVA.Items(0).Items(0).FindControl("txtProduct")
        Me.txtJob = Me.RadPanelbarQVA.Items(0).Items(0).FindControl("txtJob")
        Me.txtJobComp = Me.RadPanelbarQVA.Items(0).Items(0).FindControl("txtJobComp")
        Me.rbIncludeNB = Me.RadPanelbarQVA1.Items(0).Items(0).FindControl("rbIncludeNB")
        Me.rbBreakoutAllNB = Me.RadPanelbarQVA1.Items(0).Items(0).FindControl("rbBreakoutAllNB")
        Me.rbBreakoutNBForFT = Me.RadPanelbarQVA1.Items(0).Items(0).FindControl("rbBreakoutNBForFT")
        Me.cbEmployeeTime = Me.RadPanelbarQVA1.Items(0).Items(0).FindControl("cbEmployeeTime")
        Me.cbIncomeOnly = Me.RadPanelbarQVA1.Items(0).Items(0).FindControl("cbIncomeOnly")
        Me.cbVendor = Me.RadPanelbarQVA1.Items(0).Items(0).FindControl("cbVendor")
        If Page.IsPostBack = True Then

        Else
            Me.hlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobjacket&control=" & Me.txtClient.ClientID & "&type=client&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value);return false;")
            Me.hlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobjacket&control=" & Me.txtDivision.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value);return false;")
            Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobjacket&control=" & Me.txtProduct.ClientID & "&type=product&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value);return false;")
            Me.hlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=qvafilter&type=job&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value, 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=500,height=300,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
            Me.hlJobComp.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=qvafilter&type=jobcompjj&control=" & Me.txtJobComp.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value);return false;")
            LoadSettings()
            Me.rbIncludeNB.Checked = True

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
                Me.ShowError("err getting tab id from qs")
            End Try

            RadTabStrip.Tabs.Clear()
            Dim newTab As New Telerik.Web.UI.RadTab
            newTab.Text = "Summary"
            newTab.Value = 0
            newTab.NavigateUrl = "QuoteVsActualSummary.aspx?tab=0"
            Me.RadTabStrip.Tabs.Add(newTab)
            'newTab = New Telerik.Web.UI.RadTab
            'newTab.Text = "Detail"
            'newTab.Value = 1
            'newTab.NavigateUrl = "QuoteVsActualDetail.aspx?tab=1"
            'Me.RadTabStrip.Tabs.Add(newTab)
            'newTab = New Telerik.Web.UI.RadTab
            'newTab.Text = "Billing"
            'newTab.Value = 2
            'newTab.NavigateUrl = "QuoteVsActualBilling.aspx?tab=2"
            'Me.RadTabStrip.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Filter"
            newTab.Value = 3
            newTab.NavigateUrl = "QuoteVsActualFilter.aspx?tab=3"
            Me.RadTabStrip.Tabs.Add(newTab)

            Dim selectTab As Telerik.Web.UI.RadTab = Me.RadTabStrip.FindTabByValue(tab)
            selectTab.Selected = True

        Catch ex As Exception
            Me.ShowError("err loading tabs " & ex.Message.ToString())
        End Try
    End Sub

    Private Sub LoadSettings()
        Me.txtClient.Text = Session("QvAFilterClient")
        Me.txtDivision.Text = Session("QvAFilterDivision")
        Me.txtProduct.Text = Session("QvAFilterProduct")
        Me.txtJob.Text = Session("QvAFilterJob")
        Me.txtJobComp.Text = Session("QvAFilterJobComp")
        Me.rbIncludeNB.Checked = Session("QvaFilterIncludeNB")
        Me.rbBreakoutAllNB.Checked = Session("QvaFilterBreakoutAllNB")
        Me.rbBreakoutNBForFT.Checked = Session("QvaFilterBreakoutNBForFT")
        Me.cbEmployeeTime.Checked = Session("QvaFilterEmployeeTime")
        Me.cbIncomeOnly.Checked = Session("QvaFilterIncomeOnly")
        Me.cbVendor.Checked = Session("QvaFilterVendor")
    End Sub

    Private Sub rbBreakoutAllNB_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbBreakoutAllNB.CheckedChanged
        If Me.rbBreakoutAllNB.Checked = True Then
            Me.cbEmployeeTime.Checked = False
            Me.cbIncomeOnly.Checked = False
            Me.cbVendor.Checked = False
        End If
    End Sub

    Private Sub rbBreakoutNBForFT_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbBreakoutNBForFT.CheckedChanged
        If Me.rbBreakoutAllNB.Checked = True Then
            Me.cbEmployeeTime.Enabled = True
            Me.cbIncomeOnly.Enabled = True
            Me.cbVendor.Enabled = True
        End If
    End Sub

    Private Sub rbIncludeNB_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbIncludeNB.CheckedChanged
        If Me.rbIncludeNB.Checked = True Then
            Me.cbEmployeeTime.Checked = False
            Me.cbIncomeOnly.Checked = False
            Me.cbVendor.Checked = False
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
                Session("QvAFilterClient") = Me.txtClient.Text
                Session("QvAFilterDivision") = Me.txtDivision.Text
                Session("QvAFilterProduct") = Me.txtProduct.Text
                Session("QvAFilterJob") = Me.txtJob.Text
                Session("QvAFilterJobComp") = Me.txtJobComp.Text
                Session("QvaFilterIncludeNB") = Me.rbIncludeNB.Checked
                Session("QvaFilterBreakoutAllNB") = Me.rbBreakoutAllNB.Checked
                Session("QvaFilterBreakoutNBForFT") = Me.rbBreakoutNBForFT.Checked
                Session("QvaFilterEmployeeTime") = Me.cbEmployeeTime.Checked
                Session("QvaFilterIncomeOnly") = Me.cbIncomeOnly.Checked
                Session("QvaFilterVendor") = Me.cbVendor.Checked
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
