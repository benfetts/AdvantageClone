<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Expense_Paid_Detail.aspx.vb"
    Inherits="Webvantage.expense_paid_detail" MasterPageFile="~/ChildPage.Master"
    Title="Expense Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table width="100%">
        <tr>
            <td style="text-align:left">
                <asp:Label   ID="Label1" runat="server"   Text="Employee:" ></asp:Label>
                <asp:Label   ID="lblemp" runat="server" Font-Bold="false"   ></asp:Label>
            </td>
            <td style="text-align:right">
                <asp:Label   ID="Label2" runat="server"   Text="Invoice Number:" ></asp:Label>
                <asp:Label   ID="lblinv" runat="server" Font-Bold="false"   ></asp:Label>
            </td>
        </tr>
    
        <tr>
            <td colspan="2">
                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" GridLines="None"
                     EnableEmbeddedSkins="True">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="APCHKNBR" HeaderText="Check" UniqueName="column1">
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="APCHKDATE" HeaderText="Date" UniqueName="column2" DataFormatString="{0:M/d/yyyy }">
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CHKAMT" HeaderText="Amount Paid" UniqueName="column3" DataFormatString="{0:c}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
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
</asp:Content>