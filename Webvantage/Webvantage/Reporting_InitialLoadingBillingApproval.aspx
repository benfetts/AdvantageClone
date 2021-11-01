<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_InitialLoadingBillingApproval.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.Reporting_InitialLoadingBillingApproval"
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
    <div class="no-float-menu">
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
    </div>
        
    

    <div class="telerik-aqua-body">
        <div class="form-layout label-left label-l">
            <telerik:RadTabStrip ID="RadTabStripTaskCalendar" runat="server" AutoPostBack="true" MultiPageID="RadMultiPageCalendar"
                Orientation="HorizontalTop" CausesValidation="false"
                Width="100%">
                <Tabs>
                    <telerik:RadTab Text="Options" PageViewID="RadPageViewOptions" Value="0" Selected="true">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Select C/D/P" PageViewID="RadPageViewWorkloadSelectCDP" Value="1">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Select Jobs" PageViewID="RadPageViewSelectJobs" Value="2">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Select Account Executives" PageViewID="RadPageViewSelectAEs" Value="3">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPageCalendar" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="RadPageViewOptions" runat="server">
                    <fieldset id="Fieldset1" runat="server">                        
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td width="1%">
                                    &nbsp;
                                </td>
                                <td>
                                    <table width="99%" border="0" cellspacing="2" cellpadding="0">
                                        <tr>
                                            <td width="10%">
                                                Include:
                                            </td> 
                                            <td width="90%">  
                                                <asp:RadioButton runat="server" ID="RadioButtonAll" GroupName="IncludeOption" Checked="true" Text="All" />
                                                <asp:RadioButton runat="server" ID="RadioButtonBilled" GroupName="IncludeOption" Text="Billed" />
                                                <asp:RadioButton runat="server" ID="RadioButtonUnbilled" GroupName="IncludeOption" Text="Unbilled" />
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
                                            <td>
                                                <telerik:RadDatePicker ID="RadDatePickerFrom" runat="server" AutoPostBack="false" SkinID="RadDatePickerStandard">
                                                </telerik:RadDatePicker>
                                                &nbsp;&nbsp;
                                                <telerik:RadButton ID="RadButtonYTD" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="YTD" Width="70">
                                                </telerik:RadButton>
                                                &nbsp;&nbsp;
                                                <telerik:RadButton ID="RadButton1Year" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="1 Year" Width="70">
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
                                            <td>
                                                <telerik:RadDatePicker ID="RadDatePickerTo" runat="server" AutoPostBack="false" SkinID="RadDatePickerStandard">
                                                </telerik:RadDatePicker>
                                                &nbsp;&nbsp;
                                                <telerik:RadButton ID="RadButtonMTD" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="MTD" Width="70">
                                                </telerik:RadButton>
                                                &nbsp;&nbsp;
                                                <telerik:RadButton ID="RadButton2Years" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="2 Year" Width="70">
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
                                            <td width="10%">
                                                Jobs:
                                            </td>
                                            <td width="90%">
                                                <asp:RadioButton runat="server" ID="RadioButtonOpenOnly" GroupName="OrderOption" Checked="true" Text="Open Only" />
                                                <asp:RadioButton runat="server" ID="RadioButtonOpenandClosed" GroupName="OrderOption" Text="Open and Closed" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </fieldset>            
                        
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
                                    EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true" AllowFilteringByColumn="true">
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
                                    EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true" AllowFilteringByColumn="true">
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
                                    EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true" AllowFilteringByColumn="true">
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
                <telerik:RadPageView ID="RadPageViewSelectJobs" runat="server">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButtonAllJobs" runat="server" Text="All Jobs" GroupName="Job" Checked="true" AutoPostBack="true" />
                                <asp:RadioButton ID="RadioButtonChooseJobs" runat="server" Text="Choose Jobs" GroupName="Job" AutoPostBack="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButtonOpenJobs" runat="server" Text="Open Jobs" GroupName="Open" Checked="true" AutoPostBack="true" />
                                <asp:RadioButton ID="RadioButtonOpenClosedJobs" runat="server" Text="Open/Closed Jobs" GroupName="Open" AutoPostBack="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="RadGridJobs" runat="server" AutoGenerateColumns="False" GridLines="None"
                                    EnableEmbeddedSkins="True" Width="95%" AllowMultiRowSelection="true" AllowFilteringByColumn="true">
                                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                                    </ClientSettings>
                                    <MasterTableView DataKeyNames="Number,Description">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="Number" HeaderText="Code" UniqueName="column3" SortExpression="Number"
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
                                    <ClientSettings EnableRowHoverStyle="true">
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
            </telerik:RadMultiPage>
        </div>
    </div>    
</asp:Content>
