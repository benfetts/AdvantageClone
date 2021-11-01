<%@ Page AutoEventWireup="false" CodeBehind="PurchaseOrder_CopyWizard.aspx.vb" Inherits="Webvantage.PurchaseOrder_CopyWizard" 
    Language="vb"MasterPageFile="~/ChildPage.Master" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style type="text/css">
        .RadUploadProgressAreaVisible {
            visibility: visible !important;
            width: auto !important;
            height: auto !important;
        }
    </style>
    <telerik:RadScriptBlock ID="RadScriptBlockMain" runat="server">
    </telerik:RadScriptBlock>
    
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="Scripts/angular.min.js"></script>
    <script type="text/javascript" src="Scripts/angular-ui/ui-bootstrap-tpls.min.js"></script>
    <script type="text/javascript" src="Scripts/kendo/current/kendo.all.min.js"></script>
    <script type="text/javascript" src="app/js/app.js"></script>
    <script type="text/javascript" src="app/js/services.js"></script>
    <script type="text/javascript" src="app/js/controllers/purchaseOrderLookup.js"></script>
    <script type="text/javascript" src="app/js/controllers/kendoGridLookupModal.js"></script>
    
    <script type="text/javascript">

        var getCurrentScope = function (element) {
            return angular.element(element).scope();
        };

        var onGridCreated = function (sender, args) {
            var radGrid = sender;
            if (radGrid) {
                var masterTableView = radGrid.get_masterTableView();
                if (masterTableView) {
                    $('tbody > tr.rgEditRow').each(function (i) {
                        var cssClass = 'rgRow';
                        if (i % 2) {
                            cssClass = 'rgAltRow';
                        }
                        $(this).removeClass('rgEditRow').addClass(cssClass);
                    });
                }
            }
        };

        function RadNumericTextBoxPreventDecimal(sender, args) {
            var keyCode = args.get_keyCode();
            if (keyCode == 46 || keyCode == 110) {
                args.set_cancel(true);
            }
        }

        (function () {
            $('body')
                .on('click', 'a[adv-lookup]', function () {
                    var currentScope = getCurrentScope($(this));
                    var input, cancel;
                    var type = $(this).attr('adv-lookup');
                    input = currentScope.getInput(type);
                    if (input) {
                        if ($(input).attr('disabled') === 'disabled') {
                            cancel = true;
                        }
                    } else {
                        cancel = true;
                    }
                    if (!cancel) {
                        currentScope.open(type);
                    }
                })
                .on('dblclick', 'input[adv-lookup]', function () {
                    if ($(this).is(":enabled")) {
                        getCurrentScope($(this)).openFilterDialog($(this));
                    }
                })
                .on('change', 'input[adv-lookup]', function () {
                    var currentScope = getCurrentScope($(this))
                    var newVal = null;
                    var lookupType = $(this).attr('adv-lookup');
                    var jobComponent = {};
                    newVal = currentScope.getInputValue(lookupType);
                    if (lookupType === 'Client' || lookupType === 'Division' || lookupType === 'Product' || lookupType === 'Job' || lookupType === 'JobComponent') {
                        JobComponent = currentScope.getSearchCriteria().JobComponent
                        if (lookupType === 'Client') {
                            JobComponent.ClientName = null;
                            JobComponent.DivisionCode = null;
                            JobComponent.DivisionName = null;
                            JobComponent.ProductCode = null;
                            JobComponent.ProductName = null;
                            JobComponent.JobNumber = null;
                            JobComponent.JobDescription = null;
                            JobComponent.JobComponentNumber = null;
                            JobComponent.JobComponentDescription = null;
                        } else if (lookupType === 'Division') {
                            JobComponent.DivisionName = null;
                            JobComponent.ProductCode = null;
                            JobComponent.ProductName = null;
                            JobComponent.JobNumber = null;
                            JobComponent.JobDescription = null;
                            JobComponent.JobComponentNumber = null;
                            JobComponent.JobComponentDescription = null;
                        } else if (lookupType === 'Product') {
                            JobComponent.ProductName = null;
                            JobComponent.JobNumber = null;
                            JobComponent.JobDescription = null;
                            JobComponent.JobComponentNumber = null;
                            JobComponent.JobComponentDescription = null;
                        } else if (lookupType === 'Job') {
                            JobComponent.JobDescription = null;
                            JobComponent.JobComponentNumber = null;
                            JobComponent.JobComponentDescription = null;
                        } else if (lookupType === 'JobComponent') {
                            JobComponent.JobComponentDescription = null;
                        }
                        currentScope.jobComponentValuesChanged(JobComponent, newVal);
                    }
                    if (lookupType === 'Function') {
                        currentScope.functionValuesChanged(currentScope.getSearchCriteria().Function, newVal);
                    }
                    if (lookupType === 'GeneralLedgerAccount') {
                        currentScope.glAccountValuesChanged(currentScope.getSearchCriteria().GeneralLedgerAccount, newVal);
                    }
                    if (lookupType === 'Employee') {
                        currentScope.employeeValuesChanged(currentScope.getSearchCriteria().Employee, newVal);
                    }
                    if (lookupType === 'Vendor') {
                        currentScope.vendorValuesChanged(currentScope.getSearchCriteria().Vendor, newVal);
                    }
                    if (lookupType === 'VendorContact') {
                        currentScope.vendorContactValuesChanged(currentScope.getSearchCriteria().VendorContact, newVal);
                    }
                })
                .on('focus', 'input[adv-calc]', function () {
                    getCurrentScope($(this)).parentRow = $(this).closest('tr');
                })
                .on('focus', '.RadGrid input[adv-lookup]', function () {
                    getCurrentScope($(this)).parentRow = $(this).closest('tr');
                });
        })();

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div>
        <telerik:RadWizard ID="RadWizardPurchaseOrderCopy" runat="server" RenderedSteps="Active" DisplayProgressBar="false" DisplayNavigationBar="false">
            <WizardSteps>
                <telerik:RadWizardStep ID="RadWizardStepSelectPO" runat="server" Title="Select Purchase Order" StepType="Start">
                    <div>
                        <h3 style="display:block; border-bottom: 1px solid black; padding-bottom: 10px;">Select Purchase Order</h3>
                        <telerik:RadGrid ID="RadGridPurchaseOrders" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10"
                            ShowFooter="false" ShowGroupPanel="false" GridLines="None" AllowFilteringByColumn="true">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                            <ClientSettings AllowKeyboardNavigation="true">
                                <Selecting AllowRowSelect="true" />
                                <Scrolling AllowScroll="false" />
                                <ClientEvents OnRowDblClick="OnRowDblClick" />
                            </ClientSettings>
                            <MasterTableView DataKeyNames="Number" CommandItemDisplay="None" AllowSorting="true">
                                <Columns>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnNumber" HeaderText="Number" ItemStyle-HorizontalAlign="Center" DataField="DisplayPONumber" FilterControlWidth="80px">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDescription" HeaderText="Description" DataField="Description" FilterControlWidth="120px"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnIssuedBy" HeaderText="Issued By" DataField="EmployeeCode" FilterControlWidth="80px"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnIssuedTo" HeaderText="Issued To" DataField="VendorCode" FilterControlWidth="80px"></telerik:GridBoundColumn>
                                    <telerik:GridDateTimeColumn UniqueName="GridDateTimeColumnDate" HeaderText="Date" DataField="PODate" DataType="System.DateTime" DataFormatString="{0:d}" FilterControlWidth="120px"></telerik:GridDateTimeColumn>
                                    <telerik:GridDateTimeColumn UniqueName="GridDateTimeColumnDueDate" HeaderText="Due Date" DataField="PODueDate" DataType="System.DateTime" DataFormatString="{0:d}" FilterControlWidth="120px"></telerik:GridDateTimeColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIsVoid" HeaderText="Is Void" DataField="IsVoid" DataType="System.Int16" FilterControlWidth="100%" ShowFilterIcon="false">
                                        <FilterTemplate >
                                            <telerik:RadComboBox ID="RadComboBoxIsVoidFilter" runat="server" Width="70px" OnClientSelectedIndexChanged="VoidFilterChanged">
                                                <Items>
                                                    <telerik:RadComboBoxItem Value="" Text="" />
                                                    <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                                    <telerik:RadComboBoxItem Value="0" Text="No" />
                                                </Items>
                                            </telerik:RadComboBox>
                                            <telerik:RadScriptBlock ID="RadScripBlockIsVoidFilter" runat="server">
                                                <script type="text/javascript">
                                                    function VoidFilterChanged(sender, args) {
                                                        var gridView = $find("<%# CType(Container, Telerik.Web.UI.GridItem).OwnerTableView.ClientID %>");
                                                        var value = args.get_item().get_value();
                                                        try {
                                                            gridView.filter("GridTemplateColumnIsVoid", value, Telerik.Web.UI.GridFilterFunction.EqualTo);
                                                        } catch (Err) {
                                                        }
                                                    }
                                                </script>
                                            </telerik:RadScriptBlock>
                                        </FilterTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background standard-green" style='<%# If(Eval("IsVoid") = 1, "display:block;", "display:none;")%>'>
                                                <asp:Image ID="ImageIsVoid" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIsComplete" HeaderText="Is Complete" DataField="IsComplete" DataType="System.Int16" ShowFilterIcon="false">
                                        <FilterTemplate >
                                            <telerik:RadComboBox ID="RadComboBoxIsCompleteFilter" runat="server" Width="70px" OnClientSelectedIndexChanged="CompleteFilterChanged">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="" />
                                                    <telerik:RadComboBoxItem Value="1" Text="Yes" />
                                                    <telerik:RadComboBoxItem Value="0" Text="No" />
                                                </Items>
                                            </telerik:RadComboBox>
                                            <telerik:RadScriptBlock ID="RadScripBlockCompleteFilter" runat="server">
                                                <script type="text/javascript">
                                                    function CompleteFilterChanged(sender, args) {
                                                        var gridView = $find("<%# CType(Container, Telerik.Web.UI.GridItem).OwnerTableView.ClientID %>");
                                                        var value = args.get_item().get_value();
                                                        try {
                                                            gridView.filter("GridTemplateColumnIsComplete", value, Telerik.Web.UI.GridFilterFunction.EqualTo);
                                                        } catch (Err) {
                                                        }
                                                    }
                                                </script>
                                            </telerik:RadScriptBlock>
                                        </FilterTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background standard-green" style='<%# If(Eval("IsComplete") = 1, "display:inline-block;", "display:none;")%>'>
                                                <asp:Image ID="ImageIsComplete" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </telerik:RadWizardStep>
                <telerik:RadWizardStep ID="RadWizardStepSelectPODetails" runat="server" Title="Select Purchase Order Detail(s)" StepType="Step">
                    <div>
                        <h3 style="display:block; border-bottom: 1px solid black; padding-bottom: 10px;">Select Purchase Order Detail(s)</h3>
                        <telerik:RadGrid ID="RadGridSelectPODetails" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10"
                             ShowFooter="false" ShowGroupPanel="false" GridLines="None" AllowMultiRowSelection="true" AllowMultiRowEdit="true">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                            <ClientSettings AllowKeyboardNavigation="true">
                                <Selecting AllowRowSelect="true" />
                                <ClientEvents OnRowDblClick="OnRowDblClick" />
                            </ClientSettings>
                            <MasterTableView DataKeyNames="LineNumber" CommandItemDisplay="None" AllowSorting="true">
                                <Columns>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnLineNumber" HeaderText="Line<br/>Number" DataField="LineNumber" ItemStyle-HorizontalAlign="Right" ReadOnly="true"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDescription" HeaderText="Description" DataField="LineDescription"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnClientCode" HeaderText="Client" DataField="ClientCode"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDivisionCode" HeaderText="Division" DataField="DivisionCode"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnProductCode" HeaderText="Product" DataField="ProductCode"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnJobNumber" HeaderText="Job" DataField="JobNumber"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnJobComponentNumber" HeaderText="Component" DataField="JobComponentNumber"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnFunctionCode" HeaderText="Function<br/>Code" DataField="FunctionCode" ReadOnly="true"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnFunctionDescription" HeaderText="Function<br/>Description" DataField="FunctionDescription" ReadOnly="true"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnGeneralLedgerCode" HeaderText="GL<br/>Account" DataField="GeneralLedgerCode" ReadOnly="true"></telerik:GridBoundColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnQuantity" HeaderText="Quantity" DataField="Quantity" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N0}" ReadOnly="true"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnRate" HeaderText="Rate" DataField="Rate" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N3}" ReadOnly="true"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnExtendedAmount" HeaderText="Extended<br/>Amount" DataField="ExtendedAmount" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" ReadOnly="true"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnCommissionPercent" HeaderText="Markup<br/>Percent" DataField="CommissionPercent" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N3}" ReadOnly="true"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnExtendedMarkupAmount" HeaderText="Markup<br/>Amount" DataField="ExtendedMarkupAmount" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnLineTotal" HeaderText="Line<br/>Total" DataField="LineTotal" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" ReadOnly="true"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnEstimateBudgetNet" HeaderText="Estimate/<br/>Budget(Net)" DataField="EstimateBudgetNet" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" ReadOnly="true"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnPOUsed" HeaderText="PO Used(Net)" DataField="POUsed" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" ReadOnly="true"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnBalanceNet" HeaderText="Balance(Net)" DataField="BalanceNet" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" ReadOnly="true"></telerik:GridNumericColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnUseCPM" HeaderText="CPM" DataField="UseCPM">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background standard-green" style='<%# If(Eval("UseCPM") = True, "display:block;", "display:none;")%>'>
                                                <asp:Image ID="ImageCPM" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIsAttachedToAP" HeaderText="AP" DataField="IsAttachedToAP">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background standard-green" style='<%# If(Eval("IsAttachedToAP") = True, "display:inline-block;", "display:none;")%>'>
                                                <asp:Image ID="ImageAttachedToAP" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                            </div>
                                            <div style="display:none;">
                                                <asp:CheckBox ID="CheckBoxAP" runat="server" Checked='<%#Eval("IsAttachedToAP")%>' Enabled="false" Visible="false" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Complete">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background standard-green" style='<%# If(Eval("IsComplete") = True, "display:block;", "display:none;")%>'>
                                                <asp:Image ID="ImageIsComplete" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                            </div>
                                            <asp:HiddenField ID="HiddenFieldMenuOptions" runat="server" Value="" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <div style="margin-top: 10px;">
                            <asp:CheckBox ID="CheckBoxExcludeJobComponentInformation" runat="server" Text="Exclude Job/Component information from copy" TextAlign="Right" />
                        </div>
                    </div>
                </telerik:RadWizardStep>
                <telerik:RadWizardStep ID="RadWizardStepModifyPODetails" runat="server" Title="Update Job Information" StepType="Step">
                    
                    <script type="text/javascript">
                        (function () {
                            $('body')
                                .on('click', 'a[adv-lookup]', function () {
                                    var currentScope = getCurrentScope($(this));
                                    var input, cancel;
                                    var type = $(this).attr('adv-lookup');
                                    input = currentScope.getInput(type);
                                    if (input) {
                                        if ($(input).attr('disabled') === 'disabled') {
                                            cancel = true;
                                        }
                                    } else {
                                        cancel = true;
                                    }
                                    if (!cancel) {
                                        currentScope.open(type);
                                    }
                                })
                                .on('dblclick', 'input[adv-lookup]', function () {
                                    if ($(this).is(":enabled")) {
                                        getCurrentScope($(this)).openFilterDialog($(this));
                                    }
                                })
                                .on('change', 'input[adv-lookup]', function () {
                                    var currentScope = getCurrentScope($(this))
                                    var newVal = null;
                                    var lookupType = $(this).attr('adv-lookup');
                                    var jobComponent = {};
                                    newVal = currentScope.getInputValue(lookupType);
                                    if (lookupType === 'Client' || lookupType === 'Division' || lookupType === 'Product' || lookupType === 'Job' || lookupType === 'JobComponent') {
                                        JobComponent = currentScope.getSearchCriteria().JobComponent
                                        if (lookupType === 'Client') {
                                            JobComponent.ClientName = null;
                                            JobComponent.DivisionCode = null;
                                            JobComponent.DivisionName = null;
                                            JobComponent.ProductCode = null;
                                            JobComponent.ProductName = null;
                                            JobComponent.JobNumber = null;
                                            JobComponent.JobDescription = null;
                                            JobComponent.JobComponentNumber = null;
                                            JobComponent.JobComponentDescription = null;
                                        } else if (lookupType === 'Division') {
                                            JobComponent.DivisionName = null;
                                            JobComponent.ProductCode = null;
                                            JobComponent.ProductName = null;
                                            JobComponent.JobNumber = null;
                                            JobComponent.JobDescription = null;
                                            JobComponent.JobComponentNumber = null;
                                            JobComponent.JobComponentDescription = null;
                                        } else if (lookupType === 'Product') {
                                            JobComponent.ProductName = null;
                                            JobComponent.JobNumber = null;
                                            JobComponent.JobDescription = null;
                                            JobComponent.JobComponentNumber = null;
                                            JobComponent.JobComponentDescription = null;
                                        } else if (lookupType === 'Job') {
                                            JobComponent.JobDescription = null;
                                            JobComponent.JobComponentNumber = null;
                                            JobComponent.JobComponentDescription = null;
                                        } else if (lookupType === 'JobComponent') {
                                            JobComponent.JobComponentDescription = null;
                                        }
                                        currentScope.jobComponentValuesChanged(JobComponent, newVal);
                                    }
                                    if (lookupType === 'Function') {
                                        currentScope.functionValuesChanged(currentScope.getSearchCriteria().Function, newVal);
                                    }
                                    if (lookupType === 'GeneralLedgerAccount') {
                                        currentScope.glAccountValuesChanged(currentScope.getSearchCriteria().GeneralLedgerAccount, newVal);
                                    }
                                    if (lookupType === 'Employee') {
                                        currentScope.employeeValuesChanged(currentScope.getSearchCriteria().Employee, newVal);
                                    }
                                    if (lookupType === 'Vendor') {
                                        currentScope.vendorValuesChanged(currentScope.getSearchCriteria().Vendor, newVal);
                                    }
                                    if (lookupType === 'VendorContact') {
                                        currentScope.vendorContactValuesChanged(currentScope.getSearchCriteria().VendorContact, newVal);
                                    }
                                })
                                .on('focus', 'input[adv-calc]', function () {
                                    getCurrentScope($(this)).parentRow = $(this).closest('tr');
                                })
                                .on('focus', '.RadGrid input[adv-lookup]', function () {
                                    getCurrentScope($(this)).parentRow = $(this).closest('tr');
                                });
                        })();
                    </script>

                    <div ng-app="webvantageApp" ng-controller="purchaseOrderLookupController">
                        <h3 style="display:block; border-bottom: 1px solid black; padding-bottom: 10px;">Update Job Information</h3>
                        <telerik:RadGrid ID="RadGridModifyPODetails" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10"
                             ShowFooter="false" ShowGroupPanel="false" GridLines="None" AllowMultiRowSelection="true" AllowMultiRowEdit="true">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                            <ClientSettings AllowKeyboardNavigation="true">
                                <Selecting AllowRowSelect="true" />
                                <ClientEvents OnGridCreated="onGridCreated" />
                            </ClientSettings>
                            <MasterTableView DataKeyNames="LineNumber" CommandItemDisplay="None" AllowSorting="true" EditMode="InPlace">
                                <Columns>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnLineNumber" HeaderText="Line<br/>Number" DataField="LineNumber" ItemStyle-HorizontalAlign="Right" ReadOnly="true"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDescription"  HeaderText="Description" DataField="LineDescription" ReadOnly="true"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnClientCode" HeaderText="Client" DataField="ClientCode"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDivisionCode" HeaderText="Division" DataField="DivisionCode"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnProductCode" HeaderText="Product" DataField="ProductCode"></telerik:GridBoundColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnJobNumber" HeaderText="Job" DataField="JobNumber"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnJobComponentNumber" HeaderText="Component" DataField="JobComponentNumber"></telerik:GridNumericColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnFunctionCode"  HeaderText="Function<br/>Code" DataField="FunctionCode" ReadOnly="true"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnFunctionDescription"  HeaderText="Function<br/>Description" DataField="FunctionDescription" ReadOnly="true"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnGeneralLedgerCode"  HeaderText="GL<br/>Account" DataField="GeneralLedgerCode" ReadOnly="true"></telerik:GridBoundColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnQuantity" HeaderText="Quantity" DataField="Quantity" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N0}" ReadOnly="true"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnRate" HeaderText="Rate" DataField="Rate" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N3}" ReadOnly="true"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnExtendedAmount" HeaderText="Extended<br/>Amount" DataField="ExtendedAmount" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" ReadOnly="true"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnCommissionPercent" HeaderText="Markup<br/>Percent" DataField="CommissionPercent" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N3}" ReadOnly="true"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnExtendedMarkupAmount" HeaderText="Markup<br/>Amount" DataField="ExtendedMarkupAmount" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" ReadOnly="true"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnLineTotal" HeaderText="Line<br/>Total" DataField="LineTotal" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" ReadOnly="true"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnEstimateBudgetNet" HeaderText="Estimate/<br/>Budget(Net)" DataField="EstimateBudgetNet" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" ReadOnly="true"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnPOUsed" HeaderText="PO Used(Net)" DataField="POUsed" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" ReadOnly="true"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnBalanceNet" HeaderText="Balance(Net)" DataField="BalanceNet" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" ReadOnly="true"></telerik:GridNumericColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnUseCPM" HeaderText="CPM" DataField="UseCPM">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div id="divCPM" runat="server" class="icon-background standard-green" style='<%# If(Eval("UseCPM") = True, "display:inline-block;", "display:none;")%>'>
                                                <asp:Image ID="ImageCPM" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                            </div>
                                            <div style="display: none;">
                                                <asp:TextBox ID="HiddenTextBoxCPM" runat="server" SkinID="TextBoxStandard" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIsAttachedToAP" HeaderText="AP" DataField="IsAttachedToAP">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <%--<div class="icon-background standard-green" style='<%# If(Eval("IsAttachedToAP") = True, "display:inline-block;", "display:none;")%>'>
                                                <asp:ImageButton ID="ImageButtonAttachedToAP" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" CommandName="APInfo" />
                                            </div>
                                            <div style="display: none;">
                                                <asp:CheckBox ID="CheckBoxAP" runat="server" Checked='<%#Eval("IsAttachedToAP")%>' Enabled="false" Visible="false" />
                                            </div>--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Complete">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <%--<div class="icon-background standard-green" style='<%# If(Eval("IsComplete") = True, "display:block;", "display:none;")%>'>
                                                <asp:Image ID="ImageIsComplete" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" />
                                            </div>--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                    
                </telerik:RadWizardStep>
                <telerik:RadWizardStep ID="RadWizardStepFinal" runat="server" Title="Copying Detail(s)..." StepType="Finish">
                    <div>
                        <h3 style="display:block; border-bottom: 1px solid black; padding-bottom: 10px;">Copying Detail(s)...</h3>
                        <telerik:RadProgressManager ID="RadProgressManagerCopy" runat="server" />
                        <telerik:RadProgressArea ID="RadProgressAreaCopy" runat="server" Width="100%" DisplayCancelButton="false"
                            ProgressIndicators="FilesCountBar" OnClientProgressUpdating="OnClientProgressUpdating" >
                        </telerik:RadProgressArea>
                        <div style="margin-top: 10px;"><span id="ProgressMessage"></span></div>
                        <div style="display:none;">
                            <telerik:RadButton ID="RadButtonDoCopy" runat="server" OnClick="RadButtonDoCopy_Click" AutoPostBack="true"></telerik:RadButton>
                        </div>
                    </div>
                    <telerik:RadScriptBlock ID="RadSB" runat="server">
                        <script type="text/javascript">
                            var doDisable = true;
                            $(document).ready(function () {
                                $find('<%= RadButtonDoCopy.ClientID %>').click();
                                $('.rwzPrevious').hide();
                                if (doDisable == true) {
                                    $('.rwzFinish').attr('disabled', 'disabled');
                                }else{
                                    $('.rwzFinish').removeAttr('disabled');
                                }
                            });
                            function OnClientProgressUpdating(sender, args) {
                                var message = '';
                                var progressData = args.get_progressData();
                                if (progressData) {
                                    message = 'Copying Purchase Order detail(s)...';
                                }
                                setProgressMessage(message);
                            }
                            function progressUpdateComplete() {
                                setProgressMessage('Copying detail(s) Completed... Click Finish to continue...');
                                doDisable = false;
                            }
                            function setProgressMessage(message) {
                                var messageSpan = document.getElementById('ProgressMessage');
                                messageSpan.innerHTML = message;
                            }
                        </script>
                    </telerik:RadScriptBlock>
                </telerik:RadWizardStep>
            </WizardSteps>
        </telerik:RadWizard>
    </div>
    
    <telerik:RadScriptBlock ID="RadScriptBlockJavascript" runat="server">
        <script type="text/javascript">
            function HideOrShowJobColumn() {
                $(".threeColLookup").each(function () {
                    $(this).addClass('hideLastCol');
                });
            }
            function HighlightItemByText(sender, args) {
                var selectedVal = sender.get_text();
                var combo = sender;
                var item = combo.findItemByText(selectedVal);
                if (item) {
                    var ele = combo.get_dropDownElement();
                    var scrollEle = $(ele).find('div.rcbScroll');
                    item.highlight();
                    try {
                        var scrollPos;
                        if (item.get_attributes().getAttribute('ypos')) {
                            scrollPos = parseFloat(item.get_attributes().getAttribute('ypos'));
                        } else {
                            scrollPos = $(item.get_element()).offset().top - $(scrollEle).offset().top;
                            item.get_attributes().setAttribute('ypos', scrollPos)
                        }
                        $(scrollEle).animate({
                            scrollTop: scrollPos
                        }, 10);
                    } catch (err) {
                    }
                }
            }
            function OnClientSelectedIndexChanging(sender, args) {
                var newItem = args.get_item();
                var newText = '';
                if (newItem) {
                    newText = newItem.get_text();
                }
                var currentText = sender.get_text();
                if (currentText == newText) {
                    args.set_cancel(true);
                }
            }
            function OnRowDblClick(sender, args) {
                var dataItem = args.get_gridDataItem();
                var nextButton = $find('<%= RadWizardPurchaseOrderCopy.ClientID %>').get_nextButtonElement();
                dataItem.set_selected(true);
                $(nextButton).click();
            }
        </script>
    </telerik:RadScriptBlock>
    <asp:HiddenField ID="HiddenFieldSecMod" runat="server" ClientIDMode="Static" />
</asp:Content>
