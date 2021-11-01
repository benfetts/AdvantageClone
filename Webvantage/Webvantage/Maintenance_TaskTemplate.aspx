<%@ Page Title="Task Template Maintenance" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_TaskTemplate.aspx.vb" Inherits="Webvantage.Maintenance_TaskTemplate" %>

<asp:Content ID="ContentTaskTemplates" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function RadGridTaskTemplates_RowDoubleClick(sender, eventArgs) {
                __doPostBack("<%= RadGridTaskTemplates.UniqueID %>", "IndexOfRowDoubleClicked:" + eventArgs.get_itemIndexHierarchical());
        }
        function pageLoad() {
            var columns = $find('<%= RadGridTaskTemplates.ClientID%>').get_masterTableView().get_columns();
            $(columns).each(function () {
                this.set_resizable(true);
                this.resizeToFit(false, true);
                this.set_resizable(false);
            });
        }
        </script>

    </telerik:RadScriptBlock>
    <div class="telerik-aqua-body">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="75%">
                        <telerik:RadTabStrip ID="RadTabStripTaskMaintenance" runat="server" MultiPageID="RadMultiPageTaskMaintenance"
                            AutoPostBack="true" SelectedIndex="0" Style="z-index: 1000;">
                            <Tabs>
                                <telerik:RadTab Text="Task Templates">
                                </telerik:RadTab>
                                <telerik:RadTab Text="Task Template Detail">
                                </telerik:RadTab>
                            </Tabs>
                        </telerik:RadTabStrip>
                    </td>
                    <td align="right" valign="middle">
                        <asp:ImageButton ID="ImageButtonExport" runat="server" SkinID="ImageButtonExportExcel" />&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
            <telerik:RadMultiPage ID="RadMultiPageTaskMaintenance" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="RadPageViewTaskTemplates" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                        <br />
                        <telerik:RadGrid ID="RadGridTaskTemplates" runat="server" AllowPaging="True" AllowSorting="True"
                            GridLines="None" PageSize="10" EnableEmbeddedSkins="True" ShowFooter="False" Width="780"
                            AutoGenerateColumns="False">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                            <ClientSettings>
                                <Resizing AllowColumnResize="false" ResizeGridOnColumnResize="false" AllowResizeToFit="false" />
                            </ClientSettings>
                            <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="Code, Description, TotalStandardDays, TotalRushDays"
                                InsertItemDisplay="Top">
                                <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTaskTemplateCode" HeaderText="Code"
                                        SortExpression="Code">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <%# Eval("Code")%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxTaskTemplateCodeEditTextBox" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTaskTemplateDescription"
                                        HeaderText="Description" SortExpression="Description">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxTaskTemplateDescription" runat="server" Text='<%#Eval("Description") %>'
                                                MaxLength="30" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxTaskTemplateDescriptionEditTextBox" runat="server" MaxLength="30"
                                                SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTaskTemplateTotalStandardDays"
                                        HeaderText="Total<br/>Standard<br/>Days" SortExpression="TotalStandardDays">
                                        <HeaderStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%# Eval("TotalStandardDays")%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTaskTemplateTotalRushDays"
                                        HeaderText="Total<br/>Rush<br/>Days" SortExpression="TotalRushDays">
                                        <HeaderStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%# Eval("TotalRushDays")%>
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
                            <ClientSettings>
                                <ClientEvents OnRowDblClick="RadGridTaskTemplates_RowDoubleClick" />
                            </ClientSettings>
                        </telerik:RadGrid>
                        <br />
                </ContentTemplate>
            </asp:UpdatePanel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewTaskTemplateDetails" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    Task Template:
                                </div>
                                <div class="code-description-description">
                                    <telerik:RadComboBox ID="DropDownListTaskTemplate" runat="server" AutoPostBack="true"
                                        DataTextField="Code" DataValueField="Code" SkinID="RadComboBoxText15">
                                    </telerik:RadComboBox>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    Description:
                                </div>
                                <div class="code-description-description">
                                    <asp:TextBox ID="TextBoxTaskTemplateDescription" runat="server" MaxLength="30" SkinID="TextBoxText30"></asp:TextBox>
                                </div>
                            </div>
                            <div class="code-description-container">
                                <div class="code-description-label">
                                    Copy From Template:
                                </div>
                                <div class="code-description-description">
                                    <telerik:RadComboBox ID="DropDownListCopyTaskTemplateDetails" runat="server" AutoPostBack="false"
                                        DataTextField="Code" DataValueField="Code" SkinID="RadComboBoxText15">
                                    </telerik:RadComboBox>
                                    <asp:ImageButton ID="ImageButtonCopyTaskTemplateDetails" runat="server" SkinID="ImageButtonCopy" ToolTip="Copy Details From Template" />
                                </div>
                            </div>
                                <div class="code-description-container">
                                    <div class="code-description-label" style="width:240px;">
                                        Standard Days to Complete:
                                    </div>
                                    <div class="code-description-description">
                                        <asp:TextBox ID="TextBoxStandardScheduleCompletionDays" runat="server" Width="50" ReadOnly="true" SkinID="TextBoxStandard"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="code-description-container">
                                    <div class="code-description-label" style="width: 240px;">Rush Days to Complete:
                                    </div>
                                    <div class="code-description-description">
                                        <asp:TextBox ID="TextBoxRushScheduleCompletionDays" runat="server" Width="50" ReadOnly="true" SkinID="TextBoxStandard"></asp:TextBox>
                                    </div>
                                </div>
                            <div style="margin-top: 10px;">
                                <telerik:RadGrid ID="RadGridTaskTemplateDetails" runat="server" AllowPaging="True"
                                    AllowSorting="True" GridLines="None" PageSize="10" EnableEmbeddedSkins="True"
                                    ShowFooter="False" AutoGenerateColumns="False">
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" Height="20px"></PagerStyle>
                                    <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="TaskTemplateDetailID"
                                        InsertItemDisplay="Top">
                                        <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateDetailID" HeaderText="ID"
                                                Visible="false">
                                                <HeaderStyle Width="10" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%# Eval("TaskTemplateDetailID")%>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateDetailPhase" HeaderText="Phase"
                                                SortExpression="PhaseDescription">
                                                <HeaderStyle Width="125px" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle Width="125px" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle Width="125px" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <telerik:RadComboBox ID="DropDownListTemplateDetailPhase" runat="server" AutoPostBack="false" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                        DataTextField="Description" DataValueField="ID" Width="125px">
                                                    </telerik:RadComboBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox ID="DropDownListTemplateDetailPhaseEditDropDownList" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                        AutoPostBack="false" DataTextField="Description" DataValueField="ID" Width="125px">
                                                    </telerik:RadComboBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateDetailTask" HeaderText="Task"
                                                SortExpression="TaskDescription">
                                                <HeaderStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <FooterStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <telerik:RadComboBox ID="DropDownListTemplateDetailTaskCode" runat="server" AutoPostBack="false" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                        DataTextField="Description" DataValueField="Code" Width="200">
                                                    </telerik:RadComboBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox ID="DropDownListTemplateDetailTaskCodeEditDropDownList" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                        AutoPostBack="true" DataTextField="Description" DataValueField="Code" Width="200"
                                                        OnSelectedIndexChanged="TaskTemplateDetailTaskSelectionChanged">
                                                    </telerik:RadComboBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateDetailProcessOrderNumber"
                                                HeaderText="Process Order Number" SortExpression="ProcessOrderNumber">
                                                <HeaderStyle Width="70" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle Width="70" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <FooterStyle Width="70" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="TextBoxTemplateDetailProcessOrderNumber" runat="server"
                                                        Text='<%#Eval("ProcessOrderNumber") %>' Type="Number" Width="70" AutoPostBack="false"
                                                        MaxLength="4" MinValue="0">
                                                        <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                                        <EnabledStyle HorizontalAlign="Right" />
                                                    </telerik:RadNumericTextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadNumericTextBox ID="TextBoxTemplateDetailProcessOrderNumberEditTextBox"
                                                        runat="server" Type="Number" Width="70" MaxLength="4" MinValue="0">
                                                        <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                                        <EnabledStyle HorizontalAlign="Right" />
                                                    </telerik:RadNumericTextBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateDetailDaysToComplete"
                                                HeaderText="Days To Complete" SortExpression="DaysToComplete">
                                                <HeaderStyle Width="70" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle Width="70" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <FooterStyle Width="70" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="TextBoxTemplateDetailDaysToComplete" runat="server"
                                                        Text='<%#Eval("DaysToComplete") %>' Type="Number" Width="70" AutoPostBack="false"
                                                        MaxLength="4" MinValue="0">
                                                        <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                                        <EnabledStyle HorizontalAlign="Right" />
                                                    </telerik:RadNumericTextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadNumericTextBox ID="TextBoxTemplateDetailDaysToCompleteEditTextBox" runat="server"
                                                        Type="Number" Width="70" MaxLength="4" MinValue="0">
                                                        <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                                        <EnabledStyle HorizontalAlign="Right" />
                                                    </telerik:RadNumericTextBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateDetailHoursAllowed"
                                                HeaderText="Hours Allowed" SortExpression="HoursAllowed">
                                                <HeaderStyle Width="70" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle Width="70" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <FooterStyle Width="70" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="TextBoxTemplateDetailHoursAllowed" runat="server"
                                                        Text='<%#Eval("HoursAllowed") %>' Type="Number" Width="70" AutoPostBack="false"
                                                        MaxLength="7" MaxValue="9999.99" MinValue="0.00">
                                                        <NumberFormat DecimalDigits="2" GroupSeparator="" KeepTrailingZerosOnFocus="true" />
                                                        <EnabledStyle HorizontalAlign="Right" />
                                                    </telerik:RadNumericTextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadNumericTextBox ID="TextBoxTemplateDetailHoursAllowedEditTextBox" runat="server"
                                                        Type="Number" Width="70" MaxLength="7" MaxValue="9999.99" MinValue="0.00">
                                                        <NumberFormat DecimalDigits="2" GroupSeparator="" KeepTrailingZerosOnFocus="true" />
                                                        <EnabledStyle HorizontalAlign="Right" />
                                                    </telerik:RadNumericTextBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateDetailRushDaysToComplete"
                                                HeaderText="Rush Days To Complete" SortExpression="RushDaysToComplete">
                                                <HeaderStyle Width="70" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle Width="70" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <FooterStyle Width="70" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="TextBoxTemplateDetailRushDaysToComplete" runat="server"
                                                        Text='<%#Eval("RushDaysToComplete") %>' Type="Number" Width="70" AutoPostBack="false"
                                                        MaxLength="4" MinValue="0">
                                                        <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                                        <EnabledStyle HorizontalAlign="Right" />
                                                    </telerik:RadNumericTextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadNumericTextBox ID="TextBoxTemplateDetailRushDaysToCompleteEditTextBox"
                                                        runat="server" Type="Number" Width="70" MaxLength="4" MinValue="0">
                                                        <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                                        <EnabledStyle HorizontalAlign="Right" />
                                                    </telerik:RadNumericTextBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateDetailRushHoursToComplete"
                                                HeaderText="Rush Hours To Complete" SortExpression="RushHoursToComplete">
                                                <HeaderStyle Width="80" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle Width="80" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <FooterStyle Width="80" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="TextBoxTemplateDetailRushHoursToComplete" runat="server"
                                                        Text='<%#Eval("RushHoursToComplete") %>' Type="Number" Width="80" AutoPostBack="false"
                                                        MaxLength="7" MaxValue="9999.99" MinValue="0.00">
                                                        <NumberFormat DecimalDigits="2" GroupSeparator="" KeepTrailingZerosOnFocus="true" />
                                                        <EnabledStyle HorizontalAlign="Right" />
                                                    </telerik:RadNumericTextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadNumericTextBox ID="TextBoxTemplateDetailRushHoursToCompleteEditTextBox"
                                                        runat="server" Type="Number" Width="80" MaxLength="7" MaxValue="9999.99" MinValue="0.00">
                                                        <NumberFormat DecimalDigits="2" GroupSeparator="" KeepTrailingZerosOnFocus="true" />
                                                        <EnabledStyle HorizontalAlign="Right" />
                                                    </telerik:RadNumericTextBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateDetailIsMilestone"
                                                HeaderText="Milestone" SortExpression="IsMilestone">
                                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="10" />
                                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="10"  />
                                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="10"  />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxTemplateDetailIsMilestone" runat="server" AutoPostBack="false"
                                                        Checked='<%#Eval("IsMilestone") %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxTemplateDetailIsMilestoneEditCheckBox" runat="server" AutoPostBack="false" />
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateDetailDefaultEmployee"
                                                HeaderText="Default Employee" SortExpression="DefaultEmployeeName">
                                                <HeaderStyle Width="125" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle Width="125" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <FooterStyle Width="125" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <telerik:RadComboBox ID="DropDownListTemplateDetailDefaultEmployee" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                        AutoPostBack="false" DataTextField="FullName" DataValueField="Code" Width="125">
                                                    </telerik:RadComboBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox ID="DropDownListTemplateDetailDefaultEmployeeEditDropDownList" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                        runat="server" AutoPostBack="false" DataTextField="FullName" DataValueField="Code"
                                                        Width="125">
                                                    </telerik:RadComboBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateDetailDefaultFunction"
                                                HeaderText="Default Function" SortExpression="DefaultFunctionDescription">
                                                <HeaderStyle Width="225" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle Width="225" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <FooterStyle Width="225" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <telerik:RadComboBox ID="DropDownListTemplateDetailDefaultFunction" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                        AutoPostBack="false" DataTextField="Description" DataValueField="Code" Width="225">
                                                    </telerik:RadComboBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox ID="DropDownListTemplateDetailDefaultFunctionEditDropDownList" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                        runat="server" AutoPostBack="false" DataTextField="Description" DataValueField="Code"
                                                        Width="225">
                                                    </telerik:RadComboBox>
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
                            </div>
                </ContentTemplate>
            </asp:UpdatePanel>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
    </div>
    
</asp:Content>
