<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_InitialLoadingMediaCurrentStatus.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.Reporting_InitialLoadingMediaCurrentStatus"
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
    <table align="center" border="0" cellpadding="0" cellspacing="0" 
        width="100%">
        <tr>
            <td runat="server" id="TdRadToolBarDynamicReportInitialLoading" align="left" valign="top"
                colspan="2">
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
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" colspan="2">
                <telerik:RadTabStrip ID="RadTabStripTaskCalendar" runat="server" AutoPostBack="true" MultiPageID="RadMultiPageCalendar"
                        Orientation="HorizontalTop"  CausesValidation="false"
                         Width="100%">
                        <Tabs>
                            <telerik:RadTab Text="Options" PageViewID="RadPageViewOptions" Value="0">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Select Offices" PageViewID="RadPageViewSelectOffices" Value="1">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Select C/D/P" PageViewID="RadPageViewWorkloadSelectCDP" Value="2">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Select Campaigns" PageViewID="RadPageViewSelectCampaigns" Value="3">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Select Vendors" PageViewID="RadPageViewVendors" Value="4">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Select Markets" PageViewID="RadPageViewMarkets" Value="5">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Select Orders" PageViewID="RadPageViewOrders" Value="6">
                            </telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPageCalendar" runat="server" SelectedIndex="0">
                        <telerik:RadPageView ID="RadPageViewOptions" runat="server">
                            <table id="Table2" align="center" cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td valign="top">
                                        <fieldset id="FieldsetInclude" runat="server">
                                        <legend>Include</legend>
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:RadioButton id="RadioButtonOpenOnly" runat="server" Text="Open Only" GroupName="Open" Checked="true" AutoPostBack="true"/><br />
                                                        <asp:RadioButton id="RadioButtonOpenAndClosed" runat="server" Text="Open And Closed" GroupName="Open" AutoPostBack="true"/>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>
                                    <td valign="top">
                                        <fieldset id="FieldsetMediaTypes" runat="server">
                                        <legend>Media Types</legend>
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox id="CheckBoxAll" runat="server" Text="All" AutoPostBack="true"/><br />
                                                        <asp:CheckBox id="CheckBoxInternet" runat="server" Text="Internet"/><br />
                                                        <asp:CheckBox id="CheckBoxMagazine" runat="server" Text="Magazine"/><br />
                                                        <asp:CheckBox id="CheckBoxNewspaper" runat="server" Text="Newspaper"/><br />
                                                        <asp:CheckBox id="CheckBoxOutOfHome" runat="server" Text="Out of Home"/><br />
                                                        <asp:CheckBox id="CheckBoxRadio" runat="server" Text="Radio"/><br />
                                                        <asp:CheckBox id="CheckBoxTelevision" runat="server" Text="Television"/>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>
                                    <td valign="top">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PanelNonDailyBroadcast" runat="server" Visible="false">
                                                    <fieldset id="FieldsetNonDailyBroadcast" runat="server">
                                                    <legend>Non/Daily Broadcast</legend>
                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:RadioButton id="RadioButtonInsertStartPostDate" runat="server" Text="Insert/Start/Post Date" GroupName="Date" Checked="true"/>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblFrom" runat="server" Text="From: "></asp:Label>&nbsp;                                                                    
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" SkinID="RadDatePickerStandard">
                                                                                    <DateInput DateFormat="d" EmptyMessage="">
                                                                                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                                                    </DateInput>
                                                                                    <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                                                        <SpecialDays>
                                                                                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                                                            </telerik:RadCalendarDay>
                                                                                        </SpecialDays>
                                                                                    </Calendar>
                                                                                </telerik:RadDatePicker>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:RadioButton id="RadioButtonDateToBill" runat="server" Text="Date To Bill" GroupName="Date"/>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblTo" runat="server" Text="To: "></asp:Label>&nbsp;
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server" MinDate="1950-01-01"
                                                                                    DatePopupButton-ToolTip="Show calendar" MaxDate="2050-01-01">
                                                                                    <DateInput DateFormat="d" EmptyMessage="">
                                                                                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                                                    </DateInput>
                                                                                    <Calendar ID="CalendarEndDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                                                        <SpecialDays>
                                                                                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                                                            </telerik:RadCalendarDay>
                                                                                        </SpecialDays>
                                                                                    </Calendar>
                                                                                </telerik:RadDatePicker>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <asp:RadioButton id="RadioButtonMaterialCloseDate" runat="server" Text="Material Close Date" GroupName="Date"/>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <asp:RadioButton id="RadioButtonSpaceCloseDate" runat="server" Text="Space Close Date" GroupName="Date"/>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                    </asp:Panel>    
                                                    <asp:Panel ID="PanelMonthlyBroadcast" runat="server" Visible="false">
                                                    <fieldset id="FieldsetMonthlyBroadcast" runat="server">
                                                    <legend>Monthly Broadcast</legend>
                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:RadioButton id="RadioButtonBroadcastDateMonth" runat="server" Text="Broadcast Date" GroupName="MonthDate" Checked="true"/>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="LabelFromMonth" runat="server" Text="From: "></asp:Label>&nbsp;    
                                                                </td>
                                                                <td>
                                                                    <telerik:RadComboBox ID="RadComboBoxFromMonth" runat="server" AutoPostBack="false">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBoxFromYear" runat="server" SkinID="TextBoxStandard"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:RadioButton id="RadioButtonMaterialCloseDateMonth" runat="server" Text="Material Close Date" GroupName="MonthDate"/>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="LabelToMonth" runat="server" Text="To: "></asp:Label>&nbsp;
                                                                </td>
                                                                <td>
                                                                    <telerik:RadComboBox ID="RadComboBoxToMonth" runat="server" AutoPostBack="false">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBoxToYear" runat="server" SkinID="TextBoxStandard"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="right">
                                        <asp:Label ID="LabelNote" runat="server" Text="* Uses the first material close date of each order/month to select detail." Visible="false"></asp:Label>
                                    </td>
                                </tr>
                            </table>                                         
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageViewSelectOffices" runat="server">                            
                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">                                
                                <tr>
                                    <td>
                                        <asp:RadioButton id="RadioButtonAllOffices" runat="server" Text="All Offices" GroupName="Office" Checked="true" AutoPostBack="true"/>
                                        <asp:RadioButton id="RadioButtonChooseOffices" runat="server" Text="Choose Offices" GroupName="Office" AutoPostBack="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="RadGridOffice" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="Code,Name,IsInactive">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="Code" HeaderText="Code" UniqueName="column3">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Name" HeaderText="Name" UniqueName="column2">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-HorizontalAlign="Center" UniqueName="colInactive">                                                            
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkInactive" runat="server" Checked='<%#Eval("IsInactive")%>' Enabled="false" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
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
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageViewWorkloadSelectCDP" runat="server">
                            <table id="Table1" align="center" cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td>
                                        <asp:RadioButton id="RadioButtonAll" runat="server" Text="All" GroupName="All" Checked="true" AutoPostBack="true"/>
                                        <asp:RadioButton id="RadioButtonChoose" runat="server" Text="Choose" GroupName="All" AutoPostBack="true"/>
                                    </td>
                                </tr>
                                <asp:Panel ID="PanelCDP" runat="server">
                                <tr>
                                    <td>
                                        <asp:RadioButton id="RadioButtonClient" runat="server" Text="Client" GroupName="CDP" AutoPostBack="true" Checked="true"/>
                                        <asp:RadioButton id="RadioButtonClientDivision" runat="server" Text="Client/Division" GroupName="CDP" AutoPostBack="true"/>
                                        <asp:RadioButton id="RadioButtonClientDivisionProduct" runat="server" Text="Client/Division/Product" GroupName="CDP" AutoPostBack="true"/>
                                    </td>
                                </tr>
                                </asp:Panel>
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="RadGridClient" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="Code,IsNewBusiness,IsInactive">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="Client" HeaderText="Client" UniqueName="column2">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Is New Business" ItemStyle-HorizontalAlign="Center" UniqueName="colIsNewBusiness">                                                            
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
                                        <telerik:RadGrid ID="RadGridCD" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="Code,Client,Division,IsInactive">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="Client" HeaderText="Client" UniqueName="column2">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Division" HeaderText="Division" UniqueName="column3">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Is Inactive" ItemStyle-HorizontalAlign="Center" UniqueName="colInactive">                                                            
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkInactive" runat="server" Checked='<%#Eval("IsInactive")%>' Enabled="false" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
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
                                        <telerik:RadGrid ID="RadGridCDP" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="Code,Client,Office,Division,Product,IsInactive">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="Office" HeaderText="Office" UniqueName="column5">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Client" HeaderText="Client" UniqueName="column2">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Division" HeaderText="Division" UniqueName="column3">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Product" HeaderText="Product" UniqueName="column4">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Is Inactive" ItemStyle-HorizontalAlign="Center" UniqueName="colInactive">                                                            
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkInactive" runat="server" Checked='<%#Eval("IsInactive")%>' Enabled="false" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
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
                                    </td>
                                </tr>
                            </table>                                         
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageViewSelectCampaigns" runat="server">                            
                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">                                
                                <tr>
                                    <td>
                                        <asp:RadioButton id="RadioButtonAllCampaigns" runat="server" Text="All Campaigns" GroupName="Campaign" Checked="true" AutoPostBack="true"/>
                                        <asp:RadioButton id="RadioButtonChooseCampaigns" runat="server" Text="Choose Campaigns" GroupName="Campaign" AutoPostBack="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="RadGridCampaign" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="Campaign,ID">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="Campaign" HeaderText="Campaign" UniqueName="column2">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Is Closed" ItemStyle-HorizontalAlign="Center" UniqueName="colIsClosed">                                                            
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkIsClosed" runat="server" Checked='<%#Eval("IsClosed")%>' Enabled="false" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
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
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageViewVendors" runat="server">
                            <table id="Table3" align="center" cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td>
                                        <asp:RadioButton id="RadioButtonAllVendors" runat="server" Text="All Vendors" GroupName="Vendor" Checked="true" AutoPostBack="true"/>
                                        <asp:RadioButton id="RadioButtonChooseVendors" runat="server" Text="Choose Vendors" GroupName="Vendor" AutoPostBack="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="RadGridVendors" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="Code,Name,ActiveFlag">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="Code" HeaderText="Code" UniqueName="column3">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Name" HeaderText="Name" UniqueName="column2">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Is Inactive" ItemStyle-HorizontalAlign="Center" UniqueName="colInactive">                                                            
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkInactive" runat="server" Checked='<%#Eval("ActiveFlag")%>' Enabled="false" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
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
                                    </td>
                                </tr>
                            </table>                                         
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageViewMarkets" runat="server">                            
                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">                                
                                <tr>
                                    <td>
                                        <asp:RadioButton id="RadioButtonAllMarkets" runat="server" Text="All Markets" GroupName="Market" Checked="true" AutoPostBack="true"/>
                                        <asp:RadioButton id="RadioButtonChooseMarkets" runat="server" Text="Choose Markets" GroupName="Market" AutoPostBack="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="RadGridMarkets" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="Code,Description,IsInactive">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="Code" HeaderText="Code" UniqueName="column3">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Description" UniqueName="column2">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Is Inactive" ItemStyle-HorizontalAlign="Center" UniqueName="colInactive">                                                            
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkInactive" runat="server" Checked='<%#Eval("IsInactive")%>' Enabled="false" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
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
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageViewOrders" runat="server">   
                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">                                
                                <tr>
                                    <td>
                                        <asp:RadioButton id="RadioButtonAllOrders" runat="server" Text="All Orders" GroupName="Order" Checked="true" AutoPostBack="true"/>
                                        <asp:RadioButton id="RadioButtonChooseOrders" runat="server" Text="Choose Orders" GroupName="Order" AutoPostBack="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="RadGridOrders" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true">
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="ShortNumber,TypeInitial">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="ShortNumber" HeaderText="Number" UniqueName="column3">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Order" UniqueName="column2">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ClientPO" HeaderText="Client PO" UniqueName="column2">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Is Open" ItemStyle-HorizontalAlign="Center" UniqueName="colIsOpen">                                                            
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkIsOpen" runat="server" Checked='<%#Eval("IsOpen")%>' Enabled="false" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
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
                                    </td>
                                </tr>
                            </table>                     
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
