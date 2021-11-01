<%@ Page AutoEventWireup="false" CodeBehind="BillingApproval_AlertList.aspx.vb" Inherits="Webvantage.BillingApproval_AlertList"
    Language="vb" MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div>
        <div style="margin-bottom: 10px; font-weight: bold;">
            <asp:Label runat="server" ID="LabelHeader"></asp:Label>
        </div>
        <div>
            <telerik:RadGrid ID="RadGridBatchAlerts" runat="server" AllowPaging="False" AllowSorting="False"
                AutoGenerateColumns="False" EnableAJAX="False" EnableAJAXLoadingTemplate="False"
                EnableOutsideScripts="true" ShowFooter="True" Visible="True" Width="100%">
                <ClientSettings>
                </ClientSettings>
                <MasterTableView>
                    <Columns>
                        <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="ColView">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <!--  -->
                                <asp:ImageButton ID="ImgBtnView" runat="server" CommandArgument='<%#Eval("ALERT_ID")%>'
                                    CommandName="OpenAlert" SkinID="ImageButtonViewWhite" ToolTip="View alert"
                                    AlternateText="View alert" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="ALERT_DESC" HeaderText="Alert Category" UniqueName="ColALERT_DESC">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="175" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="175" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="175" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn DataField="SUBJECT" HeaderText="Subject" UniqueName="ColSUBJECT">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:LinkButton ID="LnkBtnAlert" runat="server" CommandArgument='<%#Eval("ALERT_ID")%>'
                                    CommandName="OpenAlert" Text='<%#Eval("SUBJECT")%>' ToolTip="View alert"></asp:LinkButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="GENERATED" HeaderText="Item Date" UniqueName="ColGENERATED">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="150" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="150" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EMP_CODE" HeaderText="Sent By" UniqueName="ColEMP_CODE">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="150" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="150" />
                        </telerik:GridBoundColumn>
                    </Columns>
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Resizable="False" Visible="False">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </div>
</asp:Content>
