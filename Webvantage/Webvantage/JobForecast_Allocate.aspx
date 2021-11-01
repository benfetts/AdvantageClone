<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="JobForecast_Allocate.aspx.vb" Inherits="Webvantage.JobForecast_Allocate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlockHeader" runat="server">
        <script type="text/javascript">

            var totalPostPeriods;

            function postPeriodAmountChanged(sender, args) {
                var element = $(sender.get_element());
                var newValue = sender.get_value();
                var totalValue;
                if (newValue) {
                    totalValue = roundToTwo(newValue * totalPostPeriods);
                }
                // find the total input box and set it to totalValue
                var BillOrRev = element.prop('id').indexOf('Billing') > -1 ? 'Billing' : 'Revenue';
                var totalInput = $find(element.closest('tr').find('input[id$=RadNumericTextBoxAllocateAmount' + BillOrRev + ']').attr('id'));
                totalInput.remove_valueChanged(totalAmountChanged);
                totalInput.set_value(totalValue);
                totalInput.add_valueChanged(totalAmountChanged);
            }
            function totalAmountChanged(sender, args) {
                var element = $(sender.get_element());
                var newValue = sender.get_value();
                var splitValue;
                if (newValue) {
                    splitValue = roundToTwo((newValue / totalPostPeriods));
                }
                // find the post period input box and set it to splitValue
                var BillOrRev = element.prop('id').indexOf('Billing') > -1 ? 'Billing' : 'Revenue';
                var perPeriodInput = $find(element.closest('tr').find('input[id$=RadNumericTextBoxAllocateAmountPerPostPeriod' + BillOrRev + ']').attr('id'));
                perPeriodInput.remove_valueChanged(postPeriodAmountChanged);
                perPeriodInput.set_value(splitValue);
                perPeriodInput.add_valueChanged(postPeriodAmountChanged);
            }
            function roundToTwo(num) {
                return +(Math.round(num + 'e+2') + "e-2");
            }
            $(document).ready(function () {
                totalPostPeriods = Number($('#HiddenFieldTotalPostPeriods').val());
            });
        </script>
    </telerik:RadScriptBlock>
    <style type="text/css">
        input[roundoff=true] {
            background: #ffd800 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <div >
        <telerik:RadToolBar ID="RadToolBarJobForecastAllocate" runat="server" AutoPostBack="true" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSave" runat="server" SkinID="RadToolBarButtonSave"
                    Text="" Value="Save" CommandName="Save" ToolTip="Save Allocation" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonCancel" runat="server" SkinID="RadToolBarButtonCancel"
                    Text="" Value="Cancel" CommandName="Cancel" ToolTip="Cancel" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    
    <div >
    </div>

    <telerik:RadGrid ID="RadGridComponents" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10"
        ShowFooter="true" EnableLinqExpressions="false" AllowMultiRowEdit="true" ShowGroupPanel="false" AllowMultiRowSelection="true" GridLines="None">
        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
        <ClientSettings AllowKeyboardNavigation="true" AllowGroupExpandCollapse="true"></ClientSettings>
        <MasterTableView CommandItemDisplay="None" AllowSorting="true" GroupLoadMode="Client" DataKeyNames="JobForecastJobID" ClientDataKeyNames="JobForecastJobID" Width="100%" EnableGroupsExpandAll="true" >
            <GroupByExpressions>
                <telerik:GridGroupByExpression>
                    <SelectFields>
                        <telerik:GridGroupByField FieldName="ClientName" />
                    </SelectFields>
                    <GroupByFields>
                        <telerik:GridGroupByField FieldName="ClientCode" />
                    </GroupByFields>
                </telerik:GridGroupByExpression>
            </GroupByExpressions>
            <SortExpressions>
                <telerik:GridSortExpression FieldName="JobNumber" SortOrder="Descending" />
                <telerik:GridSortExpression FieldName="JobComponentNumber" SortOrder="Ascending" />
            </SortExpressions>
            <ColumnGroups>
                <telerik:GridColumnGroup Name="AllocateAmount" HeaderText="Allocate" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"></telerik:GridColumnGroup>
                <telerik:GridColumnGroup Name="Billing" HeaderText="Billing" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver" ParentGroupName="AllocateAmount"></telerik:GridColumnGroup>
                <telerik:GridColumnGroup Name="Revenue" HeaderText="Revenue" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver" ParentGroupName="AllocateAmount"></telerik:GridColumnGroup>
            </ColumnGroups>
            <Columns>
                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnComponent" HeaderText="Job/Component">
                    <ItemStyle  CssClass="radgrid-large-description-column" />
                    <ItemTemplate>
                        <asp:Label ID="LabelJobComponent" runat="server" style="white-space:nowrap;" ToolTip='<%# AdvantageFramework.StringUtilities.PadWithCharacter(Eval("JobNumber"), 6, "0", True) & " - " & AdvantageFramework.StringUtilities.PadWithCharacter(Eval("JobComponentNumber"), 2, "0", True) & " " & Eval("JobComponentDescription")  %>'>
                            <%# AdvantageFramework.StringUtilities.PadWithCharacter(Eval("JobNumber"), 6, "0", True) & " - " & AdvantageFramework.StringUtilities.PadWithCharacter(Eval("JobComponentNumber"), 2, "0", True) & " " & Eval("JobComponentDescription")  %>
                        </asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridNumericColumn UniqueName="GridNumericColumnApprovedEstimateAmount" HeaderText="Estimate" DataField="ApprovedEstimateAmount" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:n2}" ItemStyle-HorizontalAlign="Right"></telerik:GridNumericColumn>
                <telerik:GridNumericColumn UniqueName="GridNumericColumnForecastAmount" HeaderText="Forecast" DataField="Forecast" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:n2}" ItemStyle-HorizontalAlign="Right"></telerik:GridNumericColumn>
                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAllocateAmountPerPostPeriodBilling" HeaderText="Per Post Period" ItemStyle-CssClass="radgrid-amount-column" ColumnGroupName="Billing">
                    <ItemTemplate>
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxAllocateAmountPerPostPeriodBilling" runat="server" AutoPostBack="false"  WrapperCssClass="radgrid-amount-input" MinValue="0" DbValue='<%# Bind("BillingAmountToAllocateByPostPeriod") %>'>
                            <NumberFormat DecimalDigits="2" KeepTrailingZerosOnFocus="true" />
                            <EnabledStyle HorizontalAlign="Right" />
                            <ClientEvents OnValueChanged="postPeriodAmountChanged" />
                        </telerik:RadNumericTextBox>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAllocateAmountBilling" HeaderText="Total" ItemStyle-CssClass="radgrid-amount-column" ColumnGroupName="Billing">
                    <ItemTemplate>
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxAllocateAmountBilling" runat="server" AutoPostBack="false"  WrapperCssClass="radgrid-amount-input" MinValue="0" DbValue='<%# Bind("BillingAmountToAllocate") %>'>
                            <NumberFormat DecimalDigits="2" KeepTrailingZerosOnFocus="true" />
                            <ClientEvents OnValueChanged="totalAmountChanged" />
                            <EnabledStyle HorizontalAlign="Right" />
                        </telerik:RadNumericTextBox>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAllocateAmountPerPostPeriodRevenue" HeaderText="Per Post Period" ItemStyle-CssClass="radgrid-amount-column" ColumnGroupName="Revenue">
                    <ItemTemplate>
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxAllocateAmountPerPostPeriodRevenue" runat="server" AutoPostBack="false"  WrapperCssClass="radgrid-amount-input" MinValue="0" DbValue='<%# Bind("RevenueAmountToAllocateByPostPeriod") %>'>
                            <NumberFormat DecimalDigits="2" KeepTrailingZerosOnFocus="true" />
                            <EnabledStyle HorizontalAlign="Right" />
                            <ClientEvents OnValueChanged="postPeriodAmountChanged" />
                        </telerik:RadNumericTextBox>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAllocateAmountRevenue" HeaderText="Total" ItemStyle-CssClass="radgrid-amount-column" ColumnGroupName="Revenue">
                    <ItemTemplate>
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxAllocateAmountRevenue" runat="server" AutoPostBack="false"  WrapperCssClass="radgrid-amount-input" MinValue="0" DbValue='<%# Bind("RevenueAmountToAllocate") %>'>
                            <NumberFormat DecimalDigits="2" KeepTrailingZerosOnFocus="true" />
                            <ClientEvents OnValueChanged="totalAmountChanged" />
                            <EnabledStyle HorizontalAlign="Right" />
                        </telerik:RadNumericTextBox>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
    <asp:HiddenField ID="HiddenFieldTotalPostPeriods" runat="server" Value="" ClientIDMode="Static" />

</asp:Content>
