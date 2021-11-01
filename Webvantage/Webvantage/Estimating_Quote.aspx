<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Estimating_Quote.aspx.vb" ValidateRequest="false"
    Inherits="Webvantage.Estimating_Quote" MasterPageFile="~/ChildPage.Master" Title="" %>
<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>

<asp:Content ID="ContentQuote" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <script type="text/javascript" src="Scripts/ej/ej.web.all.min.js"></script>
    <script type="text/javascript" src="Jscripts/EstimatingQuote.js"></script>
    <style type="text/css">
        .w400 { 
            width:400px !important;
            min-width:400px !important;
            max-width:400px !important;
        }
        .RadGrid_Metro .rgFooter > td{
            font-size: 14px !important;
        }
        .RadGrid_Bootstrap .rgFooter > td{
            font-size: 16px !important;
        }
    </style>
    <telerik:RadCodeBlock ID="RadCodeBlockEstimatingQuoteMain" runat="server">
        <script type="text/javascript">
            function RefreshPage() {
                setTimeout(function () {
                    __doPostBack('onclick#Refresh', 'Refresh');
                }, 0);

            };
            function stopRKey(evt) {
                var evt = (evt) ? evt : ((event) ? event : null);
                var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
                if ((evt.keyCode == 13) && (node.type != "textarea")) { return false; }
            }
            document.onkeypress = stopRKey;

            function RadToolbarEstimatingQuoteOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == 'Save') {
                    var a = checkvalue('<%= Me.hfApproved.ClientID  %>');
                    var b = checkvalue('<%= Me.hfInternalApproved.ClientID  %>');
                    if (a == '1') {
                        radToolBarConfirm(sender, args, "This quote is approved. Are you sure you want to save the changes?");
                        ////////args.set_cancel(!confirm('This quote is approved. Are you sure you want to save the changes?'));
                        //return confirmSave();
                    }
                    else if (b == '1') {
                        radToolBarConfirm(sender, args, "This quote is approved. Are you sure you want to save the changes?");
                        ////////args.set_cancel(!confirm('This quote is approved. Are you sure you want to save the changes?'));
                        //return confirmSave();
                    }
                    else {
                        //realPostBack("Save", "Save");
                        return false;
                    }
                }
                if (comandName == "DelRev") {
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                    ////////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    //confirmDelete();
                }
                if (comandName == "EventGenerator") {
                    var a = checkvalue('<%= Me.hfApproved.ClientID  %>');
                    var b = checkvalue('<%= Me.hfInternalApproved.ClientID  %>');
                    if (a == '1') {
                        radToolBarConfirm(sender, args, "This quote is approved. Are you sure you want to create an event?");
                        ////////args.set_cancel(!confirm('This quote is approved. Are you sure you want to create an event?'));
                        //return confirmSaveEG();
                    }
                    else if (b == '1') {
                        radToolBarConfirm(sender, args, "This quote is approved. Are you sure you want to create an event?");
                        ////////args.set_cancel(!confirm('This quote is approved. Are you sure you want to create an event?'));
                        //return confirmSaveEG();
                    }
                    else {
                        //realPostBack("EventGenerator", "EventGenerator");
                        return false;
                    }
                }
                if (comandName == "ClientApprove") {
                    var a = checkvalue('<%= Me.hfApproved.ClientID  %>');
                    if (a == '1') {
                        radToolBarConfirm(sender, args, "Are you sure you want to delete this Client Approval?");
                        //////args.set_cancel(!confirm('Are you sure you want to delete this Client Approval?'));
                        //return confirmDeleteCApproval();
                    }
                    else {
                        //realPostBack("ClientApprove", "ClientApprove");
                        return false;
                    }
                }
                if (comandName == "InternalApprove") {
                    //////args.set_cancel(!confirm('Are you sure you want to clear all assignments?'));
                    var b = checkvalue('<%= Me.hfInternalApproved.ClientID  %>');
                    if (b == '1') {
                        radToolBarConfirm(sender, args, "Are you sure you want to delete this Internal Approval?");
                        //////args.set_cancel(!confirm('Are you sure you want to delete this Internal Approval?'));
                        //return confirmDeleteIApproval();
                    }
                    else {
                        //realPostBack("InternalApprove", "InternalApprove");
                        return false;
                    }
                }
                if (comandName == "WvPermaLink") {
                    <%=Me.WebvantageLink%>
                    args.set_cancel(true);
                }
                if (comandName == "CpPermaLink") {
                    <%=Me.WebvantageLink%>
                    args.set_cancel(true);
                }
            }
            function CloseOnReload() {
                GetRadWindow().close();
            }
            function radGridOnGridCreated(sender, args) {
                var cols = sender.get_masterTableView().get_columns();
                $(cols).each(function () {
                    if (this.get_uniqueName() === 'GridTemplateColumn_JobDescription' || this.get_uniqueName() === 'GridTemplateColumn_JobCompDescription') {
                        this.set_resizable(true);
                        this.resizeToFit(false, true);
                    }
                    this.set_resizable(false);
                });
                $('.RadGrid input[adv-calc]').each(function () {
                    var radInput = $find($(this).attr('id'));
                    if (radInput) {
                        radInput.add_valueChanged(function (sender, args) {
                            var element = sender.get_element();
                            var changed = $(element).attr('adv-calc');
                            getCurrentScope(element).quantityRateAmountChanged(changed);
                        });
                    }
                });
            }

            function SelectAllRows(checked) {
                var radgrid = $find('<%= RadGridEstimateQuoteDetails.ClientID %>');
                   var masterTableView = radgrid.get_masterTableView()
                   var detailTables = radgrid.get_detailTables();
                   var allTables = new Array();

                   allTables = allTables.concat(detailTables);
                   allTables.splice(0, 0, masterTableView);

                   for (var t = 0; t < allTables.length; t++) {
                       if (checked == true) {
                           allTables[t].selectAllItems();
                       } else {
                           allTables[t].clearSelectedItems();
                       }
                   }
                   var HiddenFieldSelectAll = document.getElementById('<%= HiddenFieldSelectAll.ClientID%>');
                if (checked == true) {
                    HiddenFieldSelectAll.value = '1';
                } else {
                    HiddenFieldSelectAll.value = '0';
                }
            }
        </script>
        <!-- Sum Scripts -->
        <script type="text/javascript">
            function SumItUpQuantityHours() {
                var x = 0;
                var y = 0;
                var s = 0;
                var temp = '';
                var JavascriptArrayQuantityHours = new Array();
                <%= JavascriptArrayQuantityHours%>
                for (x = 0; x < JavascriptArrayQuantityHours.length; x++) {
                    temp = Number.parseLocale(JavascriptArrayQuantityHours[x]);
                    if (isNaN(temp) == false) {
                        s = temp;
                    }
                    else {
                        s = 0;
                    }
                    y = y + (s * 1);
                }
                var z = 0;
                z = (y * 1);
                document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl03_ctl00_TxtSumEST_REV_QUANTITY').value = String.localeFormat("{0:n}", z);
                SumItUpExtendedAmount();
                SumItUpFunctionTotal();
                SumItUpContingencyAmount();
                SumItUpTotalwithContingencyAmount();
            }
            function OnRateChange() {
                SumItUpExtendedAmount();
                SumItUpFunctionTotal();
                SumItUpContingencyAmount();
                SumItUpTotalwithContingencyAmount();
            }
            function OnMarkupPercentChange() {
                SumItUpMarkupAmount();
                SumItUpFunctionTotal();
                SumItUpContingencyAmount();
                SumItUpTotalwithContingencyAmount();
            }
            function SumItUpExtendedAmount() {
                var x = 0;
                var y = 0;
                var s = 0;
                var temp = '';
                var JavascriptArrayExtendedAmount = new Array();
                <%= JavascriptArrayExtendedAmount%>
                for (x = 0; x < JavascriptArrayExtendedAmount.length; x++) {
                    temp = Number.parseLocale(JavascriptArrayExtendedAmount[x]);
                    if (isNaN(temp) == false) {
                        s = temp;
                    }
                    else {
                        s = 0;
                    }
                    y = y + (s * 1);
                }
                var z = 0;
                z = (y * 1);
                document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl03_ctl00_TxtSumEST_REV_EXT_AMT').value = String.localeFormat("{0:n}", z);
                SumItUpMarkupAmount()
                SumItUpFunctionTotal();
                SumItUpContingencyAmount();
                SumItUpTotalwithContingencyAmount();
            }
            function SumItUpMarkupAmount() {
                var x = 0;
                var y = 0;
                var s = 0;
                var temp = '';
                var JavascriptArrayMarkupAmount = new Array();
                <%= JavascriptArrayMarkupAmount%>
                for (x = 0; x < JavascriptArrayMarkupAmount.length; x++) {
                    temp = Number.parseLocale(JavascriptArrayMarkupAmount[x]);
                    if (isNaN(temp) == false) {
                        s = temp;
                    }
                    else {
                        s = 0;
                    }
                    y = y + (s * 1);
                }
                var z = 0;
                z = (y * 1);
                document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl03_ctl00_TxtSumEXT_MARKUP_AMT').value = String.localeFormat("{0:n}", z);
                SumItUpFunctionTotal();
                SumItUpTotalwithContingencyAmount();
            }
            function SumItUpFunctionTotal() {
                var x = 0;
                var y = 0;
                var s = 0;
                var temp = '';
                var JavascriptArrayFunctionTotal = new Array();
                <%= JavascriptArrayFunctionTotal%>
                for (x = 0; x < JavascriptArrayFunctionTotal.length; x++) {
                    temp = Number.parseLocale(JavascriptArrayFunctionTotal[x]);
                    if (isNaN(temp) == false) {
                        s = temp;
                    }
                    else {
                        s = 0;
                    }
                    y = y + (s * 1);
                }
                var z = 0;
                z = (y * 1);
                document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl03_ctl00_TxtSumLINE_TOTAL').value = String.localeFormat("{0:n}", z);
            }
            function SumItUpGrossIncome() {
                var x = 0;
                var y = 0;
                var s = 0;
                var temp = '';
                var JavascriptArrayGrossIncome = new Array();
                <%= JavascriptArrayGrossIncome%>
                for (x = 0; x < JavascriptArrayGrossIncome.length; x++) {
                    temp = Number.parseLocale(JavascriptArrayGrossIncome[x]);
                    if (isNaN(temp) == false) {
                        s = temp;
                    }
                    else {
                        s = 0;
                    }
                    y = y + (s * 1);
                }
                var z = 0;
                z = (y * 1);
                document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl03_ctl00_TxtSumGrossIncome').value = String.localeFormat("{0:n}", z);
            }
            function SumItUpContingencyAmount() {
                var x = 0;
                var y = 0;
                var s = 0;
                var temp = '';
                var JavascriptArrayContingencyAmount = new Array();
                <%= JavascriptArrayContingencyAmount%>
                for (x = 0; x < JavascriptArrayContingencyAmount.length; x++) {
                    temp = Number.parseLocale(JavascriptArrayContingencyAmount[x]);
                    if (isNaN(temp) == false) {
                        s = temp;
                    }
                    else {
                        s = 0;
                    }
                    y = y + (s * 1);
                }
                var z = 0;
                z = (y * 1);
                document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl03_ctl00_TxtSumEXT_CONTINGENCY').value = String.localeFormat("{0:n}", z);
            }
            function SumItUpTotalwithContingencyAmount() {
                var x = 0;
                var y = 0;
                var s = 0;
                var temp = '';
                var JavascriptArrayTotalWithContingencyAmount = new Array();
                <%= JavascriptArrayTotalWithContingencyAmount%>
                for (x = 0; x < JavascriptArrayTotalWithContingencyAmount.length; x++) {
                    temp = Number.parseLocale(JavascriptArrayTotalWithContingencyAmount[x]);
                    if (isNaN(temp) == false) {
                        s = temp;
                    }
                    else {
                        s = 0;
                    }
                    y = y + (s * 1);
                }
                var z = 0;
                z = (y * 1);
                document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl03_ctl00_TxtSumQUOTE_W_CONTINGENCY').value = String.localeFormat("{0:n}", z);
            }

        </script>

    </telerik:RadCodeBlock>

    <link rel="stylesheet" href="Content/kendo/current/kendo.common.min.css" />
    <link rel="stylesheet" href="Content/kendo/current/kendo.bootstrap.min.css" />

    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="Scripts/angular.min.js"></script>
    <script type="text/javascript" src="Scripts/angular-ui/ui-bootstrap-tpls.min.js"></script>
    <script type="text/javascript" src="Scripts/kendo/current/kendo.all.min.js"></script>
    <script type="text/javascript" src="app/js/app.js"></script>
    <script type="text/javascript" src="app/js/services.js"></script>
    <script type="text/javascript" src="app/js/controllers/estimateLookup.js"></script>
    <script type="text/javascript" src="app/js/controllers/kendoGridLookupModal.js"></script>

