<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="dtp_currentratio_print.aspx.vb" Inherits="Webvantage.dtp_currentratio_print" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td align="Left">
                &nbsp;<asp:Label   ID="Label1" runat="server"></asp:Label>
            </td>
            <td align="right">
                <asp:Label   ID="lblType" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="False">
        <MasterTableView AllowMultiColumnSorting="True" Width="100%">
            <Columns>
                <telerik:GridBoundColumn DataField="OFFICE_NAME" HeaderText="Office" UniqueName="column1">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ASSETS" HeaderText="Assets" DataFormatString="{0:c}"
                    UniqueName="column2">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LIAB" HeaderText="Liabilities" DataFormatString="{0:c}"
                    UniqueName="column2">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="RATIO" DataFormatString="{0:F2}" HeaderText="Ratio"
                    UniqueName="column6">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn UniqueName="TemplateColumn1">
                    <HeaderStyle CssClass="radgrid-icon-column" />
                    <ItemStyle CssClass="radgrid-icon-column" />
                    <FooterStyle CssClass="radgrid-icon-column" />
                    <ItemTemplate>
                        <div class="icon-background background-color-sidebar" runat="server" id="DivFlagColor">
                            <asp:Image ID="ImageFlag" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/signal_flag.png" />
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            <ExpandCollapseColumn Visible="False">
                <HeaderStyle Width="19px" />
            </ExpandCollapseColumn>
            <RowIndicatorColumn Visible="False">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
        </MasterTableView>
        <ClientSettings>
            <Scrolling UseStaticHeaders="False" />
        </ClientSettings>
    </telerik:RadGrid>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
</asp:Content>