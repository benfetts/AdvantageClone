<%@ Page AutoEventWireup="false" CodeBehind="DashboardRealizationJob.aspx.vb" Inherits="Webvantage.DashboardRealizationJob"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Employee Utilization" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
    <div class="telerik-aqua-body">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td valign="top">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="98%">
                        <tr>
                            <td colspan="4">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td runat="Server" id="Td1" colspan="2">
                                            <telerik:RadToolBar ID="RadToolbarDash" runat="server" AutoPostBack="True" Width="100%">
                                                <Items>
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Selection" Value="Selection"
                                                        ToolTip="" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Productivity" Value="Productivity"
                                                        Hidden="False" ToolTip="" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Summary" Value="Summary"
                                                        ToolTip="" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Detail" Value="Detail"
                                                        Hidden="False" ToolTip="" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Fee" Value="Fee" Hidden="False"
                                                        ToolTip="" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Client" Value="Client"
                                                        ToolTip="" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Employee" Value="Employee"
                                                        ToolTip="" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                </Items>
                                            </telerik:RadToolBar>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="4">
                                            &nbsp;&nbsp;<strong style="font-size: large">Job Detail</strong>&nbsp;&nbsp;
                                            <asp:ImageButton ID="butExport" runat="server" SkinID="ImageButtonExportExcel" />&nbsp;&nbsp;
                                            <asp:ImageButton ID="ImageButtonPrint" runat="server" SkinID="ImageButtonPrint" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridClientTime" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" AllowSorting="true" EnableEmbeddedSkins="True" Width="100%">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="JOB_NUMBER, JOB_COMPONENT_NBR" AllowMultiColumnSorting="true">
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
                                                            DataFormatString="{0:#,##0.000}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLABLE_AMOUNT" HeaderText="Billable Amount"
                                                            UniqueName="column5" DataFormatString="{0:#,##0.000}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECT_NONBILL_HOURS" HeaderText="Non Billable Hours"
                                                            UniqueName="column8" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.000}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECT_NONBILL_AMT" HeaderText="Non Billable Amount"
                                                            UniqueName="column9" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.000}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="TOTAL_DIRECT_HOURS" HeaderText="Total Hours"
                                                            UniqueName="column4" DataFormatString="{0:#,##0.000}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="TOTAL_DIRECT_AMT" HeaderText="Total Amount" UniqueName="column5"
                                                            DataFormatString="{0:#,##0.000}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLED_HOURS" HeaderText="Billed Hours" UniqueName="column4"
                                                            DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLED_AMT" HeaderText="Billed Amount" UniqueName="column5"
                                                            DataFormatString="{0:#,##0.000}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="WIP_HOURS" HeaderText="WIP Hours" UniqueName="column6"
                                                            DataFormatString="{0:#,##0.000}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="WIP_AMT" HeaderText="WIP Amount" UniqueName="column7"
                                                            DataFormatString="{0:#,##0.000}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="MARK_UP_DOWN_AMT" HeaderText="Write Up/Down Amount"
                                                            UniqueName="column7" DataFormatString="{0:#,##0.000}" ItemStyle-HorizontalAlign="Right">
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
                        <tr>
                            <td colspan="4">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" colspan="4">
                                            &nbsp;&nbsp;<strong style="font-size: large">Job/Employee Detail</strong>&nbsp;&nbsp;
                                            <asp:ImageButton ID="butExport2" runat="server" SkinID="ImageButtonExportExcel" />&nbsp;&nbsp;
                                            <asp:ImageButton ID="ImageButtonPrint2" runat="server" SkinID="ImageButtonPrint" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridJobTime" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                AllowSorting="true" EnableEmbeddedSkins="True">
                                                <MasterTableView DataKeyNames="DP_TM_CODE, EMP_CODE" AllowMultiColumnSorting="true">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="DP_TM_DESC" HeaderText="Department" UniqueName="column1">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMP_DESC" HeaderText="Employee" UniqueName="column1">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLABLE_HOURS" HeaderText="Billable Hours" UniqueName="column4"
                                                            DataFormatString="{0:#,##0.000}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLABLE_AMOUNT" HeaderText="Billable Amount"
                                                            UniqueName="column5" DataFormatString="{0:#,##0.000}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECT_NONBILL_HOURS" HeaderText="Non Billable Hours"
                                                            UniqueName="column8" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.000}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECT_NONBILL_AMT" HeaderText="Non Billable Amount"
                                                            UniqueName="column9" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.000}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="TOTAL_DIRECT_HOURS" HeaderText="Total Hours"
                                                            UniqueName="column4" DataFormatString="{0:#,##0.000}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="TOTAL_DIRECT_AMT" HeaderText="Total Amount" UniqueName="column5"
                                                            DataFormatString="{0:#,##0.000}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLED_HOURS" HeaderText="Billed Hours" UniqueName="column4"
                                                            DataFormatString="{0:#,##0.000}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLED_AMT" HeaderText="Billed Amount" UniqueName="column5"
                                                            DataFormatString="{0:#,##0.000}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="WIP_HOURS" HeaderText="WIP Hours" UniqueName="column6"
                                                            DataFormatString="{0:#,##0.000}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="WIP_AMT" HeaderText="WIP Amount" UniqueName="column7"
                                                            DataFormatString="{0:#,##0.000}" ItemStyle-HorizontalAlign="Right">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="MARK_UP_DOWN_AMT" HeaderText="Write Up/Down Amount"
                                                            UniqueName="column7" DataFormatString="{0:#,##0.000}" ItemStyle-HorizontalAlign="Right">
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
                    </table>
                </td>
            </tr>
        </table>
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
