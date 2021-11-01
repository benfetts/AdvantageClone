<%@ Page Title="Alert Category Maintenance" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Maintenance_AlertCategory.aspx.vb" Inherits="Webvantage.Maintenance_AlertCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="DO-ButtonHeader">
        <div style="float: left; text-align: left; vertical-align: middle; display: inline-block;">
        </div>
        <div style="float: right; text-align: right; display: inline-block;">
            <asp:CheckBox ID="CheckBoxShowInactive" runat="server" Text="Show Inactive" AutoPostBack="True" />
            <asp:ImageButton ID="ImageButtonExport" runat="server" SkinID="ImageButtonExportExcel" />&nbsp;&nbsp;
        </div>
    </div>
    <br />
    <div style="text-align:center; width:100%;">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <br />
            <telerik:RadGrid ID="RadGridAlertCategories" runat="server" AllowPaging="True"
                AllowSorting="True" GridLines="None" PageSize="10" EnableEmbeddedSkins="True"
                ShowFooter="False" AutoGenerateColumns="False" Width="780">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px"></PagerStyle>
                <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ID, Description, IsInactive"
                    InsertItemDisplay="Top">
                    <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                    <Columns>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnStatusDescription" HeaderText="Description" SortExpression="Description">
                            <HeaderStyle Width="500" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemStyle Width="500" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <FooterStyle Width="500" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:TextBox ID="TextBoxStatusDescription" runat="server" Text='<%#Eval("Description") %>' MaxLength="40" Width="491" SkinID="TextBoxStandard"></asp:TextBox>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxStatusDescription" runat="server" MaxLength="40" Width="491" SkinID="TextBoxStandard"></asp:TextBox>
                            </EditItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAlertType" HeaderText=" Type">
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <telerik:RadComboBox ID="RadComboBoxAlertType" runat="server" SkinID="RadComboBoxStandard">
                                </telerik:RadComboBox>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <telerik:RadComboBox ID="RadComboBoxAlertType" runat="server" SkinID="RadComboBoxStandard">
                                </telerik:RadComboBox>
                            </EditItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIsInactive" HeaderText="Inactive" SortExpression="IsInactive">
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                            <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBoxIsInactive" runat="server" AutoPostBack="false" Checked='<%#Eval("IsInactive") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBoxIsInactive" runat="server" Checked="false" />
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
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-delete">
                                    <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite" ToolTip="Click to delete this row"
                                        CommandName="DeleteRow" />
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
                </ContentTemplate>
            </asp:UpdatePanel>

    </div>
</asp:Content>
