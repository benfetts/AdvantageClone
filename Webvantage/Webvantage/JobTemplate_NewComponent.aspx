<%@ Page AutoEventWireup="false" CodeBehind="JobTemplate_NewComponent.aspx.vb" Inherits="Webvantage.jobtemplate_newcomponent"
    Title="New Job Component" Language="vb" MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript">
        function copytext() {
            document.getElementById("ctl00_ContentPlaceHolderMain_txtCompDesc").value = document.getElementById("ctl00_ContentPlaceHolderMain_txtJobDesc").value;
        }
        var scrollPosition;
        function RadAjaxPanelOnRequestStart(sender, args) {
            scrollPosition = $(window).scrollTop();
        }
        function RadAjaxPanelOnResponseEnd(sender, args) {
            if (scrollPosition) {
                $(window).scrollTop(scrollPosition);
                scrollPosition = null;
            }
        }
        var selected = {};
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
        function checkAllowTemplate() {
            var compGrid = $find('<%= RadGridJobCopyComponent.ClientID %>');
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
            var grid = $find("<%=RadGridJobCopyComponent.ClientID %>");
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
                    var dataItem2;
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
                        } else {
                            dataItem = dataItem2
                        }
                    }
                    if (dataItem) {
                        item.quantity = $(dataItem.findElement('TextBoxDuplicate')).val();
                        item.budget = dataItem.getDataKeyValue('JOB_COMP_BUDGET_AM');
                        item.budgetSelected = $(dataItem.findElement('TextBoxSelectedBudget')).val();
                    } else {
                        //item.quantity = 0
                        //item.budget = 0
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
                    if (dataItem && budgetSelected == 0) {
                        dataItem.findControl('TextBoxSelectedBudget').set_value(budgetTotal);
                    } else {        
                        //dataItem.findControl('TextBoxSelectedBudget').set_value(budgetSelectedTotal);
                        budgetTotal = budgetSelectedTotal;
                    }
                    totalAmount += budgetTotal;
                }
            }
            var jobbudget = parseFloat(document.getElementById('ctl00_ContentPlaceHolderMain_LabelBudget').innerHTML.replace(",", ""));
            document.getElementById('ctl00_ContentPlaceHolderMain_RadGridJobCopyComponent_ctl00_ctl03_ctl00_TextBoxSumSelectedBudget').value = String.localeFormat("{0:n}", totalAmount);
            document.getElementById('ctl00_ContentPlaceHolderMain_LabelSelectedBudget').innerHTML = String.localeFormat("{0:n}", totalAmount);
            document.getElementById('ctl00_ContentPlaceHolderMain_LabelProjectedBudget').innerHTML = String.localeFormat("{0:n}", totalAmount + jobbudget);
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

                var grid = $find("<%=RadGridJobCopyComponent.ClientID %>");
                //var totalAmount = 0;
                //if (grid) {
                //    var MasterTable = grid.get_masterTableView();
                //    var Rows = MasterTable.get_dataItems();
                //    for (var i = 0; i < Rows.length; i++) {
                //        var row = Rows[i];
                //        if (row.get_selected() === true) {
                //            var txtQuntity = row.findControl("TextBoxSelectedBudget");
                //            var qty = txtQuntity.get_editValue();
                //            var qty = txtQuntity.get_textBoxValue();
                //            totalAmount = totalAmount + parseFloat(txtQuntity.get_textBoxValue().replace(",", ""));
                //        }
                //    }
                //}
                //var jobbudget = parseFloat(document.getElementById('ctl00_ContentPlaceHolderMain_LabelBudget').innerHTML.replace(",", ""));
                //document.getElementById('ctl00_ContentPlaceHolderMain_RadGridJobCopyComponent_ctl00_ctl03_ctl00_TextBoxSumSelectedBudget').value = String.localeFormat("{0:n}", totalAmount);
                //document.getElementById('ctl00_ContentPlaceHolderMain_LabelSelectedBudget').innerHTML = String.localeFormat("{0:n}", totalAmount);
                //document.getElementById('ctl00_ContentPlaceHolderMain_LabelProjectedBudget').innerHTML = String.localeFormat("{0:n}", totalAmount + jobbudget);
               
        }
        function RadGridJobCopyColumnPreferences(event) {

            var grid = $find("<%= RadGridJobCopyComponent.ClientID%>");

            grid.get_masterTableView().get_columns()[0].showHeaderMenu(event, 10, 10);

        }

        function stopRKey(evt) {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type == "text")) {
                return false;
                //evt.keyCode = 9;
            }
        }

        function CopyCompPanelOnClientToggle(id, expanded) {
            var disabled = false;
            if (expanded === true) {
                disabled = $('#<%= TxtJobSource.ClientID %>').val() !== ''? true : false;
            }
            $('#<%= BtnSaveComponent.ClientID %>').prop('disabled', disabled);
        }

        document.onkeypress = stopRKey;
        
        $(document).ready(function () {

            $('body').on('change', 'tbody input[id*="ColumnClientSelectSelectCheckBox"]', function () {
                calculateBudget();
            }).on('change', 'thead input[id*="ColumnClientSelectSelectCheckBox"]', function () {
                calculateBudget();
            });

        });
        
            function enableButton() {
                var signInButton = $("#<%=btnCopyJob.ClientID %>");
                if (signInButton) {
                    signInButton.prop("value", "Copy Components");
                    signInButton.prop("disabled", false);
                }
            }
            $(document).ready(function () {
                var signInButton = $("#<%=btnCopyJob.ClientID %>");
                if (signInButton) {
                    signInButton.click(function () {
                        signInButton.prop("value", "Please wait...");
                        signInButton.prop("disabled", true);
                        
                    })
                }
                //try {
                //    var oWindow = null;
                //    if (window.radWindow) {
                //        oWindow = window.radWindow;
                //    }
                //    else if (window.frameElement.radWindow) {
                //        oWindow = window.frameElement.radWindow;
                //    }
                //    if (oWindow == undefined) {
                //        var iFrame = window.frameElement;
                //        oWindow = window.parent.frameElement.radWindow;
                //    }
                //    if (oWindow) {
                //        window.top.location.href = "jobtemplate_newcomponent.aspx";
                //    }
                //} catch (e) {
                //}

                $("body").css("display", "none");
                $("body").fadeIn(750);

            });
    </script>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain" EnableViewState="true">          
        <div style="margin: 20px 0px 0px 0px;">
            <table style="border: 0;">
                <tr>
                    <td id="TableCellCreate" runat="server" style="width: 700px; vertical-align:top;">
                        <ew:CollapsablePanel ID="CollapsablePanel2" runat="server" TitleText="Create Job Component" Collapsed="false">
                            <div class="code-description-container">
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
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:Label ID="LabelClient" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="txtClient" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" ReadOnly="true"
                                        TabIndex="3" Lookup="Client"></asp:TextBox>
                                </div>
                                <div class="code-description-description">
                                    <asp:TextBox ID="TextBoxClientDescription" runat="server" ReadOnly="true" TabIndex="-1" 
                                       Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:Label ID="LabelDivision" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="txtDivision" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" ReadOnly="true"
                                        TabIndex="4" Lookup="Division"></asp:TextBox>
                                </div>
                                <div class="code-description-description">
                                    <asp:TextBox ID="TextBoxDivisionDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                       Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:Label ID="LabelProduct" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="txtProduct" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" ReadOnly="true"
                                        TabIndex="5" Lookup="Product"></asp:TextBox>
                                </div>
                                <div class="code-description-description">
                                    <asp:TextBox ID="TextBoxProductDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                       Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:Label ID="LabelJob" runat="server" Text="Job:" TabIndex="-1"></asp:Label> 
                                    <asp:LinkButton ID="lbJob" runat="server" CausesValidation="False" TabIndex="-1" Visible="false">Job:</asp:LinkButton>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="TxtJobNum" runat="server" MaxLength="60" SkinID="TextBoxCodeSmall"
                                        TabIndex="6" Lookup="Job"></asp:TextBox>
                                </div>
                                <div class="code-description-description">
                                    <asp:TextBox ID="TextBoxJobDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                       Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    Component Desc:
                                </div>
                                <div class="code-description-description">
                                    <asp:TextBox ID="txtCompDesc" runat="server" MaxLength="60" Width="250px" CssClass="RequiredInput" SkinID="TextBoxStandard"></asp:TextBox>
                                    <span id="MessageComp" runat="server" visible="false">From Copy</span>
                                    <asp:RequiredFieldValidator ID="rfvComponentDesc" runat="server" ControlToValidate="txtCompDesc"
                                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                        ErrorMessage="Component Desc is required."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:Label ID="LabelSalesClass" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="TextBoxSalesClass" runat="server" MaxLength="60" SkinID="TextBoxCodeSmall" ReadOnly="true"
                                        TabIndex="6"></asp:TextBox>
                                </div>
                                <div class="code-description-description">
                                    <asp:TextBox ID="TextBoxSalesClassDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                       Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    <asp:LinkButton ID="hlAE" runat="server" CausesValidation="False">Account Exec:</asp:LinkButton>
                                </div>
                                <div class="code-description-code">
                                    <asp:TextBox ID="txtAE" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" CssClass="RequiredInput"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator4" runat="server" ControlToValidate="txtAE"
                                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                        ErrorMessage="Account Exec is required."></asp:RequiredFieldValidator>
                                </div>
                                <div class="code-description-description">
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
                                    <asp:CheckBox ID="CheckBoxCreateSchedule" runat="server" Text="Create Schedule" AutoPostBack="true" />
                                </div>
                            </div>
                            <div id="DivSchedule" runat="server">
                                <div class="code-description-container">
                                    <div class="code-description-label">
                                        <asp:Label ID="LabelStatus" runat="server" TabIndex="-1" Text="Status:"></asp:Label>
                                        <asp:HyperLink ID="HyperLinkStatus" runat="server" TabIndex="-1" href="">Status:</asp:HyperLink>
                                    </div>
                                    <div class="code-description-code">
                                        <asp:TextBox ID="TextBoxTrafficScheduleStatus" runat="server" MaxLength="10" Width="100px" CssClass="RequiredInput" SkinID="TextBoxStandard"
                                            TabIndex="9"></asp:TextBox>
                                    </div>
                                    <div class="code-description-description">
                                    </div>
                                </div>
                                <div class="code-description-container">
                                    <div class="code-description-label">
                                        <asp:Label ID="LabelManager" runat="server" TabIndex="-1"></asp:Label>
                                        <asp:HyperLink ID="HyperLinkTrafficManager" runat="server" TabIndex="-1" href="" Text="Manager"></asp:HyperLink>
                                    </div>
                                    <div class="code-description-code">
                                        <asp:TextBox ID="TextBoxTrafficManager" runat="server" MaxLength="6" Width="100px" SkinID="TextBoxStandard"
                                            TabIndex="9"></asp:TextBox>
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
                                    <asp:CheckBox ID="CheckBoxOverride" runat="server" Text="Override First Component Description" TabIndex="36" AutoPostBack="true" Visible="false" />
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                </div>
                                <div class="code-description-description">
                                    <asp:Button ID="BtnSaveComponent" runat="server" Text="Create Component" />
                                    &nbsp;
                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CausesValidation="false" />
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
                <asp:CheckBox ID="CheckBoxShowCopyFromExistingJob" runat="server" Style="vertical-align: top !important;"
                    AutoPostBack="true" Visible="false" />               
            </h4>
            <ew:CollapsablePanel ID="CollapsablePanelHeader" runat="server" TitleText="Copy Job Component" Collapsed="true" OnClientToggle="CopyCompPanelOnClientToggle" >
                    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
                        <tr>
                            <td width="68%" style="vertical-align: top">
                                <div style="display: inline-block;" id="divCDP" runat="server">
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                            <asp:HyperLink ID="HlClientSource" runat="server" href="" TabIndex="-1">Client:</asp:HyperLink>
                                        </div>
                                        <div class="code-description-code">
                                            <asp:TextBox ID="TxtClientSource" runat="server" MaxLength="6" TabIndex="20" Text="" SkinID="TextBoxCodeSmall"  Lookup="Client"></asp:TextBox>
                                        </div>
                                        <div class="code-description-description">
                                            <asp:TextBox ID="TxtClientSourceDesc" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                            <asp:HyperLink ID="HlDivisionSource" runat="server" href="" TabIndex="-1">Division:</asp:HyperLink>
                                        </div>
                                        <div class="code-description-code">
                                            <asp:TextBox ID="TxtDivisionSource" runat="server" MaxLength="6" TabIndex="21" Text="" SkinID="TextBoxCodeSmall"  Lookup="Division"></asp:TextBox>
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
                                            <asp:TextBox ID="TxtProductSource" runat="server" MaxLength="6" TabIndex="22" Text="" SkinID="TextBoxCodeSmall" Lookup="Product"></asp:TextBox>
                                        </div>
                                        <div class="code-description-description">
                                            <asp:TextBox ID="TxtProductSourceDesc" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                            <asp:HyperLink ID="HlJobTypeSource" runat="server" href="" TabIndex="-1">Job Type:</asp:HyperLink>
                                        </div>
                                        <div class="code-description-code">
                                            <asp:TextBox ID="TxtJobTypeSource" runat="server" MaxLength="6" TabIndex="23" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                        </div>
                                        <div class="code-description-description">
                                            <asp:TextBox ID="TxtJobTypeSourceDesc" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                            <asp:HyperLink ID="HlJobSource" runat="server" href="" TabIndex="-1">Job:</asp:HyperLink>
                                        </div>
                                        <div class="code-description-code">
                                            <asp:TextBox ID="TxtJobSource" runat="server" MaxLength="6" TabIndex="24" Text="" SkinID="TextBoxCodeSmall" CssClass="RequiredInput" AutoPostBack="true" Lookup="Job"></asp:TextBox>
                                        </div>
                                        <div class="code-description-description">
                                            <asp:TextBox ID="TxtJobSourceDesc" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                            &nbsp;                           
                                        </div>
                                        <div class="code-description-description">
                                            <asp:CheckBox ID="cbShowClosed" runat="server" Text="Show Closed/Archived Jobs?" AutoPostBack="true" />
                                        </div>
                                    </div>
                                    <div class="code-description-container" runat="server" id="DivCopyTrafficManager">
                                        <div class="code-description-label">
                                             <asp:Label ID="LabelStatusCopy" runat="server" CssClass="HideMe" TabIndex="-1" Text="Status:"></asp:Label>
                                            <asp:HyperLink ID="hlStatusCopy" runat="server" href="" TabIndex="-1"><span>Status:</span></asp:HyperLink>
                                        </div>
                                        <div class="code-description-code">
                                            <asp:TextBox ID="txtStatusCopy" runat="server" MaxLength="10" TabIndex="23" Text="" SkinID="TextBoxCodeSmall" CssClass="RequiredInput"></asp:TextBox>
                                        </div>
                                        <div class="code-description-description">
                                            <asp:TextBox ID="txtStatusDescCopy" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="code-description-container" runat="server" id="DivCopyJobProjectScheduleDate">
                                        <div class="code-description-label">
                                               <asp:Label ID="LabelTrafficManager" runat="server" CssClass="HideMe" TabIndex="-1"></asp:Label>
                                            <asp:HyperLink ID="HyperLinkCopyTrafficManager" runat="server" TabIndex="-1" href="">Status:</asp:HyperLink>
                                        </div>
                                        <div class="code-description-code">
                                            <asp:TextBox ID="TextBoxCopyTrafficManager" runat="server" MaxLength="10" TabIndex="23" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                        </div>
                                        <div class="code-description-description">
                                            <asp:RequiredFieldValidator ID="RequiredfieldvalidatorTextBoxCopyTrafficManager" runat="server" ControlToValidate="TextBoxCopyTrafficManager"
                                                CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="false"
                                                ErrorMessage="Manager is required."></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="TextBoxCopyTrafficManagerDescription" runat="server" ReadOnly="true" TabIndex="-1" Visible="false" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>&nbsp;
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                            &nbsp;                           
                                        </div>
                                        <div class="code-description-code">                                            
                                            <asp:Button ID="btnCopyJob" runat="server" CausesValidation="False" TabIndex="17" Text="Copy Components" UseSubmitBehavior="false" />&nbsp;
                                            <asp:Button ID="ButtonClearCopy" runat="server" CausesValidation="False" Width="140" TabIndex="35" Text="Clear Copy Job" />
                                        </div>
                                        <div class="code-description-description">
                                            &nbsp; 
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                            <asp:Label ID="LabelJobBudget" runat="server" Text="Current Job Budget:"></asp:Label>              
                                        </div>
                                        <div class="code-description-code">
                                            <asp:Label ID="LabelBudget" runat="server" Text=""></asp:Label>
                                            <asp:Label ID="LabelSelectedJobBudget" runat="server" Text="Selected Job Budget:" style="margin-left: 20px; margin-right:6px;"></asp:Label >
                                            <asp:Label ID="LabelSelectedBudget" runat="server" Text=""></asp:Label>
                                            <asp:Label ID="LabelProjectedJobBudget" runat="server" Text="Projected Job Budget:" style="margin-left: 20px; margin-right:6px;"></asp:Label >
                                            <asp:Label ID="LabelProjectedBudget" runat="server" Text=""></asp:Label>               
                                        </div>
                                        <div class="code-description-description">
                                            &nbsp; 
                                        </div>  
                                    </div>
                                </div>    
                            </td>
                            <td width="32%" style="vertical-align: top">
                                <div style="display: inline-block;">
                                    <div class="code-description-container">
                                        <div class="code-description-code">
                                            <asp:CheckBox ID="cbCopyCreativeBrief" runat="server" Text="Copy Creative Brief" TabIndex="40" />
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-code">
                                            <asp:CheckBox ID="cbCopySpecs" runat="server" Text="Copy Job Specifications" TabIndex="41" />
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-code">
                                            <asp:CheckBox ID="cbCopyDestinations" runat="server" Text="Copy Destinations" Enabled="false" TabIndex="42" />
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-code">
                                            <asp:CheckBox ID="CheckBoxJobCompDocumentAssociations" runat="server" Text="Copy Job Component Document Associations" TabIndex="43" />
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-code">
                                            <asp:CheckBox ID="cbCopyProjectSchedule" runat="server" Text="Copy Project Schedule" AutoPostBack="true" TabIndex="44" />
                                        </div>
                                    </div>
                                    <div class="code-description-container" runat="server" id="DivCopyJobProjectScheduleStatus">
                                        <div class="code-description-code" style="padding-left: 15px">
                                            <asp:CheckBoxList ID="CheckBoxListCopyOptions" runat="server" RepeatDirection="Vertical" TabIndex="45"></asp:CheckBoxList>
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <%--<tr>                            
                            <td colspan="2">
                                <div class="code-description-container" runat="server">
                                    <div class="code-description-code">
                                        
                                        
                                    </div>
                                </div>
                            </td>
                        </tr>--%>
                    </table>    
                    <telerik:RadGrid ID="RadGridJobCopyComponent" runat="server" AllowMultiRowSelection="True" AllowSorting="true" AutoGenerateColumns="False" EnableAJAX="False" GridLines="None" Width="90%"
                                                    EnableHeaderContextMenu="true" AllowFilteringByColumn="true" ShowFooter="True">
                                <GroupingSettings CaseSensitive="false" />
                                <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                                <ClientSettings EnablePostBackOnRowClick="false" >
                                    <Selecting AllowRowSelect="true" EnableDragToSelectRows="True" UseClientSelectColumnOnly="True" />
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
                                                <%--<telerik:RadNumericTextBox ID="TextBoxDuplicate" runat="server" SkinID="TextBoxText3"></telerik:RadNumericTextBox>--%>
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
                                        <%--<telerik:GridBoundColumn DataField="JOB_COMP_DESC" HeaderText="Description" UniqueName="Description" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false" DataType="System.String"  FilterControlToolTip="Filter by Component Description">
                                            <HeaderStyle HorizontalAlign="left" />
                                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                            <FooterStyle HorizontalAlign="Right" VerticalAlign="middle"/>
                                        </telerik:GridBoundColumn>--%>
                                        <telerik:GridTemplateColumn DataField="JOB_COMP_DESC" HeaderText="Description" UniqueName="Description" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false" DataType="System.String"  FilterControlToolTip="Filter by Component Description">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle />
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxJobComponentDescription" runat="server" Text='<%# Eval("JOB_COMP_DESC")%>' MaxLength="60" SkinID="TextBoxStandard"></asp:TextBox>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="colComp" Visible="false">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfJob" runat="server" Value='<%# Eval("JOB_NUMBER") %>' />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="JOB_COMP_BUDGET_AM" HeaderText="Comp Budget" UniqueName="CompBudget" CurrentFilterFunction="EqualTo" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false" FilterControlWidth="100" DataFormatString="{0:#,##0.00}"  DataType="System.Decimal" FilterControlToolTip="Filter by Budget">
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="middle" />
                                            <FooterStyle HorizontalAlign="Right" VerticalAlign="middle"/>
                                        </telerik:GridBoundColumn>
                                        <%--<telerik:GridBoundColumn DataField="SELECTED" HeaderText="Comp Budget Selected" UniqueName="colCompBudgetSelected" AllowFiltering="False" AutoPostBackOnFilter="false" DataFormatString="{0:#,##0.00}">
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="middle" />
                                            <FooterStyle HorizontalAlign="Right" VerticalAlign="middle"/>
                                        </telerik:GridBoundColumn>--%>
                                        <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="CompSelectedBudget" HeaderText="Comp Budget Selected">
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="middle" />
                                            <FooterStyle HorizontalAlign="Right" VerticalAlign="middle"/>
                                            <ItemTemplate>
                                                <%--<asp:TextBox ID="TextBoxSelectedBudget" runat="server" SkinID="TextBoxCodeSmall" AutoPostBack="true" ReadOnly="true"></asp:TextBox>--%>
                                                <telerik:RadNumericTextBox ID="TextBoxSelectedBudget" runat="server" Width="90px" Value="0.00"></telerik:RadNumericTextBox>
                                            </ItemTemplate>                                            
                                            <FooterTemplate>
                                                <%--<asp:TextBox ID="TextBoxSumSelectedBudget" runat="server" Width="90px" ReadOnly="true"></asp:TextBox>--%>
                                                <telerik:RadNumericTextBox ID="TextBoxSumSelectedBudget" runat="server" Width="90px" ReadOnly="true" TabIndex="-1"></telerik:RadNumericTextBox>
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
        
    <telerik:RadScriptBlock ID="RcbFooter" runat="server">
        <script>

            $('body').on('change', 'input', function () {
                var lookupType = $(this).attr('lookup');
                var clearDivision = false,
                    clearProduct = false,
                    clearJob = false,
                    clearCampaign = false,
                    clearClientName = false;
                if (lookupType === 'Client') {
                    clearClientName = true;
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
                if (clearClientName === true) {
                    $('#' + this.id.replace(lookupType, "Client") + 'Desc').val('');
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
