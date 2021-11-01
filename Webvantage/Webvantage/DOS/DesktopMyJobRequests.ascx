<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopMyJobRequests.ascx.vb" Inherits="Webvantage.DesktopMyJobRequests" %>
<%@ Register Src="~/UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>

<telerik:RadScriptBlock ID="sbControl_ScriptBlock" runat="server">
    <script type="text/javascript">
        function RadGridJobRequestsColumnPreferencesClick(event) {

            var grid = $find("<%= RadGridJobRequestsDO.ClientID %>");

            grid.get_masterTableView().get_columns()[0].showHeaderMenu(event, 10, 10);

        };
        
    </script>
</telerik:RadScriptBlock>
<div class="telerik-aqua-body" style="margin-top: 5px!important;">
    <div class="DO-ButtonHeader">
        <div style="float: left; width: 90%; text-align: left; vertical-align: middle">
            <asp:ImageButton ID="ImageButtonAdd" runat="server" SkinID="ImageButtonAdd" ToolTip="Add Job Request" />
            <asp:ImageButton ID="butPrint" runat="server" SkinID="ImageButtonPrint" />
            <asp:ImageButton ID="butExport" runat="server" SkinID="ImageButtonExportExcel" ToolTip="Export to Excel" />
            <asp:ImageButton ID="ImageButtonFilter" runat="server" SkinID="ImageButtonFilter" />
            <asp:ImageButton ID="ImageButtonBookmark" runat="server" ToolTip="Bookmarks" SkinID="ImageButtonBookmark"/>
            <asp:ImageButton ID="butRefresh" runat="server" SkinID="ImageButtonRefresh" ToolTip="Refresh" />

            <div style="display: inline-block; padding: 0px 0px 0px 10px;">
                Search:
            </div>
            <asp:TextBox ID="TextBoxSearchHeader" runat="server"></asp:TextBox>
            <asp:ImageButton ID="ImageButtonSearchHeader" runat="server" SkinID="ImageButtonFind" ToolTip="Search" />
        </div>
        <div style="float: right; width: 10%; text-align: right;">
        </div>
    </div>
    <div class="DO-Container">
        <ew:CollapsablePanel ID="CollapsablePanelFilter" runat="server" SkinID="CollapsablePanelDesktopObjectFilter" Collapsed="true" Visible="false">
            <div style="font-size: larger; margin: -7px 0px 0px 0px !important;">
                Filter
            </div>
            <div style="float: left; padding-left: 10px; padding-top: 5px; width: 30%">
                 <table id="TableFilterTasks" border="0" cellspacing="2" cellpadding="0" width="455">
                    <tr>
                        <td width="100">
                            <asp:Label ID="Label8" runat="server">Start Date:</asp:Label>
                        </td>
                        <td width="200">
                            <asp:Label ID="Label9" runat="server">End Date:</asp:Label>
                        </td>
                        <td align="right" valign="middle" width="40">&nbsp;
                        </td>
                        <td align="right" valign="middle" width="100">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <table border="0" cellspacing="0" cellpadding="0" width="185px">
                                <tr>
                                    <td width="185px" height="25px" valign="top">
                                        <telerik:RadDatePicker ID="RadDatePickerStart" runat="server" AutoPostBack="True"
                                            DateInput-BackColor="#FFFFE0" SkinID="RadDatePickerStandard">
                                            <DateInput AutoPostBack="True" CssClass="RequiredInput">
                                            </DateInput>
                                        </telerik:RadDatePicker>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table border="0" cellspacing="0" cellpadding="0" width="185px">
                                <tr>
                                    <td width="185px" height="25px" valign="top">
                                        <telerik:RadDatePicker ID="RadDatePickerDue" runat="server" AutoPostBack="True" DateInput-BackColor="#FFFFE0"
                                            SkinID="RadDatePickerStandard">
                                            <DateInput AutoPostBack="True" CssClass="RequiredInput" Width="80px">
                                            </DateInput>
                                        </telerik:RadDatePicker>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="right" valign="middle">&nbsp;
                        </td>
                        <td align="right" valign="middle">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="Label10" runat="server">Search</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="imgbtnSearch" runat="server" SkinID="ImageButtonFind" ToolTip="Search" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:CheckBox id="CheckboxExclude" runat="server" Text="Exclude Completed Job Requests" AutoPostBack="true"/>
                        </td>
                    </tr>
                </table>   
            </div>
            
        </ew:CollapsablePanel>
    </div>
    <div class="DO-Container">
        <telerik:RadGrid ID="RadGridJobRequestsDO" runat="server" AllowPaging="True" AllowSorting="True"
             AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True"
            EnableHeaderContextMenu="true"  AllowFilteringByColumn="false">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom"></PagerStyle>
            <MasterTableView AllowMultiColumnSorting="true" DataKeyNames="JOB_VER_HDR_ID,JOB_VER_SEQ_NBR,JOB_NUMBER,JOB_COMPONENT_NBR">
                <Columns>                
                    <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderAbbr="FIXED" AllowFiltering="false">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <HeaderTemplate>
                            <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="RadGridJobRequestsColumnPreferencesClick(event);" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="icon-background background-color-sidebar">
                                <asp:ImageButton ID="ImageButtonViewDetails" runat="server" ImageAlign="AbsMiddle" CssClass="icon-image" CommandName="Detail"
                                    SkinID="ImageButtonViewWhite" ToolTip="View Task" />
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="CL_CODE" HeaderText="Client" UniqueName="ClientCode" FilterControlWidth="100"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client Name" UniqueName="ClientName"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DIV_CODE" HeaderText="Division" UniqueName="DivisionCode" FilterControlWidth="100"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DIV_NAME" HeaderText="Division Name" UniqueName="DivisionName"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PRD_CODE" HeaderText="Product" UniqueName="ProductCode" FilterControlWidth="100"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PRD_DESCRIPTION" HeaderText="Product Name" UniqueName="ProductName"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JOB_VER_DESC" HeaderText="Description" UniqueName="JobRequestDescription" SortExpression="JOB_VER_DESC"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CREATE_DATE" HeaderText="Date of Request" UniqueName="RequestDate" FilterControlWidth="100"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CREATED_BY" HeaderText="Created By" UniqueName="CreatedBy" FilterControlWidth="100"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS" HeaderText="Status" UniqueName="RequestStatus" 
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JOB_NUMBER" HeaderText="Job" UniqueName="JobNumber" FilterControlWidth="100"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JOB_DESC" HeaderText="Job Description" UniqueName="JobDescription"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column"/>
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JOB_COMPONENT_NBR" HeaderText="Component" UniqueName="ComponentNumber" FilterControlWidth="100"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JOB_COMP_DESC" HeaderText="Comp Description" UniqueName="ComponentDescription"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"  CssClass="radgrid-description-column"/>
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                    </telerik:GridBoundColumn>
                </Columns>
                <ExpandCollapseColumn Visible="False">
                    <HeaderStyle Width="19px" />
                </ExpandCollapseColumn>
                <RowIndicatorColumn Visible="False">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
            </MasterTableView>
            <ClientSettings>
                <Scrolling AllowScroll="false" />
                <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
            </ClientSettings>
        </telerik:RadGrid>
    </div>
    <asp:HiddenField ID="HiddenFieldWindowName" Value="" runat="server" />
    <telerik:RadScriptBlock ID="ScriptBlockFooter" runat="server">
        <script type="text/javascript">
            function getRadWindowName() {
                try {
                    var oWnd = GetRadWindow();
                    var id = oWnd.get_name();
                    document.getElementById('<%= HiddenFieldWindowName.ClientID %>').value = id;
                } catch (err) {
                    var abc = null;
                };
            };
            getRadWindowName();
        </script>
    </telerik:RadScriptBlock>
    <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />

</div>
