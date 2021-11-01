<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AccountSetupForm_Print.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.AccountSetupForm_Print" Title="Print Account Setup" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
     <table border="0" bordercolor="#333399" cellpadding="2" cellspacing="0" width="99%"
        align="center">
        <tr>
            <td colspan="2">
                &nbsp;Account Setup<br />
                &nbsp;<asp:Label ID="Label" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="8">
                <telerik:RadGrid ID="AccountSetupRG" runat="server" AutoGenerateColumns="False" AllowSorting="True"
                    Width="99%">
                    <MasterTableView AllowMultiColumnSorting="True">
                        <Columns>
                            <telerik:GridBoundColumn DataField="ClientCode" HeaderText="Client Code" UniqueName="column1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DivisionCode" HeaderText="Division Code" UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ProductCode" HeaderText="Product Code" UniqueName="column3">
                            </telerik:GridBoundColumn>                
                            <telerik:GridBoundColumn DataField="AccountSetupCode1" HeaderText="" UniqueName="GridBoundColumnAccountSetupCode1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AccountSetupCode2" HeaderText="" UniqueName="GridBoundColumnAccountSetupCode2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AccountSetupCode3" HeaderText="" UniqueName="GridBoundColumnAccountSetupCode3">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AccountSetupCode4" HeaderText="" UniqueName="GridBoundColumnAccountSetupCode4">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PercentSplit" HeaderText="Percent" UniqueName="column31">
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
            </td>
        </tr>
    </table>
    
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" Visible="false" />
</asp:Content>
