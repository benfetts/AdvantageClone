<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_InitialLoadingMediaPlan.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.Reporting_InitialLoadingMediaPlan"
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
                    Orientation="HorizontalTop" CausesValidation="false"
                    Width="100%">
                    <Tabs>
                        <telerik:RadTab Text="Options" PageViewID="RadPageViewOptions" Value="0">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Select Offices" PageViewID="RadPageViewSelectOffices" Value="0">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Select C/D/P" PageViewID="RadPageViewWorkloadSelectCDP" Value="1">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPageCalendar" runat="server" SelectedIndex="0">   
                    <telerik:RadPageView ID="RadPageViewOptions" runat="server">
                        <table id="TablePageViewOptions" align="center" cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td valign="top">
                                    <fieldset id="FieldsetSelectBy" runat="server">
                                        <legend>Display Month/Year</legend>
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:RadioButton ID="RadioButtonStandard" runat="server" Text="Standard Month/Year" GroupName="SelectBy" Checked="true" AutoPostBack="true" /><br />
                                                    <asp:RadioButton ID="RadioButtonBroadcast" runat="server" Text="Broadcast Month/Year" GroupName="SelectBy" AutoPostBack="true" />                                                    
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
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
                </telerik:RadMultiPage>
            </td>
        </tr>

    </table>
    <br />
</asp:Content>
