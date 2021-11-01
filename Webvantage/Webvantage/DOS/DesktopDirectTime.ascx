<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopDirectTime.ascx.vb" Inherits="Webvantage.DesktopDirectTime" %>
<%@ Register Src="~/UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>

<telerik:RadScriptBlock ID="sbControl_ScriptBlock" runat="server">
    <script type="text/javascript">
        function RadGridDirectTimeDOColumnPreferencesClick(event) {

            var grid = $find("<%= RadGridDirectTimeDO.ClientID %>");

            grid.get_masterTableView().get_columns()[0].showHeaderMenu(event, 10, 10);

        };
        
    </script>
</telerik:RadScriptBlock>
<div class="telerik-aqua-body" style="margin-top: 5px !important">
    <div class="DO-ButtonHeader">
        <div style="float: left; width: 90%; text-align: left; vertical-align: middle">
            <asp:ImageButton ID="butPrint" runat="server" SkinID="ImageButtonPrint" />
            <asp:ImageButton ID="butExport" runat="server" SkinID="ImageButtonExportExcel" ToolTip="Export to Excel" />
            <asp:ImageButton ID="ImageButtonFilter" runat="server" SkinID="ImageButtonFilter" />
            <asp:ImageButton ID="ImageButtonBookmark" runat="server" ToolTip="Bookmarks" SkinID="ImageButtonBookmark"/>
            <asp:ImageButton ID="butRefresh" runat="server" SkinID="ImageButtonRefresh" ToolTip="Refresh" />

        </div>
    </div>
    <div class="DO-Container">
        <ew:CollapsablePanel ID="CollapsablePanelFilter" runat="server" SkinID="CollapsablePanelDesktopObjectFilter" Collapsed="true" Visible="false">
            <div style="font-size: larger; margin: -7px 0px 0px 0px !important;">
                Filter
            </div>
            <div style="float: left; padding-left: 10px; padding-top: 5px;">
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
                                    <telerik:RadDatePicker ID="RadDatePickerStart" runat="server" AutoPostBack="True" TabIndex="-1"
                                        DateInput-BackColor="#FFFFE0" SkinID="RadDatePickerStandard">
                                        <DateInput AutoPostBack="True" CssClass="RequiredInput" TabIndex="1">
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
                                    <telerik:RadDatePicker ID="RadDatePickerDue" runat="server" AutoPostBack="True" DateInput-BackColor="#FFFFE0" TabIndex="-1"
                                        SkinID="RadDatePickerStandard">
                                        <DateInput AutoPostBack="True" CssClass="RequiredInput" Width="80px" TabIndex="2">
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
                    <td width="100" colspan="4">
                        <asp:Label ID="Label1" runat="server">Client:</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" colspan="4">
                        <table border="0" cellspacing="0" cellpadding="0" width="185px">
                            <tr>
                                <td width="185px" height="25px" valign="top">
                                     <telerik:RadComboBox ID="RadComboBoxClient" runat="server" AutoPostBack="true" width="400" TabIndex="3">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="100" colspan="4">
                        <asp:Label ID="Label2" runat="server">Job:</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" colspan="4">
                        <table border="0" cellspacing="0" cellpadding="0" width="185px">
                            <tr>
                                <td width="185px" height="25px" valign="top">
                                     <telerik:RadComboBox ID="RadComboBoxJob" runat="server" AutoPostBack="true" width="400" TabIndex="4">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="100" colspan="4">
                        <asp:Label ID="Label3" runat="server">Employee:</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" colspan="4">
                        <table border="0" cellspacing="0" cellpadding="0" width="185px">
                            <tr>
                                <td width="185px" height="25px" valign="top">
                                     <telerik:RadComboBox ID="RadComboBoxEmployee" runat="server" AutoPostBack="true" width="400" TabIndex="5">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="100" colspan="4">
                        <asp:CheckBox id="CheckboxPageBreak" runat="server" Text="Page Break PDF Report by Job Component"/>
                    </td>
                </tr>
            </table>
            </div>
            
        </ew:CollapsablePanel>
    </div>
    <div class="DO-Container">
        <telerik:RadGrid ID="RadGridDirectTimeDO" runat="server" AllowPaging="True" AllowSorting="True" EnableViewState="true"
             AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True" ShowHeader="True"
            EnableHeaderContextMenu="true"  AllowFilteringByColumn="false" MasterTableView-EnableGroupsExpandAll="True">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom"></PagerStyle>
            <MasterTableView AllowMultiColumnSorting="true" DataKeyNames="ClientCode,ClientDescription,DivisionCode,DivisionDescription,ProductCode,ProductDescription,Date,JobNumber,JobComponentNumber,Employee,FunctionCode,FunctionDescription, CDPName, JobComponent,JobComponentName" 
                            ShowGroupFooter="True">
                <PagerStyle PageSizes="10,20,50,100" />
                <%--<GroupHeaderTemplate>
                    <asp:Label ID="LabelClient" runat="server" Text=""></asp:Label><br />
                    <asp:Label ID="LabelJob" runat="server" Text=""></asp:Label><br />
                    <asp:Label ID="LabelEmployee" runat="server" Text=""></asp:Label><br />
                    <asp:Label ID="LabelFunction" runat="server" Text=""></asp:Label>
                </GroupHeaderTemplate>--%>
                <Columns>                
                    <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderAbbr="FIXED" AllowFiltering="false">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <HeaderTemplate>
                            <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="RadGridDirectTimeDOColumnPreferencesClick(event);" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%--<div class="icon-background background-color-sidebar">
                                <asp:ImageButton ID="ImageButtonViewDetails" runat="server" ImageAlign="AbsMiddle" CssClass="icon-image" CommandName="Detail"
                                    SkinID="ImageButtonViewWhite" ToolTip="View Task" />
                            </div>--%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <%--<telerik:GridBoundColumn DataField="ClientCode" HeaderText="Client Code" UniqueName="ClientCode" FilterControlWidth="100"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>--%>
                    <telerik:GridBoundColumn DataField="Date" HeaderText="Date" UniqueName="Date" FilterControlWidth="100"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Comments" HeaderText="Comment" UniqueName="Comment"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Hours" HeaderText="Hours" UniqueName="Hours" Aggregate="Sum" DataFormatString="{0:#,##0.00}"
                         CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false" FilterControlWidth="100">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Rate" HeaderText="Rate" UniqueName="Rate" ItemStyle-Width="100" DataFormatString="{0:#,##0.00}"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Amount" HeaderText="Amount" UniqueName="Amount" Aggregate="Sum" DataFormatString="{0:#,##0.00}"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NonBillable" HeaderText="Non Billable" UniqueName="NonBillable" FilterControlWidth="50"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="IsFeeTime" HeaderText="Fee Time" UniqueName="IsFeeTime" FilterControlWidth="50"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Billed" HeaderText="Billed" UniqueName="Billed" FilterControlWidth="50"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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
            <GroupingSettings RetainGroupFootersVisibility="true" />
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

