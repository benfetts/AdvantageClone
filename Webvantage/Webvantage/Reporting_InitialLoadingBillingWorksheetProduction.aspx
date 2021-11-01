<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_InitialLoadingBillingWorksheetProduction.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.Reporting_InitialLoadingBillingWorksheetProduction"
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
            function EnableDisableNonbillableDates(chkInclude) {
                var datepicker = $find("<%=RadDatePickerFromDate.ClientID %>");
                var datepickerTo = $find("<%=RadDatePickerToDate.ClientID %>");
                if (chkInclude.checked == true) {
                    datepicker.set_enabled(true);
                    datepickerTo.set_enabled(true);
                }
                else {
                    datepicker.set_enabled(false);
                    datepickerTo.set_enabled(false);
                }
            }
            function EnableDisableItemDetailCheckboxes(chkIncludeItemDetail) {
                if (chkIncludeItemDetail.checked == true) {                    
                    $('#TimeComments').show();
                    $('#APComments').show();
                    $('#IOComments').show();
                }
                else {
                    $('#TimeComments').hide();
                    $('#APComments').hide();
                    $('#IOComments').hide();
                }
                
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <telerik:RadToolBar ID="RadToolBarDynamicReportInitialLoading" runat="server" AutoPostBack="true" Width="100%">
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
                    <telerik:RadTab Text="Select C/D/P" PageViewID="RadPageViewWorkloadSelectCDP" Value="1">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Select Account Executives" PageViewID="RadPageViewSelectAEs" Value="2">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPageCalendar" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="RadPageViewOptions" runat="server">
                    <div class="form-layout label-left label-l">
                        <ul>
                            <li>
                                Employee Time Date:</li>
                            <li>
                                <telerik:RadDatePicker ID="RadDatePickerEmployeeTimeDate" runat="server" AutoPostBack="false" SkinID="RadDatePickerStandard"></telerik:RadDatePicker>
                            </li>
                        </ul>
                        <ul>
                            <li>
                                Income Only Date:</li>
                            <li>
                                <telerik:RadDatePicker ID="RadDatePickerIncomeOnlyDate" runat="server" AutoPostBack="false" SkinID="RadDatePickerStandard"></telerik:RadDatePicker>
                            </li>
                        </ul>
                        <ul>
                            <li>
                                A/P Posting Period:</li>
                            <li>
                                <telerik:RadComboBox ID="RadComboBoxAPPostingPeriod" runat="server" AutoPostBack="false" SkinID="RadComboBoxPostPeriod"></telerik:RadComboBox>
                            </li>
                        </ul>
                    </div>
                    <div class="form-layout label-left label-l">
                        <ul>
                            <li>
                                Type of Job:</li>
                            <li>
                                <asp:RadioButton id="RadioButtonAll" runat="server" Text="All" GroupName="TypeOfJob" Checked="True"/>
                            </li>
                        </ul>
                        <ul>
                            <li>&nbsp</li>
                            <li>
                                <asp:RadioButton id="RadioButtonAdvanceBillJobsOnly" runat="server" Text="Advance Bill Jobs Only" GroupName="TypeOfJob"/>
                            </li>
                        </ul>
                        <ul>
                            <li>&nbsp</li>
                            <li>
                                <asp:RadioButton id="RadioButtonServiceFeeJobsOnly" runat="server" Text="Service Fee Jobs Only" GroupName="TypeOfJob"/>
                            </li>
                        </ul>
                        <ul>
                            <li>Job Options:</li>
                            <li>
                                <asp:RadioButton id="RadioButtonOpenJobswithUnbilledandOther" runat="server" Text="Open Jobs with Unbilled and Other Records" GroupName="JobOption" Checked="True"/></li>
                        </ul>
                        <ul>
                            <li>&nbsp</li>
                            <li>
                                <asp:RadioButton id="RadioButtonOpenJobswithUnbilledOnly" runat="server" Text="Open Jobs with Unbilled Records Only" GroupName="JobOption"/></li>
                        </ul>
                        <ul>
                            <li>&nbsp</li>
                            <li>
                                <asp:RadioButton id="RadioButtonOpenJobs" runat="server" Text="Open Jobs" GroupName="JobOption"/></li>
                        </ul>
                        <ul>
                            <li>&nbsp</li>
                            <li>
                                <asp:CheckBox id="CheckBoxIncludeContingency" runat="server" Text="Include Contingency" /></li>
                        </ul>
                        <ul>
                            <li>&nbsp</li>
                            <li>
                                <asp:CheckBox id="CheckBoxIncludeNonBillableTimeDetail" runat="server" Text="Include Non-Billable Time Detail" AutoPostBack="false" onclick="javascript:EnableDisableNonbillableDates(this)" />
                            </li>
                            <li>
                                From Date:</li>
                            <li>
                                <telerik:RadDatePicker ID="RadDatePickerFromDate" runat="server" AutoPostBack="false" SkinID="RadDatePickerStandard" Enabled="false" ></telerik:RadDatePicker>
                            </li>
                            <li>
                                To Date:</li>
                            <li>
                                <telerik:RadDatePicker ID="RadDatePickerToDate" runat="server" AutoPostBack="false" SkinID="RadDatePickerStandard" Enabled="false" ></telerik:RadDatePicker>
                            </li>
                        </ul>
                        <ul>
                            <li>&nbsp</li>
                            <li>
                                <asp:CheckBox id="CheckBoxIncludeNonBillableAPIODetail" runat="server" Text="Include Non-Billable AP/IO Detail" /></li>
                        </ul>
                        <ul>
                            <li>&nbsp</li>
                            <li>
                                <asp:CheckBox id="CheckBoxPrintItemDetail" runat="server" Text="Print Item Detail" AutoPostBack="false" onclick="javascript:EnableDisableItemDetailCheckboxes(this)" />
                            </li>
                            <li>
                                <div id="TimeComments"><asp:CheckBox id="CheckBoxPopulateTimeComments" runat="server" Text="Populate Time Comments" /></div>
                            </li>
                            <li>
                                <div id="APComments"><asp:CheckBox id="CheckBoxPopulateAPComments" runat="server" Text="Populate AP Comments" /></div>
                            </li>
                            <li>
                                <div id="IOComments"><asp:CheckBox id="CheckBoxPopulateIOComments" runat="server" Text="Populate IO Comments" /></div>
                            </li>
                        </ul>
                        
                    </div>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewWorkloadSelectCDP" runat="server">
                    <table id="Table1" align="center" cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButtonAllCDP" runat="server" Text="All" GroupName="All" Checked="true" AutoPostBack="true" />
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
                                    EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true">
                                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                        <Selecting AllowRowSelect="True" />
                                    </ClientSettings>
                                    <MasterTableView DataKeyNames="Code,Client,ClientCode,Office,Division,DivisionCode,Product,IsInactive">
                                        <Columns>
                                            <%--<telerik:GridBoundColumn DataField="Office" HeaderText="Office" UniqueName="column5">
                                            </telerik:GridBoundColumn>--%>
                                            <telerik:GridBoundColumn DataField="Client" HeaderText="Client" UniqueName="column2">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Division" HeaderText="Division" UniqueName="column3">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Product" HeaderText="Product" UniqueName="column4">
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
                                    EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true">
                                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                        <Selecting AllowRowSelect="True" />
                                    </ClientSettings>
                                    <MasterTableView DataKeyNames="Code,Name">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="Code" HeaderText="Code" UniqueName="column3">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Name" HeaderText="Name" UniqueName="column2">
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
                
            </telerik:RadMultiPage>
        </div>
    </div>    
</asp:Content>
