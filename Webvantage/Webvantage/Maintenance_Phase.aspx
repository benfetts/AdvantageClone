<%@ Page Title="Phase Maintenance" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_Phase.aspx.vb" Inherits="Webvantage.Maintenance_Phase" %>

<asp:Content ID="conPhaseContent" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
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
                    <telerik:RadGrid ID="RadGridPhases" runat="server" AllowPaging="True"
                        AllowSorting="True" GridLines="None" PageSize="10" EnableEmbeddedSkins="True"
                         ShowFooter="False" AutoGenerateColumns="False" Width="730">
                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px">
                        </PagerStyle>
                        <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ID, Description, OrderNumber, IsInactive"
                            InsertItemDisplay="Top">
                            <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnPhaseID" HeaderText="ID" Visible="false">
                                    <HeaderStyle Width="10" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <%# Eval("ID")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnPhaseDescription" HeaderText="Description"
                                    SortExpression="Description">
                                    <HeaderStyle Width="525" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemStyle Width="525" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <FooterStyle Width="525" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBoxPhaseDescription" runat="server"  Text='<%#Eval("Description") %>' SkinID="TextBoxStandard"
                                            MaxLength="40" Width="525"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxPhaseDescriptionEditTextBox" runat="server"  SkinID="TextBoxStandard"
                                            Text='<%#Eval("Description") %>' MaxLength="40" Width="525"></asp:TextBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnPhaseOrderNumber" HeaderText="Order Number"
                                    SortExpression="OrderNumber">
                                    <HeaderStyle Width="45" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemStyle Width="45" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <FooterStyle Width="45" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <telerik:RadNumericTextBox ID="TextBoxPhaseOrderNumber" runat="server" 
                                            Text='<%#Eval("OrderNumber") %>' Type="Number" Width="80" MaxLength="6" MinValue="0">
                                            <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                            <EnabledStyle HorizontalAlign="Right" />
                                        </telerik:RadNumericTextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadNumericTextBox ID="TextBoxPhaseOrderNumberEditTextBox" runat="server" 
                                            Text='<%#Eval("OrderNumber") %>' Type="Number" Width="80" MaxLength="6" MinValue="0">
                                            <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                            <EnabledStyle HorizontalAlign="Right" />
                                        </telerik:RadNumericTextBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIsInactive" HeaderText="Inactive" SortExpression="IsInactive">
                                    <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <FooterStyle  VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBoxIsInactive" runat="server" AutoPostBack="false" Checked='<%#Eval("IsInactive") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="CheckBoxIsInactiveEditCheckBox" runat="server" Checked="false" />
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
            </td>
        </tr>
    </table>
</asp:Content>
