<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="dtp_BudgetViewpoint.aspx.vb" Inherits="Webvantage.dtp_BudgetViewpoint" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
        <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
        <table align="center" cellpadding="2" cellspacing="0" width="98%">
            <tr>
                <td align="Left">
                    &nbsp;<asp:Label   ID="Label1" runat="server"></asp:Label>
                </td>
                <td align="right">
                    <asp:Label   ID="lblType" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table align="center" cellpadding="2" cellspacing="0" width="100%">
            <telerik:RadGrid ID="BVRadGrid" runat="server" AutoGenerateColumns="False" GridLines="None"
                EnableEmbeddedSkins="True" Width="98%">
                <MasterTableView AllowMultiColumnSorting="True" Width="99%">
                    <Columns>
                        <telerik:GridBoundColumn DataField="DESCRIPTION" HeaderText="Description" HeaderStyle-VerticalAlign="Bottom"
                            HeaderStyle-HorizontalAlign="Center" UniqueName="DESCRIPTION">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BUDGET_BILLING" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"
                            HeaderText="Budget<br/>Billing" HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Center"
                            UniqueName="BUDGET_BILLING">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BUDGET_GI" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"
                            HeaderText="Budget<br/>Gross Income" HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Center"
                            UniqueName="BUDGET_GI">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ACTUAL_BILLING" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"
                            HeaderText="Billed" HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Center"
                            UniqueName="ACTUAL_BILLING">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ACTUAL_GI" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"
                            HeaderText="Billed<br/>Gross Income" HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Center"
                            UniqueName="ACTUAL_GI">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VARIANCE_BILLING" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"
                            HeaderText="Variance<br/>Billing" HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Center"
                            UniqueName="VARIANCE_BILLING">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VARIANCE_GI" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"
                            HeaderText="Variance<br/>Gross Income" HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Center"
                            UniqueName="VARIANCE_GI">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </telerik:GridBoundColumn>
                    </Columns>
                    <ExpandCollapseColumn Visible="False">
                        <HeaderStyle Width="19px" />
                    </ExpandCollapseColumn>
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                </MasterTableView>
            </telerik:RadGrid>
        </table>
        
</asp:Content>
