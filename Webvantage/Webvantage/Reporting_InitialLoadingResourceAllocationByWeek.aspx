﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_InitialLoadingResourceAllocationByWeek.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.Reporting_InitialLoadingResourceAllocationByWeek"
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
            <td width="1%">
                &nbsp;
            </td>
            <td>
                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                    <tr>
                        <td runat="server" id="td3" width="10%">
                            View:
                        </td>
                        <td width="30%" colspan="3">
                            <asp:RadioButton ID="RadioButtonSummary" runat="server" Text="Summary" GroupName="View" Checked="true"  />
                            <asp:RadioButton ID="RadioButtonDetail" runat="server" Text="Detail" GroupName="View" />
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
                        <td runat="server" id="td1" width="10%">
                            Starting Week:
                        </td>
                        <td width="30%" colspan="3">
                            <telerik:RadDatePicker ID="RadDatePickerStartingWeek" runat="server" AutoPostBack="true" SkinID="RadDatePickerStandard">
                            </telerik:RadDatePicker>
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
                        <td runat="server" id="td2" width="10%">
                            No. of Weeks:
                        </td>
                        <td width="30%" colspan="3">
                            <telerik:RadComboBox ID="RadComboBoxWeek" runat="server" Width="50"
                                AutoPostBack="false" DataTextField="Week" DataValueField="Value">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
