<%@ Page Title="Alert Group Maintenance" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_AlertGroup.aspx.vb" Inherits="Webvantage.Maintenance_AlertGroup" %>

<asp:Content ID="ContentAlertGroup" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="telerik-aqua-body">
<script type="text/javascript">
        function RadGridAlertGroups_RowDoubleClick(sender, eventArgs) {
            __doPostBack("<%= RadGridAlertGroups.UniqueID %>", "IndexOfRowDoubleClicked:" + eventArgs.get_itemIndexHierarchical());
        };
    </script>
    <div class="DO-ButtonHeader">
        <div style="float: left; text-align: left; vertical-align: middle; display: inline-block;">
            <telerik:RadTabStrip ID="RadTabStripAlertGroups" runat="server" MultiPageID="RadMultiPageAlertGroups"
                AutoPostBack="true" SelectedIndex="0" Width="350">
                <Tabs>
                    <telerik:RadTab Text="Groups">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Group Detail">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
        </div>
        <div style="float: right; text-align: right; display: inline-block;">
            <asp:CheckBox ID="CheckBoxShowInactive" runat="server" Text="Show Inactive" AutoPostBack="True" />
            <asp:ImageButton ID="ImageButtonExport" runat="server" SkinID="ImageButtonExportExcel" />&nbsp;&nbsp;
        </div>
    </div>
    <br />
    <telerik:RadMultiPage ID="RadMultiPageAlertGroups" runat="server" SelectedIndex="0" Width="100%">
        <telerik:RadPageView ID="RadPageViewAlertGroups" runat="server" Width="100%">
            <br />
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                <telerik:RadGrid ID="RadGridAlertGroups" runat="server" AllowPaging="True" AllowSorting="True" Width="770"
                    GridLines="None" PageSize="10" EnableEmbeddedSkins="True" ShowFooter="False"
                    AutoGenerateColumns="False">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px"></PagerStyle>
                    <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="Code, IsInactive"
                        InsertItemDisplay="Top">
                        <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAlertGroupCode" HeaderText="Alert Group Code"
                                SortExpression="Code">
                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <%# Eval("Code")%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIsInactive" HeaderText="Inactive"
                                SortExpression="IsInactive">
                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBoxIsInactive" runat="server" AutoPostBack="false" Checked='<%#Eval("IsInactive") %>' />
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
                    <ClientSettings>
                        <ClientEvents OnRowDblClick="RadGridAlertGroups_RowDoubleClick" />
                    </ClientSettings>
                </telerik:RadGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageViewAlertGroupDetail" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                <table>
                    <tr id="TableRowAlertGroupDetailDropDownHeader" runat="server">
                        <td>Alert Group: 
                            <telerik:RadComboBox ID="DropDownListAlertGroups" runat="server" AutoPostBack="true" Width="300" SkinID="RadComboBoxStandard"
                                DataTextField="Code" DataValueField="Code">
                            </telerik:RadComboBox>
                            <asp:ImageButton ID="ImageButtonAddNewAlertGroup" runat="server" SkinID="ImageButtonNew"
                                ToolTip="Click to add new alert group" />
                        </td>
                    </tr>
                    <tr id="TableRowAlertGroupDetailTextBoxHeader" runat="server">
                        <td>Alert Group: 
                            <asp:TextBox ID="TextBoxAlertGroup" runat="server" MaxLength="50" SkinID="TextBoxCodeExtraLarge" />
                            <asp:ImageButton ID="ImageButtonSaveAlertGroup" runat="server" SkinID="ImageButtonSave" ToolTip="Add alert group" Visible="false" />
                            <asp:ImageButton ID="ImageButtonCancelAlertGroup" runat="server" SkinID="ImageButtonCancel" ToolTip="Cancel adding alert group" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsInactive" runat="server" Text="Inactive" AutoPostBack="True" />
                        </td>
                    </tr>
                </table>
                <table style="width:100%;">
                    <tr>
                        <td align="left" valign="bottom" width="300">Available Employees
                        </td>
                        <td align="left" valign="bottom">Employees Currently in Alert Group
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <telerik:RadGrid ID="RadGridAlertGroupAvailableEmployees" runat="server" AllowSorting="false"
                                GridLines="None" EnableEmbeddedSkins="True" ShowFooter="False"
                                AutoGenerateColumns="False" Width="100%" Height="600" AllowMultiRowSelection="True">
                                <ClientSettings EnableRowHoverStyle="true" Scrolling-AllowScroll="true">
                                    <Selecting AllowRowSelect="true" />
                                </ClientSettings>
                                <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="EmployeeCode, EmployeeName">
                                    <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                    <Columns>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEmployeeCode" HeaderText="Employee Code">
                                            <HeaderStyle Width="100" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemStyle Width="100" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <FooterStyle Width="100" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%# Eval("EmployeeCode")%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEmployeeName" HeaderText="Employee Name">
                                            <HeaderStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <FooterStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%# Eval("EmployeeName")%>
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
                            <div>
                                <asp:ImageButton ID="ImageButtonAddEmployee" runat="server" SkinID="ImageButtonNew"
                                    ToolTip="Click to add employee" />
                            </div>
                        </td>
                        <td align="left" valign="top">
                            <telerik:RadGrid ID="RadGridAlertGroupCurrentEmployees" runat="server" AllowSorting="false"
                                GridLines="None" EnableEmbeddedSkins="True" ShowFooter="False"
                                AutoGenerateColumns="False" Height="600" Width="100%" AllowMultiRowSelection="True">
                                <ClientSettings EnableRowHoverStyle="true" Scrolling-AllowScroll="true">
                                    <Selecting AllowRowSelect="true" />
                                </ClientSettings>
                                <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="IncludeOnSchedule, EmployeeCode, EmployeeName, Email, DefaultRole, DefaultFunction">
                                    <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                    <Columns>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIncludeOnSchedule" HeaderText="Include On Schedule">
                                            <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Center" />
                                            <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Center" />
                                            <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBoxIncludeOnSchedule" runat="server" AutoPostBack="false"
                                                    Checked='<%#Eval("IncludeOnSchedule") %>' />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEmployeeCode" HeaderText="Employee Code">
                                            <HeaderStyle Width="25" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemStyle Width="25" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <FooterStyle Width="25" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%# Eval("EmployeeCode")%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEmployeeName" HeaderText="Employee Name">
                                            <HeaderStyle Width="100" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemStyle Width="100" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <FooterStyle Width="100" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%# Eval("EmployeeName")%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEmail" HeaderText="Email"
                                            SortExpression="Email">
                                            <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%# Eval("Email")%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDefaultRole" HeaderText="Default Role">
                                            <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%# Eval("DefaultRole")%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDefaultFunction" HeaderText="Default Function">
                                            <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%# Eval("DefaultFunction")%>
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
                            <div>
                                <asp:ImageButton ID="ImageButtonRemoveEmployee" runat="server" SkinID="ImageButtonDelete" ToolTip="Click to remove employee" />
                                <asp:ImageButton ID="ImageButtonSaveCurrentEmployeesDetails" runat="server" SkinID="ImageButtonSaveAll" ToolTip="Save current employees details" />
                            </div>
                        </td>
                    </tr>
                </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
    </div>
    
</asp:Content>
