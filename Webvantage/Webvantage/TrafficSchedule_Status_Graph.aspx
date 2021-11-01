<%@ Page Title="Status Graph" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="TrafficSchedule_Status_Graph.aspx.vb" Inherits="Webvantage.TrafficSchedule_Status_Graph" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript" src="Jscripts/FusionCharts.js"></script>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            FusionCharts.setCurrentRenderer('javascript');
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolbarHours" runat="server" AutoPostBack="True" Width="100%"
            EnableViewState="True">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Employee Time Forecast" Value="ETF" ToolTip="Planned based on ETF."
                    CheckOnClick="true" AllowSelfUnCheck="true" Group="Hours" />
                <telerik:RadToolBarButton Text="Hours Allowed" Value="Allowed" ToolTip="Planned based on Hours Allowed."
                    CheckOnClick="true" AllowSelfUnCheck="true" Group="Hours" Checked="true" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Hours Graph" Value="HoursGraph" ToolTip="Display Hours Graph"
                    CheckOnClick="true" AllowSelfUnCheck="true" Group="Graph" />
                <telerik:RadToolBarButton Text="Burn Rate Graph" Value="BurnRateGraph" ToolTip="Display Burn Rate Graph"
                    CheckOnClick="true" AllowSelfUnCheck="true" Group="Graph" Checked="true" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Hours" Value="Hours" ToolTip="Display Hours"
                    CheckOnClick="true" AllowSelfUnCheck="true" Group="Data" Checked="true" />
                <telerik:RadToolBarButton Text="Dollars" Value="Dollars" ToolTip="Display Dollars"
                    CheckOnClick="true" AllowSelfUnCheck="true" Group="Data" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Stepped" Value="Monthly" ToolTip="Display Stepped"
                    CheckOnClick="true" AllowSelfUnCheck="true" Group="Type" />
                <telerik:RadToolBarButton Text="Cumulative" Value="Cumulative" ToolTip="Display Cumulative"
                    CheckOnClick="true" AllowSelfUnCheck="true" Group="Type" Checked="true" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Quoted" Value="Quoted" ToolTip="Quoted - Burn rate based on Quoted."
                    CheckOnClick="true" AllowSelfUnCheck="true" Group="Burn" Checked="true" />
                <telerik:RadToolBarButton Text="Planned" Value="Planned" ToolTip="Planned - Burn rate based on Planned."
                    CheckOnClick="true" AllowSelfUnCheck="true" Group="Burn" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Month" Value="Month" ToolTip="Display by month"
                    CheckOnClick="true" AllowSelfUnCheck="true" Group="Group" />
                <telerik:RadToolBarButton Text="Week" Value="Week" ToolTip="Display by week"
                    CheckOnClick="true" AllowSelfUnCheck="true" Group="Group" Checked="true" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="" Value="Print" ToolTip="Print" SkinID="RadToolBarButtonPrint" />
                <telerik:RadToolBarButton Value="Refresh" SkinID="RadToolBarButtonRefresh" />
                <telerik:RadToolBarButton SkinId="RadToolBarButtonBookmark" Value="Bookmark"
                    ToolTip="Bookmark" Visible="false" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">        
            <h4 style="text-align: center !important; margin-right: 8px; margin-top: 12px;">
                <asp:Label ID="Label2" runat="server" Text='Stepped' Font-Bold="True"></asp:Label>
            </h4>
         <div style="padding: 10px; text-align: center; overflow: auto;">
                <asp:Panel ID="PanelStatus" runat="server">                    
                     <telerik:RadHtmlChart ID="RadHtmlChartHoursLineChart" runat="server">
                      </telerik:RadHtmlChart>
                    <%--<telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                        <object id="Object5" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="<%= Request.Url.Scheme %>://fpdownload.adobe.com/pub/shockwave/cabs/flash/swflash.cab"
                            height="500" width="800">
                            <param name="movie" value="Flash/MSLine.swf?chartWidth=800&chartHeight=500" />
                            <param name="FlashVars" value="&dataXML=<%= WriteXMLStatus %>">
                            <param name="quality" value="high" />
                            <embed flashvars="&dataXML=<%= WriteXMLStatus %>" height="500" name="Line"
                                pluginspage="<%= Request.Url.Scheme %>://get.adobe.com/flashplayer/"
                                quality="high" src="Flash/MSLine.swf" type="application/x-shockwave-flash"
                                width="800" wmode="transparent"></embed>
                        </object>
                    </telerik:RadCodeBlock>--%>
                </asp:Panel>
                <asp:Panel ID="PanelBurnRate" runat="server">             
                     <telerik:RadHtmlChart ID="RadHtmlChartBurnRateChart" runat="server">
                      </telerik:RadHtmlChart>
                   <%-- <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                        <object id="Object1" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="<%= Request.Url.Scheme %>://fpdownload.adobe.com/pub/shockwave/cabs/flash/swflash.cab"
                            height="500" width="800">
                            <param name="movie" value="Flash/MSLine.swf?chartWidth=800&chartHeight=500" />
                            <param name="FlashVars" value="&dataXML=<%= WriteXMLBurnRate %>">
                            <param name="quality" value="high" />
                            <embed flashvars="&dataXML=<%= WriteXMLBurnRate %>" height="500" name="Line"
                                pluginspage="<%= Request.Url.Scheme %>://get.adobe.com/flashplayer/"
                                quality="high" src="Flash/MSLine.swf" type="application/x-shockwave-flash"
                                width="800" wmode="transparent"></embed>
                        </object>
                    </telerik:RadCodeBlock>--%>
                </asp:Panel>
            </div>
            <h4 style="text-align: center !important; margin-right: 8px; margin-top: 12px;">
                <asp:Label ID="Label1" runat="server" Text='Stepped' Font-Bold="True"></asp:Label>
            </h4>
            <div style="margin-top: 5px; width: 98% !important; padding: 8px; overflow: auto;">
                <telerik:RadGrid ID="RadGridStatusHours" runat="server" AutoGenerateColumns="false" GridLines="None"
                    EnableEmbeddedSkins="True" HorizontalAlign="Center" AllowSorting="true" ShowFooter="true">
                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView HorizontalAlign="center" UseAllDataFields="true">
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
            <h4 style="text-align: center !important; margin-right: 8px; margin-top: 12px;">
                <asp:Label ID="LabelCumulative" runat="server" Text='Cumulative' Font-Bold="True"></asp:Label>
            </h4>
            <div style="margin-top: 5px; width: 98% !important; padding: 8px; overflow: auto;">
                <telerik:RadGrid ID="RadGridStatusHoursCumulative" runat="server" AutoGenerateColumns="false" GridLines="None"
                    EnableEmbeddedSkins="True" HorizontalAlign="Center" AllowSorting="true" ShowFooter="true">
                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView HorizontalAlign="center" UseAllDataFields="true">
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
    </div>
   
</asp:Content>
