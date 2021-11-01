<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Campaign_Setup.aspx.vb"
    Inherits="Webvantage.Campaign_Setup" MasterPageFile="~/ChildPage.Master" Title="Campaigns" %>



<asp:Content ID="ContentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <asp:Panel ID="PanelFloatMenu" runat="server" HorizontalAlign="center" Width="100%">
        <div id="DivFloatMenu">
            <telerik:RadToolBar ID="RadToolbarJobTemplateTop" runat="server" AutoPostBack="True"
                Width="100%">
                <Items>
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolbarButtonSave" SkinID="RadToolBarButtonSave"
                        Text="" Value="Save" ToolTip="Save Campaign" />
                    <telerik:RadToolBarButton ID="RadToolbarButtonAdd" SkinID="RadToolBarButtonNew" Text="Add"
                        CommandName="Add" Value="Add" ToolTip="Add Campaign" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolbarButtonCreateBudget" 
                        Text="Create Budget" Value="CreateBudget" ToolTip="Create Budget" />
                    <telerik:RadToolBarButton ID="RadToolbarButtonReAllocateBudget" 
                        Text="Re-Allocate Budget" CommandName="ReAllocateBudget" Value="ReAllocateBudget"
                        ToolTip="Re-Allocate Budget" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                </Items>
            </telerik:RadToolBar>
        </div>
    </asp:Panel>
    <telerik:RadSplitter ID="RadSplitter" runat="server" Width="100%" Height="100%">
        <telerik:RadPane ID="RadPaneCampaigns" runat="server">
            <dx:ASPxGridView ID="ASPxGridViewCampaigns" runat="server" Width="100%" Settings-ShowTitlePanel="false"
                Settings-ShowVerticalScrollBar="false" EnableCallbackCompression="false" EnableCallBacks="false"
                SettingsPager-PageSize="15">
                <Settings ShowHeaderFilterButton="true" />
                <SettingsBehavior ProcessSelectionChangedOnServer="true" ColumnResizeMode="Control"
                    AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" />
                <Styles>
                    <Header Font-Names="Arial" />
                </Styles>
            </dx:ASPxGridView>
        </telerik:RadPane>
        <telerik:RadSplitBar ID="RadSplitBarSplit" runat="server">
        </telerik:RadSplitBar>
        <telerik:RadPane ID="RadPaneCampaignDetails" runat="server">
            <telerik:RadTabStrip ID="RadTabStripCampaignDetails" runat="server" MultiPageID="RadMultiPageCampaignDetails"
                AutoPostBack="true" SelectedIndex="0" Style="z-index: 1000;">
                <Tabs>
                    <telerik:RadTab Text="Information">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Campaign Details">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Jobs And Media Orders">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPageCampaignDetails" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="RadPageViewInformation" runat="server">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td colspan="3" align="right">
                                &nbsp;
                                <asp:CheckBox ID="CheckBoxIsClosed" runat="server" AutoPostBack="false" Checked="false"
                                    Text="Closed" />
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td width="5%">
                                Office:
                            </td>
                            <td>
                                <telerik:RadComboBox ID="RadComboBoxOffice" runat="server" AutoPostBack="false" DataTextField="Name" SkinID="RadComboBoxStandard"
                                    DataValueField="Code" Width="100%">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td width="5%">
                                Client:
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxClient" runat="server" ReadOnly="true" SkinID="TextBoxStandard" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td width="5%">
                                Division:
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxDivision" runat="server" ReadOnly="true" SkinID="TextBoxStandard" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td width="5%">
                                Product:
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxProduct" runat="server" ReadOnly="true" SkinID="TextBoxStandard" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                Code:&nbsp;&nbsp;<asp:TextBox ID="TextBoxCode" runat="server" ReadOnly="true" SkinID="TextBoxStandard"></asp:TextBox>&nbsp;&nbsp;
                                Name:&nbsp;&nbsp;<asp:TextBox ID="TextBoxName" runat="server" Width="50%" MaxLength="60" SkinID="TextBoxStandard"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td width="5%">
                                Alert Group:
                            </td>
                            <td>
                                <telerik:RadComboBox ID="RadComboBoxAlertGroup" runat="server" AutoPostBack="false" SkinID="RadComboBoxStandard"
                                    DataTextField="Code" DataValueField="Code" >
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td width="5%">
                                Campaign Type:
                            </td>
                            <td>
                                <telerik:RadButton ID="RadButtonAssignedToJobsAndOrders" runat="server" ToggleType="Radio"
                                    ButtonType="ToggleButton" Checked="true" GroupName="CampaignType" AutoPostBack="false"
                                    Text="Assigned To Jobs And Orders" Font-Underline="false">
                                </telerik:RadButton>
                                <br />
                                <telerik:RadButton ID="RadButtonOverall" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
                                    GroupName="CampaignType" AutoPostBack="false" Text="Overall" Font-Underline="false">
                                </telerik:RadButton>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td width="5%">
                                Beginning Date:
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="RadDatePickerBeginningDate" runat="server" SkinID="RadDatePickerStandard">
                                    <DateInput runat="server" DateFormat="d" EmptyMessage="">
                                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td width="5%">
                                Ending Date:
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="RadDatePickerEndingDate" runat="server" SkinID="RadDatePickerStandard">
                                    <DateInput runat="server" DateFormat="d" EmptyMessage="">
                                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <ew:CollapsablePanel ID="CollapsablePanelMediaTypes" runat="server"TitleText="Media Types"
                                    >
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="CheckBoxMagazine" runat="server" AutoPostBack="false" Checked="false"
                                                    Text="Magazine" />
                                                <asp:CheckBox ID="CheckBoxNewspaper" runat="server" AutoPostBack="false" Checked="false"
                                                    Text="Newspaper" />
                                                <asp:CheckBox ID="CheckBoxInternet" runat="server" AutoPostBack="false" Checked="false"
                                                    Text="Internet" />
                                                <asp:CheckBox ID="CheckBoxOutOfHome" runat="server" AutoPostBack="false" Checked="false"
                                                    Text="Out Of Home" />
                                                <asp:CheckBox ID="CheckBoxRadio" runat="server" AutoPostBack="false" Checked="false"
                                                    Text="Radio" />
                                                <asp:CheckBox ID="CheckBoxTelevision" runat="server" AutoPostBack="false" Checked="false"
                                                    Text="Television" />
                                                <asp:CheckBox ID="CheckBoxPrintCollateral" runat="server" AutoPostBack="false" Checked="false"
                                                    Text="Print/Collateral" />
                                                <asp:CheckBox ID="CheckBoxDirectResponse" runat="server" AutoPostBack="false" Checked="false"
                                                    Text="Direct Response" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="CheckBoxOther" runat="server" AutoPostBack="false" Checked="false"
                                                    Text="Other" />&nbsp;&nbsp;
                                                <asp:TextBox ID="TextBoxOther" runat="server" Enabled="false" SkinID="TextBoxStandard"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </ew:CollapsablePanel>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <ew:CollapsablePanel ID="CollapsablePanelComments" runat="server" TitleText="Comments"
                                    >
                                    <asp:TextBox ID="TextBoxComments" runat="server" TextMode="MultiLine"  Rows="90" SkinID="TextBoxStandard"
                                       ></asp:TextBox>
                                </ew:CollapsablePanel>
                            </td>
                        </tr>
                    </table>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewCampaignDetails" runat="server">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td width="48%">
                                Total Billing:&nbsp;&nbsp;<telerik:RadNumericTextBox ID="RadNumericTextBoxTotalBilling"
                                    runat="server" Type="Currency">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td width="49%">
                                Total Income:&nbsp;&nbsp;<telerik:RadNumericTextBox ID="RadNumericTextBoxTotalIncome"
                                    runat="server" Type="Currency">
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td width="48%">
                                <u>Billing Amount Totals</u>
                            </td>
                            <td width="49%">
                                <u>Income Amount Totals</u>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td width="48%">
                                Media Budget:&nbsp;&nbsp;&nbsp;<asp:Label ID="LabelBillingMediaBudgetAmount" runat="server"
                                    EnableViewState="false" Text="$0.00"></asp:Label>
                            </td>
                            <td width="49%">
                                Media Budget:&nbsp;&nbsp;&nbsp;<asp:Label ID="LabelIncomeMediaBudgetAmount" runat="server"
                                    EnableViewState="false" Text="$0.00"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td width="48%">
                                Production Budget:&nbsp;&nbsp;&nbsp;<asp:Label ID="LabelBillingProductionBudgetAmount"
                                    runat="server" EnableViewState="false" Text="$0.00"></asp:Label>
                            </td>
                            <td width="49%">
                                Production Budget:&nbsp;&nbsp;&nbsp;<asp:Label ID="LabelIncomeProductionBudgetAmount"
                                    runat="server" EnableViewState="false" Text="$0.00"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td width="48%">
                                Combined Budget:&nbsp;&nbsp;&nbsp;<asp:Label ID="LabelBillingCombinedBudgetAmount"
                                    runat="server" EnableViewState="false" Text="$0.00"></asp:Label>
                            </td>
                            <td width="49%">
                                Combined Budget:&nbsp;&nbsp;&nbsp;<asp:Label ID="LabelIncomeCombinedBudgetAmount"
                                    runat="server" EnableViewState="false" Text="$0.00"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td width="48%">
                                Total Allocated:&nbsp;&nbsp;&nbsp;<asp:Label ID="LabelBillingTotalAllocatedAmount"
                                    runat="server" EnableViewState="false" Text="$0.00"></asp:Label>
                            </td>
                            <td width="49%">
                                Total Allocated:&nbsp;&nbsp;&nbsp;<asp:Label ID="LabelIncomeTotalAllocatedAmount"
                                    runat="server" EnableViewState="false" Text="$0.00"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <telerik:RadGrid ID="RadGridCampaignDetails" runat="server" AllowPaging="True" AllowSorting="True"
                                    GridLines="None" PageSize="10" EnableEmbeddedSkins="True" ShowFooter="False"
                                    AutoGenerateColumns="False" Width="99%">
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" Height="20px">
                                    </PagerStyle>
                                    <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ID"
                                        InsertItemDisplay="Top">
                                        <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateDetailID" HeaderText="ID"
                                                Visible="false">
                                                <HeaderStyle Width="10" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%# Eval("ID")%>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnPostPeriod" HeaderText="Post Period"
                                                SortExpression="PostPeriod">
                                                <HeaderStyle Width="125" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle Width="125" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle Width="125" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <telerik:RadComboBox ID="RadComboBoxPostPeriod" runat="server" AutoPostBack="false" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                        DataTextField="Code" DataValueField="Code" Width="125">
                                                    </telerik:RadComboBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox ID="RadComboBoxPostPeriodEdit" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                        AutoPostBack="false" DataTextField="Code" DataValueField="Code" Width="125">
                                                    </telerik:RadComboBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnCampaignDetailType" HeaderText="Type"
                                                SortExpression="CampaignDetailType">
                                                <HeaderStyle Width="125" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle Width="125" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle Width="125" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <telerik:RadComboBox ID="RadComboBoxCampaignDetailType" runat="server" AutoPostBack="false" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                        DataTextField="Description" DataValueField="Code" Width="125">
                                                    </telerik:RadComboBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox ID="RadComboBoxCampaignDetailTypeEdit" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                        AutoPostBack="false" DataTextField="Description" DataValueField="Code" Width="125">
                                                    </telerik:RadComboBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSalesClass" HeaderText="Sales Class"
                                                SortExpression="SalesClass">
                                                <HeaderStyle Width="125" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle Width="125" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle Width="125" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <telerik:RadComboBox ID="RadComboBoxSalesClass" runat="server" AutoPostBack="false" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                        DataTextField="Description" DataValueField="Code" Width="125">
                                                    </telerik:RadComboBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox ID="RadComboBoxSalesClassEdit" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                        AutoPostBack="false" DataTextField="Description" DataValueField="Code" Width="125">
                                                    </telerik:RadComboBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDepartmentTeam" HeaderText="Department\Team"
                                                SortExpression="DepartmentTeam">
                                                <HeaderStyle Width="125" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle Width="125" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle Width="125" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <telerik:RadComboBox ID="RadComboBoxDepartmentTeam" runat="server" AutoPostBack="false" SkinID="RadComboBoxStandard"
                                                        DataTextField="Description" DataValueField="Code" Width="125">
                                                    </telerik:RadComboBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox ID="RadComboBoxDepartmentTeamEdit" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                        AutoPostBack="false" DataTextField="Description" DataValueField="Code" Width="125">
                                                    </telerik:RadComboBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnBillingBudgetAmount" HeaderText="Billing Budget"
                                                SortExpression="BillingBudgetAmount">
                                                <HeaderStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <FooterStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxBillingBudgetAmount" runat="server" Text='<%#Eval("BillingBudgetAmount") %>'
                                                        Type="Currency" Width="30" MinValue="0">
                                                    </telerik:RadNumericTextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxBillingBudgetAmountEdit" runat="server" 
                                                        Type="Currency" Width="30" MinValue="0">
                                                    </telerik:RadNumericTextBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIncomeBudgetAmount" HeaderText="Income Budget"
                                                SortExpression="IncomeBudgetAmount">
                                                <HeaderStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <FooterStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxIncomeBudgetAmount" runat="server" Text='<%#Eval("IncomeBudgetAmount") %>'
                                                        Type="Currency" Width="30" MinValue="0">
                                                    </telerik:RadNumericTextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxIncomeBudgetAmountEdit" runat="server" 
                                                        Type="Currency" Width="30" MinValue="0">
                                                    </telerik:RadNumericTextBox>
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
                                                        <asp:ImageButton ID="ImageButtonSave" runat="server" SkinID="ImageButtonSaveImageButtonNewWhite"
                                                            ToolTip="Click to save this row" CommandName="SaveRow" />
                                                    </div>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <div class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="ImageButtonSaveNew" runat="server" SkinID="ImageButtonNewImageButtonNewWhite"
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
                            </td>
                        </tr>
                    </table>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewJobsAndMediaOrders" runat="server">
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </telerik:RadPane>
    </telerik:RadSplitter>
</asp:Content>
