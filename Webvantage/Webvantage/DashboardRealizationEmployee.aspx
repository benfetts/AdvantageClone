<%@ Page AutoEventWireup="false" CodeBehind="DashboardRealizationEmployee.aspx.vb"
    Inherits="Webvantage.DashboardRealizationEmployee" Language="vb" MasterPageFile="~/ChildPage.Master"
    Title="Employee Utilization" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
    <div class="telerik-aqua-body">
        <div class="no-float-menu">
           
            <telerik:RadToolBar ID="RadToolbarDash" runat="server" AutoPostBack="True" Width="100%">
                <Items>
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolbarSelection" runat="server" ImageURL=""
                        Text="Selection" CommandName="Selection" ToolTip="" Value="Selection"
                        TabIndex="16" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolbarProd" runat="server" ImageURL=""
                        Text="Productivity" CommandName="Productivity" Hidden="False" Value="Productivity"
                        ToolTip="" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolbarButtonSummary" runat="server" ImageURL=""
                        Text="Summary" CommandName="Summary" ToolTip="" TabIndex="16" Value="Summary" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolbarButtonDetail" runat="server" ImageURL=""
                        Text="Detail" CommandName="Detail" Hidden="False" ToolTip="" Value="Detail" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolbarButtonFee" runat="server" ImageURL=""
                        Text="Fee" CommandName="Fee" Hidden="False" ToolTip="" Value="Fee" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolbarButtonClient" runat="server" ImageURL=""
                        Text="Client" CommandName="Client" ToolTip="" TabIndex="16" Value="Client" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolbarButtonEmployee" runat="server" ImageURL=""
                        Text="Employee" CommandName="Employee" ToolTip="" Value="Employee"
                        TabIndex="16" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                </Items>
            </telerik:RadToolBar>

        </div>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td valign="top">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td colspan="4">
                                   
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left" colspan="4">
                                        &nbsp;&nbsp;<strong style="font-size: large">Employee Detail</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top">
                                        <telerik:RadGrid ID="RadGridRealization" runat="server" AutoGenerateColumns="False"
                                            GridLines="None" AllowSorting="true" EnableEmbeddedSkins="True">
                                            <MasterTableView AllowMultiColumnSorting="true" ShowFooter="true">
                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee" UniqueName="column1"
                                                        ItemStyle-HorizontalAlign="Left" SortExpression="EMP_LNAME">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="DP_TM_DESC" HeaderText="Department" UniqueName="column2">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="DIRECT_HRS_GOAL" HeaderText="Direct Hours Goal" UniqueName="column3"
                                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="GOAL" HeaderText="Billable Hours Goal" UniqueName="column4"
                                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="BILLABLE_HOURS" HeaderText="Billable Hours" UniqueName="column5"
                                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="BILLABLE_AMT" HeaderText="Billable Amount" UniqueName="column6"
                                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="DIRECT_NONBILL_HOURS" HeaderText="Non Billable Hours"
                                                        UniqueName="column7" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="DIRECT_NONBILL_AMT" HeaderText="Non Billable Amount"
                                                        UniqueName="column8" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
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
                                                        UniqueName="column9" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="TOTAL_DIRECT_AMT" HeaderText="Total Amount" UniqueName="column10"
                                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="BILLED_HOURS" HeaderText="Billed Hours" UniqueName="column11"
                                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="BILLED_AMT" HeaderText="Billed Amount" UniqueName="column12"
                                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="WIP_HOURS" HeaderText="WIP Hours" UniqueName="column13"
                                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="WIP_AMT" HeaderText="WIP Amount" UniqueName="column14"
                                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="MARK_UP_DOWN_AMT" HeaderText="Write Up/Down Amount"
                                                        UniqueName="column15" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="PERCENT_WRITE" HeaderText="Percent Write Up/Down"
                                                        UniqueName="column16" DataFormatString='{0:#,##0.00}%' ItemStyle-HorizontalAlign="Right">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="PERCENT_BILLED" HeaderText="Percent Billed" UniqueName="column17"
                                                        DataFormatString='{0:#,##0.00}%' ItemStyle-HorizontalAlign="Right">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="PERCENT_BILLED_DIRECT_GOAL" HeaderText="Percent Billed of Direct Hours Goal"
                                                        UniqueName="column18" DataFormatString='{0:#,##0.00}%' ItemStyle-HorizontalAlign="Right">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="PERCENT_BILLED_GOAL" HeaderText="Percent Billed of Billable Hours Goal"
                                                        UniqueName="column19" DataFormatString='{0:#,##0.00}%' ItemStyle-HorizontalAlign="Right">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="AVG_HOURLY_RATE_BILLED" HeaderText="Average Hourly Rate Billed"
                                                        UniqueName="column20" DataFormatString='{0:#,##0.00}' ItemStyle-HorizontalAlign="Right">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="AVG_HOURLY_RATE_ACHIEVED" HeaderText="Average Hourly Rate Achieved"
                                                        UniqueName="column21" DataFormatString='{0:#,##0.00}' ItemStyle-HorizontalAlign="Right">
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
