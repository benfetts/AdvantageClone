<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="taskEmployees.aspx.vb"
    Inherits="Webvantage.taskEmployees" MasterPageFile="~/ChildPage.Master" Title="Assigned Employee List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table cellpadding="0" cellspacing="2" width="100%">
        <tr>
            <td>
                <telerik:RadGrid ID="RadGridEmployees" runat="server" AllowSorting="False" 
                    Width="100%" AutoGenerateColumns="false">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="EMP_CODE" HeaderText="Code" UniqueName="colEMP_CODE">
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" Width="65" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="65" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Name" UniqueName="colEMP_NAME">
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TEMP_COMP_DATE" HeaderText="Completed Date" UniqueName="colTEMP_DATE">
                                <HeaderStyle HorizontalAlign="right" VerticalAlign="middle" Width="100" />
                                <ItemStyle HorizontalAlign="right" VerticalAlign="middle" Width="100" />
                            </telerik:GridBoundColumn>
                        </Columns>
                        <ExpandCollapseColumn Visible="False" Resizable="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
</asp:Content>