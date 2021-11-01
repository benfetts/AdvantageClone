Imports Webvantage.cGlobals.Globals
Public Class MediaCalendar_Filter
    Inherits Webvantage.BaseChildPage

#Region "Variables"
    'Protected header As header
    Protected reporttype As Webvantage.ReportTypeUC
    Dim intClient As Int32
    Protected WithEvents ddOffice As Telerik.Web.UI.RadComboBox
    Protected WithEvents ddProductList As Telerik.Web.UI.RadComboBox
    Protected WithEvents ddDivList As Telerik.Web.UI.RadComboBox
    Protected WithEvents ddClientList As Telerik.Web.UI.RadComboBox
    Protected WithEvents ddMediaTypeList As Telerik.Web.UI.RadComboBox
    Protected WithEvents ddCampaignList As Telerik.Web.UI.RadComboBox
    Protected WithEvents ddVendorList As Telerik.Web.UI.RadComboBox
    Protected WithEvents ddBuyerList As Telerik.Web.UI.RadComboBox
    Protected WithEvents txtClientPO As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkSaveSettings As System.Web.UI.WebControls.CheckBox
    Protected WithEvents rbCDP As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbDueDate As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbTask As System.Web.UI.WebControls.RadioButton
    Protected WithEvents chkSubHeadings As System.Web.UI.WebControls.CheckBox
    Protected WithEvents butSave As System.Web.UI.WebControls.Button
    Protected WithEvents butRestore As System.Web.UI.WebControls.Button
    Protected WithEvents chkClient As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDivision As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkProduct As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkType As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkMediaType As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkInsertionLineNum As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkVendorCode As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkVendorName As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkJobComponent As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkCampaignCode As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkCampaignName As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkMarketCode As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkMarketName As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkAdSizeLength As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkHeadlineProg As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkExtendedMatDate As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkCloseDate As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkExtendedCloseDate As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkRunDate As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkBillingAmount As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkSpots As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkMaterialDueDate As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkExtendedMaterialDueDate As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkExtendedCloseDateMedia As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkCloseDateMedia As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkRunInsertionDate As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDisplayFlight As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkPrint As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents litTabs As System.Web.UI.WebControls.Literal
    Protected WithEvents chkMagazine As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkNewspaper As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkInternet As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkOutOfHome As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkTelevision As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkRadio As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkAcceptedOrders As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkCancelledOrders As System.Web.UI.WebControls.CheckBox
    Protected WithEvents rbMediaTraffic As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMediaSchedule As System.Web.UI.WebControls.RadioButton
    Protected WithEvents RadTabStrip As Telerik.Web.UI.RadTabStrip
    Protected WithEvents MediaTypeList As Telerik.Web.UI.RadComboBox
    Protected WithEvents VendorList As Telerik.Web.UI.RadComboBox
    Protected WithEvents BuyerList As Telerik.Web.UI.RadComboBox
    Protected WithEvents RadPanelbarMediaFilter As Telerik.Web.UI.RadPanelBar
    Protected WithEvents hlOffice As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hlClient As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hlDivision As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hlProduct As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hlCampaign As System.Web.UI.WebControls.HyperLink
    Protected WithEvents txtOffice As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtClient As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDivision As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtProduct As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCampaign As System.Web.UI.WebControls.TextBox
    Protected WithEvents CheckBoxDocuments As System.Web.UI.WebControls.CheckBox
    Dim intDiv As Int32
    Dim intPrd As Int32
