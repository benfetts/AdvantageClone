<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="dtp_grossincome.aspx.vb" Inherits="Webvantage.dtp_grossincome" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="30%" align="left">
                &nbsp;<asp:Label   ID="lblTitle" runat="server"></asp:Label>
            </td>
            <td width="70%" align="right">
                <asp:Label   ID="lblClient" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <telerik:RadHtmlChart ID="RadHtmlChartGrossIncomeGraph" runat="server" Width="800" Height="400">

                </telerik:RadHtmlChart>
                <br />
            </td>
        </tr>
        <tr>
            <td align="right" colspan="3">
                <telerik:RadGrid ID="RadGridGrossIncomeClient" runat="server" AllowPaging="false" AllowSorting="True"
                    Width="100%" AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True"
                    EnableHeaderContextMenu="true" ShowFooter="true">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" ></PagerStyle>        
                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                        <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown"  />
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView AllowMultiColumnSorting="true" Width="100%" DataKeyNames="ClientCode,ClientSharePercent">
                        <Columns>
                            <telerik:GridBoundColumn DataField="ClientDescription" HeaderText="Client" UniqueName="cdp">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn> 
                            <telerik:GridBoundColumn DataField="TotalGrossIncome" HeaderText="Gross Income" UniqueName="column36" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ClientSharePercentDisplay" HeaderText="Gross Income Percent" UniqueName="column34" DataFormatString="{0:#,##0.00%}">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
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
                </telerik:RadGrid>
                <telerik:RadGrid ID="RadGridGrossIncomeCDP" runat="server" AllowPaging="false" AllowSorting="True"
                    Width="100%" AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True"
                    EnableHeaderContextMenu="true">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" ></PagerStyle>
                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                        <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown"  />
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView AllowMultiColumnSorting="true" Width="100%" DataKeyNames="ClientCode,DivisionCode,ProductCode,ClientSharePercent">
                        <Columns>
                            <telerik:GridBoundColumn DataField="ClientDescription" HeaderText="Client" UniqueName="c">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>            
                            <telerik:GridBoundColumn DataField="DivisionDescription" HeaderText="Division" UniqueName="cd">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ProductDescription" HeaderText="Product" UniqueName="cdp">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>   
                            <telerik:GridBoundColumn DataField="TotalGrossIncome" HeaderText="Gross Income" UniqueName="column36" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ClientSharePercentDisplay" HeaderText="Gross Income Percent" UniqueName="column34" DataFormatString="{0:#,##0.00%}">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
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
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
</asp:Content>