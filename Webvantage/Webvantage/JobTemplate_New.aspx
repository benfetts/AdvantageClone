<%@ Page Title="New Job" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="JobTemplate_New.aspx.vb" Inherits="Webvantage.JobTemplate_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript">
        var scrollPosition;
        var selected = {};
        function copytext() {
            document.getElementById("ctl00_ContentPlaceHolderMain_txtCompDesc").value = document.getElementById("ctl00_ContentPlaceHolderMain_txtJobDesc").value;
        }
        function copyManager() {
            //try {
            //    var textBoxTrafficManager = document.getElementById("ctl00_ContentPlaceHolderMain_TextBoxTrafficManager");
            //    var textBoxCopyTrafficManager = document.getElementById("ctl00_ContentPlaceHolderMain_TextBoxCopyTrafficManager");
            //    if (textBoxTrafficManager && textBoxCopyTrafficManager) {
            //        textBoxCopyTrafficManager.value = textBoxTrafficManager.value;
            //    }
            //} catch (e) {
            //}
        }
        function RadAjaxPanelOnRequestStart(sender, args) {

            scrollPosition = $(window).scrollTop();

        }
        function RadAjaxPanelOnResponseEnd(sender, args) {

            if (scrollPosition) {

                $(window).scrollTop(scrollPosition);
                scrollPosition = null;

            }
        }
        function GridOnRowSelected(sender, args) {
            var compNo = args.getDataKeyValue('JOB_COMPONENT_NBR');
            var item = args.get_gridDataItem();
            selected[compNo] = {
                component: compNo,
                quantity: $(item.findElement('TextBoxDuplicate')).val(),
                budget: args.getDataKeyValue('JOB_COMP_BUDGET_AM')
            };
            checkAllowTemplate();
        }
        function GridOnRowDeselected(sender, args) {
            var compNo = args.getDataKeyValue('JOB_COMPONENT_NBR');
            if (selected[compNo]) {
                selected[compNo] = null;
            }
            checkAllowTemplate();
        }
        function GridOnRowCreated(sender, args) {
            var compNo = args.getDataKeyValue('JOB_COMPONENT_NBR');
            if (selected[compNo]) {
                var item = args.get_gridDataItem();
                $(item.findElement('TextBoxDuplicate')).val(selected[compNo].quantity);
                item.set_selected(true);
            }
        }
        function GridOnGridCreated(sender, args) {
            var masterTable = sender.get_masterTableView();
            var selectColumn = masterTable.getColumnByUniqueName('ColumnClientSelect');
            var headerCheckbox = $(selectColumn.get_element()).find('[type=checkbox]')[0];

            if (headerCheckbox) {
                headerCheckbox.checked = masterTable.get_selectedItems().length == masterTable.get_dataItems().length;
            }
            calculateBudget();
        }
        function dataChangeCheckRequirements() {
            window.setTimeout(function () {
                try {
                    var combo = $find("ctl00_ContentPlaceHolderMain_RadComboBoxJobTemplate");
                    var jobTemplateCode = "";
                    var clientCode = ""
                    jobTemplateCode = combo.get_value();
                    clientCode = document.getElementById("ctl00_ContentPlaceHolderMain_txtClient").value;
                    PageMethods.IsRequiredWebMethod(jobTemplateCode, clientCode, dataChangeCheckRequirementsSuccess, dataChangeCheckRequirementsFail);
                }
                catch (err) { }
            }, 50);
        }
        function dataChangeCheckRequirementsSuccess(result, userContext, methodName) {
            try {
                 if (result && result != '') {
                    var isCampaignRequired = false;
                    var isJobTypeRequired = false;
                    var isManagerRequired = false;
                    var requirements = new Array();
                    var jobTypeTextBox = $("ctl00_ContentPlaceHolderMain_TextBoxJobType");
                    var campaignTextBox = $("ctl00_ContentPlaceHolderMain_txtCampaign");
                    var managerTextBox = $("ctl00_ContentPlaceHolderMain_TextBoxTrafficManager");
                    try {
                        requirements = result.split('|');
                    } catch (e) {
                    }
                    try {
                        if (requirements[1] == "true") {
                            isJobTypeRequired = true;
                        }
                    } catch (e) {
                    }
                    try {
                        if (requirements[0] == "true") {
                            isCampaignRequired = true;
                        }
                    } catch (e) {
                    }
                    try {
                        if (requirements[2] == "true") {
                            isManagerRequired = true;
                        }
                    } catch (e) {
                    }
                    try {
                        if (jobTypeTextBox) {
                            if (isJobTypeRequired == true) {
                                jobTypeTextBox.addClass("RequiredInput");
                            } else {
                                jobTypeTextBox.removeClass("RequiredInput");
                            }
                        }
                    } catch (e) {
                    }
                    try {
                        if (campaignTextBox) {
                            if (isCampaignRequired == true) {
                                campaignTextBox.addClass("RequiredInput");
                            } else {
                                campaignTextBox.removeClass("RequiredInput");
                            }
                        }
                    } catch (e) {
                    }
                    try {
                        if (managerTextBox) {
                            if (isManagerRequired == true) {
                                managerTextBox.addClass("RequiredInput");
                            } else {
                                managerTextBox.removeClass("RequiredInput");
                            }
                        }
                    } catch (e) {
                    }
                }
           } catch (e) {
           }
        }
        function dataChangeCheckRequirementsFail(error, userContext, methodName) {
        }
        function checkAllowTemplate() {
            var compGrid = $find('<%= RadGridJobCopy.ClientID %>');
            var selectedRows = [];
            if(compGrid){
                var masterTable = compGrid.get_masterTableView();
                if(masterTable){
                    selectedRows = masterTable.get_selectedItems();
                }
            }
            if (selectedRows.length === 0) {
               $('#TemplateMessage').hide();
               $('#TemplateWrapper').show();
            } else {
                $('#TemplateMessage').show();
                $('#TemplateWrapper').hide();
            }
        }
        function pageLoad(sender, args){
            checkAllowTemplate();
        }
        function MultiplyDup(text1, text2, textResult, check) {
            calculateBudget();
            //var x = document.getElementById(text1).value;
            //var y = text2;            
            //var w = document.getElementById(check).checked;
            //var z = 0;
            //x = Number.parseLocale(x);
            //y = Number.parseLocale(y);
            //if (isNaN(x) == false && isNaN(y) == false) {

            //    if (w == "1") {
            //        z = (x * 1) * (y * 1);
            //    } else {
            //        z = 0;
            //    }
              
            //    document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
                
            //}
            //else {
            //    document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
            //}
        }
        function calculateBudget() {
            var totalAmount = 0;
            var grid = $find("<%=RadGridJobCopy.ClientID %>");
            var MasterTable = grid.get_masterTableView();
            var Rows = MasterTable.get_dataItems();
            var compNos = [];
            for (var i = 0; i < Rows.length; i++) {
                var row = Rows[i];   
                var bs = $(row.findElement('TextBoxSelectedBudget')).val().replace(',','');
                if (row.get_selected() === false && bs == 0) {
                    row.findControl('TextBoxSelectedBudget').set_value(0);
                }
            }
            for (var key in selected) {
                var item = selected[key];
                if (item) {
                    var dataItem;
                    var quantity = 0;
                    var budget = 0;
                    var budgetTotal = 0;
                    var budgetSelected = 0;
                    var budgetSelectedTotal = 0;
                    item.quantity = 0;
                    item.budget = 0;
                    item.budgetSelected = 0;
                    for (var i = 0; i < Rows.length; i++) {
                        var row = Rows[i];
                        if (row.getDataKeyValue('JOB_COMPONENT_NBR') === item.component) {
                            dataItem = row;
                            break;
                        }
                    }
                    if (dataItem) {
                        item.quantity = $(dataItem.findElement('TextBoxDuplicate')).val();
                        item.budget = dataItem.getDataKeyValue('JOB_COMP_BUDGET_AM');
                        item.budgetSelected = $(dataItem.findElement('TextBoxSelectedBudget')).val();
                    }
                    quantity = item.quantity;
                    budget = item.budget;
                    budgetSelected = item.budgetSelected.replace(',','');
                    if (isNaN(quantity) === true || quantity === '' || parseInt(quantity) <= 0) {
                        quantity = 1;
                    }
                    quantity = parseInt(quantity);
                    budget = parseFloat(budget);
                    budgetSelected = parseFloat(budgetSelected);
                    budgetTotal = quantity * budget;
                    budgetSelectedTotal = quantity * budgetSelected;
                    //budgetSelected = parseFloat(budgetSelected);
                    //console.log(budgetTotal);
                    //console.log(budgetSelectedTotal);
                    if (dataItem && budgetSelected == 0) {
                        dataItem.findControl('TextBoxSelectedBudget').set_value(budgetTotal);
                    } else {        
                        //dataItem.findControl('TextBoxSelectedBudget').set_value(budgetSelectedTotal);
                        budgetTotal = budgetSelectedTotal;
                    }
                    totalAmount += budgetTotal;
                }
            }
            document.getElementById('ctl00_ContentPlaceHolderMain_RadGridJobCopy_ctl00_ctl03_ctl00_TextBoxSumSelectedBudget').value = String.localeFormat("{0:n}", totalAmount);
         }
        function SumItUpBudget() {
                var x = 0;
                var y = 0;
                var s = 0;
                var temp = '';
                var JavascriptArrayBudget = new Array();
                <%= JavascriptArrayBudget%>
                for (x = 0; x < JavascriptArrayBudget.length; x++) {
                    temp = Number.parseLocale(JavascriptArrayBudget[x]);
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

                var grid = $find("<%=RadGridJobCopy.ClientID %>");
                //var totalAmount = 0;
                //if (grid) {
                //    var MasterTable = grid.get_masterTableView();
                //    var Rows = MasterTable.get_dataItems();
                //    for (var i = 0; i < Rows.length; i++) {
                //        var row = Rows[i];

                //        var txtQuntity = row.findControl("TextBoxSelectedBudget");
                //        var qty = txtQuntity.get_editValue();
                //        totalAmount = totalAmount + parseFloat(txtQuntity.get_textBoxValue().replace(",",""));

                //    }
                //}
                //document.getElementById('ctl00_ContentPlaceHolderMain_RadGridJobCopyComponent_ctl00_ctl03_ctl00_TextBoxSumSelectedBudget').value = String.localeFormat("{0:n}", totalAmount);
               
        }
        function RadGridJobCopyColumnPreferences(event) {
            var grid = $find("<%= RadGridJobCopy.ClientID%>");
            grid.get_masterTableView().get_columns()[0].showHeaderMenu(event, 10, 10);
        }        
        function enableButton() {
            var signInButton = $("#<%=btnCopyJob.ClientID %>");
            if (signInButton) {
                signInButton.prop("value", "Copy Job");
                signInButton.prop("disabled", false);
            }
        }
        $(document).ready(function () {
            $('body').on('change', 'tbody input[id*="ColumnClientSelectSelectCheckBox"]', function () {
                calculateBudget();
            }).on('change', 'thead input[id*="ColumnClientSelectSelectCheckBox"]', function () {
                calculateBudget();
            });
            var signInButton = $("#<%=btnCopyJob.ClientID %>");
            if (signInButton) {
                signInButton.click(function () {
                    signInButton.prop("value", "Please wait...");
                    signInButton.prop("disabled", true);                        
                })
            }             
            $("body").css("display", "none");
            $("body").fadeIn(750);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="margin: 20px 0px 0px 0px;">
            <table style="border: 0;">
                <tr>
                    <td id="TableCellCreate" runat="server" style="width: 700px; vertical-align:top;">
                        <ew:CollapsablePanel ID="CollapsablePanel2" runat="server" TitleText="Create Job" Collapsed="false">
                            <div class="code-description-container" style="">
                                <div class="code-description-label">
                                    Template:
                                </div>
                                <div class="code-description-description">
                                    <div id="TemplateWrapper">
                                        <telerik:RadComboBox ID="RadComboBoxJobTemplate" runat="server" AutoPostBack="True" CausesValidation="False" Width="270" SkinID="RadComboBoxStandard"
                                            TabIndex="1">
                                        </telerik:RadComboBox>
                                    </div>
                                    <span id="TemplateMessage">Template is copied from selected Job Component(s).</span>
                                </div>
                            </div>
                            <div id="DivOffice" runat="server" class="code-description-container">
                                <div class="code-description-label">
                                    <asp:LinkButton ID="HlOffice" runat="server" CausesValidation="False" TabIndex="-1">Office:</asp:LinkButton>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="TxtOffice" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" CssClass="RequiredInput"
                                        TabIndex="2"></asp:TextBox>
                                </div>
                                <div class="code-description-description">
                                    <asp:RequiredFieldValidator ID="RFVOffice" runat="server" ControlToValidate="TxtOffice"
                                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                        ErrorMessage="Office is required."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:LinkButton ID="hlClient" runat="server" CausesValidation="False" TabIndex="-1">Client:</asp:LinkButton>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="txtClient" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" CssClass="RequiredInput"
                                        TabIndex="3" Lookup="Client"></asp:TextBox>
                                </div>
                                <div class="code-description-description">
                                    <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtClient"
                                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                        ErrorMessage="Client is required."></asp:RequiredFieldValidator>
                                    <asp:Label ID="lblUniqueClient" runat="server" CssClass="required"></asp:Label>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:LinkButton ID="hlDivision" runat="server" CausesValidation="False" TabIndex="-1"> Division:</asp:LinkButton>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="txtDivision" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" CssClass="RequiredInput"
                                        TabIndex="4" Lookup="Division"></asp:TextBox>
                                </div>
                                <div class="code-description-description">
                                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="server" ControlToValidate="txtDivision"
                                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                        ErrorMessage="Division is required."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:LinkButton ID="hlProduct" runat="server" CausesValidation="False" TabIndex="-1">Product:</asp:LinkButton>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="txtProduct" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" CssClass="RequiredInput"
                                        TabIndex="5" Lookup="Product"></asp:TextBox>
                                </div>
                                <div class="code-description-description">
                                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" ControlToValidate="txtProduct"
                                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                        ErrorMessage="Product is required."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    Job Desc:
                                </div>
                                <div class="code-description-description">
                                    <asp:TextBox ID="txtJobDesc" runat="server" MaxLength="60" Width="250px" CssClass="RequiredInput" TabIndex="6" onfocus="dataChangeCheckRequirements()" SkinID="TextBoxStandard"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvJobDescription" runat="server" ControlToValidate="txtJobDesc"
                                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                        ErrorMessage="Job Desc  is required."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    Component Desc:
                                </div>
                                <div class="code-description-description">
                                    <asp:TextBox ID="txtCompDesc" runat="server" MaxLength="60" Width="250px" CssClass="RequiredInput" SkinID="TextBoxStandard"
                                        TabIndex="7"></asp:TextBox>
                                    <span id="MessageComp" runat="server" visible="false">From Copy</span>
                                    <asp:RequiredFieldValidator ID="rfvComponentDesc" runat="server" ControlToValidate="txtCompDesc"
                                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                        ErrorMessage="Component Desc is required."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:LinkButton ID="hlSalesClass" runat="server" CausesValidation="False" TabIndex="-1">Sales Class:</asp:LinkButton>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="txtSalesClass" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" CssClass="RequiredInput"
                                        TabIndex="9"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator3" runat="server" ControlToValidate="txtSalesClass"
                                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                        ErrorMessage="Sales class is required."></asp:RequiredFieldValidator>
                                </div>
                                <div class="code-description-description">
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:LinkButton ID="hlAE" runat="server" CausesValidation="False" TabIndex="-1">Account Exec:</asp:LinkButton>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="txtAE" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" CssClass="RequiredInput"
                                        TabIndex="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator4" runat="server" ControlToValidate="txtAE"
                                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                        ErrorMessage="Account Exec is required."></asp:RequiredFieldValidator>
                                </div>
                                <div class="code-description-description">
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:LinkButton ID="LinkButtonCampaign" runat="server" CausesValidation="False" TabIndex="-1">Campaign:</asp:LinkButton>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="txtCampaign" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall"
                                        TabIndex="11"></asp:TextBox>
                                    <asp:HiddenField runat="server" ID="hfCampaignID" />
                                </div>
                                <div class="code-description-description">
                                    <asp:RequiredFieldValidator ID="RequiredfieldvalidatorCampaign" runat="server" ControlToValidate="txtCampaign"
                                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="false"
                                        ErrorMessage="Campaign is required."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:HyperLink ID="HyperLinkJobType" runat="server" TabIndex="-1" href="">Job Type:</asp:HyperLink>
                                </div>
                                <div class="code-description-description">
                                    <asp:TextBox ID="TextBoxJobType" runat="server" MaxLength="10" TabIndex="12" Text=""
                                        SkinID="TextBoxCodeSmall"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorJobType" runat="server" ControlToValidate="TextBoxJobType"
                                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                        ErrorMessage="Job Type is required."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                </div>
                                <div class="code-description-description">
                                    <asp:CheckBox ID="CheckBoxCreateSchedule" runat="server" Text="Create Schedule" AutoPostBack="true" TabIndex="13" />
                                </div>
                            </div>
                            <div id="DivSchedule" runat="server">
                                <div class="code-description-container">
                                    <div class="code-description-label">
                                        <asp:Label ID="LabelStatus" runat="server" TabIndex="-1" Text="Status:"></asp:Label>
                                        <asp:HyperLink ID="HyperLinkStatus" runat="server" TabIndex="-1" href="">Status:</asp:HyperLink>
                                    </div>
                                    <div class="code-description-code">
                                        <asp:TextBox ID="TextBoxTrafficScheduleStatus" runat="server" MaxLength="10" SkinID="TextBoxCodeSmall" CssClass="RequiredInput"
                                            TabIndex="14"></asp:TextBox>
                                    </div>
                                    <div class="code-description-description">
                                    </div>
                                </div>
                                <div class="code-description-container">
                                    <div class="code-description-label">
                                        <asp:Label ID="LabelManager" runat="server" TabIndex="-1"></asp:Label>
                                        <asp:HyperLink ID="HyperLinkTrafficManager" runat="server" TabIndex="-1" href=""></asp:HyperLink>
                                    </div>
                                    <div class="code-description-code">
                                        <asp:TextBox ID="TextBoxTrafficManager" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" onkeyup="copyManager();"
                                            TabIndex="15"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredfieldvalidatorTrafficManager" runat="server" ControlToValidate="TextBoxTrafficManager"
                                            CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="false"
                                            ErrorMessage="Manager is required."></asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="code-description-description">
                                    </div>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                </div>
                                <div class="code-description-description">
                                    <asp:CheckBox ID="CheckBoxOverride" runat="server" Text="Override Component 1 Description" TabIndex="36" AutoPostBack="true" Visible="false" />
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                </div>
                                <div class="code-description-description">
                                    <asp:Button ID="butCreateJob" runat="server" Text="Create Job" CausesValidation="true" TabIndex="16" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="butCancel" runat="server" CausesValidation="False" Text="Cancel" TabIndex="17" />
                                </div>
                            </div>
                        </ew:CollapsablePanel>
                    </td>
                    <td id="TableCellBoards" runat="server" style="vertical-align:top;">
                        <ew:CollapsablePanel ID="CollapsablePanelBoards" runat="server" TitleText="Add To Board(s)" Collapsed="false">
                            <telerik:RadListBox ID="RadListBoxBoards" runat="server" ShowCheckAll="true" CheckBoxes="true" Width="360px" 
                                AllowDelete="false" AllowReorder="false" AllowTransfer="false" EnableDragAndDrop="false">
                            </telerik:RadListBox>
                        </ew:CollapsablePanel>
                    </td>
                </tr>
            </table>
        <h4>
            <asp:CheckBox ID="CheckBoxShowCopyFromExistingJob" runat="server" Style="vertical-align: top !important;" AutoPostBack="true" Text="Copy From Existing Job?" Visible="false" />
        </h4>                
        <ew:CollapsablePanel ID="CollapsablePanelHeader" runat="server" TitleText="Copy Job" Collapsed="true">
            <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
                <tr>
                    <td width="65%" style="vertical-align: top">
                        <div style="display: inline-block;" id="divCDP" runat="server">
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:HyperLink ID="HlClientSource" runat="server" TabIndex="-1" href="">Client:</asp:HyperLink>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="TxtClientSource" runat="server" MaxLength="6" TabIndex="18" Text="" SkinID="TextBoxCodeSmall" Lookup="Client"></asp:TextBox>
                                </div>
                                <div class="code-description-description">
                                    <asp:TextBox ID="TxtClientSourceDesc" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:HyperLink ID="HlDivisionSource" runat="server" TabIndex="-1" href="">Division:</asp:HyperLink>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="TxtDivisionSource" runat="server" MaxLength="6" TabIndex="19" Text="" SkinID="TextBoxCodeSmall" Lookup="Division"></asp:TextBox>
                                </div>
                                <div class="code-description-description">
                                    <asp:TextBox ID="TxtDivisionSourceDesc" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:HyperLink ID="HlProductSource" runat="server" href="" TabIndex="-1">Product:</asp:HyperLink>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="TxtProductSource" runat="server" MaxLength="6" TabIndex="20" Text="" SkinID="TextBoxCodeSmall" Lookup="Product"></asp:TextBox>
                                </div>
                                <div class="code-description-description">
                                    <asp:TextBox ID="TxtProductSourceDesc" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:HyperLink ID="HlJobTypeSource" runat="server" TabIndex="-1" href="">Job Type:</asp:HyperLink>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="TxtJobTypeSource" runat="server" MaxLength="6" TabIndex="21" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                </div>
                                <div class="code-description-description">
                                    <asp:TextBox ID="TxtJobTypeSourceDesc" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </div>
                            </div>
                            <div class="code-description-container" id="DivStatusFilter">
                                <div class="code-description-label">
                                    <asp:HyperLink ID="HyperLinkStatusFilter" runat="server" TabIndex="-1" href="" Text="Status:" ToolTip="Filter job lookup based on selected status"></asp:HyperLink>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="TextBoxStatusFilter" runat="server" MaxLength="10" TabIndex="33" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                </div>
                                <div class="code-description-description">
                                    <asp:TextBox ID="TextBoxStatusFilterDescription" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:HyperLink ID="HlJobSource" runat="server" TabIndex="-1" href="">Job:</asp:HyperLink>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="TxtJobSource" runat="server" MaxLength="6" TabIndex="22" Text="" SkinID="TextBoxCodeSmall" CssClass="RequiredInput" AutoPostBack="true"></asp:TextBox>
                                </div>
                                <div class="code-description-description">
                                    <asp:TextBox ID="TxtJobSourceDesc" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:Label ID="LabelSalesClassSource" runat="server" TabIndex="-1"></asp:Label>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="TxtSalesClassSource" runat="server" MaxLength="6" TabIndex="23" Text="" SkinID="TextBoxCodeSmall" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="code-description-description">
                                    <asp:TextBox ID="TxtSalesClassDescriptionSource" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    &nbsp;                           
                                </div>
                                <div class="code-description-code">
                                    <asp:CheckBox ID="cbShowClosed" runat="server" Text="Show Closed/Archived Jobs?" TabIndex="24" AutoPostBack="true" />
                                </div>
                                <div class="code-description-description">
                                    &nbsp; 
                                </div>
                            </div>
                            <div class="code-description-container" runat="server" id="DivCopyTrafficManager">
                                <div class="code-description-label">
                                    <asp:Label ID="LabelStatusCopy" runat="server" TabIndex="-1" Text="Status:"></asp:Label>
                                    <asp:HyperLink ID="hlStatusCopy" runat="server" TabIndex="-1" href="">Status:</asp:HyperLink>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="txtStatusCopy" runat="server" MaxLength="10" TabIndex="33" Text="" CssClass="RequiredInput" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                </div>
                                <div class="code-description-description">
                                    <asp:TextBox ID="txtStatusDescCopy" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </div>
                            </div>
                            <div class="code-description-container" runat="server" id="DivCopyJobProjectScheduleDate">
                                <div class="code-description-label">
                                    <asp:Label ID="LabelTrafficManager" runat="server" TabIndex="-1"></asp:Label>
                                    <asp:HyperLink ID="HyperLinkCopyTrafficManager" runat="server" TabIndex="-1" href="">Status:</asp:HyperLink>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="TextBoxCopyTrafficManager" runat="server" MaxLength="10" TabIndex="34" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                </div>
                                <div class="code-description-description">
                                    <%--<asp:RequiredFieldValidator ID="RequiredfieldvalidatorTextBoxCopyTrafficManager" runat="server" ControlToValidate="TextBoxCopyTrafficManager"
                                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="false"
                                        ErrorMessage="Manager is required."></asp:RequiredFieldValidator>--%>
                                    <asp:TextBox ID="TextBoxCopyTrafficManagerDescription" runat="server" ReadOnly="true" TabIndex="-1" Visible="false" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>&nbsp;
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    &nbsp;                           
                                </div>
                                <div class="code-description-code">                                            
                                    <asp:Button ID="btnCopyJob" runat="server" CausesValidation="true" Width="140" TabIndex="35" Text="Copy Job" UseSubmitBehavior="false" />&nbsp;
                                    <asp:Button ID="ButtonClearCopy" runat="server" CausesValidation="False" Width="140" TabIndex="35" Text="Clear Copy Job" />
                                </div>
                                <div class="code-description-description">
                                    &nbsp; 
                                </div>
                            </div>
                        </div>    
                    </td>
                    <td width="35%" style="vertical-align: top">
                        <div style="display: inline-block;">
                            <div class="code-description-container">
                                <div class="code-description-code">
                                    <asp:CheckBox ID="cbCopyCreativeBrief" runat="server" Text="Copy Creative Brief" TabIndex="26" />
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-code">
                                    <asp:CheckBox ID="cbCopySpecs" runat="server" Text="Copy Job Specifications" TabIndex="27" />
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-code">
                                    <asp:CheckBox ID="cbCopyDestinations" runat="server" Text="Copy Destinations" Enabled="false" TabIndex="28" />
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-code">
                                    <asp:CheckBox ID="CheckBoxJobDocumentAssociations" runat="server" Text="Copy Job Document Associations" TabIndex="30" />
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-code">
                                    <asp:CheckBox ID="CheckBoxJobCompDocumentAssociations" runat="server" Text="Copy Job Component Document Associations" TabIndex="31" />
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-code">
                                    <asp:CheckBox ID="cbCopyProjectSchedule" runat="server" Text="Copy Project Schedule" AutoPostBack="true" TabIndex="29" />
                                </div>
                            </div>
                            <div class="code-description-container" runat="server" id="DivCopyJobProjectScheduleStatus">
                                <div class="code-description-code" style="padding-left: 15px">
                                    <asp:CheckBoxList ID="CheckBoxListCopyOptions" runat="server" RepeatDirection="Vertical" Style="border-spacing: 0; padding: 0; margin: 0;" TabIndex="32"></asp:CheckBoxList>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>    
            <telerik:RadGrid ID="RadGridJobCopy" runat="server" AllowMultiRowSelection="True" AllowSorting="true" AutoGenerateColumns="False" EnableAJAX="False" GridLines="None" Width="90%"
                                            EnableHeaderContextMenu="true" AllowFilteringByColumn="true" ShowFooter="True">
                <GroupingSettings CaseSensitive="false" />
                        <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                        <ClientSettings EnablePostBackOnRowClick="false">
                            <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" UseClientSelectColumnOnly="True" />
                            <ClientEvents OnRowSelected="GridOnRowSelected" OnRowDeselected="GridOnRowDeselected" OnRowCreated="GridOnRowCreated" OnGridCreated="GridOnGridCreated" OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR,JOB_COMP_BUDGET_AM" ClientDataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR,JOB_COMP_BUDGET_AM">
                            <Columns>                                        
                                <telerik:GridTemplateColumn AllowFiltering="False" HeaderAbbr="FIXED" UniqueName="colPref">
                                    <HeaderTemplate>
                                        <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                            ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="RadGridJobCopyColumnPreferences(event);"
                                                CausesValidation="false" />
                                    </HeaderTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect" HeaderAbbr="FIXED">
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" />
                                </telerik:GridClientSelectColumn>
                                <telerik:GridTemplateColumn AllowFiltering="False" HeaderAbbr="FIXED" UniqueName="colTextBoxDuplicate" HeaderText="QTY">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBoxDuplicate" runat="server" SkinID="TextBoxText3"></asp:TextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="JT_CODE" HeaderText="Job Type Code" UniqueName="JobTypeCode" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false" FilterControlWidth="50" DataType="System.String" FilterControlToolTip="Filter by Job Type Code">
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="JT_DESC" HeaderText="Job Type Desc" UniqueName="JobTypeDesc" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false" DataType="System.String" FilterControlToolTip="Filter by Job Type Description">
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="JOB_COMPONENT_NBR" HeaderText="Component" UniqueName="Component" CurrentFilterFunction="EqualTo" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false" FilterControlWidth="50" DataType="System.Int16" FilterControlToolTip="Filter by Component">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn DataField="JOB_COMP_DESC" HeaderText="Description" UniqueName="Description" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false" DataType="System.String"  FilterControlToolTip="Filter by Component Description">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                    <ItemStyle />
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBoxJobComponentDescription" runat="server" Text='<%# Eval("JOB_COMP_DESC")%>' MaxLength="60"></asp:TextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="" UniqueName="colComp" Visible="false">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hfJob" runat="server" Value='<%# Eval("JOB_NUMBER") %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="JOB_COMP_BUDGET_AM" HeaderText="Comp Budget" UniqueName="CompBudget" CurrentFilterFunction="EqualTo" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false" FilterControlWidth="100" DataFormatString="{0:#,##0.00}" DataType="System.Decimal" FilterControlToolTip="Filter by Budget">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="middle" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="middle"/>
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="CompSelectedBudget" HeaderText="Comp Budget Selected">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="middle" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="middle"/>
                                    <ItemTemplate>
                                        <telerik:RadNumericTextBox ID="TextBoxSelectedBudget" runat="server" Width="90px" Value="0.00"></telerik:RadNumericTextBox>
                                    </ItemTemplate>                                            
                                    <FooterTemplate>
                                        <asp:TextBox ID="TextBoxSumSelectedBudget" runat="server" Width="90px" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <ExpandCollapseColumn Visible="False">
                                <HeaderStyle Width="19px" />
                            </ExpandCollapseColumn>
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                        </MasterTableView>
                    </telerik:RadGrid>
        </ew:CollapsablePanel>
    </div>
    <div style="display: none;">
        <asp:Button ID="btnComps" runat="server" CausesValidation="false"/>
    </div>
<telerik:RadScriptBlock ID="rcbfooter" runat="server">
    <script>

        $('body').on('change', 'input', function () {
            var lookupType = $(this).attr('lookup');
            var clearDivision = false,
                clearProduct = false,
                clearJob = false,
                clearCampaign = false;
            if (lookupType === 'Client') {
                clearDivision = true;
                clearProduct = true;
                clearJob = true;
                clearCampaign = true;
            }
            if (lookupType === 'Division') {
                clearDivision = false;
                clearProduct = true;
                clearJob = true;
                clearCampaign = true;
            }
            if (lookupType === 'Product') {
                clearDivision = false;
                clearProduct = false;
                clearJob = true;
                clearCampaign = true;
            }
            if (clearDivision === true) {
                $('#' + this.id.replace(lookupType, "Division")).val('');
                $('#' + this.id.replace(lookupType, "Division") + 'Desc').val('');
            }
            if (clearProduct === true) {
                $('#' + this.id.replace(lookupType, "Product")).val('');
                $('#' + this.id.replace(lookupType, "Product") + 'Desc').val('');
            }
            if (clearJob === true) {
                $('#' + this.id.replace(lookupType, "Job")).val('');
                $('#' + this.id.replace(lookupType, "Job") + 'Desc').val('');
            }
        });

        function lookupComplete(control) {
            var element = $('#' + control);
            if (element) {
                if (element.prop('Lookup') !== '') {
                    element.change();
                }
            }
        }

    </script>
</telerik:RadScriptBlock>

</asp:Content>
