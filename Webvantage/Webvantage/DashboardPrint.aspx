<%@ Page Title="Print Dashboard" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="DashboardPrint.aspx.vb" Inherits="Webvantage.DashboardPrint" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">    
    
    <script type="text/javascript" src="JScripts/fusion/fusioncharts.js"></script>
    <script type="text/javascript" src="JScripts/fusion/fusioncharts.charts.js"></script>
    <script type="text/javascript" src="JScripts/fusion/fusioncharts.widgets.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="telerik-aqua-body">
    <table align="center" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="2" align="left" >
                &nbsp;<asp:Label   ID="lblTitle" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="pnlDash" runat="server" Visible="false">
                        <tr>
                            <td align="center">
                                <telerik:RadHtmlChart ID="RadHtmlChartOffice" runat="server" Width="400" Height="350">
                                </telerik:RadHtmlChart>
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                            </td>
                            <td align="center">
                                <telerik:RadHtmlChart ID="RadHtmlChartDepartmentTeamChart" runat="server" Width="400" Height="350">
                                </telerik:RadHtmlChart>
                                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="pnlDashProd" runat="server" Visible="false">
                        <tr>
                            <td width="25%">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong>Required Hours (Goal) vs. Total Hours</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <%--<telerik:RadCodeBlock ID="rc" runat="server">--%>
                                                <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                                                <%--<div id="Div1" style="text-align: center">
                                                    <object id="Object9" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="<%= Request.Url.Scheme %>://fpdownload.adobe.com/pub/shockwave/cabs/flash/swflash.cab"
                                                        height="150" width="245">
                                                        <param name="movie" value="Flash/AngularGauge.swf?chartWidth=245&chartHeight=150" />
                                                        <param name="FlashVars" value="&dataXML=<%= WriteXMLGaugeRequired %>" />
                                                        <param name="quality" value="high" />
                                                        <embed flashvars="&dataXML=<%= WriteXMLGaugeRequired %>" height="150" name="MSColumn3D"
                                                            pluginspage="<%= Request.Url.Scheme %>://get.adobe.com/flashplayer/"
                                                            quality="high" src="Flash/AngularGauge.swf" type="application/x-shockwave-flash"
                                                            width="245" wmode="transparent"></embed>
                                                    </object>
                                                </div>--%>
                                            <%--</telerik:RadCodeBlock>--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="25%">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong>Direct Hours Goal vs. Direct Hours</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                                                <asp:Literal ID="Literal4" runat="server"></asp:Literal>
                                               <%-- <div id="Div2" style="text-align: center">
                                                    <object id="Object1" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="<%= Request.Url.Scheme %>://fpdownload.adobe.com/pub/shockwave/cabs/flash/swflash.cab"
                                                        height="150" width="245">
                                                        <param name="movie" value="Flash/AngularGauge.swf?chartWidth=245&chartHeight=150" />
                                                        <param name="FlashVars" value="&dataXML=<%= WriteXMLGauge %>" />
                                                        <param name="quality" value="high" />
                                                        <embed flashvars="&dataXML=<%= WriteXMLGauge %>" height="150" name="MSColumn3D" pluginspage="<%= Request.Url.Scheme %>://get.adobe.com/flashplayer/"
                                                            quality="high" src="Flash/AngularGauge.swf" type="application/x-shockwave-flash"
                                                            width="245" wmode="transparent"></embed>
                                                    </object>
                                                </div>--%>
                                            </telerik:RadCodeBlock>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="25%">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong>Billable Hours Goal vs. Billable Hours</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                                                <asp:Literal ID="Literal5" runat="server"></asp:Literal>
                                                <%--<div id="Div4" style="text-align: center">
                                                    <object id="Object7" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="<%= Request.Url.Scheme %>://fpdownload.adobe.com/pub/shockwave/cabs/flash/swflash.cab"
                                                        height="150" width="245">
                                                        <param name="movie" value="Flash/AngularGauge.swf?chartWidth=245&chartHeight=150" />
                                                        <param name="FlashVars" value="&dataXML=<%= WriteXMLGaugeGoal %>" />
                                                        <param name="quality" value="high" />
                                                        <embed flashvars="&dataXML=<%= WriteXMLGaugeGoal %>" height="150" name="MSColumn3D"
                                                            pluginspage="<%= Request.Url.Scheme %>://get.adobe.com/flashplayer/"
                                                            quality="high" src="Flash/AngularGauge.swf" type="application/x-shockwave-flash"
                                                            width="245" wmode="transparent"></embed>
                                                    </object>
                                                </div>--%>
                                            </telerik:RadCodeBlock>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="25%">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong>Direct Hours vs. Billable Hours</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                                                <asp:Literal ID="Literal6" runat="server"></asp:Literal>
                                                <%--<div id="Div5" style="text-align: center">
                                                    <object id="Object10" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="<%= Request.Url.Scheme %>://fpdownload.adobe.com/pub/shockwave/cabs/flash/swflash.cab"
                                                        height="150" width="245">
                                                        <param name="movie" value="Flash/AngularGauge.swf?chartWidth=245&chartHeight=150" />
                                                        <param name="FlashVars" value="&dataXML=<%= WriteXMLGaugeBillable %>" />
                                                        <param name="quality" value="high" />
                                                        <embed flashvars="&dataXML=<%= WriteXMLGaugeBillable %>" height="150" name="MSColumn3D"
                                                            pluginspage="<%= Request.Url.Scheme %>://get.adobe.com/flashplayer/"
                                                            quality="high" src="Flash/AngularGauge.swf" type="application/x-shockwave-flash"
                                                            width="245" wmode="transparent"></embed>
                                                    </object>
                                                </div>--%>
                                            </telerik:RadCodeBlock>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadHtmlChart ID="RadHtmlChartRequiredHoursVsTotalHoursChart" runat="server">

                                            </telerik:RadHtmlChart>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadHtmlChart ID="RadHtmlChartDirectHoursGoalVsDirectHoursChart" runat="server">

                                            </telerik:RadHtmlChart>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadHtmlChart ID="RadHtmlChartBillableHoursGoalVsBillableHoursChart" runat="server">

                                            </telerik:RadHtmlChart>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadHtmlChart ID="RadHtmlChartDirectHoursVsBillableHoursChart" runat="server">

                                            </telerik:RadHtmlChart>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="pnlDashProdDetail" runat="server" Visible="false">
                        <tr>
                            <td width="30%">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong>Indirect Hours Vs. Direct Hours</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadHtmlChart ID="RadHtmlChartIndirectHoursVsDirectPieChart" runat="server" Height="300" Width="400">

                                            </telerik:RadHtmlChart>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="70%">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong>Direct Hours by Type</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadHtmlChart ID="RadHtmlChartDirectHourByTypePieChart" runat="server" Height="300" Width="400">

                                            </telerik:RadHtmlChart>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="30%">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong>Non Direct Hours by Category</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadHtmlChart ID="RadHtmlChartNonDirectHoursByCategoryPieChart" runat="server" Height="300" Width="400">

                                            </telerik:RadHtmlChart>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="70%">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong>Direct Hours By Client</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadHtmlChart ID="RadHtmlChartDirectHoursByClientPieChart" runat="server" Height="300" Width="595">

                                            </telerik:RadHtmlChart>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="pnlDashProdEmp" runat="server" Visible="false">
                        <%--<tr >
                                <td align="left"  colspan="4">
                                    &nbsp;&nbsp;<strong><asp:Label   ID="Label2" runat="server" Text="Productivity Employee"></asp:Label></strong>
                                </td>
                            </tr>--%>
                        <tr>
                            <td colspan="4" align="center">
                                <telerik:RadGrid ID="RadGridProductivity" runat="server" AutoGenerateColumns="False"
                                    GridLines="Both"   Width="99%">
                                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                        <Selecting AllowRowSelect="True" />
                                    </ClientSettings>
                                    <MasterTableView DataKeyNames="EMP_CODE" ShowFooter="true">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee" UniqueName="column2">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DP_TM_DESC" HeaderText="Department" UniqueName="column22">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="STD_HRS" HeaderText="Required Hours" UniqueName="column3"
                                                DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DIRECT_GOAL" HeaderText="Direct Hours Goal" UniqueName="column34"
                                                DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="GOAL" HeaderText="Billable Hours Goal" UniqueName="column4"
                                                DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="BILLABLE_HOURS" HeaderText="Billable Hours" UniqueName="column5"
                                                DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NONBILLABLE_HOURS" HeaderText="Non Billable Hours"
                                                UniqueName="column6" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="AGENCY" HeaderText="Agency Hours" UniqueName="column8"
                                                DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NEW_BUSINESS" HeaderText="New Business Hours"
                                                UniqueName="column18" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TOTAL_DIRECT" HeaderText="Total Direct Hours"
                                                UniqueName="column7" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NON_PROD_HOURS" HeaderText="Non Direct Hours"
                                                UniqueName="column9" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <%--<telerik:GridBoundColumn DataField="TOTAL_NON_PROD" HeaderText="Total Non Productive" UniqueName="column10">
                                                    </telerik:GridBoundColumn>--%>
                                            <telerik:GridBoundColumn DataField="TOTAL_HOURS" HeaderText="Total Hours" UniqueName="column11"
                                                DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="VARIANCE" HeaderText="Variance" UniqueName="column12"
                                                DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PERCENT_DIRECT" HeaderText="% Direct" UniqueName="column13"
                                                DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PERCENT_NONDIRECT" HeaderText="% Non Direct"
                                                UniqueName="column14" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="REQUIRED_HOURS" HeaderText="% of Required Hours"
                                                UniqueName="column16" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PERCENT_DIRECT_GOAL" HeaderText="% of Direct Hours Goal"
                                                UniqueName="column17" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PERCENT_BILLABLE" HeaderText="% of Billable Hours Goal"
                                                UniqueName="column15" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
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
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="pnlDashReal" runat="server" Visible="false">
                        <tr>
                            <td width="25%">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong>Direct Hours Goal vs. Billed Hours</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadCodeBlock ID="RadCodeBlock14" runat="server">
                                                <asp:Literal ID="Literal15" runat="server"></asp:Literal>
                                                <%--<div id="Div16" style="text-align: center">
                                                    <object id="Object15" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="<%= Request.Url.Scheme %>://fpdownload.adobe.com/pub/shockwave/cabs/flash/swflash.cab"
                                                        height="150" width="245">
                                                        <param name="movie" value="Flash/AngularGauge.swf?chartWidth=245&chartHeight=150" />
                                                        <param name="FlashVars" value="&dataXML=<%= WriteXMLGaugeDirectGoalvsBilled %>" />
                                                        <param name="quality" value="high" />
                                                        <embed flashvars="&dataXML=<%= WriteXMLGaugeDirectGoalvsBilled %>" height="150" name="MSColumn3D"
                                                            pluginspage="<%= Request.Url.Scheme %>://get.adobe.com/flashplayer/"
                                                            quality="high" src="Flash/AngularGauge.swf" type="application/x-shockwave-flash"
                                                            width="245" wmode="transparent"></embed>
                                                    </object>
                                                </div>--%>
                                            </telerik:RadCodeBlock>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="25%">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong>Direct Hours vs. Billed Hours</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadCodeBlock ID="RadCodeBlock12" runat="server">
                                                <asp:Literal ID="Literal16" runat="server"></asp:Literal>
                                                <%--<div id="Div14" style="text-align: center">
                                                    <object id="Object13" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="<%= Request.Url.Scheme %>://fpdownload.adobe.com/pub/shockwave/cabs/flash/swflash.cab"
                                                        height="150" width="245">
                                                        <param name="movie" value="Flash/AngularGauge.swf?chartWidth=245&chartHeight=150" />
                                                        <param name="FlashVars" value="&dataXML=<%= WriteXMLGaugeBilledvsDirect %>" />
                                                        <param name="quality" value="high" />
                                                        <embed flashvars="&dataXML=<%= WriteXMLGaugeBilledvsDirect %>" height="150" name="MSColumn3D"
                                                            pluginspage="<%= Request.Url.Scheme %>://get.adobe.com/flashplayer/"
                                                            quality="high" src="Flash/AngularGauge.swf" type="application/x-shockwave-flash"
                                                            width="245" wmode="transparent"></embed>
                                                    </object>
                                                </div>--%>
                                            </telerik:RadCodeBlock>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="25%">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong>Billable Hours Goal vs. Billed Hours</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadCodeBlock ID="RadCodeBlock15" runat="server">
                                                <asp:Literal ID="Literal17" runat="server"></asp:Literal>
                                                <%--<div id="Div17" style="text-align: center">
                                                    <object id="Object16" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="<%= Request.Url.Scheme %>://fpdownload.adobe.com/pub/shockwave/cabs/flash/swflash.cab"
                                                        height="150" width="245">
                                                        <param name="movie" value="Flash/AngularGauge.swf?chartWidth=245&chartHeight=150" />
                                                        <param name="FlashVars" value="&dataXML=<%= WriteXMLGaugeBilledvsGoal %>" />
                                                        <param name="quality" value="high" />
                                                        <embed flashvars="&dataXML=<%= WriteXMLGaugeBilledvsGoal %>" height="150" name="MSColumn3D"
                                                            pluginspage="<%= Request.Url.Scheme %>://get.adobe.com/flashplayer/"
                                                            quality="high" src="Flash/AngularGauge.swf" type="application/x-shockwave-flash"
                                                            width="245" wmode="transparent"></embed>
                                                    </object>
                                                </div>--%>
                                            </telerik:RadCodeBlock>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="25%">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong>Billable Hours vs. Billed Hours</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadCodeBlock ID="RadCodeBlock13" runat="server">
                                                <asp:Literal ID="Literal18" runat="server"></asp:Literal>
                                                <%--<div id="Div15" style="text-align: center">
                                                    <object id="Object14" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="<%= Request.Url.Scheme %>://fpdownload.adobe.com/pub/shockwave/cabs/flash/swflash.cab"
                                                        height="150" width="245">
                                                        <param name="movie" value="Flash/AngularGauge.swf?chartWidth=245&chartHeight=150" />
                                                        <param name="FlashVars" value="&dataXML=<%= WriteXMLGaugeBilledvsBillable %>" />
                                                        <param name="quality" value="high" />
                                                        <embed flashvars="&dataXML=<%= WriteXMLGaugeBilledvsBillable %>" height="150" name="MSColumn3D"
                                                            pluginspage="<%= Request.Url.Scheme %>://get.adobe.com/flashplayer/"
                                                            quality="high" src="Flash/AngularGauge.swf" type="application/x-shockwave-flash"
                                                            width="245" wmode="transparent"></embed>
                                                    </object>
                                                </div>--%>
                                            </telerik:RadCodeBlock>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadHtmlChart ID="RadHtmlChartDirectHoursGoalVsBilledHoursChart" runat="server" Width="245" Height="350">

                                            </telerik:RadHtmlChart>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadHtmlChart ID="RadHtmlChartDirectHoursVsBilledHoursChart" runat="server" Width="245" Height="350">

                                            </telerik:RadHtmlChart>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadHtmlChart ID="RadHtmlChartBillableHoursGoalVsBilledHoursChart" runat="server" Width="245" Height="350">

                                            </telerik:RadHtmlChart>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadHtmlChart ID="RadHtmlChartBillableHoursVsBilledHoursChart" runat="server" Width="245" Height="350">

                                            </telerik:RadHtmlChart>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="pnlDashRealDetail" runat="server" Visible="false">
                        <tr>
                            <td width="50%" valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<asp:Label   ID="lblClient" runat="server"><strong>Client Totals (Amounts)</strong></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadHtmlChart ID="RadHtmlChartClientTotalsChart" runat="server" Width="500" Height="350">

                                            </telerik:RadHtmlChart>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="50%" valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong>Percent Billed by Client</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadHtmlChart ID="RadHtmlChartPercentBilledByClientPieChart" runat="server" Width="600" Height="350">
                                                
                                            </telerik:RadHtmlChart>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" colspan="2">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong>Realization By Client</strong>&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <%--<asp:UpdatePanel ID="pnlGrid" runat="server">
                                        <ContentTemplate>--%>
                                            <telerik:RadGrid ID="RadGridAvgHourly" runat="server" AutoGenerateColumns="False"
                                                GridLines="Both"  >
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="CLIENT, CL_NAME">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="CLIENT" HeaderText="Client" UniqueName="column1"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" UniqueName="column2"
                                                            ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <%--<telerik:GridBoundColumn DataField="DIVISION" HeaderText="Division" UniqueName="column3" Visible="false">
                                                    </telerik:GridBoundColumn>--%>
                                                        <%--<telerik:GridBoundColumn DataField="DIV_NAME" HeaderText="Division" UniqueName="column4" ItemStyle-HorizontalAlign="Left">
                                                    </telerik:GridBoundColumn>--%>
                                                        <%--<telerik:GridBoundColumn DataField="PRODUCT" HeaderText="Product" UniqueName="column5" Visible="false">
                                                    </telerik:GridBoundColumn>--%>
                                                        <%--<telerik:GridBoundColumn DataField="PRD_DESCRIPTION" HeaderText="Product" UniqueName="column6" ItemStyle-HorizontalAlign="Left">
                                                    </telerik:GridBoundColumn>--%>
                                                        <telerik:GridBoundColumn DataField="PERCENT_WRITE" HeaderText="Percent Write Up/Down"
                                                            UniqueName="column7" DataFormatString="{0:#,##0.00}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERCENT_BILLED" HeaderText="Percent Billed" UniqueName="column8"
                                                            DataFormatString="{0:#,##0.00}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="AVG_RATE_BILLED" HeaderText="Average Hourly Rate Billed"
                                                            UniqueName="column10" DataFormatString="{0:#,##0.00}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="AVG_RATE_ACHIEVED" HeaderText="Average Hourly Rate Achieved"
                                                            UniqueName="column9" DataFormatString="{0:#,##0.00}">
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
                                            <telerik:RadGrid ID="RadGridAvgHourlyPrd" runat="server" AutoGenerateColumns="False"
                                                GridLines="Both"  >
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="CLIENT,DIVISION,PRODUCT">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="CLIENT" HeaderText="Client" UniqueName="column1"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" UniqueName="column2"
                                                            ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIVISION" HeaderText="Division" UniqueName="column3"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIV_NAME" HeaderText="Division" UniqueName="column4"
                                                            ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PRODUCT" HeaderText="Product" UniqueName="column5"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PRD_DESCRIPTION" HeaderText="Product" UniqueName="column6"
                                                            ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERCENT_WRITE" HeaderText="Percent Write Up/Down"
                                                            UniqueName="column7" DataFormatString="{0:#,##0.00}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERCENT_BILLED" HeaderText="Percent Billed" UniqueName="column8"
                                                            DataFormatString="{0:#,##0.00}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="AVG_RATE_BILLED" HeaderText="Average Hourly Rate Billed"
                                                            UniqueName="column10" DataFormatString="{0:#,##0.00}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="AVG_RATE_ACHIEVED" HeaderText="Average Hourly Rate Achieved"
                                                            UniqueName="column9" DataFormatString="{0:#,##0.00}">
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
                                            <%--</ContentTemplate>
                                    </asp:UpdatePanel> --%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="pnlDashRealFee" runat="server" Visible="false">
                        <tr>
                            <td width="100%" valign="top" colspan="4">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<asp:Label   ID="Label1" runat="server"><strong>Fee Amounts</strong></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="middle">
                                            
                                            <div id="clientTotalsLinearGauge" style="width: 800px; height: 100px;"></div>

                                            <telerik:RadScriptBlock ID="radScriptBlockLinearGauge" runat="server">
                                                <script type="text/javascript">
                                                    function CreateChart(chartOptions) {
                                                        var obj = JSON.parse(chartOptions);
                                                        var ccChart = new FusionCharts(obj);
                                                        ccChart.setTransparent(true);
                                                        ccChart.render();
                                                    }
                                                </script>
                                            </telerik:RadScriptBlock>
                                                
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" colspan="4">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            &nbsp;&nbsp;<strong>Fee Amounts By Client</strong>&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <%--<asp:UpdatePanel ID="pnlGrid" runat="server">
                                        <ContentTemplate>--%>
                                            <telerik:RadGrid ID="RadGridFee" runat="server" AutoGenerateColumns="False" GridLines="Both"
                                                 >
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="CLIENT, CL_NAME">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="CLIENT" HeaderText="Client" UniqueName="column1"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" UniqueName="column2"
                                                            ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FEE_AMOUNT" HeaderText="Fee" UniqueName="column7"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FEE_TIME_AMOUNT" HeaderText="Time" UniqueName="column8"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="" HeaderText="Variance" UniqueName="column10"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Left">
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
                                            <telerik:RadGrid ID="RadGridFeePrd" runat="server" AutoGenerateColumns="False" GridLines="Both"
                                                 >
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="CLIENT,DIVISION,PRODUCT">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="CLIENT" HeaderText="Client" UniqueName="column1"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" UniqueName="column2"
                                                            ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIVISION" HeaderText="Division" UniqueName="column3"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIV_NAME" HeaderText="Division" UniqueName="column4"
                                                            ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PRODUCT" HeaderText="Product" UniqueName="column5"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PRD_DESCRIPTION" HeaderText="Product" UniqueName="column9"
                                                            ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FEE_AMOUNT" HeaderText="Fee" UniqueName="column7"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FEE_TIME_AMOUNT" HeaderText="Time" UniqueName="column8"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="" HeaderText="Variance" UniqueName="column10"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Left">
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
                                            <%--</ContentTemplate>
                                    </asp:UpdatePanel> --%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="pnlDashRealClient" runat="server" Visible="false">
                        <%--<tr >
                                <td align="left"  colspan="4">
                                    &nbsp;&nbsp;<strong><asp:Label   ID="Label3" runat="server" Text="Realization"></asp:Label></strong>
                                </td>
                            </tr>--%>
                        <tr>
                            <td colspan="4">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <%--<tr >
                                            <td align="left"  colspan="4">
                                                &nbsp;&nbsp;<strong>Client Detail</strong>&nbsp;&nbsp;
                                            </td>
                                        </tr>--%>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridCl" runat="server" AutoGenerateColumns="False" GridLines="Both"
                                                 >
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="CLIENT">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" UniqueName="column1"
                                                            ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CLIENT" HeaderText="ClientCode" UniqueName="column1"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLABLE_HOURS" HeaderText="Billable Hours" UniqueName="column4"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLABLE_AMT" HeaderText="Billable Amount" UniqueName="column5"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECT_NONBILL_HOURS" HeaderText="Non Billable Hours"
                                                            UniqueName="column8" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECT_NONBILL_AMT" HeaderText="Non Billable Amount"
                                                            UniqueName="column9" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}">
                                                        </telerik:GridBoundColumn>                                                                                                            
                                                        <telerik:GridBoundColumn DataField="AGENCY_HOURS" HeaderText="Agency Hours" UniqueName="column28"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>                                                                                                        
                                                        <telerik:GridBoundColumn DataField="AGENCY_AMOUNT" HeaderText="Agency Amount" UniqueName="column29"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="NEW_BUS_HOURS" HeaderText="New Business Hours"
                                                            UniqueName="column30" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="NEW_BUS_AMOUNT" HeaderText="New Business Amount"
                                                            UniqueName="column31" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" >
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="TOTAL_DIRECT_HOURS" HeaderText="Total Hours"
                                                            UniqueName="column4" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="TOTAL_DIRECT_AMT" HeaderText="Total Amount" UniqueName="column5"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLED_HOURS" HeaderText="Billed Hours" UniqueName="column4"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLED_AMT" HeaderText="Billed Amount" UniqueName="column5"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="WIP_HOURS" HeaderText="WIP Hours" UniqueName="column6"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="WIP_AMT" HeaderText="WIP Amount" UniqueName="column7"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="MARK_UP_DOWN_AMT" HeaderText="Write Up/Down Amount"
                                                            UniqueName="column7" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERCENT_WRITE" HeaderText="Percent Write Up/Down"
                                                            UniqueName="column6" DataFormatString='{0:#,##0.00}%' ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERCENT_BILLED" HeaderText="Percent Billed" UniqueName="column6"
                                                            DataFormatString='{0:#,##0.00}%' ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="AVG_HOURLY_RATE_BILLED" HeaderText="Average Hourly Rate Billed"
                                                            UniqueName="column8" DataFormatString='{0:#,##0.00}' ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="AVG_HOURLY_RATE_ACHIEVED" HeaderText="Average Hourly Rate Achieved"
                                                            UniqueName="column9" DataFormatString='{0:#,##0.00}' ItemStyle-HorizontalAlign="Right">
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
                                            <telerik:RadGrid ID="RadGridClientDetail" runat="server" AutoGenerateColumns="False"
                                                GridLines="Both"  >
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="CLIENT,DIVISION,PRODUCT">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" UniqueName="column1"
                                                            ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CLIENT" HeaderText="ClientCode" UniqueName="column1"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIVISION" HeaderText="Division" UniqueName="column3"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIV_NAME" HeaderText="Division" UniqueName="column4"
                                                            ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PRODUCT" HeaderText="Product" UniqueName="column5"
                                                            Visible="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PRD_DESCRIPTION" HeaderText="Product" UniqueName="column6"
                                                            ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLABLE_HOURS" HeaderText="Billable Hours" UniqueName="column4"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:n}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLABLE_AMT" HeaderText="Billable Amount" UniqueName="column5"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:n}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECT_NONBILL_HOURS" HeaderText="Non Billable Hours"
                                                            UniqueName="column8" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:n}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECT_NONBILL_AMT" HeaderText="Non Billable Amount"
                                                            UniqueName="column9" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:n}">
                                                        </telerik:GridBoundColumn>                                                                                                            
                                                        <telerik:GridBoundColumn DataField="AGENCY_HOURS" HeaderText="Agency Hours" UniqueName="column28"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>                                                                                                        
                                                        <telerik:GridBoundColumn DataField="AGENCY_AMOUNT" HeaderText="Agency Amount" UniqueName="column29"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="NEW_BUS_HOURS" HeaderText="New Business Hours"
                                                            UniqueName="column30" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="NEW_BUS_AMOUNT" HeaderText="New Business Amount"
                                                            UniqueName="column31" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" >
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="TOTAL_DIRECT_HOURS" HeaderText="Total Hours"
                                                            UniqueName="column4" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:n}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="TOTAL_DIRECT_AMT" HeaderText="Total Amount" UniqueName="column5"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:n}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLED_HOURS" HeaderText="Billed Hours" UniqueName="column4"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:n}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLED_AMT" HeaderText="Billed Amount" UniqueName="column5"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:n}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="WIP_HOURS" HeaderText="WIP Hours" UniqueName="column6"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:n}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="WIP_AMT" HeaderText="WIP Amount" UniqueName="column7"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:n}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="MARK_UP_DOWN_AMT" HeaderText="Write Up/Down Amount"
                                                            UniqueName="column7" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:n}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERCENT_WRITE" HeaderText="Percent Write Up/Down"
                                                            UniqueName="column6" DataFormatString='{0:#,##0.00}%' ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERCENT_BILLED" HeaderText="Percent Billed" UniqueName="column6"
                                                            DataFormatString='{0:#,##0.00}%' ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="AVG_HOURLY_RATE_BILLED" HeaderText="Average Hourly Rate Billed"
                                                            UniqueName="column8" DataFormatString='{0:#,##0.00}' ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="AVG_HOURLY_RATE_ACHIEVED" HeaderText="Average Hourly Rate Achieved"
                                                            UniqueName="column9" DataFormatString='{0:#,##0.00}' ItemStyle-HorizontalAlign="Right">
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
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="pnlDashRealEmp" runat="server" Visible="false">
                        <%--<tr >
                                <td align="left"  colspan="4">
                                    &nbsp;&nbsp;<strong><asp:Label   ID="Label4" runat="server" Text="Realization"></asp:Label></strong>
                                </td>
                            </tr>--%>
                        <tr>
                            <td colspan="4">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <%--<tr >
                                            <td align="left"  colspan="4">
                                                &nbsp;&nbsp;<strong>Employee Detail</strong>
                                            </td>
                                        </tr>--%>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridRealization" runat="server" AutoGenerateColumns="False"
                                                GridLines="Both"  >
                                                <MasterTableView ShowFooter="true">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee" UniqueName="column1"
                                                            ItemStyle-HorizontalAlign="Left">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DP_TM_DESC" HeaderText="Department" UniqueName="column22">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECT_HRS_GOAL" HeaderText="Direct Hours Goal" UniqueName="column33"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="GOAL" HeaderText="Billable Hours Goal" UniqueName="column3"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLABLE_HOURS" HeaderText="Billable Hours" UniqueName="column4"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLABLE_AMT" HeaderText="Billable Amount" UniqueName="column5"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECT_NONBILL_HOURS" HeaderText="Non Billable Hours"
                                                            UniqueName="column8" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECT_NONBILL_AMT" HeaderText="Non Billable Amount"
                                                            UniqueName="column9" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </telerik:GridBoundColumn>                                                    
                                                        <telerik:GridBoundColumn DataField="AGENCY_HOURS" HeaderText="Agency Hours" UniqueName="column28"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" Aggregate="Sum">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        </telerik:GridBoundColumn>                                                                                                        
                                                        <telerik:GridBoundColumn DataField="AGENCY_AMOUNT" HeaderText="Agency Amount" UniqueName="column29"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" Aggregate="Sum">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="NEW_BUS_HOURS" HeaderText="New Business Hours"
                                                            UniqueName="column30" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" Aggregate="Sum">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="NEW_BUS_AMOUNT" HeaderText="New Business Amount"
                                                            UniqueName="column31" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" Aggregate="Sum">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="TOTAL_DIRECT_HOURS" HeaderText="Total Hours"
                                                            UniqueName="column6" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="TOTAL_DIRECT_AMT" HeaderText="Total Amount" UniqueName="column7"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLED_HOURS" HeaderText="Billed Hours" UniqueName="column18"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLED_AMT" HeaderText="Billed Amount" UniqueName="column11"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="WIP_HOURS" HeaderText="WIP Hours" UniqueName="column12"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="WIP_AMT" HeaderText="WIP Amount" UniqueName="column13"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="MARK_UP_DOWN_AMT" HeaderText="Write Up/Down Amount"
                                                            UniqueName="column14" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERCENT_WRITE" HeaderText="Percent Write Up/Down"
                                                            UniqueName="column6" DataFormatString='{0:#,##0.00}%' ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERCENT_BILLED" HeaderText="Percent Billed" UniqueName="column6"
                                                            DataFormatString='{0:#,##0.00}%' ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERCENT_BILLED_DIRECT_GOAL" HeaderText="Percent Billed of Direct Hours Goal"
                                                            UniqueName="column67" DataFormatString='{0:#,##0.00}%' ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERCENT_BILLED_GOAL" HeaderText="Percent Billed of Goal"
                                                            UniqueName="column6" DataFormatString='{0:#,##0.00}%' ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="AVG_HOURLY_RATE_BILLED" HeaderText="Average Hourly Rate Billed"
                                                            UniqueName="column8" DataFormatString='{0:#,##0.00}' ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="AVG_HOURLY_RATE_ACHIEVED" HeaderText="Average Hourly Rate Achieved"
                                                            UniqueName="column9" DataFormatString='{0:#,##0.00}' ItemStyle-HorizontalAlign="Right">
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
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="pnlDashRealJob" runat="server" Visible="false">
                        <%--<tr >
                                <td align="left"  colspan="4">
                                    &nbsp;&nbsp;<strong><asp:Label   ID="Label2" runat="server" Text="Realization"></asp:Label></strong>
                                </td>
                            </tr>--%>
                        <tr>
                            <td colspan="4">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="4">
                                            &nbsp;&nbsp;<strong>Job Detail</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridClientTime" runat="server" AutoGenerateColumns="False"
                                                GridLines="Both"   Width="100%">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="JOB_NUMBER, JOB_COMPONENT_NBR">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="JOB_NUMBER" HeaderText="Job" UniqueName="column1">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="JOB_DESC" HeaderText="Description" UniqueName="column2">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="JOB_COMPONENT_NBR" HeaderText="Component" UniqueName="column3">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="JOB_COMP_DESC" HeaderText="Description" UniqueName="column4">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLABLE_HOURS" HeaderText="Billable Hours" UniqueName="column4"
                                                            DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLABLE_AMOUNT" HeaderText="Billable Amount"
                                                            UniqueName="column5" DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECT_NONBILL_HOURS" HeaderText="Non Billable Hours"
                                                            UniqueName="column8" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:n}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECT_NONBILL_AMT" HeaderText="Non Billable Amount"
                                                            UniqueName="column9" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:n}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="TOTAL_DIRECT_HOURS" HeaderText="Total Hours"
                                                            UniqueName="column4" DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="TOTAL_DIRECT_AMT" HeaderText="Total Amount" UniqueName="column5"
                                                            DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLED_HOURS" HeaderText="Billed Hours" UniqueName="column4"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLED_AMT" HeaderText="Billed Amount" UniqueName="column5"
                                                            DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="WIP_HOURS" HeaderText="WIP Hours" UniqueName="column6"
                                                            DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="WIP_AMT" HeaderText="WIP Amount" UniqueName="column7"
                                                            DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="MARK_UP_DOWN_AMT" HeaderText="Write Up/Down Amount"
                                                            UniqueName="column7" DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERCENT_WRITE" HeaderText="Percent Write Up/Down"
                                                            UniqueName="column6" DataFormatString='{0:#,##0.00}%' ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERCENT_BILLED" HeaderText="Percent Billed" UniqueName="column6"
                                                            DataFormatString='{0:#,##0.00}%' ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="AVG_HOURLY_RATE_BILLED" HeaderText="Average Hourly Rate Billed"
                                                            UniqueName="column8" DataFormatString='{0:#,##0.00}' ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="AVG_HOURLY_RATE_ACHIEVED" HeaderText="Average Hourly Rate Achieved"
                                                            UniqueName="column9" DataFormatString='{0:#,##0.00}' ItemStyle-HorizontalAlign="Right">
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
                                                    <%--<DetailTables>
                                                    <telerik:GridTableView BorderWidth="1" AllowPaging="False" AllowSorting="True" DataKeyNames="ACTUAL_HOURS"
                                                        Width="100%">
                                                        <Columns>
                                                            
                                                        </Columns>
                                                    </telerik:GridTableView>
                                                </DetailTables>--%>
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="pnlDashRealJobTime" runat="server" Visible="false">
                        <tr>
                            <td colspan="4">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="4">
                                            &nbsp;&nbsp;<strong>Job/Employee Detail</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridJobTime" runat="server" AutoGenerateColumns="False" GridLines="Both"
                                                 >
                                                <MasterTableView DataKeyNames="DP_TM_CODE, EMP_CODE">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="DP_TM_DESC" HeaderText="Department" UniqueName="column1">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMP_DESC" HeaderText="Employee" UniqueName="column1">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLABLE_HOURS" HeaderText="Billable Hours" UniqueName="column4"
                                                            DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLABLE_AMOUNT" HeaderText="Billable Amount"
                                                            UniqueName="column5" DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECT_NONBILL_HOURS" HeaderText="Non Billable Hours"
                                                            UniqueName="column8" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:n}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECT_NONBILL_AMT" HeaderText="Non Billable Amount"
                                                            UniqueName="column9" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:n}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="TOTAL_DIRECT_HOURS" HeaderText="Total Hours"
                                                            UniqueName="column4" DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="TOTAL_DIRECT_AMT" HeaderText="Total Amount" UniqueName="column5"
                                                            DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLED_HOURS" HeaderText="Billed Hours" UniqueName="column4"
                                                            DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLED_AMT" HeaderText="Billed Amount" UniqueName="column5"
                                                            DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="WIP_HOURS" HeaderText="WIP Hours" UniqueName="column6"
                                                            DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="WIP_AMT" HeaderText="WIP Amount" UniqueName="column7"
                                                            DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="MARK_UP_DOWN_AMT" HeaderText="Write Up/Down Amount"
                                                            UniqueName="column7" DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERCENT_WRITE" HeaderText="Percent Write Up/Down"
                                                            UniqueName="column6" DataFormatString='{0:#,##0.00}%' ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PERCENT_BILLED" HeaderText="Percent Billed" UniqueName="column6"
                                                            DataFormatString='{0:#,##0.00}%' ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="AVG_HOURLY_RATE_BILLED" HeaderText="Average Hourly Rate Billed"
                                                            UniqueName="column8" DataFormatString='{0:#,##0.00}' ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="AVG_HOURLY_RATE_ACHIEVED" HeaderText="Average Hourly Rate Achieved"
                                                            UniqueName="column9" DataFormatString='{0:#,##0.00}' ItemStyle-HorizontalAlign="Right">
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
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
    </table>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
    <div id="divPrint" runat="server" visible="false" style="padding: 12px; text-align: center">
        <asp:Button ID="BtnPrint" runat="server" Text="Print" />&nbsp;
        <asp:Button ID="BtnClose" runat="server" Text="Close" OnClientClick="window.close();" />
    </div>
    </div>
</asp:Content>
