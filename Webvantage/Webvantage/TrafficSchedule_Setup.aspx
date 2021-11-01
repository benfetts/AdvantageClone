<%@ Page AutoEventWireup="false" CodeBehind="TrafficSchedule_Setup.aspx.vb" Inherits="Webvantage.TrafficSchedule_Setup"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Project Schedule Settings" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <div style="padding:10px;">
    <asp:Button ID="BtnBack" runat="server" CausesValidation="False" Text="Back" Visible="false" />
    
        <h4>Available Columns</h4>
        <table align="center" border="0" cellpadding="0" cellspacing="2" width="100%">
            <tr>
                <td align="Center">
                    <telerik:RadGrid ID="RadGridScheduleItems" runat="server" AutoGenerateColumns="false"
                        AllowMultiRowSelection="false" Width="100%">
                        <MasterTableView DataKeyNames="ID, ColumnName" Width="100%">
                            <Columns>
                                <telerik:GridBoundColumn DataField="ColumnShortDescription" HeaderText="Column Heading"
                                    Resizable="true" UniqueName="colCOLUMN_SHORT_DESC">
                                    <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" Width="140" />
                                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="140" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ColumnLongDescription" HeaderText="Description" Resizable="true"
                                    UniqueName="colCOLUMN_LONG_DESC" Display="true">
                                    <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" />
                                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Show On Grid" UniqueName="colInclude">
                                    <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="85" />
                                    <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="85" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkShowOnGrid" runat="server" AutoPostBack="true" OnCheckedChanged="ChkShowOnGrid_CheckedChanged" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn Display="true" HeaderText="Show On Add New" UniqueName="colShowOnAddNew"
                                    Visible="false">
                                    <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" />
                                    <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkShowOnAddNew" runat="server" AutoPostBack="true" OnCheckedChanged="ChkShowOnAddNew_CheckedChanged" />
                                        <asp:HiddenField ID="HfACTIVE" runat="server" Value='<%#Eval("Active") %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Show Full Column Name" UniqueName="colShowLongDesc"
                                    Visible="false">
                                    <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" />
                                    <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkShowFull" runat="server" AutoPostBack="true" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
        <h4>Other Settings</h4>

        <table cellspacing="0" cellpadding="0" border="0">
            <tr>
                <td colspan="2"><asp:CheckBox ID="CheckBoxDisablePaging" runat="server" AutoPostBack="true" Text="Disable paging*" /></td>
            </tr>
            <tr>
                <td>Default Schedule:&nbsp;&nbsp;</td>
                <td><asp:RadioButtonList ID="RadioButtonListDefaultCalculation" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Order" Value="0" />
                        <asp:ListItem Text="Predecessor" Value="1" />
                    </asp:RadioButtonList></td>
            </tr>
        </table>
        <br />
        <br />
        *Note:  This can drastically increase load time for large schedules!
</div>
</asp:Content>
