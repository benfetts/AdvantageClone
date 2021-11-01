<%@ Page AutoEventWireup="false" CodeBehind="DashboardProductionEmployee.aspx.vb"
    Inherits="Webvantage.DashboardProductionEmployee" Language="vb" MasterPageFile="~/ChildPage.Master"
    Title="Employee Utilization" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
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
                                        <td runat="Server" id="Td1" align="left" valign="top">
                                            <telerik:RadToolBar ID="RadToolbarDashEmp" runat="server" AutoPostBack="True" Width="100%">
                                                <Items>
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Selection" Value="Selection"
                                                        ToolTip=""  />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Realization" Value="Realization"
                                                        ToolTip=""  />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Summary" Value="Summary"
                                                        ToolTip="" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Detail" Value="Detail"
                                                        Hidden="False"  ToolTip="" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton ImageUrl="" Text="Employee" Value="Employee"
                                                        ToolTip=""  />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                </Items>
                                            </telerik:RadToolBar>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <telerik:RadGrid ID="RadGridProductivity" runat="server" AutoGenerateColumns="False"
                                    GridLines="None" EnableEmbeddedSkins="True" Width="99%" AllowSorting="true">
                                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                        <Selecting AllowRowSelect="True" />
                                    </ClientSettings>
                                    <MasterTableView DataKeyNames="EMP_CODE" AllowMultiColumnSorting="true" ShowFooter="true">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee" UniqueName="column2" SortExpression="EMP_LNAME">
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
                                            <telerik:GridBoundColumn DataField="TOTAL_HOURS" HeaderText="Total Hours" UniqueName="column11"
                                                DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" Aggregate="Sum">
                                            <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="VARIANCE" HeaderText="Variance" UniqueName="column12"
                                                DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right">
                                            <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PERCENT_DIRECT" HeaderText="% Direct" UniqueName="column13"
                                                DataFormatString="{0:#,##0.00}%" ItemStyle-HorizontalAlign="Right">
                                            <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PERCENT_NONDIRECT" HeaderText="% Non Direct"
                                                UniqueName="column14" DataFormatString="{0:#,##0.00}%" ItemStyle-HorizontalAlign="Right">
                                            <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="REQUIRED_HOURS" HeaderText="% of Required Hours"
                                                UniqueName="column16" DataFormatString="{0:#,##0.00}%" ItemStyle-HorizontalAlign="Right">
                                            <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PERCENT_DIRECT_GOAL" HeaderText="% of Direct Hours Goal"
                                                UniqueName="column17" DataFormatString="{0:#,##0.00}%" ItemStyle-HorizontalAlign="Right">
                                            <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PERCENT_BILLABLE" HeaderText="% of Billable Hours Goal"
                                                UniqueName="column15" DataFormatString="{0:#,##0.00}%" ItemStyle-HorizontalAlign="Right">
                                            <FooterStyle HorizontalAlign="Right" />
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
    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
