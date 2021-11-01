<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dtp_directtime.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.dtp_directtime" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
     <table border="0" bordercolor="#333399" cellpadding="2" cellspacing="0" width="99%"
        align="center">
        <tr>
            <td colspan="2">
                &nbsp;Direct Time<br />
                &nbsp;<asp:Label ID="Label" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="8">
                <telerik:RadGrid ID="RadGridDirectTimeDO" runat="server" AutoGenerateColumns="False" AllowSorting="True" ShowFooter="True"
                    Width="99%" ShowHeader="True">
                    <MasterTableView AllowMultiColumnSorting="True" DataKeyNames="ClientCode,ClientDescription,DivisionCode,DivisionDescription,ProductCode,ProductDescription,Date,JobNumber,JobComponentNumber,Employee,FunctionCode,FunctionDescription, CDPName, JobComponent,JobComponentName" ShowGroupFooter="True">
                        <Columns>
                            <telerik:GridBoundColumn DataField="Date" HeaderText="Date" UniqueName="Date" DataFormatString="{0:d}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Comments" HeaderText="Comment" UniqueName="Comment">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Hours" HeaderText="Hours" UniqueName="Hours" Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Rate" HeaderText="Rate" UniqueName="Rate" DataFormatString="{0:#,##0.00}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Amount" HeaderText="Amount" UniqueName="Amount" Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NonBillable" HeaderText="Non Billable" UniqueName="NonBillable">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="IsFeeTime" HeaderText="Fee Time" UniqueName="IsFeeTime" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Billed" HeaderText="Billed" UniqueName="Billed">
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
    
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
</asp:Content>
