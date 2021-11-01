<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="purchaseorder_dtl.aspx.vb" Inherits="Webvantage.purchaseorder_dtl"
    Title="Purchase Order Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <script src="Jscripts/po-functions.js" type="text/javascript"></script>

    <link rel="stylesheet" href="Content/kendo/current/kendo.common.min.css" />
    <link rel="stylesheet" href="Content/kendo/current/kendo.bootstrap.min.css" />
    <link href="Content/bootstrap.css" rel="stylesheet" />

    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="Scripts/angular.min.js"></script>
    <script type="text/javascript" src="Scripts/angular-ui/ui-bootstrap-tpls.min.js"></script>
    <script type="text/javascript" src="Scripts/kendo/current/kendo.all.min.js"></script>
    <script type="text/javascript" src="app/js/app.js"></script>
    <script type="text/javascript" src="app/js/services.js"></script>
    <script type="text/javascript" src="app/js/controllers/purchaseOrderLookup.js"></script>
    <script type="text/javascript" src="app/js/controllers/kendoGridLookupModal.js"></script>

    <telerik:RadCodeBlock ID="rcbHeader" runat="server">

         <script type="text/javascript">

            function getConfirmOverride(msg) {
                var ans;

                if ($('#<%= RadNumericTextBoxExtendedAmount.ClientID%>').val() != '') {

                    ans = window.confirm(msg + '\n Allow Save anyway?');
                    if (ans == true) {
                        $('#confirm_override_flg').val('1');
                    }
                    else {
                        $('#confirm_override_flg').val('0');
                    }
                }
            }


            function getEstimateAlert(msg) {

                if ($('#<%= RadNumericTextBoxExtendedAmount.ClientID%>').val() != '') {
                    ShowMessage(msg + '\n Cannot save P.O. line.');
                }
            }

            function realPostBack(eventTarget, eventArgument) {
                __doPostBack(eventTarget, eventArgument);
            }

         </script>
        <script type="text/javascript">

            function SpecsDesc(radWindowCaller) {
                __doPostBack('onclick#SpecsDesc', 'SpecsDesc');
            }
            function SpecsInstruct(radWindowCaller) {
                __doPostBack('onclick#SpecsInstruct', 'SpecsInstruct');
            }
            function SpecsDescEst(radWindowCaller) {
                __doPostBack('onclick#SpecsDescEst', 'SpecsDescEst');
            }
            function SpecsInstructEst(radWindowCaller) {
                __doPostBack('onclick#SpecsInstructEst', 'SpecsInstructEst');
            }
            function OnClientClose(oWnd) {
                //__doPostBack('onclick#Refresh','Refresh');
            }
        </script>
        <script type="text/javascript">
            function RadToolbar_OnClientButtonClicking(sender, args) {
                if (args.get_item().get_commandName() == 'Save') {
                    document.getElementById('<%= HiddenFieldSaving.ClientID%>').value = "1";
                } else if (args.get_item().get_commandName() == 'Estimate') {
                    args.set_cancel(true);
                    var jobNumber = $('input[adv-lookup=Job]').val();
                    var jobCompNumber = $('input[adv-lookup=JobComponent]').val();
                    if (jobNumber && jobCompNumber) {
                        $find('<%= RadButtonLoadEstimateData.ClientID%>').click();
                    } else {
                        ShowMessage('To view the approved Estimate components, you must enter a Job and Component Number first.');
                    }
                } else if (args.get_item().get_commandName() == 'ClearJob') {
                    args.set_cancel(true);
                    var jobLookup;
                    $('input[adv-lookup]').each(function () {
                        var type = $(this).attr('adv-lookup');
                        if (type === 'Client' || type === 'Division' || type === 'Product' || type === 'Job' || type === 'JobComponent') {
                            $(this).val(null);
                            $('input[adv-desc=' + type + ']').val(null);
                        }
                        if (type === 'Job') {
                            jobLookup = $(this);
                        }
                    });
                    if (jobLookup) {
                        $(jobLookup).focus();
                    }
                }
            }
            function RadToolbar_Load(sender, args) {
                document.getElementById('<%= HiddenFieldSaving.ClientID%>').value = "0";
            }
            function RadAjaxPanelOnResponseEnd(sender, args) {
                var target = args.get_eventTarget();
                var openWindow = false;
                if (target.indexOf('RadButtonLoadEstimateData') > -1) {
                    var radGrid = $find('<%= RadGridEstimateInfo.ClientID%>');
                    var dataItems;
                    try{
                        dataItems = radGrid.get_masterTableView().get_dataItems();
                    } catch (err) {
                        dataItems = {};
                    }
                    if (dataItems.length > 0) {
                        var estimateWindow = $('#estimateWindow').data('kendoWindow')
                        var width = $(document.body).outerWidth();
                        if (width > 1300) {
                            width = 1300;
                        }
                        width = width - 100;
                        estimateWindow.setOptions({
                            width: width + 'px'
                        });
                        estimateWindow.center().open();
                    } else {
                        ShowMessage('No approved estimates were found for Job Component ' + $('input[adv-lookup=Job]').val() + '-' + $('input[adv-lookup=JobComponent]').val() + '.');
                    }
                }
            }
        </script>

        <style type="text/css">
            div[id*=divCPM]{
                display: none;
            }
        </style>

    </telerik:RadCodeBlock>
    
    <asp:HiddenField ID="HiddenFieldSaving" runat="server" Value="0" />
