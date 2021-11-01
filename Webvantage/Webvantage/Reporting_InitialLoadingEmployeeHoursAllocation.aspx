<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_InitialLoadingEmployeeHoursAllocation.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.Reporting_InitialLoadingEmployeeHoursAllocation"
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
                        <telerik:RadTab Text="Select Departments" PageViewID="RadPageViewSelectDepartments" Value="2">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Select Roles" PageViewID="RadPageViewSelectRoles" Value="3">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Select Employees" PageViewID="RadPageViewSelectEmployees" Value="4">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPageCalendar" runat="server" SelectedIndex="0">
                     <telerik:RadPageView ID="RadPageViewOptions" runat="server">  
                         <table align="left" border="0" cellpadding="0" cellspacing="0" width="60%">
                                <tr> 
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>&nbsp; 
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="50px">
                                        <asp:Label ID="lblFrom" runat="server" Text="From: "></asp:Label>&nbsp;                                                                    
                                    </td>
                                    <td align="left" width="220px">
                                        <telerik:RadDatePicker ID="RadDatePickerFrom" runat="server" AutoPostBack="true" SkinID="RadDatePickerStandard"></telerik:RadDatePicker>
                                    </td>
                                    <td align="left" width="50px">
                                        <asp:Label ID="lblTo" runat="server" Text="To: "></asp:Label>&nbsp;                                                                    
                                    </td>
                                    <td align="left" width="220px">
                                        <telerik:RadDatePicker ID="RadDatePickerTo" runat="server" AutoPostBack="true" SkinID="RadDatePickerStandard"></telerik:RadDatePicker>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td align="left" width="50px">
                                        <asp:Label ID="lblBy" runat="server" Text="By: "></asp:Label>&nbsp;                                                                    
                                    </td>
                                    <td align="left" width="220px">
                                        <asp:RadioButton ID="RadioButtonDay" runat="server" GroupName="GroupBy" Text="Day" Checked="true" /> 
                                        <asp:RadioButton ID="RadioButtonWeek" runat="server" GroupName="GroupBy" Text="Week" />     
                                        <asp:RadioButton ID="RadioButtonMonth" runat="server" GroupName="GroupBy" Text="Month" />
                                    </td>
                                    <td align="left"  width="50px">
                                        <asp:CheckBox ID="CheckBoxActualized" runat="server" Text="Actualized" Visible="false" /> 
                                    </td>
                                   <td align="left"  width="220px">
                                        <asp:Label ID="Label2" runat="server" Text="" Visible="false"></asp:Label>&nbsp; 
                                    </td>
                                </tr> 
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td align="left" width="50px">
                                        &nbsp;                                                                  
                                    </td>
                                    <td align="left" width="220px">
                                        <asp:CheckBox ID="CheckBoxIncludeActuals" runat="server" Text="Include Actuals" /> 
                                    </td>
                                    <td align="left"  width="50px">
                                        &nbsp;  
                                    </td>
                                   <td align="left"  width="220px">
                                        &nbsp; 
                                    </td>
                                </tr> 
                        </table>
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
                     <telerik:RadPageView ID="RadPageViewSelectDepartments" runat="server">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <asp:RadioButton ID="RadioButtonAllDepartments" runat="server" Text="All Departments" GroupName="Department" Checked="true" AutoPostBack="true" />
                                    <asp:RadioButton ID="RadioButtonChooseDepartments" runat="server" Text="Choose Departments" GroupName="Department" AutoPostBack="true" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RadGridDepartment" runat="server" AutoGenerateColumns="False" GridLines="None"
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
                     <telerik:RadPageView ID="RadPageViewSelectRoles" runat="server">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <asp:RadioButton ID="RadioButtonAllRoles" runat="server" Text="All Roles" GroupName="Role" Checked="true" AutoPostBack="true" />
                                    <asp:RadioButton ID="RadioButtonChooseRoles" runat="server" Text="Choose Roles" GroupName="Role" AutoPostBack="true" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RadGridRole" runat="server" AutoGenerateColumns="False" GridLines="None"
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
                     <telerik:RadPageView ID="RadPageViewSelectEmployees" runat="server">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <asp:RadioButton ID="RadioButtonAllEmployees" runat="server" Text="All Employees" GroupName="Employee" Checked="true" AutoPostBack="true" />
                                    <asp:RadioButton ID="RadioButtonChooseEmployees" runat="server" Text="Choose Employees" GroupName="Employee" AutoPostBack="true" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RadGridEmployee" runat="server" AutoGenerateColumns="False" GridLines="None"
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
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
