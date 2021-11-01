<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_InitialLoadingOpenPurchaseOrderDetail.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.Reporting_InitialLoadingOpenPurchaseOrderDetail"
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
            <td width="1%">
                &nbsp;
            </td>
            <td>
                <br />
            </td>
        </tr>      
        <tr>
            <td align="left" valign="top" colspan="2">
                <telerik:RadTabStrip ID="RadTabStripPODetail" runat="server" AutoPostBack="true" MultiPageID="RadMultiPagePODetail"
                        Orientation="HorizontalTop"  CausesValidation="false"
                         Width="100%">
                        <Tabs>
                            <telerik:RadTab Text="Options" PageViewID="RadPageViewOptions" Value="0" Selected="true">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Select C/D/P" PageViewID="RadPageViewWorkloadSelectCDP" Value="1">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Select Vendors" PageViewID="RadPageViewVendors" Value="2">
                            </telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPagePODetail" runat="server" SelectedIndex="0">
                        <telerik:RadPageView ID="RadPageViewOptions" runat="server">
                            <table id="Table2" align="center" cellpadding="0" cellspacing="0" border="0" width="100%">
                                 <tr>
                                    <td width="1%">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <table width="99%" border="0" cellspacing="2" cellpadding="0">
                                            <tr>
                                                <td runat="server" id="tdFrom" width="15%">
                                                    Start Date:
                                                </td>
                                                &nbsp;
                                                <td>
                                                    <telerik:RadDatePicker ID="RadDatePickerFrom" runat="server" AutoPostBack="true" SkinID="RadDatePickerStandard">
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
                                <tr>
                                    <td width="1%">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <table width="99%" border="0" cellspacing="2" cellpadding="0">
                                            <tr>
                                                <td runat="server" id="tdTo" width="15%">
                                                    End Date:
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="RadDatePickerTo" runat="server" AutoPostBack="true" SkinID="RadDatePickerStandard">
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
                                </tr>
                                <tr>
                                    <td width="1%">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxIncludeClosedPOs" runat="server" AutoPostBack="true"
                                            Checked="false" Text="Include Completed PO's" Visible="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="1%"> 
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxIncludeVoidedPOs" runat="server" AutoPostBack="false"
                                            Checked="false" Text="Include Voided PO's" Visible="true" Enabled="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="1%">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxIncludeClientPOs" runat="server" AutoPostBack="true"
                                            Checked="true" Text="Include Client PO's" Visible="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="1%">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxIncludeNonClientPOs" runat="server" AutoPostBack="false"
                                            Checked="true" Text="Include Non-Client PO's" Visible="true" />
                                    </td>
                                </tr>
                            </table>                                         
                        </telerik:RadPageView>                        
                        <telerik:RadPageView ID="RadPageViewWorkloadSelectCDP" runat="server">
                            <table width="99%" border="0" cellspacing="2" cellpadding="0">
                                        <tr>
                                            <td align="left" valign="bottom">
                                                <telerik:RadButton ID="RadButtonAllClients" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
                                                    Checked="true" GroupName="Client" AutoPostBack="true" Text="All Clients" Font-Underline="false">
                                                </telerik:RadButton>
                                                <telerik:RadButton ID="RadButtonChooseClients" runat="server" ToggleType="Radio"
                                                    ButtonType="ToggleButton" Checked="false" GroupName="Client" AutoPostBack="true"
                                                    Text="Choose Clients" Font-Underline="false">
                                                </telerik:RadButton>
                                                <telerik:RadButton ID="RadButtonChooseClientDivision" runat="server" ToggleType="Radio"
                                                    ButtonType="ToggleButton" Checked="false" GroupName="Client" AutoPostBack="true"
                                                    Text="Choose Client/Divisions" Font-Underline="false">
                                                </telerik:RadButton>
                                                <telerik:RadButton ID="RadButtonChooseClientDivisionProduct" runat="server" ToggleType="Radio"
                                                    ButtonType="ToggleButton" Checked="false" GroupName="Client" AutoPostBack="true"
                                                    Text="Choose Client/Division/Products" Font-Underline="false">
                                                </telerik:RadButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <telerik:RadListBox ID="RadListBoxClients" runat="server" Width="100%" AutoPostBack="true"
                                                    Height="300" SelectionMode="Multiple" AllowReorder="False" EnableDragAndDrop="false"
                                                    DataValueField="Code" DataTextField="Name" Enabled="false">
                                                </telerik:RadListBox>
                                            </td>
                                        </tr>
                                    </table>                                         
                        </telerik:RadPageView>                        
                        <telerik:RadPageView ID="RadPageViewVendors" runat="server">
                            <table width="99%" border="0" cellspacing="2" cellpadding="0">
                                <tr>
                                    <td align="left" valign="bottom">
                                        <telerik:RadButton ID="RadButtonAllVendors" runat="server" ToggleType="Radio"
                                            ButtonType="ToggleButton" Checked="true" GroupName="Vendor" AutoPostBack="true"
                                            Text="All Vendors" Font-Underline="false">
                                        </telerik:RadButton>
                                        <telerik:RadButton ID="RadButtonChooseVendors" runat="server" ToggleType="Radio"
                                            ButtonType="ToggleButton" Checked="false" GroupName="Vendor" AutoPostBack="true"
                                            Text="Choose Vendors" Font-Underline="false">
                                        </telerik:RadButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <telerik:RadListBox ID="RadListBoxVendors" runat="server" Width="100%"
                                            AutoPostBack="false" Height="300" SelectionMode="Multiple" AllowReorder="False"
                                            EnableDragAndDrop="false" DataValueField="Code" DataTextField="Name" Enabled="false">
                                        </telerik:RadListBox>
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