<div>
    <telerik:RadToolBar ID="RadToolbarPurchseOrderDetail" runat="server" AutoPostBack="True"
        Width="100%" OnClientButtonClicking="RadToolbar_OnClientButtonClicking" OnClientLoad="RadToolbar_Load">
        <Items>
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="" CausesValidation="true" Value="Save" CommandName="Save" Hidden="False" ToolTip="Save this Purchase Order" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonClear" Text="Clear Job" Value="ClearJob" CommandName="ClearJob" ToolTip="Clear Job" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton Text="Use Estimate" Value="Estimate" CommandName="Estimate" ToolTip="Use Estimate" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton Text="Vendor Prices" Value="Vendor" CommandName="Vendor" ToolTip="Vendor Prices" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh" CommandName="Refresh" ToolTip="Refresh" />
            <telerik:RadToolBarButton IsSeparator="true" />
        </Items>
    </telerik:RadToolBar>
</div>
    
    <div style="margin-top: 10px;">
        <div style="float:left;">
            <div class="form-layout">
                <ul>
                    <li>PO Number:</li>
                    <li><asp:TextBox ID="TextBoxPODisplayNumber" runat="server" SkinID="TextBoxCodeSmall" ReadOnly="True" Enabled="false"></asp:TextBox></li>
                    <li><asp:TextBox ID="TextBoxDescription" runat="server" SkinID="TextBoxText40" ReadOnly="true" Enabled="false"></asp:TextBox></li>
                </ul>
                <ul>
                    <li>Issued By:</li>
                    <li><asp:TextBox ID="TextBoxEmployeeCode" runat="server" SkinID="TextBoxCodeSmall" ReadOnly="True" Enabled="false" ClientIDMode="Static"></asp:TextBox></li>
                    <li><asp:TextBox ID="TextBoxEmployeeName" runat="server" SkinID="TextBoxText40" ReadOnly="True" Enabled="false"></asp:TextBox></li>
                </ul>
                <ul>
                    <li>Issued To:</li>
                    <li><asp:TextBox ID="TextBoxVendorCode" runat="server" SkinID="TextBoxCodeSmall" ReadOnly="True" Enabled="false"></asp:TextBox></li>
                    <li><asp:TextBox ID="TextBoxVendorName" runat="server" SkinID="TextBoxText40" ReadOnly="True" Enabled="false"></asp:TextBox></li>
                </ul>
            </div>
        </div>
        <div style="float:left;">
            <div class="form-layout">
                <ul>
                    <li>Date Issued:</li>
                    <li><asp:Label ID="LabelDateIssued" runat="server" /></li>
                </ul>
                <ul>
                    <li>Due Date:</li>
                    <li><asp:Label ID="LabelDueDate" runat="server" /></li>
                </ul>
                <ul>
                    <li>PO Total:</li>
                    <li><asp:Label ID="LabelPOTotal" runat="server" /></li>
                </ul>
            </div>
        </div>
    </div>
    <div style="clear: both;"></div>

