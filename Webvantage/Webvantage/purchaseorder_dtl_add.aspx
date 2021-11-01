<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="purchaseorder_dtl_add.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="" Inherits="Webvantage.purchaseorder_dtl_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">

            function RadToolBarOnClientButtonClicking(sender, eventArgs) {
                var button = eventArgs.get_item();
                if (button.get_value() == 'Add') {
                    var MasterTable = $find('<%= RadGrid_Items.ClientID%>').get_masterTableView();
                    var SelectedRows = MasterTable.get_selectedItems();
                    var NonBillable = false;
                    var Cell;
                    for (i = 0; i < SelectedRows.length; i++) {
                        Cell = MasterTable.getCellByColumnUniqueName(SelectedRows[i], "GridBoundColumn_Nonbillable");
                        if (Cell.innerHTML == '1') {
                            NonBillable = true;
                        }
                    }
                    if (NonBillable) {
                        eventArgs.set_cancel(!confirm('One or more job components are marked as non billable. Are you sure you want to continue?'));
                    }
                }
            }

            function EnableOrDisableActions() {
                var RadGrid = $find('<%= RadGrid_Items.ClientID%>');
                var MasterTable = RadGrid.get_masterTableView();
                var SelectedRows = MasterTable.get_selectedItems();
                var Addbutton = $find('<%= RadToolBar_Options.ClientID%>').findItemByValue('Add');
                if (SelectedRows.length > 0) {
                    Addbutton.enable();
                } else {
                    Addbutton.disable();
                }
            }

            function RadGridOnGridCreated(sender, args) {
                var cols = sender.get_masterTableView().get_columns();
                $(cols).each(function () {
                    this.set_resizable(true);
                    this.resizeToFit(false, true);
                    this.set_resizable(false);
                });
            }

            function IsPOVendorOnly() {
                if ($('#<%= CheckBox_Vendor.ClientID %>').is(':checked') === true) {
                    return 1;
                } else {
                    return 0;
                }
            }

        </script>
    </telerik:RadScriptBlock>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolBar_Options" runat="server" AutoPostBack="True" Width="100%" OnClientButtonClicking="RadToolBarOnClientButtonClicking">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonFind" Text="Search" Value="Search" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonNew" Text="Add" Value="Add" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonClear" Text="Clear" Value="Clear" />
            </Items>
        </telerik:RadToolBar>
    </div>
   <style>
       .two-col-leftcolumn {
            float: left;
            margin-top: -11px;
            width: 250px;
            border: 0px solid transparent;
            /* border-radius: 6px; */
        }
   </style>
    <div class="wrapper">
        <div id="DivFilter" runat="server" class="two-col-leftcolumn">
            <div class="" style="">
                <div class="filter-card">
                    <div class="card-content" style="margin-bottom: 20px;">
                        <asp:Panel ID="PnlSearch" runat="server" DefaultButton="BtnSearch">
                            <div>
                                <asp:Panel ID="Panel_Client" runat="server">
                                    <div>
                                        <div>
                                            <asp:HyperLink ID="HyperLink_Client" runat="server" href=""><span>Client:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TextBox_Client" runat="server" Width="145px" MaxLength="6" SkinID="TextBoxStandard"></asp:TextBox>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Panel_Division" runat="server">
                                    <div>
                                        <div>
                                            <asp:HyperLink ID="HyperLink_Division" runat="server" href=""><span>Division:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TextBox_Division" runat="server" Width="145px" MaxLength="6" SkinID="TextBoxStandard"></asp:TextBox>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Panel_Product" runat="server">
                                    <div>
                                        <div>
                                            <asp:HyperLink ID="HyperLink_Product" runat="server" href=""><span>Product:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TextBox_Product" runat="server" Width="145px" MaxLength="6" SkinID="TextBoxStandard"></asp:TextBox>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Panel_Job" runat="server">
                                    <div>
                                        <div>
                                            <asp:HyperLink ID="HyperLink_Job" runat="server" href=""><span>Job:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TextBox_Job" runat="server" Width="145px" MaxLength="6" SkinID="TextBoxStandard"></asp:TextBox>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Panel_Component" runat="server">
                                    <div>
                                        <div>
                                            <asp:HyperLink ID="HyperLink_Component" runat="server" Text="Component:" href=""><span>Component:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TextBox_Component" runat="server" Width="145px" MaxLength="3" SkinID="TextBoxStandard"></asp:TextBox>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Panel_Campaign" runat="server">
                                    <div>
                                        <div>
                                            <asp:HyperLink ID="HyperLink_Campaign" runat="server" Text="Campaign:" href=""><span>Campaign:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TextBox_Campaign" runat="server" Width="145px" MaxLength="6" AutoPostBack="true" SkinID="TextBoxStandard"></asp:TextBox>
                                            <asp:HiddenField ID="HiddenField_Campaign" runat="server" />
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Panel_Vendor" runat="server">
                                    <div>
                                        <div>
                                            <asp:Label ID="Label_Vendor" runat="server"><span>PO Vendor Only:</span></asp:Label>&nbsp;&nbsp;<asp:CheckBox ID="CheckBox_Vendor" runat="server" TextAlign="Left" />
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                            <div style="display: none;">
                                <asp:Button ID="BtnSearch" runat="server" Text="Search" Visible="true" TabIndex="-1" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
        <div id="DivGrid" runat="server" class="two-col-rightcolumn">
            <telerik:RadGrid ID="RadGrid_Items" runat="server" AllowPaging="true" PageSize="40" AllowMultiRowSelection="true" AllowSorting="true" Width="1400px" Height="100%">
                <ClientSettings>
                    <ClientEvents OnGridCreated="RadGridOnGridCreated" />
                    <Resizing AllowColumnResize="true" AllowResizeToFit="true" />
                </ClientSettings>
                <MasterTableView AllowPaging="true" PageSize="15" TableLayout="Auto" AutoGenerateColumns="false" AllowFilteringByColumn="false">
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="SelectColumn_Select"></telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_JobNumber" DataField="JobNumber" HeaderText="Job">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_JobDescription" DataField="JobDescription" HeaderText="Job<br/>Description">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_JobComponentNumber" DataField="JobComponentNumber" HeaderText="Comp">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_JobComponentDescription" DataField="JobComponentDescription" HeaderText="Comp<br/>Description">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_CampaignCode" DataField="CampaignCode" HeaderText="Campaign">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_CampaignName" DataField="CampaignName" HeaderText="Campaign<br/>Name">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_EstimateNumber" DataField="EstimateNumber" HeaderText="Estimate">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_EstimateComponentNumber" DataField="EstimateComponentNumber" HeaderText="Estimate<br/>Comp">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_EstimateQuoteNumber" DataField="EstimateQuoteNumber" HeaderText="Estimate<br/>Quote">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_FunctionCode" DataField="FunctionCode" HeaderText="Function">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_FunctionDescription" DataField="FunctionDescription" HeaderText="Function<br/>Description">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_VendorCode" DataField="VendorCode" HeaderText="Vendor">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_VendorName" DataField="VendorName" HeaderText="Vendor<br/>Name">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_Quantity" DataField="Quantity" HeaderText="Quantity">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_Rate" DataField="Rate" HeaderText="Rate">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_ExtendedAmount" DataField="ExtendedAmount" HeaderText="Extended<br/>Amount">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_Nonbillable" DataField="NonBillable" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_MarkupPercent" DataField="MarkupPercent" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumn_ExtendedMarkupAmount" DataField="ExtendedMarkupAmount" Display="false">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
                <ClientSettings>
                    <Selecting AllowRowSelect="true" />
                    <Resizing AllowColumnResize="true" AllowResizeToFit="true" ResizeGridOnColumnResize="true" />
                    <ClientEvents OnRowSelected="EnableOrDisableActions" OnRowDeselected="EnableOrDisableActions" OnMasterTableViewCreated="EnableOrDisableActions" />
                </ClientSettings>
            </telerik:RadGrid>
        </div>
    </div>
    <asp:HiddenField ID="PO_VenderCode" runat="server" Value="" />
</asp:Content>
