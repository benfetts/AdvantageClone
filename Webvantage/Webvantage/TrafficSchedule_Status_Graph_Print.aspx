<%@ Page Title="Print Status Graph" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="TrafficSchedule_Status_Graph_Print.aspx.vb" Inherits="Webvantage.TrafficSchedule_Status_Graph_Print" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
        
        <tr>
            <td>
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" valign="top">
                            <asp:Label   ID="Label2" runat="server" Text='Stepped' Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:Panel ID="PanelStatus" runat="server">                  
                     <telerik:RadHtmlChart ID="RadHtmlChartHoursLineChart" runat="server">
                      </telerik:RadHtmlChart>
                    <%--<telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                        <div id="Div4" style="text-align: center">
                            <object id="Object5" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="<%= Request.Url.Scheme %>://fpdownload.adobe.com/pub/shockwave/cabs/flash/swflash.cab"
                                height="500" width="800">
                                <param name="movie" value="Flash/MSLine.swf?chartWidth=800&chartHeight=500" />
                                <param name="FlashVars" value="&dataXML=<%= WriteXMLStatus %>">
                                <param name="quality" value="high" />
                                <embed flashvars="&dataXML=<%= WriteXMLStatus %>" height="500" name="Line" pluginspage="<%= Request.Url.Scheme %>://get.adobe.com/flashplayer/"
                                    quality="high" src="Flash/MSLine.swf" type="application/x-shockwave-flash" width="800"
                                    wmode="transparent"></embed>
                            </object>
                        </div>
                    </telerik:RadCodeBlock>--%>
                </asp:Panel>
                <asp:Panel ID="PanelBurnRate" runat="server">            
                     <telerik:RadHtmlChart ID="RadHtmlChartBurnRateChart" runat="server">
                      </telerik:RadHtmlChart>
                    <%--<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                        <div id="Div1" style="text-align: center">
                            <object id="Object1" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="<%= Request.Url.Scheme %>://fpdownload.adobe.com/pub/shockwave/cabs/flash/swflash.cab"
                                height="500" width="800">
                                <param name="movie" value="Flash/MSLine.swf?chartWidth=800&chartHeight=500" />
                                <param name="FlashVars" value="&dataXML=<%= WriteXMLBurnRate %>">
                                <param name="quality" value="high" />
                                <embed flashvars="&dataXML=<%= WriteXMLBurnRate %>" height="500" name="Line" pluginspage="<%= Request.Url.Scheme %>://get.adobe.com/flashplayer/"
                                    quality="high" src="Flash/MSLine.swf" type="application/x-shockwave-flash" width="800"
                                    wmode="transparent"></embed>
                            </object>
                        </div>
                    </telerik:RadCodeBlock>--%>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" valign="top">
                            <asp:Label   ID="Label1" runat="server" Text='Stepped' Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="98%" valign="top">
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" valign="top">
                            <telerik:RadGrid ID="RadGridStatusHours" runat="server" AutoGenerateColumns="false"
                                GridLines="None" EnableEmbeddedSkins="True" HorizontalAlign="Center" AllowSorting="true"
                                ShowFooter="true" Width="700">
                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <MasterTableView HorizontalAlign="center" UseAllDataFields="true">
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" valign="top">
                            <asp:Label   ID="LabelCumulative" runat="server" Text='Cumulative' Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="98%" valign="top">
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" valign="top">
                            <telerik:RadGrid ID="RadGridStatusHoursCumulative" runat="server" AutoGenerateColumns="false"
                                GridLines="None" EnableEmbeddedSkins="True" HorizontalAlign="Center" AllowSorting="true"
                                ShowFooter="true" Width="700">
                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <MasterTableView HorizontalAlign="center" UseAllDataFields="true">
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
</asp:Content>
