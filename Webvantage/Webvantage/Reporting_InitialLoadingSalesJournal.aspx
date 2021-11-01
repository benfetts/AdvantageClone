<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_InitialLoadingSalesJournal.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.Reporting_InitialLoadingSalesJournal"
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
                    <telerik:RadTab Text="Select Offices" PageViewID="RadPageViewSelectOffices" Value="1">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Select C/D/P" PageViewID="RadPageViewWorkloadSelectCDP" Value="2">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPageCalendar" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="RadPageViewOptions" runat="server">
                    <div class="form-layout label-left label-l">
                        <ul>
                            <li>
                                <asp:Label ID="LabelStartingPostPeriod" runat="server" Text="Starting Post Period:" /></li>
                            <li>
                                <telerik:RadComboBox ID="RadComboBoxStart" runat="server" AutoPostBack="false" SkinID="RadComboBoxPostPeriod"></telerik:RadComboBox>
                            </li>
                            <li style="margin-left: 20px;">
                                <telerik:RadButton ID="RadButtonYTD" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="YTD"></telerik:RadButton>
                            </li>
                            <li>
                                <telerik:RadButton ID="RadButton1Year" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="1 Year"></telerik:RadButton>
                            </li>
                        </ul>
                        <ul>
                            <li>
                                <asp:Label ID="LabelEndingPostPeriod" runat="server" Text="Ending Post Period:" /></li>
                            <li>
                                <telerik:RadComboBox ID="RadComboBoxEnd" runat="server" AutoPostBack="false" SkinID="RadComboBoxPostPeriod"></telerik:RadComboBox>
                            </li>
                            <li style="margin-left: 20px;">
                                <telerik:RadButton ID="RadButtonMTD" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="MTD"></telerik:RadButton>
                            </li>
                            <li>
                                <telerik:RadButton ID="RadButton2Years" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="2 Year"></telerik:RadButton>
                            </li>
                        </ul>
                    </div>
                    <div class="form-layout label-left label-l">
                         <%--<ul>
                            <li>
                                <asp:Label ID="LabelSelectBy" runat="server" Text="Select By:" /></li>
                            <li>
                                <asp:RadioButton id="RadioButtonARPeriod" runat="server" Text="AR Period"/>
                                <asp:RadioButton id="RadioButtonSalesPeriod" runat="server" Text="Sales Period"/>
                            </li>
                            <li>&nbsp</li>
                        </ul>--%>
                        <ul>
                            <li>&nbsp</li>
                            <li>
                                <asp:CheckBox ID="CheckBoxBreakoutCoOpBilling" runat="server" Text="Breakout Co-Op Billing" /></li>
                        </ul>
                        <ul>
                            <li>&nbsp</li>
                            <li>
                                <asp:CheckBox ID="CheckBoxFilterByDate" runat="server" Text="Filter by Date (Within Period Selected)" AutoPostBack="true" /></li>
                        </ul>
                    </div>
                    <div class="form-layout label-left label-l">
                        <ul>
                            <li>
                                <asp:Label ID="LabelInvoiceFromDate" runat="server" Text="Invoice From Date:" /></li> 
                            <li>
                                <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" SkinID="RadDatePickerStandard">
                                    <DateInput DateFormat="d" EmptyMessage="Start Date">
                                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                    </DateInput>
                                    <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                        <SpecialDays>
                                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                            </telerik:RadCalendarDay>
                                        </SpecialDays>
                                    </Calendar>
                                </telerik:RadDatePicker>
                            </li>
                            <li style="margin-left: 20px;">
                                <telerik:RadButton ID="RadButtonInvoiceYTD" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="YTD"></telerik:RadButton>
                            </li>
                            <li>
                                <telerik:RadButton ID="RadButtonInvoice1Year" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="1 Year"></telerik:RadButton>
                            </li>
                        </ul>
                        <ul>
                            <li>
                                <asp:Label ID="LabelInvoiceToDate" runat="server" Text="Invoice To Date" /></li> 
                            <li>
                                <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server"
                                    SkinID="RadDatePickerStandard">
                                    <DateInput DateFormat="d" EmptyMessage="End Date">
                                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                    </DateInput>
                                    <Calendar ID="CalendarEndDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                        <SpecialDays>
                                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                            </telerik:RadCalendarDay>
                                        </SpecialDays>
                                    </Calendar>
                                </telerik:RadDatePicker>
                            </li>
                            <li style="margin-left: 20px;">
                                <telerik:RadButton ID="RadButtonInvoiceMTD" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="MTD"></telerik:RadButton>
                            </li>
                            <li>
                                <telerik:RadButton ID="RadButtonInvoice2Year" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="2 Year"></telerik:RadButton>
                            </li>
                        </ul>
                    </div>                     
                        
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewSelectOffices" runat="server">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButtonAllOffices" runat="server" Text="All Offices" GroupName="Office" Checked="true" AutoPostBack="true" />
                                <asp:RadioButton ID="RadioButtonChooseOffices" runat="server" Text="Choose Offices" GroupName="Office" AutoPostBack="true" />
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
                                <asp:RadioButton ID="RadioButtonAll" runat="server" Text="All" GroupName="All" Checked="true" AutoPostBack="true" />
                                <asp:RadioButton ID="RadioButtonChoose" runat="server" Text="Choose" GroupName="All" AutoPostBack="true" />
                            </td>
                        </tr>
                        <asp:Panel ID="PanelCDP" runat="server">
                            <tr>
                                <td>
                                    <asp:RadioButton ID="RadioButtonClient" runat="server" Text="Client" GroupName="CDP" AutoPostBack="true" Checked="true" />
                                    <asp:RadioButton ID="RadioButtonClientDivision" runat="server" Text="Client/Division" GroupName="CDP" AutoPostBack="true" />
                                    <asp:RadioButton ID="RadioButtonClientDivisionProduct" runat="server" Text="Client/Division/Product" GroupName="CDP" AutoPostBack="true" />
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
                                    <MasterTableView DataKeyNames="Code,Client,ClientCode,Division,IsInactive">
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
                                    <MasterTableView DataKeyNames="Code,Client,ClientCode,Office,Division,DivisionCode,Product,IsInactive">
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
            </telerik:RadMultiPage>
        </div>
    </div>
    <br />
</asp:Content>