<div id="dtlScope" ng-app="webvantageApp" ng-controller="purchaseOrderLookupController">
    <div>
        <div class="sub-header sub-header-color">
            Line
        </div>
        <div class="form-layout" style="margin-top: 10px;">
            <ul runat="server" ID="ulLineNumber">
                <li>Line Number:</li>
                <li><asp:Label ID="LabelLineNumber" runat="server" /></li>
            </ul>
            <ul>
                <li>Description:</li>
                <li><asp:TextBox ID="TextBoxLineDescription" runat="server" MaxLength="40" Width="392px" TabIndex="1" SkinID="TextBoxStandard"></asp:TextBox></li>
            </ul>
            <ul>
                <li>Detail Description:</li>
                <li><asp:TextBox ID="TextBoxDetailDescription" runat="server" Height="57px" MaxLength="9000" Rows="10" TextMode="MultiLine" Width="605px" TabIndex="2" SkinID="TextBoxStandard"></asp:TextBox></li>
                <li><asp:ImageButton ID="ImageButtonEstimateDetailDescription" runat="server" SkinID="ImageButtonInsert" ToolTip="Insert Estimate Comments" /><br />
                    <asp:ImageButton ID="ImageButtonSpecsDetailDescription" runat="server" ImageUrl="~/Images/form_red-trans.png" ToolTip="Insert Specifications" /></li>
            </ul>
            <ul>
                <li>Detail Instruction:</li>
                <li><asp:TextBox ID="TextBoxInstructions" runat="server" Height="57px" MaxLength="9000" Rows="10" TextMode="MultiLine" Width="605px" TabIndex="3" SkinID="TextBoxStandard"></asp:TextBox></li>
                <li><asp:ImageButton ID="ImageButtonEstimateInstructions" runat="server" SkinID="ImageButtonInsert" ToolTip="Insert Estimate Comments" /><br />
                    <asp:ImageButton ID="ImageButtonSpecsInstructions" runat="server" ImageUrl="~/Images/form_red-trans.png" ToolTip="Insert Specifications" /></li>
            </ul>
        </div>
    </div>
    <div>
        <div class="sub-header sub-header-color">
            Job Component
        </div>
        <div class="form-layout" style="margin-top: 10px;">
            <ul>
                <li><asp:HyperLink ID="HyperLinkClient" runat="server" href="">Client:</asp:HyperLink></li>
                <li><asp:TextBox ID="TextBoxClientCode" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" TabIndex="3"></asp:TextBox></li>
                <li><asp:TextBox ID="TextBoxClientName" runat="server" SkinID="TextBoxCodeSingleLineDescription" ReadOnly="true"></asp:TextBox></li>
            </ul>
            <ul>
                <li><asp:HyperLink ID="HyperLinkDivision" runat="server" href="">Division:</asp:HyperLink></li>
                <li><asp:TextBox ID="TextBoxDivisionCode" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" TabIndex="4"></asp:TextBox></li>
                <li><asp:TextBox ID="TextBoxDivisionName" runat="server" SkinID="TextBoxCodeSingleLineDescription" ReadOnly="true"></asp:TextBox></li>
            </ul>
            <ul>
                <li><asp:HyperLink ID="HyperLinkProduct" runat="server" href="">Product:</asp:HyperLink></li>
                <li><asp:TextBox ID="TextBoxProductCode" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" TabIndex="5"></asp:TextBox></li>
                <li><asp:TextBox ID="TextBoxProductName" runat="server" SkinID="TextBoxCodeSingleLineDescription" ReadOnly="true"></asp:TextBox></li>
            </ul>
            <ul>
                <li><asp:HyperLink ID="HyperLinkJob" runat="server" href="">Job Number:</asp:HyperLink></li>
                <li><asp:TextBox ID="TextBoxJobNumber" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" TabIndex="6"></asp:TextBox></li>
                <li><asp:TextBox ID="TextBoxJobDescription" runat="server" SkinID="TextBoxCodeSingleLineDescription" ReadOnly="true"></asp:TextBox></li>
            </ul>
            <ul>
                <li><asp:HyperLink ID="HyperLinkJobComponent" runat="server" href="">Component:</asp:HyperLink></li>
                <li><asp:TextBox ID="TextBoxJobComponentNumber" runat="server" SkinID="TextBoxCodeSmall" TabIndex="7"></asp:TextBox></li>
                <li><asp:TextBox ID="TextBoxJobComponentDescription" runat="server" SkinID="TextBoxCodeSingleLineDescription" ReadOnly="true"></asp:TextBox></li>
            </ul>
            <div>
                <asp:Label ID="LabelJobValidationMessage" runat="server" CssClass="warning" Width="100%"></asp:Label>
            </div>
            <ul>
                <li><asp:HyperLink ID="HyperLinkFunction" runat="server" href="">Function:</asp:HyperLink></li>
                <li><asp:TextBox ID="TextBoxFunctionCode" runat="server" SkinID="TextBoxCodeSmall" TabIndex="8"></asp:TextBox></li>
                <li><asp:TextBox ID="TextBoxFunctionDescription" runat="server" MaxLength="100" SkinID="TextBoxCodeSingleLineDescription" ReadOnly="True" TabIndex="-1"></asp:TextBox></li>
                <li style="margin-left: 10px;">CPM:</li>
                <li><div id="divCPM" runat="server" class="icon-background standard-green">
                        <asp:Image ID="ImageCPM" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                    </div></li>
            </ul>
            <div>
                <asp:Label ID="LabelFunctionValidationMessage" runat="server" CssClass="warning" Width="100%"></asp:Label>
            </div>
            <div id="divEstimate" runat="server" style="display: none;">
            </div>
            <ul id="ulGLAccount" runat="server">
                <li><asp:HyperLink ID="HyperLinkGLAccount" runat="server" href="">GL Account:</asp:HyperLink></li>
                <li><asp:TextBox ID="TextBoxGLAccountCode" runat="server" SkinID="TextBoxCodeSmall" TabIndex="9"></asp:TextBox></li>
                <li><asp:TextBox ID="TextBoxGLAccountDescription" runat="server" MaxLength="100" SkinID="TextBoxCodeSingleLineDescription" ReadOnly="True" TabIndex="-1"></asp:TextBox></li>
            </ul>
            <asp:Label ID="lbl_msg4" runat="server" CssClass="warning" Width="100%"></asp:Label>
        </div>
    </div>
    <div>
        <div class="sub-header sub-header-color">
            Quantity and Price Information
        </div>
        <div style="margin-top: 10px;">
            <div style="float:left; margin-right: 20px;">
                <div class="form-layout" style="margin-top: 10px;">
                    <ul>
                        <li>Quantity:</li>
                        <li><telerik:RadNumericTextBox ID="RadNumericTextBoxQuantity" runat="server" SkinID="RadNumericTextBoxAmount" EnabledStyle-HorizontalAlign="Right" adv-calc="Quantity" TabIndex="10" IncrementSettings-InterceptMouseWheel="False">
                                <NumberFormat DecimalDigits="0" />
                                <ClientEvents OnKeyPress="RadNumericTextBoxPreventDecimal" />
                            </telerik:RadNumericTextBox></li>
                    </ul>
                    <ul>
                        <li>Rate:</li>
                        <li><telerik:RadNumericTextBox ID="RadNumericTextBoxRate" runat="server" SkinID="RadNumericTextBoxAmount" EnabledStyle-HorizontalAlign="Right" adv-calc="Rate" TabIndex="11" IncrementSettings-InterceptMouseWheel="False">
                                <NumberFormat DecimalDigits="4" KeepTrailingZerosOnFocus="true" />
                                <ClientEvents OnKeyPress="RadNumericTextBoxPreventDecimal" />
                            </telerik:RadNumericTextBox></li>
                    </ul>
                    <ul>
                        <li>Amount:</li>
                        <li><telerik:RadNumericTextBox ID="RadNumericTextBoxExtendedAmount" runat="server" SkinID="RadNumericTextBoxAmount" EnabledStyle-HorizontalAlign="Right" adv-calc="ExtendedAmount" TabIndex="11" IncrementSettings-InterceptMouseWheel="False">
                                <NumberFormat DecimalDigits="2" KeepTrailingZerosOnFocus="true" />
                                <ClientEvents OnKeyPress="RadNumericTextBoxPreventDecimal" />
                            </telerik:RadNumericTextBox></li>
                    </ul>
                </div>
            </div>
            <div style="float:left;">
                <div class="form-layout" style="margin-top: 10px;">
                    <ul>
                        <li>Markup %:</li>
                        <li><telerik:RadNumericTextBox ID="RadNumericTextBoxMarkupPercent" runat="server" SkinID="RadNumericTextBoxAmount" ReadOnly="true" EnabledStyle-HorizontalAlign="Right" adv-calc="CommissionPercent">
                                <NumberFormat DecimalDigits="3" KeepTrailingZerosOnFocus="true" />
                            </telerik:RadNumericTextBox></li>
                    </ul>
                    <ul>
                        <li>Markup Amount:</li>
                        <li><telerik:RadNumericTextBox ID="RadNumericTextBoxMarkupAmount" runat="server" SkinID="RadNumericTextBoxAmount" ReadOnly="true" EnabledStyle-HorizontalAlign="Right" adv-calc="ExtendedMarkupAmount">
                                <NumberFormat DecimalDigits="2" KeepTrailingZerosOnFocus="true" />
                            </telerik:RadNumericTextBox></li>
                    </ul>
                    <ul>
                        <li>Line Total:</li>
                        <li><telerik:RadNumericTextBox ID="RadNumericTextBoxLineTotal" runat="server" SkinID="RadNumericTextBoxAmount" ReadOnly="true" EnabledStyle-HorizontalAlign="Right" adv-calc="LineTotal">
                                <NumberFormat DecimalDigits="2" KeepTrailingZerosOnFocus="true" />
                            </telerik:RadNumericTextBox></li>
                    </ul>
                    <ul>
                        <li>Attached to AP:</li>
                        <li><asp:CheckBox ID="CheckBoxAttachedToAP" runat="server" Enabled="False" Width="106px" /></li>
                    </ul>
                </div>
            </div>
            <div style="clear: both;"></div>
        </div>
    </div>
    
    <asp:HiddenField ID="HiddenFieldSecMod" runat="server" ClientIDMode="Static" /> <!-- needed for lookups -->

