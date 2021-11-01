<%@ Page Title="Contract Manager" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_ContractManager.aspx.vb" Inherits="Webvantage.Maintenance_ContractManager" %>

<asp:Content ID="conContractContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarContract" runat="server" AutoPostBack="True" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonAdd" SkinID="RadToolBarButtonNew" Text="Add" Value="Add" ToolTip="Add New" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <table cellpadding="2" cellspacing="0" width="95%" align="center" border="0">
        <tr>
            <td>
                <telerik:RadGrid ID="RadGridContracts" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                    GridLines="None" EnableEmbeddedSkins="True" Width="99%" PageSize="10" AllowSorting="true">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" ></PagerStyle>
                    <MasterTableView DataKeyNames="ID">
                        <Columns>
                            <telerik:GridTemplateColumn AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonDetail" runat="server" CommandName="Detail" SkinID="ImageButtonViewWhite" CommandArgument='<%#Eval("ID").ToString%>' ToolTip="View Contract" />
                                   </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Code" HeaderText="Code" UniqueName="Code">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Description" HeaderText="Description" UniqueName="Description">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="160" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="160" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="160" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="IsContract" HeaderText="Is Contract" UniqueName="IsContract">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                <ItemTemplate>
                                    <div class="icon-background standard-green" style='<%# If(Eval("IsContract") = True, "display:block;", "display:none;")%>'>
                                        <asp:Image ID="ImageIsContract" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="" HeaderText="" UniqueName="Documents">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                <ItemTemplate>
                                    <div id="divDocuments" runat="server" class="icon-background background-color-sidebar">
                                        <asp:Image ID="DocumentsImage" runat="server" ImageUrl="Images/Icons/White/256/documents_empty.png" CssClass="icon-image" ToolTip="Documents" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="IsInactive" HeaderText="Is Inactive" UniqueName="IsInactive">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                <ItemTemplate>
                                    <div class="icon-background standard-green" style='<%# If(Eval("IsInactive") = True, "display:block;", "display:none;")%>'>
                                        <asp:Image ID="ImageIsInactive" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete" AllowFiltering="false">
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
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Resizable="False" Visible="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <EditFormSettings>
                            <PopUpSettings ScrollBars="None" />
                        </EditFormSettings>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    </div>
    
</asp:Content>
