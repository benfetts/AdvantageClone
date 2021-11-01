<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="dtp_servicefee.aspx.vb" Inherits="Webvantage.dtp_servicefee" %>

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
                <telerik:RadHtmlChart ID="RadHtmlChartServiceFees" runat="server" Height="250" Width="350">
                    <PlotArea>
                        <YAxis>
                            <LabelsAppearance DataFormatString="{0:N0}"></LabelsAppearance>
                        </YAxis>
                    </PlotArea>
                </telerik:RadHtmlChart>
                <br />
            </td>
        </tr>
        <tr>
            <td align="right" colspan="3">
                <telerik:RadGrid ID="RadGridServiceFeeClient" runat="server" AllowPaging="false" AllowSorting="True"
                    Width="100%" AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True"
                    EnableHeaderContextMenu="true" ShowFooter="true">                       
                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                        <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown"  />
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView AllowMultiColumnSorting="true" Width="100%" DataKeyNames="ClientCode">
                        <Columns>
                            <telerik:GridBoundColumn DataField="ClientDescription" HeaderText="Client" UniqueName="cdp">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>            
                            <telerik:GridBoundColumn DataField="ServiceFeeTypeDescription" HeaderText="Fee Type" UniqueName="fee" Display="false">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FeeAmount" HeaderText="Fee Billed" UniqueName="column36" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Hours" HeaderText="Actual Hours" UniqueName="column34" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Amount" HeaderText="Actual Amount" UniqueName="column35" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="VarianceAmount" HeaderText="Variance" UniqueName="taskcolumn" DataFormatString="{0:#,##0.00}">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
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
                <telerik:RadGrid ID="RadGridServiceFeeCDP" runat="server" AllowPaging="False" AllowSorting="True"
                    Width="100%" AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True"
                    EnableHeaderContextMenu="true" ShowFooter="true">                    
                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                        <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown"  />
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView AllowMultiColumnSorting="true" Width="100%" DataKeyNames="ClientCode,DivisionCode,ProductCode">
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
                            <telerik:GridBoundColumn DataField="ServiceFeeTypeDescription" HeaderText="Fee Type" UniqueName="fee" Display="false">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FeeAmount" HeaderText="Fee Billed" UniqueName="column36" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="true" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Hours" HeaderText="Actual Hours" UniqueName="column34" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="true" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Amount" HeaderText="Actual Amount" UniqueName="column35" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="true" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="VarianceAmount" HeaderText="Variance" UniqueName="taskcolumn" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="true" />
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
