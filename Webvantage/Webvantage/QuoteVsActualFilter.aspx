<%@ Page AutoEventWireup="false" CodeBehind="QuoteVsActualFilter.aspx.vb" EnableViewState="True"
    Inherits="Webvantage.QuoteVsActualFilter" Language="vb" MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain"
    EnableViewState="true">
    <telerik:RadTabStrip ID="RadTabStrip" runat="server" AutoPostBack="True" CausesValidation="False"
        Width="100%">
        <Tabs>
            <telerik:RadTab ID="Tab1" runat="server" Text="Root Tab">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadToolBar ID="RadToolbarQvA" runat="server" AutoPostBack="true" Width="100%">
        <Items>
            <telerik:RadToolBarButton ID="RadToolbarButtonSave" ImageUrl="Images/disk_blue.png"
                Text="Save" Value="Save" ToolTip="Save" />
            <telerik:RadToolBarButton ID="RadToolbarButtonClear" ImageUrl="Images/undo.png" Text="Clear"
                Value="Clear" ToolTip="Clear" />
        </Items>
    </telerik:RadToolBar>
    <table align="center" width="100%" cellspacing="2" cellpadding="0">
        <tr>
            <td align="center" valign="top" width="50%">
                <table align="center" cellpadding="2" cellspacing="2" width="100%">
                    <tr class="DesktopObjectSubHeader">
                        <td align="center">
                            Filter Options
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadPanelBar ID="RadPanelbarQVA" runat="server" CollapseAnimation-Duration="200"
                                CollapseAnimation-Type="Linear" ExpandAnimation-Duration="200" ExpandAnimation-Type="Linear"
                                Width="100%" BorderStyle="None" Height="200px">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Expanded="true" BorderStyle="None">
                                        <Items>
                                            <telerik:RadPanelItem runat="server" BorderStyle="None">
                                                <ItemTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="right">
                                                                <asp:HyperLink ID="hlClient" runat="server" TabIndex="-1" href="" Target="_blank"> Client: </asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtClient" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:HyperLink ID="hlDivision" runat="server" TabIndex="-1" href="" Target="_blank">  Division: </asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDivision" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:HyperLink ID="hlProduct" runat="server" TabIndex="-1" href="" Target="_blank">  Product: </asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtProduct" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:HyperLink ID="hlJob" runat="server" TabIndex="-1" href="" Target="_blank">  Job: </asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtJob" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:HyperLink ID="hlJobComp" runat="server" TabIndex="-1" href="" Target="_blank">  Job Comp: </asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtJobComp" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </telerik:RadPanelItem>
                                        </Items>
                                    </telerik:RadPanelItem>
                                </Items>
                                <ExpandAnimation Duration="300" Type="Linear" />
                                <CollapseAnimation Duration="300" Type="Linear" />
                            </telerik:RadPanelBar>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="center" valign="top" width="50%">
                <table align="center" cellpadding="2" cellspacing="2" width="100%">
                    <tr class="DesktopObjectSubHeader">
                        <td align="center">
                            Non Billable Breakout Options
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadPanelBar ID="RadPanelbarQVA1" runat="server" CollapseAnimation-Duration="200"
                                CollapseAnimation-Type="Linear" ExpandAnimation-Duration="200" ExpandAnimation-Type="Linear"
                                Width="100%" BorderStyle="None" Height="200px">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Expanded="true" BorderStyle="None">
                                        <Items>
                                            <telerik:RadPanelItem runat="server" BorderStyle="None">
                                                <ItemTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButton ID="rbIncludeNB" runat="server" Text="Include Non Billable" GroupName="NonBillable"
                                                                    AutoPostBack="true" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButton ID="rbBreakoutAllNB" runat="server" Text="Breakout All Non Billable"
                                                                    GroupName="NonBillable" AutoPostBack="true" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButton ID="rbBreakoutNBForFT" runat="server" Text="Breakout Non Billable For Function Types"
                                                                    GroupName="NonBillable" AutoPostBack="true" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbEmployeeTime"
                                                                    runat="server" Text="Employee Time" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIncomeOnly" runat="server"
                                                                    Text="Income Only" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbVendor" runat="server"
                                                                    Text="Vendor" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </telerik:RadPanelItem>
                                        </Items>
                                    </telerik:RadPanelItem>
                                </Items>
                                <ExpandAnimation Duration="300" Type="Linear" />
                                <CollapseAnimation Duration="300" Type="Linear" />
                            </telerik:RadPanelBar>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div class="centered">
        <asp:Button ID="butClear" runat="server" Text="Clear" />&nbsp;
        <asp:Button ID="butOk" runat="server" Text="Save" /><br />
        <asp:Label   ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>