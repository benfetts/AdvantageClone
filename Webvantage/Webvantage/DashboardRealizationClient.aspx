<%@ Page AutoEventWireup="false" CodeBehind="DashboardRealizationClient.aspx.vb"
    Inherits="Webvantage.DashboardRealizationClient" Language="vb" MasterPageFile="~/ChildPage.Master"
    Title="Employee Utilization" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <style>
         .telerik-aqua-body .RadToolBar {
                margin: 0 auto;
                margin-left: auto;
                margin-right: auto;
                display: block;
                
            }
    </style>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
    <div class="telerik-aqua-body">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td valign="top">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td colspan="4">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td runat="Server" id="Td1" colspan="2">
                                            <telerik:RadToolBar ID="RadToolbarDash" runat="server" AutoPostBack="True" Width="100%">
                                                <Items>
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton  ImageURL=""
                                                        Text="Selection" Value="Selection" ToolTip="" />
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
                                            &nbsp;&nbsp;<strong style="font-size: large">Client Detail</strong>&nbsp;&nbsp;
                                            <asp:CheckBox ID="cbShowProducts" runat="server" Text="Products" AutoPostBack="true" />&nbsp;&nbsp;
                                            <asp:ImageButton ID="butExport" runat="server" SkinID="ImageButtonExportExcel" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <telerik:RadGrid ID="RadGridCl" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                AllowSorting="true" EnableEmbeddedSkins="True">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="CLIENT" AllowMultiColumnSorting="true">
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
                                                GridLines="None" AllowSorting="true" EnableEmbeddedSkins="True">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="CLIENT,DIVISION,PRODUCT" AllowMultiColumnSorting="true">
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
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.000}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLABLE_AMT" HeaderText="Billable Amount" UniqueName="column5"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.000}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECT_NONBILL_HOURS" HeaderText="Non Billable Hours"
                                                            UniqueName="column8" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.000}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DIRECT_NONBILL_AMT" HeaderText="Non Billable Amount"
                                                            UniqueName="column9" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.000}">
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
                                                            UniqueName="column4" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.000}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="TOTAL_DIRECT_AMT" HeaderText="Total Amount" UniqueName="column5"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.000}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLED_HOURS" HeaderText="Billed Hours" UniqueName="column4"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.000}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BILLED_AMT" HeaderText="Billed Amount" UniqueName="column5"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.000}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="WIP_HOURS" HeaderText="WIP Hours" UniqueName="column6"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.000}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="WIP_AMT" HeaderText="WIP Amount" UniqueName="column7"
                                                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.000}">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="MARK_UP_DOWN_AMT" HeaderText="Write Up/Down Amount"
                                                            UniqueName="column7" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.000}">
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
                                &nbsp;
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
