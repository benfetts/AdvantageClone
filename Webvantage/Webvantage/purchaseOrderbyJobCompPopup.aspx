<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="purchaseOrderbyJobCompPopup.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="" Inherits="Webvantage.purchaseOrderbyJobCompPopup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="col-xs-12">
    <div class="telerik-aqua-body" style="margin-top: 5px!important; max-width: 96%!important">
       <div class="col-xs-12">

       </div>
        <asp:Literal ID="LitTemplateCSS" runat="server"></asp:Literal>
            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
            <table align="center" cellpadding="0" cellspacing="0" width="99%">
                <tr>
                    <td>
                        <table align="left" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>&nbsp;&nbsp;
                                    <asp:Label ID="lblTitle" runat="server" Text="Purchase Orders"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table align="center" cellpadding="0" cellspacing="0" width="99%">
                <tr>
                    <td>
                        <table align="left" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="POGrid" runat="server" AllowPaging="True" AllowSorting="True"
                                        AutoGenerateColumns="False" GridLines="None"  CssClass="grid-width">
                                        <PagerStyle Mode="NextPrevAndNumeric" NextPageText="&amp;gt;" PrevPageText="&amp;lt;" />
                                        <MasterTableView DataKeyNames="PO_NUMBER, PO_DESCRIPTION, PO_NUMBER_DISPLAY"  CssClass="grid-width">
                                            <Columns>
                                                <telerik:GridTemplateColumn DataField="PO_NUMBER_DISPLAY" HeaderText="PO Number"
                                                    UniqueName="column2" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                    <HeaderStyle  Width="60px" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="ViewLinkButton" runat="server" Visible="true"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="LINE_NUMBER" HeaderText="Line Number" UniqueName="column3"
                                                    DataFormatString="{0:00}" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                    <HeaderStyle  Width="60px" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="VN_CODE" HeaderText="Vendor Code" UniqueName="column">
                                                    <HeaderStyle  Width="60px" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="VN_NAME" HeaderText="Vendor Name" UniqueName="column">
                                                    <HeaderStyle  Width="100px" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PO_EXT_AMOUNT" HeaderText="Extended Amount" UniqueName="column7"
                                                    DataFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center">
                                                    <HeaderStyle  Width="75px" />
                                                    <ItemStyle  Width="75px" />
                                                    <FooterStyle  Width="75px" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PO_COMPLETE" HeaderText="Complete" UniqueName="column8"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="TemplateColumn1" HeaderText="Complete">
                                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                                    <ItemStyle CssClass="radgrid-icon-column" />
                                                    <FooterStyle CssClass="radgrid-icon-column" />
                                                    <ItemTemplate>
                                                        <div class="icon-background standard-green" style='<%# If(Eval("PO_COMPLETE") = 1, "display:block;", "display:none;")%>'>
                                                            <asp:Image ID="ImageCheck" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
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
                    </td>
                </tr>
            </table>
            <telerik:RadWindowManager ID="RadWindowManager" runat="server">
                <Windows>
                    <telerik:RadWindow ID="PO" runat="server" InitialBehavior="None" Modal="true" OnClientClose="" ReloadOnShow="true"
                        VisibleOnPageLoad="false" />
                </Windows>
            </telerik:RadWindowManager>
    </div>
    
    </div>

</asp:Content>