<div ng-app="webvantageApp" ng-controller="estimateController">
    <div class="no-float-menu">

        <telerik:RadToolBar ID="RadToolbarEstimatingQuote" runat="server" AutoPostBack="True"
            OnClientButtonClicking="RadToolbarEstimatingQuoteOnClientButtonClicking">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="New Quote" Value="NewQuote"
                    ToolTip="Add New Quote" />
                <telerik:RadToolBarButton Text="New Revision" Value="NewRev"
                    ToolTip="New Revision" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Delete Revision" Value="DelRev"
                    ToolTip="Delete Revision" CommandName="DelRev" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonSettings" Text="Settings" Value="ColumnSettings"
                    ToolTip="Set column preferences" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonAlerts" Value="Alerts" ToolTip="Alerts" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarDropDown Text="Print/Send">
                    <Buttons>
                        <telerik:RadToolBarButton Text="Print" Value="Print" ToolTip="Print" />
                        <telerik:RadToolBarButton Text="Send Alert" Value="SendAlert" ToolTip="Send Alert" />
                        <telerik:RadToolBarButton Text="Send Assignment" Value="SendAssignment" ToolTip="Send Assignment" />
                        <telerik:RadToolBarButton Text="Send Email" Value="SendEmail" ToolTip="Send Email" />
                        <telerik:RadToolBarButton Text="Options" Value="PrintSendOptions" ToolTip="Print/Send Options" />
                    </Buttons>
                </telerik:RadToolBarDropDown>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Client Approval" Value="ClientApprove"
                    ToolTip="Approve" CommandName="ClientApprove" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Internal Approval" Value="InternalApprove"
                    ToolTip="Internal Approve" CommandName="InternalApprove" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Event Generator" Value="EventGenerator" Visible="false"
                    ToolTip="Event Generator" CommandName="EventGenerator" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh"
                    ToolTip="Refresh" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark" ToolTip="Bookmark" />
                <telerik:RadToolBarSplitButton DropDownWidth="125">
                    <Buttons>
                        <telerik:RadToolBarButton Text="WV Link" Value="WvPermaLink" CommandName="WvPermaLink" ToolTip="Create Webvantage link for use in other systems" Visible="True" />
                        <telerik:RadToolBarButton Text="CP Link" Value="CpPermaLink" CommandName="CpPermaLink" ToolTip="Create Client Portal link for use in other systems" Visible="True" />
                    </Buttons>
                </telerik:RadToolBarSplitButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton>
                    <ItemTemplate>
                        &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Summary View:"></asp:Label>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton ID="RadToolbarButtonFunction" runat="server" Text="Function" CommandName="Function" ToolTip="Function Description" Value="Function" Group="Function"
                    AllowSelfUnCheck="true" CheckOnClick="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonType" Text="Type" CommandName="Type" ToolTip="Function Type" Value="Type" Group="Function"
                    AllowSelfUnCheck="true" CheckOnClick="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonHeading" Text="Heading" CommandName="Heading" ToolTip="Function Heading" Value="Heading" Group="Function"
                    AllowSelfUnCheck="true" CheckOnClick="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonConsolidation" Text="Consolidation" CommandName="Consolidation" ToolTip="Function Consolidation" Value="Consolidation" Group="Function"
                    AllowSelfUnCheck="true" CheckOnClick="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    
    <div class="telerik-aqua-body">
         <ew:CollapsablePanel ID="CollapsablePanelHeader" runat="server"
        TitleText="Quote Information">
        <div align="right">
            <asp:Label ID="lblMSG" runat="server" Text=""></asp:Label>
            <asp:LinkButton ID="hlApproved" runat="server" ForeColor="red" TabIndex="-1" Text="CLIENT APPROVED"
                Font-Underline="True" ></asp:LinkButton>&nbsp;&nbsp;
            <asp:HiddenField ID="hfApproved" runat="server" />
            <br />
            <asp:LinkButton ID="hlApprovedInternal" runat="server" ForeColor="Blue" TabIndex="-1"
                Text="INTERNALLY APPROVED" Font-Underline="True" ></asp:LinkButton>&nbsp;&nbsp;
            <asp:HiddenField ID="hfInternalApproved" runat="server" />
        </div>
        <div style="display: inline-block;">
            <div class="code-description-container">
                <div class="code-description-label">
                    Estimate:
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtEstimate" runat="server" TabIndex="3" Text="" SkinID="TextBoxCodeSmall" ReadOnly="true"></asp:TextBox>
                    <asp:HiddenField ID="HiddenFieldCreateDate" runat="server"/>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtEstimateDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                <asp:HiddenField ID="hfClientCode" runat="server" />
                                <asp:HiddenField ID="hfDivisionCode" runat="server" />
                                <asp:HiddenField ID="hfProductCode" runat="server" />
                                <asp:HiddenField ID="hfSalesClass" runat="server" />
                                <asp:HiddenField ID="hfCampaignID" runat="server" />
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Component:
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtEstimateComponent" runat="server" TabIndex="4" Text="" SkinID="TextBoxCodeSmall"
                                        ReadOnly="true"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtEstimateComponentDescription" runat="server" ReadOnly="true"
                                    TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:LinkButton ID="LbQuote" runat="server">Quote:</asp:LinkButton>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtQuoteNum" runat="server" TabIndex="5" Text="" SkinID="TextBoxCodeSmall" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtQuoteDescription" runat="server" TabIndex="6" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Revision:
                </div>
                 <div class="code-description-code">
                    <telerik:RadComboBox ID="ddRevision" runat="server" AutoPostBack="true" TabIndex="7" SkinID="RadComboBoxStandard">
                                    </telerik:RadComboBox>
                    <asp:HiddenField ID="hfRev" runat="server" />
                </div>
                <div class="code-description-description">
                    &nbsp;
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    &nbsp;
                </div>
                 <div class="code-description-code">
                    &nbsp;
                </div>
                <div class="code-description-description">
                    &nbsp;
                </div>
            </div>
        </div>
        <div style="display: inline-block;">
            <div class="code-description-container">
                <div class="code-description-label">
                    Job:
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtJobNum" runat="server" TabIndex="8" Text="" SkinID="TextBoxCodeSmall" MaxLength="6"
                                        ReadOnly="true"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtJobDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Component:
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtJobCompNum" runat="server" TabIndex="9" Text="" SkinID="TextBoxCodeSmall"
                                        MaxLength="3" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtJobCompDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container" id="divJob" runat="server">
                <div class="code-description-label">
                    <asp:Label ID="lblQty" runat="server">Qty:</asp:Label>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtQty" runat="server" TabIndex="10" Text="" Width="100px" SkinID="TextBoxStandard"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    &nbsp;
                </div>
            </div>
            <div class="code-description-container" id="divComponent" runat="server">
                <div class="code-description-label">
                    <asp:Label ID="lblCPU" runat="server">CPU:</asp:Label>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtCPU" runat="server" TabIndex="11" Text="" Width="100px" ReadOnly="true" SkinID="TextBoxStandard"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    &nbsp;
                </div>
            </div>
            <div class="code-description-container" id="div1" runat="server">
                <div class="code-description-label">
                    <asp:Label ID="lblCPM" runat="server">CPM:</asp:Label>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="txtCPM" runat="server" TabIndex="12" Text="" Width="100px" ReadOnly="true" SkinID="TextBoxStandard"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    &nbsp;
                </div>
            </div>
        </div>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelComments" runat="server" TitleText="Comments">
        <br />
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="left" valign="top">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="right" valign="top" width="13%">
                                <span>Quote:</span>
                            </td>
                            <td align="left" valign="top" width="2%">&nbsp;
                            </td>
                            <td align="left" valign="top" width="80%">
                                <telerik:RadEditor ID="RadEditorQuoteComment" runat="server" ToolsFile="~/RadEditorToolbars.xml" NewLineMode="Br" Height="420" AutoResizeHeight="True"  StripFormattingOptions="MsWord"
                                    ContentAreaCssFile="~/CSS/RadEditorContentArea.min.css" Width="98%" EditModes="Design" OnClientLoad="OnClientLoad" ContentAreaMode="Div" OnClientCommandExecuted="RadEditorOnClientCommandExecuted">
                                </telerik:RadEditor>
                                <asp:HiddenField ID="HiddenFieldKey" runat="server" />
                                <script type="text/javascript">
                                    function OnClientLoad(editor, args) {
                                        try {
                                            if (editor) {
                                                editor.attachEventHandler("blur", function (e) {
                                                    var html = editor.get_html(true);
                                                    var text = editor.get_text(true);
                                                    DataChangeEstimateHeader('<%= Me.HiddenFieldKey.Value%>', 'EST_QTE_COMMENT', text, '<%= Me.RadEditorQuoteComment.ClientID%>');
                                                    DataChangeEstimateHeader('<%= Me.HiddenFieldKey.Value%>', 'EST_QTE_COMMENT_HTML', html, '<%= Me.RadEditorQuoteComment.ClientID%>');
                                                });
                                                var buttonsHolder = $get(editor.get_id() + "Top");
                                                var buttons = buttonsHolder.getElementsByTagName("A");
                                                for (var i = 0; i < buttons.length; i++) {
                                                    var a = buttons[i];
                                                    a.tabIndex = -1;
                                                    a.tabStop = false;
                                                };
                                            }
                                        } catch (e) { }
                                    };
                                </script>
                            </td>
                            <td align="left" valign="top" width="5%">
                                <asp:ImageButton ID="imgbtnSpecsQuote" runat="server" SkinID="ImageButtonInsert" ToolTip="Insert Specifications" />
                            </td>
                        </tr>
                    </table>                    
                    <table>
                        <tr>
                            <td>&nbsp;<br /></td>
                        </tr>
                    </table>
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="right" valign="top" width="13%">
                                <span>
                                    <asp:Label ID="lblRevisionDD" runat="server">Revision:</asp:Label></span>
                            </td>
                            <td align="left" valign="top" width="2%">&nbsp;
                            </td>
                            <td align="left" valign="top" width="80%">
                                <telerik:RadEditor ID="RadEditorRevisionComment" runat="server" ToolsFile="~/RadEditorToolbars.xml" NewLineMode="Br" Height="420" AutoResizeHeight="True"
                                    ContentAreaCssFile="~/CSS/RadEditorContentArea.min.css" Width="98%" EditModes="Design" OnClientLoad="OnClientLoadRevision" StripFormattingOptions="MsWord" ContentAreaMode="Div" OnClientCommandExecuted="RadEditorOnClientCommandExecuted">
                                </telerik:RadEditor>
                                <script type="text/javascript">
                                    function OnClientLoadRevision(editor, args) {
                                        try {
                                            if (editor) {
                                                editor.attachEventHandler("blur", function (e) {
                                                    var html = editor.get_html(true);
                                                    var text = editor.get_text(true);
                                                    DataChangeEstimateHeader('<%= Me.HiddenFieldKey.Value%>', 'EST_REV_COMMENT', text, '<%= Me.RadEditorRevisionComment.ClientID%>');
                                                    DataChangeEstimateHeader('<%= Me.HiddenFieldKey.Value%>', 'EST_REV_COMMENT_HTML', html, '<%= Me.RadEditorRevisionComment.ClientID%>');
                                                });
                                                var buttonsHolder = $get(editor.get_id() + "Top");
                                                var buttons = buttonsHolder.getElementsByTagName("A");
                                                for (var i = 0; i < buttons.length; i++) {
                                                    var a = buttons[i];
                                                    a.tabIndex = -1;
                                                    a.tabStop = false;
                                                };
                                            }
                                        } catch (e) {}
                                    };
                                </script>
                            </td>
                            <td align="left" valign="top" width="5%">
                                <asp:ImageButton ID="imgbtnSpecsRev" runat="server" SkinID="ImageButtonInsert" ToolTip="Insert Specifications"/>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelOtherInformation" runat="server" TitleText="Specs" Collapsed="true">
        <div style="display: inline-block;">
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:LinkButton ID="HlVersion" runat="server">Version:</asp:LinkButton>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtVersion" runat="server" TabIndex="15" Text="" MaxLength="3" SkinID="TextBoxCodeSmall"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TextBoxVersionDescription" runat="server" TabIndex="15" Text="" MaxLength="3" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:Label ID="lblRevision" runat="server">Revision:</asp:Label>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtRevision" runat="server" TabIndex="16" Text="" ReadOnly="true"
                                    SkinID="TextBoxCodeSmall"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    &nbsp;
                </div>
            </div>
        </div>                
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelEstimateTotals" runat="server"
        TitleText="Estimate Totals">
        <table align="left" border="0" cellpadding="0" cellspacing="0" width="800px">
            <tr>
                <td align="Right" valign="middle">
                    <asp:Label ID="lblJobBudget" runat="server" Text="Job Budget"></asp:Label>
                </td>
                <td align="center" valign="middle">&nbsp;
                </td>
                <td align="Right" valign="middle">
                    <asp:Label ID="lblQuoteAmount" runat="server" Text="Quote Amount"></asp:Label>
                </td>
                <td align="center" valign="middle">&nbsp;
                </td>
                <td align="Right" valign="middle">
                    <asp:Label ID="lblContingency" runat="server" Text="Contingency"></asp:Label>
                </td>
                <td align="center" valign="middle">&nbsp;
                </td>
                <td align="Right" valign="middle">
                    <asp:Label ID="lblQuotewithContingency" runat="server" Text="Quote w/Contingency"></asp:Label>
                </td>
                <td align="center" valign="middle">&nbsp;
                </td>
                <td align="Right" valign="middle">
                    <asp:Label ID="lblActualPO" runat="server" Text="Actual/P.O."></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="Right" valign="middle">
                    <asp:Label ID="lblJobBudgetAmount" runat="server"></asp:Label>
                </td>
                <td align="center" valign="middle">&nbsp;
                </td>
                <td align="Right" valign="middle">
                    <asp:Label ID="lblQuoteAmt" runat="server"></asp:Label>
                </td>
                <td align="center" valign="middle">&nbsp;
                </td>
                <td align="Right" valign="middle">
                    <asp:Label ID="lblContingencyAmount" runat="server"></asp:Label>
                </td>
                <td align="center" valign="middle">&nbsp;
                </td>
                <td align="Right" valign="middle">
                    <asp:Label ID="lblQuotewithContingnecyAmount" runat="server"></asp:Label>
                </td>
                <td align="center" valign="middle">&nbsp;
                </td>
                <td align="Right" valign="middle">
                    <asp:Label ID="lblActualPOAmount" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </ew:CollapsablePanel>
    <asp:Panel ID="PnlGridToolbar" runat="server" Width="100%">
        <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
            <script type="text/javascript">
                function RadToolbarEstimateGridOnClientButtonClicking(sender, args) {
                    var comandName = args.get_item().get_commandName();
                    if (comandName == "AddNewGridRow") {
                        //////args.set_cancel(!confirm('Are you sure you want to delete?'));
                        radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                    }
                    if (comandName == "DeleteRows") {
                        ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                        radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                        //return confirmDeleteGrid();
                    }
                    if (comandName == "ClearPhase") {
                        ////args.set_cancel(!confirm('Are you sure you want to clear Phases?'));
                        radToolBarConfirm(sender, args, "Are you sure you want to clear Phases?");
                        //return confirmDeletePhase();
                    }
                    if (comandName == "Save") {
                        //////args.set_cancel(!confirm('Are you sure you want to clear all assignments?'));
                        var a = checkvalue('<%= Me.hfApproved.ClientID  %>');
                        var b = checkvalue('<%= Me.hfInternalApproved.ClientID  %>');
                        if (a == '1') {
                            ////args.set_cancel(!confirm('This quote is approved. Are you sure you want to save the changes?'));
                            radToolBarConfirm(sender, args, "This quote is approved. Are you sure you want to save the changes?");
                            //return confirmSave2();
                        }
                        else if (b == '1') {
                            ////args.set_cancel(!confirm('This quote is approved. Are you sure you want to save the changes?'));
                            radToolBarConfirm(sender, args, "This quote is approved. Are you sure you want to save the changes?");
                            //return confirmSave2();
                        }
                        else {
                            //realPostBack("Save", "Save");
                            return false;
                        }
                    }
                    if (comandName == "Add" || comandName == "Subtract") {
                        //////args.set_cancel(!confirm('Are you sure you want to clear all assignments?'));
                        var a = checkvalue('<%= Me.hfApproved.ClientID  %>');
                        var b = checkvalue('<%= Me.hfInternalApproved.ClientID  %>');
                        if (a == '1') {
                            ////args.set_cancel(!confirm('This quote is approved. Are you sure you want to update this quote based on related components?  You can create a revision to preserve the original quote before updating'));
                            radToolBarConfirm(sender, args, "This quote is approved. Are you sure you want to update this quote based on related components?  You can create a revision to preserve the original quote before updating.");
                            //return confirmSave2();
                        }
                        else if (b == '1') {
                            ////args.set_cancel(!confirm('This quote is approved. Are you sure you want to update this quote based on related components?  You can create a revision to preserve the original quote before updating'));
                            radToolBarConfirm(sender, args, "This quote is approved. Are you sure you want to update this quote based on related components?  You can create a revision to preserve the original quote before updating.");
                            //return confirmSave2();
                        }
                        else {
                            ////args.set_cancel(!confirm('Are you sure you want to update this quote based on related components?  You can create a revision to preserve the original quote before updating'));
                            radToolBarConfirm(sender, args, "Are you sure you want to update this quote based on related components?  You can create a revision to preserve the original quote before updating.");
                        }
                    }
                    if (comandName == "CreatePO") {
                        ////args.set_cancel(!confirm('Are you sure you want to create a PO from the selected estimate lines?'));
                        radToolBarConfirm(sender, args, "Are you sure you want to create a PO from the selected estimate lines?");
                        //return confirmDeletePhase();
                    }
                }

                function confirmDeleteGrid() {
                    if (confirm("Are you sure you want to delete?")) {
                        realPostBack("DeleteRows", "DeleteRows");
                    }
                }
                function confirmDeletePhase() {
                    if (confirm("Are you sure you want to clear Phases?")) {
                        realPostBack("ClearPhase", "ClearPhase");
                    }
                }
                function confirmSave2() {
                    if (confirm("This quote is approved. Are you sure you want to save the changes?")) {
                        realPostBack("Save", "Save");
                    } else {
                        return false;
                    }
                }
            </script>
        </telerik:RadScriptBlock>
        <telerik:RadToolBar ID="RadToolbarEstimateGrid" runat="server" AutoPostBack="true"
            OnClientButtonClicking="RadToolbarEstimateGridOnClientButtonClicking">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Value="RadToolBarButtonFunctionsTooltip" Text="Functions" CommandName="NoPostBack">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Value="RadToolBarButtonPhaseTooltip" Text="Phase" CommandName="NoPostBack">
                </telerik:RadToolBarButton>
                <%--<telerik:RadToolBarButton Text="New Row" Value="NewRow"
                    ToolTip="Add row" />
                <telerik:RadToolBarButton Text="Delete Row" Value="DeleteRows"
                    ToolTip="Delete selected rows" CommandName="DeleteRows" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Template" Value="QuickAdd"
                    ToolTip="Add functions using quick add screen/templates" />
                <telerik:RadToolBarButton Text="Copy Quote" Value="CopyQuote"
                    Enabled="true" ToolTip="Copy from an existing quote" />
                <telerik:RadToolBarButton Text="Quote from Schedule"
                    Value="QuoteFromPS" ToolTip="Create Quote from Schedule" />
                <telerik:RadToolBarButton Text="Job History" Value="JobHistory"
                    Enabled="true" ToolTip="Create Quote from Job History" />
                <telerik:RadToolBarButton Text="Quote from Campaign" Value="Campaign"
                    Enabled="true" ToolTip="Update Quote from Campaign" />
                <telerik:RadToolBarDropDown Text="Update">
                    <Buttons>
                        <telerik:RadToolBarButton Text="Add" Value="Add" CommandName="Add"
                            Enabled="true" ToolTip="Update this quote by adding up quotes on all components" />
                        <telerik:RadToolBarButton Text="Subtract" Value="Subtract" CommandName="Subtract"
                            Enabled="true" ToolTip="Update this quote by subtracting quotes on all other components" />
                    </Buttons>
                </telerik:RadToolBarDropDown>--%>
                <telerik:RadToolBarButton IsSeparator="true" />
                <%--<telerik:RadToolBarButton Text="Set Phase" Value="SetPhase"
                    ToolTip="Set Phase for selected rows" />
                <telerik:RadToolBarButton Text="Clear Phase" Value="ClearPhase"
                    ToolTip="Clear Phase for selected rows" CommandName="ClearPhase" />
                <telerik:RadToolBarButton IsSeparator="true" />--%>
                <telerik:RadToolBarButton Text="Blended Time Rate:" Value="RadToolBarButtonLblBlendRate" Enabled="true">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Value="RadToolBarButtonTxtBlendRate">
                    <ItemTemplate>
                        <asp:TextBox ID="txtBlendRate" runat="server" Width="80px" MaxLength="9" SkinID="TextBoxStandard"></asp:TextBox>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="Filter Phase By:" Value="RadToolBarButtonLblPhase" Enabled="true">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Value="RadToolBarButtonDdPhase" Enabled="true">
                    <ItemTemplate>
                        <telerik:RadComboBox ID="ddPhase" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard">
                        </telerik:RadComboBox>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Sort:" Value="RadToolBarButtonLblSort">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Value="RadToolBarButtonDropSort">
                    <ItemTemplate>
                        <telerik:RadComboBox ID="DropSort" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard">
                            <Items>
                                <telerik:RadComboBoxItem Text="Function Code" Value="funccode"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="Consolidation Code" Value="conscode"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="Function Type" Value="functype"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="Function Heading" Value="funcheading"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="Sequence Number" Value="seqnbr"></telerik:RadComboBoxItem>
                            </Items>
                        </telerik:RadComboBox>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Create Purchase Order" Value="CreatePO" ToolTip="Create Purchase Order from estimate." CommandName="CreatePO">
                </telerik:RadToolBarButton>
            </Items>
        </telerik:RadToolBar>
        <telerik:RadToolTip ID="RadToolTipFunctions" runat="server" SkinID="RadToolTipToolbarContentArea" Width="600" Height="280" TargetControlID="RadToolBarButtonFunctionsTooltip">
            <div style="width: 275px; float: left; position: relative;">
                <div style="font-size: larger;">
                    Add Functions
                </div>
                <div>
                    <div style="padding: 11px 0px 0px 0px;">
                        <asp:Button ID="ButtonAddFunctionsFromListOfFunctions" runat="server" Text="Manually or from list of Functions" ToolTip="Add Function(s) from a list of all available Functions" Width="250" />
                    </div>
                    <div style="padding: 6px 0px 0px 0px;">
                        <asp:Button ID="ButtonAddFunctionsFromFunctionTemplates" runat="server" Text="From Function templates" ToolTip="Add Function(s) from predefined Function templates" Width="250" />
                    </div>
                    <div style="padding: 6px 0px 0px 0px;">
                        <asp:Button ID="ButtonAddFunctionsCopyFromExistingQuote" runat="server" Text="From an existing quote" ToolTip="Copy the Function(s) from another quote to this one" Width="250" />
                    </div>
                    <div style="padding: 6px 0px 0px 0px;">
                        <asp:Button ID="ButtonAddFunctionsCreateFromSchedule" runat="server" Text="Create from Schedule" ToolTip="Create quote from schedule tasks" Width="250" />
                    </div>
                    <div style="padding: 6px 0px 0px 0px;">
                        <asp:Button ID="ButtonAddFunctionsCreateFromJobHistory" runat="server" Text="Create from Job History" ToolTip="Create quote from Job History" Width="250" />
                    </div>
                </div>
            </div>
            <div style="width: 275px; float: right; position: relative;">
                <div style="font-size: larger;">
                    Other Function Actions
                </div>
                <div>
                    <div style="padding: 11px 0px 0px 0px;">
                        <asp:Button ID="ButtonDeleteSelectedFunctions" runat="server" Text="Delete selected Functions" ToolTip="" Width="250" />
                    </div>
                    <div style="padding: 6px 0px 0px 0px;">
                        <asp:Button ID="ButtonQuotefromCampaign" runat="server" Text="Update from Campaign" ToolTip="Update function(s) from the campaign" Width="250" />
                    </div>
                    <div style="padding: 6px 0px 0px 0px;">
                        Update Quote:<br />
                        <asp:Button ID="ButtonAdd" runat="server" Text="Add" ToolTip="Update this quote by adding up quotes on all components" Width="110" />
                        <asp:Button ID="ButtonSubtract" runat="server" Text="Subtract" ToolTip="Update this quote by subtracting quotes on all other components" Width="110" />
                    </div>
                    <div style="padding: 6px 0px 0px 0px;">
                        &nbsp;
                    </div>
                    <div style="padding: 6px 0px 0px 0px;">
                        &nbsp;
                    </div>
                </div>
            </div>
        </telerik:RadToolTip>
        <telerik:RadToolTip ID="RadToolTipPhase" runat="server" SkinID="RadToolTipToolbarContentArea" Width="290" Height="150" TargetControlID="RadToolBarButtonPhaseTooltip">
            <div style="width: 275px; float: left; position: relative;">
                <div style="font-size: larger;">
                    Phase Actions
                </div>
                <div>
                    <div style="padding: 11px 0px 0px 0px;">
                        <asp:Button ID="ButtonPhaseSetPhase" runat="server" Text="Set phase for selected rows" ToolTip="" Width="250" />
                    </div>
                    <div style="padding: 6px 0px 0px 0px;">
                        <asp:Button ID="ButtonPhaseClearPhase" runat="server" Text="Clear phase for selected rows" ToolTip="" Width="250" />
                    </div>
                </div>
            </div>
        </telerik:RadToolTip>
    </asp:Panel>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
    
    <telerik:RadGrid ID="RadGridEstimateQuoteDetails" runat="server" AllowMultiRowSelection="true" AllowSorting="true" 
        AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True" AllowPaging="false" PageSize="10" EnableAJAX="false"        
        MasterTableView-ShowFooter="true"  AllowMultiRowEdit="True">
        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>        
        <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
        <ClientSettings AllowColumnHide="True" AllowExpandCollapse="True" AllowKeyboardNavigation="true">
            <Scrolling AllowScroll="false" SaveScrollPosition="true" UseStaticHeaders="False" />
            <Selecting AllowRowSelect="True" EnableDragToSelectRows="true" />
            <KeyboardNavigationSettings AllowSubmitOnEnter="false" />           
            <ClientEvents OnGridCreated="radGridOnGridCreated" OnRowContextMenu="OnRowContextMenu" />
        </ClientSettings>
        <HeaderContextMenu>
            <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
        </HeaderContextMenu>
        <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ESTIMATE_NUMBER,EST_COMPONENT_NBR,EST_QUOTE_NBR,SEQ_NBR,INDEX,FNC_TYPE, INCL_CPU, EMPLOYEE_TITLE_ID" InsertItemDisplay="Top" EnableLinqGrouping="false">
            <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
            <Columns>
                <telerik:GridTemplateColumn UniqueName="ColumnSelect" Visible="true">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="16px" />
                    <HeaderTemplate>
                        <input id="CheckBoxSelectAllRows" type="checkbox" name="CheckBoxSelectAllRows" onclick="SelectAllRows(this.checked)" />
                    </HeaderTemplate>
                    <ItemTemplate>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="EST_PHASE_DESC" HeaderText="Phase" UniqueName="colEST_PHASE_DESC"
                    Display="False">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtPhase" runat="server" Text='<%# Eval("EST_PHASE_DESC") %>' Width="200px"
                            ReadOnly="true"></asp:TextBox>
                        <asp:HiddenField ID="HfPhaseID" runat="server" Value='<%# Eval("EST_PHASE_ID") %>' />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="FNC_CODE" HeaderText="Function Code" UniqueName="colFNC_CODE">
                    <ItemTemplate>
                        <div class="est-radgrid-code-column">
                            <asp:TextBox ID="TxtFunctionCode" runat="server" MaxLength="6" Text='<%# Eval("FNC_CODE") %>' SkinID="TextBoxCodeMedium"
                                ></asp:TextBox>
                        </div>
                        <asp:Label ID="LblFunctionCode" runat="server" Text='<%# Eval("FNC_CODE") %>'></asp:Label>
                        <asp:HiddenField ID="HfFunctionCode" runat="server" Value='<%# Eval("FNC_CODE") %>' />
                        <asp:HiddenField ID="HfFunctionType" runat="server" Value='<%# Eval("FNC_TYPE") %>' />
                        <asp:HiddenField ID="HfFunctionHeadingID" runat="server" Value='<%# Eval("FNC_HEADING_ID") %>' />
                        <asp:HiddenField ID="HfFunctionHeadingDesc" runat="server" Value='<%# Eval("FNC_HEADING_DESC") %>' />
                        <asp:HiddenField ID="HfFuncConsolidation" runat="server" Value='<%# Eval("FNC_CONSOLIDATION") %>' />
                        <asp:HiddenField ID="HfIS_USER_ROW" runat="server" Value='<%# Eval("IS_USER_ROW") %>' />
                        <asp:HiddenField ID="HfNonbillFlag" runat="server" Value='<%# Eval("EST_NONBILL_FLAG") %>' />
                        <asp:HiddenField ID="HfTaxComm" runat="server" Value='<%# Eval("TAX_COMM") %>' />
                        <asp:HiddenField ID="HfTaxCommOnly" runat="server" Value='<%# Eval("TAX_COMM_ONLY") %>' />
                        <input type="hidden" id="HiddenFieldTaxComm" runat="server" Value='<%# Eval("TAX_COMM") %>' />
                        <input type="hidden" id="HiddenFieldTaxCommOnly" runat="server" Value='<%# Eval("TAX_COMM_ONLY") %>' />
                        <input type="hidden" id="HiddenFieldNonbillFlag" runat="server" Value='<%# Eval("EST_NONBILL_FLAG") %>'/>
                        <input type="hidden" id="HiddenFunctionType" runat="server" Value='<%# Eval("FNC_TYPE") %>'/>
                        <input type="hidden" id="HiddenFunctionSequence" runat="server" Value='<%# Eval("SEQ_NBR") %>'/>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="FNC_DESCRIPTION" HeaderText="Function Description"
                    UniqueName="colFNC_DESCRIPTION">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtFNC_DESCRIPTION" runat="server" Text='<%# Eval("FNC_DESCRIPTION") %>' SkinID="TextBoxText20"
                            ReadOnly="true" ></asp:TextBox>
                        <asp:HiddenField ID="HfFNC_DESCRIPTION" runat="server" Value='<%# Eval("FNC_DESCRIPTION") %>' />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn Display="False" HeaderText="&nbsp;" UniqueName="colComments">
                    <ItemTemplate>
                        <div id="DivAddComments" runat="server" class="icon-background background-color-sidebar">
                            <asp:ImageButton ID="ImageButtonAddComments" runat="server" SkinID="ImageButtonCommentWhite" ToolTip="Show Comments" CommandArgument='<%#Eval("SEQ_NBR")%>' CommandName="ShowComments" />
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="SEQ" UniqueName="colSEQ_NBR" Display="false">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtSEQ_NBR" runat="server" SkinID="TextBoxStandard" ReadOnly="true" Text='<%#Eval("SEQ_NBR") %>'
                            Width="22px"></asp:TextBox>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Detail Comments" UniqueName="colEST_FNC_COMMENT"
                    Display="False">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtEST_FNC_COMMENT" runat="server" SkinID="TextBoxStandard" Text='<%#Eval("EST_FNC_COMMENT")%>' TextMode="multiLine" CssClass="radgrid-textarea"></asp:TextBox>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="EST_REV_SUP_BY_CDE" HeaderText="Supplied By"
                    UniqueName="colEST_REV_SUP_BY_CDE" Display="False">
                    <ItemTemplate>
                        <div class="est-radgrid-code-column">
                            <asp:TextBox ID="TxtEST_REV_SUP_BY_CDE" runat="server"  MaxLength="6" Text='<%#Eval("EST_REV_SUP_BY_CDE") %>' SkinID="TextBoxCodeMedium"
                             ></asp:TextBox>
                        </div>
                        <asp:HiddenField ID="HfSuppliedByCode" runat="server" Value='<%# Eval("EST_REV_SUP_BY_CDE") %>' />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="EMP_TITLE" HeaderText="Employee Title"
                    UniqueName="colEMPLOYEE_TITLE" Display="False">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtEMPLOYEE_TITLE" runat="server" Text='<%#Eval("EMP_TITLE") %>' SkinID="TextBoxText20" ></asp:TextBox>
                        <input type="hidden" id="HiddenEmployeeTitleID" runat="server" Value='<%# Eval("EMPLOYEE_TITLE_ID") %>'/>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Supplied By Notes" UniqueName="colEST_REV_SUP_BY_NTE"
                    Display="False">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtEST_REV_SUP_BY_NTE" runat="server" Text='<%#Eval("EST_REV_SUP_BY_NTE")%>' TextMode="multiLine" CssClass="radgrid-textarea" SkinID="TextBoxStandard"></asp:TextBox>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="EST_REV_QUANTITY" HeaderText="Quantity/ Hours"
                    UniqueName="colEST_REV_QUANTITY">
                    <ItemTemplate>
                        <div class="est-Quantity-col">
                            <asp:TextBox ID="TxtEST_REV_QUANTITY" runat="server" Style="text-align: right;" MaxLength="12" SkinID="TextBoxStandard"
                                Text='<%# Eval("EST_REV_QUANTITY") %>' Width="90px" ></asp:TextBox>
                        </div>
                    </ItemTemplate>                    
                    <FooterTemplate>
                        <div class="est-Quantity-col" >
                            <asp:TextBox ID="TxtSumEST_REV_QUANTITY" runat="server" ReadOnly="true" Style="text-align: right;" Width="90px" SkinID="TextBoxStandard"></asp:TextBox>
                        </div>
                    </FooterTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="EST_REV_RATE" HeaderText="Rate" UniqueName="colEST_REV_RATE">
                    <ItemTemplate>
                        <div class="est-Rate-col">
                            <asp:TextBox ID="TxtEST_REV_RATE" runat="server" Style="text-align: right;" MaxLength="18" Width="90px" SkinID="TextBoxStandard"
                                Text='<%# Eval("EST_REV_RATE")%>' ></asp:TextBox>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="EST_REV_EXT_AMT" HeaderText="Extended Amount"
                    UniqueName="colEST_REV_EXT_AMT">
                    <ItemTemplate>
                        <div class="est-Rate-col">
                            <asp:TextBox ID="TxtEST_REV_EXT_AMT" runat="server" Style="text-align: right;" MaxLength="15" SkinID="TextBoxStandard"
                                Text='<%# Eval("EST_REV_EXT_AMT") %>' Width="90px" ></asp:TextBox>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        <div class="est-Rate-col">
                            <asp:TextBox ID="TxtSumEST_REV_EXT_AMT" runat="server" ReadOnly="true" Style="text-align: right;" Width="90px" SkinID="TextBoxStandard"></asp:TextBox>
                        </div>
                    </FooterTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="EST_REV_COMM_PCT" HeaderText="Markup %" UniqueName="colEST_REV_COMM_PCT"
                    Display="False">
                    <ItemTemplate>                       
                        <div class="est-Markup-col">
                            <asp:TextBox ID="TxtEST_REV_COMM_PCT" runat="server" Style="text-align: right;" MaxLength="9" SkinID="TextBoxStandard"
                                Text='<%# Eval("EST_REV_COMM_PCT") %>' Width="80px"></asp:TextBox>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Markup Amount" UniqueName="colMARKUP_AMT"
                    Display="False">
                    <ItemTemplate>                       
                        <div class="est-Rate-col">
                            <asp:TextBox ID="TxtMARKUP_AMT" runat="server" Style="text-align: right;" MaxLength="20" SkinID="TextBoxStandard"
                                Text='<%# Eval("EXT_MARKUP_AMT") %>' Width="90px"></asp:TextBox>
                        </div>
                        <asp:HiddenField ID="HfMarkupAmt" runat="server" Value='<%# Eval("EXT_MARKUP_AMT")%>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <div class="est-Rate-col">
                            <asp:TextBox ID="TxtSumEXT_MARKUP_AMT" runat="server" ReadOnly="true" Style="text-align: right;" Width="90px" SkinID="TextBoxStandard"></asp:TextBox>
                        </div>
                    </FooterTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="EST_REV_EXT_MU_AMT" HeaderText="Extended Amount w/Markup"
                    UniqueName="colEST_REV_EXT_MU_AMT" Display="false">
                    <ItemTemplate>
                        <div class="est-Rate-col">
                            <asp:TextBox ID="TxtEST_REV_EXT_MU_AMT" runat="server" Style="text-align: right;" MaxLength="15" SkinID="TextBoxStandard"
                                Text='<%# Eval("EST_REV_EXT_MU_AMT") %>' Width="90px" ReadOnly="true" ></asp:TextBox>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        <div class="est-Rate-col">
                            <asp:TextBox ID="TxtSumEST_REV_EXT_MU_AMT" runat="server" ReadOnly="true" Style="text-align: right;" Width="90px" SkinID="TextBoxStandard"></asp:TextBox>
                        </div>
                    </FooterTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="TAX_CODE" HeaderText="Tax Code" UniqueName="colTAX_CODE"
                    Display="False">
                    <ItemTemplate>
                        <div class="est-radgrid-code-column">
                            <asp:TextBox ID="TxtTaxCode" runat="server" MaxLength="4" Text='<%# Eval("TAX_CODE") %>' SkinID="TextBoxCodeMedium"
                                ></asp:TextBox>
                        </div>
                        <asp:HiddenField ID="HfTaxCode" runat="server" Value='<%# Eval("TAX_CODE") %>' />
                        <asp:HiddenField ID="HfTaxStatePct" runat="server" Value='<%# Eval("TAX_STATE_PCT") %>' />
                        <asp:HiddenField ID="HfTaxCountyPct" runat="server" Value='<%# Eval("TAX_COUNTY_PCT") %>' />
                        <asp:HiddenField ID="HfTaxCityPct" runat="server" Value='<%# Eval("TAX_CITY_PCT") %>' />
                        <asp:HiddenField ID="HfTaxStatePercent" runat="server" Value='<%# Eval("DFLT_TAX_STATE_PERCENT") %>' />
                        <asp:HiddenField ID="HfTaxCountyPercent" runat="server" Value='<%# Eval("DFLT_TAX_COUNTY_PERCENT") %>' />
                        <asp:HiddenField ID="HfTaxCityPercent" runat="server" Value='<%# Eval("DFLT_TAX_CITY_PERCENT") %>' />
                        <asp:HiddenField ID="HfTaxResale" runat="server" Value='<%# Eval("TAX_RESALE") %>' />
                        <input type="hidden" id="HiddenFieldTaxCode" runat="server" Value='<%# Eval("TAX_CODE") %>'/>
                        <input type="hidden" id="HiddenFieldTaxStatePct" runat="server" Value='<%# Eval("TAX_STATE_PCT") %>'/>
                        <input type="hidden" id="HiddenFieldTaxCountyPct" runat="server" Value='<%# Eval("TAX_COUNTY_PCT") %>'/>
                        <input type="hidden" id="HiddenFieldTaxCityPct" runat="server" Value='<%# Eval("TAX_CITY_PCT") %>'/>
                        <input type="hidden" id="HiddenFieldTaxResale" runat="server" Value='<%# Eval("TAX_RESALE") %>'/>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Tax Amount" UniqueName="colTAX_AMOUNT" Display="False">
                    <ItemTemplate>                        
                        <div class="est-Rate-col">
                            <asp:TextBox ID="TxtTAX_AMOUNT" runat="server" Style="text-align: right;" MaxLength="20" Width="90px" SkinID="TextBoxStandard"
                                ReadOnly="true" Text='<%# (Eval("TAX")) %>'></asp:TextBox>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        <div class="est-Amount-col">
                            <asp:TextBox ID="TxtSumTAX_AMOUNT" runat="server" ReadOnly="true" Style="text-align: right;" Width="90px" SkinID="TextBoxStandard"></asp:TextBox>
                        </div>
                    </FooterTemplate>
                </telerik:GridTemplateColumn>
                
                <telerik:GridTemplateColumn DataField="LINE_TOTAL" HeaderText="Function Total" UniqueName="colLINE_TOTAL">
                    <ItemTemplate>                       
                        <div class="est-Rate-col">
                            <asp:TextBox ID="TxtLINE_TOTAL" runat="server" Style="text-align: right;" MaxLength="16" SkinID="TextBoxStandard"
                                Text='<%# Eval("LINE_TOTAL") %>' Width="90px" ReadOnly="true"></asp:TextBox>
                        </div>
                        <asp:HiddenField ID="HfLineTotal" runat="server" Value='<%# Eval("LINE_TOTAL") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <div class="est-Rate-col">
                            <asp:TextBox ID="TxtSumLINE_TOTAL" runat="server" ReadOnly="true" Style="text-align: right;" Width="90px" SkinID="TextBoxStandard"></asp:TextBox>
                        </div>
                    </FooterTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Gross Income" UniqueName="colGrossIncome"
                    Display="False"> 
                    <ItemTemplate>                       
                        <div class="est-Rate-col">
                            <asp:TextBox ID="TxtGrossIncome" runat="server" Style="text-align: right;" MaxLength="20" SkinID="TextBoxStandard"
                                Text='' Width="90px"></asp:TextBox>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        <div class="est-Rate-col">
                            <asp:TextBox ID="TxtSumGrossIncome" runat="server" ReadOnly="true" Style="text-align: right;" Width="90px" SkinID="TextBoxStandard"></asp:TextBox>
                        </div>
                    </FooterTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="EST_REV_CONT_PCT" HeaderText="Contingency %"
                    UniqueName="colEST_REV_CONT_PCT" Display="False">
                    <ItemTemplate>                       
                        <div class="est-Markup-col">
                            <asp:TextBox ID="TxtEST_REV_CONT_PCT" runat="server" Style="text-align: right;" MaxLength="9" SkinID="TextBoxStandard"
                                Text='<%# Eval("EST_REV_CONT_PCT") %>' Width="80px"></asp:TextBox>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="EXT_CONTINGENCY" HeaderText="Contingency Amount"
                    UniqueName="colEXT_CONTINGENCY" Display="False">
                    <ItemTemplate>                      
                        <div class="est-Rate-col">
                            <asp:TextBox ID="TxtEXT_CONTINGENCY" runat="server" Style="text-align: right;" MaxLength="16" SkinID="TextBoxStandard"
                                Text='<%# Eval("LINE_TOTAL_CONT") %>' Width="90px" ReadOnly="true"></asp:TextBox>
                        </div>
                        <asp:HiddenField ID="HfContingency" runat="server" Value='<%# Eval("EXT_CONTINGENCY") %>' />
                        <asp:HiddenField ID="HfMUContingency" runat="server" Value='<%# Eval("EXT_MU_CONT") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <div class="est-Rate-col">
                            <asp:TextBox ID="TxtSumEXT_CONTINGENCY" runat="server" ReadOnly="true" Style="text-align: right;" Width="90px" SkinID="TextBoxStandard"></asp:TextBox>
                        </div>
                    </FooterTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="QUOTE_W_CONTINGENCY" HeaderText="Total w/Contingency"
                    UniqueName="colQUOTE_W_CONTINGENCY" Display="False">
                    <ItemTemplate>                      
                        <div class="est-Rate-col">
                            <asp:TextBox ID="TxtQUOTE_W_CONTINGENCY" runat="server" Style="text-align: right;" MaxLength="16" SkinID="TextBoxStandard"
                                Text='<%# Eval("QUOTE_W_CONTINGENCY") %>' Width="100px" ReadOnly="true"></asp:TextBox>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        <div class="est-Rate-col">
                            <asp:TextBox ID="TxtSumQUOTE_W_CONTINGENCY" runat="server" ReadOnly="true" Style="text-align: right;" Width="100px" SkinID="TextBoxStandard"></asp:TextBox>
                        </div>
                    </FooterTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="CPU" UniqueName="colCPU" Display="False">
                    <HeaderStyle HorizontalAlign="Center" CssClass="est-CPU-col" />
                    <ItemStyle HorizontalAlign="Center" CssClass="est-CPU-col" />
                    <FooterStyle HorizontalAlign="Center" CssClass="est-CPU-col" />
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkCPU" runat="server"  />
                        <asp:HiddenField ID="HfCPM" runat="server" Value='<%# Eval("EST_CPM_FLAG") %>' />
                        <input type="hidden" id="HiddenFieldCPM" runat="server" Value='<%# Eval("EST_CPM_FLAG") %>'/>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TxtSumCPU" runat="server" ReadOnly="true" Style="text-align: right;" Width="90px" SkinID="TextBoxStandard"></asp:TextBox>
                    </FooterTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="IS_USER_ROW" HeaderText="IS_USER_ROW" UniqueName="ColTESTING_COLUMN"
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn UniqueName="colFEE_TIME">
                    <HeaderStyle CssClass="radgrid-icon-column" />
                    <ItemStyle CssClass="radgrid-icon-column" />
                    <FooterStyle CssClass="radgrid-icon-column" />
                    <ItemTemplate>
                        <asp:HiddenField ID="HfFEE_TIME" runat="server" Value='<%# Eval("FEE_TIME") %>' />
                        <asp:HiddenField ID="HfEST_NONBILL_FLAG" runat="server" Value='<%# Eval("EST_NONBILL_FLAG") %>' />
                        <div class="icon-background background-color-sidebar" runat="server" id="DivFlagColor">
                            <asp:Image ID="ImageFlag" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/signal_flag.png" />
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave" Resizable="false">
                    <HeaderStyle CssClass="radgrid-icon-column" />
                    <ItemStyle CssClass="radgrid-icon-column" />
                    <FooterStyle CssClass="radgrid-icon-column" />
                    <ItemTemplate>                        
                    </ItemTemplate>
                    <EditItemTemplate>
                        <div class="icon-background background-color-sidebar">
                            <asp:ImageButton ID="ImageButton_AddFunction" runat="server" AlternateText="Add Item" CommandName="AddItem"
                                ToolTip="Add Item" SkinID="ImageButtonNewWhite" />
                        </div>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnCopy" Resizable="false">
                    <HeaderStyle CssClass="radgrid-icon-column" />
                    <ItemStyle CssClass="radgrid-icon-column" />
                    <FooterStyle CssClass="radgrid-icon-column" />
                    <ItemTemplate>
                        <div id="DivCopyFunction" class="icon-background background-color-sidebar" runat="server">
                            <asp:ImageButton ID="ImageButton_CopyFunction" runat="server" AlternateText="Copy" CommandName="Copy"
                                CommandArgument='<%#Eval("SEQ_NBR")%>' ToolTip="Copy" SkinID="ImageButtonCopyWhite" />
                        </div>
                    </ItemTemplate>
                    <EditItemTemplate>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete" Resizable="false">
                    <HeaderStyle CssClass="radgrid-icon-column" />
                    <ItemStyle CssClass="radgrid-icon-column" />
                    <FooterStyle CssClass="radgrid-icon-column" />
                    <ItemTemplate>
                        <div id="DivDeleteFunction" class="icon-background background-color-delete" runat="server">
                            <asp:ImageButton ID="ImageButton_DeleteFunction" runat="server" AlternateText="Delete" CommandName="Delete"
                                CommandArgument='<%#Eval("SEQ_NBR")%>' ToolTip="Delete" SkinID="ImageButtonDeleteWhite" />
                        </div>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <div class="icon-background background-color-delete">
                            <asp:ImageButton ID="ImageButton_CancelFunction" runat="server" AlternateText="Cancel" CommandName="CancelItem"
                                ToolTip="Cancel add row" SkinID="ImageButtonCancelWhite" />
                        </div>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="FNC_TYPE" HeaderText="FNC_TYPE" UniqueName="ColFNC_TYPE"
                    Visible="False">
                </telerik:GridBoundColumn>
            </Columns>
            <ExpandCollapseColumn Resizable="False" Visible="False">
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <RowIndicatorColumn Visible="False">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
        </MasterTableView>
    </telerik:RadGrid>

                </ContentTemplate>
            </asp:UpdatePanel>


    <telerik:RadGrid ID="RadGridEstimateSummary" runat="server" AllowMultiRowSelection="true" Visible="false"
        HorizontalAlign="Center" AutoGenerateColumns="False" GridLines="None" AllowSorting="true" EnableAJAX="false"
        AllowPaging="false" PageSize="10" ShowFooter="true"
        MasterTableView-ShowFooter="true" EnableEmbeddedSkins="True">
        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
        <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
        <ClientSettings AllowColumnHide="True" AllowExpandCollapse="True">
            <Scrolling AllowScroll="false" SaveScrollPosition="true" UseStaticHeaders="False" />
        </ClientSettings>
        <MasterTableView EnableLinqGrouping="false">
            <Columns>
                <telerik:GridBoundColumn DataField="FNC_DESCRIPTION" HeaderText="Function Description" UniqueName="colFNC_DESCRIPTION">
                    <HeaderStyle VerticalAlign="bottom" HorizontalAlign="Left" Width="150px" />
                    <ItemStyle VerticalAlign="middle" HorizontalAlign="Left" Width="150px" />
                    <FooterStyle VerticalAlign="middle" HorizontalAlign="Left" Width="150px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="EST_REV_QUANTITY" HeaderText="Quantity/ Hours" UniqueName="colEST_REV_QUANTITY" Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="left" VerticalAlign="Bottom" Width="60px" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="60px" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="60px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="EST_REV_EXT_AMT" HeaderText="Extended Amount" UniqueName="colEST_REV_EXT_AMT" Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="left" VerticalAlign="Bottom" Width="60px" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="60px" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="60px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TAX" HeaderText="Tax Amount" UniqueName="colTAX_AMOUNT" Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="bottom" Width="55" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="middle" Width="55" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="middle" Width="55" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="EXT_MARKUP_AMT" HeaderText="Markup Amount" UniqueName="colMARKUP_AMT" Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="bottom" Width="60px" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="middle" Width="60px" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="middle" Width="60px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LINE_TOTAL" HeaderText="Function Total" UniqueName="colLINE_TOTAL" Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="bottom" Width="95px" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="middle" Width="95px" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="middle" Width="95px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="GROSS_INCOME" HeaderText="Gross Income" UniqueName="colGrossIncome" Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="bottom" Width="95px" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="middle" Width="95px" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="middle" Width="95px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LINE_TOTAL_CONT" HeaderText="Contingency Amount" UniqueName="colEXT_CONTINGENCY" Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="bottom" Width="95px" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="middle" Width="95px" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="middle" Width="95px" />
                </telerik:GridBoundColumn>
            </Columns>
            <ExpandCollapseColumn Resizable="False" Visible="False">
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <RowIndicatorColumn Visible="False">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
        </MasterTableView>
    </telerik:RadGrid>
    <br />    
    <telerik:RadContextMenu ID="RadContextMenuGridItem" runat="server" OnItemClick="RadContextMenuGridItem_ItemClick" OnClientItemClicking="RadContextMenuGridItemClicking">
        <Items>            
            <telerik:RadMenuItem Text="Copy Function" Value="CopyTask"></telerik:RadMenuItem>
            <telerik:RadMenuItem IsSeparator="true"></telerik:RadMenuItem>
            <telerik:RadMenuItem Text="Delete Function" Value="DeleteTask"></telerik:RadMenuItem>
        </Items>
    </telerik:RadContextMenu>
    <asp:HiddenField ID="HiddenFieldSelectedRow" runat="server" />
    <asp:Button ID="btnSave" runat="server" Width="115" Text="Save" Visible="false" CausesValidation="false" />&nbsp;
    <asp:Button ID="btnPrint" runat="server" Width="115" Text="Print" Visible="false" /><asp:HiddenField ID="HiddenFieldSecMod" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="HiddenFieldSelectAll" runat="server" Value="0" />
    </div>
   