#End Region

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.PageTitle = "Media Filter"
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        Dim c As New cDayPilot
        c.LoadMediaTabs(Me.RadTabStrip)
        Me.hlOffice = Me.RadPanelbarMediaFilter.Items(0).Items(0).FindControl("hlOffice")
        Me.hlClient = Me.RadPanelbarMediaFilter.Items(0).Items(0).FindControl("hlClient")
        Me.hlDivision = Me.RadPanelbarMediaFilter.Items(0).Items(0).FindControl("hlDivision")
        Me.hlProduct = Me.RadPanelbarMediaFilter.Items(0).Items(0).FindControl("hlProduct")
        Me.hlCampaign = Me.RadPanelbarMediaFilter.Items(0).Items(0).FindControl("hlCampaign")
        Me.MediaTypeList = Me.RadPanelbarMediaFilter.Items(0).Items(0).FindControl("ddMediaTypeList")
        Me.VendorList = Me.RadPanelbarMediaFilter.Items(0).Items(0).FindControl("ddVendorList")
        Me.BuyerList = Me.RadPanelbarMediaFilter.Items(0).Items(0).FindControl("ddBuyerList")
        Me.txtOffice = Me.RadPanelbarMediaFilter.Items(0).Items(0).FindControl("txtOffice")
        Me.txtClient = Me.RadPanelbarMediaFilter.Items(0).Items(0).FindControl("txtClient")
        Me.txtDivision = Me.RadPanelbarMediaFilter.Items(0).Items(0).FindControl("txtDivision")
        Me.txtProduct = Me.RadPanelbarMediaFilter.Items(0).Items(0).FindControl("txtProduct")
        Me.txtCampaign = Me.RadPanelbarMediaFilter.Items(0).Items(0).FindControl("txtCampaign")
        Me.txtClientPO = Me.RadPanelbarMediaFilter.Items(0).Items(0).FindControl("txtClientPO")
        If Me.IsPostBack = True Then
            'CheckChanged()
        Else
            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Media_MediaCalendar)
            'LoadClientList()
            If otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType") <> "" Then
                If otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType") = "Traffic" Then
                    Me.rbMediaTraffic.Checked = True
                ElseIf otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType") = "Schedule" Then
                    Me.rbMediaSchedule.Checked = True
                End If
            Else
                Me.rbMediaTraffic.Checked = True
            End If
            'If Not Session("MediaCalType") Is Nothing Then
            '    If Session("MediaCalType") = "Traffic" Then
            '        Me.rbMediaTraffic.Checked = True
            '    ElseIf Session("MediaCalType") = "Schedule" Then
            '        Me.rbMediaSchedule.Checked = True
            '    End If
            'Else
            '    Me.rbMediaTraffic.Checked = True
            'End If
            If Me.IsClientPortal = True Then
                Me.hlOffice.Visible = False
                Me.txtOffice.Visible = False
                Me.hlClient.Visible = False
                Me.txtClient.Text = Session("CL_CODE")
                Me.txtClient.Visible = False
                Me.hlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtDivision.ClientID & "&type=divisionjj&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value);return false;")
                Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?cp=1&form=mediafilter&type=product&control=" & Me.txtProduct.ClientID & "&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")
                Me.hlCampaign.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=alertinbox&type=campaignmedcal&control=" & Me.txtCampaign.ClientID & "&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")
            Else
                Me.hlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtDivision.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value);return false;")
                Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=mediafilter&type=product&control=" & Me.txtProduct.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value);return false;")
                Me.hlCampaign.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=alertinbox&type=campaignmedcal&control=" & Me.txtCampaign.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value);return false;")
            End If
            Me.hlOffice.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=mediacal&control=" & Me.txtOffice.ClientID & "&type=office&ddtype=client');return false;")
            Me.hlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtClient.ClientID & "&type=client&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value);return false;")

            'LoadOfficeList()
            LoadMediaTypeList()
            'LoadCampaignList()
            LoadVendorList()
            LoadBuyerList()
            CheckChanged()
            Me.chkBillingAmount.Visible = False
            Me.chkSpots.Visible = False

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
                Me.ShowMessage("err getting tab id from qs")
            End Try

            RadTabStrip.Tabs.Clear()
            Dim newTab As New Telerik.Web.UI.RadTab
            newTab.Text = "Month View"
            newTab.Value = 0
            newTab.NavigateUrl = "MediaCalendar.aspx?tab=0"
            Me.RadTabStrip.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Week View"
            newTab.Value = 1
            newTab.NavigateUrl = "MediaCalendar_Week.aspx?tab=1"
            Me.RadTabStrip.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Day View"
            newTab.Value = 2
            newTab.NavigateUrl = "MediaCalendar_Day.aspx?tab=2"
            Me.RadTabStrip.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Filter"
            newTab.Value = 3
            newTab.NavigateUrl = "mediafilter.aspx?tab=3"
            Me.RadTabStrip.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab

            Dim selectTab As Telerik.Web.UI.RadTab = Me.RadTabStrip.FindTabByValue(tab)
            selectTab.Selected = True

        Catch ex As Exception
            Me.ShowMessage("err loading tabs " & ex.Message.ToString())
        End Try
    End Sub

    Private Sub LoadClientList()
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
        Me.ddClientList.DataSource = oDropDowns.GetClientList(Session("UserCode"))
        Me.ddClientList.DataTextField = "Description"
        Me.ddClientList.DataValueField = "Code"
        Me.ddClientList.DataBind()
        Me.ddClientList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Clients", "%"))
        If Len(intClient) > 0 Then
            Me.ddClientList.Items(intClient).Selected = True
        End If

    End Sub

    Private Sub LoadOfficeList()
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
        Me.ddOffice.DataSource = oDropDowns.GetOffices()
        Me.ddOffice.DataTextField = "Description"
        Me.ddOffice.DataValueField = "Code"
        Me.ddOffice.DataBind()
        Me.ddOffice.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Offices", "%"))
        'If Len(intClient) > 0 Then
        '    Me.ddClientList.Items(intClient).Selected = True
        'End If

    End Sub

    Private Overloads Sub LoadDivList(ByVal strClient As String)
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
        Me.ddDivList.DataSource = oDropDowns.GetDivisionList(Session("UserCode"), strClient)
        Me.ddDivList.DataTextField = "Description"
        Me.ddDivList.DataValueField = "Code"
        Me.ddDivList.DataBind()
        Me.ddDivList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Divisions", "%"))
        If Len(intDiv) > 0 Then
            Me.ddDivList.Items(intDiv).Selected = True
        End If
    End Sub

    Private Overloads Sub LoadDivList()
        Me.ddDivList.Items.Clear()
        Me.ddDivList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Divisions", "%"))
    End Sub

    Private Overloads Sub LoadProdList(ByVal strClient As String, ByVal strDiv As String)
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))

        Me.ddProductList.DataSource = oDropDowns.GetProductList(Session("UserCode"), strClient, strDiv)
        Me.ddProductList.DataTextField = "Description"
        Me.ddProductList.DataValueField = "Code"
        Me.ddProductList.DataBind()
        Me.ddProductList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Products", "%"))
    End Sub

    Private Overloads Sub LoadProdList()
        Me.ddProductList.Items.Clear()
        Me.ddProductList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Products", "%"))
    End Sub

    Private Sub LoadMediaTypeList()
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))

        Me.MediaTypeList.DataSource = oDropDowns.GetMediaTypeList(Session("UserCode"))
        Me.MediaTypeList.DataTextField = "MEDIA_TYPE"
        Me.MediaTypeList.DataValueField = "MEDIA_TYPE"
        Me.MediaTypeList.DataBind()
        Me.MediaTypeList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Media Types", "%"))
        If Len(intClient) > 0 Then
            Me.MediaTypeList.Items(intClient).Selected = True
        End If

    End Sub

    Private Sub LoadCampaignList(Optional ByVal strClientCode As String = "", Optional ByVal strDivisionCode As String = "", Optional ByVal strProductCode As String = "")
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
        Me.ddCampaignList.DataSource = oDropDowns.GetCampaignsMediaCal(Session("UserCode"), strClientCode, strDivisionCode, strProductCode)
        Me.ddCampaignList.DataTextField = "Description"
        Me.ddCampaignList.DataValueField = "Code"
        Me.ddCampaignList.DataBind()
        Me.ddCampaignList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Campaigns", "%"))

    End Sub

    Private Sub LoadVendorList()
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))

        Me.VendorList.DataSource = oDropDowns.GetVendors(Session("UserCode"), Me.chkMagazine.Checked, Me.chkNewspaper.Checked, Me.chkInternet.Checked, Me.chkOutOfHome.Checked, Me.chkTelevision.Checked, Me.chkRadio.Checked)
        Me.VendorList.DataTextField = "Description"
        Me.VendorList.DataValueField = "Code"
        Me.VendorList.DataBind()
        Me.VendorList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Vendors", "%"))
        If Len(intClient) > 0 Then
            Me.VendorList.Items(intClient).Selected = True
        End If

    End Sub

    Private Sub LoadBuyerList()
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))

        Me.BuyerList.DataSource = oDropDowns.GetBuyers(Session("UserCode"))
        Me.BuyerList.DataTextField = "BUYER"
        Me.BuyerList.DataValueField = "BUYER"
        Me.BuyerList.DataBind()
        Me.BuyerList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Buyers", "%"))
        If Len(intClient) > 0 Then
            Me.BuyerList.Items(intClient).Selected = True
        End If

    End Sub


    Private Function SaveSettingsMediaTraffic()
        Try
            Dim count As Integer = checkDisplayOptions()
            Dim count2 As Integer = checkMediaDisplayOptions()
            Dim count3 As Integer = checkIncludeOptions()

            If count = 0 Then
                Me.ShowMessage("Please select at least one Display Option.")
                Return False
                Exit Function
            End If
            If count > 5 Then
                Me.ShowMessage("No more than five Display Options can be selected.")
                Return False
                Exit Function
            End If
            If count2 = 0 Then
                Me.ShowMessage("Please select at least one Display By Option.")
                Return False
                Exit Function
            End If
            If count2 > 1 Then
                Me.ShowMessage("No more than one Media Display By Option can be selected.")
                Return False
                Exit Function
            End If
            If count3 = 0 Then
                Me.ShowMessage("Please select at least one Include Option.")
                Return False
                Exit Function
            End If
            'Filter Options
            'Selection Options

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim oAppVars As New cAppVars(cAppVars.Application.CALENDAR_MEDIA)
            oAppVars.getAllAppVars()

            oAppVars.setAppVar("mtfSClient", Me.txtClient.Text, "")
            oAppVars.setAppVar("mtfSDivision", Me.txtDivision.Text, "")
            oAppVars.setAppVar("mtfSProduct", Me.txtProduct.Text, "")
            If Me.txtClient.Text = "" Then
                oAppVars.setAppVar("mtfSClientText", "", "") 'Session("mtfSClientText") = ""
            Else
                oAppVars.setAppVar("mtfSClientText", getClientName(Me.txtClient.Text), "") 'Session("mtfSClientText") = getClientName(Me.txtClient.Text) 'Me.ddClientList.SelectedItem.Text
            End If
            If Me.txtDivision.Text = "" Then
                oAppVars.setAppVar("mtfSDivisionText", "", "") 'Session("mtfSDivisionText") = ""
            Else
                oAppVars.setAppVar("mtfSDivisionText", getDivisionName(Me.txtClient.Text, Me.txtDivision.Text), "") 'Session("mtfSDivisionText") = getDivisionName(Me.txtClient.Text, Me.txtDivision.Text) 'Me.ddDivList.SelectedItem.Text
            End If
            If Me.txtProduct.Text = "" Then
                oAppVars.setAppVar("mtfSProductText", "", "") 'Session("mtfSProductText") = ""
            Else
                oAppVars.setAppVar("mtfSProductText", getProductName(Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text), "") 'Session("mtfSProductText") = getProductName(Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text) 'Me.ddProductList.SelectedItem.Text
            End If

            oAppVars.setAppVar("mtfSCampaign", Me.txtCampaign.Text, "")
            oAppVars.setAppVar("mtfSMediaType", Me.MediaTypeList.SelectedItem.Value, "")
            oAppVars.setAppVar("mtfSClientPO", Me.txtClientPO.Text.Trim, "")
            oAppVars.setAppVar("mtfSVendor", Me.VendorList.SelectedItem.Value, "")
            oAppVars.setAppVar("mtfSBuyer", Me.BuyerList.SelectedItem.Value, "")
            oAppVars.setAppVar("mtfSOffice", Me.txtOffice.Text, "")

            'Include Criteria
            oAppVars.setAppVar("mtfIMagazine", Me.chkMagazine.Checked, "")
            oAppVars.setAppVar("mtfINewspaper", Me.chkNewspaper.Checked, "")
            oAppVars.setAppVar("mtfIInternet", Me.chkInternet.Checked, "")
            oAppVars.setAppVar("mtfIOutOfHome", Me.chkOutOfHome.Checked, "")
            oAppVars.setAppVar("mtfITelevision", Me.chkTelevision.Checked, "")
            oAppVars.setAppVar("mtfIRadio", Me.chkRadio.Checked, "")
            oAppVars.setAppVar("mtfIAcceptedOrders", Me.chkAcceptedOrders.Checked, "")
            oAppVars.setAppVar("mtfICancelledOrders", Me.chkCancelledOrders.Checked, "")

            'Display Options
            oAppVars.setAppVar("mtfDClient", Me.chkClient.Checked, "")
            oAppVars.setAppVar("mtfDDivision", Me.chkDivision.Checked, "")
            oAppVars.setAppVar("mtfDProduct", Me.chkProduct.Checked, "")
            oAppVars.setAppVar("mtfDType", Me.chkType.Checked, "")
            oAppVars.setAppVar("mtfDMediaType", Me.chkMediaType.Checked, "")
            oAppVars.setAppVar("mtfDInsertionLine", Me.chkInsertionLineNum.Checked, "")
            oAppVars.setAppVar("mtfDVendorCode", Me.chkVendorCode.Checked, "")
            oAppVars.setAppVar("mtfDVendorName", Me.chkVendorName.Checked, "")
            oAppVars.setAppVar("mtfDJobComp", Me.chkJobComponent.Checked, "")
            oAppVars.setAppVar("mtfDCampaignCode", Me.chkCampaignCode.Checked, "")
            oAppVars.setAppVar("mtfDCampaignName", Me.chkCampaignName.Checked, "")
            oAppVars.setAppVar("mtfDMarketCode", Me.chkMarketCode.Checked, "")
            oAppVars.setAppVar("mtfDMarketName", Me.chkMarketName.Checked, "")
            oAppVars.setAppVar("mtfDAdSizeLength", Me.chkAdSizeLength.Checked, "")
            oAppVars.setAppVar("mtfDHeadlineProg", Me.chkHeadlineProg.Checked, "")
            oAppVars.setAppVar("mtfDExtMatDate", Me.chkExtendedMatDate.Checked, "")
            oAppVars.setAppVar("mtfDCloseDate", Me.chkCloseDate.Checked, "")
            oAppVars.setAppVar("mtfDExtCloseDate", Me.chkExtendedCloseDate.Checked, "")
            oAppVars.setAppVar("mtfDRunDate", Me.chkRunDate.Checked, "")
            oAppVars.setAppVar("mtfDBillingAmount", Me.chkBillingAmount.Checked, "")
            oAppVars.setAppVar("mtfDSpots", Me.chkSpots.Checked, "")
            oAppVars.setAppVar("mtfDBMatDueDate", Me.chkMaterialDueDate.Checked, "")
            oAppVars.setAppVar("mtfDBExtMatDueDate", Me.chkExtendedMaterialDueDate.Checked, "")
            oAppVars.setAppVar("mtfDBCloseDate", Me.chkCloseDateMedia.Checked, "")
            oAppVars.setAppVar("mtfDBExtCloseDate", Me.chkExtendedCloseDateMedia.Checked, "")
            oAppVars.setAppVar("mtfDBRunInsertionDate", Me.chkRunInsertionDate.Checked, "")
            oAppVars.setAppVar("mtfDDocuments", Me.CheckBoxDocuments.Checked, "")

            oAppVars.SaveAllAppVars()

            'Session("mtfSClient") = Me.txtClient.Text 'Me.ddClientList.SelectedItem.Value
            'Session("mtfSDivision") = Me.txtDivision.Text 'Me.ddDivList.SelectedItem.Value
            'Session("mtfSProduct") = Me.txtProduct.Text 'Me.ddProductList.SelectedItem.Value
            'If Me.txtClient.Text = "" Then
            '    Session("mtfSClientText") = ""
            'Else
            '    Session("mtfSClientText") = getClientName(Me.txtClient.Text) 'Me.ddClientList.SelectedItem.Text
            'End If
            'If Me.txtDivision.Text = "" Then
            '    Session("mtfSDivisionText") = ""
            'Else
            '    Session("mtfSDivisionText") = getDivisionName(Me.txtClient.Text, Me.txtDivision.Text) 'Me.ddDivList.SelectedItem.Text
            'End If
            'If Me.txtProduct.Text = "" Then
            '    Session("mtfSProductText") = ""
            'Else
            '    Session("mtfSProductText") = getProductName(Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text) 'Me.ddProductList.SelectedItem.Text
            'End If
            'Session("mtfSCampaign") = Me.txtCampaign.Text 'Me.ddCampaignList.SelectedItem.Value
            'Session("mtfSMediaType") = Me.MediaTypeList.SelectedItem.Value 'Me.ddMediaTypeList.SelectedItem.Value
            'Session("mtfSClientPO") = Me.txtClientPO.Text.Trim
            'Session("mtfSVendor") = Me.VendorList.SelectedItem.Value 'Me.ddVendorList.SelectedItem.Value
            'Session("mtfSBuyer") = Me.BuyerList.SelectedItem.Value 'Me.ddBuyerList.SelectedItem.Value
            'Session("mtfSOffice") = Me.txtOffice.Text

            ''Include Criteria
            'Session("mtfIMagazine") = Me.chkMagazine.Checked
            'Session("mtfINewspaper") = Me.chkNewspaper.Checked
            'Session("mtfIInternet") = Me.chkInternet.Checked
            'Session("mtfIOutOfHome") = Me.chkOutOfHome.Checked
            'Session("mtfITelevision") = Me.chkTelevision.Checked
            'Session("mtfIRadio") = Me.chkRadio.Checked
            'Session("mtfIAcceptedOrders") = Me.chkAcceptedOrders.Checked
            'Session("mtfICancelledOrders") = Me.chkCancelledOrders.Checked

            ''Display Options
            'Session("mtfDClient") = Me.chkClient.Checked
            'Session("mtfDDivision") = Me.chkDivision.Checked
            'Session("mtfDProduct") = Me.chkProduct.Checked
            'Session("mtfDType") = Me.chkType.Checked
            'Session("mtfDMediaType") = Me.chkMediaType.Checked
            'Session("mtfDInsertionLine") = Me.chkInsertionLineNum.Checked
            'Session("mtfDVendorCode") = Me.chkVendorCode.Checked
            'Session("mtfDVendorName") = Me.chkVendorName.Checked
            'Session("mtfDJobComp") = Me.chkJobComponent.Checked
            'Session("mtfDCampaignCode") = Me.chkCampaignCode.Checked
            'Session("mtfDCampaignName") = Me.chkCampaignName.Checked
            'Session("mtfDMarketCode") = Me.chkMarketCode.Checked
            'Session("mtfDMarketName") = Me.chkMarketName.Checked
            'Session("mtfDAdSizeLength") = Me.chkAdSizeLength.Checked
            'Session("mtfDHeadlineProg") = Me.chkHeadlineProg.Checked
            'Session("mtfDExtMatDate") = Me.chkExtendedMatDate.Checked
            'Session("mtfDCloseDate") = Me.chkCloseDate.Checked
            'Session("mtfDExtCloseDate") = Me.chkExtendedCloseDate.Checked
            'Session("mtfDRunDate") = Me.chkRunDate.Checked
            'Session("mtfDBillingAmount") = Me.chkBillingAmount.Checked
            'Session("mtfDSpots") = Me.chkSpots.Checked
            'Session("mtfDBMatDueDate") = Me.chkMaterialDueDate.Checked
            'Session("mtfDBExtMatDueDate") = Me.chkExtendedMaterialDueDate.Checked
            'Session("mtfDBCloseDate") = Me.chkCloseDateMedia.Checked
            'Session("mtfDBExtCloseDate") = Me.chkExtendedCloseDateMedia.Checked
            'Session("mtfDBRunInsertionDate") = Me.chkRunInsertionDate.Checked
            Return True

        Catch ex As Exception
            Me.ShowMessage("Error with SaveSettings: " & ex.Message.ToString())
        End Try

    End Function

    Private Function SaveSettingsMediaSchedule()
        Try
            Dim count As Integer = checkDisplayOptions()
            Dim count2 As Integer = checkMediaDisplayOptions()
            Dim count3 As Integer = checkIncludeOptions()

            If count = 0 Then
                Me.ShowMessage("Please select at least one Display Option.")
                Return False
                Exit Function
            End If
            If count > 5 Then
                Me.ShowMessage("No more than five Display Options can be selected.")
                Return False
                Exit Function
            End If
            If count2 = 0 Then
                Me.ShowMessage("Please select at least one Display By Option.")
                Return False
                Exit Function
            End If
            If count2 > 1 Then
                Me.ShowMessage("No more than one Media Display By Option can be selected.")
                Return False
                Exit Function
            End If
            If count3 = 0 Then
                Me.ShowMessage("Please select at least one Include Option.")
                Return False
                Exit Function
            End If
            'Filter Options
            'Selection Options
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim oAppVars As New cAppVars(cAppVars.Application.CALENDAR_MEDIA)
            oAppVars.getAllAppVars()

            oAppVars.setAppVar("msfSClient", Me.txtClient.Text, "")
            oAppVars.setAppVar("msfSDivision", Me.txtDivision.Text, "")
            oAppVars.setAppVar("msfSProduct", Me.txtProduct.Text, "")
            If Me.txtClient.Text = "" Then
                oAppVars.setAppVar("msfSClientText", "", "") 'Session("mtfSClientText") = ""
            Else
                oAppVars.setAppVar("msfSClientText", getClientName(Me.txtClient.Text), "") 'Session("mtfSClientText") = getClientName(Me.txtClient.Text) 'Me.ddClientList.SelectedItem.Text
            End If
            If Me.txtDivision.Text = "" Then
                oAppVars.setAppVar("msfSDivisionText", "", "") 'Session("mtfSDivisionText") = ""
            Else
                oAppVars.setAppVar("msfSDivisionText", getDivisionName(Me.txtClient.Text, Me.txtDivision.Text), "") 'Session("mtfSDivisionText") = getDivisionName(Me.txtClient.Text, Me.txtDivision.Text) 'Me.ddDivList.SelectedItem.Text
            End If
            If Me.txtProduct.Text = "" Then
                oAppVars.setAppVar("msfSProductText", "", "") 'Session("mtfSProductText") = ""
            Else
                oAppVars.setAppVar("msfSProductText", getProductName(Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text), "") 'Session("mtfSProductText") = getProductName(Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text) 'Me.ddProductList.SelectedItem.Text
            End If

            oAppVars.setAppVar("msfSCampaign", Me.txtCampaign.Text, "")
            oAppVars.setAppVar("msfSMediaType", Me.MediaTypeList.SelectedItem.Value, "")
            oAppVars.setAppVar("msfSClientPO", Me.txtClientPO.Text.Trim, "")
            oAppVars.setAppVar("msfSVendor", Me.VendorList.SelectedItem.Value, "")
            oAppVars.setAppVar("msfSBuyer", Me.BuyerList.SelectedItem.Value, "")
            oAppVars.setAppVar("msfSOffice", Me.txtOffice.Text, "")

            'Include Criteria
            oAppVars.setAppVar("msfIMagazine", Me.chkMagazine.Checked, "")
            oAppVars.setAppVar("msfINewspaper", Me.chkNewspaper.Checked, "")
            oAppVars.setAppVar("msfIInternet", Me.chkInternet.Checked, "")
            oAppVars.setAppVar("msfIOutOfHome", Me.chkOutOfHome.Checked, "")
            oAppVars.setAppVar("msfITelevision", Me.chkTelevision.Checked, "")
            oAppVars.setAppVar("msfIRadio", Me.chkRadio.Checked, "")
            oAppVars.setAppVar("msfIAcceptedOrders", Me.chkAcceptedOrders.Checked, "")
            oAppVars.setAppVar("msfICancelledOrders", Me.chkCancelledOrders.Checked, "")

            'Display Options
            oAppVars.setAppVar("msfDClient", Me.chkClient.Checked, "")
            oAppVars.setAppVar("msfDDivision", Me.chkDivision.Checked, "")
            oAppVars.setAppVar("msfDProduct", Me.chkProduct.Checked, "")
            oAppVars.setAppVar("msfDType", Me.chkType.Checked, "")
            oAppVars.setAppVar("msfDMediaType", Me.chkMediaType.Checked, "")
            oAppVars.setAppVar("msfDInsertionLine", Me.chkInsertionLineNum.Checked, "")
            oAppVars.setAppVar("msfDVendorCode", Me.chkVendorCode.Checked, "")
            oAppVars.setAppVar("msfDVendorName", Me.chkVendorName.Checked, "")
            oAppVars.setAppVar("msfDJobComp", Me.chkJobComponent.Checked, "")
            oAppVars.setAppVar("msfDCampaignCode", Me.chkCampaignCode.Checked, "")
            oAppVars.setAppVar("msfDCampaignName", Me.chkCampaignName.Checked, "")
            oAppVars.setAppVar("msfDMarketCode", Me.chkMarketCode.Checked, "")
            oAppVars.setAppVar("msfDMarketName", Me.chkMarketName.Checked, "")
            oAppVars.setAppVar("msfDAdSizeLength", Me.chkAdSizeLength.Checked, "")
            oAppVars.setAppVar("msfDHeadlineProg", Me.chkHeadlineProg.Checked, "")
            oAppVars.setAppVar("msfDExtMatDate", Me.chkExtendedMatDate.Checked, "")
            oAppVars.setAppVar("msfDCloseDate", Me.chkCloseDate.Checked, "")
            oAppVars.setAppVar("msfDExtCloseDate", Me.chkExtendedCloseDate.Checked, "")
            oAppVars.setAppVar("msfDRunDate", Me.chkRunDate.Checked, "")
            oAppVars.setAppVar("msfDBillingAmount", Me.chkBillingAmount.Checked, "")
            oAppVars.setAppVar("msfDSpots", Me.chkSpots.Checked, "")
            oAppVars.setAppVar("msfDBMatDueDate", Me.chkMaterialDueDate.Checked, "")
            oAppVars.setAppVar("msfDBExtMatDueDate", Me.chkExtendedMaterialDueDate.Checked, "")
            oAppVars.setAppVar("msfDBCloseDate", Me.chkCloseDateMedia.Checked, "")
            oAppVars.setAppVar("msfDBExtCloseDate", Me.chkExtendedCloseDateMedia.Checked, "")
            oAppVars.setAppVar("msfDBRunInsertionDate", Me.chkRunInsertionDate.Checked, "")
            oAppVars.setAppVar("msfDBDisplayFlight", Me.chkDisplayFlight.Checked, "")
            oAppVars.setAppVar("msfDDocuments", Me.CheckBoxDocuments.Checked, "")

            oAppVars.SaveAllAppVars()

            'Session("msfSClient") = Me.txtClient.Text 'Me.ddClientList.SelectedItem.Value
            'Session("msfSDivision") = Me.txtDivision.Text 'Me.ddDivList.SelectedItem.Value
            'Session("msfSProduct") = Me.txtProduct.Text 'Me.ddProductList.SelectedItem.Value
            'If Me.txtClient.Text = "" Then
            '    Session("msfSClientText") = ""
            'Else
            '    Session("msfSClientText") = getClientName(Me.txtClient.Text) 'Me.ddClientList.SelectedItem.Text
            'End If
            'If Me.txtDivision.Text = "" Then
            '    Session("msfSDivisionText") = ""
            'Else
            '    Session("msfSDivisionText") = getDivisionName(Me.txtClient.Text, Me.txtDivision.Text) 'Me.ddDivList.SelectedItem.Text
            'End If
            'If Me.txtProduct.Text = "" Then
            '    Session("msfSProductText") = ""
            'Else
            '    Session("msfSProductText") = getProductName(Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text) 'Me.ddProductList.SelectedItem.Text
            'End If
            'Session("msfSCampaign") = Me.txtCampaign.Text 'Me.ddCampaignList.SelectedItem.Value
            'Session("msfSMediaType") = Me.MediaTypeList.SelectedItem.Value 'Me.ddMediaTypeList.SelectedItem.Value
            'Session("msfSClientPO") = Me.txtClientPO.Text.Trim
            'Session("msfSVendor") = Me.VendorList.SelectedItem.Value 'Me.ddVendorList.SelectedItem.Value
            'Session("msfSBuyer") = Me.BuyerList.SelectedItem.Value 'Me.ddBuyerList.SelectedItem.Value
            'Session("msfSOffice") = Me.txtOffice.Text

            ''Include Criteria
            'Session("msfIMagazine") = Me.chkMagazine.Checked
            'Session("msfINewspaper") = Me.chkNewspaper.Checked
            'Session("msfIInternet") = Me.chkInternet.Checked
            'Session("msfIOutOfHome") = Me.chkOutOfHome.Checked
            'Session("msfITelevision") = Me.chkTelevision.Checked
            'Session("msfIRadio") = Me.chkRadio.Checked
            'Session("msfIAcceptedOrders") = Me.chkAcceptedOrders.Checked
            'Session("msfICancelledOrders") = Me.chkCancelledOrders.Checked

            ''Display Options
            'Session("msfDClient") = Me.chkClient.Checked
            'Session("msfDDivision") = Me.chkDivision.Checked
            'Session("msfDProduct") = Me.chkProduct.Checked
            'Session("msfDType") = Me.chkType.Checked
            'Session("msfDMediaType") = Me.chkMediaType.Checked
            'Session("msfDInsertionLine") = Me.chkInsertionLineNum.Checked
            'Session("msfDVendorCode") = Me.chkVendorCode.Checked
            'Session("msfDVendorName") = Me.chkVendorName.Checked
            'Session("msfDJobComp") = Me.chkJobComponent.Checked
            'Session("msfDCampaignCode") = Me.chkCampaignCode.Checked
            'Session("msfDCampaignName") = Me.chkCampaignName.Checked
            'Session("msfDMarketCode") = Me.chkMarketCode.Checked
            'Session("msfDMarketName") = Me.chkMarketName.Checked
            'Session("msfDAdSizeLength") = Me.chkAdSizeLength.Checked
            'Session("msfDHeadlineProg") = Me.chkHeadlineProg.Checked
            'Session("msfDExtMatDate") = Me.chkExtendedMatDate.Checked
            'Session("msfDCloseDate") = Me.chkCloseDate.Checked
            'Session("msfDExtCloseDate") = Me.chkExtendedCloseDate.Checked
            'Session("msfDRunDate") = Me.chkRunDate.Checked
            'Session("msfDBillingAmount") = Me.chkBillingAmount.Checked
            'Session("msfDSpots") = Me.chkSpots.Checked
            'Session("msfDBMatDueDate") = Me.chkMaterialDueDate.Checked
            'Session("msfDBExtMatDueDate") = Me.chkExtendedMaterialDueDate.Checked
            'Session("msfDBCloseDate") = Me.chkCloseDateMedia.Checked
            'Session("msfDBExtCloseDate") = Me.chkExtendedCloseDateMedia.Checked
            'Session("msfDBRunInsertionDate") = Me.chkRunInsertionDate.Checked
            'Session("msfDBDisplayFlight") = Me.chkDisplayFlight.Checked
            Return True
        Catch ex As Exception
            Me.ShowMessage("Error with SaveSettings: " & ex.Message.ToString())
        End Try

    End Function

    Private Sub LoadSettingsMediaTraffic()
        'Selection Options
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        Dim oAppVars As cAppVars
        oAppVars = New cAppVars(cAppVars.Application.CALENDAR_MEDIA, Session("UserCode"))
        oAppVars.getAllAppVars()
        If oAppVars.getAppVar("mtfSOffice") <> "" Then
            Me.txtOffice.Text = oAppVars.getAppVar("mtfSOffice")
        End If
        If oAppVars.getAppVar("mtfSClient") <> "" Then
            Me.txtClient.Text = oAppVars.getAppVar("mtfSClient")
        End If
        If oAppVars.getAppVar("mtfSDivision") <> "" Then
            Me.txtDivision.Text = oAppVars.getAppVar("mtfSDivision")
        End If
        If oAppVars.getAppVar("mtfSProduct") <> "" Then
            Me.txtProduct.Text = oAppVars.getAppVar("mtfSProduct")
        End If
        If oAppVars.getAppVar("mtfSCampaign") <> "" Then
            Me.txtCampaign.Text = oAppVars.getAppVar("mtfSCampaign")
        End If

        If oAppVars.getAppVar("mtfSMediaType") <> "" Then
            Me.MediaTypeList.SelectedValue = oAppVars.getAppVar("mtfSMediaType")
        End If
        If oAppVars.getAppVar("mtfSClientPO") <> "" Then
            Me.txtClientPO.Text = oAppVars.getAppVar("mtfSClientPO")
        End If
        If oAppVars.getAppVar("mtfSVendor") <> "" Then
            Me.VendorList.SelectedValue = oAppVars.getAppVar("mtfSVendor")
        End If
        If oAppVars.getAppVar("mtfIMagazine") <> "" Then
            Me.chkMagazine.Checked = oAppVars.getAppVar("mtfIMagazine")
        End If
        If oAppVars.getAppVar("mtfSBuyer") <> "" Then
            Me.BuyerList.SelectedValue = oAppVars.getAppVar("mtfSBuyer")
        End If

        'Try
        '    Me.txtOffice.Text = Session("mtfSOffice")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.txtClient.Text = Session("mtfSClient")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.txtDivision.Text = Session("mtfSDivision")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.txtProduct.Text = Session("mtfSProduct")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.txtCampaign.Text = Session("mtfSCampaign")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.MediaTypeList.SelectedValue = Session("mtfSMediaType")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.txtClientPO.Text = Session("mtfSClientPO")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.VendorList.SelectedValue = Session("mtfSVendor")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkMagazine.Checked = Session("mtfIMagazine")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.BuyerList.SelectedValue = Session("mtfSBuyer")
        'Catch ex As Exception
        'End Try

        'Include Criteria
        If oAppVars.getAppVar("mtfINewspaper") <> "" Then
            Me.chkNewspaper.Checked = oAppVars.getAppVar("mtfINewspaper")
        End If
        If oAppVars.getAppVar("mtfIInternet") <> "" Then
            Me.chkInternet.Checked = oAppVars.getAppVar("mtfIInternet")
        End If
        If oAppVars.getAppVar("mtfIOutOfHome") <> "" Then
            Me.chkOutOfHome.Checked = oAppVars.getAppVar("mtfIOutOfHome")
        End If
        If oAppVars.getAppVar("mtfITelevision") <> "" Then
            Me.chkTelevision.Checked = oAppVars.getAppVar("mtfITelevision")
        End If
        If oAppVars.getAppVar("mtfIRadio") <> "" Then
            Me.chkRadio.Checked = oAppVars.getAppVar("mtfIRadio")
        End If
        If oAppVars.getAppVar("mtfIAcceptedOrders") <> "" Then
            Me.chkAcceptedOrders.Checked = oAppVars.getAppVar("mtfIAcceptedOrders")
        End If
        If oAppVars.getAppVar("mtfICancelledOrders") <> "" Then
            Me.chkCancelledOrders.Checked = oAppVars.getAppVar("mtfICancelledOrders")
        End If
        'Try
        '    Me.chkNewspaper.Checked = Session("mtfINewspaper")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkInternet.Checked = Session("mtfIInternet")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkOutOfHome.Checked = Session("mtfIOutOfHome")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkTelevision.Checked = Session("mtfITelevision")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkRadio.Checked = Session("mtfIRadio")
        'Catch ex As Exception
        'End Try
        'Try
        '    Me.chkAcceptedOrders.Checked = Session("mtfIAcceptedOrders")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkCancelledOrders.Checked = Session("mtfICancelledOrders")
        'Catch ex As Exception
        'End Try


        'Display Options
        If oAppVars.getAppVar("mtfDClient") <> "" Then
            Me.chkClient.Checked = oAppVars.getAppVar("mtfDClient")
        End If
        If oAppVars.getAppVar("mtfDDivision") <> "" Then
            Me.chkDivision.Checked = oAppVars.getAppVar("mtfDDivision")
        End If
        If oAppVars.getAppVar("mtfDProduct") <> "" Then
            Me.chkProduct.Checked = oAppVars.getAppVar("mtfDProduct")
        End If
        If oAppVars.getAppVar("mtfDType") <> "" Then
            Me.chkType.Checked = oAppVars.getAppVar("mtfDType")
        End If
        If oAppVars.getAppVar("mtfDMediaType") <> "" Then
            Me.chkMediaType.Checked = oAppVars.getAppVar("mtfDMediaType")
        End If
        If oAppVars.getAppVar("mtfDInsertionLine") <> "" Then
            Me.chkInsertionLineNum.Checked = oAppVars.getAppVar("mtfDInsertionLine")
        End If
        If oAppVars.getAppVar("mtfDVendorCode") <> "" Then
            Me.chkVendorCode.Checked = oAppVars.getAppVar("mtfDVendorCode")
        End If
        If oAppVars.getAppVar("mtfDVendorName") <> "" Then
            Me.chkVendorName.Checked = oAppVars.getAppVar("mtfDVendorName")
        End If
        If oAppVars.getAppVar("mtfDJobComp") <> "" Then
            Me.chkJobComponent.Checked = oAppVars.getAppVar("mtfDJobComp")
        End If
        If oAppVars.getAppVar("mtfDCampaignCode") <> "" Then
            Me.chkCampaignCode.Checked = oAppVars.getAppVar("mtfDCampaignCode")
        End If
        If oAppVars.getAppVar("mtfDCampaignName") <> "" Then
            Me.chkCampaignName.Checked = oAppVars.getAppVar("mtfDCampaignName")
        End If
        If oAppVars.getAppVar("mtfDMarketCode") <> "" Then
            Me.chkMarketCode.Checked = oAppVars.getAppVar("mtfDMarketCode")
        End If
        If oAppVars.getAppVar("mtfDMarketName") <> "" Then
            Me.chkMarketName.Checked = oAppVars.getAppVar("mtfDMarketName")
        End If
        If oAppVars.getAppVar("mtfDAdSizeLength") <> "" Then
            Me.chkAdSizeLength.Checked = oAppVars.getAppVar("mtfDAdSizeLength")
        End If
        If oAppVars.getAppVar("mtfDHeadlineProg") <> "" Then
            Me.chkHeadlineProg.Checked = oAppVars.getAppVar("mtfDHeadlineProg")
        End If
        If oAppVars.getAppVar("mtfDExtMatDate") <> "" Then
            Me.chkExtendedMatDate.Checked = oAppVars.getAppVar("mtfDExtMatDate")
        End If
        If oAppVars.getAppVar("mtfDCloseDate") <> "" Then
            Me.chkCloseDate.Checked = oAppVars.getAppVar("mtfDCloseDate")
        End If
        If oAppVars.getAppVar("mtfDExtCloseDate") <> "" Then
            Me.chkExtendedCloseDate.Checked = oAppVars.getAppVar("mtfDExtCloseDate")
        End If
        If oAppVars.getAppVar("mtfDRunDate") <> "" Then
            Me.chkRunDate.Checked = oAppVars.getAppVar("mtfDRunDate")
        End If
        If oAppVars.getAppVar("mtfDBillingAmount") <> "" Then
            Me.chkBillingAmount.Checked = oAppVars.getAppVar("mtfDBillingAmount")
        End If
        If oAppVars.getAppVar("mtfDSpots") <> "" Then
            Me.chkSpots.Checked = oAppVars.getAppVar("mtfDSpots")
        End If
        If oAppVars.getAppVar("mtfDBMatDueDate") <> "" Then
            Me.chkMaterialDueDate.Checked = oAppVars.getAppVar("mtfDBMatDueDate")
        End If
        If oAppVars.getAppVar("mtfDBExtMatDueDate") <> "" Then
            Me.chkExtendedMaterialDueDate.Checked = oAppVars.getAppVar("mtfDBExtMatDueDate")
        End If
        If oAppVars.getAppVar("mtfDBCloseDate") <> "" Then
            Me.chkCloseDateMedia.Checked = oAppVars.getAppVar("mtfDBCloseDate")
        End If
        If oAppVars.getAppVar("mtfDBExtCloseDate") <> "" Then
            Me.chkExtendedCloseDateMedia.Checked = oAppVars.getAppVar("mtfDBExtCloseDate")
        End If
        If oAppVars.getAppVar("mtfDBRunInsertionDate") <> "" Then
            Me.chkRunInsertionDate.Checked = oAppVars.getAppVar("mtfDBRunInsertionDate")
        End If
        If oAppVars.getAppVar("mtfDDocuments") <> "" Then
            Me.CheckBoxDocuments.Checked = oAppVars.getAppVar("mtfDDocuments")
        End If
        'Try
        '    Me.chkClient.Checked = Session("mtfDClient")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkDivision.Checked = Session("mtfDDivision")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkProduct.Checked = Session("mtfDProduct")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkType.Checked = Session("mtfDType")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkMediaType.Checked = Session("mtfDMediaType")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkInsertionLineNum.Checked = Session("mtfDInsertionLine")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkVendorCode.Checked = Session("mtfDVendorCode")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkVendorName.Checked = Session("mtfDVendorName")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkJobComponent.Checked = Session("mtfDJobComp")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkCampaignCode.Checked = Session("mtfDCampaignCode")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkCampaignName.Checked = Session("mtfDCampaignName")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkMarketCode.Checked = Session("mtfDMarketCode")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkMarketName.Checked = Session("mtfDMarketName")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkAdSizeLength.Checked = Session("mtfDAdSizeLength")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkHeadlineProg.Checked = Session("mtfDHeadlineProg")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkExtendedMatDate.Checked = Session("mtfDExtMatDate")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkCloseDate.Checked = Session("mtfDCloseDate")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkExtendedCloseDate.Checked = Session("mtfDExtCloseDate")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkRunDate.Checked = Session("mtfDRunDate")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkBillingAmount.Checked = Session("mtfDBillingAmount")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkSpots.Checked = Session("mtfDSpots")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkMaterialDueDate.Checked = Session("mtfDBMatDueDate")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkExtendedMaterialDueDate.Checked = Session("mtfDBExtMatDueDate")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkCloseDateMedia.Checked = Session("mtfDBCloseDate")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkExtendedCloseDateMedia.Checked = Session("mtfDBExtCloseDate")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkRunInsertionDate.Checked = Session("mtfDBRunInsertionDate")
        'Catch ex As Exception
        'End Try

        'HttpContext.Current.Session("AppVarCollectionMediaFilte") = Nothing


    End Sub

    Private Sub LoadSettingsMediaSchedule()
        'Selection Options

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        Dim oAppVars As cAppVars
        oAppVars = New cAppVars(cAppVars.Application.CALENDAR_MEDIA, Session("UserCode"))
        oAppVars.getAllAppVars()


        If oAppVars.getAppVar("msfSOffice") <> "" Then
            Me.txtOffice.Text = oAppVars.getAppVar("msfSOffice")
        End If
        If oAppVars.getAppVar("msfSClient") <> "" Then
            Me.txtClient.Text = oAppVars.getAppVar("msfSClient")
        End If
        If oAppVars.getAppVar("msfSDivision") <> "" Then
            Me.txtDivision.Text = oAppVars.getAppVar("msfSDivision")
        End If
        If oAppVars.getAppVar("msfSProduct") <> "" Then
            Me.txtProduct.Text = oAppVars.getAppVar("msfSProduct")
        End If
        If oAppVars.getAppVar("msfSCampaign") <> "" Then
            Me.txtCampaign.Text = oAppVars.getAppVar("msfSCampaign")
        End If

        If oAppVars.getAppVar("msfSMediaType") <> "" Then
            Me.MediaTypeList.SelectedValue = oAppVars.getAppVar("msfSMediaType")
        End If
        If oAppVars.getAppVar("msfSClientPO") <> "" Then
            Me.txtClientPO.Text = oAppVars.getAppVar("msfSClientPO")
        End If
        If oAppVars.getAppVar("msfSVendor") <> "" Then
            Me.VendorList.SelectedValue = oAppVars.getAppVar("msfSVendor")
        End If
        If oAppVars.getAppVar("msfIMagazine") <> "" Then
            Me.chkMagazine.Checked = oAppVars.getAppVar("msfIMagazine")
        End If
        If oAppVars.getAppVar("msfSBuyer") <> "" Then
            Me.BuyerList.SelectedValue = oAppVars.getAppVar("msfSBuyer")
        End If
        'Try
        '    Me.txtOffice.Text = Session("msfSOffice")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.txtClient.Text = Session("msfSClient")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.txtDivision.Text = Session("msfSDivision")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.txtProduct.Text = Session("msfSProduct")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.txtCampaign.Text = Session("msfSCampaign")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.MediaTypeList.SelectedValue = Session("msfSMediaType")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.txtClientPO.Text = Session("msfSClientPO")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.VendorList.SelectedValue = Session("msfSVendor")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.BuyerList.SelectedValue = Session("msfSBuyer")
        'Catch ex As Exception
        'End Try

        'Include Criteria
        If oAppVars.getAppVar("msfINewspaper") <> "" Then
            Me.chkNewspaper.Checked = oAppVars.getAppVar("msfINewspaper")
        End If
        If oAppVars.getAppVar("msfIInternet") <> "" Then
            Me.chkInternet.Checked = oAppVars.getAppVar("msfIInternet")
        End If
        If oAppVars.getAppVar("msfIOutOfHome") <> "" Then
            Me.chkOutOfHome.Checked = oAppVars.getAppVar("msfIOutOfHome")
        End If
        If oAppVars.getAppVar("msfITelevision") <> "" Then
            Me.chkTelevision.Checked = oAppVars.getAppVar("msfITelevision")
        End If
        If oAppVars.getAppVar("msfIRadio") <> "" Then
            Me.chkRadio.Checked = oAppVars.getAppVar("msfIRadio")
        End If
        If oAppVars.getAppVar("msfIAcceptedOrders") <> "" Then
            Me.chkAcceptedOrders.Checked = oAppVars.getAppVar("msfIAcceptedOrders")
        End If
        If oAppVars.getAppVar("msfICancelledOrders") <> "" Then
            Me.chkCancelledOrders.Checked = oAppVars.getAppVar("msfICancelledOrders")
        End If
        'Try
        '    Me.chkMagazine.Checked = Session("msfIMagazine")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkNewspaper.Checked = Session("msfINewspaper")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkInternet.Checked = Session("msfIInternet")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkOutOfHome.Checked = Session("msfIOutOfHome")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkTelevision.Checked = Session("msfITelevision")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkRadio.Checked = Session("msfIRadio")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkAcceptedOrders.Checked = Session("msfIAcceptedOrders")
        'Catch ex As Exception
        'End Try

        'Try
        '    Me.chkCancelledOrders.Checked = Session("msfICancelledOrders")
        'Catch ex As Exception
        'End Try


        'Display Options
        If oAppVars.getAppVar("msfDClient") <> "" Then
            Me.chkClient.Checked = oAppVars.getAppVar("msfDClient")
        End If
        If oAppVars.getAppVar("msfDDivision") <> "" Then
            Me.chkDivision.Checked = oAppVars.getAppVar("msfDDivision")
        End If
        If oAppVars.getAppVar("msfDProduct") <> "" Then
            Me.chkProduct.Checked = oAppVars.getAppVar("msfDProduct")
        End If
        If oAppVars.getAppVar("msfDType") <> "" Then
            Me.chkType.Checked = oAppVars.getAppVar("msfDType")
        End If
        If oAppVars.getAppVar("msfDMediaType") <> "" Then
            Me.chkMediaType.Checked = oAppVars.getAppVar("msfDMediaType")
        End If
        If oAppVars.getAppVar("msfDInsertionLine") <> "" Then
            Me.chkInsertionLineNum.Checked = oAppVars.getAppVar("msfDInsertionLine")
        End If
        If oAppVars.getAppVar("msfDVendorCode") <> "" Then
            Me.chkVendorCode.Checked = oAppVars.getAppVar("msfDVendorCode")
        End If
        If oAppVars.getAppVar("msfDVendorName") <> "" Then
            Me.chkVendorName.Checked = oAppVars.getAppVar("msfDVendorName")
        End If
        If oAppVars.getAppVar("msfDJobComp") <> "" Then
            Me.chkJobComponent.Checked = oAppVars.getAppVar("msfDJobComp")
        End If
        If oAppVars.getAppVar("msfDCampaignCode") <> "" Then
            Me.chkCampaignCode.Checked = oAppVars.getAppVar("msfDCampaignCode")
        End If
        If oAppVars.getAppVar("msfDCampaignName") <> "" Then
            Me.chkCampaignName.Checked = oAppVars.getAppVar("msfDCampaignName")
        End If
        If oAppVars.getAppVar("msfDMarketCode") <> "" Then
            Me.chkMarketCode.Checked = oAppVars.getAppVar("msfDMarketCode")
        End If
        If oAppVars.getAppVar("msfDMarketName") <> "" Then
            Me.chkMarketName.Checked = oAppVars.getAppVar("msfDMarketName")
        End If
        If oAppVars.getAppVar("msfDAdSizeLength") <> "" Then
            Me.chkAdSizeLength.Checked = oAppVars.getAppVar("msfDAdSizeLength")
        End If
        If oAppVars.getAppVar("msfDHeadlineProg") <> "" Then
            Me.chkHeadlineProg.Checked = oAppVars.getAppVar("msfDHeadlineProg")
        End If
        If oAppVars.getAppVar("msfDExtMatDate") <> "" Then
            Me.chkExtendedMatDate.Checked = oAppVars.getAppVar("msfDExtMatDate")
        End If
        If oAppVars.getAppVar("msfDCloseDate") <> "" Then
            Me.chkCloseDate.Checked = oAppVars.getAppVar("msfDCloseDate")
        End If
        If oAppVars.getAppVar("msfDExtCloseDate") <> "" Then
            Me.chkExtendedCloseDate.Checked = oAppVars.getAppVar("msfDExtCloseDate")
        End If
        If oAppVars.getAppVar("msfDRunDate") <> "" Then
            Me.chkRunDate.Checked = oAppVars.getAppVar("msfDRunDate")
        End If
        If oAppVars.getAppVar("msfDBillingAmount") <> "" Then
            Me.chkBillingAmount.Checked = oAppVars.getAppVar("msfDBillingAmount")
        End If
        If oAppVars.getAppVar("msfDSpots") <> "" Then
            Me.chkSpots.Checked = oAppVars.getAppVar("msfDSpots")
        End If
        If oAppVars.getAppVar("msfDBMatDueDate") <> "" Then
            Me.chkMaterialDueDate.Checked = oAppVars.getAppVar("msfDBMatDueDate")
        End If
        If oAppVars.getAppVar("msfDBExtMatDueDate") <> "" Then
            Me.chkExtendedMaterialDueDate.Checked = oAppVars.getAppVar("msfDBExtMatDueDate")
        End If
        If oAppVars.getAppVar("msfDBCloseDate") <> "" Then
            Me.chkCloseDateMedia.Checked = oAppVars.getAppVar("msfDBCloseDate")
        End If
        If oAppVars.getAppVar("msfDBExtCloseDate") <> "" Then
            Me.chkExtendedCloseDateMedia.Checked = oAppVars.getAppVar("msfDBExtCloseDate")
        End If
        If oAppVars.getAppVar("msfDBRunInsertionDate") <> "" Then
            Me.chkRunInsertionDate.Checked = oAppVars.getAppVar("msfDBRunInsertionDate")
        End If
        If oAppVars.getAppVar("msfDBDisplayFlight") <> "" Then
            Me.chkDisplayFlight.Checked = oAppVars.getAppVar("msfDBDisplayFlight")
        End If
        If oAppVars.getAppVar("msfDDocuments") <> "" Then
            Me.CheckBoxDocuments.Checked = oAppVars.getAppVar("msfDDocuments")
        End If



    End Sub

    Private Sub rbCDP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCDP.CheckedChanged, rbDueDate.CheckedChanged, rbTask.CheckedChanged, chkSubHeadings.CheckedChanged
        CheckChanged()
    End Sub

    Private Sub butSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
        Dim strURL As String
        Dim save As Boolean
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        Try
            If Me.rbMediaTraffic.Checked = True Then
                If SaveSettingsMediaTraffic() = False Then
                    Exit Sub
                End If
                otask.setAppVars(Session("UserCode"), "MediaFilter", "MediaCalType", "", "Traffic")
                'Session("MediaCalType") = "Traffic"
            Else
                If SaveSettingsMediaSchedule() = False Then
                    Exit Sub
                End If
                otask.setAppVars(Session("UserCode"), "MediaFilter", "MediaCalType", "", "Schedule")
                'Session("MediaCalType") = "Schedule"
            End If
            otask.setAppVars(Session("UserCode"), "MediaFilter", "MediaCalPrint", "", Me.chkPrint.Checked)
            'Session("MediaCalPrint") = Me.chkPrint.Checked
            MiscFN.ResponseRedirect("MediaCalendar.aspx?tab=0")
        Catch ex As Exception
            Me.ShowMessage("Error with Settings: " & ex.Message.ToString())
        End Try

    End Sub

    Private Sub CheckChanged(Optional ByVal restore As Boolean = False)
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        If rbMediaTraffic.Checked = True Then
            If (otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType") = "Traffic" And restore = False) Or (otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfIMagazine") <> "" And restore = False) Then
                LoadSettingsMediaTraffic()
                Me.chkDisplayFlight.Enabled = False
                Me.chkDisplayFlight.Checked = False
            Else
                Me.chkClient.Checked = True
                Me.chkDivision.Checked = False
                Me.chkProduct.Checked = False
                Me.chkType.Checked = True
                Me.chkMediaType.Checked = False
                Me.chkInsertionLineNum.Checked = True
                Me.chkVendorCode.Checked = True
                Me.chkVendorName.Checked = False
                Me.chkJobComponent.Checked = False
                Me.chkCampaignCode.Checked = False
                Me.chkCampaignName.Checked = False
                Me.chkMarketCode.Checked = False
                Me.chkMarketName.Checked = False
                Me.chkAdSizeLength.Checked = False
                Me.chkHeadlineProg.Checked = False
                Me.chkExtendedMatDate.Checked = False
                Me.chkCloseDate.Checked = False
                Me.chkExtendedCloseDate.Checked = False
                Me.chkRunDate.Checked = False
                Me.chkMaterialDueDate.Checked = True
                Me.chkExtendedMaterialDueDate.Checked = False
                Me.chkCloseDateMedia.Checked = False
                Me.chkExtendedCloseDateMedia.Checked = False
                Me.chkRunInsertionDate.Checked = False
                Me.chkDisplayFlight.Enabled = False
                Me.chkDisplayFlight.Checked = False
                Me.chkMagazine.Checked = True
                Me.chkNewspaper.Checked = True
                Me.chkInternet.Checked = True
                Me.chkOutOfHome.Checked = True
                Me.chkTelevision.Checked = True
                Me.chkRadio.Checked = True
                Me.chkAcceptedOrders.Checked = False
                Me.chkCancelledOrders.Checked = True
                Me.CheckBoxDocuments.Checked = False
            End If
            'If Not Session("mtfSClient") Is Nothing Then
            '    If Session("mtfSClient") <> "%" Then
            '        'LoadDivList(Session("mtfSClient"))
            '        'LoadProdList(Session("mtfSClient"), Session("mtfSDivision"))
            '        LoadSettingsMediaTraffic()
            '    Else
            '        LoadSettingsMediaTraffic()
            '    End If
            '    Me.chkDisplayFlight.Enabled = True
            '    Me.chkDisplayFlight.Checked = True
            'Else'
            'End If
        End If
        If rbMediaSchedule.Checked = True Then
            If (otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType") = "Schedule" And restore = False) Or (otask.getAppVars(Session("UserCode"), "MediaFilter", "msfIMagazine") <> "" And restore = False) Then
                LoadSettingsMediaSchedule()
                Me.chkDisplayFlight.Enabled = True
            Else
                Me.chkClient.Checked = False
                Me.chkDivision.Checked = False
                Me.chkProduct.Checked = False
                Me.chkType.Checked = True
                Me.chkMediaType.Checked = False
                Me.chkInsertionLineNum.Checked = False
                Me.chkVendorCode.Checked = False
                Me.chkVendorName.Checked = True
                Me.chkJobComponent.Checked = False
                Me.chkCampaignCode.Checked = False
                Me.chkCampaignName.Checked = False
                Me.chkMarketCode.Checked = False
                Me.chkMarketName.Checked = False
                Me.chkAdSizeLength.Checked = True
                Me.chkHeadlineProg.Checked = True
                Me.chkExtendedMatDate.Checked = False
                Me.chkCloseDate.Checked = False
                Me.chkExtendedCloseDate.Checked = False
                Me.chkRunDate.Checked = False
                Me.chkMaterialDueDate.Checked = False
                Me.chkExtendedMaterialDueDate.Checked = False
                Me.chkCloseDateMedia.Checked = False
                Me.chkExtendedCloseDateMedia.Checked = False
                Me.chkRunInsertionDate.Checked = True
                Me.chkDisplayFlight.Enabled = True
                Me.chkDisplayFlight.Checked = True
                Me.chkMagazine.Checked = True
                Me.chkNewspaper.Checked = True
                Me.chkInternet.Checked = True
                Me.chkOutOfHome.Checked = True
                Me.chkTelevision.Checked = True
                Me.chkRadio.Checked = True
                Me.chkAcceptedOrders.Checked = False
                Me.chkCancelledOrders.Checked = True
                Me.CheckBoxDocuments.Checked = False
            End If
            'If Not Session("msfSClient") Is Nothing Then
            '    If Session("msfSClient") <> "%" Then
            '        'LoadDivList(Session("msfSClient"))
            '        'LoadProdList(Session("msfSClient"), Session("msfSDivision"))
            '        LoadSettingsMediaSchedule()
            '    Else
            '        LoadSettingsMediaSchedule()
            '    End If
            'Else

            '    'LoadClientList()
            '    'LoadDivList()
            '    'LoadProdList()
            'End If        
        End If
        If otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalPrint") <> "" Then
            Me.chkPrint.Checked = otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalPrint")
        Else
            Me.chkPrint.Checked = False
        End If
        'If Not Session("MediaCalPrint") Is Nothing Then
        '    Me.chkPrint.Checked = Session("MediaCalPrint")
        'Else
        '    Me.chkPrint.Checked = False
        'End If
    End Sub

    Private Function checkDisplayOptions()
        Try
            Dim count As Integer = 0
            If Me.chkClient.Checked = True Then
                count += 1
            End If
            If Me.chkDivision.Checked = True Then
                count += 1
            End If
            If Me.chkProduct.Checked = True Then
                count += 1
            End If
            If Me.chkType.Checked = True Then
                count += 1
            End If
            If Me.chkMediaType.Checked = True Then
                count += 1
            End If
            If Me.chkInsertionLineNum.Checked = True Then
                count += 1
            End If
            If Me.chkVendorCode.Checked = True Then
                count += 1
            End If
            If Me.chkVendorName.Checked = True Then
                count += 1
            End If
            If Me.chkJobComponent.Checked = True Then
                count += 1
            End If
            If Me.chkCampaignCode.Checked = True Then
                count += 1
            End If
            If Me.chkCampaignName.Checked = True Then
                count += 1
            End If
            If Me.chkMarketCode.Checked = True Then
                count += 1
            End If
            If Me.chkMarketName.Checked = True Then
                count += 1
            End If
            If Me.chkAdSizeLength.Checked = True Then
                count += 1
            End If
            If Me.chkHeadlineProg.Checked = True Then
                count += 1
            End If
            If Me.chkExtendedMatDate.Checked = True Then
                count += 1
            End If
            If Me.chkCloseDate.Checked = True Then
                count += 1
            End If
            If Me.chkExtendedCloseDate.Checked = True Then
                count += 1
            End If
            If Me.chkRunDate.Checked = True Then
                count += 1
            End If
            If Me.chkBillingAmount.Checked = True Then
                count += 1
            End If
            If Me.chkSpots.Checked = True Then
                count += 1
            End If

            Return count

        Catch ex As Exception
            Me.ShowMessage("Error with checkDisplayOptions: " & ex.Message.ToString())
        End Try
    End Function

    Private Function checkMediaDisplayOptions()
        Try
            Dim count As Integer = 0

            If Me.chkMaterialDueDate.Checked = True Then
                count += 1
            End If
            If Me.chkExtendedMaterialDueDate.Checked = True Then
                count += 1
            End If
            If Me.chkCloseDateMedia.Checked = True Then
                count += 1
            End If
            If Me.chkExtendedCloseDateMedia.Checked = True Then
                count += 1
            End If
            If Me.chkRunInsertionDate.Checked = True Then
                count += 1
            End If

            Return count

        Catch ex As Exception
            Me.ShowMessage("Error with checkMediaDisplayOptions: " & ex.Message.ToString())
        End Try
    End Function

    Private Function checkIncludeOptions()
        Try
            Dim count As Integer = 0

            If Me.chkMagazine.Checked = True Then
                count += 1
            End If
            If Me.chkNewspaper.Checked = True Then
                count += 1
            End If
            If Me.chkInternet.Checked = True Then
                count += 1
            End If
            If Me.chkOutOfHome.Checked = True Then
                count += 1
            End If
            If Me.chkTelevision.Checked = True Then
                count += 1
            End If
            If Me.chkRadio.Checked = True Then
                count += 1
            End If

            Return count

        Catch ex As Exception
            Me.ShowMessage("Error with checkMediaDisplayOptions: " & ex.Message.ToString())
        End Try
    End Function

    'Private Sub ddClientList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddClientList.SelectedIndexChanged
    '    intClient = Me.ddClientList.SelectedIndex
    '    If intClient > 0 Then
    '        LoadDivList(Me.ddClientList.SelectedItem.Value)
    '        LoadProdList()
    '        LoadCampaignList(Me.ddClientList.SelectedItem.Value)
    '    Else
    '        LoadDivList()
    '        LoadProdList()
    '    End If
    'End Sub

    'Private Sub ddDivList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddDivList.SelectedIndexChanged
    '    intDiv = Me.ddDivList.SelectedIndex
    '    If intDiv > 0 Then
    '        LoadProdList(Me.ddClientList.SelectedItem.Value, Me.ddDivList.SelectedItem.Value)
    '        LoadCampaignList(Me.ddClientList.SelectedItem.Value, Me.ddDivList.SelectedItem.Value)
    '    Else
    '        LoadProdList()
    '    End If
    'End Sub

    'Private Sub ddProductList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddProductList.SelectedIndexChanged
    '    intPrd = Me.ddProductList.SelectedIndex
    '    If intPrd > 0 Then
    '        LoadCampaignList(Me.ddClientList.SelectedItem.Value, Me.ddDivList.SelectedItem.Value, Me.ddProductList.SelectedItem.Value)
    '    End If
    'End Sub

    Public Function GetChecked(ByVal blnChecked As Boolean) As String
        If blnChecked = True Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub rbMediaTraffic_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbMediaTraffic.CheckedChanged
        CheckChanged()
    End Sub

    Private Sub rbMediaSchedule_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbMediaSchedule.CheckedChanged
        CheckChanged()
    End Sub

    Private Sub chkMagazine_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkMagazine.CheckedChanged
        LoadVendorList()
    End Sub

    Private Sub chkNewspaper_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNewspaper.CheckedChanged
        LoadVendorList()
    End Sub

    Private Sub chkInternet_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkInternet.CheckedChanged
        LoadVendorList()
    End Sub

    Private Sub chkOutOfHome_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkOutOfHome.CheckedChanged
        LoadVendorList()
    End Sub

    Private Sub chkRadio_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRadio.CheckedChanged
        LoadVendorList()
    End Sub

    Private Sub chkTelevision_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkTelevision.CheckedChanged
        LoadVendorList()
    End Sub

    Private Sub butRestore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butRestore.Click
        Session.Remove("mtfSClient")
        Session.Remove("mtfSDivision")
        Session.Remove("mtfSProduct")
        Session.Remove("mtfSClientText")
        Session.Remove("mtfSDivisionText")
        Session.Remove("mtfSProductText")
        Session.Remove("mtfSCampaign")
        Session.Remove("mtfSMediaType")
        Session.Remove("mtfSClientPO")
        Session.Remove("mtfSVendor")
        Session.Remove("mtfSBuyer")
        Session.Remove("mtfSOffice")

        Session.Remove("mtfIMagazine")
        Session.Remove("mtfINewspaper")
        Session.Remove("mtfIInternet")
        Session.Remove("mtfIOutOfHome")
        Session.Remove("mtfITelevision")
        Session.Remove("mtfIRadio")
        Session.Remove("mtfIAcceptedOrders")
        Session.Remove("mtfICancelledOrders")

        Session.Remove("mtfDClient")
        Session.Remove("mtfDDivision")
        Session.Remove("mtfDProduct")
        Session.Remove("mtfDType")
        Session.Remove("mtfDMediaType")
        Session.Remove("mtfDInsertionLine")
        Session.Remove("mtfDVendorCode")
        Session.Remove("mtfDVendorName")
        Session.Remove("mtfDJobComp")
        Session.Remove("mtfDCampaignCode")
        Session.Remove("mtfDCampaignName")
        Session.Remove("mtfDMarketCode")
        Session.Remove("mtfDMarketName")
        Session.Remove("mtfDAdSizeLength")
        Session.Remove("mtfDHeadlineProg")
        Session.Remove("mtfDExtMatDate")
        Session.Remove("mtfDCloseDate")
        Session.Remove("mtfDExtCloseDate")
        Session.Remove("mtfDRunDate")
        Session.Remove("mtfDBillingAmount")
        Session.Remove("mtfDSpots")
        Session.Remove("mtfDBMatDueDate")
        Session.Remove("mtfDBExtMatDueDate")
        Session.Remove("mtfDBCloseDate")
        Session.Remove("mtfDBExtCloseDate")
        Session.Remove("mtfDBRunInsertionDate")

        Session.Remove("msfSClient")
        Session.Remove("msfSDivision")
        Session.Remove("msfSProduct")
        Session.Remove("msfSClientText")
        Session.Remove("msfSDivisionText")
        Session.Remove("msfSProductText")
        Session.Remove("msfSCampaign")
        Session.Remove("msfSMediaType")
        Session.Remove("msfSClientPO")
        Session.Remove("msfSVendor")
        Session.Remove("msfSBuyer")
        Session.Remove("msfSOffice")

        Session.Remove("msfIMagazine")
        Session.Remove("msfINewspaper")
        Session.Remove("msfIInternet")
        Session.Remove("msfIOutOfHome")
        Session.Remove("msfITelevision")
        Session.Remove("msfIRadio")
        Session.Remove("msfIAcceptedOrders")
        Session.Remove("msfICancelledOrders")

        Session.Remove("msfDClient")
        Session.Remove("msfDDivision")
        Session.Remove("msfDProduct")
        Session.Remove("msfDType")
        Session.Remove("msfDMediaType")
        Session.Remove("msfDInsertionLine")
        Session.Remove("msfDVendorCode")
        Session.Remove("msfDVendorName")
        Session.Remove("msfDJobComp")
        Session.Remove("msfDCampaignCode")
        Session.Remove("msfDCampaignName")
        Session.Remove("msfDMarketCode")
        Session.Remove("msfDMarketName")
        Session.Remove("msfDAdSizeLength")
        Session.Remove("msfDHeadlineProg")
        Session.Remove("msfDExtMatDate")
        Session.Remove("msfDCloseDate")
        Session.Remove("msfDExtCloseDate")
        Session.Remove("msfDRunDate")
        Session.Remove("msfDBillingAmount")
        Session.Remove("msfDSpots")
        Session.Remove("msfDBMatDueDate")
        Session.Remove("msfDBExtMatDueDate")
        Session.Remove("msfDBCloseDate")
        Session.Remove("msfDBExtCloseDate")
        Session.Remove("msfDBRunInsertionDate")
        Session.Remove("msfDBDisplayFlight")

        Session.Remove("MediaCalType")
        Session.Remove("MediaCalPrint")

        Me.rbMediaTraffic.Checked = True
        Me.rbMediaSchedule.Checked = False
        CheckChanged(True)
        'LoadMediaTypeList()
        'LoadCampaignList()
        'LoadVendorList()
        'LoadBuyerList()
        Me.MediaTypeList.SelectedIndex = 0
        Me.VendorList.SelectedIndex = 0
        Me.BuyerList.SelectedIndex = 0
        Me.txtClientPO.Text = ""
        Me.txtClient.Text = ""
        Me.txtDivision.Text = ""
        Me.txtProduct.Text = ""
        Me.txtOffice.Text = ""
        Me.txtCampaign.Text = ""

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        Try
            If SaveSettingsMediaTraffic() = False Then
                Exit Sub
            End If
            otask.setAppVars(Session("UserCode"), "MediaFilter", "MediaCalType", "", "Traffic")
            If SaveSettingsMediaSchedule() = False Then
                Exit Sub
            End If
            otask.setAppVars(Session("UserCode"), "MediaFilter", "MediaCalPrint", "", Me.chkPrint.Checked)

        Catch ex As Exception
            Me.ShowMessage("Error with Settings: " & ex.Message.ToString())
        End Try

    End Sub

    Private Function getClientName(ByVal clientcode As String)
        Dim client As New CLIENT(Session("ConnString"))
        client.LoadByPrimaryKey(clientcode)
        Return client.CL_NAME
    End Function

    Private Function getDivisionName(ByVal clientcode As String, ByVal divisioncode As String)
        Dim division As New DIVISION(Session("ConnString"))
        division.LoadByPrimaryKey(clientcode, divisioncode)
        Return division.DIV_NAME
    End Function

    Private Function getProductName(ByVal clientcode As String, ByVal divisioncode As String, ByVal productcode As String)
        Dim product As New PRODUCT(Session("ConnString"))
        product.LoadByPrimaryKey(clientcode, divisioncode, productcode)
        Return product.PRD_DESCRIPTION
    End Function


End Class
