<%@ Page Title="Edit Product" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_ClientContactManager.aspx.vb" Inherits="Webvantage.Maintenance_ClientContactManager" %>

<asp:Content ID="conClientContactContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <div >
        <telerik:RadToolBar ID="RadToolbarClientContact" runat="server" AutoPostBack="True" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonAdd" SkinID="RadToolBarButtonNew" Text="Add" Value="Add" ToolTip="Add New" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div >
    </div>
    <table cellpadding="2" cellspacing="0" width="95%" align="center" border="0">
        <tr>
            <td>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <br />
                    <telerik:RadGrid ID="RadGridContacts" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                        GridLines="None" EnableEmbeddedSkins="True" Width="99%" PageSize="10" AllowSorting="true">
                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" ></PagerStyle>
                        <MasterTableView DataKeyNames="ContactID, Code">
                            <Columns>
                                <telerik:GridTemplateColumn AllowFiltering="false">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div class="icon-background background-color-sidebar">
                                          <asp:ImageButton ID="butDetail" runat="server" CommandName="Detail" SkinID="ImageButtonViewWhite" CommandArgument='<%#Eval("ContactID").ToString%>' ToolTip="View Contact" />
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Code" HeaderText="Code" UniqueName="Code">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Name" HeaderText="Name" UniqueName="Name">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="160" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="160" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="160" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Title" HeaderText="Title" UniqueName="Name">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Telephone" HeaderText="Telephone" UniqueName="Name">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CellPhone" HeaderText="Cell Phone" UniqueName="Name">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Fax" HeaderText="Fax" UniqueName="Name">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EmailAddress" HeaderText="Email Address" UniqueName="Name">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn DataField="IsInactive" HeaderText="Is Inactive" UniqueName="IsInactive">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBoxContactIsInactive" runat="server" Enabled="false" AutoPostBack="false" Checked='<%#Eval("IsInactive") %>' />
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
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <script>
        function Refresh() {
            __doPostBack('onclick#Refresh', 'Refresh');
        }
    </script>
</asp:Content>