</div>

    <div id="estimateWindow">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <div>
            <telerik:RadGrid ID="RadGridEstimateInfo" runat="server" AutoGenerateColumns="false" AllowPaging="false" AllowSorting="false"
                ShowFooter="false" ShowGroupPanel="false" GridLines="None" Width="100%" AllowMultiRowSelection="false">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                <ClientSettings>
                    <Scrolling FrozenColumnsCount="2" />
                    <Selecting AllowRowSelect="true" />
                    <ClientEvents OnRowSelected="RadGridOnRowSelected" OnGridCreated="RadGridOnGridCreated" OnRowDblClick="RadGridOnRowDblClick" />
                </ClientSettings>
                <MasterTableView CommandItemDisplay="None" AllowSorting="false" DataKeyNames="" Width="100%" ClientDataKeyNames="Quantity, Rate, ExtendedAmount, MarkupPercent, MarkupAmount, FunctionCode, Function">
                    <ColumnGroups>
                        <telerik:GridColumnGroup HeaderText="Markup" Name="MarkupGroup"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup HeaderText="Tax Amount" Name="TaxGroup"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup HeaderText="Contingency" Name="ContingencyGroup"></telerik:GridColumnGroup>
                    </ColumnGroups>
                    <Columns>
                        <telerik:GridBoundColumn DataField="Function" HeaderText="Function" />
                        <telerik:GridBoundColumn DataField="QuoteNumber" HeaderText="Quote #" ItemStyle-HorizontalAlign="Right" />
                        <telerik:GridBoundColumn DataField="Rate" HeaderText="Rate" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N4}" />
                        <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" />
                        <telerik:GridBoundColumn DataField="ExtendedAmount" HeaderText="Total" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" />
                        <telerik:GridBoundColumn DataField="VendorName" HeaderText="Vendor" UniqueName="GridBoundColumnVendor" />
                        <telerik:GridBoundColumn DataField="MarkupPercent" HeaderText="Percent" ColumnGroupName="MarkupGroup" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N3}" />
                        <telerik:GridBoundColumn DataField="MarkupAmount" HeaderText="Amount" ColumnGroupName="MarkupGroup" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" />
                        <telerik:GridBoundColumn DataField="CountyTaxAmount" HeaderText="County" ColumnGroupName="TaxGroup" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" />
                        <telerik:GridBoundColumn DataField="CityTaxAmount" HeaderText="City" ColumnGroupName="TaxGroup" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" />
                        <telerik:GridBoundColumn DataField="ContingencyAmount" HeaderText="Amount" ColumnGroupName="ContingencyGroup" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" />
                        <telerik:GridBoundColumn DataField="ContingencyMarkupAmount" HeaderText="Markup" ColumnGroupName="ContingencyGroup" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" />
                        <telerik:GridBoundColumn DataField="ContingencyStateAmount" HeaderText="State" ColumnGroupName="ContingencyGroup" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" />
                        <telerik:GridBoundColumn DataField="ContingencyCountyAmount" HeaderText="County" ColumnGroupName="ContingencyGroup" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" />
                        <telerik:GridBoundColumn DataField="ContingencyCityAmount" HeaderText="City" ColumnGroupName="ContingencyGroup" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" />
                        <telerik:GridBoundColumn DataField="ContingencyNonResaleAmount" HeaderText="Non Resale" ColumnGroupName="ContingencyGroup" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" />
                        <telerik:GridBoundColumn DataField="ContingencyTotalAmount" HeaderText="Total" ColumnGroupName="ContingencyGroup" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" />
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
            <div style="display:none">
                <!-- trigger -->
                <telerik:RadButton ID="RadButtonLoadEstimateData" runat="server" AutoPostBack="true"></telerik:RadButton>
            </div>
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        <div style="margin-top: 10px; margin-bottom: 10px;">
            <div style="float:right;">
                <button id="selectEstimateButton" class="k-primary">Select</button>
                <button id="cancelEstimateButton" class="k-primary">Cancel</button>
            </div>
            <div style="clear: both;"></div>
        </div>
        
    </div>

