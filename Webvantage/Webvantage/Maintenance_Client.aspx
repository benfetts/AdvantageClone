<%@ Page Title="Client Maintenance" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_Client.aspx.vb" Inherits="Webvantage.Maintenance_Client" %>

<asp:Content ID="conClientContent" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">

    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    <script type="text/javascript">
        function RadGridTaskTemplates_RowDoubleClick(sender, eventArgs) {
            __doPostBack("<%= RadGridClients.UniqueID%>", "IndexOfRowDoubleClicked:" + eventArgs.get_itemIndexHierarchical());
        }

        function RefreshPage() {
            __doPostBack("onclick#refresh", "refresh");
        }

    </script>
    </telerik:RadScriptBlock>
    <div  style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolBarClient" runat="server" AutoPostBack="true"
                            Width="100%">
                            <Items>
                                <telerik:RadToolBarButton ID="RadToolBarSeparatorFirstSeparator" runat="server" IsSeparator="true" />
                                <telerik:RadToolBarButton ID="RadToolBarButtonAdd" runat="server" Text="Add" Value="Add"
                                    CommandName="Add" ToolTip="Add New Client" SkinID="RadToolBarButtonNew" />
                                <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server"
                                    IsSeparator="true" />
                            </Items>
                        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
                <tr>
                    <td align="left" valign="top" colspan="2">
                
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="75%">
                                  &nbsp;
                                </td>
                                <td align="right" valign="middle">
                                    <asp:CheckBox ID="CheckBoxShowInactive" runat="server" Text="Show Inactive" AutoPostBack="True" />
                                    <asp:ImageButton ID="ImageButtonExport" runat="server" SkinID="ImageButtonExportExcel" />&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                            <br />
                            <telerik:RadGrid ID="RadGridClients" runat="server" AllowPaging="True" AllowFilteringByColumn="true"
                                AllowSorting="True" GridLines="None" PageSize="10" EnableEmbeddedSkins="True"
                                 ShowFooter="False" AutoGenerateColumns="False" Width="780" EnableLinqExpressions="false">
                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px">
                                </PagerStyle>
                                <GroupingSettings CaseSensitive="false" />
                                <MasterTableView CommandItemDisplay="None" DataKeyNames="Code, Client"
                                    InsertItemDisplay="Top">
                                    <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                    <Columns>
                                         <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="GridTemplateColumnView">
                                             <HeaderStyle CssClass="radgrid-icon-column" />
                                             <ItemStyle CssClass="radgrid-icon-column" />
                                             <FooterStyle CssClass="radgrid-icon-column" />
                                             <ItemTemplate>
                                                <div class="icon-background background-color-sidebar">
                                                    <asp:ImageButton ID="ImageButtonView" runat="server" CommandName="Detail" SkinID="ImageButtonViewWhite" CommandArgument='<%#Eval("Code").ToString%>' ToolTip="View Client" />
                                               </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="GridTemplateColumnCopy">
                                            <HeaderStyle CssClass="radgrid-icon-column" />
                                            <ItemStyle CssClass="radgrid-icon-column" />
                                            <FooterStyle CssClass="radgrid-icon-column" />
                                            <ItemTemplate>
                                                <div class="icon-background background-color-sidebar">
                                                    <asp:ImageButton ID="ImageButtonCopyWhite" runat="server" CommandName="Copy" SkinID="ImageButtonCopyWhite" CommandArgument='<%#Eval("Code").ToString%>' ToolTip="Copy Client" />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnCode" HeaderText="Code" Visible="false">
                                            <HeaderStyle Width="10" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%# Eval("Code")%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnClient" HeaderText="Client" DataField="Client" FilterDelay="1250"
                                            SortExpression="Client">
                                            <HeaderStyle Width="575" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemStyle Width="575" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <FooterStyle Width="575" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%# Eval("Client")%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIsNewBusiness" HeaderText="Is New Business" FilterDelay="1250"
                                            SortExpression="IsNewBusiness" DataField="IsNewBusiness">
                                            <HeaderStyle CssClass="radgrid-icon-column" />
                                            <ItemStyle CssClass="radgrid-icon-column" />
                                            <FooterStyle CssClass="radgrid-icon-column" />
                                            <ItemTemplate>
                                                <div class="icon-background standard-green" style='<%# If(Eval("IsNewBusiness") = True, "display:block;", "display:none;")%>'>
                                                    <asp:Image ID="ImageNewBusiness" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="GridTemplateColumnIsInactive" HeaderText="Is Inactive"
                                            SortExpression="IsInactive">
                                            <HeaderStyle CssClass="radgrid-icon-column" />
                                            <ItemStyle CssClass="radgrid-icon-column" />
                                            <FooterStyle CssClass="radgrid-icon-column" />
                                            <ItemTemplate>
                                                <div class="icon-background standard-green" style='<%# If(Eval("IsInactive") = True, "display:block;", "display:none;")%>'>
                                                    <asp:Image ID="ImageIsInactive" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="GridTemplateColumnDelete">
                                            <HeaderStyle CssClass="radgrid-icon-column" />
                                            <ItemStyle CssClass="radgrid-icon-column" />
                                            <FooterStyle CssClass="radgrid-icon-column" />
                                            <ItemTemplate>
                                                <div class="icon-background background-color-delete">
                                                    <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite" ToolTip="Click to delete this row"
                                                        CommandName="DeleteRow" />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <RowIndicatorColumn>
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn>
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                </MasterTableView>
                            </telerik:RadGrid>
                            <br />
                </ContentTemplate>
            </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
    </div>
    
</asp:Content>
