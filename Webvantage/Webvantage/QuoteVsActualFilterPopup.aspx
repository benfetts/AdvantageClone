<%@ Page Title="Quote Vs Actual Filter" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="QuoteVsActualFilterPopup.aspx.vb" Inherits="Webvantage.QuoteVsActualFilterPopup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
<script language="javascript" type="text/javascript">

    function ClearTB(tb) {
        try {
            var keyval = window.event.keyCode;
            if (keyval == 9) { }
            else {
                var thisTextbox = document.getElementById(tb);
                thisTextbox.value = '';
            }
        }
        catch (err) { }

    }

    function FocusTB(tb) {
        var thisTextbox = document.getElementById(tb);
        thisTextbox.focus();
    }

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadTabStrip ID="FilterTabs" runat="server" AutoPostBack="True" CausesValidation="False"
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
                    <tr>
                        <td align="center" class="DesktopObjectSubHeader">
                            Filter Options
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadPanelBar ID="FilterPanelFilter" runat="server" CollapseAnimation-Duration="200"
                                CollapseAnimation-Type="Linear" ExpandAnimation-Duration="200" ExpandAnimation-Type="Linear"
                                Width="100%" BorderStyle="None" Height="250">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Expanded="true" BorderStyle="None">
                                        <Items>
                                            <telerik:RadPanelItem runat="server" BorderStyle="None">
                                                <ItemTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="right">
                                                                <asp:HyperLink ID="hlOffice" runat="server" href="" Target="_blank" TabIndex="-1"> Office: </asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtOffice" runat="server" MaxLength="4"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:HyperLink ID="hlClient" runat="server" href="" Target="_blank" TabIndex="-1"> Client: </asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtClient" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:HyperLink ID="hlDivision" runat="server" href="" Target="_blank" TabIndex="-1">  Division: </asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDivision" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:HyperLink ID="hlProduct" runat="server" href="" Target="_blank" TabIndex="-1">  Product: </asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtProduct" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>                                                        
                                                        <tr>
                                                            <td align="right">
                                                                <asp:HyperLink ID="hlSalesClass" runat="server" href="" Target="_blank" TabIndex="-1"> Sales Class: </asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtSalesClass" runat="server" MaxLength="6"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:HyperLink ID="hlCampaign" runat="server" href="" Target="_blank" TabIndex="-1"> Campaign: </asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtCampaign" runat="server" MaxLength="6"></asp:TextBox>
                                                                <asp:HiddenField ID="hfCampaignID" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:HyperLink ID="hlJob" runat="server" href="" Target="_blank" TabIndex="-1">  Job: </asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtJob" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:HyperLink ID="hlJobComp" runat="server" href="" Target="_blank" TabIndex="-1">  Job Comp: </asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtJobComp" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:HyperLink ID="hlAE" runat="server" href="" Target="_blank" TabIndex="-1"> AE: </asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtAE" runat="server" MaxLength="6"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:HyperLink ID="HlManager" runat="server" href="" TabIndex="-1" Target="_blank" > Manager: </asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TxtManager" runat="server" MaxLength="6" Text=""></asp:TextBox>
                                                            </td>
                                                        </tr>                                                        
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="cbClosedJobs" runat="server" Text='Include Closed Jobs'/>
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
                    <tr>
                        <td align="center" class="DesktopObjectSubHeader">
                            Non Billable Breakout Options
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                                <telerik:RadPanelBar ID="FilterPanelBreakout" runat="server" BorderStyle="None" CollapseAnimation-Duration="200"
                                    CollapseAnimation-Type="Linear" ExpandAnimation-Duration="200" ExpandAnimation-Type="Linear"
                                    Height="250" Width="100%">
                                    <Items>
                                        <telerik:RadPanelItem runat="server" BorderStyle="None" Expanded="true">
                                            <Items>
                                                <telerik:RadPanelItem runat="server" BorderStyle="None">
                                                    <ItemTemplate>
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:RadioButton ID="rbIncludeNB" runat="server" AutoPostBack="true" GroupName="NonBillable"
                                                                        Text="Include Non Billable" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:RadioButton ID="rbBreakoutAllNB" runat="server" AutoPostBack="true" GroupName="NonBillable"
                                                                        Text="Breakout All Non Billable" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:RadioButton ID="rbBreakoutNBForFT" runat="server" AutoPostBack="true" GroupName="NonBillable"
                                                                        Text="Breakout Non Billable For Function Types" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbEmployeeTime"
                                                                        runat="server" AutoPostBack="true" Text="Employee Time" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIncomeOnly" runat="server"
                                                                        AutoPostBack="true" Text="Income Only" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbVendor" runat="server"
                                                                        AutoPostBack="true" Text="Vendor" />
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
                            </telerik:RadAjaxPanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div class="centered">
        <asp:Label   ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>