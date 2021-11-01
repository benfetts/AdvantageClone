<%@ Page Title="Task Maintenance" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_Task.aspx.vb" Inherits="Webvantage.Maintenance_Task" %>

<asp:Content ID="ContentTask" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="75%">&nbsp;
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
                    <telerik:RadGrid ID="RadGridTasks" runat="server" AllowPaging="True" AllowSorting="True"
                        GridLines="None" PageSize="10" EnableEmbeddedSkins="True" ShowFooter="False"
                        AutoGenerateColumns="False" Width="1050">
                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" ></PagerStyle>
                        <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="Code"
                            InsertItemDisplay="Top">
                            <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTaskCode" HeaderText="Code"
                                    SortExpression="Code">
                                    <HeaderStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <FooterStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <%#Eval("Code") %>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxTaskCodeEditTextBox" runat="server" MaxLength="10" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTaskDescription" HeaderText="Description"
                                    SortExpression="Description">
                                    <HeaderStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <FooterStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBoxTaskDescription" runat="server" Text='<%#Eval("Description") %>' SkinID="TextBoxStandard"
                                            MaxLength="40" Width="200"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxTaskDescriptionEditTextBox" runat="server" MaxLength="40" SkinID="TextBoxStandard"
                                            Width="200"></asp:TextBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTaskProcessOrderNumber"
                                    HeaderText="Process Order Number" SortExpression="ProcessOrderNumber">
                                    <HeaderStyle Width="70" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemStyle Width="70" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <FooterStyle Width="70" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <telerik:RadNumericTextBox ID="TextBoxTaskProcessOrderNumber" runat="server" Text='<%#Eval("ProcessOrderNumber") %>'
                                            Type="Number" Width="70" MaxLength="4" MinValue="0">
                                            <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                            <EnabledStyle HorizontalAlign="Right" />
                                        </telerik:RadNumericTextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadNumericTextBox ID="TextBoxTaskProcessOrderNumberEditTextBox" runat="server"
                                            Type="Number" Width="70" MaxLength="4" MinValue="0">
                                            <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                            <EnabledStyle HorizontalAlign="Right" />
                                        </telerik:RadNumericTextBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTaskDaysToComplete" HeaderText="Days To Complete"
                                    SortExpression="DaysToComplete">
                                    <HeaderStyle Width="70" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemStyle Width="70" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <FooterStyle Width="70" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <telerik:RadNumericTextBox ID="TextBoxTaskDaysToComplete" runat="server" Text='<%#Eval("DaysToComplete") %>'
                                            Type="Number" Width="70" MaxLength="4" MinValue="0">
                                            <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                            <EnabledStyle HorizontalAlign="Right" />
                                        </telerik:RadNumericTextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadNumericTextBox ID="TextBoxTaskDaysToCompleteEditTextBox" runat="server"
                                            Type="Number" Width="70" MaxLength="4" MinValue="0">
                                            <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                            <EnabledStyle HorizontalAlign="Right" />
                                        </telerik:RadNumericTextBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTaskHoursAllowed" HeaderText="Hours Allowed"
                                    SortExpression="HoursAllowed">
                                    <HeaderStyle Width="80" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemStyle Width="80" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <FooterStyle Width="80" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <telerik:RadNumericTextBox ID="TextBoxTaskHoursAllowed" runat="server" Text='<%#Eval("HoursAllowed") %>'
                                            Type="Number" Width="80" MaxLength="7" MaxValue="9999.99" MinValue="0.00">
                                            <NumberFormat DecimalDigits="2" GroupSeparator="" KeepTrailingZerosOnFocus="true" />
                                            <EnabledStyle HorizontalAlign="Right" />
                                        </telerik:RadNumericTextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadNumericTextBox ID="TextBoxTaskHoursAllowedEditTextBox" runat="server"
                                            Type="Number" Width="80" MaxLength="7" MaxValue="9999.99" MinValue="0.00">
                                            <NumberFormat DecimalDigits="2" GroupSeparator="" KeepTrailingZerosOnFocus="true" />
                                            <EnabledStyle HorizontalAlign="Right" />
                                        </telerik:RadNumericTextBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTaskIsMilestone" HeaderText="Milestone"
                                    SortExpression="IsMilestone">
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBoxTaskIsMilestone" runat="server" AutoPostBack="false" Checked='<%#Eval("IsMilestone") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="CheckBoxTaskIsMilestoneEditCheckBox" runat="server" AutoPostBack="false" />
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTaskFunctionCode" HeaderText="Default Function"
                                    SortExpression="DefaultFunctionCode">
                                    <HeaderStyle Width="225" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemStyle Width="225" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <FooterStyle Width="225" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="DropDownListTaskDefaultFunction" runat="server" AutoPostBack="false" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                            DataTextField="Description" DataValueField="Code" Width="225">
                                        </telerik:RadComboBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadComboBox ID="DropDownListTaskDefaultFunctionEditDropDownList" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                            AutoPostBack="false" DataTextField="Description" DataValueField="Code" Width="225">
                                        </telerik:RadComboBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTaskDefaultStatusCode"
                                    HeaderText="Default Status" SortExpression="DefaultStatusCode">
                                    <HeaderStyle Width="225" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemStyle Width="225" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <FooterStyle Width="225" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="DropDownListTaskDefaultStatus" runat="server" AutoPostBack="false" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                            DataTextField="Description" DataValueField="Code" Width="225">
                                        </telerik:RadComboBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadComboBox ID="DropDownListTaskDefaultStatusEditDropDownList" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                            AutoPostBack="false" DataTextField="Description" DataValueField="Code" Width="225">
                                        </telerik:RadComboBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTaskIsInactive" HeaderText="Inactive"
                                    SortExpression="IsInactive">
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBoxTaskIsInactive" runat="server" AutoPostBack="false" Checked='<%#Eval("IsInactive") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="CheckBoxTaskIsInactiveEditCheckBox" runat="server" AutoPostBack="false" />
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
                                    <EditItemTemplate>
                                        <div class="icon-background background-color-sidebar">
                                            <asp:ImageButton ID="ImageButtonCancel" runat="server" SkinID="ImageButtonCancelWhite"
                                                ToolTip="Cancel add row" CommandName="CancelNewRow" />
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