<asp:Label ID="LabelPOValidationMessage" runat="server" CssClass="warning" Width="100%"></asp:Label>

    <input type="text" id="confirm_override_flg" value="2" runat="server" maxlength="1" size="1" style="display: none" />

    <telerik:RadCodeBlock ID="RCBfooter" runat="server">
        
        <script type="text/javascript">

            function RadNumericTextBoxPreventDecimal(sender, args) {
                var keyCode = args.get_keyCode();
                var cancel = false;
                var decimalDigits = sender.get_numberFormat().DecimalDigits;
                if (decimalDigits === 0) {
                    if (keyCode == 46 || keyCode == 110) {
                        cancel = true;
                    }
                } else {
                    var caretPos = sender.get_caretPosition();
                    var inputVal = sender.get_textBoxValue();
                    var decLoc = inputVal.indexOf('.');
                    if (decLoc > -1) {
                        if ((caretPos - decLoc) > decimalDigits) {
                            if (keyCode != 46 && keyCode != 110) {
                                cancel = true;
                            }
                        }
                    }
                }
                args.set_cancel(cancel);
            }

            var RadGridOnRowSelected = function (sender, args) {
                checkRadGridRowSelection();
            };
            var RadGridOnGridCreated = function (sender, args) {
                checkRadGridRowSelection();
            };
            var RadGridOnRowDblClick = function (sender, args) {
                $('#estimateWindow').data('kendoWindow').close();
            }
            var checkRadGridRowSelection = function () {
                var radGrid = $find('<%= RadGridEstimateInfo.ClientID%>');
                var selectButton = $('#selectEstimateButton').data('kendoButton');
                if (radGrid.get_selectedItems().length > 0) {
                    selectedEstimateItem = radGrid.get_selectedItems()[0];
                    selectButton.enable(true);
                } else {
                    selectButton.enable(false);
                }
            };

            var selectedEstimateItem;

            $(document).ready(function () {

                /*
                estimate window
                */
                $('#selectEstimateButton').kendoButton({
                    enable: false,
                    click: function (e) {
                        $('#estimateWindow').data('kendoWindow').close();
                    }
                });
                $('#cancelEstimateButton').kendoButton({
                    click: function (e) {
                        selectedEstimateItem = null;
                        $('#estimateWindow').data('kendoWindow').close();
                    }
                });
                $('#estimateWindow').kendoWindow({
                    animation: false,
                    open: function (e) {
                        
                    },
                    title: 'Existing Estimate Functions',
                    visible: false,
                    close: function () {
                        var Quantity, Rate, ExtendedAmount, MarkupPercent, MarkupAmount, FunctionCode, FunctionDesc;
                        if (selectedEstimateItem) {
                            Quantity = selectedEstimateItem.getDataKeyValue('Quantity');
                            Rate = selectedEstimateItem.getDataKeyValue('Rate');
                            ExtendedAmount = selectedEstimateItem.getDataKeyValue('ExtendedAmount');
                            MarkupPercent = selectedEstimateItem.getDataKeyValue('MarkupPercent');
                            MarkupAmount = selectedEstimateItem.getDataKeyValue('MarkupAmount');
                            FunctionCode = selectedEstimateItem.getDataKeyValue('FunctionCode');
                            FunctionDesc = selectedEstimateItem.getDataKeyValue('Function');
                            var currentScope = getCurrentScope($('[adv-lookup=Job]'));
                            currentScope.setQuantity(null);
                            currentScope.setRate(null);
                            currentScope.setAmount(null);
                            currentScope.setQuantity(Quantity);
                            currentScope.setRate(Rate);
                            currentScope.setAmount(ExtendedAmount);
                            currentScope.setCommissionPercent(MarkupPercent);
                            currentScope.setCommissionAmount(MarkupAmount);
                            currentScope.setFunctionCode(FunctionCode);
                            currentScope.setFunctionDescription(FunctionDesc);
                        }
                    }
                });


                /*
                lookups
                */
                var getCurrentScope = function (element) {
                    return angular.element(element).scope();
                };

                getCurrentScope($('input[adv-lookup=Client]')).parentRow = $('#dtlScope');
                
                $('a[adv-lookup]').on('click', function () {
                    var currentScope = getCurrentScope($(this));
                    var type = $(this).attr('adv-lookup');
                    currentScope.open(type);
                });
                $('input[adv-lookup]').on('focus', function () {
                    getCurrentScope($(this)).parentRow = $('#dtlScope');
                });
                $('input[adv-lookup]').on('dblclick', function () {
                    if ($(this).is(":enabled")) {
                        var currentScope = getCurrentScope($(this));
                        currentScope.openFilterDialog($(this));
                    }
                });
                $('input[adv-lookup]').on('change', function () {
                    var currentScope = getCurrentScope($(this))
                    var newVal = null;
                    var lookupType = $(this).attr('adv-lookup');
                    var jobComponent = {};
                    newVal = currentScope.getInputValue(lookupType);
                    if (lookupType === 'Client' || lookupType === 'Division' || lookupType === 'Product' || lookupType === 'Job' || lookupType === 'JobComponent') {
                        JobComponent = currentScope.getSearchCriteria().JobComponent
                        if (lookupType === 'Client') {
                            JobComponent.DivisionCode = null;
                            JobComponent.ProductCode = null;
                            JobComponent.JobNumber = null;
                            JobComponent.JobComponentNumber = null;
                        } else if (lookupType === 'Division') {
                            JobComponent.ProductCode = null;
                            JobComponent.JobNumber = null;
                            JobComponent.JobComponentNumber = null;
                        } else if (lookupType === 'Product') {
                            JobComponent.JobNumber = null;
                        } else if (lookupType === 'Job') {
                            JobComponent.JobComponentNumber = null;
                        }
                        currentScope.jobComponentValuesChanged(JobComponent, newVal);
                    }
                    if (lookupType === 'Function') {
                        currentScope.functionValuesChanged(currentScope.getSearchCriteria().Function, newVal);
                    }
                    if (lookupType === 'GeneralLedgerAccount') {
                        currentScope.generalLedgerAccountValuesChanged(currentScope.getSearchCriteria().GeneralLedgerAccount, newVal);
                    }
                    if (lookupType === 'Employee') {
                        currentScope.employeeValuesChanged(currentScope.getSearchCriteria().GeneralLedgerAccount, newVal);
                    }
                    if (lookupType === 'Vendor') {
                        currentScope.vendorValuesChanged(currentScope.getSearchCriteria().Vendor, newVal);
                    }
                    if (lookupType === 'VendorContact') {
                        currentScope.vendorContactValuesChanged(currentScope.getSearchCriteria().VendorContact, newVal);
                    }
                });
                $('input[adv-calc]').on('focus', function () {
                    getCurrentScope($(this)).parentRow = $('#dtlScope');
                });
                $('input[adv-calc]').each(function () {
                    var radInput = $find($(this).attr('id'));
                    if (radInput) {
                        radInput.add_valueChanged(function (sender, args) {
                            var element = sender.get_element();
                            var changed = $(element).attr('adv-calc');
                            getCurrentScope(element).quantityRateAmountChanged(changed);
                        });
                    }
                });

            });
            
        </script>

    </telerik:RadCodeBlock>

</asp:Content>
