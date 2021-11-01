<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Desktop_CRMCentral.aspx.vb" Inherits="Webvantage.Desktop_CRMCentral" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentCRMCentral" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlockCSS" runat="server">
        <script type="text/javascript">

            var xoffset;
            var yoffset;
            var isExporting;

            function OnRequestStart(sender, args) {
                xoffset = window.pageXOffset;
                yoffset = window.pageYOffset;
                if (isExporting == true) {
                    isExporting = false;
                    args.set_enableAjax(false);
                };
            };

            function OnResponseEnd() {
                var grid = $find('<%= RadGridCRMCentralProducts.ClientID%>');
                var toolbar = $find('<%= RadToolBarCRMCentral.ClientID%>');

                grid.repaint();
                //toolbar.repaint();

                window.scrollTo(xoffset, yoffset);
            };

            function RadToolBarCRMCentralOnClientButtonClicking(sender, args) {
                var commandName = args.get_item().get_value();
                if (commandName == "Export") {
                    isExporting = true;
                    args.set_cancel(true);
                    __doPostBack("Export", "Export");
                };
            };
            function RadToolBarCRMCentralOnClientMouseOver(sender, args) {
                var commandName = args.get_item().get_value();
                if (commandName == "ColumnPreferences") {
                    RadGridCRMCentralProductsColumnHeaderMenu();
                    return false;
                };
            };

            function OnClientShowing() {
                var element = $get('content - div');
                var scrollTop = document.body.scrollTop;
                var scrollLeft = document.body.scrollLeft;
                var viewPortHeight = document.body.clientHeight;
                var viewPortWidth = document.body.clientWidth;
                if (document.compatMode == "CSS1Compat") {
                    viewPortHeight = document.documentElement.clientHeight;
                    viewPortWidth = document.documentElement.clientWidth;
                    if (!$telerik.isSafari) {
                        scrollTop = document.documentElement.scrollTop;
                        scrollLeft = document.documentElement.scrollLeft;
                    };
                };
                element.style.position = "absolute";
                element.style.top = scrollTop + "px";
                element.style.left = scrollLeft + "px";
            };

            function ModifyColumns(visiblecolumns) {
                var grid = $find('<%= RadGridCRMCentralProducts.ClientID%>');
                var mastertable = grid.get_masterTableView();
                var columns = mastertable.get_columns();
                var column;

                for (i = 0; i < columns.length; i++) {
                    column = columns[i];
                    if (visiblecolumns.indexOf(column.get_uniqueName()) >= 0) {
                        mastertable.showColumn(i);
                    } else {
                        mastertable.hideColumn(i);
                    };
                };

                grid.repaint();

            };

            function RadGridCRMCentralProductsColumnHeaderMenu(ev) {
                var grid = $find("<%= RadGridCRMCentralProducts.ClientID %>");
                grid.get_masterTableView().get_columns()[0].showHeaderMenu(ev, 30, 40);
                return false;
            };


        </script>
        <style>

            .rgFiltered .rgFilter {
                 background-color: yellow !important;
                 color: yellow !important;
                 
                 
            }

             /*.rgFilterRow .rgFilterActive:active,
             .rgFilterRow .rgFilterActive:hover,
             .rgFilterRow .rgFilterActive:focus {
                background-color: yellow !important;
                color: yellow !important;
            }

             .rgFilterRow button.rgActionButton {
                background-color: yellow !important;
                color: #9eda29;
            }*/

        </style>
    </telerik:RadCodeBlock>
    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>    
            <div style="margin-left: 18px;">
            <telerik:RadToolBar ID="RadToolBarCRMCentral" runat="server" AutoPostBack="true" 
                OnClientButtonClicking="RadToolBarCRMCentralOnClientButtonClicking" 
                OnClientMouseOver="RadToolBarCRMCentralOnClientMouseOver">
                <Items>                    
                    <telerik:RadToolBarButton ID="RadToolBarButtonSeparator1" runat="server" IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonExport" runat="server" SkinID="RadToolBarButtonExportExcel" Value="Export" CommandName="Export" ToolTip="Export CRM Activity" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonPrint" runat="server" SkinID="RadToolBarButtonPrint"
                        Text="Print" Value="Print" ToolTip="Print Reports" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonSettings" Value="ColumnPreferences" Visible="false"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton ID="RadToolBarButtonCodes" runat="server"
                        Text="Show Codes" Value="Codes" ToolTip="Show Codes" Group="GridDisplay" AllowSelfUnCheck="false" CheckOnClick="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonDescriptions" runat="server"
                        Text="Show Descriptions" Value="Descriptions" ToolTip="Show Descriptions" Group="GridDisplay" AllowSelfUnCheck="false" CheckOnClick="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonBoth" runat="server"
                        Text="Show Both" Value="Both" ToolTip="Show Both" Group="GridDisplay" AllowSelfUnCheck="false" CheckOnClick="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonSeparator2" runat="server" IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonClient" runat="server"
                        Text="Client" Value="Client" ToolTip="View/Edit Client" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonSeparator3" runat="server" IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonDivision" runat="server"
                        Text="Division" Value="Division" ToolTip="View/Edit Division" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonSeparator4" runat="server" IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonProduct" runat="server"
                        Text="Product" Value="Product" ToolTip="View/Edit Product" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonCompanyProfile" runat="server"
                        Text="Company Profile" Value="CompanyProfile" ToolTip="View/Edit Company Profile" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonActivitySummary" runat="server"
                        Text="Activity Summary" Value="ActivitySummary" ToolTip="View/Edit Activity Summary" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonContracts" runat="server"
                        Text="Contract/Opportunities" Value="ContractOpportunities" ToolTip="View Contract/Opportunities" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonSeparator5" runat="server" IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonClientContacts" runat="server"
                        Text="Client Contacts" Value="ClientContacts" ToolTip="View Client Contacts" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonSeparator6" runat="server" IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonAddDiary" runat="server"
                        Text="Add Diary" Value="AddDiary" ToolTip="Add New Diary Entry" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonSeparator7" runat="server" IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonAddActivity" runat="server"
                        Text="Add Activity" Value="AddActivity" ToolTip="Add New Activity" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonSeparator8" runat="server" IsSeparator="true" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="Bookmark" Value="Bookmark" ToolTip="Bookmark" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonClearFilters" Text="" Value="ClearFilter" ToolTip="Clear Column Filters" />

                </Items>
            </telerik:RadToolBar>      
            </div>
            <div id="content-div" class="telerik-aqua-body">
                <telerik:RadGrid ID="RadGridCRMCentralProducts" runat="server" AllowPaging="true" EnableAJAX="false"
                AllowSorting="true" GridLines="None" PageSize="25" EnableEmbeddedSkins="true"
                ShowFooter="false" AutoGenerateColumns="false" Width="98%" AllowFilteringByColumn="true" ClientSettings-EnablePostBackOnRowClick="true" EnableHeaderContextMenu="true"
                EnableLinqExpressions="false" ExportSettings-ExportOnlyData="true" ExportSettings-HideStructureColumns="True" ExportSettings-OpenInNewWindow="True" ExportSettings-IgnorePaging="True">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                <ClientSettings Selecting-AllowRowSelect="true">
                    <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
                </ClientSettings>
                <ExportSettings FileName="CRM Activity"></ExportSettings>
                <GroupingSettings CaseSensitive="false" />
                <MasterTableView DataKeyNames="ID">
                    <Columns>
                        <telerik:GridBoundColumn DataField="ClientCode" ReadOnly="true" UniqueName="ClientCode" HeaderText="Client Code" SortExpression="ClientCode" FilterControlWidth="75px" FilterDelay="1250" CurrentFilterFunction="Contains" />
                        <telerik:GridBoundColumn DataField="ClientName" ReadOnly="true" UniqueName="ClientName" HeaderText="Client Name" SortExpression="ClientName" FilterDelay="1250" CurrentFilterFunction="Contains" />
                        <telerik:GridBoundColumn DataField="DivisionCode" ReadOnly="true" UniqueName="DivisionCode" HeaderText="Division Code" SortExpression="DivisionCode" FilterControlWidth="75px" FilterDelay="1250" CurrentFilterFunction="Contains" />
                        <telerik:GridBoundColumn DataField="DivisionName" ReadOnly="true" UniqueName="DivisionName" HeaderText="Division Name" SortExpression="DivisionName" FilterDelay="1250" CurrentFilterFunction="Contains" />
                        <telerik:GridBoundColumn DataField="ProductCode" ReadOnly="true" UniqueName="ProductCode" HeaderText="Product Code" SortExpression="ProductCode" FilterControlWidth="75px" FilterDelay="1250" CurrentFilterFunction="Contains" />
                        <telerik:GridBoundColumn DataField="ProductName" ReadOnly="true" UniqueName="ProductName" HeaderText="Product Name" SortExpression="ProductName" FilterDelay="1250" CurrentFilterFunction="Contains" />
                        <telerik:GridBoundColumn DataField="OfficeCode" ReadOnly="true" UniqueName="OfficeCode" HeaderText="Office Code" SortExpression="OfficeCode" FilterControlWidth="75px" FilterDelay="1250" CurrentFilterFunction="Contains" />
                        <telerik:GridBoundColumn DataField="OfficeName" ReadOnly="true" UniqueName="OfficeName" HeaderText="Office Name" SortExpression="OfficeName" FilterDelay="1250" CurrentFilterFunction="Contains" />
                        <telerik:GridBoundColumn DataField="DefaultAccountExecutiveCode" ReadOnly="true" UniqueName="DefaultAccountExecutiveCode" HeaderText="AE Code" SortExpression="DefaultAccountExecutiveCode" FilterControlWidth="75px" CurrentFilterFunction="Contains" FilterDelay="1250" />
                        <telerik:GridBoundColumn DataField="DefaultAccountExecutive" ReadOnly="true" UniqueName="DefaultAccountExecutive" HeaderText="Account Executive" SortExpression="DefaultAccountExecutive" CurrentFilterFunction="Contains" FilterDelay="1250" />
                        <telerik:GridTemplateColumn DataField="NewBusiness" ReadOnly="false" UniqueName="NewBusiness" HeaderText="New Business" SortExpression="NewBusiness" FilterDelay="1250">
                            <HeaderStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <FooterStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <div class="icon-background standard-green" style='<%# If(Eval("NewBusiness") = True, "display:block;", "display:none;")%>'>
                                    <asp:Image ID="ImageNewBusiness" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="IsInactive" ReadOnly="false" UniqueName="IsInactive" HeaderText="Inactive" SortExpression="IsInactive" FilterDelay="1250" DataType="System.Boolean">
                            <HeaderStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <FooterStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <div class="icon-background standard-red" style='<%# If(Eval("IsInactive") = True, "display:block;", "display:none;")%>'>
                                    <asp:Image ID="ImageIsInactive" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="LastActivityDate" ReadOnly="true" UniqueName="LastActivityDate" HeaderText="Last Activity Date" SortExpression="LastActivityDate" FilterDelay="1250" CurrentFilterFunction="Contains" />
                        <telerik:GridBoundColumn DataField="LastActivityType" ReadOnly="true" UniqueName="LastActivityType" HeaderText="Last Activity Type" SortExpression="LastActivityType" FilterDelay="1250" CurrentFilterFunction="Contains" />
                        <telerik:GridBoundColumn DataField="LastActivitySubject" ReadOnly="true" UniqueName="LastActivitySubject" HeaderText="Last Activity Subject" SortExpression="LastActivitySubject" FilterDelay="1250" CurrentFilterFunction="Contains" />
                        <telerik:GridTemplateColumn UniqueName="LastContactDate" HeaderText="Last Contact Date" DataField="LastContactDate" FilterDelay="1250" CurrentFilterFunction="Contains"
                            SortExpression="LastContactDate">
                            <HeaderStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <FooterStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <telerik:RadDatePicker ID="RadDatePickerLastContactDate" runat="server" CssClass="NoBorderTextBox" SelectedDate='<%#Eval("LastContactDate")%>' AutoPostBack="true" OnSelectedDateChanged="ASPxDateEditLastContactDate_OnValueChanged" SkinID="RadDatePickerStandard"></telerik:RadDatePicker>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="LastContactDate" ReadOnly="true" UniqueName="LastContactDateExport" HeaderText="Last Contact Date" SortExpression="LastContactDate" Visible="false" />
                    </Columns>
                    <RowIndicatorColumn>
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn>
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                </MasterTableView>
            </telerik:RadGrid>
            </div>     
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
