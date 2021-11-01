<%@ Page AutoEventWireup="false" CodeBehind="ProjectHoursUsed_Render.aspx.vb" Inherits="Webvantage.ProjectHoursUsed_Render"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Dashboard Print" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left"  colspan="2">
                &nbsp;<asp:Label   ID="lblTitle" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <asp:Panel ID="pnlHours" runat="server" Visible="false">
                        <tr>
                            <td align="center">
                                <telerik:RadGrid ID="RadGridHours" runat="server" AutoGenerateColumns="false" EnableEmbeddedSkins="True"
                                    GridLines="Both" GroupingEnabled="true">
                                    <MasterTableView ShowFooter="true" ShowGroupFooter="true">
                                        <%--<GroupByExpressions>
                                            <telerik:GridGroupByExpression>
                                                <SelectFields>
                                                    <telerik:GridGroupByField FieldName="JOBPAD" HeaderText="Job" />
                                                    <telerik:GridGroupByField FieldName="COMPPAD" HeaderText="Comp" />
                                                </SelectFields>
                                                <GroupByFields>
                                                    <telerik:GridGroupByField FieldName="JobNum" />
                                                </GroupByFields>
                                            </telerik:GridGroupByExpression>
                                        </GroupByExpressions>--%>
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="column1">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelFooter" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="JobNum" HeaderText="Job Number" UniqueName="column2">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Job Name" HeaderText="Job Name" UniqueName="column3">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Component Number" HeaderText="Component Number"
                                                UniqueName="column4">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Component Name" HeaderText="Component Name" UniqueName="column5">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Client Code" HeaderText="Client Code" UniqueName="column6">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Client Name" HeaderText="Client Name" UniqueName="column7">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Division Code" HeaderText="Division Code" UniqueName="column8">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Division Name" HeaderText="Division Name" UniqueName="column9">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Product Code" HeaderText="Product Code" UniqueName="column10">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Product Name" HeaderText="Product Name" UniqueName="column11">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CMP_CODE" HeaderText="Campaign Code" UniqueName="column17">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CMP_NAME" HeaderText="Campaign Name" UniqueName="column18">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Employee Code" HeaderText="Employee Code" UniqueName="column12">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Employee Name" HeaderText="Employee Name" UniqueName="column13">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="HoursPosted" HeaderText="Hours Posted" UniqueName="column14" Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="HoursAllowed" HeaderText="Hours Assigned" UniqueName="column15" Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TotalHoursPosted" HeaderText="Total Hours Posted" Aggregate="Sum" DataFormatString="{0:#,##0.00}"
                                                UniqueName="column16">
                                            </telerik:GridBoundColumn>
                                            <%--<telerik:GridBoundColumn DataField="CMP_ID" HeaderText="Campaign Name" UniqueName="column19" Visible="false">
                                            </telerik:GridBoundColumn>--%>
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
                                <telerik:RadGrid ID="RadGridHoursNoGroup" runat="server" AutoGenerateColumns="false" EnableEmbeddedSkins="True"
                                    GridLines="Both" GroupingEnabled="true">
                                    <MasterTableView ShowFooter="true">                                        
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="Job Number" HeaderText="Job Number" UniqueName="column2" FooterText="Grand Total: ">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Job Name" HeaderText="Job Name" UniqueName="column3">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Component Number" HeaderText="Component Number"
                                                UniqueName="column4">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Component Name" HeaderText="Component Name" UniqueName="column5">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Client Code" HeaderText="Client Code" UniqueName="column6">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Client Name" HeaderText="Client Name" UniqueName="column7">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Division Code" HeaderText="Division Code" UniqueName="column8">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Division Name" HeaderText="Division Name" UniqueName="column9">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Product Code" HeaderText="Product Code" UniqueName="column10">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Product Name" HeaderText="Product Name" UniqueName="column11">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CMP_CODE" HeaderText="Campaign Code" UniqueName="column17">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CMP_NAME" HeaderText="Campaign Name" UniqueName="column18">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Employee Code" HeaderText="Employee Code" UniqueName="column12">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Employee Name" HeaderText="Employee Name" UniqueName="column13">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Hours Posted" HeaderText="Hours Posted" UniqueName="column14" Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Hours Allowed" HeaderText="Hours Assigned" UniqueName="column15" Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Total Hours Posted" HeaderText="Total Hours Posted" Aggregate="Sum" DataFormatString="{0:#,##0.00}"
                                                UniqueName="column16">
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
    </table>
    <p align="center" class="no-print">
        <asp:Button ID="BtnPrint" runat="server" CssClass="print-button" OnClientClick="window.print();window.close();"
            Text="Print" />&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnClose" runat="server" CssClass="print-button" OnClientClick="window.close();"
            Text="Close" />
    </p>
</asp:Content>