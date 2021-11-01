<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Maintenance_JobVersionTemplateDetailListValue.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Job Version Template Detail List Values"
    Inherits="Webvantage.Maintenance_JobVersionTemplateDetailListValue" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="400">
        <tr>
            <td colspan="2">
                &nbsp;&nbsp;<asp:Label   ID="LabelJobVersionTemplateDetailLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td runat="server" id="TdRadToolbarJobVersionTemplateDetailListValues" align="left"
                valign="top" colspan="2">
                <telerik:RadToolBar ID="RadToolbarJobVersionTemplateDetailListValues" runat="server"
                    AutoPostBack="True"  ImagesDir="~/Images/" SkinsPath="~/RadControls/Toolbar/Skins"
                    >
                    <Items>
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton Text="Done" CommandName="Done" Value="Done" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonExportExcel" Text="Export To Excel" CommandName="ExportToExcel"
                            Value="ExportToExcel" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td width="1%">
                &nbsp;
            </td>
            <td>
                <br />
                <telerik:RadGrid ID="RadGridJobVersionTemplateDetailListValues" runat="server" AllowPaging="True"
                    AllowSorting="false" GridLines="None" PageSize="5" EnableEmbeddedSkins="True"
                    ShowFooter="False" AutoGenerateColumns="False" Width="99%">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px">
                    </PagerStyle>
                    <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ID, Value"
                        InsertItemDisplay="Top">
                        <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobVersionTemplateDetailListValueID"
                                HeaderText="ID" Visible="false">
                                <HeaderStyle Width="10" VerticalAlign="Middle" HorizontalAlign="Center" />
                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <%# Eval("ID")%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobVersionTemplateDetailListValueValue"
                                HeaderText="Value" SortExpression="[Value]">
                                <HeaderStyle Width="358" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemStyle Width="358" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <FooterStyle Width="358" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBoxJobVersionTemplateDetailListValueValue" runat="server" 
                                        SkinID="TextBoxStandard" Text='<%#Eval("Value") %>' Width="358"></asp:TextBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxJobVersionTemplateDetailListValueValueEditTextBox" runat="server"
                                         SkinID="TextBoxStandard" Text="" Width="358"></asp:TextBox>
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <HeaderTemplate>
                                        <asp:ImageButton ID="ImageButtonSaveAll" runat="server" SkinID="ImageButtonSaveAll"
                                            ToolTip="Click to save all rows" CommandName="SaveAll" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonSave" runat="server" SkinID="ImageButtonSaveWhite"
                                            ToolTip="Click to save this row" CommandName="SaveRow" />
                                    </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonSaveNew" runat="server" SkinID="ImageButtonNewWhite"
                                            ToolTip="Click to add this row" CommandName="SaveNewRow" />
                                    </div>
                                </EditItemTemplate>
                                <FooterTemplate>
                                        <asp:ImageButton ID="ImageButtonSaveAllFooter" runat="server" SkinID="ImageButtonSaveAll"
                                            ToolTip="Click to save all rows" CommandName="SaveAll" />
                                </FooterTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnCancel">
                                <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                <FooterStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-delete">
                                    <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite"
                                        ToolTip="Click to delete this row" CommandName="DeleteRow" />
                                    </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonCancel" runat="server" SkinID="ImageButtonCancelWhite"
                                            ToolTip="Cancel add row" CommandName="CancelAddRow" />
                                    </div>
                                </EditItemTemplate>
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
            </td>
        </tr>
    </table>
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
</asp:Content>
