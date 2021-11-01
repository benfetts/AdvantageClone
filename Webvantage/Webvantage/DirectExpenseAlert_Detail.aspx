<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DirectExpenseAlert_Detail.aspx.vb"
    Inherits="Webvantage.DirectExpenseAlert_Detail" MasterPageFile="~/ChildPage.Master"
    Title="Direct Expense Alert Detail" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="telerik-aqua-body">
        <table>
                <tr>
                    <td align="right" style="font-size: 8pt; font-family: Arial; font-weight: bold;">
                        Vendor Code:
                    </td>
                    <td style="width: 300px; font-size: 8pt; font-family: Arial;">
                        <asp:Label   ID="lblVendorCode" runat="server" Width="98%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="font-size: 8pt; font-family: Arial; font-weight: bold;">
                        Vendor Name:
                    </td>
                    <td style="width: 300px; font-size: 8pt; font-family: Arial;">
                        <asp:Label   ID="lblVendorName" runat="server" Width="98%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="font-size: 8pt; font-family: Arial; font-weight: bold;">
                        Invoice Number:
                    </td>
                    <td style="width: 300px; font-size: 8pt; font-family: Arial;">
                        <asp:Label   ID="lblInvNbr" runat="server" Width="98%"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
       
                        <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                <tr>
                                    <td colspan="4">
                                        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" GridLines="None" PageSize="30">
                                            <PagerStyle Mode="NextPrevAndNumeric" NextPageText="&amp;gt;" PrevPageText="&amp;lt;" />
                                            <MasterTableView AllowMultiColumnSorting="True" Width="100%">
                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="CL_CODE" HeaderText="Client" UniqueName="column1">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="DIV_CODE" HeaderText="Division" UniqueName="column2">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="PRD_CODE" HeaderText="Product" UniqueName="column3">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="JOB_NUMBER" HeaderText="Job Nbr" UniqueName="column4">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="JOB_DESC" HeaderText="Job Description" UniqueName="column5">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="JOB_COMPONENT_NBR" HeaderText="Comp Nbr" UniqueName="column6">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="JOB_COMP_DESC" HeaderText="Comp Description"
                                                        UniqueName="column7">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="FNC_CODE" HeaderText="Function Code" UniqueName="column8">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="FNC_DESCRIPTION" HeaderText="Function Description"
                                                        UniqueName="column9">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="AMT" HeaderText="Net Amount" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" UniqueName="column10">
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                                <ExpandCollapseColumn Visible="False" Resizable="False">
                                                    <HeaderStyle Width="20px" />
                                                </ExpandCollapseColumn>
                                                <RowIndicatorColumn Visible="False">
                                                    <HeaderStyle Width="20px" />
                                                </RowIndicatorColumn>
                                            </MasterTableView>
                                            <ClientSettings>
                                                <Scrolling UseStaticHeaders="False" />
                                            </ClientSettings>
                                        </telerik:RadGrid>
                                    </td>
                                </tr>
                            </table>
   
       
                </ContentTemplate>
            </asp:UpdatePanel>
            <webvantage:Print_Buttons ID="PrintButtons" runat="server" />
    </div>
    
</asp:Content>
