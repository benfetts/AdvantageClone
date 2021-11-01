<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopMyClientAging.ascx.vb" Inherits="Webvantage.DesktopMyClientAging" %>
<div class="telerik-aqua-body" style="margin-top: 5px !important;">
    <div class="DO-ButtonHeader">
        <div style="float: left; width: 90%; text-align: left; vertical-align: middle">
            <asp:ImageButton ID="butPrint" runat="server" SkinID="ImageButtonPrint" />
            <asp:ImageButton ID="butExport" runat="server" SkinID="ImageButtonExportExcel" ToolTip="Export to Excel" Visible="false" />
            <asp:ImageButton ID="ImageButtonFilter" runat="server" SkinID="ImageButtonFilter" />
            <asp:ImageButton ID="ImageButtonBookmark" runat="server" ToolTip="Bookmarks" SkinID="ImageButtonBookmark"/>
            <asp:ImageButton ID="butrefresh" runat="server" AlternateText="Refresh"
                SkinID="ImageButtonRefresh" ToolTip="Refresh" />
        </div>

    </div>
    <div class="DO-Container">
        <ew:CollapsablePanel ID="CollapsablePanelFilter" runat="server" SkinID="CollapsablePanelDesktopObjectFilter" Collapsed="true" Visible="false">
            <div style="font-size: larger; margin: -7px 0px 0px 0px !important;">
                Filter
            </div>
            <table id="TableFilterMyClientAging" border="0"
                cellspacing="2" cellpadding="0">
                <tr>
                    <td width="60%">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblMsg" runat="server" CssClass="CssRequired"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="1%">&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server">Office:</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddOffice" runat="server" AutoPostBack="true" width="220">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server">Client:</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ClientDropDownList" runat="server" AutoPostBack="true" width="220">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server">Division:</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="DivisionDropDownList" runat="server" AutoPostBack="true" width="220">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server">Product:</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ProductDropDownList" runat="server" AutoPostBack="true" width="220">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblGroup1" runat="server">Group 1:</asp:Label><br />
                                    <asp:TextBox ID="txtGroup1" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblGroup2" runat="server">Group 2:</asp:Label><br />
                                    <asp:TextBox ID="txtGroup2" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblGroup3" runat="server">Group 3:</asp:Label><br />
                                    <asp:TextBox ID="txtGroup3" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblGroup4" runat="server">Group 4:</asp:Label><br />
                                    <asp:TextBox ID="txtGroup4" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbIncludeOver" runat="server" Text="Include Over Only" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="40%" valign="top">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label3" runat="server" CssClass="CssRequired"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="1%">&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server">Invoice Category:</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <telerik:RadListBox ID="lbInvoiceCat" runat="server" SelectionMode="Multiple" Width="220"
                                        Height="100px" AutoPostBack="true">
                                    </telerik:RadListBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ew:CollapsablePanel>
    </div>


    <div class="centered" style="padding-top: 11px">
        <telerik:RadHtmlChart ID="RadHtmlChartClientAging" runat="server">
            <ClientEvents OnSeriesClick="RadHtmlChartClientAgingOnSeriesClick" />

        </telerik:RadHtmlChart>
    </div>
    <style type="text/css">
        svg > g > g:nth-child(3) > g:nth-child(4) > g {
            cursor: pointer;
        }
    </style>
    <telerik:RadScriptBlock ID="RadScriptBlockFooter" runat="server">
        <script type="text/javascript">
            function RadHtmlChartClientAgingOnSeriesClick(sender, args) {
                var url = sender.dataItem.SeriesClickUrl;
                if (url) {
                    OpenRadWindow('', url, 800, 1200, false);
                }
            }
            $(window).resize(function () {
                $find('<%= RadHtmlChartClientAging.ClientID%>').get_kendoWidget().resize();
            });
        </script>
    </telerik:RadScriptBlock>
</div>

