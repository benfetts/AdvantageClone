<%@ Page AutoEventWireup="false" CodeBehind="DashboardClient.aspx.vb" Inherits="Webvantage.DashboardClient"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function StopPropagation(e) {
                if (!e) {
                    e = window.event;
                }

                e.cancelBubble = true;
            }
        </script>
    </telerik:RadScriptBlock>

            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        
    <table border="0" cellpadding="0" cellspacing="0" align="center" width="100%" >
        <tr>
            <td valign="top">
                <table align="center" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="98%">
                                <tr>
                                    <td runat="Server" id="Td4" align="left" valign="top" >
                                        <telerik:RadToolBar ID="RadToolbarData" runat="server" AutoPostBack="True" Width="100%">
                                            <Items>
                                            </Items>
                                        </telerik:RadToolBar>
                                    </td>
                                    <td runat="Server" id="Td1" align="left" valign="top">
                                        <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
                                            <script type="text/javascript">
                                                function JsOnClientButtonClicking(sender, args) {
                                                    var comandName = args.get_item().get_commandName();
                                                    if (comandName == "Data") {
                                                        ////args.set_cancel(!confirm('Are you sure you want to update?'));
                                                        radToolBarConfirm(sender, args, "Are you sure you want to update?");
                                                    }
                                                }
                                            </script>
                                        </telerik:RadScriptBlock>
                                        <telerik:RadToolBar ID="RadToolbarDashProject" runat="server" AutoPostBack="True"
                                            EnableViewState="True" Width="830px" OnClientButtonClicking="JsOnClientButtonClicking">
                                            <Items>
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Year to Date" Value="YeartoDate" ToolTip="Calculate Data year to Date"
                                                    CheckOnClick="true" AllowSelfUnCheck="true" Group="Range" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Month" Value="Month" ToolTip="Calculate Data by Month"
                                                    CheckOnClick="true" AllowSelfUnCheck="true" Group="Range" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton runat="server">
                                                    <ItemTemplate>
                                                        &nbsp;Month:
                                                        <telerik:RadComboBox ID="DropDownListMonth" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                                        </telerik:RadComboBox>
                                                        &nbsp;
                                                    </ItemTemplate>
                                                </telerik:RadToolBarButton>
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton runat="server">
                                                    <ItemTemplate>
                                                        &nbsp;Week:
                                                        <telerik:RadComboBox ID="DropDownListWeek" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                                        </telerik:RadComboBox>
                                                        &nbsp;
                                                    </ItemTemplate>
                                                </telerik:RadToolBarButton>
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="Bookmark" Value="Bookmark" ToolTip="Bookmark" />
                                                <%-- Please swap these 2 refresh buttons - jl --%>

                                                <telerik:RadToolBarButton ID="RadToolbarButtonRefresh" runat="server" SkinID="RadToolBarButtonRefresh" Value="Data" ToolTip="Refresh Data" CommandName="Data" />
