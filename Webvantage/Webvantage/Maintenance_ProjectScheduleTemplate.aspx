<%@ Page Title="Project Schedule Templates Maintenance" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Maintenance_ProjectScheduleTemplate.aspx.vb" Inherits="Webvantage.Maintenance_ProjectScheduleTemplate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="text-align:right;margin:10px;">
    <asp:CheckBox ID="CheckBoxShowInactive" runat="server" Text="Show Inactive" AutoPostBack="True" />
    <asp:ImageButton ID="ImageButtonExport" runat="server" SkinID="ImageButtonExportExcel" />
    </div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>

        <telerik:RadGrid ID="RadGridProjectScheduleTemplateMaintenance" runat="server" AllowPaging="True"
            AllowSorting="True" GridLines="None" PageSize="10" EnableEmbeddedSkins="True"
            ShowFooter="False" AutoGenerateColumns="False" Width="780">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" ></PagerStyle>
            <ExportSettings ExportOnlyData="True" IgnorePaging="true" OpenInNewWindow="true" HideStructureColumns="true">
                <Excel Format="Html" />
            </ExportSettings>
            <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ID"
                InsertItemDisplay="Top">
                <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" ShowExportToExcelButton="true" />
                <Columns>
                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateName" HeaderText="Template Name" DataField="Name"
                        SortExpression="Name">
                        <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Left" />
                        <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Left" />
                        <FooterStyle  VerticalAlign="Middle" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBoxTemplateName" runat="server" Text='<%#Eval("Name")%>' SkinID="TextBoxStandard"
                                Width="100%" MaxLength="100"></asp:TextBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnActiveFlag" HeaderText="Inactive" SortExpression="IsInactive" DataField="IsInactive">
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="18px" />
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="18px" />
                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="18px" />
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBoxInactive" runat="server" AutoPostBack="false" Checked='<%#Eval("IsInactive")%>' />
                        </ItemTemplate>
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
                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <ItemTemplate>
                            <div class="icon-background background-color-delete">
                            <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite"
                                ToolTip="Click to delete this row" CommandName="DeleteRow" />
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
                </ContentTemplate>
            </asp:UpdatePanel>

</asp:Content>
