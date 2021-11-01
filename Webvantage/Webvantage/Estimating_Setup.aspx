<%@ Page AutoEventWireup="false" Codebehind="Estimating_Setup.aspx.vb" Inherits="Webvantage.Estimating_Setup"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Estimating Setup" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">

    
    <table align="center" border="0" cellpadding="0" cellspacing="0" 
        width="98%">
        <tr >
            <td align="left"  valign="middle">
                &nbsp;</td>
            <td align="right"  valign="middle">
                &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td align="Center">
                <br />
                <br />
                <telerik:RadGrid ID="RGEstimateItems" runat="server" AutoGenerateColumns="false"
                     AllowMultiRowSelection="false" EnableAJAX="true" Width="600px">
                        <MasterTableView DataKeyNames="ID" Width="100%" >
                        <Columns>
                            <telerik:GridBoundColumn DataField="COLUMN_SHORT_DESC" HeaderText="<div align='left'>Column Heading</div>"
                                Resizable="true" UniqueName="colCOLUMN_SHORT_DESC">
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="COLUMN_LONG_DESC" HeaderText="<div align='left'>Description</div>"
                                Resizable="true" UniqueName="colCOLUMN_LONG_DESC" Display="true">
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="<div align='center'>Show On Grid</div>" UniqueName="colInclude">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkShowOnGrid" runat="server" AutoPostBack="true" OnCheckedChanged="ChkShowOnGrid_CheckedChanged" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Display="False" HeaderText="<div align='center'>Show On<br/>Add New</div>"
                                UniqueName="colShowOnAddNew">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkShowOnAddNew" runat="server" AutoPostBack="true" OnCheckedChanged="ChkShowOnAddNew_CheckedChanged" />
                                    <asp:HiddenField ID="HfACTIVE" runat="server" Value='<%#Eval("ACTIVE") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="<div align='center'>Show Full<br/>Column Name</div>"
                                UniqueName="colShowLongDesc" Display="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkShowFull" runat="server" AutoPostBack="true" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                     </telerik:RadGrid>
                <br />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
