<%@ Page AutoEventWireup="false" CodeBehind="DashboardProject.aspx.vb" Inherits="Webvantage.DashboardProject"
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
    <table border="0" cellpadding="0" cellspacing="0" align="center" width="50%" class="no-float-menu">
        <tr>
            <td valign="top">
                <asp:TextBox ID="txt1" runat="server" Visible="false" SkinID="TextBoxStandard"></asp:TextBox>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="98%">
                        <tr>
                            <td colspan="4">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td runat="Server" id="Td3" align="left" valign="top" width="10%">
                                            <telerik:RadToolBar ID="RadToolbarData" runat="server" AutoPostBack="True" Width="135px">
                                                <Items>
                                                </Items>
                                            </telerik:RadToolBar>
                                        </td>
                                        <td runat="Server" id="Td1" align="left" valign="top" width="90%">
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
                                                EnableViewState="True" Width="1100px" OnClientButtonClicking="JsOnClientButtonClicking">
                                                <Items>
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton Text="Year to Date" Value="YeartoDate" ToolTip="Calculate Data year to Date"
                                                        CheckOnClick="true" AllowSelfUnCheck="true" Group="Range" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton Text="Month" Value="Month" ToolTip="Calculate Data by Month"
                                                        CheckOnClick="true" AllowSelfUnCheck="true" Group="Range" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton runat="server" Width="200px">
                                                        <ItemTemplate>
                                                            &nbsp;Month:
                                                            <telerik:RadComboBox ID="DropDownListMonth" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                                            </telerik:RadComboBox>
                                                            &nbsp;
                                                        </ItemTemplate>
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton runat="server" Width="200px">
                                                        <ItemTemplate>
                                                            &nbsp;Week:
                                                            <telerik:RadComboBox ID="DropDownListWeek" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                                            </telerik:RadComboBox>
                                                            &nbsp;
                                                        </ItemTemplate>
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton Text="Refresh Data" Value="Data" CommandName="Data" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton Text="Export All" Value="ExportAll" CommandName="ExportAll" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="Bookmark" Value="Bookmark" ToolTip="Bookmark" />                                                    
                                                </Items>
                                            </telerik:RadToolBar>
                                            <!-- Add refresh here too if EC wants it -JL -->
                                        </td>
                                    </tr>
                                    <tr>
                                        <td runat="Server" id="Td2" align="left" valign="top" colspan="4">
                                            <telerik:RadToolBar ID="RadToolbarProject" runat="server" AutoPostBack="True" Width="1235px">
                                                <Items>
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton Text="Projects Created" CheckOnClick="true" AllowSelfUnCheck="true"
                                                        Value="Created" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton Text="Projects Completed" CheckOnClick="true" AllowSelfUnCheck="true"
                                                        Value="Completed" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton Text="Projects Due" CheckOnClick="true" AllowSelfUnCheck="true"
                                                        Value="Due" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton Text="Projects Pending" CheckOnClick="true" AllowSelfUnCheck="true"
                                                        Value="Pending" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton Text="Projects Cancelled" CheckOnClick="true" AllowSelfUnCheck="true"
                                                        Value="Cancelled" />
                                                    <%--<telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="All Projects" CheckOnClick="true" Checked="true" AllowSelfUncheck="true" Value="All" />--%>
                                                </Items>
                                            </telerik:RadToolBar>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <%-- <tr >
                        <td align="left"  colspan="4">
                             &nbsp;&nbsp;<strong><asp:Label   ID="lblTitle" runat="server" Text="Projects"></asp:Label></strong>
                        </td>
                     </tr>--%>
                        <tr class="telerik-aqua-body" align="center">
                            <td valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top" style="padding: 5px">
                                            <telerik:RadGrid ID="RadGridOffice" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                EnableEmbeddedSkins="True" AllowMultiRowSelection="true" Height="200px" Width="250px">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True">
                                                    </Scrolling>
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="OFFICE_CODE,OFFICE_NAME">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="OFFICE_NAME" HeaderText="Office" UniqueName="column2"
                                                            ItemStyle-HorizontalAlign="Left">
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
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </td>
                                        <td align="center" valign="top" style="padding: 5px">
                                            <telerik:RadGrid ID="RadGridAE" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                EnableEmbeddedSkins="True" AllowMultiRowSelection="true" Height="200px" Width="250px">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True">
                                                    </Scrolling>
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="Code,Description">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Account Executive" UniqueName="column2"
                                                            ItemStyle-HorizontalAlign="Left">
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
                                        </td>
                                        <td align="center" valign="top" style="padding: 5px">
                                            <telerik:RadGrid ID="RadGridClient" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                EnableEmbeddedSkins="True" AllowMultiRowSelection="true" Height="200px" Width="250px">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True">
                                                    </Scrolling>
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="Code,Description">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Client" UniqueName="column2"
                                                            ItemStyle-HorizontalAlign="Left">
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridDepartment" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" EnableEmbeddedSkins="True" AllowMultiRowSelection="true" Height="200px"
                                                Width="250px">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True">
                                                    </Scrolling>
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="DP_TM_CODE,DP_TM_DESC">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="DP_TM_DESC" HeaderText="Department" UniqueName="column2"
                                                            ItemStyle-HorizontalAlign="Left">
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
                                        </td>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridSalesClass" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" EnableEmbeddedSkins="True" AllowMultiRowSelection="true" Height="200px"
                                                Width="250px">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True">
                                                    </Scrolling>
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="code,description">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="description" HeaderText="Sales Class" UniqueName="column2"
                                                            ItemStyle-HorizontalAlign="Left">
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
                                        </td>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridJobType" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                EnableEmbeddedSkins="True" AllowMultiRowSelection="true" Height="200px" Width="250px">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True">
                                                    </Scrolling>
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="code,description">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="description" HeaderText="Job Type" UniqueName="column2"
                                                            ItemStyle-HorizontalAlign="Left">
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridCancelledStatus" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" EnableEmbeddedSkins="True" AllowMultiRowSelection="false" Height="200px"
                                                Width="250px">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True">
                                                    </Scrolling>
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="Code,CodeDescription">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="CodeDescription" HeaderText="Status" UniqueName="column2"
                                                            ItemStyle-HorizontalAlign="Left">
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
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:CheckBox ID="ChkIsClosedStatus" runat="server" AutoPostBack="true" Text="Cancelled Status" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <%--  --%>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
