<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dtp_agencyGoals_print.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.dtp_agencyGoals_print" %>

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
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False">
        <MasterTableView AllowMultiColumnSorting="True" Width="100%">
            <Columns>
                <telerik:GridBoundColumn DataField="DESCR" HeaderText="Description" UniqueName="column1">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="AMT" HeaderText="Amount" DataFormatString="{0:#,###.00}" UniqueName="column2">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="GOAL_PCT" HeaderText="Percent Goal" DataFormatString="{0:#,###.00}" UniqueName="column2">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ACTUAL_PCT" HeaderText="Actual Percent" DataFormatString="{0:#,##0.00}"
                    UniqueName="column4">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
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