<%--                                                <telerik:RadToolBarButton Text="Refresh Data" Value="Data" CommandName="Data" />--%>
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Export All" Value="ExportAll" CommandName="ExportAll" />
                                            </Items>
                                        </telerik:RadToolBar>
                                    </td>
                                </tr>
                                <tr>
                                    <td runat="Server" id="Td2" align="left" valign="top" colspan="2">
                                        <telerik:RadToolBar ID="RadToolbarOptions" runat="server" AutoPostBack="True" Width="100%">
                                            <Items>
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Estimated" CheckOnClick="true" AllowSelfUnCheck="true"
                                                    Value="Estimated" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Actual" CheckOnClick="true" AllowSelfUnCheck="true"
                                                    Value="Actual" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Billable" CheckOnClick="true" AllowSelfUnCheck="true"
                                                    Value="Billable" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Fee" CheckOnClick="true" AllowSelfUnCheck="true"
                                                    Value="Fee" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Non Billable" CheckOnClick="true" AllowSelfUnCheck="true"
                                                    Value="Non Billable" />
                                            </Items>
                                        </telerik:RadToolBar>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
        <div class="telerik-aqua-body">
            <div class="grid-container" >
                <div class="grid-col-1-3">
                    <telerik:RadGrid ID="RadGridOffice" runat="server" AutoGenerateColumns="False" GridLines="None"
                            AllowMultiRowSelection="true" Height="200px">
                        <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                            <Selecting AllowRowSelect="True" />
                            <Scrolling AllowScroll="true" UseStaticHeaders="True" SaveScrollPosition="True">
                            </Scrolling>
                            <Resizing AllowColumnResize="true" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="OFFICE_CODE,OFFICE_NAME">
                            <Columns>
                                <telerik:GridBoundColumn DataField="OFFICE_NAME" HeaderText="Office" UniqueName="column2"
                                    ItemStyle-HorizontalAlign="Left" Resizable="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="OFFICE_CODE" HeaderText="" UniqueName="column3"
                                    Visible="false">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <EditFormSettings>
                                <PopUpSettings ScrollBars="None" />
                            </EditFormSettings>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
                <div class="grid-col-1-3">
                    <telerik:RadGrid ID="RadGridAE" runat="server" AutoGenerateColumns="False" GridLines="None"
                            AllowMultiRowSelection="true" Height="200px">
                        <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                            <Selecting AllowRowSelect="True" />
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True">
                            </Scrolling>
                            <Resizing AllowColumnResize="true" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="Code,Description">
                            <Columns>
                                <telerik:GridBoundColumn DataField="Description" HeaderText="Account Executive" UniqueName="column2"
                                    ItemStyle-HorizontalAlign="Left" Resizable="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Code" HeaderText="" UniqueName="column3" Visible="false">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <EditFormSettings>
                                <PopUpSettings ScrollBars="None" />
                            </EditFormSettings>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
                <div class="grid-col-1-3">
                    <telerik:RadGrid ID="RadGridClient" runat="server" AutoGenerateColumns="False" GridLines="None"
                            AllowMultiRowSelection="true" Height="200px">
                        <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                            <Selecting AllowRowSelect="True" />
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True">
                            </Scrolling>
                            <Resizing AllowColumnResize="true" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="Code,Description">
                            <Columns>
                                <telerik:GridBoundColumn DataField="Description" HeaderText="Client" UniqueName="column2"
                                    ItemStyle-HorizontalAlign="Left" Resizable="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Code" HeaderText="" UniqueName="column3" Visible="false">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </div>
            <div class="grid-container">
                <div class="grid-col-1-3">
                    <telerik:RadGrid ID="RadGridDepartment" runat="server" AutoGenerateColumns="False"
                        GridLines="None"  AllowMultiRowSelection="true" Height="200px">
                        <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                            <Selecting AllowRowSelect="True" />
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True">
                            </Scrolling>
                            <Resizing AllowColumnResize="true" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="DP_TM_CODE,DP_TM_DESC">
                            <Columns>
                                <telerik:GridBoundColumn DataField="DP_TM_DESC" HeaderText="Department" UniqueName="column2"
                                    ItemStyle-HorizontalAlign="Left" Resizable="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DP_TM_CODE" HeaderText="" UniqueName="column3"
                                    Visible="false">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
                <div class="grid-col-1-3">
                    <telerik:RadGrid ID="RadGridSalesClass" runat="server" AutoGenerateColumns="False"
                        GridLines="None"  AllowMultiRowSelection="true" Height="200px">
                        <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                            <Selecting AllowRowSelect="True" />
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True">
                            </Scrolling>
                            <Resizing AllowColumnResize="true" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="code,description">
                            <Columns>
                                <telerik:GridBoundColumn DataField="description" HeaderText="Sales Class" UniqueName="column2"
                                    ItemStyle-HorizontalAlign="Left" Resizable="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="code" HeaderText="" UniqueName="column3" Visible="false">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
                <div class="grid-col-1-3">
                    <telerik:RadGrid ID="RadGridJobType" runat="server" AutoGenerateColumns="False" GridLines="None"
                            AllowMultiRowSelection="true" Height="200px">
                        <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                            <Selecting AllowRowSelect="True" />
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True">
                            </Scrolling>
                            <Resizing AllowColumnResize="true" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="code,description">
                            <Columns>
                                <telerik:GridBoundColumn DataField="description" HeaderText="Job Type" UniqueName="column2"
                                    ItemStyle-HorizontalAlign="Left" Resizable="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="code" HeaderText="" UniqueName="column3" Visible="false">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </div>     
        </div>
    

                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
