<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_InitialLoadingProjectSummaryAnalysis.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.Reporting_InitialLoadingProjectSummaryAnalysis"
    Title="Set Initial Criteria" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlockRadWindow" runat="server">
        <script type="text/javascript">
            function returnValue() {
                //Get a reference to the parent (MDI) page 
                var oWnd = GetRadWindow();
                //get a reference to the second RadWindow
                var CallingWindowName = 'Create';
                var CallingWindow = oWnd.get_windowManager().getWindowByName(CallingWindowName);
                // Get a reference to the first RadWindow's content
                var CallingWindowContent = CallingWindow.get_contentFrame().contentWindow;
                //Call the predefined function in Dialog1
                //alert(CallingWindowName + '\n' + CallingWindow + '\n');
                CallingWindowContent.ReloadColumns(oWnd);
                //Close the second RadWindow
                oWnd.close();
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadToolBar ID="RadToolBarDynamicReportInitialLoading" runat="server" AutoPostBack="true"
        Width="100%">
        <Items>
            <telerik:RadToolBarButton ID="RadToolBarSeparatorFirstSeparator" runat="server" IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonOK" runat="server"
                Text="OK" Value="OK" CommandName="OK" ToolTip="OK" />
            <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server"
                IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonCancel" runat="server" SkinID="RadToolBarButtonCancel"
                Text="Cancel" Value="Cancel" CommandName="Cancel" ToolTip="Cancel" />
            <telerik:RadToolBarButton ID="RadToolBarSeparatorThirdSeparator" runat="server" IsSeparator="true" />
        </Items>
    </telerik:RadToolBar>
    <div style="margin-top: 10px;">
        <div class="form-layout label-left label-l">
            <telerik:RadTabStrip ID="RadTabStripTaskCalendar" runat="server" AutoPostBack="true" MultiPageID="RadMultiPageCalendar"
                Orientation="HorizontalTop" CausesValidation="false"
                Width="100%">
                <Tabs>
                    <telerik:RadTab Text="Options" PageViewID="RadPageViewOptions" Value="0" Selected="true">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Select Clients" PageViewID="RadPageViewWorkloadSelectCDP" Value="1">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Select Account Executives" PageViewID="RadPageViewSelectAEs" Value="2">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Select Sales Classes" PageViewID="RadPageViewSelectCampaigns" Value="3">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Select Job Types" PageViewID="RadPageViewJobType" Value="4">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPageCalendar" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="RadPageViewOptions" runat="server">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" 
                        width="100%">       
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td>
                                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                                    <tr>
                                        <td width="10%">
                                            Criteria:
                                        </td>
                                        <td width="90%">
                                            <telerik:RadComboBox ID="RadComboBoxCriteria" runat="server" AutoPostBack="false"
                                                Width="100%" DataTextField="Name" DataValueField="Value">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td>
                                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                                    <tr>
                                        <td runat="server" id="tdFrom" width="10%">
                                            From:
                                        </td>
                                        <td width="50%">
                                            <telerik:RadDatePicker ID="RadDatePickerFrom" runat="server" AutoPostBack="true" SkinID="RadDatePickerStandard">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td width="20%">
                                            <telerik:RadButton ID="RadButtonYTD" runat="server" AutoPostBack="true" ButtonType="StandardButton"
                                                Text="YTD">
                                            </telerik:RadButton>
                                        </td>
                                        <td width="20%">
                                            <telerik:RadButton ID="RadButton1Year" runat="server" AutoPostBack="true" ButtonType="StandardButton"
                                                Text="1 Year">
                                            </telerik:RadButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server" id="trTo">
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td>
                                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                                    <tr>
                                        <td width="10%">
                                            To:
                                        </td>
                                        <td width="50%">
                                            <telerik:RadDatePicker ID="RadDatePickerTo" runat="server" AutoPostBack="true" SkinID="RadDatePickerStandard">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td width="20%">
                                            <telerik:RadButton ID="RadButtonMTD" runat="server" AutoPostBack="true" ButtonType="StandardButton"
                                                Text="MTD">
                                            </telerik:RadButton>
                                        </td>
                                        <td width="20%">
                                            <telerik:RadButton ID="RadButton2Years" runat="server" AutoPostBack="true" ButtonType="StandardButton"
                                                Text="2 Year">
                                            </telerik:RadButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td>
                                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                                    <tr>
                                        <td width="35%">
                                            Compare Actuals To:
                                        </td>
                                        <td>
                                            <asp:RadioButton id="RadioButtonQuoted" runat="server" Text="Quoted" GroupName="Hours" AutoPostBack="true"/>
                                            <asp:RadioButton id="RadioButtonPlanned" runat="server" Text="Planned" GroupName="Hours"/>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td>
                                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                                    <tr>
                                        <td width="35%">
                                            Definition of Planned:
                                        </td>
                                        <td>
                                            <asp:RadioButton id="RadioButtonForecast" runat="server" Text="Forecast" GroupName="Fore" AutoPostBack="true"/>
                                            <asp:RadioButton id="RadioButtonHoursAllowed" runat="server" Text="Hours Allowed" GroupName="Fore"/>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxIncludeDetail" runat="server" AutoPostBack="true"
                                    Checked="false" Text="Include Function Detail (No Forecast Data)"  />
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxIncludeEmployeeDetail" runat="server" AutoPostBack="True"
                                    Checked="false" Text="Include Employee Detail (No Quote and Forecast Data)"   />
                            </td>
                        </tr>
                    </table>                        
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewWorkloadSelectCDP" runat="server">
                    <table id="Table1" align="center" cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButtonAllCDP" runat="server" Text="All Clients" GroupName="All" Checked="true" AutoPostBack="true" />
                                <asp:RadioButton ID="RadioButtonChoose" runat="server" Text="Choose Clients" GroupName="All" AutoPostBack="true" />
                            </td>
                        </tr>
                        <asp:Panel ID="PanelCDP" runat="server">
                            <tr>
                                <td>
                                    <asp:RadioButton ID="RadioButtonClient" runat="server" Text="Client" GroupName="CDP" AutoPostBack="true" Checked="true" Visible="false" />
                                    <asp:RadioButton ID="RadioButtonClientDivision" runat="server" Text="Client/Division" GroupName="CDP" AutoPostBack="true" Visible="false" />
                                    <asp:RadioButton ID="RadioButtonClientDivisionProduct" runat="server" Text="Client/Division/Product" GroupName="CDP" AutoPostBack="true" Visible="false" />
                                </td>
                            </tr>
                        </asp:Panel>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="RadGridClient" runat="server" AutoGenerateColumns="False" GridLines="None"
                                    EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true" AllowFilteringByColumn="true" GroupingSettings-CaseSensitive="False">
                                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                        <Selecting AllowRowSelect="True"  EnableDragToSelectRows="True" />
                                    </ClientSettings>
                                    <MasterTableView DataKeyNames="Code,IsNewBusiness,IsInactive">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="Client" HeaderText="Client" UniqueName="column2" SortExpression="Client"
                                                    CurrentFilterFunction="Contains" FilterDelay="1250" AutoPostBackOnFilter="false">
                                            </telerik:GridBoundColumn>
                                            <%--<telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Is New Business" ItemStyle-HorizontalAlign="Center" UniqueName="colIsNewBusiness">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkIsNewBusiness" runat="server" Checked='<%#Eval("IsNewBusiness")%>' Enabled="false" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Is Inactive" ItemStyle-HorizontalAlign="Center" UniqueName="colInactive">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkInactive" runat="server" Checked='<%#Eval("IsInactive")%>' Enabled="false" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                            </telerik:GridTemplateColumn>--%>
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
                                <telerik:RadGrid ID="RadGridCD" runat="server" AutoGenerateColumns="False" GridLines="None"
                                    EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true" AllowFilteringByColumn="true" GroupingSettings-CaseSensitive="False">
                                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                                    </ClientSettings>
                                    <MasterTableView DataKeyNames="Code,Client,ClientCode,Division,IsInactive">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="Client" HeaderText="Client" UniqueName="column2" SortExpression="Client"
                                                    CurrentFilterFunction="Contains" FilterDelay="1250" AutoPostBackOnFilter="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Division" HeaderText="Division" UniqueName="column3" SortExpression="Division"
                                                    CurrentFilterFunction="Contains" FilterDelay="1250" AutoPostBackOnFilter="false">
                                            </telerik:GridBoundColumn>
                                            <%--<telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Is Inactive" ItemStyle-HorizontalAlign="Center" UniqueName="colInactive">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkInactive" runat="server" Checked='<%#Eval("IsInactive")%>' Enabled="false" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                            </telerik:GridTemplateColumn>--%>
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
                                <telerik:RadGrid ID="RadGridCDP" runat="server" AutoGenerateColumns="False" GridLines="None"
                                    EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true" AllowFilteringByColumn="true" GroupingSettings-CaseSensitive="False">
                                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                                    </ClientSettings>
                                    <MasterTableView DataKeyNames="Code,Client,ClientCode,Office,Division,DivisionCode,Product,IsInactive">
                                        <Columns>
                                            <%--<telerik:GridBoundColumn DataField="Office" HeaderText="Office" UniqueName="column5">
                                            </telerik:GridBoundColumn>--%>
                                            <telerik:GridBoundColumn DataField="Client" HeaderText="Client" UniqueName="column2" SortExpression="Client"
                                                    CurrentFilterFunction="Contains" FilterDelay="1250" AutoPostBackOnFilter="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Division" HeaderText="Division" UniqueName="column3" SortExpression="Division"
                                                    CurrentFilterFunction="Contains" FilterDelay="1250" AutoPostBackOnFilter="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Product" HeaderText="Product" UniqueName="column4" SortExpression="Product"
                                                    CurrentFilterFunction="Contains" FilterDelay="1250" AutoPostBackOnFilter="false">
                                            </telerik:GridBoundColumn>
                                            <%--<telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Is Inactive" ItemStyle-HorizontalAlign="Center" UniqueName="colInactive">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkInactive" runat="server" Checked='<%#Eval("IsInactive")%>' Enabled="false" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                            </telerik:GridTemplateColumn>--%>
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
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewSelectAEs" runat="server">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButtonAllAccountExecutives" runat="server" Text="All Account Executives" GroupName="Office" Checked="true" AutoPostBack="true" />
                                <asp:RadioButton ID="RadioButtonChooseAccountExecutives" runat="server" Text="Choose Account Executives" GroupName="Office" AutoPostBack="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="RadGridAccountExecutives" runat="server" AutoGenerateColumns="False" GridLines="None"
                                    EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true" AllowFilteringByColumn="true" GroupingSettings-CaseSensitive="False">
                                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                                    </ClientSettings>
                                    <MasterTableView DataKeyNames="Code,Description">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="Code" HeaderText="Code" UniqueName="column3" SortExpression="Code"
                                                    CurrentFilterFunction="Contains" FilterDelay="1250" AutoPostBackOnFilter="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Description" HeaderText="Name" UniqueName="column2" SortExpression="Description"
                                                    CurrentFilterFunction="Contains" FilterDelay="1250" AutoPostBackOnFilter="false">
                                            </telerik:GridBoundColumn>
                                            <%--<telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-HorizontalAlign="Center" UniqueName="colInactive">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkInactive" runat="server" Checked='<%#Eval("IsInactive")%>' Enabled="false" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                            </telerik:GridTemplateColumn>--%>
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
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewSelectCampaigns" runat="server">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButtonAllSalesClass" runat="server" Text="All Sales Classes" GroupName="SaleClasses" Checked="true" AutoPostBack="true" />
                                <asp:RadioButton ID="RadioButtonChooseSalesClass" runat="server" Text="Choose Sales Classes" GroupName="SaleClasses" AutoPostBack="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="RadGridSalesClass" runat="server" AutoGenerateColumns="False" GridLines="None"
                                    EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true" AllowFilteringByColumn="true" GroupingSettings-CaseSensitive="False">
                                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                                    </ClientSettings>
                                    <MasterTableView DataKeyNames="Code,Name">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="Code" HeaderText="Code" UniqueName="column3" SortExpression="Code"
                                                    CurrentFilterFunction="Contains" FilterDelay="1250" AutoPostBackOnFilter="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Name" HeaderText="Description" UniqueName="column2" SortExpression="Name"
                                                    CurrentFilterFunction="Contains" FilterDelay="1250" AutoPostBackOnFilter="false">
                                            </telerik:GridBoundColumn>
                                            <%--<telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-HorizontalAlign="Center" UniqueName="colInactive">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkInactive" runat="server" Checked='<%#Eval("IsInactive")%>' Enabled="false" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                            </telerik:GridTemplateColumn>--%>
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
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewJobType" runat="server">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButtonAllJobTypes" runat="server" Text="All Job Types" GroupName="JobTypes" Checked="true" AutoPostBack="true" />
                                <asp:RadioButton ID="RadioButtonChooseJobTypes" runat="server" Text="Choose Job Types" GroupName="JobTypes" AutoPostBack="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="RadGridJobTypes" runat="server" AutoGenerateColumns="False" GridLines="None"
                                    EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true" AllowFilteringByColumn="true" GroupingSettings-CaseSensitive="False">
                                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                                    </ClientSettings>
                                    <MasterTableView DataKeyNames="Code,Name">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="Code" HeaderText="Code" UniqueName="column3" SortExpression="Code"
                                                    CurrentFilterFunction="Contains" FilterDelay="1250" AutoPostBackOnFilter="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Name" HeaderText="Description" UniqueName="column2" SortExpression="Name"
                                                    CurrentFilterFunction="Contains" FilterDelay="1250" AutoPostBackOnFilter="false">
                                            </telerik:GridBoundColumn>
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
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </div>
    </div>

    
    <br />
</asp:Content>