</div>
    <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
    <telerik:RadScriptBlock ID="RadScriptBlockFooter" runat="server">
        <script type="text/javascript">
            function RadContextMenuGridItemClicking(sender, args) {
                var itemValue = args.get_item().get_value();
                if (itemValue == "DeleteTask") {
                    var a = checkvalue('<%= Me.hfApproved.ClientID  %>');
                    var b = checkvalue('<%= Me.hfInternalApproved.ClientID  %>');
                    if (a == '1') {
                        //args.set_cancel(!confirm('This quote is approved. Are you sure you want to delete?'));
                        radToolBarConfirm(sender, args, "This quote is approved. Are you sure you want to delete?");
                        //return confirmSave();
                    }
                    else if (b == '1') {
                        //args.set_cancel(!confirm('This quote is approved. Are you sure you want to delete?'));
                        radToolBarConfirm(sender, args, "This quote is approved. Are you sure you want to delete?");
                        //return confirmSave();
                    }
                    else {
                        //args.set_cancel(!confirm('Are you sure you want to delete?'));
                        radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                        //realPostBack("Save", "Save");
                        //return false;
                    }
                };
                if (itemValue == "CopyTask") {
                    var a = checkvalue('<%= Me.hfApproved.ClientID  %>');
                    var b = checkvalue('<%= Me.hfInternalApproved.ClientID  %>');
                    if (a == '1') {
                        ////args.set_cancel(!confirm('This quote is approved. Are you sure you want to save changes?'));
                        radToolBarConfirm(sender, args, "This quote is approved. Are you sure you want to save changes?");
                        //return confirmSave();
                    }
                    else if (b == '1') {
                        ////args.set_cancel(!confirm('This quote is approved. Are you sure you want to save changes?'));
                        radToolBarConfirm(sender, args, "This quote is approved. Are you sure you want to save changes?");
                        //return confirmSave();
                    }
                    else {
                        //////args.set_cancel(!confirm('Are you sure you want to delete?'));
                        //realPostBack("Save", "Save");
                        return false;
                    }
                };
            };


            function OnRowContextMenu(sender, args) {
                var evt = args.get_domEvent();
                if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                    return;
                }

                document.getElementById('<%= HiddenFieldSelectedRow.ClientID %>').value = args.get_itemIndexHierarchical();

                var menu = $find('<%= RadContextMenuGridItem.ClientID %>');
                menu.show(evt);
                evt.cancelBubble = true;
                evt.returnValue = false;

                if (evt.stopPropagation) {
                    evt.stopPropagation();
                    evt.preventDefault();
                }

            }
            (function () {
                $('body')
                    .on('dblclick', 'input[adv-lookup]:enabled', function () {
                        var lookuptype = $(this).attr('adv-lookup');
                        var currentScope = getCurrentScope($(this));
                        if (lookuptype !== 'EstimateQuantity' && lookuptype !== 'EstimateContingencyPct' && lookuptype !== 'EstimateCommissionPercent' && lookuptype !== 'EstimateCommissionAmount' && lookuptype !== 'EstimateAmount') {
                            //if (lookuptype == 'EmployeeTitle') {
                            //    employeetitle = currentScope.getSearchCriteria().EmployeeTitle;
                            //    employeetitle = EmployeeTitle = null;
                            //    currentScope.employeeTitleValuesChanged(employeetitle, null);
                            //} 
                            getCurrentScope($(this)).openFilterDialog($(this));
                        }
                    })
                    .on('change', 'input[adv-lookup]', function () {
                        var currentScope = getCurrentScope($(this));
                        var lookuptype = $(this).attr('adv-lookup');
                        var jobComponent = {};
                        newVal = currentScope.getInputValue(lookuptype);
                        jobComponent = currentScope.getSearchCriteria().JobComponent;
                        if (lookuptype === 'Client') {
                            jobComponent.ClientName = null;
                            jobComponent.DivisionCode = null;
                            jobComponent.DivisionName = null;
                            jobComponent.ProductCode = null;
                            jobComponent.ProductName = null;
                            jobComponent.JobNumber = null;
                            jobComponent.JobDescription = null;
                            jobComponent.JobComponentNumber = null;
                            jobComponent.JobComponentDescription = null;
                            currentScope.jobComponentValuesChanged(jobComponent, newVal);
                        } else if (lookuptype === 'Division') {
                            jobComponent.DivisionName = null;
                            jobComponent.ProductCode = null;
                            jobComponent.ProductName = null;
                            jobComponent.JobNumber = null;
                            jobComponent.JobDescription = null;
                            jobComponent.JobComponentNumber = null;
                            jobComponent.JobComponentDescription = null;
                            currentScope.jobComponentValuesChanged(jobComponent, newVal);
                        } else if (lookuptype === 'Product') {
                            jobComponent.ProductName = null;
                            jobComponent.JobNumber = null;
                            jobComponent.JobDescription = null;
                            jobComponent.JobComponentNumber = null;
                            jobComponent.JobComponentDescription = null;
                            currentScope.jobComponentValuesChanged(jobComponent, newVal);
                        } else if (lookuptype === 'Job') {
                            jobComponent.JobDescription = null;
                            jobComponent.JobComponentNumber = null;
                            jobComponent.JobComponentDescription = null;
                            currentScope.jobComponentValuesChanged(jobComponent, newVal);
                        } else if (lookuptype === 'JobComponent') {
                            jobComponent.JobComponentDescription = null;
                            currentScope.jobComponentValuesChanged(jobComponent, newVal);
                        } else if (lookuptype === 'Function') {
                            currentScope.functionValuesChanged(currentScope.getSearchCriteria().Function, newVal);
                        } else if (lookuptype === 'Employee') {
                            currentScope.employeeValuesChanged(currentScope.getSearchCriteria().Employee, newVal);
                        } else if (lookuptype === 'Vendor') {
                            currentScope.vendorValuesChanged(currentScope.getSearchCriteria().Vendor, newVal);
                        } else if (lookuptype === 'TaxCode') {
                            currentScope.taxValuesChanged(currentScope.getSearchCriteria().Tax, newVal);
                        } else if (lookuptype === 'EmployeeTitle') {
                            currentScope.employeeTitleValuesChanged(currentScope.getSearchCriteria().EmployeeTitle, newVal);
                        }
                    })
                    .on('focus', 'input[adv-calc]', function () {
                        getCurrentScope($(this)).parentRow = $(this).closest('tr');
                    })
                    .on('focus', '.RadGrid input[adv-lookup]', function () {
                        getCurrentScope($(this)).parentRow = $(this).closest('tr');
                    });
            })();

            function getCurrentScope(element) {
                return angular.element(element).scope();
            }

            function radGridOnGridCreated(sender, args) {
                var cols = sender.get_masterTableView().get_columns();
                $('.RadGrid input[adv-calc]').each(function () {
                    var radInput = $find($(this).attr('id'));
                    if (radInput) {
                        radInput.add_valueChanged(function (sender, args) {
                            var element = sender.get_element();
                            var changed = $(element).attr('adv-calc');
                            getCurrentScope(element).quantityRateAmountChanged(changed);
                        });
                    }
                });
            }

            var RadAjaxPanelGridOnResponseEnd = function (sender, args) {
                $('input[adv-calc]').each(function () {
                    $(this).removeClass('rfdDecorated').removeClass('rfdInputDisabled');
                });
            }

        </script>
    </telerik:RadScriptBlock>
</asp:Content>
